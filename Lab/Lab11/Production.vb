Public Class Production
    Public CurrentPro As String
    Private Sub Production_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'production form

        Call LoadProduction()
    End Sub

    Private Sub btnFIrstz_Click(sender As Object, e As EventArgs) Handles btnFIrstz.Click
        'first record

        Call zDisplay(0)
    End Sub

    Private Sub btnLstRecz_Click(sender As Object, e As EventArgs) Handles btnLstRecz.Click
        'last record

        Call zDisplay(TotalInProduction - 1)
    End Sub

    Private Sub btnNxtz_Click(sender As Object, e As EventArgs) Handles btnNxtz.Click
        'next button

        CurrentPro = txtProdz.Text

        Call zFindName(CurrentPro)

        'this moves to the previous index within the array and shows the desired info
        If ProductionNameFound = TotalInProduction - 1 Then
            ProductionNameFound = 0
        Else
            ProductionNameFound = ProductionNameFound + 1
        End If

        'display info
        Call zDisplay(ProductionNameFound)
    End Sub

    Private Sub btnPreviousz_Click(sender As Object, e As EventArgs) Handles btnPreviousz.Click
        'previous record

        CurrentPro = txtProdz.Text

        Call zFindName(CurrentPro)

        'this moves to the previous index within the array and shows the desired info
        If ProductionNameFound = 0 Then
            ProductionNameFound = TotalInProduction - 1
        Else
            ProductionNameFound = ProductionNameFound - 1
        End If

        'display info
        Call zDisplay(ProductionNameFound)
    End Sub

    Private Sub btnFindz_Click(sender As Object, e As EventArgs) Handles btnFindz.Click
        'find button

        'userinput is a string when input is given
        Dim UserInput As String = InputBox("Enter the product name you are seeking", "Find Product Name")

        Call zFindName(UserInput)

        If ProductionNameFound = -1 Then
            MsgBox("Product not found")
        Else
            Call zDisplay(ProductionNameFound)
        End If
    End Sub

    Private Sub btnAddz_Click(sender As Object, e As EventArgs) Handles btnAddz.Click
        'add button

        If btnAddz.Text = "Add" Then
            'clearing text boxes so user can input new product and quantity
            Call zDisable()
            btnAddz.Enabled = True
            btnAddz.Text = "Save"
            txtProdz.Text = ""
            txtQuant.Text = ""

        Else

            'this appends to the array with the user input.
            ProductionName = ProductionName.Concat({txtProdz.Text}).ToArray
            ProductionNumber = ProductionNumber.Concat({txtQuant.Text}).ToArray

            'adding total elements in the array and calling respective fnctions to save new input data
            TotalInProduction = TotalInProduction + 1
            Call zSave(TotalInProduction)
            Call Production_Load(sender, e)
            Call zAble()

            btnAddz.Text = "Add"

        End If
    End Sub

    Private Sub btnDeletez_Click(sender As Object, e As EventArgs) Handles btnDeletez.Click
        'delete button

        CurrentPro = txtProdz.Text

        Call zFindName(CurrentPro)

        Call zSave(ProductionNameFound)
        Call Production_Load(sender, e)

        txtProdz.Text = ""
        txtQuant.Text = ""
        MsgBox("Information deleted")
    End Sub

    Private Sub btnModz_Click(sender As Object, e As EventArgs) Handles btnModz.Click
        'modify button


        CurrentPro = txtProdz.Text

        Call zFindName(CurrentPro)

        If btnModz.Text = "Modify" Then
            Call zDisable()
            btnModz.Enabled = True
            btnModz.Text = "Save"
        Else
            'modifying info given the current index and user input
            ProductionName(ProductionNameFound) = txtProdz.Text
            ProductionNumber(ProductionNameFound) = txtQuant.Text

            TotalInProduction = TotalInProduction

            'calling respective functions to save new input data
            Call zSave(TotalInProduction)
            Call Production_Load(sender, e)
            Call zAble()

            MsgBox("Information has been modified")
            btnAddz.Enabled = True
            btnModz.Text = "Modify"
        End If
    End Sub

    Private Sub btnBackz_Click(sender As Object, e As EventArgs) Handles btnBackz.Click
        'back button

        Me.Close()
        LogIn.Show()
        LogIn.txtCode.Text = ""
    End Sub

    Private Sub btnExitz_Click(sender As Object, e As EventArgs) Handles btnExitz.Click
        'exit 

        Me.Close()
        End
    End Sub
End Class