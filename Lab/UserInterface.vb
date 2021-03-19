Public Class Form1
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        PictureBox1.Visible = True
        PictureBox2.Visible = False
        PictureBox3.Visible = False

        TextBox1.Text = "I am going to Disney"
        TextBox2.Text = ""
        TextBox3.Text = ""




    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        PictureBox1.Visible = False
        PictureBox2.Visible = True
        PictureBox3.Visible = False

        TextBox1.Text = ""
        TextBox2.Text = "I am bored"
        TextBox3.Text = ""
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = True


        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = "I lost my wallet"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub
End Class
