Public Class frmEditDeleteExam
    Private Sub frmEditDeleteExam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not connect() Then
            Close()
            Return
        End If

        fill_years(cboYear)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If cboExamName.SelectedItem Is Nothing Then
            If confirm("Are You Sure You Want To Delete The Examination! This Will Remove All Records Associated With The Examination!") Then
                If qwrite("DELETE FROM examinations WHERE (ExamName='" & escape_string(cboExamName.SelectedItem) & "' AND Term='" & cboTerm.SelectedItem & "' AND Year='" & cboYear.SelectedItem & "')") Then
                    success("Examination Records For The Specified Examination Have Been Successfully Deleted!")
                    fill_exam()
                Else
                    failure("Could Not Delete The Examination!")
                End If
            End If
        Else
            failure("Invalid Examination Name Selected!")
        End If


    End Sub



    Private Sub fill_exam()
        If qread("SELECT ExamName FROM examinations WHERE Term='" & cboTerm.SelectedItem & "' AND Year='" & cboYear.SelectedItem & "'") Then
            cboExamName.Items.Clear()
            txtTotal.Clear()
            txtName.Clear()
            cboExamName.SelectedItem = String.Empty
            While dbreader.Read
                cboExamName.Items.Add(dbreader("ExamName"))
            End While
            dbreader.Close()
        Else
            failure("Could Not Load Examinations!")
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboYear.SelectedIndexChanged
        If cboTerm.SelectedItem IsNot Nothing And cboYear.SelectedItem.ToString IsNot Nothing Then
            fill_exam()
        End If
    End Sub

    Private Sub cboTerm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTerm.SelectedIndexChanged
        If cboTerm.SelectedItem IsNot Nothing And cboYear.SelectedItem.ToString IsNot Nothing Then
            fill_exam()
        End If
    End Sub

    Private Sub cboExamName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboExamName.SelectedIndexChanged
        If cboExamName.SelectedItem IsNot Nothing Then
            txtName.Text = cboExamName.SelectedItem
            totalMark()
        End If

    End Sub

    Private Sub totalMark()
        If qread("SELECT Total FROM examinations WHERE (ExamName='" & escape_string(cboExamName.SelectedItem) & "' AND Term='" & cboTerm.SelectedItem & "' AND Year='" & cboYear.SelectedItem & "')") Then
            Try
                dbreader.Read()
                txtTotal.Text = dbreader("Total")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If IsNumeric(txtTotal.Text) Then
            If qwrite("UPDATE examinations SET ExamName='" & escape_string(txtName.Text) & "', Total='" & txtTotal.Text & "' WHERE (ExamName='" & escape_string(cboExamName.SelectedItem) & "' AND Term='" & cboTerm.SelectedItem & "' AND Year='" & cboYear.SelectedItem & "')") Then
                success("Examination Successfully Updated!")
                fill_exam()
            Else
                failure("Examination Could Not Be Updated!")
            End If
        End If
    End Sub
End Class