Imports System.IO

Public Class ReportDesigner
    Dim vconn As New GlobalClass
    Dim colomns As String
    Dim sizes As String

    Private Sub BUT_GEN_VIEW_Click(sender As Object, e As EventArgs) Handles BUT_GEN_VIEW.Click
        Dim i, cnt, totsize As Integer
        Dim size, ssql, caption, Order As String
        i = 0
        cnt = 0
        colomns = ""
        size = ""
        caption = ""
        totsize = 0
        For i = 0 To Me.DataGridView1.RowCount - 1
            If DataGridView1.Rows(i).Cells("chk").Value = True Then
                If colomns = "" Then
                    colomns = DataGridView1.Rows(i).Cells("Column Name").Value.ToString
                    caption = DataGridView1.Rows(i).Cells("Column Name").Value.ToString
                    size = DataGridView1.Rows(i).Cells("Size").Value.ToString
                    totsize = totsize + Val(DataGridView1.Rows(i).Cells("Size").Value.ToString)
                Else
                    colomns = colomns & "," & DataGridView1.Rows(i).Cells("Column Name").Value.ToString
                    caption = caption & "," & DataGridView1.Rows(i).Cells("Column Name").Value.ToString
                    size = size & "," & DataGridView1.Rows(i).Cells("Size").Value.ToString
                    totsize = totsize + Val(DataGridView1.Rows(i).Cells("Size").Value.ToString)
                End If
                cnt += 1
            End If
        Next
        If colomns = "" Then
            'MsgBox("No Fields Has Been Selected")
            Exit Sub
        End If
        If tables = "" Then Exit Sub
        ssql = " Select " & colomns & " " & tables
        'MsgBox(size)
        'MsgBox(ssql)
        colomns = ""
        gPrint = False

        PrintOperation(ssql, size, caption, totsize, cnt, Order)

    End Sub

    Sub PrintOperation(ByVal sql As String, ByVal size As String, ByVal caption As String, ByVal totsize As Integer, ByVal cnt As Integer, ByVal Order As String)
        Randomize()
        Dim rowj As Integer
        Dim ssql As String
        Dim vCaption As String
        Dim Loopindex, i As Integer
        Dim vPath As String
        Dim str As String
        Dim Fsize() As String
        Dim Forder() As String
        Dim vFilepath As String
        Dim Filewrite As StreamWriter
        Dim vOutfile, vheader, vline As String
        Dim vpagenumber As Long
        Dim Vrowcount As Long
        Dim in1 As Integer
        Dim CountItem As Integer
        Dim Fo As Integer
        AppPath = Application.StartupPath
        Try
            vpagenumber = 1
            If Directory.Exists(AppPath & "\Reports") = True Then
            Else
                Directory.CreateDirectory(AppPath & "Reports")
            End If
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            vFilepath = AppPath & "\Reports\" & vOutfile & ".txt"
            If Trim(Order) <> "" Then
                Forder = Order.Split(",")
                ' Forder.Sort(Forder)
                Order = ""
            End If
            vconn.getDataSet(sql, "ReportTable")
            If gdataset.Tables("ReportTable").Rows.Count > 0 Then
                Filewrite = File.AppendText(vFilepath)
                vline = "----"
                For i = 1 To totsize
                    vline = vline & "-"
                Next
                For rowj = 0 To gdataset.Tables("ReportTable").Rows.Count - 1
                    If Vrowcount = 0 Then
                        If totsize > 80 Then
                            Filewrite.Write(Chr(15))
                        Else
                            Filewrite.Write(Chr(18))
                        End If
                        'vheader = Chr(14) & Chr(15) & Space((totsize / 2) - (Len(gCompanyname) / 2)) & gCompanyname
                        vheader = Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F"
                        'Filewrite.WriteLine(vheader)
                        'vheader = Space((totsize / 2) - (Len(Gheader) / 2)) & Gheader
                        Filewrite.WriteLine(vheader)
                        Filewrite.WriteLine(Gheader)
                        If Val(totsize) > 21 Then
                            ssql = "Date: " & Format(Now, "dd/MM/yyyy")
                        Else
                            ssql = "Date: " & Format(Now, "dd/MM/yyyy")
                        End If
                        If Val(totsize) > 21 Then
                            ssql = ssql & Space(totsize - 35) & "Page Number: " & vpagenumber
                        Else
                            ssql = ssql & Space(totsize - 35) & "Page Number: " & vpagenumber
                        End If
                        Filewrite.WriteLine(ssql)
                        Filewrite.WriteLine(vline)
                        ssql = "||"
                        Dim arr() As String
                        arr = caption.Split(",")
                        ssql = ""
                        Fsize = size.Split(",")
                        For in1 = 0 To arr.Length - 1
                            ssql = ssql & Mid(Trim(arr(in1) & ""), 1, Val(Fsize(in1))) & Space(Val(Fsize(in1) + 1) - Len(Mid(Trim(arr(in1) & ""), 1, Val(Fsize(in1)))))
                        Next
                        Filewrite.WriteLine(ssql)
                        Filewrite.WriteLine(vline)
                        Vrowcount = 8
                    End If
                    With gdataset.Tables("ReportTable").Rows(rowj)
                        ssql = ""
                        While CountItem <= cnt - 1
                            'If Val((.Item(CountItem))) = 0 Then
                            ssql = ssql & Mid(Trim(.Item(CountItem) & ""), 1, Val(Fsize(CountItem))) & Space(Val(Fsize(CountItem) + 1) - Len(Mid(Trim(.Item(CountItem) & ""), 1, Val(Fsize(CountItem)))))
                            'Else
                            'ssql = ssql & Space(Val(Fsize(CountItem) + 1) - Len(Mid(Trim(.Item(CountItem) & ""), 1, Val(Fsize(CountItem))))) & Mid(Trim(.Item(CountItem) & ""), 1, Val(Fsize(CountItem)))
                            'End If
                            CountItem = CountItem + 1
                        End While
                        Filewrite.WriteLine(ssql)
                        ssql = ""
                        CountItem = 0
                        Vrowcount = Vrowcount + 1

                    End With
                    If Vrowcount > 55 Then
                        Filewrite.WriteLine(vline)
                        Filewrite.WriteLine("User Name: " & gUsername & Space(30) & "Date :" & Format(Date.Now, "dd/MM/yyyy") & Chr(12))
                        Vrowcount = 0
                        vpagenumber = Val(vpagenumber) + 1
                    End If
                Next
                Filewrite.WriteLine(vline)
                Filewrite.WriteLine("User Name: " & gUsername & Space(30) & "Date :" & Format(Date.Now, "dd/MM/yyyy") & Chr(12))
                'Filewrite.WriteLine("The Software Is Designed And Developed By DATABASE SOFTWARE,Chennai")
                'Filewrite.WriteLine("To Know Abt DBS Pls Mail at :- info@databasesoftware.in")
                Filewrite.Close()
                If gPrint = True Then
                    PrintTextFile(vOutfile)
                Else
                    OpenTextFile(vOutfile)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, )
            Exit Sub
        End Try
    End Sub

    Private Sub BUT_GV_PRINT_Click(sender As Object, e As EventArgs) Handles BUT_GV_PRINT.Click
        Dim i, cnt, totsize As Integer
        Dim size, ssql, caption, Order As String
        i = 0
        cnt = 0
        colomns = ""
        size = ""
        caption = ""
        totsize = 0
        For i = 0 To Me.DataGridView1.RowCount - 1
            If DataGridView1.Rows(i).Cells("chk").Value = True Then
                If colomns = "" Then
                    colomns = DataGridView1.Rows(i).Cells("Column Name").Value.ToString
                    caption = DataGridView1.Rows(i).Cells("Column Name").Value.ToString
                    size = DataGridView1.Rows(i).Cells("Size").Value.ToString
                    totsize = totsize + Val(DataGridView1.Rows(i).Cells("Size").Value.ToString)
                Else
                    colomns = colomns & "," & DataGridView1.Rows(i).Cells("Column Name").Value.ToString
                    caption = caption & "," & DataGridView1.Rows(i).Cells("Column Name").Value.ToString
                    size = size & "," & DataGridView1.Rows(i).Cells("Size").Value.ToString
                    totsize = totsize + Val(DataGridView1.Rows(i).Cells("Size").Value.ToString)
                End If
                cnt += 1
            End If
        Next
        If colomns = "" Then
            'MsgBox("No Fields Has Been Selected")
            Exit Sub
        End If
        If tables = "" Then Exit Sub
        ssql = " Select " & colomns & " " & tables
        'MsgBox(size)
        'MsgBox(ssql)
        colomns = ""
        gPrint = True
        PrintOperation(ssql, size, caption, totsize, cnt, Order)
    End Sub

    Private Sub BUT_EXIT_Click(sender As Object, e As EventArgs) Handles BUT_EXIT.Click
        Me.Close()
    End Sub

    Private Sub ReportDesigner_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            For i = 0 To Me.DataGridView1.RowCount - 2
                DataGridView1.Rows(i).Cells("chk").Value = True
                ' Exit Sub
            Next
        End If
        If e.KeyCode = Keys.F3 Then
            For i = 0 To Me.DataGridView1.RowCount - 1
                DataGridView1.Rows(i).Cells("chk").Value = False
                'Exit Sub
            Next
        End If
    End Sub

    Private Sub ReportDesigner_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class