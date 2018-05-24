Imports System
Imports System.Drawing.Printing
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Diagnostics.Debugger
Public Class frmEnterMarks
    Dim results_entered As Boolean
    Dim msg As String
    Dim adm()
    Private Function check_results()
        If class_stream <> "All" Then
            query = "SELECT * FROM " & table & " WHERE Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "' AND  class='" & escape_string(ret_name(class_form)) & "' AND Stream='" & escape_string(stream) & "'"
        Else
            query = "SELECT * FROM " & table & " WHERE Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "' AND  class='" & escape_string(ret_name(class_form)) & "' "
        End If
        If qread(query) Then
            If dbreader.RecordsAffected > 0 Then
                dbreader.Close()
                Return True
            Else
                dbreader.Close()
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function IsEditableResults() As Boolean
        qread("SELECT Entry FROM examinations WHERE (last_date_of_entry<='" & Today.Year & "-" & Format(Today.Month, "00") & "-" & Format(Today.Day, "00") & "' AND ExamName='" & escape_string(cboExamName.SelectedItem) & "' AND Term='" & cboTerm.SelectedItem & "' AND Year=" & cboYear.SelectedItem & ")")
        If dbreader.RecordsAffected > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Dim is_editable As Boolean
    Private Sub get_split_subjects(ByVal subj As String)
        qread("SELECT * FROM split_subjects WHERE subject='" & escape_string(subj) & "' AND class='" & escape_string(ret_name(class_form)) & "' ORDER BY id ASC")
        ReDim splits(dbreader.RecordsAffected - 1), splits_cont(dbreader.RecordsAffected - 1)
        Dim i As Integer = 0
        While dbreader.Read
            splits(i) = dbreader("abbreviation")
            splits_cont(i) = dbreader("contribution")
            i += 1
        End While
    End Sub

    Dim splits(), splits_cont()
    Private Sub create_dataform()
        For k As Integer = 0 To subjabb.Length - 1
            Dim split_count As Integer = 0
            If CheckBox1.Checked Then
                get_split_subjects(subjects(k))
                For count = 0 To splits.Length - 1
                    Dim cellINDEX1 As DataGridViewCell = New DataGridViewTextBoxCell
                    Dim colINDEX1 As New DataGridViewColumn
                    With colINDEX1
                        .CellTemplate = cellINDEX1
                        .Name = splits(count)
                        .HeaderText = splits(count)
                        .Width = 50
                        .ReadOnly = False
                        .SortMode = DataGridViewColumnSortMode.Programmatic
                        If subjects(k) = cboSubject.SelectedItem Or cboSubject.SelectedItem = "All" Then
                            .Visible = True
                        Else
                            .Visible = False
                        End If
                    End With
                    dgvEnterMarks.Columns.Add(colINDEX1)
                    split_count += 1
                Next
            End If
            Dim column As New DataGridViewColumn
            Dim cell As DataGridViewCell = New DataGridViewTextBoxCell
            With column
                .CellTemplate = cell
                If subj = "All" And IsAdmin() Then
                    .Visible = True
                ElseIf subj = "All" Then
                    If IsSubjectTeacher(subjects(k), cboClass.SelectedItem, cboStream.SelectedItem, tm, yr) Then
                        .Visible = True And is_editable
                    Else
                        .Visible = False
                    End If
                Else
                    If subj = subjects(k) Then
                        .Visible = True And is_editable
                    Else
                        .Visible = False
                    End If
                End If
                .Width = 55
                If (subjabb.Length > 3) Then
                    .Name = subjname(k)
                    If CheckBox1.Checked Then
                        .Width = 0
                    End If
                    If IsPrimary() And split_count > 0 Then
                        .ReadOnly = True
                        .HeaderText = "TOTAL"
                    Else
                        If subjabb(k).ToString.Length > 3 Then
                            .HeaderText = remove_wild(subjabb(k).Substring(0, 3))
                        Else
                            .HeaderText = remove_wild(subjabb(k))
                        End If
                    End If
                Else
                    .Name = subjname(k)
                    If IsPrimary() And split_count > 0 Then
                        .HeaderText = "TOTAL"
                        .Visible = False
                        .ReadOnly = True
                    Else
                        .HeaderText = remove_wild(subjabb(k).Substring(0, 2))
                    End If
                End If
            End With
            dgvEnterMarks.Columns.Add(column)
        Next
        Dim column1 As New DataGridViewColumn
        Dim cell1 As DataGridViewCell = New DataGridViewTextBoxCell
        With column1
            .Name = "Class"
            .HeaderText = "Class"
            .CellTemplate = cell1
            .Visible = False
        End With
        dgvEnterMarks.Columns.Add(column1)
        Dim column2 As New DataGridViewColumn
        Dim cell2 As DataGridViewCell = New DataGridViewTextBoxCell
        With column2
            .Name = "Stream"
            .HeaderText = "Stream"
            .CellTemplate = cell2
            .Visible = False
        End With
        dgvEnterMarks.Columns.Add(column2)

        ' dgvEnterMarks.AutoResizeColumns()

    End Sub
    Private Sub frmEnterMarks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            If Not get_subjects() Then
                Me.Close()
            Else
                fill_year()
                cboYear.SelectedItem = Today.Year
                CheckBox1.Checked = IsPrimary()
                load_class(cboClass)
                cboTerm.SelectedItem = tm
                ComboBox1.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub fill_year()
        Dim i As Integer
        cboYear.Items.Clear()
        For i = startyear To endyear
            cboYear.Items.Add(i)
        Next
        cboYear.SelectedItem = Today.Year
    End Sub

    Private Sub load_entered()
        Dim query1 As String = String.Empty
        Dim adminNumber As String = String.Empty

        dgvEnterMarks.Rows.Clear()
        If yr = Today.Year Then
            If subj <> "All" Then
                If stream = "All" Then
                    query1 = "SELECT admin_no FROM students WHERE (class='" & escape_string(ret_name(class_form)) & "' AND IsStudent='True'  AND admin_no IN (SELECT admno FROM subjects_done WHERE `" & get_subject_name(subj, True) & "`='Yes' )) ORDER BY admin_no"
                Else
                    query1 = "SELECT admin_no FROM students WHERE (class='" & escape_string(ret_name(class_form)) & "' AND stream='" & escape_string(stream) & "' AND IsStudent='True'  AND admin_no IN (SELECT admno FROM subjects_done WHERE `" & get_subject_name(subj, True) & "`='Yes' )) ORDER BY admin_no"
                End If
            Else
                If stream = "All" Then
                    query1 = "SELECT admin_no FROM students WHERE (class='" & escape_string(ret_name(class_form)) & "' AND IsStudent='True') ORDER BY admin_no"
                Else
                    query1 = "SELECT admin_no FROM students WHERE (class='" & escape_string(ret_name(class_form)) & "' AND stream='" & escape_string(stream) & "' AND IsStudent='True') ORDER BY admin_no"
                End If
            End If
        Else
            If stream = "All" Then
                query = "SELECT * FROM exam_results WHERE (term='" & tm & "' AND year='" & yr & "' AND examination='" & escape_string(exam_name) & "' AND class='" & escape_string(cboClass.SelectedItem) & "') ORDER BY admno"
            Else
                query = "SELECT * FROM exam_results WHERE (term='" & tm & "' AND year='" & yr & "' AND examination='" & escape_string(exam_name) & "' AND class='" & escape_string(cboClass.SelectedItem) & "' AND stream='" & escape_string(cboStream.SelectedItem) & "') ORDER BY admno"
            End If
        End If

        If query1 IsNot String.Empty Then
            query = query1
            adminNumber = "admin_no"
        Else
            adminNumber = "admno"
        End If

        If qread(query) Then
            Dim i As Integer = 0
            If dbreader.RecordsAffected = 0 Then
                load_new()
                dbreader.Close()
            Else
                ReDim adm(dbreader.RecordsAffected - 1)
                Dim k As Integer = 0
                While dbreader.Read
                    adm(k) = dbreader(adminNumber)
                    k += 1
                End While
                For k = 0 To adm.Length - 1
                    If qread("SELECT * FROM exam_results LEFT JOIN students ON students.admin_no=exam_results.admno WHERE term='" & tm & "' AND year='" & yr & "' AND examination='" & escape_string(exam_name) & "' AND exam_results.admno='" & adm(k) & "'") Then
                        If dbreader.RecordsAffected > 0 Then
                            dbreader.Read()
                            dgvEnterMarks.Rows.Add()
                            dgvEnterMarks.Item("IndexNo", k).Value = get_id(dbreader("indexno"))
                            dgvEnterMarks.Item("admin_no", k).Value = get_id(dbreader(adminNumber))
                            dgvEnterMarks.Item("Class", k).Value = cboClass.SelectedItem
                            dgvEnterMarks.Item("Stream", k).Value = dbreader("stream")
                            dgvEnterMarks.Item("StudentName", k).Value = dbreader("studentname")
                            dgvEnterMarks.Item("Examination", k).Value = dbreader("Examination")
                            dgvEnterMarks.Item("Term", k).Value = dbreader("Term")
                            dgvEnterMarks.Item("Year", k).Value = dbreader("Year")
                            For j As Integer = 0 To subjabb.Length - 1
                                If dbreader(subjabb(j)) = "" Then
                                    dgvEnterMarks.Item(subjname(j), k).Value = "-"
                                Else
                                    dgvEnterMarks.Item(subjname(j), k).Value = dbreader(subjabb(j))
                                End If
                            Next
                        Else
                            qread("SELECT admin_no, student_name, stream, indexno FROM students WHERE admin_no='" & escape_string(adm(k)) & "' AND IsStudent='True'")
                            dbreader.Read()
                            dgvEnterMarks.Rows.Add()
                            dgvEnterMarks.Item("IndexNo", k).Value = get_id(dbreader("indexno"))
                            dgvEnterMarks.Item("admin_no", k).Value = get_id(dbreader("admin_no"))
                            dgvEnterMarks.Item("StudentName", k).Value = dbreader("student_name")
                            dgvEnterMarks.Item("Class", k).Value = cboClass.SelectedItem
                            dgvEnterMarks.Item("Stream", k).Value = dbreader("Stream")
                        End If
                    End If
                Next
                If CheckBox1.Checked Then
                    load_split()
                End If
                dbreader.Close()
                Me.Text = exam_name.ToUpper & " EXAMINATION RESULTS ENTRY FOR " & ret_name(class_form).ToString.ToUpper
            End If
        Else
            failure("Could Not Read From The Database!")
            Me.Close()
        End If
    End Sub
    Private Sub load_split()
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            qread("SELECT * FROM exam_split_subject_results WHERE term='" & tm & "' AND year='" & yr & "' AND examination='" & escape_string(exam_name) & "' AND admno='" & dgvEnterMarks.Item("admin_no", k).Value & "'")
            If dbreader.RecordsAffected > 0 Then
                dbreader.Read()
                For i As Integer = 6 To dgvEnterMarks.Columns.Count - 3
                    If dgvEnterMarks.Columns(i).Visible And is_split_subject(dgvEnterMarks.Columns(i).Name) Then
                        Try
                            dgvEnterMarks.Item(dgvEnterMarks.Columns(i).Name, k).Value = dbreader(class_form & "_" & dgvEnterMarks.Columns(i).Name)
                        Catch ex As Exception

                        End Try
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub load_form()
        results_entered = check_results()
        If results_entered Then
            load_entered()
        Else
            load_new()
        End If
        If dgvEnterMarks.RowCount = 0 Then
            Exit Sub
        End If
        If ComboBox1.SelectedIndex = 0 Then
            dgvEnterMarks.Sort(dgvEnterMarks.Columns("admin_no"), System.ComponentModel.ListSortDirection.Ascending)
            dgvEnterMarks.Columns("IndexNo").Visible = False
            dgvEnterMarks.Columns("admin_no").Visible = True
        ElseIf ComboBox1.SelectedIndex = 1 Then
            dgvEnterMarks.Sort(dgvEnterMarks.Columns("IndexNo"), System.ComponentModel.ListSortDirection.Ascending)
            dgvEnterMarks.Columns("admin_no").Visible = False
            dgvEnterMarks.Columns("IndexNo").Visible = True
        Else
            dgvEnterMarks.Sort(dgvEnterMarks.Columns("StudentName"), System.ComponentModel.ListSortDirection.Ascending)
            dgvEnterMarks.Columns("IndexNo").Visible = False
            dgvEnterMarks.Columns("admin_no").Visible = True
        End If
    End Sub
    Private Sub load_new()
        If subj = "All" Then
            If stream <> "All" Then
                query = "SELECT admin_no, student_name, stream, indexno FROM `students` WHERE class='" & escape_string(ret_name(class_form)) & "' AND stream='" & escape_string(stream) & "'  AND IsStudent='True' ORDER BY admin_no"
            Else
                query = "SELECT admin_no, student_name, stream, indexno FROM `students` WHERE class='" & escape_string(ret_name(class_form)) & "'  AND IsStudent='True'  ORDER BY admin_no"
            End If
        Else
            If stream <> "All" Then
                query = "SELECT admin_no, student_name, stream, indexno FROM `students` WHERE (class='" & escape_string(ret_name(class_form)) & "' AND stream='" & escape_string(stream) & "'  AND IsStudent='True' AND admin_no IN (SELECT admin_no FROM subjects_done WHERE `" & get_subject_name(subj, True) & "`='Yes' )) ORDER BY admin_no"
            Else
                query = "SELECT admin_no, student_name, stream, indexno FROM `students` WHERE (class='" & escape_string(ret_name(class_form)) & "'  AND IsStudent='True'  AND admin_no IN (SELECT admin_no FROM subjects_done WHERE `" & get_subject_name(subj, True) & "`='Yes' ))  ORDER BY admin_no"
            End If
        End If
        If qread(query) Then
            Dim i As Integer = 0
            If dbreader.RecordsAffected = 0 Then
                failure("No Student Records Found For Examination Marks Entry Operation!")
                Me.Close()
            Else
                While dbreader.Read
                    dgvEnterMarks.Rows.Add()
                    dgvEnterMarks.Item("IndexNo", i).Value = get_id(dbreader("indexno"))
                    dgvEnterMarks.Item("admin_no", i).Value = get_id(dbreader("admin_no"))
                    dgvEnterMarks.Item("StudentName", i).Value = dbreader("student_name")
                    dgvEnterMarks.Item("Examination", i).Value = exam_name
                    dgvEnterMarks.Item("Term", i).Value = tm
                    dgvEnterMarks.Item("Year", i).Value = yr
                    dgvEnterMarks.Item("Class", i).Value = cboClass.SelectedItem
                    dgvEnterMarks.Item("Stream", i).Value = dbreader("stream")
                    i += 1
                End While
                dbreader.Close()
                Me.Text = exam_name.ToUpper & " EXAMINATION RESULTS ENTRY FOR " & ret_name(class_form).ToString.ToUpper
            End If
        Else
            failure("Could Not Read From The Database!")
            Me.Close()
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If confirm("Save Data Before Closing Form?") Then
            save_now()
            Me.Close()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If Not OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        import_data()
    End Sub
    Private Sub import_data()
        Dim fields_list As String = ""
        Dim col_count As Integer = 0
        For k As Integer = 0 To dgvEnterMarks.Columns.Count - 1
            If dgvEnterMarks.Columns(k).Visible Then
                If col_count > 0 Then
                    fields_list &= ","
                End If
                fields_list &= dgvEnterMarks.Columns(k).Name
                col_count += 1
            End If
        Next
        Dim excel As New Microsoft.Office.Interop.Excel.Application()
        Dim wb As Microsoft.Office.Interop.Excel.Workbook = excel.Workbooks.Open(OpenFileDialog1.FileName)
        Dim ws As Microsoft.Office.Interop.Excel.Worksheet = TryCast(excel.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
        Dim i As Integer = 2




        progress.Visible = True
        progress.Increment(-100)

        Dim counter As String = String.Empty


        While ws.Cells(i, 1).Value2 <> Nothing

            'If i = 70 Then
            '    Debugger.Break()
            '    Break()
            'End If

            counter = ws.Cells(i, 1).Value.ToString()

            col_count = 1
            Dim row_index As Integer = getRowIndex(ws.Cells(i, 1).Value2)
            For k As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                If dgvEnterMarks.Columns(k).Visible Then
                    dgvEnterMarks.Rows.Add()
                    dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, row_index).Value = ws.Cells(i, col_count).Value2
                    col_count += 1
                End If
            Next
            progress.Increment(1)
            i += 1

            If Not IsNumeric(counter) Then
                Exit While
            End If

        End While
        progress.Visible = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        MessageBox.Show("The Operation Was Successful")

    End Sub
    Private Function getRowIndex(adm As String) As Integer
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            If dgvEnterMarks.Item("admin_no", k).Value.ToString = adm Then
                Return k
            End If
        Next
    End Function
    Private Function isvalid()
        Dim out_of As Double
        progress.Visible = True
        lblSave.Visible = True
        lblSave.Text = "Validating Data..."
        Dim inc As Integer = 100 / dgvEnterMarks.Rows.Count
        For i As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            For k As Integer = 0 To subjabb.Length - 1
                If Not IsNumeric(dgvEnterMarks.Item(subjname(k), i).value) And dgvEnterMarks.Item(subjname(k), i).value <> Nothing Then
                    dgvEnterMarks.Item(subjname(k), i).value = dgvEnterMarks.Item(subjname(k), i).value.ToString.ToUpper
                ElseIf IsNumeric(dgvEnterMarks.Item(subjname(k), i).Value) Then
                    out_of = markOutOf(subjname(k), dgvEnterMarks.Item("Stream", i).Value)
                    If dgvEnterMarks.Item(subjname(k), i).Value > out_of Or dgvEnterMarks.Item(subjname(k), i).value < 0 Then
                        msg = "failure value for " & subjects(k) & " for " & dgvEnterMarks.Item("StudentName", i).Value & " Value greater than maximum Or Lower Than Minimum!"
                        progress.Visible = False
                        lblSave.Visible = False
                        Return False
                    End If
                End If
            Next
            progress.Increment(inc)
        Next
        progress.Increment(-100)
        progress.Visible = False
        lblSave.Visible = False
        Return True
    End Function
    Private Sub save_now()
        If isvalid() And formfourmode() Then
            increment = dgvEnterMarks.Rows.Count / 100
            progress.Visible = True
            lblSave.Visible = True
            lblWait.Visible = True
            If check_results() Then
                lblSave.Text = "Updating Data..."
                up_date()
            Else
                lblSave.Text = "Saving Data..."
                save()
            End If
            progress.Increment(-100)
            progress.Visible = False
            lblSave.Visible = False
            lblWait.Visible = False
        Else
            failure(msg)
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        progress.Visible = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        save_now()
    End Sub
    Dim total As Double
    Dim total_term_days As Integer
    Dim percentage_attendance As Double
    Dim student As Integer
    Dim class_out_of As Integer
    Dim stream_no() As Integer
    Dim adm_no
    Dim sciences() As String
    Dim sci_names() As String
    Dim science As Boolean = True
    Dim humanities() As String
    Dim hum_names() As String
    Dim app_names() As String
    Dim humanity As Boolean = False
    Dim applieds() As String
    Dim applied As Boolean = False
    Dim compulsory() As String
    Dim comp_names() As String
    Dim points As Boolean = False
    Dim admin_nos() As String
    Private Function get_sciences()
        If qread("SELECT Abbreviation FROM subjects WHERE  Department='Science'") Then
            ReDim sciences(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read
                sciences(i) = dbreader("Abbreviation")
                i += 1
            End While
            dbreader.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Private Function get_compulsory()
        If qread("SELECT Abbreviation FROM subjects WHERE  Comment='Compulsory'") Then
            ReDim compulsory(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read
                compulsory(i) = dbreader("Abbreviation")
                i += 1
            End While
            dbreader.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Private Function get_humanity()
        If qread("SELECT Abbreviation FROM subjects WHERE  Department='Humanities'") Then
            ReDim humanities(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read
                humanities(i) = dbreader("Abbreviation")
                i += 1
            End While
            dbreader.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Private Function get_applied()
        If qread("SELECT Abbreviation FROM subjects WHERE  Department='APPLIED STUDIES'") Then
            ReDim applieds(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read
                applieds(i) = dbreader("Abbreviation")
                i += 1
            End While
            dbreader.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Private Function formfourmode()
        If get_compulsory() Then
            If get_sciences() Then
                If get_humanity() Then
                    get_applied()
                    Return True
                Else
                    failure("Could Not Correctly Determine Any Humanity Subject!")
                    Return False
                End If
            Else
                failure("Could Not Correctly Determine Any Science Subject!")
                Return False
            End If
        Else
            failure("Could Not Correctly Determine Any Compulsory Subject!")
            Return False
        End If
    End Function

    Private Function valid(ByVal row As Integer)
        If formfourmode() Then
            For k As Integer = 0 To compulsory.Length - 1
                If Not IsNumeric(dgvEnterMarks.Item(compulsory(k), row).Value) Then
                    Return False
                End If
            Next
            Dim sci_count As Integer = sciences.Length
            For k As Integer = 0 To sciences.Length - 1
                If Not IsNumeric(dgvEnterMarks.Item(sciences(k), row).Value) Then
                    sci_count -= 1
                End If
            Next
            If sci_count < 2 Then
                Return False
            End If
            Dim hum_count As Integer = humanities.Length
            For k As Integer = 0 To humanities.Length - 1
                If Not IsNumeric(dgvEnterMarks.Item(humanities(k), row).Value) Then
                    hum_count -= 1
                End If
            Next
            If hum_count < 1 Then
                Return False
            End If
            Dim app_count As Integer = applieds.Length
            For k As Integer = 0 To applieds.Length - 1
                If Not IsNumeric(dgvEnterMarks.Item(applieds(k), row).Value) Then
                    app_count -= 1
                End If
            Next
            If sci_count = 2 And hum_count = 1 And app_count = 0 Then
                Return False
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Dim sb_tp, tp As Double
    Private Function markOutOf(ByVal subj As String, ByVal str As String) As Double
        Return SubjectOutOf(subj, cboTerm.SelectedItem, cboYear.SelectedItem, cboExamName.SelectedItem, cboClass.SelectedItem, str)
    End Function
    Private Function best_of_7(ByVal row As Integer)
        If Not valid(row) Then
            sb_tp = 0
            tp = 0
            total = 0
            Return 0
        End If
        Dim out_of As Double
        total = 0
        science = True
        tp = 0
        sb_tp = 0
        Dim temp, l As Integer
        '##############get total of first compulsory subjects#################
        Dim counter As Integer = 0
        For k As Integer = 0 To compulsory.Length - 1
            If IsNumeric(dgvEnterMarks.Item(compulsory(k), row).Value) Then
                out_of = markOutOf(compulsory(k), dgvEnterMarks.Item("Stream", row).Value)
                total += (dgvEnterMarks.Item(compulsory(k), row).Value / out_of) * 100
                tp += fix_point(get_grade((dgvEnterMarks.Item(compulsory(k), row).Value / out_of) * 100, False, compulsory(k)))
                sb_tp += fix_point(get_grade((dgvEnterMarks.Item(compulsory(k), row).Value / out_of) * 100, True, compulsory(k)))
                counter += 1
            End If
        Next
        If counter < 3 Then
            sb_tp = 0
            tp = 0
            total = 0
            Return 0
        Else
            counter = 0
        End If
        '###########add the 2 best performed science and the second best###################
        For k As Integer = 0 To sciences.Length - 1
            If Not IsNumeric(dgvEnterMarks.Item(sciences(k), row).Value) Then
                science = False
            Else
                counter += 1
            End If
        Next
        If counter < 2 Then
            sb_tp = 0
            tp = 0
            total = 0
            Return 0
        Else
            counter = 0
        End If
        Dim sci(sciences.Length - 1)
        Dim hum(humanities.Length - 1), app(applieds.Length - 1) As Integer
        ReDim app_names(applieds.Length - 1), hum_names(humanities.Length - 1), sci_names(sciences.Length - 1)
        For k As Integer = 0 To sciences.Length - 1
            sci(k) = dgvEnterMarks.Item(sciences(k), row).Value
            sci_names(k) = sciences(k)
        Next
        Dim temp_name As String
        If science Then
            '###########Sor them#############
            For k As Integer = 0 To sciences.Length - 1
                For l = k + 1 To sciences.Length - 1
                    If sci(k) < sci(l) Then
                        temp = sci(k)
                        temp_name = sci_names(k)
                        sci(k) = sci(l)
                        sci_names(k) = sci_names(l)
                        sci(l) = temp
                        sci_names(l) = temp_name
                    End If
                Next
            Next
            For k As Integer = 0 To sciences.Length - 1
                If k < sciences.Length - 1 Then
                    out_of = markOutOf(sci_names(k), dgvEnterMarks.Item("Stream", row).Value)
                    total += (sci(k) / out_of) * 100
                    tp += fix_point(get_grade((sci(k) / out_of) * 100, False, sci_names(k)))
                    sb_tp += fix_point(get_grade((sci(k) / out_of) * 100, True, sci_names(k)))
                End If
            Next
        Else
            For k As Integer = 0 To sciences.Length - 1
                If IsNumeric(dgvEnterMarks.Item(sciences(k), row).Value) Then
                    out_of = markOutOf(sci_names(k), dgvEnterMarks.Item("Stream", row).Value)
                    total += (dgvEnterMarks.Item(sciences(k), row).Value / out_of) * 100
                    tp += fix_point(get_grade((dgvEnterMarks.Item(sciences(k), row).Value / out_of) * 100, False, sci_names(k)))
                    sb_tp += fix_point(get_grade((dgvEnterMarks.Item(sciences(k), row).Value / out_of) * 100, True, sci_names(k)))
                End If
            Next
        End If
        '###########get highest and second best performed humanity ##################
        Dim count As Integer = humanities.Length
        For k As Integer = 0 To humanities.Length - 1
            hum_names(k) = humanities(k)
        Next
        For k As Integer = 0 To humanities.Length - 1
            If Not IsNumeric(dgvEnterMarks.Item(humanities(k), row).Value) Then
                count -= 1
            Else
                counter += 1
            End If
        Next
        If counter < 1 Then
            sb_tp = 0
            tp = 0
            total = 0
            Return 0
        Else
            counter = 0
        End If
        If count > 1 Then
            humanity = True
            l = 0
            For k As Integer = 0 To humanities.Length - 1
                If IsNumeric(dgvEnterMarks.Item(humanities(k), row).Value) Then
                    hum(k) = dgvEnterMarks.Item(humanities(k), row).Value
                End If
            Next
            For k As Integer = 0 To hum.Length - 1
                For l = k + 1 To hum.Length - 1
                    If hum(k) < hum(l) Or (Not IsNumeric(hum(k)) And IsNumeric(hum(l))) Then
                        temp = hum(k)
                        temp_name = hum_names(k)
                        hum(k) = hum(l)
                        hum_names(k) = hum_names(l)
                        hum(l) = temp
                        hum_names(l) = temp_name
                    End If
                Next
            Next
            out_of = markOutOf(hum_names(0), dgvEnterMarks.Item("Stream", row).Value)
            total += (hum(0) / out_of) * 100
            tp += fix_point(get_grade((hum(0) / out_of) * 100, False, hum_names(0)))
            sb_tp += fix_point(get_grade((hum(0) / out_of) * 100, True, hum_names(0)))
        Else
            For k As Integer = 0 To humanities.Length - 1
                If IsNumeric(dgvEnterMarks.Item(humanities(k), row).Value) Then
                    out_of = markOutOf(hum_names(k), dgvEnterMarks.Item("Stream", row).Value)
                    total += (dgvEnterMarks.Item(humanities(k), row).Value / out_of) * 100
                    tp += fix_point(get_grade((dgvEnterMarks.Item(humanities(k), row).Value / out_of) * 100, False, hum_names(k)))
                    sb_tp += fix_point(get_grade((dgvEnterMarks.Item(humanities(k), row).Value / out_of) * 100, True, hum_names(k)))
                End If
            Next
        End If
        '########### get highest performed applied subject ##################
        For k As Integer = 0 To applieds.Length - 1
            app_names(k) = applieds(k)
        Next
        count = 0
        l = 0
        For k As Integer = 0 To applieds.Length - 1
            If IsNumeric(dgvEnterMarks.Item(applieds(k), row).Value) Then
                count += 1
            End If
        Next
        If count > 0 Then
            applied = True
            For k As Integer = 0 To applieds.Length - 1
                If IsNumeric(dgvEnterMarks.Item(applieds(k), row).Value) Then
                    app(l) = dgvEnterMarks.Item(applieds(k), row).Value
                    app_names(l) = applieds(k)
                    l += 1
                End If
            Next
            If l > 1 Then
                For k As Integer = 0 To app.Length - 1
                    For l = k + 1 To app.Length - 1
                        If app(k) < app(l) Then
                            temp = app(k)
                            temp_name = app_names(k)
                            app(k) = app(l)
                            app_names(k) = app_names(l)
                            app(l) = temp
                            app_names(l) = temp_name
                        End If
                    Next
                Next
            End If
        End If
        If science And humanity And applied Then
            If sci(2) > hum(1) Then
                If sci(2) > app(0) Then
                    out_of = markOutOf(sci_names(2), dgvEnterMarks.Item("Stream", row).Value)
                    total += (sci(2) / out_of) * 100
                    tp += fix_point(get_grade((sci(2) / out_of) * 100, False, sci_names(2)))
                    sb_tp += fix_point(get_grade((sci(2) / out_of) * 100, True, sci_names(2)))
                Else
                    out_of = markOutOf(app_names(0), dgvEnterMarks.Item("Stream", row).Value)
                    total += (app(0) / out_of) * 100
                    tp += fix_point(get_grade((app(0) / out_of) * 100, False, app_names(0)))
                    sb_tp += fix_point(get_grade((app(0) / out_of) * 100, True, app_names(0)))
                End If
            Else
                If hum(1) > app(0) Then
                    out_of = markOutOf(hum_names(1), dgvEnterMarks.Item("Stream", row).Value)
                    total += (hum(1) / out_of) * 100
                    tp += fix_point(get_grade((hum(1) / out_of) * 100, False, hum_names(1)))
                    sb_tp += fix_point(get_grade((hum(1) / out_of) * 100, True, hum_names(1)))
                Else
                    out_of = markOutOf(app_names(0), dgvEnterMarks.Item("Stream", row).Value)
                    total += (app(0) / out_of) * 100
                    tp += fix_point(get_grade((app(0) / out_of) * 100, False, app_names(0)))
                    sb_tp += fix_point(get_grade((app(0) / out_of) * 100, True, app_names(0)))
                End If
            End If
        ElseIf science And humanity Then
            If sci(2) > hum(1) Then
                out_of = markOutOf(sci_names(2), dgvEnterMarks.Item("Stream", row).Value)
                total += (sci(2) / out_of) * 100
                tp += fix_point(get_grade((sci(2) / out_of) * 100, False, sci_names(2)))
                sb_tp += fix_point(get_grade((sci(2) / out_of) * 100, True, sci_names(2)))
            Else
                out_of = markOutOf(hum_names(1), dgvEnterMarks.Item("Stream", row).Value)
                total += (hum(1) / out_of) * 100
                tp += fix_point(get_grade((hum(1) / out_of) * 100, False, hum_names(1)))
                sb_tp += fix_point(get_grade((hum(1) / out_of) * 100, True, hum_names(1)))
            End If
        ElseIf science And applied Then
            If sci(2) > app(0) Then
                out_of = markOutOf(sci_names(2), dgvEnterMarks.Item("Stream", row).Value)
                total += (sci(2) / out_of) * 100
                tp += fix_point(get_grade((sci(2) / out_of) * 100, False, sci_names(2)))
                sb_tp += fix_point(get_grade((sci(2) / out_of) * 100, True, sci_names(2)))
            Else
                out_of = markOutOf(app_names(0), dgvEnterMarks.Item("Stream", row).Value)
                total += (app(0) / out_of) * 100
                tp += fix_point(get_grade((app(0) / out_of) * 100, False, app_names(0)))
                sb_tp += fix_point(get_grade((app(0) / out_of) * 100, True, app_names(0)))
            End If
        ElseIf applied And humanity Then
            If app(0) > hum(1) Then
                out_of = markOutOf(app_names(0), dgvEnterMarks.Item("Stream", row).Value)
                total += (app(0) / out_of) * 100
                tp += fix_point(get_grade((app(0) / out_of) * 100, False, app_names(0)))
                sb_tp += fix_point(get_grade((app(0) / out_of) * 100, True, app_names(0)))
            Else
                out_of = markOutOf(hum_names(1), dgvEnterMarks.Item("Stream", row).Value)
                total += (hum(1) / out_of) * 100
                tp += fix_point(get_grade((hum(1) / out_of) * 100, False, hum_names(1)))
                sb_tp += fix_point(get_grade((hum(1) / out_of) * 100, True, hum_names(1)))
            End If
        ElseIf science Then
            out_of = markOutOf(sci_names(2), dgvEnterMarks.Item("Stream", row).Value)
            total += (sci(2) / out_of) * 100
            tp += fix_point(get_grade((sci(2) / out_of) * 100, False, sci_names(2)))
            sb_tp += fix_point(get_grade((sci(2) / out_of) * 100, True, sci_names(2)))
        ElseIf humanity Then
            out_of = markOutOf(hum_names(1), dgvEnterMarks.Item("Stream", row).Value)
            total += (hum(1) / out_of) * 100
            tp += fix_point(get_grade((hum(1) / out_of) * 100, False, hum_names(1)))
            sb_tp += fix_point(get_grade((hum(1) / out_of) * 100, True, hum_names(1)))
        ElseIf applied Then
            out_of = markOutOf(app_names(0), dgvEnterMarks.Item("Stream", row).Value)
            total += (app(0) / out_of) * 100
            tp += fix_point(get_grade((app(0) / out_of) * 100, False, app_names(0)))
            sb_tp += fix_point(get_grade((app(0) / out_of) * 100, True, app_names(0)))
        Else
            sb_tp = 0
            tp = 0
            total = 0
            Return 0
        End If
        Return total
    End Function
    Dim mark As Double
    Dim nsb_tp As Double
    Function compute_points(ByVal row As Integer)
        Dim total, out_of As Double
        nsb_tp = 0
        For k As Integer = 0 To subjabb.Length - 1
            out_of = markOutOf(subjname(k), dgvEnterMarks.Item("Stream", row).Value)
            If IsNumeric(dgvEnterMarks.Item(subjname(k), row).Value) Then
                'todo fix_point() function may result into a big logic error
                total += fix_point(get_grade((dgvEnterMarks.Item(subjname(k), row).Value / out_of) * 100, False, subjabb(k)))
                nsb_tp += fix_point(get_grade((dgvEnterMarks.Item(subjname(k), row).Value / out_of) * 100, True, subjabb(k)))
            End If
        Next
        Return total
    End Function

    Dim increment As Integer
    Dim tableColumns As New List(Of String)
    Dim availableColumns As New List(Of String)

    Private Sub getColumns()
        tableColumns.Clear()
        availableColumns.Clear()
        If qread("show columns from exam_split_subject_results;") Then
            If dbreader.RecordsAffected > 0 Then
                While dbreader.Read
                    tableColumns.Add(dbreader("field"))
                End While
            End If
        End If
    End Sub

    Private Sub up_date()

        Dim total As Integer
        If dgvEnterMarks.Rows.Count > 100 Then
            increment = dgvEnterMarks.Rows.Count / 100
        Else
            increment = 100 / dgvEnterMarks.Rows.Count
        End If
        Dim out_of As Double
        Dim query2 As String = Nothing
        getColumns()
        start()
        If CheckBox1.Checked Then

            For i As Integer = 0 To dgvEnterMarks.Rows.Count - 1

                If String.IsNullOrEmpty(dgvEnterMarks.Item("admin_no", i).Value) Then
                    Break()
                End If

                If ExistsStudentInRecord(i) Then
                    total = 0
                    For k As Integer = 0 To subjabb.Length - 1
                        'todo edited here 8/8/2016
                        Try
                            If dgvEnterMarks.Item(subjname(k), i).Value.ToString <> "-" And dgvEnterMarks.Item(subjname(k), i).Value.ToString <> "X" Then
                                Dim sResult As String = dgvEnterMarks.Item(subjname(k), i).Value.ToString()
                                If IsNumeric(dgvEnterMarks.Item(subjname(k), i).Value) And CDec(sResult) > 0 Then
                                    out_of = markOutOf(subjname(k), dgvEnterMarks.Item("Stream", i).Value)
                                    total += (dgvEnterMarks.Item(subjname(k), i).Value / out_of) * 100
                                End If
                            End If
                        Catch ex As Exception

                        End Try

                    Next
                    Dim count_ As Integer = 0
                    'save split subjects
                    If ExistsStudentInRecord2(i) Then
                        'update split subjects query
                        query = "UPDATE exam_split_subject_results SET StudentName='" & escape_string(dgvEnterMarks.Item("StudentName", i).Value) & "', "
                        For k As Integer = 6 To dgvEnterMarks.Columns.Count - 1
                            If dgvEnterMarks.Columns(k).Visible And is_split_subject(dgvEnterMarks.Columns(k).Name) Then
                                If count_ > 0 Then
                                    query &= ", "
                                End If
                                query = query & "`" & class_form & "_" & dgvEnterMarks.Columns(k).Name & "`='" & dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value & "'"
                                availableColumns.Add("" & class_form & "_" & dgvEnterMarks.Columns(k).Name & "")
                                count_ += 1
                            End If
                        Next
                        query &= " WHERE admno='" & escape_string(dgvEnterMarks.Item("admin_no", i).Value) & "' AND Examination='" & escape_string(exam_name) & "' AND Year='" & yr & "' AND Term='" & tm & "'"
                    Else
                        'insert split subjects query
                        query = "INSERT INTO exam_split_subject_results(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,"
                        For k As Integer = 6 To dgvEnterMarks.Columns.Count - 1
                            If dgvEnterMarks.Columns(dgvEnterMarks.Columns(k).Name).Visible And is_split_subject(dgvEnterMarks.Columns(k).Name) Then
                                query &= "`" & class_form & "_" & dgvEnterMarks.Columns(k).Name & "`"
                                availableColumns.Add("" & class_form & "_" & dgvEnterMarks.Columns(k).Name & "")
                                If k < dgvEnterMarks.Columns.Count - 4 Then
                                    query &= ","
                                End If
                            End If
                        Next
                        query = query.Substring(0, query.Length - 1)
                        query = query & ") VALUES"
                        query &= "(NULL, '" & dgvEnterMarks.Item("admin_no", i).Value & "','" & escape_string(dgvEnterMarks.Item("StudentName", i).Value) &
                        "', '" & escape_string(exam_name) & "', '" & tm & "', '" & yr & "','"
                        For k As Integer = 6 To dgvEnterMarks.Columns.Count - 1
                            If dgvEnterMarks.Columns(dgvEnterMarks.Columns(k).Name).Visible And is_split_subject(dgvEnterMarks.Columns(k).Name) Then
                                If IsNumeric(dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value) Then
                                    If dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value.ToString.Length > 1 Then
                                        query = query & dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value & "', '"
                                    Else
                                        query = query & "0" & dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value & "', '"
                                    End If
                                Else
                                    query = query & dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value & "', '"
                                End If
                            End If
                        Next

                        query = query.Substring(0, query.Length - 2) & ")"
                        query = query.Replace(",)", ")")
                    End If
                    'update exam_results query
                    query2 = "UPDATE " & table & " SET StudentName='" & escape_string(dgvEnterMarks.Item("StudentName", i).Value) & "',"
                    For k As Integer = 0 To subjabb.Length - 1
                        If dgvEnterMarks.Columns(subjname(k).ToString).Visible Then
                            If has_constituents(subjects(k)) Then
                                query2 &= "`" & subjname(k) & "`='" & subject_total(subjects(k), i, out_of) & "', "
                            Else
                                query2 &= "`" & subjname(k) & "`='" & dgvEnterMarks.Item(subjname(k), i).Value & "', "
                            End If
                        End If
                    Next
                    query2 &= "Total='" & total & "', B7_Total='" & best_of_7(i) & "', B7SB_TP='" & sb_tp & "', B7NSB_TP='" & tp & "', NSB_TP='" & compute_points(i) & "', SB_TP='" & nsb_tp & "' WHERE admno='" & escape_string(dgvEnterMarks.Item("admin_no", i).Value) & "' AND Examination='" & escape_string(exam_name) & "' AND Year='" & yr & "' AND Term='" & tm & "'"
                    progress.Increment(increment)
                    Try
                        dbreader.Close()
                    Catch ex As Exception

                    End Try

                    query = query.Replace(",  WHERE", "  WHERE")

                    confirmRows()
                    '  Dim deleteQuery As String = "delete from exam_results where admno = '" & dgvEnterMarks.Item("admin_no", i).Value & "' and examination = '" & cboExamName.SelectedItem.ToString & "' and term = '" & cboTerm.SelectedItem.ToString & "' and year = '" & cboYear.SelectedItem.ToString & "';"

                    If qwrite(query) Then
                        If qwrite(query2) Then
                        Else

                            rollback()
                            failure("Could Not Save Records")
                            progress.Visible = False
                            Exit Sub
                        End If
                    Else
                        rollback()
                        failure("Could Not Save Records")
                        progress.Visible = False
                        Exit Sub
                    End If
                Else
                    'save split subjects
                    Dim count_ As Integer
                    If ExistsStudentInRecord2(i) Then
                        'update split subjects query
                        query = "UPDATE exam_split_subject_results SET StudentName='" & escape_string(dgvEnterMarks.Item("StudentName", i).Value) & "', "
                        For k As Integer = 6 To dgvEnterMarks.Columns.Count - 1
                            If dgvEnterMarks.Columns(k).Visible And is_split_subject(dgvEnterMarks.Columns(k).Name) Then
                                If count_ > 0 Then
                                    query &= ", "
                                End If

                                query = query & "`" & class_form & "_" & dgvEnterMarks.Columns(k).Name & "`='" & dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value & "'"
                                availableColumns.Add("" & class_form & "_" & dgvEnterMarks.Columns(k).Name & "")
                                count_ += 1

                            End If
                        Next
                        query &= " WHERE admno='" & escape_string(dgvEnterMarks.Item("admin_no", i).Value) & "' AND Examination='" & escape_string(exam_name) & "' AND Year='" & yr & "' AND Term='" & tm & "'"
                    Else
                        'insert split subjects query
                        query = "INSERT INTO exam_split_subject_results(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,"
                        For k As Integer = 6 To dgvEnterMarks.Columns.Count - 1
                            If dgvEnterMarks.Columns(dgvEnterMarks.Columns(k).Name).Visible And is_split_subject(dgvEnterMarks.Columns(k).Name) Then
                                query &= "`" & class_form & "_" & dgvEnterMarks.Columns(k).Name & "`"
                                availableColumns.Add("" & class_form & "_" & dgvEnterMarks.Columns(k).Name & "")
                                If k < dgvEnterMarks.Columns.Count - 4 Then
                                    query &= ","
                                End If
                            End If
                        Next
                        query = query & ") VALUES"
                        query &= "(NULL, '" & dgvEnterMarks.Item("admin_no", i).Value & "','" & escape_string(dgvEnterMarks.Item("StudentName", i).Value) &
                        "', '" & escape_string(exam_name) & "', '" & tm & "', '" & yr & "','"
                        For k As Integer = 6 To dgvEnterMarks.Columns.Count - 1
                            If dgvEnterMarks.Columns(dgvEnterMarks.Columns(k).Name).Visible And is_split_subject(dgvEnterMarks.Columns(k).Name) Then
                                If IsNumeric(dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value) Then
                                    If dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value.ToString.Length > 1 Then
                                        query = query & dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value & "', '"
                                    Else
                                        query = query & "0" & dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value & "', '"
                                    End If
                                Else
                                    query = query & dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value & "', '"
                                End If
                            End If
                        Next
                    End If

                    'query = query.Substring(0, query.Length - 3) & ")"

                    query2 = "INSERT INTO exam_results(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,"
                    For k As Integer = 0 To subjabb.Length - 1
                        query2 &= "`" & subjname(k) & "`, "
                    Next
                    query2 = query2 & " `Total`, `B7_Total`, `B7SB_TP`, `B7NSB_TP`, `SB_TP`, `NSB_TP`, `CLASS`, `STREAM`) VALUES"
                    'For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
                    query2 &= "(NULL, '" & dgvEnterMarks.Item("admin_no", i).Value & "','" & escape_string(dgvEnterMarks.Item("StudentName", i).Value) &
                    "', '" & escape_string(exam_name) & "', '" & tm & "', '" & yr & "','"
                    For l As Integer = 0 To subjabb.Length - 1
                        out_of = markOutOf(subjname(l), dgvEnterMarks.Item("Stream", i).Value)
                        If has_constituents(subjects(l)) Then
                            query2 &= subject_total(subjects(l), i, out_of) & "','"
                        Else
                            query2 &= dgvEnterMarks.Item(subjname(l), i).Value & "','"
                        End If

                    Next
                    query2 = query2 & total & "','" & best_of_7(i) & "','" & sb_tp & "','" & tp & "','" & compute_points(i) & "','" & nsb_tp & "','" & escape_string(ret_name(class_form)) & "', '" & escape_string(dgvEnterMarks.Item("Stream", i).Value) & "')"
                    If get_class(dgvEnterMarks.Item("admin_no", i).Value).ToString = "False" Then
                        failure("Could Not Determine The Stream For Student With Admission Number: " & dgvEnterMarks.Item("admin_no", i).Value & ". Therefore The Saving Has Been Terminated. Exiting..")
                        progress.Visible = False
                        progress.Increment(-100)
                        Exit Sub
                    End If
                    total = 0
                    progress.Increment(increment)
                    If Not qwrite(query2) Then
                        rollback()
                        failure("Could Not Save Records!  You may have checked the 'Show Subjects Contribution' option when you do not have split subject entries")
                        progress.Visible = False
                        Exit Sub
                    Else
                        If splits.Length > 0 Then
                            confirmRows()

                            query = query.Replace(", ,", ",")

                            If Not qwrite(query) Then
                                rollback()
                                failure("Could Not Save Records")
                                progress.Visible = False
                                Exit Sub
                            End If
                        End If
                    End If
                    total = 0
                End If
            Next
        Else
            For i = 0 To dgvEnterMarks.Rows.Count - 1
                If ExistsStudentInRecord(i) Then
                    total = 0
                    For k As Integer = 0 To subjabb.Length - 1
                        If IsNumeric(dgvEnterMarks.Item(subjname(k), i).Value) Then
                            out_of = markOutOf(subjname(k), dgvEnterMarks.Item("Stream", i).Value)
                            total += (dgvEnterMarks.Item(subjname(k), i).Value / out_of) * 100
                        End If
                    Next
                    query = "UPDATE " & table & " SET StudentName='" & escape_string(dgvEnterMarks.Item("StudentName", i).Value) & "',"
                    For k As Integer = 0 To subjabb.Length - 1
                        If dgvEnterMarks.Columns(subjname(k)).visible Then
                            If IsNumeric(dgvEnterMarks.Item(subjname(k), i).value) Then
                                If CInt(dgvEnterMarks.Item(subjname(k), i).value) > 9 Then
                                    query = query & "`" & subjabb(k) & "`='" & Convert.ToDouble(dgvEnterMarks.Item(subjname(k), i).Value) & "', "
                                Else
                                    query = query & "`" & subjabb(k) & "`='0" & CInt(dgvEnterMarks.Item(subjname(k), i).Value) & "', "
                                End If
                            Else
                                query = query & "`" & subjabb(k) & "`='" & dgvEnterMarks.Item(subjname(k), i).Value & "', "
                            End If
                        End If
                    Next
                    query = query & "Total='" & total & "', B7_Total='" & best_of_7(i) & "', B7SB_TP='" & sb_tp & "', B7NSB_TP='" & tp & "', NSB_TP='" & compute_points(i) & "', SB_TP='" & nsb_tp & "' WHERE admno='" & escape_string(dgvEnterMarks.Item("admin_no", i).Value) & "' AND Examination='" & escape_string(exam_name) & "' AND Year='" & yr & "' AND Term='" & tm & "'"
                    progress.Increment(increment)
                    confirmRows()

                    If Not qwrite(query) Then
                        rollback()
                        failure("Could Not Save Records")
                        progress.Visible = False
                        Exit Sub
                    End If
                Else
                    query = "INSERT INTO " & table & "(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,"
                    For k As Integer = 0 To subjabb.Length - 1
                        If dgvEnterMarks.Columns(subjname(k)).Visible Then
                            If IsNumeric(dgvEnterMarks.Item(subjname(k), i).Value) Then
                                out_of = markOutOf(subjname(k), dgvEnterMarks.Item("Stream", i).Value)
                                total += (dgvEnterMarks.Item(subjname(k), i).Value / out_of) * 100
                            End If
                            query &= "`" & subjname(k) & "`,"
                        End If
                    Next
                    query = query & " `Total`, `B7_Total`, `B7SB_TP`, `B7NSB_TP`, `SB_TP`, `NSB_TP`, `CLASS`, `STREAM`) VALUES"
                    query &= "(NULL, '" & dgvEnterMarks.Item("admin_no", i).Value & "','" & escape_string(dgvEnterMarks.Item("StudentName", i).Value) &
                    "', '" & escape_string(exam_name) & "', '" & tm & "', '" & yr & "','"
                    For k As Integer = 0 To subjabb.Length - 1
                        If dgvEnterMarks.Columns(subjname(k)).Visible Then
                            If IsNumeric(dgvEnterMarks.Item(subjname(k).ToString, i).Value) Then
                                If dgvEnterMarks.Item(subjname(k).ToString, i).Value > 9 Then
                                    query = query & dgvEnterMarks.Item(subjname(k), i).Value & "', '"
                                Else
                                    query = query & "0" & dgvEnterMarks.Item(subjname(k), i).Value & "', '"
                                End If
                            Else
                                query = query & dgvEnterMarks.Item(subjname(k), i).Value & "', '"
                            End If
                        End If
                    Next
                    If get_class(dgvEnterMarks.Item("admin_no", i).Value).ToString = "False" Then
                        failure("Could Not Determine The Stream For Student With Admission Number: " & dgvEnterMarks.Item("admin_no", i).Value & ". Therefore The Saving Has Been Terminated. Exiting..")
                        progress.Visible = False
                        progress.Increment(-100)
                        Exit Sub
                    End If
                    query = query & total & "','" & best_of_7(i) & "','" & sb_tp & "','" & tp & "','" & compute_points(i) & "','" & nsb_tp & "','" & escape_string(ret_name(class_form)) & "', '" & escape_string(dgvEnterMarks.Item("Stream", i).Value) & "')"
                    confirmRows()

                    If Not qwrite(query) Then
                        rollback()
                        failure("Could Not Save Records")
                        progress.Visible = False
                        Exit Sub
                    End If
                    total = 0
                End If
            Next
        End If

        results_entered = True
        commit()
        success("Examination Results Successfully Saved!")
    End Sub

    Private Sub confirmRows()
        For Each item In availableColumns
            If Not tableColumns.Contains(item) Then
                If qwrite("ALTER TABLE `exam_split_subject_results` ADD COLUMN `" + item + "` VARCHAR(255) NOT NULL DEFAULT '' AFTER `" + tableColumns(tableColumns.Count - 1) + "`;") Then
                    tableColumns.Add(item)
                End If
            End If
        Next
    End Sub

    Private Function ExistsStudentInRecord(ByVal row As Integer) As Boolean
        qread("SELECT id FROM exam_results WHERE admno='" & dgvEnterMarks.Item("admin_no", row).Value & "' AND Examination='" & escape_string(exam_name) & "' AND year='" & yr & "' AND Term='" & tm & "'")
        If dbreader.RecordsAffected > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function ExistsStudentInRecord2(ByVal row As Integer) As Boolean
        qread("SELECT id FROM exam_split_subject_results WHERE admno='" & dgvEnterMarks.Item("admin_no", row).Value & "' AND Examination='" & escape_string(exam_name) & "' AND year='" & yr & "' AND Term='" & tm & "'")
        If dbreader.RecordsAffected > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function get_class(ByVal adm)
        qread("SELECT stream FROM students WHERE admin_no='" & adm & "'")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            Return dbreader("stream")
        Else
            failure("Could Not Determine The Correct Stream For Student Adm. No. " & adm & ". You Must Fix This Before You Continue...")
            Return False
        End If
    End Function
    Private Sub save()
        Dim query2 As String = Nothing
        Dim total As Integer = 0
        Dim i As Integer
        Dim out_of As Double

        getColumns()

        If Not CheckBox1.Checked Then
            query = "INSERT INTO " & table & "(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,"
            For i = 0 To dgvEnterMarks.Rows.Count - 1

                If String.IsNullOrEmpty(dgvEnterMarks.Item("admin_no", i).Value) Then
                    Continue For
                End If

                If i = 0 Then
                    For k As Integer = 0 To subjabb.Length - 1
                        out_of = markOutOf(subjname(k), dgvEnterMarks.Item("Stream", i).Value)
                        If dgvEnterMarks.Columns(subjname(k)).Visible Then
                            If IsNumeric(dgvEnterMarks.Item(subjname(k), i).Value) Then
                                total += (dgvEnterMarks.Item(subjname(k), i).Value / out_of) * 100
                            End If
                            query &= "`" & subjname(k) & "`,"
                        End If
                    Next
                    query = query & " `Total`, `B7_Total`, `B7SB_TP`, `B7NSB_TP`, `SB_TP`, `NSB_TP`, `CLASS`, `STREAM`) VALUES"
                End If
                query &= "(NULL, '" & dgvEnterMarks.Item("admin_no", i).Value & "','" & escape_string(dgvEnterMarks.Item("StudentName", i).Value) &
                "', '" & escape_string(exam_name) & "', '" & tm & "', '" & yr & "','"
                For k As Integer = 0 To subjabb.Length - 1
                    If dgvEnterMarks.Columns(subjname(k)).Visible Then
                        If IsNumeric(dgvEnterMarks.Item(subjname(k).ToString, i).Value) Then
                            If dgvEnterMarks.Item(subjname(k).ToString, i).Value.ToString.Length > 1 Then
                                query = query & dgvEnterMarks.Item(subjname(k), i).Value & "', '"
                            Else
                                query = query & "0" & dgvEnterMarks.Item(subjname(k), i).Value & "', '"
                            End If
                        Else
                            query = query & dgvEnterMarks.Item(subjname(k), i).Value & "', '"
                        End If
                    End If
                Next
                If get_class(dgvEnterMarks.Item("admin_no", i).Value).ToString = "False" Then
                    failure("Could Not Determine The Stream For Student With Admission Number: " & dgvEnterMarks.Item("admin_no", i).Value & ". Therefore The Saving Has Been Terminated. Exiting..")
                    progress.Visible = False
                    progress.Increment(-100)
                    Exit Sub
                End If
                query = query & total & "','" & best_of_7(i) & "','" & sb_tp & "','" & tp & "','" & compute_points(i) & "','" & nsb_tp & "','" & escape_string(ret_name(class_form)) & "', '" & escape_string(dgvEnterMarks.Item("Stream", i).Value) & "')"
                total = 0
                If i < dgvEnterMarks.Rows.Count - 1 Then
                    query = query & ", "
                    'If i = dgvEnterMarks.Rows.Count - 2 Then
                    '    query = query & "; "
                    'Else
                    '    query = query & ", "
                    'End If


                End If
                progress.Increment(increment)
            Next
        Else
            query = "INSERT INTO exam_split_subject_results(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,"
            query2 = "INSERT INTO exam_results(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,"
            For k As Integer = 0 To subjabb.Length - 1
                query2 &= "`" & subjname(k) & "`, "
            Next
            query2 = query2 & " `Total`, `B7_Total`, `B7SB_TP`, `B7NSB_TP`, `SB_TP`, `NSB_TP`, `CLASS`, `STREAM`) VALUES"
            For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
                query2 &= "(NULL, '" & dgvEnterMarks.Item("admin_no", k).Value & "','" & escape_string(dgvEnterMarks.Item("StudentName", k).Value) &
                "', '" & escape_string(exam_name) & "', '" & tm & "', '" & yr & "','"
                For l As Integer = 0 To subjabb.Length - 1
                    out_of = markOutOf(subjname(l), dgvEnterMarks.Item("Stream", k).Value)
                    If has_constituents(subjects(l)) Then
                        query2 &= subject_total(subjects(l), k, out_of) & "','"
                    Else
                        query2 &= dgvEnterMarks.Item(subjname(l), k).Value & "','"
                    End If

                Next
                query2 = query2 & total & "','" & best_of_7(k) & "','" & sb_tp & "','" & tp & "','" & compute_points(k) & "','" & nsb_tp & "','" & escape_string(ret_name(class_form)) & "', '" & escape_string(dgvEnterMarks.Item("Stream", k).Value) & "')"
                If k < dgvEnterMarks.Rows.Count - 1 Then
                    query2 &= ","
                End If
            Next
            For i = 0 To dgvEnterMarks.Rows.Count - 1
                If i = 0 Then
                    For k As Integer = 6 To dgvEnterMarks.Columns.Count - 1
                        If dgvEnterMarks.Columns(dgvEnterMarks.Columns(k).Name).Visible And is_split_subject(dgvEnterMarks.Columns(k).Name) Then
                            query &= "`" & class_form & "_" & dgvEnterMarks.Columns(k).Name & "`"
                            availableColumns.Add("" & class_form & "_" & dgvEnterMarks.Columns(k).Name & "")
                            If k <= dgvEnterMarks.Columns.Count - 5 Then
                                query &= ","
                            End If
                        End If
                    Next
                    If query.Substring(query.Length - 1) = "," Then
                        query = query.Substring(0, query.Length - 1)
                    End If
                    query = query & ") VALUES"
                End If
                query &= "(NULL, '" & dgvEnterMarks.Item("admin_no", i).Value & "','" & escape_string(dgvEnterMarks.Item("StudentName", i).Value) &
                "', '" & escape_string(exam_name) & "', '" & tm & "', '" & yr & "','"
                For k As Integer = 6 To dgvEnterMarks.Columns.Count - 1
                    If dgvEnterMarks.Columns(dgvEnterMarks.Columns(k).Name).Visible And is_split_subject(dgvEnterMarks.Columns(k).Name) Then
                        If IsNumeric(dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value) Then
                            If dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value.ToString.Length > 1 Then
                                query = query & dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value & "', '"
                            Else
                                query = query & "0" & dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value & "', '"
                            End If
                        Else
                            query = query & dgvEnterMarks.Item(dgvEnterMarks.Columns(k).Name, i).Value & "', '"
                        End If
                    End If
                Next
                If get_class(dgvEnterMarks.Item("admin_no", i).Value).ToString = "False" Then
                    failure("Could Not Determine The Stream For Student With Admission Number: " & dgvEnterMarks.Item("admin_no", i).Value & ". Therefore The Saving Has Been Terminated. Exiting..")
                    progress.Visible = False
                    progress.Increment(-100)
                    Exit Sub
                End If
                query = query.Substring(0, query.Length - 3) & ")"
                total = 0
                If i < dgvEnterMarks.Rows.Count - 1 Then
                    query = query & ", "
                End If
                progress.Increment(increment)
            Next
        End If
        start()
        If CheckBox1.Checked Then
            confirmRows()

            If qwrite(query) Then
                If qwrite(query2) Then
                Else
                    rollback()
                    failure("Examination Results Saving Failed! You may have checked the 'Show Subjects Contribution' option when you do not have split subject entries")
                End If
                results_entered = True
                commit()
                success("Examination Results Successfully Saved!")
            Else
                rollback()
                failure("Examination Results Saving Failed! You may have checked the 'Show Subjects Contribution' option when you do not have split subject entries")
            End If
        Else
            confirmRows()

            Dim test As String = parseQuery(query)

            If qwrite(parseQuery(query)) Then
                results_entered = True
                commit()
                success("Examination Results Successfully Saved!")
            Else
                rollback()
                failure("Examination Results Saving Failed!")
            End If
        End If
    End Sub
    Private Function subject_total(name As String, row As Integer, out_of As Double) As Double
        subject_total = 0
        qread("SELECT * FROM split_subjects WHERE subject='" & escape_string(name) & "' AND class='" & ret_name(class_form) & "'")
        While dbreader.Read
            If IsNumeric(dgvEnterMarks.Item(dbreader("abbreviation"), row).value) Then
                subject_total += (dgvEnterMarks.Item(dbreader("abbreviation"), row).value / dbreader("contribution")) * dbreader("weighted")
            End If
        End While
        Return CInt(subject_total)
    End Function
    Private Function has_constituents(name As String) As Boolean
        qread("SELECT abbreviation FROM split_subjects WHERE subject='" & escape_string(name) & "'", 1)
        Return dbreader1.HasRows
    End Function
    Private Function is_split_subject(name As String) As Boolean
        qread("SELECT abbreviation FROM split_subjects WHERE abbreviation='" & name & "'", 1)
        dbreader1.Read()
        If dbreader1.RecordsAffected = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function print_student_report2()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report2
        Return print_document
    End Function
    Dim start_from As Integer = 0
    Private Sub print_report2(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.HasMorePages = False
        Dim line As Integer = 30
        Dim topline As Integer
        Dim CenterPage As Single
        Dim left_margin As Integer = 50
        Dim count As Integer = 0
        If start_from = 0 Then
            If S_NAME <> "" Then
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(S_NAME.ToUpper, header_font).Width / 2)
                e.Graphics.DrawString(S_NAME.ToUpper, header_font, Brushes.Black, CenterPage, line)
                line += header_font.Height + 2
            End If
            If S_ADDRESS <> "" Then
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("P.O. BOX " & S_ADDRESS.ToUpper & ", " & S_LOCATION.ToUpper, other_font).Width / 2)
                e.Graphics.DrawString("P.O. BOX " & S_ADDRESS.ToUpper & ", " & S_LOCATION.ToUpper, other_font, Brushes.Black, CenterPage, line)
                line += other_font.Height + 5
            End If
            If S_PHONE <> "" Then
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("TELEPHONE: " & S_PHONE, other_font).Width / 2)
                e.Graphics.DrawString("TELEPHONE: " & S_PHONE, other_font, Brushes.Black, CenterPage, line)
                line += other_font.Height + 5
            End If
            If mode Then
                For k As Integer = 0 To exam_names.Length - 1
                    exam_name &= exam_names(k)
                    If k > 0 Then
                        exam_name &= "/"
                    End If
                Next
            End If
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(ret_name(class_form) & " " & stream & " " & exam_name & " MARKS FOR TERM " & tm & " " & yr, other_font).Width / 2)
            e.Graphics.DrawString(ret_name(class_form) & " " & stream & " " & exam_name & " MARKS FOR TERM " & tm & " " & yr, other_font, Brushes.Black, CenterPage, line)
            line += other_font.Height + 5
        End If
        topline = line
        For col As Integer = 0 To dgvEnterMarks.Columns.Count - 1
            If dgvEnterMarks.Columns(col).Visible Then
                Try
                    e.Graphics.DrawString(dgvEnterMarks.Columns(col).HeaderText, other_font, Brushes.Black, left_margin, line - 1)
                Catch ex As Exception
                    e.Graphics.DrawString(dgvEnterMarks.Columns(col).HeaderText, other_font, Brushes.Black, left_margin, line - 1)
                End Try
                count += 1
                If count = 2 Then
                    left_margin += 200
                Else
                    left_margin += 50
                End If
            End If
        Next
        Dim right_margin As Integer = left_margin
        e.Graphics.DrawLine(Pens.Black, 42, line, right_margin, line)
        line += 15
        For row As Integer = start_from To dgvEnterMarks.Rows.Count - 1
            line += 1
            If line >= 806 And row < dgvEnterMarks.Rows.Count - 1 Then
                left_margin = 10
                For k As Integer = 0 To dgvEnterMarks.Columns.Count - 6
                    If k = 2 Then
                        left_margin += 200
                    Else
                        left_margin += 50
                    End If
                    e.Graphics.DrawLine(Pens.Black, left_margin - 15, line, left_margin - 15, topline)
                Next
                left_margin = 50
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
                e.HasMorePages = True
                start_from = row
                Exit Sub
            End If
            left_margin = 50
            count = 0
            For col As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                If dgvEnterMarks.Columns(col).Visible Then
                    If dgvEnterMarks.Columns(col).Name = "IndexNo" Then
                        If dgvEnterMarks.Item("IndexNo", row).Value <> Nothing Then
                            If dgvEnterMarks.Item("IndexNo", row).Value.ToString.Length > 3 Then
                                e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value.ToString.Substring(dgvEnterMarks.Item("IndexNo", row).Value.ToString.Length - 3, 3), smallfont, Brushes.Black, left_margin, line + 2)
                            Else
                                e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                            End If
                        End If
                    Else
                        e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                    End If
                    count += 1
                    If count = 2 Then
                        left_margin += 200
                    Else
                        left_margin += 50
                    End If
                End If
            Next
            line += 1
            e.Graphics.DrawLine(Pens.Black, 45, line, left_margin, line)
            line += smallfont.Height + 5
        Next
        left_margin = 10
        For k As Integer = 0 To dgvEnterMarks.Columns.Count - 6
            If k = 2 Then
                left_margin += 200
            Else
                left_margin += 50
            End If
            e.Graphics.DrawLine(Pens.Black, left_margin - 15, line, left_margin - 15, topline)
        Next
        left_margin = 50
        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
        start_from = 0
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim Print_Preview As New PrintPreviewDialog
        'Dim print_dialog As New PrintDialog
        'Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report2()
        'print_document.DefaultPageSettings.Landscape = CheckBox2.Checked
        'Print_Preview.Document = print_document
        'Print_Preview.ShowDialog()

        Dim title As String = ret_name(class_form) & " " & stream & " " & exam_name & " MARKS FOR TERM " & tm & " " & yr
        generateFromDataTable(title, "From Grid", "", Nothing, dgvEnterMarks)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'exportToExcel(dgvEnterMarks)

        If SaveFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        Dim filename As String = SaveFileDialog1.FileName
        If filename = Nothing Then
            filename = Environment.GetEnvironmentVariable("HOMEDRIVE") & "\export_data"
        End If
        filename &= ".csv"
        FileOpen(1, filename, OpenMode.Output)
        Dim line As String = Nothing
        For k As Integer = 0 To dgvEnterMarks.Columns.Count - 1
            If dgvEnterMarks.Columns(k).Visible = True Then
                line &= dgvEnterMarks.Columns(k).HeaderText
                If k < dgvEnterMarks.Columns.Count - 1 Then
                    line &= ","
                End If
            End If
        Next
        line += vbNewLine
        For row As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            For col As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                If dgvEnterMarks.Columns(col).Visible = True Then
                    line &= dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value
                    If col < dgvEnterMarks.Columns.Count - 1 Then
                        line &= ","
                    End If
                End If
            Next
            line += vbNewLine
        Next
        Print(1, line)
        FileClose(1)
        Dim oExcelFile As Object
        Try
            oExcelFile = GetObject(, "Excel.Application")
        Catch
            oExcelFile = CreateObject("Excel.Application")
        End Try
        oExcelFile.Visible = False
        oExcelFile.Workbooks.Open(SaveFileDialog1.FileName)
        oExcelFile.DisplayAlerts = False
        'todo commented the below code
        '  oExcelFile.ActiveWorkbook.SaveAs(Filename:=SaveFileDialog1.FileName, FileFormat:=Excel.XlFileFormat.xlExcel5, CreateBackup:=False)
        oExcelFile.ActiveWorkbook.Close(SaveChanges:=False)
        oExcelFile.DisplayAlerts = True
        oExcelFile.Quit()
        'File.Delete(SaveFileDialog1.FileName & ".csv")
        success("Data Successfully Exported To " & SaveFileDialog1.FileName & ".xls")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If cboYear.SelectedItem = Nothing Or cboTerm.SelectedItem = Nothing Or cboExamName.SelectedItem = Nothing Or cboClass.SelectedItem = Nothing Or cboStream.SelectedItem = Nothing Then
            failure("Please Select An Examination And / Or Class / Stream To Enter Out Of Mark")
            Return
        End If

        If cboSubject.SelectedItem = Nothing Then
            failure("Please Select Subject To Load/Enter Marks For!")
            Exit Sub
        End If
        class_stream = cboStream.SelectedItem
        If cboStream.SelectedItem = "All" Then
            title = "EXAMINATION MARKS ENTRY FOR " & cboClass.SelectedItem.ToString.ToUpper
            stream_mode = False
        Else
            title = "EXAMINATION MARKS ENTRY FOR " & cboClass.SelectedItem.ToString.ToUpper & " " & cboStream.SelectedItem
            stream_mode = True
        End If
        subj = cboSubject.SelectedItem
        search_teachers = True
        tm = cboTerm.SelectedItem
        stream = cboStream.SelectedItem
        yr = cboYear.SelectedItem
        is_editable = IsEditableResults()
        If is_editable And Not IsAdmin() Then
            btnClear.Enabled = False
        Else
            btnClear.Enabled = True
        End If
        load_entry_form()
        Me.Text = title
        dgvEnterMarks.Rows.Clear()
        Dim count = dgvEnterMarks.Columns.Count - 1
        If count > 6 Then
            For k As Integer = dgvEnterMarks.Columns.Count - 1 To 6 Step -1
                dgvEnterMarks.Columns.RemoveAt(k)
            Next
        End If
        create_dataform()
        load_form()
        mark = get_total_mark(exam_name, tm)
        loadSubjectsOutOf()
    End Sub
    '  Dim subj_out_of(subjabb.Length - 1)()
    Dim subj_out_of(12)()

    Private Sub loadSubjectsOutOf()
        'todo change the code below added a try catch statement
        For k As Integer = 0 To subjabb.Length - 1
            Try
                ReDim subj_out_of(k)(cboStream.Items.Count - 2)
                For i As Integer = 0 To subj_out_of(k).Length - 1
                    subj_out_of(k)(i) = 0
                Next
            Catch ex As Exception

            End Try
        Next

        Try
            For k As Integer = 0 To subjabb.Length - 1
                For i As Integer = 0 To subj_out_of(k).Length - 1
                    subj_out_of(k)(i) = SubjectOutOf(subjname(k), cboTerm.SelectedItem, cboYear.SelectedItem, cboExamName.SelectedItem, cboClass.SelectedItem, cboStream.Items.Item(i).ToString)
                Next
            Next
        Catch ex As Exception

        End Try

    End Sub
    Private Sub load_entry_form()
        table = "exam_results"
        class_form = get_name(cboClass.SelectedItem)
        stream = cboStream.SelectedItem
        exam_name = cboExamName.SelectedItem
    End Sub



    Private Sub Permissions()
        'permissions sub determines which particular teacher can add or edit a particular exam admin is all and teacher is restricted
        cboSubject.Items.Clear()
        USER_ID = 1 'todo remove this user id hardcoded
        If USER_ID = 1 Or USER_ID = 3 Then
            cboSubject.Items.Add("All")
            For k As Integer = 0 To subjabb.Length - 1
                cboSubject.Items.Add(subjects(k))
            Next
        Else
            For k As Integer = 0 To subjabb.Length - 1
                If IsSubjectTeacher(subjects(k), cboClass.SelectedItem, cboStream.SelectedItem, cboTerm.SelectedItem, cboYear.SelectedItem) Then
                    cboSubject.Items.Add(subjects(k))
                End If
            Next
        End If
        cboSubject.SelectedItem = "All"
    End Sub
    Private Sub fill_exam()
        If qread("SELECT ExamName FROM examinations WHERE Term='" & cboTerm.SelectedItem & "' AND Year='" & cboYear.SelectedItem & "'") Then
            cboExamName.Items.Clear()
            cboExamName.Items.Add(None)
            While dbreader.Read
                cboExamName.Items.Add(dbreader("ExamName"))
            End While
        Else
            failure("Could Not Load Examinations!")
        End If
    End Sub
    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged, cboTerm.SelectedIndexChanged
        Permissions()
        If cboTerm.SelectedItem <> None And cboYear.SelectedItem.ToString <> None Then
            fill_exam()
        End If
        loadClasses()
    End Sub

    Private Sub cboClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        If cboClass.SelectedItem <> None Then
            fill_class(cboClass.SelectedItem, cboStream)
            cboStream.Items.Add("All")
            cboStream.SelectedItem = "All"
            Permissions()
        End If
    End Sub

    Private Sub cboStream_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStream.SelectedIndexChanged
        Permissions()
    End Sub
    Private Sub loadClasses()
        cboClass.Items.Clear()
        qread("SELECT class FROM examined_classes WHERE (Examination='" & escape_string(cboExamName.SelectedItem) & "' AND Term='" & escape_string(cboTerm.SelectedItem) & "' AND Year='" & cboYear.SelectedItem & "')")
        While dbreader.Read
            cboClass.Items.Add(dbreader("class"))
        End While
    End Sub

    Private Sub btnImportResults_Click(sender As Object, e As EventArgs) Handles btnImportResults.Click

        If dgvEnterMarks.Rows.Count = 0 Then
            MsgBox("Please select the year, term, exam .... inorder to add students to the list")
            Return
        End If

        Dim abbr As String = String.Empty
        qread("select abbreviation from subjects where subject = '" + cboSubject.SelectedItem.ToString() + "';")
        While dbreader.Read
            abbr = dbreader("abbreviation")
        End While

        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            dgvEnterMarks.Rows(k).Cells(abbr).Value = "-"
        Next

        If Not OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim rCnt As Integer
        Dim cCnt As Integer
        Dim Obj As Object
        Dim Obj2 As Object

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(OpenFileDialog1.FileName)
        xlWorkSheet = xlWorkBook.Worksheets("sheet1")

        range = xlWorkSheet.UsedRange

        For rCnt = 1 To range.Rows.Count
            Obj = CType(range.Cells(rCnt, 1), Excel.Range)
            Obj2 = CType(range.Cells(rCnt, 3), Excel.Range)
            For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
                If dgvEnterMarks.Rows(k).Cells("admin_no").Value.ToString() = Obj.value.ToString() Then
                    dgvEnterMarks.Rows(k).Cells(abbr).Value = Obj2.value.ToString()
                End If
            Next
        Next

        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Editor_Click(sender As Object, e As EventArgs) Handles Editor.Click

        If Not OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim rCnt As Integer
        Dim cCnt As Integer
        Dim Obj As Object
        Dim Obj2 As Object

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(OpenFileDialog1.FileName)
        xlWorkSheet = xlWorkBook.Worksheets("sheet1")

        range = xlWorkSheet.UsedRange
        Dim rowValues As New Dictionary(Of String, String)
        Dim col As String
        Dim query As String
        Dim values As String
        Dim admNumber As String
        Dim parentQuery As String
        Dim parentsColums As New List(Of String)(New String() {"father", "mother", "phone", "address", "admin_no"})
        Dim pCol As String
        Dim pVal As String

        For rCnt = 2 To range.Rows.Count
            rowValues.Clear()
            query = String.Empty
            values = String.Empty
            admNumber = String.Empty
            pCol = String.Empty
            pVal = String.Empty

            For cCnt = 1 To range.Columns.Count

                Obj = CType(range.Cells(rCnt, cCnt), Excel.Range)
                If (Not String.IsNullOrEmpty(Obj.value)) Then
                    Obj2 = CType(range.Cells(1, cCnt), Excel.Range)
                    col = Obj2.value

                    rowValues.Add(col, Obj.value)
                End If
            Next

            If rowValues.Count > 0 Then
                For j As Integer = 0 To rowValues.Count - 1
                    If Not parentsColums.Contains(rowValues.Keys(j).ToLower()) Then
                        values += rowValues.Keys(j) + "= '" + rowValues(rowValues.Keys(j)) + "', "
                    End If
                Next

                values = values.Remove(values.Length - 2, 2)
                Obj2 = CType(range.Cells(rCnt, 1), Excel.Range)
                admNumber = Obj2.value
                query = "UPDATE students SET " + values + " WHERE  admin_no=" + admNumber + ""

                If qwrite(query) Then
                    Dim parents As New List(Of String)(New String() {"father", "mother"})
                    For z As Integer = 0 To parents.Count - 1

                        pCol = String.Empty
                        pVal = String.Empty

                        If rowValues.ContainsKey(parents(z)) Then
                            pCol += "type, "
                            If parents(z) = "father" Then
                                pVal += "'Father', "
                            Else
                                pVal += "'Mother', "
                            End If
                            For i = 0 To parentsColums.Count - 1
                                If rowValues.ContainsKey(parentsColums(i)) Then
                                    If z = 0 Then
                                        If Not parentsColums(i) = "mother" Then
                                            pCol += parentsColums(i) + ", "
                                            pVal += "'" + rowValues(parentsColums(i)) + "', "
                                        End If
                                    Else
                                        If Not parentsColums(i) = "father" Then
                                            pCol += parentsColums(i) + ", "
                                            pVal += "'" + rowValues(parentsColums(i)) + "', "
                                        End If
                                    End If
                                End If

                            Next


                            pCol = pCol.Remove(pCol.Count - 2, 2).Replace("father", "name").Replace("mother", "name")
                            pVal = pVal.Remove(pVal.Count - 2, 2)

                            parentQuery = "INSERT INTO parents_guardians (" + pCol + ") VALUES (" + pVal + ");"
                            If qwrite(parentQuery) Then
                            End If


                        End If
                    Next
                End If
            End If

        Next


        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub

    Private Sub cboExamName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExamName.SelectedIndexChanged
        loadClasses()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If cboYear.SelectedItem <> Nothing And cboTerm.SelectedItem <> Nothing And cboExamName.SelectedItem <> Nothing And cboClass.SelectedItem <> Nothing And cboStream.SelectedItem <> "All" Then
            exam_name = cboExamName.SelectedItem
            tm = cboTerm.SelectedItem
            yr = cboYear.SelectedItem
            class_form = cboClass.SelectedItem
            stream = cboStream.SelectedItem
            Dim frm As New frmSubjectsOutOf
            frm.ShowDialog()
        Else
            failure("Please Select An Examination And / Or Class / Stream To Enter Out Of Mark")
        End If
    End Sub
End Class