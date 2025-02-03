<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BillClosing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BillClosing))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Dtp_CloseDate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_POSCode = New System.Windows.Forms.Label()
        Me.Grp_Operation = New System.Windows.Forms.GroupBox()
        Me.cmd_Ok = New System.Windows.Forms.Button()
        Me.cmd_Cancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Grp_Operation.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(160, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "BILL CLOSING"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Dtp_CloseDate)
        Me.GroupBox1.Controls.Add(Me.lbl_POSCode)
        Me.GroupBox1.Location = New System.Drawing.Point(65, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(354, 78)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'Dtp_CloseDate
        '
        Me.Dtp_CloseDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_CloseDate.Location = New System.Drawing.Point(153, 14)
        Me.Dtp_CloseDate.Name = "Dtp_CloseDate"
        Me.Dtp_CloseDate.Size = New System.Drawing.Size(112, 26)
        Me.Dtp_CloseDate.TabIndex = 8
        '
        'lbl_POSCode
        '
        Me.lbl_POSCode.AutoSize = True
        Me.lbl_POSCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_POSCode.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_POSCode.ForeColor = System.Drawing.Color.Black
        Me.lbl_POSCode.Location = New System.Drawing.Point(60, 16)
        Me.lbl_POSCode.Name = "lbl_POSCode"
        Me.lbl_POSCode.Size = New System.Drawing.Size(76, 22)
        Me.lbl_POSCode.TabIndex = 7
        Me.lbl_POSCode.Text = "DATE :"
        '
        'Grp_Operation
        '
        Me.Grp_Operation.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Operation.Controls.Add(Me.cmd_Ok)
        Me.Grp_Operation.Controls.Add(Me.cmd_Cancel)
        Me.Grp_Operation.Location = New System.Drawing.Point(121, 150)
        Me.Grp_Operation.Name = "Grp_Operation"
        Me.Grp_Operation.Size = New System.Drawing.Size(264, 56)
        Me.Grp_Operation.TabIndex = 11
        Me.Grp_Operation.TabStop = False
        '
        'cmd_Ok
        '
        Me.cmd_Ok.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmd_Ok.BackgroundImage = CType(resources.GetObject("cmd_Ok.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Ok.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmd_Ok.ForeColor = System.Drawing.Color.White
        Me.cmd_Ok.Image = CType(resources.GetObject("cmd_Ok.Image"), System.Drawing.Image)
        Me.cmd_Ok.Location = New System.Drawing.Point(16, 16)
        Me.cmd_Ok.Name = "cmd_Ok"
        Me.cmd_Ok.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Ok.TabIndex = 4
        Me.cmd_Ok.Text = "Process"
        Me.cmd_Ok.UseVisualStyleBackColor = False
        '
        'cmd_Cancel
        '
        Me.cmd_Cancel.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Cancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmd_Cancel.ForeColor = System.Drawing.Color.White
        Me.cmd_Cancel.Image = CType(resources.GetObject("cmd_Cancel.Image"), System.Drawing.Image)
        Me.cmd_Cancel.Location = New System.Drawing.Point(144, 16)
        Me.cmd_Cancel.Name = "cmd_Cancel"
        Me.cmd_Cancel.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Cancel.TabIndex = 5
        Me.cmd_Cancel.Text = "Close"
        Me.cmd_Cancel.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(33, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Label2"
        '
        'Frm_BillClosing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(507, 229)
        Me.Controls.Add(Me.Grp_Operation)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "Frm_BillClosing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_BillClosing"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Grp_Operation.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_POSCode As System.Windows.Forms.Label
    Friend WithEvents Dtp_CloseDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Grp_Operation As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Ok As System.Windows.Forms.Button
    Friend WithEvents cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
