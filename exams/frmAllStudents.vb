Public Class frmAllStudents

    Private Sub frmAllStudents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If qread(query) Then
            If dbreader.RecordsAffected > 0 Then
                Dim i As Integer = 0
                While dbreader.Read
                    dgvStudents.Rows.Add()
                    dgvStudents.Item("ADMNo", i).Value = dbreader("ADMNo")
                    dgvStudents.Item("StudentName", i).Value = dbreader("LastName") &
                    " " & dbreader("FirstName") & " " & dbreader("MiddleName")
                    class_form = dbreader("CurrentClass")
                    i += 1
                End While
                cont = True
            Else
                failure("No Matching Student Records Found!")
                cont = False
                Me.Close()
            End If
            dbreader.Close()
        End If
    End Sub

    Private Sub dgvStudents_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvStudents.DoubleClick
        t_id = dgvStudents.Item("ADMNo", dgvStudents.SelectedRows.Item(0).Index).Value
        t_name = dgvStudents.Item("StudentName", dgvStudents.SelectedRows.Item(0).Index).Value
        Me.Close()
    End Sub
End Class