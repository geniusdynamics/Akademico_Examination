Public Class frmModifySubject
    Dim msg As String
    Dim state As Boolean = False
    Private Sub frmModifySubject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            load_subjects()
            load_dept()
        End If
    End Sub
    Private Sub load_dept()
        If qread("SELECT * FROM departments") Then
            While dbreader.Read
                cboDepartment.Items.Add(dbreader("department"))
            End While
            cboDepartment.SelectedItem = None
            dbreader.Close()
        Else
            failure("Could Not Read From Departments Database!")
        End If
    End Sub
    Private Sub load_subjects()
        state = False
        If qread("SELECT * FROM subjects") Then
            Dim i As Integer = 0
            dgvSubjects.Rows.Clear()
            While dbreader.Read
                dgvSubjects.Rows.Add()
                dgvSubjects.Item("SubjID", i).Value = dbreader("ID")
                dgvSubjects.Item("SubjectName", i).Value = dbreader("Subject")
                dgvSubjects.Item("Code", i).Value = dbreader("subjectCode")
                dgvSubjects.Item("Abbreviation", i).Value = dbreader("Abbreviation")
                dgvSubjects.Item("Department", i).Value = dbreader("Department")
                dgvSubjects.Item("Comment", i).Value = dbreader("Comment")
                i += 1
            End While
            dbreader.Close()
        Else
            failure("Could Not Read From Subjects Database!")
        End If
        state = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtName.Clear()
        txtAbbreviation.Clear()
        cboDepartment.SelectedItem = None
    End Sub
    Private Function isvalid()
        If Trim(txtName.Text) = "" Or IsNumeric(txtName.Text) Then
            msg = "Subject Name is invalid!"
            Return False
        ElseIf Trim(txtAbbreviation.Text) = "" Then
            msg = "Subject Abbreviation is invalid!"
            Return False
        ElseIf Trim(txtCode.Text) = "" Or Not IsNumeric(txtCode.Text) Then
            msg = "Subject Code Is Invalid!"
            Return False
        ElseIf cboDepartment.SelectedItem = None Then
            msg = "Invalid Values Selected For Department!"
            Return False
        ElseIf Not radCompulsory.Checked And Not radOptional.Checked Then
            msg = "Comment On Subject is Not Valid!"
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub up_date()
        Dim comment As String
        If radCompulsory.Checked Then
            comment = "Compulsory"
        Else
            comment = "Optional"
        End If
        start()
        If qwrite("UPDATE subjects SET `Subjectcode`='" & Trim(txtCode.Text) & "', Subject='" & escape_string(Trim(txtName.Text).ToUpper) & "',Abbreviation='" & escape_string(Trim(txtAbbreviation.Text).ToUpper) &
         "',Department='" & escape_string(cboDepartment.SelectedItem) & "', Comment='" & comment & "' WHERE ID ='" & dgvSubjects.Item("SubjID", dgvSubjects.SelectedRows.Item(0).Index).Value & "'") And update_instances(txtAbbreviation.Text) Then
            commit()
            success("Subject Update Was Successful!")
        Else
            rollback()
            failure("Subject Update Failed! Duplicate Entry For Subject Details!")
        End If
    End Sub
    Dim subjectfrom As String
    Private Function update_instances(ByVal subjectto As String) As Boolean
        subjectto = get_name(subjectto)
        If Not qwrite("ALTER TABLE `exam_results` CHANGE `" & get_name(subjectfrom) & "` `" & get_name(subjectto) & "` VARCHAR(255) NOT NULL DEFAULT '-'") Or Not qwrite("ALTER TABLE `exam_results_subjects_out_of` CHANGE `" & get_name(subjectfrom) & "` `" & get_name(subjectto) & "` DOUBLE NOT NULL DEFAULT '100'") Or Not qwrite("ALTER TABLE `kcse_results` CHANGE `" & get_name(subjectfrom) & "` `" & get_name(subjectto) & "` VARCHAR(255) NOT NULL DEFAULT '-'") Or Not qwrite("ALTER TABLE `subjects_done` CHANGE `" & get_name(subjectfrom) & "` `" & get_name(subjectto) & "` ENUM('Yes','No') NOT NULL DEFAULT 'Yes'") Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If isvalid() Then
            up_date()
            load_subjects()
            fill()
        Else
            failure(msg)
        End If
    End Sub

    Private Sub dgvSubjects_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSubjects.CellEnter
        If state Then
            fill()
        End If
    End Sub
    Dim subject_full As String
    Private Sub fill()
        Try
            txtName.Text = dgvSubjects.Item("SubjectName", dgvSubjects.SelectedRows.Item(0).Index).Value
            txtAbbreviation.Text = dgvSubjects.Item("Abbreviation", dgvSubjects.SelectedRows.Item(0).Index).Value
            txtCode.Text = dgvSubjects.Item("Code", dgvSubjects.SelectedRows.Item(0).Index).Value.ToString
            subjectfrom = txtAbbreviation.Text
            subject_full = txtName.Text
            cboDepartment.SelectedItem = dgvSubjects.Item("Department", dgvSubjects.SelectedRows.Item(0).Index).Value
            If dgvSubjects.Item("Comment", dgvSubjects.SelectedRows.Item(0).Index).Value = "Compulsory" Then
                radCompulsory.Checked = True
            Else
                radOptional.Checked = True
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub dgvSubjects_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSubjects.Click
        fill()
    End Sub
End Class