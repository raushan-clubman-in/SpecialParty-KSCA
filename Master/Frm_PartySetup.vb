Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports System.IO
Public Class Frm_PartySetup
    Dim SSQL As String
    Dim GCONNECTION As New GlobalClass
    Dim gconn As New GlobalClass
    Dim DT As New DataTable
    Dim GrdRate, GrdAmount, GrdTaxAmt As Double
    Dim boolchk, booldatechk As Boolean
    Dim sqlstring As String
    Private Sub Frm_PartySetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            sqlstring = "SELECT ISNULL(NonStandRate,0) as NonStandRate,ISNULL(NonStandRateWEnd,0) as NonStandRateWEnd FROM partysetUP "
            GCONNECTION.getDataSet(sqlstring, "PartySetup")
            If gdataset.Tables("PartySetup").Rows.Count > 0 Then
                Txt_NonStandRate.Text = gdataset.Tables("PartySetup").Rows(0).Item("NonStandRate")
                Txt_NonStandRateWEnd.Text = gdataset.Tables("PartySetup").Rows(0).Item("NonStandRateWEnd")
            Else
                MessageBox.Show("Party Setup Table r missing or No Recoreds is there, Plz Check", MyCompanyName)
                Txt_NonStandRate.Text = 0
                Txt_NonStandRateWEnd.Text = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Party Setup Table r missing " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click

        sqlstring = "Update partysetUP Set NonStandRate = " & Val(Txt_NonStandRate.Text) & ",NonStandRateWEnd = " & Val(Txt_NonStandRateWEnd.Text) & ""
        GCONNECTION.dataOperation(1, sqlstring, "PartySetup")

        sqlstring = "SELECT ISNULL(NonStandRate,0) as NonStandRate,ISNULL(NonStandRateWEnd,0) as NonStandRateWEnd FROM partysetUP "
        GCONNECTION.getDataSet(sqlstring, "PartySetup")
        If gdataset.Tables("PartySetup").Rows.Count > 0 Then
            Txt_NonStandRate.Text = gdataset.Tables("PartySetup").Rows(0).Item("NonStandRate")
            Txt_NonStandRateWEnd.Text = gdataset.Tables("PartySetup").Rows(0).Item("NonStandRateWEnd")
        Else
            MessageBox.Show("Party Setup Table r missing or No Recoreds is there, Plz Check", MyCompanyName)
            Txt_NonStandRate.Text = 0
            Txt_NonStandRateWEnd.Text = 0
        End If

    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
End Class