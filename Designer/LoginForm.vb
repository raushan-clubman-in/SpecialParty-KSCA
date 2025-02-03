Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient
Public Class LoginForm
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Turnoff As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_Username As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Password As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Login As System.Windows.Forms.Button
    Friend WithEvents Cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents CHK_CHANGEPWD As System.Windows.Forms.CheckBox
    Friend WithEvents TXT_NEWPASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmd_Turnoff = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_Username = New System.Windows.Forms.TextBox()
        Me.Txt_Password = New System.Windows.Forms.TextBox()
        Me.Cmd_Login = New System.Windows.Forms.Button()
        Me.Cmd_Cancel = New System.Windows.Forms.Button()
        Me.CHK_CHANGEPWD = New System.Windows.Forms.CheckBox()
        Me.TXT_NEWPASSWORD = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(52, 640)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 604
        Me.Label1.Text = "Turn off Application"
        '
        'Cmd_Turnoff
        '
        Me.Cmd_Turnoff.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Turnoff.Image = CType(resources.GetObject("Cmd_Turnoff.Image"), System.Drawing.Image)
        Me.Cmd_Turnoff.Location = New System.Drawing.Point(12, 632)
        Me.Cmd_Turnoff.Name = "Cmd_Turnoff"
        Me.Cmd_Turnoff.Size = New System.Drawing.Size(24, 24)
        Me.Cmd_Turnoff.TabIndex = 602
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(378, 457)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 16)
        Me.Label6.TabIndex = 611
        Me.Label6.Text = "NEW PASSWORD :"
        '
        'Txt_Username
        '
        Me.Txt_Username.BackColor = System.Drawing.Color.Silver
        Me.Txt_Username.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Username.ForeColor = System.Drawing.Color.Black
        Me.Txt_Username.Location = New System.Drawing.Point(453, 284)
        Me.Txt_Username.MaxLength = 15
        Me.Txt_Username.Name = "Txt_Username"
        Me.Txt_Username.Size = New System.Drawing.Size(134, 22)
        Me.Txt_Username.TabIndex = 603
        '
        'Txt_Password
        '
        Me.Txt_Password.BackColor = System.Drawing.Color.Silver
        Me.Txt_Password.Font = New System.Drawing.Font("Wingdings", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Txt_Password.ForeColor = System.Drawing.Color.Black
        Me.Txt_Password.Location = New System.Drawing.Point(453, 332)
        Me.Txt_Password.MaxLength = 20
        Me.Txt_Password.Name = "Txt_Password"
        Me.Txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(50)
        Me.Txt_Password.Size = New System.Drawing.Size(134, 22)
        Me.Txt_Password.TabIndex = 605
        '
        'Cmd_Login
        '
        Me.Cmd_Login.BackColor = System.Drawing.Color.White
        Me.Cmd_Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Login.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Login.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Login.Location = New System.Drawing.Point(437, 364)
        Me.Cmd_Login.Name = "Cmd_Login"
        Me.Cmd_Login.Size = New System.Drawing.Size(83, 24)
        Me.Cmd_Login.TabIndex = 606
        Me.Cmd_Login.Text = "  LOGIN"
        Me.Cmd_Login.UseVisualStyleBackColor = False
        '
        'Cmd_Cancel
        '
        Me.Cmd_Cancel.BackColor = System.Drawing.Color.White
        Me.Cmd_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Cancel.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Cancel.Image = CType(resources.GetObject("Cmd_Cancel.Image"), System.Drawing.Image)
        Me.Cmd_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Cancel.Location = New System.Drawing.Point(533, 364)
        Me.Cmd_Cancel.Name = "Cmd_Cancel"
        Me.Cmd_Cancel.Size = New System.Drawing.Size(89, 24)
        Me.Cmd_Cancel.TabIndex = 607
        Me.Cmd_Cancel.Text = "  CANCEL"
        Me.Cmd_Cancel.UseVisualStyleBackColor = False
        '
        'CHK_CHANGEPWD
        '
        Me.CHK_CHANGEPWD.BackColor = System.Drawing.Color.Transparent
        Me.CHK_CHANGEPWD.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CHK_CHANGEPWD.Location = New System.Drawing.Point(477, 404)
        Me.CHK_CHANGEPWD.Name = "CHK_CHANGEPWD"
        Me.CHK_CHANGEPWD.Size = New System.Drawing.Size(120, 16)
        Me.CHK_CHANGEPWD.TabIndex = 612
        Me.CHK_CHANGEPWD.Text = "Change Password"
        Me.CHK_CHANGEPWD.UseVisualStyleBackColor = False
        '
        'TXT_NEWPASSWORD
        '
        Me.TXT_NEWPASSWORD.BackColor = System.Drawing.Color.LightGray
        Me.TXT_NEWPASSWORD.Font = New System.Drawing.Font("Wingdings", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.TXT_NEWPASSWORD.ForeColor = System.Drawing.Color.LightGray
        Me.TXT_NEWPASSWORD.Location = New System.Drawing.Point(533, 455)
        Me.TXT_NEWPASSWORD.MaxLength = 20
        Me.TXT_NEWPASSWORD.Name = "TXT_NEWPASSWORD"
        Me.TXT_NEWPASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(50)
        Me.TXT_NEWPASSWORD.Size = New System.Drawing.Size(134, 22)
        Me.TXT_NEWPASSWORD.TabIndex = 610
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"), System.Drawing.Icon)
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 659)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(432, 16)
        Me.Label7.TabIndex = 609
        Me.Label7.Text = "Copyrights Reserved 2004-2011  by CHS Solution Pvt Ltd."
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(477, 308)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 608
        Me.Label5.Text = "Invalid User"
        Me.Label5.Visible = False
        '
        'LoginForm
        '
        Me.AllowDrop = True
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1028, 704)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmd_Turnoff)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Txt_Username)
        Me.Controls.Add(Me.Txt_Password)
        Me.Controls.Add(Me.Cmd_Login)
        Me.Controls.Add(Me.Cmd_Cancel)
        Me.Controls.Add(Me.CHK_CHANGEPWD)
        Me.Controls.Add(Me.TXT_NEWPASSWORD)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.ForeColor = System.Drawing.Color.Coral
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "LoginForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LoginForm"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Public Sub GetServer1()
        Dim ServerConn As New OleDb.OleDbConnection
        Dim servercmd As New OleDb.OleDbDataAdapter
        Dim getserver As New DataSet
        Dim sql, ssql As String
        Try
            sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
            sql = sql & AppPath & "\DBS_KEY.MDB"
            ServerConn.ConnectionString = sql
            ServerConn.Open()
            ssql = "SELECT SERVER, UserName, Password, Company_ID,Database,COMPORT,Port FROM DBSKEY"
            servercmd = New OleDb.OleDbDataAdapter(ssql, ServerConn)
            servercmd.Fill(getserver)
            If getserver.Tables(0).Rows.Count > 0 Then
                gserver = Trim(getserver.Tables(0).Rows(0).Item(0) & "")
                strDataSqlUsr = Trim(getserver.Tables(0).Rows(0).Item(1) & "")
                strDataSqlPwd = (Trim(getserver.Tables(0).Rows(0).Item(2) & ""))
                gDatabase = Trim(getserver.Tables(0).Rows(0).Item(4) & "")
                COMPORT_SC = Val(getserver.Tables(0).Rows(0).Item(5))
                GSplashPath = Val(getserver.Tables(0).Rows(0).Item(6))
                gport = Val(getserver.Tables(0).Rows(0).Item("Port"))
            Else
                gserver = Environment.MachineName
                gport = "PRN"
            End If
        Catch ex As Exception
            MessageBox.Show("Failed To Connect Server", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            ServerConn.Close()
        End Try
    End Sub
    Public Sub GetServer()
        Dim ServerConn As New OleDb.OleDbConnection
        Dim servercmd As New OleDb.OleDbDataAdapter
        Dim getserver As New DataSet
        Dim sql, ssql As String
        sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
        sql = sql & AppPath & "\DBS_KEY.MDB"
        ServerConn.ConnectionString = sql
        Try
            ServerConn.Open()
            'Mk Kannan
            'Begin
            'UserName and Password is Added on 06 Oct'07
            ssql = "SELECT SERVER, UserName, Password, Company_ID,Database,COMPORT,port,splashpath,readertype FROM DBSKEY"
            'End
            servercmd = New OleDb.OleDbDataAdapter(ssql, ServerConn)
            servercmd.Fill(getserver)
            If getserver.Tables(0).Rows.Count > 0 Then
                gserver = Trim(getserver.Tables(0).Rows(0).Item(0) & "")
                'Mk Kannan
                'Begin
                'UserName and Password is Added on 06 Oct'07
                strDataSqlUsr = Trim(getserver.Tables(0).Rows(0).Item(1) & "")
                strDataSqlPwd = Trim(getserver.Tables(0).Rows(0).Item(2) & "")
                'End
                'Mk Kannan
                'Begin
                'Company ID is Added on 10 Dec'07
                strCompany_ID = Trim(getserver.Tables(0).Rows(0).Item(3) & "")

                'End
                gDatabase = Trim(getserver.Tables(0).Rows(0).Item(4) & "")
                'COMPORT_SC = Val(getserver.Tables(0).Rows(0).Item(5))
                gport = Trim(getserver.Tables(0).Rows(0).Item("port") & "")
                'GSplashPath = Trim(getserver.Tables(0).Rows(0).Item(6) & "")
                greadertype = Trim(getserver.Tables(0).Rows(0).Item("readertype") & "")
            Else
                MessageBox.Show("Failed to connect to Data Source")
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to connect to data source")
            MsgBox(ex.Message)
        Finally
            ServerConn.Close()
        End Try
    End Sub
    Public Sub GetEXCELPATH()
        Dim ExcelConn As New OleDb.OleDbConnection
        Dim Excelcmd As New OleDb.OleDbDataAdapter
        Dim getexcel As New DataSet
        Dim sql, ssql As String
        Try
            sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
            sql = sql & AppPath & "\DBS_KEY.MDB"
            ExcelConn.ConnectionString = sql
            ExcelConn.Open()
            ssql = "SELECT PATH FROM EXCELPATH"
            Excelcmd = New OleDb.OleDbDataAdapter(ssql, ExcelConn)
            Excelcmd.Fill(getexcel)
            If getexcel.Tables(0).Rows.Count > 0 Then
                strexcelpath = Trim(getexcel.Tables(0).Rows(0).Item(0) & "")
            Else
                strexcelpath = Environment.SystemDirectory & "\Excel.exe"
            End If
        Catch ex As Exception
            MessageBox.Show("Failed To Find Microsoft Excel Path", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            ExcelConn.Close()
        End Try
    End Sub
    Public Sub GetPrinter()
        Dim PrinterConn As New OleDb.OleDbConnection
        Dim Printercmd As New OleDb.OleDbDataAdapter
        Dim GetPrinter As New DataSet
        Dim sql, ssql As String
        Dim i As Integer
        Try
            sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
            sql = sql & AppPath & "\DBS_KEY.MDB"
            PrinterConn.ConnectionString = sql
            PrinterConn.Open()
            ssql = " SELECT COMPUTERNAME, PRINTERNAME, KOTOPTION FROM PrinterSetup "
            Printercmd = New OleDb.OleDbDataAdapter(ssql, PrinterConn)
            Printercmd.Fill(GetPrinter)
            If GetPrinter.Tables(0).Rows.Count > 0 Then
                For i = 0 To GetPrinter.Tables(0).Rows.Count - 1
                    If Trim(GetPrinter.Tables(0).Rows(i).Item(2)) = "Y" Then
                        Kot_Computername = Trim(GetPrinter.Tables(0).Rows(i).Item(0) & "")
                        Kot_Printername = Trim(GetPrinter.Tables(0).Rows(i).Item(1) & "")
                    Else
                        computername = Trim(GetPrinter.Tables(0).Rows(i).Item(0) & "")
                        Printername = Trim(GetPrinter.Tables(0).Rows(i).Item(1) & "")
                    End If
                Next
            Else
                computername = ""
                Printername = ""
            End If
        Catch ex As Exception
            'MessageBox.Show("Failed To Connect To Computer Printer", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MessageBox.Show("Failed To Connect To Computer Printer" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Finally
            PrinterConn.Close()
        End Try
    End Sub
    Public Sub GetPHOTOPATH()
        Dim PHOTOConn As New OleDb.OleDbConnection
        Dim PHOTOcmd As New OleDb.OleDbDataAdapter
        Dim getPHOTO As New DataSet
        Dim sql, ssql As String
        Try
            sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
            sql = sql & AppPath & "\DBS_KEY.MDB"
            PHOTOConn.ConnectionString = sql
            PHOTOConn.Open()
            ssql = "SELECT PATH FROM SCPHOTOPATH"
            PHOTOcmd = New OleDb.OleDbDataAdapter(ssql, PHOTOConn)
            PHOTOcmd.Fill(getPHOTO)
            If getPHOTO.Tables(0).Rows.Count > 0 Then
                STRPHOTOPATH = Trim(getPHOTO.Tables(0).Rows(0).Item(0) & "")
            Else
                MessageBox.Show("PLS PROVIDE PHOTO PATH IN DBS KEY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("PLS PROVIDE PHOTO PATH IN DBS KEY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            PHOTOConn.Close()
        End Try
    End Sub

    Private Sub Cbo_Usertype_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Txt_Username.Focus()
        End If
    End Sub
    Private Sub CHK_CHANGEPWD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CHK_CHANGEPWD.Checked = True Then
            Label6.Visible = True
            TXT_NEWPASSWORD.Visible = True
            TXT_NEWPASSWORD.Focus()
        Else
            Label6.Visible = False
            TXT_NEWPASSWORD.Visible = False
            Txt_Password.Focus()
        End If
    End Sub
    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FileInfo(Application.StartupPath & "\GolfManagement.Exe")
        AppPath = Application.StartupPath
        If Dir(AppPath & "\Reports", FileAttribute.Directory) = "" Then
            MkDir(AppPath & "\Reports")
        End If
        Call GetPrinter()
        Call GetServer()
        Call GetEXCELPATH()
        Call GetPHOTOPATH()
        Me.Txt_Username.Focus()
        Me.ForeColor = Color.Transparent()
        'me.BackgroundImage=

    End Sub
    Private Sub Cmd_Login_Click(sender As Object, e As EventArgs) Handles Cmd_Login.Click
        Dim SQLSTRING As String
        If (Trim(Txt_Username.Text) = "") Then
            ErrorProvider1.SetError(Txt_Username, "Please enter User name")
        Else
            ErrorProvider1.SetError(Txt_Username, "")
        End If
        If (Trim(Txt_Password.Text) = "") Then
            ErrorProvider1.SetError(Txt_Password, "Please enter Password")
        Else
            ErrorProvider1.SetError(Txt_Password, "")
        End If
        Try

            '            SQLSTRING = "SELECT * FROM USERADMIN WHERE  USERNAME = '" & Trim(UCase(Txt_Username.Text)) & "' and USERPASSWORD ='" & Trim(GetPassword(UCase(Txt_Password.Text))) & "' AND MAINGROUP = 'POS' AND CATEGORY <> 'S' "
            SQLSTRING = "SELECT * FROM USERADMIN WHERE  USERNAME = '" & Trim(UCase(Txt_Username.Text)) & "' and USERPASSWORD ='" & Trim(GetPassword(UCase(Txt_Password.Text))) & "'"
            gconnection.getCompanyinfo(SQLSTRING, "ClubMaster")

            If gdataset.Tables("ClubMaster").Rows.Count > 0 Then
                gUsername = Trim(Txt_Username.Text)
                gPoSUsername = Trim(Mid(Trim(Txt_Username.Text), 1, 5))
                gUserCategory = gdataset.Tables("ClubMaster").Rows(0).Item("CATEGORY")

                'new one
                If CHK_CHANGEPWD.Checked = True And Trim(TXT_NEWPASSWORD.Text) <> "" Then
                    Dim vstr As String
                    vstr = abcdADD(UCase(Trim(TXT_NEWPASSWORD.Text)))

                    SQLSTRING = "UPDATE MASTER..USERADMIN SET USERPASSWORD='" & Trim(vstr) & "' WHERE USERNAME='" & Trim(Txt_Username.Text) & "'"
                    gconnection.getCompanyinfo(SQLSTRING, "USERUPDATE")

                    SQLSTRING = "UPDATE " & Trim(gDatabase) & "..USERADMIN SET USERPASSWORD='" & Trim(vstr) & "' WHERE USERNAME='" & Trim(Txt_Username.Text) & "'"
                    gconnection.getCompanyinfo(SQLSTRING, "USERUPDATE1")
                End If
                If gUserCategory = "U" Then
                    Me.Hide()
                    Dim Objwelcome As New Welcome
                    Objwelcome.Show()
                ElseIf gUserCategory = "O" Then 'for Operator User Type Only
                    'Dim Objwelcome As New Operator_MainMenu
                    'Me.Hide()
                    'Objwelcome.Show()
                Else
                    Me.Hide()
                    Dim Objwelcome As New Welcome
                    Objwelcome.Show()
                End If
            Else
                SQLSTRING = "SELECT * FROM USERADMIN WHERE  USERNAME = '" & Trim(UCase(Txt_Username.Text)) & "' and USERPASSWORD ='" & Trim(GetPassword(UCase(Txt_Password.Text))) & "' AND  CATEGORY = 'S' "
                gconnection.getCompanyinfo(SQLSTRING, "ClubMaster")
                If gdataset.Tables("ClubMaster").Rows.Count > 0 Then
                    'gUsername = Trim(Txt_Username.Text)
                    'gPoSUsername = Trim(Mid(Trim(Txt_Username.Text), 1, 5))
                    'gUserCategory = gdataset.Tables("ClubMaster").Rows(0).Item("CATEGORY")
                    'Dim Objwelcome As New Welcome
                    'Me.Hide()
                    'Objwelcome.Show()
                Else
                    MessageBox.Show("Invalid Username Or Password !!! Contact System Admin", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Label5.Visible = True
                    Me.Txt_Password.Text = ""
                    Me.Txt_Password.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Create Table UserAdmin In Master database", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_Turnoff_Click(sender As Object, e As EventArgs) Handles Cmd_Turnoff.Click
        Me.Close()
    End Sub
    Private Sub Cmd_Cancel_Click(sender As Object, e As EventArgs) Handles Cmd_Cancel.Click
        Txt_Username.Text = ""
        Txt_Password.Text = ""
        Label5.Visible = False
        ErrorProvider1.Dispose()
        Txt_Username.Focus()
    End Sub

    Private Sub Txt_Username_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Username.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt_Password.Focus()
        End If
    End Sub

    Private Sub Txt_Password_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Password.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Trim(Txt_Password.Text) = "" Then
                Txt_Password.Focus()
            Else
                Cmd_Login.Focus()
            End If
        End If
    End Sub
End Class
