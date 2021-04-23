Public Class Production
    Public TempTypeOfPart, TempManufacturer, TempNumOfPartsProduce, Part(), Manufacturer() As String
    Public ProductionTotalInArray, ProductionCurrentIndex, a, b, MgrInput As Integer
    Public NumOfPartsProduce() As Integer

    Private Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        'go back to manager division list

        Me.Close()
        Management.Show()
    End Sub

    Private Sub btnGoToLogin_Click(sender As Object, e As EventArgs) Handles btnGoToLogin.Click
        'go back to login 

        Me.Close()
        LogIn.Show()
        LogIn.txtPw.Text = ""
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'update button

        txtDescription.Visible = True

        'if else satement that adds current number of produced products to the managers input; handles erros too
        If rbtnPressureSensor.Checked = True Then
            If txtNumOfParts.Text = "" Then
                MsgBox("Please enter number of parts")

            ElseIf Not IsNumeric(txtNumOfParts.Text) Then
                MsgBox("Please enter a number")
            Else
                MgrInput = txtNumOfParts.Text
                If MgrInput < 0 Or MgrInput = 0 Then
                    MsgBox("Please enter a positive number")

                Else
                    ProTotalPressure = MgrInput
                    NumOfPartsProduce(0) = NumOfPartsProduce(0) + MgrInput
                    txtNumOfParts.Text = CStr(NumOfPartsProduce(0))
                    'ProTotalPressure = CInt(txtNumOfParts.Text)
                    'call function to update production file; keep instructions and mgr buttons after update
                    rbtnPressureSensor.Checked = False
                    Call UpdateProductionFile()
                    Production_Load(sender, e)
                    Call KeepButtonsProduction()
                End If 'end if for negative number
            End If 'end if error

        ElseIf rbtnTempSensor.Checked = True Then
            If txtNumOfParts.Text = "" Then
                MsgBox("Please enter number of parts")

            ElseIf Not IsNumeric(txtNumOfParts.Text) Then
                MsgBox("Please enter a number")
            Else
                MgrInput = txtNumOfParts.Text
                If MgrInput < 0 Or MgrInput = 0 Then
                    MsgBox("Please enter a positive number")

                Else
                    ProTotalTemp = MgrInput
                    NumOfPartsProduce(1) = NumOfPartsProduce(1) + MgrInput
                    txtNumOfParts.Text = CStr(NumOfPartsProduce(1))
                    'ProTotalTemp = CInt(txtNumOfParts.Text)
                    'call function to update production file; keep instructions and mgr buttons after update
                    rbtnTempSensor.Checked = False
                    Call UpdateProductionFile()
                    Production_Load(sender, e)
                    Call KeepButtonsProduction()
                End If 'end if for negative number
            End If 'end if error

        ElseIf rbtnProxSensor.Checked = True Then
            If txtNumOfParts.Text = "" Then
                MsgBox("Please enter number of parts")

            ElseIf Not IsNumeric(txtNumOfParts.Text) Then
                MsgBox("Please enter a number")
            Else
                MgrInput = txtNumOfParts.Text
                If MgrInput < 0 Or MgrInput = 0 Then
                    MsgBox("Please enter a positive number")

                Else
                    ProTotalProxi = MgrInput
                    NumOfPartsProduce(2) = NumOfPartsProduce(2) + MgrInput
                    txtNumOfParts.Text = CStr(NumOfPartsProduce(2))
                    'ProTotalProxi = CInt(txtNumOfParts.Text)
                    'call function to update production file; keep instructions and mgr buttons after update
                    rbtnProxSensor.Checked = False
                    Call UpdateProductionFile()
                    Production_Load(sender, e)
                    Call KeepButtonsProduction()
                End If 'end if for negative number
            End If 'end if error

        ElseIf rbtnOpticalSensore.Checked = True Then
            If txtNumOfParts.Text = "" Then
                MsgBox("Please enter number of parts")

            ElseIf Not IsNumeric(txtNumOfParts.Text) Then
                MsgBox("Please enter a number")
            Else
                MgrInput = txtNumOfParts.Text
                If MgrInput < 0 Or MgrInput = 0 Then
                    MsgBox("Please enter a positive number")

                Else
                    ProTotalOptic = MgrInput
                    NumOfPartsProduce(3) = NumOfPartsProduce(3) + MgrInput
                    txtNumOfParts.Text = CStr(NumOfPartsProduce(3))
                    'ProTotalOptic = CInt(txtNumOfParts.Text)
                    'call function to update production file; keep instructions and mgr buttons after update
                    rbtnOpticalSensore.Checked = False
                    Call UpdateProductionFile()
                    Production_Load(sender, e)
                    Call KeepButtonsProduction()
                End If 'end if for negative number
            End If 'end if error

        ElseIf rbtnHumanMachine.Checked = True Then
            If txtNumOfParts.Text = "" Then
                MsgBox("Please enter number of parts")

            ElseIf Not IsNumeric(txtNumOfParts.Text) Then
                MsgBox("Please enter a number")
            Else
                MgrInput = txtNumOfParts.Text
                If MgrInput < 0 Or MgrInput = 0 Then
                    MsgBox("Please enter a positive number")

                Else
                    ProTotalHMI = MgrInput
                    NumOfPartsProduce(5) = NumOfPartsProduce(5) + MgrInput
                    txtNumOfParts.Text = CStr(NumOfPartsProduce(5))

                    'call function to update production file; keep instructions and mgr buttons after update
                    rbtnHumanMachine.Checked = False
                    Call UpdateProductionFile()
                    Production_Load(sender, e)
                    Call KeepButtonsProduction()
                End If 'end if for negative number
            End If 'end if error

        ElseIf rbtnLimitSwitches.Checked = True Then
            If txtNumOfParts.Text = "" Then
                MsgBox("Please enter number of parts")

            ElseIf Not IsNumeric(txtNumOfParts.Text) Then
                MsgBox("Please enter a number")
            Else
                MgrInput = txtNumOfParts.Text
                If MgrInput < 0 Or MgrInput = 0 Then
                    MsgBox("Please enter a positive number")

                Else
                    ProTotalLimitSwitch = MgrInput
                    NumOfPartsProduce(4) = NumOfPartsProduce(4) + MgrInput
                    txtNumOfParts.Text = CStr(NumOfPartsProduce(4))
                    'ProTotalLimitSwitch = CInt(txtNumOfParts.Text)
                    'call function to update production file; keep instructions and mgr buttons after update
                    rbtnLimitSwitches.Checked = False
                    Call UpdateProductionFile()
                    Production_Load(sender, e)
                    Call KeepButtonsProduction()
                End If 'end if for negative number
            End If 'end if error
        Else
            MsgBox("Please select a product")
        End If 'end overall if

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'exit program button

        Me.Close()
        End
    End Sub

    Private Sub rbtnProxSensor_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnProxSensor.CheckedChanged
        'prox sensor radio button

        Call DisplayProduction(2)
    End Sub

    Private Sub rbtnOpticalSensore_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOpticalSensore.CheckedChanged
        'optical sensor radio button

        Call DisplayProduction(3)
    End Sub

    Private Sub rbtnHumanMachine_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnHumanMachine.CheckedChanged
        'human manchine radio button

        Call DisplayProduction(5)
    End Sub

    Private Sub rbtnLimitSwitches_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnLimitSwitches.CheckedChanged
        'limit switches radio button

        Call DisplayProduction(4)
    End Sub



    Private Sub rbtnTempSensor_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTempSensor.CheckedChanged
        'temp radio button

        Call DisplayProduction(1)
    End Sub


    Private Sub rbtnPressureSensor_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPressureSensor.CheckedChanged
        'pressure sensor radio button

        Call DisplayProduction(0)
    End Sub


    Private Sub Production_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'production load form

        a = 0

        FileOpen(5, "Production - Production.csv", OpenMode.Input)

        Input(5, TempNumOfPartsProduce)
        Input(5, TempTypeOfPart)
        Input(5, TempManufacturer)

        Do Until EOF(5)

            ReDim Preserve NumOfPartsProduce(0 To a)
            ReDim Preserve Part(0 To a)
            ReDim Preserve Manufacturer(0 To a)

            Input(5, NumOfPartsProduce(a))
            Input(5, Part(a))
            Input(5, Manufacturer(a))

            a = a + 1

        Loop

        ProductionTotalInArray = a
        FileClose(5)
    End Sub
End Class