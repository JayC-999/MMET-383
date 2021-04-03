Public Class Sales
    Public CurrentProd As String
    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'form sales

        Call LoadSales()
    End Sub

    Private Sub btnFstRecordx_Click(sender As Object, e As EventArgs) Handles btnFstRecordx.Click
        'first record

        Call xDisplay(0)
    End Sub

    Private Sub btnLstRecordx_Click(sender As Object, e As EventArgs) Handles btnLstRecordx.Click
        'last record

        Call xDisplay(TotalInSales - 1)
    End Sub

    Private Sub btnNxtRecordx_Click(sender As Object, e As EventArgs) Handles btnNxtRecordx.Click
        'next record

        CurrentProd = txtProductx.Text

        Call xFindName(CurrentProd)

        'this moves to the previous index within the array and shows the desired info
        If SalesNameFound = TotalInSales - 1 Then
            SalesNameFound = 0
        Else
            SalesNameFound = SalesNameFound + 1
        End If

        'display info
        Call xDisplay(SalesNameFound)
    End Sub

    Private Sub btnPreRecordx_Click(sender As Object, e As EventArgs) Handles btnPreRecordx.Click
        'previous button

        CurrentProd = txtProductx.Text

        Call xFindName(CurrentProd)

        'this moves to the previous index within the array and shows the desired info
        If SalesNameFound = 0 Then
            SalesNameFound = TotalInSales - 1
        Else
            SalesNameFound = SalesNameFound - 1
        End If

        'display info
        Call xDisplay(SalesNameFound)
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'find button

        'userinput is a string when input is given
        Dim UserInput As String = InputBox("Enter the product name you are seeking", "Find Product Name")

        Call xFindName(UserInput)

        If SalesNameFound = -1 Then
            MsgBox("Product not found")
        Else
            Call xDisplay(SalesNameFound)
        End If
    End Sub

    Private Sub btnAddx_Click(sender As Object, e As EventArgs) Handles btnAddx.Click
        'add button

        If btnAddx.Text = "Add" Then
            'clearing text boxes so user can input new product and quantity
            Call xDisable()
            btnAddx.Enabled = True
            btnAddx.Text = "Save"
            txtProductx.Text = ""
            txtQuantity.Text = ""

        Else

            'this appends to the array with the user input.
            SalesName = SalesName.Concat({txtProductx.Text}).ToArray
            SalesNumber = SalesNumber.Concat({txtQuantity.Text}).ToArray

            'adding total elements in the array and calling respective fnctions to save new input data
            TotalInSales = TotalInSales + 1
            Call xSave(TotalInSales)
            Call Sales_Load(sender, e)
            Call xAble()

            btnAddx.Text = "Add"

        End If
    End Sub

    Private Sub btnDeletex_Click(sender As Object, e As EventArgs) Handles btnDeletex.Click
        'delete button


        CurrentProd = txtProductx.Text

        Call xFindName(CurrentProd)

        Call xSave(SalesNameFound)
        Call Sales_Load(sender, e)

        txtProductx.Text = ""
        txtQuantity.Text = ""
        MsgBox("Information deleted")
    End Sub

    Private Sub btnModx_Click(sender As Object, e As EventArgs) Handles btnModx.Click
        'modify button

        CurrentProd = txtProductx.Text

        Call xFindName(CurrentProd)

        If btnModx.Text = "Modify" Then
            Call xDisable()
            btnModx.Enabled = True
            btnModx.Text = "Save"
        Else
            'modifying info given the current index and user input
            SalesName(SalesNameFound) = txtProductx.Text
            SalesNumber(SalesNameFound) = txtQuantity.Text

            TotalInSales = TotalInSales

            'calling respective functions to save new input data
            Call xSave(TotalInSales)
            Call Sales_Load(sender, e)
            Call xAble()

            MsgBox("Information has been modified")
            btnAddx.Enabled = True
            btnModx.Text = "Modify"
        End If
    End Sub

    Private Sub btnBackx_Click(sender As Object, e As EventArgs) Handles btnBackx.Click
        'back button

        Me.Close()
        LogIn.Show()
        LogIn.txtCode.Text = ""
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        'exit button

        Me.Close()
        End
    End Sub
End Class