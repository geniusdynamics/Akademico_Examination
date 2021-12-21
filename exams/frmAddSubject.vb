Public Class frmAddSubject
    Dim msg As String
    Dim opt As String
    Private Function isvalid()
        If Trim(txtName.Text) = String.Empty Or IsNumeric(txtName.Text) Then
            msg = "Subject Name is invalid!"
            Return False
        ElseIf Trim(txtAbbreviation.Text) = String.Empty Then
            msg = "Subject Abbreviation is invalid!"
            Return False
        ElseIf Trim(txtCode.Text) = String.Empty Or Not IsNumeric(txtCode.Text) Then
            msg = "Subject Code Is Invalid!"
            Return False
        ElseIf cboDepartment.SelectedItem = None Then
            msg = "Invalid Values Selected For Department!"
            Return False
        ElseIf Not radCompulsory.Checked And Not radOptional.Checked Then
            msg = "Invalid Subject Comment! Compulsory Or Optional?"
            Return False
        Else
            Return True
        End If
    End Function
    Private Function LastValidColumn() As String
        qread("SELECT Abbreviation FROM subjects ORDER BY id DESC LIMIT 1")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            Return dbreader("Abbreviation")
        Else

        End If

    End Function
    Private Function get_one_subject() As String
        get_subjects()
        Return subjname(0)
    End Function
    Private Function add_instances(ByVal subject As String) As Boolean

        If Not qwrite("ALTER TABLE `exam_results` ADD COLUMN `" & get_name(escape_string(txtAbbreviation.Text)) & "` VARCHAR(255) NOT NULL DEFAULT '-' AFTER `Year`") Or Not qwrite("ALTER TABLE `kcse_results` ADD COLUMN `" & get_name(escape_string(txtAbbreviation.Text)) & "` VARCHAR(255) NOT NULL DEFAULT '-' AFTER `stream`") Or Not qwrite("ALTER TABLE `subjects_done` ADD COLUMN `" & get_name(txtAbbreviation.Text) & "` ENUM('Yes','No') NOT NULL DEFAULT 'No'") Or Not qwrite("ALTER TABLE `exam_results_subjects_out_of` ADD COLUMN `" & get_name(escape_string(txtAbbreviation.Text)) & "` DOUBLE NOT NULL DEFAULT '100' AFTER `year`") Or Not qwrite("UPDATE exam_results_subjects_out_of SET `" & get_name(escape_string(txtAbbreviation.Text)) & "`=`" & get_one_subject() & "`") Then
            Return False
        Else
            Return True
        End If
    End Function
    Dim words() As String
    Dim col As String
    Private Sub add_subject()
        start()

        col = LastValidColumn()

        If qwrite("INSERT INTO subjects VALUES(NULL,'" & escape_string(Trim(txtName.Text).ToUpper) & "','" & escape_string(Trim(txtAbbreviation.Text).ToUpper) &
        "','" & Trim(txtCode.Text) & "','" & escape_string(cboDepartment.SelectedItem) & "','" & opt & "', '--', 'Yes' )") And add_instances(txtName.Text) Then
            commit()
            success("Subject Entry Was Successful!")
        Else
            rollback()
            failure("Subject Entry Failed! Subject Exists!")
        End If
    End Sub
    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        If isvalid() Then
            If radCompulsory.Checked Then
                opt = "Compulsory"
            Else
                opt = "Optional"
            End If

            If subjects.ContainsKey(txtName.Text.ToLower()) Then
                failure("The Subject Has Already Been Added Into The System")
                Return
            ElseIf subjects.ContainsValue(txtCode.Text.ToLower()) Then
                failure("The Subject Has Already Been Used In The System")
                Return
            End If

            add_subject()
        Else
            failure(msg)
        End If
    End Sub

    Private Sub frmAddSubject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            load_dept()
        End If
    End Sub

    Dim subjects As New Dictionary(Of String, String)

    Private Sub loadSubjectsInfo()
        If qread("select subject, abbreviation from subjects;") Then
            subjects.Clear()
            While dbreader.Read
                subjects.Add(dbreader("subject").ToString().ToLower(), dbreader("abbreviation").ToString().ToLower())
            End While
            dbreader.Close()
        End If
    End Sub
    Private Sub load_dept()
        If qread("SELECT * FROM departments") Then
            cboDepartment.Items.Clear()

            While dbreader.Read
                cboDepartment.Items.Add(dbreader("department"))
            End While
            cboDepartment.SelectedItem = None
            dbreader.Close()
        Else
            failure("Could Not Read Departments Database!")
        End If
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtName.Clear()
        cboDepartment.SelectedItem = None
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


End Class