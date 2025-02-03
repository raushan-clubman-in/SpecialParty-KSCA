Public Class VIEWDET

    Private Sub VIEWDET_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub VIEWDET_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub LOADDATA(ByVal DC As DataTable, ByVal DET As Boolean, ByVal FORMNAME As String, ByVal SQL As String, ByVal KEYFILD As String, ByVal COLUMNSEQ As Integer)
        DGVDET.DataSource = DC
        'Dim CHECKCOL As New DataGridViewCheckBoxColumn
        'CHECKCOL.HeaderText = "SELECT"
        'DGVDET.Columns.Add(CHECKCOL)
        For i = 0 To DGVDET.Columns.Count - 1
            DGVDET.Columns(i).HeaderCell.Style.ForeColor = Color.Red
            If i = 0 Then
            Else
                DGVDET.Columns(i).ReadOnly = True
            End If
        Next
    End Sub

End Class