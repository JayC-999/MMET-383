Public Class Navigation
    Private NewIndex As Integer = 0
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Form2 load

        'load picture for the given divison
        PictureBox1.Load(LogIn.ImageList(LogIn.CurrentIndexForPic))


    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        'back button

        'closes current form and returns to first form and clears code textbox
        Me.Close()
        LogIn.Show()
        LogIn.txtCode.Text = ""

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'next button

        'Preps next picture to show
        LogIn.CurrentIndexForPic = LogIn.CurrentIndexForPic + 1

        'returns to first picture in ImageList when it reaches the end of its array and starts over
        If LogIn.CurrentIndexForPic > 5 Then
            LogIn.CurrentIndexForPic = 0
        End If

        'displays next picture
        PictureBox1.Load(LogIn.ImageList(LogIn.CurrentIndexForPic))
    End Sub
End Class