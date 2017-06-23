Public Class frmEditSplitSubject

    Private Sub frmAddSplitSubject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            load_class(cboClass)
            'todo commented the below code not sure what the repurcsion are
            ' qwrite("ALTER TABLE `split_subjects` ADD COLUMN `weighted` DOUBLE NOT NULL AFTER `contribution`;")
            qread("SELECT * FROM split_subjects WHERE id=" & t_id)
            dbreader.Read()
            Dim subject As String = dbreader("subject")
            names = dbreader("Abbreviation")
            txtAbbreviation.Text = dbreader("Abbreviation")
            txtContribution.Text = dbreader("Contribution")
            txtWeighted.Text = dbreader("weighted")
            txtName.Text = dbreader("Name")
            cboClass.SelectedItem = dbreader("Class")
            cboSubject.SelectedItem = subject
        End If
    End Sub
    Dim names As String = Nothing
    Private Sub load_subjects()
        cboSubject.Items.Clear()
        get_class_subjects(cboClass.SelectedItem)
        For k As Integer = 0 To subjabb.Length - 1
            cboSubject.Items.Add(subjects(k))
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cboSubject.SelectedItem <> Nothing And txtName.Text.Trim <> Nothing And txtAbbreviation.Text.Trim <> Nothing And IsNumeric(txtContribution.Text) Then
            start()
            If Not qwrite("UPDATE split_subjects SET class='" & escape_string(cboClass.SelectedItem) & "', subject='" & escape_string(cboSubject.SelectedItem) & "',name='" & escape_string(txtName.Text) &
                          "',abbreviation='" & escape_string(txtAbbreviation.Text) & "', contribution='" & txtContribution.Text & "', weighted='" & txtWeighted.Text & "' WHERE id=" & t_id) Or Not qwrite("ALTER TABLE `exam_split_subject_results`" &
                            "CHANGE `" & get_name(cboClass.SelectedItem) & "_" & names & "` `" & get_name(cboClass.SelectedItem) & "_" & txtAbbreviation.Text & "` VARCHAR(255) NOT NULL DEFAULT '';") Then
                rollback()
                failure("Could Not Save Record!")
            Else
                commit()
                success("Record Successfully Saved!")
                Me.Close()
            End If
        Else
            failure("Please fill in the form correctly!")
        End If
    End Sub

    Private Sub cboClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        load_subjects()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If cboSubject.SelectedItem <> Nothing And txtName.Text.Trim <> Nothing And txtAbbreviation.Text.Trim Then
            If displayConfirmationMessage("Are You Sure You Want To Delete This Subject ?") Then
                If qwrite("ALTER TABLE exam_split_subject_results DROP COLUMN " + txtName.Text + ";") And qwrite("delete from split_subjects where subject = '" + cboSubject.SelectedItem.ToString() + "' and name = '" + txtName.Text + "' and abbreviation = '" + txtAbbreviation.Text + "' ") Then
                    MsgBox("The Operation Was Successful")
                End If
            End If
        Else
            failure("Please fill in the form correctly!")
        End If
    End Sub
End Class