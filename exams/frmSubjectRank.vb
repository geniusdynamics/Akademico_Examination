Public Class frmSubjectRank

    Private Sub frmSubjectRank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            radNone.Checked = True
            radFirst.Checked = False
            radLast.Checked = False
            txtNumber.Enabled = False
            cboSubject.Items.Add(None)
            For k As Integer = 0 To subjabb.Length - 1
                cboSubject.Items.Add(subjabb(k))
            Next
            cboSubject.SelectedItem = None
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        rank = False
        Me.Close()
    End Sub

    Private Sub btnAnalyze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyze.Click
        If cboSubject.SelectedItem <> None Then
            If (radFirst.Checked Or radLast.Checked) And Not IsNumeric(txtNumber.Text) Then
                failure("failure Value For Student Filter Number!")
                Exit Sub
            End If
            rank = True
            radF = radFirst.Checked
            radL = radLast.Checked
            Try
                rankno = txtNumber.Text
            Catch ex As Exception

            End Try
            subject = cboSubject.SelectedItem
            Me.Close()
        Else
            failure("Please Select A Subject To Analyze!")
        End If
    End Sub

    Private Sub radFirst_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radFirst.CheckedChanged
        txtNumber.Enabled = True
    End Sub

    Private Sub radLast_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLast.CheckedChanged
        txtNumber.Enabled = True
    End Sub
End Class