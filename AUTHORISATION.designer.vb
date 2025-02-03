<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AUTHORISATION
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
        Me.DTAUTH = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SaveExcelFileDialog = New System.Windows.Forms.OpenFileDialog()
        CType(Me.DTAUTH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DTAUTH
        '
        Me.DTAUTH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTAUTH.Location = New System.Drawing.Point(12, 12)
        Me.DTAUTH.Name = "DTAUTH"
        Me.DTAUTH.Size = New System.Drawing.Size(896, 339)
        Me.DTAUTH.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(299, 444)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(154, 38)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "EXPORT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(507, 444)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(154, 38)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "AUTHORISE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(696, 444)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(154, 38)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "EXIT"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'SaveExcelFileDialog
        '
        Me.SaveExcelFileDialog.FileName = "OpenFileDialog1"
        '
        'AUTHORISATION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 512)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DTAUTH)
        Me.Name = "AUTHORISATION"
        Me.Text = "AUTHORISATION"
        CType(Me.DTAUTH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DTAUTH As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents SaveExcelFileDialog As System.Windows.Forms.OpenFileDialog
End Class
