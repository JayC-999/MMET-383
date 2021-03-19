Public Class Form1

    'custom subroutine
    Private Sub xDisplay(ByVal Happytxt As String, ByVal Oktxt As String, ByVal Sadtxt As String,
                        ByVal HappyChecked As String, ByVal OkChecked As String, SadChecked As String)

        'this custom subroutine displays a text for each corresponding textbox in a changed subroutine and the visibility for each corresponding
        ' picturebox

        'dispaly text
        txtHappy.Text = Happytxt
        txtOk.Text = Oktxt
        txtSad.Text = Sadtxt

        'display picture
        picHappy.Visible = HappyChecked
        picOk.Visible = OkChecked
        picSad.Visible = SadChecked
    End Sub

    Private Sub rbtnHappy_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnHappy.CheckedChanged

        'calling custom subroutine if radio button happy is picked
        Call xDisplay("I am going to Disney", "", "", True, False, False)
    End Sub

    Private Sub rbtnOk_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOk.CheckedChanged

        'calling custom subroutine if radio button ok is picked
        Call xDisplay("", "I am ok", "", False, True, False)
    End Sub

    Private Sub rbtnSad_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSad.CheckedChanged

        'calling custon subroutine if radio button sad is picked
        Call xDisplay("", "", "I am sad", False, False, True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Exit Button
        End
    End Sub
End Class
