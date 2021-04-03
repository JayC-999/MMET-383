Module Module1
    Public InventoryName() As String
    Public InventoryNumber() As Integer
    Public SalesName() As String
    Public SalesNumber() As Integer
    Public ProductionName() As String
    Public ProductionNumber() As Integer
    Public TotalInInvetory As Integer
    Public TotalInSales As Integer
    Public TotalInProduction As Integer
    Public TotalProducts As Integer
    Public TempName As String
    Public TempNum As String
    Public TempSalesName As String
    Public TempSalesNum As String
    Public TempProName As String
    Public TempProNum As String

    Public Sub LoadInventory()

        Call ReadInventory()

        For i = 0 To TotalInInvetory - 2
            For j = i + 1 To TotalInInvetory - 1
                'combine two inventory quantity with same name
                If InventoryName(i) = InventoryName(j) Then
                    InventoryNumber(i) = InventoryNumber(i) + InventoryNumber(j)
                    InventoryName(j) = ""
                    InventoryNumber(j) = 0

                End If
            Next j
        Next i

        'updating file without empty strings
        FileOpen(4, "Inventory(1).csv", OpenMode.Output)

        WriteLine(4, TempName, TempNum)

        For k = 0 To TotalInInvetory - 1
            If InventoryName(k) <> "" Then
                WriteLine(4, InventoryName(k), InventoryNumber(k))
            End If
        Next k

        FileClose(4)

    End Sub

    Public Sub LoadSales()

        Call ReadSales()


        For i = 0 To TotalInSales - 2
            For j = i + 1 To TotalInSales - 1
                'combine two inventory quantity with same name
                If SalesName(i) = SalesName(j) Then
                    SalesNumber(i) = SalesNumber(i) + SalesNumber(j)
                    SalesName(j) = ""
                    SalesNumber(j) = 0

                End If
            Next j
        Next i

        'updating file without empty strings
        FileOpen(5, "Sales(1).csv", OpenMode.Output)

        WriteLine(5, TempSalesName, TempSalesNum)

        For k = 0 To TotalInSales - 1
            If SalesName(k) <> "" Then
                WriteLine(5, SalesName(k), SalesNumber(k))
            End If
        Next k

        FileClose(5)
    End Sub

    Public Sub LoadProduction()

        Call LoadInventory()
        Call LoadSales()
        Call ReadProduction()

        'calculate production
        For i = 0 To TotalInInvetory - 1
            For j = 0 To TotalInSales - 1
                For k = 0 To TotalInProduction - 1
                    'calculate production = sales - inventory
                    If InventoryName(i) = SalesName(j) And InventoryName(i) = ProductionName(k) Then
                        ProductionNumber(k) = SalesNumber(j) - InventoryNumber(i)
                    End If
                Next k
            Next j
        Next i

        FileOpen(8, "Production(1).csv", OpenMode.Output)

        WriteLine(8, TempProName, TempProNum)

        For I = 0 To TotalInProduction - 1
            WriteLine(8, ProductionName(I), ProductionNumber(I))
        Next I

        FileClose(8)
    End Sub

    Public Sub ReadInventory()

        'local variables
        Dim i As Integer = 0

        'read inventory file
        FileOpen(1, "Inventory(1).csv", OpenMode.Input)

        'stores first row of unwanted values from first row of file
        Input(1, TempName)
        Input(1, TempNum)

        Do Until EOF(1)
            ReDim Preserve InventoryName(0 To i)
            ReDim Preserve InventoryNumber(0 To i)

            Input(1, InventoryName(i))
            Input(1, InventoryNumber(i))

            i = i + 1
        Loop
        TotalInInvetory = i

        FileClose(1)
    End Sub

    Public Sub ReadSales()

        'local variables
        Dim k As Integer = 0

        'read sales file
        FileOpen(2, "Sales(1).csv", OpenMode.Input)

        'stores first row of unwanted values from first row of file
        Input(2, TempSalesName)
        Input(2, TempSalesNum)

        Do Until EOF(2)
            ReDim Preserve SalesName(0 To k)
            ReDim Preserve SalesNumber(0 To k)

            Input(2, SalesName(k))
            Input(2, SalesNumber(k))

            k = k + 1
        Loop

        TotalInSales = k

        FileClose(2)
    End Sub

    Public Sub ReadProduction()

        'local variables
        Dim j As Integer = 0

        'read production file
        FileOpen(3, "Production(1).csv", OpenMode.Input)

        'stores first row of unwanted values from first row of file
        Input(3, TempProName)
        Input(3, TempProNum)

        Do Until EOF(3)
            ReDim Preserve ProductionName(0 To j)
            ReDim Preserve ProductionNumber(0 To j)

            Input(3, ProductionName(j))
            Input(3, ProductionNumber(j))

            j = j + 1
        Loop

        TotalInProduction = j

        FileClose(3)
    End Sub
End Module
