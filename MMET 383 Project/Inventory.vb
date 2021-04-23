Public Class Inventory
    Public ManagerInput As String

    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'iventory form

        ' Call HideSelectInventory()
        'TODO: This line of code loads data into the 'InventoryDataSet.Inventory' table. You can move, or remove it, as needed.
        ' Me.InventoryTableAdapter.Fill(Me.InventoryDataSet.Inventory)

        InvPressure = 40 + PurchTotalPressure - TotalPressure + ProTotalPressure + MatTotalPressure
        InvTemp = 20 - TotalTemp + PurchTotalTemp + ProTotalTemp + MatTotalTemp
        InvProx = 5 - TotalProxi + PurchTotalProxi + ProTotalProxi + MatTotalProxi
        InvOptic = 31 - TotalOptic + PurchTotalOptic + ProTotalOptic + MatTotalOptic
        InvLimit = 65 - TotalLimitSwitch + PurchTotalLimitSwitch + ProTotalLimitSwitch + MatTotalLimitSwitch
        InvHMI = 8 - TotalHMI + PurchTotalHMI + ProTotalHMI + MatTotalHMI

        txtDirection.Text = "Products" & vbTab & vbTab & vbTab & "On Hand Inventory" & vbCrLf &
                            "Pressure sensor" & vbTab & vbTab & vbTab & InvPressure & vbCrLf & "Temperature sensor" & vbTab & vbTab & vbTab & InvTemp & vbCrLf &
                           "Proximity sensor" & vbTab & vbTab & vbTab & InvProx & vbCrLf & "Optical sensor" & vbTab & vbTab & vbTab & InvOptic & vbCrLf &
                            "Limit switches" & vbTab & vbTab & vbTab & InvLimit & vbCrLf & "Human-machine interface" & vbTab & vbTab & InvHMI



    End Sub

    Private Sub btnGoToLogin_Click(sender As Object, e As EventArgs) Handles btnGoToLogin.Click
        'go to login button

        'close current form and go back to login form and clear login password text field
        Me.Close()
        LogIn.Show()
        LogIn.txtPw.Text = ""
    End Sub

    Private Sub rbtnYes_CheckedChanged(sender As Object, e As EventArgs)
        'radiobutton yes

        'if radio button is clicked then execute select case statment
        'If rbtnYes.Checked = True Then
        '    'txtQty.ReadOnly = False
        '    Select Case lstProduct.Text
        '        Case "Human-machine interface"
        '            'Call InputBoxError()
        '            txtQty.Text = CInt(txtQty.Text)
        '            txtQty.Text = txtQty.Text - TotalHMI
        '            rbtnYes.Checked = False

        '        Case "Limit switches"
        '            'Call InputBoxError()
        '            txtQty.Text = CInt(txtQty.Text)
        '            txtQty.Text = txtQty.Text - TotalLimitSwitch
        '            rbtnYes.Checked = False
        '        Case "Optical sensor"
        '            'Call InputBoxError()
        '            txtQty.Text = CInt(txtQty.Text)
        '            txtQty.Text = txtQty.Text - TotalOptic
        '            rbtnYes.Checked = False
        '        Case "Pressure sensor"
        '            'Call InputBoxError()
        '            txtQty.Text = CInt(txtQty.Text)
        '            txtQty.Text = txtQty.Text - TotalPressure
        '            rbtnYes.Checked = False
        '        Case "Proximity sensor"
        '            'Call InputBoxError()
        '            txtQty.Text = CInt(txtQty.Text)
        '            txtQty.Text = txtQty.Text - TotalProxi
        '            rbtnYes.Checked = False
        '        Case "Temperature sensor"
        '            'Call InputBoxError()
        '            txtQty.Text = CInt(txtQty.Text)
        '            txtQty.Text = txtQty.Text - TotalTemp
        '            rbtnYes.Checked = False
        '    End Select

        '    'update access file and its quantity column; file name inventory 
        '    Validate()
        '    InventoryBindingSource.EndEdit()
        '    InventoryTableAdapter.Update(Me.InventoryDataSet)
        'Inventory_Load(sender, e)

        'End If

    End Sub

    Private Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        'go back to manager form

        Me.Close()
        Management.Show()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'exit button

        Me.Close()
        End
    End Sub

    Private Sub btnInventoryUpdate_Click(sender As Object, e As EventArgs)


        'Select Case lstProduct.Text
        '    Case "Human-machine interface"
        '        'Call InputBoxError()
        '        txtQty.Text = CInt(txtQty.Text)
        '        txtQty.Text = txtQty.Text - TotalHMI
        '        'update access file and its quantity column; file name inventory 
        '        Validate()
        '        InventoryBindingSource.EndEdit()
        '        InventoryTableAdapter.Update(Me.InventoryDataSet)

        '    Case "Limit switches"
        '        'Call InputBoxError()
        '        txtQty.Text = CInt(txtQty.Text)
        '        txtQty.Text = txtQty.Text - TotalLimitSwitch
        '        'update access file and its quantity column; file name inventory 
        '        Validate()
        '        InventoryBindingSource.EndEdit()
        '        InventoryTableAdapter.Update(Me.InventoryDataSet)
        '    Case "Optical sensor"
        '        'Call InputBoxError()
        '        txtQty.Text = CInt(txtQty.Text)
        '        txtQty.Text = txtQty.Text - TotalOptic
        '        'update access file and its quantity column; file name inventory 
        '        Validate()
        '        InventoryBindingSource.EndEdit()
        '        InventoryTableAdapter.Update(Me.InventoryDataSet)
        '    Case "Pressure sensor"
        '        'Call InputBoxError()
        '        txtQty.Text = CInt(txtQty.Text)
        '        txtQty.Text = txtQty.Text - TotalPressure
        '        'update access file and its quantity column; file name inventory 
        '        Validate()
        '        InventoryBindingSource.EndEdit()
        '        InventoryTableAdapter.Update(Me.InventoryDataSet)
        '    Case "Proximity sensor"
        '        'Call InputBoxError()
        '        txtQty.Text = CInt(txtQty.Text)
        '        txtQty.Text = txtQty.Text - TotalProxi

        '    Case "Temperature sensor"
        '        'Call InputBoxError()
        '        txtQty.Text = CInt(txtQty.Text)
        '        txtQty.Text = txtQty.Text - TotalTemp
        '        'update access file and its quantity column; file name inventory 
        '        Validate()
        '        InventoryBindingSource.EndEdit()
        '        InventoryTableAdapter.Update(Me.InventoryDataSet)
        'End Select
    End Sub
End Class