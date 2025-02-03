Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Public Class HALLAVAILABLITY
    Inherits System.Windows.Forms.Form
    Dim sqlstring, SSQL2 As String
    Dim chkbool As Boolean
    Dim vconn As New GlobalClass
    Dim pagesize, pageno As Integer
    Dim dr As DataRow
    Dim gconnection As New GlobalClass
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        vconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdView.Enabled = False
        Me.CmdPrint.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdView.Enabled = True
                    Me.CmdPrint.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.CmdPrint.Enabled = True
                End If
            Next
        End If
    End Sub
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CHBCANCEL As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents Chk_roomselection As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Dtpbookfromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpbooktodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chklist_Rooms As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HALLAVAILABLITY))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CHBCANCEL = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.Chk_roomselection = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Dtpbookfromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpbooktodate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chklist_Rooms = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(396, -33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 22)
        Me.Label3.TabIndex = 454
        Me.Label3.Text = "BILL PENDING"
        '
        'CHBCANCEL
        '
        Me.CHBCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.CHBCANCEL.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHBCANCEL.Location = New System.Drawing.Point(76, 443)
        Me.CHBCANCEL.Name = "CHBCANCEL"
        Me.CHBCANCEL.Size = New System.Drawing.Size(48, 24)
        Me.CHBCANCEL.TabIndex = 2
        Me.CHBCANCEL.Text = "HALL CANCEL"
        Me.CHBCANCEL.UseVisualStyleBackColor = False
        Me.CHBCANCEL.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cmdexport)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.CmdPrint)
        Me.GroupBox4.Controls.Add(Me.CHBCANCEL)
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.CmdView)
        Me.GroupBox4.Location = New System.Drawing.Point(860, 135)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(148, 329)
        Me.GroupBox4.TabIndex = 451
        Me.GroupBox4.TabStop = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdexport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.Black
        Me.cmdexport.Image = CType(resources.GetObject("cmdexport.Image"), System.Drawing.Image)
        Me.cmdexport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexport.Location = New System.Drawing.Point(6, 204)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(137, 50)
        Me.cmdexport.TabIndex = 9
        Me.cmdexport.Text = " Export"
        Me.cmdexport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexport.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Gainsboro
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(7, 19)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(137, 50)
        Me.CmdClear.TabIndex = 6
        Me.CmdClear.Text = "Clear[F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.Gainsboro
        Me.CmdPrint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.Black
        Me.CmdPrint.Image = CType(resources.GetObject("CmdPrint.Image"), System.Drawing.Image)
        Me.CmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPrint.Location = New System.Drawing.Point(7, 143)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(137, 50)
        Me.CmdPrint.TabIndex = 7
        Me.CmdPrint.Text = "Report"
        Me.CmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrint.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(7, 265)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(137, 50)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "Exit[F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.Gainsboro
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(7, 83)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(137, 50)
        Me.CmdView.TabIndex = 5
        Me.CmdView.Text = "View [F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'cmdreport
        '
        Me.cmdreport.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdreport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdreport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ForeColor = System.Drawing.Color.White
        Me.cmdreport.Image = CType(resources.GetObject("cmdreport.Image"), System.Drawing.Image)
        Me.cmdreport.Location = New System.Drawing.Point(864, 384)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(72, 32)
        Me.cmdreport.TabIndex = 8
        Me.cmdreport.Text = "Report[F12]"
        Me.cmdreport.UseVisualStyleBackColor = False
        Me.cmdreport.Visible = False
        '
        'Chk_roomselection
        '
        Me.Chk_roomselection.BackColor = System.Drawing.Color.Transparent
        Me.Chk_roomselection.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_roomselection.Location = New System.Drawing.Point(219, 111)
        Me.Chk_roomselection.Name = "Chk_roomselection"
        Me.Chk_roomselection.Size = New System.Drawing.Size(138, 24)
        Me.Chk_roomselection.TabIndex = 0
        Me.Chk_roomselection.Text = "SELECT ALL "
        Me.Chk_roomselection.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Dtpbookfromdate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.dtpbooktodate)
        Me.GroupBox3.Location = New System.Drawing.Point(216, 468)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(596, 53)
        Me.GroupBox3.TabIndex = 453
        Me.GroupBox3.TabStop = False
        '
        'Dtpbookfromdate
        '
        Me.Dtpbookfromdate.CustomFormat = "dd/MM/yyyy"
        Me.Dtpbookfromdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpbookfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpbookfromdate.Location = New System.Drawing.Point(129, 16)
        Me.Dtpbookfromdate.Name = "Dtpbookfromdate"
        Me.Dtpbookfromdate.Size = New System.Drawing.Size(120, 26)
        Me.Dtpbookfromdate.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(326, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TO DATE :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "FROM DATE :"
        '
        'dtpbooktodate
        '
        Me.dtpbooktodate.CustomFormat = "dd/MM/yyyy"
        Me.dtpbooktodate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpbooktodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpbooktodate.Location = New System.Drawing.Point(404, 18)
        Me.dtpbooktodate.Name = "dtpbooktodate"
        Me.dtpbooktodate.Size = New System.Drawing.Size(120, 26)
        Me.dtpbooktodate.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(322, 566)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(331, 16)
        Me.Label5.TabIndex = 452
        Me.Label5.Text = "Press F2 to select all / Press ENTER key to navigate"
        '
        'chklist_Rooms
        '
        Me.chklist_Rooms.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_Rooms.Location = New System.Drawing.Point(216, 137)
        Me.chklist_Rooms.Name = "chklist_Rooms"
        Me.chklist_Rooms.Size = New System.Drawing.Size(593, 327)
        Me.chklist_Rooms.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(186, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 16)
        Me.Label1.TabIndex = 457
        Me.Label1.Text = "BANQUET  AVAILABLITY  LIST"
        '
        'HALLAVAILABLITY
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1024, 726)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Chk_roomselection)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.chklist_Rooms)
        Me.Controls.Add(Me.cmdreport)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "HALLAVAILABLITY"
        Me.Text = "BANQUET HALL AVAILABLITY LIST"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        If chklist_Rooms.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Hall Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        'Checkdaterangevalidate(Dtpbookfromdate.Value, dtpbooktodate.Value)
        'If chkdatevalidate = False Then Exit Sub
        gPrint = False
        Call Hall_Status()
        Call HallView()
    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        CHBCANCEL.Checked = False
        Chk_roomselection.Checked = False
        chklist_Rooms.Items.Clear()
        Chk_roomselection.Checked = False
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Call FillhallLocation()
        Dtpbookfromdate.Value = Now.Today
        dtpbooktodate.Value = Now.Today
        Chk_roomselection.Focus()
    End Sub
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 732
        K = 1016
        Me.ResizeRedraw = True

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        If U = 800 Then
            T = T - 20
        End If
        If U = 1280 Then
            T = T - 20
        End If
        If U = 1360 Then
            T = T - 55
        End If
        If U = 1366 Then
            T = T - 55
        End If
        Me.Width = U
        Me.Height = T


        With Me
            For i_i = 0 To .Controls.Count - 1
                ' MsgBox(Controls(i_i).Name)
                If TypeOf .Controls(i_i) Is Form Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0
                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If
                ElseIf TypeOf .Controls(i_i) Is Panel Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "Panel" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is GroupBox Then

                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "GroupBox4" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 45
                            End If
                            If U = 1280 Then
                                L = L + 45
                            End If
                            If U = 1360 Then
                                L = L + 70
                            End If
                            If U = 1366 Then
                                L = L + 70
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If

                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is Label Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is TextBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is ComboBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is DateTimePicker Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is PictureBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is CheckBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is CheckedListBox Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is TabControl Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is Button Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "Cmd_Clear" Or Controls(i_i).Name = "Cmd_Add" Or Controls(i_i).Name = "Cmd_Delete" Or Controls(i_i).Name = "Cmd_View" Or Controls(i_i).Name = "Cmd_Print" Or Controls(i_i).Name = "Cmd_Export" Or Controls(i_i).Name = "Cmd_Exit" Or Controls(i_i).Name = "Cmd_PendingBill" Or Controls(i_i).Name = "Cmd_Bill" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                        'L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                End If
            Next i_i
        End With
    End Sub

    Private Sub HALLAVAILABLITY_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()

        CmdClear_Click(sender, e)
    End Sub
    Private Sub FillhallLocation()
        Dim i As Integer
        chklist_Rooms.Items.Clear()
        sqlstring = "SELECT DISTINCT HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,LOCCODE,LOCDESC,FROMTIME,TOTIME FROM PARTY_VIEW_HALLMASTER"
        vconn.getDataSet(sqlstring, "HALL")
        If gdataset.Tables("HALL").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                With gdataset.Tables("HALL").Rows(i)
                    chklist_Rooms.Items.Add(Trim(.Item("HALLTYPECODE") & "-->" & .Item("HALLTYPEDESC") & "-->" & .Item("FROMTIME") & "-->" & .Item("TOTIME") & "-->" & .Item("PCODE") & "-->" & .Item("PDESC") & "-->" & .Item("LOCCODE") & "-->" & .Item("LOCDESC")))
                End With
            Next i
        End If
        chklist_Rooms.Sorted = True
    End Sub
    Private Sub Hall_Status_OLD()
        'PRIVATE SUB STATUSHALL
        Dim i, j, k, L As Integer
        Dim ssql, hallcode, PCODE, tspilt() As String
        Try
            Dim dno, ddiff As Integer
            Dim dd, dd1 As Date
            Dim dt As New DataTable
            Dim dt2 As New DataTable
            Dim DT1 As New DataTable
            Dim DT3 As New DataTable
            Dim II As Integer

            ssql = " DELETE FROM PARTY_HallStatus"
            '            gconnection.dataOperation(6, ssql, "DEL")
            gconnection.GetValues(ssql)
            'dt = vconn.GetValues(ssql)


            ddiff = DateDiff(DateInterval.Day, Dtpbookfromdate.Value, dtpbooktodate.Value)

            If chklist_Rooms.CheckedItems.Count <> 0 Then
                'sqlstring = sqlstring & " WHERE B.PCODE IN ("
                dd = DateAdd(DateInterval.Day, -1, Dtpbookfromdate.Value)
                For i = 0 To ddiff
                    dd = dd.AddDays(+1)
                    For II = 0 To chklist_Rooms.CheckedItems.Count - 1
                        tspilt = Split(chklist_Rooms.CheckedItems(II), "-->")
                        hallcode = tspilt(0)
                        PCODE = tspilt(4)
                        'sqlstring = "SELECT ISNULL(HALLTYPECODE,'')AS HALLCODE,PCODE FROM PARTY_HALLMASTER_DET "
                        'sqlstring = sqlstring & " WHERE HALLCODE IN ='" & Trim(hallcode) & "' AND PCODE='" & Trim(hallcode) & "'"
                        'DT1 = gconnection.GetValues(sqlstring)
                        'If DT1.Rows.Count > 0 Then
                        '    For L = 0 To DT1.Rows.Count - 1

                        '    Next
                        'End If
                        'If i = 0 Then
                        '    ssql = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET "
                        '    ssql = ssql & " WHERE partydate between '" & Mid(Format(Dtpbookfromdate.Value, "dd/MMM/yyyy"), 1, 11) & "' and '" & Mid(Format(dtpbooktodate.Value, "dd/MMM/yyyy"), 1, 11) & "'"
                        '    ssql = ssql & " and hallcode='" & hallcode & "' and isnull(freeze,'')<>'Y' AND PCODE = '" & Trim(PCODE) & "' Order by Totime"

                        'Else
                        ssql = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET WHERE "
                        ssql = ssql & " CAST(Convert(varchar(11),PARTYDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                        ssql = ssql & " and hallcode='" & hallcode & "' and isnull(freeze,'')<>'Y' AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                        ' End If
                        dt = gconnection.GetValues(ssql)

                        SSQL2 = "SELECT * FROM party_hallstatusdetails WHERE "
                        SSQL2 = SSQL2 & " CAST(Convert(varchar(11),PARTYDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                        SSQL2 = SSQL2 & " and hallcode='" & hallcode & "'AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                        DT3 = gconnection.GetValues(SSQL2)

                        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
                            If dt.Rows.Count > 0 Then
                                ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                ssql = ssql & "CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                                ssql = ssql & " and hallcode='" & hallcode & "'"
                                dt2 = gconnection.GetValues(ssql)
                                If dt2.Rows.Count <= 0 Then
                                    ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                                    ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                    gconnection.ExcuteStoreProcedure(ssql)
                                End If
                                For j = 0 To dt.Rows.Count - 1
                                    For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                        ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='B'"
                                        ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                        ssql = ssql & " and hallcode='" & hallcode & "'"

                                        gconnection.ExcuteStoreProcedure(ssql)
                                    Next
                                    ssql = ""
                                Next
                                'If DT3.Rows.Count > 0 Then
                                '    For j = 0 To dt.Rows.Count - 1
                                '        For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                '            ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                                '            ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                '            ssql = ssql & " and hallcode='" & hallcode & "'"

                                '            gconnection.ExcuteStoreProcedure(ssql)
                                '        Next
                                '        ssql = ""
                                '    Next
                                'End If
                            Else
                                ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                ssql = ssql & " CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                                ssql = ssql & " and hallcode='" & hallcode & "'"
                                dt2 = gconnection.GetValues(ssql)
                                If dt2.Rows.Count <= 0 Then
                                    ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
                                    ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                    gconnection.ExcuteStoreProcedure(ssql)
                                End If
                            End If
                            ''FOR ASCA SHOWING THE BOOKED OR CONFORMED 

                        Else
                            If dt.Rows.Count > 0 Then
                                ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                ssql = ssql & "CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                                ssql = ssql & " and hallcode='" & hallcode & "'"
                                dt2 = gconnection.GetValues(ssql)
                                If dt2.Rows.Count <= 0 Then
                                    ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                                    ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                    gconnection.ExcuteStoreProcedure(ssql)
                                End If
                                For j = 0 To dt.Rows.Count - 1
                                    For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                        ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='B'"
                                        ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                        ssql = ssql & " and hallcode='" & hallcode & "'"

                                        gconnection.ExcuteStoreProcedure(ssql)
                                    Next
                                    ssql = ""
                                Next
                                If DT3.Rows.Count > 0 Then
                                    For j = 0 To dt.Rows.Count - 1
                                        For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                            ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                                            ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                            ssql = ssql & " and hallcode='" & hallcode & "'"

                                            gconnection.ExcuteStoreProcedure(ssql)
                                        Next
                                        ssql = ""
                                    Next
                                End If
                            Else
                                ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                ssql = ssql & " CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                                ssql = ssql & " and hallcode='" & hallcode & "'"
                                dt2 = gconnection.GetValues(ssql)
                                If dt2.Rows.Count <= 0 Then
                                    ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
                                    ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                    gconnection.ExcuteStoreProcedure(ssql)
                                End If
                            End If
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Hall_Status()
        'PRIVATE SUB STATUSHALL
        Dim i, j, k, L As Integer
        Dim ssql, hallcode, PCODE, tspilt() As String
        Try
            Dim dno, ddiff As Integer
            Dim dd, dd1 As Date
            Dim dt As New DataTable
            Dim dt2 As New DataTable
            Dim DT1 As New DataTable
            Dim DT3 As New DataTable
            Dim II As Integer

            ssql = " DELETE FROM PARTY_HallStatus"
            '            gconnection.dataOperation(6, ssql, "DEL")
            gconnection.GetValues(ssql)
            'dt = vconn.GetValues(ssql)


            ddiff = DateDiff(DateInterval.Day, Dtpbookfromdate.Value, dtpbooktodate.Value)

            If chklist_Rooms.CheckedItems.Count <> 0 Then
                'sqlstring = sqlstring & " WHERE B.PCODE IN ("
                dd = DateAdd(DateInterval.Day, -1, Dtpbookfromdate.Value)
                For i = 0 To ddiff
                    dd = dd.AddDays(+1)
                    For II = 0 To chklist_Rooms.CheckedItems.Count - 1
                        tspilt = Split(chklist_Rooms.CheckedItems(II), "-->")
                        hallcode = tspilt(0)
                        PCODE = tspilt(4)
                        ssql = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET WHERE "
                        ssql = ssql & "'" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "' BETWEEN cast(convert(varchar(11),Partydate,106)as datetime) AND cast(convert(varchar(11),PartyTodate,106)as datetime)"
                        ssql = ssql & " and hallcode='" & hallcode & "' and isnull(freeze,'')<>'Y' AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"

                        dt = gconnection.GetValues(ssql)

                        SSQL2 = "SELECT * FROM party_hallstatusdetails WHERE "
                        'SSQL2 = SSQL2 & " CAST(Convert(varchar(11),PARTYDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                        SSQL2 = SSQL2 & " '" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "' BETWEEN cast(convert(varchar(11),Partydate,106)as datetime) AND cast(convert(varchar(11),PartyTodate,106)as datetime)"
                        SSQL2 = SSQL2 & " and hallcode='" & hallcode & "'AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                        DT3 = gconnection.GetValues(SSQL2)

                        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
                            If dt.Rows.Count > 0 Then
                                ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                ssql = ssql & "CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                                ssql = ssql & " and hallcode='" & hallcode & "'"
                                dt2 = gconnection.GetValues(ssql)
                                If dt2.Rows.Count <= 0 Then
                                    ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                                    ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                    gconnection.ExcuteStoreProcedure(ssql)
                                End If
                                For j = 0 To dt.Rows.Count - 1
                                    For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                        'ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='P'"
                                        ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='B'"
                                        ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                        ssql = ssql & " and hallcode='" & hallcode & "'"

                                        gconnection.ExcuteStoreProcedure(ssql)
                                    Next
                                    ssql = ""
                                Next
                                'If DT3.Rows.Count > 0 Then
                                '    For j = 0 To dt.Rows.Count - 1
                                '        For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                '            ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                                '            ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                '            ssql = ssql & " and hallcode='" & hallcode & "'"

                                '            gconnection.ExcuteStoreProcedure(ssql)
                                '        Next
                                '        ssql = ""
                                '    Next
                                'End If
                            Else
                                ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                ssql = ssql & " CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                                ssql = ssql & " and hallcode='" & hallcode & "'"
                                dt2 = gconnection.GetValues(ssql)
                                If dt2.Rows.Count <= 0 Then
                                    ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
                                    ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                    gconnection.ExcuteStoreProcedure(ssql)
                                End If
                            End If

                        Else
                            If dt.Rows.Count > 0 Then
                                ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                ssql = ssql & "CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                                ssql = ssql & " and hallcode='" & hallcode & "'"
                                dt2 = gconnection.GetValues(ssql)
                                If dt2.Rows.Count <= 0 Then
                                    ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                                    ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                    gconnection.ExcuteStoreProcedure(ssql)
                                End If
                                For j = 0 To dt.Rows.Count - 1
                                    For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                        'ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='P'"
                                        ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='B'"
                                        ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                        ssql = ssql & " and hallcode='" & hallcode & "'"

                                        gconnection.ExcuteStoreProcedure(ssql)
                                    Next
                                    ssql = ""
                                Next
                                If DT3.Rows.Count > 0 Then
                                    For j = 0 To dt.Rows.Count - 1
                                        For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                            'ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                                            ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                                            ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                            ssql = ssql & " and hallcode='" & hallcode & "'"

                                            gconnection.ExcuteStoreProcedure(ssql)
                                        Next
                                        ssql = ""
                                    Next
                                End If
                            Else
                                ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                ssql = ssql & " CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                                ssql = ssql & " and hallcode='" & hallcode & "'"
                                dt2 = gconnection.GetValues(ssql)
                                If dt2.Rows.Count <= 0 Then
                                    ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
                                    ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                    gconnection.ExcuteStoreProcedure(ssql)
                                End If
                            End If
                        End If
                    Next
                Next

                ddiff = DateDiff(DateInterval.Day, Dtpbookfromdate.Value, dtpbooktodate.Value)

                If chklist_Rooms.CheckedItems.Count <> 0 Then
                    dd = DateAdd(DateInterval.Day, -1, Dtpbookfromdate.Value)
                    For i = 0 To ddiff
                        dd = dd.AddDays(+1)
                        For II = 0 To chklist_Rooms.CheckedItems.Count - 1
                            tspilt = Split(chklist_Rooms.CheckedItems(II), "-->")
                            hallcode = tspilt(0)
                            ssql = " SELECT * FROM Party_Trn_HallBlocking WHERE Trans_Date = '" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "' AND HALLCODE = '" & hallcode & "' "
                            dt = gconnection.GetValues(ssql)
                            If dt.Rows.Count > 0 Then
                                For k = 1 To 24
                                    ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='L'"
                                    ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                    ssql = ssql & " and hallcode='" & hallcode & "'"
                                    gconnection.ExcuteStoreProcedure(ssql)
                                Next
                                ssql = ""
                            End If
                        Next
                    Next
                End If
              
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub print_windows()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r As New RPT_HALLSTATUS
        str = " SELECT * FROM PARTY_VIEW_HALLSTATUS  WHERE"
        If chklist_Rooms.CheckedItems.Count <> 0 Then
            str = str & "  HALLCODE IN ("
            For i = 0 To chklist_Rooms.CheckedItems.Count - 1
                tspilt = Split(chklist_Rooms.CheckedItems(i), "-->")
                If i = 0 Then
                    str = str & "'" & tspilt(0)
                Else
                    str = str & "','" & tspilt(0)
                End If
            Next
            str = str & "') "
        Else
            MessageBox.Show("Select the Hall Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        str = str & " AND CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME) BETWEEN '" & Format(Dtpbookfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtpbooktodate.Value, "dd/MMM/yyyy") & "'"
        'str = str & " ORDER BY BOOKINGDATE,HALLCODE "
        Viewer.ssql = str
        Viewer.Report = r
        Viewer.TableName = "PARTY_VIEW_HALLSTATUS"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text32")
        textobj1.Text = MyCompanyName

        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = r.ReportDefinition.ReportObjects("Text2")
        TXTOBJ6.Text = Address1 & Address2

        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text4")
        'TXTOBJ9.Text = "PhoneNo : " & gphoneno

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text36")
        TXTOBJ1.Text = "UserName : " & gUsername


        Dim TXTOBJ3 As TextObject
        TXTOBJ3 = r.ReportDefinition.ReportObjects("Text38")
        TXTOBJ3.Text = " " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""
        Viewer.Show()
    End Sub
    Private Sub HallView()
        Try
            Dim i As Integer
            Dim tspilt() As String
            Dim sqlstring As String
            sqlstring = "SELECT ISNULL(HALLCODE,'')AS HALLCODE,ISNULL(H.HALLTYPEDESC,'')AS HALLDESC,ISNULL(BOOKINGDATE,'')AS BOOKINGDATE,"
            sqlstring = sqlstring & " ISNULL(B1,'')AS B1, ISNULL(B2,'')AS B2, "
            sqlstring = sqlstring & " ISNULL(B3,'')AS B3, ISNULL(B4,'')AS B4, "
            sqlstring = sqlstring & " ISNULL(B5,'')AS B5, ISNULL(B6,'')AS B6, ISNULL(B7,'')AS B7,"
            sqlstring = sqlstring & " ISNULL(B8,'')AS B8, ISNULL(B9,'')AS B9, "
            sqlstring = sqlstring & " ISNULL(B10,'')AS B10, ISNULL(B11,'')AS B11, "
            sqlstring = sqlstring & " ISNULL(B12,'')AS B12, ISNULL(B13,'')AS B13, ISNULL(B14,'')AS B14, "
            sqlstring = sqlstring & " ISNULL(B15,'')AS B15, ISNULL(B16,'')AS B16, "
            sqlstring = sqlstring & " ISNULL(B17,'')AS B17, ISNULL(B18,'')AS B18, "
            sqlstring = sqlstring & " ISNULL(B19,'')AS B19, ISNULL(B20,'')AS B20, "
            sqlstring = sqlstring & " ISNULL(B21,'')AS B21, ISNULL(B22,'')AS B22, "
            sqlstring = sqlstring & " ISNULL(B23,'')AS B23, ISNULL(B24,'')AS B24 "
            'sqlstring = sqlstring & " FROM party_hallstatus S LEFT OUTER JOIN PARTY_HALLMASTER_HDR H"
            sqlstring = sqlstring & " FROM PARTY_VIEW_HALLSTATUS S LEFT OUTER JOIN PARTY_HALLMASTER_HDR H"
            sqlstring = sqlstring & " ON S.HALLCODE=H.HALLTYPECODE"
            If chklist_Rooms.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE HALLCODE IN ("
                For i = 0 To chklist_Rooms.CheckedItems.Count - 1
                    tspilt = Split(chklist_Rooms.CheckedItems(i), "-->")
                    If i = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(0)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(0)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the Hall Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            sqlstring = sqlstring & " AND CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME) BETWEEN '" & Format(Dtpbookfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtpbooktodate.Value, "dd/MMM/yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY BOOKINGDATE,HALLCODE "
            Dim heading() As String = {"HALL AVAILABLITY DETAILS"}
            Call Reportdetails(sqlstring, heading, Dtpbookfromdate.Value, dtpbooktodate.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Public Function Reportdetails(ByVal SQLSTRING As String, ByVal columnheading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim dblmembertot, dblCosttot, dblDoctot, dblGrand, POSCount, doccount, gdoccount, POSGrand, POStotal, POSGrandtotal As Double
        Dim Membername, Posdesc As String
        Dim Memberbool, POSbool As Boolean
        Dim HALLCODE, SCODE, BILLNO, BILLDETAILS, ADDUSERCODE, CATEGORY As String
        Dim I, BOOKNO As Integer
        Dim STRSTRING As String
        Dim dblBTax, dblBNet, dbltax, dblnet As Double
        Dim BILLDATE As Date

        Try
            Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Call PrintHeader(columnheading, mskfromdate, msktodate)
            vconn.getDataSet(SQLSTRING, "CREDITSALEREGISTER")
            If gdataset.Tables("CREDITSALEREGISTER").Rows.Count > 0 Then
                I = 1
                For Each dr In gdataset.Tables("CREDITSALEREGISTER").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(121, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(columnheading, mskfromdate, msktodate)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If BILLDATE <> dr("BOOKINGDATE") Then
                        Filewrite.Write("|" & Mid(Format(dr("BOOKINGDATE"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dr("BOOKINGDATE"), "dd/MM/yyyy"), 1, 10))))
                        pagesize = pagesize + 1
                    Else
                        Filewrite.Write("|" & Space(10))
                    End If
                    Filewrite.Write("|" & Mid(dr("HALLCODE"), 1, 10) & Space(10 - Len(Mid(dr("HALLCODE"), 1, 10))))
                    Filewrite.Write("|" & Mid(dr("HALLDESC"), 1, 25) & Space(25 - Len(Mid(dr("HALLDESC"), 1, 25))))
                    Filewrite.Write("|" & Mid(dr("B1"), 1, 2) & Space(2 - Len(Mid(dr("B1"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B2"), 1, 2) & Space(2 - Len(Mid(dr("B2"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B3"), 1, 2) & Space(2 - Len(Mid(dr("B3"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B4"), 1, 2) & Space(2 - Len(Mid(dr("B4"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B5"), 1, 2) & Space(2 - Len(Mid(dr("B5"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B6"), 1, 2) & Space(2 - Len(Mid(dr("B6"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B7"), 1, 2) & Space(2 - Len(Mid(dr("B7"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B8"), 1, 2) & Space(2 - Len(Mid(dr("B8"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B9"), 1, 2) & Space(2 - Len(Mid(dr("B9"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B10"), 1, 2) & Space(2 - Len(Mid(dr("B10"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B11"), 1, 2) & Space(2 - Len(Mid(dr("B11"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B12"), 1, 2) & Space(2 - Len(Mid(dr("B12"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B13"), 1, 2) & Space(2 - Len(Mid(dr("B13"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B14"), 1, 2) & Space(2 - Len(Mid(dr("B14"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B15"), 1, 2) & Space(2 - Len(Mid(dr("B15"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B16"), 1, 2) & Space(2 - Len(Mid(dr("B16"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B17"), 1, 2) & Space(2 - Len(Mid(dr("B17"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B18"), 1, 2) & Space(2 - Len(Mid(dr("B18"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B19"), 1, 2) & Space(2 - Len(Mid(dr("B19"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B20"), 1, 2) & Space(2 - Len(Mid(dr("B20"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B21"), 1, 2) & Space(2 - Len(Mid(dr("B21"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B22"), 1, 2) & Space(2 - Len(Mid(dr("B22"), 1, 2))))
                    Filewrite.Write("|" & Mid(dr("B23"), 1, 2) & Space(2 - Len(Mid(dr("B23"), 1, 2))))
                    Filewrite.WriteLine("|" & Mid(dr("B24"), 1, 2) & Space(2 - Len(Mid(dr("B24"), 1, 2))) & "|")
                    BILLDATE = dr("BOOKINGDATE")
                    HALLCODE = dr("HALLCODE")

                    pagesize = pagesize + 1
                    I = I + 1
                Next dr
                Filewrite.WriteLine(StrDup(121, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("Note : " & "B --> Hall Booked")
                pagesize = pagesize + 1
                Filewrite.WriteLine("Prepared By : " & gUsername)
                pagesize = pagesize + 1
            Else
                MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
            End If
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile1(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Function
        End Try
    End Function
    Private Function PrintHeader(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        pagesize = 0
        Try
            Filewrite.WriteLine(Space(35) & Chr(14) & Mid(Trim(MyCompanyName), 1, 30) & Space(30 - Len(Mid(Trim(MyCompanyName), 1, 30))) & Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(35) & "HALL AVAILABLITY DETAILS")
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(1) & Chr(14) & Chr(15) & "PRINTED ON : " & Format(Now, "dd/MM/yyyy") & Space(35) & " PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(121, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("PARTY DATE   HALL DETAILS                       <------------TIME PERIOD IN (HRS)--------------------------------------->")
            pagesize = pagesize + 1
            Filewrite.WriteLine("                                                | 1| 2| 3| 4| 5| 6| 7| 8| 9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(121, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        If chklist_Rooms.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Hall Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        'Checkdaterangevalidate(Dtpbookfromdate.Value, dtpbooktodate.Value)
        'If chkdatevalidate = False Then Exit Sub
        gPrint = True
        Call Hall_Status()
        Call print_windows()
    End Sub
    Private Sub Chk_roomselection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_roomselection.CheckedChanged
        Dim i As Integer
        If Chk_roomselection.Checked = True Then
            For i = 0 To chklist_Rooms.Items.Count - 1
                chklist_Rooms.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_Rooms.Items.Count - 1
                chklist_Rooms.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Sub HALLAVAILABLITY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F2 Then
            For i = 0 To chklist_Rooms.Items.Count - 1
                chklist_Rooms.SetItemChecked(i, True)
            Next i
            Chk_roomselection.Checked = True
            Me.Dtpbookfromdate.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            Call CmdPrint_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F9 Then
            Call CmdView_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.F Then
            Me.Dtpbookfromdate.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.T Then
            Me.dtpbooktodate.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub Chk_roomselection_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Chk_roomselection.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            chklist_Rooms.Focus()
        End If
    End Sub
    Private Sub chklist_Rooms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chklist_Rooms.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            CHBCANCEL.Focus()
        End If
    End Sub
    Private Sub CHBCANCEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CHBCANCEL.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Dtpbookfromdate.Focus()
        End If
    End Sub
    Private Sub Dtpbookfromdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dtpbookfromdate.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            dtpbooktodate.Focus()
        End If
    End Sub
    Private Sub dtpbooktodate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpbooktodate.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            CmdView.Focus()
        End If
    End Sub

    Private Sub Dtpbookfromdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtpbookfromdate.ValueChanged

    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        'Dim r As New crptparty_hallstatus

        'Dim POSdesc(), MemberCode() As String
        'Dim SQLSTRING2 As String
        'sqlstring = "SELECT * FROM party_view_hallstatus WHERE"
        'sqlstring = sqlstring & "  BOOKINGDATE BETWEEN '" & Format(Dtpbookfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtpbooktodate.Value, "dd/MMM/yyyy") & "'"
        'sqlstring = sqlstring & " ORDER BY BOOKINGDATE,HALLCODE "
        'Call Viewer.GetDetails(sqlstring, "party_view_hallstatus", r)
        'Viewer.Report = r

        'Viewer.TableName = "party_view_hallstatus"
        'Viewer.Show()
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
       
        Call Hall_Status()

        Dim i As Integer
        Dim sqlstring, MTYPE(), tspilt() As String
        sqlstring = " SELECT * FROM PARTY_VIEW_HALLSTATUS  WHERE"
        If chklist_Rooms.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "  HALLCODE IN ("
            For i = 0 To chklist_Rooms.CheckedItems.Count - 1
                tspilt = Split(chklist_Rooms.CheckedItems(i), "-->")
                If i = 0 Then
                    sqlstring = sqlstring & "'" & tspilt(0)
                Else
                    sqlstring = sqlstring & "','" & tspilt(0)
                End If
            Next
            sqlstring = sqlstring & "') "
        Else
            MessageBox.Show("Select the Hall Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        sqlstring = sqlstring & " AND CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME) BETWEEN '" & Format(Dtpbookfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtpbooktodate.Value, "dd/MMM/yyyy") & "'"

        Dim exp As New exportexcel
        exp.Show()
        Call exp.export(sqlstring, "HALL AVAILABLITY STATUS  " & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtpbooktodate.Value, "dd-MMM-yyyy"), "")
    End Sub

    Private Sub chklist_Rooms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklist_Rooms.SelectedIndexChanged

    End Sub
End Class
