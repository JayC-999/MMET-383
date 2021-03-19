Public Class Form1
    Public BaseNumber As Double = 0
    Public LowTimes As Double = 0
    Public HighTimes As Double = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        'calculate button

        If txtBaseNum.Text = "" And txtHighTimes.Text = "" And txtLowTimes.Text = "" Then
            MsgBox("Please make sure all fields have an input")
        Else

            BaseNumber = txtBaseNum.Text
            LowTimes = txtLowTimes.Text
            HighTimes = txtHighTimes.Text

            If LowTimes <= 0 Or HighTimes <= 0 Or BaseNumber <= 0 Then
                MsgBox("Please make sure all inputs are greater than zero")
            Else
                'display for multiplication table
                ListBox1.Items.Add("Multiplication Table for " & BaseNumber)

                'display results and end on given condition
                Do
                    ListBox1.Items.Add(BaseNumber & " X " & LowTimes & " = " & BaseNumber * LowTimes)

                    LowTimes = LowTimes + 1


                Loop While (LowTimes <= HighTimes)
            End If 'end if if all fields are greater than zero
        End If 'end if for all fields checked
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'End Button
        End
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Clear Button

        txtBaseNum.Text = ""
        txtLowTimes.Text = ""
        txtHighTimes.Text = ""
        ListBox1.Items.Clear()
    End Sub
End Class
