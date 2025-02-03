Imports System.Data.SqlClient
Imports System.IO
Public Class PendingKOTRegisterReport
    Dim pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Public Function Detailsection(ByVal Sqlstring As String, ByVal pageheading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim i As Integer
        Dim boolKOTdetails, boolServer, boolgrouptotal As Boolean
        Dim ServerName, KOTdetails, MemberCode, Rowprint, Todaydate As String
        Dim KOTAmount, GroupAmount, Grouptax, GrandAmount, Grandtax, BearerTotal, Bearertax, TotalAmount, Totaltax As Double
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            Call PrintHeader(pageheading, mskfromdate, msktodate)
            gconnection.getDataSet(Sqlstring, "PENDINGKOTREGISTER")
            If gdataset.Tables("PENDINGKOTREGISTER").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                For Each dr In gdataset.Tables("PENDINGKOTREGISTER").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(147, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(pageheading, mskfromdate, msktodate)
                    End If
                    If ServerName <> CStr(dr("SERVERNAME")) Then
                        If boolServer = True Then
                            ''''************************************** $  ITEM GROUP TOTAL $   **********************************''''
                            Filewrite.WriteLine(StrDup(147, "="))
                            pagesize = pagesize + 1
                            GrandAmount = GrandAmount + GroupAmount
                            Grandtax = Grandtax + Grouptax
                            BearerTotal = Format(Val(GroupAmount), "0.00")
                            Bearertax = Format(Val(Grouptax), "0.00")

                            GroupAmount = GroupAmount + Format(Val(dr("AMOUNT")), "0.00")
                            'Filewrite.WriteLine("{0,-82}{1,-40}{2,12}", "", "BEARER TOTAL :", Mid(Format(Val(BearerTotal), "0.00"), 1, 10))
                            Filewrite.WriteLine("{0,-82}{1,-28}{2,12}{3,12}{4,12}", "", "BEARER TOTAL :", Mid(Format(Val(Bearertax), "0.00"), 1, 10), Mid(Format(Val(BearerTotal), "0.00"), 1, 10), Mid(Format(Val(BearerTotal) + Val(Bearertax), "0.00"), 1, 10))

                            pagesize = pagesize + 1
                            Filewrite.WriteLine(StrDup(147, "="))
                            pagesize = pagesize + 1
                            GroupAmount = 0
                            Grouptax = 0
                            boolgrouptotal = True
                            ''''************************************** $ COMPLETE ITEM GROUP TOTAL $  **********************************''''
                        End If
                        Filewrite.WriteLine("{0,-25}{1,-10}", Mid(Trim(dr("SERVERNAME")), 1, 30), ":" & Mid(Trim(dr("SERVERCODE")), 1, 10))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine(StrDup(35, "="))
                        pagesize = pagesize + 1
                        ServerName = dr("SERVERNAME")
                        boolServer = True
                    End If
                    If MemberCode <> CStr(dr("MCODE")) Then
                        If Trim(UCase(dr("PAYMENTTYPE"))) = "ROOM" Then
                            Filewrite.Write("{0,-15}{1,-10}", "ROOM NO      :", Mid(Trim(dr("ROOMNO")), 1, 10))
                        ElseIf Trim(UCase(dr("PAYMENTTYPE"))) = "R.MEMBER" Then
                            Filewrite.Write("{0,-15}{1,-10}", "MEMBER CODE :", Mid(Trim(dr("PAYMENTTYPE")), 1, 10))
                        Else
                            Filewrite.Write("{0,-15}{1,-10}", "MEMBER CODE :", Mid(Trim(dr("MCODE")), 1, 10))
                        End If
                        Filewrite.Write("{0,-6}{1,-12}", "USER :", Mid(Trim(dr("ADDUSERID")), 1, 12))
                        Filewrite.WriteLine("{0,-6}{1,10}", "TIME :", Mid(Trim(Format(dr("ADDDATETIME"), "hh:mm:ss")), 1, 10))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine(StrDup(60, "="))
                        pagesize = pagesize + 1
                        MemberCode = dr("MCODE")
                    End If
                    If KOTdetails <> CStr(dr("KOTDETAILS")) Then
                        Filewrite.Write("{0,-20}{1,-20}", Mid(Trim(Format(dr("KOTDATE"), "dd/MM/yyyy")), 1, 20), Mid(Trim(dr("KOTDETAILS")), 1, 20))
                        KOTdetails = dr("KOTDETAILS")
                    Else
                        Filewrite.Write("{0,-20}{1,-20}", "", "")
                    End If
                    Filewrite.Write("{0,-15}{1,-25}", Mid(Trim(dr("ITEMCODE")), 1, 10), Mid(Trim(dr("ITEMDESC")), 1, 25))
                    Filewrite.Write("{0,-10}{1,-10}", Mid(Format(Val(dr("QTY")), "0"), 1, 5), Mid(Trim(dr("UOM")), 1, 10))
                    Filewrite.WriteLine("{0,10}{1,12}{2,12}{3,12}", Mid(Format(Val(dr("RATE")), "0.00"), 1, 10), Mid(Format(Val(dr("TAXAMOUNT")), "0.00"), 1, 10), Mid(Format(Val(dr("AMOUNT")), "0.00"), 1, 10), Mid(Format(Val(dr("AMOUNT")) + Val(dr("TAXAMOUNT")), "0.00"), 1, 10))
                    pagesize = pagesize + 1
                    KOTAmount = KOTAmount + Format(Val(dr("AMOUNT")), "0.00")
                    GroupAmount = GroupAmount + Format(Val(dr("AMOUNT")), "0.00")
                    Grouptax = Grouptax + Format(Val(dr("taxaMOUNT")), "0.00")
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                ''''************************************** $  ITEM GROUP TOTAL $   **********************************''''
                Filewrite.WriteLine(StrDup(147, "="))
                pagesize = pagesize + 1
                GrandAmount = GrandAmount + GroupAmount
                Grandtax = Grandtax + Grouptax
                BearerTotal = Format(Val(GroupAmount), "0.00")
                Bearertax = Format(Val(Grouptax), "0.00")

                GroupAmount = GroupAmount + Format(Val(dr("AMOUNT")), "0.00")
                Grouptax = Grouptax + Format(Val(dr("TAXAMOUNT")), "0.00")

                'Filewrite.WriteLine("{0,-82}{1,-40}{2,12}", "", "BEARER TOTAL :", Mid(Format(Val(BearerTotal), "0.00"), 1, 10))
                Filewrite.WriteLine("{0,-82}{1,-28}{2,12}{3,12}{4,12}", "", "BEARER TOTAL :", Mid(Format(Val(Bearertax), "0.00"), 1, 10), Mid(Format(Val(BearerTotal), "0.00"), 1, 10), Mid(Format(Val(BearerTotal) + Val(Bearertax), "0.00"), 1, 10))

                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(147, "="))
                pagesize = pagesize + 1
                GroupAmount = 0
                boolgrouptotal = True
                ''''************************************** $ COMPLETE ITEM GROUP TOTAL $  **********************************''''
                ''''******************************************** $  GRAND TOTAL $   ****************************************''''
                Filewrite.WriteLine(StrDup(147, "="))
                pagesize = pagesize + 1
                TotalAmount = Format(Val(GrandAmount), "0.00")
                Totaltax = Format(Val(Grandtax), "0.00")
                'Filewrite.WriteLine("{0,-82}{1,-40}{2,12}", "", "TOTAL AMOUNT :", Mid(Format(Val(TotalAmount), "0.00"), 1, 10))
                Filewrite.WriteLine("{0,-82}{1,-28}{2,12}{3,12}{4,12}", "", "TOTAL AMOUNT :", Mid(Format(Val(Totaltax), "0.00"), 1, 8), Mid(Format(Val(TotalAmount), "0.00"), 1, 10), Mid(Format(Val(TotalAmount) + Val(Totaltax), "0.00"), 1, 10))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(147, "="))
                pagesize = pagesize + 1
                ''''************************************** $  COMPLETE GRAND TOTAL $   **************************************''''
            Else
                'MessageBox.Show("NO RECORD TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                'Exit Function
                Filewrite.WriteLine()
                Filewrite.WriteLine()
                Filewrite.WriteLine(Chr(14) & Chr(15) & "No pending KOT for today")
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

    Private Function PrintHeader(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.Write(Chr(15))
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
            'If flag = 1 Then
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "DETAILS")
            'Else
            '   Filewrite.WriteLine("{0,64}{1,-10}", " ", "SUMMARY")
            'End If
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(147, "-"))
            pagesize = pagesize + 1
            Filewrite.Write("{0,-20}{1,-20}{2,-15}{3,-25}{4,-10}", "SERVER/", "BILL", "ITEM", "ITEM", "QTY")
            Filewrite.WriteLine("{0,-10}{1,10}{2,12}{3,12}{4,12}", "UOM", "RATE", PrintTaxheading1, "AMOUNT", "NETAMOUNT")
            pagesize = pagesize + 1
            Filewrite.Write("{0,-20}{1,-20}{2,-15}{3,-25}{4,-10}", "BILL DATE", "NUMBER", "CODE", "DESCRIPTION", "")
            Filewrite.WriteLine("{0,-10}{1,10}{2,12}{3,12}{3,12}", "", "", PrintTaxheading2, "", "")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(147, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
