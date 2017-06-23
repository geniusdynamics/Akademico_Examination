Public Class frmHeadTeacherComments
    Private Sub frmHeadTeacherComments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not connect() Then
            Close()
        End If
    End Sub

    Dim recordID As String = ""

    Private Sub check()
        If cboTrend.SelectedItem IsNot Nothing Then
            qread("SELECT id,comment FROM head_teachers_comments WHERE trend='" & cboTrend.SelectedItem &
                  "'")
            If dbreader.RecordsAffected > 0 Then
                btnSave.Text = "Update"
                dbreader.Read()
                recordID = dbreader("id")
                txtComment.Text = dbreader("comment")
                dbreader.Close()
            Else
                btnSave.Text = "Save"
                dbreader.Close()
            End If
        End If
    End Sub

    Private Sub cboTrend_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTrend.SelectedIndexChanged
        check()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If verify() Then
            If btnSave.Text = "Save" Then
                If qwrite("INSERT INTO head_teachers_comments VALUES(NULL, '" & cboTrend.SelectedItem & "','" & escape_string(txtComment.Text) & "')") Then
                    success("Comments Successfully Saved!")
                    btnSave.Text = "Update"
                Else
                    failure("Could not save comments")
                End If
            Else
                If qwrite("UPDATE head_teachers_comments SET comment='" & escape_string(txtComment.Text) & "' WHERE id='" & recordID & "'") Then
                    success("Comments Update Successfully Saved!")
                    check()
                Else
                    failure("could not save comments")
                End If
            End If
        End If
    End Sub

    Private Function verify() As Boolean
        If String.IsNullOrEmpty(txtComment.Text) Then
            ErrorProvider1.SetError(txtComment, "Please Enter The Performance Comment")
            successful = False
        ElseIf cboTrend.SelectedItem Is Nothing Then
            ErrorProvider1.SetError(cboTrend, "Please Select The Performance Trend")
            successful = False
        Else
            successful = True
        End If

        Return successful
    End Function
End Class