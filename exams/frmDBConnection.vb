Public Class frmDBConnection
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.dbName = txtDBName.Text
        My.Settings.host = txtDbHost.Text
        My.Settings.userName = txtUserName.Text
        My.Settings.passWord = txtPassword.Text
        My.Settings.dPport = txtDbPort.Text
        My.Settings.API = txtAPI.Text
        My.Settings.APIUserName = txtAPIUserName.Text
        My.Settings.Sender = txtSender.Text
        My.Settings.Save()
        success("The Connection Was Succesfuly Saved")
        Me.Close()
    End Sub

    Private Sub frmDBConnection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDBName.Text = My.Settings.dbName
        txtDbHost.Text = My.Settings.host
        txtUserName.Text = My.Settings.userName
        txtPassword.Text = My.Settings.passWord
        txtDbPort.Text = My.Settings.dPport
        txtAPI.Text = My.Settings.API
        txtSender.Text = My.Settings.Sender
        txtAPIUserName.Text = My.Settings.APIUserName
    End Sub

    Private Sub defaultConnString_Click(sender As Object, e As EventArgs) Handles defaultConnString.Click
        Me.txtDBName.Text = "schoolss"
        Me.txtDbHost.Text = "localhost"
        Me.txtPassword.Text = String.Empty
        Me.txtUserName.Text = "root"
        Me.txtDbPort.Text = "7474"
    End Sub
End Class