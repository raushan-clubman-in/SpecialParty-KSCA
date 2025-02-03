Public Class FRM_MKGA_CategoryMaster
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim vSeqNo As Double
    Dim gconnection As New GlobalClass

  
    Private Sub cmdcategoryHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
     
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
                txtcategoryCode.Text = Trim(vform.keyfield & "")
                txtcategoryCode.Select()
                txtcategoryCode_Validated(sender, e)
                Cmd_Add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try

    End Sub
   
    Private Sub GetRights()
        Dim i, j, x As Integer
        'Dim vmain, vsmod, vssmod As Long
        Dim SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        chstr = ""
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
    Private Sub categorymaster_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        categoryMastbool = False
    End Sub

   
   

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Public Sub checkValidation()
        boolchk = False
        ''********** Check  Server Code Can't be blank *********************'''
        If Trim(txtcategoryCode.Text) = "" Then
            MessageBox.Show(" category Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtcategoryCode.Focus()
            Exit Sub
        End If
        '********** Check  Server desc Can't be blank *********************'''
        If Trim(txtcategoryName.Text) = "" Then
            MessageBox.Show(" category Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtcategoryName.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Private Sub txtcategoryCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
    '    Dim sqlstring As String
    '    Dim _export As New EXPORT
    '    _export.TABLENAME = "poscategorymaster"
    '    sqlstring = "SELECT * FROM poscategorymaster order by CATEGORYCODE"
    '    Call _export.export_excel(sqlstring)
    '    _export.Show()
    '    Exit Sub
    'End Sub

    'Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
    '    'GroupBox3.Visible = True

    '    Dim sqlstring, SSQL As String
    '    Dim Viewer As New ReportViwer
    '    Dim r As New Crptcategorymaster
    '    Dim POSdesc(), MemberCode() As String
    '    Dim SQLSTRING2 As String
    '    sqlstring = "select * from poscategorymaster"

    '    Call Viewer.GetDetails(sqlstring, "poscategorymaster", r)
    '    Viewer.TableName = "poscategorymaster"

    '    Dim TXTOBJ10 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ10 = r.ReportDefinition.ReportObjects("Text10")
    '    TXTOBJ10.Text = gCompanyname

    '    Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ9 = r.ReportDefinition.ReportObjects("Text9")
    '    TXTOBJ9.Text = "UserName : " & gUsername

    '    Viewer.Show()
    'End Sub

    Private Sub Cmd_Exit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM poscategorymaster"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM poscategorymaster", "SERIALNO", 0)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM poscategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM poscategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
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

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE poscategorymaster set  ", "categorycode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM poscategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM poscategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
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

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE poscategorymaster set  ", "categorycode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM poscategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM poscategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE poscategorymaster set  ", "categorycode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If

    End Sub

    Private Sub FRM_MKGA_CategoryMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            If Cmd_View.Enabled = True Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            End If
        End If
        'If e.KeyCode = Keys.F10 Then
        '    If cmdexport.Enabled = True Then
        '        Call cmdexport_Click(cmdexport, e)
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
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub

    Private Sub FRM_MKGA_CategoryMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmdCATEGORYHelp.Enabled = True
        txtcategoryCode.Focus()
        ServerMastbool = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub

    Private Sub txtcategoryCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcategoryCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdCATEGORYHelp.Enabled = True Then
                Search = Trim(txtcategoryCode.Text)
                Call cmdcategoryHelp_Click(cmdCATEGORYHelp, e)
            End If
        End If
    End Sub

    Private Sub txtcategoryCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcategoryCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtcategoryCode.Text <> "" Then
                Call txtcategoryCode_Validated(txtcategoryCode.Text, e)
                txtcategoryName.Focus()
            Else
                Call cmdcategoryHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtcategoryCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcategoryCode.Validated
        If Trim(txtcategoryCode.Text) <> "" Then
            vSeqNo = GetSeqno(txtcategoryCode.Text)
            sqlstring = "SELECT * FROM poscategorymaster WHERE categorySeqNo=" & Trim(vSeqNo)
            gconnection.getDataSet(sqlstring, "categorymaster")
            If gdataset.Tables("categorymaster").Rows.Count > 0 Then
                txtcategoryName.Clear()
                txtcategoryName.Text = gdataset.Tables("categorymaster").Rows(0).Item("categoryname")
                txtcategoryCode.ReadOnly = True
                txtcategoryName.Focus()
                If gdataset.Tables("categorymaster").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("categorymaster").Rows(0).Item("Adddatetime")), "dd-MMM-yyyy")
                    'Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If
                Me.Cmd_Add.Text = "Update[F7]"
                Me.txtcategoryCode.ReadOnly = True
                Me.cmdCATEGORYHelp.Enabled = False
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                Me.txtcategoryName.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txtcategoryCode.ReadOnly = False
                txtcategoryName.Focus()
            End If
        Else
            txtcategoryCode.Text = ""
            txtcategoryName.Focus()
        End If
        'If Trim(txtcategoryCode.Text) = "500" Then
        '    Cmd_Freeze.Enabled = False
        'Else
        '    Cmd_Freeze.Enabled = True
        'End If
    End Sub

    Private Sub txtcategoryName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcategoryName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtcategoryName.Text <> "" Then
                Cmd_Add.Focus()
            End If
        End If
    End Sub

    Private Sub cmdCATEGORYHelp_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCATEGORYHelp.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(categorycode,'') AS categorycode, ISNULL(categorycode,'') AS categoryname FROM POScategorymaster"
            M_WhereCondition = " "
            vform.Field = "categorycode,categorycode"
            'vform.Frmcalled = "   CATEGORY CODE   | CATEGORY NAME         |                                  "
            vform.vCaption = "Category Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtcategoryCode.Text = Trim(vform.keyfield & "")
                txtcategoryCode.Select()
                txtcategoryCode_Validated(sender, e)
                Cmd_Add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try

    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        Dim FRM As New ReportDesigner
        If txtcategoryCode.Text.Length > 0 Then
            tables = " FROM poscategorymaster WHERE categoryCode = '" & Trim(txtcategoryCode.Text) & "'"
        Else
            tables = "FROM poscategorymaster "
        End If
        Gheader = "Category DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"CATEGORYCODE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CATEGORYNAME", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"freeze", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"adduser", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"adddatetime", "11"}
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

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation()
            'Dim SQL As String
            ''--->Check Validation
            If boolchk = False Then Exit Sub
            vSeqNo = GetSeqno(txtcategoryCode.Text)
            sqlstring = " INSERT INTO poscategorymaster (categoryCode,categoryName,categorySeqno,Freeze,Adduser,Adddatetime)"
            sqlstring = sqlstring & " VALUES ( '" & Trim(txtcategoryCode.Text) & "','" & Replace(Trim(txtcategoryName.Text), "'", "") & "',"
            sqlstring = sqlstring & " " & Val(vSeqNo) & " ,"
            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(1, sqlstring, "categorymaster")
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation()
            ''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            Dim VSQL As String
            VSQL = " SELECT * FROM KOT_DET WHERE CATEGORY='" & Trim(txtcategoryName.Text) & "'"
            gconnection.getDataSet(VSQL, "CATEGORYVALIDATION")
            If gdataset.Tables("CATEGORYVALIDATION").Rows.Count - 1 > 0 Then
                MsgBox("THIS CATEGORY HAVING TRANSACTION, U CANNOT UPDATE THIS CATEGORY ")
                Exit Sub
            Else
                sqlstring = "UPDATE  poscategorymaster "
                sqlstring = sqlstring & " SET categoryName='" & Replace(Trim(txtcategoryName.Text), "'", "") & "',"
                sqlstring = sqlstring & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
                sqlstring = sqlstring & " WHERE categoryCode = '" & Trim(txtcategoryCode.Text) & "'"
                gconnection.dataOperation(2, sqlstring, "categorymaster")
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            End If
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Freeze.Enabled = True
        txtcategoryCode.ReadOnly = False
        txtcategoryName.ReadOnly = False
        txtcategoryCode.Text = ""
        txtcategoryName.Text = ""
        cmdCATEGORYHelp.Enabled = True
        Cmd_Freeze.Enabled = True

        Cmd_Add.Text = "Add [F7]"
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtcategoryCode.Focus()
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim STATUS As Integer
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  poscategorymaster "
                sqlstring = sqlstring & " SET Freeze= 'Y',Adduser='" & gUsername & " ', Adddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE categoryCode = '" & Trim(txtcategoryCode.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "poscategorymaster")
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            Else
                Exit Sub
                '    End If
                'Else
                '    STATUS = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
                '    If STATUS = 1 Then
                '        sqlstring = "UPDATE  poscategorymaster "
                '        sqlstring = sqlstring & " SET Freeze= 'N',Adduser='" & gUsername & "', Adddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                '        sqlstring = sqlstring & " WHERE categoryCode = '" & Trim(txtcategoryCode.Text) & "'"
                '        gconnection.dataOperation(4, sqlstring, "poscategorymaster")
                '        Me.Cmd_Clear_Click(sender, e)
                '        Cmd_Add.Text = "Add [F7]"
                '    Else
                '        Exit Sub
            End If
        End If

    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New Crptcategorymaster
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = "select * from poscategorymaster"

        Call Viewer.GetDetails(sqlstring, "poscategorymaster", r)
        Viewer.TableName = "poscategorymaster"

        Dim TXTOBJ10 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ10 = r.ReportDefinition.ReportObjects("Text10")
        TXTOBJ10.Text = gCompanyname

        Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ9 = r.ReportDefinition.ReportObjects("Text9")
        TXTOBJ9.Text = "UserName : " & gUsername

        Viewer.Show()
    End Sub
End Class