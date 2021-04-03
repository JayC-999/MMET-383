Module InventoryFunctions
    Public NameFound As Integer = 0

    'custom sub to display product name and quatity
    Public Sub Display(ByVal Index As Integer)

        'using text box in inventory form
        Inventory.txtProdName.Text = InventoryName(Index)
        Inventory.txtQty.Text = InventoryNumber(Index)
    End Sub

    Public Sub FindName(ByVal Name As String)

        'variable to set if there is no product name found
        NameFound = -1

        'loop to find product name. if found variable becomes loop counter and exit sub
        For k = 0 To TotalInInvetory - 1
            If InventoryName(k) = Name Then
                NameFound = k
                Exit Sub
            Else
                NameFound = NameFound
            End If
        Next k
    End Sub

    Public Sub Save(ByVal rec As Long)
        Dim j As Long

        'open file
        FileOpen(6, "Inventory(1).csv", OpenMode.Output)

        WriteLine(6, TempName, TempNum)

        For j = 0 To TotalInInvetory - 1
            If j <> rec Then
                WriteLine(6, InventoryName(j), InventoryNumber(j))
            End If
        Next j

        FileClose(6)
    End Sub

    Public Sub Able()
        Inventory.btnAdd.Enabled = True
        Inventory.btnDelete.Enabled = True
        Inventory.btnMod.Enabled = True
        Inventory.btnFstRecord.Enabled = True
        Inventory.btnLstRecord.Enabled = True
        Inventory.btnName.Enabled = True
        Inventory.btnPreRecord.Enabled = True
        Inventory.btnNxtRecord.Enabled = True
        Inventory.btnExit.Enabled = True
    End Sub

    Public Sub Disable()
        Inventory.btnAdd.Enabled = False
        Inventory.btnDelete.Enabled = False
        Inventory.btnMod.Enabled = False
        Inventory.btnFstRecord.Enabled = False
        Inventory.btnLstRecord.Enabled = False
        Inventory.btnName.Enabled = False
        Inventory.btnPreRecord.Enabled = False
        Inventory.btnNxtRecord.Enabled = False
        Inventory.btnExit.Enabled = False
    End Sub
End Module
