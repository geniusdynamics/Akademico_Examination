Public Class frmIndexNumbers

    Private Sub frmIndexNumbers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            load_code()
            load_class(cboClass)
        End If
    End Sub

    Private Sub load_code()
        qread("SELECT code FROM school_details")
        dbreader.Read()
        txtCode.Text = dbreader("code")
        dbreader.Close()
    End Sub

    Private Function index_no(ByVal adm As Integer)
        qread("SELECT indexno FROM students WHERE admin_no='" & adm & "'")
        Try
            dbreader.Read()
            index_no = dbreader("indexno")
        Catch ex As Exception
            index_no = 0
        End Try
        dbreader.Close()
    End Function
    Private Sub load_students()
        dgvIndexNo.Rows.Clear()
        qread(query)
        If dbreader.RecordsAffected > 0 Then
            Dim rows As New List(Of String)
            While dbreader.Read
                'dgvIndexNo.Rows.Add()
                'dgvIndexNo.Item("ADMNo", dgvIndexNo.Rows.Count - 1).Value = get_id(dbreader("admin_no"))
                'dgvIndexNo.Item("StudentName", dgvIndexNo.Rows.Count - 1).Value = dbreader("student_name")
                'dgvIndexNo.Item("str_class", dgvIndexNo.Rows.Count - 1).Value = dbreader("Stream")
                rows.Add(dbreader("admin_no"))
                rows.Add(dbreader("student_name"))
                rows.Add(dbreader("stream"))
                dgvIndexNo.Rows.Add(rows.ToArray())
                rows.Clear()
            End While
            dbreader.Close()
            For k As Integer = 0 To dgvIndexNo.Rows.Count - 1
                dgvIndexNo.Item("IndexNo", k).Value = index_no(dgvIndexNo.Item("ADMNo", k).Value)
            Next
        Else
            failure("There Were No Matching Student Records For This Operation!")
            Try
                dbreader.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        For k As Integer = 0 To dgvIndexNo.Rows.Count - 1
            dgvIndexNo.Item("IndexNo", k).Value = 0
        Next
    End Sub


    Private Sub btnEnterMarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnterMarks.Click

        start()
        Dim inc As Integer
        If dgvIndexNo.Rows.Count > 100 Then
            inc = dgvIndexNo.Rows.Count / 100
        Else
            inc = 100 / dgvIndexNo.Rows.Count
        End If
        For k As Integer = 0 To dgvIndexNo.Rows.Count - 1
            Dim index As String = dgvIndexNo.Item("IndexNo", k).Value
            If index.Length < 4 Then
                index = txtCode.Text & index
            End If
            If Not qwrite("UPDATE students SET indexno='" & index & "' WHERE admin_no='" & dgvIndexNo.Item("ADMNo", k).Value & "'") Then
                rollback()
                failure("Could Not Save Records!")
                ProgressBar1.Visible = False
                Exit Sub
            End If
            ProgressBar1.Increment(inc)
        Next
        commit()
        success("Records Successfully Saved!")
        ProgressBar1.Visible = False
    End Sub

    Private Sub cboClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        fill_class(cboClass.SelectedItem, cboStream)
        query = "SELECT * FROM students WHERE Class='" & escape_string(cboClass.SelectedItem) & "' AND IsStudent='True' ORDER BY indexno ASC"
        load_students()
    End Sub

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        If cboStream.SelectedItem = "All" Then
            query = "SELECT * FROM students WHERE Class='" & escape_string(cboClass.SelectedItem) & "' AND IsStudent='True' ORDER BY indexno ASC"
        Else
            query = "SELECT * FROM students WHERE Class='" & escape_string(cboClass.SelectedItem) & "' AND Stream='" & escape_string(cboStream.SelectedItem) & "' ORDER BY indexno ASC"
        End If
        load_students()
    End Sub

    Private Sub cboStream_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStream.SelectedIndexChanged
        If cboStream.SelectedItem = "All" Then
            query = "SELECT * FROM students WHERE Class='" & escape_string(cboClass.SelectedItem) & "' AND IsStudent='True'"
        Else
            query = "SELECT * FROM students WHERE Class='" & escape_string(cboClass.SelectedItem) & "' AND stream='" & escape_string(cboStream.SelectedItem) & "' AND IsStudent='True'"
        End If
        load_students()
    End Sub
End Class