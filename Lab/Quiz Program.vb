Public Class Form1
    Public Question1 As String
    Public Question2 As String
    Public Question3 As String
    Public QuestionNum As Integer
    Public QuestionAsked As Integer = 0
    Public QuestionRight As Integer = 0
    Public PercentRight As Decimal = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Display first question

        QuestionNum = 1
        Label1.Text = "Question #1"
        Question1 = "Can a VB project Have more than one form (Y/N)?"
        RichTextBox1.Text = Question1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Check Answer Button

        'case statment for each question 
        Select Case QuestionNum
            Case = 1
                'do question 1
                If TextBox1.Text = "Y" Or TextBox1.Text = "y" Then
                    Label2.Visible = True
                    Label2.Text = "You are correct!!"
                    QuestionRight = QuestionRight + 1

                    'outpur results
                    QuestionAsked = QuestionAsked + 1
                    PercentRight = QuestionRight / QuestionAsked
                    RichTextBox2.Text = "Questions Right: " & QuestionRight & vbCrLf &
                                        "Questions Asked: " & QuestionAsked & vbCrLf &
                                        "Percentage Right: " & Format(PercentRight, "0.00%")

                ElseIf TextBox1.Text = "N" Or TextBox1.Text = "n" Then
                    Label2.Visible = True
                    Label2.Text = "Wrong."

                    'output results
                    QuestionAsked = QuestionAsked + 1
                    PercentRight = QuestionRight / QuestionAsked
                    RichTextBox2.Text = "Questions Right: " & QuestionRight & vbCrLf &
                                        "Questions Asked: " & QuestionAsked & vbCrLf &
                                        "Percentage Right: " & Format(PercentRight, "0.00%")

                Else
                    MsgBox("Please input Y or N")

                End If

            Case = 2
                'do question 2

                If TextBox1.Text = "T" Or TextBox1.Text = "t" Then
                    Label2.Visible = True
                    Label2.Text = "You are correct!!"
                    QuestionRight = QuestionRight + 1

                    'output results
                    QuestionAsked = QuestionAsked + 1
                    PercentRight = QuestionRight / QuestionAsked
                    RichTextBox2.Text = "Questions Right: " & QuestionRight & vbCrLf &
                                        "Questions Asked: " & QuestionAsked & vbCrLf &
                                        "Percentage Right: " & Format(PercentRight, "0.00%")

                ElseIf TextBox1.Text = "F" Or TextBox1.Text = "f" Then
                    Label2.Visible = True
                    Label2.Text = "Wrong."

                    'output results
                    QuestionAsked = QuestionAsked + 1
                    PercentRight = QuestionRight / QuestionAsked
                    RichTextBox2.Text = "Questions Right: " & QuestionRight & vbCrLf &
                                        "Questions Asked: " & QuestionAsked & vbCrLf &
                                        "Percentage Right: " & Format(PercentRight, "0.00%")
                Else
                    MsgBox("Please input T or F")

                End If

            Case = 3
                'do question 3

                Label3.Visible = True
                Label3.Text = "End of Quiz"

                If TextBox1.Text = "T" Or TextBox1.Text = "t" Then
                    Label2.Text = "Wrong"

                    'output result 
                    QuestionAsked = QuestionAsked + 1
                    PercentRight = QuestionRight / QuestionAsked
                    RichTextBox2.Text = "Questions Right: " & QuestionRight & vbCrLf &
                                        "Questions Asked: " & QuestionAsked & vbCrLf &
                                        "Percentage Right: " & Format(PercentRight, "0.00%")


                ElseIf TextBox1.Text = "F" Or TextBox1.Text = "f" Then
                    Label2.Text = "You Are Right!!"
                    QuestionRight = QuestionRight + 1

                    'output result

                    QuestionAsked = QuestionAsked + 1
                    PercentRight = QuestionRight / QuestionAsked
                    RichTextBox2.Text = "Questions Right: " & QuestionRight & vbCrLf &
                                        "Questions Asked: " & QuestionAsked & vbCrLf &
                                        "Percentage Right: " & Format(PercentRight, "0.00%")
                Else
                    MsgBox("Please input T of F")

                End If
        End Select
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Exit Button

        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Next Question Button

        'clears textbox after each question
        TextBox1.Text = ""

        'this statment determines the question number ex.) question 1...
        If QuestionNum < 3 Then
            QuestionNum = QuestionNum + 1
        Else
            QuestionNum = 3
        End If

        'preparing next questions
        Question2 = "T/F: A label is a control that permits user input."
        Question3 = "T/F: The '/ ' symbol is used for comments in VB."

        Select Case QuestionNum
            Case = 2
                Label1.Text = "Question #2"
                RichTextBox1.Text = Question2
            Case = 3
                Label1.Text = "Question #3"
                RichTextBox1.Text = Question3
        End Select
    End Sub
End Class
