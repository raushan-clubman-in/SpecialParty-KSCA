'Imports System
'Imports System.Collections.Generic.i
'Imports System.ComponentModel
''Imports System.Data
'Imports System.Drawing
Imports System.Linq
'Imports System.Text
''Imports System.Windows.Forms
'Imports System.Configuration
'Imports System.IO
'Option Explicit On
'Option Strict On
Imports x = Microsoft.Office.Interop.Excel


Public Class VIEWHDR
    Dim DETAIL As Boolean
    Dim VCONN As New GlobalClass
    Dim SSQL, KEYFIELD, FORMNAME As String
    Dim COLUMNSEQ As Integer
    Dim LD As Boolean
    Dim DataGridViewCheckBoxColumn As String

    Private Sub VIEWHDR_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            Call Cmd_Export_Click(Cmd_Export, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub VIEWHDR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Call Load()
        'AppPath = Application.StartupPath
        'Call GetServer()
        'DTGRDHDR.DataSource = Nothing
        'DTGRDHDR.Rows.Clear()
        'Dim STRQUERY As String
        'STRQUERY = "SELECT *  FROM menumaster"
        'VCONN.getDataSet(STRQUERY, "MENUMASTER")
        'If gdataset.Tables("MENUMASTER").Rows.Count > 0 Then
        '    For I = 0 To gdataset.Tables("MENUMASTER").Rows.Count - 1
        '        'DTGRDHDR.Rows.Add()
        '        DTGRDHDR.Rows(I).Cells(0).Value = gdataset.Tables("MENUMASTER").Rows(I).Item(0).ToString
        '        DTGRDHDR.Rows(I).Cells(1).Value = gdataset.Tables("MENUMASTER").Rows(I).Item(1).ToString
        '        DTGRDHDR.Rows(I).Cells(2).Value = gdataset.Tables("MENUMASTER").Rows(I).Item(2).ToString
        '        DTGRDHDR.Rows(I).Cells(3).Value = gdataset.Tables("MENUMASTER").Rows(I).Item(3).ToString
        '        DTGRDHDR.Rows(I).Cells(4).Value = gdataset.Tables("MENUMASTER").Rows(I).Item(4).ToString
        '        DTGRDHDR.Rows(I).Cells(5).Value = gdataset.Tables("MENUMASTER").Rows(I).Item(5).ToString

        '    Next

        'End If
    End Sub
    'Public Sub GetServer()
    '    Dim ServerConn As New OleDb.OleDbConnection
    '    Dim servercmd As New OleDb.OleDbDataAdapter
    '    Dim getserver As New DataSet
    '    Dim sql, ssql As String
    '    sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
    '    sql = sql & AppPath & "\DBS_KEY.MDB"
    '    ServerConn.ConnectionString = sql
    '    Try
    '        ServerConn.Open()
    '        'Mk Kannan
    '        'Begin
    '        'UserName and Password is Added on 06 Oct'07
    '        ssql = "SELECT SERVER, UserName, Password, Company_ID,DATABASE FROM DBSKEY"
    '        'End
    '        servercmd = New OleDb.OleDbDataAdapter(ssql, ServerConn)
    '        servercmd.Fill(getserver)
    '        If getserver.Tables(0).Rows.Count > 0 Then
    '            gserver = Trim(getserver.Tables(0).Rows(0).Item(0) & "")
    '            'Mk Kannan
    '            'Begin
    '            'UserName and Password is Added on 06 Oct'07
    '            strDataSqlUsr = Trim(getserver.Tables(0).Rows(0).Item(1) & "")
    '            strDataSqlPwd = Trim(getserver.Tables(0).Rows(0).Item(2) & "")

    '            'End
    '            'Mk Kannan
    '            'Begin
    '            'Company ID is Added on 10 Dec'07
    '            strCompany_ID = Trim(getserver.Tables(0).Rows(0).Item(3) & "")
    '            gDatabase = Trim(getserver.Tables(0).Rows(0).Item(4) & "")
    '            'End
    '        Else
    '            MessageBox.Show("Failed to connect to Data Source")
    '            Me.Close()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Failed to connect to data source")
    '        MsgBox(ex.Message)
    '    Finally
    '        ServerConn.Close()
    '    End Try
    'End Sub
    Public Sub LOADGRID(ByVal DC As DataTable, ByVal DET As Boolean, ByVal FORMNM As String, ByVal SQL As String, ByVal KEYFILD As String, ByVal COLUMSEQ As Integer)
        LD = False
        DETAIL = DET
        SSQL = SQL
        KEYFIELD = KEYFILD
        COLUMNSEQ = COLUMSEQ
        FORMNAME = FORMNM
        'DTGRDHDR.DataSource = DC
        Dim CHECKCOL As New DataGridViewCheckBoxColumn
        CHECKCOL.HeaderText = "SELECT"
        DTGRDHDR.Columns.Add(CHECKCOL)
        DTGRDHDR.DataSource = DC
        DTGRDHDR.EnableHeadersVisualStyles = False
        For i = 0 To DTGRDHDR.Columns.Count - 1
            DTGRDHDR.Columns(i).HeaderCell.Style.ForeColor = Color.Blue
            If i = 0 Then
            Else
                DTGRDHDR.Columns(i).ReadOnly = True
            End If
        Next
        'DTGRDHDR.ColumnHeadersDefaultCellStyle.BackColor = Color.Red
        'DTGRDHDR.RowHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue
        LD = False
    End Sub

    Private Sub DTGRDHDR_CellEnter(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DTGRDHDR_CellLeave(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DTGRDHDR_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DTGRDHDR.CellValueChanged
        If DTGRDHDR.CurrentCell.Value = True Then
            If DETAIL = True Then
                Dim DTLDET As New VIEWDET
                DTLDET.Show()
                Dim STRSQL As String
                Dim SSMS As String
                SSMS = DTGRDHDR.Rows(DTGRDHDR.CurrentCellAddress.Y).Cells(COLUMNSEQ).Value.ToString()
                STRSQL = SSQL & " WHERE " & KEYFIELD & " IN ('" & SSMS & "')"
                VCONN.getDataSet(STRSQL, "DETAILS")
                DTLDET.LOADDATA(gdataset.Tables("DETAILS"), False, "MENUMASTER", STRSQL, "SERIALNO", 1)
            End If
        End If
    End Sub

    Private Sub DTGRDHDR_ColumnStateChanged(sender As Object, e As DataGridViewColumnStateChangedEventArgs) Handles DTGRDHDR.ColumnStateChanged
        If LD = True Then
            If DETAIL = True Then
                Dim DTLDET As New VIEWDET
                DTLDET.Show()
                Dim STRSQL As String
                Dim SSMS As String
                SSMS = DTGRDHDR.Rows(DTGRDHDR.CurrentCellAddress.Y).Cells(COLUMNSEQ).Value.ToString()
                STRSQL = SSQL & " WHERE " & KEYFIELD & " IN ('" & SSMS & "')"
                VCONN.getDataSet(STRSQL, "DETAILS")
                DTLDET.LOADDATA(gdataset.Tables("DETAILS"), False, "MENUMASTER", STRSQL, "SERIALNO", 1)
            End If
        End If
    End Sub

    Private Sub DTGRDHDR_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DTGRDHDR_KeyDown(sender As Object, e As KeyEventArgs)
        Dim i, j As Integer
        If e.KeyCode = Keys.F4 Then
            j = DTGRDHDR.CurrentCellAddress.X
            For i = 0 To DTGRDHDR.RowCount - 1
                DTGRDHDR.Rows(i).Cells(j).Value = 1
            Next
        End If
        If e.KeyCode = Keys.F3 Then
            j = DTGRDHDR.CurrentCellAddress.X
            For i = 0 To DTGRDHDR.RowCount - 1
                DTGRDHDR.Rows(i).Cells(j).Value = 0
            Next
        End If
    End Sub

    Private Sub DTGRDHDR_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Friend Function Export(ByRef dgv As DataGridView, ByVal Path As String) As Boolean

        Dim xlWorkSheet As New x.Worksheet
        '; xlWorkSheet.SaveAs(Path, xlWorkSheet.xls, , )
        Dim misValue As Object = System.Reflection.Missing.Value
     


        Dim xlApp = New x.Application

        Dim xlWorkBook = xlApp.Workbooks.Add(misValue)

        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        Dim ColNames As Generic.List(Of String) = (From col As DataGridViewColumn _
                                           In dgv.Columns.Cast(Of DataGridViewColumn)() _
                                           Where (col.Visible = True) _
                                           Order By col.DisplayIndex _
                                           Select col.Name).ToList
        Dim s As String
        Dim colcount = 0
        For Each s In ColNames
            colcount += 1
            xlWorkSheet.Cells(1, colcount) = dgv.Columns.Item(s).HeaderText
        Next
        'get the values
        Dim rowcount As Integer
        For rowcount = 0 To dgv.Rows.Count - 1  'for each row
            colcount = 0
            For Each s In ColNames 'for each column
                colcount += 1
                xlWorkSheet.Cells(rowcount + 2, colcount) = dgv.Rows(rowcount).Cells(s).Value
                'xlWorkSheet.Cells(rowcount + 2, colcount) = dgv.Rows(rowcount).Cells(s).FormattedValue
            Next
        Next
        Return True
        System.Diagnostics.Process.Start(Path & "\BOOK1.xlsx")
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim dgData As DataGridView = DirectCast(DTGRDHDR, DataGridView)
        'With SaveExcelFileDialog
        '    .Filter = "Excel|*.xlsx"
        '    .Title = "Save griddata in Excel"
        '    If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '        'Dim o As New ExcelExporter
        '        Dim b = exportnew(dgData, .FileName)
        '        MsgBox("EXPORT COMPLETED SUCCESSFULY")
        '    End If
        '    .Dispose()
        'End With
        'Call ButtonExport()
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
                If IsDBNull(dgv.Rows(i).Cells(j).Value.ToString) = False Or dgv.Rows(i).Cells(j).Value.ToString() <> Nothing Then
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
    Private Sub ButtonExport()
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New x.Application
        Try
            Dim excelBook As x.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As x.Worksheet = CType(excelBook.Worksheets(1), x.Worksheet)
            xlApp.Visible = True
            rowsTotal = DTGRDHDR.RowCount - 1
            colsTotal = DTGRDHDR.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DTGRDHDR.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    'For j = 0 To colsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DTGRDHDR.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 10
                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MsgBox("Export Excel Error " & ex.Message)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub Cmd_Export_Click(sender As Object, e As EventArgs) Handles Cmd_Export.Click
        'Dim dgData As DataGridView = DirectCast(DTGRDHDR, DataGridView)
        'With SaveExcelFileDialog
        '    .Filter = "Excel|*.xlsx"
        '    .Title = "Save griddata in Excel"
        '    If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '        'Dim o As New ExcelExporter
        '        Dim b = exportnew(dgData, .FileName)
        '        MsgBox("EXPORT COMPLETED SUCCESSFULY")
        '    End If
        '    .Dispose()
        'End With
        Call ButtonExport()
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

End Class