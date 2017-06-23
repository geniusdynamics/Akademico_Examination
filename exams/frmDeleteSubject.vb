Public Class frmDeleteSubject

    Private Sub frmDeleteSubject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            load_subjects()
        End If
    End Sub
    Private Sub load_subjects()
        If qread("SELECT * FROM subjects ORDER BY ID") Then
            If dbreader.RecordsAffected > 0 Then
                Dim i As Integer = 0
                dgvSubjects.Rows.Clear()
                While dbreader.Read
                    dgvSubjects.Rows.Add()
                    dgvSubjects.Item("SubjID", i).Value = dbreader("ID")
                    dgvSubjects.Item("SubjectName", i).Value = dbreader("Subject")
                    dgvSubjects.Item("Abbreviation", i).Value = dbreader("Abbreviation")
                    dgvSubjects.Item("Department", i).Value = dbreader("Department")
                    i += 1
                End While
            Else
                failure("No Subject Records Found To Delete!")
                Me.Close()
            End If
        Else
            failure("Could Not Read From  Subjects Database!")
            Me.Close()
        End If
    End Sub

    Private Sub dgvSubjects_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSubjects.DoubleClick
        If confirm("Are you sure you want to delete subject?") Then
            For k As Integer = 0 To dgvSubjects.SelectedRows.Count - 1
                delete(dgvSubjects.SelectedRows.Item(k).Index)
            Next
            load_subjects()
        End If
    End Sub

    Private Function del_instances(ByVal subject As String, ByVal row As Integer) As Boolean
        If Not qwrite("ALTER TABLE `exam_results` DROP COLUMN `" & get_name(dgvSubjects.Item("Abbreviation", row).Value) & "`") Or Not qwrite("ALTER TABLE `exam_results_subjects_out_of` DROP COLUMN `" & get_name(dgvSubjects.Item("Abbreviation", row).Value) & "`") Or Not qwrite("ALTER TABLE `kcse_results` DROP COLUMN `" & get_name(dgvSubjects.Item("Abbreviation", row).Value) & "`") Or Not qwrite("ALTER TABLE `subjects_done` DROP COLUMN `" & get_name(dgvSubjects.Item("Abbreviation", row).Value) & "`") Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub delete(ByVal row As Integer)
        start()
        For k As Integer = 0 To dgvSubjects.SelectedRows.Count - 1
            If Not qwrite("DELETE FROM subjects WHERE id='" & dgvSubjects.Item("SubjID", row).Value & "'") And del_instances(dgvSubjects.Item("SubjectName", row).Value, row) Then
                rollback()
                failure("Subject Entry Deletion Failed!")
            End If
        Next
        commit()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If confirm("Are you sure you want to delete subject?") Then
            pbar.Visible = True
            Dim inc As Integer = 100 / dgvSubjects.SelectedRows.Count
            For k As Integer = 0 To dgvSubjects.SelectedRows.Count - 1
                delete(dgvSubjects.SelectedRows.Item(k).Index)
                pbar.Increment(inc)
            Next
            success("Subject(s) Entry Successfully Deleted!")
            pbar.Visible = False
            pbar.Increment(-100)
            load_subjects()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class