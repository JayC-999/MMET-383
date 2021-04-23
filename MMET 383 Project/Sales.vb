Public Class Sales
    Public OrderNumber(), TypeOfParts(), SoldBy(), SoldTo() As String
    Public TempOrderNum, TempTypeOfParts, TempSoldBy, TempSoldTo, TempTotalNumber, TempTotalCost, TempIndex, CheckOrderNumber As String
    Public TotalNumberOfParts(), TotalCost() As Integer
    Public SalesTotalInArray, CurrentIndex As Integer


    Private Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Me.Close()
        Management.Show()
    End Sub

    Private i, k As Integer
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'exit button
        'msg 
        Me.Close()
        End
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'delete order button

        'overall, find the ordernumber to delete
        'once found call updatesalesfile which will write all information from arrays except the deleted ordernumber and its inforamtion
        TempIndex = txtOrderNum.Text

        Call FindOrderNumber(TempIndex)

        Call UpdateSalesFile(CurrentIndex)
        Call Sales_Load(sender, e)

        Call ClearTxtBoxes()
        MsgBox("Inforamtion deleted")
    End Sub



    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        'modify order button

        TempIndex = txtOrderNum.Text

        Call FindOrderNumber(TempIndex)

        'changing modify button to say save and dislabe buttons
        If btnModify.Text = "Modify Order" Then
            Call DisableButtons()
            btnModify.Enabled = True
            btnModify.Text = "Save"
        Else
            'modifying information from the user given the index called from findordernumber

            If Not IsNumeric(txtTotalNumberOfParts.Text) Or Not IsNumeric(txtTotalCost.Text) Then
                MsgBox("Please make sure that Total Parts and Total Cost are numeric values")
            Else
                OrderNumber(CurrentIndex) = txtOrderNum.Text
                TotalNumberOfParts(CurrentIndex) = CInt(txtTotalNumberOfParts.Text)
                TypeOfParts(CurrentIndex) = txtTypeOfPart.Text
                TotalCost(CurrentIndex) = CInt(txtTotalCost.Text)
                SoldTo(CurrentIndex) = txtSoldTo.Text
                SoldBy(CurrentIndex) = txtSoldBy.Text

                'totalinarray does not change
                SalesTotalInArray = SalesTotalInArray

                'calling respective function to save modified information
                Call UpdateSalesFile(SalesTotalInArray)
                Call Sales_Load(sender, e)
                Call EnableButtons()

                'let user know info was modified
                MsgBox("Information has been modified")
                'btnModify.Enabled = True
                btnModify.Text = "Modify Order"
            End If
        End If

    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'add order button

        'if statment when user selects add order:
        'if the user selects add order before any information is shown in the text box, first if statement executes
        'elseif if the text boxes show information execute elseif statment
        'else update the last element in the array's with the user input
        If btnAdd.Text = "Add Order" And String.IsNullOrEmpty(txtOrderNum.Text) Then
            Call Enable()
            Call DisableButtons()
            btnAdd.Enabled = True
            btnExit.Enabled = True
            btnAdd.Text = "Save"
            'this updates the length of the array's by 1
            ReDim Preserve OrderNumber(UBound(OrderNumber) + 1)
            ReDim Preserve TotalNumberOfParts(UBound(TotalNumberOfParts) + 1)
            ReDim Preserve TypeOfParts(UBound(TypeOfParts) + 1)
            ReDim Preserve TotalCost(UBound(TotalCost) + 1)
            ReDim Preserve SoldTo(UBound(SoldTo) + 1)
            ReDim Preserve SoldBy(UBound(SoldBy) + 1)

        ElseIf Not String.IsNullOrEmpty(txtOrderNum.Text) And btnAdd.Text = "Add Order" Then
            Call ClearTxtBoxes()
            Call DisableButtons()
            btnAdd.Enabled = True
            btnExit.Enabled = True
            btnAdd.Text = "Save"
            ReDim Preserve OrderNumber(UBound(OrderNumber) + 1)
            ReDim Preserve TotalNumberOfParts(UBound(TotalNumberOfParts) + 1)
            ReDim Preserve TypeOfParts(UBound(TypeOfParts) + 1)
            ReDim Preserve TotalCost(UBound(TotalCost) + 1)
            ReDim Preserve SoldTo(UBound(SoldTo) + 1)
            ReDim Preserve SoldBy(UBound(SoldBy) + 1)
        Else

            'handles errors and updates if no errors are found
            If Not IsNumeric(txtTotalNumberOfParts.Text) Or Not IsNumeric(txtTotalCost.Text) Then
                MsgBox("Please make sure Total Parts and Total Cost are numeric values")

            ElseIf IsNumeric(txtTotalNumberOfParts.Text) Or IsNumeric(txtTotalCost.Text) Then
                If txtTotalNumberOfParts.Text < 0 Or txtTotalCost.Text < 0 Then
                    MsgBox("Please make sure Total Parts and Total Cost are greater than zero")
                Else
                    'update last element in array's with user input
                    OrderNumber(UBound(OrderNumber)) = txtOrderNum.Text
                    TotalNumberOfParts(UBound(TotalNumberOfParts)) = CInt(txtTotalNumberOfParts.Text)
                    'save user info for inventory
                    UserEntry = CInt(txtTotalNumberOfParts.Text)
                    TypeOfParts(UBound(TypeOfParts)) = txtTypeOfPart.Text
                    'save user info for inventory
                    InventoryName = txtTypeOfPart.Text
                    TotalCost(UBound(TotalCost)) = CInt(txtTotalCost.Text)
                    SoldTo(UBound(SoldTo)) = txtSoldTo.Text
                    SoldBy(UBound(SoldBy)) = txtSoldBy.Text

                    'case to see what user put as product; will be used to subtract from overall inventory
                    Select Case InventoryName
                        Case "Pressure sensor"
                            TotalPressure = UserEntry
                            'InventoryName = "Pressure sensor"

                        Case "Temperature sensor"
                            TotalTemp = UserEntry


                        Case "Optical sensor"
                            TotalOptic = UserEntry

                        Case "Limit switches"
                            TotalLimitSwitch = UserEntry

                        Case "Human-machine interface"
                            TotalHMI = UserEntry

                        Case "Proximity sensor"
                            TotalProxi = UserEntry


                    End Select
                    'TotalSales = TotalPressure + TotalTemp + TotalOptic + TotalLimitSwitch + TotalHMI + TotalProxi

                    'check to see if order number exsits already; if not, update file
                    CheckOrderNumber = OrderNumber(UBound(OrderNumber))
                    Call DuplicateOrderNumber(CheckOrderNumber)

                    If CheckOrderNumber = "Found" Then
                        MsgBox("Order number exsits already. Please choose a different order number")
                    Else
                        'update totalinarry and call respective functions
                        SalesTotalInArray = SalesTotalInArray + 1
                        Call UpdateSalesFile(SalesTotalInArray)
                        Call Sales_Load(sender, e)
                        Call EnableButtons()
                        btnAdd.Text = "Add Order"


                    End If 'end if for duplicate number
                End If 'end if for negative number
            End If 'end if for error condition
        End If 'end if for overall if statement

    End Sub

    Private Sub btnNxtOrder_Click(sender As Object, e As EventArgs) Handles btnNxtOrder.Click
        'next order  button

        TempIndex = txtOrderNum.Text

        Call FindOrderNumber(TempIndex)

        'this moves to the next index within the array and shows the desired info
        If CurrentIndex = SalesTotalInArray - 1 Then
            CurrentIndex = 0
        Else
            CurrentIndex = CurrentIndex + 1
        End If

        'displays info
        Call Display(CurrentIndex)
    End Sub

    Private Sub btnLastOrder_Click(sender As Object, e As EventArgs) Handles btnLastOrder.Click
        'last order number

        'calls function and display last element in the array
        Call Display(SalesTotalInArray - 1)
        Call Enable()
        btnPrevious.Visible = True
        btnNxtOrder.Visible = True
    End Sub

    Private Sub btnFirstOrder_Click(sender As Object, e As EventArgs) Handles btnFirstOrder.Click
        'first order number

        Call Display(0)
        Call Enable()
        btnPrevious.Visible = True
        btnNxtOrder.Visible = True

    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        'previous order button

        TempIndex = txtOrderNum.Text

        Call FindOrderNumber(TempIndex)

        'this moves to the previous index within the array and shows the desired info
        If CurrentIndex = 0 Then
            CurrentIndex = SalesTotalInArray - 1
        Else
            CurrentIndex = CurrentIndex - 1
        End If
        'displays info
        Call Display(CurrentIndex)


    End Sub

    Private Sub btnGoToLogin_Click(sender As Object, e As EventArgs) Handles btnGoToLogin.Click
        'go to login button

        Me.Close()
        LogIn.Show()
        LogIn.txtPw.Text = ""
    End Sub


    Private Sub btnSearchOrderNum_Click(sender As Object, e As EventArgs) Handles btnSearchOrderNum.Click
        'search order button



        Dim UserInput As String = InputBox("Enter order number", "Find Order")

        Call FindOrderNumber(UserInput)

        If CurrentIndex = -1 Then
            MsgBox("Order number does not exist")
        Else
            Call Display(CurrentIndex)
            Call Enable()
        End If

        'btnPrevious.Visible = True
        'btnNxtOrder.Visible = True

    End Sub


    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Sales form load

        i = 0
        'open file and store inforamtion in respective variables
        FileOpen(1, "Sales Data.csv", OpenMode.Input)

        Input(1, TempOrderNum)
        Input(1, TempTotalNumber)
        Input(1, TempTypeOfParts)
        Input(1, TempTotalCost)
        Input(1, TempSoldTo)
        Input(1, TempSoldBy)

        Do Until EOF(1)
            'resizing array's
            ReDim Preserve OrderNumber(0 To i)
            ReDim Preserve TotalNumberOfParts(0 To i)
            ReDim Preserve TypeOfParts(0 To i)
            ReDim Preserve TotalCost(0 To i)
            ReDim Preserve SoldTo(0 To i)
            ReDim Preserve SoldBy(0 To i)

            Input(1, OrderNumber(i))
            Input(1, TotalNumberOfParts(i))
            Input(1, TypeOfParts(i))
            Input(1, TotalCost(i))
            Input(1, SoldTo(i))
            Input(1, SoldBy(i))
            i = i + 1


        Loop
        SalesTotalInArray = i
        FileClose(1)
    End Sub
End Class