Public Class frmSubjectRankPrompt2
    Private Sub frmSubjectRankPrompt2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        radFirst.Checked = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAnalyze_Click(sender As Object, e As EventArgs) Handles btnAnalyze.Click
        If Not IsNumeric(txtNumber.Text) Then
            If radNone.Checked = True Then
                filterType = "None"
            Else
                MsgBox("Please enter the result limit or the value is not a number")
                Return
            End If
        Else
            rankno = txtNumber.Text
            If radFirst.Checked = True Then
                filterType = "Top"
            ElseIf radLast.Checked = True Then
                filterType = "Bottom"
            Else
                filterType = "None"
            End If

        End If

        Dim bestSubject As New frmBestStudentSubject
        bestSubject.ShowDialog()

        Me.Close()

    End Sub
End Class