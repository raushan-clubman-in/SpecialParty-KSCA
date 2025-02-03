Imports x = Microsoft.Office.Interop.Excel
Public Class AUTHORISATION
    Dim DETAIL As Boolean
    Dim VCONN As New GlobalClass
    Dim SSQL, KEYFIELD As String
    Dim frmt As Form
    Dim COLUMNSEQ, finallevel As Integer
    Dim LD As Boolean
    Dim DataGridViewCheckBoxColumn, strSqlString As String
    Dim ctrlname1 As Integer
    Dim gconnection As New GlobalClass
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dgData As DataGridView = DirectCast(DTAUTH, DataGridView)
        With SaveExcelFileDialog
            .Filter = "Excel|*.xlsx"
            .Title = "Save griddata in Excel"
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                'Dim o As New ExcelExporter
                Dim b = exportnew(dgData, .FileName)
                MsgBox("EXPORT COMPLETED SUCCESSFULY")
            End If
            .Dispose()
        End With
    End Sub
    Private Function exportnew(ByRef dgv As DataGridView, ByVal Path As String) As Boolean
        Dim i, j As Integer
        Dim default_location As String = Path & ".xls"
        'Creating dataset to export
        Dim dset As New DataSet
        'add table to dataset
        dset.Tables.Add()
        'add column to that table
        For i = 0 To dgv.ColumnCount - 1
            dset.Tables(0).Columns.Add(dgv.Columns(i).HeaderText)
        Next
        'add rows to the table
        Dim dr1 As DataRow
        For i = 0 To dgv.RowCount - 1
            dr1 = dset.Tables(0).NewRow
            For j = 0 To dgv.Columns.Count - 1
                dr1(j) = dgv.Rows(i).Cells(j).Value
            Next
            dset.Tables(0).Rows.Add(dr1)
        Next

        Dim xp As New x.Application
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        xp.Visible = True
        xp.UserControl = True

        wBook = xp.Workbooks.Add(System.Reflection.Missing.Value)
        wSheet = wBook.Sheets("sheet1")
        xp.Range("A50:I50").EntireColumn.AutoFit()
        With wBook
            .Sheets("Sheet1").Select()
            .Sheets(1).Name = "NameYourSheet"
        End With

        Dim dt As System.Data.DataTable = dset.Tables(0)
        wSheet.Cells(1).value = Path
        ' Dim i As Integer
        Dim s As String
        Dim colcount = 0
        Dim ColNames As Generic.List(Of String) = (From col As DataGridViewColumn _
                                           In dgv.Columns.Cast(Of DataGridViewColumn)() _
                                           Where (col.Visible = True) _
                                           Order By col.DisplayIndex _
                                           Select col.Name).ToList
        For Each s In ColNames
            colcount += 1
            wSheet.Cells(1, colcount) = dgv.Columns.Item(s).HeaderText
        Next
        For i = 0 To dgv.RowCount - 2
            For j = 0 To dgv.ColumnCount - 2
                If IsDBNull(dgv.Rows(i).Cells(j).Value) = False Or dgv.Rows(i).Cells(j).Value.ToString() <> Nothing Then
                    wSheet.Cells(i + 2, j + 1).value = dgv.Rows(i).Cells(j).Value.ToString()
                Else
                    wSheet.Cells(i + 2, j + 1).value = ""
                End If

            Next j
        Next i

        wSheet.Columns.AutoFit()
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(default_location)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(default_location) Then
            System.IO.File.Delete(default_location)
        End If

        wBook.SaveAs(default_location)
        xp.Workbooks.Open(default_location)
        xp.Visible = True
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim J As Integer
        Dim insert(0) As String
        J = DTAUTH.Columns.Count - 1
        For I = 0 To DTAUTH.Rows.Count - 1
            If DTAUTH.Rows(I).Cells(J).Value = True Then
                strSqlString = SSQL & " "
                If ctrlname1 = 1 Then
                    strSqlString = strSqlString & " AUTHORISE_USER1 ='" & gUsername & "',AUTHORISE_DATE1 =getdate() where " & KEYFIELD & " ='" & DTAUTH.Rows(I).Cells(COLUMNSEQ).Value.ToString() & "'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = strSqlString
                    If finallevel = ctrlname1 Then
                        strSqlString = SSQL & " AUTHORISED='Y' where " & KEYFIELD & " ='" & DTAUTH.Rows(I).Cells(COLUMNSEQ).Value.ToString() & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = strSqlString
                    End If

                End If
                If ctrlname1 = 2 Then
                    strSqlString = strSqlString & " AUTHORISE_USER2 ='" & gUsername & "',AUTHORISE_DATE2 =getdate() where " & KEYFIELD & " ='" & DTAUTH.Rows(I).Cells(COLUMNSEQ).Value.ToString() & "'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = strSqlString
                    If finallevel = ctrlname1 Then
                        strSqlString = SSQL & " AUTHORISED='Y' where " & KEYFIELD & " ='" & DTAUTH.Rows(I).Cells(COLUMNSEQ).Value.ToString() & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = strSqlString
                    End If

                End If
                If ctrlname1 = 3 Then
                    strSqlString = strSqlString & " AUTHORISE_USER3 ='" & gUsername & "',AUTHORISE_DATE3 =getdate() where " & KEYFIELD & " ='" & DTAUTH.Rows(I).Cells(COLUMNSEQ).Value.ToString() & "'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = strSqlString
                    If finallevel = ctrlname1 Then
                        strSqlString = SSQL & " AUTHORISED='Y' where " & KEYFIELD & " ='" & DTAUTH.Rows(I).Cells(COLUMNSEQ).Value.ToString() & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = strSqlString
                    End If
                End If
            End If
        Next
        gconnection.MoreTrans(insert)
    End Sub

    Private Sub AUTHORISATION_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub LOADGRID(ByVal DC As DataTable, ByVal DET As Boolean, ByVal FORMNM As Form, ByVal SQL As String, ByVal KEYFILD As String, ByVal auth As Integer, LEVEL As Integer, COLUMSEQ As Integer)
        LD = False
        DETAIL = DET
        SSQL = SQL
        KEYFIELD = KEYFILD
        COLUMNSEQ = COLUMSEQ
        frmt = FORMNM
        finallevel = auth
        ctrlname1 = LEVEL
        DTAUTH.DataSource = DC
        Dim CHECKCOL As New DataGridViewCheckBoxColumn
        CHECKCOL.HeaderText = "SELECT"
        DTAUTH.Columns.Add(CHECKCOL)
    End Sub

    Private Sub DTAUTH_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DTAUTH.CellContentClick

    End Sub
End Class