Public Class Form1
    Private UserName As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Greet Button

        UserName = TextBox1.Text

        If RadioButton1.Checked = True Or RadioButton2.Checked = True Then
            If UserName <> "" Then 'checking to see if username is not empty 
                If RadioButton1.Checked = True Then
                    RichTextBox1.Text = "Dear Mr. " & UserName
                Else
                    RichTextBox1.Text = "Dear Mrs. " & UserName
                End If 'end if else, string, and radio button 1
            Else
                MsgBox("Please enter a last name")
            End If 'end string check
        Else
            MsgBox("Please choose a gender")
        End If 'end radio check

    End Sub
End Class
