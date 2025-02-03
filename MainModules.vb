Imports System.IO
Module MainModules
    'Variable Declare
    Dim gStartDate As Date, gEndDate As Date
    Public Function GetSeqno(ByVal Seq As String)
        Dim vCheck As String
        Dim vString As String
        Dim vCode As String
        Dim sString As String
        Dim seqno As String
        Dim SCount As Integer
        vCode = Trim(Seq & "")
        SCount = Len(vCode)
        Dim i As Integer
        i = 1
        While i <= SCount
            vString = Mid(vCode, i, 1)
            sString = Asc(vString)
            seqno = seqno + sString
            i = i + 1
        End While
        Return seqno
    End Function
    Public Function NumberBoxCheck(ByRef x As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim s As String
        If Char.IsDigit(e.KeyChar) = False And (Microsoft.VisualBasic.Asc(e.KeyChar) <> 8 Or e.KeyChar <> ".") Then
            e.Handled = True
            Exit Function
        End If
        If Trim(x.Text) = Nothing = False And e.KeyChar <> "." Then
            s = x.Text
            If s.IndexOf(".") >= 0 Then
                e.Handled = True
            End If
        End If
    End Function
    Public Function decimalcheck(ByRef x As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim s As String
        If Char.IsDigit(e.KeyChar) = False And Microsoft.VisualBasic.Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            e.Handled = True
            Exit Function
        End If
        If Trim(x.Text) = Nothing = False And e.KeyChar = "." Then
            s = x.Text
            If s.IndexOf(".") >= 0 Then
                e.Handled = True
            End If
        End If
    End Function
    Public Function DateCheck(ByRef dt As Object, ByVal CheckFY As Boolean) As Boolean
        If Not IsDate(dt) Then
            DateCheck = False
            Exit Function
        Else
            DateCheck = True
        End If
        If CheckFY = True Then
            If gStartDate >= dt And gEndDate <= dt Then
                DateCheck = True
            Else
                DateCheck = False
            End If
        End If
    End Function
    Public Function DSApostrophe(ByVal x As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 34 Or Microsoft.VisualBasic.Asc(e.KeyChar) = 39) Then
            e.Handled = True
            Exit Function
        End If
    End Function
   
    Public Function GridClear(ByRef vGrid As Object, ByVal fromCol As Integer, ByVal ToCol As Integer, ByVal FromRow As Integer, ByVal ToRow As Integer)
        vGrid.ClearRange(1, 1, vGrid.MaxCols, vGrid.MaxRows, True)
    End Function
    Public Function SetColFocus(ByRef vGrid As Object, ByVal FromCol As Integer, ByVal ToRow As Integer)
        vGrid.focus()
        vGrid.SetActiveCell(FromCol, ToRow)
    End Function


    Public Function abcdMINUS(ByVal vString As String) As String
        Dim vDesc As String
        Dim vAsc As Long
        Dim vDes As String
        Dim vDt As String
        Dim Loopindex As Long
        vDesc = vString
        For Loopindex = 1 To Len(vDesc)
            vDes = Trim(Mid(vDesc, Loopindex, 1) & "")
            vAsc = Asc(vDes) - 150
            If vDt = "" Then
                vDt = Chr(vAsc)
            Else
                vDt = vDt & Chr(vAsc)
            End If
        Next Loopindex
        abcdMINUS = vDt
    End Function
    Public Function abcdADD(ByVal vString As String) As String
        Dim vDesc As String
        Dim vAsc As Long
        Dim vDes As String
        Dim vDt As String
        Dim Loopindex As Long
        vDesc = vString
        For Loopindex = 1 To Len(vDesc)
            vDes = Trim(Mid(vDesc, Loopindex, 1) & "")
            vAsc = Asc(vDes) + 150
            If vDt = "" Then
                vDt = Chr(vAsc)
            Else
                vDt = vDt & Chr(vAsc)
            End If
        Next Loopindex
        abcdADD = vDt
    End Function
    Public Function BoxCheck(ByRef x As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim s As String
        'If e.KeyChar.IsDigit(e.KeyChar) = False And (Microsoft.VisualBasic.Asc(e.KeyChar) <> 8 Or e.KeyChar = ".") Then
        If e.KeyChar.IsDigit(e.KeyChar) = False And e.KeyChar.IsUpper(e.KeyChar) = False And e.KeyChar.IsLower(e.KeyChar) Then 'And e.KeyChar.IsSeparator(e.KeyChar) Then

            e.Handled = True
            Exit Function
        End If
        If Trim(x.Text) = Nothing = False And e.KeyChar <> "." Then
            s = x.Text
            If s.IndexOf(".") >= 0 Then
                e.Handled = True
            End If
        End If
    End Function
    Public Function NumberBoxCheck1(ByRef x As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim s As String
        If e.KeyChar.IsDigit(e.KeyChar) = False And (e.KeyChar <> ".") And (e.KeyChar <> "-") Then
            e.Handled = True
            Exit Function
        End If
    End Function
End Module
