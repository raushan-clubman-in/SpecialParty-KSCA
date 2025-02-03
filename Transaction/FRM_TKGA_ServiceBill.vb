Imports System.Data.SqlClient
Imports System.IO
Public Class FRM_TKGA_ServiceBill
    Dim doctype, POScode, SALESACCTIN, POSUNDER As String
    Dim Amt, AMT1 As Double
    Public dblBillTotalAmount, dblBillNonTotalAmount, dblBillTaxTotal, dblBillNonTaxtotal, gridRow As Double
    Public BillTaxBillno, BillTaxBilldetails, BillNonTaxBilldetails, BillNonTaxBillno, BillMcode, BillMname, loccode As String
    Dim BillNontaxamount, BillNontotalamount, Billtaxamount, Billtotalamount As Double
    Dim dbldicountAmount, dblGrossAmount, dbldicountPack, dblGrossPack As Double
    Dim dbldicountTax, dblGrossTax, dblDicountBillAmount, Gridbillamount As Double
    Dim txt_creditfacility As String
    Dim I, J As Long
    Dim itembool, chkbool, smartcardbool As Boolean
    Dim vsearch, vitem, accountcode, Billno(), HNAME() As String
    Public KOTno, billstatus, BillDetails As String
    Dim gconnection As New GlobalClass
    Dim TotalItemCount As Integer
    Dim crstopmsg As String
    Dim strAccountIn, strSaleCostAccountIn, strSaleCostAccountInDesc, strBatchNo, strAccountDesc, STMcode As String
    Public vseqno, Jnltaxamount, Jnlamount, _Billamount As Double
    Dim dr As DataRow
    Dim ITEMCODE, servicelocation, UOMCODE As String
    Dim GrdRate, GrdAmount, GrdTaxAmt As Double

    Private Sub FRM_TKGA_ServiceBill_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Call cmd_BillSettlement_Click(cmd_BillSettlement, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F2 Then
            txt_KOTno.Text = ""
            txt_KOTno.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.F12 Then
            If SMENTTYPE = "YES" Then
                If ssGrid.DataRowCnt > 0 Then
                    SETLEMENT_GROUP.Visible = True
                    'SpiltBill()
                    SETLEMENT_GROUP.Top = 40
                    SETLEMENT_GROUP.Left = 85
                    ssgrid_settlement.SetActiveCell(1, 1)
                    ssgrid_settlement.Focus()
                End If
            End If
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
                'Call cmd_View_Click(Cmd_View, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F10 Then
            If Cmd_Print.Enabled = True Then
                'Call Cmd_Print_Click(sender, e)
                Exit Sub
            End If

        ElseIf e.KeyCode = Keys.F11 Then
            Call Cmd_Exit_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.Escape Then
            If pnl_POSCode.Top = 50 Then
                pnl_POSCode.Top = 1000
                ssGrid.SetActiveCell(3, ssGrid.ActiveRow)
                Exit Sub
            ElseIf pnl_UOMCode.Top = 50 Then
                pnl_UOMCode.Top = 1000
                ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                Exit Sub
                'ElseIf grp_Carddetails.Top = 24 Then
                '    grp_Carddetails.Top = 1000
                '    ssgridPayment.SetActiveCell(3, gridRow)
                '    ssgridPayment.Focus()
                'ElseIf grp_Chequedetails.Top = 24 Then
                '    grp_Chequedetails.Top = 1000
                '    ssgridPayment.SetActiveCell(3, gridRow)
                '    ssgridPayment.Focus()
            ElseIf grp_Paymentmodeselection.Top = 296 Then
                grp_Paymentmodeselection.Top = 1000
                'ElseIf grp_Memberfacility.Top = 128 Then
                '    grp_Memberfacility.Top = 1000
                '    'txt_MemberCode.Focus()
            Else
                Call Cmd_Exit_Click(sender, e)
                Exit Sub
            End If
        ElseIf e.Alt = True And e.KeyCode = Keys.K Then
            Me.Txt_Remarks.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.S Then
            Me.Txt_ServerCode.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.B Then
            'Me.txt_MemberCode.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.P Then
            Me.cbo_PaymentMode.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.G Then
            Me.ssGrid.Focus()
            Me.ssGrid.SetActiveCell(1, 1)
            Exit Sub
        End If
    End Sub
    Private Sub FRM_TKGA_ServiceBill_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Call FacilityValidation()
        lblUser.Visible = True
        lblUser.Text = UCase(gUsername)
        Call FillDefaultPayment()
        Call fillPayment_Mode()
        doclength = 5
        Call autogenerate()
        Call AUTO_TRANSNO()
        Call ShowBillno()
        '        Call GRIDLOCK()
        'CHK_PRINT.Checked = False
        doctypelength = Len(Trim(doctype))
        itembool = False
        pnl_UOMCode.Top = 1000
        KOT_Timer.Enabled = True
        KOT_Timer.Interval = 100
        txt_TotalValue.ReadOnly = True
        txt_TaxValue.ReadOnly = True
        Txt_Charges.ReadOnly = True
        txt_BillAmount.ReadOnly = True
        Me.cmd_BillSettlement.Enabled = True
        'cbo_Typeofcheque.SelectedIndex = 0
        grp_Paymentmodeselection.Top = 1000
        ssGrid.ClearRange(1, 1, -1, -1, True)
        Me.cmd_KOTnoHelp.Enabled = True
        Me.Cmd_Delete.Enabled = True
        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        SETLEMENT_GROUP.Visible = False
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        dtp_KOTdate.Focus()
        Call cmd_Clear_Click(sender, e)
        Show()
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
    Private Sub ShowBillno()
        Dim sqlstring, financalyear As String
        Try
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
            sqlstring = "SELECT MAX(Cast(SUBSTRING(KOTno,1,6) As Numeric)) FROM KOT_HDR WHERE DocType ='" & Trim(doctype) & "' AND TTYPE='B'"
            gconnection.openConnection()
            gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is DBNull.Value Then
                    'lbl_Status.Visible = True
                    'lbl_Status.Text = "FIRST SERVICE BILL NO "
                Else
                    'lbl_Status.Visible = True
                    'lbl_Status.Text = "LAST SERVICE BILL NO  :" & doctype & "/" & Format(Val(gdreader(0)), "000000") & "/" & financalyear
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
    Private Sub AUTO_TRANSNO()
        Dim sqlstring, financalyear As String
        financalyear = Trim(CStr(Format(dtp_KOTdate.Value, "yyyyMMdd")))
        Try
            sqlstring = "SELECT ISNULL(MAX(TRANSNO),0) FROM KOT_HDR"
            gconnection.openConnection()
            gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    LBL_TRANSNO.Text = 1
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    LBL_TRANSNO.Text = gdreader(0) + 1
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                LBL_TRANSNO.Text = 1
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub
    Private Sub autogenerate()
        Dim sqlstring, financalyear As String
        'financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
        financalyear = Trim(CStr(Format(dtp_KOTdate.Value, "yyyyMMdd")))
        Try
            sqlstring = "SELECT TOP 1 SUBSTRING(KOTDETAILS," & doclength & ",6)  FROM KOT_HDR  WHERE DocType ='" & Trim(doctype) & "' and cast(convert(char(39),kotdate,106)as datetime)='" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "' and isnull(ttype,'')='S' ORDER BY KOTDETAILS DESC"
            'sqlstring = "select isnull(count(*),0) from kot_hdr where SERVICELOCATION='" & Trim(POSUNDER) & "' and cast(convert(char(39),kotdate,106)as datetime)='" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "' and isnull(ttype,'')='S'"
            gconnection.openConnection()
            gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    'txt_KOTno.Text = doctype & "/000001/" & financalyear
                    LBL_DOCNO.Text = 1
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    'txt_KOTno.Text = doctype & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    LBL_DOCNO.Text = gdreader(0)
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                'txt_KOTno.Text = doctype & "/000001/" & financalyear
                'LBL_DOCNO.Text = gdreader(0)
                LBL_DOCNO.Text = "0"
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub
    Private Sub fillPayment_Mode()
        Dim sqlstring As String
        Dim index As Integer
        Dim i As Integer
        Try
            Call FillDefaultPayment()
            sqlstring = " SELECT PaymentCode FROM paymentmodemaster WHERE ISNULL(freeze,'')<>'Y'"
            cbo_PaymentMode.Items.Clear()
            gconnection.getDataSet(sqlstring, "paymentmodemaster")
            If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("paymentmodemaster").Rows.Count - 1
                    cbo_PaymentMode.Items.Add(gdataset.Tables("paymentmodemaster").Rows(i).Item("PaymentCode"))
                Next i
                index = cbo_PaymentMode.FindString(DefaultPayment)
                cbo_PaymentMode.SelectedIndex = index
                Call FillSubPaymentMode(DefaultPayment)
            Else
                MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillDefaultPayment()
        Dim Sqlstring As String
        Sqlstring = "SELECT ISNULL(BillPaymentMode,'') AS BillPaymentMode, ISNULL(BILLROUNDOFF,'') AS BILLROUNDOFF,ISNULL(SETTLEMENT,'') AS SETTLEMENT FROM POSSETUP"
        gconnection.getDataSet(Sqlstring, "POSSETUP")
        If gdataset.Tables("POSSETUP").Rows.Count > 0 Then
            DefaultPayment = Trim(gdataset.Tables("POSSETUP").Rows(0).Item("BillPaymentMode"))
            BILLROUNDYESNO = Trim(gdataset.Tables("POSSETUP").Rows(0).Item("BILLROUNDOFF"))
            SMENTTYPE = Trim(gdataset.Tables("POSSETUP").Rows(0).Item("SETTLEMENT"))
        Else
            DefaultPayment = "CREDIT"
        End If
    End Sub
    Private Sub FillSubPaymentMode(ByVal Paymode As String)
        Dim sql As String
        Dim i As Integer
        Dim dt As New DataTable
        sql = "SELECT ISNULL(SUBPAYSTATUS,'') AS SUBPAYSTATUS FROM PAYMENTMODEMASTER WHERE PAYMENTCODE = '" & Trim(Paymode) & "'"
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
                    dtp_KOTdate.Focus()
                    Show()
                    Me.cbo_SubPaymentMode.SelectedIndex = 0
                Else
                    cbo_SubPaymentMode.Visible = False
                    lbl_SubPaymentMode.Visible = False
                End If
            End If
        End If
    End Sub
    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        'LABDUE.Text = ""
        ssGrid.ClearRange(1, 1, -1, -1, True)
        SSGRID_MEM.ClearRange(1, 1, -1, -1, True)
        cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDownList
        Call clearform(Me)
        Call autogenerate()
        Call AUTO_TRANSNO()
        Call ShowBillno()
        '        Call GRIDLOCK()
        Call enablecontrols()
        Call fillPayment_Mode()
        '        Call FacilityValidation()
        pnl_POSCode.Top = 1000
        pnl_UOMCode.Top = 1000
        Cmd_Add.Text = "Add [F7]"
        KOT_Timer.Enabled = True
        Me.Lbl_Bill.Visible = False
        TotalItemCount = 0
        txt_TotalValue.Text = ""
        txt_TaxValue.Text = ""
        Txt_Charges.Text = ""
        txt_BillAmount.Text = ""
        txt_KOTno.ReadOnly = False
        Me.Cmd_Delete.Enabled = True
        Me.Cmd_Add.Enabled = True
        Me.lbl_SubPaymentMode.Visible = False
        Me.cbo_SubPaymentMode.Visible = False
        Me.cmd_BillSettlement.Enabled = True
        Me.cmd_KOTnoHelp.Enabled = True
        'lblCro1.Visible = False
        'lblCro.Visible = False
        SETLEMENT_GROUP.Visible = True
        ssgrid_settlement.ClearRange(1, 1, -1, -1, True)
        ssgrid_settlement.SetActiveCell(1, 1)
        SETLEMENT_GROUP.Visible = False
        TXT_ITEMCODE.Text = ""
        TXT_ITEMNAME.Text = ""
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txt_KOTno.Text = ""
        dtp_KOTdate.Focus()
        Show()
        BillNontaxamount = 0 : BillNontotalamount = 0 : Billtaxamount = 0 : Billtotalamount = 0
    End Sub
    Private Sub disablecontrols()
        txt_TableNo.ReadOnly = True
        txt_Cover.ReadOnly = True
        'txt_MemberCode.ReadOnly = True
        'txt_MemberName.ReadOnly = True
        'txt_ServerCode.ReadOnly = True
        'txt_ServerName.ReadOnly = True
        dtp_KOTdate.Enabled = False
        cbo_PaymentMode.Enabled = False
        cbo_SubPaymentMode.Enabled = False
        'cmd_MemberCodeHelp.Enabled = False
        'cmd_ServerCodeHelp.Enabled = False
        cmd_TablenoHelp.Enabled = False
    End Sub
    Private Sub enablecontrols()
        txt_TableNo.ReadOnly = False
        txt_Cover.ReadOnly = False
        'txt_MemberCode.ReadOnly = False
        'txt_MemberName.ReadOnly = False
        'txt_ServerCode.ReadOnly = False
        'txt_ServerName.ReadOnly = False
        dtp_KOTdate.Enabled = True
        cbo_PaymentMode.Enabled = True
        cbo_SubPaymentMode.Enabled = True
        'cmd_MemberCodeHelp.Enabled = True
        'cmd_ServerCodeHelp.Enabled = True
        cmd_TablenoHelp.Enabled = True
    End Sub
    Private Sub BillingUpdation()
        Dim sql, taxcode, cancel, x, y As String
        Dim i As Integer
        For i = 1 To ssGrid.DataRowCnt
            taxcode = Nothing
            cancel = Nothing
            With ssGrid
                .GetText(10, i, taxcode)
                .GetText(12, i, cancel)
                If Val(cancel) = 0 Then
                    x = Nothing
                    y = Nothing
                    If Trim(taxcode) = "" Then
                        .GetText(8, i, x)
                        BillNontaxamount = 0
                        BillNontotalamount = Val(BillNontotalamount) + Val(x)
                    Else
                        .GetText(7, i, y)
                        .GetText(8, i, x)
                        Billtaxamount = Val(Billtaxamount) + Val(y)
                        Billtotalamount = Val(Billtotalamount) + Val(x)
                    End If
                End If
            End With
        Next
    End Sub
    Private Sub cbo_SubPaymentMode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_SubPaymentMode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ssGrid.SetActiveCell(1, 1)
            ssGrid.Focus()
        End If
    End Sub
    Function bill_roundoff()
        Dim ROUNDOFF As Double
        Dim ROUND As String

        txt_BillAmount.Text = Format(Val(txt_BillAmount.Text), "0.00")
        ROUNDOFF = Format(Val(txt_BillAmount.Text), "0.00")
        ROUND = CStr(Format(Val(ROUNDOFF), "0.00"))

        If ROUND.IndexOf(".") <= 0 Then
            ROUND = ROUND.Insert(ROUND.Length - 1, ".00")
        End If
        If Val(Split(ROUND, ".")(1)) >= 36 And Val(Split(ROUND, ".")(1)) <= 75 Then
            AMT1 = 0.5
        ElseIf Val(Split(ROUND, ".")(1)) >= 0 And Val(Split(ROUND, ".")(1)) <= 35 Then
            AMT1 = 0.0
        ElseIf Val(Split(ROUND, ".")(1)) >= 76 And Val(Split(ROUND, ".")(1)) <= 99 Then
            AMT1 = 1
        End If
        Amt = Format(Val(AMT1) - (Format(Val(Split(txt_BillAmount.Text, ".")(1)), "0.00") / 100), "0.00")
    End Function
    Public Function ConvertRupees(ByVal Value As Double) As String
        Dim strText, TempString, TxtArray(5) As String
        Dim locNumber, AbsValue, DecimalValue, NumArray(5), Remain, Loopindex As Double
        NumArray(0) = 7
        NumArray(1) = 5
        NumArray(2) = 3
        NumArray(3) = 2
        TxtArray(0) = " CRORE"
        TxtArray(1) = " LAKH(S)"
        TxtArray(2) = " THOUSAND"
        TxtArray(3) = " HUNDRED"
        AbsValue = Value
        For Loopindex = 0 To 3
            locNumber = (AbsValue - (AbsValue Mod (10 ^ NumArray(Loopindex)))) / (10 ^ NumArray(Loopindex))
            If locNumber > 99 Then
                strText = strText & ConvertRupees(locNumber) & TxtArray(Loopindex)
                AbsValue = AbsValue - (locNumber * (10 ^ NumArray(Loopindex)))
            Else
                If locNumber <> 0 Then
                    If locNumber > 19 Then
                        strText = strText & NumValString(((locNumber - (locNumber Mod 10)) / 10) * 10) & NumValString(locNumber Mod 10) & TxtArray(Loopindex)
                    Else
                        strText = strText & NumValString(locNumber) & TxtArray(Loopindex)
                    End If
                    AbsValue = AbsValue - (locNumber * (10 ^ NumArray(Loopindex)))
                End If
            End If
        Next Loopindex
        If AbsValue <> 0 Then
            If AbsValue > 19 Then
                strText = strText & NumValString(((AbsValue - (AbsValue Mod 10)) / 10) * 10) & NumValString(AbsValue Mod 10) & TxtArray(Loopindex)
            Else
                strText = strText & NumValString(AbsValue)
            End If
        End If
        ConvertRupees = strText
    End Function
    Private Function NumValString(ByVal Value As Double)
        Select Case Value
            Case 1
                NumValString = " ONE"
            Case 2
                NumValString = " TWO"
            Case 3
                NumValString = " THREE"
            Case 4
                NumValString = " FOUR"
            Case 5
                NumValString = " FIVE"
            Case 6
                NumValString = " SIX"
            Case 7
                NumValString = " SEVEN"
            Case 8
                NumValString = " EIGHT"
            Case 9
                NumValString = " NINE"
            Case 10
                NumValString = " TEN"
            Case 11
                NumValString = " ELEVEN"
            Case 12
                NumValString = " TWELVE"
            Case 13
                NumValString = " THIRTEEN"
            Case 14
                NumValString = " FOURTEEN"
            Case 15
                NumValString = " FIFTEEN"
            Case 16
                NumValString = " SIXTEEN"
            Case 17
                NumValString = " SEVENTEEN"
            Case 18
                NumValString = " EIGHTEEN"
            Case 19
                NumValString = " NINETEEN"
            Case 20
                NumValString = " TWENTY"
            Case 30
                NumValString = " THIRTY"
            Case 40
                NumValString = " FOURTY"
            Case 50
                NumValString = " FIFTY"
            Case 60
                NumValString = " SIXTY"
            Case 70
                NumValString = " SEVENTY"
            Case 80
                NumValString = " EIGHTY"
            Case 90
                NumValString = " NINETY"
            Case Else
                NumValString = ""
        End Select
    End Function
    Private Sub lvw_Uom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lvw_Uom.KeyPress
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
                ssGrid.SetText(4, ssGrid.ActiveRow, uomcode)
                ssGrid.SetText(6, ssGrid.ActiveRow, uomrate)
                pnl_UOMCode.Top = 1000
                ssGrid.Focus()
                ssGrid.SetActiveCell(5, ssGrid.ActiveRow)
            End Try
        End If
    End Sub
    Private Sub lvw_POSCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lvw_POSCode.KeyPress
        Dim strSQL As String
        Dim posloc As String
        If Asc(e.KeyChar) = 13 Then
            Try
                posloc = Trim(lvw_POSCode.SelectedItems(0).SubItems(0).Text)
            Catch ex As Exception
                posloc = Trim(lvw_POSCode.Items(0).SubItems(0).Text)
            Finally
                ssGrid.SetText(3, ssGrid.ActiveRow, posloc)
                pnl_POSCode.Top = 1000
                ssGrid.Focus()
                ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
            End Try
        End If
    End Sub
    Private Sub KOT_Timer_Tick(sender As Object, e As EventArgs) Handles KOT_Timer.Tick
        txt_KOTTime.Text = Now.ToLongTimeString
    End Sub
    Private Sub GridUnLock()
        Dim i, j As Integer
        For i = 1 To 10000
            For j = 1 To 5
                ssGrid.Col = j
                ssGrid.Row = i

                ssGrid.Lock = False
            Next j
        Next i
    End Sub

    Private Sub txt_KOTno_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_KOTno.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmd_KOTnoHelp.Enabled = True Then
                Search = Trim(txt_KOTno.Text)
                Call cmd_KOTnoHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txt_KOTno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_KOTno.KeyPress
        getNumeric(e)
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_KOTno.Text) = "" Then
                Call cmd_KOTnoHelp_Click(cmd_KOTnoHelp, e)
            Else
                Call txt_KOTno_Validated(sender, e)
            End If
        End If
    End Sub

    Private Sub txt_KOTno_LostFocus(sender As Object, e As EventArgs) Handles txt_KOTno.LostFocus
        Call autogenerate()
    End Sub

    Private Sub txt_KOTno_Validated(sender As Object, e As EventArgs) Handles txt_KOTno.Validated
        Dim j, i As Integer
        Dim vString, sqlstring As String
        Dim vTypeseqno As Double
        Dim vGroupseqno As Double
        Dim dt As New DataTable
        If Trim(txt_KOTno.Text) <> "" Then
            Try
                sqlstring = "SELECT isnull(transno,0)as transno,ISNULL(PACKAMT,0) as PACKAMT,ISNULL(DISCOUNTAMT,0) as DISCOUNTAMT,ISNULL(MR_FLAG,'') AS MR_FLAG,* "
                sqlstring = sqlstring & " FROM KOT_HDR H"
                sqlstring = sqlstring & " LEFT OUTER JOIN  RECEIPT_DETAILS R"
                sqlstring = sqlstring & " ON H.KOTDETAILS=R.BILLNO  WHERE H.TRANSNO=" & Trim(txt_KOTno.Text) & " AND ISNULL(H.TTYPE,'')='S'"
                gconnection.getDataSet(sqlstring, "KOT_HDR")

                If gdataset.Tables("KOT_HDR").Rows.Count > 0 Then
                    '                    Call GridUnLock()
                    Cmd_Add.Text = "Update[F7]"
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
                                Me.Lbl_Bill.Text = "BILL GENERATED"
                            Else
                                If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("CroStatus")) = "N" Then
                                    Me.Lbl_Bill.Text = "BILL GENERATED"
                                Else
                                    Me.Lbl_Bill.Text = "MRP/CRO GENERATED"
                                    'lblCro.Visible = True
                                    'lblCro1.Visible = True
                                    'Me.lblCro.Text = Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("CroNO"))
                                    ' Call disablecontrols()
                                    '                                    Call CROGRIDLOCK()
                                End If
                            End If
                        Else
                            Me.Lbl_Bill.Visible = True
                            Me.Lbl_Bill.Text = "BILL GENERATED"
                        End If
                    Else
                        Me.Lbl_Bill.Visible = True
                        Me.Lbl_Bill.Text = "BILL GENERATED"
                    End If
                    If Trim(gdataset.Tables("Kot_Hdr").Rows(0).Item("DELFLAG")) = "Y" Then
                        Me.Lbl_Bill.Text = "BILL DELETED"
                        ' Call disablecontrols()
                        '                        Call CROGRIDLOCK()
                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Delete.Enabled = False
                        Me.cmd_BillSettlement.Enabled = False
                    End If
                    KOT_Timer.Enabled = False
                    dtp_KOTdate.Value = Format(CDate(gdataset.Tables("KOT_HDR").Rows(0).Item("KOTDATE")), "dd-MMM-yy")
                    txt_KOTTime.Text = Format(gdataset.Tables("KOT_HDR").Rows(0).Item("KOTDATE"), "hh:mm:ss")
                    txt_KOTno.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("TRANSNO") & "")
                    'Txt_BookNo.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("BOOKNO") & "")
                    'TXT_CHITNO.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("CHITNO") & "")
                    txt_TableNo.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("tableno") & "")
                    Txt_Pos.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("SERVICELOCATION") & "")

                    sqlstring = " SELECT ISNULL(B.Poscode,'') AS UNDER,ISNULL(B.Poscode,'') AS POSCODE,ISNULL(B.POSCODE,'') AS DOCTYPE,ISNULL(B.Posdesc,'') AS POSDESC,0 AS PACKINGPERCENT,'' AS SALESACCTIN FROM POSMASTER B "
                    sqlstring = sqlstring & "WHERE POSCODE = '" & Trim(Txt_Pos.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "POSUNDER")
                    If gdataset.Tables("POSUNDER").Rows.Count > 0 Then
                        POSUNDER = Trim(gdataset.Tables("POSUNDER").Rows(0).Item("UNDER") & "")
                    End If

                    txt_Cover.Text = Val(gdataset.Tables("KOT_HDR").Rows(0).Item("Covers"))
                    Txt_ServerCode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("ServerCode") & "")
                    Txt_ServerName.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("ServerName") & "")
                    txt_TotalValue.Text = Format(Val(gdataset.Tables("KOT_HDR").Rows(0).Item("Total")), "0.00")
                    txt_TaxValue.Text = Format(Val(gdataset.Tables("KOT_HDR").Rows(0).Item("TotalTax")), "0.00")
                    Txt_Charges.Text = Format(Val(gdataset.Tables("KOT_HDR").Rows(0).Item("PackAmt")), "0.00")
                    txt_Discount.Text = Format(Val(gdataset.Tables("KOT_HDR").Rows(0).Item("DiscountAmt")), "0")
                    txt_BillAmount.Text = Format(Val(gdataset.Tables("KOT_HDR").Rows(0).Item("BillAmount")), "0.00")
                    cbo_PaymentMode.DropDownStyle = ComboBoxStyle.DropDown
                    cbo_PaymentMode.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("PaymentType") & "")
                    Txt_Remarks.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("Remarks") & "")
                    LBL_TRANSNO.Text = Trim(gdataset.Tables("KOT_HDR").Rows(0).Item("TRANSNO") & "")
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
                       
                    Else
                        Try
                            sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                            sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                            gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                            If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                                If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) = "NO" Then
                                   
                                Else
                                    If cbo_PaymentMode.Text <> "STAFF" Then
                                        
                                    End If

                                End If
                            Else
                                MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            End If
                        Catch ex As Exception
                            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End Try
                    End If
                    '''************************************************* SELECT record from KOT_DET *********************************************''''                
                    sqlstring = "SELECT ISNULL(SALESACCOUNTCODE,0) AS SALESACCOUNTCODE,ISNULL(TAXACCOUNTCODE,0) AS TAXACCOUNTCODE,ISNULL(GROUPCODE,0) AS GROUPCODE,ISNULL(PACKPERCENT,0) AS PACKPERCENT,"
                    sqlstring = sqlstring & " ISNULL(PACKAMOUNT,0) AS PACKAMOUNT,ISNULL(OPENFACILITYST,0) AS OPENFACILITYST,ISNULL(PROMOTIONALST,0) AS PROMOTIONALST,ISNULL(PACKACCOUNTCODE,'') AS PACKACCOUNTCODE,* FROM KOT_DET WHERE  TRANSNO=" & Trim(LBL_TRANSNO.Text) & " AND ISNULL(TTYPE,'')='S' ORDER BY AUTOID "
                    gconnection.getDataSet(sqlstring, "KOT_DET")
                    Dim ITEM, mcode As String
                    ITEM = ""
                    If gdataset.Tables("KOT_DET").Rows.Count > 0 Then
                        TXT_ITEMCODE.Text = Trim(gdataset.Tables("KOT_DET").Rows(0).Item("itemCode"))
                        TXT_ITEMNAME.Text = Trim(gdataset.Tables("KOT_DET").Rows(0).Item("itemdesc"))
                        For i = 1 To gdataset.Tables("KOT_DET").Rows.Count
                            ssGrid.SetText(1, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("MCode")) & "")
                            sqlstring = "SELECT ISNULL(MNAME,'')AS MNAME FROM MEMBERMASTER WHERE MCODE='" & Trim(gdataset.Tables("KOT_DET").Rows(j).Item("MCode")) & "' "
                            gconnection.getDataSet(sqlstring, "MEM")
                            If gdataset.Tables("MEM").Rows.Count > 0 Then
                                ssGrid.SetText(2, i, Trim(gdataset.Tables("MEM").Rows(0).Item("MNAME")))
                            End If
                            ssGrid.SetText(25, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("BOOKNO")))


                            ssGrid.SetText(23, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("itemcode")) & "")
                            ssGrid.SetText(24, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("itemdesc")) & "")
                            ssGrid.SetText(3, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("poscode")))
                            ssGrid.SetText(4, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("UOM")))
                            ssGrid.SetText(5, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("Qty")))
                            ssGrid.SetText(6, i, Format(Val(gdataset.Tables("KOT_DET").Rows(j).Item("Rate")), "0.00"))
                            ssGrid.SetText(7, i, Format(Val(gdataset.Tables("KOT_DET").Rows(j).Item("Taxamount")), "0.00"))
                            ssGrid.SetText(8, i, Format(Val(gdataset.Tables("KOT_DET").Rows(j).Item("Amount")), "0.00"))
                            ssGrid.SetText(9, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("ItemType")) & "")
                            ssGrid.SetText(10, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("TaxCode")) & "")
                            ssGrid.SetText(11, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("TaxPerc")))
                            ssGrid.SetText(13, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("TaxAccountCode")))
                            ssGrid.SetText(14, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("SalesAccountCode")))
                            ssGrid.SetText(15, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("GroupCode")))
                            ssGrid.SetText(16, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("Autoid")))
                            ssGrid.SetText(17, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("PackPercent")))
                            ssGrid.SetText(18, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("PackAmount")))
                            ssGrid.SetText(19, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("Openfacilityst")))
                            ssGrid.SetText(20, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("Promotionalst")))
                            ssGrid.SetText(21, i, Trim(gdataset.Tables("KOT_DET").Rows(j).Item("Packaccountcode")))
                            ssGrid.SetText(26, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("TipsPer")))
                            ssGrid.SetText(27, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("TipsAmt")))
                            ssGrid.SetText(28, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("AdCgsPer")))
                            ssGrid.SetText(29, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("AdCgsAmt")))
                            ssGrid.SetText(30, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("PartyPer")))
                            ssGrid.SetText(31, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("PartyAmt")))
                            ssGrid.SetText(32, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("RoomPer")))
                            ssGrid.SetText(33, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("RoomAmt")))
                            'REFERINVENTORY***********************************************************************
                            ssGrid.SetText(22, i, Val(gdataset.Tables("KOT_DET").Rows(j).Item("Qty")))
                            '*************************************************************************************
                            If CStr(gdataset.Tables("KOT_DET").Rows(j).Item("KOTStatus") & "") = "Y" Then
                                ssGrid.SetText(12, i, "Yes")
                            Else
                                ssGrid.SetText(12, i, "No")
                            End If
                            ITEM = Trim(gdataset.Tables("KOT_DET").Rows(j).Item("ItemCode"))
                            j = j + 1
                        Next
                    End If
                    '''************************************************* SELECT record from BILLSETTLEMENT  *********************************************''''                
                    sqlstring = "SELECT ISNULL(BILLNO,'') AS BILLNO,BILLDATE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(PAYMENTACCOUNTCODE,'') AS PAYMENTACCOUNTCODE,"
                    sqlstring = sqlstring & " ISNULL(MCODE,'') AS MCODE,ISNULL(MNAME,'') AS MNAME,ISNULL(CARDTYPE,'') AS CARDTYPE,ISNULL(INSTRUMENTNO,'') AS INSTRUMENTNO,INSTRUMENTDATE,"
                    sqlstring = sqlstring & " ISNULL(BANKNAME,'') AS BANKNAME,ISNULL(RECEIVEDNAME,'') AS RECEIVEDANAME,ISNULL(PAYAMOUNT,0) AS PAYAMOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                    sqlstring = sqlstring & " ISNULL(BALANCEAMOUNT,0) AS BALANCEAMOUNT  FROM BILLSETTLEMENT WHERE BILLNO = '" & Trim(txt_KOTno.Text) & "' ORDER BY PAYMENTMODE"
                    gconnection.getDataSet(sqlstring, "BILLSETTLEMENT")
                    If gdataset.Tables("BILLSETTLEMENT").Rows.Count > 0 Then
                        j = 0
                        For i = 1 To gdataset.Tables("BILLSETTLEMENT").Rows.Count
                            ssgridPayment.SetText(1, i, Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("BILLNO")) & "")
                            ssgridPayment.SetText(2, i, Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("BILLDATE")) & "")
                            Call FillPaymentmodeSettlement(i)
                            ssgridPayment.SetText(3, i, Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("PAYMENTMODE")))
                            ssgridPayment.SetText(5, i, Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("MCODE")))
                            ssgridPayment.SetText(6, i, Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("MNAME")))
                            ssgridPayment.SetText(4, i, Format(Val(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("PAYAMOUNT")), "0.00"))
                            ssgridPayment.SetText(7, i, Format(Val(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("BILLAMOUNT")), "0.00"))
                            ssgridPayment.SetText(8, i, Format(Val(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("BALANCEAMOUNT")), "0.00"))
                            ssgridPayment.Col = 3
                            ssgridPayment.Row = i
                            sqlstring = " SELECT ISNULL(ACCOUNTIN,'') AS ACCOUNTIN,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE,ISNULL(PAYMENTTYPE,'') AS PAYMENTTYPE  FROM paymentmodemaster WHERE Paymentcode = '" & Trim(ssgridPayment.Text) & "' AND ISNULL(Freeze,'')='N'"
                            gconnection.getDataSet(sqlstring, "paymentmodemaster")
                            If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                                If Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CD" Then
                                    'txt_Typeofcard.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("CARDTYPE"))
                                    'txt_Cardno.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("INSTRUMENTNO"))
                                    'dtp_Expirydate.Value = Format(CDate(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("INSTRUMENTDATE")), "dd-MMM-yyyy")
                                    'txt_Cardholdername.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("PAYMENTMODE"))
                                ElseIf Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CQ" Then
                                    'cbo_Typeofcheque.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("CARDTYPE"))
                                    'txt_Chequeno.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("INSTRUMENTNO"))
                                    'dtp_Chequedate.Value = Format(CDate(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("INSTRUMENTDATE")), "dd-MMM-yyyy")
                                    'txt_Draweebank.Text = Trim(gdataset.Tables("BILLSETTLEMENT").Rows(j).Item("BANKNAME"))
                                End If
                            End If
                            j = j + 1
                        Next
                    Else
                        ssgridPayment.ClearRange(1, 1, -1, -1, True)
                    End If
                    TotalItemCount = gdataset.Tables("KOT_DET").Rows.Count
                    Call Fillsettlement()
                    ssGrid.SetActiveCell(1, 1)
                    dtp_KOTdate.Focus()
                    Show()
                    cmd_KOTnoHelp.Enabled = False
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                Else
                    ''Call cmd_Clear_Click(cmd_Clear, e)
                End If
                bill_closing()
            Catch ex As Exception
                'MessageBox.Show("Enter valid Bill No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                'txt_KOTno.Text = ""
                'txt_KOTno.Focus()
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub bill_closing()
        Dim ssql As String
        ssql = "select isnull(accountflag,'')  as Aflag from bill_hdr where billdetails='" & txt_KOTno.Text & "'"
        gconnection.getDataSet(ssql, "Bill")
        If gdataset.Tables("Bill").Rows.Count > 0 Then
            If Trim(gdataset.Tables("Bill").Rows(0).Item("Aflag")) = "Y" Then
                Cmd_Add.Enabled = False
                cmd_Delete.Enabled = False
                cmd_Delete.Enabled = False
                cmd_BillSettlement.Enabled = False
            End If
        End If
    End Sub
    Public Sub FillPaymentmodeSettlement(ByVal i As Integer)
        Dim sqlstring As String
        Dim j As Integer
        Try
            ssgridPayment.TypeComboBoxClear(3, i)
            sqlstring = "SELECT Paymentcode FROM paymentmodemaster WHERE  Paymentcode <> 'ROOM' AND Isnull(Freeze,'')='N'"
            gconnection.getDataSet(sqlstring, "paymentmodemaster")
            If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                For j = 0 To gdataset.Tables("paymentmodemaster").Rows.Count - 1
                    ssgridPayment.Col = 3
                    ssgridPayment.Row = i
                    ssgridPayment.TypeComboBoxString = Trim(gdataset.Tables("paymentmodemaster").Rows(j).Item("Paymentcode"))
                    ssgridPayment.Text = Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("Paymentcode"))
                Next j
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Function Fillsettlement()
        Dim sqlstring, Subpaymentmode() As String
        Dim Billtotal As Double
        kotdetails = ""
        Dim i, j As Integer
        Try
            sqlstring = " SELECT ISNULL(MCODE,'') AS MCODE,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(BILLDETAILS,'') AS BILLDETAILS,ISNULL(DESCRIPTION,'') AS DESCRIPTION "
            sqlstring = sqlstring & " FROM SETTLEMENT WHERE BILLDETAILS='" & Trim(txt_KOTno.Text) & "' --AND ISNULL(DELETEFLAG,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "SETTLE")
            If gdataset.Tables("SETTLE").Rows.Count > 0 Then
                With ssgrid_settlement
                    ssgrid_settlement.ClearRange(1, 1, -1, -1, True)
                    ssgrid_settlement.SetActiveCell(1, 1)
                    For i = 0 To gdataset.Tables("SETTLE").Rows.Count - 1
                        .Row = i + 1
                        .Col = 1
                        .Text = gdataset.Tables("SETTLE").Rows(i).Item("MCODE")
                        .Col = 2
                        .Text = Format(Val(gdataset.Tables("SETTLE").Rows(i).Item("AMOUNT")), "0.00")
                        .Col = 3
                        .Text = gdataset.Tables("SETTLE").Rows(i).Item("DESCRIPTION")
                    Next
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Private Sub CROGRIDLOCK()
        Dim Row, Col As Integer
        ssGrid.Col = 15
        ssGrid.Row = ssGrid.ActiveRow
        For Row = 1 To 10000
            For Col = 1 To 15
                ssGrid.Row = Row
                ssGrid.Col = Col
                ssGrid.Lock = True
            Next
        Next Row
    End Sub
    Private Sub checkvalidate()
        Dim icode, icode1, uom, uom1, Fstart, Fend As String
        Dim taxcode, sqlstring, itemdesc As String
        Dim i, j As Integer
        chkbool = False
        ''***************************************** Assign Account Code Value **********************************************'''
        If SMENTTYPE = "YES" Then
            If SETLEMENT_GROUP.Visible = True Then
                MessageBox.Show("Please Close the Settlement Screen.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssgrid_settlement.Focus()
                Exit Sub
            End If
        End If

        If cbo_PaymentMode.SelectedItem = "ROOM" Then
            accountcode = "RMLDGR"
        ElseIf cbo_PaymentMode.SelectedItem = "CREDIT" Then
            accountcode = Trim(gDebitors)
        Else
            accountcode = ""
        End If
        '''**************************************** Check Chitno can't be blank *******************************************'''
        'If Trim(TXT_CHITNO.Text) = "" Then
        '    MessageBox.Show("Chit No. Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    TXT_CHITNO.Focus()
        '    Exit Sub
        'End If
        '''**************************************** Check Payment Mode can't be blank *******************************************''
        Fstart = "01-APR-" & Trim(gFinancalyearStart)
        Fend = "31-MAR-" & Trim(gFinancialYearEnd)
        If DateDiff(DateInterval.Day, Me.dtp_KOTdate.Value, Now) < 0 Then
            Me.dtp_KOTdate.Focus()
            MessageBox.Show("Billdate can't be greater then today's date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If (Format(Me.dtp_KOTdate.Value, "dd-MMM-yyyy") > Format(Fstart, "dd-MMM-yyyy")) And (Format(Me.dtp_KOTdate.Value, "dd-MMM-yyyy") < Format(Fend, "dd-MMM-yyyy")) Then
            Me.dtp_KOTdate.Focus()
            MessageBox.Show("Voucher Date Should Be Within The Financial Year", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Trim(cbo_PaymentMode.Text) = "" Then
            MessageBox.Show("Payment Mode Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            cbo_PaymentMode.Focus()
            Exit Sub
        End If
        
        '''********************************************* Check ssgrid value can't be blank ********************************************'''
        If ssGrid.DataRowCnt = 0 Then
            MessageBox.Show("!! Sorry !!There is no KOT DETAILS part to be saved", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            ssGrid.Focus()
            ssGrid.SetActiveCell(1, 1)
            Exit Sub
        End If
        With ssGrid
            For i = 1 To .DataRowCnt
                If i = 1 Then
                    .Col = 3
                    .Row = i
                    loccode = Trim(.Text)
                End If
                .Col = 19
                .Row = i
                If Trim(.Text) <> "Y" Then
                    .Row = i
                    .Col = 23
                    ITEMCODE = Trim(CStr(ssGrid.Text))
                    .Row = i
                    .Col = 24
                    itemdesc = Trim(CStr(ssGrid.Text))
                    sqlstring = "SELECT ITEMCODE,ITEMDESC FROM ITEMMASTER WHERE Itemcode = '" & Trim(ITEMCODE) & "' AND Itemdesc = '" & Trim(itemdesc) & "'"
                    gconnection.getDataSet(sqlstring, "ITEMMASTER")
                    If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                        .Row = i
                        .Col = 23
                        ssGrid.Text = Trim(CStr(gdataset.Tables("ITEMMASTER").Rows(0).Item("ITEMCODE")))
                        .Row = i
                        .Col = 24
                        ssGrid.Text = Trim(CStr(gdataset.Tables("ITEMMASTER").Rows(0).Item("ITEMDESC")))
                    Else
                        MessageBox.Show("!!Warning!! Itemcode : " & Trim(ITEMCODE) & " And Itemdesc : " & Trim(itemdesc) & " is not valid ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ssGrid.Focus()
                        ssGrid.SetActiveCell(1, i)
                        Exit Sub
                    End If
                End If
                .Col = 25
                .Row = i

            Next
        End With
        For i = 1 To ssGrid.DataRowCnt
            ssGrid.Row = i
            ssGrid.Col = 1
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("Member Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(1, i)
                ssGrid.Focus()
                Exit Sub
            End If
            ssGrid.Col = 2
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("Mname can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(2, i)
                ssGrid.Focus()
                Exit Sub
            End If
            ssGrid.Col = 3
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("POS Location can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(3, i)
                ssGrid.Focus()
                Exit Sub
            End If
            ssGrid.Col = 4
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(4, i)
                ssGrid.Focus()
                Exit Sub
            End If
            ssGrid.Col = 23
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("Item Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(3, i)
                ssGrid.Focus()
                Exit Sub
            End If
            ssGrid.Col = 24
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("Item Desc can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(4, i)
                ssGrid.Focus()
                Exit Sub
            End If
            ssGrid.Col = 25
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("Chit can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(4, i)
                ssGrid.Focus()
                Exit Sub
            End If
            ssGrid.Col = 5
            If Val(ssGrid.Text) = 0 Then
                MessageBox.Show("Quantity can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(5, i)
                ssGrid.Focus()
                Exit Sub
            End If
            ssGrid.Col = 6
            If Val(ssGrid.Text) = 0 Then
                ssGrid.Col = 20
                ssGrid.Row = i - 1
                If POScode <> 24 Then
                    If Trim(ssGrid.Text) <> "Y" Then
                        MessageBox.Show("Rate can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ssGrid.SetActiveCell(6, i)
                        ssGrid.Focus()
                        Exit Sub
                    Else
                        ssGrid.Col = 1
                        ssGrid.Row = i
                        If Mid(Trim(ssGrid.Text), Len(Trim(ssGrid.Text)), 1) <> "A" Then
                            MessageBox.Show("Rate can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            ssGrid.SetActiveCell(6, i)
                            ssGrid.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            End If
            ssGrid.Col = 8
            If Val(ssGrid.Text) = 0 Then
                ssGrid.Col = 20
                ssGrid.Row = i - 1
                If POScode <> 24 Then
                    If Trim(ssGrid.Text) <> "Y" Then
                        MessageBox.Show("Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ssGrid.SetActiveCell(8, i)
                        ssGrid.Focus()
                        Exit Sub
                    Else
                        ssGrid.Col = 1
                        ssGrid.Row = i
                        If Mid(Trim(ssGrid.Text), Len(Trim(ssGrid.Text)), 1) <> "A" Then
                            MessageBox.Show("Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            ssGrid.SetActiveCell(8, i)
                            ssGrid.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            End If
            ssGrid.Col = 9
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("Item Type can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(9, i)
                ssGrid.Focus()
                Exit Sub
            End If
            ssGrid.Col = 14
            If Trim(ssGrid.Text) = "" Then
                MessageBox.Show("Sales Account can't blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ssGrid.SetActiveCell(11, i)
                ssGrid.Focus()
                Exit Sub
            End If
        Next i
        If Cmd_Add.Text = "Update[F7]" And Me.Lbl_Bill.Text = "CRO GENERATED" Then
            If Me.ssGrid.DataRowCnt > TotalItemCount Then
                MessageBox.Show("Specified Billno has been deposited in CRO Counter", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        chkbool = True
    End Sub
    Private Sub mfsreport(ByVal MEMCODE As String)
        Randomize()
        Dim vOutfile, vheader, vFilepath, vline, Kot, Bill, amtword, paymentmode, rupeesword As String
        Dim ssql, sql1, sql2, vCaption, vPath, str, Sqlstring, billdetails, Fsize(), Forder(), Round, Roundedvalue() As String
        Dim RoundOff, RoundDiff, TotalAmount, TaxAmount, Taxpercentage, RoundOff1 As Double
        Dim Loopindex, i, Fo, in1, CountItem, rowj As Integer
        Dim Vrowcount, vpagenumber As Long
        Dim TOTALQTY As Double = 0
        Dim Filewrite As StreamWriter
        gCompanyname = MyCompanyName
        gCompanyAddress(0) = Address1
        gCompanyAddress(1) = Address2
        Gheader = " N O T I C E"
        Dim PSTR As String
        Dim C As Integer

        vOutfile = Mid("Not" & (Rnd() * 800000), 1, 8)
        vFilepath = AppPath & "\Reports\" & vOutfile & ".txt"
        gPrint = False

        Filewrite = File.AppendText(vFilepath)

        vheader = Chr(18) & Chr(14) & Chr(15) & gCompanyname & Chr(18)
        Filewrite.WriteLine(vheader)
        vheader = Chr(18) & Chr(14) & Chr(15) & "NOTICE" & Chr(18)
        Filewrite.WriteLine(vheader)
        Filewrite.WriteLine("")
        Sqlstring = "select b.* from mfs_app_hdr a,mfs_app_det b,itemmaster c where b.itemcode=c.itemcode and substring(isnull(c.category,''),1,1)='F' AND a.mcode='" & Trim(MEMCODE) & "' AND b.ITEMCODE='" & Trim(ITEMCODE) & "' AND a.appno=b.appno and a.todate>='" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "'"
        gconnection.getDataSet(Sqlstring, "MFSVALID")
        C = 1
        If gdataset.Tables("MFSVALID").Rows.Count > 0 Then
            For Each dr In gdataset.Tables("MFSVALID").Rows
                PSTR = Space(4 - Len(Mid(Format(C, "0"), 1, 4))) & Mid(Format(C, "0"), 1, 4) & "." & Space(1) & Mid(Trim(CStr(dr("ITEMCODE"))), 1, 10) & Space(10 - Len(Mid(Trim(CStr(dr("ITEMCODE"))), 1, 10))) & Space(1) & Mid(Trim(CStr(dr("ITEMDESC"))), 1, 40) & Space(40 - Len(Mid(Trim(CStr(dr("ITEMDESC"))), 1, 40)))
                PSTR = PSTR & Space(1) & Mid(Trim(CStr(dr("DEPCODE"))), 1, 10) & Space(10 - Len(Mid(Trim(CStr(dr("DEPCODE"))), 1, 10))) & Space(1) & Mid(Trim(CStr(dr("DEPNAME"))), 1, 40) & Space(40 - Len(Mid(Trim(CStr(dr("DEPNAME"))), 1, 40)))
                Filewrite.WriteLine(PSTR)
                C = C + 1
            Next
        End If

        Filewrite.WriteLine("")
        Filewrite.WriteLine("")
        Filewrite.WriteLine("")
        Filewrite.WriteLine("")
        Filewrite.WriteLine("THE SPORTS CARD PACKAGE IS TAKEN BY THE MEMBER ON THIS ITEM")
        Filewrite.Close()
        If gPrint = False Then
            OpenTextFile(vOutfile)
        Else
            PrintTextFile1(vFilepath)
        End If
    End Sub
    Private Sub fillmember()
        Dim MEMCODE As String
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ISNULL(A.MNAME,'') AS MNAME,ISNULL(A.MCODE,'') AS MCODE FROM Membermaster A"
        M_WhereCondition = " WHERE A.CURENTSTATUS IN ('LIVE','ACTIVE')"
        vform.Field = "A.MNAME,A.MCODE"
        'vform.vFormatstring = "                  MEMBER NAME             |         MCODE          "
        vform.vCaption = "MEMBER MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssGrid
                .Col = 1
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield1 & "")
                MEMCODE = Trim(vform.keyfield1 & "")
                .Col = 2
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield & "")
                .Col = 25
                .Row = .ActiveRow
                .Text = ""
                .Text = .ActiveRow ' + Val(LBL_DOCNO.Text)
                .SetActiveCell(1, .ActiveRow)
                .Focus()
            End With
        Else
            ssGrid.Col = 1
            MEMCODE = ssGrid.Text
            gSQLString = "SELECT ISNULL(A.MNAME,'') AS MNAME,ISNULL(A.MCODE,'') AS MCODE FROM Membermaster A"
            gSQLString = gSQLString & " WHERE A.CURENTSTATUS IN ('LIVE','ACTIVE') AND A.MCODE='" & Trim(MEMCODE) & "'"
            gconnection.getDataSet(gSQLString, "MEMBERVALIDATE")
            If gdataset.Tables("MEMBERVALIDATE").Rows.Count <= 0 Then
                ssGrid.SetActiveCell(1, ssGrid.ActiveRow)
                ssGrid.Focus()
                Exit Sub
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub ssGrid_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssGrid.KeyDownEvent
        Dim Sqlstring, Itemdesc, Promtcode As String
        Dim varitemcode, varitemdesc, varposcode, varuom As String
        Dim varitemrate As Double
        Dim i, j, k, bookno, chitno As Integer
        Dim memcode As String
        Dim strstring As String
        Dim SSQL As String
        Dim CLIMIT, PLIMIT As Double
        Try
            If e.keyCode = Keys.Enter Then
                i = ssGrid.ActiveRow
                If ssGrid.ActiveCol = 1 Or ssGrid.ActiveCol = 2 Then
                    ssGrid.Col = 1
                    ssGrid.Row = i
                    memcode = Trim(ssGrid.Text)
                    'ssGrid.Col = 2
                    'varitemdesc = Trim(ssGrid.Text)
                    'ssGrid.Col = 3
                    'varposcode = Trim(ssGrid.Text)
                    'ssGrid.Col = 1
                    'ITEMCODE = Trim(ssGrid.Text)
                    If ssGrid.Lock = False Then
                        If Trim(ssGrid.Text) = "" Then
                            Call fillmember()
                        ElseIf Trim(ssGrid.Text) <> "" Then
                            'NEW
                            'Sqlstring = "select b.* from mfs_app_hdr a,mfs_app_det b,itemmaster c where b.itemcode=c.itemcode and substring(isnull(c.category,''),1,1)='F' AND a.mcode='" & Trim(memcode) & "' AND b.ITEMCODE='" & Trim(ITEMCODE) & "' AND a.appno=b.appno and a.todate>='" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "'"
                            'gconnection.getDataSet(Sqlstring, "MFSVALID")
                            'If gdataset.Tables("MFSVALID").Rows.Count > 0 Then
                            '    Call mfsreport(memcode)
                            'End If

                            'END


                            gSQLString = "SELECT ISNULL(A.MNAME,'') AS MNAME,ISNULL(A.MCODE,'') AS MCODE FROM Membermaster A"
                            gSQLString = gSQLString & " WHERE ISNULL(A.CURENTSTATUS,'')IN ('LIVE','INACTIVE','ACTIVE') AND A.MCODE='" & Trim(memcode) & "'"
                            gconnection.getDataSet(gSQLString, "MEMBERVALIDATE")
                            If gdataset.Tables("MEMBERVALIDATE").Rows.Count > 0 Then
                                ssGrid.SetText(2, ssGrid.ActiveRow, gdataset.Tables("MEMBERVALIDATE").Rows(0).Item("MNAME"))
                            Else
                                MessageBox.Show("Specified MEMBER CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssGrid.ClearRange(1, i, 25, i, True)
                                ssGrid.SetActiveCell(0, i)
                                ssGrid.Lock = False
                                ssGrid.Focus()
                                Exit Sub
                            End If


                            If Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                                'ssGrid.ClearRange(1, ssGrid.ActiveRow, 15, ssGrid.ActiveRow, True)
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''


                                'Sqlstring = "SELECT ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(PL.POS,'') AS POS,ISNULL(TL.TAXCODE,'') AS TAXCODE,ISNULL(TL.TAXPERCENTAGE,0) AS TAXPERCENTAGE,"
                                'Sqlstring = Sqlstring & " ISNULL(TL.ACCOUNTCODE,'') AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL ,ISNULL(I.PROMITEMCODE,'') AS PROMITEMCODE, ISNULL(P.SALESACCTIN,'') AS SALESACCTIN,"
                                'Sqlstring = Sqlstring & " ISNULL(P.PACKINGPERCENT,0) AS PACKINGPERCENT, ISNULL(OPENFACILITY,'') AS OPENFACILITY,ISNULL(P.PACKINGACCTIN,'') AS PACKINGACCTIN "
                                'Sqlstring = Sqlstring & " FROM ITEMMASTER AS I INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
                                'Sqlstring = Sqlstring & " INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE  "
                                'Sqlstring = Sqlstring & " WHERE I.ITEMCODE = '" & Trim(TXT_ITEMCODE.Text) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'  AND PL.POS='" & Trim(POSUNDER) & "'"

                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,ISNULL(PL.POS,'') AS POS,"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                If gCenterlized = "Y" Then
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink ) and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                Else
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(StrPOSCODE) & "' "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(StrPOSCODE) & "') and I.ITEMCODE = '" & Trim(TXT_ITEMCODE.Text) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                End If

                                gconnection.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then

                                    ssGrid.SetText(23, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")))
                                    ssGrid.SetText(24, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")))
                                    ssGrid.SetText(3, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("POS")))
                                    ssGrid.SetText(9, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")))
                                    ssGrid.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")))
                                    ssGrid.SetText(11, i, Val(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    ssGrid.SetText(13, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    ssGrid.SetText(14, i, Trim(""))
                                    ssGrid.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    ssGrid.SetText(17, i, Trim(0))
                                    ssGrid.SetText(19, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    ssGrid.SetText(20, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PROMOTIONAL")))
                                    'ssGrid.SetText(21, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PACKINGACCTIN")))
                                    ssGrid.SetText(25, i, i)
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        ssGrid.Col = 5
                                        ssGrid.Row = i
                                        ssGrid.Text = 1
                                        ssGrid.Col = 6
                                        ssGrid.Row = i
                                        ssGrid.Lock = False
                                        ssGrid.SetActiveCell(5, i)
                                        ssGrid.Focus()
                                    Else
                                        ssGrid.SetActiveCell(4, i)
                                        ssGrid.Focus()
                                    End If
                                    '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                    Sqlstring = "SELECT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE FROM ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                    Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(ITEMCODE) & "' ) ORDER BY R.UOM"
                                    gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                    If gdataset.Tables("ITEMRATE").Rows.Count > 0 Then
                                        If gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                                            ssGrid.Col = 4
                                            Call FillUomList(gdataset.Tables("ITEMRATE"))
                                            Me.lvw_Uom.FullRowSelect = True
                                            pnl_UOMCode.Top = 50
                                            Me.lvw_Uom.Focus()
                                        Else
                                            ssGrid.SetText(4, i, CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")))
                                            ssGrid.SetText(6, i, Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")))
                                        End If
                                        ssGrid.Col = 19
                                        ssGrid.Row = i
                                        If Trim(ssGrid.Text) = "Y" Then
                                            ssGrid.Col = 5
                                            ssGrid.Row = i
                                            ssGrid.Text = 1
                                            ssGrid.Col = 6
                                            ssGrid.Row = i
                                            ssGrid.Lock = False
                                            ssGrid.SetActiveCell(5, i)
                                            ssGrid.Focus()
                                        Else
                                            If pnl_UOMCode.Top = 50 Then
                                                Me.lvw_Uom.FullRowSelect = True
                                                Me.lvw_Uom.Focus()
                                            Else
                                                ssGrid.SetActiveCell(4, i)
                                                ssGrid.Focus()
                                            End If
                                        End If
                                    Else
                                        ssGrid.Col = 6
                                        ssGrid.Text = "0.00"
                                        ssGrid.Col = 4
                                        ssGrid.Col = 19
                                        ssGrid.Row = i
                                        If Trim(ssGrid.Text) = "Y" Then
                                            ssGrid.Col = 5
                                            ssGrid.Row = i
                                            ssGrid.Text = 1
                                            ssGrid.Col = 6
                                            ssGrid.Row = i
                                            ssGrid.Lock = False
                                            ssGrid.SetActiveCell(5, i)
                                            ssGrid.Focus()
                                        Else
                                            ssGrid.SetActiveCell(4, i)
                                            ssGrid.Focus()
                                        End If
                                    End If
                                    '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                Else
                                    MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    ssGrid.ClearRange(1, i, 25, i, True)
                                    ssGrid.SetActiveCell(0, i)
                                    ssGrid.Lock = False
                                    ssGrid.Focus()
                                    Exit Sub
                                End If
                            End If
                            '' Call FillMenu() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                            ''Call FillMenuItem() ''' IT WILL SHOW A POPUP MENU FOR ITEM DESC
                        ElseIf Trim(ssGrid.Text) <> "" Then
                            ssGrid.Col = 1
                            ssGrid.Row = i

                            ''***********************MEMBER VALIDATION********************************
                            If cbo_PaymentMode.Text = "ROOM" Then
                                strstring = "Select roomno,guest,docno From roomcheckin Where isnull(checkout,'') <> 'Y' and roomstatus='occupied' AND RoomNo='" & Trim(memcode) & "'"
                                gconnection.getDataSet(strstring, "RoomCheckin")
                                If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                                    ssGrid.Col = 1
                                    ssGrid.Row = i
                                    ssGrid.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("RoomNo")
                                    ssGrid.Col = 2
                                    ssGrid.Row = i
                                    ssGrid.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("Guest")
                                    ssGrid.Col = 25
                                    ssGrid.Row = i
                                    If Trim(ssGrid.Text) = "" Then
                                        ssGrid.Text = ""
                                        ssGrid.Text = Val(i)   '+ Val(LBL_DOCNO.Text)
                                        ssGrid.SetActiveCell(0, i + 1)
                                        ssGrid.Focus()
                                    End If
                                Else
                                    ssGrid.ClearRange(1, i, 25, i, True)
                                    ssGrid.DeleteRows(i, 1)
                                    ssGrid.SetActiveCell(0, i)
                                    ssGrid.Focus()
                                    Exit Sub
                                End If
                            ElseIf cbo_PaymentMode.Text = "CLUB" Then
                                strstring = "SELECT slcode,slname FROM accountssubledgermaster WHERE SLCODE='" & Trim(memcode) & "'"
                                gconnection.getDataSet(strstring, "RoomCheckin")
                                If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                                    ssGrid.Col = 1
                                    ssGrid.Row = i
                                    ssGrid.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("slcode")
                                    ssGrid.Col = 2
                                    ssGrid.Row = i
                                    ssGrid.Text = gdataset.Tables("RoomCheckin").Rows(0).Item("slname")
                                    ssGrid.Col = 25
                                    If Trim(ssGrid.Text) = "" Then
                                        ssGrid.Text = ""
                                        ssGrid.Text = Val(i) + Val(LBL_DOCNO.Text)
                                        ssGrid.SetActiveCell(0, i + 1)
                                        ssGrid.Focus()
                                    End If
                                Else
                                    ssGrid.ClearRange(1, i, 3, i, True)
                                    ssGrid.DeleteRows(i, 1)
                                    ssGrid.SetActiveCell(0, i)
                                    ssGrid.Focus()
                                End If
                            Else
                                strstring = "SELECT isnull(A.mcode,'') as mcode,isnull(A.mname,'') as mname,isnull(curentstatus,'') as termination FROM membermaster A WHERE A.MCODE='" & Trim(memcode) & "'"
                                gconnection.getDataSet(strstring, "membermaster")
                                If gdataset.Tables("membermaster").Rows.Count > 0 Then
                                    Dim name
                                    name = gdataset.Tables("membermaster").Rows(0).Item("TERMINATION")
                                    '                                    gDebtors = gdataset.Tables("membermaster").Rows(0).Item("MEMBERSLCODE")
                                    '                                   gDebitors = gdataset.Tables("membermaster").Rows(0).Item("MEMBERSLCODE")
                                    Select Case Trim(name)
                                        Case "LIVE"
                                            Txt_Remarks.Text = ""
                                            ssGrid.Col = 1
                                            ssGrid.Row = i
                                            ssGrid.Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                                            ssGrid.Col = 2
                                            ssGrid.Row = i
                                            ssGrid.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                                            ssGrid.Col = 25
                                            '                                            If Trim(ssGrid.Text) = "" Then
                                            ssGrid.Text = ""
                                            ssGrid.Text = Val(i) ' + Val(LBL_DOCNO.Text) - 1
                                            '                                          ssGrid.SetActiveCell(0, i + 1)
                                            ssGrid.Focus()
                                            '                                           End If

                                        Case "ACTIVE"
                                            Txt_Remarks.Text = ""
                                            ssGrid.Col = 1
                                            ssGrid.Row = i
                                            ssGrid.Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                                            ssGrid.Col = 2
                                            ssGrid.Row = i
                                            ssGrid.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                                            ssGrid.Col = 25
                                            '                                            If Trim(ssGrid.Text) = "" Then
                                            ssGrid.Text = ""
                                            ssGrid.Text = Val(i) ' + Val(LBL_DOCNO.Text) - 1
                                            '                                          ssGrid.SetActiveCell(0, i + 1)
                                            ssGrid.Focus()
                                            '                                           End If

                                        Case Else
                                            ssGrid.Col = 1
                                            ssGrid.Row = i
                                            ssGrid.Text = "MEMBERSHIP " & name & "."
                                            ssGrid.Col = 2
                                            ssGrid.Row = i
                                            ssGrid.Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                                    End Select

                                    If memcode = "XX" Or memcode = "MM" Or memcode = "ZZ" Then
                                    Else
                                        If Trim(Txt_Remarks.Text) = "" Then
                                            'Dim prvbal, curbal, present, rcd, clsbal, asonbal As Double
                                            'Sqlstring = "exec cp_creditlimit '" & Format(dtp_KOTdate.Value, "dd MMM yyyy") & "','" & Trim(gDebtors) & "','" & Trim(memcode) & "'"
                                            'gconnection.getDataSet(Sqlstring, "CP_CREDIT")
                                            'Sqlstring = "select ISNULL(PLIMIT,0) AS PLIMIT,ISNULL(CLIMIT,0) AS CLIMIT,ISNULL(SUM(ISNULL(CDR,0)),0)-ISNULL(SUM(ISNULL(CCR,0)),0) AS CAMOUNT,ISNULL(SUM(ISNULL(PDR,0)),0)-ISNULL(SUM(ISNULL(PCR,0)),0) AS PAMOUNT from CREDITSTOP_MCODE WHERE MCODE='" & Trim(memcode) & "' GROUP BY PLIMIT,CLIMIT"
                                            'gconnection.getDataSet(Sqlstring, "CP_CRLIMIT")
                                            'If gdataset.Tables("CP_CRLIMIT").Rows.Count > 0 Then
                                            '    curbal = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("CAMOUNT")
                                            '    prvbal = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("PAMOUNT")
                                            '    CLIMIT = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("CLIMIT")
                                            '    PLIMIT = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("PLIMIT")
                                            'Else
                                            '    curbal = 0
                                            '    prvbal = 0
                                            '    CLIMIT = 0
                                            '    PLIMIT = 0
                                            'End If

                                            'prvbal = 0

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
                                            'If Trim(cbo_PaymentMode.Text) = "CREDIT" Or Trim(cbo_PaymentMode.Text) = "CASH" Then
                                            '    If curbal > CLIMIT Or prvbal > PLIMIT Then
                                            '        MsgBox("Member is in Credit Stop List...  " & LABDUE.Text, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Credit Limit Exceed")
                                            '        crstopmsg = "Member is in Credit Stop List... "
                                            '        strstring = "select * from membermaster where isnull(creditstopdate,'')<'" & Format(dtp_KOTdate.Value, "yyyy-MMM-dd") & "' and isnull(creditstopflag,'N') ='Y' and mcode='" & Trim(memcode) & "'"
                                            '        gconnection.getDataSet(strstring, "membermast")
                                            '        If gdataset.Tables("membermast").Rows.Count > 0 Then
                                            '            MsgBox("This is the Second Time, Sorry Not Allowed....")
                                            '        Else
                                            '            'Call BillPrintOperation_notice(curbal, CLIMIT, prvbal, PLIMIT)
                                            '            Sqlstring = "update membermaster set creditstopflag ='Y',creditstopdate='" & Format(dtp_KOTdate.Value, "yyyy-MM-dd") & "' where mcode='" & Trim(memcode) & "'"
                                            '            gconnection.getDataSet(Sqlstring, "membermast")
                                            '        End If
                                            '    Else
                                            '        crstopmsg = ""
                                            '        Sqlstring = "update membermaster set creditstopflag ='N',creditstopdate='" & Format(dtp_KOTdate.Value, "yyyy-MM-dd") & "' where mcode='" & Trim(memcode) & "'"
                                            '        gconnection.getDataSet(Sqlstring, "membermast")
                                            '    End If
                                            '    Txt_Remarks.Text = LABDUE.Text

                                            '    SSQL = "DELETE FROM CREDITSTOP_MCODE WHERE MCODE='" & Trim(memcode) & "'"
                                            '    gcommand = New SqlClient.SqlCommand(SSQL, gconnection.Myconn)
                                            '    gconnection.openConnection()
                                            '    gcommand.ExecuteNonQuery()
                                            '    gconnection.closeConnection()
                                            'Else
                                            '    crstopmsg = ""
                                            'End If
                                            'Txt_Remarks.Text = LABDUE.Text    '"L-Credit: " & Format(pcredit, "0.00") & "  L-Debit: " & Format(pdebit, "0.00") & "  L-Closing: " & Format(pclbal, "0.00") & "  C-Credit: " & Format(ccredit, "0.00") & "  C-Debit: " & Format(cdebit, "0.00") & "  C-Closing: " & Format(cclbal, "0.00")
                                        End If
                                    End If
                                Else
                                    ssGrid.ClearRange(1, i, 25, i, True)
                                    ssGrid.DeleteRows(i, 1)
                                    ssGrid.SetActiveCell(0, i)
                                    ssGrid.Focus()
                                    Exit Sub
                                End If
                            End If
                            ''***************************MEMBER VALIDATION ENDS********************************

                            If Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                                'ssGrid.ClearRange(1, ssGrid.ActiveRow, 15, ssGrid.ActiveRow, True)
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''

                                'Sqlstring = "SELECT ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(PL.POS,'') AS POS,ISNULL(TL.TAXCODE,'') AS TAXCODE,ISNULL(TL.TAXPERCENTAGE,0) AS TAXPERCENTAGE,"
                                'Sqlstring = Sqlstring & " ISNULL(TL.ACCOUNTCODE,'') AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL ,ISNULL(I.PROMITEMCODE,'') AS PROMITEMCODE, ISNULL(P.SALESACCTIN,'') AS SALESACCTIN,"
                                'Sqlstring = Sqlstring & " ISNULL(P.PACKINGPERCENT,0) AS PACKINGPERCENT, ISNULL(OPENFACILITY,'') AS OPENFACILITY,ISNULL(P.PACKINGACCTIN,'') AS PACKINGACCTIN "
                                'Sqlstring = Sqlstring & " FROM ITEMMASTER AS I INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
                                'Sqlstring = Sqlstring & " INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE  "
                                'Sqlstring = Sqlstring & " WHERE I.ITEMCODE = '" & Trim(TXT_ITEMCODE.Text) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'  AND PL.POS='" & Trim(POSUNDER) & "'"
                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,ISNULL(PL.POS,'') AS POS"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                If gCenterlized = "Y" Then
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink ) and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                Else
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(StrPOSCODE) & "' "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(StrPOSCODE) & "') and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                End If
                                gconnection.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                    ssGrid.SetText(23, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")))
                                    ssGrid.SetText(24, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")))
                                    ssGrid.SetText(3, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("POS")))
                                    ssGrid.SetText(9, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")))
                                    ssGrid.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")))
                                    ssGrid.SetText(11, i, Val(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    ssGrid.SetText(13, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    ssGrid.SetText(14, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("SALESACCTIN")))
                                    ssGrid.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    ssGrid.SetText(17, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PACKINGPERCENT")))
                                    ssGrid.SetText(19, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    ssGrid.SetText(20, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PROMOTIONAL")))
                                    'ssGrid.SetText(21, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PACKINGACCTIN")))
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        ssGrid.Col = 5
                                        ssGrid.Row = i
                                        ssGrid.Text = 1
                                        ssGrid.Col = 6
                                        ssGrid.Row = i
                                        ssGrid.Lock = False
                                        ssGrid.SetActiveCell(5, ssGrid.ActiveRow)
                                        ssGrid.Focus()
                                    Else
                                        ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                                        ssGrid.Focus()
                                    End If
                                    '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                    Sqlstring = "SELECT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE FROM ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                    Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(TXT_ITEMCODE.Text) & "' ) ORDER BY R.UOM"
                                    gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                    If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                        'ssGrid.Col = 4
                                        'ssGrid.Row = i
                                        ssGrid.SetText(4, i, CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")))
                                        'ssGrid.Col = 6
                                        'ssGrid.Row = ssGrid.ActiveRow
                                        ssGrid.SetText(6, i, Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")))
                                        ssGrid.Col = 19
                                        ssGrid.Row = i
                                        If Trim(ssGrid.Text) = "Y" Then
                                            ssGrid.Col = 5
                                            ssGrid.Row = i
                                            ssGrid.Text = 1
                                            ssGrid.Col = 6
                                            ssGrid.Row = i
                                            ssGrid.Lock = False
                                            ssGrid.SetActiveCell(5, i)
                                            ssGrid.Focus()
                                        Else
                                            ssGrid.SetActiveCell(4, i)
                                            ssGrid.Focus()
                                        End If
                                    Else
                                        ssGrid.Col = 6
                                        ssGrid.Text = "0.00"
                                        ssGrid.Col = 4
                                        ssGrid.Col = 19
                                        ssGrid.Row = i
                                        If Trim(ssGrid.Text) = "Y" Then
                                            ssGrid.Col = 5
                                            ssGrid.Row = i
                                            ssGrid.Text = 1
                                            ssGrid.Col = 6
                                            ssGrid.Row = i
                                            ssGrid.Lock = False
                                            ssGrid.SetActiveCell(5, i)
                                            ssGrid.Focus()
                                        Else
                                            ssGrid.SetActiveCell(4, i)
                                            ssGrid.Focus()
                                        End If
                                    End If
                                    '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                Else
                                    MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    ssGrid.ClearRange(1, ssGrid.ActiveRow, 15, ssGrid.ActiveRow, True)
                                    ssGrid.SetActiveCell(0, ssGrid.ActiveRow)
                                    ssGrid.Lock = False
                                    ssGrid.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                ElseIf ssGrid.ActiveCol = 2 Then

                ElseIf ssGrid.ActiveCol = 3 Then
                    ssGrid.Row = ssGrid.ActiveRow
                    ssGrid.Row = ssGrid.ActiveRow
                    ssGrid.Col = 1
                    varitemcode = Trim(ssGrid.Text)
                    ssGrid.Col = 2
                    varitemdesc = Trim(ssGrid.Text)
                    ssGrid.Col = 3
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" Then
                        ssGrid.SetActiveCell(3, ssGrid.ActiveRow)
                        Exit Sub
                    Else
                        ssGrid.Col = 1
                        varitemcode = Trim(ssGrid.Text)
                        ssGrid.Col = 3
                        varposcode = Trim(ssGrid.Text)
                        If Trim(varposcode) = "" Then
                            ssGrid.Text = ""
                            ssGrid.SetActiveCell(3, ssGrid.ActiveRow)
                            ssGrid.Focus()
                        ElseIf Trim(varposcode) <> "" Then
                            ssGrid.SetActiveCell(3, ssGrid.ActiveRow)
                        End If
                    End If
                ElseIf ssGrid.ActiveCol = 4 Then
                    ssGrid.Row = ssGrid.ActiveRow
                    ssGrid.Row = ssGrid.ActiveRow
                    ssGrid.Col = 1
                    varitemcode = Trim(ssGrid.Text)
                    ssGrid.Col = 2
                    varitemdesc = Trim(ssGrid.Text)
                    ssGrid.Col = 3
                    varposcode = Trim(ssGrid.Text)
                    ssGrid.Col = 4
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                        ssGrid.SetActiveCell(3, ssGrid.ActiveRow)
                        Exit Sub
                    Else
                        If ssGrid.Lock = False Then
                            ssGrid.Col = 23
                            varitemcode = Trim(ssGrid.Text)
                            ssGrid.Col = 3
                            varposcode = Trim(ssGrid.Text)
                            ssGrid.Col = 6
                            varitemrate = Val(ssGrid.Text)
                            ssGrid.Col = 4
                            If Trim(ssGrid.Text) = "" Then
                                '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                Sqlstring = "SELECT DISTINCT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE FROM ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(varitemcode) & "' ) ORDER BY R.UOM"
                                gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                    ssGrid.Col = 4
                                    ssGrid.Row = ssGrid.ActiveRow
                                    ssGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM"))
                                    ssGrid.Col = 19
                                    ssGrid.Row = ssGrid.ActiveRow
                                    If Trim(ssGrid.Text) = "Y" Then
                                        ssGrid.Col = 6
                                        ssGrid.Row = i
                                        ssGrid.Lock = False
                                        ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                                    Else
                                        ssGrid.Col = 6
                                        ssGrid.Row = ssGrid.ActiveRow
                                        ssGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                        ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                                    End If
                                ElseIf gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                                    ssGrid.Col = 4
                                    Call FillUomList(gdataset.Tables("ITEMRATE"))
                                    Me.lvw_Uom.FullRowSelect = True
                                    pnl_UOMCode.Top = 50
                                    Me.lvw_Uom.Focus()
                                Else
                                    ssGrid.Col = 1
                                    ssGrid.Row = ssGrid.ActiveRow
                                    If Trim(ssGrid.Text) <> "" Then
                                        ssGrid.Col = 4
                                        ssGrid.Text = ""
                                        ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                                    End If
                                End If
                                '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                            ElseIf Trim(ssGrid.Text) <> "" Then
                                Sqlstring = "SELECT DISTINCT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE FROM ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(varitemcode) & "' ) AND R.ITEMRATE = " & Val(varitemrate) & " ORDER BY R.UOM"
                                gconnection.getDataSet(Sqlstring, "RATEMASTER")
                                If gdataset.Tables("RATEMASTER").Rows.Count > 0 Then
                                    If gdataset.Tables("RATEMASTER").Rows.Count = 1 Then
                                        ssGrid.Col = 4
                                        ssGrid.Row = ssGrid.ActiveRow
                                        ssGrid.Text = CStr(gdataset.Tables("RATEMASTER").Rows(0).Item("UOM"))
                                        ssGrid.Col = 19
                                        ssGrid.Row = ssGrid.ActiveRow
                                        If Trim(ssGrid.Text) = "Y" Then
                                            ssGrid.Col = 6
                                            ssGrid.Row = i
                                            ssGrid.Lock = False
                                            ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                                        Else
                                            ssGrid.Col = 6
                                            ssGrid.Row = ssGrid.ActiveRow
                                            ssGrid.Text = Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE"))
                                            ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                                        End If
                                    Else
                                        ssGrid.Col = 4
                                        ssGrid.Col = 6
                                        ssGrid.Text = "0.00"
                                    End If
                                Else
                                    MessageBox.Show("!! Oop's specified ITEM UOM is not valid ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    ssGrid.Col = 4
                                    ssGrid.Row = ssGrid.ActiveRow
                                    ssGrid.Text = ""
                                    ssGrid.SetActiveCell(3, ssGrid.ActiveRow)
                                End If
                            End If
                        End If
                    End If
                ElseIf ssGrid.ActiveCol = 5 Then
                    ssGrid.Row = ssGrid.ActiveRow
                    ssGrid.Col = 1
                    varitemcode = Trim(ssGrid.Text)
                    ssGrid.Col = 2
                    varitemdesc = Trim(ssGrid.Text)
                    ssGrid.Col = 3
                    varposcode = Trim(ssGrid.Text)
                    ssGrid.Col = 5
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                        ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                        Exit Sub
                    Else
                        If ssGrid.Lock = False Then
                            ssGrid.Col = 1
                            ssGrid.Row = ssGrid.ActiveRow
                            If Trim(ssGrid.Text) <> "" Then
                                ssGrid.Col = 5
                                ssGrid.Row = ssGrid.ActiveRow
                                If Val(ssGrid.Text) = 0 Then
                                    ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                                    Exit Sub
                                Else
                                    ssGrid.Col = 19
                                    ssGrid.Row = ssGrid.ActiveRow
                                    If Trim(ssGrid.Text) = "Y" Then
                                        ssGrid.Col = 6
                                        ssGrid.Lock = False
                                        ssGrid.SetActiveCell(5, ssGrid.ActiveRow)
                                        Exit Sub
                                    Else
                                        '''REFERINVENTORY****************************CHECKING FOR THE STOCK AVAILABILITY*******************
                                        Dim CHECK_AVAILABILITY As Integer
                                        CHECK_AVAILABILITY = STOCKAVAILABILITY(ssGrid, i)
                                        If CHECK_AVAILABILITY = 0 Then
                                            ssGrid.ClearRange(1, i, ssGrid.MaxCols, i, True)
                                            ssGrid.Focus()
                                            ssGrid.SetActiveCell(0, i)
                                            Exit Sub
                                        ElseIf CHECK_AVAILABILITY = 1 Then
                                            ssGrid.Col = 4
                                            ssGrid.Text = ""
                                            ssGrid.SetActiveCell(4, i)
                                            ssGrid.Focus()
                                            Exit Sub
                                        End If
                                        '''************************************************************************************************
                                        Call Calculate()
                                        ssGrid.Col = 20
                                        ssGrid.Row = ssGrid.ActiveRow
                                        If Trim(ssGrid.Text) = "Y" Then
                                            '''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                            Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PROMITEMCODE"))
                                            Sqlstring = " SELECT ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,ISNULL(I.PROMITEMCODE,'') AS PROMITEMCODE,ISNULL(I.PROMUOM,'') AS PROMUOM,"
                                            Sqlstring = Sqlstring & " ISNULL(I.PROMQTY,0) AS PROMQTY,ISNULL(I.PROMRATE,0) AS PROMRATE FROM ITEMMASTER AS I WHERE I.ITEMCODE= '" & Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "'AND ISNULL(I.FREEZE,'') <>'Y' "
                                            gconnection.getDataSet(Sqlstring, "ITEMMASTER")
                                            If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                                                Promtcode = Trim(gdataset.Tables("ITEMMASTER").Rows(j).Item("PROMITEMCODE"))
                                                Sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS PROMITEMCODE,ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(I.ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(P.POSCODE,'') AS POSCODE,"
                                                Sqlstring = Sqlstring & " I.STARTINGDATE,I.ENDINGDATE,ISNULL(TL.TAXCODE,'') AS TAXCODE,ISNULL(TL.TAXPERCENTAGE,0) AS TAXPERCENTAGE,ISNULL(TL.ACCOUNTCODE,'') AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,"
                                                Sqlstring = Sqlstring & "  ISNULL(P.SALESACCTIN,'')  AS SALESACCTIN FROM ITEMMASTER AS I INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE"
                                                Sqlstring = Sqlstring & " INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE   WHERE  '13-Apr-2007' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Promtcode) & "') AND ISNULL(I.FREEZE,'') <>'Y' AND PL.POS='" & Trim(POSUNDER) & "'"
                                                gconnection.getDataSet(Sqlstring, "PROMOTIONAL")
                                                If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                                    k = MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                                                    If k = 1 Then
                                                        ssGrid.Row = ssGrid.ActiveRow + 1
                                                        ssGrid.Col = 1
                                                        ssGrid.Lock = False
                                                        ssGrid.Col = 2
                                                        ssGrid.Lock = False
                                                        ssGrid.Col = 3
                                                        ssGrid.Lock = False
                                                        ssGrid.Col = 4
                                                        ssGrid.Lock = False
                                                        ssGrid.Col = 5
                                                        ssGrid.Lock = False
                                                        ssGrid.SetText(1, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")))
                                                        ssGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")))
                                                        ssGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")))
                                                        ssGrid.SetText(4, i + 1, Trim(gdataset.Tables("ITEMMASTER").Rows(j).Item("PROMUOM")))
                                                        ssGrid.SetText(5, i + 1, Val(gdataset.Tables("ITEMMASTER").Rows(j).Item("PROMQTY")))
                                                        ssGrid.SetText(6, i + 1, 0.0)
                                                        ssGrid.SetText(7, i + 1, 0.0)
                                                        ssGrid.SetText(8, i + 1, 0.0)
                                                        ssGrid.SetText(9, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")))
                                                        ssGrid.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("TAXCODE")))
                                                        ssGrid.SetText(11, i + 1, Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("TAXPERCENTAGE")))
                                                        ssGrid.SetText(13, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ACCOUNTCODE")))
                                                        ssGrid.SetText(14, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("SALESACCTIN")))
                                                        ssGrid.SetText(15, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("GROUPCODE")))
                                                        ssGrid.SetText(17, i + 1, 0)
                                                        ssGrid.SetText(18, i + 1, 0)
                                                        ssGrid.SetText(19, i + 1, "N")
                                                        ssGrid.SetText(20, i + 1, "N")
                                                        ssGrid.SetActiveCell(4, i + 1)
                                                        ssGrid.Focus()
                                                    Else
                                                        ssGrid.SetActiveCell(1, i + 1)
                                                        ssGrid.Focus()
                                                    End If
                                                End If
                                            Else
                                                ssGrid.Row = ssGrid.ActiveRow + 1
                                                ssGrid.Col = 1
                                                ssGrid.Lock = False
                                                ssGrid.Col = 2
                                                ssGrid.Lock = False
                                                ssGrid.Col = 3
                                                ssGrid.Lock = False
                                                ssGrid.Col = 4
                                                ssGrid.Lock = False
                                                ssGrid.Col = 5
                                                ssGrid.Lock = False
                                                ssGrid.SetActiveCell(1, ssGrid.ActiveRow + 1)
                                            End If
                                            '''*************************** $ COMPLETE PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                        Else
                                            ssGrid.Row = ssGrid.ActiveRow + 1
                                            ssGrid.Col = 1
                                            ssGrid.Lock = False
                                            ssGrid.Col = 2
                                            ssGrid.Lock = False
                                            ssGrid.Col = 3
                                            ssGrid.Lock = False
                                            ssGrid.Col = 4
                                            ssGrid.Lock = False
                                            ssGrid.Col = 5
                                            ssGrid.Lock = False
                                            ssGrid.SetActiveCell(1, ssGrid.ActiveRow + 1)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf ssGrid.ActiveCol = 6 Then
                    ssGrid.Col = 6
                    ssGrid.Row = ssGrid.ActiveRow
                    If ssGrid.Lock = False Then
                        ssGrid.Col = 1
                        ssGrid.Row = ssGrid.ActiveRow
                        If Trim(ssGrid.Text) <> "" Then
                            ssGrid.Col = 6
                            ssGrid.Row = ssGrid.ActiveRow
                            If Val(ssGrid.Text) = 0 Then
                                ssGrid.SetActiveCell(5, ssGrid.ActiveRow)
                                Exit Sub
                            Else
                                Call RateCalculate()
                                ssGrid.Row = ssGrid.ActiveRow + 1
                                ssGrid.Col = 1
                                ssGrid.Lock = False
                                ssGrid.Col = 2
                                ssGrid.Lock = False
                                ssGrid.Col = 3
                                ssGrid.Lock = False
                                ssGrid.Col = 4
                                ssGrid.Lock = False
                                ssGrid.Col = 5
                                ssGrid.Lock = False
                                ssGrid.SetActiveCell(0, ssGrid.ActiveRow + 1)
                            End If
                        End If
                    End If
                ElseIf ssGrid.ActiveCol = 12 Then
                    ssGrid.Col = 12
                    ssGrid.Row = ssGrid.ActiveRow
                    If Val(ssGrid.Text) = 0 Then
                        Call Calculate()
                        ssGrid.SetActiveCell(0, ssGrid.ActiveRow + 1)
                        Exit Sub
                    Else
                        Call Calculate()
                        ssGrid.SetActiveCell(0, ssGrid.ActiveRow + 1)
                        Exit Sub
                    End If
                End If
            ElseIf e.keyCode = Keys.F4 Then
                If ssGrid.ActiveCol = 1 Then
                    ssGrid.Col = 1
                    ssGrid.Row = ssGrid.ActiveRow
                    If ssGrid.Lock = False Then
                        ssGrid.Col = 1
                        ssGrid.Row = ssGrid.ActiveRow
                        Search = Trim(ssGrid.Text)
                        'Call FillMenu()
                        Call FillMenuItem() ''' IT WILL SHOW A POPUP MENU FOR ITEM DESC
                    End If
                ElseIf ssGrid.ActiveCol = 2 Then
                    ssGrid.Col = 2
                    ssGrid.Row = ssGrid.ActiveRow
                    If ssGrid.Lock = False Then
                        ssGrid.Col = 2
                        ssGrid.Row = ssGrid.ActiveRow
                        Search = Trim(ssGrid.Text)
                        Call FillMenuItem()
                    End If
                End If
            ElseIf e.keyCode = Keys.F12 Then
                ssGrid.Col = 3
                ssGrid.Row = ssGrid.ActiveRow
                If ssGrid.ActiveCol = 4 Then
                    ssGrid.Col = 4
                    ssGrid.Row = ssGrid.ActiveRow

                    If ssGrid.Lock = False Then
                        ITEMCODE = Nothing
                        i = ssGrid.ActiveRow
                        ssGrid.Col = 1
                        ssGrid.Row = i
                        ITEMCODE = Trim(ssGrid.Text)
                        Sqlstring = "SELECT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE FROM ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(ITEMCODE) & "' ) ORDER BY R.UOM"
                        gconnection.getDataSet(Sqlstring, "ITEMRATE")
                        If gdataset.Tables("ITEMRATE").Rows.Count > 0 Then
                            If gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                                ssGrid.Col = 4
                                ssGrid.Row = i
                                Call FillUomList(gdataset.Tables("ITEMRATE"))
                                Me.lvw_Uom.FullRowSelect = True
                                pnl_UOMCode.Top = 50
                                pnl_UOMCode.Focus()
                                Me.lvw_Uom.Focus()
                            Else
                                ssGrid.Col = 4
                                ssGrid.Row = ssGrid.ActiveRow
                                ssGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")
                                ssGrid.Col = 6
                                ssGrid.Row = ssGrid.ActiveRow
                                ssGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")
                                ssGrid.SetActiveCell(5, ssGrid.ActiveRow)
                            End If
                        Else
                            ssGrid.Col = 1
                            ssGrid.Row = ssGrid.ActiveRow
                            ssGrid.Focus()
                        End If
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                ssGrid.Row = ssGrid.ActiveRow
                ssGrid.ClearRange(1, ssGrid.ActiveRow, 15, ssGrid.ActiveRow, True)
                ssGrid.DeleteRows(ssGrid.ActiveRow, 1)
                Call Calculate()
                ssGrid.Row = ssGrid.ActiveRow
                ssGrid.Col = 1
                ssGrid.Lock = False
                ssGrid.Col = 2
                ssGrid.Lock = False
                ssGrid.Col = 3
                ssGrid.Lock = False
                ssGrid.Col = 4
                ssGrid.Lock = False
                ssGrid.Col = 5
                ssGrid.Lock = False
                ssGrid.SetActiveCell(1, ssGrid.ActiveRow)
            ElseIf e.keyCode = Keys.Tab Then
                SSGRID_MEM.SetActiveCell(1, 1)
                SSGRID_MEM.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub CheckBillAmt()
        Dim j, Qty As Integer
        Dim TotAmt, TotTaxAmt, TotBillAmt As Double
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, ITEMCODE As String
        Dim TPercent As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, TotCharges, PartyPer, RoomPer As Double
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
                .Col = 23
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
                .Col = 7
                .Row = I
                .Text = Val(GrdTaxAmt)
            End With
        Next
        GrdAmount = GrdAmount + TotTaxAmt
        txt_TotalValue.Text = Format(TotAmt, "0.00")
        txt_TaxValue.Text = Format(TotTaxAmt, "0.00")
        TotCharges = 0
        For i = 1 To sSGrid.DataRowCnt
            With sSGrid
                .Col = 23
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
                    'TPartyAmt = Val((GAmt * gPartyPer) / 100)
                    'TRoomAmt = Val((GAmt * gRoomPer) / 100)
                    If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                        TPartyAmt = Val((GAmt * gPartyPer) / 100)
                        PartyPer = gPartyPer
                    Else
                        TPartyAmt = 0
                        PartyPer = 0
                    End If
                    If Trim(cbo_PaymentMode.Text) = "ROOM" Then
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
                    'TPartyAmt = Val((GAmt * pPartyPer) / 100)
                    'TRoomAmt = Val((GAmt * pRoomPer) / 100)
                    If Trim(cbo_PaymentMode.Text) = "PARTY" Then
                        TPartyAmt = Val((GAmt * pPartyPer) / 100)
                        PartyPer = gPartyPer
                    Else
                        TPartyAmt = 0
                        PartyPer = 0
                    End If
                    If Trim(cbo_PaymentMode.Text) = "ROOM" Then
                        TRoomAmt = Val((GAmt * pRoomPer) / 100)
                        RoomPer = gRoomPer
                    Else
                        RoomPer = 0
                        TRoomAmt = 0
                    End If
                End If
                GrdAmount = GrdAmount + (TPackAmt + TTipsAmt + TAdchgAmt + TPartyAmt + TRoomAmt)
                TotCharges = TotCharges + (TPackAmt + TTipsAmt + TAdchgAmt + TPartyAmt + TRoomAmt)
                .Col = 17
                .Row = I
                .Text = pPackPer
                .Col = 18
                .Row = I
                .Text = TPackAmt
                .Col = 26
                .Row = I
                .Text = pTipsPer
                .Col = 27
                .Row = I
                .Text = TTipsAmt
                .Col = 28
                .Row = I
                .Text = pAdCgsPer
                .Col = 29
                .Row = I
                .Text = TAdchgAmt
                .Col = 30
                .Row = I
                .Text = PartyPer
                .Col = 31
                .Row = I
                .Text = TPartyAmt
                .Col = 32
                .Row = I
                .Text = RoomPer
                .Col = 33
                .Row = I
                .Text = TRoomAmt
            End With
        Next
        Txt_Charges.Text = Format(TotCharges, "0.00")
        txt_BillAmount.Text = Format(GrdAmount, "0.00")
    End Sub
    Private Sub ssGrid_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssGrid.LeaveCell
        Dim Sqlstring, Itemdesc, Promtcode As String
        Dim varitemcode, varitemdesc, varposcode As String
        Dim i, j As Integer
        Dim qty As String
        Call Calculate()
        Try
            i = ssGrid.ActiveRow
            If ssGrid.ActiveCol = 1 Then
                ssGrid.Col = 1
                ssGrid.Row = i
                varitemdesc = Trim(ssGrid.Text)
                If ssGrid.Lock = False Then
                    If Trim(ssGrid.Text) <> "" Then
                    End If
                End If
            ElseIf ssGrid.ActiveCol = 2 Then
                ssGrid.Col = 2
                ssGrid.Row = i
                If ssGrid.Lock = False Then
                    If Trim(ssGrid.Text) <> "" Then
                        ssGrid.Col = 3
                        ssGrid.Row = i
                        If Trim(ssGrid.Text) = "" Then
                            ssGrid.Row = i
                            ssGrid.Col = 2
                            varitemdesc = Trim(ssGrid.Text)
                            If Trim(varitemdesc) <> "" Then
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                                Sqlstring = "SELECT DISTINCT PL.POS,I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                If gCenterlized = "Y" Then
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink ) and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                Else
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(StrPOSCODE) & "' "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(StrPOSCODE) & "') and I.ITEMDESC = '" & varitemdesc & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                End If
                                gconnection.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                    ssGrid.SetText(1, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")))
                                    ssGrid.SetText(2, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")))
                                    ssGrid.SetText(3, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("POS")))
                                    ssGrid.SetText(9, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")))
                                    ssGrid.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")))
                                    ssGrid.SetText(11, i, Val(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    ssGrid.SetText(13, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    ssGrid.SetText(14, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    ssGrid.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    'ssGrid.SetText(17, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PACKINGPERCENT")))
                                    ssGrid.SetText(19, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    ssGrid.SetText(20, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PROMOTIONAL")))
                                    'ssGrid.SetText(21, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PACKINGACCTIN")))
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        ssGrid.SetActiveCell(2, ssGrid.ActiveRow)
                                    Else
                                        ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                                    End If
                                    '''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("Promotional")) = "Y" Then
                                        Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PROMITEMCODE"))

                                        Sqlstring = " SELECT ISNULL(I.PROMITEMCODE,'') AS PROMITEMCODE,ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(I.ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(P.POSCODE,'') AS POSCODE,I.STARTINGDATE,I.ENDINGDATE,"
                                        Sqlstring = Sqlstring & " ISNULL(I.PROMUOM,'') AS PROMUOM,ISNULL(I.PROMQTY,0) AS PROMQTY,ISNULL(I.PROMRATE,0) AS PROMRATE,ISNULL(TL.TAXCODE,'') AS TAXCODE,ISNULL(TL.TAXPERCENTAGE,0) AS TAXPERCENTAGE,"
                                        Sqlstring = Sqlstring & " ISNULL(TL.ACCOUNTCODE,'') AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM ITEMMASTER AS I INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                        Sqlstring = Sqlstring & " INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE  "

                                        Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.PROMITEMCODE = '" & Trim(Promtcode) & "') "
                                        Sqlstring = Sqlstring & " AND (I.ITEMCODE = '" & Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "') AND ISNULL(I.FREEZE,'') <>'Y'  AND PL.POS='" & Trim(POSUNDER) & "'"
                                        gconnection.getDataSet(Sqlstring, "PROMOTIONAL")
                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                            MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                                            If DialogResult.OK = 1 Then
                                                If DateValue(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ENDINGDATE")) <= DateValue(Now) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("STARTINGDATE")) >= DateValue(Now) Then
                                                    ssGrid.SetText(1, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")))
                                                    ssGrid.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")))
                                                    ssGrid.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")))
                                                    ssGrid.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")))
                                                    ssGrid.SetText(5, i + 1, Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")))
                                                    ssGrid.SetText(6, i + 1, 0.0)
                                                    ssGrid.SetText(7, i + 1, 0.0)
                                                    ssGrid.SetText(8, i + 1, 0.0)
                                                    ssGrid.SetText(9, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")))
                                                    ssGrid.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("TAXCODE")))
                                                    ssGrid.SetText(11, i + 1, Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("TAXPERCENTAGE")))
                                                    ssGrid.SetText(13, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ACCOUNTCODE")))
                                                    ssGrid.SetText(14, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("SALESACCTIN")))
                                                    ssGrid.SetText(15, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("GROUPCODE")))
                                                    ssGrid.SetActiveCell(5, i)
                                                    ssGrid.Focus()
                                                End If
                                            Else
                                                ssGrid.SetActiveCell(4, i)
                                                ssGrid.Focus()
                                            End If
                                        End If
                                    End If
                                    '''*************************** $ COMPLETE PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*************************************************'''
                                    ssGrid.Col = 1
                                    ssGrid.Row = ssGrid.ActiveRow
                                    Sqlstring = "SELECT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE FROM ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                    Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(ssGrid.Text) & "' ) ORDER BY R.UOM"
                                    gconnection.getDataSet(Sqlstring, "ITEMRATE")
                                    If gdataset.Tables("ITEMRATE").Rows.Count > 0 Then
                                        ssGrid.Col = 4
                                        ssGrid.Row = ssGrid.ActiveRow
                                        ssGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM"))
                                        ssGrid.Col = 6
                                        ssGrid.Row = ssGrid.ActiveRow
                                        ssGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                        ssGrid.Col = 19
                                        ssGrid.Row = ssGrid.ActiveRow
                                        If Trim(ssGrid.Text) = "Y" Then
                                            ssGrid.SetActiveCell(2, ssGrid.ActiveRow)
                                        Else
                                            ssGrid.SetActiveCell(5, ssGrid.ActiveRow)
                                        End If
                                    Else
                                        ssGrid.Col = 6
                                        ssGrid.Text = "0.00"
                                        ssGrid.Col = 4
                                        ssGrid.Col = 19
                                        ssGrid.Row = ssGrid.ActiveRow
                                        If Trim(ssGrid.Text) = "Y" Then
                                            ssGrid.SetActiveCell(2, ssGrid.ActiveRow)
                                        Else
                                            ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                                        End If
                                    End If
                                    '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                Else
                                    MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    ssGrid.ClearRange(1, ssGrid.ActiveRow, 15, ssGrid.ActiveRow, True)
                                    ssGrid.SetActiveCell(1, ssGrid.ActiveRow)
                                    ssGrid.Lock = False
                                    ssGrid.Focus()
                                    Exit Sub
                                End If
                            End If
                        Else
                            ssGrid.Col = 19
                            ssGrid.Row = ssGrid.ActiveRow
                            If Trim(ssGrid.Text) = "Y" Then
                                ssGrid.SetActiveCell(5, ssGrid.ActiveRow)
                                ssGrid.Focus()
                            End If
                        End If
                    End If
                End If
            ElseIf ssGrid.ActiveCol = 3 Then
                ssGrid.Row = ssGrid.ActiveRow
                ssGrid.Row = ssGrid.ActiveRow
                ssGrid.Col = 1
                varitemcode = Trim(ssGrid.Text)
                ssGrid.Col = 2
                varitemdesc = Trim(ssGrid.Text)
                ssGrid.Col = 3
                If Trim(varitemcode) = "" And Trim(varitemdesc) = "" Then
                    ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                    Exit Sub
                Else
                    ssGrid.Col = 1
                    varitemcode = Trim(ssGrid.Text)
                    ssGrid.Col = 3
                    varposcode = Trim(ssGrid.Text)
                    If Trim(varposcode) = "" Then
                        ssGrid.Text = ""
                        ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                        ssGrid.Focus()
                    ElseIf Trim(varposcode) <> "" Then
                        ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                    End If
                End If
            ElseIf ssGrid.ActiveCol = 4 Then
                ssGrid.Col = 4
                ssGrid.Row = ssGrid.ActiveRow
                If ssGrid.Lock = False Then
                    If Trim(ssGrid.Text) = "" Then
                        ssGrid.Col = 1
                        ssGrid.Row = ssGrid.ActiveRow
                        'CHANGE
                        '                        ITEMCODE = Trim(ssGrid.Text)
                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                        Sqlstring = "SELECT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE FROM ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(ITEMCODE) & "' ) ORDER BY R.UOM"
                        gconnection.getDataSet(Sqlstring, "ITEMRATE")
                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                            ssGrid.Col = 4
                            ssGrid.Row = ssGrid.ActiveRow
                            ssGrid.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM"))
                            ssGrid.Col = 19
                            ssGrid.Row = ssGrid.ActiveRow
                            If Trim(ssGrid.Text) = "Y" Then
                                ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                            Else
                                ssGrid.Col = 6
                                ssGrid.Row = ssGrid.ActiveRow
                                ssGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                            End If
                        ElseIf gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                            ssGrid.Col = 4
                            Call FillUomList(gdataset.Tables("ITEMRATE"))
                            Me.lvw_Uom.FullRowSelect = True
                            pnl_UOMCode.Top = 50
                            Me.lvw_Uom.Focus()
                        Else
                            ssGrid.Col = 1
                            ssGrid.Row = ssGrid.ActiveRow
                            If Trim(ssGrid.Text) <> "" Then
                                ssGrid.Col = 4
                                ssGrid.Text = ""
                                ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                            End If
                        End If
                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                    End If
                End If
            ElseIf ssGrid.ActiveCol = 5 Then
                ssGrid.Col = 5
                ssGrid.Row = ssGrid.ActiveRow
                If ssGrid.Lock = False Then
                    ssGrid.Col = 1
                    ssGrid.Row = ssGrid.ActiveRow
                    If Trim(ssGrid.Text) <> "" Then
                        ssGrid.Col = 5
                        ssGrid.Row = ssGrid.ActiveRow
                        If Val(ssGrid.Text) = 0 Then
                            ssGrid.SetActiveCell(5, ssGrid.ActiveRow)
                            Exit Sub
                        Else
                            ssGrid.Col = 19
                            ssGrid.Row = ssGrid.ActiveRow
                            If Trim(ssGrid.Text) = "Y" Then
                                ssGrid.Col = 6
                                ssGrid.Lock = False
                                ssGrid.SetActiveCell(6, ssGrid.ActiveRow)
                                Exit Sub
                            Else
                                Call Calculate()
                                ssGrid.Row = ssGrid.ActiveRow + 1
                                ssGrid.Col = 1
                                ssGrid.Lock = False
                                ssGrid.Col = 2
                                ssGrid.Lock = False
                                ssGrid.Col = 3
                                ssGrid.Lock = False
                                ssGrid.Col = 4
                                ssGrid.Lock = False
                                ssGrid.Col = 5
                                ssGrid.Lock = False
                                ssGrid.SetActiveCell(1, ssGrid.ActiveRow + 1)
                            End If
                        End If
                    End If
                End If
            ElseIf ssGrid.ActiveCol = 6 Then
                ssGrid.Col = 6
                ssGrid.Row = ssGrid.ActiveRow
                If ssGrid.Lock = False Then
                    ssGrid.Col = 1
                    ssGrid.Row = ssGrid.ActiveRow
                    If Trim(ssGrid.Text) <> "" Then
                        ssGrid.Col = 6
                        ssGrid.Row = ssGrid.ActiveRow
                        If Val(ssGrid.Text) = 0 Then
                            ssGrid.SetActiveCell(6, ssGrid.ActiveRow)
                            Exit Sub
                        Else
                            Call RateCalculate()
                            ssGrid.Row = ssGrid.ActiveRow + 1
                            ssGrid.Col = 1
                            ssGrid.Lock = False
                            ssGrid.Col = 2
                            ssGrid.Lock = False
                            ssGrid.Col = 3
                            ssGrid.Lock = False
                            ssGrid.Col = 4
                            ssGrid.Lock = False
                            ssGrid.Col = 5
                            ssGrid.Lock = False
                            ssGrid.SetActiveCell(1, ssGrid.ActiveRow + 1)
                        End If
                    End If
                End If
            ElseIf ssGrid.ActiveCol = 12 Then
                ssGrid.Col = 12
                ssGrid.Row = ssGrid.ActiveRow
                If Val(ssGrid.Text) = 0 Then
                    Call Calculate()
                    ssGrid.SetActiveCell(1, ssGrid.ActiveRow + 1)
                    Exit Sub
                Else
                    Call Calculate()
                    ssGrid.SetActiveCell(1, ssGrid.ActiveRow + 1)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub RateCalculate()
        Dim i As Integer
        Dim cancel, kotstatus As String
        Dim dblTotalamount, dblTaxamount, cancelamt, canceltax As Double
        Dim Billamount, dblCalqty, dblTaxperc, dblCalRate, dblPackPercent, dblPackAmount As Double
        ssGrid.Col = 19
        ssGrid.Row = ssGrid.ActiveRow
        If Trim(ssGrid.Text) = "Y" Then
            If ssGrid.ActiveCol = 6 Or ssGrid.ActiveCol = 5 Or ssGrid.ActiveCol = 2 Or ssGrid.ActiveCol = 1 Then
                Me.txt_TaxValue.Text = "0.00"
                Me.txt_TotalValue.Text = "0.00"
                Me.Txt_Charges.Text = "0.00"
                Me.txt_BillAmount.Text = "0.00"
                For i = 1 To ssGrid.DataRowCnt
                    ssGrid.Col = 12
                    ssGrid.Row = i
                    kotstatus = ssGrid.Text
                    If Val(kotstatus) = 0 Then
                        ssGrid.Col = 5
                        ssGrid.Row = i
                        dblCalqty = Val(ssGrid.Text)
                        ssGrid.Col = 6
                        ssGrid.Row = i
                        dblCalRate = Val(ssGrid.Text)
                        ssGrid.Col = 11
                        ssGrid.Row = i
                        dblTaxperc = Val(ssGrid.Text)
                        ssGrid.Col = 17
                        ssGrid.Row = i
                        dblPackPercent = Val(ssGrid.Text)
                        dblTotalamount = Val(dblCalqty) * Val(dblCalRate)
                        dblTaxamount = (dblTotalamount * dblTaxperc) / 100
                        dblPackAmount = ((Val(dblTotalamount) + Val(dblTaxamount)) * dblPackPercent) / 100
                        ssGrid.SetText(8, i, dblTotalamount)
                        ssGrid.SetText(7, i, dblTaxamount)
                        ssGrid.SetText(18, i, dblPackAmount)
                        Me.txt_TotalValue.Text = Format(Val(Me.txt_TotalValue.Text) + Val(dblTotalamount), "0.00")
                        Me.txt_TaxValue.Text = Format(Val(Me.txt_TaxValue.Text) + Val(dblTaxamount), "0.00")
                        Me.Txt_Charges.Text = Format(Val(Me.Txt_Charges.Text) + Val(dblPackAmount), "0.00")
                        ''Billamount = Format(Math.Round(Val(Me.txt_TaxValue.Text)) + Math.Round(Val(Me.txt_TotalValue.Text)) + Math.Round(Val(Me.txt_PackingCharge.Text)), "0.00")
                        'Me.txt_BillAmount.Text = Format(Math.Round(Billamount), "0.00")
                        If BILLROUNDYESNO = "YES" Then
                            Billamount = Format(Math.Round(Val(Me.txt_TaxValue.Text)) + Math.Round(Val(Me.txt_TotalValue.Text)) + Math.Round(Val(Me.Txt_Charges.Text)), "0.00")
                            Me.txt_BillAmount.Text = Format(Math.Round(Billamount), "0.00")
                        Else
                            Billamount = Format(Val(Me.txt_TaxValue.Text) + Val(Me.txt_TotalValue.Text) + Val(Me.Txt_Charges.Text), "0.00")
                            Me.txt_BillAmount.Text = Format(Billamount, "0.00")
                        End If
                    End If
                Next i
            End If
            i = i - 1
        End If
    End Sub
    Private Sub Calculate()
        Dim dblTotalamount, dblTaxamount, cancelamt, canceltax, Billamount As Double
        Dim dblCalqty, dblTaxperc, dblCalRate, dblPackPercent, dblPackAmount, Roundoff, Roundoff1 As Double
        Dim cancel, kotstatus, Round, Roundedvalue() As String
        Dim i As Integer
        If ssGrid.ActiveCol = 5 Or ssGrid.ActiveCol = 4 Or ssGrid.ActiveCol = 1 Or ssGrid.ActiveCol = 12 Then
            Me.txt_TaxValue.Text = "0.00"
            Me.txt_TotalValue.Text = "0.00"
            Me.Txt_Charges.Text = "0.00"
            Me.txt_BillAmount.Text = "0.00"
            For i = 1 To ssGrid.DataRowCnt
                ssGrid.Col = 12
                ssGrid.Row = i
                kotstatus = ssGrid.Text
                If Val(kotstatus) = 0 Then
                    ssGrid.Col = 5
                    ssGrid.Row = i
                    dblCalqty = Val(ssGrid.Text)
                    ssGrid.Col = 6
                    ssGrid.Row = i
                    dblCalRate = Val(ssGrid.Text)
                    ssGrid.Col = 11
                    ssGrid.Row = i
                    dblTaxperc = Val(ssGrid.Text)
                    ssGrid.Col = 17
                    ssGrid.Row = i
                    dblPackPercent = Val(ssGrid.Text)
                    dblTotalamount = Val(dblCalqty) * Val(dblCalRate)
                    dblTaxamount = (dblTotalamount * dblTaxperc) / 100
                    dblPackAmount = ((Val(dblTotalamount) + Val(dblTaxamount)) * dblPackPercent) / 100
                    ssGrid.SetText(8, i, dblTotalamount)
                    ssGrid.SetText(7, i, dblTaxamount)
                    ssGrid.SetText(18, i, dblPackAmount)
                    Me.txt_TotalValue.Text = Format(Val(Me.txt_TotalValue.Text) + Val(dblTotalamount), "0.00")
                    Me.txt_TaxValue.Text = Format(Val(Me.txt_TaxValue.Text) + Val(dblTaxamount), "0.00")
                    Me.Txt_Charges.Text = Format(Val(Me.Txt_Charges.Text) + Val(dblPackAmount), "0.00")
                    Roundoff = Val(Me.txt_TotalValue.Text) + Val(Me.txt_TaxValue.Text) + Val(Me.Txt_Charges.Text)
                    Round = CStr(Roundoff)
                    If BILLROUNDYESNO = "YES" Then
                        If Round.IndexOf(".") <= 0 Then
                            Round = Round.Insert(Round.Length - 1, ".00")
                        End If
                        Roundedvalue = Split(Round, ".")
                        Roundoff1 = Mid(Format(Val(Roundoff), "0.00"), Len(Format(Val(Roundoff), "0.00")) - 1, Len(Format(Val(Roundoff), "0.00")))
                        If Format(Val(Roundoff1), "00") = 50 Then
                            Roundoff = Math.Ceiling(Roundoff)
                        ElseIf Format(Val(Roundoff1), "00") > 50 Then
                            Roundoff = Math.Ceiling(Roundoff)
                        Else
                            Roundoff = Math.Floor(Roundoff)
                        End If
                        Me.txt_BillAmount.Text = Format(Val(Roundoff), "0.00")
                    Else
                        Roundoff1 = Mid(Format(Val(Roundoff), "0.00"), Len(Format(Val(Roundoff), "0.00")) - 1, Len(Format(Val(Roundoff), "0.00")))
                        Me.txt_BillAmount.Text = Format(Val(Roundoff), "0.00")
                    End If
                End If
            Next i
            i = i - 1
        End If
        Call CheckBillAmt()
    End Sub

    Private Sub FillPosList(ByVal PosTable As DataTable)
        Dim lvw As New ListViewItem
        Dim i As Integer
        lvw_POSCode.Items.Clear()
        For i = 0 To PosTable.Rows.Count - 1
            lvw = lvw_POSCode.Items.Add(PosTable.Rows(i).Item(0))
            lvw.SubItems.Add(PosTable.Rows(i).Item(1))
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

    Private Sub cbo_PaymentMode_KeyDown(sender As Object, e As KeyEventArgs) Handles cbo_PaymentMode.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
        End If
    End Sub

    Private Sub cbo_PaymentMode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_PaymentMode.KeyPress
        Dim sqlstring As String
        If Asc(e.KeyChar) = 13 Then
            Try
                sqlstring = " SELECT ISNULL(SUBPAYSTATUS,'') AS SUBPAYSTATUS,ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                    If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("SUBPAYSTATUS")) = "YES" Then
                        cbo_SubPaymentMode.Focus()
                    ElseIf Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) = "NO" Then
                        'Txt_ServerCode.Focus()
                        Txt_Pos.Focus()
                    Else
                        'Txt_ServerCode.Focus()
                        Txt_Pos.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub cbo_PaymentMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_PaymentMode.SelectedIndexChanged
        Dim sqlstring As String
        If cbo_PaymentMode.SelectedItem = "ROOM" Then
            Txt_ServerCode.Focus()
        Else
            Try
                sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                    If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) = "NO" Then
                        lbl_SubPaymentMode.Visible = False
                        cbo_SubPaymentMode.Visible = False
                        Txt_ServerCode.Focus()
                    Else
                        lbl_SubPaymentMode.Visible = False
                        cbo_SubPaymentMode.Visible = False
                        Txt_ServerCode.Focus()
                    End If
                Else
                    MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            Catch ex As Exception
                MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
        Call FillSubPaymentMode(Trim(Me.cbo_PaymentMode.Text))
    End Sub
    Private Sub FillMenu()
        Dim vform As New LIST_OPERATION1
        Dim promitemcode As String
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(PL.POS,'') AS POS,ISNULL(I.ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(TL.TAXCODE,'') AS TAXCODE,ISNULL(TL.TAXPERCENTAGE,0) AS TAXPERCENTAGE,"
        gSQLString = gSQLString & " ISNULL(TL.ACCOUNTCODE,'') AS ACCOUNTCODE, ISNULL(I.SALESACCTIN,'') AS SALESACCTIN,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.PROMITEMCODE,'') AS PROMITEMCODE,"
        gSQLString = gSQLString & " ISNULL(P.PACKINGPERCENT,0) AS PACKINGPERCENT, ISNULL(OPENFACILITY,'') AS OPENFACILITY,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL ,ISNULL(P.PACKINGACCTIN,'') AS PACKINGACCTIN "
        gSQLString = gSQLString & " FROM ITEMMASTER AS I INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE  "
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            'M_WhereCondition = " WHERE I.ITEMCODE LIKE '" & Trim(Search) & "%' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y' AND PL.POS='" & Trim(POSUNDER) & "'"
            M_WhereCondition = " WHERE I.ITEMCODE = '" & Trim(TXT_ITEMCODE.Text) & "%' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y' AND PL.POS='" & Trim(POSUNDER) & "'"
        End If
        vform.Field = "I.ITEMDESC,I.ITEMCODE"
        'vform.vFormatstring = "  ITEMCODE           |                 ITEMDESC                  |  POSCODE     |  ITEMTYPECODE  |  TAXCODE  | TAXPERCENTAGE | ACCOUNTCODE | SALESACCTIN |  GROUPCODE | PROMITEMCODE | PACKINGPERCENT "
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
        'vform.Keypos11 = 11
        'vform.Keypos12 = 12
        'vform.Keypos13 = 13
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssGrid
                '.Col = 1
                '.Row = .ActiveRow
                '.Text = vform.keyfield
                '.Col = 2
                '.Row = .ActiveRow
                '.Text = vform.keyfield1
                .Col = 3
                .Row = .ActiveRow
                .Text = vform.keyfield2
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
                .Text = vform.keyfield7
                .Col = 15
                .Row = .ActiveRow
                .Text = vform.keyfield8
                promitemcode = vform.keyfield9
                .Col = 17
                .Row = .ActiveRow
                .Text = vform.keyfield10
                .Col = 19
                .Row = .ActiveRow
                .Text = Trim(CStr(vform.keyfield11))
                .Col = 20
                .Row = .ActiveRow
                .Text = Trim(CStr(vform.keyfield12))
                .Col = 21
                .Row = .ActiveRow
                .Text = Trim(CStr(vform.keyfield13))
                If Trim(CStr(vform.keyfield11)) = "Y" Then
                    ssGrid.SetActiveCell(1, ssGrid.ActiveRow)
                Else
                    ssGrid.SetActiveCell(3, ssGrid.ActiveRow)
                End If
            End With
        Else
            ssGrid.SetActiveCell(0, ssGrid.ActiveRow)
            Exit Sub
        End If
        If Trim(vform.keyfield) <> "" Then
            '''************************************************* $ FILL UOM , RATE INTO SSGRID $ **************************************************'''
            gSQLString = "SELECT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE "
            gSQLString = gSQLString & " FROM ITEMMASTER AS I INNER JOIN "
            gSQLString = gSQLString & " RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
            gSQLString = gSQLString & "WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(vform.keyfield) & "' ) ORDER BY R.UOM"
            gconnection.getDataSet(gSQLString, "ITEMRATE")
            If gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                Call FillUomList(gdataset.Tables("ITEMRATE"))
                If ssGrid.ActiveCol = 4 Then
                    '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                    Me.lvw_Uom.FullRowSelect = True
                    pnl_UOMCode.Top = 50
                    Me.lvw_Uom.Focus()
                    '''***************************************** $ COMPLETE POPUP FOR VARIOUS UOM $ ******************************************************''
                End If
            Else
                ssGrid.Col = 4
                ssGrid.Row = ssGrid.ActiveRow
                ssGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")
                ssGrid.Col = 6
                ssGrid.Row = ssGrid.ActiveRow
                ssGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")
                If Trim(CStr(vform.keyfield11)) = "Y" Then
                    ssGrid.SetActiveCell(1, ssGrid.ActiveRow)
                Else
                    ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                End If
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FillMenuItem()
        Dim vform As New LIST_OPERATION1
        Dim promitemcode As String
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "SELECT ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.BASERATESTD,0) AS RATE,ISNULL(PL.POS,'') AS POS,ISNULL(I.ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(TL.TAXCODE,'') AS TAXCODE,ISNULL(TL.TAXPERCENTAGE,0) AS TAXPERCENTAGE,"
        gSQLString = gSQLString & " ISNULL(TL.ACCOUNTCODE,'') AS ACCOUNTCODE, ISNULL(I.SALESACCTIN,'') AS SALESACCTIN,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.PROMITEMCODE,'') AS PROMITEMCODE,"
        gSQLString = gSQLString & " ISNULL(P.PACKINGPERCENT,0) AS PACKINGPERCENT, ISNULL(OPENFACILITY,'') AS OPENFACILITY,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL ,ISNULL(P.PACKINGACCTIN,'') AS PACKINGACCTIN "
        gSQLString = gSQLString & " FROM ITEMMASTER AS I INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE  "
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " WHERE I.ITEMDESC LIKE '" & Trim(Search) & "%' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y' AND PL.POS='" & Trim(POSUNDER) & "'"
        End If
        vform.Field = "I.ITEMDESC,I.ITEMCODE"
        'vform.vFormatstring = "                ITEMDESC                  |        ITEMCODE      |  RATE       |  POSCODE     |  ITEMTYPECODE  |  TAXCODE  | TAXPERCENTAGE | ACCOUNTCODE | SALESACCTIN |  GROUPCODE  | PROMITEMCODE | PACKINGPERCENT "
        vform.vCaption = "ITEM CODE HELP"
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 3
        'vform.Keypos3 = 4
        'vform.keypos4 = 5
        'vform.Keypos5 = 6
        'vform.Keypos6 = 7
        'vform.Keypos7 = 8
        'vform.Keypos8 = 9
        'vform.keypos9 = 10
        'vform.Keypos10 = 11
        'vform.Keypos11 = 12
        'vform.Keypos12 = 13
        'vform.Keypos13 = 14
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssGrid
                .Col = 1
                .Row = .ActiveRow
                .Text = vform.keyfield1
                .Col = 2
                .Row = .ActiveRow
                .Text = vform.keyfield
                .Col = 3
                .Row = .ActiveRow
                .Text = vform.keyfield2
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
                .Text = vform.keyfield7
                .Col = 15
                .Row = .ActiveRow
                .Text = vform.keyfield8
                promitemcode = vform.keyfield9
                .Col = 17
                .Row = .ActiveRow
                .Text = vform.keyfield10
                .Col = 19
                .Row = .ActiveRow
                .Text = vform.keyfield11
                .Col = 20
                .Row = .ActiveRow
                .Text = vform.keyfield12
                .Col = 21
                .Row = .ActiveRow
                .Text = vform.keyfield13
                If Trim(CStr(vform.keyfield11)) = "Y" Then
                    ssGrid.SetActiveCell(1, ssGrid.ActiveRow)
                Else
                    ssGrid.SetActiveCell(3, ssGrid.ActiveRow)
                End If
            End With
        Else
            ssGrid.SetActiveCell(1, ssGrid.ActiveRow)
            Exit Sub
        End If
        If Trim(vform.keyfield) <> "" Then
            '''************************************************* $ FILL UOM , RATE INTO SSGRID $ **************************************************'''
            gSQLString = "SELECT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE "
            gSQLString = gSQLString & " FROM ITEMMASTER AS I INNER JOIN "
            gSQLString = gSQLString & " RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
            gSQLString = gSQLString & "WHERE '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(vform.keyfield1) & "' ) ORDER BY R.UOM"
            gconnection.getDataSet(gSQLString, "ITEMRATE")
            If gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                Call FillUomList(gdataset.Tables("ITEMRATE"))
                If ssGrid.ActiveCol = 4 Then
                    '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                    Me.lvw_Uom.FullRowSelect = True
                    pnl_UOMCode.Top = 50
                    Me.lvw_Uom.Focus()
                    '''***************************************** $ COMPLETE POPUP FOR VARIOUS UOM $ ******************************************************''
                End If
            Else
                ssGrid.Col = 4
                ssGrid.Row = ssGrid.ActiveRow
                ssGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")
                ssGrid.Col = 6
                ssGrid.Row = ssGrid.ActiveRow
                ssGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")
                If Trim(CStr(vform.keyfield11)) = "Y" Then
                    ssGrid.SetActiveCell(1, ssGrid.ActiveRow)
                Else
                    ssGrid.SetActiveCell(4, ssGrid.ActiveRow)
                End If
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        Call checkvalidate() '''---> Check Validation
        If chkbool = False Then Exit Sub
        Dim sqlstring, Delete(0) As String
        Dim dt As New DataTable

        sqlstring = "SELECT ISNULL(POSCLOSE,'N')  AS POSCLOSE FROM MONTHCLOSE WHERE MONTHNO=" & Month(dtp_KOTdate.Value)
        gconnection.getDataSet(sqlstring, "MONTHCLOSE")
        If gdataset.Tables("MONTHCLOSE").Rows.Count > 0 Then
            If gdataset.Tables("MONTHCLOSE").Rows(0).Item("POSCLOSE") = "Y" Then
                MsgBox("ACCOUNT POSTING ALREADY DONE...........")
                Exit Sub
            End If
        End If

        sqlstring = "SELECT * FROM MATCHING WHERE VOUCHERNO = '" & Trim(txt_KOTno.Text) & "' AND VOUCHERDATE = '" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "'"
        dt = gconnection.GetValues(sqlstring)
        If (dt.Rows.Count > 0) Then
            MsgBox("Sorry, Bill Matching Was Already Made, You Can't Delete....")
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
       
        '''************************************** Deleting KOTDETAILS Permently from KOT_HDR ************************************'''
        sqlstring = " UPDATE KOT_HDR SET DELFLAG = 'Y' WHERE TRANSNO= " & Trim(CStr(Me.txt_KOTno.Text)) & " AND ISNULL(TTYPE,'')='S'"
        Delete(0) = sqlstring
        '''************************************************* COMPLETE KOT_HDR ***************************************************'''
        '''************************************** Deleting KOTDETAILS Permently from KOT_DET ************************************'''
        sqlstring = " UPDATE KOT_DET SET DELFLAG = 'Y' WHERE TRANSNO= " & Trim(CStr(Me.txt_KOTno.Text)) & " AND ISNULL(TTYPE,'')='S'"
        ReDim Preserve Delete(Delete.Length)
        Delete(Delete.Length - 1) = sqlstring

        'REFERINVENTORY************************************* UPDATING STOCK FOR KOT DELETION **************************************
        sqlstring = " UPDATE SUBSTORECONSUMPTIONDETAIL SET VOID = 'Y' WHERE DOCDetails IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO=" & Trim(CStr(Me.txt_KOTno.Text)) & " AND ISNULL(TTYPE,'')='S')"
        ReDim Preserve Delete(Delete.Length)
        Delete(Delete.Length - 1) = sqlstring
        '***************************************************************************************************************************
        '''************************************************* COMPLETE KOT_HDR ***************************************************'''

        sqlstring = " UPDATE BILL_HDR SET DELFLAG = 'Y' WHERE BILLDETAILS IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO = " & Trim(CStr(Me.txt_KOTno.Text)) & " AND ISNULL(TTYPE,'')='S')"
        ReDim Preserve Delete(Delete.Length)
        Delete(Delete.Length - 1) = sqlstring

        '''************************************************* COMPLETE KOT_HDR ***************************************************'''
        sqlstring = " UPDATE BILL_DET SET DELFLAG = 'Y' WHERE BILLDETAILS IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO= " & Trim(CStr(Me.txt_KOTno.Text)) & " AND ISNULL(TTYPE,'')='S')"
        ReDim Preserve Delete(Delete.Length)
        Delete(Delete.Length - 1) = sqlstring

        '''************************************************* COMPLETE BILLSETTLEMENT ***************************************************'''
        sqlstring = " UPDATE BILLSETTLEMENT SET DELFLAG = 'Y' WHERE BILLNO IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO=" & Trim(CStr(Me.txt_KOTno.Text)) & " AND ISNULL(TTYPE,'')='S')"
        ReDim Preserve Delete(Delete.Length)
        Delete(Delete.Length - 1) = sqlstring

        sqlstring = " UPDATE KOT_HDR SET VOUCHERNO = '',POSTINGSTATUS = 'N' WHERE TRANSNO=" & txt_KOTno.Text & " AND ISNULL(TTYPE,'')='S'"
        ReDim Preserve Delete(Delete.Length)
        Delete(Delete.Length - 1) = sqlstring

        '''************************************************* COMPLETE KOT_HDR ***************************************************'''
        sqlstring = "SELECT ISNULL(KOTDETAILS,'') AS KOTDETAILS,KOTDATE,ISNULL(VOUCHERNO,'') AS VOUCHERNO,ISNULL(POSTINGSTATUS,'') As POSTINGSTATUS FROM KOT_HDR  WHERE TRANSNO=" & Trim(CStr(Me.txt_KOTno.Text)) & " AND ISNULL(TTYPE,'')='S'"
        gconnection.getDataSet(sqlstring, "KOTHDR")
        If gdataset.Tables("KOTHDR").Rows.Count > 0 Then

            sqlstring = " UPDATE KOT_HDR SET VOUCHERNO = '',POSTINGSTATUS = 'N' WHERE TRANSNO=" & Trim(CStr(Me.txt_KOTno.Text))
            ReDim Preserve Delete(Delete.Length)
            Delete(Delete.Length - 1) = sqlstring
            sqlstring = " UPDATE BILL_JOURNALENTRY SET VOID = 'Y' WHERE VOUCHERNO IN (SELECT KOTDETAILS FROM KOT_HDR WHERE TRANSNO=" & Trim(CStr(Me.txt_KOTno.Text)) & ")"
            ReDim Preserve Delete(Delete.Length)
            Delete(Delete.Length - 1) = sqlstring
            sqlstring = " UPDATE OUTSTANDING SET VOID = 'Y' WHERE VOUCHERNO IN (SELECT KOTDETAILS FROM KOT_HDR WHERE TRANSNO=" & Trim(CStr(Me.txt_KOTno.Text)) & ")"
            ReDim Preserve Delete(Delete.Length)
            Delete(Delete.Length - 1) = sqlstring
        End If
       
        ReDim Preserve Delete(Delete.Length)
        Delete(Delete.Length - 1) = sqlstring
        gconnection.MoreTransold(Delete)
        Call Cmd_Clear_Click(Cmd_Clear, e)
    End Sub
    Private Sub DeleteOperation()
        MessageBox.Show("Particular KOT's Can't be deleted", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
    End Sub
    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub txt_Cover_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Cover.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            cbo_PaymentMode.Focus()
        End If
    End Sub
    Private Sub Txt_ServerName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ServerName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'ssGrid.Focus()
            'ssGrid.SetActiveCell(1, 1)
            If Trim(Txt_ServerName.Text) <> "" Then
                TXT_ITEMCODE.Focus()
            Else
                Txt_ServerName.Focus()
            End If
        End If
    End Sub
    Private Sub cmd_KOTnoHelp_Click(sender As Object, e As EventArgs) Handles cmd_KOTnoHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ISNULL(TRANSNO,0)AS TRANSNO,ISNULL(KOTDETAILS,'') AS KOTDETAILS,ISNULL(BOOKNO,0)AS BOOKNO,ISNULL(CHITNO,0)AS CHITNO,ISNULL(MCODE,'') AS MCODE,ISNULL(SERVERCODE,'') AS SERVERCODE,ISNULL(SERVERNAME,'') AS SERVERNAME,ISNULL(MNAME,'') AS MNAME,Convert(varchar, KOTDATE,100) AS KOTDATE,ISNULL(REMARKS,'') AS REMARKS  FROM KOT_HDR "
        M_WhereCondition = " WHERE ISNULL(MANUALBILLSTATUS,'')='Y' AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(TTYPE,'')='S'"
        vform.Field = " TRANSNO,KOTDETAILS,BOOKNO,CHITNO,MCODE,MNAME,SERVERCODE,SERVERNAME,KOTDATE "
        'vform.vFormatstring = " TRANSACTION NO  | BILL NO                     |  BOOK NO   |  CHITNO    |   MCODE   | SERVER CODE |    SERVER NAME      |    MNAME           |      KOT DATE     |   REMARKS    | "
        vform.vCaption = "KOT DETAILS HELP"
        'vform.KeyPos = 0
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_KOTno.Text = Trim(vform.keyfield)
            Call txt_KOTno_Validated(sender, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_TotalValue_LostFocus(sender As Object, e As EventArgs) Handles txt_TotalValue.LostFocus
        txt_TotalValue.Text = Format(Val(txt_TotalValue.Text), "0.00")
    End Sub
    Private Sub txt_TaxValue_LostFocus(sender As Object, e As EventArgs) Handles txt_TaxValue.LostFocus
        txt_TaxValue.Text = Format(Val(txt_TaxValue.Text), "0.00")
    End Sub
    Private Sub txt_BillAmount_LostFocus(sender As Object, e As EventArgs) Handles txt_BillAmount.LostFocus
        If BILLROUNDYESNO = "YES" Then
            txt_BillAmount.Text = Format(Math.Round(Val(txt_BillAmount.Text)), "0.00")
        Else
            txt_BillAmount.Text = Format(Val(txt_BillAmount.Text), "0.00")
        End If
    End Sub
    Private Sub dtp_KOTdate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp_KOTdate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cbo_PaymentMode.Focus()
            Show()
        End If
    End Sub
    Private Sub cmd_BillSettlement_Click(sender As Object, e As EventArgs) Handles cmd_BillSettlement.Click
        gPrint = False
        'COMBINED_BILL_PRINT()
        Exit Sub
        MsgBox("Please Contact System Admin!", MsgBoxStyle.OkOnly, "Info!")
        Exit Sub
        'End

        Dim sqlstring, Varchk, SubpaymentMode(), paymentaccountcode, Subpaymentaccountcode As String
        Dim TotalAmount, TaxTotal, total, size, i, j As Double
        Dim TaxApp, NoTax, Otherbool As Boolean
        Dim Kot_Bill As New DataTable
        Dim Taxdr(), NoTaxDr() As DataRow
        Try
            'Call checkvalidate() '''---> Check Validation
            'If chkbool = False Then Exit Sub
            ''''************************************************* Case-1:ADD [F7] ***********************************'''
            If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                BillTaxBilldetails = Trim(Me.txt_KOTno.Text)
                BillNonTaxBilldetails = ""
                dblBillTaxTotal = Val(txt_TaxValue.Text)
                dblBillTotalAmount = Val(txt_BillAmount.Text)
                dblBillNonTaxtotal = 0
                dblBillNonTotalAmount = 0
                'BillMcode = Trim(txt_MemberCode.Text)
                'BillMname = Trim(txt_MemberName.Text)
                ssgridPayment.Col = 1
                ssgridPayment.Row = 1
                ssgridPayment.Text = Trim(BillTaxBilldetails)
                ssgridPayment.Col = 2
                ssgridPayment.Row = 1
                ssgridPayment.Text = Format(dtp_KOTdate.Value, "dd/MM/yyyy")
                ssgridPayment.Col = 5
                ssgridPayment.Row = 1
                ssgridPayment.Text = Trim(BillMcode)
                ssgridPayment.Col = 6
                ssgridPayment.Row = 1
                ssgridPayment.Text = Trim(BillMname)
                ssgridPayment.Col = 7
                ssgridPayment.Row = 1
                ssgridPayment.Text = Format(Val(dblBillTotalAmount), "0.00")
                ssgridPayment.Col = 8
                ssgridPayment.Row = 1
                ssgridPayment.Text = Format(Val(dblBillTotalAmount), "0.00")
                Gridbillamount = Format(Val(dblBillTotalAmount), "0.00")
                Me.txt_PartialPayment.Text = Format(Val(dblBillTotalAmount), "0.00")
                Call FillPaymentmodeSettlement(1)
                grp_Paymentmodeselection.Top = 296
                grp_Paymentmodeselection.Left = 80
                ssgridPayment.SetActiveCell(3, 1)
                ssgridPayment.Focus()
            Else
                grp_Paymentmodeselection.Top = 296
                grp_Paymentmodeselection.Left = 80
                ssgridPayment.SetActiveCell(3, 1)
                ssgridPayment.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillUOMMenu()
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        gSQLString = "SELECT UOMCODE,UOMDESC FROM UOMMASTER "
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " WHERE SUBSTRING(ISNULL(CATEGORY,''),1,1)='F' AND ISNULL(FREEZE,'') <>'Y'"
        End If
        vform.Field = "UOMCODE,UOMDESC"
        'vform.vFormatstring = "  UOMCODE           |                 UOMDESC                         "
        vform.vCaption = "FACILITY CODE HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssGrid
                .Col = 5
                .Row = .ActiveRow
                .Text = vform.keyfield
            End With
        Else
            ssGrid.SetActiveCell(5, ssGrid.ActiveRow)
            Exit Sub
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_Discount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Discount.KeyPress
        Dim Taxamt, Totalamt, Packamt, cancel As String
        Dim i As Integer
        If Asc(e.KeyChar) = 13 Then
            If Val(txt_Discount.Text) > 0 Then
                Me.txt_TotalValue.Text = 0
                Me.txt_TaxValue.Text = 0
                Me.Txt_Charges.Text = 0
                For i = 1 To ssGrid.DataRowCnt
                    cancel = Nothing
                    Taxamt = Nothing
                    Totalamt = Nothing
                    Packamt = Nothing
                    ssGrid.GetText(12, i, cancel)
                    If Val(cancel) = 0 Then
                        ssGrid.GetText(7, i, Taxamt)
                        ssGrid.GetText(8, i, Totalamt)
                        ssGrid.GetText(18, i, Packamt)
                        Me.txt_TotalValue.Text = Format(Val(Me.txt_TotalValue.Text) + Val(Totalamt), "0.00")
                        Me.txt_TaxValue.Text = Format(Val(Me.txt_TaxValue.Text) + Val(Taxamt), "0.00")
                        Me.Txt_Charges.Text = Format(Val(Me.Txt_Charges.Text) + Val(Packamt), "0.00")
                    End If
                Next i
                dbldicountAmount = (Val(txt_TotalValue.Text) * Val(txt_Discount.Text)) / 100
                dblGrossAmount = Val(txt_TotalValue.Text) - Val(dbldicountAmount)
                dbldicountTax = (Val(txt_TaxValue.Text) * Val(txt_Discount.Text)) / 100
                dblGrossTax = Val(txt_TaxValue.Text) - Val(dbldicountTax)
                dbldicountPack = (Val(Txt_Charges.Text) * Val(txt_Discount.Text)) / 100
                dblGrossPack = Val(Txt_Charges.Text) - Val(dbldicountPack)
                dblDicountBillAmount = dblGrossAmount + dblGrossTax + dblGrossPack
                Me.txt_TotalValue.Text = Format(Val(dblGrossAmount), "0.00")
                Me.txt_TaxValue.Text = Format(Val(dblGrossTax), "0.00")
                Me.Txt_Charges.Text = Format(Val(dblGrossPack), "0.00")
                If BILLROUNDYESNO = "YES" Then
                    Me.txt_BillAmount.Text = Format(Math.Round(Val(dblDicountBillAmount)), "0.00")
                Else
                    Me.txt_BillAmount.Text = Format(Val(dblDicountBillAmount), "0.00")
                End If
                Cmd_Add.Focus()
            End If
        End If
    End Sub
    Private Sub ssgridPayment_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgridPayment.KeyDownEvent
        Dim Sqlstring, Itemdesc, Promtcode, Billdetailswise As String
        Dim varBillCode, varBillDate, varPaymentMode, varMcode, varMName As String
        Dim dblBillamount, dblAmount1, dblAmount2, dblAmount3 As Decimal
        Dim i, j, count As Integer
        Try
            If e.keyCode = Keys.Enter Then
                i = ssgridPayment.ActiveRow
                If ssgridPayment.ActiveCol = 1 Then
                    ssgridPayment.Row = ssgridPayment.ActiveRow
                    ssgridPayment.Col = 1
                    If Trim(ssgridPayment.Text) = "" Then
                        ssgridPayment.SetActiveCell(2, ssgridPayment.ActiveRow)
                        ssgridPayment.Focus()
                    ElseIf Trim(ssgridPayment.Text) <> "" Then
                        ssgridPayment.SetActiveCell(2, ssgridPayment.ActiveRow)
                        ssgridPayment.Focus()
                    End If
                ElseIf ssgridPayment.ActiveCol = 2 Then
                    ssgridPayment.Row = ssgridPayment.ActiveRow
                    ssgridPayment.Col = 2
                    If Trim(ssgridPayment.Text) = "" Then
                        ssgridPayment.SetActiveCell(2, ssgridPayment.ActiveRow)
                        ssgridPayment.Focus()
                    ElseIf Trim(ssgridPayment.Text) <> "" Then
                        ssgridPayment.SetActiveCell(2, ssgridPayment.ActiveRow)
                        ssgridPayment.Focus()
                    End If
                ElseIf ssgridPayment.ActiveCol = 3 Then
                    ssgridPayment.Row = ssgridPayment.ActiveRow
                    ssgridPayment.Col = 3
                    If ssgridPayment.Lock = False Then
                        ssgridPayment.Col = 3
                        ssgridPayment.Row = ssgridPayment.ActiveRow
                        If Trim(ssgridPayment.Text) = "" Then
                            ssgridPayment.SetActiveCell(2, ssgridPayment.ActiveRow)
                        Else
                            Sqlstring = " SELECT ISNULL(Paymentcode,'') AS Paymentcode,ISNULL(paymentType,'') AS paymentType  FROM paymentmodemaster WHERE Paymentcode = '" & Trim(ssgridPayment.Text) & "' AND ISNULL(Freeze,'')='N'"
                            gconnection.getDataSet(Sqlstring, "paymentmodemaster")
                            If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                                If Trim(ssgridPayment.Text) = Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("Paymentcode")) And Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CD" Then
                                    gridRow = 0
                                    gridRow = ssgridPayment.ActiveRow
                                    grp_Carddetails.Top = 24
                                    grp_Carddetails.Left = 344
                                    grp_Carddetails.Focus()
                                    txt_Typeofcard.Focus()
                                ElseIf Trim(ssgridPayment.Text) = Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("Paymentcode")) And Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CQ" Then
                                    gridRow = 0
                                    gridRow = ssgridPayment.ActiveRow
                                    grp_Chequedetails.Top = 24
                                    grp_Chequedetails.Left = 344
                                    grp_Chequedetails.Focus()
                                    cbo_Typeofcheque.SelectedIndex = 0
                                    cbo_Typeofcheque.Focus()
                                Else
                                    ssgridPayment.SetActiveCell(3, ssgridPayment.ActiveRow)
                                    ssgridPayment.Focus()
                                End If
                            Else
                                ssgridPayment.SetActiveCell(3, ssgridPayment.ActiveRow)
                                ssgridPayment.Focus()
                            End If
                        End If
                    End If
                ElseIf ssgridPayment.ActiveCol = 4 Then
                    ssgridPayment.Row = ssgridPayment.ActiveRow
                    ssgridPayment.Col = 1
                    Billdetailswise = Trim(ssgridPayment.Text)
                    ssgridPayment.Row = ssgridPayment.ActiveRow
                    ssgridPayment.Col = 4
                    If ssgridPayment.Lock = False Then
                        ssgridPayment.Row = ssgridPayment.ActiveRow
                        ssgridPayment.Col = 4
                        If Val(ssgridPayment.Text) = 0 Then
                            ssgridPayment.SetActiveCell(3, ssgridPayment.ActiveRow)
                            ssgridPayment.Focus()
                        ElseIf Val(ssgridPayment.Text) <> 0 Then
                            For i = 1 To ssgridPayment.DataRowCnt
                                ssgridPayment.Col = 1
                                ssgridPayment.Row = i
                                If ssgridPayment.Text = Billdetailswise Then
                                    ssgridPayment.Col = 4
                                    ssgridPayment.Row = i
                                    dblAmount3 = dblAmount3 + Val(ssgridPayment.Text)
                                End If
                            Next
                            ssgridPayment.Row = ssgridPayment.ActiveRow
                            ssgridPayment.Col = 7
                            dblAmount1 = Val(ssgridPayment.Text)
                            ssgridPayment.Row = ssgridPayment.ActiveRow
                            ssgridPayment.Col = 4
                            dblAmount2 = Val(ssgridPayment.Text)
                            If Val(dblAmount3) <= Val(dblAmount1) Then
                                txt_PartialPayment.Text = Format(Val(dblAmount1) - Val(dblAmount3), "0.00")
                                ssgridPayment.Row = ssgridPayment.ActiveRow
                                ssgridPayment.Col = 8
                                If Val(Gridbillamount) <> 0 Then
                                    ssgridPayment.Col = 8
                                    ssgridPayment.Row = ssgridPayment.ActiveRow
                                    ssgridPayment.Text = Format(Val(dblAmount1) - Val(dblAmount3), "0.00")
                                    Gridbillamount = Format(Val(dblAmount1) - Val(dblAmount3), "0.00")
                                    If Val(Gridbillamount) = 0 Then
                                        ssgridPayment.SetActiveCell(3, ssgridPayment.ActiveRow)
                                        cmd_Save.Focus()
                                        Exit Sub
                                    Else
                                        ssgridPayment.Col = 1
                                        ssgridPayment.Row = ssgridPayment.ActiveRow + 1
                                        ssgridPayment.Text = Trim(Billdetailswise)
                                        ssgridPayment.Col = 2
                                        ssgridPayment.Row = ssgridPayment.ActiveRow + 1
                                        ssgridPayment.Text = Format(CDate(dtp_KOTdate.Value), "dd/MMM/yyyy")
                                        ssgridPayment.Col = 5
                                        ssgridPayment.Row = ssgridPayment.ActiveRow + 1
                                        ssgridPayment.Text = Trim(BillMcode)
                                        ssgridPayment.Col = 6
                                        ssgridPayment.Row = ssgridPayment.ActiveRow + 1
                                        ssgridPayment.Text = Trim(BillMname)
                                        ssgridPayment.Col = 7
                                        ssgridPayment.Row = ssgridPayment.ActiveRow + 1
                                        ssgridPayment.Text = Format(Val(dblBillTotalAmount), "0.00")
                                        ssgridPayment.Row = ssgridPayment.ActiveRow + 1
                                        ssgridPayment.Col = 3
                                        ssgridPayment.Lock = False
                                        ssgridPayment.Col = 4
                                        ssgridPayment.Lock = False
                                        Call FillPaymentmodeSettlement(ssgridPayment.ActiveRow + 1)
                                        ssgridPayment.SetActiveCell(2, ssgridPayment.ActiveRow + 1)
                                        ssgridPayment.Focus()
                                    End If
                                End If
                            Else
                                MessageBox.Show("You Can't enter more amount then Billamount", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                ssgridPayment.Col = 4
                                ssgridPayment.Row = ssgridPayment.ActiveRow
                                ssgridPayment.Text = ""
                                ssgridPayment.SetActiveCell(3, ssgridPayment.ActiveRow)
                                ssgridPayment.Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf ssgridPayment.ActiveCol = 5 Then
                    ssgridPayment.Row = ssgridPayment.ActiveRow
                    ssgridPayment.Col = 5
                    If Trim(ssgridPayment.Text) = "" Then
                        ssgridPayment.SetActiveCell(4, i)
                        ssgridPayment.Focus()
                    ElseIf Trim(ssgridPayment.Text) <> "" Then
                        ssgridPayment.SetActiveCell(2, ssgridPayment.ActiveRow + 1)
                        ssgridPayment.Focus()
                    End If
                ElseIf ssgridPayment.ActiveCol = 6 Then
                    ssgridPayment.Row = ssgridPayment.ActiveRow
                    ssgridPayment.Col = 6
                    If Trim(ssgridPayment.Text) = "" Then
                        ssgridPayment.SetActiveCell(5, i)
                        ssgridPayment.Focus()
                    ElseIf Trim(ssgridPayment.Text) <> "" Then
                        ssgridPayment.SetActiveCell(2, ssgridPayment.ActiveRow + 1)
                        ssgridPayment.Focus()
                    End If
                End If
            End If
        Catch EX As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub cmd_Back_Click(sender As Object, e As EventArgs) Handles cmd_Back.Click
        grp_Paymentmodeselection.Top = 1000
        grp_Carddetails.Top = 1000
        grp_Chequedetails.Top = 1000
    End Sub

    Private Sub cmd_Cancel_Click(sender As Object, e As EventArgs) Handles cmd_Cancel.Click
        ssgridPayment.ClearRange(1, 1, -1, -1, True)
        ssgridPayment.SetActiveCell(1, 1)
        txt_Cardholdername.Text = ""
        txt_PartialPayment.Text = ""
        txt_Chequeno.Text = ""
        txt_Draweebank.Text = ""
        txt_Typeofcard.Text = ""
        txt_Cardno.Text = ""
    End Sub
    Private Sub txt_Typeofcard_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Typeofcard.KeyPress
        Call getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            txt_Cardno.Focus()
        End If
    End Sub
    Private Sub txt_Cardno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Cardno.KeyPress
        Call getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            dtp_Expirydate.Focus()
        End If
    End Sub

    Private Sub dtp_Expirydate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp_Expirydate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txt_Cardholdername.Focus()
        End If
    End Sub
    Private Sub txt_Cardholdername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Cardholdername.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ssgridPayment.SetActiveCell(4, gridRow)
            ssgridPayment.Focus()
            grp_Carddetails.Top = 1000
        End If
    End Sub

    Private Sub cbo_Typeofcheque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_Typeofcheque.KeyPress
        Call Blank(e)
        If Asc(e.KeyChar) = 13 Then
            txt_Chequeno.Focus()
        End If
    End Sub
    Private Sub txt_Chequeno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Chequeno.KeyPress
        Call getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            dtp_Chequedate.Focus()
        End If
    End Sub
    Private Sub dtp_Chequedate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp_Chequedate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txt_Draweebank.Focus()
        End If
    End Sub
    Private Sub txt_Draweebank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Draweebank.KeyPress
        Call getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            ssgridPayment.SetActiveCell(4, gridRow)
            ssgridPayment.Focus()
            grp_Chequedetails.Top = 1000
        End If
    End Sub
    Private Sub cmd_Save_Click(sender As Object, e As EventArgs) Handles cmd_Save.Click
        grp_Paymentmodeselection.Top = 1000
        Cmd_Add.Focus()
    End Sub

    Private Sub Txt_Remarks_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Remarks.KeyDown
        If e.KeyCode = Keys.K Then
            Txt_Remarks.Text = "OT NO :"
        End If
    End Sub

    Private Sub Txt_Remarks_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Remarks.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cmd_Add.Focus()
        End If
    End Sub
    Private Function SpiltBill()
        Dim tempamt As Double
        Dim mcode As String
        LAB_BALANCEAMT.Text = "BALANCE AMOUNT:"
        Try
            With ssgrid_settlement
                tempamt = 0.0
                For I = 1 To ssgrid_settlement.DataRowCnt
                    .Col = 2
                    .Row = I
                    tempamt = tempamt + Val(.Text)
                Next
            End With
            LAB_BALANCEAMT.Text = LAB_BALANCEAMT.Text & Format(Math.Round(Val(txt_BillAmount.Text - tempamt), 2), "0.00")
            If tempamt <> Val(txt_BillAmount.Text) Then
                Return "True"
            Else
                Return "False"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Function MEMBER_VALIDACTION()
        Dim strstring, MCODE As String
        Dim J As Int16
        Try
            With ssgrid_settlement
                .Row = .ActiveRow
                .Col = 1
                If Trim(.Text) <> "" Then
                    strstring = "SELECT ISNULL(MCODE,'') AS MCODE,ISNULL(MNAME,'') AS MNAME,ISNULL(CRIDITNUMBER,'') AS CRIDITNUMBER FROM membermaster WHERE MCODE='" & Trim(.Text) & "'"
                    gconnection.getDataSet(strstring, "membermaster")
                    If gdataset.Tables("membermaster").Rows.Count = 0 Then
                        Return "True"
                    Else
                        For I = 1 To ssgrid_settlement.DataRowCnt
                            .Col = 1
                            .Row = I
                            MCODE = Trim(.Text)
                            For J = 1 To ssgrid_settlement.DataRowCnt
                                .Col = 1
                                .Row = J
                                If MCODE = Trim(.Text) And I <> J Then
                                    ssgrid_settlement.Row = ssgrid_settlement.ActiveRow
                                    ssgrid_settlement.DeleteRows(ssgrid_settlement.ActiveRow, 1)
                                    Call SpiltBill()
                                End If
                            Next
                        Next
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            ' txt_MemberCode.Focus()
            Exit Function
        End Try
    End Function
    Private Function member_help()
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT mcode,mname FROM Membermaster"
        M_WhereCondition = ""
        vform.Field = " MCODE,MNAME "
        'vform.vFormatstring = "                 MEMBER CODE            |                 MEMBER NAME                                "
        vform.vCaption = "MEMBER MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If ssgrid_settlement.ActiveCol = 1 Then
                ssgrid_settlement.Col = 1
                ssgrid_settlement.Row = ssgrid_settlement.ActiveRow
                ssgrid_settlement.Text = Trim(vform.keyfield & "")
                ssgrid_settlement.SetActiveCell(1, ssgrid_settlement.ActiveRow)
            End If
        End If
        vform.Close()
        vform = Nothing
    End Function
    Private Sub ssgrid_settlement_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid_settlement.KeyDownEvent
        If e.keyCode = Keys.F3 Then
            ssgrid_settlement.Row = ssgrid_settlement.ActiveRow
            ssgrid_settlement.DeleteRows(ssgrid_settlement.ActiveRow, 1)
            Call SpiltBill()
        End If
        If e.keyCode = Keys.Enter Then
            With ssgrid_settlement
                .Row = .ActiveRow
                .Col = 1
                If .ActiveCol = 1 And Trim(.Text) = "" Then
                    Call member_help()
                End If
                If MEMBER_VALIDACTION() = "True" Then
                    .Col = 1
                    .Text = ""
                    MessageBox.Show("Invalid Member Code Plz try once again", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    .Focus()
                End If

                .Col = 2
                If .ActiveCol = 2 And Val(Trim(.Text)) > 0 Then
                    Call SpiltBill()
                End If
            End With
        End If
        If e.keyCode = Keys.F4 Then
            If ssgrid_settlement.ActiveCol = 1 Then
                Call member_help()
            End If
        End If
    End Sub

    Private Sub ssgrid_settlement_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid_settlement.LeaveCell
        With ssgrid_settlement
            .Row = .ActiveRow
            .Col = 1
            If .ActiveCol = 1 Then
            End If
            .Row = .ActiveRow
            .Col = 2
            If .ActiveCol = 2 Then
                SpiltBill()
            End If
        End With
    End Sub
    Private Sub CMD_SETTLEMENT_Click(sender As Object, e As EventArgs) Handles CMD_SETTLEMENT.Click
        If ssGrid.DataRowCnt > 0 Then
            If SpiltBill() = "True" Then
                MessageBox.Show("Settlement Amount Not Tallyed :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                SETLEMENT_GROUP.Visible = True
                ssgrid_settlement.Focus()
            Else
                SETLEMENT_GROUP.Visible = False
            End If
        End If
    End Sub
    Private Sub txt_BillAmount_Validated(sender As Object, e As EventArgs) Handles txt_BillAmount.Validated
        'SETTLEMENT
        'BEGIN
        If Val(Trim(txt_BillAmount.Text)) > 0 Then
            With ssgrid_settlement
                If ssgrid_settlement.DataRowCnt = 1 Then
                    .Col = 1
                    .Row = 1
                    .Text = ""
                    '.Text = Trim(txt_MemberCode.Text)
                    .Col = 2
                    .Row = 1
                    .Text = ""
                    .Text = Trim(txt_BillAmount.Text)
                    'End If
                End If
            End With
        End If
        'SETTLEMENT
        'END
    End Sub
    Private Sub dtp_KOTdate_ValueChanged(sender As Object, e As EventArgs) Handles dtp_KOTdate.ValueChanged
        Call autogenerate()
    End Sub
    Private Sub SSGRID_MEM_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID_MEM.KeyDownEvent
        Dim i, j, k, bookno, chitno As Integer
        Dim memcode As String
        Dim strstring As String
        Dim SSQL As String
        Dim CLIMIT, PLIMIT As Double
        With SSGRID_MEM
            i = .ActiveRow
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = i
                    memcode = Trim(.Text)
                    If Trim(memcode) = "" Then
                        Call fillmember()
                    ElseIf Trim(memcode) <> "" Then
                        If cbo_PaymentMode.Text = "ROOM" Then
                            strstring = "Select roomno,guest,docno From roomcheckin Where isnull(checkout,'') <> 'Y' and roomstatus='occupied' AND RoomNo='" & Trim(memcode) & "'"
                            gconnection.getDataSet(strstring, "RoomCheckin")
                            If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                                .Col = 1
                                .Row = i
                                .Text = gdataset.Tables("RoomCheckin").Rows(0).Item("RoomNo")
                                .Col = 2
                                .Row = i
                                .Text = gdataset.Tables("RoomCheckin").Rows(0).Item("Guest")
                                .Col = 3
                                .Row = i
                                If Trim(.Text) = "" Then
                                    .Text = ""
                                    .Text = Val(i) + Val(LBL_DOCNO.Text)
                                    .SetActiveCell(0, i + 1)
                                    .Focus()
                                End If
                            Else
                                .ClearRange(1, i, 25, i, True)
                                .DeleteRows(i, 1)
                                .SetActiveCell(0, i)
                                .Focus()
                                Exit Sub
                            End If
                        ElseIf cbo_PaymentMode.Text = "CLUB" Then
                            strstring = "SELECT slcode,slname FROM accountssubledgermaster WHERE SLCODE='" & Trim(memcode) & "'"
                            gconnection.getDataSet(strstring, "RoomCheckin")
                            If gdataset.Tables("RoomCheckin").Rows.Count > 0 Then
                                .Col = 1
                                .Row = i
                                .Text = gdataset.Tables("RoomCheckin").Rows(0).Item("slcode")
                                .Col = 2
                                .Row = i
                                .Text = gdataset.Tables("RoomCheckin").Rows(0).Item("slname")
                                .Col = 3
                                If Trim(.Text) = "" Then
                                    .Text = ""
                                    .Text = Val(i) + Val(LBL_DOCNO.Text)
                                    .SetActiveCell(0, i + 1)
                                    .Focus()
                                End If
                            Else
                                .ClearRange(1, i, 25, i, True)
                                .DeleteRows(i, 1)
                                .SetActiveCell(0, i)
                                .Focus()
                                Exit Sub
                            End If
                        Else
                            strstring = "SELECT isnull(A.mcode,'') as mcode,isnull(A.mname,'') as mname,isnull(curentstatus,'') as termination FROM membermaster A WHERE A.MCODE='" & Trim(memcode) & "'"
                            gconnection.getDataSet(strstring, "membermaster")
                            If gdataset.Tables("membermaster").Rows.Count > 0 Then
                                Dim name
                                name = gdataset.Tables("membermaster").Rows(0).Item("TERMINATION")
                                '                                gDebtors = gdataset.Tables("membermaster").Rows(0).Item("MEMBERSLCODE")
                                '                               gDebitors = gdataset.Tables("membermaster").Rows(0).Item("MEMBERSLCODE")
                                Select Case Trim(name)
                                    Case "LIVE"
                                        Txt_Remarks.Text = ""
                                        .Col = 1
                                        .Row = i
                                        .Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                                        .Col = 2
                                        .Row = i
                                        .Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                                        .Col = 3
                                        If Trim(.Text) = "" Then
                                            .Text = ""
                                            .Text = Val(i) + Val(LBL_DOCNO.Text)
                                            .SetActiveCell(0, i + 1)
                                            .Focus()
                                        End If

                                    Case "ACTIVE"
                                        Txt_Remarks.Text = ""
                                        .Col = 1
                                        .Row = i
                                        .Text = gdataset.Tables("membermaster").Rows(0).Item("MCODE")
                                        .Col = 2
                                        .Row = i
                                        .Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                                        .Col = 3
                                        If Trim(.Text) = "" Then
                                            .Text = ""
                                            .Text = Val(i) + Val(LBL_DOCNO.Text)
                                            .SetActiveCell(0, i + 1)
                                            .Focus()
                                        End If

                                    Case Else
                                        .Col = 1
                                        .Row = i
                                        .Text = "MEMBERSHIP " & name & "."
                                        .Col = 2
                                        .Row = i
                                        .Text = gdataset.Tables("membermaster").Rows(0).Item("MNAME")
                                End Select
                                If Trim(Txt_Remarks.Text) = "" Then
                                    Dim sqlstring As String
                                    Dim prvbal, curbal, present, rcd, clsbal, asonbal As Double
                                    sqlstring = "exec cp_creditlimit '" & Format(dtp_KOTdate.Value, "dd MMM yyyy") & "','" & Trim(gDebtors) & "','" & Trim(memcode) & "'"
                                    gconnection.getDataSet(sqlstring, "CP_CREDIT")
                                    sqlstring = "select ISNULL(PLIMIT,0) AS PLIMIT,ISNULL(CLIMIT,0) AS CLIMIT,ISNULL(SUM(ISNULL(CDR,0)),0)-ISNULL(SUM(ISNULL(CCR,0)),0) AS CAMOUNT,ISNULL(SUM(ISNULL(PDR,0)),0)-ISNULL(SUM(ISNULL(PCR,0)),0) AS PAMOUNT from CREDITSTOP_MCODE WHERE MCODE='" & Trim(memcode) & "' GROUP BY PLIMIT,CLIMIT"
                                    gconnection.getDataSet(sqlstring, "CP_CRLIMIT")
                                    If gdataset.Tables("CP_CRLIMIT").Rows.Count > 0 Then
                                        curbal = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("CAMOUNT")
                                        prvbal = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("PAMOUNT")
                                        CLIMIT = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("CLIMIT")
                                        PLIMIT = gdataset.Tables("CP_CRLIMIT").Rows(0).Item("PLIMIT")
                                    Else
                                        curbal = 0
                                        prvbal = 0
                                        CLIMIT = 0
                                        PLIMIT = 0
                                    End If

                                    prvbal = 0
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
                                    If Trim(cbo_PaymentMode.Text) = "CREDIT" Or Trim(cbo_PaymentMode.Text) = "CASH" Then
                                        ''If curbal > CLIMIT Or prvbal > PLIMIT Then
                                        ''    MsgBox("Member is in Credit Stop List...  " & LABDUE.Text, MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "Credit Limit Exceed")
                                        ''    crstopmsg = "Member is in Credit Stop List... "
                                        ''    strstring = "select * from membermaster where isnull(creditstopdate,'')<'" & Format(dtp_KOTdate.Value, "yyyy-MMM-dd") & "' and isnull(creditstopflag,'N') ='Y' and mcode='" & Trim(memcode) & "'"
                                        ''    gconnection.getDataSet(strstring, "membermast")
                                        ''    If gdataset.Tables("membermast").Rows.Count > 0 Then
                                        ''        MsgBox("This is the Second Time, Sorry Not Allowed....")
                                        ''    Else
                                        ''        Call BillPrintOperation_notice(curbal, CLIMIT, prvbal, PLIMIT)
                                        ''        sqlstring = "update membermaster set creditstopflag ='Y',creditstopdate='" & Format(dtp_KOTdate.Value, "yyyy-MM-dd") & "' where mcode='" & Trim(memcode) & "'"
                                        ''        gconnection.getDataSet(sqlstring, "membermast")
                                        ''    End If
                                        ''Else
                                        ''    crstopmsg = ""
                                        ''    sqlstring = "update membermaster set creditstopflag ='N',creditstopdate='" & Format(dtp_KOTdate.Value, "yyyy-MM-dd") & "' where mcode='" & Trim(memcode) & "'"
                                        ''    gconnection.getDataSet(sqlstring, "membermast")
                                        ''End If
                                        'Txt_Remarks.Text = LABDUE.Text

                                        'SSQL = "DELETE FROM CREDITSTOP_MCODE WHERE MCODE='" & Trim(memcode) & "'"
                                        'gcommand = New SqlClient.SqlCommand(SSQL, gconnection.Myconn)
                                        'gconnection.openConnection()
                                        'gcommand.ExecuteNonQuery()
                                        'gconnection.closeConnection()
                                    Else
                                        crstopmsg = ""
                                    End If
                                    'Txt_Remarks.Text = LABDUE.Text    '"L-Credit: " & Format(pcredit, "0.00") & "  L-Debit: " & Format(pdebit, "0.00") & "  L-Closing: " & Format(pclbal, "0.00") & "  C-Credit: " & Format(ccredit, "0.00") & "  C-Debit: " & Format(cdebit, "0.00") & "  C-Closing: " & Format(cclbal, "0.00")
                                End If
                            Else
                                .ClearRange(1, i, 25, i, True)
                                .DeleteRows(i, 1)
                                .SetActiveCell(0, i)
                                .Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf .ActiveCol = 2 Then
                    .Col = 2
                    .Row = i
                    If Trim(.Text) <> "" Then
                        .Col = 3
                        .Row = i
                        .Text = ""
                        .Text = Val(i) + Val(LBL_DOCNO.Text)
                        .SetActiveCell(2, i)
                        .Focus()
                    Else
                        .ClearRange(1, i, 3, i, True)
                        .DeleteRows(i, 1)
                        .SetActiveCell(0, i)
                        .Focus()
                    End If
                ElseIf .ActiveCol = 3 Then
                    .Col = 3
                    .Row = i
                    .Text = ""
                    .Text = Val(i) + Val(LBL_DOCNO.Text)
                    .SetActiveCell(0, i + 1)
                    .Focus()
                End If
            ElseIf e.keyCode = Keys.F3 Then
                .ClearRange(1, i, 3, i, True)
                .DeleteRows(i, 1)
                .SetActiveCell(0, i)
                .Focus()
            End If
        End With
    End Sub
    Private Sub Cmd_Servercode_Click(sender As Object, e As EventArgs) Handles Cmd_Servercode.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ISNULL(SERVERNAME,'') AS SERVERNAME,ISNULL(SERVERCODE,'')AS SERVERCODE FROM servermaster"
        M_WhereCondition = " WHERE ISNULL(Freeze,'') <> 'Y'"
        vform.Field = "SERVERNAME,SERVERCODE"
        'vform.vFormatstring = "      SERVER NAME          |        SERVER CODE"
        vform.vCaption = "SERVER MASTER HELP"
        'vform.KeyPos = 0
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_ServerCode.Text = Trim(vform.keyfield1 & "")
            ssGrid.SetActiveCell(1, 1)
            ssGrid.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Txt_ServerCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ServerCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_ServerCode.Text) <> "" Then
                Call Txt_ServerCode_Validated(Txt_ServerCode, e)
            Else
                Call Cmd_Servercode_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Txt_ServerCode_Validated(sender As Object, e As EventArgs) Handles Txt_ServerCode.Validated
        If Trim(Txt_ServerCode.Text) <> "" Then
            SQLSTRING = "SELECT ISNULL(SERVERCODE,'')AS SERVERCODE,ISNULL(SERVERNAME,'')AS SERVERNAME FROM SERVERMASTER "
            SQLSTRING = SQLSTRING & " WHERE SERVERCODE='" & Trim(Txt_ServerCode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(SQLSTRING, "SERVER")
            If gdataset.Tables("SERVER").Rows.Count > 0 Then
                Txt_ServerCode.Text = gdataset.Tables("SERVER").Rows(0).Item("SERVERCODE")
                Txt_ServerName.Text = gdataset.Tables("SERVER").Rows(0).Item("SERVERNAME")
                ssGrid.SetActiveCell(1, 1)
                ssGrid.Focus()
            End If
        End If
    End Sub
    Private Sub Cmd_Pos_Click(sender As Object, e As EventArgs) Handles Cmd_Pos.Click
        gSQLString = "SELECT ISNULL(Poscode,'') AS POSCODE,ISNULL(POSCODE,'') AS DOCTYPE,ISNULL(Posdesc,'') AS POSDESC FROM POSMASTER "
        M_WhereCondition = " WHERE ISNULL(Freeze,'') <> 'Y'"
        Dim vform As New LIST_OPERATION1
        vform.Field = "POSDESC,POSCODE"
        'vform.vFormatstring = "      POS CODE         |           DOC TYPE                |        POSDESC         "
        vform.vCaption = "POS Master Help"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            doctype = Trim(vform.keyfield)
            POScode = Trim(vform.keyfield)
            servicelocation = Trim(vform.keyfield)
            Me.Txt_Pos.Text = Trim(vform.keyfield)
            lbl_POS.Visible = True
            lbl_POS.Text = Trim(vform.keyfield2)
            'SALESACCTIN = Trim(vform.keyfield3 & "")
            POSUNDER = Trim(vform.keyfield1 & "")
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub Txt_Pos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Pos.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Pos.Text) = "" Then
                Call Cmd_Pos_Click(sender, e)
            Else
                Txt_Pos_Validated(Txt_Pos, e)
            End If
        End If
    End Sub
    Private Sub Txt_Pos_Validated(sender As Object, e As EventArgs) Handles Txt_Pos.Validated
        If Trim(Txt_Pos.Text) <> "" Then
            SQLSTRING = "SELECT ISNULL(B.Poscode,'') AS POSCODE,ISNULL(B.POSCODE,'') AS DOCTYPE,ISNULL(B.Posdesc,'') AS POSDESC,0 PACKINGPERCENT,'' AS SALESACCTIN FROM POSMASTER B "
            SQLSTRING = SQLSTRING & " WHERE ISNULL(B.Freeze,'') <> 'Y' and isnull(B.POSCODE,'')='" & Trim(Txt_Pos.Text) & "'"
            gconnection.getDataSet(SQLSTRING, "POS")
            If gdataset.Tables("POS").Rows.Count > 0 Then
                Txt_Pos.Text = gdataset.Tables("POS").Rows(0).Item("POSCODE")
                doctype = gdataset.Tables("POS").Rows(0).Item("POSCODE")

                doclength = Val(Len(Trim(gdataset.Tables("POS").Rows(0).Item("POSCODE")))) + 2
                servicelocation = gdataset.Tables("POS").Rows(0).Item("POSCODE")
                SALESACCTIN = gdataset.Tables("POS").Rows(0).Item("SALESACCTIN")
                POSUNDER = gdataset.Tables("POS").Rows(0).Item("POSCODE")

                lbl_POS.Visible = True
                lbl_POS.Text = gdataset.Tables("POS").Rows(0).Item("POSDESC")
                ShowBillno()
                SQLSTRING = "SELECT ISNULL(PACKINGPERCENT,0) AS PACKPER,ISNULL(TIPS,0) AS TIPS_SER,ISNULL(ADCHARGE,0) AS ADCHARGE,ISNULL(PRCHARGE,0) AS PRCHARGE,ISNULL(GRCHARGE,0) AS GRCHARGE,ISNULL(KOTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(directprefix,'') AS KOTPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ FROM POSMASTER  WHERE POSCODE = '" & Trim(Txt_Pos.Text) & "'"
                gconnection.getDataSet(SQLSTRING, "PSETUP")
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
                'TXT_ITEMCODE.Focus()
                Txt_ServerName.Focus()
                'ssGrid.SetActiveCell(1, 1)
                'ssGrid.Focus()
                Show()
            Else
                lbl_POS.Visible = False
                MsgBox("INVALID POS CODE", MsgBoxStyle.Information)
                Txt_Pos.Text = ""
                Txt_Pos.Focus()
                Show()
            End If
        End If
    End Sub

    Private Sub CMD_ITEMCODE_Click(sender As Object, e As EventArgs) Handles CMD_ITEMCODE.Click
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
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(StrPOSCODE) & "' "
        End If

        If Trim(Search) = " " Then
            If gCenterlized = "Y" Then
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink)"
            Else
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(StrPOSCODE) & "')"
            End If
        Else
            If gCenterlized = "Y" Then
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink) AND (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            Else
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(StrPOSCODE) & "' ) and (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            End If
        End If
        vform.Field = "I.ITEMDESC,I.ITEMCODE"
        'vform.vFormatstring = "  ITEMCODE           |                 ITEMDESC                  |  POSCODE     |  ITEMTYPECODE  |  TAXCODE  | TAXPERCENTAGE | ACCOUNTCODE | SALESACCTIN |  GROUPCODE | PROMITEMCODE | PACKINGPERCENT "
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
        'vform.Keypos11 = 11
        'vform.Keypos12 = 12
        'vform.Keypos13 = 13
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_ITEMCODE.Text = Trim(vform.keyfield)
            TXT_ITEMNAME.Text = Trim(vform.keyfield1)
            Call TXT_ITEMCODE_Validated(TXT_ITEMCODE, e)
            ssGrid.SetActiveCell(1, 1)
            ssGrid.Focus()
            'doctype = Trim(vform.keyfield1)
            'POScode = Trim(vform.keyfield1)
            'servicelocation = Trim(vform.keyfield1)
            'Me.Txt_Pos.Text = Trim(vform.keyfield1)
            'lbl_POS.Visible = True
            'lbl_POS.Text = Trim(vform.keyfield)
            'SALESACCTIN = Trim(vform.keyfield3 & "")
            'POSUNDER = Trim(vform.keyfield4 & "")
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub TXT_ITEMCODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_ITEMCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_ITEMCODE.Text) <> "" Then
                Call TXT_ITEMCODE_Validated(TXT_ITEMCODE, e)
            Else
                Call CMD_ITEMCODE_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub TXT_ITEMCODE_Validated(sender As Object, e As EventArgs) Handles TXT_ITEMCODE.Validated
        If Trim(TXT_ITEMCODE.Text) <> "" Then
            'SQLSTRING = "SELECT ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(PL.POS,'') AS POS,ISNULL(TL.TAXCODE,'') AS TAXCODE,ISNULL(TL.TAXPERCENTAGE,0) AS TAXPERCENTAGE,"
            'SQLSTRING = SQLSTRING & " ISNULL(TL.ACCOUNTCODE,'') AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL ,ISNULL(I.PROMITEMCODE,'') AS PROMITEMCODE, ISNULL(I.SALESACCTIN,'') AS SALESACCTIN,"
            'SQLSTRING = SQLSTRING & " ISNULL(P.PACKINGPERCENT,0) AS PACKINGPERCENT, ISNULL(OPENFACILITY,'') AS OPENFACILITY,ISNULL(P.PACKINGACCTIN,'') AS PACKINGACCTIN "

            'SQLSTRING = SQLSTRING & " FROM ITEMMASTER AS I INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
            'SQLSTRING = SQLSTRING & " INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE  "

            'SQLSTRING = SQLSTRING & " WHERE I.ITEMCODE = '" & Trim(TXT_ITEMCODE.Text) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'  AND PL.POS='" & Trim(POSUNDER) & "'"
            SQLSTRING = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,"
            SQLSTRING = SQLSTRING & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE,I.OPENFACILITY,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
            If gCenterlized = "Y" Then
                SQLSTRING = SQLSTRING & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
                SQLSTRING = SQLSTRING & " WHERE i.itemcode in(select itemcode from posmenulink ) and I.ITEMCODE = '" & Trim(TXT_ITEMCODE.Text) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
            Else
                SQLSTRING = SQLSTRING & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(StrPOSCODE) & "' "
                SQLSTRING = SQLSTRING & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(StrPOSCODE) & "') and I.ITEMCODE = '" & Trim(TXT_ITEMCODE.Text) & "' AND '" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(dtp_KOTdate.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
            End If
            gconnection.getDataSet(SQLSTRING, "ITEMCODE")
            If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                TXT_ITEMCODE.Text = gdataset.Tables("ITEMCODE").Rows(0).Item("ITEMCODE")
                TXT_ITEMNAME.Text = gdataset.Tables("ITEMCODE").Rows(0).Item("ITEMDESC")
                ITEMCODE = gdataset.Tables("ITEMCODE").Rows(0).Item("ITEMCODE")
                '                UOMCODE = gdataset.Tables("ITEMCODE").Rows(0).Item("UOMCODE")
                ssGrid.SetActiveCell(1, 1)
                ssGrid.Focus()
            End If
        End If
        Call autogenerate()
    End Sub

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        Dim Totalamount, Taxamount, Calamount, Caltax, CalBilamount, calhighratio, CardAmount, Billroundoff, dblCard, dblMinimum, Roundoff1 As Double
        Dim cancelamt, canceltax, cancel, SubpaymentMode(), paymentaccountcode, Roundaccountcode, Subpaymentaccountcode, Round, jrnsql, jrnsql1 As String
        Dim Taxamt, Totalamt, Packamt, DiscAmt, costinguom, Billdetails, Roundedvalue() As String
        Dim Oldtaxbilldetails, Oldtaxbillno, Oldnontaxbilldetails, Oldnontaxbillno, OldOtherbillno As String
        Dim TaxTotal, total, size, i, j, Z As Double
        Dim TaxApp, NoTax, Otherbool As Boolean
        Dim Taxdr(), NoTaxDr() As DataRow
        Dim Kot_Bill As New DataTable
        Dim taxbilldetails, taxbillno, nontaxbilldetails, nontaxbillno, Otherbillno, STRSQL As String
        Dim sqlstring, varchk, VarSql As String
        Dim Insert(0), Update2(0), caldoublevalue As String
        Dim Gridbool As Boolean
        Dim Qty As Integer
        Dim PAmt, TAmt, AAmt, PaAmt, RAmt As Double
        'REFERINVENTORY**********************************************************************************************
        Dim POSLOCATION, POSITEMCODE, POSITEMUOM, MCODE, MNAME, SCODE, SNAME As String
        Dim AVGRATE, AVGQUANTITY, dblCalqty As Double
        Dim K, LOOPINDEX, BOOKNO, CHITNO As Integer
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, Pos, KStatus As String
        Dim TPercent, RoomPer, PartyPer As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, PKOTAMT As Double

        'DELETE FROM BILL_DET WHERE BILLDETAILS IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO =3 AND ISNULL(TTYPE,'')='S') 
        'DELETE FROM BILL_HDR WHERE BILLDETAILS IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO =3 AND ISNULL(TTYPE,'')='S') 
        'DELETE FROM BILLSETTLEMENT WHERE BILLNO IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO =3 AND POSCODE='ENT'  AND ISNULL(TTYPE,'')='S')
        'DELETE FROM BILL_JOURNALENTRY WHERE VOUCHERNO IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO =3 AND ISNULL(TTYPE,'')='S')
        'DELETE FROM SUBSTORECONSUMPTIONDETAIL WHERE DOCDETAILS IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO =3 AND ISNULL(TTYPE,'')='S')
        'DELETE FROM KOT_HDR WHERE TRANSNO=3 AND ISNULL(TTYPE,'')='S'
        'DELETE FROM KOT_DET WHERE TRANSNO=3 AND ISNULL(TTYPE,'')='S'

        '************************************************************************************************************
        loccode = ""
        sqlstring = "SELECT ISNULL(POSCLOSE,'N') AS POSCLOSE FROM MONTHCLOSE WHERE MONTHNO=" & Month(dtp_KOTdate.Value)
        gconnection.getDataSet(sqlstring, "MONTHCLOSE")
        If gdataset.Tables("MONTHCLOSE").Rows.Count > 0 Then
            If gdataset.Tables("MONTHCLOSE").Rows(0).Item("POSCLOSE") = "Y" Then
                MsgBox("ACCOUNT POSTING ALREADY DONE...........")
                Exit Sub
            End If
        End If

        'Call checkvalidate() '''---> Check Validation
        'If chkbool = False Then Exit Sub


        Me.txt_TotalValue.Text = 0
        Me.txt_TaxValue.Text = 0
        Me.Txt_Charges.Text = 0
        For i = 1 To ssGrid.DataRowCnt
            cancel = Nothing
            Taxamt = Nothing
            Totalamt = Nothing
            Packamt = Nothing
            ssGrid.GetText(12, i, cancel)
            If Val(cancel) = 0 Then
                ssGrid.GetText(7, i, Taxamt)
                ssGrid.GetText(8, i, Totalamt)
                ssGrid.GetText(18, i, Packamt)
                Me.txt_TotalValue.Text = Format(Val(Me.txt_TotalValue.Text) + Val(Totalamt), "0.00")
                Me.txt_TaxValue.Text = Format(Val(Me.txt_TaxValue.Text) + Val(Taxamt), "0.00")
                Me.Txt_Charges.Text = Format(Val(Me.Txt_Charges.Text) + Val(Packamt), "0.00")
            End If
        Next i
        'If Val(txt_Discount.Text) = 0 Then
        '    Billroundoff = Val(Me.txt_TotalValue.Text) + Val(Me.txt_TaxValue.Text) + Val(Me.Txt_Charges.Text)
        '    Round = CStr(Billroundoff)
        '    If BILLROUNDYESNO = "YES" Then
        '        If Round.IndexOf(".") <= 0 Then
        '            Round = Round.Insert(Round.Length - 1, ".00")
        '        End If
        '        Roundedvalue = Split(Round, ".")
        '        If Format(Val(Roundedvalue(1)), "00") = 50 Then
        '            Billroundoff = Math.Ceiling(Billroundoff)
        '        ElseIf Format(Val(Roundedvalue(1)), "00") > 50 Then
        '            Billroundoff = Math.Ceiling(Billroundoff)
        '        Else
        '            Billroundoff = Math.Floor(Billroundoff)
        '        End If
        '        Roundoff1 = Mid(Format(Val(Billroundoff), "0.00"), Len(Format(Val(Billroundoff), "0.00")) - 1, Len(Format(Val(Billroundoff), "0.00")))
        '        If Format(Val(Roundoff1), "00") = 50 Then
        '            Billroundoff = Math.Ceiling(Billroundoff)
        '        ElseIf Format(Val(Roundoff1), "00") > 50 Then
        '            Billroundoff = Math.Ceiling(Billroundoff)
        '        Else
        '            Billroundoff = Math.Floor(Billroundoff)
        '        End If
        '        Me.txt_BillAmount.Text = Format(Val(Billroundoff), "0.00")
        '    Else
        '        Roundoff1 = Mid(Format(Val(Billroundoff), "0.00"), Len(Format(Val(Billroundoff), "0.00")) - 1, Len(Format(Val(Billroundoff), "0.00")))
        '        Me.txt_BillAmount.Text = Format(Val(Billroundoff), "0.00")
        '    End If
        'Else
        '    dbldicountAmount = (Val(txt_TotalValue.Text) * Val(txt_Discount.Text)) / 100
        '    dblGrossAmount = Val(txt_TotalValue.Text) - Val(dbldicountAmount)
        '    dbldicountTax = (Val(txt_TaxValue.Text) * Val(txt_Discount.Text)) / 100
        '    dblGrossTax = Val(txt_TaxValue.Text) - Val(dbldicountTax)
        '    dbldicountPack = (Val(Txt_Charges.Text) * Val(txt_Discount.Text)) / 100
        '    dblGrossPack = Val(Txt_Charges.Text) - Val(dbldicountPack)
        '    dblDicountBillAmount = dblGrossAmount + dblGrossTax + dblGrossPack
        '    Me.txt_TotalValue.Text = Format(Val(dblGrossAmount), "0.00")
        '    Me.txt_TaxValue.Text = Format(Val(dblGrossTax), "0.00")
        '    Me.Txt_Charges.Text = Format(Val(dblGrossPack), "0.00")
        '    Round = CStr(dblDicountBillAmount)
        '    If BILLROUNDYESNO = "YES" Then

        '        If Round.IndexOf(".") <= 0 Then
        '            Round = Round.Insert(Round.Length - 1, ".00")
        '        End If
        '        Roundedvalue = Split(Round, ".")
        '        If Format(Val(Roundedvalue(1)), "00") = 50 Then
        '            Billroundoff = Math.Ceiling(dblDicountBillAmount)
        '        ElseIf Format(Val(Roundedvalue(1)), "00") > 50 Then
        '            Billroundoff = Math.Ceiling(dblDicountBillAmount)
        '        Else
        '            Billroundoff = Math.Floor(dblDicountBillAmount)
        '        End If
        '        Roundoff1 = Mid(Format(Val(dblDicountBillAmount), "0.00"), Len(Format(Val(dblDicountBillAmount), "0.00")) - 1, Len(Format(Val(dblDicountBillAmount), "0.00")))
        '        If Format(Val(Roundoff1), "00") = 50 Then
        '            dblDicountBillAmount = Math.Ceiling(dblDicountBillAmount)
        '        ElseIf Format(Val(Roundoff1), "00") > 50 Then
        '            dblDicountBillAmount = Math.Ceiling(dblDicountBillAmount)
        '        Else
        '            dblDicountBillAmount = Math.Floor(dblDicountBillAmount)
        '        End If
        '        Me.txt_BillAmount.Text = Format(Math.Round(Val(dblDicountBillAmount)), "0.00")
        '    Else
        '        Roundoff1 = Mid(Format(Val(dblDicountBillAmount), "0.00"), Len(Format(Val(dblDicountBillAmount), "0.00")) - 1, Len(Format(Val(dblDicountBillAmount), "0.00")))
        '        Me.txt_BillAmount.Text = Format(Val(dblDicountBillAmount), "0.00")
        '    End If
        'End If


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
        '''************************************************************* PAYMENT MODE ACCT IN *******************'''
        sqlstring = "SELECT Accountin FROM Paymentmodemaster WHERE Paymentcode ='" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(Freeze,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "Paymentmodemaster")
        If gdataset.Tables("Paymentmodemaster").Rows.Count > 0 Then
            paymentaccountcode = Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin") & "")
        Else
            MessageBox.Show("Assign a AccountCode For Specified PAYMENTMODE", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            paymentaccountcode = ""
            Exit Sub
        End If
        '''************************************************************* ROUND OFF ACCT IN *******************'''
        sqlstring = "SELECT ISNULL(ROUNDACCTIN,'') AS ROUNDACCTIN FROM POSSETUP WHERE ISNULL(ROUNDACCTIN,'') <> ''"
        gconnection.getDataSet(sqlstring, "POSSETUP")
        If gdataset.Tables("POSSETUP").Rows.Count > 0 Then
            Roundaccountcode = Trim(gdataset.Tables("POSSETUP").Rows(0).Item("ROUNDACCTIN") & "")
        Else
            'MessageBox.Show("Assign a AccountCode For Specified ROUNDOFF VALUE", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Roundaccountcode = ""
            'Exit Sub
        End If
        '''***************************************************************** INSERT INTO KOT_HDR ********************************************************************************************************'''

        If Mid(CStr(Cmd_Add.Text), 1, 1) <> "A" Then
            Call checkvalidate() '''---> Check Validation
            If chkbool = False Then Exit Sub

            sqlstring = "DELETE FROM BILL_DET WHERE BILLDETAILS IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO =" & Trim(txt_KOTno.Text) & " AND ISNULL(TTYPE,'')='S') "
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            sqlstring = "DELETE FROM BILL_HDR WHERE BILLDETAILS IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO =" & Trim(txt_KOTno.Text) & " AND ISNULL(TTYPE,'')='S') "
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            sqlstring = "DELETE FROM BILLSETTLEMENT WHERE BILLNO IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO =" & Trim(txt_KOTno.Text) & " AND POSCODE='" & Trim(POSUNDER) & "' AND ISNULL(BILLAMOUNT,0)=" & Val(txt_BillAmount.Text) & " AND ISNULL(TTYPE,'')='S')"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            sqlstring = "DELETE FROM BILL_JOURNALENTRY WHERE VOUCHERNO IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO = " & Trim(txt_KOTno.Text) & " AND ISNULL(TTYPE,'')='S')"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            sqlstring = "DELETE FROM SUBSTORECONSUMPTIONDETAIL WHERE DOCDETAILS IN (SELECT KOTDETAILS FROM KOT_DET WHERE TRANSNO = " & Trim(txt_KOTno.Text) & " AND ISNULL(TTYPE,'')='S')"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            sqlstring = "DELETE FROM KOT_HDR WHERE TRANSNO=" & Trim(txt_KOTno.Text) & " AND ISNULL(TTYPE,'')='S'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            sqlstring = "DELETE FROM KOT_DET WHERE TRANSNO=" & Trim(txt_KOTno.Text) & " AND ISNULL(TTYPE,'')='S'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            '            gconnection.MoreTransold1(Insert)
        End If

        With ssGrid
            If .DataRowCnt > 0 Then
                For LOOPINDEX = 0 To .DataRowCnt - 1

                    Call Randomize()
                    'vOutfile = Mid("jrnl" & (Rnd() * 800000), 1, 8)
                    vOutfile = "jrnl" & Trim(Txt_Pos.Text) & Format(Val(LOOPINDEX) + 1, "000000") & Trim(CStr(Format(dtp_KOTdate.Value, "yyyyMMdd"))) '& (Rnd() * 800000)
                    ReDim Preserve Update2(0)
                    Update2(0) = " Exec Jrn_Kot_Det '" & vOutfile & "'"
                    ReDim Preserve Update2(1)

                    Update2(1) = " SELECT * INTO " & vOutfile & " FROM KOT_DET WHERE 1<0 "

                    .Col = 1
                    .Row = LOOPINDEX + 1
                    MCODE = Trim(.Text)
                    .Col = 2
                    .Row = LOOPINDEX + 1
                    MNAME = Trim(.Text)
                    .Col = 25
                    .Row = LOOPINDEX + 1
                    BOOKNO = Val(.Text)

                    .Col = 8
                    .Row = LOOPINDEX + 1
                    Totalamt = Val(.Text)

                    .Col = 7
                    .Row = LOOPINDEX + 1
                    Taxamt = Val(.Text)

                    .Col = 18
                    .Row = LOOPINDEX + 1
                    PAmt = Val(.Text)
                    .Col = 27
                    .Row = LOOPINDEX + 1
                    TAmt = Val(.Text)
                    .Col = 29
                    .Row = LOOPINDEX + 1
                    AAmt = Val(.Text)
                    .Col = 31
                    .Row = LOOPINDEX + 1
                    PaAmt = Val(.Text)
                    .Col = 33
                    .Row = LOOPINDEX + 1
                    RAmt = Val(.Text)



                    Dim billamt As Double
                    billamt = Val(Totalamt) + Val(Taxamt) + Val(PAmt) + Val(TAmt) + Val(AAmt) + Val(PaAmt) + Val(RAmt)

                    SCODE = Trim(Txt_ServerCode.Text)
                    SNAME = Trim(Txt_ServerName.Text)

                    KOTno = POSUNDER & "/" & Format(Val(LBL_DOCNO.Text) + LOOPINDEX + 1, "000000") & "/" & Trim(CStr(Format(dtp_KOTdate.Value, "yyyyMMdd"))) & "/" & Trim(TXT_ITEMCODE.Text)
                    txt_KOTno.Text = Trim(CStr(KOTno))
                    If cbo_PaymentMode.SelectedItem = "ROOM" Then
                        sqlstring = "INSERT INTO KOT_HDR(BOOKNO,CHITNO,TTYPE,KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,DiscountAmt,Total,TotalTax,BillAmount,RoundOff,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                        sqlstring = sqlstring & " Receiptstatus,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Roundoffaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,transno,PackAmt,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) "
                        sqlstring = sqlstring & " VALUES (" & Val(BOOKNO) & " ,"
                        sqlstring = sqlstring & Val(BOOKNO) & " ,"
                        sqlstring = sqlstring & " 'S','" & Trim(BOOKNO) & "','" & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "'," & Val(txt_TableNo.Text) & "," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','SALE','" & Trim(accountcode) & "','" & Trim(MCODE) & "','" & Trim(MCODE) & "','" & Trim(MNAME) & "','','','',"
                        'sqlstring = sqlstring & "'" & Trim(SCODE) & "','" & Trim(SCODE) & "', "
                        sqlstring = sqlstring & "'500','500', "
                        sqlstring = sqlstring & "'" & Trim(SNAME) & "','" & Trim(cbo_PaymentMode.Text) & "', "
                        If BILLROUNDYESNO = "YES" Then
                            sqlstring = sqlstring & " 'SALE','AUTO',0," & Val(Totalamt) & "," & Val(Taxamt) & "," & Math.Round(Val(billamt)) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                        Else
                            sqlstring = sqlstring & " 'SALE','AUTO',0," & Val(Totalamt) & "," & Val(Taxamt) & "," & Val(billamt) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                            '                            sqlstring = sqlstring & " 'SALE','AUTO'," & Val(txt_Discount.Text) & "," & Val(txt_PackingCharge.Text) & "," & Val(txt_TotalValue.Text) & "," & Val(txt_TaxValue.Text) & "," & Val(txt_BillAmount.Text) & "," & Format((Val(txt_BillAmount.Text)) - (Val(txt_TotalValue.Text) + Val(txt_PackingCharge.Text) + Val(txt_TaxValue.Text)), "0.00") & ",'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                        End If
                        sqlstring = sqlstring & " 'N',0,'','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(gDebitors) & "',"
                        sqlstring = sqlstring & " '" & Trim(MCODE) & "','" & Trim(Roundaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','Y','N','','" & loccode & "'," & Val(LBL_TRANSNO.Text) & "," & PAmt & "," & TAmt & "," & AAmt & "," & PaAmt & "," & RAmt & ")"
                    ElseIf cbo_PaymentMode.SelectedItem = "CREDIT" Then
                        sqlstring = "INSERT INTO KOT_HDR(BOOKNO,CHITNO,TTYPE,KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,DiscountAmt,Total,TotalTax,BillAmount,RoundOff,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                        sqlstring = sqlstring & " Receiptstatus,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Roundoffaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,transno,PackAmt,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) "
                        sqlstring = sqlstring & " VALUES (" & Val(BOOKNO) & " ,"
                        sqlstring = sqlstring & Val(BOOKNO) & " ,"
                        sqlstring = sqlstring & " 'S','" & Trim(BOOKNO) & "','" & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "'," & Val(txt_TableNo.Text) & "," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','SALE','" & Trim(accountcode) & "','" & Trim(MCODE) & "','" & Trim(MCODE) & "','" & Trim(MNAME) & "','','','',"
                        'sqlstring = sqlstring & "'" & Trim(SCODE) & "','" & Trim(SCODE) & "', "
                        sqlstring = sqlstring & "'500','500', "
                        sqlstring = sqlstring & "'" & Trim(SNAME) & "','" & Trim(cbo_PaymentMode.Text) & "', "
                        If BILLROUNDYESNO = "YES" Then
                            sqlstring = sqlstring & " 'SALE','AUTO',0," & Val(Totalamt) & "," & Val(Taxamt) & "," & Math.Round(Val(billamt)) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                        Else
                            sqlstring = sqlstring & " 'SALE','AUTO',0," & Val(Totalamt) & "," & Val(Taxamt) & "," & Val(billamt) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                        End If
                        sqlstring = sqlstring & " 'N',0,'','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(gDebitors) & "',"
                        sqlstring = sqlstring & " '" & Trim(MCODE) & "','" & Trim(Roundaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','Y','N','','" & loccode & "'," & Val(LBL_TRANSNO.Text) & "," & PAmt & "," & TAmt & "," & AAmt & "," & PaAmt & "," & RAmt & ")"
                    Else
                        Try
                            sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                            sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                            gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                            If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                                If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) = "NO" Then
                                    sqlstring = "INSERT INTO KOT_HDR(BOOKNO,CHITNO,TTYPE,KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,Slcode,Mcode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,DiscountAmt,Total,TotalTax,BillAmount,RoundOff,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                                    sqlstring = sqlstring & " Receiptstatus,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Roundoffaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,servicelocation,transno,PackAmt,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) "
                                    sqlstring = sqlstring & " VALUES (" & Val(BOOKNO) & " ,"
                                    sqlstring = sqlstring & Val(BOOKNO) & " ,"
                                    sqlstring = sqlstring & " 'S','" & Trim(BOOKNO) & "','" & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "'," & Val(txt_TableNo.Text) & "," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','SALE','" & Trim(accountcode) & "','" & Trim(MCODE) & "',"
                                    sqlstring = sqlstring & "'" & Trim(MCODE) & "', "
                                    sqlstring = sqlstring & "'" & Trim(MNAME) & "', '','','','',"
                                    'sqlstring = sqlstring & "'" & Trim(SCODE) & "', "
                                    sqlstring = sqlstring & "'500', "
                                    sqlstring = sqlstring & "'" & Trim(SNAME) & "','" & Trim(cbo_PaymentMode.Text) & "', "
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & " 'SALE','AUTO',0," & Val(Totalamt) & "," & Val(Taxamt) & "," & Math.Round(Val(billamt)) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                                    Else
                                        sqlstring = sqlstring & " 'SALE','AUTO',0," & Val(Totalamt) & "," & Val(Taxamt) & "," & Val(billamt) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                                    End If
                                    sqlstring = sqlstring & " 'N',0,'','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(paymentaccountcode) & " ','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Roundaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','Y','N','','" & loccode & "'," & Val(LBL_TRANSNO.Text) & "," & PAmt & "," & TAmt & "," & AAmt & "," & PaAmt & "," & RAmt & ")"
                                Else
                                    sqlstring = "INSERT INTO KOT_HDR(BOOKNO,CHITNO,TTYPE,KotNo,Kotdetails,Kotdate,TableNo,Covers,DocType,SaleType,AccountCode,SLCode,MCode,Mname,RoomNo,Guest,checkin,STCode,ServerCode,ServerName,PaymentType,ServiceType,Postingtype,DiscountAmt,Total,TotalTax,BillAmount,RoundOff,BillStatus,Adduserid,Adddatetime,Crostatus,SubPaymentMode,"
                                    sqlstring = sqlstring & " Receiptstatus,Partyorderno,upduserid,upddatetime,postingstatus,Paymodeaccountcode,subpaymentaccountcode,Roundoffaccountcode,Remarks,Manualbillstatus,delflag,Voucherno,transno,PackAmt,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) "
                                    sqlstring = sqlstring & " VALUES (" & Val(BOOKNO) & " ,"
                                    sqlstring = sqlstring & Val(BOOKNO) & " ,"
                                    sqlstring = sqlstring & " 'S','" & Trim(BOOKNO) & "','" & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "'," & Val(txt_TableNo.Text) & "," & Val(txt_Cover.Text) & ",'" & Trim(doctype) & "','SALE','" & Trim(accountcode) & "','" & Trim(MCODE) & "',"
                                    sqlstring = sqlstring & "'" & Trim(MCODE) & "', "
                                    sqlstring = sqlstring & "'" & Trim(MNAME) & "', '','','','',"
                                    'sqlstring = sqlstring & "'" & Trim(SCODE) & "', "
                                    sqlstring = sqlstring & "'500', "
                                    sqlstring = sqlstring & "'" & Trim(SNAME) & "','" & Trim(cbo_PaymentMode.Text) & "', "
                                    If BILLROUNDYESNO = "YES" Then
                                        sqlstring = sqlstring & " 'SALE','AUTO',0," & Val(Totalamt) & "," & Val(Taxamt) & "," & Math.Round(Val(billamt)) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                                    Else
                                        sqlstring = sqlstring & " 'SALE','AUTO',0," & Val(Totalamt) & "," & Val(Taxamt) & "," & Val(billamt) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'ST','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(SubpaymentMode(0)) & "',"
                                    End If
                                    sqlstring = sqlstring & " 'N',0,'','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Trim(paymentaccountcode) & " ','" & Trim(Subpaymentaccountcode) & " ','" & Trim(Roundaccountcode) & " ','" & Trim(Txt_Remarks.Text) & "','Y','N',''," & Val(LBL_TRANSNO.Text) & "," & PAmt & "," & TAmt & "," & AAmt & "," & PaAmt & "," & RAmt & ")"
                                End If
                            Else
                                MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            End If
                        Catch ex As Exception
                            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End Try
                    End If
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                    '''******************************************************** Insert into KOT_DET **********************************'''

                    sqlstring = "INSERT INTO KOT_DET(BOOKNO,CHITNO,TTYPE,KotNo,KOTdetails,KotDate,Billdetails,KotType,PaymentMode,PDA_PRINT_FLAG,PDA_DELETE_FLAG,Mcode,Scode,Covers,TableNo,TotAmt,TaxAmt,DiscAmt,BillAmt,ItemCode,Itemdesc,Poscode,Uom,Qty,Rate,Taxamount,Amount,ItemType,TaxCode,TaxPerc,TaxAccountCode,SalesAccountCode,GroupCode,"
                    sqlstring = sqlstring & " PackPercent,PackAmount,Openfacilityst,Promotionalst,Packaccountcode,TipsPer,TipsAmt,AdCgsPer,AdCgsAmt,PartyPer,PartyAmt,RoomPer,RoomAmt,Taxtype,Alcholst,Adduserid,Adddatetime,Upduserid,Upddatetime,KOTStatus,Delflag,transno) VALUES ("
                    sqlstring = sqlstring & " " & Val(BOOKNO) & "," & Val(BOOKNO) & ",'S','" & Trim(BOOKNO) & "','" & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(CStr(KOTno)) & "','" & doctype & "','" & Trim(cbo_PaymentMode.Text) & "','','',"
                    'sqlstring = sqlstring & " '" & Trim(MCODE) & "','" & Trim(SCODE) & "',"
                    sqlstring = sqlstring & " '" & Trim(MCODE) & "','500',"
                    sqlstring = sqlstring & " " & Val(txt_Cover.Text) & "," & Val(txt_TableNo.Text) & ","
                    If BILLROUNDYESNO = "YES" Then
                        sqlstring = sqlstring & " " & Val(Totalamt) & "," & Val(Taxamt) & ",0," & Math.Round(Val(billamt)) & ","
                    Else
                        sqlstring = sqlstring & " " & Val(Totalamt) & "," & Val(Taxamt) & ",0," & Val(billamt) & ","
                    End If
                    i = LOOPINDEX + 1
                    ssGrid.Row = i
                    ssGrid.Col = 1
                    sqlstring = sqlstring & "'" & Trim(TXT_ITEMCODE.Text) & "'"
                    ssGrid.Col = 2
                    sqlstring = sqlstring & ",'" & Trim(TXT_ITEMNAME.Text) & "'"
                    ssGrid.Col = 3
                    sqlstring = sqlstring & ",'" & Trim(ssGrid.Text) & "'"
                    ssGrid.Col = 4
                    sqlstring = sqlstring & ",'" & Trim(ssGrid.Text) & "'"
                    ssGrid.Col = 5
                    sqlstring = sqlstring & "," & Val(ssGrid.Text) & ""
                    ssGrid.Col = 6
                    sqlstring = sqlstring & "," & Val(ssGrid.Text) & ""
                    ssGrid.Col = 7
                    sqlstring = sqlstring & "," & Val(ssGrid.Text) & ""
                    ssGrid.Col = 8
                    sqlstring = sqlstring & "," & Val(ssGrid.Text) & ""
                    ssGrid.Col = 9
                    sqlstring = sqlstring & ",'" & Trim(ssGrid.Text) & "'"
                    ssGrid.Col = 10
                    sqlstring = sqlstring & ",'" & Trim(ssGrid.Text) & "'"
                    ssGrid.Col = 11
                    sqlstring = sqlstring & "," & Val(ssGrid.Text) & " "
                    ssGrid.Col = 13
                    sqlstring = sqlstring & ",'" & Trim(ssGrid.Text) & "' "
                    ssGrid.Col = 14
                    sqlstring = sqlstring & ",'" & Trim(ssGrid.Text) & "' "
                    ssGrid.Col = 15
                    sqlstring = sqlstring & ",'" & Trim(ssGrid.Text) & "' "
                    ssGrid.Col = 17
                    sqlstring = sqlstring & "," & Val(ssGrid.Text) & " "
                    ssGrid.Col = 18
                    sqlstring = sqlstring & "," & Val(ssGrid.Text) & " "
                    ssGrid.Col = 19
                    sqlstring = sqlstring & ",'" & Trim(ssGrid.Text) & "' "
                    ssGrid.Col = 20
                    sqlstring = sqlstring & ",'" & Trim(ssGrid.Text) & "' "
                    ssGrid.Col = 21
                    sqlstring = sqlstring & ",'" & Trim(ssGrid.Text) & "' "
                    ssGrid.Col = 26
                    sqlstring = sqlstring & ",'" & Val(ssGrid.Text) & "' "
                    ssGrid.Col = 27
                    sqlstring = sqlstring & ",'" & Val(ssGrid.Text) & "' "
                    ssGrid.Col = 28
                    sqlstring = sqlstring & ",'" & Val(ssGrid.Text) & "' "
                    ssGrid.Col = 29
                    sqlstring = sqlstring & ",'" & Val(ssGrid.Text) & "' "
                    ssGrid.Col = 30
                    sqlstring = sqlstring & ",'" & Val(ssGrid.Text) & "' "
                    ssGrid.Col = 31
                    sqlstring = sqlstring & ",'" & Val(ssGrid.Text) & "' "
                    ssGrid.Col = 32
                    sqlstring = sqlstring & ",'" & Val(ssGrid.Text) & "' "
                    ssGrid.Col = 33
                    sqlstring = sqlstring & ",'" & Val(ssGrid.Text) & "' "
                    ssGrid.Col = 9
                    If Trim(ssGrid.Text) = "BAR" Then
                        sqlstring = sqlstring & ",'','Y'"
                    ElseIf Trim(ssGrid.Text) = "SD" Then
                        sqlstring = sqlstring & ",'SALES','S'"
                    Else
                        sqlstring = sqlstring & ",'SALES','N'"
                    End If
                    sqlstring = sqlstring & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                    ssGrid.Col = 12
                    If Trim(ssGrid.Text) = "Yes" Then
                        sqlstring = sqlstring & ",'Y','N'," & Val(LBL_TRANSNO.Text) & ")"
                    Else
                        sqlstring = sqlstring & ",'N','N'," & Val(LBL_TRANSNO.Text) & ")"
                    End If
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                    ReDim Preserve Update2(2)
                    Update2(2) = Replace(sqlstring, "KOT_DET", " " & vOutfile & " ")

                    gconnection.MoreTransold1(Update2)

                    'For i = 1 To ssGrid.DataRowCnt

                    '    ''REFERINVENTORY*************************UPDATING STOCK***********************************************
                    '    ssGrid.Row = i
                    '    ssGrid.Col = 3
                    '    POSLOCATION = Trim(ssGrid.Text)
                    '    '******************************************************************************************************
                    'Next i
                    '''********************************************************* INSERT INTO BILL_HDR TABLE ********************************************************************************************************************************************************************************************************************************************'''
                    If cbo_PaymentMode.SelectedItem = "ROOM" Then
                        sqlstring = "INSERT INTO BILL_HDR(BOOKNO,CHITNO,TTYPE,Billno,BillDetails,BillDate,BillTime,DiscountAmount,TaxAmount,BillAmount,Roundoff,Roundoffaccountcode,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,Scode,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,remarks,servicelocation,Packamount,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                        sqlstring = sqlstring & " (" & Val(BOOKNO) & " ," & Val(BOOKNO) & ",'S','" & Trim(BOOKNO) & "','" & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "','" & Format(Now, "hh:mm:ss") & "',0," & Val(Taxamt) & "," & Val(Totalamt) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'" & Trim(Roundaccountcode) & " ',"
                        sqlstring = sqlstring & " '" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','','','" & Trim(MCODE) & "','" & Trim(MNAME) & "','" & Trim(SCODE) & "','" & Trim(SNAME) & "','','','','',"
                        sqlstring = sqlstring & " '" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & loccode & "'," & PAmt & "," & TAmt & "," & AAmt & "," & PaAmt & "," & RAmt & ")"
                    ElseIf cbo_PaymentMode.SelectedItem = "CREDIT" Then
                        sqlstring = "INSERT INTO BILL_HDR(BOOKNO,CHITNO,TTYPE,Billno,BillDetails,BillDate,BillTime,DiscountAmount,TaxAmount,BillAmount,Roundoff,Roundoffaccountcode,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,Scode,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,remarks,servicelocation,Packamount,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                        sqlstring = sqlstring & " (" & Val(BOOKNO) & " ," & Val(BOOKNO) & " ,'S','" & Trim(BOOKNO) & "','" & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "','" & Format(Now, "hh:mm:ss") & "',0," & Val(Taxamt) & "," & Val(Totalamt) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'" & Trim(Roundaccountcode) & " ',"
                        sqlstring = sqlstring & " '" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(gDebitors) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(MCODE) & " ','" & Trim(MCODE) & "','" & Trim(MNAME) & "','" & Trim(SCODE) & "','" & Trim(SNAME) & "','N',0,"
                        sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & loccode & "'," & PAmt & "," & TAmt & "," & AAmt & "," & PaAmt & "," & RAmt & ")"
                    ElseIf cbo_PaymentMode.SelectedItem = "CARD" Then
                        '''************************************************** $ IF PAYMENTMODE IS "CARD"  $ ********************************************'''
                        If CStr(cbo_PaymentMode.Text) = "CARD" Then
                            If smartcardbool = True Then
                                sqlstring = "SELECT Minimumusage FROM MEMBERMASTER WHERE MCODE ='" & Trim(CStr(MCODE)) & "' "
                                gconnection.getDataSet(sqlstring, "MinimumusageMaster")
                                If gdataset.Tables("MinimumusageMaster").Rows.Count > 0 Then
                                    If Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) = 0 Then
                                        sqlstring = "SELECT CardAmt FROM MEMBERMASTER WHERE MCODE ='" & Trim(CStr(MCODE)) & "' "
                                        gconnection.getDataSet(sqlstring, "CardAmtMaster")
                                        If gdataset.Tables("CardAmtMaster").Rows.Count > 0 Then
                                            If Val(gdataset.Tables("CardAmtMaster").Rows(0).Item("CardAmt")) >= Val(billamt) Then
                                                sqlstring = "UPDATE MEMBERMASTER SET CardAmt = CardAmt - " & Math.Round(Val(Totalamt)) & " WHERE MCODE = '" & Trim(CStr(MCODE)) & "'"
                                                dblCard = Math.Round(Val(Totalamount))
                                                dblMinimum = 0
                                                ReDim Preserve Insert(Insert.Length)
                                                Insert(Insert.Length - 1) = sqlstring
                                            Else
                                                MessageBox.Show("!!! Warning !!! Refill your CARD before using ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                cbo_PaymentMode.Focus()
                                                Exit Sub
                                            End If
                                        End If
                                    ElseIf Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) >= Val(Totalamt) Then
                                        sqlstring = "UPDATE MEMBERMASTER SET Minimumusage = Minimumusage - " & Math.Round(Val(Totalamt)) & " WHERE MCODE = '" & Trim(CStr(MCODE)) & "'"
                                        ReDim Preserve Insert(Insert.Length)
                                        Insert(Insert.Length - 1) = sqlstring
                                        dblCard = 0
                                        dblMinimum = Math.Round(Val(Totalamount))
                                    ElseIf Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) <= Val(Totalamt) And Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage")) > 0 Then
                                        sqlstring = "UPDATE MEMBERMASTER SET Minimumusage = 0 WHERE MCODE = '" & Trim(CStr(MCODE)) & "'"
                                        ReDim Preserve Insert(Insert.Length)
                                        Insert(Insert.Length - 1) = sqlstring
                                        dblMinimum = Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage"))
                                        CardAmount = Math.Round(Val(Totalamount)) - Val(gdataset.Tables("MinimumusageMaster").Rows(0).Item("Minimumusage"))
                                        sqlstring = "SELECT CardAmt FROM MEMBERMASTER WHERE MCODE ='" & Trim(CStr(MCODE)) & "' "
                                        gconnection.getDataSet(sqlstring, "CardAmtMaster")
                                        If gdataset.Tables("CardAmtMaster").Rows.Count > 0 Then
                                            If Val(gdataset.Tables("CardAmtMaster").Rows(0).Item("CardAmt")) >= Val(Totalamt) Then
                                                sqlstring = "UPDATE MEMBERMASTER SET CardAmt = CardAmt - " & Format(Val(CardAmount), "0.00") & " WHERE MCODE = '" & Trim(CStr(MCODE)) & "'"
                                                ReDim Preserve Insert(Insert.Length)
                                                Insert(Insert.Length - 1) = sqlstring
                                                dblCard = Format(Val(CardAmount), "0.00")
                                            Else
                                                MessageBox.Show("!!! Warning !!! Refill your CARD before using ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                                cbo_PaymentMode.Focus()
                                                Exit Sub
                                            End If
                                        End If
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
                        '''***************************************************** $ COMPLETE CALCULATION FOR CARD PAYMENTMODE ********************************************************************************'''
                        sqlstring = "INSERT INTO BILL_HDR(BOOKNO,CHITNO,TTYPE,Billno,BillDetails,BillDate,BillTime,DiscountAmount,TaxAmount,BillAmount,Roundoff,Roundoffaccountcode,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,Scode,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,servicelocation,Packamount,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                        sqlstring = sqlstring & " (" & Val(BOOKNO) & " ," & Val(BOOKNO) & " ,'S','" & Trim(BOOKNO) & "','" & Trim(CStr(KOTno)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "hh:mm:ss") & "',0," & Val(Taxamt) & "," & Val(Totalamt) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'" & Trim(Roundaccountcode) & " ',"
                        sqlstring = sqlstring & " '" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(MCODE) & "','" & Trim(MNAME) & "','" & Trim(SCODE) & "','" & Trim(SNAME) & "','N',0,"
                        sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'," & Format(Val(dblMinimum), "0.00") & "," & Format(Val(dblCard), "0.00") & ",'" & Trim(CStr(Txt_Remarks.Text)) & "','" & loccode & "'," & PAmt & "," & TAmt & "," & AAmt & "," & PaAmt & "," & RAmt & ")"
                    Else
                        Try
                            sqlstring = " SELECT ISNULL(MEMBERSTATUS,'') AS MEMBERSTATUS,ISNULL(PAYMENTCODE,'') AS PAYMENTCODE  FROM PAYMENTMODEMASTER "
                            sqlstring = sqlstring & "WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
                            gconnection.getDataSet(sqlstring, "PAYMENTMODEMASTER")
                            If gdataset.Tables("PAYMENTMODEMASTER").Rows.Count > 0 Then
                                If Trim(gdataset.Tables("PAYMENTMODEMASTER").Rows(0).Item("MEMBERSTATUS")) = "NO" Then
                                    sqlstring = "INSERT INTO Bill_Hdr(BOOKNO,CHITNO,TTYPE,Billno,BillDetails,BillDate,BillTime,DiscountAmount,TaxAmount,BillAmount,Roundoff,Roundoffaccountcode,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,Scode,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,remarks,servicelocation,Packamount,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    sqlstring = sqlstring & " (" & Val(BOOKNO) & " ," & Val(BOOKNO) & " ,'S','" & Trim(BOOKNO) & "','" & Trim(CStr(KOTno)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "hh:mm:ss") & "',0," & Val(Taxamt) & "," & Val(Totalamt) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'" & Trim(Roundaccountcode) & " ',"
                                    sqlstring = sqlstring & " '" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','','','" & Trim(SCODE) & "','" & Trim(SNAME) & "','N',0,"
                                    sqlstring = sqlstring & " 0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & loccode & "'," & PAmt & "," & TAmt & "," & AAmt & "," & PaAmt & "," & RAmt & ")"
                                Else
                                    sqlstring = "INSERT INTO Bill_Hdr(BOOKNO,CHITNO,TTYPE,Billno,BillDetails,BillDate,BillTime,DiscountAmount,TaxAmount,BillAmount,Roundoff,Roundoffaccountcode,PayMentmode,Paymentaccountcode,SubPaymentMode,Subpaymentaccountcode,Mcode,Mname,Scode,sname,CroStatus,Roomno,ChkId,Guest,AddUserId,AddDatetime,Upduserid,Upddatetime,Adjflag,Adjdate,Minimumusage,CardAmount,Remarks,servicelocation,Packamount,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES"
                                    sqlstring = sqlstring & " (" & Val(BOOKNO) & " ," & Val(BOOKNO) & " ,'S','" & Trim(BOOKNO) & "','" & Trim(CStr(KOTno)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','" & Format(Now, "hh:mm:ss") & "',0," & Val(Taxamt) & "," & Val(Totalamt) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'" & Trim(Roundaccountcode) & " ',"
                                    sqlstring = sqlstring & " '" & Trim(Me.cbo_PaymentMode.Text) & "','" & Trim(paymentaccountcode) & " ','" & Trim(SubpaymentMode(0)) & "','" & Trim(Subpaymentaccountcode) & " ','" & Trim(MCODE) & "','" & Trim(MNAME) & "','" & Trim(SCODE) & "',"
                                    sqlstring = sqlstring & " '" & Trim(SNAME) & "','N',0,0,'','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',0,0,'" & Trim(CStr(Txt_Remarks.Text)) & "','" & loccode & "'," & PAmt & "," & TAmt & "," & AAmt & "," & PaAmt & "," & RAmt & ")"
                                End If
                            Else
                                MessageBox.Show("Plz Enter various payment mode into payment master ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            End If
                        Catch ex As Exception
                            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End Try
                    End If

                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    '''*********************************************************** COMPLETE INSERTING BILL_HDR ***********************************************************************************************'''
                    '''*********************************************************** INSERT INTO BILL_DET ******************************************************************************************************'''
                    sqlstring = "SELECT ISNULL(TAXCODE,'') AS TAXCODE  FROM TAXITEMLINK WHERE ITEMTYPECODE IN (SELECT TAXTYPECODE FROM CHARGEMASTER WHERE CHARGECODE IN (SELECT ISNULL(ITEMTYPECODE,'') AS ITEMTYPECODE FROM ITEMMASTER INNER JOIN POSMENULINK ON "
                    sqlstring = sqlstring & " ITEMMASTER.ITEMCODE = POSMENULINK.ITEMCODE))" ' WHERE POS= '" & Trim(poscode) & "') "
                    gconnection.getDataSet(sqlstring, "ITEMMASTER")
                    If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                        sqlstring = " INSERT INTO Bill_Det(BOOKNO,CHITNO,Billno,BillDetails,BillDate,KotDetails,TaxAmount,Discountamount,KotAmount,Roundoff,OthBillDetails,KotDate,TaxCode,Packamount,TipsAmt,AdCgsAmt,PartyAmt,RoomAmt) VALUES ("
                        sqlstring = sqlstring & " " & Val(BOOKNO) & " ," & Val(BOOKNO) & " ,'" & Trim(BOOKNO) & "','" & Trim(CStr(KOTno)) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','" & Trim(CStr(KOTno)) & "',"
                        sqlstring = sqlstring & " " & Val(Taxamt) & ",0," & Val(Totalamt) & "," & Format((Val(billamt)) - (Val(Totalamt) + Val(Taxamt)), "0.00") & ",'',"
                        sqlstring = sqlstring & " '" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("ITEMMASTER").Rows(0).Item("TAXCODE")) & "'," & PAmt & "," & TAmt & "," & AAmt & "," & PaAmt & "," & RAmt & ")"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring

                        sqlstring = "UPDATE KOT_HDR SET "
                        sqlstring = sqlstring & " Crostatus='N',PaymentType ='" & Trim(Me.cbo_PaymentMode.Text) & "',Paymodeaccountcode ='" & Trim(paymentaccountcode) & " ',"
                        sqlstring = sqlstring & " SubPaymentMode ='" & Trim(SubpaymentMode(0)) & "',subpaymentaccountcode='" & Trim(Subpaymentaccountcode) & " ' WHERE Kotdetails= '" & Trim(CStr(KOTno)) & "'"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring

                        sqlstring = "UPDATE KOT_DET SET BillDetails='" & Trim(CStr(KOTno)) & "'"
                        sqlstring = sqlstring & " WHERE Kotdetails='" & Trim(CStr(KOTno)) & "' "
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    End If
                    '''*********************************************************** COMPLETE INSERTING BILL_DET ***********************************************************************************************'''
                    ''''************************************************** $ BILL SETTLEMENT IF ANY   $ ********************************************'''
                    If ssgridPayment.DataRowCnt = 0 Then
                        sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                        sqlstring = sqlstring & " '" & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "','" & Trim(cbo_PaymentMode.Text) & "','" & Trim(POScode) & "','" & Trim(paymentaccountcode) & "','" & Trim(MCODE) & "','" & Trim(MNAME) & "', "
                        sqlstring = sqlstring & " '','','" & Format(Now, "dd-MMM-yyyy") & "','',''," & Format(Val(txt_BillAmount.Text), "0.00") & ", " & Format(Val(txt_BillAmount.Text), "0.00") & ",0,'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N') "
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    Else
                        For Z = 1 To ssgridPayment.DataRowCnt
                            ssgridPayment.Col = 1
                            ssgridPayment.Row = Z
                            If Trim(ssgridPayment.Text) <> "" Then
                                ssgridPayment.Col = 3
                                ssgridPayment.Row = Z
                                sqlstring = " SELECT ISNULL(Accountin,'') AS ACCOUNTIN,ISNULL(Paymentcode,'') AS Paymentcode,ISNULL(paymentType,'') AS paymentType  FROM paymentmodemaster WHERE Paymentcode = '" & Trim(ssgridPayment.Text) & "' AND ISNULL(Freeze,'')='N'"
                                gconnection.getDataSet(sqlstring, "paymentmodemaster")
                                If gdataset.Tables("paymentmodemaster").Rows.Count > 0 Then
                                    If Trim(ssgridPayment.Text) = Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("Paymentcode")) And Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CD" Then
                                        sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,"
                                        sqlstring = sqlstring & "Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                                        ssgridPayment.Row = Z
                                        ssgridPayment.Col = 1
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "',"
                                        ssgridPayment.Col = 2
                                        sqlstring = sqlstring & "'" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "',"
                                        ssgridPayment.Col = 3
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "','" & Trim(POScode) & "',"
                                        sqlstring = sqlstring & "'" & Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin")) & "',"
                                        ssgridPayment.Col = 5
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "',"
                                        ssgridPayment.Col = 6
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "',"
                                        sqlstring = sqlstring & "'" & Trim(txt_Typeofcard.Text) & "','" & Trim(txt_Cardno.Text) & "','" & Format(dtp_Expirydate.Value, "dd-MMM-yyyy") & "','','" & Trim(txt_Cardholdername.Text) & "',"
                                        ssgridPayment.Col = 4
                                        sqlstring = sqlstring & "" & Format(Val(ssgridPayment.Text), "0.00") & ","
                                        ssgridPayment.Col = 7
                                        sqlstring = sqlstring & "" & Format(Val(ssgridPayment.Text), "0.00") & ","
                                        ssgridPayment.Col = 8
                                        sqlstring = sqlstring & "" & Format(Val(ssgridPayment.Text), "0.00") & ","
                                        sqlstring = sqlstring & "'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N')"
                                        ReDim Preserve Insert(Insert.Length)
                                        Insert(Insert.Length - 1) = sqlstring
                                    ElseIf Trim(ssgridPayment.Text) = Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("Paymentcode")) And Trim(gdataset.Tables("paymentmodemaster").Rows(0).Item("paymentType")) = "CQ" Then
                                        sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,"
                                        sqlstring = sqlstring & "Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                                        ssgridPayment.Row = Z
                                        ssgridPayment.Col = 1
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "',"
                                        ssgridPayment.Col = 2
                                        sqlstring = sqlstring & "'" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "',"
                                        ssgridPayment.Col = 3
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "','" & Trim(POScode) & "',"
                                        sqlstring = sqlstring & "'" & Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin")) & "',"
                                        ssgridPayment.Col = 5
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "',"
                                        ssgridPayment.Col = 6
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "',"
                                        sqlstring = sqlstring & "'" & Trim(cbo_Typeofcheque.Text) & "','" & Trim(txt_Chequeno.Text) & "','" & Format(dtp_Chequedate.Value, "dd-MMM-yyyy") & "','" & Trim(txt_Draweebank.Text) & "','',"
                                        ssgridPayment.Col = 4
                                        sqlstring = sqlstring & "" & Format(Val(ssgridPayment.Text), "0.00") & ","
                                        ssgridPayment.Col = 7
                                        sqlstring = sqlstring & "" & Format(Val(ssgridPayment.Text), "0.00") & ","
                                        ssgridPayment.Col = 8
                                        sqlstring = sqlstring & "" & Format(Val(ssgridPayment.Text), "0.00") & ","
                                        sqlstring = sqlstring & "'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N')"
                                        ReDim Preserve Insert(Insert.Length)
                                        Insert(Insert.Length - 1) = sqlstring
                                    Else
                                        sqlstring = "INSERT INTO BILLSETTLEMENT (Billno,Billdate,PaymentMode,Poscode,PaymentAccountCode,Mcode,Mname,CardType, Instrumentno,Instrumentdate,"
                                        sqlstring = sqlstring & "Bankname,ReceivedName,Payamount,Billamount,Balanceamount,AddUserid,Adddatetime,UpdateUserid,Updatedatetime,Delflag ) VALUES ("
                                        ssgridPayment.Row = Z
                                        ssgridPayment.Col = 1
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "',"
                                        ssgridPayment.Col = 2
                                        sqlstring = sqlstring & "'" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy ") & "',"
                                        ssgridPayment.Col = 3
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "','" & Trim(POScode) & "',"
                                        sqlstring = sqlstring & "'" & Trim(gdataset.Tables("Paymentmodemaster").Rows(0).Item("Accountin")) & "',"
                                        ssgridPayment.Col = 5
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "',"
                                        ssgridPayment.Col = 6
                                        sqlstring = sqlstring & "'" & Trim(ssgridPayment.Text) & "',"
                                        sqlstring = sqlstring & "'','','" & Format(Now, "dd-MMM-yyyy") & "','','',"
                                        ssgridPayment.Col = 4
                                        sqlstring = sqlstring & "" & Format(Val(ssgridPayment.Text), "0.00") & ","
                                        ssgridPayment.Col = 7
                                        sqlstring = sqlstring & "" & Format(Val(ssgridPayment.Text), "0.00") & ","
                                        ssgridPayment.Col = 8
                                        sqlstring = sqlstring & "" & Format(Val(ssgridPayment.Text), "0.00") & ","
                                        sqlstring = sqlstring & "'" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N')"
                                        ReDim Preserve Insert(Insert.Length)
                                        Insert(Insert.Length - 1) = sqlstring
                                    End If
                                End If
                            End If
                        Next Z
                    End If
                    '''''************************************************** $ BILL SETTLEMENT COMPLETE   $ ********************************************'''
                    '''*********************************************************** COMPLETE ******************************************************************************************************************'''
                    ''**************************Inserting Data into ROOM LEDGER table **************************************
                    If cbo_PaymentMode.SelectedItem = "ROOM" Then
                        sqlstring = "INSERT INTO ROOMLEDGER(CHKNO,DOCNO,DOCDATE,DOCTYPE,FOLIONO,AMOUNT,POSCODE,"
                        sqlstring = sqlstring & "ROOMNO,REFNO,CREDITDEBIT,PAYMENTMODE,VOUCHERTYPE,VOUCHERCATEGORY,KOTNO)"
                        sqlstring = sqlstring & " Values('" & MCODE & "','" & Trim(BOOKNO) & "','" & Format(CDate(Me.dtp_KOTdate.Value), "dd-MMM-yyyy") & "','SALES',1," & Val(billamt) & ","
                        sqlstring = sqlstring & "'" & loccode & "'," & MCODE & ",'" & MCODE & "','DEBIT','ROOM','RM','RM',1)"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    End If
                    '--------------------
                    'Settlement 
                    'begin
                    'If cbo_PaymentMode.SelectedItem <> "ROOM" Then
                    With ssgrid_settlement
                        If .DataRowCnt = 1 Or .DataRowCnt = 0 Then
                            sqlstring = "INSERT INTO SETTLEMENT(BILLDETAILS,BILLDATE,MCODE,AMOUNT,DESCRIPTION,deleteflag,SBILLFLAG) "
                            sqlstring = sqlstring & "VALUES('" & txt_KOTno.Text & "','" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "',"
                            sqlstring = sqlstring & "'" & Trim(MCODE) & "'," & billamt & ",'','N','N')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring

                            sqlstring = "UPDATE BILL_HDR SET SBILLFLAG='N' WHERE BILLDETAILS='" & txt_KOTno.Text & "'"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Else
                            For i = 1 To .DataRowCnt
                                sqlstring = "INSERT INTO SETTLEMENT(BILLDETAILS,BILLDATE,MCODE,AMOUNT,DESCRIPTION,DELETEFLAG,SBILLFLAG) "
                                sqlstring = sqlstring & "VALUES('" & CStr(KOTno) & "','" & Format(dtp_KOTdate.Value, "dd/MMM/yyyy") & "',"
                                .Col = 1
                                .Row = i
                                sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                                .Col = 2
                                .Row = i
                                sqlstring = sqlstring & Math.Round(Val(Trim(.Text)), 2) & ","
                                .Col = 3
                                .Row = i
                                sqlstring = sqlstring & "'" & Trim(.Text) & "','N','Y')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            Next
                            sqlstring = "UPDATE BILL_HDR SET SBILLFLAG='Y' WHERE BILLDETAILS='" & txt_KOTno.Text & "'"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        End If
                    End With
                    'End If
                    '---------------------
                    'Settlement 
                    'end

                    '-----------------------------------------JOURNAL BEGIN
                    'BILL_JOURNALENTRY 
                    'begin
                    '                    gconnection.MoreTransold1(Update2)

                    sqlstring = "SELECT ISNULL(ACCOUNTIN,'') AS ACCOUNTIN, ISNULL(SALECOSTCENTERCODE,'') AS SALECOSTCENTERCODE, ISNULL(SALECOSTCENTERDESC,'') AS SALECOSTCENTERDESC FROM PAYMENTMODEMASTER WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "' And ISNULL(SUBPAYSTATUS,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "AccountIn")
                    If (gdataset.Tables("AccountIn").Rows.Count > 0) Then
                        'MUST BE CHANGE IF SUNDRY DEBTORS ACCOUNT CODE IS ONE
                        '                strAccountIn = Trim(gdataset.Tables("AccountIn").Rows(0).Item("AccountIn"))
                        strAccountIn = gDebitors
                        strSaleCostAccountIn = Trim(gdataset.Tables("AccountIn").Rows(0).Item("SALECOSTCENTERCODE"))
                        strSaleCostAccountInDesc = Trim(gdataset.Tables("AccountIn").Rows(0).Item("SALECOSTCENTERDESC"))
                    Else
                        sqlstring = "SELECT ISNULL(ACCOUNTIN,'') AS ACCOUNTIN, ISNULL(SALECOSTCENTERCODE,'') AS         SALECOSTCENTERCODE, ISNULL(SALECOSTCENTERDESC,'') AS SALECOSTCENTERDESC FROM PAYMENTMODEMASTER WHERE PAYMENTCODE = '" & Trim(cbo_PaymentMode.Text) & "'ISNULL(SUBPAYSTATUS,'')='N'"
                        strAccountIn = ""
                        strSaleCostAccountIn = ""
                        strSaleCostAccountInDesc = ""
                    End If

                    If Me.cbo_SubPaymentMode.Visible = True Then
                        strAccountIn = Subpaymentaccountcode
                    End If

                    ' STMcode = Trim(txt_MemberCode.Text)

                    sqlstring = "SELECT ISNULL(MAX(ISNULL(BATCHNO,0)),0) AS BATCHNO FROM BILL_JOURNALENTRY"
                    gconnection.getDataSet(sqlstring, "BatchNo")
                    If (gdataset.Tables("BatchNo").Rows.Count > 0) Then
                        strBatchNo = Trim(gdataset.Tables("BatchNo").Rows(0).Item("BATCHNO"))
                    Else
                        strBatchNo = ""
                    End If
                    If (strAccountIn <> "") Then
                        sqlstring = "SELECT ISNULL(ACDESC,'') AS ACDESC FROM ACCOUNTSGLACCOUNTMASTER WHERE ACCODE = '" & strAccountIn & "'"
                        gconnection.getDataSet(sqlstring, "AccountDesc")
                        If (gdataset.Tables("AccountDesc").Rows.Count > 0) Then
                            strAccountDesc = Trim(gdataset.Tables("AccountDesc").Rows(0).Item("ACDESC"))
                        Else
                            strAccountDesc = ""
                        End If
                    End If
                    sqlstring = " Delete From  BILL_JOURNALENTRY Where voucherno='" & txt_KOTno.Text & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                    sqlstring = "Select Isnull(A.Billdetails,'') as Billdetails,Isnull(sum(A.TaxAMOUNT),0) as Amount,Isnull(B.Acdesc,'') as Acdesc,"
                    sqlstring = sqlstring & "Isnull(A.Taxaccountcode,'') as Acctcode From " & vOutfile & "  A,Accountsglaccountmaster B "
                    sqlstring = sqlstring & "Where Isnull(delFlag,'')<>'Y'  And A.TAXAccountcode=b.Accode "
                    sqlstring = sqlstring & "And Isnull(Billdetails,'')='" & txt_KOTno.Text & "' "
                    sqlstring = sqlstring & "Group by A.Taxaccountcode,A.billdetails,B.Acdesc "
                    gconnection.getDataSet(sqlstring, "JrnTax")
                    Jnltaxamount = 0
                    If (gdataset.Tables("JrnTax").Rows.Count > 0) Then
                        For K = 0 To gdataset.Tables("JrnTax").Rows.Count - 1
                            strBatchNo = strBatchNo + 1
                            sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description,OPPACCOUNTCODE,OPPSLCODE) "
                            '                            sqlstring = sqlstring & " Values ('" & Mid(Trim(txt_KOTno.Text), 1, doctypelength) & "','" & Mid(Trim(txt_KOTno.Text), 1, doctypelength) & "','" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("JrnTax").Rows(K).Item("Acctcode")) & "',''," & Trim(gdataset.Tables("Jrntax").Rows(K).Item("Amount")) & ",'CREDIT','" & Trim(gdataset.Tables("Jrntax").Rows(K).Item("Acdesc")) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"

                            If Trim(cbo_PaymentMode.Text) = "SMART CARD" Then
                                sqlstring = sqlstring & " Values ('SMART','SMART','"
                            ElseIf Trim(cbo_PaymentMode.Text) = "CASH" Then
                                sqlstring = sqlstring & " Values ('CASH','CASH','"
                            Else
                                sqlstring = sqlstring & " Values ('SALE','SALE','"
                            End If

                            sqlstring = sqlstring & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("JrnTax").Rows(K).Item("Acctcode")) & "',''," & Trim(gdataset.Tables("Jrntax").Rows(K).Item("Amount")) & ",'CREDIT','" & Trim(gdataset.Tables("Jrntax").Rows(K).Item("Acdesc")) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                            sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, doctypelength) & "','" & Trim(strAccountIn) & "','" & Trim(STMcode) & "')"
                            Jnltaxamount = Jnltaxamount + Val(gdataset.Tables("Jrntax").Rows(K).Item("Amount"))
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next
                    End If
                    'ACCOUNTS CODE WISE INSERT IN BILL_JOURNALENTRY - CREDIT PART
                    sqlstring = "select Isnull(A.Billdetails,'') as Billdetails,Isnull(sum(A.AMOUNT),0) as Amount,"
                    sqlstring = sqlstring & "Isnull(A.SalesAccountcode,'') as AcctCode,Isnull(B.Acdesc,'') as Acdesc From  " & vOutfile & " A, "
                    sqlstring = sqlstring & "Accountsglaccountmaster B Where Isnull(A.delFlag,'')<>'Y' "
                    sqlstring = sqlstring & "And Isnull(A.billdetails,'')='" & txt_KOTno.Text & "'  And A.SalesAccountcode=B.Accode "
                    sqlstring = sqlstring & "Group by A.SalesAccountcode,A.billdetails,B.Acdesc "
                    gconnection.getDataSet(sqlstring, "JrnAcct")

                    If (gdataset.Tables("JrnAcct").Rows.Count > 0) Then
                        Jnlamount = 0
                        For K = 0 To gdataset.Tables("JrnAcct").Rows.Count - 1
                            strBatchNo = strBatchNo + 1

                            sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description,OPPACCOUNTCODE,OPPSLCODE) "
                            If Trim(cbo_PaymentMode.Text) = "SMART CARD" Then
                                sqlstring = sqlstring & " Values ('SMART','SMART','"
                            ElseIf Trim(cbo_PaymentMode.Text) = "CASH" Then
                                sqlstring = sqlstring & " Values ('CASH','CASH','"
                            Else
                                sqlstring = sqlstring & " Values ('SALE','SALE','"
                            End If

                            sqlstring = sqlstring & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Acctcode")) & "',''," & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Amount")) & ",'CREDIT','" & Trim(gdataset.Tables("JrnAcct").Rows(K).Item("Acdesc")) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                            sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, doctypelength) & "','" & Trim(strAccountIn) & "','" & Trim(STMcode) & "')"
                            Jnlamount = Jnlamount + Val(gdataset.Tables("JrnAcct").Rows(K).Item("Amount"))


                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        Next
                    End If
                    'MEMBER CODE WISE INSERT IN BILL_JOURNALENTRY - DEBIT PART
                    With ssgrid_settlement
                        If .DataRowCnt > 1 Then
                            .SetActiveCell(1, 1)
                            For K = 1 To .DataRowCnt
                                STMcode = ""
                                _Billamount = 0.0
                                .Row = K
                                .Col = 1
                                STMcode = .Text
                                .Row = K
                                .Col = 2
                                _Billamount = .Text

                                strBatchNo = strBatchNo + 1
                                sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,SlDesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                                '                                sqlstring = sqlstring & " Values ('" & Mid(Trim(CStr(KOTno)), 1, doctypelength) & "','" & Mid(Trim(CStr(KOTno)), 1, doctypelength) & "','" & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"

                                If Trim(cbo_PaymentMode.Text) = "SMART CARD" Then
                                    sqlstring = sqlstring & " Values ('SMART','SMART','"
                                ElseIf Trim(cbo_PaymentMode.Text) = "CASH" Then
                                    sqlstring = sqlstring & " Values ('CASH','CASH','"
                                Else
                                    sqlstring = sqlstring & " Values ('SALE','SALE','"
                                End If

                                sqlstring = sqlstring & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"
                                sqlstring = sqlstring & Trim(STMcode) & "','',"

                                sqlstring = sqlstring & Format(Val(_Billamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, doctypelength) & "')"

                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            Next
                        Else
                            strBatchNo = strBatchNo + 1
                            sqlstring = "INSERT INTO BILL_JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SlCode,SlDesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description) "
                            '                            sqlstring = sqlstring & " Values ('" & Mid(Trim(CStr(KOTno)), 1, doctypelength) & "','" & Mid(Trim(CStr(KOTno)), 1, doctypelength) & "','" & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"

                            If Trim(cbo_PaymentMode.Text) = "SMART CARD" Then
                                sqlstring = sqlstring & " Values ('SMART','SMART','"
                            ElseIf Trim(cbo_PaymentMode.Text) = "CASH" Then
                                sqlstring = sqlstring & " Values ('CASH','CASH','"
                            Else
                                sqlstring = sqlstring & " Values ('SALE','SALE','"
                            End If

                            sqlstring = sqlstring & Trim(CStr(KOTno)) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','" & strAccountIn & "','"
                            sqlstring = sqlstring & Trim(MCODE) & "','" & Trim(MNAME) & "',"
                            sqlstring = sqlstring & Format(Val(Jnltaxamount + Jnlamount), "0.00") & ",'DEBIT','" & strAccountDesc & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                            sqlstring = sqlstring & strBatchNo & ",'POSTING FROM POS - " & Mid(Trim(txt_KOTno.Text), 1, doctypelength) & "')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        End If
                    End With
                    sqlstring = "Drop Table  " & vOutfile
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    'Tax Start Hear
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    i = LOOPINDEX + 1
                    With ssGrid
                        .Col = 23
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

                                STRSQL = "INSERT INTO KOT_DET_TAX (KOTDETAILS,KOTDATE,TTYPE,CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,ADD_USER,ADD_DATE,VOID,VOIDUSER) VALUES ( "
                                STRSQL = STRSQL & "'" & Trim(txt_KOTno.Text) & "','" & Format(dtp_KOTdate.Value, "dd-MMM-yyyy") & "','S','" & Trim(ChargeCode) & "','" & Trim(IType) & "','" & Trim(Pos) & "','" & Trim(ITEMCODE) & "','" & Trim(KStatus) & "','" & Trim(Taxcode) & "','" & Trim(Taxon) & "'," & (GrdRate) & "," & (Qty) & "," & (TPercent) & ","

                                If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                    Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    STRSQL = STRSQL & "" & Val(Zero) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    STRSQL = STRSQL & "" & Val(ZeroA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    STRSQL = STRSQL & "" & Val(ZeroB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                    One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    STRSQL = STRSQL & "" & Val(One) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    STRSQL = STRSQL & "" & Val(OneA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    STRSQL = STRSQL & "" & Val(OneB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                    Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    STRSQL = STRSQL & "" & Val(Two) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    STRSQL = STRSQL & "" & Val(TwoA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    STRSQL = STRSQL & "" & Val(TwoB) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                    Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    STRSQL = STRSQL & "" & Val(Three) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    STRSQL = STRSQL & "" & Val(ThreeA) * Qty & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    STRSQL = STRSQL & "" & Val(ThreeB) * Qty & ","
                                End If
                                STRSQL = STRSQL & "'" & Trim(gUsername) & "',getdate(),'N','')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = STRSQL
                            Next
                        End If
                    End With
                    'Tax End Hear
                    
                Next LOOPINDEX
            End If
        End With
        'ALL RECORD INSERTING HERE

        gconnection.MoreTransold(Insert)
        ' sqlstring = "UPDATE KOT_DET SET CATEGORY=A.CATEGORY FROM ITEMMASTER A WHERE A.ITEMCODE=KOT_DET.ITEMCODE AND KOTDETAILS='" & Trim(txt_KOTno.Text) & "'"
        sqlstring = "UPDATE KOT_DET SET CATEGORY=A.CATEGORY FROM ITEMMASTER A WHERE A.ITEMCODE=KOT_DET.ITEMCODE AND TRANSNO='" & Trim(LBL_TRANSNO.Text) & "'  AND ISNULL(TTYPE,'')='S'"
        gconnection.dataOperation(9, sqlstring, "CAT")

        sqlstring = "update kot_det set salesslcode=isnull(b.salesslcode,'') from itemmaster b where b.itemcode=kot_det.itemcode and kot_det.TRANSNO='" & Trim(LBL_TRANSNO.Text) & "'  AND ISNULL(kot_det.TTYPE,'')='S'"
        gconnection.dataOperation(9, sqlstring, "CAT")


        sqlstring = "update bill_journalentry set slcode=isnull(b.salesslcode,'') from kot_det b where b.kotdetails in ((select VOUCHERNO from bill_journalentry a where ISNULL(accountcode,'')+ISNULL(slcode,'') not in (select accode+slcode from accountssubledgermaster b where b.accode=a.accountcode and b.slcode=a.slcode) and accountcode in (select accode from accountsglaccountmaster where isnull(subledgerflag,'N')='Y') and vouchertype='SALE')) and isnull(b.ttype,'')='S' AND B.SALESACCOUNTCODE=BILL_JOURNALENTRY.ACCOUNTCODE"
        gconnection.dataOperation(9, sqlstring, "CAT")
        '
        '
        If CHK_PRINT.Checked = True Then
            Call Cmd_Print_Click(Cmd_Print, e)
            Call Cmd_Clear_Click(sender, e)
            If kotupdate = True Then
                Me.Close()
            End If
        Else
            Call Cmd_Clear_Click(sender, e)
            If kotupdate = True Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click

    End Sub
End Class