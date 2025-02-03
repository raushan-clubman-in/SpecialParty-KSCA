Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FRM_MKGA_Tablemaster
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim vSeqNo As Double
    Dim gconnection As New GlobalClass

    Private Sub FRM_MKGA_Tablemaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If

        'If e.KeyCode = Keys.F8 Then
        '    Call Cmd_Freeze_Click(Cmd_Freeze, e)
        '    Exit Sub
        'End If
        'If e.KeyCode = Keys.F7 Then
        '    Call Cmd_Add_Click(Cmd_Add, e)
        '    Exit Sub
        'End If
        'If e.KeyCode = Keys.F9 Then
        '    Call Cmd_View_Click(Cmd_View, e)
        '    Exit Sub
        'End If
        If e.KeyCode = Keys.F8 Then
            If Cmd_Freeze.Enabled = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F7 Then
            If Cmd_Add.Enabled = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            If Cmd_view.Enabled = True Then
                Call Cmd_View_Click(Cmd_view, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub
    Private Sub FRM_MKGA_Tablemaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmdTableHelp.Enabled = True
        txtTableNo.Select()
        TableMastbool = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub

    Private Sub txtTableNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTableNo.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdTableHelp.Enabled = True Then
                Search = Trim(txtTableNo.Text)
                Call cmdTableHelp_Click(txtTableNo, e)
            End If
        End If
    End Sub

    Private Sub txtTableNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTableNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtTableNo.Text) <> "" Then
                Call txtTableNo_Validated(txtTableNo, e)
                ' txtTableName.Focus()
                Txt_poscode.Focus()
            Else
                Call cmdTableHelp_Click(sender, e)
            End If
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
        Me.Cmd_Add.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub txtTableNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTableNo.Validated
        If Trim(txtTableNo.Text) <> "" Then
            vSeqNo = GetSeqno(txtTableNo.Text)
            sqlstring = "SELECT * FROM TableMaster WHERE TableNo = '" & Trim(txtTableNo.Text) & "'"
            gconnection.getDataSet(sqlstring, "TableMaster")
            If gdataset.Tables("TableMaster").Rows.Count > 0 Then
                'txtTableName.Clear()
                'txtTableName.Text = gdataset.Tables("TableMaster").Rows(0).Item("TableName")
                Txt_poscode.Text = gdataset.Tables("TableMaster").Rows(0).Item("pos")
                TXT_POSDESC.Text = gdataset.Tables("TableMaster").Rows(0).Item("posdesc")
                'txtTableName.Focus()
                txtTableNo.ReadOnly = True
                Cmd_Add.Text = "Update[F7]"
                If gdataset.Tables("TableMaster").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("TableMaster").Rows(0).Item("Adddatetime")), "dd-MMM-yyyy")
                    ' Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If
                Me.Cmd_Add.Text = "Update[F7]"
                Me.txtTableNo.ReadOnly = True
                Me.cmdTableHelp.Enabled = False
                'Me.txtTableName.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txtTableNo.ReadOnly = False
                ' txtTableName.Focus()
            End If
        Else
            'txtTableName.Text = ""
            ' txtTableName.Focus()
        End If
    End Sub

    Private Sub cmdTableHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTableHelp.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(TABLENO,'') AS TABLENO,ISNULL(pos,'') AS pos FROM TableMaster"
            M_WhereCondition = " "
            vform.Field = "TABLENO,pos"
            ' vform.Frmcalled = "   TABLENO     | POS                                   "
            vform.vCaption = " TABLEMASTER Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtTableNo.Text = Trim(vform.keyfield & "")
                txtTableNo.Select()
                txtTableNo_Validated(sender, e)
                Cmd_Add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub TableMaster_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        TableMastbool = False
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        txtTableNo.Select()
        txtTableNo.Text = ""
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = " "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.Enabled = True
        Cmd_Add.Text = "Add [F7]"
        txtTableNo.ReadOnly = False
        'txtTableName.ReadOnly = False
        cmdTableHelp.Enabled = True
        Txt_poscode.Text = ""
        TXT_POSDESC.Text = ""
        Cmd_Add.Text = "Add [F7]"
        txtTableNo.Focus()
    End Sub
    Public Sub checkValidation()
        boolchk = False
        ''********** Check  Store Code Can't be blank *********************'''
        If Trim(txtTableNo.Text) = "" Then
            MessageBox.Show(" Table No. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTableNo.Focus()
            Exit Sub
        End If
        ''********** Check  Store desc Can't be blank *********************'''
        'If Trim(txtTableName.Text) = "" Then
        '    MessageBox.Show(" Table Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtTableName.Focus()
        '    Exit Sub
        'End If
        ''********** Check  POSCode Can't be blank *********************'''
        If Trim(txt_POSCODE.Text) = "" Then
            MessageBox.Show(" Table No. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_POSCODE.Focus()
            Exit Sub
        End If
        ''********** Check  POS desc Can't be blank *********************'''
        If Trim(TXT_POSDESC.Text) = "" Then
            MessageBox.Show(" Table Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_POSDESC.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() ''--->Check Validation
            If boolchk = False Then Exit Sub
            vSeqNo = GetSeqno(Val(txtTableNo.Text))
            sqlstring = " INSERT INTO TableMaster (TableNo,TableSeqNo,POS,POSDESC,Freeze,AddUserId,Adddatetime)"
            sqlstring = sqlstring & " VALUES ( '" & Trim(txtTableNo.Text) & "',"

            sqlstring = sqlstring & "" & Val(vSeqNo) & " ,"
            sqlstring = sqlstring & " '" & Trim(Txt_poscode.Text) & " ','" & Replace(Trim(TXT_POSDESC.Text), "'", "") & "',"
            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(1, sqlstring, "TableMaster")
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation() ''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                    boolchk = False
                End If
            End If
            'Dim VSQL As String
            'VSQL = " SELECT tableno,pos FROM KOT_DET WHERE SUBgroupcode='" & Trim(Txt_subgroup.Text) & "'"
            'gconnection.getDataSet(VSQL, "SUBGROUPVALIDATION")
            'If gdataset.Tables("SUBGROUPVALIDATION").Rows.Count - 1 > 0 Then
            '    MsgBox("THIS SUBGROUP HAVING TRANSACTION, U CANNOT UPDATE THIS SUBGROUP ")
            '    Exit Sub
            'End If
            sqlstring = "UPDATE  TableMaster "
            'sqlstring = sqlstring & " SET TableName='" & Replace(Trim(txtTableName.Text), "'", "") & "',"
            sqlstring = sqlstring & " SET  POS='" & Trim(Txt_poscode.Text) & "',POSDESC='" & Replace(Trim(TXT_POSDESC.Text), ",", "") & "',"
            sqlstring = sqlstring & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            sqlstring = sqlstring & " WHERE TableNo = '" & Trim(txtTableNo.Text) & "'"
            gconnection.dataOperation(2, sqlstring, "TableMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        Dim status As Integer
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            status = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If status = 1 Then
                sqlstring = "UPDATE  Tablemaster "
                sqlstring = sqlstring & " SET Freeze= 'Y',AddUserId='" & gUsername & " ', Adddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE TableNo = '" & Trim(txtTableNo.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "Tablemaster")
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            Else
                Exit Sub
            End If
            'Else
            '    status = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            '    If status = 1 Then
            '        sqlstring = "UPDATE  Tablemaster "
            '        sqlstring = sqlstring & " SET Freeze= 'N',AddUserId='" & gUsername & " ', Adddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        sqlstring = sqlstring & " WHERE TableNo = '" & Trim(txtTableNo.Text) & "'"
            '        gconnection.dataOperation(4, sqlstring, "Tablemaster")
            '        Me.Cmd_Clear_Click(sender, e)
            '        Cmd_Add.Text = "Add [F7]"
            '    Else
            '        Exit Sub
            '    End If
        End If
    End Sub

    Private Sub Txt_poscode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_poscode.KeyDown
        If e.KeyCode = Keys.F2 Then
            If CMDPOSHELP.Enabled = True Then
                Search = Trim(Txt_poscode.Text)
                Call CMDPOSHELP_Click(txtTableNo, e)
            End If
        End If
    End Sub

    Private Sub Txt_poscode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_poscode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_poscode.Text) <> "" Then
                Call Txt_poscode_Validated(txtTableNo, e)
                TXT_POSDESC.Focus()
            Else
                Call cmdposHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub CMDPOSHELP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPOSHELP.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(POSCODE,'') AS POSCODE,ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE "
            M_WhereCondition = "ISNULL(FREEZE,'')<>'Y' "
            vform.Field = "POSCODE,POSDESC"
            ' vform.Frmcalled = "   POSCODE     | POSDESC                                   "
            vform.vCaption = " Pos Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_poscode.Text = Trim(vform.keyfield & "")
                Txt_poscode.Select()
                Txt_poscode_Validated(sender, e)
                'Cmd_Add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Txt_poscode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_poscode.Validated
        If Trim(Txt_poscode.Text) <> "" Then
            vSeqNo = GetSeqno(Txt_poscode.Text)
            sqlstring = "SELECT * FROM posmaster WHERE poscode = '" & Trim(Txt_poscode.Text) & "'"
            gconnection.getDataSet(sqlstring, "posmaster")
            If gdataset.Tables("POSMASTER").Rows.Count > 0 Then
                TXT_POSDESC.Clear()
                TXT_POSDESC.Text = gdataset.Tables("posmaster").Rows(0).Item("posdesc")
                TXT_POSDESC.Focus()
                Txt_poscode.ReadOnly = True
                TXT_POSDESC.ReadOnly = True
            End If
        Else
            Txt_poscode.Text = ""
            TXT_POSDESC.Focus()
        End If
    End Sub

    Private Sub TXT_POSDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_POSDESC.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If TXT_POSDESC.Text <> "" Then
                Cmd_Add.Focus()
            End If
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_view.Click
        Dim FRM As New ReportDesigner
        If txtTableNo.Text.Length > 0 Then
            tables = " FROM tablemaster WHERE TABLENO = '" & Trim(txtTableNo.Text) & "'"
        Else
            tables = "FROM tablemaster "
        End If
        Gheader = "tablemaster DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"TABLENO", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"POS", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"GROUPCODE", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"GROUPDESC", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ''ROW = New String() {"CATEGORY", "15"}
        ''FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"POSDESC", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"freeze", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSERID", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDDATETIME", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATETIME", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub Cmdbrse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbrse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM tablemaster"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM tablemaster", "SERIALNO", 0)

    End Sub

    Private Sub Cmdauth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdauth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM tablemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM tablemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
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

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE tablemaster set  ", "TABLENO", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM tablemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM tablemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
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

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE tablemaster set  ", "TABLENO", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM tablemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM tablemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE tablemaster set  ", "TABLENO", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Sub cmd_rpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_rpt.Click
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New Crpttablemaster
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = "select * from tablemaster "

        Call Viewer.GetDetails(sqlstring, "tablemaster", r)
        Viewer.TableName = "tablemaster"

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text9")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text8")
        TXTOBJ1.Text = "UserName : " & gUsername

        Viewer.Show()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class