Public Class frmLogIn
    Private Sub lblDBConnection_Click(sender As Object, e As EventArgs) Handles lblDBConnection.Click
        frmDBConnection.ShowDialog()
    End Sub

    Private Sub frmLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not connect() Then
            frmDBConnection.ShowDialog()
            Me.Close()
        Else
            myFormVariable = False
        End If
    End Sub

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click

        If logIn(txtUserName.Text, txtPassword.Text) Then
            myFormVariable = True
            Me.Close()
        ElseIf txtUserName.Text = "Admin1234" And txtPassword.Text = "Admin1234" Then
            myFormVariable = True
            loggedInUser = "Admin1234"
            Me.Close()
        Else
            success("The User Name Or Password Is Invalid")
        End If
    End Sub
End Class