Imports System.Text.RegularExpressions
Public Class FRM_MKGA_POSSETUP


    Dim boolchk As Boolean
    Dim vseqno As Double
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim vconn As New GlobalClass

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim SQL(0) As String
        'Dim I As Integer
        ' If CmdAdd.Text = "Add [F7]" Then
        Call checkValidation() ''--->Check Validation
        If boolchk = False Then Exit Sub

        sqlstring = "DELETE FROM POSSETUP "
        ReDim Preserve SQL(SQL.Length)
        SQL(SQL.Length - 1) = sqlstring

        sqlstring = " INSERT INTO POSSETUP ( PAYMENTMODE,PackingPercent,PCKDESC,PCKLIMIT,tips,SCDESC,SCLIMIT,adcharge,ADDESC,ADLIMIT,prcharge,grcharge,roundoffyesno,roundval,"
        sqlstring = sqlstring & " centralizedkot,kottype,kotprefix,finalprefix,tablerequired,KOTGOLFAPP,LOCREQ,CARDREQ,CRLIMIT,DFLTRLE,STATUS,BRLIMIT,WAITREQR,AddUSerId,AddDateTime)"
        'salesacctin,SalesAcctdesc,PackingPercent,PackingAcctin,Packingdesc,Freeze,StoreStatus,AddUSerId,AddDateTime,under,TIPSSTATUS,tips,tipsacctin,accharge,acchargeacctin)"
        sqlstring = sqlstring & " VALUES ( '" & Replace(Trim(CMB_PAYMENT.Text), "'", "") & "',"

        'sqlstring = sqlstring & " ' SALES ','" & Replace(Trim(txtAcctDesc.Text), "'", "") & "',"
        'sqlstring = sqlstring & " '" & Trim(txtAcctIn.Text) & "','" & Replace(Trim(txtAcctDesc.Text), "'", "") & "',"

        sqlstring = sqlstring & " " & Format(Val(txt_PackingPercent.Text), "0.00") & ",'" & Replace(Trim(txt_PCKDESC.Text), "'", "") & "'," & Format(Val(txt_PCKLIMIT.Text), "0.00") & "," & Format(Val(txt_tips.Text), "0.00") & ",'" & Replace(Trim(TXT_SCKDESC.Text), "'", "") & "'," & Format(Val(TXT_SCLIMIT.Text), "0.00") & "," & Format(Val(txt_acchg.Text), "0.00") & ",'" & Replace(Trim(TXT_ADDESC.Text), "'", "") & "'," & Format(Val(TXT_ADLIMIT.Text), "0.00") & "," & Format(Val(Txt_party.Text), "0.00") & "," & Format(Val(Txt_groom.Text), "0.00") & ","
        sqlstring = sqlstring & " '" & Trim(CMB_ROUND.Text) & "'," & Format(Val(CMB_RNDVAL.Text), "0.00") & "," '" & Trim(TXT_CENTRALIZED.Text) & "',"
        sqlstring = sqlstring & " '" & Trim(TXT_CENTRALIZED.Text) & "','" & Trim(CMB_TYPE.Text) & "','" & Trim(Txt_prefix.Text) & "','" & Trim(Txt_fprefix.Text) & "'," ''" & Trim(CMB_DIRECT.Text) & "',"
        sqlstring = sqlstring & " '" & Trim(CMB_TABLENO.Text) & "','" & Trim(Cmb_KotGolfReg.Text) & "','" & Trim(CMB_LOCATION.Text) & "','" & Trim(CMB_SMRT.Text) & "','" & Trim(CMB_CLIMIT.Text) & "','" & Trim(CMB_DEFAULT.Text) & "','" & Trim(CMB_STATUS.Text) & "'," & Format(Val(txt_barlimit.Text), "0.00") & ",'" & Trim(cmb_wr.Text) & "',"
        'If opt_Facility.Checked = True Then
        '    sqlstring = sqlstring & " 'N','F',"
        'ElseIf opt_Store.Checked = True Then
        '    sqlstring = sqlstring & " 'N','S',"
        'ElseIf opt_KITCHEN.Checked = True Then
        '    sqlstring = sqlstring & " 'N','K',"
        'End If
        sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
        'If ChKTIPSYES.Checked = True Then
        ' sqlstring = sqlstring & " 'T',"
        ' ElseIf ChKTIPSNO.Checked = True Then
        ' sqlstring = sqlstring & " 'F',"
        'End If

        'sqlstring = sqlstring & " " & Val(Me.txt_tips.Text) & ",'" & Me.txt_tipsacctin.Text & "'," & Val(Me.txt_acchg.Text) & ",'" & Me.txt_acchgin.Text & "')"


        ReDim Preserve SQL(SQL.Length)
        SQL(SQL.Length - 1) = sqlstring
        ' End If
        gconnection.MoreTransold(SQL)
        Me.CmdClear_Click(sender, e)
        Call addActivation()

    End Sub

    Private Sub FRM_MKGA_POSSETUP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cbo_BillPrint.SelectedIndex = 0
        'Cbo_BillPrint.Focus()
        CmdAdd.Enabled = True
        CMB_PAYMENT.Select()
        Call addActivation()
        GroupMasterbool = True
        Call fillpayment()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub
    Private Sub fillpayment()
        Try
            Dim i As Integer
            sqlstring = " SELECT DISTINCT paymentcode FROM paymentmodemaster where freeze <> 'Y' ORDER BY paymentcode ASC"
            vconn.getDataSet(sqlstring, "paymentmodemaster")
            CMB_PAYMENT.Items.Clear()
            CMB_PAYMENT.Sorted = True
            If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("paymentmodemaster").Rows.Count - 1
                    CMB_PAYMENT.Items.Add(gdataset.Tables("paymentmodemaster").Rows(i).Item("paymentcode"))
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub
    Public Sub addActivation()
        'sqlstring = "SELECT ISNULL(centralizedkot,'') AS centralizedkot,ISNULL(kotentry,'') AS kotentry,ISNULL(directbill,'') AS directbill,"
        sqlstring = " SELECT ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(roundoffyesno,'') AS roundoffyesno,ISNULL(tablerequired,'') AS tablerequired FROM POSSETUP "
        gconnection.getDataSet(sqlstring, "POSSETUP")
        If gdataset.Tables("POSSETUP").Rows.Count > 0 Then
            'txtRoundoffacctin.Enabled = False
            'txtRoundoffacctdesc.Enabled = False
            'cmdRoundoffacctin.Enabled = False
            CmdAdd.Enabled = False
            Exit Sub
        Else
            'txtRoundoffacctin.Enabled = True
            'txtRoundoffacctdesc.Enabled = True
            'cmdRoundoffacctin.Enabled = True
            CmdAdd.Enabled = True
            Exit Sub
        End If
    End Sub
    Private Sub GetRights()
        Dim i, x As Integer
        'Dim vmain, vsmod, vssmod As Long
        Dim SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        chstr = 0
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='POS' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdAdd.Enabled = True
        Me.CmbView.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    Me.CmbView.Enabled = True
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
                If Right(x) = "V" Then
                    Me.CmbView.Enabled = True
                End If
            Next
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = True
    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call addActivation()

        Call clearform(Me)

        'Cmd_Add.Text = "Add [F7]"
        Dim CTRL As New Control
        'For Each CTRL In GroupBox1.Controls
        '    If TypeOf CTRL Is TextBox Then
        '        CTRL.Text = ""
        '    End If
        '    If TypeOf CTRL Is ComboBox Then
        '        CTRL.Text = ""
        '    End If
        'Next CTRL
        CMB_PAYMENT.Select()
        txt_acchg.Text = "0.00"
        txt_PackingPercent.Text = "0.00"
        txt_tips.Text = "0.00"
        Txt_party.Text = "0.00"
        Txt_groom.Text = "0.00"
        TXT_ADDESC.Text = ""
        txt_PCKDESC.Text = ""
        txt_acchg.Text = ""
        Txt_prefix.Text = ""
        Txt_fprefix.Text = ""
        CMB_TYPE.Text = ""
        CMB_RNDVAL.Text = ""
        txt_barlimit.Text = ""
        CMB_CLIMIT.Text = ""
        CMB_DEFAULT.Text = ""
        CMB_PAYMENT.Text = ""
        CMB_LOCATION.Text = ""
        CMB_STATUS.Text = ""
        CMB_TABLENO.Text = ""
        CMB_SMRT.Text = ""
        txt_PCKLIMIT.Text = ""
        TXT_SCLIMIT.Text = ""
        TXT_ADLIMIT.Text = ""

        If gUserCategory <> "S" Then
            Call GetRights()
        End If

        CMB_PAYMENT.Focus()

    End Sub
    Private Sub txt_PackingPercent_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txt_PCKDESC.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_PCKDESC.Focus()
        End If
    End Sub
    Private Sub txt_tips_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            TXT_SCKDESC.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            TXT_SCKDESC.Focus()
        End If
    End Sub




    Private Sub txt_acchg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_acchg.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXT_ADDESC.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            TXT_ADDESC.Focus()
        End If
    End Sub
    Private Sub txt_PCKDESC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_PCKDESC.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_PCKLIMIT.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_PCKLIMIT.Focus()
        End If
    End Sub

    Private Sub txt_PCKLIMIT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_PCKLIMIT.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_tips.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_tips.Focus()
        End If
    End Sub

    Private Sub txt_SCKDESC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_SCKDESC.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXT_SCLIMIT.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            TXT_SCLIMIT.Focus()
        End If
    End Sub

    Private Sub txt_SCLIMIT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_SCLIMIT.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_acchg.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_acchg.Focus()
        End If
    End Sub

    Private Sub txt_ADDESC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_ADDESC.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXT_ADLIMIT.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            TXT_ADLIMIT.Focus()
        End If
    End Sub

    Private Sub txt_ADLIMIT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_ADLIMIT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt_party.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            Txt_party.Focus()
        End If
    End Sub

    Private Sub Txt_party_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_party.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt_groom.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            Txt_groom.Focus()
        End If
    End Sub

    Private Sub Txt_groom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_groom.KeyDown
        If e.KeyCode = Keys.Enter Then
            CMB_ROUND.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CMB_ROUND.Focus()
        End If
    End Sub

    Private Sub CMB_TABLENO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMB_TABLENO.KeyDown
        If e.KeyCode = Keys.Enter Then
            CMB_LOCATION.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CMB_LOCATION.Focus()
        End If
    End Sub

    Private Sub CMB_LOCATION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMB_LOCATION.KeyDown
        If e.KeyCode = Keys.Enter Then
            CMB_SMRT.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CMB_SMRT.Focus()
        End If
    End Sub

    Private Sub CMB_SMRT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMB_SMRT.KeyDown
        If e.KeyCode = Keys.Enter Then
            CMB_CLIMIT.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CMB_CLIMIT.Focus()
        End If
    End Sub

    Private Sub CMB_CLIMIT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMB_CLIMIT.KeyDown
        If e.KeyCode = Keys.Enter Then
            CMB_DEFAULT.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CMB_DEFAULT.Focus()
        End If
    End Sub

    Private Sub CMB_DEFAULT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMB_DEFAULT.KeyDown
        If e.KeyCode = Keys.Enter Then
            CMB_STATUS.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CMB_STATUS.Focus()
        End If
    End Sub

    Private Sub CMB_PAYMENT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMB_PAYMENT.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_PackingPercent.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_PackingPercent.Focus()
        End If
    End Sub
    Private Sub CMB_ROUND_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_ROUND.SelectedIndexChanged
        If CMB_ROUND.Text = "YES" Then
            CMB_RNDVAL.Visible = True
            Lblroundval.Visible = True
        Else
            CMB_RNDVAL.Visible = False
            Lblroundval.Visible = False
        End If
    End Sub


    Private Sub CMB_ROUND_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMB_ROUND.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If CMB_ROUND.Text = "YES" Then
                CMB_RNDVAL.Focus()
            Else
                TXT_CENTRALIZED.Focus()
            End If
        End If
    End Sub

    Private Sub CMB_RNDVAL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMB_RNDVAL.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            TXT_CENTRALIZED.Focus()
        End If
    End Sub


    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub txt_PackingPercent_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_PackingPercent.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_PCKDESC.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_PCKDESC.Focus()
        End If
    End Sub


    Private Sub txt_tips_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_tips.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXT_SCKDESC.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            TXT_SCKDESC.Focus()
        End If
    End Sub

    Private Sub CMB_STATUS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMB_STATUS.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_barlimit.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_barlimit.Focus()
        End If
    End Sub

    Private Sub txt_acchg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_acchg.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'for ne decimal point
        If (e.KeyChar = "."c AndAlso (txt_acchg).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_PackingPercent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_PackingPercent.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'for ne decimal point
        If (e.KeyChar = "."c AndAlso (txt_PackingPercent).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txt_party_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_party.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'for ne decimal point
        If (e.KeyChar = "."c AndAlso (Txt_party).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txt_groom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_groom.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'for ne decimal point
        If (e.KeyChar = "."c AndAlso (Txt_groom).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_tips_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_tips.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'for ne decimal point
        If (e.KeyChar = "."c AndAlso (txt_tips).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXT_ADLIMIT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_ADLIMIT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
                'MsgBox(" Numbers only ")
            End If
        End If
    End Sub

    Private Sub txt_PCKLIMIT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_PCKLIMIT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
                'MsgBox(" Numbers only ")
            End If
        End If
    End Sub

    Private Sub TXT_SCLIMIT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_SCLIMIT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
                'MsgBox(" Numbers only ")
            End If
        End If
    End Sub

    Private Sub txt_barlimit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_barlimit.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
                'MsgBox(" Numbers only ")
            End If
        End If
    End Sub

    Private Sub txt_PCKDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_PCKDESC.KeyPress
        getCharater(e)
    End Sub

    Private Sub txt_PCKDESC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_PCKDESC.TextChanged
        'If (System.Text.RegularExpressions.Regex.IsMatch("^[a-zA-Z]", txt_PCKDESC.Text)) Then

        '    ' MessageBox.Show("This textbox accepts only alphabetical characters")
        '    ' TXT_TITLE.Text.Remove(TXT_TITLE.Text.Length - 1)
        'End If

    End Sub

    Private Sub TXT_SCKDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_SCKDESC.KeyPress
        getCharater(e)
    End Sub

    Private Sub TXT_SCKDESC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_SCKDESC.TextChanged
        'If (System.Text.RegularExpressions.Regex.IsMatch("^[a-zA-Z]", TXT_SCKDESC.Text)) Then

        '    ' MessageBox.Show("This textbox accepts only alphabetical characters")
        '    ' TXT_TITLE.Text.Remove(TXT_TITLE.Text.Length - 1)
        'End If

    End Sub

    Private Sub TXT_ADDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_ADDESC.KeyPress
        getCharater(e)
    End Sub

    Private Sub TXT_ADDESC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_ADDESC.TextChanged
        'If (System.Text.RegularExpressions.Regex.IsMatch("^[a-zA-Z]", TXT_ADDESC.Text)) Then

        '    ' MessageBox.Show("This textbox accepts only alphabetical characters")
        '    ' TXT_TITLE.Text.Remove(TXT_TITLE.Text.Length - 1)
        'End If

    End Sub

    Private Sub cmd_brwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_brwse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM POSSETUP"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM POSSETUP", "SERIALNO", 0)

    End Sub

    Private Sub TXT_CENTRALIZED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_CENTRALIZED.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If TXT_CENTRALIZED.Text = "YES" Then
                CMB_TYPE.Focus()
            Else
                CMB_TABLENO.Focus()
            End If
        End If
    End Sub

    Private Sub TXT_CENTRALIZED_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_CENTRALIZED.SelectedIndexChanged
        If TXT_CENTRALIZED.Text = "YES" Then
            LBLTYPE.Visible = True
            CMB_TYPE.Visible = True
            ' CMB_KOTENTRY.Enabled = False
            ' CMB_DIRECT.Enabled = False
            If CMB_TYPE.Text = "AUTO" Then
                LBLPREFIX.Visible = True
                Txt_prefix.Visible = True
                LBLFPREFIX.Visible = True
                Txt_fprefix.Visible = True
                'Else
                '    CMB_KOTENTRY.Focus()
            End If
        Else
            LBLTYPE.Visible = False
            CMB_TYPE.Visible = False
            LBLPREFIX.Visible = False
            Txt_prefix.Visible = False
            LBLFPREFIX.Visible = False
            Txt_fprefix.Visible = False
            ' CMB_KOTENTRY.Enabled = True
            'CMB_DIRECT.Enabled = True
            'CMB_KOTENTRY.Focus()
        End If
    End Sub

    Private Sub CMB_TYPE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMB_TYPE.KeyPress
        If CMB_TYPE.Text = "AUTO" Then
            'If TXT_CENTRALIZED.Text = "YES" Or CMB_KOTENTRY.Text = "YES" Then
            Txt_prefix.Focus()
            'Else
            '    TXT_DRPREFIX.Focus()
            'End If
        Else
            'If TXT_CENTRALIZED.Text = "YES" Then
            ' CMB_TABLENO.Focus()
            'ElseIf CMB_KOTENTRY.Text = "YES" Then
            '    CMB_DIRECT.Focus()
            'Else
            CMB_TABLENO.Focus()
        End If
        'End If
    End Sub

    Private Sub CMB_TYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMB_TYPE.SelectedIndexChanged
        If CMB_TYPE.Text = "AUTO" Then
            'If TXT_CENTRALIZED.Text = "YES" Or CMB_KOTENTRY.Text = "YES" Then
            LBLPREFIX.Visible = True
            Txt_prefix.Visible = True
            LBLFPREFIX.Visible = True
            Txt_fprefix.Visible = True
            'Txt_prefix.Focus()
            'Else
            '    Txt_prefix.Visible = True
            '    LBLFPREFIX.Visible = True
            'End If
        Else
            LBLPREFIX.Visible = False
            Txt_prefix.Visible = False
            LBLFPREFIX.Visible = False
            Txt_fprefix.Visible = False
        End If
    End Sub

    Private Sub Txt_prefix_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_prefix.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TXT_CENTRALIZED.Text = "YES" Then 'O''r CMB_KOTENTRY.Text = "YES" Then
                Txt_fprefix.Focus()
            Else
                CMB_TABLENO.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_fprefix_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_fprefix.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TXT_CENTRALIZED.Text = "YES" Then
                CMB_TABLENO.Focus()
           
                'CMB_PAYMENT.Focus()
                End If
            End If
        ' End If
    End Sub

    Private Sub CmbView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbView.Click
        Dim strStatus As Integer
        'If Trim(txtPOSCode.Text) <> "" Then
        'vseqno = GetSeqno(txtPOSCode.Text)
        'sqlstring = "SELECT ISNULL(POSDESC,'') AS POSDESC,ISNULL(SALESACCTIN,'') AS SALESACCTIN,ISNULL(SALESACCTDESC,'') AS SALESACCTDESC,ISNULL(FREEZE,'') AS FREEZE ,ADDDATETIME,ISNULL(STORESTATUS,'') AS STORESTATUS "
        sqlstring = "select  isnull(PackingPercent,0) as PackingPercent,isnull(pckdesc,'') as pckdesc,isnull(pcklimit,0) as pcklimit,isnull(tips,0) as tips,isnull(scdesc,'') as scdesc,isnull(sclimit,0) as sclimit,isnull(adcharge,0) as adcharge,isnull(addesc,'') as addesc,isnull(adlimit,0) as adlimit,isnull(prcharge,0) as prcharge,isnull(grcharge,0) as grcharge"
        sqlstring = sqlstring & ",isnull(roundoffyesno,'') as roundoffyesno ,isnull(ROUNDVAL,0) as ROUNDVAL,isnull(paymentmode,'') as paymentmode,isnull(centralizedkot,'') as centralizedkot "
        sqlstring = sqlstring & ",isnull(kottype,'') as kottype,isnull(kotprefix,'') as kotprefix,isnull(finalprefix,'') as finalprefix,isnull(LOCREQ,'') as LOCREQ,isnull(CRLIMIT,'') as CRLIMIT,isnull(DFLTRLE,'') as DFLTRLE"
        sqlstring = sqlstring & ",isnull(STATUS,'') as STATUS,isnull(tablerequired,'') as tablerequired,isnull(CARDREQ,'') as CARDREQ,isnull(WAITREQR,'') as WAITREQR,isnull(BRLIMIT,0) as BRLIMIT,ISNULL(KOTGOLFAPP,'NO') AS KOTGOLFAPP"
        'sqlstring = "ISNULL(FREEZE,'') AS FREEZE ,ADDDATETIME "

        'sqlstring = sqlstring & ",ISNULL(PACKINGPERCENT,0) AS PACKINGPERCENT,ISNULL(PACKINGACCTIN,'') AS PACKINGACCTIN,ISNULL(PACKINGDESC,'') AS PACKINGDESC,ISNULL(tips,0)AS TIPS,ISNULL(tipsacctin,'')AS TIPSACCTIN ,isnull(accharge,0)as accharge,isnull(acchargeacctin,'')as acchargeacctin 
        sqlstring = sqlstring & " FROM POSSETUP " 'WHERE POSSEQNO = " & Trim(vseqno)
        gconnection.getDataSet(sqlstring, "POSMASTER")
        If gdataset.Tables("POSMASTER").Rows.Count > 0 Then
            'txtPOSDesc.Clear()
            'Call VISIBLEform(Me)
            ' Cmb_postype.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("storetype"))
            ' txtPOSDesc.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("POSDESC"))
            txt_PackingPercent.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("PACKINGPERCENT")), "0.00")
            txt_PCKDESC.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("pckdesc"))
            txt_PCKLIMIT.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("pcklimit")), "0.00")
            txt_tips.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("tips")), "0.00")
            TXT_SCKDESC.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("scdesc"))
            TXT_SCLIMIT.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("sclimit")), "0.00")
            txt_acchg.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("adcharge")), "0.00")
            TXT_ADDESC.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("addesc"))
            TXT_ADLIMIT.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("adlimit")), "0.00")
            Txt_party.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("prcharge")), "0.00")
            Txt_groom.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("grcharge")), "0.00")
            CMB_ROUND.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("roundoffyesno"))
            CMB_RNDVAL.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("roundval")), "0.00")
            CMB_PAYMENT.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("paymentmode"))
            TXT_CENTRALIZED.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("centralizedkot"))
            'CMB_KOTENTRY.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("kotentry"))
            'CMB_TYPE.Visible = True
            CMB_TYPE.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("kottype"))
            'Txt_prefix.Visible = True
            Txt_prefix.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("kotprefix"))
            'Txt_fprefix.Visible = True
            Txt_fprefix.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("finalprefix"))
            CMB_TABLENO.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("tablerequired"))
            Cmb_KotGolfReg.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("KOTGOLFAPP"))
            CMB_SMRT.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("CARDREQ"))
            cmb_wr.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("WAITREQR"))
            CMB_STATUS.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("STATUS"))
            CMB_LOCATION.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("LOCREQ"))
            CMB_DEFAULT.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("DFLTRLE"))
            CMB_CLIMIT.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("CRLIMIT"))
            txt_barlimit.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("BRLIMIT"))
            CmdAdd.Enabled = True
            Me.CmdAdd.Text = "UPDATE"
            TXT_CENTRALIZED_SelectedIndexChanged(sender, e)
            CMB_ROUND_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CmdClear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Me.CmdClear_Click(sender, e)
    End Sub
End Class