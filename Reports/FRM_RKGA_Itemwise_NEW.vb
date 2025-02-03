Imports System.Data.SqlClient
Public Class FRM_RKGA_Itemwise_NEW
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
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Chk_SelectAllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents LstGroup As System.Windows.Forms.CheckedListBox
    Friend WithEvents LstPOS As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_SelectAllPos As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents grp_Salebillitemwise As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents SSGRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllCategory As System.Windows.Forms.CheckBox
    Friend WithEvents lstcategory As System.Windows.Forms.CheckedListBox
    Friend WithEvents CMDREPORT As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_RKGA_Itemwise_NEW))
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMDREPORT = New System.Windows.Forms.Button()
        Me.Chk_SelectAllGroup = New System.Windows.Forms.CheckBox()
        Me.LstGroup = New System.Windows.Forms.CheckedListBox()
        Me.LstPOS = New System.Windows.Forms.CheckedListBox()
        Me.Chk_SelectAllPos = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.grp_Salebillitemwise = New System.Windows.Forms.GroupBox()
        Me.lbl_Wait = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SSGRID = New AxFPSpreadADO.AxfpSpread()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllCategory = New System.Windows.Forms.CheckBox()
        Me.lstcategory = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox2.SuspendLayout()
        Me.grp_Salebillitemwise.SuspendLayout()
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Transparent
        Me.CmdClear.BackgroundImage = Global.SpecialParty.My.Resources.Resources.Clear
        Me.CmdClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(7, 32)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(131, 56)
        Me.CmdClear.TabIndex = 4
        Me.CmdClear.Text = "Clear [F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.CmdView)
        Me.GroupBox2.Controls.Add(Me.CmdPrint)
        Me.GroupBox2.Controls.Add(Me.cmdexit)
        Me.GroupBox2.Controls.Add(Me.CmdClear)
        Me.GroupBox2.Controls.Add(Me.CMDREPORT)
        Me.GroupBox2.Location = New System.Drawing.Point(865, 215)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(142, 344)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdView.BackgroundImage = CType(resources.GetObject("CmdView.BackgroundImage"), System.Drawing.Image)
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.White
        Me.CmdView.Location = New System.Drawing.Point(136, 16)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(104, 32)
        Me.CmdView.TabIndex = 0
        Me.CmdView.Text = "View [F9]"
        Me.CmdView.UseVisualStyleBackColor = False
        Me.CmdView.Visible = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.Transparent
        ' Me.CmdPrint.BackgroundImage = Global.SMARTPOS.My.Resources.Resources.excel
        Me.CmdPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdPrint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.Black
        Me.CmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPrint.Location = New System.Drawing.Point(8, 194)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(131, 56)
        Me.CmdPrint.TabIndex = 1
        Me.CmdPrint.Text = "Export  [F12]"
        Me.CmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrint.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.BackgroundImage = Global.SpecialParty.My.Resources.Resources._Exit
        Me.cmdexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(9, 275)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(131, 56)
        Me.cmdexit.TabIndex = 2
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMDREPORT
        '
        Me.CMDREPORT.BackColor = System.Drawing.Color.Transparent
        Me.CMDREPORT.BackgroundImage = Global.SpecialParty.My.Resources.Resources.view
        Me.CMDREPORT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CMDREPORT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREPORT.ForeColor = System.Drawing.Color.Black
        Me.CMDREPORT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMDREPORT.Location = New System.Drawing.Point(7, 114)
        Me.CMDREPORT.Name = "CMDREPORT"
        Me.CMDREPORT.Size = New System.Drawing.Size(131, 56)
        Me.CMDREPORT.TabIndex = 2
        Me.CMDREPORT.Text = "Report [F9]"
        Me.CMDREPORT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMDREPORT.UseVisualStyleBackColor = False
        '
        'Chk_SelectAllGroup
        '
        Me.Chk_SelectAllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllGroup.Location = New System.Drawing.Point(465, 205)
        Me.Chk_SelectAllGroup.Name = "Chk_SelectAllGroup"
        Me.Chk_SelectAllGroup.Size = New System.Drawing.Size(64, 24)
        Me.Chk_SelectAllGroup.TabIndex = 16
        Me.Chk_SelectAllGroup.Text = "SELECT ALL "
        Me.Chk_SelectAllGroup.UseVisualStyleBackColor = False
        Me.Chk_SelectAllGroup.Visible = False
        '
        'LstGroup
        '
        Me.LstGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstGroup.Location = New System.Drawing.Point(465, 253)
        Me.LstGroup.Name = "LstGroup"
        Me.LstGroup.Size = New System.Drawing.Size(72, 319)
        Me.LstGroup.TabIndex = 17
        Me.LstGroup.Visible = False
        '
        'LstPOS
        '
        Me.LstPOS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstPOS.Location = New System.Drawing.Point(224, 246)
        Me.LstPOS.Name = "LstPOS"
        Me.LstPOS.Size = New System.Drawing.Size(272, 319)
        Me.LstPOS.TabIndex = 18
        '
        'Chk_SelectAllPos
        '
        Me.Chk_SelectAllPos.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllPos.Location = New System.Drawing.Point(224, 200)
        Me.Chk_SelectAllPos.Name = "Chk_SelectAllPos"
        Me.Chk_SelectAllPos.Size = New System.Drawing.Size(128, 24)
        Me.Chk_SelectAllPos.TabIndex = 19
        Me.Chk_SelectAllPos.Text = "SELECT ALL"
        Me.Chk_SelectAllPos.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(256, 667)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(296, 15)
        Me.Label4.TabIndex = 417
        Me.Label4.Text = "Press F2 to select all / Press ENTER key to navigate"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(224, 220)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(272, 24)
        Me.Label1.TabIndex = 418
        Me.Label1.Text = "POS LOCATION:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(465, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 24)
        Me.Label2.TabIndex = 419
        Me.Label2.Text = "GROUP DESCRIPTION :"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(184, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 16)
        Me.Label3.TabIndex = 420
        Me.Label3.Text = "POS MENU REPORT"
        '
        'Timer1
        '
        '
        'grp_Salebillitemwise
        '
        Me.grp_Salebillitemwise.Controls.Add(Me.lbl_Wait)
        Me.grp_Salebillitemwise.Controls.Add(Me.ProgressBar1)
        Me.grp_Salebillitemwise.Location = New System.Drawing.Point(216, 600)
        Me.grp_Salebillitemwise.Name = "grp_Salebillitemwise"
        Me.grp_Salebillitemwise.Size = New System.Drawing.Size(496, 56)
        Me.grp_Salebillitemwise.TabIndex = 421
        Me.grp_Salebillitemwise.TabStop = False
        '
        'lbl_Wait
        '
        Me.lbl_Wait.AutoSize = True
        Me.lbl_Wait.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Wait.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Wait.Location = New System.Drawing.Point(248, 22)
        Me.lbl_Wait.Name = "lbl_Wait"
        Me.lbl_Wait.Size = New System.Drawing.Size(0, 15)
        Me.lbl_Wait.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 10)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(480, 40)
        Me.ProgressBar1.TabIndex = 0
        '
        'SSGRID
        '
        Me.SSGRID.DataSource = Nothing
        Me.SSGRID.Location = New System.Drawing.Point(2, 8)
        Me.SSGRID.Name = "SSGRID"
        Me.SSGRID.OcxState = CType(resources.GetObject("SSGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID.Size = New System.Drawing.Size(926, 10)
        Me.SSGRID.TabIndex = 613
        Me.SSGRID.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(541, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(224, 24)
        Me.Label5.TabIndex = 616
        Me.Label5.Text = "CATEGORY"
        '
        'Chk_SelectAllCategory
        '
        Me.Chk_SelectAllCategory.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllCategory.Location = New System.Drawing.Point(541, 203)
        Me.Chk_SelectAllCategory.Name = "Chk_SelectAllCategory"
        Me.Chk_SelectAllCategory.Size = New System.Drawing.Size(128, 24)
        Me.Chk_SelectAllCategory.TabIndex = 614
        Me.Chk_SelectAllCategory.Text = "SELECT ALL "
        Me.Chk_SelectAllCategory.UseVisualStyleBackColor = False
        '
        'lstcategory
        '
        Me.lstcategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstcategory.Location = New System.Drawing.Point(541, 248)
        Me.lstcategory.Name = "lstcategory"
        Me.lstcategory.Size = New System.Drawing.Size(224, 319)
        Me.lstcategory.TabIndex = 615
        '
        'FRM_RKGA_Itemwise_NEW
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImage = Global.SpecialParty.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1014, 692)
        Me.Controls.Add(Me.SSGRID)
        Me.Controls.Add(Me.grp_Salebillitemwise)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Chk_SelectAllPos)
        Me.Controls.Add(Me.LstPOS)
        Me.Controls.Add(Me.Chk_SelectAllGroup)
        Me.Controls.Add(Me.LstGroup)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lstcategory)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Chk_SelectAllCategory)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "FRM_RKGA_Itemwise_NEW"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ITEM MASTER PRINTING"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.grp_Salebillitemwise.ResumeLayout(False)
        Me.grp_Salebillitemwise.PerformLayout()
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim ssql As String
    Public Myconn As New SqlConnection
    Dim ds As DataSet
    Dim chkbool As Boolean
    Dim da As New SqlDataAdapter
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass
    Private Sub FillPOS()   '''***************************** To fill POS details from POSMaster  *****************'''
        LstPOS.Items.Clear()
        Dim i As Integer
        ssql = "SELECT DISTINCT POSCODE,POSDESC FROM POSMASTER "
        vconn.getDataSet(ssql, "POSMASTER")
        If gdataset.Tables("POSMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("POSMASTER").Rows.Count - 1
                With gdataset.Tables("POSMASTER").Rows(i)
                    LstPOS.Items.Add(Trim(.Item("POSDESC")))
                End With
            Next i
        End If
        LstPOS.Sorted = True
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
                    Me.CmdPrint.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub FillGroup()   '''***************************** To fill Group details from GroupMaster  *****************'''
        LstGroup.Items.Clear()
        Dim i As Integer
        ssql = "SELECT DISTINCT GROUPCODE,GROUPDESC FROM GROUPMASTER "
        vconn.getDataSet(ssql, "GROUPMASTER")
        If gdataset.Tables("GROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("GROUPMASTER").Rows.Count - 1
                With gdataset.Tables("GROUPMASTER").Rows(i)
                    LstGroup.Items.Add(Trim(.Item("GROUPDESC")))
                End With
            Next
        End If
    End Sub
    Private Sub Chk_SelectAllPos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllPos.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllPos.Checked = True Then
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
            Me.ProgressBar1.Value += 1
            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar1.Value = 0
            Me.grp_Salebillitemwise.Top = 1000
            Call viewItemmasterprinting()
        End If
    End Sub
    Public Sub viewItemmasterprinting()
        Dim Sqlstring, GroupCode() As String
        Dim i As Integer
        Sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(I.ITEMTYPECODE,'') AS ITEMTYPECODE,"
        Sqlstring = Sqlstring & " ISNULL(R.UOM,'') AS UOM,ISNULL(R.PURCAHSERATE,0) AS PURCHASERATE,ISNULL(R.ITEMRATE,0) AS ITEMRATE,CASE WHEN ISNULL(Z.TAXPERCENTAGE,0)<>0 THEN ROUND(R.ITEMRATE+(R.ITEMRATE*(Z.TAXPERCENTAGE/100)),0) ELSE R.ITEMRATE END AS VATRATE,"
        Sqlstring = Sqlstring & " ISNULL(PL.POS,'') AS POSCODE,ISNULL(P.POSDESC,'') AS POSDESC,ISNULL(I.GROUPCODE,'') AS GROUPCODE,"
        Sqlstring = Sqlstring & " ISNULL(G.GROUPDESC,'') AS GROUPDESC,ISNULL(I.FREEZE,'') AS FREEZE,ISNULL(R.ENDINGDATE,'') AS ENDINGDATE FROM ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON R.ITEMCODE = I.ITEMCODE INNER JOIN ITEMTYPEMASTER AS Z ON I.ITEMTYPECODE=Z.ITEMTYPECODE "
        Sqlstring = Sqlstring & " INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON P.POSCODE = PL.POS"
        Sqlstring = Sqlstring & " INNER JOIN GROUPMASTER AS G ON G.GROUPCODE = I.GROUPCODE "
        If LstPOS.CheckedItems.Count <> 0 Then
            Sqlstring = Sqlstring & " WHERE POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                Sqlstring = Sqlstring & " '" & Trim(LstPOS.CheckedItems(i)) & "', "
            Next i
            Sqlstring = Mid(Sqlstring, 1, Len(Sqlstring) - 2)
            Sqlstring = Sqlstring & ")"
        Else
            MsgBox("Select the location(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If
        If LstGroup.CheckedItems.Count <> 0 Then
            Sqlstring = Sqlstring & " AND GROUPDESC IN ("
            For i = 0 To LstGroup.CheckedItems.Count - 1
                Sqlstring = Sqlstring & " '" & Trim(LstGroup.CheckedItems(i)) & "', "
            Next
            Sqlstring = Mid(Sqlstring, 1, Len(Sqlstring) - 2)
            Sqlstring = Sqlstring & ")"
        Else
            MsgBox("Select the Group(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Sub
        End If
        Sqlstring = Sqlstring & " AND ISNULL(I.FREEZE,'') <> 'Y' AND  ISNULL(R.ENDINGDATE,'')=''"
        Sqlstring = Sqlstring & " GROUP BY P.POSDESC,PL.POS,I.GROUPCODE,G.GROUPDESC,I.ITEMCODE,"
        Sqlstring = Sqlstring & " I.ITEMDESC,R.UOM,R.PURCAHSERATE,R.ITEMRATE,I.ITEMTYPECODE,I.FREEZE,R.ENDINGDATE,Z.TAXPERCENTAGE ORDER BY GROUPDESC,POSDESC,ITEMCODE,ITEMDESC"
        Dim heading() As String = {"ITEM MASTER CHECKLIST", LstPOS.CheckedItems(0)}
        'Dim ObjItemmasterchecklist As New rptItemmasterchecklist
        'If CheckBox1.Checked = True And CheckBox2.Checked = False Then
        '    ObjItemmasterchecklist.printdatasale(Sqlstring, heading, Format(Now, "dd-MMM-yyyy"), Format(Now, "dd-MMM-yyyy"))
        'ElseIf CheckBox2.Checked = True And CheckBox1.Checked = False Then
        '    ObjItemmasterchecklist.printdatapurchase(Sqlstring, heading, Format(Now, "dd-MMM-yyyy"), Format(Now, "dd-MMM-yyyy"))
        'ElseIf CheckBox3.Checked = True Then
        '    ObjItemmasterchecklist.printdatasalevat(Sqlstring, heading, Format(Now, "dd-MMM-yyyy"), Format(Now, "dd-MMM-yyyy"))
        'ElseIf chkNonRate.Checked = True And CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False Then
        '    ObjItemmasterchecklist.printwithoutrate(Sqlstring, heading, Format(Now, "dd-MMM-yyyy"), Format(Now, "dd-MMM-yyyy"))
        'Else
        '    ObjItemmasterchecklist.printdata(Sqlstring, heading, Format(Now, "dd-MMM-yyyy"), Format(Now, "dd-MMM-yyyy"))
        'End If
    End Sub

    Private Sub Chk_SelectAllGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllGroup.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllGroup.Checked = True Then
            For i = 0 To LstGroup.Items.Count - 1
                LstGroup.SetItemChecked(i, True)
            Next i
        Else
            For i = 0 To LstGroup.Items.Count - 1
                LstGroup.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        LstPOS.Items.Clear()
        LstGroup.Items.Clear()
        Chk_SelectAllGroup.Checked = False
        Chk_SelectAllPos.Checked = False
        SSGRID.Visible = False
        lstcategory.Items.Clear()
        lstcategory.Items.Add(Trim("CANTEEN"))
        lstcategory.Items.Add(Trim("BAR"))
        lstcategory.Items.Add(Trim("FACILITY"))


        Call FillGroup()
        Call FillPOS()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        'If LstPOS.CheckedItems.Count = 0 Then
        '    MsgBox("Select the location(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
        '    Exit Sub
        'End If
        'If LstGroup.CheckedItems.Count = 0 Then
        '    MsgBox("Select the Group(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
        '    Exit Sub
        'End If
        'gPrint = False
        'grp_Salebillitemwise.Top = 424
        'grp_Salebillitemwise.Left = 120
        'Me.ProgressBar1.Value = 2
        'Me.Timer1.Interval = 30
        'Me.Timer1.Enabled = True
        Call GRID_VIEW()
        If SSGRID.DataRowCnt > 0 Then
            SSGRID.BringToFront()
            CmdView.Enabled = True
            CmdPrint.Enabled = True
        End If

    End Sub

    Function GRID_VIEW()
        Dim Ssql As String
        Dim vsplit() As String
        Dim Total, Debit, Credit, RowNo, I, J As Double
        Dim mtypecode(), mcodes(), mcurrentstatus(), fields, fieldsgroup(300) As String
        Dim whereorand As Boolean = False
        Total = 0
        Debit = 0
        Credit = 0

        SQLSTRING = "  SELECT ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMDESC,'') AS ITEMDESC,"
        SQLSTRING = SQLSTRING & " ISNULL(POSCODE ,'') AS POSCODE ,ISNULL(POSDESC,'') AS POSDESC,  "
        SQLSTRING = SQLSTRING & " ISNULL(GROUPCODE,'') AS GROUPCODE, ISNULL(GROUPDESC,'') AS GROUPDESC,ISNULL(UOM,'') AS UOM,ITEMRATE,ISNULL(ITEMTYPECODE,'') AS ITEMTYPECODE FROM POS_MENU_LIST"

        If LstPOS.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " WHERE POSDESC IN ("
            For I = 0 To LstPOS.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & Trim(LstPOS.CheckedItems(I)) & "', "
            Next I
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
        Else
            MsgBox("Select the location(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
            Exit Function
        End If

        'If LstGroup.CheckedItems.Count <> 0 Then
        '    SQLSTRING = SQLSTRING & " AND GROUPDESC IN ("
        '    For I = 0 To LstGroup.CheckedItems.Count - 1
        '        SQLSTRING = SQLSTRING & " '" & Trim(LstGroup.CheckedItems(I)) & "', "
        '    Next
        '    SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
        '    SQLSTRING = SQLSTRING & ")"
        'Else
        '    MsgBox("Select the Group(s)", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, MyCompanyName)
        '    Exit Function
        'End If
        If lstcategory.CheckedItems.Count <> 0 Then
            SQLSTRING = SQLSTRING & " and CATEGORY in ("
            For I = 0 To lstcategory.CheckedItems.Count - 1
                SQLSTRING = SQLSTRING & " '" & lstcategory.CheckedItems(I) & "', "
            Next
            SQLSTRING = Mid(SQLSTRING, 1, Len(SQLSTRING) - 2)
            SQLSTRING = SQLSTRING & ")"
        End If
        SQLSTRING = SQLSTRING & " AND ISNULL(GROUPCODE,'') <> ''"
        SQLSTRING = SQLSTRING & " ORDER BY ITEMCODE"

        vconn.getDataSet(SQLSTRING, "MEMBER_VIEW")
        If gdataset.Tables("MEMBER_VIEW").Rows.Count = 0 Then
            MsgBox("No Records Available ", vbInformation + vbOKOnly, "MESSAGE")
        Else
            SSGRID.Visible = True
            SSGRID.BringToFront()
            SSGRID.ClearRange(1, 1, -1, -1, True)

            With SSGRID
                .Row = 1
                .Col = 1
                .BackColor = Color.MistyRose
                .FontBold = True
                .ForeColor = Color.MediumVioletRed
                .Text = "SL NO"
                .Row = 1
                .Col = 2
                .BackColor = Color.MistyRose
                .FontBold = True
                .ForeColor = Color.MediumVioletRed
                .Text = "ITEM CODE"
                J = .Text.Length + 2
                If J > .get_ColWidth(1) Then
                    .set_ColWidth(1, J)
                End If
                .Col = 3
                .BackColor = Color.MistyRose
                .FontBold = True
                .ForeColor = Color.MediumVioletRed
                .Text = "ITEM NAME"
                J = .Text.Length + 2
                If J > .get_ColWidth(2) Then
                    .set_ColWidth(2, J)
                End If
                .Col = 4
                .BackColor = Color.MistyRose
                .FontBold = True
                .ForeColor = Color.MediumVioletRed
                .Text = "GROUP CODE"
                J = .Text.Length + 2
                If J > .get_ColWidth(3) Then
                    .set_ColWidth(3, J)
                End If
                .Col = 5
                .BackColor = Color.MistyRose
                .FontBold = True
                .ForeColor = Color.MediumVioletRed
                .Text = "GROUP DESCRIPTION"
                J = .Text.Length + 2
                If J > .get_ColWidth(4) Then
                    .set_ColWidth(4, J)
                End If
                .Col = 6
                .BackColor = Color.MistyRose
                .FontBold = True
                .ForeColor = Color.MediumVioletRed
                .Text = "POS CODE"
                J = .Text.Length + 2
                If J > .get_ColWidth(5) Then
                    .set_ColWidth(5, J)
                End If
                .Col = 7
                .BackColor = Color.MistyRose
                .FontBold = True
                .ForeColor = Color.MediumVioletRed
                .Text = "POS NAME"
                J = .Text.Length + 2
                If J > .get_ColWidth(6) Then
                    .set_ColWidth(6, J)
                End If
                .Col = 8
                .BackColor = Color.MistyRose
                .FontBold = True
                .ForeColor = Color.MediumVioletRed
                .Text = "UOM"
                J = .Text.Length + 2
                If J > .get_ColWidth(7) Then
                    .set_ColWidth(7, J)
                End If
                .Col = 9
                .BackColor = Color.MistyRose
                .FontBold = True
                .ForeColor = Color.MediumVioletRed
                .Text = "ITEM RATE"
                J = .Text.Length + 2
                If J > .get_ColWidth(7) Then
                    .set_ColWidth(8, J)
                End If
                .Col = 10
                .BackColor = Color.MistyRose
                .FontBold = True
                .ForeColor = Color.MediumVioletRed
                .Text = "TAX CODE"
                J = .Text.Length + 2
                If J > .get_ColWidth(7) Then
                    .set_ColWidth(9, J)
                End If
            End With
        End If

        For I = 0 To gdataset.Tables("MEMBER_VIEW").Rows.Count - 1
            With SSGRID
                .Row = I + 2
                .Col = 1
                .Text = CStr(I + 1)
                .Col = 2
                J = gdataset.Tables("MEMBER_VIEW").Rows(I).Item("ITEMCODE").ToString.Length + 2
                If J > .get_ColWidth(1) Then
                    .set_ColWidth(1, J)
                End If
                .Text = Trim(gdataset.Tables("MEMBER_VIEW").Rows(I).Item("ITEMCODE") & "")
                .Col = 3
                J = gdataset.Tables("MEMBER_VIEW").Rows(I).Item("ITEMDESC").ToString.Length + 2
                If J > .get_ColWidth(2) Then
                    .set_ColWidth(2, J)
                End If
                .Text = Trim(gdataset.Tables("MEMBER_VIEW").Rows(I).Item("ITEMDESC") & "")
                .Col = 4
                J = gdataset.Tables("MEMBER_VIEW").Rows(I).Item("GROUPCODE").ToString.Length + 2
                If J > .get_ColWidth(3) Then
                    .set_ColWidth(3, J)
                End If
                .Text = Trim(gdataset.Tables("MEMBER_VIEW").Rows(I).Item("GROUPCODE") & "")
                .Col = 5
                J = gdataset.Tables("MEMBER_VIEW").Rows(I).Item("GROUPDESC").ToString.Length + 2
                If J > .get_ColWidth(4) Then
                    .set_ColWidth(4, J)
                End If
                .Text = Trim(gdataset.Tables("MEMBER_VIEW").Rows(I).Item("GROUPDESC") & "")
                .Col = 6
                J = gdataset.Tables("MEMBER_VIEW").Rows(I).Item("POSCODE").ToString.Length + 2
                If J > .get_ColWidth(5) Then
                    .set_ColWidth(5, J)
                End If
                .Text = Trim(gdataset.Tables("MEMBER_VIEW").Rows(I).Item("POSCODE") & "")
                .Col = 7
                J = gdataset.Tables("MEMBER_VIEW").Rows(I).Item("POSDESC").ToString.Length + 2
                If J > .get_ColWidth(6) Then
                    .set_ColWidth(6, J)
                End If
                .Text = Trim(gdataset.Tables("MEMBER_VIEW").Rows(I).Item("POSDESC") & "")
                .Col = 8
                J = gdataset.Tables("MEMBER_VIEW").Rows(I).Item("UOM").ToString.Length + 2
                If J > .get_ColWidth(7) Then
                    .set_ColWidth(7, J)
                End If
                .Text = Trim(gdataset.Tables("MEMBER_VIEW").Rows(I).Item("UOM") & "")
                .Col = 9
                J = gdataset.Tables("MEMBER_VIEW").Rows(I).Item("ITEMRATE").ToString.Length + 2
                If J > .get_ColWidth(7) Then
                    .set_ColWidth(8, J)
                End If
                .Text = Trim(gdataset.Tables("MEMBER_VIEW").Rows(I).Item("ITEMRATE") & "")
                .Col = 10
                J = gdataset.Tables("MEMBER_VIEW").Rows(I).Item("ITEMTYPECODE").ToString.Length + 2
                If J > .get_ColWidth(7) Then
                    .set_ColWidth(9, J)
                End If
                .Text = Trim(gdataset.Tables("MEMBER_VIEW").Rows(I).Item("ITEMTYPECODE") & "")


            End With
            If SSGRID.MaxRows < I + 20 Then
                SSGRID.MaxRows = SSGRID.MaxRows + 100
            End If
        Next
        SSGRID.Focus()
        SSGRID.SetActiveCell(1, 1)
    End Function


    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        Try
            'If SSGRID.Visible = True Then
            ' Call ExportTo(SSGRID)
            ' End If
            Dim exp As New exportexcel
            Dim sqlstring, HNAME As String

            Dim Viewer As New ReportViwer
            Dim r As New CrptPOS_MENU_LIST
            Dim i As Integer
            Dim Type(1) As String

            sqlstring = "select * from POS_MENU_LIST where "
            If LstPOS.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  POSDESC IN ("
                For i = 0 To LstPOS.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & LstPOS.CheckedItems(i) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ") "
            Else
                MessageBox.Show("Select the POS Location(s)", "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            If lstcategory.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " and CATEGORY in ("
                HNAME = "("
                For i = 0 To lstcategory.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
                    HNAME = HNAME & lstcategory.CheckedItems(i) & ", "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
                HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
                HNAME = HNAME & ")"
            End If
            sqlstring = sqlstring & "ORDER BY itemcode,itemdesc"
            gconnection.getDataSet(sqlstring, "SETTLEMENTREPORT")
            If gdataset.Tables("SETTLEMENTREPORT").Rows.Count > 0 Then
                exp.Show()
                Call exp.export(sqlstring, "SETTLEMENT-DATEWISE ", "")
            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Exit Sub
            End If
            'If LstGroup.CheckedItems.Count <> 0 Then
            '    SSQL = SSQL & " AND GROUPCODE IN ("
            '    For i = 0 To LstGroup.CheckedItems.Count - 1
            '        Type = Split(LstGroup.CheckedItems(i), "-->")
            '        SSQL = SSQL & " '" & Type(1) & "', "

            '    Next
            '    SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
            '    SSQL = SSQL & ")"
            'End If

            'Call Viewer.GetDetails(sqlstring, "POS_MENU_LIST", r)
            'Viewer.TableName = "POS_MENU_LIST"
            'Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
            'TXTOBJ1.Text = gCompanyname


            'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ5 = r.ReportDefinition.ReportObjects("Text17")
            'TXTOBJ5.Text = "UserName : " & gUsername

            'Viewer.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Public Function ExportTo(ByVal ssgrid As AxFPSpreadADO.AxfpSpread)
        Try
            Dim X As Boolean
            Dim vpath As String
            Dim vLog As String
            Dim strpath As String
            vpath = Application.StartupPath & "\Reports\Monprtn"
            vLog = Application.StartupPath & "\Reports\Monprtn.Txt"
            X = ssgrid.ExportRangeToTextFile(0, 0, ssgrid.Col2, ssgrid.Row2, Application.StartupPath & "\Reports\One.txt", "", ",", vbCrLf, FPSpreadADO.ExportRangeToTextFileConstants.ExportRangeToTextFileCreateNewFile, Application.StartupPath & "\Reports\One.log")
            With ssgrid
                If Dir(vpath & ".Xls") <> "" Then
                    Kill(vpath & ".Xls")
                End If
                X = .ExportToExcel(vpath & ".Xls", "", "")
                strpath = strexcelpath & " " & vpath & ".xls"
                Call Shell(strpath, AppWinStyle.NormalFocus)
            End With
        Catch ex As Exception
            MessageBox.Show("Before Opening New EXCEL Sheet Close Previous EXCEL sheet", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function

    Private Sub frmItemwisereport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call FillPOS()
        Call FillGroup()
        FillCATEGORY()
        'lstcategory.Items.Clear()
        'lstcategory.Items.Add(Trim("CANTEEN"))
        'lstcategory.Items.Add(Trim("BAR"))
        'lstcategory.Items.Add(Trim("FACILITY"))
        grp_Salebillitemwise.Top = 1000
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub
    Private Sub FillCATEGORY()   '''***************************** To fill Group details from GroupMaster  *****************'''
        Dim sqlstring As String
        Dim gconnection As String
        lstcategory.Items.Clear()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT CATEGORY FROM ITEMMaster "
        vconn.getDataSet(sqlstring, "GroupMaster")
        If gdataset.Tables("GroupMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("GroupMaster").Rows.Count - 1
                With gdataset.Tables("GroupMaster").Rows(i)
                    lstcategory.Items.Add(Trim(.Item("CATEGORY")))
                    'chklist_Type.Items.Add(Trim(.Item("TaxDesc")) & Space(100) & "-->" & Trim(.Item("TaxCode")))
                End With
            Next
        End If
    End Sub

    Private Sub Chk_SelectAllPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Chk_SelectAllPos.KeyPress
        If Asc(e.KeyChar) = 13 Then
            LstPOS.Focus()
        End If
    End Sub

    Private Sub LstPOS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LstPOS.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Chk_SelectAllGroup.Focus()
        End If
    End Sub

    Private Sub Chk_SelectAllGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Chk_SelectAllGroup.KeyPress
        If Asc(e.KeyChar) = 13 Then
            LstGroup.Focus()
        End If
    End Sub

    Private Sub LstGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LstGroup.KeyPress
        If Asc(e.KeyChar) = 13 Then
            CmdView.Focus()
        End If
    End Sub

    Private Sub frmItemwisereport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'If e.KeyCode = Keys.F9 Then
        '    Call CmdView_Click(sender, e)
        'End If
        'If e.KeyCode = Keys.F8 Then
        '    Call CmdPrint_Click(sender, e)
        'End If
        If e.KeyCode = Keys.F12 Then
            If CmdPrint.Enabled = True Then
                Call CmdPrint_Click(sender, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            If CmdView.Enabled = True Then
                Call CMDREPORT_Click(sender, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
        End If
        If e.KeyCode = Keys.F11 Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F7 Then
            Search = InputBox("ENTER TEXT", "SEARCH")
            If LstPOS.SelectedIndex = 0 Then
                Call Search_Item(LstPOS, Search)
            ElseIf LstGroup.SelectedIndex = 0 Then
                Call Search_Item(LstGroup, Search)
            End If
        End If
    End Sub

    Private Sub Chk_SelectAllCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllCategory.CheckedChanged
        Dim i As Integer

        If Chk_SelectAllCategory.Checked = True Then
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub lstcategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstcategory.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To lstcategory.Items.Count - 1
                lstcategory.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub LstGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstGroup.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To LstGroup.Items.Count - 1
                LstGroup.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To LstGroup.Items.Count - 1
                LstGroup.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub LstPOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstPOS.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F2 Then
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, True)
            Next i
        ElseIf e.KeyCode = Keys.F3 Then
            For i = 0 To LstPOS.Items.Count - 1
                LstPOS.SetItemChecked(i, False)
            Next i
        End If
    End Sub

    Private Sub CMDREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREPORT.Click
        Dim sqlstring, HNAME As String
        Dim Viewer As New ReportViwer
        Dim r As New CrptPOS_MENU_LIST
        Dim i As Integer
        Dim Type(1) As String
     
        sqlstring = "select * from POS_MENU_LIST where "
        If LstPOS.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "  POSDESC IN ("
            For i = 0 To LstPOS.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & LstPOS.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ") "
        Else
            MessageBox.Show("Select the POS Location(s)", "Calcutta Swimming Club", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If lstcategory.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and CATEGORY in ("
            HNAME = "("
            For i = 0 To lstcategory.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & lstcategory.CheckedItems(i) & "', "
                HNAME = HNAME & lstcategory.CheckedItems(i) & ", "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
            HNAME = Mid(HNAME, 1, Len(HNAME) - 2)
            HNAME = HNAME & ")"
        End If
        'If LstGroup.CheckedItems.Count <> 0 Then
        '    SSQL = SSQL & " AND GROUPCODE IN ("
        '    For i = 0 To LstGroup.CheckedItems.Count - 1
        '        Type = Split(LstGroup.CheckedItems(i), "-->")
        '        SSQL = SSQL & " '" & Type(1) & "', "

        '    Next
        '    SSQL = Mid(SSQL, 1, Len(SSQL) - 2)
        '    SSQL = SSQL & ")"
        'End If

        Call Viewer.GetDetails(sqlstring, "POS_MENU_LIST", r)
        Viewer.TableName = "POS_MENU_LIST"
        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
        TXTOBJ1.Text = gCompanyname


        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text17")
        TXTOBJ5.Text = "UserName : " & gUsername

        Viewer.Show()
    End Sub
End Class
