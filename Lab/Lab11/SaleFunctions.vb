Module SaleFunctions
    Public SalesNameFound As Integer = 0
    Public Sub xDisplay(ByVal Index As Integer)

        'displays sales information
        Sales.txtProductx.Text = SalesName(Index)
        Sales.txtQuantity.Text = SalesNumber(Index)
    End Sub

    Public Sub xFindName(ByVal Name As String)

        'variable to set if there is no product name found
        SalesNameFound = -1

        'loop to find product name. if found variable becomes loop counter and exit sub
        For k = 0 To TotalInSales - 1
            If SalesName(k) = Name Then
                SalesNameFound = k
                Exit Sub
            Else
                SalesNameFound = SalesNameFound
            End If
        Next k
    End Sub

    Public Sub xSave(ByVal rec As Long)
        Dim j As Long

        'open file
        FileOpen(7, "Sales(1).csv", OpenMode.Output)

        WriteLine(7, TempSalesName, TempSalesNum)

        For j = 0 To TotalInSales - 1
            If j <> rec Then
                WriteLine(7, SalesName(j), SalesNumber(j))
            End If
        Next j

        FileClose(7)
    End Sub

    Public Sub xAble()
        Sales.btnAddx.Enabled = True
        Sales.btnFstRecordx.Enabled = True
        Sales.btnPreRecordx.Enabled = True
        Sales.btnDeletex.Enabled = True
        Sales.btnLstRecordx.Enabled = True
        Sales.btnNxtRecordx.Enabled = True
        Sales.btnModx.Enabled = True
        Sales.btnFind.Enabled = True
        Sales.btnexit.Enabled = True
    End Sub

    Public Sub xDisable()
        Sales.btnAddx.Enabled = False
        Sales.btnFstRecordx.Enabled = False
        Sales.btnPreRecordx.Enabled = False
        Sales.btnDeletex.Enabled = False
        Sales.btnLstRecordx.Enabled = False
        Sales.btnNxtRecordx.Enabled = False
        Sales.btnModx.Enabled = False
        Sales.btnFind.Enabled = False
        Sales.btnexit.Enabled = False
    End Sub
End Module
