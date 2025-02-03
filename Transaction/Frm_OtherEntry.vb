Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports System.IO
Public Class Frm_OtherEntry
    Dim SSQL As String
    Dim GCONNECTION As New GlobalClass
    Dim gconn As New GlobalClass
    Dim DT As New DataTable
    Dim GrdRate, GrdAmount, GrdTaxAmt As Double
    Dim boolchk, booldatechk As Boolean
    Dim sqlstring As String
    Private Sub Frm_OtherEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Call Resize_Form()
    End Sub
    Private Sub GetRights()
        Try
            Dim i, j, k, x As Integer
            Dim vmain, vsmod, vssmod As Long
            Dim ssql, SQLSTRING As String
            Dim M1 As New MainMenu
            Dim chstr As String

            SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
            gconnection.getDataSet(SQLSTRING, "USER")
            If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
                For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                    With gdataset.Tables("USER").Rows(i)
                        chstr = abcdMINUS(.Item("RIGHTS"))
                    End With
                Next
            End If

            Me.CmdAdd.Enabled = False
            Me.Cmd_Freeze.Enabled = False
            Cmdview.Enabled = False
            'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
            If Len(chstr) > 0 Then
                Dim Right() As Char
                Right = chstr.ToCharArray
                For x = 0 To Right.Length - 1
                    If Right(x) = "A" Then
                        Me.CmdAdd.Enabled = True
                        Me.Cmd_Freeze.Enabled = True
                        Me.Cmdview.Enabled = True
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
                        Me.Cmd_Freeze.Enabled = True
                    End If
                    If Right(x) = "V" Then
                        Me.Cmdview.Enabled = True
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
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

    Private Sub Cmd_BookingNoHelp_Click(sender As Object, e As EventArgs) Handles Cmd_BookingNoHelp.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "Select BOOKINGNO,MCODE,GUESTNAME,PARTYDATE from Party_Hallbooking_Hdr"
            If Trim(Search) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " "
            End If
            vform.Field = "BOOKINGNO,MCODE,GUESTNAME,PARTYDATE"
            vform.vCaption = "Booking Help"
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_BookingNo.Text = Trim(vform.keyfield & "")
                Txt_BookingNo_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txt_BookingNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_BookingNo.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_BookingNo.Text) = "" Then
                Call Cmd_BookingNoHelp_Click(sender, e)
            Else
                sqlstring = "SELECT * FROM Party_Hallbooking_Hdr WHERE BOOKINGNO=" & Val(Txt_BookingNo.Text) & " "
                GCONNECTION.getDataSet(sqlstring, "HallStatus")
                If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                    Txt_BookingNo_Validated(sender, e)
                    Txt_StoreConsum.Focus()
                Else
                    MessageBox.Show("No Booking Found, Plz Check", MyCompanyName)
                    Txt_BookingNo.Text = ""
                    Txt_BookingNo.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Txt_BookingNo_Validated(sender As Object, e As EventArgs) Handles Txt_BookingNo.Validated
        Try
            If Trim(Txt_BookingNo.Text) <> "" Then
                sqlstring = "select * from Party_Hallbooking_Hdr WHERE BOOKINGNO=" & Txt_BookingNo.Text & " "
                GCONNECTION.getDataSet(sqlstring, "HallHdr")
                If gdataset.Tables("HallHdr").Rows.Count > 0 Then
                    Dtp_BookingDate.Value = Format(gdataset.Tables("HallHdr").Rows(0).Item("BOOKINGDATE"), "dd/MM/yyyy HH:mm:ss")
                    Dtp_PartyDate.Value = Format(gdataset.Tables("HallHdr").Rows(0).Item("PARTYDATE"), "dd/MM/yyyy HH:mm:ss")
                    Txt_Purpose.Text = gdataset.Tables("HallHdr").Rows(0).Item("DESCRIPTION")
                    Txt_MemberCode.Text = gdataset.Tables("HallHdr").Rows(0).Item("MCODE")
                    Txt_MemberName.Text = gdataset.Tables("HallHdr").Rows(0).Item("ASSOCIATENAME")
                    Txt_GuestName.Text = gdataset.Tables("HallHdr").Rows(0).Item("GUESTNAME")
                    Txt_TotPax.Text = Val(gdataset.Tables("HallHdr").Rows(0).Item("OCCUPANCY"))
                    Txt_VPax.Text = Val(gdataset.Tables("HallHdr").Rows(0).Item("VEG"))
                    Txt_NVPax.Text = Val(gdataset.Tables("HallHdr").Rows(0).Item("NONVEG"))
                    Txt_CellNo.Text = gdataset.Tables("HallHdr").Rows(0).Item("CELLNO")
                    Txt_Email.Text = gdataset.Tables("HallHdr").Rows(0).Item("EMAIL")

                    sqlstring = "select * from PARTY_OTHERENTRY WHERE BOOKINGNO=" & Txt_BookingNo.Text & " "
                    GCONNECTION.getDataSet(sqlstring, "PARTY_OTHERENTRY")
                    If gdataset.Tables("PARTY_OTHERENTRY").Rows.Count > 0 Then
                        Txt_StoreConsum.Text = Format(gdataset.Tables("PARTY_OTHERENTRY").Rows(0).Item("StoreConsum"), "0.00")
                        Txt_OTKit.Text = Format(gdataset.Tables("PARTY_OTHERENTRY").Rows(0).Item("OT_Kit"), "0.00")
                        Txt_OTService.Text = Format(gdataset.Tables("PARTY_OTHERENTRY").Rows(0).Item("OT_Service"), "0.00")
                        Txt_Cont_ItemCost.Text = Format(gdataset.Tables("PARTY_OTHERENTRY").Rows(0).Item("Cont_ItemCost"), "0.00")
                        Me.CmdAdd.Text = "Update[F7]"
                    End If
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    Me.Txt_BookingNo.ReadOnly = True
                Else
                    MessageBox.Show("No Booking Found, Plz Check", MyCompanyName)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Txt_StoreConsum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_StoreConsum.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_StoreConsum.Text) >= 0 Then
                Txt_OTKit.Focus()
            Else
                Txt_StoreConsum.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_OTKit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_OTKit.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_OTKit.Text) >= 0 Then
                Txt_OTService.Focus()
            Else
                Txt_OTKit.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_OTService_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_OTService.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_OTService.Text) >= 0 Then
                Txt_Cont_ItemCost.Focus()
            Else
                Txt_OTService.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_Cont_ItemCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Cont_ItemCost.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_Cont_ItemCost.Text) >= 0 Then
                CmdAdd.Focus()
            Else
                Txt_Cont_ItemCost.Focus()
            End If
        End If
    End Sub
    Public Sub checkValidation()
        Dim Loc As String
        Try
            boolchk = False
            Dim D1, d2 As DateTime
            Dim FDAY, TDAY, DAYS, CNT, j, k As Integer
            Dim hlcode, pcode, hlcode1, pcode1, Shlcode As String
            D1 = Format(Dtp_PartyDate.Value, "dd/MM/yyyy")
            d2 = Format(Dtp_BookingDate.Value, "dd/MM/yyyy")

            SSQL = "SELECT ISNULL(LOCCODE,'')AS LOCCODE FROM party_locationmaster"
            gconnection.getDataSet(ssql, "LOC")
            If gdataset.Tables("LOC").Rows.Count > 0 Then
                Loc = Trim(gdataset.Tables("LOC").Rows(0).Item("LOCCODE"))
            End If
            If Val(Txt_BookingNo.Text) = 0 Then
                MessageBox.Show("Booking No can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_BookingNo.Focus()
                Exit Sub
            End If
            If Val(Txt_Cont_ItemCost.Text) < 0 Then
                MessageBox.Show("Contractual Item Cost can't be less than 0 or less ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_Cont_ItemCost.Focus()
                Exit Sub
            End If
            If Val(Txt_StoreConsum.Text) < 0 Then
                MessageBox.Show("Store Consumption can't be less than 0 or less ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_StoreConsum.Focus()
                Exit Sub
            End If
            If Val(Txt_OTKit.Text) < 0 Then
                MessageBox.Show("OT Kitchen can't be less than 0 or less ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_OTKit.Focus()
                Exit Sub
            End If
            If Val(Txt_OTService.Text) < 0 Then
                MessageBox.Show("OT Service can't be less than 0 or less ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_OTService.Focus()
                Exit Sub
            End If
            boolchk = True

        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim strSQL, SQL As String
        Dim INSERT(0) As String
        Try
            Call checkValidation()
            If boolchk = False Then Exit Sub
            If CmdAdd.Text = "Add [F7]" Then
                strSQL = "INSERT INTO PARTY_OTHERENTRY(BookingNo,StoreConsum,OT_Kit,OT_Service,Cont_ItemCost,Adduser,AddDate)"
                strSQL = strSQL & " VALUES ('" & Txt_BookingNo.Text & "'," & Val(Txt_StoreConsum.Text) & "," & Val(Txt_OTKit.Text) & ", " & Val(Txt_OTService.Text) & "," & Val(Txt_Cont_ItemCost.Text) & ","
                strSQL = strSQL & "'" & Trim(gUsername) & "',Getdate())"
                GCONNECTION.dataOperation(1, strSQL, "PARTY_OTHERENTRY")
                Me.CmdClear_Click(sender, e)
            ElseIf CmdAdd.Text = "Update[F7]" Then
                strSQL = "UPDATE  PARTY_OTHERENTRY "
                strSQL = strSQL & " SET StoreConsum=" & Val(Txt_StoreConsum.Text) & ","
                strSQL = strSQL & " OT_Kit =" & Val(Txt_OTKit.Text) & ","
                strSQL = strSQL & " OT_Service=" & Val(Txt_OTService.Text) & ","
                strSQL = strSQL & " Cont_ItemCost =" & Val(Txt_Cont_ItemCost.Text) & ","
                strSQL = strSQL & " UpdUser='" & Trim(gUsername) & "',UpdDate=Getdate() "
                strSQL = strSQL & " Where BookingNo = '" & Txt_BookingNo.Text & "' "
                GCONNECTION.dataOperation(2, strSQL, "PARTY_OTHERENTRY")
                Me.CmdClear_Click(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        Me.Txt_BookingNo.ReadOnly = False
        Txt_BookingNo.Text = ""
        Dtp_PartyDate.Value = Format(serverdate, "dd/MM/yyyy")
        Dtp_BookingDate.Value = Format(serverdate, "dd/MM/yyyy")
        Txt_Purpose.Text = ""
        Txt_MemberCode.Text = ""
        Txt_MemberName.Text = ""
        Txt_TotPax.Text = ""
        Txt_GuestName.Text = ""
        Txt_CellNo.Text = ""
        Txt_Email.Text = ""
        Txt_VPax.Text = ""
        Txt_NVPax.Text = ""
        Txt_StoreConsum.Text = ""
        Txt_OTKit.Text = ""
        Txt_OTService.Text = ""
        Txt_Cont_ItemCost.Text = ""
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.Enabled = True
        Txt_BookingNo.Focus()
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
End Class