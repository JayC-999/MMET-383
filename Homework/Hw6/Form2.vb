Public Class Form2
    Private MPG As Decimal

    Private Sub btnAnalyze_Click(sender As Object, e As EventArgs) Handles btnAnalyze.Click
        'analyze button


        MPG = Form1.TotalMiles / Form1.TotalGallons

        'display results in form 2
        txtMiles2.Text = CStr(Form1.TotalMiles)
        txtGallons2.Text = CStr(Form1.TotalGallons)
        txtMPG.Text = Format(MPG, "0.0")
    End Sub

    Private Sub btnExit2_Click(sender As Object, e As EventArgs) Handles btnExit2.Click
        'end button

        Me.Close()
        End
    End Sub

    Private Sub btnOpen2_Click(sender As Object, e As EventArgs) Handles btnOpen2.Click
        'open button form2

        OpenFileDialog2.ShowDialog()
    End Sub
End Class