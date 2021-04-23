Public Class Maintenance
    Public TempProductType, TempNumReturned, TempNumRepaired, TempPersonRepaired As String
    Public ProductType(), PersonRepaired() As String
    Public NumReturned(), NumRepaired(), MaintenanceTotalInArray, MgrNumRepaired, MgrNumReturned As Integer
    Public c, d As Integer

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'exit button

        Me.Close()
        End
    End Sub

    Private Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Me.Close()
        Management.Show()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'update button


        Select Case True
            Case rbtnPressureSensor.Checked
                'MsgBox("works")

                'if else to handle errors; else update array's
                If txtNumReturned.Text = "" Or txtRepaired.Text = "" Then
                    MsgBox("Please enter data")

                ElseIf Not IsNumeric(txtRepaired.Text) Or Not IsNumeric(txtNumReturned.Text) Then
                    MsgBox("Please enter a number")
                Else
                    MgrNumRepaired = txtRepaired.Text
                    MgrNumReturned = txtNumReturned.Text

                    MatTotalPressure = txtRepaired.Text

                    If MgrNumReturned < 0 Or MgrNumRepaired < 0 Then

                        MsgBox("Please enter a positive number")
                    Else
                        NumReturned(0) = NumReturned(0) + CInt(MgrNumReturned)
                        NumRepaired(0) = NumRepaired(0) + CInt(MgrNumRepaired)

                        txtNumReturned.Text = CStr(NumReturned(0))
                        txtRepaired.Text = CStr(NumRepaired(0))

                        rbtnPressureSensor.Checked = False
                        MsgBox("Number returned and number repaired saved and added to previous number.")

                        'call respective function and update file
                        Call UpdateMaintenanceFile()
                        Maintenance_Load(sender, e)
                        Call ShowSelectMaintenace()
                    End If
                End If

            Case rbtnTempSensor.Checked
                'if else to handle errors; else update array's
                If txtNumReturned.Text = "" Or txtRepaired.Text = "" Then
                    MsgBox("Please enter data")

                ElseIf Not IsNumeric(txtRepaired.Text) Or Not IsNumeric(txtNumReturned.Text) Then
                    MsgBox("Please enter a number")
                Else
                    MgrNumRepaired = txtRepaired.Text
                    MgrNumReturned = txtNumReturned.Text
                    MatTotalTemp = txtRepaired.Text
                    If MgrNumReturned < 0 Or MgrNumRepaired < 0 Then

                        MsgBox("Please enter a positive number")
                    Else
                        NumReturned(1) = NumReturned(1) + CInt(MgrNumReturned)
                        NumRepaired(1) = NumRepaired(1) + CInt(MgrNumRepaired)

                        txtNumReturned.Text = CStr(NumReturned(1))
                        txtRepaired.Text = CStr(NumRepaired(1))

                        rbtnTempSensor.Checked = False
                        MsgBox("Number returned and number repaired saved and added to previous number.")
                        'call respective function and update file
                        Call UpdateMaintenanceFile()
                        Maintenance_Load(sender, e)
                        Call ShowSelectMaintenace()
                    End If
                End If

            Case rbtnProxSensor.Checked
                'if else to handle errors; else update array's
                If txtNumReturned.Text = "" Or txtRepaired.Text = "" Then
                    MsgBox("Please enter data")

                ElseIf Not IsNumeric(txtRepaired.Text) Or Not IsNumeric(txtNumReturned.Text) Then
                    MsgBox("Please enter a number")
                Else
                    MgrNumRepaired = txtRepaired.Text
                    MgrNumReturned = txtNumReturned.Text
                    MatTotalProxi = txtRepaired.Text

                    If MgrNumReturned < 0 Or MgrNumRepaired < 0 Then

                        MsgBox("Please enter a positive number")
                    Else
                        NumReturned(2) = NumReturned(0) + CInt(MgrNumReturned)
                        NumRepaired(2) = NumRepaired(0) + CInt(MgrNumRepaired)

                        txtNumReturned.Text = CStr(NumReturned(2))
                        txtRepaired.Text = CStr(NumRepaired(2))

                        rbtnProxSensor.Checked = False
                        MsgBox("Number returned and number repaired saved and added to previous number.")
                        'call respective function and update file
                        Call UpdateMaintenanceFile()
                        Maintenance_Load(sender, e)
                        Call ShowSelectMaintenace()
                    End If
                End If

            Case rbtnOpticalSensor.Checked
                'if else to handle errors; else update array's
                If txtNumReturned.Text = "" Or txtRepaired.Text = "" Then
                    MsgBox("Please enter data")

                ElseIf Not IsNumeric(txtRepaired.Text) Or Not IsNumeric(txtNumReturned.Text) Then
                    MsgBox("Please enter a number")
                Else
                    MgrNumRepaired = txtRepaired.Text
                    MgrNumReturned = txtNumReturned.Text
                    MatTotalOptic = txtRepaired.Text

                    If MgrNumReturned < 0 Or MgrNumRepaired < 0 Then

                        MsgBox("Please enter a positive number")
                    Else
                        NumReturned(3) = NumReturned(3) + CInt(MgrNumReturned)
                        NumRepaired(3) = NumRepaired(3) + CInt(MgrNumRepaired)

                        txtNumReturned.Text = CStr(NumReturned(3))
                        txtRepaired.Text = CStr(NumRepaired(3))

                        rbtnOpticalSensor.Checked = False
                        MsgBox("Number returned and number repaired saved and added to previous number.")
                        'call respective function and update file
                        Call UpdateMaintenanceFile()
                        Maintenance_Load(sender, e)
                        Call ShowSelectMaintenace()
                    End If
                End If

            Case rbtnLimitSwitches.Checked
                'if else to handle errors; else update array's
                If txtNumReturned.Text = "" Or txtRepaired.Text = "" Then
                    MsgBox("Please enter data")

                ElseIf Not IsNumeric(txtRepaired.Text) Or Not IsNumeric(txtNumReturned.Text) Then
                    MsgBox("Please enter a number")
                Else
                    MgrNumRepaired = txtRepaired.Text
                    MgrNumReturned = txtNumReturned.Text
                    MatTotalLimitSwitch = txtRepaired.Text

                    If MgrNumReturned < 0 Or MgrNumRepaired < 0 Then

                        MsgBox("Please enter a positive number")
                    Else
                        NumReturned(4) = NumReturned(4) + CInt(MgrNumReturned)
                        NumRepaired(4) = NumRepaired(4) + CInt(MgrNumRepaired)

                        txtNumReturned.Text = CStr(NumReturned(4))
                        txtRepaired.Text = CStr(NumRepaired(4))

                        rbtnLimitSwitches.Checked = False
                        MsgBox("Number returned and number repaired saved and added to previous number.")
                        'call respective function and update file
                        Call UpdateMaintenanceFile()
                        Maintenance_Load(sender, e)
                        Call ShowSelectMaintenace()
                    End If
                End If

            Case rbtnHumanMachine.Checked
                'if else to handle errors; else update array's
                If txtNumReturned.Text = "" Or txtRepaired.Text = "" Then
                    MsgBox("Please enter data")

                ElseIf Not IsNumeric(txtRepaired.Text) Or Not IsNumeric(txtNumReturned.Text) Then
                    MsgBox("Please enter a number")
                Else
                    MgrNumRepaired = txtRepaired.Text
                    MgrNumReturned = txtNumReturned.Text
                    MatTotalHMI = txtRepaired.Text

                    If MgrNumReturned < 0 Or MgrNumRepaired < 0 Then

                        MsgBox("Please enter a positive number")
                    Else
                        NumReturned(5) = NumReturned(5) + CInt(MgrNumReturned)
                        NumRepaired(5) = NumRepaired(5) + CInt(MgrNumRepaired)

                        txtNumReturned.Text = CStr(NumReturned(5))
                        txtRepaired.Text = CStr(NumRepaired(5))

                        rbtnHumanMachine.Checked = False
                        MsgBox("Number returned and number repaired saved and added to previous number.")
                        'call respective function and update file
                        Call UpdateMaintenanceFile()
                        Maintenance_Load(sender, e)
                        Call ShowSelectMaintenace()
                    End If
                End If
            Case Else
                MsgBox("Please select a product")
        End Select
    End Sub

    Private Sub btnGoToLogin_Click(sender As Object, e As EventArgs) Handles btnGoToLogin.Click
        'go back login button

        Me.Close()
        LogIn.Show()
        LogIn.txtPw.Text = ""
    End Sub

    Private Sub rbtnTempSensor_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTempSensor.CheckedChanged
        'radio button temp sensor

        Call DisplayMaintenance(1)
    End Sub

    Private Sub rbtnProxSensor_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnProxSensor.CheckedChanged
        'radio button proxsensor

        Call DisplayMaintenance(2)
    End Sub

    Private Sub rbtnOpticalSensor_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOpticalSensor.CheckedChanged
        'radio button opticsensor

        Call DisplayMaintenance(3)
    End Sub

    Private Sub rbtnLimitSwitches_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnLimitSwitches.CheckedChanged
        'radio button limitswitches

        Call DisplayMaintenance(4)
    End Sub

    Private Sub rbtnHumanMachine_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnHumanMachine.CheckedChanged
        'radio button human machine interface

        Call DisplayMaintenance(5)
    End Sub


    Private Sub rbtnPressureSensor_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPressureSensor.CheckedChanged
        'radio button pressure sensor

        Call DisplayMaintenance(0)
    End Sub



    Private Sub Maintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'maintenance form load

        txtInstructions.Text = "User, " & vbCrLf & "Simply click a product and its information will show in the text fields"
        btnUpdate.Visible = False
        btnGoBack.Visible = False


        c = 0
        FileOpen(7, "ReturnRepair.csv", OpenMode.Input)

        Input(7, TempProductType)
        Input(7, TempNumReturned)
        Input(7, TempNumRepaired)
        Input(7, TempPersonRepaired)

        Do Until EOF(7)
            ReDim Preserve ProductType(0 To c)
            ReDim Preserve NumReturned(0 To c)
            ReDim Preserve NumRepaired(0 To c)
            ReDim Preserve PersonRepaired(0 To c)

            Input(7, ProductType(c))
            Input(7, NumReturned(c))
            Input(7, NumRepaired(c))
            Input(7, PersonRepaired(c))

            c = c + 1
        Loop
        MaintenanceTotalInArray = c

        FileClose(7)
    End Sub
End Class