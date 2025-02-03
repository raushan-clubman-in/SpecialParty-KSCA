Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class Frm_ArrangementMaster
    Dim gconn As New GlobalClass
    Dim i, j As Integer
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim sqlstring As String
    Dim vSeqNo As Double
    Dim gconnection As New GlobalClass
    Dim boolchk As Boolean
    Private Sub Cmd_ArrItemHelp_Click(sender As Object, e As EventArgs) Handles Cmd_ArrItemHelp.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT isnull(ITEMCODE,'') as ITEMCODE,isnull(ITEMDESC,'') as ITEMDESC FROM PARTY_itemmaster"
            M_WhereCondition = " "
            vform.Field = "ITEMCODE ,ITEMDESC"
            vform.vCaption = "Arrangement Item Master Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_ArrItemCode.Text = Trim(vform.keyfield & "")
                Txt_ArrItemCode.Select()
                Call Txt_ArrItemCode_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Txt_ArrItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ArrItemCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Txt_ArrItemCode.Enabled = True Then
                Search = Trim(Txt_ArrItemCode.Text)
                Call Cmd_ArrItemHelp_Click(Txt_ArrItemCode, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Txt_ArrItemCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ArrItemCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_ArrItemCode.Text) <> "" Then
                Call Txt_ArrItemCode_Validated(Txt_ArrItemCode, e)
            Else
                Call Cmd_ArrItemHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Txt_ArrItemCode_Validated(sender As Object, e As EventArgs) Handles Txt_ArrItemCode.Validated
        Try
            If Trim(Txt_ArrItemCode.Text) <> "" Then
                Dim ds As New DataSet
                sqlstring = "select isnull(category,'') as category,isnull(glaccode,'') as glaccode,isnull(itemcode,'') as itemcode,isnull(itemdesc,'') as itemdesc,isnull(TAXcode,'') as TAXcode,isnull(groupcode,'') as groupcode,isnull(GROUPDESC,'') as GROUPDESC,isnull(SUBgroupcode,'') as SUBgroupcode,isnull(SUBGROUPDESC,'') as SUBGROUPDESC,isnull(uomCODE,'') as uomCODE,isnull(uomDESC,'') as uomDESC,isnull(rate,0) as rate,isnull(sbfcharge,'') as sbfcharge,isnull(freeze,'') as freeze,ISNULL(OPENFACILITY,'')AS OPENFACILITY,"
                sqlstring = sqlstring & " isnull(adddatetime,'') as adddatetime,isnull(adduserid,'') as adduserid,isnull(VendorCode,'') as VendorCode,isnull(VendorName,'') as VendorName,isnull(ContactPersone ,'') as ContactPersone ,isnull(Add1  ,'') as Add1,isnull(Add2 ,'') as Add2 ,isnull(Add3 ,'') as Add3 ,isnull(City ,'') as City,isnull(Pincode,0) as Pincode    from PARTY_ITEMMASTER "
                sqlstring = sqlstring & " WHERE isnull(itemcode,'')='" & Txt_ArrItemCode.Text & "'"
                gconnection.getDataSet(sqlstring, "MenuMaster")
                If gdataset.Tables("MenuMaster").Rows.Count > 0 Then
                    Txt_ArrItemdesc.Clear()
                    Txt_ArrItemdesc.Text = gdataset.Tables("MenuMaster").Rows(0).Item("ItemDesc")
                    Text_CCODE.Text = gdataset.Tables("MenuMaster").Rows(0).Item("category")
                    Txt_CCode.Text = gdataset.Tables("MenuMaster").Rows(0).Item("TAXCODE")
                    Cmb_OpenFacility.Text = gdataset.Tables("MenuMaster").Rows(0).Item("OPENFACILITY")

                    Txt_Uom.Text = gdataset.Tables("MenuMaster").Rows(0).Item("UOMCODE")
                    If gdataset.Tables("MenuMaster").Rows(0).Item("VendorCode") <> "" Then
                        Me.Rdb_Vendor_Click(sender, e)
                        Txt_Vendorcode.Text = gdataset.Tables("MenuMaster").Rows(0).Item("VendorCode")
                        Txt_VendorName.Text = gdataset.Tables("MenuMaster").Rows(0).Item("VendorName")
                        Txt_ContPersone.Text = gdataset.Tables("MenuMaster").Rows(0).Item("ContactPersone")
                        Txt_Add1.Text = gdataset.Tables("MenuMaster").Rows(0).Item("Add1")
                        Txt_Add2.Text = gdataset.Tables("MenuMaster").Rows(0).Item("Add2")
                        Txt_Add3.Text = gdataset.Tables("MenuMaster").Rows(0).Item("Add3")
                        Txt_City.Text = gdataset.Tables("MenuMaster").Rows(0).Item("city")
                        Txt_Pincode.Text = gdataset.Tables("MenuMaster").Rows(0).Item("Pincode")
                    Else
                        Me.Rdb_Self_Click(sender, e)
                        'Txt_Vendorcode.Text = "''"
                        'Txt_VendorName.Text = "''"
                    End If
                    Txt_Uom.Text = gdataset.Tables("MenuMaster").Rows(0).Item("UomCODE")
                    Txt_Rate.Text = gdataset.Tables("MenuMaster").Rows(0).Item("Rate")

                    If gdataset.Tables("MenuMaster").Rows(0).Item("Freeze") = "Y" Then
                        Me.lbl_freeze.Visible = True
                        Me.lbl_freeze.Text = ""
                        Me.lbl_freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("MenuMaster").Rows(0).Item("ADDDATETIME")), "dd-MMM-yyyy")
                        Me.CmdFreeze.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_freeze.Visible = False
                        Me.lbl_freeze.Text = "Record Freezed  On "
                        Me.CmdFreeze.Text = "Freeze[F8]"
                    End If
                    Me.CmdAdd.Text = "Update[F7]"
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    Me.Txt_ArrItemCode.ReadOnly = True
                    Me.Cmd_ArrItemHelp.Enabled = False
                    Me.Txt_ArrItemdesc.Focus()
                Else
                    Txt_ArrItemdesc.Focus()
                End If
            Else
                Txt_ArrItemCode.Text = ""
                Txt_ArrItemdesc.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Frm_ArrangementMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            If CmdAdd.Enabled = True Then
                Call CmdAdd_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            If CmdFreeze.Enabled = True Then
                Call CmdFreeze_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            Call CmdView_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            Call CmdExit_Click(sender, e)
        End If
    End Sub

    Private Sub Frm_ArrangementMaster_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()

        Me.Grp_Vendor.Visible = False
        Me.Txt_Vendorcode.Visible = False
        Me.Txt_Pincode.Text = 0
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Rdb_Self.Checked = True
        Me.Txt_ArrItemCode.Focus()
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
                        If Controls(i_i).Name = "CmdAdd" Or Controls(i_i).Name = "CmdClear" Or Controls(i_i).Name = "CmdFreeze" Or Controls(i_i).Name = "CmdView" Or Controls(i_i).Name = "CmdBrowse" Or Controls(i_i).Name = "CmdExit" Or Controls(i_i).Name = "cmdreport" Or Controls(i_i).Name = "Cmd_PendingBill" Or Controls(i_i).Name = "Cmd_Bill" Then
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
    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub
    Private Sub Rdb_Self_Click(sender As Object, e As EventArgs) Handles Rdb_Self.Click
        Me.Grp_Vendor.Visible = False
        Me.Rdb_Self.Checked = True
    End Sub

    Private Sub Rdb_Vendor_Click(sender As Object, e As EventArgs) Handles Rdb_Vendor.Click
        Me.Grp_Vendor.Visible = True
        Me.Rdb_Vendor.Checked = True
    End Sub
    Private Sub Cmd_Vendor_Click(sender As Object, e As EventArgs) Handles Cmd_Vendor.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(Slcode,'') as Slcode,ISNULL(slname ,'')as slname,ISNULL(contactperson,'')as contactperson from VW_VENDORE "
            M_WhereCondition = ""
            vform.Field = "Slcode,Slname,Contactperson"
            vform.vCaption = "Vendor Name Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_Vendorcode.Text = Trim(vform.keyfield & "")
                Call Txt_Vendorcode_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub
    Private Sub Txt_Vendorcode_Validated(sender As Object, e As EventArgs) Handles Txt_Vendorcode.Validated
        Try
            If Trim(Txt_Vendorcode.Text) <> "" Then
                Dim ds As New DataSet
                sqlstring = "SELECT slcode,SLname,contactperson,Address1,Address2,Address3,city,pin  FROM  VW_VENDORE "
                sqlstring = sqlstring & " WHERE isnull(Slcode,'') = '" & Txt_Vendorcode.Text & "'"
                gconnection.getDataSet(sqlstring, "VendoreMaster")
                If gdataset.Tables("VendoreMaster").Rows.Count > 0 Then
                    Txt_VendorName.Clear()
                    Txt_Vendorcode.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("Slcode")
                    Txt_VendorName.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("slname")
                    Txt_ContPersone.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("contactperson")
                    Txt_Add1.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("Address1")
                    Txt_Add2.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("Address2")
                    Txt_Add3.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("Address3")
                    Txt_City.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("City")
                    Txt_Pincode.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("Pin")
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    Me.Txt_Vendorcode.ReadOnly = True
                    Me.Txt_VendorName.ReadOnly = True
                    Me.Txt_VendorName.Focus()
                Else
                    CmdAdd.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Private Sub Txt_VendorName_Validated(sender As Object, e As EventArgs) Handles Txt_VendorName.Validated
    '    Try
    '        If Trim(Txt_VendorName.Text) <> "" Then
    '            Dim ds As New DataSet
    '            sqlstring = "SELECT slcode,SLname,contactperson,Address1,Address2,Address3,city,pin  FROM  VW_VENDORE "
    '            sqlstring = sqlstring & " WHERE isnull(Slcode,'') = '" & Txt_Vendorcode.Text & "'"
    '            gconnection.getDataSet(sqlstring, "VendoreMaster")
    '            If gdataset.Tables("VendoreMaster").Rows.Count > 0 Then
    '                Txt_VendorName.Clear()
    '                Txt_Vendorcode.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("Slcode")
    '                Txt_VendorName.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("slname")
    '                Txt_ContPersone.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("contactperson")
    '                Txt_Add1.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("Address1")
    '                Txt_Add2.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("Address2")
    '                Txt_Add3.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("Address3")
    '                Txt_City.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("City")
    '                Txt_Pincode.Text = gdataset.Tables("VendoreMaster").Rows(0).Item("Pin")
    '                If gUserCategory <> "S" Then
    '                    'Call GetRights()
    '                End If
    '                Me.Txt_VendorName.ReadOnly = True
    '                Me.Cmd_Vendor.Enabled = False
    '                'TXTITEMDESC.Focus()
    '            Else
    '                CmdAdd.Focus()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Public Sub checkValidation()
        boolchk = False
        Dim ssql As String
        If Trim(Txt_ArrItemCode.Text) = "" Then
            MessageBox.Show("ITEMCODE can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_ArrItemCode.Focus()
            Exit Sub
        End If
        If Trim(Txt_ArrItemdesc.Text) = "" Then
            MessageBox.Show("ITEM Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_ArrItemdesc.Focus()
            Exit Sub
        End If
        If Trim(Txt_Uom.Text) = "" Then
            MessageBox.Show("UOMCODE can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_Uom.Focus()
            Exit Sub
        End If

        If Trim(Cmb_OpenFacility.Text) = "" Then
            MessageBox.Show("Open Facility  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cmb_OpenFacility.Focus()
            Exit Sub
        End If
        If Val(Txt_Rate.Text) <= 0 Then
            MessageBox.Show("Rate can't be less than 0 or less ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_Rate.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim strSQL, SQL As String
        Dim INSERT(0) As String
        Call checkValidation()
        If boolchk = False Then Exit Sub
        strSQL = "INSERT INTO PARTY_ITEMMASTER_LOG(ITEMCODE,ITEMDESC,TAXCODE,GROUPCODE,GROUPDESC,SUBGROUPCODE,SUBGROUPDESC,UOMCODE,UOMDESC,RATE,OPENFACILITY,CATEGORY,FREEZE,adduserid,ADDDATETIME)"
        strSQL = strSQL & " VALUES ('" & Trim(Txt_ArrItemCode.Text) & "','" & Trim(Txt_ArrItemdesc.Text) & "', '" & Trim(Txt_CCode.Text) & "','','',"
        strSQL = strSQL & "'','',' " & Txt_Uom.Text & " ',' " & Txt_Uom.Text & "'," & Txt_Rate.Text & ","
        strSQL = strSQL & "'" & Cmb_OpenFacility.Text & "','" & Text_CCODE.Text & "'"
        strSQL = strSQL & ",'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
        gconnection.dataOperation(6, strSQL, "PARTY_ITEMMASTER")

        If CmdAdd.Text = "Add [F7]" Then
            vSeqNo = GetSeqno(Txt_ArrItemCode.Text)
            strSQL = "INSERT INTO PARTY_ITEMMASTER(ITEMCODE,ITEMDESC,CATEGORY,TAXCODE,UOMCODE,UOMDESC,RATE,OPENFACILITY,VendorCode,VendorName,ContactPersone,Add1,Add2,Add3,City,Pincode,FREEZE,adduserid,ADDDATETIME)"
            strSQL = strSQL & " VALUES ('" & Trim(Txt_ArrItemCode.Text) & "','" & Trim(Txt_ArrItemdesc.Text) & "','" & Text_CCODE.Text & "', '" & Trim(Txt_CCode.Text) & "',"
            strSQL = strSQL & "'" & Txt_Uom.Text & " ',' " & Txt_Uom.Text & "'," & Txt_Rate.Text & ","
            strSQL = strSQL & "'" & Cmb_OpenFacility.Text & "','" & Trim(Txt_Vendorcode.Text) & "','" & Trim(Txt_VendorName.Text) & "','" & Trim(Txt_ContPersone.Text) & "','" & Trim(Txt_Add1.Text) & "','" & Trim(Txt_Add2.Text) & "','" & Trim(Txt_Add3.Text) & "','" & Trim(Txt_City.Text) & "'," & Val(Txt_Pincode.Text) & ","
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(1, strSQL, "PARTY_ITEMMASTER")
            Me.CmdClear_Click(sender, e)

        ElseIf CmdAdd.Text = "Update[F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            If Mid(Me.CmdAdd.Text, 1, 1) = "U" Then
                If Me.lbl_freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            strSQL = "UPDATE  PARTY_ITEMMASTER "
            strSQL = strSQL & " SET ITEMDESC='" & Trim(Txt_ArrItemdesc.Text) & "',"
            strSQL = strSQL & " CATEGORY='" & Trim(Text_CCODE.Text) & "',"
            strSQL = strSQL & " TAXCODE ='" & Trim(Txt_CCode.Text) & "',"
            strSQL = strSQL & " City ='" & Trim(Txt_City.Text) & "',"
            strSQL = strSQL & " OPENFACILITY ='" & Trim(Cmb_OpenFacility.Text) & "',"
            strSQL = strSQL & " VendorCode ='" & Trim(Txt_Vendorcode.Text) & "',"
            strSQL = strSQL & " ContactPersone ='" & Trim(Txt_ContPersone.Text) & "',"
            strSQL = strSQL & " VendorName ='" & Trim(Txt_VendorName.Text) & "',"
            strSQL = strSQL & " Add1 ='" & Trim(Txt_Add1.Text) & "',"
            strSQL = strSQL & " Add2 ='" & Trim(Txt_Add2.Text) & "',"
            strSQL = strSQL & " Add3 ='" & Trim(Txt_Add3.Text) & "',"
            strSQL = strSQL & " Pincode =" & Val(Txt_Pincode.Text) & ","
            strSQL = strSQL & " UOMCODE ='" & Trim(Txt_Uom.Text) & "',"
            strSQL = strSQL & " UOMDESC ='" & Trim(Txt_Uom.Text) & "',"
            strSQL = strSQL & " RATE=" & Trim(Txt_Rate.Text) & ","
            strSQL = strSQL & " AddUserId='" & Trim(gUsername) & "',AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            strSQL = strSQL & " Where Itemcode = '" & Trim(Txt_ArrItemCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "PARTY_ITEMMASTER")
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            '====================================
            SQL = "delete from party_itemmaster_tax where ITEMCODE='" & Me.Txt_ArrItemCode.Text & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = SQL
            '======================================
            'SQL = "INSERT INTO party_itemmaster_tax(CATEGORY,glaccode,ITEMCODE,ITEMDESC,ITEMTYPECODE,RATE,GROUPCODE,CGROUPCODE,UOM,SBFCHARGE,FREEZE,ADDUSERID,ADDDATETIME,TYPE)"
            'SQL = SQL & " VALUES ( '','','" & Trim(Txt_ArrItemCode.Text) & "','" & Trim(Txt_ArrItemdesc.Text) & "'"
            '' SQL = SQL & ",'" & ITEMTYPECODE(0)
            'SQL = SQL & ",''"
            'SQL = SQL & "','" & Txt_Rate.Text & "','',''"
            'SQL = SQL & ",'" & Txt_Uom.Text & "'"
            'SQL = SQL & ",'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(Cmb_OpenFacility.Text) & "')"
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = SQL
            'gconnection.MORETRANS(INSERT)
            '====================================
            Me.CmdClear_Click(sender, e)
            'CmdAdd.Text = "Add [F7]"
        End If
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        Txt_Rate.Text = ""
        Txt_ArrItemCode.Text = ""
        Txt_ArrItemdesc.Text = ""
        Txt_Rate.Text = ""
        Txt_Uom.Text = ""
        Txt_CCode.Text = ""
        Text_CCODE.Text = ""
        Cmb_OpenFacility.Text = ""
        Txt_Vendorcode.Text = ""
        Txt_VendorName.Text = ""
        Txt_ContPersone.Text = ""
        Txt_Add1.Text = ""
        Txt_Add2.Text = ""
        Txt_Add3.Text = ""
        Txt_City.Text = ""
        Txt_Pincode.Text = ""
        Rdb_Self_Click(sender, e)
        Me.lbl_freeze.Visible = False
        Me.Txt_Uom.ReadOnly = False
        Me.lbl_freeze.Text = "Record Freezed  On "
        Me.CmdFreeze.Text = "Freeze[F8]"
        CmdAdd.Text = "Add [F7]"
        Me.Txt_Vendorcode.ReadOnly = False
        Me.Txt_VendorName.ReadOnly = False
        Me.Cmd_Vendor.Enabled = True
        Txt_ArrItemCode.Enabled = True
        Txt_ArrItemCode.ReadOnly = False
        Txt_ArrItemdesc.ReadOnly = False
        Cmd_ArrItemHelp.Enabled = True
        Txt_Rate.Text = Format(Val(Txt_Rate.Text), "0.00")
        Txt_ArrItemCode.Focus()
    End Sub

    Private Sub Cmd_Uom_Click(sender As Object, e As EventArgs) Handles Cmd_Uom.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "select ISNULL(UOMCode  ,'') as Code ,ISNULL(UOMDesc  ,'')as Name  from UoMMaster  "
            M_WhereCondition = "where isnull(freeze,'')<>'Y'"
            vform.Field = "UOMCode,UOMDesc"
            vform.vCaption = "Uom Master Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_Uom.Text = Trim(vform.keyfield & "")
                ' Txt_ContPersone.Text = Trim(vform.keyfield & "")
                'Txt_Add1.Text = Trim(vform.keyfield2 & "")
                'Txt_Add2.Text = Trim(vform.keyfield3 & "")
                'Txt_Add3.Text = Trim(vform.keyfield4 & "")
                'Txt_City.Text = Trim(vform.keyfield5 & "")
                'Txt_Pincode.Text = Trim(vform.keyfield6 & "")
                'Txt_Uom.Select()
                Call Txt_Uom_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Txt_Uom_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Uom.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Txt_Uom.Enabled = True Then
                Search = Trim(Txt_Uom.Text)
                Call Cmd_Uom_Click(Txt_Uom, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Txt_Uom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Uom.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Uom.Text) <> "" Then
                Call Txt_Uom_Validated(Txt_Uom, e)
            Else
                Call Cmd_Uom_Click(sender, e)
            End If
            'Txt_Rate.Focus()
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='PARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdAdd.Enabled = False
        Me.CmdFreeze.Enabled = False
        Me.CmdView.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    Me.CmdFreeze.Enabled = True
                    Me.CmdView.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.CmdAdd.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.CmdAdd.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.CmdAdd.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.CmdFreeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub Txt_Uom_Validated(sender As Object, e As EventArgs) Handles Txt_Uom.Validated
        Try
            If Trim(Txt_Uom.Text) <> "" Then
                Dim ds As New DataSet
                sqlstring = "select ISNULL(UOMCode  ,'') as UOMCode ,ISNULL(UOMDesc  ,'') as UOMDesc  from UoMMaster "
                sqlstring = sqlstring & " WHERE isnull(UOMCode,'') = '" & Txt_Uom.Text & "'"
                gconnection.getDataSet(sqlstring, "UomMaster")
                If gdataset.Tables("UomMaster").Rows.Count > 0 Then
                    Txt_Uom.Clear()
                    Txt_Uom.Text = gdataset.Tables("UomMaster").Rows(0).Item("UOMCode")
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    Me.Txt_Uom.ReadOnly = True
                    'Me.Txt_Uom.ReadOnly = True
                    'Me.Cmd_Uom.Enabled = False
                    Txt_Rate.Focus()
                Else
                    Txt_Uom.Text = ""
                    'CmdAdd.Focus()
                    Txt_Uom.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txt_ArrItemdesc_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ArrItemdesc.KeyDown
        'If e.KeyCode = Keys.F4 Then
        '    If Txt_ArrItemdesc.Enabled = True Then
        '        Search = Trim(Txt_ArrItemdesc.Text)
        '        Call Cmd_Uom_Click(Txt_ArrItemdesc, e)
        '        Exit Sub
        '    End If
        'End If
    End Sub

    Private Sub Txt_ArrItemdesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ArrItemdesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_Uom.Focus()
        End If
    End Sub

    Private Sub Txt_Rate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Rate.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Cmb_OpenFacility.Focus()
        End If
    End Sub

    Private Sub Cmb_OpenFacility_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cmb_OpenFacility.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_CCode.Focus()
        End If
    End Sub

    Private Sub Cmd_ChargeCode_Click(sender As Object, e As EventArgs) Handles Cmd_ChargeCode.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(CHARGECODE,'') AS CHARGECODE,ISNULL(CHARGEDESC,'') AS CHARGEDESC  FROM CHARGEMASTER  WHERE "
            M_WhereCondition = " RATE=0   AND ISNULL(Freeze,'') <> 'Y'AND ISNULL(TAXTYPECODE,'')<>'' "
            vform.Field = "CHARGECODE,CHARGEDESC"
            'vform.Frmcalled = "  CHARGECODE  | CHARGE DESCRIPTION          |                                  "
            vform.vCaption = "Charge Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_CCode.Text = Trim(vform.keyfield & "")
                ' Txt_CCode.Select()
                Txt_CCode_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Txt_CCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_CCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Txt_CCode.Enabled = True Then
                Search = Trim(Txt_CCode.Text)
                Call Cmd_ChargeCode_Click(Txt_CCode, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Txt_CCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_CCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_CCode.Text) <> "" Then
                Call Txt_CCode_Validated(Txt_CCode, e)
            Else
                Call Cmd_ChargeCode_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Txt_CCode_Validated(sender As Object, e As EventArgs) Handles Txt_CCode.Validated
        Dim SSQL As String
        If Txt_CCode.Text <> "" Then
            SSQL = "SELECT ISNULL(CHARGECODE,'') AS CHARGECODE,ISNULL(CHARGEDESC,'') AS CHARGEDESC FROM CHARGEMASTER  WHERE RATE=0  AND CHARGECODE='" & Trim(Txt_CCode.Text) & "' AND ISNULL(Freeze,'') <> 'Y'AND ISNULL(TAXTYPECODE,'')<>''"
            'ssql = "and "ESC
            gconn.getDataSet(SSQL, "ItemTypeMaster")
            If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                'txtTypedes.Text = ""
                Txt_CCode.Text = Trim(gdataset.Tables("ItemTypeMaster").Rows(0).Item("CHARGECODE"))
                'Txt_CCode.ReadOnly = True
            Else
                Rdb_Self.Focus()
            End If
        Else
            Txt_CCode.Clear()
        End If
    End Sub

    Private Sub CmdFreeze_Click(sender As Object, e As EventArgs) Handles CmdFreeze.Click
        Call checkValidation()
        If boolchk = False Then Exit Sub
        Dim ssql As String
        ssql = "select * from  PARTY_ITEMMASTER where  itemcode = '" & Trim(Txt_ArrItemCode.Text) & "'"
        gconnection.getDataSet(ssql, "log")
        If gdataset.Tables("log").Rows.Count > 0 Then
            If Mid(Me.CmdFreeze.Text, 1, 1) = "F" Then
                sqlstring = "UPDATE  PARTY_ITEMMASTER "
                sqlstring = sqlstring & " SET Freeze= 'Y',VOIDUSER='" & gUsername & " ', VOIDDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE itemcode = '" & Trim(Txt_ArrItemCode.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "Arrmaster")
                Me.CmdClear_Click(sender, e)
                CmdAdd.Text = "Add [F7]"
            Else
                sqlstring = "UPDATE  PARTY_ITEMMASTER "
                sqlstring = sqlstring & " SET Freeze= 'N',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE itemcode = '" & Trim(Txt_ArrItemCode.Text) & "'"
                gconnection.dataOperation(4, sqlstring, "Arrmaster")
                Me.CmdClear_Click(sender, e)
                CmdAdd.Text = "Add [F7]"
            End If
        Else
            MessageBox.Show("ITEM WAS NOT EXISTS ", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        End If
    End Sub
    Private Sub CmdView_Click(sender As Object, e As EventArgs) Handles CmdView.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_ADDTIONALITEMMASTER
        STR = "SELECT * FROM PAR_ITEMMASTER"
        Viewer.ssql = STR
        Viewer.Report = r
        Viewer.TableName = "PAR_ITEMMASTER"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text6")
        textobj1.Text = MyCompanyName

        Dim TXTOBJ2 As TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text11")
        TXTOBJ2.Text = "UserName : " & gUsername


        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = r.ReportDefinition.ReportObjects("Text15")
        TXTOBJ6.Text = Address1 & Address2

        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = r.ReportDefinition.ReportObjects("Text16")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
        'TXTOBJ9.Text = "PhoneNo : " & gphoneno
        Viewer.Show()
    End Sub

    Private Sub CmdBrowse_Click(sender As Object, e As EventArgs) Handles CmdBrowse.Click
        Dim OBJ1 As New VIEWHDR
        Dim ChildSql As String
        sqlstring = "SELECT ITEMCODE,ITEMDESC,UOMCODE,RATE,OPENFACILITY,VendorCode,Freeze FROM PARTY_ITEMMASTER "
        ChildSql = ""
        gconnection.getDataSet(sqlstring, "PARTY_ITEMMASTER")
        OBJ1.LOADGRID(gdataset.Tables("PARTY_ITEMMASTER"), False, "FRM_ArrangementMaster", ChildSql, "ITEMCODE", 0)
        OBJ1.Show()
    End Sub

    Private Sub Txt_Pincode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Pincode.KeyPress
        getNumeric(e)
    End Sub


    Private Sub Cmd_Ccode_Click(sender As Object, e As EventArgs) Handles Cmd_Ccode.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(categorycode,'') AS categorycode, ISNULL(CATEGORYNAME,'') AS categoryname FROM POScategorymaster"
            M_WhereCondition = " "
            vform.Field = "categorycode,CATEGORYNAME"
            ' vform.Frmcalled = "   CATEGORY CODE   | CATEGORY NAME         |                                  "
            vform.vCaption = "Category Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Text_CCODE.Text = Trim(vform.keyfield & "")
                Text_CCODE_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Text_CCODE_KeyDown(sender As Object, e As KeyEventArgs) Handles Text_CCODE.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Text_CCODE.Enabled = True Then
                Search = Trim(Text_CCODE.Text)
                Call Cmd_Ccode_Click(Text_CCODE, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Text_CCODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_CCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Text_CCODE.Text) <> "" Then
                Call Text_CCODE_Validated(Text_CCODE, e)
            Else
                Call Cmd_Ccode_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Text_CCODE_Validated(sender As Object, e As EventArgs) Handles Text_CCODE.Validated
        If Trim(Text_CCODE.Text) <> "" Then
            vSeqNo = GetSeqno(Text_CCODE.Text)
            sqlstring = "SELECT * FROM poscategorymaster WHERE CATEGORYCODE='" & Trim(Text_CCODE.Text) & " '"
            gconnection.getDataSet(sqlstring, "categorymaster")
            If gdataset.Tables("categorymaster").Rows.Count > 0 Then
                Text_CCODE.Text = gdataset.Tables("categorymaster").Rows(0).Item("CATEGORYNAME")
                'txt_CCode.ReadOnly = True
                'Me.txt_CCode.ReadOnly = True
                'Me.Cmd_Ccode.Enabled = False
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                'Me.cmb_category.Focus()
            Else
                Text_CCODE.ReadOnly = False
            End If
        Else
            Text_CCODE.Text = ""
        End If
    End Sub
End Class