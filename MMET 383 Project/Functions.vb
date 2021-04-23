Module Functions
    Public InventoryName, PurchInventoryName As String
    Public TotalSales, TotalPressure, TotalTemp, TotalOptic, TotalProxi, TotalHMI, TotalLimitSwitch, UserEntry, PurchUserEntry As Integer
    Public ProTotalPressure, ProTotalTemp, ProTotalOptic, ProTotalProxi, ProTotalHMI, ProTotalLimitSwitch As Integer
    Public MatTotalPressure, MatTotalTemp, MatTotalOptic, MatTotalProxi, MatTotalHMI, MatTotalLimitSwitch As Integer
    Public PurchTotalPressure, PurchTotalTemp, PurchTotalOptic, PurchTotalProxi, PurchTotalHMI, PurchTotalLimitSwitch As Integer
    Public InvPressure, InvTemp, InvProx, InvOptic, InvLimit, InvHMI As Integer
    Public SalesInputArray(0 To 6) As Integer


    'sub for purchsing form that displays informatin in arrays to respective text boxes
    Public Sub xDisplay(ByVal Index As Integer)
        Purchasing.txtPurchaseNumber.Text = Purchasing.PurchaseNumber(Index)
        Purchasing.txtTotalParts.Text = Purchasing.TotalNumOfParts(Index)
        Purchasing.txtTypeOfPart.Text = Purchasing.TypeOfPart(Index)
        Purchasing.txtTotalCost.Text = Format(Purchasing.PurchaseTotalCost(Index), "$0.00")
        Purchasing.txtBoughtFrom.Text = Purchasing.BoughtFrom(Index)
        Purchasing.txtMadePurchase.Text = Purchasing.MadePurchase(Index)
    End Sub

    'sub to display production txt boxes information
    Public Sub DisplayProduction(ByVal Index As Integer)
        Production.txtNumOfParts.Text = Production.NumOfPartsProduce(Index)
        Production.txtManufacturer.Text = Production.Manufacturer(Index)
    End Sub

    'sub to display maintenance txt boxes information
    Public Sub DisplayMaintenance(ByVal Index As Integer)
        Maintenance.txtNumReturned.Text = Maintenance.NumReturned(Index)
        Maintenance.txtRepaired.Text = Maintenance.NumRepaired(Index)
        Maintenance.txtPersonRepaired.Text = Maintenance.PersonRepaired(Index)
    End Sub

    'sub to manager buttons inventory
    Public Sub ShowSelectInventory()
        Inventory.btnGoBack.Visible = True
        Inventory.txtDirection.Visible = True
        'Inventory.txtDirection.Text = "Manager, " & vbCrLf & "If you want to update the quantity of a specific product, simply click a product, and click the yes button."
        'Inventory.rbtnYes.Visible = True
        'Inventory.Label3.Visible = True
        'Inventory.Label4.Visible = True
    End Sub

    'sub to manager button production
    Public Sub ShowSelectProduction()
        Production.btnExit.Visible = True
        Production.btnUpdate.Visible = True
        Production.btnGoBack.Visible = True
        Production.txtDescription.Visible = True
        Production.txtNumOfParts.ReadOnly = False
        Production.txtManufacturer.ReadOnly = True
        Production.txtDescription.Text = "Manager, " & vbCrLf & "to update the number of parts produced, " & vbCrLf &
                                         "simply click a product, edit its current number in the text field, and click Update Number of Parts Produced"
    End Sub

    Public Sub ShowSelectMaintenace()
        Maintenance.txtInstructions.Text = "Manager, " & vbCrLf & "to update number of parts produce, " & vbCrLf &
                                           "simply click a product, edit its current number in the text field, and click update"
        Maintenance.btnUpdate.Visible = True
        Maintenance.btnGoBack.Visible = True
        Maintenance.txtNumReturned.ReadOnly = False
        Maintenance.txtRepaired.ReadOnly = False
    End Sub

    'sub to show info for user in production
    Public Sub ShowUserInfoProduction()
        Production.btnGoBack.Visible = False
        Production.btnUpdate.Visible = False
        Production.txtDescription.Visible = True
        Production.txtDescription.Text = "User, " & vbCrLf & "simply click a product and its information will show in the text fields"
        Production.txtNumOfParts.ReadOnly = True
        Production.txtManufacturer.ReadOnly = True
    End Sub

    'sub for production 
    Public Sub KeepButtonsProduction()
        'call function to update production file; keep instructions and mgr buttons after update
        Production.btnGoBack.Visible = True
        Production.btnUpdate.Visible = True
        Production.txtDescription.Visible = True
        Production.Label5.Visible = True
        MsgBox("Number of parts produced saved and added to previous number of parts produced.")
    End Sub
    'sub to hide manager buttons in inventory form
    Public Sub HideSelectInventory()

        Inventory.btnGoBack.Visible = False
        Inventory.txtDirection.Visible = False
        ' Inventory.rbtnYes.Visible = False
        'Inventory.Label3.Visible = False
        'Inventory.Label4.Visible = False
    End Sub

    'clear text boxes
    Public Sub ClearTxtBoxes()
        Sales.txtOrderNum.Text = ""
        Sales.txtTypeOfPart.Text = ""
        Sales.txtTotalNumberOfParts.Text = ""
        Sales.txtTotalCost.Text = ""
        Sales.txtSoldTo.Text = ""
        Sales.txtSoldBy.Text = ""

        Purchasing.txtPurchaseNumber.Text = ""
        Purchasing.txtTotalParts.Text = ""
        Purchasing.txtTypeOfPart.Text = ""
        Purchasing.txtTotalCost.Text = ""
        Purchasing.txtBoughtFrom.Text = ""
        Purchasing.txtMadePurchase.Text = ""
    End Sub

    'sub for purchsing that finds purchasing number
    'Public Sub FindPurchaseNumber(ByVal TempIndex As String)

    '    Purchasing.PurchaseCurrentIndex = -1

    '    'for loop to find matching userinput; if not found CurrentIndex is set to -1 and tell user order number is not found
    '    For i = 0 To Purchasing.TotNumPurchasingDataset - 1

    '        If Purchasing.PurchaseNumber(i) = TempIndex Then
    '            Purchasing.PurchaseCurrentIndex = i
    '            Exit Sub
    '        Else
    '            Purchasing.PurchaseCurrentIndex = Purchasing.PurchaseCurrentIndex
    '        End If
    '    Next i
    'End Sub

    'sub for sales to display information if repective text box
    Public Sub Display(ByVal Index As Integer)

        'setting text box to display inofrmation form array
        Sales.txtOrderNum.Text = Sales.OrderNumber(Index)
        Sales.txtTotalNumberOfParts.Text = CStr(Sales.TotalNumberOfParts(Index))
        Sales.txtTypeOfPart.Text = Sales.TypeOfParts(Index)
        Sales.txtTotalCost.Text = Format(Sales.TotalCost(Index), "$0.00")
        Sales.txtSoldTo.Text = Sales.SoldTo(Index)
        Sales.txtSoldBy.Text = Sales.SoldBy(Index)
    End Sub

    'sub for sales to find order number
    Public Sub FindOrderNumber(ByVal TempIndex As String)

        Sales.CurrentIndex = -1


        'for loop to find matching userinput; if not found CurrentIndex is set to -1 and tell user order number is not found
        For k = 0 To Sales.SalesTotalInArray - 1
            If Sales.OrderNumber(k) = TempIndex Then
                Sales.CurrentIndex = k
                Exit Sub
            Else
                Sales.CurrentIndex = Sales.CurrentIndex
            End If
        Next k
    End Sub

    'sub to enable text boxes in respective forms
    Public Sub Enable()
        Sales.txtOrderNum.Enabled = True
        Sales.txtTotalNumberOfParts.Enabled = True
        Sales.txtTypeOfPart.Enabled = True
        Sales.txtTotalCost.Enabled = True
        Sales.txtSoldTo.Enabled = True
        Sales.txtSoldBy.Enabled = True

        Purchasing.txtPurchaseNumber.Enabled = True
        Purchasing.txtTotalParts.Enabled = True
        Purchasing.txtTypeOfPart.Enabled = True
        Purchasing.txtTotalCost.Enabled = True
        Purchasing.txtBoughtFrom.Enabled = True
        Purchasing.txtMadePurchase.Enabled = True
    End Sub

    'sub to enable button add, button delete... and so on 
    Public Sub ShowButtons()
        Sales.btnAdd.Visible = True
        Sales.btnDelete.Visible = True
        Sales.btnModify.Visible = True
        Sales.btnExit.Visible = True
        Sales.btnFirstOrder.Visible = True
        Sales.btnLastOrder.Visible = True
        Sales.btnNxtOrder.Visible = True
        Sales.btnPrevious.Visible = True
        Sales.btnGoBack.Visible = True

        Purchasing.btnFirstPurchase.Visible = True
        Purchasing.btnLastPurchaseOrder.Visible = True
        Purchasing.btnPreviousPurchaseOrder.Visible = True
        Purchasing.btnNxtPurchaseOrder.Visible = True
        Purchasing.btnExit.Visible = True
        Purchasing.btnDelete.Visible = True
        Purchasing.btnModify.Visible = True
        Purchasing.btnAdd.Visible = True
        Purchasing.btnGoBack.Visible = True
    End Sub

    Public Sub ReadOnlyEnabledPurchasing()
        Purchasing.txtPurchaseNumber.ReadOnly = False
        Purchasing.txtTypeOfPart.ReadOnly = False
        Purchasing.txtTotalCost.ReadOnly = False
        Purchasing.txtBoughtFrom.ReadOnly = False
        Purchasing.txtMadePurchase.ReadOnly = False
        Purchasing.txtTotalParts.ReadOnly = False
        Purchasing.btnNxtPurchaseOrder.Visible = True
        Purchasing.btnPreviousPurchaseOrder.Visible = True


    End Sub

    'sub to disable buttons 
    Public Sub DisableButtons()
        Sales.btnSearchOrderNum.Enabled = False
        Sales.btnGoToLogin.Enabled = False
        Sales.btnPrevious.Enabled = False
        Sales.btnNxtOrder.Enabled = False
        Sales.btnExit.Enabled = False
        Sales.btnAdd.Enabled = False
        Sales.btnModify.Enabled = False
        Sales.btnDelete.Enabled = False
        Sales.btnFirstOrder.Enabled = False
        Sales.btnLastOrder.Enabled = False

        Purchasing.btnPurchase.Enabled = False
        Purchasing.btnGoToLogin.Enabled = False
        Purchasing.btnFirstPurchase.Enabled = False
        Purchasing.btnLastPurchaseOrder.Enabled = False
        Purchasing.btnPreviousPurchaseOrder.Enabled = False
        Purchasing.btnNxtPurchaseOrder.Enabled = False
        Purchasing.btnExit.Enabled = False
        Purchasing.btnDelete.Enabled = False
        Purchasing.btnModify.Enabled = False
        Purchasing.btnAdd.Enabled = False
    End Sub

    'sun to enable buttons
    Public Sub EnableButtons()
        Sales.btnSearchOrderNum.Enabled = True
        Sales.btnGoToLogin.Enabled = True
        Sales.btnPrevious.Enabled = True
        Sales.btnNxtOrder.Enabled = True
        Sales.btnExit.Enabled = True
        Sales.btnAdd.Enabled = True
        Sales.btnModify.Enabled = True
        Sales.btnDelete.Enabled = True
        Sales.btnFirstOrder.Enabled = True
        Sales.btnLastOrder.Enabled = True

        Purchasing.btnPurchase.Enabled = True
        Purchasing.btnGoToLogin.Enabled = True
        Purchasing.btnFirstPurchase.Enabled = True
        Purchasing.btnLastPurchaseOrder.Enabled = True
        Purchasing.btnPreviousPurchaseOrder.Enabled = True
        Purchasing.btnNxtPurchaseOrder.Enabled = True
        Purchasing.btnExit.Enabled = True
        Purchasing.btnDelete.Enabled = True
        Purchasing.btnModify.Enabled = True
        Purchasing.btnAdd.Enabled = True
    End Sub


    'sub to handle inputbox error
    Public Sub InputBoxError()


        'handles error for the inpubox
        'if manager enters a quantity, then update quantity 
        'else, the manager cancelled quantity update and let them know
        'Inventory.ManagerInput = InputBox("Please enter a positive quantity", "Enter quantity")

        'If Inventory.ManagerInput <> "" And IsNumeric(Inventory.ManagerInput) Then
        '    If Inventory.ManagerInput < 0 Then
        '        MsgBox("Input postive quantity")
        '        Inventory.rbtnYes.Checked = False
        '    Else
        '        Inventory.txtQty.Text = ""
        '        Inventory.txtQty.Text = CInt(Inventory.ManagerInput)
        '        MsgBox("Quantity updated")
        '        Inventory.rbtnYes.Checked = False
        '    End If
        'ElseIf Inventory.ManagerInput <> "" Then
        '    Inventory.txtQty.Text = ""
        '    Inventory.txtQty.Text = CInt(Inventory.ManagerInput)
        '    MsgBox("Quantity updated")
        '    Inventory.rbtnYes.Checked = False

        'Else
        '    MsgBox("You've cancelled")
        '    'Inventory.lstProduct.ClearSelected()
        '    Inventory.rbtnYes.Checked = False
        'End If
    End Sub

    'public sub to handle duplicate purchase number in sales
    Public Sub DuplicatePurchaseNumber(ByVal TempPurchaseNum As Integer)

        For i = 0 To Purchasing.PurchasingTotalInArray - 1
            If Purchasing.PurchaseNumber(i) = TempPurchaseNum Then
                Purchasing.CheckPurchaseNumber = -1
            End If
        Next
    End Sub

    'public sub to handle duplicate order number in sales
    Public Sub DuplicateOrderNumber(ByVal TempOrderNumber As String)

        For k = 0 To Sales.SalesTotalInArray - 1
            If Sales.OrderNumber(k) = TempOrderNumber Then
                Sales.CheckOrderNumber = "Found"
            End If
        Next k
    End Sub



    'sub to update sales .cvs file
    Public Sub UpdateSalesFile(ByVal record As Long)
        Dim j As Long

        'open file
        FileOpen(3, "Sales Data.csv", OpenMode.Output)

        WriteLine(3, Sales.TempOrderNum, Sales.TempTotalNumber, Sales.TempTypeOfParts, Sales.TempTotalCost, Sales.TempSoldTo, Sales.TempSoldBy)

        'unwanted index (order number and information) does not get stored
        For j = 0 To Sales.SalesTotalInArray - 1
            If j <> record Then
                WriteLine(3, Sales.OrderNumber(j), Sales.TotalNumberOfParts(j), Sales.TypeOfParts(j), Sales.TotalCost(j), Sales.SoldTo(j), Sales.SoldBy(j))
            End If
        Next j

        Call Test()


        FileClose(3)
    End Sub

    Public Sub UpdatePurchasingFile(ByVal rec As Long)
        Dim k As Long

        'open file
        FileOpen(4, "Purchasing Data.csv", OpenMode.Output)

        WriteLine(4, Purchasing.TempPurchaseNumber, Purchasing.TempTotalNumOfParts, Purchasing.TempTypeOfPart,
                  Purchasing.TempTotalCost, Purchasing.TempBoughtFrom, Purchasing.TempMadePurchase)

        'unwanted index (purchase order number) does not get stored
        For k = 0 To Purchasing.PurchasingTotalInArray - 1
            If k <> rec Then
                WriteLine(4, Purchasing.PurchaseNumber(k), Purchasing.TotalNumOfParts(k), Purchasing.TypeOfPart(k),
                         Purchasing.PurchaseTotalCost(k), Purchasing.BoughtFrom(k), Purchasing.MadePurchase(k))
            End If
        Next k

        FileClose(4)
    End Sub

    Public Sub UpdateProductionFile()

        FileOpen(6, "Production - Production.csv", OpenMode.Output)

        WriteLine(6, Production.TempNumOfPartsProduce, Production.TempTypeOfPart, Production.TempManufacturer)

        For j = 0 To Production.ProductionTotalInArray - 1
            WriteLine(6, Production.NumOfPartsProduce(j), Production.Part(j), Production.Manufacturer(j))
        Next j

        FileClose(6)
    End Sub

    Public Sub UpdateMaintenanceFile()

        FileOpen(8, "ReturnRepair.csv", OpenMode.Output)

        WriteLine(8, Maintenance.TempProductType, Maintenance.TempNumReturned, Maintenance.TempNumRepaired, Maintenance.TempPersonRepaired)

        For i = 0 To Maintenance.MaintenanceTotalInArray - 1
            WriteLine(8, Maintenance.ProductType(i), Maintenance.NumReturned(i), Maintenance.NumRepaired(i), Maintenance.PersonRepaired(i))
        Next i

        FileClose(8)
    End Sub

    Public Sub Test()

        'no bueno
        MgrSummary.txtSummary.Text = "What you added from Sales: " & vbCrLf & "Pressure sensor:" & vbTab & vbTab & vbTab & TotalPressure & vbCrLf & "Temperature sensor:" & vbTab & vbTab & TotalTemp &
                                     vbCrLf & "Proximity sensor:" & vbTab & vbTab & vbTab & TotalProxi & vbCrLf & "Optical sensor" & vbTab & vbTab & vbTab & TotalOptic & vbCrLf &
                                     "Limit switches:" & vbTab & vbTab & vbTab & TotalLimitSwitch & vbCrLf & "Human-machine interface" & vbTab & vbTab & TotalHMI & vbCrLf & vbCrLf &
                                     "What you added from purchasing:" & vbCrLf & "Pressure sensor:" & vbTab & vbTab & vbTab & PurchTotalPressure & vbCrLf & "Temperature sensor:" & vbTab & vbTab & PurchTotalTemp &
                                     vbCrLf & "Proximity sensor:" & vbTab & vbTab & vbTab & PurchTotalProxi & vbCrLf & "Optical sensor" & vbTab & vbTab & vbTab & PurchTotalOptic & vbCrLf &
                                     "Limit switches:" & vbTab & vbTab & vbTab & PurchTotalLimitSwitch & vbCrLf & "Human-machine interface" & vbTab & vbTab & PurchTotalHMI & vbCrLf & vbCrLf & "What you added from Production:" & vbCrLf & "Pressure sensor:" & vbTab & vbTab & vbTab & ProTotalPressure & vbCrLf & "Temperature sensor:" & vbTab & vbTab & ProTotalTemp &
                                     vbCrLf & "Proximity sensor:" & vbTab & vbTab & vbTab & ProTotalProxi & vbCrLf & "Optical sensor" & vbTab & vbTab & vbTab & ProTotalOptic & vbCrLf &
                                     "Limit switches:" & vbTab & vbTab & vbTab & ProTotalLimitSwitch & vbCrLf & "Human-machine interface" & vbTab & vbTab & ProTotalHMI & vbCrLf & vbCrLf & "What you added from Maintenace:" & vbCrLf & "Pressure sensor:" & vbTab & vbTab & vbTab & MatTotalPressure & vbCrLf & "Temperature sensor:" & vbTab & vbTab & MatTotalTemp &
                                     vbCrLf & "Proximity sensor:" & vbTab & vbTab & vbTab & MatTotalProxi & vbCrLf & "Optical sensor" & vbTab & vbTab & vbTab & MatTotalOptic & vbCrLf &
                                     "Limit switches:" & vbTab & vbTab & vbTab & MatTotalLimitSwitch & vbCrLf & "Human-machine interface" & vbTab & vbTab & MatTotalHMI





    End Sub
End Module
