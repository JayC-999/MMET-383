Public Class Form1
    Private EID() As String
    Private EName() As String
    Private BDay() As String
    Private PayRate() As String
    Private TempID As String
    Private TempName As String
    Private TempBirthday As String
    Private TempPay As String
    Private TotalInArray As Integer
    Private i As Integer
    Private TargetIndex As Integer = 0
    Private CurrentID As String


    ''' <summary>
    ''' changes may be made later; running correctly last time checked
    ''' </summary>

    Private Sub Able()

        'enables buttons when info is saved 
        btnAdd.Enabled = True
        btnDelete.Enabled = True
        btnModify.Enabled = True
        btnFstRecord.Enabled = True
        btnLastRecord.Enabled = True
        btnFindID.Enabled = True
        btnPreRecord.Enabled = True
        btnNxtRecord.Enabled = True
        btnExit.Enabled = True
    End Sub
    Private Sub Disable()

        'disables buttons when saving new info
        btnAdd.Enabled = False
        btnDelete.Enabled = False
        btnModify.Enabled = False
        btnFstRecord.Enabled = False
        btnLastRecord.Enabled = False
        btnFindID.Enabled = False
        btnPreRecord.Enabled = False
        btnNxtRecord.Enabled = False
        btnExit.Enabled = False
    End Sub
    Private Sub Save(ByVal rec As Long)
        Dim j As Long
        'open file
        FileOpen(2, "EmployeeDB.csv", OpenMode.Output)

        WriteLine(2, TempID, TempName, TempBirthday, TempPay)

        'unwanted index does not get stored in file
        For j = 0 To TotalInArray - 1
            If j <> rec Then
                WriteLine(2, EID(j), EName(j), BDay(j), PayRate(j))
            End If
        Next
        FileClose(2)

    End Sub

    Private Sub FindID(ByVal TempIndex As Integer)
        'custom sub to find ID

        TargetIndex = -1

        'loop to find ID and then set the targetindex to current index
        For k = 0 To TotalInArray - 1
            If EID(k) = TempIndex Then
                TargetIndex = k
                Exit Sub

            Else
                TargetIndex = TargetIndex
            End If
        Next k
    End Sub

    Private Sub Display(ByVal Index As Integer)

        'custom sub to show information in textboxes
        txtEEID.Text = EID(Index)
        txtEEName.Text = EName(Index)
        txtBDay.Text = BDay(Index)
        txtHrPayRate.Text = PayRate(Index)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'reading file

        On Error GoTo FileError
        FileOpen(1, "EmployeeDB.csv", OpenMode.Input)

        i = 0
        'store first row of data from the file in variables; we don't want this data in our arrays 
        Input(1, TempID)
        Input(1, TempName)
        Input(1, TempBirthday)
        Input(1, TempPay)

        Do Until EOF(1)

            'setting size of array and storing the data from the file
            ReDim Preserve EID(0 To i)
            ReDim Preserve EName(0 To i)
            ReDim Preserve BDay(0 To i)
            ReDim Preserve PayRate(0 To i)

            Input(1, EID(i))
            Input(1, EName(i))
            Input(1, BDay(i))
            Input(1, PayRate(i))

            i = i + 1

        Loop

        TotalInArray = i
        FileClose(1)
        Exit Sub

FileError:
        MsgBox("Missing File")
        Exit Sub
    End Sub

    Private Sub btnFstRecord_Click(sender As Object, e As EventArgs) Handles btnFstRecord.Click
        'first record

        Call Display(0)
    End Sub

    Private Sub btnLastRecord_Click(sender As Object, e As EventArgs) Handles btnLastRecord.Click
        'last record

        Call Display(TotalInArray - 1)
    End Sub

    Private Sub btnNxtRecord_Click(sender As Object, e As EventArgs) Handles btnNxtRecord.Click
        'next record button

        CurrentID = txtEEID.Text

        Call FindID(CurrentID)

        'this moves to the next index within the array and shows the desired info
        If TargetIndex = TotalInArray - 1 Then
            TargetIndex = 0
        Else
            TargetIndex = TargetIndex + 1
        End If

        'displays info
        Call Display(TargetIndex)
    End Sub

    Private Sub btnPreRecord_Click(sender As Object, e As EventArgs) Handles btnPreRecord.Click
        'previous record button

        CurrentID = txtEEID.Text

        Call FindID(CurrentID)

        'this moves to the previous index within the array and shows the desired info
        If TargetIndex = 0 Then
            TargetIndex = TotalInArray - 1
        Else
            TargetIndex = TargetIndex - 1
        End If
        'displays info
        Call Display(TargetIndex)
    End Sub

    Private Sub btnFindID_Click(sender As Object, e As EventArgs) Handles btnFindID.Click
        'FindID button

        'userinput is now a integer when input is given
        Dim UserInput As Integer = InputBox("Enter the Employee ID of the Employee you are seeking", "Find ID")

        Call FindID(UserInput)

        'display ID given a targetindex
        If TargetIndex = -1 Then
            MsgBox("Cannot find ID")
        Else
            Call Display(TargetIndex)
        End If


    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'add button

        Dim Last As Integer

        If btnAdd.Text = "Add" Then

            'sets new ID + 1 (e.g. 51 + 1, 52 + 1...) and clearing remaining txtboxes
            Call Disable()
            btnAdd.Enabled = True
            btnAdd.Text = "Save"
            Call Display(TotalInArray - 1)
            Last = CInt(txtEEID.Text)
            txtEEID.Text = CStr(Last + 1)
            txtEEName.Text = ""
            txtBDay.Text = ""
            txtHrPayRate.Text = ""
        Else

            'this appends to the array with user input. Note that this is not efficient and can be improved
            EID = EID.Concat({txtEEID.Text}).ToArray
            EName = EName.Concat({txtEEName.Text}).ToArray
            BDay = BDay.Concat({txtBDay.Text}).ToArray
            PayRate = PayRate.Concat({txtHrPayRate.Text}).ToArray

            'adding total elements in the array and calling respective functions to save new input data
            TotalInArray = TotalInArray + 1
            Call Save(TotalInArray)
            Call Form1_Load(sender, e)
            Call Able()


            btnAdd.Text = "Add"
        End If
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        'modify button

        CurrentID = txtEEID.Text

        Call FindID(CurrentID)

        'changing modify button to say Save
        If btnModify.Text = "Modify" Then
            Call Disable()
            btnModify.Enabled = True
            btnModify.Text = "Save"
        Else

            'modifying info given the current index and user input
            EID(TargetIndex) = txtEEID.Text
            EName(TargetIndex) = txtEEName.Text
            BDay(TargetIndex) = txtBDay.Text
            PayRate(TargetIndex) = txtHrPayRate.Text

            'may be unnecessary. Test later
            TotalInArray = TotalInArray

            'calling respective functions to save new input data
            Call Save(TotalInArray)
            Call Form1_Load(sender, e)
            Call Able()

            MsgBox("Information has been modified")
            btnAdd.Enabled = True
            btnModify.Text = "Modify"
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'delete button

        CurrentID = txtEEID.Text

        'calling function to get targetindex
        Call FindID(CurrentID)

        'calling function to update file with deleted data
        Call Save(TargetIndex)
        Call Form1_Load(sender, e)


        MsgBox("Information deleted")
        txtEEID.Text = ""
        txtEEName.Text = ""
        txtBDay.Text = ""
        txtHrPayRate.Text = ""

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'end button

        Me.Close()
        End

    End Sub
End Class
