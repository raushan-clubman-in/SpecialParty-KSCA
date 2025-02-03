Imports System.Data.OleDb
Imports System.IO
Public Class FRM_MKGA_GroupMaster
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim vseqno As String
    Dim sqlstring As String
    Dim gconnection As New GlobalClass

    Private Sub FRM_MKGA_GroupMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
        'If e.KeyCode = Keys.F10 Then
        '    If cmdreport.Enabled = True Then
        '        Call cmdexport_Click(cmdexport, e)
        '        Exit Sub
        '    End If
        'End If

        'If e.KeyCode = Keys.F12 Or e.KeyCode = Keys.Escape Then
        '    Call cmdreport_Click(Cmd_Exit, e)
        '    Exit Sub
        'End If

    End Sub
    Private Sub FRM_MKGA_GroupMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmdGroupCode.Enabled = True
        Me.txtGroupCode.ReadOnly = False
        GroupMasterbool = True
        Call FillCategory()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtGroupCode.Focus()
    End Sub
    Private Sub FillCategory()
        Try
            Dim i As Integer
            sqlstring = " SELECT DISTINCT categoryname FROM POSCATEGORYMASTER where ISNULL(freeze ,'')<> 'Y'  ORDER BY Categoryname ASC"
            gconnection.getDataSet(sqlstring, "categorymaster")
            CBO_CATEGORY.Items.Clear()
            CBO_CATEGORY.Sorted = True
            If gdataset.Tables("categorymaster").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("categorymaster").Rows.Count - 1
                    CBO_CATEGORY.Items.Add(gdataset.Tables("categorymaster").Rows(i).Item("Categoryname"))
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
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
        Me.Cmdview.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        chstr = ""
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
                If Right(x) = "S" Then
                    Me.Cmd_Add.Enabled = True
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

    Private Sub txtGroupCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGroupCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdGroupCode.Enabled = True Then
                Search = Trim(txtGroupCode.Text)
                Call cmdGroupCode_Click(txtGroupCode, e)
                Exit Sub
            End If
        End If
    End Sub

   
    Private Sub txtGroupCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGroupCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtGroupCode.Text) <> "" Then
                Call txtGroupCode_Validated(txtGroupCode, e)
            Else
                Call cmdGroupCode_Click(cmdGroupCode, e)
            End If
        End If
    End Sub

    Private Sub txtGroupDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGroupDesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtGroupDesc.Text <> "" Then
                txtSname.Focus()
            Else
                txtGroupDesc.Focus()
            End If
        End If
    End Sub

    Private Sub txtGroupCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupCode.Validated
        If Trim(txtGroupCode.Text) <> "" Then
            sqlstring = "SELECT * FROM GroupMaster WHERE GroupCode= '" & Trim(txtGroupCode.Text) & "'"
            gconnection.getDataSet(sqlstring, "GroupMaster")
            If gdataset.Tables("GroupMaster").Rows.Count > 0 Then
                txtGroupDesc.Clear()
                txtSname.Clear()
                txtGroupDesc.Text = Trim(gdataset.Tables("GroupMaster").Rows(0).Item("Groupdesc"))
                txtSname.Text = Trim(gdataset.Tables("GroupMaster").Rows(0).Item("ShortName"))

                CBO_CATEGORY.DropDownStyle = ComboBoxStyle.DropDown
                CBO_CATEGORY.Text = Trim(gdataset.Tables("GroupMaster").Rows(0).Item("Category"))

                If gdataset.Tables("GroupMaster").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("GroupMaster").Rows(0).Item("AddDateTime")), "dd-MMM-yyyy")
                    'Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If
                Me.txtGroupCode.ReadOnly = True
                Me.cmdGroupCode.Enabled = False
                Me.Cmd_Add.Text = "Update[F7]"
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                txtGroupDesc.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txtGroupCode.ReadOnly = False
                txtGroupDesc.Focus()
            End If
        Else
            txtGroupCode.Text = ""
            txtGroupDesc.Focus()
        End If
    End Sub

    Private Sub cmdGroupCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroupCode.Click
        

        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPDESC,'') AS GROUPDESC FROM groupmaster "
            M_WhereCondition = " "
            vform.Field = "GROUPCODE,GROUPDESC"
            'vform.Frmcalled = "   GROUPCODE     | GROUP NAME         |                                  "
            vform.vCaption = "Group Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtGroupCode.Text = Trim(vform.keyfield & "")
                txtGroupCode.Select()
                txtGroupCode_Validated(sender, e)
                Cmd_Add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub txtSname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSname.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            CBO_CATEGORY.Focus()
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = ""
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.Enabled = True
        Cmd_Add.Text = "Add [F7]"
        txtGroupCode.Enabled = True
        txtGroupCode.ReadOnly = False
        txtGroupDesc.ReadOnly = False
        CBO_CATEGORY.Text = ""
        txtSname.Text = ""
        txtGroupCode.Text = ""
        txtGroupDesc.Text = ""
        ' TXT_MONTHDESC.Text = ""
        'cmdGroupCode.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtGroupCode.Focus()
    End Sub
    Public Sub checkValidation()
        boolchk = False
        ''********** Check  Store Code Can't be blank *********************'''
        If Trim(txtGroupCode.Text) = "" Then
            MessageBox.Show(" Group Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGroupCode.Focus()
            Exit Sub
        End If
        ''********** Check  Store desc Can't be blank *********************'''
        If Trim(txtGroupDesc.Text) = "" Then
            MessageBox.Show(" Group Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGroupDesc.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        Dim sql(0) As String
        If Cmd_Add.Text = "Add [F7]" Then

            Call checkValidation() ''--->Check Validation
            If boolchk = False Then Exit Sub

            vseqno = GetSeqno(txtGroupCode.Text)
            strSQL = " INSERT INTO groupmaster (Groupcode,Groupseqno,Groupdesc,ShortName,Category,Freeze,AddUserId,AddDateTime)"
            strSQL = strSQL & " VALUES ( '" & Trim(txtGroupCode.Text) & "'," & Val(vseqno) & ",'" & Replace(Trim(txtGroupDesc.Text), "'", "") & "',"
            strSQL = strSQL & "'" & Replace(Trim(txtSname.Text), "'", "") & "',"
            strSQL = strSQL & "'" & Trim(CBO_CATEGORY.Text) & "',"
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')" ','" & Trim(TXT_MONTHDESC.Text) & "')"
            gconnection.dataOperation(1, strSQL, "groupmaster")
            Me.Cmd_Clear_Click(sender, e)

        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation() ''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK)
                    boolchk = False
                    Exit Sub
                End If
            End If
            Dim VSQL As String
            VSQL = " SELECT * FROM KOT_DET WHERE groupcode='" & Trim(txtGroupCode.Text) & "'"
            gconnection.getDataSet(VSQL, "GROUPVALIDATION")
            If gdataset.Tables("GROUPVALIDATION").Rows.Count - 1 > 0 Then
                MsgBox("THIS GROUP HAVING TRANSACTION, U CANNOT UPDATE THIS GROUP ")
                Exit Sub
            Else
                strSQL = "UPDATE  groupmaster "
                strSQL = strSQL & " SET Groupdesc='" & Replace(Trim(txtGroupDesc.Text), "'", "") & "',"
                strSQL = strSQL & " ShortName='" & Replace(Trim(txtSname.Text), "'", "") & "',"
                strSQL = strSQL & " Category='" & Trim(CBO_CATEGORY.Text) & "',"
                strSQL = strSQL & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
                strSQL = strSQL & " WHERE Groupcode = '" & Trim(txtGroupCode.Text) & "'"
                'gconnection.dataOperation(2, strSQL, "groupmaster")
                'ReDim Preserve Sql(Sql.Length)
                'Sql(Sql.Length - 1) = strSQL

                'pardha 05 oct 12
                'strSQL = "UPDATE  kot_det "
                'strSQL = strSQL & " set Category='" & Trim(CBO_CATEGORY.Text) & "'"
                'strSQL = strSQL & " WHERE Groupcode = '" & Trim(txtGroupCode.Text) & "'"

                'ReDim Preserve sql(sql.Length)
                'sql(sql.Length - 1) = strSQL

                gconnection.dataOperation(2, strSQL, "groupmaster")
                ' gconnection.MoreTransold(sql)
                'pardha 05 oct 12
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            End If
            End If
    End Sub
    'Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
    '    Dim sqlstring As String
    '    Dim _export As New EXPORT
    '    _export.TABLENAME = "GROUPMASTER"
    '    sqlstring = "SELECT * FROM GROUPMASTER order by GROUPcode"
    '    Call _export.export_excel(sqlstring)
    '    _export.Show()
    '    Exit Sub
    ' End Sub

    'Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
    '    'GroupBox3.Visible = True
    '    'Dim vform As New report
    '    'vform.ShowDialog(Me)
    '    'vform.Close()
    '    'vform = Nothing
    '    Dim sqlstring, SSQL As String
    '    Dim Viewer As New ReportViwer
    '    Dim r As New crptgroupmaster
    '    Dim POSdesc(), MemberCode() As String
    '    Dim SQLSTRING2 As String
    '    sqlstring = "select * from GROUPMASTER"

    '    Call Viewer.GetDetails(sqlstring, "GROUPMASTER", r)
    '    Viewer.TableName = "GROUPMASTER"
    '    Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ5 = r.ReportDefinition.ReportObjects("Text8")
    '    TXTOBJ5.Text = gCompanyname

    '    Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ1 = r.ReportDefinition.ReportObjects("Text6")
    '    TXTOBJ1.Text = "UserName : " & gUsername
    '    Viewer.Show()
    'End Sub

    Private Sub CBO_CATEGORY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBO_CATEGORY.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If CBO_CATEGORY.Text <> "" Then
                CBO_CATEGORY.Focus()
            Else
                Cmd_Add.Focus()
            End If
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Dim Sqlstring, Update(0) As String
        Dim i, count, mm As Integer
        If MsgBox("Want to update sequence no...", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "SEQUENCE ") = MsgBoxResult.Ok Then
            mm = 1
        Else
            mm = 0
        End If
        If mm = 1 Then

            Sqlstring = "SELECT * FROM POSMASTER"
            gconnection.getDataSet(Sqlstring, "POSMASTER")
            If gdataset.Tables("POSMASTER").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("POSMASTER").Rows.Count - 1
                    vseqno = GetSeqno(Trim(gdataset.Tables("POSMASTER").Rows(i).Item("POSCODE")))
                    count = count + 1
                    Sqlstring = "UPDATE POSMASTER SET POSSEQNO  = " & (vseqno) & " WHERE POSCODE = '" & Trim(gdataset.Tables("POSMASTER").Rows(i).Item("POSCODE")) & "'"
                    If count = 0 Then
                        Update(0) = Sqlstring
                    Else
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = Sqlstring
                    End If

                    Sqlstring = "UPDATE POSMENULINK SET POSseqno = " & (vseqno) & " WHERE POS = '" & Trim(gdataset.Tables("POSMASTER").Rows(i).Item("POSCODE")) & "'"
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = Sqlstring
                Next
            End If
            'gconnection.MoreTransold(Update)

            'ReDim Preserve Update(Update.Length)

            Sqlstring = "SELECT * FROM ITEMMASTER"
            gconnection.getDataSet(Sqlstring, "ITEMMASTER")
            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("ITEMMASTER").Rows.Count - 1
                    vseqno = ""
                    vseqno = GetSeqno(Trim(gdataset.Tables("ITEMMASTER").Rows(i).Item("ITEMCODE")))
                    count = count + 1
                    Sqlstring = "UPDATE posmenulink SET ITEMCODESEQNO  = " & (vseqno) & " WHERE ITEMCODE = '" & Trim(gdataset.Tables("ITEMMASTER").Rows(i).Item("ITEMCODE")) & "'"
                    If count = 0 Then
                        Update(0) = Sqlstring
                    Else
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = Sqlstring
                    End If

                    Sqlstring = "UPDATE ratemaster SET ITEMCODESEQNO  = " & (vseqno) & " WHERE ITEMCODE = '" & Trim(gdataset.Tables("ITEMMASTER").Rows(i).Item("ITEMCODE")) & "'"
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = Sqlstring

                    Sqlstring = "UPDATE ITEMMASTER SET ITEMCODESEQNO  = " & (vseqno) & " WHERE ITEMCODE = '" & Trim(gdataset.Tables("ITEMMASTER").Rows(i).Item("ITEMCODE")) & "'"
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = Sqlstring
                Next
            End If
            'gconnection.MoreTransold(Update)
            'ReDim Preserve Update(Update.Length)
            Sqlstring = "SELECT * FROM GROUPMASTER"
            gconnection.getDataSet(Sqlstring, "GROUPMASTER")
            If gdataset.Tables("GROUPMASTER").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("GROUPMASTER").Rows.Count - 1
                    vseqno = GetSeqno(Trim(gdataset.Tables("GROUPMASTER").Rows(i).Item("GROUPCODE")))
                    count = count + 1
                    Sqlstring = "UPDATE GROUPMASTER SET GROUPSEQNO  = " & (vseqno) & " WHERE GROUPCODE = '" & Trim(gdataset.Tables("GROUPMASTER").Rows(i).Item("GROUPCODE")) & "'"
                    If count = 0 Then
                        Update(0) = Sqlstring
                    Else
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = Sqlstring
                    End If

                    Sqlstring = "UPDATE itemmaster SET Groupseqno = " & (vseqno) & " WHERE GROUPCODE = '" & Trim(gdataset.Tables("GROUPMASTER").Rows(i).Item("GROUPCODE")) & "'"
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = Sqlstring
                Next
            End If
            'gconnection.MoreTransold(Update)
            'ReDim Preserve Update(Update.Length)
            Sqlstring = "SELECT * FROM UOMMASTER"
            gconnection.getDataSet(Sqlstring, "UOMMASTER")
            If gdataset.Tables("UOMMASTER").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("UOMMASTER").Rows.Count - 1
                    vseqno = GetSeqno(Trim(gdataset.Tables("UOMMASTER").Rows(i).Item("UOMCODE")))
                    count = count + 1
                    Sqlstring = "UPDATE UOMMASTER SET UOMSEQNO  = " & (vseqno) & " WHERE UOMCODE = '" & Trim(gdataset.Tables("UOMMASTER").Rows(i).Item("UOMCODE")) & "'"
                    If count = 0 Then
                        Update(0) = Sqlstring
                    Else
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = Sqlstring
                    End If
                Next
            End If
            'gconnection.MoreTransold(Update)

            'ReDim Preserve Update(Update.Length)

            Sqlstring = "SELECT * FROM SERVERMASTER"
            gconnection.getDataSet(Sqlstring, "SERVERMASTER")
            If gdataset.Tables("SERVERMASTER").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("SERVERMASTER").Rows.Count - 1
                    vseqno = GetSeqno(Trim(gdataset.Tables("SERVERMASTER").Rows(i).Item("SERVERCODE")))
                    count = count + 1
                    Sqlstring = "UPDATE SERVERMASTER SET SERVERSEQNO  = " & (vseqno) & " WHERE SERVERCODE = '" & Trim(gdataset.Tables("SERVERMASTER").Rows(i).Item("SERVERCODE")) & "'"
                    If count = 0 Then
                        Update(0) = Sqlstring
                    Else
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = Sqlstring
                    End If
                Next
            End If

            'gconnection.MoreTransold(Update)

            'ReDim Preserve Update(Update.Length)


            Sqlstring = "SELECT * FROM ItemTypeMASTER"
            gconnection.getDataSet(Sqlstring, "ItemTypeMASTER")
            If gdataset.Tables("ItemTypeMASTER").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("ItemTypeMASTER").Rows.Count - 1
                    vseqno = GetSeqno(Trim(gdataset.Tables("ItemTypeMASTER").Rows(i).Item("ItemTypeCODE")))
                    count = count + 1
                    Sqlstring = "UPDATE ItemTypeMASTER SET ItemTypeSEQNO  = " & (vseqno) & " WHERE ItemTypeCODE = '" & Trim(gdataset.Tables("ItemTypeMASTER").Rows(i).Item("ItemTypeCODE")) & "'"
                    If count = 0 Then
                        Update(0) = Sqlstring
                    Else
                        ReDim Preserve Update(Update.Length)
                        Update(Update.Length - 1) = Sqlstring
                    End If
                    Sqlstring = "UPDATE itemmaster SET ItemTypeSEQNO  = " & (vseqno) & " WHERE ItemTypeCODE = '" & Trim(gdataset.Tables("ItemTypeMASTER").Rows(i).Item("ItemTypeCODE")) & "'"
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = Sqlstring
                Next
            End If
            gconnection.MoreTransold(Update)
        End If

        Me.Close()
    End Sub

    Private Sub Cmdview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdview.Click
        Dim FRM As New ReportDesigner
        If txtGroupCode.Text.Length > 0 Then
            tables = " FROM GROUPMASTER WHERE GROUPCODE = '" & Trim(txtGroupCode.Text) & "'"
        Else
            tables = "FROM GROUPMASTER "
        End If
        Gheader = "GROUPMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"GROUPCODE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GROUPDESC", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CATEGORY", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SHORTNAME", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"freeze", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSERID", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDDATETIME", "10"}
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

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim STATUS As Integer
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  groupmaster "
                sqlstring = sqlstring & " SET Freeze= 'Y',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE Groupcode = '" & Trim(txtGroupCode.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "groupmaster")
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            Else
                Exit Sub
            End If

            'Else
            '    STATUS = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            '    If STATUS = 1 Then
            '        sqlstring = "UPDATE  groupmaster "
            '        sqlstring = sqlstring & " SET Freeze= 'N',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        sqlstring = sqlstring & " WHERE Groupcode = '" & Trim(txtGroupCode.Text) & "'"
            '        gconnection.dataOperation(4, sqlstring, "groupmaster")
            '        Me.Cmd_Clear_Click(sender, e)
            '        Cmd_Add.Text = "Add [F7]"
            '    Else
            '        Exit Sub
            '    End If
        End If
    End Sub

    Private Sub Cmdbrse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbrse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM GROUPMASTER"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM GROUPMASTER", "SERIALNO", 0)

    End Sub

    Private Sub Cmdauth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdauth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM GROUPMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM GROUPMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
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

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE GROUPMASTER set  ", "GROUPCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM GROUPMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM GROUPMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
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

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE GROUPMASTER set  ", "GROUPCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM GROUPMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM GROUPMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE GROUPMASTER set  ", "GROUPCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If

    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New crptgroupmaster
        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = "select * from GROUPMASTER"

        Call Viewer.GetDetails(sqlstring, "GROUPMASTER", r)
        Viewer.TableName = "GROUPMASTER"
        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text8")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text6")
        TXTOBJ1.Text = "UserName : " & gUsername
        Viewer.Show()
    End Sub
End Class