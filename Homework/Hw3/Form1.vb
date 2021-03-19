Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Enter button

        QuizScore = TextBox1.Text

        If QuizScore >= 70 Then
            TotalNumQuizScores = TotalNumQuizScores + QuizScore
            TotalNumScores = TotalNumScores + 1
            NumOfCOrBetter = NumOfCOrBetter + 1

            If QuizScore > MaxValue Then 'to find max value 
                MaxValue = QuizScore
            ElseIf MaxValue < QuizScore Then 'compares maxvalue to current quize score 
                MaxValue = QuizScore
            End If

            If QuizScore < minValue Then 'to find min value
                minValue = QuizScore
            ElseIf minValue < QuizScore Then 'compares minvalue to current quize score
                minValue = minValue
            End If

        End If

        If QuizScore < 70 Then
            TotalNumQuizScores = TotalNumQuizScores + QuizScore
            TotalNumScores = TotalNumScores + 1

            If QuizScore > MaxValue Then 'to find max value
                MaxValue = QuizScore
            ElseIf MaxValue < QuizScore Then 'compares maxvalue to current quize score
                MaxValue = QuizScore
            End If

            If QuizScore < minValue Then 'to find min value
                minValue = QuizScore
            ElseIf minValue < QuizScore Then 'compares minvalue to current quize score
                minValue = minValue
            End If

        End If

        'these two operations enables multiple inputs within textbox1
        TextBox1.Text = ""
        TextBox1.Focus()

        'output values
        HighestScore = MaxValue
        LowestScore = minValue
        AvgScore = TotalNumQuizScores / TotalNumScores

        Format(AvgScore, "0.00")



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Summary button
        Form2.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Clear Button
        TextBox1.Text = ""
    End Sub
End Class
