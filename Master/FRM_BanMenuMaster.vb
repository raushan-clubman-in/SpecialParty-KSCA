Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class FRM_BanMenuMaster
    Dim gconn As New GlobalClass
    Dim i, j As Integer
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim sqlstring As String
    Dim vSeqNo As Double
    Dim gconnection As New GlobalClass
    Dim boolchk As Boolean
    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        txt_CCode.Text = ""
        'Txt_Cdesc.Text = ""
        Txt_TariffCode.Text = ""
        Txt_Tariffdesc.Text = ""
        Txt_MenuRate.Text = ""
        txt_taxcode.Text = ""
        SSGRID_MENU.ClearRange(1, 1, -1, -1, True)
        lbl_freeze.Visible = False
        txt_CCode.Enabled = True
        Txt_TariffCode.Enabled = True
        'Cmd_tariff.Enabled = True
        CmdFreeze.Text = "Freeze[F8]"
        CmdAdd.Text = "Add[F7]"
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Txt_TariffCode.Focus()
    End Sub

    Private Sub Cmd_MenuHelp_Click(sender As Object, e As EventArgs) Handles Cmd_MenuHelp.Click
        Dim vform As New LIST_OPERATION1
        ' gSQLString = "SELECT  DISTINCT isnull(TARIFFCODE,'') as MENUCODE,isnull(TARIFFDESC,'') as MENUDESC,isnull(CCODE,'')AS CCODE,ISNULL(CDESC,'')AS CDESC FROM PARTY_VIEW_TARIFFMASTER "
        gSQLString = "SELECT  DISTINCT isnull(TARIFFCODE,'') as MENUCODE,isnull(TARIFFDESC,'') as MENUDESC,isnull(CCODE,'')AS CCODE FROM PARTY_VIEW_TARIFFMASTER "

        M_WhereCondition = " "
        vform.Field = "MENUCODE,MENUDESC,CCODE "
        ' vform.vFormatstring = "             Tariff Description            |   Tariff Code    |    CATEGORY    | CATEGORY CODE| RATE| SBF CHARGE"
        vform.vCaption = "Menu Master Help"
        'vform.KeyPos = 0
        ' vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        ' vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_TariffCode.Text = Trim(vform.keyfield & "")
            Txt_TariffCode.Select()
            'Txt_tariffdesc.Text = Trim(vform.keyfield)
            'txt_CCode.Text = Trim(vform.keyfield2)
            'Txt_Cdesc.Text = Trim(vform.keyfield3)
            Call Txt_Tariffcode_Validated(Txt_TariffCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub Txt_TariffCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_TariffCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Txt_TariffCode.Enabled = True Then
                Search = Trim(Txt_TariffCode.Text)
                Call Cmd_MenuHelp_Click(Txt_TariffCode, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Txt_TariffCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_TariffCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_TariffCode.Text) <> "" Then
                Call Txt_Tariffcode_Validated(Txt_TariffCode, e)
            Else
                Call Cmd_MenuHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Txt_Tariffcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_TariffCode.Validated
        Dim i As Integer
        If Trim(Txt_Tariffcode.Text) <> "" Then
            sqlstring = "SELECT * FROM PARTY_VIEW_TARIFFMASTER WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "' "
            'sqlstring = sqlstring & " AND CCODE='" & Trim(txt_CCode.Text) & "'"
            gconn.getDataSet(sqlstring, "TAR")
            If gdataset.Tables("TAR").Rows.Count > 0 Then
                CmdAdd.Text = "Update[F7]"
                Txt_TariffCode.Enabled = False
                ' Cmd_tariff.Enabled = False
                For i = 0 To gdataset.Tables("TAR").Rows.Count - 1
                    Txt_tariffdesc.Text = gdataset.Tables("TAR").Rows(i).Item("TARIFFDESC")
                    txt_CCode.Text = gdataset.Tables("TAR").Rows(0).Item("CCODE")
                    ' txt_.Text = gdataset.Tables("TAR").Rows(0).Item("CDESC")
                    Txt_MenuRate.Text = gdataset.Tables("TAR").Rows(i).Item("RATE")
                    cmb_category.Text = gdataset.Tables("TAR").Rows(0).Item("CATEGORY")
                    'If gdataset.Tables("TAR").Rows(i).Item("sbfcharge") = "Y" Then
                    '    optYes.Checked = True
                    '    OptNo.Checked = False
                    'Else
                    '    optYes.Checked = False
                    '    OptNo.Checked = True
                    'End If

                    txt_taxcode.Text = gdataset.Tables("TAR").Rows(i).Item("TAXCODE")
                    With SSGRID_MENU
                        .Col = 1
                        .Row = i + 1
                        .Text = gdataset.Tables("TAR").Rows(i).Item("MENUCODE")
                        .Col = 2
                        .Row = i + 1
                        .Text = gdataset.Tables("TAR").Rows(i).Item("MENUDESC")
                        .Col = 3
                        .Row = i + 1
                        .Text = gdataset.Tables("TAR").Rows(i).Item("MAXITEMS")
                    End With
                    If gdataset.Tables("TAR").Rows(i).Item("FREEZE") = "Y" Then
                        lbl_freeze.Visible = True
                        Me.lbl_freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("TAR").Rows(0).Item("voidDATE")), "dd-MMM-yyyy") & "  " & gdataset.Tables("TAR").Rows(0).Item("voidUSER")

                        txt_CCode.Enabled = False
                        'CMD_Ccode.Enabled = False
                        Txt_Tariffcode.Enabled = False
                        ' Cmd_tariff.Enabled = False
                        CmdFreeze.Text = "UnFreeze[F8]"
                    Else
                        lbl_freeze.Visible = False
                        txt_CCode.Enabled = True
                        ' CMD_Ccode.Enabled = True
                        Txt_Tariffcode.Enabled = True
                        'Cmd_tariff.Enabled = True
                    End If
                Next
                Txt_Tariffdesc.Focus()
                'Txt_MenuRate.Focus()
            Else
                'Txt_MenuRate.Focus()
                Txt_Tariffdesc.Focus()
            End If
        End If
    End Sub

    Private Function Cmd_tariff() As Object
        'Throw New NotImplementedException
    End Function

    Private Function optYes() As Object
        'Throw New NotImplementedException
    End Function

    Private Function OptNo() As Object
        Throw New NotImplementedException
    End Function

    Private Function cmd_Freeze() As Object
        'Throw New NotImplementedException
    End Function
    Private Sub checkvalidate()
        Dim menu As String
        boolchk = False
        Dim ssql As String

        ssql = "select * from PARTY_TARIFFHDR where isnull(FREEZE,'')='Y' AND  TARIFFCODE='" & Txt_Tariffcode.Text & "'"
        gconnection.getDataSet(ssql, "LOG")
        If gdataset.Tables("LOG").Rows.Count > 0 Then
            MessageBox.Show("FREEZE RECORD CANNOT BE UPDATE", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        End If

        If Trim(txt_CCode.Text) = "" Then
            MessageBox.Show("Category Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_CCode.Focus()
            Exit Sub
        End If

        ''If Trim(Txt_Cdesc.Text) = "" Then
        ''    MessageBox.Show("Category Description Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        ''    Txt_Cdesc.Focus()
        ''    Exit Sub
        ''End If
        If Trim(Txt_Tariffcode.Text) = "" Then
            MessageBox.Show("Tariff Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Tariffcode.Focus()
            Exit Sub
        End If
        If Trim(Txt_tariffdesc.Text) = "" Then
            MessageBox.Show("Tariff Desc Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_tariffdesc.Focus()
            Exit Sub
        End If
        If Trim(txt_taxcode.Text) = "" Then
            MessageBox.Show("TAXCODE CANNOT BE BLANK", MyCompanyName, MessageBoxButtons.OK)
            txt_taxcode.Focus()
            Exit Sub
        End If

        If Val(Txt_MenuRate.Text) <= 0 Then
            MessageBox.Show("Rate Can't be Lessthan Zero", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_MenuRate.Focus()
            Exit Sub
        End If

        If Trim(cmb_category.Text) = "" Then
            MessageBox.Show("Tariff code can't be blank", MyCompanyName, MessageBoxButtons.OK)
            cmb_category.Focus()
            Exit Sub
        End If

        'If Trim(Txt_menudesc.Text) = "" Then
        '    MessageBox.Show("Menu Desc Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Txt_menudesc.Focus()
        '    Exit Sub
        'End If
        'If Trim(Txt_Maxitems.Text) = "" Then
        '    MessageBox.Show("Items Permitted Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Txt_Maxitems.Focus()
        '    Exit Sub
        'End If
        With SSGRID_MENU
            If .DataRowCnt = 0 Then
                MessageBox.Show("Menus Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                SSGRID_MENU.SetActiveCell(1, 1)
                SSGRID_MENU.Focus()
                Exit Sub
            End If

        End With
        With SSGRID_MENU
            For i = 1 To .DataRowCnt
                .Col = 3
                .Row = i
                menu = .Text
                If Trim(menu) <= 0 Then
                    MessageBox.Show("MAX ITEM CAN'T BE BLANK", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
            Next
        End With
        boolchk = True
    End Sub
    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim grpcode(), INSERT(0), UPDATE(0) As String
        Dim acct, subacct, costcode
        Dim i As Integer        '
        If Mid(CmdAdd.Text, 1, 1) = "A" Then
            Call checkvalidate()
            If boolchk = False Then Exit Sub
            'sqlstring = "Insert into party_tariffhdr (ccode,tariffcode,tariffdesc,rate,taxcode,sbfcharge,freeze,adduser,adddate,CATEGORY)"
            sqlstring = "Insert into party_tariffhdr (ccode,tariffcode,tariffdesc,rate,taxcode,freeze,adduser,adddate,CATEGORY)"
            sqlstring = sqlstring & " Values('" & Trim(txt_CCode.Text) & "','" & Txt_TariffCode.Text & "','" & Txt_Tariffdesc.Text & "',"
            sqlstring = sqlstring & " " & Trim(Txt_MenuRate.Text) & ",'" & txt_taxcode.Text & "',"
            'If optYes.Checked = True Then
            '    sqlstring = sqlstring & "'Y',"
            'Else
            '    sqlstring = sqlstring & "'N',"
            'End If
            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & cmb_category.Text & "')"

            INSERT(0) = sqlstring

            With SSGRID_MENU
                For i = 1 To .DataRowCnt
                    sqlstring = "Insert into party_tariffdet (tariffcode,tariffdesc,menucode,menudesc,maxitems,freeze,adduser,adddate)"
                    sqlstring = sqlstring & " Values('" & Txt_TariffCode.Text & "','" & Txt_Tariffdesc.Text & "',"
                    .Col = 1
                    .Row = i
                    sqlstring = sqlstring & " '" & Trim(.Text) & "',"
                    .Col = 2
                    .Row = i
                    sqlstring = sqlstring & " '" & Trim(.Text) & "',"
                    .Col = 3
                    .Row = i
                    sqlstring = sqlstring & " " & Val(.Text) & ","
                    sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring
                Next
            End With
            gconn.MORETRANS(INSERT)
            Call CmdClear_Click(sender, e)
        ElseIf Mid(CmdAdd.Text, 1, 1) = "U" Then
            Call checkvalidate()
            If boolchk = False Then Exit Sub
            sqlstring = " select * from party_view_tariffmaster where tariffcode='" & Trim(Txt_TariffCode.Text) & "' and ccode='" & Trim(txt_CCode.Text) & "'"
            gconn.getDataSet(sqlstring, "UPD")
            If gdataset.Tables("UPD").Rows.Count = 0 Then
                MsgBox("INVALID TARIFF CODE TO UPDATE", MsgBoxStyle.Information)
                Exit Sub
            End If
            sqlstring = " select isnull(salesacctin,'') as salesacctin,isnull(subglaccode,'') as subglaccode,isnull(costcode,'') as costcode from party_tariffhdr where tariffcode='" & Trim(Txt_TariffCode.Text) & "' "
            gconn.getDataSet(sqlstring, "UPD1")
            If gdataset.Tables("UPD1").Rows.Count > 0 Then
                acct = gdataset.Tables("UPD1").Rows(0).Item("salesacctin")
                subacct = gdataset.Tables("UPD1").Rows(0).Item("subglaccode")
                costcode = gdataset.Tables("UPD1").Rows(0).Item("costcode")
            Else
                acct = ""
                subacct = ""
                costcode = ""
            End If
            ''***********************UPDATION START*****************
            sqlstring = "Delete from party_tariffdet where tariffcode in (Select tariffcode from party_tariffhdr where tariffcode='" & Trim(Txt_TariffCode.Text) & "' and ccode='" & Trim(txt_CCode.Text) & "')"
            UPDATE(0) = sqlstring

            sqlstring = "Delete from party_tariffhdr where tariffcode='" & Trim(Txt_TariffCode.Text) & "' and ccode='" & Trim(txt_CCode.Text) & "'"
            ReDim Preserve UPDATE(UPDATE.Length)
            UPDATE(UPDATE.Length - 1) = sqlstring

            'sqlstring = "Insert into party_tariffhdr (ccode,tariffcode,tariffdesc,rate,taxcode,sbfcharge,freeze,adduser,adddate,CATEGORY)"
            sqlstring = "Insert into party_tariffhdr (ccode,tariffcode,tariffdesc,rate,taxcode,freeze,adduser,adddate,CATEGORY)"
            sqlstring = sqlstring & " Values('" & Trim(txt_CCode.Text) & "','" & Txt_TariffCode.Text & "','" & Txt_Tariffdesc.Text & "',"
            sqlstring = sqlstring & " " & Trim(Txt_MenuRate.Text) & ",'" & txt_taxcode.Text & "',"
            'If optYes.Checked = True Then
            '    sqlstring = sqlstring & "'Y',"
            'Else
            '    sqlstring = sqlstring & "'N',"
            'End If
            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & cmb_category.Text & "')"
            ReDim Preserve UPDATE(UPDATE.Length)
            UPDATE(UPDATE.Length - 1) = sqlstring

            With SSGRID_MENU
                For i = 1 To .DataRowCnt
                    sqlstring = "Insert into party_tariffdet (tariffcode,tariffdesc,menucode,menudesc,maxitems,freeze,adduser,adddate)"
                    sqlstring = sqlstring & " Values('" & Txt_TariffCode.Text & "','" & Txt_Tariffdesc.Text & "',"
                    .Col = 1
                    .Row = i
                    sqlstring = sqlstring & " '" & Trim(.Text) & "',"
                    .Col = 2
                    .Row = i
                    sqlstring = sqlstring & " '" & Trim(.Text) & "',"
                    .Col = 3
                    .Row = i
                    sqlstring = sqlstring & " " & Val(.Text) & ","
                    sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "')"
                    ReDim Preserve UPDATE(UPDATE.Length)
                    UPDATE(UPDATE.Length - 1) = sqlstring
                Next
            End With
            sqlstring = "Update party_tariffhdr set salesacctin = '" & acct & "',subglaccode = '" & subacct & "',costcode = '" & costcode & "'  where tariffcode='" & Trim(Txt_TariffCode.Text) & "'"
            ReDim Preserve UPDATE(UPDATE.Length)
            UPDATE(UPDATE.Length - 1) = sqlstring

            gconn.MORETRANS(UPDATE)
            Call CmdClear_Click(sender, e)
        End If
    End Sub

    Private Sub SSGRID_MENU_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID_MENU.KeyDownEvent
        Dim i As Integer
        Dim menucode As String
        With SSGRID_MENU
            i = .ActiveRow
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = i
                    menucode = Trim(.Text)
                    If Trim(menucode) = "" Then
                        Call FILLMENU()
                    ElseIf Trim(menucode) <> "" Then
                        sqlstring = "SELECT isnull(SUBGROUPCODE,'') as SUBGROUPCODE,isnull(SUBGROUPDESC,'') as SUBGROUPDESC FROM subgroupmaster"
                        sqlstring = sqlstring & " WHERE SUBGROUPCODE='" & Trim(menucode) & "' "
                        gconn.getDataSet(sqlstring, "MENU")
                        If gdataset.Tables("MENU").Rows.Count > 0 Then
                            .Col = 1
                            .Row = i
                            .Text = gdataset.Tables("MENU").Rows(0).Item("SUBGROUPCODE")
                            .Col = 2
                            .Row = i
                            .Text = gdataset.Tables("MENU").Rows(0).Item("SUBGROUPDESC")
                            .SetActiveCell(3, i)
                            .Focus()
                        End If
                    End If
                ElseIf .ActiveCol = 3 Then
                    .Col = 3
                    .Row = i
                    If Val(.Text) <> 0 Then
                        .SetActiveCell(1, i + 1)
                        .Focus()
                    Else
                        .SetActiveCell(3, i)
                        .Focus()
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                .DeleteRows(i, 1)
                .SetActiveCell(1, i)
                .Focus()
            End If
        End With
    End Sub
    Private Sub FILLMENU()
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT isnull(SUBGROUPCODE,'') as SUBGROUPCODE,isnull(SUBGROUPDESC,'') as SUBGROUPDESC FROM SUBGROUPMASTER"
        M_WhereCondition = " "
        vform.Field = "SUBGROUPCODE,SUBGROUPDESC"
        ' vform.vFormatstring = "        Menu Description    |     Menu Code    "
        vform.vCaption = "SubGroup Master Help"
        ' vform.KeyPos = 0
        ' vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With SSGRID_MENU
                .Col = 1
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield & "")
                .Col = 2
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield1)
                .SetActiveCell(3, .ActiveRow)
                .Focus()
            End With
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdFreeze_Click(sender As Object, e As EventArgs) Handles CmdFreeze.Click
        Dim INSERT(0) As String
        If Mid(CmdFreeze.Text, 1, 1) = "F" Then
            Call checkvalidate()
            If boolchk = False Then Exit Sub
            sqlstring = "SELECT * FROM PARTY_VIEW_TARIFFMASTER WHERE TARIFFCODE='" & Trim(Txt_TariffCode.Text) & "' AND CCODE='" & Trim(txt_CCode.Text) & "'"
            gconn.getDataSet(sqlstring, "VIEW")
            If gdataset.Tables("VIEW").Rows.Count > 0 Then
                sqlstring = "UPDATE PARTY_TARIFFHDR SET FREEZE='Y',voiduser='" & Trim(gUsername) & "',voiddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' WHERE TARIFFCODE='" & Trim(Txt_TariffCode.Text) & "' AND CCODE='" & Trim(txt_CCode.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring

                sqlstring = "UPDATE PARTY_TARIFFDET SET FREEZE='Y',voiduser='" & Trim(gUsername) & "',voiddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' WHERE TARIFFCODE IN (SELECT TARIFFCODE FROM PARTY_TARIFFHDR WHERE TARIFFCODE='" & Trim(Txt_TariffCode.Text) & "' AND CCODE='" & Trim(txt_CCode.Text) & "')"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring

                gconn.MORETRANS(INSERT)
                Call CmdClear_Click(sender, e)
            End If
        ElseIf Mid(CmdFreeze.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE PARTY_TARIFFHDR SET FREEZE='N',voiduser='" & Trim(gUsername) & "',voiddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' WHERE TARIFFCODE='" & Trim(Txt_TariffCode.Text) & "' AND CCODE='" & Trim(txt_CCode.Text) & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            sqlstring = "UPDATE PARTY_TARIFFDET SET FREEZE='N',voiduser='" & Trim(gUsername) & "',voiddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' WHERE TARIFFCODE IN (SELECT TARIFFCODE FROM PARTY_TARIFFHDR WHERE TARIFFCODE='" & Trim(Txt_TariffCode.Text) & "' AND CCODE='" & Trim(txt_CCode.Text) & "')"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
            gconn.MORETRANS(INSERT)
            Call CmdClear_Click(sender, e)
        End If
    End Sub

    Private Sub Cmd_ChargeCode_Click(sender As Object, e As EventArgs) Handles Cmd_ChargeCode.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(CHARGECODE,'') AS CHARGECODE,ISNULL(CHARGEDESC,'') AS CHARGEDESC  FROM CHARGEMASTER  WHERE "
            M_WhereCondition = " RATE=0   AND ISNULL(Freeze,'') <> 'Y'AND ISNULL(TAXTYPECODE,'')<>'' "
            vform.Field = "CHARGECODE,CHARGEDESC"
            'vform.Frmcalled = "  CHARGECODE  | CHARGE DESCRIPTION          |                                  "
            vform.vCaption = "Charge Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_taxcode.Text = Trim(vform.keyfield & "")
                txt_taxcode_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub txt_taxcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_taxcode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If txt_taxcode.Enabled = True Then
                Search = Trim(txt_taxcode.Text)
                Call Cmd_ChargeCode_Click(txt_taxcode, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txt_taxcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_taxcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_taxcode.Text) <> "" Then
                Call txt_taxcode_Validated(txt_taxcode, e)
            Else
                Call Cmd_ChargeCode_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txt_taxcode_Validated(sender As Object, e As EventArgs) Handles txt_taxcode.Validated
        Dim SSQL As String
        If txt_taxcode.Text <> "" Then
            SSQL = "SELECT ISNULL(CHARGECODE,'') AS CHARGECODE,ISNULL(CHARGEDESC,'') AS CHARGEDESC FROM CHARGEMASTER  WHERE RATE=0  AND CHARGECODE='" & Trim(txt_taxcode.Text) & "' AND ISNULL(Freeze,'') <> 'Y'AND ISNULL(TAXTYPECODE,'')<>''"
            gconn.getDataSet(SSQL, "ItemTypeMaster")
            If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                txt_taxcode.Text = Trim(gdataset.Tables("ItemTypeMaster").Rows(0).Item("CHARGECODE"))
                'txt_taxcode.ReadOnly = True
                txt_CCode.Focus()
            Else
                txt_CCode.Focus()
            End If
        Else
            txt_taxcode.Clear()
        End If
    End Sub

    Private Sub Cmd_Ccode_Click(sender As Object, e As EventArgs) Handles Cmd_Ccode.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(categorycode,'') AS categorycode, ISNULL(categorycode,'') AS categoryname FROM POScategorymaster"
            M_WhereCondition = " "
            vform.Field = "categorycode,categorycode"
            ' vform.Frmcalled = "   CATEGORY CODE   | CATEGORY NAME         |                                  "
            vform.vCaption = "Category Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_CCode.Text = Trim(vform.keyfield & "")
                txt_CCode_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub txt_CCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_CCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If txt_CCode.Enabled = True Then
                Search = Trim(txt_CCode.Text)
                Call Cmd_Ccode_Click(txt_CCode, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txt_CCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_CCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_CCode.Text) <> "" Then
                Call txt_CCode_Validated(txt_CCode, e)
            Else
                Call Cmd_Ccode_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txt_CCode_Validated(sender As Object, e As EventArgs) Handles txt_CCode.Validated
        If Trim(txt_CCode.Text) <> "" Then
            vSeqNo = GetSeqno(txt_CCode.Text)
            sqlstring = "SELECT * FROM poscategorymaster WHERE CATEGORYCODE='" & Trim(txt_CCode.Text) & " '"
            gconnection.getDataSet(sqlstring, "categorymaster")
            If gdataset.Tables("categorymaster").Rows.Count > 0 Then
                txt_CCode.Text = gdataset.Tables("categorymaster").Rows(0).Item("CATEGORYCODE")
                'txt_CCode.ReadOnly = True
                'Me.txt_CCode.ReadOnly = True
                'Me.Cmd_Ccode.Enabled = False
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                Me.cmb_category.Focus()
            Else
                txt_CCode.ReadOnly = False
            End If
        Else
            txt_CCode.Text = ""
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdAdd.Enabled = False
        Me.CmdFreeze.Enabled = False
        Me.CmdView.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    Me.CmdFreeze.Enabled = True
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

    Private Sub Txt_Tariffdesc_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Tariffdesc.KeyDown
        'Txt_MenuRate.Focus()
    End Sub

    Private Sub Txt_Tariffdesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Tariffdesc.KeyPress
        'Txt_MenuRate.Focus()
        If Asc(e.KeyChar) = 13 Then
            Txt_MenuRate.Focus()
        End If
    End Sub

    Private Sub Txt_Tariffdesc_Validated(sender As Object, e As EventArgs) Handles Txt_Tariffdesc.Validated
        Txt_MenuRate.Focus()
    End Sub

    Private Sub Txt_MenuRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_MenuRate.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            txt_taxcode.Focus()
        End If
    End Sub

    Private Sub FRM_BanMenuMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            If CmdAdd.Enabled = True Then
                Call CmdAdd_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            If CmdFreeze.Enabled = True Then
                Call CmdFreeze_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            'Call Cmdview_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            Call CmdExit_Click(sender, e)
        End If
    End Sub

    Private Sub FRM_BanMenuMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
     
        GroupBox2.Controls.Add(SSGRID_MENU)
        SSGRID_MENU.Location = New Point(23, 13)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Txt_TariffCode.Focus()
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

    Private Sub CmdBrowse_Click(sender As Object, e As EventArgs) Handles CmdBrowse.Click
        Dim OBJ1 As New VIEWHDR
        Dim ChildSql As String
        sqlstring = "SELECT tariffcode,tariffdesc,CATEGORY,ccode,RATE,freeze FROM PARTY_TARIFFHDR "
        ChildSql = "SELECT tariffcode,menucode,menudesc,maxitems FROM PARTY_TARIFFDET"
        gconnection.getDataSet(sqlstring, "Tariff_HDR")
        OBJ1.LOADGRID(gdataset.Tables("Tariff_HDR"), True, "FRM_BanMenuMaster", ChildSql, "tariffcode", 1)
        OBJ1.Show()
    End Sub

    Private Sub CmdView_Click(sender As Object, e As EventArgs) Handles CmdView.Click

    End Sub
End Class