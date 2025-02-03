<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MKGA_Tablemaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MKGA_Tablemaster))
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbrse = New System.Windows.Forms.Button()
        Me.Cmd_view = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.cmdTableHelp = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTableNo = New System.Windows.Forms.TextBox()
        Me.TXT_POSDESC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMDPOSHELP = New System.Windows.Forms.Button()
        Me.Poscode = New System.Windows.Forms.Label()
        Me.Txt_poscode = New System.Windows.Forms.TextBox()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.cmd_rpt = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(863, 581)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Exit.TabIndex = 154
        Me.Cmd_Exit.Text = "Exit [F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = True
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(863, 514)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 153
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        '
        'Cmdbrse
        '
        Me.Cmdbrse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbrse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbrse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbrse.Location = New System.Drawing.Point(863, 448)
        Me.Cmdbrse.Name = "Cmdbrse"
        Me.Cmdbrse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbrse.TabIndex = 152
        Me.Cmdbrse.Text = "Browse"
        Me.Cmdbrse.UseVisualStyleBackColor = True
        '
        'Cmd_view
        '
        Me.Cmd_view.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_view.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_view.Image = CType(resources.GetObject("Cmd_view.Image"), System.Drawing.Image)
        Me.Cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_view.Location = New System.Drawing.Point(863, 315)
        Me.Cmd_view.Name = "Cmd_view"
        Me.Cmd_view.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_view.TabIndex = 151
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
        Me.Cmd_Freeze.Location = New System.Drawing.Point(863, 249)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Freeze.TabIndex = 150
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(863, 181)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Clear.TabIndex = 149
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
        Me.Cmd_Add.Location = New System.Drawing.Point(863, 115)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Add.TabIndex = 148
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'cmdTableHelp
        '
        Me.cmdTableHelp.Location = New System.Drawing.Point(416, 23)
        Me.cmdTableHelp.Name = "cmdTableHelp"
        Me.cmdTableHelp.Size = New System.Drawing.Size(29, 22)
        Me.cmdTableHelp.TabIndex = 118
        Me.cmdTableHelp.Text = "F4"
        Me.cmdTableHelp.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(175, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Table No"
        '
        'txtTableNo
        '
        Me.txtTableNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTableNo.Location = New System.Drawing.Point(280, 24)
        Me.txtTableNo.MaxLength = 10
        Me.txtTableNo.Name = "txtTableNo"
        Me.txtTableNo.Size = New System.Drawing.Size(131, 20)
        Me.txtTableNo.TabIndex = 117
        '
        'TXT_POSDESC
        '
        Me.TXT_POSDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_POSDESC.Location = New System.Drawing.Point(281, 90)
        Me.TXT_POSDESC.MaxLength = 20
        Me.TXT_POSDESC.Name = "TXT_POSDESC"
        Me.TXT_POSDESC.Size = New System.Drawing.Size(163, 20)
        Me.TXT_POSDESC.TabIndex = 116
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(175, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 15)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Pos Desc."
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CMDPOSHELP)
        Me.GroupBox1.Controls.Add(Me.Poscode)
        Me.GroupBox1.Controls.Add(Me.Txt_poscode)
        Me.GroupBox1.Controls.Add(Me.cmdTableHelp)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtTableNo)
        Me.GroupBox1.Controls.Add(Me.TXT_POSDESC)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(205, 264)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 166)
        Me.GroupBox1.TabIndex = 147
        Me.GroupBox1.TabStop = False
        '
        'CMDPOSHELP
        '
        Me.CMDPOSHELP.Location = New System.Drawing.Point(415, 53)
        Me.CMDPOSHELP.Name = "CMDPOSHELP"
        Me.CMDPOSHELP.Size = New System.Drawing.Size(29, 22)
        Me.CMDPOSHELP.TabIndex = 121
        Me.CMDPOSHELP.Text = "?"
        Me.CMDPOSHELP.UseVisualStyleBackColor = True
        '
        'Poscode
        '
        Me.Poscode.AutoSize = True
        Me.Poscode.BackColor = System.Drawing.Color.Transparent
        Me.Poscode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Poscode.Location = New System.Drawing.Point(175, 58)
        Me.Poscode.Name = "Poscode"
        Me.Poscode.Size = New System.Drawing.Size(61, 15)
        Me.Poscode.TabIndex = 119
        Me.Poscode.Text = "Pos Code"
        '
        'Txt_poscode
        '
        Me.Txt_poscode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_poscode.Location = New System.Drawing.Point(280, 55)
        Me.Txt_poscode.MaxLength = 10
        Me.Txt_poscode.Name = "Txt_poscode"
        Me.Txt_poscode.Size = New System.Drawing.Size(131, 20)
        Me.Txt_poscode.TabIndex = 120
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(414, 462)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(0, 22)
        Me.lbl_Freeze.TabIndex = 155
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'cmd_rpt
        '
        Me.cmd_rpt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_rpt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_rpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_rpt.Location = New System.Drawing.Point(863, 382)
        Me.cmd_rpt.Name = "cmd_rpt"
        Me.cmd_rpt.Size = New System.Drawing.Size(144, 65)
        Me.cmd_rpt.TabIndex = 156
        Me.cmd_rpt.Text = "Report"
        Me.cmd_rpt.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(187, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 19)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Table Master"
        '
        'FRM_MKGA_Tablemaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmd_rpt)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbrse)
        Me.Controls.Add(Me.Cmd_view)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "FRM_MKGA_Tablemaster"
        Me.Text = "FRM_MKGA_Tablemaster"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbrse As System.Windows.Forms.Button
    Friend WithEvents Cmd_view As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents cmdTableHelp As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTableNo As System.Windows.Forms.TextBox
    Friend WithEvents TXT_POSDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CMDPOSHELP As System.Windows.Forms.Button
    Friend WithEvents Poscode As System.Windows.Forms.Label
    Friend WithEvents Txt_poscode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmd_rpt As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
