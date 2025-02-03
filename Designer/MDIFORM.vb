Imports System.Windows.Forms

Public Class MDIFORM
    Dim gconnection As New GlobalClass
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub MDIFORM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub MDIFORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParentobj = Me
        CheckForIllegalCrossThreadCalls = False
        Call GetServer()

        Me.Text = "[ Party  ]  " & gCompanyname & Space(10) & "Version-2" & Space(15) & "[" & gFinancalyearStart & "-" & gFinancialYearEnd & "]" & Space(20) & "UserName:" & gUsername
       
        Call Activateuseradmin()
        Call Update_Column()

        SQLSTRING = "SELECT Isnull(BillCloseDate,'') as BillCloseDate,Isnull(PartyAccode,'') as PartyAccode FROM partysetUP "
        gconnection.getDataSet(SQLSTRING, "BILLCLOSE")
        If gdataset.Tables("BILLCLOSE").Rows.Count > 0 Then
            billclosedate = Format(gdataset.Tables("BILLCLOSE").Rows(0).Item("BillCloseDate"), "dd-MMM-yyyy")
            PartyAcccode = Trim(gdataset.Tables("BILLCLOSE").Rows(0).Item("PartyAccode"))
        Else
            PartyAcccode = ""
        End If

        Call SYS_DATE_TIME()

        If Mid(gCompName, 1, 3) = "MGC" Then
            SQLSTRING = "SELECT Isnull(Prev_DataFile,'') as Prev_DataFile FROM master..CLUBMASTER where DATAfile = '" & gDatabase & "'  "
            gconnection.getDataSet(SQLSTRING, "PrevDataFile")
            If gdataset.Tables("PrevDataFile").Rows.Count > 0 Then
                gPrevDatabase = Trim(gdataset.Tables("PrevDataFile").Rows(0).Item("Prev_DataFile"))
            Else
                gPrevDatabase = ""
            End If
        End If
        If Mid(gCompName, 1, 3) = "MGC" Then
            MenuItem21.Visible = True
        Else
            MenuItem21.Visible = False
        End If
        If Mid(gCompName, 1, 3) = "BRC" Then
            MenuItem22.Visible = True
            MenuItem23.Visible = True
        Else
            MenuItem22.Visible = False
            MenuItem23.Visible = False
        End If
        If Mid(gCompName, 1, 4) = "BBSR" Then
            MenuItem25.Visible = True
        Else
            MenuItem25.Visible = False
        End If
        If Mid(gCompName, 1, 4) = "CATH" Then
            MenuItem16.Visible = False
        Else
            MenuItem16.Visible = True
        End If
        If Mid(gCompName, 1, 4) = "KSCA" Then
            MenuItem5.Visible = False
            MenuItem20.Visible = False
            MenuItem15.Visible = False
            MenuItem26.Visible = True
        Else
            MenuItem26.Visible = False
        End If

    End Sub
    Private Sub SYS_DATE_TIME()
        Dim sqlstring As String
        Try
            sqlstring = "SELECT ISNULL(COMPNAME,'') AS COMPNAME FROM POSSETUP "
            gconnection.getDataSet(sqlstring, "CNAME")
            If gdataset.Tables("CNAME").Rows.Count > 0 Then
                gCompName = Trim(gdataset.Tables("CNAME").Rows(0).Item("COMPNAME"))
            End If

            sqlstring = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
            gconnection.getDataSet(sqlstring, "SERVERDATE")
            If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then
                serverdate = Format(gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE"), "dd-MMM-yyyy")
                If Mid(gCompName, 1, 4) = "CATH" Then
                Else
                    serverdate = DateAdd(DateInterval.Day, 1, billclosedate)
                End If
                servertime = gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERTIME")
            End If

            sqlstring = "SELECT ISNULL(BillPaymentMode,'') AS BillPaymentMode, ISNULL(roundoffyesno,'') AS BILLROUNDOFF,ISNULL(SETTLEMENT,'') AS SETTLEMENT,isnull(brlimit,0) as brlimit FROM POSSETUP"
            gconnection.getDataSet(sqlstring, "POSSETUP")
            If gdataset.Tables("POSSETUP").Rows.Count > 0 Then
                BILLROUNDYESNO = Trim(gdataset.Tables("POSSETUP").Rows(0).Item("BILLROUNDOFF"))
                BarLimit = Val(gdataset.Tables("POSSETUP").Rows(0).Item("brlimit"))
            End If
        Catch ex As Exception
            MessageBox.Show("Enter a valid datetime :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Update_Column()
        Dim sqlstring As String
        Try
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PARTY_CANCELLATIONMASTER' AND  COLUMN_NAME = 'HallCode') Begin ALTER TABLE PARTY_CANCELLATIONMASTER ADD HallCode VARCHAR(20) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PARTY_CANCELLATIONMASTER' AND  COLUMN_NAME = 'CanBefore') Begin ALTER TABLE PARTY_CANCELLATIONMASTER ADD CanBefore Numeric(18,0) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'partysetUP' AND  COLUMN_NAME = 'BillCloseDate') Begin ALTER TABLE partysetUP ADD BillCloseDate Datetime End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Party_OtherChgsMaster' AND  COLUMN_NAME = 'GLACCODE') Begin ALTER TABLE Party_OtherChgsMaster ADD GLACCODE VARCHAR(20) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'party_tariffhdr' AND  COLUMN_NAME = 'SUBGLACCODE') Begin ALTER TABLE party_tariffhdr ADD SUBGLACCODE VARCHAR(15) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PARTY_HALLMASTER_HDR' AND  COLUMN_NAME = 'SUBGLACCODE') Begin ALTER TABLE PARTY_HALLMASTER_HDR ADD SUBGLACCODE VARCHAR(15) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PARTY_ITEMMASTER' AND  COLUMN_NAME = 'SUBGLACCODE') Begin ALTER TABLE PARTY_ITEMMASTER ADD SUBGLACCODE VARCHAR(15) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Party_OtherChgsMaster' AND  COLUMN_NAME = 'SUBGLACCODE') Begin ALTER TABLE Party_OtherChgsMaster ADD SUBGLACCODE VARCHAR(15) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'party_tariffhdr' AND  COLUMN_NAME = 'COSTCODE') Begin ALTER TABLE party_tariffhdr ADD COSTCODE VARCHAR(30) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PARTY_HALLMASTER_HDR' AND  COLUMN_NAME = 'COSTCODE') Begin ALTER TABLE PARTY_HALLMASTER_HDR ADD COSTCODE VARCHAR(30) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PARTY_ITEMMASTER' AND  COLUMN_NAME = 'COSTCODE') Begin ALTER TABLE PARTY_ITEMMASTER ADD COSTCODE VARCHAR(30) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Party_OtherChgsMaster' AND  COLUMN_NAME = 'COSTCODE') Begin ALTER TABLE Party_OtherChgsMaster ADD COSTCODE VARCHAR(30) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PARTY_ACC_POST' AND  COLUMN_NAME = 'COSTCODE') Begin ALTER TABLE PARTY_ACC_POST ADD COSTCODE VARCHAR(30) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Party_Hallbooking_Hdr' AND  COLUMN_NAME = 'Menu_Type') Begin ALTER TABLE Party_Hallbooking_Hdr ADD Menu_Type VARCHAR(30) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'partysetUP' AND  COLUMN_NAME = 'NonStandRate') Begin ALTER TABLE partysetUP ADD NonStandRate NUMERIC(18,2) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'partysetUP' AND  COLUMN_NAME = 'NonStandRateWEnd') Begin ALTER TABLE partysetUP ADD NonStandRateWEnd NUMERIC(18,2) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "UPDATE Party_Hallbooking_Hdr SET Menu_Type = 'Standard' WHERE ISNULL(Menu_Type,'') = ''"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Party_Hallmaster_Hdr' AND  COLUMN_NAME = 'NonStandRate') Begin ALTER TABLE Party_Hallmaster_Hdr ADD NonStandRate NUMERIC(18,2) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Party_Hallmaster_Hdr' AND  COLUMN_NAME = 'NonStandRateWEnd') Begin ALTER TABLE Party_Hallmaster_Hdr ADD NonStandRateWEnd NUMERIC(18,2) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Party_Hallbooking_Det' AND  COLUMN_NAME = 'Extra_Hour') Begin ALTER TABLE Party_Hallbooking_Det ADD Extra_Hour NUMERIC(18,0) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Party_Hallbooking_Det' AND  COLUMN_NAME = 'CLSTIME') Begin ALTER TABLE Party_Hallbooking_Det ADD CLSTIME Varchar(5) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PARTY_HDR' AND  COLUMN_NAME = 'OvrallDiscount') Begin ALTER TABLE PARTY_HDR ADD OvrallDiscount NUMERIC(18,2) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "SELECT * FROM SYSOBJECTS WHERE name = 'Party_Trn_HallBlocking'"
            gconnection.getDataSet(sqlstring, "ExtTab1")
            If gdataset.Tables("ExtTab1").Rows.Count = 0 Then
                sqlstring = "CREATE TABLE [dbo].[Party_Trn_HallBlocking]([HallCode] [varchar](20) NULL,[FromDate] [datetime] NULL,[ToDate] [datetime] NULL,[Trans_Date] [datetime] NULL,[BlockType] [varchar](2) NULL,[AddUser] [varchar](50) NULL,[AddDate] [datetime] NULL) "
                gconnection.dataOperation(6, sqlstring, "AddC")
            End If

            sqlstring = "SELECT * FROM Party_OtherChgsMaster Where Itemcode = 'EHC'"
            gconnection.getDataSet(sqlstring, "ExtTab1")
            If gdataset.Tables("ExtTab1").Rows.Count = 0 Then
                sqlstring = "INSERT INTO Party_OtherChgsMaster(ITEMCODE,ITEMDESC,AmtOverride,rate,ChargeCode,FREEZE,Adduser,Adddate) VALUES ('EHC','Extra Hours Chages','Y',1,'','N','CHS','') "
                gconnection.dataOperation(6, sqlstring, "AddC")
            End If

            sqlstring = "SELECT * FROM SYSOBJECTS WHERE name = 'Party_RateMaster'"
            gconnection.getDataSet(sqlstring, "ExtTab1")
            If gdataset.Tables("ExtTab1").Rows.Count = 0 Then
                sqlstring = "Create Table Party_RateMaster(HallCode Varchar(25),FromSlab Numeric(18,2),ToSlab Numeric(18,2),FromDate DateTime,ToDate DateTime,ChargeCode Varchar(15),Freeze Varchar(5),Adduser Varchar(50),AddDate Datetime) "
                gconnection.dataOperation(6, sqlstring, "AddC")
            End If

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Party_Hallmaster_Hdr' AND  COLUMN_NAME = 'MG_Amount') Begin ALTER TABLE Party_Hallmaster_Hdr ADD MG_Amount NUMERIC(18,2) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Party_Hallmaster_Hdr' AND  COLUMN_NAME = 'MG_TaxType') Begin ALTER TABLE Party_Hallmaster_Hdr ADD MG_TaxType Varchar(15) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "SELECT * FROM Party_OtherChgsMaster Where Itemcode = 'MGA'"
            gconnection.getDataSet(sqlstring, "ExtTab1")
            If gdataset.Tables("ExtTab1").Rows.Count = 0 Then
                sqlstring = "INSERT INTO Party_OtherChgsMaster(ITEMCODE,ITEMDESC,AmtOverride,rate,ChargeCode,FREEZE,Adduser,Adddate) VALUES ('MGA','Mininum Guarantee Amount','Y',1,'','N','CHS','') "
                gconnection.dataOperation(6, sqlstring, "AddC")
            End If

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PARTY_HDR' AND  COLUMN_NAME = 'NBillNo') Begin ALTER TABLE PARTY_HDR ADD NBillNo Varchar(20) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PARTY_HALLBOOKING_HDR' AND  COLUMN_NAME = 'GGSTINNO') Begin ALTER TABLE PARTY_HALLBOOKING_HDR ADD GGSTINNO Varchar(30) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'partysetUP' AND  COLUMN_NAME = 'PartyAccode') Begin ALTER TABLE partysetUP ADD PartyAccode Varchar(20) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'party_receipt_Det' AND  COLUMN_NAME = 'RType') Begin ALTER TABLE party_receipt_Det ADD RType Varchar(10) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

        Catch ex As Exception
            MessageBox.Show("Enter a valid datetime :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub GetServer()
        Dim ServerConn As New OleDb.OleDbConnection
        Dim servercmd As New OleDb.OleDbDataAdapter
        Dim getserver As New DataSet
        Dim sql, ssql As String
        AppPath = Application.StartupPath
        sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
        sql = sql & AppPath & "\DBS_KEY.MDB"
        ServerConn.ConnectionString = sql
        Try
            ServerConn.Open()
            ssql = "SELECT SERVER, UserName, Password, Company_ID,DATABASE FROM DBSKEY"
            servercmd = New OleDb.OleDbDataAdapter(ssql, ServerConn)
            servercmd.Fill(getserver)
            If getserver.Tables(0).Rows.Count > 0 Then
                gserver = Trim(getserver.Tables(0).Rows(0).Item(0) & "")
                strDataSqlUsr = Trim(getserver.Tables(0).Rows(0).Item(1) & "")
                strDataSqlPwd = Trim(getserver.Tables(0).Rows(0).Item(2) & "")
                strCompany_ID = Trim(getserver.Tables(0).Rows(0).Item(3) & "")
                gDatabase = Trim(getserver.Tables(0).Rows(0).Item(4) & "")
            Else
                MessageBox.Show("Failed to connect to Data Source")
                'Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to connect to data source")
            MsgBox(ex.Message)
        Finally
            ServerConn.Close()
        End Try
    End Sub
    Private Sub Activateuseradmin()
        Dim totmenu As Integer = 0
        Dim i, j, k, ckhmn, ckhmn1 As Integer
        Call menublock()
        For i = 0 To Me.Menu.MenuItems.Count - 2
            ckhmn1 = Me.Menu.MenuItems(i).MenuItems.Count()

            If ckhmn1 <> 0 Then
                For j = 0 To Me.Menu.MenuItems(i).MenuItems.Count() - 1
                    ckhmn = Me.Menu.MenuItems(i).MenuItems(j).MenuItems.Count()
                    If ckhmn <> 0 Then
                        For k = 0 To Me.Menu.MenuItems(i).MenuItems(j).MenuItems.Count() - 1
                            totmenu = totmenu + 1
                        Next
                    Else
                        totmenu = totmenu + 1
                    End If
                Next
            Else
                totmenu = totmenu + 1
            End If
        Next
        gconnection.getDataSet("SELECT COUNT(*) FROM  modulemaster WHERE PackageName='SPECIALPARTY'", "chk")
        If gdataset.Tables("chk").Rows.Count <> totmenu Then
            gconnection.ExcuteStoreProcedure("DELETE FROM modulemaster WHERE PackageName='SPECIALPARTY'")
            Call checkmenulist()
        End If
        If gUserCategory = "S" Or gUserCategory = "A" Then
            Call menuclear()
        Else
            Call relemenu()
        End If
    End Sub
    Sub menuclear()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        vmain = Me.Menu.MenuItems.Count.ToString
        For i = 0 To vmain - 2
            vsmod = Me.Menu.MenuItems(i).MenuItems.Count
            If vsmod <> 0 Then
                For j = 0 To vsmod - 1
                    vssmod = Me.Menu.MenuItems(i).MenuItems(j).MenuItems.Count
                    If vssmod <> 0 Then
                        For k = 0 To vssmod - 1
                            Me.Menu.MenuItems(i).MenuItems(j).MenuItems(k).Enabled = True
                        Next
                    Else
                        Me.Menu.MenuItems(i).MenuItems(j).Enabled = True
                    End If
                Next
            Else
                Me.Menu.MenuItems(i).Enabled = True
            End If
        Next
    End Sub
    Sub menublock()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        vmain = Me.Menu.MenuItems.Count
        For i = 0 To vmain - 2
            vsmod = Me.Menu.MenuItems(i).MenuItems.Count
            If vsmod <> 0 Then
                For j = 0 To vsmod - 1
                    vssmod = Me.Menu.MenuItems(i).MenuItems(j).MenuItems.Count
                    If vssmod <> 0 Then
                        For k = 0 To vssmod - 1
                            Me.Menu.MenuItems(i).MenuItems(j).MenuItems(k).Enabled = False
                        Next
                    Else
                        Me.Menu.MenuItems(i).MenuItems(j).Enabled = False
                    End If
                Next
            Else
                Me.Menu.MenuItems(i).Enabled = False
            End If
        Next
    End Sub
    Sub relemenu1()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql As String
        Dim ds As New DataSet
        Dim chstr As String
        gconnection.getDataSet("SELECT * FROM USERADMIN WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY'", "user")
        If gdataset.Tables("user").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("user").Rows.Count - 1
                With gdataset.Tables("user").Rows(i)
                    If Trim(gdataset.Tables("user").Rows(i).Item("mainmoduleid") & "") <> "" And Trim(.Item("submoduleid") & "") <> "" And Trim(.Item("ssubmoduleid") & "") <> "" Then
                        Me.Menu.MenuItems(.Item("mainmoduleid")).MenuItems(Val(.Item("submoduleid"))).MenuItems(Val(.Item("ssubmoduleid"))).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    ElseIf Trim(gdataset.Tables("user").Rows(i).Item("mainmoduleid") & "") <> "" And Trim(gdataset.Tables("user").Rows(i).Item("submoduleid") & "") <> "" Then
                        Me.Menu.MenuItems(gdataset.Tables("user").Rows(i).Item("mainmoduleid")).MenuItems(Val(gdataset.Tables("user").Rows(i).Item("submoduleid"))).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    ElseIf Trim(.Item("mainmoduleid") & "") <> "" Then
                        Me.Menu.MenuItems(.Item("mainmoduleid")).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    End If
                End With
            Next
        End If
    End Sub
    Sub relemenu()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql As String
        Dim ds As New DataSet
        Dim chstr As String
        Dim a As Integer
        Dim b As Integer
        Dim c As Integer
        gconnection.getDataSet("SELECT * FROM USERADMIN WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY'", "user")
        If gdataset.Tables("user").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("user").Rows.Count - 1
                With gdataset.Tables("user").Rows(i)
                    If Trim(.Item("mainmoduleid") & "") <> "" And Trim(.Item("submoduleid") & "") <> "" And Trim(.Item("ssubmoduleid") & "") <> "" Then
                        a = .Item("mainmoduleid")
                        b = Val(.Item("submoduleid"))
                        c = Val(.Item("ssubmoduleid"))
                        Menu.MenuItems(a).MenuItems(b).MenuItems(c).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    ElseIf Trim(.Item("mainmoduleid") & "") <> "" And Trim(.Item("submoduleid") & "") <> "" Then
                        a = gdataset.Tables("user").Rows(i).Item("mainmoduleid")
                        b = Val(gdataset.Tables("user").Rows(i).Item("submoduleid"))
                        Menu.MenuItems(a).MenuItems(b).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    ElseIf Trim(.Item("mainmoduleid") & "") <> "" Then
                        Menu.MenuItems((.Item("mainmoduleid"))).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    End If
                End With
            Next
        End If
    End Sub
    Public Sub checkmenulist()
        Dim i, j, k, x As Integer
        Dim vsql() As String
        Dim vmain, vsmod, vssmod As Long
        x = 0
        ReDim vsql(x)
        vmain = Me.Menu.MenuItems.Count
        If vmain <> 0 Then
            For i = 0 To vmain - 2
                vsmod = Me.Menu.MenuItems(i).MenuItems.Count
                If vsmod <> 0 Then
                    For j = 0 To vsmod - 1
                        vssmod = Me.Menu.MenuItems(i).MenuItems(j).MenuItems.Count
                        If vssmod <> 0 Then
                            For k = 0 To vssmod - 1
                                If Me.Menu.MenuItems(i).MenuItems(j).MenuItems(k).Visible = True Then
                                    vsql(vsql.Length - 1) = "insert into Modulemaster(Mainmoduleid,MainModulename,SubModuleid,SubModulename,SsubModuleid,SsubModuleName,PackageName) values "
                                    vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & " ('" & i & "','" & Trim(Me.Menu.MenuItems(i).Text.Replace("&", "") & "") & "',"
                                    vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'" & j & "','" & Trim(Me.Menu.MenuItems(i).MenuItems(j).Text.Replace("&", "") & "") & "',"
                                    vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'" & k & "','" & Trim(Me.Menu.MenuItems(i).MenuItems(j).MenuItems(k).Text.Replace("&", "") & "") & "','SPECIALPARTY')"
                                    ReDim Preserve vsql(vsql.Length)
                                End If
                            Next
                        Else
                            If Me.Menu.MenuItems(i).MenuItems(j).Visible = True Then
                                vsql(vsql.Length - 1) = "insert into Modulemaster(Mainmoduleid,MainModulename,SubModuleid,SubModulename,SsubModuleid,SsubModuleName,PackageName ) values "
                                vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & " ('" & i & "','" & Trim(Me.Menu.MenuItems(i).Text.Replace("&", "") & "") & "',"
                                vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'" & j & "','" & Trim(Me.Menu.MenuItems(i).MenuItems(j).Text.Replace("&", "") & "") & "',"
                                vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'','','SPECIALPARTY')"
                                ReDim Preserve vsql(vsql.Length)
                            End If
                        End If
                    Next
                Else
                    If Me.Menu.MenuItems(i).Visible = True Then
                        vsql(vsql.Length - 1) = "insert into Modulemaster(Mainmoduleid,MainModulename,SubModuleid,SubModulename,SsubModuleid,SsubModuleName,PackageName) values "
                        vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & " ('" & i & "','" & Trim(Me.Menu.MenuItems(i).Text.Replace("&", "") & "") & "',"
                        vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'','',"
                        vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'','','SPECIALPARTY')"
                        ReDim Preserve vsql(vsql.Length)
                    End If
                End If
            Next
            ReDim Preserve vsql(vsql.Length - 2)
            gconnection.MoreTrans1(vsql)
        End If
    End Sub

    Private Sub MenuItem2_Click(sender As Object, e As EventArgs) Handles MenuItem2.Click
        GmoduleName = "HALL MASTER"
        Try
            Dim SMPS As New Frm_M_HallMaster
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem40_Click(sender As Object, e As EventArgs) Handles MenuItem40.Click
        Application.Exit()
    End Sub

    Private Sub MenuItem3_Click(sender As Object, e As EventArgs) Handles MenuItem3.Click
        GmoduleName = "BANQUET RESERVATION"
        Try
            Dim SMPS As New Frm_T_HallRervation
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem4_Click(sender As Object, e As EventArgs) Handles MenuItem4.Click
        GmoduleName = "BANQUET RECEIPT"
        Try
            If Mid(gCompName, 1, 3) = "HSR" Then
                Dim SMPS As New Receiptentry_HSR
                SMPS.Show()
                SMPS.MdiParent = Me
            Else
                Dim SMPS As New Frm_T_BanReceipt
                SMPS.Show()
                SMPS.MdiParent = Me
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem5_Click(sender As Object, e As EventArgs) Handles MenuItem5.Click
        GmoduleName = "BANQUET MENU BOOKING"
        Try
            Dim SMPS As New Frm_T_BanMenuBooking
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem6_Click(sender As Object, e As EventArgs) Handles MenuItem6.Click
        GmoduleName = "BANQUET MENU BILLING"
        Try
            Dim SMPS As New Frm_T_BanMenuBilling
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem7_Click(sender As Object, e As EventArgs) Handles MenuItem7.Click
        GmoduleName = "Banquet Availablity List"
        Try
            Dim SMPS As New HALLAVAILABLITY
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem8_Click(sender As Object, e As EventArgs) Handles MenuItem8.Click
        GmoduleName = "Banquet Bill Details"
        Try
            Dim SMPS As New ReceiptRegister
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem9_Click(sender As Object, e As EventArgs) Handles MenuItem9.Click
        GmoduleName = "Banquet Reservation Details"
        Try
            Dim SMPS As New RESERVATION
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem10_Click(sender As Object, e As EventArgs) Handles MenuItem10.Click
        GmoduleName = "Banquet Itemwise Sales"
        Try
            Dim SMPS As New ITEMSALES
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem11_Click(sender As Object, e As EventArgs) Handles MenuItem11.Click
        GmoduleName = "MENU MASTER"
        Try
            Dim SMPS As New FRM_BanMenuMaster
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem12_Click(sender As Object, e As EventArgs) Handles MenuItem12.Click
        GmoduleName = "RECEIPT HEAD MASTER"
        Try
            Dim SMPS As New Frm_HeadReceiptMaster
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem13_Click(sender As Object, e As EventArgs) Handles MenuItem13.Click
        GmoduleName = "ARRANGEMENT ITEM MASTER"
        Try
            Dim SMPS As New Frm_ArrangementMaster
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem14_Click(sender As Object, e As EventArgs) Handles MenuItem14.Click
        GmoduleName = "OTHER CHARGE MASTER"
        Try
            Dim SMPS As New Frm_OtherChargeMaster
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem15_Click(sender As Object, e As EventArgs) Handles MenuItem15.Click
        GmoduleName = "BANQUET BLOCKING"
        Try
            Dim SMPS As New Frm_T_BanBlocking
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem16_Click(sender As Object, e As EventArgs) Handles MenuItem16.Click
        GmoduleName = "BANQUET BILL CLOSING"
        Try
            Dim SMPS As New Frm_BillClosing
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem17_Click(sender As Object, e As EventArgs) Handles MenuItem17.Click
        GmoduleName = "BANQUET ACCOUNT TAGGING"
        Try
            Dim SMPS As New AccountItemTagging
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem18_Click(sender As Object, e As EventArgs) Handles MenuItem18.Click
        GmoduleName = "BANQUET AUDIT TRAIL"
        Try
            Dim SMPS As New SM_AUDITTRAIL
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem19_Click(sender As Object, e As EventArgs) Handles MenuItem19.Click
        GmoduleName = "SETUP"
        Try
            Dim SMPS As New Frm_PartySetup
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem20_Click(sender As Object, e As EventArgs) Handles MenuItem20.Click
        GmoduleName = "BANQUET CLOSING TIME"
        Try
            Dim SMPS As New Frm_T_HallClosingTime
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem21_Click(sender As Object, e As EventArgs) Handles MenuItem21.Click
        GmoduleName = "Banquet Reconcilliation"
        Try
            Dim SMPS As New Frm_Party_Recon
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem22_Click(sender As Object, e As EventArgs) Handles MenuItem22.Click
        GmoduleName = "BANQUET OTHER ENTRY"
        Try
            Dim SMPS As New Frm_OtherEntry
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem23_Click(sender As Object, e As EventArgs) Handles MenuItem23.Click
        GmoduleName = "Banquet Get Together Report"
        Try
            Dim SMPS As New Frm_Party_Recon_BRC
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem25_Click(sender As Object, e As EventArgs) Handles MenuItem25.Click
        GmoduleName = "RECEIPT UPDATE"
        Try
            Dim SMPS As New Frm_ReceiptUpdate
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItem26_Click(sender As Object, e As EventArgs) Handles MenuItem26.Click
        GmoduleName = "Banquet Abstract Report"
        Try
            Dim SMPS As New Frm_Party_Abstract_KSCA
            SMPS.Show()
            SMPS.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
