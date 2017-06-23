Public Class frmAddSplitSubject

    Private Sub frmAddSplitSubject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            load_class(cboClass)
        End If
    End Sub

    Private Sub load_subjects()
        cboSubject.Items.Clear()
        If get_class_subjects(cboClass.SelectedItem) Then
            For k As Integer = 0 To subjabb.Length - 1
                cboSubject.Items.Add(subjects(k))
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cboClass.SelectedItem <> Nothing And cboSubject.SelectedItem <> Nothing And txtName.Text.Trim <> Nothing And txtAbbreviation.Text.Trim <> Nothing And IsNumeric(txtContribution.Text) Then
            '  qwrite("ALTER TABLE `split_subjects` ADD COLUMN `weighted` DOUBLE NOT NULL AFTER `contribution`;")
            start()
            If Not qwrite("INSERT INTO split_subjects VALUES(NULL, '" & escape_string(cboClass.SelectedItem) & "','" & escape_string(cboSubject.SelectedItem) & "','" & escape_string(txtName.Text) &
                          "','" & escape_string(txtAbbreviation.Text) & "', '" & txtContribution.Text & "', '" & txtWeighted.Text & "')") Or Not qwrite("ALTER TABLE `exam_split_subject_results`" &
                            "ADD COLUMN `" & get_name(cboClass.SelectedItem) & "_" & txtAbbreviation.Text & "` VARCHAR(255) NOT NULL DEFAULT '';") Then

                rollback()
                failure("Could Not Save Record!")
            Else
                commit()
                success("Record Successfully Saved!")
            End If
        Else
            failure("Please fill in the form correctly!")
        End If
    End Sub

    Private Sub cboClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        load_subjects()
    End Sub
End Class