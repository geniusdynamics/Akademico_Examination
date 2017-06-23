Public Class frmAllStudentsPrompt
    Private Function isvalid()
        If Trim(txtName.Text) = "" Then
            msg = "Admission Number Cannot Be Empty!"
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub show_students()
        query = "SELECT admin_no, student_name, Class FROM students WHERE admin_no LIKE '%" & escape_string(txtName.Text) & "%' AND IsStudent='True'"
        If qread(query) Then
            If dbreader.RecordsAffected > 1 Then
                Dim frm As New frmAllStudents
                frm.ShowDialog()
            Else
                Try
                    dbreader.Read()
                    t_name = dbreader("student_name")
                    t_id = dbreader("admin_no")
                    cont = True
                Catch ex As Exception
                    failure("No Matching Student Records Found!")
                    cont = False
                End Try
            End If
        End If
        If cont Then
            Me.Close()
        End If
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If isvalid() Then
            show_students()
        Else
            failure(msg)
        End If
    End Sub

    Private Sub frmAllStudentsPrompt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        cont = False
        Me.Close()
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If isvalid() Then
                show_students()
            End If
        End If
    End Sub

End Class