
Public Class exportexcel
    Inherits System.Windows.Forms.Form
    Dim vconn As New GlobalClass
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

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
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(exportexcel))
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(16, 8)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(984, 432)
        Me.ssgrid.TabIndex = 0
        '
        'exportexcel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 482)
        Me.Controls.Add(Me.ssgrid)
        Me.Name = "exportexcel"
        Me.Text = "exportexcel"
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub exportexcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub export(ByVal sqlstring As String, ByVal heading As String, ByVal orderby As String)
        Dim I, J, K As Integer
        Dim datatype As String
        vconn.getDataSet(sqlstring, "GROUP")
        ssgrid.ClearRange(1, 1, -1, -1, False)
        If gdataset.Tables("GROUP").Rows.Count > 0 Then
            With ssgrid
                .Row = 1
                .Col = 1
                .Text = heading
                For K = 0 To gdataset.Tables("GROUP").Columns.Count - 1
                    .Row = 2
                    .Col = K + 1
                    .Text = gdataset.Tables("GROUP").Columns(K).ColumnName
                Next
                For I = 0 To gdataset.Tables("GROUP").Rows.Count - 1
                    .Row = I + 3
                    For J = 0 To gdataset.Tables("GROUP").Columns.Count - 1
                        .Col = J + 1
                        datatype = UCase(gdataset.Tables("GROUP").Columns(J).DataType.Name)
                        If datatype = "NUMERIC" Or datatype = "NUMBER" Or datatype = "INT" Or datatype = "DECIMAL" Then
                            .Text = gdataset.Tables("GROUP").Rows(I).Item(J)
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                        ElseIf datatype = "DATETIME" Then
                            .Text = Format(gdataset.Tables("GROUP").Rows(I).Item(J), "dd-MMM-yyyy HH:mm")
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                        Else
                            .Text = gdataset.Tables("GROUP").Rows(I).Item(J)
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                        End If
                    Next
                    .MaxRows = .MaxRows + 1
                Next
            End With
            Me.ssgrid.Visible = True
        End If
        'Me.ssgrid.Visible = False
        Call ExportTo(ssgrid)
        Me.Close()
    End Sub
End Class
