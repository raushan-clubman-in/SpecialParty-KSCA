Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports System.IO
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Public Class Frm_T_BanMenuBilling
    Dim SSQL As String
    Dim GConnection As New GlobalClass
    Dim DT As New DataTable
    Dim GrdRate, GrdAmount, GrdTaxAmt As Double
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim CANCEL As Boolean
    Dim TarrifType, SubMenuCode, DocType, RecRef As String

    Private Sub Frm_T_BanMenuBilling_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            If CmdAdd.Enabled = True Then
                Call CmdAdd_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F8 Then

        ElseIf e.KeyCode = Keys.F9 Then
            Call Cmdview_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmdexit_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.R Then
            If Not (MDIParentobj.ActiveMdiChild Is Nothing) Then
                MDIParentobj.ActiveMdiChild.Close()
            End If
            GmoduleName = "BANQUET RECEIPT"
            Dim SMPS As New Frm_T_BanReceipt
            SMPS.Show()
            SMPS.MdiParent = MDIParentobj
        End If
    End Sub
    Private Sub Frm_T_BanMenuBilling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()
        Call autogenerate()
        Call LocationFill()
        If Mid(gCompName, 1, 4) = "BBSR" Or Mid(gCompName, 1, 4) = "CATH" Then
            Cmd_Freeze.Enabled = True
        Else
            Cmd_Freeze.Enabled = False
        End If
        Call FillPayment_Mode()
        Grp_Settlement.Visible = False

        Lbl_Outstanding.Text = ""
        CMBBOOKINGTYPE.SelectedIndex = 0
    End Sub
    Private Sub autogenerate()
        Dim ssql, SQLSTRING As String
        Dim billstr As String
        SQLSTRING = "select isnull(max(substring(billno,5,6)),0)+1 as no from PARTY_HDR where BOOKINGTYPE='BILLING' AND substring(billno,12,5)='" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2) & "'"
        GCONNECTION.getDataSet(SQLSTRING, "USER1")
        If gdataset.Tables("USER1").Rows.Count - 1 >= 0 Then
            If Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 1 Then
                billstr = "PBL/00000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 2 Then
                billstr = "PBL/0000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 3 Then
                billstr = "PBL/000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 4 Then
                billstr = "PBL/00" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 5 Then
                billstr = "PBL/0" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 6 Then
                billstr = "PBL/" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            End If
        End If
        TXTBILLINGNO.Text = billstr
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        GCONNECTION.getDataSet(SQLSTRING, "USER")
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
    End Sub
    Private Function LocationFill()
        Try
            Dim I As Integer
            Dim SQLSTRING As String
            Cmb_Location.Items.Clear()
            SQLSTRING = "SELECT DISTINCT LOCCODE FROM PARTY_LOCATIONMASTER"
            GConnection.getDataSet(SQLSTRING, "PARTY_LOCATIONMASTER")
            If gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count > 0 Then
                For I = 0 To gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count - 1
                    Cmb_Location.Items.Add(gdataset.Tables("PARTY_LOCATIONMASTER").Rows(I).Item("loccode"))
                Next
            End If
            Cmb_Location.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CATEGORYFILL " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function

    Private Sub Txt_BookingNo_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_BookingNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Trim(Txt_BookingNo.Text) = "" Then
                'Call Button2_Click(sender, e)
            Else
                Call Txt_BookingNo_Validated(Txt_BookingNo, e)
            End If
        End If
    End Sub

    Private Sub Txt_BookingNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_BookingNo.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_BookingNo.Text) = "" Then
                '  Call Button2_Click(sender, e)
            Else
                Call Txt_BookingNo_Validated(Txt_BookingNo, e)
            End If
        End If
    End Sub

    Private Sub Txt_BookingNo_Validated(sender As Object, e As EventArgs) Handles Txt_BookingNo.Validated
        Dim D1, D2 As Date
        Try
            If Val(Txt_BookingNo.Text) > 0 Then
                sqlstring = "SELECT ISNULL(BOOKINGFLAG,'') AS BOOKINGFLAG,ISNULL(BILLINGFLAG,'') AS BILLINGFLAG,"
                sqlstring = sqlstring & "ISNULL(CANCELFLAG,'') AS CANCELFLAG FROM  PARTY_HALLBOOKING_HDR "
                sqlstring = sqlstring & "WHERE ISNULL(BOOKINGNO, 0) = " & IIf(Txt_BookingNo.Text = "", 0, Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'  AND ISNULL(FREEZE,'') <> 'Y' "
                DT = GConnection.GetValues(sqlstring)
            Else
                Txt_BookingNo.Text = ""
                Exit Sub
            End If
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item("CANCELFLAG") = "Y" Then
                    CANCEL = True
                Else
                    CANCEL = False
                End If
                If DT.Rows(0).Item("BOOKINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                    sqlstring = "SELECT ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,ISNULL(P.PARTYDATE,'') AS PARTYDATE,ISNULL(P.FROMTIME,0) AS FROMTIME,"
                    sqlstring = sqlstring & "ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,ISNULL(P.GUESTNAME,'') AS GUESTNAME,ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE, "
                    sqlstring = sqlstring & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS OCCUPANCY,ISNULL(P.veg,0) AS veg,ISNULL(P.nonveg,0) AS nonveg,ISNULL(h.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME, "
                    sqlstring = sqlstring & "ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG,ISNULL(P.MENUCODE,'')AS MENUCODE FROM PARTY_HDR P LEFT OUTER "
                    sqlstring = sqlstring & " JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE where P.Bookingno='" & Txt_BookingNo.Text & "' AND P.LOCCODE='" & Trim(Cmb_Location.Text) & "' AND P.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'  and ISNULL(h.FREEZE ,'')<>'Y' "
                    DT = GConnection.GetValues(sqlstring)
                    Me.CmdAdd.Text = "Update[F7]"
                ElseIf DT.Rows(0).Item("BILLINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                    'bookingstatus.Visible = True
                    'bookingstatus.Text = "BILLING OVER"

                    sqlstring = "SELECT  ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,"
                    sqlstring = sqlstring & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                    sqlstring = sqlstring & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                    sqlstring = sqlstring & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,ISNULL(P.GUESTNAME,'') AS GUESTNAME,"
                    sqlstring = sqlstring & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                    sqlstring = sqlstring & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS OCCUPANCY,"
                    sqlstring = sqlstring & "ISNULL(P.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                    sqlstring = sqlstring & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg,"
                    sqlstring = sqlstring & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG,ISNULL(P.BILLNO,'') AS BILLNO,ISNULL(P.OvrallDiscount,0) AS OvrallDiscount FROM PARTY_HDR P"
                    sqlstring = sqlstring & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE"
                    sqlstring = sqlstring & " where P.Bookingno=" & Trim(Txt_BookingNo.Text) & ""
                    sqlstring = sqlstring & " AND P.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND H.LOCCODE='" & Trim(Cmb_Location.Text) & "'  And ISNULL(H.FREEZE ,'')<>'Y' And ISNULL(P.FREEZE,'') <> 'Y' "
                    DT = GConnection.GetValues(sqlstring)
                    Me.CmdAdd.Text = "Update[F7]"
                Else
                    If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                        sqlstring = "SELECT H.BOOKINGNO,H.BOOKINGDATE,H.PARTYDATE,H.DESCRIPTION,H.MCODE,H.ASSOCIATENAME,H.OCCUPANCY,H.GUESTNAME,H.NONVEG,H.VEG,H.FREEZE "
                        sqlstring = sqlstring & "FROM party_hallbooking_hdr H ,party_hallbooking_det D WHERE D.BOOKINGNO = H.BOOKINGNO AND H.BOOKINGNO = '" & Txt_BookingNo.Text & "' AND H.LOCCODE='" & Trim(Cmb_Location.Text) & "' "
                        DT = GConnection.GetValues(sqlstring)
                    ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                        SSQL = "SELECT  ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,ISNULL(P.BOOKINGTYPE,'')AS BOOKINGTYPE,"
                        SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                        SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                        SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,isnull(P.GUESTname,'')as GUESTname,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,ISNULL(P.GUESTNAME,'') AS GUESTNAME,"
                        SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                        SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS OCCUPANCY,"
                        SSQL = SSQL & "ISNULL(P.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                        SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,"
                        SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG,ISNULL(P.BILLNO,'') AS BILLNO,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg,ISNULL(P.MENUCODE,0) AS MENUCODE FROM PARTY_HDR P"
                        SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO"
                        SSQL = SSQL & " WHERE P.BOOKINGNO=" & Txt_BookingNo.Text & " AND P.LOCCODE='" & Trim(Cmb_Location.Text) & "'  And ISNULL(H.FREEZE ,'') <>'Y'"
                        SSQL = SSQL & " AND P.BOOKINGTYPE='BOOKING'"
                        If Mid(gCompName, 1, 4) = "KSCA" Then
                            SSQL = "SELECT H.BOOKINGNO,H.BOOKINGDATE,H.PARTYDATE,H.DESCRIPTION,H.MCODE,H.ASSOCIATENAME,H.OCCUPANCY,H.GUESTNAME,H.NONVEG,H.VEG,H.FREEZE "
                            SSQL = SSQL & "FROM party_hallbooking_hdr H ,party_hallbooking_det D WHERE D.BOOKINGNO = H.BOOKINGNO AND H.BOOKINGNO = '" & Txt_BookingNo.Text & "' AND H.LOCCODE='" & Trim(Cmb_Location.Text) & "' "
                        End If
                        DT = GConnection.GetValues(SSQL)
                    End If
                End If
                If DT.Rows.Count > 0 Then
                    Dtp_BookingDate.Value = Format(DT.Rows(0).Item("BOOKINGDATE"), "dd/MM/yyyy HH:mm:ss")
                    Dtp_PartyDate.Value = Format(DT.Rows(0).Item("PARTYDATE"), "dd/MM/yyyy HH:mm:ss")
                    Txt_Purpose.Text = DT.Rows(0).Item("DESCRIPTION")
                    Txt_MemberCode.Text = DT.Rows(0).Item("MCODE")
                    Txt_MemberName.Text = DT.Rows(0).Item("ASSOCIATENAME")
                    Txt_GuestName.Text = DT.Rows(0).Item("GUESTNAME")
                    Txt_TotPax.Text = Val(DT.Rows(0).Item("OCCUPANCY"))
                    Txt_VPax.Text = Val(DT.Rows(0).Item("VEG"))
                    Txt_PaidAmt.Text = Format(GConnection.getvalue("SELECT ISNULL(SUM(AMOUNT),0) AS DEPAMT FROM party_receipt_DET WHERE RECEIPTTYPE IN ('ADVANCE','DEPOSIT','SETTLEMENT') AND ISNULL(FREEZE,'') <> 'Y' AND BOOKINGNO = '" & Txt_BookingNo.Text & "'"), "0.00")
                    If Mid(UCase(Trim(gCompName)), 1, 2) = "HC" Then
                        Txt_PaidAmt.Text = Format(GConnection.getvalue("SELECT ISNULL(SUM(AMOUNT),0) AS DEPAMT FROM party_receiptauto WHERE bookingno = '" & Txt_BookingNo.Text & "'"), "0.00")
                    End If

                    If Val(DT.Rows(0).Item("VEG")) > 0 Then
                        Cmd_VMenuCodeHelp.Enabled = True
                        Txt_VMenuCode.Enabled = True
                    Else
                        Cmd_VMenuCodeHelp.Enabled = False
                        Txt_VMenuCode.Enabled = False
                    End If
                    Txt_NVPax.Text = Val(DT.Rows(0).Item("NONVEG"))
                    If Val(DT.Rows(0).Item("NONVEG")) > 0 Then
                        Cmd_NVMenuCodeHelp.Enabled = True
                        Txt_NVMenuCode.Enabled = True
                    Else
                        Cmd_NVMenuCodeHelp.Enabled = False
                        Txt_NVMenuCode.Enabled = False
                    End If
                    If Mid(CmdAdd.Text, 1, 1) = "A" And CMBBOOKINGTYPE.Text = "BILLING" Then
                    Else
                        TXTBILLINGNO.Text = DT.Rows(0).Item("BILLNO")
                        Txt_Discount.Text = DT.Rows(0).Item("OvrallDiscount")
                    End If

                    If DT.Rows(0).Item("FREEZE") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "THIS BOOKING IS FREEZED"
                        Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Freeze[F8]"
                    End If
                    Dim DTDet As DataTable
                    sqlstring = "Select * from Party_Hallbooking_Det WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                    DTDet = GConnection.GetValues(sqlstring)
                    If DTDet.Rows.Count > 0 Then
                        sSGrid_HallResv.ClearRange(-1, -1, 1, 1, True)
                        With sSGrid_HallResv
                            For i = 0 To DTDet.Rows.Count - 1
                                .Row = i + 1
                                .Col = 1
                                .Text = DTDet.Rows(i).Item("HALLCODE")
                                .Col = 2
                                .Text = DTDet.Rows(i).Item("HallDesc")
                                .Col = 3
                                .Text = DTDet.Rows(i).Item("SessionType")
                                .Col = 4
                                .Text = DTDet.Rows(i).Item("FROMTIME")
                                .Col = 5
                                .Text = DTDet.Rows(i).Item("TOTIME")
                                .Col = 6
                                .Text = Format(DTDet.Rows(i).Item("PARTYDATE"), "dd/MM/yy")
                                .Col = 7
                                .Text = Format(DTDet.Rows(i).Item("PartyToDate"), "dd/MM/yy")
                                .Col = 8
                                .Text = Format(DTDet.Rows(i).Item("HALLAMOUNT"), "0.00")
                                .Col = 9
                                .Text = DTDet.Rows(i).Item("ChargeCode")
                                .Col = 10
                                .Text = Format(DTDet.Rows(i).Item("HALLTAXAMOUNT"), "0.00")
                                .Col = 11
                                .Text = Format(DTDet.Rows(i).Item("HALLNETAMOUNT"), "0.00")
                                .Col = 12
                                .Text = Format(DTDet.Rows(i).Item("SECURITYDEPOSIT"), "0.00")
                                .Col = 13
                                .Text = Format(DTDet.Rows(i).Item("Act_HallCgs"), "0.00")
                                .Col = 15
                                .Text = DTDet.Rows(i).Item("HALLTYPE")
                                .Col = 16
                                .Text = DTDet.Rows(i).Item("PDesc")
                                .Col = 17
                                .Text = DTDet.Rows(i).Item("M_Keeper")
                            Next
                        End With
                    End If
                    Call POSDetails()
                    Call ARRANGEMENT()
                    Call Others()
                    'Call RESTAURANT()
                    Call TarriffVeg()
                    Call TarriffNonVeg()
                    Dtp_BookingDate.Focus()
                    Txt_MemberCode.Enabled = False
                    Dtp_PartyDate.Enabled = False
                    'Call Total_Calculate()
                    If Mid(gCompName, 1, 4) = "KSCA" Then
                        sqlstring = "select BOOKINGNO,SUM(DEB) AS DEB,SUM(CRE) AS CRE from Get_PartyBal WHERE BOOKINGNO = " & Txt_BookingNo.Text & " GROUP BY BOOKINGNO "
                        GConnection.getDataSet(sqlstring, "GBal")
                        If gdataset.Tables("GBal").Rows.Count > 0 Then
                            Lbl_Outstanding.Text = "Total Debit : " & gdataset.Tables("GBal").Rows(0).Item("DEB") & ",Total Credit : " & gdataset.Tables("GBal").Rows(0).Item("CRE") & ", Balance : " & (gdataset.Tables("GBal").Rows(0).Item("DEB") - gdataset.Tables("GBal").Rows(0).Item("CRE"))
                        Else
                            Lbl_Outstanding.Text = ""
                        End If
                    Else
                        Lbl_Outstanding.Text = ""
                    End If
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.CmdAdd.Text = "Add [F7]"
                    Txt_BookingNo.ReadOnly = False
                    MessageBox.Show("HALL BOOKING NO NOT FOUND,PLEASE BOOK THE HALL FIRST.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Txt_BookingNo.Text = ""
                    Txt_BookingNo.Focus()
                    Exit Sub
                End If
            Else
                MessageBox.Show("HALL BOOKING NO NOT FOUND,PLEASE BOOK THE HALL FIRST.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Txt_BookingNo.Text = ""
                Exit Sub
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
                sqlstring = sqlstring & "FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Trim(Txt_BookingNo.Text) & "') AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y' "
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
                    SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT,TAXCODE,SLNO "
                    SSQL = SSQL & " FROM VIEW_PARTY_ARRANGEMENT WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                    DT = GCONNECTION.GetValues(SSQL)
                    If DT.Rows.Count = 0 Then
                        SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT,TAXCODE,SLNO "
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
    Private Sub Others()
        Try
            If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT,TAXCODE,SLNO "
                SSQL = SSQL & " FROM VIEW_PARTY_OTHERSCHAGES WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' AND ITEMCODE NOT IN ('EHC','MGA')"
                DT = GConnection.GetValues(SSQL)
            ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT,TAXCODE,SLNO "
                SSQL = SSQL & " FROM VIEW_PARTY_OTHERSCHAGES WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' AND ITEMCODE NOT IN ('EHC','MGA')"
                DT = GConnection.GetValues(SSQL)
                If DT.Rows.Count = 0 Then
                    SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT,TAXCODE,SLNO "
                    SSQL = SSQL & " FROM VIEW_PARTY_OTHERSCHAGES WHERE  BOOKINGTYPE='BOOKING' AND BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' AND ITEMCODE NOT IN ('EHC','MGA')"
                    DT = GConnection.GetValues(SSQL)
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
            SSQL = SSQL & " WHERE  BOOKINGNO=" & Txt_BookingNo.Text & "  and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category IN ('VEG')) "
            DT = GConnection.GetValues(SSQL)
        ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE  BOOKINGNO=" & Txt_BookingNo.Text & " AND ISNULL(TARIFFDESC,'')<>'' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category in ('VEG')) AND BOOKINGTYPE='BOOKING'"
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
            SSQL = SSQL & " WHERE  BOOKINGTYPE='BILLING' AND BOOKINGNO=" & Txt_BookingNo.Text & "  and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category='VEG')"
            DT = GConnection.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                Me.Txt_VMenuCode.Text = DT.Rows(0).Item("TARIFFCODE")
                Me.Txt_VMenuDesc.Text = DT.Rows(0).Item("TARIFFDESC")
                Me.Txt_VMaxItem.Text = DT.Rows(0).Item("MAXITEMS")
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
            End If
        End If
    End Sub
    Private Sub TarriffNonVeg()
        If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE  BOOKINGNO=" & Txt_BookingNo.Text & "  and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category IN ('NON VEG')) "
            DT = GConnection.GetValues(SSQL)
        ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE  BOOKINGNO=" & Txt_BookingNo.Text & " AND ISNULL(TARIFFDESC,'')<>'' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category in ('NON VEG')) AND BOOKINGTYPE='BILLING'"
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
            GConnection.getDataSet(sqlstring, "TARIFF")
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
                        'Call FillSubCodeVeg()
                    Else
                        sqlstring = "SELECT MENUCODE,MAXITEMS FROM PARTY_TARIFFdet where TariffCode = '" & Trim(Txt_VMenuCode.Text) & "' and MenuCode = '" & Trim(SubCode) & "'"
                        GConnection.getDataSet(sqlstring, "Subcode")
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
                        'Call FillMenuVeg()
                    Else
                        sqlstring = "SELECT ITEMCODE,ITEMDESC,UOM FROM view_party_menuitemhelp where TariffCode = '" & Trim(Txt_VMenuCode.Text) & "' and MenuCode = '" & Trim(SubCode) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                        GConnection.getDataSet(sqlstring, "Itemcode")
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
            GConnection.getDataSet(sqlstring, "TARIFF")
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
                        'Call FillSubCodeNonVeg()
                    Else
                        sqlstring = "SELECT MENUCODE,MAXITEMS FROM PARTY_TARIFFdet where TariffCode = '" & Trim(Txt_NVMenuCode.Text) & "' and MenuCode = '" & Trim(SubCode) & "'"
                        GConnection.getDataSet(sqlstring, "Subcode")
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
                        'Call FillMenuNonVeg()
                    Else
                        sqlstring = "SELECT ITEMCODE,ITEMDESC,UOM FROM view_party_menuitemhelp where TariffCode = '" & Trim(Txt_NVMenuCode.Text) & "' and MenuCode = '" & Trim(SubCode) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                        GConnection.getDataSet(sqlstring, "Itemcode")
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

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        Cmd_NVMenuCodeHelp.Enabled = False
        Txt_NVMenuCode.Enabled = False
        Cmd_VMenuCodeHelp.Enabled = False
        Txt_VMenuCode.Enabled = False
        Me.Txt_BookingNo.ReadOnly = False
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
        Txt_BookingNo.Text = ""
        Dtp_PartyDate.Value = Format(serverdate, "dd/MM/yyyy")
        Dtp_BookingDate.Value = Format(serverdate, "dd/MM/yyyy")
        Txt_Purpose.Text = ""
        Txt_MemberCode.Text = ""
        Txt_MemberName.Text = ""
        Txt_TotPax.Text = ""
        Txt_GuestName.Text = ""
        Txt_VPax.Text = ""
        Txt_NVPax.Text = ""
        Txt_PaidAmt.Text = ""
        Txt_Discount.Text = ""
        Lbl_Outstanding.Text = ""
        CmdAdd.Text = "Add [F7]"
        CmdAdd.Enabled = True
        Cmd_Freeze.Enabled = True
        Button5.Enabled = True
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze [F8]"
        Call autogenerate()
        If Mid(gCompName, 1, 4) = "BBSR" Or Mid(gCompName, 1, 4) = "CATH" Then
            Cmd_Freeze.Enabled = True
        Else
            Cmd_Freeze.Enabled = False
        End If
        Grp_Settlement.Visible = False
        Txt_SettleAmt.Text = ""
        sSGrid_HallResv.ClearRange(-1, -1, 1, 1, True)
        sSGrid_HallResv.SetActiveCell(1, 1)
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
        TabControl1.SelectedIndex = 0
        Txt_BookingNo.Focus()
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
                        SSQL = "SELECT ITEMCODE,ITEMDESC,UOMCODE,RATE,OPENFACILITY,TAXCODE FROM PARTY_ITEMMASTER  WHERE ITEMCODE='" & Trim(.Text) & "' And Isnull(Freeze,'') <> 'Y' "
                        DT = GConnection.GetValues(SSQL)
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
                M_WhereCondition = " Where Isnull(Freeze,'') <> 'Y' "
            Else
                M_WhereCondition = " Where Isnull(Freeze,'') <> 'Y' "
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
                        DT = GConnection.GetValues(SSQL)
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
                            .Col = 9
                            .Row = .ActiveRow
                            .Text = Val(1)
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
        If sSGrid_Arr.ActiveCol = 1 Then
            gSQLString = " Select Itemcode,ItemDesc,Rate,AmtOverride,ChargeCode from Party_OtherChgsMaster"
            If Trim(Search) = "" Then
                M_WhereCondition = " WHERE ISNULL(Freeze,'') <> 'Y' And ITEMCODE NOT IN ('EHC','MGA')  "
            Else
                M_WhereCondition = " WHERE ISNULL(Freeze,'') <> 'Y' And ITEMCODE NOT IN ('EHC','MGA')"
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
                    .Col = 9
                    .Row = .ActiveRow
                    .Text = Val(1)
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
                .Col = 9
                .Row = i
                Qty = Val(.Text)
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
    Private Sub Check_NonGSTBIll()
        Dim ssql, SQLSTRING As String
        Dim billstrNon As String
        Try
            sqlstring = "SELECT GSTFLAG FROM RPT_PARTY_POSDETAILS_GN where BOOKINGNO = " & Trim(Txt_BookingNo.Text) & " AND ISNULL(GSTFLAG,'') = 'NO' UNION ALL"
            sqlstring = sqlstring & " SELECT GSTFLAG FROM RPT_PARTY_HALLDET_GN where BOOKINGNO = " & Trim(Txt_BookingNo.Text) & " AND ISNULL(GSTFLAG,'') = 'NO'"
            GConnection.getDataSet(sqlstring, "CheckNonGST")
            If gdataset.Tables("CheckNonGST").Rows.Count > 0 Then
                SQLSTRING = "select isnull(max(substring(NBillNo,5,6)),0)+1 as no from PARTY_HDR where BOOKINGTYPE='BILLING' AND substring(billno,12,5)='" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2) & "' AND ISNULL(NBillNo,'') <> ''"
                GConnection.getDataSet(SQLSTRING, "USER1")
                If gdataset.Tables("USER1").Rows.Count - 1 >= 0 Then
                    If Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 1 Then
                        billstrNon = "NBL/00000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
                    ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 2 Then
                        billstrNon = "NBL/0000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
                    ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 3 Then
                        billstrNon = "NBL/000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
                    ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 4 Then
                        billstrNon = "NBL/00" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
                    ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 5 Then
                        billstrNon = "NBL/0" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
                    ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 6 Then
                        billstrNon = "NBL/" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
                    End If
                End If

                SQLSTRING = "UPDATE PARTY_HDR SET NBillNo = '" & billstrNon & "' WHERE BOOKINGNO = " & Trim(Txt_BookingNo.Text) & " AND BOOKINGTYPE='BILLING'  AND ISNULL(NBillNo,'') = ''"
                GConnection.dataOperation(6, SQLSTRING, "UpdNonGST")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MininumPosting()
        Dim Insert1(0) As String
        Dim MinGAmt, TotAmtForMin As Double
        Dim MinTaxtype As String
        Dim TPercent, RoomPer, PartyPer As Double
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, Pos, KStatus As String
        Dim Qty, OthGridCount, kk As Integer

        MinGAmt = GConnection.getvalue("SELECT Isnull(SUM(ISNULL(MG_AMOUNT,0)),0) AS MG_Amount FROM Party_Hallmaster_Hdr WHERE HallTypeCode IN (SELECT HALLCODE FROM Party_Hallbooking_Det WHERE BOOKINGNO = " & Txt_BookingNo.Text & ")")
        TotAmtForMin = GConnection.getvalue("Select Isnull(SUM(Amount+TaxAmount),0) As Amt from View_MininumAmount Where Bookingno = " & Txt_BookingNo.Text & "")
        MinTaxtype = GConnection.getvalue("SELECT TOP 1 ISNULL(MG_TaxType,'') AS MG_TaxType FROM Party_Hallmaster_Hdr WHERE HallTypeCode IN (SELECT HALLCODE FROM Party_Hallbooking_Det WHERE BOOKINGNO = " & Txt_BookingNo.Text & ")")
        If MinGAmt > 0 Then
            If TotAmtForMin < MinGAmt Then
                '-- Others Item Deletion
                sqlstring = " DELETE FROM Party_OtherCharges "
                sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' And Itemcode = 'MGA'"
                ReDim Preserve Insert1(Insert1.Length)
                Insert1(Insert1.Length - 1) = sqlstring

                sqlstring = " DELETE FROM Party_OtherCharges_Tax "
                sqlstring = sqlstring & " WHERE BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' And Itemcode = 'MGA' "
                ReDim Preserve Insert1(Insert1.Length)
                Insert1(Insert1.Length - 1) = sqlstring

                '-- Others Item Insertion 
                sqlstring = "INSERT INTO Party_OtherCharges(BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,ITEMCODE,ITEMDESC,UOM,RATE,QTY,AMOUNT,TAXAMOUNT,TOTALAMOUNT,SLNO,LOCCODE,FREEZE,ADDUSERID,ADDDATETIME) Values ("
                sqlstring = sqlstring & "'" & CMBBOOKINGTYPE.Text & "','" & Trim(Txt_BookingNo.Text) & "','" & Format(Dtp_BookingDate.Value, "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & "'MGA',"
                sqlstring = sqlstring & "'Mininum Guarantee Amount','NOS',"
                sqlstring = sqlstring & "" & MinGAmt - TotAmtForMin & ",1,"
                sqlstring = sqlstring & "" & MinGAmt - TotAmtForMin & ","
                sqlstring = sqlstring & "'0',"
                sqlstring = sqlstring & "" & MinGAmt - TotAmtForMin & ","
                sqlstring = sqlstring & "" & sSGrid_Oth.DataRowCnt + 1 & ","
                sqlstring = sqlstring & "'" & Trim(Cmb_Location.Text) & "','N',"
                sqlstring = sqlstring & "'" & Trim(gUsername) & "'"
                sqlstring = sqlstring & ",GETDATE())"
                ReDim Preserve Insert1(Insert1.Length)
                Insert1(Insert1.Length - 1) = sqlstring

                Dim Itemcode As String
                Dim SNO As Integer
                Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                Itemcode = "MGA"
                GrdRate = MinGAmt - TotAmtForMin
                Qty = 1
                SNO = sSGrid_Oth.DataRowCnt + 1
                ChargeCode = Trim(MinTaxtype)
                sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                GConnection.getDataSet(sqlstring, "CODE_CHECK")
                If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                    ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                End If
                sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                GConnection.getDataSet(sqlstring, "TAXON")
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
                        ReDim Preserve Insert1(Insert1.Length)
                        Insert1(Insert1.Length - 1) = sqlstring
                    Next
                End If
                sqlstring = "  UPDATE Party_OtherCharges SET TAXAMOUNT = (SELECT ISNULL(SUM(Party_OtherCharges_Tax.TAXAMOUNT),0) FROM Party_OtherCharges_Tax  WHERE Party_OtherCharges.BOOKINGNO = Party_OtherCharges_Tax.BOOKINGNO AND Party_OtherCharges_Tax.ITEMCODE = Party_OtherCharges.ITEMCODE "
                sqlstring = sqlstring & " AND ISNULL(Party_OtherCharges_Tax.BOOKINGTYPE,'') = ISNULL(Party_OtherCharges.BOOKINGTYPE,'') AND ISNULL(Party_OtherCharges_Tax.SLNO,0) = ISNULL(Party_OtherCharges.SLNO,0) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''),ISNULL(SLNO,0)) WHERE Party_OtherCharges.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(Party_OtherCharges.BOOKINGTYPE,'') = 'BILLING'"
                ReDim Preserve Insert1(Insert1.Length)
                Insert1(Insert1.Length - 1) = sqlstring
                sqlstring = "UPDATE Party_OtherCharges SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BILLING'"
                ReDim Preserve Insert1(Insert1.Length)
                Insert1(Insert1.Length - 1) = sqlstring

                GConnection.MoreTransold1(Insert1)
            End If
        End If
    End Sub
    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim RATE, AMOUNT, GRDTAXAMOUNT As Double
        Dim vat, stax As Double
        Dim TPercent, RoomPer, PartyPer As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, PKOTAMT, ActHallAmount As Double
        Call checkValidation()
        If boolchk = False Then Exit Sub
        Dim taxtype, NChgCode As String
        Dim Insert(0), Update(0) As String
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, Pos, KStatus As String
        Dim Qty, OthGridCount, kk, ArrGridCount As Integer

        If Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
            If Trim(gUserCategory) <> "S" Then
                MsgBox("Please Contact System Administrator...", MsgBoxStyle.OkOnly, "CANCEL")
                CMBBOOKINGTYPE.Focus()
                Exit Sub
            End If
        End If
        If Trim(Txt_BookingNo.Text) <> "" Then
            sqlstring = "SELECT * FROM PARTY_ACC_POST  where bookingno=" & Txt_BookingNo.Text & " AND ISNULL(POSTFLAG,'')='Y' "
            GConnection.getDataSet(sqlstring, "accpost")
            If gdataset.Tables("accpost").Rows.Count > 0 Then
                MessageBox.Show("ALREADY ACCOUNT POSTING WAS DONE,YOU CANNOT UPDATE THE BOOKING ", MyCompanyName, MessageBoxButtons.OK)
                Exit Sub
            End If
        End If
        If Trim(Txt_BookingNo.Text) <> "" Then
            sqlstring = "SELECT * FROM Journalentry  where VoucherNo='" & TXTBILLINGNO.Text & "' AND ISNULL(VOID,'') <> 'Y' "
            GConnection.getDataSet(sqlstring, "accpost")
            If gdataset.Tables("accpost").Rows.Count > 0 Then
                MessageBox.Show("ALREADY ACCOUNT POSTING WAS DONE,YOU CANNOT UPDATE THE BOOKING ", MyCompanyName, MessageBoxButtons.OK)
                Exit Sub
            End If
        End If

        For i = 1 To sSGrid_Oth.DataRowCnt
            sSGrid_Oth.Col = 9
            sSGrid_Oth.Row = i
            sSGrid_Oth.Text = Val(1)
        Next

        OthGridCount = sSGrid_Oth.DataRowCnt
        sqlstring = "SELECT ISNULL(Extra_Hour,0) AS Extra_Hour,HALLCODE,HALLTYPE,Isnull(HALLAMOUNT,0) As HALLAMOUNT FROM PARTY_HALLBOOKING_DET  WHERE  ISNULL(Extra_Hour,0) > 0 AND ISNULL(BOOKINGNO,0) = " & Txt_BookingNo.Text & " "
        GConnection.getDataSet(sqlstring, "ExHourCheck")
        If gdataset.Tables("ExHourCheck").Rows.Count > 0 Then
            For kk = 0 To gdataset.Tables("ExHourCheck").Rows.Count - 1
                sqlstring = "SELECT ISNULL(HALFDAYHOURRATE,0) AS HALFDAYHOURRATE,ISNULL(TAXTYPE,'') AS TAXTYPE FROM Party_Hallmaster_Det D,Party_Hallmaster_Hdr H WHERE H.HallTypeCode = D.HallTypeCode AND D.HallTypeCode = '" & Trim(gdataset.Tables("ExHourCheck").Rows(kk).Item("HALLCODE")) & "' AND PCode = '" & Trim(gdataset.Tables("ExHourCheck").Rows(kk).Item("HALLTYPE")) & "' "
                GConnection.getDataSet(sqlstring, "ExRateMaster")
                If gdataset.Tables("ExRateMaster").Rows.Count > 0 Then
                    ActHallAmount = (gdataset.Tables("ExHourCheck").Rows(kk).Item("HALLAMOUNT")) + (gdataset.Tables("ExRateMaster").Rows(0).Item("HALFDAYHOURRATE") * gdataset.Tables("ExHourCheck").Rows(kk).Item("Extra_Hour"))
                    sqlstring = "SELECT ISNULL(ChargeCode,'') As ChargeCode FROM Party_RateMaster WHERE HallCode = '" & Trim(gdataset.Tables("ExHourCheck").Rows(kk).Item("HALLCODE")) & "' AND " & ActHallAmount & " BETWEEN FromSlab and ToSlab AND '" & Format(Dtp_PartyDate.Value, "dd-MMM-yyyy") & "' BETWEEN FromDate AND ToDate And ISNULL(Freeze,'') <> 'Y'"
                    GConnection.getDataSet(sqlstring, "CheckTax")
                    If gdataset.Tables("CheckTax").Rows.Count > 0 Then
                        NChgCode = Trim(gdataset.Tables("CheckTax").Rows(0).Item(0))
                    Else
                        NChgCode = Trim(gdataset.Tables("ExRateMaster").Rows(0).Item("TAXTYPE"))
                    End If
                    OthGridCount = OthGridCount + 1
                    With sSGrid_Oth
                        .Row = OthGridCount
                        .Col = 1
                        .Text = "EHC"
                        .Col = 2
                        .Text = "Extra Hours Chages"
                        .Col = 3
                        .Text = gdataset.Tables("ExRateMaster").Rows(0).Item("HALFDAYHOURRATE")
                        .Col = 7
                        .Text = Trim(NChgCode)
                        .Col = 9
                        .Text = gdataset.Tables("ExHourCheck").Rows(kk).Item("Extra_Hour")
                    End With
                    If NChgCode <> Trim(gdataset.Tables("ExRateMaster").Rows(0).Item("TAXTYPE")) Then
                        sqlstring = "DELETE FROM Party_Hallbooking_Det_Tax WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND HALLCODE = '" & Trim(gdataset.Tables("ExHourCheck").Rows(kk).Item("HALLCODE")) & "' "
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = sqlstring
                        sqlstring = "UPDATE Party_Hallbooking_Det SET ChargeCode = '" & NChgCode & "' WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND HALLCODE = '" & Trim(gdataset.Tables("ExHourCheck").Rows(kk).Item("HALLCODE")) & "' "
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = sqlstring
                        sqlstring = "INSERT INTO Party_Hallbooking_Det_Tax (BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,HALLRATE,HALLTAXCODE,CHARGECODE,HALLTAXON,HALLTAXPERC,HALLTAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE,M_Keeper) "
                        sqlstring = sqlstring & "SELECT BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,HALLAMOUNT,I.TaxCode,'" & NChgCode & "',TAXON,I.TaxPercentage,(HALLAMOUNT*I.TaxPercentage)/100, 'CHS',GETDATE(),'N','No'"
                        sqlstring = sqlstring & " FROM Party_Hallbooking_Det D,ITEMTYPEMASTER I WHERE BOOKINGNO = " & Trim(Txt_BookingNo.Text) & " AND HALLCODE = '" & Trim(gdataset.Tables("ExHourCheck").Rows(kk).Item("HALLCODE")) & "' AND I.ItemTypeCode IN (SELECT TAXTYPECODE FROM CHARGEMASTER WHERE CHARGECODE = '" & NChgCode & "') "
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = sqlstring

                        sqlstring = "UPDATE party_hallbooking_det SET HALLTAXAMOUNT = (SELECT SUM(ISNULL(party_hallbooking_DET_TAX.HALLTAXAMOUNT,0)) FROM party_hallbooking_DET_TAX  WHERE party_hallbooking_DET_TAX.BOOKINGNO = party_hallbooking_det.BOOKINGNO AND party_hallbooking_DET_TAX.HALLCODE=party_hallbooking_det.HALLCODE AND party_hallbooking_DET_TAX.HALLTYPE = party_hallbooking_det.HALLTYPE group by BOOKINGNO,HALLCODE,HALLTYPE) WHERE party_hallbooking_det.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = sqlstring
                        sqlstring = "UPDATE party_hallbooking_det SET HALLNETAMOUNT = HALLAMOUNT + HALLTAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = sqlstring
                        sqlstring = "UPDATE party_hallbooking_hdr SET TOTALAMOUNT  = (SELECT SUM(ISNULL(party_hallbooking_det.HALLAMOUNT,0)) FROM party_hallbooking_det WHERE party_hallbooking_det.BOOKINGNO =party_hallbooking_hdr.BOOKINGNO group by BOOKINGNO) WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = sqlstring
                        sqlstring = "UPDATE party_hallbooking_hdr SET HALLTAXAMOUNT  = (SELECT SUM(ISNULL(party_hallbooking_det.HALLTAXAMOUNT,0)) FROM party_hallbooking_det  WHERE party_hallbooking_det.BOOKINGNO = party_hallbooking_hdr.BOOKINGNO group by BOOKINGNO) WHERE BOOKINGNO ='" & Trim(Txt_BookingNo.Text) & "'"
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = sqlstring
                        sqlstring = "UPDATE party_hallbooking_hdr SET HALLNETAMOUNT = TOTALAMOUNT + HALLTAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = sqlstring
                    End If
                End If
            Next
        Else
            sqlstring = "SELECT BOOKINGNO,HALLCODE,HALLTYPE,HALLAMOUNT,ChargeCode,TAXTYPE FROM Party_Hallbooking_Det D,Party_Hallmaster_Hdr H WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND D.HALLCODE = H.HallTypeCode AND D.ChargeCode <> H.TaxType "
            GConnection.getDataSet(sqlstring, "TaxCheck")
            If gdataset.Tables("TaxCheck").Rows.Count > 0 And CDate(Dtp_PartyDate.Value) > CDate("30-Jun-2017") Then
                For kk = 0 To gdataset.Tables("TaxCheck").Rows.Count - 1
                    ActHallAmount = (gdataset.Tables("TaxCheck").Rows(kk).Item("HALLAMOUNT"))
                    sqlstring = "SELECT ISNULL(ChargeCode,'') As ChargeCode FROM Party_RateMaster WHERE HallCode = '" & Trim(gdataset.Tables("TaxCheck").Rows(kk).Item("HALLCODE")) & "' AND " & ActHallAmount & " BETWEEN FromSlab and ToSlab AND '" & Format(Dtp_PartyDate.Value, "dd-MMM-yyyy") & "' BETWEEN FromDate AND ToDate And ISNULL(Freeze,'') <> 'Y'"
                    GConnection.getDataSet(sqlstring, "CheckTax")
                    If gdataset.Tables("CheckTax").Rows.Count > 0 Then
                        NChgCode = Trim(gdataset.Tables("CheckTax").Rows(0).Item(0))
                    Else
                        NChgCode = Trim(gdataset.Tables("TaxCheck").Rows(0).Item("TAXTYPE"))
                    End If
                    sqlstring = "DELETE FROM Party_Hallbooking_Det_Tax WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND HALLCODE = '" & Trim(gdataset.Tables("TaxCheck").Rows(kk).Item("HALLCODE")) & "' "
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = sqlstring
                    sqlstring = "UPDATE Party_Hallbooking_Det SET ChargeCode = '" & NChgCode & "' WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND HALLCODE = '" & Trim(gdataset.Tables("TaxCheck").Rows(kk).Item("HALLCODE")) & "' "
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = sqlstring
                    sqlstring = "INSERT INTO Party_Hallbooking_Det_Tax (BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,HALLRATE,HALLTAXCODE,CHARGECODE,HALLTAXON,HALLTAXPERC,HALLTAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE,M_Keeper) "
                    sqlstring = sqlstring & "SELECT BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,HALLAMOUNT,I.TaxCode,'" & NChgCode & "',TAXON,I.TaxPercentage,(HALLAMOUNT*I.TaxPercentage)/100, 'CHS',GETDATE(),'N','No'"
                    sqlstring = sqlstring & " FROM Party_Hallbooking_Det D,ITEMTYPEMASTER I WHERE BOOKINGNO = " & Trim(Txt_BookingNo.Text) & " AND HALLCODE = '" & Trim(gdataset.Tables("TaxCheck").Rows(kk).Item("HALLCODE")) & "' AND I.ItemTypeCode IN (SELECT TAXTYPECODE FROM CHARGEMASTER WHERE CHARGECODE = '" & NChgCode & "') "
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = sqlstring

                    sqlstring = "UPDATE party_hallbooking_det SET HALLTAXAMOUNT = (SELECT SUM(ISNULL(party_hallbooking_DET_TAX.HALLTAXAMOUNT,0)) FROM party_hallbooking_DET_TAX  WHERE party_hallbooking_DET_TAX.BOOKINGNO = party_hallbooking_det.BOOKINGNO AND party_hallbooking_DET_TAX.HALLCODE=party_hallbooking_det.HALLCODE AND party_hallbooking_DET_TAX.HALLTYPE = party_hallbooking_det.HALLTYPE group by BOOKINGNO,HALLCODE,HALLTYPE) WHERE party_hallbooking_det.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = sqlstring
                    sqlstring = "UPDATE party_hallbooking_det SET HALLNETAMOUNT = HALLAMOUNT + HALLTAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = sqlstring
                    sqlstring = "UPDATE party_hallbooking_hdr SET TOTALAMOUNT  = (SELECT SUM(ISNULL(party_hallbooking_det.HALLAMOUNT,0)) FROM party_hallbooking_det WHERE party_hallbooking_det.BOOKINGNO =party_hallbooking_hdr.BOOKINGNO group by BOOKINGNO) WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = sqlstring
                    sqlstring = "UPDATE party_hallbooking_hdr SET HALLTAXAMOUNT  = (SELECT SUM(ISNULL(party_hallbooking_det.HALLTAXAMOUNT,0)) FROM party_hallbooking_det  WHERE party_hallbooking_det.BOOKINGNO = party_hallbooking_hdr.BOOKINGNO group by BOOKINGNO) WHERE BOOKINGNO ='" & Trim(Txt_BookingNo.Text) & "'"
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = sqlstring
                    sqlstring = "UPDATE party_hallbooking_hdr SET HALLNETAMOUNT = TOTALAMOUNT + HALLTAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = sqlstring
                Next
            End If
        End If

        Call Calculate_Arrange()
        Call Calculate_Others()

        If Mid(Me.CmdAdd.Text, 1, 1) = "U" And CMBBOOKINGTYPE.Text = "CANCEL" Then
            MessageBox.Show(" This Booking is Cancelled Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.CmdClear_Click(sender, e)
            Exit Sub
        ElseIf Mid(Me.CmdAdd.Text, 1, 1) = "U" And CMBBOOKINGTYPE.Text = "BOOKING" Then
            SSQL = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' and Isnull(BILLINGFLAG,'')='Y'"
            DT = GConnection.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                MessageBox.Show(" Billing Over, can't be Updated", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.CmdClear_Click(sender, e)
                Exit Sub
            End If
        ElseIf Mid(Me.CmdAdd.Text, 1, 1) = "U" And CMBBOOKINGTYPE.Text = "BILLING" Then
            SSQL = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' and Isnull(bookingflag,'')<>'Y'"
            DT = GConnection.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                If Mid(gCompName, 1, 4) = "KSCA" Then
                Else
                    MessageBox.Show(" Booking is Not Complete,Can Not Be Insert", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.CmdClear_Click(sender, e)
                    Exit Sub
                End If
            End If
        Else
            SSQL = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' and Isnull(cancelflag,'')='Y'"
            DT = GConnection.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                MessageBox.Show(" This Booking is Cancelled Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.CmdClear_Click(sender, e)
                Exit Sub
            End If
        End If
        If Mid(CmdAdd.Text, 1, 1) = "A" Then
            Call autogenerate()
            sqlstring = "INSERT INTO PARTY_HDR(BILLNO,LOCCODE,BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,PARTYDATE,MCODE,GUESTNAME,"
            sqlstring = sqlstring & "OCCUPANCY,veg,nonveg,HALLTAXFLAG,"
            sqlstring = sqlstring & "FREEZE,ADDUSERID,ADDDATETIME,vegcode,MENUCODE,nonvegcode,OvrallDiscount) "
            sqlstring = sqlstring & " VALUES('" & Trim(TXTBILLINGNO.Text) & "','" & Trim(Cmb_Location.Text) & "','" & Trim(CMBBOOKINGTYPE.Text) & "'," & Trim(Txt_BookingNo.Text)
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
            sqlstring = sqlstring & ",'" & Trim(Txt_NVMenuCode.Text) & "'," & Val(Txt_Discount.Text) & ")"
            Insert(0) = sqlstring
            sqlstring = "UPDATE PARTY_HDR SET ASSOCIATENAME = H.ASSOCIATENAME,HALLAMOUNT = H.TOTALAMOUNT,HALLTAXAMOUNT = H.HallTaxAmount,DESCRIPTION = H.DESCRIPTION  FROM party_hallbooking_hdr H,PARTY_HDR P WHERE H.BOOKINGNO = P.BOOKINGNO AND P.BOOKINGTYPE = 'BILLING' AND H.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            '-- Veg Menu Insertion
            With sSGrid_VPax
                If .DataRowCnt > 0 Then
                    sqlstring = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & Txt_VMenuCode.Text & "' AND CATEGORY='VEG'"
                    GConnection.getDataSet(sqlstring, "TARIFF")
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
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
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
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        End If
                    Next
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    GrdRate = RATE
                    Qty = Val(Txt_VPax.Text)
                    ChargeCode = ChargeCode
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    GConnection.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    GConnection.getDataSet(sqlstring, "TAXON")
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
                            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate(),'BILLING')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next
                    End If
                End If
            End With
            '-- Non Veg Menu Insertion
            With sSGrid_NVPax
                If .DataRowCnt > 0 Then
                    sqlstring = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & Txt_NVMenuCode.Text & "' AND CATEGORY='NON VEG'"
                    GConnection.getDataSet(sqlstring, "TARIFF")
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
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
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
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        End If
                    Next
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    GrdRate = RATE
                    Qty = Val(Txt_NVPax.Text)
                    ChargeCode = ChargeCode
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    GConnection.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    GConnection.getDataSet(sqlstring, "TAXON")
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
                            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate(),'BILLING')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next
                    End If
                End If
            End With
            sqlstring = " UPDATE PARTY_RESTAURANT SET TAXAMOUNT = (SELECT ISNULL(SUM(PARTY_RESTAURANT_TAX.TAXAMOUNT),0) FROM PARTY_RESTAURANT_TAX  WHERE PARTY_RESTAURANT.BOOKINGNO = PARTY_RESTAURANT_TAX.BOOKINGNO AND PARTY_RESTAURANT_TAX.ITEMCODE = PARTY_RESTAURANT.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(PARTY_RESTAURANT_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_RESTAURANT.BOOKINGTYPE,'') GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,'')) WHERE PARTY_RESTAURANT.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(PARTY_RESTAURANT.BOOKINGTYPE,'') = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            sqlstring = "UPDATE PARTY_RESTAURANT SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
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
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
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
                        GConnection.getDataSet(sqlstring, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GConnection.getDataSet(sqlstring, "TAXON")
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
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            Next
                        End If
                    Next
                End If
            End With
            sqlstring = " UPDATE PARTY_ARRANGEMENT SET TAXAMOUNT = (SELECT ISNULL(SUM(party_arrangement_TAX.TAXAMOUNT),0) FROM party_arrangement_TAX  WHERE PARTY_ARRANGEMENT.BOOKINGNO = party_arrangement_TAX.BOOKINGNO AND party_arrangement_TAX.ITEMCODE = PARTY_ARRANGEMENT.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(party_arrangement_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') AND ISNULL(party_arrangement_TAX.SLNO,0) = ISNULL(PARTY_ARRANGEMENT.SLNO,0) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''),ISNULL(SLNO,0)) WHERE PARTY_ARRANGEMENT.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            sqlstring = "UPDATE PARTY_ARRANGEMENT SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

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
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 9
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
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
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
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
                        .Col = 9
                        .Row = i
                        Qty = .Text
                        .Col = 8
                        .Row = i
                        SNO = .Text
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
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            Next
                        End If
                    Next
                End If
            End With
            sqlstring = "  UPDATE Party_OtherCharges SET TAXAMOUNT = (SELECT ISNULL(SUM(Party_OtherCharges_Tax.TAXAMOUNT),0) FROM Party_OtherCharges_Tax  WHERE Party_OtherCharges.BOOKINGNO = Party_OtherCharges_Tax.BOOKINGNO AND Party_OtherCharges_Tax.ITEMCODE = Party_OtherCharges.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(Party_OtherCharges_Tax.BOOKINGTYPE,'') = ISNULL(Party_OtherCharges.BOOKINGTYPE,'') AND ISNULL(Party_OtherCharges_Tax.SLNO,0) = ISNULL(Party_OtherCharges.SLNO,0) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''),ISNULL(SLNO,0)) WHERE Party_OtherCharges.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(Party_OtherCharges.BOOKINGTYPE,'') = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            sqlstring = "UPDATE Party_OtherCharges SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            If Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BILLINGFLAG='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = SSQL

            ElseIf Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BOOKINGFLAG='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = SSQL
            End If
            With sSGrid_Kot
                If .DataRowCnt > 0 Then
                    sqlstring = "DELETE FROM PARTY_KOT_DET WHERE KOTDETAILS = '" & Txt_BookingNo.Text & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM PARTY_KOT_DET_TAX WHERE KOTDETAILS = '" & Txt_BookingNo.Text & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                    sqlstring = "INSERT INTO PARTY_KOT_DET (KOTNO,KOTDETAILS,KOTDATE,BILLDETAILS,CATEGORY,ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE, "
                    sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,KOTTYPE,ALCHOLST,CHITNO,PAYMENTMODE,DelFlag,AddUserid,Adddatetime,UpdUserid,Upddatetime,PACKAMT,DISCAMT,PACKPERCENT,"
                    sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,PDA_PRINT_FLAG,PDA_DELETE_FLAG,IS_PDA,SUBGroupCode,TipsPer,TipsAmt,AdCgsPer,AdCgsAmt,PartyPer,PartyAmt,RoomPer,RoomAmt,MKOTNO,BOOKINGTYPE,SNO) "
                    If Mid(gCompName, 1, 2) = "HC" Then
                        sqlstring = sqlstring & " SELECT '" & Txt_BookingNo.Text & "','" & Txt_BookingNo.Text & "',KOTDATE,'" & Txt_BookingNo.Text & "','PAR',ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE,"
                        sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,'PAR',ALCHOLST,0,PAYMENTMODE,DelFlag,'CHS',GETDATE(),UpdUserid,GETDATE(),PACKAMT,DISCAMT,PACKPERCENT,"
                        sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,'','','',GroupCode,TIPSPERCENT,TIPSAMOUNT,0,0,0,0,0,0,KOTDETAILS,'BILLING',0"
                        sqlstring = sqlstring & " FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "')  AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> ''  "
                    Else
                        sqlstring = sqlstring & " SELECT '" & Txt_BookingNo.Text & "','" & Txt_BookingNo.Text & "',KOTDATE,'" & Txt_BookingNo.Text & "',CATEGORY,ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE,"
                        sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,'PAR',ALCHOLST,CHITNO,PAYMENTMODE,DelFlag,'" & Trim(gUsername) & "',GETDATE(),UpdUserid,GETDATE(),PACKAMT,DISCAMT,PACKPERCENT,"
                        sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,ISNULL(PDA_PRINT_FLAG,''),ISNULL(PDA_DELETE_FLAG,''),ISNULL(IS_PDA,''),SUBGroupCode,TipsPer,TipsAmt,AdCgsPer,AdCgsAmt,PartyPer,PartyAmt,RoomPer,RoomAmt,KOTDETAILS,'BILLING',SLNO"
                        sqlstring = sqlstring & " FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "') AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> '' "
                    End If
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "INSERT INTO PARTY_KOT_DET_TAX (KOTDETAILS,KOTDATE,TTYPE,CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,ADD_USER,ADD_DATE,VOID,VOIDUSER,SNO)"
                    sqlstring = sqlstring & "SELECT '" & Txt_BookingNo.Text & "',KOTDATE,'PAR',CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,'" & Trim(gUsername) & "',GETDATE(),VOID,'',SLNO"
                    sqlstring = sqlstring & " FROM KOT_DET_TAX WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
            End With

            GConnection.MoreTransold(Insert)

            If Update.Length > 0 Then
                GConnection.MoreTransold1(Update)
            End If

            If Mid(gCompName, 1, 3) = "DCL" Then
                sqlstring = "EXEC PARTY_DIRECT_POST '" & Txt_BookingNo.Text & "'"
                GConnection.ExcuteStoreProcedure(sqlstring)
            End If
            If Mid(gCompName, 1, 3) = "GNC" Then
                Call MininumPosting()
            End If
            Call Check_NonGSTBIll()

            If MessageBox.Show("Do You Want View it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                Call Cmdview_Click(sender, e)
            End If
            Call CmdClear_Click(sender, e)

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
            sqlstring = sqlstring & ",OvrallDiscount=" & Val(Txt_Discount.Text) & ""
            sqlstring = sqlstring & ",HALLTAXFLAG='Y' "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' "
            Insert(0) = sqlstring
            sqlstring = "UPDATE PARTY_HDR SET ASSOCIATENAME = H.ASSOCIATENAME,HALLAMOUNT = H.TOTALAMOUNT,HALLTAXAMOUNT = H.HallTaxAmount  FROM party_hallbooking_hdr H,PARTY_HDR P WHERE H.BOOKINGNO = P.BOOKINGNO AND P.BOOKINGTYPE = 'BILLING' AND H.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            If Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BILLINGFLAG='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = SSQL
            ElseIf Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BOOKINGFLAG='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = SSQL
            ElseIf Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                Dim HRS, OCC As Integer
                Dim TRATE, CANRATE, CANAMT, CANHEAD, CANFROM, CANTO As Double
                SSQL = "SELECT ISNULL(T.RATE,0)AS RATE,ISNULL(H.TARIFFCODE,'')AS TARIFF,H.BOOKINGDATE,ISNULL(P.OCCUPANCY,0)AS OCCUPANCY "
                SSQL = SSQL & " FROM PARTY_HALLBOOKING_HDR H,"
                SSQL = SSQL & " PARTY_HDR P,PARTY_TARIFFHDR T "
                SSQL = SSQL & " WHERE H.BOOKINGNO=P.BOOKINGNO AND P.BOOKINGDATE=H.BOOKINGDATE AND "
                SSQL = SSQL & " H.TARIFFCODE = T.TARIFFCODE AND H.BOOKINGNO=" & Val(Txt_BookingNo.Text) & " AND P.LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                SSQL = SSQL & " GROUP BY T.RATE,H.TARIFFCODE,H.BOOKINGDATE,P.OCCUPANCY"
                GConnection.getDataSet(SSQL, "book")
                If gdataset.Tables("book").Rows.Count > 0 Then
                    HRS = DateDiff(DateInterval.Hour, gdataset.Tables("book").Rows(0).Item("BOOKINGDATE"), Now())
                    OCC = gdataset.Tables("book").Rows(0).Item("OCCUPANCY")
                    TRATE = gdataset.Tables("book").Rows(0).Item("RATE")
                End If
                SSQL = "SELECT ISNULL(CANCELFROM,0)AS CANCELFROM,ISNULL(CANCELTO,0)AS CANCELTO,ISNULL(CANCEL_AMT_PER,0)AS PERAMT,ISNULL(CANCEL_AMT_HEAD,0)AS HEADAMT,ISNULL(FIXEDAMOUNT,0)AS FIXAMT FROM PARTY_CANCELLATIONMASTER WHERE " & Val(HRS) & " BETWEEN CANCELFROM AND CANCELTO "
                GConnection.getDataSet(SSQL, "CANCEL")
                If gdataset.Tables("CANCEL").Rows.Count > 0 Then
                    CANHEAD = gdataset.Tables("CANCEL").Rows(0).Item("CANCEL_AMT_HEAD")
                    CANRATE = gdataset.Tables("CANCEL").Rows(0).Item("FIXEDAMOUNT")
                    CANFROM = gdataset.Tables("CANCEL").Rows(0).Item("CANCELFROM")
                    CANTO = gdataset.Tables("CANCEL").Rows(0).Item("CANCELTO")
                    CANAMT = (Val(OCC) * TRATE) + (Val(OCC) * Val(CANHEAD)) + Val(CANRATE)
                End If
                SSQL = " UPDATE  PARTY_HDR SET FREEZE='Y',HALLCANCELAMOUNT=" & Val(CANAMT) & ",FROMHRS=" & Val(CANFROM) & ",TOHRS=" & Val(CANTO) & ",CANCELDATE='" & Format(DateTime.Now, "dd/MMM/yyyy hh:mm:ss") & "' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                Insert(Insert.Length - 1) = SSQL
                ReDim Preserve Insert(Insert.Length)

                SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET CANCELFLAG='Y',FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                Insert(Insert.Length - 1) = SSQL
                ReDim Preserve Insert(Insert.Length)

                SSQL = " UPDATE  PARTY_HALLBOOKING_DET SET FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                Insert(Insert.Length - 1) = SSQL
                ReDim Preserve Insert(Insert.Length)

                SSQL = " UPDATE PARTY_RECEIPT SET FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                Insert(Insert.Length - 1) = SSQL
                ReDim Preserve Insert(Insert.Length)

                SSQL = " UPDATE PARTY_RESTAURANT SET FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                Insert(Insert.Length - 1) = SSQL
                ReDim Preserve Insert(Insert.Length)

                SSQL = " UPDATE PARTY_ARRANGEMENT SET FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                Insert(Insert.Length - 1) = SSQL
                ReDim Preserve Insert(Insert.Length)

                SSQL = " UPDATE PARTY_HALLFACILITY SET FREEZE='Y' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                Insert(Insert.Length - 1) = SSQL
                ReDim Preserve Insert(Insert.Length)
            End If
            If Mid(UCase(Trim(gCompName)), 1, 3) = "ALU" Then
                sqlstring = "UPDATE  PARTY_HDR SET "
                sqlstring = sqlstring & " BILLDATE='" & Format(DateTime.Now, "dd/MMM/yyyy hh:mm:ss") & "' WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
            End If
            '-- Veg Menu Deletion
            sqlstring = " DELETE FROM PARTY_RESTAURANT "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND TTYPE='T'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' AND TYPE='VEG' AND ITEMCODE='" & Trim(Txt_VMenuCode.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            sqlstring = " DELETE FROM PARTY_RESTAURANT_DET "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND TTYPE='VEG' AND TARIFFCODE='" & Trim(Txt_VMenuCode.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            sqlstring = " DELETE FROM PARTY_RESTAURANT_TAX "
            sqlstring = sqlstring & " WHERE BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND TTYPE='VEG' AND ITEMCODE='" & Trim(Txt_VMenuCode.Text) & "' AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            '-- Veg Menu Insertion
            With sSGrid_VPax
                If .DataRowCnt > 0 Then
                    sqlstring = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & Txt_VMenuCode.Text & "' AND CATEGORY='VEG'"
                    GConnection.getDataSet(sqlstring, "TARIFF")
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
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
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
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        End If
                    Next
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    GrdRate = RATE
                    Qty = Val(Txt_VPax.Text)
                    ChargeCode = ChargeCode
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    GConnection.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    GConnection.getDataSet(sqlstring, "TAXON")
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
                            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate(),'BILLING')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next
                    End If
                End If
            End With
            '-- Non Veg Menu Deletion
            sqlstring = " DELETE FROM PARTY_RESTAURANT "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND TTYPE='T'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "' AND TYPE='NONVEG' AND ITEMCODE='" & Trim(Txt_NVMenuCode.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            sqlstring = " DELETE FROM PARTY_RESTAURANT_DET "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND TTYPE='NONVEG' AND TARIFFCODE='" & Trim(Txt_NVMenuCode.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            sqlstring = " DELETE FROM PARTY_RESTAURANT_TAX "
            sqlstring = sqlstring & " WHERE BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND TTYPE='NONVEG' AND ITEMCODE='" & Trim(Txt_NVMenuCode.Text) & "' AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            '-- Non Veg Menu Insertion
            With sSGrid_NVPax
                If .DataRowCnt > 0 Then
                    sqlstring = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & Txt_NVMenuCode.Text & "' AND CATEGORY='NON VEG'"
                    GConnection.getDataSet(sqlstring, "TARIFF")
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
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
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
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        End If
                    Next
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    GrdRate = RATE
                    Qty = Val(Txt_NVPax.Text)
                    ChargeCode = ChargeCode
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    GConnection.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    GConnection.getDataSet(sqlstring, "TAXON")
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
                            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "',getdate(),'BILLING')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next
                    End If
                End If
            End With
            sqlstring = " UPDATE PARTY_RESTAURANT SET TAXAMOUNT = (SELECT ISNULL(SUM(PARTY_RESTAURANT_TAX.TAXAMOUNT),0) FROM PARTY_RESTAURANT_TAX  WHERE PARTY_RESTAURANT.BOOKINGNO = PARTY_RESTAURANT_TAX.BOOKINGNO AND PARTY_RESTAURANT_TAX.ITEMCODE = PARTY_RESTAURANT.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(PARTY_RESTAURANT_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_RESTAURANT.BOOKINGTYPE,'') GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,'')) WHERE PARTY_RESTAURANT.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(PARTY_RESTAURANT.BOOKINGTYPE,'') = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            sqlstring = "UPDATE PARTY_RESTAURANT SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            '-- Arrangement Item Deletion
            sqlstring = " DELETE FROM PARTY_ARRANGEMENT "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            sqlstring = " DELETE FROM party_arrangement_TAX "
            sqlstring = sqlstring & " WHERE BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' "
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

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
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
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
                        GConnection.getDataSet(sqlstring, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GConnection.getDataSet(sqlstring, "TAXON")
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
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            Next
                        End If
                    Next
                End If
            End With
            sqlstring = " UPDATE PARTY_ARRANGEMENT SET TAXAMOUNT = (SELECT ISNULL(SUM(party_arrangement_TAX.TAXAMOUNT),0) FROM party_arrangement_TAX  WHERE PARTY_ARRANGEMENT.BOOKINGNO = party_arrangement_TAX.BOOKINGNO AND party_arrangement_TAX.ITEMCODE = PARTY_ARRANGEMENT.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(party_arrangement_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') AND ISNULL(party_arrangement_TAX.SLNO,0) = ISNULL(PARTY_ARRANGEMENT.SLNO,0) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''),ISNULL(SLNO,0)) WHERE PARTY_ARRANGEMENT.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            sqlstring = "UPDATE PARTY_ARRANGEMENT SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            '-- Others Item Deletion
            sqlstring = " DELETE FROM Party_OtherCharges "
            sqlstring = sqlstring & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & " AND BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            sqlstring = " DELETE FROM Party_OtherCharges_Tax "
            sqlstring = sqlstring & " WHERE BOOKINGNO=" & Trim(Txt_BookingNo.Text) & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' "
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

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
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
                        .Col = 9
                        sqlstring = sqlstring & "'" & Val(.Text) & "',"
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
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
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
                        .Col = 9
                        .Row = i
                        Qty = .Text
                        .Col = 8
                        .Row = i
                        SNO = .Text
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
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            Next
                        End If
                    Next
                End If
            End With
            sqlstring = "  UPDATE Party_OtherCharges SET TAXAMOUNT = (SELECT ISNULL(SUM(Party_OtherCharges_Tax.TAXAMOUNT),0) FROM Party_OtherCharges_Tax  WHERE Party_OtherCharges.BOOKINGNO = Party_OtherCharges_Tax.BOOKINGNO AND Party_OtherCharges_Tax.ITEMCODE = Party_OtherCharges.ITEMCODE "
            sqlstring = sqlstring & " AND ISNULL(Party_OtherCharges_Tax.BOOKINGTYPE,'') = ISNULL(Party_OtherCharges.BOOKINGTYPE,'') AND ISNULL(Party_OtherCharges_Tax.SLNO,0) = ISNULL(Party_OtherCharges.SLNO,0) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''),ISNULL(SLNO,0)) WHERE Party_OtherCharges.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'  AND ISNULL(Party_OtherCharges.BOOKINGTYPE,'') = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            sqlstring = "UPDATE Party_OtherCharges SET TOTALAMOUNT = AMOUNT + TAXAMOUNT WHERE BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "' AND BOOKINGTYPE = 'BILLING'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            With sSGrid_Kot
                If .DataRowCnt > 0 Then
                    sqlstring = "DELETE FROM PARTY_KOT_DET WHERE KOTDETAILS = '" & Txt_BookingNo.Text & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM PARTY_KOT_DET_TAX WHERE KOTDETAILS = '" & Txt_BookingNo.Text & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                    sqlstring = "INSERT INTO PARTY_KOT_DET (KOTNO,KOTDETAILS,KOTDATE,BILLDETAILS,CATEGORY,ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE, "
                    sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,KOTTYPE,ALCHOLST,CHITNO,PAYMENTMODE,DelFlag,AddUserid,Adddatetime,UpdUserid,Upddatetime,PACKAMT,DISCAMT,PACKPERCENT,"
                    sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,PDA_PRINT_FLAG,PDA_DELETE_FLAG,IS_PDA,SUBGroupCode,TipsPer,TipsAmt,AdCgsPer,AdCgsAmt,PartyPer,PartyAmt,RoomPer,RoomAmt,MKOTNO,BOOKINGTYPE,SNO) "
                    ''sqlstring = sqlstring & " SELECT '" & Txt_BookingNo.Text & "','" & Txt_BookingNo.Text & "',KOTDATE,'" & Txt_BookingNo.Text & "',CATEGORY,ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE,"
                    ''sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,'PAR',ALCHOLST,CHITNO,PAYMENTMODE,DelFlag,'" & Trim(gUsername) & "',GETDATE(),UpdUserid,GETDATE(),PACKAMT,DISCAMT,PACKPERCENT,"
                    ''sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,ISNULL(PDA_PRINT_FLAG,''),ISNULL(PDA_DELETE_FLAG,''),ISNULL(IS_PDA,''),SUBGroupCode,TipsPer,TipsAmt,AdCgsPer,AdCgsAmt,PartyPer,PartyAmt,RoomPer,RoomAmt,KOTDETAILS,'BILLING',SLNO"
                    ''sqlstring = sqlstring & " FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "') AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> ''"
                    If Mid(gCompName, 1, 2) = "HC" Then
                        sqlstring = sqlstring & " SELECT '" & Txt_BookingNo.Text & "','" & Txt_BookingNo.Text & "',KOTDATE,'" & Txt_BookingNo.Text & "','PAR',ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE,"
                        sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,'PAR',ALCHOLST,0,PAYMENTMODE,DelFlag,'CHS',GETDATE(),UpdUserid,GETDATE(),PACKAMT,DISCAMT,PACKPERCENT,"
                        sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,'','','',GroupCode,TIPSPERCENT,TIPSAMOUNT,0,0,0,0,0,0,KOTDETAILS,'BILLING',0"
                        sqlstring = sqlstring & " FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "')  AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> ''  "
                    Else
                        sqlstring = sqlstring & " SELECT '" & Txt_BookingNo.Text & "','" & Txt_BookingNo.Text & "',KOTDATE,'" & Txt_BookingNo.Text & "',CATEGORY,ITEMCODE,ITEMDESC,GROUPCODE,ITEMTYPE,POSCODE,UOM,QTY,RATE,AMOUNT,TAXTYPE,TAXPERC,TAXCODE,TAXAMOUNT,TAXACCOUNTCODE,"
                        sqlstring = sqlstring & "SALESACCOUNTCODE,KOTSTATUS,MCODE,SCODE,TOTAMT,TAXAMT,BILLAMT,COVERS,TABLENO,'PAR',ALCHOLST,CHITNO,PAYMENTMODE,DelFlag,'" & Trim(gUsername) & "',GETDATE(),UpdUserid,GETDATE(),PACKAMT,DISCAMT,PACKPERCENT,"
                        sqlstring = sqlstring & "PACKAMOUNT,OPENFACILITYST,PROMOTIONALST,ISNULL(PDA_PRINT_FLAG,''),ISNULL(PDA_DELETE_FLAG,''),ISNULL(IS_PDA,''),SUBGroupCode,TipsPer,TipsAmt,AdCgsPer,AdCgsAmt,PartyPer,PartyAmt,RoomPer,RoomAmt,KOTDETAILS,'BILLING',SLNO"
                        sqlstring = sqlstring & " FROM KOT_DET WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "') AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> '' "
                    End If
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "INSERT INTO PARTY_KOT_DET_TAX (KOTDETAILS,KOTDATE,TTYPE,CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,ADD_USER,ADD_DATE,VOID,VOIDUSER,SNO)"
                    sqlstring = sqlstring & "SELECT '" & Txt_BookingNo.Text & "',KOTDATE,'PAR',CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,'" & Trim(gUsername) & "',GETDATE(),VOID,'',SLNO"
                    sqlstring = sqlstring & " FROM KOT_DET_TAX WHERE KOTDETAILS IN (SELECT KOTDETAILS FROM KOT_HDR WHERE PaymentType = 'PARTY' AND PartyOrderNo = '" & Txt_BookingNo.Text & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                End If
            End With

            GConnection.MoreTransold(Insert)

            If Update.Length > 0 Then
                GConnection.MoreTransold1(Update)
            End If

            If Mid(gCompName, 1, 3) = "DCL" Then
                sqlstring = "EXEC PARTY_DIRECT_POST '" & Txt_BookingNo.Text & "'"
                GConnection.ExcuteStoreProcedure(sqlstring)
            End If
            If Mid(gCompName, 1, 3) = "GNC" Then
                Call MininumPosting()
            End If
            ''Call Check_NonGSTBIll()
            Call CmdClear_Click(sender, e)

        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        If Trim(Txt_BookingNo.Text) = "" Then
            MessageBox.Show(" Booking No can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_BookingNo.Focus()
            Exit Sub
        End If
        Dim LOC As String
        SSQL = "SELECT ISNULL(LOCCODE,'')AS LOCCODE FROM party_locationmaster"
        GCONNECTION.getDataSet(SSQL, "LOC")
        If gdataset.Tables("LOC").Rows.Count > 0 Then
            LOC = Trim(gdataset.Tables("LOC").Rows(0).Item("LOCCODE"))
        End If
        If Trim(Txt_TotPax.Text) = "" Then
            MessageBox.Show(" Occupancy can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_TotPax.Focus()
            Exit Sub
        End If
        If Trim(Txt_MemberCode.Text) = "" Then
            MessageBox.Show(" Member Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_MemberCode.Focus()
            Exit Sub
        End If
        If Trim(Txt_GuestName.Text) = "" Then
            MessageBox.Show(" Guest Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_GuestName.Focus()
            Exit Sub
        End If
        If Mid(gCompName, 1, 4) = "CATH" Then
            If CDate(Dtp_PartyDate.Value) > serverdate Then
                MessageBox.Show(" Yout can't Make Future date Party Bill ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        boolchk = True
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

    Private Sub Cmdview_Click(sender As Object, e As EventArgs) Handles Cmdview.Click
        Dim servercode() As String
        Dim i As Integer
        Dim BOOLCHK As Boolean
        BOOLCHK = False
        Dim sqlstring, SSQL, SSQL1, SSQL2, SSQL3, SSQ, SQL1, SSQL4, SSQL5, SSQL6, SSQL7, SQL8, SQL9, SQL10, SSQL12, SSQL13, BillNo, TDATE, Occupancy, GSTIN, MGSTINNO As String
        Dim HALLDESC As String
        Dim PTodate, Pdate, BILLDATE As Date
        Dim Viewer As New ReportViwer
        Dim POSdesc(), MemberCode() As String
        Dim sqlstring1, NonStandApp As String
        Dim SQLSTRING2 As String
        Dim OvrallDiscount As Double
        Dim GSTINNO, TINNO, CSTNO, SERVICETAX As String
        Dim HALLAMOUNT, AMOUNT, SGST, CGST, DISCOUNT, RECEIPT, NETAMOUNT, BAL, PHONE1, PHONE2 As String
        If Mid(UCase(Trim(gCompName)), 1, 3) = "ALU" Then
            SSQL13 = "SELECT ISNULL(PHONE1,'') AS PHONE1,ISNULL(PHONE2,'') AS PHONE2,ISNULL(GSTINNO,'') AS GSTINNO,ISNULL(TINNO,'') AS TINNO,ISNULL(CSTNO,'') AS CSTNO,ISNULL(SERVICETAX,'') AS SERVICETAX FROM MASTER..CLUBMASTER WHERE DATAFILE IN (SELECT db_name())"
            GConnection.getDataSet(SSQL13, "MASTER")
            If gdataset.Tables("MASTER").Rows.Count > 0 Then
                PHONE1 = gdataset.Tables("MASTER").Rows(0).Item("PHONE1")
                PHONE2 = gdataset.Tables("MASTER").Rows(0).Item("PHONE2")
                GSTINNO = gdataset.Tables("MASTER").Rows(0).Item("GSTINNO")
                TINNO = gdataset.Tables("MASTER").Rows(0).Item("TINNO")
                CSTNO = gdataset.Tables("MASTER").Rows(0).Item("CSTNO")
                'SERVICETAX = gdataset.Tables("MASTER").Rows(0).Item("SERVICETAX")
            End If
        Else
            GSTIN = GConnection.getvalue("SELECT ISNULL(GSTINNO,'') AS GSTINNO  FROM master..CLUBMASTER WHERE DATAfile in(select db_name())")
        End If

        GSTIN = GConnection.getvalue("SELECT ISNULL(GSTINNO,'') AS GSTINNO  FROM master..CLUBMASTER WHERE DATAfile in(select db_name())")

        SQL1 = "SELECT isnull(OvrallDiscount,0) as OvrallDiscount,* FROM party_hdr WHERE BOOKINGNO = " & Txt_BookingNo.Text & " AND ISNULL(BOOKINGTYPE,'') = 'BILLING'"
        GConnection.getDataSet(SQL1, "RPT1")
        If gdataset.Tables("RPT1").Rows.Count = 0 Then
            MessageBox.Show("Bill Not Done Plz Check", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        Else
            Occupancy = gdataset.Tables("RPT1").Rows(0).Item("OCCUPANCY")
            OvrallDiscount = gdataset.Tables("RPT1").Rows(0).Item("OvrallDiscount")
        End If

        Dim R
        If Mid(UCase(Trim(gCompName)), 1, 3) = "BRC" Then
            R = New CRPT_PAR_BILLING_BRC
        ElseIf Mid(UCase(Trim(gCompName)), 1, 3) = "MGC" Then
            R = New CRPT_PAR_BILLING_MGC
        ElseIf Mid(UCase(Trim(gCompName)), 1, 3) = "CCL" Then
            R = New CRPT_PAR_BILLING_CCL
        ElseIf Mid(UCase(Trim(gCompName)), 1, 3) = "GNC" Then
            R = New CRPT_PAR_BILLING_GNC
        ElseIf Mid(UCase(Trim(gCompName)), 1, 2) = "HC" Then
            R = New CRPT_PAR_BILLING_HC
        ElseIf Mid(UCase(Trim(gCompName)), 1, 3) = "BCL" Then
            R = New CRPT_PAR_BILLING_BCL
        ElseIf Mid(UCase(Trim(gCompName)), 1, 3) = "ALU" Then
            R = New CRPT_PAR_BILLING_ALU
        ElseIf Mid(UCase(Trim(gCompName)), 1, 4) = "FNCC" Then
            R = New CRPT_PAR_BILLING_FNCC
        ElseIf Mid(UCase(Trim(gCompName)), 1, 4) = "CATH" Then
            R = New CRPT_PAR_BILLING_CATH
        Else
            R = New CRPT_PAR_BILLING_CIAL
        End If

        If Trim(Txt_BookingNo.Text) <> "" Then

            sqlstring = "SELECT * FROM RPT_PARTY_RECEIPT Where BOOKNO='" & Txt_BookingNo.Text & "'"
            GConnection.getDataSet(sqlstring, "RPT_PARTY_RECEIPT")

            ''SQL1 = "SELECT * FROM RPT_PARTY_POSDETAILS Where BOOKINGNO=" & Txt_BookingNo.Text & ""
            ''GConnection.getDataSet(SQL1, "RPT_PARTY_POSDETAILS")

            If Mid(UCase(Trim(gCompName)), 1, 3) = "ALU" Then

                SQL1 = "SELECT type, isnull(sum(amount),0) as amount, bookingno FROM RPT_PARTY_POSDETAILS Where BOOKINGNO=" & Txt_BookingNo.Text & "  group by bookingno,type"
                GConnection.getDataSet(SQL1, "RPT_PARTY_POSDETAILS")

                SQL9 = "SELECT SUM(AMOUNT) AS HALLAMOUNT FROM RPT_PARTY_POSDETAILS_GST where type='Hall Name' AND BOOKINGNO=" & Txt_BookingNo.Text & ""
                GConnection.getDataSet(SQL9, "HALLCHARGE")
                If gdataset.Tables("HALLCHARGE").Rows.Count > 0 Then
                    HALLAMOUNT = gdataset.Tables("HALLCHARGE").Rows(0).Item("HALLAMOUNT")
                End If
                SSQL12 = "SELECT TOP 1 ISNULL(HALLDESC,'') AS HALLDESC FROM PARTY_HALLBOOKING_DET WHERE BOOKINGNO=" & Txt_BookingNo.Text & " "
                GConnection.getDataSet(SSQL12, "PRTY")
                If gdataset.Tables("PRTY").Rows.Count > 0 Then
                    HALLDESC = gdataset.Tables("PRTY").Rows(0).Item("HALLDESC")

                End If
                SQL10 = "SELECT SUM(AMOUNT) AS AMOUNT, SUM(TAXAMOUNT) AS SGST,SUM (TAXAMT) AS CGST,SUM(DISCOUNT) AS DISCOUNT,SUM(RECAMOUNT) RECEIPT,"
                SQL10 = SQL10 & "SUM ((AMOUNT+TAXAMOUNT+TAXAMT)-DISCOUNT) AS NETAMOUNT, SUM(((AMOUNT+TAXAMOUNT+TAXAMT)-DISCOUNT)-RECAMOUNT) AS BAL FROM RPT_PARTY_POSDETAILS_GST "
                SQL10 = SQL10 & "WHERE BOOKINGNO = " & Txt_BookingNo.Text & ""
                GConnection.getDataSet(SQL10, "TOTALAMOUNT")
                If gdataset.Tables("TOTALAMOUNT").Rows.Count > 0 Then
                    AMOUNT = gdataset.Tables("TOTALAMOUNT").Rows(0).Item("AMOUNT")
                    SGST = gdataset.Tables("TOTALAMOUNT").Rows(0).Item("SGST")
                    CGST = gdataset.Tables("TOTALAMOUNT").Rows(0).Item("CGST")
                    DISCOUNT = gdataset.Tables("TOTALAMOUNT").Rows(0).Item("DISCOUNT")
                    RECEIPT = gdataset.Tables("TOTALAMOUNT").Rows(0).Item("RECEIPT")
                    NETAMOUNT = gdataset.Tables("TOTALAMOUNT").Rows(0).Item("NETAMOUNT")
                    BAL = gdataset.Tables("TOTALAMOUNT").Rows(0).Item("BAL")
                    'HALLAMOUNT = gdataset.Tables("TOTALAMOUNT").Rows(0).Item("HALLAMOUNT")
                End If
            Else

                SQL1 = "SELECT * FROM RPT_PARTY_POSDETAILS Where BOOKINGNO=" & Txt_BookingNo.Text & " "
                GConnection.getDataSet(SQL1, "RPT_PARTY_POSDETAILS")
            End If

            SSQL5 = "SELECT * FROM RPT_PARTY_HALLDET Where BOOKINGNO=" & Txt_BookingNo.Text & ""
            GConnection.getDataSet(SSQL5, "RPT_PARTY_HALLDET")

            SSQL6 = "SELECT bookingno AS MCODE,TAXDESC AS ASSOCIATENAME ,HALLTAXPERC AS TAX, SUM(TAXAMOUNT) AS AMOUNT FROM TAX_DETAILS_BOOKING Where bookingno=" & Txt_BookingNo.Text & " GROUP BY bookingno,TAXDESC ,HALLTAXPERC "
            GConnection.getDataSet(SSQL6, "PARTY_PENDINGBILL")

        End If

        If Mid(UCase(Trim(gCompName)), 1, 4) = "FNCC" Or Mid(UCase(Trim(gCompName)), 1, 3) = "FMC" Or Mid(UCase(Trim(gCompName)), 1, 3) = "HSR" Or Mid(UCase(Trim(gCompName)), 1, 4) = "CATH" Or Mid(UCase(Trim(gCompName)), 1, 3) = "ALU" Then
            MGSTINNO = GConnection.getvalue("SELECT isnull(GGSTINNO,'') as GGSTINNO FROM PARTY_HALLBOOKING_HDR where BOOKINGNO = '" & Txt_BookingNo.Text & "'")
            If MGSTINNO = Nothing Then
                MGSTINNO = GConnection.getvalue("SELECT isnull(GSTINNO,'') as GSTINNO FROM MEMBERMASTER where MCODE = '" & Txt_MemberCode.Text & "'")
                If MGSTINNO = Nothing Then
                    MGSTINNO = ""
                End If
            End If
        End If
        Viewer.Report = R
        Call Viewer.GetDetails1(sqlstring, "RPT_PARTY_RECEIPT", R)
        Call Viewer.GetDetails1(SQL1, "RPT_PARTY_POSDETAILS", R)
        Call Viewer.GetDetails1(SSQL5, "RPT_PARTY_HALLDET", R)
        Call Viewer.GetDetails1(SSQL6, "PARTY_PENDINGBILL", R)

        ''sqlstring = "SELECT ISNULL(BILLNO,'') FROM PARTY_hDR WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "' AND BOOKINGTYPE = 'BILLING'"
        ''GConnection.getDataSet(sqlstring, "Bno")
        ''If gdataset.Tables("Bno").Rows.Count > 0 Then
        ''    BillNo = gdataset.Tables("Bno").Rows(0).Item(0)
        ''End If
        If Mid(UCase(Trim(gCompName)), 1, 3) = "ALU" Then
            sqlstring = "SELECT ISNULL(BILLNO,''),BILLDATE FROM PARTY_hDR WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "' AND BOOKINGTYPE = 'BILLING'"
            GConnection.getDataSet(sqlstring, "Bno")
            If gdataset.Tables("Bno").Rows.Count > 0 Then
                BillNo = gdataset.Tables("Bno").Rows(0).Item(0)
                BILLDATE = gdataset.Tables("Bno").Rows(0).Item("BILLDATE")
            End If
        Else
            sqlstring = "SELECT ISNULL(BILLNO,'') FROM PARTY_hDR WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "' AND BOOKINGTYPE = 'BILLING'"
            GConnection.getDataSet(sqlstring, "Bno")
            If gdataset.Tables("Bno").Rows.Count > 0 Then
                BillNo = gdataset.Tables("Bno").Rows(0).Item(0)
            End If
        End If


        sqlstring = "SELECT CAST(CONVERT(VARCHAR,PartyTodate,106) AS DATETIME) AS TODATE,CAST(CONVERT(VARCHAR,Partydate,106) AS DATETIME) AS PARTYDATE FROM party_hallbooking_det WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "'"
        GConnection.getDataSet(sqlstring, "Bno")
        If gdataset.Tables("Bno").Rows.Count > 0 Then
            PTodate = Format(gdataset.Tables("Bno").Rows(0).Item("TODATE"), "dd.MM.yyyy")
            Pdate = Format(gdataset.Tables("Bno").Rows(0).Item("PARTYDATE"), "dd.MM.yyyy")
            If PTodate = Pdate Then
                PTodate = "01-JAN-1900"
            End If
        End If
        If PTodate = "01-JAN-1900" Then
            TDATE = ""
        Else
            TDATE = Format(PTodate, "dd.MM.yyyy")
        End If

        Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ2 = R.ReportDefinition.ReportObjects("Text31")
        TXTOBJ2.Text = BillNo

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = R.ReportDefinition.ReportObjects("Text23")
        TXTOBJ1.Text = "UserName : " & gUsername

        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = R.ReportDefinition.ReportObjects("Text24")
        TXTOBJ3.Text = TDATE

        If Mid(UCase(Trim(gCompName)), 1, 3) = "ALU" Then
            'Dim TXTOBJ34 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ34 = R.ReportDefinition.ReportObjects("Text28")
            'TXTOBJ34.Text = HALLDESC
            Dim TXTOBJ35 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ35 = R.ReportDefinition.ReportObjects("Text33")
            TXTOBJ35.Text = BILLDATE
            Dim TXTOBJ36 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ36 = R.ReportDefinition.ReportObjects("Text36")
            TXTOBJ36.Text = TINNO
            Dim TXTOBJ37 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ37 = R.ReportDefinition.ReportObjects("Text38")
            TXTOBJ37.Text = CSTNO
            Dim TXTOBJ38 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ38 = R.ReportDefinition.ReportObjects("Text28")
            TXTOBJ38.Text = "GSTIN NO : " & GSTIN
            Dim TXTOBJ39 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ39 = R.ReportDefinition.ReportObjects("Text41")
            TXTOBJ39.Text = HALLAMOUNT
            Dim TXTOBJ40 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ40 = R.ReportDefinition.ReportObjects("Text42")
            TXTOBJ40.Text = SGST
            Dim TXTOBJ41 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ41 = R.ReportDefinition.ReportObjects("Text43")
            TXTOBJ41.Text = CGST
            Dim TXTOBJ42 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ42 = R.ReportDefinition.ReportObjects("Text44")
            TXTOBJ42.Text = DISCOUNT
            Dim TXTOBJ43 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ43 = R.ReportDefinition.ReportObjects("Text47")
            TXTOBJ43.Text = RECEIPT
            Dim TXTOBJ44 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ44 = R.ReportDefinition.ReportObjects("Text45")
            TXTOBJ44.Text = NETAMOUNT
            Dim TXTOBJ45 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ45 = R.ReportDefinition.ReportObjects("Text49")
            TXTOBJ45.Text = BAL
            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = R.ReportDefinition.ReportObjects("Text10")
            TXTOBJ5.Text = MyCompanyName

            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = R.ReportDefinition.ReportObjects("Text2")
            TXTOBJ6.Text = Address1 & "," & Address2 & "," & gCity & "," & gState & "-" & gPincode
            Dim TXTOBJ7 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ7 = R.ReportDefinition.ReportObjects("Text12")
            TXTOBJ7.Text = "Phone:" & PHONE1 & "," & PHONE2
        Else
            Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ4 = R.ReportDefinition.ReportObjects("Text11")
            If TDATE = "" Then
                TXTOBJ4.Text = ""
            Else
                TXTOBJ4.Text = "To"
            End If
            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = R.ReportDefinition.ReportObjects("Text10")
            TXTOBJ5.Text = MyCompanyName
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = R.ReportDefinition.ReportObjects("Text2")
            TXTOBJ6.Text = Address1 & "," & Address2
            Dim TXTOBJ7 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ7 = R.ReportDefinition.ReportObjects("Text12")
            TXTOBJ7.Text = gCity & "," & gState & "-" & gPincode
        End If

        ''Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''TXTOBJ4 = R.ReportDefinition.ReportObjects("Text11")
        ''If TDATE = "" Then
        ''    TXTOBJ4.Text = ""
        ''Else
        ''    TXTOBJ4.Text = "To"
        ''End If

        ''Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''TXTOBJ5 = R.ReportDefinition.ReportObjects("Text10")
        ''TXTOBJ5.Text = MyCompanyName

        ''Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''TXTOBJ6 = R.ReportDefinition.ReportObjects("Text2")
        ''TXTOBJ6.Text = Address1 & " " & Address2

        ''Dim TXTOBJ7 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''TXTOBJ7 = R.ReportDefinition.ReportObjects("Text12")
        ''TXTOBJ7.Text = gCity & "," & gState & "-" & gPincode

        sqlstring = "SELECT ISNULL(Menu_Type,'') as Menu_Type FROM Party_Hallbooking_Hdr where BOOKINGNO = '" & Val(Txt_BookingNo.Text) & "' "
        GConnection.getDataSet(sqlstring, "PartyHallbookingHdr")
        If gdataset.Tables("PartyHallbookingHdr").Rows.Count > 0 Then
            NonStandApp = Trim(gdataset.Tables("PartyHallbookingHdr").Rows(0).Item(0))
        Else
            NonStandApp = ""
        End If
        If NonStandApp = "Non Standard" Then
            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = R.ReportDefinition.ReportObjects("Text1")
            TXTOBJ8.Text = "This is Non Standard Billing"
        End If
        If Mid(UCase(Trim(gCompName)), 1, 3) = "BRC" Or Mid(UCase(Trim(gCompName)), 1, 3) = "MGC" Then
            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = R.ReportDefinition.ReportObjects("Text33")
            TXTOBJ9.Text = Occupancy
        End If
        If Mid(UCase(Trim(gCompName)), 1, 2) = "HC" Then
            Dim TXTOBJ10 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ10 = R.ReportDefinition.ReportObjects("Text22")
            TXTOBJ10.Text = "GSTIN : " & GSTIN
        End If

        If Mid(UCase(Trim(gCompName)), 1, 4) = "FNCC" Then
            Dim TXTOBJ10 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ10 = R.ReportDefinition.ReportObjects("Text28")
            TXTOBJ10.Text = "GSTIN : " & GSTIN

            Dim TXTOBJ101 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ101 = R.ReportDefinition.ReportObjects("Text29")
            TXTOBJ101.Text = MGSTINNO
        End If

        R.DataDefinition.FormulaFields("UnboundNumber1").Text = OvrallDiscount

        Viewer.Show()

        Dim AFILE As File
        Filepath = AppPath & "\Reports\" & Txt_BookingNo.Text & "-ANX.PDF"
        If AFILE.Exists(Filepath) Then
            AFILE.Delete(Filepath)
        End If
        Dim CREXPORTOPTIONS As ExportOptions
        Dim CRDISKFILEDESTINATIONOPTIONS As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        CRDISKFILEDESTINATIONOPTIONS.DiskFileName = Filepath
        CREXPORTOPTIONS = R.ExportOptions
        With CREXPORTOPTIONS
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CRDISKFILEDESTINATIONOPTIONS
            .FormatOptions = CrFormatTypeOptions
        End With
        R.Export()
        R.Dispose()
        Viewer.Close()
        Viewer.Dispose()

        If Mid(UCase(Trim(gCompName)), 1, 2) = "HC" Or Mid(UCase(Trim(gCompName)), 1, 3) = "BRC" Then
        Else
            Call BillPrint_GST()
            sqlstring = "SELECT * FROM PARTY_HDR WHERE BOOKINGNO = '" & Val(Txt_BookingNo.Text) & "'  AND ISNULL(NBillNo,'') <> '' AND BOOKINGTYPE='BILLING' "
            GConnection.getDataSet(sqlstring, "NBillCheck")
            If gdataset.Tables("NBillCheck").Rows.Count > 0 Then
                Call BillPrint_NGST()
            End If
        End If

        Filepath = AppPath & "\Reports\" & Txt_BookingNo.Text & "-ANX.PDF"
        If AFILE.Exists(Filepath) Then
            System.Diagnostics.Process.Start(Filepath)
        End If
        Filepath = AppPath & "\Reports\" & Txt_BookingNo.Text & "-GST.PDF"
        If AFILE.Exists(Filepath) Then
            System.Diagnostics.Process.Start(Filepath)
        End If
        Filepath = AppPath & "\Reports\" & Txt_BookingNo.Text & "-NGST.PDF"
        If AFILE.Exists(Filepath) Then
            System.Diagnostics.Process.Start(Filepath)
        End If

        ''Call BillPrint()
    End Sub
    Private Sub BillPrint()
        Dim servercode() As String
        Dim i As Integer
        Dim BOOLCHK As Boolean
        BOOLCHK = False
        Dim sqlstring, SSQL, SSQL1, SSQL2, SSQL3, SSQ, SQL1, SSQL4, SSQL5, SSQL6, BillNo, TDATE, Occupancy, GSTIN As String
        Dim PTodate, Pdate As Date
        Dim Viewer As New ReportViwer
        Dim POSdesc(), MemberCode() As String
        Dim sqlstring1, NonStandApp As String
        Dim SQLSTRING2 As String
        Dim OvrallDiscount As Double

        GSTIN = GConnection.getvalue("SELECT ISNULL(GSTINNO,'') AS GSTINNO  FROM master..CLUBMASTER WHERE DATAfile in(select db_name())")

        SQL1 = "SELECT isnull(OvrallDiscount,0) as OvrallDiscount,* FROM party_hdr WHERE BOOKINGNO = " & Txt_BookingNo.Text & " AND ISNULL(BOOKINGTYPE,'') = 'BILLING'"
        GConnection.getDataSet(SQL1, "RPT1")
        If gdataset.Tables("RPT1").Rows.Count = 0 Then
            MessageBox.Show("Bill Not Done Plz Check", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        Else
            Occupancy = gdataset.Tables("RPT1").Rows(0).Item("OCCUPANCY")
            OvrallDiscount = gdataset.Tables("RPT1").Rows(0).Item("OvrallDiscount")
        End If

        Dim R

        If Mid(UCase(Trim(gCompName)), 1, 3) = "GNC" Then
            R = New CRPT_PAR_BILLORG_GNC
        Else
            R = New CRPT_PAR_BILLING
        End If


        If Trim(Txt_BookingNo.Text) <> "" Then

            sqlstring = "SELECT * FROM RPT_PARTY_RECEIPT Where BOOKNO='" & Txt_BookingNo.Text & "'"
            GConnection.getDataSet(sqlstring, "RPT_PARTY_RECEIPT")

            SQL1 = "SELECT * FROM RPT_PARTY_POSDETAILS Where BOOKINGNO=" & Txt_BookingNo.Text & ""
            GConnection.getDataSet(SQL1, "RPT_PARTY_POSDETAILS")

            SSQL5 = "SELECT * FROM RPT_PARTY_HALLDET Where BOOKINGNO=" & Txt_BookingNo.Text & ""
            GConnection.getDataSet(SSQL5, "RPT_PARTY_HALLDET")

            SSQL6 = "SELECT bookingno AS MCODE,TAXDESC AS ASSOCIATENAME ,HALLTAXPERC AS TAX, SUM(TAXAMOUNT) AS AMOUNT FROM TAX_DETAILS_BOOKING Where bookingno=" & Txt_BookingNo.Text & " GROUP BY bookingno,TAXDESC ,HALLTAXPERC "
            GConnection.getDataSet(SSQL6, "PARTY_PENDINGBILL")

        End If

        Viewer.Report = R
        Call Viewer.GetDetails1(sqlstring, "RPT_PARTY_RECEIPT", R)
        Call Viewer.GetDetails1(SQL1, "RPT_PARTY_POSDETAILS", R)
        Call Viewer.GetDetails1(SSQL5, "RPT_PARTY_HALLDET", R)
        Call Viewer.GetDetails1(SSQL6, "PARTY_PENDINGBILL", R)

        sqlstring = "SELECT ISNULL(BILLNO,'') FROM PARTY_hDR WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "' AND BOOKINGTYPE = 'BILLING'"
        GConnection.getDataSet(sqlstring, "Bno")
        If gdataset.Tables("Bno").Rows.Count > 0 Then
            BillNo = gdataset.Tables("Bno").Rows(0).Item(0)
        End If

        sqlstring = "SELECT CAST(CONVERT(VARCHAR,PartyTodate,106) AS DATETIME) AS TODATE,CAST(CONVERT(VARCHAR,Partydate,106) AS DATETIME) AS PARTYDATE FROM party_hallbooking_det WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "'"
        GConnection.getDataSet(sqlstring, "Bno")
        If gdataset.Tables("Bno").Rows.Count > 0 Then
            PTodate = Format(gdataset.Tables("Bno").Rows(0).Item("TODATE"), "dd.MM.yyyy")
            Pdate = Format(gdataset.Tables("Bno").Rows(0).Item("PARTYDATE"), "dd.MM.yyyy")
            If PTodate = Pdate Then
                PTodate = "01-JAN-1900"
            End If
        End If
        If PTodate = "01-JAN-1900" Then
            TDATE = ""
        Else
            TDATE = Format(PTodate, "dd.MM.yyyy")
        End If

        Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ2 = R.ReportDefinition.ReportObjects("Text31")
        TXTOBJ2.Text = BillNo

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = R.ReportDefinition.ReportObjects("Text23")
        TXTOBJ1.Text = "UserName : " & gUsername

        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = R.ReportDefinition.ReportObjects("Text24")
        TXTOBJ3.Text = TDATE

        Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ4 = R.ReportDefinition.ReportObjects("Text11")
        If TDATE = "" Then
            TXTOBJ4.Text = ""
        Else
            TXTOBJ4.Text = "To"
        End If

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = R.ReportDefinition.ReportObjects("Text10")
        TXTOBJ5.Text = MyCompanyName

        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = R.ReportDefinition.ReportObjects("Text2")
        TXTOBJ6.Text = Address1 & " " & Address2

        Dim TXTOBJ7 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ7 = R.ReportDefinition.ReportObjects("Text12")
        TXTOBJ7.Text = gCity & "," & gState & "-" & gPincode

        sqlstring = "SELECT ISNULL(Menu_Type,'') as Menu_Type FROM Party_Hallbooking_Hdr where BOOKINGNO = '" & Val(Txt_BookingNo.Text) & "' "
        GConnection.getDataSet(sqlstring, "PartyHallbookingHdr")
        If gdataset.Tables("PartyHallbookingHdr").Rows.Count > 0 Then
            NonStandApp = Trim(gdataset.Tables("PartyHallbookingHdr").Rows(0).Item(0))
        Else
            NonStandApp = ""
        End If
        If NonStandApp = "Non Standard" Then
            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = R.ReportDefinition.ReportObjects("Text1")
            TXTOBJ8.Text = "This is Non Standard Billing"
        End If
        ''If Mid(UCase(Trim(gCompName)), 1, 3) = "BRC" Or Mid(UCase(Trim(gCompName)), 1, 3) = "MGC" Then
        ''    Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''    TXTOBJ9 = R.ReportDefinition.ReportObjects("Text33")
        ''    TXTOBJ9.Text = Occupancy
        ''End If

        Dim TXTOBJ10 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ10 = R.ReportDefinition.ReportObjects("Text34")
        TXTOBJ10.Text = GSTIN

        R.DataDefinition.FormulaFields("UnboundNumber1").Text = OvrallDiscount

        Viewer.Show()
    End Sub

    Private Sub BillPrint_GST()
        Dim servercode() As String
        Dim i As Integer
        Dim BOOLCHK As Boolean
        BOOLCHK = False
        Dim sqlstring, SSQL, SSQL1, SSQL2, SSQL3, SSQ, SQL1, SSQL4, SSQL5, SSQL6, BillNo, TDATE, Occupancy, GSTIN, MGSTINNO As String
        Dim PTodate, Pdate As Date
        Dim Viewer As New ReportViwer
        Dim POSdesc(), MemberCode() As String
        Dim sqlstring1, NonStandApp As String
        Dim SQLSTRING2 As String
        Dim OvrallDiscount As Double

        GSTIN = GConnection.getvalue("SELECT ISNULL(GSTINNO,'') AS GSTINNO  FROM master..CLUBMASTER WHERE DATAfile in(select db_name())")

        SQL1 = "SELECT isnull(OvrallDiscount,0) as OvrallDiscount,* FROM party_hdr WHERE BOOKINGNO = " & Txt_BookingNo.Text & " AND ISNULL(BOOKINGTYPE,'') = 'BILLING'"
        GConnection.getDataSet(SQL1, "RPT1")
        If gdataset.Tables("RPT1").Rows.Count = 0 Then
            MessageBox.Show("Bill Not Done Plz Check", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        Else
            Occupancy = gdataset.Tables("RPT1").Rows(0).Item("OCCUPANCY")
            OvrallDiscount = 0
        End If

        Dim R1

        If Mid(UCase(Trim(gCompName)), 1, 3) = "GNC" Then
            R1 = New CRPT_PAR_GSTBILL_GNC
        Else
            R1 = New CRPT_PAR_GSTBILL
        End If

        If Trim(Txt_BookingNo.Text) <> "" Then

            sqlstring = "SELECT * FROM RPT_PARTY_RECEIPT Where BOOKNO='" & Txt_BookingNo.Text & "'"
            GConnection.getDataSet(sqlstring, "RPT_PARTY_RECEIPT")

            SQL1 = "SELECT * FROM RPT_PARTY_POSDETAILS_GN Where BOOKINGNO=" & Txt_BookingNo.Text & " AND ISNULL(GSTFLAG,'') = 'YES' "
            GConnection.getDataSet(SQL1, "RPT_PARTY_POSDETAILS")

            SSQL5 = "SELECT * FROM RPT_PARTY_HALLDET_GN Where BOOKINGNO=" & Txt_BookingNo.Text & " AND ISNULL(GSTFLAG,'') = 'YES'"
            GConnection.getDataSet(SSQL5, "RPT_PARTY_HALLDET")

            SSQL6 = "SELECT bookingno AS MCODE,TAXDESC AS ASSOCIATENAME ,HALLTAXPERC AS TAX, SUM(TAXAMOUNT) AS AMOUNT FROM TAX_DETAILS_BOOKING Where bookingno=" & Txt_BookingNo.Text & " AND HALLTAXCODE IN (SELECT TAXCODE FROM accountstaxmaster WHERE typeoftax IN ('CGST','SGST','CGST CESS','SGST CESS')) GROUP BY bookingno,TAXDESC ,HALLTAXPERC "
            GConnection.getDataSet(SSQL6, "PARTY_PENDINGBILL")

        End If

        If Mid(UCase(Trim(gCompName)), 1, 4) = "FNCC" Or Mid(UCase(Trim(gCompName)), 1, 3) = "FMC" Or Mid(UCase(Trim(gCompName)), 1, 3) = "HSR" Or Mid(UCase(Trim(gCompName)), 1, 4) = "CATH" Or Mid(UCase(Trim(gCompName)), 1, 3) = "ALU" Then
            MGSTINNO = GConnection.getvalue("SELECT isnull(GGSTINNO,'') as GGSTINNO FROM PARTY_HALLBOOKING_HDR where BOOKINGNO = '" & Txt_BookingNo.Text & "'")
            If MGSTINNO = Nothing Then
                MGSTINNO = GConnection.getvalue("SELECT isnull(GSTINNO,'') as GSTINNO FROM MEMBERMASTER where MCODE = '" & Txt_MemberCode.Text & "'")
                If MGSTINNO = Nothing Then
                    MGSTINNO = ""
                End If
            End If
        End If
        If MGSTINNO = Nothing Then
            MGSTINNO = ""
        End If

        Viewer.Report = R1
        Call Viewer.GetDetails1(sqlstring, "RPT_PARTY_RECEIPT", R1)
        Call Viewer.GetDetails1(SQL1, "RPT_PARTY_POSDETAILS", R1)
        Call Viewer.GetDetails1(SSQL5, "RPT_PARTY_HALLDET", R1)
        Call Viewer.GetDetails1(SSQL6, "PARTY_PENDINGBILL", R1)

        sqlstring = "SELECT ISNULL(BILLNO,'') FROM PARTY_hDR WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "' AND BOOKINGTYPE = 'BILLING'"
        GConnection.getDataSet(sqlstring, "Bno")
        If gdataset.Tables("Bno").Rows.Count > 0 Then
            BillNo = gdataset.Tables("Bno").Rows(0).Item(0)
        End If

        sqlstring = "SELECT CAST(CONVERT(VARCHAR,PartyTodate,106) AS DATETIME) AS TODATE,CAST(CONVERT(VARCHAR,Partydate,106) AS DATETIME) AS PARTYDATE FROM party_hallbooking_det WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "'"
        GConnection.getDataSet(sqlstring, "Bno")
        If gdataset.Tables("Bno").Rows.Count > 0 Then
            PTodate = Format(gdataset.Tables("Bno").Rows(0).Item("TODATE"), "dd.MM.yyyy")
            Pdate = Format(gdataset.Tables("Bno").Rows(0).Item("PARTYDATE"), "dd.MM.yyyy")
            If PTodate = Pdate Then
                PTodate = "01-JAN-1900"
            End If
        End If
        If PTodate = "01-JAN-1900" Then
            TDATE = ""
        Else
            TDATE = Format(PTodate, "dd.MM.yyyy")
        End If

        Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ2 = R1.ReportDefinition.ReportObjects("Text31")
        TXTOBJ2.Text = BillNo

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = R1.ReportDefinition.ReportObjects("Text23")
        TXTOBJ1.Text = "UserName : " & gUsername

        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = R1.ReportDefinition.ReportObjects("Text24")
        TXTOBJ3.Text = TDATE

        Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ4 = R1.ReportDefinition.ReportObjects("Text11")
        If TDATE = "" Then
            TXTOBJ4.Text = ""
        Else
            TXTOBJ4.Text = "To"
        End If

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = R1.ReportDefinition.ReportObjects("Text10")
        TXTOBJ5.Text = MyCompanyName

        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = R1.ReportDefinition.ReportObjects("Text2")
        TXTOBJ6.Text = Address1 & " " & Address2

        Dim TXTOBJ7 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ7 = R1.ReportDefinition.ReportObjects("Text12")
        TXTOBJ7.Text = gCity & "," & gState & "-" & gPincode

        sqlstring = "SELECT ISNULL(Menu_Type,'') as Menu_Type FROM Party_Hallbooking_Hdr where BOOKINGNO = '" & Val(Txt_BookingNo.Text) & "' "
        GConnection.getDataSet(sqlstring, "PartyHallbookingHdr")
        If gdataset.Tables("PartyHallbookingHdr").Rows.Count > 0 Then
            NonStandApp = Trim(gdataset.Tables("PartyHallbookingHdr").Rows(0).Item(0))
        Else
            NonStandApp = ""
        End If
        If NonStandApp = "Non Standard" Then
            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = R1.ReportDefinition.ReportObjects("Text1")
            TXTOBJ8.Text = "This is Non Standard Billing"
        End If
        ''If Mid(UCase(Trim(gCompName)), 1, 3) = "BRC" Or Mid(UCase(Trim(gCompName)), 1, 3) = "MGC" Then
        ''    Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''    TXTOBJ9 = R.ReportDefinition.ReportObjects("Text33")
        ''    TXTOBJ9.Text = Occupancy
        ''End If

        Dim TXTOBJ10 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ10 = R1.ReportDefinition.ReportObjects("Text34")
        TXTOBJ10.Text = GSTIN

        Dim TXTOBJ11 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ11 = R1.ReportDefinition.ReportObjects("Text35")
        TXTOBJ11.Text = MGSTINNO


        R1.DataDefinition.FormulaFields("UnboundNumber1").Text = OvrallDiscount

        Viewer.Show()

        Dim AFILE As File
        Filepath = AppPath & "\Reports\" & Txt_BookingNo.Text & "-GST.PDF"
        If AFILE.Exists(Filepath) Then
            AFILE.Delete(Filepath)
        End If
        Dim CREXPORTOPTIONS As ExportOptions
        Dim CRDISKFILEDESTINATIONOPTIONS As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        CRDISKFILEDESTINATIONOPTIONS.DiskFileName = Filepath
        CREXPORTOPTIONS = R1.ExportOptions
        With CREXPORTOPTIONS
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CRDISKFILEDESTINATIONOPTIONS
            .FormatOptions = CrFormatTypeOptions
        End With
        R1.Export()
        R1.Dispose()
        Viewer.Close()
        Viewer.Dispose()

    End Sub

    Private Sub BillPrint_NGST()
        Dim servercode() As String
        Dim i As Integer
        Dim BOOLCHK As Boolean
        BOOLCHK = False
        Dim sqlstring, SSQL, SSQL1, SSQL2, SSQL3, SSQ, SQL1, SSQL4, SSQL5, SSQL6, BillNo, TDATE, Occupancy, GSTIN As String
        Dim PTodate, Pdate As Date
        Dim Viewer As New ReportViwer
        Dim POSdesc(), MemberCode() As String
        Dim sqlstring1, NonStandApp As String
        Dim SQLSTRING2 As String
        Dim OvrallDiscount As Double

        GSTIN = GConnection.getvalue("SELECT ISNULL(GSTINNO,'') AS GSTINNO  FROM master..CLUBMASTER WHERE DATAfile in(select db_name())")

        SQL1 = "SELECT isnull(OvrallDiscount,0) as OvrallDiscount,* FROM party_hdr WHERE BOOKINGNO = " & Txt_BookingNo.Text & " AND ISNULL(BOOKINGTYPE,'') = 'BILLING'"
        GConnection.getDataSet(SQL1, "RPT1")
        If gdataset.Tables("RPT1").Rows.Count = 0 Then
            MessageBox.Show("Bill Not Done Plz Check", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        Else
            Occupancy = gdataset.Tables("RPT1").Rows(0).Item("OCCUPANCY")
            OvrallDiscount = 0
        End If

        Dim R2

        R2 = New CRPT_PAR_NGSTBILL

        If Trim(Txt_BookingNo.Text) <> "" Then

            sqlstring = "SELECT * FROM RPT_PARTY_RECEIPT Where BOOKNO='" & Txt_BookingNo.Text & "'"
            GConnection.getDataSet(sqlstring, "RPT_PARTY_RECEIPT")

            SQL1 = "SELECT * FROM RPT_PARTY_POSDETAILS_GN Where BOOKINGNO=" & Txt_BookingNo.Text & " AND ISNULL(GSTFLAG,'') = 'NO' "
            GConnection.getDataSet(SQL1, "RPT_PARTY_POSDETAILS")

            SSQL5 = "SELECT * FROM RPT_PARTY_HALLDET_GN Where BOOKINGNO=" & Txt_BookingNo.Text & " AND ISNULL(GSTFLAG,'') = 'NO'"
            GConnection.getDataSet(SSQL5, "RPT_PARTY_HALLDET")

            SSQL6 = "SELECT bookingno AS MCODE,TAXDESC AS ASSOCIATENAME ,HALLTAXPERC AS TAX, SUM(TAXAMOUNT) AS AMOUNT FROM TAX_DETAILS_BOOKING Where bookingno=" & Txt_BookingNo.Text & " AND HALLTAXCODE NOT IN (SELECT TAXCODE FROM accountstaxmaster WHERE typeoftax IN ('CGST','SGST','CGST CESS','SGST CESS')) GROUP BY bookingno,TAXDESC ,HALLTAXPERC "
            GConnection.getDataSet(SSQL6, "PARTY_PENDINGBILL")

        End If

        Viewer.Report = R2
        Call Viewer.GetDetails1(sqlstring, "RPT_PARTY_RECEIPT", R2)
        Call Viewer.GetDetails1(SQL1, "RPT_PARTY_POSDETAILS", R2)
        Call Viewer.GetDetails1(SSQL5, "RPT_PARTY_HALLDET", R2)
        Call Viewer.GetDetails1(SSQL6, "PARTY_PENDINGBILL", R2)

        sqlstring = "SELECT ISNULL(NBILLNO,'') FROM PARTY_hDR WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "' AND BOOKINGTYPE = 'BILLING'"
        GConnection.getDataSet(sqlstring, "Bno")
        If gdataset.Tables("Bno").Rows.Count > 0 Then
            BillNo = gdataset.Tables("Bno").Rows(0).Item(0)
        End If

        sqlstring = "SELECT CAST(CONVERT(VARCHAR,PartyTodate,106) AS DATETIME) AS TODATE,CAST(CONVERT(VARCHAR,Partydate,106) AS DATETIME) AS PARTYDATE FROM party_hallbooking_det WHERE BOOKINGNO = '" & Txt_BookingNo.Text & "'"
        GConnection.getDataSet(sqlstring, "Bno")
        If gdataset.Tables("Bno").Rows.Count > 0 Then
            PTodate = Format(gdataset.Tables("Bno").Rows(0).Item("TODATE"), "dd.MM.yyyy")
            Pdate = Format(gdataset.Tables("Bno").Rows(0).Item("PARTYDATE"), "dd.MM.yyyy")
            If PTodate = Pdate Then
                PTodate = "01-JAN-1900"
            End If
        End If
        If PTodate = "01-JAN-1900" Then
            TDATE = ""
        Else
            TDATE = Format(PTodate, "dd.MM.yyyy")
        End If

        Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ2 = R2.ReportDefinition.ReportObjects("Text31")
        TXTOBJ2.Text = BillNo

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = R2.ReportDefinition.ReportObjects("Text23")
        TXTOBJ1.Text = "UserName : " & gUsername

        Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ3 = R2.ReportDefinition.ReportObjects("Text24")
        TXTOBJ3.Text = TDATE

        Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ4 = R2.ReportDefinition.ReportObjects("Text11")
        If TDATE = "" Then
            TXTOBJ4.Text = ""
        Else
            TXTOBJ4.Text = "To"
        End If

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = R2.ReportDefinition.ReportObjects("Text10")
        TXTOBJ5.Text = MyCompanyName

        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = R2.ReportDefinition.ReportObjects("Text2")
        TXTOBJ6.Text = Address1 & " " & Address2

        Dim TXTOBJ7 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ7 = R2.ReportDefinition.ReportObjects("Text12")
        TXTOBJ7.Text = gCity & "," & gState & "-" & gPincode

        sqlstring = "SELECT ISNULL(Menu_Type,'') as Menu_Type FROM Party_Hallbooking_Hdr where BOOKINGNO = '" & Val(Txt_BookingNo.Text) & "' "
        GConnection.getDataSet(sqlstring, "PartyHallbookingHdr")
        If gdataset.Tables("PartyHallbookingHdr").Rows.Count > 0 Then
            NonStandApp = Trim(gdataset.Tables("PartyHallbookingHdr").Rows(0).Item(0))
        Else
            NonStandApp = ""
        End If
        If NonStandApp = "Non Standard" Then
            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = R2.ReportDefinition.ReportObjects("Text1")
            TXTOBJ8.Text = "This is Non Standard Billing"
        End If
        ''If Mid(UCase(Trim(gCompName)), 1, 3) = "BRC" Or Mid(UCase(Trim(gCompName)), 1, 3) = "MGC" Then
        ''    Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''    TXTOBJ9 = R.ReportDefinition.ReportObjects("Text33")
        ''    TXTOBJ9.Text = Occupancy
        ''End If

        ''Dim TXTOBJ10 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''TXTOBJ10 = R.ReportDefinition.ReportObjects("Text34")
        ''TXTOBJ10.Text = GSTIN

        R2.DataDefinition.FormulaFields("UnboundNumber1").Text = OvrallDiscount

        Viewer.Show()

        Dim AFILE As File
        Filepath = AppPath & "\Reports\" & Txt_BookingNo.Text & "-NGST.PDF"
        If AFILE.Exists(Filepath) Then
            AFILE.Delete(Filepath)
        End If
        Dim CREXPORTOPTIONS As ExportOptions
        Dim CRDISKFILEDESTINATIONOPTIONS As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        CRDISKFILEDESTINATIONOPTIONS.DiskFileName = Filepath
        CREXPORTOPTIONS = R2.ExportOptions
        With CREXPORTOPTIONS
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CRDISKFILEDESTINATIONOPTIONS
            .FormatOptions = CrFormatTypeOptions
        End With
        R2.Export()
        R2.Dispose()
        Viewer.Close()
        Viewer.Dispose()

    End Sub

    Private Sub CMD_BILLINGNO_Click(sender As Object, e As EventArgs) Handles CMD_BILLINGNO.Click
        If CMBBOOKINGTYPE.Text = "BILLING" Then
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(BILLNO,0) AS BILLNO,ISNULL(BOOKINGNO,0) AS BOOKINGNO,ISNULL(partyDATE,'')AS PARTYDATE,BOOKINGDATE AS BOOKINGDATE"
            gSQLString = gSQLString & "  FROM  PARTY_HDR"
            If Trim(Search) = " " Then
                M_WhereCondition = " WHERE LOCCODE='" & Trim(Cmb_Location.Text) & "' AND  BOOKINGTYPE='BILLING'"
            Else
                M_WhereCondition = " WHERE LOCCODE='" & Trim(Cmb_Location.Text) & "' AND  BOOKINGTYPE='BILLING'"
            End If
            vform.Field = "BILLNO,BOOKINGNO,PARTYDATE,BOOKINGDATE"
            'vform.vFormatstring = "BILLNO NO             | BOOKINGNO |   PARTYDATE            |  BOOKING DATE             "
            vform.vCaption = "PARTY BILL HELP"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            'vform.Keypos3 = 3
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_BookingNo.Text = Trim(vform.keyfield1 & "")
                Dtp_BookingDate.Text = Trim(vform.keyfield3 & "")
                'Call Txt_BookingNo_Validated(sender, e)
                Call TXTBILLINGNO_Validated(sender, e)
                Dtp_BookingDate.Focus()
            End If
            vform.Close()
            vform = Nothing
        Else
            MsgBox("Please Select Booking Type=BILLING...")
            CMBBOOKINGTYPE.Focus()
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Me.CMBBOOKINGTYPE.Text = "BILLING" Then
            SSQL = "SELECT * FROM PARTY_HDR WHERE BOOKINGNO = '" & Me.Txt_BookingNo.Text & "' AND BOOKINGTYPE = 'BILLING' AND ISNULL(BILLNO,'') <> '' "
            GConnection.getDataSet(SSQL, "BILLCHECK")
            If gdataset.Tables("BILLCHECK").Rows.Count > 0 Then
            Else
                MessageBox.Show("Bill No Not Generted, Plz Check", MyCompanyName)
                Exit Sub
            End If

            Dim SETT As New SETTLEMENT(Txt_BookingNo.Text, Dtp_PartyDate.Value)
            SETT.MdiParent = Me.MdiParent
            SETT.Show()
            SSQL = " delete from PARTY_ACC_POST  WHERE BOOKINGNO ='" & Me.Txt_BookingNo.Text & "'"
            GConnection.dataOperation(6, SSQL, "delbook")
            SSQL = "SELECT BOOKINGNO ,PARTYDATE ,ACCOUNTCODE +'>'+ACDESC AS ACCODE,TOTALAMOUNT AS DEBIT,CASHAMT  AS CREDIT,BANKAMT ,MEMAMT ,POSTFLAG FROM PARTY_ACC_POST WHERE BOOKINGNO ='" & Me.Txt_BookingNo.Text & "'"
            GConnection.getDataSet(SSQL, "ACCTYPE")
            If gdataset.Tables("ACCTYPE").Rows.Count > 0 Then
                SSQL = "SELECT BOOKINGNO ,PARTYDATE ,ACCOUNTCODE +'>'+ACDESC AS ACCODE,ISNULL(SLCODE,'') AS SLCODE,TOTALAMOUNT AS DEBIT,CASHAMT  AS CREDIT,POSTFLAG FROM PARTY_ACC_POST WHERE BOOKINGNO ='" & Me.Txt_BookingNo.Text & "'"
            Else
                SSQL = "SELECT A.BOOKINGNO,A.PARTYDATE,(ISNULL(A.ACCODE,'') +'>'+ISNULL(B.ACDESC,''))  AS ACCODE,ISNULL(SLCODE,'') AS SLCODE,ISNULL(A.COSTCODE,'') AS COSTCODE,SUM(DRAMOUNT)AS DEBIT,SUM(CRAMOUNT)AS CREDIT ,'N' AS POSTFLAG FROM PARTY_DETSUMMARY A LEFT OUTER JOIN ACCOUNTSGLACCOUNTMASTER B ON A.ACCODE=B.ACCODE  WHERE BOOKINGNO='" & Me.Txt_BookingNo.Text & "' GROUP BY A.BOOKINGNO,A.PARTYDATE,A.ACCODE,B.ACDESC,SLCODE,ISNULL(A.COSTCODE,'')  "
            End If
            Call SETT.GETDATA(SSQL, Txt_BookingNo.Text)
        End If
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Dim Insert(0) As String
        Call checkValidation()
        If boolchk = False Then Exit Sub
        Dim Fre, strsql As String
        Try
           
            ''If Trim(Txt_BookingNo.Text) <> "" Then
            ''    sqlstring = "SELECT * FROM PARTY_ACC_POST  where bookingno=" & Txt_BookingNo.Text & " AND ISNULL(POSTFLAG,'')='Y' "
            ''    GConnection.getDataSet(sqlstring, "accpost")
            ''    If gdataset.Tables("accpost").Rows.Count > 0 Then
            ''        MessageBox.Show("ALREADY ACCOUNT POSTING WAS DONE,YOU CANNOT FREEZE ", MyCompanyName, MessageBoxButtons.OK)
            ''        Exit Sub
            ''    End If
            ''End If
            If Trim(Txt_BookingNo.Text) <> "" Then
                sqlstring = "SELECT * FROM Journalentry  where VoucherNo='" & TXTBILLINGNO.Text & "' AND ISNULL(VOID,'') <> 'Y' "
                GConnection.getDataSet(sqlstring, "accpost")
                If gdataset.Tables("accpost").Rows.Count > 0 Then
                    ''MessageBox.Show("ALREADY ACCOUNT POSTING WAS DONE,YOU CANNOT UPDATE THE BOOKING ", MyCompanyName, MessageBoxButtons.OK)
                    ''Exit Sub
                    If MsgBox("ALREADY ACCOUNT POSTING WAS DONE,ARE YOU CONFIRM TO DELETE ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Else
                        Exit Sub
                    End If
                End If
            End If

            If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
                If MsgBox("Are U Sure To Delete", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    sqlstring = "UPDATE PARTY_HDR SET FREEZE = 'Y' WHERE BILLNO = '" & Trim(TXTBILLINGNO.Text) & "' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "UPDATE Party_Hallbooking_Hdr SET BILLINGFLAG = '' WHERE BOOKINGNO = " & Txt_BookingNo.Text & "  "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM PARTY_RESTAURANT WHERE BOOKINGNO = " & Txt_BookingNo.Text & "  AND BOOKINGTYPE = 'BILLING' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM PARTY_RESTAURANT_DET WHERE BOOKINGNO = " & Txt_BookingNo.Text & " AND BOOKINGTYPE = 'BILLING' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM PARTY_RESTAURANT_TAX WHERE BOOKINGNO = " & Txt_BookingNo.Text & " AND BOOKINGTYPE = 'BILLING' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM PARTY_ARRANGEMENT  WHERE BOOKINGNO = " & Txt_BookingNo.Text & " AND BOOKINGTYPE = 'BILLING' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM party_arrangement_TAX  WHERE BOOKINGNO = " & Txt_BookingNo.Text & " AND BOOKINGTYPE = 'BILLING' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM Party_OtherCharges WHERE BOOKINGNO = " & Txt_BookingNo.Text & " AND BOOKINGTYPE = 'BILLING' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM Party_OtherCharges_Tax WHERE BOOKINGNO = " & Txt_BookingNo.Text & " AND BOOKINGTYPE = 'BILLING' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM PARTY_KOT_DET WHERE KOTDETAILS = '" & Txt_BookingNo.Text & "' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "DELETE FROM PARTY_KOT_DET_TAX WHERE KOTDETAILS = '" & Txt_BookingNo.Text & "' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "UPDATE Journalentry SET VOID = 'Y' WHERE VOUCHERNO = '" & Trim(TXTBILLINGNO.Text) & "' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                    GConnection.MoreTransold(Insert)
                    Me.CmdClear_Click(sender, e)
                    CmdAdd.Text = "Add [F7]"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TXTBILLINGNO_Validated(sender As Object, e As EventArgs) Handles TXTBILLINGNO.Validated
        Dim D1, D2 As Date
        Try
            If Val(Txt_BookingNo.Text) > 0 Then
                sqlstring = "SELECT ISNULL(BOOKINGFLAG,'') AS BOOKINGFLAG,ISNULL(BILLINGFLAG,'') AS BILLINGFLAG,"
                sqlstring = sqlstring & "ISNULL(CANCELFLAG,'') AS CANCELFLAG FROM  PARTY_HALLBOOKING_HDR "
                sqlstring = sqlstring & "WHERE ISNULL(BOOKINGNO, 0) = " & IIf(Txt_BookingNo.Text = "", 0, Txt_BookingNo.Text) & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'  And ISNULL(Freeze,'') <> 'Y' "
                DT = GConnection.GetValues(sqlstring)
            Else
                Txt_BookingNo.Text = ""
                Exit Sub
            End If

            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item("CANCELFLAG") = "Y" Then
                    CANCEL = True
                Else
                    CANCEL = False
                End If
                If DT.Rows(0).Item("BOOKINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                    sqlstring = "SELECT ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,ISNULL(P.PARTYDATE,'') AS PARTYDATE,ISNULL(P.FROMTIME,0) AS FROMTIME,"
                    sqlstring = sqlstring & "ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,ISNULL(P.GUESTNAME,'') AS GUESTNAME,ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE, "
                    sqlstring = sqlstring & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS OCCUPANCY,ISNULL(P.veg,0) AS veg,ISNULL(P.nonveg,0) AS nonveg,ISNULL(h.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME, "
                    sqlstring = sqlstring & "ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG,ISNULL(P.MENUCODE,'')AS MENUCODE FROM PARTY_HDR P LEFT OUTER "
                    sqlstring = sqlstring & " JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE where P.Bookingno='" & Txt_BookingNo.Text & "' AND P.LOCCODE='" & Trim(Cmb_Location.Text) & "' AND P.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'  and ISNULL(h.FREEZE ,'')<>'Y'   "
                    DT = GConnection.GetValues(sqlstring)
                    Me.CmdAdd.Text = "Update[F7]"
                ElseIf DT.Rows(0).Item("BILLINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                    'bookingstatus.Visible = True
                    'bookingstatus.Text = "BILLING OVER"

                    sqlstring = "SELECT  ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,"
                    sqlstring = sqlstring & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                    sqlstring = sqlstring & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                    sqlstring = sqlstring & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,ISNULL(P.GUESTNAME,'') AS GUESTNAME,"
                    sqlstring = sqlstring & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                    sqlstring = sqlstring & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS OCCUPANCY,"
                    sqlstring = sqlstring & "ISNULL(P.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                    sqlstring = sqlstring & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg,"
                    sqlstring = sqlstring & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG,ISNULL(P.BILLNO,'') AS BILLNO,ISNULL(P.OvrallDiscount,0) AS OvrallDiscount FROM PARTY_HDR P"
                    sqlstring = sqlstring & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE"
                    'sqlstring = sqlstring & " where P.Bookingno=" & Trim(Txt_BookingNo.Text) & ""
                    sqlstring = sqlstring & " where P.BILLNO='" & Trim(TXTBILLINGNO.Text) & "'"
                    sqlstring = sqlstring & " AND P.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND H.LOCCODE='" & Trim(Cmb_Location.Text) & "'  "
                    DT = GConnection.GetValues(sqlstring)
                    Me.CmdAdd.Text = "Update[F7]"
                Else
                    If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                        sqlstring = "SELECT H.BOOKINGNO,H.BOOKINGDATE,H.PARTYDATE,H.DESCRIPTION,H.MCODE,H.ASSOCIATENAME,H.OCCUPANCY,H.GUESTNAME,H.NONVEG,H.VEG,H.FREEZE "
                        sqlstring = sqlstring & "FROM party_hallbooking_hdr H ,party_hallbooking_det D WHERE D.BOOKINGNO = H.BOOKINGNO AND H.BOOKINGNO = '" & Txt_BookingNo.Text & "' AND H.LOCCODE='" & Trim(Cmb_Location.Text) & "'  "
                        DT = GConnection.GetValues(sqlstring)
                    ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                        SSQL = "SELECT ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,ISNULL(P.BOOKINGTYPE,'')AS BOOKINGTYPE,"
                        SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                        SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                        SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,isnull(P.GUESTname,'')as GUESTname,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,ISNULL(P.GUESTNAME,'') AS GUESTNAME,"
                        SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                        SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS OCCUPANCY,"
                        SSQL = SSQL & "ISNULL(H.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                        SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,"
                        SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG,ISNULL(P.BILLNO,'') AS BILLNO,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg,ISNULL(P.MENUCODE,0) AS MENUCODE,ISNULL(P.OvrallDiscount,0) AS OvrallDiscount FROM PARTY_HDR P"
                        SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO"
                        SSQL = SSQL & " WHERE P.BOOKINGNO=" & Txt_BookingNo.Text & " AND P.LOCCODE='" & Trim(Cmb_Location.Text) & "'  "
                        SSQL = SSQL & " AND P.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                        DT = GConnection.GetValues(SSQL)
                        Me.CmdAdd.Text = "Update[F7]"
                    End If
                End If
                If DT.Rows.Count > 0 Then
                    Dtp_BookingDate.Value = Format(DT.Rows(0).Item("BOOKINGDATE"), "dd/MM/yyyy HH:mm:ss")
                    Dtp_PartyDate.Value = Format(DT.Rows(0).Item("PARTYDATE"), "dd/MM/yyyy HH:mm:ss")
                    Txt_Purpose.Text = DT.Rows(0).Item("DESCRIPTION")
                    Txt_MemberCode.Text = DT.Rows(0).Item("MCODE")
                    Txt_MemberName.Text = DT.Rows(0).Item("ASSOCIATENAME")
                    Txt_GuestName.Text = DT.Rows(0).Item("GUESTNAME")
                    Txt_TotPax.Text = Val(DT.Rows(0).Item("OCCUPANCY"))
                    Txt_VPax.Text = Val(DT.Rows(0).Item("VEG"))
                    Txt_PaidAmt.Text = Format(GConnection.getvalue("SELECT ISNULL(SUM(AMOUNT),0) AS DEPAMT FROM party_receipt_DET WHERE RECEIPTTYPE IN ('ADVANCE','DEPOSIT','SETTLEMENT') And PARTYRECEIPTNO IN (SELECT PARTYRECEIPTNO FROM party_receipt_HDR WHERE ISNULL(Authorised,'') = 'Y') AND ISNULL(FREEZE,'') <> 'Y' AND BOOKINGNO = '" & Txt_BookingNo.Text & "'"), "0.00")

                    If Val(DT.Rows(0).Item("VEG")) > 0 Then
                        Cmd_VMenuCodeHelp.Enabled = True
                        Txt_VMenuCode.Enabled = True
                    Else
                        Cmd_VMenuCodeHelp.Enabled = False
                        Txt_VMenuCode.Enabled = False
                    End If
                    Txt_NVPax.Text = Val(DT.Rows(0).Item("NONVEG"))
                    If Val(DT.Rows(0).Item("NONVEG")) > 0 Then
                        Cmd_NVMenuCodeHelp.Enabled = True
                        Txt_NVMenuCode.Enabled = True
                    Else
                        Cmd_NVMenuCodeHelp.Enabled = False
                        Txt_NVMenuCode.Enabled = False
                    End If
                    If Mid(CmdAdd.Text, 1, 1) = "A" And CMBBOOKINGTYPE.Text = "BILLING" Then
                    Else
                        TXTBILLINGNO.Text = DT.Rows(0).Item("BILLNO")
                        Txt_Discount.Text = DT.Rows(0).Item("OvrallDiscount")
                    End If

                    If DT.Rows(0).Item("FREEZE") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "THIS BILLING IS FREEZED "
                        Me.Cmd_Freeze.Text = "Freeze [F8]"
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "UnFreeze [F8]"
                    End If
                    Dim DTDet As DataTable
                    sqlstring = "Select * from Party_Hallbooking_Det WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND LOCCODE='" & Trim(Cmb_Location.Text) & "'"
                    DTDet = GConnection.GetValues(sqlstring)
                    If DTDet.Rows.Count > 0 Then
                        sSGrid_HallResv.ClearRange(-1, -1, 1, 1, True)
                        With sSGrid_HallResv
                            For i = 0 To DTDet.Rows.Count - 1
                                .Row = i + 1
                                .Col = 1
                                .Text = DTDet.Rows(i).Item("HALLCODE")
                                .Col = 2
                                .Text = DTDet.Rows(i).Item("HallDesc")
                                .Col = 3
                                .Text = DTDet.Rows(i).Item("SessionType")
                                .Col = 4
                                .Text = DTDet.Rows(i).Item("FROMTIME")
                                .Col = 5
                                .Text = DTDet.Rows(i).Item("TOTIME")
                                .Col = 6
                                .Text = Format(DTDet.Rows(i).Item("PARTYDATE"), "dd/MM/yy")
                                .Col = 7
                                .Text = Format(DTDet.Rows(i).Item("PartyToDate"), "dd/MM/yy")
                                .Col = 8
                                .Text = Format(DTDet.Rows(i).Item("HALLAMOUNT"), "0.00")
                                .Col = 9
                                .Text = DTDet.Rows(i).Item("ChargeCode")
                                .Col = 10
                                .Text = Format(DTDet.Rows(i).Item("HALLTAXAMOUNT"), "0.00")
                                .Col = 11
                                .Text = Format(DTDet.Rows(i).Item("HALLNETAMOUNT"), "0.00")
                                .Col = 12
                                .Text = Format(DTDet.Rows(i).Item("SECURITYDEPOSIT"), "0.00")
                                .Col = 13
                                .Text = Format(DTDet.Rows(i).Item("Act_HallCgs"), "0.00")
                                .Col = 15
                                .Text = DTDet.Rows(i).Item("HALLTYPE")
                                .Col = 16
                                .Text = DTDet.Rows(i).Item("PDesc")
                                .Col = 17
                                .Text = DTDet.Rows(i).Item("M_Keeper")
                            Next
                        End With
                    End If
                    If DT.Rows(0).Item("FREEZE") = "Y" Then
                    Else
                        Call POSDetails()
                        Call ARRANGEMENT()
                        Call Others()
                        Call TarriffVeg()
                        Call TarriffNonVeg()
                    End If

                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If

                    If DT.Rows(0).Item("FREEZE") = "Y" Then
                        CmdAdd.Enabled = False
                        Cmd_Freeze.Enabled = False
                        Button5.Enabled = False
                    End If
                    Dtp_BookingDate.Focus()
                    Txt_MemberCode.Enabled = False
                    Dtp_PartyDate.Enabled = False
                    'Call Total_Calculate()
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.CmdAdd.Text = "Add [F7]"
                    Txt_BookingNo.ReadOnly = False
                    MessageBox.Show("HALL BOOKING NO NOT FOUND,PLEASE BOOK THE HALL FIRST.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Txt_BookingNo.Text = ""
                    Txt_BookingNo.Focus()
                    Exit Sub
                End If
            Else
                MessageBox.Show("HALL BOOKING NO NOT FOUND,PLEASE BOOK THE HALL FIRST.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Txt_BookingNo.Text = ""
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillPayment_Mode()
        Dim sqlstring As String
        Dim index As Integer
        Dim i As Integer
        Try
            Cbo_PaymentMode.Items.Clear()
            sqlstring = " SELECT Paymentcode FROM paymentmodemaster WHERE Isnull(Freeze,'')<>'Y' AND ISNULL(MEMBERSTATUS,'') <> 'SMART CARD'"
            Gconnection.getDataSet(sqlstring, "paymentmodemaster")
            If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("paymentmodemaster").Rows.Count - 1
                    Cbo_PaymentMode.Items.Add(gdataset.Tables("paymentmodemaster").Rows(i).Item("Paymentcode"))
                Next i
                Cbo_PaymentMode.SelectedIndex = 0
            Else
                MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Settlement_Click(sender As Object, e As EventArgs) Handles Cmd_Settlement.Click
        Dim SetAmt As Double
        If Val(Txt_BookingNo.Text) > 0 And Mid(CmdAdd.Text, 1, 1) = "U" Then
            sqlstring = "select BOOKINGNO,SUM(DEB) AS DEB,SUM(CRE) AS CRE from Get_PartyBal WHERE BOOKINGNO = " & Txt_BookingNo.Text & " GROUP BY BOOKINGNO "
            GConnection.getDataSet(sqlstring, "GBal")
            If gdataset.Tables("GBal").Rows.Count > 0 Then
                SetAmt = Val(gdataset.Tables("GBal").Rows(0).Item("DEB") - gdataset.Tables("GBal").Rows(0).Item("CRE"))
            Else
                SetAmt = 0
            End If
            If SetAmt <> 0 Then
                If SetAmt > 0 Then
                    Txt_SettleAmt.Text = SetAmt
                    Rdb_Settle.Checked = True
                    Rdb_Refund.Enabled = False
                    Grp_Settlement.Visible = True
                    CmdAdd.Enabled = False
                ElseIf SetAmt < 0 Then
                    Txt_SettleAmt.Text = -(SetAmt)
                    Rdb_Refund.Checked = True
                    Rdb_Settle.Enabled = False
                    Grp_Settlement.Visible = True
                    CmdAdd.Enabled = False
                End If
            End If
        End If
    End Sub
    Private Sub AutoGenerate_Rec(ByVal Dtype As String)
        DocType = Dtype
        RecRef = ""
        Dim sqlstring, financalyear As String
        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
        Try
            sqlstring = "SELECT MAX(Cast(SUBSTRING(PARTYRECEIPTNO,5,6) As VARCHAR)) AS  PARTYRECEIPTNO FROM party_receipt_HDR  "
            GConnection.openConnection()
            gcommand = New SqlCommand(sqlstring, GConnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    RecRef = DocType & "/000001" & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    GConnection.closeConnection()
                Else
                    RecRef = DocType & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    GConnection.closeConnection()
                End If
            Else
                RecRef = DocType & "/000001" & "/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                GConnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            GConnection.closeConnection()
        End Try
    End Sub
    Private Sub Cmd_Settle_Click(sender As Object, e As EventArgs) Handles Cmd_Settle.Click
        Dim strSQL, SetlleType As String
        Dim DT As New DataTable
        Dim VOUNO As Integer
        Dim INSERT(0) As String
        If Rdb_Settle.Checked = True Then
            SetlleType = "SETTLEMENT"
        ElseIf Rdb_Refund.Checked = True Then
            SetlleType = "REFUND"
        Else
            SetlleType = "SETTLEMENT"
        End If
        If Val(Txt_BookingNo.Text) > 0 And Mid(CmdAdd.Text, 1, 1) = "U" And Val(Txt_SettleAmt.Text) > 0 Then
            Call AutoGenerate_Rec("PAR")
            If RecRef <> "" Then
                strSQL = " INSERT INTO party_receipt_HDR(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,adduserid,adddatetime,"
                strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,CARDNUMBER,PLACE)"
                strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                strSQL = strSQL & "'" & Trim(RecRef) & "'"
                strSQL = strSQL & ",Getdate(),'" & Trim(Cbo_PaymentMode.Text) & "'"
                strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                strSQL = strSQL & ",'N'"
                strSQL = strSQL & ",'','" & Trim(SetlleType) & "',"
                strSQL = strSQL & "'',"
                strSQL = strSQL & "'','',"
                strSQL = strSQL & "'" & Format(Val(Txt_SettleAmt.Text), 0.0) & "','','')"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL

                strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,RType)"
                strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                strSQL = strSQL & "'" & Trim(RecRef) & "'"
                strSQL = strSQL & ",Getdate(),'" & Trim(Cbo_PaymentMode.Text) & "'"
                strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                strSQL = strSQL & ",'FOOD'"
                strSQL = strSQL & ",'PARTY FOOD'"
                strSQL = strSQL & "," & Val(Txt_SettleAmt.Text) & ""
                strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                strSQL = strSQL & ",'N'"
                strSQL = strSQL & ",'','" & Trim(SetlleType) & "',"
                strSQL = strSQL & "'',"
                strSQL = strSQL & "'','',"
                strSQL = strSQL & "'" & Format(Val(Txt_SettleAmt.Text), 0.0) & "','S')"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL

                strSQL = "UPDATE party_receipt_HDR SET DESCRIPTION = H.DESCRIPTION FROM party_hallbooking_hdr H,party_receipt_HDR R WHERE H.BOOKINGNO = R.BOOKINGNO AND R.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL
                strSQL = "UPDATE party_receipt_DET SET DESCRIPTION = H.DESCRIPTION FROM party_hallbooking_hdr H,party_receipt_DET R WHERE H.BOOKINGNO = R.BOOKINGNO AND R.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL
                strSQL = "UPDATE party_receipt_DET SET Receiptheaddesc = M.Receiptheaddesc FROM party_Head_master M, party_receipt_DET D WHERE D.Receiptheadcode = M.Receiptheadcode AND D.PARTYRECEIPTNO = '" & Trim(RecRef) & "' "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL

                GConnection.MoreTransold(INSERT)
                Grp_Settlement.Visible = False
                CmdAdd.Enabled = True
                Txt_SettleAmt.Text = ""
            End If

            sqlstring = "select BOOKINGNO,SUM(DEB) AS DEB,SUM(CRE) AS CRE from Get_PartyBal WHERE BOOKINGNO = " & Txt_BookingNo.Text & " GROUP BY BOOKINGNO "
            GConnection.getDataSet(sqlstring, "GBal")
            If gdataset.Tables("GBal").Rows.Count > 0 Then
                Lbl_Outstanding.Text = "Total Debit : " & gdataset.Tables("GBal").Rows(0).Item("DEB") & ",Total Credit : " & gdataset.Tables("GBal").Rows(0).Item("CRE") & ", Balance : " & (gdataset.Tables("GBal").Rows(0).Item("DEB") - gdataset.Tables("GBal").Rows(0).Item("CRE"))
            Else
                Lbl_Outstanding.Text = ""
            End If
        End If
    End Sub

    Private Sub Txt_BookingNo_TextChanged(sender As Object, e As EventArgs) Handles Txt_BookingNo.TextChanged

    End Sub
End Class