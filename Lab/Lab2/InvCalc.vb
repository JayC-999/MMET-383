Public Class Form1
    Private InvGoal As Decimal
    Private TerminYears As Integer
    Private GrowthRate As Decimal
    Private InInvestment As Decimal
    Private NumofInvestments As Integer
    Private TotalinInvestments As Decimal
    Private InvesterName As String


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NumofInvestments = 0
        TotalinInvestments = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Calculate

        GrowthRate = (TextBox4.Text)
        InvGoal = (TextBox2.Text)
        TerminYears = (TextBox3.Text)


        GrowthRate = GrowthRate / 100
        InInvestment = (InvGoal) / (1 + GrowthRate) ^ TerminYears
        NumofInvestments = NumofInvestments + 1
        TotalinInvestments = TotalinInvestments + InInvestment

        TextBox5.Text = Format(InInvestment, "$0.00")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Clear

        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Club Summary

        Label6.Visible = True
        Label7.Visible = True
        Label8.Visible = True
        Label9.Visible = True
        Label9.Text = TextBox1.Text
        TextBox6.Visible = True
        TextBox7.Visible = True


        TextBox6.Text = CStr(NumofInvestments)
        TextBox7.Text = Format(TotalinInvestments, "$0.00")


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'New Investor 

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        TextBox6.Visible = False
        TextBox7.Visible = False
    End Sub
End Class
