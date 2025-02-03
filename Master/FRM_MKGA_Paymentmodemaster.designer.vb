<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MKGA_Paymentmodemaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MKGA_Paymentmodemaster))
        Me.cmdPayment = New System.Windows.Forms.Button()
        Me.cbo_bill = New System.Windows.Forms.ComboBox()
        Me.cbo_kot = New System.Windows.Forms.ComboBox()
        Me.CBO_SMVALIDATE = New System.Windows.Forms.ComboBox()
        Me.cbo_Subpaymentmode = New System.Windows.Forms.ComboBox()
        Me.cbo_MemberCodeRequired = New System.Windows.Forms.ComboBox()
        Me.txtPaymentName = New System.Windows.Forms.TextBox()
        Me.txt_Prefix = New System.Windows.Forms.TextBox()
        Me.txtPaymentcode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbrse = New System.Windows.Forms.Button()
        Me.Cmd_view = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdPayment
        '
        Me.cmdPayment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPayment.Location = New System.Drawing.Point(410, 78)
        Me.cmdPayment.Name = "cmdPayment"
        Me.cmdPayment.Size = New System.Drawing.Size(36, 23)
        Me.cmdPayment.TabIndex = 36
        Me.cmdPayment.Text = "F4"
        Me.cmdPayment.UseVisualStyleBackColor = True
        '
        'cbo_bill
        '
        Me.cbo_bill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_bill.FormattingEnabled = True
        Me.cbo_bill.Items.AddRange(New Object() {"NO", "YES"})
        Me.cbo_bill.Location = New System.Drawing.Point(251, 291)
        Me.cbo_bill.Name = "cbo_bill"
        Me.cbo_bill.Size = New System.Drawing.Size(154, 21)
        Me.cbo_bill.TabIndex = 35
        '
        'cbo_kot
        '
        Me.cbo_kot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_kot.FormattingEnabled = True
        Me.cbo_kot.Items.AddRange(New Object() {"NO", "YES"})
        Me.cbo_kot.Location = New System.Drawing.Point(251, 262)
        Me.cbo_kot.Name = "cbo_kot"
        Me.cbo_kot.Size = New System.Drawing.Size(154, 21)
        Me.cbo_kot.TabIndex = 34
        '
        'CBO_SMVALIDATE
        '
        Me.CBO_SMVALIDATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_SMVALIDATE.FormattingEnabled = True
        Me.CBO_SMVALIDATE.Items.AddRange(New Object() {"NO", "YES"})
        Me.CBO_SMVALIDATE.Location = New System.Drawing.Point(251, 233)
        Me.CBO_SMVALIDATE.Name = "CBO_SMVALIDATE"
        Me.CBO_SMVALIDATE.Size = New System.Drawing.Size(154, 21)
        Me.CBO_SMVALIDATE.TabIndex = 33
        '
        'cbo_Subpaymentmode
        '
        Me.cbo_Subpaymentmode.FormattingEnabled = True
        Me.cbo_Subpaymentmode.Items.AddRange(New Object() {"NO", "YES"})
        Me.cbo_Subpaymentmode.Location = New System.Drawing.Point(251, 200)
        Me.cbo_Subpaymentmode.Name = "cbo_Subpaymentmode"
        Me.cbo_Subpaymentmode.Size = New System.Drawing.Size(154, 21)
        Me.cbo_Subpaymentmode.TabIndex = 32
        '
        'cbo_MemberCodeRequired
        '
        Me.cbo_MemberCodeRequired.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_MemberCodeRequired.FormattingEnabled = True
        Me.cbo_MemberCodeRequired.Items.AddRange(New Object() {"SMART CARD ", "ROOM CHECKIN ", "MEMBER ACCOUNT ", "BANK INSTRUMENT", "CASH", "CLUB ACCOUNT", "EMPLOYEE"})
        Me.cbo_MemberCodeRequired.Location = New System.Drawing.Point(251, 172)
        Me.cbo_MemberCodeRequired.Name = "cbo_MemberCodeRequired"
        Me.cbo_MemberCodeRequired.Size = New System.Drawing.Size(154, 21)
        Me.cbo_MemberCodeRequired.TabIndex = 31
        '
        'txtPaymentName
        '
        Me.txtPaymentName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentName.Location = New System.Drawing.Point(251, 109)
        Me.txtPaymentName.MaxLength = 30
        Me.txtPaymentName.Name = "txtPaymentName"
        Me.txtPaymentName.Size = New System.Drawing.Size(154, 20)
        Me.txtPaymentName.TabIndex = 30
        '
        'txt_Prefix
        '
        Me.txt_Prefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Prefix.Location = New System.Drawing.Point(251, 140)
        Me.txt_Prefix.MaxLength = 8
        Me.txt_Prefix.Name = "txt_Prefix"
        Me.txt_Prefix.Size = New System.Drawing.Size(154, 20)
        Me.txt_Prefix.TabIndex = 29
        '
        'txtPaymentcode
        '
        Me.txtPaymentcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentcode.Location = New System.Drawing.Point(251, 80)
        Me.txtPaymentcode.MaxLength = 15
        Me.txtPaymentcode.Name = "txtPaymentcode"
        Me.txtPaymentcode.Size = New System.Drawing.Size(154, 20)
        Me.txtPaymentcode.TabIndex = 28
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(100, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 15)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Payment Name"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(100, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 15)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Prefix"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(100, 178)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 15)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Required Input"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(100, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 15)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Subpayment Mode"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(100, 235)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 15)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Smart Card Validate"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(100, 266)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 15)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Apply In KOT"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(100, 297)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Apply in Settlement"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(100, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Payment Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(188, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 19)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Payment/Operation Mode Master"
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(862, 591)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(144, 65)
        Me.cmdexit.TabIndex = 431
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(862, 520)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 430
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        '
        'Cmdbrse
        '
        Me.Cmdbrse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbrse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbrse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbrse.Location = New System.Drawing.Point(862, 449)
        Me.Cmdbrse.Name = "Cmdbrse"
        Me.Cmdbrse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbrse.TabIndex = 429
        Me.Cmdbrse.Text = "Browse"
        Me.Cmdbrse.UseVisualStyleBackColor = True
        '
        'Cmd_view
        '
        Me.Cmd_view.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_view.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_view.Image = CType(resources.GetObject("Cmd_view.Image"), System.Drawing.Image)
        Me.Cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_view.Location = New System.Drawing.Point(862, 313)
        Me.Cmd_view.Name = "Cmd_view"
        Me.Cmd_view.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_view.TabIndex = 428
        Me.Cmd_view.Text = "View [F9]"
        Me.Cmd_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_view.UseVisualStyleBackColor = True
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(862, 242)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Freeze.TabIndex = 427
        Me.Cmd_Freeze.Text = "Freeze [F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(862, 171)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(144, 65)
        Me.CmdClear.TabIndex = 426
        Me.CmdClear.Text = "Clear [F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdAdd
        '
        Me.CmdAdd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdAdd.Image = CType(resources.GetObject("CmdAdd.Image"), System.Drawing.Image)
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdd.Location = New System.Drawing.Point(862, 100)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(144, 65)
        Me.CmdAdd.TabIndex = 425
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmdPayment)
        Me.GroupBox1.Controls.Add(Me.txtPaymentcode)
        Me.GroupBox1.Controls.Add(Me.cbo_bill)
        Me.GroupBox1.Controls.Add(Me.txt_Prefix)
        Me.GroupBox1.Controls.Add(Me.cbo_kot)
        Me.GroupBox1.Controls.Add(Me.txtPaymentName)
        Me.GroupBox1.Controls.Add(Me.CBO_SMVALIDATE)
        Me.GroupBox1.Controls.Add(Me.cbo_MemberCodeRequired)
        Me.GroupBox1.Controls.Add(Me.cbo_Subpaymentmode)
        Me.GroupBox1.Location = New System.Drawing.Point(226, 177)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 358)
        Me.GroupBox1.TabIndex = 432
        Me.GroupBox1.TabStop = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(404, 556)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(0, 23)
        Me.lbl_Freeze.TabIndex = 433
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'cmdreport
        '
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(862, 381)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(144, 65)
        Me.cmdreport.TabIndex = 434
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.UseVisualStyleBackColor = True
        '
        'FRM_MKGA_Paymentmodemaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.cmdreport)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbrse)
        Me.Controls.Add(Me.Cmd_view)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FRM_MKGA_Paymentmodemaster"
        Me.Text = "Paymentmodemaster"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdPayment As System.Windows.Forms.Button
    Friend WithEvents cbo_bill As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_kot As System.Windows.Forms.ComboBox
    Friend WithEvents CBO_SMVALIDATE As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Subpaymentmode As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_MemberCodeRequired As System.Windows.Forms.ComboBox
    Friend WithEvents txtPaymentName As System.Windows.Forms.TextBox
    Friend WithEvents txt_Prefix As System.Windows.Forms.TextBox
    Friend WithEvents txtPaymentcode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbrse As System.Windows.Forms.Button
    Friend WithEvents Cmd_view As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmdreport As System.Windows.Forms.Button
End Class
