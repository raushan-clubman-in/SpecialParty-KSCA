<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportDesigner
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
        Me.BUT_EXIT = New System.Windows.Forms.Button()
        Me.BUT_GV_PRINT = New System.Windows.Forms.Button()
        Me.BUT_GEN_VIEW = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BUT_EXIT
        '
        Me.BUT_EXIT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BUT_EXIT.ForeColor = System.Drawing.Color.Red
        Me.BUT_EXIT.Location = New System.Drawing.Point(425, 335)
        Me.BUT_EXIT.Name = "BUT_EXIT"
        Me.BUT_EXIT.Size = New System.Drawing.Size(131, 37)
        Me.BUT_EXIT.TabIndex = 18
        Me.BUT_EXIT.Text = "Exit"
        Me.BUT_EXIT.UseVisualStyleBackColor = True
        '
        'BUT_GV_PRINT
        '
        Me.BUT_GV_PRINT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BUT_GV_PRINT.ForeColor = System.Drawing.Color.Red
        Me.BUT_GV_PRINT.Location = New System.Drawing.Point(286, 335)
        Me.BUT_GV_PRINT.Name = "BUT_GV_PRINT"
        Me.BUT_GV_PRINT.Size = New System.Drawing.Size(131, 37)
        Me.BUT_GV_PRINT.TabIndex = 17
        Me.BUT_GV_PRINT.Text = "Give Print"
        Me.BUT_GV_PRINT.UseVisualStyleBackColor = True
        '
        'BUT_GEN_VIEW
        '
        Me.BUT_GEN_VIEW.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BUT_GEN_VIEW.ForeColor = System.Drawing.Color.Red
        Me.BUT_GEN_VIEW.Location = New System.Drawing.Point(147, 335)
        Me.BUT_GEN_VIEW.Name = "BUT_GEN_VIEW"
        Me.BUT_GEN_VIEW.Size = New System.Drawing.Size(131, 37)
        Me.BUT_GEN_VIEW.TabIndex = 16
        Me.BUT_GEN_VIEW.Text = "Generate View"
        Me.BUT_GEN_VIEW.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(685, 329)
        Me.DataGridView1.TabIndex = 19
        '
        'ReportDesigner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(686, 392)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BUT_EXIT)
        Me.Controls.Add(Me.BUT_GV_PRINT)
        Me.Controls.Add(Me.BUT_GEN_VIEW)
        Me.KeyPreview = True
        Me.Name = "ReportDesigner"
        Me.Text = "ReportDesigner"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BUT_GEN_VIEW As System.Windows.Forms.Button
    Friend WithEvents BUT_GV_PRINT As System.Windows.Forms.Button
    Friend WithEvents BUT_EXIT As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
