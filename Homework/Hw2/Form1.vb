Public Class Form1
    Private LargeCookie As Decimal
    Private RegularCookie As Decimal
    Private Price As Decimal
    Private Tax As Decimal
    Private Shipping As Decimal
    Private Total As Decimal
    Private OunceToPound As Decimal
    Private Sum As Decimal
    Private WeightInOunce As Decimal
    Private Remainder As Decimal



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Calculate Button

        LargeCookie = TextBox1.Text
        RegularCookie = TextBox2.Text

        Price = ((LargeCookie * 95) + (RegularCookie * 50)) / 100
        Tax = (Price * 5) / 100
        Sum = Price + Tax

        TextBox3.Text = Math.Truncate(Sum * 100) / 100 'this removes unwanted numbers after two decmial places so we don't round second decmial place

        WeightInOunce = (LargeCookie * 11) + (RegularCookie * 6) 'number is an ounces
        Remainder = WeightInOunce Mod 16

        'this condition checks to see if there is a remainder or not and then does computation
        If Remainder = 0 Then
            OunceToPound = WeightInOunce / 16 'converts ounces to pound
            Shipping = OunceToPound
            Total = Shipping + Sum

            TextBox3.Text = Math.Truncate(Sum * 100) / 100
            TextBox4.Text = Math.Truncate(Shipping * 100) / 100
            TextBox5.Text = Math.Truncate(Total * 100) / 100

        Else
            OunceToPound = (WeightInOunce - Remainder) / 16 'converts ounce to pound minus the remainder 
            Remainder = (Remainder * 0.1) + OunceToPound
            Shipping = Remainder
            Total = Shipping + Sum

            TextBox3.Text = Math.Truncate(Sum * 100) / 100
            TextBox4.Text = Math.Truncate(Shipping * 100) / 100
            TextBox5.Text = Math.Truncate(Total * 100) / 100

        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Clear Button

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Exit button

        End
    End Sub


End Class
