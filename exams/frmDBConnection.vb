Public Class frmDBConnection
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.dbName = txtDBName.Text
        My.Settings.host = txtDbHost.Text
        My.Settings.userName = txtUserName.Text
        My.Settings.passWord = txtPassword.Text
        My.Settings.Save()
        success("The Connection Was Succesfuly Saved")
    End Sub

    Private Sub frmDBConnection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDBName.Text = My.Settings.dbName
        txtDbHost.Text = My.Settings.host
        txtUserName.Text = My.Settings.userName
        txtPassword.Text = My.Settings.passWord
    End Sub
End Class