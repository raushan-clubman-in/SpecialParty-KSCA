<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MKGA_GroupMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MKGA_GroupMaster))
        Me.CBO_CATEGORY = New System.Windows.Forms.ComboBox()
        Me.cmdGroupCode = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSname = New System.Windows.Forms.TextBox()
        Me.txtGroupDesc = New System.Windows.Forms.TextBox()
        Me.txtGroupCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbrse = New System.Windows.Forms.Button()
        Me.Cmdview = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CBO_CATEGORY
        '
        Me.CBO_CATEGORY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_CATEGORY.FormattingEnabled = True
        Me.CBO_CATEGORY.Location = New System.Drawing.Point(287, 164)
        Me.CBO_CATEGORY.Name = "CBO_CATEGORY"
        Me.CBO_CATEGORY.Size = New System.Drawing.Size(145, 21)
        Me.CBO_CATEGORY.TabIndex = 102
        '
        'cmdGroupCode
        '
        Me.cmdGroupCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroupCode.Location = New System.Drawing.Point(393, 48)
        Me.cmdGroupCode.Name = "cmdGroupCode"
        Me.cmdGroupCode.Size = New System.Drawing.Size(38, 21)
        Me.cmdGroupCode.TabIndex = 101
        Me.cmdGroupCode.Text = "F4"
        Me.cmdGroupCode.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(191, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 15)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Group Master"
        '
        'txtSname
        '
        Me.txtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSname.Location = New System.Drawing.Point(287, 129)
        Me.txtSname.MaxLength = 10
        Me.txtSname.Name = "txtSname"
        Me.txtSname.Size = New System.Drawing.Size(100, 20)
        Me.txtSname.TabIndex = 99
        '
        'txtGroupDesc
        '
        Me.txtGroupDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGroupDesc.Location = New System.Drawing.Point(287, 84)
        Me.txtGroupDesc.MaxLength = 30
        Me.txtGroupDesc.Name = "txtGroupDesc"
        Me.txtGroupDesc.Size = New System.Drawing.Size(228, 20)
        Me.txtGroupDesc.TabIndex = 98
        '
        'txtGroupCode
        '
        Me.txtGroupCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGroupCode.Location = New System.Drawing.Point(287, 48)
        Me.txtGroupCode.MaxLength = 10
        Me.txtGroupCode.Name = "txtGroupCode"
        Me.txtGroupCode.Size = New System.Drawing.Size(100, 20)
        Me.txtGroupCode.TabIndex = 97
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(153, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Category"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(153, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Short Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(153, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 15)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Group/Menu Desc."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(153, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 15)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Group /Menu Code"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBO_CATEGORY)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmdGroupCode)
        Me.GroupBox1.Controls.Add(Me.txtSname)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtGroupCode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtGroupDesc)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(214, 269)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 233)
        Me.GroupBox1.TabIndex = 103
        Me.GroupBox1.TabStop = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(861, 600)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Exit.TabIndex = 131
        Me.Cmd_Exit.Text = "Exit [F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = True
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(861, 533)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 130
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        '
        'Cmdbrse
        '
        Me.Cmdbrse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbrse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbrse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbrse.Location = New System.Drawing.Point(861, 464)
        Me.Cmdbrse.Name = "Cmdbrse"
        Me.Cmdbrse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbrse.TabIndex = 129
        Me.Cmdbrse.Text = "Browse"
        Me.Cmdbrse.UseVisualStyleBackColor = True
        '
        'Cmdview
        '
        Me.Cmdview.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdview.Image = CType(resources.GetObject("Cmdview.Image"), System.Drawing.Image)
        Me.Cmdview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdview.Location = New System.Drawing.Point(860, 323)
        Me.Cmdview.Name = "Cmdview"
        Me.Cmdview.Size = New System.Drawing.Size(144, 65)
        Me.Cmdview.TabIndex = 128
        Me.Cmdview.Text = "View [F9]"
        Me.Cmdview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdview.UseVisualStyleBackColor = True
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(860, 252)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Freeze.TabIndex = 127
        Me.Cmd_Freeze.Text = "Freeze [F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = True
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(860, 181)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Clear.TabIndex = 126
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(860, 110)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Add.TabIndex = 125
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(401, 544)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(0, 23)
        Me.lbl_Freeze.TabIndex = 132
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'cmdreport
        '
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(861, 392)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(144, 65)
        Me.cmdreport.TabIndex = 161
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.UseVisualStyleBackColor = True
        '
        'FRM_MKGA_GroupMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.cmdreport)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbrse)
        Me.Controls.Add(Me.Cmdview)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.KeyPreview = True
        Me.Name = "FRM_MKGA_GroupMaster"
        Me.Text = "GroupMaster"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBO_CATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents cmdGroupCode As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSname As System.Windows.Forms.TextBox
    Friend WithEvents txtGroupDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbrse As System.Windows.Forms.Button
    Friend WithEvents Cmdview As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmdreport As System.Windows.Forms.Button
End Class
