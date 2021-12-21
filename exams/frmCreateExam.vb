Public Class frmCreateExam
    Private Sub frmCreateExam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not connect() Or Not get_subjects() Then
            Close()
        End If

        fill_years(cboYear)
        lstClass.Items.Clear()
        get_term(cboTerm)
        qread("SELECT distinct(class) from class_stream")
        While dbreader.Read

            Dim li As New ListViewItem
            li = lstClass.Items.Add(dbreader("class"))
            li.Checked = True
        End While
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub clear()
        cboTerm.SelectedItem = Nothing
        cboExamName.SelectedItem = Nothing
        chkOtherName.Checked = False
        cboExamName.Enabled = True
        txtExamName.Clear()
        txtTotal.Clear()
    End Sub

    Dim msg As String = String.Empty

    Private Function isvalid()
        If cboTerm.SelectedItem Is Nothing Then
            msg = "Invalid Selection for Term!"
            Return False
        ElseIf cboYear.SelectedItem Is Nothing Then
            msg = "Please Select The Examination Year"
            Return False
        ElseIf (cboExamName.SelectedItem Is Nothing) And Not chkOtherName.Checked Then
            msg = "Exam Name is invalid!"
            Return False
        ElseIf chkOtherName.Checked And txtExamName.Text = String.Empty Then
            msg = "Exam Name is invalid!"
            Return False
        ElseIf txtTotal.Text = String.Empty Or Not IsNumeric(txtTotal.Text) Then
            msg = "Total Marks is invalid!"
            Return False
        ElseIf exists() Then
            msg = "Examination Already Exists!"
            Return False
        ElseIf DateTimePicker1.Value.Date < Today.Date Then
            msg = "Invalid Date For Last Date Of Marks Entry"
            Return False
        Else
            Return True
        End If
    End Function

    Dim exam_name As String = String.Empty

    Private Function exists()
        If chkOtherName.Checked Then
            exam_name = Trim(txtExamName.Text)
        Else
            exam_name = cboExamName.SelectedItem
        End If
        If qread("SELECT * FROM examinations WHERE (Term='" &
        cboTerm.SelectedItem & "' AND ExamName='" & exam_name & "' AND Year='" & cboYear.SelectedItem & "')") Then
            If dbreader.Read Then
                dbreader.Close()
                Return True
            Else
                dbreader.Close()
                Return False
            End If
        Else
            failure("Could Not Correctly Confirm If Examination Already Exists!")
            Return False
        End If
    End Function

    Private Sub add_exam()
        If chkOtherName.Checked Then
            exam_name = Trim(txtExamName.Text)
        Else
            exam_name = cboExamName.SelectedItem
        End If
        start()
        If qwrite("INSERT INTO examinations VALUES(NULL, '" & cboTerm.SelectedItem & "','" & escape_string(exam_name) & "','" & Trim(txtTotal.Text) & "','" & cboYear.SelectedItem & "', '" & DateTimePicker1.Value.Year & "-" & Format(DateTimePicker1.Value.Month, "00") & "-" & Format(DateTimePicker1.Value.Day, "00") & "')") And SaveExaminedClasses() And SaveSubjectsOutOf() Then
            commit()
            success("Examination Successfully Saved!")
        Else
            rollback()
            failure("Examination Could not be successfully Saved!")
        End If
    End Sub

    Function SaveSubjectsOutOf() As Boolean
        Dim list As String = Nothing
        Dim values As String = Nothing
        For k As Integer = 0 To subjabb.Length - 1
            list &= subjname(k)
            values &= txtTotal.Text
            If k < subjabb.Length - 1 Then
                list &= ","
                values &= ","
            End If
        Next

        For k As Integer = 0 To lstClass.Items.Count - 1
            qread("SELECT `stream` FROM class_stream WHERE class='" & escape_string(lstClass.Items.Item(k).Text) & "';")
            While dbreader.Read
                If Not qwrite("INSERT INTO exam_results_subjects_out_of (id, Examination, Term, Year, Class, Stream, " & list & ") VALUES" &
                  "(NULL, '" & escape_string(exam_name) & "','" & cboTerm.SelectedItem & "','" & cboYear.SelectedItem &
                  "', '" & escape_string(lstClass.Items.Item(k).Text) & "', '" & escape_string(dbreader("stream")) & "', " & values & ")") Then
                    Return False
                End If
            End While
        Next
        Return True
    End Function

    Function SaveExaminedClasses() As Boolean
        For k As Integer = 0 To lstClass.Items.Count - 1
            If lstClass.Items.Item(k).Checked Then
                If Not qwrite("INSERT INTO examined_classes (`id`, `examination`, `term`, `year`, `class` ) VALUES(NULL, '" & escape_string(exam_name) & "', '" & cboTerm.SelectedItem & "','" & cboYear.SelectedItem & "','" & escape_string(lstClass.Items.Item(k).Text) & "')") Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub chkOtherName_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtherName.CheckedChanged
        If chkOtherName.Checked Then
            txtExamName.Enabled = True
            cboExamName.SelectedItem = Nothing
            cboExamName.Enabled = False
        Else
            txtExamName.Enabled = False
            cboExamName.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If isvalid() Then
            Try
                add_exam()
                clear()
            Catch ex As Exception
                failure(ex.Message)
            End Try
        Else
            failure(msg)
        End If
    End Sub
End Class