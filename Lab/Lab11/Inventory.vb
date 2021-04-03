Public Class Inventory
    Public CurrentProduct As String


    Private Sub btnNxtRecord_Click(sender As Object, e As EventArgs) Handles btnNxtRecord.Click
        'next button

        CurrentProduct = txtProdName.Text

        Call FindName(CurrentProduct)

        'this moves to the nest index within the array and shows the desired info
        If NameFound = TotalInInvetory - 1 Then
            NameFound = 0
        Else
            NameFound = NameFound + 1
        End If

        'dispaly info
        Call Display(NameFound)

    End Sub

    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'form inventory

        Call LoadInventory()
    End Sub

    Private Sub btnFstRecord_Click(sender As Object, e As EventArgs) Handles btnFstRecord.Click
        'first record

        'call function
        Call Display(0)
    End Sub

    Private Sub btnLstRecord_Click(sender As Object, e As EventArgs) Handles btnLstRecord.Click
        'last record

        'call function
        Call Display(TotalInInvetory - 1)

    End Sub

    Private Sub btnName_Click(sender As Object, e As EventArgs) Handles btnName.Click
        'find name

        'userinput is a string when input is given
        Dim UserInput As String = InputBox("Enter the product name you are seeking", "Find Product Name")

        Call FindName(UserInput)

        If NameFound = -1 Then
            MsgBox("Product not found")
        Else
            Call Display(NameFound)
        End If

    End Sub

    Private Sub btnPreRecord_Click(sender As Object, e As EventArgs) Handles btnPreRecord.Click
        'previous button

        CurrentProduct = txtProdName.Text

        Call FindName(CurrentProduct)

        'this moves to the previous index within the array and shows the desired info
        If NameFound = 0 Then
            NameFound = TotalInInvetory - 1
        Else
            NameFound = NameFound - 1
        End If

        'display info
        Call Display(NameFound)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'add button

        If btnAdd.Text = "Add" Then
            'clearing text boxes so user can input new product and quantity
            Call Disable()
            btnAdd.Enabled = True
            btnAdd.Text = "Save"
            txtProdName.Text = ""
            txtQty.Text = ""

        Else

            'this appends to the array with the user input.
            InventoryName = InventoryName.Concat({txtProdName.Text}).ToArray
            InventoryNumber = InventoryNumber.Concat({txtQty.Text}).ToArray

            'adding total elements in the array and calling respective fnctions to save new input data
            TotalInInvetory = TotalInInvetory + 1
            Call Save(TotalInInvetory)
            Call Inventory_Load(sender, e)
            Call Able()

            btnAdd.Text = "Add"

        End If

    End Sub

    Private Sub btnMod_Click(sender As Object, e As EventArgs) Handles btnMod.Click
        'modify button

        CurrentProduct = txtProdName.Text

        Call FindName(CurrentProduct)

        If btnMod.Text = "Modify" Then
            Call Disable()
            btnMod.Enabled = True
            btnMod.Text = "Save"
        Else
            'modifying info given the current index and user input
            InventoryName(NameFound) = txtProdName.Text
            InventoryNumber(NameFound) = txtQty.Text

            TotalInInvetory = TotalInInvetory

            'calling respective functions to save new input data
            Call Save(TotalInInvetory)
            Call Inventory_Load(sender, e)
            Call Able()

            MsgBox("Information has been modified")
            btnAdd.Enabled = True
            btnMod.Text = "Modify"
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Delete button

        CurrentProduct = txtProdName.Text

        Call FindName(CurrentProduct)

        Call Save(NameFound)
        Call Inventory_Load(sender, e)

        txtProdName.Text = ""
        txtQty.Text = ""
        MsgBox("Information deleted")
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'end button

        Me.Close()
        End
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'back button

        Me.Close()
        LogIn.Show()

        LogIn.txtCode.Text = ""
    End Sub
End Class