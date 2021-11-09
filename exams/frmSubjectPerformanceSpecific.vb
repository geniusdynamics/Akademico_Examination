Imports System.Drawing.Printing
Imports System.IO
Public Class frmSubjectPerformanceSpecific
    Dim state As Boolean = False
    Dim index As Integer = 0
    Private Sub frmSubjectPerformance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Or Not get_subjects() Or Not dbNewOpen() Then
            Me.Close()
        Else
            get_grades()
            grpAnalyze.Enabled = False
            'btnAddExam.Enabled = False
            Button4.Enabled = False
            'Button2.Enabled = False
            grpSelect.Enabled = True
            fill_years(cboYear)
            cboYear.SelectedItem = Today.Year
            get_term()
            state = True
            cboTerm.SelectedItem = term
            load_class(cboClass)
            chkBestOf7.Visible = Not IsPrimary()
            radSubject.Visible = chkBestOf7.Visible
            bestStud.Enabled = False
        End If
    End Sub

    Private Sub cboTerm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTerm.SelectedIndexChanged
        If cboTerm.SelectedItem <> None And state And cboYear.SelectedItem.ToString <> None Then
            fill_exam()
        Else
            cboExamName.Items.Clear()
            cboClass.Items.Clear()
        End If
    End Sub
    Private Sub fill_exam()
        If qread("SELECT ExamName FROM examinations WHERE Term='" & cboTerm.SelectedItem &
        "' AND Year='" & cboYear.SelectedItem & "'") Then
            cboExamName.Items.Clear()
            cboExamName.Items.Add(None)
            While dbreader.Read
                cboExamName.Items.Add(dbreader("ExamName"))
            End While
            dbreader.Close()
            cboExamName.SelectedItem = None
        Else
            failure("Could Not Load Examinations!")
            Me.Close()
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        If cboYear.SelectedItem.ToString <> None And cboTerm.SelectedItem <> None And state Then
            fill_exam()
        Else
            cboExamName.Items.Clear()
            cboClass.Items.Clear()
        End If
    End Sub


    Private Sub chkAnalyze_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mode = False
    End Sub
    Private Function isvalid()
        If chkMode.Checked Then
            If lstExaminations.Items.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            If cboYear.SelectedItem.ToString = None Then
                msg = "failure Choice For Year!"
                Return False
            ElseIf cboTerm.SelectedItem = None Then
                msg = "failure Choice For Term!"
                Return False
            ElseIf cboExamName.SelectedItem = Nothing Then
                msg = "failure Choice For Examination Name!"
                Return False
            ElseIf cboClass.SelectedItem = None Or cboClass.SelectedItem = "" Then
                msg = "failure Choice For Class!"
                Return False
            Else
                Return True
            End If
        End If

    End Function
    Private Sub analyze()
        grpSelect.Enabled = False
        grpAnalyze.Enabled = True
        'Button2.Enabled = True
        Button4.Enabled = True
    End Sub
    Private Sub denalyze()
        grpSelect.Enabled = True
        grpAnalyze.Enabled = False
        'Button2.Enabled = False
        Button4.Enabled = False
        mode = False
    End Sub
    Dim main_exam As String
    Private Sub btnAnalyze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyze.Click
        If isvalid() Then
            bestStud.Enabled = True
            If chkMode.Checked Then
                mode = True
                ReDim yrs(lstExaminations.Items.Count - 1), tms(lstExaminations.Items.Count - 1), exam_names(lstExaminations.Items.Count - 1), contribution(lstExaminations.Items.Count - 1), total_mark(lstExaminations.Items.Count - 1)
                For k As Integer = 0 To lstExaminations.Items.Count - 1
                    exam_names(k) = lstExaminations.Items.Item(k).Text
                    contribution(k) = lstExaminations.Items.Item(k).SubItems(1).Text
                    yrs(k) = lstExaminations.Items.Item(k).SubItems(2).Text
                    tms(k) = lstExaminations.Items.Item(k).SubItems(3).Text

                    'todo I have set the total_mark to a constant 100 original code is below
                    total_mark(k) = 100

                    'total_mark(k) = get_total_mark(exam_names(k), tms(k), yrs(k))
                Next
                analyze()
            Else
                mode = False
                yr = cboYear.SelectedItem
                tm = cboTerm.SelectedItem
                analyze()
            End If
        Else
            failure(msg)
        End If
    End Sub
    Private Sub chkMode_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMode.CheckedChanged
        If chkMode.Checked Then
            btnAddExam.Enabled = True
            txtContribution.Enabled = True
            grpMultiExaminations.Enabled = True
            analysis_mode = True
            mode = True
        Else
            lstExaminations.Items.Clear()
            btnAddExam.Enabled = False
            txtContribution.Enabled = False
            grpMultiExaminations.Enabled = False
            mode = False
            analysis_mode = False
        End If
    End Sub
    Private Function exists(ByVal str As String)
        Dim i As Integer
        For i = 0 To lstExaminations.Items.Count - 1
            If lstExaminations.Items.Item(i).Text = str Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub txtContribution_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContribution.KeyPress
        If Asc(e.KeyChar()) = 13 Then
            add_exam()
        End If
    End Sub
    Dim total_percentage As Double
    Private Sub add_exam()
        If cboExamName.SelectedItem <> None And IsNumeric(txtContribution.Text) And txtContribution.Text <> "" Then
            If Not exists(cboExamName.SelectedItem) Then
                Dim li As New ListViewItem
                li = lstExaminations.Items.Add(cboExamName.SelectedItem)
                li.SubItems.Add(txtContribution.Text)
                li.SubItems.Add(cboYear.SelectedItem)
                li.SubItems.Add(cboTerm.SelectedItem)
                total_percentage += txtContribution.Text
            Else
                failure("Examination Already Exists In Examination Listing")
            End If
        End If
    End Sub
    Private Sub btnAddExam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddExam.Click
        add_exam()
    End Sub

    Private Sub cboExamName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExamName.SelectedIndexChanged
        txtContribution.Clear()
        txtContribution.Focus()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        grade = False
        mod_subject = False
        mode = False
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        denalyze()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStudentRank.Click
        get_details()
        Dim frm As New frmStudentSubjectRank
        frm.ShowDialog()
    End Sub
    Private Sub get_details()
        tm = cboTerm.SelectedItem
        yr = cboYear.SelectedItem
        mod_subject = radSubject.Checked
        grading = radSubject.Checked
        best_of_7 = chkBestOf7.Checked
        exam_name = cboExamName.SelectedItem



        ' marks = get_total_mark(cboExamName.SelectedItem, tm)
        'todo modified marks set it to a constant 100 the original code is commented 

        marks = 100
        table = "exam_results"
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeanGradeAnalysis.Click
        get_details()
        wait("Computing Subject Grades...")
        Dim frm As New frmMeanAnalysis
        frm.ShowDialog()
    End Sub

    Private Sub btnGradesAttained_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGradesAttained.Click
        get_details()
        wait("Computing Exam Results...")
        Dim frm As New frmGradesAttained
        frm.ShowDialog()
    End Sub
    Private Sub btnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        index = 0
        ReDim tables(index)
        ReDim total_mark(index)
    End Sub

    Private Sub cboClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        If cboClass.SelectedItem <> None And cboClass.SelectedItem <> "" Then
            class_form = cboClass.SelectedItem
        End If
    End Sub

    Private Sub radSubject_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSubject.CheckedChanged
        If radSubject.Checked Then
            mod_subject = True
        Else
            mod_subject = False
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        get_details()
        create_report()
    End Sub
    Private Sub create_report()
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = prepare_class_list()
        printpreview.Document = print_document
        print_document.Print()
    End Sub
    Private Function prepare_class_list()
        Dim print_document As New PrintDocument
        Dim margin As New Margins(10, 10, 10, 10)
        print_document.DefaultPageSettings.Landscape = False
        print_document.DefaultPageSettings.Margins = margin
        AddHandler print_document.PrintPage, AddressOf print_class_list
        Return print_document
    End Function
    Dim words() As String
    Dim mp, totalmp, totalentries, entries, total(), mm As Integer
    Private Function get_exam_name()
        exam_name = ""
        If chkMode.Checked Then
            For k As Integer = 0 To lstExaminations.Items.Count - 1
                exam_name &= lstExaminations.Items(k).Text
                If k < lstExaminations.Items.Count - 1 Then
                    exam_name &= "/"
                End If
            Next
            Return exam_name
        Else
            Return cboExamName.SelectedItem
        End If
    End Function
    Private Sub print_class_list(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim line As Integer = 40
        Dim topline As Integer = line
        Dim left_margin As Integer = 20
        Dim right_margin As Integer = 800
        Dim col As Integer = 50
        exam_name = get_exam_name()
        Try
            e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, topline, 100, 100)
        Catch ex As Exception
            If Not confirm("You Have No School Logo To Print! Do You Want To Continue Printing?") Then
                Exit Sub
            End If
        End Try
        e.Graphics.DrawString(S_NAME.ToUpper, other_font, Brushes.Black, left_margin, line)
        line += other_font.Height + 5
        e.Graphics.DrawString("EXAMINATION DEPARTMENT", other_font, Brushes.Black, left_margin, line)
        line += other_font.Height + 5
        e.Graphics.DrawString("CLASS MEAN GRADE COUNT ANALYSIS", other_font, Brushes.Black, left_margin, line)
        line += other_font.Height + 5
        e.Graphics.DrawString(exam_name & "             Term: " & term & "          Year: " & Today.Year, other_font, Brushes.Black, left_margin, line)
        line += 20
        classes()
        ReDim total(grades.Length - 1)
        totalmp = 0
        Dim cnt As Integer
        wait("Complex Computation ...")
        For c As Integer = 0 To words.Length - 1
            totalentries = 0
            entries = 0
            mp = 0
            totalmp = 0
            mm = 0
            For k As Integer = 0 To grades.Length - 1
                total(k) = 0
            Next
            table = cboTerm.SelectedItem & "_" & cboYear.SelectedItem.ToString.Substring(2) & "_" & get_name(cboExamName.SelectedItem) & "_" & get_name(words(c))
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            e.Graphics.DrawString(words(c).ToUpper, smallfont, Brushes.Black, left_margin, line)
            topline = line - 20
            left_margin = 20
            col = 70
            For k As Integer = 0 To grades.Length - 1
                e.Graphics.DrawString(grades(k), smallfont, Brushes.Black, left_margin + col, line)
                col += 30
            Next
            e.Graphics.DrawString("ENTRY", smallfont, Brushes.Black, left_margin + col, line)
            col += 50
            e.Graphics.DrawString("M.P.", smallfont, Brushes.Black, left_margin + col, line)
            col += 60
            e.Graphics.DrawString("M.GRADE", smallfont, Brushes.Black, left_margin + col, line)
            col += 70
            e.Graphics.DrawString("M.MARK", smallfont, Brushes.Black, left_margin + col, line)
            line += 15
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            fill_stream(get_stream(words(c)))
            Dim column As Integer
            For s As Integer = 0 To streams.Length - 1
                wait("Computing " & words(c) & " " & streams(s) & "...")
                totalentries += entries
                entries = 0
                column = 73
                totalmp += mp
                mp = 0
                e.Graphics.DrawString(get_name(words(c)) & " " & streams(s), smallfont, Brushes.Black, left_margin, line)
                For k As Integer = 0 To grades.Length - 1
                    cnt = no_of_grades(grades(k), streams(s))
                    total(k) += cnt
                    e.Graphics.DrawString(cnt, smallfont, Brushes.Black, left_margin + column, line)
                    column += 30
                Next
                e.Graphics.DrawString(entries, smallfont, Brushes.Black, left_margin + column, line)
                column += 50
                e.Graphics.DrawString(Format(mp / entries, "0.00"), smallfont, Brushes.Black, left_margin + column, line)
                column += 60
                e.Graphics.DrawString(get_points(mp / entries), smallfont, Brushes.Black, left_margin + column, line)
                column += 70
                e.Graphics.DrawString(mean_mark(streams(s)), smallfont, Brushes.Black, left_margin + column, line)
                line += 15
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
                If s = streams.Length - 1 Then
                    totalmp += mp
                    totalentries += entries
                End If
            Next
            e.Graphics.DrawString("TOTAL", smallfont, Brushes.Black, left_margin, line)
            column = 73
            For k As Integer = 0 To grades.Length - 1
                e.Graphics.DrawString(total(k), smallfont, Brushes.Black, left_margin + column, line)
                column += 30
            Next
            e.Graphics.DrawString(totalentries, smallfont, Brushes.Black, left_margin + column, line)
            column += 50
            If totalentries = 0 Or totalmp = 0 Then
                e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
            Else
                e.Graphics.DrawString(Format(totalmp / totalentries, "0.00"), smallfont, Brushes.Black, left_margin + column, line)
            End If
            column += 60
            If totalentries = 0 Or totalmp = 0 Then
                e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
            Else
                e.Graphics.DrawString(get_points(totalmp / totalentries), smallfont, Brushes.Black, left_margin + column, line)
            End If
            column += 70
            If totalentries = 0 Or totalmp = 0 Then
                e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
            Else
                e.Graphics.DrawString(mean_mark_total(), smallfont, Brushes.Black, left_margin + column, line)
            End If
            line += 15
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            e.Graphics.DrawLine(Pens.Black, left_margin, topline + smallfont.Height + 8, left_margin, line)
            col = 70
            For k As Integer = 0 To grades.Length - 1
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height + 8, left_margin + col - 4, line)
                col += 30
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height + 8, left_margin + col - 4, line)
            col += 50
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height + 8, left_margin + col - 4, line)
            col += 60
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height + 8, left_margin + col - 4, line)
            col += 70
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height + 8, left_margin + col - 4, line)
            e.Graphics.DrawLine(Pens.Black, right_margin, topline + smallfont.Height + 8, right_margin, line)
            line += 25
        Next
        e.Graphics.DrawString(Today.Date.Date & " " & Now.Hour & ":" & Now.Minute & ":" & Now.Second, smallfont, Brushes.Black, left_margin - 80, line)
    End Sub
    Dim largest_index
    Private Function no_of_grades_2(ByVal grade As String, ByVal stream As String, ByVal subj As String) As Integer
        subj = ret_subject_name(subj)
        Dim all_grades() As String
        no_of_grades_2 = 0
        Dim out_of As Double
        If Not mode Then
            qread("SELECT `" & subj & "`, Stream FROM `" & table & "` WHERE Stream='" & escape_string(stream) & "' AND Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "' AND Class='" & escape_string(cboClass.SelectedItem) & "'")
            Dim i As Integer = 0
            ReDim all_grades(dbreader.RecordsAffected - 1)
            While dbreader.Read
                If IsNumeric(dbreader(subj)) Then
                    out_of = SubjectOutOf(subj, tm, yr, exam_name, class_form, dbreader("Stream"), 2)
                    all_grades(i) = get_grade((dbreader(subj) / out_of) * 100, grading, subj)
                Else
                    all_grades(i) = dbreader(subj)
                End If
                i += 1
            End While
            For k As Integer = 0 To all_grades.Length - 1
                If all_grades(k) = grade Then
                    no_of_grades_2 += 1
                End If
            Next
            entries += no_of_grades_2
            mp += no_of_grades_2 * fix_point(grade)
            Return no_of_grades_2
        Else
            Dim largest_table As String = LargestTable(stream)
            Dim studs(large - 1)()
            For k As Integer = 0 To exam_names.Length - 1
                qread("SELECT ADMNo, `" & subj & "`, Stream FROM `" & table & "` WHERE Stream='" & escape_string(stream) & "' AND Examination='" & escape_string(exam_names(k)) & "'  AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "' AND Class='" & escape_string(cboClass.SelectedItem) & "' ORDER BY ADMNo ASC")
                If k = 0 Then
                    ReDim Preserve studs(dbreader.RecordsAffected - 1)(1)
                    For c As Integer = 0 To studs.Length - 1
                        ReDim Preserve studs(c)(1)
                        For c1 As Integer = 0 To studs(c).Length - 1
                            studs(c)(c1) = 0
                        Next
                    Next
                End If
                Dim i As Integer = 0
                While dbreader.Read
                    out_of = SubjectOutOf(subj, tms(k), yrs(k), exam_names(k), class_form, dbreader("Stream"), 2)
                    If k = 0 Then
                        Try
                            studs(i)(0) = dbreader("ADMNo")
                            studs(i)(1) += ((dbreader(subj) / out_of) * total_mark(k)) * contribution(k) / total_mark(k)
                            i += 1
                        Catch ex As Exception

                        End Try
                    Else
                        For count As Integer = 0 To studs.Length - 1
                            Try
                                If studs(count)(0) = dbreader("ADMNo") Then
                                    studs(count)(1) += ((dbreader(subj) / out_of) * total_mark(k)) * contribution(k) / total_mark(k)
                                    Exit For
                                End If
                            Catch ex As Exception

                            End Try

                        Next
                    End If
                End While
            Next
            For k As Integer = 0 To studs.Length - 1
                studs(k)(1) = get_grade(studs(k)(1), grading, subj)
            Next
            For k As Integer = 0 To studs.Length - 1
                Try
                    If studs(k)(1) = grade Then
                        no_of_grades_2 += 1
                    End If
                Catch ex As Exception

                End Try

            Next
            entries += no_of_grades_2
            mp += no_of_grades_2 * fix_point(grade)
            Return no_of_grades_2
        End If
        'here
    End Function
    Dim large As Integer = 0
    Private Function LargestTable(ByVal str As String) As String
        LargestTable = Nothing
        For k As Integer = 0 To exam_names.Length - 1
            qread("SELECT id FROM exam_results WHERE (class='" & escape_string(class_form) & "' and stream='" & escape_string(str) & "' AND Examination='" & escape_string(exam_names(k)) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "')")
            If dbreader.RecordsAffected > large Then
                large = dbreader.RecordsAffected
                largest_index = k
                LargestTable = exam_names(k)
            End If
        Next
        Return LargestTable
    End Function
    Dim sum As String
    Private Function mean_mark_total()
        mm = 0
        If chkBestOf7.Checked Then
            sum = "B7_Total"
        Else
            sum = "Total"
        End If
        qread("SELECT `" & sum & "` FROM `" & table & "` WHERE Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "' AND Class='" & escape_string(cboClass.SelectedItem) & "'")
        Dim cnt As Integer
        While dbreader.Read
            If IsNumeric(dbreader(sum)) Then
                mm += dbreader(sum)
                cnt += 1
            End If
        End While
        dbreader.Close()
        Return Format(mm / cnt, "0.00")
    End Function
    Private Function mean_mark(ByVal s As String)
        mm = 0
        If chkBestOf7.Checked Then
            sum = "B7_Total"
        Else
            sum = "Total"
        End If
        qread("SELECT `" & sum & "` FROM `" & table & "` WHERE Stream='" & s & "' AND Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "' AND Class='" & escape_string(cboClass.SelectedItem) & "'")
        Dim cnt As Integer
        While dbreader.Read
            If IsNumeric(dbreader(sum)) Then
                mm += dbreader(sum)
                cnt += 1
            End If
        End While
        dbreader.Close()
        Return Format(mm / cnt, "0.00")
    End Function
    Private Function no_of_grades(ByVal grade As String, ByVal stream As String) As Integer
        Dim all_grades() As String
        no_of_grades = 0
        If chkBestOf7.Checked Then
            If radSubject.Checked Then
                sum = "B7SB_TP"
            Else
                sum = "B7NSB_TP"
            End If
        Else
            If radSubject.Checked Then
                sum = "SB_TP"
            Else
                sum = "NSB_TP"
            End If
        End If
        qread("SELECT * FROM `" & table & "` WHERE Stream='" & stream & "' Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "' AND Class='" & escape_string(cboClass.SelectedItem) & "'")
        Dim i As Integer = 0
        Dim count As Integer
        ReDim all_grades(dbreader.RecordsAffected - 1)
        While dbreader.Read
            count = subjabb.Length
            If IsNumeric(dbreader(sum)) Then
                For k As Integer = 0 To subjabb.Length - 1
                    If dbreader(subjname(k)) = "-" Then
                        count -= 1
                    End If
                Next
                If chkBestOf7.Checked Then
                    all_grades(i) = get_points(dbreader(sum) / 7)
                Else
                    all_grades(i) = get_points(dbreader(sum) / count)
                End If
                i += 1
            End If
        End While
        For k As Integer = 0 To all_grades.Length - 1
            If all_grades(k) = grade Then
                no_of_grades += 1
            End If
        Next
        entries += no_of_grades
        mp += no_of_grades * fix_point(grade)
        Return no_of_grades
    End Function

    Private Sub fill_stream(ByVal str As String)
        qread("SELECT stream FROM class_stream WHERE class='" & escape_string(str) & "'")
        ReDim streams(dbreader.RecordsAffected - 1)
        Dim i As Integer = 0
        While dbreader.Read
            streams(i) = dbreader("stream")
            i += 1
        End While
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        get_details()
        create_report2()
    End Sub
    Private Sub create_report2()
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = prepare_class_list2()
        printpreview.Document = print_document
        print_document.Print()
    End Sub
    Private Function prepare_class_list2()
        Dim print_document As New PrintDocument
        Dim margin As New Margins(10, 10, 10, 10)
        print_document.DefaultPageSettings.Landscape = False
        print_document.DefaultPageSettings.Margins = margin
        AddHandler print_document.PrintPage, AddressOf print_class_list2
        Return print_document
    End Function
    Private Sub print_class_list2(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        'e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
        Dim line As Integer = 30
        Dim topline As Integer = line
        Dim left_margin As Integer = 20
        Dim right_margin As Integer = 810
        Dim col As Integer = 50
        exam_name = get_exam_name()
        Try
            e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, topline, 100, 100)
        Catch ex As Exception
            If Not confirm("You Have No School Logo To Print! Do You Want To Continue Printing?") Then
                Exit Sub
            End If
        End Try
        e.Graphics.DrawString(S_NAME.ToUpper, other_font, Brushes.Black, left_margin, line)
        line += other_font.Height + 5
        e.Graphics.DrawString("EXAMINATION DEPARTMENT", other_font, Brushes.Black, left_margin, line)
        line += other_font.Height + 5
        e.Graphics.DrawString("CLASS GENDER ANALYSIS", other_font, Brushes.Black, left_margin, line)
        line += other_font.Height + 5
        e.Graphics.DrawString(exam_name & " Term " & tm & " " & yr, other_font, Brushes.Black, left_margin, line)
        line += other_font.Height + 5
        classes()
        wait("Complex Computation ...")
        For c As Integer = 0 To words.Length - 1
            table = cboTerm.SelectedItem & "_" & cboYear.SelectedItem.ToString.Substring(2) & "_" & get_name(cboExamName.SelectedItem) & "_" & get_name(words(c))
            fill_stream(get_stream(words(c)))
            For s As Integer = 0 To streams.Length - 1
                wait("Computing " & words(c) & " " & streams(s) & "...")
                e.Graphics.DrawString(words(c).ToUpper & " " & streams(s), smallfont, Brushes.Black, left_margin, line)
                line += smallfont.Height + 2
                topline = line
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
                e.Graphics.DrawString("GENDER   ", smallfont, Brushes.Black, left_margin, line)
                col = 103
                For k As Integer = 0 To grades.Length - 1
                    e.Graphics.DrawString(grades(k), smallfont, Brushes.Black, left_margin + col + 4, line)
                    col += 35
                Next
                e.Graphics.DrawString("ENTRY", smallfont, Brushes.Black, left_margin + col, line)
                col += 50
                e.Graphics.DrawString("M.P.", smallfont, Brushes.Black, left_margin + col, line)
                col += 50
                e.Graphics.DrawString("M.G.", smallfont, Brushes.Black, left_margin + col, line)
                col += 50
                e.Graphics.DrawString("M.M.", smallfont, Brushes.Black, left_margin + col, line)
                line += smallfont.Height + 2
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
                col = 103
                For k As Integer = 0 To grades.Length - 1
                    e.Graphics.DrawString(gradeno(grades(k), "Male", streams(s)), smallfont, Brushes.Black, left_margin + col + 4, line)
                    col += 35
                Next
                e.Graphics.DrawString(g_entry, smallfont, Brushes.Black, left_margin + col, line)
                col += 50
                Dim mean As Double = mean_p("", "Male", streams(s))
                e.Graphics.DrawString(mean, smallfont, Brushes.Black, left_margin + col, line)
                col += 50
                e.Graphics.DrawString(get_points(mean), smallfont, Brushes.Black, left_margin + col, line)
                col += 50
                mean = meanmark("Male", streams(s))
                e.Graphics.DrawString(mean, smallfont, Brushes.Black, left_margin + col, line)
                g_mp = 0
                g_entry = 0
                mean = 0
                e.Graphics.DrawString("M", smallfont, Brushes.Black, left_margin + 10, line)
                line += smallfont.Height + 2
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
                col = 103
                For k As Integer = 0 To grades.Length - 1
                    e.Graphics.DrawString(gradeno(grades(k), "Female", streams(s)), smallfont, Brushes.Black, left_margin + col + 4, line)
                    col += 35
                Next
                e.Graphics.DrawString(g_entry, smallfont, Brushes.Black, left_margin + col, line)
                col += 50
                mean = mean_p("", "Female", streams(s))
                e.Graphics.DrawString(mean, smallfont, Brushes.Black, left_margin + col, line)
                col += 50
                e.Graphics.DrawString(get_points(mean), smallfont, Brushes.Black, left_margin + col, line)
                col += 50
                mean = meanmark("Female", streams(s))
                e.Graphics.DrawString(mean, smallfont, Brushes.Black, left_margin + col, line)
                g_mp = 0
                g_entry = 0
                mean = 0
                e.Graphics.DrawString("F", smallfont, Brushes.Black, left_margin + 10, line)
                line += smallfont.Height + 2
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
                e.Graphics.DrawLine(Pens.Black, left_margin, topline, left_margin, line)
                col = 103
                For k As Integer = 0 To grades.Length - 1
                    e.Graphics.DrawLine(Pens.Black, left_margin + col, topline, left_margin + col, line)
                    col += 35
                Next
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line)
                col += 50
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line)
                col += 50
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line)
                col += 50
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line)
                e.Graphics.DrawLine(Pens.Black, right_margin, topline, right_margin, line)
                line += 10
            Next
            line += 20
        Next
        e.Graphics.DrawString(Today.Date.Date & " " & Now.Hour & ":" & Now.Minute & ":" & Now.Second, smallfont, Brushes.Black, left_margin - 80, line)
    End Sub
    Private Function mean_p(ByVal grade As String, ByVal gender As String, ByVal s As String)
        Dim all_grades() As String
        Dim admnos() As String
        Dim cnt As Integer
        If chkBestOf7.Checked Then
            sum = "B7_Total"
        Else
            sum = "Total"
        End If
        qread("SELECT `" & sum & "`, `ADMNo` FROM `" & table & "` WHERE Stream='" & s & "' AND Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "' AND Class='" & escape_string(cboClass.SelectedItem) & "'")
        Dim i As Integer = 0
        ReDim all_grades(dbreader.RecordsAffected - 1), admnos(dbreader.RecordsAffected - 1)
        While dbreader.Read
            If IsNumeric(dbreader(sum)) Then
                admnos(i) = dbreader("ADMNo")
                all_grades(i) = get_grade(((dbreader(sum) / 11) / marks) * 100, False, ret_subject_name(subject))
                i += 1
            End If
        End While
        dbreader.Close()
        For k As Integer = 0 To admnos.Length - 1
            If isgender(admnos(k), gender) Then
                g_mp += fix_point(all_grades(k))
                cnt += 1
            End If
        Next
        If cnt = 0 Or g_mp = 0 Then
            Return "--"
        Else
            Return Format(g_mp / cnt, "0.00")
        End If
    End Function
    Private Function meanmark(ByVal gender As String, ByVal s As String)
        Dim admnos() As String
        Dim cnt As Integer
        If chkBestOf7.Checked Then
            sum = "B7_Total"
        Else
            sum = "Total"
        End If
        qread("SELECT `" & sum & "`, `ADMNo` FROM `" & table & "` WHERE Stream='" & s & "' AND Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "' AND Class='" & escape_string(cboClass.SelectedItem) & "'")
        Dim i As Integer = 0
        ReDim totals(dbreader.RecordsAffected - 1), admnos(dbreader.RecordsAffected - 1)
        While dbreader.Read
            If IsNumeric(dbreader(sum)) Then
                admnos(i) = dbreader("ADMNo")
                totals(i) = dbreader(sum)
                i += 1
            End If
        End While
        dbreader.Close()
        g_mp = 0
        For k As Integer = 0 To admnos.Length - 1
            If isgender(admnos(k), gender) Then
                g_mp += totals(k)
                cnt += 1
            End If
        Next
        If cnt > 0 And g_mp > 0 Then
            Return Format(g_mp / cnt, "0.00")
        Else
            Return "--"
        End If
    End Function
    Dim g_entry, g_mp, totals() As Integer

    Private Sub bestStud_Click(sender As Object, e As EventArgs) Handles bestStud.Click

        selectedExams.Clear()

        If radSubject.CheckState = CheckState.Checked Then
            MsgBox("Please use class based grading")
            Return
            ' gradingType = "SubjectBased"
        End If

        selectedClass = cboClass.SelectedItem
        selectedTerm = cboTerm.SelectedItem
        selectedYear = cboYear.SelectedItem

        If chkMode.Checked Then

            For Each value As ListViewItem In lstExaminations.Items
                selectedExams.Add(New Tuple(Of String, String, String, String)(value.Text, value.SubItems.Item(1).Text, value.SubItems.Item(2).Text, value.SubItems.Item(3).Text))
            Next

        Else
            selectedExams.Add(New Tuple(Of String, String, String, String)(cboExamName.SelectedItem, 100, selectedTerm, selectedYear))
        End If

        If selectedExams.Count = 0 Then
            MsgBox("The exam or term or year has not been selected")
        End If

        Dim prompt2 As New frmSubjectRankPrompt2
        prompt2.ShowDialog()

    End Sub

    Private Function gradeno(ByVal grade As String, ByVal gender As String, ByVal s As String)
        Dim all_grades() As String
        Dim admnos() As String
        gradeno = 0
        If chkBestOf7.Checked Then
            If radSubject.Checked Then
                sum = "B7SB_TP"
            Else
                sum = "B7NSB_TP"
            End If
        Else
            If radSubject.Checked Then
                sum = "SB_TP"
            Else
                sum = "NSB_TP"
            End If
        End If
        qread("SELECT * FROM `" & table & "` WHERE Stream='" & escape_string(s) & "' AND Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "' AND Class='" & escape_string(cboClass.SelectedItem) & "'")
        Dim i As Integer = 0
        Dim count As Integer = 0
        ReDim all_grades(dbreader.RecordsAffected - 1), admnos(dbreader.RecordsAffected - 1)
        While dbreader.Read
            count = 0
            For k As Integer = 0 To subjabb.Length - 1
                If IsNumeric(dbreader(subjname(k))) Then
                    count += 1
                End If
            Next
            If IsNumeric(dbreader(sum)) Then
                admnos(i) = dbreader("ADMNo")
                If chkBestOf7.Checked Then
                    all_grades(i) = get_points(dbreader(sum) / 7)
                Else
                    all_grades(i) = get_points(dbreader(sum) / count)
                End If
                i += 1
            End If
        End While
        dbreader.Close()
        For k As Integer = 0 To admnos.Length - 1
            If isgender(admnos(k), gender) Then
                If all_grades(k) = grade Then
                    gradeno += 1
                    g_entry += 1
                End If
            End If
        Next
        Return gradeno
    End Function

    Private Function isgender(ByVal adm As String, ByVal gender As String)
        qread("SELECT * FROM students WHERE admin_no='" & adm & "' AND Gender='" & gender & "'")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Close()
            Return True
        Else
            dbreader.Close()
            Return False
        End If
    End Function

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        grading = radSubject.Checked
        If Not chkMode.Checked Then
            tm = cboTerm.SelectedItem
            yr = cboYear.SelectedItem
        End If
        class_form = cboClass.SelectedItem
        exam_name = cboExamName.SelectedItem
        get_details()
        create_report3()
    End Sub
    Private Sub create_report3()
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = prepare_class_list3()
        printpreview.Document = print_document
        printpreview.ShowDialog()
        print_document.Print()
    End Sub
    Private Function prepare_class_list3()
        Dim print_document As New PrintDocument
        Dim margin As New Margins(10, 10, 10, 10)
        print_document.DefaultPageSettings.Landscape = False
        print_document.DefaultPageSettings.Margins = margin
        AddHandler print_document.PrintPage, AddressOf print_class_list3
        Return print_document
    End Function
    Dim start_from As Integer = 0
    Private Sub print_class_list3(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        'e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
        Dim line As Integer = 20
        Dim topline As Integer = line
        Dim left_margin As Integer = 50
        Dim right_margin As Integer = 800
        Dim col As Integer = 50
        exam_name = get_exam_name()
        If File.Exists(path & "\student_images\" & logo()) Then
            e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin, topline, 100, 100)
        End If
        Dim CenterPage As Single
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
        If S_EMAIL <> "" Then
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("EMAIL ADDRESS: " & S_EMAIL, other_font).Width / 2)
            e.Graphics.DrawString("EMAIL ADDRESS: " & S_EMAIL, other_font, Brushes.Black, CenterPage, line)
            line += other_font.Height + 5
        End If
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("DEPARTMENTAL SUBJECT ANALYSIS", other_font).Width / 2)
        e.Graphics.DrawString("DEPARTMENTAL SUBJECT ANALYSIS", other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height + 3
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(cboClass.SelectedItem.ToString.ToUpper & " " & exam_name.ToUpper & " TERM " & tm & "  " & yr, other_font).Width / 2)
        e.Graphics.DrawString(cboClass.SelectedItem.ToString.ToUpper & " " & exam_name.ToUpper & "  TERM " & tm & "  " & yr, other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height + 3
        line += 15
        classes()
        For p As Integer = start_from To subjabb.Length - 1
            If (line + 80) >= 1000 And start_from = 0 Then
                e.HasMorePages = True
                start_from = p
                Exit Sub
            End If
            e.Graphics.DrawString(subjects(p) & " DEPARTMENT ", smallfont, Brushes.Black, left_margin, line)
            line += 14
            ReDim total(grades.Length - 1)
            totalmp = 0
            mp = 0
            Dim cnt As Integer
            totalentries = 0
            entries = 0
            e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line)
            e.Graphics.DrawString(cboClass.SelectedItem.ToString.ToUpper, smallfont, Brushes.Black, left_margin + 20, line)
            topline = line - 10
            left_margin = 50
            col = 100
            For k As Integer = 0 To grades.Length - 1
                e.Graphics.DrawString(grades(k), smallfont, Brushes.Black, left_margin + col, line)
                col += 35
            Next
            e.Graphics.DrawString("ENTRY", smallfont, Brushes.Black, left_margin + col, line)
            col += 50
            e.Graphics.DrawString("M.P.", smallfont, Brushes.Black, left_margin + col, line)
            col += 60
            e.Graphics.DrawString("M. GRADE", smallfont, Brushes.Black, left_margin + col, line)
            line += 13
            e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line)
            fill_stream(cboClass.SelectedItem)
            Dim column As Integer = 103
            For s As Integer = 0 To streams.Length - 1
                wait("Computing " & cboClass.SelectedItem & " " & streams(s) & "...")
                totalentries += entries
                entries = 0
                column = 103
                totalmp += mp
                mp = 0
                e.Graphics.DrawString(streams(s), smallfont, Brushes.Black, left_margin + 20, line)
                For k As Integer = 0 To grades.Length - 1
                    cnt = no_of_grades_2(grades(k), streams(s), subjects(p))
                    total(k) += cnt
                    e.Graphics.DrawString(cnt, smallfont, Brushes.Black, left_margin + column, line)
                    column += 35
                Next
                e.Graphics.DrawString(entries, smallfont, Brushes.Black, left_margin + column, line)
                column += 50
                If mp = 0 Or entries = 0 Then
                    e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
                Else
                    e.Graphics.DrawString(Format(mp / entries, "0.00"), smallfont, Brushes.Black, left_margin + column, line)
                End If
                column += 60
                If mp = 0 Or entries = 0 Then
                    e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
                Else
                    e.Graphics.DrawString(get_points(mp / entries), smallfont, Brushes.Black, left_margin + column, line)
                End If
                line += 13
                e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line)
                If s = streams.Length - 1 Then
                    totalmp += mp
                    totalentries += entries
                End If
            Next
            e.Graphics.DrawString("TOTAL", smallfont, Brushes.Black, left_margin + 20, line)
            column = 103
            For k As Integer = 0 To grades.Length - 1
                e.Graphics.DrawString(total(k), smallfont, Brushes.Black, left_margin + column, line)
                column += 35
            Next
            e.Graphics.DrawString(totalentries, smallfont, Brushes.Black, left_margin + column, line)
            column += 50
            If totalentries = 0 Or totalmp = 0 Then
                e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
            Else
                e.Graphics.DrawString(Format(totalmp / totalentries, "0.00"), smallfont, Brushes.Black, left_margin + column, line)
            End If
            column += 60
            If totalentries = 0 Or totalmp = 0 Then
                e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
            Else
                e.Graphics.DrawString(get_points(totalmp / totalentries), smallfont, Brushes.Black, left_margin + column, line)
            End If
            line += 13
            e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 20, topline + smallfont.Height, left_margin + 20, line)
            col = 100
            For k As Integer = 0 To grades.Length - 1
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height, left_margin + col - 4, line)
                col += 35
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height, left_margin + col - 4, line)
            col += 50
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height, left_margin + col - 4, line)
            col += 60
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height, left_margin + col - 4, line)
            e.Graphics.DrawLine(Pens.Black, right_margin, topline + smallfont.Height, right_margin, line)
        Next
        e.Graphics.DrawString(Today.Date.Date & " " & Now.Hour & ":" & Now.Minute & ":" & Now.Second, smallfont, Brushes.Black, left_margin + 100, line)
        start_from = 0
    End Sub
End Class