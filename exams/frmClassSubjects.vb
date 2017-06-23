Public Class frmClassSubjects

    Private Sub frmClassSubjects_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            get_subjects()
            cboSubject.Items.Clear()

            For k As Integer = 0 To subjabb.Length - 1
                cboSubject.Items.Add(subjects(k))
            Next
            load_class(cboClass)
        End If
    End Sub

    Private Sub cboClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        lstSubjects.Items.Clear()
        Dim i As Integer = 1
        qread("SELECT * FROM class_subjects WHERE class='" & escape_string(cboClass.SelectedItem) & "'")
        While dbreader.Read
            Dim li As New ListViewItem
            li = lstSubjects.Items.Add(i)
            li.Tag = dbreader("SubjID")
            li.SubItems.Add(dbreader("Class"))
            li.SubItems.Add(dbreader("Subject"))
            li.SubItems.Add(dbreader("Abbreviation"))
            li.SubItems.Add(dbreader("Department"))
            li.SubItems.Add(dbreader("Comment"))
            li.SubItems.Add(dbreader("Code"))
            i += 1
        End While
    End Sub

    Private Function Exists() As Boolean
        For k As Integer = 0 To lstSubjects.Items.Count - 1
            If cboSubject.SelectedItem = lstSubjects.Items.Item(k).SubItems(2).Text Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        start()
        qwrite("DELETE FROM class_subjects WHERE class='" & escape_string(cboClass.SelectedItem) & "'")
        For k As Integer = 0 To lstSubjects.Items.Count - 1
            If Not qwrite("INSERT INTO class_subjects VALUES(NULL,'" & escape_string(lstSubjects.Items.Item(k).SubItems(1).Text) & "','" & escape_string(lstSubjects.Items.Item(k).SubItems(2).Text) & "','" & escape_string(lstSubjects.Items.Item(k).SubItems(3).Text) & "','" & escape_string(lstSubjects.Items.Item(k).SubItems(4).Text) & "','" & escape_string(lstSubjects.Items.Item(k).SubItems(5).Text) & "','" & escape_string(lstSubjects.Items.Item(k).SubItems(6).Text) & "')") Then
                rollback()
                failure("Could Not Save Class Subjects!")
                Exit Sub
            End If
        Next

        commit()
        success("Class Subjects Successfully Saved!")
    End Sub



    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If lstSubjects.SelectedItems.Count > 0 Then
            If confirm("Are you sure you want to delete the selected subject from the list?") Then
                For k As Integer = lstSubjects.Items.Count - 1 To 0 Step -1
                    If lstSubjects.Items.Item(k).Selected Then
                        lstSubjects.Items.RemoveAt(k)
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Not Exists() Then
            qread("SELECT * FROM subjects WHERE subject='" & escape_string(cboSubject.SelectedItem) & "'")
            dbreader.Read()
            Dim li As New ListViewItem
            li = lstSubjects.Items.Add(dbreader("ID"))
            li.SubItems.Add(cboClass.SelectedItem)
            li.SubItems.Add(dbreader("Subject"))
            li.SubItems.Add(dbreader("Abbreviation"))
            li.SubItems.Add(dbreader("Department"))
            li.SubItems.Add(dbreader("Comment"))
            ' previous code li.SubItems.Add(dbreader("Code"))
            li.SubItems.Add(dbreader("subjectCode"))
        Else
            failure("Subject Alread Exists In The List!")
        End If
    End Sub
End Class