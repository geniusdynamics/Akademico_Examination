Public Class frmWaitSlow
    Dim i As Integer = 0
    Private Sub frmWait_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblOperation.Text = operation
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(10)
        i += 5
        If i = 60 Then
            Timer1.Enabled = False
            Me.Close()
        End If
    End Sub
End Class