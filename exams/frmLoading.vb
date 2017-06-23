Public Class frmLoading
    Dim i As Integer = 0
    Private Sub frmLoading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartTimer.Enabled = True
    End Sub

    Private Sub StartTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartTimer.Tick
        progressBar.Increment(5)
        i += 2
        If i >= 120 Then
            StartTimer.Enabled = False
            Me.Close()
        End If
    End Sub
End Class