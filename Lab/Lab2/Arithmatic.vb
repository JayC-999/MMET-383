Public Class Form1
    Private Inc, Dec, Count, IncDec As Integer

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Increment

        Dec = CInt(TextBox3.Text)
        Inc = CInt(TextBox5.Text)
        IncDec = CInt(TextBox2.Text)

        Dec = Dec - IncDec
        Inc = Inc + IncDec
        Count = Count + 1

        TextBox3.Text = CStr(Dec)
        TextBox4.Text = CStr(Count)
        TextBox5.Text = CStr(Inc)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Initialize 

        TextBox3.Text = TextBox1.Text
        TextBox5.Text = TextBox1.Text
        TextBox4.Text = "0"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Count = 0
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Swap

        Dim Temp As String
        Temp = ""

        Temp = TextBox3.Text
        TextBox3.Text = TextBox5.Text
        TextBox5.Text = Temp
    End Sub
End Class
