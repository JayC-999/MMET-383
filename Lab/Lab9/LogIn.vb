Public Class LogIn
    Private DepartmentList() As String
    Public ImageList() As String
    Private Password() As String
    Public CurrentIndexForPic As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'open file and add contents to departmentlist array
        FileOpen(1, "DepartmentList.txt", OpenMode.Input)

        ReDim Preserve DepartmentList(0 To 2)

        Input(1, DepartmentList(0))
        Input(1, DepartmentList(1))
        Input(1, DepartmentList(2))

        FileClose(1)

        'open image.text file and store the contents in the array
        Dim i As Integer = 0
        FileOpen(2, "Image.csv.txt", OpenMode.Input)

        Do Until EOF(2)
            ReDim Preserve ImageList(0 To i)
            Input(2, ImageList(i))
            i = i + 1
        Loop

        FileClose(2)

        'adding dapartmentlist contents to the listbox
        lstDivision.Items.Add(DepartmentList(0))
        lstDivision.Items.Add(DepartmentList(1))
        lstDivision.Items.Add(DepartmentList(2))

        'setting passwords 
        ReDim Preserve Password(0 To 2)

        Password(0) = "123"
        Password(1) = "456"
        Password(2) = "789"

    End Sub

    Private Sub btnCheckIn_Click(sender As Object, e As EventArgs) Handles btnCheckIn.Click
        'checking button


        Select Case lstDivision.Text
            Case "Design"
                'go to form 2 if password is right else wrong password; same will be for the other cases
                If txtCode.Text = Password(0) Then
                    CurrentIndexForPic = 0
                    Me.Hide()
                    Navigation.Show()

                Else
                    MsgBox("Incorrect Password")
                End If 'for case design

            Case "Manufacturing"
                If txtCode.Text = Password(1) Then
                    CurrentIndexForPic = 1
                    Me.Hide()
                    Navigation.Show()

                Else
                    MsgBox("Incorrect Password")
                End If 'for case manufacturing 

            Case "Sales"
                If txtCode.Text = Password(2) Then
                    CurrentIndexForPic = 2
                    Me.Hide()
                    Navigation.Show()

                Else
                    MsgBox("Incorrect Password")
                End If 'for case sales
        End Select
    End Sub
End Class
