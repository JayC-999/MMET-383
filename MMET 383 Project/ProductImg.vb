Public Class ProductImg
    Private Sub rbtnPress_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPress.CheckedChanged
        PictureBox1.Load("PresSensor.jpg")
        PictureBox1.Visible = True
    End Sub

    Private Sub rbtnTemp_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTemp.CheckedChanged
        PictureBox1.Load("TempSensor.jpg")
        PictureBox1.Visible = True
    End Sub

    Private Sub rbtnOptical_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOptical.CheckedChanged
        PictureBox1.Load("OptiSensor.jpg")
        PictureBox1.Visible = True
    End Sub

    Private Sub rbtnProxi_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnProxi.CheckedChanged
        PictureBox1.Load("ProxSensor.jpeg")
        PictureBox1.Visible = True
    End Sub

    Private Sub rbtnLimit_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnLimit.CheckedChanged
        PictureBox1.Load("LimitSwitch.jpg")
        PictureBox1.Visible = True
    End Sub

    Private Sub rbtnHMI_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnHMI.CheckedChanged
        PictureBox1.Load("HumanMachineInt.jpg")
        PictureBox1.Visible = True
    End Sub

    Private Sub btnGoToLogin_Click(sender As Object, e As EventArgs) Handles btnGoToLogin.Click
        Me.Close()
        LogIn.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        End
    End Sub
End Class