Imports System.Data.SqlClient
Imports System.IO
Public Class FRM_TKGA_SmartKotEntry
    Dim strPhotoFilePath As String
    Public foto As New GlobalClass
    Dim dd, serverdate As DateTime
    Dim POScode, gDocType As String
    Public STRPOSCODE, DOCTYPE, MainCode, lastpaymode As String
    Public PACKINGPERCENT, TIPSPERCENT As Double
    Dim boolchk As Boolean
    Dim LoadCount As Integer
    Public vseqno As Double
    Dim Sql, STran(0), PrintFlag, strBatchNo, strAccountDesc, strAccountIn, strSlDesc, strBillno, strSaleCostAccountIn, strPackCostAccountIn, strSaleCostAccountInDesc, strPackCostAccountInDesc As String
    Dim itembool, chkbool, smartcardbool, boolPromotional As Boolean
    Dim TotalItemCount As Integer
    Dim gconnection As New GlobalClass
    Dim vsearch, vitem, accountcode, KOTno(), loccode, stosql, servicelocation As String
    Dim BillNontaxamount, BillNontotalamount, Billtaxamount, Billtotalamount, MemberOutstand As Double
    Dim duplicateflag As Boolean = False
    Dim crstopmsg As String
    Dim Billroundoff As Double
    Dim SQLSTRING, StrSql As String
    Public BALANCE_HDR As Double
    Public MIN_USAGE_BALANCE_HDR As Double
    Dim count As Integer = 1
    Dim GADDDATETIME As Date
    Dim real, real1 As Double
    Dim GrdRate, GrdAmount, GrdTaxAmt As Double
    Dim CrLimit, CrLimitAmt As Double

    Private Sub FRM_TKGA_SmartKotEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F2 Then
            txt_KOTno.Text = ""
            txt_KOTno.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            If Cmd_Delete.Enabled = True Then
                Call Cmd_Delete_Click(Cmd_Delete, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F7 Then
            If Cmd_Add.Enabled = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            If Cmd_View.Enabled = True Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F10 Then
            If Cmd_Print.Enabled = True Then
                Call Cmd_Print_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F11 Then
            Call Cmd_Exit_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F12 Then
            Call Cmd_Export_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.Escape Then
            If pnl_POSCode.Top = 50 Then
                pnl_POSCode.Top = 1000
                sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                Exit Sub
            ElseIf pnl_UOMCode.Top = 50 Then
                pnl_UOMCode.Top = 1000
                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                Exit Sub
            Else
                Call Cmd_Exit_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.Alt = True And e.KeyCode = Keys.K Then
            Me.Txt_Remarks.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.S Then
            Me.txt_ServerCode.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.B Then
            Me.txt_MemberCode.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.P Then
            Me.cbo_PaymentMode.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.G Then
            Me.sSGrid.Focus()
            Me.sSGrid.SetActiveCell(1, 1)
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.T Then
            Me.txt_TableNo.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.C Then
            Me.txt_Cover.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.L Then
            Me.CMB_BTYPE.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.D Then
            Me.dtp_KOTdate.Focus()
            Exit Sub
        ElseIf e.Control = True And e.KeyCode = Keys.F Then
            GmoduleName = "Final Billing"
            Try
                SQLSTRING = "SELECT ISNULL(centralizedkot,'N') AS CENTRALIZEDKOT,ISNULL(FINALPREFIX,'') AS FINALPREFIX,ISNULL(KOTTYPE,'') AS KOTTYPE FROM POSSETUP"
                gconnection.getDataSet(SQLSTRING, "CEN_CHECK")
                If gdataset.Tables("CEN_CHECK").Rows.Count > 0 Then
                    If Mid(gdataset.Tables("CEN_CHECK").Rows(0).Item(0), 1, 1) = "Y" Then
                        SQLSTRING = "SELECT ISNULL(PACKINGPERCENT,0) AS PACKPER,ISNULL(TIPS,0) AS TIPS_SER,ISNULL(ADCHARGE,0) AS ADCHARGE,ISNULL(PRCHARGE,0) AS PRCHARGE,ISNULL(GRCHARGE,0) AS GRCHARGE,ISNULL(KOTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(FINALPREFIX,'') AS FINALPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ,ISNULL(WAITREQR,'') AS WAITREQR FROM POSSETUP"
                        gconnection.getDataSet(SQLSTRING, "POSSETUP")
                        If gdataset.Tables("POSSETUP").Rows.Count > 0 Then
                            gTableReq = gdataset.Tables("POSSETUP").Rows(0).Item("TABLEREQ")
                            gWaiterReq = gdataset.Tables("POSSETUP").Rows(0).Item("WAITREQR")
                            gKotType = gdataset.Tables("POSSETUP").Rows(0).Item("KOTTYPE")
                            gKotPrefix = gdataset.Tables("POSSETUP").Rows(0).Item("FINALPREFIX")
                            DefaultPayment = gdataset.Tables("POSSETUP").Rows(0).Item("PAYMENTMODE")
                        End If
                        If Trim(gdataset.Tables("CEN_CHECK").Rows(0).Item(2)) = "AUTO" Then
                            gKotType = "A"
                        Else
                            gKotType = "M"
                        End If
                        gCenterlized = "Y"
                        Dim SMPS As New FRM_TKGA_FinalBilling("", Trim(gdataset.Tables("CEN_CHECK").Rows(0).Item(1)))
                        SMPS.Show()
                        SMPS.MdiParent = MDIParentobj
                    ElseIf Mid(gdataset.Tables("CEN_CHECK").Rows(0).Item(0), 1, 1) = "N" Then
                        gCenterlized = "N"
                        GmoduleName = "Final Billing"
                        Dim DOCSelection As New DOCSelection("FINAL BILLING")
                        DOCSelection.FormBorderStyle = FormBorderStyle.FixedDialog
                        DOCSelection.MdiParent = MDIParentobj
                        DOCSelection.Show()
                    End If
                    Me.Close()
                Else
                    MessageBox.Show("Pos Setup Not Done Pleaze Check")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FRM_TKGA_SmartKotEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim LastDoctype As String
        gDocType = DOCTYPE
        LastDoctype = DOCTYPE
        Timer1.Enabled = False
        LoadCount = 0
        bselect = False
        If gCenterlized = "N" Then
            StrSql = "SELECT ISNULL(PACKINGPERCENT,0) AS PACKPER,ISNULL(TIPS,0) AS TIPS_SER,ISNULL(ADCHARGE,0) AS ADCHARGE,ISNULL(PRCHARGE,0) AS PRCHARGE,ISNULL(GRCHARGE,0) AS GRCHARGE,ISNULL(KOTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(KOTPREFIX,'') AS KOTPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ FROM POSMASTER  WHERE POSCODE = '" & STRPOSCODE & "'"
            gconnection.getDataSet(StrSql, "PSETUP")
            If gdataset.Tables("PSETUP").Rows.Count > 0 Then
                pPackPer = gdataset.Tables("PSETUP").Rows(0).Item("PACKPER")
                pTipsPer = gdataset.Tables("PSETUP").Rows(0).Item("TIPS_SER")
                pAdCgsPer = gdataset.Tables("PSETUP").Rows(0).Item("ADCHARGE")
                pPartyPer = gdataset.Tables("PSETUP").Rows(0).Item("PRCHARGE")
                pRoomPer = gdataset.Tables("PSETUP").Rows(0).Item("GRCHARGE")
                pTableReq = gdataset.Tables("PSETUP").Rows(0).Item("TABLEREQ")
                pKotType = gdataset.Tables("PSETUP").Rows(0).Item("KOTTYPE")
                pKotPrefix = gdataset.Tables("PSETUP").Rows(0).Item("KOTPREFIX")
                DefaultPayment = gdataset.Tables("PSETUP").Rows(0).Item("PAYMENTMODE")
            End If
        End If
        StrSql = "SELECT ISNULL(PACKINGPERCENT,0) AS PACKPER,ISNULL(TIPS,0) AS TIPS_SER,ISNULL(ADCHARGE,0) AS ADCHARGE,ISNULL(PRCHARGE,0) AS PRCHARGE,ISNULL(GRCHARGE,0) AS GRCHARGE,ISNULL(KOTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(KOTPREFIX,'') AS KOTPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ FROM POSMASTER  WHERE POSCODE = '" & STRPOSCODE & "'"
        gconnection.getDataSet(StrSql, "PSETUP")
        If gdataset.Tables("PSETUP").Rows.Count > 0 Then
            pPackPer = gdataset.Tables("PSETUP").Rows(0).Item("PACKPER")
            pTipsPer = gdataset.Tables("PSETUP").Rows(0).Item("TIPS_SER")
            pAdCgsPer = gdataset.Tables("PSETUP").Rows(0).Item("ADCHARGE")
            pPartyPer = gdataset.Tables("PSETUP").Rows(0).Item("PRCHARGE")
            pRoomPer = gdataset.Tables("PSETUP").Rows(0).Item("GRCHARGE")
        End If
        StrSql = "SELECT ISNULL(KOTGOLFAPP,'NO') AS KOTGOLFAPP FROM POSSETUP"
        gconnection.getDataSet(StrSql, "PGSETUP")
        If gdataset.Tables("PGSETUP").Rows.Count > 0 Then
            If gdataset.Tables("PGSETUP").Rows(0).Item("KOTGOLFAPP") = "YES" Then
                GolfRegApp = "Y"
            Else
                GolfRegApp = "N"
            End If
        End If

        Call fillPayment_Mode()
        'Call FillDefaultPayment()
        Call Enabledcontrol()
        Call ShowBillno()
        Call GRIDLOCK()
        Call fillposdocument()
        If gCenterlized = "Y" And Mid(gKotType, 1, 1) = "A" Then
            Call Autogenerate()
        ElseIf gCenterlized = "N" And Mid(pKotType, 1, 1) = "A" Then
            Call Autogenerate()
            CMB_BTYPE.SelectedItem = DOCTYPE
        ElseIf gCenterlized = "Y" And Mid(gKotType, 1, 1) = "M" Then
            txt_KOTno.Text = ""
        End If
        If GolfRegApp = "Y" Then
            Lbl_GolfRegNo.Visible = True
            Txt_GolfRegNo.Visible = True
            Cmd_GolfRegNoHelp.Visible = True
        Else
            Lbl_GolfRegNo.Visible = False
            Txt_GolfRegNo.Visible = False
            Cmd_GolfRegNoHelp.Visible = False
        End If
        'txt_LOCATIONCODE.Text = STRPOSCODE
        itembool = False
        pnl_POSCode.Top = 1000
        pnl_UOMCode.Top = 1000
        KOT_Timer.Enabled = True
        KOT_Timer.Interval = 100
        kotentrybool = True
        ordertype = ""
        Dim ssqqll As String
        ssqqll = "SELECT  ISNULL(ACCESS_CHECK,'N') AS ACCESS_CHECK FROM SM_ACCESSCONTROL_MASTER"
        gconnection.getDataSet(ssqqll, "SM_ACCESSCONTROL_MASTER")
        If gdataset.Tables("SM_ACCESSCONTROL_MASTER").Rows.Count > 0 Then
            If Trim(gdataset.Tables("SM_ACCESSCONTROL_MASTER").Rows(0).Item("ACCESS_CHECK")) = "Y" Then
                ACCESS_CHECK_GBL = True
            Else
                ACCESS_CHECK_GBL = False
            End If
        Else
            ACCESS_CHECK_GBL = False
        End If
        txt_MemberName.ReadOnly = False
        txt_ServerName.ReadOnly = False
        'txt_TotalValue.ReadOnly = True
        'txt_TaxValue.ReadOnly = True
        'txt_BillAmount.ReadOnly = True
        sSGrid.ClearRange(1, 1, -1, -1, True)
        Me.cmd_KOTnoHelp.Enabled = True
        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        '
        txt_TableNo.Focus()
        Show()
        'txt_KOTno.Focus()

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Lbl_PartyBookingNo.Visible = False
        Txt_PartyBookingNo.Visible = False
        Txt_PartyBookingNo.Text = ""
        Call SetDateTime()
        Call SYS_DATE_TIME()
        Show()
        Pic_Member.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
        'If gCompanyname = "THE TNCA CLUB" Then
        '    txt_TableNo.Focus()
        '    txt_TableNo.Visible = True
        '    lbl_Tableno.Visible = True
        'Else
        '    txt_TableNo.Visible = False
        '    cbo_PaymentMode.Focus()
        '    lbl_Tableno.Visible = False
        'End If
        'If UCase(gCompanyname) = "CATHOLIC CLUB" Then
        '    lbl_Remarks.Visible = False
        '    Me.Txt_Remarks.Visible = False
        'End If
        'Call HideCol()
        If Mid(gWaiterReq, 1, 1) = "Y" Then
            txt_ServerCode.ReadOnly = False
            txt_ServerName.ReadOnly = False
            cmd_ServerCodeHelp.Enabled = True
        Else
            txt_ServerCode.ReadOnly = True
            txt_ServerName.ReadOnly = True
            cmd_ServerCodeHelp.Enabled = False
            Me.CMB_BTYPE.Focus()
        End If
        If gCenterlized = "Y" Then
            If Mid(gTableReq, 1, 1) = "Y" Then
                txt_TableNo.ReadOnly = False
                cmd_TablenoHelp.Enabled = True
                txt_TableNo.Focus()
            Else
                txt_TableNo.ReadOnly = True
                cmd_TablenoHelp.Enabled = False
                Me.CMB_BTYPE.Focus()
            End If
        Else
            If Mid(pTableReq, 1, 1) = "Y" Then
                txt_TableNo.ReadOnly = False
                cmd_TablenoHelp.Enabled = True
                txt_TableNo.Focus()
            Else
                txt_TableNo.ReadOnly = True
                cmd_TablenoHelp.Enabled = False
                Me.CMB_BTYPE.Focus()
            End If
        End If
        If gCenterlized = "Y" And Mid(gKotType, 1, 1) = "A" Then
        ElseIf gCenterlized = "N" And Mid(pKotType, 1, 1) = "A" Then
            CMB_BTYPE.SelectedItem = LastDoctype
        ElseIf gCenterlized = "Y" And Mid(gKotType, 1, 1) = "M" Then

        End If
        'Call cmd_Clear_Click(sender, e)
    End Sub
    Private Sub fillposdocument()
        Dim sqlstring As String
        Dim index As Integer
        Dim i As Integer
        Try
            If gUserCategory = "S" Then
                sqlstring = " SELECT ISNULL(KOTPREFIX,'') AS DOCTYPE FROM POSMASTER WHERE ISNULL(KOTPREFIX,'') <> '' AND Isnull(Freeze,'N')='N' "
            Else
                sqlstring = "  SELECT ISNULL(KOTPREFIX,'') AS DOCTYPE FROM POSMASTER WHERE ISNULL(KOTPREFIX,'') <> '' AND Isnull(Freeze,'N')='N' and poscode in (SELECT poscode FROM POS_USERCONTROL where username='" & gUsername & "')"
            End If
            CMB_BTYPE.Items.Clear()
            gconnection.getDataSet(sqlstring, "posdocument")
            If gdataset.Tables("posdocument").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("posdocument").Rows.Count - 1
                    CMB_BTYPE.Items.Add(gdataset.Tables("posdocument").Rows(i).Item("DOCTYPE"))
                Next i
                CMB_BTYPE.SelectedIndex = 0
            Else
                MessageBox.Show("Plz Enter various POS DOCUMENT into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Autogenerate()
        Dim sqlstring, financalyear, strstring As String
        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
        Try
            If Mid(pKotType, 1, 1) = "A" Or Mid(gKotType, 1, 1) = "A" Then
                If gCenterlized = "Y" Then
                    sqlstring = "SELECT  ISNULL(MAX(Cast(SUBSTRING(KOTno,1,6) As Numeric)),0)  FROM KOT_HDR  WHERE SALETYPE ='SALE' AND ISNULL(TTYPE,'') <> 'S' "
                ElseIf gCenterlized = "N" Then
                    sqlstring = "SELECT  ISNULL(MAX(Cast(SUBSTRING(KOTno,1,6) As Numeric)),0)  FROM KOT_HDR  WHERE DocType ='" & Trim(DOCTYPE) & "' AND SALETYPE <> 'SALE'  AND ISNULL(TTYPE,'') <> 'S'"
                End If
                gconnection.openConnection()
                gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
                gdreader = gcommand.ExecuteReader
                If gdreader.Read Then
                    If gdreader(0) Is System.DBNull.Value Then
                        If gCenterlized = "Y" Then
                            txt_KOTno.Text = gDocType & "/000001" & "/" & financalyear
                        Else
                            txt_KOTno.Text = DOCTYPE & "/000001" & "/" & financalyear
                        End If
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        If gCenterlized = "Y" Then
                            txt_KOTno.Text = gDocType & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                        Else
                            txt_KOTno.Text = DOCTYPE & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                        End If
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    If gCenterlized = "Y" Then
                        txt_KOTno.Text = gDocType & "/000001" & "/" & financalyear
                    Else
                        txt_KOTno.Text = DOCTYPE & "/000001" & "/" & financalyear
                    End If
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                'txt_KOTno.Text = ""
                If Mid(pKotType, 1, 1) = "A" Then
                Else
                    strstring = "SELECT * FROM KOT_HDR WHERE KOTDETAILS='" & txt_KOTno.Text & "'"
                    gconnection.getDataSet(strstring, "KOTNO")
                    If gdataset.Tables("KOTNO").Rows.Count = 0 Then
                        strstring = " Select isnull(Prefix,'') as Prefix,isnull(Servercode,'') as Servercode From Kotbook "
                        strstring = strstring & "  Where  " & IIf(Val(txt_KOTno.Text) > 0, Val(txt_KOTno.Text), 0) & " between snofrom and  snoto "
                        gconnection.getDataSet(strstring, "servermaster")
                        If gdataset.Tables("servermaster").Rows.Count > 0 Then
                            txt_ServerCode.Text = gdataset.Tables("servermaster").Rows(0).Item("Servercode")
                            strstring = " Select isnull(servername,'') as servername,isnull(Servercode,'') as Servercode From servermaster where servercode='" & Trim(txt_ServerCode.Text) & "' "
                            gconnection.getDataSet(strstring, "servername")
                            txt_ServerName.Text = gdataset.Tables("servername").Rows(0).Item("servername")
                            'txt_ServerCode_Validated(sender, e)
                            cbo_PaymentMode.Focus()
                            'txt_MemberCode.Focus()
                        Else
                            'MessageBox.Show("Kindly Register This Kotbook in System,Thanking You", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            txt_KOTno.Text = ""
                            txt_KOTno.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            End If
            
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub

    Private Sub autogenerate_CENTRALISED()
        Dim sqlstring, financalyear As String
        Try
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
            sqlstring = "SELECT Isnull(DocNo,0) FROM PoSKotDoc Where DocType = 'KOT'"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    txt_KOTno.Text = "KOT/000001/" & financalyear
                    'txt_KOTno.Text = gPoSUsername & "/000001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    txt_KOTno.Text = "KOT/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    'txt_KOTno.Text = gPoSUsername & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                txt_KOTno.Text = "KOT/000001/" & financalyear
                'txt_KOTno.Text = gPoSUsername & "/000001/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
            'End
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub
    Private Sub GRIDLOCK()
        Dim Row, Col As Integer
        sSGrid.Col = 15
        sSGrid.Row = sSGrid.ActiveRow
        For Row = 1 To 100
            For Col = 1 To 5
                sSGrid.Row = Row
                sSGrid.Col = Col
                sSGrid.Lock = True
            Next
        Next
        sSGrid.Row = 1
        For Col = 1 To 5
            sSGrid.Col = Col
            sSGrid.Lock = False
        Next
    End Sub
    Private Sub GridLockRate()
        Dim Row, Col As Integer
        sSGrid.Col = 6
        sSGrid.Row = sSGrid.ActiveRow
        For Row = 1 To 100
            sSGrid.Col = 20
            sSGrid.Row = Row
            If Trim(sSGrid.Text) = "Y" Then
                For Col = 6 To 6
                    sSGrid.Row = Row
                    sSGrid.Col = Col
                    sSGrid.Lock = False
                Next
            Else
                For Col = 6 To 8
                    sSGrid.Row = Row
                    sSGrid.Col = Col
                    sSGrid.Lock = True
                Next
            End If
        Next
    End Sub
    Private Sub HideCol()
        'Dim i, j As Integer
        'For i = 1 To 50
        '    For j = 9 To 20
        '        sSGrid.Col = j
        '        sSGrid.Row = i
        '        sSGrid.ColHidden = True
        '    Next j
        '    sSGrid.Col = 7
        '    sSGrid.Row = i
        '    sSGrid.ColHidden = True
        '    sSGrid.Col = 12
        '    sSGrid.Row = i
        '    sSGrid.ColHidden = False
        'Next i
    End Sub
    Private Sub GridUnLock()
        Dim i, j As Integer
        For i = 1 To 100
            For j = 1 To 5
                sSGrid.Col = j
                sSGrid.Row = i
                sSGrid.Lock = False
            Next j
        Next i
    End Sub
    Private Sub GridColUnLock(ByVal ColNo As Integer)
        Dim i, j As Integer
        For i = 1 To 100
            'For j = 1 To 5
            sSGrid.Col = ColNo
            sSGrid.Row = i
            sSGrid.Lock = False
            'Next j
        Next i
    End Sub
    Private Sub disablecontrols()
        txt_TableNo.ReadOnly = True
        txt_Cover.ReadOnly = True
        txt_MemberCode.ReadOnly = True
        txt_MemberName.ReadOnly = True
        txt_ServerCode.ReadOnly = True
        txt_ServerName.ReadOnly = True
        dtp_KOTdate.Enabled = False
        cbo_PaymentMode.Enabled = False
        cbo_SubPaymentMode.Enabled = False
        cmd_MemberCodeHelp.Enabled = False
        cmd_ServerCodeHelp.Enabled = False
        cmd_TablenoHelp.Enabled = False
        Cmd_Add.Enabled = False
    End Sub
    Private Sub Enabledcontrol()
        txt_TableNo.ReadOnly = False
        txt_Cover.ReadOnly = False
        txt_MemberCode.ReadOnly = False
        txt_MemberName.ReadOnly = False
        'txt_ServerCode.ReadOnly = False
        'txt_ServerName.ReadOnly = False
        If Mid(gWaiterReq, 1, 1) = "Y" Then
            txt_ServerCode.ReadOnly = False
            txt_ServerName.ReadOnly = False
            cmd_ServerCodeHelp.Enabled = True
        Else
            txt_ServerCode.ReadOnly = True
            txt_ServerName.ReadOnly = True
            cmd_ServerCodeHelp.Enabled = False
        End If
        dtp_KOTdate.Enabled = True
        cbo_PaymentMode.Enabled = True
        cbo_SubPaymentMode.Enabled = True
        cmd_MemberCodeHelp.Enabled = True
        'cmd_ServerCodeHelp.Enabled = True
        cmd_TablenoHelp.Enabled = True
        Cmd_Add.Enabled = True
    End Sub
    Private Sub fillPayment_Mode()
        Dim sqlstring As String
        Dim index As Integer
        Dim i As Integer
        Try
            sqlstring = " SELECT Paymentcode FROM paymentmodemaster WHERE Isnull(Freeze,'')<>'Y' and isnull(kot,'')='YES'"
            cbo_PaymentMode.Items.Clear()
            gconnection.getDataSet(sqlstring, "paymentmodemaster")
            If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("paymentmodemaster").Rows.Count - 1
                    cbo_PaymentMode.Items.Add(gdataset.Tables("paymentmodemaster").Rows(i).Item("Paymentcode"))
                Next i
                If LoadCount = 0 Then
                    index = cbo_PaymentMode.FindString(DefaultPayment)
                    cbo_PaymentMode.SelectedIndex = index
                Else
                    index = cbo_PaymentMode.FindString(lastpaymode)
                    cbo_PaymentMode.SelectedIndex = index
                End If
                lastpaymode = cbo_PaymentMode.Text
                Call FillSubPaymentMode(DefaultPayment)
            Else
                MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillSubPaymentMode(ByVal Paymode As String)
        Dim sql As String
        Dim i As Integer
        Dim dt As New DataTable
        sql = "SELECT ISNULL(SUBPAYSTATUS,'') AS SUBPAYSTATUS FROM PAYMENTMODEMASTER WHERE PAYMENTCODE = '" & Trim(Paymode) & "'and isnull(kot,'')='YES'"
        gconnection.getDataSet(sql, "PAYMENTMODEMASTER")
        If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
            If gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("SUBPAYSTATUS") = "YES" Then
                sql = "SELECT subpaymentcode + '-' + SubPaymentname FROM SubpaymentMode WHERE Paymentcode='" & Trim(Paymode) & "' AND ISNULL(Freeze,'')<>'Y'"
                Me.cbo_SubPaymentMode.Items.Clear()
                dt = gconnection.GetValues(sql)
                If dt.Rows.Count > 0 Then
                    Me.cbo_SubPaymentMode.Visible = True
                    lbl_SubPaymentMode.Visible = True
                    For i = 0 To dt.Rows.Count - 1
                        Me.cbo_SubPaymentMode.Items.Add(dt.Rows(i).Item(0))
                    Next i
                    Me.cbo_PaymentMode.Focus()
                    Me.cbo_SubPaymentMode.SelectedIndex = 0
                Else
                    cbo_SubPaymentMode.Visible = False
                    lbl_SubPaymentMode.Visible = False
                End If
            Else
                cbo_SubPaymentMode.Visible = False
                lbl_SubPaymentMode.Visible = False
            End If
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='POS' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add.Enabled = False
        Me.cmd_Delete.Enabled = False
        Me.cmd_View.Enabled = False
        Me.Cmd_Print.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.cmd_Delete.Enabled = True
                    Me.cmd_View.Enabled = True
                    Me.Cmd_Print.Enabled = True
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
                    Me.cmd_Delete.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.Cmd_Print.Enabled = True
                End If
            Next
        End If
    End Sub
    Public Function SetDateTime()
        If Val(Now.Hour) >= 0 And Val(Now.Hour) <= 5 Then
            dtp_KOTdate.Value = DateAdd(DateInterval.Day, -1, Now)
            KOT_Timer.Enabled = False
            Select Case Val(Now.Hour)
                Case 1
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-65 - Now.Minute), Now).ToLongTimeString
                Case 2
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-125 - Now.Minute), Now).ToLongTimeString
                Case 3
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-185 - Now.Minute), Now).ToLongTimeString
                Case 4
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-245 - Now.Minute), Now).ToLongTimeString
                Case 5
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-305 - Now.Minute), Now).ToLongTimeString
                Case 0
                    txt_KOTTime.Text = DateAdd(DateInterval.Minute, (-5 - Now.Minute), Now).ToLongTimeString
            End Select
        Else
            KOT_Timer.Enabled = True
            txt_KOTTime.Text = Now.ToLongTimeString
            'dtp_KOTdate.Value = Now.Date
            'dtp_KOTdate.Value = Now.ToLongDateString
            'Now.ToLongDateString()

        End If
        'txt_TableNo.Focus()
        cbo_PaymentMode.Focus()

    End Function
    Private Sub ShowBillno()
        Dim sqlstring, financalyear As String
        Try
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)

            sqlstring = "SELECT Isnull(KOTNO,0) FROM KOT_HDR Where DocType = '" & DOCTYPE & "'"
            gconnection.openConnection()
            gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is DBNull.Value Then
                    lbl_Status.Visible = True
                    lbl_Status.Text = "FIRST KOTNO :"
                Else
                    lbl_Status.Visible = False
                    lbl_Status.Text = "LAST KOTNO :" & Trim(DOCTYPE) & "/" & Format(Val(gdreader(0)), "000000") & "/" & financalyear
                    'lbl_Status.Text = "LAST KOTNO :" & gPoSUsername & "/" & Format(Val(gdreader(0)), "000000") & "/" & financalyear
                    'End
                End If
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            Else
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub
    Private Sub SYS_DATE_TIME()
        Dim sqlstring, financalyear, Insert(0) As String
        Try
            sqlstring = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
            gconnection.getDataSet(sqlstring, "SERVERDATE")
            If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then
                dtp_KOTdate.Value = gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE")
            End If
            dtp_KOTdate.Enabled = False
            'CMD_LOCK()
        Catch ex As Exception
            MessageBox.Show("Enter a valid datetime :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub KOT_Timer_Tick(sender As Object, e As EventArgs) Handles KOT_Timer.Tick
        txt_KOTTime.Text = Now.ToLongTimeString
    End Sub

    Private Sub sSGrid_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles sSGrid.KeyDownEvent
        Dim Sqlstring, Itemcode, Itemdesc, Promtcode, itc As String
        Dim varitemcode, varitemdesc, varposcode, varuom As String
        Dim i, j, t, cct As Integer
        Dim PROQTY_GRID As Double

        Dim varitemrate As Double
        Try
            If e.keyCode = Keys.Enter Or e.keyCode = Keys.Tab Then
                i = sSGrid.ActiveRow
                If sSGrid.ActiveCol = 1 Then
                    sSGrid.Row = i
                    sSGrid.Col = 2
                    varitemdesc = Trim(sSGrid.Text)
                    sSGrid.Col = 3
                    varposcode = Trim(sSGrid.Text)
                    sSGrid.Col = 1
                    If sSGrid.Lock = False Then
                        If Trim(sSGrid.Text) = "" Then
                            Call FillMenu() ' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        ElseIf Trim(sSGrid.Text) <> "" Then
                            If Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                                Itemcode = Trim(sSGrid.Text)
                                Dim K As Integer
                                'For j = 1 To sSGrid.DataRowCnt + 1
                                '    'Dim ITC
                                '    sSGrid.Col = 1
                                '    sSGrid.Row = j
                                '    itc = sSGrid.Text
                                '    For K = 1 To sSGrid.DataRowCnt + 1
                                '        sSGrid.Col = 1
                                '        sSGrid.Row = K
                                '        If Trim(sSGrid.Text) = itc Then
                                '            cct = cct + 1
                                '        End If
                                '    Next
                                '    If cct > 1 Then
                                '        MsgBox("duplicate item entry")
                                '        Exit Sub
                                '    End If
                                '    cct = 0
                                'Next
                                j = 0
                                sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE,I.OPENFACILITY,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                If gCenterlized = "Y" Then
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink ) and I.ITEMCODE = '" & Trim(Itemcode) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                Else
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "') and I.ITEMCODE = '" & Trim(Itemcode) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                End If
                                'AND txt_POSCode='" & Trim(POScode) & "'
                                gconnection.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                    sSGrid.SetText(1, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "")
                                    sSGrid.SetText(2, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")) & "")
                                    sSGrid.SetText(9, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")) & "")
                                    sSGrid.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")) & "")
                                    sSGrid.SetText(11, i, Val(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    sSGrid.SetText(13, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    sSGrid.SetText(14, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("SALESACCTIN")))
                                    sSGrid.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    sSGrid.SetText(16, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("SUBGROUPCODE")))
                                    sSGrid.SetText(20, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                    Else
                                        sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                                    End If
                                    ''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("Promotional")) = "Y" Then
                                        Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PromItemcode"))

                                        Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC, IM.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN "

                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                        Sqlstring = Sqlstring & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                        Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                        gconnection.getDataSet(Sqlstring, "PROMOTIONAL")
                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                            If MessageBox.Show("Promotional available for this Itemcode!", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) >= CDate(Now.Today) Then
                                                    sSGrid.SetText(1, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                    sSGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                    sSGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                    sSGrid.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                    sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                    sSGrid.SetText(6, i + 1, 0.0)
                                                    sSGrid.SetText(7, i + 1, 0.0)
                                                    sSGrid.SetText(8, i + 1, 0.0)
                                                    sSGrid.SetText(9, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                    'Modified on 14 Mar'08
                                                    'Mk Kannan
                                                    'Begin
                                                    sSGrid.SetText(11, i + 1, 0.0)
                                                    sSGrid.SetText(15, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("GROUPCODE")) & "")
                                                    sSGrid.SetText(17, i + 1, "Y")
                                                    boolPromotional = True
                                                    'End
                                                End If
                                            End If
                                        End If
                                    End If
                                    '''*************************** $ COMPLETE PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    '''****************************** TO FILL POSCODE **********************************************************************'''
                                    'Sqlstring = "SELECT POSCODE,POSDESC,SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    Sqlstring = "SELECT POSCODE,POSDESC,'' as SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "'"
                                    gconnection.getDataSet(Sqlstring, "PosMenuLinkVALIDATE")
                                    If gdataset.Tables("PosMenuLinkVALIDATE").Rows.Count > 0 Then
                                        If gCenterlized = "Y" Then
                                            Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                        Else
                                            Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "' ORDER BY POSCODE"
                                        End If
                                    Else
                                        Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    End If
                                    gconnection.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count = 1 Then
                                        sSGrid.Col = 3
                                        sSGrid.Row = sSGrid.ActiveRow
                                        sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE")
                                        'If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")) = False Then
                                        '    If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                        '        sSGrid.Col = 14
                                        '        sSGrid.Row = sSGrid.ActiveRow
                                        '        'sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")
                                        '    Else
                                        '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '        Exit Sub
                                        '    End If
                                        'Else
                                        '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '    Exit Sub
                                        'End If
                                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) ORDER BY R.ITEMRATE,R.UOM"
                                        gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                            sSGrid.Col = 4
                                            sSGrid.Row = sSGrid.ActiveRow
                                            sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                            sSGrid.Col = 6
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Val(PACKINGPERCENT) <> 0 Then
                                                sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                            Else
                                                sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                            End If
                                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                            End If
                                        Else
                                            sSGrid.Col = 6
                                            sSGrid.Text = "0.00"
                                            sSGrid.Col = 4
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                                            End If

                                        End If
                                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                    Else
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                    End If
                                    '''****************************** COMPLETE FILLING TO FILL POSCODE ******************************************************'''
                                Else
                                    MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                    sSGrid.Lock = False
                                    sSGrid.Focus()
                                    Exit Sub
                                End If
                            Else
                                If pnl_POSCode.Top = 50 Then
                                    Me.lvw_POSCode.FullRowSelect = True
                                    lvw_POSCode.Focus()
                                End If
                            End If
                        End If
                    End If
                ElseIf sSGrid.ActiveCol = 2 Then
                    sSGrid.Row = i
                    sSGrid.Col = 3
                    varposcode = Trim(sSGrid.Text)
                    sSGrid.Col = 1
                    sSGrid.Col = 2
                    sSGrid.Row = sSGrid.ActiveRow
                    If sSGrid.Lock = False Then
                        If Trim(sSGrid.Text) = "" Then
                            Call FillMenuItem() ''' IT WILL SHOW A POPUP MENU FOR ITEM DESC
                        Else
                            If Trim(varposcode) = "" Then
                                Itemdesc = Trim(sSGrid.Text)
                                sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                If gCenterlized = "Y" Then
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink ) and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                Else
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "') and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                End If
                                gconnection.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                    sSGrid.SetText(1, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "")
                                    Itemcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & ""
                                    sSGrid.SetText(2, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")) & "")
                                    sSGrid.SetText(9, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")) & "")
                                    sSGrid.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")) & "")
                                    sSGrid.SetText(11, i, Val(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    sSGrid.SetText(13, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    sSGrid.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    sSGrid.SetText(16, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("subgroupcode")))
                                    sSGrid.SetText(20, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                    Else
                                        sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                                    End If
                                    '''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("Promotional")) = "Y" Then

                                        Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PromItemcode"))

                                        'Modified on 14 Mar'08
                                        'Mk Kannan
                                        'Begin
                                        'Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, I.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        'Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                        'Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                        Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                        Sqlstring = Sqlstring & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                        Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                        'End

                                        gconnection.getDataSet(Sqlstring, "PROMOTIONAL")
                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                            If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) >= CDate(Now.Today) Then
                                                    sSGrid.SetText(1, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                    sSGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                    sSGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                    sSGrid.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                    sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                    sSGrid.SetText(6, i + 1, 0.0)
                                                    sSGrid.SetText(7, i + 1, 0.0)
                                                    sSGrid.SetText(8, i + 1, 0.0)
                                                    sSGrid.SetText(9, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                    'Modified on 14 Mar'08
                                                    'Mk Kannan
                                                    'Begin
                                                    sSGrid.SetText(11, i + 1, 0.0)
                                                    sSGrid.SetText(17, i + 1, "Y")
                                                    boolPromotional = True
                                                    'End
                                                End If
                                            End If
                                        End If
                                    End If
                                    '''*************************** $ COMPLETE PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                   Sqlstring = "SELECT POSCODE,POSDESC,'' as SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "'"
                                    gconnection.getDataSet(Sqlstring, "PosMenuLinkVALIDATE")
                                    If gdataset.Tables("PosMenuLinkVALIDATE").Rows.Count > 0 Then
                                        If gCenterlized = "Y" Then
                                            Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                        Else
                                            Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "' ORDER BY POSCODE"
                                        End If
                                    Else
                                        Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    End If
                                    gconnection.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count = 1 Then
                                        sSGrid.Col = 3
                                        sSGrid.Row = sSGrid.ActiveRow
                                        sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE")
                                        'If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")) = False Then
                                        '    If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                        '        sSGrid.Col = 14
                                        '        sSGrid.Row = sSGrid.ActiveRow
                                        '        'sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")
                                        '    Else
                                        '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '        Exit Sub
                                        '    End If
                                        'Else
                                        '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '    Exit Sub
                                        'End If
                                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) "
                                        gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                            sSGrid.Col = 4
                                            sSGrid.Row = sSGrid.ActiveRow
                                            sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                            sSGrid.Col = 6
                                            ''sSGrid.Row = sSGrid.ActiveRow
                                            ''If Val(PACKINGPERCENT) <> 0 Then
                                            ''    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                            ''    ''+ (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                            ''Else
                                            sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                            'End If
                                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            End If
                                        Else
                                            sSGrid.Col = 4
                                            sSGrid.Col = 6
                                            sSGrid.Text = "0.00"
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                                            End If

                                        End If
                                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                    Else
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                    End If
                                    '''****************************** COMPLETE FILLING TO FILL POSCODE ******************************************************'''
                                Else
                                    MessageBox.Show("Specified ITEM DESC not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                    sSGrid.Lock = False
                                    sSGrid.Focus()
                                    Exit Sub
                                End If
                            Else
                                sSGrid.Col = 19
                                sSGrid.Row = sSGrid.ActiveRow
                                If Trim(sSGrid.Text) = "Y" Then
                                    sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    sSGrid.Focus()
                                End If
                            End If
                        End If
                    End If
                ElseIf sSGrid.ActiveCol = 3 Then
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Col = 1
                    varitemcode = Trim(sSGrid.Text)
                    sSGrid.Col = 2
                    varitemdesc = Trim(sSGrid.Text)
                    sSGrid.Col = 3
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" Then
                        sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                        Exit Sub
                    Else
                        If sSGrid.Lock = False Then
                            sSGrid.Col = 1
                            varitemcode = Trim(sSGrid.Text)
                            sSGrid.Col = 3
                            varposcode = Trim(sSGrid.Text)
                            If Trim(varposcode) = "" Then
                                sSGrid.Text = ""
                                sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                sSGrid.Focus()
                                Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(varitemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                gconnection.getDataSet(Sqlstring, "PosMenuLink")
                                If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                                    '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                    Call FillPosList(gdataset.Tables("PosMenuLink"))
                                    Me.lvw_POSCode.FullRowSelect = True
                                    pnl_POSCode.Top = 50
                                    lvw_POSCode.Focus()
                                End If
                                '''****************************** SHOW COMPLETE FOR POS LOCATION ***********************''
                                Exit Sub
                            ElseIf Trim(varposcode) <> "" Then
                                Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(varitemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND POSCODE = '" & Trim(CStr(varposcode)) & "' ORDER BY POSCODE"
                                gconnection.getDataSet(Sqlstring, "POSMASTER")
                                If gdataset.Tables("POSMASTER").Rows.Count = 1 Then
                                    sSGrid.Col = 3
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = gdataset.Tables("POSMASTER").Rows(0).Item("POSCODE")
                                    sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    'If IsDBNull(gdataset.Tables("POSMASTER").Rows(0).Item("SALESACCTIN")) = False Then
                                    '    If Trim((gdataset.Tables("POSMASTER").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                    '        sSGrid.Col = 14
                                    '        sSGrid.Row = sSGrid.ActiveRow
                                    '        'sSGrid.Text = gdataset.Tables("POSMASTER").Rows(0).Item("SALESACCTIN")
                                    '    Else
                                    '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                    '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                    '        Exit Sub
                                    '    End If
                                    'Else
                                    '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                    '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                    '    Exit Sub
                                    'End If
                                Else
                                    MessageBox.Show("!! Oop's specified POSCODE is not valid ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    sSGrid.Text = ""
                                    sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                    sSGrid.Focus()
                                    Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(varitemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    gconnection.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                    End If
                                    '''****************************** SHOW COMPLETE FOR POS LOCATION ***********************''
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                ElseIf sSGrid.ActiveCol = 4 Then
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Col = 1
                    varitemcode = Trim(sSGrid.Text)
                    sSGrid.Col = 2
                    varitemdesc = Trim(sSGrid.Text)
                    sSGrid.Col = 3
                    varposcode = Trim(sSGrid.Text)

                    sSGrid.Col = 4
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                        sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                        Exit Sub
                    Else
                        If sSGrid.Lock = False Then
                            sSGrid.Col = 1
                            varitemcode = Trim(sSGrid.Text)
                            sSGrid.Col = 3
                            varposcode = Trim(sSGrid.Text)
                            sSGrid.Col = 6
                            varitemrate = Val(sSGrid.Text)
                            sSGrid.Col = 4
                            If Trim(sSGrid.Text) = "" Then
                                '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                Sqlstring = "SELECT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(varitemcode) & "' ) ORDER BY R.ITEMRATE,R.UOM"
                                gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                    sSGrid.Col = 4
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                    ''sSGrid.Col = 6
                                    ''sSGrid.Row = sSGrid.ActiveRow
                                    ''sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                    ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    sSGrid.Col = 19
                                    sSGrid.Row = sSGrid.ActiveRow
                                    If Trim(sSGrid.Text) = "Y" Then
                                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    Else
                                        sSGrid.Col = 6
                                        sSGrid.Row = sSGrid.ActiveRow
                                        sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    End If
                                ElseIf gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                                    sSGrid.Col = 4
                                    Call FillUomList(gdataset.Tables("ITEMRATE"))
                                    Me.lvw_Uom.FullRowSelect = True
                                    pnl_UOMCode.Top = 50
                                    Me.lvw_Uom.Focus()
                                Else
                                    sSGrid.Col = 1
                                    sSGrid.Row = sSGrid.ActiveRow
                                    If Trim(sSGrid.Text) <> "" Then
                                        sSGrid.Col = 4
                                        sSGrid.Text = ""
                                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    End If
                                End If
                                '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                            ElseIf Trim(sSGrid.Text) <> "" Then
                                Sqlstring = "SELECT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(varitemcode) & "' ) AND R.ITEMRATE = " & Val(varitemrate) & " ORDER BY R.ITEMRATE,R.UOM"
                                gconnection.getDataSet(Sqlstring, "RATEMASTER")
                                If gdataset.Tables("RATEMASTER").Rows.Count > 0 Then
                                    If gdataset.Tables("RATEMASTER").Rows.Count = 1 Then
                                        sSGrid.Col = 4
                                        sSGrid.Row = sSGrid.ActiveRow
                                        sSGrid.Text = CStr(gdataset.Tables("RATEMASTER").Rows(0).Item("UOM")) & ""
                                        'sSGrid.Col = 6
                                        'sSGrid.Row = sSGrid.ActiveRow
                                        'sSGrid.Text = Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE")) & ""
                                        'sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                        sSGrid.Col = 19
                                        sSGrid.Row = sSGrid.ActiveRow
                                        If Trim(sSGrid.Text) = "Y" Then
                                            sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                        Else
                                            sSGrid.Col = 6
                                            sSGrid.Row = sSGrid.ActiveRow
                                            'If Val(PACKINGPERCENT) <> 0 Then
                                            '    sSGrid.Text = Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE"))
                                            '    ''+ (Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                            'Else
                                            sSGrid.Text = Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE")) & ""
                                            'End If
                                            sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                        End If
                                    ElseIf gdataset.Tables("RATEMASTER").Rows.Count > 1 Then
                                        sSGrid.Col = 4
                                        Call FillUomList(gdataset.Tables("ITEMRATE"))
                                        Me.lvw_Uom.FullRowSelect = True
                                        pnl_UOMCode.Top = 50
                                        Me.lvw_Uom.Focus()
                                        Exit Sub
                                    Else
                                        sSGrid.Col = 4
                                        sSGrid.Col = 6
                                        sSGrid.Text = "0.00"
                                    End If
                                Else
                                    MessageBox.Show("!! Oop's specified ITEM UOM is not valid ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    sSGrid.Col = 4
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = ""
                                    sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                                End If
                            End If
                        Else
                            If pnl_UOMCode.Top = 50 Then
                                Me.lvw_Uom.FullRowSelect = True
                                pnl_UOMCode.Top = 50
                                Me.lvw_Uom.Focus()
                                Exit Sub
                            Else
                                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                            End If
                        End If
                    End If
                ElseIf sSGrid.ActiveCol = 5 Then
                    Dim ITEMQTY, Freeqty, FreeDis, FreeRate, ActRate, PKotQty, rkotqty, baseqty As Double
                    Dim PROMAMT As Double
                    Dim Basedon, BItemcode, Pitemcode, Puom, WeekDay, Type, Pssql, buom, ssql As String
                    Dim CHECK_AVAILABILITY, k As Integer
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Col = 3
                    sSGrid.Lock = True
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Col = 4
                    sSGrid.Lock = True
                    sSGrid.Col = 20
                    sSGrid.Row = sSGrid.ActiveRow
                    If Trim(sSGrid.Text) = "Y" Then
                        sSGrid.Lock = False
                    Else
                        sSGrid.Lock = True
                    End If
                    sSGrid.Row = sSGrid.ActiveRow
                    sSGrid.Col = 1
                    varitemcode = Trim(sSGrid.Text)
                    sSGrid.Col = 2
                    varitemdesc = Trim(sSGrid.Text)
                    sSGrid.Col = 3
                    varposcode = Trim(sSGrid.Text)
                    sSGrid.Col = 4
                    buom = Trim(sSGrid.Text)
                    sSGrid.Col = 6
                    ActRate = Val(sSGrid.Text)
                    sSGrid.Col = 5
                    ITEMQTY = Val(sSGrid.Text)
                    WeekDay = UCase(Now.DayOfWeek.ToString)
                    PKotQty = 0
                    'boolProm = False
                    Pssql = "DELETE FROM PROM_STATUS"
                    gconnection.dataOperation(9, Pssql, "DELETE")
                   
                    sSGrid.Col = 5
                    Pssql = "SELECT KOTDETAILS,ITEMCODE,SUM(QTY)AS QTY FROM KOT_DET WHERE ISNULL(BILLDETAILS,'') = '' AND ISNULL(PROMKOTNO,'') = ''"
                    Pssql = Pssql & " AND CAST(CONVERT(VARCHAR,KOTDATE,106)AS DATETIME) = '" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "' AND ITEMCODE = '" & varitemcode & "' AND MCODE = '" & Trim(txt_MemberCode.Text) & "'"
                    Pssql = Pssql & " AND ISNULL(PROMOTIONALST,'') <> 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' GROUP BY KOTDETAILS,ITEMCODE "
                    gconnection.getDataSet(Pssql, "PROM")
                    If gdataset.Tables("PROM").Rows.Count > 0 Then
                        For k = 0 To gdataset.Tables("PROM").Rows.Count - 1
                            PKotQty = PKotQty + gdataset.Tables("PROM").Rows(k).Item("QTY")
                            Pssql = "INSERT INTO PROM_STATUS VALUES ('" & gdataset.Tables("PROM").Rows(k).Item("KOTDETAILS") & "','" & Trim(txt_KOTno.Text) & "','" & gdataset.Tables("PROM").Rows(k).Item("ITEMCODE") & "','" & gdataset.Tables("PROM").Rows(k).Item("QTY") & "')"
                            gconnection.dataOperation(9, Pssql, "DELETE")
                        Next
                    End If
                    ssql = "select pitemcode as itemcode FROM PROMMASTER WHERE  BASEDITEMCODE = '" & varitemcode & "' and baseduom= '" & buom & "' AND '" & Format(Now, "dd/MMM/yyyy") & "' BETWEEN FROMDATE AND TODATE AND '" & Format(Now, "HH:MM") & "' BETWEEN FROMTIME AND TOTIME AND WDAY = '" & WeekDay & "' AND POSCODE = '" & varposcode & "'"
                    gconnection.getDataSet(ssql, "rau")
                    If gdataset.Tables("RAU").Rows.Count > 0 Then
                        Pssql = "SELECT KOTDETAILS,ITEMCODE,SUM(QTY)AS QTY FROM KOT_DET WHERE ISNULL(BILLDETAILS,'') = '' AND ISNULL(PROMKOTNO,'') = ''"
                        Pssql = Pssql & " AND CAST(CONVERT(VARCHAR,KOTDATE,106)AS DATETIME) = '" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "' AND ITEMCODE = '" & gdataset.Tables("RAU").Rows(0).Item("itemcode") & "' AND MCODE = '" & Trim(txt_MemberCode.Text) & "'"
                        Pssql = Pssql & " AND ISNULL(PROMOTIONALST,'') = 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' GROUP BY KOTDETAILS,ITEMCODE "
                        gconnection.getDataSet(Pssql, "PROM")
                        If gdataset.Tables("PROM").Rows.Count > 0 Then
                            For k = 0 To gdataset.Tables("PROM").Rows.Count - 1
                                rkotqty = rkotqty + gdataset.Tables("PROM").Rows(k).Item("QTY")

                            Next

                        End If
                    End If
                    Pssql = "INSERT INTO PROM_STATUS_TEMP SELECT * FROM PROM_STATUS"
                    gconnection.dataOperation(9, Pssql, "DELETE")
                    ITEMQTY = ITEMQTY + PKotQty
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                        Exit Sub
                    Else
                        If sSGrid.Lock = False Then
                            sSGrid.Col = 1
                            sSGrid.Row = sSGrid.ActiveRow
                            If Trim(sSGrid.Text) <> "" Then
                                sSGrid.Col = 5
                                sSGrid.Row = sSGrid.ActiveRow
                                If Val(sSGrid.Text) = 0 Then
                                    sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    Exit Sub
                                Else
                                    sSGrid.Col = 20
                                    sSGrid.Row = sSGrid.ActiveRow
                                    If Trim(sSGrid.Text) = "Y" Then
                                        sSGrid.Col = 6
                                        sSGrid.Lock = False
                                        sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
                                        Exit Sub
                                    Else
                                        'GPS  PROMOTIONAL
                                        '''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                        sSGrid.Col = 1
                                        sSGrid.Row = sSGrid.ActiveRow
                                        Itemcode = Trim(sSGrid.Text)
                                        Sqlstring = " SELECT ISNULL(Promotional,'') AS Promotional,ISNULL(PromItemcode,'') AS PromItemcode FROM ITEMMASTER WHERE ITEMCODE='" & Itemcode & "'"
                                        Sqlstring = "SELECT 'Y' AS Promotional,BASEDON AS PromItemcode FROM PROMMASTER WHERE BASEDITEMCODE = '" & varitemcode & "' "
                                        gconnection.getDataSet(Sqlstring, "ITEMCODE1")
                                        If gdataset.Tables("ITEMCODE1").Rows.Count > 0 Then
                                            If Trim(gdataset.Tables("ITEMCODE1").Rows(j).Item("Promotional")) = "Y" Then
                                                sSGrid.Col = 1
                                                sSGrid.Row = i
                                                Itemcode = Trim(sSGrid.Text)
                                                Basedon = (gdataset.Tables("ITEMCODE1").Rows(j).Item("PromItemcode"))

                                                '----- Pankaj Start
                                                If Basedon = "Q" Then
                                                    'Sqlstring = "SELECT PITEMCODE,ISNULL(FREEQTY,0) AS FREEQTY,ISNULL(PUOM,'') AS PUOM,'QTY' AS TYPE,ISNULL(FIXEDRATE,0) AS FIXEDRATE,ISNULL(DISCOUNT,0) AS DISCOUNT ,cast(((" & ITEMQTY & " /FROMQTY )- " & rkotqty & " )*ISNULL(FREEQTY,0) as integer) as prom  FROM PROMMASTER WHERE BASEDON = 'Q' AND BASEDITEMCODE = '" & varitemcode & "' and baseduom= '" & buom & "'AND '" & Format(Now, "dd/MMM/yyyy") & "' BETWEEN FROMDATE AND TODATE"
                                                    ' AND " & ITEMQTY & " BETWEEN FROMQTY AND TOQTY "
                                                    Sqlstring = "SELECT PITEMCODE,isnull(saleqty,0)as fromqty,ISNULL(FREEQTY,0) AS FREEQTY,ISNULL(PUOM,'') AS PUOM,ISNULL(TYPE,'') AS TYPE,ISNULL(FIXEDRATE,0) AS FIXEDRATE,ISNULL(DISCOUNT,0) AS DISCOUNT,cast(((" & ITEMQTY & " /saleqty )- " & rkotqty & " )*ISNULL(saleqty,0) as integer) as prom FROM PROMMASTER WHERE BASEDON = 'Q' AND BASEDITEMCODE = '" & varitemcode & "' and baseduom= '" & buom & "' AND '" & Format(Now, "dd/MMM/yyyy") & "' BETWEEN FROMDATE AND TODATE AND '" & Format(Now, "HH:MM") & "' BETWEEN FROMTIME AND TOTIME AND WDAY = '" & WeekDay & "' AND POSCODE = '" & varposcode & "'"
                                                ElseIf Basedon = "P" Then
                                                    Sqlstring = "SELECT PITEMCODE,isnull(FROMQTY,0)as fromqty,ISNULL(FREEQTY,0) AS FREEQTY,ISNULL(PUOM,'') AS PUOM,ISNULL(TYPE,'') AS TYPE,ISNULL(FIXEDRATE,0) AS FIXEDRATE,ISNULL(DISCOUNT,0) AS DISCOUNT,cast(((" & ITEMQTY & " /saleqty )- " & rkotqty & " )*ISNULL(saleqty,0) as integer) as prom FROM PROMMASTER WHERE BASEDON = 'P' AND BASEDITEMCODE = '" & varitemcode & "' and baseduom= '" & buom & "' AND '" & Format(Now, "dd/MMM/yyyy") & "' BETWEEN FROMDATE AND TODATE AND '" & Format(Now, "HH:MM") & "' BETWEEN FROMTIME AND TOTIME AND WDAY = '" & WeekDay & "' AND POSCODE = '" & varposcode & "'"
                                                    'AND " & ITEMQTY & " BETWEEN FROMQTY AND TOQTY 
                                                End If
                                                gconnection.getDataSet(Sqlstring, "FITEMCODE")
                                                If gdataset.Tables("FITEMCODE").Rows.Count > 0 Then
                                                    If gdataset.Tables("FITEMCODE").Rows(0).Item("prom") > 0 Then
                                                        boolProm = False
                                                        baseqty = gdataset.Tables("FITEMCODE").Rows(0).Item("fromqty")
                                                        Pitemcode = gdataset.Tables("FITEMCODE").Rows(0).Item("PITEMCODE")
                                                        Freeqty = gdataset.Tables("FITEMCODE").Rows(0).Item("prom")
                                                        Puom = gdataset.Tables("FITEMCODE").Rows(0).Item("PUOM")
                                                        Type = gdataset.Tables("FITEMCODE").Rows(0).Item("TYPE")
                                                        FreeRate = gdataset.Tables("FITEMCODE").Rows(0).Item("FIXEDRATE")
                                                        FreeDis = gdataset.Tables("FITEMCODE").Rows(0).Item("DISCOUNT")
                                                    Else
                                                        boolProm = False
                                                        baseqty = gdataset.Tables("FITEMCODE").Rows(0).Item("fromqty")
                                                        Pitemcode = gdataset.Tables("FITEMCODE").Rows(0).Item("PITEMCODE")
                                                        Freeqty = gdataset.Tables("FITEMCODE").Rows(0).Item("prom")
                                                        Puom = gdataset.Tables("FITEMCODE").Rows(0).Item("PUOM")
                                                        Type = gdataset.Tables("FITEMCODE").Rows(0).Item("TYPE")
                                                        FreeRate = gdataset.Tables("FITEMCODE").Rows(0).Item("FIXEDRATE")
                                                        FreeDis = gdataset.Tables("FITEMCODE").Rows(0).Item("DISCOUNT")

                                                    End If
                                                End If
                                                '-----Pankaj End

                                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,TL.TAXCODE,TL.TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,"
                                                Sqlstring = Sqlstring & " ISNULL(TL.ACCOUNTCODE,'') AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,I.PROMOTIONAL,I.PROMITEMCODE FROM ITEMMASTER AS I"
                                                Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
                                                Sqlstring = Sqlstring & " WHERE I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,getdate())  AND ISNULL(I.FREEZE,'') <>'Y'"
                                                gconnection.getDataSet(Sqlstring, "ITEMCODE")
                                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                                    Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(0).Item("PromItemcode"))
                                                End If
                                                sSGrid.Row = sSGrid.ActiveRow
                                                sSGrid.Col = 1
                                                Itemcode = Trim(sSGrid.Text)
                                                'Modified on 14 Mar'08
                                                'Mk Kannan
                                                'Begin
                                                'Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE,I.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                                'Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                'Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "                                        
                                                'Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC, IM.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,ISNULL(I.PROMTYPE,'') AS PROMTYPE,"
                                                Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY,I.BASEQTY , I.PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                Sqlstring = Sqlstring & " INNER JOIN ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                                'Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now()), "dd/MMM/yyyy") & "' BETWEEN I.StartingDate AND I.EndingDate AND PL.POS='" & Trim(varposcode) & "'"

                                                'PANKAJ
                                                If Basedon = "Q" Then
                                                    Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, 'QTY' AS PROMTYPE,"
                                                    Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , I.BASERATESTD AS PROMRATE FROM ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                    Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE"
                                                    'Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                    Sqlstring = Sqlstring & " WHERE (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                    Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now()), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(varposcode) & "'"

                                                ElseIf Basedon = "P" Then
                                                    If Type = "QTY" Then
                                                        Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                        Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , I.BASERATESTD AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                        Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                        Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                        Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(varposcode) & "'"
                                                    ElseIf Type = "DISCOUNT ON RATE" Then
                                                        Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                        Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , " & FreeDis & " AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                        Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                        Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                        Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate AND PL.POS='" & Trim(varposcode) & "'"
                                                    ElseIf Type = "FIXED RATE" Then
                                                        If UCase(Mid(gCompanyname, 1, 4)) = "CATH" Then
                                                            Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                            Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & baseqty & " AS BASEQTY , " & FreeRate & " AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                            Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                            Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                            Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                            Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(varposcode) & "'"
                                                        Else
                                                            Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                            Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , " & FreeRate & " AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                            Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                            Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                            Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                            Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(varposcode) & "'"

                                                        End If
                                                    End If
                                                End If

                                                'PANKAJ
                                                'CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) <= CDate(serverdate.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) >= CDate(serverdate.Today)
                                                'End
                                                gconnection.getDataSet(Sqlstring, "PROMOTIONAL")
                                                sSGrid.Row = sSGrid.ActiveRow
                                                sSGrid.Col = 5
                                                Trim(sSGrid.Text)
                                                'If Trim(sSGrid.Text) = Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY")) Then
                                                'PROQTY_GRID = Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")))
                                                If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                                    If Val(Trim(sSGrid.Text)) + PKotQty >= Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY"))) Then
                                                        PROQTY_GRID = (Val(Math.Floor(Trim(sSGrid.Text) + PKotQty) / Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY"))) * Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY"))))
                                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 And PROQTY_GRID <> 0 And Basedon = "Q" Then
                                                            CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                                            If CHECK_AVAILABILITY > 0 Then
                                                                If MessageBox.Show("Promotional available for this Itemcode!", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                                    'If Format(CDate(serverdate), "dd/MM/yyyy") = Format(CDate(dtp_KOTdate.Value), "dd/MM/yyyy") Then
                                                                    If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) <= CDate(Now) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) >= CDate(Now) Then
                                                                        CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                                                        If CHECK_AVAILABILITY = 0 Then
                                                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                sSGrid.ClearRange(1, i, sSGrid.MaxCols, i, True)
                                                                                sSGrid.Focus()
                                                                                sSGrid.SetActiveCell(0, i)
                                                                                Exit Sub
                                                                            End If

                                                                        ElseIf CHECK_AVAILABILITY = 1 Then
                                                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                sSGrid.Col = 4
                                                                                sSGrid.Text = ""
                                                                                sSGrid.SetActiveCell(4, i)
                                                                                sSGrid.Focus()
                                                                                Exit Sub
                                                                            End If
                                                                        End If
                                                                        If Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "FIXED RATE" Then
                                                                            sSGrid.SetText(6, i, Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE")))
                                                                            sSGrid.Row = i
                                                                            sSGrid.Col = 5
                                                                            If Val(sSGrid.Text) > 0 Then
                                                                                ITEMQTY = Val(sSGrid.Text)
                                                                                PROMAMT = Val((ITEMQTY * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))))
                                                                                sSGrid.SetText(8, i, PROMAMT)
                                                                                sSGrid.SetText(17, i, "Y")
                                                                                boolPromotional = True
                                                                                Call Calculate()
                                                                            End If
                                                                        ElseIf Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "DISCOUNT ON RATE" Then
                                                                            ActRate = ActRate - ((Val(ActRate) * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))) / 100)
                                                                            sSGrid.SetText(6, i, Val(ActRate))
                                                                            sSGrid.Row = i
                                                                            sSGrid.Col = 5
                                                                            If Val(sSGrid.Text) > 0 Then
                                                                                ITEMQTY = Val(sSGrid.Text)
                                                                                PROMAMT = Val(ActRate)
                                                                                sSGrid.SetText(8, i, PROMAMT)
                                                                                sSGrid.SetText(17, i, "Y")
                                                                                boolPromotional = True
                                                                                Call Calculate()
                                                                            End If
                                                                        Else
                                                                            sSGrid.SetText(1, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                            sSGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                                            sSGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                                            sSGrid.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                                            sSGrid.Row = i
                                                                            sSGrid.Col = 3
                                                                            sSGrid.Lock = True
                                                                            sSGrid.Row = i
                                                                            sSGrid.Col = 4
                                                                            sSGrid.Lock = True
                                                                            sSGrid.Row = i
                                                                            sSGrid.Col = 3
                                                                            sSGrid.Lock = True
                                                                            sSGrid.Row = i + 1
                                                                            sSGrid.Col = 4
                                                                            sSGrid.Lock = True
                                                                            sSGrid.Col = 17
                                                                            sSGrid.Row = sSGrid.ActiveRow
                                                                            If Trim(sSGrid.Text) = "Y" Then
                                                                                sSGrid.Lock = False
                                                                            Else
                                                                                sSGrid.Lock = True
                                                                            End If
                                                                            'sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                                            sSGrid.SetText(5, i + 1, Val(PROQTY_GRID))
                                                                            sSGrid.Row = i + 1
                                                                            sSGrid.Col = 5
                                                                            sSGrid.Lock = True
                                                                            sSGrid.SetText(6, i + 1, 0.0)
                                                                            sSGrid.SetText(7, i + 1, 0.0)
                                                                            sSGrid.SetText(8, i + 1, 0.0)
                                                                            sSGrid.SetText(9, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                                            sSGrid.SetText(11, i + 1, 0.0)
                                                                            sSGrid.SetText(15, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("GROUPCODE")) & "")
                                                                            sSGrid.SetText(17, i + 1, "Y")
                                                                            sSGrid.SetText(17, i, Type)
                                                                            sSGrid.SetText(20, i, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                            boolPromotional = True
                                                                            boolProm = True
                                                                        End If
                                                                        'Modified on 14 Mar'08
                                                                        'Mk Kannan
                                                                        'Begin
                                                                        'End
                                                                    End If
                                                                    'End If
                                                                End If
                                                            End If
                                                        ElseIf Type <> "QTY" Then
                                                            CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                                            sSGrid.Row = sSGrid.ActiveRow
                                                            sSGrid.Col = 5
                                                            Trim(sSGrid.Text)
                                                            If Val(Trim(sSGrid.Text)) Mod Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY"))) = 0 Then
                                                                If CHECK_AVAILABILITY > 0 Then
                                                                    If MessageBox.Show("Promotional available for this Itemcode!", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                                        'If Format(CDate(serverdate), "dd/MM/yyyy") = Format(CDate(dtp_KOTdate.Value), "dd/MM/yyyy") Then
                                                                        If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) <= CDate(Now) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) >= CDate(Now) Then
                                                                            CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                                                            If CHECK_AVAILABILITY = 0 Then
                                                                                If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                    sSGrid.ClearRange(1, i, sSGrid.MaxCols, i, True)
                                                                                    sSGrid.Focus()
                                                                                    sSGrid.SetActiveCell(0, i)
                                                                                    Exit Sub
                                                                                End If
                                                                            ElseIf CHECK_AVAILABILITY = 1 Then
                                                                                If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                    sSGrid.Col = 4
                                                                                    sSGrid.Text = ""
                                                                                    sSGrid.SetActiveCell(4, i)
                                                                                    sSGrid.Focus()
                                                                                    Exit Sub
                                                                                End If
                                                                            End If
                                                                            'If Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "RATE" Then
                                                                            If Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "FIXED RATE" Then
                                                                                sSGrid.SetText(6, i, Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE")))
                                                                                sSGrid.Row = i
                                                                                sSGrid.Col = 5
                                                                                If Val(sSGrid.Text) > 0 Then
                                                                                    ITEMQTY = Val(sSGrid.Text)
                                                                                    PROMAMT = Val((ITEMQTY * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))))
                                                                                    sSGrid.SetText(8, i, PROMAMT)
                                                                                    sSGrid.SetText(17, i, "Y")
                                                                                    boolPromotional = True
                                                                                    Call Calculate()
                                                                                End If
                                                                            ElseIf Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "DISCOUNT ON RATE" Then
                                                                                ActRate = ActRate - ((Val(ActRate) * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))) / 100)
                                                                                sSGrid.SetText(6, i, Val(ActRate))
                                                                                sSGrid.Row = i
                                                                                sSGrid.Col = 5
                                                                                If Val(sSGrid.Text) > 0 Then
                                                                                    ITEMQTY = Val(sSGrid.Text)
                                                                                    PROMAMT = Val(ActRate)
                                                                                    sSGrid.SetText(8, i, PROMAMT)
                                                                                    sSGrid.SetText(17, i, "Y")
                                                                                    boolPromotional = True
                                                                                    Call Calculate()
                                                                                End If
                                                                            Else
                                                                                sSGrid.SetText(1, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                                sSGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                                                sSGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                                                sSGrid.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                                                sSGrid.Row = i
                                                                                sSGrid.Col = 3
                                                                                sSGrid.Lock = True
                                                                                sSGrid.Row = i
                                                                                sSGrid.Col = 4
                                                                                sSGrid.Lock = True
                                                                                sSGrid.Row = i
                                                                                sSGrid.Col = 3
                                                                                sSGrid.Lock = True
                                                                                sSGrid.Row = i + 1
                                                                                sSGrid.Col = 4
                                                                                sSGrid.Lock = True
                                                                                sSGrid.Col = 17
                                                                                sSGrid.Row = sSGrid.ActiveRow
                                                                                If Trim(sSGrid.Text) = "Y" Then
                                                                                    sSGrid.Lock = False
                                                                                Else
                                                                                    sSGrid.Lock = True
                                                                                End If
                                                                                'sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                                                sSGrid.SetText(5, i + 1, Val(PROQTY_GRID))
                                                                                sSGrid.Row = i + 1
                                                                                sSGrid.Col = 5
                                                                                sSGrid.Lock = True
                                                                                sSGrid.SetText(6, i + 1, 0.0)
                                                                                sSGrid.SetText(7, i + 1, 0.0)
                                                                                sSGrid.SetText(8, i + 1, 0.0)
                                                                                sSGrid.SetText(9, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                                                sSGrid.SetText(11, i + 1, 0.0)
                                                                                sSGrid.SetText(15, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("GROUPCODE")) & "")
                                                                                sSGrid.SetText(17, i + 1, "Y")
                                                                                sSGrid.SetText(17, i, Type)
                                                                                sSGrid.SetText(20, i, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                                boolPromotional = True
                                                                                boolProm = True
                                                                            End If
                                                                            'Modified on 14 Mar'08
                                                                            'Mk Kannan
                                                                            'Begin
                                                                            'End
                                                                        End If
                                                                    End If
                                                                End If
                                                            Else
                                                                Sqlstring = "SELECT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                                                Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) ORDER BY R.ITEMRATE,R.UOM"
                                                                gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                                                If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                                                    sSGrid.Col = 4
                                                                    sSGrid.Row = sSGrid.ActiveRow
                                                                    sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                                                    sSGrid.Col = 6
                                                                    ''sSGrid.Row = sSGrid.ActiveRow
                                                                    ''If Val(PACKINGPERCENT) <> 0 Then
                                                                    ''    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                                                    ''    ''+ (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                                                    ''Else
                                                                    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                                                    'End If
                                                                    ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                                                    sSGrid.Col = 19
                                                                    sSGrid.Row = sSGrid.ActiveRow
                                                                    If Trim(sSGrid.Text) = "Y" Then
                                                                        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                                                    Else
                                                                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                                                    End If
                                                                Else
                                                                    sSGrid.Col = 4
                                                                    sSGrid.Col = 6
                                                                    sSGrid.Text = "0.00"
                                                                    sSGrid.Col = 19
                                                                    sSGrid.Row = sSGrid.ActiveRow
                                                                    If Trim(sSGrid.Text) = "Y" Then
                                                                        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                                                    Else
                                                                        sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                                                                    End If

                                                                End If

                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If

                                        CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                        If CHECK_AVAILABILITY = 0 Then
                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                sSGrid.ClearRange(1, i, sSGrid.MaxCols, i, True)
                                                sSGrid.Focus()
                                                sSGrid.SetActiveCell(0, i)
                                                Exit Sub
                                            End If
                                        ElseIf CHECK_AVAILABILITY = 1 Then
                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                sSGrid.Col = 4
                                                sSGrid.Text = ""
                                                sSGrid.SetActiveCell(4, i)
                                                sSGrid.Focus()
                                                Exit Sub
                                            End If
                                        End If
                                        '''************************************************************************************************
                                        Call Calculate()
                                        If boolPromotional = True Then
                                            sSGrid.Row = sSGrid.ActiveRow + 1
                                        Else
                                            sSGrid.Row = sSGrid.ActiveRow + 1
                                        End If

                                        sSGrid.Col = 1
                                        sSGrid.Lock = False
                                        sSGrid.Col = 2
                                        sSGrid.Lock = False
                                        sSGrid.Col = 3
                                        sSGrid.Lock = False
                                        sSGrid.Col = 4
                                        sSGrid.Lock = False
                                        sSGrid.Col = 5
                                        sSGrid.Lock = False
                                        sSGrid.Col = 17
                                        sSGrid.Row = sSGrid.ActiveRow
                                        If Trim(sSGrid.Text) = "Y" Then
                                            sSGrid.Lock = False
                                        Else
                                            sSGrid.Lock = True
                                        End If
                                        If boolPromotional = True Then
                                            If PROMAMT > 0 Then
                                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                                            End If
                                        Else
                                            sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                                        End If
                                        sSGrid.Col = 1
                                        sSGrid.Lock = False
                                        sSGrid.Col = 2
                                        sSGrid.Lock = False
                                        sSGrid.Col = 3
                                        sSGrid.Lock = False
                                        sSGrid.Col = 4
                                        sSGrid.Lock = False
                                        sSGrid.Col = 5
                                        sSGrid.Lock = False
                                        sSGrid.Col = 17
                                        sSGrid.Row = sSGrid.ActiveRow
                                        If Trim(sSGrid.Text) = "Y" Then
                                            sSGrid.Lock = False
                                        Else
                                            sSGrid.Lock = True
                                        End If
                                        If boolPromotional = True Then
                                            sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                            sSGrid.Focus()
                                        End If
                                        'boolPromotional = False
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf sSGrid.ActiveCol = 6 Then
                    sSGrid.Col = 6
                    sSGrid.Row = sSGrid.ActiveRow
                    If sSGrid.Lock = False Then
                        sSGrid.Col = 1
                        sSGrid.Row = sSGrid.ActiveRow
                        If Trim(sSGrid.Text) <> "" Then
                            sSGrid.Col = 6
                            sSGrid.Row = sSGrid.ActiveRow
                            If Val(sSGrid.Text) = 0 Then
                                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                Exit Sub
                            Else
                                Call Calculate()
                                sSGrid.Row = sSGrid.ActiveRow + 1
                                sSGrid.Col = 1
                                sSGrid.Lock = False
                                sSGrid.Col = 2
                                sSGrid.Lock = False
                                sSGrid.Col = 3
                                sSGrid.Lock = False
                                sSGrid.Col = 4
                                sSGrid.Lock = False
                                sSGrid.Col = 5
                                sSGrid.Lock = False
                                sSGrid.Col = 17
                                sSGrid.Row = sSGrid.ActiveRow
                                If Trim(sSGrid.Text) = "Y" Then
                                    sSGrid.Lock = False
                                Else
                                    sSGrid.Lock = True
                                End If
                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                            End If
                        End If
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                sSGrid.Col = 1
                sSGrid.Row = sSGrid.ActiveRow
                If sSGrid.Lock = False Then
                    sSGrid.Col = 3
                    sSGrid.Row = sSGrid.ActiveRow
                    If sSGrid.ActiveCol = 3 Then
                        If sSGrid.Lock = False Then
                            Itemcode = Nothing
                            i = sSGrid.ActiveRow
                            sSGrid.Col = 1
                            sSGrid.Row = i
                            Itemcode = Trim(sSGrid.Text)

                            Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M ON P.POS=M.POSCODE WHERE P.ITEMCODE='" & Trim(Itemcode) & "' ORDER BY POSCODE"
                            gconnection.getDataSet(Sqlstring, "POSMENULINK")
                            If gdataset.Tables("POSMENULINK").Rows.Count > 0 Then
                                If gdataset.Tables("POSMENULINK").Rows.Count > 1 Then
                                    sSGrid.Col = 3
                                    sSGrid.Row = i
                                    Call FillPosList(gdataset.Tables("PosMenuLink"))
                                    Me.lvw_POSCode.FullRowSelect = True
                                    pnl_POSCode.Top = 50
                                    pnl_POSCode.Focus()
                                    lvw_POSCode.Focus()
                                Else
                                    sSGrid.Col = 3
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = gdataset.Tables("POSMENULINK").Rows(0).Item(0)
                                    sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                End If
                            Else
                                sSGrid.Col = 1
                                sSGrid.Row = sSGrid.ActiveRow
                                sSGrid.Focus()
                            End If
                        End If
                    ElseIf sSGrid.ActiveCol = 4 Then
                        sSGrid.Col = 4
                        sSGrid.Row = sSGrid.ActiveRow
                        If sSGrid.Lock = False Then
                            Itemcode = Nothing
                            i = sSGrid.ActiveRow
                            sSGrid.Col = 1
                            sSGrid.Row = i
                            Itemcode = Trim(sSGrid.Text)
                            Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                            Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) "
                            gconnection.getDataSet(Sqlstring, "ITEMRATE")
                            If gdataset.Tables("ITEMRATE").Rows.Count > 0 Then
                                If gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                                    sSGrid.Col = 4
                                    sSGrid.Row = i
                                    Call FillUomList(gdataset.Tables("ITEMRATE"))
                                    Me.lvw_Uom.FullRowSelect = True
                                    pnl_UOMCode.Top = 50
                                    Me.lvw_Uom.Focus()

                                Else
                                    sSGrid.Col = 4
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")
                                    sSGrid.Col = 6
                                    sSGrid.Row = sSGrid.ActiveRow
                                    sSGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")
                                    sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                                End If
                            Else
                                sSGrid.Col = 1
                                sSGrid.Row = sSGrid.ActiveRow
                                sSGrid.Focus()
                            End If
                        End If
                    ElseIf sSGrid.ActiveCol = 1 Or sSGrid.ActiveCol = 5 Then

                        'End If

                        'AS PER SIVAJI REQUIREMENT  ON 05/05/2008 WE ARE BLOCKING THEIS FUNCTION
                        ' ElseIf e.keyCode = Keys.F12 Then
                        If Mid(Me.Cmd_Add.Text, 1, 1) <> "U" Then
                            sSGrid.Row = sSGrid.ActiveRow
                            sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                            sSGrid.DeleteRows(sSGrid.ActiveRow, 1)
                            Call Calculate()
                            sSGrid.Row = sSGrid.ActiveRow
                            sSGrid.Col = 1
                            sSGrid.Lock = False
                            sSGrid.Col = 2
                            sSGrid.Lock = False
                            sSGrid.Col = 3
                            sSGrid.Lock = False
                            sSGrid.Col = 4
                            sSGrid.Lock = False
                            sSGrid.Col = 5
                            sSGrid.Lock = False
                            sSGrid.Col = 17
                            sSGrid.Row = sSGrid.ActiveRow
                            If Trim(sSGrid.Text) = "Y" Then
                                sSGrid.Lock = False
                            Else
                                sSGrid.Lock = True
                            End If
                            sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                        End If

                    End If
                End If
            End If
            Call GridLockRate()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillMenu()
        Dim vform As New LIST_OPERATION1
        Dim ssql, COMPNAME As String
        Dim k, cct As Integer
        cct = 0
        Dim itc As String
        ssql = "SELECT ISNULL(COMPNAME,'')AS COMPNAME FROM POSSETUP "
        gconnection.getDataSet(ssql, "COMP")
        If gdataset.Tables("COMP").Rows.Count > 0 Then
            COMPNAME = gdataset.Tables("COMP").Rows(0).Item("COMPNAME")
        End If
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO sSGrid ********** 
        gSQLString = "SELECT DISTINCT I.ITEMCODE,I.ITEMDESC,I.BASERATESTD,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE, '' "
        gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.subGroupCode,'') AS subGroupCode,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN,ISNULL(I.OPENFACILITY,'')AS OPENFACILITY FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode INNER "
        If gCenterlized = "Y" Then
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
        Else
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
        End If

        If Trim(Search) = " " Then
            If gCenterlized = "Y" Then
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink)"
            Else
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "')"
            End If
        Else
            If gCenterlized = "Y" Then
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink) AND (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            Else
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "' ) and (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            End If
        End If
        vform.Field = "I.ITEMDESC,I.ITEMCODE"
        'vform.vFormatstring = "ITEMCODE     |ITEM DESCRIPTION                       |  BASERATESTD  |  ITEMTYPE  |  TAXCODE  | TAXPERCENTAGE | ACCOUNTCODE |  GROUPCODE  |  SUBGROUPCODE  |SALESACCTIN|OPENFACILITY|"
        vform.vCaption = "ITEM CODE HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        'vform.Keypos5 = 5
        'vform.Keypos6 = 6
        'vform.Keypos7 = 7
        'vform.Keypos8 = 8
        'vform.keypos9 = 9
        'vform.Keypos10 = 10
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With sSGrid
                .Col = 1
                .Row = .ActiveRow
                .Text = vform.keyfield
                .Col = 2
                .Row = .ActiveRow
                .Text = vform.keyfield1
                .Col = 9
                .Row = .ActiveRow
                .Text = vform.keyfield3
                .Col = 10
                .Row = .ActiveRow
                .Text = vform.keyfield4
                .Col = 11
                .Row = .ActiveRow
                .Text = vform.keyfield5
                .Col = 13
                .Row = .ActiveRow
                .Text = vform.keyfield6
                .Col = 15
                .Row = .ActiveRow
                .Text = vform.keyfield7
                .Col = 16
                .Row = .ActiveRow
                .Text = vform.keyfield8
                .Col = 17
                .Row = .ActiveRow
                .Text = vform.keyfield9
                .Col = 18
                .Row = .ActiveRow
                .Text = vform.keyfield7
                .Col = 20
                .Row = .ActiveRow
                .Text = vform.keyfield10
            End With
        Else
            sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
            Exit Sub
        End If
        If Trim(sSGrid.Text) <> "" Then
            sSGrid.GetText(1, sSGrid.ActiveRow, itc)
            For k = 1 To sSGrid.DataRowCnt
                sSGrid.Col = 1
                sSGrid.Row = k
                If Trim(sSGrid.Text) = itc Then
                    cct = cct + 1
                    'MsgBox("duplicate item entry")
                    'Exit For
                End If

            Next
        End If
        If cct > 1 Then
            MsgBox("duplicate item entry")
        End If
        ' End If
        If Trim(vform.keyfield) <> "" Then
            '''*********************************************** $ FILL POSCODE INTO sSGrid $ *********************************************'''
            '''
            If gCenterlized = "Y" Then
                SQLSTRING = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(vform.keyfield) & "' AND ISNULL(M.FREEZE,'') <>'Y' "
            Else
                SQLSTRING = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(vform.keyfield) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "'"
            End If
            gconnection.getDataSet(SQLSTRING, "PosMenuLink")
        
            If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                Call FillPosList(gdataset.Tables("PosMenuLink"))
                Me.lvw_POSCode.FullRowSelect = True
                pnl_POSCode.Top = 50
                lvw_POSCode.Focus()
                Exit Sub
                'sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
            Else
                sSGrid.Col = 3
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item(0)
                'If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item(2)) = False Then
                '    If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item(2))) <> "" Then
                '        sSGrid.Col = 14
                '        sSGrid.Row = sSGrid.ActiveRow
                '        If sSGrid.Text = "" Then
                '            sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item(2)
                '        End If
                '    Else
                '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '        Exit Sub
                '    End If
                'Else
                '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '    Exit Sub
                'End If
                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
            End If
            '''************************************************* $ FILL UOM , RATE INTO sSGrid $ **************************************************'''
            gSQLString = "SELECT DISTINCT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE "
            gSQLString = gSQLString & " FROM VIEW_ITEMMASTER AS I INNER JOIN "
            gSQLString = gSQLString & " RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
            gSQLString = gSQLString & "WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(vform.keyfield) & "' ) "
            gconnection.getDataSet(gSQLString, "ITEMRATE")
            If gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                Call FillUomList(gdataset.Tables("ITEMRATE"))
                If sSGrid.ActiveCol = 5 Then
                    '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                    Me.lvw_Uom.FullRowSelect = True
                    pnl_UOMCode.Top = 50
                    Me.lvw_Uom.Focus()
                    '''***************************************** $ COMPLETE POPUP FOR VARIOUS UOM $ ******************************************************''
                End If
            Else
                sSGrid.Col = 4
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")
                sSGrid.Col = 6
                sSGrid.Row = sSGrid.ActiveRow
                'If Val(PACKINGPERCENT) <> 0 Then
                '    sSGrid.Text = Math.Round(Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) + (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                'Else
                sSGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")
                'End If
                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
            End If
            '''**************************************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''

            gSQLString = "SELECT promitemcode,VIEW_ITEMMASTER.itemdesc,promotional,promuom,promqty,promrate, "
            gSQLString = gSQLString & "posmenulink.pos FROM VIEW_ITEMMASTER INNER JOIN posmenulink on VIEW_ITEMMASTER.itemcode=posmenulink.itemcode "
            gSQLString = gSQLString & "WHERE VIEW_ITEMMASTER.itemcode='" & vform.keyfield & "' "
            gconnection.getDataSet(gSQLString, "Promotional")

            If Trim(gdataset.Tables("Promotional").Rows(0).Item("Promotional")) = "Y" Then
                gSQLString = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                gSQLString = gSQLString & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                gSQLString = gSQLString & " POSMASTER AS P ON PL.POS = P.POSCODE "
                gSQLString = gSQLString & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                gSQLString = gSQLString & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & gdataset.Tables("Promotional").Rows(0).Item("promitemcode") & "') AND (I.ITEMCODE = '" & vform.keyfield & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                gconnection.getDataSet(gSQLString, "Promotional")
                If gdataset.Tables("Promotional").Rows.Count > 0 Then
                    If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                        If CDate(gdataset.Tables("Promotional").Rows(0).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("Promotional").Rows(0).Item("StartingDate")) >= CDate(Now.Today) Then
                            sSGrid.SetText(1, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromItemcode")) & "")
                            sSGrid.SetText(2, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemDesc")) & "")
                            sSGrid.SetText(3, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("POSCode")) & "")
                            sSGrid.SetText(4, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromUOM")) & "")
                            sSGrid.SetText(5, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromQty")) & "")
                            sSGrid.SetText(6, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(7, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(8, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(9, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemTypecode")) & "")
                         
                            sSGrid.SetText(11, sSGrid.ActiveRow + 1, 0.0)
                            boolPromotional = True
                            sSGrid.SetText(17, sSGrid.ActiveRow + 1, "Y")
                        End If
                    End If
                End If
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FillMenuItem()
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMDESC,ITEMCODE INTO sSGrid ********** 
        gSQLString = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.BASERATESTD,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE, '' "
        gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN,ISNULL(I.OPENFACILITY,'')AS OPENFACILITY FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode INNER "
        If gCenterlized = "Y" Then
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
        Else
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
        End If

        If Trim(Search) = " " Then
            If gCenterlized = "Y" Then
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink )"
            Else
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "')"
            End If
        Else
            If gCenterlized = "Y" Then
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink ) and (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            Else
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "' ) and (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            End If
        End If
        vform.Field = "I.ITEMDESC,I.ITEMCODE"
        'vform.vFormatstring = "              ITEMDESC            |     ITEMCODE     | RATE    |  ITEMTYPE  |  TAXCODE  | TAXPERCENTAGE | TAX.ACCOUNTCODE |  GROUPCODE  |  SUBGROUPCODE  | OPENFACILITY | SALESACCTIN|"
        vform.vCaption = "ITEM DESC HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        'vform.Keypos5 = 5
        'vform.Keypos6 = 6
        'vform.Keypos7 = 7
        'vform.Keypos8 = 8
        'vform.keypos9 = 9
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With sSGrid
                .Col = 1
                .Row = .ActiveRow
                .Text = CStr(vform.keyfield1)
                .Col = 2
                .Row = .ActiveRow
                .Text = CStr(vform.keyfield)
                .Col = 9
                .Row = .ActiveRow
                .Text = vform.keyfield3
                .Col = 10
                .Row = .ActiveRow
                .Text = vform.keyfield4
                .Col = 11
                .Row = .ActiveRow
                .Text = vform.keyfield5
                .Col = 13
                .Row = .ActiveRow
                .Text = vform.keyfield6
                .Col = 14
                .Row = .ActiveRow
                .Text = vform.keyfield8
                .Col = 15
                .Row = .ActiveRow
                .Text = vform.keyfield7
                .Col = 20
                .Row = .ActiveRow
                .Text = vform.keyfield10

                If Trim(CStr(vform.keyfield7)) = "Y" Then
                    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                Else
                    sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                End If
                'End
            End With
        Else
            sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
            Exit Sub
        End If
        If Trim(vform.keyfield1) <> "" Then
            '''*********************************************** $ FILL POSCODE INTO sSGrid $ ********************************************************'''
            If gCenterlized = "Y" Then
                ssql = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M ON P.POS=M.POSCODE WHERE ITEMCODE='" & vform.keyfield1 & "'AND ISNULL(M.FREEZE,'')<>'Y' ORDER BY POSCODE"
            Else
                ssql = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M ON P.POS=M.POSCODE WHERE ITEMCODE='" & vform.keyfield1 & "'AND ISNULL(M.FREEZE,'')<>'Y' AND P.POS='" & Trim(STRPOSCODE) & "' ORDER BY POSCODE"
            End If
            gconnection.getDataSet(ssql, "POSMENULINK")
            If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                '''***************************************** $ SHOW POPUP FOR VARIOUS POS LOC $ ******************************************************''
                Call FillPosList(gdataset.Tables("POSMENULINK"))
                Me.lvw_POSCode.FullRowSelect = True
                pnl_POSCode.Top = 50
                lvw_POSCode.Focus()
                sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                Exit Sub
            Else
                sSGrid.Col = 3
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("POSMENULINK").Rows(0).Item(0)
                'If IsDBNull(gdataset.Tables("POSMENULINK").Rows(0).Item(2)) = False Then
                '    If Trim((gdataset.Tables("POSMENULINK").Rows(0).Item(2))) <> "" Then
                '        sSGrid.Col = 14
                '        sSGrid.Row = sSGrid.ActiveRow
                '        ''sSGrid.Text = gdataset.Tables("POSMENULINK").Rows(0).Item(2)
                '        ''sSGrid.Text = vform.keyfield8
                '    Else
                '        MsgBox("Account Code For The Location  " & gdataset.Tables("POSMENULINK").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '        Exit Sub
                '    End If
                'Else
                '    MsgBox("Account Code For The Location  " & gdataset.Tables("POSMENULINK").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '    Exit Sub
                'End If
                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
            End If
            '''************************************************* $ FILL UOM , RATE INTO sSGrid $ **************************************************'''
            gSQLString = "SELECT DISTINCT R.UOM, R.ItemRate "
            gSQLString = gSQLString & "FROM VIEW_ITEMMASTER AS I INNER JOIN "
            gSQLString = gSQLString & "RateMaster AS R ON I.ItemCode = R.ItemCode "
            gSQLString = gSQLString & "WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ItemCode = '" & Trim(vform.keyfield1) & "' ) AND ISNULL(I.freeze,'')<>'Y' "
            gconnection.getDataSet(gSQLString, "ItemRate")
            If gdataset.Tables("ItemRate").Rows.Count > 1 Then
                Call FillUomList(gdataset.Tables("ItemRate"))
                If sSGrid.ActiveCol = 5 Then
                    '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                    Me.lvw_Uom.FullRowSelect = True
                    pnl_UOMCode.Top = 50
                    Me.lvw_Uom.Focus()
                End If
            Else
                sSGrid.Col = 4
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("ItemRate").Rows(0).Item("UOM")
                sSGrid.Col = 6
                sSGrid.Row = sSGrid.ActiveRow
                'If Val(PACKINGPERCENT) <> 0 Then
                '    sSGrid.Text = Math.Round(Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) + (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                'Else
                sSGrid.Text = gdataset.Tables("ItemRate").Rows(0).Item("ItemRate")
                'End If
                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
            End If
            '''**************************************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
            gSQLString = "SELECT promitemcode,VIEW_ITEMMASTER.itemdesc,ISNULL(promotional,'') AS promotional,promuom,promqty,promrate, "
            gSQLString = gSQLString & " posmenulink.pos FROM VIEW_ITEMMASTER INNER JOIN posmenulink on VIEW_ITEMMASTER.itemcode=posmenulink.itemcode "
            gSQLString = gSQLString & "WHERE VIEW_ITEMMASTER.itemcode='" & vform.keyfield1 & "' AND ISNULL(VIEW_ITEMMASTER.freeze,'')<>'Y'"
            gconnection.getDataSet(gSQLString, "Promotional")
            If Trim(gdataset.Tables("Promotional").Rows(0).Item("Promotional")) = "Y" Then

                'Modified on 14 Mar'08
                'Mk Kannan
                'Begin
                gSQLString = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                gSQLString = gSQLString & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                gSQLString = gSQLString & " POSMASTER AS P ON PL.POS = P.POSCODE "
                gSQLString = gSQLString & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                gSQLString = gSQLString & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & gdataset.Tables("Promotional").Rows(0).Item("promitemcode") & "') AND (I.ITEMCODE = '" & vform.keyfield & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                'gSQLString = "SELECT dbo.VIEW_ITEMMASTER.PromQty, dbo.VIEW_ITEMMASTER.ItemCode,dbo.VIEW_ITEMMASTER.PromItemcode, dbo.VIEW_ITEMMASTER.ItemDesc,dbo.VIEW_ITEMMASTER.ItemTypecode, dbo.POSMaster.POSCode, dbo.POSMaster.POSDesc,dbo.VIEW_ITEMMASTER.StartingDate,dbo.VIEW_ITEMMASTER.EndingDate,"
                'gSQLString = gSQLString & " dbo.VIEW_ITEMMASTER.PromUOM, dbo.VIEW_ITEMMASTER.PromQty, dbo.VIEW_ITEMMASTER.PromRate FROM dbo.VIEW_ITEMMASTER INNER JOIN dbo.POSMenulink ON dbo.VIEW_ITEMMASTER.ItemCode = dbo.POSMenulink.ItemCode INNER JOIN"
                'gSQLString = gSQLString & " dbo.POSMaster ON dbo.POSMenulink.Pos = dbo.POSMaster.POSCode WHERE (dbo.VIEW_ITEMMASTER.Promotional = 'Y') AND (dbo.VIEW_ITEMMASTER.PromItemcode = '" & gdataset.Tables("Promotional").Rows(0).Item("promitemcode") & "') AND (dbo.VIEW_ITEMMASTER.itemcode = '" & vform.keyfield & "') "
                'End

                gconnection.getDataSet(gSQLString, "Promotional")
                If gdataset.Tables("Promotional").Rows.Count > 0 Then
                    If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                        If CDate(gdataset.Tables("Promotional").Rows(0).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("Promotional").Rows(0).Item("StartingDate")) >= CDate(Now.Today) Then
                            sSGrid.SetText(1, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromItemcode")) & "")
                            sSGrid.SetText(2, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemDesc")) & "")
                            sSGrid.SetText(3, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("POSCode")) & "")
                            sSGrid.SetText(4, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromUOM")) & "")
                            sSGrid.SetText(5, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromQty")) & "")
                            sSGrid.SetText(6, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(7, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(8, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(9, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemTypecode")) & "")
                            'Modified on 14 Mar'08
                            'Mk Kannan
                            'Begin
                            sSGrid.SetText(11, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(17, sSGrid.ActiveRow + 1, "Y")
                            boolPromotional = True
                            'End
                        End If
                    End If
                End If
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FillPosList(ByVal PosTable As DataTable)
        Dim lvw As New ListViewItem
        Dim i As Integer
        lvw_POSCode.Items.Clear()
        For i = 0 To PosTable.Rows.Count - 1
            lvw = lvw_POSCode.Items.Add(PosTable.Rows(i).Item(0))
            lvw.SubItems.Add(PosTable.Rows(i).Item(1))
            lvw.SubItems.Add(PosTable.Rows(i).Item(2))
        Next i
    End Sub
    Private Sub FillUomList(ByVal UomTable As DataTable)
        Dim lvw As New ListViewItem
        Dim i As Integer
        lvw_Uom.Items.Clear()
        For i = 0 To UomTable.Rows.Count - 1
            lvw = lvw_Uom.Items.Add(UomTable.Rows(i).Item("UOM"))
            lvw.SubItems.Add(UomTable.Rows(i).Item("ITEMRATE"))
        Next i
    End Sub

    Private Sub lvw_POSCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lvw_POSCode.KeyPress
        Dim strSQL As String
        Dim posloc As String
        Dim acctin As String
        If Asc(e.KeyChar) = 13 Then
            Try
                posloc = Trim(lvw_POSCode.SelectedItems(0).SubItems(0).Text)
                acctin = Trim(lvw_POSCode.SelectedItems(0).SubItems(2).Text)
            Catch ex As Exception
                posloc = Trim(lvw_POSCode.Items(0).SubItems(0).Text)
                acctin = Trim(lvw_POSCode.Items(0).SubItems(2).Text)
            Finally
                If Trim(acctin) <> "" Or Trim(acctin) = "" Then
                    sSGrid.SetText(3, sSGrid.ActiveRow, posloc)
                    ''sSGrid.SetText(14, sSGrid.ActiveRow, acctin)
                    pnl_POSCode.Top = 1000
                    sSGrid.Focus()
                    sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                Else
                    MsgBox("Sales Account In Not Defined", MsgBoxStyle.Critical)
                End If
            End Try
        End If
    End Sub
    Private Sub lvw_Uom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lvw_Uom.KeyPress
        Try
            Dim strSQL As String
            Dim uomcode, uomrate As String
            If Asc(e.KeyChar) = 13 Then
                Try
                    uomcode = Trim(lvw_Uom.SelectedItems(0).SubItems(0).Text)
                    uomrate = Trim(lvw_Uom.SelectedItems(0).SubItems(1).Text)
                Catch ex As Exception
                    uomcode = Trim(lvw_Uom.Items(0).SubItems(0).Text)
                    uomrate = Trim(lvw_Uom.Items(0).SubItems(1).Text)
                Finally
                    sSGrid.SetText(4, sSGrid.ActiveRow, uomcode)
                    sSGrid.SetText(6, sSGrid.ActiveRow, uomrate)
                    pnl_UOMCode.Top = 1000
                    sSGrid.Focus()
                    sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                End Try
            End If
        Catch
        End Try
    End Sub
    Private Sub Calculate()
        Dim qty, taxperc, cancel, kotstatus, rate, varposcode As String
        Dim total, Taxamount, cancelamt, canceltax, Billamount, Packingamt, TIPSAMT As Double
        Dim i As Integer
        With sSGrid
            '   If .ActiveCol = 5 Or .ActiveCol = 4 Or .ActiveCol = 1 Then
            'Me.txt_TaxValue.Text = "0.00"
            'Me.txt_TotalValue.Text = "0.00"
            'Me.Txt_PackingValue.Text = "0.00"
            'Me.txt_BillAmount.Text = "0.00"
            For i = 1 To .DataRowCnt
                sSGrid.Row = i
                sSGrid.Col = 3
                .Col = 12
                .Row = i
                kotstatus = .Text
                If Trim(kotstatus) = "NO" Or Trim(kotstatus) = "" Then
                    .Col = 5
                    .Row = i
                    qty = .Text
                    .Col = 6
                    .Row = i
                    rate = .Text
                    .Col = 11
                    .Row = i
                    taxperc = Val(.Text)
                    If Val(rate) > 0 Then
                        total = (Val(qty) * Val(rate))
                    Else
                        total = 0
                    End If
                    Taxamount = (total) * (taxperc / 100)
                    .SetText(8, i, total)
                    .SetText(7, i, Taxamount)
                    'Billamount = Format(Val(Me.txt_TaxValue.Text) + Val(Me.txt_TotalValue.Text) + Val(Me.txt_TaxValue.Text) + Val(Me.TXT_TIPS.Text), "0.00")
                    'If BILLROUNDYESNO = "YES" Then
                    '    Me.txt_BillAmount.Text = Format(Math.Round(Billamount), "0.00")
                    'Else
                    '    Me.txt_BillAmount.Text = Format(Billamount, "0.00")
                    'End If
                End If
            Next i
            '+ Val(Me.Txt_PackingValue.Text)
            '+ Val(txt_sertax_value.Text)
            'txt_sertax_value.Text = Format(((Val(Me.txt_TotalValue.Text) * PACKINGPERCENT) / 100), "0.00")
            'Me.TXT_TIPS.Text = Format(((Val(Me.txt_TotalValue.Text) * TIPSPERCENT) / 100), "0.00")
            'Billroundoff = Val(Me.txt_TaxValue.Text) + Val(Me.txt_TotalValue.Text) + Val(txt_sertax_value.Text) + Val(Me.TXT_TIPS.Text)
            'If BILLROUNDYESNO = "YES" Then
            '    Me.txt_BillAmount.Text = Format(Math.Round(Billroundoff), "0.00")
            'Else
            '    Me.txt_BillAmount.Text = Format(Billroundoff, "0.00")
            'End If

            'End If
        End With
        i = i - 1
    End Sub
    Private Sub sSGrid_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles sSGrid.LeaveCell
        Dim Sqlstring, Itemcode, Itemdesc, Promtcode, UOMCODE, itc As String
        Dim varitemcode, varitemdesc, varposcode As String
        Dim RATE As Double
        Dim i, j, k, cct As Integer
        cct = 0
        Dim qty As String
        Call Calculate()
        Try
            i = sSGrid.ActiveRow
            If sSGrid.ActiveCol = 1 Then
                sSGrid.Col = 1
                sSGrid.Row = i
                'If sSGrid.Lock = False Then
                If Trim(sSGrid.Text) <> "" Then
                    'sSGrid.GetText(1, i, itc)
                    'For k = 1 To sSGrid.DataRowCnt
                    '    sSGrid.Col = 1
                    '    sSGrid.Row = k
                    '    If Trim(sSGrid.Text) = itc Then
                    '        cct = cct + 1
                    '        'MsgBox("duplicate item entry")
                    '        'Exit For
                    '    End If

                    'Next
                End If
                'End If
                'If cct > 1 Then
                '    MsgBox("duplicate item entry")
                'End If
            ElseIf sSGrid.ActiveCol = 2 Then
                sSGrid.Col = 1
                sSGrid.Row = i
                If sSGrid.Lock = False Then
                    If Trim(sSGrid.Text) <> "" Then
                        Itemcode = Trim(sSGrid.Text)
                        Sqlstring = "SELECT ITEMDESC FROM ITEMMASTER WHERE ITEMCODE='" & Itemcode & "'"
                        gconnection.getDataSet(Sqlstring, "RR")
                        If gdataset.Tables("RR").Rows.Count > 0 Then
                            sSGrid.Col = 2
                            sSGrid.Row = i
                            sSGrid.Text = Trim(gdataset.Tables("RR").Rows(0).Item("Itemdesc"))
                        Else
                            MsgBox("ITEMNAME NOT FOUND")
                            sSGrid.Col = 2
                            sSGrid.Row = i
                            sSGrid.Text = ""
                        End If
                        sSGrid.Col = 3
                        sSGrid.Row = i
                        If Trim(sSGrid.Text) = "" Then
                            sSGrid.Row = i
                            sSGrid.Col = 2
                            varitemdesc = Trim(sSGrid.Text)
                            sSGrid.Col = 3
                            varposcode = Trim(sSGrid.Text)
                            sSGrid.Col = 1
                            Itemcode = Trim(sSGrid.Text)
                            If Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
                                Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "') and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                gconnection.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                    sSGrid.SetText(1, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "")
                                    sSGrid.SetText(2, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")) & "")
                                    sSGrid.SetText(9, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")) & "")
                                    sSGrid.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")) & "")
                                    sSGrid.SetText(11, i, Val(gdataset.Tables("ITE2MCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    sSGrid.SetText(13, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    sSGrid.SetText(14, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("salesacctin")))
                                    sSGrid.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    sSGrid.SetText(16, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("SUBGROUPCODE")))
                                    sSGrid.SetText(20, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                    Else
                                        sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    End If


                                    '''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("Promotional")) = "Y" Then
                                        Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PromItemcode"))

                                        'Modified on 14 Mar'08
                                        'Mk Kannan
                                        'Begin
                                        'Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, I.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        'Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                        'Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                        Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                        Sqlstring = Sqlstring & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                        Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                        'End

                                        gconnection.getDataSet(Sqlstring, "PROMOTIONAL")
                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                            If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) >= CDate(Now.Today) Then
                                                    sSGrid.SetText(1, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                    sSGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                    sSGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                    sSGrid.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                    sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                    sSGrid.SetText(6, i + 1, 0.0)
                                                    sSGrid.SetText(7, i + 1, 0.0)
                                                    sSGrid.SetText(8, i + 1, 0.0)
                                                    sSGrid.SetText(9, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                    'Modified on 14 Mar'08
                                                    'Mk Kannan
                                                    'Begin
                                                    sSGrid.SetText(11, i + 1, 0.0)
                                                    sSGrid.SetText(17, i + 1, "Y")
                                                    boolPromotional = True
                                                    'End
                                                End If
                                            End If
                                        End If
                                    End If
                                    '''*************************** $ COMPLETE PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    '''****************************** TO FILL POSCODE **********************************************************************'''
                                    Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    gconnection.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count = 1 Then
                                        sSGrid.Col = 3
                                        sSGrid.Row = sSGrid.ActiveRow
                                        sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE")
                                        If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")) = False Then
                                            If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                                sSGrid.Col = 14
                                                sSGrid.Row = sSGrid.ActiveRow
                                                ' sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")
                                            Else
                                                MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                                sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                                Exit Sub
                                            End If
                                        Else
                                            MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                            sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                            sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                            Exit Sub
                                        End If
                                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) "
                                        gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                            sSGrid.Col = 4
                                            sSGrid.Row = sSGrid.ActiveRow
                                            sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                            sSGrid.Col = 6
                                            sSGrid.Row = sSGrid.ActiveRow
                                            'If Val(PACKINGPERCENT) <> 0 Then
                                            '    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                            '    '' + (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                            'Else
                                            sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                            'End If
                                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            End If
                                        Else
                                            sSGrid.Col = 6
                                            sSGrid.Text = "0.00"
                                            sSGrid.Col = 4
                                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            sSGrid.Col = 19
                                            sSGrid.Row = sSGrid.ActiveRow
                                            If Trim(sSGrid.Text) = "Y" Then
                                                sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                                            Else
                                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            End If
                                        End If
                                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                    Else
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                        Exit Sub
                                    End If
                                    '''****************************** COMPLETE FILLING TO FILL POSCODE ******************************************************'''
                                Else
                                    MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                    sSGrid.Lock = False
                                    sSGrid.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If

            ElseIf sSGrid.ActiveCol = 3 Then
                sSGrid.Col = 1
                sSGrid.Row = sSGrid.ActiveRow
                Itemcode = sSGrid.Text
                sSGrid.Col = 3
                sSGrid.Row = sSGrid.ActiveRow
                POScode = sSGrid.Text

                If sSGrid.Lock = False Then
                    '    If Trim(sSGrid.Text) = "" Then
                    '        'sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                    '        Exit Sub
                    '    End If
                    'Sqlstring = "SELECT POS FROM POSMENULINK WHERE POS='" & POScode & "'AND ITEMCODE='" & Itemcode & "'"
                    'gconnection.getDataSet(Sqlstring, "TR")
                    'If gdataset.Tables("TR").Rows.Count > 0 Then
                    'Else
                    '    MsgBox("POSCODE ALTERED PLEASE CHECK")
                    '    sSGrid.Text = ""
                    'End If
                End If

            ElseIf sSGrid.ActiveCol = 4 Then
                sSGrid.Col = 4
                sSGrid.Row = sSGrid.ActiveRow
                If sSGrid.Lock = False Then
                    If Trim(sSGrid.Text) = "" Then
                        sSGrid.Col = 1
                        sSGrid.Row = sSGrid.ActiveRow
                        Itemcode = Trim(sSGrid.Text)
                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' )"
                        gconnection.getDataSet(Sqlstring, "ITEMRATE")
                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                            sSGrid.Col = 4
                            sSGrid.Row = sSGrid.ActiveRow
                            sSGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                            sSGrid.Col = 6
                            sSGrid.Row = sSGrid.ActiveRow
                            'If Val(PACKINGPERCENT) <> 0 Then
                            '    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                            '    ''+ (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                            'Else
                            sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                            'End If
                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)

                            sSGrid.Col = 19
                            sSGrid.Row = sSGrid.ActiveRow
                            If Trim(sSGrid.Text) = "Y" Then
                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                            Else
                                sSGrid.Col = 6
                                sSGrid.Row = sSGrid.ActiveRow
                                sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                            End If

                        ElseIf gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                            sSGrid.Col = 4
                            Call FillUomList(gdataset.Tables("ITEMRATE"))
                            Me.lvw_Uom.FullRowSelect = True
                            pnl_UOMCode.Top = 50
                            Me.lvw_Uom.Focus()
                            Exit Sub
                        Else
                            sSGrid.Col = 1
                            sSGrid.Row = sSGrid.ActiveRow
                            If Trim(sSGrid.Text) <> "" Then
                                sSGrid.Col = 4
                                sSGrid.Text = ""
                                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                            End If
                        End If
                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                    Else
                        sSGrid.Col = 1
                        sSGrid.Row = sSGrid.ActiveRow
                        Itemcode = Trim(sSGrid.Text)
                        sSGrid.Col = 4
                        sSGrid.Row = sSGrid.ActiveRow
                        UOMCODE = Trim(sSGrid.Text)
                        sSGrid.Col = 6
                        sSGrid.Row = sSGrid.ActiveRow
                        RATE = Trim(sSGrid.Text)
                        'Sqlstring = "SELECT UOM FROM RATEMASTER WHERE ITEMCODE='" & Itemcode & "' AND UOM='" & UOMCODE & "'AND ITEMRATE='" & Val(RATE) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN STARTINGDATE AND ISNULL(ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  "
                        'gconnection.getDataSet(Sqlstring, "RAT")
                        'If gdataset.Tables("RAT").Rows.Count > 0 Then
                        'Else
                        '    MsgBox("UOM ALTERED PLEASE CHECK")
                        '    sSGrid.Col = 4
                        '    sSGrid.Row = sSGrid.ActiveRow
                        '    sSGrid.Text = ""
                        'End If
                    End If
                End If

            ElseIf sSGrid.ActiveCol = 5 Then
                Dim CHECK_AVAILABILITY As Integer
                sSGrid.Col = 5
                sSGrid.Row = sSGrid.ActiveRow
                If sSGrid.Lock = False Then
                    sSGrid.Col = 1
                    sSGrid.Row = sSGrid.ActiveRow
                    If Trim(sSGrid.Text) <> "" Then
                        sSGrid.Col = 5
                        sSGrid.Row = sSGrid.ActiveRow
                        If Val(sSGrid.Text) = 0 Then
                            sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
                            Exit Sub
                        Else
                            '' Call Calculate()
                            sSGrid.Col = 19
                            sSGrid.Row = sSGrid.ActiveRow
                            If Trim(sSGrid.Text) = "Y" Then
                                sSGrid.Col = 6
                                sSGrid.Lock = False
                                sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
                                Exit Sub
                            Else
                                CHECK_AVAILABILITY = STOCKAVAILABILITY(sSGrid, i)
                                If CHECK_AVAILABILITY = 0 Then
                                    If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                        sSGrid.ClearRange(1, i, sSGrid.MaxCols, i, True)
                                        sSGrid.Focus()
                                        sSGrid.SetActiveCell(1, i)
                                        Exit Sub
                                    End If
                                ElseIf CHECK_AVAILABILITY = 1 Then
                                    If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                        sSGrid.Col = 4
                                        sSGrid.Text = ""
                                        sSGrid.SetActiveCell(4, i)
                                        sSGrid.Focus()
                                        Exit Sub
                                    End If
                                End If
                                Call Calculate()
                                sSGrid.Row = sSGrid.ActiveRow + 1
                                sSGrid.Col = 1
                                sSGrid.Lock = False
                                sSGrid.Col = 2
                                sSGrid.Lock = False
                                sSGrid.Col = 3
                                sSGrid.Lock = False
                                sSGrid.Col = 4
                                sSGrid.Lock = False
                                sSGrid.Col = 5
                                sSGrid.Lock = False
                                sSGrid.Col = 17
                                sSGrid.Row = sSGrid.ActiveRow
                                If Trim(sSGrid.Text) = "Y" Then
                                    sSGrid.Lock = False
                                Else
                                    sSGrid.Lock = True
                                End If
                                'sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                            End If

                            'Added on 14 Mar'08
                            'Mk Kannan
                            'Begin
                            'sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                            If boolPromotional = True Then

                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                                sSGrid.Row = sSGrid.ActiveRow + 1
                                sSGrid.Col = 1
                                sSGrid.Lock = False
                                sSGrid.Col = 2
                                sSGrid.Lock = False
                                sSGrid.Col = 3
                                sSGrid.Lock = False
                                sSGrid.Col = 4
                                sSGrid.Lock = False
                                sSGrid.Col = 5
                                sSGrid.Lock = False
                                sSGrid.Col = 17
                                sSGrid.Row = sSGrid.ActiveRow
                                If Trim(sSGrid.Text) = "Y" Then
                                    sSGrid.Lock = False
                                Else
                                    sSGrid.Lock = True
                                End If
                            Else
                                sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                            End If
                            boolPromotional = False
                            'End                            
                        End If
                    End If
                End If

            ElseIf sSGrid.ActiveCol = 6 Then
                sSGrid.Col = 6
                sSGrid.Row = sSGrid.ActiveRow
                If sSGrid.Lock = False Then
                    sSGrid.Col = 1
                    sSGrid.Row = sSGrid.ActiveRow
                    If Trim(sSGrid.Text) <> "" Then
                        sSGrid.Col = 6
                        sSGrid.Row = sSGrid.ActiveRow
                        If Val(sSGrid.Text) = 0 Then
                            sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
                            Exit Sub
                        Else
                            Call Calculate()
                            sSGrid.Row = sSGrid.ActiveRow + 1
                            sSGrid.Col = 1
                            sSGrid.Lock = False
                            sSGrid.Col = 2
                            sSGrid.Lock = False
                            sSGrid.Col = 3
                            sSGrid.Lock = False
                            sSGrid.Col = 4
                            sSGrid.Lock = False
                            sSGrid.Col = 5
                            sSGrid.Lock = False
                            sSGrid.Col = 17
                            sSGrid.Row = sSGrid.ActiveRow
                            If Trim(sSGrid.Text) = "Y" Then
                                sSGrid.Lock = False
                            Else
                                sSGrid.Lock = True
                            End If
                            sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                        End If
                    End If
                End If
            ElseIf sSGrid.ActiveCol = 12 Then
                sSGrid.Col = 12
                sSGrid.Row = sSGrid.ActiveRow
                If Val(sSGrid.Text) = 0 Then
                    Call Calculate()
                    sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                    Exit Sub
                Else
                    Call Calculate()
                    sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                    Exit Sub
                End If
            End If
            Call GridLockRate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub cbo_PaymentMode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_PaymentMode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If cbo_SubPaymentMode.Visible = True Then
                cbo_SubPaymentMode.Focus()
            ElseIf txt_MemberCode.Visible = True Then

                If txt_TableNo.Text = "" And txt_TableNo.ReadOnly = False Then
                    txt_TableNo.Focus()
                Else
                    txt_MemberCode.Focus()
                End If
            Else
                If txt_TableNo.Text = "" Then
                    txt_TableNo.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub cbo_PaymentMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_PaymentMode.SelectedIndexChanged
        Dim sqlstring As String
        'CSC SMARTCARD
        Try
            Call CloseSmartDevicePort()
            PAYMENTMODE_GBL = cbo_PaymentMode.Text
            lastpaymode = cbo_PaymentMode.Text
            ordertype = " "
            lbl_Membercode.Text = "Member Code"
            sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE ,isnull(SMARTVALIDATE,'')as SMARTVALIDATE FROM PAYMENTMODEMASTER "
            sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
            If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) <> "SMART CARD" Then
                    If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("SMARTVALIDATE")).ToUpper() <> "YES" Then
                        lbl_SwipeCard.Visible = False
                        txt_card_id.Visible = False
                        Label3.Visible = False
                        Label4.Visible = False
                        txt_Holder_Code.Visible = False
                        Txt_holder_name.Visible = False
                        txt_card_id.Text = ""
                        txt_Holder_Code.Text = ""
                        Txt_holder_name.Text = ""

                        txt_MemberName.Enabled = True
                        txt_MemberCode.Enabled = True
                        cmd_MemberCodeHelp.Enabled = True
                        lbl_Membercode.Visible = True
                        txt_MemberName.Text = ""
                        txt_MemberCode.Text = ""
                        txt_MemberName.ReadOnly = False
                        txt_MemberCode.ReadOnly = False

                        txt_MemberName.Visible = True
                        txt_MemberCode.Visible = True
                        cmd_MemberCodeHelp.Visible = True
                        lbl_Membercode.Visible = True
                        Timer1.Enabled = False
                        Pic_Member.Image = New Bitmap(AppPath & "\IMAGE.Jpg")
                    Else
                        lbl_SwipeCard.Visible = True
                        txt_card_id.Visible = True
                        txt_card_id.Text = ""
                        Timer1.Enabled = True
                        Label3.Visible = True
                        Label4.Visible = True
                        txt_Holder_Code.Visible = True
                        Txt_holder_name.Visible = True
                        txt_Holder_Code.Enabled = True
                        Txt_holder_name.Enabled = True
                        txt_MemberCode.Enabled = False
                        txt_MemberName.Enabled = False

                        'txt_Holder_Code.Enabled = False
                        cmd_MemberCodeHelp.Enabled = False
                        Txt_holder_name.Enabled = False

                        lbl_SubPaymentMode.Visible = False
                        cbo_SubPaymentMode.Visible = False
                        cmd_MemberCodeHelp.Visible = False

                        '***************** CSC SMARTCARD

                        txt_MemberCode.ReadOnly = True
                        txt_MemberName.ReadOnly = True
                        cmd_MemberCodeHelp.Visible = False


                        txt_MemberName.Text = ""
                        txt_MemberCode.Text = ""
                        txt_Holder_Code.Text = ""
                        Txt_holder_name.Text = ""

                        txt_MemberCode.Text = MCODE_GBL
                        txt_MemberName.Text = MNAME_GBL


                        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                            '*****************'CSC SMARTCARD
                            txt_MemberCode.Text = MCODE_GBL
                            txt_MemberName.Text = MNAME_GBL
                        End If

                        cmd_MemberCodeHelp.Visible = False
                        lbl_Membercode.Text = "MEMBER CODE :"
                        sqlstring = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                        sqlstring = sqlstring & " UNION SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                        gconnection.getDataSet(sqlstring, "SM_MEM_LINKAGE")
                        'CHECKING IN GLOBAL FUNCTION (DD,MM,YYYY REMOVE AND CHECK IN txt_card_id)
                        Call CardIdValidate(Trim(txt_card_id.Text))
                        If gdataset.Tables("SM_MEM_LINKAGE").Rows.Count > 0 Then
                            cardcode = gdataset.Tables("SM_MEM_LINKAGE").Rows(0).Item("CARDCODE")
                        ElseIf Cardidcheck = True Then
                            cardcode = Trim(vCardcode)
                            vCardcode = ""
                        Else
                            If Me.txt_card_id.Text <> "" Then
                                MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                            lbl_SwipeCard.Visible = True
                            txt_card_id.Clear()
                            cbo_PaymentMode.Focus()
                            Exit Sub
                        End If

                        sqlstring = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
                        sqlstring = sqlstring & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME, ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
                        sqlstring = sqlstring & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
                        gconnection.getDataSet(sqlstring, "SM_CARDFILE_HDR")
                        If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                            If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                                gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "MEMBERMASTER")
                                If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                                    MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                                    Txt_Remarks.Text = "Current Card Balance : " & Trim(Format(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE"), "0.00"))
                                    txt_MemberName.Text = MNAME_GBL
                                    ordertype = "CLUBMEMBER"
                                End If
                            ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                                lbl_Membercode.Text = "AFF CLUB CODE   :"
                                'ordertype = "AFFMEMBER"
                                gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM AFFCLUBMEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "AFFILIATEDCLUBDETAILS")
                                If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                    MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                    txt_MemberName.Text = MNAME_GBL
                                    ordertype = "AFFMEMBER"
                                End If
                            ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EM" Then
                                lbl_Membercode.Text = "EMP CODE   :"

                                gconnection.getDataSet("SELECT MNAME AS CLUBNAME  FROM EMPLOYEEMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "EMPLOYEE")
                                If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                    MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                    txt_MemberName.Text = MNAME_GBL
                                    ordertype = "EMPMEMBER"
                                End If
                            End If
                        End If
                    End If


                Else
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Visible = True
                    txt_card_id.Text = ""
                    Timer1.Enabled = True
                    Label3.Visible = True
                    Label4.Visible = True
                    txt_Holder_Code.Visible = True
                    Txt_holder_name.Visible = True

                    txt_MemberCode.Enabled = False
                    txt_MemberName.Enabled = False
                    Txt_holder_name.Visible = True
                    txt_Holder_Code.Enabled = True

                    Txt_holder_name.Enabled = False

                    lbl_SubPaymentMode.Visible = False
                    cbo_SubPaymentMode.Visible = False
                    cmd_MemberCodeHelp.Visible = False

                    '***************** CSC SMARTCARD

                    txt_MemberCode.ReadOnly = True
                    txt_MemberName.ReadOnly = True
                    cmd_MemberCodeHelp.Visible = False


                    txt_MemberName.Text = ""
                    txt_MemberCode.Text = ""
                    txt_Holder_Code.Text = ""
                    Txt_holder_name.Text = ""

                    txt_MemberCode.Text = MCODE_GBL
                    txt_MemberName.Text = MNAME_GBL


                    If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                        '*****************'CSC SMARTCARD
                        txt_MemberCode.Text = MCODE_GBL
                        txt_MemberName.Text = MNAME_GBL
                    End If

                    cmd_MemberCodeHelp.Visible = False
                    lbl_Membercode.Text = "MEMBER CODE :"
                    sqlstring = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                    sqlstring = sqlstring & " UNION SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                    gconnection.getDataSet(sqlstring, "SM_MEM_LINKAGE")
                    'CHECKING IN GLOBAL FUNCTION (DD,MM,YYYY REMOVE AND CHECK IN txt_card_id)
                    Call CardIdValidate(Trim(txt_card_id.Text))
                    If gdataset.Tables("SM_MEM_LINKAGE").Rows.Count > 0 Then
                        cardcode = gdataset.Tables("SM_MEM_LINKAGE").Rows(0).Item("CARDCODE")
                    ElseIf Cardidcheck = True Then
                        cardcode = Trim(vCardcode)
                        vCardcode = ""
                    Else
                        If Me.txt_card_id.Text <> "" Then
                            MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        lbl_SwipeCard.Visible = True
                        txt_card_id.Clear()
                        cbo_PaymentMode.Focus()
                        Exit Sub
                    End If

                    sqlstring = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
                    sqlstring = sqlstring & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME, ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
                    sqlstring = sqlstring & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
                    gconnection.getDataSet(sqlstring, "SM_CARDFILE_HDR")
                    If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                        If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                            gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "MEMBERMASTER")
                            If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                                MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                                Txt_Remarks.Text = "Current Card Balance : " & Trim(Format(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE"), "0.00"))
                                txt_MemberName.Text = MNAME_GBL
                                ordertype = "CLUBMEMBER"
                            End If
                        ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                            lbl_Membercode.Text = "CLUB CODE   :"
                            gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM AFFCLUBMEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "AFFILIATEDCLUBDETAILS")
                            If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                txt_MemberName.Text = MNAME_GBL
                                ordertype = "AFFMEMBER"
                            End If
                        ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EM" Then
                            lbl_Membercode.Text = "EMP CODE   :"
                            gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM EMPLOYEEMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "EMPLOYEE")
                            If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                txt_MemberName.Text = MNAME_GBL
                                ordertype = "EMPMEMBER"
                            End If
                        End If
                    End If
                End If
                If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                    Lbl_PartyBookingNo.Visible = True
                    Txt_PartyBookingNo.Visible = True
                    Txt_PartyBookingNo.Focus()
                Else
                    Lbl_PartyBookingNo.Visible = False
                    Txt_PartyBookingNo.Visible = False
                    Txt_PartyBookingNo.Focus()
                End If
            Else
                MsgBox("Please select a valid payment mode.........")
                cbo_PaymentMode.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        Call FillSubPaymentMode(Trim(Me.cbo_PaymentMode.Text))
    End Sub

    Private Sub txt_MemberCode_GotFocus(sender As Object, e As EventArgs) Handles txt_MemberCode.GotFocus
        If txt_card_id.Text = "" And cbo_PaymentMode.Text = "SMART CARD" Then
            txt_card_id.Focus()
        Else
        End If
    End Sub

    Private Sub txt_card_id_GotFocus(sender As Object, e As EventArgs) Handles txt_card_id.GotFocus
        If gReaderType_code = 2 Then
            'If cardprent = False Then
            Call GetSMARTDEVICEPORT()
            Timer1.Enabled = True
            'Else
            '    txt_MemberCode.Focus()
            'End If

        ElseIf gReaderType_code = 3 Then
            If Trim(txt_card_id.Text) = "" Then
                Call GetSMART_CARDID()
            End If
        End If
    End Sub
    Private Sub txt_card_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_card_id.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(cbo_PaymentMode.Text) = "SMART CARD" Then
                Call txt_card_id_Validated(txt_card_id, e)
            Else
                MsgBox("SELECT CORRECT PAYMENTMODE", MsgBoxStyle.Information)
                txt_card_id.Text = ""
                cbo_PaymentMode.Focus()
            End If
        End If
    End Sub
    Private Sub txt_card_id_LostFocus(sender As Object, e As EventArgs) Handles txt_card_id.LostFocus
        If gReaderType_code = 2 Then
            Call CloseSmartDevicePort()
            If cardprent = True Then
                Me.txt_MemberCode.Focus()
            End If
        End If
    End Sub

    Private Sub txt_card_id_Validated(sender As Object, e As EventArgs) Handles txt_card_id.Validated
        Dim ssql, pay, valid As String
        ssql = "select MEMBERSTATUS ,isnull(SMARTVALIDATE,'')as SMARTVALIDATE froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(ssql, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            pay = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
            valid = gdataset.Tables("PAY").Rows(0).Item("SMARTVALIDATE")
        Else
            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
            Exit Sub
        End If
        Dim SQLSTRING As String
        If Trim(txt_card_id.Text) = "" And pay = "SMART CARD" Then
            ''''MessageBox.Show("PLEASE! SWIPE YOUR CARD", "CARD NOT SWIPED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ''''lbl_SwipeCard.Visible = True
            ''''txt_card_id.Focus()
            ''''Exit Sub
        Else
            SQLSTRING = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
            SQLSTRING = SQLSTRING & " UNION SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
            gconnection.getDataSet(SQLSTRING, "SM_MEM_LINKAGE")
            'CHECKING IN GLOBAL FUNCTION (DD,MM,YYYY REMOVE AND CHECK IN txt_card_id)
            Call CardIdValidate(Trim(txt_card_id.Text))
            If gdataset.Tables("SM_MEM_LINKAGE").Rows.Count > 0 Then
                cardcode = gdataset.Tables("SM_MEM_LINKAGE").Rows(0).Item("CARDCODE")
            ElseIf Cardidcheck = True Then
                cardcode = Trim(vCardcode)
                vCardcode = ""
            Else
                If pay = "SMART CARD" Then
                    MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Focus()
                    Exit Sub
                End If
            End If

            SQLSTRING = "SELECT * FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "' "
            gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
            If txt_card_id.Text <> "" Then
                gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
            End If
            If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                'CHECKING ACTIVATION FLAG IS 'Y' OR 'N'
                Dim temp_flag As Char
                temp_flag = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ACTIVATION_FLAG")
                If temp_flag <> "Y" Then
                    MessageBox.Show("Sorry!  Your Card Not Activated. " & ControlChars.CrLf & "Contact Smart Card Administration", "Validity Expires", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    txt_card_id.Clear()
                    txt_card_id.Focus()
                    '                    lbl_SwipeCard.Focus()
                    Exit Sub
                End If
                'DISPLAY BALNACE AMOUNT
                BALANCE_HDR = Format(Val(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE")), "0.00")
                'MIN_USAGE_BALANCE_HDR = Format(Val(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("MIN_USG_BALANCE")), "0.00")


            Else
                'MessageBox.Show("Sorry! CARD EXPIRED " & ControlChars.CrLf & "Contact Smart Card Administration", "Validity Expires", MessageBoxButtons.OK)
            End If

            'Show PHOTOS
            If gFoto = "Y" Then
                gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
                'gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
            Else
                If gShortName = "MCC" Then
                    gconnection.FOTO_LOAD_MCC(txt_Holder_Code, Pic_Member)
                ElseIf gShortName = "NIZAM" Then
                    gconnection.Foto_LOAD_NIZAM(txt_Holder_Code, Pic_Member)
                Else
                    gconnection.Foto_LOAD(txt_Holder_Code, Pic_Member)
                End If
            End If
            If Trim(Me.txt_card_id.Text) <> "" Then
                Call DISPLAYINF()
            End If

            'End If
        End If
    End Sub
    Public Function DISPLAYINF()
        Try

            Dim sender As Object, e As System.EventArgs
            Dim SMARTDATE, DD, MM, YY As String
            Dim CARDDATE As Date
            Dim i As Integer
            Dim TT() As String
            bselect = True
            Dim sqlstring1, sqlstring2, SQLSTRING, subcode, mcode As String
            'CHECKING AND DISPLAYING RECORDS FROM SM_CARDFILE_HDR
            SQLSTRING = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
            SQLSTRING = SQLSTRING & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME,  ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
            SQLSTRING = SQLSTRING & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
            gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
            If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                'CHECKING ACTIVATION FLAG IS 'Y' OR 'N'
                Dim temp_flag As Char
                temp_flag = ""
                temp_flag = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ACTIVATION_FLAG")
                If temp_flag <> "Y" Then
                    If cbo_PaymentMode.Text = "SMART CARD" Then
                        MessageBox.Show("SORRY! CARD IS DEACTIVATED", "CARD DEACTIVATED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        lbl_SwipeCard.Visible = True
                        txt_card_id.Clear()
                        txt_card_id.Focus()
                        '                    lbl_SwipeCard.Focus()
                        Exit Function
                    End If
                End If
                Dim todate As DateTime
                todate = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("VALID_TO")
                If Date.Today > todate Then
                    MessageBox.Show("SORRY! CARD IS OUT OF VALIDITY DATE", "CARD EXPIRED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Clear()
                    txt_card_id.Focus()
                    '                lbl_SwipeCard.Focus()
                    Exit Function
                End If
                Dim ACCESS_CTL As String
                Dim strsql, STRSQL2 As String
                strsql = " SELECT * FROM SM_CARDFILE_DET WHERE CARDCODE='" & cardcode & "' AND POSCODE='" & STRPOSCODE & "'"
                gconnection.getDataSet(strsql, "SM_CARDFILE_DET")
                If gdataset.Tables("SM_CARDFILE_DET").Rows.Count > 0 Then
                    STRSQL2 = " SELECT * FROM POSMASTER WHERE POSCODE='" & STRPOSCODE & "'"
                    gconnection.getDataSet(STRSQL2, "POSMASTER")
                    If gdataset.Tables("POSMASTER").Rows.Count > 0 Then
                        POSNAME_GBL = gdataset.Tables("POSMASTER").Rows(0).Item("POSDESC")
                    End If
                    ACCESS_CTL = gdataset.Tables("SM_CARDFILE_DET").Rows(0).Item("POS_ACCESS")
                    If ACCESS_CTL = "N" Then
                        MessageBox.Show("SORRY! YOU HAVE NO RIGHTS TO USE THE POS FACILITY", "ACCESS BLOCKED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txt_card_id.Clear()
                        txt_card_id.Focus()
                        '                    lbl_SwipeCard.Focus()
                        Exit Function
                    End If
                Else
                    MessageBox.Show(" PLEASE GET POS VALIDITY", "NO RIGHTS FOR POS USAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_card_id.Clear()
                    txt_card_id.Focus()
                    '                lbl_SwipeCard.Focus()
                    Exit Function
                End If
                txt_MemberCode.Text = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("MEMBERCODE")
                MCODE_GBL = Trim(txt_MemberCode.Text)
                NAME_GBL = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("NAME")
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Then
                    gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "' AND CURENTSTATUS IN('LIVE','ACTIVE')", "MEMBERMASTER")
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                    gconnection.getDataSet("SELECT MNAME FROM AFFCLUBMEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "' AND CURENTSTATUS IN('LIVE','ACTIVE')", "MEMBERMASTER")
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EMP" Then
                    gconnection.getDataSet("SELECT MNAME FROM  EMPLOYEEMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "' AND CURENTSTATUS IN('LIVE','ACTIVE')", "MEMBERMASTER")
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                    gconnection.getDataSet("SELECT GUEST AS MNAME FROM  ROOMCHECKIN WHERE ROOMNO='" & Trim(MCODE_GBL) & "' AND ISNULL(CHECKOUT,'')<>'Y'", "MEMBERMASTER")
                End If

                If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                    MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                    txt_MemberName.Text = MNAME_GBL
                Else

                End If
                'KARTHI JUNE 13
                'KARTHI JUNE 13
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TMP" Then
                    gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "MEMBERMASTER")
                    If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                        MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                    lbl_Membercode.Text = "CLUB CODE   :"
                    '                lbl_MemberName.Text = "CLUB NAME   :"
                    gconnection.getDataSet("SELECT mname as CLUBNAME FROM AFFCLUBMEMBERMASTER WHERE CLUBCODE='" & Trim(MCODE_GBL) & "'", "AFFILIATEDCLUBDETAILS")
                    If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                        MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EMP" Then
                    lbl_Membercode.Text = "EMP  CODE   :"
                    '                lbl_MemberName.Text = "CLUB NAME   :"
                    gconnection.getDataSet("SELECT mname as EMPNAME FROM EMPLOYEEMASTER WHERE mcode='" & Trim(MCODE_GBL) & "'", "empdet")
                    If gdataset.Tables("empdet").Rows.Count > 0 Then
                        MNAME_GBL = gdataset.Tables("empdet").Rows(0).Item("EMPNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                    lbl_Membercode.Text = "ROOM NO     :"
                    gconnection.getDataSet("SELECT GUEST AS MNAME FROM  ROOMCHECKIN WHERE ROOMNO='" & Trim(MCODE_GBL) & "' AND ISNULL(CHECKOUT,'')<>'Y'", "ROOM")
                    If gdataset.Tables("ROOM").Rows.Count > 0 Then

                        MNAME_GBL = gdataset.Tables("ROOM").Rows(0).Item("MNAME")
                        txt_MemberName.Text = MNAME_GBL
                    End If
                    TT = Split(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("CARDCODE"), "-")
                    gconnection.getDataSet("SELECT GUEST AS MNAME FROM  ROOMCHECKIN WHERE DOCNO='" & TT(1) & "' AND ISNULL(CHECKOUT,'')<>'Y'", "ROOM1")
                    If gdataset.Tables("ROOM1").Rows.Count > 0 Then
                    Else
                        MsgBox("SORRY USER GUEST CHECKED OUT U CAN NOT GENERATE KOT")
                        MNAME_GBL = ""
                        Me.txt_MemberCode.Text = ""
                        Me.txt_MemberName.Text = ""
                    End If

                End If
                txt_Holder_Code.Enabled = True
                cmd_MemberCodeHelp.Enabled = True
                txt_Holder_Code.ReadOnly = False
                'karthi jun2
                txt_Holder_Code.Text = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("cardcode")
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                    Dim CSPLIT() As String
                    CSPLIT = Split(Me.txt_Holder_Code.Text, "-")
                    SQLSTRING = "SELECT * FROM ROOMCHECKIN WHERE ISNULL(DOCNO,0)='" & CSPLIT(1) & "' AND ISNULL(CHECKOUT,'')<>'Y'"
                    gconnection.getDataSet(SQLSTRING, "RMC")
                    If gdataset.Tables("RMC").Rows.Count > 0 Then
                    Else
                        MsgBox("ROOM IS CHECKEDOUT U CANNOT USE THE CARD")
                        Me.txt_Holder_Code.Text = ""
                        Me.txt_MemberCode.Text = ""
                        Me.Cmd_Add.Enabled = False
                    End If
                End If
                Txt_holder_name.Text = gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("CARDHOLDERNAME")
                lbl_SwipeCard.Visible = False
                '***********************************New addition for reading datefromcard block
                If ACCESS_CHECK_GBL = True Then
                    SQLSTRING = "SELECT CARDCODE FROM SM_MEMBERENTRY_LOG WHERE CARDCODE='" & Trim(txt_Holder_Code.Text) & "' AND CAST(CONVERT(VARCHAR(11),DATETIME,6) AS DATETIME ) = '" & Format(Date.Now, "dd/MMM/yyyy") & "'"
                    gconnection.getDataSet(SQLSTRING, "SM_MEMBERENTRY_LOG")
                    If gdataset.Tables("SM_MEMBERENTRY_LOG").Rows.Count = 0 Then
                        MessageBox.Show("SORRY! GET ACCESS AT RECEPTION", "GET ACCESS AT RECEPTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txt_card_id.Clear()
                        txt_card_id.Focus()
                        txt_MemberCode.Clear()
                        txt_MemberName.Clear()
                        Txt_holder_name.Clear()
                        txt_Holder_Code.Clear()
                        Exit Function
                    End If
                End If
                ''CHECKING AND DISPLAYING RECORDS FROM MEMBERMASTER
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TMP" Then
                    SQLSTRING = "SELECT isnull(mcode,'') as mcode,isnull(mname,'') as mname,isnull(curentstatus,'') as termination FROM VIEWMEMBER WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' and curentstatus not in('live','active') "
                    gconnection.getDataSet(SQLSTRING, "membermaster")
                    If gdataset.Tables("membermaster").Rows.Count > 0 Then
                        Txt_Remarks.Text = "MEMBERSHIP " & "." & gdataset.Tables("membermaster").Rows(0).Item("termination")

                        If MsgBox("MEMBERSHIP NOT. FOUND...as membership   " & gdataset.Tables("membermaster").Rows(0).Item("termination"), MsgBoxStyle.OKCancel, "chs") = MsgBoxResult.OK Then
                            txt_MemberCode.Text = ""
                            txt_MemberCode.Focus()
                        Else
                            txt_MemberCode.Text = ""
                            txt_MemberCode.Focus()
                        End If
                    End If
                End If
                SQLSTRING = "select balance,muc_amt from sm_vw_balance  where  CARDCODE='" & Trim(Me.txt_Holder_Code.Text) & "'"
                gconnection.getDataSet(SQLSTRING, "sm_bal")
                If gdataset.Tables("sm_bal").Rows.Count > 0 Then
                    lbl_bal.Text = "CARD BAL.:" & gdataset.Tables("sm_bal").Rows(0).Item("balance")
                    '& "  MUC :" & gdataset.Tables("sm_bal").Rows(0).Item("muc_amt")

                End If

                Dim PHOTOFILENAME As String
                If txt_TableNo.ReadOnly = True Then
                    txt_ServerCode.Focus()
                Else
                    txt_TableNo.Focus()
                End If
            Else
                If cbo_PaymentMode.Text = "SMART CARD" Then
                    MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lbl_SwipeCard.Visible = True
                    txt_card_id.Clear()
                    cbo_PaymentMode.Focus()
                End If
            End If
        Catch EX As Exception
            MsgBox("PLEASE GET ACCESS AT RECEPTION USING SPLASH DEVICE..." & EX.Message)
            Call clear()
        End Try
    End Function
    Public Sub clear()
        Dim sender As Object, e As System.EventArgs
        cmd_Clear_Click(sender, e)
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        BALANCE_HDR = 0
        Pic_Member.Image = Nothing
        sSGrid.ClearRange(1, 1, -1, -1, True)
        ordertype = ""
        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        sSGrid.SetActiveCell(1, 1)
        '        lab_outstanding.Text = ""
        LoadCount = 1
        bselect = False
        Call clearform(Me)
        Call Autogenerate()
        Call ShowBillno()
        Call GRIDLOCK()
        Call Enabledcontrol()
        Call fillPayment_Mode()
        'LABDUE.Text = ""
        lblBillno1.Visible = False
        lblBillno2.Visible = False
        'txt_KOTno.Text = ""
        pnl_POSCode.Top = 1000
        pnl_UOMCode.Top = 1000
        txt_MemberCode.Tag = ""
        Cmd_Add.Enabled = True
        Cmd_Add.Text = "Add [F7]"
        cbo_PaymentMode.Focus()
        'txt_TableNo.Focus()
        KOT_Timer.Enabled = True
        'Me.Lbl_Bill.Visible = False
        TotalItemCount = 0
        txt_ServerCode.ReadOnly = False
        txt_KOTno.ReadOnly = False
        txt_MemberName.ReadOnly = False
        txt_ServerName.ReadOnly = False
        'txt_LOCATIONCODE.Text = ""
        txt_ServerName.Text = ""
        txt_MemberCode.Text = ""
        txt_MemberName.Text = ""
        txt_Holder_Code.Text = ""
        Txt_holder_name.Text = ""
        txt_card_id.Text = ""
        MCODE_GBL = ""
        MNAME_GBL = ""
        txt_ServerCode.Text = ""
        txt_ServerName.Text = ""
        Txt_GolfRegNo.Text = ""
        Txt_GolfRegNo.ReadOnly = False
        'txt_LOCATIONCODE.Text = ""
        'TXT_LOCATIONNAME.Text = ""
        Lbl_Bill.Text = ""
        lbl_Status.Text = ""
        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
            Lbl_PartyBookingNo.Visible = True
            Txt_PartyBookingNo.Visible = True
            Txt_PartyBookingNo.Text = ""
        Else
            Lbl_PartyBookingNo.Visible = False
            Txt_PartyBookingNo.Visible = False
            Txt_PartyBookingNo.Text = ""
        End If
      

        'grp_paydet.Visible = False
        'TXT_LOCATIONNAME.Text = ""
        txt_MemberCode.ReadOnly = False
        txt_MemberName.ReadOnly = False
        cmd_MemberCodeHelp.Enabled = True
        Me.dtp_KOTdate.Value = Format(Now, "dd/MM/yyyy")
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Delete.Enabled = True
        Me.lbl_SubPaymentMode.Visible = False
        Me.cbo_SubPaymentMode.Visible = False
        Me.cmd_KOTnoHelp.Enabled = True
        BillNontaxamount = 0 : BillNontotalamount = 0 : Billtaxamount = 0 : Billtotalamount = 0
        'Call UserValidation()
        'End
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Call SetDateTime()
        Call SYS_DATE_TIME()
        If gCenterlized = "Y" Then
            If Mid(gTableReq, 1, 1) = "Y" Then
                txt_TableNo.ReadOnly = False
                cmd_TablenoHelp.Enabled = True
                txt_TableNo.Focus()
            Else
                txt_TableNo.ReadOnly = True
                cmd_TablenoHelp.Enabled = False
                Me.CMB_BTYPE.Focus()
            End If
        Else
            If Mid(pTableReq, 1, 1) = "Y" Then
                txt_TableNo.ReadOnly = False
                cmd_TablenoHelp.Enabled = True
                txt_TableNo.Focus()
            Else
                txt_TableNo.ReadOnly = True
                cmd_TablenoHelp.Enabled = False
                Me.CMB_BTYPE.Focus()
            End If
        End If
        If Mid(gWaiterReq, 1, 1) = "Y" Then
            txt_ServerCode.ReadOnly = False
            txt_ServerName.ReadOnly = False
            cmd_ServerCodeHelp.Enabled = True
        Else
            txt_ServerCode.ReadOnly = True
            txt_ServerName.ReadOnly = True
            cmd_ServerCodeHelp.Enabled = False
            Me.CMB_BTYPE.Focus()
        End If
        If GolfRegApp = "Y" Then
            Lbl_GolfRegNo.Visible = True
            Txt_GolfRegNo.Visible = True
            Cmd_GolfRegNoHelp.Visible = True
        Else
            Lbl_GolfRegNo.Visible = False
            Txt_GolfRegNo.Visible = False
            Cmd_GolfRegNoHelp.Visible = False
        End If
        cbo_PaymentMode.Focus()
        txt_MemberCode.Text = ""
        Txt_Remarks.Text = ""
        Show()
        If Mid(pKotType, 1, 1) = "A" Or Mid(gKotType, 1, 1) = "A" Then
            Me.CMB_BTYPE.Focus()
        Else
            txt_KOTno.Focus()
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ttime = 0 Or ttime <> 2 Then
            '    Lbl_SwipeCard.Visible = False
            ttime = 2
        ElseIf ttime = 2 And Trim(txt_card_id.Text) = "" Then
            txt_card_id.Focus()
            CloseSmartDevicePort()
            If RealD < 0 Then
                Timer1.Stop()
                If MessageBox.Show("PROBLEM IN SMART CARD DEVICE CONNECTION ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    Timer1.Start()
                    Call GetSMARTDEVICEPORT()
                Else
                    Timer1.Start()
                End If
            Else
                GetSMARTDEVICEPORT()
            End If
            GetSMART_CARDID()
            txt_card_id.Text = Trim(GBL_SMARTCARDSNO)
            If txt_card_id.Text <> "" Then
                Call txt_card_id_Validated(sender, e)
                ttime = 0
            End If
        End If
    End Sub
    Private Sub Timer_Delay_Tick(sender As Object, e As EventArgs) Handles Timer_Delay.Tick
    End Sub
    Private Sub CMB_BTYPE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CMB_BTYPE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'bselect = True
            Me.cbo_PaymentMode.Focus()
        End If
    End Sub

    Private Sub CMB_BTYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_BTYPE.SelectedIndexChanged
        DOCTYPE = CMB_BTYPE.Text
        SQLSTRING = "select poscode from POSMASTER where ISNULL(KOTPREFIX,'') ='" & DOCTYPE & "'"
        gconnection.getDataSet(SQLSTRING, "doc")
        If gdataset.Tables("doc").Rows.Count > 0 Then
            STRPOSCODE = gdataset.Tables("doc").Rows(0).Item("poscode")
        End If
        If gCenterlized = "N" Then
            StrSql = "SELECT ISNULL(PACKINGPERCENT,0) AS PACKPER,ISNULL(TIPS,0) AS TIPS_SER,ISNULL(ADCHARGE,0) AS ADCHARGE,ISNULL(PRCHARGE,0) AS PRCHARGE,ISNULL(GRCHARGE,0) AS GRCHARGE,ISNULL(KOTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(KOTPREFIX,'') AS KOTPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ FROM POSMASTER  WHERE POSCODE = '" & STRPOSCODE & "'"
            gconnection.getDataSet(StrSql, "PSETUP")
            If gdataset.Tables("PSETUP").Rows.Count > 0 Then
                pPackPer = gdataset.Tables("PSETUP").Rows(0).Item("PACKPER")
                pTipsPer = gdataset.Tables("PSETUP").Rows(0).Item("TIPS_SER")
                pAdCgsPer = gdataset.Tables("PSETUP").Rows(0).Item("ADCHARGE")
                pPartyPer = gdataset.Tables("PSETUP").Rows(0).Item("PRCHARGE")
                pRoomPer = gdataset.Tables("PSETUP").Rows(0).Item("GRCHARGE")
                pTableReq = gdataset.Tables("PSETUP").Rows(0).Item("TABLEREQ")
                pKotType = gdataset.Tables("PSETUP").Rows(0).Item("KOTTYPE")
                pKotPrefix = gdataset.Tables("PSETUP").Rows(0).Item("KOTPREFIX")
                DefaultPayment = gdataset.Tables("PSETUP").Rows(0).Item("PAYMENTMODE")
            End If
        End If
        Call fillPayment_Mode()
        'Call FillDefaultPayment()
        Call Enabledcontrol()
        Call Autogenerate()
        Call ShowBillno()
        Call GRIDLOCK()
        'Call fillposdocument()
        If gCenterlized = "Y" And Mid(gKotType, 1, 1) = "A" Then
            Call Autogenerate()
        ElseIf gCenterlized = "N" And Mid(pKotType, 1, 1) = "A" Then
            Call Autogenerate()
        ElseIf gCenterlized = "Y" And Mid(gKotType, 1, 1) = "M" Then
            txt_KOTno.Text = ""
        End If
        sSGrid.ClearRange(1, 1, -1, -1, True)
        If gCenterlized = "Y" Then
            If Mid(gTableReq, 1, 1) = "Y" Then
                txt_TableNo.ReadOnly = False
                cmd_TablenoHelp.Enabled = True
                txt_TableNo.Focus()
            Else
                txt_TableNo.ReadOnly = True
                cmd_TablenoHelp.Enabled = False
                Me.CMB_BTYPE.Focus()
            End If
        Else
            If Mid(pTableReq, 1, 1) = "Y" Then
                txt_TableNo.ReadOnly = False
                cmd_TablenoHelp.Enabled = True
                txt_TableNo.Focus()
            Else
                txt_TableNo.ReadOnly = True
                cmd_TablenoHelp.Enabled = False
                Me.CMB_BTYPE.Focus()
            End If
        End If
        'lbl_Membercode.Text = "Member Code"
    End Sub
    Private Sub cmd_TablenoHelp_Click(sender As Object, e As EventArgs) Handles cmd_TablenoHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT DISTINCT ISNULL(TABLENO,'') AS TABLENO,ISNULL(TABLENAME,'') AS TABLENAME FROM TABLEMASTER"
        M_WhereCondition = " WHERE     isnull(FREEZE,'') <> 'Y'"
        vform.Field = " TABLENO,TABLENAME"
        'vform.vFormatstring = "         TABLE NO         |          TABLE DESC"
        vform.vCaption = "TABLE MASTER HELP"
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_TableNo.Text = Trim(vform.keyfield & "")
            txt_TableNo_Validated(sender, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_TableNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_TableNo.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmd_TablenoHelp_Click(sender, e)
        End If
    End Sub
    Private Sub txt_TableNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_TableNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If txt_TableNo.ReadOnly = False Then
                If Trim(txt_TableNo.Text) <> "" Then
                    txt_TableNo_Validated(sender, e)
                Else
                    Call cmd_TablenoHelp_Click(cmd_TablenoHelp, e)
                End If
            End If
            'txt_Cover.Focus()
        End If
    End Sub
    Private Sub txt_TableNo_Validated(sender As Object, e As EventArgs) Handles txt_TableNo.Validated
        Try
            Dim strstring As String
            Dim I As Integer
            If Trim(txt_TableNo.Text) <> "" Then
                If Trim(txt_TableNo.Text) <> "" Then
                    'strstring = "SELECT TABLENO,MCODE,MNAME FROM Kot_Hdr WHERE tableno='" & Trim(txt_TableNo.Text) & "' AND   "
                    'strstring = strstring & "Billstatus='PO' And isnull(DELFLAG,'') <> 'Y' And ISNULL(Manualbillstatus,'')<> 'Y' AND CAST(Convert(varchar(11),KOTDATE,6) AS DATETIME) = '" & Format(CDate(dtp_KOTdate.Value), "yyyy-MM-dd") & "' "
                    '                    strstring = "SELECT isnull(poscode,'') as poscode,isnull(posdesc,'') as posname FROM POSMASTER WHERE POSCODE='" & Trim(txt_ServerCode.Text) & "'AND ISNULL(Freeze,'')<>'Y'"
                    strstring = "SELECT TABLENO FROM TABLEMASTER WHERE tableno='" & Trim(txt_TableNo.Text) & "' AND ISNULL(FREEZE,'')<>'y'"
                    gconnection.getDataSet(strstring, "LOCmaster")
                    If gdataset.Tables("LOCmaster").Rows.Count > 0 Then
                        txt_TableNo.Text = gdataset.Tables("Locmaster").Rows(0).Item("TABLENO")
                        'txt_ServerName.Text = gdataset.Tables("Locmaster").Rows(0).Item("PosName")
                        'txt_MemberCode.Text = gdataset.Tables("Locmaster").Rows(0).Item("MCODE")
                        'txt_MemberName.Text = gdataset.Tables("Locmaster").Rows(0).Item("MNAME")
                        'txt_MemberCode_Validated(sender, e)
                        Me.cbo_PaymentMode.Focus()
                        'txt_ServerCode.Focus()
                    Else
                        Me.txt_TableNo.Focus()
                    End If
                Else
                    Me.txt_TableNo.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cmd_MemberCodeHelp_Click(sender As Object, e As EventArgs) Handles cmd_MemberCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        Dim SSQL As String
        Dim PAY As String
        PAY = ""
        'SMART(CARD)
        'ROOM(CHECKIN)
        'MEMBER(ACCOUNT)
        'BANK(INSTRUMENT)
        'CASH()
        SSQL = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(SSQL, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
        Else
            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
            Exit Sub
        End If
        If PAY = "ROOM CHECKIN" Then
            gSQLString = "SELECT roomno,guest,docno FROM roomcheckin "
            M_WhereCondition = "WHERE ISNULL(checkout,'') <> 'Y' AND roomstatus='occupied'"
            vform.Field = " ROOMNO,GUEST,DOCNO "
            'vform.vFormatstring = "     ROOM NO                  |                     GUEST NAME                    |              DOC NO               "
            vform.vCaption = "ROOM MASTER HELP"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_MemberCode.Text = Trim(vform.keyfield & "")
                txt_MemberName.Text = Trim(vform.keyfield1 & "")
                txt_MemberCode.Tag = Trim(vform.keyfield2 & "")
                'txt_ServerCode.Focus()
                If txt_ServerCode.ReadOnly = True Then
                    txt_LOCATIONCODE.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
            End If
            vform.Close()
            vform = Nothing
            'club
            '03/05/2008
            'SMART(CARD)
            'ROOM(CHECKIN)
            'MEMBER(ACCOUNT)
            'BANK(INSTRUMENT)
            'CASH()
            'CLUB(ACCOUNT)
            'EMPLOYEE()
        ElseIf PAY = "CLUB ACCOUNT" Then
            gSQLString = "SELECT MCODE,MNAME FROM MEMBERMASTER "
            M_WhereCondition = "WHERE membertypecode in(select subtypecode from subcategorymaster where isnull(clubaccount,'')='Y') "
            vform.Field = " SLCODE,SLNAME "
            'vform.vFormatstring = "     SLCODE                  |                     SL NAME                    "
            vform.vCaption = "ACCOUNT MASTER HELP"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_MemberCode.Text = Trim(vform.keyfield & "")
                txt_MemberName.Text = Trim(vform.keyfield1 & "")
                txt_MemberCode.Tag = Trim(vform.keyfield & "")
                'txt_ServerCode.Focus()
                If txt_ServerCode.ReadOnly = True Then
                    txt_LOCATIONCODE.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
            End If
            vform.Close()
            vform = Nothing
        ElseIf PAY = "MEMBER ACCOUNT" Then
            gSQLString = "SELECT mcode,mname FROM VIEWMEMBER "
            M_WhereCondition = " Where  TYPE='CLUBMEMBER' AND CURENTSTATUS IN ('LIVE','ACTIVE') "
            vform.Field = "MNAME,MCODE "
            'vform.vFormatstring = "                 MEMBER CODE            |                 MEMBER NAME                                "
            vform.vCaption = "MEMBER MASTER HELP"
           
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_MemberCode.Text = Trim(vform.keyfield & "")
                txt_MemberName.Text = Trim(vform.keyfield1 & "")
                txt_MemberCode_Validated(sender, e)
                'txt_ServerCode.Focus()
                If txt_ServerCode.ReadOnly = True Then
                    txt_LOCATIONCODE.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
            End If
            vform.Close()
            vform = Nothing
        ElseIf PAY = "EMPLOYEE" Then
            gSQLString = "SELECT mcode,mname FROM VIEWMEMBER "
            M_WhereCondition = " Where  TYPE='EMPMEMBER' AND CURENTSTATUS IN ('LIVE','ACTIVE') "
            vform.Field = "MNAME,MCODE "
            'vform.vFormatstring = "                 MEMBER CODE            |                 MEMBER NAME                                "
            vform.vCaption = "MEMBER MASTER HELP"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_MemberCode.Text = Trim(vform.keyfield & "")
                txt_MemberName.Text = Trim(vform.keyfield1 & "")
                txt_MemberCode_Validated(sender, e)
                'txt_ServerCode.Focus()
                If txt_ServerCode.ReadOnly = True Then
                    txt_LOCATIONCODE.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
            End If
            vform.Close()
            vform = Nothing
        Else
            gSQLString = "SELECT mcode,mname FROM VIEWMEMBER "
            M_WhereCondition = " Where  TYPE='CLUBMEMBER' AND CURENTSTATUS IN ('LIVE','ACTIVE') "
            vform.Field = "MNAME,MCODE "
            'vform.vFormatstring = "                 MEMBER CODE            |                 MEMBER NAME                                "
            vform.vCaption = "MEMBER MASTER HELP"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_MemberCode.Text = Trim(vform.keyfield & "")
                txt_MemberName.Text = Trim(vform.keyfield1 & "")
                txt_MemberCode_Validated(sender, e)
                'txt_ServerCode.Focus()
                If txt_ServerCode.ReadOnly = True Then
                    txt_LOCATIONCODE.Focus()
                Else
                    txt_ServerCode.Focus()
                End If
            End If
            vform.Close()
            vform = Nothing
        End If
    End Sub

    Private Sub txt_MemberCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_MemberCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Me.cmd_MemberCodeHelp.Enabled = True Then
                Call cmd_MemberCodeHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txt_MemberCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_MemberCode.KeyPress
        If cbo_PaymentMode.SelectedItem = "ROOM" Then
            getNumeric(e)
        End If
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_MemberCode.Text) <> "" Then
                txt_MemberCode_Validated(sender, e)
            Else
                Call cmd_MemberCodeHelp_Click(cmd_MemberCodeHelp, e)
            End If
        End If
    End Sub
    Private Sub txt_MemberCode_Validated(sender As Object, e As EventArgs) Handles txt_MemberCode.Validated
        Try
            Dim strstring As String
            Dim SSQL As String
            Dim CLIMIT, pLIMIT As Double
            'Dim SSQL As String
            Dim PAY As String
            PAY = ""
            'SMART CARD
            'ROOM CHECKIN
            'MEMBER ACCOUNT
            'BANK INSTRUMENT
            'CASH
            'CLUB ACCOUNT
            'EMPLOYEE
            SSQL = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(SSQL, "PAY")
            If gdataset.Tables("PAY").Rows.Count > 0 Then
                PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
            Else
                MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
                Exit Sub
            End If
            SQLSTRING = "select isnull(memcreditlimit,0)as creditlimit from  possetup"
            gconnection.getDataSet(SQLSTRING, "climit")
            If gdataset.Tables("climit").Rows.Count > 0 Then
                If gdataset.Tables("climit").Rows(0).Item("creditlimit") > 0 Then
                    SQLSTRING = "exec get_creditlimit'" & Me.txt_MemberCode.Text & "'"
                    gconnection.ExcuteStoreProcedure(SQLSTRING)
                    SQLSTRING = "SELECT * FROM balance WHERE MCODE='" & Me.txt_MemberCode.Text & "'"
                    gconnection.getDataSet(SQLSTRING, "CRD")
                    If gdataset.Tables("CRD").Rows.Count > 0 Then
                        MemberOutstand = gdataset.Tables("CRD").Rows(0).Item("OUTSTAND")
                        'Me.LAB_OUTSTAND.Text = "MEMBER OUTSTANDING :" & gdataset.Tables("CRD").Rows(0).Item("OUTSTAND")

                    Else
                        MemberOutstand = 0
                    End If
                    'If MemberOutstand + Val(txt_BillAmount.Text) > gdataset.Tables("climit").Rows(0).Item("creditlimit") Then
                    '    MessageBox.Show("CREDIT LIMIT EXPIRED", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    '    'Exit Sub
                    'End If
                End If
            End If
            If Me.txt_card_id.Text = "" Then
                If UCase(Mid(gCompanyname, 1, 4)) = "" Then
                    If Trim(txt_MemberCode.Text) <> "" Then
                        SQLSTRING = "SELECT * FROM memberblocking WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' AND CAST(CONVERT(VARCHAR(20),adddatetime,106)AS DATETIME)='" & Format(Now, "dd-MMM-yyyy") & "'"
                        gconnection.getDataSet(SQLSTRING, "MEM")
                        If gdataset.Tables("MEM").Rows.Count > 0 Then
                            If PAY = "ROOM CHECKIN" Then
                                Label8.Visible = True
                                Me.txt_MemberName.Text = ""
                                Me.txt_MemberCode.Text = ""
                                lbl_SwipeCard.Visible = True
                                txt_card_id.Visible = True
                                txt_card_id.Text = ""
                                Timer1.Enabled = True
                                Label3.Visible = True
                                Label4.Visible = True
                                txt_Holder_Code.Visible = True
                                Txt_holder_name.Visible = True
                                txt_Holder_Code.Enabled = True
                                Txt_holder_name.Enabled = True
                                txt_MemberCode.Enabled = False
                                txt_MemberName.Enabled = False

                                'txt_Holder_Code.Enabled = False
                                cmd_MemberCodeHelp.Enabled = False
                                Txt_holder_name.Enabled = False

                                lbl_SubPaymentMode.Visible = False
                                cbo_SubPaymentMode.Visible = False
                                cmd_MemberCodeHelp.Visible = False

                                '***************** CSC SMARTCARD

                                txt_MemberCode.ReadOnly = True
                                txt_MemberName.ReadOnly = True
                                cmd_MemberCodeHelp.Visible = False


                                txt_MemberName.Text = ""
                                txt_MemberCode.Text = ""
                                txt_Holder_Code.Text = ""
                                Txt_holder_name.Text = ""

                                txt_MemberCode.Text = MCODE_GBL
                                txt_MemberName.Text = MNAME_GBL


                                If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                                    '*****************'CSC SMARTCARD
                                    txt_MemberCode.Text = MCODE_GBL
                                    txt_MemberName.Text = MNAME_GBL
                                End If

                                cmd_MemberCodeHelp.Visible = False
                                lbl_Membercode.Text = "MEMBER CODE :"
                                SQLSTRING = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                                SQLSTRING = SQLSTRING & " UNION SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                                gconnection.getDataSet(SQLSTRING, "SM_MEM_LINKAGE")
                                'CHECKING IN GLOBAL FUNCTION (DD,MM,YYYY REMOVE AND CHECK IN txt_card_id)
                                Call CardIdValidate(Trim(txt_card_id.Text))
                                If gdataset.Tables("SM_MEM_LINKAGE").Rows.Count > 0 Then
                                    cardcode = gdataset.Tables("SM_MEM_LINKAGE").Rows(0).Item("CARDCODE")
                                ElseIf Cardidcheck = True Then
                                    cardcode = Trim(vCardcode)
                                    vCardcode = ""
                                Else
                                    If Me.txt_card_id.Text <> "" Then
                                        MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    End If
                                    lbl_SwipeCard.Visible = True
                                    txt_card_id.Clear()
                                    cbo_PaymentMode.Focus()
                                    Exit Sub
                                End If

                                SQLSTRING = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
                                SQLSTRING = SQLSTRING & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME, ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
                                SQLSTRING = SQLSTRING & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
                                gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
                                If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                                    If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                                        gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "MEMBERMASTER")
                                        If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                                            MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                                            Txt_Remarks.Text = "Current Card Balance : " & Trim(Format(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE"), "0.00"))
                                            txt_MemberName.Text = MNAME_GBL
                                            ordertype = "CLUBMEMBER"
                                        End If
                                    ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                                        lbl_Membercode.Text = "AFF CLUB CODE   :"
                                        'ordertype = "AFFMEMBER"
                                        gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM AFFCLUBMEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "AFFILIATEDCLUBDETAILS")
                                        If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                            MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                            txt_MemberName.Text = MNAME_GBL
                                            ordertype = "AFFMEMBER"
                                        End If
                                    ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EM" Then
                                        lbl_Membercode.Text = "EMP CODE   :"

                                        gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM EMPLOYEEMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "EMPLOYEE")
                                        If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                            MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                            txt_MemberName.Text = MNAME_GBL
                                            ordertype = "EMPMEMBER"
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            Label8.Visible = True
                            Me.txt_MemberName.Text = ""
                            Me.txt_MemberCode.Text = ""
                            lbl_SwipeCard.Visible = True
                            txt_card_id.Visible = True
                            txt_card_id.Text = ""
                            Timer1.Enabled = True
                            Label3.Visible = True
                            Label4.Visible = True
                            txt_Holder_Code.Visible = True
                            Txt_holder_name.Visible = True
                            txt_Holder_Code.Enabled = True
                            Txt_holder_name.Enabled = True
                            txt_MemberCode.Enabled = False
                            txt_MemberName.Enabled = False

                            'txt_Holder_Code.Enabled = False
                            cmd_MemberCodeHelp.Enabled = False
                            Txt_holder_name.Enabled = False

                            lbl_SubPaymentMode.Visible = False
                            cbo_SubPaymentMode.Visible = False
                            cmd_MemberCodeHelp.Visible = False

                            '***************** CSC SMARTCARD

                            txt_MemberCode.ReadOnly = True
                            txt_MemberName.ReadOnly = True
                            cmd_MemberCodeHelp.Visible = False


                            txt_MemberName.Text = ""
                            txt_MemberCode.Text = ""
                            txt_Holder_Code.Text = ""
                            Txt_holder_name.Text = ""

                            txt_MemberCode.Text = MCODE_GBL
                            txt_MemberName.Text = MNAME_GBL


                            If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                                '*****************'CSC SMARTCARD
                                txt_MemberCode.Text = MCODE_GBL
                                txt_MemberName.Text = MNAME_GBL
                            End If

                            cmd_MemberCodeHelp.Visible = False
                            lbl_Membercode.Text = "MEMBER CODE :"
                            SQLSTRING = "SELECT * FROM SM_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                            SQLSTRING = SQLSTRING & " UNION SELECT * FROM SM_AFF_TEMP_MEM_LINKAGE WHERE [16_DIGIT_CODE]='" & Trim(txt_card_id.Text) & "' AND ISNULL(CARDCODE,'NULL')<>'NULL' "
                            gconnection.getDataSet(SQLSTRING, "SM_MEM_LINKAGE")
                            'CHECKING IN GLOBAL FUNCTION (DD,MM,YYYY REMOVE AND CHECK IN txt_card_id)
                            Call CardIdValidate(Trim(txt_card_id.Text))
                            If gdataset.Tables("SM_MEM_LINKAGE").Rows.Count > 0 Then
                                cardcode = gdataset.Tables("SM_MEM_LINKAGE").Rows(0).Item("CARDCODE")
                            ElseIf Cardidcheck = True Then
                                cardcode = Trim(vCardcode)
                                vCardcode = ""
                            Else
                                If Me.txt_card_id.Text <> "" Then
                                    MessageBox.Show("SORRY! CARD IS NOT VALID", "NOT A VALID CARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                                lbl_SwipeCard.Visible = True
                                txt_card_id.Clear()
                                cbo_PaymentMode.Focus()
                                Exit Sub
                            End If

                            SQLSTRING = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
                            SQLSTRING = SQLSTRING & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME, ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
                            SQLSTRING = SQLSTRING & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
                            gconnection.getDataSet(SQLSTRING, "SM_CARDFILE_HDR")
                            If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Or gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                                    gconnection.getDataSet("SELECT MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "MEMBERMASTER")
                                    If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
                                        MNAME_GBL = gdataset.Tables("MEMBERMASTER").Rows(0).Item("MNAME")
                                        Txt_Remarks.Text = "Current Card Balance : " & Trim(Format(gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("BALANCE"), "0.00"))
                                        txt_MemberName.Text = MNAME_GBL
                                        ordertype = "CLUBMEMBER"
                                    End If
                                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                                    lbl_Membercode.Text = "AFF CLUB CODE   :"
                                    'ordertype = "AFFMEMBER"
                                    gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM AFFCLUBMEMBERMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "AFFILIATEDCLUBDETAILS")
                                    If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                        MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                        txt_MemberName.Text = MNAME_GBL
                                        ordertype = "AFFMEMBER"
                                    End If
                                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EM" Then
                                    lbl_Membercode.Text = "EMP CODE   :"

                                    gconnection.getDataSet("SELECT MNAME AS CLUBNAME FROM EMPLOYEEMASTER WHERE MCODE='" & Trim(MCODE_GBL) & "'", "EMPLOYEE")
                                    If gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows.Count > 0 Then
                                        MNAME_GBL = gdataset.Tables("AFFILIATEDCLUBDETAILS").Rows(0).Item("CLUBNAME")
                                        txt_MemberName.Text = MNAME_GBL
                                        ordertype = "EMPMEMBER"
                                    End If
                                End If
                            End If
                        End If

                    End If
                End If
            End If
            If Trim(txt_MemberCode.Text) <> "" Then
                'Call tableno()
                If cbo_PaymentMode.Text <> "ROOM" Or cbo_PaymentMode.Text <> "SMART CARD" Then
                    gconnection.LoadFoto_DB_MemberMaster(txt_MemberCode, Pic_Member)
                End If

                If PAY = "ROOM CHECKIN" Then
                    strstring = "Select roomno,guest,docno From roomcheckin Where isnull(checkout,'') <> 'Y' and roomstatus='occupied' AND RoomNo='" & Trim(txt_MemberCode.Text) & "'"
                    gconnection.getDataSet(strstring, "RoomCheckin")
                    If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                        txt_MemberCode.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("RoomNo")
                        txt_MemberName.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("Guest")
                        txt_MemberCode.Tag = gdataset.Tables("RoomCheckin").Rows(0).Item("docno")
                        ordertype = "ROOMGUEST"
                        'txt_ServerCode.Focus()
                        If txt_ServerCode.ReadOnly = True Then
                            txt_LOCATIONCODE.Focus()
                        Else
                            txt_ServerCode.Focus()
                        End If
                    Else
                        txt_MemberCode.Text = ""
                        txt_MemberCode.Focus()
                    End If
                    'club
                    '03/05/2008
                ElseIf PAY = "CLUB ACCOUNT" Then
                    ''strstring = "SELECT slcode,slname FROM accountssubledgermaster WHERE SLCODE='" & Trim(txt_MemberCode.Text) & "'"
                    strstring = "SELECT mcode,mname FROM membermaster WHERE mcode='" & Trim(txt_MemberCode.Text) & "' and curentstatus in('LIVE','ACTIVE')and membertypecode in(select subtypecode from subcategorymaster where isnull(clubaccount,'')='Y') "
                    gconnection.getDataSet(strstring, "RoomCheckin")
                    If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                        txt_MemberCode.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        txt_MemberName.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mname")
                        txt_MemberCode.Tag = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        ordertype = "CLUBMEMBER"
                        'txt_ServerCode.Focus()
                        If txt_ServerCode.ReadOnly = True Then
                            txt_LOCATIONCODE.Focus()
                        Else
                            txt_ServerCode.Focus()
                        End If
                    Else
                        txt_MemberCode.Text = ""
                        txt_MemberName.Text = ""
                        txt_MemberCode.Focus()
                    End If
                ElseIf PAY = "EMPLOYEE" Then
                    ''strstring = "SELECT slcode,slname FROM accountssubledgermaster WHERE SLCODE='" & Trim(txt_MemberCode.Text) & "'"
                    strstring = "SELECT mcode,mname FROM EMPLOYEEMASTER WHERE mcode='" & Trim(txt_MemberCode.Text) & "' and curentstatus in('LIVE','ACTIVE') "
                    gconnection.getDataSet(strstring, "RoomCheckin")
                    If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                        txt_MemberCode.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        txt_MemberName.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("mname")
                        txt_MemberCode.Tag = gdataset.Tables("RoomCheckin").Rows(0).Item("mcode")
                        ordertype = "EMPMEMBER"
                        'txt_ServerCode.Focus()
                        If txt_ServerCode.ReadOnly = True Then
                            txt_LOCATIONCODE.Focus()
                        Else
                            txt_ServerCode.Focus()
                        End If
                    Else
                        txt_MemberCode.Text = ""
                        txt_MemberName.Text = ""
                        txt_MemberCode.Focus()
                    End If
                Else
                    strstring = "SELECT isnull(mcode,'') as mcode,isnull(mname,'') as mname,isnull(curentstatus,'') as termination FROM VIEWMEMBER WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' and CurentStatus in ('ACTIVE','live')"
                    gconnection.getDataSet(strstring, "membermaster")
                    If gdataset.Tables("membermaster").Rows.Count > 0 Then
                        Dim name
                        name = gdataset.Tables("membermaster").Rows(0).Item("termination")

                        Select Case Trim(name)
                            Case "LIVE"
                                Txt_Remarks.Text = ""
                                txt_MemberCode.Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                                txt_MemberName.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                            Case "ACTIVE"
                                Txt_Remarks.Text = ""
                                txt_MemberCode.Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                                txt_MemberName.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                            Case Else
                                Txt_Remarks.Text = "MEMBERSHIP " & name & "."
                                txt_MemberName.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                                txt_MemberCode.Focus()
                        End Select
                        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                            strstring = "SELECT * FROM party_hallbooking_hdr WHERE MCODE = '" & Trim(txt_MemberCode.Text) & "' AND BOOKINGNO = '" & Val(Txt_PartyBookingNo.Text) & "' "
                            gconnection.getDataSet(strstring, "membermasterparty")
                            If gdataset.Tables("membermasterparty").Rows.Count > 0 Then
                            Else
                                txt_MemberCode.Text = ""
                                txt_MemberName.Text = ""
                                MessageBox.Show("Check Booking No")
                                txt_MemberCode.Focus()
                            End If
                        End If

                        'if txt_MemberCode.Text =
                        If gclosingvalue = True Then
                            'If Trim(Txt_Remarks.Text) = "" Then
                            Dim sqlstring As String
                            Dim prvbal, curbal, present, rcd, clsbal, asonbal As Double
                            sqlstring = "exec cp_creditlimit '" & Format(dtp_KOTdate.Value, "dd MMM yyyy") & "','" & Trim(gDebtors) & "','" & Trim(txt_MemberCode.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CP_CREDIT")

                            sqlstring = "select ISNULL(PLIMIT,0) AS PLIMIT,ISNULL(CLIMIT,0) AS CLIMIT,ISNULL(SUM(ISNULL(CDR,0)),0)-ISNULL(SUM(ISNULL(CCR,0)),0) AS CAMOUNT,ISNULL(SUM(ISNULL(PDR,0)),0)-ISNULL(SUM(ISNULL(PCR,0)),0) AS PAMOUNT from CREDITSTOP_MCODE WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' GROUP BY PLIMIT,CLIMIT"
                            gconnection.getDataSet(sqlstring, "CP_CRLIMIT")
                            If gdataset.Tables("CP_CRLIMIT").Rows.Count > 0 Then
                                curbal = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("CAMOUNT")
                                prvbal = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("PAMOUNT")
                                CLIMIT = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("CLIMIT")
                                pLIMIT = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("PLIMIT")
                            Else
                                curbal = 0
                                prvbal = 0
                                CLIMIT = 0
                                pLIMIT = 0
                            End If

                            'If Val(prvbal) < 0 Then
                            '    LABDUE.Text = "PREV MONTH : " & " CR " & Space(8 - Len(Mid(Format(Val(prvbal) * -1, "0.00"), 1, 8))) & Mid(Format(Val(prvbal) * -1, "0.00"), 1, 8)
                            'Else
                            '    LABDUE.Text = "PREV MONTH : " & " DR " & Space(8 - Len(Mid(Format(Val(prvbal), "0.00"), 1, 8))) & Mid(Format(Val(prvbal), "0.00"), 1, 8)
                            'End If
                            'If Val(curbal) < 0 Then
                            '    LABDUE.Text = LABDUE.Text & "   ASON : " & " CR " & Space(8 - Len(Mid(Format(Val(curbal) * -1, "0.00"), 1, 8))) & Mid(Format(Val(curbal) * -1, "0.00"), 1, 8)
                            'Else
                            '    LABDUE.Text = LABDUE.Text & "   ASON : " & " DR " & Space(8 - Len(Mid(Format(Val(curbal), "0.00"), 1, 8))) & Mid(Format(Val(curbal), "0.00"), 1, 8)
                            'End If


                            'If Trim(cbo_PaymentMode.Text) = "CREDIT" Then
                            '    If pLIMIT - CLIMIT > 0 Then
                            '        LABDUE.Text = "CREDIT LIMIT EXCEED Rs....  " & Trim(Format(pLIMIT - CLIMIT, "0.00"))
                            '        MsgBox("CREDIT LIMIT EXCEED...  " & LABDUE.Text, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Credit Limit Exceed")
                            '        txt_MemberCode.Focus()
                            '        Exit Sub
                            '    Else
                            '        LABDUE.Text = "CURRENT BAR LIMIT AMOUNT Rs....  " & Trim(Format(pLIMIT - CLIMIT, "0.00"))
                            '    End If
                            'End If


                            If Trim(PAY) = "MEMBER ACCOUNT" Then

                                'Txt_Remarks.Text = LABDUE.Text
                                'txt_ServerCode.Focus()
                                If txt_ServerCode.ReadOnly = True Then
                                    txt_LOCATIONCODE.Focus()
                                Else
                                    txt_ServerCode.Focus()
                                End If
                                SSQL = "DELETE FROM CREDITSTOP_MCODE WHERE MCODE='" & Trim(txt_MemberCode.Text) & "'"
                                gcommand = New SqlClient.SqlCommand(SSQL, gconnection.Myconn)
                                gconnection.openConnection()
                                gcommand.ExecuteNonQuery()
                                gconnection.closeConnection()
                            Else
                                crstopmsg = ""
                                'txt_ServerCode.Focus()
                                If txt_ServerCode.ReadOnly = True Then
                                    txt_LOCATIONCODE.Focus()
                                Else
                                    txt_ServerCode.Focus()
                                End If
                            End If
                            ' Txt_Remarks.Text = LABDUE.Text    '"L-Credit: " & Format(pcredit, "0.00") & "  L-Debit: " & Format(pdebit, "0.00") & "  L-Closing: " & Format(pclbal, "0.00") & "  C-Credit: " & Format(ccredit, "0.00") & "  C-Debit: " & Format(cdebit, "0.00") & "  C-Closing: " & Format(cclbal, "0.00")
                            txt_MemberCode.Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                            txt_MemberName.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")

                            If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                                strstring = "SELECT * FROM party_hallbooking_hdr WHERE MCODE = '" & Trim(txt_MemberCode.Text) & "' AND BOOKINGNO = '" & Val(Txt_PartyBookingNo.Text) & "' "
                                gconnection.getDataSet(strstring, "membermasterparty")
                                If gdataset.Tables("membermasterparty").Rows.Count > 0 Then
                                Else
                                    txt_MemberCode.Text = ""
                                    txt_MemberName.Text = ""
                                    MessageBox.Show("Check Booking No")
                                    txt_MemberCode.Focus()
                                End If
                            End If
                            'Else
                            '    txt_MemberCode.Text = ""
                            '    txt_MemberCode.Focus()
                            ' End If
                        Else
                            'txt_ServerCode.Focus()
                            If txt_ServerCode.ReadOnly = True Then
                                txt_LOCATIONCODE.Focus()
                            Else
                                txt_ServerCode.Focus()
                            End If
                        End If
                    Else
                        strstring = "SELECT isnull(mcode,'') as mcode,isnull(mname,'') as mname,isnull(curentstatus,'') as termination FROM VIEWMEMBER WHERE MCODE='" & Trim(txt_MemberCode.Text) & "' "
                        gconnection.getDataSet(strstring, "membermaster")
                        If gdataset.Tables("membermaster").Rows.Count > 0 Then
                            Txt_Remarks.Text = "MEMBERSHIP " & "." & gdataset.Tables("membermaster").Rows(0).Item("termination")

                            If MsgBox("MEMBERSHIP NOT. FOUND...as membership   " & gdataset.Tables("membermaster").Rows(0).Item("termination"), MsgBoxStyle.OkCancel, "chs") = MsgBoxResult.Ok Then
                                txt_MemberCode.Text = ""
                                txt_MemberCode.Focus()
                            Else
                                txt_MemberCode.Text = ""
                                txt_MemberCode.Focus()

                            End If
                        Else
                            txt_MemberCode.Text = ""
                            txt_MemberCode.Focus()
                        End If
                    End If
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub cmd_ServerCodeHelp_Click(sender As Object, e As EventArgs) Handles cmd_ServerCodeHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT Servercode, Servername FROM servermaster"
        M_WhereCondition = " WHERE ISNULL(FREEZE,'') <>'Y'"
        vform.Field = " SERVERCODE,SERVERNAME "
        'vform.vFormatstring = "         SERVER CODE            |                       SERVERNAME                               "
        vform.vCaption = "SERVER MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_ServerCode.Text = Trim(vform.keyfield & "")
            txt_ServerName.Text = Trim(vform.keyfield1 & "")
            sSGrid.Focus()
            sSGrid.SetActiveCell(1, 1)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_ServerCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_ServerCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Me.cmd_ServerCodeHelp.Enabled = True Then
                Call cmd_ServerCodeHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txt_ServerCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ServerCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_ServerCode.Text) <> "" Then
                txt_ServerCode_Validated(sender, e)
            Else
                Call cmd_ServerCodeHelp_Click(cmd_ServerCodeHelp, e)
            End If
        End If
    End Sub
    Private Sub txt_ServerCode_Validated(sender As Object, e As EventArgs) Handles txt_ServerCode.Validated
        Dim strstring As String
        Dim I As Integer
        If Trim(txt_ServerCode.Text) <> "" Then
            strstring = "SELECT * FROM servermaster WHERE ServerCode='" & Trim(txt_ServerCode.Text) & "'AND ISNULL(Freeze,'')<>'Y'"
            gconnection.getDataSet(strstring, "servermaster")
            If gdataset.Tables("servermaster").Rows.Count > 0 Then
                txt_ServerCode.Text = gdataset.Tables("servermaster").Rows(0).Item("ServerCode")
                txt_ServerName.Text = gdataset.Tables("servermaster").Rows(0).Item("ServerName")
                sSGrid.SetActiveCell(1, 1)
                txt_LOCATIONCODE.Focus()
                'sSGrid.Focus()
            Else
                txt_ServerCode.Text = ""
                txt_ServerCode.Focus()
            End If
        Else
        End If
    End Sub
    Public Sub CreditCheck()
        SQLSTRING = "SELECT ISNULL(MEMLIMIT,0) AS MEMLIMIT FROM MEMBERMASTER WHERE MCODE = '" & Trim(txt_MemberCode.Text) & "'"
        gconnection.getDataSet(SQLSTRING, "CRLIMIT")
        If gdataset.Tables("CRLIMIT").Rows.Count > 0 Then
            CrLimit = gdataset.Tables("CRLIMIT").Rows(0).Item(0)
        Else
            CrLimit = 0
        End If
        SQLSTRING = "SELECT  ISNULL(MCode,'') AS Mcode FROM MEMBERMASTER Where MCODE ='" & Trim(txt_MemberCode.Text) & "'"
        gconnection.getDataSet(SQLSTRING, "MEMBERMASTER")
        If gdataset.Tables("MEMBERMASTER").Rows.Count > 0 Then
            MainCode = gdataset.Tables("MEMBERMASTER").Rows(0).Item("Mcode")
            SQLSTRING = "SELECT SLCODE,ISNULL(SUM(DEB),0)-ISNULL(SUM(CRE),0) AS CLS FROM Get_CreditBal WHERE SLCODE = '" & Trim(MainCode) & "' GROUP BY SLCODE ORDER BY SLCODE"
            gconnection.getDataSet(SQLSTRING, "CLSAMT")
            If gdataset.Tables("CLSAMT").Rows.Count > 0 Then
                CrLimitAmt = CrLimit - gdataset.Tables("CLSAMT").Rows(0).Item("CLS")
            Else
                CrLimitAmt = 0
            End If
        End If
    End Sub
    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        Dim SSQL, SALETYPE As String
        Dim PAY As String
        Dim Qty As Integer
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, Pos, KStatus As String
        Dim TPercent, RoomPer, PartyPer As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt As Double
        PAY = ""
        'SMART CARD
        'ROOM CHECKIN
        'MEMBER ACCOUNT
        'BANK INSTRUMENT
        'CASH
        'CLUB ACCOUNT
        'EMPLOYEE
        If gCenterlized = "Y" Then
            SALETYPE = "SALE"
        Else
            SALETYPE = DOCTYPE
        End If
        'If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
        '    MsgBox("Cannot be updated delete and enter again.....................")
        '    Exit Sub
        'End If
        SSQL = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(SSQL, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
        Else
            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
            Exit Sub
        End If
        'If txt_MemberCode.Text = "" Then
        '    Call Cmd_Clear_Click(sender, e)
        '    Exit Sub
        'End If
        Dim Totalamount, Taxamount, Calamount, Caltax, CalBilamount, calhighratio, CardAmount, PKOTAMT As Double
        Dim cancelamt, canceltax, cancel, SubpaymentMode(), paymentaccountcode, Subpaymentaccountcode, ITEMCODE As String
        Dim x, y, _itemcode, costinguom, Billdetails As String
        Dim kotupd() As String
        Dim sqlstring, varchk, SelectedAutoid As String
        Dim Insert(0), StrUpdate(0), caldoublevalue, VARSQL As String
        Dim i, j, Z As Integer
        Dim Gridbool As Boolean
        'REFERINVENTORY**********************************************************************************************
        Dim POSLOCATION, POSITEMCODE, POSITEMUOM As String
        Dim AVGRATE, AVGQUANTITY, dblCalqty As Double
        Dim K As Integer
        '************************************************************************************************************
        Call checkvalidate() '''---> Check Validation
        If chkbool = False Then Exit Sub
        '''*********************************************************** Case-1 : Add [F7] *******************************************'''
        Call Calculate()
        Call CheckBillAmt()
        Call CreditCheck()
        sqlstring = "SELECT MCODE,SUM(ISNULL(AMOUNT,0))+SUM(ISNULL(TAXAMOUNT,0))+SUM(ISNULL(PACKAMOUNT,0))+SUM(ISNULL(TIPSAMT,0))+SUM(ISNULL(ADCGSAMT,0))+SUM(ISNULL(PARTYAMT,0))+SUM(ISNULL(ROOMAMT,0)) AS PKOT FROM KOT_DET "
        sqlstring = sqlstring & " WHERE ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(BILLDETAILS,'') = '' AND PAYMENTMODE = '" & Trim(cbo_PaymentMode.Text) & "' AND MCODE = '" & Trim(txt_MemberCode.Text) & "' GROUP BY MCODE"
        gconnection.getDataSet(sqlstring, "PKOT")
        If gdataset.Tables("PKOT").Rows.Count > 0 Then
            PKOTAMT = gdataset.Tables("PKOT").Rows(0).Item(1)
        Else
            PKOTAMT = 0
        End If
        sqlstring = "select mcode from memberblocking where mcode='" & Trim(txt_MemberCode.Text) & "' and valid ='N' "
        gconnection.getDataSet(sqlstring, "curdet")
        If gdataset.Tables("curdet").Rows.Count > 0 Then
        Else
            If Trim(cbo_PaymentMode.Text) = "CREDIT" Then
                If CrLimitAmt < (Val(GrdAmount) + Val(PKOTAMT)) Then
                    MsgBox("CREDIT BALANCE NOT AVAILABLE", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        End If
        'If Trim(cbo_PaymentMode.Text) = "CREDIT" Then
        '    If CrLimitAmt < (Val(GrdAmount) + Val(PKOTAMT)) Then
        '        MsgBox("CREDIT BALANCE NOT AVAILABLE", MsgBoxStyle.Critical)
        '        Exit Sub
        '    End If
        'End If
        If Trim(cbo_PaymentMode.Text) = "SMART CARD" Then
            If (MIN_USAGE_BALANCE_HDR + BALANCE_HDR) - MIN_BALANCE_GBL < (Val(GrdAmount) + Val(PKOTAMT)) Then
                MsgBox("CARD BALANCE NOT AVAILABLE", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If
        SSQL = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(SSQL, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
        Else
            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
            Exit Sub
        End If
        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
            Txt_PartyBookingNo.Text = Val(Txt_PartyBookingNo.Text)
        Else
            Txt_PartyBookingNo.Text = ""
        End If
        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            dblMsg = 0
            Call Autogenerate() '''---> AUTO GENERATE
            If Mid(pKotType, 1, 1) = "A" Or Mid(gKotType, 1, 1) = "A" Then
                KOTno = Split(Trim(txt_KOTno.Text), "/")
            Else
                ReDim KOTno(2)
                KOTno(0) = DOCTYPE
                KOTno(1) = Trim(txt_KOTno.Text)
            End If

            '''******************************************* Find Out Paymentmode Accountcode and Subpaymentmode Accountcode *********************'''
            If Me.cbo_SubPaymentMode.Visible = True Then
                SubpaymentMode = Split(Trim(Me.cbo_SubPaymentMode.Text), "-")
                sqlstring = "SELECT ISNULL(Accountin,'') AS Accountin FROM subpaymentmode WHERE Subpaymentcode ='" & Trim(SubpaymentMode(0)) & "' AND ISNULL(Freeze,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "subpaymentmode")
                If gdataset.Tables("subpaymentmode").Rows.Count > 0 Then
                    Subpaymentaccountcode = Trim(gdataset.Tables("subpaymentmode").Rows(0).Item("Accountin") & "")
                End If
            Else
                ReDim Preserve SubpaymentMode(1)
                SubpaymentMode(0) = ""
                Subpaymentaccountcode = ""
            End If
            sqlstring = "SELECT ISNULL(Accountin,'') AS Accountin FROM Paymentmodemaster WHERE Paymentcode ='" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(Freeze,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "Paymentmodemaster")
            If gdataset.Tables("Paymentmodemaster").Rows.Count > 0 Then
                paymentaccountcode = Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin") & "")
            Else
                MessageBox.Show("Assign a AccountCode For Specified PAYMENTMODE", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                paymentaccountcode = ""
                Exit Sub
            End If
            '''*********************************************************** COMPLETE ************************************************************'''
            'If CHECK_KOTEXIST(Trim(KOTno(1))) = False Then
            If PAY = "ROOM CHECKIN" Then
                sqlstring = "INSERT INTO KOT_HDR(TTYPE,KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,Total,TotalTax,BillAmount,PackAmt,packingpercent,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                sqlstring = sqlstring & "Receiptstatus,Roundoff,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,[16_digit_code],cardholdercode,cardholdername) "
                sqlstring = sqlstring & " VALUES ('ROOMGUEST','" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy HH:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & DOCTYPE & "','" & SALETYPE & "','" & accountcode & "','','','','" & Trim(txt_MemberCode.Text) & "', "
                sqlstring = sqlstring & "'" & Trim(txt_MemberName.Text) & "','" & Trim(txt_MemberCode.Tag) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerName.Text) & "','" & Trim(cbo_PaymentMode.Text) & "',"
                'sqlstring = sqlstring & "'" & DOCTYPE & "','AUTO'," & Val(txt_TotalValue.Text) & "," & Val(txt_TaxValue.Text) & "," & Val(txt_BillAmount.Text) & "," & Val(Txt_PackingValue.Text) & "," & Val(PACKINGPERCENT) & ",'PO','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                sqlstring = sqlstring & "'" & DOCTYPE & "','AUTO'," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",'PO','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                sqlstring = sqlstring & "'N'," & Math.Round(Val(0)) & ",0,'','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','N','" & Trim(paymentaccountcode) & " ','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','N','N','','" & Trim(txt_LOCATIONCODE.Text) & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "')"
            ElseIf cbo_PaymentMode.SelectedItem = "R.MEMBER" Then
                sqlstring = "INSERT INTO KOT_HDR(TTYPE,KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,Total,TotalTax,BillAmount,PackAmt,packingpercent,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                sqlstring = sqlstring & "Receiptstatus,Roundoff,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,[16_digit_code],cardholdercode,cardholdername) "
                sqlstring = sqlstring & " VALUES ('R.MEMBER','" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy HH:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & DOCTYPE & "','" & SALETYPE & "','" & accountcode & "','" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','', "
                sqlstring = sqlstring & "'','','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerName.Text) & "','" & Trim(cbo_PaymentMode.Text) & "',"
                sqlstring = sqlstring & "'" & DOCTYPE & "','AUTO'," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",'PO','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                sqlstring = sqlstring & "'N'," & Math.Round(Val(0)) & ",'" & Val(Txt_PartyBookingNo.Text) & "','','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','N','" & Trim(paymentaccountcode) & " ','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','N','N','','" & Trim(txt_LOCATIONCODE.Text) & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "')"
            ElseIf PAY = "MEMBER ACCOUNT" Then
                sqlstring = "INSERT INTO KOT_HDR(TTYPE,KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,Total,TotalTax,BillAmount,PackAmt,packingpercent,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                sqlstring = sqlstring & "Receiptstatus,Roundoff,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,[16_digit_code],cardholdercode,cardholdername) "
                sqlstring = sqlstring & " VALUES ('CLUBMEMBER','" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy HH:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & DOCTYPE & "','" & SALETYPE & "','" & accountcode & "','" & Trim(txt_MemberCode.Text) & "', "
                sqlstring = sqlstring & "'" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','','','','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerName.Text) & "','" & Trim(cbo_PaymentMode.Text) & "',"
                sqlstring = sqlstring & "'" & DOCTYPE & "','AUTO'," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",'PO','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                sqlstring = sqlstring & "'N'," & Math.Round(Val(0)) & ",'" & Val(Txt_PartyBookingNo.Text) & "','','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','N','" & gDebtors & " ','" & Trim(txt_MemberCode.Text) & "','" & Trim(Txt_Remarks.Text) & "','N','N','','" & Trim(txt_LOCATIONCODE.Text) & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "')"
            ElseIf PAY = "SMART CARD" Then
                sqlstring = "INSERT INTO KOT_HDR(TTYPE,KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,Total,TotalTax,BillAmount,PackAmt,packingpercent,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                sqlstring = sqlstring & "Receiptstatus,Roundoff,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,[16_digit_code],cardholdercode,cardholdername,SMARTBILL) "
                sqlstring = sqlstring & " VALUES ('" & ordertype & "','" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy HH:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & DOCTYPE & "','" & SALETYPE & "','" & accountcode & "','" & Trim(txt_MemberCode.Text) & "', "
                sqlstring = sqlstring & "'" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','','','','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerName.Text) & "','" & Trim(cbo_PaymentMode.Text) & "',"
                sqlstring = sqlstring & "'" & DOCTYPE & "','AUTO'," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",'PO','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                sqlstring = sqlstring & "'N'," & Math.Round(Val(0)) & ",'" & Val(Txt_PartyBookingNo.Text) & "','','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','N','" & gDebtors & " ','" & Trim(txt_MemberCode.Text) & "','" & Trim(Txt_Remarks.Text) & "','N','N','','" & Trim(txt_LOCATIONCODE.Text) & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "','Y')"
            Else
                sqlstring = "INSERT INTO KOT_HDR(TTYPE,KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,SLCode,MCode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,Total,TotalTax,BillAmount,Packamt,packingpercent,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                sqlstring = sqlstring & "Receiptstatus,Roundoff,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,[16_digit_code],cardholdercode,cardholdername) "
                sqlstring = sqlstring & " VALUES ('" & ordertype & "','" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy HH:mm:ss") & "','" & Trim(txt_TableNo.Text) & "'," & Val(txt_Cover.Text) & ",'" & DOCTYPE & "','" & SALETYPE & "','" & accountcode & "','" & Trim(txt_MemberCode.Text) & "', "
                sqlstring = sqlstring & "'" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_MemberName.Text) & "','','','','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerCode.Text) & "','" & Trim(txt_ServerName.Text) & "','" & Trim(cbo_PaymentMode.Text) & "',"
                sqlstring = sqlstring & "'" & DOCTYPE & "','AUTO'," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(0) & ",'PO','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                sqlstring = sqlstring & "'N'," & Math.Round(Val(0)) & ",'" & Val(Txt_PartyBookingNo.Text) & "','','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','N','" & Trim(paymentaccountcode) & " ','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','N','N','','" & Trim(txt_LOCATIONCODE.Text) & "','" & txt_card_id.Text & "','" & txt_Holder_Code.Text & "','" & Txt_holder_name.Text & "')"
            End If
            Insert(0) = sqlstring
            '''******************************************************** Insert into KOT_DET **********************************'''
            For i = 1 To sSGrid.DataRowCnt
                sqlstring = "INSERT INTO KOT_DET(TTYPE,KotNo,KOTdetails,KotDate,KotType,PaymentMode,Mcode,Scode,Covers,TableNo,TotAmt,TaxAmt,BillAmt,ChkId,ItemCode,Itemdesc,Poscode,Uom,Qty,Rate,Taxamount,Amount,ItemType,TaxCode,TaxPerc,TaxAccountCode,SalesAccountCode,GroupCode,SUBGroupCode,"
                sqlstring = sqlstring & "Taxtype,Alcholst,Adduserid,Adddatetime,Upduserid,Upddatetime,PROMOTIONALST,KOTStatus,delflag) "
                sqlstring = sqlstring & "VALUES('" & ordertype & "','" & Trim(CStr(KOTno(1))) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy HH:mm:ss") & "','SALE','" & Trim(cbo_PaymentMode.Text) & "',"
                sqlstring = sqlstring & "'" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_ServerCode.Text) & "'," & Val(Me.txt_Cover.Text) & ",'" & Trim(Me.txt_TableNo.Text) & "'," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(Me.txt_MemberCode.Tag) & ""
                sSGrid.Row = i
                sSGrid.Col = 1
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 2
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 3
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 4
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 5
                sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                sSGrid.Col = 6
                sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                sSGrid.Col = 7
                sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                sSGrid.Col = 8
                sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                sSGrid.Col = 9
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 10
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                sSGrid.Col = 11
                sqlstring = sqlstring & "," & Val(sSGrid.Text) & " "
                sSGrid.Col = 13
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                sSGrid.Col = 14
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                sSGrid.Col = 15
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                sSGrid.Col = 16
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                sSGrid.Col = 9
                If Trim(sSGrid.Text) = "BAR" Then
                    sqlstring = sqlstring & ",'','Y'"
                ElseIf Trim(sSGrid.Text) = "SD" Then
                    sqlstring = sqlstring & ",'SALES','S'"
                Else
                    sqlstring = sqlstring & ",'SALES','N'"
                End If
                sqlstring = sqlstring & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "'"
                sSGrid.Col = 18
                sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                sSGrid.Col = 12
                If Trim(sSGrid.Text) = "Yes" Then
                    sqlstring = sqlstring & ",'Y','N')"
                Else
                    sqlstring = sqlstring & ",'N','N')"
                End If
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                Dim SUBSTORECODE As String
                sSGrid.Row = i
                sSGrid.Col = 3
                POSLOCATION = Trim(sSGrid.Text)
                sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & Trim(POSLOCATION) & "' AND ISNULL(FREEZE,'') <> 'Y'"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    sSGrid.Row = i
                    sSGrid.Col = 1
                    POSITEMCODE = Trim(sSGrid.Text)
                    sSGrid.Row = i
                    sSGrid.Col = 4
                    POSITEMUOM = Trim(sSGrid.Text)

                    sqlstring = "SELECT GITEMCODE,GITEMNAME,GUOM,GQTY,GRATE,GAMOUNT,GDBLAMT,GHIGHRATIO,GGROUPCODE,GSUBGROUPCODE,VOID FROM BOM_DET WHERE"
                    sqlstring = sqlstring & " ITEMCODE='" & POSITEMCODE & "' AND ITEMUOM='" & POSITEMUOM & "' AND ISNULL(VOID,'') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "BOM")
                    If gdataset.Tables("BOM").Rows.Count > 0 Then
                        For K = 0 To gdataset.Tables("BOM").Rows.Count - 1

                            sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(POSLOCATION) & "' AND ITEMCODE='" & gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "'"
                            gconnection.getDataSet(sqlstring, "SUBSTORE")
                            If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                            End If
                            sqlstring = "INSERT INTO SUBSTORECONSUMPTIONDETAIL(Docno,Docdetails,Docdate,Storelocationcode,STORELOCATIONNAME,"
                            sqlstring = sqlstring & " Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                            sqlstring = sqlstring & " Dblamt,Highratio,Groupcode,Subgroupcode,Void,Adduser,adddatetime,Updateuser,Updatetime)"
                            sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                            sqlstring = sqlstring & " '" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy") & "',"
                            sqlstring = sqlstring & " '" & Trim(SUBSTORECODE) & "',"
                            sqlstring = sqlstring & " '" & Trim(STORELOCATION(Trim(SUBSTORECODE))) & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMNAME") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GUOM") & "") & "',"
                            sSGrid.Col = 5
                            sSGrid.Row = i
                            dblCalqty = Val(sSGrid.Text)
                            sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) & ","
                            AVGRATE = CalAverageRate(Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & ""))
                            'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                            sqlstring = sqlstring & AVGRATE & ","
                            sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) * AVGRATE & ","
                            'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                            sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GDBLAMT")) & ","
                            sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GHIGHRATIO")) & ","
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GGROUPCODE") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GSUBGROUPCODE") & "") & "',"
                            sqlstring = sqlstring & "'N'," '& Format(Val(AVGQUANTITY), "0.000") & "," & Format(Val(AVGRATE), "0.00") & ","
                            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "',"
                            sqlstring = sqlstring & " ' ','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next K
                    Else

                        sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(POSLOCATION) & "' AND ITEMCODE='" & POSITEMCODE & "'"
                        gconnection.getDataSet(sqlstring, "SUBSTORE")
                        If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                            SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                        End If
                        sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0.00) AS PURCHASERATE,"
                        sqlstring = sqlstring & " ISNULL(I.STOCKUOM,'') AS CONVUOM,1 AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                        sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
                        sqlstring = sqlstring & " WHERE I.ITEMCODE='" & POSITEMCODE & "' AND I.STOCKUOM='" & POSITEMUOM & "' AND ISNULL(FREEZE,'') <> 'Y' and i.storecode='" & Trim(SUBSTORECODE) & "'"
                        gconnection.getDataSet(sqlstring, "DIRECT_STOCK")
                        If gdataset.Tables("DIRECT_STOCK").Rows.Count > 0 Then
                            sqlstring = "INSERT INTO SUBSTORECONSUMPTIONDETAIL(Docno,Docdetails,Docdate,Storelocationcode,STORELOCATIONNAME,"
                            sqlstring = sqlstring & " Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                            sqlstring = sqlstring & " Dblamt,Highratio,Groupcode,Subgroupcode,Void,Adduser,adddatetime,Updateuser,Updatetime)"
                            sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                            sqlstring = sqlstring & " '" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy") & "',"
                            sqlstring = sqlstring & " '" & Trim(SUBSTORECODE) & "',"
                            sqlstring = sqlstring & " '" & Trim(STORELOCATION(Trim(SUBSTORECODE))) & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMNAME") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("STOCKUOM") & "") & "',"
                            sSGrid.Col = 5
                            sSGrid.Row = i
                            dblCalqty = Val(sSGrid.Text)
                            sqlstring = sqlstring & dblCalqty & ","
                            AVGRATE = CalAverageRate(Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & ""))
                            'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                            sqlstring = sqlstring & AVGRATE & ","
                            sqlstring = sqlstring & dblCalqty * AVGRATE & ","
                            'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                            sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ","
                            sqlstring = sqlstring & Val(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ","
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("GROUPCODE") & "") & "',"
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("SUBGROUPCODE") & "") & "',"
                            sqlstring = sqlstring & "'N'," '& Format(Val(AVGQUANTITY), "0.000") & "," & Format(Val(AVGRATE), "0.00") & ","
                            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "',"
                            sqlstring = sqlstring & " ' ','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        End If
                    End If
                End If
            Next i
            For i = 1 To sSGrid.DataRowCnt
                Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                With sSGrid
                    .Col = 1
                    .Row = i
                    ITEMCODE = Trim(.Text)
                    .Col = 6
                    .Row = i
                    GrdRate = .Text
                    .Col = 5
                    .Row = i
                    Qty = Val(.Text)
                    .Col = 3
                    .Row = i
                    Pos = Trim(.Text)
                    .Col = 12
                    .Row = i
                    KStatus = Mid(Trim(.Text), 1, 1)
                    .Col = 9
                    .Row = i
                    ChargeCode = Trim(.Text)
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    gconnection.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    gconnection.getDataSet(sqlstring, "TAXON")
                    If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                        For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                            IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                            Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                            Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                            TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                            StrSql = "INSERT INTO KOT_DET_TAX (KOTDETAILS,KOTDATE,TTYPE,CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,ADD_USER,ADD_DATE,VOID,VOIDUSER) VALUES ( "
                            StrSql = StrSql & "'" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(CMB_BTYPE.Text) & "','" & Trim(ChargeCode) & "','" & Trim(IType) & "','" & Trim(Pos) & "','" & Trim(ITEMCODE) & "','" & Trim(KStatus) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (GrdRate) & "," & (Qty) & "," & (TPercent) & ","

                            If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZero = GZero + Zero
                                StrSql = StrSql & "" & Val(Zero) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroA = GZeroA + ZeroA
                                StrSql = StrSql & "" & Val(ZeroA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroB = GZeroB + ZeroB
                                StrSql = StrSql & "" & Val(ZeroB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOne = GOne + One
                                StrSql = StrSql & "" & Val(One) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneA = GOneA + OneA
                                StrSql = StrSql & "" & Val(OneA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneB = GOneB + OneB
                                StrSql = StrSql & "" & Val(OneB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwo = GTwo + Two
                                StrSql = StrSql & "" & Val(Two) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoA = GTwoA + TwoA
                                StrSql = StrSql & "" & Val(TwoA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoB = GTwoB + TwoB
                                StrSql = StrSql & "" & Val(TwoB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThree = GThree + Three
                                StrSql = StrSql & "" & Val(Three) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeA = GThreeA + ThreeA
                                StrSql = StrSql & "" & Val(ThreeA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeB = GThreeB + ThreeB
                                StrSql = StrSql & "" & Val(ThreeB) * Qty & ","
                            End If
                            StrSql = StrSql & "'" & Trim(gUsername) & "',getdate(),'N','')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = StrSql
                        Next
                    End If
                End With
            Next
            For i = 1 To sSGrid.DataRowCnt
                Dim aid As Integer
                With sSGrid
                    .Col = 1
                    .Row = i
                    ITEMCODE = Trim(.Text)
                    .Col = 5
                    .Row = i
                    Qty = Val(.Text)
                    .Col = 8
                    .Row = i
                    GAmt = Val(.Text)
                    If gCenterlized = "Y" Then
                        TPackAmt = Val((GAmt * gPackPer) / 100)
                        TTipsAmt = Val((GAmt * gTipsPer) / 100)
                        TAdchgAmt = Val((GAmt * gAdCgsPer) / 100)
                        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                            TPartyAmt = Val((GAmt * gPartyPer) / 100)
                            PartyPer = gPartyPer
                        Else
                            TPartyAmt = 0
                            PartyPer = 0
                        End If
                        If PAY = "ROOM CHECKIN" Then
                            TRoomAmt = Val((GAmt * gRoomPer) / 100)
                            RoomPer = gRoomPer
                        Else
                            RoomPer = 0
                            TRoomAmt = 0
                        End If
                    Else
                        TPackAmt = Val((GAmt * pPackPer) / 100)
                        TTipsAmt = Val((GAmt * pTipsPer) / 100)
                        TAdchgAmt = Val((GAmt * pAdCgsPer) / 100)
                        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                            TPartyAmt = Val((GAmt * pPartyPer) / 100)
                            PartyPer = pPartyPer
                        Else
                            TPartyAmt = 0
                            PartyPer = 0
                        End If
                        If PAY = "ROOM CHECKIN" Then
                            TRoomAmt = Val((GAmt * pRoomPer) / 100)
                            RoomPer = pRoomPer
                        Else
                            RoomPer = 0
                            TRoomAmt = 0
                        End If
                    End If
                    If gCenterlized = "Y" Then
                        sqlstring = "UPDATE KOT_DET SET PACKPERCENT = " & gPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & gTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & gAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                        sqlstring = sqlstring & " WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "' "
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    Else
                        sqlstring = "UPDATE KOT_DET SET PACKPERCENT = " & pPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & pTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & pAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                        sqlstring = sqlstring & " WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "' "
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    End If
                End With
            Next
            gconnection.MoreTransold(Insert)

            sqlstring = "UPDATE KOT_DET SET TAXAMOUNT = 0 WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            StrUpdate(0) = sqlstring

            sqlstring = "UPDATE KOT_DET SET PACKAMOUNT = (AMOUNT * PACKPERCENT)/100,TipsAmt = (AMOUNT * TipsPer)/100,AdCgsAmt = (AMOUNT * AdCgsPer) /100,PartyAmt = (AMOUNT *PartyPer) / 100, RoomAmt = (AMOUNT * RoomPer)/100  WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = " UPDATE KOT_HDR SET PackAmt = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TAXAMOUNT = (SELECT ISNULL(SUM(KOT_DET_TAX.TAXAMT),0) FROM KOT_DET_TAX WHERE KOT_DET.KOTDETAILS = KOT_DET_TAX.KOTDETAILS AND KOT_DET_TAX.ITEMCODE = KOT_DET.ITEMCODE  GROUP BY KOTDETAILS,ITEMCODE)"
            sqlstring = sqlstring & " WHERE KOT_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TAXAMT = (SELECT ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'  AND ISNULL(KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL1")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TOTAMT = (SELECT ISNULL(SUM(AMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ISNULL(KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL2")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_DET SET BILLAMT = (SELECT ISNULL(SUM(AMOUNT),0)+ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            sqlstring = "UPDATE KOT_DET SET BILLAMT = (SELECT ISNULL(SUM(AMOUNT),0)+ISNULL(SUM(TAXAMOUNT),0)+ISNULL(SUM(PACKAMOUNT),0)+ISNULL(SUM(TipsAmt),0)+ISNULL(SUM(AdCgsAmt),0)+ISNULL(SUM(PartyAmt),0)+ISNULL(SUM(RoomAmt),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_HDR SET TotalTax = TAXAMT,Total = TOTAMT,BillAmount = BILLAMT FROM KOT_DET K ,KOT_HDR H WHERE K.KOTDETAILS = H.Kotdetails AND K.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' "
            ''gconnection.dataOperation(9, sqlstring, "TOTAL4")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET TotalTax = (SELECT ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET Total = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET BillAmount = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0)+ISNULL(SUM(KOT_DET.TAXAMOUNT),0)+ISNULL(SUM(KOT_DET.PACKAMOUNT),0)+ISNULL(SUM(KOT_DET.TipsAmt),0)+ISNULL(SUM(KOT_DET.AdCgsAmt),0)+ISNULL(SUM(KOT_DET.PartyAmt),0)+ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            gconnection.MoreTrans1(StrUpdate)

            sqlstring = "UPDATE KOT_DET SET CATEGORY=A.CATEGORY FROM VIEW_ITEMMASTER A WHERE A.ITEMCODE=KOT_DET.ITEMCODE AND KOTDETAILS='" & Trim(txt_KOTno.Text) & "'"
            gconnection.dataOperation(9, sqlstring, "CAT")

            'sqlstring = "EXEC UPD_PACK '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(6, sqlstring, "UPD_PACK")


            sqlstring = "Update KOT_HDR Set KotNo = '" & CStr(KOTno(1)) & "', KotDetails = '" & Trim(txt_KOTno.Text) & "' Where  ltrim(rtrim(KotDetails)) ='" & Trim(KOTno(1)) & "' and ltrim(rtrim(mcode))='" & Trim(txt_MemberCode.Text) & "' and ltrim(rtrim(stcode))='" & Trim(txt_ServerCode.Text) & "'"
            sqlstring = "Update KOT_HDR Set KotNo = '" & CStr(KOTno(1)) & "', KotDetails = '" & Trim(txt_KOTno.Text) & "' Where  ltrim(rtrim(KotDetails)) ='" & Trim(KOTno(1)) & "' and ltrim(rtrim(stcode))='" & Trim(txt_ServerCode.Text) & "'"
            gconnection.dataOperation(6, sqlstring, "KotHdr")
            sqlstring = "Update KOT_DET Set KotNo = '" & CStr(KOTno(1)) & "', KotDetails = '" & Trim(txt_KOTno.Text) & "' Where  ltrim(rtrim(KotDetails)) ='" & Trim(KOTno(1)) & "' and ltrim(rtrim(scode))='" & Trim(txt_ServerCode.Text) & "'"
            gconnection.dataOperation(6, sqlstring, "KotDet")
            sqlstring = "Update SUBSTORECONSUMPTIONDETAIL Set DocNo = '" & CStr(KOTno(1)) & "', DocDetails = '" & Trim(txt_KOTno.Text) & "' Where  DocDetails Like '" & gPoSUsername & "%'"
            gconnection.dataOperation(6, sqlstring, "SubStore")

            'End
            If dblMsg <> 1 Then
                'If CHK_PRINT.Checked = True Then
                'If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                '    Call Cmd_Print_Click(sender, e)
                '    If MessageBox.Show("Do You Want Go Final Bill ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                '        GmoduleName = "Final Billing"
                '        Try
                '            sqlstring = "SELECT ISNULL(centralizedkot,'N') AS CENTRALIZEDKOT,ISNULL(FINALPREFIX,'') AS FINALPREFIX,ISNULL(KOTTYPE,'') AS KOTTYPE FROM POSSETUP"
                '            gconnection.getDataSet(sqlstring, "CEN_CHECK")
                '            If gdataset.Tables("CEN_CHECK").Rows.Count > 0 Then
                '                If Mid(gdataset.Tables("CEN_CHECK").Rows(0).Item(0), 1, 1) = "Y" Then
                '                    sqlstring = "SELECT ISNULL(PACKINGPERCENT,0) AS PACKPER,ISNULL(TIPS,0) AS TIPS_SER,ISNULL(ADCHARGE,0) AS ADCHARGE,ISNULL(PRCHARGE,0) AS PRCHARGE,ISNULL(GRCHARGE,0) AS GRCHARGE,ISNULL(KOTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(FINALPREFIX,'') AS FINALPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ,ISNULL(WAITREQR,'') AS WAITREQR FROM POSSETUP"
                '                    gconnection.getDataSet(sqlstring, "POSSETUP")
                '                    If gdataset.Tables("POSSETUP").Rows.Count > 0 Then
                '                        gTableReq = gdataset.Tables("POSSETUP").Rows(0).Item("TABLEREQ")
                '                        gWaiterReq = gdataset.Tables("POSSETUP").Rows(0).Item("WAITREQR")
                '                        gKotType = gdataset.Tables("POSSETUP").Rows(0).Item("KOTTYPE")
                '                        gKotPrefix = gdataset.Tables("POSSETUP").Rows(0).Item("FINALPREFIX")
                '                        DefaultPayment = gdataset.Tables("POSSETUP").Rows(0).Item("PAYMENTMODE")
                '                    End If
                '                    If Trim(gdataset.Tables("CEN_CHECK").Rows(0).Item(2)) = "AUTO" Then
                '                        gKotType = "A"
                '                    Else
                '                        gKotType = "M"
                '                    End If
                '                    gCenterlized = "Y"
                '                    FKot = "Y"
                '                    Fkotscode = txt_ServerCode.Text
                '                    Fkotpaymode = cbo_PaymentMode.Text
                '                    FkotMcode = txt_MemberCode.Text
                '                    Dim SMPS As New FRM_TKGA_FinalBilling("", Trim(gdataset.Tables("CEN_CHECK").Rows(0).Item(1)))
                '                    SMPS.Show()
                '                    SMPS.MdiParent = MDIParentobj
                '                ElseIf Mid(gdataset.Tables("CEN_CHECK").Rows(0).Item(0), 1, 1) = "N" Then
                '                    gCenterlized = "N"
                '                    GmoduleName = "Final Billing"
                '                    FKot = "Y"
                '                    Fkotscode = txt_ServerCode.Text
                '                    Fkotpaymode = cbo_PaymentMode.Text
                '                    FkotMcode = txt_MemberCode.Text
                '                    Dim SMPS As New FRM_TKGA_FinalBilling(STRPOSCODE, DOCTYPE)
                '                    SMPS.Show()
                '                    SMPS.MdiParent = MDIParentobj
                '                End If
                '                Call Cmd_Clear_Click(sender, e)
                '                Me.Close()
                '            Else
                '                MessageBox.Show("Pos Setup Not Done Pleaze Check")
                '            End If
                '        Catch ex As Exception
                '            MsgBox(ex.Message)
                '        End Try
                '    End If
                '    'Call Cmd_Clear_Click(sender, e)
                '    If kotupdate = True Then
                '        Me.Close()
                '    End If
                '    'Else
                '    'Call Cmd_Clear_Click(sender, e)
                '    If kotupdate = True Then
                '        Me.Close()
                '    End If
                '    'End If
                'Else
                If MessageBox.Show("Do You Want Go Final Bill ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    GmoduleName = "Final Billing"
                    Try
                        sqlstring = "SELECT ISNULL(centralizedkot,'N') AS CENTRALIZEDKOT,ISNULL(FINALPREFIX,'') AS FINALPREFIX,ISNULL(KOTTYPE,'') AS KOTTYPE FROM POSSETUP"
                        gconnection.getDataSet(sqlstring, "CEN_CHECK")
                        If gdataset.Tables("CEN_CHECK").Rows.Count > 0 Then
                            If Mid(gdataset.Tables("CEN_CHECK").Rows(0).Item(0), 1, 1) = "Y" Then
                                sqlstring = "SELECT ISNULL(PACKINGPERCENT,0) AS PACKPER,ISNULL(TIPS,0) AS TIPS_SER,ISNULL(ADCHARGE,0) AS ADCHARGE,ISNULL(PRCHARGE,0) AS PRCHARGE,ISNULL(GRCHARGE,0) AS GRCHARGE,ISNULL(KOTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(FINALPREFIX,'') AS FINALPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ,ISNULL(WAITREQR,'') AS WAITREQR FROM POSSETUP"
                                gconnection.getDataSet(sqlstring, "POSSETUP")
                                If gdataset.Tables("POSSETUP").Rows.Count > 0 Then
                                    gTableReq = gdataset.Tables("POSSETUP").Rows(0).Item("TABLEREQ")
                                    gWaiterReq = gdataset.Tables("POSSETUP").Rows(0).Item("WAITREQR")
                                    gKotType = gdataset.Tables("POSSETUP").Rows(0).Item("KOTTYPE")
                                    gKotPrefix = gdataset.Tables("POSSETUP").Rows(0).Item("FINALPREFIX")
                                    DefaultPayment = gdataset.Tables("POSSETUP").Rows(0).Item("PAYMENTMODE")
                                End If
                                If Trim(gdataset.Tables("CEN_CHECK").Rows(0).Item(2)) = "AUTO" Then
                                    gKotType = "A"
                                Else
                                    gKotType = "M"
                                End If
                                gCenterlized = "Y"
                                FKot = "Y"
                                Fkotscode = txt_ServerCode.Text
                                Fkotpaymode = cbo_PaymentMode.Text
                                FkotMcode = txt_MemberCode.Text
                                Dim SMPS As New FRM_TKGA_FinalBilling("", Trim(gdataset.Tables("CEN_CHECK").Rows(0).Item(1)))
                                Call Cmd_Clear_Click(sender, e)
                                SMPS.Show()
                                SMPS.MdiParent = MDIParentobj
                            ElseIf Mid(gdataset.Tables("CEN_CHECK").Rows(0).Item(0), 1, 1) = "N" Then
                                gCenterlized = "N"
                                GmoduleName = "Final Billing"
                                FKot = "Y"
                                Fkotscode = txt_ServerCode.Text
                                Fkotpaymode = cbo_PaymentMode.Text
                                FkotMcode = txt_MemberCode.Text
                                Dim SMPS As New FRM_TKGA_FinalBilling(STRPOSCODE, DOCTYPE)
                                Call Cmd_Clear_Click(sender, e)
                                SMPS.Show()
                                SMPS.MdiParent = MDIParentobj
                            End If
                            'Call Cmd_Clear_Click(sender, e)
                            'Me.Close()
                        Else
                            MessageBox.Show("Pos Setup Not Done Pleaze Check")
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    Call Cmd_Clear_Click(sender, e)
                End If
                'Call Cmd_Clear_Click(sender, e)
                'Cmd_Add.Focus()
                'End If
            End If
            'Else
            'MsgBox("!!!!.........................!!!!!!!!")
            'End If
            '''*********************************************************** Case-2 : Update [F7] *******************************************'''
        ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then

            If Trim(txt_card_id.Text) = "" And PAY = "SMART CARD" Then
                MessageBox.Show("PLEASE! SWIPE YOUR CARD", "CARD NOT SWIPED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lbl_SwipeCard.Visible = True
                txt_card_id.Focus()
                '                lbl_SwipeCard.Focus()
                Exit Sub
            Else
                If PAY = "SMART CARD" Then
                    'Call cardcheck()
                End If
            End If

            KOTno = Split(Trim(txt_KOTno.Text), "/")

            '''******************************************* Find Out Paymentmode Accountcode and Subpaymentmode Accountcode *********************'''
            If Me.cbo_SubPaymentMode.Visible = True Then
                SubpaymentMode = Split(Trim(Me.cbo_SubPaymentMode.Text), "-")
                sqlstring = "SELECT Accountin FROM subpaymentmode WHERE Subpaymentcode ='" & Trim(SubpaymentMode(0)) & "' AND ISNULL(Freeze,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "subpaymentmode")
                If gdataset.Tables("subpaymentmode").Rows.Count > 0 Then
                    Subpaymentaccountcode = Trim(gdataset.Tables("subpaymentmode").Rows(0).Item("Accountin") & "")
                End If
            Else
                ReDim Preserve SubpaymentMode(1)
                SubpaymentMode(0) = ""
                Subpaymentaccountcode = ""
            End If
            sqlstring = "SELECT Accountin FROM Paymentmodemaster WHERE Paymentcode ='" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(Freeze,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "Paymentmodemaster")
            If gdataset.Tables("Paymentmodemaster").Rows.Count > 0 Then
                paymentaccountcode = Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin") & "")
            Else
                MessageBox.Show("Assign a AccountCode For Specified PAYMENTMODE", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                paymentaccountcode = ""
                Exit Sub
            End If
            '''*********************************************************** COMPLETE ************************************************************'''
            '''********************************************************** UPDATE KOT_HDR *********************************************************'''
            If PAY = "ROOM CHECKIN" Then
                sqlstring = "SELECT ISNULL(CHECKOUT,'N') AS CHECKOUT,ISNULL(ROOMNO,0)AS ROOMNO FROM Roomcheckin WHERE docno = " & Val(txt_MemberCode.Tag) & ""
                gconnection.getDataSet(sqlstring, "Roomcheckin")
                If gdataset.Tables("Roomcheckin").Rows.Count > 0 Then
                    'If Trim(CStr(gdataset.Tables("Roomcheckin").Rows(0).Item("CHECKOUT"))) = "Y" Then
                    '    MessageBox.Show("Bill Can't be updated " & vbCrLf & " as GUEST  had been checkout from RoomNo" & ": " & gdataset.Tables("ROOMLEDGER").Rows(0).Item("ROOMNO"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    '    Call Cmd_Clear_Click(Cmd_Clear, e)
                    '    Cmd_Add.Enabled = True
                    '    Exit Sub
                    'End If
                End If
                sqlstring = "UPDATE KOT_HDR SET Kotdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy HH:mm:ss") & "',TableNo='" & Trim(txt_TableNo.Text) & "',Covers=" & Val(txt_Cover.Text) & ",DocType='" & DOCTYPE & "',SaleType='" & SALETYPE & "',AccountCode='" & accountcode & "',"
                sqlstring = sqlstring & " Slcode = '',Mcode= '',Mname= '',RoomNo='" & Trim(txt_MemberCode.Text) & "',Guest='" & Trim(txt_MemberName.Text) & "',checkin='" & Trim(txt_MemberCode.Tag) & "',STCode='" & Trim(txt_ServerCode.Text) & "',ServerCode='" & Trim(txt_ServerCode.Text) & "',ServerName='" & Trim(txt_ServerName.Text) & "',"
                sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',Total =" & Val(0) & ",TotalTax =" & Val(0) & ",packamt =" & Val(0) & ",packingpercent =" & Val(PACKINGPERCENT) & ",BillAmount =" & Val(0) & ",Remarks = '" & Trim(Txt_Remarks.Text) & "',reason = '" & Trim(0) & "',"
                sqlstring = sqlstring & " SubPaymentMode='" & SubpaymentMode(0) & "',Roundoff=" & Math.Round(Val(0)) & ",upduserid='" & Trim(gUsername) & "',upddatetime='" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "',Paymodeaccountcode = '" & Trim(paymentaccountcode) & " ',subpaymentaccountcode = '" & Trim(Subpaymentaccountcode) & "',servicelocation = '" & Trim(txt_LOCATIONCODE.Text) & "',TTYPE='ROOMGUEST'"
                sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(txt_KOTno.Text)) & "' "
            ElseIf PAY = "R.MEMBER" Then
                sqlstring = "UPDATE KOT_HDR SET Kotdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy HH:mm:ss") & "',TableNo='" & Trim(txt_TableNo.Text) & "',Covers=" & Val(txt_Cover.Text) & ",DocType='" & DOCTYPE & "',SaleType='" & SALETYPE & "',AccountCode='" & accountcode & "',"
                sqlstring = sqlstring & " Slcode = '" & Trim(txt_MemberCode.Text) & "',Mcode= '" & Trim(txt_MemberCode.Text) & "',Mname= '" & Trim(txt_MemberName.Text) & "',RoomNo='',Guest='',checkin='',STCode='" & Trim(txt_ServerCode.Text) & "',ServerCode='" & Trim(txt_ServerCode.Text) & "',ServerName='" & Trim(txt_ServerName.Text) & "',"
                sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',Total =" & Val(0) & ",TotalTax =" & Val(0) & ",packingpercent =" & Val(PACKINGPERCENT) & ",PackAmt =" & Val(0) & ",BillAmount =" & Val(0) & ",Remarks = '" & Trim(Txt_Remarks.Text) & "',reason = '',"
                sqlstring = sqlstring & " SubPaymentMode='" & SubpaymentMode(0) & "',Roundoff=" & Math.Round(Val(0)) & ",upduserid='" & Trim(gUsername) & "',upddatetime='" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "',Paymodeaccountcode = '" & Trim(paymentaccountcode) & " ',subpaymentaccountcode = '" & Trim(Subpaymentaccountcode) & "', servicelocation = '" & Trim(txt_LOCATIONCODE.Text) & "',TTYPE='AFFMEMBER'"
                sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(txt_KOTno.Text)) & "' "
            ElseIf PAY = "MEMBER ACCOUNT" Then
                sqlstring = "UPDATE KOT_HDR SET Kotdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy HH:mm:ss") & "',TableNo='" & Trim(txt_TableNo.Text) & "',Covers=" & Val(txt_Cover.Text) & ",DocType='" & DOCTYPE & "',SaleType='" & SALETYPE & "',AccountCode='" & accountcode & "',"
                sqlstring = sqlstring & " Slcode = '" & Trim(txt_MemberCode.Text) & "',Mcode= '" & Trim(txt_MemberCode.Text) & "',Mname= '" & Trim(txt_MemberName.Text) & "',RoomNo='',Guest='',checkin='',STCode='" & Trim(txt_ServerCode.Text) & "',ServerCode='" & Trim(txt_ServerCode.Text) & "',ServerName='" & Trim(txt_ServerName.Text) & "',"
                sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',Total =" & Val(0) & ",TotalTax =" & Val(0) & ",BillAmount =" & Val(0) & ",packingpercent =" & Val(PACKINGPERCENT) & ",PackAmt =" & Val(0) & ",Remarks = '" & Trim(Txt_Remarks.Text) & "',reason = '',"
                sqlstring = sqlstring & " SubPaymentMode='" & SubpaymentMode(0) & "',Roundoff=" & Math.Round(Val(0)) & ",upduserid='" & Trim(gUsername) & "',upddatetime='" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "',Paymodeaccountcode = '" & gDebtors & "',subpaymentaccountcode = '" & Trim(txt_MemberCode.Text) & "',servicelocation = '" & Trim(txt_LOCATIONCODE.Text) & "',TTYPE='CLUBMEMBER' "
                sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(txt_KOTno.Text)) & "' "
            Else
                sqlstring = "UPDATE KOT_HDR SET Kotdate='" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy HH:mm:ss") & "',TableNo='" & Trim(txt_TableNo.Text) & "',Covers=" & Val(txt_Cover.Text) & ",DocType='" & DOCTYPE & "',SaleType='" & SALETYPE & "',AccountCode='" & accountcode & "',"
                sqlstring = sqlstring & " SLCode='" & Trim(txt_MemberCode.Text) & "',MCode='" & Trim(txt_MemberCode.Text) & "',Mname='" & Trim(txt_MemberName.Text) & "',STCode='" & Trim(txt_ServerCode.Text) & "',ServerCode='" & Trim(txt_ServerCode.Text) & "',ServerName='" & Trim(txt_ServerName.Text) & "',"
                sqlstring = sqlstring & " PaymentType='" & Trim(cbo_PaymentMode.Text) & "',ServiceType ='SALE',Postingtype ='AUTO',Total =" & Val(0) & ",TotalTax =" & Val(0) & ",packingpercent =" & Val(PACKINGPERCENT) & ",Packamt =" & Val(0) & ",BillAmount =" & Val(0) & ",Remarks = '" & Trim(Txt_Remarks.Text) & "',reason = '',"
                sqlstring = sqlstring & " SubPaymentMode='" & SubpaymentMode(0) & "',Roundoff=" & Math.Round(Val(0)) & ",upduserid='" & Trim(gUsername) & "',upddatetime='" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "',Paymodeaccountcode = '" & Trim(paymentaccountcode) & " ',subpaymentaccountcode = '" & Trim(Subpaymentaccountcode) & "', servicelocation = '" & Trim(txt_LOCATIONCODE.Text) & "',TTYPE='" & ordertype & "'"
                sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(txt_KOTno.Text)) & "' "
            End If
            Insert(0) = sqlstring
            If Me.Lbl_Bill.Visible = True And Me.Lbl_Bill.Text = "B I L L  G E N E R A T E D" Then
                '''******************************************* $ CHECK IF THAT MEMBER HAV THE FACILITY OF USING CARD OR NOT      $ *********************'''
                'If Trim(PAY) = "SMART CARD" Then
                '    sqlstring = "SELECT * FROM SMARTCARDDETAILS WHERE MCODE ='" & Trim(CStr(txt_MemberCode.Text)) & "' "
                '    gconnection.getDataSet(sqlstring, "SMARTCARDDETAILS")
                '    If gdataset.Tables("SMARTCARDDETAILS").Rows.Count > 0 Then
                '        smartcardbool = True
                '    Else
                '        MessageBox.Show("Sorry this member don't hav card facility", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '        txt_MemberCode.Focus()
                '        smartcardbool = False
                '        Exit Sub
                '    End If
                'End If
                '''******************************************* $ CHECK COMPLETED  $ ********************************************************************'''
                VARSQL = " SELECT Autoid AS Autoid,Kotdetails AS Kotdetails,Kotdate AS Kotdate,ISNULL(Billdetails,'') AS Billdetails,Taxcode,Itemcode FROM KOT_DET WHERE KOTDETAILS  = '" & Trim(txt_KOTno.Text) & "'"
                gconnection.getDataSet(VARSQL, "TEMPKOTDET")
                If gdataset.Tables("TEMPKOTDET").Rows.Count > 0 Then
                    For Z = 0 To gdataset.Tables("TEMPKOTDET").Rows.Count - 1
                        For i = 1 To sSGrid.DataRowCnt
                            sSGrid.Row = i
                            sSGrid.Col = 16
                            If Val(sSGrid.Text) = Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("Autoid")) Then
                                '''******************************************************** UPDATE INTO KOT_DET ******************************************************'''
                                sqlstring = "UPDATE KOT_DET SET KotDate = '" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy HH:mm:ss") & "',KotType = 'SALE',PaymentMode= '" & Trim(cbo_PaymentMode.Text) & "' ,"
                                sqlstring = sqlstring & " Mcode = '" & Trim(txt_MemberCode.Text) & "',Scode = '" & Trim(txt_ServerCode.Text) & "',Covers = " & Val(Me.txt_Cover.Text) & ",TableNo = '" & Trim(Me.txt_TableNo.Text) & "',"
                                sqlstring = sqlstring & " TotAmt= " & Val(0) & ",TaxAmt= " & Val(0) & ",BillAmt= " & Val(0) & ",ChkId= " & Val(Me.txt_MemberCode.Tag) & " "
                                sSGrid.Row = i
                                sSGrid.Col = 1
                                sqlstring = sqlstring & ",ItemCode='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 2
                                sqlstring = sqlstring & ",Itemdesc='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 3
                                sqlstring = sqlstring & ",Poscode='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 4
                                sqlstring = sqlstring & ",Uom= '" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 5
                                sqlstring = sqlstring & ",Qty= " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 6
                                sqlstring = sqlstring & ",Rate= " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 7
                                sqlstring = sqlstring & ",Taxamount= " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 8
                                sqlstring = sqlstring & ",Amount = " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 9
                                sqlstring = sqlstring & ",ItemType ='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 10
                                sqlstring = sqlstring & ",TaxCode='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 11
                                sqlstring = sqlstring & ",TaxPerc =" & Val(sSGrid.Text) & " "
                                sSGrid.Col = 13
                                sqlstring = sqlstring & ",TaxAccountCode = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 14
                                sqlstring = sqlstring & ",SalesAccountCode = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 15
                                sqlstring = sqlstring & ",GroupCode = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 16
                                sqlstring = sqlstring & ",SUBGroupCode = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 18
                                sqlstring = sqlstring & ",PROMOTIONALST = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 9
                                If Trim(sSGrid.Text) = "BAR" Then
                                    sqlstring = sqlstring & ",Taxtype = '',Alcholst = 'Y'"
                                ElseIf Trim(sSGrid.Text) = "SD" Then
                                    sqlstring = sqlstring & ",Taxtype = 'SALES',Alcholst ='S'"
                                Else
                                    sqlstring = sqlstring & ",Taxtype = 'SALES',Alcholst ='N'"
                                End If
                                sqlstring = sqlstring & ",Upduserid = '" & Trim(gUsername) & "',Upddatetime = '" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "',TTYPE='" & ordertype & "',"
                                sSGrid.Col = 12
                                If Trim(sSGrid.Text) = "Yes" Then
                                    sqlstring = sqlstring & "KOTStatus='Y',DELFLAG = 'N'"
                                Else
                                    sqlstring = sqlstring & "KOTStatus='N',DELFLAG = 'N'"
                                End If
                                sqlstring = sqlstring & " WHERE  AUTOID = " & Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("AUTOID")) & ""
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                                Gridbool = True
                                Exit For
                            Else
                                Gridbool = False
                            End If
                        Next i
                        If Gridbool = False Then
                            sqlstring = "DELETE FROM KOT_DET WHERE autoid= " & Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("Autoid")) & " "
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        End If
                        '''******************************************************** COMPLETE KOT_DET *********************************************************'''
                    Next Z
                End If
                Dim dt As DataTable
                'Call BillingUpdation() '''--->Billing Updation
                '''****************************************** $ FOR NON TAXABLE ITEMS $ *************************************
                dt = gconnection.GetValues("SELECT Billdetails,Kotamount FROM Bill_Det WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "' AND Isnull(Taxamount,0)=0")
                If dt.Rows.Count > 0 Then
                    sqlstring = "UPDATE Bill_Det SET KotAmount=" & Val(BillNontotalamount) & " ,TaxAmount= " & Val(BillNontaxamount) & " Where KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "' AND Isnull(Taxamount,0)=0"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "UPDATE Bill_Hdr SET BillAmount= Billamount - " & Val(dt.Rows(0).Item("kotamount")) & " Where BillDetails='" & Trim(dt.Rows(0).Item("BillDetails")) & "' AND Isnull(Taxamount,0)=0"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "UPDATE Bill_Hdr SET BillAmount= Billamount + " & Val(BillNontotalamount) & " ,TaxAmount= TaxAmount +  " & Val(BillNontaxamount) & " WHERE BillDetails='" & Trim(dt.Rows(0).Item("BillDetails")) & "' AND Isnull(Taxamount,0)=0"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    '''************************************************** $ IF PAYMENTMODE IS "CARD"  $ ********************************************'''
                    If CStr(PAY) = "SMART CARD" Then
                        If smartcardbool = True Then
                            sqlstring = "SELECT Minimumusage,CardAmount FROM Bill_Hdr WHERE BILLDETAILS ='" & Trim(dt.Rows(0).Item("BillDetails")) & "' "
                            gconnection.getDataSet(sqlstring, "CardBill_Hdr")
                            If gdataset.Tables("CardBill_Hdr").Rows.Count > 0 Then
                                If Val(gdataset.Tables("CardBill_Hdr").Rows(0).Item("Minimumusage")) > 0 Then
                                    sqlstring = "UPDATE MEMBERMASTER SET CardAmt = CardAmt - " & Format(Val(CardAmount), "0.00") & " WHERE MCODE = '" & Trim(CStr(txt_MemberCode.Text)) & "'"
                                    ReDim Preserve Insert(Insert.Length)
                                    Insert(Insert.Length - 1) = sqlstring
                                ElseIf Val(gdataset.Tables("CardBill_Hdr").Rows(0).Item("Minimumusage")) = 0 Then

                                ElseIf Val(gdataset.Tables("CardBill_Hdr").Rows(0).Item("CardAmount")) > 0 Then

                                End If
                            Else
                                MessageBox.Show("!!! Warning !!! Recharge your CARD before using ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                '                                cbo_PaymentMode.Focus()
                                'txt_TableNo.Focus()
                                cbo_PaymentMode.Focus()
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("!!! Sorry !!! Transaction can't be proceed ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If
                    '''************************************************** $ IF TAX ITEM IS INSERTED  $ ********************************************'''
                End If
                '''****************************************************** $ FOR TAXABLE ITEMS $  **********************************************
                dt = gconnection.GetValues("SELECT Billdetails,Kotamount,TaxAmount FROM Bill_Det WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "' AND Isnull(Taxamount,0)> 0")
                If dt.Rows.Count > 0 Then
                    sqlstring = "UPDATE Bill_Det SET KotAmount=" & Val(Billtotalamount) & ",TaxAmount= " & Val(Billtaxamount) & " WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "' AND Isnull(Taxamount,0) > 0"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "UPDATE Bill_Hdr SET BillAmount= BillAmount - " & Val(dt.Rows(0).Item("kotamount")) & ", TaxAmount = TaxAmount - " & Val(dt.Rows(0).Item("TaxAmount")) & " WHERE BillDetails='" & Trim(dt.Rows(0).Item("BillDEtails")) & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    sqlstring = "UPDATE Bill_Hdr SET BillAmount= BillAmount + " & Val(Billtotalamount) & ",TaxAmount= TaxAmount + " & Val(Billtaxamount) & " WHERE BillDetails='" & Trim(dt.Rows(0).Item("BillDetails")) & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    '''************************************************** $ IF PAYMENTMODE IS "CARD"  $ ********************************************'''
                    If CStr(PAY) = "SMART CARD" Then
                        If smartcardbool = True Then
                            sqlstring = "SELECT Minimumusage,CardAmount FROM Bill_Hdr WHERE BILLDETAILS ='" & Trim(dt.Rows(0).Item("BillDetails")) & "' "
                            gconnection.getDataSet(sqlstring, "Bill_Hdr")
                            If gdataset.Tables("Bill_Hdr").Rows.Count > 0 Then

                            Else
                                MessageBox.Show("!!! Warning !!! Recharge your CARD before using ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                cbo_PaymentMode.Focus()
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("!!! Sorry !!! Transaction can't be proceed ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf Me.Lbl_Bill.Visible = True And Me.Lbl_Bill.Text = "C R O  G E N E R A T E D" Then
                MessageBox.Show("As CRO is generated so KOT Can't be modified", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Call Cmd_Clear_Click(Cmd_Clear, e)
                Exit Sub
            Else
                'REFERINVENTORY
                'VARSQL = " SELECT Autoid AS Autoid,Kotdetails AS Kotdetails,Kotdate AS Kotdate,ISNULL(Billdetails,'') AS Billdetails,Taxcode,Itemcode FROM KOT_DET WHERE KOTDETAILS  = '" & Trim(txt_KOTno.Text) & "'"
                VARSQL = " SELECT Autoid AS Autoid,Kotdetails AS Kotdetails,Kotdate AS Kotdate,ISNULL(Billdetails,'') AS Billdetails,Taxcode,Itemcode,isnull(qty,0) qty FROM KOT_DET WHERE KOTDETAILS  = '" & Trim(txt_KOTno.Text) & "'"
                gconnection.getDataSet(VARSQL, "TEMPKOTDET")
                If gdataset.Tables("TEMPKOTDET").Rows.Count > 0 Then
                    For Z = 0 To gdataset.Tables("TEMPKOTDET").Rows.Count - 1
                        For i = 1 To sSGrid.DataRowCnt
                            sSGrid.Row = i
                            sSGrid.Col = 17
                            If Val(sSGrid.Text) = Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("Autoid")) Then
                                '''******************************************************** UPDATE INTO KOT_DET ******************************************************'''
                                sqlstring = "UPDATE KOT_DET SET KotDate = '" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy HH:mm:ss") & "',KotType = 'SALE',PaymentMode= '" & Trim(cbo_PaymentMode.Text) & "' ,"
                                sqlstring = sqlstring & " Mcode = '" & Trim(txt_MemberCode.Text) & "',Scode = '" & Trim(txt_ServerCode.Text) & "',Covers = " & Val(Me.txt_Cover.Text) & ",TableNo = '" & Trim(Me.txt_TableNo.Text) & "',"
                                sqlstring = sqlstring & " TotAmt= " & Val(0) & ",TaxAmt= " & Val(0) & ",BillAmt= " & Val(0) & ",ChkId= " & Val(Me.txt_MemberCode.Tag) & " "
                                sSGrid.Row = i
                                sSGrid.Col = 1
                                sqlstring = sqlstring & ",ItemCode='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 2
                                sqlstring = sqlstring & ",Itemdesc='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 3
                                sqlstring = sqlstring & ",Poscode='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 4
                                sqlstring = sqlstring & ",Uom= '" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 5
                                sqlstring = sqlstring & ",Qty= " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 6
                                sqlstring = sqlstring & ",Rate= " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 7
                                sqlstring = sqlstring & ",Taxamount= " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 8
                                sqlstring = sqlstring & ",Amount = " & Val(sSGrid.Text) & ""
                                sSGrid.Col = 9
                                sqlstring = sqlstring & ",ItemType ='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 10
                                sqlstring = sqlstring & ",TaxCode='" & Trim(sSGrid.Text) & "'"
                                sSGrid.Col = 11
                                sqlstring = sqlstring & ",TaxPerc =" & Val(sSGrid.Text) & " "
                                sSGrid.Col = 13
                                sqlstring = sqlstring & ",TaxAccountCode = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 14
                                sqlstring = sqlstring & ",SalesAccountCode = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 15
                                sqlstring = sqlstring & ",GroupCode = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 16
                                sqlstring = sqlstring & ",SUBGroupCode = '" & Trim(sSGrid.Text) & "' "
                                sSGrid.Col = 18
                                sqlstring = sqlstring & ",PROMOTIONALST = '" & Trim(sSGrid.Text) & "' "

                                sSGrid.Col = 9
                                If Trim(sSGrid.Text) = "BAR" Then
                                    sqlstring = sqlstring & ",Taxtype = '',Alcholst = 'Y'"
                                ElseIf Trim(sSGrid.Text) = "SD" Then
                                    sqlstring = sqlstring & ",Taxtype = 'SALES',Alcholst ='S'"
                                Else
                                    sqlstring = sqlstring & ",Taxtype = 'SALES',Alcholst ='N'"
                                End If
                                sqlstring = sqlstring & ",Upduserid = '" & Trim(gUsername) & "',Upddatetime = '" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "',"
                                sSGrid.Col = 12
                                If Trim(sSGrid.Text) = "Yes" Then
                                    sqlstring = sqlstring & "KOTStatus='Y',DELFLAG = 'N'"
                                Else
                                    sqlstring = sqlstring & "KOTStatus='N',DELFLAG = 'N'"
                                End If
                                sqlstring = sqlstring & " WHERE  AUTOID = " & Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("AUTOID")) & ""
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                                'REFERINVENTORY******************************* CHANGING THE QUANTITY OF ITEM *****************
                                sSGrid.Row = i
                                sSGrid.Col = 3
                                POSLOCATION = Trim(sSGrid.Text)

                                Dim SUBSTORECODE As String
                                sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & Trim(POSLOCATION) & "' AND ISNULL(FREEZE,'') <> 'Y'"
                                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                                    sSGrid.Row = i
                                    sSGrid.Col = 1
                                    POSITEMCODE = Trim(sSGrid.Text)

                                    sSGrid.Row = i
                                    sSGrid.Col = 4
                                    POSITEMUOM = Trim(sSGrid.Text)

                                    sqlstring = "SELECT GITEMCODE,GITEMNAME,GUOM,GQTY,GRATE,GAMOUNT,GDBLAMT,GHIGHRATIO,GGROUPCODE,GSUBGROUPCODE,VOID FROM BOM_DET WHERE"
                                    sqlstring = sqlstring & " ITEMCODE='" & POSITEMCODE & "' AND ITEMUOM='" & POSITEMUOM & "' AND ISNULL(VOID,'') <> 'Y'"
                                    gconnection.getDataSet(sqlstring, "BOM")
                                    If gdataset.Tables("BOM").Rows.Count > 0 Then
                                        For K = 0 To gdataset.Tables("BOM").Rows.Count - 1


                                            sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(POSLOCATION) & "' AND ITEMCODE='" & gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "'"
                                            gconnection.getDataSet(sqlstring, "SUBSTORE")
                                            If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                                SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                                            Else
                                                SUBSTORECODE = POSLOCATION
                                            End If

                                            sqlstring = "UPDATE SUBSTORECONSUMPTIONDETAIL SET DOCDate = '" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "'"
                                            sSGrid.Row = i
                                            sSGrid.Col = 3
                                            sqlstring = sqlstring & ",STORELOCATIONcode='" & SUBSTORECODE & "'"
                                            sqlstring = sqlstring & ",STORELOCATIONNAME='" & STORELOCATION(Trim(SUBSTORECODE)) & "'"
                                            sqlstring = sqlstring & ",ItemCode='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "'"
                                            sqlstring = sqlstring & ",ItemNAME='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMNAME") & "") & "'"
                                            sqlstring = sqlstring & ",Uom= '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GUOM") & "") & "'"
                                            sSGrid.Col = 5
                                            sqlstring = sqlstring & ",Qty= " & (Val(sSGrid.Text) * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY"))) & ""
                                            AVGRATE = CalAverageRate(Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & ""))
                                            'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                                            sqlstring = sqlstring & ",RATE= " & AVGRATE & ""
                                            sSGrid.Col = 5
                                            sSGrid.Row = i
                                            dblCalqty = Val(sSGrid.Text)
                                            sqlstring = sqlstring & ",AMOUNT= " & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) * AVGRATE & ""
                                            'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                                            sqlstring = sqlstring & ",DBLAmt = " & (Val(sSGrid.Text) * CDbl(gdataset.Tables("BOM").Rows(K).Item("GDBLAMT"))) & ""
                                            sqlstring = sqlstring & ",HIGHRATIO = " & Val(gdataset.Tables("BOM").Rows(K).Item("GHIGHRATIO")) & ""
                                            sqlstring = sqlstring & ",GROUPCODE= '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GGROUPCODE") & "") & "'"
                                            sqlstring = sqlstring & ",SUBGROUPCODE= '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GSUBGROUPCODE") & "") & "'"
                                            sSGrid.Col = 12
                                            If Trim(sSGrid.Text) = "1" Then
                                                sqlstring = sqlstring & ",VOID='Y'"
                                            Else
                                                sqlstring = sqlstring & ",VOID='N'"
                                            End If
                                            sqlstring = sqlstring & ",UpdATEuser = '" & Trim(gUsername) & "',Updatetime = '" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "' "
                                            sqlstring = sqlstring & " WHERE DOCDETAILS='" & Trim(txt_KOTno.Text) & "' AND STORELOCATIONCODE='" & Trim(SUBSTORECODE) & "' "
                                            sqlstring = sqlstring & " AND ITEMCODE='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "'"
                                            sqlstring = sqlstring & " AND UOM='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GUOM") & "") & "'"
                                            sSGrid.Row = i
                                            'REFERCSC
                                            'sSGrid.Col = 22
                                            sSGrid.Col = 18

                                            ReDim Preserve Insert(Insert.Length)
                                            Insert(Insert.Length - 1) = sqlstring
                                        Next K
                                    Else
                                        sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0.00) AS PURCHASERATE,"
                                        sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                                        sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE"
                                        sqlstring = sqlstring & " WHERE I.ITEMCODE='" & POSITEMCODE & "' AND I.STOCKUOM='" & POSITEMUOM & "' AND ISNULL(FREEZE,'') <> 'Y' AND STORECODE='" & SUBSTORECODE & "'"
                                        gconnection.getDataSet(sqlstring, "DIRECT_STOCK")
                                        If gdataset.Tables("DIRECT_STOCK").Rows.Count > 0 Then

                                            sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(POSLOCATION) & "' AND ITEMCODE='" & gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & "'"
                                            gconnection.getDataSet(sqlstring, "SUBSTORE")
                                            If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                                SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                                            Else
                                                SUBSTORECODE = POSLOCATION
                                            End If

                                            sqlstring = "UPDATE SUBSTORECONSUMPTIONDETAIL SET DOCDate = '" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "'"
                                            sSGrid.Row = i
                                            sSGrid.Col = 3
                                            sqlstring = sqlstring & ",STORELOCATIONcode='" & Trim(SUBSTORECODE) & "'"
                                            sqlstring = sqlstring & ",STORELOCATIONNAME='" & STORELOCATION(Trim(SUBSTORECODE)) & "'"
                                            sqlstring = sqlstring & ",ItemCode='" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & "") & "'"
                                            sqlstring = sqlstring & ",ItemNAME='" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMNAME") & "") & "'"
                                            sqlstring = sqlstring & ",Uom= '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("STOCKUOM") & "") & "'"
                                            sSGrid.Col = 5
                                            sqlstring = sqlstring & ",Qty= " & Val(sSGrid.Text) & ""
                                            AVGRATE = CalAverageRate(Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & ""))
                                            'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                                            sqlstring = sqlstring & ",RATE= " & AVGRATE & ""
                                            sSGrid.Col = 5
                                            sSGrid.Row = i
                                            dblCalqty = Val(sSGrid.Text)
                                            sqlstring = sqlstring & ",AMOUNT= " & dblCalqty * AVGRATE & ""
                                            'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                                            sqlstring = sqlstring & ",DBLAmt = " & (Val(sSGrid.Text) * CDbl(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO"))) & ""
                                            sqlstring = sqlstring & ",HIGHRATIO = " & Val(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ""
                                            sqlstring = sqlstring & ",GROUPCODE= '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("GROUPCODE") & "") & "'"
                                            sqlstring = sqlstring & ",SUBGROUPCODE= '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("SUBGROUPCODE") & "") & "'"
                                            sSGrid.Col = 12
                                            If Trim(sSGrid.Text) = "1" Then
                                                sqlstring = sqlstring & ",VOID='Y'"
                                            Else
                                                sqlstring = sqlstring & ",VOID='N'"
                                            End If
                                            sqlstring = sqlstring & ",UpdATEuser = '" & Trim(gUsername) & "',Updatetime = '" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "' "
                                            sqlstring = sqlstring & " WHERE DOCDETAILS='" & Trim(txt_KOTno.Text) & "' AND STORELOCATIONCODE='" & Trim(SUBSTORECODE) & "' "
                                            sqlstring = sqlstring & " AND ITEMCODE='" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & "") & "'"
                                            sqlstring = sqlstring & " AND UOM='" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("STOCKUOM") & "") & "'"
                                            sSGrid.Row = i
                                            'REFERCSC
                                            sSGrid.Col = 18
                                            '  sqlstring = sqlstring & " AND QTY=" & Val(sSGrid.Text)

                                            ReDim Preserve Insert(Insert.Length)
                                            Insert(Insert.Length - 1) = sqlstring
                                        End If
                                    End If
                                End If
                                '*********************************************************************************************

                                Gridbool = True
                                Exit For
                            Else
                                Gridbool = False
                            End If
                        Next i
                        If Gridbool = False Then

                            Dim SUBSTORECODE As String
                            'REFERINVENTORY******************UPDATING STOCK FOR DELETION*****************************
                            Dim KOTDETAILS_DEL, ITEMCODE_DEL, UOM_DEL, POSCODE_DEL As String
                            sqlstring = "SELECT KOTDETAILS,ITEMCODE,UOM,POSCODE FROM KOT_DET WHERE AUTOID=" & Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("AUTOID")) & " "
                            gconnection.getDataSet(sqlstring, "KOTDETAILS")
                            If gdataset.Tables("KOTDETAILS").Rows.Count > 0 Then
                                KOTDETAILS_DEL = gdataset.Tables("KOTDETAILS").Rows(0).Item("kotdetails")
                                ITEMCODE_DEL = gdataset.Tables("KOTDETAILS").Rows(0).Item("ITEMCODE")
                                UOM_DEL = gdataset.Tables("KOTDETAILS").Rows(0).Item("UOM")
                                POSCODE_DEL = gdataset.Tables("KOTDETAILS").Rows(0).Item("POSCODE")
                            End If
                            sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & POSCODE_DEL & "' AND ISNULL(FREEZE,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "STOREMASTER1")
                            If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                                sqlstring = "SELECT GITEMCODE,GITEMNAME,GUOM,GQTY,GRATE,GAMOUNT,GDBLAMT,GHIGHRATIO,GGROUPCODE,GSUBGROUPCODE,VOID FROM BOM_DET WHERE"
                                sqlstring = sqlstring & " ITEMCODE='" & ITEMCODE_DEL & "' AND ITEMUOM='" & UOM_DEL & "' AND ISNULL(VOID,'') <> 'Y'"
                                gconnection.getDataSet(sqlstring, "BOM")
                                If gdataset.Tables("BOM").Rows.Count > 0 Then
                                    For K = 0 To gdataset.Tables("BOM").Rows.Count - 1

                                        sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(POSLOCATION) & "' AND ITEMCODE='" & gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "'"
                                        gconnection.getDataSet(sqlstring, "SUBSTORE")
                                        If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                            SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                                        Else
                                            SUBSTORECODE = POSLOCATION
                                        End If

                                        sqlstring = "DELETE FROM SUBSTORECONSUMPTIONDETAIL WHERE "
                                        sqlstring = sqlstring & " DOCDETAILS='" & KOTDETAILS_DEL & "'"
                                        sqlstring = sqlstring & " AND ITEMCODE='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "'"
                                        sqlstring = sqlstring & " AND UOM='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GUOM") & "") & "'"
                                        sqlstring = sqlstring & " AND STORELOCATIONCODE='" & SUBSTORECODE & "'"
                                        '  sqlstring = sqlstring & " AND QTY=" & (CDbl(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("QTY")) * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")))
                                        ReDim Preserve Insert(Insert.Length)
                                        Insert(Insert.Length - 1) = sqlstring
                                    Next K
                                Else
                                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0.00) AS PURCHASERATE,"
                                    sqlstring = sqlstring & " ISNULL(I.STOCKUOM,'') AS CONVUOM,1 AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                                    sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I "
                                    sqlstring = sqlstring & " WHERE I.ITEMCODE='" & ITEMCODE_DEL & "' AND I.STOCKUOM='" & UOM_DEL & "' AND ISNULL(FREEZE,'') <> 'Y' AND STORECODE='" & SUBSTORECODE & "'"
                                    gconnection.getDataSet(sqlstring, "DIRECT_STOCK")
                                    If gdataset.Tables("DIRECT_STOCK").Rows.Count > 0 Then

                                        sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(POSLOCATION) & "' AND ITEMCODE='" & ITEMCODE_DEL & "'"
                                        gconnection.getDataSet(sqlstring, "SUBSTORE")
                                        If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                            SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                                        Else
                                            SUBSTORECODE = POSLOCATION
                                        End If

                                        sqlstring = "DELETE FROM SUBSTORECONSUMPTIONDETAIL WHERE "
                                        sqlstring = sqlstring & " DOCDETAILS='" & KOTDETAILS_DEL & "'"
                                        sqlstring = sqlstring & " AND ITEMCODE='" & ITEMCODE_DEL & "'"
                                        sqlstring = sqlstring & " AND UOM='" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("STOCKUOM") & "") & "'"
                                        sqlstring = sqlstring & " AND STORELOCATIONCODE='" & SUBSTORECODE & "'"
                                        'sqlstring = sqlstring & " AND QTY=" & CDbl(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("QTY"))
                                        ReDim Preserve Insert(Insert.Length)
                                        Insert(Insert.Length - 1) = sqlstring
                                    End If
                                End If
                            End If
                            '****************************************************************************************

                            sqlstring = "DELETE FROM KOT_DET WHERE autoid= " & Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("Autoid")) & " "
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        End If
                        '''******************************************************** COMPLETE KOT_DET *********************************************************'''
                    Next Z
                End If
                For i = 1 To sSGrid.DataRowCnt
                    sSGrid.Row = i
                    sSGrid.Col = 17
                    If Val(sSGrid.Text) = 0 Then
                        sqlstring = "INSERT INTO KOT_DET(KotNo,KOTdetails,KotDate,KotType,PaymentMode,Mcode,Scode,Covers,TableNo,TotAmt,TaxAmt,BillAmt,ChkId,ItemCode,Itemdesc,Poscode,Uom,Qty,Rate,Taxamount,Amount,ItemType,TaxCode,TaxPerc,TaxAccountCode,SalesAccountCode,GroupCode,SUBGroupCode,"
                        sqlstring = sqlstring & "Taxtype,Alcholst,Adduserid,Adddatetime,Upduserid,Upddatetime,PROMOTIONALST,KOTStatus,delflag) "
                        sqlstring = sqlstring & "VALUES('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "','" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy HH:mm:ss") & "','SALE','" & Trim(cbo_PaymentMode.Text) & "',"
                        sqlstring = sqlstring & "'" & Trim(txt_MemberCode.Text) & "','" & Trim(txt_ServerCode.Text) & "'," & Val(Me.txt_Cover.Text) & ",'" & Trim(Me.txt_TableNo.Text) & "'," & Val(0) & "," & Val(0) & "," & Val(0) & "," & Val(Me.txt_MemberCode.Tag) & ""
                        sSGrid.Row = i
                        sSGrid.Col = 1
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 2
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 3
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 4
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 5
                        sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                        sSGrid.Col = 6
                        sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                        sSGrid.Col = 7
                        sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                        sSGrid.Col = 8
                        sqlstring = sqlstring & "," & Val(sSGrid.Text) & ""
                        sSGrid.Col = 9
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 10
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "'"
                        sSGrid.Col = 11
                        sqlstring = sqlstring & "," & Val(sSGrid.Text) & " "
                        sSGrid.Col = 13
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                        sSGrid.Col = 14
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                        sSGrid.Col = 15
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                        sSGrid.Col = 16
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "
                        sSGrid.Col = 9

                        If Trim(sSGrid.Text) = "BAR" Then
                            sqlstring = sqlstring & ",'','Y'"
                        ElseIf Trim(sSGrid.Text) = "SD" Then
                            sqlstring = sqlstring & ",'SALES','S'"
                        Else
                            sqlstring = sqlstring & ",'SALES','N'"
                        End If
                        sqlstring = sqlstring & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "'"
                        sSGrid.Col = 18
                        sqlstring = sqlstring & ",'" & Trim(sSGrid.Text) & "' "

                        sSGrid.Col = 12
                        If Trim(sSGrid.Text) = "Yes" Then
                            sqlstring = sqlstring & ",'Y','N')"
                        Else
                            sqlstring = sqlstring & ",'N','N')"
                        End If
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                        ''REFERINVENTORY*************************UPDATING STOCK***********************************************

                        sSGrid.Row = i
                        sSGrid.Col = 3
                        POSLOCATION = Trim(sSGrid.Text)

                        Dim SUBSTORECODE As String
                        sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & Trim(POSLOCATION) & "' AND ISNULL(FREEZE,'') <> 'Y'"
                        gconnection.getDataSet(sqlstring, "STOREMASTER1")
                        If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                            sSGrid.Row = i
                            sSGrid.Col = 1
                            POSITEMCODE = Trim(sSGrid.Text)

                            sSGrid.Row = i
                            sSGrid.Col = 4
                            POSITEMUOM = Trim(sSGrid.Text)
                            sqlstring = "SELECT GITEMCODE,GITEMNAME,GUOM,GQTY,GRATE,GAMOUNT,GDBLAMT,GHIGHRATIO,GGROUPCODE,GSUBGROUPCODE,VOID FROM BOM_DET WHERE"
                            sqlstring = sqlstring & " ITEMCODE='" & POSITEMCODE & "' AND ITEMUOM='" & POSITEMUOM & "' AND ISNULL(VOID,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "BOM")
                            If gdataset.Tables("BOM").Rows.Count > 0 Then
                                For K = 0 To gdataset.Tables("BOM").Rows.Count - 1


                                    sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(POSLOCATION) & "' AND ITEMCODE='" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "'"
                                    gconnection.getDataSet(sqlstring, "SUBSTORE")
                                    If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                        SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                                    Else
                                        SUBSTORECODE = POSLOCATION
                                    End If

                                    sqlstring = "INSERT INTO SUBSTORECONSUMPTIONDETAIL(Docno,Docdetails,Docdate,Storelocationcode,STORELOCATIONNAME,"
                                    sqlstring = sqlstring & " Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                                    sqlstring = sqlstring & " Dblamt,Highratio,Groupcode,Subgroupcode,Void,Adduser,adddatetime,Updateuser,Updatetime)"
                                    sqlstring = sqlstring & " VALUES ('" & Trim(CStr(txt_KOTno.Text)) & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                                    sqlstring = sqlstring & " '" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy") & "',"
                                    sqlstring = sqlstring & " '" & Trim(SUBSTORECODE) & "',"
                                    sqlstring = sqlstring & " '" & Trim(STORELOCATION(Trim(SUBSTORECODE))) & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMNAME") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GUOM") & "") & "',"
                                    sSGrid.Col = 5
                                    sSGrid.Row = i
                                    dblCalqty = Val(sSGrid.Text)
                                    sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) & ","
                                    AVGRATE = CalAverageRate(Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & ""))
                                    'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                                    sqlstring = sqlstring & AVGRATE & ","
                                    sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) * AVGRATE & ","
                                    'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                                    sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GDBLAMT")) & ","
                                    sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GHIGHRATIO")) & ","
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GGROUPCODE") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GSUBGROUPCODE") & "") & "',"
                                    sqlstring = sqlstring & "'N'," '& Format(Val(AVGQUANTITY), "0.000") & "," & Format(Val(AVGRATE), "0.00") & ","
                                    sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "',"
                                    sqlstring = sqlstring & " ' ','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "')"
                                    ReDim Preserve Insert(Insert.Length)
                                    Insert(Insert.Length - 1) = sqlstring
                                Next K
                            Else
                                sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0.00) AS PURCHASERATE,"
                                sqlstring = sqlstring & " ISNULL(I.STOCKUOM,'') AS CONVUOM,1 AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                                sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I "
                                sqlstring = sqlstring & " WHERE I.ITEMCODE='" & POSITEMCODE & "' AND I.STOCKUOM='" & POSITEMUOM & "' AND ISNULL(FREEZE,'') <> 'Y' AND STORECODE='" & SUBSTORECODE & "'"
                                gconnection.getDataSet(sqlstring, "DIRECT_STOCK")
                                If gdataset.Tables("DIRECT_STOCK").Rows.Count > 0 Then

                                    sqlstring = "SELECT STORECODE FROM POSITEMSTORELINK WHERE POS='" & Trim(POSLOCATION) & "' AND ITEMCODE='" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & "") & "'"
                                    gconnection.getDataSet(sqlstring, "SUBSTORE")
                                    If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                        SUBSTORECODE = Trim(gdataset.Tables("SUBSTORE").Rows(0).Item("STORECODE") & "")
                                    Else
                                        SUBSTORECODE = POSLOCATION
                                    End If

                                    sqlstring = "INSERT INTO SUBSTORECONSUMPTIONDETAIL(Docno,Docdetails,Docdate,Storelocationcode,STORELOCATIONNAME,"
                                    sqlstring = sqlstring & " Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                                    sqlstring = sqlstring & " Dblamt,Highratio,Groupcode,Subgroupcode,Void,Adduser,adddatetime,Updateuser,Updatetime)"
                                    'sqlstring = sqlstring & " VALUES ('" & CStr(KOTno(1)) & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                                    sqlstring = sqlstring & " VALUES ('" & CStr(txt_KOTno.Text) & "','" & Trim(CStr(txt_KOTno.Text)) & "',"
                                    sqlstring = sqlstring & " '" & Format(CDate(dtp_KOTdate.Value), "dd-MMM-yyyy") & "',"
                                    sqlstring = sqlstring & " '" & Trim(Trim(SUBSTORECODE)) & "',"
                                    sqlstring = sqlstring & " '" & Trim(STORELOCATION(Trim(SUBSTORECODE))) & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMNAME") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("STOCKUOM") & "") & "',"
                                    sSGrid.Col = 5
                                    sSGrid.Row = i
                                    dblCalqty = Val(sSGrid.Text)
                                    sqlstring = sqlstring & dblCalqty & ","
                                    AVGRATE = CalAverageRate(Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & ""))
                                    'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                                    sqlstring = sqlstring & AVGRATE & ","
                                    sqlstring = sqlstring & dblCalqty * AVGRATE & ","
                                    'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                                    sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ","
                                    sqlstring = sqlstring & Val(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ","
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("GROUPCODE") & "") & "',"
                                    sqlstring = sqlstring & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("SUBGROUPCODE") & "") & "',"
                                    sqlstring = sqlstring & "'N'," '& Format(Val(AVGQUANTITY), "0.000") & "," & Format(Val(AVGRATE), "0.00") & ","
                                    sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "',"
                                    sqlstring = sqlstring & " ' ','" & Format(Now, "dd-MMM-yyyy HH:mm:ss") & "')"
                                    ReDim Preserve Insert(Insert.Length)
                                    Insert(Insert.Length - 1) = sqlstring
                                End If
                            End If
                        End If
                        '******************************************************************************************************
                    Else
                    End If
                Next i
            End If
            sqlstring = "DELETE FROM KOT_DET_TAX WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            For i = 1 To sSGrid.DataRowCnt
                Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                With sSGrid
                    .Col = 1
                    .Row = i
                    ITEMCODE = Trim(.Text)
                    .Col = 6
                    .Row = i
                    GrdRate = .Text
                    .Col = 5
                    .Row = i
                    Qty = Val(.Text)
                    .Col = 3
                    .Row = i
                    Pos = Trim(.Text)
                    .Col = 12
                    .Row = i
                    KStatus = Mid(Trim(.Text), 1, 1)
                    .Col = 9
                    .Row = i
                    ChargeCode = Trim(.Text)
                    sqlstring = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                    gconnection.getDataSet(sqlstring, "CODE_CHECK")
                    If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                        ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                    End If
                    sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                    gconnection.getDataSet(sqlstring, "TAXON")
                    If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                        For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                            IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                            Taxcode = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                            Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                            TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                            StrSql = "INSERT INTO KOT_DET_TAX (KOTDETAILS,KOTDATE,TTYPE,CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,ADD_USER,ADD_DATE,VOID,VOIDUSER) VALUES ( "
                            StrSql = StrSql & "'" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(CMB_BTYPE.Text) & "','" & Trim(ChargeCode) & "','" & Trim(IType) & "','" & Trim(Pos) & "','" & Trim(ITEMCODE) & "','" & Trim(KStatus) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (GrdRate) & "," & (Qty) & "," & (TPercent) & ","

                            If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZero = GZero + Zero
                                StrSql = StrSql & "" & Val(Zero) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroA = GZeroA + ZeroA
                                StrSql = StrSql & "" & Val(ZeroA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GZeroB = GZeroB + ZeroB
                                StrSql = StrSql & "" & Val(ZeroB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOne = GOne + One
                                StrSql = StrSql & "" & Val(One) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneA = GOneA + OneA
                                StrSql = StrSql & "" & Val(OneA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GOneB = GOneB + OneB
                                StrSql = StrSql & "" & Val(OneB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwo = GTwo + Two
                                StrSql = StrSql & "" & Val(Two) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoA = GTwoA + TwoA
                                StrSql = StrSql & "" & Val(TwoA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GTwoB = GTwoB + TwoB
                                StrSql = StrSql & "" & Val(TwoB) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThree = GThree + Three
                                StrSql = StrSql & "" & Val(Three) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeA = GThreeA + ThreeA
                                StrSql = StrSql & "" & Val(ThreeA) * Qty & ","
                            ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                GThreeB = GThreeB + ThreeB
                                StrSql = StrSql & "" & Val(ThreeB) * Qty & ","
                            End If
                            StrSql = StrSql & "'" & Trim(gUsername) & "',getdate(),'N','')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = StrSql
                        Next
                    End If
                End With
            Next
            For i = 1 To sSGrid.DataRowCnt
                Dim aid As Integer
                With sSGrid
                    .Col = 1
                    .Row = i
                    ITEMCODE = Trim(.Text)
                    .Col = 5
                    .Row = i
                    Qty = Val(.Text)
                    .Col = 8
                    .Row = i
                    GAmt = Val(.Text)
                    .Col = 17
                    .Row = i
                    aid = Val(.Text)
                    If gCenterlized = "Y" Then
                        TPackAmt = Val((GAmt * gPackPer) / 100)
                        TTipsAmt = Val((GAmt * gTipsPer) / 100)
                        TAdchgAmt = Val((GAmt * gAdCgsPer) / 100)
                        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                            TPartyAmt = Val((GAmt * gPartyPer) / 100)
                            PartyPer = gPartyPer
                        Else
                            TPartyAmt = 0
                            PartyPer = 0
                        End If
                        If PAY = "ROOM CHECKIN" Then
                            TRoomAmt = Val((GAmt * gRoomPer) / 100)
                            RoomPer = gRoomPer
                        Else
                            RoomPer = 0
                            TRoomAmt = 0
                        End If
                    Else
                        TPackAmt = Val((GAmt * pPackPer) / 100)
                        TTipsAmt = Val((GAmt * pTipsPer) / 100)
                        TAdchgAmt = Val((GAmt * pAdCgsPer) / 100)
                        If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                            TPartyAmt = Val((GAmt * pPartyPer) / 100)
                            PartyPer = pPartyPer
                        Else
                            TPartyAmt = 0
                            PartyPer = 0
                        End If
                        If PAY = "ROOM CHECKIN" Then
                            TRoomAmt = Val((GAmt * pRoomPer) / 100)
                            RoomPer = pRoomPer
                        Else
                            RoomPer = 0
                            TRoomAmt = 0
                        End If
                    End If
                    If gCenterlized = "Y" Then
                        sqlstring = "UPDATE KOT_DET SET PACKPERCENT = " & gPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & gTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & gAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                        sqlstring = sqlstring & " WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "' AND AUTOID = " & aid & ""
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    Else
                        sqlstring = "UPDATE KOT_DET SET PACKPERCENT = " & pPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & pTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & pAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                        sqlstring = sqlstring & " WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "' AND AUTOID = " & aid & ""
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    End If
                End With
            Next
            gconnection.MoreTransold(Insert)

            'sqlstring = " UPDATE KOT_HDR SET PackAmt = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'StrUpdate(0) = sqlstring
            'sqlstring = "UPDATE KOT_HDR SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = " UPDATE KOT_HDR SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE KOT_HDR SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            'sqlstring = "UPDATE KOT_HDR SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_DET SET TAXAMOUNT = (SELECT ISNULL(SUM(KOT_DET_TAX.TAXAMT),0) FROM KOT_DET_TAX WHERE KOT_DET.KOTDETAILS = KOT_DET_TAX.KOTDETAILS AND KOT_DET_TAX.ITEMCODE = KOT_DET.ITEMCODE GROUP BY KOTDETAILS,ITEMCODE)"
            'sqlstring = sqlstring & " WHERE KOT_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_DET SET TAXAMT = (SELECT ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL1")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_DET SET TOTAMT = (SELECT ISNULL(SUM(AMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL2")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            ''sqlstring = "UPDATE KOT_DET SET BILLAMT = (SELECT ISNULL(SUM(AMOUNT),0)+ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'sqlstring = "UPDATE KOT_DET SET BILLAMT = (SELECT ISNULL(SUM(AMOUNT),0)+ISNULL(SUM(TAXAMOUNT),0)+ISNULL(SUM(PACKAMOUNT),0)+ISNULL(SUM(TipsAmt),0)+ISNULL(SUM(AdCgsAmt),0)+ISNULL(SUM(PartyAmt),0)+ISNULL(SUM(RoomAmt),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_HDR SET TotalTax = TAXAMT,Total = TOTAMT,BillAmount = BILLAMT FROM KOT_DET K ,KOT_HDR H WHERE K.KOTDETAILS = H.Kotdetails AND K.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ''gconnection.dataOperation(9, sqlstring, "TOTAL4")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TAXAMOUNT = 0 WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            StrUpdate(0) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET PackAmt = (SELECT ISNULL(SUM(KOT_DET.PACKAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET TipsAmt = (SELECT ISNULL(SUM(KOT_DET.TipsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET AdCgsAmt = (SELECT ISNULL(SUM(KOT_DET.AdCgsAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET PartyAmt = (SELECT ISNULL(SUM(KOT_DET.PartyAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = "UPDATE KOT_HDR SET RoomAmt = (SELECT ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TAXAMOUNT = (SELECT ISNULL(SUM(KOT_DET_TAX.TAXAMT),0) FROM KOT_DET_TAX WHERE KOT_DET.KOTDETAILS = KOT_DET_TAX.KOTDETAILS AND KOT_DET_TAX.ITEMCODE = KOT_DET.ITEMCODE  GROUP BY KOTDETAILS,ITEMCODE)"
            sqlstring = sqlstring & " WHERE KOT_DET.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TAXAMT = (SELECT ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'  AND ISNULL(KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL1")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            sqlstring = "UPDATE KOT_DET SET TOTAMT = (SELECT ISNULL(SUM(AMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' AND ISNULL(KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(9, sqlstring, "TOTAL2")
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_DET SET BILLAMT = (SELECT ISNULL(SUM(AMOUNT),0)+ISNULL(SUM(TAXAMOUNT),0) FROM KOT_DET WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' GROUP BY KOTDETAILS) WHERE KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            sqlstring = " UPDATE KOT_HDR SET BillAmount = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0)+ISNULL(SUM(KOT_DET.TAXAMOUNT),0)+ISNULL(SUM(KOT_DET.PACKAMOUNT),0)+ISNULL(SUM(KOT_DET.TipsAmt),0)+ISNULL(SUM(KOT_DET.AdCgsAmt),0)+ISNULL(SUM(KOT_DET.PartyAmt),0)+ISNULL(SUM(KOT_DET.RoomAmt),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring

            'sqlstring = "UPDATE KOT_HDR SET TotalTax = TAXAMT,Total = TOTAMT,BillAmount = BILLAMT FROM KOT_DET K ,KOT_HDR H WHERE K.KOTDETAILS = H.Kotdetails AND K.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "' "
            ''gconnection.dataOperation(9, sqlstring, "TOTAL4")
            'ReDim Preserve StrUpdate(StrUpdate.Length)
            'StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET TotalTax = (SELECT ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET Total = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring
            sqlstring = " UPDATE KOT_HDR SET BillAmount = (SELECT ISNULL(SUM(KOT_DET.AMOUNT),0)+ISNULL(SUM(KOT_DET.TAXAMOUNT),0) FROM KOT_DET WHERE KOT_DET.KOTDETAILS = KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.KOTSTATUS,'') <> 'Y' GROUP BY KOTDETAILS) WHERE KOT_HDR.KOTDETAILS = '" & Trim(txt_KOTno.Text) & "'"
            ReDim Preserve StrUpdate(StrUpdate.Length)
            StrUpdate(StrUpdate.Length - 1) = sqlstring


            gconnection.MoreTrans1(StrUpdate)

            'sqlstring = "EXEC UPD_PACK '" & Trim(txt_KOTno.Text) & "'"
            'gconnection.dataOperation(6, sqlstring, "UPD_PACK")

            'If Val(PACKINGPERCENT) <> 0 Then
            '    sqlstring = "UPDATE KOT_DET SET PACKPERCENT=" & Val(PACKINGPERCENT) & ",PACKAMOUNT=AMOUNT*" & (Val(PACKINGPERCENT) / 100) & " WHERE KOTDETAILS='" & Trim(txt_KOTno.Text) & "'"
            '    gconnection.dataOperation(9, sqlstring, "PACK")
            'Else
            '    sqlstring = "UPDATE KOT_DET SET PACKPERCENT=0,PACKAMOUNT=0 WHERE KOTDETAILS='" & Trim(txt_KOTno.Text) & "'"
            '    gconnection.dataOperation(9, sqlstring, "PACK")
            'End If

            sqlstring = "UPDATE KOT_DET SET CATEGORY=A.CATEGORY FROM VIEW_ITEMMASTER A WHERE A.ITEMCODE=KOT_DET.ITEMCODE AND KOTDETAILS='" & Trim(txt_KOTno.Text) & "'"
            gconnection.dataOperation(9, sqlstring, "CAT")

            If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                Call Cmd_Clear_Click(sender, e)
                If kotupdate = True Then
                    Me.Close()
                End If
            Else
                Call Cmd_Clear_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub CheckBillAmt()
        Dim j, Qty As Integer
        Dim TotAmt, TotTaxAmt, TotBillAmt As Double
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, ITEMCODE As String
        Dim TPercent As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt As Double
        GrdAmount = 0
        For i = 1 To sSGrid.DataRowCnt
            With sSGrid
                .Col = 8
                .Row = i
                GrdAmount = GrdAmount + Val(.Text)
            End With
        Next
        For i = 1 To sSGrid.DataRowCnt
            Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
            GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
            With sSGrid
                .Col = 1
                .Row = i
                ITEMCODE = Trim(.Text)
                .Col = 6
                .Row = i
                GrdRate = Val(.Text)
                .Col = 5
                .Row = i
                Qty = Val(.Text)
                .Col = 9
                .Row = i
                ChargeCode = Trim(.Text)
                SQLSTRING = "SELECT TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                gconnection.getDataSet(SQLSTRING, "CODE_CHECK")
                If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                    ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                End If
                SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                gconnection.getDataSet(SQLSTRING, "TAXON")
                If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                    For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                        If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                            Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZero = GZero + Zero
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                            ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroA = GZeroA + ZeroA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                            ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroB = GZeroB + ZeroB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                            One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOne = GOne + One
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                            OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneA = GOneA + OneA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                            OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneB = GOneB + OneB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                            Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwo = GTwo + Two
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                            TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoA = GTwoA + TwoA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                            TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoB = GTwoB + TwoB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                            Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThree = GThree + Three
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                            ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeA = GThreeA + ThreeA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                            ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeB = GThreeB + ThreeB
                        End If
                    Next
                    GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                End If
                TotAmt = TotAmt + (Val(GrdRate) * Qty)
                TotTaxAmt = TotTaxAmt + (Val(GrdTaxAmt) * Qty)
                TotBillAmt = TotBillAmt + ((Val(GrdTaxAmt) * Qty) + (Val(GrdRate) * Qty))
            End With
        Next
        GrdAmount = GrdAmount + TotTaxAmt
        For i = 1 To sSGrid.DataRowCnt
            With sSGrid
                .Col = 1
                .Row = i
                ITEMCODE = Trim(.Text)
                .Col = 5
                .Row = i
                Qty = Val(.Text)
                .Col = 8
                .Row = i
                GAmt = Val(.Text)
                If gCenterlized = "Y" Then
                    TPackAmt = Val((GAmt * gPackPer) / 100)
                    TTipsAmt = Val((GAmt * gTipsPer) / 100)
                    TAdchgAmt = Val((GAmt * gAdCgsPer) / 100)
                    TPartyAmt = Val((GAmt * gPartyPer) / 100)
                    TRoomAmt = Val((GAmt * gRoomPer) / 100)
                Else
                    TPackAmt = Val((GAmt * pPackPer) / 100)
                    TTipsAmt = Val((GAmt * pTipsPer) / 100)
                    TAdchgAmt = Val((GAmt * pAdCgsPer) / 100)
                    TPartyAmt = Val((GAmt * pPartyPer) / 100)
                    TRoomAmt = Val((GAmt * pRoomPer) / 100)
                End If
                GrdAmount = GrdAmount + (TPackAmt + TTipsAmt + TAdchgAmt + TPartyAmt + TRoomAmt)
            End With
        Next
    End Sub

    Private Sub txt_KOTno_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_KOTno.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmd_KOTnoHelp_Click(sender, e)
        End If
    End Sub

    Private Sub cmd_KOTnoHelp_Click(sender As Object, e As EventArgs) Handles cmd_KOTnoHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT Kotdetails,Convert(varchar, kotdate,100) as kotdate,MCODE,MNAME,DOCTYPE FROM KOT_HDR "
        If Trim(txt_MemberCode.Text) <> "" Then
            M_WhereCondition = " WHERE ISNULL(MANUALBILLSTATUS,'')='N' AND ISNULL(DELFLAG,'') <> 'Y' AND CAST(CONVERT(CHAR(39),KOTDATE,106) AS DATETIME)='" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "' AND MCODE='" & Trim(txt_MemberCode.Text) & "'"
        Else
            M_WhereCondition = " WHERE ISNULL(MANUALBILLSTATUS,'')='N' AND ISNULL(DELFLAG,'') <> 'Y'"
        End If
        vform.Field = " KOTDETAILS,KOTDATE,MCODE,MNAME "
        'vform.vFormatstring = "            KOT NO              |     SERVER CODE    |     SERVER NAME      |       KOT DATE           |       MCODE     |       MNAME     "
        vform.vCaption = "KOT DETAILS HELP"
        'vform.KeyPos = 0
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_KOTno.Text = Trim(vform.keyfield & "")
            CMB_BTYPE.Text = Trim(vform.keyfield4 & "")
            Call txt_KOTno_Validated(sender, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_KOTno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_KOTno.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_KOTno.Text) = "" Then
                Call cmd_KOTnoHelp_Click(cmd_KOTnoHelp, e)
            Else
                cbo_PaymentMode.Focus()
            End If
        End If
    End Sub

    Private Sub txt_KOTno_Validated(sender As Object, e As EventArgs) Handles txt_KOTno.Validated
        Dim vTypeseqno, vGroupseqno As Double
        Dim vString, sqlstring As String
        Dim dt As New DataTable
        Dim j, i As Integer
        If Trim(txt_KOTno.Text) <> "" Then
            Call KOTNoValidate(Trim(txt_KOTno.Text))
            'Call txt_LOCATIONCODE_Validated(sender, e)
            'CMD_LOCK()
        End If
    End Sub
    Public Sub KOTNoValidate(ByVal KOTNO As String)
        Dim vTypeseqno, vGroupseqno As Double
        Dim vString, sqlstring, strstring As String
        Dim a As System.EventArgs
        Dim dt As New DataTable
        Dim j, i As Integer
        Dim STRBILLNO, strbillno2 As String
        Try
            If Trim(KOTNO) <> "" Then
                If gCenterlized = "Y" Then
                    sqlstring = "SELECT isnull(BILLDETAILS,'') as BILLDETAILS,* FROM KOT_DET WHERE ( KOTNO='" & Format(Val(KOTNO), "000000") & "'  OR KOTDETAILS = '" & Trim(KOTNO) & "') and kotdetails like '" & gDocType & "%'"
                Else
                    If Mid(pKotType, 1, 1) = "A" Then
                        sqlstring = "SELECT isnull(BILLDETAILS,'') as BILLDETAILS,* FROM KOT_DET WHERE ( KOTNO='" & Format(Val(KOTNO), "000000") & "'  OR KOTDETAILS = '" & Trim(KOTNO) & "') and kotdetails like '" & DOCTYPE & "%'"
                    Else
                        sqlstring = "SELECT isnull(BILLDETAILS,'') as BILLDETAILS,* FROM KOT_DET WHERE  KOTDETAILS = '" & Trim(KOTNO) & "' "
                    End If
                End If
                gconnection.getDataSet(sqlstring, "KOT_DET")
                If gdataset.Tables("KOT_DET").Rows.Count > 0 Then
                    For i = 0 To gdataset.Tables("KOT_DET").Rows.Count - 1
                        If Trim(STRBILLNO) = "" Then
                            STRBILLNO = Trim(gdataset.Tables("KOT_DET").Rows(i).Item("BILLDETAILS"))
                        Else
                            strbillno2 = Trim(gdataset.Tables("KOT_DET").Rows(i).Item("BILLDETAILS"))
                        End If
                    Next
                    lblBillno1.Text = STRBILLNO
                    If STRBILLNO <> "" Then
                        STRBILLNO = Trim(STRBILLNO)
                        lblBillno1.Visible = True
                        lblBillno1.Text = STRBILLNO
                    End If
                    'If strbillno2 <> "" Then
                    '    strbillno2 = Trim(strbillno2)
                    '    lblBillno2.Visible = True
                    '    lblBillno2.Text = strbillno2
                    'End If
                End If
                sqlstring = "SELECT ISNULL(PACKAMT,0) as PACKAMT,ISNULL(DISCOUNTAMT,0) as DISCOUNTAMT,ISNULL(REMARKS,'') AS REMARKS,* FROM KOT_HDR "
                If gCenterlized = "Y" Then
                    sqlstring = sqlstring & " WHERE (KOTNO='" & Format(Val(KOTNO), "000000") & "'  OR KOTDETAILS = '" & Trim(KOTNO) & "')  and kotdetails like '" & gDocType & "%'"
                Else
                    If Mid(pKotType, 1, 1) = "A" Then
                        sqlstring = sqlstring & " WHERE (KOTNO='" & Format(Val(KOTNO), "000000") & "'  OR KOTDETAILS = '" & Trim(KOTNO) & "')  and kotdetails like '" & DOCTYPE & "%'"
                    Else
                        sqlstring = sqlstring & " WHERE  KOTDETAILS = '" & Trim(KOTNO) & "'  "
                    End If
                End If

                'sqlstring = sqlstring & " WHERE KOTNO='" & KOTNO & "'  AND DOCTYPE ='SALE' OR KOTDETAILS='" & Trim(KOTNO) & "' AND DOCTYPE ='SALE'"
                gconnection.getDataSet(sqlstring, "KOT_HDR")
                '''************************************************* SELECT record from KOT_HDR *********************************************''''                
                If gdataset.Tables("KOT_HDR").Rows.Count > 0 Then

                    ''===============
                    Call GridUnLock()
                    ''===============
                    ''Call CROGRIDLOCK()
                    'sSGrid.Col = 12

                    ''Call GridColUnLock(9)
                    sSGrid.ClearRange(1, 1, -1, -1, True)
                    Cmd_Add.Text = "Update[F7]"
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    Me.txt_KOTno.ReadOnly = True
                    If gdataset.Tables("Kot_Hdr").Rows(0).IsNull("CroStatus") = False Then
                        If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("CroStatus")) = "Y" Then
                            Me.Cmd_Add.Enabled = False
                        End If
                    End If

                    If gdataset.Tables("Kot_Hdr").Rows(0).IsNull("BillStatus") = False Then
                        If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("BillStatus")) = "ST" Then
                            Me.Lbl_Bill.Visible = True
                            If gdataset.Tables("Kot_Hdr").Rows(0).IsNull("CroStatus") = True Then
                                Me.Lbl_Bill.Text = "BILL  GENERATED"
                                Call disablecontrols()
                            Else
                                If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("CroStatus")) = "N" Then
                                    Me.Lbl_Bill.Text = "BILL  GENERATED"
                                    Call disablecontrols()
                                Else
                                    Me.Lbl_Bill.Text = "CRO GENERATED"
                                    Call disablecontrols()
                                    Call CROGRIDLOCK()
                                End If
                            End If
                        Else
                            Me.Lbl_Bill.Visible = True
                            Me.Lbl_Bill.Text = "BILL NOT GENERATED"
                            '-------------only Aministrator can edit the bill with out card.-------------------------
                            If gUserCategory <> "S" Then
                                If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("PAYMENTTYPE")) = "SMART CARD" And Trim(txt_card_id.Text) = "" Then
                                    MessageBox.Show("THIS IS SMART CARD BILL KINDLY! SWIPE THE CARD TO EDIT KOT..... ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                                    Cmd_Add.Enabled = False
                                End If
                            End If
                            '-------------only Aministrator can edit the bill with out card.-------------------------   
                        End If
                    Else
                        Me.Lbl_Bill.Visible = True
                        Me.Lbl_Bill.Text = "BILL NOT GENERATED"
                        '-------------only Aministrator can edit the bill with out card.-------------------------
                        If gUserCategory <> "S" Then
                            If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("PAYMENTTYPE")) = "SMART CARD" And Trim(txt_card_id.Text) = "" Then
                                MessageBox.Show("THIS IS SMART CARD BILL KINDLY! SWIPE THE CARD TO EDIT KOT..... ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                                Cmd_Add.Enabled = False
                            End If
                        End If
                        '-------------only Aministrator can edit the bill with out card.-------------------------   

                    End If

                    
                    KOT_Timer.Enabled = False
                    txt_KOTno.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Kotdetails") & "")
                    dtp_KOTdate.Value = Format(CDate(gdataset.Tables("KOT_HDR").Rows(0).Item("Kotdate")), "dd-MMM-yyyy")
                    'If gCompanyname = "THE TNCA CLUB" Then
                    '    dtp_KOTdate.Value = Format(CDate(gdataset.Tables("KOT_HDR").Rows(0).Item("Kotdate")), "dd-MMM")
                    'Else
                    '    dtp_KOTdate.Value = Format(CDate(gdataset.Tables("KOT_HDR").Rows(0).Item("Kotdate")), "dd-MMM-yy")
                    'End If
                    'txt_KOTTime.Text = Format(CDate(gdataset.Tables("KOT_HDR").Rows(0).Item("adddatetime")), "HH:mm:ss")
                    txt_KOTTime.Text = Format(CDate(gdataset.Tables("KOT_HDR").Rows(0).Item("adddatetime")), "T")
                    txt_TableNo.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("tableno") & "")
                    txt_Cover.Text = Val(gdataset.Tables("KOT_HDR").Rows(0).Item("Covers"))
                    txt_ServerCode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("ServerCode") & "")
                    txt_Holder_Code.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("CARDHOLDERCODE") & "")
                    Txt_holder_name.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("CARDHOLDERNAME") & "")
                    cardcode = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("CARDHOLDERCODE") & "")
                    txt_card_id.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("16_digit_code") & "")
                    txt_ServerName.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("ServerName") & "")
                    txt_LOCATIONCODE.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("SERVICELOCATION") & "")
                    cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDown
                    cbo_PaymentMode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("PaymentType") & "")
                    CMB_BTYPE.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("DOCTYPE") & "")

                    If Me.Lbl_Bill.Text = "B I L L  G E N E R A T E D" Then
                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Delete.Enabled = False
                        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDown
                        If Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("PaymentType")) = "CLUB" Then
                            txt_MemberCode.Visible = False
                            txt_MemberName.Visible = False
                            lbl_Membercode.Visible = False
                            lbl_MemberName.Visible = False
                            cmd_MemberCodeHelp.Visible = False
                        End If
                    Else
                        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
                    End If
                    Txt_Remarks.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Remarks") & "")
                    If gdataset.Tables("KOT_HDR").Rows(0).IsNull("Subpaymentmode") = False Then
                        If Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Subpaymentmode") & "") <> "" Then
                            Call FillSubPaymentMode(Trim(gdataset.Tables("KOt_HDR").Rows(0).Item("PaymentType") & ""))
                            sqlstring = "SELECT SUBPAYMENTNAME,SUBPAYMENTCODE FROM SUBPAYMENTMODE WHERE SUBPAYMENTCODE = '" & Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Subpaymentmode")) & "' "
                            gconnection.getDataSet(sqlstring, "SUBPAYMENTMODE")
                            If gdataset.Tables("SUBPAYMENTMODE").Rows.Count = 1 Then
                                cbo_SubPaymentMode.DropDownStyle = ComboBoxStyle.DropDown
                                Me.cbo_SubPaymentMode.Text = Trim(gdataset.Tables("SUBPAYMENTMODE").Rows(0).Item("SUBPAYMENTCODE") & "-" & Trim(gdataset.Tables("SUBPAYMENTMODE").Rows(0).Item("SUBPAYMENTNAME")))
                                cbo_SubPaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
                            End If
                        End If
                    End If
                    If Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("PaymentType")) = "ROOM" Then
                        txt_MemberCode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("ROOMNO")) & ""
                        txt_MemberName.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("GUEST")) & ""
                        txt_MemberCode.Tag = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("CHECKIN")) & ""
                        lbl_Membercode.Text = "ROOM NO.   :"
                        lbl_MemberName.Text = "GUEST NAME :"
                        'Modified on 15 Mar'08
                        'Mk Kannan
                        'Begin
                        'ElseIf Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("PaymentType")) = "R.MEMBER" Or Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("PaymentType")) = "COUPON" Then
                        'txt_MemberCode.Visible = False
                        'txt_MemberName.Visible = False
                        'lbl_Membercode.Visible = False
                        'lbl_MemberName.Visible = False
                        'cmd_MemberCodeHelp.Visible = False
                        'txt_MemberCode.Text = ""
                        'txt_MemberName.Text = ""
                    Else
                        If Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("MCode")) & "" <> "" And Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Mname")) & "" <> "" Then
                            txt_MemberCode.Visible = True
                            txt_MemberName.Visible = True
                            lbl_Membercode.Visible = True
                            'lbl_MemberName.Visible = True
                            cmd_MemberCodeHelp.Visible = True
                            lbl_Membercode.Text = "MEMBER CODE :"
                            lbl_MemberName.Text = "MEMBER NAME :"
                            txt_MemberCode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("MCode")) & ""
                            txt_MemberName.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Mname")) & ""
                        Else
                            txt_MemberCode.Visible = False
                            txt_MemberName.Visible = False
                            lbl_Membercode.Visible = False
                            lbl_MemberName.Visible = False
                            cmd_MemberCodeHelp.Visible = False
                            txt_MemberCode.Text = ""
                            txt_MemberName.Text = ""
                        End If

                        'Show PHOTOS
                        If gFoto = "Y" Then
                            gconnection.LoadFoto_DB_MemberMaster(txt_card_id, Pic_Member)
                        Else
                            If gShortName = "MCC" Then
                                gconnection.FOTO_LOAD_MCC(txt_Holder_Code, Pic_Member)
                            ElseIf gShortName = "NIZAM" Then
                                gconnection.Foto_LOAD_NIZAM(txt_Holder_Code, Pic_Member)
                            Else
                                gconnection.Foto_LOAD(txt_Holder_Code, Pic_Member)
                            End If
                        End If
                    End If
                    If Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("16_DIGIT_CODE")) <> "" Then
                        Cmd_Add.Enabled = False
                        Cmd_Delete.Enabled = False
                        sqlstring = "SELECT * FROM SM_CARDFILE_HDR WHERE [16_DIGIT_CODE] = '" & Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("16_DIGIT_CODE")) & "'"
                        gconnection.getDataSet(sqlstring, "CARD_CHECK")
                        If gdataset.Tables("CARD_CHECK").Rows.Count > 0 Then
                            If gdataset.Tables("CARD_CHECK").Rows(0).Item("CARDCODE") = Trim(txt_Holder_Code.Text) Then
                                Cmd_Add.Enabled = True
                                Cmd_Delete.Enabled = True
                            Else
                                Cmd_Add.Enabled = False
                                Cmd_Delete.Enabled = False
                            End If
                        End If
                    Else
                        Cmd_Add.Enabled = True
                        Cmd_Delete.Enabled = True
                    End If
                    If gdataset.Tables("KOT_HDR").Rows(0).IsNull("delflag") = False Then
                        If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("delflag")) = "Y" Then
                            Me.Cmd_Add.Enabled = False
                            Me.Cmd_Delete.Enabled = False
                            Call disablecontrols()
                            Call CROGRIDLOCK()
                            Me.Lbl_Bill.Text = "KOT  DELETED"
                            Lbl_Bill.ForeColor = Color.Red
                        End If
                    End If
                    '''************************************************* SELECT record from KOT_DET *********************************************''''                
                    sqlstring = "SELECT ISNULL(PROMOTIONALST,'') AS PROMOTIONALST,ISNULL(SALESACCOUNTCODE,0) AS SALESACCOUNTCODE,ISNULL(TAXACCOUNTCODE,0) AS TAXACCOUNTCODE,ISNULL(GROUPCODE,0) AS GROUPCODE,ISNULL(SUBGROUPCODE,'') AS SUBGROUPCODE,* FROM KOT_DET WHERE  KOTdetails='" & Trim(txt_KOTno.Text) & "' ORDER BY Autoid "
                    gconnection.getDataSet(sqlstring, "KOT_DET")
                    If gdataset.Tables("KOT_DET").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("KOT_DET").Rows.Count
                            sSGrid.SetText(1, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("ItemCode")) & "")
                            sSGrid.SetText(2, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("itemdesc")) & "")
                            sSGrid.SetText(3, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("poscode")))
                            sSGrid.SetText(4, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("UOM")))
                            sSGrid.SetText(5, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("Qty")))
                            sSGrid.SetText(6, i, Format(Val(gdataset.Tables("KOT_DET").Rows(j).Item("Rate")), "0.00"))
                            sSGrid.SetText(7, i, Format(Val(gdataset.Tables("KOT_DET").Rows(j).Item("Taxamount")), "0.00"))
                            sSGrid.SetText(8, i, Format(Val(gdataset.Tables("KOT_DET").Rows(j).Item("Amount")), "0.00"))
                            sSGrid.SetText(9, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("ItemType")) & "")
                            sSGrid.SetText(10, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("TaxCode")) & "")
                            sSGrid.SetText(11, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("TaxPerc")))
                            sSGrid.SetText(13, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("TaxAccountCode")))
                            sSGrid.SetText(14, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("SalesAccountCode")))
                            sSGrid.SetText(15, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("GroupCode")))
                            sSGrid.SetText(16, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("SUBGROUPCODE")))
                            sSGrid.SetText(17, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("Autoid")))
                            sSGrid.SetText(18, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("PROMOTIONALST")))
                            'REFERINVENTORY***********************************************************************
                            sSGrid.SetText(19, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("Qty")))
                            '*************************************************************************************
                            If CStr(gdataset.Tables("KOT_DET").Rows(j).Item("KOTStatus") & "") = "Y" Then
                                sSGrid.SetText(12, i, "Yes")
                            Else
                                sSGrid.SetText(12, i, "No")
                            End If
                            j = j + 1
                        Next
                    End If
                    Call Calculate()
                    Call gridlock_new()
                    Call GridColUnLock(12)
                    TotalItemCount = gdataset.Tables("KOT_DET").Rows.Count
                    cbo_PaymentMode.Focus()
                    cmd_KOTnoHelp.Enabled = False
                Else
                    'MessageBox.Show("Enter valid KOT No ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    'Call cmd_Clear_Click(cmd_Clear, a)
                    If Mid(pKotType, 1, 1) = "A" Or Mid(gKotType, 1, 1) = "A" Then
                    Else
                        strstring = "SELECT * FROM KOT_HDR WHERE KOTDETAILS='" & txt_KOTno.Text & "'"
                        gconnection.getDataSet(strstring, "KOTNO")
                        If gdataset.Tables("KOTNO").Rows.Count = 0 Then
                            strstring = " Select isnull(Prefix,'') as Prefix,isnull(Servercode,'') as Servercode From Kotbook "
                            strstring = strstring & "  Where  " & IIf(Val(txt_KOTno.Text) > 0, Val(txt_KOTno.Text), 0) & " between snofrom and  snoto "
                            gconnection.getDataSet(strstring, "servermaster")
                            If gdataset.Tables("servermaster").Rows.Count > 0 Then
                                txt_ServerCode.Text = gdataset.Tables("servermaster").Rows(0).Item("Servercode")
                                strstring = " Select isnull(servername,'') as servername,isnull(Servercode,'') as Servercode From servermaster where servercode='" & Trim(txt_ServerCode.Text) & "' "
                                gconnection.getDataSet(strstring, "servername")
                                txt_ServerName.Text = gdataset.Tables("servername").Rows(0).Item("servername")
                                'txt_ServerCode_Validated(sender, e)
                                'cbo_PaymentMode.Focus()
                                txt_MemberCode.Focus()
                            Else
                                MessageBox.Show("Kindly Register This Kotbook in System,Thanking You", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                txt_KOTno.Text = ""
                                txt_KOTno.Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                'cbo_PaymentMode.Focus()
                cmd_KOTnoHelp.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Enter valid KOT No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Call Cmd_Clear_Click(Cmd_Clear, a)
            Exit Sub
        End Try
    End Sub
    Private Sub CROGRIDLOCK()
        Dim Row, Col As Integer
        sSGrid.Col = 15
        sSGrid.Row = sSGrid.ActiveRow
        For Row = 1 To 100
            For Col = 1 To 15
                sSGrid.Row = Row
                sSGrid.Col = Col
                sSGrid.Lock = True
            Next
        Next Row
    End Sub
    Private Sub gridlock_new()
        Dim Row, Col As Integer
        For Row = 1 To 100
            For Col = 1 To 18
                ssGrid.Row = Row
                ssGrid.Col = Col
                ssGrid.Lock = True
            Next
        Next Row
    End Sub
    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        Call checkvalidate() '''---> Check Validation
        If chkbool = False Then Exit Sub
        Dim sqlstring, Delete(0) As String
        Dim dt As New DataTable

        sqlstring = "SELECT ISNULL(BillStatus,'PO') As BillStatus,ISNULL(Crostatus,'N') As Crostatus,ISNULL(PostingStatus,'N') as PostingStatus FROM Kot_Hdr WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
        dt = gconnection.GetValues(sqlstring)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("PostingStatus") = "Y" Then
                If MsgBox("The KotAmount Is Already Posted To Accounts,Deleting This Kot Also Reflects In Accounts,Are U Sure To Delete", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Call DeleteOperation()
                    Exit Sub
                Else
                    Call Cmd_Clear_Click(Cmd_Clear, e)
                    Exit Sub
                End If
            ElseIf dt.Rows(0).Item("CRostatus") = "Y" Then
                If MsgBox("The KotAmount Is Already Posted To Cro,Deleting This Kot Also Reflects In Cro,Are U Sure To Delete", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    '                    Call DeleteOperation()
                    Exit Sub
                Else
                    Call Cmd_Clear_Click(Cmd_Clear, e)
                    Exit Sub
                End If
            ElseIf dt.Rows(0).Item("BillStatus") = "ST" Then
                If MsgBox("The KotAmount Is Already Posted To Final Bill,Deleting This Kot Also Reflects In Final Bill,Are U Sure To Delete", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Call DeleteOperation()
                    Exit Sub
                Else
                    Call Cmd_Clear_Click(Cmd_Clear, e)
                    Exit Sub
                End If
            Else
                '''************************************** Deleting KOTDETAILS Permently from KOT_HDR ************************************'''
                sqlstring = " UPDATE KOT_HDR SET DELFLAG = 'Y' WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                Delete(0) = sqlstring
                '''************************************************* COMPLETE KOT_HDR ***************************************************'''
                '''************************************** Deleting KOTDETAILS Permently from KOT_DET ************************************'''
                sqlstring = " UPDATE KOT_DET SET DELFLAG = 'Y',kotstatus='Y' WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring

                sqlstring = " UPDATE KOT_DET_TAX SET VOID = 'Y',kotstatus='Y' WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring
                '''************************************** Deleting item  reason from KOT_DET ************************************'''
                'sqlstring = " UPDATE KOT_DET SET reason = '" & Trim(cmb_CANNAME.Text) & "' WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                'ReDim Preserve Delete(Delete.Length)
                'Delete(Delete.Length - 1) = sqlstring
                '''************************************** Deleting item  reason from KOT_hdr ************************************'''
                'sqlstring = " UPDATE KOT_hdr SET reason = '" & Trim(cmb_CANNAME.Text) & "' WHERE KotDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                'ReDim Preserve Delete(Delete.Length)
                'Delete(Delete.Length - 1) = sqlstring
                '''************************************************* COMPLETE KOT_HDR ***************************************************'''
                'REFERINVENTORY************************************* UPDATING STOCK FOR KOT DELETION **************************************
                sqlstring = " UPDATE SUBSTORECONSUMPTIONDETAIL SET VOID = 'Y' WHERE DOCDetails='" & Trim(CStr(Me.txt_KOTno.Text)) & "'"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring
                '***************************************************************************************************************************

                sqlstring = "DELETE FROM KOTBLOCK WHERE MCODE='" & Trim(Me.txt_MemberCode.Text) & "'"
                ReDim Preserve Delete(Delete.Length)
                Delete(Delete.Length - 1) = sqlstring

                gconnection.MoreTransold(Delete)
                If rac < 1 Then
                    Call Cmd_Clear_Click(Cmd_Clear, e)
                End If
            End If
        Else
            MessageBox.Show("Plz Enter a Valid KOTno", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        Call Cmd_Clear_Click(Cmd_Clear, e)
    End Sub
    Private Sub checkvalidate()
        Dim i As Integer
        Dim j As Integer
        Dim icode, icode1, uom, uom1 As String
        Dim taxcode, sqlstring, itemcode, itemdesc As String
        chkbool = False
        ''***************************************** Assign Account Code Value **********************************************'''
        Dim SSQL As String
        Dim PAY As String
        PAY = ""
        'SMART CARD
        'ROOM CHECKIN
        'MEMBER ACCOUNT
        'BANK INSTRUMENT
        'CASH
        'CLUB ACCOUNT
        'EMPLOYEE

        SSQL = "select MEMBERSTATUS froM PAYMENTMODEMASTER WHERE PAYMENTCODE='" & cbo_PaymentMode.SelectedItem & "'AND ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(SSQL, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            PAY = gdataset.Tables("PAY").Rows(0).Item("MEMBERSTATUS")
        Else
            MsgBox("NO INPUT DEFINED FOR THIS PAYMENTMODE")
            Exit Sub
        End If
        If PAY = "ROOM CHECKIN" Then
            accountcode = "RMLDGR"
        Else
            accountcode = gDebtors
        End If
        If PAY = "ROOM CHECKIN" Then
            ordertype = "ROOMGUEST"
        ElseIf PAY = "CLUB ACCOUNT" Then
            ordertype = "CLUBMEMBER"
        ElseIf PAY = "EMPLOYEE" Then
            ordertype = "EMPMEMBER"
        ElseIf PAY = "SMART CARD" Then
            sqlstring = "SELECT isnull(MEMBERCODE,'') AS MEMBERCODE, ISNULL(MEMBERSUBCODE,'') AS  MEMBERSUBCODE, ISNULL(CARDCODE,'')AS CARDCODE, ISNULL(FANCYCODE,'')AS FANCYCODE,ISNULL(PASSWORD,'')AS PASSWORD, "
            sqlstring = sqlstring & " ISNULL(ACTIVATION_FLAG,'')AS ACTIVATION_FLAG, ISNULL(ISSUETYPE,'')AS ISSUETYPE,ISNULL(VALID_FROM,'')AS VALID_FROM,ISNULL(VALID_TO,'')AS VALID_TO,ISNULL(NAME,'')AS NAME, ISNULL(CARDHOLDERNAME,'')AS CARDHOLDERNAME, ISNULL(AGE,0)AS AGE, ISNULL(DOB,'')AS DOB, ISNULL(TRANSACTION_TYPE,'')AS TRANSACTION_TYPE, ISNULL(AMOUNT,0)AS AMOUNT, ISNULL(BALANCE,0)AS BALANCE "
            sqlstring = sqlstring & " FROM SM_CARDFILE_HDR WHERE CARDCODE='" & cardcode & "'"
            gconnection.getDataSet(sqlstring, "SM_CARDFILE_HDR")
            If gdataset.Tables("SM_CARDFILE_HDR").Rows.Count > 0 Then
                If gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "MEM" Then
                    ordertype = "CLUBMEMBER"
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TA" Then
                    ordertype = "AFFMEMBER"
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "EM" Then
                    ordertype = "EMPMEMBER"
                ElseIf gdataset.Tables("SM_CARDFILE_HDR").Rows(0).Item("ISSUETYPE") = "TE" Then
                    ordertype = "ROOMGUEST"
                End If
            End If
        Else
            ordertype = "CLUBMEMBER"
        End If
        '''**************************************** Check Tableno can't be blank *******************************************'''
        If Trim(txt_TableNo.Text) = "" And txt_TableNo.ReadOnly = False Then
            MessageBox.Show("Table No. Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_TableNo.Focus()
            Exit Sub
        End If
        If Trim(txt_LOCATIONCODE.Text) = "" Then
            MessageBox.Show("Location Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_LOCATIONCODE.Focus()
            Exit Sub
        End If
        If Trim(TXT_LOCATIONNAME.Text) = "" Then
            MessageBox.Show("Location Name Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            TXT_LOCATIONNAME.Focus()
            Exit Sub
        End If
        'sqlstring = "SELECT * FROM KOTBLOCK WHERE MCODE='" & Trim(Me.txt_MemberCode.Text) & "'"
        'gconnection.getDataSet(sqlstring, "KOTBLOCK")
        'If gdataset.Tables("KOTBLOCK").Rows.Count > 0 Then
        '    MsgBox("SORRY PENDING BILL IS ALREADY PRINTED MAKE SETTLEMENT FIRST THEN ENTER ANY OTHER KOT")
        '    Exit Sub
        'End If
        sqlstring = "select isnull(delflag,'') as delflag from kot_det where kotdetails='" & Trim(Me.txt_KOTno.Text) & "'"
        gconnection.getDataSet(sqlstring, "KOT_bill1")
        If gdataset.Tables("kot_bill1").Rows.Count > 0 Then
            If UCase(gdataset.Tables("kot_bill1").Rows(0).Item("delflag")) = "Y" Then
                MsgBox("Deleted Kot Cannot Be Updated....", MsgBoxStyle.OKOnly, "finalized KOTS")
                Exit Sub
            End If
        End If
        'If Trim(txt_TableNo.Text) = "" Then
        '    MessageBox.Show("Table No. Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    txt_TableNo.Focus()
        '    Exit Sub
        'End If

        sqlstring = "select isnull(billdetails,'')as billdetails from kot_det where kotdetails='" & Me.txt_KOTno.Text & "' and isnull(delflag,'')<>'' and isnull(kotstatus,'')<>'y' and isnull(billdetails,'')<>'' "
        gconnection.getDataSet(sqlstring, "KOT_bill")
        If gdataset.Tables("kot_bill").Rows.Count > 0 Then
            MsgBox("bill is already generated....", MsgBoxStyle.OKOnly, "finalized KOTS")
            Exit Sub
        End If
        'If UCase(gCompanyname) <> "CATHOLIC CLUB" Then
        '    sqlstring = "SELECT KOTDETAILS FROM KOT_HDR WHERE BILLSTATUS='PO'"
        '    sqlstring = sqlstring & " AND ISNULL(DELFLAG,'') <> 'Y' AND CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) < '" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "'AND month(CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME)) <>'5'"
        '    gconnection.getDataSet(sqlstring, "KOT_HDR")
        '    If gdataset.Tables("KOT_HDR").Rows.Count > 0 Then
        '        MsgBox("Please Clear the Pending KOTS (Kot Vs Final Bill)....", MsgBoxStyle.OKOnly, "PENDING KOTS")
        '        Exit Sub
        '    End If
        'End If
        '''**************************************** Check Payment Mode can't be blank *******************************************''
        If Trim(cbo_PaymentMode.Text) = "" Then
            MessageBox.Show("Payment Mode Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            cbo_PaymentMode.Focus()
            Exit Sub
        End If
        '''**************************************** Check Room No and Member Code can't be blank *******************************************''
        If Trim(txt_MemberCode.Text) = "" Then
            If PAY = "ROOM CHECKIN" Then
                MessageBox.Show("Room No Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_MemberCode.Focus()
                Exit Sub
            ElseIf cbo_PaymentMode.Text = "R.MEMBER" Then
                cbo_PaymentMode.Text = "R.MEMBER"
            ElseIf cbo_PaymentMode.Text = "COUPON" Then
                cbo_PaymentMode.Text = "COUPON"
            ElseIf PAY = "CLUB ACCOUNT" Then
                'cbo_PaymentMode.Text = "CLUB"
            Else
                MessageBox.Show("Member Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_MemberCode.Focus()
                Exit Sub
            End If
        End If
        If gUserCategory <> "S" Then
            sqlstring = "SELECT * FROM kot_hdr WHERE CAST(CONVERT(VARCHAR(11),KOTDATE,6) AS DATETIME) ='" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "' AND postingstatus = 'Y'"
            gconnection.getDataSet(sqlstring, "kot_hdr")
            If gdataset.Tables("kot_hdr").Rows.Count > 0 Then
                Cmd_Add.Enabled = False
                cmd_Delete.Enabled = False
                MessageBox.Show("NO KOT SHOULD BE ENTERED/UPDATED ON  BILL CLOSED DATE:" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If
        If txt_KOTno.Text = "" Then
            MessageBox.Show("KOT NO Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_KOTno.Focus()
            Exit Sub
        End If
        '''**************************************** Check Guest Name and Member Name can't be blank *******************************************''
        If Trim(txt_MemberName.Text) = "" Then
            If PAY = "ROOM CHECKIN" Then
                MessageBox.Show("Guest Name Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_MemberName.Focus()
                Exit Sub
            ElseIf cbo_PaymentMode.Text = "R.MEMBER" Then
                cbo_PaymentMode.Text = "R.MEMBER"
            ElseIf cbo_PaymentMode.Text = "COUPON" Then
                cbo_PaymentMode.Text = "COUPON"
            ElseIf PAY = "CLUB ACCOUNT" Then
                'cbo_PaymentMode.Text = "CLUB"
            Else
                MessageBox.Show("Member Name Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_MemberName.Focus()
                Exit Sub
            End If
        End If
        '''**************************************** Check Server Code can't be blank *******************************************''
        If Trim(txt_ServerCode.Text) = "" Then
            MessageBox.Show("Server Code. Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_ServerCode.Focus()
            Exit Sub
        End If
        '''**************************************** Check Server Name can't be blank *******************************************''
        If Trim(txt_ServerName.Text) = "" Then
            MessageBox.Show("Server Name Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_ServerName.Focus()
            Exit Sub
        End If
        '''********************************************* Check ssgrid1 value can't be blank ********************************************'''
        If sSGrid.DataRowCnt = 0 Then
            MessageBox.Show("!! Sorry !!There is no KOT DETAILS part to be saved", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            sSGrid.Focus()
            sSGrid.SetActiveCell(1, 1)
            Exit Sub
        End If

        'Dim K, CCT As Integer
        'For j = 1 To sSGrid.DataRowCnt
        '    Dim ITC
        '    sSGrid.Col = 2
        '    sSGrid.Row = j
        '    ITC = sSGrid.Text
        '    For K = 1 To sSGrid.DataRowCnt
        '        sSGrid.Col = 2
        '        sSGrid.Row = K
        '        If Trim(sSGrid.Text) = ITC Then
        '            CCT = CCT + 1
        '        End If
        '    Next
        '    If CCT > 1 Then
        '        MsgBox("duplicate item entry")
        '        Exit Sub
        '    End If
        '    'End If
        '    CCT = 0
        'Next
        With sSGrid
            For i = 1 To .DataRowCnt
                .Row = i
                .Col = 1
                itemcode = Trim(CStr(sSGrid.Text))
                .Row = i
                .Col = 2
                itemdesc = Trim(CStr(sSGrid.Text))
                If i = 1 Then
                    .Row = i
                    .Col = 3
                    loccode = Trim(.Text)
                End If
                sqlstring = "SELECT ITEMCODE,ITEMDESC,ISNULL(OPENFACILITY,'') AS OPENFACILITY FROM VIEW_ITEMMASTER WHERE Itemcode = '" & Trim(itemcode) & "'--AND Itemdesc = '" & Trim(itemdesc) & "'"
                gconnection.getDataSet(Trim(sqlstring), "VIEW_ITEMMASTER")
                If gdataset.Tables("VIEW_ITEMMASTER").Rows.Count > 0 Then
                    .Row = i
                    .Col = 1
                    sSGrid.Text = Trim(CStr(gdataset.Tables("VIEW_ITEMMASTER").Rows(0).Item("ITEMCODE")))
                    .Row = i
                    .Col = 2
                    If Trim(CStr(gdataset.Tables("VIEW_ITEMMASTER").Rows(0).Item("OPENFACILITY"))) <> "Y" Then
                        'ssgrid1.Text = Trim(CStr(gdataset.Tables("VIEW_ITEMMASTER").Rows(0).Item("ITEMDESC")))
                    End If
                Else
                    MessageBox.Show("!!Warning!! Itemcode : " & Trim(itemcode) & " And Itemdesc : " & Trim(itemdesc) & " is not valid ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    sSGrid.Focus()
                    sSGrid.SetActiveCell(1, i)
                    Exit Sub
                End If
                'End If
            Next
        End With
        With sSGrid
            For i = 1 To .DataRowCnt
                .Row = i
                .Col = 1
                If Trim(.Text) = "" Then
                    MessageBox.Show("Item Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    .SetActiveCell(1, i)
                    .Focus()
                    Exit Sub
                End If
                .Col = 2
                If Trim(.Text) = "" Then
                    MessageBox.Show("Item Description can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    .SetActiveCell(2, i)
                    .Focus()
                    Exit Sub
                End If
                .Col = 3
                If Trim(.Text) = "" Then
                    MessageBox.Show("POS Location can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    .SetActiveCell(3, i)
                    .Focus()
                    Exit Sub
                End If
                .Col = 4
                If Trim(.Text) = "" Then
                    MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    .SetActiveCell(4, i)
                    .Focus()
                    Exit Sub
                End If
                .Col = 5
                If Val(.Text) = 0 Then
                    MessageBox.Show("Quantity can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    .SetActiveCell(5, i)
                    .Focus()
                    Exit Sub
                End If
                .Col = 17
                If Trim(.Text) <> "Y" Then
                    .Col = 6
                    If Val(.Text) = 0 Then
                        .Col = 1
                        If Mid(Trim(sSGrid.Text), Len(Trim(sSGrid.Text)), 1) <> "A" Then
                            MessageBox.Show("Rate can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            .SetActiveCell(6, i)
                            .Focus()
                            Exit Sub
                        End If
                    End If
                    If Val(.Text) = 0 Then
                        If Mid(Trim(sSGrid.Text), Len(Trim(sSGrid.Text)), 1) <> "A" Then
                            MessageBox.Show("Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            .SetActiveCell(8, i)
                            .Focus()
                            Exit Sub
                        End If
                    End If
                    .Col = 9
                    If Trim(.Text) = "" Then
                        MessageBox.Show("Item Type can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        .SetActiveCell(9, i)
                        .Focus()
                        Exit Sub
                    End If
                    '.Col = 14
                    'If Trim(.Text) = "" Then
                    '    MsgBox("Sales Account can't blank", MsgBoxStyle.Information, MyCompanyName)
                    '    .SetActiveCell(11, i)
                    '    .Focus()
                    '    Exit Sub
                    'End If
                End If
            Next
        End With
        If Cmd_Add.Text = "Update[F7]" And Me.Lbl_Bill.Text = "B I L L  G E N E R A T E D" Then
            If Me.sSGrid.DataRowCnt > TotalItemCount Then
                MessageBox.Show("Bill Has Been Generated You Can Not Add More Item,Plz Generate Another KOT ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If
        chkbool = True
    End Sub
    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        gPrint = False
        Call PrintOperation_KOT()
    End Sub
    Public Sub PrintOperation()

        Dim PROWJ As Integer
        Dim Filewrite As StreamWriter
        If gPrint = True Then
            SQLSTRING = "SELECT ISNULL(D.CATEGORY,'') as CATEGORY FROM KOT_DET AS D INNER JOIN KOT_HDR AS H ON D.KOTDETAILS = H.KOTDETAILS INNER JOIN ITEMMASTER C ON C.ITEMCODE=D.ITEMCODE WHERE H.KOTDETAILS='" & Trim(Me.txt_KOTno.Text) & "' GROUP BY D.CATEGORY"
            gconnection.getDataSet(SQLSTRING, "KOTPOS")
            If gdataset.Tables("KOTPOS").Rows.Count > 0 Then
                For PROWJ = 0 To gdataset.Tables("KOTPOS").Rows.Count - 1
                    If MsgBox("Print Next Kot(s)...", MsgBoxStyle.OKCancel + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton1, "KOT") = MsgBoxResult.OK Then
                        SQLSTRING = "SELECT ISNULL(D.KOTDETAILS,'') AS KOTDETAILS,ISNULL(D.KOTDATE,GETDATE()) AS KOTDATE,ISNULL(D.ITEMCODE,'') AS ITEMCODE,isnull(h.roomno,'') as roomno,isnull(h.guest,'') as guest,ISNULL(paymenttype,'') as paymenttype,isnull(H.servicelocation,'') as servicelocation,"
                        SQLSTRING = SQLSTRING & " ISNULL(D.ITEMDESC,'') AS ITEMDESC,ISNULL(C.STORECODE,'') AS POSCODE,ISNULL(D.UOM,'') AS UOM,ISNULL(D.QTY,0) AS QTY,ISNULL(D.RATE,0) AS RATE,"
                        SQLSTRING = SQLSTRING & " ISNULL(D.AMOUNT,0) AS AMOUNT,ISNULL(H.MCODE,'') AS MCODE,ISNULL(H.MNAME,'') AS MNAME,ISNULL(H.SERVERCODE,'') AS SERVERCODE,ISNULL(H.PRINTFLAG,'') AS PRN,"
                        'SQLSTRING = SQLSTRING & " ISNULL(H.SERVERNAME,'') AS SERVERNAME,ISNULL(D.TABLENO,'') AS TABLENO,ISNULL(H.REMARKS,'') AS REMARKS, ISNULL(D.KOTSTATUS,'') AS KOTSTATUS, ISNULL(H.DELFLAG,'') AS DELFLAG,H.ADDUSERID AS USERID FROM KOT_DET AS D INNER JOIN KOT_HDR AS H ON D.KOTDETAILS = H.KOTDETAILS INNER JOIN ITEMMASTER C ON C.ITEMCODE=D.ITEMCODE WHERE H.KOTDETAILS='" & Trim(Me.txt_KOTno.Text) & "' AND D.POSCODE='" & gdataset.Tables("KOTPOS").Rows(PROWJ).Item("POSCODE") & "' ORDER BY D.AUTOID"
                        SQLSTRING = SQLSTRING & " ISNULL(H.SERVERNAME,'') AS SERVERNAME,ISNULL(D.TABLENO,'') AS TABLENO,ISNULL(H.REMARKS,'') AS REMARKS, ISNULL(D.KOTSTATUS,'') AS KOTSTATUS, ISNULL(H.DELFLAG,'') AS DELFLAG,H.ADDUSERID AS USERID FROM KOT_DET AS D INNER JOIN KOT_HDR AS H ON D.KOTDETAILS = H.KOTDETAILS INNER JOIN ITEMMASTER C ON C.ITEMCODE=D.ITEMCODE WHERE H.KOTDETAILS='" & Trim(Me.txt_KOTno.Text) & "' AND ISNULL(D.CATEGORY,'')='" & gdataset.Tables("KOTPOS").Rows(PROWJ).Item("CATEGORY") & "' AND ISNULL(D.KOTSTATUS,'') <> 'Y' ORDER BY D.AUTOID,D.RATE DESC"
                        Call PRINT_KOT(SQLSTRING)
                    End If
                Next
            End If
        Else
            SQLSTRING = "SELECT ISNULL(D.KOTDETAILS,'') AS KOTDETAILS,ISNULL(D.KOTDATE,GETDATE()) AS KOTDATE,ISNULL(D.ITEMCODE,'') AS ITEMCODE,isnull(h.roomno,'') as roomno,isnull(h.guest,'') as guest,ISNULL(paymenttype,'') as paymenttype,isnull(H.servicelocation,'') as servicelocation,"
            SQLSTRING = SQLSTRING & " ISNULL(D.ITEMDESC,'') AS ITEMDESC,ISNULL(C.STORECODE,'') AS POSCODE,ISNULL(D.UOM,'') AS UOM,ISNULL(D.QTY,0) AS QTY,ISNULL(D.RATE,0) AS RATE,"
            SQLSTRING = SQLSTRING & " ISNULL(D.AMOUNT,0) AS AMOUNT,ISNULL(H.MCODE,'') AS MCODE,ISNULL(H.MNAME,'') AS MNAME,ISNULL(H.SERVERCODE,'') AS SERVERCODE,ISNULL(H.PRINTFLAG,'') AS PRN,"
            SQLSTRING = SQLSTRING & " ISNULL(H.SERVERNAME,'') AS SERVERNAME,ISNULL(D.TABLENO,'') AS TABLENO,ISNULL(H.REMARKS,'') AS REMARKS, ISNULL(D.KOTSTATUS,'') AS KOTSTATUS, ISNULL(H.DELFLAG,'') AS DELFLAG,H.ADDUSERID AS USERID FROM KOT_DET AS D INNER JOIN KOT_HDR AS H ON D.KOTDETAILS = H.KOTDETAILS INNER JOIN ITEMMASTER C ON C.ITEMCODE=D.ITEMCODE WHERE H.KOTDETAILS='" & Trim(Me.txt_KOTno.Text) & "' AND ISNULL(D.KOTSTATUS,'') <> 'Y' ORDER BY D.POSCODE,D.RATE DESC,D.AUTOID ASC"
            Call PRINT_KOT(SQLSTRING)
        End If
    End Sub
    Private Sub PRINT_KOT(ByVal sqlstring As String)
        Dim PROWJ, rowj, Loopindex, i, in1, CountItem, Fo As Integer
        Dim ssqlstring, ssql, Servicecode, vCaption, vPath, str, serverdetail, Fsize() As String
        Dim Forder(), vFilepath, vOutfile, vheader, vline, INSERT(0) As String
        Dim USERNAME, REMARKS, KOTNO As String
        Dim Filewrite As StreamWriter
        Dim vpagenumber, Vrowcount, innercount, FREECOUNT As Long
        Dim addUser, KOT As String
        Dim gamount As Double
        Dim mcode As String
        Dim Pposcode As String
        gCompanyname = MyCompanyName
        FREECOUNT = 0
        'Gheader = Chr(27) & Chr(106) & Chr(200) & Chr(27) & Chr(14) & Chr(27) & Chr(71) & Space(12) & gCompanyname & Space(2) & Chr(20) & Chr(27) & Chr(72)
        Gheader = Chr(27) + "E" & Space(15) & " KOT " & Space(2) & Chr(27) + "F"
        vpagenumber = 2
        Call Randomize()
        vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
        vFilepath = AppPath & "\Reports\" & vOutfile & ".txt"
        ssql = "EXEC UPD_PACK '" & Trim(txt_KOTno.Text) & "'"
        gconnection.dataOperation(6, ssql, "UPD_PACK")
        gconnection.getDataSet(sqlstring, "KOTHDR")
        If gdataset.Tables("KOTHDR").Rows.Count > 0 Then
            Filewrite = File.AppendText(vFilepath)
            vline = ""
            servicelocation = gdataset.Tables("KOTHDR").Rows(0).Item("servicelocation")
            Pposcode = gdataset.Tables("KOTHDR").Rows(0).Item("Poscode")
            addUser = gdataset.Tables("KOTHDR").Rows(0).Item("USERID")
            KOTNO = gdataset.Tables("KOTHDR").Rows(0).Item("KOTDETAILS")
            USERNAME = gdataset.Tables("KOTHDR").Rows(0).Item("USERID")
            REMARKS = gdataset.Tables("KOTHDR").Rows(0).Item("REMARKS")
            mcode = gdataset.Tables("KOTHDR").Rows(0).Item("MCODE")
            For rowj = 0 To gdataset.Tables("KOTHDR").Rows.Count - 1
                CountItem = CountItem + 1
                With gdataset.Tables("KOTHDR").Rows(rowj)
                    If Pposcode <> .Item("POSCODE") Then
                        innercount = 0
                        Filewrite.WriteLine("")
                        Filewrite.WriteLine("")
                        Filewrite.WriteLine("")
                        Filewrite.WriteLine("")
                        gamount = 0
                        Filewrite.WriteLine("PREPARED BY :", Mid(Trim(USERNAME), 1, 15))
                        Pposcode = .Item("POSCODE")
                        CountItem = 1
                        For i = 1 To 8
                            Filewrite.WriteLine("")
                        Next
                        If UCase(gdataset.Tables("KOTHDR").Rows(0).Item("PRN")) <> "Y" Then
                            vheader = Chr(18) & Gheader
                        Else
                            vheader = Chr(18) & "DUPLICATE  " & Gheader
                        End If
                        Filewrite.WriteLine(vheader)
                        Filewrite.WriteLine("{0,-11}{1,-20}", "NO" & Space(8) & ":", Mid(Chr(18) & Trim(.Item("KOTDETAILS")), 1, 20))
                        Filewrite.WriteLine("{0,-11}{1,-15}{2,10}", "DATE" & Space(6) & ":", Mid(Trim(Format(dtp_KOTdate.Value, "dd-MMM-yyyy")), 1, 15), Mid(Trim(txt_KOTTime.Text), 1, 10))
                        Filewrite.WriteLine("{0,-11}{1,-20}", "AREA" & Space(6) & ":", Chr(18) & gconnection.getvalue("SELECT SUBSTRING(ISNULL(POSDESC,''),1,20) AS POSDESC FROM POSMASTER WHERE POSCODE='" & Pposcode & "'"))
                        Filewrite.WriteLine("{0,-11}{1,-20}", "WAITER" & Space(4) & ":", Mid(Chr(18) & Trim(.Item("SERVERCODE")) & " [ " & Trim(.Item("SERVERNAME")) & " ]", 1, 20))
                        If gCompanyname = "THE TNCA CLUB" Then
                            Filewrite.WriteLine("{0,-11}{1,-20}", "TABLENO" & Space(3) & ":", .Item("TABLENO"))
                        Else
                            'Filewrite.WriteLine("{0,-11}{1,-20}", "TABLENO" & Space(3) & ":", .Item("TABLENO"))
                        End If
                        If .Item("ROOMNO") = "" Then
                            Filewrite.WriteLine("{0,-11}{1,-30}", "MEMB CODE" & Space(1) & ":", Mid(Chr(14) & Chr(15) & Trim(.Item("MCODE")), 1, 20) & Chr(18))
                            Filewrite.WriteLine("{0,-11}{1,-30}", "MEMB NAME" & Space(1) & ":", Mid(.Item("MNAME"), 1, 30))
                        Else
                            Filewrite.WriteLine("{0,-11}{1,-25}", "ROOM NO" & Space(3) & ":", Mid(Chr(15) & Trim(.Item("ROOMNO")) & "[ " & Trim(.Item("GUEST")) & " ]", 1, 25))
                        End If
                        Filewrite.WriteLine(StrDup(40, "-"))
                        Filewrite.WriteLine("ITEM DESC           UOM    QTY   AMOUNT")
                        Filewrite.WriteLine(StrDup(40, "-"))
                        Filewrite.WriteLine("{0,-12}{1,-20}", "LOCATION :", Chr(14) & Chr(15) & gconnection.getvalue("SELECT ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE POSCODE='" & servicelocation & "'"))
                        Filewrite.WriteLine(StrDup(20, "-"))
                        Vrowcount = 20
                        addUser = gdataset.Tables("KOTHDR").Rows(rowj).Item("USERID")
                        KOTNO = gdataset.Tables("KOTHDR").Rows(rowj).Item("KOTDETAILS")
                        USERNAME = gdataset.Tables("KOTHDR").Rows(rowj).Item("USERID")
                        REMARKS = gdataset.Tables("KOTHDR").Rows(rowj).Item("REMARKS")
                    End If

                    If KOTNO <> .Item("KOTDETAILS") Then
                        For i = 1 To 12 - innercount
                            Filewrite.WriteLine()
                        Next i
                        innercount = 0

                        Filewrite.WriteLine(StrDup(40, "-"))
                        '                        Filewrite.WriteLine("{0,-18}{1,-5}{2,-7}{3,-10}", "Total :" & Space(10), Space(5), Space(7), Mid(Format(Val(gamount), "0.00"), 1, 9))
                        Filewrite.WriteLine(StrDup(40, "-"))
                        Filewrite.WriteLine("")
                        gamount = 0
                        Filewrite.WriteLine("PREPARED BY :", Mid(Trim(USERNAME), 1, 15))

                        Pposcode = .Item("POSCODE")
                        CountItem = 1
                        For i = 1 To 8
                            Filewrite.WriteLine("")
                        Next

                        'NEW ONE

                        'Filewrite.WriteLine("")
                        If UCase(gdataset.Tables("KOTHDR").Rows(0).Item("PRN")) <> "Y" Then
                            vheader = Chr(18) & Gheader
                        Else
                            vheader = Chr(18) & "DUPLICATE  " & Gheader
                        End If
                        Filewrite.WriteLine(vheader)
                        'Filewrite.WriteLine("")
                        Filewrite.WriteLine("{0,-11}{1,-20}", "NO" & Space(8) & ":", Mid(Chr(18) & Trim(.Item("KOTDETAILS")), 1, 20))
                        Filewrite.WriteLine("{0,-11}{1,-15}{2,10}", "DATE" & Space(6) & ":", Mid(Trim(Format(dtp_KOTdate.Value, "dd-MMM-yyyy")), 1, 15), Mid(Trim(txt_KOTTime.Text), 1, 10))
                        Filewrite.WriteLine("{0,-11}{1,-20}", "AREA" & Space(6) & ":", Chr(18) & gconnection.getvalue("SELECT ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE POSCODE='" & Pposcode & "'"))
                        Filewrite.WriteLine("{0,-11}{1,-20}", "WAITER" & Space(4) & ":", Mid(Chr(18) & Trim(.Item("SERVERCODE")) & " [ " & Trim(.Item("SERVERNAME")) & " ]", 1, 20))
                        If gCompanyname = "THE TNCA CLUB" Then
                            Filewrite.WriteLine("{0,-11}{1,-20}", "TABLENO" & Space(3) & ":", .Item("TABLENO"))
                        Else
                            'Filewrite.WriteLine("{0,-11}{1,-20}", "TABLENO" & Space(3) & ":", .Item("TABLENO"))
                        End If
                        If .Item("ROOMNO") = "" Then
                            Filewrite.WriteLine("{0,-11}{1,-30}", "MEMB CODE" & Space(1) & ":", Mid(Chr(14) & Chr(15) & Trim(.Item("MCODE")), 1, 20) & Chr(18))
                            Filewrite.WriteLine("{0,-11}{1,-30}", "MEMB NAME" & Space(1) & ":", Mid(.Item("MNAME"), 1, 30))
                        Else
                            Filewrite.WriteLine("{0,-11}{1,-25}", "ROOM NO" & Space(3) & ":", Mid(Chr(15) & Trim(.Item("ROOMNO")) & "[ " & Trim(.Item("GUEST")) & " ]", 1, 25))
                        End If


                        'Filewrite.WriteLine("")
                        Filewrite.WriteLine(StrDup(40, "-"))
                        Filewrite.WriteLine("ITEM DESC           UOM    QTY   AMOUNT")
                        Filewrite.WriteLine(StrDup(40, "-"))

                        Vrowcount = 20
                        Pposcode = gdataset.Tables("KOTHDR").Rows(rowj).Item("Poscode")
                        addUser = gdataset.Tables("KOTHDR").Rows(rowj).Item("USERID")
                        KOTNO = gdataset.Tables("KOTHDR").Rows(rowj).Item("KOTDETAILS")
                        USERNAME = gdataset.Tables("KOTHDR").Rows(rowj).Item("USERID")
                        REMARKS = gdataset.Tables("KOTHDR").Rows(rowj).Item("REMARKS")
                    End If
                End With

                With gdataset.Tables("KOTHDR").Rows(rowj)
                    If Vrowcount = 0 Then
                        If UCase(gdataset.Tables("KOTHDR").Rows(0).Item("PRN")) <> "Y" Then
                            vheader = Chr(18) & Gheader
                        Else
                            vheader = Chr(18) & "DUPLICATE  " & Gheader
                        End If
                        Filewrite.WriteLine(vheader)
                        If gdataset.Tables("KOTHDR").Rows(0).Item("DELFLAG") = "Y" Then
                            Filewrite.WriteLine(Space(10) & Chr(27) + "E" & "D E L E T E D  V O U C H E R" & Chr(27) + "F")
                        Else
                            Filewrite.WriteLine("")
                        End If

                        Filewrite.WriteLine("{0,-11}{1,-20}", "NO" & Space(8) & ":", Mid(Chr(18) & Trim(.Item("KOTDETAILS")), 1, 20) & Chr(18))
                        Filewrite.WriteLine("{0,-11}{1,-15}{2,10}", "DATE" & Space(6) & ":", Mid(Trim(Format(dtp_KOTdate.Value, "dd-MMM-yyyy")), 1, 15), Mid(Trim(txt_KOTTime.Text), 1, 10) & Chr(18))
                        'Filewrite.WriteLine("{0,-11}{1,-20} {2,10}", "DATE" & Space(6) & ":", Mid(Trim(Format(dtp_KOTdate.Value, "dd-MMM-yyyy")), 1, 20), Format(gdataset.Tables("ReportTable").Rows(rowj).Item("BillTime"), "T"))
                        Filewrite.WriteLine("{0,-11}{1,-20}", "AREA" & Space(6) & ":", Chr(18) & gconnection.getvalue("SELECT ISNULL(servicelocation,'') AS servicelocation FROM kot_hdr WHERE servicelocation='" & servicelocation & "'") & Chr(18))
                        'Filewrite.WriteLine("{0,-11}{1,-20}", "AREA" & Space(6) & ":", Chr(18) & gconnection.getvalue("SELECT ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE POSCODE='" & POScode & "'"))
                        Filewrite.WriteLine("{0,-11}{1,-20}", "WAITER" & Space(4) & ":", Mid(Chr(18) & Trim(.Item("SERVERCODE")) & " [ " & Trim(.Item("SERVERNAME")) & " ]", 1, 20) & Chr(18))
                        
                        If .Item("ROOMNO") = "" Then
                            Filewrite.WriteLine("{0,-11}{1,-30}", "MEMB CODE" & Space(1) & ":", Mid(Chr(14) & Chr(15) & Trim(.Item("MCODE")), 1, 20) & Chr(18))
                            Filewrite.WriteLine("{0,-11}{1,-30}", "MEMB NAME" & Space(1) & ":", Mid(.Item("MNAME"), 1, 30))
                        Else
                            Filewrite.WriteLine("{0,-11}{1,-25}", "ROOM NO" & Space(3) & ":", Mid(Chr(15) & Trim(.Item("ROOMNO")) & "[ " & Trim(.Item("GUEST")) & " ]", 1, 25) & Chr(18))
                        End If


                        '  Filewrite.WriteLine("")
                        Filewrite.WriteLine(StrDup(40, "-") & Chr(18))
                        Filewrite.WriteLine("ITEM DESC            UOM       QTY   ")
                        'Filewrite.WriteLine("ITEM DESC           UOM    QTY   AMOUNT")

                        Filewrite.WriteLine(StrDup(40, "-") & Chr(18))
                        Filewrite.WriteLine("{0,-12}{1,-20}", "LOCATION :", Chr(14) & Chr(15) & gconnection.getvalue("SELECT ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE POSCODE='" & servicelocation & "'"))

                        'Filewrite.WriteLine("{0,-12}{1,-20}", "KITCHEN CODE :", Chr(14) & Chr(15) & gconnection.getvalue("SELECT ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE POSCODE='" & Pposcode & "'"))
                        Filewrite.WriteLine(StrDup(20, "-"))
                        Filewrite.WriteLine("" & Chr(18))
                        Vrowcount = 10
                    End If
                End With
                With gdataset.Tables("KOTHDR").Rows(rowj)
                    If Val(.Item("RATE")) <> 0 Then
                        Filewrite.Write("{0,-20}{1,-10}{2,-14}", Mid(Trim(.Item("ITEMDESC") & ""), 1, 20), Mid(.Item("UOM"), 1, 6), Mid(Format(Val(.Item("QTY")), "0.00"), 1, 12) & Chr(18))
                        Filewrite.WriteLine("")
                        innercount = innercount + 1
                        Vrowcount = Vrowcount + 1
                    Else
                        FREECOUNT = FREECOUNT + 1
                    End If
                End With
                If FREECOUNT > 0 Then
                    Filewrite.WriteLine("FREE")
                    innercount = innercount + 1
                    Vrowcount = Vrowcount + 1
                    With gdataset.Tables("KOTHDR").Rows(rowj)
                        If Val(.Item("RATE")) = 0 Then
                            FREECOUNT = 0
                            Filewrite.Write("{0,-20}{1,-10}{2,-14}", Mid(Trim(.Item("ITEMDESC") & ""), 1, 20), Mid(.Item("UOM"), 1, 6), Mid(Format(Val(.Item("QTY")), "0.00"), 1, 12) & Chr(18))
                            Filewrite.WriteLine("")
                            innercount = innercount + 1
                            Vrowcount = Vrowcount + 1
                        End If
                    End With
                End If
            Next rowj
            innercount = 0
            Filewrite.WriteLine(StrDup(40, "-"))

            Filewrite.WriteLine("PREPARED BY :" & Trim(USERNAME), 1, 15)
            For i = 1 To 12
                Filewrite.WriteLine("")
            Next
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                INSERT(0) = "UPDATE KOT_HDR SET PRINTFLAG='Y' WHERE KOTDETAILS='" & Trim(txt_KOTno.Text) & "'"
                gconnection.MoreTransold1(INSERT)
            End If
            Filewrite.Close()
        End If

        If gPrint = False Then
            OpenTextFile(vOutfile)
        Else
            PrintTextFile1(vFilepath)
        End If
    End Sub
    Public Sub PrintOperation_KOT()
        Dim rowj, Loopindex, i, in1, CountItem, Fo As Integer
        Dim ssqlstring, ssql, Servicecode, vCaption, vPath, str, serverdetail, Fsize(), INSERT(0) As String
        Dim Forder(), vFilepath, vOutfile, vheader, vline, sqlstring, poscode, Table, Loc As String
        Dim USERNAME, REMARKS, KOTNO As String
        Dim Filewrite As StreamWriter
        Dim vpagenumber, Vrowcount, innercount As Long
        Dim addUser As String
        gCompanyname = MyCompanyName
        Gheader = Chr(27) & Chr(106) & Chr(200) & Chr(27) & Chr(14) & Chr(27) & Chr(71) & Space(2) & Chr(15) & "KITCHEN ORDER TICKET" & Chr(20) & Chr(27) & Chr(72)
        vpagenumber = 1
        '''************************************* Create .TXT file and write text *****************************'''
        Call Randomize()
        vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
        vFilepath = AppPath & "\Reports\" & vOutfile & ".txt"
        '''**************************************** Select data from KOTDETAILS ******************************'''
        sqlstring = "SELECT ISNULL(D.KOTDETAILS,'') AS KOTDETAILS,ISNULL(D.KOTDATE,GETDATE()) AS KOTDATE,ISNULL(D.ITEMCODE,'') AS ITEMCODE,isnull(h.roomno,'') as roomno,isnull(h.guest,'') as guest,ISNULL(paymenttype,'') as paymenttype,isnull(H.servicelocation,'') as servicelocation,ISNULL(D.TABLENO,'') AS TABLENO,ISNULL(H.servicelocation,'') AS servicelocation,"
        sqlstring = sqlstring & " ISNULL(D.ITEMDESC,'') AS ITEMDESC,ISNULL(D.POSCODE,'') AS POSCODE,ISNULL(D.UOM,'') AS UOM,ISNULL(D.QTY,0) AS QTY,ISNULL(D.RATE,0) AS RATE,"
        sqlstring = sqlstring & " ISNULL(D.AMOUNT,0) AS AMOUNT,ISNULL(H.PRINTFLAG,'') PRINTFLAG,ISNULL(H.MCODE,'') AS MCODE,ISNULL(H.MNAME,'') AS MNAME,ISNULL(H.SERVERCODE,'') AS SERVERCODE,ISNULL(H.CARDHOLDERCODE,'') AS CARDHOLDERCODE,ISNULL(H.CARDHOLDERNAME,'') AS CARDHOLDERNAME,"
        sqlstring = sqlstring & " ISNULL(H.SERVERNAME,'') AS SERVERNAME,ISNULL(H.REMARKS,'') AS REMARKS, ISNULL(D.KOTSTATUS,'') AS KOTSTATUS, ISNULL(H.DELFLAG,'') AS DELFLAG,H.ADDUSERID AS USERID FROM KOT_DET AS D INNER JOIN KOT_HDR AS H ON D.KOTDETAILS = H.KOTDETAILS WHERE H.KOTDETAILS='" & Trim(Me.txt_KOTno.Text) & "' AND ISNULL(D.KOTSTATUS,'') <> 'Y' ORDER BY POSCODE"
        gconnection.getDataSet(sqlstring, "KOTHDR")
        If gdataset.Tables("KOTHDR").Rows.Count > 0 Then
            Filewrite = File.AppendText(vFilepath)
            vline = ""
            servicelocation = gdataset.Tables("KOTHDR").Rows(0).Item("servicelocation")
            poscode = gdataset.Tables("KOTHDR").Rows(0).Item("Poscode")
            addUser = gdataset.Tables("KOTHDR").Rows(0).Item("USERID")
            KOTNO = gdataset.Tables("KOTHDR").Rows(0).Item("KOTDETAILS")
            USERNAME = gdataset.Tables("KOTHDR").Rows(0).Item("USERID")
            REMARKS = gdataset.Tables("KOTHDR").Rows(0).Item("REMARKS")
            Table = gdataset.Tables("KOTHDR").Rows(0).Item("TABLENO")
            Loc = gdataset.Tables("KOTHDR").Rows(0).Item("servicelocation")
            For rowj = 0 To gdataset.Tables("KOTHDR").Rows.Count - 1
                CountItem = CountItem + 1
                With gdataset.Tables("KOTHDR").Rows(rowj)
                    If poscode <> .Item("POSCODE") Then
                        innercount = 0
                        Filewrite.WriteLine(StrDup(39, "-"))
                        Filewrite.WriteLine("{0,-5}{1,-5}", "PREPARED BY :", addUser)
                        Filewrite.WriteLine("{0,-10}{1,-20}", "REMARKS  : ", Trim(Txt_Remarks.Text))
                        poscode = .Item("POSCODE")
                        CountItem = 1
                        For i = 1 To 10
                            Filewrite.WriteLine("")
                        Next
                        vheader = Gheader

                        Filewrite.WriteLine(Chr(27) & Chr(106) & Chr(200) & Chr(27) & Chr(14) & Chr(27) & Chr(71) & Space(2) & Chr(15) & "" & Chr(20) & Chr(27) & Chr(72))
                        Filewrite.WriteLine(vheader)
                        If gdataset.Tables("KOTHDR").Rows(0).Item("DELFLAG") = "Y" Then
                            Filewrite.WriteLine(Space(10) & Chr(27) + "E" & "D E L E T E D  V O U C H E R" & Chr(27) + "F")
                        Else
                            Filewrite.WriteLine("")
                        End If
                        Filewrite.WriteLine("{0,-8}{1,-1}{2,-40}", "KOT NO", ":", Mid(Chr(14) & Chr(15) & Trim(.Item("KOTDETAILS")), 1, 40))
                        If .Item("ROOMNO") = "" Then
                            Filewrite.WriteLine("{0,-8}{1,-1}{2,-32}", Trim("MEMB NO"), ":", Mid(Chr(14) & Chr(15) & Trim(.Item("MCODE")) & " [" & Trim(.Item("MNAME")) & "]", 1, 32))
                        Else
                            Filewrite.WriteLine("{0,-8}{1,-1}{2,-32}", "ROOM NO", ":", Mid(Chr(14) & Chr(15) & Trim(.Item("ROOMNO")) & "[" & Trim(.Item("GUEST")) & "]", 1, 32))
                        End If
                        Filewrite.WriteLine("{0,-8}{1,-1}{2,-30}", "WAITER", ":", Mid(Chr(14) & Chr(15) & Trim(.Item("SERVERCODE")) & " [ " & Trim(.Item("SERVERNAME")) & " ]", 1, 30) & Chr(18))
                        Filewrite.WriteLine("{0,-8}{1,-15}{2,-3}{3,12}", "DATE    :", Mid(Trim(Format(dtp_KOTdate.Value, "dd-MMM-yyyy")), 1, 15), "TIME:", Mid(Trim(txt_KOTTime.Text), 1, 12))
                        If Trim(Table) <> "" Then
                            Filewrite.WriteLine("{0,-8}{1,-15}{2,-3}{3,10}", "TABLE   :", Table, "", "")
                        End If
                        If Trim(Loc) <> "" Then
                            Filewrite.WriteLine("{0,-8}{1,-15}{2,-3}{3,10}", "LOCATION:", Loc, "", "")
                        End If
                        Filewrite.WriteLine(StrDup(39, "-"))
                        'Filewrite.WriteLine("SLNO ITEM DESC       UOM   QTY    AMT")
                        Filewrite.WriteLine("SLNO ITEM DESC       UOM     QTY")
                        Filewrite.WriteLine(StrDup(39, "-"))
                        Filewrite.WriteLine("{0,-12}{1,-20}", "LOCATION :", Chr(14) & Chr(15) & gconnection.getvalue("SELECT ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE POSCODE='" & poscode & "'"))
                        Filewrite.WriteLine(StrDup(30, "-"))
                        'Filewrite.WriteLine("")
                        Vrowcount = 12
                        poscode = gdataset.Tables("KOTHDR").Rows(rowj).Item("Poscode")
                        addUser = gdataset.Tables("KOTHDR").Rows(rowj).Item("USERID")
                        KOTNO = gdataset.Tables("KOTHDR").Rows(rowj).Item("KOTDETAILS")
                        USERNAME = gdataset.Tables("KOTHDR").Rows(rowj).Item("USERID")
                        REMARKS = gdataset.Tables("KOTHDR").Rows(rowj).Item("REMARKS")
                    End If
                    If KOTNO <> .Item("KOTDETAILS") Then
                        For i = 1 To 12 - innercount
                            Filewrite.WriteLine()
                        Next i
                        innercount = 0
                        Filewrite.WriteLine(StrDup(39, "-"))
                        Filewrite.WriteLine("{0,-5}{1,-5}", "PREPARED BY :", addUser)
                        Filewrite.WriteLine("{0,-10}{1,-20}", "REMARKS  : ", Trim(Txt_Remarks.Text))
                        poscode = .Item("POSCODE")
                        CountItem = 1
                        For i = 1 To 10
                            Filewrite.WriteLine("")
                        Next
                        vheader = Gheader
                        Filewrite.WriteLine(vheader)
                        If gdataset.Tables("KOTHDR").Rows(0).Item("DELFLAG") = "Y" Then
                            Filewrite.WriteLine(Space(10) & Chr(27) + "E" & "D E L E T E D  V O U C H E R" & Chr(27) + "F")
                        Else
                            Filewrite.WriteLine("")
                        End If
                        Filewrite.WriteLine("{0,-8}{1,-1}{2,-40}", "KOT NO", ":", Mid(Chr(14) & Chr(15) & Trim(.Item("KOTDETAILS")), 1, 40))
                        If .Item("ROOMNO") = "" Then
                            Filewrite.WriteLine("{0,-8}{1,-1}{2,-32}", Trim("MEMB NO"), ":", Mid(Chr(14) & Chr(15) & Trim(.Item("MCODE")) & " [" & Trim(.Item("MNAME")) & "]", 1, 32))
                        Else
                            Filewrite.WriteLine("{0,-8}{1,-1}{2,-32}", "ROOM NO", ":", Mid(Chr(14) & Chr(15) & Trim(.Item("ROOMNO")) & "[" & Trim(.Item("GUEST")) & "]", 1, 32))
                        End If
                        Filewrite.WriteLine("{0,-8}{1,-1}{2,-30}", "WAITER", ":", Mid(Chr(14) & Chr(15) & Trim(.Item("SERVERCODE")) & " [ " & Trim(.Item("SERVERNAME")) & " ]", 1, 30) & Chr(18))
                        Filewrite.WriteLine("{0,-8}{1,-15}{2,-3}{3,12}", "DATE    :", Mid(Trim(Format(dtp_KOTdate.Value, "dd-MMM-yyyy")), 1, 15), "TIME:", Mid(Trim(txt_KOTTime.Text), 1, 12))
                        If Trim(Table) <> "" Then
                            Filewrite.WriteLine("{0,-8}{1,-15}{2,-3}{3,10}", "TABLE   :", Table, "", "")
                        End If
                        If Trim(Loc) <> "" Then
                            Filewrite.WriteLine("{0,-8}{1,-15}{2,-3}{3,10}", "LOCATION:", Loc, "", "")
                        End If
                        Filewrite.WriteLine(StrDup(39, "-"))
                        'Filewrite.WriteLine("SLNO ITEM DESC               UOM  QTY    AMT")
                        Filewrite.WriteLine("SLNO ITEM DESC       UOM     QTY")
                        Filewrite.WriteLine(StrDup(39, "-"))
                        Filewrite.WriteLine("{0,-12}{1,-20}", "LOCATION :", Chr(14) & Chr(15) & gconnection.getvalue("SELECT ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE POSCODE='" & poscode & "'"))
                        Filewrite.WriteLine(StrDup(30, "-"))
                        'Filewrite.WriteLine("")
                        Vrowcount = 12
                        poscode = gdataset.Tables("KOTHDR").Rows(rowj).Item("Poscode")
                        addUser = gdataset.Tables("KOTHDR").Rows(rowj).Item("USERID")
                        KOTNO = gdataset.Tables("KOTHDR").Rows(rowj).Item("KOTDETAILS")
                        USERNAME = gdataset.Tables("KOTHDR").Rows(rowj).Item("USERID")
                        REMARKS = gdataset.Tables("KOTHDR").Rows(rowj).Item("REMARKS")
                    End If
                End With
                With gdataset.Tables("KOTHDR").Rows(rowj)
                    If Vrowcount = 0 Then
                        vheader = Gheader
                        Filewrite.WriteLine("")
                        Filewrite.WriteLine("")
                        Filewrite.WriteLine(vheader)
                        If gdataset.Tables("KOTHDR").Rows(0).Item("DELFLAG") = "Y" Then
                            Filewrite.WriteLine(Space(10) & Chr(27) + "E" & "D E L E T E D  V O U C H E R" & Chr(27) + "F")
                        Else
                            If gdataset.Tables("KOTHDR").Rows(0).Item("PRINTFLAG") = "Y" Then
                                Filewrite.WriteLine("")
                                Filewrite.WriteLine(Space(6) & Chr(18) & Chr(14) & "D U P L I C A T E")
                                Filewrite.WriteLine("")
                            Else
                                Filewrite.WriteLine("")
                            End If
                        End If
                        Filewrite.WriteLine("{0,-8}{1,-1}{2,-40}", "KOT NO", ":", Mid(Chr(14) & Chr(15) & Trim(.Item("KOTDETAILS")), 1, 40))
                        If .Item("ROOMNO") = "" Then
                            Filewrite.WriteLine("{0,-8}{1,-1}{2,-32}", Trim("MEMB NO"), ":", Mid(Chr(14) & Chr(15) & Trim(.Item("MCODE")) & " [" & Trim(.Item("MNAME")) & "]", 1, 32))
                        Else
                            Filewrite.WriteLine("{0,-8}{1,-1}{2,-32}", "ROOM NO", ":", Mid(Chr(14) & Chr(15) & Trim(.Item("ROOMNO")) & "[" & Trim(.Item("GUEST")) & "]", 1, 32))
                        End If
                        Filewrite.WriteLine("{0,-8}{1,-1}{2,-30}", "WAITER", ":", Mid(Chr(14) & Chr(15) & Trim(.Item("SERVERCODE")) & " [ " & Trim(.Item("SERVERNAME")) & " ]", 1, 30) & Chr(18))
                        Filewrite.WriteLine("{0,-8}{1,-15}{2,-3}{3,12}", "DATE    :", Mid(Trim(Format(dtp_KOTdate.Value, "dd-MMM-yyyy")), 1, 15), "TIME:", Mid(Trim(txt_KOTTime.Text), 1, 12))
                        If Trim(Table) <> "" Then
                            Filewrite.WriteLine("{0,-8}{1,-15}{2,-3}{3,10}", "TABLE   :", Table, "", "")
                        End If
                        If Trim(Loc) <> "" Then
                            Filewrite.WriteLine("{0,-8}{1,-15}{2,-3}{3,10}", "LOCATION:", Loc, "", "")
                        End If
                        Filewrite.WriteLine(StrDup(39, "-"))
                        'Filewrite.WriteLine("SLNO ITEM DESC                 QTY    AMT")
                        Filewrite.WriteLine("SLNO ITEM DESC       UOM     QTY")
                        Filewrite.WriteLine(StrDup(39, "-"))
                        Filewrite.WriteLine("{0,-12}{1,-20}", "LOCATION :", Chr(14) & Chr(15) & gconnection.getvalue("SELECT ISNULL(POSDESC,'') AS POSDESC FROM POSMASTER WHERE POSCODE='" & poscode & "'"))
                        Filewrite.WriteLine(StrDup(30, "-"))
                        'Filewrite.WriteLine("")
                        Vrowcount = 12
                    End If
                End With
                With gdataset.Tables("KOTHDR").Rows(rowj)
                    'Filewrite.Write(Chr(18) & "{0,-2}{1,25}{2,4}{3,8}", Mid(CountItem, 1, 2) & "", Mid(Trim(.Item("ITEMDESC") & ""), 1, 25) & Space(25 - Len(Mid(Trim(.Item("ITEMDESC") & ""), 1, 25))), Format(Val(.Item("QTY")), "0"), Space(1) & Format(Val(.Item("AMOUNT")), "0.0"))
                    Filewrite.Write(Chr(18) & "{0,-2}{1,18}{2,8}{3,2}{4,8}", Mid(CountItem, 1, 2) & "", Mid(Trim(.Item("ITEMDESC") & ""), 1, 18) & Space(18 - Len(Mid(Trim(.Item("ITEMDESC") & ""), 1, 18))), Mid(Trim(.Item("uom") & ""), 1, 8) & Space(8 - Len(Mid(Trim(.Item("uom") & ""), 1, 8))), Format(Val(.Item("QTY")), "0"), "")
                    Filewrite.WriteLine("")
                    innercount = innercount + 1
                    Vrowcount = Vrowcount + 1
                End With
            Next rowj
            Filewrite.WriteLine("")
            'Next i
            innercount = 0
            Filewrite.WriteLine(StrDup(39, "-"))
            Filewrite.WriteLine("{0,-5}{1,-5}", "PREPARED BY :", addUser)
            Filewrite.WriteLine("{0,-10}{1,-20}", "REMARKS  : ", Trim(Txt_Remarks.Text))
            For i = 1 To 12
                Filewrite.WriteLine("")
            Next
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                INSERT(0) = "UPDATE KOT_HDR SET PRINTFLAG='Y' WHERE KOTDETAILS='" & Trim(txt_KOTno.Text) & "'"
                gconnection.MoreTransold1(INSERT)

                PrintTextFile1(vFilepath)
            End If
        End If
    End Sub

    Private Sub CMD_LOCHELP_Click(sender As Object, e As EventArgs) Handles CMD_LOCHELP.Click
        Dim vform As New LIST_OPERATION1
        If gCenterlized = "Y" Then
            gSQLString = "SELECT LOCATIONCODE,LOCATIONNAME FROM LOCATIONMASTER "
        Else
            gSQLString = "SELECT LOCATIONCODE,LOCATIONNAME FROM LOCATIONMASTER  "
        End If
        'If gCenterlized = "Y" Then
        M_WhereCondition = " WHERE ISNULL(FREEZE,'') <>'Y'"
        'Else
        'M_WhereCondition = " WHERE LOCATIONCODE IN (SELECT LOCATIONNAME FROM POS_LOCATIONCONTROL WHERE POSCODE = '" & STRPOSCODE & "') AND  ISNULL(FREEZE,'') <>'Y'"
        'End If
        vform.Field = " LOCATIONCODE,LOCATIONNAME"
        'vform.vFormatstring = "         LOCATION CODE            |                       LOCATIONNAME        |  PERCENTAGE"
        vform.vCaption = "LOCATION MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_LOCATIONCODE.Text = Trim(vform.keyfield & "")
            TXT_LOCATIONNAME.Text = Trim(vform.keyfield1 & "")
            sSGrid.Focus()
            sSGrid.SetActiveCell(1, 1)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_LOCATIONCODE_GotFocus(sender As Object, e As EventArgs) Handles txt_LOCATIONCODE.GotFocus
        Dim strstring As String
        Dim I As Integer
        If Trim(txt_LOCATIONCODE.Text) <> "" Then
            If Trim(txt_LOCATIONCODE.Text) <> "" Then
                If gCenterlized = "Y" Then
                    strstring = "SELECT LOCATIONCODE,LOCATIONNAME FROM LOCATIONMASTER  WHERE ISNULL(FREEZE,'') <>'Y' AND LOCATIONCODE = '" & Trim(txt_LOCATIONCODE.Text) & "'"
                Else
                    'strstring = "SELECT LOCATIONCODE,LOCATIONNAME FROM LOCATIONMASTER WHERE LOCATIONCODE IN (SELECT LOCATIONNAME FROM POS_LOCATIONCONTROL WHERE POSCODE = '" & STRPOSCODE & "') AND ISNULL(FREEZE,'') <>'Y'"
                    strstring = "SELECT LOCATIONCODE,LOCATIONNAME FROM LOCATIONMASTER  WHERE ISNULL(FREEZE,'') <>'Y' AND LOCATIONCODE = '" & Trim(txt_LOCATIONCODE.Text) & "' "
                End If
                gconnection.getDataSet(strstring, "LOCmaster")
                If gdataset.Tables("LOCmaster").Rows.Count > 0 Then
                    txt_LOCATIONCODE.Text = gdataset.Tables("Locmaster").Rows(0).Item("LOCATIONCODE")
                    TXT_LOCATIONNAME.Text = gdataset.Tables("Locmaster").Rows(0).Item("LOCATIONNAME")
                    sSGrid.SetActiveCell(1, 1)
                    sSGrid.Focus()
                Else
                    txt_LOCATIONCODE.Text = ""
                    TXT_LOCATIONNAME.Focus()
                End If
            Else
                txt_LOCATIONCODE.Focus()
            End If
        End If
    End Sub
    Private Sub txt_LOCATIONCODE_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_LOCATIONCODE.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Me.cmd_ServerCodeHelp.Enabled = True Then
                Call CMD_LOCHELP_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txt_LOCATIONCODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_LOCATIONCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_LOCATIONCODE.Text) <> "" Then
                txt_LOCATIONCODE_Validated(sender, e)
            Else
                Call CMD_LOCHELP_Click(CMD_LOCHELP, e)
            End If
        End If
    End Sub
    Private Sub txt_LOCATIONCODE_Validated(sender As Object, e As EventArgs) Handles txt_LOCATIONCODE.Validated
        Dim strstring As String
        Dim I As Integer
        If Trim(txt_LOCATIONCODE.Text) <> "" Then
            If Trim(txt_LOCATIONCODE.Text) <> "" Then
                If gCenterlized = "Y" Then
                    strstring = "SELECT LOCATIONCODE,LOCATIONNAME FROM LOCATIONMASTER  WHERE ISNULL(FREEZE,'') <>'Y' AND LOCATIONCODE = '" & Trim(txt_LOCATIONCODE.Text) & "' "
                Else
                    'strstring = "SELECT LOCATIONCODE,LOCATIONNAME FROM LOCATIONMASTER WHERE LOCATIONCODE IN (SELECT LOCATIONNAME FROM POS_LOCATIONCONTROL WHERE POSCODE = '" & STRPOSCODE & "') AND ISNULL(FREEZE,'') <>'Y'"
                    strstring = "SELECT LOCATIONCODE,LOCATIONNAME FROM LOCATIONMASTER  WHERE ISNULL(FREEZE,'') <>'Y' AND LOCATIONCODE = '" & Trim(txt_LOCATIONCODE.Text) & "' "
                End If
                gconnection.getDataSet(strstring, "LOCmaster")
                If gdataset.Tables("LOCmaster").Rows.Count > 0 Then
                    txt_LOCATIONCODE.Text = gdataset.Tables("Locmaster").Rows(0).Item("LOCATIONCODE")
                    TXT_LOCATIONNAME.Text = gdataset.Tables("Locmaster").Rows(0).Item("LOCATIONNAME")
                    sSGrid.SetActiveCell(1, 1)
                    sSGrid.Focus()
                Else
                    txt_LOCATIONCODE.Text = ""
                    TXT_LOCATIONNAME.Focus()
                End If
            Else
                txt_LOCATIONCODE.Focus()
            End If
        End If
    End Sub
    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        gPrint = True
        Call PrintOperation_KOT()
    End Sub
    Private Sub Cmd_Export_Click(sender As Object, e As EventArgs) Handles Cmd_Export.Click
        Dim OBJ1 As New VIEWHDR
        Dim ChildSql As String
        SQLSTRING = "SELECT KOTDETAILS,KOTDATE,MCode,Mname,CARDHOLDERCODE,CARDHOLDERNAME,ServerCode,ServerName,TotalTax,Total,BillAmount,PaymentType,ISNULL(PackAmt,0) AS SERCHARGE,ISNULL(TipsAmt,0) AS TipsAmt,ISNULL(ADCGSAMT,0) AS ADDITIONCGS,ISNULL(PARTYAMT,0) AS PARTAMT,ISNULL(ROOMAMT,0) AS ROOMAMT,ADDUSERID,CAST(CONVERT(VARCHAR,Adddatetime,106) AS DATETIME) AS ADD_DATE,UPDUSERID,CAST(CONVERT(VARCHAR,ISNULL(Upddatetime,''),106) AS DATETIME) AS UPD_DATE,ISNULL(DelFlag,'') AS VOID,ISNULL(DELUSER,'') AS VOIDUSER,CAST(CONVERT(VARCHAR,ISNULL(DELDATETIME,''),106) AS DATETIME) AS VOIDDATE FROM KOT_HDR "
        ChildSql = "SELECT KOTDETAILS,CATEGORY,GROUPCODE,ITEMTYPE,POSCODE,ITEMCODE,ITEMDESC,UOM,QTY,RATE,AMOUNT,TAXAMOUNT,PAYMENTMODE,ISNULL(PACKAMOUNT,0) AS SERCHARGE,ISNULL(TipsAmt,0) AS TipsAmt,ISNULL(ADCGSAMT,0) AS ADDITIONCGS,ISNULL(PARTYAMT,0) AS PARTAMT,ISNULL(ROOMAMT,0) AS ROOMAMT FROM KOT_DET"
        gconnection.getDataSet(SQLSTRING, "KOT_HDR")
        OBJ1.LOADGRID(gdataset.Tables("KOT_HDR"), True, "FRM_TKGA_SmartKotEntry", ChildSql, "KOTDETAILS", 1)
        OBJ1.Show()
    End Sub

    Private Sub txt_KOTno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_KOTno.TextChanged

    End Sub

    Private Sub Cmd_GolfRegNoHelp_Click(sender As Object, e As EventArgs) Handles Cmd_GolfRegNoHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT DOCNO,DOCDATE,LOCATION FROM GMS_GREENFEE_HDR "
        M_WhereCondition = " WHERE ISNULL(VOID,'') <> 'Y' AND DOCDATE = '" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "' AND LOCATION = 'GOLF COURSE' "
        vform.vCaption = "Master Help"
        vform.Field = "DOCNO,DOCDATE"
        vform.CMB_SRC_FIELDS.Select()
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_GolfRegNo.Text = Trim(vform.keyfield & "")
            Call Txt_GolfRegNo_Validated(Txt_GolfRegNo, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub Txt_GolfRegNo_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_GolfRegNo.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Cmd_GolfRegNoHelp.Enabled = True Then
                Search = Trim(Txt_GolfRegNo.Text)
                Call Cmd_GolfRegNoHelp_Click(Cmd_GolfRegNoHelp, e)
            End If
        End If
    End Sub

    Private Sub Txt_GolfRegNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_GolfRegNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_GolfRegNo.Text) <> "" Then
                Call Txt_GolfRegNo_Validated(Txt_GolfRegNo, e)
                Exit Sub
            Else
                Call Cmd_GolfRegNoHelp_Click(sender, e)
                Exit Sub
            End If
        End If
    End Sub
    Private Sub Txt_GolfRegNo_Validated(sender As Object, e As EventArgs) Handles Txt_GolfRegNo.Validated
        If Trim(Txt_GolfRegNo.Text) <> "" Then
            SQLSTRING = "SELECT * FROM GMS_GREENFEE_HDR WHERE DOCNO = '" & Trim(Txt_GolfRegNo.Text) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE = '" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "' AND LOCATION = 'GOLF COURSE' "
            gconnection.getDataSet(SQLSTRING, "RECVALUE")
            If gdataset.Tables("RECVALUE").Rows.Count > 0 Then
                Txt_GolfRegNo.Text = Trim(CStr(gdataset.Tables("RECVALUE").Rows(0).Item("DOCNO")))
                Txt_GolfRegNo.ReadOnly = True
                txt_MemberCode.Text = Trim(CStr(gdataset.Tables("RECVALUE").Rows(0).Item("MEMBERCODE")))
                txt_MemberName.Text = Trim(CStr(gdataset.Tables("RECVALUE").Rows(0).Item("MEMBERNAME")))
                txt_MemberCode.ReadOnly = True
                txt_MemberName.ReadOnly = True
                cmd_MemberCodeHelp.Enabled = False
                txt_KOTno.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_PartyBookingNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_PartyBookingNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_PartyBookingNo.Text) <> "" Then
                Call Txt_PartyBookingNo_Validated(Txt_PartyBookingNo, e)
                Exit Sub
            Else
                'Call Cmd_GolfRegNoHelp_Click(sender, e)
                'Exit Sub
                'MessageBox.Show("Party Not Available in this Date")
                'Txt_PartyBookingNo.Text = ""
            End If
        End If
    End Sub

    Private Sub Txt_PartyBookingNo_Validated(sender As Object, e As EventArgs) Handles Txt_PartyBookingNo.Validated
        If Trim(Txt_PartyBookingNo.Text) <> "" Then
            If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                SQLSTRING = "SELECT * FROM party_hallbooking_hdr WHERE  CAST(CONVERT(VARCHAR,PARTYDATE,106) AS DATETIME) = '" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "' AND BOOKINGNO = '" & Val(Txt_PartyBookingNo.Text) & "' "
                gconnection.getDataSet(SQLSTRING, "BOOKVALUE")
                If gdataset.Tables("BOOKVALUE").Rows.Count > 0 Then
                    txt_MemberCode.Text = Trim(CStr(gdataset.Tables("BOOKVALUE").Rows(0).Item("MCODE")))
                    txt_MemberName.Text = Trim(CStr(gdataset.Tables("BOOKVALUE").Rows(0).Item("ASSOCIATENAME")))
                    txt_MemberCode.ReadOnly = True
                    txt_MemberName.ReadOnly = True
                    cmd_MemberCodeHelp.Enabled = False
                    txt_MemberCode.Focus()
                Else
                    MessageBox.Show("Party Not Available in this Date")
                    Txt_PartyBookingNo.Text = ""
                End If
            Else
                Txt_PartyBookingNo.Text = ""
                txt_MemberCode.Focus()
            End If
        End If
    End Sub

    Private Sub txt_card_id_TextChanged(sender As Object, e As EventArgs) Handles txt_card_id.TextChanged

    End Sub
End Class