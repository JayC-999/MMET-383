Public Class Form1
    Public LowTemp As Double = 0
    Public HighTemp As Double = 0
    Public FahrenheitToCelsius As Double = 0
    Public CelsiusToFarhenheit As Double = 0
    'Public CurrentTemp As Double = 0
    Public Message As String

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        'calculate button

        'LowTemp = txtLowTemp.Text
        'HighTemp = txtHighTemp.Text

        If rbtnFtoC.Checked = True Then ' if radiobutton F to C is checked

            LowTemp = txtLowTemp.Text
            HighTemp = txtHighTemp.Text
            Message = "Fahrenheit" & vbTab & "Celcius"

            Do
                'convert F to C
                FahrenheitToCelsius = (LowTemp - 32) / (1.8)

                'output message
                Message = Message & vbCrLf & LowTemp & vbTab & vbTab & Format(FahrenheitToCelsius, "0.0")

                'update temp
                LowTemp = LowTemp + 1
            Loop While (LowTemp <= HighTemp)

            'output results
            txtResults.Enabled = True
            txtResults.Text = Message

        ElseIf rbtnCtoF.Checked = True Then 'if radiobutton C to F is checked

            LowTemp = txtLowTemp.Text
            HighTemp = txtHighTemp.Text
            Message = "Celcius" & vbTab & "Fahrenheit"

            Do
                'convert C to F
                CelsiusToFarhenheit = (LowTemp * 1.8) + 32

                'output message
                Message = Message & vbCrLf & LowTemp & vbTab & vbTab & Format(CelsiusToFarhenheit, "0.0")

                'update temp
                LowTemp = LowTemp + 1
            Loop While (LowTemp <= HighTemp)

            'output results
            txtResults.Enabled = True
            txtResults.Text = Message

        Else
            'error if txtbox is empty and rbtn is not selected
            If IsNumeric(txtLowTemp.Text) = False And IsNumeric(txtHighTemp.Text) = False And rbtnCtoF.Checked = False And rbtnFtoC.Checked = False Then
                MsgBox("Please make sure that all fields have an input and a conversion is checked")
            End If
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'end button
        End
    End Sub
End Class
