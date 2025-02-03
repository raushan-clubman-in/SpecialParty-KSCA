Imports System.Data.OleDb
Imports System.IO
Imports System.Data.SqlClient
Imports System
Imports System.Data
Public Class FRM_MKGA_POSGROUPMASTER
    Inherits System.Windows.Forms.Form
    Dim ssql, Lstposcode As String
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass
    Dim boolchk As Boolean
    Dim i, j As Integer
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
    Friend WithEvents Cmdview As System.Windows.Forms.Button
    Friend WithEvents cmd_brwse As System.Windows.Forms.Button

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_groupcode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGroupCode As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    'Friend WithEvents Lst_poscode As System.Windows.Forms.ListBox
    Friend WithEvents Txt_groupdesc As System.Windows.Forms.TextBox
    Friend WithEvents lst_poscode As System.Windows.Forms.CheckedListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MKGA_POSGROUPMASTER))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdGroupCode = New System.Windows.Forms.Button()
        Me.Txt_groupdesc = New System.Windows.Forms.TextBox()
        Me.Txt_groupcode = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lst_poscode = New System.Windows.Forms.CheckedListBox()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Cmdview = New System.Windows.Forms.Button()
        Me.cmd_auth = New System.Windows.Forms.Button()
        Me.cmd_brwse = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(187, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "POS GROUPING MASTER"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "GROUP CODE :"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(256, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "GROUP DESCRIPTION :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmdGroupCode)
        Me.GroupBox1.Controls.Add(Me.Txt_groupdesc)
        Me.GroupBox1.Controls.Add(Me.Txt_groupcode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(183, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 64)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'cmdGroupCode
        '
        Me.cmdGroupCode.Location = New System.Drawing.Point(220, 18)
        Me.cmdGroupCode.Name = "cmdGroupCode"
        Me.cmdGroupCode.Size = New System.Drawing.Size(23, 26)
        Me.cmdGroupCode.TabIndex = 12
        Me.cmdGroupCode.Text = "?"
        '
        'Txt_groupdesc
        '
        Me.Txt_groupdesc.Location = New System.Drawing.Point(384, 22)
        Me.Txt_groupdesc.Name = "Txt_groupdesc"
        Me.Txt_groupdesc.Size = New System.Drawing.Size(152, 20)
        Me.Txt_groupdesc.TabIndex = 4
        '
        'Txt_groupcode
        '
        Me.Txt_groupcode.Location = New System.Drawing.Point(96, 22)
        Me.Txt_groupcode.Name = "Txt_groupcode"
        Me.Txt_groupcode.Size = New System.Drawing.Size(120, 20)
        Me.Txt_groupcode.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lst_poscode)
        Me.GroupBox2.Controls.Add(Me.ssgrid)
        Me.GroupBox2.Location = New System.Drawing.Point(183, 279)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(675, 319)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'lst_poscode
        '
        Me.lst_poscode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_poscode.Location = New System.Drawing.Point(8, 16)
        Me.lst_poscode.Name = "lst_poscode"
        Me.lst_poscode.Size = New System.Drawing.Size(224, 289)
        Me.lst_poscode.TabIndex = 425
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(256, 16)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(408, 288)
        Me.ssgrid.TabIndex = 424
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.BackgroundImage = Global.SpecialParty.My.Resources.Resources.Clear
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(9, 39)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Clear.TabIndex = 5
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Cmdview)
        Me.GroupBox3.Controls.Add(Me.cmd_auth)
        Me.GroupBox3.Controls.Add(Me.cmd_brwse)
        Me.GroupBox3.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox3.Controls.Add(Me.Cmd_Add)
        Me.GroupBox3.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox3.Location = New System.Drawing.Point(853, 148)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(154, 476)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'Cmdview
        '
        Me.Cmdview.BackColor = System.Drawing.Color.Transparent
        Me.Cmdview.BackgroundImage = Global.SpecialParty.My.Resources.Resources.view
        Me.Cmdview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmdview.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdview.ForeColor = System.Drawing.Color.Black
        Me.Cmdview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdview.Location = New System.Drawing.Point(8, 183)
        Me.Cmdview.Name = "Cmdview"
        Me.Cmdview.Size = New System.Drawing.Size(144, 65)
        Me.Cmdview.TabIndex = 11
        Me.Cmdview.Text = "View [F9]"
        Me.Cmdview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdview.UseVisualStyleBackColor = False
        '
        'cmd_auth
        '
        Me.cmd_auth.BackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_auth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_auth.ForeColor = System.Drawing.Color.Black
        Me.cmd_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_auth.Location = New System.Drawing.Point(8, 317)
        Me.cmd_auth.Name = "cmd_auth"
        Me.cmd_auth.Size = New System.Drawing.Size(144, 65)
        Me.cmd_auth.TabIndex = 10
        Me.cmd_auth.Text = "Authorize"
        Me.cmd_auth.UseVisualStyleBackColor = False
        '
        'cmd_brwse
        '
        Me.cmd_brwse.BackColor = System.Drawing.Color.Transparent
        Me.cmd_brwse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_brwse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_brwse.ForeColor = System.Drawing.Color.Black
        Me.cmd_brwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_brwse.Location = New System.Drawing.Point(9, 250)
        Me.cmd_brwse.Name = "cmd_brwse"
        Me.cmd_brwse.Size = New System.Drawing.Size(144, 65)
        Me.cmd_brwse.TabIndex = 9
        Me.cmd_brwse.Text = "Browse"
        Me.cmd_brwse.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.BackgroundImage = Global.SpecialParty.My.Resources.Resources._Exit
        Me.Cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(9, 393)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Exit.TabIndex = 8
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.BackgroundImage = Global.SpecialParty.My.Resources.Resources.save
        Me.Cmd_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(9, 112)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Add.TabIndex = 6
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Navy
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(896, 110)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 9
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.UseVisualStyleBackColor = False
        Me.Cmd_View.Visible = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.Navy
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.Location = New System.Drawing.Point(881, 148)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze.TabIndex = 7
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        Me.Cmd_Freeze.Visible = False
        '
        'FRM_MKGA_POSGROUPMASTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.Cmd_View)
        Me.KeyPreview = True
        Me.Name = "FRM_MKGA_POSGROUPMASTER"
        Me.Text = "POSGROUPMASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub POSGROUPMASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call FillPOS() ''--> Fill All POS Location
        Call FillGrid() ''--> Fill All group
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Me.Txt_groupcode.ReadOnly = False
        Txt_groupcode.Focus()

    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='POS' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        vconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub POSGROUPMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        'If e.KeyCode = Keys.F8 Then
        '    If Cmd_Freeze.Enabled = True Then
        '        Call Cmd_Freeze_Click(Cmd_Freeze, e)
        '        Exit Sub
        '    End If
        'End If
        If e.KeyCode = Keys.F7 Then
            If Cmd_Add.Enabled = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            If Cmd_View.Enabled = True Then
                Call Cmdview_Click(Cmdview, e)
                Exit Sub
            End If
        End If

        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If

    End Sub
    Private Sub FillGrid()
        Dim j, i As Integer
        i = 1
        SQLSTRING = " SELECT DISTINCT ISNULL(Groupcode,'') AS Groupcode,ISNULL(GroupName,'')AS GroupName,"
        SQLSTRING = SQLSTRING & " ISNULL(PosCode,'')AS PosCode,ISNULL(PosDesc,'') AS PosDesc  "
        SQLSTRING = SQLSTRING & " FROM POSGROUPMASTER  WHERE  ISNULL(VOID,'') <> 'Y'"
        gconnection.getDataSet(SQLSTRING, "POSGROUPMASTER")
        If gdataset.Tables("POSGROUPMASTER").Rows.Count > 0 Then
            ssgrid.ClearRange(1, 1, -1, -1, True)
            For j = 0 To gdataset.Tables("POSGROUPMASTER").Rows.Count - 1
                With ssgrid
                    .Row = i
                    .Col = 1
                    .Text = gdataset.Tables("POSGROUPMASTER").Rows(j).Item("Groupcode") & "-->" & gdataset.Tables("POSGROUPMASTER").Rows(j).Item("GroupName")
                    .Row = i
                    .Col = 2
                    .Text = gdataset.Tables("POSGROUPMASTER").Rows(j).Item("PosCode") & "-->" & gdataset.Tables("POSGROUPMASTER").Rows(j).Item("PosDesc")
                    i = i + 1
                End With
            Next
            ssgrid.Focus()
        Else
            ssgrid.ClearRange(1, 1, -1, -1, True)
        End If

    End Sub
    Private Sub FillPOS()
        Dim varposcode() As String
        ssql = "SELECT ISNULL(POSCODE,'') AS POSCODE,ISNULL(POSDESC,'') AS POSDESC FROM POSMaster WHERE ISNULL(Freeze,'') <> 'Y'and poscode not in(select poscode from posgroupmaster where isnull(void,'')<>'Y') "
        ssql = ssql & " union all select poscode,posdesc from POSGROUPMASTER where groupcode='" & Me.Txt_groupcode.Text & "' AND ISNULL(VOID,'')<>'Y' ORDER BY POSCODE"
        lst_poscode.Items.Clear()
        gconnection.getDataSet(ssql, "POSMaster")
        If gdataset.Tables("POSMaster").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("POSMaster").Rows.Count - 1
                With gdataset.Tables("POSMaster").Rows(i)
                    lst_poscode.Items.Add(Trim(.Item("POSCODE")) & "-->" & Trim(.Item("POSDESC")))
                End With
            Next i
        End If
        If Me.Txt_groupcode.Text <> "" Then
            ssql = "select poscode from POSGROUPMASTER where groupcode='" & Me.Txt_groupcode.Text & "'and isnull(void,'')<>'y'"
            vconn.getDataSet(ssql, "grp")
            If gdataset.Tables("grp").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("grp").Rows.Count - 1
                    For j = 0 To Me.lst_poscode.Items.Count - 1
                        varposcode = Split(Me.lst_poscode.Items(j), "-->")
                        If gdataset.Tables("grp").Rows(i).Item("poscode") = varposcode(0) Then
                            lst_poscode.SetItemChecked(j, True)
                        End If
                    Next

                Next
            End If
        End If

    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Me.Txt_groupcode.ReadOnly = False
        Txt_groupcode.Text = ""
        Txt_groupdesc.Text = ""
        Call FillPOS()
        Call FillGrid()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Txt_groupcode.Focus()
    End Sub
    Public Sub checkValidation()
        boolchk = False
        ''********** Check  Store Code Can't be blank *********************'''
        If Trim(Txt_groupcode.Text) = "" Then
            MessageBox.Show(" Group Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_groupcode.Focus()
            Exit Sub
        End If
        ''********** Check  Store desc Can't be blank *********************'''
        If Trim(Txt_groupdesc.Text) = "" Then
            MessageBox.Show(" Group Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_groupdesc.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click

        Dim insert(0), VarPOSCODE(), checked As String
        Dim vstring, vDate As Date
        'If Cmd_Add.Text = "Add [F7]" Then
        Call checkValidation()
        If boolchk = False Then Exit Sub
        ssql = " update Posgroupmaster set void='Y',voiduser='" & gUsername & "',voiddate=getdate() where groupcode='" & Me.Txt_groupcode.Text & "'"
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = ssql
        For i = 0 To lst_poscode.Items.Count - 1
            If lst_poscode.GetItemChecked(i) = True Then
                ssql = " INSERT INTO Posgroupmaster (Groupcode,Groupname,Poscode,Posdesc,Adduserid,Adddate) "
                ssql = ssql & " VALUES('" & Trim(Txt_groupcode.Text) & "', '" & Trim(Txt_groupdesc.Text) & "',"
                VarPOSCODE = Split(lst_poscode.Items(i), "-->")
                ssql = ssql & "'" & VarPOSCODE(0) & "','" & VarPOSCODE(1) & "',"
                ssql = ssql & " '" & Trim(gUsername) & "',"
                ssql = ssql & " '" & Format(DateTime.Now, "dd/MMM/yyyy") & "')"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = ssql
            End If
        Next
        vconn.MoreTransold(insert)
        Me.Cmd_Clear_Click(sender, e)
        'ElseIf Cmd_Add.Text = "Update[F7]" Then
        'Call checkValidation() '''--->Check Validation
        'If boolchk = False Then Exit Sub
        'If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
        '    If Me.lbl_Freeze.Visible = True Then
        '        MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '        boolchk = False
        '        Exit Sub
        '    End If
        'End If

        'ssql = "UPDATE  Posgroupmaster "
        'ssql = ssql & " SET Groupname='" & Replace(Trim(Txt_groupdesc.Text), "'", "") & "',"
        'VarPOSCODE = Split(lst_poscode.Items(i), "-->")
        'ssql = ssql & "'" & VarPOSCODE(0) & "','" & VarPOSCODE(1) & "',"
        'ssql = ssql & " set  ADDUSERID='" & Trim(gUsername) & "',"
        'ssql = ssql & " VOIDUSER='" & Trim(gUsername) & "',AddDate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',VOID='N'"
        'ssql = ssql & " WHERE Groupcode = '" & Trim(Txt_groupcode.Text) & "'"
        'gconnection.dataOperation(2, ssql, "Posgroupmaster")

        'Me.Cmd_Clear_Click(sender, e)
        'Cmd_Add.Text = "Add [F7]"
        'End If
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click

    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub cmdGroupCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroupCode.Click
       
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT DISTINCT ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPNAME,'') AS GROUPNAME FROM posgroupmaster"
            M_WhereCondition = " where isnull(void,'')<>'y' "
            vform.Field = "GROUPCODE,GROUPNAME"
            ' vform.Frmcalled = "   GROUP CODE      |   GROUP DESCRIPTION       |                                  "
            vform.vCaption = " Group Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_groupcode.Text = Trim(vform.keyfield & "")
                Txt_groupcode_Validated(sender, e)
                'cmd_add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try

    End Sub

    Private Sub ssgrid_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid.Advance

    End Sub

    Private Sub Txt_groupcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_groupcode.Validated
        ssql = "select * from posgroupmaster where groupcode='" & Me.Txt_groupcode.Text & "' and isnull(void,'')<>'y'"
        vconn.getDataSet(ssql, "grp1")
        If gdataset.Tables("grp1").Rows.Count > 0 Then
            Me.Txt_groupdesc.Text = gdataset.Tables("grp1").Rows(0).Item("groupname")
            Call FillPOS()
            Me.Txt_groupcode.ReadOnly = True
        End If

    End Sub

    Private Sub Txt_groupcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_groupcode.TextChanged

    End Sub

    Private Sub Txt_groupcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_groupcode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdGroupCode.Enabled = True Then
                Search = Trim(Txt_groupcode.Text)
                Call cmdGroupCode_Click(sender, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Txt_groupdesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_groupdesc.TextChanged

    End Sub

    Private Sub Txt_groupdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_groupdesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Txt_groupdesc.Text <> "" Then
                lst_poscode.Focus()
            Else
                Txt_groupdesc.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_groupcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_groupcode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_groupcode.Text) <> "" Then
                Call Txt_groupcode_Validated(sender, e)
                Txt_groupdesc.Focus()
            Else
                Call cmdGroupCode_Click(cmdGroupCode, e)
                Txt_groupcode.Focus()
            End If
        End If

    End Sub

    Private Sub Cmdview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdview.Click
        Dim FRM As New ReportDesigner
        '  If txtlocationcode.Text.Length > 0 Then
        'tables = " FROM LOCATIONMASTER WHERE LOCATIONCODE = '" & Trim(txtlocationcode.Text) & "'"
        'Else
        tables = "FROM posgroupmaster "
        ' End If
        Gheader = "posgroupmaster DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"GROUPCODE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GROUPNAME", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"POSCODE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"POSDESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"VOID", "5"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSERID", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDDATE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub cmd_brwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_brwse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM posgroupmaster"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM posgroupmaster", "SERIALNO", 0)
    End Sub

    Private Sub cmd_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_auth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM posgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM posgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
                    gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                    If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                        Dim VIEW1 As New AUTHORISATION
                        VIEW1.Show()
                        VIEW1.DTAUTH.DataSource = Nothing
                        VIEW1.DTAUTH.Rows.Clear()
                        'Dim STRQUERY As String
                        'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                        ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                        'gconnection.getDataSet(STRQUERY, "authorize")

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE posgroupmaster set  ", "GROUPCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM posgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM posgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            'Dim STRQUERY As String
                            'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                            ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                            'gconnection.getDataSet(STRQUERY, "authorize")

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE posgroupmaster set  ", "GROUPCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM posgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM posgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE posgroupmaster set  ", "GROUPCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub
End Class
