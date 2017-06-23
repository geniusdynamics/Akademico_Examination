Public Class frmSubjectsDone

    Private Sub frmSubjectsDone_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            'Dim frm As New frmSelectClass
            'frm.ShowDialog()
            'If cont Then
            '    create_dataform()
            '    load_students()
            'Else
            '    Me.Close()
            'End If

            If qread("select distinct class from class_stream") Then
                If dbreader.RecordsAffected > 0 Then
                    cboClass.Items.Clear()
                    While dbreader.Read
                        cboClass.Items.Add(dbreader("class"))
                    End While
                End If
            End If

        End If
    End Sub

    Private Sub load_students()
        qread("SELECT * FROM students WHERE Class='" & escape_string(cboClass.SelectedItem.ToString()) & "' AND IsStudent='True'")
        dgvIndexNo.Rows.Clear()
        If dbreader.RecordsAffected > 0 Then
            Dim row = New List(Of String)
            While dbreader.Read
                row.Add(dbreader("admin_no"))
                row.Add(dbreader("student_name"))
                row.Add(dbreader("Stream"))
                row.Add(dbreader("indexno"))
                dgvIndexNo.Rows.Add(row.ToArray())
                row.Clear()
                'dgvIndexNo.Rows.Add()
                'dgvIndexNo.Item("ADMNo", dgvIndexNo.Rows.Count - 1).Value = get_id(dbreader("admin_no"))
                'dgvIndexNo.Item("StudentName", dgvIndexNo.Rows.Count - 1).Value = dbreader("student_name")
                'dgvIndexNo.Item("str_class", dgvIndexNo.Rows.Count - 1).Value = dbreader("Stream")
                'dgvIndexNo.Item("IndexNo", dgvIndexNo.Rows.Count - 1).Value = dbreader("indexno")
            End While
            For k As Integer = 0 To dgvIndexNo.Rows.Count - 1
                qread("SELECT * FROM `subjects_done` WHERE ADMNo='" & dgvIndexNo.Item("ADMNo", k).Value & "'")
                If dbreader.RecordsAffected > 0 Then
                    dbreader.Read()
                    For s As Integer = 0 To subjabb.Length - 1
                        Try
                            dgvIndexNo.Item(subjname(s), k).Value = dbreader(subjname(s))
                        Catch ex As Exception

                        End Try
                    Next
                Else
                    qwrite("INSERT INTO `subjects_done`(ADMNo) VALUES('" & dgvIndexNo.Item("ADMNo", k).Value & "')")
                    For s As Integer = 0 To subjabb.Length - 1
                        dgvIndexNo.Item(subjname(s), k).value = "Yes"
                    Next
                End If
            Next
        Else
            failure("There Were No Matching Student Records For This Operation!")
            Try
                dbreader.Close()
            Catch ex As Exception

            End Try
            Me.Close()
        End If
    End Sub
    Private Sub create_dataform()
        get_subjects()
        For k As Integer = 0 To subjabb.Length - 1
            Dim column As New DataGridViewComboBoxColumn
            column.Name = subjname(k)
            column.Items.Add("Yes")
            column.Items.Add("No")
            column.Width = 55
            dgvIndexNo.Columns.Add(column)
        Next
    End Sub


    Private Sub btnEnterMarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnterMarks.Click
        For line As Integer = 0 To dgvIndexNo.Rows.Count - 1
            For k As Integer = 0 To subjabb.Length - 1
                If dgvIndexNo.Item(subjname(k), line).value <> "No" And dgvIndexNo.Item(subjname(k), line).value <> "Yes" Then
                    failure("Invalid Value For " & subjects(k) & " On Row Number " & line + 1)
                    Exit Sub
                End If
            Next
        Next
        start()
        For k As Integer = 0 To dgvIndexNo.Rows.Count - 1
            qread("SELECT * FROM `subjects_done` WHERE ADMNo='" & dgvIndexNo.Item("ADMNo", k).Value & "'")
            If dbreader.RecordsAffected > 0 Then
                dbreader.Close()
                query = "UPDATE `subjects_done` SET "
                For s As Integer = 0 To subjabb.Length - 1
                    query &= "`" & subjname(s) & "`='" & dgvIndexNo.Item(subjname(s), k).value & "'"
                    If s < subjabb.Length - 1 Then
                        query &= ", "
                    End If
                Next
                query &= " WHERE ADMNo='" & dgvIndexNo.Item("ADMNo", k).Value & "'"
                If Not qwrite(query) Then
                    rollback()
                    failure("Could Not Save The Data!")
                    Exit Sub
                End If
            Else
                dbreader.Close()
                query = "INSERT INTO `subjects_done` VALUES('" & dgvIndexNo.Item("ADMNo", k).Value & "',"
                For s As Integer = 0 To subjabb.Length - 1
                    query &= "'" & dgvIndexNo.Item(subjname(s), k).value & "',"
                    If s = subjabb.Length - 1 Then
                        query &= ")"
                    End If
                Next
                If Not qwrite(query) Then
                    rollback()
                    failure("Could Not Save The Data!")
                    Exit Sub
                End If
            End If
        Next
        commit()
        success("Student Subject Choices Successfully Saved!")
    End Sub

    Private Sub btnview_Click(sender As Object, e As EventArgs) Handles btnview.Click
        If cboClass.SelectedItem IsNot Nothing Then
            create_dataform()
            load_students()
        End If
    End Sub
End Class