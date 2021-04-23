Public Class Management
    Private Sub Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'form management load

        lstDivision.Items.AddRange({"Inventory", "Sales", "Purchasing", "Production", "Maintenance"})
    End Sub

    Private Sub btnDivision_Click(sender As Object, e As EventArgs) Handles btnDivision.Click


        'go to form the manager chooses; for all cases
        Select Case lstDivision.Text
            Case "Sales"
                Me.Close()
                Sales.Show()
                Call ShowButtons()
                'hiding previous and next order button until information is filled in the sales textbox
                Sales.btnPrevious.Visible = False
                Sales.btnNxtOrder.Visible = False
            Case "Inventory"
                Me.Close()
                Inventory.Show()
                'show manager options when in manager view; not user view
                Call ShowSelectInventory()
                Inventory.btnGoBack.Visible = True
                'CallTest()
                'Inventory.txtQty.ReadOnly = True
                'Inventory.Label5.Visible = False
            Case "Purchasing"
                Me.Close()
                Purchasing.Show()
                'show manager options when in manager view; not user view
                Inventory.btnGoBack.Visible = True
                Purchasing.txtInstruction.Visible = True
                Purchasing.txtInstruction.Text = "Manager, Please make sure that Purchasing Number, Total Cost, and Total Number of Parts are numeric values"
                Call ShowButtons()
                Call ReadOnlyEnabledPurchasing()

            Case "Production"
                Me.Close()
                Production.Show()
                'show manager options when in manager view; not user view
                Call ShowSelectProduction()
            Case "Maintenance"
                Me.Close()
                Maintenance.Show()
                ShowSelectMaintenace()
        End Select
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'exit button

        Me.Close()
        End
    End Sub

    Private Sub btnSummary_Click(sender As Object, e As EventArgs) Handles btnSummary.Click
        Me.Close()
        MgrSummary.Show()
        Call Test()
    End Sub
End Class