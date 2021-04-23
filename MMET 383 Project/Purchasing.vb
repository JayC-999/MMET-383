Public Class Purchasing
    Public TotalNumOfParts(), PurchaseNumber(), PurchaseTotalCost() As Integer
    Public TypeOfPart(), BoughtFrom(), MadePurchase() As String
    Public TempTotalNumOfParts, TempPurchaseNumber, TempTotalCost, TempTypeOfPart, TempBoughtFrom, TempMadePurchase As String
    Public PurchasingTotalInArray, j, PurchaseCurrentIndex, PurchaseTempIndex, CheckPurchaseNumber As Integer
    Public PurchaseNumberIndex, TotNumPurchasingDataset As Integer
    Public TypeName As String
    Public TotalPurchase As Integer



    Private Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Me.Close()
        Management.Show()

    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'exit button

        Me.Close()
        End
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'delete purchase button

        PurchasingBindingSource.RemoveCurrent()
        PurchasingTableAdapter.Update(Me.PurchasingDataDataSet)
        MsgBox("Information deleted")

        'overall, find the ordernumber to delete
        'once found call updatesalesfile which will write all information from arrays except the deleted ordernumber and its inforamtion
        'PurchaseTempIndex = txtPurchaseNumber.Text

        'Call FindPurchaseNumber(PurchaseTempIndex)

        'Call UpdatePurchasingFile(PurchaseCurrentIndex)
        'Call Purchasing_Load(sender, e)

        'Call ClearTxtBoxes()
        'MsgBox("Inforamtion deleted")
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        'modify purchase button


        If btnModify.Text = "Modify Purchase" Then
            Call DisableButtons()
            btnModify.Enabled = True
            btnExit.Enabled = True
            btnModify.Text = "Save"
        Else
            'update modified access file; file name purchase data
            Validate()
            PurchasingBindingSource.EndEdit()
            PurchasingTableAdapter.Update(Me.PurchasingDataDataSet)
            Call EnableButtons()
            MsgBox("Information modified")
            btnModify.Text = "Modify Purchase"
        End If
        'PurchaseTempIndex = txtPurchaseNumber.Text

        'Call FindPurchaseNumber(PurchaseTempIndex)

        ''changing modify button to say save and dislabe buttons
        'If btnModify.Text = "Modify Purchase" Then
        '    Call DisableButtons()
        '    btnModify.Enabled = True
        '    btnModify.Text = "Save"
        'Else
        '    'modifying information from the user given the index called from findordernumber

        '    If Not IsNumeric(txtPurchaseNumber.Text) Or Not IsNumeric(txtTotalParts.Text) Or Not IsNumeric(txtTotalCost.Text) Then
        '        MsgBox("Please make sure Purchase Number, Total Parts, and Total Cost are numeric values")
        '    Else

        '        PurchaseNumber(PurchaseCurrentIndex) = txtPurchaseNumber.Text
        '        TotalNumOfParts(PurchaseCurrentIndex) = CInt(txtTotalParts.Text)
        '        TypeOfPart(PurchaseCurrentIndex) = txtTypeOfPart.Text
        '        PurchaseTotalCost(PurchaseCurrentIndex) = CInt(txtTotalCost.Text)
        '        BoughtFrom(PurchaseCurrentIndex) = txtBoughtFrom.Text
        '        MadePurchase(PurchaseCurrentIndex) = txtMadePurchase.Text

        '        'totalinarray does not change
        '        PurchasingTotalInArray = PurchasingTotalInArray

        '        'calling respective function to save modified information
        '        Call UpdatePurchasingFile(PurchasingTotalInArray)
        '        Call Purchasing_Load(sender, e)
        '        Call EnableButtons()

        '        'let user know info was modified
        '        MsgBox("Information has been modified")
        '        'btnModify.Enabled = True
        '        btnModify.Text = "Modify Purchase"
        '    End If
        'End If
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'add purchase order button

        If btnAdd.Text = "Add Purchase" Then
            Me.PurchasingBindingSource.AddNew()
            Call ClearTxtBoxes()
            Call DisableButtons()
            btnAdd.Enabled = True
            btnExit.Enabled = True
            btnAdd.Text = "Save"
            'Me.PurchasingBindingSource.AddNew()
        Else

            PurchInventoryName = txtTypeOfPart.Text
            PurchUserEntry = txtTotalParts.Text
            Select Case PurchInventoryName
                Case "Pressure sensor"
                    PurchTotalPressure = PurchUserEntry
                            'InventoryName = "Pressure sensor"

                Case "Temperature sensor"
                    PurchTotalTemp = PurchUserEntry


                Case "Optical sensor"
                    PurchTotalOptic = PurchUserEntry

                Case "Limit switches"
                    PurchTotalLimitSwitch = PurchUserEntry

                Case "Human-machine interface"
                    PurchTotalHMI = PurchUserEntry

                Case "Proximity sensor"
                    PurchTotalProxi = PurchUserEntry

            End Select
            Me.PurchasingBindingSource.EndEdit()
            Me.PurchasingTableAdapter.Update(Me.PurchasingDataDataSet)
            TotNumPurchasingDataset = TotNumPurchasingDataset + 1
            Call EnableButtons()
            MsgBox("Information added")
            btnAdd.Text = "Add Purchase"

        End If



        'if statment when user selects add purchase order:
        'if the user selects add order before any information is shown in the text box, first if statement executes
        'elseif if the text boxes show information execute elseif statment
        'else update the last element in the given array's with the user input
        'If btnAdd.Text = "Add Purchase" And String.IsNullOrEmpty(txtPurchaseNumber.Text) Then
        '    Call Enable()
        '    Call DisableButtons()
        '    btnAdd.Enabled = True
        '    btnExit.Enabled = True
        '    btnAdd.Text = "Save"
        '    'this updates the length of the array's by 1
        '    ReDim Preserve PurchaseNumber(UBound(PurchaseNumber) + 1)
        '    ReDim Preserve TotalNumOfParts(UBound(TotalNumOfParts) + 1)
        '    ReDim Preserve TypeOfPart(UBound(TypeOfPart) + 1)
        '    ReDim Preserve PurchaseTotalCost(UBound(PurchaseTotalCost) + 1)
        '    ReDim Preserve BoughtFrom(UBound(BoughtFrom) + 1)
        '    ReDim Preserve MadePurchase(UBound(MadePurchase) + 1)

        'ElseIf Not String.IsNullOrEmpty(txtPurchaseNumber.Text) And btnAdd.Text = "Add Purchase" Then
        '    Call ClearTxtBoxes()
        '    Call DisableButtons()
        '    btnAdd.Enabled = True
        '    btnExit.Enabled = True
        '    btnAdd.Text = "Save"
        '    ReDim Preserve PurchaseNumber(UBound(PurchaseNumber) + 1)
        '    ReDim Preserve TotalNumOfParts(UBound(TotalNumOfParts) + 1)
        '    ReDim Preserve TypeOfPart(UBound(TypeOfPart) + 1)
        '    ReDim Preserve PurchaseTotalCost(UBound(PurchaseTotalCost) + 1)
        '    ReDim Preserve BoughtFrom(UBound(BoughtFrom) + 1)
        '    ReDim Preserve MadePurchase(UBound(MadePurchase) + 1)
        'Else

        '    If Not IsNumeric(txtPurchaseNumber.Text) Or Not IsNumeric(txtTotalParts.Text) Or Not IsNumeric(txtTotalCost.Text) Then
        '        MsgBox("Please make sure Purchase Number, Total Parts, and Total Cost are numeric values")

        '    ElseIf IsNumeric(txtPurchaseNumber.Text) Or IsNumeric(txtTotalParts.Text) Or IsNumeric(txtTotalCost.Text) Then
        '        If txtPurchaseNumber.Text < 0 Or txtTotalParts.Text < 0 Or txtTotalCost.Text < 0 Then
        '            MsgBox("Please make sure Purchse Number, Total Parts, and Total Cost are greater than zero")
        '        Else
        '            'update last element in array's with user input
        '            PurchaseNumber(UBound(PurchaseNumber)) = CInt(txtPurchaseNumber.Text)
        '            TotalNumOfParts(UBound(TotalNumOfParts)) = CInt(txtTotalParts.Text)
        '            TypeOfPart(UBound(TypeOfPart)) = txtTypeOfPart.Text
        '            PurchaseTotalCost(UBound(PurchaseTotalCost)) = CInt(txtTotalCost.Text)
        '            BoughtFrom(UBound(BoughtFrom)) = txtBoughtFrom.Text
        '            MadePurchase(UBound(MadePurchase)) = txtMadePurchase.Text

        '            CheckPurchaseNumber = PurchaseNumber(UBound(PurchaseNumber))

        '            Call DuplicatePurchaseNumber(CheckPurchaseNumber)

        '            If CheckPurchaseNumber = -1 Then
        '                MsgBox("Purchase number already exsits. Please choose a different purchase number")
        '            Else
        '                'update totalinarry and call respective functions
        '                PurchasingTotalInArray = PurchasingTotalInArray + 1
        '                Call UpdatePurchasingFile(PurchasingTotalInArray)
        '                Call Purchasing_Load(sender, e)
        '                Call EnableButtons()
        '                btnAdd.Text = "Add Purchase"

        '            End If 'end if for duplicate pruchase number
        '        End If 'end if for negative numbers
        '    End If 'end if for error
        'End If 'end if for overall if statment
    End Sub



    Private Sub btnPreviousPurchaseOrder_Click(sender As Object, e As EventArgs) Handles btnPreviousPurchaseOrder.Click
        'Previous purchase order button

        PurchasingBindingSource.MovePrevious()
        'PurchaseTempIndex = txtPurchaseNumber.Text

        'Call FindPurchaseNumber(PurchaseTempIndex)

        ''this moves to the previous index within the array and shows the desired info
        'If PurchaseCurrentIndex = 0 Then
        '    PurchaseCurrentIndex = PurchasingTotalInArray - 1
        'Else
        '    PurchaseCurrentIndex = PurchaseCurrentIndex - 1
        'End If
        ''displays info
        'Call xDisplay(PurchaseCurrentIndex)
    End Sub


    Private Sub btnLastPurchaseOrder_Click(sender As Object, e As EventArgs) Handles btnLastPurchaseOrder.Click
        'last purchase button

        PurchasingBindingSource.MoveLast()
        'show last pruchase order info in all array's
        'enable all buttons the manager has authority over
        'show next and previous buttons
        'Call xDisplay(PurchasingTotalInArray - 1)
        'Call Enable()
        'btnPreviousPurchaseOrder.Visible = True
        'btnNxtPurchaseOrder.Visible = True

    End Sub



    Private Sub btnFirstPurchase_Click(sender As Object, e As EventArgs) Handles btnFirstPurchase.Click
        'first purchase button

        PurchasingBindingSource.MoveFirst()



        ''show first pruchase order info in all array's
        ''enable all buttons the manager has authority over
        ''show next and previous buttons
        'Call xDisplay(0)
        'Call Enable()
        'btnPreviousPurchaseOrder.Visible = True
        'btnNxtPurchaseOrder.Visible = True
    End Sub

    Private Sub btnNxtPurchaseOrder_Click(sender As Object, e As EventArgs) Handles btnNxtPurchaseOrder.Click
        'next purchase order button

        PurchasingBindingSource.MoveNext()
        'PurchaseTempIndex = txtPurchaseNumber.Text

        'Call FindPurchaseNumber(PurchaseTempIndex)

        ''this moves to the next index within the array and shows the desired info
        'If PurchaseCurrentIndex = PurchasingTotalInArray - 1 Then
        '    PurchaseCurrentIndex = 0
        'Else
        '    PurchaseCurrentIndex = PurchaseCurrentIndex + 1
        'End If

        ''displays info
        'Call xDisplay(PurchaseCurrentIndex)
    End Sub


    Private Sub btnGoToLogin_Click(sender As Object, e As EventArgs) Handles btnGoToLogin.Click
        'go to Login button

        Me.Close()
        LogIn.Show()
        LogIn.txtPw.Text = ""
    End Sub


    Private Sub btnPurchase_Click(sender As Object, e As EventArgs) Handles btnPurchase.Click
        'purchase number button


        Dim UserInput As String = InputBox("Enter purchase number", "Purchase number")
        Dim i As Integer



        Dim Exsits As Boolean = False

        'for loop to find matching userinput; if not found CurrentIndex 
        For i = 0 To TotNumPurchasingDataset
            PurchasingBindingSource.Position = i

            If txtPurchaseNumber.Text = UserInput Then
                PurchasingBindingSource.Position = i
                Exsits = True
                Exit Sub
            End If
        Next i

        If Exsits = False Then
            MsgBox("Purchase number does not exist")
            PurchasingBindingSource.MoveFirst()
            Exit Sub
        End If

        'Call FindPurchaseNumber(UserInput)

        'If PurchaseCurrentIndex = -1 Then
        '    MsgBox("Purchase number does not exist")
        'Else
        '    Call xDisplay(PurchaseCurrentIndex)
        '    Call Enable()
        'End If
    End Sub

    Private Sub Purchasing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PurchasingDataDataSet.Purchasing' table. You can move, or remove it, as needed.
        Me.PurchasingTableAdapter.Fill(Me.PurchasingDataDataSet.Purchasing)
        TotNumPurchasingDataset = PurchasingDataDataSet.Purchasing.Count

        'purchasing load form

        'j = 0
        'FileOpen(2, "Purchasing Data.csv", OpenMode.Input)

        'Input(2, TempPurchaseNumber)
        'Input(2, TempTotalNumOfParts)
        'Input(2, TempTypeOfPart)
        'Input(2, TempTotalCost)
        'Input(2, TempBoughtFrom)
        'Input(2, TempMadePurchase)

        'Do Until EOF(2)
        '    ReDim Preserve PurchaseNumber(0 To j)
        '    ReDim Preserve TotalNumOfParts(0 To j)
        '    ReDim Preserve TypeOfPart(0 To j)
        '    ReDim Preserve PurchaseTotalCost(0 To j)
        '    ReDim Preserve BoughtFrom(0 To j)
        '    ReDim Preserve MadePurchase(0 To j)

        '    Input(2, PurchaseNumber(j))
        '    Input(2, TotalNumOfParts(j))
        '    Input(2, TypeOfPart(j))
        '    Input(2, PurchaseTotalCost(j))
        '    Input(2, BoughtFrom(j))
        '    Input(2, MadePurchase(j))
        '    j = j + 1

        'Loop
        'PurchasingTotalInArray = j
        'FileClose(2)

    End Sub
End Class