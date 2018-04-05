Public Class frmResultAnalysis

    Dim total_percentage As Double = 0
    Dim msg As String = ""
    Private Sub frmExamEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            stream_mode = False
            lstExaminations.Items.Clear()
            CheckBox1.Enabled = True
            btnAddExam.Enabled = False
            txtContribution.Enabled = False
            grpMultiExaminations.Enabled = False
            fill_year()
            get_term()
            load_class(cboClass)
            cboTerm.SelectedItem = term
            cboYear.SelectedItem = Today.Year
        End If
    End Sub

    Private Sub loadClasses()
        cboClass.Items.Clear()
        qread("SELECT class FROM examined_classes WHERE (Examination='" & escape_string(cboExamName.SelectedItem) & "' AND Term='" & escape_string(cboTerm.SelectedItem) & "' AND Year='" & cboYear.SelectedItem & "')")
        While dbreader.Read
            cboClass.Items.Add(dbreader("class"))
        End While
    End Sub
    Private Sub fill_year()

        cboYear.Items.Clear()
        fill_years(cboYear)
        cboYear.SelectedItem = Today.Year
    End Sub
    Private Sub cboTerm_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTerm.SelectedValueChanged, cboYear.SelectedValueChanged
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        search_teachers = False
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
        total_percentage = 0
    End Sub
    Private Sub clear()
        cboTerm.SelectedItem = None
        cboExamName.SelectedItem = None
        cboClass.SelectedItem = None
        'cboStream.SelectedItem = None
        lstExaminations.Items.Clear()
    End Sub
    Private Function isvalid()

        If total_percentage <> 100 And chkMode.Checked Then
            msg = "The Examination Contributions Don't Total to 100%!"
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
        ElseIf cboClass.SelectedItem = Nothing Or cboClass.SelectedItem = None Then
            msg = "Invalid Selection For Class!"
            Return False
        ElseIf lstExaminations.Items.Count < 1 And chkMode.Checked Then
            msg = "Only 1 Examination? You didn't tell me so!"
            Return False
        ElseIf cboSortBy.SelectedItem = "" And cboSortBy.Visible Then
            msg = "Please Choose The Mode To Sort The Result Analysis!"
            Return False
        Else

            Return True
        End If

    End Function
    Private Sub load_entry_form_many()
        Dim i As Integer
        ReDim tables(lstExaminations.Items.Count - 1)
        ReDim contribution(lstExaminations.Items.Count - 1)
        ReDim total_mark(lstExaminations.Items.Count - 1)
        ReDim tms(lstExaminations.Items.Count - 1)
        ReDim yrs(lstExaminations.Items.Count - 1)
        For i = 0 To tables.Length - 1
            tables(i) = lstExaminations.Items.Item(i).Text
            total_mark(i) = get_total_mark(lstExaminations.Items.Item(i).Text, lstExaminations.Items.Item(i).SubItems(3).Text)
            contribution(i) = lstExaminations.Items.Item(i).SubItems(1).Text
            tms(i) = lstExaminations.Items(i).SubItems(3).Text
            yrs(i) = lstExaminations.Items(i).SubItems(2).Text
        Next
        class_form = get_name(cboClass.SelectedItem)
        ReDim exam_names(lstExaminations.Items.Count - 1)
        For i = 0 To lstExaminations.Items.Count - 1
            exam_names(i) = lstExaminations.Items.Item(i).Text
        Next
        table = "exam_results"
        For k As Integer = 0 To tables.Length - 1
            If total_mark(k) = 0 Then
                failure(" Program Cannot Perform The Requested Operation! Looks Like There's One Examination Which The Chosen Class Did Not Undertake!")
                Exit Sub
            End If
        Next
        Me.Close()
    End Sub
    Private Sub btnEnterMarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnterMarks.Click
        If isvalid() Then

            table = "exam_results"
            search_teachers = True
            show_split = CheckBox1.Checked
            tm = cboTerm.SelectedItem
            'stream = cboStream.SelectedItem
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

            If chkMode.Checked Then
                mode = True
                load_entry_form_many()
            Else
                chkMode.Checked = True
                mode = True
                lstExaminations.Items.Clear()
                Dim li As New ListViewItem
                li = lstExaminations.Items.Add(cboExamName.SelectedItem)
                li.SubItems.Add("100")
                li.SubItems.Add(cboYear.SelectedItem)
                li.SubItems.Add(cboTerm.SelectedItem)
                total_percentage += 100
                load_entry_form_many()
                ' load_entry_form()
            End If

        Else
            failure(msg)
        End If
    End Sub
    Private Sub load_entry_form()
        table = "exam_results"
        class_form = get_name(cboClass.SelectedItem)
        exam_name = cboExamName.SelectedItem
        Me.Close()
    End Sub

    Private Sub chkMode_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMode.CheckedChanged
        If chkMode.Checked Then
            btnAddExam.Enabled = True
            txtContribution.Enabled = True
            grpMultiExaminations.Enabled = True
            CheckBox1.Checked = False
            CheckBox1.Enabled = False
        Else
            lstExaminations.Items.Clear()
            CheckBox1.Enabled = True
            btnAddExam.Enabled = False
            txtContribution.Enabled = False
            grpMultiExaminations.Enabled = False
        End If

    End Sub
    Private Function exists(ByVal str As String)
        Dim i As Integer
        Dim selectedTerm As String = String.Empty

        For i = 0 To lstExaminations.Items.Count - 1
            If lstExaminations.Items.Item(i).Text = str And lstExaminations.Items.Item(i).SubItems(2).Text = cboYear.SelectedItem And lstExaminations.Items.Item(i).SubItems(3).Text = cboTerm.SelectedItem Then
                MsgBox("The Exam Already Exist In The List")
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub add_exam()
        If cboExamName.SelectedItem <> None And IsNumeric(txtContribution.Text) And txtContribution.Text <> "" Then
            If Not exists(cboExamName.SelectedItem) Then
                Dim li As New ListViewItem
                li = lstExaminations.Items.Add(cboExamName.SelectedItem)
                li.SubItems.Add(txtContribution.Text)
                li.SubItems.Add(cboYear.SelectedItem)
                li.SubItems.Add(cboTerm.SelectedItem)
                total_percentage += txtContribution.Text
            End If
        End If
    End Sub
    Private Sub btnAddExam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddExam.Click
        add_exam()
    End Sub

    Private Sub cboExamName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExamName.SelectedIndexChanged
        txtContribution.Clear()
        txtContribution.Focus()
        loadClasses()
    End Sub

    Private Sub txtContribution_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContribution.KeyPress
        If Asc(e.KeyChar()) = 13 Then
            add_exam()
        End If
    End Sub

    Private Sub cboClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        get_class_subjects(cboClass.SelectedItem)
    End Sub
End Class