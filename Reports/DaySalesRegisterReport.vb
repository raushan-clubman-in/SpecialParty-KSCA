Imports System.data.sqlclient
Imports System.io
Public Class DaySalesRegisterReport
    Public pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    'Public Function ReportsDetails(ByVal SQLSTRING As String, ByVal PAGEHEADER() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
    '    Dim dblPurchaserate, dblBillamt, dblTaxamt, dblTotalamt, dblTotal As Double
    '    Dim dblGrandPackamount, dblGrandRoundoff, dblDayPackamount, dblDayRoundoff As Double
    '    Dim dblDayPurchaserate, dblDayBillamt, dblDayTaxamt, dblDayTotalamt, dblDayTotal As Double
    '    Dim dblGrandPurchaserate, dblGrandBillamt, dblGrandTaxamt, dblGrandTotalamt, dblGrandTotal As Double
    '    Dim POSDESC, SSQL As String
    '    Dim BILLDATE As Date
    '    Dim Billdatebool As Boolean
    '    Dim I, J As Integer
    '    Try
    '        Call Randomize()
    '        AppPath = Application.StartupPath
    '        vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
    '        VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
    '        Filewrite = File.AppendText(VFilePath)
    '        printfile = VFilePath
    '        pageno = 1
    '        Filewrite.Write(Chr(15))
    '        Call PrintHeader(PAGEHEADER, FROMDATE, TODATE)
    '        gconnection.getDataSet(SQLSTRING, "DAYWISESALEREGISTER")
    '        If gdataset.Tables("DAYWISESALEREGISTER").Rows.Count > 0 Then
    '            Filewrite.WriteLine()
    '            pagesize = pagesize + 1
    '            For Each dr In gdataset.Tables("DAYWISESALEREGISTER").Rows
    '                If pagesize > 58 Then
    '                    Filewrite.Write(StrDup(135, "-"))
    '                    Filewrite.Write(Chr(12))
    '                    pageno = pageno + 1
    '                    Call PrintHeader(PAGEHEADER, FROMDATE, TODATE)
    '                End If
    '                If Format(DateValue(BILLDATE), "dd/MM/yyyy") <> Format(CDate(dr("BILLDATE")), "dd/MM/yyyy") Then
    '                    If Billdatebool = True Then
    '                        Filewrite.WriteLine(StrDup(135, "."))
    '                        pagesize = pagesize + 1
    '                        Filewrite.Write("{0,-16}{1,-20}{2,13}", "", "DAY TOTAL =====>", Mid(Format(Val(dblDayPurchaserate), "0.00"), 1, 13))
    '                        Filewrite.Write("{0,13}{1,13}{2,13}", Mid(Format(Val(dblDayTaxamt), "0.00"), 1, 13), Mid(Format(Val(dblDayTotalamt), "0.00"), 1, 13), Mid(Format(Val(dblDayPackamount), "0.00"), 1, 13))
    '                        Filewrite.WriteLine("{0,13}{1,13}{2,13}", "", Mid(Format(Val(dblDayRoundoff), "0.00"), 1, 13), Mid(Format(Val(dblDayTotal), "0.00"), 1, 13))
    '                        pagesize = pagesize + 1
    '                        Filewrite.WriteLine(StrDup(135, "."))
    '                        pagesize = pagesize + 1
    '                        Filewrite.WriteLine("{0,-16}", Mid(Format(dr("BILLDATE"), "dd/MM/yyyy"), 1, 15))
    '                        pagesize = pagesize + 1
    '                        BILLDATE = CDate(dr("BILLDATE"))
    '                        dblDayPurchaserate = 0 : dblDayTaxamt = 0 : dblDayTotalamt = 0 : dblDayTotal = 0
    '                        dblDayPackamount = 0 : dblDayRoundoff = 0
    '                        POSDESC = ""
    '                    Else
    '                        Filewrite.WriteLine("{0,-16}", Mid(Format(dr("BILLDATE"), "dd/MM/yyyy"), 1, 15))
    '                        pagesize = pagesize + 1
    '                        BILLDATE = CDate(dr("BILLDATE"))
    '                        Billdatebool = True
    '                    End If
    '                End If
    '                If POSDESC <> Trim(CStr(dr("POSDESC"))) Then
    '                    Filewrite.Write("{0,-16}{1,-20}", "", Mid(CStr(dr("POSDESC")), 1, 20))
    '                    SSQL = "SELECT SUM(PURCHASERATE) AS PURCHASERATE,SUM(BILLAMOUNT) AS BILLAMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT,"
    '                    SSQL = SSQL & " SUM(PACKAMOUNT) AS PACKAMOUNT,SUM(ROUNDOFF) AS ROUNDOFF,0 AS DISCOUNT,SUM(TOTALAMOUNT) AS TOTALAMOUNT FROM VIEWSALEREGISTERDAYWISE "
    '                    SSQL = SSQL & " WHERE POSDESC = '" & Trim(CStr(dr("POSDESC"))) & "' AND ISNULL(DELFLAG,'') <> 'Y'  AND BILLDATE ="
    '                    SSQL = SSQL & " '" & Format(BILLDATE, "yyyy-MM-dd") & "'  GROUP BY POSDESC ORDER BY POSDESC"
    '                    gconnection.getDataSet(SSQL, "VIEWSALEREGISTERDAYWISE")
    '                    If gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows.Count > 0 Then
    '                        Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PURCHASERATE")), "0.00"), 1, 12))
    '                        dblDayPurchaserate = dblDayPurchaserate + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PURCHASERATE")), "0.00")
    '                        dblGrandPurchaserate = dblGrandPurchaserate + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PURCHASERATE")), "0.00")
    '                        Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TAXAMOUNT")), "0.00"), 1, 12))
    '                        dblDayTaxamt = dblDayTaxamt + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TAXAMOUNT")), "0.00")
    '                        dblGrandTaxamt = dblGrandTaxamt + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TAXAMOUNT")), "0.00")
    '                        ''-----------------
    '                        Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("BILLAMOUNT")), "0.00"), 1, 12))
    '                        dblDayTotalamt = dblDayTotalamt + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("BILLAMOUNT")), "0.00")
    '                        dblGrandTotalamt = dblGrandTotalamt + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("BILLAMOUNT")), "0.00")
    '                        ''-----------------
    '                        Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PACKAMOUNT")), "0.00"), 1, 12))
    '                        dblDayPackamount = dblDayPackamount + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PACKAMOUNT")), "0.00")
    '                        dblGrandPackamount = dblGrandPackamount + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PACKAMOUNT")), "0.00")
    '                        ''-----------------
    '                        Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("DISCOUNT"))) & "%", 1, 12))
    '                        ''-----------------
    '                        Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("ROUNDOFF")), "0.00"), 1, 12))
    '                        dblDayRoundoff = dblDayRoundoff + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("ROUNDOFF")), "0.00")
    '                        dblGrandRoundoff = dblGrandRoundoff + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("ROUNDOFF")), "0.00")
    '                        ''-----------------
    '                        Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TOTALAMOUNT")), "0.00"), 1, 12))
    '                        dblDayTotal = dblDayTotal + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TOTALAMOUNT")), "0.00")
    '                        dblGrandTotal = dblGrandTotal + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TOTALAMOUNT")), "0.00")
    '                        Filewrite.WriteLine()
    '                        pagesize = pagesize + 1
    '                    End If
    '                    I = I + 1
    '                    POSDESC = Trim(CStr(dr("POSDESC")))
    '                End If
    '            Next dr
    '            Filewrite.WriteLine(StrDup(135, "."))
    '            pagesize = pagesize + 1
    '            Filewrite.Write("{0,-16}{1,-20}{2,13}", "", "DAY TOTAL =====>", Mid(Format(Val(dblDayPurchaserate), "0.00"), 1, 13))
    '            Filewrite.Write("{0,13}{1,13}{2,13}", Mid(Format(Val(dblDayTaxamt), "0.00"), 1, 13), Mid(Format(Val(dblDayTotalamt), "0.00"), 1, 13), Mid(Format(Val(dblDayPackamount), "0.00"), 1, 13))
    '            Filewrite.WriteLine("{0,13}{1,13}{2,13}", "", Mid(Format(Val(dblDayRoundoff), "0.00"), 1, 13), Mid(Format(Val(dblDayTotal), "0.00"), 1, 13))
    '            pagesize = pagesize + 1
    '            Filewrite.WriteLine(StrDup(135, "."))
    '            pagesize = pagesize + 1
    '            Filewrite.WriteLine(StrDup(135, "="))
    '            pagesize = pagesize + 1
    '            Filewrite.Write("{0,-16}{1,-20}", " ", "GRAND TOTAL ===>")
    '            Filewrite.Write("{0,13}", Format(Val(dblGrandPurchaserate), "0.00"))
    '            Filewrite.Write("{0,13}", Format(Val(dblGrandTaxamt), "0.00"))
    '            Filewrite.Write("{0,13}", Format(Val(dblGrandTotalamt), "0.00"))
    '            Filewrite.Write("{0,13}{1,13}", Format(Val(dblGrandPackamount), "0.00"), "")
    '            Filewrite.Write("{0,13}", Format(Val(dblGrandRoundoff), "0.00"))
    '            Filewrite.Write("{0,13}", Format(Val(dblGrandTotal), "0.00"))
    '            Filewrite.WriteLine()
    '            pagesize = pagesize + 1
    '            Filewrite.WriteLine(StrDup(135, "="))
    '            pagesize = pagesize + 1
    '        Else
    '            MessageBox.Show("NO RECORD TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
    '            Exit Function
    '        End If
    '        Filewrite.Write(Chr(12))
    '        Filewrite.Close()
    '        If gPrint = False Then
    '            OpenTextFile(vOutfile)
    '        Else
    '            PrintTextFile1(VFilePath)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message & ex.Source & ex.ToString)
    '        Exit Function
    '    End Try
    'End Function
    Public Function ReportsDetails(ByVal SQLSTRING As String, ByVal PAGEHEADER() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dblPurchaserate, dblBillamt, dblTaxamt, dblTotalamt, dblTotal As Double
        Dim dblGrandPackamount, dblGrandRoundoff, dblDayPackamount, dblDayRoundoff As Double
        Dim dblDayPurchaserate, dblDayBillamt, dblDayTaxamt, dblDayTotalamt, dblDayTotal As Double
        Dim dblGrandPurchaserate, dblGrandBillamt, dblGrandTaxamt, dblGrandTotalamt, dblGrandTotal As Double
        Dim POSDESC, SSQL As String
        Dim BILLDATE As Date
        Dim Billdatebool As Boolean
        Dim I, J As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            Call PrintHeader(PAGEHEADER, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "DAYWISESALEREGISTER")
            If gdataset.Tables("DAYWISESALEREGISTER").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                For Each dr In gdataset.Tables("DAYWISESALEREGISTER").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(135, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEADER, FROMDATE, TODATE)
                    End If
                    If Format(DateValue(BILLDATE), "dd/MM/yyyy") <> Format(CDate(dr("BILLDATE")), "dd/MM/yyyy") Then
                        If Billdatebool = True Then
                            Filewrite.WriteLine(StrDup(135, "."))
                            pagesize = pagesize + 1
                            Filewrite.Write("{0,-16}{1,-20}{2,13}", "", "DAY TOTAL =====>", Mid(Format(Val(dblDayPurchaserate), "0.00"), 1, 13))
                            'Filewrite.Write("{0,13}{1,13}{2,13}", Mid(Format(Val(dblDayTaxamt), "0.00"), 1, 13), Mid(Format(Val(dblDayTotal), "0.00"), 1, 13), Mid(Format(Val(dblDayPackamount), "0.00"), 1, 13))
                            Filewrite.Write("{0,13}{1,13}{2,13}", Mid(Format(Val(dblDayTaxamt), "0.00"), 1, 13), Mid(Format(Val(dblDayTotal), "0.00"), 1, 13), "")
                            'Filewrite.WriteLine("{0,2}{1,13}{2,13}", "", Mid(dblDayRoundoff, 1, 12), Mid(Format(Math.Round(Val(dblDayTotalamt)), "0.00"), 1, 13))
                            Filewrite.WriteLine("{0,2}{1,13}{2,13}", "", "", Mid(Format(Val(dblDayTotalamt), "0.00"), 1, 13))
                            pagesize = pagesize + 1
                            Filewrite.WriteLine(StrDup(135, "."))
                            pagesize = pagesize + 1
                            Filewrite.WriteLine("{0,-16}", Mid(Format(dr("BILLDATE"), "dd/MM/yyyy"), 1, 15))
                            pagesize = pagesize + 1
                            BILLDATE = CDate(dr("BILLDATE"))
                            dblDayPurchaserate = 0 : dblDayTaxamt = 0 : dblDayTotalamt = 0 : dblDayTotal = 0
                            dblDayPackamount = 0 : dblDayRoundoff = 0
                            POSDESC = ""
                        Else
                            Filewrite.WriteLine("{0,-16}", Mid(Format(dr("BILLDATE"), "dd/MM/yyyy"), 1, 15))
                            pagesize = pagesize + 1
                            BILLDATE = CDate(dr("BILLDATE"))
                            Billdatebool = True
                        End If
                    End If
                    If POSDESC <> Trim(CStr(dr("POSDESC"))) Then
                        Filewrite.Write("{0,-16}{1,-20}", "", Mid(CStr(dr("POSDESC")), 1, 20))
                        SSQL = "SELECT SUM(PURCHASERATE) AS PURCHASERATE,SUM(BILLAMOUNT) AS BILLAMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT,"
                        SSQL = SSQL & " SUM(PACKAMOUNT) AS PACKAMOUNT,SUM(ROUNDOFF) AS ROUNDOFF,0 AS DISCOUNT,SUM(TOTALAMOUNT) AS TOTALAMOUNT FROM VIEWSALEREGISTERDAYWISE "
                        SSQL = SSQL & " WHERE POSDESC = '" & Trim(CStr(dr("POSDESC"))) & "' AND ISNULL(DELFLAG,'') <> 'Y'  AND CAST(CONVERT(VARCHAR(11),BILLDATE,6) AS DATETIME) ="
                        SSQL = SSQL & " '" & Format(BILLDATE, "yyyy-MM-dd") & "'  GROUP BY POSDESC ORDER BY POSDESC"
                        gconnection.getDataSet(SSQL, "VIEWSALEREGISTERDAYWISE")
                        If gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows.Count > 0 Then
                            Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PURCHASERATE")), "0.00"), 1, 12))
                            dblDayPurchaserate = dblDayPurchaserate + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PURCHASERATE")), "0.00")
                            dblGrandPurchaserate = dblGrandPurchaserate + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PURCHASERATE")), "0.00")
                            Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TAXAMOUNT")), "0.00"), 1, 12))
                            dblDayTaxamt = dblDayTaxamt + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TAXAMOUNT")), "0.00")
                            dblGrandTaxamt = dblGrandTaxamt + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TAXAMOUNT")), "0.00")
                            ''-----------------
                            '''''Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("BILLAMOUNT")), "0.00"), 1, 12))
                            '''''dblDayTotalamt = dblDayTotalamt + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("BILLAMOUNT")), "0.00")
                            '''''dblGrandTotalamt = dblGrandTotalamt + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("BILLAMOUNT")), "0.00")
                            Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TOTALAMOUNT")), "0.00"), 1, 12))
                            dblDayTotal = dblDayTotal + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TOTALAMOUNT")), "0.00")
                            dblGrandTotal = dblGrandTotal + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TOTALAMOUNT")), "0.00")
                            ''-----------------
                            'Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PACKAMOUNT")), "0.00"), 1, 12))
                            Filewrite.Write("{0,2}", "")
                            dblDayPackamount = dblDayPackamount + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PACKAMOUNT")), "0.00")
                            dblGrandPackamount = dblGrandPackamount + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("PACKAMOUNT")), "0.00")
                            ''-----------------
                            'Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("DISCOUNT"))) & "%", 1, 12))
                            Filewrite.Write("{0,13}", "")
                            ''-----------------
                            ''Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("ROUNDOFF")), "0.00"), 1, 12))
                            Filewrite.Write("{0,13}", "")
                            'Filewrite.Write("{0,5}", "")

                            dblDayRoundoff = dblDayRoundoff + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("ROUNDOFF")), "0.00")
                            dblGrandRoundoff = dblGrandRoundoff + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("ROUNDOFF")), "0.00")
                            ''-----------------
                            ''''Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TOTALAMOUNT")), "0.00"), 1, 12))
                            ''''dblDayTotal = dblDayTotal + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TOTALAMOUNT")), "0.00")
                            ''''dblGrandTotal = dblGrandTotal + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("TOTALAMOUNT")), "0.00")
                            Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("BILLAMOUNT")), "0.00"), 1, 12))
                            dblDayTotalamt = dblDayTotalamt + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("BILLAMOUNT")), "0.00")
                            dblGrandTotalamt = dblGrandTotalamt + Format(Val(gdataset.Tables("VIEWSALEREGISTERDAYWISE").Rows(0).Item("BILLAMOUNT")), "0.00")
                            Filewrite.WriteLine()
                            pagesize = pagesize + 1
                        End If
                        I = I + 1
                        POSDESC = Trim(CStr(dr("POSDESC")))
                    End If
                Next dr
                Filewrite.WriteLine(StrDup(135, "."))
                pagesize = pagesize + 1
                Filewrite.Write("{0,-16}{1,-20}{2,13}", "", "DAY TOTAL =====>", Mid(Format(Val(dblDayPurchaserate), "0.00"), 1, 13))
                'Filewrite.Write("{0,13}{1,13}{2,13}", Mid(Format(Val(dblDayTaxamt), "0.00"), 1, 13), Mid(Format(Val(dblDayTotal), "0.00"), 1, 13), Mid(Format(Val(dblDayPackamount), "0.00"), 1, 13))
                Filewrite.Write("{0,13}{1,13}{2,2}", Mid(Format(Val(dblDayTaxamt), "0.00"), 1, 13), Mid(Format(Val(dblDayTotal), "0.00"), 1, 13), "")
                'Filewrite.WriteLine("{0,13}{1,13}{2,13}", "", Mid(dblDayRoundoff, 1, 12), Mid(Format(Math.Round(Val(dblDayTotalamt)), "0.00"), 1, 13))

                Filewrite.WriteLine("{0,13}{1,13}{2,13}", "", "", Mid(Format(Val(dblDayTotalamt), "0.00"), 1, 13))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "."))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "="))
                pagesize = pagesize + 1
                Filewrite.Write("{0,-16}{1,-20}", " ", "GRAND TOTAL ===>")
                Filewrite.Write("{0,13}", Format(Val(dblGrandPurchaserate), "0.00"))
                Filewrite.Write("{0,13}", Format(Val(dblGrandTaxamt), "0.00"))
                'Filewrite.Write("{0,13}", Format(Val(dblGrandTotalamt), "0.00"))
                Filewrite.Write("{0,13}", Format(Val(dblGrandTotal), "0.00"))
                'Filewrite.Write("{0,13}{1,13}", Format(Val(dblGrandPackamount), "0.00"), "")
                Filewrite.Write("{0,13}{1,2}", "", "")
                Filewrite.Write("{0,13}", "") 'Format(Val(dblGrandRoundoff), "0.00"))
                'Filewrite.Write("{0,5}", "")
                'Filewrite.Write("{0,13}", Format(Val(dblGrandTotal), "0.00"))
                Filewrite.Write("{0,13}", Format(Val(dblGrandTotalamt), "0.00"))
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "="))
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
    Private Function PrintHeader(ByVal HEADING() As String, ByVal MSKFROMDATE As Date, ByVal MSKTODATE As Date)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(HEADING(0)), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialYearEnd)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(HEADING(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "SUMMARY")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(MSKFROMDATE, "MMM dd,yyyy") & " " & "To" & " " & Format(MSKTODATE, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(135, "-"))
            pagesize = pagesize + 1
            Filewrite.Write("{0,-16}{1,-20}{2,13}{3,13}{4,13}", "BILL", "COST", "PURCHASE", PrintTaxheading1, "BASIC")
            'Filewrite.WriteLine("{0,13}{1,2}{2,13}{3,13}", "", "", "ROUNDOFF", "BILL")
            Filewrite.WriteLine("{0,13}{1,2}{2,13}{3,13}", "", "", "", "BILL")
            pagesize = pagesize + 1
            Filewrite.Write("{0,-16}{1,-20}{2,13}{3,13}{4,13}", "DATE", "CENTRE", "AMOUNT", PrintTaxheading2, "AMOUNT")
            'Filewrite.WriteLine("{0,13}{1,2}{2,13}{3,13}", "", "", "AMOUNT", "AMOUNT")
            Filewrite.WriteLine("{0,13}{1,2}{2,13}{3,13}", "", "", "", "AMOUNT")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(135, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
