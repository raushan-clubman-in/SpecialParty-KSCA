Imports System.Data.SqlClient
Public Class LIST_OPERATION1
    Dim gconnection As New GlobalClass
    Dim vConn As New GlobalClass
    Dim i As Integer, vIndex As Long
    Public Table As String
    Public LABDUE As String
    Public keyfield As String
    Public keyfield1 As String
    Public keyfield2 As String
    Public keyfield3 As String
    Public keyfield4 As String
    Public keyfield5 As String
    Public keyfield6 As String
    Public keyfield7 As String
    Public keyfield8 As String
    Public keyfield9 As String
    Public keyfield10 As String
    Public keyfield11 As String
    Public keyfield12 As String
    Public keyfield13 As String
    Public keyfield14 As String
    Public keyfield15 As String
    Public vCaption As String
    Public Field As String
    Dim Fields() As String
    Dim ssql As String
    Dim listop As String
    Dim vLastString As String
    Dim Loopindex As Long
    Dim vCode As String
    Dim FormUnload As Boolean
    Dim vSelect As String
    Public vSamleCol As String
    Dim vColValue As String
    Dim Frmcalled As String

    Private Sub LIST_OPERATION1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'If FormUnload = True Then
        '    Me.Close()
        '    gSQLString = ""
        '    vCaption = ""
        '    M_Groupby = ""
        '    M_ORDERBY = ""
        '    M_WhereCondition = ""
        '    LABDUE = ""
        'End If
    End Sub

    Private Sub LIST_OPERATION1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose(True)
        End If

    End Sub

    Private Sub LIST_OPERATION1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Dispose(True)
        End If
    End Sub

    Private Sub LIST_OPERATION1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "ZOOM [ " & MyCompanyName & " ]"
        FormUnload = True
        vSelect = Field
        Fields = Split(Field, ",")
        For i = 0 To UBound(Fields)
            'CMB_ORDERBY.Items.Add(Trim(Fields(i)))
            'CMB_SRC_FIELDS.Items.Add(Trim(Fields(i)))
        Next i
        If Field <> "" Then
            'CMB_ORDERBY.Text = Trim(Fields(0) & "")
            'CMB_SRC_FIELDS.Text = Trim(Fields(0) & "")
        End If
        LBL_HEADING.Text = vCaption
        'If Len(Search) > 0 Then
        '    Me.TXT_SEARCH_TXT.Text = Search
        '    Search = ""
        'End Ifm
        'DataGridView1.AutoResizeColumns()
        Me.Show()
        Me.TXT_SEARCH_TXT.Focus()

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count > 0 Then
            If DataGridView1.ColumnCount = 2 Then
                keyfield = DataGridView1.Rows(e.RowIndex).Cells(0).Value().ToString()
                keyfield1 = DataGridView1.Rows(e.RowIndex).Cells(1).Value().ToString()
            ElseIf DataGridView1.ColumnCount = 1 Then
                keyfield = DataGridView1.Rows(e.RowIndex).Cells(0).Value().ToString()
            ElseIf DataGridView1.ColumnCount = 3 Then
                keyfield = DataGridView1.Rows(e.RowIndex).Cells(0).Value().ToString()
                keyfield1 = DataGridView1.Rows(e.RowIndex).Cells(1).Value().ToString()
                keyfield2 = DataGridView1.Rows(e.RowIndex).Cells(2).Value().ToString()
            ElseIf DataGridView1.ColumnCount = 4 Then
                keyfield = DataGridView1.Rows(e.RowIndex).Cells(0).Value().ToString()
                keyfield1 = DataGridView1.Rows(e.RowIndex).Cells(1).Value().ToString()
                keyfield2 = DataGridView1.Rows(e.RowIndex).Cells(2).Value().ToString()
                keyfield3 = DataGridView1.Rows(e.RowIndex).Cells(3).Value().ToString()
            ElseIf DataGridView1.ColumnCount = 5 Then
                keyfield = DataGridView1.Rows(e.RowIndex).Cells(0).Value().ToString()
                keyfield1 = DataGridView1.Rows(e.RowIndex).Cells(1).Value().ToString()
                keyfield2 = DataGridView1.Rows(e.RowIndex).Cells(2).Value().ToString()
                keyfield3 = DataGridView1.Rows(e.RowIndex).Cells(3).Value().ToString()
                keyfield4 = DataGridView1.Rows(e.RowIndex).Cells(4).Value().ToString()
            ElseIf DataGridView1.ColumnCount = 6 Then
                keyfield = DataGridView1.Rows(e.RowIndex).Cells(0).Value().ToString()
                keyfield1 = DataGridView1.Rows(e.RowIndex).Cells(1).Value().ToString()
                keyfield2 = DataGridView1.Rows(e.RowIndex).Cells(2).Value().ToString()
                keyfield3 = DataGridView1.Rows(e.RowIndex).Cells(3).Value().ToString()
                keyfield4 = DataGridView1.Rows(e.RowIndex).Cells(4).Value().ToString()
                keyfield5 = DataGridView1.Rows(e.RowIndex).Cells(5).Value().ToString()
            ElseIf DataGridView1.ColumnCount = 9 Then
                keyfield = DataGridView1.Rows(e.RowIndex).Cells(0).Value().ToString()
                keyfield1 = DataGridView1.Rows(e.RowIndex).Cells(1).Value().ToString()
                keyfield2 = DataGridView1.Rows(e.RowIndex).Cells(2).Value().ToString()
                keyfield3 = DataGridView1.Rows(e.RowIndex).Cells(3).Value().ToString()
                keyfield4 = DataGridView1.Rows(e.RowIndex).Cells(4).Value().ToString()
                keyfield5 = DataGridView1.Rows(e.RowIndex).Cells(5).Value().ToString()
                keyfield6 = DataGridView1.Rows(e.RowIndex).Cells(6).Value().ToString()
                keyfield7 = DataGridView1.Rows(e.RowIndex).Cells(7).Value().ToString()
                keyfield8 = DataGridView1.Rows(e.RowIndex).Cells(8).Value().ToString()
            ElseIf DataGridView1.ColumnCount = 10 Then
                keyfield = DataGridView1.Rows(e.RowIndex).Cells(0).Value().ToString()
                keyfield1 = DataGridView1.Rows(e.RowIndex).Cells(1).Value().ToString()
                keyfield2 = DataGridView1.Rows(e.RowIndex).Cells(2).Value().ToString()
                keyfield3 = DataGridView1.Rows(e.RowIndex).Cells(3).Value().ToString()
                keyfield4 = DataGridView1.Rows(e.RowIndex).Cells(4).Value().ToString()
                keyfield5 = DataGridView1.Rows(e.RowIndex).Cells(5).Value().ToString()
                keyfield6 = DataGridView1.Rows(e.RowIndex).Cells(6).Value().ToString()
                keyfield7 = DataGridView1.Rows(e.RowIndex).Cells(7).Value().ToString()
                keyfield8 = DataGridView1.Rows(e.RowIndex).Cells(8).Value().ToString()
                keyfield9 = DataGridView1.Rows(e.RowIndex).Cells(9).Value().ToString()
            ElseIf DataGridView1.ColumnCount = 11 Then
                keyfield = DataGridView1.Rows(e.RowIndex).Cells(0).Value().ToString()
                keyfield1 = DataGridView1.Rows(e.RowIndex).Cells(1).Value().ToString()
                keyfield2 = DataGridView1.Rows(e.RowIndex).Cells(2).Value().ToString()
                keyfield3 = DataGridView1.Rows(e.RowIndex).Cells(3).Value().ToString()
                keyfield4 = DataGridView1.Rows(e.RowIndex).Cells(4).Value().ToString()
                keyfield5 = DataGridView1.Rows(e.RowIndex).Cells(5).Value().ToString()
                keyfield6 = DataGridView1.Rows(e.RowIndex).Cells(6).Value().ToString()
                keyfield7 = DataGridView1.Rows(e.RowIndex).Cells(7).Value().ToString()
                keyfield8 = DataGridView1.Rows(e.RowIndex).Cells(8).Value().ToString()
                keyfield9 = DataGridView1.Rows(e.RowIndex).Cells(9).Value().ToString()
                keyfield10 = DataGridView1.Rows(e.RowIndex).Cells(10).Value().ToString()
            End If

            Me.Hide()
        End If
    End Sub

    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        If DataGridView1.Rows.Count > 0 Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                Dim row As Integer = (DataGridView1.CurrentRow.Index) - 1
                If DataGridView1.ColumnCount = 2 Then
                    keyfield = DataGridView1.Rows(row).Cells(0).Value.ToString()
                    keyfield1 = DataGridView1.Rows(row).Cells(1).Value.ToString()
                    'keyfield2 = DataGridView1.Rows(row).Cells(2).Value.ToString()
                    'keyfield3 = DataGridView1.Rows(row).Cells(3).Value.ToString()
                ElseIf DataGridView1.ColumnCount = 1 Then
                    keyfield = DataGridView1.Rows(row).Cells(0).Value.ToString()
                ElseIf DataGridView1.ColumnCount = 3 Then
                    keyfield = DataGridView1.Rows(row).Cells(0).Value.ToString()
                    keyfield1 = DataGridView1.Rows(row).Cells(1).Value.ToString()
                    keyfield2 = DataGridView1.Rows(row).Cells(2).Value.ToString()
                ElseIf DataGridView1.ColumnCount = 4 Then
                    keyfield = DataGridView1.Rows(row).Cells(0).Value.ToString()
                    keyfield1 = DataGridView1.Rows(row).Cells(1).Value.ToString()
                    keyfield2 = DataGridView1.Rows(row).Cells(2).Value.ToString()
                    keyfield3 = DataGridView1.Rows(row).Cells(3).Value.ToString()
                ElseIf DataGridView1.ColumnCount = 5 Then
                    keyfield = DataGridView1.Rows(row).Cells(0).Value.ToString()
                    keyfield1 = DataGridView1.Rows(row).Cells(1).Value.ToString()
                    keyfield2 = DataGridView1.Rows(row).Cells(2).Value.ToString()
                    keyfield3 = DataGridView1.Rows(row).Cells(3).Value.ToString()
                    keyfield4 = DataGridView1.Rows(row).Cells(4).Value.ToString()
                ElseIf DataGridView1.ColumnCount = 6 Then
                    keyfield = DataGridView1.Rows(row).Cells(0).Value.ToString()
                    keyfield1 = DataGridView1.Rows(row).Cells(1).Value.ToString()
                    keyfield2 = DataGridView1.Rows(row).Cells(2).Value.ToString()
                    keyfield3 = DataGridView1.Rows(row).Cells(3).Value.ToString()
                    keyfield4 = DataGridView1.Rows(row).Cells(4).Value.ToString()
                    keyfield5 = DataGridView1.Rows(row).Cells(5).Value.ToString()
                ElseIf DataGridView1.ColumnCount = 9 Then
                    keyfield = DataGridView1.Rows(row).Cells(0).Value.ToString()
                    keyfield1 = DataGridView1.Rows(row).Cells(1).Value.ToString()
                    keyfield2 = DataGridView1.Rows(row).Cells(2).Value.ToString()
                    keyfield3 = DataGridView1.Rows(row).Cells(3).Value.ToString()
                    keyfield4 = DataGridView1.Rows(row).Cells(4).Value.ToString()
                    keyfield5 = DataGridView1.Rows(row).Cells(5).Value.ToString()
                    keyfield6 = DataGridView1.Rows(row).Cells(6).Value.ToString()
                    keyfield7 = DataGridView1.Rows(row).Cells(7).Value.ToString()
                    keyfield8 = DataGridView1.Rows(row).Cells(8).Value.ToString()
                ElseIf DataGridView1.ColumnCount = 10 Then
                    keyfield = DataGridView1.Rows(row).Cells(0).Value.ToString()
                    keyfield1 = DataGridView1.Rows(row).Cells(1).Value.ToString()
                    keyfield2 = DataGridView1.Rows(row).Cells(2).Value.ToString()
                    keyfield3 = DataGridView1.Rows(row).Cells(3).Value.ToString()
                    keyfield4 = DataGridView1.Rows(row).Cells(4).Value.ToString()
                    keyfield5 = DataGridView1.Rows(row).Cells(5).Value.ToString()
                    keyfield6 = DataGridView1.Rows(row).Cells(6).Value.ToString()
                    keyfield7 = DataGridView1.Rows(row).Cells(7).Value.ToString()
                    keyfield8 = DataGridView1.Rows(row).Cells(8).Value.ToString()
                    keyfield9 = DataGridView1.Rows(row).Cells(9).Value.ToString()
                ElseIf DataGridView1.ColumnCount = 11 Then
                    keyfield = DataGridView1.Rows(row).Cells(0).Value.ToString()
                    keyfield1 = DataGridView1.Rows(row).Cells(1).Value.ToString()
                    keyfield2 = DataGridView1.Rows(row).Cells(2).Value.ToString()
                    keyfield3 = DataGridView1.Rows(row).Cells(3).Value.ToString()
                    keyfield4 = DataGridView1.Rows(row).Cells(4).Value.ToString()
                    keyfield5 = DataGridView1.Rows(row).Cells(5).Value.ToString()
                    keyfield6 = DataGridView1.Rows(row).Cells(6).Value.ToString()
                    keyfield7 = DataGridView1.Rows(row).Cells(7).Value.ToString()
                    keyfield8 = DataGridView1.Rows(row).Cells(8).Value.ToString()
                    keyfield9 = DataGridView1.Rows(row).Cells(9).Value.ToString()
                    keyfield10 = DataGridView1.Rows(row).Cells(10).Value.ToString()
                End If
                Me.Hide()
            End If
        End If

    End Sub

    Private Sub TXT_SEARCH_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_SEARCH_TXT.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If TXT_SEARCH_TXT.Text = "" Then
                Call TXT_SEARCH_TXT_TextChanged(TXT_SEARCH_TXT, e)
            End If
            Microsoft.VisualBasic.ChrW(0)
            DataGridView1.Focus()
        End If
    End Sub

    Private Sub TXT_SEARCH_TXT_TextChanged(sender As Object, e As EventArgs) Handles TXT_SEARCH_TXT.TextChanged

        Dim vLen As Integer
        Dim myconn As SqlConnection
        ssql = ""
        ssql = gSQLString & IIf(Trim(M_WhereCondition) = "", " Where ", M_WhereCondition & " And ")
        Try

            If listop = "" Then
                listop = "%'"
            End If

            'If CMB_SRC_FIELDS.Text <> "" Then
            '    vLen = Len(Trim(TXT_SEARCH_TXT.Text))
            '    ssql = ssql & Trim(CMB_SRC_FIELDS.Text & "") & " LIKE '" & Trim(TXT_SEARCH_TXT.Text) & listop
            'ElseIf CMB_SRC_FIELDS.Text <> "" Then
            '    MsgBox("Select the SearchField Column as it is mandatory ...", MsgBoxStyle.Information)
            '    CMB_SRC_FIELDS.Focus()
            '    Exit Sub
            'End If
            'If CMB_SRC_FIELDS.Text <> "" Then
            '    vLen = Len(Trim(TXT_SEARCH_TXT.Text))
            '    ssql = ssql & Trim(CMB_SRC_FIELDS.Text & "") & " LIKE '" & Trim(TXT_SEARCH_TXT.Text) & "%'"
            '    'ElseIf CbxColumn.Text <> "" Then
            '    '    MsgBox("Select the SearchField Column as it is mandatory ...", MsgBoxStyle.Information)
            '    '    CbxColumn.Focus()
            '    '    Exit Sub
            'End If
            If UBound(Fields) >= 0 Then
                For i = 0 To UBound(Fields)
                    'CbxColumn.Items.Add(Trim(Fields(i)))
                    'CbxOrderby.Items.Add(Trim(Fields(i)))
                    If Mid(gCompName, 1, 6) = "RSIHYD" Then
                        If i = 0 Then
                            ssql = ssql & "(" & Trim(Fields(i) & "") & " LIKE '%" & Trim(TXT_SEARCH_TXT.Text) & "%'"
                        Else
                            ssql = ssql & " OR " & Trim(Fields(i) & "") & " LIKE '%" & Trim(TXT_SEARCH_TXT.Text) & "%'"
                        End If
                    Else
                        If i = 0 Then
                            ssql = ssql & "(" & Trim(Fields(i) & "") & " LIKE '" & Trim(TXT_SEARCH_TXT.Text) & "%'"
                        Else
                            ssql = ssql & " OR " & Trim(Fields(i) & "") & " LIKE '" & Trim(TXT_SEARCH_TXT.Text) & "%'"
                        End If
                    End If
                    'If i = 0 Then
                    '    ssql = ssql & "(" & Trim(Fields(i) & "") & " LIKE '" & Trim(TXT_SEARCH_TXT.Text) & "%'"
                    'Else
                    '    ssql = ssql & " OR " & Trim(Fields(i) & "") & " LIKE '" & Trim(TXT_SEARCH_TXT.Text) & "%'"
                    'End If
                Next i
            End If
            ssql = ssql & ") "
            If ssql <> "" Then
                gconnection.getDataSet(ssql, "mytable")
                If gdataset.Tables("mytable").Rows.Count > 0 Then
                    DataGridView1.DataSource = Nothing
                    DataGridView1.Rows.Clear()
                    DataGridView1.DataSource = gdataset.Tables("MYTABLE")
                    'DataGridView1.DataSource = gconnection.getvalue(ssql)
                Else
                    MsgBox("Details Not Found In The Database", MsgBoxStyle.Critical, vCaption)
                    'TXT_SEARCH_TXT.Text = Trim(vLastString & "")
                    TXT_SEARCH_TXT.Focus()
                End If
                ssql = ""
            End If
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.Columns(1).MinimumWidth = 15
            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).HeaderCell.Style.ForeColor = Color.Blue
                If i = 0 Then
                    DataGridView1.Columns(i).ReadOnly = True
                    'DataGridView1.AutoResizeColumns(i)
                Else
                    DataGridView1.Columns(i).ReadOnly = True
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CMB_SRC_FIELDS_KeyDown(sender As Object, e As KeyEventArgs) Handles CMB_SRC_FIELDS.KeyDown
        If e.KeyCode = Keys.Enter Then
            CMB_ORDERBY.Focus()
        End If
    End Sub

    Private Sub CMB_ORDERBY_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            TXT_SEARCH_TXT.Focus()
        End If
    End Sub

    Private Sub CMB_SRC_FIELDS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CMB_SRC_FIELDS.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            CMB_ORDERBY.Focus()
        End If
    End Sub

    Private Sub CMB_ORDERBY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CMB_ORDERBY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TXT_SEARCH_TXT.Focus()
        End If
    End Sub
End Class