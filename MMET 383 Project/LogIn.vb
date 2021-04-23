Public Class LogIn
    Private PwSales, PwInventory, PwManagement, PwPurchasing, PwProduction, PwMaitenance As String

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        Me.Hide()
        ProductImg.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'exit button

        'end program
        Me.Close()
        End
    End Sub

    Private Sub btnCheckIn_Click(sender As Object, e As EventArgs) Handles btnCheckIn.Click
        'Checkin button
        ProductImg.Close()
        'this handles an error if nothing is selected in the list box and there is no password input
        If lstDivision.SelectedItem Is Nothing And txtPw.Text = "" Then
            MsgBox("Please select a division and enter a password")
        Else
            'go to form number if passowrd is right else wrong password; for all cases
            Select Case lstDivision.Text
                Case "Inventory"
                    If txtPw.Text = PwInventory Then
                        Me.Hide()
                        Inventory.Show()

                    Else
                        MsgBox("Incorrect password")
                    End If
                Case "Sales"
                    If txtPw.Text = PwSales Then
                        Me.Hide()
                        Sales.Show()
                        Sales.btnGoBack.Visible = False
                        Sales.btnExit.Visible = True
                    Else
                        MsgBox("Incorrect password")
                    End If
                Case "Management"
                    If txtPw.Text = PwManagement Then
                        Me.Hide()
                        Management.Show()
                        'prompt manager to select a division once they're in their form
                        MsgBox("Please select a division to work with")
                    Else
                        MsgBox("Incorrect password")
                    End If
                Case "Purchasing"
                    If txtPw.Text = PwPurchasing Then
                        Me.Hide()
                        Purchasing.Show()
                        Purchasing.btnExit.Visible = True
                    Else
                        MsgBox("Incorrect password")
                    End If
                Case "Production"
                    If txtPw.Text = PwProduction Then
                        Me.Hide()
                        Production.Show()
                        'show user info when user is viewing production
                        Call ShowUserInfoProduction()
                    Else
                        MsgBox("Incorrect password")
                    End If
                Case "Maintenance"
                    If txtPw.Text = PwMaitenance Then
                        Me.Hide()
                        Maintenance.Show()
                    Else
                        MsgBox("Incorrect password")
                    End If
            End Select
        End If
    End Sub

    Private Sub LogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'login form load

        'allows multiple add items
        lstDivision.Items.AddRange({"Inventory", "Sales", "Management", "Purchasing", "Production", "Maintenance"})

        'setting up passwords for each division
        PwInventory = "1"
        PwSales = "2"
        PwManagement = "3"
        PwPurchasing = "4"
        PwProduction = "5"
        PwMaitenance = "6"

    End Sub
End Class
