Public Class Form1
    Private HourlyPay As Double
    Private HoursWorked As Double
    Private GrossPay As Double = 0
    Private TaxRate As Double = 0.25
    Private Parking As Double = 0
    Private NetPay As Double = 0
    Private OvertimeRate As Double = 1.5
    Private UserName As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Calculate Button

        UserName = TextBox1.Text


        If UserName <> "" Then
            If TextBox2.Text <> "" Then
                If TextBox3.Text <> "" Then
                    If RadioButton1.Checked = True Or RadioButton2.Checked = True Or RadioButton3.Checked = True Then
                        'Calculate all inputs

                        HourlyPay = TextBox2.Text
                        HoursWorked = TextBox3.Text

                        'calculate gross pay

                        If HoursWorked <= 40 Then


                            GrossPay = HourlyPay * HoursWorked

                        Else

                            GrossPay = (HourlyPay * 40) + (OvertimeRate * HourlyPay * (HoursWorked - 40))

                        End If 'end if condition for hours worked

                        'calculate parking fee if pay is < 20

                        If HourlyPay < 20 Then
                            If RadioButton1.Checked = True Then

                                Parking = 10

                            ElseIf RadioButton2.Checked = True Then

                                Parking = 4
                            End If 'end if condition if pay is < 20 & parking A is chosen 
                        End If 'end if condition if pay is < 20

                        'parking fee condition if pay is >= 20

                        If HourlyPay >= 20 Then
                            If RadioButton1.Checked = True Then
                                Parking = 14

                            ElseIf RadioButton2.Checked = True Then
                                Parking = 6
                            End If
                        End If

                        If RadioButton3.Checked = True Then
                            Parking = 0
                        End If

                        NetPay = GrossPay - (GrossPay * TaxRate) - Parking

                        'dispaly output

                        RichTextBox1.Text = "Weekly Pay Report" & vbCrLf &
                                            "for " & UserName & vbCrLf &
                                            "Gross Pay: " & Format(GrossPay, "$0.00") & vbCrLf &
                                            "Taxes: " & TaxRate & vbCrLf &
                                            "Parking: " & Format(Parking, "$0.00") & vbCrLf &
                                            "Net Pay: " & Format(NetPay, "$0.00")

                    Else
                        MsgBox("Please choose a parking type")
                    End If 'end radiobutton error condition
                Else
                    MsgBox("Please input hours worked")
                End If 'end hours worked error condition
            Else
                MsgBox("Please input hourly pay")
            End If 'end hourly pay error condition
        Else
            MsgBox("Please enter a name")
        End If 'end username  error condition

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class
