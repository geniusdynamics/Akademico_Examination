Public Class frmPerformanceComments
    Private Sub frmPerformanceComments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not connect() Then
            Close()
        Else
            load_class(cboClass)
            load_stream(cboStream)
        End If
    End Sub

    Private Function verify() As Boolean
        If cboClass.SelectedItem Is Nothing Then
            ErrorProvider1.SetError(cboClass, "Please Select The Class")
            successful = False
        ElseIf cboStream.SelectedItem Is Nothing Then
            ErrorProvider1.SetError(cboStream, "Please Select The Stream")
            successful = False
        ElseIf cboTrend.SelectedItem Is Nothing Then
            ErrorProvider1.SetError(cboTrend, "Please Select The Performance Trend")
            successful = False
        ElseIf txtComment.Text = "" Then
            ErrorProvider1.SetError(txtComment, "Please Enter The Performance Comments")
            successful = False
        Else
            successful = True
        End If
        Return successful
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If verify() Then
            'todo foreign key reference for the class and stream on update cascade on delete cascade
            If btnSave.Text = "Save" Then
                If qwrite("INSERT INTO class_teachers_comments VALUES(NULL, '" & escape_string(cboClass.SelectedItem) & "', '" & escape_string(cboStream.SelectedItem) &
             "', '" & cboTrend.SelectedItem & "','" & escape_string(txtComment.Text) & "')") Then
                    success("Comments Successfully Saved!")
                    btnSave.Text = "Update"
                Else
                    failure("Could Not Save The Details!")
                End If
            Else
                If qwrite("UPDATE class_teachers_comments SET comment='" & escape_string(txtComment.Text) & "' WHERE id='" & recordId & "'") Then
                    success("Comments Update Successful!")
                    check()
                Else
                    failure("Could Not Save The Details!")
                End If
            End If
        End If
    End Sub

    Dim recordId As String

    Private Sub check()
        If cboClass.SelectedItem IsNot Nothing And cboStream.SelectedItem IsNot Nothing And cboTrend.SelectedItem IsNot Nothing Then
            qread("SELECT id,comment FROM class_teachers_comments WHERE (class='" & escape_string(cboClass.SelectedItem) &
                  "' AND stream='" & escape_string(cboStream.SelectedItem) & "' AND trend='" & cboTrend.SelectedItem &
                  "')")
            If dbreader.RecordsAffected > 0 Then
                btnSave.Text = "Update"
                dbreader.Read()
                recordId = dbreader("id")
                txtComment.Text = CType(dbreader("comment"), String)
                dbreader.Close()
            Else
                btnSave.Text = "Save"
                dbreader.Close()
            End If
        End If
    End Sub

    Private Sub cboStream_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStream.SelectedIndexChanged
        check()
    End Sub

    Private Sub cboClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClass.SelectedIndexChanged
        check()
    End Sub

    Private Sub cboTrend_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTrend.SelectedIndexChanged
        check()
    End Sub
End Class