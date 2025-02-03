Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.IO
Public Class FRM_MKGA_ItemMaster
    Inherits System.Windows.Forms.Form
    Dim ssql, vPromUOM As String
    Dim vconn As New GlobalClass
    Dim GCONNECTION As New GlobalClass
    Dim promtbool As Boolean
    'Dim vseqno As Double
    Dim vseqno As String
    ' Friend WithEvents CHK_MRPTAG As System.Windows.Forms.CheckBox
    Dim i As Integer

    Private Sub FRM_MKGA_ItemMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            ' If FraPromt.Visible = False Then
            Call CmdClear_Click(CmdClear, e)
            'End If
        End If
        'If e.KeyCode = Keys.F10 Then
        '    Call cmdOk_Click(sender, e)
        'End If
        'If e.KeyCode = Keys.F2 Then
        '    Call btnPromotDelete_Click(sender, e)
        'End If
        'If e.KeyCode = Keys.F12 Then
        '    Call cmdCancel_Click(sender, e)
        'End If
        'If e.KeyCode = Keys.F7 Then
        '    If FraPromt.Visible = False Then
        '        Call CmdAdd_Click(CmdAdd, e)
        '    End If
        'End If
        'If e.KeyCode = Keys.F8 Then
        '    If FraPromt.Visible = False Then
        '        Call Cmd_Freeze_Click(Cmd_Freeze, e)
        '    End If
        'End If
        'If e.KeyCode = Keys.F9 Then
        '    Call CmdView_Click(CmdView, e)
        'End If
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
            ' If Cmd_Delete.Enabled = True Then
            Call Cmdview_Click_1(Cmdview, e)
            Exit Sub
            'End If
        End If

        'If e.KeyCode = Keys.F10 Then
        '    If cmdexport.Enabled = True Then
        '        Call CmdView_Click(cmdexport, e)
        '        Exit Sub
        '    End If
        'End If

        'If e.KeyCode = Keys.F12 Then
        '    If cmdreport.Enabled = True Then
        '        Call cmdreport_Click(cmdreport, e)
        '        Exit Sub
        '    End If
        'End If


        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then

            Me.Close()
            'End If
        End If
    End Sub
    Private Sub FRM_MKGA_ItemMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' cbo_BaseUOM.DropDownStyle = ComboBoxStyle.DropDownList
        txtItemCode.Select()
        itemmasterbool = True
        optYes.Checked = True
        FraGrid.Visible = True
        FraRate.Visible = False
        'FraPromt.Visible = Fals
        'ChkPROMOT.Checked = False


        ChkOPENITEMFACILITY.Checked = False
        'txtBaseUOM.BackColor = Color.White
        txtItemType.ReadOnly = False
        txtItemCode.ReadOnly = False
        txtGroupcode.ReadOnly = False
        cmdItemHelp.Enabled = True
        CBO_CATEGORY.Enabled = False
        'dtp_WEFdate.Value = Format(gFinancialyearStart, "dd/MM/yyyy")
        If gCompanyname = "CHORD ROAD CLUB" Then
            Txt_subcode.Visible = False
            CMDSUBCODE.Visible = False
            'sub_gdesc.Visible = False
            TXT_SUBDESC.Visible = False
        Else
            Txt_subcode.Visible = True
            CMDSUBCODE.Visible = True
            ' sub_gdesc.Visible = True
            TXT_SUBDESC.Visible = True
        End If

        'If gCompanyname = "THE TNCA CLUB" Then
        '    Txt_subcode.Visible = False
        '    CMDSUBCODE.Visible = False
        '    sub_gdesc.Visible = False
        '    TXT_SUBDESC.Visible = False
        'End If
        ' Call max()
        txt_mrprate.Text = 0.0
        CHK_MRPTAG.Checked = False
        CHKFBNO.Checked = False
        CHKFBYES.Checked = False
        CHKLOCNO.Checked = False
        CHKLOCYES.Checked = False
        txtItemDesc.Text = ""
        'txt_mrprate.V()
        Call FillPOS() ''--> Fill All POS Location
        Call FillUOM() '' --> Fill All UOM 
        Call FillCategory()
        'FraPromt.Top = 1000
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        If Mid(CmdAdd.Text, 1, 1) = "U" Then
            Call GRIDLOCK()
            'FraGrid.Enabled = True
        Else
            'FraGrid.Enabled = False
            'ssgrid.SetActiveCell(1, 1)
        End If
        txtItemCode.Select()
    End Sub
    Private Sub FillCategory()
        Try
            Dim i As Integer
            SQLSTRING = " SELECT DISTINCT Category FROM groupmaster WHERE FREEZE <> 'Y' ORDER BY Category ASC"
            vconn.getDataSet(SQLSTRING, "groupmaster")
            CBO_CATEGORY.Items.Clear()
            CBO_CATEGORY.Sorted = True
            If gdataset.Tables("groupmaster").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("groupmaster").Rows.Count - 1
                    CBO_CATEGORY.Items.Add(gdataset.Tables("groupmaster").Rows(i).Item("Category"))
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub GRIDLOCK()
        Dim Row, Col As Integer
        ssGrid.Col = 4
        ssGrid.Row = ssGrid.ActiveRow
        For Row = 1 To 100
            For Col = 1 To 4
                ssgrid.Row = Row
                ssgrid.Col = Col
                ssgrid.Lock = True
            Next
        Next
        'ssGrid.Row = 1
        'For Col = 1 To 5
        '    ssGrid.Col = Col
        '    ssGrid.Lock = False
        'Next
    End Sub
    'Private Sub OptNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optNo.Click
    '    If OptNo.Checked = True Then
    '        FraGrid.Visible = False
    '        FraRate.Visible = True
    '        OptNo.Focus()
    '    End If
    'End Sub
    'Private Sub optYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optYes.Click
    '    If optYes.Checked = True Then
    '        FraRate.Visible = False
    '        FraGrid.Visible = True
    '        Call GridUOM(ssgrid.ActiveRow) '''---> Fill the UOM feild
    '    End If
    'End Sub
    'Private Sub optYes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles optYes.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        FraRate.Visible = False
    '        FraGrid.Visible = True
    '        cbo_BaseUOM.Focus()
    '    End If
    'End Sub
    'Private Sub OptNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles optNo.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        FraRate.Visible = True
    '        FraGrid.Visible = False
    '        txtPurchaseRate.Focus()
    '    End If
    'End Sub

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        'Dim vmain, vsmod, vssmod As Long
        Dim SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='POS' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        vconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdAdd.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        CmdView.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.CmdView.Enabled = True
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
                    Me.CmdView.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Call clearform(Me)
        ' dtgrd.DataSource = Nothing
        ' Call max()
        txtItemCode.Text = ""
        txtShort.Text = ""
        TXT_SUBDESC.Text = ""
        Txt_subcode.Text = ""
        txtRate.Text = ""
        txtPurchaseRate.Text = ""
        Me.Cmd_Freeze.Enabled = True
        'txtPromQty.Text = ""
        'txtPromUOM.Text = ""
        'txtBaseUOM.Text = ""
        'txtBaseItem.Text = ""
        'TxtSlcode.Text = ""
        'txtAcctIn.Text = ""
        'txtProItem.Text = ""
        txt_BaseRate.Text = ""
        txt_mrprate.Text = ""
        TxtKitchenCode.Text = ""
        txtItemType.Text = ""
        cmdItemHelp.Enabled = True
        txtItemType.ReadOnly = False
        txtItemCode.ReadOnly = False
        txtGroupcode.ReadOnly = False
        txtGroupDes.Text = ""
        txtGroupcode.Text = ""
        Txt_subcode.Text = ""
        TXT_SUBDESC.Text = ""
        CHK_MRPTAG.Checked = False
        CHKFBNO.Checked = False
        CHKFBYES.Checked = False
        CHKLOCNO.Checked = False
        CHKLOCYES.Checked = False
        txtItemDesc.Text = ""
        ' ChkPROMOT.Checked = False
        ChkOPENITEMFACILITY.Checked = False
        FraRate.Visible = False
        ssgrid.Visible = True
        FraGrid.Visible = True
        txtGroupcode.Text = ""
        optYes.Checked = True
        CmbUOm.Items.Clear()
        CBO_CATEGORY.Text = ""
        ' CBO_SUBSCODE.Text = ""
        LstPOScode.Items.Clear()
        'cbo_BaseUOM.Items.Clear()
        'cmbBaseUOM.Items.Clear()
        'txtBaseQty.Text = 1
        'dtp_WEFdate.Value = Format(gFinancalyearStart, "dd/MMM/yyyy")
        'dtp_WEFdate.Value = Format(gFinancialyearStart, "dd/MM/yyyy")

        ' txtBaseRate.Text = 0
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        CmdAdd.Text = "Add [F7]"
        ssgrid.SetActiveCell(1, 1)
        ssgrid.ClearRange(1, 1, -1, -1, True)
        Call FillPOS() ''--> Fill All POS Location
        Call FillUOM() '' --> Fill All UOM  FILL
        Call FillCategory()
        cbo_BaseUOM.DropDownStyle = ComboBoxStyle.DropDownList
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtRate.Enabled = True
        FraGrid.Enabled = True
        txtItemCode.Select()

    End Sub
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub FillPOS()
        ssql = "SELECT ISNULL(POSCODE,'') AS POSCODE,ISNULL(POSDESC,'') AS POSDESC,ISNULL(POSSEQNO,0) AS POSSEQNO FROM POSMaster WHERE ISNULL(Freeze,'') <> 'Y'  AND STORETYPE='POS' ORDER BY POSCODE"
        LstPOScode.Items.Clear()
        vconn.getDataSet(ssql, "POSMaster")
        If gdataset.Tables("POSMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POSMaster").Rows.Count - 1
                With gdataset.Tables("POSMaster").Rows(i)
                    LstPOScode.Items.Add(Trim(.Item("POSCODE")) & " [ " & Trim(.Item("POSDESC")) & " ]")
                End With
            Next i
        End If
    End Sub
    Private Sub LstPOScode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            If CmdAdd.Text = "Add [F7]" Then
                optYes.Focus()
            ElseIf CmdAdd.Text = "Update[F7]" Then
                If optYes.Checked = True Then
                    ssgrid.Focus()
                    ssgrid.SetActiveCell(3, 1)
                Else
                    txtPurchaseRate.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub cmdItemHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemHelp.Click
        'gSQLString = "SELECT  ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMDESC,'') as ITEMDESC FROM ITEMMASTER"
        'If Trim(Search) = " " Then
        '    M_WhereCondition = ""
        'Else
        '    M_WhereCondition = ""
        'End If
        'Dim vform As New ListOperattion1
        'vform.Field = "ITEMDESC,ITEMCODE"
        'vform.vFormatstring = "  ITEM CODE         |                               ITEM DESCRIPTION                             "
        'vform.vCaption = " ITEM MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.ShowDialog(Me)
        'If Trim(vform.keyfield & "") <> "" Then
        '    txtItemCode.Text = Trim(vform.keyfield & "")
        '    Call txtItemCode_Validated(txtItemCode, e)
        'End If
        'vform.Close()
        'vform = Nothing

        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMDESC,'') AS ITEMDESC FROM ITEMMASTER"
            M_WhereCondition = " "
            vform.Field = "ITEMCODE,ITEMDESC"
            ' vform.Frmcalled = "  POSCODE  | ITEM DESCRIPTION          |                                  "
            vform.vCaption = "Item Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtItemCode.Text = Trim(vform.keyfield & "")
                txtItemCode.Select()
                txtItemCode_Validated(sender, e)
                CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub txtItemType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemType.KeyDown
        If e.KeyCode = Keys.F4 Then
            Search = Trim(txtItemType.Text)
            Call cmdType_Click(cmdType, e)
        End If
    End Sub

    Private Sub txtItemType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtItemType.Text) <> "" Then
                Call txtItemType_Validated(txtItemType, e)
            Else
                Call cmdType_Click(cmdType, e)
            End If
        End If
    End Sub
    'Private Sub cmdGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroup.Click
    '    Dim vform As New ListOperattion1
    '    gSQLString = "SELECT ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPDESC,'') AS GROUPDESC FROM groupmaster"
    '    If Trim(Search) = " " Then
    '        M_WhereCondition = ""
    '    Else
    '        M_WhereCondition = " WHERE ISNULL(Freeze,'') <> 'Y'"
    '    End If
    '    vform.Field = "GROUPCODE,GROUPDESC"
    '    vform.vFormatstring = "   GROUPCODE        |                               GROUP DESCRIPTION                             "
    '    vform.vCaption = "GROUP MASTER HELP"
    '    vform.KeyPos = 0
    '    vform.KeyPos1 = 1
    '    vform.ShowDialog(Me)
    '    If Trim(vform.keyfield & "") <> "" Then
    '        txtGroupcode.Text = Trim(vform.keyfield & "")
    '        Call txtGroupcode_Validated(txtGroupcode, e)
    '    End If
    '    vform.Close()
    '    vform = Nothing
    'End Sub
    Private Sub txtItemType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemType.Validated
        If txtItemType.Text <> "" Then
            ssql = "SELECT ISNULL(CHARGECODE,'') AS CHARGECODE,ISNULL(CHARGEDESC,'') AS CHARGEDESC FROM CHARGEMASTER  WHERE ISNULL(RATE,0)=0  AND CHARGECODE='" & Trim(txtItemType.Text) & "' AND ISNULL(Freeze,'') <> 'Y'"
            'ssql = "and "ESC
            vconn.getDataSet(ssql, "ItemTypeMaster")
            If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                txtTypedes.Text = ""
                txtTypedes.Text = Trim(gdataset.Tables("ItemTypeMaster").Rows(0).Item("CHARGEDESC"))
                txtTypedes.ReadOnly = True
                Txt_subcode.Focus()
            Else
                txtItemType.Clear()
                txtTypedes.Clear()
                txtItemType.Focus()
            End If
        Else
            txtTypedes.Clear()
        End If
    End Sub

    Private Sub txtItemCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdItemHelp.Enabled = True Then
                Search = Trim(txtItemCode.Text)
                Call cmdItemHelp_Click(cmdItemHelp, e)
            End If
        End If
    End Sub

    Private Sub txtItemCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtItemCode.Text) <> "" Then
                Call txtItemType_Validated(txtItemType, e)
                txtItemDesc.Focus()
            Else
                Call cmdItemHelp_Click(cmdType, e)
            End If
        End If
    End Sub

    Private Sub txtItemCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemCode.Validated
        Dim vTypeseqno, vGroupseqno As Double
        Dim dt As DataTable
        Dim vString, VarPOSCODE() As String
        Dim j As Integer
        If Trim(txtItemCode.Text) <> "" Then
            vseqno = GetSeqno(Trim(txtItemCode.Text))
            ''******************* Fetch the ITEMMASTER *************************************************************''
            ssql = "SELECT isnull(wefdate,'') as wefdate,ISNULL(ITEMDESC,'') AS ITEMDESC,ISNULL(SHORTNAME,'') AS SHORTNAME,isnull(category,'') as CATEGORY,ISNULL(ITEMTYPEDESC,'') AS ITEMTYPEDESC,ISNULL(SUBSCODE,'') AS SUBSCODE,ISNULL(ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(BASEUOMSTD,'') as BASEUOMSTD,"
            ssql = ssql & " ISNULL(BASERATESTD,'0.00') as BASERATESTD,ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(FREEZE,'') AS FREEZE,ISNULL(ADDDATETIME,GETDATE()) AS ADDDATETIME,"
            ssql = ssql & " ISNULL(MULTIRATE,'') AS MULTIRATE,ISNULL(PROMOTIONAL,0) AS PROMOTIONAL,ISNULL(BASEUOM,'') AS BASEUOM,ISNULL(BASEQTY,0) AS BASEQTY,"
            ssql = ssql & " ISNULL(BASERATE,0) AS BASERATE,ISNULL(MRPTAG,'') AS MRPTAG,ISNULL(MRPRATE,0) AS MRPRATE,isnull(LWTFLAG,'') as LWTFLAG,isnull(fbflag,'') fbflag, ISNULL(STARTINGDATE,GETDATE()) AS STARTINGDATE,ISNULL(ENDINGDATE,GETDATE()) AS ENDINGDATE,"
            ssql = ssql & " ISNULL(PROMUOM,'') AS PROMUOM,ISNULL(PROMQTY,0) AS PROMQTY,ISNULL(PROMRATE,0) AS PROMRATE,ISNULL(PROMITEMCODE,'') AS PROMITEMCODE,ISNULL(OPENFACILITY,'') AS OPENFACILITY,ISNULL(SALESACCTIN,'') AS SALESACCTIN,ISNULL(SALESSLCODE,'') AS SALESSLCODE,ISNULL(STORECODE,'') AS STORECODE,ISNULL(subgroupcode,'') AS subgroupcode,ISNULL(subgroupdesc,'') AS subgroupdesc "
            ssql = ssql & " FROM ItemMaster WHERE ItemCodeSeqno=" & (vseqno)
            vconn.getDataSet(ssql, "ItemMaster")
            If gdataset.Tables("ItemMaster").Rows.Count > 0 Then
                Call FillUOM() ''--> Fill All UOM 
                'Call GRIDLOCK()
                'FraGrid.Enabled = True
                txtItemDesc.Text = ""
                txtItemDesc.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("ITEMDESC"))
                ' txtAcctIn.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("SALESACCTIN"))
                ' TxtSlcode.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("SALESSLCODE"))
                txtShort.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("SHORTNAME"))
                txtItemType.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("ITEMTYPECODE"))
                txtTypedes.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("ITEMTYPEDESC"))
                Txt_subcode.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("subgroupcode"))
                TXT_SUBDESC.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("subgroupdesc"))

                TxtKitchenCode.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("STORECODE"))

                vTypeseqno = GetSeqno(txtItemType.Text)

                CBO_CATEGORY.DropDownStyle = ComboBoxStyle.DropDown
                CBO_CATEGORY.Text = gdataset.Tables("ItemMaster").Rows(0).Item("CATEGORY")

                'dtp_WEFdate.Value = CDate(gdataset.Tables("ItemMaster").Rows(0).Item("WEFDATE"))

                'CBO_SUBSCODE.DropDownStyle = ComboBoxStyle.DropDown
                'CBO_SUBSCODE.Text = gdataset.Tables("ItemMaster").Rows(0).Item("SUBSCODE")

                'ssql = "SELECT ISNULL(ITEMTYPEDESC,'') AS ITEMTYPEDESC FROM ItemTypeMaster WHERE ItemTypeSeqno=" & Val(vTypeseqno)
                'vString = ""
                'vString = vconn.getvalue(ssql)
                'txtTypedes.Text = Trim(vString)
                txtGroupcode.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("GROUPCODE"))
                vGroupseqno = GetSeqno(txtGroupcode.Text)
                ssql = "SELECT ISNULL(GROUPDESC,'') AS GROUPDESC FROM GroupMaster WHERE  GroupSeqno=" & Val(vGroupseqno)
                vString = ""
                vString = vconn.getvalue(ssql)
                txtGroupDes.Text = Trim(vString)
                If gdataset.Tables("ItemMaster").Rows(0).Item("FREEZE") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("ItemMaster").Rows(0).Item("ADDDATETIME")), "dd-MMM-yyyy")
                    'Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If
                txtItemCode.ReadOnly = True
                txtTypedes.ReadOnly = True
                txtGroupDes.ReadOnly = True
                txtGroupcode.ReadOnly = True
                cmdItemHelp.Enabled = False
                CmdAdd.Text = "Update[F7]"
                If CmdAdd.Text = "Update[F7]" Then
                    'txtRate.Enabled = False
                    'CmbUOm.Enabled = False
                    'ssgrid.Lock = True
                Else
                    'txtRate.Enabled = True
                    'CmbUOm.Enabled = True
                    'ssgrid.Lock = False
                End If
                ''******************** This is for POSMENULINK **********************************************************''
                ssql = "SELECT * FROM POSmenulink WHERE Itemcodeseqno=" & (vseqno)
                vconn.getDataSet(ssql, "POSMenuLink")
                If gdataset.Tables("PosMenuLink").Rows.Count > 0 Then
                    For i = 0 To gdataset.Tables("PosMenuLink").Rows.Count - 1
                        For j = 0 To LstPOScode.Items.Count - 1
                            VarPOSCODE = Split(Trim(LstPOScode.Items(j)), "[")
                            If Trim(gdataset.Tables("PosMenuLink").Rows(i).Item("POS")) = Trim(VarPOSCODE(0)) Then
                                LstPOScode.SetItemChecked(j, True)
                                LstPOScode.SelectedItem = gdataset.Tables("PosMenuLink").Rows(0).Item("POS")
                            End If
                        Next j
                    Next
                End If
                ''****************** Fetch ITEMRATE form RATEMASTER if Multirate is Yes *****************************''
                If Trim(gdataset.Tables("ItemMaster").Rows(0).Item("MULTIRATE")) = "Y" Then
                    optYes.Checked = True
                    FraRate.Visible = False
                    FraGrid.Visible = True
                    If CmdAdd.Text = "Update[F7]" Then
                        'txtRate.Enabled = False
                        'FraGrid.Enabled = False
                        'ssgrid.Enabled=
                    Else
                        'txtRate.Enabled = True
                        'FraGrid.Enabled = True
                    End If
                    cbo_BaseUOM.DropDownStyle = ComboBoxStyle.DropDown
                    cbo_BaseUOM.Text = gdataset.Tables("ItemMaster").Rows(0).Item("BASEUOMSTD")
                    txt_BaseRate.Text = Format(Val(gdataset.Tables("ItemMaster").Rows(0).Item("BASERATESTD")), "0.00")
                    cbo_BaseUOM.DropDownStyle = ComboBoxStyle.DropDownList
                    With ssgrid
                        ssql = "SELECT ISNULL(UOM,'') AS UOM,ISNULL(ITEMRATE,0) AS ITEMRATE,ISNULL(MRPRATE,0) AS MRPRATE,ISNULL(PURCAHSERATE,0) AS PURCAHSERATE,ISNULL(RPOSCODE,'') AS POS FROM RateMaster WHERE Itemcodeseqno=" & (vseqno) & " AND ISNULL(ENDINGDATE,'')='' "
                        vconn.getDataSet(ssql, "RateMaster")
                        If gdataset.Tables("RateMaster").Rows.Count > 0 Then
                            For i = 0 To gdataset.Tables("RateMaster").Rows.Count - 1
                                Call GridUOM(i + 1) ''---> Fill the UOM feild
                                .SetText(1, i + 1, Trim(txtItemCode.Text))
                                .SetText(2, i + 1, Trim(txtItemDesc.Text))
                                .SetText(3, i + 1, Trim(gdataset.Tables("RateMaster").Rows(i).Item("UOM")))
                                .SetText(4, i + 1, Val(gdataset.Tables("RateMaster").Rows(i).Item("ITEMRATE")))
                                .SetText(5, i + 1, Val(gdataset.Tables("RateMaster").Rows(i).Item("PURCAHSERATE")))
                                .SetText(6, i + 1, Trim(gdataset.Tables("RateMaster").Rows(i).Item("POS")))
                                '.SetText(6, i + 1, Val(gdataset.Tables("RateMaster").Rows(i).Item("MRPRATE")))
                            Next
                        End If
                    End With
                Else
                    optNo.Checked = True
                    FraGrid.Visible = False
                    FraRate.Visible = True
                    ssql = "SELECT ISNULL(UOM,'') AS UOM,ISNULL(ITEMRATE,0) AS ITEMRATE,ISNULL(MRPRATE,0) AS MRPRATE,ISNULL(PURCAHSERATE,0) AS PURCAHSERATE FROM RateMaster WHERE Itemcodeseqno=" & (vseqno) & " and ISNULL(ENDINGDATE,'')='' "
                    vconn.getDataSet(ssql, "RateMaster")
                    If gdataset.Tables("RateMaster").Rows.Count > 0 Then
                        txtPurchaseRate.Text = Format(Val(gdataset.Tables("RateMaster").Rows(0).Item("PURCAHSERATE")), "0.00")
                        txtRate.Text = Format(Val(gdataset.Tables("RateMaster").Rows(0).Item("ITEMRATE")), "0.00")
                        txt_mrprate.Text = Format(Val(gdataset.Tables("RateMaster").Rows(0).Item("MRPRATE")), "0.00")
                        CmbUOm.Text = Trim(gdataset.Tables("RateMaster").Rows(0).Item("UOM"))
                    End If
                End If
                If Trim(gdataset.Tables("ItemMaster").Rows(0).Item("MRPTAG")) = "Y" Then
                    CHK_MRPTAG.Checked = True
                Else
                    CHK_MRPTAG.Checked = False
                End If
                If Trim(gdataset.Tables("ItemMaster").Rows(0).Item("fbflag")) = "Y" Then
                    CHKFBYES.Checked = True
                Else
                    CHKFBNO.Checked = True
                End If
                If Trim(gdataset.Tables("ItemMaster").Rows(0).Item("LWTFLAG")) = "Y" Then
                    CHKLOCYES.Checked = True
                Else
                    CHKLOCNO.Checked = True
                End If
                If Trim(gdataset.Tables("ItemMaster").Rows(0).Item("Openfacility")) = "Y" Then
                    ChkOPENITEMFACILITY.Checked = True
                Else
                    ChkOPENITEMFACILITY.Checked = False
                End If
                'If Trim(gdataset.Tables("ItemMaster").Rows(0).Item("PROMOTIONAL")) = "Y" Then
                '    ChkPROMOT.Checked = True
                '    btnPromotionalView.Visible = True
                '    ChkPROMOT.Checked = True
                '    If Trim(gdataset.Tables("ItemMaster").Rows(0).Item("MULTIRATE")) = "Y" Then
                '        cmbBaseUOM.Visible = True
                '        txtPromUOM.Visible = False
                '        cmbBaseUOM.DropDownStyle = ComboBoxStyle.DropDown
                '        cmbBaseUOM.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("BASEUOM"))
                '    Else
                '        cmbBaseUOM.Visible = False
                '        txtPromUOM.Visible = True
                '        txtBaseUOM.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("BASEUOM"))
                '    End If
                '    mskFromDate.Value = CDate(gdataset.Tables("ItemMaster").Rows(0).Item("STARTINGDATE"))
                '    mskToDate.Value = CDate(gdataset.Tables("ItemMaster").Rows(0).Item("ENDINGDATE"))
                '    txtBaseQty.Text = Val(gdataset.Tables("ItemMaster").Rows(0).Item("BASEQTY"))
                '    txtBaseRate.Text = Format(Val(gdataset.Tables("ItemMaster").Rows(0).Item("BASERATE")), "0.00")
                '    'txt_mrprate.Text = Format(Val(gdataset.Tables("ItemMaster").Rows(0).Item("MRPRATE")), "0.00")
                '    txtProItem.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("PROMITEMCODE"))
                '    ssql = "SELECT  ISNULL(MULTIRATE,'') AS MULTIRATE   FROM ItemMaster WHERE Itemcode='" & Trim(txtProItem.Text) & "'"
                '    vconn.getDataSet(ssql, "ITEMMASTER1")
                '    If gdataset.Tables("ITEMMASTER1").Rows.Count > 0 Then
                '        If Trim(gdataset.Tables("ITEMMASTER1").Rows(0).Item("MULTIRATE")) = "Y" Then
                '            txtPromUOM.Visible = False
                '            cmbPromtUOM.Visible = True
                '            cmbPromtUOM.DropDownStyle = ComboBoxStyle.DropDown
                '            cmbPromtUOM.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("PROMUOM"))
                '        Else
                '            cmbPromtUOM.Visible = False
                '            txtPromUOM.Visible = True
                '            txtPromUOM.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("PROMUOM"))
                '        End If
                '        txtPromQty.Text = Val(gdataset.Tables("ItemMaster").Rows(0).Item("PROMQTY"))
                '        txtPromRate.Text = Format(Val(gdataset.Tables("ItemMaster").Rows(0).Item("PROMRATE")), "0.00")
                '    End If
                'Else
                '    ChkPROMOT.Checked = False
                'End If
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
            Else
                txtItemDesc.Focus()
            End If
            txtItemDesc.Focus()
        Else
            txtItemCode.Text = ""
            txtItemCode.Focus()
        End If
    End Sub

    Private Sub OptNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If optNo.Checked = True Then
            FraGrid.Visible = False
            FraRate.Visible = True
            optNo.Focus()
        End If
    End Sub
    Private Sub optYes_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If optYes.Checked = True Then
            FraRate.Visible = False
            FraGrid.Visible = True
            Call GridUOM(ssgrid.ActiveRow) ''---> Fill the UOM feild
        End If
    End Sub
    Private Sub optYes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            FraRate.Visible = False
            FraGrid.Visible = True
            cbo_BaseUOM.Focus()
        End If
    End Sub
    Private Sub OptNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            FraRate.Visible = True
            FraGrid.Visible = False
            txtPurchaseRate.Focus()
        End If
    End Sub
    'Private Sub txtItemType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemType.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        If Trim(txtItemType.Text) <> "" Then
    '            Call txtItemType_Validated(txtItemType, e)
    '        Else
    '            Call cmdType_Click(cmdType, e)
    '        End If
    '    End If
    'End Sub

    'Private Sub ItemMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '    If e.KeyCode = Keys.F6 Then
    '        If FraPromt.Visible = False Then
    '            Call CmdClear_Click(CmdClear, e)
    '        End If
    '    End If
    '    'If e.KeyCode = Keys.F10 Then
    '    '    Call cmdOk_Click(sender, e)
    '    'End If
    '    'If e.KeyCode = Keys.F2 Then
    '    '    Call btnPromotDelete_Click(sender, e)
    '    'End If
    '    If e.KeyCode = Keys.F12 Then
    '        Call cmdCancel_Click(sender, e)
    '    End If
    '    'If e.KeyCode = Keys.F7 Then
    '    '    If FraPromt.Visible = False Then
    '    '        Call CmdAdd_Click(CmdAdd, e)
    '    '    End If
    '    'End If
    '    'If e.KeyCode = Keys.F8 Then
    '    '    If FraPromt.Visible = False Then
    '    '        Call Cmd_Freeze_Click(Cmd_Freeze, e)
    '    '    End If
    'End If
    'If e.KeyCode = Keys.F9 Then
    '    Call CmdView_Click(CmdView, e)
    'End If
    'If e.KeyCode = Keys.F8 Then
    '    If Cmd_Freeze.Enabled = True Then
    '        Call Cmd_Freeze_Click(Cmd_Freeze, e)
    '        Exit Sub
    '    End If
    'End If
    'If e.KeyCode = Keys.F7 Then
    '    If CmdAdd.Enabled = True Then
    '        Call CmdAdd_Click(CmdAdd, e)
    '        Exit Sub
    '    End If
    'End If
    'If e.KeyCode = Keys.F9 Then
    '    If Cmd_Delete.Enabled = True Then
    '        Call Cmd_Delete_Click(Cmd_Delete, e)
    '        Exit Sub
    '    End If
    'End If

    'If e.KeyCode = Keys.F10 Then
    '    If cmdexport.Enabled = True Then
    '        Call CmdView_Click(cmdexport, e)
    '        Exit Sub
    '    End If
    'End If

    'If e.KeyCode = Keys.F12 Then
    '    If cmdreport.Enabled = True Then
    '        Call cmdreport_Click(cmdreport, e)
    '        Exit Sub
    '    End If
    'End If


    'If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
    '    If FraPromt.Top = 8 Then
    '        FraPromt.Top = 1000
    '    Else
    '        Me.Close()
    '    End If
    'End If
    'End Sub

    Private Sub txtItemDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txtShort.Focus()
        End If
    End Sub
    Private Sub txtShort_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txtItemType.Focus()
        End If
    End Sub
    Private Sub txtRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            CmbUOm.Focus()
        End If
    End Sub

    'Private Sub mskDateFrom_KeyPressEvent(ByVal sender As System.Object, ByVal e As AxMSMask.MaskEdBoxEvents_KeyPressEvent)
    '    If Asc(e.keyAscii) = 13 Then
    '        mskToDate.Focus()
    '    End If
    'End Sub

    'Private Sub mskDateTo_KeyPressEvent(ByVal sender As System.Object, ByVal e As AxMSMask.MaskEdBoxEvents_KeyPressEvent)
    '    If e.keyAscii = 13 Then
    '        txtBaseUOM.Focus()
    '    End If
    'End Sub



    Private Sub FillUOM() ''---> Fill All UOM From UOMMASTER
        ssql = "SELECT DISTINCT ISNULL(UOMCODE,'') AS UOMCODE FROM UOMMaster WHERE ISNULL(Freeze,'') <> 'Y' ORDER BY uomCODE ASC"
        vconn.getDataSet(ssql, "UOMMaster")
        CmbUOm.Items.Clear()
        ' cmbBaseUOM.Items.Clear()
        'cmbPromtUOM.Items.Clear()
        cbo_BaseUOM.Items.Clear()
        If gdataset.Tables("UOMMaster").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("UOMMaster").Rows.Count - 1
                With gdataset.Tables("UOMMaster").Rows(i)
                    CmbUOm.Items.Add(Trim(.Item("UOMCODE")))
                    cbo_BaseUOM.Items.Add(Trim(.Item("UOMCODE")))
                    'cmbBaseUOM.Items.Add(Trim(.Item("UOMdesc") ))
                    'cmbPromtUOM.Items.Add(Trim(.Item("UOMdesc")))
                End With
            Next i
        End If
        cbo_BaseUOM.Sorted = True
        CmbUOm.Sorted = True
        'cmbBaseUOM.Sorted = True
        'cmbPromtUOM.Sorted = True
    End Sub

    'Private Sub ssgrid_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid.LeaveCell
    '    Dim vacctcode As String
    '    ssgrid.GetText(3, ssgrid.ActiveRow, vacctcode)
    '    If Trim(vacctcode & "") <> "" Then
    '        For i = 1 To ssgrid.DataRowCnt
    '            ssgrid.Row = i
    '            ssgrid.Col = 3
    '            If Trim(ssgrid.Text) <> "" Then
    '                If Trim(ssgrid.Text) = Trim(vacctcode) And ssgrid.Row <> ssgrid.ActiveRow Then
    '                    ssgrid.Row = ssgrid.ActiveRow
    '                    ssgrid.ClearRange(1, ssgrid.ActiveRow, 11, ssgrid.ActiveRow, True)
    '                    MsgBox("UOM Code already Selected", vbInformation + MsgBoxStyle.OkOnly, MyCompanyName)
    '                    ssgrid.DeleteRows(ssgrid.ActiveRow, 1)
    '                    ssgrid.ActiveRow = ssgrid.Row - 1
    '                    ssgrid.ClearRange(ssgrid.ActiveCol, ssgrid.ActiveRow, ssgrid.ActiveCol, ssgrid.ActiveRow, False)
    '                    ssgrid.Col = 1
    '                    ssgrid.Row = ssgrid.ActiveRow
    '                    ssgrid.Focus()
    '                    Exit Sub
    '                End If
    '            End If
    '        Next i
    '    End If
    'End Sub
    Private Sub GridUOM(ByVal i As Integer)
        Dim j As Integer
        Dim sqlstring As String
        ssgrid.TypeComboBoxClear(3, i)
        sqlstring = " SELECT UOMCODE FROM UOMMaster WHERE ISNULL(Freeze,'') <> 'Y' ORDER BY uomCODE ASC "
        vconn.getDataSet(sqlstring, "UOMMaster1")
        If gdataset.Tables("UOMMaster1").Rows.Count > 0 Then
            For j = 0 To gdataset.Tables("UOMMaster1").Rows.Count - 1
                ssgrid.Col = 3
                ssgrid.Row = i
                ssgrid.TypeComboBoxString = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("UOMCODE"))
                ssgrid.TypeComboBoxIndex = j
            Next j
        End If
    End Sub
    'Private Sub cmbBaseUOM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBaseUOM.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        Call cmbBaseUOM_Validated(cmbBaseUOM, e)
    '        txtBaseQty.Text = 1
    '        txtBaseQty.Focus()
    '    End If
    'End Sub
    'Private Sub cmbPromtUOM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPromtUOM.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        txtPromQty.Focus()
    '    End If
    'End Sub
    'Private Sub cmbBaseUOM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBaseUOM.Validated
    '    Dim vString As String
    '    If Trim(txtBaseItem.Text & "") <> "" Then
    '        ssql = "SELECT ItemRate FROM RateMaster WHERE ItemCode= '" & txtItemCode.Text & "'  AND UOM ='" & Trim(cmbBaseUOM.Text) & "'"
    '        vString = vconn.getvalue(ssql)
    '        If Trim(vString) <> "" Then
    '            txtBaseRate.Text = Format(Val(vString), "0.00")
    '            txtBaseQty.Text = 1
    '        Else
    '            For i = 1 To ssgrid.DataRowCnt
    '                ssgrid.Row = i
    '                ssgrid.Col = 3
    '                If Trim(cmbBaseUOM.Text) = Trim(ssgrid.Text) Then
    '                    ssgrid.Col = 4
    '                    txtBaseRate.Text = Format(Val(ssgrid.Text), "0.00")
    '                    Exit Sub
    '                Else
    '                    txtBaseRate.Text = 1
    '                End If
    '            Next i
    '            txtBaseRate.Text = 1
    '        End If
    '    End If
    'End Sub
    'Private Sub txtBaseItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBaseItem.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        If OptNo.Checked = True Then
    '            txtBaseUOM.Focus()
    '        ElseIf optYes.Checked = True Then
    '            cmbBaseUOM.Items.Clear()
    '            For i = 1 To ssgrid.DataRowCnt
    '                ssgrid.Col = 3
    '                ssgrid.Row = i
    '                cmbBaseUOM.Items.Add(Trim(ssgrid.Text))
    '            Next i
    '            cmbBaseUOM.SelectedIndex = 0
    '            cmbBaseUOM.Focus()
    '        End If
    '    End If
    'End Sub

    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent)
        If e.keyCode = Keys.F3 Then
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.ClearRange(1, ssgrid.ActiveRow, 5, ssgrid.ActiveRow, True)
            ssgrid.DeleteRows(ssgrid.ActiveRow, 1)
            ssgrid.ActiveRow = ssgrid.Row - 1
            ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
            ssgrid.Focus()
        End If
    End Sub
    Private Sub ItemMaster_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        itemmasterbool = False
    End Sub

    'Private Sub mskFromDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskFromDate.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        mskToDate.Focus()
    '    End If
    'End Sub

    'Private Sub mskToDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskToDate.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        txtBaseItem.Focus()
    '    End If
    'End Sub


    Private Sub txtRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txtRate.Text = Format(Val(txtRate.Text), "0.00")
    End Sub

    Private Sub txtPurchaseRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txtPurchaseRate.Text = Format(Val(txtPurchaseRate.Text), "0.00")
    End Sub



    Private Sub ssgrid_KeyPressEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyPressEvent)
        If Asc(e.keyAscii) = 13 Or ssgrid.ActiveCol = 1 Then
            If optYes.Checked = True Then
                ssgrid.SetText(1, ssgrid.ActiveRow, Trim(txtItemCode.Text))
                ssgrid.SetText(2, ssgrid.ActiveRow, Trim(txtItemDesc.Text))
                Call GridUOM(ssgrid.ActiveRow)
            End If
        End If
    End Sub





    Private Sub txtPurchaseRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'txtRate.Focus()
            CHK_MRPTAG.Focus()
        End If
    End Sub


    Private Sub txt_BaseRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_BaseRate.LostFocus
        txt_BaseRate.Text = Format(Val(txt_BaseRate.Text), "0.00")
    End Sub

    Private Sub cbo_BaseUOM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_BaseUOM.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txt_BaseRate.Focus()
        End If
    End Sub

    Private Sub txt_BaseRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_BaseRate.KeyPress

        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'for ne decimal point
        If (e.KeyChar = "."c AndAlso (txtRate).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 13 Then
            Dim sqlstring As String
            Dim dblrate As Double
            Dim i, j As Integer
            Dim vuom As String
            If CmdAdd.Text = "Update[F7]" Then
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 4
                    If Trim(txt_BaseRate.Text) <> Trim(ssgrid.Text) Then
                        ssgrid.SetText(4, i, Format(Val(txt_BaseRate.Text), "0.00"))
                    End If
                Next i
                For j = 1 To ssgrid.DataRowCnt
                    ssgrid.Col = 3
                    ssgrid.Row = j
                    vuom = ssgrid.Text
                    sqlstring = "SELECT * FROM UOMRELATION WHERE uom2='" & Trim(cbo_BaseUOM.Text) & "' "
                    sqlstring = sqlstring & " AND uom1='" & vuom & "' "
                    vconn.getDataSet(sqlstring, "UOMRELATION")
                    If gdataset.Tables("UOMRELATION").Rows.Count > 0 Then
                        dblrate = gdataset.Tables("UOMRELATION").Rows(0).Item("ratio2") * Val(txt_BaseRate.Text)
                        ssgrid.SetText(4, j, Format(Val(dblrate), "0.00"))
                    End If
                Next j
                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                ssgrid.Focus()
            Else
                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                ssgrid.Focus()
            End If
        End If
    End Sub

    Private Sub txt_BaseRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_BaseRate.TextChanged
        Dim sqlstring As String
        Dim dblrate As Double
        Dim i, j As Integer
        Dim vuom As String
        If CmdAdd.Text = "Update[F7]" Then
            For i = 1 To ssgrid.DataRowCnt
                ssgrid.Row = i
                ssgrid.Col = 4
                If Trim(txt_BaseRate.Text) <> Trim(ssgrid.Text) Then
                    ssgrid.SetText(4, i, Format(Val(txt_BaseRate.Text), "0.00"))
                End If
            Next i
            For j = 1 To ssgrid.DataRowCnt
                ssgrid.Col = 3
                ssgrid.Row = j
                vuom = ssgrid.Text
                sqlstring = "SELECT * FROM UOMRELATION WHERE uom2='" & Trim(cbo_BaseUOM.Text) & "' "
                sqlstring = sqlstring & " AND uom1='" & vuom & "' "
                vconn.getDataSet(sqlstring, "UOMRELATION")
                If gdataset.Tables("UOMRELATION").Rows.Count > 0 Then
                    dblrate = gdataset.Tables("UOMRELATION").Rows(0).Item("ratio2") * Val(txt_BaseRate.Text)
                    ssgrid.SetText(4, j, Format(Val(dblrate), "0.00"))
                End If
            Next j
        End If
    End Sub
    Private Function MeValidate() As Boolean
        MeValidate = True
        If Trim(txtItemCode.Text & "") = "" Then
            MeValidate = False
            MsgBox("Item Code Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MyCompanyName)
            txtItemCode.Focus()
            Exit Function
        End If
        If Trim(CBO_CATEGORY.Text & "") = "" Then
            MeValidate = False
            MsgBox("category Code Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MyCompanyName)
            CBO_CATEGORY.Focus()
            Exit Function
        End If
        If Trim(txtItemDesc.Text & "") = "" Then
            MeValidate = False
            MsgBox("Item Code Description Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MyCompanyName)
            txtItemDesc.Focus()
            Exit Function
        End If
        If Trim(Txt_subcode.Text & "") = "" Then
            MeValidate = False
            MsgBox("subgroup Code Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MyCompanyName)
            Txt_subcode.Focus()
            Exit Function
        End If
        'If Trim(CmbUOm.Text & "") = "" Then
        '    MeValidate = False
        '    MsgBox(" Code Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MyCompanyName)
        '    CmbUOm.Focus()
        '    Exit Function
        'End If
        If Trim(txtItemType.Text & "") = "" Then
            MeValidate = False
            MsgBox("Item type Code Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MyCompanyName)
            txtItemType.Focus()
            Exit Function
        End If
        If Trim(txtGroupcode.Text & "") = "" Then
            MeValidate = False
            MsgBox("Group Code Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MyCompanyName)
            txtGroupcode.Focus()
            Exit Function
        End If
        If CHK_MRPTAG.Checked = True Then
            Dim DB As Double = Nothing
            Dim STR As String = Nothing
            STR = txt_mrprate.Text
            DB = Convert.ToDouble(STR)
            If DB <= 0 Then
                MeValidate = False
                MessageBox.Show("MRPRATE MUST BE GREATER THAN ZERO")
                txt_mrprate.Focus()
                Exit Function
                'txt_mrprate.Focus()
                'Else
                '    txtRate.Focus()
                'End If
            Else
                txtRate.Focus()
            End If
        End If
        'If gCompanyname = "CHORD ROAD CLUB" Then
        'Else
        '    If Trim(Txt_subcode.Text & "") = "" Then
        '        MeValidate = False
        '        MsgBox("subGroup Code Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, MyCompanyName)
        '        Txt_subcode.Focus()
        '        Exit Function
        '    End If
        'End If
        'If gCompanyname = "THE TNCA CLUB" Then
        'Else
        '    If Trim(Txt_subcode.Text & "") = "" Then
        '        MeValidate = False
        '        MsgBox("subGroup Code Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, MyCompanyName)
        '        Txt_subcode.Focus()
        '        Exit Function
        '    End If
        'End If
        If OptNo.Checked = True Then
            If Trim(txtRate.Text & "") = "" Then
                MeValidate = False
                MsgBox("Item Rate Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MyCompanyName)
                txtRate.Focus()
                Exit Function
            End If
            If Trim(CmbUOm.Text & "") = "" Then
                MeValidate = False
                MsgBox("Item UOM Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MyCompanyName)
                CmbUOm.Focus()
                Exit Function
            End If
        Else
            With ssgrid
                For i = 1 To .DataRowCnt
                    .Row = i
                    .Col = 1
                    If Trim(.Text) = "" Then
                        MeValidate = False
                        MsgBox("Item Code can't blank", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MyCompanyName)
                        .SetActiveCell(1, ssgrid.ActiveRow)
                        .Focus()
                        Exit Function
                    End If
                    .Col = 2
                    If Trim(.Text) = "" Then
                        MeValidate = False
                        MsgBox("Item Description can't blank", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MyCompanyName)
                        .SetActiveCell(2, ssgrid.ActiveRow)
                        .Focus()
                        Exit Function
                    End If
                    .Col = 3
                    If Trim(.Text) = "" Then
                        MeValidate = False
                        MsgBox("UOM can't blank", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MyCompanyName)
                        .SetActiveCell(3, ssgrid.ActiveRow)
                        .Focus()
                        Exit Function
                    End If
                    .Col = 4
                    If Trim(.Text) = "" Then
                        MeValidate = False
                        MsgBox("Rate can't blank", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MyCompanyName)
                        .SetActiveCell(4, ssgrid.ActiveRow)
                        .Focus()
                        Exit Function
                    End If
                Next
            End With
        End If
    End Function

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Dim sqlstring As String
        Dim status As Integer
        Dim freeze(0) As String
        If MeValidate() = False Then Exit Sub ''-->Check Validation
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            status = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If status = 1 Then
                sqlstring = "UPDATE  ITEMMASTER "
                sqlstring = sqlstring & " SET Freeze= 'Y',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE Itemcode = '" & Trim(txtItemCode.Text) & "'"
                freeze(0) = sqlstring
                sqlstring = "UPDATE  RATEMASTER "
                sqlstring = sqlstring & " SET Freeze= 'Y',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE Itemcode = '" & Trim(txtItemCode.Text) & "'"
                ReDim Preserve freeze(freeze.Length)
                freeze(freeze.Length - 1) = sqlstring
                vconn.MoreTransold(freeze)
                Me.CmdClear_Click(sender, e)
                CmdAdd.Text = "Add [F7]"
            Else
                Exit Sub
            End If

            'Else
            '    status = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            '    If status = 1 Then
            '        sqlstring = "UPDATE  ITEMMASTER "
            '        sqlstring = sqlstring & " SET Freeze= 'N',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        sqlstring = sqlstring & " WHERE Itemcode = '" & Trim(txtItemCode.Text) & "'"
            '        freeze(0) = sqlstring
            '        sqlstring = "UPDATE  RATEMASTER "
            '        sqlstring = sqlstring & " SET Freeze= 'N',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        sqlstring = sqlstring & " WHERE Itemcode = '" & Trim(txtItemCode.Text) & "'"
            '        ReDim Preserve freeze(freeze.Length)
            '        freeze(freeze.Length - 1) = sqlstring
            '        vconn.MoreTransold(freeze)
            '        Me.CmdClear_Click(sender, e)
            '        CmdAdd.Text = "Add [F7]"
            '    Else
            '        Exit Sub
            '    End If
        End If
    End Sub


    'Private Sub Cmd_freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
    '    Dim sqlstring As String
    '    Dim Delete(0) As String
    '    If MeValidate() = False Then Exit Sub ''-->Check Validation
    '    If Mid(Me.Cmd_Delete.Text, 1, 1) = "D" Then
    '        sqlstring = "DELETE FROM ITEMMASTER "
    '        sqlstring = sqlstring & " WHERE Itemcode = '" & Trim(txtItemCode.Text) & "'"
    '        Delete(0) = sqlstring
    '        sqlstring = "DELETE FROM  RATEMASTER "
    '        sqlstring = sqlstring & " WHERE Itemcode = '" & Trim(txtItemCode.Text) & "'"
    '        ReDim Preserve Delete(Delete.Length)
    '        Delete(Delete.Length - 1) = sqlstring
    '        sqlstring = "DELETE FROM  POSMENULINK "
    '        sqlstring = sqlstring & " WHERE Itemcode = '" & Trim(txtItemCode.Text) & "'"
    '        ReDim Preserve Delete(Delete.Length)
    '        Delete(Delete.Length - 1) = sqlstring
    '        vconn.MoreTransold(Delete)
    '        Me.CmdClear_Click(sender, e)
    '        CmdAdd.Text = "Add [F7]"
    '    End If
    'End Sub

    Private Sub ChkOPENITEMFACILITY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            CmdAdd.Focus()
        End If
    End Sub



    'Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
    '    Dim sqlstring As String
    '    Dim _export As New EXPORT
    '    _export.TABLENAME = "ITEMMASTER"
    '    sqlstring = "SELECT * FROM ITEMMASTER order by ITEMcode"
    '    Call _export.export_excel(sqlstring)
    '    _export.Show()
    '    Exit Sub
    'End Sub

    'Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
    '    'GroupBox3.Visible = True
    '    'Dim vform As New report
    '    'vform.ShowDialog(Me)
    '    'vform.Close()
    '    'vform = Nothing

    '    Dim sqlstring, SSQL As String
    '    Dim Viewer As New ReportViwer
    '    Dim r As New crptitemmaster
    '    Dim POSdesc(), MemberCode() As String
    '    Dim SQLSTRING2 As String
    '    'sqlstring = "select * from VW_ITEMMASTER where category='" & Trim(CBO_CATEGORY.Text) & "' order by ItemCode"
    '    sqlstring = "select * from VW_ITEMMASTER  order by category,ItemCode"

    '    Call Viewer.GetDetails(sqlstring, "VW_ITEMMASTER", r)
    '    Viewer.TableName = "VW_ITEMMASTER"

    '    Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ5 = r.ReportDefinition.ReportObjects("Text13")
    '    TXTOBJ5.Text = gCompanyname

    '    Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
    '    TXTOBJ1.Text = "UserName : " & gUsername

    '    Viewer.Show()
    'End Sub

    Private Sub cmdkitchenHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKitchenHelp.Click
        'Dim vform As New ListOperattion1
        'gSQLString = "SELECT ISNULL(POSCODE,'') AS POSCODE,ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER"
        'If Trim(Search) = " " Then
        '    M_WhereCondition = " WHERE STORETYPE='KITCHEN'"
        'Else
        '    M_WhereCondition = " WHERE STORETYPE='KITCHEN'"
        'End If
        'vform.Field = "POSCODE,POSDESC"
        'vform.vFormatstring = "                 POS CODE              |                   POS DESCRIPTION                           "
        'vform.vCaption = "KITCHEN MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.ShowDialog(Me)
        'If Trim(vform.keyfield & "") <> "" Then
        '    TxtKitchenCode.Text = Trim(vform.keyfield & "")
        'End If
        'vform.Close()
        'vform = Nothing

        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(KITCHENCODE,'') AS KITCHENCODE ,ISNULL(KITCHENNAME,'') AS KITCHENNAME FROM KITCHENMASTER "
            M_WhereCondition = " "
            vform.Field = "KITCHENCODE,KITCHENNAME"
            ' vform.Frmcalled = "  KITCHENCODE  |  KITCHENNAME          |                                  "
            vform.vCaption = "Kitchen Code Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TxtKitchenCode.Text = Trim(vform.keyfield & "")
                TxtKitchenCode.Select()
                TxtKitchenCode_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try




    End Sub

    Private Sub TxtKitchenCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKitchenCode.TextChanged

    End Sub

    Private Sub TxtKitchenCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtKitchenCode.Validated
        'SQLSTRING = "SELECT ISNULL(POSCODE,'') AS POSCODE,ISNULL(FREEZE,'') AS FREEZE ,ADDDATETIME,ISNULL(STORESTATUS,'') AS STORESTATUS "
        SQLSTRING = " SELECT ISNULL(KITCHENCODE,'') AS KITCHENCODE ,ISNULL(KITCHENNAME,'') AS KITCHENNAME FROM KITCHENMASTER WHERE  "
        'SQLSTRING = SQLSTRING & ",ISNULL(PACKINGPERCENT,0) AS PACKINGPERCENT,ISNULL(PACKINGACCTIN,'') AS PACKINGACCTIN,ISNULL(PACKINGDESC,'') AS PACKINGDESC  FROM POSMASTER"
        SQLSTRING = SQLSTRING & " ISNULL(FREEZE,'')<>'Y'"
        vconn.getDataSet(SQLSTRING, "kitchenmaster")
        If gdataset.Tables("kitchenmaster").Rows.Count > 0 Then
            TxtKitchenCode.Text = Trim(gdataset.Tables("kitchenmaster").Rows(0).Item("KITCHENCODE"))
            LstPOScode.Focus()
        Else
            'TxtKitchenCode.Text = ""
            'TxtKitchenCode.Focus()
        End If
    End Sub
    Private Sub TxtKitchenCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKitchenCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdKitchenHelp.Enabled = True Then
                Search = Trim(TxtKitchenCode.Text)
                Call cmdkitchenHelp_Click(cmdKitchenHelp, e)
            End If
        End If
    End Sub
    Private Sub TxtKitchenCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKitchenCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TxtKitchenCode.Text) = "" Then
                Call cmdkitchenHelp_Click(cmdKitchenHelp, e)
                LstPOScode.Focus()
            Else
                TxtKitchenCode_Validated(TxtKitchenCode, e)
            End If
        End If
    End Sub

    Private Sub Txt_subcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_subcode.TextChanged

    End Sub

    Private Sub Txt_subcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_subcode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Search = Trim(Txt_subcode.Text)
            Call CMDSUBCODE_Click(CMDSUBCODE, e)
            Txt_subcode.Focus()
        End If
    End Sub

    Private Sub CMDSUBCODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSUBCODE.Click
        'Dim vform As New ListOperattion1
        'gSQLString = "SELECT ISNULL(SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(SUBGROUPDESC,'') AS SUBGROUPDESC FROM subgroupmaster "
        'If Trim(Search) = " " Then
        '    M_WhereCondition = "  "
        'Else
        '    M_WhereCondition = " "
        'End If
        'vform.Field = "SUBGROUPCODE,SUBGROUPDESC"
        'vform.vFormatstring = "    SUB GROUP CODE            |       SUB GROUP DESCRIPTION               "
        'vform.vCaption = "SUBGROUP MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.ShowDialog(Me)
        'If Trim(vform.keyfield & "") <> "" Then
        '    Txt_subcode.Text = Trim(vform.keyfield & "")
        '    Call Txt_subcode_Validated(Txt_subcode, e)
        'End If
        'vform.Close()
        'vform = Nothing

        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(SUBGROUPDESC,'') AS SUBGROUPDESC FROM subgroupmaster "
            M_WhereCondition = " "
            vform.Field = "SUBGROUPCODE,SUBGROUPDESC"
            'vform.Frmcalled = "  SUBGROUPCODE  |  DESCRIPTION          |                                  "
            vform.vCaption = "Sub Category  Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_subcode.Text = Trim(vform.keyfield & "")
                Txt_subcode.Select()
                Txt_subcode_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try

    End Sub

    Private Sub Txt_subcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_subcode.Validated
        If Txt_subcode.Text <> "" Then
            vseqno = GetSeqno(Txt_subcode.Text)
            SQLSTRING = "SELECT s.subgroupcode, s.subgroupdesc,s.groupcode,g.groupdesc,g.category "
            SQLSTRING = SQLSTRING & "FROM subGroupMaster s inner join  groupmaster g  "
            SQLSTRING = SQLSTRING & "on  s.groupcode=g.GroupCode  and subGroupCode= '" & Trim(Txt_subcode.Text) & "' "
            vconn.getDataSet(SQLSTRING, "subGroupMaster")
            If gdataset.Tables("subGroupMaster").Rows.Count > 0 Then
                Txt_subcode.Text = Trim(gdataset.Tables("subGroupMaster").Rows(0).Item("subgroupcode"))
                TXT_SUBDESC.Text = Trim(gdataset.Tables("subGroupMaster").Rows(0).Item("subgroupdesc"))
                txtGroupcode.Text = Trim(gdataset.Tables("subGroupMaster").Rows(0).Item("groupcode"))
                txtGroupDes.Text = Trim(gdataset.Tables("subGroupMaster").Rows(0).Item("groupdesc"))
                'CBO_CATEGORY.Text = Trim(gdataset.Tables("subGroupMaster").Rows(0).Item("category"))
                TXT_SUBDESC.ReadOnly = True
                txtGroupcode.ReadOnly = True
                txtGroupDes.ReadOnly = True
                Me.CBO_CATEGORY.DropDownStyle = ComboBoxStyle.DropDownList
                'Me.ComboBox1.Items.Insert(0, "Please select ...")
                'Me.Cmb_postype.SelectedItem = "
                Me.CBO_CATEGORY.Text = gdataset.Tables("subGroupMaster").Rows(0).Item("category")
                CHKFBYES.Focus()
            Else
                Txt_subcode.Clear()
                TXT_SUBDESC.Clear()
                txtGroupDes.Clear()
                txtGroupDes.Clear()
                Txt_subcode.Focus()
            End If
        Else
            TXT_SUBDESC.Clear()
        End If

    End Sub

    Private Sub Txt_subcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_subcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_subcode.Text) <> "" Then
                Call Txt_subcode_Validated(Txt_subcode, e)
            Else
                Call CMDSUBCODE_Click(CMDSUBCODE, e)
            End If
        End If
    End Sub

    Private Sub txt_mrprate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_mrprate.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbUOm.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CmbUOm.Focus()
        End If
    End Sub



    Private Sub txt_mrprate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_mrprate.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'for ne decimal point
        If (e.KeyChar = "."c AndAlso (txt_mrprate).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If



        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then

            If CHK_MRPTAG.Checked = True Then
                Dim DB As Double = 0.0
                ' Dim STR As String = 0.0
                DB = Val(txt_mrprate.Text)
                'DB = Convert.ToDouble(STR)
                If DB <= 0 Then
                    MessageBox.Show("MRP RATE MUST BE GREATER THAN ZERO")
                    'txt_mrprate.Focus()
                    'Else
                    '    txtRate.Focus()
                    'End If
                Else
                    CmbUOm.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim vPromseqno, insert(0), VarPOSCODE() As String
        Dim vstring, vDate As Date
        Dim vPOSno As Double
        Dim count As Integer
        ''*********************************** Check Validation *******************************************************'''
        If MeValidate() = False Then Exit Sub
        ''*********************************** UPDATE RateMaster,ItemMaster *******************************************'''
        If Mid(CmdAdd.Text, 1, 1) = "U" Then
            Call GRIDLOCK()
            FraGrid.Enabled = True
            vseqno = GetSeqno(txtItemCode.Text)
            ssql = "SELECT Startingdate FROM Ratemaster WHERE ItemCodeseqno=" & (vseqno) & ""
            ssql = ssql & " AND  ISNULL(endingdate,'') =''"
            vstring = vconn.getvalue(ssql)

            ' vstring = Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy")
            If Me.lbl_Freeze.Visible = True Then
                MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                'boolchk = False
                Exit Sub
            End If

            ssql = "UPDATE Itemmaster SET ItemDesc = '" & Replace(Trim(txtItemDesc.Text), "'", " ") & "',"
            ssql = ssql & " CATEGORY ='" & Trim(CBO_CATEGORY.Text) & "',"
            'ssql = ssql & " SUBSCODE ='" & Trim(CBO_SUBSCODE.Text) & "',"
            ssql = ssql & " STORECODE ='" & Trim(TxtKitchenCode.Text) & "'," 'ITEMTYPEDESC
            ssql = ssql & " kitchencode ='" & Trim(TxtKitchenCode.Text) & "',"
            ssql = ssql & " ShortName = '" & Trim(txtShort.Text) & "',ItemTypeCode='" & Trim(txtItemType.Text) & "',ITEMTYPEDESC='" & Trim(txtTypedes.Text) & "',"
            ssql = ssql & " GroupCode = '" & Trim(txtGroupcode.Text) & "',GROUPCODEDEC = '" & Trim(txtGroupDes.Text) & "',subGroupCode = '" & Trim(Txt_subcode.Text) & "',SUBGROUPDESC = '" & Trim(TXT_SUBDESC.Text) & "',Freeze = 'N',"
            'ssql = ssql & " SALESACCTIN = '" & Trim(txtAcctIn.Text) & "',"
            'ssql = ssql & " WEFDATE = '" & Format(dtp_WEFdate.Value, "dd/MMM/yyyy") & "',"
            '  ssql = ssql & " SALESSLCODE = '" & Trim(TxtSlcode.Text) & "',"
            ssql = ssql & " Multirate = '" & IIf(optYes.Checked = True, "Y", "N") & "',"
            ssql = ssql & " FBFLAG = '" & IIf(CHKFBYES.Checked = True, "Y", "N") & "',"
            ssql = ssql & " LWTFLAG = '" & IIf(CHKLOCYES.Checked = True, "Y", "N") & "',"
            ssql = ssql & " mrptag = '" & IIf(CHK_MRPTAG.Checked = True, "Y", "N") & "',"
            ssql = ssql & " mrpRate = " & Format(Val(txt_mrprate.Text), "0.00") & ","

            If OptNo.Checked = True Then

                ssql = ssql & " BaseUOMstd = '" & Trim(CmbUOm.Text) & "',BaseRatestd=" & Format(Val(txtRate.Text), "0.00") & ","
            Else
                ssql = ssql & " BaseUOMstd = '" & Trim(cbo_BaseUOM.Text) & "',BaseRatestd=" & Format(Val(txt_BaseRate.Text), "0.00") & ","
            End If
            ssql = ssql & " Openfacility = '" & IIf(ChkOPENITEMFACILITY.Checked = True, "Y", "N") & "',"
            ssql = ssql & " UPDATEUSER = '" & Trim(gUsername) & "', UPDATETIME ='" & Format(Now, "dd-MMM-yyyy") & "'"
            'If ChkPROMOT.Checked = True Then
            '    If OptNo.Checked = True Then
            '        ssql = ssql & " BaseUOM ='" & Trim(txtBaseUOM.Text) & "',"
            '        ssql = ssql & " BaseQty = " & Format(Val(txtBaseQty.Text), "0.00") & ","
            '        ssql = ssql & " BaseRate = " & Format(Val(txtBaseRate.Text), "0.00") & ","
            '        ssql = ssql & " PromItemcode='" & Trim(txtProItem.Text) & "',"
            '        vPromseqno = GetSeqno(txtProItem.Text)
            '        ssql = ssql & " PromItemseqno=" & Val(vPromseqno) & ", "
            '        If Trim(txtPromUOM.Text) <> "" Then
            '            ssql = ssql & " PromUOM= '" & Trim(txtPromUOM.Text) & "',"
            '        ElseIf Trim(cmbPromtUOM.Text) <> "" Then
            '            ssql = ssql & " PromUOM= '" & Trim(cmbPromtUOM.Text) & "',"
            '        End If
            '        ssql = ssql & " PromQty = " & Format(Val(txtPromQty.Text), "0.00") & ", PromRate = " & Format(Val(txtPromRate.Text), "0.00") & " , "
            '        ssql = ssql & " Startingdate = '" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "',Endingdate = '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "'"
            '    Else
            '        ssql = ssql & " BaseUOM ='" & Trim(cmbBaseUOM.Text) & "',"
            '        ssql = ssql & " BaseQty = " & Format(Val(txtBaseQty.Text), "0.00") & ","
            '        ssql = ssql & " BaseRate = " & Format(Val(txtBaseRate.Text), "0.00") & ","

            '        ssql = ssql & " PromItemcode='" & Trim(txtProItem.Text) & "',"
            '        vPromseqno = GetSeqno(txtProItem.Text)
            '        ssql = ssql & " PromItemseqno=" & Val(vPromseqno) & ","
            '        If Trim(txtPromUOM.Text) <> "" Then
            '            ssql = ssql & " PromUOM= '" & Trim(txtPromUOM.Text) & "',"
            '        ElseIf Trim(cmbPromtUOM.Text) <> "" Then
            '            ssql = ssql & " PromUOM= '" & Trim(cmbPromtUOM.Text) & "',"
            '        End If
            '        ssql = ssql & " PromQty = " & Format(Val(txtPromQty.Text), "0.00") & ", PromRate = " & Format(Val(txtPromRate.Text), "0.00") & " , "
            '        ssql = ssql & " Startingdate = '" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "',Endingdate = '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "'"
            '    End If
            'Else
            'ssql = ssql & " BaseUOM ='',"
            'ssql = ssql & " BaseQty = 0,BaseRate=0, PromItemcode='', "
            'ssql = ssql & " PromItemseqno=0, "
            'ssql = ssql & " PromUOM= '',"
            'ssql = ssql & " PromQty = 0, PromRate = 0, "
            'ssql = ssql & " Startingdate = '" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "',Endingdate = '" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "'"
            ' End If

            vseqno = GetSeqno(txtItemCode.Text)

            ssql = ssql & " WHERE ItemCodeseqno = " & (vseqno)
            insert(0) = ssql
            vseqno = GetSeqno(txtItemCode.Text)
            ssql = "DELETE FROM POSMenulink WHERE ItemCodeseqno=" & (vseqno)
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = ssql

            vseqno = GetSeqno(txtItemCode.Text)
            ssql = "DELETE FROM RATEMASTER WHERE ItemCodeseqno=" & (vseqno)
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = ssql
            'vstring = Format(vstring, "dd-MMM-yyyy")
            'If vstring = Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy") Then
            '    vDate = DateAdd(DateInterval.Day, -1, CDate(dtp_WEFdate.Value))
            '    ssql = "UPDATE Ratemaster SET Endingdate='" & Format(vDate, "dd-MMM-yyyy") & "' where ItemCodeseqno=" & (vseqno) & " And EndingDate is Null "
            'Else
            '    vDate = DateAdd(DateInterval.Day, -1, CDate(dtp_WEFdate.Value))
            '    ssql = "UPDATE Ratemaster SET Endingdate='" & Format(vDate, "dd-MMM-yyyy") & "' where ItemCodeseqno=" & (vseqno) & " And  EndingDate is Null  "
            'End If
            'ReDim Preserve insert(insert.Length)
            'insert(insert.Length - 1) = ssql
        End If
        count = 1
        For i = 0 To LstPOScode.Items.Count - 1
            If LstPOScode.GetItemChecked(i) = True Then
                VarPOSCODE = Split(LstPOScode.Items(i), "[")
                ssql = " INSERT INTO POSMenulink (ItemCodeseqno,Itemcode,POS,POSseqno) "
                vseqno = GetSeqno(txtItemCode.Text)
                ssql = ssql & " VALUES(" & (vseqno) & ", '" & Trim(txtItemCode.Text) & "'"
                vPOSno = GetSeqno(VarPOSCODE(0))
                ssql = ssql & " ,'" & VarPOSCODE(0) & "' , " & Val(vPOSno) & ")"
                If Mid(CmdAdd.Text, 1, 1) = "U" Then
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = ssql
                Else
                    If count > 1 Then
                        ReDim Preserve insert(insert.Length)
                    End If
                    insert(insert.Length - 1) = ssql
                    count = count + 1
                End If
            End If
        Next
        If optNo.Checked = True Then
            Call InsertPromotional(insert)
        Else
            Call InsertGridYes(insert)
        End If
        Call CmdClear_Click(CmdClear, e)
    End Sub
    Private Sub InsertPromotional(ByVal Insert() As String)
        ''****************************************** IF MULTIRATE IS 'NO' *****************************************''''
        Dim vsql, vPromSeqno As String
        '  If ChkPROMOT.Checked = True Then
        ''******************************** $ IF MULTIRATE IS 'NO' AND PROMTIONAL IS 'YES' $ ***********************'''
        'If Mid(CmdAdd.Text, 1, 1) = "A" Then
        '    vseqno = GetSeqno(txtItemCode.Text)
        '    ssql = "INSERT INTO ItemMaster(ItemCodeseqno,ItemCode,Shortname,CATEGORY,kitchencode,STORECODE,SUBSCODE,ItemDesc,ItemTypeCode,ItemTypeseqno,GroupCode,subgroupcode,"
        '    ssql = ssql & " groupseqno,Freeze,Multirate,Promotional,BaseUomStd,BaseRateStd,Openfacility,BaseRate,mrptag,MRPRate,BaseUOM,BaseQty,PromItemseqno,"
        '    ssql = ssql & " PromItemCode,PromUOM,PromQty,PromRate,Startingdate,Endingdate,AddUserId,AddDateTime,SalesAcctin,SalesSLCODE,WEFDATE)"
        '    ssql = ssql & " VALUES(" & (vseqno) & ","
        '    ssql = ssql & " '" & Trim(txtItemCode.Text) & "','" & Trim(txtShort.Text) & "',"
        '    ssql = ssql & " '" & Trim(CBO_CATEGORY.Text) & "','" & Trim(TxtKitchenCode.Text) & "','" & Trim(TxtKitchenCode.Text) & "','" & Trim(CBO_SUBSCODE.Text) & "',"
        '    ssql = ssql & " '" & Replace(Trim(txtItemDesc.Text), "'", "") & "','" & Trim(txtItemType.Text) & "',"
        '    vseqno = GetSeqno(txtItemType.Text)
        '    ssql = ssql & " " & (vseqno) & ","
        '    ssql = ssql & " '" & Trim(txtGroupcode.Text) & "','" & Trim(Txt_subcode.Text) & "',"
        '    vseqno = GetSeqno(txtGroupcode.Text)
        '    ssql = ssql & " " & (vseqno) & ",'N','N','Y',"
        '    If OptNo.Checked = True Then
        '        ssql = ssql & " '" & Trim(CmbUOm.Text) & "'," & Format(Val(txtRate.Text), "0.00") & ","
        '    Else
        '        ssql = ssql & " '" & Trim(cbo_BaseUOM.Text) & "'," & Format(Val(txt_BaseRate.Text), "0.00") & ","
        '    End If
        '    If ChkOPENITEMFACILITY.Checked = True Then
        '        ssql = ssql & " 'Y',"
        '    Else
        '        ssql = ssql & " 'N',"
        '    End If
        '    ssql = ssql & " " & Format(Val(txtBaseRate.Text), "0.00") & ","
        '    If CHK_MRPTAG.Checked = True Then
        '        ssql = ssql & " 'Y',"
        '    Else
        '        ssql = ssql & " 'N',"
        '    End If
        '    ssql = ssql & " " & Format(Val(txt_mrprate.Text), "0.00") & ","
        '    If OptNo.Checked = True Then
        '        ssql = ssql & "'" & Trim(txtBaseUOM.Text) & "'," & Format(Val(txtBaseQty.Text), "0.00") & ","
        '    Else
        '        ssql = ssql & "'" & Trim(cmbBaseUOM.Text) & "'," & Format(Val(txtBaseQty.Text), "0.00") & ","
        '    End If
        '    vPromSeqno = GetSeqno(txtProItem.Text)
        '    ssql = ssql & "" & Val(vPromSeqno) & ",'" & Trim(txtProItem.Text) & "',"
        '    If Trim(txtPromUOM.Text) <> "" Then
        '        ssql = ssql & "'" & Trim(txtPromUOM.Text) & "'," & Format(Val(txtPromQty.Text), "0.00") & ","
        '    Else
        '        ssql = ssql & "'" & Trim(cmbPromtUOM.Text) & "'," & Format(Val(txtPromQty.Text), "0.00") & ","
        '    End If
        '    ssql = ssql & "" & Val(txtPromRate.Text) & ","
        '    ssql = ssql & "'" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "',"
        '    ssql = ssql & "'" & Format(mskToDate.Value, "dd-MMM-yyyy") & "',"
        '    ssql = ssql & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','" & txtAcctIn.Text & "','" & TxtSlcode.Text & "','" & Format(dtp_WEFdate.Value, "dd/MMM/yyyy") & "')"
        '    ReDim Preserve Insert(Insert.Length)
        '    Insert(Insert.Length - 1) = ssql
        'End If
        ''vseqno = GetSeqno(txtItemCode.Text)
        ''ssql = " INSERT INTO RateMaster(WithEffectFrom,ItemCodeseqno,ItemCode,UOM,ItemRate,purcahseRate,MRPRate,"
        ''ssql = ssql & " Startingdate,Freeze,AddUserId,AddDateTime)"
        ''ssql = ssql & " VALUES('" & Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy") & "'," & (vseqno) & ","
        ''ssql = ssql & " '" & Trim(txtItemCode.Text) & "','" & Trim(CmbUOm.Text) & "',"
        ''ssql = ssql & " " & Format(Val(txtRate.Text), "0.00") & "," & Format(Val(txtPurchaseRate.Text), "0.00") & "," & Format(Val(txt_mrprate.Text), "0.00") & ","
        ''ssql = ssql & " '" & Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy") & "','N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"
        ''ReDim Preserve Insert(Insert.Length)
        ''Insert(Insert.Length - 1) = ssql
        ''pardhu


        'Dim VarPOSCODE(), vPOSno() As String
        'Dim count As Integer
        'count = 1
        'For i = 0 To LstPOScode.Items.Count - 1
        '    If LstPOScode.GetItemChecked(i) = True Then
        '        VarPOSCODE = Split(LstPOScode.Items(i), "[")
        '        vseqno = GetSeqno(txtItemCode.Text)
        '        'ssql = " INSERT INTO POSMenulink (ItemCodeseqno,Itemcode,POS,POSseqno) "
        '        ssql = " INSERT INTO RateMaster(WithEffectFrom,ItemCodeseqno,ItemCode,UOM,ItemRate,purcahseRate,MRPRate,pritemrate,"
        '        ssql = ssql & " Startingdate,AddUserId,AddDateTime,rposcode)"
        '        ssql = ssql & " VALUES('" & Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy") & "'," & (vseqno) & ","
        '        ssql = ssql & " '" & Trim(txtItemCode.Text) & "','" & Trim(CmbUOm.Text) & "',"
        '        ssql = ssql & " " & Format(Val(txtRate.Text), "0.00") & "," & Format(Val(txtPurchaseRate.Text), "0.00") & "," & Format(Val(txt_mrprate.Text), "0.00") & " 0.00,"
        '        ssql = ssql & " '" & Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy") & "','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "'"

        '        'ssql = ssql & " VALUES(" & (vseqno) & ", '" & Trim(txtItemCode.Text) & "'"
        '        vPOSno = GetSeqno(VarPOSCODE(0))
        '        ssql = ssql & " ,'" & VarPOSCODE(0) & "' )"
        '        If Mid(CmdAdd.Text, 1, 1) = "U" Then
        '            ReDim Preserve Insert(Insert.Length)
        '            Insert(Insert.Length - 1) = ssql
        '        Else
        '            'If count > 1 Then
        '            ReDim Preserve Insert(Insert.Length)
        '            'End If
        '            Insert(Insert.Length - 1) = ssql
        '            count = count + 1
        '        End If
        '    End If
        'Next
        ''pardhu
        ' Else
        ''******************************** $ IF MULTIRATE IS 'NO' AND PROMTIONAL IS 'NO' $ ***********************'''
        If Mid(CmdAdd.Text, 1, 1) = "A" Then
            vseqno = GetSeqno(txtItemCode.Text)
            ssql = "INSERT INTO ItemMaster(ItemCodeseqno,ItemCode,ShortName,Category,STORECODE,ItemDesc,ItemTypeCode,ITEMTYPEDESC,ItemTypeseqno,GroupCode,GROUPCODEDEC,subGroupCode,SUBGROUPDESC,FBFLAG,LWTFLAG,Openfacility,Groupseqno,"
            ssql = ssql & " Freeze,Multirate,BaseUOMstd,BaseRatestd,BaseRate,mrptag,MRPRate,BaseUOM,BaseQty,StockControl,PromItemcode,"
            ssql = ssql & " PromItemseqno,PromUOM,PromQty,PromRate,AddUserId,AddDateTime,StartingDate)"
            vseqno = GetSeqno(txtItemCode.Text)
            ssql = ssql & " VALUES(" & Trim(vseqno) & ","
            ssql = ssql & " '" & Trim(txtItemCode.Text) & "','" & Trim(txtShort.Text) & "',"
            ssql = ssql & " '" & Trim(CBO_CATEGORY.Text) & "','" & Trim(TxtKitchenCode.Text) & "',"
            ssql = ssql & " '" & Replace(Trim(txtItemDesc.Text), "'", "") & "','" & Trim(txtItemType.Text) & "','" & Trim(txtTypedes.Text) & "',"
            vseqno = GetSeqno(txtItemType.Text)
            ssql = ssql & " " & Trim(vseqno) & ",'" & Trim(txtGroupcode.Text) & "','" & Trim(txtGroupDes.Text) & "','" & Trim(Txt_subcode.Text) & "','" & Trim(TXT_SUBDESC.Text) & "',"
            If CHKFBYES.Checked = True Then
                ssql = ssql & " 'Y',"
            Else
                ssql = ssql & " 'N',"
            End If
            If CHKLOCYES.Checked = True Then
                ssql = ssql & " 'Y',"
            Else
                ssql = ssql & " 'N',"
            End If
            If ChkOPENITEMFACILITY.Checked = True Then
                ssql = ssql & " 'Y',"
            Else
                ssql = ssql & " 'N',"
            End If
            vseqno = GetSeqno(txtGroupcode.Text)
            ssql = ssql & "" & Trim(vseqno) & ",'N','N',"
            If optNo.Checked = True Then
                ssql = ssql & " '" & Trim(CmbUOm.Text) & "'," & Format(Val(txtRate.Text), "0.00") & ","
            Else
                ssql = ssql & " '" & Trim(cbo_BaseUOM.Text) & "'," & Format(Val(txt_BaseRate.Text), "0.00") & ","
            End If
            ssql = ssql & " 0,"
            If CHK_MRPTAG.Checked = True Then
                ssql = ssql & " 'Y',"
            Else
                ssql = ssql & " 'N',"
            End If
          
            ssql = ssql & "" & Format(Val(txt_mrprate.Text), "0.00") & ",'',0,'','',0,'',0,0,'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "'," ','" & Format(Now, "dd-MMM-yyyy") & "',"
            ssql = ssql & " '" & Format(Now, "dd-MMM-yyyy") & "')"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = ssql
        End If
        'pardhu
        Dim VarPOSCODE(), vPOSno() As String
        Dim count As Integer
        count = 1
        For i = 0 To LstPOScode.Items.Count - 1
            If LstPOScode.GetItemChecked(i) = True Then
                VarPOSCODE = Split(LstPOScode.Items(i), "[")
                vseqno = GetSeqno(txtItemCode.Text)
                'ssql = " INSERT INTO POSMenulink (ItemCodeseqno,Itemcode,POS,POSseqno) "
                ssql = " INSERT INTO RateMaster(ItemCodeseqno,ItemCode,UOM,ItemRate,PRITEMRATE,purcahseRate,MRPRate,"
                ssql = ssql & " Startingdate,AddUserId,AddDateTime,rposcode)"
                ssql = ssql & " VALUES( " & (vseqno) & ","
                ssql = ssql & " '" & Trim(txtItemCode.Text) & "','" & Trim(CmbUOm.Text) & "',"
                ssql = ssql & " " & Format(Val(txtRate.Text), "0.00") & ",0.00,"
                'ssql = ssql & "0.00,"
                ssql = ssql & "" & Format(Val(txtPurchaseRate.Text), "0.00") & "," & Format(Val(txt_mrprate.Text), "0.00") & ","
                ssql = ssql & " '" & Format(Now, "dd-MMM-yyyy") & "','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "'"

                'ssql = ssql & " VALUES(" & (vseqno) & ", '" & Trim(txtItemCode.Text) & "'"
                'vPOSno = GetSeqno(VarPOSCODE(0))
                ssql = ssql & " ,'" & VarPOSCODE(0) & "' )"
                If Mid(CmdAdd.Text, 1, 1) = "U" Then
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = ssql
                Else
                    'If count > 1 Then
                    ReDim Preserve Insert(Insert.Length)
                    'End If
                    Insert(Insert.Length - 1) = ssql
                    count = count + 1
                End If
            End If
        Next
        'vseqno = GetSeqno(txtItemCode.Text)
        'ssql = "INSERT INTO RateMaster(WithEffectFrom,ItemCodeseqno,ItemCode,UOM,ItemRate,purcahseRate,MRPRate,"
        'ssql = ssql & " Startingdate,Freeze,AddUserId,AddDateTime,rposcode)"
        'ssql = ssql & " VALUES('" & Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy") & "'," & Trim(vseqno) & ","
        'ssql = ssql & " '" & Trim(txtItemCode.Text) & "','" & Trim(CmbUOm.Text) & "',"
        'ssql = ssql & " " & Format(Val(txtRate.Text), "0.00") & "," & Format(Val(txtPurchaseRate.Text), "0.00") & "," & Format(Val(txt_mrprate.Text), "0.00") & ","
        'ssql = ssql & " '" & Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy") & "','N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "',"
        'Dim count As Integer = 1
        'Dim VarPOSCODE()
        'For i = 0 To LstPOScode.Items.Count - 1
        '    If LstPOScode.GetItemChecked(i) = True Then
        '        VarPOSCODE = Split(LstPOScode.Items(i), "[")
        '        ssql = ssql & "'" & VarPOSCODE(0) & "')"
        '    End If
        '    If Mid(CmdAdd.Text, 1, 1) = "U" Then
        '        ReDim Preserve Insert(Insert.Length)
        '        Insert(Insert.Length - 1) = ssql
        '    Else
        '        If count > 1 Then
        '            ReDim Preserve Insert(Insert.Length)
        '        End If
        '        Insert(Insert.Length - 1) = ssql
        '        count = count + 1
        '    End If
        '        Next
        'ReDim Preserve Insert(Insert.Length)
        'Insert(Insert.Length - 1) = ssql
        'count = 1
        'For i = 0 To LstPOScode.Items.Count - 1
        '    If LstPOScode.GetItemChecked(i) = True Then
        '        VarPOSCODE = Split(LstPOScode.Items(i), "[")
        '        ssql = " INSERT INTO POSMenulink (ItemCodeseqno,Itemcode,POS,POSseqno) "
        '        vseqno = GetSeqno(txtItemCode.Text)
        '        ssql = ssql & " VALUES(" & (vseqno) & ", '" & Trim(txtItemCode.Text) & "'"
        '        vPOSno = GetSeqno(VarPOSCODE(0))
        '        ssql = ssql & " ,'" & VarPOSCODE(0) & "' , " & Val(vPOSno) & ")"
        '        If Mid(CmdAdd.Text, 1, 1) = "U" Then
        '            ReDim Preserve Insert(Insert.Length)
        '            Insert(Insert.Length - 1) = ssql
        '        Else
        '            If count > 1 Then
        '                ReDim Preserve Insert(Insert.Length)
        '            End If
        '            Insert(Insert.Length - 1) = ssql
        '            count = count + 1
        '        End If
        '    End If
        '

        ' End If
        vconn.MoreTransold(Insert)
    End Sub
    Private Sub InsertGridYes(ByVal Insert() As String)
        '''****************************************** IF MULTIRATE IS 'NO' *****************************************''''
        'Dim vPromSeqno As Double
        'Dim vUOM, vRate As String
        vseqno = GetSeqno(txtItemCode.Text)
        'If ChkPROMOT.Checked = True Then
        ' '''******************************** $ IF MULTIRATE IS 'YES' AND PROMTIONAL IS 'YES' $ ***********************'''
        'If Mid(CmdAdd.Text, 1, 1) = "A" Then
        '    vseqno = GetSeqno(txtItemCode.Text)
        '    ssql = " INSERT INTO ItemMaster(ItemCodeseqno,ItemCode,Shortname,category,Subscode,ItemDesc,ItemTypeCode,ItemTypeseqno,GroupCode,subgroupcode"
        '    ssql = ssql & " ,groupseqno,Freeze,Multirate,BaseUOMstd,BaseRatestd,Promotional,BaseRate,mrptag,MRPRate,BaseUOM,BaseQty,Openfacility,PromItemseqno"
        '    ssql = ssql & " ,PromItemCode,PromUOM,PromQty,PromRate,Startingdate,Endingdate,AddUserId,AddDateTime,SALESACCTIN,SALESSLCODE,wefdate,STORECODE)"
        '    ssql = ssql & " VALUES(" & (vseqno) & ","
        '    ssql = ssql & " '" & Trim(txtItemCode.Text) & "','" & Trim(txtShort.Text) & "',"
        '    ssql = ssql & " '" & Trim(CBO_CATEGORY.Text) & "','" & Trim(CBO_SUBSCODE.Text) & "',"
        '    ssql = ssql & " '" & Replace(Trim(txtItemDesc.Text), "'", "") & "','" & Trim(txtItemType.Text) & "',"
        '    vseqno = GetSeqno(txtItemType.Text)
        '    ssql = ssql & " " & Val(vseqno) & ","
        '    ssql = ssql & " '" & Trim(txtGroupcode.Text) & "','" & Trim(Txt_subcode.Text) & "',"
        '    vseqno = GetSeqno(txtGroupcode.Text)
        '    ssql = ssql & " " & (vseqno) & ",'N','Y',"
        '    ssql = ssql & " '" & Trim(cbo_BaseUOM.Text) & "',"
        '    ssql = ssql & " " & Format(Val(txt_BaseRate.Text), "0.00") & ",'Y',"
        '    ssql = ssql & " " & Format(Val(txtBaseRate.Text), "0.00") & ","
        '    If CHK_MRPTAG.Checked = True Then
        '        ssql = ssql & " 'Y',"
        '    Else
        '        ssql = ssql & " 'N',"
        '    End If
        '    ssql = ssql & "" & Format(Val(txt_mrprate.Text), "0.00") & ","
        '    If txtBaseUOM.Visible = True Then
        '        ssql = ssql & " '" & Trim(txtBaseUOM.Text) & "'," & Format(Val(txtBaseQty.Text), "0.00") & ","
        '    Else
        '        ssql = ssql & " '" & Trim(cmbBaseUOM.Text) & "'," & Format(Val(txtBaseQty.Text), "0.00") & ","
        '    End If
        '    If ChkOPENITEMFACILITY.Checked = True Then
        '        ssql = ssql & " 'Y',"
        '    Else
        '        ssql = ssql & " 'N',"
        '    End If
        '    vPromSeqno = GetSeqno(txtProItem.Text)
        '    ssql = ssql & " " & Val(vPromSeqno) & ",'" & Trim(txtProItem.Text) & "',"
        '    If Trim(txtPromUOM.Text) = "" Then
        '        ssql = ssql & " '" & Trim(cmbPromtUOM.Text) & "'," & Format(Val(txtPromQty.Text), "0.00") & ","
        '    Else
        '        ssql = ssql & " '" & Trim(txtPromUOM.Text) & "'," & Format(Val(txtPromQty.Text), "0.00") & ","
        '    End If
        '    ssql = ssql & " " & Format(Val(txtPromRate.Text), "0.00") & ","
        '    ssql = ssql & " '" & Format(mskFromDate.Value, "dd-MMM-yyyy") & "',"
        '    ssql = ssql & " '" & Format(mskToDate.Value, "dd-MMM-yyyy") & "','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(txtAcctIn.Text) & "','" & Trim(TxtSlcode.Text) & "','" & Format(dtp_WEFdate.Value, "dd/MMM/yyyy") & "','" & Trim(TxtKitchenCode.Text) & "')"
        '    ReDim Preserve Insert(Insert.Length)
        '    Insert(Insert.Length - 1) = ssql
        'End If
        'With ssgrid
        '    For i = 1 To .DataRowCnt
        '        vseqno = GetSeqno(txtItemCode.Text)
        '        ssql = "INSERT INTO RateMaster(WithEffectFrom,ItemCodeseqno,ItemCode,UOM,ItemRate,MRPRate,Startingdate,Freeze,"
        '        ssql = ssql & " purcahseRate,AddUserId,AddDateTime)"
        '        ssql = ssql & " VALUES('" & Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy") & "'," & Trim(vseqno) & ","
        '        ssql = ssql & " '" & txtItemCode.Text & "',"
        '        .Row = i
        '        .Col = 3
        '        ssql = ssql & " '" & Trim(.Text) & "',"
        '        .Col = 4
        '        ssql = ssql & " " & Format(Val(.Text), "0.00") & ","
        '        .Col = 6
        '        ssql = ssql & " " & Format(Val(.Text), "0.00") & ","
        '        ssql = ssql & " '" & Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy") & "','N',"
        '        ssql = ssql & " 0,'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"
        '        ReDim Preserve Insert(Insert.Length)
        '        Insert(Insert.Length - 1) = ssql
        '    Next i
        'End With
        ' ElseIf ChkPROMOT.Checked = False Then
        ''******************************** $ IF MULTIRATE IS 'YES' AND PROMTIONAL IS 'NO' $ ***********************'''
        If Mid(CmdAdd.Text, 1, 1) = "A" Then
            vseqno = GetSeqno(txtItemCode.Text)
            ssql = "INSERT INTO ItemMaster(ItemCodeseqno,ItemCode,ShortName,Category,STORECODE,ItemDesc,ItemTypeCode,ITEMTYPEDESC,ItemTypeseqno,GroupCode,GROUPCODEDEC,subGroupCode,SUBGROUPDESC,FBFLAG,LWTFLAG,Openfacility,Groupseqno,"
            ssql = ssql & " Freeze,MultiRate,BaseUOMstd,BaseRatestd,BaseRate,mrptag,MRPRate,BaseUOM,BaseQty,StockControl,PromItemcode,"
            ssql = ssql & " PromItemseqno,PromUOM,PromQty,PromRate,AddUserId,AddDateTime,StartingDate,EndingDate)"
            ssql = ssql & " VALUES(" & Trim(vseqno) & ",'" & Trim(txtItemCode.Text) & "','" & Trim(txtShort.Text) & "',"
            ssql = ssql & " '" & Trim(CBO_CATEGORY.Text) & "','" & Trim(TxtKitchenCode.Text) & "',"
            ssql = ssql & " '" & Replace(Trim(txtItemDesc.Text), "'", " ") & "','" & Trim(txtItemType.Text) & "','" & Trim(txtTypedes.Text) & "',"
            vseqno = GetSeqno(txtItemType.Text)
            ssql = ssql & " " & Trim(vseqno) & ","
            ssql = ssql & " '" & Trim(txtGroupcode.Text) & "','" & Trim(txtGroupDes.Text) & "','" & Trim(Txt_subcode.Text) & "','" & Trim(TXT_SUBDESC.Text) & "',"
            If CHKFBYES.Checked = True Then
                ssql = ssql & " 'Y',"
            Else
                ssql = ssql & " 'N',"
            End If
            If CHKLOCYES.Checked = True Then
                ssql = ssql & " 'Y',"
            Else
                ssql = ssql & " 'N',"
            End If
            If ChkOPENITEMFACILITY.Checked = True Then
                ssql = ssql & " 'Y',"
            Else
                ssql = ssql & " 'N',"
            End If
            vseqno = GetSeqno(txtGroupcode.Text)
            ssql = ssql & " " & Trim(vseqno) & ","
            ssql = ssql & " 'N','Y','" & Trim(cbo_BaseUOM.Text) & "'," & Format(Val(txt_BaseRate.Text), "0.00") & ","
            ssql = ssql & " 0,"
            If CHK_MRPTAG.Checked = True Then
                ssql = ssql & " 'Y',"
            Else
                ssql = ssql & " 'N',"
            End If
            ssql = ssql & "" & Format(Val(txt_mrprate.Text), "0.00") & ",'',0,'','',0,'',0,0,'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "','" & Format(Now, "dd-MMM-yyyy") & "',"
            ssql = ssql & " '" & Format(Now, "dd-MMM-yyyy") & "')"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = ssql

            Dim VarPOSCODE(), vPOSno() As String
            Dim count, j, i As Integer
            count = 1
            For j = 0 To LstPOScode.Items.Count - 1
                If LstPOScode.GetItemChecked(j) = True Then
                    'Dim count, i As Integer
                    For i = 1 To ssgrid.DataRowCnt
                        '    With ssgrid
                        '        vseqno = GetSeqno(txtItemCode.Text)
                        '        ssql = "INSERT INTO RateMaster(WithEffectFrom,ItemCodeseqno,ItemCode,UOM,ItemRate,MRPRate,Startingdate,Freeze,"
                        '        ssql = ssql & " purcahseRate,AddUserId,AddDateTime)"
                        '        ssql = ssql & " VALUES('" & Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy") & "'," & Trim(vseqno) & ",'" & Trim(txtItemCode.Text) & "',"
                        '        .Row = i
                        '        .Col = 3
                        '        ssql = ssql & "'" & Trim(.Text) & "',"
                        '        .Col = 4
                        '        ssql = ssql & " " & Format(Val(.Text), "0.00") & ","
                        '        .Col = 6
                        '        ssql = ssql & " " & Format(Val(.Text), "0.00") & ","
                        '        ssql = ssql & " '" & Format(CDate(dtp_WEFdate.Value), "dd-MMM-yyyy") & "','N',"
                        '        ssql = ssql & " 0,'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"
                        '        ReDim Preserve Insert(Insert.Length)
                        '        Insert(Insert.Length - 1) = ssql
                        '    End With
                        'Next i
                        'pardhu


                        With ssgrid
                            VarPOSCODE = Split(LstPOScode.Items(j), "[")
                            vseqno = GetSeqno(txtItemCode.Text)
                            'ssql = " INSERT INTO POSMenulink (ItemCodeseqno,Itemcode,POS,POSseqno) "
                            ssql = " INSERT INTO RateMaster(ItemCodeseqno,ItemCode,UOM,ItemRate,MRPRate,purcahseRate,PritemRate,"
                            ssql = ssql & " Startingdate,AddUserId,AddDateTime,rposcode)"
                            ssql = ssql & " VALUES(" & (vseqno) & ","
                            ssql = ssql & " '" & Trim(txtItemCode.Text) & "'," '" & Trim(CmbUOm.Text) & "',"
                            .Row = i
                            .Col = 3
                            ssql = ssql & "'" & Trim(.Text) & "',"
                            .Col = 4
                            ssql = ssql & " " & Format(Val(.Text), "0.00") & ","
                           
                            .Col = 5
                            ssql = ssql & " " & Format(Val(.Text), "0.00") & ","
                            .Col = 5
                            ssql = ssql & " " & Format(Val(.Text), "0.00") & ","
                            ssql = ssql & " 0.00," '& Format(Val(txt_mrprate.Text), "0.00") & ","
                            'ssql = ssql & " " & 0.00,
                            ssql = ssql & " '" & Format(Now, "dd-MMM-yyyy") & "','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "'"

                            'ssql = ssql & " VALUES(" & (vseqno) & ", '" & Trim(txtItemCode.Text) & "'"
                            'vPOSno = GetSeqno(VarPOSCODE(0))
                            ssql = ssql & " ,'" & VarPOSCODE(0) & "' )"
                            If Mid(CmdAdd.Text, 1, 1) = "U" Then
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = ssql
                            Else
                                'If count > 1 Then
                                ReDim Preserve Insert(Insert.Length)
                                'End If
                                Insert(Insert.Length - 1) = ssql
                                count = count + 1
                            End If
                            'End If

                        End With


                    Next i
                End If
            Next
        ElseIf Mid(CmdAdd.Text, 1, 1) = "U" Then
            Dim VarPOSCODE(), vPOSno() As String
            Dim count, j, i As Integer
            count = 1
            For i = 1 To ssgrid.DataRowCnt
                With ssgrid
                    'VarPOSCODE = Split(LstPOScode.Items(j), "[")
                    vseqno = GetSeqno(txtItemCode.Text)
                    'ssql = " INSERT INTO POSMenulink (ItemCodeseqno,Itemcode,POS,POSseqno) "
                    ssql = " INSERT INTO RateMaster(ItemCodeseqno,ItemCode,UOM,ItemRate,MRPRate,purcahseRate,PritemRate,"
                    ssql = ssql & " Startingdate,AddUserId,AddDateTime,rposcode)"
                    ssql = ssql & " VALUES(" & (vseqno) & ","
                    ssql = ssql & " '" & Trim(txtItemCode.Text) & "'," '" & Trim(CmbUOm.Text) & "',"
                    .Row = i
                    .Col = 3
                    ssql = ssql & "'" & Trim(.Text) & "',"
                    .Col = 4
                    ssql = ssql & " " & Format(Val(.Text), "0.00") & ","
                    .Col = 5
                    ssql = ssql & " " & Format(Val(.Text), "0.00") & ","
                    .Col = 5
                    ssql = ssql & " " & Format(Val(.Text), "0.00") & ","
                    ssql = ssql & " 0.00," '& Format(Val(txt_mrprate.Text), "0.00") & ","
                    'ssql = ssql & " " & 0.00,
                    ssql = ssql & " '" & Format(Now, "dd-MMM-yyyy") & "','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "',"

                    'ssql = ssql & " VALUES(" & (vseqno) & ", '" & Trim(txtItemCode.Text) & "'"
                    'vPOSno = GetSeqno(VarPOSCODE(0))
                    ' ssql = ssql & " ,'" & VarPOSCODE(0) & "' )"
                    .Row = i
                    .Col = 6
                    ssql = ssql & "'" & Trim(.Text) & "')"
                    If Mid(CmdAdd.Text, 1, 1) = "U" Then
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = ssql
                    Else
                        'If count > 1 Then
                        ReDim Preserve Insert(Insert.Length)
                        'End If
                        Insert(Insert.Length - 1) = ssql
                        count = count + 1
                    End If
                    'End If

                End With


            Next i
            'End If
            ' Next
            ' Next
        End If

        ' End If
        vconn.MoreTransold(Insert)
    End Sub



   

   
    Private Sub txtItemDesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtShort.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txtShort.Focus()
        End If
    End Sub

    Private Sub txtShort_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShort.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtItemType.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txtItemType.Focus()
        End If
    End Sub




    Private Sub cmdType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdType.Click
        Try
            Dim vform As New LIST_OPERATION1


            gSQLString = "SELECT ISNULL(CHARGECODE,'') AS CHARGECODE,ISNULL(CHARGEDESC,'') AS CHARGEDESC  FROM CHARGEMASTER  WHERE "
            M_WhereCondition = " ISNULL(RATE,0)= 0   AND ISNULL(Freeze,'') <> 'Y' "
            vform.Field = "CHARGECODE,CHARGEDESC"
            'vform.Frmcalled = "  CHARGECODE  | CHARGE DESCRIPTION          |                                  "
            vform.vCaption = "Charge Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtItemType.Text = Trim(vform.keyfield & "")
                txtItemType.Select()
                txtItemType_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub CHKFBYES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CHKFBYES.KeyDown
        If e.KeyCode = Keys.Enter Then
            CHKFBNO.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CHKFBNO.Focus()
        End If
    End Sub

    Private Sub CHKFBNO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CHKFBNO.KeyDown
        If e.KeyCode = Keys.Enter Then
            CHKLOCYES.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CHKLOCYES.Focus()
        End If
    End Sub

    Private Sub CHKLOCYES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CHKLOCYES.KeyDown
        If e.KeyCode = Keys.Enter Then
            CHKLOCNO.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CHKLOCNO.Focus()
        End If
    End Sub

    Private Sub CHKLOCNO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CHKLOCNO.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtKitchenCode.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            TxtKitchenCode.Focus()
        End If
    End Sub

    Private Sub LstPOScode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstPOScode.KeyDown
        If e.KeyCode = Keys.Enter Then
            optYes.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            optYes.Focus()
        End If
    End Sub

    Private Sub CHKFBYES_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKFBYES.CheckedChanged
        If CHKFBYES.Checked = True Then
            CHKFBNO.Checked = False
        Else
            CHKFBNO.Checked = True
        End If
    End Sub

    Private Sub CHKFBNO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKFBNO.CheckedChanged
        If CHKFBNO.Checked = True Then
            CHKFBYES.Checked = False
        Else
            CHKFBYES.Checked = True
        End If
    End Sub

    Private Sub CHKLOCYES_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKLOCYES.CheckedChanged
        If CHKLOCYES.Checked = True Then
            CHKLOCNO.Checked = False
        Else
            CHKLOCNO.Checked = True
        End If
    End Sub

    Private Sub CHKLOCNO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKLOCNO.CheckedChanged
        If CHKLOCNO.Checked = True Then
            CHKLOCYES.Checked = False
        Else
            CHKLOCYES.Checked = True
        End If
    End Sub

    Private Sub optNo_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles optNo.Click
        If optNo.Checked = True Then
            FraGrid.Visible = False
            FraRate.Visible = True
            optNo.Focus()
        End If
    End Sub

    Private Sub optNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles optNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPurchaseRate.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txtPurchaseRate.Focus()
        End If
    End Sub

    Private Sub txtPurchaseRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPurchaseRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRate.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txtRate.Focus()
        End If
    End Sub

    Private Sub txtPurchaseRate_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPurchaseRate.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'for ne decimal point
        If (e.KeyChar = "."c AndAlso (txtPurchaseRate).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            CHK_MRPTAG.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CHK_MRPTAG.Focus()
        End If
    End Sub

    Private Sub CHK_MRPTAG_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CHK_MRPTAG.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_mrprate.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            txt_mrprate.Focus()
        End If
    End Sub

    Private Sub CHK_MRPTAG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_MRPTAG.CheckedChanged

    End Sub

    Private Sub CmbUOm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbUOm.KeyDown
        If e.KeyCode = Keys.Enter Then
            ChkOPENITEMFACILITY.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            ChkOPENITEMFACILITY.Focus()
        End If
    End Sub

    Private Sub optYes_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles optYes.Click
        If optYes.Checked = True Then
            FraRate.Visible = False
            FraGrid.Visible = True
            Call GridUOM(ssgrid.ActiveRow) ''---> Fill the UOM feild
        End If
    End Sub

    Private Sub ssgrid_KeyDownEvent1(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        If e.keyCode = Keys.F3 Then
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.ClearRange(1, ssgrid.ActiveRow, 5, ssgrid.ActiveRow, True)
            ssgrid.DeleteRows(ssgrid.ActiveRow, 1)
            ssgrid.ActiveRow = ssgrid.Row - 1
            ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
            ssgrid.Focus()
        End If
    End Sub

    Private Sub ssgrid_KeyPressEvent1(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyPressEvent) Handles ssgrid.KeyPressEvent
        If Asc(e.keyAscii) = 13 Or ssgrid.ActiveCol = 1 Then
            If optYes.Checked = True Then
                ssgrid.SetText(1, ssgrid.ActiveRow, Trim(txtItemCode.Text))
                ssgrid.SetText(2, ssgrid.ActiveRow, Trim(txtItemDesc.Text))
                Call GridUOM(ssgrid.ActiveRow)
            End If
        End If
    End Sub

    Private Sub cmdexit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub optYes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles optYes.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbo_BaseUOM.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            cbo_BaseUOM.Focus()
        End If
    End Sub

    Private Sub Cmdview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtPurchaseRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPurchaseRate.TextChanged

    End Sub

    Private Sub txtRate_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'for ne decimal point
        If (e.KeyChar = "."c AndAlso (txtRate).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.TextChanged

    End Sub

    Private Sub txt_mrprate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mrprate.TextChanged

    End Sub

    Private Sub Cmdview_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdview.Click
        Dim FRM As New ReportDesigner
        If txtItemCode.Text.Length > 0 Then
            tables = " FROM ITEMMASTER WHERE ITEMCODE ='" & txtItemCode.Text & "' "
        Else
            tables = "FROM ITEMMASTER "
        End If
        Gheader = "ITEMMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"ITEMCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ITEMDESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ITEMTYPECODE", "12"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CATEGORY", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GROUPCODE", "5"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GROUPCODEDEC", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SUBGROUPCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SUBGROUPDESC", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"BASEUOMSTD", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"BASERATESTD", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"OPENFACILITY", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"STORECODE", "9"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"MRPRATE", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"roundval", "7"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FREEZE", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSERID", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDDATETIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATETIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub Cmdbwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbwse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM ITEMMASTER"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM ITEMMASTER", "SERIALNO", 0)

    End Sub

    Private Sub Cmdauth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdauth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            GCONNECTION.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                GCONNECTION.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
                    GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
                    If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                        Dim VIEW1 As New AUTHORISATION
                        VIEW1.Show()
                        VIEW1.DTAUTH.DataSource = Nothing
                        VIEW1.DTAUTH.Rows.Clear()
                        'Dim STRQUERY As String
                        'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                        ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                        'gconnection.getDataSet(STRQUERY, "authorize")

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE ITEMMASTER set  ", "ITEMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                GCONNECTION.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    GCONNECTION.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
                        GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            'Dim STRQUERY As String
                            'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                            ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                            'gconnection.getDataSet(STRQUERY, "authorize")

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE ITEMMASTER set  ", "ITEMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    GCONNECTION.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        GCONNECTION.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE ITEMMASTER set  ", "ITEMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub


    Private Sub ChkOPENITEMFACILITY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkOPENITEMFACILITY.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmdAdd.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CmdAdd.Focus()
        End If
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New crptitemmaster
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        'sqlstring = "select * from VW_ITEMMASTER where category='" & Trim(CBO_CATEGORY.Text) & "' order by ItemCode"
        sqlstring = "select * from ITEMMASTER "

        Call Viewer.GetDetails(sqlstring, "ITEMMASTER", r)
        Viewer.TableName = "ITEMMASTER"

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text13")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
        TXTOBJ1.Text = "UserName : " & gUsername

        Viewer.Show()
    End Sub
End Class