<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MKGA_Locationmaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MKGA_Locationmaster))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdlocationHelp = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtlocationcode = New System.Windows.Forms.TextBox()
        Me.txtlocationName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbrse = New System.Windows.Forms.Button()
        Me.Cmdview = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(192, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 15)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Location Master"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmdlocationHelp)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtlocationcode)
        Me.GroupBox1.Controls.Add(Me.txtlocationName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(195, 243)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 100)
        Me.GroupBox1.TabIndex = 132
        Me.GroupBox1.TabStop = False
        '
        'cmdlocationHelp
        '
        Me.cmdlocationHelp.Location = New System.Drawing.Point(416, 23)
        Me.cmdlocationHelp.Name = "cmdlocationHelp"
        Me.cmdlocationHelp.Size = New System.Drawing.Size(29, 22)
        Me.cmdlocationHelp.TabIndex = 118
        Me.cmdlocationHelp.Text = "F4"
        Me.cmdlocationHelp.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(175, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 15)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Location Code"
        '
        'txtlocationcode
        '
        Me.txtlocationcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtlocationcode.Location = New System.Drawing.Point(280, 24)
        Me.txtlocationcode.MaxLength = 10
        Me.txtlocationcode.Name = "txtlocationcode"
        Me.txtlocationcode.Size = New System.Drawing.Size(131, 20)
        Me.txtlocationcode.TabIndex = 117
        '
        'txtlocationName
        '
        Me.txtlocationName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtlocationName.Location = New System.Drawing.Point(280, 63)
        Me.txtlocationName.MaxLength = 20
        Me.txtlocationName.Name = "txtlocationName"
        Me.txtlocationName.Size = New System.Drawing.Size(131, 20)
        Me.txtlocationName.TabIndex = 116
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(175, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Location Desc."
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(860, 591)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Exit.TabIndex = 146
        Me.Cmd_Exit.Text = "Exit [F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = True
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(860, 523)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 145
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        '
        'Cmdbrse
        '
        Me.Cmdbrse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbrse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbrse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbrse.Location = New System.Drawing.Point(860, 455)
        Me.Cmdbrse.Name = "Cmdbrse"
        Me.Cmdbrse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbrse.TabIndex = 144
        Me.Cmdbrse.Text = "Browse"
        Me.Cmdbrse.UseVisualStyleBackColor = True
        '
        'Cmdview
        '
        Me.Cmdview.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdview.Image = CType(resources.GetObject("Cmdview.Image"), System.Drawing.Image)
        Me.Cmdview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdview.Location = New System.Drawing.Point(860, 317)
        Me.Cmdview.Name = "Cmdview"
        Me.Cmdview.Size = New System.Drawing.Size(144, 65)
        Me.Cmdview.TabIndex = 143
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
        Me.Cmd_Freeze.Location = New System.Drawing.Point(860, 250)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Freeze.TabIndex = 142
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(860, 184)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Clear.TabIndex = 141
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
        Me.Cmd_Add.Location = New System.Drawing.Point(860, 116)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Add.TabIndex = 140
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
        Me.lbl_Freeze.Location = New System.Drawing.Point(414, 362)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(0, 23)
        Me.lbl_Freeze.TabIndex = 147
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(860, 387)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 65)
        Me.Button1.TabIndex = 148
        Me.Button1.Text = "Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FRM_MKGA_Locationmaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbrse)
        Me.Controls.Add(Me.Cmdview)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "FRM_MKGA_Locationmaster"
        Me.Text = "Locationmaster"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdlocationHelp As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtlocationcode As System.Windows.Forms.TextBox
    Friend WithEvents txtlocationName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbrse As System.Windows.Forms.Button
    Friend WithEvents Cmdview As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
