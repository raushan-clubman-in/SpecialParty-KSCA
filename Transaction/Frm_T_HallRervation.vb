Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports System.IO
Public Class Frm_T_HallRervation
    Dim SSQL As String
    Dim GCONNECTION As New GlobalClass
    Dim gconn As New GlobalClass
    Dim DT As New DataTable
    Dim GrdRate, GrdAmount, GrdTaxAmt As Double
    Dim boolchk, booldatechk, Dup As Boolean
    Dim sqlstring As String
    Dim TarrifType, SubMenuCode, DocType As String
    Dim InsertBook(0), InsertRec(0) As String

    Private Sub Frm_T_HallRervation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub Frm_T_HallRervation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Call LocationFill()
        Call Auto_BookingNo()
        CMBBOOKINGTYPE.SelectedIndex = 0
        Cbo_TypeofMenu.SelectedIndex = 0

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()

        Dtp_PartyDate.Value = Format(serverdate, "dd/MM/yyyy")
        Dtp_BookingDate.Value = Format(serverdate, "dd/MM/yyyy")

        If Mid(UCase(Trim(gCompName)), 1, 4) = "FNCC" Then
            Dtp_BookingDate.Enabled = True
        End If
        For i = 1 To 4
            Call GridPayment(i)
        Next
        '----GUEST GSTIN NO
        Txt_GGstN.Visible = False
        lbl_GGstNo.Visible = False
        '----GUEST GSTIN NO
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
        Dim PENDINGAMOUNT, BOOKINGNO, CRE, DEB, CreditYN, MainCode As String
        Dim CrLimit As Double

        Try
            If Trim(Txt_MemberCode.Text) <> "" Then

                If Mid(gCompName, 1, 4) = "KSCA" Then
                    sqlstring = "SELECT A.BOOKINGNO,(sum(HALLAMT+FOOD+BREV))-(sum(DEPAMT+SETT)) as amount  FROM Party_Abstract A,Party_Hallbooking_Hdr H WHERE A.BOOKINGNO = H.BOOKINGNO  and a.MCODE='" + Txt_MemberCode.Text + "' GROUP BY A.BOOKINGNO,A.PARTYDATE,A.MCODE,H.ASSOCIATENAME"
                    GCONNECTION.getDataSet(sqlstring, "GBal")
                    If gdataset.Tables("GBal").Rows.Count > 0 Then
                        BOOKINGNO = Trim(gdataset.Tables("GBal").Rows(0).Item("BOOKINGNO"))

                        CRE = Trim(gdataset.Tables("GBal").Rows(0).Item("amount"))
                    End If
                Else
                End If
                Txt_MemberName.ReadOnly = False
                Txt_MemberName.Enabled = True
                If CRE > 0 Then

                    MessageBox.Show("Previous Party Amount Is Not Fully Settled Against BookingNo:- " & BOOKINGNO & "  and Amount:-" & CRE & " ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    sqlstring = "Select isnull(mcode,'') as mcode,isnull(mname,'') as mname,isnull(curentstatus,'') as termination,CONTADD1,CONTADD2,CONTCITY+' '+CONTPIN as city, CONTEMAIL,CONTCELL  From MemberMaster Where Mcode='" & Trim(Txt_MemberCode.Text) & "' AND  CURENTSTATUS IN ('LIVE','ACTIVE') "
                    GCONNECTION.getDataSet(sqlstring, "MemberMaster")
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
                End If


                'sqlstring = "SELECT ISNULL(Creditlimit,0) AS Creditlimit,ISNULL(creditlimityn,'N') AS creditlimityn FROM SUBCATEGORYMASTER WHERE SUBTYPECODE IN (SELECT MEMBERTYPECODE FROM MEMBERMASTER WHERE MCODE = '" & Trim(Txt_MemberCode.Text) & "')"
                'GCONNECTION.getDataSet(sqlstring, "CRLIMIT")
                'If gdataset.Tables("CRLIMIT").Rows.Count > 0 Then
                '    CrLimit = gdataset.Tables("CRLIMIT").Rows(0).Item(0)
                '    CreditYN = gdataset.Tables("CRLIMIT").Rows(0).Item(1)
                'Else
                '    CrLimit = 0
                '    CreditYN = "N"
                'End If
                'sqlstring = "SELECT ISNULL(MEMLIMIT,0) AS MEMLIMIT FROM MEMBERMASTER WHERE MCODE = '" & Trim(Txt_MemberCode.Text) & "'"
                'GCONNECTION.getDataSet(sqlstring, "CRLIMIT1")
                'If gdataset.Tables("CRLIMIT1").Rows.Count > 0 Then
                '    If Val(gdataset.Tables("CRLIMIT1").Rows(0).Item(0)) > 0 Then
                '        CrLimit = gdataset.Tables("CRLIMIT1").Rows(0).Item(0)
                '        CreditYN = "Y"
                '    End If
                'End If
                'If CreditYN = "Y" Then
                '    sqlstring = "SELECT  ISNULL(MCode,'') AS Mcode FROM MEMBERMASTER Where MCODE ='" & Trim(Txt_MemberCode.Text) & "'"
                '    GCONNECTION.getDataSet(sqlstring, "MEMBERMASTER")
                '    If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                '        MainCode = gdataset.Tables("MEMBERMASTER").Rows(0).Item("Mcode")
                '        sqlstring = "SELECT SLCODE,ISNULL(SUM(DEB),0)-ISNULL(SUM(CRE),0) AS CLS FROM Get_CreditBal WHERE SLCODE = '" & Trim(MainCode) & "' GROUP BY SLCODE ORDER BY SLCODE"
                '        GCONNECTION.getDataSet(sqlstring, "CLSAMT")
                '        If gdataset.Tables("CLSAMT").Rows.Count > 0 Then
                '            CrLimit = CrLimit - gdataset.Tables("CLSAMT").Rows(0).Item("CLS")
                '            'Otst = gdataset.Tables("CLSAMT").Rows(0).Item("CLS")
                '        Else
                '            'Otst = 0
                '            'CrLimitAmt = 0
                '        End If
                '    End If
                '    If CrLimit < 0 Then
                '        MsgBox("CREDIT BALANCE NOT AVAILABLE", MsgBoxStyle.Critical)
                '        Txt_MemberCode.Clear()
                '        Txt_MemberName.Clear()
                '        Txt_MemberCode.Focus()
                '    End If
                'End If
                
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
                If Val(Txt_NVPax.Text) > 0 Then
                    Cmd_NVMenuCodeHelp.Enabled = True
                    Txt_NVMenuCode.Enabled = True
                Else
                    Cmd_NVMenuCodeHelp.Enabled = False
                    Txt_NVMenuCode.Enabled = False
                End If
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
                If Val(Txt_VPax.Text) > 0 Then
                    Cmd_VMenuCodeHelp.Enabled = True
                    Txt_VMenuCode.Enabled = True
                Else
                    Cmd_VMenuCodeHelp.Enabled = False
                    Txt_VMenuCode.Enabled = False
                End If
                sSGrid_HallReserv.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_VPax_LostFocus(sender As Object, e As EventArgs) Handles Txt_VPax.LostFocus
        Txt_TotPax.Text = Val(Txt_NVPax.Text) + Val(Txt_VPax.Text)
    End Sub
    Private Sub sSGrid_HallReserv_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles sSGrid_HallReserv.KeyDownEvent
        Dim PDATE As String
        Dim ITEMCODE, Hallcode, PCode, WeekDay, FromTime, ToTime As String
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
                            Call FillHallDetails()
                        Else
                            .Col = 1
                            Hallcode = Trim(.Text)
                            Call FillHallDetails_Code(Hallcode)
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
                        If ToDate < Fromdate Then
                            MessageBox.Show("To Date Can't Be Less From Date", MyCompanyName)
                            .SetActiveCell(6, .ActiveRow)
                        Else
                            Call Check_Status(.ActiveRow)
                            DDiff = DateDiff(DateInterval.Day, Fromdate, ToDate) + 1
                            .Col = 13
                            ARate = Val(.Text)
                            .Col = 8
                            .Text = ARate * DDiff
                            .SetActiveCell(0, .ActiveRow + 1)
                        End If
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
        Dim qty, taxperc, cancel, kotstatus, rate, varposcode As String
        Dim total, Taxamount, cancelamt, canceltax, Billamount, Packingamt, TIPSAMT, ARate As Double
        Dim i, DDiff As Integer
        Dim d1, d2, Fromdate, ToDate As Date
        With sSGrid_HallReserv
            For i = 1 To .DataRowCnt
                sSGrid_HallReserv.Row = i
                kotstatus = ""
                If Trim(kotstatus) = "No" Or Trim(kotstatus) = "" Then
                    .Col = 6
                    Fromdate = CDate(.Text)
                    .Col = 7
                    ToDate = CDate(.Text)
                    DDiff = DateDiff(DateInterval.Day, Fromdate, ToDate) + 1
                    .Col = 13
                    ARate = Val(.Text)
                    .SetText(8, i, ARate * DDiff)
                End If
            Next i
        End With
        i = i - 1
        Call CheckTaxCode()
        Call CheckBillAmt()
    End Sub
    Private Sub CheckTaxCode()
        Dim TaxC, HCodeC As String
        Dim HRate As Double

        With sSGrid_HallReserv
            For i = 1 To .DataRowCnt
                .Row = i
                .Col = 1
                HCodeC = Trim(.Text)
                .Row = i
                .Col = 13
                HRate = Val(.Text)
                sqlstring = "SELECT ISNULL(ChargeCode,'') As ChargeCode FROM Party_RateMaster WHERE HallCode = '" & HCodeC & "' AND " & HRate & " BETWEEN FromSlab and ToSlab AND '" & Format(Dtp_PartyDate.Value, "dd-MMM-yyyy") & "' BETWEEN FromDate AND ToDate And ISNULL(Freeze,'') <> 'Y'"
                GCONNECTION.getDataSet(sqlstring, "CheckTax")
                If gdataset.Tables("CheckTax").Rows.Count > 0 Then
                    TaxC = gdataset.Tables("CheckTax").Rows(0).Item(0)
                    .SetText(9, i, TaxC)
                Else
                    sqlstring = "SELECT ISNULL(TAXTYPE,'') As ChargeCode FROM Party_Hallmaster_Hdr WHERE HallTypeCode = '" & HCodeC & "' "
                    GCONNECTION.getDataSet(sqlstring, "CheckTax1")
                    If gdataset.Tables("CheckTax1").Rows.Count > 0 Then
                        TaxC = gdataset.Tables("CheckTax1").Rows(0).Item(0)
                        .SetText(9, i, TaxC)
                    End If
                End If
            Next
        End With
    End Sub
    Private Sub CheckBillAmt()
        Dim j, Qty As Integer
        Dim TotAmt, TotTaxAmt, TotBillAmt As Double
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, ITEMCODE As String
        Dim TPercent As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, TotCharges As Double
        GrdAmount = 0
        For i = 1 To sSGrid_HallReserv.DataRowCnt
            With sSGrid_HallReserv
                .Col = 8
                .Row = i
                GrdAmount = GrdAmount + Val(.Text)
            End With
        Next
        For i = 1 To sSGrid_HallReserv.DataRowCnt
            Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
            GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
            With sSGrid_HallReserv
                .Col = 8
                .Row = i
                GrdRate = Val(.Text)
                Qty = 1
                .Col = 9
                .Row = i
                ChargeCode = Trim(.Text)
                SQLSTRING = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
                If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                    ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                End If
                SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                GCONNECTION.getDataSet(SQLSTRING, "TAXON")
                If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                    For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                        If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                            Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZero = GZero + Zero
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                            ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroA = GZeroA + ZeroA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                            ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroB = GZeroB + ZeroB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                            One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOne = GOne + One
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                            OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneA = GOneA + OneA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                            OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneB = GOneB + OneB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                            Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwo = GTwo + Two
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                            TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoA = GTwoA + TwoA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                            TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoB = GTwoB + TwoB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                            Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThree = GThree + Three
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                            ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeA = GThreeA + ThreeA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                            ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeB = GThreeB + ThreeB
                        End If
                    Next
                    GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                End If
                TotAmt = TotAmt + (Val(GrdRate) * Qty)
                TotTaxAmt = TotTaxAmt + (Val(GrdTaxAmt) * Qty)
                TotBillAmt = TotBillAmt + ((Val(GrdTaxAmt) * Qty) + (Val(GrdRate) * Qty))
                .SetText(10, i, (Val(GrdTaxAmt) * Qty))
                .SetText(11, i, (Val(GrdTaxAmt) * Qty) + GrdRate)
            End With
        Next
        Txt_Amount.Text = Format(GrdAmount, "0.00")
        'GrdAmount = GrdAmount + TotTaxAmt
        Txt_TaxAmount.Text = Format(TotTaxAmt, "0.00")
        Txt_TotAmount.Text = Format(GrdAmount + TotTaxAmt, "0.00")

    End Sub
    Private Sub FillHallDetails()
        Dim hallcd, Weekday As String
        Try
            Weekday = Dtp_PartyDate.Value.DayOfWeek.ToString
            Dim vform As New LIST_OPERATION1
            gSQLString = " SELECT distinct SessionType,HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,Rate,TAXTYPE,SEDEPOSIT,TimeInterval FROM PARTY_VIEW_HALLMASTER"
            If Trim(Search) = "" Then
                M_WhereCondition = " WHERE  ISNULL(FREEZE,'')<>'Y' "
            Else
                M_WhereCondition = " WHERE  ISNULL(FREEZE,'')<>'Y' "
            End If
            vform.Field = "SessionType,HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,RATE,TAXTYPE"
            vform.vCaption = "Hall Details Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield1 & "") <> "" Then
                With sSGrid_HallReserv
                    .Row = .ActiveRow
                    .Col = 3
                    .Text = Trim(vform.keyfield & "")
                    .Col = 1
                    .Text = Trim(vform.keyfield1)
                    hallcd = Trim(vform.keyfield1 & "")
                    .Col = 2
                    .Text = Trim(vform.keyfield2 & "")
                    .Col = 8
                    .Text = Trim(vform.keyfield7 & "")
                    .Col = 15
                    .Text = Trim(vform.keyfield3 & "")
                    .Col = 16
                    .Text = Trim(vform.keyfield4 & "")
                    .Col = 9
                    .Text = Trim(vform.keyfield8 & "")
                    .Col = 14
                    .Text = Trim(vform.keyfield10 & "")
                    .Col = 12
                    .Text = Trim(vform.keyfield9 & "")
                    sqlstring = "SELECT ISNULL(RentOverride,'No')as RentOverride FROM PARTY_HALLMASTER_HDR WHERE HALLTYPECODE = '" & Trim(hallcd) & "'"
                    GCONNECTION.getDataSet(sqlstring, "Overrid")
                    If Trim(gdataset.Tables("Overrid").Rows(0).Item(0)) = "Yes" Then
                        .Col = 13
                        .Lock = False
                    Else
                        .Col = 13
                        .Lock = True
                    End If
                    .Text = Trim(vform.keyfield7 & "")
                    .SetActiveCell(3, .ActiveRow)
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillHallDetails_Code(HallCode As String)
        Dim hallcd, Weekday As String
        Try
            Weekday = Dtp_PartyDate.Value.DayOfWeek.ToString
            Dim vform As New LIST_OPERATION1
            gSQLString = " SELECT distinct SessionType,HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,Rate,TAXTYPE,SEDEPOSIT,TimeInterval FROM PARTY_VIEW_HALLMASTER"
            If Trim(Search) = "" Then
                M_WhereCondition = " WHERE  ISNULL(FREEZE,'')<>'Y' And HALLTYPECODE = '" & Trim(HallCode) & "'"
            Else
                M_WhereCondition = " WHERE  ISNULL(FREEZE,'')<>'Y' And HALLTYPECODE = '" & Trim(HallCode) & "'"
            End If
            vform.Field = "SessionType,HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,RATE,TAXTYPE"
            vform.vCaption = "Hall Details Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield1 & "") <> "" Then
                With sSGrid_HallReserv
                    .Row = .ActiveRow
                    .Col = 3
                    .Text = Trim(vform.keyfield & "")
                    .Col = 1
                    .Text = Trim(vform.keyfield1)
                    hallcd = Trim(vform.keyfield1 & "")
                    .Col = 2
                    .Text = Trim(vform.keyfield2 & "")
                    .Col = 8
                    .Text = Trim(vform.keyfield7 & "")
                    .Col = 15
                    .Text = Trim(vform.keyfield3 & "")
                    .Col = 16
                    .Text = Trim(vform.keyfield4 & "")
                    .Col = 9
                    .Text = Trim(vform.keyfield8 & "")
                    .Col = 14
                    .Text = Trim(vform.keyfield10 & "")
                    .Col = 12
                    .Text = Trim(vform.keyfield9 & "")
                    sqlstring = "SELECT ISNULL(RentOverride,'No')as RentOverride FROM PARTY_HALLMASTER_HDR WHERE HALLTYPECODE = '" & Trim(hallcd) & "'"
                    GCONNECTION.getDataSet(sqlstring, "Overrid")
                    If Trim(gdataset.Tables("Overrid").Rows(0).Item(0)) = "Yes" Then
                        .Col = 13
                        .Lock = False
                    Else
                        .Col = 13
                        .Lock = True
                    End If
                    .Text = Trim(vform.keyfield7 & "")
                    .SetActiveCell(3, .ActiveRow)
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim strsql, halltype, insert(0), HALLCODE, PCODE, FTIME, TTIME As String
        Dim i, j As Integer
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, Pos, KStatus, M_Keep As String
        Dim Qty As Integer
        Dim TPercent, RoomPer, PartyPer As Double
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
                If Mid(Me.CmdAdd.Text, 1, 1) = "U" And CMBBOOKINGTYPE.Text = "CANCEL" Then
                    MessageBox.Show(" This Booking is Cancelled Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf Mid(Me.CmdAdd.Text, 1, 1) = "U" And CMBBOOKINGTYPE.Text = "BOOKING" Then
                    SSQL = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' and Isnull(BILLINGFLAG,'')='Y'"
                    DT = GCONNECTION.GetValues(SSQL)
                    If DT.Rows.Count > 0 Then
                        MessageBox.Show("  Billing Over, can't be Updated", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                ElseIf Mid(Me.CmdAdd.Text, 1, 1) = "U" And CMBBOOKINGTYPE.Text = "BILLING" Then
                    SSQL = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' and Isnull(bookingflag,'')<>'Y'"
                    DT = GCONNECTION.GetValues(SSQL)
                    If DT.Rows.Count > 0 Then
                        MessageBox.Show(" Booking is Not Completed,can't be Inserted", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Else
                    SSQL = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' and Isnull(cancelflag,'')='Y'"
                    DT = GCONNECTION.GetValues(SSQL)
                    If DT.Rows.Count > 0 Then
                        MessageBox.Show(" This Booking is Cancelled Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            End If
            If Mid(CmdAdd.Text, 1, 1) = "A" Then
                Call Auto_BookingNo()
                Call checkValidation()
                If boolchk = False Then Exit Sub
                CmdAdd.Enabled = False
                sqlstring = "Insert Into Party_Hallbooking_Hdr(LOCCODE,BOOKINGNO,PARTYDATE,BOOKINGDATE,MCODE,ASSOCIATENAME,DESCRIPTION,OCCUPANCY,VEG,NONVEG,DISCOUNTAMT,"
                sqlstring = sqlstring & "TOTALAMOUNT,HallTaxAmount,HALLNETAMOUNT,DISCOUNT,GUESTNAME,CELLNO,EMAIL,FREEZE,ADDUSERID,ADDDATETIME,Menu_Type)"
                sqlstring = sqlstring & " Values('" & Trim(Cmb_Location.Text) & "'," & Trim(Txt_BookingNo.Text) & ",'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                sqlstring = sqlstring & "'" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy HH:mm:ss") & "','" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_Purpose.Text) & "',"
                sqlstring = sqlstring & "" & Val(Txt_TotPax.Text) & "," & Val(Txt_VPax.Text) & "," & Val(Txt_NVPax.Text) & ",0," & Val(Txt_Amount.Text) & "," & Val(Txt_TaxAmount.Text) & "," & Val(Txt_TotAmount.Text) & ",0,"
                sqlstring = sqlstring & "'" & Trim(Txt_GuestName.Text) & "','" & Trim(Txt_CellNo.Text) & "','" & Trim(Txt_Email.Text) & "','N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','" & Trim(Cbo_TypeofMenu.Text) & "')"
                insert(0) = sqlstring
                With sSGrid_HallReserv
                    If .DataRowCnt > 0 Then
                        For i = 1 To .DataRowCnt
                            .Row = i
                            sqlstring = "Insert Into Party_Hallbooking_Det(LOCCODE,BOOKINGNO,PARTYDATE,PartyToDate,HALLCODE,HallDesc,HALLTYPE,PDesc,SessionType,FROMTIME,TOTIME,"
                            sqlstring = sqlstring & "HALLAMOUNT,HALLTAXAMOUNT,HALLNETAMOUNT,SECURITYDEPOSIT,ChargeCode,Act_Hallcgs,M_Keeper,FREEZE,ADDUSERID,ADDDATETIME)"
                            sqlstring = sqlstring & " Values('" & Trim(Cmb_Location.Text) & "'," & Trim(Txt_BookingNo.Text) & ",'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy") & "',"
                            .Col = 7
                            sqlstring = sqlstring & "'" & Format(CDate(.Text), "dd/MMM/yyyy") & "',"
                            .Col = 1
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 2
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 15
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 16
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 3
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 4
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 5
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 8
                            sqlstring = sqlstring & "" & Val(.Text) & ","
                            .Col = 10
                            sqlstring = sqlstring & "" & Val(.Text) & ","
                            .Col = 11
                            sqlstring = sqlstring & "" & Val(.Text) & ","
                            .Col = 12
                            sqlstring = sqlstring & "" & Val(.Text) & ","
                            .Col = 9
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 13
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 17
                            If Trim(.Text) = "No" Or Trim(.Text) = "" Then
                                sqlstring = sqlstring & "'No',"
                            Else
                                sqlstring = sqlstring & "'Yes',"
                            End If
                            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "')"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = sqlstring
                        Next
                    End If
                End With
                For i = 1 To sSGrid_HallReserv.DataRowCnt
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    With sSGrid_HallReserv
                        .Col = 1
                        .Row = i
                        HALLCODE = Trim(.Text)
                        .Col = 15
                        .Row = i
                        PCODE = Trim(.Text)
                        .Col = 8
                        .Row = i
                        GrdRate = .Text
                        Qty = 1
                        .Col = 4
                        .Row = i
                        FTIME = Trim(.Text)
                        .Col = 5
                        .Row = i
                        TTIME = Trim(.Text)
                        .Col = 9
                        .Row = i
                        ChargeCode = Trim(.Text)
                        sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(sqlstring, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                                Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                                strsql = "Insert Into Party_HallBooking_Det_Tax(BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,CHARGECODE,HALLTAXCODE,HALLTAXON,HALLRATE,HALLTAXPERC,HALLTAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME,M_Keeper) VALUES ( "
                                strsql = strsql & "'" & Trim(Txt_BookingNo.Text) & "','" & Trim(HALLCODE) & "','" & Trim(PCODE) & "','" & Format(Dtp_PartyDate.Value, "dd-MMM-yyyy") & "','" & Trim(FTIME) & "','" & Trim(TTIME) & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (GrdRate) & "," & (TPercent) & ","

                                If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                    Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    strsql = strsql & "" & Val(Zero) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    strsql = strsql & "" & Val(ZeroA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    strsql = strsql & "" & Val(ZeroB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                    One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    strsql = strsql & "" & Val(One) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    strsql = strsql & "" & Val(OneA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    strsql = strsql & "" & Val(OneB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                    Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    strsql = strsql & "" & Val(Two) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    strsql = strsql & "" & Val(TwoA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    strsql = strsql & "" & Val(TwoB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                    Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    strsql = strsql & "" & Val(Three) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    strsql = strsql & "" & Val(ThreeA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    strsql = strsql & "" & Val(ThreeB) * Qty & ","
                                End If
                                strsql = strsql & "'N','" & Trim(gUsername) & "',getdate(),'No')"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = strsql
                            Next
                        End If
                    End With
                Next
                '-- M Keeper Tax Applicable
                For i = 1 To sSGrid_HallReserv.DataRowCnt
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    With sSGrid_HallReserv
                        .Col = 17
                        .Row = i
                        If Trim(.Text) = "" Then
                            M_Keep = "No"
                        Else
                            M_Keep = Trim(.Text)
                        End If
                        If M_Keep = "Yes" Then
                            .Col = 1
                            .Row = i
                            HALLCODE = Trim(.Text)
                            .Col = 15
                            .Row = i
                            PCODE = Trim(.Text)
                            .Col = 8
                            .Row = i
                            GrdRate = .Text
                            Qty = 1
                            .Col = 4
                            .Row = i
                            FTIME = Trim(.Text)
                            .Col = 5
                            .Row = i
                            TTIME = Trim(.Text)
                            .Col = 17
                            .Row = i
                            If Trim(.Text) = "" Then
                                M_Keep = "No"
                            Else
                                M_Keep = Trim(.Text)
                            End If
                            ChargeCode = GCONNECTION.getvalue("SELECT MKTaxType FROM Party_Hallmaster_hdr WHERE HallTypeCode = '" & Trim(HALLCODE) & "'")
                            sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                            GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                            If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                                ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                            End If
                            sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                            GCONNECTION.getDataSet(sqlstring, "TAXON")
                            If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                                For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                    IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                                    Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                                    Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                                    TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                                    strsql = "Insert Into Party_HallBooking_Det_Tax(BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,CHARGECODE,HALLTAXCODE,HALLTAXON,HALLRATE,HALLTAXPERC,HALLTAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME,M_Keeper) VALUES ( "
                                    strsql = strsql & "'" & Trim(Txt_BookingNo.Text) & "','" & Trim(HALLCODE) & "','" & Trim(PCODE) & "','" & Format(Dtp_PartyDate.Value, "dd-MMM-yyyy") & "','" & Trim(FTIME) & "','" & Trim(TTIME) & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (GrdRate) & "," & (TPercent) & ","

                                    If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                        Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GZero = GZero + Zero
                                        strsql = strsql & "" & Val(Zero) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                        ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GZeroA = GZeroA + ZeroA
                                        strsql = strsql & "" & Val(ZeroA) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                        ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GZeroB = GZeroB + ZeroB
                                        strsql = strsql & "" & Val(ZeroB) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                        One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GOne = GOne + One
                                        strsql = strsql & "" & Val(One) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                        OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GOneA = GOneA + OneA
                                        strsql = strsql & "" & Val(OneA) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                        OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GOneB = GOneB + OneB
                                        strsql = strsql & "" & Val(OneB) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                        Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GTwo = GTwo + Two
                                        strsql = strsql & "" & Val(Two) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                        TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GTwoA = GTwoA + TwoA
                                        strsql = strsql & "" & Val(TwoA) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                        TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GTwoB = GTwoB + TwoB
                                        strsql = strsql & "" & Val(TwoB) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                        Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GThree = GThree + Three
                                        strsql = strsql & "" & Val(Three) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                        ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GThreeA = GThreeA + ThreeA
                                        strsql = strsql & "" & Val(ThreeA) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                        ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GThreeB = GThreeB + ThreeB
                                        strsql = strsql & "" & Val(ThreeB) * Qty & ","
                                    End If
                                    strsql = strsql & "'N','" & Trim(gUsername) & "',getdate(),'" & Trim(M_Keep) & "')"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = strsql
                                Next
                            End If
                        End If
                    End With
                Next

                sqlstring = "UPDATE party_hallbooking_hdr SET MEMBERTYPE = MEMBERTYPECODE FROM MEMBERMASTER M,party_hallbooking_hdr H WHERE M.MCODE = H.MCODE AND H.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                sqlstring = "UPDATE party_hallbooking_det SET HALLTAXAMOUNT = (SELECT SUM(ISNULL(party_hallbooking_DET_TAX.HALLTAXAMOUNT,0)) FROM party_hallbooking_DET_TAX  WHERE party_hallbooking_DET_TAX.BOOKINGNO = party_hallbooking_det.BOOKINGNO AND party_hallbooking_DET_TAX.HALLCODE=party_hallbooking_det.HALLCODE AND party_hallbooking_DET_TAX.HALLTYPE = party_hallbooking_det.HALLTYPE group by BOOKINGNO,HALLCODE,HALLTYPE) WHERE party_hallbooking_det.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                sqlstring = "UPDATE party_hallbooking_det SET HALLNETAMOUNT = HALLAMOUNT + HALLTAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                sqlstring = "UPDATE party_hallbooking_hdr SET TOTALAMOUNT  = (SELECT SUM(ISNULL(party_hallbooking_det.HALLAMOUNT,0)) FROM party_hallbooking_det WHERE party_hallbooking_det.BOOKINGNO =party_hallbooking_hdr.BOOKINGNO group by BOOKINGNO) WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                sqlstring = "UPDATE party_hallbooking_hdr SET HALLTAXAMOUNT  = (SELECT SUM(ISNULL(party_hallbooking_det.HALLTAXAMOUNT,0)) FROM party_hallbooking_det  WHERE party_hallbooking_det.BOOKINGNO = party_hallbooking_hdr.BOOKINGNO group by BOOKINGNO) WHERE BOOKINGNO ='" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                sqlstring = "UPDATE party_hallbooking_hdr SET HALLNETAMOUNT = TOTALAMOUNT + HALLTAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                sqlstring = "Update PARTY_HALLBOOKING_DET SET CLSTIME = TOTIME,Extra_Hour = 0 WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                '---------------------GUEST GSTIN NUMBER
                If Txt_GGstN.Visible = True Then
                    sqlstring = "Update party_hallbooking_hdr SET GGSTINNO = '" & Trim(Txt_GGstN.Text) & "' WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                End If
                '---------------------GUEST GSTIN NUMBER

                Call BookingDetAdd()
                For i = 0 To InsertBook.Length - 1
                    If InsertBook(i) Is Nothing = False Then
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = InsertBook(i)
                    End If
                Next

                GCONNECTION.MoreTransold(insert)
                Call BookingRecAdd()
                If sSGrid_Rec.DataRowCnt > 0 Then
                    If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                        gPrint = True
                        With sSGrid_Rec
                            For i = 1 To .DataRowCnt
                                .Row = i
                                .Col = 3
                                Call RECEIT_KSCA(Trim(.Text))
                            Next
                        End With
                    End If
                End If
                Call CmdClear_Click(sender, e)

            ElseIf Mid(CmdAdd.Text, 1, 1) = "U" Then
                Call checkValidation()
                If boolchk = False Then Exit Sub
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Freezed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                    boolchk = False
                End If
                sqlstring = "Update Party_Hallbooking_Hdr Set PartyDate = '" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',MCODE = '" & Trim(Txt_MemberCode.Text) & "',"
                sqlstring = sqlstring & "ASSOCIATENAME = '" & Trim(Txt_MemberName.Text) & "',DESCRIPTION = '" & Trim(Txt_Purpose.Text) & "',OCCUPANCY = " & Val(Txt_TotPax.Text) & ","
                sqlstring = sqlstring & "VEG = " & Val(Txt_VPax.Text) & ",NONVEG = " & Val(Txt_NVPax.Text) & ",GUESTNAME = '" & Trim(Txt_GuestName.Text) & "',CELLNO = '" & Trim(Txt_CellNo.Text) & "',Menu_Type= '" & Trim(Cbo_TypeofMenu.Text) & "',"
                sqlstring = sqlstring & "EMAIL = '" & Trim(Txt_Email.Text) & "',TOTALAMOUNT = " & Val(Txt_Amount.Text) & ",HallTaxAmount = " & Val(Txt_TaxAmount.Text) & ",HALLNETAMOUNT = " & Val(Txt_TotAmount.Text) & ","
                sqlstring = sqlstring & "UpdUserID = '" & Trim(gUsername) & "',UpdDateTime = Getdate() Where BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' And LOCCODE = '" & Trim(Cmb_Location.Text) & "'"
                insert(0) = sqlstring
                With sSGrid_HallReserv
                    If .DataRowCnt > 0 Then

                        sqlstring = "Delete From Party_Hallbooking_Det Where BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' And LOCCODE = '" & Trim(Cmb_Location.Text) & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring

                        For i = 1 To .DataRowCnt
                            .Row = i
                            sqlstring = "Insert Into Party_Hallbooking_Det(LOCCODE,BOOKINGNO,PARTYDATE,PartyToDate,HALLCODE,HallDesc,HALLTYPE,PDesc,SessionType,FROMTIME,TOTIME,"
                            sqlstring = sqlstring & "HALLAMOUNT,HALLTAXAMOUNT,HALLNETAMOUNT,SECURITYDEPOSIT,ChargeCode,Act_Hallcgs,M_Keeper,FREEZE,ADDUSERID,ADDDATETIME)"
                            sqlstring = sqlstring & " Values('" & Trim(Cmb_Location.Text) & "'," & Trim(Txt_BookingNo.Text) & ",'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy") & "',"
                            .Col = 7
                            sqlstring = sqlstring & "'" & Format(CDate(.Text), "dd/MMM/yyyy") & "',"
                            .Col = 1
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 2
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 15
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 16
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 3
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 4
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 5
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 8
                            sqlstring = sqlstring & "" & Val(.Text) & ","
                            .Col = 10
                            sqlstring = sqlstring & "" & Val(.Text) & ","
                            .Col = 11
                            sqlstring = sqlstring & "" & Val(.Text) & ","
                            .Col = 12
                            sqlstring = sqlstring & "" & Val(.Text) & ","
                            .Col = 9
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 13
                            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                            .Col = 17
                            If Trim(.Text) = "No" Or Trim(.Text) = "" Then
                                sqlstring = sqlstring & "'No',"
                            Else
                                sqlstring = sqlstring & "'Yes',"
                            End If
                            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "')"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = sqlstring
                        Next
                    End If
                End With

                sqlstring = "Delete From Party_HallBooking_Det_Tax Where BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' "
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring

                For i = 1 To sSGrid_HallReserv.DataRowCnt
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    With sSGrid_HallReserv
                        .Col = 1
                        .Row = i
                        HALLCODE = Trim(.Text)
                        .Col = 15
                        .Row = i
                        PCODE = Trim(.Text)
                        .Col = 8
                        .Row = i
                        GrdRate = .Text
                        Qty = 1
                        .Col = 4
                        .Row = i
                        FTIME = Trim(.Text)
                        .Col = 5
                        .Row = i
                        TTIME = Trim(.Text)
                        .Col = 9
                        .Row = i
                        ChargeCode = Trim(.Text)
                        sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(sqlstring, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                                Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                                strsql = "Insert Into Party_HallBooking_Det_Tax(BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,CHARGECODE,HALLTAXCODE,HALLTAXON,HALLRATE,HALLTAXPERC,HALLTAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME,M_Keeper) VALUES ( "
                                strsql = strsql & "'" & Trim(Txt_BookingNo.Text) & "','" & Trim(HALLCODE) & "','" & Trim(PCODE) & "','" & Format(Dtp_PartyDate.Value, "dd-MMM-yyyy") & "','" & Trim(FTIME) & "','" & Trim(TTIME) & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (GrdRate) & "," & (TPercent) & ","

                                If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                    Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    strsql = strsql & "" & Val(Zero) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    strsql = strsql & "" & Val(ZeroA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    strsql = strsql & "" & Val(ZeroB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                    One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    strsql = strsql & "" & Val(One) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    strsql = strsql & "" & Val(OneA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    strsql = strsql & "" & Val(OneB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                    Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    strsql = strsql & "" & Val(Two) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    strsql = strsql & "" & Val(TwoA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    strsql = strsql & "" & Val(TwoB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                    Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    strsql = strsql & "" & Val(Three) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    strsql = strsql & "" & Val(ThreeA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    strsql = strsql & "" & Val(ThreeB) * Qty & ","
                                End If
                                strsql = strsql & "'N','" & Trim(gUsername) & "',getdate(),'No')"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = strsql
                            Next
                        End If
                    End With
                Next
                '-- M Keeper Tax Applicable
                For i = 1 To sSGrid_HallReserv.DataRowCnt
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    With sSGrid_HallReserv
                        .Col = 17
                        .Row = i
                        If Trim(.Text) = "" Then
                            M_Keep = "No"
                        Else
                            M_Keep = Trim(.Text)
                        End If
                        If M_Keep = "Yes" Then
                            .Col = 1
                            .Row = i
                            HALLCODE = Trim(.Text)
                            .Col = 15
                            .Row = i
                            PCODE = Trim(.Text)
                            .Col = 8
                            .Row = i
                            GrdRate = .Text
                            Qty = 1
                            .Col = 4
                            .Row = i
                            FTIME = Trim(.Text)
                            .Col = 5
                            .Row = i
                            TTIME = Trim(.Text)
                            .Col = 17
                            .Row = i
                            If Trim(.Text) = "" Then
                                M_Keep = "No"
                            Else
                                M_Keep = Trim(.Text)
                            End If
                            ChargeCode = GCONNECTION.getvalue("SELECT MKTaxType FROM Party_Hallmaster_hdr WHERE HallTypeCode = '" & Trim(HALLCODE) & "'")
                            sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                            GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                            If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                                ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                            End If
                            sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                            GCONNECTION.getDataSet(sqlstring, "TAXON")
                            If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                                For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                    IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                                    Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                                    Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                                    TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                                    strsql = "Insert Into Party_HallBooking_Det_Tax(BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,CHARGECODE,HALLTAXCODE,HALLTAXON,HALLRATE,HALLTAXPERC,HALLTAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME,M_Keeper) VALUES ( "
                                    strsql = strsql & "'" & Trim(Txt_BookingNo.Text) & "','" & Trim(HALLCODE) & "','" & Trim(PCODE) & "','" & Format(Dtp_PartyDate.Value, "dd-MMM-yyyy") & "','" & Trim(FTIME) & "','" & Trim(TTIME) & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (GrdRate) & "," & (TPercent) & ","

                                    If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                        Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GZero = GZero + Zero
                                        strsql = strsql & "" & Val(Zero) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                        ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GZeroA = GZeroA + ZeroA
                                        strsql = strsql & "" & Val(ZeroA) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                        ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GZeroB = GZeroB + ZeroB
                                        strsql = strsql & "" & Val(ZeroB) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                        One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GOne = GOne + One
                                        strsql = strsql & "" & Val(One) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                        OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GOneA = GOneA + OneA
                                        strsql = strsql & "" & Val(OneA) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                        OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GOneB = GOneB + OneB
                                        strsql = strsql & "" & Val(OneB) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                        Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GTwo = GTwo + Two
                                        strsql = strsql & "" & Val(Two) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                        TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GTwoA = GTwoA + TwoA
                                        strsql = strsql & "" & Val(TwoA) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                        TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GTwoB = GTwoB + TwoB
                                        strsql = strsql & "" & Val(TwoB) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                        Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GThree = GThree + Three
                                        strsql = strsql & "" & Val(Three) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                        ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GThreeA = GThreeA + ThreeA
                                        strsql = strsql & "" & Val(ThreeA) * Qty & ","
                                    ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                        ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                        GThreeB = GThreeB + ThreeB
                                        strsql = strsql & "" & Val(ThreeB) * Qty & ","
                                    End If
                                    strsql = strsql & "'N','" & Trim(gUsername) & "',getdate(),'" & Trim(M_Keep) & "')"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = strsql
                                Next
                            End If
                        End If
                    End With
                Next

                sqlstring = "UPDATE party_hallbooking_hdr SET MEMBERTYPE = MEMBERTYPECODE FROM MEMBERMASTER M,party_hallbooking_hdr H WHERE M.MCODE = H.MCODE AND H.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                sqlstring = "UPDATE party_hallbooking_det SET HALLTAXAMOUNT = (SELECT SUM(ISNULL(party_hallbooking_DET_TAX.HALLTAXAMOUNT,0)) FROM party_hallbooking_DET_TAX  WHERE party_hallbooking_DET_TAX.BOOKINGNO = party_hallbooking_det.BOOKINGNO AND party_hallbooking_DET_TAX.HALLCODE=party_hallbooking_det.HALLCODE AND party_hallbooking_DET_TAX.HALLTYPE = party_hallbooking_det.HALLTYPE group by BOOKINGNO,HALLCODE,HALLTYPE) WHERE party_hallbooking_det.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                sqlstring = "UPDATE party_hallbooking_det SET HALLNETAMOUNT = HALLAMOUNT + HALLTAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                sqlstring = "UPDATE party_hallbooking_hdr SET TOTALAMOUNT  = (SELECT SUM(ISNULL(party_hallbooking_det.HALLAMOUNT,0)) FROM party_hallbooking_det WHERE party_hallbooking_det.BOOKINGNO =party_hallbooking_hdr.BOOKINGNO group by BOOKINGNO) WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                sqlstring = "UPDATE party_hallbooking_hdr SET HALLTAXAMOUNT  = (SELECT SUM(ISNULL(party_hallbooking_det.HALLTAXAMOUNT,0)) FROM party_hallbooking_det  WHERE party_hallbooking_det.BOOKINGNO = party_hallbooking_hdr.BOOKINGNO group by BOOKINGNO) WHERE BOOKINGNO ='" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                sqlstring = "UPDATE party_hallbooking_hdr SET HALLNETAMOUNT = TOTALAMOUNT + HALLTAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                '---------------------GUEST GSTIN NUMBER
                If Txt_GGstN.Visible = True Then
                    sqlstring = "Update party_hallbooking_hdr SET GGSTINNO = '" & Trim(Txt_GGstN.Text) & "' WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                End If
                '---------------------GUEST GSTIN NUMBER
                Call BookingDetAdd()
                For i = 0 To InsertBook.Length - 1
                    If InsertBook(i) Is Nothing = False Then
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = InsertBook(i)
                    End If
                Next
                GCONNECTION.MoreTransold(insert)
                Call BookingRecAdd()
                Call CmdClear_Click(sender, e)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub checkValidation()
        Dim Loc, CreditYN, MainCode As String
        Dim CrLimit As Double
        Try
            boolchk = False
            Dim D1, d2, Fromdate, ToDate As DateTime
            Dim FDAY, TDAY, DAYS, CNT, j, k As Integer
            Dim hlcode, pcode, hlcode1, pcode1, Shlcode As String
            D1 = Format(Dtp_PartyDate.Value, "dd/MM/yyyy")
            d2 = Format(Dtp_BookingDate.Value, "dd/MM/yyyy")

            If Mid(CmdAdd.Text, 1, 1) = "A" Then
                booldatechk = True
                Call Datevalidation()
                If booldatechk = False Then Exit Sub
            End If

            If DateDiff(DateInterval.Day, D1, d2) > 0 Then
                MessageBox.Show("Party Date cannot be Less than To BookingDate", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Dtp_PartyDate.Focus()
                Exit Sub
            End If
            If Trim(Txt_CellNo.Text) = "" Then
                MessageBox.Show("MOBILE NO CAN'T BE BLANK", MyCompanyName, MessageBoxButtons.OK)
                Exit Sub
            End If

            SSQL = "SELECT ISNULL(LOCCODE,'')AS LOCCODE FROM party_locationmaster"
            gconnection.getDataSet(ssql, "LOC")
            If gdataset.Tables("LOC").Rows.Count > 0 Then
                Loc = Trim(gdataset.Tables("LOC").Rows(0).Item("LOCCODE"))
            End If
            If Val(Txt_VPax.Text) < 0 Then
                MessageBox.Show(" Veg Pax's can't be Less Than Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_VPax.Focus()
                Exit Sub
            End If
            If Val(Txt_NVPax.Text) < 0 Then
                MessageBox.Show(" Non Veg Pax's can't be Less Than Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_NVPax.Focus()
                Exit Sub
            End If
            If Val(Txt_TotPax.Text) <= 0 Then
                MessageBox.Show(" Pax's can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_TotPax.Focus()
                Exit Sub
            End If
            If Trim(Txt_Purpose.Text) = "" Then
                MessageBox.Show("Purpose Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If Trim(Txt_MemberCode.Text) = "" Then
                MessageBox.Show(" Member Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_MemberCode.Focus()
                Exit Sub
            End If
            If Trim(Txt_MemberName.Text) = "" Then
                MessageBox.Show(" Member Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_MemberCode.Focus()
                Exit Sub
            End If
            If Trim(Txt_GuestName.Text) = "" Then
                MessageBox.Show(" Guest Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_MemberCode.Focus()
                Exit Sub
            End If
            If Trim(Cbo_TypeofMenu.Text) = "" Then
                MessageBox.Show(" Type of Menu can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cbo_TypeofMenu.Focus()
                Exit Sub
            End If
          
            With sSGrid_HallReserv
                If .DataRowCnt = 0 Then
                    MessageBox.Show("Hall Details Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    sSGrid_HallReserv.SetActiveCell(1, 1)
                    sSGrid_HallReserv.Focus()
                    Exit Sub
                End If

            End With
            Dim MinCap, MaxCap As Double
            With sSGrid_HallReserv
                For CNT = 1 To .DataRowCnt
                    .Col = 1
                    .Row = CNT
                    hlcode = Trim(.Text)
                    If Trim(hlcode) <> "" Then
                        sqlstring = "SELECT MinCapacity,MaxCapacity  FROM PARTY_HALLMASTER_HDR WHERE HALLTYPECODE = '" & Trim(hlcode) & "'"
                        GCONNECTION.getDataSet(sqlstring, "Cap")
                        If gdataset.Tables("Cap").Rows.Count > 0 Then
                            MinCap = MinCap + Val(gdataset.Tables("Cap").Rows(0).Item("MinCapacity"))
                            MaxCap = MaxCap + Val(gdataset.Tables("Cap").Rows(0).Item("MaxCapacity"))
                        End If
                    End If
                Next
            End With
            If Val(Txt_TotPax.Text) < MinCap Then
                MessageBox.Show(" Total Pax is Below Mininum Pax For Regarding Hall given in Hall Reservation Area", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Val(Txt_TotPax.Text) > MaxCap Then
                MessageBox.Show(" Total Pax is Above Maxinum Pax For Regarding Hall given in Hall Reservation Area", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            With sSGrid_HallReserv
                For CNT = 1 To .DataRowCnt
                    .Col = 1
                    .Row = CNT
                    hlcode = Trim(.Text)
                    If Trim(hlcode) = "" Then
                        MessageBox.Show("Hall Code  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .SetActiveCell(1, CNT)
                        .Focus()
                        Exit Sub
                    End If
                    .Col = 15
                    .Row = CNT
                    pcode = Trim(.Text)
                    If Trim(pcode) = "" Then
                        MessageBox.Show("Purpose  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .SetActiveCell(3, CNT)
                        .Focus()
                        Exit Sub
                    End If
                    .Col = 18
                    .Row = CNT
                    Shlcode = Trim(.Text)

                    k = 0
                    For j = 1 To .DataRowCnt
                        .Col = 1
                        .Row = j
                        hlcode1 = Trim(.Text)
                        .Col = 3
                        .Row = j
                        pcode1 = Trim(.Text)
                        If hlcode = hlcode1 And pcode = pcode1 Then
                            k = k + 1
                        End If
                    Next j

                    .Col = 6
                    Fromdate = CDate(.Text)
                    .Col = 7
                    ToDate = CDate(.Text)
                    If ToDate < Fromdate Then
                        MessageBox.Show("To Date Can't Be Less From Date", MyCompanyName)
                        .SetActiveCell(6, CNT)
                        .Focus()
                        Exit Sub
                    End If
                    If Fromdate <> CDate(Dtp_PartyDate.Value) Then
                        MessageBox.Show("From Date Can't Be Less Or More From Party Date", MyCompanyName)
                        .SetActiveCell(6, CNT)
                        .Focus()
                        Exit Sub
                    End If

                    ''sqlstring = "select * from VIEW_PARTY_BOOKINGDETAILS WHERE BOOKINGNO <> " & Val(Txt_BookingNo.Text) & " and "
                    ''If Shlcode <> "" Then
                    ''    sqlstring = sqlstring & " '" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy") & "' BETWEEN PARTYDATE and PARTYTODATE and (HALLCODE='" & hlcode & "')  and "
                    ''Else
                    ''    sqlstring = sqlstring & " '" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy") & "' BETWEEN PARTYDATE and PARTYTODATE and (HALLCODE='" & hlcode & "')  and "
                    ''End If
                    ''sqlstring = sqlstring & " Halltype='" & Trim(pcode) & "' and loccode='" & Trim(Cmb_Location.Text) & "'"
                    ''GCONNECTION.getDataSet(sqlstring, "val")
                    ''If gdataset.Tables("val").Rows.Count > 0 Then
                    ''    sqlstring = "Already this HallCode & Purpose Combination Booked.." & Trim(gdataset.Tables("val").Rows(0).Item("MCODE")) & " " & Trim(gdataset.Tables("val").Rows(0).Item("MNAME")) & " " & Format(gdataset.Tables("val").Rows(0).Item("BOOKINGNO"), "0")
                    ''    MessageBox.Show(sqlstring, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ''.SetActiveCell(1, CNT)
                    ''.Focus()
                    ''Exit Sub
                    ''End If
                    Dim HCode, FTime, TTime As String
                    Dim FDate, TDate As DateTime

                    .Row = CNT
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
                        .SetActiveCell(1, CNT)
                        .Focus()
                        Exit Sub
                    Else
                        SSQL = "SELECT BOOKINGNO,PARTYDATE,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS"
                        SSQL = SSQL & " WHERE (('" & Format(Dtp_PartyDate.Value, "yyyy-MM-dd") & "' BETWEEN cast(convert(varchar(11),PARTYDATE,106)as datetime) AND cast(convert(varchar(11),PARTYTODATE,106)as datetime)) "
                        SSQL = SSQL & "  Or ('" & Format(TDate, "yyyy-MM-dd") & "' BETWEEN cast(convert(varchar(11),PARTYDATE,106)as datetime) AND cast(convert(varchar(11),PARTYTODATE,106)as datetime))) "
                        SSQL = SSQL & " AND '" & (TTime) & "' BETWEEN FROMTIME AND TOTIME  AND HALLCODE='" & HCode & "' And Bookingno<>" & Txt_BookingNo.Text
                        DT = GCONNECTION.GetValues(SSQL)
                        If DT.Rows.Count > 0 Then
                            MessageBox.Show("ALREAD BOOKED,PLEASE CHECK THE HALLSTATUS", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            .SetActiveCell(1, CNT)
                            .Focus()
                            Exit Sub
                        End If
                    End If
                    SSQL = "select * from Party_Trn_HallBlocking WHERE Trans_Date Between '" & Format(Dtp_PartyDate.Value, "dd-MMM-yyyy") & "' and '" & Format(TDate, "dd-MMM-yyyy") & "' And BlockType = 'B'"
                    DT = GCONNECTION.GetValues(SSQL)
                    If DT.Rows.Count > 0 Then
                        MessageBox.Show("Hall is Blocked this Between Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        .SetActiveCell(1, CNT)
                        .Focus()
                        Exit Sub
                    End If

                    If Val(k) > 1 Then
                        MessageBox.Show("Already this HallCode & Purpose Combination Exists..", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .SetActiveCell(1, CNT)
                        .Focus()
                        Exit Sub
                    End If
                Next
            End With
            Dim Pmcode As String
            With sSGrid_Rec
                For i = 1 To .DataRowCnt
                    .Row = i
                    .Col = 1
                    Pmcode = Trim(.Text)
                    If Pmcode <> "" Then
                        .Row = i
                        .Col = 2
                        If Val(.Text) <= 0 Then
                            MessageBox.Show("Advance Amount can't be Zero or Less then Zero", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                Next
            End With

            Dim Code1, Code2 As String
            Dim rowid As Integer
            Dup = True
            For i = 1 To sSGrid_Rec.DataRowCnt
                With sSGrid_Rec
                    .Col = 1
                    .Row = i
                    Code1 = (.Text)
                    rowid = i
                    For j = 1 To sSGrid_Rec.DataRowCnt
                        .Col = 1
                        .Row = j
                        Code2 = (.Text)
                        If Code1 = Code2 And rowid <> j Then
                            MessageBox.Show("Duplicate PaymentMode not allowed in advance")
                            Exit Sub
                        End If
                    Next
                End With
            Next

            ''If Mid(CmdAdd.Text, 1, 1) = "A" Then
            ''    sqlstring = "SELECT ISNULL(Creditlimit,0) AS Creditlimit,ISNULL(creditlimityn,'N') AS creditlimityn FROM SUBCATEGORYMASTER WHERE SUBTYPECODE IN (SELECT MEMBERTYPECODE FROM MEMBERMASTER WHERE MCODE = '" & Trim(Txt_MemberCode.Text) & "')"
            ''    GCONNECTION.getDataSet(sqlstring, "CRLIMIT")
            ''    If gdataset.Tables("CRLIMIT").Rows.Count > 0 Then
            ''        CrLimit = gdataset.Tables("CRLIMIT").Rows(0).Item(0)
            ''        CreditYN = gdataset.Tables("CRLIMIT").Rows(0).Item(1)
            ''    Else
            ''        CrLimit = 0
            ''        CreditYN = "N"
            ''    End If
            ''    sqlstring = "SELECT ISNULL(MEMLIMIT,0) AS MEMLIMIT FROM MEMBERMASTER WHERE MCODE = '" & Trim(Txt_MemberCode.Text) & "'"
            ''    GCONNECTION.getDataSet(sqlstring, "CRLIMIT1")
            ''    If gdataset.Tables("CRLIMIT1").Rows.Count > 0 Then
            ''        If Val(gdataset.Tables("CRLIMIT1").Rows(0).Item(0)) > 0 Then
            ''            CrLimit = gdataset.Tables("CRLIMIT1").Rows(0).Item(0)
            ''            CreditYN = "Y"
            ''        End If
            ''    End If
            ''    If CreditYN = "Y" Then
            ''        sqlstring = "SELECT  ISNULL(MCode,'') AS Mcode FROM MEMBERMASTER Where MCODE ='" & Trim(Txt_MemberCode.Text) & "'"
            ''        GCONNECTION.getDataSet(sqlstring, "MEMBERMASTER")
            ''        If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
            ''            MainCode = gdataset.Tables("MEMBERMASTER").Rows(0).Item("Mcode")
            ''            sqlstring = "SELECT SLCODE,ISNULL(SUM(DEB),0)-ISNULL(SUM(CRE),0) AS CLS FROM Get_CreditBal WHERE SLCODE = '" & Trim(MainCode) & "' GROUP BY SLCODE ORDER BY SLCODE"
            ''            GCONNECTION.getDataSet(sqlstring, "CLSAMT")
            ''            If gdataset.Tables("CLSAMT").Rows.Count > 0 Then
            ''                CrLimit = CrLimit - gdataset.Tables("CLSAMT").Rows(0).Item("CLS")
            ''                'Otst = gdataset.Tables("CLSAMT").Rows(0).Item("CLS")
            ''            Else
            ''                'Otst = 0
            ''                'CrLimitAmt = 0
            ''            End If
            ''        End If
            ''        If CrLimit < Val(Txt_TotAmount.Text) Then
            ''            MsgBox("CREDIT BALANCE NOT AVAILABLE", MsgBoxStyle.Critical)
            ''            Txt_MemberCode.Clear()
            ''            Txt_MemberName.Clear()
            ''            Txt_MemberCode.Focus()
            ''            Exit Sub
            ''        End If
            ''    End If
            ''End If

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
                    Txt_Amount.Text = Format(gdataset.Tables("HallHdr").Rows(0).Item("TOTALAMOUNT"), "0.00")
                    Txt_TaxAmount.Text = Format(gdataset.Tables("HallHdr").Rows(0).Item("HallTaxAmount"), "0.00")
                    Txt_TotAmount.Text = Format(gdataset.Tables("HallHdr").Rows(0).Item("HALLNETAMOUNT"), "0.00")
                    Cbo_TypeofMenu.Text = gdataset.Tables("HallHdr").Rows(0).Item("Menu_Type")

                    ''Details
                    sqlstring = "Select * from Party_Hallbooking_Det WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
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
                                .Text = Format(DT.Rows(i).Item("HALLAMOUNT"), "0.00")
                                .Col = 9
                                .Text = DT.Rows(i).Item("ChargeCode")
                                .Col = 10
                                .Text = Format(DT.Rows(i).Item("HALLTAXAMOUNT"), "0.00")
                                .Col = 11
                                .Text = Format(DT.Rows(i).Item("HALLNETAMOUNT"), "0.00")
                                .Col = 12
                                .Text = Format(DT.Rows(i).Item("SECURITYDEPOSIT"), "0.00")
                                sqlstring = "SELECT ISNULL(RentOverride,'No')as RentOverride FROM PARTY_HALLMASTER_HDR WHERE HALLTYPECODE = '" & Trim(DT.Rows(i).Item("HALLCODE")) & "'"
                                GCONNECTION.getDataSet(sqlstring, "Overrid")
                                If Trim(gdataset.Tables("Overrid").Rows(0).Item(0)) = "Yes" Then
                                    .Col = 13
                                    .Lock = False
                                Else
                                    .Col = 13
                                    .Lock = True
                                End If
                                .Col = 13
                                .Text = Format(DT.Rows(i).Item("Act_HallCgs"), "0.00")
                                .Col = 15
                                .Text = DT.Rows(i).Item("HALLTYPE")
                                .Col = 16
                                .Text = DT.Rows(i).Item("PDesc")
                                .Col = 17
                                .Text = DT.Rows(i).Item("M_Keeper")
                            Next
                        End With
                    End If
                    sqlstring = "SELECT * FROM partyrec_advance WHERE bookno = " & Txt_BookingNo.Text & ""
                    DT = GCONNECTION.GetValues(sqlstring)
                    If DT.Rows.Count > 0 Then
                        sSGrid_Receipt.ClearRange(-1, -1, 1, 1, True)
                        With sSGrid_Receipt
                            For i = 0 To DT.Rows.Count - 1
                                .Col = 1
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("PARTYRECEIPTNO")
                                .Col = 2
                                .Row = i + 1
                                .Text = Format(CDate(Trim(DT.Rows(i).Item("PARTYRECEIPTDATE"))), "dd/MM/yy")
                                .Col = 3
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("AMOUNT")
                                .Col = 4
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("Receiptheaddesc")
                            Next
                        End With
                    End If
                    '----GUEST GSTIN NO
                    Dim GGSTINNO As String
                    GGSTINNO = GCONNECTION.getvalue("SELECT isnull(GGSTINNO,'') as GGSTINNO FROM PARTY_HALLBOOKING_HDR where BOOKINGNO = '" & Txt_BookingNo.Text & "'")
                    If GGSTINNO = Nothing Then
                        Txt_GGstN.Visible = False
                        lbl_GGstNo.Visible = False
                    Else
                        Txt_GGstN.Visible = True
                        lbl_GGstNo.Visible = True
                        Txt_GGstN.Text = gdataset.Tables("HallHdr").Rows(0).Item("GGSTINNO")
                    End If
                    '----GUEST GSTIN NO

                    If Val(gdataset.Tables("HallHdr").Rows(0).Item("VEG")) > 0 Then
                        Cmd_VMenuCodeHelp.Enabled = True
                        Txt_VMenuCode.Enabled = True
                    Else
                        Cmd_VMenuCodeHelp.Enabled = False
                        Txt_VMenuCode.Enabled = False
                    End If
                    If Val(gdataset.Tables("HallHdr").Rows(0).Item("NONVEG")) > 0 Then
                        Cmd_NVMenuCodeHelp.Enabled = True
                        Txt_NVMenuCode.Enabled = True
                    Else
                        Cmd_NVMenuCodeHelp.Enabled = False
                        Txt_NVMenuCode.Enabled = False
                    End If
                    Call POSDetails()
                    Call ARRANGEMENT()
                    Call OthersDet()
                    'Call RESTAURANT()
                    Call TarriffVeg()
                    Call TarriffNonVeg()
                    Call ReceiptDet()

                    If gdataset.Tables("HallStatus").Rows(0).Item("FREEZE") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "This Booking is Freezed on :" & Format(CDate(gdataset.Tables("HallStatus").Rows(0).Item("UPDDATETIME")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                        CmdAdd.Enabled = False
                        Cmd_Freeze.Enabled = False
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

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub POSDetails()
        Try
            If Mid(gCompName, 1, 2) = "HC" Then
                sqlstring = "SELECT KOTNO,KOTDETAILS,KOTDATE,BILLDETAILS,'PAR',ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE, "
                sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,KOTTYPE,ALCHOLST,0,PAYMENTMODE,DelFlag,AddUserid,Adddatetime,UpdUserid,Upddatetime,PACKAMT,DISCAMT,PACKPERCENT, "
                sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,'','','',GroupCode,TIPSPERCENT,TIPSAMOUNT,0,0,0,0,0,0,'','BOOKING',0  "
                sqlstring = sqlstring & "FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Trim(Txt_BookingNo.Text) & "') AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y'"
            Else
                sqlstring = "SELECT KOTNO,KOTDETAILS,KOTDATE,BILLDETAILS,CATEGORY,ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE, "
                sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,KOTTYPE,ALCHOLST,CHITNO,PAYMENTMODE,DelFlag,AddUserid,Adddatetime,UpdUserid,Upddatetime,PACKAMT,DISCAMT,PACKPERCENT, "
                sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,PDA_PRINT_FLAG,PDA_DELETE_FLAG,IS_PDA,SUBGroupCode,TipsPer,TipsAmt,AdCgsPer,AdCgsAmt,PartyPer,PartyAmt,RoomPer,RoomAmt,MKOTNO,'BOOKING',SLNO "
                sqlstring = sqlstring & "FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Trim(Txt_BookingNo.Text) & "') AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y'"
            End If
            DT = GConnection.GetValues(sqlstring)
            If DT.Rows.Count > 0 Then
                With sSGrid_Kot
                    sSGrid_Kot.ClearRange(-1, -1, 1, 1, True)
                    For I = 0 To DT.Rows.Count - 1
                        .Col = 1
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("KOTDETAILS")
                        .Col = 2
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("ITEMCODE")
                        .Col = 3
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("ITEMDESC")
                        .Col = 4
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("POSCODE")
                        .Col = 5
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("UOM")
                        .Col = 6
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("RATE")
                        .Col = 7
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("QTY")
                        .Col = 8
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("AMOUNT")
                        .Col = 9
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("TAXAMOUNT")
                    Next
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ARRANGEMENT()
        Dim PD As Integer
        Dim CAMT As Double
        If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then

        Else
            Try
                If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                    SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT,TAXCODE,SLNO "
                    SSQL = SSQL & " FROM VIEW_PARTY_ARRANGEMENT WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                    DT = GCONNECTION.GetValues(SSQL)
                ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                    SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT "
                    SSQL = SSQL & " FROM VIEW_PARTY_ARRANGEMENT WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                    DT = GCONNECTION.GetValues(SSQL)
                    If DT.Rows.Count = 0 Then
                        SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT "
                        SSQL = SSQL & " FROM VIEW_PARTY_ARRANGEMENT WHERE  BOOKINGTYPE='BOOKING' AND BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                        DT = GCONNECTION.GetValues(SSQL)
                    End If
                End If
                If DT.Rows.Count > 0 Then
                    With sSGrid_Arr
                        .ClearRange(-1, -1, 1, 1, True)
                        .SetActiveCell(1, 1)
                        For I = 0 To DT.Rows.Count - 1
                            .Row = I + 1
                            .Col = 1
                            .Text = DT.Rows(I).Item("Itemcode")
                            .Row = I + 1
                            .Col = 2
                            .Text = DT.Rows(I).Item("Itemdescription")
                            .Row = I + 1
                            .Col = 3
                            .Text = DT.Rows(I).Item("Uom")
                            .Row = I + 1
                            .Col = 4
                            .Text = Format(DT.Rows(I).Item("rate"), "0.00")
                            .Row = I + 1
                            .Col = 5
                            .Text = Format(DT.Rows(I).Item("qty"), "0.00")
                            .Row = I + 1
                            .Col = 7
                            .Text = Format(DT.Rows(I).Item("Taxamount"), "0.00")
                            .Row = I + 1
                            .Col = 6
                            .Text = Format(DT.Rows(I).Item("Amount"), "0.00")
                            .Row = I + 1
                            .Col = 8
                            .Text = Format(DT.Rows(I).Item("TOTALAMOUNT"), "0.00")
                            .Row = I + 1
                            .Col = 9
                            .Text = DT.Rows(I).Item("Taxcode").ToString
                            .Row = I + 1
                            .Col = 10
                            .Text = Format(DT.Rows(I).Item("SLNO"), "0")
                            .SetActiveCell(1, I + 1)
                        Next
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub
    Private Sub OthersDet()
        Try
            If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT,TAXCODE,SLNO "
                SSQL = SSQL & " FROM VIEW_PARTY_OTHERSCHAGES WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' AND ITEMCODE NOT IN ('EHC','MGA')"
                DT = GCONNECTION.GetValues(SSQL)
            ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT "
                SSQL = SSQL & " FROM VIEW_PARTY_OTHERSCHAGES WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' AND ITEMCODE NOT IN ('EHC','MGA')"
                DT = GCONNECTION.GetValues(SSQL)
                If DT.Rows.Count = 0 Then
                    SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT "
                    SSQL = SSQL & " FROM VIEW_PARTY_OTHERSCHAGES WHERE  BOOKINGTYPE='BOOKING' AND BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' AND ITEMCODE NOT IN ('EHC','MGA')"
                    DT = GCONNECTION.GetValues(SSQL)
                End If
            End If
            If DT.Rows.Count > 0 Then
                With sSGrid_Oth
                    .ClearRange(-1, -1, 1, 1, True)
                    .SetActiveCell(1, 1)
                    For I = 0 To DT.Rows.Count - 1
                        .Row = I + 1
                        .Col = 1
                        .Text = DT.Rows(I).Item("Itemcode")
                        .Row = I + 1
                        .Col = 2
                        .Text = DT.Rows(I).Item("Itemdescription")
                        .Row = I + 1
                        .Col = 3
                        .Text = Format(DT.Rows(I).Item("rate"), "0.00")
                        .Row = I + 1
                        .Col = 5
                        .Text = Format(DT.Rows(I).Item("Taxamount"), "0.00")
                        .Row = I + 1
                        .Col = 4
                        .Text = Format(DT.Rows(I).Item("Amount"), "0.00")
                        .Row = I + 1
                        .Col = 6
                        .Text = Format(DT.Rows(I).Item("TOTALAMOUNT"), "0.00")
                        .Row = I + 1
                        .Col = 7
                        .Text = DT.Rows(I).Item("Taxcode").ToString
                        .Row = I + 1
                        .Col = 8
                        .Text = Format(DT.Rows(I).Item("SLNO"), "0")
                        .SetActiveCell(1, I + 1)
                    Next
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TarriffVeg()
        If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE  BOOKINGNO=" & Txt_BookingNo.Text & " AND BOOKINGTYPE = '" & CMBBOOKINGTYPE.Text & "'  and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category IN ('VEG')) AND BOOKINGTYPE='BOOKING'"
            DT = GConnection.GetValues(SSQL)
        ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE  BOOKINGNO=" & Txt_BookingNo.Text & " AND BOOKINGTYPE = '" & CMBBOOKINGTYPE.Text & "' AND ISNULL(TARIFFDESC,'')<>'' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category in ('VEG'))"
            DT = GConnection.GetValues(SSQL)
        End If
        If DT.Rows.Count > 0 Then
            Txt_VMenuCode.Enabled = False
            Cmd_VMenuCodeHelp.Enabled = False
            Me.Txt_VMenuCode.Text = DT.Rows(0).Item("TARIFFCODE")
            Me.Txt_VMenuDesc.Text = DT.Rows(0).Item("TARIFFDESC")
            SSQL = "SELECT isnull(SUM(MAXITEMS),25) AS MAXITEMS FROM PARTY_TARIFFDET WHERE TARIFFCODE='" & Trim(Txt_VMenuCode.Text) & "' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category in ('VEG'))"
            GConnection.getDataSet(SSQL, "USER")
            If gdataset.Tables("USER").Rows.Count > 0 Then
                Me.Txt_VMaxItem.Text = gdataset.Tables("USER").Rows(0).Item("MAXITEMS")
            Else
                Txt_VMaxItem.Text = 25
            End If
            With sSGrid_VPax
                For I = 0 To DT.Rows.Count - 1
                    .Col = 1
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("MENUCODE")
                    .Col = 2
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("ITEMCODE")
                    .Col = 3
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("ITEMDESCRIPTION")
                    .Col = 4
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("UOM")
                    .Col = 5
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("QTY")
                    .Col = 6
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("MAXITEMS")
                Next
            End With
        Else
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE  BOOKINGTYPE='BOOKING' AND BOOKINGNO=" & Txt_BookingNo.Text & "  and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category='VEG')"

            DT = GConnection.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                Me.Txt_VMenuCode.Text = DT.Rows(0).Item("TARIFFCODE")
                Me.Txt_VMenuDesc.Text = DT.Rows(0).Item("TARIFFDESC")
                Me.Txt_VMaxItem.Text = DT.Rows(0).Item("MAXITEMS")
                With sSGrid_VPax
                    For I = 1 To DT.Rows.Count - 1
                        .Col = 1
                        .Row = I
                        .Text = DT.Rows(I).Item("MENUCODE")
                        .Col = 2
                        .Row = I
                        .Text = DT.Rows(I).Item("ITEMCODE")
                        .Col = 3
                        .Row = I
                        .Text = DT.Rows(I).Item("ITEMDESCRIPTION")
                        .Col = 4
                        .Row = I
                        .Text = DT.Rows(I).Item("UOM")
                        .Col = 5
                        .Row = I
                        .Text = DT.Rows(I).Item("QTY")
                        .Col = 6
                        .Row = I
                        .Text = DT.Rows(I).Item("MAXITEMS")
                    Next
                End With
            End If
        End If
    End Sub
    Private Sub TarriffNonVeg()
        If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE  BOOKINGNO=" & Txt_BookingNo.Text & " AND BOOKINGTYPE = '" & CMBBOOKINGTYPE.Text & "'  and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category IN ('NON VEG')) AND BOOKINGTYPE='BOOKING'"
            DT = GConnection.GetValues(SSQL)
        ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE  BOOKINGNO=" & Txt_BookingNo.Text & " AND BOOKINGTYPE = '" & CMBBOOKINGTYPE.Text & "' AND ISNULL(TARIFFDESC,'')<>'' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category in ('NON VEG'))"
            DT = GConnection.GetValues(SSQL)
        End If
        If DT.Rows.Count > 0 Then
            Txt_NVMenuCode.Enabled = False
            Cmd_NVMenuCodeHelp.Enabled = False
            Me.Txt_NVMenuCode.Text = DT.Rows(0).Item("TARIFFCODE")
            Me.Txt_NVMenuDesc.Text = DT.Rows(0).Item("TARIFFDESC")
            SSQL = "SELECT isnull(SUM(MAXITEMS),25) AS MAXITEMS FROM PARTY_TARIFFDET WHERE TARIFFCODE='" & Trim(Txt_NVMenuCode.Text) & "' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category in ('NON VEG'))"
            GConnection.getDataSet(SSQL, "USER")
            If gdataset.Tables("USER").Rows.Count > 0 Then
                Me.Txt_NVMaxItem.Text = gdataset.Tables("USER").Rows(0).Item("MAXITEMS")
            Else
                Txt_NVMaxItem.Text = 25
            End If
            With sSGrid_NVPax
                For I = 0 To DT.Rows.Count - 1
                    .Col = 1
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("MENUCODE")
                    .Col = 2
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("ITEMCODE")
                    .Col = 3
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("ITEMDESCRIPTION")
                    .Col = 4
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("UOM")
                    .Col = 5
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("QTY")
                    .Col = 6
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("MAXITEMS")
                Next
            End With
        Else
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE  BOOKINGTYPE='BOOKING' AND BOOKINGNO=" & Txt_BookingNo.Text & "  and tariffcode in ( select tariffcode from PARTY_TARIFFHDR where category='NON VEG')"

            DT = GConnection.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                Me.Txt_NVMenuCode.Text = DT.Rows(0).Item("TARIFFCODE")
                Me.Txt_NVMenuDesc.Text = DT.Rows(0).Item("TARIFFDESC")
                Me.Txt_NVMaxItem.Text = DT.Rows(0).Item("MAXITEMS")
                With sSGrid_NVPax
                    For I = 1 To DT.Rows.Count - 1
                        .Col = 1
                        .Row = I
                        .Text = DT.Rows(I).Item("MENUCODE")
                        .Col = 2
                        .Row = I
                        .Text = DT.Rows(I).Item("ITEMCODE")
                        .Col = 3
                        .Row = I
                        .Text = DT.Rows(I).Item("ITEMDESCRIPTION")
                        .Col = 4
                        .Row = I
                        .Text = DT.Rows(I).Item("UOM")
                        .Col = 5
                        .Row = I
                        .Text = DT.Rows(I).Item("QTY")
                        .Col = 6
                        .Row = I
                        .Text = DT.Rows(I).Item("MAXITEMS")
                    Next
                End With
            End If
        End If
    End Sub
    Private Sub ReceiptDet()
        Try
            If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                SSQL = "  select PAYMENTMODE,SUM(Amount) as Amount,PARTYRECEIPTNO from party_receipt_Det WHERE BOOKINGNO = " & Txt_BookingNo.Text & " And ISNULL(RType,'') = 'B'"
                SSQL = SSQL & " GROUP BY PAYMENTMODE,PARTYRECEIPTNO ORDER BY PARTYRECEIPTNO "
                DT = GCONNECTION.GetValues(SSQL)
            End If
            If DT.Rows.Count > 0 Then
                With sSGrid_Rec
                    .ClearRange(-1, -1, 1, 1, True)
                    .SetActiveCell(1, 1)
                    For I = 0 To DT.Rows.Count - 1
                        .Row = I + 1
                        .Col = 1
                        .Text = DT.Rows(I).Item("PAYMENTMODE")
                        .Row = I + 1
                        .Col = 2
                        .Text = Format(DT.Rows(I).Item("Amount"), "0.00")
                        .Row = I + 1
                        .Col = 3
                        .Text = DT.Rows(I).Item("PARTYRECEIPTNO")
                        .SetActiveCell(1, I + 1)
                    Next
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
        Txt_Amount.Text = ""
        Txt_TaxAmount.Text = ""
        Txt_TotAmount.Text = ""
        Txt_Discount.Text = ""
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.Enabled = True
        Me.Cmd_Freeze.Text = "Freeze [F8]"
        Cmd_Freeze.Enabled = True
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "THIS BOOKING IS CANCELLED ON :"
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        sSGrid_HallReserv.ClearRange(-1, -1, 1, 1, True)
        sSGrid_HallReserv.SetActiveCell(1, 1)
        sSGrid_HallAvail.ClearRange(-1, -1, 1, 1, True)
        sSGrid_HallAvail.SetActiveCell(1, 1)
        sSGrid_Receipt.ClearRange(-1, -1, 1, 1, True)
        sSGrid_Receipt.SetActiveCell(1, 1)
        Cbo_TypeofMenu.SelectedIndex = 0

        Cmd_NVMenuCodeHelp.Enabled = False
        Txt_NVMenuCode.Enabled = False
        Cmd_VMenuCodeHelp.Enabled = False
        Txt_VMenuCode.Enabled = False
        Txt_MemberCode.Enabled = True
        Txt_NVMenuCode.Enabled = True
        Cmd_NVMenuCodeHelp.Enabled = True
        Txt_VMenuCode.Enabled = True
        Cmd_VMenuCodeHelp.Enabled = True
        Txt_VMenuCode.Text = ""
        Txt_VMenuDesc.Text = ""
        Txt_VMaxItem.Text = ""
        Txt_NVMenuCode.Text = ""
        Txt_NVMenuDesc.Text = ""
        Txt_NVMaxItem.Text = ""
        sSGrid_VPax.ClearRange(-1, -1, 1, 1, True)
        sSGrid_VPax.SetActiveCell(1, 1)
        sSGrid_NVPax.ClearRange(-1, -1, 1, 1, True)
        sSGrid_NVPax.SetActiveCell(1, 1)
        sSGrid_Arr.ClearRange(-1, -1, 1, 1, True)
        sSGrid_Arr.SetActiveCell(1, 1)
        sSGrid_Oth.ClearRange(-1, -1, 1, 1, True)
        sSGrid_Oth.SetActiveCell(1, 1)
        sSGrid_Kot.ClearRange(-1, -1, 1, 1, True)
        sSGrid_Kot.SetActiveCell(1, 1)
        sSGrid_Rec.ClearRange(-1, -1, 1, 1, True)
        sSGrid_Rec.SetActiveCell(1, 1)
        TabControl1.SelectedIndex = 0


        Call Auto_BookingNo()
        Txt_BookingNo.Focus()
        '----GUEST GSTIN NO
        Txt_GGstN.Text = ""
        Txt_GGstN.Visible = False
        lbl_GGstNo.Visible = False
        '----GUEST GSTIN NO
    End Sub

    Private Sub Hall_Avail_Click(sender As Object, e As EventArgs) Handles Hall_Avail.Click

    End Sub

    Private Sub Receipt_Details_Click(sender As Object, e As EventArgs) Handles Receipt_Details.Click
        ''sSGrid_Receipt.ClearRange(-1, -1, 1, 1, True)
        ''sSGrid_Receipt.Col = 1
        ''sSGrid_Receipt.Row = 1
        ''sSGrid_Receipt.Text = "PAR/000001/15-16"
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 2 Then
            Call Receipt_Details_Click(sender, e)
        ElseIf TabControl1.SelectedIndex = 1 Then
            Call Hall_Status()
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
                        If Controls(i_i).Name = "Cmd_Clear" Or Controls(i_i).Name = "Cmd_Add" Or Controls(i_i).Name = "Cmd_Delete" Or Controls(i_i).Name = "Cmd_View" Or Controls(i_i).Name = "Cmd_Print" Or Controls(i_i).Name = "Cmd_Export" Or Controls(i_i).Name = "Cmd_Exit" Or Controls(i_i).Name = "Cmd_PendingBill" Or Controls(i_i).Name = "Cmd_Bill" Or Controls(i_i).Name = "Cmd_RecPrint" Then
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
    Private Sub Hall_Status()
        'PRIVATE SUB STATUSHALL
        sSGrid_HallAvail.Lock = False
        Dim II As Integer
        Dim SSTR As String
        Try
            Dim dno As Integer
            Dim dd, dd1 As Date
            Dim dt As New DataTable
            Dim dt2 As New DataTable
            Dim dt3 As New DataTable
            Dim SSQL2 As String
            ssql = " DELETE FROM PARTY_HallStatus"
            dt = gconnection.GetValues(ssql)
            dd = Dtp_PartyDate.Value
            Dim hallcode, PCODE As String
            'hallcode = (txthallcode.Text)

            For II = 0 To sSGrid_HallReserv.DataRowCnt - 1

                sSGrid_HallReserv.Col = 1
                sSGrid_HallReserv.Row = II + 1
                hallcode = Trim(sSGrid_HallReserv.Text)
                sSGrid_HallReserv.Col = 15
                sSGrid_HallReserv.Row = II + 1
                PCODE = Trim(sSGrid_HallReserv.Text)

                'SSQL2 = "SELECT * FROM party_hallstatusdetails WHERE "
                'SSQL2 = SSQL2 & " CAST(Convert(varchar(11),PARTYDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                'SSQL2 = SSQL2 & " and hallcode='" & hallcode & "' AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                'dt3 = GCONNECTION.GetValues(SSQL2)
                SSQL2 = "SELECT * FROM party_hallstatusdetails WHERE "
                SSQL2 = SSQL2 & " CAST(Convert(varchar(11),PARTYDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                SSQL2 = SSQL2 & " and hallcode='" & hallcode & "' order by Totime"
                dt3 = GCONNECTION.GetValues(SSQL2)

                dd = DateAdd(DateInterval.Day, -1, Dtp_PartyDate.Value)
                For i = 0 To 6
                    dd = dd.AddDays(+1)
                    'SSQL = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET WHERE "
                    'SSQL = SSQL & "  cast(convert(varchar(11),PARTYDATE,106)as datetime)='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                    'SSQL = SSQL & " and hallcode ='" & Trim(hallcode) & "'AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                    SSQL = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET WHERE "
                    SSQL = SSQL & "  cast(convert(varchar(11),PARTYDATE,106)as datetime)='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                    SSQL = SSQL & " and hallcode ='" & Trim(hallcode) & "'  order by Totime"
                    dt = GCONNECTION.GetValues(SSQL)
                    If dt.Rows.Count > 0 Then
                        SSQL = " SELECT * FROM  PARTY_HallStatus WHERE "
                        SSQL = SSQL & "  cast(convert(varchar(11),BOOKINGDATE,106)as datetime)='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                        SSQL = SSQL & " and hallcode='" & hallcode & "'"
                        dt2 = GCONNECTION.GetValues(SSQL)
                        If dt2.Rows.Count <= 0 Then
                            SSQL = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                            SSQL = SSQL & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "')"
                            GCONNECTION.ExcuteStoreProcedure(SSQL)
                        End If

                        For j = 0 To dt.Rows.Count - 1
                            For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                SSQL = " Update PARTY_HallStatus set b" & Trim(k) & "='B'"
                                SSQL = SSQL & " Where Bookingdate='" & Format(dd, "yyyy-MM-dd") & "' AND HALLCODE='" & Trim(hallcode) & "'"
                                GCONNECTION.ExcuteStoreProcedure(SSQL)
                            Next
                            SSQL = ""
                        Next
                        If dt3.Rows.Count > 0 Then
                            For j = 0 To dt.Rows.Count - 1
                                For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                    SSQL = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                                    SSQL = SSQL & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                    SSQL = SSQL & " and hallcode='" & hallcode & "'"

                                    GCONNECTION.ExcuteStoreProcedure(SSQL)
                                Next
                                SSQL = ""
                            Next
                        End If
                    Else
                        'SSQL = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET WHERE "
                        'SSQL = SSQL & "  '" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "' BETWEEN cast(convert(varchar(11),Partydate,106)as datetime) AND cast(convert(varchar(11),PartyTodate,106)as datetime)"
                        'SSQL = SSQL & " and hallcode ='" & Trim(hallcode) & "'AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                        SSQL = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET WHERE "
                        SSQL = SSQL & "  '" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "' BETWEEN cast(convert(varchar(11),Partydate,106)as datetime) AND cast(convert(varchar(11),PartyTodate,106)as datetime)"
                        SSQL = SSQL & " and hallcode ='" & Trim(hallcode) & "'  order by Totime"
                        dt = GCONNECTION.GetValues(SSQL)
                        If dt.Rows.Count > 0 Then
                            SSQL = " SELECT * FROM  PARTY_HallStatus WHERE "
                            SSQL = SSQL & "  cast(convert(varchar(11),BOOKINGDATE,106)as datetime)='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                            SSQL = SSQL & " and hallcode='" & hallcode & "'"
                            dt2 = GCONNECTION.GetValues(SSQL)
                            If dt2.Rows.Count <= 0 Then
                                SSQL = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                                SSQL = SSQL & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "')"
                                GCONNECTION.ExcuteStoreProcedure(SSQL)
                            End If

                            For j = 0 To dt.Rows.Count - 1
                                For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                    SSQL = " Update PARTY_HallStatus set b" & Trim(k) & "='B'"
                                    SSQL = SSQL & " Where Bookingdate='" & Format(dd, "yyyy-MM-dd") & "' AND HALLCODE='" & Trim(hallcode) & "'"
                                    GCONNECTION.ExcuteStoreProcedure(SSQL)
                                Next
                                SSQL = ""
                            Next
                            If dt3.Rows.Count > 0 Then
                                For j = 0 To dt.Rows.Count - 1
                                    For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                        SSQL = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                                        SSQL = SSQL & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                        SSQL = SSQL & " and hallcode='" & hallcode & "'"

                                        GCONNECTION.ExcuteStoreProcedure(SSQL)
                                    Next
                                    SSQL = ""
                                Next
                            End If
                        Else
                            SSQL = " SELECT * FROM  PARTY_HallStatus WHERE "
                            SSQL = SSQL & " BOOKINGDATE='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                            SSQL = SSQL & " and hallcode='" & hallcode & "'"
                            dt2 = GCONNECTION.GetValues(SSQL)
                            If dt2.Rows.Count <= 0 Then
                                SSQL = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
                                SSQL = SSQL & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "')"
                                GCONNECTION.ExcuteStoreProcedure(SSQL)
                            End If
                        End If

                    End If
                Next
            Next II

            For II = 0 To sSGrid_HallReserv.DataRowCnt - 1
                sSGrid_HallReserv.Col = 1
                sSGrid_HallReserv.Row = II + 1
                hallcode = Trim(sSGrid_HallReserv.Text)
                dd = DateAdd(DateInterval.Day, -1, Dtp_PartyDate.Value)
                For i = 0 To 6
                    dd = dd.AddDays(+1)
                    SSQL = " SELECT * FROM Party_Trn_HallBlocking WHERE Trans_Date = '" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "' "
                    dt = GCONNECTION.GetValues(SSQL)
                    If dt.Rows.Count > 0 Then
                        For k = 1 To 24
                            SSQL = " Update PARTY_HallStatus set b" & Trim(k) & "='L'"
                            SSQL = SSQL & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                            SSQL = SSQL & " and hallcode='" & hallcode & "'"
                            GCONNECTION.ExcuteStoreProcedure(SSQL)
                        Next
                        SSQL = ""
                    End If
                Next
            Next


            SSQL = " SELECT HALLCODE,BOOKINGDATE,B1,B2,B3,B4,B5,B6,B7,B8,B9,B10,B11,B12,B13,B14,B15,B16,B17,B18,B19,B20,B21,B22,"
            SSQL = SSQL & " B23,B24 FROM VIEW_PARTY_STATUSHALL order by bookingdate,HALLCODE"
            dt = (GCONNECTION.GetValues(SSQL))
            sSGrid_HallAvail.ClearRange(-1, -1, 1, 1, True)
            sSGrid_HallAvail.SetActiveCell(1, 1)
            Dim rowid As Integer
            Dim Super As String
            If dt.Rows.Count > 0 Then
                With sSGrid_HallAvail
                    For i = 0 To dt.Rows.Count - 1
                        rowid = rowid + 1
                        .Row = rowid
                        .Col = 1
                        .Text = Trim(dt.Rows(i).Item("HALLCODE"))
                        .Row = rowid
                        .Col = 2
                        For j = 0 To 24
                            If j = 0 Then
                                .SetActiveCell(j + 2, rowid)
                                .Col = j + 2
                                .Row = rowid
                                .BackColor = Color.GreenYellow
                                .ForeColor = Color.Blue
                                .Text = Format(dt.Rows(i).Item(dt.Columns(j + 1).ColumnName), "dd/MM/yyyy")
                            Else
                                If dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "C" Then
                                    sSGrid_HallAvail.SetActiveCell(j + 1, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .Text = "C"
                                    .BackColor = Color.Red
                                ElseIf dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "B" Then
                                    sSGrid_HallAvail.SetActiveCell(j + 1, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .Text = "B"
                                    .BackColor = Color.Blue
                                ElseIf dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "L" Then
                                    sSGrid_HallAvail.SetActiveCell(j + 1, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .Text = "L"
                                    .BackColor = Color.Yellow
                                Else
                                    sSGrid_HallAvail.SetActiveCell(j + 1, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .BackColor = Color.Green
                                End If
                            End If
                        Next
                    Next
                    .SetActiveCell(2, 1)
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Dim Insert(0) As String
        Call checkValidation()
        If boolchk = False Then Exit Sub
        Dim Fre, strsql As String
        Try
            If Trim(Txt_BookingNo.Text) <> "" Then
                sqlstring = "SELECT * FROM PARTY_ACC_POST  where bookingno=" & Txt_BookingNo.Text & " AND ISNULL(POSTFLAG,'')='Y' "
                GCONNECTION.getDataSet(sqlstring, "accpost")
                If gdataset.Tables("accpost").Rows.Count > 0 Then
                    MessageBox.Show("ALREADY ACCOUNT POSTING WAS DONE,YOU CANNOT FREEZE ", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
                sqlstring = "SELECT ISNULL(BILLINGFLAG,'N') AS BILLINGFLAG,ISNULL(BOOKINGFLAG,'N') AS BOOKINGFLAG FROM party_hallbooking_hdr  where bookingno=" & Txt_BookingNo.Text & " "
                GCONNECTION.getDataSet(sqlstring, "BillCheck")
                If gdataset.Tables("BillCheck").Rows.Count > 0 Then
                    If gdataset.Tables("BillCheck").Rows(0).Item("BILLINGFLAG") = "Y" Then
                        MessageBox.Show("BILLING WAS DONE,YOU CANNOT FREEZE", MyCompanyName, MessageBoxButtons.OK)
                        Exit Sub
                    End If
                    If gdataset.Tables("BillCheck").Rows(0).Item("BOOKINGFLAG") = "Y" Then
                        MessageBox.Show("BOOKING WAS DONE,YOU CANNOT FREEZE", MyCompanyName, MessageBoxButtons.OK)
                        Exit Sub
                    End If
                End If
            End If
            If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
                If MsgBox("Are U Sure To Delete", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    sqlstring = "UPDATE Party_Hallbooking_Hdr SET Freeze= 'Y',UPDUSERID='" & gUsername & " ',UPDDATETIME =Getdate() "
                    sqlstring = sqlstring & " Where  Bookingno=" & Txt_BookingNo.Text & " "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "UPDATE Party_Hallbooking_Det SET Freeze= 'Y' "
                    sqlstring = sqlstring & " Where  Bookingno=" & Txt_BookingNo.Text & " "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "UPDATE Party_HallBooking_Det_Tax SET Freeze= 'Y',UPDATEUSERID='" & gUsername & " ',UPDATETIME =Getdate() "
                    sqlstring = sqlstring & " Where  Bookingno=" & Txt_BookingNo.Text & " "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                    GCONNECTION.MoreTransold(Insert)
                    Me.CmdClear_Click(sender, e)
                    CmdAdd.Text = "Add [F7]"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cmdbwse_Click(sender As Object, e As EventArgs) Handles Cmdbwse.Click
        Dim OBJ1 As New VIEWHDR
        Dim ChildSql As String
        sqlstring = "SELECT BOOKINGNO,HallDesc,PDesc,PARTYDATE,PartyToDate,FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET ORDER BY BOOKINGNO "
        ChildSql = ""
        GCONNECTION.getDataSet(sqlstring, "PARTY_HALLBOOKING_DET")
        OBJ1.LOADGRID(gdataset.Tables("PARTY_HALLBOOKING_DET"), False, "FRM_T_HallRervation", ChildSql, "BOOKINGNO", 0)
        OBJ1.Show()
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

    Private Sub sSGrid_HallAvail_MouseMoveEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_MouseMoveEvent) Handles sSGrid_HallAvail.MouseMoveEvent
        Dim ik, col, row As Integer
        With sSGrid_HallAvail

        End With

    End Sub

    Private Sub Txt_GuestName_Validated(sender As Object, e As EventArgs) Handles Txt_GuestName.Validated
        Dim response As MsgBoxResult
        response = MsgBox("Do You Want To Add Guest GSTIN Number ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm")
        If response = MsgBoxResult.Yes Then
            Txt_GGstN.Visible = True
            lbl_GGstNo.Visible = True
            Txt_GGstN.Select()
        ElseIf response = MsgBoxResult.No Then
            Txt_GGstN.Visible = False
            lbl_GGstNo.Visible = False
            Exit Sub
        End If
    End Sub

    Private Sub Txt_GGstN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_GGstN.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_GGstN.Text) <> "" Then
                Txt_NVPax.Focus()
            Else
                Txt_GGstN.Focus()
            End If
        End If
    End Sub
    Private Sub Cmd_VMenuCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_VMenuCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT DISTINCT TARIFFDESC,TARIFFCODE,RATE FROM PARTY_TARIFFHDR"
        gSQLString = gSQLString & " "
        If Trim(Search) = " " Then
            M_WhereCondition = " WHERE CATEGORY='VEG'"
        Else
            M_WhereCondition = " WHERE CATEGORY='VEG'"
        End If
        vform.Field = "TARIFFDESC,TARIFFCODE,RATE"
        vform.vCaption = "TARIFF MASTER HELP"
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_VMenuCode.Text = Trim(vform.keyfield1 & "")
            Txt_VMenuDesc.Text = Trim(vform.keyfield & "")
            Call Txt_VMenuCode_Validated(Txt_VMenuCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub Txt_VMenuCode_Validated(sender As Object, e As EventArgs) Handles Txt_VMenuCode.Validated
        If Trim(Txt_VMenuCode.Text) <> "" Then
            sqlstring = "SELECT TARIFFDESC,TARIFFCODE,SUM(MAXITEMS) AS MAXITEMS FROM PARTY_TARIFFDET WHERE TARIFFCODE='" & Trim(Txt_VMenuCode.Text) & "' AND freeze<>'Y'"
            sqlstring = sqlstring & " GROUP BY TARIFFDESC,TARIFFCODE"
            GCONNECTION.getDataSet(sqlstring, "TARIFF")
            If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                Txt_VMenuCode.Text = gdataset.Tables("TARIFF").Rows(0).Item("TARIFFCODE")
                Txt_VMenuDesc.Text = gdataset.Tables("TARIFF").Rows(0).Item("TARIFFDESC")
                Txt_VMaxItem.Text = gdataset.Tables("TARIFF").Rows(0).Item("MAXITEMS")
                sSGrid_VPax.MaxRows = Val(Txt_VMaxItem.Text)
                sSGrid_VPax.SetActiveCell(1, 1)
                sSGrid_VPax.Focus()
            Else
                Txt_VMenuCode.Text = ""
                Txt_VMenuCode.Focus()
            End If
        End If
    End Sub

    Private Sub sSGrid_VPax_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles sSGrid_VPax.KeyDownEvent
        Dim ITEMCODE As String
        Dim GROUP, SubCode As String
        Dim QTY, RATE, AMT As Double
        Dim COUNT, MAXITEMS, i As Integer
        With sSGrid_VPax
            i = .ActiveRow
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = i
                    SubCode = Trim(.Text)
                    If Trim(SubCode) = "" Then
                        Call FillSubCodeVeg()
                    Else
                        sqlstring = "SELECT MENUCODE,MAXITEMS FROM PARTY_TARIFFdet where TariffCode = '" & Trim(Txt_VMenuCode.Text) & "' and MenuCode = '" & Trim(SubCode) & "'"
                        GCONNECTION.getDataSet(sqlstring, "Subcode")
                        If gdataset.Tables("Subcode").Rows.Count > 0 Then
                            .SetText(1, .ActiveRow, gdataset.Tables("Subcode").Rows(0).Item("MENUCODE"))
                            .SetText(6, .ActiveRow, gdataset.Tables("Subcode").Rows(0).Item("MAXITEMS") & "")
                            .SetActiveCell(1, i)
                        Else
                            MessageBox.Show("SubGroup Not Found For this Tariff", MyCompanyName)
                            .ClearRange(1, .ActiveRow, 15, .ActiveRow, True)
                            .SetActiveCell(0, .ActiveRow)
                            .Focus()
                            Exit Sub
                        End If
                    End If
                ElseIf .ActiveCol = 2 Then
                    .Col = 1
                    .Row = i
                    SubCode = Trim(.Text)
                    .Col = 2
                    .Row = i
                    ITEMCODE = Trim(.Text)
                    If Trim(ITEMCODE) = "" Then
                        SubMenuCode = SubCode
                        Call FillMenuVeg()
                    Else
                        sqlstring = "SELECT ITEMCODE,ITEMDESC,UOM FROM view_party_menuitemhelp where TariffCode = '" & Trim(Txt_VMenuCode.Text) & "' and MenuCode = '" & Trim(SubCode) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                        GCONNECTION.getDataSet(sqlstring, "Itemcode")
                        If gdataset.Tables("Subcode").Rows.Count > 0 Then
                            .SetText(2, .ActiveRow, gdataset.Tables("Itemcode").Rows(0).Item("ITEMCODE"))
                            .SetText(3, .ActiveRow, gdataset.Tables("Itemcode").Rows(0).Item("ITEMDESC"))
                            .SetText(4, .ActiveRow, gdataset.Tables("Itemcode").Rows(0).Item("UOM"))
                            .SetActiveCell(4, i)
                        Else
                            MessageBox.Show("Item Not Found For this Tariff", MyCompanyName)
                            .ClearRange(2, .ActiveRow, 15, .ActiveRow, True)
                            .SetActiveCell(1, .ActiveRow)
                            .Focus()
                            Exit Sub
                        End If
                    End If
                ElseIf .ActiveCol = 5 Then
                    .Col = 5
                    .Row = i
                    If Val(.Text) <= 0 Then
                        .SetActiveCell(5, i)
                    Else
                        .SetActiveCell(0, .ActiveRow + 1)
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                With sSGrid_VPax
                    .Row = .ActiveRow
                    .DeleteRows(.ActiveRow, 1)
                    If .ActiveRow <= 1 Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(1, .ActiveRow - 1)
                    End If
                End With
            End If
        End With
    End Sub
    Public Sub FillSubCodeVeg()
        Dim vform As New LIST_OPERATION1
        gSQLString = "select DISTINCT MENUCODE,MENUDESC,MAXITEMS from PARTY_TARIFFdet "
        If Trim(Search) = " " Then
            M_WhereCondition = " Where tariffcode = '" & Trim(Txt_VMenuCode.Text) & "'  "
        Else
            M_WhereCondition = " Where tariffcode = '" & Trim(Txt_VMenuCode.Text) & "' "
        End If
        vform.Field = "MENUCODE,MENUDESC"
        vform.vCaption = "Sub Code MASTER HELP"
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            sSGrid_VPax.Col = 1
            sSGrid_VPax.Row = sSGrid_VPax.ActiveRow
            sSGrid_VPax.Text = Trim(vform.keyfield & "")
            sSGrid_VPax.Col = 6
            sSGrid_VPax.Row = sSGrid_VPax.ActiveRow
            sSGrid_VPax.Text = Trim(vform.keyfield2 & "")
            sSGrid_VPax.SetActiveCell(1, sSGrid_VPax.ActiveRow)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Public Sub FillMenuVeg()
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ITEMCODE,ITEMDESC,UOM FROM view_party_menuitemhelp "
        If Trim(Search) = " " Then
            M_WhereCondition = " Where tariffcode = '" & Trim(Txt_VMenuCode.Text) & "'  and MenuCode = '" & Trim(SubMenuCode) & "'"
        Else
            M_WhereCondition = " Where tariffcode = '" & Trim(Txt_VMenuCode.Text) & "'  and MenuCode = '" & Trim(SubMenuCode) & "'"
        End If
        vform.Field = "ITEMCODE,ITEMDESC"
        vform.vCaption = "Item Code MASTER HELP"
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            sSGrid_VPax.Col = 2
            sSGrid_VPax.Row = sSGrid_VPax.ActiveRow
            sSGrid_VPax.Text = Trim(vform.keyfield & "")
            sSGrid_VPax.Col = 3
            sSGrid_VPax.Row = sSGrid_VPax.ActiveRow
            sSGrid_VPax.Text = Trim(vform.keyfield1 & "")
            sSGrid_VPax.Col = 4
            sSGrid_VPax.Row = sSGrid_VPax.ActiveRow
            sSGrid_VPax.Text = Trim(vform.keyfield2 & "")
            sSGrid_VPax.SetActiveCell(4, sSGrid_VPax.ActiveRow)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub Cmd_NVMenuCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_NVMenuCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT DISTINCT TARIFFDESC,TARIFFCODE,RATE FROM PARTY_TARIFFHDR"
        gSQLString = gSQLString & " "
        If Trim(Search) = " " Then
            M_WhereCondition = " WHERE CATEGORY='NON VEG'"
        Else
            M_WhereCondition = " WHERE CATEGORY='NON VEG'"
        End If
        vform.Field = "TARIFFDESC,TARIFFCODE,RATE"
        vform.vCaption = "TARIFF MASTER HELP"
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_NVMenuCode.Text = Trim(vform.keyfield1 & "")
            Txt_NVMenuDesc.Text = Trim(vform.keyfield & "")
            Call Txt_NVMenuCode_Validated(Txt_NVMenuCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub Txt_NVMenuCode_Validated(sender As Object, e As EventArgs) Handles Txt_NVMenuCode.Validated
        If Trim(Txt_NVMenuCode.Text) <> "" Then
            sqlstring = "SELECT TARIFFDESC,TARIFFCODE,SUM(MAXITEMS) AS MAXITEMS FROM PARTY_TARIFFDET WHERE TARIFFCODE='" & Trim(Txt_NVMenuCode.Text) & "' AND freeze<>'Y'"
            sqlstring = sqlstring & " GROUP BY TARIFFDESC,TARIFFCODE"
            GCONNECTION.getDataSet(sqlstring, "TARIFF")
            If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                Txt_NVMenuCode.Text = gdataset.Tables("TARIFF").Rows(0).Item("TARIFFCODE")
                Txt_NVMenuDesc.Text = gdataset.Tables("TARIFF").Rows(0).Item("TARIFFDESC")
                Txt_NVMaxItem.Text = gdataset.Tables("TARIFF").Rows(0).Item("MAXITEMS")
                sSGrid_NVPax.MaxRows = Val(Txt_NVMaxItem.Text)
                sSGrid_NVPax.SetActiveCell(1, 1)
                sSGrid_NVPax.Focus()
            Else
                Txt_NVMenuCode.Text = ""
                Txt_NVMenuCode.Focus()
            End If
        End If
    End Sub

    Private Sub sSGrid_NVPax_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles sSGrid_NVPax.KeyDownEvent
        Dim ITEMCODE As String
        Dim GROUP, SubCode As String
        Dim QTY, RATE, AMT As Double
        Dim COUNT, MAXITEMS, i As Integer
        With sSGrid_NVPax
            i = .ActiveRow
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = i
                    SubCode = Trim(.Text)
                    If Trim(SubCode) = "" Then
                        Call FillSubCodeNonVeg()
                    Else
                        sqlstring = "SELECT MENUCODE,MAXITEMS FROM PARTY_TARIFFdet where TariffCode = '" & Trim(Txt_NVMenuCode.Text) & "' and MenuCode = '" & Trim(SubCode) & "'"
                        GCONNECTION.getDataSet(sqlstring, "Subcode")
                        If gdataset.Tables("Subcode").Rows.Count > 0 Then
                            .SetText(1, .ActiveRow, gdataset.Tables("Subcode").Rows(0).Item("MENUCODE"))
                            .SetText(6, .ActiveRow, gdataset.Tables("Subcode").Rows(0).Item("MAXITEMS") & "")
                            .SetActiveCell(1, i)
                        Else
                            MessageBox.Show("SubGroup Not Found For this Tariff", MyCompanyName)
                            .ClearRange(1, .ActiveRow, 15, .ActiveRow, True)
                            .SetActiveCell(0, .ActiveRow)
                            .Focus()
                            Exit Sub
                        End If
                    End If
                ElseIf .ActiveCol = 2 Then
                    .Col = 1
                    .Row = i
                    SubCode = Trim(.Text)
                    .Col = 2
                    .Row = i
                    ITEMCODE = Trim(.Text)
                    If Trim(ITEMCODE) = "" Then
                        SubMenuCode = SubCode
                        Call FillMenuNonVeg()
                    Else
                        sqlstring = "SELECT ITEMCODE,ITEMDESC,UOM FROM view_party_menuitemhelp where TariffCode = '" & Trim(Txt_NVMenuCode.Text) & "' and MenuCode = '" & Trim(SubCode) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                        GCONNECTION.getDataSet(sqlstring, "Itemcode")
                        If gdataset.Tables("Subcode").Rows.Count > 0 Then
                            .SetText(2, .ActiveRow, gdataset.Tables("Itemcode").Rows(0).Item("ITEMCODE"))
                            .SetText(3, .ActiveRow, gdataset.Tables("Itemcode").Rows(0).Item("ITEMDESC"))
                            .SetText(4, .ActiveRow, gdataset.Tables("Itemcode").Rows(0).Item("UOM"))
                            .SetActiveCell(4, i)
                        Else
                            MessageBox.Show("Item Not Found For this Tariff", MyCompanyName)
                            .ClearRange(2, .ActiveRow, 15, .ActiveRow, True)
                            .SetActiveCell(1, .ActiveRow)
                            .Focus()
                            Exit Sub
                        End If
                    End If
                ElseIf .ActiveCol = 5 Then
                    .Col = 5
                    .Row = i
                    If Val(.Text) <= 0 Then
                        .SetActiveCell(5, i)
                    Else
                        .SetActiveCell(0, .ActiveRow + 1)
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                With sSGrid_VPax
                    .Row = .ActiveRow
                    .DeleteRows(.ActiveRow, 1)
                    If .ActiveRow <= 1 Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(1, .ActiveRow - 1)
                    End If
                End With
            End If
        End With
    End Sub
    Public Sub FillSubCodeNonVeg()
        Dim vform As New LIST_OPERATION1
        gSQLString = "select DISTINCT MENUCODE,MENUDESC,MAXITEMS from PARTY_TARIFFdet "
        If Trim(Search) = " " Then
            M_WhereCondition = " Where tariffcode = '" & Trim(Txt_NVMenuCode.Text) & "'  "
        Else
            M_WhereCondition = " Where tariffcode = '" & Trim(Txt_NVMenuCode.Text) & "' "
        End If
        vform.Field = "MENUCODE,MENUDESC"
        vform.vCaption = "Sub Code MASTER HELP"
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            sSGrid_NVPax.Col = 1
            sSGrid_NVPax.Row = sSGrid_NVPax.ActiveRow
            sSGrid_NVPax.Text = Trim(vform.keyfield & "")
            sSGrid_NVPax.Col = 6
            sSGrid_NVPax.Row = sSGrid_NVPax.ActiveRow
            sSGrid_NVPax.Text = Trim(vform.keyfield2 & "")
            sSGrid_NVPax.SetActiveCell(1, sSGrid_NVPax.ActiveRow)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Public Sub FillMenuNonVeg()
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ITEMCODE,ITEMDESC,UOM FROM view_party_menuitemhelp "
        If Trim(Search) = " " Then
            M_WhereCondition = " Where tariffcode = '" & Trim(Txt_NVMenuCode.Text) & "'  and MenuCode = '" & Trim(SubMenuCode) & "'"
        Else
            M_WhereCondition = " Where tariffcode = '" & Trim(Txt_NVMenuCode.Text) & "'  and MenuCode = '" & Trim(SubMenuCode) & "'"
        End If
        vform.Field = "ITEMCODE,ITEMDESC"
        vform.vCaption = "Item Code MASTER HELP"
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            sSGrid_NVPax.Col = 2
            sSGrid_NVPax.Row = sSGrid_NVPax.ActiveRow
            sSGrid_NVPax.Text = Trim(vform.keyfield & "")
            sSGrid_NVPax.Col = 3
            sSGrid_NVPax.Row = sSGrid_NVPax.ActiveRow
            sSGrid_NVPax.Text = Trim(vform.keyfield1 & "")
            sSGrid_NVPax.Col = 4
            sSGrid_NVPax.Row = sSGrid_NVPax.ActiveRow
            sSGrid_NVPax.Text = Trim(vform.keyfield2 & "")
            sSGrid_NVPax.SetActiveCell(4, sSGrid_NVPax.ActiveRow)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub sSGrid_Arr_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles sSGrid_Arr.KeyDownEvent
        Dim Itemcode, OP As String
        Dim CDAY As Integer
        Dim rate, qty, TAXAMOUNT, AMOUNT, TAXPER As Double
        With sSGrid_Arr
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = .ActiveRow
                    If Trim(.Text) = "" Then
                        Call ArrItemCodeHelp()
                    Else
                        SSQL = "SELECT ITEMCODE,ITEMDESC,UOMCODE,RATE,OPENFACILITY,TAXCODE FROM PARTY_ITEMMASTER  WHERE ITEMCODE='" & Trim(.Text) & "' And Isnull(Freeze,'') <> 'Y'"
                        DT = GCONNECTION.GetValues(SSQL)
                        If DT.Rows.Count > 0 Then
                            .Col = 1
                            .Row = .ActiveRow
                            .Text = Trim(DT.Rows(0).Item("ITEMCODE"))
                            .Col = 2
                            .Row = .ActiveRow
                            .Text = Trim(DT.Rows(0).Item("ITEMDESC"))
                            .Col = 3
                            .Row = .ActiveRow
                            .Text = Trim(DT.Rows(0).Item("UOMCODE"))
                            .Col = 4
                            .Row = .ActiveRow
                            .Text = Trim(DT.Rows(0).Item("RATE"))
                            .Col = 9
                            .Row = .ActiveRow
                            .Text = Trim(DT.Rows(0).Item("TAXCODE"))
                            If Trim(DT.Rows(0).Item("OPENFACILITY")) = "Y" Then
                                .SetActiveCell(3, .ActiveRow)
                            Else
                                .SetActiveCell(4, .ActiveRow)
                            End If
                            '-------------Zubaer
                            Call DupCheck(sSGrid_Arr)
                            If Dup = False Then
                                .ClearRange(1, sSGrid_Arr.ActiveRow, 15, sSGrid_Arr.ActiveRow, True)
                                .SetActiveCell(0, sSGrid_Arr.ActiveRow)
                                .Focus()
                                Exit Sub
                            End If
                            '-------------Zubaer
                            Call Calculate_Arrange()
                        Else
                            MessageBox.Show("Item Not Found ", MyCompanyName)
                            .ClearRange(1, .ActiveRow, 15, .ActiveRow, True)
                            .SetActiveCell(0, .ActiveRow)
                            .Focus()
                            Exit Sub
                        End If
                    End If
                ElseIf .ActiveCol = 2 Then
                    If Trim(.Text) = "" Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(2, .ActiveRow)
                    End If
                ElseIf .ActiveCol = 3 Then
                    If Trim(.Text) = "" Then
                        .SetActiveCell(2, .ActiveRow)
                    Else
                        .SetActiveCell(3, .ActiveRow)
                    End If
                ElseIf .ActiveCol = 4 Then
                    If Val(.Text) <= 0 Then
                        .SetActiveCell(3, .ActiveRow)
                    Else
                        .SetActiveCell(4, .ActiveRow)
                    End If
                    .SetActiveCell(4, .ActiveRow)
                ElseIf .ActiveCol = 5 Then
                    .Col = 5
                    If Val(.Text) <= 0 Then
                        .SetActiveCell(4, .ActiveRow)
                    Else
                        .SetActiveCell(0, .ActiveRow + 1)
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                With sSGrid_Arr
                    .Row = .ActiveRow
                    .DeleteRows(.ActiveRow, 1)
                    If .ActiveRow <= 1 Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(1, .ActiveRow)
                    End If
                End With
                'Call TEMPBOOKINGDETAILS()
            End If
            Call Calculate_Arrange()
        End With
    End Sub
    Private Function ArrItemCodeHelp()
        Dim OP As String
        Dim vform As New LIST_OPERATION1
        If sSGrid_Arr.ActiveCol = 1 Then
            gSQLString = " SELECT ITEMCODE,ITEMDESC,UOMCODE,RATE,OPENFACILITY,TAXCODE FROM PARTY_ITEMMASTER"
            If Trim(Search) = "" Then
                M_WhereCondition = " Where Isnull(Freeze,'') <> 'Y'"
            Else
                M_WhereCondition = " Where Isnull(Freeze,'') <> 'Y'"
            End If
            vform.Field = "ITEMCODE,ITEMDESC,UOMCODE,RATE,OPENFACILITY,TAXCODE"
            vform.vCaption = "ARRANGEMENT DETAILS HELP"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                With sSGrid_Arr
                    .Col = 1
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield & "")
                    .Col = 2
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield1 & "")
                    .Col = 3
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield2 & "")
                    .Col = 4
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield3 & "")
                    OP = Trim(vform.keyfield4 & "")
                    If OP = "Y" Then
                        .SetActiveCell(3, .ActiveRow)
                    Else
                        .SetActiveCell(4, .ActiveRow)
                    End If
                    .Col = 9
                    .Text = Trim(vform.keyfield5 & "")
                End With
                '--------Zubaer
                Call DupCheck(sSGrid_Arr)
                If Dup = False Then
                    sSGrid_Arr.ClearRange(1, sSGrid_Arr.ActiveRow, 15, sSGrid_Arr.ActiveRow, True)
                    sSGrid_Arr.SetActiveCell(0, sSGrid_Arr.ActiveRow)
                    sSGrid_Arr.Focus()
                    Exit Function
                End If
                '-------Zubaer
            End If
        ElseIf sSGrid_Arr.ActiveCol = 2 Then
            With sSGrid_Arr
                .SetActiveCell(3, .ActiveRow)
            End With
        Else
            sSGrid_Arr.SetActiveCell(0, sSGrid_Arr.ActiveRow + 1)
        End If
        vform.Close()
        vform = Nothing
    End Function
    Private Sub Calculate_Arrange()
        Dim j, Qty As Integer
        Dim TotAmt, TotTaxAmt, TotBillAmt As Double
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, ITEMCODE As String
        Dim TPercent As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, TotCharges As Double
        GrdAmount = 0
        For i = 1 To sSGrid_Arr.DataRowCnt
            With sSGrid_Arr
                .Col = 4
                .Row = i
                GrdAmount = GrdAmount + Val(.Text)
            End With
        Next
        For i = 1 To sSGrid_Arr.DataRowCnt
            Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
            GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
            With sSGrid_Arr
                .Col = 4
                .Row = i
                GrdRate = Val(.Text)
                .Col = 5
                .Row = i
                Qty = Val(.Text)
                .Col = 9
                .Row = i
                ChargeCode = Trim(.Text)
                sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                GConnection.getDataSet(sqlstring, "CODE_CHECK")
                If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                    ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                End If
                sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                GConnection.getDataSet(sqlstring, "TAXON")
                If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                    For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                        If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                            Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZero = GZero + Zero
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                            ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroA = GZeroA + ZeroA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                            ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroB = GZeroB + ZeroB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                            One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOne = GOne + One
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                            OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneA = GOneA + OneA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                            OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneB = GOneB + OneB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                            Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwo = GTwo + Two
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                            TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoA = GTwoA + TwoA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                            TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoB = GTwoB + TwoB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                            Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThree = GThree + Three
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                            ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeA = GThreeA + ThreeA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                            ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeB = GThreeB + ThreeB
                        End If
                    Next
                    GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                End If
                TotAmt = TotAmt + (Val(GrdRate) * Qty)
                TotTaxAmt = TotTaxAmt + (Val(GrdTaxAmt) * Qty)
                TotBillAmt = TotBillAmt + ((Val(GrdTaxAmt) * Qty) + (Val(GrdRate) * Qty))
                .SetText(6, i, Val(GrdRate) * Qty)
                .SetText(7, i, (Val(GrdTaxAmt) * Qty))
                .SetText(8, i, (Val(GrdTaxAmt) * Qty) + (Val(GrdRate) * Qty))
            End With
        Next
    End Sub

    Private Sub sSGrid_Oth_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles sSGrid_Oth.KeyDownEvent
        Dim Itemcode, OP As String
        Dim CDAY As Integer
        Dim rate, qty, TAXAMOUNT, AMOUNT, TAXPER As Double
        With sSGrid_Oth
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = .ActiveRow
                    If Trim(.Text) = "" Then
                        Call OthItemCodeHelp()
                    Else
                        SSQL = "Select Itemcode,ItemDesc,Rate,AmtOverride,ChargeCode from Party_OtherChgsMaster  WHERE ITEMCODE='" & Trim(.Text) & "' AND ISNULL(Freeze,'') <> 'Y' AND ITEMCODE NOT IN ('EHC','MGA')"
                        DT = GCONNECTION.GetValues(SSQL)
                        If DT.Rows.Count > 0 Then
                            .Col = 1
                            .Row = .ActiveRow
                            .Text = Trim(DT.Rows(0).Item("ITEMCODE"))
                            .Col = 2
                            .Row = .ActiveRow
                            .Text = Trim(DT.Rows(0).Item("ITEMDESC"))
                            .Col = 3
                            .Row = .ActiveRow
                            .Text = Trim(DT.Rows(0).Item("Rate"))
                            .Col = 7
                            .Row = .ActiveRow
                            .Text = Trim(DT.Rows(0).Item("ChargeCode"))
                            If Trim(DT.Rows(0).Item("AmtOverride")) = "Y" Then
                                .Col = 3
                                .Row = .ActiveRow
                                .Lock = False
                                .SetActiveCell(2, .ActiveRow)
                            Else
                                .Col = 3
                                .Row = .ActiveRow
                                .Lock = True
                                .SetActiveCell(2, .ActiveRow)
                            End If
                            Call Calculate_Others()
                        Else
                            MessageBox.Show("Item Not Found ", MyCompanyName)
                            .ClearRange(1, .ActiveRow, 15, .ActiveRow, True)
                            .SetActiveCell(0, .ActiveRow)
                            .Focus()
                            Exit Sub
                        End If
                    End If
                ElseIf .ActiveCol = 2 Then
                    If Trim(.Text) = "" Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(2, .ActiveRow)
                    End If
                ElseIf .ActiveCol = 3 Then
                    If Trim(.Text) = "" Then
                        .SetActiveCell(2, .ActiveRow)
                    Else
                        .SetActiveCell(0, .ActiveRow + 1)
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                With sSGrid_Oth
                    .Row = .ActiveRow
                    .DeleteRows(.ActiveRow, 1)
                    If .ActiveRow <= 1 Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(1, .ActiveRow)
                    End If
                End With
                'Call TEMPBOOKINGDETAILS()
            End If
            Call Calculate_Others()
        End With
    End Sub
    Private Function OthItemCodeHelp()
        Dim OP As String
        Dim vform As New LIST_OPERATION1
        If sSGrid_Oth.ActiveCol = 1 Then
            gSQLString = " Select Itemcode,ItemDesc,Rate,AmtOverride,ChargeCode from Party_OtherChgsMaster"
            If Trim(Search) = "" Then
                M_WhereCondition = "  WHERE ISNULL(Freeze,'') <> 'Y' And ITEMCODE NOT IN ('EHC','MGA')"
            Else
                M_WhereCondition = "  WHERE ISNULL(Freeze,'') <> 'Y' And ITEMCODE NOT IN ('EHC','MGA')"
            End If
            vform.Field = "ITEMCODE,ITEMDESC,RATE,AmtOverride,ChargeCode"
            vform.vCaption = "OTHERS ITEM DETAILS HELP"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                With sSGrid_Oth
                    .Col = 1
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield & "")
                    .Col = 2
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield1 & "")
                    .Col = 3
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield2 & "")
                    OP = Trim(vform.keyfield3 & "")
                    If OP = "Y" Then
                        .Col = 3
                        .Row = .ActiveRow
                        .Lock = False
                        .SetActiveCell(2, .ActiveRow)
                    Else
                        .Col = 3
                        .Row = .ActiveRow
                        .Lock = True
                        .SetActiveCell(2, .ActiveRow)
                    End If
                    .Col = 7
                    .Text = Trim(vform.keyfield4 & "")
                End With
            End If
        ElseIf sSGrid_Oth.ActiveCol = 2 Then
            With sSGrid_Oth
                .SetActiveCell(3, .ActiveRow)
            End With
        Else
            sSGrid_Oth.SetActiveCell(0, sSGrid_Arr.ActiveRow + 1)
        End If
        vform.Close()
        vform = Nothing
    End Function
    Private Sub Calculate_Others()
        Dim j, Qty As Integer
        Dim TotAmt, TotTaxAmt, TotBillAmt As Double
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, ITEMCODE As String
        Dim TPercent As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, TotCharges As Double
        GrdAmount = 0
        For i = 1 To sSGrid_Oth.DataRowCnt
            With sSGrid_Oth
                .Col = 3
                .Row = i
                GrdAmount = GrdAmount + Val(.Text)
            End With
        Next
        For i = 1 To sSGrid_Oth.DataRowCnt
            Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
            GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
            With sSGrid_Oth
                .Col = 3
                .Row = i
                GrdRate = Val(.Text)
                Qty = 1
                .Col = 7
                .Row = i
                ChargeCode = Trim(.Text)
                sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                GConnection.getDataSet(sqlstring, "CODE_CHECK")
                If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                    ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                End If
                sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                GConnection.getDataSet(sqlstring, "TAXON")
                If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                    For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                        If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                            Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZero = GZero + Zero
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                            ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroA = GZeroA + ZeroA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                            ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroB = GZeroB + ZeroB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                            One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOne = GOne + One
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                            OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneA = GOneA + OneA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                            OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneB = GOneB + OneB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                            Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwo = GTwo + Two
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                            TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoA = GTwoA + TwoA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                            TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoB = GTwoB + TwoB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                            Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThree = GThree + Three
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                            ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeA = GThreeA + ThreeA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                            ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeB = GThreeB + ThreeB
                        End If
                    Next
                    GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                End If
                TotAmt = TotAmt + (Val(GrdRate) * Qty)
                TotTaxAmt = TotTaxAmt + (Val(GrdTaxAmt) * Qty)
                TotBillAmt = TotBillAmt + ((Val(GrdTaxAmt) * Qty) + (Val(GrdRate) * Qty))
                .SetText(4, i, Val(GrdRate) * Qty)
                .SetText(5, i, (Val(GrdTaxAmt) * Qty))
                .SetText(6, i, (Val(GrdTaxAmt) * Qty) + (Val(GrdRate) * Qty))
            End With
        Next
    End Sub
    Public Sub DupCheck(ByVal SS As Object)
        Dim Code1, Code2 As String
        Dim rowid As Integer
        Dup = True
        For i = 1 To SS.DataRowCnt
            With SS
                .Col = 2
                .Row = i
                Code1 = (.Text)
                rowid = i
                For j = 1 To SS.DataRowCnt
                    .Col = 2
                    .Row = j
                    Code2 = (.Text)
                    If Code1 = Code2 And rowid <> j Then
                        MessageBox.Show("Duplicate Item Not allowed")
                        Dup = False
                        Exit Sub
                    End If
                Next
            End With
        Next
    End Sub
    Private Sub BookingDetAdd()
        Dim RATE, AMOUNT, GRDTAXAMOUNT As Double
        Dim vat, stax As Double
        Dim TPercent, RoomPer, PartyPer As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, PKOTAMT As Double
        Dim taxtype As String

        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, Pos, KStatus As String
        Dim Qty As Integer

        ReDim InsertBook(0)
       
        Call Calculate_Arrange()
        Call Calculate_Others()
        
        If Mid(CmdAdd.Text, 1, 1) = "A" Then
            sqlstring = "INSERT INTO PARTY_HDR(LOCCODE,BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,PARTYDATE,MCODE,GUESTNAME,"
            sqlstring = sqlstring & "OCCUPANCY,veg,nonveg,HALLTAXFLAG,"
            sqlstring = sqlstring & "FREEZE,ADDUSERID,ADDDATETIME,vegcode,MENUCODE,nonvegcode) "
            sqlstring = sqlstring & " VALUES('" & Trim(Cmb_Location.Text) & "','" & Trim(CMBBOOKINGTYPE.Text) & "'," & Trim(Txt_BookingNo.Text)
            sqlstring = sqlstring & ",'" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy HH:mm:ss") & "'"
            sqlstring = sqlstring & ",'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "'"
            sqlstring = sqlstring & ",'" & Trim(Txt_MemberCode.Text) & "'"
            sqlstring = sqlstring & ",'" & Trim(Txt_GuestName.Text) & "'"
            sqlstring = sqlstring & "," & IIf(Val(Txt_TotPax.Text) > 0, Val(Txt_TotPax.Text), 0)
            sqlstring = sqlstring & "," & IIf(Val(Txt_VPax.Text) > 0, Val(Txt_VPax.Text), 0)
            sqlstring = sqlstring & "," & IIf(Val(Txt_NVPax.Text) > 0, Val(Txt_NVPax.Text), 0)
            sqlstring = sqlstring & ",'Y','N'"
            sqlstring = sqlstring & ",'" & Trim(gUsername) & "'"
            sqlstring = sqlstring & ",Getdate()"
            sqlstring = sqlstring & ",'" & Trim(Txt_VMenuCode.Text) & "'"
            sqlstring = sqlstring & ",''"
            sqlstring = sqlstring & ",'" & Trim(Txt_NVMenuCode.Text) & "')"
            InsertBook(0) = sqlstring
            sqlstring = "UPDATE PARTY_HDR SET ASSOCIATENAME = H.ASSOCIATENAME,HALLAMOUNT = H.TOTALAMOUNT,HALLTAXAMOUNT = H.HallTaxAmount,MCODE = H.MCODE,GUESTNAME = H.GUESTNAME  FROM party_hallbooking_hdr H,PARTY_HDR P WHERE H.BOOKINGNO = P.BOOKINGNO AND P.BOOKINGTYPE = 'BOOKING' AND H.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring

            '-- Veg Menu Insertion
            With sSGrid_VPax
                If .DataRowCnt > 0 Then
                    sqlstring = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & Txt_VMenuCode.Text & "' AND CATEGORY='VEG'"
                    GCONNECTION.getDataSet(sqlstring, "TARIFF")
                    If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                        RATE = Val(gdataset.Tables("TARIFF").Rows(0).Item("RATE"))
                        ChargeCode = gdataset.Tables("TARIFF").Rows(0).Item("TAXCODE")
                    End If
                    sqlstring = "INSERT INTO PARTY_RESTAURANT(UOM,LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                    sqlstring = sqlstring & " ITEMCODE,QTY,RATE,AMOUNT,TAXCODE,TARIFFCODE,MAXITEMS,"
                    sqlstring = sqlstring & " TYPE,FREEZE,ADDUSERID,ADDDATETIME)"
                    sqlstring = sqlstring & " VALUES('NOS','" & Trim(Cmb_Location.Text) & "'," & Txt_BookingNo.Text
                    sqlstring = sqlstring & ",'" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "'"
                    sqlstring = sqlstring & ",'" & CMBBOOKINGTYPE.Text & "','T'"
                    sqlstring = sqlstring & ",'" & Txt_VMenuCode.Text & "'"
                    sqlstring = sqlstring & "," & Val(Txt_VPax.Text) & ""
                    sqlstring = sqlstring & "," & RATE & ""
                    sqlstring = sqlstring & "," & (Val(Txt_VPax.Text) * RATE) & ""
                    sqlstring = sqlstring & ",'" & ChargeCode & "'"
                    sqlstring = sqlstring & ",'" & Txt_VMenuCode.Text & "'"
                    sqlstring = sqlstring & "," & Val(Txt_VMaxItem.Text) & ""
                    sqlstring = sqlstring & ",'VEG'"
                    sqlstring = sqlstring & ",'N'"
                    sqlstring = sqlstring & ",'" & Trim(gUsername) & "'"
                    sqlstring = sqlstring & ",GETDATE())"
                    ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring
                    For I = 1 To .DataRowCnt
                        .Col = 2
                        .Row = I
                        If (.Text <> "") Then
                            sqlstring = "INSERT INTO PARTY_RESTAURANT_DET(BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                            sqlstring = sqlstring & " ITEMCODE,ITEMDESC,UOM,QTY,GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS,"
                            sqlstring = sqlstring & " FREEZE,ADDUSERID,ADDDATETIME)"
                            sqlstring = sqlstring & " VALUES(" & Txt_BookingNo.Text
                            sqlstring = sqlstring & ",'" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "'"
                            sqlstring = sqlstring & ",'" & CMBBOOKINGTYPE.Text & "','VEG'"
                            .Col = 2
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 3
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 4
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 5
                            .Row = I
                            sqlstring = sqlstring & "," & Val(.Text) & ""
                            sqlstring = sqlstring & ",''"
                            .Col = 1
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            sqlstring = sqlstring & ",'" & Trim(Txt_VMenuCode.Text) & "'"
                            .Col = 6
                            .Row = I
                            sqlstring = sqlstring & "," & Val(.Text) & ""
                            sqlstring = sqlstring & ",'N'"
                            sqlstring = sqlstring & ",'" & Trim(gUsername) & "'"
                            sqlstring = sqlstring & ",GETDATE())"
                            ReDim Preserve InsertBook(InsertBook.Length)
                            InsertBook(InsertBook.Length - 1) = sqlstring
                        End If
                    Next
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    GrdRate = RATE
                    Qty = Val(Txt_VPax.Text)
                    ChargeCode = ChargeCode
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    GCONNECTION.getDataSet(sqlstring, "TAXON")
                    If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                        For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                            IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                            Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                            Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                            TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")
                            sqlstring = "INSERT INTO PARTY_RESTAURANT_TAX (BOOKINGNO,BOOKINGDATE,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TTYPE,TAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME,BOOKINGTYPE) VALUES ( "
                            sqlstring = sqlstring & "'" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd-MMM-yyyy") & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "','" & Trim(Txt_VMenuCode.Text) & "'," & (GrdRate) & "," & (Qty) & "," & (TPercent) & ",'VEG',"
                            If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZero = GZero + Zero
                                sqlstring = sqlstring & "" & Val(Zero) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroA = GZeroA + ZeroA
                                sqlstring = sqlstring & "" & Val(ZeroA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroB = GZeroB + ZeroB
                                sqlstring = sqlstring & "" & Val(ZeroB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOne = GOne + One
                                sqlstring = sqlstring & "" & Val(One) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneA = GOneA + OneA
                                sqlstring = sqlstring & "" & Val(OneA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneB = GOneB + OneB
                                sqlstring = sqlstring & "" & Val(OneB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwo = GTwo + Two
                                sqlstring = sqlstring & "" & Val(Two) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoA = GTwoA + TwoA
                                sqlstring = sqlstring & "" & Val(TwoA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoB = GTwoB + TwoB
                                sqlstring = sqlstring & "" & Val(TwoB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThree = GThree + Three
                                sqlstring = sqlstring & "" & Val(Three) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeA = GThreeA + ThreeA
                                sqlstring = sqlstring & "" & Val(ThreeA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeB = GThreeB + ThreeB
                                sqlstring = sqlstring & "" & Val(ThreeB) * Qty & ","
                            End If
                            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate(),'BOOKING')"
                            ReDim Preserve InsertBook(InsertBook.Length)
                            InsertBook(InsertBook.Length - 1) = sqlstring
                        Next
                    End If
                End If
            End With
            '-- Non Veg Menu Insertion
            With sSGrid_NVPax
                If .DataRowCnt > 0 Then
                    sqlstring = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & Txt_NVMenuCode.Text & "' AND CATEGORY='NON VEG'"
                    GCONNECTION.getDataSet(sqlstring, "TARIFF")
                    If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                        RATE = Val(gdataset.Tables("TARIFF").Rows(0).Item("RATE"))
                        ChargeCode = gdataset.Tables("TARIFF").Rows(0).Item("TAXCODE")
                    End If
                    sqlstring = "INSERT INTO PARTY_RESTAURANT(UOM,LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                    sqlstring = sqlstring & " ITEMCODE,QTY,RATE,AMOUNT,TAXCODE,TARIFFCODE,MAXITEMS,"
                    sqlstring = sqlstring & " TYPE,FREEZE,ADDUSERID,ADDDATETIME)"
                    sqlstring = sqlstring & " VALUES('NOS','" & Trim(Cmb_Location.Text) & "'," & Txt_BookingNo.Text
                    sqlstring = sqlstring & ",'" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "'"
                    sqlstring = sqlstring & ",'" & CMBBOOKINGTYPE.Text & "','T'"
                    sqlstring = sqlstring & ",'" & Txt_NVMenuCode.Text & "'"
                    sqlstring = sqlstring & "," & Val(Txt_NVPax.Text) & ""
                    sqlstring = sqlstring & "," & RATE & ""
                    sqlstring = sqlstring & "," & (Val(Txt_NVPax.Text) * RATE) & ""
                    sqlstring = sqlstring & ",'" & ChargeCode & "'"
                    sqlstring = sqlstring & ",'" & Txt_NVMenuCode.Text & "'"
                    sqlstring = sqlstring & "," & Val(Txt_NVMaxItem.Text) & ""
                    sqlstring = sqlstring & ",'NONVEG'"
                    sqlstring = sqlstring & ",'N'"
                    sqlstring = sqlstring & ",'" & Trim(gUsername) & "'"
                    sqlstring = sqlstring & ",GETDATE())"
                    ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring
                    For I = 1 To .DataRowCnt
                        .Col = 2
                        .Row = I
                        If (.Text <> "") Then
                            sqlstring = "INSERT INTO PARTY_RESTAURANT_DET(BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                            sqlstring = sqlstring & " ITEMCODE,ITEMDESC,UOM,QTY,GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS,"
                            sqlstring = sqlstring & " FREEZE,ADDUSERID,ADDDATETIME)"
                            sqlstring = sqlstring & " VALUES(" & Txt_BookingNo.Text
                            sqlstring = sqlstring & ",'" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "'"
                            sqlstring = sqlstring & ",'" & CMBBOOKINGTYPE.Text & "','NONVEG'"
                            .Col = 2
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 3
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 4
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 5
                            .Row = I
                            sqlstring = sqlstring & "," & Val(.Text) & ""
                            sqlstring = sqlstring & ",''"
                            .Col = 1
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            sqlstring = sqlstring & ",'" & Trim(Txt_NVMenuCode.Text) & "'"
                            .Col = 6
                            .Row = I
                            sqlstring = sqlstring & "," & Val(.Text) & ""
                            sqlstring = sqlstring & ",'N'"
                            sqlstring = sqlstring & ",'" & Trim(gUsername) & "'"
                            sqlstring = sqlstring & ",GETDATE())"
                            ReDim Preserve InsertBook(InsertBook.Length)
                            InsertBook(InsertBook.Length - 1) = sqlstring
                        End If
                    Next
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    GrdRate = RATE
                    Qty = Val(Txt_NVPax.Text)
                    ChargeCode = ChargeCode
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    GCONNECTION.getDataSet(sqlstring, "TAXON")
                    If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                        For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                            IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                            Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                            Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                            TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")
                            sqlstring = "INSERT INTO PARTY_RESTAURANT_TAX (BOOKINGNO,BOOKINGDATE,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TTYPE,TAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME,BOOKINGTYPE) VALUES ( "
                            sqlstring = sqlstring & "'" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd-MMM-yyyy") & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "','" & Trim(Txt_NVMenuCode.Text) & "'," & (GrdRate) & "," & (Qty) & "," & (TPercent) & ",'NONVEG',"
                            If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZero = GZero + Zero
                                sqlstring = sqlstring & "" & Val(Zero) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroA = GZeroA + ZeroA
                                sqlstring = sqlstring & "" & Val(ZeroA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroB = GZeroB + ZeroB
                                sqlstring = sqlstring & "" & Val(ZeroB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOne = GOne + One
                                sqlstring = sqlstring & "" & Val(One) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneA = GOneA + OneA
                                sqlstring = sqlstring & "" & Val(OneA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneB = GOneB + OneB
                                sqlstring = sqlstring & "" & Val(OneB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwo = GTwo + Two
                                sqlstring = sqlstring & "" & Val(Two) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoA = GTwoA + TwoA
                                sqlstring = sqlstring & "" & Val(TwoA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoB = GTwoB + TwoB
                                sqlstring = sqlstring & "" & Val(TwoB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThree = GThree + Three
                                sqlstring = sqlstring & "" & Val(Three) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeA = GThreeA + ThreeA
                                sqlstring = sqlstring & "" & Val(ThreeA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeB = GThreeB + ThreeB
                                sqlstring = sqlstring & "" & Val(ThreeB) * Qty & ","
                            End If
                            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate(),'BOOKING')"
                            ReDim Preserve InsertBook(InsertBook.Length)
                            InsertBook(InsertBook.Length - 1) = sqlstring
                        Next
                    End If
                End If
            End With
            sqlstring = " UPDATE PARTY_RESTAURANT SET TAXAMOUNT = (SELECT ISNULL(SUM(PARTY_RESTAURANT_TAX.TAXAMOUNT),0) FROM PARTY_RESTAURANT_TAX  WHERE PARTY_RESTAURANT.BOOKINGNO = PARTY_RESTAURANT_TAX.BOOKINGNO AND PARTY_RESTAURANT_TAX.ITEMCODE = PARTY_RESTAURANT.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(PARTY_RESTAURANT_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_RESTAURANT.BOOKINGTYPE,'') GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,'')) WHERE PARTY_RESTAURANT.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(PARTY_RESTAURANT.BOOKINGTYPE,'') = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            sqlstring = "UPDATE PARTY_RESTAURANT SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            '-- Arrangement Item Insertion 
            With sSGrid_Arr
                For i = 1 To .DataRowCnt
                    .Col = 10
                    .Row = i
                    .Text = Val(i)
                Next
                If .DataRowCnt > 0 Then
                    For i = 1 To .DataRowCnt
                        sqlstring = "INSERT INTO PARTY_ARRANGEMENT(BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,ITEMCODE,ITEMDESC,UOM,RATE,QTY,AMOUNT,TAXAMOUNT,TOTALAMOUNT,SLNO,LOCCODE,FREEZE,ADDUSERID,ADDDATETIME) Values ("
                        sqlstring = sqlstring & "'" & CMBBOOKINGTYPE.Text & "','" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "',"
                        .Row = i
                        .Col = 1
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 2
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 3
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 4
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 5
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 6
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 7
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 8
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 10
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        sqlstring = sqlstring & "'" & Trim(Cmb_Location.Text) & "','N',"
                        sqlstring = sqlstring & "'" & Trim(gUsername) & "'"
                        sqlstring = sqlstring & ",GETDATE())"
                        ReDim Preserve InsertBook(InsertBook.Length)
                        InsertBook(InsertBook.Length - 1) = sqlstring
                    Next
                    Dim Itemcode As String
                    Dim SNO As Integer
                    For i = 1 To .DataRowCnt
                        Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                        GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                        .Col = 1
                        .Row = i
                        Itemcode = Trim(.Text)
                        .Col = 4
                        .Row = i
                        GrdRate = .Text
                        .Col = 5
                        .Row = i
                        Qty = .Text
                        .Col = 10
                        .Row = i
                        SNO = .Text
                        .Col = 9
                        .Row = i
                        ChargeCode = Trim(.Text)
                        sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(sqlstring, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                                Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                                sqlstring = "INSERT INTO party_arrangement_TAX(BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,CHARGECODE,TAXCODE,TAXON,TAXPERC,ITEMCODE,RATE,QTY,SLNO,TAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME) VALUES ( "
                                sqlstring = sqlstring & "'" & CMBBOOKINGTYPE.Text & "','" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd-MMM-yyyy") & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (TPercent) & ",'" & Trim(Itemcode) & "'," & (GrdRate) & "," & (Qty) & "," & (SNO) & ","

                                If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                    Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    sqlstring = sqlstring & "" & Val(Zero) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    sqlstring = sqlstring & "" & Val(ZeroA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    sqlstring = sqlstring & "" & Val(ZeroB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                    One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    sqlstring = sqlstring & "" & Val(One) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    sqlstring = sqlstring & "" & Val(OneA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    sqlstring = sqlstring & "" & Val(OneB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                    Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    sqlstring = sqlstring & "" & Val(Two) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    sqlstring = sqlstring & "" & Val(TwoA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    sqlstring = sqlstring & "" & Val(TwoB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                    Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    sqlstring = sqlstring & "" & Val(Three) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    sqlstring = sqlstring & "" & Val(ThreeA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    sqlstring = sqlstring & "" & Val(ThreeB) * Qty & ","
                                End If
                                sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate())"
                                ReDim Preserve InsertBook(InsertBook.Length)
                                InsertBook(InsertBook.Length - 1) = sqlstring
                            Next
                        End If
                    Next
                End If
            End With
            sqlstring = " UPDATE PARTY_ARRANGEMENT SET TAXAMOUNT = (SELECT ISNULL(SUM(party_arrangement_TAX.TAXAMOUNT),0) FROM party_arrangement_TAX  WHERE PARTY_ARRANGEMENT.BOOKINGNO = party_arrangement_TAX.BOOKINGNO AND party_arrangement_TAX.ITEMCODE = PARTY_ARRANGEMENT.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(party_arrangement_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') AND ISNULL(party_arrangement_TAX.SLNO,0) = ISNULL(PARTY_ARRANGEMENT.SLNO,0) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''),ISNULL(SLNO,0)) WHERE PARTY_ARRANGEMENT.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            sqlstring = "UPDATE PARTY_ARRANGEMENT SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring

            '-- Others Item Insertion 
            With sSGrid_Oth
                For i = 1 To .DataRowCnt
                    .Col = 8
                    .Row = i
                    .Text = Val(i)
                Next
                If .DataRowCnt > 0 Then
                    For i = 1 To .DataRowCnt
                        sqlstring = "INSERT INTO Party_OtherCharges(BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,ITEMCODE,ITEMDESC,UOM,RATE,QTY,AMOUNT,TAXAMOUNT,TOTALAMOUNT,SLNO,LOCCODE,FREEZE,ADDUSERID,ADDDATETIME) Values ("
                        sqlstring = sqlstring & "'" & CMBBOOKINGTYPE.Text & "','" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "',"
                        .Row = i
                        .Col = 1
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 2
                        sqlstring = sqlstring & "'" & Trim(.Text) & "','NOS',"
                        .Col = 3
                        sqlstring = sqlstring & "'" & Val(.Text) & "',1,"
                        .Col = 4
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 5
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 6
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 8
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        sqlstring = sqlstring & "'" & Trim(Cmb_Location.Text) & "','N',"
                        sqlstring = sqlstring & "'" & Trim(gUsername) & "'"
                        sqlstring = sqlstring & ",GETDATE())"
                        ReDim Preserve InsertBook(InsertBook.Length)
                        InsertBook(InsertBook.Length - 1) = sqlstring
                    Next
                    Dim Itemcode As String
                    Dim SNO As Integer
                    For i = 1 To .DataRowCnt
                        Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                        GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                        .Col = 1
                        .Row = i
                        Itemcode = Trim(.Text)
                        .Col = 3
                        .Row = i
                        GrdRate = .Text
                        Qty = 1
                        .Col = 8
                        .Row = i
                        SNO = .Text
                        .Col = 7
                        .Row = i
                        ChargeCode = Trim(.Text)
                        sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(sqlstring, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                                Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                                sqlstring = "INSERT INTO Party_OtherCharges_Tax(BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,CHARGECODE,TAXCODE,TAXON,TAXPERC,ITEMCODE,RATE,QTY,SLNO,TAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME) VALUES ( "
                                sqlstring = sqlstring & "'" & CMBBOOKINGTYPE.Text & "','" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd-MMM-yyyy") & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (TPercent) & ",'" & Trim(Itemcode) & "'," & (GrdRate) & "," & (Qty) & "," & (SNO) & ","

                                If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                    Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    sqlstring = sqlstring & "" & Val(Zero) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    sqlstring = sqlstring & "" & Val(ZeroA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    sqlstring = sqlstring & "" & Val(ZeroB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                    One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    sqlstring = sqlstring & "" & Val(One) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    sqlstring = sqlstring & "" & Val(OneA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    sqlstring = sqlstring & "" & Val(OneB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                    Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    sqlstring = sqlstring & "" & Val(Two) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    sqlstring = sqlstring & "" & Val(TwoA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    sqlstring = sqlstring & "" & Val(TwoB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                    Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    sqlstring = sqlstring & "" & Val(Three) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    sqlstring = sqlstring & "" & Val(ThreeA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    sqlstring = sqlstring & "" & Val(ThreeB) * Qty & ","
                                End If
                                sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate())"
                                ReDim Preserve InsertBook(InsertBook.Length)
                                InsertBook(InsertBook.Length - 1) = sqlstring
                            Next
                        End If
                    Next
                End If
            End With
            sqlstring = "  UPDATE Party_OtherCharges SET TAXAMOUNT = (SELECT ISNULL(SUM(Party_OtherCharges_Tax.TAXAMOUNT),0) FROM Party_OtherCharges_Tax  WHERE Party_OtherCharges.BOOKINGNO = Party_OtherCharges_Tax.BOOKINGNO AND Party_OtherCharges_Tax.ITEMCODE = Party_OtherCharges.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(Party_OtherCharges_Tax.BOOKINGTYPE,'') = ISNULL(Party_OtherCharges.BOOKINGTYPE,'') AND ISNULL(Party_OtherCharges_Tax.SLNO,0) = ISNULL(Party_OtherCharges.SLNO,0) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''),ISNULL(SLNO,0)) WHERE Party_OtherCharges.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(Party_OtherCharges.BOOKINGTYPE,'') = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            sqlstring = "UPDATE Party_OtherCharges SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring

            If Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BILLINGFLAG='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve InsertBook(InsertBook.Length)
                InsertBook(InsertBook.Length - 1) = SSQL

            ElseIf Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BOOKINGFLAG='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve InsertBook(InsertBook.Length)
                InsertBook(InsertBook.Length - 1) = SSQL
            End If
            With sSGrid_Kot
                If .DataRowCnt > 0 Then
                    sqlstring = "DELETE FROM PARTY_KOT_DET WHERE KOTDETAILS = '" & Txt_BookingNo.Text & "'"
                    ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM PARTY_KOT_DET_TAX WHERE KOTDETAILS = '" & Txt_BookingNo.Text & "'"
                    ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring

                    sqlstring = "INSERT INTO PARTY_KOT_DET (KOTNO,KOTDETAILS,KOTDATE,BILLDETAILS,CATEGORY,ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE, "
                    sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,KOTTYPE,ALCHOLST,CHITNO,PAYMENTMODE,DelFlag,AddUserid,Adddatetime,UpdUserid,Upddatetime,PACKAMT,DISCAMT,PACKPERCENT,"
                    sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,PDA_PRINT_FLAG,PDA_DELETE_FLAG,IS_PDA,SUBGroupCode,TipsPer,TipsAmt,AdCgsPer,AdCgsAmt,PartyPer,PartyAmt,RoomPer,RoomAmt,MKOTNO,BOOKINGTYPE,SNO) "
                    If Mid(gCompName, 1, 2) = "HC" Then
                        sqlstring = sqlstring & " SELECT '" & Txt_BookingNo.Text & "','" & Txt_BookingNo.Text & "',KOTDATE,'" & Txt_BookingNo.Text & "','PAR',ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE,"
                        sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,'PAR',ALCHOLST,0,PAYMENTMODE,DelFlag,'CHS',GETDATE(),UpdUserid,GETDATE(),PACKAMT,DISCAMT,PACKPERCENT,"
                        sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,'','','',GroupCode,TIPSPERCENT,TIPSAMOUNT,0,0,0,0,0,0,KOTDETAILS,'BOOKING',0"
                        sqlstring = sqlstring & " FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "')  AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> ''  "
                    Else
                        sqlstring = sqlstring & " SELECT '" & Txt_BookingNo.Text & "','" & Txt_BookingNo.Text & "',KOTDATE,'" & Txt_BookingNo.Text & "',CATEGORY,ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE,"
                        sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,'PAR',ALCHOLST,CHITNO,PAYMENTMODE,DelFlag,'" & Trim(gUsername) & "',GETDATE(),UpdUserid,GETDATE(),PACKAMT,DISCAMT,PACKPERCENT,"
                        sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,ISNULL(PDA_PRINT_FLAG,''),ISNULL(PDA_DELETE_FLAG,''),ISNULL(IS_PDA,''),SUBGroupCode,TipsPer,TipsAmt,AdCgsPer,AdCgsAmt,PartyPer,PartyAmt,RoomPer,RoomAmt,KOTDETAILS,'BOOKING',SLNO"
                        sqlstring = sqlstring & " FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "')  AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> ''  "
                    End If
                    ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring
                    sqlstring = "INSERT INTO PARTY_KOT_DET_TAX (KOTDETAILS,KOTDATE,TTYPE,CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,ADD_USER,ADD_DATE,VOID,VOIDUSER,SNO)"
                    sqlstring = sqlstring & "SELECT '" & Txt_BookingNo.Text & "',KOTDATE,'PAR',CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,'" & Trim(gUsername) & "',GETDATE(),VOID,'',SLNO"
                    sqlstring = sqlstring & " FROM KOT_DET_TAX WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "')"
                    ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring
                End If
            End With

        ElseIf Mid(CmdAdd.Text, 1, 1) = "U" Then
            If Me.lbl_Freeze.Visible = True Then
                MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
                boolchk = False
            End If
            sqlstring = "UPDATE  PARTY_HDR SET "
            sqlstring = sqlstring & " LOCCODE='" & Trim(Cmb_Location.Text) & "',"
            sqlstring = sqlstring & " BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & ",PARTYDATE='" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "'"
            sqlstring = sqlstring & ",MCODE='" & Trim(Txt_MemberCode.Text) & "'"
            sqlstring = sqlstring & ",ASSOCIATENAME='" & Trim(Txt_MemberName.Text) & "'"
            sqlstring = sqlstring & ",OCCUPANCY=" & Trim(Txt_TotPax.Text)
            sqlstring = sqlstring & ",veg=" & Trim(Txt_VPax.Text)
            sqlstring = sqlstring & ",nonveg=" & Trim(Txt_NVPax.Text)
            sqlstring = sqlstring & ",vegcode='" & Trim(Txt_VMenuCode.Text) & "'"
            sqlstring = sqlstring & ",nonvegcode='" & Trim(Txt_NVMenuCode.Text) & "'"
            sqlstring = sqlstring & ",DESCRIPTION='" & Trim(Txt_Purpose.Text) & "'"
            sqlstring = sqlstring & ",GUESTNAME='" & Trim(Txt_GuestName.Text) & "'"
            sqlstring = sqlstring & ",HALLTAXFLAG='Y' "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' "
            InsertBook(0) = sqlstring
            sqlstring = "UPDATE PARTY_HDR SET ASSOCIATENAME = H.ASSOCIATENAME,HALLAMOUNT = H.TOTALAMOUNT,HALLTAXAMOUNT = H.HallTaxAmount,MCODE = H.MCODE,GUESTNAME = H.GUESTNAME,OCCUPANCY = H.OCCUPANCY,veg = H.veg,nonveg = H.nonveg  FROM party_hallbooking_hdr H,PARTY_HDR P WHERE H.BOOKINGNO = P.BOOKINGNO AND P.BOOKINGTYPE = 'BOOKING' AND H.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring

            If Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BILLINGFLAG='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text
                ReDim Preserve InsertBook(InsertBook.Length)
                InsertBook(InsertBook.Length - 1) = SSQL
            ElseIf Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BOOKINGFLAG='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve InsertBook(InsertBook.Length)
                InsertBook(InsertBook.Length - 1) = SSQL
            ElseIf Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                Dim HRS, OCC As Integer
                Dim TRATE, CANRATE, CANAMT, CANHEAD, CANFROM, CANTO As Double
                SSQL = "SELECT ISNULL(T.RATE,0)AS RATE,ISNULL(H.TARIFFCODE,'')AS TARIFF,H.BOOKINGDATE,ISNULL(P.OCCUPANCY,0)AS OCCUPANCY "
                SSQL = SSQL & " FROM PARTY_HALLBOOKING_HDR H,"
                SSQL = SSQL & " PARTY_HDR P,PARTY_TARIFFHDR T "
                SSQL = SSQL & " WHERE H.BOOKINGNO=P.BOOKINGNO AND P.BOOKINGDATE=H.BOOKINGDATE AND "
                SSQL = SSQL & " H.TARIFFCODE = T.TARIFFCODE AND H.BOOKINGNO=" & Val(Txt_BookingNo.Text) & " AND P.LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                SSQL = SSQL & " GROUP BY T.RATE,H.TARIFFCODE,H.BOOKINGDATE,P.OCCUPANCY"
                GCONNECTION.getDataSet(SSQL, "book")
                If gdataset.Tables("book").Rows.Count > 0 Then
                    HRS = DateDiff(DateInterval.Hour, gdataset.Tables("book").Rows(0).Item("BOOKINGDATE"), Now())
                    OCC = gdataset.Tables("book").Rows(0).Item("OCCUPANCY")
                    TRATE = gdataset.Tables("book").Rows(0).Item("RATE")
                End If
                SSQL = "SELECT ISNULL(CANCELFROM,0)AS CANCELFROM,ISNULL(CANCELTO,0)AS CANCELTO,ISNULL(CANCEL_AMT_PER,0)AS PERAMT,ISNULL(CANCEL_AMT_HEAD,0)AS HEADAMT,ISNULL(FIXEDAMOUNT,0)AS FIXAMT FROM PARTY_CANCELLATIONMASTER WHERE " & Val(HRS) & " BETWEEN CANCELFROM AND CANCELTO "
                GCONNECTION.getDataSet(SSQL, "CANCEL")
                If gdataset.Tables("CANCEL").Rows.Count > 0 Then
                    CANHEAD = gdataset.Tables("CANCEL").Rows(0).Item("CANCEL_AMT_HEAD")
                    CANRATE = gdataset.Tables("CANCEL").Rows(0).Item("FIXEDAMOUNT")
                    CANFROM = gdataset.Tables("CANCEL").Rows(0).Item("CANCELFROM")
                    CANTO = gdataset.Tables("CANCEL").Rows(0).Item("CANCELTO")
                    CANAMT = (Val(OCC) * TRATE) + (Val(OCC) * Val(CANHEAD)) + Val(CANRATE)
                End If
                SSQL = " UPDATE  PARTY_HDR SET FREEZE='Y',HALLCANCELAMOUNT=" & Val(CANAMT) & ",FROMHRS=" & Val(CANFROM) & ",TOHRS=" & Val(CANTO) & ",CANCELDATE='" & Format(DateTime.Now, "dd/MMM/yyyy hh:mm:ss") & "' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve InsertBook(InsertBook.Length)
                InsertBook(InsertBook.Length - 1) = SSQL

                SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET CANCELFLAG='Y',FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve InsertBook(InsertBook.Length)
                InsertBook(InsertBook.Length - 1) = SSQL

                SSQL = " UPDATE  PARTY_HALLBOOKING_DET SET FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve InsertBook(InsertBook.Length)
                InsertBook(InsertBook.Length - 1) = SSQL

                SSQL = " UPDATE PARTY_RECEIPT SET FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve InsertBook(InsertBook.Length)
                InsertBook(InsertBook.Length - 1) = SSQL

                SSQL = " UPDATE PARTY_RESTAURANT SET FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve InsertBook(InsertBook.Length)
                InsertBook(InsertBook.Length - 1) = SSQL

                SSQL = " UPDATE PARTY_ARRANGEMENT SET FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve InsertBook(InsertBook.Length)
                InsertBook(InsertBook.Length - 1) = SSQL

                SSQL = " UPDATE PARTY_HALLFACILITY SET FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve InsertBook(InsertBook.Length)
                InsertBook(InsertBook.Length - 1) = SSQL
            End If
            '-- Veg Menu Deletion
            sqlstring = " DELETE FROM PARTY_RESTAURANT "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND TTYPE='T'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' AND TYPE='VEG' AND ITEMCODE='" & Trim(Txt_VMenuCode.Text) & "'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            sqlstring = " DELETE FROM PARTY_RESTAURANT_DET "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND TTYPE='VEG' AND TARIFFCODE='" & Trim(Txt_VMenuCode.Text) & "'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            sqlstring = " DELETE FROM PARTY_RESTAURANT_TAX "
            sqlstring = sqlstring & " WHERE BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND TTYPE='VEG' AND ITEMCODE='" & Trim(Txt_VMenuCode.Text) & "' AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            '-- Veg Menu Insertion
            With sSGrid_VPax
                If .DataRowCnt > 0 Then
                    sqlstring = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & Txt_VMenuCode.Text & "' AND CATEGORY='VEG'"
                    GCONNECTION.getDataSet(sqlstring, "TARIFF")
                    If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                        RATE = Val(gdataset.Tables("TARIFF").Rows(0).Item("RATE"))
                        ChargeCode = gdataset.Tables("TARIFF").Rows(0).Item("TAXCODE")
                    End If
                    sqlstring = "INSERT INTO PARTY_RESTAURANT(UOM,LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                    sqlstring = sqlstring & " ITEMCODE,QTY,RATE,AMOUNT,TAXCODE,TARIFFCODE,MAXITEMS,"
                    sqlstring = sqlstring & " TYPE,FREEZE,ADDUSERID,ADDDATETIME)"
                    sqlstring = sqlstring & " VALUES('NOS','" & Trim(Cmb_Location.Text) & "'," & Txt_BookingNo.Text
                    sqlstring = sqlstring & ",'" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "'"
                    sqlstring = sqlstring & ",'" & CMBBOOKINGTYPE.Text & "','T'"
                    sqlstring = sqlstring & ",'" & Txt_VMenuCode.Text & "'"
                    sqlstring = sqlstring & "," & Val(Txt_VPax.Text) & ""
                    sqlstring = sqlstring & "," & RATE & ""
                    sqlstring = sqlstring & "," & (Val(Txt_VPax.Text) * RATE) & ""
                    sqlstring = sqlstring & ",'" & ChargeCode & "'"
                    sqlstring = sqlstring & ",'" & Txt_VMenuCode.Text & "'"
                    sqlstring = sqlstring & "," & Val(Txt_VMaxItem.Text) & ""
                    sqlstring = sqlstring & ",'VEG'"
                    sqlstring = sqlstring & ",'N'"
                    sqlstring = sqlstring & ",'" & Trim(gUsername) & "'"
                    sqlstring = sqlstring & ",GETDATE())"
                    ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring
                    For I = 1 To .DataRowCnt
                        .Col = 2
                        .Row = I
                        If (.Text <> "") Then
                            sqlstring = "INSERT INTO PARTY_RESTAURANT_DET(BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                            sqlstring = sqlstring & " ITEMCODE,ITEMDESC,UOM,QTY,GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS,"
                            sqlstring = sqlstring & " FREEZE,ADDUSERID,ADDDATETIME)"
                            sqlstring = sqlstring & " VALUES(" & Txt_BookingNo.Text
                            sqlstring = sqlstring & ",'" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "'"
                            sqlstring = sqlstring & ",'" & CMBBOOKINGTYPE.Text & "','VEG'"
                            .Col = 2
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 3
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 4
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 5
                            .Row = I
                            sqlstring = sqlstring & "," & Val(.Text) & ""
                            sqlstring = sqlstring & ",''"
                            .Col = 1
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            sqlstring = sqlstring & ",'" & Trim(Txt_VMenuCode.Text) & "'"
                            .Col = 6
                            .Row = I
                            sqlstring = sqlstring & "," & Val(.Text) & ""
                            sqlstring = sqlstring & ",'N'"
                            sqlstring = sqlstring & ",'" & Trim(gUsername) & "'"
                            sqlstring = sqlstring & ",GETDATE())"
                            ReDim Preserve InsertBook(InsertBook.Length)
                            InsertBook(InsertBook.Length - 1) = sqlstring
                        End If
                    Next
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    GrdRate = RATE
                    Qty = Val(Txt_VPax.Text)
                    ChargeCode = ChargeCode
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    GCONNECTION.getDataSet(sqlstring, "TAXON")
                    If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                        For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                            IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                            Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                            Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                            TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")
                            sqlstring = "INSERT INTO PARTY_RESTAURANT_TAX (BOOKINGNO,BOOKINGDATE,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TTYPE,TAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME,BOOKINGTYPE) VALUES ( "
                            sqlstring = sqlstring & "'" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd-MMM-yyyy") & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "','" & Trim(Txt_VMenuCode.Text) & "'," & (GrdRate) & "," & (Qty) & "," & (TPercent) & ",'VEG',"
                            If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZero = GZero + Zero
                                sqlstring = sqlstring & "" & Val(Zero) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroA = GZeroA + ZeroA
                                sqlstring = sqlstring & "" & Val(ZeroA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroB = GZeroB + ZeroB
                                sqlstring = sqlstring & "" & Val(ZeroB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOne = GOne + One
                                sqlstring = sqlstring & "" & Val(One) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneA = GOneA + OneA
                                sqlstring = sqlstring & "" & Val(OneA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneB = GOneB + OneB
                                sqlstring = sqlstring & "" & Val(OneB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwo = GTwo + Two
                                sqlstring = sqlstring & "" & Val(Two) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoA = GTwoA + TwoA
                                sqlstring = sqlstring & "" & Val(TwoA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoB = GTwoB + TwoB
                                sqlstring = sqlstring & "" & Val(TwoB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThree = GThree + Three
                                sqlstring = sqlstring & "" & Val(Three) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeA = GThreeA + ThreeA
                                sqlstring = sqlstring & "" & Val(ThreeA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeB = GThreeB + ThreeB
                                sqlstring = sqlstring & "" & Val(ThreeB) * Qty & ","
                            End If
                            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate(),'BOOKING')"
                            ReDim Preserve InsertBook(InsertBook.Length)
                            InsertBook(InsertBook.Length - 1) = sqlstring
                        Next
                    End If
                End If
            End With
            '-- Non Veg Menu Deletion
            sqlstring = " DELETE FROM PARTY_RESTAURANT "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND TTYPE='T'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' AND TYPE='NONVEG' AND ITEMCODE='" & Trim(Txt_NVMenuCode.Text) & "'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            sqlstring = " DELETE FROM PARTY_RESTAURANT_DET "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND TTYPE='NONVEG' AND TARIFFCODE='" & Trim(Txt_NVMenuCode.Text) & "'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            sqlstring = " DELETE FROM PARTY_RESTAURANT_TAX "
            sqlstring = sqlstring & " WHERE BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND TTYPE='NONVEG' AND ITEMCODE='" & Trim(Txt_NVMenuCode.Text) & "' AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            '-- Non Veg Menu Insertion
            With sSGrid_NVPax
                If .DataRowCnt > 0 Then
                    sqlstring = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & Txt_NVMenuCode.Text & "' AND CATEGORY='NON VEG'"
                    GCONNECTION.getDataSet(sqlstring, "TARIFF")
                    If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                        RATE = Val(gdataset.Tables("TARIFF").Rows(0).Item("RATE"))
                        ChargeCode = gdataset.Tables("TARIFF").Rows(0).Item("TAXCODE")
                    End If
                    sqlstring = "INSERT INTO PARTY_RESTAURANT(UOM,LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                    sqlstring = sqlstring & " ITEMCODE,QTY,RATE,AMOUNT,TAXCODE,TARIFFCODE,MAXITEMS,"
                    sqlstring = sqlstring & " TYPE,FREEZE,ADDUSERID,ADDDATETIME)"
                    sqlstring = sqlstring & " VALUES('NOS','" & Trim(Cmb_Location.Text) & "'," & Txt_BookingNo.Text
                    sqlstring = sqlstring & ",'" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "'"
                    sqlstring = sqlstring & ",'" & CMBBOOKINGTYPE.Text & "','T'"
                    sqlstring = sqlstring & ",'" & Txt_NVMenuCode.Text & "'"
                    sqlstring = sqlstring & "," & Val(Txt_NVPax.Text) & ""
                    sqlstring = sqlstring & "," & RATE & ""
                    sqlstring = sqlstring & "," & (Val(Txt_NVPax.Text) * RATE) & ""
                    sqlstring = sqlstring & ",'" & ChargeCode & "'"
                    sqlstring = sqlstring & ",'" & Txt_NVMenuCode.Text & "'"
                    sqlstring = sqlstring & "," & Val(Txt_NVMaxItem.Text) & ""
                    sqlstring = sqlstring & ",'NONVEG'"
                    sqlstring = sqlstring & ",'N'"
                    sqlstring = sqlstring & ",'" & Trim(gUsername) & "'"
                    sqlstring = sqlstring & ",GETDATE())"
                    ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring
                    For I = 1 To .DataRowCnt
                        .Col = 2
                        .Row = I
                        If (.Text <> "") Then
                            sqlstring = "INSERT INTO PARTY_RESTAURANT_DET(BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                            sqlstring = sqlstring & " ITEMCODE,ITEMDESC,UOM,QTY,GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS,"
                            sqlstring = sqlstring & " FREEZE,ADDUSERID,ADDDATETIME)"
                            sqlstring = sqlstring & " VALUES(" & Txt_BookingNo.Text
                            sqlstring = sqlstring & ",'" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "'"
                            sqlstring = sqlstring & ",'" & CMBBOOKINGTYPE.Text & "','NONVEG'"
                            .Col = 2
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 3
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 4
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            .Col = 5
                            .Row = I
                            sqlstring = sqlstring & "," & Val(.Text) & ""
                            sqlstring = sqlstring & ",''"
                            .Col = 1
                            .Row = I
                            sqlstring = sqlstring & ",'" & Trim(.Text) & "'"
                            sqlstring = sqlstring & ",'" & Trim(Txt_NVMenuCode.Text) & "'"
                            .Col = 6
                            .Row = I
                            sqlstring = sqlstring & "," & Val(.Text) & ""
                            sqlstring = sqlstring & ",'N'"
                            sqlstring = sqlstring & ",'" & Trim(gUsername) & "'"
                            sqlstring = sqlstring & ",GETDATE())"
                            ReDim Preserve InsertBook(InsertBook.Length)
                            InsertBook(InsertBook.Length - 1) = sqlstring
                        End If
                    Next
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    GrdRate = RATE
                    Qty = Val(Txt_NVPax.Text)
                    ChargeCode = ChargeCode
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    GCONNECTION.getDataSet(sqlstring, "TAXON")
                    If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                        For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                            IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                            Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                            Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                            TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")
                            sqlstring = "INSERT INTO PARTY_RESTAURANT_TAX (BOOKINGNO,BOOKINGDATE,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TTYPE,TAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME,BOOKINGTYPE) VALUES ( "
                            sqlstring = sqlstring & "'" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd-MMM-yyyy") & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "','" & Trim(Txt_NVMenuCode.Text) & "'," & (GrdRate) & "," & (Qty) & "," & (TPercent) & ",'NONVEG',"
                            If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZero = GZero + Zero
                                sqlstring = sqlstring & "" & Val(Zero) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroA = GZeroA + ZeroA
                                sqlstring = sqlstring & "" & Val(ZeroA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroB = GZeroB + ZeroB
                                sqlstring = sqlstring & "" & Val(ZeroB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOne = GOne + One
                                sqlstring = sqlstring & "" & Val(One) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneA = GOneA + OneA
                                sqlstring = sqlstring & "" & Val(OneA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneB = GOneB + OneB
                                sqlstring = sqlstring & "" & Val(OneB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwo = GTwo + Two
                                sqlstring = sqlstring & "" & Val(Two) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoA = GTwoA + TwoA
                                sqlstring = sqlstring & "" & Val(TwoA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoB = GTwoB + TwoB
                                sqlstring = sqlstring & "" & Val(TwoB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThree = GThree + Three
                                sqlstring = sqlstring & "" & Val(Three) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeA = GThreeA + ThreeA
                                sqlstring = sqlstring & "" & Val(ThreeA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeB = GThreeB + ThreeB
                                sqlstring = sqlstring & "" & Val(ThreeB) * Qty & ","
                            End If
                            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate(),'BOOKING')"
                            ReDim Preserve InsertBook(InsertBook.Length)
                            InsertBook(InsertBook.Length - 1) = sqlstring
                        Next
                    End If
                End If
            End With
            sqlstring = " UPDATE PARTY_RESTAURANT SET TAXAMOUNT = (SELECT ISNULL(SUM(PARTY_RESTAURANT_TAX.TAXAMOUNT),0) FROM PARTY_RESTAURANT_TAX  WHERE PARTY_RESTAURANT.BOOKINGNO = PARTY_RESTAURANT_TAX.BOOKINGNO AND PARTY_RESTAURANT_TAX.ITEMCODE = PARTY_RESTAURANT.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(PARTY_RESTAURANT_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_RESTAURANT.BOOKINGTYPE,'') GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,'')) WHERE PARTY_RESTAURANT.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(PARTY_RESTAURANT.BOOKINGTYPE,'') = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            sqlstring = "UPDATE PARTY_RESTAURANT SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring

            '-- Arrangement Item Deletion
            sqlstring = " DELETE FROM PARTY_ARRANGEMENT "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring

            sqlstring = " DELETE FROM party_arrangement_TAX "
            sqlstring = sqlstring & " WHERE BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' "
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring

            '-- Arrangement Item Insertion 
            With sSGrid_Arr
                For i = 1 To .DataRowCnt
                    .Col = 10
                    .Row = i
                    .Text = Val(i)
                Next
                If .DataRowCnt > 0 Then
                    For i = 1 To .DataRowCnt
                        sqlstring = "INSERT INTO PARTY_ARRANGEMENT(BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,ITEMCODE,ITEMDESC,UOM,RATE,QTY,AMOUNT,TAXAMOUNT,TOTALAMOUNT,SLNO,LOCCODE,FREEZE,ADDUSERID,ADDDATETIME) Values ("
                        sqlstring = sqlstring & "'" & CMBBOOKINGTYPE.Text & "','" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "',"
                        .Row = i
                        .Col = 1
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 2
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 3
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 4
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 5
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 6
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 7
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 8
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 10
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        sqlstring = sqlstring & "'" & Trim(Cmb_Location.Text) & "','N',"
                        sqlstring = sqlstring & "'" & Trim(gUsername) & "'"
                        sqlstring = sqlstring & ",GETDATE())"
                        ReDim Preserve InsertBook(InsertBook.Length)
                        InsertBook(InsertBook.Length - 1) = sqlstring
                    Next
                    Dim Itemcode As String
                    Dim SNO As Integer
                    For i = 1 To .DataRowCnt
                        Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                        GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                        .Col = 1
                        .Row = i
                        Itemcode = Trim(.Text)
                        .Col = 4
                        .Row = i
                        GrdRate = .Text
                        .Col = 5
                        .Row = i
                        Qty = .Text
                        .Col = 10
                        .Row = i
                        SNO = .Text
                        .Col = 9
                        .Row = i
                        ChargeCode = Trim(.Text)
                        sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(sqlstring, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                                Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                                sqlstring = "INSERT INTO party_arrangement_TAX(BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,CHARGECODE,TAXCODE,TAXON,TAXPERC,ITEMCODE,RATE,QTY,SLNO,TAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME) VALUES ( "
                                sqlstring = sqlstring & "'" & CMBBOOKINGTYPE.Text & "','" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd-MMM-yyyy") & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (TPercent) & ",'" & Trim(Itemcode) & "'," & (GrdRate) & "," & (Qty) & "," & (SNO) & ","

                                If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                    Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    sqlstring = sqlstring & "" & Val(Zero) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    sqlstring = sqlstring & "" & Val(ZeroA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    sqlstring = sqlstring & "" & Val(ZeroB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                    One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    sqlstring = sqlstring & "" & Val(One) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    sqlstring = sqlstring & "" & Val(OneA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    sqlstring = sqlstring & "" & Val(OneB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                    Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    sqlstring = sqlstring & "" & Val(Two) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    sqlstring = sqlstring & "" & Val(TwoA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    sqlstring = sqlstring & "" & Val(TwoB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                    Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    sqlstring = sqlstring & "" & Val(Three) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    sqlstring = sqlstring & "" & Val(ThreeA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    sqlstring = sqlstring & "" & Val(ThreeB) * Qty & ","
                                End If
                                sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate())"
                                ReDim Preserve InsertBook(InsertBook.Length)
                                InsertBook(InsertBook.Length - 1) = sqlstring
                            Next
                        End If
                    Next
                End If
            End With
            sqlstring = " UPDATE PARTY_ARRANGEMENT SET TAXAMOUNT = (SELECT ISNULL(SUM(party_arrangement_TAX.TAXAMOUNT),0) FROM party_arrangement_TAX  WHERE PARTY_ARRANGEMENT.BOOKINGNO = party_arrangement_TAX.BOOKINGNO AND party_arrangement_TAX.ITEMCODE = PARTY_ARRANGEMENT.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(party_arrangement_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') AND ISNULL(party_arrangement_TAX.SLNO,0) = ISNULL(PARTY_ARRANGEMENT.SLNO,0) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''),ISNULL(SLNO,0)) WHERE PARTY_ARRANGEMENT.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            sqlstring = "UPDATE PARTY_ARRANGEMENT SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring

            '-- Others Item Deletion
            sqlstring = " DELETE FROM Party_OtherCharges "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring

            sqlstring = " DELETE FROM Party_OtherCharges_Tax "
            sqlstring = sqlstring & " WHERE BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' "
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring

            '-- Others Item Insertion 
            With sSGrid_Oth
                For i = 1 To .DataRowCnt
                    .Col = 8
                    .Row = i
                    .Text = Val(i)
                Next
                If .DataRowCnt > 0 Then
                    For i = 1 To .DataRowCnt
                        sqlstring = "INSERT INTO Party_OtherCharges(BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,ITEMCODE,ITEMDESC,UOM,RATE,QTY,AMOUNT,TAXAMOUNT,TOTALAMOUNT,SLNO,LOCCODE,FREEZE,ADDUSERID,ADDDATETIME) Values ("
                        sqlstring = sqlstring & "'" & CMBBOOKINGTYPE.Text & "','" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "',"
                        .Row = i
                        .Col = 1
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 2
                        sqlstring = sqlstring & "'" & Trim(.Text) & "','NOS',"
                        .Col = 3
                        sqlstring = sqlstring & "'" & Val(.Text) & "',1,"
                        .Col = 4
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 5
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 6
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 8
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        sqlstring = sqlstring & "'" & Trim(Cmb_Location.Text) & "','N',"
                        sqlstring = sqlstring & "'" & Trim(gUsername) & "'"
                        sqlstring = sqlstring & ",GETDATE())"
                        ReDim Preserve InsertBook(InsertBook.Length)
                        InsertBook(InsertBook.Length - 1) = sqlstring
                    Next
                    Dim Itemcode As String
                    Dim SNO As Integer
                    For i = 1 To .DataRowCnt
                        Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                        GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                        .Col = 1
                        .Row = i
                        Itemcode = Trim(.Text)
                        .Col = 3
                        .Row = i
                        GrdRate = .Text
                        Qty = 1
                        .Col = 8
                        .Row = i
                        SNO = .Text
                        .Col = 7
                        .Row = i
                        ChargeCode = Trim(.Text)
                        sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        GCONNECTION.getDataSet(sqlstring, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(sqlstring, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                                Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                                sqlstring = "INSERT INTO Party_OtherCharges_Tax(BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,CHARGECODE,TAXCODE,TAXON,TAXPERC,ITEMCODE,RATE,QTY,SLNO,TAXAMOUNT,FREEZE,ADDUSERID,ADDDATETIME) VALUES ( "
                                sqlstring = sqlstring & "'" & CMBBOOKINGTYPE.Text & "','" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd-MMM-yyyy") & "','" & Trim(ChargeCode) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (TPercent) & ",'" & Trim(Itemcode) & "'," & (GrdRate) & "," & (Qty) & "," & (SNO) & ","

                                If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                    Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    sqlstring = sqlstring & "" & Val(Zero) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    sqlstring = sqlstring & "" & Val(ZeroA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    sqlstring = sqlstring & "" & Val(ZeroB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                    One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    sqlstring = sqlstring & "" & Val(One) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    sqlstring = sqlstring & "" & Val(OneA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    sqlstring = sqlstring & "" & Val(OneB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                    Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    sqlstring = sqlstring & "" & Val(Two) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    sqlstring = sqlstring & "" & Val(TwoA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    sqlstring = sqlstring & "" & Val(TwoB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                    Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    sqlstring = sqlstring & "" & Val(Three) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    sqlstring = sqlstring & "" & Val(ThreeA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    sqlstring = sqlstring & "" & Val(ThreeB) * Qty & ","
                                End If
                                sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate())"
                                ReDim Preserve InsertBook(InsertBook.Length)
                                InsertBook(InsertBook.Length - 1) = sqlstring
                            Next
                        End If
                    Next
                End If
            End With
            sqlstring = "  UPDATE Party_OtherCharges SET TAXAMOUNT = (SELECT ISNULL(SUM(Party_OtherCharges_Tax.TAXAMOUNT),0) FROM Party_OtherCharges_Tax  WHERE Party_OtherCharges.BOOKINGNO = Party_OtherCharges_Tax.BOOKINGNO AND Party_OtherCharges_Tax.ITEMCODE = Party_OtherCharges.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(Party_OtherCharges_Tax.BOOKINGTYPE,'') = ISNULL(Party_OtherCharges.BOOKINGTYPE,'') AND ISNULL(Party_OtherCharges_Tax.SLNO,0) = ISNULL(Party_OtherCharges.SLNO,0) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''),ISNULL(SLNO,0)) WHERE Party_OtherCharges.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(Party_OtherCharges.BOOKINGTYPE,'') = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring
            sqlstring = "UPDATE Party_OtherCharges SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BOOKING'"
            ReDim Preserve InsertBook(InsertBook.Length)
            InsertBook(InsertBook.Length - 1) = sqlstring

            With sSGrid_Kot
                If .DataRowCnt > 0 Then
                    sqlstring = "DELETE FROM PARTY_KOT_DET WHERE KOTDETAILS = '" & Txt_BookingNo.Text & "'"
                    ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM PARTY_KOT_DET_TAX WHERE KOTDETAILS = '" & Txt_BookingNo.Text & "'"
                    ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring
                    If Mid(gCompName, 1, 2) = "HC" Then
                        sqlstring = sqlstring & " SELECT '" & Txt_BookingNo.Text & "','" & Txt_BookingNo.Text & "',KOTDATE,'" & Txt_BookingNo.Text & "','PAR',ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE,"
                        sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,'PAR',ALCHOLST,0,PAYMENTMODE,DelFlag,'CHS',GETDATE(),UpdUserid,GETDATE(),PACKAMT,DISCAMT,PACKPERCENT,"
                        sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,'','','',GroupCode,TIPSPERCENT,TIPSAMOUNT,0,0,0,0,0,0,KOTDETAILS,'BOOKING',0"
                        sqlstring = sqlstring & " FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "')  AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> ''  "
                    Else
                        sqlstring = sqlstring & " SELECT '" & Txt_BookingNo.Text & "','" & Txt_BookingNo.Text & "',KOTDATE,'" & Txt_BookingNo.Text & "',CATEGORY,ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE,"
                        sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,'PAR',ALCHOLST,CHITNO,PAYMENTMODE,DelFlag,'" & Trim(gUsername) & "',GETDATE(),UpdUserid,GETDATE(),PACKAMT,DISCAMT,PACKPERCENT,"
                        sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,ISNULL(PDA_PRINT_FLAG,''),ISNULL(PDA_DELETE_FLAG,''),ISNULL(IS_PDA,''),SUBGroupCode,TipsPer,TipsAmt,AdCgsPer,AdCgsAmt,PartyPer,PartyAmt,RoomPer,RoomAmt,KOTDETAILS,'BOOKING',SLNO"
                        sqlstring = sqlstring & " FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "')  AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> ''  "
                    End If
                    ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring
                    sqlstring = "INSERT INTO PARTY_KOT_DET_TAX (KOTDETAILS,KOTDATE,TTYPE,CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,ADD_USER,ADD_DATE,VOID,VOIDUSER,SNO)"
                    sqlstring = sqlstring & "SELECT '" & Txt_BookingNo.Text & "',KOTDATE,'PAR',CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,'" & Trim(gUsername) & "',GETDATE(),VOID,'',SLNO"
                    sqlstring = sqlstring & " FROM KOT_DET_TAX WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "')"
                     ReDim Preserve InsertBook(InsertBook.Length)
                    InsertBook(InsertBook.Length - 1) = sqlstring
                End If
            End With
        End If
    End Sub
    Private Sub GridPayment(ByVal i As Integer)
        Dim j As Integer
        Dim sqlstring As String
        sSGrid_Rec.TypeComboBoxClear(1, i)
        sqlstring = " SELECT Paymentcode FROM paymentmodemaster WHERE Isnull(Freeze,'')<>'Y' AND ISNULL(MEMBERSTATUS,'') <> 'SMART CARD'"
        GCONNECTION.getDataSet(sqlstring, "paymentmodemaster")
        If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
            For j = 0 To gdataset.Tables("paymentmodemaster").Rows.Count - 1
                sSGrid_Rec.Col = 1
                sSGrid_Rec.Row = i
                sSGrid_Rec.TypeComboBoxString = Trim(gdataset.Tables("paymentmodemaster").Rows(j).Item("Paymentcode"))
                sSGrid_Rec.TypeComboBoxIndex = j
            Next j
        End If
    End Sub
    Private Sub AutoGenerate_Rec(ByVal Dtype As String, i As Integer)
        DocType = Dtype
        Dim sqlstring, financalyear As String
        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
        Try
            sqlstring = "SELECT MAX(Cast(SUBSTRING(PARTYRECEIPTNO,5,6) As VARCHAR)) AS  PARTYRECEIPTNO FROM party_receipt_HDR  "
            GCONNECTION.openConnection()
            gcommand = New SqlCommand(sqlstring, GCONNECTION.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    sSGrid_Rec.Col = 3
                    sSGrid_Rec.Row = i
                    sSGrid_Rec.Text = DocType & "/000001" & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    GCONNECTION.closeConnection()
                Else
                    sSGrid_Rec.Col = 3
                    sSGrid_Rec.Row = i
                    sSGrid_Rec.Text = DocType & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    GCONNECTION.closeConnection()
                End If
            Else
                sSGrid_Rec.Col = 3
                sSGrid_Rec.Row = i
                sSGrid_Rec.Text = DocType & "/000001" & "/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                GCONNECTION.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            GCONNECTION.closeConnection()
        End Try
    End Sub
    Private Sub BookingRecAdd()
        Dim strSQL As String
        Dim DT As New DataTable
        Dim VOUNO As Integer
        Dim Vdate As DateTime
        Dim INSERT(0) As String
        Dim RecMode, RecNo As String
        Dim RecAmt, HAmt, FAmt As Double
        If Mid(CmdAdd.Text, 1, 1) = "A" Then
            sqlstring = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
            GCONNECTION.getDataSet(sqlstring, "SERVERDATE")
            If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then
                Vdate = Format(gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE"), "dd-MMM-yyyy")
            End If
            With sSGrid_Rec
                For i = 1 To .DataRowCnt
                    .Row = i
                    .Col = 1
                    RecMode = Trim(.Text)
                    AutoGenerate_Rec("PAR", i)
                    .Col = 3
                    RecNo = Trim(.Text)
                    .Col = 2
                    RecAmt = Val(.Text)
                    ReDim INSERT(0)
                    strSQL = " INSERT INTO party_receipt_HDR(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,adduserid,adddatetime,"
                    strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,CARDNUMBER,PLACE)"
                    strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                    strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                    strSQL = strSQL & "'" & Trim(RecNo) & "'"
                    strSQL = strSQL & ",'" & Format(Vdate, "dd/MMM/yyyy") & "','" & Trim(RecMode) & "'"
                    strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                    strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                    strSQL = strSQL & ",'N'"
                    strSQL = strSQL & ",'','ADVANCE',"
                    strSQL = strSQL & "'',"
                    strSQL = strSQL & "'','',"
                    strSQL = strSQL & "'" & Format(Val(RecAmt), 0.0) & "','','')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = strSQL

                    If i = 1 Then
                        If RecAmt > Val(Txt_TotAmount.Text) Then
                            HAmt = Val(Txt_TotAmount.Text)
                            FAmt = RecAmt - Val(Txt_TotAmount.Text)
                        Else
                            HAmt = RecAmt
                            FAmt = 0
                        End If
                        If HAmt > 0 Then
                            strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                            strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,RType)"
                            strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                            strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                            strSQL = strSQL & "'" & Trim(RecNo) & "'"
                            strSQL = strSQL & ",'" & Format(Vdate, "dd/MMM/yyyy") & "','" & Trim(RecMode) & "'"
                            strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                            strSQL = strSQL & ",'HALL'"
                            strSQL = strSQL & ",'HALL AMOUNT'"
                            strSQL = strSQL & "," & Val(HAmt) & ""
                            strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                            strSQL = strSQL & ",'N'"
                            strSQL = strSQL & ",'','ADVANCE',"
                            strSQL = strSQL & "'',"
                            strSQL = strSQL & "'','',"
                            strSQL = strSQL & "'" & Format(Val(RecAmt), 0.0) & "','B')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = strSQL
                        End If
                        If FAmt > 0 Then
                            strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                            strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,RType)"
                            strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                            strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                            strSQL = strSQL & "'" & Trim(RecNo) & "'"
                            strSQL = strSQL & ",'" & Format(Vdate, "dd/MMM/yyyy") & "','" & Trim(RecMode) & "'"
                            strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                            strSQL = strSQL & ",'FOOD'"
                            strSQL = strSQL & ",'FOOD AMOUNT'"
                            strSQL = strSQL & "," & Val(FAmt) & ""
                            strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                            strSQL = strSQL & ",'N'"
                            strSQL = strSQL & ",'','ADVANCE',"
                            strSQL = strSQL & "'',"
                            strSQL = strSQL & "'','',"
                            strSQL = strSQL & "'" & Format(Val(RecAmt), 0.0) & "','B')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = strSQL
                        End If
                    Else
                        strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                        strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,RType)"
                        strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                        strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                        strSQL = strSQL & "'" & Trim(RecNo) & "'"
                        strSQL = strSQL & ",'" & Format(Vdate, "dd/MMM/yyyy") & "','" & Trim(RecMode) & "'"
                        strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                        strSQL = strSQL & ",'FOOD'"
                        strSQL = strSQL & ",'FOOD AMOUNT'"
                        strSQL = strSQL & "," & Val(RecAmt) & ""
                        strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                        strSQL = strSQL & ",'N'"
                        strSQL = strSQL & ",'','ADVANCE',"
                        strSQL = strSQL & "'',"
                        strSQL = strSQL & "'','',"
                        strSQL = strSQL & "'" & Format(Val(RecAmt), 0.0) & "','B')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = strSQL
                    End If

                    strSQL = "UPDATE party_receipt_HDR SET DESCRIPTION = H.DESCRIPTION FROM party_hallbooking_hdr H,party_receipt_HDR R WHERE H.BOOKINGNO = R.BOOKINGNO AND R.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = strSQL
                    strSQL = "UPDATE party_receipt_DET SET DESCRIPTION = H.DESCRIPTION FROM party_hallbooking_hdr H,party_receipt_DET R WHERE H.BOOKINGNO = R.BOOKINGNO AND R.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = strSQL

                    GCONNECTION.MoreTransold1(INSERT)
                Next
            End With
        ElseIf Mid(CmdAdd.Text, 1, 1) = "U" Then
            With sSGrid_Rec
                For i = 1 To .DataRowCnt
                    .Row = i
                    .Col = 1
                    RecMode = Trim(.Text)
                    .Col = 3
                    RecNo = Trim(.Text)
                    If Trim(RecNo) <> "" Then
                        .Col = 2
                        RecAmt = Val(.Text)
                        ReDim INSERT(0)
                        Vdate = GCONNECTION.getvalue("select PARTYRECEIPTDATE from party_receipt_HDR where PARTYRECEIPTNO = '" & Trim(RecNo) & "'")
                        Vdate = Format(Vdate, "dd-MMM-yyyy")

                        strSQL = "UPDATE party_receipt_HDR SET PAYMENTMODE = '" & Trim(RecMode) & "',TOTALAMOUNT = '" & Format(Val(RecAmt), 0.0) & "', MCODE ='" & Trim(Txt_MemberCode.Text) & "',MNAME ='" & Trim(Txt_MemberName.Text) & "',GUESTNAME ='" & Trim(Txt_GuestName.Text) & "',DESCRIPTION = '" & Trim(Txt_Purpose.Text) & "' WHERE PARTYRECEIPTNO = '" & Trim(RecNo) & "' "
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = strSQL
                        ''strSQL = "UPDATE party_receipt_DET SET PAYMENTMODE = '" & Trim(RecMode) & "',AMOUNT = '" & Format(Val(RecAmt), 0.0) & "',TOTALAMOUNT = '" & Format(Val(RecAmt), 0.0) & "', MCODE ='" & Trim(Txt_MemberCode.Text) & "',MNAME ='" & Trim(Txt_MemberName.Text) & "',GUESTNAME ='" & Trim(Txt_GuestName.Text) & "',DESCRIPTION = '" & Trim(Txt_Purpose.Text) & "' WHERE PARTYRECEIPTNO = '" & Trim(RecNo) & "' "
                        ''ReDim Preserve INSERT(INSERT.Length)
                        ''INSERT(INSERT.Length - 1) = strSQL
                        strSQL = " DELETE FROM party_receipt_DET  Where PARTYRECEIPTNO='" & Trim(RecNo) & "'"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = strSQL
                        If i = 1 Then
                            If RecAmt > Val(Txt_TotAmount.Text) Then
                                HAmt = Val(Txt_TotAmount.Text)
                                FAmt = RecAmt - Val(Txt_TotAmount.Text)
                            Else
                                HAmt = RecAmt
                                FAmt = 0
                            End If
                            If HAmt > 0 Then
                                strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                                strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,RType)"
                                strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                                strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                                strSQL = strSQL & "'" & Trim(RecNo) & "'"
                                strSQL = strSQL & ",'" & Format(Vdate, "dd/MMM/yyyy") & "','" & Trim(RecMode) & "'"
                                strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                                strSQL = strSQL & ",'HALL'"
                                strSQL = strSQL & ",'HALL AMOUNT'"
                                strSQL = strSQL & "," & Val(HAmt) & ""
                                strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                                strSQL = strSQL & ",'N'"
                                strSQL = strSQL & ",'','ADVANCE',"
                                strSQL = strSQL & "'',"
                                strSQL = strSQL & "'','',"
                                strSQL = strSQL & "'" & Format(Val(RecAmt), 0.0) & "','B')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = strSQL
                            End If
                            If FAmt > 0 Then
                                strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                                strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,RType)"
                                strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                                strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                                strSQL = strSQL & "'" & Trim(RecNo) & "'"
                                strSQL = strSQL & ",'" & Format(Vdate, "dd/MMM/yyyy") & "','" & Trim(RecMode) & "'"
                                strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                                strSQL = strSQL & ",'FOOD'"
                                strSQL = strSQL & ",'FOOD AMOUNT'"
                                strSQL = strSQL & "," & Val(FAmt) & ""
                                strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                                strSQL = strSQL & ",'N'"
                                strSQL = strSQL & ",'','ADVANCE',"
                                strSQL = strSQL & "'',"
                                strSQL = strSQL & "'','',"
                                strSQL = strSQL & "'" & Format(Val(RecAmt), 0.0) & "','B')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = strSQL
                            End If
                        Else
                            strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                            strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,RType)"
                            strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                            strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                            strSQL = strSQL & "'" & Trim(RecNo) & "'"
                            strSQL = strSQL & ",'" & Format(Vdate, "dd/MMM/yyyy") & "','" & Trim(RecMode) & "'"
                            strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                            strSQL = strSQL & ",'FOOD'"
                            strSQL = strSQL & ",'FOOD AMOUNT'"
                            strSQL = strSQL & "," & Val(RecAmt) & ""
                            strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                            strSQL = strSQL & ",'N'"
                            strSQL = strSQL & ",'','ADVANCE',"
                            strSQL = strSQL & "'',"
                            strSQL = strSQL & "'','',"
                            strSQL = strSQL & "'" & Format(Val(RecAmt), 0.0) & "','B')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = strSQL
                        End If
                    Else
                        AutoGenerate_Rec("PAR", i)
                        .Col = 3
                        RecNo = Trim(.Text)
                        .Col = 2
                        RecAmt = Val(.Text)
                        ReDim INSERT(0)
                        sqlstring = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
                        GCONNECTION.getDataSet(sqlstring, "SERVERDATE")
                        If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then
                            Vdate = Format(gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE"), "dd-MMM-yyyy")
                        End If

                        strSQL = " INSERT INTO party_receipt_HDR(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,adduserid,adddatetime,"
                        strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,CARDNUMBER,PLACE)"
                        strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                        strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                        strSQL = strSQL & "'" & Trim(RecNo) & "'"
                        strSQL = strSQL & ",'" & Format(Vdate, "dd/MMM/yyyy") & "','" & Trim(RecMode) & "'"
                        strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                        strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                        strSQL = strSQL & ",'N'"
                        strSQL = strSQL & ",'','ADVANCE',"
                        strSQL = strSQL & "'',"
                        strSQL = strSQL & "'','',"
                        strSQL = strSQL & "'" & Format(Val(RecAmt), 0.0) & "','','')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = strSQL

                        If i = 1 Then
                            If RecAmt > Val(Txt_TotAmount.Text) Then
                                HAmt = Val(Txt_TotAmount.Text)
                                FAmt = RecAmt - Val(Txt_TotAmount.Text)
                            Else
                                HAmt = RecAmt
                                FAmt = 0
                            End If
                            If HAmt > 0 Then
                                strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                                strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,RType)"
                                strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                                strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                                strSQL = strSQL & "'" & Trim(RecNo) & "'"
                                strSQL = strSQL & ",'" & Format(Vdate, "dd/MMM/yyyy") & "','" & Trim(RecMode) & "'"
                                strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                                strSQL = strSQL & ",'HALL'"
                                strSQL = strSQL & ",'HALL AMOUNT'"
                                strSQL = strSQL & "," & Val(HAmt) & ""
                                strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                                strSQL = strSQL & ",'N'"
                                strSQL = strSQL & ",'','ADVANCE',"
                                strSQL = strSQL & "'',"
                                strSQL = strSQL & "'','',"
                                strSQL = strSQL & "'" & Format(Val(RecAmt), 0.0) & "','B')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = strSQL
                            End If
                            If FAmt > 0 Then
                                strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                                strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,RType)"
                                strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                                strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                                strSQL = strSQL & "'" & Trim(RecNo) & "'"
                                strSQL = strSQL & ",'" & Format(Vdate, "dd/MMM/yyyy") & "','" & Trim(RecMode) & "'"
                                strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                                strSQL = strSQL & ",'FOOD'"
                                strSQL = strSQL & ",'FOOD AMOUNT'"
                                strSQL = strSQL & "," & Val(FAmt) & ""
                                strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                                strSQL = strSQL & ",'N'"
                                strSQL = strSQL & ",'','ADVANCE',"
                                strSQL = strSQL & "'',"
                                strSQL = strSQL & "'','',"
                                strSQL = strSQL & "'" & Format(Val(RecAmt), 0.0) & "','B')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = strSQL
                            End If
                        Else
                            strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                            strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,RType)"
                            strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                            strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                            strSQL = strSQL & "'" & Trim(RecNo) & "'"
                            strSQL = strSQL & ",'" & Format(Vdate, "dd/MMM/yyyy") & "','" & Trim(RecMode) & "'"
                            strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                            strSQL = strSQL & ",'FOOD'"
                            strSQL = strSQL & ",'FOOD AMOUNT'"
                            strSQL = strSQL & "," & Val(RecAmt) & ""
                            strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                            strSQL = strSQL & ",'N'"
                            strSQL = strSQL & ",'','ADVANCE',"
                            strSQL = strSQL & "'',"
                            strSQL = strSQL & "'','',"
                            strSQL = strSQL & "'" & Format(Val(RecAmt), 0.0) & "','B')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = strSQL
                        End If

                        strSQL = "UPDATE party_receipt_HDR SET DESCRIPTION = H.DESCRIPTION FROM party_hallbooking_hdr H,party_receipt_HDR R WHERE H.BOOKINGNO = R.BOOKINGNO AND R.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = strSQL
                        strSQL = "UPDATE party_receipt_DET SET DESCRIPTION = H.DESCRIPTION FROM party_hallbooking_hdr H,party_receipt_DET R WHERE H.BOOKINGNO = R.BOOKINGNO AND R.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = strSQL
                    End If

                    strSQL = "UPDATE party_receipt_DET SET Receiptheaddesc = M.Receiptheaddesc FROM party_Head_master M, party_receipt_DET D WHERE D.Receiptheadcode = M.Receiptheadcode AND D.PARTYRECEIPTNO = '" & Trim(RecNo) & "' "
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = strSQL

                    GCONNECTION.MoreTransold1(INSERT)
                Next
            End With
        End If
    End Sub

    Private Sub Cmd_RecPrint_Click(sender As Object, e As EventArgs) Handles Cmd_RecPrint.Click
        If MessageBox.Show("Press OK for Print,View for Cancel ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            gPrint = True
        Else
            gPrint = False
        End If
        With sSGrid_Rec
            For i = 1 To .DataRowCnt
                .Row = i
                .Col = 3
                If Mid(gCompName, 1, 4) = "KSCA" Then
                    Call RECEIT_KSCA(Trim(.Text))
                Else
                    Call RECEIT(Trim(.Text))
                End If
            Next
        End With
    End Sub
    Private Sub RECEIT(ByVal Recno As String)
        Dim Viewer As New ReportViwer
        Dim r1 As New partreceiptVoucher_CIAL
        Dim i As Integer
        Dim sqlstring, sqlstring1, towords As String
        Dim Amt As Double

        sqlstring = " SELECT * from partyreceiptvoucher  WHERE PARTYRECEIPTNO='" & Recno & "' "
        GCONNECTION.getDataSet(sqlstring, "PARTYRECEIPTNO")
        sqlstring1 = " SELECT * from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Recno & "' "
        GCONNECTION.getDataSet(sqlstring1, "PARTYRECEIPTNO")
        If (gdataset.Tables("PARTYRECEIPTNO").Rows.Count > 0) Then

            Call Viewer.GetDetails1(sqlstring, "partyreceiptvoucher", r1)
            Call Viewer.GetDetails1(sqlstring1, "partyreceiptvoucher1", r1)

            sqlstring = "SELECT SUM(amount) as amount from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Recno & "'"
            GCONNECTION.getDataSet(sqlstring, "amount")
            If (gdataset.Tables("amount").Rows.Count > 0) Then
                Amt = gdataset.Tables("amount").Rows(0).Item(0)
            End If
            Dim TXTOBJ11 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ11 = r1.ReportDefinition.ReportObjects("Text11")
            TXTOBJ11.Text = MyCompanyName

            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text12")
            TXTOBJ6.Text = Address1 & " " & Address2

            Dim TXTOBJ7 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ7 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ7.Text = gCity & "," & gState & "-" & gPincode

            towords = RupeesToWord(Amt)
            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text10")
            TXTOBJ5.Text = towords

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text16")
            TXTOBJ1.Text = "UserName : " & gUsername

            Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ2 = r1.ReportDefinition.ReportObjects("Text15")
            TXTOBJ2.Text = Txt_GuestName.Text

            Viewer.Show()
            If gPrint = True Then
                r1.PrintOptions.PrinterName = "\\" & computername & "\" & Printername
                r1.PrintToPrinter(2, False, 0, 0)
                r1.Close()
                r1.Dispose()
                Viewer.Refresh()
                Viewer.Close()
                Viewer.Dispose()
                GC.Collect()
                Exit Sub
            End If
            Viewer.BringToFront()
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub RECEIT_KSCA(ByVal Recno As String)
        Dim Viewer As New ReportViwer
        Dim r1 As New Rpt_ReceiptPaymentNote_KSCA
        Dim i As Integer
        Dim sqlstring, sqlstring1, towords, SLCODE1, rectype, PayMode As String
        Dim Amt As Double
        Dim Bookno, HFromTime, HToTime, HHDesc As String
        Dim HPartyDate As DateTime

        sqlstring1 = "SELECT 1 as copyno,'M E M B E R C O P Y' as copydesc,b.ClubLogo as ClubLogo,'CASH' as cashbank,PARTYRECEIPTNO  AS VOUCHERNO,PARTYRECEIPTDATE  AS VOUCHERDATE,"
        sqlstring1 = sqlstring1 & " 'CR' AS VOUCHERTYPE,'' AS ACCOUNTCODE,RECEIPTHEADDESC AS ACCOUNTCODEDESC,MCODE AS SLCODE,MNAME AS SLDESC,'' AS COSTCENTERCODE,'' AS COSTCENTERDESC,'CREDIT' AS CREDITDEBIT,"
        sqlstring1 = sqlstring1 & " AMOUNT,AMOUNT AS CRAMOUNT,0 AS DRAMOUNT,DESCRIPTION,INSTDATE AS INSTRUMENTDATE,INSTNO AS INSTRUMENTNO,MNAME AS RECEIVEDFROM,FREEZE AS VOID,'' AS BANKPLACE,"
        sqlstring1 = sqlstring1 & " convert(varchar(11),isnull(AddDateTime,''),108) as AdddateTime FROM party_receipt_DET a,accountssetup b WHERE PARTYRECEIPTNO = '" & Recno & "'  UNION ALL "
        sqlstring1 = sqlstring1 & " SELECT 2 as copyno,'O F F I C E C O P Y' as copydesc,b.ClubLogo as ClubLogo,'CASH' as cashbank,PARTYRECEIPTNO  AS VOUCHERNO,PARTYRECEIPTDATE  AS VOUCHERDATE,"
        sqlstring1 = sqlstring1 & " 'CR' AS VOUCHERTYPE,'' AS ACCOUNTCODE,RECEIPTHEADDESC AS ACCOUNTCODEDESC,MCODE AS SLCODE,MNAME AS SLDESC,'' AS COSTCENTERCODE,'' AS COSTCENTERDESC,'CREDIT' AS CREDITDEBIT,"
        sqlstring1 = sqlstring1 & " AMOUNT,AMOUNT AS CRAMOUNT,0 AS DRAMOUNT,DESCRIPTION,INSTDATE AS INSTRUMENTDATE,INSTNO AS INSTRUMENTNO,MNAME AS RECEIVEDFROM,FREEZE AS VOID,'' AS BANKPLACE,"
        sqlstring1 = sqlstring1 & " convert(varchar(11),isnull(AddDateTime,''),108) as AdddateTime FROM party_receipt_DET a,accountssetup b WHERE PARTYRECEIPTNO = '" & Recno & "' "

        GCONNECTION.getDataSet(sqlstring1, "vw_ReceiptPaymentNote")
        If (gdataset.Tables("vw_ReceiptPaymentNote").Rows.Count > 0) Then
            SLCODE1 = gdataset.Tables("vw_ReceiptPaymentNote").Rows(0).Item("SLCODE")
            Call Viewer.GetDetails1(sqlstring1, "vw_ReceiptPaymentNote", r1)

            sqlstring = "SELECT SUM(amount) as amount from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Recno & "'"
            GCONNECTION.getDataSet(sqlstring, "amount")
            If (gdataset.Tables("amount").Rows.Count > 0) Then
                Amt = gdataset.Tables("amount").Rows(0).Item(0)
            End If

            sqlstring = "SELECT DISTINCT RECEIPTTYPE from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Recno & "'"
            GCONNECTION.getDataSet(sqlstring, "amount1")
            If (gdataset.Tables("amount1").Rows.Count > 0) Then
                rectype = gdataset.Tables("amount1").Rows(0).Item(0)
            End If

            sqlstring = "SELECT *  from partyreceiptvoucher1 WHERE PARTYRECEIPTNO='" & Recno & "'"
            GCONNECTION.getDataSet(sqlstring, "Partyvou")
            If (gdataset.Tables("Partyvou").Rows.Count > 0) Then
                PayMode = gdataset.Tables("Partyvou").Rows(0).Item("PAYMENTMODE")
            End If

            sqlstring = "SELECT BOOKINGNO,PARTYDATE,FROMTIME,TOTIME,HallDesc FROM PARTY_HALLBOOKING_DET WHERE BOOKINGNO IN (SELECT BOOKINGNO FROM PARTY_RECEIPT_dET WHERE PARTYRECEIPTNO = '" & Recno & "')"
            GCONNECTION.getDataSet(sqlstring, "PInfo")
            If (gdataset.Tables("PInfo").Rows.Count > 0) Then
                Bookno = gdataset.Tables("PInfo").Rows(0).Item("BOOKINGNO")
                HFromTime = gdataset.Tables("PInfo").Rows(0).Item("FROMTIME")
                HToTime = gdataset.Tables("PInfo").Rows(0).Item("TOTIME")
                HPartyDate = Format(gdataset.Tables("PInfo").Rows(0).Item("PARTYDATE"), "dd/MMM/yyyy")
                HHDesc = ""

                For i = 0 To gdataset.Tables("PInfo").Rows.Count - 1
                    HHDesc = Trim(gdataset.Tables("PInfo").Rows(0).Item("HallDesc")) & ","
                Next
                HHDesc = Mid(HHDesc, 1, Len(HHDesc) - 1)
            End If

            Dim TXTOBJ11 As TextObject
            TXTOBJ11 = r1.ReportDefinition.ReportObjects("TEXT11")
            TXTOBJ11.Text = MyCompanyName

            Dim TXTOBJ14 As TextObject
            TXTOBJ14 = r1.ReportDefinition.ReportObjects("TEXT14")
            TXTOBJ14.Text = Address1

            Dim TXTOBJ8 As TextObject
            TXTOBJ8 = r1.ReportDefinition.ReportObjects("TEXT8")
            TXTOBJ8.Text = Address2

            Dim TXTOBJ13 As TextObject
            TXTOBJ13 = r1.ReportDefinition.ReportObjects("TEXT13")
            TXTOBJ13.Text = gCity & "-" & gPincode

            If Trim(rectype) = "REFUND" Then
                Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text5")
                TXTOBJ4.Text = "Party Refund"
            Else
                Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text5")
                TXTOBJ4.Text = "Party Received"
            End If

            towords = RupeesToWord(Amt)
            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text6")
            TXTOBJ5.Text = Amt & " " & towords

            Dim TXTOBJ188, TXTOBJ198 As TextObject
            TXTOBJ188 = r1.ReportDefinition.ReportObjects("Text26")
            ''TXTOBJ188.Text = "Payment Mode: CASH"
            TXTOBJ188.Text = "Payment Mode: " & PayMode

            TXTOBJ198 = r1.ReportDefinition.ReportObjects("Text22")
            TXTOBJ198.Text = UCase(gUsername)

            Dim Salut As String
            sqlstring = "SELECT * FROM MEMBERMASTER WHERE MCODE ='" & Trim(SLCODE1) & "'"
            GCONNECTION.getDataSet(sqlstring, "MEMBERMASTER")
            If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                Salut = gdataset.Tables("MEMBERMASTER").Rows(0).Item("salut")
            End If

            Dim TXTOBJ19 As TextObject
            TXTOBJ19 = r1.ReportDefinition.ReportObjects("TEXT2")
            TXTOBJ19.Text = Salut

            Dim TXTOBJ21, TXTOBJ22, TXTOBJ23, TXTOBJ24 As TextObject
            TXTOBJ21 = r1.ReportDefinition.ReportObjects("Text31")
            TXTOBJ21.Text = Bookno
            TXTOBJ22 = r1.ReportDefinition.ReportObjects("Text32")
            TXTOBJ22.Text = HPartyDate
            TXTOBJ23 = r1.ReportDefinition.ReportObjects("Text33")
            TXTOBJ23.Text = HFromTime & " To " & HToTime
            TXTOBJ24 = r1.ReportDefinition.ReportObjects("Text34")
            TXTOBJ24.Text = UCase(HHDesc)

            Viewer.Show()

            If gPrint = True Then
                'r1.PrintOptions.PrinterName = "\\" & computername & "\" & Printername
                r1.PrintToPrinter(1, False, 0, 0)
                r1.Close()
                r1.Dispose()
                Viewer.Refresh()
                Viewer.Close()
                Viewer.Dispose()
                GC.Collect()
                Exit Sub
            End If
            Viewer.BringToFront()
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub Txt_MemberCode_TextChanged(sender As Object, e As EventArgs) Handles Txt_MemberCode.TextChanged

    End Sub
End Class