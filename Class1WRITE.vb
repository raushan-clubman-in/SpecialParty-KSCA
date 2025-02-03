Imports System.Runtime.InteropServices
Imports System.IO

Public Class Class1write
    '  Friend Class Class1
    ' Methods
    Public Shared Sub Main(ByVal args As String())
        Console.WriteLine("Reading Data File.......")
        Dim general As New generalwrite
        If Not Directory.Exists("C:\KGACARD") Then
            Directory.CreateDirectory("C:\KGACARD")
        End If
        If Not general.FnReadDataFile Then
            Console.WriteLine("Error reading specified file")
        ElseIf Not general.FnReadKeyFile Then
            Console.WriteLine("Error reading specified file")
        ElseIf Not general.FnWriteCard Then
            If Not Directory.Exists("C:\KGACARD") Then
                Directory.CreateDirectory("C:\KGACARD")
            End If
            Dim path As String = "C:\KGACARD\Error.txt"
            Dim stream As FileStream = File.Open(path, FileMode.Create, FileAccess.ReadWrite)
            Dim length As Long = stream.Length
            Dim writer As New StreamWriter(stream)
            writer.WriteLine(general.WizObj.sErrorMsg)
            writer.Close()
            stream.Close()
        Else
            Console.WriteLine("Card Write Successfull")
            Dim str2 As String = "C:\KGACARD\Success.txt"
            Dim stream2 As FileStream = File.Open(str2, FileMode.Create, FileAccess.Write)
            Dim num2 As Long = stream2.Length
            'New StreamWriter(stream2).Close
            stream2.Close()
            Class1.Sleep(&H7D0)
        End If
    End Sub

    <STAThread(), DllImport("kernel32.dll")> _
    Public Shared Sub Sleep(ByVal needed As Long)
    End Sub

    '  End Class


    'Collapse Methods


End Class
