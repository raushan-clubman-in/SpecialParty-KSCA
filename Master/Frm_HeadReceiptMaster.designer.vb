<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_HeadReceiptMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_HeadReceiptMaster))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmd_ParHeadHelp = New System.Windows.Forms.Button()
        Me.Txt_ParHeadCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_ParHeaddesc = New System.Windows.Forms.TextBox()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdBrowse = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.CmdFreeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.lbl_freeze = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(260, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 15)
        Me.Label6.TabIndex = 688
        Me.Label6.Text = "Party Head Code"
        '
        'Cmd_ParHeadHelp
        '
        Me.Cmd_ParHeadHelp.BackgroundImage = CType(resources.GetObject("Cmd_ParHeadHelp.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_ParHeadHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_ParHeadHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Cmd_ParHeadHelp.Location = New System.Drawing.Point(552, 141)
        Me.Cmd_ParHeadHelp.Name = "Cmd_ParHeadHelp"
        Me.Cmd_ParHeadHelp.Size = New System.Drawing.Size(30, 22)
        Me.Cmd_ParHeadHelp.TabIndex = 690
        Me.Cmd_ParHeadHelp.UseVisualStyleBackColor = True
        '
        'Txt_ParHeadCode
        '
        Me.Txt_ParHeadCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ParHeadCode.Location = New System.Drawing.Point(408, 143)
        Me.Txt_ParHeadCode.MaxLength = 10
        Me.Txt_ParHeadCode.Name = "Txt_ParHeadCode"
        Me.Txt_ParHeadCode.Size = New System.Drawing.Size(143, 20)
        Me.Txt_ParHeadCode.TabIndex = 689
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(257, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 15)
        Me.Label1.TabIndex = 691
        Me.Label1.Text = "Party Head  Description"
        '
        'Txt_ParHeaddesc
        '
        Me.Txt_ParHeaddesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ParHeaddesc.Location = New System.Drawing.Point(408, 185)
        Me.Txt_ParHeaddesc.MaxLength = 30
        Me.Txt_ParHeaddesc.Name = "Txt_ParHeaddesc"
        Me.Txt_ParHeaddesc.Size = New System.Drawing.Size(170, 20)
        Me.Txt_ParHeaddesc.TabIndex = 692
        '
        'CmdExit
        '
        Me.CmdExit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdExit.Image = CType(resources.GetObject("CmdExit.Image"), System.Drawing.Image)
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.Location = New System.Drawing.Point(859, 423)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(144, 55)
        Me.CmdExit.TabIndex = 716
        Me.CmdExit.Text = "Exit [F11]"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdBrowse
        '
        Me.CmdBrowse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBrowse.Location = New System.Drawing.Point(859, 362)
        Me.CmdBrowse.Name = "CmdBrowse"
        Me.CmdBrowse.Size = New System.Drawing.Size(144, 55)
        Me.CmdBrowse.TabIndex = 715
        Me.CmdBrowse.Text = "Browse"
        Me.CmdBrowse.UseVisualStyleBackColor = True
        '
        'CmdView
        '
        Me.CmdView.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(859, 303)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(144, 55)
        Me.CmdView.TabIndex = 714
        Me.CmdView.Text = "View [F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = True
        '
        'CmdFreeze
        '
        Me.CmdFreeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFreeze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdFreeze.Image = CType(resources.GetObject("CmdFreeze.Image"), System.Drawing.Image)
        Me.CmdFreeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdFreeze.Location = New System.Drawing.Point(859, 244)
        Me.CmdFreeze.Name = "CmdFreeze"
        Me.CmdFreeze.Size = New System.Drawing.Size(144, 55)
        Me.CmdFreeze.TabIndex = 713
        Me.CmdFreeze.Text = "Freeze [F8]"
        Me.CmdFreeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdFreeze.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(859, 185)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(144, 55)
        Me.CmdClear.TabIndex = 712
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
        Me.CmdAdd.Location = New System.Drawing.Point(859, 127)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(144, 55)
        Me.CmdAdd.TabIndex = 711
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'lbl_freeze
        '
        Me.lbl_freeze.AutoSize = True
        Me.lbl_freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freeze.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_freeze.Location = New System.Drawing.Point(403, 362)
        Me.lbl_freeze.Name = "lbl_freeze"
        Me.lbl_freeze.Size = New System.Drawing.Size(165, 25)
        Me.lbl_freeze.TabIndex = 725
        Me.lbl_freeze.Text = "Record Freezed"
        Me.lbl_freeze.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(202, 115)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(625, 135)
        Me.GroupBox1.TabIndex = 726
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(199, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 15)
        Me.Label2.TabIndex = 727
        Me.Label2.Text = "Banquet Receipt Head"
        '
        'Frm_HeadReceiptMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1025, 750)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.CmdBrowse)
        Me.Controls.Add(Me.CmdView)
        Me.Controls.Add(Me.CmdFreeze)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_ParHeaddesc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cmd_ParHeadHelp)
        Me.Controls.Add(Me.Txt_ParHeadCode)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "Frm_HeadReceiptMaster"
        Me.Text = "Frm_HeadReceiptMaster"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmd_ParHeadHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_ParHeadCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_ParHeaddesc As System.Windows.Forms.TextBox
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdBrowse As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents CmdFreeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents lbl_freeze As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
