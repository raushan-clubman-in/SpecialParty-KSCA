Public Class Frm_BillClosing
    Dim vSeqno As Double
    Dim sqlstring As String
    Dim boolchk As Boolean
    Dim gconnection As New GlobalClass
    Dim PACKINGPERCENT As Double
    Private Sub Frm_BillClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dtp_CloseDate.Value = Format(serverdate, "dd/MM/yyyy")
        Label2.Text = "Last Close Date: " & Format(billclosedate, "dd/MM/yyyy")
    End Sub

    Private Sub cmd_Ok_Click(sender As Object, e As EventArgs) Handles cmd_Ok.Click

        If MsgBox("Are U Sure To Update this Date", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If gUserCategory = "S" Then
                sqlstring = "Update partysetUP Set BillCloseDate = '" & Format(Dtp_CloseDate.Value, "dd/MMM/yyyy") & "'"
                gconnection.dataOperation(1, sqlstring, "PartySetup")
            Else
                MessageBox.Show("You u Not Authourized", MyCompanyName)
                Exit Sub
            End If
        End If

        sqlstring = "SELECT Isnull(BillCloseDate,'') as BillCloseDate FROM partysetUP "
        gconnection.getDataSet(sqlstring, "BILLCLOSE")
        If gdataset.Tables("BILLCLOSE").Rows.Count > 0 Then
            billclosedate = Format(gdataset.Tables("BILLCLOSE").Rows(0).Item("BillCloseDate"), "dd-MMM-yyyy")
            serverdate = DateAdd(DateInterval.Day, 1, billclosedate)
        End If
        Label2.Text = "Last Close Date: " & Format(billclosedate, "dd/MM/yyyy")

    End Sub

    Private Sub cmd_Cancel_Click(sender As Object, e As EventArgs) Handles cmd_Cancel.Click
        Me.Close()
    End Sub
End Class