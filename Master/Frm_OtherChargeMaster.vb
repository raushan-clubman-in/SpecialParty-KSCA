Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class Frm_OtherChargeMaster
    Dim gconn As New GlobalClass
    Dim i, j As Integer
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim sqlstring As String
    Dim vSeqNo As Double
    Dim gconnection As New GlobalClass
    Dim boolchk As Boolean
    Private Sub Cmd_OthItemHelp_Click(sender As Object, e As EventArgs) Handles Cmd_OthItemHelp.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT isnull(ITEMCODE,'') as ITEMCODE,isnull(ITEMDESC,'') as ITEMDESC FROM Party_OtherChgsMaster"
            M_WhereCondition = " "
            vform.Field = "ITEMCODE ,ITEMDESC"
            vform.vCaption = "Other Charge Master Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_OthItemCode.Text = Trim(vform.keyfield & "")
                Txt_OthItemCode.Select()
                Call Txt_OthItemCode_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Txt_OthItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_OthItemCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Txt_OthItemCode.Enabled = True Then
                Search = Trim(Txt_OthItemCode.Text)
                Call Cmd_OthItemHelp_Click(Txt_OthItemCode, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Txt_OthItemCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_OthItemCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_OthItemCode.Text) <> "" Then
                Call Txt_OthItemCode_Validated(Txt_OthItemCode, e)
            Else
                Call Cmd_OthItemHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Txt_OthItemCode_Validated(sender As Object, e As EventArgs) Handles Txt_OthItemCode.Validated
        Try
            If Trim(Txt_OthItemCode.Text) <> "" Then
                Dim ds As New DataSet
                sqlstring = "select isnull(ITEMCODE,'') as ITEMCODE,isnull(ITEMDESC,'') as ITEMDESC,isnull(AmtOverride,'') as AmtOverride,isnull(rate,0) as rate,isnull(ChargeCode ,'') as ChargeCode,isnull(Freeze ,'') as Freeze,"
                sqlstring = sqlstring & " isnull(Adduser,'') as Adduser,isnull(Adddate,'') as Adddate  from Party_OtherChgsMaster "
                sqlstring = sqlstring & " WHERE isnull(itemcode,'')='" & Txt_OthItemCode.Text & "'"
                gconnection.getDataSet(sqlstring, "OtherMaster")
                If gdataset.Tables("OtherMaster").Rows.Count > 0 Then
                    Txt_OthItemdesc.Clear()
                    Txt_OthItemdesc.Text = gdataset.Tables("OtherMaster").Rows(0).Item("ItemDesc")
                    Txt_Rate.Text = gdataset.Tables("OtherMaster").Rows(0).Item("rate")
                    Txt_CCode.Text = gdataset.Tables("OtherMaster").Rows(0).Item("ChargeCode")
                    Cmb_AmtOverRide.Text = gdataset.Tables("OtherMaster").Rows(0).Item("AmtOverride")
                    If gdataset.Tables("OtherMaster").Rows(0).Item("Freeze") = "Y" Then
                        Me.lbl_freeze.Visible = True
                        Me.lbl_freeze.Text = ""
                        Me.lbl_freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("OtherMaster").Rows(0).Item("Adddate")), "dd-MMM-yyyy")
                        Me.CmdFreeze.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_freeze.Visible = False
                        Me.lbl_freeze.Text = "Record Freezed  On "
                        Me.CmdFreeze.Text = "Freeze[F8]"
                    End If
                    Me.CmdAdd.Text = "Update[F7]"
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                End If
                Txt_OthItemCode.ReadOnly = True
                Txt_OthItemdesc.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

    Private Sub Cmd_Uom_Click(sender As Object, e As EventArgs) Handles Cmd_Uom.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "select ISNULL(UOMCode  ,'') as Code ,ISNULL(UOMDesc  ,'')as Name  from UoMMaster  "
            M_WhereCondition = "where isnull(freeze,'')<>'Y'"
            vform.Field = "UOMCode,UOMDesc"
            vform.vCaption = "Uom Master Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_Uom.Text = Trim(vform.keyfield & "")
                Txt_Uom.Select()
                Call Txt_Uom_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Txt_Uom_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Uom.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Txt_Uom.Enabled = True Then
                Search = Trim(Txt_Uom.Text)
                Call Cmd_Uom_Click(Txt_Uom, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Txt_Uom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Uom.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Uom.Text) <> "" Then
                Call Txt_Uom_Validated(Txt_Uom, e)
            Else
                Call Cmd_Uom_Click(sender, e)
            End If
            Txt_Rate.Focus()
        End If
    End Sub
    Private Sub Txt_Uom_Validated(sender As Object, e As EventArgs) Handles Txt_Uom.Validated
        Try
            If Trim(Txt_Uom.Text) <> "" Then
                Dim ds As New DataSet
                sqlstring = "select ISNULL(UOMCode  ,'') as UOMCode ,ISNULL(UOMDesc  ,'') as UOMDesc  from UoMMaster "
                sqlstring = sqlstring & " WHERE isnull(UOMCode,'') = '" & Txt_Uom.Text & "'"
                gconnection.getDataSet(sqlstring, "UomMaster")
                If gdataset.Tables("UomMaster").Rows.Count > 0 Then
                    Txt_Uom.Clear()
                    Txt_Uom.Text = gdataset.Tables("UomMaster").Rows(0).Item("UOMCode")
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    Me.Txt_Uom.ReadOnly = True
                Else
                    CmdAdd.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Cmd_ChargeCode_Click(sender As Object, e As EventArgs)
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
                Txt_CCode.Text = Trim(vform.keyfield & "")
                Txt_CCode.Select()
                Txt_CCode_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub
    Private Sub Txt_CCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_CCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Txt_CCode.Enabled = True Then
                Search = Trim(Txt_CCode.Text)
                Call Cmd_ChargeCode_Click(Txt_CCode, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Txt_CCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_CCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_CCode.Text) <> "" Then
                Call Txt_CCode_Validated(Txt_CCode, e)
            Else
                Call Cmd_ChargeCode_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Txt_CCode_Validated(sender As Object, e As EventArgs) Handles Txt_CCode.Validated
        Dim SSQL As String
        If Txt_CCode.Text <> "" Then
            SSQL = "SELECT ISNULL(CHARGECODE,'') AS CHARGECODE,ISNULL(CHARGEDESC,'') AS CHARGEDESC FROM CHARGEMASTER  WHERE RATE=0  AND CHARGECODE='" & Trim(Txt_CCode.Text) & "' AND ISNULL(Freeze,'') <> 'Y'AND ISNULL(TAXTYPECODE,'')<>''"
            'ssql = "and "ESC
            gconn.getDataSet(SSQL, "ItemTypeMaster")
            If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                'txtTypedes.Text = ""
                Txt_CCode.Text = Trim(gdataset.Tables("ItemTypeMaster").Rows(0).Item("CHARGECODE"))
                ' Txt_CCode.ReadOnly = True
                CmdAdd.Focus()
            Else
                Txt_CCode.Text = ""
                Txt_CCode.Focus()
            End If
        Else
            Txt_CCode.Clear()
        End If
    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        Txt_OthItemCode.Text = ""
        Txt_OthItemdesc.Text = ""
        Txt_Rate.Text = ""
        Txt_Uom.Text = ""
        Txt_CCode.Text = ""
        Cmb_AmtOverRide.Text = ""
        Me.lbl_freeze.Visible = False
        Me.lbl_freeze.Text = "Record Freezed  On "
        Me.CmdFreeze.Text = "Freeze[F8]"
        CmdAdd.Text = "Add [F7]"
        Txt_OthItemCode.Enabled = True
        Txt_OthItemCode.ReadOnly = False
        Txt_OthItemdesc.ReadOnly = False
        Cmd_OthItemHelp.Enabled = True
        Txt_Rate.Text = Format(Val(Txt_Rate.Text), "0.00")
        Txt_OthItemCode.Focus()
    End Sub
    Public Sub checkValidation()
        boolchk = False
        Dim ssql As String
        If Trim(Txt_OthItemCode.Text) = "" Then
            MessageBox.Show("ITEMCODE can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_OthItemCode.Focus()
            Exit Sub
        End If
        If Trim(Txt_OthItemdesc.Text) = "" Then
            MessageBox.Show("ITEM Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_OthItemdesc.Focus()
            Exit Sub
        End If
        'If Trim(Txt_Uom.Text) = "" Then
        '    MessageBox.Show("UOMCODE can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Txt_Uom.Focus()
        '    Exit Sub
        'End If
        If Trim(Txt_OthItemCode.Text) = "EHC" Or Trim(Txt_OthItemCode.Text) = "MGA" Then
            MessageBox.Show("Sorry, This Item can't be Modify or Freeze. ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_OthItemCode.Focus()
            Exit Sub
        End If

        If Trim(Cmb_AmtOverRide.Text) = "" Then
            MessageBox.Show("Open Facility  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cmb_AmtOverRide.Focus()
            Exit Sub
        End If
        If Val(Txt_Rate.Text) <= 0 Then
            MessageBox.Show("Rate can't be less than 0 or less ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_Rate.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim strSQL, SQL As String
        Dim INSERT(0) As String
        Call checkValidation()
        If boolchk = False Then Exit Sub
        If CmdAdd.Text = "Add [F7]" Then
            vSeqNo = GetSeqno(Txt_OthItemCode.Text)
            strSQL = "INSERT INTO Party_OtherChgsMaster(ITEMCODE,ITEMDESC,AmtOverride,rate,ChargeCode,FREEZE,Adduser,Adddate)"
            strSQL = strSQL & " VALUES ('" & Trim(Txt_OthItemCode.Text) & "','" & Trim(Txt_OthItemdesc.Text) & "', '" & Cmb_AmtOverRide.Text & "',"
            strSQL = strSQL & "'" & Txt_Rate.Text & " ','" & Txt_CCode.Text & "',"
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(1, strSQL, "Party_OtherChgsMaster")
            Me.CmdClear_Click(sender, e)
        ElseIf CmdAdd.Text = "Update[F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            If Mid(Me.CmdAdd.Text, 1, 1) = "U" Then
                If Me.lbl_freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            strSQL = "UPDATE  Party_OtherChgsMaster "
            strSQL = strSQL & " SET ITEMDESC='" & Trim(Txt_OthItemdesc.Text) & "',"
            strSQL = strSQL & " AmtOverride ='" & Trim(Cmb_AmtOverRide.Text) & "',"
            strSQL = strSQL & " RATE=" & Trim(Txt_Rate.Text) & ","
            'strSQL = strSQL & " UOM ='" & Trim(Txt_Uom.Text) & "',"
            strSQL = strSQL & " ChargeCode ='" & Trim(Txt_CCode.Text) & "',"
            strSQL = strSQL & " UPDUSER='" & Trim(gUsername) & "',UPDdateTIME='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            strSQL = strSQL & " Where Itemcode = '" & Trim(Txt_OthItemCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "Party_OtherChgsMaster")
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            Me.CmdClear_Click(sender, e)
            'CmdAdd.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Txt_OthItemdesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_OthItemdesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_Rate.Focus()
        End If
    End Sub

    Private Sub Txt_Rate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Rate.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_CCode.Focus()
        End If
    End Sub

    Private Sub Cmb_AmtOverRide_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cmb_AmtOverRide.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_CCode.Focus()
        End If
    End Sub

    Private Sub Cmd_ChargeCode_Click_1(sender As Object, e As EventArgs) Handles Cmd_ChargeCode.Click
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
                Txt_CCode.Text = Trim(vform.keyfield & "")
                Txt_CCode.Select()
                Txt_CCode_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub CmdFreeze_Click(sender As Object, e As EventArgs) Handles CmdFreeze.Click
        Call checkValidation()
        If boolchk = False Then Exit Sub
        Dim ssql As String
        ssql = "select * from  Party_OtherChgsMaster where  itemcode = '" & Trim(Txt_OthItemCode.Text) & "'"
        gconnection.getDataSet(ssql, "log")
        If gdataset.Tables("log").Rows.Count > 0 Then
            If Mid(Me.CmdFreeze.Text, 1, 1) = "F" Then
                sqlstring = "UPDATE  Party_OtherChgsMaster "
                sqlstring = sqlstring & " SET Freeze= 'Y',UpdUser='" & gUsername & " ', Upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE itemcode = '" & Trim(Txt_OthItemCode.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "OtherChgsMaste")
                Me.CmdClear_Click(sender, e)
                CmdAdd.Text = "Add [F7]"
            Else
                sqlstring = "UPDATE  Party_OtherChgsMaster "
                sqlstring = sqlstring & " SET Freeze= 'N',UpdUser='" & gUsername & " ', Upddatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE itemcode = '" & Trim(Txt_OthItemCode.Text) & "'"
                gconnection.dataOperation(4, sqlstring, "OtherChgsMaste")
                Me.CmdClear_Click(sender, e)
                CmdAdd.Text = "Add [F7]"
            End If
        Else
            MessageBox.Show("ITEM WAS NOT EXISTS ", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        End If

    End Sub

    Private Sub Frm_OtherChargeMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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


    Private Sub Frm_OtherChargeMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Txt_OthItemCode.Focus()
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
                        If Controls(i_i).Name = "CmdAdd" Or Controls(i_i).Name = "CmdClear" Or Controls(i_i).Name = "CmdFreeze" Or Controls(i_i).Name = "CmdView" Or Controls(i_i).Name = "CmdBrowse" Or Controls(i_i).Name = "CmdExit" Or Controls(i_i).Name = "cmdreport" Or Controls(i_i).Name = "Cmd_PendingBill" Or Controls(i_i).Name = "Cmd_Bill" Then
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
        Dim r As New RPT_OtherCharge
        STR = "SELECT * FROM Party_OtherChgsMaster"
        Viewer.ssql = STR
        Viewer.Report = r
        Viewer.TableName = "Party_OtherChgsMaster"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text6")
        textobj1.Text = MyCompanyName

        Dim TXTOBJ2 As TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text11")
        TXTOBJ2.Text = "UserName : " & gUsername

        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = r.ReportDefinition.ReportObjects("Text15")
        TXTOBJ6.Text = Address1 & Address2

        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = r.ReportDefinition.ReportObjects("Text16")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
        'TXTOBJ9.Text = "PhoneNo : " & gphoneno

        Viewer.Show()
    End Sub

    Private Sub CmdBrowse_Click(sender As Object, e As EventArgs) Handles CmdBrowse.Click
        Dim OBJ1 As New VIEWHDR
        Dim ChildSql As String
        sqlstring = "SELECT Itemcode,ItemDesc,AmtOverride,Rate,Freeze FROM Party_OtherChgsMaster "
        ChildSql = ""
        gconnection.getDataSet(sqlstring, "Party_OtherChgsMaster")
        OBJ1.LOADGRID(gdataset.Tables("Party_OtherChgsMaster"), False, "FRM_OtherChargeMaster", ChildSql, "Itemcode", 0)
        OBJ1.Show()
    End Sub
End Class