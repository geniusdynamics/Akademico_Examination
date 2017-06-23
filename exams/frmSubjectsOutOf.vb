Public Class frmSubjectsOutOf

    Private Sub frmSubjectsOutOf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            If stream = "All" Then
                query = "SELECT * FROM exam_results_subjects_out_of WHERE Examination='" & escape_string(exam_name) & "' AND term='" & tm & "' AND year='" & yr & "' AND Class='" & escape_string(class_form) & "'"
            Else
                query = "SELECT * FROM exam_results_subjects_out_of WHERE Examination='" & escape_string(exam_name) & "' AND term='" & tm & "' AND year='" & yr & "' AND Class='" & escape_string(class_form) & "' AND Stream='" & escape_string(stream) & "'"
            End If
            qread(query)
            Dim i As Integer = 0
            While dbreader.Read()
                For k As Integer = 0 To subjabb.Length - 1
                    dgvSubjects.Rows.Add()
                    dgvSubjects.Item("Abbreviation", k + (i * (subjabb.Length))).Value = subjabb(k)
                    dgvSubjects.Item("Subject", k + (i * (subjabb.Length))).Value = subjects(k)
                    dgvSubjects.Item("Clas", k + (i * (subjabb.Length))).Value = dbreader("Class")
                    dgvSubjects.Item("Str", k + (i * (subjabb.Length))).Value = dbreader("Stream")
                    dgvSubjects.Item("Marks", k + (i * (subjabb.Length))).Value = dbreader(subjname(k))
                Next
                i += 1
            End While
            If Not IsAdmin() Then
                For k As Integer = 0 To dgvSubjects.Rows.Count - 1
                    If IsSubjectTeacher(dgvSubjects.Item("Subject", k).Value, dgvSubjects.Item("Clas", k).Value, dgvSubjects.Item("Str", k).Value, tm, yr) Then
                        dgvSubjects.Rows(k).ReadOnly = True
                    Else
                        dgvSubjects.Rows(k).ReadOnly = False
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        start()
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            If Not qwrite("UPDATE exam_results_subjects_out_of SET `" & dgvSubjects.Item("Abbreviation", k).Value & "`='" & dgvSubjects.Item("Marks", k).Value & "' WHERE (Examination='" & escape_string(exam_name) & "' AND term='" & tm & "' AND year='" & yr & "' AND Class='" & escape_string(dgvSubjects.Item("Clas", k).Value) & "' AND Stream='" & escape_string(dgvSubjects.Item("Str", k).Value) & "')") Then
                rollback()
                failure("Subject Total Marks Could Not Be Saved!")
                Exit Sub
            End If
        Next
        commit()
        success("Subject Total Marks Successfully Saved!")
    End Sub
End Class