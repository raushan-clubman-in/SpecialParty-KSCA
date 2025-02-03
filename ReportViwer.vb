Imports System.Data.SqlClient
Public Class ReportViwer
    Inherits System.Windows.Forms.Form
    Dim gconnection As New GlobalClass
    Public str As String
    Dim myconn As SqlConnection
    Public sqlstring As String
    Dim chkbool As Boolean
    Dim vconn As New GlobalClass
    Public ssql, TableName As String
    Public Report As Object
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Dim ds As DataSet

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
    'Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1016, 734)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReportViwer
        '
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "ReportViwer"
        Me.Text = "Report Viewer"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ReportViwer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GetDetails(ssql, TableName, Report)
    End Sub
    Public Function GetDetails(ByVal sqlstring As String, ByVal Tabname As String, ByVal rpt As Object)
        Try
            If sqlstring <> "" Then
                myconn = New SqlConnection(gconnection.Getconnection())
                Dim adp As New SqlDataAdapter
                Dim ds As New DataSet
                adp = New SqlDataAdapter(sqlstring, myconn)
                adp.SelectCommand.CommandTimeout = 100000
                adp.Fill(ds, Tabname)
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Zoom(100)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "MEMBER", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
    Public Function GetDetails1(ByVal ssql As String, ByVal Tab As String, ByVal rpt As Object)
        Dim dt As New DataTable
        If ssql <> "" Then
            myconn = New SqlConnection(gconnection.Getconnection())
            gadapter = New SqlDataAdapter(ssql, myconn)
            gadapter.SelectCommand.CommandTimeout = 999999
            gadapter.Fill(dt)
            dt.TableName = Tab
        End If
        If gdataset.Tables.Contains(Tab) = True Then
            gdataset.Tables.Remove(Tab)

        End If
        gdataset.Tables.Add(dt)
        rpt.SetDataSource(gdataset)
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Zoom(100)
    End Function

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class
