Public Class Form1
    Public TruckNum As Integer
    Public NumOfMiles As Decimal
    Public NumOfGallons As Decimal
    Public TotalMiles As Decimal = 0
    Public TotalGallons As Decimal = 0
    Public TruckData As String = "TruckData.CSV"

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        'enter button

        'handles error conditions 
        If txtTruck.Text = "" Or txtMiles.Text = "" Or txtGallons.Text = "" Then

            MsgBox("Please make sure all fields have an input")

        ElseIf Not IsNumeric(txtTruck.Text) Or Not IsNumeric(txtMiles.Text) Or Not IsNumeric(txtGallons.Text) Then

            MsgBox("Please make sure all fields have numbers and are greater than zero")

        Else

            'testing purpose; erases all data before each start of the program to determine if the program runs correctly
            'System.IO.File.WriteAllText(TruckData, "")

            'creating file if it does not exsit (.CSV file)
            If (Not System.IO.File.Exists(TruckData)) Then
                MsgBox("File Created")
                System.IO.File.Create(TruckData).Dispose()
            End If

            'opens file to store data
            FileOpen(1, TruckData, OpenMode.Append)

            'stores data in respective variables
            TruckNum = txtTruck.Text
            NumOfMiles = txtMiles.Text
            NumOfGallons = txtGallons.Text

            'new line after each entry
            WriteLine(1, TruckNum, NumOfMiles, NumOfGallons)

            'keeping track of total miles and gallons
            TotalMiles = TotalMiles + NumOfMiles
            TotalGallons = TotalGallons + NumOfGallons

            'clear text boxes after each entry
            txtTruck.Text = ""
            txtMiles.Text = ""
            txtGallons.Text = ""

            FileClose(1)
        End If
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        'open button

        'promts user to open their files folder and open the .CSV file that was created
        OpenFileDialog1.ShowDialog()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'exit button

        Me.Close()
        End
    End Sub

    Private Sub btnGoToAnalyzeData_Click(sender As Object, e As EventArgs) Handles btnGoToAnalyzeData.Click
        'go to analyze button

        'opens form2 
        Me.Hide()
        Form2.Show()
    End Sub
End Class
