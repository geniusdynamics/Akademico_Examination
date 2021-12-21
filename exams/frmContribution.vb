Public Class frmContribution

    Private Sub frmContribution_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not connect() Then
            Me.Close()
        Else
            total_percentage = 0
            txtContribution.Clear()
            lstExaminations.Items.Clear()
            grpMultiExaminations.Enabled = True
            fill_year()
            get_term()
            load_class(cboClass)
            cboTerm.SelectedItem = term
            txtContribution.Text = 0
            cboSelectedTerm.SelectedItem = term
        End If
    End Sub

    Private Sub fill_year()
        cboYear.Items.Clear()
        cboSelectedYear.Items.Clear()
        fill_years(cboYear)
        fill_years(cboSelectedYear)
        cboYear.SelectedItem = Today.Year
        cboSelectedTerm.SelectedItem = Today.Year
    End Sub

    Private Sub btnAddExam_Click(sender As Object, e As EventArgs) Handles btnAddExam.Click
        If isvalid() Then
            add_exam()
        Else
            MsgBox(msg)
        End If

    End Sub

    Private Function getExamContribution() As String
        Dim contribution As String = String.Empty
        If qread("select total from examinations where term = '" + cboTerm.SelectedItem.ToString + "' and year = '" + cboYear.SelectedItem.ToString + "' and examname = '" + cboExamName.SelectedItem.ToString + "'") Then
            While dbreader.Read
                contribution = dbreader("total")
            End While
        End If
        Return contribution
    End Function

    Dim total_percentage As Double = 0
    Dim msg As String = String.Empty
    Private Function isvalid()

        Dim buffer As Double = 0
        buffer = total_percentage + txtContribution.Text
        If buffer > 100 Then
            msg = "The Examination Contributions Must Not Exceed 100%"
            Return False
        End If

        If Not IsNumeric(cboYear.SelectedItem) Then
            msg = "Invalid Selection For Year!"
            Return False
        ElseIf cboTerm.SelectedItem = None Then
            msg = "Invalid Selection for Term!"
            Return False
        ElseIf cboExamName.SelectedItem = None Then
            msg = "Invalid Selection For Exam Name!"
            Return False
        ElseIf Not IsNumeric(txtContribution.Text) Then
            msg = "The Value For Contribution Is Not A Number"
            Return False
        ElseIf txtContribution.Text = 0 Then
            msg = "Contribution Can Not Be Zero"
            Return False
        Else
            Return True
        End If

    End Function

    Private Function isValidSave()
        If cboClass.SelectedItem = Nothing Or cboClass.SelectedItem = None Then
            msg = "Invalid Selection For Class!"
            Return False
        ElseIf cboSortBy.SelectedItem = String.Empty And cboSortBy.Visible Then
            msg = "Please Choose The Mode To Sort The Result Analysis!"
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub add_exam()
        'todo add method to get the exam out of
        If cboExamName.SelectedItem <> None And IsNumeric(txtContribution.Text) And txtContribution.Text <> String.Empty Then
            If Not exists(cboExamName.SelectedItem) Then
                Dim li As New ListViewItem
                li = lstExaminations.Items.Add(cboExamName.SelectedItem)
                li.SubItems.Add(txtContribution.Text)
                li.SubItems.Add(cboTerm.SelectedItem)
                li.SubItems.Add(cboYear.SelectedItem)
                li.SubItems.Add(getExamContribution())
                total_percentage += txtContribution.Text
            End If
        End If
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

    Private Sub cboTerm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTerm.SelectedIndexChanged
        If cboTerm.SelectedItem <> None And cboYear.SelectedItem.ToString <> None Then
            fill_exam()
        End If
    End Sub

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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        search_teachers = False
        Me.Close()
    End Sub

    Private Sub cboYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboYear.SelectedIndexChanged
        If cboTerm.SelectedItem <> None And cboYear.SelectedItem.ToString <> None Then
            fill_exam()
        End If
    End Sub

    Private Sub btnEnterMarks_Click(sender As Object, e As EventArgs) Handles btnEnterMarks.Click
        If lstExaminations.Items.Count = 0 Then
            MsgBox("There Are No Exams To Analyze")
        ElseIf cboClass.SelectedItem = Nothing Then
            MsgBox("Please Select The Class")
        ElseIf cboSortBy.SelectedItem = String.Empty And cboSortBy.Visible Then
            MsgBox("Please Choose The Mode To Sort The Result Analysis!")
        Else

            If rdSubjectBased.Checked = True Then
                gradingType = "SubjectBased"
            Else
                gradingType = "ClassBased"
            End If
            selectedTerm = cboTerm.SelectedItem.ToString()
            selectedClass = cboClass.SelectedItem.ToString()
            selectedYear = cboSelectedYear.SelectedItem.ToString
            sortGradesBy = cboSortBy.SelectedItem.ToString()

            tm = cboTerm.SelectedItem
            yr = cboYear.SelectedItem

            examListMain = New List(Of Tuple(Of String, String, String, String, String))

            For i = 0 To lstExaminations.Items.Count - 1
                examListMain.Add(New Tuple(Of String, String, String, String, String)(lstExaminations.Items.Item(i).Text, lstExaminations.Items.Item(i).SubItems(1).Text, lstExaminations.Items.Item(i).SubItems(2).Text, lstExaminations.Items.Item(i).SubItems(3).Text, lstExaminations.Items.Item(i).SubItems(4).Text))
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

            '//////////////////////////////////////////////////////////////////////

            table = "exam_results"
            search_teachers = True
            tm = cboTerm.SelectedItem
            yr = cboYear.SelectedItem

            If cboSortBy.SelectedItem = "Total Marks" Then
                sortby = "Total"
            ElseIf cboSortBy.SelectedItem = "Mean Marks" Then
                sortby = "MM"
            ElseIf cboSortBy.SelectedItem = "Mean Points" Then
                sortby = "MP"
            ElseIf cboSortBy.SelectedItem = "Total Points" Then
                sortby = "TP"
            End If

            '/////////////////////////////////////////////////////////////////////

            Me.Close()
            'total be converted to devexpress
            Dim computeResultForm As New frmComputeResults
            computeResultForm.MdiParent = frmMainForm
            computeResultForm.Show()

        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
        total_percentage = 0
    End Sub

    Private Sub clear()
        cboTerm.SelectedItem = None
        cboExamName.SelectedItem = None
        cboClass.SelectedItem = None
        lstExaminations.Items.Clear()
        txtContribution.Text = 0
    End Sub


End Class