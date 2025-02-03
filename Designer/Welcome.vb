Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class Welcome
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lbl_Companyname As System.Windows.Forms.Label
    Friend WithEvents lbl_CompanyAddress1 As System.Windows.Forms.Label
    Friend WithEvents lbl_CompanyAddress2 As System.Windows.Forms.Label
    Friend WithEvents lbl_State As System.Windows.Forms.Label
    Friend WithEvents lbl_Username As System.Windows.Forms.Label
    Friend WithEvents lbl_Loding As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Welcome))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_Username = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_Loding = New System.Windows.Forms.Label()
        Me.lbl_Companyname = New System.Windows.Forms.Label()
        Me.lbl_CompanyAddress1 = New System.Windows.Forms.Label()
        Me.lbl_CompanyAddress2 = New System.Windows.Forms.Label()
        Me.lbl_State = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(72, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(251, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Special Party"
        '
        'lbl_Username
        '
        Me.lbl_Username.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Username.ForeColor = System.Drawing.Color.White
        Me.lbl_Username.Location = New System.Drawing.Point(600, 328)
        Me.lbl_Username.Name = "lbl_Username"
        Me.lbl_Username.Size = New System.Drawing.Size(264, 32)
        Me.lbl_Username.TabIndex = 2
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Timer2
        '
        '
        'lbl_Loding
        '
        Me.lbl_Loding.AutoSize = True
        Me.lbl_Loding.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Loding.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Loding.ForeColor = System.Drawing.Color.Red
        Me.lbl_Loding.Location = New System.Drawing.Point(556, 328)
        Me.lbl_Loding.Name = "lbl_Loding"
        Me.lbl_Loding.Size = New System.Drawing.Size(203, 13)
        Me.lbl_Loding.TabIndex = 5
        Me.lbl_Loding.Text = "Loading Your Personal  Rights ....."
        Me.lbl_Loding.Visible = False
        '
        'lbl_Companyname
        '
        Me.lbl_Companyname.AutoSize = True
        Me.lbl_Companyname.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Companyname.Font = New System.Drawing.Font("Century", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Companyname.ForeColor = System.Drawing.Color.Black
        Me.lbl_Companyname.Location = New System.Drawing.Point(144, 288)
        Me.lbl_Companyname.Name = "lbl_Companyname"
        Me.lbl_Companyname.Size = New System.Drawing.Size(66, 16)
        Me.lbl_Companyname.TabIndex = 6
        Me.lbl_Companyname.Text = "LABLE1"
        '
        'lbl_CompanyAddress1
        '
        Me.lbl_CompanyAddress1.AutoSize = True
        Me.lbl_CompanyAddress1.BackColor = System.Drawing.Color.Transparent
        Me.lbl_CompanyAddress1.Font = New System.Drawing.Font("Century", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyAddress1.ForeColor = System.Drawing.Color.Black
        Me.lbl_CompanyAddress1.Location = New System.Drawing.Point(144, 312)
        Me.lbl_CompanyAddress1.Name = "lbl_CompanyAddress1"
        Me.lbl_CompanyAddress1.Size = New System.Drawing.Size(66, 16)
        Me.lbl_CompanyAddress1.TabIndex = 7
        Me.lbl_CompanyAddress1.Text = "LABLE2"
        '
        'lbl_CompanyAddress2
        '
        Me.lbl_CompanyAddress2.AutoSize = True
        Me.lbl_CompanyAddress2.BackColor = System.Drawing.Color.Transparent
        Me.lbl_CompanyAddress2.Font = New System.Drawing.Font("Century", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyAddress2.ForeColor = System.Drawing.Color.Black
        Me.lbl_CompanyAddress2.Location = New System.Drawing.Point(144, 336)
        Me.lbl_CompanyAddress2.Name = "lbl_CompanyAddress2"
        Me.lbl_CompanyAddress2.Size = New System.Drawing.Size(66, 16)
        Me.lbl_CompanyAddress2.TabIndex = 8
        Me.lbl_CompanyAddress2.Text = "LABLE3"
        '
        'lbl_State
        '
        Me.lbl_State.AutoSize = True
        Me.lbl_State.BackColor = System.Drawing.Color.Transparent
        Me.lbl_State.Font = New System.Drawing.Font("Century", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_State.ForeColor = System.Drawing.Color.Black
        Me.lbl_State.Location = New System.Drawing.Point(144, 360)
        Me.lbl_State.Name = "lbl_State"
        Me.lbl_State.Size = New System.Drawing.Size(66, 16)
        Me.lbl_State.TabIndex = 9
        Me.lbl_State.Text = "LABLE4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(144, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "COMPANY DETAILS :"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(89, 256)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(49, 49)
        Me.PictureBox3.TabIndex = 12
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(502, 288)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Welcome
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1030, 755)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_Loding)
        Me.Controls.Add(Me.lbl_State)
        Me.Controls.Add(Me.lbl_CompanyAddress2)
        Me.Controls.Add(Me.lbl_CompanyAddress1)
        Me.Controls.Add(Me.lbl_Companyname)
        Me.Controls.Add(Me.lbl_Username)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Welcome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Welcome"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim gconnection As New GlobalClass
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        'Dim rectGrBrush As New LinearGradientBrush( _
        '       New Point(0, 0), _
        '       New Point(15, 0), _
        '       Color.FromArgb(255, 1, 61, 150), _
        '       Color.FromArgb(255, 1, 61, 150))
        'Dim lineGrBrush As New LinearGradientBrush( _
        '       New Point(0, 0), _
        '       New Point(15, 0), _
        '       Color.FromArgb(255, 255, 255, 255), _
        '       Color.FromArgb(255, 255, 255, 255))
        'Dim welcomeGrBrush As New LinearGradientBrush( _
        '       New Point(0, 0), _
        '       New Point(510, 0), _
        '       Color.FromArgb(255, 99, 158, 255), _
        '       Color.FromArgb(1, 15, 92, 244))
        'Dim rectpen As New Pen(rectGrBrush)
        'e.Graphics.FillRectangle(rectGrBrush, 0, 0, 1100, 80)
        'Dim linepen As New Pen(lineGrBrush)
        'e.Graphics.FillRectangle(lineGrBrush, 0, 80, 1100, 2)


        'Dim pBrush As New LinearGradientBrush( _
        '       New Point(0, 0), _
        '       New Point(1100, 0), _
        '       Color.FromArgb(200, 99, 158, 248), _
        '       Color.FromArgb(255, 15, 92, 244))


        'Dim path As New GraphicsPath
        'e.Graphics.FillRectangle(pBrush, New Rectangle(0, 82, 1100, 600))
        'Dim linepen1 As New Pen(lineGrBrush)
        'e.Graphics.FillRectangle(lineGrBrush, 0, 680, 1100, 2)
        'e.Graphics.FillRectangle(rectGrBrush, 0, 682, 1100, 90)
        'e.Graphics.FillRectangle(lineGrBrush, 500, 100, 1, 550)
    End Sub

    'Private Sub Welcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Dim login As New LoginForm
    '    Call FillCompanyinfo()
    '    lbl_Username.Text = gUsername
    '    Me.lbl_Loding.Visible = False
    'End Sub
    'Public Sub FillCompanyinfo()
    '    Dim sqlstring As String
    '    Try
    '        ' ObjCompanyList.Show()
    '        sqlstring = " SELECT ISNULL(CompanyName,'') AS CompanyName,ISNULL(Fromdate,getdate()) AS Fromdate,ISNULL(Todate,getdate()) AS Todate,ISNULL(Add1,'') AS Add1,ISNULL(Add2,'') AS Add2,"
    '        sqlstring = sqlstring & " ISNULL(City,'') AS City,ISNULL(State,'') AS State,ISNULL(Pincode,'') AS Pincode,ISNULL(Datafile,'') AS Datafile FROM ClubMaster "
    '        gconnection.getCompanyinfo(sqlstring, "ClubMaster")
    '        If gdataset.Tables("ClubMaster").Rows.Count > 0 Then
    '            MyCompanyName = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("CompanyName")))
    '            Me.lbl_Companyname.Text = MyCompanyName
    '            Address1 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add1")))
    '            Me.lbl_CompanyAddress1.Text = Address1
    '            Address2 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add2")))
    '            Me.lbl_CompanyAddress2.Text = Address2
    '            gCity = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("City")))
    '            gState = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("State")))
    '            Me.lbl_State.Text = "STATE :" & gState
    '            gPincode = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Pincode")))
    '            gDatabase = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Datafile")))
    '            Me.Text = MyCompanyName & " [" & "POS" & " ]"
    '        Else
    '            MessageBox.Show("Plz. Contact to your System Administrator ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '        Exit Sub
    '    End Try
    'End Sub
    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Dim ObjCompanyList As New CompanyList1
    '    'If PictureBox1.Top < 367 Then
    '    '    PictureBox1.Top = PictureBox1.Top + 5
    '    '    lbl_Username.Top = lbl_Username.Top + 5
    '    '    Panel1.Top = Panel1.Top + 5
    '    'Else
    '        Timer1.Enabled = False
    '    'Timer2.Enabled = True
    '    Me.lbl_Loding.Visible = True
    '    ObjCompanyList.Show()
    '    Me.Close()
    '    'End If
    'End Sub

    ''Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
    ''    Dim ObjCompanyList As New CompanyList1
    ''    Me.Hide()
    ''    ObjCompanyList.Show()
    ''    Timer2.Enabled = False
    ''    Me.lbl_Loding.Visible = False
    ''End Sub

    Private Sub Welcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim login As New LoginForm
        Call FillCompanyinfo()
        lbl_Username.Text = gUsername
        Me.lbl_Loding.Visible = False
    End Sub
    Public Sub FillCompanyinfo()
        Dim sqlstring As String
        Try
            If Trim(gDatabase) = "" Then
                sqlstring = " SELECT ISNULL(CompanyName,'') AS CompanyName,ISNULL(Fromdate,getdate()) AS Fromdate,ISNULL(Todate,getdate()) AS Todate,ISNULL(Add1,'') AS Add1,ISNULL(Add2,'') AS Add2,"
                sqlstring = sqlstring & " ISNULL(City,'') AS City,ISNULL(State,'') AS State,ISNULL(Pincode,'') AS Pincode,ISNULL(Datafile,'') AS Datafile FROM ClubMaster where companyname not like '%PAY%'"
            Else
                sqlstring = " SELECT ISNULL(CompanyName,'') AS CompanyName,ISNULL(Fromdate,getdate()) AS Fromdate,ISNULL(Todate,getdate()) AS Todate,ISNULL(Add1,'') AS Add1,ISNULL(Add2,'') AS Add2,"
                sqlstring = sqlstring & " ISNULL(City,'') AS City,ISNULL(State,'') AS State,ISNULL(Pincode,'') AS Pincode,ISNULL(Datafile,'') AS Datafile FROM ClubMaster WHERE DATAFILE='" & Trim(gDatabase) & "' AND companyname not like '%PAY%'"
            End If
            gconnection.getCompanyinfo(sqlstring, "ClubMaster")
            If gdataset.Tables("ClubMaster").Rows.Count > 1 Then
                MyCompanyName = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("CompanyName")))
                Me.lbl_Companyname.Text = MyCompanyName
                Address1 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add1")))
                Me.lbl_CompanyAddress1.Text = Address1
                Address2 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add2")))
                Me.lbl_CompanyAddress2.Text = Address2
                gCity = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("City")))
                gState = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("State")))
                Me.lbl_State.Text = "STATE :" & gState
                gPincode = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Pincode")))
                Me.Text = MyCompanyName & " [ STANDARD COSTING ]"
                gCompanyname = MyCompanyName

                strFinancialYearStart = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("FROMDATE")), "dd/MMM/yyyy")
                strFinancialYearEnd = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("TODATE")), "dd/MMM/yyyy")

                gFinancialyearStart = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("FROMDATE")), "dd/MMM/yyyy")
                gFinancalyearStart = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("FROMDATE")), "dd/MMM/yyyy")
                gFinancialyearEnding = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("TODATE")), "dd/MMM/yyyy")

                gFinancalyearStart = Year(gFinancialyearStart)
                gFinancialYearEnd = Year(gFinancialyearEnding)
                gFinancialYearEnd = Year(gFinancialyearEnding)

                gPincode = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Pincode")))
                '                gFinancialyearStarting = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("FROMDATE")), "dd/MM/yyyy")
                '               gFinancialyearStarting = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("TODATE")), "dd/MM/yyyy")
                '              gFinancialyearEnding = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("TODATE")), "dd/MM/yyyy")
                gCompanyAddress(0) = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add1")))
                gCompanyAddress(1) = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add2")))
                gCompanyAddress(2) = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("State")))
                gCompanyAddress(3) = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Pincode")))

            ElseIf gdataset.Tables("ClubMaster").Rows.Count = 1 Then
                MyCompanyName = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("CompanyName")))
                Me.lbl_Companyname.Text = MyCompanyName
                Address1 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add1")))
                Me.lbl_CompanyAddress1.Text = Address1
                Address2 = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add2")))
                Me.lbl_CompanyAddress2.Text = Address2
                gCity = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("City")))
                gState = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("State")))
                Me.lbl_State.Text = "STATE :" & gState
                gPincode = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Pincode")))
                Me.Text = MyCompanyName & " [STANDARD COSTING]"
                gCompanyname = MyCompanyName
                gPincode = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Pincode")))
                '                gFinancialyearStarting = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("FROMDATE")), "dd/MM/yyyy")
                '               gFinancialyearStarting = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("TODATE")), "dd/MM/yyyy")
                '              gFinancialyearEnding = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("TODATE")), "dd/MM/yyyy")
                gCompanyAddress(0) = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add1")))
                gCompanyAddress(1) = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Add2")))
                gCompanyAddress(2) = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("State")))
                gCompanyAddress(3) = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Pincode")))
                gDatabase = Trim(CStr(gdataset.Tables("ClubMaster").Rows(0).Item("Datafile")))

                strFinancialYearStart = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("FROMDATE")), "dd/MM/yyyy")
                strFinancialYearEnd = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("TODATE")), "dd/MM/yyyy")

                gFinancialyearStart = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("FROMDATE")), "dd/MM/yyyy")
                gFinancalyearStart = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("FROMDATE")), "dd/MM/yyyy")
                gFinancialyearEnding = Format(CDate(gdataset.Tables("ClubMaster").Rows(0).Item("TODATE")), "dd/MM/yyyy")

                gFinancalyearStart = Year(gFinancialyearStart)
                gFinancialYearEnd = Year(gFinancialyearEnding)
                gFinancialYearEnd = Year(gFinancialyearEnding)

            Else
                MessageBox.Show("Plz. Contact to your System Administrator ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If PictureBox1.Top < 367 Then
            PictureBox1.Top = PictureBox1.Top + 5
            lbl_Username.Top = lbl_Username.Top + 5
            'Panel1.Top = Panel1.Top + 5
        Else
            Timer1.Enabled = False
            Timer2.Enabled = True
            Me.lbl_Loding.Visible = True
        End If
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If gDatabase = "" Then
            'Dim ObjCompanyList As New CompanyList1
            'Me.Hide()
            'ObjCompanyList.Show()
            'Timer2.Enabled = False
            'Me.lbl_Loding.Visible = False
        Else
            Me.Hide()
            Timer2.Enabled = False
            Me.lbl_Loding.Visible = False
            Dim mdiacc As New MDIFORM
            mdiacc.Show()
        End If
    End Sub

End Class
