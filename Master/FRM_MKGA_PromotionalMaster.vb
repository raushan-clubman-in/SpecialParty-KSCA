Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class FRM_MKGA_PromotionalMaster
    Inherits System.Windows.Forms.Form
    Dim gconnection As New GlobalClass
    'Dim VCONN As New GlobalClass
    Dim boolchk As Boolean
    Dim sqlstring, str, strF As String
    Dim pagesize, pageno, years As Integer

    Private Sub FRM_MKGA_PromotionalMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdPROMOHelp.Enabled = True Then
                Search = Trim(txtPROMOcode.Text)
                Call cmdPROMOHelp_Click(txtPROMOcode, e)
            End If
        End If
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(sender, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            If Cmd_Freeze.Enabled = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F7 Then
            If Cmd_Add.Enabled = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            If cmd_view.Enabled = True Then
                Call cmd_view_Click(cmd_view, e)
                Exit Sub
            End If
        End If
        'If e.KeyCode = Keys.F10 Then
        '    If CmdView.Enabled = True Then
        '        Call cmdexport_Click(CmdView, e)
        '        Exit Sub
        '    End If
        'End If

        If e.KeyCode = Keys.F12 Then
            'If CmdView.Enabled = True Then
            Call cmd_excel_Click(cmd_excel, e)
            Exit Sub
            'End If
        End If

        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmb_exit_Click(cmb_exit, e)
            Exit Sub
        End If
    End Sub

    Private Sub FRM_MKGA_PromotionalMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call FILLLOC()
        'Call gconnection.FocusSetting(Me)
        'grp_Specific.Visible = True
        txtBaseItem.Focus()
        Cbo_TYPE.SelectedIndex = 0
        str = "SELECT * FROM ITEMMASTER"
        gconnection.getDataSet(str, "ITEM")
        Call FillUOM()
        ' Cbo_TYPE.Focus()
        DAYSGRID.Enabled = True
        txtPROMOcode.Select()
        mskdate.Value = Today
        Cmb_ToDate.Value = Today
        Cmb_FromDate.Value = Today

    End Sub
    Private Sub FILLLOC()
        Dim J As Integer
        sqlstring = "SELECT POSCODE+'-->'+POSDESC AS LOCCODE FROM POSMASTER WHERE ISNULL(Freeze,'') <> 'Y'  AND STORETYPE='POS' ORDER BY POSCODE ASC "
        gconnection.getDataSet(sqlstring, "UOMMaster1")
        If gdataset.Tables("UOMMaster1").Rows.Count > 0 Then
            For J = 0 To gdataset.Tables("UOMMaster1").Rows.Count - 1
                CHK_LOCATION.Items.Add(gdataset.Tables("UOMMaster1").Rows(J).Item("LOCCODE"))
            Next J
        End If
    End Sub
    Private Sub FillUOM() ''---> Fill All UOM From UOMMASTER
        Dim ssql As String
        Dim i As Integer
        ssql = "SELECT DISTINCT ISNULL(uomcode,'') AS uomcode FROM UOMMaster WHERE ISNULL(Freeze,'') <> 'Y' ORDER BY uomcode ASC"

        'ssql = "SELECT DISTINCT ISNULL(UOMDESC,'') AS UOMDESC FROM UOMMaster WHERE ISNULL(Freeze,'') <> 'Y' ORDER BY uomdesc ASC"
        gconnection.getDataSet(ssql, "UOMMaster")
        cbo_QBaseUom.Items.Clear()
        ' ComboBox1.Items.Clear()
        If gdataset.Tables("UOMMaster").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("UOMMaster").Rows.Count - 1
                With gdataset.Tables("UOMMaster").Rows(i)
                    cbo_QBaseUom.Items.Add(Trim(.Item("uomcode")))
                    'ComboBox1.Items.Add(Trim(.Item("uomcode")))
                End With
            Next i
        End If
        'cbo_QBaseUom.Sorted = True
    End Sub

    Private Sub cmdBaseItemHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaseItemHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMDESC,'') AS ITEMDESC FROM ITEMMASTER"
        'If Trim(Search) = " " Then
        M_WhereCondition = ""
        'Else
        ' M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y' "
        'End If        
        vform.Field = "ITEMCODE,ITEMDESC"
        ' vform.Frmcalled = "         ITEM CODE            |             ITEM DESCRIPTION                              "
        vform.vCaption = "ITEM MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txtBaseItem.Text = Trim(vform.keyfield & "")
            Call txtBaseItem_Validated(txtBaseItem, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txtBaseItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBaseItem.KeyPress
        getAlphanumeric(e)

        If Asc(e.KeyChar) = 13 Then
            If txtBaseItem.Text <> "" Then
                txtBaseItem_Validated(sender, e)
                ' txtBaseItem.Focus()
            Else
                Call cmdBaseItemHelp_Click(sender, e)
            End If
        End If
    End Sub
    'Private Sub GridUOM(ByVal i As Integer)
    '    Dim j As Integer
    '    Dim sqlstring As String
    '    ssGrid.TypeComboBoxClear(3, i)
    '    ssGrid.TypeComboBoxClear(6, i)
    '    sqlstring = "SELECT uomcode FROM UOMMaster WHERE ISNULL(Freeze,'') <> 'Y' ORDER BY uomcode ASC "
    '    gconnection.getDataSet(sqlstring, "UOMMaster1")
    '    If gdataset.Tables("UOMMaster1").Rows.Count > 0 Then
    '        For j = 0 To gdataset.Tables("UOMMaster1").Rows.Count - 1
    '            ssGrid.Col = 3
    '            ssGrid.Row = i
    '            ssGrid.TypeComboBoxString = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("uomcode"))

    '            ssGrid.TypeComboBoxIndex = j
    '            ssGrid.Col = 6
    '            ssGrid.Row = i
    '            ssGrid.TypeComboBoxString = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("uomcode"))
    '            ssGrid.TypeComboBoxIndex = j
    '        Next j
    '    End If
    'End Sub

    Private Sub txtBaseItem_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseItem.Validated
        Dim i As Integer
        Dim sname As String
        If Trim(txtBaseItem.Text) <> "" Then
            sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMDESC,'') AS ITEMDESC ,ISNULL(BASEUOMSTD,'') AS BASEUOMSTD FROM ITEMMASTER WHERE ITEMCODE =  '" & Trim(txtBaseItem.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' "
            gconnection.getDataSet(sqlstring, "ItemMaster")
            If gdataset.Tables("ItemMaster").Rows.Count > 0 Then
                txtBaseItem.Clear()
                txtBaseName.Clear()
                txtBaseItem.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("ITEMCODE"))
                txtBaseName.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("ITEMDESC"))
                cbo_QBaseUom.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("BASEUOMSTD"))
                ' ssGrid.ClearRange(1, 1, -1, -1, True)
                ' cbo_QBaseUom.Focus()
                TXT_SALEQTY.Focus()
            Else
                txtBaseItem.Clear()
                txtBaseName.Clear()
                ' ssGrid.ClearRange(1, 1, -1, -1, True)
                txtBaseItem.Focus()
                txtBaseItem.Focus()
            End If
        End If
        'End If
    End Sub
    Private Sub ItemFillMenu()
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        Dim J As Integer
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMDESC,'') AS ITEMDESC FROM ITEMMASTER"
        ' If Trim(Search) = " " Then
        ' M_WhereCondition = ""
        ' Else
        M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y' "
        ' End If
        vform.Field = "ITEMCODE,ITEMDESC"
        ' vform.Frmcalled = "  ITEMCODE           |                 ITEMDESC                   "
        vform.vCaption = "ITEM CODE HELP"
        ' vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With PROMOGRID
                .Col = 1
                .Row = .ActiveRow
                .Text = vform.keyfield
                '.Col = 2
                '.Row = .ActiveRow
                '.Text = vform.keyfield1
                If Trim(.Text) <> "" Then
                    sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMDESC,'') AS ITEMDESC ,ISNULL(BASEUOMSTD,'') AS BASEUOMSTD,ISNULL(BASERATESTD,0) AS BASERATESTD FROM ITEMMASTER WHERE ITEMCODE =  '" & Trim(.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' "
                    gconnection.getDataSet(sqlstring, "ItemMaster")
                    If gdataset.Tables("ItemMaster").Rows.Count > 0 Then
                        'txtBaseItem.Clear()
                        'txtBaseName.Clear()
                        '.Col = 1
                        '.Row = .ActiveRow
                        '.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("ITEMCODE"))
                        ''txtBaseName.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("ITEMDESC"))
                        '.Col = 2
                        '.Row = .ActiveRow
                        '.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("BASEUOMSTD"))
                        '' ssGrid.ClearRange(1, 1, -1, -1, True)
                        '' cbo_QBaseUom.Focus()
                        '.Col = 3
                        '.Row = .ActiveRow
                        '.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("BASERATESTD"))
                        ' TXT_SALEQTY.Focus()
                        ' PROMOGRID.SetText(1, .Row, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "")
                        Call GridUOM(PROMOGRID.ActiveRow)
                        PROMOGRID.SetText(2, .Row, Trim(gdataset.Tables("ItemMaster").Rows(J).Item("BASEUOMSTD")) & "")
                        PROMOGRID.SetText(3, .Row, Trim(gdataset.Tables("ItemMaster").Rows(J).Item("BASERATESTD")) & "")
                        If Cbo_TYPE.Text = "QTY" Then
                            PROMOGRID.SetActiveCell(3, PROMOGRID.ActiveRow)
                            .Col = 4
                            .Row = .ActiveRow
                            .Lock = False
                            .Col = 5
                            .Row = .ActiveRow
                            .Lock = True
                            .Col = 6
                            .Row = .ActiveRow
                            .Lock = True
                        ElseIf Cbo_TYPE.Text = "DISCOUNT " Then
                            PROMOGRID.SetActiveCell(4, PROMOGRID.ActiveRow)
                            .Col = 5
                            .Row = .ActiveRow
                            .Lock = False
                            .Col = 4
                            .Row = .ActiveRow
                            .Lock = True
                            .Col = 6
                            .Row = .ActiveRow
                            .Lock = True
                        ElseIf Cbo_TYPE.Text = "DISCOUNT ON RATE" Then
                            PROMOGRID.SetActiveCell(5, PROMOGRID.ActiveRow)
                            .Col = 6
                            .Row = .ActiveRow
                            .Lock = False
                            .Col = 5
                            .Row = .ActiveRow
                            .Lock = True
                            .Col = 4
                            .Row = .ActiveRow
                            .Lock = True
                        ElseIf Cbo_TYPE.Text = "FIXED RATE" Then
                            PROMOGRID.SetActiveCell(5, PROMOGRID.ActiveRow)
                            .Col = 4
                            .Row = .ActiveRow
                            .Lock = True
                            .Col = 5
                            .Row = .ActiveRow
                            .Lock = True
                            .Col = 6
                            .Row = .ActiveRow
                            .Lock = True
                        End If
                    Else
                        txtBaseItem.Clear()
                        txtBaseName.Clear()
                        ' ssGrid.ClearRange(1, 1, -1, -1, True)
                        txtBaseItem.Focus()
                    End If
                End If
                'PROMOGRID.SetActiveCell(2, PROMOGRID.ActiveRow)
            End With
        Else
            PROMOGRID.SetActiveCell(1, PROMOGRID.ActiveRow)
            Exit Sub
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub GridUOM(ByVal i As Integer)
        Dim j As Integer
        Dim sqlstring As String
        PROMOGRID.TypeComboBoxClear(3, i)
        PROMOGRID.TypeComboBoxClear(6, i)
        sqlstring = "SELECT uomcode FROM UOMMaster WHERE ISNULL(Freeze,'') <> 'Y' ORDER BY uomcode ASC "
        gconnection.getDataSet(sqlstring, "UOMMaster1")
        If gdataset.Tables("UOMMaster1").Rows.Count > 0 Then
            For j = 0 To gdataset.Tables("UOMMaster1").Rows.Count - 1
                PROMOGRID.Col = 2
                PROMOGRID.Row = i
                PROMOGRID.TypeComboBoxString = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("uomcode"))

                PROMOGRID.TypeComboBoxIndex = j
                'PROMOGRID.Col = 6
                'PROMOGRID.Row = i
                'PROMOGRID.TypeComboBoxString = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("uomcode"))
                'PROMOGRID.TypeComboBoxIndex = j
            Next j
        End If
    End Sub


    Private Sub PROMOGRID_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles PROMOGRID.KeyDownEvent
        Dim i, j As Integer
        Dim Itemcode As String
        Try
            If e.keyCode = Keys.Enter Then
                i = PROMOGRID.ActiveRow
                If PROMOGRID.ActiveCol = 1 Then
                    Itemcode = ""
                    PROMOGRID.Row = i
                    PROMOGRID.Col = 1
                    Itemcode = Trim(PROMOGRID.Text)
                    If Itemcode = "" Then
                        Call ItemFillMenu()
                    ElseIf Itemcode <> "" Then
                        PROMOGRID.ClearRange(1, PROMOGRID.ActiveRow, 5, PROMOGRID.ActiveRow, True)
                        sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMDESC,'') AS ITEMDESC,ISNULL(BASEUOMSTD,'') AS BASEUOMSTD,ISNULL(BASERATESTD,0) AS BASERATESTD FROM ITEMMASTER WHERE ISNULL(FREEZE,'') <> 'Y'"
                        sqlstring = sqlstring & " AND ITEMCODE = '" & Trim(Itemcode) & "'"
                        gconnection.getDataSet(sqlstring, "ITEMCODE")
                        If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                            PROMOGRID.SetText(1, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "")
                            PROMOGRID.SetText(2, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("BASEUOMSTD")) & "")
                            PROMOGRID.SetText(3, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("BASERATESTD")) & "")
                            ' PROMOGRID.SetText(4, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")) & "")
                            ' PROMOGRID.SetActiveCell(2, PROMOGRID.ActiveRow)
                            With PROMOGRID
                                If Cbo_TYPE.Text = "QTY" Then
                                    PROMOGRID.SetActiveCell(3, PROMOGRID.ActiveRow)
                                    .Col = 4
                                    .Row = .ActiveRow
                                    .Lock = False
                                    .Col = 5
                                    .Row = .ActiveRow
                                    .Lock = True
                                    .Col = 6
                                    .Row = .ActiveRow
                                    .Lock = True
                                ElseIf Cbo_TYPE.Text = "DISCOUNT " Then
                                    PROMOGRID.SetActiveCell(4, PROMOGRID.ActiveRow)
                                    .Col = 5
                                    .Row = .ActiveRow
                                    .Lock = False
                                    .Col = 4
                                    .Row = .ActiveRow
                                    .Lock = True
                                    .Col = 6
                                    .Row = .ActiveRow
                                    .Lock = True
                                ElseIf Cbo_TYPE.Text = "DISCOUNT ON RATE" Then
                                    PROMOGRID.SetActiveCell(5, PROMOGRID.ActiveRow)
                                    .Col = 6
                                    .Row = .ActiveRow
                                    .Lock = False
                                    .Col = 5
                                    .Row = .ActiveRow
                                    .Lock = True
                                    .Col = 4
                                    .Row = .ActiveRow
                                    .Lock = True
                                ElseIf Cbo_TYPE.Text = "FIXED RATE" Then
                                    PROMOGRID.SetActiveCell(5, PROMOGRID.ActiveRow)
                                    .Col = 4
                                    .Row = .ActiveRow
                                    .Lock = True
                                    .Col = 5
                                    .Row = .ActiveRow
                                    .Lock = True
                                    .Col = 6
                                    .Row = .ActiveRow
                                    .Lock = True
                                End If
                            End With
                        Else
                            MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            PROMOGRID.ClearRange(1, PROMOGRID.ActiveRow, 5, PROMOGRID.ActiveRow, True)
                            PROMOGRID.SetActiveCell(0, PROMOGRID.ActiveRow)
                            PROMOGRID.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                If PROMOGRID.ActiveCol = 1 Then
                    PROMOGRID.Row = PROMOGRID.ActiveRow
                    PROMOGRID.ClearRange(1, PROMOGRID.ActiveRow, 6, PROMOGRID.ActiveRow, True)
                    PROMOGRID.DeleteRows(PROMOGRID.ActiveRow, 1)
                End If
            ElseIf e.keyCode = Keys.Enter Then
                Cmb_FromDate.Focus()
                ' DAYSGRID.SetActiveCell(1, 1)
            ElseIf e.keyCode = Keys.Tab Then
                Cmb_FromDate.Focus()
            End If
            If e.keyCode = Keys.Enter Then
                If PROMOGRID.ActiveCol = 4 Then
                    If Cbo_TYPE.Text = "QTY" Then
                        If Val(PROMOGRID.Text) = 0 Then
                            PROMOGRID.SetText(4, PROMOGRID.ActiveRow, 1)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub PROMOGRID_KeyPressEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyPressEvent) Handles PROMOGRID.KeyPressEvent
        If Asc(e.keyAscii) = 13 Or PROMOGRID.ActiveCol = 1 Then
            Call GridUOM(PROMOGRID.ActiveRow)
        End If
    End Sub



    Private Sub TXT_SALEQTY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_SALEQTY.KeyDown
        If e.KeyCode = Keys.Enter Then
            PROMOGRID.Focus()
            PROMOGRID.SetActiveCell(1, 1)
        End If
        If e.KeyCode = Keys.Tab Then
            PROMOGRID.Focus()
            PROMOGRID.SetActiveCell(1, 1)
        End If
    End Sub

    Private Sub CHK_LOCATION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CHK_LOCATION.KeyDown
        If e.KeyCode = Keys.Enter Then
            DAYSGRID.Focus()
            DAYSGRID.SetActiveCell(1, 1)
        End If
        If e.KeyCode = Keys.Tab Then
            DAYSGRID.Focus()
            DAYSGRID.SetActiveCell(1, 1)
        End If
    End Sub

    Private Sub Cmb_FromDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmb_FromDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmb_ToDate.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            Cmb_ToDate.Focus()
        End If
    End Sub

    Private Sub Cmb_ToDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmb_ToDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            CHK_LOCATION.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            CHK_LOCATION.Focus()
        End If
    End Sub

    Private Sub txtPROMOcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPROMOcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            mskdate.Focus()
        ElseIf e.KeyCode = Keys.Tab Then
            mskdate.Focus()
        End If
    End Sub

    Private Sub mskdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_prodesc.Focus()
        ElseIf e.KeyCode = Keys.Tab Then
            txt_prodesc.Focus()
        End If
    End Sub

    Private Sub txt_prodesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_prodesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cbo_TYPE.Focus()
        ElseIf e.KeyCode = Keys.Tab Then
            Cbo_TYPE.Focus()
        End If
    End Sub

    Private Sub Cbo_TYPE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cbo_TYPE.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBaseItem.Focus()
        ElseIf e.KeyCode = Keys.Tab Then
            txtBaseItem.Focus()
        End If
    End Sub

    Private Sub DAYSGRID_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles DAYSGRID.KeyDownEvent
        If e.keyCode = Keys.Tab Then
            Cmd_Add.Focus()
        End If
        If e.keyCode = Keys.F3 Then
            If DAYSGRID.ActiveCol = 1 Then
                DAYSGRID.Row = DAYSGRID.ActiveRow
                DAYSGRID.ClearRange(1, DAYSGRID.ActiveRow, 6, DAYSGRID.ActiveRow, True)
                DAYSGRID.DeleteRows(DAYSGRID.ActiveRow, 1)
            End If
        End If
        With DAYSGRID
            Dim var1, var, var2, day, daylist As String
            Dim H, M, CNT As Integer

            If e.keyCode = Keys.Enter Then
                For I = 1 To DAYSGRID.DataRowCnt Step 1
                    If DAYSGRID.ActiveCol = 1 Then
                        DAYSGRID.Row = I
                        DAYSGRID.Col = 1
                        daylist = Trim(DAYSGRID.Text)
                        If (DAYSGRID.Text) <> "" Then
                            DAYSGRID.Row = .ActiveRow
                            DAYSGRID.Col = 1
                            day = Trim(DAYSGRID.Text)

                            If Trim(daylist) = Trim(day) Then
                                ' var1 = 0
                                'DAYSGRID.GetText(3, I, var1)
                                DAYSGRID.Col = 2
                                DAYSGRID.Row = I
                                var = Trim(DAYSGRID.Text)
                                DAYSGRID.Col = 3
                                DAYSGRID.Row = I
                                var1 = Trim(DAYSGRID.Text)
                                If var1 <> "00:00" Then
                                    If var < var1 Then
                                        H = Val(Mid(var1, 1, 2))
                                        M = Val(Mid(var1, 4, 2))
                                        .SetText(2, .ActiveRow, Format(H, "00") & ":" & Format(M, "00"))
                                        If H < 24 Then
                                            If M < 59 Then
                                                M = M + 1
                                                var2 = Format(H, "00") & ":" & Format(M, "00")
                                                'If DAYSGRID.MaxRows <= .ActiveRow + 1 Then
                                                '    DAYSGRID.MaxRows = .MaxRows + 1
                                                'End If
                                                DAYSGRID.SetText(2, .ActiveRow, var2)
                                                DAYSGRID.Col = 2
                                                DAYSGRID.Row = .ActiveRow
                                                DAYSGRID.Lock = True
                                                ' DAYSGRID.SetActiveCell(2, .ActiveRow)

                                            Else
                                                If H < 23 Then
                                                    M = 0
                                                    var2 = Format(H + 1, "00") & ":" & Format(M, "00")
                                                    'If DAYSGRID.MaxRows <= .ActiveRow + 1 Then
                                                    '    DAYSGRID.MaxRows = .MaxRows + 1
                                                    'End If
                                                    DAYSGRID.SetText(2, .ActiveRow, var2)
                                                    DAYSGRID.Col = 2
                                                    DAYSGRID.Row = .ActiveRow
                                                    DAYSGRID.Lock = True
                                                Else
                                                    MsgBox("TIME HAD BEEN ALLOTED FOR THIS DAY ")
                                                    ' DAYSGRID.ClearRange(1, 1, 3, .MaxRows, False)
                                                    DAYSGRID.Col = 1
                                                    DAYSGRID.Row = .ActiveRow
                                                    DAYSGRID.Text = ""
                                                    DAYSGRID.Col = 2
                                                    DAYSGRID.Row = .ActiveRow
                                                    DAYSGRID.Text = ""
                                                    DAYSGRID.Col = 3
                                                    DAYSGRID.Row = .ActiveRow
                                                    DAYSGRID.Text = ""

                                                End If

                                            End If
                                        Else
                                            var = Nothing
                                            var1 = Nothing
                                            var2 = Nothing

                                        End If
                                    Else
                                        'MsgBox("RECORD ALREADY EXISTS ")
                                        '' DAYSGRID.ClearRange(1, 1, 3, .MaxRows, False)
                                        'DAYSGRID.Col = 1
                                        'DAYSGRID.Row = I
                                        'DAYSGRID.Text = ""
                                        'DAYSGRID.SetActiveCell(3, .ActiveRow)
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        End With
        'Dim VAR, VAR1, VAR2, VAR3, VAR4, daylist, DAY As String
        'Dim H, M As Integer
        '' If Asc(e.keyCode) = 49 Then
        'If e.keyCode = Keys.Enter Then
        '    With DAYSGRID
        '        .Col = .ActiveCol
        '        .Row = .ActiveRow
        '        'If .Col = 2 Then
        '        '    If .Text <> "" Then
        '        '        .GetText(2, 1, VAR4)
        '        '        If VAR4 <> "00:01" Then
        '        '            MsgBox("WRONG INPUT STARTING TIME")
        '        '            DAYSGRID.ClearRange(1, 1, 3, DAYSGRID.MaxRows, False)
        '        '        End If
        '        '        .GetText(2, .ActiveRow, VAR)
        '        '        If VAR <> "00:00" Then
        '        '            '.SetText(1, .ActiveRow, Format(.Text, "00:00"))
        '        '        Else
        '        '            MsgBox("WRONG INPUT TIME")
        '        '            'DAYSGRID.ClearRange(1, 1, 3, DAYSGRID.MaxRows, False)
        '        '        End If
        '        '        '.Col = 2
        '        '        '.Row = .ActiveRow
        '        '        DAYSGRID.SetActiveCell(3, .ActiveRow)
        '        '    Else
        '        '        .SetActiveCell(1, .ActiveRow)
        '        '    End If
        '        If .Col = 1 Then
        '            For I = 1 To DAYSGRID.DataRowCnt Step 1

        '                DAYSGRID.Row = I
        '                DAYSGRID.Col = 1
        '                daylist = Trim(DAYSGRID.Text)
        '                If (DAYSGRID.Text) <> "" Then
        '                    DAYSGRID.Row = .ActiveRow
        '                    DAYSGRID.Col = 1
        '                    DAY = Trim(DAYSGRID.Text)

        '                    If Trim(daylist) = Trim(DAY) Then

        '                        ' DAYSGRID.GetText(1, .ActiveRow, VAR)
        '                        DAYSGRID.Row = .ActiveRow - 1
        '                        DAYSGRID.Col = 2
        '                        VAR = Trim(.Text)
        '                        If Trim(VAR) = "" Then
        '                            DAYSGRID.SetActiveCell(2, .ActiveRow)
        '                        ElseIf .Text <> "" Then
        '                            '.SetText(2, .ActiveRow, .Text, "00:00"))
        '                            'DAYSGRID.GetText(3, .ActiveRow, VAR1)
        '                            DAYSGRID.Col = 3
        '                            DAYSGRID.Row = .ActiveRow
        '                            VAR1 = Trim(.Text)
        '                            If VAR1 <> "00:00" Then
        '                                If VAR < VAR1 Then
        '                                    H = Val(Mid(VAR1, 1, 2))
        '                                    M = Val(Mid(VAR1, 4, 2))
        '                                    .SetText(2, .ActiveRow, Format(H, "00") & ":" & Format(M, "00"))
        '                                    If H < 24 Then
        '                                        If M < 59 Then
        '                                            M = M + 1
        '                                            VAR2 = Format(H, "00") & ":" & Format(M, "00")
        '                                            'If DAYSGRID.MaxRows <= .ActiveRow + 1 Then
        '                                            '    DAYSGRID.MaxRows = .MaxRows + 1
        '                                            'End If
        '                                            DAYSGRID.SetText(1, .ActiveRow, VAR2)
        '                                            DAYSGRID.Col = 2
        '                                            DAYSGRID.Row = .ActiveRow
        '                                            DAYSGRID.Lock = True
        '                                        Else
        '                                            If H < 23 Then
        '                                                M = 0
        '                                                VAR2 = Format(H + 1, "00") & ":" & Format(M, "00")
        '                                                'If DAYSGRID.MaxRows <= .ActiveRow + 1 Then
        '                                                '    DAYSGRID.MaxRows = .MaxRows + 1
        '                                                'End If
        '                                                DAYSGRID.SetText(1, .ActiveRow, VAR2)
        '                                                DAYSGRID.Col = 2
        '                                                DAYSGRID.Row = .ActiveRow
        '                                                DAYSGRID.Lock = True
        '                                            Else
        '                                                MsgBox("TIME HAD BEEN ALLOTED FOR THIS DAY ")
        '                                                ' DAYSGRID.ClearRange(1, 1, 3, .MaxRows, False)
        '                                                DAYSGRID.Col = 1
        '                                                DAYSGRID.Row = .ActiveRow
        '                                                DAYSGRID.Text = ""

        '                                            End If

        '                                        End If
        '                                    Else
        '                                        VAR = Nothing
        '                                        VAR1 = Nothing
        '                                        VAR2 = Nothing
        '                                    End If
        '                                Else
        '                                    MsgBox("FROM TIME CANNOT BE GREATER THAN TO TIME")
        '                                    ' DAYSGRID.ClearRange(1, 1, 3, .MaxRows, False)
        '                                End If
        '                            Else
        '                                MsgBox("WRONG INPUT TIME")
        '                                ' DAYSGRID.ClearRange(1, 1, 3, .MaxRows, False)
        '                            End If
        '                            DAYSGRID.SetActiveCell(3, .ActiveRow)

        '                        Else
        '                            DAYSGRID.SetActiveCell(2, .ActiveRow)
        '                        End If

        '                    End If

        '                End If
        '            Next

        '        ElseIf .Col = 3 Then
        '            DAYSGRID.GetText(1, .ActiveRow, VAR3)
        '            DAYSGRID.GetText(2, .ActiveRow, VAR2)
        '            If Trim(VAR3) = "" Then
        '                DAYSGRID.SetActiveCell(1, .ActiveRow)
        '            ElseIf Trim(VAR2) = "" Then
        '                DAYSGRID.SetActiveCell(2, .ActiveRow)
        '            ElseIf .Text <> "" Then
        '                DAYSGRID.SetText(3, .ActiveRow, Format(Val(.Text), "0.00"))
        '                DAYSGRID.SetActiveCell(1, .ActiveRow + 1)
        '            Else
        '                DAYSGRID.SetActiveCell(3, .ActiveRow)
        '            End If
        '        End If

        ' End With
        '  End If
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Call checkValidation()
        If boolchk = False Then Exit Sub
        Dim i, j, k As Integer
        Dim loc As String()
        Dim BASEDON As String
        k = 0
        ' QTY()
        ' FIXEDRate
        'DISCOUNT ON RATE
        Dim itemcode, Insert(0), SqlArray(0) As String
        ' Dim sql(Me.PROMOGRID.DataRowCnt + 20) As String
        Dim sql As String
        Dim Y As Integer
        If Cbo_TYPE.Text = "QTY" Then
            BASEDON = "Q"
        ElseIf Cbo_TYPE.Text = "DISCOUNT " Then
            BASEDON = "D"
        ElseIf Cbo_TYPE.Text = "FIXED RATE" Then
            BASEDON = "F"
        Else
            BASEDON = "P"
        End If
        If Mid(Cmd_Add.Text, 1, 1) = "A" Then
            Dim loccode, day As String
            For i = 0 To Me.CHK_LOCATION.CheckedItems.Count - 1
                loc = Split(CHK_LOCATION.CheckedItems(i), "-->")
                loccode = loc(0)
                'Call checkvalidation() ''-->Check Validation
                Dim tm, FM As String
                Dim WDAY As String
                With DAYSGRID
                    For j = 1 To .DataRowCnt
                        .Col = 1
                        .Row = j
                        WDAY = .Text
                        .Col = 2
                        .Row = j
                        FM = .Text
                        .Col = 3
                        .Row = j
                        tm = .Text
                        If Trim(WDAY) <> "" Then
                            'If rdbQty.Checked = True Then
                            ' Call checkValidation()
                            'If boolchk = False Then Exit Sub

                            With PROMOGRID
                                For Y = 1 To .DataRowCnt
                                    .Col = 1
                                    .Row = Y
                                    itemcode = .Text
                                    If Trim(itemcode) <> "" Then
                                        'sql = "INSERT INTO PROMMASTER (BASEDON,BASEDITEMCODE,BASEDUOM,PITEMCODE,PITEMDESC,FROMQTY,TOQTY,FREEQTY,PUOM,FROMDATE,TODATE,ADDUSER,ADDDATETIME) Values("
                                        sql = "INSERT INTO PROMMASTER (POSCODE,PROMOCODE,PROMODATE,PROMODESC,BASEDON,BASEDITEMCODE,basename,BASEDUOM,SALEQTY,PITEMCODE,PUOM,SALERATE,FREEQTY,DISCOUNT,Discountprice,WDAY,FROMTIME,TOTIME,FROMDATE,TODATE,FREEZE,ADDUSER,ADDDATETIME) Values("
                                        sql = sql & " '" & Trim(loccode) & "',"
                                        sql = sql & "'" & Trim(txtPROMOcode.Text) & "','" & Format(mskdate.Value, "dd-MMM-yyyy") & "','" & Trim(txt_prodesc.Text) & "',"
                                        sql = sql & "'" & BASEDON & "','" & Trim(txtBaseItem.Text) & "','" & Trim(txtBaseName.Text) & "','" & Trim(cbo_QBaseUom.Text) & "'," & Val(TXT_SALEQTY.Text) & ","
                                        sql = sql & " '" & Trim(itemcode) & "',"
                                        .Col = 2
                                        .Row = Y
                                        sql = sql & " '" & Trim(.Text) & "',"
                                        .Col = 3
                                        .Row = Y
                                        sql = sql & " " & Val(.Text) & ","
                                        .Col = 4
                                        .Row = Y
                                        sql = sql & " " & Val(.Text) & ","
                                        .Col = 5
                                        .Row = Y
                                        sql = sql & " " & Val(.Text) & ","
                                        .Col = 6
                                        .Row = Y
                                        sql = sql & " " & Val(.Text) & ","
                                        'sql = sql & " '" & Trim(.Text) & "',"
                                        sql = sql & " '" & Trim(WDAY) & "',"
                                        sql = sql & " '" & Trim(FM) & "',"
                                        sql = sql & " '" & Trim(tm) & "',"
                                        sql = sql & "'" & Format(Cmb_FromDate.Value, "dd-MMM-yyyy") & "',"
                                        sql = sql & "'" & Format(Cmb_ToDate.Value, "dd-MMM-yyyy") & "','N',"
                                        sql = sql & "'" & gUsername & "',"
                                        sql = sql & "'" & Format(Now, "dd-MMM-yyyy") & "')"
                                    End If
                                Next Y

                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sql
                                'ReDim Preserve sql(sql.Length)
                                'sql(sql.Length - 1) = sql


                            End With

                            'End If
                            'ElseIf Mid(Cmd_Add.Text, 1, 1) = "U" Then
                            '    'Call checkvalidation() ''-->Check Validation
                            '    ' Dim itemcode, uom, qty, Insert(0), SqlArray(0) As String
                            '    ' Dim sql(Me.PROMOGRID.DataRowCnt + 20) As String
                            '    'Dim Y As Integer
                            '    sql = " DELETE FROM PROMMASTER WHERE   PROMOCODE = '" & Trim(txtPROMOcode.Text) & "'"

                            '    ReDim Preserve Insert(Insert.Length)
                            '    Insert(Insert.Length - 1) = sql

                            '    With PROMOGRID
                            '        For Y = 1 To .DataRowCnt
                            '            .Col = 1
                            '            .Row = Y
                            '            itemcode = .Text
                            '            If Trim(itemcode) <> "" Then
                            '                'sql = "INSERT INTO PROMMASTER (BASEDON,BASEDITEMCODE,BASEDUOM,PITEMCODE,PITEMDESC,FROMQTY,TOQTY,FREEQTY,PUOM,FROMDATE,TODATE,ADDUSER,ADDDATETIME) Values("
                            '                sql = "INSERT INTO PROMMASTER (POSCODE,PROMOCODE,PROMODATE,PROMODESC,BASEDON,BASEDITEMCODE,basename,BASEDUOM,SALEQTY,PITEMCODE,PUOM,SALERATE,FREEQTY,FIXEDRATE,DISCOUNT,WDAY,FROMTIME,TOTIME,FROMDATE,TODATE,ADDUSER,ADDDATETIME) Values("
                            '                sql = sql & " '" & Trim(loccode) & "',"
                            '                sql = sql & "'" & Trim(txtPROMOcode.Text) & "','" & Format(mskdate.Value, "dd-MMM-yyyy") & "','" & Trim(txt_prodesc.Text) & "',"
                            '                sql = sql & "'" & BASEDON & "','" & Trim(txtBaseItem.Text) & "','" & Trim(txtBaseName.Text) & "','" & Trim(cbo_QBaseUom.Text) & "'," & Val(TXT_SALEQTY.Text) & ","
                            '                sql = sql & " '" & Trim(itemcode) & "',"
                            '                .Col = 2
                            '                .Row = Y
                            '                sql = sql & " '" & Trim(.Text) & "',"
                            '                .Col = 3
                            '                .Row = Y
                            '                sql = sql & " " & Val(.Text) & ","
                            '                .Col = 4
                            '                .Row = Y
                            '                sql = sql & " " & Val(.Text) & ","
                            '                .Col = 5
                            '                .Row = Y
                            '                sql = sql & " " & Val(.Text) & ","
                            '                .Col = 6
                            '                .Row = Y
                            '                sql = sql & " " & Val(.Text) & ","
                            '                'sql = sql & " '" & Trim(.Text) & "',"
                            '                sql = sql & " '" & Trim(WDAY) & "',"
                            '                sql = sql & " '" & Trim(FM) & "',"
                            '                sql = sql & " '" & Trim(tm) & "',"
                            '                sql = sql & "'" & Format(Cmb_FromDate.Value, "dd-MMM-yyyy") & "',"
                            '                sql = sql & "'" & Format(Cmb_ToDate.Value, "dd-MMM-yyyy") & "',"
                            '                sql = sql & "'" & gUsername & "',"
                            '                sql = sql & "'" & Format(Now, "dd-MMM-yyyy") & "')"
                            '            End If
                            '        Next Y

                            '        ReDim Preserve Insert(Insert.Length)
                            '        Insert(Insert.Length - 1) = sql
                            '        'ReDim Preserve sql(sql.Length)
                            '        'sql(sql.Length - 1) = sql


                            '    End With





                        End If
                    Next j

                End With

            Next i
            'sql = ""
        ElseIf Mid(Cmd_Add.Text, 1, 1) = "U" Then
            Dim loccode, day As String
            ' Call checkValidation()

            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK)
                    boolchk = False
                    Exit Sub
                End If
            End If

            sql = " DELETE FROM PROMMASTER WHERE   PROMOCODE = '" & Trim(txtPROMOcode.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sql

            For i = 0 To Me.CHK_LOCATION.CheckedItems.Count - 1
                loc = Split(CHK_LOCATION.CheckedItems(i), "-->")
                loccode = loc(0)
                'Call checkvalidation() ''-->Check Validation
                Dim tm, FM As String
                Dim WDAY As String
                With DAYSGRID
                    For j = 1 To .DataRowCnt
                        .Col = 1
                        .Row = j
                        WDAY = .Text
                        .Col = 2
                        .Row = j
                        FM = .Text
                        .Col = 3
                        .Row = j
                        tm = .Text
                        If Trim(WDAY) <> "" Then
                            'If rdbQty.Checked = True Then
                            ' Call checkValidation()
                            'If boolchk = False Then Exit Sub




                            With PROMOGRID
                                For Y = 1 To .DataRowCnt
                                    .Col = 1
                                    .Row = Y
                                    itemcode = .Text
                                    If Trim(itemcode) <> "" Then
                                        'sql = "INSERT INTO PROMMASTER (BASEDON,BASEDITEMCODE,BASEDUOM,PITEMCODE,PITEMDESC,FROMQTY,TOQTY,FREEQTY,PUOM,FROMDATE,TODATE,ADDUSER,ADDDATETIME) Values("
                                        sql = "INSERT INTO PROMMASTER (POSCODE,PROMOCODE,PROMODATE,PROMODESC,BASEDON,BASEDITEMCODE,basename,BASEDUOM,SALEQTY,PITEMCODE,PUOM,SALERATE,FREEQTY,DISCOUNT,Discountprice,WDAY,FROMTIME,TOTIME,FROMDATE,TODATE,FREEZE,ADDUSER,ADDDATETIME,UPDATEUSER,UPDATETIME) Values("
                                        sql = sql & " '" & Trim(loccode) & "',"
                                        sql = sql & "'" & Trim(txtPROMOcode.Text) & "','" & Format(mskdate.Value, "dd-MMM-yyyy") & "','" & Trim(txt_prodesc.Text) & "',"
                                        sql = sql & "'" & BASEDON & "','" & Trim(txtBaseItem.Text) & "','" & Trim(txtBaseName.Text) & "','" & Trim(cbo_QBaseUom.Text) & "'," & Val(TXT_SALEQTY.Text) & ","
                                        sql = sql & " '" & Trim(itemcode) & "',"
                                        .Col = 2
                                        .Row = Y
                                        sql = sql & " '" & Trim(.Text) & "',"
                                        .Col = 3
                                        .Row = Y
                                        sql = sql & " " & Val(.Text) & ","
                                        .Col = 4
                                        .Row = Y
                                        sql = sql & " " & Val(.Text) & ","
                                        .Col = 5
                                        .Row = Y
                                        sql = sql & " " & Val(.Text) & ","
                                        .Col = 6
                                        .Row = Y
                                        sql = sql & " " & Val(.Text) & ","
                                        'sql = sql & " '" & Trim(.Text) & "',"
                                        sql = sql & " '" & Trim(WDAY) & "',"
                                        sql = sql & " '" & Trim(FM) & "',"
                                        sql = sql & " '" & Trim(tm) & "',"
                                        sql = sql & "'" & Format(Cmb_FromDate.Value, "dd-MMM-yyyy") & "',"
                                        sql = sql & "'" & Format(Cmb_ToDate.Value, "dd-MMM-yyyy") & "','N',"
                                        sql = sql & "'" & gUsername & "',"
                                        sql = sql & "'" & Format(Now, "dd-MMM-yyyy") & "',"
                                        sql = sql & "'" & gUsername & "',"
                                        sql = sql & "'" & Format(Now, "dd-MMM-yyyy") & "')"
                                    End If
                                Next Y

                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sql
                                'ReDim Preserve sql(sql.Length)
                                'sql(sql.Length - 1) = sql


                            End With
                        End If
                    Next j

                End With

            Next i

        End If
        gconnection.MoreTransold(Insert)
        Me.Cmd_Clear_Click(sender, e)
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        txtPROMOcode.Text = ""
        txt_prodesc.Text = ""
        mskdate.Value = Now
        txtBaseItem.Text = ""
        txtBaseName.Text = ""
        cbo_QBaseUom.Text = ""
        TXT_SALEQTY.Text = ""
        DAYSGRID.Enabled = True
        PROMOGRID.ClearRange(1, 1, -1, -1, True)
        DAYSGRID.ClearRange(1, 1, -1, -1, True)
        Cmb_ToDate.Value = Today
        Cmb_FromDate.Value = Today
        Cbo_TYPE.SelectedIndex = 0
        CHK_LOCATION.Items.Clear()
        Call FILLLOC()
        txtPROMOcode.Focus()
        Cmd_Add.Text = "Add [F7]"
        Cmd_Freeze.Enabled = True
        lbl_Freeze.Visible = False

    End Sub

    Private Sub cmdPROMOHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPROMOHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT distinct PROMOCODE , PROMODATE FROM PROMMASTER  "
        'If Trim(Search) = " " Then
        M_WhereCondition = " "
        'Else
        ' M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y' "
        'End If        
        vform.Field = "PROMOCODE,PROMODATE"
        'vform.Frmcalled = "         PROMOCODE            |            PROMODATE                             "
        vform.vCaption = "PROMO MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txtPROMOcode.Text = Trim(vform.keyfield & "")
            Call txtPROMOcode_Validated(txtBaseItem, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub


    Private Sub txtPROMOcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPROMOcode.KeyPress
        getAlphanumeric(e)

        If Asc(e.KeyChar) = 13 Then
            If txtPROMOcode.Text <> "" Then
                txtPROMOcode_Validated(sender, e)
                'txtPROMOcode.Focus()
            Else
                Call cmdPROMOHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtPROMOcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPROMOcode.Validated
        Dim i As Integer
        Dim sname, SSQL, VarPOSCODE(0) As String
        If Trim(txtPROMOcode.Text) <> "" Then
            sqlstring = "SELECT ISNULL(PROMODESC,'') AS PROMODESC,isnull(PROMODATE,'') as PROMODATE,isnull(BASEDON,'') AS BASEDON,ISNULL(BASEDITEMCODE,'') AS BASEDITEMCODE,ISNULL(basename,'') AS basename,isnull(saleqty,0) as saleqty, ISNULL(PITEMCODE,'') AS PITEMCODE,ISNULL(BASEDUOM,'') AS BASEDUOM,ISNULL(PUOM,'') AS PUOM,"
            sqlstring = sqlstring & "ISNULL(PITEMDESC,'') AS PITEMDESC,ISNULL(FROMQTY,0) AS FROMQTY,ISNULL(TOQTY,0) AS TOQTY,ISNULL(FREEQTY,0) AS FREEQTY,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATETIME,ISNULL(FROMDATE,'') AS FROMDATE,ISNULL(TODATE,'') AS TODATE,ISNULL(FROMTIME,'') AS FROMTIME,ISNULL(TOTIME,'') AS TOTIME,isnull(wday,'') as  wday,isnull(salerate,0) as salerate,isnull(discount,0) as discount,isnull(fixedrate,0) as fixedrate,isnull(Discountprice,0) as Discountprice,isnull(freeze,'') as freeze,isnull(voiddate,'') as voiddate  FROM PROMMASTER"
            sqlstring = sqlstring & " WHERE  ISNULL(PROMOCODE,'') = '" & Trim(txtPROMOcode.Text) & "'"
            gconnection.getDataSet(sqlstring, "PromMaster")
            If gdataset.Tables("PromMaster").Rows.Count > 0 Then
                txt_prodesc.Text = Trim(gdataset.Tables("PromMaster").Rows(0).Item("PROMODESC"))
                mskdate.Value = Format(gdataset.Tables("PromMaster").Rows(0).Item("PROMODATE"), "dd/MM/yyyy")
                ' sname = "SELECT ITEMDESC FROM ITEMMASTER WHERE ITEMCODE = '" & Trim(txtBaseItem.Text) & "'"
                'gconnection.getDataSet(sname, "ITEMNAME")
                'If gdataset.Tables("ITEMNAME").Rows.Count > 0 Then
                '    txtBaseName.Text = Trim(gdataset.Tables("ITEMNAME").Rows(0).Item("ITEMDESC"))
                'End If
                ' txtBaseItem.ReadOnly = True
                Cbo_TYPE.Text = Trim(gdataset.Tables("PromMaster").Rows(0).Item("BASEDON"))
                If Trim(gdataset.Tables("PromMaster").Rows(0).Item("BASEDON")) = "Q" Then
                    Cbo_TYPE.SelectedIndex = 0
                ElseIf Trim(gdataset.Tables("PromMaster").Rows(0).Item("BASEDON")) = "F" Then
                    Cbo_TYPE.SelectedIndex = 1
                ElseIf Trim(gdataset.Tables("PromMaster").Rows(0).Item("BASEDON")) = "P" Then
                    Cbo_TYPE.SelectedIndex = 2
                ElseIf Trim(gdataset.Tables("PromMaster").Rows(0).Item("BASEDON")) = "D" Then
                    Cbo_TYPE.SelectedIndex = 3
                End If
                txtBaseItem.Text = Trim(gdataset.Tables("PromMaster").Rows(0).Item("BASEDITEMCODE"))
                txtBaseName.Text = Trim(gdataset.Tables("PromMaster").Rows(0).Item("basename"))
                TXT_SALEQTY.Text = Val(gdataset.Tables("PromMaster").Rows(0).Item("saleqty"))
                cbo_QBaseUom.Text = Trim(gdataset.Tables("PromMaster").Rows(0).Item("BASEDUOM"))
                Cmb_FromDate.Value = Format(gdataset.Tables("PromMaster").Rows(0).Item("FROMDATE"), "dd/MM/yyyy")
                Cmb_ToDate.Value = Format(gdataset.Tables("PromMaster").Rows(0).Item("TODATE"), "dd/MM/yyyy")

                SSQL = "SELECT DISTINCT PITEMCODE FROM PROMMASTER WHERE PROMOCODE='" & txtPROMOcode.Text & "'"
                gconnection.getDataSet(SSQL, "PROITEM")
                If gdataset.Tables("PROITEM").Rows.Count > 0 Then
                    For i = 0 To gdataset.Tables("PROITEM").Rows.Count - 1
                        With PROMOGRID
                            .Row = i + 1
                            .Col = 1
                            .Text = Trim(gdataset.Tables("PromMaster").Rows(i).Item("PITEMCODE"))
                            '.Col = 2
                            '.Text = Trim(gdataset.Tables("PromMaster").Rows(i).Item("PITEMDESC"))
                            Call GridUOM(i + 1)
                            .Col = 2
                            .Text = gdataset.Tables("PromMaster").Rows(i).Item("PUOM")
                            .Col = 3
                            .Text = gdataset.Tables("PromMaster").Rows(i).Item("salerate")
                            .Col = 4
                            .Text = gdataset.Tables("PromMaster").Rows(i).Item("FREEQTY")

                            .Col = 5
                            .Text = Trim(gdataset.Tables("PromMaster").Rows(i).Item("Discount"))
                            .Col = 6
                            .Text = Trim(gdataset.Tables("PromMaster").Rows(i).Item("Discountprice"))
                        End With
                    Next
                End If
                If gdataset.Tables("PromMaster").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("PromMaster").Rows(0).Item("voiddate")), "dd-MMM-yyyy")
                    ' Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If
                SSQL = "SELECT DISTINCT POSCODE FROM PROMMASTER WHERE PROMOCODE='" & txtPROMOcode.Text & "'"
                gconnection.getDataSet(SSQL, "POSMenuLink")
                If gdataset.Tables("PosMenuLink").Rows.Count > 0 Then
                    For i = 0 To gdataset.Tables("PosMenuLink").Rows.Count - 1
                        For j = 0 To CHK_LOCATION.Items.Count - 1
                            VarPOSCODE = Split(Trim(CHK_LOCATION.Items(j)), "-->")
                            If Trim(gdataset.Tables("PosMenuLink").Rows(i).Item("POSCODE")) = Trim(VarPOSCODE(0)) Then
                                CHK_LOCATION.SetItemChecked(j, True)
                                CHK_LOCATION.SelectedItem = gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE")
                            End If
                        Next j
                    Next
                End If
                ' Next
                'For i = 0 To gdataset.Tables("PromMaster").Rows.Count - 1
                SSQL = "SELECT DISTINCT WDAY,FROMTIME FROM PROMMASTER WHERE PROMOCODE='" & txtPROMOcode.Text & "'"
                gconnection.getDataSet(SSQL, "WDAY")
                If gdataset.Tables("WDAY").Rows.Count > 0 Then
                    For i = 0 To gdataset.Tables("WDAY").Rows.Count - 1
                        With DAYSGRID
                            .Row = i + 1
                            .Col = 1
                            '.Text = Trim(gdataset.Tables("PromMaster").Rows(i).Item("PITEMCODE"))
                            ''.Col = 2
                            ''.Text = Trim(gdataset.Tables("PromMaster").Rows(i).Item("PITEMDESC"))
                            '' Call GridUOM(i + 1)
                            '.Col = 2
                            '.Text = gdataset.Tables("PromMaster").Rows(i).Item("PUOM")
                            '.Col = 3
                            '.Text = gdataset.Tables("PromMaster").Rows(i).Item("salerate")
                            '.Col = 4
                            '.Text = gdataset.Tables("PromMaster").Rows(i).Item("FREEQTY")
                            '.Col = 1
                            .Text = gdataset.Tables("PromMaster").Rows(i).Item("WDAY")
                            .Col = 2
                            .Text = Format(gdataset.Tables("PromMaster").Rows(i).Item("fromtime"), "HH:mm")
                            .Col = 3
                            .Text = Format(gdataset.Tables("PromMaster").Rows(i).Item("totime"), "HH:mm")
                        End With

                    Next
                End If
                Cmd_Add.Text = "Update[F7]"
                'cbo_QBaseUom.Focus()
                DAYSGRID.Enabled = False
            Else
                'sqlstring = "SELECT * FROM PROMMASTER WHERE BASEDITEMCODE = '" & Trim(txtBaseItem.Text) & "'"
                'gconnection.getDataSet(sqlstring, "ALREADY")
                'If gdataset.Tables("ALREADY").Rows.Count > 0 Then
                '    MessageBox.Show("Promotional Already Given", "Promotional", MessageBoxButtons.OK)
                '    Call Cmd_Clear_Click(sender, e)
                '    Exit Sub
                'End If
                'sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMDESC,'') AS ITEMDESC FROM ITEMMASTER WHERE ITEMCODE =  '" & Trim(txtBaseItem.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' "
                'gconnection.getDataSet(sqlstring, "ItemMaster")
                'If gdataset.Tables("ItemMaster").Rows.Count > 0 Then
                '    txtBaseItem.Clear()
                '    txtBaseName.Clear()
                '    txtBaseItem.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("ITEMCODE"))
                '    txtBaseName.Text = Trim(gdataset.Tables("ItemMaster").Rows(0).Item("ITEMDESC"))
                '    ssGrid.ClearRange(1, 1, -1, -1, True)
                '    cbo_QBaseUom.Focus()
                'Else
                '    txtBaseItem.Clear()
                '    txtBaseName.Clear()
                '    ssGrid.ClearRange(1, 1, -1, -1, True)
                '    txtBaseItem.Focus()
                'End If
            End If
        End If

    End Sub

    Private Sub Cbo_TYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_TYPE.SelectedIndexChanged
        'If PROMOGRID.ActiveCol = 1 Then

        'PROMOGRID.Row = PROMOGRID.ActiveRow
        ' PROMOGRID.ClearRange(1, PROMOGRID.ActiveRow, 6, PROMOGRID.ActiveRow, True)
        ' PROMOGRID.DeleteRows(PROMOGRID.ActiveRow, 1)
        
        PROMOGRID.ClearRange(1, 1, -1, -1, True)
        'End If
    End Sub

    Private Sub Cmb_ToDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_ToDate.ValueChanged


        ' Checkdaterangevalidate(Cmb_FromDate.Value, Cmb_ToDate.Value)

        If DateDiff(DateInterval.Day, Cmb_FromDate.Value, Cmb_ToDate.Value) < 0 Then
            MessageBox.Show("From Date cannot be greater than To Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            'chkdatevalidate = False
            Cmb_ToDate.Value = Cmb_FromDate.Value
            ' Exit Sub
        End If
        'If DateDiff(DateInterval.Day, Cmb_FromDate.Value, Cmb_ToDate.Value) > 0 Then
        '    MessageBox.Show("TO Date cannot be greater than To Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    chkdatevalidate = False
        '    Exit Sub
        'End If
        If CDate(Cmb_FromDate.Value) >= CDate(Cmb_FromDate.Value) And CDate(Cmb_ToDate.Value) <= CDate(Cmb_ToDate.Value) Then
            chkdatevalidate = True
        Else
            MsgBox("Date should be within Financial Year", MsgBoxStyle.Critical)
            chkdatevalidate = False
            Exit Sub
        End If
        ' If chkdatevalidate = False Then Exit Sub
        Dim dys, days As String
        Dim daylist()
        years = DateDiff("d", Cmb_FromDate.Value, Cmb_ToDate.Value)

        'If Format(Cmb_FromDate.Value, "dd/MM/yyyy") = Format(Cmb_ToDate.Value, "dd/MM/yyyy") Then
        'Else
        ' years = years + 1
        ' End If

        'For i = 0 To years
        '    daylist = Cmb_FromDate.Value.DayOfWeek.ToString()
        '    dys = " '" & daylist(0) & "'"
        'Next

        chk_days.Items.Clear()
        Dim startDay As Date
        Dim endDay As Date
        startDay = Cmb_FromDate.Value
        endDay = Format(Cmb_ToDate.Value, "dd/MM/yyyy")
        Dim dayCtr As Date
        dayCtr = Format(startDay, "dd/MM/yyyy")

        If (dayCtr <= endDay) Then
            For j = 0 To years
                If j < 7 Then
                    'MessageBox.Show(dayCtr.Date.Day & "-" & dayCtr.Date.DayOfWeek.ToString())
                    dys = dayCtr.Date.Day & "-" & dayCtr.Date.DayOfWeek.ToString()
                    daylist = Split(dys, "-")
                    days = " " & daylist(1) & ""
                    ' For i = 0 To daylist.Count
                    chk_days.Items.Add(Trim(days))
                    'Next
                    dayCtr = dayCtr.AddDays(1)

                End If
            Next
            'End While
        End If
        With DAYSGRID
            'DAYSGRID.Col = .ActiveCol
            'DAYSGRID.Row = 1
            Dim VAR As String = Trim(DAYSGRID.Text)
            If VAR <> "" Then
                DAYSGRID.ClearRange(1, 1, -1, -1, True)
            End If
        End With
        If DAYSGRID.Enabled = False Then
            DAYSGRID.Enabled = True
        End If
    End Sub

    Private Sub DAYSGRID_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles DAYSGRID.Advance

    End Sub

    Private Sub DAYSGRID_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles DAYSGRID.LeaveCell
        Dim day, daylist As String
        Dim i, CNT As Integer
        'i = DAYSGRID.ActiveRow
        'With DAYSGRID
        '    ' .Col = 1
        '    If DAYSGRID.ActiveCol = 1 Then
        '        .Row = i
        '        day = .Text
        '        If chk_days.Items.Contains(day) Then
        '        Else
        '            MessageBox.Show("Invaild Day")
        '        End If
        '    End If

        'End With
        i = DAYSGRID.ActiveRow
        If DAYSGRID.ActiveCol = 1 Then
            DAYSGRID.Col = 1
            DAYSGRID.Row = i
            day = UCase(DAYSGRID.Text)
            ' If DAYSGRID.Lock = False Then
            If Trim(DAYSGRID.Text) <> "" Then
                For i = 0 To chk_days.Items.Count - 1
                    daylist = chk_days.Items(i).ToString()
                    If UCase(daylist) = day Then                        ' 
                        CNT = CNT + 1
                    End If
                Next
                If CNT = 0 Then
                    MessageBox.Show("THIS DAY IS NOT BELONGS TO THE SELECTED PERIOD")
                    DAYSGRID.Text = ""
                Else
                    ' MessageBox.Show(day)
                End If
            End If
            ' End If
        End If
    End Sub

    Private Sub TXT_SALEQTY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_SALEQTY.KeyPress
        getNumeric(e)
    End Sub

    Private Sub TXT_SALEQTY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_SALEQTY.TextChanged

    End Sub

    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
    '    Call checkValidation() ''-->Check Validation
    '    If boolchk = False Then Exit Sub
    '    Dim STATUS As Integer
    '    If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
    '        STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
    '        If STATUS = 1 Then
    '            sqlstring = "UPDATE  POSMASTER "
    '            sqlstring = sqlstring & " SET Freeze= 'Y',voiduser='" & gUsername & " ', voiddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
    '            sqlstring = sqlstring & " WHERE POSCode = '" & Trim(CStr(txtPOSCode.Text)) & "'"
    '            gconnection.dataOperation(3, sqlstring, "POSMASTER")
    '            Me.CmdClear_Click(sender, e)
    '            CmdAdd.Text = "Add [F7]"
    '        Else
    '            Exit Sub
    '        End If

    '        'Else
    '        '    STATUS = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
    '        '    If STATUS = 1 Then
    '        '        sqlstring = "UPDATE  POSMASTER "
    '        '        sqlstring = sqlstring & " SET Freeze= 'N',AddUSerId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
    '        '        sqlstring = sqlstring & " WHERE POSCode = '" & Trim(CStr(txtPOSCode.Text)) & "'"
    '        '        gconnection.dataOperation(4, sqlstring, "POSMASTER")
    '        '        Me.CmdClear_Click(sender, e)
    '        '        CmdAdd.Text = "Add [F7]"
    '        '    Else
    '        '        Exit Sub
    '        '    End If
    '    End If
    'End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim STATUS As Integer
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  PromMaster "
                sqlstring = sqlstring & " SET FREEZE= 'Y',voiduser='" & gUsername & " ', voiddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE promocode = '" & Trim(CStr(txtPROMOcode.Text)) & "'"
                gconnection.dataOperation(3, sqlstring, "PromMaster")
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            Else
                Exit Sub
            End If

            'Else
            '    STATUS = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            '    If STATUS = 1 Then
            '        sqlstring = "UPDATE  POSMASTER "
            '        sqlstring = sqlstring & " SET Freeze= 'N',AddUSerId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        sqlstring = sqlstring & " WHERE POSCode = '" & Trim(CStr(txtPOSCode.Text)) & "'"
            '        gconnection.dataOperation(4, sqlstring, "POSMASTER")
            '        Me.CmdClear_Click(sender, e)
            '        CmdAdd.Text = "Add [F7]"
            '    Else
            '        Exit Sub
            '    End If
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        ''********** Check  POS CODE Can't be blank *********************'''

        If mskdate.Value < Today Then
            MessageBox.Show("Promotional date Can't be less than Todate ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Format(Cmb_FromDate.Value, "dd/MM/yyyy") < Format(mskdate.Value, "dd/MM/yyyy") Then
            MessageBox.Show("From date Can't be less than Creation date ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Trim(txtPROMOcode.Text) = "" Then
            MessageBox.Show("Promotional Code Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPROMOcode.Focus()
            Exit Sub
        End If
        ''********** Check  POS DESC Can't be blank *********************'''
        If Trim(txt_prodesc.Text) = "" Then
            MessageBox.Show("Promotional Description Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_prodesc.Focus()
            Exit Sub
        End If

        If Trim(Cbo_TYPE.Text) = "" Then
            MessageBox.Show("Promotional type  Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cbo_TYPE.Focus()
            Exit Sub
        End If
        If Trim(txtBaseItem.Text) = "" Then
            MessageBox.Show("Sale Item Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBaseItem.Focus()
            Exit Sub
        End If
        If Trim(txtBaseName.Text) = "" Then
            MessageBox.Show("Sale Item description Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBaseName.Focus()
            Exit Sub
        End If
        If Trim(cbo_QBaseUom.Text) = "" Then
            MessageBox.Show("Sale Item description Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_QBaseUom.Focus()
            Exit Sub
        End If
        If Trim(TXT_SALEQTY.Text) = "" Then
            MessageBox.Show("Sale qty Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_SALEQTY.Focus()
            Exit Sub
        End If

        With PROMOGRID
            '
            Dim itemcode As String
            Dim qty, dicnt, rate As Double
            PROMOGRID.Row = PROMOGRID.ActiveRow
            PROMOGRID.Row = 1
            PROMOGRID.Col = 1
            'If (PROMOGRID.Text) <> "" Then
            'itemcode = Format(CDate(PROMOGRID.Text), "yyyy/MM/dd")
            itemcode = Trim(PROMOGRID.Text)
            If itemcode = "" Then
                MessageBox.Show("Promotinal itemcode can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                'Return False
                Exit Sub
            End If
            ' End If
            For I = 1 To PROMOGRID.DataRowCnt Step 1
                If (PROMOGRID.Text) <> "" Then
                    ' For I = 1 To PROMOGRID.DataRowCnt Step 1
                    If Cbo_TYPE.Text = "QTY" Then
                        PROMOGRID.Row = I
                        PROMOGRID.Col = 4
                        qty = Val(PROMOGRID.Text)
                        If qty = 0.0 Then
                            MessageBox.Show("Promotinal Qty can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    ElseIf Cbo_TYPE.Text = "DISCOUNT " Then
                        PROMOGRID.Row = I
                        PROMOGRID.Col = 5
                        dicnt = Val(PROMOGRID.Text)
                        If dicnt = 0.0 Then
                            MessageBox.Show("Promotinal Discount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    ElseIf Cbo_TYPE.Text = "DISCOUNT ON RATE" Then
                        PROMOGRID.Row = I
                        PROMOGRID.Col = 6
                        rate = Val(PROMOGRID.Text)
                        If rate = 0.0 Then
                            MessageBox.Show("Promotinal Discount Price  can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If
                    ' 
                End If
            Next
        End With
        With DAYSGRID
            'Dim TM, FM As Double
            'For I = 1 To DAYSGRID.DataRowCnt Step 1
            '    DAYSGRID.Row = I
            '    DAYSGRID.Col = 1

            '    If (DAYSGRID.Text) <> "" Then
            '        ' For I = 1 To PROMOGRID.DataRowCnt Step 1
            '        Dim var, var1 As String
            '        Dim h, m As Integer
            '        DAYSGRID.Row = I
            '        DAYSGRID.Col = 2
            '        FM = Val(DAYSGRID.Text)
            '        'If FM = 0.0 Then
            '        '    MessageBox.Show("From time  can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '        '    Exit Sub
            '        'End If
            '        DAYSGRID.Row = I
            '        DAYSGRID.Col = 3
            '        ' DAYSGRID.GetText(1, I, var1)
            '        TM = Val(DAYSGRID.Text)
            '            If TM = 0.0 Then
            '                MessageBox.Show("To time  can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                Exit Sub
            '            End If
            '            If FM > TM Then
            '                MessageBox.Show("From time  can't be greater than To Time", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                Exit Sub
            '            End If

            '        End If
            '    Next
            For i = 0 To DAYSGRID.DataRowCnt - 1
                Dim var, var1 As String
                Dim h, m As Integer
                ' var = ""
                ' var = ""
                ' DAYSGRID.GetText(2, i + 1, var)
                DAYSGRID.Col = 2
                DAYSGRID.Row = i + 1
                var = Trim(.Text)
                ' DAYSGRID.GetText(3, i + 1, var1)
                DAYSGRID.Col = 3
                DAYSGRID.Row = i + 1
                var1 = Trim(.Text)
                If var = "" Then
                    MessageBox.Show("From time  can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DAYSGRID.DeleteRows(i + 1, 1)
                    Exit Sub
                End If
                If var1 = "" Then
                    MessageBox.Show("To time  can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DAYSGRID.DeleteRows(i + 1, 1)
                    Exit Sub
                End If
                If var > var1 Then
                    MessageBox.Show("From time  can't be greater than To Time", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DAYSGRID.DeleteRows(i + 1, 1)
                    Exit Sub
                End If

            Next
            Dim day, daylist As String
            Dim cnt As Integer
            For i = 0 To chk_days.Items.Count - 1
                daylist = chk_days.Items(i).ToString()
                day = UCase(daylist)
                cnt = 0
                For j = 0 To DAYSGRID.DataRowCnt - 1
                    DAYSGRID.Row = j + 1
                    DAYSGRID.Col = 1
                    If (DAYSGRID.Text) <> "" Then
                        If Trim(day) = Trim(DAYSGRID.Text) Then
                            cnt = cnt + 1
                        End If
                    End If
                Next
                If cnt = 0 Then
                    ' MessageBox.Show(day)
                    MessageBox.Show(" You Are Not Mentioned :" & day & "", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Next

        End With

        If DateDiff(DateInterval.Day, Cmb_FromDate.Value, Cmb_ToDate.Value) < 0 Then
            MessageBox.Show("From Date cannot be greater than To Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            'chkdatevalidate = False
            ' Cmb_ToDate.Value = Cmb_FromDate.Value
            Exit Sub
        End If
        'If DateDiff(DateInterval.Day, Cmb_FromDate.Value, Cmb_ToDate.Value) > 0 Then
        '    MessageBox.Show("TO Date cannot be greater than To Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    chkdatevalidate = False
        '    Exit Sub
        'End If
        If CDate(Cmb_FromDate.Value) >= CDate(Cmb_FromDate.Value) And CDate(Cmb_ToDate.Value) <= CDate(Cmb_ToDate.Value) Then
            chkdatevalidate = True
        Else
            MsgBox("Date should be within Financial Year", MsgBoxStyle.Critical)
            '  chkdatevalidate = False
            Exit Sub
        End If
        If CHK_LOCATION.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        boolchk = True
    End Sub


    Private Sub cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_view.Click
        Dim FRM As New ReportDesigner
        If txtPROMOcode.Text.Length > 0 Then
            tables = " FROM PromMaster WHERE promocode ='" & txtPROMOcode.Text & "' "
        Else
            tables = "FROM PromMaster "
        End If
        Gheader = "PROMOTIONAL DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"PROMOCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"PROMODESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"PROMODATE", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"BasedItemCode", "13"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"basename", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"BasedUom", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"PItemCode", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"PUom", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"salerate", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FreeQty", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Discount", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FixedRate", "9"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"PosCode", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"WDay", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FromDate", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ToDate", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"FromTime", "17"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ' ROW = New String() {"ToTime", "17"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FREEZE", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"AddUser", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"AddDateTime", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATETIME", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"Waitinglist", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"Freeze", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub


    Private Sub cmd_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_excel.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM PromMaster"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM PromMaster", "SERIALNO", 0)
    End Sub

    Private Sub cmb_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_exit.Click
        Me.Close()
    End Sub

    Private Sub PROMOGRID_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles PROMOGRID.Advance

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        'Dim r As New Crptpromotionalmaster
        'Dim POSdesc(), MemberCode() As String
        'Dim SQLSTRING2 As String
        'sqlstring = "select * from PromMaster order by promocode"

        'Call Viewer.GetDetails(sqlstring, "PromMaster", r)
        'Viewer.TableName = "PromMaster"
        'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ5 = r.ReportDefinition.ReportObjects("Text2")
        'TXTOBJ5.Text = gCompanyname

        'Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ1 = r.ReportDefinition.ReportObjects("Text3")
        'TXTOBJ1.Text = "UserName : " & gUsername

        'Viewer.Show()
    End Sub

    Private Sub cmd_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_auth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM PromMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM PromMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER1,'')=''"
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

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PromMaster set  ", "promocode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM PromMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PromMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER2,'')=''"
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

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PromMaster set  ", "promocode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM PromMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM PromMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHTHORISEUSER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PromMaster set  ", "promocode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If

    End Sub

   
    Private Sub Cmb_FromDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_FromDate.ValueChanged
        If DateDiff(DateInterval.Day, Cmb_FromDate.Value, Cmb_ToDate.Value) < 0 Then
            MessageBox.Show("From Date cannot be greater than To Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            'chkdatevalidate = False
            Cmb_ToDate.Value = Cmb_FromDate.Value
            ' Exit Sub
        End If
        'If DateDiff(DateInterval.Day, Cmb_FromDate.Value, Cmb_ToDate.Value) > 0 Then
        '    MessageBox.Show("TO Date cannot be greater than To Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    chkdatevalidate = False
        '    Exit Sub
        'End If
        If CDate(Cmb_FromDate.Value) >= CDate(Cmb_FromDate.Value) And CDate(Cmb_ToDate.Value) <= CDate(Cmb_ToDate.Value) Then
            chkdatevalidate = True
        Else
            MsgBox("Date should be within Financial Year", MsgBoxStyle.Critical)
            chkdatevalidate = False
            Exit Sub
        End If
        ' If chkdatevalidate = False Then Exit Sub
        Dim dys, days As String
        Dim daylist()
        years = DateDiff("d", Cmb_FromDate.Value, Cmb_ToDate.Value)

        'If Format(Cmb_FromDate.Value, "dd/MM/yyyy") = Format(Cmb_ToDate.Value, "dd/MM/yyyy") Then
        'Else
        ' years = years + 1
        ' End If

        'For i = 0 To years
        '    daylist = Cmb_FromDate.Value.DayOfWeek.ToString()
        '    dys = " '" & daylist(0) & "'"
        'Next

        chk_days.Items.Clear()
        Dim startDay As Date
        Dim endDay As Date
        startDay = Cmb_FromDate.Value
        endDay = Format(Cmb_ToDate.Value, "dd/MM/yyyy")
        Dim dayCtr As Date
        dayCtr = Format(startDay, "dd/MM/yyyy")

        If (dayCtr <= endDay) Then
            For j = 0 To years
                If j < 7 Then
                    'MessageBox.Show(dayCtr.Date.Day & "-" & dayCtr.Date.DayOfWeek.ToString())
                    dys = dayCtr.Date.Day & "-" & dayCtr.Date.DayOfWeek.ToString()
                    daylist = Split(dys, "-")
                    days = " " & daylist(1) & ""
                    ' For i = 0 To daylist.Count
                    chk_days.Items.Add(Trim(days))
                    'Next
                    dayCtr = dayCtr.AddDays(1)

                End If
            Next
            'End While
        End If
        With DAYSGRID
            'DAYSGRID.Col = .ActiveCol
            'DAYSGRID.Row = 1
            Dim VAR As String = Trim(DAYSGRID.Text)
            If VAR <> "" Then
                DAYSGRID.ClearRange(1, 1, -1, -1, True)
            End If
        End With
        If DAYSGRID.Enabled = False Then
            DAYSGRID.Enabled = True
        End If
    End Sub


    Private Sub PROMOGRID_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles PROMOGRID.LeaveCell
        Dim i, cct, itc As Integer
        i = PROMOGRID.ActiveRow
        'If PROMOGRID.ActiveCol = 1 Then
        PROMOGRID.Col = 1
        PROMOGRID.Row = i
        'If PROMOGRID.Lock = False Then
        If Trim(PROMOGRID.Text) <> "" Then
            ' PROMOGRID.GetText(1, i, itc)
            PROMOGRID.Col = 1
            PROMOGRID.Row = i
            itc = Trim(PROMOGRID.Text)
            For k = 1 To PROMOGRID.DataRowCnt
                PROMOGRID.Col = 1
                PROMOGRID.Row = k
                If Trim(PROMOGRID.Text) = itc Then
                    cct = cct + 1
                    'MsgBox("duplicate item entry")
                    'Exit For
                End If

            Next
            ' End If
        End If
        If cct > 1 Then
            MsgBox("duplicate item entry")
            ' PROMOGRID.Col = 1
            '  PROMOGRID.Row = i
            ' PROMOGRID.Row = PROMOGRID.ActiveRow
            'PROMOGRID.ClearRange(1, PROMOGRID.ActiveRow, 6, PROMOGRID.ActiveRow, True)
            PROMOGRID.DeleteRows(PROMOGRID.ActiveRow, 1)
            '  PROMOGRID.SetActiveCell(i, 1)

        End If
        ' End If
    End Sub
End Class