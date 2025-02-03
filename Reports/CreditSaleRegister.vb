Imports System.Data.SqlClient
Imports System.IO
Public Class CreditSaleRegister
    Public pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Dim dblBasic, dblTax, dblNet, dblPaid As Double
    Dim dblNBasic, dblNTax, dblNNet, dblNPaid As Double
    Public Function Reportdetails(ByVal SQLSTRING As String, ByVal SQLSTRING2 As String, ByVal columnheading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim dblmembertot, dblCosttot, dblDoctot, dblGrand, POSCount, doccount, gdoccount, POSGrand, POStotal, POSGrandtotal As Double
        Dim Membername, Posdesc As String
        Dim Memberbool, POSbool As Boolean
        Dim MCODE, BILLNO, BILLDETAILS, ADDUSERCODE, CATEGORY As String
        Dim I As Integer
        Dim STRSTRING As String
        Dim dblBTax, dblBNet As Double
        Dim BILLDATE As Date

        Try
            Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            Call PrintHeader(columnheading, mskfromdate, msktodate)
            gconnection.getDataSet(SQLSTRING, "CREDITSALEREGISTER")
            If gdataset.Tables("CREDITSALEREGISTER").Rows.Count > 0 Then
                I = 0
                For Each dr In gdataset.Tables("CREDITSALEREGISTER").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(79, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(columnheading, mskfromdate, msktodate)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If MCODE <> dr("MCODE") Then
                        If Val(dblNNet) > 0 Then
                            Filewrite.WriteLine(StrDup(79, "."))
                            pagesize = pagesize + 1
                            Filewrite.WriteLine(Mid(UCase(MCODE), 1, 20) & "  Total =====>" & Space(40) & Space(10 - Len(Mid(Format(Val(dblNNet), "0.00"), 1, 10))) & Mid(Format(Val(dblNNet), "0.00"), 1, 10) & Space(1) & Space(8 - Len(Mid(Format(Val(dblNTax), "0.00"), 1, 8))) & Mid(Format(Val(dblNTax), "0.00"), 1, 8))
                            pagesize = pagesize + 1
                            Filewrite.WriteLine(StrDup(79, "."))
                            pagesize = pagesize + 1
                        End If
                        Filewrite.WriteLine(Mid(CStr(dr("MCODE")), 1, 6) & Space(6 - Len(Mid(CStr(dr("MCODE")), 1, 6))) & "  : " & Mid(dr("MNAME"), 1, 40) & Space(40 - Len(Mid(dr("MNAME"), 1, 40))))
                        Filewrite.WriteLine()
                        pagesize = pagesize + 2
                        dblNTax = 0
                        dblNNet = 0
                    End If
                    If BILLDETAILS <> dr("BILLDETAILS") Then
                        If Val(dblBNet) > 0 Then
                            '                            Filewrite.WriteLine(Mid(CStr(BILLDETAILS), 1, 17) & Space(17 - Len(Mid(CStr(BILLDETAILS), 1, 17))) & " : " & Mid(Format(CDate(BILLDATE), "dd/MMM/yyyy"), 1, 12) & Space(12 - Len(Mid(Format(CDate(BILLDATE), "dd/MMM/yyyy"), 1, 12))) & Space(25) & Space(10 - Len(Mid(Format(Val(dblBNet), "0.00"), 1, 10))) & Mid(Format(Val(dblBNet), "0.00"), 1, 10) & Space(1) & Space(8 - Len(Mid(Format(Val(dblBTax), "0.00"), 1, 8))) & Mid(Format(Val(dblBTax), "0.00"), 1, 8))
                            Filewrite.WriteLine(Space(47) & StrDup(31, "-"))
                            Filewrite.WriteLine(Space(47) & "Total   : " & Space(10 - Len(Mid(Trim(Format(Val(dblBNet), "0.00")), 1, 10))) & Mid(Trim(Format(Val(dblBNet), "0.00")), 1, 10) & Space(1) & Space(8 - Len(Mid(Trim(Format(Val(dblBTax), "0.00")), 1, 8))) & Mid(Trim(Format(Val(dblBTax), "0.00")), 1, 8))
                            Filewrite.WriteLine(Space(47) & StrDup(31, "-"))
                            pagesize = pagesize + 3
                        End If
                        dblBTax = 0
                        dblBNet = 0
                        ADDUSERCODE = ""
                        CATEGORY = ""
                    End If
                    If CATEGORY <> dr("CATEGORY") Then
                        Filewrite.Write(Mid(dr("CATEGORY"), 1, 3) & Space(3 - Len(Mid(dr("CATEGORY"), 1, 3))))
                    Else
                        Filewrite.Write(Space(3))
                    End If

                    If ADDUSERCODE <> dr("ADDUSERID") Then
                        Filewrite.Write(Space(1) & Mid(dr("ADDUSERID"), 1, 4) & Space(4 - Len(Mid(dr("ADDUSERID"), 1, 4))))
                    Else
                        Filewrite.Write(Space(5))
                    End If
                    If BILLDETAILS <> dr("BILLDETAILS") Then
                        Filewrite.Write(Space(1) & Mid(dr("BILLDETAILS"), 1, 16) & Space(16 - Len(Mid(dr("BILLDETAILS"), 1, 16))))
                    Else
                        Filewrite.Write(Space(17))
                    End If
                    Filewrite.Write(Space(1) & Mid(dr("ITEMCODE"), 1, 5) & Space(5 - Len(Mid(dr("ITEMCODE"), 1, 5))))
                    Filewrite.Write(Space(1) & Mid(dr("ITEMDESC"), 1, 20) & Space(20 - Len(Mid(dr("ITEMDESC"), 1, 20))))
                    Filewrite.Write(Space(1) & Space(5 - Len(Mid(Format(dr("QTY"), "0"), 1, 5))) & Mid(Format(dr("QTY"), "0"), 1, 5))
                    Filewrite.Write(Space(1) & Space(8 - Len(Mid(Format(dr("AMOUNT"), "0.00"), 1, 8))) & Mid(Format(dr("AMOUNT"), "0.00"), 1, 8))
                    Filewrite.WriteLine(Space(1) & Space(8 - Len(Mid(Format(dr("TAXAMOUNT"), "0.00"), 1, 8))) & Mid(Format(dr("TAXAMOUNT"), "0.00"), 1, 8))
                    dblTax = dblTax + Format(Val(dr("TAXAMOUNT")), "0.00")
                    dblNet = dblNet + Format(Val(dr("AMOUNT")), "0.00")
                    dblNTax = dblNTax + Format(Val(dr("TAXAMOUNT")), "0.00")
                    dblNNet = dblNNet + Format(Val(dr("AMOUNT")), "0.00")

                    dblBTax = dblBTax + Format(Val(dr("TAXAMOUNT")), "0.00")
                    dblBNet = dblBNet + Format(Val(dr("AMOUNT")), "0.00")

                    MCODE = dr("MCODE")

                    BILLDETAILS = dr("BILLDETAILS")
                    BILLDATE = dr("BILLDATE")
                    ADDUSERCODE = dr("ADDUSERID")
                    CATEGORY = dr("CATEGORY")
                    pagesize = pagesize + 1
                Next dr
                Filewrite.WriteLine(Space(47) & StrDup(31, "-"))
                Filewrite.WriteLine(Space(47) & "Total   : " & Space(10 - Len(Mid(Trim(Format(Val(dblBNet), "0.00")), 1, 10))) & Mid(Trim(Format(Val(dblBNet), "0.00")), 1, 10) & Space(1) & Space(8 - Len(Mid(Trim(Format(Val(dblBTax), "0.00")), 1, 8))) & Mid(Trim(Format(Val(dblBTax), "0.00")), 1, 8))

                pagesize = pagesize + 2
                Filewrite.WriteLine(StrDup(79, "."))
                Filewrite.WriteLine(Mid(UCase(MCODE), 1, 20) & "  Total =====>" & Space(40) & Space(10 - Len(Mid(Format(Val(dblNNet), "0.00"), 1, 10))) & Mid(Format(Val(dblNNet), "0.00"), 1, 10) & Space(1) & Space(8 - Len(Mid(Format(Val(dblNTax), "0.00"), 1, 8))) & Mid(Format(Val(dblNTax), "0.00"), 1, 8))
                Filewrite.WriteLine(StrDup(79, "."))
                pagesize = pagesize + 3
                Call grandtotal()
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
    Private Function grandtotal()
        Filewrite.WriteLine(StrDup(79, "-"))
        pagesize = pagesize + 1
        Filewrite.WriteLine(Space(16) & "Grand Total =====>" & Space(24) & Space(10 - Len(Mid(Format(Val(dblNet), "0.00"), 1, 10))) & Mid(Format(Val(dblNet), "0.00"), 1, 10) & Space(1) & Space(8 - Len(Mid(Format(Val(dblTax), "0.00"), 1, 8))) & Mid(Format(Val(dblTax), "0.00"), 1, 8))
        pagesize = pagesize + 1
        Filewrite.WriteLine(StrDup(79, "-"))
        pagesize = pagesize + 1
    End Function
    Private Function PrintHeader(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        pagesize = 0
        Try
            If pageno <= 1 Then
                Filewrite.WriteLine("{0,10}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "")
                pagesize = pagesize + 1
                Filewrite.WriteLine(Chr(18))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,-30}{1,17}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
                pagesize = pagesize + 1
            End If
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,30}{1,-10}", "CREDIT SALES REGISTER", " PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(79, "="))
            pagesize = pagesize + 1
            Filewrite.WriteLine("MEM.     BILLDETAILS      ITEM   ITEM DESCRIPTION       QTY   AMOUNT TAX AMOUNT")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(79, "="))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
