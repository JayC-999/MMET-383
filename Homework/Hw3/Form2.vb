Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ModuleQuiz.TotalNumScores
        TextBox2.Text = ModuleQuiz.HighestScore
        TextBox3.Text = ModuleQuiz.LowestScore
        TextBox4.Text = ModuleQuiz.AvgScore
        TextBox5.Text = ModuleQuiz.NumOfCOrBetter
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class