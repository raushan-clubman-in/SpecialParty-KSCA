Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports System.IO
Public Class Frm_M_HallMaster
    Dim SSQL As String
    Dim GConnection As New GlobalClass
    Dim DT As New DataTable
    Dim boolchk As Boolean
    Dim sqlstring As String

    Private Sub Frm_M_HallMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            If CmdAdd.Enabled = True Then
                Call CmdAdd_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            If Cmd_Freeze.Enabled = True Then
                Call Cmd_Freeze_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            Call Cmdview_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmdexit_Click(sender, e)
        End If
    End Sub
    Private Sub Frm_M_HallMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Txt_HallCode.Focus()
    End Sub

    Private Sub Txt_HallCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_HallCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_HallCode.Text) <> "" Then
                Txt_HallCode_Validated(sender, e)
                Txt_HallDesc.Focus()
            Else
                Cmd_HallCodeHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Txt_HallCode_Validated(sender As Object, e As EventArgs) Handles Txt_HallCode.Validated
        Try
            If Trim(Txt_HallCode.Text) <> "" Then
                sqlstring = "SELECT ISNULL(MG_TaxType,'') As MG_TaxType,ISNULL(MG_Amount,0) as MG_Amount,ISNULL(NonStandRate,0) as NonStandRate,ISNULL(NonStandRateWEnd,0) as NonStandRateWEnd,* FROM PARTY_HALLMASTER_HDR WHERE HallTypeCode = '" & Trim(Txt_HallCode.Text) & "'"
                GConnection.getDataSet(sqlstring, "HDR")
                If gdataset.Tables("HDR").Rows.Count > 0 Then
                    Txt_HallDesc.Text = gdataset.Tables("HDR").Rows(0).Item("HallTypeDesc")
                    Txt_MinCapacity.Text = Val(gdataset.Tables("HDR").Rows(0).Item("MinCapacity"))
                    Txt_MaxCapacity.Text = Val(gdataset.Tables("HDR").Rows(0).Item("MaxCapacity"))
                    Txt_ActCapacity.Text = Val(gdataset.Tables("HDR").Rows(0).Item("ActCapacity"))
                    Txt_SecDeposit.Text = Val(gdataset.Tables("HDR").Rows(0).Item("SeDeposit"))
                    Cbo_HRentOveride.Text = gdataset.Tables("HDR").Rows(0).Item("RentOverride")
                    Cbo_OSFoodAllow.Text = gdataset.Tables("HDR").Rows(0).Item("OutFoodAllowed")
                    Cbo_AdvanceApp.Text = gdataset.Tables("HDR").Rows(0).Item("AdvanceApp")
                    Txt_HallChargeCode.Text = gdataset.Tables("HDR").Rows(0).Item("TaxType")
                    Txt_MKChargeCode.Text = gdataset.Tables("HDR").Rows(0).Item("MKTaxType")
                    Dtp_BookFromTime.Text = Format(gdataset.Tables("HDR").Rows(0).Item("Book_FromTime"), "T")
                    Dtp_BookToTime.Text = Format(gdataset.Tables("HDR").Rows(0).Item("Book_ToTime"), "T")

                    Txt_NonStandRate.Text = gdataset.Tables("HDR").Rows(0).Item("NonStandRate")
                    Txt_NonStandRateWEnd.Text = gdataset.Tables("HDR").Rows(0).Item("NonStandRateWEnd")
                    Txt_MGAmount.Text = gdataset.Tables("HDR").Rows(0).Item("MG_Amount")
                    Txt_MGChargeCode.Text = gdataset.Tables("HDR").Rows(0).Item("MG_TaxType")

                    If gdataset.Tables("HDR").Rows(0).Item("FREEZE") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "This Hall is Freezed on :" & Format(CDate(gdataset.Tables("HDR").Rows(0).Item("AddDate")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "This Hall is Freezed on :"
                        Me.Cmd_Freeze.Text = "Freeze[F8]"
                    End If
                    Me.CmdAdd.Text = "Update[F7]"
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    sqlstring = "SELECT * FROM PARTY_HALLMASTER_DET WHERE HallTypeCode = '" & Trim(Txt_HallCode.Text) & "' And RateFlag = 'F' And SessionType = 'FullDay'"
                    GConnection.getDataSet(sqlstring, "DETF")
                    If gdataset.Tables("DETF").Rows.Count > 0 Then
                        Chk_FullDay.Checked = True
                        Txt_FullDayRate.Text = Val(gdataset.Tables("DETF").Rows(0).Item("Rate"))
                    Else
                        Chk_FullDay.Checked = False
                        Txt_FullDayRate.Text = ""
                    End If
                    sqlstring = "SELECT * FROM PARTY_HALLMASTER_DET WHERE HallTypeCode = '" & Trim(Txt_HallCode.Text) & "' And RateFlag = 'H' And SessionType = 'HalfDay'"
                    GConnection.getDataSet(sqlstring, "DETH")
                    If gdataset.Tables("DETH").Rows.Count > 0 Then
                        Chk_HalfDay.Checked = True
                        Txt_HalfDayRate.Text = Val(gdataset.Tables("DETH").Rows(0).Item("Rate"))
                        Txt_HalfDayHourRate.Text = Val(gdataset.Tables("DETH").Rows(0).Item("HalfDayHourRate"))
                    Else
                        Chk_HalfDay.Checked = False
                        Txt_HalfDayRate.Text = ""
                        Txt_HalfDayHourRate.Text = ""
                    End If
                    sqlstring = "SELECT * FROM PARTY_HALLMASTER_DET WHERE HallTypeCode = '" & Trim(Txt_HallCode.Text) & "' And RateFlag = 'T' And SessionType = 'TimeSlot' Order by PCode"
                    GConnection.getDataSet(sqlstring, "DETT")
                    If gdataset.Tables("DETT").Rows.Count > 0 Then
                        Chk_TimeSlot.Checked = True
                        sSGrid_TimeSlot.ClearRange(1, 1, -1, -1, True)
                        With sSGrid_TimeSlot
                            For i = 0 To gdataset.Tables("DETT").Rows.Count - 1
                                .Col = 1
                                .Row = i + 1
                                .Text = Trim(gdataset.Tables("DETT").Rows(i).Item("PDesc"))
                                .Col = 2
                                .Row = i + 1
                                .Text = Val(gdataset.Tables("DETT").Rows(i).Item("Rate"))
                                .Col = 3
                                .Row = i + 1
                                .Text = Val(gdataset.Tables("DETT").Rows(i).Item("TimeInterval"))
                                .Col = 4
                                .Row = i + 1
                                .Text = Val(gdataset.Tables("DETT").Rows(i).Item("HalfDayHourRate"))
                            Next
                        End With
                    Else
                        Chk_TimeSlot.Checked = False
                        sSGrid_TimeSlot.ClearRange(1, 1, -1, -1, True)
                    End If
                    sqlstring = "SELECT HallCode,TYPE,CanBefore,CancelType,Cancel_Amt_Per,FixedAmount,Freeze,Adduser,Adddate FROM PARTY_CANCELLATIONMASTER WHERE HallCode = '" & Trim(Txt_HallCode.Text) & "' Order by TYPE,CanBefore"
                    GConnection.getDataSet(sqlstring, "CANDET")
                    If gdataset.Tables("CANDET").Rows.Count > 0 Then
                        sSGrid_Can.ClearRange(1, 1, -1, -1, True)
                        With sSGrid_Can
                            For i = 0 To gdataset.Tables("CANDET").Rows.Count - 1
                                .Col = 1
                                .Row = i + 1
                                .Text = Trim(gdataset.Tables("CANDET").Rows(i).Item("TYPE"))
                                .Col = 2
                                .Row = i + 1
                                .Text = Val(gdataset.Tables("CANDET").Rows(i).Item("CanBefore"))
                                .Col = 3
                                .Row = i + 1
                                .Text = Trim(gdataset.Tables("CANDET").Rows(i).Item("CancelType"))
                                .Col = 4
                                .Row = i + 1
                                If Trim(gdataset.Tables("CANDET").Rows(i).Item("CancelType")) = "Amount" Then
                                    .Text = Val(gdataset.Tables("CANDET").Rows(i).Item("FixedAmount"))
                                Else
                                    .Text = Val(gdataset.Tables("CANDET").Rows(i).Item("Cancel_Amt_Per"))
                                End If
                            Next
                        End With
                    Else
                        sSGrid_Can.ClearRange(1, 1, -1, -1, True)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetRights()
        Try
            Dim i, j, k, x As Integer
            Dim vmain, vsmod, vssmod As Long
            Dim ssql, SQLSTRING As String
            Dim M1 As New MainMenu
            Dim chstr As String

            SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
            gconnection.getDataSet(SQLSTRING, "USER")
            If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
                For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                    With gdataset.Tables("USER").Rows(i)
                        chstr = abcdMINUS(.Item("RIGHTS"))
                    End With
                Next
            End If

            Me.CmdAdd.Enabled = False
            Me.Cmd_Freeze.Enabled = False
            Cmdview.Enabled = False
            'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
            If Len(chstr) > 0 Then
                Dim Right() As Char
                Right = chstr.ToCharArray
                For x = 0 To Right.Length - 1
                    If Right(x) = "A" Then
                        Me.CmdAdd.Enabled = True
                        Me.Cmd_Freeze.Enabled = True
                        Me.Cmdview.Enabled = True
                        Exit Sub
                    End If
                    If UCase(Mid(Me.CmdAdd.Text, 1, 1)) = "A" Then
                        If Right(x) = "S" Then
                            Me.CmdAdd.Enabled = True
                        End If
                    Else
                        If Right(x) = "M" Then
                            Me.CmdAdd.Enabled = True
                        End If
                    End If
                    If Right(x) = "D" Then
                        Me.Cmd_Freeze.Enabled = True
                    End If
                    If Right(x) = "V" Then
                        Me.Cmdview.Enabled = True
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_HallCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_HallCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "SELECT HallTypeCode,HallTypeDesc FROM PARTY_HALLMASTER_HDR"
            If Trim(Search) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " "
            End If
            vform.Field = "HallTypeCode,HallTypeDesc"
            vform.vCaption = "Hall Master Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_HallCode.Text = Trim(vform.keyfield & "")
                Txt_HallCode_Validated(sender, e)
                Txt_HallDesc.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txt_HallDesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_HallDesc.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_HallDesc.Text) <> "" Then
                Txt_MinCapacity.Focus()
            Else
                Txt_HallDesc.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_MinCapacity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_MinCapacity.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_MinCapacity.Text) <> 0 Then
                Txt_MaxCapacity.Focus()
            Else
                Txt_MinCapacity.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_MaxCapacity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_MaxCapacity.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_MaxCapacity.Text) <> 0 Then
                Txt_ActCapacity.Focus()
            Else
                Txt_MaxCapacity.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_ActCapacity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ActCapacity.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_ActCapacity.Text) <> 0 Then
                Txt_SecDeposit.Focus()
            Else
                Txt_ActCapacity.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_SecDeposit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_SecDeposit.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_SecDeposit.Text) >= 0 Then
                Cbo_HRentOveride.Focus()
            Else
                Txt_SecDeposit.Focus()
            End If
        End If
    End Sub

    Private Sub Cbo_HRentOveride_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cbo_HRentOveride.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cbo_OSFoodAllow.Focus()
        End If
    End Sub

    Private Sub Cbo_OSFoodAllow_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cbo_OSFoodAllow.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_FullDayRate.Focus()
        End If
    End Sub

    Private Sub Txt_FullDayRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_FullDayRate.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_FullDayRate.Text) > 0 Then
                Txt_HalfDayRate.Focus()
            Else
                Txt_FullDayRate.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_HalfDayRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_HalfDayRate.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_HalfDayRate.Text) > 0 Then
                Txt_HalfDayHourRate.Focus()
            Else
                Txt_HalfDayRate.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_HalfDayHourRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_HalfDayHourRate.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_HalfDayHourRate.Text) >= 0 Then
                sSGrid_TimeSlot.Focus()
            Else
                Txt_HalfDayHourRate.Focus()
            End If
        End If
    End Sub

    Private Sub Dtp_BookFromTime_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Dtp_BookFromTime.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dtp_BookToTime.Focus()
        End If
    End Sub

    Private Sub Dtp_BookToTime_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Dtp_BookToTime.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_HallChargeCode.Focus()
        End If
    End Sub

    Private Sub Txt_HallChargeCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_HallChargeCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_HallChargeCode.Text) <> "" Then
                Txt_HallChargeCode_Validated(sender, e)
                Txt_MKChargeCode.Focus()
            Else
                Cmd_HChargeCodeHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Cmd_HChargeCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_HChargeCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "SELECT CHARGECODE,CHARGEDESC FROM CHARGEMASTER"
            If Trim(Search) = " " Then
                M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
            Else
                M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
            End If
            vform.Field = "CHARGECODE,CHARGEDESC"
            vform.vCaption = "Charge Master Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_HallChargeCode.Text = Trim(vform.keyfield & "")
                Txt_HallChargeCode_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txt_HallChargeCode_Validated(sender As Object, e As EventArgs) Handles Txt_HallChargeCode.Validated
        Try
            sqlstring = "SELECT CHARGECODE,CHARGEDESC FROM CHARGEMASTER WHERE ISNULL(FREEZE,'') <> 'Y' AND ISNULL(CHARGECODE,'') = '" & Trim(Txt_HallChargeCode.Text) & "'"
            GConnection.getDataSet(sqlstring, "ChargeCode")
            If gdataset.Tables("ChargeCode").Rows.Count > 0 Then
                Txt_HallChargeCode.Text = gdataset.Tables("ChargeCode").Rows(0).Item(0)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt_MKChargeCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_MKChargeCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_MKChargeCode.Text) <> "" Then
                Txt_MKChargeCode_Validated(sender, e)
            Else
                Cmd_MKChargeCodeHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Txt_MKChargeCode_Validated(sender As Object, e As EventArgs) Handles Txt_MKChargeCode.Validated
        Try
            sqlstring = "SELECT CHARGECODE,CHARGEDESC FROM CHARGEMASTER WHERE ISNULL(FREEZE,'') <> 'Y' AND ISNULL(CHARGECODE,'') = '" & Trim(Txt_MKChargeCode.Text) & "'"
            GConnection.getDataSet(sqlstring, "ChargeCode")
            If gdataset.Tables("ChargeCode").Rows.Count > 0 Then
                Txt_MKChargeCode.Text = gdataset.Tables("ChargeCode").Rows(0).Item(0)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmd_MKChargeCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_MKChargeCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "SELECT CHARGECODE,CHARGEDESC FROM CHARGEMASTER"
            If Trim(Search) = " " Then
                M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
            Else
                M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
            End If
            vform.Field = "CHARGECODE,CHARGEDESC"
            vform.vCaption = "Charge Master Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_MKChargeCode.Text = Trim(vform.keyfield & "")
                Txt_MKChargeCode_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub sSGrid_TimeSlot_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles sSGrid_TimeSlot.KeyDownEvent
        Dim i As Integer
        Try
            If e.keyCode = Keys.Enter Then
                With sSGrid_TimeSlot
                    i = .ActiveRow
                    If .ActiveCol = 1 Then
                        .Row = i
                        .Col = 1
                        If Trim(.Text) <> "" Then
                            sSGrid_TimeSlot.SetActiveCell(1, i)
                        Else
                            sSGrid_TimeSlot.SetActiveCell(0, i)
                        End If
                    ElseIf .ActiveCol = 2 Then
                        .Row = i
                        .Col = 2
                        If Val(.Text) > 0 Then
                            sSGrid_TimeSlot.SetActiveCell(2, i)
                        Else
                            sSGrid_TimeSlot.SetActiveCell(1, i)
                        End If
                    ElseIf .ActiveCol = 3 Then
                        .Row = i
                        .Col = 3
                        If Val(.Text) > 0 Then
                            sSGrid_TimeSlot.SetActiveCell(0, i + 1)
                        Else
                            sSGrid_TimeSlot.SetActiveCell(2, i)
                        End If
                    End If
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim strsql, halltype, Insert(0), HALLCODE, PCODE, FTIME, TTIME, APType, Type As String
        Dim TCode, TDesc As String
        Dim TRate, BefHours, APAmount, AddHourRate As Double
        Dim i, j, TInterval As Integer
        Try
            If Mid(CmdAdd.Text, 1, 1) = "A" Then
                Call checkValidation()
                If boolchk = False Then Exit Sub
                sqlstring = "INSERT INTO PARTY_HALLMASTER_HDR (HallTypeCode,HallTypeDesc,MinCapacity,MaxCapacity,ActCapacity,SeDeposit,RentOverride,OutFoodAllowed,AdvanceApp,MKTaxType,TaxType,Book_FromTime,Book_ToTime,AddUser,AddDate,Freeze,NonStandRate,NonStandRateWEnd,MG_Amount,MG_TaxType) Values ( "
                sqlstring = sqlstring & "'" & Trim(Txt_HallCode.Text) & "','" & Trim(Txt_HallDesc.Text) & "','" & Val(Txt_MinCapacity.Text) & "','" & Val(Txt_MaxCapacity.Text) & "','" & Val(Txt_ActCapacity.Text) & "',"
                sqlstring = sqlstring & "'" & Val(Txt_SecDeposit.Text) & "','" & Trim(Cbo_HRentOveride.Text) & "','" & Trim(Cbo_OSFoodAllow.Text) & "','" & Trim(Cbo_AdvanceApp.Text) & "','" & Trim(Txt_MKChargeCode.Text) & "','" & Trim(Txt_HallChargeCode.Text) & "','" & Trim(Dtp_BookFromTime.Text) & "','" & Trim(Dtp_BookToTime.Text) & "','" & Trim(gUsername) & "',GetDate(),'N'," & Val(Txt_NonStandRate.Text) & "," & Val(Txt_NonStandRateWEnd.Text) & "," & Val(Txt_MGAmount.Text) & ",'" & Trim(Txt_MGChargeCode.Text) & "')"
                Insert(0) = sqlstring
                If Chk_FullDay.Checked = True Then
                    sqlstring = "INSERT INTO PARTY_HALLMASTER_DET (HallTypeCode,PCode,PDesc,Sun,Mon,Tue,Wed,Thu,Fri,Sat,Freeze,AddUser,AddDate,Rate,SessionType,TimeInterval,RateFlag,HalfDayHourRate) VALUES ( "
                    sqlstring = sqlstring & "'" & Trim(Txt_HallCode.Text) & "','" & Trim(Txt_HallCode.Text & "F") & "','" & Trim(Txt_HallDesc.Text & " Full Day") & "','Y','Y','Y','Y','Y','Y','Y','N',"
                    sqlstring = sqlstring & "'" & Trim(gUsername) & "',GetDate(),'" & Val(Txt_FullDayRate.Text) & "','FullDay','12','F',0)"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
                If Chk_HalfDay.Checked = True Then
                    sqlstring = "INSERT INTO PARTY_HALLMASTER_DET (HallTypeCode,PCode,PDesc,Sun,Mon,Tue,Wed,Thu,Fri,Sat,Freeze,AddUser,AddDate,Rate,SessionType,TimeInterval,RateFlag,HalfDayHourRate) VALUES ( "
                    sqlstring = sqlstring & "'" & Trim(Txt_HallCode.Text) & "','" & Trim(Txt_HallCode.Text & "H") & "','" & Trim(Txt_HallDesc.Text & " Half Day") & "','Y','Y','Y','Y','Y','Y','Y','N',"
                    sqlstring = sqlstring & "'" & Trim(gUsername) & "',GetDate(),'" & Val(Txt_HalfDayRate.Text) & "','HalfDay','6','H','" & Val(Txt_HalfDayHourRate.Text) & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
                If Chk_TimeSlot.Checked = True Then
                    With sSGrid_TimeSlot
                        For i = 1 To .DataRowCnt
                            .Col = 1
                            .Row = i
                            TDesc = Trim(.Text)
                            .Col = 2
                            .Row = i
                            TRate = Val(.Text)
                            .Col = 3
                            .Row = i
                            TInterval = Val(.Text)
                            .Col = 4
                            .Row = i
                            AddHourRate = Val(.Text)
                            TCode = Trim(Txt_HallCode.Text) & "S" & i

                            sqlstring = "INSERT INTO PARTY_HALLMASTER_DET (HallTypeCode,PCode,PDesc,Sun,Mon,Tue,Wed,Thu,Fri,Sat,Freeze,AddUser,AddDate,Rate,SessionType,TimeInterval,RateFlag,HalfDayHourRate) VALUES ( "
                            sqlstring = sqlstring & "'" & Trim(Txt_HallCode.Text) & "','" & Trim(TCode) & "','" & Trim(TDesc) & "','Y','Y','Y','Y','Y','Y','Y','N',"
                            sqlstring = sqlstring & "'" & Trim(gUsername) & "',GetDate(),'" & Val(TRate) & "','TimeSlot','" & Val(TInterval) & "','T','" & Val(AddHourRate) & "')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next
                    End With
                End If
                With sSGrid_Can
                    If .DataRowCnt > 0 Then
                        For i = 1 To .DataRowCnt
                            .Col = 1
                            .Row = i
                            Type = Trim(.Text)
                            .Col = 2
                            .Row = i
                            BefHours = Val(.Text)
                            .Col = 3
                            .Row = i
                            APType = Trim(.Text)
                            .Col = 4
                            .Row = i
                            APAmount = Val(.Text)
                            sqlstring = "Insert Into PARTY_CANCELLATIONMASTER(HallCode,TYPE,CanBefore,CancelType,Cancel_Amt_Per,FixedAmount,Freeze,Adduser,Adddate) Values ( "
                            If Trim(APType) = "Amount" Then
                                sqlstring = sqlstring & "'" & Trim(Txt_HallCode.Text) & "','" & Trim(Type) & "'," & Val(BefHours) & ",'" & Trim(APType) & "',0," & Val(APAmount) & ",'N','" & gUsername & "',getdate() )"
                            Else
                                sqlstring = sqlstring & "'" & Trim(Txt_HallCode.Text) & "','" & Trim(Type) & "'," & Val(BefHours) & ",'" & Trim(APType) & "'," & Val(APAmount) & ",0,'N','" & gUsername & "',getdate() )"
                            End If
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next
                    End If
                End With
                GConnection.MoreTransold(Insert)
                Call CmdClear_Click(sender, e)

            ElseIf Mid(CmdAdd.Text, 1, 1) = "U" Then
                Call checkValidation()
                If boolchk = False Then Exit Sub
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Freezed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                    boolchk = False
                End If
                sqlstring = "UPDATE PARTY_HALLMASTER_HDR SET HallTypeDesc = '" & Trim(Txt_HallDesc.Text) & "',MinCapacity = '" & Val(Txt_MinCapacity.Text) & "',MaxCapacity = '" & Val(Txt_MaxCapacity.Text) & "',"
                sqlstring = sqlstring & " ActCapacity = '" & Val(Txt_ActCapacity.Text) & "',SeDeposit = '" & Val(Txt_SecDeposit.Text) & "',RentOverride = '" & Trim(Cbo_HRentOveride.Text) & "',"
                sqlstring = sqlstring & " OutFoodAllowed = '" & Trim(Cbo_OSFoodAllow.Text) & "',AdvanceApp = '" & Trim(Cbo_AdvanceApp.Text) & "',MKTaxType = '" & Trim(Txt_MKChargeCode.Text) & "',"
                sqlstring = sqlstring & " TaxType = '" & Trim(Txt_HallChargeCode.Text) & "',Book_FromTime = '" & Trim(Dtp_BookFromTime.Text) & "',Book_ToTime = '" & Trim(Dtp_BookToTime.Text) & "',NonStandRate = " & Val(Txt_NonStandRate.Text) & ",NonStandRateWEnd = " & Val(Txt_NonStandRateWEnd.Text) & ",MG_Amount = " & Val(Txt_MGAmount.Text) & ",MG_TaxType = '" & Trim(Txt_MGChargeCode.Text) & "',"
                sqlstring = sqlstring & " AddUser = '" & Trim(gUsername) & "',AddDate = GetDate() Where HallTypeCode = '" & Trim(Txt_HallCode.Text) & "'"
                Insert(0) = sqlstring

                sqlstring = "DELETE FROM PARTY_HALLMASTER_DET Where HallTypeCode = '" & Trim(Txt_HallCode.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                If Chk_FullDay.Checked = True Then
                    sqlstring = "INSERT INTO PARTY_HALLMASTER_DET (HallTypeCode,PCode,PDesc,Sun,Mon,Tue,Wed,Thu,Fri,Sat,Freeze,AddUser,AddDate,Rate,SessionType,TimeInterval,RateFlag,HalfDayHourRate) VALUES ( "
                    sqlstring = sqlstring & "'" & Trim(Txt_HallCode.Text) & "','" & Trim(Txt_HallCode.Text & "F") & "','" & Trim(Txt_HallDesc.Text & " Full Day") & "','Y','Y','Y','Y','Y','Y','Y','N',"
                    sqlstring = sqlstring & "'" & Trim(gUsername) & "',GetDate(),'" & Val(Txt_FullDayRate.Text) & "','FullDay','12','F',0)"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
                If Chk_HalfDay.Checked = True Then
                    sqlstring = "INSERT INTO PARTY_HALLMASTER_DET (HallTypeCode,PCode,PDesc,Sun,Mon,Tue,Wed,Thu,Fri,Sat,Freeze,AddUser,AddDate,Rate,SessionType,TimeInterval,RateFlag,HalfDayHourRate) VALUES ( "
                    sqlstring = sqlstring & "'" & Trim(Txt_HallCode.Text) & "','" & Trim(Txt_HallCode.Text & "H") & "','" & Trim(Txt_HallDesc.Text & " Half Day") & "','Y','Y','Y','Y','Y','Y','Y','N',"
                    sqlstring = sqlstring & "'" & Trim(gUsername) & "',GetDate(),'" & Val(Txt_HalfDayRate.Text) & "','HalfDay','6','H','" & Val(Txt_HalfDayHourRate.Text) & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
                If Chk_TimeSlot.Checked = True Then
                    With sSGrid_TimeSlot
                        For i = 1 To .DataRowCnt
                            .Col = 1
                            .Row = i
                            TDesc = Trim(.Text)
                            .Col = 2
                            .Row = i
                            TRate = Val(.Text)
                            .Col = 3
                            .Row = i
                            TInterval = Val(.Text)
                            .Col = 4
                            .Row = i
                            AddHourRate = Val(.Text)
                            TCode = Trim(Txt_HallCode.Text) & "S" & i

                            sqlstring = "INSERT INTO PARTY_HALLMASTER_DET (HallTypeCode,PCode,PDesc,Sun,Mon,Tue,Wed,Thu,Fri,Sat,Freeze,AddUser,AddDate,Rate,SessionType,TimeInterval,RateFlag,HalfDayHourRate) VALUES ( "
                            sqlstring = sqlstring & "'" & Trim(Txt_HallCode.Text) & "','" & Trim(TCode) & "','" & Trim(TDesc) & "','Y','Y','Y','Y','Y','Y','Y','N',"
                            sqlstring = sqlstring & "'" & Trim(gUsername) & "',GetDate(),'" & Val(TRate) & "','TimeSlot','" & Val(TInterval) & "','T','" & Val(AddHourRate) & "')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next
                    End With
                End If
                sqlstring = "DELETE FROM PARTY_CANCELLATIONMASTER Where HallCode = '" & Trim(Txt_HallCode.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                With sSGrid_Can
                    If .DataRowCnt > 0 Then
                        For i = 1 To .DataRowCnt
                            .Col = 1
                            .Row = i
                            Type = Trim(.Text)
                            .Col = 2
                            .Row = i
                            BefHours = Val(.Text)
                            .Col = 3
                            .Row = i
                            APType = Trim(.Text)
                            .Col = 4
                            .Row = i
                            APAmount = Val(.Text)
                            sqlstring = "Insert Into PARTY_CANCELLATIONMASTER(HallCode,TYPE,CanBefore,CancelType,Cancel_Amt_Per,FixedAmount,Freeze,Adduser,Adddate) Values ( "
                            If Trim(APType) = "Amount" Then
                                sqlstring = sqlstring & "'" & Trim(Txt_HallCode.Text) & "','" & Trim(Type) & "'," & Val(BefHours) & ",'" & Trim(APType) & "',0," & Val(APAmount) & ",'N','" & gUsername & "',getdate() )"
                            Else
                                sqlstring = sqlstring & "'" & Trim(Txt_HallCode.Text) & "','" & Trim(Type) & "'," & Val(BefHours) & ",'" & Trim(APType) & "'," & Val(APAmount) & ",0,'N','" & gUsername & "',getdate() )"
                            End If
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next
                    End If
                End With
                GConnection.MoreTransold(Insert)
                Call CmdClear_Click(sender, e)
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Sub checkValidation()
        Dim Loc As String
        Try
            boolchk = False
            Dim D1, d2, Fromdate, ToDate As DateTime
            Dim FDAY, TDAY, DAYS, CNT, j, k As Integer
            Dim hlcode, pcode, hlcode1, pcode1, Shlcode As String

            If Trim(Txt_HallCode.Text) = "" Then
                MessageBox.Show(" Hall Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_HallCode.Focus()
                Exit Sub
            End If
            If Trim(Txt_HallDesc.Text) = "" Then
                MessageBox.Show(" Hall Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_HallDesc.Focus()
                Exit Sub
            End If
            If Trim(Cbo_HRentOveride.Text) = "" Then
                MessageBox.Show(" Hall Rent Override can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cbo_HRentOveride.Focus()
                Exit Sub
            End If
            If Trim(Cbo_OSFoodAllow.Text) = "" Then
                MessageBox.Show(" OutSide Food Allowed can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cbo_OSFoodAllow.Focus()
                Exit Sub
            End If
            If Trim(Cbo_AdvanceApp.Text) = "" Then
                MessageBox.Show(" Advance Applicable can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cbo_AdvanceApp.Focus()
                Exit Sub
            End If
            If Trim(Txt_HallChargeCode.Text) = "" Then
                MessageBox.Show(" Charge Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_HallChargeCode.Focus()
                Exit Sub
            End If
            If Trim(Txt_MKChargeCode.Text) = "" Then
                MessageBox.Show(" Marriage Keeper Charge Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_MKChargeCode.Focus()
                Exit Sub
            End If
            If Val(Txt_MinCapacity.Text) <= 0 Then
                MessageBox.Show(" Minimum Capacity can't be Less or Equal to Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_MinCapacity.Focus()
                Exit Sub
            End If
            If Val(Txt_MaxCapacity.Text) <= 0 Then
                MessageBox.Show(" Maximum Capacity can't be Less or Equal to Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_MaxCapacity.Focus()
                Exit Sub
            End If
            If Val(Txt_MinCapacity.Text) > Val(Txt_MaxCapacity.Text) Then
                MessageBox.Show(" Mininum Capacity can't be greater than Maximum Capacity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_MaxCapacity.Focus()
                Exit Sub
            End If
            If Val(Txt_ActCapacity.Text) <= 0 Then
                MessageBox.Show(" Actual Capacity can't be Less or Equal to Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_ActCapacity.Focus()
                Exit Sub
            End If
            If Val(Txt_SecDeposit.Text) < 0 Then
                MessageBox.Show(" Security Deposit can't be Less then Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_SecDeposit.Focus()
                Exit Sub
            End If
            If Chk_FullDay.Checked = True Then
                If Val(Txt_FullDayRate.Text) < 0 Then
                    MessageBox.Show(" Full Day Rate can't be Less or Equal to Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Txt_FullDayRate.Focus()
                    Exit Sub
                End If
            End If
            If Chk_HalfDay.Checked = True Then
                If Val(Txt_HalfDayRate.Text) < 0 Then
                    MessageBox.Show(" Half Day Rate can't be Less or Equal to Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Txt_HalfDayRate.Focus()
                    Exit Sub
                End If
                If Val(Txt_HalfDayHourRate.Text) < 0 Then
                    MessageBox.Show(" Half Day Hour Rate can't be Less or Equal to Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Txt_HalfDayHourRate.Focus()
                    Exit Sub
                End If
            End If

           
            With sSGrid_TimeSlot
                If .DataRowCnt = 0 And Chk_TimeSlot.Checked = True Then
                    MessageBox.Show("Time Slot Details Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    sSGrid_TimeSlot.SetActiveCell(1, 1)
                    sSGrid_TimeSlot.Focus()
                    Exit Sub
                End If
            End With

            With sSGrid_TimeSlot
                For CNT = 1 To .DataRowCnt
                    .Col = 1
                    .Row = CNT
                    hlcode = Trim(.Text)
                    If Trim(hlcode) = "" Then
                        MessageBox.Show("Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .SetActiveCell(0, CNT)
                        .Focus()
                        Exit Sub
                    End If
                    .Col = 2
                    .Row = CNT
                    If Val(.Text) < 0 Then
                        MessageBox.Show("Rate can't be blank For " & hlcode, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .SetActiveCell(1, CNT)
                        .Focus()
                        Exit Sub
                    End If
                    .Col = 3
                    .Row = CNT
                    If Val(.Text) <= 0 Then
                        MessageBox.Show("Time Interval can't be blank For " & hlcode, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .SetActiveCell(1, CNT)
                        .Focus()
                        Exit Sub
                    End If
                Next
            End With
            boolchk = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        Txt_HallCode.Text = ""
        Txt_HallDesc.Text = ""
        Txt_MinCapacity.Text = ""
        Txt_MaxCapacity.Text = ""
        Txt_ActCapacity.Text = ""
        Txt_SecDeposit.Text = ""
        Cbo_HRentOveride.Text = "No"
        Cbo_OSFoodAllow.Text = "No"
        Txt_NonStandRate.Text = ""
        Txt_NonStandRateWEnd.Text = ""
        Chk_FullDay.Checked = False
        Chk_HalfDay.Checked = False
        Chk_TimeSlot.Checked = False
        Grp_Cancel.Visible = False
        Txt_FullDayRate.Text = ""
        Txt_HalfDayRate.Text = ""
        Txt_HalfDayHourRate.Text = ""
        sSGrid_TimeSlot.ClearRange(1, 1, -1, -1, True)
        sSGrid_TimeSlot.SetActiveCell(1, 1)
        sSGrid_Can.ClearRange(1, 1, -1, -1, True)
        sSGrid_Can.SetActiveCell(1, 1)
        Dtp_BookFromTime.Text = "00:00:00"
        Dtp_BookToTime.Text = "00:00:00"
        Txt_HallChargeCode.Text = ""
        Txt_MKChargeCode.Text = ""
        Txt_MGAmount.Text = ""
        Txt_MGChargeCode.Text = ""
        Cbo_AdvanceApp.Text = "No"
        Me.CmdAdd.Text = "Add[F7]"
        Txt_HallCode.Focus()
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 732
        K = 1016
        Me.ResizeRedraw = True

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        If U = 800 Then
            T = T - 20
        End If
        If U = 1280 Then
            T = T - 20
        End If
        If U = 1360 Then
            T = T - 55
        End If
        If U = 1366 Then
            T = T - 55
        End If
        If U = 1908 Then
            T = T - 65
        End If
        Me.Width = U
        Me.Height = T


        With Me
            For i_i = 0 To .Controls.Count - 1
                ' MsgBox(Controls(i_i).Name)
                If TypeOf .Controls(i_i) Is Form Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0
                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If
                ElseIf TypeOf .Controls(i_i) Is Panel Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "Panel" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                            If U = 1908 Then
                                L = L + 100
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is GroupBox Then

                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "GroupBox4" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 45
                            End If
                            If U = 1280 Then
                                L = L + 45
                            End If
                            If U = 1360 Then
                                L = L + 70
                            End If
                            If U = 1366 Then
                                L = L + 70
                            End If
                            If U = 1908 Then
                                L = L + 90
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If

                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is Label Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is TextBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is ComboBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is DateTimePicker Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is PictureBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is CheckBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is TabControl Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is Button Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "Cmd_Clear" Or Controls(i_i).Name = "Cmd_Add" Or Controls(i_i).Name = "Cmd_Delete" Or Controls(i_i).Name = "Cmd_View" Or Controls(i_i).Name = "Cmd_Print" Or Controls(i_i).Name = "Cmd_Export" Or Controls(i_i).Name = "Cmd_Exit" Or Controls(i_i).Name = "Cmd_PendingBill" Or Controls(i_i).Name = "Cmd_Bill" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                            If U = 1908 Then
                                L = L + 100
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                        'L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                End If
            Next i_i
        End With
    End Sub

    Private Sub Cmdview_Click(sender As Object, e As EventArgs) Handles Cmdview.Click

    End Sub

    Private Sub Cmdbwse_Click(sender As Object, e As EventArgs) Handles Cmdbwse.Click
        Dim OBJ1 As New VIEWHDR
        Dim ChildSql As String
        sqlstring = "SELECT HallTypeCode,HallTypeDesc,MinCapacity,MaxCapacity,ActCapacity,Book_FromTime,Book_ToTime FROM PARTY_HALLMASTER_HDR "
        ChildSql = "SELECT HallTypeCode,PCode,PDesc,SessionType,Rate,TimeInterval FROM Party_Hallmaster_det"
        GConnection.getDataSet(sqlstring, "Hall_HDR")
        OBJ1.LOADGRID(gdataset.Tables("Hall_HDR"), True, "FRM_M_HallMaster", ChildSql, "HallTypeCode", 1)
        OBJ1.Show()
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Dim INSERT(0) As String
        If Mid(Cmd_Freeze.Text, 1, 1) = "F" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            sqlstring = "SELECT * FROM PARTY_HALLMASTER_HDR WHERE HallTypeCode='" & Trim(Txt_HallCode.Text) & "' "
            GConnection.getDataSet(sqlstring, "VIEW")
            If gdataset.Tables("VIEW").Rows.Count > 0 Then
                sqlstring = "UPDATE PARTY_HALLMASTER_HDR SET FREEZE='Y',adduser='" & Trim(gUsername) & "',adddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' WHERE HallTypeCode='" & Trim(Txt_HallCode.Text) & "' "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring

                sqlstring = "UPDATE PARTY_HALLMASTER_DET SET FREEZE='Y',adduser='" & Trim(gUsername) & "',adddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "'  WHERE HallTypeCode='" & Trim(Txt_HallCode.Text) & "' "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring

                sqlstring = "UPDATE PARTY_CANCELLATIONMASTER SET FREEZE='Y',adduser='" & Trim(gUsername) & "',adddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "'  WHERE HallCode='" & Trim(Txt_HallCode.Text) & "' "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring

                GConnection.MORETRANS(INSERT)
                Call CmdClear_Click(sender, e)
            End If
        ElseIf Mid(Cmd_Freeze.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE PARTY_HALLMASTER_HDR SET FREEZE='N',adduser='" & Trim(gUsername) & "',adddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' WHERE HallTypeCode='" & Trim(Txt_HallCode.Text) & "' "
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            sqlstring = "UPDATE PARTY_HALLMASTER_DET SET FREEZE='N',adduser='" & Trim(gUsername) & "',adddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "'  WHERE HallTypeCode='" & Trim(Txt_HallCode.Text) & "' "
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            sqlstring = "UPDATE PARTY_CANCELLATIONMASTER SET FREEZE='N',adduser='" & Trim(gUsername) & "',adddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "'  WHERE HallCode='" & Trim(Txt_HallCode.Text) & "' "
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            GConnection.MORETRANS(INSERT)
            Call CmdClear_Click(sender, e)
        End If
    End Sub

    Private Sub Cmd_CanSetting_Click(sender As Object, e As EventArgs) Handles Cmd_CanSetting.Click
        If Trim(Txt_HallCode.Text) <> "" Then
            Grp_Cancel.Visible = True
        End If
    End Sub

    Private Sub Cmd_ok_Click(sender As Object, e As EventArgs) Handles Cmd_ok.Click
        Grp_Cancel.Visible = False
        Txt_MKChargeCode.Focus()
    End Sub

    Private Sub Txt_MGChargeCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_MGChargeCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_MGChargeCode.Text) <> "" Then
                Txt_MGChargeCode_Validated(sender, e)
            Else
                Cmd_MGChargeCodeHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Cmd_MGChargeCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_MGChargeCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "SELECT CHARGECODE,CHARGEDESC FROM CHARGEMASTER"
            If Trim(Search) = " " Then
                M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
            Else
                M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
            End If
            vform.Field = "CHARGECODE,CHARGEDESC"
            vform.vCaption = "Charge Master Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_MGChargeCode.Text = Trim(vform.keyfield & "")
                Txt_MGChargeCode_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txt_MGChargeCode_Validated(sender As Object, e As EventArgs) Handles Txt_MGChargeCode.Validated
        Try
            sqlstring = "SELECT CHARGECODE,CHARGEDESC FROM CHARGEMASTER WHERE ISNULL(FREEZE,'') <> 'Y' AND ISNULL(CHARGECODE,'') = '" & Trim(Txt_MGChargeCode.Text) & "'"
            GConnection.getDataSet(sqlstring, "ChargeCode")
            If gdataset.Tables("ChargeCode").Rows.Count > 0 Then
                Txt_MGChargeCode.Text = gdataset.Tables("ChargeCode").Rows(0).Item(0)
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class