Public Class frmResultMeanAnalysis

    Private Sub frmResultMeanAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            lstExaminations.Items.Clear()
            grpMultiExaminations.Enabled = True
            fill_year()
            get_term()
            load_class(cboClass)
            cboTerm.SelectedItem = term
            cboYear.SelectedItem = Today.Year
            cboSelectedTerm.SelectedItem = term
        End If
    End Sub

    Private Sub fill_year()
        cboYear.Items.Clear()
        cboSelectedYear.Items.Clear()
        fill_years(cboYear)
        fill_years(cboSelectedYear)
        cboYear.SelectedItem = Today.Year
        cboSelectedYear.SelectedItem = Today.Year
    End Sub

    Private Sub btnAddExam_Click(sender As Object, e As EventArgs) Handles btnAddExam.Click
        add_exam()
    End Sub

    Private Function exists(ByVal str As String)
        Dim i As Integer
        Dim selectedTerm As String = String.Empty

        For i = 0 To lstExaminations.Items.Count - 1
            If lstExaminations.Items.Item(i).Text = str And lstExaminations.Items.Item(i).SubItems(2).Text = cboYear.SelectedItem And lstExaminations.Items.Item(i).SubItems(1).Text = cboTerm.SelectedItem Then
                MsgBox("The Exam Already Exist In The List")
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub fill_exam()
        If qread("SELECT ExamName FROM examinations WHERE Term='" & cboTerm.SelectedItem & "' AND Year='" & cboYear.SelectedItem & "'") Then
            cboExamName.Items.Clear()
            cboExamName.Items.Add(None)
            While dbreader.Read
                cboExamName.Items.Add(dbreader("ExamName"))
            End While
            cboExamName.SelectedItem = None
            dbreader.Close()
        Else
            failure("Could Not Load Examinations!")
        End If
    End Sub

    Private Sub add_exam()
        If cboExamName.SelectedItem <> None Then
            If Not exists(cboExamName.SelectedItem) Then
                Dim li As New ListViewItem
                li = lstExaminations.Items.Add(cboExamName.SelectedItem)
                li.SubItems.Add(cboTerm.SelectedItem)
                li.SubItems.Add(cboYear.SelectedItem)
            End If
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboYear.SelectedIndexChanged
        If cboTerm.SelectedItem <> None And cboYear.SelectedItem.ToString <> None Then
            fill_exam()
        End If
    End Sub

    Private Sub cboTerm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTerm.SelectedIndexChanged
        If cboTerm.SelectedItem <> None And cboYear.SelectedItem.ToString <> None Then
            fill_exam()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnEnterMarks_Click(sender As Object, e As EventArgs) Handles btnEnterMarks.Click
        If lstExaminations.Items.Count = 0 Then
            MsgBox("There Are No Exams To Analyze")
        ElseIf cboClass.SelectedItem = Nothing Then
            MsgBox("Please Select The Class")
            'todo add condition to check whether grading scheme exists
        ElseIf cboSortBy.SelectedItem = String.Empty And cboSortBy.Visible Then
            MsgBox("Please Choose The Mode To Sort The Result Analysis!")
        Else

            If rdSubjectBased.Checked = True Then
                gradingType = "SubjectBased"
            Else
                gradingType = "ClassBased"
            End If

            selectedTerm = cboSelectedTerm.SelectedItem.ToString()
            selectedClass = cboClass.SelectedItem.ToString()
            selectedYear = cboSelectedYear.SelectedItem.ToString()
            sortGradesBy = cboSortBy.SelectedItem.ToString()

            tm = cboTerm.SelectedItem
            yr = cboYear.SelectedItem

            examList = New List(Of Tuple(Of String, String, String))

            For i = 0 To lstExaminations.Items.Count - 1
                examList.Add(New Tuple(Of String, String, String)(lstExaminations.Items.Item(i).Text, lstExaminations.Items.Item(i).SubItems(1).Text, lstExaminations.Items.Item(i).SubItems(2).Text))
            Next

            subjectColumns = New List(Of String)
            qread("SHOW COLUMNS FROM subjects_done;")
            Dim columns As String = String.Empty
            While dbreader.Read
                columns = dbreader("Field")

                If columns <> "ADMNo" Then
                    subjectColumns.Add(columns)
                End If
            End While

            Me.Close()
            Dim meanResultForm As New frmMeanResults
            meanResultForm.MdiParent = frmMainForm
            meanResultForm.Show()

        End If
    End Sub


End Class