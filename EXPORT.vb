Imports System
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Public Class EXPORT
    Inherits System.Windows.Forms.Form
    Dim gconnection As New GlobalClass
    Dim myconn As SqlConnection
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim sqlstring, SSQL As String
    Dim HEADERNAME As String
    Dim i, j, SNO As Integer
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim COLNAME, DATATYPE, CON_WHERE(1) As String
    Public TABLENAME As String
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
    Friend WithEvents SELECT_GRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents EXPORT_GRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents BTNCANCEL As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EXPORT))
        Me.SELECT_GRID = New AxFPSpreadADO.AxfpSpread
        Me.EXPORT_GRID = New AxFPSpreadADO.AxfpSpread
        Me.cmdexport = New System.Windows.Forms.Button
        Me.BTNCANCEL = New System.Windows.Forms.Button
        CType(Me.SELECT_GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EXPORT_GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SELECT_GRID
        '
        Me.SELECT_GRID.DataSource = Nothing
        Me.SELECT_GRID.Location = New System.Drawing.Point(0, 0)
        Me.SELECT_GRID.Name = "SELECT_GRID"
        Me.SELECT_GRID.OcxState = CType(resources.GetObject("SELECT_GRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SELECT_GRID.Size = New System.Drawing.Size(600, 384)
        Me.SELECT_GRID.TabIndex = 14
        '
        'EXPORT_GRID
        '
        Me.EXPORT_GRID.DataSource = Nothing
        Me.EXPORT_GRID.Location = New System.Drawing.Point(64, 432)
        Me.EXPORT_GRID.Name = "EXPORT_GRID"
        Me.EXPORT_GRID.OcxState = CType(resources.GetObject("EXPORT_GRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.EXPORT_GRID.Size = New System.Drawing.Size(495, 128)
        Me.EXPORT_GRID.TabIndex = 15
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.White
        Me.cmdexport.BackgroundImage = CType(resources.GetObject("cmdexport.BackgroundImage"), System.Drawing.Image)
        Me.cmdexport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.Location = New System.Drawing.Point(160, 392)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(128, 32)
        Me.cmdexport.TabIndex = 16
        Me.cmdexport.Text = "EXPORT TO  EXCEL"
        '
        'BTNCANCEL
        '
        Me.BTNCANCEL.BackColor = System.Drawing.Color.White
        Me.BTNCANCEL.BackgroundImage = CType(resources.GetObject("BTNCANCEL.BackgroundImage"), System.Drawing.Image)
        Me.BTNCANCEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCEL.Location = New System.Drawing.Point(296, 392)
        Me.BTNCANCEL.Name = "BTNCANCEL"
        Me.BTNCANCEL.Size = New System.Drawing.Size(128, 32)
        Me.BTNCANCEL.TabIndex = 17
        Me.BTNCANCEL.Text = "CANCEL"
        '
        'EXPORT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(608, 430)
        Me.Controls.Add(Me.BTNCANCEL)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.EXPORT_GRID)
        Me.Controls.Add(Me.SELECT_GRID)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "EXPORT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "                                                          EXPORT TO EXCEL"
        CType(Me.SELECT_GRID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EXPORT_GRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Function export_excel(ByVal sqlstring As String)
        Try
            If StrComp(UCase(sqlstring), "WHERE") Then
                CON_WHERE = Split(UCase(sqlstring), "WHERE")
            End If
            myconn = New SqlConnection(gconnection.Getconnection())
            If CON_WHERE.Length > 1 Then
                SSQL = "SELECT * FROM " & TABLENAME & " WHERE " & CON_WHERE(1)
            Else
                SSQL = "SELECT * FROM " & TABLENAME
            End If
            dt = gconnection.GetValues(SSQL)

            If dt.Columns.Count > 0 Then
                With SELECT_GRID
                    .MaxCols = 4
                    .MaxRows = dt.Rows.Count + 55
                    .ClearRange(-1, -1, 1, 1, True)
                    .Col = 1
                    .Row = HEADERNAME
                    .Text = "SNO"
                    .Col = 2
                    .Row = HEADERNAME
                    .Text = "COLUMN NAME"
                    .Col = 3
                    .Row = HEADERNAME
                    .Text = "USE"
                    .Col = 4
                    .Row = HEADERNAME
                    .Text = "DATATYPE"
                    For j = 0 To dt.Columns.Count - 1
                        .Row = j + 1
                        .Col = 1
                        SNO = j + 1
                        .Text = SNO
                        .Lock = True

                        .Row = j + 1
                        .Col = 2
                        COLNAME = UCase(dt.Columns(j).ColumnName)
                        DATATYPE = UCase(dt.Columns(j).DataType.Name)
                        .Text = COLNAME
                        .Lock = True

                        .Row = j + 1
                        .Col = 4
                        SNO = j + 1
                        .Text = DATATYPE
                        .Lock = True
                    Next
                End With
            End If
        Catch ex As Exception
        End Try
    End Function
    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Try
            If SELECT_GRID.DataRowCnt > 0 Then
                sqlstring = "SELECT "
                With SELECT_GRID
                    For i = 1 To .DataRowCnt
                        .Col = 4
                        .Row = i
                        DATATYPE = Trim(.Text)
                        .Col = 3
                        .Row = i
                        If Val(.Text) = 1 Then
                            .Col = 2
                            .Row = i
                            If Len(Trim(.Text)) > 0 Then
                                If DATATYPE = "STRING" Or DATATYPE = "CHAR" Or DATATYPE = "DATETIME" Then
                                    sqlstring = sqlstring & " ISNULL(" & UCase(Trim(Trim(.Text))) & ",'') as " & UCase(Trim(Trim(.Text))) & " , "
                                Else
                                    sqlstring = sqlstring & " ISNULL(" & UCase(Trim(Trim(.Text))) & ",0) as " & UCase(Trim(Trim(.Text))) & " , "
                                End If
                            End If
                        End If
                    Next
                    If Len(sqlstring) < 8 Then
                        sqlstring = sqlstring & " * FROM " & UCase(TABLENAME)
                    Else
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & " FROM " & UCase(TABLENAME)
                    End If
                    If CON_WHERE.Length > 1 Then
                        sqlstring = sqlstring & " WHERE " & CON_WHERE(1)
                    End If
                End With
            End If
            dt = gconnection.GetValues(sqlstring)
            If dt.Columns.Count > 0 Then
                With EXPORT_GRID
                    .ClearRange(-1, -1, 1, 1, True)
                    .SetActiveCell(1, 1)
                    .MaxCols = 500
                    .MaxRows = dt.Rows.Count + 20
                    For j = 0 To dt.Columns.Count - 1
                        .Row = 1
                        .Col = j + 1
                        .Text = UCase(dt.Columns(j).ColumnName)
                        .ForeColor = Color.DarkBlue
                    Next
                    For i = 0 To dt.Rows.Count - 1
                        .SetActiveCell(1, .ActiveRow + 1)
                        For j = 0 To dt.Columns.Count - 1
                            .Row = .ActiveRow
                            .Col = j + 1

                            DATATYPE = UCase(dt.Columns(j).DataType.Name)
                            If DATATYPE = "NUMERIC" Or DATATYPE = "NUMBER" Or DATATYPE = "INT" Or DATATYPE = "DECIMAL" Then
                                .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                            ElseIf DATATYPE = "DATETIME" Then
                                .CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                            Else
                                .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                            End If


                            .Text = dt.Rows(i).Item(dt.Columns(j).ColumnName)
                        Next
                    Next
                End With
            End If
            ExportTo(EXPORT_GRID)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BTNCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCEL.Click
        Me.Close()
    End Sub
    Private Sub SELECT_GRID_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SELECT_GRID.KeyDownEvent
        Dim I As Integer
        Try
            If e.keyCode = 13 Then
                With SELECT_GRID
                    If .ActiveCol = 3 Then
                        .SetActiveCell(3, .ActiveRow + 1)
                    End If
                End With
            ElseIf e.keyCode = Keys.F2 Then
                With SELECT_GRID
                    For I = 1 To .DataRowCnt
                        .Col = 3
                        .SetText(3, I, 1)
                    Next
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub EXPORT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
