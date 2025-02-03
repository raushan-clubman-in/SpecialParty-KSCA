Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports System.IO
Public Class Frm_T_BanReceipt
    Dim DT As New DataTable
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim Gconnection As New GlobalClass
    Dim DocType As String
    Dim strcn As String = "Persist Security Info=False;User ID=" & strDataSqlUsr & ";PWD=" & strDataSqlPwd & ";Initial Catalog=" & gDatabase & ";Data Source=" & gserver & ""
    Dim SQLCON As SqlConnection
    Dim SQLCMD As SqlCommand
    Dim SQLRDR As SqlDataAdapter

    Private Sub Frm_T_BanReceipt_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
        ElseIf e.Alt = True And e.KeyCode = Keys.B Then
            If Not (MDIParentobj.ActiveMdiChild Is Nothing) Then
                MDIParentobj.ActiveMdiChild.Close()
            End If
            GmoduleName = "BANQUET MENU BILLING"
            Dim SMPS As New Frm_T_BanMenuBilling
            SMPS.Show()
            SMPS.MdiParent = MDIParentobj
        End If
    End Sub
    Private Sub FillReciept()
        Dim dt As New DataTable
        Dim SQLSTRING As Integer
        Try
            SQLCON = New SqlConnection(strcn)
            SQLCMD = New SqlCommand("select * from party_receipt_HDR WHERE BOOKINGNO=" & Txt_BookingNo.Text & "", SQLCON)

            SQLCON.Open()
            SQLRDR = New SqlDataAdapter(SQLCMD)
            SQLRDR.Fill(dt)
            dgvBox.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SQLCON.Close()
        End Try
        dgvBox.ReadOnly = True
    End Sub
    Private Sub Frm_T_BanReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Call FillPayment_Mode()
        Dtp_PartyDate.Value = Format(serverdate, "dd/MM/yyyy")
        Dtp_RecDate.Value = Format(serverdate, "dd/MM/yyyy")

        If Mid(gCompName, 1, 4) = "CATH" Then
            Dtp_RecDate.Enabled = False
        End If
        Lbl_Outstanding.Text = ""
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()

        Call AutoGenerate()
        BankDet.Visible = False

        If Mid(gCompName, 1, 3) = "MGC" Then
            Chk_Prev.Visible = True
        Else
            Chk_Prev.Visible = False
        End If

        If Mid(gCompName, 1, 4) = "KSCA" Then
            Label10.Visible = True
            Txt_AdvAmt.Visible = True
        Else
            Label10.Visible = False
            Txt_AdvAmt.Visible = False
        End If

        Txt_BookingNo.Focus()
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
    Private Sub Txt_BookingNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_BookingNo.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_BookingNo.Text) <> "" Then
                sqlstring = "SELECT * FROM Party_Hallbooking_Hdr WHERE BOOKINGNO=" & Txt_BookingNo.Text & ""
                Gconnection.getDataSet(sqlstring, "HallStatus")
                If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                    Txt_BookingNo_Validated(sender, e)
                    Cbo_PaymentMode.Focus()
                Else
                    Cbo_PaymentMode.Focus()
                End If
            Else
                Call Cmd_BookingNoHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Txt_BookingNo_Validated(sender As Object, e As EventArgs) Handles Txt_BookingNo.Validated
        Try
            If Trim(Txt_BookingNo.Text) <> "" Then
                'sqlstring = "select * from Party_Hallbooking_Hdr WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND ISNULL(FREEZE,'') <> 'Y' "
                If Chk_Prev.Checked = True And Mid(gCompName, 1, 3) = "MGC" And Trim(gPrevDatabase) <> "" Then
                    sqlstring = "select * from " & gPrevDatabase & "..Party_Hallbooking_Hdr WHERE (BOOKINGNO=" & Txt_BookingNo.Text & " OR BOOKINGNO= " & Txt_BookingNo.Text & "-100000 ) AND ISNULL(FREEZE,'') <> 'Y' "
                Else
                    sqlstring = "select * from Party_Hallbooking_Hdr WHERE BOOKINGNO=" & Txt_BookingNo.Text & " AND ISNULL(FREEZE,'') <> 'Y' "
                End If
                Gconnection.getDataSet(sqlstring, "HallHdr")
                If gdataset.Tables("HallHdr").Rows.Count > 0 Then
                    Dtp_PartyDate.Value = Format(gdataset.Tables("HallHdr").Rows(0).Item("PARTYDATE"), "dd/MM/yyyy HH:mm:ss")
                    Txt_MemberCode.Text = gdataset.Tables("HallHdr").Rows(0).Item("MCODE")
                    Txt_MemberName.Text = gdataset.Tables("HallHdr").Rows(0).Item("ASSOCIATENAME")
                    Txt_GuestName.Text = gdataset.Tables("HallHdr").Rows(0).Item("GUESTNAME")
                    Me.Txt_BookingNo.ReadOnly = True
                    Cbo_PaymentMode.Focus()
                Else
                    Txt_BookingNo.Text = ""
                    Txt_BookingNo.Focus()
                End If
                Call FillReciept()
                If Mid(gCompName, 1, 4) = "KSCA" Then
                    sqlstring = "select BOOKINGNO,SUM(DEB) AS DEB,SUM(CRE) AS CRE from Get_PartyBal WHERE BOOKINGNO = " & Txt_BookingNo.Text & " GROUP BY BOOKINGNO "
                    Gconnection.getDataSet(sqlstring, "GBal")
                    If gdataset.Tables("GBal").Rows.Count > 0 Then
                        Lbl_Outstanding.Text = "Total Debit : " & gdataset.Tables("GBal").Rows(0).Item("DEB") & ",Total Credit : " & gdataset.Tables("GBal").Rows(0).Item("CRE") & ", Balance : " & (gdataset.Tables("GBal").Rows(0).Item("DEB") - gdataset.Tables("GBal").Rows(0).Item("CRE"))
                    Else
                        Lbl_Outstanding.Text = ""
                    End If
                Else
                    Lbl_Outstanding.Text = ""
                End If
            Else
                Txt_BookingNo.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        Me.Txt_BookingNo.ReadOnly = False
        Txt_RecNo.ReadOnly = False
        Cmd_Freeze.Enabled = True
        CmdAdd.Enabled = True
        Txt_BookingNo.Text = ""
        Me.lbl_Freeze.Text = ""
        Cmd_BookingNoHelp.Enabled = True
        Cmd_RecNoHelp.Enabled = True
        Call AutoGenerate()
        Dtp_PartyDate.Value = Format(serverdate, "dd/MM/yyyy")
        Dtp_RecDate.Value = Format(serverdate, "dd/MM/yyyy")
        Txt_MemberCode.Text = ""
        Txt_MemberName.Text = ""
        Txt_GuestName.Text = ""
        Txt_Amount.Text = ""
        Txt_AdvAmt.Text = ""
        Lbl_Outstanding.Text = ""
        If Mid(gCompName, 1, 4) = "KSCA" Then
            Label10.Visible = True
            Txt_AdvAmt.Visible = True
        Else
            Label10.Visible = False
            Txt_AdvAmt.Visible = False
        End If
        Me.CmdAdd.Text = "Add [F7]"
        Txt_AdvAmt.Enabled = True
        sSGrid.ClearRange(-1, -1, 1, 1, True)
        sSGrid.SetActiveCell(1, 1)
        dgvBox.DataSource = Nothing
        dgvBox.Refresh()
        BankDet.Visible = False
        Txt_BookingNo.Visible = True
        Txt_BookingNo.Focus()
    End Sub

    Private Sub Cbo_PaymentMode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cbo_PaymentMode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dtp_RecDate.Focus()
        End If
    End Sub

    Private Sub Dtp_RecDate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Dtp_RecDate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cbo_RecType.Focus()
        End If
    End Sub

    Private Sub Cbo_RecType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cbo_RecType.KeyPress
        sSGrid.SetActiveCell(1, 1)
        sSGrid.Focus()
    End Sub
    Private Sub AutoGenerate()
        DocType = "PAR"
        Dim sqlstring, financalyear As String
        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
        Try
            sqlstring = "SELECT MAX(Cast(SUBSTRING(PARTYRECEIPTNO,5,6) As VARCHAR)) AS  PARTYRECEIPTNO FROM party_receipt_HDR  "
            Gconnection.openConnection()
            gcommand = New SqlCommand(sqlstring, Gconnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then

                If gdreader(0) Is System.DBNull.Value Then
                    Txt_RecNo.Text = DocType & "/000001" & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    Gconnection.closeConnection()
                Else
                    Txt_RecNo.Text = DocType & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    Gconnection.closeConnection()
                End If
            Else
                Txt_RecNo.Text = DocType & "/000001" & "/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                Gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            Gconnection.closeConnection()
        End Try
    End Sub

    Private Sub Cbo_PaymentMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo_PaymentMode.SelectedIndexChanged
        Dim sqlstring As String
        Dim index As Integer
        Dim i As Integer
        Try
            sqlstring = " SELECT Paymentcode,ISNULL(MEMBERSTATUS,'') as MEMBERSTATUS FROM paymentmodemaster WHERE Isnull(Freeze,'')<>'Y' AND ISNULL(MEMBERSTATUS,'') <> 'SMART CARD' And Paymentcode = '" & Trim(Cbo_PaymentMode.Text) & "'"
            Gconnection.getDataSet(sqlstring, "paymentmodemaster")
            If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                If gdataset.Tables("paymentmodemaster").Rows(0).Item("MEMBERSTATUS") = "BANK INSTRUMENT" Then
                    BankDet.Visible = True
                Else
                    BankDet.Visible = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub sSGrid_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles sSGrid.KeyDownEvent
        Dim PartyHeadCode As String
        Dim Amount As Double
        Dim i As Integer
        Try
            With sSGrid
                If e.keyCode = Keys.Enter Then
                    i = .ActiveRow
                    If .ActiveCol = 1 Then
                        .Row = i
                        .Col = 1
                        If Trim(.Text) = "" Then
                            Call FillMenu()
                        ElseIf Trim(.Text) <> "" Then
                            PartyHeadCode = Trim(.Text)
                            .ClearRange(1, .ActiveRow, 3, .ActiveRow, True)

                            sqlstring = "SELECT  DISTINCT RECEIPTHEADCODE,Receiptheaddesc FROM party_Head_master"
                            sqlstring = sqlstring & " WHERE RECEIPTHEADCODE='" & PartyHeadCode & "'"
                            Gconnection.getDataSet(sqlstring, "partyheadcode")
                            If gdataset.Tables("partyheadcode").Rows.Count > 0 Then
                                .Col = 1
                                .Row = i
                                .Text = gdataset.Tables("partyheadcode").Rows(0).Item("RECEIPTHEADCODE")
                                .Col = 2
                                .Row = i
                                .Text = gdataset.Tables("partyheadcode").Rows(0).Item("Receiptheaddesc")
                                .SetActiveCell(2, .ActiveRow)
                                .Focus()
                            Else
                                .ClearRange(1, .ActiveRow, 1, .ActiveRow, True)
                                .SetActiveCell(0, .ActiveRow)
                                .Focus()
                            End If
                        End If
                    End If
                ElseIf e.keyCode = Keys.F3 Then
                    .Row = .ActiveRow
                    .ClearRange(1, .ActiveRow, 3, .ActiveRow, True)
                    .DeleteRows(.ActiveRow, 1)
                    .SetActiveCell(1, .ActiveRow)
                End If
                Call CalCulate()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CalCulate()
        Dim qty, taxperc, cancel, kotstatus, rate, varposcode As String
        Dim total, Taxamount, cancelamt, canceltax, Billamount, Packingamt, TIPSAMT, ARate As Double
        Dim i, DDiff As Integer
        Dim d1, d2, Fromdate, ToDate As Date
        With sSGrid
            For i = 1 To .DataRowCnt
                sSGrid.Row = i
                sSGrid.Col = 1
                kotstatus = .Text
                If Trim(kotstatus) <> "" Then
                    .Col = 3
                    total = total + Val(.Text)
                End If
            Next i
        End With
        Txt_Amount.Text = Format(total, "0.00")
    End Sub
    Private Sub FillMenu()
        Try
            Dim vform As New LIST_OPERATION1
            Dim ssql As String
            gSQLString = "SELECT DISTINCT RECEIPTHEADCODE,RECEIPTHEADDESC FROM party_Head_master"
            If Trim(Search) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " "
            End If
            vform.Field = "RECEIPTHEADCODE,RECEIPTHEADDESC"
            vform.vCaption = "RECEIPT HEAD CODE HELP"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                With sSGrid
                    .Col = 1
                    .Row = .ActiveRow
                    .Text = vform.keyfield
                    .Col = 2
                    .Row = .ActiveRow
                    .Text = vform.keyfield1
                End With
                sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cmd_BookingNoHelp_Click(sender As Object, e As EventArgs) Handles Cmd_BookingNoHelp.Click
        Dim vform As New LIST_OPERATION1
        Try
            'gSQLString = "Select BOOKINGNO,MCODE,GUESTNAME,PARTYDATE from Party_Hallbooking_Hdr"
            If Chk_Prev.Checked = True And Mid(gCompName, 1, 3) = "MGC" And Trim(gPrevDatabase) <> "" Then
                gSQLString = "Select BOOKINGNO,MCODE,GUESTNAME,PARTYDATE from " & gPrevDatabase & "..Party_Hallbooking_Hdr"
            Else
                gSQLString = "Select BOOKINGNO,MCODE,GUESTNAME,PARTYDATE from Party_Hallbooking_Hdr"
            End If
            If Trim(Search) = " " Then
                M_WhereCondition = " Where ISNULL(Freeze,'') <> 'Y'"
            Else
                M_WhereCondition = " Where ISNULL(Freeze,'') <> 'Y'"
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

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim strSQL As String
        Dim DT As New DataTable
        Dim VOUNO As Integer
        Dim INSERT(0) As String

        If Mid(gCompName, 1, 4) = "KSCA" And Mid(CmdAdd.Text, 1, 1) = "A" Then
            Call KSCA_CalculateAdv()
        End If

        Call checkValidation()
        If boolchk = False Then Exit Sub

        If Chk_Prev.Checked = True And Mid(gCompName, 1, 3) = "MGC" And Mid(CmdAdd.Text, 1, 1) = "A" And Trim(gPrevDatabase) <> "" Then
            Txt_BookingNo.Text = Txt_BookingNo.Text + 100000
        End If
        If Mid(gCompName, 1, 3) = "MGC" And Mid(CmdAdd.Text, 1, 1) <> "A" Then
            strSQL = "Select  * from  Party_Hallbooking_Hdr where bookingno=" & Txt_BookingNo.Text & " and isnull(freeze,'') <> 'Y' "
            Gconnection.getDataSet(strSQL, "BConfirm")
            If gdataset.Tables("BConfirm").Rows.Count = 0 Then
                MessageBox.Show("Can't Update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        If CmdAdd.Text = "Add [F7]" Then
            Call AutoGenerate()
            strSQL = " INSERT INTO party_receipt_HDR(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,adduserid,adddatetime,"
            strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,CARDNUMBER,PLACE)"
            strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
            strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
            strSQL = strSQL & "'" & Trim(Txt_RecNo.Text) & "'"
            strSQL = strSQL & ",'" & Format(Dtp_RecDate.Value, "dd/MMM/yyyy hh:mm:ss") & "','" & Trim(Cbo_PaymentMode.Text) & "'"
            strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
            strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
            strSQL = strSQL & ",'N'"
            strSQL = strSQL & ",'" & Trim(INS_TYPE.Text) & "','" & Trim(Cbo_RecType.Text) & "',"
            strSQL = strSQL & "'" & Trim(TXT_INSNO.Text) & "',"
            strSQL = strSQL & "'" & Trim(TXT_DRAWEEBANK.Text) & "','" & Format(INS_DATE.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
            strSQL = strSQL & "'" & Format(Val(Txt_Amount.Text), 0.0) & "','" & Trim(TXT_CARDNO.Text) & "','" & Trim(Txt_city.Text) & "')"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            With sSGrid
                For i = 1 To .DataRowCnt
                    strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                    strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT)"
                    strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                    strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                    strSQL = strSQL & "'" & Trim(Txt_RecNo.Text) & "'"
                    strSQL = strSQL & ",'" & Format(Dtp_RecDate.Value, "dd/MMM/yyyy HH:mm:ss") & "','" & Trim(Cbo_PaymentMode.Text) & "'"
                    strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                    .Row = i
                    .Col = 1
                    strSQL = strSQL & ",'" & Trim(.Text) & "'"
                    .Col = 2
                    strSQL = strSQL & ",'" & Trim(.Text) & "'"
                    .Col = 3
                    strSQL = strSQL & "," & Val(.Text) & ""
                    strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                    strSQL = strSQL & ",'N'"
                    strSQL = strSQL & ",'" & Trim(INS_TYPE.Text) & "','" & Trim(Cbo_RecType.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_INSNO.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_DRAWEEBANK.Text) & "','" & Format(INS_DATE.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                    strSQL = strSQL & "'" & Format(Val(Txt_Amount.Text), 0.0) & "')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = strSQL
                Next
            End With
            strSQL = "UPDATE party_receipt_HDR SET DESCRIPTION = H.DESCRIPTION FROM party_hallbooking_hdr H,party_receipt_HDR R WHERE H.BOOKINGNO = R.BOOKINGNO AND R.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            strSQL = "UPDATE party_receipt_DET SET DESCRIPTION = H.DESCRIPTION FROM party_hallbooking_hdr H,party_receipt_DET R WHERE H.BOOKINGNO = R.BOOKINGNO AND R.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL

            If Chk_Prev.Checked = True And Mid(gCompName, 1, 3) = "MGC" And Trim(gPrevDatabase) <> "" Then
                strSQL = "INSERT INTO " & gPrevDatabase & "..party_receipt_HDR(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,adduserid,adddatetime,freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,CARDNUMBER,PLACE)"
                strSQL = strSQL & "SELECT BOOKINGNO-100000,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,adduserid,adddatetime,freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,CARDNUMBER,PLACE FROM party_receipt_HDR WHERE PARTYRECEIPTNO = '" & Trim(Txt_RecNo.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL
                strSQL = "INSERT INTO " & gPrevDatabase & "..party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT)"
                strSQL = strSQL & "SELECT BOOKINGNO-100000,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT FROM party_receipt_DET WHERE PARTYRECEIPTNO = '" & Trim(Txt_RecNo.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL
            End If
            Gconnection.MoreTransold(INSERT)

            If Mid(gCompName, 1, 3) = "MGC" Then
                If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    gPrint = True
                    Call RECEIT_MGC()
                End If
            Else
                If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    gPrint = True
                    Call RECEIT_KSCA()
                End If
            End If
            Call CmdClear_Click(sender, e)
        ElseIf CmdAdd.Text = "Update[F7]" Then
            If Mid(Me.CmdAdd.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            strSQL = "UPDATE  party_receipt_HDR"
            strSQL = strSQL & " SET PARTYRECEIPTDATE='" & Format(Dtp_RecDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
            strSQL = strSQL & " BOOKINGNO ='" & Trim(Txt_BookingNo.Text) & "',"
            strSQL = strSQL & " PARTYDATE ='" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
            strSQL = strSQL & " Mcode ='" & Trim(Txt_MemberCode.Text) & "',"
            strSQL = strSQL & " MNAME ='" & Trim(Txt_MemberName.Text) & "',"
            strSQL = strSQL & " GUESTNAME ='" & Trim(Txt_GuestName.Text) & "',"
            strSQL = strSQL & " PAYMENTMODE ='" & Trim(Cbo_PaymentMode.Text) & "',"
            strSQL = strSQL & " INSTTYPE ='" & Trim(INS_TYPE.Text) & "',"
            strSQL = strSQL & " INSTNO ='" & Trim(TXT_INSNO.Text) & "',"
            strSQL = strSQL & " RECEIPTTYPE='" & Trim(Cbo_RecType.Text) & "',"
            strSQL = strSQL & " DRAWBANK ='" & Trim(TXT_DRAWEEBANK.Text) & "',"
            strSQL = strSQL & " INSTDATE ='" & Format(INS_DATE.Value, "dd/MMM/yyyy") & "',"
            strSQL = strSQL & " UPDATEuserid='" & Trim(gUsername) & "',"
            strSQL = strSQL & " TOTALAMOUNT='" & Format(Val(Txt_Amount.Text), 0.0) & "',"
            strSQL = strSQL & " CARDNUMBER='" & Trim(TXT_INSNO.Text) & "',"
            strSQL = strSQL & " UPDATEadddatetime =Getdate(),freeze='N'"
            strSQL = strSQL & " Where PARTYRECEIPTNO='" & Trim(Txt_RecNo.Text) & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            With sSGrid
                strSQL = " DELETE FROM party_receipt_DET "
                strSQL = strSQL & " Where PARTYRECEIPTNO='" & Trim(Txt_RecNo.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL
                For i = 1 To .DataRowCnt
                    strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                    strSQL = strSQL & "freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT)"
                    strSQL = strSQL & " VALUES ( '" & Trim(Txt_BookingNo.Text) & "',"
                    strSQL = strSQL & "'" & Format(Dtp_PartyDate.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                    strSQL = strSQL & "'" & Trim(Txt_RecNo.Text) & "'"
                    strSQL = strSQL & ",'" & Format(Dtp_RecDate.Value, "dd/MMM/yyyy HH:mm:ss") & "','" & Trim(Cbo_PaymentMode.Text) & "'"
                    strSQL = strSQL & ",'" & Trim(Txt_MemberCode.Text) & "','" & Trim(Txt_MemberName.Text) & "','" & Trim(Txt_GuestName.Text) & "'"
                    .Row = i
                    .Col = 1
                    strSQL = strSQL & ",'" & Trim(.Text) & "'"
                    .Col = 2
                    strSQL = strSQL & ",'" & Trim(.Text) & "'"
                    .Col = 3
                    strSQL = strSQL & "," & Val(.Text) & ""
                    strSQL = strSQL & ",'" & Trim(gUsername) & "',Getdate()"
                    strSQL = strSQL & ",'N'"
                    strSQL = strSQL & ",'" & Trim(INS_TYPE.Text) & "','" & Trim(Cbo_RecType.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_INSNO.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_DRAWEEBANK.Text) & "','" & Format(INS_DATE.Value, "dd/MMM/yyyy HH:mm:ss") & "',"
                    strSQL = strSQL & "'" & Format(Val(Txt_Amount.Text), 0.0) & "')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = strSQL
                Next
            End With
            strSQL = "UPDATE party_receipt_HDR SET DESCRIPTION = H.DESCRIPTION FROM party_hallbooking_hdr H,party_receipt_HDR R WHERE H.BOOKINGNO = R.BOOKINGNO AND R.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            strSQL = "UPDATE party_receipt_DET SET DESCRIPTION = H.DESCRIPTION FROM party_hallbooking_hdr H,party_receipt_DET R WHERE H.BOOKINGNO = R.BOOKINGNO AND R.BOOKINGNO = '" & Trim(Txt_BookingNo.Text) & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL

            Gconnection.MoreTransold(INSERT)
            Call CmdClear_Click(sender, e)
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        Dim hlcode, shlcode, ssql As String
        Dim Partydate As DateTime
        Dim Ftime, Ttime As String

        If Trim(Txt_BookingNo.Text) = "" Then '
            MessageBox.Show("Booing No  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_BookingNo.Focus()
            Exit Sub
        End If
        ssql = "Select  * from  VIEW_PARTY_BOOKINGDETAILS where bookingno=" & Txt_BookingNo.Text & " "
        gconnection.getDataSet(ssql, "BConfirm")
        If gdataset.Tables("BConfirm").Rows.Count > 0 Then
            hlcode = gdataset.Tables("BConfirm").Rows(0).Item("HALLCODE")
            'shlcode = gdataset.Tables("BConfirm").Rows(0).Item("SUPERHALLCODE")
            Partydate = gdataset.Tables("BConfirm").Rows(0).Item("PARTYDATE")
            Ftime = gdataset.Tables("BConfirm").Rows(0).Item("FROMTIME")
            Ttime = gdataset.Tables("BConfirm").Rows(0).Item("TOTIME")

            ssql = "SELECT BOOKINGNO,PARTYDATE,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS"
            If shlcode <> "" Then
                ssql = ssql & " WHERE '" & Format(Partydate, "yyyy-MM-dd") & "' BETWEEN CAST(CONVERT(VARCHAR(11),PARTYDATE,106)AS DATETIME) AND CAST(CONVERT(VARCHAR(11),PARTYTODATE,106)AS DATETIME) AND '" & (Ftime) & "' BETWEEN FROMTIME AND TOTIME  AND (HALLCODE='" & hlcode & "' ) And Bookingno<>" & Txt_BookingNo.Text
            Else
                ssql = ssql & " WHERE '" & Format(Partydate, "yyyy-MM-dd") & "' BETWEEN CAST(CONVERT(VARCHAR(11),PARTYDATE,106)AS DATETIME) AND CAST(CONVERT(VARCHAR(11),PARTYTODATE,106)AS DATETIME) AND '" & (Ftime) & "' BETWEEN FROMTIME AND TOTIME  AND (HALLCODE='" & hlcode & "' ) And Bookingno<>" & Txt_BookingNo.Text
            End If
            DT = gconnection.GetValues(ssql)
            If DT.Rows.Count > 0 Then
                MessageBox.Show("ALREAD BOOKING IS CONFIRM TO OTHERS ON THIS TIME,PLEASE CHECK THE HALLSTATUS", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.CmdAdd.Enabled = False
                Exit Sub
            End If
            ssql = "SELECT BOOKINGNO,PARTYDATE,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS"
            If shlcode <> "" Then
                ssql = ssql & " WHERE '" & Format(Partydate, "yyyy-MM-dd") & "' BETWEEN CAST(CONVERT(VARCHAR(11),PARTYDATE,106)AS DATETIME) AND CAST(CONVERT(VARCHAR(11),PARTYTODATE,106)AS DATETIME) AND '" & (Ttime) & "' BETWEEN FROMTIME AND TOTIME  AND (HALLCODE='" & hlcode & "'  ) And Bookingno<>" & Txt_BookingNo.Text
            Else
                ssql = ssql & " WHERE '" & Format(Partydate, "yyyy-MM-dd") & "' BETWEEN CAST(CONVERT(VARCHAR(11),PARTYDATE,106)AS DATETIME) AND CAST(CONVERT(VARCHAR(11),PARTYTODATE,106)AS DATETIME) AND '" & (Ttime) & "' BETWEEN FROMTIME AND TOTIME  AND (HALLCODE='" & hlcode & "') And Bookingno<>" & Txt_BookingNo.Text
            End If
            DT = gconnection.GetValues(ssql)
            If DT.Rows.Count > 0 Then
                MessageBox.Show("ALREAD BOOKING IS CONFIRM TO OTHERS ON THIS TIME,PLEASE CHECK THE HALLSTATUS", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.CmdAdd.Enabled = False
                Exit Sub
            End If
        End If

        ssql = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & Txt_BookingNo.Text & " AND  Isnull(cancelflag,'')='Y'"
        DT = gconnection.GetValues(ssql)
        If DT.Rows.Count > 0 Then
            MessageBox.Show(" This Booking is Cancelled Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Trim(Cbo_PaymentMode.Text) = "" Then
            MessageBox.Show("Payment Mode can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cbo_PaymentMode.Focus()
            Exit Sub
        End If
        If Trim(Cbo_RecType.Text) = "" Then
            MessageBox.Show("Receipt Type can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cbo_RecType.Focus()
            Exit Sub
        End If
        If Trim(Txt_MemberCode.Text) = "" Then
            MessageBox.Show("Member Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_MemberCode.Focus()
            Exit Sub
        End If
        If Trim(Txt_MemberName.Text) = "" Then
            MessageBox.Show("Member Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_MemberName.Focus()
            Exit Sub
        End If
        If Trim(Txt_GuestName.Text) = "" Then
            MessageBox.Show("Guest Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_GuestName.Focus()
            Exit Sub
        End If
        
        With sSGrid
            For i = 1 To .DataRowCnt
                .Row = i
                .Col = 3
                If Val(.Text) <= 0 Then
                    MessageBox.Show("Receipt Amount can't be Zero or Less then Zero", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next
        End With
        sqlstring = " SELECT Paymentcode,ISNULL(MEMBERSTATUS,'') as MEMBERSTATUS FROM paymentmodemaster WHERE Isnull(Freeze,'')<>'Y' AND ISNULL(MEMBERSTATUS,'') <> 'SMART CARD' And Paymentcode = '" & Trim(Cbo_PaymentMode.Text) & "'"
        Gconnection.getDataSet(sqlstring, "paymentmodemaster")
        If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
            If gdataset.Tables("paymentmodemaster").Rows(0).Item("MEMBERSTATUS") = "BANK INSTRUMENT" Then
                If Trim(TXT_INSNO.Text) = "" Then
                    MessageBox.Show("Ins no can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TXT_INSNO.Focus()
                    Exit Sub
                End If
                If Trim(TXT_DRAWEEBANK.Text) = "" Then '
                    MessageBox.Show("Drawee Bank  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TXT_DRAWEEBANK.Focus()
                    Exit Sub
                End If
                If Trim(INS_TYPE.Text) = "" Then '
                    MessageBox.Show("Ins Type can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    INS_TYPE.Focus()
                    Exit Sub
                End If
            End If
        End If
        boolchk = True
    End Sub

    Private Sub Cmd_RecNoHelp_Click(sender As Object, e As EventArgs) Handles Cmd_RecNoHelp.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "Select DISTINCT PARTYRECEIPTNO,PARTYRECEIPTDATE,BOOKINGNO,PARTYDATE,MCODE FROM party_receipt_DET "
            M_WhereCondition = " Where Isnull(RType,'') <> 'B' "
            'M_WhereCondition = " "
            vform.Field = "PARTYRECEIPTNO,PARTYRECEIPTDATE"
            vform.vCaption = "Receipts Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_RecNo.Text = Trim(vform.keyfield & "")
                Txt_RecNo.Select()
                Call TXT_RecNo_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Txt_RecNo.ReadOnly = True
    End Sub

    Private Sub Txt_RecNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_RecNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Call Txt_RecNo_Validated(sender, e)
        End If
    End Sub

    Private Sub Txt_RecNo_Validated(sender As Object, e As EventArgs) Handles Txt_RecNo.Validated
        Try
            sqlstring = "SELECT * FROM Party_Receipt_HDR WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "' "
            Gconnection.getDataSet(sqlstring, "Party_Receipt_HDR")
            If gdataset.Tables("Party_Receipt_HDR").Rows.Count > 0 Then
                Txt_BookingNo.Text = gdataset.Tables("Party_Receipt_HDR").Rows(0).Item("bookingno")
                Dtp_PartyDate.Value = Format(gdataset.Tables("Party_Receipt_HDR").Rows(0).Item("partydate"), "dd/MM/yyyy")
                Cbo_PaymentMode.Text = gdataset.Tables("Party_Receipt_HDR").Rows(0).Item("PAYMENTMODE")
                Dtp_RecDate.Value = Format(gdataset.Tables("Party_Receipt_HDR").Rows(0).Item("PARTYRECEIPTDATE"), "dd/MM/yyyy")
                Txt_MemberCode.Text = gdataset.Tables("Party_Receipt_HDR").Rows(0).Item("mcode")
                Txt_MemberName.Text = gdataset.Tables("Party_Receipt_HDR").Rows(0).Item("mname")
                Txt_GuestName.Text = gdataset.Tables("Party_Receipt_HDR").Rows(0).Item("GUESTNAME")
                Cbo_RecType.Text = gdataset.Tables("Party_Receipt_HDR").Rows(0).Item("RECEIPTTYPE")
                Txt_Amount.Text = Format(gdataset.Tables("Party_Receipt_HDR").Rows(0).Item("TOTALAMOUNT"), "0.00")
                TXT_CARDNO.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("cardnumber")
                Txt_city.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("PLACE")
                INS_TYPE.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("INSTTYPE")
                TXT_INSNO.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("INSTNO")
                INS_DATE.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("INSTDATE")
                TXT_DRAWEEBANK.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("DRAWBANK")
                If gdataset.Tables("party_receipt_hdr").Rows(0).Item("FREEZE") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "This Receipt is Freezed on :" & Format(CDate(gdataset.Tables("party_receipt_hdr").Rows(0).Item("FREEZEDATE")), "dd-MMM-yyyy")
                    Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                    Me.CmdAdd.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = ""
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If
                sqlstring = "SELECT Receiptheadcode,Receiptheaddesc,amount,RECEIPTTYPE from party_receipt_DET WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "'"
                DT = Gconnection.GetValues(sqlstring)
                If DT.Rows.Count > 0 Then
                    sSGrid.ClearRange(-1, -1, 1, 1, True)
                    With sSGrid
                        For i = 0 To DT.Rows.Count - 1
                            .Col = 1
                            .Row = i + 1
                            .Text = DT.Rows(i).Item("Receiptheadcode")
                            .Col = 2
                            .Row = i + 1
                            .Text = DT.Rows(i).Item("Receiptheaddesc")
                            .Col = 3
                            .Row = i + 1
                            .Text = DT.Rows(i).Item("amount")
                        Next
                    End With
                    Me.CmdAdd.Text = "Update[F7]"
                    Txt_AdvAmt.Enabled = False
                End If
                Txt_RecNo.ReadOnly = True
                Txt_BookingNo.ReadOnly = True
                Cmd_BookingNoHelp.Enabled = False
                Cmd_RecNoHelp.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub sSGrid_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles sSGrid.LeaveCell
        Call CalCulate()
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Dim Insert(0) As String
        Call checkValidation()
        If boolchk = False Then Exit Sub
        Dim Fre, strsql As String
        Try
            If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
                If MsgBox("Are U Sure To Delete", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    sqlstring = "UPDATE party_receipt_hdr "
                    sqlstring = sqlstring & " SET Freeze= 'Y',FREEZEadduserid='" & gUsername & " ',"
                    sqlstring = sqlstring & " FREEZEDATE=Getdate() "
                    sqlstring = sqlstring & " Where  PARTYRECEIPTNO='" & Trim(Txt_RecNo.Text) & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "UPDATE party_receipt_DET SET Freeze= 'Y',FREEZEadduserid='" & gUsername & " ',FREEZEDATE=Getdate()  Where  PARTYRECEIPTNO='" & Trim(Txt_RecNo.Text) & "' "
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    Gconnection.MoreTransold(Insert)
                    Me.CmdClear_Click(sender, e)
                    CmdAdd.Text = "Add [F7]"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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

    Private Sub Cmdview_Click(sender As Object, e As EventArgs) Handles Cmdview.Click
        If Mid(gCompName, 1, 3) = "MGC" Then
            gPrint = False
            Call RECEIT_MGC()
        ElseIf Mid(gCompName, 1, 4) = "CATH" Then
            gPrint = False
            Call PartyReceiptCath()
        Else
            If MessageBox.Show("Press OK for Print,View for Cancel ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                gPrint = True
            Else
                gPrint = False
            End If
            If Mid(gCompName, 1, 4) = "KSCA" Then
                Call RECEIT_KSCA()
            Else
                Call RECEIT()
            End If
        End If

        'Call RECEIT()
    End Sub
    Private Sub RECEIT()
        Dim Viewer As New ReportViwer
        Dim r1 As New partreceiptVoucher_CIAL
        Dim i As Integer
        Dim sqlstring, sqlstring1, towords As String
        Dim Amt As Double

        sqlstring = " SELECT * from partyreceiptvoucher  WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "' "
        Gconnection.getDataSet(sqlstring, "PARTYRECEIPTNO")
        sqlstring1 = " SELECT * from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "' "
        Gconnection.getDataSet(sqlstring1, "PARTYRECEIPTNO")
        If (gdataset.Tables("PARTYRECEIPTNO").Rows.Count > 0) Then

            Call Viewer.GetDetails1(sqlstring, "partyreceiptvoucher", r1)
            Call Viewer.GetDetails1(sqlstring1, "partyreceiptvoucher1", r1)

            sqlstring = "SELECT SUM(amount) as amount from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "'"
            Gconnection.getDataSet(sqlstring, "amount")
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

    Private Sub RECEIT_MGC()
        Dim Viewer As New ReportViwer
        Dim r1 As New Rpt_ReceiptPaymentNote
        Dim i As Integer
        Dim sqlstring, sqlstring1, towords As String
        Dim Amt As Double

        ''sqlstring = " SELECT * from partyreceiptvoucher  WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "' "
        ''Gconnection.getDataSet(sqlstring, "PARTYRECEIPTNO")
        ''sqlstring1 = " SELECT * from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "' "
        ''Gconnection.getDataSet(sqlstring1, "PARTYRECEIPTNO

        ''sqlstring1 = "SELECT 1 as copyno,'M E M B E R C O P Y' as copydesc,b.ClubLogo as ClubLogo,'CASH' as cashbank,PARTYRECEIPTNO  AS VOUCHERNO,PARTYRECEIPTDATE  AS VOUCHERDATE,"
        ''sqlstring1 = sqlstring1 & " 'CR' AS VOUCHERTYPE,'' AS ACCOUNTCODE,'' AS ACCOUNTCODEDESC,MCODE AS SLCODE,MNAME AS SLDESC,'' AS COSTCENTERCODE,'' AS COSTCENTERDESC,'CREDIT' AS CREDITDEBIT,"
        ''sqlstring1 = sqlstring1 & " AMOUNT,AMOUNT AS CRAMOUNT,0 AS DRAMOUNT,DESCRIPTION,INSTDATE AS INSTRUMENTDATE,INSTNO AS INSTRUMENTNO,MNAME AS RECEIVEDFROM,FREEZE AS VOID,'' AS BANKPLACE,"
        ''sqlstring1 = sqlstring1 & " convert(varchar(11),isnull(AddDateTime,''),108) as AdddateTime FROM party_receipt_DET a,accountssetup b WHERE PARTYRECEIPTNO = '" & Me.Txt_RecNo.Text & "'  UNION ALL "
        ''sqlstring1 = sqlstring1 & " SELECT 2 as copyno,'O F F I C E C O P Y' as copydesc,b.ClubLogo as ClubLogo,'CASH' as cashbank,PARTYRECEIPTNO  AS VOUCHERNO,PARTYRECEIPTDATE  AS VOUCHERDATE,"
        ''sqlstring1 = sqlstring1 & " 'CR' AS VOUCHERTYPE,'' AS ACCOUNTCODE,'' AS ACCOUNTCODEDESC,MCODE AS SLCODE,MNAME AS SLDESC,'' AS COSTCENTERCODE,'' AS COSTCENTERDESC,'CREDIT' AS CREDITDEBIT,"
        ''sqlstring1 = sqlstring1 & " AMOUNT,AMOUNT AS CRAMOUNT,0 AS DRAMOUNT,DESCRIPTION,INSTDATE AS INSTRUMENTDATE,INSTNO AS INSTRUMENTNO,MNAME AS RECEIVEDFROM,FREEZE AS VOID,'' AS BANKPLACE,"
        ''sqlstring1 = sqlstring1 & " convert(varchar(11),isnull(AddDateTime,''),108) as AdddateTime FROM party_receipt_DET a,accountssetup b WHERE PARTYRECEIPTNO = '" & Me.Txt_RecNo.Text & "' "
        sqlstring1 = "SELECT 1 as copyno,'M E M B E R C O P Y' as copydesc,b.ClubLogo as ClubLogo,'CASH' as cashbank,PARTYRECEIPTNO  AS VOUCHERNO,PARTYRECEIPTDATE  AS VOUCHERDATE,"
        sqlstring1 = sqlstring1 & " 'CR' AS VOUCHERTYPE,'' AS ACCOUNTCODE,RECEIPTHEADDESC AS ACCOUNTCODEDESC,MCODE AS SLCODE,MNAME AS SLDESC,'' AS COSTCENTERCODE,'' AS COSTCENTERDESC,'CREDIT' AS CREDITDEBIT,"
        sqlstring1 = sqlstring1 & " AMOUNT,AMOUNT AS CRAMOUNT,0 AS DRAMOUNT,DESCRIPTION,INSTDATE AS INSTRUMENTDATE,INSTNO AS INSTRUMENTNO,MNAME AS RECEIVEDFROM,FREEZE AS VOID,'' AS BANKPLACE,"
        sqlstring1 = sqlstring1 & " convert(varchar(11),isnull(AddDateTime,''),108) as AdddateTime FROM party_receipt_DET a,accountssetup b WHERE PARTYRECEIPTNO = '" & Me.Txt_RecNo.Text & "'  UNION ALL "
        sqlstring1 = sqlstring1 & " SELECT 2 as copyno,'O F F I C E C O P Y' as copydesc,b.ClubLogo as ClubLogo,'CASH' as cashbank,PARTYRECEIPTNO  AS VOUCHERNO,PARTYRECEIPTDATE  AS VOUCHERDATE,"
        sqlstring1 = sqlstring1 & " 'CR' AS VOUCHERTYPE,'' AS ACCOUNTCODE,RECEIPTHEADDESC AS ACCOUNTCODEDESC,MCODE AS SLCODE,MNAME AS SLDESC,'' AS COSTCENTERCODE,'' AS COSTCENTERDESC,'CREDIT' AS CREDITDEBIT,"
        sqlstring1 = sqlstring1 & " AMOUNT,AMOUNT AS CRAMOUNT,0 AS DRAMOUNT,DESCRIPTION,INSTDATE AS INSTRUMENTDATE,INSTNO AS INSTRUMENTNO,MNAME AS RECEIVEDFROM,FREEZE AS VOID,'' AS BANKPLACE,"
        sqlstring1 = sqlstring1 & " convert(varchar(11),isnull(AddDateTime,''),108) as AdddateTime FROM party_receipt_DET a,accountssetup b WHERE PARTYRECEIPTNO = '" & Me.Txt_RecNo.Text & "' "

        Gconnection.getDataSet(sqlstring1, "vw_ReceiptPaymentNote")
        If (gdataset.Tables("vw_ReceiptPaymentNote").Rows.Count > 0) Then

            ''Call Viewer.GetDetails1(sqlstring, "partyreceiptvoucher", r1)
            Call Viewer.GetDetails1(sqlstring1, "vw_ReceiptPaymentNote", r1)

            sqlstring = "SELECT SUM(amount) as amount from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "'"
            Gconnection.getDataSet(sqlstring, "amount")
            If (gdataset.Tables("amount").Rows.Count > 0) Then
                Amt = gdataset.Tables("amount").Rows(0).Item(0)
            End If

            towords = RupeesToWord(Amt)
            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text6")
            TXTOBJ5.Text = Amt & " " & towords

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text11")
            TXTOBJ1.Text = MyCompanyName

            Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ2 = r1.ReportDefinition.ReportObjects("Text14")
            TXTOBJ2.Text = Address1 & " " & Address2

            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text8")
            TXTOBJ3.Text = gCity & "-" & gPincode

            If Trim(Cbo_RecType.Text) = "REFUND" Then
                Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text5")
                TXTOBJ4.Text = "PARTY REFUND"
            Else
                Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ4 = r1.ReportDefinition.ReportObjects("Text5")
                TXTOBJ4.Text = "PARTY RECEIPT"
            End If

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

    Private Sub RECEIT_KSCA()
        Dim Viewer As New ReportViwer
        Dim r1 As New Rpt_ReceiptPaymentNote_KSCA
        Dim i As Integer
        Dim sqlstring, sqlstring1, towords, SLCODE1, PayMode As String
        Dim Amt As Double
        Dim Bookno, HFromTime, HToTime, HHDesc As String
        Dim HPartyDate As DateTime

        sqlstring1 = "SELECT 1 as copyno,'M E M B E R C O P Y' as copydesc,b.ClubLogo as ClubLogo,'CASH' as cashbank,PARTYRECEIPTNO  AS VOUCHERNO,PARTYRECEIPTDATE  AS VOUCHERDATE,"
        sqlstring1 = sqlstring1 & " 'CR' AS VOUCHERTYPE,'' AS ACCOUNTCODE,RECEIPTHEADDESC AS ACCOUNTCODEDESC,MCODE AS SLCODE,MNAME AS SLDESC,'' AS COSTCENTERCODE,'' AS COSTCENTERDESC,'CREDIT' AS CREDITDEBIT,"
        sqlstring1 = sqlstring1 & " AMOUNT,AMOUNT AS CRAMOUNT,0 AS DRAMOUNT,DESCRIPTION,INSTDATE AS INSTRUMENTDATE,INSTNO AS INSTRUMENTNO,MNAME AS RECEIVEDFROM,FREEZE AS VOID,'' AS BANKPLACE,"
        sqlstring1 = sqlstring1 & " convert(varchar(11),isnull(AddDateTime,''),108) as AdddateTime FROM party_receipt_DET a,accountssetup b WHERE PARTYRECEIPTNO = '" & Me.Txt_RecNo.Text & "'  UNION ALL "
        sqlstring1 = sqlstring1 & " SELECT 2 as copyno,'O F F I C E C O P Y' as copydesc,b.ClubLogo as ClubLogo,'CASH' as cashbank,PARTYRECEIPTNO  AS VOUCHERNO,PARTYRECEIPTDATE  AS VOUCHERDATE,"
        sqlstring1 = sqlstring1 & " 'CR' AS VOUCHERTYPE,'' AS ACCOUNTCODE,RECEIPTHEADDESC AS ACCOUNTCODEDESC,MCODE AS SLCODE,MNAME AS SLDESC,'' AS COSTCENTERCODE,'' AS COSTCENTERDESC,'CREDIT' AS CREDITDEBIT,"
        sqlstring1 = sqlstring1 & " AMOUNT,AMOUNT AS CRAMOUNT,0 AS DRAMOUNT,DESCRIPTION,INSTDATE AS INSTRUMENTDATE,INSTNO AS INSTRUMENTNO,MNAME AS RECEIVEDFROM,FREEZE AS VOID,'' AS BANKPLACE,"
        sqlstring1 = sqlstring1 & " convert(varchar(11),isnull(AddDateTime,''),108) as AdddateTime FROM party_receipt_DET a,accountssetup b WHERE PARTYRECEIPTNO = '" & Me.Txt_RecNo.Text & "' "

        Gconnection.getDataSet(sqlstring1, "vw_ReceiptPaymentNote")
        If (gdataset.Tables("vw_ReceiptPaymentNote").Rows.Count > 0) Then
            SLCODE1 = gdataset.Tables("vw_ReceiptPaymentNote").Rows(0).Item("SLCODE")
            Call Viewer.GetDetails1(sqlstring1, "vw_ReceiptPaymentNote", r1)

            sqlstring = "SELECT SUM(amount) as amount from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "'"
            Gconnection.getDataSet(sqlstring, "amount")
            If (gdataset.Tables("amount").Rows.Count > 0) Then
                Amt = gdataset.Tables("amount").Rows(0).Item(0)
            End If

            sqlstring = "SELECT *  from partyreceiptvoucher1 WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "'"
            Gconnection.getDataSet(sqlstring, "Partyvou")
            If (gdataset.Tables("Partyvou").Rows.Count > 0) Then
                PayMode = gdataset.Tables("Partyvou").Rows(0).Item("PAYMENTMODE")
            End If

            ''Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            ''TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text11")
            ''TXTOBJ1.Text = MyCompanyName

            ''Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
            ''TXTOBJ2 = r1.ReportDefinition.ReportObjects("Text14")
            ''TXTOBJ2.Text = Address1 & " " & Address2

            ''Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            ''TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text8")
            ''TXTOBJ3.Text = gCity & "-" & gPincode

            sqlstring = "SELECT BOOKINGNO,PARTYDATE,FROMTIME,TOTIME,HallDesc FROM PARTY_HALLBOOKING_DET WHERE BOOKINGNO IN (SELECT BOOKINGNO FROM PARTY_RECEIPT_dET WHERE PARTYRECEIPTNO = '" & Me.Txt_RecNo.Text & "')"
            Gconnection.getDataSet(sqlstring, "PInfo")
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

            If Trim(Cbo_RecType.Text) = "REFUND" Then
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
            Gconnection.getDataSet(sqlstring, "MEMBERMASTER")
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

    Private Sub PartyReceiptCath()
        Dim Viewer As New ReportViwer
        Dim r1 As New CRPT_PAR_RECEIPT
        Dim i As Integer
        Dim sqlstring, sqlstring1, towords As String
        Dim Amt As Double

        sqlstring = " SELECT * from PartyreceiptVoucher  WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "' "
        Gconnection.getDataSet(sqlstring, "PARTYRECEIPTNO")
        sqlstring1 = " SELECT * from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "' "
        Gconnection.getDataSet(sqlstring1, "PARTYRECEIPTNO")
        If (gdataset.Tables("PARTYRECEIPTNO").Rows.Count > 0) Then

            Call Viewer.GetDetails1(sqlstring, "PartyRreceiptVoucher", r1)
            Call Viewer.GetDetails1(sqlstring1, "partyreceiptvoucher1", r1)

            sqlstring = "SELECT SUM(amount) as amount from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Me.Txt_RecNo.Text & "'"
            Gconnection.getDataSet(sqlstring, "amount")
            If (gdataset.Tables("amount").Rows.Count > 0) Then
                Amt = gdataset.Tables("amount").Rows(0).Item(0)
            End If
            Dim TXTOBJ11 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ11 = r1.ReportDefinition.ReportObjects("Text1")
            TXTOBJ11.Text = MyCompanyName

            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text2")
            TXTOBJ6.Text = Address1 & " " & Address2

            Dim TXTOBJ7 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ7 = r1.ReportDefinition.ReportObjects("Text3")
            TXTOBJ7.Text = gCity & "," & gState & "-" & gPincode


            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text26")
            TXTOBJ1.Text = "UserName : " & gUsername

            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If

    End Sub

    Private Sub Txt_AdvAmt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_AdvAmt.KeyPress
        getNumeric(e)
        Call KSCA_CalculateAdv()
    End Sub
    Private Sub KSCA_CalculateAdv()
        Dim i As Integer
        Dim BalAmt, Hamt As Double
        Dim ADVAvail As Boolean
        If Mid(gCompName, 1, 4) = "KSCA" Then
        Else
            Exit Sub
        End If
        If Trim(Cbo_RecType.Text) = "ADVANCE" And Mid(CmdAdd.Text, 1, 1) = "A" Then
            sSGrid.ClearRange(-1, -1, 1, 1, True)
        End If
        sqlstring = "SELECT * FROM party_receipt_DET WHERE BOOKINGNO = " & Me.Txt_BookingNo.Text & " AND RECEIPTTYPE = 'ADVANCE'"
        Gconnection.getDataSet(sqlstring, "RECAMT")
        If gdataset.Tables("RECAMT").Rows.Count > 0 Then
            ADVAvail = True
        Else
            ADVAvail = False
        End If
        If Trim(Cbo_RecType.Text) = "ADVANCE" And Val(Txt_AdvAmt.Text) > 0 Then
            sqlstring = "SELECT SUM(ISNULL(HALLNETAMOUNT,0)) AS HALLAMT FROM Party_Hallbooking_Hdr WHERE BOOKINGNO = '" & Me.Txt_BookingNo.Text & "'"
            Gconnection.getDataSet(sqlstring, "HALLAMT")
            If gdataset.Tables("HALLAMT").Rows.Count > 0 Then
                Hamt = gdataset.Tables("HALLAMT").Rows(0).Item(0)
                BalAmt = Val(Txt_AdvAmt.Text)
                With sSGrid
                    For i = 1 To 2
                        If i = 1 Then
                            sqlstring = "select Receiptheadcode,Receiptheaddesc from party_Head_master where Receiptheadcode = 'HALL'"
                            Gconnection.getDataSet(sqlstring, "HALL")
                            If gdataset.Tables("HALL").Rows.Count > 0 And ADVAvail = False Then
                                .Row = i
                                .Col = 1
                                .Text = gdataset.Tables("HALL").Rows(0).Item(0)
                                .Col = 2
                                .Text = gdataset.Tables("HALL").Rows(0).Item(1)
                                .Col = 3
                                If Hamt < BalAmt Then
                                    .Text = Hamt
                                Else
                                    .Text = BalAmt
                                End If
                                BalAmt = BalAmt - Hamt
                            End If
                        Else
                            If i = 2 Then
                                sqlstring = "select Receiptheadcode,Receiptheaddesc from party_Head_master where Receiptheadcode = 'FOOD'"
                                Gconnection.getDataSet(sqlstring, "HALL")
                                If gdataset.Tables("HALL").Rows.Count > 0 And BalAmt > 0 Then
                                    If ADVAvail = True Then
                                        .Row = i - 1
                                    Else
                                        .Row = i
                                    End If
                                    .Col = 1
                                    .Text = gdataset.Tables("HALL").Rows(0).Item(0)
                                    .Col = 2
                                    .Text = gdataset.Tables("HALL").Rows(0).Item(1)
                                    .Col = 3
                                    .Text = BalAmt
                                End If
                            End If
                        End If
                    Next
                End With
            End If
        End If
    End Sub
End Class