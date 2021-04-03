Module ProductionFunctions
    Public ProductionNameFound As Integer = 0
    Public Sub zDisplay(ByVal Index As Integer)

        'displays sales information
        Production.txtProdz.Text = ProductionName(Index)
        Production.txtQuant.Text = ProductionNumber(Index)
    End Sub

    Public Sub zFindName(ByVal Name As String)

        'variable to set if there is no product name found
        ProductionNameFound = -1

        'loop to find product name. if found variable becomes loop counter and exit sub
        For k = 0 To TotalInProduction - 1
            If ProductionName(k) = Name Then
                ProductionNameFound = k
                Exit Sub
            Else
                ProductionNameFound = ProductionNameFound
            End If
        Next k
    End Sub

    Public Sub zSave(ByVal rec As Long)
        Dim j As Long

        'open file
        FileOpen(9, "Production(1).csv", OpenMode.Output)

        WriteLine(9, TempProName, TempProNum)

        For j = 0 To TotalInProduction - 1
            If j <> rec Then
                WriteLine(9, ProductionName(j), ProductionNumber(j))
            End If
        Next j

        FileClose(9)
    End Sub

    Public Sub zAble()
        Production.btnAddz.Enabled = True
        Production.btnFIrstz.Enabled = True
        Production.btnPreviousz.Enabled = True
        Production.btnDeletez.Enabled = True
        Production.btnLstRecz.Enabled = True
        Production.btnNxtz.Enabled = True
        Production.btnModz.Enabled = True
        Production.btnFindz.Enabled = True
        Production.btnExitz.Enabled = True
        Production.btnBackz.Enabled = True
    End Sub

    Public Sub zDisable()
        Production.btnAddz.Enabled = False
        Production.btnFIrstz.Enabled = False
        Production.btnPreviousz.Enabled = False
        Production.btnDeletez.Enabled = False
        Production.btnLstRecz.Enabled = False
        Production.btnNxtz.Enabled = False
        Production.btnModz.Enabled = False
        Production.btnFindz.Enabled = False
        Production.btnExitz.Enabled = False
        Production.btnBackz.Enabled = False
    End Sub
End Module
