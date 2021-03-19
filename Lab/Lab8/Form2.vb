Public Class Form2
    Private Min As Integer
    Private Max As Integer
    Private Mean As Decimal
    Private Sum As Integer
    Private TotalNumberOfData As Integer
    Private CurrentDataNumber As Integer
    Private Data As String
    Private Sub btnAnalyze_Click(sender As Object, e As EventArgs) Handles btnAnalyze.Click
        'analyze button

        'open file
        FileOpen(2, "data.txt", OpenMode.Input)

        'read first data point
        Input(2, Data)
        CurrentDataNumber = CInt(Data)

        'initializing variables
        TotalNumberOfData = 1
        Min = CurrentDataNumber
        Max = CurrentDataNumber
        Sum = CurrentDataNumber

        'reading rest of data
        Do Until EOF(2)
            Input(2, Data)

            If Data <> "" Then 'reads 10 numbers per line
                CurrentDataNumber = CInt(Data)

                'finding max number
                If CurrentDataNumber >= Max Then
                    Max = CurrentDataNumber
                End If

                'finding min number
                If CurrentDataNumber <= Min Then
                    Min = CurrentDataNumber
                End If

                'counting sum and total numbers within the file
                TotalNumberOfData = TotalNumberOfData + 1
                Sum = Sum + CurrentDataNumber
            End If
        Loop

        'display output
        txtQty2.Text = Form1.Quantity
        txtMin.Text = Min
        txtMax.Text = Max
        Mean = Sum / TotalNumberOfData
        txtMean.Text = Format(Mean, "0.00")

        FileClose(2)
    End Sub

    Private Sub btnGoToWrite_Click(sender As Object, e As EventArgs) Handles btnGoToWrite.Click
        'go to write button

        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub btnExit2_Click(sender As Object, e As EventArgs) Handles btnExit2.Click
        'exit button

        Me.Close()
        End
    End Sub
End Class