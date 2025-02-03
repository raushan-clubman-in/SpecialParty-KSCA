Imports System.IO
Imports System.Runtime.InteropServices
Public Class Class1UPDATE
    'Friend Class Class1
    ' Methods
    Public Shared Sub Main(ByVal args As String())
        Console.WriteLine("Reading File.......")
        Dim general As New GENERALUPDATE
        If Not Directory.Exists("C:\KGACARD") Then
            Directory.CreateDirectory("C:\KGACARD")
        End If
        If Not general.FnReadDataFile Then
            Console.WriteLine("Error reading specified file")
            Class1.Sleep(&H7D0)
        ElseIf Not general.FnReadKeyFile Then
            Console.WriteLine("Error reading specified file")
        ElseIf Not general.FnUpdateCard Then
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
            Dim gen1 As New Class1write
            Dim s As String()
            gen1.Main(s)
        Else
            Console.WriteLine("Card Updated Successfully")
            Dim str2 As String = "C:\KGACARD\Success.txt"
            Dim stream2 As FileStream = File.Open(str2, FileMode.Create, FileAccess.Write)
            Dim num2 As Long = stream2.Length
            ' New StreamWriter(stream2).Close
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
