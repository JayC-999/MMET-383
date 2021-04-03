Public Class LogIn
    Private PassWordInventory As String
    Private PassWordSales As String
    Private PassWordProduction As String

    Private Sub LogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'form LogIn

        lstDivison.Items.Add("Inventory")
        lstDivison.Items.Add("Sales")
        lstDivison.Items.Add("Production")

        PassWordInventory = "123"
        PassWordSales = "456"
        PassWordProduction = "789"

    End Sub

    Private Sub btnCheckIn_Click(sender As Object, e As EventArgs) Handles btnCheckIn.Click
        'CheckIn button

        'case for division list. if password is correct for the selected division then proceed to corresponding form
        'else worng password
        Select Case lstDivison.Text
            Case "Inventory"
                If txtCode.Text = PassWordInventory Then
                    Me.Hide()
                    Inventory.Show()
                Else
                    MsgBox("Incorrect Password")
                End If 'for inventory

            Case "Sales"
                If txtCode.Text = PassWordSales Then
                    Me.Hide()
                    Sales.Show()
                Else
                    MsgBox("Inccorect Password")
                End If 'for sales
            Case "Production"
                If txtCode.Text = PassWordProduction Then
                    Me.Hide()
                    Production.Show()
                Else
                    MsgBox("Incorrect Password")
                End If 'for production
        End Select
    End Sub
End Class
