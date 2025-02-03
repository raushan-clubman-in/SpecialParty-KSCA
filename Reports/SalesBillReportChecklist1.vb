Imports System.Data.SqlClient
Imports System.IO
Public Class SalesBillChecklist1Report
    Dim dr As DataRow
    Dim pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim rowcount, rowtotal
    Dim dblBasic, dblTax, dblNet, dblPaid, Total As Double
    Dim dblUBasic, dblUTax, dblUNet, dblUPaid As Double
    Dim dblUroff As Double
    Public Function ReportDetails(ByVal SQLSTRING As String, ByVal pageheading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal RSNO As Integer, ByVal frm As Object)
        Dim docdate, changeno, billsdetails, servercode, billamount, totalamount, POSCode, dblBasicamt, dblnetamt As String
        Dim amount, basic, discountamount, i As Integer
        Dim GrandQty, GrandAmount As Double
        Dim OBJ As New SalesBillChecklist1
        Dim SSQL As String
        Dim USERNAME, BILLNO, STRSTRING, BILLDETAILS, MNAME, sqlstr, sqlstr1 As String
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".Txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            Call ReportHeader(pageheading, mskfromdate, msktodate)
            gconnection.getDataSet(SQLSTRING, "SALEBILLCHECKLIST")
            rowtotal = gdataset.Tables("SALEBILLCHECKLIST").Rows.Count
            rowcount = 100 / rowtotal
            If gdataset.Tables("SALEBILLCHECKLIST").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                basic = 0
                amount = 0
                For Each dr In gdataset.Tables("SALEBILLCHECKLIST").Rows
                    If pagesize > 56 Then
                        Filewrite.WriteLine(StrDup(130, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call ReportHeader(pageheading, mskfromdate, msktodate)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If POSCode <> dr("POSDESC") Then
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-30}", Chr(14) & Chr(15) & Mid(CStr(dr("POSDESC")), 1, 25) & ":")
                        pagesize = pagesize + 1
                        POSCode = dr("POSDESC")
                    End If

                    'If billsdetails <> Trim(dr("BILLDETAILS")) Then
                    'SSQL = "SELECT SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT "
                    'If RSNO = 2 Then
                    '    SSQL = SSQL & " FROM VIEWSALEBILLCHECKLIST_PARK_SUMMARY WHERE POSCODE = '" & Trim(CStr(dr("POSCODE"))) & "' AND BILLDETAILS ="
                    'ElseIf RSNO = 3 Then
                    '    SSQL = SSQL & " FROM VIEWSALEBILLCHECKLIST_MC_SUMMARY WHERE POSCODE = '" & Trim(CStr(dr("POSCODE"))) & "' AND BILLDETAILS ="
                    'Else
                    '    SSQL = SSQL & " FROM VIEWSALEBILLCHECKLIST WHERE POSCODE = '" & Trim(CStr(dr("POSCODE"))) & "' AND BILLDETAILS ="
                    'End If
                    'SSQL = SSQL & " '" & Trim(dr("billdetails")) & "'  GROUP BY POSDESC,BILLDETAILS ORDER BY POSDESC"
                    'gconnection.getDataSet(SSQL, "VIEWSALEREGISTER")
                    Filewrite.Write("{0,-12}", Mid(Format(dr("BILLDATE"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dr("BILLDATE"), "dd/MM/yyyy"), 1, 10))))
                    Filewrite.Write("{0,-20}", Mid(CStr(dr("BILLDETAILS")), 1, 20) & Space(20 - Len(Mid(CStr(dr("BILLDETAILS")), 1, 20))))
                    Filewrite.Write("{0,-6}", Mid(CStr(dr("SERVERCODE")), 1, 6) & Space(6 - Len(Mid(CStr(dr("SERVERCODE")), 1, 6))))
                    Filewrite.Write("{0,-6}", Mid(CStr(dr("ADDUSERID")), 1, 6) & Space(6 - Len(Mid(CStr(dr("ADDUSERID")), 1, 6))))
                    Filewrite.Write("{0,-8}", Mid(CStr(dr("MCODE")), 1, 8) & Space(8 - Len(Mid(CStr(dr("MCODE")), 1, 8))))
                    Filewrite.Write("{0,-8}", Mid(CStr(dr("ITEMCODE")), 1, 8) & Space(8 - Len(Mid(CStr(dr("ITEMCODE")), 1, 8))))
                    Filewrite.Write("{0,-24}", Mid(CStr(dr("ITEMDESC")), 1, 24) & Space(24 - Len(Mid(CStr(dr("ITEMDESC")), 1, 24))))
                    Filewrite.Write("{0,8}", Space(8 - Len(Mid(Format(Val(dr("QTY")), "0"), 1, 8))) & Mid(Format(Val(dr("QTY")), "0"), 1, 8))
                    Filewrite.Write("{0,8}", Space(8 - Len(Mid(Format(Val(dr("RATE")), "0.00"), 1, 8))) & Mid(Format(Val(dr("RATE")), "0.00"), 1, 8))
                    Filewrite.Write("{0,10}", Space(10 - Len(Mid(Format(Val(dr("AMOUNT")), "0.00"), 1, 10))) & Mid(Format(Val(dr("AMOUNT")), "0.00"), 1, 10))
                    Filewrite.Write("{0,10}", Space(10 - Len(Mid(Format(Val(dr("TAXAMOUNT")), "0.00"), 1, 10))) & Mid(Format(Val(dr("TAXAMOUNT")), "0.00"), 1, 10))
                    Filewrite.WriteLine("{0,10}", Space(10 - Len(Mid(Format(Val(dr("TOTALAMOUNT")), "0.00"), 1, 10))) & Mid(Format(Val(dr("TOTALAMOUNT")), "0.00"), 1, 10))
                    pagesize = pagesize + 1
                    billsdetails = Trim(dr("BILLDETAILS"))
                    'Filewrite.Write("{0,12}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTER").Rows(0).Item("AMOUNT")), "0.00"), 1, 12))
                    'dblBasicamt = Val(dblBasicamt) + Format(Val(gdataset.Tables("VIEWSALEREGISTER").Rows(0).Item("AMOUNT")), "0.00")
                    'Filewrite.Write("{0,12}{1,-5}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTER").Rows(0).Item("AMOUNT") + gdataset.Tables("VIEWSALEREGISTER").Rows(0).Item("TAXAMOUNT")), "0.00"), 1, 12), "")
                    'dblnetamt = Val(dblnetamt) + Format(Val(gdataset.Tables("VIEWSALEREGISTER").Rows(0).Item("AMOUNT") + gdataset.Tables("VIEWSALEREGISTER").Rows(0).Item("TAXAMOUNT")), "0.00")
                    'Else
                    '    'Filewrite.Write("{0,-12}{1,-20}{2,-6}{3,12}{4,12}{5,-5}", "", " ", " ", " ", " ", " ")
                    '    Filewrite.Write("{0,-12}{1,-20}{2,-6}{3,-8}", "", " ", " ", " ")
                    '    Filewrite.Write("{0,-10}", Mid(CStr(dr("ITEMCODE")), 1, 8))
                    '    Filewrite.Write("{0,-25}", Mid(CStr(dr("ITEMDESC")), 1, 25))
                    '    Filewrite.Write("{0,8}", Mid(Format(Val(dr("QTY")), "0.00"), 1, 8))
                    '    Filewrite.Write("{0,10}", Mid(Format(Val(dr("RATE")), "0.00"), 1, 10))
                    '    Filewrite.Write("{0,10}", Mid(Format(Val(dr("AMOUNT")), "0.00"), 1, 10))
                    ' End If
                    dblnetamt = Val(dblnetamt) + dr("TOTALAMOUNT")
                    dblBasicamt = Val(dblBasicamt) + dr("AMOUNT")
                    dblTax = Val(dblTax) + dr("TAXAMOUNT")
                    GrandAmount = GrandAmount + Format(Val(dr("AMOUNT")), "0.00")
                    GrandQty = GrandQty + Format(Val(dr("QTY")), "0.00")
                Next dr
                Filewrite.WriteLine(StrDup(130, "="))
                pagesize = pagesize + 1
                Filewrite.Write(Space(69) & "GRAND TOTAL ====>")
                Filewrite.Write(Space(6 - Len(Mid(Format(Val(GrandQty), "0"), 1, 6))) & Mid(Format(Val(GrandQty), "0"), 1, 6))
                Filewrite.Write(Space(8) & Space(10 - Len(Mid(Format(Val(dblBasicamt), "0.00"), 1, 10))) & Mid(Format(Val(dblBasicamt), "0.00"), 1, 10))
                Filewrite.Write(Space(10 - Len(Mid(Format(Val(dblTax), "0.00"), 1, 10))) & Mid(Format(Val(dblTax), "0.00"), 1, 10))
                Filewrite.WriteLine(Space(10 - Len(Mid(Format(Val(dblnetamt), "0.00"), 1, 10))) & Mid(Format(Val(dblnetamt), "0.00"), 1, 10))
                pagesize = pagesize + 1
                'Filewrite.Write("{0,12}{1,-20}", "", "GRAND TOTAL =====>")
                'Filewrite.Write("{0,12}{1,10}{2,19}{3,8}{4,8}", "", "", "", "", Format(Val(GrandQty), "0.00"))
                'Filewrite.Write("{0,12}{1,8}", "", Mid(Format(Val(dblBasicamt), "0.00"), 1, 8), Mid(Format(Val(dblnetamt), "0.00"), 1, 8))
                'Filewrite.Write("{0,4}{1,8}", "", Mid(Format(Val(dblBasicamt), "0.00"), 1, 8), Mid(Format(Val(dblnetamt), "0.00"), 1, 8))
                'Filewrite.Write("{0,2}{1,10}", "", Format(Val(dblnetamt), "0.00"))
                Filewrite.WriteLine(StrDup(130, "="))
                pagesize = pagesize + 1
            Else
                MessageBox.Show("NO RECORD TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
            End If
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile1(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Function
        End Try
    End Function
    Private Function ReportHeader(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        pagesize = 0
        Try
            Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialYearEnd)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "SUMMARY")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(130, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("BILL        BILL              WAITER  USER  MCODE   ITEM      ITEM                          QTY   RATE    AMOUNT       TAX     TOTAL")
            pagesize = pagesize + 1
            Filewrite.WriteLine("DATE        NUMBER              CODE  CODE  CODE    CODE      DESCRIPTION                                             AMOUNT   AMOUNT")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(130, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class