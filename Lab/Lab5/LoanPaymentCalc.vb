Public Class Form1
    Public LoanAmount As Double = 0
    Public AnnualIntrestRate As Double = 0
    Public Years As Double = 0
    Public Payment As Double = 0
    Public MonthlyRate As Double = 0
    Public NumOfPayments As Double = 0
    Public InterestPayment As Double = 0
    Public PrinciplaPayment As Double = 0
    Public Balance As Double = 0
    Public CurrentPaymentNumber As Double
    Public Message As String


    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        'payment button

        LoanAmount = txtLoanAmt.Text
        AnnualIntrestRate = txtAnnualIntrestRate.Text
        Years = txtYears.Text

        NumOfPayments = Years * 12 'years to months
        MonthlyRate = AnnualIntrestRate / (12 * 100) ' convert to percentage

        'formula for monthly payments
        Payment = LoanAmount * MonthlyRate / (1 - (1 + MonthlyRate) ^ (-NumOfPayments))

        'display payment resutl
        txtPayment.Enabled = True
        txtPayment.Text = Format(Payment, "##.00")
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'end button
        End
    End Sub

    Private Sub btnAmortize_Click(sender As Object, e As EventArgs) Handles btnAmortize.Click
        'Amortize Button

        'initialize balance
        Balance = LoanAmount

        'preparing message
        Message = "Payment" & vbTab & "Total" & vbTab & "Interest" & vbTab & "Principal" & vbTab & "Balance" & vbCrLf &
                  "Number" & vbTab & "Payment" & vbTab & "Payment" & vbTab & "Payment"

        CurrentPaymentNumber = 1
        Do
            'calcualting monthly payments for each month
            InterestPayment = (AnnualIntrestRate / (12 * 100)) * Balance
            PrinciplaPayment = Payment - InterestPayment
            Balance = Balance - PrinciplaPayment

            'message for each month
            Message = Message & vbCrLf & CurrentPaymentNumber & vbTab & Format(Payment, "0.00") & vbTab & Format(InterestPayment, "0.00") & vbTab &
                      Format(PrinciplaPayment, "0.00") & vbTab & Format(Balance, "0.00")
            CurrentPaymentNumber = CurrentPaymentNumber + 1
        Loop While (CurrentPaymentNumber <= NumOfPayments)

        'output final message
        txtSchedule.Text = Message
    End Sub
End Class
