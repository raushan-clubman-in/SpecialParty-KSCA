Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports System.IO
Public Class Frm_T_HallClosingTime
    Dim SSQL As String
    Dim GCONNECTION As New GlobalClass
    Dim gconn As New GlobalClass
    Dim DT As New DataTable
    Dim GrdRate, GrdAmount, GrdTaxAmt As Double
    Dim boolchk, booldatechk As Boolean
    Dim sqlstring As String

    Private Sub Frm_T_HallClosingTime_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub Frm_T_HallClosingTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Call LocationFill()
        'Call Auto_BookingNo()
        CMBBOOKINGTYPE.SelectedIndex = 0

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()

        Dtp_PartyDate.Value = Format(serverdate, "dd/MM/yyyy")
        Dtp_BookingDate.Value = Format(serverdate, "dd/MM/yyyy")
    End Sub
    Private Function LocationFill()
        Try
            Dim I As Integer
            Cmb_Location.Items.Clear()
            SQLSTRING = "SELECT DISTINCT LOCCODE FROM PARTY_LOCATIONMASTER WHERE ISNULL(LOCCODE,'')<>''"
            GCONNECTION.getDataSet(SQLSTRING, "PARTY_LOCATIONMASTER")
            If gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count > 0 Then
                For I = 0 To gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count - 1
                    Cmb_Location.Items.Add(gdataset.Tables("PARTY_LOCATIONMASTER").Rows(I).Item("loccode"))
                Next
                Cmb_Location.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Category Fill " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Private Sub Auto_BookingNo()
        SSQL = "SELECT ISNULL(MAX(isnull(BOOKINGNO,0)),0)+1 AS BOOKINGNO FROM  PARTY_HALLBOOKING_DET WHERE LOCCODE='" & Trim(Cmb_Location.Text) & "'"
        DT = GCONNECTION.GetValues(SSQL)
        If DT.Rows.Count > 0 Then
            Txt_BookingNo.Text = DT.Rows(0).Item(0)
        Else
            Cmb_Location.SelectedIndex = 0
            Txt_BookingNo.Text = 0
        End If
    End Sub
    Private Sub Txt_BookingNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_BookingNo.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            SQLSTRING = "SELECT * FROM Party_Hallbooking_Hdr WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
            GCONNECTION.getDataSet(SQLSTRING, "HallStatus")
            If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                Txt_BookingNo_Validated(sender, e)
                Dtp_PartyDate.Focus()
            Else
                Dtp_PartyDate.Focus()
            End If
        End If
    End Sub
    Private Sub Dtp_PartyDate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Dtp_PartyDate.KeyPress
        Dim i As Integer
        If Asc(e.KeyChar) = 13 Then
            If Dtp_PartyDate.Value < serverdate Then
                MessageBox.Show("Party Date Should Not Less Then Server Date", MyCompanyName)
                Dtp_PartyDate.Focus()
            Else
                Txt_Purpose.Focus()
            End If
            If sSGrid_HallReserv.DataRowCnt > 0 Then
                For i = 1 To sSGrid_HallReserv.DataRowCnt
                    sSGrid_HallReserv.Row = i
                    sSGrid_HallReserv.Col = 6
                    sSGrid_HallReserv.Text = Format(Dtp_PartyDate.Value, "dd/MM/yy")
                Next
            End If
        End If
    End Sub
    Private Sub Dtp_PartyDate_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_PartyDate.ValueChanged
        Lbl_PartyDay.Text = Format(Dtp_PartyDate.Value, "ddddd")
    End Sub

    Private Sub Txt_Purpose_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Purpose.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Purpose.Text) <> "" Then
                Txt_MemberCode.Focus()
            Else
                Txt_Purpose.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_MemberCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_MemberCode.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(Txt_MemberCode.Text) <> "" Then
                    Call Txt_MemberCode_Validated(Txt_MemberCode, e)
                Else
                    Call Cmd_MCodeHelp_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_MCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_MCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "Select Mcode,Mname From MemberMaster "
            If Trim(Search) = " " Then
                M_WhereCondition = " WHERE curentstatus in ('ACTIVE','LIVE')"
            Else
                M_WhereCondition = " WHERE curentstatus in ('ACTIVE','LIVE')"
            End If
            vform.Field = "Mcode,Mname"
            vform.vCaption = "Member Master Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_MemberCode.Text = Trim(vform.keyfield & "")
                Txt_MemberCode.Select()
                Txt_MemberCode_Validated(sender, e)
                Txt_GuestName.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Txt_MemberCode_Validated(sender As Object, e As EventArgs) Handles Txt_MemberCode.Validated
        Try
            If Trim(Txt_MemberCode.Text) <> "" Then
                Txt_MemberName.ReadOnly = False
                Txt_MemberName.Enabled = True
                SQLSTRING = "Select isnull(mcode,'') as mcode,isnull(mname,'') as mname,isnull(curentstatus,'') as termination,CONTADD1,CONTADD2,CONTCITY+' '+CONTPIN as city, CONTEMAIL,CONTCELL  From MemberMaster Where Mcode='" & Trim(Txt_MemberCode.Text) & "' AND  CURENTSTATUS IN ('LIVE','ACTIVE') "
                GCONNECTION.getDataSet(SQLSTRING, "MemberMaster")
                If gdataset.Tables("MemberMaster").Rows.Count > 0 Then
                    Txt_MemberName.Text = ""
                    Txt_MemberName.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("Mname"))
                    If Trim(Txt_GuestName.Text) = "" Then
                    Else
                        Txt_GuestName.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("Mname"))
                    End If
                    Txt_Email.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("CONTEMAIL"))
                    Txt_CellNo.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("CONTCELL"))
                    Txt_MemberName.ReadOnly = True
                    Txt_GuestName.Focus()
                Else
                    Txt_MemberCode.Clear()
                    Txt_MemberName.Clear()
                    Txt_MemberCode.Focus()
                End If
            Else
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txt_GuestName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_GuestName.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_GuestName.Text) <> "" Then
                Txt_NVPax.Focus()
            Else
                Txt_GuestName.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_NVPax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_NVPax.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_NVPax.Text) < 0 Then
                Txt_NVPax.Focus()
            Else
                Txt_TotPax.Text = Val(Txt_NVPax.Text) + Val(Txt_VPax.Text)
                Txt_VPax.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_NVPax_LostFocus(sender As Object, e As EventArgs) Handles Txt_NVPax.LostFocus
        Txt_TotPax.Text = Val(Txt_NVPax.Text) + Val(Txt_VPax.Text)
    End Sub
    Private Sub Txt_VPax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_VPax.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_VPax.Text) < 0 Then
                Txt_VPax.Focus()
            Else
                Txt_TotPax.Text = Val(Txt_NVPax.Text) + Val(Txt_VPax.Text)
                sSGrid_HallReserv.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_VPax_LostFocus(sender As Object, e As EventArgs) Handles Txt_VPax.LostFocus
        Txt_TotPax.Text = Val(Txt_NVPax.Text) + Val(Txt_VPax.Text)
    End Sub
    Private Sub sSGrid_HallReserv_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles sSGrid_HallReserv.KeyDownEvent
        Dim PDATE As String
        Dim ITEMCODE, Hallcode, PCode, WeekDay, FromTime, ToTime, ClsTime As String
        Dim d1, d2, Fromdate, ToDate As Date
        Dim TAXAMOUNT, perc, taxpercent, ARate, halltotalamount, dbldicountAmount, TimeInt As Double
        Dim ftime, CNT, i, HALLTAXAMOUNT, DDiff As Integer
        Dim time1, time2 As DateTime
        Try
            WeekDay = Dtp_PartyDate.Value.DayOfWeek.ToString
            If e.keyCode = Keys.Enter Then
                With sSGrid_HallReserv
                    i = .ActiveRow
                    If .ActiveCol = 1 Then
                        .Col = 1
                        .Row = .ActiveRow
                        If Trim(.Text) = "" Then
                            'Call FillHallDetails()
                        Else
                            .Col = 1
                            Hallcode = Trim(.Text)
                            'Call FillHallDetails_Code(Hallcode)
                        End If
                    ElseIf .ActiveCol = 4 Then
                        .Col = 1
                        Hallcode = Trim(.Text)
                        .Col = 15
                        PCode = Trim(.Text)
                        .Col = 4
                        FromTime = .Text
                        sqlstring = "SELECT * FROM PARTY_HALLMASTER_HDR WHERE HALLTYPECODE = '" & Trim(Hallcode) & "' AND  '" & Format(CDate(FromTime), "HH:mm") & "' BETWEEN Book_FromTime and Book_ToTime"
                        GCONNECTION.getDataSet(sqlstring, "TimeCheck")
                        If gdataset.Tables("TimeCheck").Rows.Count = 0 Then
                            MessageBox.Show("Booking is Not Available For this Time Plz Check Hall Master Booking From and To Time", MyCompanyName)
                            .SetActiveCell(3, .ActiveRow)
                            .Text = ""
                            Exit Sub
                        End If
                        TimeInt = GCONNECTION.getvalue("SELECT TimeInterval FROM PARTY_VIEW_HALLMASTER Where halltypecode = '" & Trim(Hallcode) & "' and pcode = '" & Trim(PCode) & "'")
                        ToTime = GCONNECTION.getvalue("SELECT DATEADD(HOUR," & TimeInt & ",'" & FromTime & "') AS TIMEVAL")
                        .Col = 5
                        .Text = Format(CDate(ToTime), "HH:mm")
                        .Col = 6
                        .Text = Format(CDate(Dtp_PartyDate.Value), "dd/MM/yy")
                        .Col = 7
                        .Text = Format(CDate(Dtp_PartyDate.Value), "dd/MM/yy")

                        Call Check_Status(.ActiveRow)

                        .SetActiveCell(6, .ActiveRow)
                    ElseIf .ActiveCol = 7 Then
                        .Col = 7
                        If .Text = "" Then
                            .Col = 7
                            .Text = Format(CDate(Dtp_PartyDate.Value), "dd/MM/yy")
                        End If
                        .Col = 6
                        Fromdate = CDate(.Text)
                        .Col = 7
                        ToDate = CDate(.Text)
                        .Col = 1
                        Hallcode = Trim(.Text)
                        .Col = 4
                        FromTime = .Text
                        .Col = 5
                        ToTime = .Text
                    ElseIf .ActiveCol = 8 Then
                        .Col = 4
                        FromTime = .Text
                        .Col = 5
                        ToTime = .Text
                        .Col = 8
                        ClsTime = .Text
                        TimeInt = GCONNECTION.getvalue("SELECT DateDiff(HOUR,'" & ToTime & "','" & ClsTime & "') AS TIMEVAL")
                        If Mid(UCase(Trim(gCompName)), 1, 3) = "BRC" Then
                            If TimeInt < 0 Then
                                TimeInt = 0
                            End If
                        Else
                            If TimeInt < 0 Then
                                TimeInt = 24 + TimeInt
                            End If
                        End If
                        .Col = 9
                        .Text = Val(TimeInt)
                    End If
                End With
            End If
            If e.keyCode = Keys.F3 Then
                With sSGrid_HallReserv
                    .Row = .ActiveRow
                    .DeleteRows(.ActiveRow, 1)
                    If .ActiveRow <= 1 Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(1, .ActiveRow - 1)
                    End If
                End With
            End If
            Call Calculate()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Check_Status(Po As Integer)
        Dim HCode, FTime, TTime As String
        Dim FDate, TDate As DateTime
        With sSGrid_HallReserv
            .Row = Po
            .Col = 1
            HCode = Trim(.Text)
            .Col = 4
            FTime = .Text
            .Col = 5
            TTime = .Text
            .Col = 6
            FDate = CDate(.Text)
            .Col = 7
            TDate = CDate(.Text)

            SSQL = "SELECT BOOKINGNO,PARTYDATE,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS"
            SSQL = SSQL & " WHERE  (('" & Format(Dtp_PartyDate.Value, "yyyy-MM-dd") & "' BETWEEN cast(convert(varchar(11),PARTYDATE,106)as datetime) AND cast(convert(varchar(11),PARTYTODATE,106)as datetime)) "
            SSQL = SSQL & "  Or ('" & Format(TDate, "yyyy-MM-dd") & "' BETWEEN cast(convert(varchar(11),PARTYDATE,106)as datetime) AND cast(convert(varchar(11),PARTYTODATE,106)as datetime))) "
            SSQL = SSQL & " AND '" & (FTime) & "' BETWEEN FROMTIME AND TOTIME  AND HALLCODE='" & HCode & "' And Bookingno<>" & Txt_BookingNo.Text
            DT = GCONNECTION.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                MessageBox.Show("ALREAD BOOKED,PLEASE CHECK THE HALLSTATUS", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.CmdAdd.Enabled = False
            Else
                SSQL = "SELECT BOOKINGNO,PARTYDATE,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS"
                SSQL = SSQL & " WHERE (('" & Format(Dtp_PartyDate.Value, "yyyy-MM-dd") & "' BETWEEN cast(convert(varchar(11),PARTYDATE,106)as datetime) AND cast(convert(varchar(11),PARTYTODATE,106)as datetime)) "
                SSQL = SSQL & "  Or ('" & Format(TDate, "yyyy-MM-dd") & "' BETWEEN cast(convert(varchar(11),PARTYDATE,106)as datetime) AND cast(convert(varchar(11),PARTYTODATE,106)as datetime))) "
                SSQL = SSQL & " AND '" & (TTime) & "' BETWEEN FROMTIME AND TOTIME  AND HALLCODE='" & HCode & "' And Bookingno<>" & Txt_BookingNo.Text
                DT = GCONNECTION.GetValues(SSQL)
                If DT.Rows.Count > 0 Then
                    MessageBox.Show("ALREAD BOOKED,PLEASE CHECK THE HALLSTATUS", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.CmdAdd.Enabled = False
                End If
            End If
            SSQL = "select * from Party_Trn_HallBlocking WHERE Trans_Date Between '" & Format(Dtp_PartyDate.Value, "dd-MMM-yyyy") & "' and '" & Format(TDate, "dd-MMM-yyyy") & "' And BlockType = 'B'"
            DT = GCONNECTION.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                MessageBox.Show("Hall is Blocked this Between Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.CmdAdd.Enabled = False
            End If
        End With
    End Sub
    Private Sub Calculate()
        'Dim qty, taxperc, cancel, kotstatus, rate, varposcode As String
        'Dim total, Taxamount, cancelamt, canceltax, Billamount, Packingamt, TIPSAMT, ARate As Double
        'Dim i, DDiff As Integer
        'Dim d1, d2, Fromdate, ToDate As Date
        'With sSGrid_HallReserv
        '    For i = 1 To .DataRowCnt
        '        sSGrid_HallReserv.Row = i
        '        kotstatus = ""
        '        If Trim(kotstatus) = "No" Or Trim(kotstatus) = "" Then
        '            .Col = 6
        '            Fromdate = CDate(.Text)
        '            .Col = 7
        '            ToDate = CDate(.Text)
        '            DDiff = DateDiff(DateInterval.Day, Fromdate, ToDate) + 1
        '            .Col = 13
        '            ARate = Val(.Text)
        '            .SetText(8, i, ARate * DDiff)
        '        End If
        '    Next i
        'End With
        'i = i - 1
        'Call CheckBillAmt()
    End Sub
    'Private Sub CheckBillAmt()
    '    Dim j, Qty As Integer
    '    Dim TotAmt, TotTaxAmt, TotBillAmt As Double
    '    Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
    '    Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
    '    Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, ITEMCODE As String
    '    Dim TPercent As Double
    '    Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, TotCharges As Double
    '    GrdAmount = 0
    '    For i = 1 To sSGrid_HallReserv.DataRowCnt
    '        With sSGrid_HallReserv
    '            .Col = 8
    '            .Row = i
    '            GrdAmount = GrdAmount + Val(.Text)
    '        End With
    '    Next
    '    For i = 1 To sSGrid_HallReserv.DataRowCnt
    '        Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
    '        GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
    '        With sSGrid_HallReserv
    '            .Col = 8
    '            .Row = i
    '            GrdRate = Val(.Text)
    '            Qty = 1
    '            .Col = 9
    '            .Row = i
    '            ChargeCode = Trim(.Text)
    '            SQLSTRING = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
    '            GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
    '            If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
    '                ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
    '            End If
    '            SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
    '            GCONNECTION.getDataSet(SQLSTRING, "TAXON")
    '            If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
    '                For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
    '                    If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
    '                        Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GZero = GZero + Zero
    '                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
    '                        ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GZeroA = GZeroA + ZeroA
    '                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
    '                        ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GZeroB = GZeroB + ZeroB
    '                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
    '                        One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GOne = GOne + One
    '                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
    '                        OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GOneA = GOneA + OneA
    '                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
    '                        OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GOneB = GOneB + OneB
    '                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
    '                        Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GTwo = GTwo + Two
    '                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
    '                        TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GTwoA = GTwoA + TwoA
    '                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
    '                        TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GTwoB = GTwoB + TwoB
    '                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
    '                        Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GThree = GThree + Three
    '                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
    '                        ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GThreeA = GThreeA + ThreeA
    '                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
    '                        ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
    '                        GThreeB = GThreeB + ThreeB
    '                    End If
    '                Next
    '                GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
    '            End If
    '            TotAmt = TotAmt + (Val(GrdRate) * Qty)
    '            TotTaxAmt = TotTaxAmt + (Val(GrdTaxAmt) * Qty)
    '            TotBillAmt = TotBillAmt + ((Val(GrdTaxAmt) * Qty) + (Val(GrdRate) * Qty))
    '            .SetText(10, i, (Val(GrdTaxAmt) * Qty))
    '            .SetText(11, i, (Val(GrdTaxAmt) * Qty) + GrdRate)
    '        End With
    '    Next
    '    Txt_Amount.Text = Format(GrdAmount, "0.00")
    '    'GrdAmount = GrdAmount + TotTaxAmt
    '    Txt_TaxAmount.Text = Format(TotTaxAmt, "0.00")
    '    Txt_TotAmount.Text = Format(GrdAmount + TotTaxAmt, "0.00")

    'End Sub
    'Private Sub FillHallDetails()
    '    Dim hallcd, Weekday As String
    '    Try
    '        Weekday = Dtp_PartyDate.Value.DayOfWeek.ToString
    '        Dim vform As New LIST_OPERATION1
    '        gSQLString = " SELECT distinct SessionType,HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,Rate,TAXTYPE,SEDEPOSIT,TimeInterval FROM PARTY_VIEW_HALLMASTER"
    '        If Trim(Search) = "" Then
    '            M_WhereCondition = " WHERE  ISNULL(FREEZE,'')<>'Y' "
    '        Else
    '            M_WhereCondition = " WHERE  ISNULL(FREEZE,'')<>'Y' "
    '        End If
    '        vform.Field = "SessionType,HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,RATE,TAXTYPE"
    '        vform.vCaption = "Hall Details Help"
    '        vform.ShowDialog(Me)
    '        If Trim(vform.keyfield1 & "") <> "" Then
    '            With sSGrid_HallReserv
    '                .Row = .ActiveRow
    '                .Col = 3
    '                .Text = Trim(vform.keyfield & "")
    '                .Col = 1
    '                .Text = Trim(vform.keyfield1)
    '                hallcd = Trim(vform.keyfield1 & "")
    '                .Col = 2
    '                .Text = Trim(vform.keyfield2 & "")
    '                .Col = 8
    '                .Text = Trim(vform.keyfield7 & "")
    '                .Col = 15
    '                .Text = Trim(vform.keyfield3 & "")
    '                .Col = 16
    '                .Text = Trim(vform.keyfield4 & "")
    '                .Col = 9
    '                .Text = Trim(vform.keyfield8 & "")
    '                .Col = 14
    '                .Text = Trim(vform.keyfield10 & "")
    '                .Col = 12
    '                .Text = Trim(vform.keyfield9 & "")
    '                sqlstring = "SELECT ISNULL(RentOverride,'No')as RentOverride FROM PARTY_HALLMASTER_HDR WHERE HALLTYPECODE = '" & Trim(hallcd) & "'"
    '                GCONNECTION.getDataSet(sqlstring, "Overrid")
    '                If Trim(gdataset.Tables("Overrid").Rows(0).Item(0)) = "Yes" Then
    '                    .Col = 13
    '                    .Lock = False
    '                Else
    '                    .Col = 13
    '                    .Lock = True
    '                End If
    '                .Text = Trim(vform.keyfield7 & "")
    '                .SetActiveCell(3, .ActiveRow)
    '            End With
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Private Sub FillHallDetails_Code(HallCode As String)
    '    Dim hallcd, Weekday As String
    '    Try
    '        Weekday = Dtp_PartyDate.Value.DayOfWeek.ToString
    '        Dim vform As New LIST_OPERATION1
    '        gSQLString = " SELECT distinct SessionType,HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,Rate,TAXTYPE,SEDEPOSIT,TimeInterval FROM PARTY_VIEW_HALLMASTER"
    '        If Trim(Search) = "" Then
    '            M_WhereCondition = " WHERE  ISNULL(FREEZE,'')<>'Y' And HALLTYPECODE = '" & Trim(HallCode) & "'"
    '        Else
    '            M_WhereCondition = " WHERE  ISNULL(FREEZE,'')<>'Y' And HALLTYPECODE = '" & Trim(HallCode) & "'"
    '        End If
    '        vform.Field = "SessionType,HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,RATE,TAXTYPE"
    '        vform.vCaption = "Hall Details Help"
    '        vform.ShowDialog(Me)
    '        If Trim(vform.keyfield1 & "") <> "" Then
    '            With sSGrid_HallReserv
    '                .Row = .ActiveRow
    '                .Col = 3
    '                .Text = Trim(vform.keyfield & "")
    '                .Col = 1
    '                .Text = Trim(vform.keyfield1)
    '                hallcd = Trim(vform.keyfield1 & "")
    '                .Col = 2
    '                .Text = Trim(vform.keyfield2 & "")
    '                .Col = 8
    '                .Text = Trim(vform.keyfield7 & "")
    '                .Col = 15
    '                .Text = Trim(vform.keyfield3 & "")
    '                .Col = 16
    '                .Text = Trim(vform.keyfield4 & "")
    '                .Col = 9
    '                .Text = Trim(vform.keyfield8 & "")
    '                .Col = 14
    '                .Text = Trim(vform.keyfield10 & "")
    '                .Col = 12
    '                .Text = Trim(vform.keyfield9 & "")
    '                sqlstring = "SELECT ISNULL(RentOverride,'No')as RentOverride FROM PARTY_HALLMASTER_HDR WHERE HALLTYPECODE = '" & Trim(hallcd) & "'"
    '                GCONNECTION.getDataSet(sqlstring, "Overrid")
    '                If Trim(gdataset.Tables("Overrid").Rows(0).Item(0)) = "Yes" Then
    '                    .Col = 13
    '                    .Lock = False
    '                Else
    '                    .Col = 13
    '                    .Lock = True
    '                End If
    '                .Text = Trim(vform.keyfield7 & "")
    '                .SetActiveCell(3, .ActiveRow)
    '            End With
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim strsql, halltype, insert(0), HALLCODE, PCODE, FTIME, TTIME, CLSTIME As String
        Dim i, j, Ex_Hours As Integer
        Try
            Call Calculate()
            If Trim(Txt_BookingNo.Text) <> "" Then
                sqlstring = "SELECT * FROM PARTY_ACC_POST  where bookingno=" & Txt_BookingNo.Text & " AND ISNULL(POSTFLAG,'')='Y' "
                GCONNECTION.getDataSet(sqlstring, "accpost")
                If gdataset.Tables("accpost").Rows.Count > 0 Then
                    MessageBox.Show("ALREADY ACCOUNT POSTING WAS DONE,YOU CANNOT UPDATE THE BILL ", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
                sqlstring = "SELECT ISNULL(BILLINGFLAG,'') AS BILLINGFLAG FROM party_hallbooking_hdr  where bookingno=" & Txt_BookingNo.Text & " "
                GCONNECTION.getDataSet(sqlstring, "BillCheck")
                If gdataset.Tables("BillCheck").Rows.Count > 0 Then
                    If gdataset.Tables("BillCheck").Rows(0).Item("BILLINGFLAG") = "Y" Then
                        MessageBox.Show("BILLING WAS DONE,YOU CANNOT UPDATE", MyCompanyName, MessageBoxButtons.OK)
                        Exit Sub
                    End If
                End If
            End If

            If Mid(CmdAdd.Text, 1, 1) = "A" Then

            ElseIf Mid(CmdAdd.Text, 1, 1) = "U" Then
                Call checkValidation()
                If boolchk = False Then Exit Sub
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Freezed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                    boolchk = False
                End If
                insert(0) = " SELECT * FROM PARTY_HALLBOOKING_HDR WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "'"
                With sSGrid_HallReserv
                    If .DataRowCnt > 0 Then
                        For i = 1 To .DataRowCnt
                            .Row = i
                            .Col = 8
                            CLSTIME = .Text
                            .Col = 9
                            Ex_Hours = Val(.Text)
                            .Col = 1
                            HALLCODE = Trim(.Text)
                            .Col = 10
                            PCODE = Trim(.Text)
                            sqlstring = "Update PARTY_HALLBOOKING_DET SET CLSTIME = '" & CLSTIME & "',Extra_Hour = " & Ex_Hours & " WHERE HALLCODE = '" & HALLCODE & "' AND HALLTYPE = '" & PCODE & "' AND BOOKINGNO = '" & Txt_BookingNo.Text & "'"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = sqlstring
                        Next
                    End If
                End With

                GCONNECTION.MoreTransold(insert)
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
            D1 = Format(Dtp_PartyDate.Value, "dd/MM/yyyy")
            d2 = Format(Dtp_BookingDate.Value, "dd/MM/yyyy")

            SSQL = "SELECT ISNULL(LOCCODE,'')AS LOCCODE FROM party_locationmaster"
            gconnection.getDataSet(ssql, "LOC")
            If gdataset.Tables("LOC").Rows.Count > 0 Then
                Loc = Trim(gdataset.Tables("LOC").Rows(0).Item("LOCCODE"))
            End If
            boolchk = True

        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Datevalidation()
        Try
            'sqlstring = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
            'GCONNECTION.getDataSet(sqlstring, "SERVERDATE")
            'If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then
            '    If CDate(Format(Dtp_BookingDate.Value, "yyyy/MMM/dd")) < CDate(Format(gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE"), "yyyy/MMM/dd")) Then
            '        MsgBox("Booking Date should be Greaterthan or equal to Server System Date.......", MsgBoxStyle.OkOnly, "Date Validation")
            '        Dtp_BookingDate.Value = gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE")
            '        Exit Sub
            '    End If
            '    If CDate(Format(gFinancialyearEnding, "yyyy/MMM/dd")) < CDate(Format(Dtp_BookingDate.Value, "yyyy/MMM/dd")) Then
            '        Dtp_BookingDate.Value = Format("dd/MM/yyyy", Now())
            '    End If
            '    If CDate(Format(Dtp_BookingDate.Value, "yyyy/MMM/dd")) > CDate(Format(Dtp_PartyDate.Value, "yyyy/MMM/dd")) Then
            '        MsgBox("Booking Date Should be Less than party Date.......", MsgBoxStyle.OkOnly, "Date Validation")
            '        Dtp_BookingDate.Value = Format("dd/MM/yyyy", Now())
            '        Exit Sub
            '    End If
            'End If
            If CDate(Format(Dtp_BookingDate.Value, "yyyy/MMM/dd")) < CDate(Format(serverdate, "yyyy/MMM/dd")) Then
                MsgBox("Booking Date should be Greater than closing Date.......", MsgBoxStyle.OkOnly, "Date Validation")
                Dtp_BookingDate.Value = serverdate
                booldatechk = False
                Exit Sub
            End If
            If CDate(Format(gFinancialyearEnding, "yyyy/MMM/dd")) < CDate(Format(Dtp_BookingDate.Value, "yyyy/MMM/dd")) Then
                Dtp_BookingDate.Value = Format("dd/MM/yyyy", serverdate)
                booldatechk = False
                Exit Sub
            End If
            If CDate(Format(Dtp_BookingDate.Value, "yyyy/MMM/dd")) > CDate(Format(Dtp_PartyDate.Value, "yyyy/MMM/dd")) Then
                MsgBox("Party Date Should be greater or equal to Booking Date.......", MsgBoxStyle.OkOnly, "Date Validation")
                Dtp_BookingDate.Value = Format("dd/MM/yyyy", serverdate)
                booldatechk = False
                Exit Sub
            End If
        Catch
            MsgBox("Error in date view..." & Err.Description)
        End Try
    End Sub

    Private Sub Txt_BookingNo_Validated(sender As Object, e As EventArgs) Handles Txt_BookingNo.Validated
        Dim Fre As String
        Dim Others As Double
        Try
            If Trim(Txt_BookingNo.Text) <> "" Then
                sqlstring = "select * from Party_Hallbooking_Hdr WHERE BOOKINGNO=" & Txt_BookingNo.Text & " "
                GCONNECTION.getDataSet(sqlstring, "HallHdr")
                If gdataset.Tables("HallHdr").Rows.Count > 0 Then
                    Dtp_BookingDate.Value = Format(gdataset.Tables("HallHdr").Rows(0).Item("BOOKINGDATE"), "dd/MM/yyyy HH:mm:ss")
                    Dtp_PartyDate.Value = Format(gdataset.Tables("HallHdr").Rows(0).Item("PARTYDATE"), "dd/MM/yyyy HH:mm:ss")
                    Txt_Purpose.Text = gdataset.Tables("HallHdr").Rows(0).Item("DESCRIPTION")
                    Txt_MemberCode.Text = gdataset.Tables("HallHdr").Rows(0).Item("MCODE")
                    Txt_MemberName.Text = gdataset.Tables("HallHdr").Rows(0).Item("ASSOCIATENAME")
                    Txt_GuestName.Text = gdataset.Tables("HallHdr").Rows(0).Item("GUESTNAME")
                    Txt_TotPax.Text = Val(gdataset.Tables("HallHdr").Rows(0).Item("OCCUPANCY"))
                    Txt_VPax.Text = Val(gdataset.Tables("HallHdr").Rows(0).Item("VEG"))
                    Txt_NVPax.Text = Val(gdataset.Tables("HallHdr").Rows(0).Item("NONVEG"))
                    Txt_CellNo.Text = gdataset.Tables("HallHdr").Rows(0).Item("CELLNO")
                    Txt_Email.Text = gdataset.Tables("HallHdr").Rows(0).Item("EMAIL")
                    ''Details
                    sqlstring = "Select ISNULL(CLSTIME,TOTIME) AS CLSTIME,ISNULL(Extra_Hour,0) AS Extra_Hour,* from Party_Hallbooking_Det WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                    DT = GCONNECTION.GetValues(sqlstring)
                    If DT.Rows.Count > 0 Then
                        sSGrid_HallReserv.ClearRange(-1, -1, 1, 1, True)
                        With sSGrid_HallReserv
                            For i = 0 To DT.Rows.Count - 1
                                .Row = i + 1
                                .Col = 1
                                .Text = DT.Rows(i).Item("HALLCODE")
                                .Col = 2
                                .Text = DT.Rows(i).Item("HallDesc")
                                .Col = 3
                                .Text = DT.Rows(i).Item("SessionType")
                                .Col = 4
                                .Text = DT.Rows(i).Item("FROMTIME")
                                .Col = 5
                                .Text = DT.Rows(i).Item("TOTIME")
                                .Col = 6
                                .Text = Format(DT.Rows(i).Item("PARTYDATE"), "dd/MM/yy")
                                .Col = 7
                                .Text = Format(DT.Rows(i).Item("PartyToDate"), "dd/MM/yy")
                                .Col = 8
                                .Text = DT.Rows(i).Item("CLSTIME")
                                .Col = 9
                                .Text = Val(DT.Rows(i).Item("Extra_Hour"))
                                .Col = 10
                                .Text = DT.Rows(i).Item("HALLTYPE")
                                .Col = 11
                                .Text = DT.Rows(i).Item("PDesc")
                            Next
                        End With
                    End If
                    If gdataset.Tables("HallStatus").Rows(0).Item("FREEZE") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "This Booking is Freezed on :" & Format(CDate(gdataset.Tables("HallStatus").Rows(0).Item("ADDDATETIME")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "THIS BOOKING IS CANCELLED ON :"
                        Me.Cmd_Freeze.Text = "Freeze[F8]"
                    End If
                    Me.CmdAdd.Text = "Update[F7]"
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    Me.Txt_BookingNo.ReadOnly = True
                Else
                    MessageBox.Show("No Booking Found, Plz Check", MyCompanyName)
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

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        Me.Txt_BookingNo.ReadOnly = False
        Txt_BookingNo.Text = ""
        Dtp_PartyDate.Value = Format(serverdate, "dd/MM/yyyy")
        Dtp_BookingDate.Value = Format(serverdate, "dd/MM/yyyy")
        Txt_Purpose.Text = ""
        Txt_MemberCode.Text = ""
        Txt_MemberName.Text = ""
        Txt_TotPax.Text = ""
        Txt_GuestName.Text = ""
        Txt_CellNo.Text = ""
        Txt_Email.Text = ""
        Txt_VPax.Text = ""
        Txt_NVPax.Text = ""
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.Enabled = True
        sSGrid_HallReserv.ClearRange(-1, -1, 1, 1, True)
        sSGrid_HallReserv.SetActiveCell(1, 1)
        TabControl1.SelectedIndex = 0
        'Call Auto_BookingNo()
        Txt_BookingNo.Focus()
    End Sub

    Private Sub Hall_Avail_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Receipt_Details_Click(sender As Object, e As EventArgs)
        ''sSGrid_Receipt.ClearRange(-1, -1, 1, 1, True)
        ''sSGrid_Receipt.Col = 1
        ''sSGrid_Receipt.Row = 1
        ''sSGrid_Receipt.Text = "PAR/000001/15-16"
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 2 Then
            Call Receipt_Details_Click(sender, e)
        ElseIf TabControl1.SelectedIndex = 1 Then
            'Call Hall_Status()
        End If
    End Sub

    Private Sub Cmd_BookingNoHelp_Click(sender As Object, e As EventArgs) Handles Cmd_BookingNoHelp.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "Select BOOKINGNO,MCODE,GUESTNAME,PARTYDATE from Party_Hallbooking_Hdr"
            If Trim(Search) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " "
            End If
            vform.Field = "BOOKINGNO,MCODE,GUESTNAME,PARTYDATE"
            vform.vCaption = "Booking Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_BookingNo.Text = Trim(vform.keyfield & "")
                Txt_BookingNo_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click

    End Sub

    Private Sub Cmdbwse_Click(sender As Object, e As EventArgs) Handles Cmdbwse.Click
        'Dim OBJ1 As New VIEWHDR
        'Dim ChildSql As String
        'sqlstring = "SELECT BOOKINGNO,HallDesc,PDesc,PARTYDATE,PartyToDate,FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET ORDER BY BOOKINGNO "
        'ChildSql = ""
        'GCONNECTION.getDataSet(sqlstring, "PARTY_HALLBOOKING_DET")
        'OBJ1.LOADGRID(gdataset.Tables("PARTY_HALLBOOKING_DET"), False, "FRM_T_HallRervation", ChildSql, "BOOKINGNO", 0)
        'OBJ1.Show()
    End Sub

    Private Sub Cmdview_Click(sender As Object, e As EventArgs) Handles Cmdview.Click
        Dim i, j, K As Integer
        Dim sql1 As String
        Dim hallamt, rcamt As Double
        Dim Viewer As New ReportViwer
        Dim r1 As New Cry_HallRervation
        Dim dt As New DataTable
        Dim BOOKNO As Integer
        sqlstring = "SELECT * FROM View_HallReservation Where bookingno=" & Txt_BookingNo.Text & ""
        GCONNECTION.getDataSet(sqlstring, "View_HallReservation")
        If gdataset.Tables("View_HallReservation").Rows.Count > 0 Then
            Viewer.Report = r1
            Call Viewer.GetDetails1(sqlstring, "View_HallReservation", r1)

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text9")
            TXTOBJ5.Text = MyCompanyName

            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text12")
            TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Viewer.Show()
        Else
            MsgBox("No Recored to Display  ", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub
    Private Sub Txt_Email_LostFocus(sender As Object, e As EventArgs) Handles Txt_Email.LostFocus
        If Txt_Email.Text <> "" Then
            getEmail(Txt_Email)
        End If
    End Sub

    Private Sub Txt_TotPax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_TotPax.KeyPress
        getNumeric(e)
    End Sub

    Private Sub Txt_CellNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_CellNo.KeyPress
        getNumeric(e)
    End Sub
End Class