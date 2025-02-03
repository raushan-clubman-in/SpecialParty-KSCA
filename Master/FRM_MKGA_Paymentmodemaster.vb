Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FRM_MKGA_Paymentmodemaster
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim sqlstring, PaymentType As String
    Dim vSeqNo As Double
    Dim gconnection As New GlobalClass


    Function checkValidation()
        boolchk = False
        ''********** Check  Payment Code Can't be blank *********************'''
        If Trim(txtPaymentcode.Text) = "" Then
            MsgBox("Payment Code Can't Be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, MyCompanyName)
            txtPaymentcode.Text = ""
            txtPaymentcode.Focus()
            ' Exit Function
            checkValidation = False
            Exit Function
        Else
            checkValidation = True
        End If
        '********** Check  Payment desc Can't be blank *********************'''
        If Trim(txtPaymentName.Text) = "" Then
            MsgBox("Payment Name Can't Be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, MyCompanyName)
            txtPaymentName.Text = ""
            txtPaymentName.Focus()
            ' Exit Function
            checkValidation = False
            Exit Function
        Else
            checkValidation = True
        End If
        ''********** Check  Prefix Can't be blank *********************'''
        If Trim(txt_Prefix.Text) = "" Then
            MsgBox("Prefix Can't Be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, MyCompanyName)
            txt_Prefix.Text = ""
            txt_Prefix.Focus()
            'Exit Function
            checkValidation = False
            Exit Function
        Else
            checkValidation = True
        End If
        ''********** Check PaymentType in PaymentMode *********************'''
        'If opt_Card.Checked = True Then
        '    PaymentType = "CD"
        'ElseIf opt_Cheque.Checked = True Then
        '    PaymentType = "CQ"
        'Else
        '    PaymentType = "NO"
        'End If
        ''********** Check  Account In Can't be blank *********************'''
        'If Trim(cbo_Subpaymentmode.Text) = "NO" Then
        '    If Trim(TxtAccIn.Text) = "" Then
        '        MsgBox("Account In Can't Be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, MyCompanyName)
        '        TxtAccIn.Text = ""
        '        TxtAccIn.Focus()
        '        checkValidation = False
        '    Else
        '        checkValidation = True
        '    End If
        ''********** Check  Account Name Can't be blank *********************'''
        'If Trim(txtAccName.Text) = "" Then
        '    MsgBox("Account Name Can't be Blank", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, MyCompanyName)
        ''txtAccName.Text = ""
        ''txtAccName.Focus()
        ''checkValidation = False
        'Else
        'checkValidation = True
        'End If

        boolchk = True
    End Function

    Private Sub FRM_MKGA_Paymentmodemaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(CmdClear, e)
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
            If CmdAdd.Enabled = True Then
                Call CmdAdd_Click(CmdAdd, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            If Cmd_view.Enabled = True Then
                Call Cmd_View_Click(Cmd_view, e)
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
            Call cmdexit_Click(cmdexit, e)
            Exit Sub
        End If
    End Sub

    Private Sub txtPaymentName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaymentName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txt_Prefix.Focus()
        End If
    End Sub

    Private Sub FRM_MKGA_Paymentmodemaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cbo_Subpaymentmode.SelectedIndex = 0
        ' cbo_MemberCodeRequired.SelectedIndex = 0
        '  opt_None.Checked = True
        'TxtAccIn.Visible = False
        'lbl_Accountin.Visible = False
        'TxtAccIn.Visible = False
        'cmdAccinHelp.Visible = False
        'txtAccName.Visible = False
        'TxtAccIn.Text = ""
        'txtAccName.Text = ""
        txtPaymentcode.Select()
        Paymentmodebool = True
        cmdPayment.Enabled = True
        cmdPayment.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        'Dim vmain, vsmod, vssmod As Long
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
        Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
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
                    Me.Cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub PaymentModeMaster_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Paymentmodebool = False
    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Call clearform(Me)
        'lbl_Accountin.Visible = False
        Me.txt_Prefix.Text = ""
        Me.txtPaymentcode.Text = ""
        Me.txtPaymentName.Text = ""
      
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = " "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.Enabled = True
        CmdAdd.Text = "Add [F7]"
       
        cmdPayment.Enabled = True
        txtPaymentcode.ReadOnly = False
        Me.CBO_SMVALIDATE.Text = ""
        'Me.CBO_SMVALIDATE.SelectedText = "YES"
        cbo_bill.Text = ""
        cbo_kot.Text = ""
        cbo_MemberCodeRequired.Text = ""
        cbo_Subpaymentmode.Text = ""

        'txtAccName.ReadOnly = False
        cmdPayment.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtPaymentcode.Select()
    End Sub

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        If CmdAdd.Text = "Add [F7]" Then
            If checkValidation() Then
                If boolchk = False Then Exit Sub
                vSeqNo = GetSeqno(txtPaymentcode.Text)
                sqlstring = " INSERT INTO paymentmodemaster (PaymentCode,PaymentName,Paymentseqno,prefix,Subpaystatus,MemberStatus,SMARTVALIDATE,Freeze,PaymentType,AddUserId,AddDateTime,kot,bill)"
                sqlstring = sqlstring & " VALUES ( '" & Trim(txtPaymentcode.Text) & "','" & Replace(Trim(txtPaymentName.Text), "'", "") & "',"
                sqlstring = sqlstring & " " & Val(vSeqNo) & " ,"
                sqlstring = sqlstring & "'" & Trim(CStr(txt_Prefix.Text)) & "','" & Trim(CStr(cbo_Subpaymentmode.Text)) & "','" & Trim(CStr(cbo_MemberCodeRequired.Text)) & "','" & Trim(CStr(Me.CBO_SMVALIDATE.Text)) & "',"
                sqlstring = sqlstring & "'N','" & Trim(PaymentType) & "','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','" & Me.cbo_kot.Text & "','" & Me.cbo_bill.Text & "')"
                'If CHK_PATMENTRATEYES.Checked = True Then
                '    sqlstring = sqlstring & " 'T',"
                'ElseIf CHK_PAYMENTRATENO.Checked = True Then
                '    sqlstring = sqlstring & " 'F',"
                'End If
                'sqlstring = sqlstring & " " & Val(CBO_PAYMENTRATE.Text) & " )"

                gconnection.dataOperation(1, sqlstring, "paymentmodemaster")
                Me.CmdClear_Click(sender, e)
            End If
        ElseIf CmdAdd.Text = "Update[F7]" Then
            If checkValidation() Then
                If boolchk = False Then Exit Sub
                If Mid(Me.CmdAdd.Text, 1, 1) = "U" Then
                    If Me.lbl_Freeze.Visible = True Then
                        MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        boolchk = False
                        Exit Sub
                    End If
                End If
                sqlstring = "UPDATE  paymentmodemaster "
                sqlstring = sqlstring & " SET PaymentName='" & Replace(Trim(txtPaymentName.Text), "'", "") & "',acctseqno =0,Subpaystatus ='" & Trim(CStr(cbo_Subpaymentmode.Text)) & "',MemberStatus = '" & Trim(CStr(cbo_MemberCodeRequired.Text)) & "' ,"
                sqlstring = sqlstring & " Prefix = '" & Trim(CStr(txt_Prefix.Text)) & "',PaymentType ='" & Trim(PaymentType) & "' ,UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N',SMARTVALIDATE='" & Trim(CStr(Me.CBO_SMVALIDATE.Text)) & "' ,kot='" & Me.cbo_kot.Text & "',bill='" & Me.cbo_bill.Text & "'"
                'If CHK_PATMENTRATEYES.Checked = True Then
                '    sqlstring = sqlstring & " PAYRATESTATUS = 'T'"
                'ElseIf CHK_PAYMENTRATENO.Checked = True Then
                '    sqlstring = sqlstring & " PAYRATESTATUS = 'F'"
                'End If
                'sqlstring = sqlstring & " PAYMENTMODEAMOUNT = " & Val(CBO_PAYMENTRATE.Text) & " '"
                sqlstring = sqlstring & " WHERE PaymentCode = '" & Trim(txtPaymentcode.Text) & "'"
                gconnection.dataOperation(2, sqlstring, "paymentmodemaster")
                Me.CmdClear_Click(sender, e)
                CmdAdd.Text = "Add [F7]"
            End If
        End If
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim STATUS As Integer
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  PaymentModeMaster "
                sqlstring = sqlstring & " SET Freeze= 'Y',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE PaymentCode = '" & Trim(txtPaymentcode.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "PaymentModeMaster")
                Me.CmdClear_Click(sender, e)
                CmdAdd.Text = "Add [F7]"
            Else
                Exit Sub
            End If

            'Else
            '    STATUS = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            '    If STATUS = 1 Then
            '        sqlstring = "UPDATE  PaymentModeMaster "
            '        sqlstring = sqlstring & " SET Freeze= 'N',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        sqlstring = sqlstring & " WHERE PaymentCode = '" & Trim(txtPaymentcode.Text) & "'"
            '        gconnection.dataOperation(4, sqlstring, "PaymentModeMaster")
            '        Me.CmdClear_Click(sender, e)
            '        CmdAdd.Text = "Add [F7]"
            '    Else
            '        Exit Sub
            '    End If

        End If
    End Sub

    Private Sub txt_Prefix_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Prefix.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cbo_MemberCodeRequired.Focus()
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cbo_Subpaymentmode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_Subpaymentmode.KeyPress
        Call Blank(e)
        If Asc(e.KeyChar) = 13 Then
            CBO_SMVALIDATE.Focus()
        End If
    End Sub

    Private Sub cbo_MemberCodeRequired_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_MemberCodeRequired.KeyPress
        Call Blank(e)
        If Asc(e.KeyChar) = 13 Then
            cbo_Subpaymentmode.Focus()
        End If
    End Sub
    'Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
    '    Dim sqlstring As String
    '    Dim _export As New EXPORT
    '    _export.TABLENAME = "PAYMENTMODEMASTER"
    '    sqlstring = "SELECT * FROM PAYMENTMODEMASTER order by PAYMENTCODE"
    '    Call _export.export_excel(sqlstring)
    '    _export.Show()
    '    Exit Sub
    'End Sub

    'Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
    '    'GroupBox3.Visible = True
    '    Dim vform As New report
    '    vform.ShowDialog(Me)
    '    vform.Close()
    '    vform = Nothing
    '    '    Dim sqlstring, SSQL As String
    '    '    Dim Viewer As New ReportViwer
    '    '    Dim r As New Crptpaymentmodemaster
    '    '    Dim POSdesc(), MemberCode() As String
    '    '    Dim SQLSTRING2 As String
    '    '    sqlstring = "select * from PAYMENTMODEMASTER"

    '    '    Call Viewer.GetDetails(sqlstring, "PAYMENTMODEMASTER", r)
    '    '    Viewer.TableName = "PAYMENTMODEMASTER"
    '    '    Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    '    TXTOBJ5 = r.ReportDefinition.ReportObjects("Text9")
    '    '    TXTOBJ5.Text = gCompanyname

    '    '    Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    '    TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
    '    '    TXTOBJ1.Text = "UserName : " & gUsername
    '    '    Viewer.Show()
    'End Sub

    Private Sub cmdPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPayment.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(PAYMENTCODE,'') AS  PAYMENTCODE,ISNULL(PAYMENTNAME,'') AS PAYMENTNAME FROM PaymentModeMaster"
            M_WhereCondition = " "
            vform.Field = "PAYMENTCODE,PAYMENTNAME"
            ' vform.Frmcalled = "   PAYMENTCODE     | PAYMENTNAME                                 "
            vform.vCaption = " Payment Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtPaymentcode.Text = Trim(vform.keyfield & "")
                txtPaymentcode.Select()
                txtPaymentcode_Validated(sender, e)
                CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub txtPaymentcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaymentcode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdPayment.Enabled = True Then
                Search = Trim(txtPaymentcode.Text)
                Call cmdPayment_Click(txtPaymentcode, e)
            End If
        End If
    End Sub

    Private Sub txtPaymentcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaymentcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtPaymentcode.Text) <> "" Then
                txtPaymentcode_Validated(txtPaymentcode, e)
            Else
                Call cmdPayment_Click(cmdPayment, e)
            End If
        End If
    End Sub

    Private Sub txtPaymentcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaymentcode.Validated
        ' Dim vstring As String
        If Trim(txtPaymentcode.Text) <> "" Then
            vSeqNo = GetSeqno(txtPaymentcode.Text)
            sqlstring = "SELECT PaymentCode,ISNULL(PaymentName,'') as PaymentName,ISNULL(Subpaystatus,'NO') AS subpaystatus,ISNULL(Prefix,'') AS Prefix,ISNULL(Freeze,'') AS Freeze,ISNULL(PaymentType,'') AS PaymentType,ISNULL(MemberStatus,'') AS MemberStatus,ISNULL(AddUserId,'') as AddUserId,AddDateTime,isnull(SMARTVALIDATE,'') as SMARTVALIDATE ,isnull(kot,'')as kot,isnull(bill,'')as bill FROM PaymentModeMaster WHERE paymentcode= '" & CStr(txtPaymentcode.Text) & "'"
            gconnection.getDataSet(sqlstring, "PaymentMode")
            If gdataset.Tables("PaymentMode").Rows.Count > 0 Then
                txtPaymentName.Clear()
                txtPaymentName.Text = Trim(CStr(gdataset.Tables("PaymentMode").Rows(0).Item("PaymentName")))
                txt_Prefix.Text = Trim(CStr(gdataset.Tables("PaymentMode").Rows(0).Item("Prefix")))
                cbo_Subpaymentmode.DropDownStyle = ComboBoxStyle.DropDown
                cbo_Subpaymentmode.Text = UCase(CStr(gdataset.Tables("PaymentMode").Rows(0).Item("Subpaystatus")))
                cbo_MemberCodeRequired.DropDownStyle = ComboBoxStyle.DropDown
                cbo_MemberCodeRequired.Text = UCase(CStr(gdataset.Tables("PaymentMode").Rows(0).Item("MemberStatus")))
                Me.cbo_kot.Text = UCase(CStr(gdataset.Tables("PaymentMode").Rows(0).Item("kot")))
                Me.cbo_bill.Text = UCase(CStr(gdataset.Tables("PaymentMode").Rows(0).Item("bill")))
                Me.CBO_SMVALIDATE.Text = UCase(CStr(gdataset.Tables("PaymentMode").Rows(0).Item("SMARTVALIDATE")))
               
                txtPaymentcode.ReadOnly = True
                txtPaymentName.Focus()
                If gdataset.Tables("PaymentMode").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("PaymentMode").Rows(0).Item("AddDateTime")), "dd-MMM-yyyy")
                    ' Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If
               
                cmdPayment.Enabled = False
                Me.CmdAdd.Text = "Update[F7]"
                Me.txtPaymentcode.ReadOnly = True
                Me.cmdPayment.Enabled = False
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                Me.txtPaymentName.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.CmdAdd.Text = "Add [F7]"
                txtPaymentcode.ReadOnly = False
                txtPaymentName.Focus()
            End If
        Else
            txtPaymentcode.Text = ""
            txtPaymentcode.Focus()
        End If
    End Sub

    Private Sub Cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_view.Click
        Dim FRM As New ReportDesigner
        If txtPaymentcode.Text.Length > 0 Then
            tables = " FROM paymentmodemaster WHERE paymentcode = '" & Trim(txtPaymentcode.Text) & "'"
        Else
            tables = "FROM paymentmodemaster "
        End If
        Gheader = "paymentmodemaster DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"PaymentCode", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"PaymentName", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Subpaystatus", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Prefix", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"PaymentType", "13"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"MemberStatus", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"smartvalidate", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"kot", "5"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"bill", "5"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"freeze", "6"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSERId", "10"}
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

    Private Sub CBO_SMVALIDATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBO_SMVALIDATE.KeyPress
        Call Blank(e)
        If Asc(e.KeyChar) = 13 Then
            cbo_kot.Focus()
        End If
    End Sub

    Private Sub cbo_kot_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_kot.KeyPress
        Call Blank(e)
        If Asc(e.KeyChar) = 13 Then
            cbo_bill.Focus()
        End If
    End Sub

    Private Sub cbo_bill_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_bill.KeyPress
        Call Blank(e)
        If Asc(e.KeyChar) = 13 Then
            CmdAdd.Focus()
        End If
    End Sub

    Private Sub Cmdbrse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbrse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM PAYMENTMODEMASTER"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM PAYMENTMODEMASTER", "SERIALNO", 0)
    End Sub

    Private Sub Cmdauth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdauth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM paymentmodemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM paymentmodemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
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

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE paymentmodemaster set  ", "PAYMENTCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM paymentmodemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM paymentmodemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
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

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE paymentmodemaster set  ", "PAYMENTCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM paymentmodemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM paymentmodemaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE paymentmodemaster set  ", "PAYMENTCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
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
        Dim sqlstring As String
        Dim Viewer As New ReportViwer
        Dim r As New Crptpaymentmodemaster
       
        sqlstring = "select * from PAYMENTMODEMASTER"

        Call Viewer.GetDetails(sqlstring, "PAYMENTMODEMASTER", r)
        Viewer.TableName = "PAYMENTMODEMASTER"
        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text9")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
        TXTOBJ1.Text = "UserName : " & gUsername
        Viewer.Show()
    End Sub
End Class