Public Class DOCSelection
    Inherits System.Windows.Forms.Form
    Public GDOCUNDER As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal DOCUNDER As String)

        MyBase.New()
        GDOCUNDER = DOCUNDER
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Grp_Operation As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_DOCType As System.Windows.Forms.Label
    Friend WithEvents txt_DOCType As System.Windows.Forms.TextBox
    Friend WithEvents cmd_POSLocationHelp As System.Windows.Forms.Button
    Friend WithEvents txt_POSCode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_POSCode As System.Windows.Forms.Label
    Friend WithEvents txt_POSDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmd_Ok As System.Windows.Forms.Button
    Friend WithEvents cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DOCSelection))
        Me.Grp_Operation = New System.Windows.Forms.GroupBox
        Me.txt_POSCode = New System.Windows.Forms.TextBox
        Me.cmd_POSLocationHelp = New System.Windows.Forms.Button
        Me.lbl_DOCType = New System.Windows.Forms.Label
        Me.txt_DOCType = New System.Windows.Forms.TextBox
        Me.lbl_POSCode = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_POSDesc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmd_Ok = New System.Windows.Forms.Button
        Me.cmd_Cancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Grp_Operation
        '
        Me.Grp_Operation.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Operation.Location = New System.Drawing.Point(96, 144)
        Me.Grp_Operation.Name = "Grp_Operation"
        Me.Grp_Operation.Size = New System.Drawing.Size(264, 56)
        Me.Grp_Operation.TabIndex = 10
        Me.Grp_Operation.TabStop = False
        '
        'txt_POSCode
        '
        Me.txt_POSCode.BackColor = System.Drawing.Color.White
        Me.txt_POSCode.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_POSCode.Location = New System.Drawing.Point(152, 62)
        Me.txt_POSCode.MaxLength = 15
        Me.txt_POSCode.Name = "txt_POSCode"
        Me.txt_POSCode.Size = New System.Drawing.Size(80, 29)
        Me.txt_POSCode.TabIndex = 0
        Me.txt_POSCode.Text = ""
        '
        'cmd_POSLocationHelp
        '
        Me.cmd_POSLocationHelp.Image = CType(resources.GetObject("cmd_POSLocationHelp.Image"), System.Drawing.Image)
        Me.cmd_POSLocationHelp.Location = New System.Drawing.Point(232, 62)
        Me.cmd_POSLocationHelp.Name = "cmd_POSLocationHelp"
        Me.cmd_POSLocationHelp.Size = New System.Drawing.Size(24, 29)
        Me.cmd_POSLocationHelp.TabIndex = 7
        '
        'lbl_DOCType
        '
        Me.lbl_DOCType.AutoSize = True
        Me.lbl_DOCType.BackColor = System.Drawing.Color.Transparent
        Me.lbl_DOCType.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DOCType.ForeColor = System.Drawing.Color.Black
        Me.lbl_DOCType.Location = New System.Drawing.Point(24, 96)
        Me.lbl_DOCType.Name = "lbl_DOCType"
        Me.lbl_DOCType.Size = New System.Drawing.Size(124, 25)
        Me.lbl_DOCType.TabIndex = 9
        Me.lbl_DOCType.Text = "DOC TYPE :"
        '
        'txt_DOCType
        '
        Me.txt_DOCType.BackColor = System.Drawing.Color.White
        Me.txt_DOCType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_DOCType.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DOCType.Location = New System.Drawing.Point(152, 96)
        Me.txt_DOCType.MaxLength = 50
        Me.txt_DOCType.Name = "txt_DOCType"
        Me.txt_DOCType.Size = New System.Drawing.Size(256, 29)
        Me.txt_DOCType.TabIndex = 1
        Me.txt_DOCType.Text = ""
        '
        'lbl_POSCode
        '
        Me.lbl_POSCode.AutoSize = True
        Me.lbl_POSCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_POSCode.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_POSCode.ForeColor = System.Drawing.Color.Black
        Me.lbl_POSCode.Location = New System.Drawing.Point(24, 64)
        Me.lbl_POSCode.Name = "lbl_POSCode"
        Me.lbl_POSCode.Size = New System.Drawing.Size(124, 25)
        Me.lbl_POSCode.TabIndex = 6
        Me.lbl_POSCode.Text = "POS CODE :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(16, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(416, 97)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'txt_POSDesc
        '
        Me.txt_POSDesc.BackColor = System.Drawing.Color.White
        Me.txt_POSDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_POSDesc.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_POSDesc.Location = New System.Drawing.Point(256, 62)
        Me.txt_POSDesc.MaxLength = 50
        Me.txt_POSDesc.Name = "txt_POSDesc"
        Me.txt_POSDesc.ReadOnly = True
        Me.txt_POSDesc.Size = New System.Drawing.Size(152, 29)
        Me.txt_POSDesc.TabIndex = 8
        Me.txt_POSDesc.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(88, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(271, 28)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "CHOOSE POS LOCATION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd_Ok
        '
        Me.cmd_Ok.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmd_Ok.BackgroundImage = CType(resources.GetObject("cmd_Ok.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Ok.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmd_Ok.ForeColor = System.Drawing.Color.White
        Me.cmd_Ok.Image = CType(resources.GetObject("cmd_Ok.Image"), System.Drawing.Image)
        Me.cmd_Ok.Location = New System.Drawing.Point(112, 160)
        Me.cmd_Ok.Name = "cmd_Ok"
        Me.cmd_Ok.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Ok.TabIndex = 2
        Me.cmd_Ok.Text = "OK [F7]"
        '
        'cmd_Cancel
        '
        Me.cmd_Cancel.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Cancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmd_Cancel.ForeColor = System.Drawing.Color.White
        Me.cmd_Cancel.Image = CType(resources.GetObject("cmd_Cancel.Image"), System.Drawing.Image)
        Me.cmd_Cancel.Location = New System.Drawing.Point(240, 160)
        Me.cmd_Cancel.Name = "cmd_Cancel"
        Me.cmd_Cancel.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Cancel.TabIndex = 3
        Me.cmd_Cancel.Text = "Cancel [F11]"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'DOCSelection
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(446, 212)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmd_Ok)
        Me.Controls.Add(Me.cmd_Cancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_POSDesc)
        Me.Controls.Add(Me.txt_POSCode)
        Me.Controls.Add(Me.lbl_DOCType)
        Me.Controls.Add(Me.txt_DOCType)
        Me.Controls.Add(Me.lbl_POSCode)
        Me.Controls.Add(Me.Grp_Operation)
        Me.Controls.Add(Me.cmd_POSLocationHelp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "DOCSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CHOOSE POS LOCATION"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim vSeqno As Double
    Dim sqlstring As String
    Dim boolchk As Boolean
    Dim gconnection As New GlobalClass
    Dim PACKINGPERCENT As Double
    Private Sub DOCSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearform(Me)
        txt_POSCode.Focus()
    End Sub
    Private Sub cmd_POSLocationHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_POSLocationHelp.Click
        If GmoduleName = "KOT ENTRY" Then
            gSQLString = "SELECT POSCODE,POSDESC,kotprefix AS PREFIX FROM posmaster"
        ElseIf GmoduleName = "Final Billing" Then
            gSQLString = "SELECT POSCODE,POSDESC,finalprefix as PREFIX FROM posmaster"
        ElseIf GmoduleName = "DIRECT BILLING" Then


            gSQLString = "SELECT POSCODE,POSDESC,directprefix as PREFIX FROM posmaster"
        ElseIf GmoduleName = "Service Billing" Then
            gSQLString = "SELECT POSCODE,POSDESC,directprefix as PREFIX FROM posmaster"
        End If
        If GmoduleName = "KOT ENTRY" Then
            If gUserCategory <> "S" Then
                M_WhereCondition = " WHERE ISNULL(KOTPREFIX,'') <> '' AND ISNULL(Freeze,'') <> 'Y' poscode in (SELECT poscode FROM POS_USERCONTROL where username='" & gUsername & "')"
            Else
                M_WhereCondition = " WHERE ISNULL(Freeze,'') <> 'Y' AND ISNULL(KOTPREFIX,'') <> '' "
            End If
        ElseIf GmoduleName = "Final Billing" Then
            If gUserCategory <> "S" Then
                M_WhereCondition = " WHERE ISNULL(finalprefix,'') <> '' AND ISNULL(Freeze,'') <> 'Y' poscode in (SELECT poscode FROM POS_USERCONTROL where username='" & gUsername & "')"
            Else
                M_WhereCondition = " WHERE ISNULL(Freeze,'') <> 'Y' AND ISNULL(finalprefix,'') <> '' "
            End If
        ElseIf GmoduleName = "DIRECT BILLING" Then
            If gUserCategory <> "S" Then
                M_WhereCondition = " WHERE ISNULL(directprefix,'') <> '' AND ISNULL(Freeze,'') <> 'Y' poscode in (SELECT poscode FROM POS_USERCONTROL where username='" & gUsername & "')"
            Else
                M_WhereCondition = " WHERE ISNULL(Freeze,'') <> 'Y' AND ISNULL(directprefix,'') <> '' "
            End If
        ElseIf GmoduleName = "Service Billing" Then
            If gUserCategory <> "S" Then
                M_WhereCondition = " WHERE ISNULL(directprefix,'') <> '' AND ISNULL(Freeze,'') <> 'Y' poscode in (SELECT poscode FROM POS_USERCONTROL where username='" & gUsername & "')"
            Else
                M_WhereCondition = " WHERE ISNULL(Freeze,'') <> 'Y' AND ISNULL(directprefix,'') <> '' "
            End If
        End If

        Dim vform As New LIST_OPERATION1
        vform.Field = "POSCODE,POSDESC,KOTPREFIX"
        'vform.vFormatstring = "      POS CODE         |           DOC TYPE                |        POSDESC         "
        vform.vCaption = "POS Master Help"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Me.txt_POSCode.Text = Trim(vform.keyfield & "")
            Me.txt_DOCType.Text = Trim(vform.keyfield2 & "")
            Me.txt_POSDesc.Text = Trim(vform.keyfield1 & "")
            'PACKINGPERCENT = Val(Trim(vform.keyfield3 & ""))
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub cmd_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Ok.Click
        Call checkvalidation()
        If boolchk = False Then Exit Sub
        If GmoduleName = "KOT ENTRY" Then
            sqlstring = " SELECT KOTTYPE FROM POSMASTER WHERE POSCODE = '" & Trim(txt_POSCode.Text) & "'"
            gconnection.getDataSet(sqlstring, "KOT")
            If gdataset.Tables("KOT").Rows.Count > 0 Then
                If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then

                    Dim WOKotentry As New FRM_TKGA_SmartKotEntry(Trim(txt_POSCode.Text), Trim(txt_DOCType.Text))
                    Me.Hide()
                    WOKotentry.FormBorderStyle = FormBorderStyle.FixedDialog
                    WOKotentry.MdiParent = MDIParentobj
                    WOKotentry.Show()
                    Me.Close()
                Else
                    Dim WOKotentry As New FRM_TKGA_SmartKotEntry(Trim(txt_POSCode.Text), Trim(txt_DOCType.Text))
                    Me.Hide()
                    WOKotentry.FormBorderStyle = FormBorderStyle.FixedDialog
                    WOKotentry.MdiParent = MDIParentobj
                    WOKotentry.Show()
                    Me.Close()

                End If
            End If
        ElseIf GmoduleName = "Final Billing" Then
            sqlstring = " SELECT KOTTYPE FROM POSMASTER WHERE POSCODE = '" & Trim(txt_POSCode.Text) & "'"
            gconnection.getDataSet(sqlstring, "KOT")
            If gdataset.Tables("KOT").Rows.Count > 0 Then
                If gdataset.Tables("KOT").Rows(0).Item("KOTTYPE") = "MANUAL" Then
                    Dim WOKotentry As New FRM_TKGA_FinalBilling(Trim(txt_POSCode.Text), Trim(txt_DOCType.Text))
                    Me.Hide()
                    WOKotentry.FormBorderStyle = FormBorderStyle.FixedDialog
                    WOKotentry.MdiParent = MDIParentobj
                    WOKotentry.Show()
                    Me.Close()

                Else
                    Dim WOKotentry As New FRM_TKGA_FinalBilling(Trim(txt_POSCode.Text), Trim(txt_DOCType.Text))
                    Me.Hide()
                    WOKotentry.FormBorderStyle = FormBorderStyle.FixedDialog
                    WOKotentry.MdiParent = MDIParentobj
                    WOKotentry.Show()
                    Me.Close()

                End If
            End If
        ElseIf GmoduleName = "DIRECT BILLING" Then
            Dim WOKotentry As New FRM_TKGA_Directbilling(Trim(txt_POSCode.Text), Trim(txt_DOCType.Text))
            Me.Hide()
            WOKotentry.FormBorderStyle = FormBorderStyle.FixedDialog
            WOKotentry.MdiParent = MDIParentobj
            WOKotentry.Show()
            Me.Close()
        ElseIf GmoduleName = "Service Billing" Then
            gCenterlized = "N"
            Dim objmanualbill As New FRM_TKGA_ServiceBill(Trim(txt_POSCode.Text), Trim(txt_DOCType.Text))
            Me.Hide()
            objmanualbill.FormBorderStyle = FormBorderStyle.FixedDialog
            objmanualbill.MdiParent = MDIParentobj
            Me.Close()
            objmanualbill.Show()
        End If
    End Sub
    Private Sub cmd_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Cancel.Click
        Me.Close()
    End Sub
    Private Sub txt_POSCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_POSCode.KeyPress
        ' getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_POSCode.Text) <> "" Then
                Call txt_POSCode_Validated(txt_POSCode, e)
            Else
                Call cmd_POSLocationHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txt_POSDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_POSDesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txt_DOCType.Focus()
        End If
    End Sub

    Private Sub txt_DOCType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_DOCType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmd_Ok.Focus()
        End If
    End Sub

    Private Sub txt_POSCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_POSCode.Validated
        If Trim(txt_POSCode.Text) <> "" Then
            If GmoduleName = "KOT ENTRY" Then
                sqlstring = "SELECT poscode,posdesc,kotprefix FROM posmaster  WHERE Poscode='" & Trim(txt_POSCode.Text) & "' AND ISNULL(Freeze,'') <> 'Y' "
            ElseIf GmoduleName = "Final Billing" Then
                sqlstring = "SELECT poscode,posdesc,finalprefix as kotprefix FROM posmaster  WHERE Poscode='" & Trim(txt_POSCode.Text) & "' AND ISNULL(Freeze,'') <> 'Y' "
            ElseIf GmoduleName = "DIRECT BILLING" Then
                sqlstring = "SELECT poscode,posdesc,directprefix as kotprefix FROM posmaster  WHERE Poscode='" & Trim(txt_POSCode.Text) & "' AND ISNULL(Freeze,'') <> 'Y' "
            ElseIf GmoduleName = "Service Billing" Then
                sqlstring = "SELECT poscode,posdesc,directprefix as kotprefix FROM posmaster  WHERE Poscode='" & Trim(txt_POSCode.Text) & "' AND ISNULL(Freeze,'') <> 'Y' "
            End If

            If gUserCategory <> "S" Then
                sqlstring = sqlstring & " and poscode in (SELECT poscode FROM POS_USERCONTROL where username='" & gUsername & "')"
            End If
            gconnection.getDataSet(sqlstring, "POSdocument")
            If gdataset.Tables("POSdocument").Rows.Count > 0 Then
                txt_POSCode.Text = Trim(gdataset.Tables("POSdocument").Rows(0).Item("POSCODE"))
                txt_POSDesc.Text = Trim(gdataset.Tables("POSdocument").Rows(0).Item("POSDesc"))
                txt_DOCType.Text = Trim(gdataset.Tables("POSdocument").Rows(0).Item("kotprefix"))
                'PACKINGPERCENT = Val(gdataset.Tables("POSdocument").Rows(0).Item("PACKINGPERCENT"))
                cmd_POSLocationHelp.Enabled = False
                txt_POSCode.ReadOnly = True
                cmd_Ok.Focus()
            Else
                txt_POSCode.Text = ""
                txt_POSDesc.Text = ""
                txt_POSCode.Focus()
                PACKINGPERCENT = 0
            End If
        Else
            txt_POSCode.Text = ""
            PACKINGPERCENT = 0
            txt_POSCode.Focus()
        End If
    End Sub

    Private Sub DOCSelection_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F7 Then
            Call cmd_Ok_Click(cmd_Ok, e)
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub txt_POSCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_POSCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmd_POSLocationHelp_Click(cmd_POSLocationHelp, e)
        End If
    End Sub
    Private Sub checkvalidation()
        boolchk = False
        '''********** Check  POSCode is blank
        If Trim(txt_POSCode.Text) = "" Then
            MessageBox.Show(" POSCode can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_POSCode.Focus()
            Exit Sub
        End If
        '''********** Check  DocType Code is blank
        If Trim(txt_DOCType.Text) = "" Then
            MessageBox.Show(" Doctype can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_DOCType.Focus()
            Exit Sub
        End If
        '''********** Check POSDesc is blank
        If Trim(txt_POSDesc.Text) = "" Then
            MessageBox.Show(" POSDesc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_POSDesc.Focus()
            Exit Sub
        End If
        boolchk = True
        'cbo_PaymentMode.Focus()
    End Sub

    Private Sub txt_DOCType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_DOCType.Validated
        'If Trim(txt_DOCType.Text) <> "" Then
        '    sqlstring = "SELECT * FROM POSdocument WHERE Doctype='" & Trim(txt_DOCType.Text) & "' AND ISNULL(Freeze,'') <> 'Y'"
        '    gconnection.getDataSet(sqlstring, "DocumentPOS")
        '    If gdataset.Tables("DocumentPOS").Rows.Count > 0 Then
        '        txt_POSCode.Text = Trim(gdataset.Tables("DocumentPOS").Rows(0).Item("POSCODE"))
        '        txt_POSDesc.Text = Trim(gdataset.Tables("DocumentPOS").Rows(0).Item("POSDESC"))
        '        txt_DOCType.Text = Trim(gdataset.Tables("DocumentPOS").Rows(0).Item("DOCTYPE"))
        '        cmd_POSLocationHelp.Enabled = False
        '        txt_POSCode.ReadOnly = True
        '        cmd_Ok.Focus()
        '    Else
        '        txt_POSCode.Text = ""
        '        txt_POSDesc.Text = ""
        '        txt_DOCType.Text = ""
        '        txt_DOCType.Focus()
        '    End If
        'Else
        '    txt_DOCType.Text = ""
        '    txt_DOCType.Focus()
        'End If
    End Sub

    Private Sub txt_POSCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_POSCode.TextChanged

    End Sub
End Class
