Imports System.IO

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'ADD THE TEXTBOX1 TEXT FOR THE HOSTS FILE
        Dim path As String
        Dim sw As StreamWriter
        Dim site As String = TextBox1.Text

        site = site.Replace("https://", "")
        site = site.Replace("http://", "")

        path = "C:\Windows\System32\drivers\etc\hosts"
        sw = New StreamWriter(path, True)
        Dim sitetoblock As String = (Environment.NewLine & "127.0.0.1		" & site)
        sw.Write(sitetoblock)
        sw.Close()

        loadSites()

    End Sub
    Sub loadSites()
        'CLEAN TEXTBOX2
        TextBox2.Clear()
        'LOAD THE HOSTS FILE LINKS TO TEXTBOX2
        Dim inputFilePath As String = "C:\Windows\System32\drivers\etc\hosts"

        Using reader As New StreamReader(inputFilePath)
            While Not reader.EndOfStream

                Dim line As String = reader.ReadLine()
                Dim lineClean As String = line.Replace("127.0.0.1		", "")

                If line.Contains("127.0.0.1") And Not line.Contains("localhost") Then
                    If TextBox2.Text = "" Then
                        TextBox2.Text = lineClean
                    Else
                        TextBox2.AppendText(Environment.NewLine & lineClean)
                    End If

                End If
            End While
        End Using

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'CALL LOAD SITE
        loadSites()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'SAVE TEXTBOX2 TEXT TO HOSTS FILE
        Dim lines As String() = TextBox2.Lines

        For line As Integer = 0 To lines.Count - 1
            lines(line) = "127.0.0.1		" & lines(line)
        Next

        TextBox3.Lines = lines

        File.WriteAllText("C:\Windows\System32\drivers\etc\hosts", TextBox3.Text)

    End Sub

End Class
