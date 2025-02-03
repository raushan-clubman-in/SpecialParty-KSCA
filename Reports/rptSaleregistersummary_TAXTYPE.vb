Imports System.Data.SqlClient
Imports System.IO
Public Class rptSaleregistersummary_TAXTYPE
    Dim pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Public Function Detailsection(ByVal SQLSTRING As String, ByVal pageheading() As String, ByVal HNAME As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim i As Integer = 1
        Dim j As Integer
        Dim boolitem, boolgrouptotal As Boolean
        Dim SSQL, Itemdesc, Itemcode, Uom As String
        Dim GrandQty, TotalAmount, TotalQty, TotalRate, GrandAmount, ItemAmount, TaxAmount As Double
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            Call PrintHeader(HNAME, mskfromdate, msktodate)
            gconnection.getDataSet(SQLSTRING, "SALEREGISTERSUMMARY")
            If gdataset.Tables("SALEREGISTERSUMMARY").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                GrandAmount = 0 : ItemAmount = 0 : TaxAmount = 0
                For Each dr In gdataset.Tables("SALEREGISTERSUMMARY").Rows
                    If pagesize >= 58 Then
                        Filewrite.Write(StrDup(88, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(HNAME, mskfromdate, msktodate)
                    End If
                    'If Itemcode <> Trim(CStr(dr("ITEMCODE"))) And Uom <> Trim(CStr(dr("UOM"))) Then
                    Filewrite.Write("{0,-7}{1,-10}", Mid(Format(Val(i), "0") & ".", 1, 7), Mid(Trim(dr("ITEMCODE")), 1, 10))
                    Filewrite.Write("{0,-27}", Mid(Trim(dr("ITEMDESC")), 1, 27))
                    Filewrite.Write("{0,10}", Mid(Format(Val(dr("QTY")), "0.00"), 1, 10))
                    Filewrite.Write("{0,10}", Mid(Format(Val(dr("AMOUNT")), "0.00"), 1, 10))
                    Filewrite.Write("{0,10}", Mid(Format(Val(dr("TAXAMOUNT")), "0.00"), 1, 10))
                    Filewrite.WriteLine("{0,13}", Mid(Format(Val(dr("BILLAMOUNT")), "0.00"), 1, 13))
                    pagesize = pagesize + 1
                    GrandAmount = Val(GrandAmount) + Val(dr("BILLAMOUNT"))
                    ItemAmount = Val(ItemAmount) + Val(dr("AMOUNT"))
                    TaxAmount = Val(TaxAmount) + Val(dr("TAXAMOUNT"))
                    i = i + 1
                    Itemcode = dr("ITEMCODE")
                    'Uom = dr("UOM")
                    TotalAmount = 0 : TotalQty = 0 : TotalRate = 0
                    'End If
                Next
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                '''******************************************** $  GRAND TOTAL $   ****************************************''''
                Filewrite.WriteLine(StrDup(88, "="))
                pagesize = pagesize + 1
                Filewrite.Write("{0,-17}{1,-27}", "", "GRAND TOTAL =====>")
                Filewrite.Write("{0,10}", "")
                Filewrite.Write("{0,10}", Mid(Format(Val(ItemAmount), "0.00"), 1, 10))
                Filewrite.Write("{0,10}", Mid(Format(Val(TaxAmount), "0.00"), 1, 10))
                Filewrite.WriteLine("{0,13}", Mid(Format(Val(GrandAmount), "0.00"), 1, 13))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(88, "="))
                pagesize = pagesize + 1
                '''************************************** $  COMPLETE GRAND TOTAL $   **************************************''''
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
    Private Function PrintHeader(ByVal HNAME As String, ByVal MSKFROMDATE As Date, ByVal MSKTODATE As Date)
        Dim I As Integer
        pagesize = 0
        Try
            '''*********************************************** PRINT REPORTS HEADING  *********************************'''
            Filewrite.Write(Chr(15))
            'Filewrite.WriteLine("{0,Len(Trim(HNAME))}{1,20}{2,30}{3,25}", "", Mid(HNAME, 1, Len(Trim(HNAME))), " ", "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
            Filewrite.Write("{0," & Len(Trim(HNAME)) & "}", Mid(HNAME, 1, Len(Trim(HNAME))))
            Filewrite.WriteLine("{0,20}{1,30}{2,25}", "", " ", "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(HNAME), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialYearEnd)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(HNAME)), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,65}{1,-20}", " ", "SUMMARY")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.Write("{0,-30}{1,87}{2,16}", Format(MSKFROMDATE, "MMM dd,yyyy") & " " & "To" & " " & Format(MSKTODATE, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(88, "="))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-7}{1,-10}{2,-27}{3,10}{4,10}{5,10}{6,13}", "SLNO.", "ITEM CODE", "ITEM DESCRIPTION", "QUANTITY", "AMOUNT", "TAXAMOUNT", "TOTALAMOUNT")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(88, "="))
            pagesize = pagesize + 1
            '''*********************************************** COMPLETE PRINT REPORTS HEADING  *********************************'''
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
