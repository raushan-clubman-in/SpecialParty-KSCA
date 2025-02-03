Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.IO
Public Class FRM_MKGA_POSMaster
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim vSeqNo As Double
    Dim vconn As New GlobalClass

    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LBLDRTYPE As System.Windows.Forms.Label
    Dim gconnection As New GlobalClass
    Private Sub CMD_USER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_USER.Click
        If GRP_USER.Visible = False Then
            GRP_USER.Visible = True
            GRP_USER.BringToFront()
            ' GRP_LOC.Visible = False
        Else
            GRP_USER.Visible = False
        End If
    End Sub

    Private Sub CMD_LOCATION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_LOCATION.Click
        If GRP_LOC.Visible = False Then
            GRP_LOC.Visible = True
            GRP_LOC.BringToFront()
            ' GRP_LOC.Visible = False
        Else
            GRP_LOC.Visible = False
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub txtPOSCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPOSCode.KeyPress
        'getNumeric(e)
        getAlphanumeric(e)

        If Asc(e.KeyChar) = 13 Then
            If txtPOSCode.Text <> "" Then
                txtPOSCode_Validated(txtPOSCode, e)
                txtPOSDesc.Focus()
            Else
                Call cmdPOSHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub cmdPOSHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPOSHelp.Click
       
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(POSCODE,'') AS POSCODE,ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER"
            M_WhereCondition = " "
            vform.Field = "POSCODE,POSDESC"
            'vform.Frmcalled = "  POSCODE  | POS DESCRIPTION          |                                  "
            vform.vCaption = "Pos Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtPOSCode.Text = Trim(vform.keyfield & "")
                txtPOSCode.Select()
                txtPOSCode_Validated(sender, e)
                CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub
   
    Private Sub txtPOSCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOSCode.Validated
        Dim strStatus As Integer
        If Trim(txtPOSCode.Text) <> "" Then
            vSeqNo = GetSeqno(txtPOSCode.Text)
            'sqlstring = "SELECT ISNULL(POSDESC,'') AS POSDESC,ISNULL(SALESACCTIN,'') AS SALESACCTIN,ISNULL(SALESACCTDESC,'') AS SALESACCTDESC,ISNULL(FREEZE,'') AS FREEZE ,ADDDATETIME,ISNULL(STORESTATUS,'') AS STORESTATUS "
            sqlstring = "select isnull(Storetype,'') as storetype,isnull(PosDesc,'') as posdesc, isnull(PackingPercent,0) as PackingPercent,isnull(pckdesc,'') as pckdesc,isnull(pcklimit,0) as pcklimit,isnull(tips,0) as tips,isnull(scdesc,'') as scdesc,isnull(sclimit,0) as sclimit,isnull(adcharge,0) as adcharge,isnull(addesc,'') as addesc,isnull(adlimit,0) as adlimit,isnull(prcharge,0) as prcharge,isnull(grcharge,0) as grcharge"
            sqlstring = sqlstring & ",isnull(roundoffyesno,'') as roundoffyesno ,isnull(ROUNDVAL,0) as ROUNDVAL,isnull(paymentmode,'') as paymentmode,isnull(centralizedkot,'') as centralizedkot "
            sqlstring = sqlstring & ",isnull(kotentry,'') as kotentry,isnull(kottype,'') as kottype,isnull(kotprefix,'') as kotprefix,isnull(finalprefix,'') as finalprefix,isnull(directbill,'') as directbill,isnull(directtype,'') as directtype"
            sqlstring = sqlstring & ",isnull(directprefix,'') as directprefix,isnull(tablerequired,'') as tablerequired,isnull(smartrequired,'') as smartrequired,AddUSerId,AddDateTime,voiddate,freeze "
            'sqlstring = "ISNULL(FREEZE,'') AS FREEZE ,ADDDATETIME "

            'sqlstring = sqlstring & ",ISNULL(PACKINGPERCENT,0) AS PACKINGPERCENT,ISNULL(PACKINGACCTIN,'') AS PACKINGACCTIN,ISNULL(PACKINGDESC,'') AS PACKINGDESC,ISNULL(tips,0)AS TIPS,ISNULL(tipsacctin,'')AS TIPSACCTIN ,isnull(accharge,0)as accharge,isnull(acchargeacctin,'')as acchargeacctin 
            sqlstring = sqlstring & " FROM POSMASTER WHERE POSSEQNO = " & Trim(vSeqNo)
            gconnection.getDataSet(sqlstring, "POSMASTER")
            If gdataset.Tables("POSMASTER").Rows.Count > 0 Then
                txtPOSDesc.Clear()
                'Call VISIBLEform(Me)
                Cmb_postype.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("storetype"))
                txtPOSDesc.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("POSDESC"))
                txt_PackingPercent.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("PACKINGPERCENT")), "0.00")
                txt_PCKDESC.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("pckdesc"))
                txt_PCKLIMIT.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("pcklimit")), "0.00")
                txt_tips.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("tips")), "0.00")
                txt_SCKDESC.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("scdesc"))
                txt_SCLIMIT.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("sclimit")), "0.00")
                txt_acchg.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("adcharge")), "0.00")
                txt_ADDESC.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("addesc"))
                txt_ADLIMIT.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("adlimit")), "0.00")
                Txt_party.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("prcharge")), "0.00")
                txt_groom.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("grcharge")), "0.00")
                CMB_ROUND.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("roundoffyesno"))
                CMB_RNDVAL.Text = Format(Val(gdataset.Tables("POSMASTER").Rows(0).Item("roundval")), "0.00")
                CMB_PAYMENT.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("paymentmode"))
                TXT_CENTRALIZED.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("centralizedkot"))
                CMB_KOTENTRY.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("kotentry"))
                'CMB_TYPE.Visible = True
                CMB_TYPE.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("kottype"))
                'Txt_prefix.Visible = True
                Txt_prefix.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("kotprefix"))
                'Txt_fprefix.Visible = True
                Dim VSQL As String
                If Txt_prefix.Text <> "" Then
                    If Len(Txt_prefix.Text) = 3 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(KOTDETAILS,1,3),'')AS kotprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(KOTDETAILS,1,3),'') ='" & Trim(Txt_prefix.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    ElseIf Len(Txt_prefix.Text) = 4 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(KOTDETAILS,1,4),'')AS kotprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(KOTDETAILS,1,4),'') ='" & Trim(Txt_prefix.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    ElseIf Len(Txt_prefix.Text) = 2 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(KOTDETAILS,1,2),'')AS kotprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(KOTDETAILS,1,2),'') ='" & Trim(Txt_prefix.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    ElseIf Len(Txt_prefix.Text) = 5 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(KOTDETAILS,1,5),'')AS kotprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(KOTDETAILS,1,5),'') ='" & Trim(Txt_prefix.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    End If
                    gconnection.getDataSet(VSQL, "kotprefixVALIDATION")
                    If gdataset.Tables("kotprefixVALIDATION").Rows.Count - 1 > 0 Then
                        ' MsgBox("THIS KOT PREFIX HAVING TRANSACTION, U CANNOT UPDATE THIS PREFIX ")
                        ' Txt_prefix.Text = gdataset.Tables("kotprefixVALIDATION").Rows(0).Item("kotprefix")
                        Txt_prefix.ReadOnly = True
                        'Exit Sub
                    Else
                        Txt_prefix.ReadOnly = False
                    End If
                End If
                Txt_fprefix.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("finalprefix"))
                If Txt_fprefix.Text <> "" Then
                    If Len(Txt_fprefix.Text) = 3 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(billdetails,1,3),'')AS finalprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(billdetails,1,3),'') ='" & Trim(Txt_fprefix.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    ElseIf Len(Txt_fprefix.Text) = 4 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(billdetails,1,4),'')AS finalprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(billdetails,1,4),'') ='" & Trim(Txt_fprefix.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    ElseIf Len(Txt_fprefix.Text) = 2 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(billdetails,1,2),'')AS finalprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(billdetails,1,2),'') ='" & Trim(Txt_fprefix.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    ElseIf Len(Txt_fprefix.Text) = 5 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(billdetails,1,5),'')AS finalprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(billdetails,1,5),'') ='" & Trim(Txt_fprefix.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    End If
                    gconnection.getDataSet(VSQL, "finalprefixVALIDATION")
                    If gdataset.Tables("finalprefixVALIDATION").Rows.Count - 1 > 0 Then
                        ' MsgBox("THIS Final PREFIX HAVING TRANSACTION, U CANNOT UPDATE THIS PREFIX ")
                        ' Txt_prefix.Text = gdataset.Tables("kotprefixVALIDATION").Rows(0).Item("kotprefix")
                        Txt_fprefix.ReadOnly = True
                        'Exit Sub
                    Else
                        Txt_fprefix.ReadOnly = False
                    End If
                End If
                CMB_DIRECT.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("directbill"))
                'CMB_DIRECT.Visible = True
                CMB_DRTYPE.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("directtype"))
                'TXT_DRPREFIX.Visible = True
                TXT_DRPREFIX.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("directprefix"))
                'Dim VSQL As String
                If TXT_DRPREFIX.Text <> "" Then
                    If Len(TXT_DRPREFIX.Text) = 3 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(KOTDETAILS,1,3),'')AS directprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(KOTDETAILS,1,3),'') ='" & Trim(TXT_DRPREFIX.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    ElseIf Len(TXT_DRPREFIX.Text) = 4 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(KOTDETAILS,1,4),'')AS directprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(KOTDETAILS,1,4),'') ='" & Trim(TXT_DRPREFIX.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    ElseIf Len(TXT_DRPREFIX.Text) = 2 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(KOTDETAILS,1,2),'')AS directprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(KOTDETAILS,1,2),'') ='" & Trim(TXT_DRPREFIX.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    ElseIf Len(TXT_DRPREFIX.Text) = 5 Then
                        VSQL = " SELECT isnull(poscode,'') as poscode,isNULL(SUBSTRING(KOTDETAILS,1,5),'')AS directprefix  FROM KOT_DET WHERE isNULL(SUBSTRING(KOTDETAILS,1,5),'') ='" & Trim(TXT_DRPREFIX.Text) & "' AND POSCODE='" & Trim(txtPOSCode.Text) & "'"
                    End If
                    gconnection.getDataSet(VSQL, "directprefixVALIDATION")
                    If gdataset.Tables("directprefixVALIDATION").Rows.Count - 1 > 0 Then
                        ' MsgBox("THIS Direct PREFIX HAVING TRANSACTION, U CANNOT UPDATE THIS PREFIX ")
                        ' Txt_prefix.Text = gdataset.Tables("kotprefixVALIDATION").Rows(0).Item("kotprefix")
                        TXT_DRPREFIX.ReadOnly = True
                        'Exit Sub
                    Else
                        TXT_DRPREFIX.ReadOnly = False
                    End If
                End If

                CMB_TABLENO.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("tablerequired"))
                CMB_SMRT.Text = Trim(gdataset.Tables("POSMASTER").Rows(0).Item("smartrequired"))

                txtPOSCode.ReadOnly = True
                txtPOSDesc.Focus()
                CMB_KOTENTRY_SelectedIndexChanged(sender, e)
                CMB_TYPE_SelectedIndexChanged(sender, e)
                CMB_ROUND_SelectedIndexChanged(sender, e)
                CMB_DIRECT_SelectedIndexChanged(sender, e)
                CMB_DRTYPE_SelectedIndexChanged(sender, e)

                ' TXT_CENTRALIZED_SelectedIndexChanged(sender, e)
                If gdataset.Tables("POSMASTER").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("POSMASTER").Rows(0).Item("voiddate")), "dd-MMM-yyyy")
                    ' Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If

                Me.CmdAdd.Text = "Update[F7]"
                Me.cmdPOSHelp.Enabled = False
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.CmdAdd.Text = "Add [F7]"
                txtPOSCode.ReadOnly = False
                txtPOSDesc.Focus()
            End If
            'Else
            '    txtPOSCode.Text = ""
            '    txtPOSDesc.Focus()
            'End If
            Dim strsql As String
            Dim I As Integer

            strsql = "select * from POS_USERCONTROL WHERE POSCODE = '" & Trim(txtPOSCode.Text) & "'  "
            gconnection.getDataSet(strsql, "MEM")
            If gdataset.Tables("MEM").Rows.Count > 0 Then
                With USERGRID
                    For I = 0 To gdataset.Tables("MEM").Rows.Count - 1
                        .Col = 1
                        .Row = I + 1
                        .Text = Trim(gdataset.Tables("MEM").Rows(I).Item("USERNAME"))
                    Next
                    .SetActiveCell(1, 1)
                    .Focus()
                End With
            End If

            strsql = "select * from POS_locationCONTROL WHERE POSCODE = '" & Trim(txtPOSCode.Text) & "'  "
            gconnection.getDataSet(strsql, "LOC")
            If gdataset.Tables("LOC").Rows.Count > 0 Then
                With Lssgrid
                    For I = 0 To gdataset.Tables("LOC").Rows.Count - 1
                        .Col = 1
                        .Row = I + 1
                        .Text = Trim(gdataset.Tables("LOC").Rows(I).Item("locationNAME"))
                    Next
                    .SetActiveCell(1, 1)
                    .Focus()
                End With
            End If
        Else
            txtPOSCode.Text = ""
            txtPOSDesc.Focus()
        End If

    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='POS' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
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
        ' CmdView.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    ' Me.CmdView.Enabled = True
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
                    ' Me.CmdView.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub FRM_MKGA_POSMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F4 Then
            If cmdPOSHelp.Enabled = True Then
                Search = Trim(txtPOSCode.Text)
                Call cmdPOSHelp_Click(txtPOSCode, e)
            End If
        End If
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            If Cmd_Freeze.Enabled = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F7 Then
            If CmdAdd.Enabled = True Then
                Call CmdAdd_Click(CmdAdd, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            If CMDVIEW.Enabled = True Then
                Call CMDVIEW_Click(CMDVIEW, e)
                Exit Sub
            End If
        End If
        'If e.KeyCode = Keys.F10 Then
        '    If CmdView.Enabled = True Then
        '        Call cmdexport_Click(CmdView, e)
        '        Exit Sub
        '    End If
        'End If

        'If e.KeyCode = Keys.F12 Then
        '    If CmdView.Enabled = True Then
        '        Call cmdreport_Click(CmdView, e)
        '        Exit Sub
        '    End If
        'End If

        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(cmdexit, e)
            Exit Sub
        End If
    End Sub

    Private Sub FRM_MKGA_POSMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cmb_postype.DropDownStyle = ComboBoxStyle.DropDownList
        Cmb_postype.Select()
        Cmb_postype.SelectedIndex = 0
        Me.Cmb_postype.Text = Cmb_postype.Items(0)
        CmdAdd.Text = "Add [F7]"
        txtPOSCode.ReadOnly = False
        txtPOSDesc.ReadOnly = False
        Call fillpayment()
        If (Me.Contains(USERGRID)) Then
            USERGRID.SendToBack()
        End If
        If (Me.Contains(Lssgrid)) Then
            Lssgrid.SendToBack()
        End If
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Lssgrid.ClearRange(1, 1, -1, -1, True)
        USERGRID.ClearRange(1, 1, -1, -1, True)
        Cmb_postype.Focus()
        sqlstring = " SELECT  isnull(centralizedkot,'') as centralizedkot  FROM possetup  "
        vconn.getDataSet(sqlstring, "possetup")
        If gdataset.Tables("possetup").Rows(0).Item("centralizedkot") = "YES" Then
            TXT_CENTRALIZED.Enabled = False
        End If
        CMB_KOTENTRY_SelectedIndexChanged(sender, e)
        CMB_ROUND_SelectedIndexChanged(sender, e)
        CMB_DIRECT_SelectedIndexChanged(sender, e)
        CMB_DRTYPE_SelectedIndexChanged(sender, e)
        CMB_TYPE_SelectedIndexChanged(sender, e)
        TXT_CENTRALIZED_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub fillpayment()
        Try
            Dim i As Integer
            sqlstring = " SELECT DISTINCT paymentcode FROM paymentmodemaster WHERE FREEZE <> 'Y' ORDER BY paymentcode ASC"
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
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Call clearform(Me)
        Cmb_postype.Select()

        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.Enabled = True
        CmdAdd.Text = "Add [F7]"
        Dim CTRL As New Control
        For Each CTRL In GroupBox1.Controls
            If TypeOf CTRL Is TextBox Then
                CTRL.Text = ""
            End If
            If TypeOf CTRL Is ComboBox Then
                CTRL.Text = ""
            End If
        Next CTRL
        Cmb_postype.SelectedIndex = 0
        txt_acchg.Enabled = True
        txt_PackingPercent.Enabled = True
        txt_tips.Enabled = True
        Txt_party.Enabled = True
        Txt_prefix.ReadOnly = False
        Txt_fprefix.ReadOnly = False
        TXT_DRPREFIX.ReadOnly = False
        txt_groom.Enabled = True
        CMB_ROUND.Enabled = True
        CMB_PAYMENT.Enabled = True
        CMB_KOTENTRY.Enabled = True
        ' TXT_CENTRALIZED.Enabled = True
        CMB_DIRECT.Enabled = True
        CMB_TABLENO.Enabled = True
        CMB_SMRT.Enabled = True
        txt_ADDESC.Enabled = True
        txt_ADLIMIT.Enabled = True
        txt_PCKDESC.Enabled = True
        txt_PCKLIMIT.Enabled = True
        txt_SCKDESC.Enabled = True
        txt_SCLIMIT.Enabled = True

        Txt_prefix.Text = ""
        Txt_fprefix.Text = ""
        TXT_DRPREFIX.Text = ""
        txt_acchg.Text = "0.00"
        txt_PackingPercent.Text = "0.00"
        txt_tips.Text = "0.00"
        Txt_party.Text = "0.00"
        txt_groom.Text = "0.00"
        txt_ADDESC.Text = ""
        txt_ADLIMIT.Text = ""
        txt_PCKDESC.Text = ""
        txt_PCKLIMIT.Text = ""
        txt_SCKDESC.Text = ""
        txt_SCLIMIT.Text = ""
        If (Me.Contains(ussgrid)) Then
            ussgrid.SendToBack()
        End If
        If (Me.Contains(Lssgrid)) Then
            Lssgrid.SendToBack()
        End If
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        'Ussgrid.ClearRange(1, 1, -1, -1, True)
        USERGRID.ClearRange(1, 1, -1, -1, True)
        Lssgrid.ClearRange(1, 1, -1, -1, True)
        LBLTYPE.Visible = False
        CMB_TYPE.Visible = False
        LBLPREFIX.Visible = False
        Txt_prefix.Visible = False
        LBLFPREFIX.Visible = False
        Txt_fprefix.Visible = False
        ' LBLDRTYPE.Visible = False
        LBLDRTYP.Visible = False
        CMB_DRTYPE.Visible = False
        LBLDRPREFIX.Visible = False
        TXT_DRPREFIX.Visible = False
        CMB_RNDVAL.Visible = False
        Lblroundval.Visible = False
        cmdPOSHelp.Enabled = True
        'txtPOSCode.Focus()
        CMB_DIRECT.Enabled = True
        Cmb_postype.Focus()
        txtPOSCode.ReadOnly = False
        txtPOSCode.Enabled = True
        GRP_LOC.Visible = False
        GRP_USER.Visible = False

    End Sub
    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click

        Dim SQL(0), TTYPE, SALES As String
        Dim I As Integer
        If CmdAdd.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            vSeqNo = GetSeqno(txtPOSCode.Text)
            sqlstring = " INSERT INTO POSMASTER (Storetype,POSseqno,Poscode,PosDesc,PackingPercent,PCKDESC,PCKLIMIT,tips,SCDESC,SCLIMIT,adcharge,ADDESC,ADLIMIT,prcharge,grcharge,roundoffyesno,roundval,paymentmode,centralizedkot,"
            sqlstring = sqlstring & "kotentry,kottype,kotprefix,finalprefix,directbill,directtype,directprefix,tablerequired,smartrequired,AddUSerId,AddDateTime,freeze)"
            'salesacctin,SalesAcctdesc,PackingPercent,PackingAcctin,Packingdesc,Freeze,StoreStatus,AddUSerId,AddDateTime,under,TIPSSTATUS,tips,tipsacctin,accharge,acchargeacctin)"
            sqlstring = sqlstring & " VALUES ( '" & Trim(Cmb_postype.Text) & "'," & Val(vSeqNo) & ",'" & Trim(txtPOSCode.Text) & "','" & Replace(Trim(txtPOSDesc.Text), "'", "") & "',"

            'sqlstring = sqlstring & " ' SALES ','" & Replace(Trim(txtAcctDesc.Text), "'", "") & "',"
            'sqlstring = sqlstring & " '" & Trim(txtAcctIn.Text) & "','" & Replace(Trim(txtAcctDesc.Text), "'", "") & "',"

            sqlstring = sqlstring & " " & Format(Val(txt_PackingPercent.Text), "0.00") & ",'" & Replace(Trim(txt_PCKDESC.Text), "'", "") & "'," & Format(Val(txt_PCKLIMIT.Text), "0.00") & "," & Format(Val(txt_tips.Text), "0.00") & ",'" & Replace(Trim(txt_SCKDESC.Text), "'", "") & "'," & Format(Val(txt_SCLIMIT.Text), "0.00") & "," & Format(Val(txt_acchg.Text), "0.00") & ",'" & Replace(Trim(txt_ADDESC.Text), "'", "") & "'," & Format(Val(txt_ADLIMIT.Text), "0.00") & "," & Format(Val(Txt_party.Text), "0.00") & "," & Format(Val(txt_groom.Text), "0.00") & ","
            sqlstring = sqlstring & " '" & Trim(CMB_ROUND.Text) & "'," & Format(Val(CMB_RNDVAL.Text), "0.00") & ",'" & Trim(CMB_PAYMENT.Text) & "','" & Trim(TXT_CENTRALIZED.Text) & "',"
            sqlstring = sqlstring & " '" & Trim(CMB_KOTENTRY.Text) & "','" & Trim(CMB_TYPE.Text) & "','" & Trim(Txt_prefix.Text) & "','" & Trim(Txt_fprefix.Text) & "','" & Trim(CMB_DIRECT.Text) & "',"
            sqlstring = sqlstring & " '" & Trim(CMB_DRTYPE.Text) & "','" & Trim(TXT_DRPREFIX.Text) & "','" & Trim(CMB_TABLENO.Text) & "','" & Trim(CMB_SMRT.Text) & "',"
            'If opt_Facility.Checked = True Then
            '    sqlstring = sqlstring & " 'N','F',"
            'ElseIf opt_Store.Checked = True Then
            '    sqlstring = sqlstring & " 'N','S',"
            'ElseIf opt_KITCHEN.Checked = True Then
            '    sqlstring = sqlstring & " 'N','K',"
            'End If
            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N')"
            'If ChKTIPSYES.Checked = True Then
            ' sqlstring = sqlstring & " 'T',"
            ' ElseIf ChKTIPSNO.Checked = True Then
            ' sqlstring = sqlstring & " 'F',"
            'End If

            'sqlstring = sqlstring & " " & Val(Me.txt_tips.Text) & ",'" & Me.txt_tipsacctin.Text & "'," & Val(Me.txt_acchg.Text) & ",'" & Me.txt_acchgin.Text & "')"


            ReDim Preserve SQL(SQL.Length)
            SQL(SQL.Length - 1) = sqlstring

            '   gconnection.dataOperation(1, sqlstring, "POSMASTER")
            ' Me.CmdClear_Click(sender, e)
        ElseIf CmdAdd.Text = "Update[F7]" Then
            Call checkValidation()
            '''--->Check Validation            ''' 
            If boolchk = False Then Exit Sub
            If Mid(Me.CmdAdd.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK)
                    boolchk = False
                    Exit Sub
                End If
            End If
           

            sqlstring = "UPDATE  POSMASTER "
            sqlstring = sqlstring & " SET POSdesc='" & Replace(Trim(txtPOSDesc.Text), "'", "") & "',"
            sqlstring = sqlstring & " Storetype='" & Trim(Cmb_postype.Text) & "',"
            'sqlstring = sqlstring & " SalesAcctin=' SALES',SalesAcctdesc='" & Replace(Trim(txtAcctDesc.Text), "'", "") & "',"
            sqlstring = sqlstring & " PackingPercent = " & Format(Val(txt_PackingPercent.Text), "0.00") & ",tips=" & Format(Val(txt_tips.Text), "0.00") & ",adcharge=" & Format(Val(txt_acchg.Text), "0.00") & ",prcharge=" & Format(Val(Txt_party.Text), "0.00") & ",grcharge=" & Format(Val(txt_groom.Text), "0.00") & ",roundoffyesno='" & Trim(CMB_ROUND.Text) & "',"
            sqlstring = sqlstring & " PCKDESC='" & Trim(txt_PCKDESC.Text) & "',PCKLIMIT = " & Format(Val(txt_PCKLIMIT.Text), "0.00") & ","
            sqlstring = sqlstring & " SCDESC='" & Trim(txt_SCKDESC.Text) & "',SCLIMIT = " & Format(Val(txt_SCLIMIT.Text), "0.00") & ","
            sqlstring = sqlstring & " ADDESC='" & Trim(txt_ADDESC.Text) & "',ADLIMIT = " & Format(Val(txt_ADLIMIT.Text), "0.00") & ","
            sqlstring = sqlstring & "roundval=" & Format(Val(CMB_RNDVAL.Text), "0.00") & ",paymentmode='" & Trim(CMB_PAYMENT.Text) & "',centralizedkot='" & Trim(TXT_CENTRALIZED.Text) & "',"
            sqlstring = sqlstring & " KOTEntry='" & Trim(CMB_KOTENTRY.Text) & "', kottype='" & Trim(CMB_TYPE.Text) & "', kotprefix='" & Trim(Txt_prefix.Text) & "', finalprefix='" & Trim(Txt_fprefix.Text) & "', directbill='" & Trim(CMB_DIRECT.Text) & "',"
            sqlstring = sqlstring & " directtype='" & Trim(CMB_DRTYPE.Text) & "', directprefix='" & Trim(TXT_DRPREFIX.Text) & "', tablerequired='" & Trim(CMB_TABLENO.Text) & "', smartrequired='" & Trim(CMB_SMRT.Text) & "',"
            ' PackingAcctin='" & Trim(txtPackingAcctin.Text) & "',Packingdesc='" & Replace(Trim(txtPackingAcctdesc.Text), "'", "") & "',"
            sqlstring = sqlstring & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',Freeze='N'"
            
            sqlstring = sqlstring & " WHERE Poscode = '" & Trim(txtPOSCode.Text) & "'"

            ReDim Preserve SQL(SQL.Length)
            SQL(SQL.Length - 1) = sqlstring
            CmdAdd.Text = "Add [F7]"

        End If

        sqlstring = "DELETE FROM  POS_USERCONTROL WHERE POSCODE='" & Trim(txtPOSCode.Text) & "'"

        ReDim Preserve SQL(SQL.Length)
        SQL(SQL.Length - 1) = sqlstring

        With USERGRID
            For I = 0 To USERGRID.DataRowCnt - 1
                .Row = I + 1
                .Col = 1
                TTYPE = .Text

                sqlstring = "INSERT INTO POS_USERCONTROL (POSCODE,USERNAME,ADDUSER,ADDDATE)"
                sqlstring = sqlstring & " VALUES ('" & Trim(txtPOSCode.Text) & "','" & Trim(TTYPE) & "','" & gUsername & "','" & Format(Now(), "dd/MMM/yyyy HH:mm:ss") & "')"

                ReDim Preserve SQL(SQL.Length)
                SQL(SQL.Length - 1) = sqlstring

            Next I
        End With

        sqlstring = "DELETE FROM  POS_LOCATIONCONTROL WHERE POSCODE='" & Trim(txtPOSCode.Text) & "'"

        ReDim Preserve SQL(SQL.Length)
        SQL(SQL.Length - 1) = sqlstring

        With Lssgrid
            For I = 0 To Lssgrid.DataRowCnt - 1
                .Row = I + 1
                .Col = 1
                TTYPE = .Text

                sqlstring = "INSERT INTO POS_LOCATIONCONTROL (POSCODE,locationNAME,ADDUSER,ADDDATE)"
                sqlstring = sqlstring & " VALUES ('" & Trim(txtPOSCode.Text) & "','" & Trim(TTYPE) & "','" & gUsername & "','" & Format(Now(), "dd/MMM/yyyy HH:mm:ss") & "')"

                ReDim Preserve SQL(SQL.Length)
                SQL(SQL.Length - 1) = sqlstring

            Next I
        End With
        gconnection.MoreTransold(SQL)
        Me.CmdClear_Click(sender, e)


    End Sub
    Public Sub checkValidation()
        boolchk = False
        ''********** Check  POS CODE Can't be blank *********************'''
        If Trim(txtPOSCode.Text) = "" Then
            MessageBox.Show("POS Code Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPOSCode.Focus()
            Exit Sub
        End If
        ''********** Check  POS DESC Can't be blank *********************'''
        If Trim(txtPOSDesc.Text) = "" Then
            MessageBox.Show("POS Description Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPOSDesc.Focus()
            Exit Sub
        End If
        ''********** Check  ACCOUNT IN Can't be blank *********************'''
        'If Trim(Me.txtAcctIn.Text) = "" And Trim(Me.txtAcctDesc.Text) = "" Then
        '    MessageBox.Show("Account In Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Me.txtAcctIn.Text = ""
        '    Me.txtAcctDesc.Text = ""
        '    Me.txtAcctIn.Focus()
        '    Exit Sub
        'End If
        boolchk = True
    End Sub

    Private Sub txtPOSCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPOSCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdPOSHelp.Enabled = True Then
                Search = Trim(txtPOSCode.Text)
                Call cmdPOSHelp_Click(txtPOSCode, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If cmdPOSHelp.Enabled = True Then
                txtPOSDesc.Focus()
            End If
        End If
        If e.KeyCode = Keys.Tab Then
            If cmdPOSHelp.Enabled = True Then
                txtPOSDesc.Focus()
            End If
        End If
    End Sub
    Private Sub POSMaster_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        POSMastbool = False
    End Sub
    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim STATUS As Integer
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  POSMASTER "
                sqlstring = sqlstring & " SET Freeze= 'Y',voiduser='" & gUsername & " ', voiddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE POSCode = '" & Trim(CStr(txtPOSCode.Text)) & "'"
                gconnection.dataOperation(3, sqlstring, "POSMASTER")
                Me.CmdClear_Click(sender, e)
                CmdAdd.Text = "Add [F7]"
            Else
                Exit Sub
            End If

            'Else
            '    STATUS = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            '    If STATUS = 1 Then
            '        sqlstring = "UPDATE  POSMASTER "
            '        sqlstring = sqlstring & " SET Freeze= 'N',AddUSerId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        sqlstring = sqlstring & " WHERE POSCode = '" & Trim(CStr(txtPOSCode.Text)) & "'"
            '        gconnection.dataOperation(4, sqlstring, "POSMASTER")
            '        Me.CmdClear_Click(sender, e)
            '        CmdAdd.Text = "Add [F7]"
            '    Else
            '        Exit Sub
            '    End If
        End If
    End Sub

    Private Sub txt_PackingPercent_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_PackingPercent.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_PCKDESC.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_PCKDESC.Focus()
        End If
    End Sub
   

    'Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
    '    Dim sqlstring As String
    '    Dim _export As New EXPORT
    '    _export.TABLENAME = "posmaster"
    '    sqlstring = "select * from posmaster order by poscode"
    '    Call _export.export_excel(sqlstring)
    '    _export.Show()
    '    Exit Sub
    'End Sub
    'Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
    '    'GroupBox3.Visible = True

    '    Dim sqlstring, SSQL As String
    '    Dim Viewer As New ReportViwer
    '    Dim r As New Crptposmaster
    '    Dim POSdesc(), MemberCode() As String
    '    Dim SQLSTRING2 As String
    '    sqlstring = "select * from posmaster order by poscode"

    '    Call Viewer.GetDetails(sqlstring, "posmaster", r)
    '    Viewer.TableName = "posmaster"
    '    Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ5 = r.ReportDefinition.ReportObjects("Text2")
    '    TXTOBJ5.Text = gCompanyname

    '    Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ1 = r.ReportDefinition.ReportObjects("Text3")
    '    TXTOBJ1.Text = "UserName : " & gUsername

    '    Viewer.Show()
    'End Sub
    Private Sub fillTrans()
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT USERNAME,''AS ID FROM POS_VIEW_USERADMIN"
            M_WhereCondition = " "
            vform.Field = "USERNAME,ID"
            ' vform.Frmcalled = "  USERNAME  | ID        |                                  "
            vform.vCaption = "USER NAME HELP"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                'txtPOSCode.Text = Trim(vform.keyfield & "")
                'txtPOSCode.Select()
                'txtPOSCode_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
                With USERGRID
                    .Col = 1
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield)
                    .SetActiveCell(1, .ActiveRow + 1)
                    .Focus()
                End With
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
      
    End Sub
    Private Sub filllocation()
        Try
            Dim sqlstring As String
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT LOCATIONCODE,locationname  FROM locationmaster "
            M_WhereCondition = " "
            vform.Field = "LOCATIONCODE,locationname"
            ' vform.Frmcalled = "  LOCATIONCODE  | locationname        |                                  "
            vform.vCaption = "LOCATION HELP"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                'txtPOSCode.Text = Trim(vform.keyfield & "")
                'txtPOSCode.Select()
                'txtPOSCode_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
                With Lssgrid
                    .Col = 1
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield1)
                    .SetActiveCell(1, .ActiveRow + 1)
                    .Focus()
                End With
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub
   
    Private Sub Lssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles Lssgrid.KeyDownEvent
        Dim I As Integer
        Dim DEPT, TRANS As String
        Dim DOB As Date
        With Lssgrid
            If e.keyCode = Keys.Enter Then
                I = .ActiveRow
                If .ActiveCol = 1 Then
                    .Row = I
                    .Col = 1
                    If Trim(.Text) = "" Then
                        Call filllocation()
                    Else
                        sqlstring = "SELECT ISNULL(LOCATIONNAME,'') AS LOCATIONNAME FROM POS_VIEW_LOCATION"
                        sqlstring = sqlstring & " WHERE LOCATIONNAME="
                        .Col = 1
                        .Row = I
                        TRANS = .Text
                        sqlstring = sqlstring & " '" & TRANS & "'"
                        gconnection.getDataSet(sqlstring, "TRANS")
                        If gdataset.Tables("TRANS").Rows.Count > 0 Then
                            .Col = 1
                            .Row = I
                            .Text = gdataset.Tables("TRANS").Rows(0).Item("LOCATIONNAME")

                            .SetActiveCell(1, I + 1)
                        Else
                            MsgBox("NO SUCH ITEM FOUND")
                            .Text = ""
                            .SetActiveCell(1, I)
                        End If
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                .DeleteRows(.ActiveRow, 1)
                .SetActiveCell(1, I)
                .Focus()
            End If
            If e.keyCode = Keys.Tab Then
                CmdAdd.Focus()
            End If
        End With
    End Sub


    Private Sub CMB_TYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_TYPE.SelectedIndexChanged
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
            ' Txt_prefix.Text = ""
            LBLFPREFIX.Visible = False
            Txt_fprefix.Visible = False
            'Txt_fprefix.Text = ""
        End If
    End Sub

    Private Sub txt_tips_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_tips.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_SCKDESC.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_SCKDESC.Focus()
        End If
    End Sub

    Private Sub txtPOSDesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPOSDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_PackingPercent.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_PackingPercent.Focus()
        End If
    End Sub
   

    Private Sub txt_acchg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_acchg.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_ADDESC.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_ADDESC.Focus()
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
                CMB_TABLENO.Focus()
            End If
        End If
    End Sub

    Private Sub CMB_RNDVAL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMB_RNDVAL.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            CMB_TABLENO.Focus()
        End If
    End Sub

    Private Sub CMB_PAYMENT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMB_PAYMENT.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'If Cmb_postype.Text = "FACILITY" Then
            '    CMB_DIRECT.Focus()
            'Else
            CMB_ROUND.Focus()
            ' End If
        End If
    End Sub

    Private Sub TXT_CENTRALIZED_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_CENTRALIZED.SelectedIndexChanged
        If TXT_CENTRALIZED.Text = "YES" Then
            LBLTYPE.Visible = True
            CMB_TYPE.Visible = True
            CMB_KOTENTRY.Enabled = False
            CMB_DIRECT.Enabled = False
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
            CMB_KOTENTRY.Enabled = True
            CMB_DIRECT.Enabled = True
            'CMB_KOTENTRY.Focus()
        End If
    End Sub

    Private Sub TXT_CENTRALIZED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_CENTRALIZED.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If TXT_CENTRALIZED.Text = "YES" Then
                CMB_TYPE.Focus()
            Else
                CMB_KOTENTRY.Focus()
            End If
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
            If TXT_CENTRALIZED.Text = "YES" Then
                CMB_TABLENO.Focus()
            ElseIf CMB_KOTENTRY.Text = "YES" Then
                CMB_DIRECT.Focus()
            Else
                CMB_TABLENO.Focus()
            End If
        End If
    End Sub

    Private Sub CMB_KOTENTRY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_KOTENTRY.SelectedIndexChanged
        If CMB_KOTENTRY.Text = "YES" Then
            LBLTYPE.Visible = True
            CMB_TYPE.Visible = True
            CMB_DIRECT.Enabled = True
            'CMB_TYPE.Focus()
            If CMB_TYPE.Text = "AUTO" Then
                LBLPREFIX.Visible = True
                Txt_prefix.Visible = True
                LBLFPREFIX.Visible = True
                Txt_fprefix.Visible = True
            Else
                LBLPREFIX.Visible = False
                Txt_prefix.Visible = False
                LBLFPREFIX.Visible = False
                Txt_fprefix.Visible = False
                'CMB_DIRECT.Focus()
            End If
        Else
            LBLTYPE.Visible = False
            CMB_TYPE.Visible = False
            LBLPREFIX.Visible = False
            Txt_prefix.Visible = False
            LBLFPREFIX.Visible = False
            Txt_fprefix.Visible = False
            'CMB_DIRECT.Focus()
            CMB_DIRECT.Text = "YES"
            CMB_DIRECT.Enabled = False
            LBLDRTYP.Visible = True
            CMB_DRTYPE.Visible = True
            'CMB_DRTYPE.Focus()
            'CMB_DIRECT.Focus()
            'If CMB_TYPE.Text = "AUTO" Then
            '    LBLDRPREFIX.Visible = True
            '    TXT_DRPREFIX.Visible = True
            'Else
            '    CMB_TABLENO.Focus()
            'End If

        End If
    End Sub

    Private Sub CMB_DIRECT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMB_DIRECT.KeyPress
        If CMB_DIRECT.Text = "YES" Then
            CMB_DRTYPE.Focus()
           
        Else
           
                CMB_PAYMENT.Focus()

            End If
    End Sub

    Private Sub Txt_prefix_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_prefix.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TXT_CENTRALIZED.Text = "YES" Or CMB_KOTENTRY.Text = "YES" Then
                Txt_fprefix.Focus()
            Else
                CMB_PAYMENT.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_fprefix_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_fprefix.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TXT_CENTRALIZED.Text = "YES" Then
                CMB_PAYMENT.Focus()
            Else
                If CMB_KOTENTRY.Text = "YES" Then
                    CMB_DIRECT.Focus()
                Else
                    CMB_PAYMENT.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub CMB_DIRECT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_DIRECT.SelectedIndexChanged
        If CMB_DIRECT.Text = "YES" Then
            If CMB_KOTENTRY.Text = "NO" Then
                LBLTYPE.Visible = False
                CMB_TYPE.Visible = False
                LBLPREFIX.Visible = False
                Txt_prefix.Visible = False
                LBLFPREFIX.Visible = False
                Txt_fprefix.Visible = False
            End If
            CMB_DRTYPE.Visible = True
            LBLDRTYP.Visible = True
            'CMB_TYPE.Focus()
        Else
            LBLDRTYP.Visible = False
            CMB_DRTYPE.Visible = False
            'LBLTYPE.Visible = False
            'CMB_TYPE.Visible = False
            'CMB_TABLENO.Focus()
        End If
    End Sub

    Private Sub CMB_KOTENTRY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMB_KOTENTRY.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If CMB_KOTENTRY.Text = "YES" Then
                CMB_TYPE.Focus()
            Else
                CMB_DRTYPE.Focus()
            End If
        End If
    End Sub

    Private Sub TXT_DRPREFIX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_DRPREFIX.TextChanged
       
    End Sub

    'Private Sub TXT_DRPREFIX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_DRPREFIX.KeyPress
    '    getNumeric(e)
    '    If Asc(e.KeyChar) = 13 Then
    '        CMB_TABLENO.Focus()
    '    End If
    'End Sub

    Private Sub LBLFPREFIX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLFPREFIX.Click

    End Sub
    Private Sub CMB_TABLENO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMB_TABLENO.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            CMB_SMRT.Focus()
        End If
    End Sub
    Private Sub CMB_DRTYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_DRTYPE.SelectedIndexChanged
        If CMB_DRTYPE.Text = "AUTO" Then
            LBLDRPREFIX.Visible = True
            TXT_DRPREFIX.Visible = True
        Else
            LBLDRPREFIX.Visible = False
            TXT_DRPREFIX.Visible = False
            ' TXT_DRPREFIX.Text = ""
        End If
    End Sub
    Private Sub CMB_DRTYPE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMB_DRTYPE.KeyPress
        If CMB_DRTYPE.Text = "AUTO" Then
            TXT_DRPREFIX.Focus()
        Else
            CMB_PAYMENT.Focus()
        End If
    End Sub
    Private Sub TXT_DRPREFIX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_DRPREFIX.KeyPress
        'getNumeric(e)

        If Asc(e.KeyChar) = 13 Then
            CMB_PAYMENT.Focus()
        End If
    End Sub

    Private Sub Cmb_postype_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmb_postype.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPOSCode.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txtPOSCode.Focus()
        End If
    End Sub

  

    
    Private Sub Cmb_postype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_postype.SelectedIndexChanged
        Dim ctrl As New Control
        If Cmb_postype.Text = "FACILITY" Then
            'For Each ctrl In GroupBox1.Controls
            '    If TypeOf ctrl Is TextBox Then
            '        'ctrl.Text = ""
            '        ctrl.Enabled = True

            '    End If
            '    If TypeOf ctrl Is ComboBox Then
            '        'ctrl.Text = ""
            '        ctrl.Enabled = True
            '    End If
            'Next ctrl
            TXT_CENTRALIZED.Enabled = False
            CMB_KOTENTRY.Enabled = False
            txt_acchg.Enabled = True
            txt_PackingPercent.Enabled = True
            txt_tips.Enabled = True
            Txt_party.Enabled = True
            txt_groom.Enabled = True
            CMB_ROUND.Enabled = True
            CMB_PAYMENT.Enabled = True
            'CMB_KOTENTRY.Enabled = True
            'TXT_CENTRALIZED.Enabled = True
            CMB_DIRECT.Enabled = True
            CMB_TABLENO.Enabled = True
            CMB_SMRT.Enabled = True
            txt_ADDESC.Enabled = True
            txt_ADLIMIT.Enabled = True
            txt_PCKDESC.Enabled = True
            txt_PCKLIMIT.Enabled = True
            txt_SCKDESC.Enabled = True
            txt_SCLIMIT.Enabled = True

        ElseIf Cmb_postype.Text = "POS" Then
            'TXT_CENTRALIZED.Enabled = True
            sqlstring = " SELECT  isnull(centralizedkot,'') as centralizedkot  FROM possetup  "
            vconn.getDataSet(sqlstring, "possetup")
            If gdataset.Tables("possetup").Rows(0).Item("centralizedkot") = "YES" Then
                TXT_CENTRALIZED.Enabled = False
            Else
                TXT_CENTRALIZED.Enabled = True
            End If
            CMB_KOTENTRY.Enabled = True
            'For Each ctrl In GroupBox1.Controls
            '    If TypeOf ctrl Is TextBox Then
            '        'ctrl.Text = ""
            '        ctrl.Enabled = True

            '    End If
            '    If TypeOf ctrl Is ComboBox Then
            '        'ctrl.Text = ""
            '        ctrl.Enabled = True
            '    End If
            'Next ctrl
            txt_acchg.Enabled = True
            txt_PackingPercent.Enabled = True
            txt_tips.Enabled = True
            Txt_party.Enabled = True
            txt_groom.Enabled = True
            CMB_ROUND.Enabled = True
            CMB_PAYMENT.Enabled = True
            ' CMB_KOTENTRY.Enabled = True
            ' TXT_CENTRALIZED.Enabled = True
            CMB_DIRECT.Enabled = True
            CMB_TABLENO.Enabled = True
            CMB_SMRT.Enabled = True
            txt_ADDESC.Enabled = True
            txt_ADLIMIT.Enabled = True
            txt_PCKDESC.Enabled = True
            txt_PCKLIMIT.Enabled = True
            txt_SCKDESC.Enabled = True
            txt_SCLIMIT.Enabled = True
          
        Else
            txt_acchg.Enabled = False
            txt_PackingPercent.Enabled = False
            txt_tips.Enabled = False
            Txt_party.Enabled = False
            txt_groom.Enabled = False
            CMB_ROUND.Enabled = False
            CMB_PAYMENT.Enabled = False
            CMB_KOTENTRY.Enabled = False
            TXT_CENTRALIZED.Enabled = False
            CMB_DIRECT.Enabled = False
            CMB_TABLENO.Enabled = False
            CMB_SMRT.Enabled = False
            txt_ADDESC.Enabled = False
            txt_ADLIMIT.Enabled = False
            txt_PCKDESC.Enabled = False
            txt_PCKLIMIT.Enabled = False
            txt_SCKDESC.Enabled = False
            txt_SCLIMIT.Enabled = False


            'For Each ctrl In GroupBox1.Controls
            '    If TypeOf ctrl Is TextBox Then
            '        'ctrl.Text = ""
            '        ctrl.Enabled = False

            '    End If
            '    If TypeOf ctrl Is ComboBox Then
            '        'ctrl.Text = ""
            '        ctrl.Enabled = False
            '    End If
            'Next ctrl
            Cmb_postype.Enabled = True
            txtPOSCode.Enabled = True
            txtPOSDesc.Enabled = True
            txtPOSCode.Focus()
        End If
    End Sub


    Private Sub USERGRID_KeyDownEvent1(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles USERGRID.KeyDownEvent
        Dim I As Integer
        Dim DEPT, TRANS As String
        Dim DOB As Date
        With USERGRID
            If e.keyCode = Keys.Enter Then
                I = .ActiveRow
                If .ActiveCol = 1 Then
                    .Row = I
                    .Col = 1
                    If Trim(.Text) = "" Then
                        Call fillTrans()
                    Else
                        sqlstring = "SELECT ISNULL(USERNAME,'') AS USERNAME FROM POS_VIEW_USERADMIN"
                        sqlstring = sqlstring & " WHERE USERNAME="
                        .Col = 1
                        .Row = I
                        TRANS = .Text
                        sqlstring = sqlstring & " '" & TRANS & "'"
                        gconnection.getDataSet(sqlstring, "TRANS")
                        If gdataset.Tables("TRANS").Rows.Count > 0 Then
                            .Col = 1
                            .Row = I
                            .Text = gdataset.Tables("TRANS").Rows(0).Item("USERNAME")

                            .SetActiveCell(1, I + 1)
                        Else
                            MsgBox("NO SUCH ITEM FOUND")
                            .Text = ""
                            .SetActiveCell(1, I)
                        End If
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                .DeleteRows(.ActiveRow, 1)
                .SetActiveCell(1, I)
                .Focus()
            End If
            If e.keyCode = Keys.Tab Then
                '.SetActiveCell(1, I)
                CMD_LOCATION.Focus()
            End If
        End With
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

    Private Sub txt_SCKDESC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_SCKDESC.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_SCLIMIT.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_SCLIMIT.Focus()
        End If
    End Sub

    Private Sub txt_SCLIMIT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_SCLIMIT.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_acchg.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_acchg.Focus()
        End If
    End Sub

    Private Sub txt_ADDESC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ADDESC.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_ADLIMIT.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_ADLIMIT.Focus()
        End If
    End Sub

    Private Sub txt_ADLIMIT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ADLIMIT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt_party.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            Txt_party.Focus()
        End If
    End Sub

    Private Sub Txt_party_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_party.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_groom.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_groom.Focus()
        End If
    End Sub

    Private Sub txt_groom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_groom.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Mid(Cmb_postype.Text, 1, 3) = "FAC" Then

                CMB_DIRECT.Focus()
            Else
                If TXT_CENTRALIZED.Enabled = False Then
                    TXT_CENTRALIZED.Text = "NO"
                    CMB_KOTENTRY.Focus()
                Else
                    TXT_CENTRALIZED.Focus()
                End If
            End If
        End If
        If e.KeyCode = Keys.Tab Then
            If Mid(Cmb_postype.Text, 1, 3) = "FAC" Then
                CMB_DIRECT.Focus()
            Else
                If TXT_CENTRALIZED.Enabled = False Then
                    TXT_CENTRALIZED.Text = "NO"
                    CMB_KOTENTRY.Focus()
                Else
                    TXT_CENTRALIZED.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Dim FRM As New ReportDesigner
        If txtPOSCode.Text.Length > 0 Then
            tables = " FROM POSMASTER WHERE POSCODE ='" & txtPOSCode.Text & "' "
        Else
            tables = "FROM POSMASTER "
        End If
        Gheader = "POS DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"POSCODE", "5"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"POSDESC", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"MNAME", "20"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"PACKINGPERCENT", "4"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"TIPS", "5"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADCHARGE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CENTRALIZEDKOT", "12"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"KOTENTRY", "4"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"DIRECTBILL", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"PAYMENTMODE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"directprefix", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"roundval", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FREEZE", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSERID", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDDATETIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATETIME", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"Waitinglist", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"Freeze", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub txt_PackingPercent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_PackingPercent.KeyPress

        'If e.KeyChar <> ChrW(Keys.Back) Then
        '    If Char.IsNumber(e.KeyChar) Then
        '    Else
        '        e.Handled = True
        '        'MsgBox(" Numbers only ")
        '    End If
        'End If
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

    Private Sub txt_groom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_groom.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'for ne decimal point
        If (e.KeyChar = "."c AndAlso (txt_groom).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txt_ADLIMIT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ADLIMIT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
                'MsgBox(" Numbers only ")
            End If
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

    Private Sub txt_SCLIMIT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_SCLIMIT.KeyPress
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

    Private Sub txt_tips_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_tips.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'for ne decimal point
        If (e.KeyChar = "."c AndAlso (txt_tips).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPOSDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOSDesc.TextChanged
        If (System.Text.RegularExpressions.Regex.IsMatch("^[a-zA-Z]", txtPOSDesc.Text)) Then

            ' MessageBox.Show("This textbox accepts only alphabetical characters")
            ' txt_FirstName.Text.Remove(txt_FirstName.Text.Length - 1)
        End If
    End Sub

    Private Sub CMD_BRSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_BRSE.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM POSMASTER"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM POSMASTER", "SERIALNO", 0)

    End Sub

    Private Sub AUTHORISE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AUTHORISE.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM POSMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM POSMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
                    gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                    If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                        Dim VIEW1 As New AUTHORISATION
                        VIEW1.Show()
                        VIEW1.DTAUTH.DataSource = Nothing
                        VIEW1.DTAUTH.Rows.Clear()
                        'Dim STRQUERY As String
                        'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                        ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                        'gconnection.getDataSet(STRQUERY, "authorize")

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE POSMASTER set  ", "POSCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM POSMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM POSMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            'Dim STRQUERY As String
                            'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                            ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                            'gconnection.getDataSet(STRQUERY, "authorize")

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE POSMASTER set  ", "POSCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM POSMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM POSMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE POSMASTER set  ", "POSCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If

    End Sub

    Private Sub txt_PackingPercent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_PackingPercent.TextChanged

    End Sub

    Private Sub CMD_USER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMD_USER.KeyDown
        If e.KeyCode = Keys.Enter Then
            CMD_LOCATION.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            USERGRID.Focus()
        End If

    End Sub

    Private Sub Lssgrid_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles Lssgrid.Advance

    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New Crptposmaster
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = "select * from posmaster order by poscode"

        Call Viewer.GetDetails(sqlstring, "posmaster", r)
        Viewer.TableName = "posmaster"
        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text2")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ1.Text = "UserName : " & gUsername

        Viewer.Show()
    End Sub

    Private Sub CMB_SMRT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMB_SMRT.KeyDown
        If e.KeyCode = Keys.Enter Then
            CMD_USER.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CMD_USER.Focus()
        End If
    End Sub

    Private Sub CMB_SMRT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_SMRT.SelectedIndexChanged

    End Sub

    Private Sub CMD_LOCATION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMD_LOCATION.KeyDown
        If e.KeyCode = Keys.Enter Then
            Lssgrid.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            Lssgrid.Focus()
        End If
    End Sub

    Private Sub Txt_prefix_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_prefix.TextChanged
     
    End Sub

    Private Sub Txt_prefix_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_prefix.Validated
        If Txt_prefix.Text = TXT_DRPREFIX.Text Then
            MsgBox("This prefix has been used in DIRECT prefix")
            Txt_prefix.Text = ""
        ElseIf Txt_prefix.Text = Txt_fprefix.Text Then
            MsgBox("This prefix has been used in final prefix")
            Txt_prefix.Text = ""
        End If

        Dim SSQLSTR2 As String
        SSQLSTR2 = " SELECT ISNULL(KOTPREFIX,'') AS KOTPREFIX FROM POSMASTER  WHERE ISNULL(KOTPREFIX,'')='" & Txt_prefix.Text & " '"
        SSQLSTR2 = SSQLSTR2 & " and ISNULL(finalprefix,'')='" & Txt_prefix.Text & "' and ISNULL(directprefix,'')='" & Txt_prefix.Text & " '"
        gconnection.getDataSet(SSQLSTR2, "kotprefix")
        'for gdataset.Tables("kotprefix").Rows.Count - 1 Then
        If gdataset.Tables("kotprefix").Rows.Count > 0 Then
            MsgBox("This  Prefix Already Exits")
            Txt_prefix.Text = ""
        End If

       
    End Sub

    Private Sub Txt_fprefix_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_fprefix.TextChanged
      
    End Sub

    Private Sub Txt_fprefix_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_fprefix.Validated

        If Txt_fprefix.Text = TXT_DRPREFIX.Text Then
            MsgBox("This prefix has been used in DIRECT prefix")
            Txt_fprefix.Text = ""
        ElseIf Txt_fprefix.Text = Txt_prefix.Text Then
            MsgBox("This prefix has been used in KOT prefix")
            Txt_fprefix.Text = ""
        End If

        Dim SSQLSTR2 As String
        SSQLSTR2 = " SELECT ISNULL(finalprefix,'') AS finalprefix FROM POSMASTER  WHERE ISNULL(finalprefix,'')='" & Txt_fprefix.Text & "'"
        SSQLSTR2 = SSQLSTR2 & " and ISNULL(KOTPREFIX,'')='" & Txt_fprefix.Text & "' and ISNULL(directprefix,'')='" & Txt_fprefix.Text & "'"
        gconnection.getDataSet(SSQLSTR2, "fprefix")
        'for gdataset.Tables("kotprefix").Rows.Count - 1 Then
        If gdataset.Tables("fprefix").Rows.Count > 0 Then
            MsgBox("This  Prefix Already Exits")
            Txt_fprefix.Text = ""
        End If
    End Sub

    Private Sub TXT_DRPREFIX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_DRPREFIX.Validated
        If TXT_DRPREFIX.Text = Txt_prefix.Text Then
            MsgBox("This prefix has been used in kot prefix")
            TXT_DRPREFIX.Text = ""
        ElseIf TXT_DRPREFIX.Text = Txt_fprefix.Text Then
            MsgBox("This prefix has been used in final prefix")
            TXT_DRPREFIX.Text = ""
        End If

        Dim SSQLSTR2 As String
        SSQLSTR2 = " SELECT ISNULL(directprefix,'') AS directprefix FROM POSMASTER  WHERE ISNULL(directprefix,'')='" & TXT_DRPREFIX.Text & "'"
        SSQLSTR2 = SSQLSTR2 & " and ISNULL(KOTPREFIX,'')='" & TXT_DRPREFIX.Text & "' and ISNULL(finalprefix,'')='" & TXT_DRPREFIX.Text & "'"
        gconnection.getDataSet(SSQLSTR2, "dprefix")
        'for gdataset.Tables("kotprefix").Rows.Count - 1 Then
        If gdataset.Tables("dprefix").Rows.Count > 0 Then
            MsgBox("This  Prefix Already Exits")
            TXT_DRPREFIX.Text = ""
        End If
    End Sub

   
End Class