Public Class frmSplitSubjects

    Private Sub frmSplitSubjects_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            load_subjects()
        End If
    End Sub
    Private Sub load_subjects()
        lstSubjects.Items.Clear()
        'todo commented the below code not sure what the repurcsion are
        ' qwrite("ALTER TABLE `split_subjects` ADD COLUMN `weighted` DOUBLE NOT NULL AFTER `contribution`;")
        qread("SELECT * FROM split_subjects")
        While dbreader.Read
            Dim li As New ListViewItem
            li = lstSubjects.Items.Add(dbreader("class"))
            li.SubItems.Add(dbreader("subject"))
            li.SubItems.Add(dbreader("name"))
            li.SubItems.Add(dbreader("Abbreviation"))
            li.SubItems.Add(dbreader("contribution"))
            li.SubItems.Add(dbreader("weighted"))
            li.Tag = dbreader("id")
        End While
    End Sub

    Private Sub lstSubjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSubjects.DoubleClick
        t_id = lstSubjects.Items.Item(lstSubjects.SelectedItems.Item(0).Index).Tag
        Dim frm As New frmEditSplitSubject
        frm.ShowDialog()
        load_subjects()
    End Sub
End Class