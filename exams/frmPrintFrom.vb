Public Class frmPrintFrom

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtFrom.Text.Trim <> Nothing And txtTo.Text.Trim <> Nothing Then
            cont = True
            row_from = txtFrom.Text
            row_to = txtTo.Text
            Me.Close()
        End If
    End Sub
    Private Function isvalid() As Boolean

    End Function

    Private Sub frmPrintFrom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class