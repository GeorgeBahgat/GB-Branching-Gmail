Imports System.IO
Imports System.Text
Imports System.Threading
Public Class Form1
    Sub COGS()
        On Error Resume Next
        For Each SL As String In TextBox1.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
            Dim IHEB1 As String = SL.Split("@")(0)

            TextBox2.Text = IHEB1
        Next
    End Sub

    Sub New()
        InitializeComponent()
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://www.youtube.com/@george.bahgat")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://www.facebook.com/i.GeorgeBahgat/")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox("Don't Forget To Subscribe For More :D")
        '  Process.Start("https://www.youtube.com/@george.bahgat")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.Height >= 580 Then
            Timer1.Stop()
        Else
            Me.Height += 10
            If Me.Height >= 580 Then
                Timer1.Stop()
            End If
        End If

    End Sub
    Dim f As Boolean = True

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text <> Nothing Then
            Timer1.Start()
            NewMail.ScrollBars = ScrollBars.Vertical
            Label3.Show()

            If f = True Then
                f = False
                Button2.Text = "Stop"
                NewMail.Clear()
                Timer2.Start()
                Label3.Text = 0
            Else
                '
                f = True
                Timer2.Stop()
                Button2.Text = "Generate List"
            End If
        End If

    End Sub
    Function GetRandomNumber() As Integer
        Dim rnd As New Random()
        Return rnd.Next(3, 10)
    End Function
    Function G(ByRef length As Integer) As String

        Randomize()

        Dim allowableChars As String

        allowableChars = "abcdefghijklmnopqrstuvwzxy12345678.9_"



        Dim i As Integer

        For i = 1 To length

            G = G & Mid$(allowableChars, Int(Rnd() * Len(allowableChars) + 1), 1)

        Next

    End Function
    Private Function AddRandomDots(textbox As TextBox) As String
        Dim sb As New StringBuilder()
        Dim random As New Random()
        For Each c As Char In textbox.Text
            sb.Append(c)
            If random.Next(0, 2) = 0 Then
                sb.Append(".")
            End If
        Next
        Return sb.ToString()
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = Nothing Then : Exit Sub
        End If
        NewMail.Clear()
        Dim OO As New Thread(AddressOf COGS)
        OO.IsBackground = True
        OO.Start()
        Dim s As String = AddRandomDots(TextBox2)
        Dim randomNumber As Integer = GetRandomNumber()
        NewMail.Text = s + "+" + G(randomNumber) + "@gmail.com"
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = Nothing Then : Exit Sub
        End If
        NewMail.Clear()
        Dim OO As New Thread(AddressOf COGS)
        OO.IsBackground = True
        OO.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim s As String = AddRandomDots(TextBox2)
        Dim randomNumber As Integer = GetRandomNumber()
        NewMail.Text += s + "+" + G(randomNumber) + "@gmail.com" + vbNewLine
        Label3.Text += 1
    End Sub
End Class
