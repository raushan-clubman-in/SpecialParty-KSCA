Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class Frm_HeadReceiptMaster
    Dim gconn As New GlobalClass
    Dim i, j As Integer
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim sqlstring As String
    Dim vSeqNo As Double
    Dim gconnection As New GlobalClass
    Dim boolchk As Boolean
    Private Sub Cmd_ParHeadHelp_Click(sender As Object, e As EventArgs) Handles Cmd_ParHeadHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ISNULL(Receiptheadcode,'') AS Receiptheadcode,ISNULL(Receiptheaddesc,'') AS Receiptheaddesc FROM party_Head_master"
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "Receiptheadcode,Receiptheaddesc"
        'vform.vFormatstring = " RECEIPT HEAD CODE   | RECEIPT HEAD DESCRIPTION        "
        vform.vCaption = "PARTY HEAD MASTER HELP"
        ''vform.KeyPos = 0
        ''vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_ParHeadCode.Text = Trim(vform.keyfield & "")
            Txt_ParHeadCode.Select()
            Txt_ParHeadCode.Enabled = False
            Txt_ParHeaddesc.Focus()
            Call Txt_ParHeadCode_Validated(Txt_ParHeadCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub Txt_ParHeadCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ParHeadCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Txt_ParHeadCode.Enabled = True Then
                Search = Trim(Txt_ParHeadCode.Text)
                Call Cmd_ParHeadHelp_Click(Txt_ParHeadCode, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Txt_ParHeadCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ParHeadCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_ParHeadCode.Text) <> "" Then
                Call Txt_ParHeadCode_Validated(Txt_ParHeadCode, e)
            Else
                Call Cmd_ParHeadHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Txt_ParHeadCode_Validated(sender As Object, e As EventArgs) Handles Txt_ParHeadCode.Validated
        If Trim(Txt_ParHeadCode.Text) <> "" Then
            sqlstring = "SELECT * FROM party_Head_master WHERE Receiptheadcode= '" & Trim(Txt_ParHeadCode.Text) & "'"
            gconnection.getDataSet(sqlstring, "party_Head_master")
            If gdataset.Tables("party_Head_master").Rows.Count > 0 Then
                Txt_ParHeaddesc.Clear()
                'txtSname.Clear()
                Txt_ParHeaddesc.Text = Trim(gdataset.Tables("party_Head_master").Rows(0).Item("Receiptheaddesc"))
                'txtSname.Text = Trim(gdataset.Tables("party_Head_master").Rows(0).Item("ShortName"))
                If gdataset.Tables("party_Head_master").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_freeze.Visible = True
                    Me.lbl_freeze.Text = ""
                    Me.lbl_freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("party_Head_master").Rows(0).Item("AddDateTime")), "dd-MMM-yyyy")
                    Me.CmdFreeze.Text = "UnFreeze[F8]"
                Else
                    Me.lbl_freeze.Visible = False
                    Me.lbl_freeze.Text = "Record Freezed  On "
                    Me.CmdFreeze.Text = "Freeze[F8]"
                End If
                Me.Cmd_ParHeadHelp.Enabled = True
                Txt_ParHeadCode.Enabled = False
                Me.CmdAdd.Text = "Update[F7]"
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                Txt_ParHeaddesc.Focus()
            Else
                Me.lbl_freeze.Visible = False
                Me.lbl_freeze.Text = "Record Freezed  On "
                Me.CmdAdd.Text = "Add [F7]"

                Txt_ParHeadCode.Enabled = False
                Txt_ParHeaddesc.Focus()
            End If
        Else
            Txt_ParHeadCode.Text = ""
            Txt_ParHeaddesc.Focus()
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='PARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
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
                    Me.CmdFreeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                End If
            Next
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(Txt_ParHeadCode.Text) = "" Then
            MessageBox.Show(" Party head Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_ParHeadCode.Focus()
            Exit Sub
        End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Trim(Txt_ParHeaddesc.Text) = "" Then
            MessageBox.Show(" party head Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_ParHeaddesc.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim strSQL As String
        If CmdAdd.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            strSQL = " INSERT INTO party_Head_master_LOG (Receiptheadcode,RECseqno,Receiptheaddesc,Freeze,AddUserId,AddDateTime)"
            strSQL = strSQL & " VALUES ( '" & Trim(Txt_ParHeadCode.Text) & "'," & Val(vSeqNo) & ",'" & Replace(Trim(Txt_ParHeaddesc.Text), "'", "") & "',"
            'strSQL = strSQL & "'" & Replace(Trim(txtSname.Text), "'", "") & "',"
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(6, strSQL, "party_Head_master")

            vSeqNo = GetSeqno(Txt_ParHeadCode.Text)
            strSQL = " INSERT INTO party_Head_master (Receiptheadcode,RECseqno,Receiptheaddesc,Freeze,AddUserId,AddDateTime)"
            strSQL = strSQL & " VALUES ( '" & Trim(Txt_ParHeadCode.Text) & "'," & Val(vSeqNo) & ",'" & Replace(Trim(Txt_ParHeaddesc.Text), "'", "") & "',"
            'strSQL = strSQL & "'" & Replace(Trim(txtSname.Text), "'", "") & "',"
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(1, strSQL, "party_Head_master")
            Me.CmdClear_Click(sender, e)
        ElseIf CmdAdd.Text = "Update[F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.CmdAdd.Text, 1, 1) = "U" Then
                If Me.lbl_freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            strSQL = "UPDATE  party_Head_master "
            strSQL = strSQL & " SET Receiptheaddesc='" & Replace(Trim(Txt_ParHeaddesc.Text), "'", "") & "',"
            'strSQL = strSQL & " ShortName='" & Replace(Trim(txtSname.Text), "'", "") & "',"
            strSQL = strSQL & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            strSQL = strSQL & " WHERE Receiptheadcode = '" & Trim(Txt_ParHeadCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "party_Head_master")
            Me.CmdClear_Click(sender, e)
            CmdAdd.Text = "Add [F7]"
        End If
    End Sub
    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        Call clearform(Me)
        Me.lbl_freeze.Visible = False
        Me.lbl_freeze.Text = "Record Freezed  On "
        Me.CmdFreeze.Text = "Freeze[F8]"
        CmdAdd.Text = "Add [F7]"
        Txt_ParHeadCode.Text = ""
        Txt_ParHeaddesc.Text = ""
        Txt_ParHeadCode.Enabled = True
        Cmd_ParHeadHelp.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Txt_ParHeadCode.Focus()
    End Sub
    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub
    Private Sub CmdFreeze_Click(sender As Object, e As EventArgs) Handles CmdFreeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim strSQL As String
        strSQL = " INSERT INTO party_Head_master (Receiptheadcode,RECseqno,Receiptheaddesc,Freeze,AddUserId,AddDateTime)"
        strSQL = strSQL & " VALUES ( '" & Trim(Txt_ParHeadCode.Text) & "'," & Val(vSeqNo) & ",'" & Replace(Trim(Txt_ParHeaddesc.Text), "'", "") & "',"
        'strSQL = strSQL & "'" & Replace(Trim(txtSname.Text), "'", "") & "',"
        strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
        gconnection.dataOperation(6, strSQL, "party_Head_master")

        If Mid(Me.CmdFreeze.Text, 1, 1) = "F" Then
            sqlstring = "UPDATE  party_Head_master "
            sqlstring = sqlstring & " SET Freeze= 'Y',VOIDUSER='" & gUsername & " ', VOIDDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE Receiptheadcode = '" & Trim(Txt_ParHeadCode.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "party_Head_master")
            Me.CmdClear_Click(sender, e)
            CmdAdd.Text = "Add [F7]"
        Else
            sqlstring = "UPDATE  party_Head_master "
            sqlstring = sqlstring & " SET Freeze= 'N',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE Receiptheadcode = '" & Trim(Txt_ParHeadCode.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "party_Head_master")
            Me.CmdClear_Click(sender, e)
            CmdAdd.Text = "Add [F7]"
        End If
    End Sub

    Private Sub cmdreport_Click(sender As Object, e As EventArgs)
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_HEADMASTER

        STR = "SELECT * FROM PARTY_VIEWHEAD"
        Viewer.ssql = STR
        Viewer.Report = r
        Viewer.TableName = "PARTY_VIEWHEAD"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text6")
        textobj1.Text = MyCompanyName
        Dim TXTOBJ2 As TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text10")
        TXTOBJ2.Text = gUsername
        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = r.ReportDefinition.ReportObjects("Text51")
        TXTOBJ6.Text = Address1 & Address2

        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = r.ReportDefinition.ReportObjects("Text52")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text53")
        'TXTOBJ9.Text = "PhoneNo : " & gphoneno

        Viewer.Show()
    End Sub

    Private Sub Frm_HeadReceiptMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            Call CmdView_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            Call CmdExit_Click(sender, e)
        End If
    End Sub

    Private Sub Frm_HeadReceiptMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Txt_ParHeadCode.Focus()
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
                        If Controls(i_i).Name = "CmdAdd" Or Controls(i_i).Name = "CmdClear" Or Controls(i_i).Name = "CmdFreeze" Or Controls(i_i).Name = "CmdView" Or Controls(i_i).Name = "CmdBrowse" Or Controls(i_i).Name = "CmdExit" Or Controls(i_i).Name = "Cmd_Exit" Or Controls(i_i).Name = "Cmd_PendingBill" Or Controls(i_i).Name = "Cmd_Bill" Then
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

    Private Sub CmdView_Click(sender As Object, e As EventArgs) Handles CmdView.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_HEADMASTER

        STR = "SELECT * FROM PARTY_VIEWHEAD"
        Viewer.ssql = STR
        Viewer.Report = r
        Viewer.TableName = "PARTY_VIEWHEAD"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text6")
        textobj1.Text = MyCompanyName
        Dim TXTOBJ2 As TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text10")
        TXTOBJ2.Text = gUsername
        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = r.ReportDefinition.ReportObjects("Text51")
        TXTOBJ6.Text = Address1 & Address2

        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = r.ReportDefinition.ReportObjects("Text52")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text53")
        'TXTOBJ9.Text = "PhoneNo : " & gphoneno

        Viewer.Show()
    End Sub

    Private Sub CmdBrowse_Click(sender As Object, e As EventArgs) Handles CmdBrowse.Click
        Dim OBJ1 As New VIEWHDR
        Dim ChildSql As String
        sqlstring = "SELECT Receiptheadcode,Receiptheaddesc,Freeze FROM Party_Head_Master ORDER BY Receiptheadcode "
        ChildSql = ""
        gconnection.getDataSet(sqlstring, "Party_Head_Master")
        OBJ1.LOADGRID(gdataset.Tables("Party_Head_Master"), False, "FRM_HeadReceiptMaster", ChildSql, "Receiptheadcode", 0)
        OBJ1.Show()
    End Sub
End Class