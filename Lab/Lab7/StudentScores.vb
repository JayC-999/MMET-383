Public Class Form1
    'declare arrays
    Private StudentID(), StudentName() As String
    Private TestScore() As Decimal
    'declare number of students that are entered
    Private TotalNumber As Integer = 0

    Private Sub btnDisplayStudent_Click(sender As Object, e As EventArgs) Handles btnDisplayStudent.Click
        'display student button

        'setting up display output in each category
        txtDispaly.Text = "ID" & vbTab & vbTab & "Name" & vbTab & vbTab & "Score Grade"

        'displays a list of all students that were inputed
        For k = 0 To TotalNumber - 1
            txtDispaly.Text = txtDispaly.Text & vbCrLf & StudentID(k) & vbTab & vbTab & StudentName(k) & vbTab & vbTab & Format(TestScore(k), "0.00")
        Next
    End Sub

    Private Sub btnHighestScore_Click(sender As Object, e As EventArgs) Handles btnHighestScore.Click
        'highest score button

        'variables to hold highest score for student
        Dim MaxScore = TestScore(0)
        Dim MaxID = StudentID(0)
        Dim MaxName = StudentName(0)

        'for loop to find max test score and store that student's info
        For i = 0 To TotalNumber - 1
            If TestScore(i) >= MaxScore Then
                MaxScore = TestScore(i)
                MaxID = StudentID(i)
                MaxName = StudentName(i)
            End If
        Next

        'display highest test score info
        txtDispaly.Text = "Highest Score: " & vbCrLf & "ID" & vbTab & vbTab & "Name" & vbTab & vbTab & " Score Grade" & vbCrLf &
                           MaxID & vbTab & vbTab & MaxName & vbTab & vbTab & Format(MaxScore, "0.00")
    End Sub

    Private Sub btnLowestScore_Click(sender As Object, e As EventArgs) Handles btnLowestScore.Click
        'lowest score button 

        'variables to hold lowest score for student
        Dim LowScore = TestScore(0)
        Dim LowID = StudentID(0)
        Dim LowName = StudentName(0)

        'for loop to find lowest test score and store that student's info
        For k = 0 To TotalNumber - 1
            If TestScore(k) <= LowScore Then
                LowScore = TestScore(k)
                LowID = StudentID(k)
                LowName = StudentName(k)
            End If
        Next

        'display lowest test score info
        txtDispaly.Text = "Lowest Score: " & vbCrLf & "ID" & vbTab & vbTab & "Name" & vbTab & vbTab & " Score Grade" & vbCrLf &
                           LowID & vbTab & vbTab & LowName & vbTab & vbTab & Format(LowScore, "0.00")
    End Sub

    Private Sub btnSortingGrade_Click(sender As Object, e As EventArgs) Handles btnSortingGrade.Click
        'sorting button

        Dim TempID As String
        Dim TempName As String
        Dim TempScore As Decimal

        'for loop sorts each student in ascending order
        For iPass = 1 To TotalNumber - 1
            For i = 0 To TotalNumber - 2
                If TestScore(i) > TestScore(i + 1) Then 'if statment swaps each value or swaps positions within the array
                    TempID = StudentID(i)
                    TempName = StudentName(i)
                    TempScore = TestScore(i)
                    StudentID(i) = StudentID(i + 1)
                    StudentName(i) = StudentName(i + 1)
                    TestScore(i) = TestScore(i + 1)
                    StudentID(i + 1) = TempID
                    StudentName(i + 1) = TempName
                    TestScore(i + 1) = TempScore
                End If
            Next i
        Next iPass

        'preparing first row of display
        txtDispaly.Text = "ID" & vbTab & vbTab & "Name" & vbTab & vbTab & "Score Grade"

        'display students as sorted
        For j = 0 To TotalNumber - 1
            txtDispaly.Text = txtDispaly.Text & vbCrLf & StudentID(j) & vbTab & vbTab & StudentName(j) & vbTab & vbTab & Format(TestScore(j), "0.00")
        Next
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'end button
        End
    End Sub

    Private Sub btnInsertStudent_Click(sender As Object, e As EventArgs) Handles btnInsertStudent.Click
        'insert student button

        'updating array size
        ReDim Preserve StudentID(0 To TotalNumber)
        ReDim Preserve StudentName(0 To TotalNumber)
        ReDim Preserve TestScore(0 To TotalNumber)

        'updating array input values
        StudentID(TotalNumber) = txtStudentID.Text
        StudentName(TotalNumber) = txtStudentName.Text
        TestScore(TotalNumber) = CDec(txtTestScore.Text)

        'counting total number of students
        TotalNumber = TotalNumber + 1

        txtStudentName.Text = ""
        txtStudentID.Text = ""
        txtTestScore.Text = ""

        'display current student number that was inserted. ex) student 1 inserted, student 2 inserted...
        txtDispaly.Text = "Student " & TotalNumber & " inserted"
    End Sub
End Class
