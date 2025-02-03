Public Class FRM_MKGA_Locationmaster
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim vSeqNo As Double
    Dim gconnection As New GlobalClass

    Private Sub Locationmaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            If Cmdview.Enabled = True Then
                Call Cmdview_Click(Cmdview, e)
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
    Private Sub Locationmaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmdlocationHelp.Enabled = True
        txtlocationcode.Focus()
        txtlocationcode.Select()
        ServerMastbool = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        ' Dim vmain, vsmod, vssmod As Long
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
        Cmdview.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmdview.Enabled = True
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
                    Me.Cmdview.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub locationmaster_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        locationMastbool = False
    End Sub

    Private Sub txtlocationcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlocationcode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdlocationHelp.Enabled = True Then
                Search = Trim(txtlocationcode.Text)
                Call cmdlocationHelp_Click(cmdlocationHelp, e)
            End If
        End If
    End Sub

    Private Sub txtlocationcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlocationcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtlocationcode.Text <> "" Then
                Call txtlocationcode_Validated(txtlocationcode.Text, e)
                txtlocationName.Focus()
            Else
                Call cmdlocationHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtlocationcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlocationcode.Validated
        If Trim(txtlocationcode.Text) <> "" Then
            vSeqNo = GetSeqno(txtlocationcode.Text)
            sqlstring = "SELECT * FROM locationmaster WHERE LOCATIONSeqNo=" & Trim(vSeqNo)
            gconnection.getDataSet(sqlstring, "locationmaster")
            If gdataset.Tables("locationmaster").Rows.Count > 0 Then
                txtlocationName.Clear()
                txtlocationName.Text = gdataset.Tables("locationmaster").Rows(0).Item("LOCATIONname")
                txtlocationcode.ReadOnly = True
                txtlocationName.Focus()
                If gdataset.Tables("locationmaster").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("locationmaster").Rows(0).Item("Adddatetime")), "dd-MMM-yyyy")
                    'Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If
                Me.Cmd_Add.Text = "Update[F7]"
                Me.txtlocationcode.ReadOnly = True
                Me.cmdlocationHelp.Enabled = False
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                Me.txtlocationName.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txtlocationcode.ReadOnly = False
                txtlocationName.Focus()
            End If
        Else
            txtlocationcode.Text = ""
            txtlocationName.Focus()
        End If
        'If Trim(txtlocationcode.Text) = "500" Then
        '    Cmd_Freeze.Enabled = False
        'Else
        '    Cmd_Freeze.Enabled = True
        'End If
    End Sub

    Private Sub cmdlocationHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlocationHelp.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(locationcode,'') AS locationcode,ISNULL(locationname,'') AS locationname FROM locationmaster "
            M_WhereCondition = " "
            vform.Field = "locationcode,locationname"
            ' vform.Frmcalled = "   LOCATIONCODE     | LOCATION NAME         |                                  "
            vform.vCaption = " location Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtlocationcode.Text = Trim(vform.keyfield & "")
                txtlocationcode.Select()
                txtlocationcode_Validated(sender, e)
                Cmd_Add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        txtlocationcode.Select()
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.Enabled = True
        Cmd_Add.Text = "Add [F7]"
        txtlocationcode.ReadOnly = False
        txtlocationName.ReadOnly = False
        cmdlocationHelp.Enabled = True
        Cmd_Freeze.Enabled = True
        txtlocationcode.Text = ""
        txtlocationName.Text = ""
        Cmd_Add.Text = "Add [F7]"
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        'txtlocationcode.Focus()
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            vSeqNo = GetSeqno(txtlocationcode.Text)
            sqlstring = " INSERT INTO locationmaster (LOCATIONCode,LOCATIONName,LOCATIONSeqno,Freeze,Adduser,Adddatetime)"
            sqlstring = sqlstring & " VALUES ( '" & Trim(txtlocationcode.Text) & "','" & Replace(Trim(txtlocationName.Text), "'", "") & "',"
            sqlstring = sqlstring & " " & Val(vSeqNo) & " ,"
            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(1, sqlstring, "locationmaster")
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK)
                    boolchk = False
                    Exit Sub
                End If
            End If
            'Dim VSQL As String
            'VSQL = " SELECT locationcode FROM KOT_DET WHERE LOCATIONCODE='" & Trim(txtlocationcode.Text) & "'"
            'gconnection.getDataSet(VSQL, "locationVALIDATION")
            'If gdataset.Tables("locationVALIDATION").Rows.Count - 1 > 0 Then
            '    MsgBox("THIS LOCATION HAVING TRANSACTION, U CANNOT UPDATE THIS LOCATION ")
            '    Exit Sub
            'End If
            sqlstring = "UPDATE  locationmaster "
            sqlstring = sqlstring & " SET LOCATIONName='" & Replace(Trim(txtlocationName.Text), "'", "") & "',"
            sqlstring = sqlstring & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            sqlstring = sqlstring & " WHERE LOCATIONCode = '" & Trim(txtlocationcode.Text) & "'"
            gconnection.dataOperation(2, sqlstring, "locationmaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Server Code Can't be blank *********************'''
        If Trim(txtlocationcode.Text) = "" Then
            MessageBox.Show(" LOCATION Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtlocationcode.Focus()
            Exit Sub
        End If
        '''********** Check  Server desc Can't be blank *********************'''
        If Trim(txtlocationName.Text) = "" Then
            MessageBox.Show(" LOCATION Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtlocationName.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim STATUS As Integer
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  locationmaster "
                sqlstring = sqlstring & " SET Freeze= 'Y',Adduser='" & gUsername & " ', Adddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE LOCATIONCode = '" & Trim(txtlocationcode.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "locationmaster")
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            Else
                Exit Sub
            End If

            'Else
            '    STATUS = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            '    If STATUS = 1 Then
            '        sqlstring = "UPDATE  locationmaster "
            '        sqlstring = sqlstring & " SET Freeze= 'N',Adduser='" & gUsername & " ', Adddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        sqlstring = sqlstring & " WHERE LOCATIONCode = '" & Trim(txtlocationcode.Text) & "'"
            '        gconnection.dataOperation(4, sqlstring, "locationmaster")
            '        Me.Cmd_Clear_Click(sender, e)
            '        Cmd_Add.Text = "Add [F7]"
            '    Else
            '        Exit Sub
            '    End If
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmdbrse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbrse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM LOCATIONMASTER"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM LOCATIONMASTER", "SERIALNO", 0)

    End Sub

    Private Sub Cmdauth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdauth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM LOCATIONMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM LOCATIONMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
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

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE LOCATIONMASTER set  ", "LOCATIONCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM LOCATIONMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM LOCATIONMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
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

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE LOCATIONMASTER set  ", "LOCATIONCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM LOCATIONMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM LOCATIONMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE LOCATIONMASTER set  ", "LOCATIONCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Sub Cmdview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdview.Click
        Dim FRM As New ReportDesigner
        If txtlocationcode.Text.Length > 0 Then
            tables = " FROM LOCATIONMASTER WHERE LOCATIONCODE = '" & Trim(txtlocationcode.Text) & "'"
        Else
            tables = "FROM LOCATIONMASTER "
        End If
        Gheader = "LOCATIONMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"LOCATIONCODE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"LOCATIONNAME", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"GROUPCODE", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"GROUPDESC", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ''ROW = New String() {"CATEGORY", "15"}
        ''FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"SHORTNAME", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"freeze", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSER", "10"}
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

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New Crptlocationmaster
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = "select * from locationmaster "

        Call Viewer.GetDetails(sqlstring, "locationmaster", r)
        Viewer.TableName = "locationmaster"

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text4")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text6")
        TXTOBJ1.Text = "UserName : " & gUsername

        Viewer.Show()
    End Sub
End Class