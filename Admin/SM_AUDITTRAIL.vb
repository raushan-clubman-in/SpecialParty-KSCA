Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class SM_AUDITTRAIL

    Dim SQLSTRING As String
    Dim gconnection As New GlobalClass

    Private Sub BT_GET_Click(sender As Object, e As EventArgs) Handles BT_GET.Click
        Checkdaterangevalidate(DTP_FROM.Value, DTP_TO.Value)
        If chkdatevalidate = False Then Exit Sub
        If rd_summary.Checked = True Then
        Else
            rd_details.Checked = False
        End If
        Dim i As Integer
        i = 0


        Dim gdebit, gcredit As Decimal

        gdebit = 0 : gcredit = 0

        If rd_summary.Checked = True Then
            GP_SUMMARY.Visible = True
            GP_SUMMARY.BringToFront()

            GP_DETAILS.Visible = False
            GP_DETAILS.SendToBack()
            SSGRID1.ClearRange(1, 1, 0, 0, False)

            SQLSTRING = "SELECT   VoucherType,CASHBANK, AccountCode ,AccountcodeDesc, SUM(DEBIT) AS DEBIT,SUM(CREDIT) AS CREDIT  FROM VW_PARTYAUDIT_JOUR"
            SQLSTRING = SQLSTRING & " WHERE  CAST(CONVERT(VARCHAR(11),VOUCHERDATE,106 )  AS DATETIME) BETWEEN '" & Format(DTP_FROM.Value, "dd MMM yyyy") & "' and  '" & Format(DTP_TO.Value, "dd MMM yyyy") & "'"
            SQLSTRING = SQLSTRING & " GROUP BY  VoucherType , CashBank, AccountCode ,AccountcodeDesc"
            SQLSTRING = SQLSTRING & " ORDER BY VoucherType,CASHBANK"

            gconnection.getDataSet(SQLSTRING, "VW_SMAUDIT_JOUR")
            If gdataset.Tables("VW_SMAUDIT_JOUR").Rows.Count - 1 >= 0 Then

                For i = 0 To gdataset.Tables("VW_SMAUDIT_JOUR").Rows.Count - 1
                    With SSGRID1
                        .Row = i + 1
                        .Col = 1
                        .Text = gdataset.Tables("VW_SMAUDIT_JOUR").Rows(i).Item("AccountCode")

                        .Row = i + 1
                        .Col = 2
                        .Text = gdataset.Tables("VW_SMAUDIT_JOUR").Rows(i).Item("AccountcodeDesc")

                        .Row = i + 1
                        .Col = 3
                        .Text = gdataset.Tables("VW_SMAUDIT_JOUR").Rows(i).Item("CREDIT")
                        gcredit = gcredit + Val(.Text)

                        .Row = i + 1
                        .Col = 4
                        .Text = gdataset.Tables("VW_SMAUDIT_JOUR").Rows(i).Item("DEBIT")
                        gdebit = gdebit + Val(.Text)

                    End With

                Next
                With SSGRID1
                    .Row = i + 1
                    .Col = 2
                    .ForeColor = Color.Red
                    .FontBold = True
                    .FontSize = 12
                    .Text = "Grand Total"

                    .Col = 3
                    .ForeColor = Color.Red
                    .FontBold = True
                    .FontSize = 12
                    .Text = gcredit

                    .Col = 4
                    .ForeColor = Color.Red
                    .FontBold = True
                    .FontSize = 12
                    .Text = gdebit

                End With

            End If

        Else
            GP_SUMMARY.Visible = False
            GP_SUMMARY.SendToBack()
            GP_DETAILS.Visible = True
            GP_DETAILS.BringToFront()

            SQLSTRING = "SELECT  VOUCHERNO, VOUCHERDATE ,VOUCHERTYPE,AccountCode ,AccountcodeDesc, SUM(DEBIT) AS DEBIT,SUM(CREDIT)AS CREDIT  FROM VW_PARTYAUDIT_JOUR"
            SQLSTRING = SQLSTRING & " WHERE  CAST(CONVERT(VARCHAR(11),VOUCHERDATE,106 ) AS DATETIME) BETWEEN '" & Format(DTP_FROM.Value, "dd MMM yyyy") & "' and  '" & Format(DTP_TO.Value, "dd MMM yyyy") & "'"
            SQLSTRING = SQLSTRING & " GROUP BY  VOUCHERNO, VOUCHERDATE ,VOUCHERTYPE,AccountCode ,AccountcodeDesc "
            SQLSTRING = SQLSTRING & " ORDER BY VoucherType,VOUCHERNO, VOUCHERDATE  "

            gconnection.getDataSet(SQLSTRING, "VW_SMAUDIT_JOUR")
            If gdataset.Tables("VW_SMAUDIT_JOUR").Rows.Count - 1 >= 0 Then
                If gdataset.Tables("VW_SMAUDIT_JOUR").Rows.Count > 450 Then
                    SSGRID2.MaxRows = gdataset.Tables("VW_SMAUDIT_JOUR").Rows.Count + 20
                End If

                For i = 0 To gdataset.Tables("VW_SMAUDIT_JOUR").Rows.Count - 1
                    With SSGRID2
                        .Row = i + 1
                        .Col = 1
                        .Text = gdataset.Tables("VW_SMAUDIT_JOUR").Rows(i).Item("VOUCHERNO")

                        .Row = i + 1
                        .Col = 2
                        .Text = gdataset.Tables("VW_SMAUDIT_JOUR").Rows(i).Item("VOUCHERDATE")

                        .Row = i + 1
                        .Col = 3
                        .Text = gdataset.Tables("VW_SMAUDIT_JOUR").Rows(i).Item("VOUCHERTYPE")

                        .Row = i + 1
                        .Col = 4
                        .Text = gdataset.Tables("VW_SMAUDIT_JOUR").Rows(i).Item("AccountCode")

                        .Row = i + 1
                        .Col = 5
                        .Text = gdataset.Tables("VW_SMAUDIT_JOUR").Rows(i).Item("AccountcodeDesc")

                        .Row = i + 1
                        .Col = 6
                        .Text = gdataset.Tables("VW_SMAUDIT_JOUR").Rows(i).Item("CREDIT")
                        gcredit = gcredit + Val(.Text)

                        .Row = i + 1
                        .Col = 7
                        .Text = gdataset.Tables("VW_SMAUDIT_JOUR").Rows(i).Item("DEBIT")
                        gdebit = gdebit + Val(.Text)

                    End With
                Next

                With SSGRID2
                    .Row = i + 1
                    .Col = 5
                    .ForeColor = Color.Red
                    .FontBold = True
                    .FontSize = 12
                    .Text = "Grand Total"

                    .Col = 6
                    .ForeColor = Color.Red
                    .FontBold = True
                    .FontSize = 12
                    .Text = gcredit

                    .Col = 7
                    .ForeColor = Color.Red
                    .FontBold = True
                    .FontSize = 12
                    .Text = gdebit

                End With

            End If



        End If




    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        SQLSTRING = "SELECT   Trans_Type,CashBank, AccountIn ,ACCDESC, SUM(debit) AS debit,SUM(credit) AS credit  FROM VW_ADUIT_PARTY"
        SQLSTRING = SQLSTRING & " WHERE  CAST(CONVERT(VARCHAR(11),Trans_Date,106 ) AS DATETIME) BETWEEN '" & Format(DTP_FROM.Value, "dd MMM yyyy") & "' and  '" & Format(DTP_TO.Value, "dd MMM yyyy") & "'"
        SQLSTRING = SQLSTRING & " GROUP BY  Trans_Type , CashBank,  AccountIn,ACCDESC"
        SQLSTRING = SQLSTRING & " ORDER BY Trans_Type"

        Dim Viewer As New ReportViwer
        Dim r As New SMAUDIT_SUMMARY
        Dim txtobj1 As TextObject

        Viewer.ssql = SQLSTRING

        txtobj1 = r.ReportDefinition.ReportObjects("Text7")
        txtobj1.Text = "USER NAME : " & UCase(gUsername)



        txtobj1 = r.ReportDefinition.ReportObjects("Text8")
        txtobj1.Text = gCompanyname

        txtobj1 = r.ReportDefinition.ReportObjects("Text9")
        txtobj1.Text = gCity


        txtobj1 = r.ReportDefinition.ReportObjects("Text11")
        txtobj1.Text = "DATE BETWEEN " & Format(DTP_FROM.Value, "dd MMM yyyy") & " TO  " & Format(DTP_TO.Value, "dd MMM yyyy")


        Viewer.Report = r
        Viewer.Refresh()
        Viewer.TableName = "VW_ADUIT"
        Viewer.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GP_SUMMARY.Visible = False
        GP_SUMMARY.SendToBack()
    End Sub

    Private Sub BT_CLOSE_Click(sender As Object, e As EventArgs) Handles BT_CLOSE.Click
        GP_DETAILS.Visible = False
        GP_DETAILS.SendToBack()
    End Sub

    Private Sub BT_REPORT_Click(sender As Object, e As EventArgs) Handles BT_REPORT.Click
        SQLSTRING = "SELECT   Trans_No,Trans_Date,Trans_Type ,CashBank, AccountIn ,ACCDESC,   debit,  credit  FROM VW_ADUIT_PARTY"
        SQLSTRING = SQLSTRING & " WHERE  CAST(CONVERT(VARCHAR(11),Trans_Date,106 ) AS DATETIME) BETWEEN '" & Format(DTP_FROM.Value, "dd MMM yyyy") & "' and  '" & Format(DTP_TO.Value, "dd MMM yyyy") & "'"
        'SQLSTRING = SQLSTRING & " GROUP BY  Trans_Type , CashBank,  AccountIn,ACCDESC"
        SQLSTRING = SQLSTRING & " ORDER BY Trans_No,Trans_Type,Trans_Date"

        Dim Viewer As New ReportViwer
        Dim r As New SMAUDIT_DETAILS
        Dim txtobj1 As TextObject

        Viewer.ssql = SQLSTRING

        txtobj1 = r.ReportDefinition.ReportObjects("Text2")
        txtobj1.Text = "USER NAME : " & UCase(gUsername)

        txtobj1 = r.ReportDefinition.ReportObjects("Text16")
        txtobj1.Text = gCompanyname

        txtobj1 = r.ReportDefinition.ReportObjects("Text17")
        txtobj1.Text = gCity


        txtobj1 = r.ReportDefinition.ReportObjects("Text14")
        txtobj1.Text = "DATE BETWEEN " & Format(DTP_FROM.Value, "dd MMM yyyy") & " TO  " & Format(DTP_TO.Value, "dd MMM yyyy")

        Viewer.Report = r
        Viewer.Refresh()
        Viewer.TableName = "VW_ADUIT"
        Viewer.Show()

    End Sub

    Private Sub BT_EXIT_Click(sender As Object, e As EventArgs) Handles BT_EXIT.Click
        Me.Close()

    End Sub

    Private Sub SM_AUDITTRAIL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class