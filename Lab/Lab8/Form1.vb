Public Class Form1
    'declaring variables
    Public Quantity As Integer
    Private LowRange As Integer
    Private HighRange As Integer
    Private Message As String
    Private RandomNumbersArray() As Integer

    Private Sub btnGenData_Click(sender As Object, e As EventArgs) Handles btnGenData.Click
        'generate buttton

        'condition if erros occur. If none, proceed to generate random numbers
        If Lable1.Text = "" Or txtLow.Text = "" Or txtHigh.Text = "" Then

            MsgBox("Please make sure all fields are filled")

        ElseIf Not IsNumeric(txtQty.Text) Or Not IsNumeric(txtLow.Text) Or Not IsNumeric(txtHigh.Text) Then

            MsgBox("Please make sure all fields are numeric values and greater than zero")
        Else

            'variables equal textboxes
            Quantity = txtQty.Text
            LowRange = txtLow.Text
            HighRange = txtHigh.Text

            'preparing message and array
            Message = "Data has been generated:"
            ReDim Preserve RandomNumbersArray(0 To Quantity - 1)

            'generates random numbers and stores them in the array
            For i = 0 To Quantity - 1
                Dim RanNumber = CInt(Rnd() * (HighRange - LowRange) + LowRange)
                RandomNumbersArray(i) = RanNumber
            Next i

            'makes sure that there are 10 integers per line(row)
            For i = 0 To Quantity - 1
                If (i Mod 10) = 0 Then
                    Message = Message & vbCrLf & CStr(RandomNumbersArray(i))
                Else
                    Message = Message & vbTab & CStr(RandomNumbersArray(i))
                End If
            Next i

            'display data
            lblStatus.Visible = True
            txtDisplay.Enabled = True
            txtDisplay.Text = Message
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'save button

        lblStatus.Visible = False

        'opens file and stores data to it
        FileOpen(1, "data.txt", OpenMode.Output)

        'loop for making sure there are 10 integers per line
        For i = 0 To Quantity - 1
            If ((i + 1) Mod 10) = 0 Then
                Write(1, RandomNumbersArray(i))
                WriteLine(1)
            Else
                Write(1, RandomNumbersArray(i))
            End If
        Next

        'notifies that user saved file
        lblStatus.Visible = True
        lblStatus.Text = "File has been saved"
        MsgBox("File has been saved")

        'close file
        FileClose(1)
    End Sub

    Private Sub btnGoToRead_Click(sender As Object, e As EventArgs) Handles btnGoToRead.Click
        'got to read button

        Me.Hide()
        Form2.show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'exit button

        Me.Close()
        End
    End Sub
End Class
