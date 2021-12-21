Imports System.Drawing.Printing
Public Class frmStudentSubjectRank
    Dim admnos() As String
    Private Sub frmStudentSubjectRank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() And dbNewOpen() Then
            Me.Close()
        Else
            load_it()
        End If
    End Sub
    Private Function ReturnStudentIndex(ByVal adm As String) As Integer
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            If dgvSubjects.Item("ADMNo", k).Value.ToString = adm Then
                Return k
            End If
        Next
    End Function
    Private Sub load_it()
        Dim frm As New frmSubjectRank
        frm.ShowDialog()
        Dim out_of As Double
        If Not rank Then
            Me.Close()
        Else
            lblTitle.Text = "Student Subject Ranking Analysis for " & get_subject_name(subject)
            If mode Then
                Dim i As Integer
                Dim exist As Boolean = False
                For k As Integer = 0 To exam_names.Length - 1
                    If qread("SELECT ADMNo, StudentName, Stream,`" & subject & "` FROM `" & table & "` WHERE (Examination='" & escape_string(exam_names(k)) & "' AND class='" & escape_string(ret_name(class_form)) & "'  AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "' AND ADMNo IN (SELECT ADMNo FROM subjects_done WHERE `" & subject & "`='Yes')) ORDER BY `" & subject & "` DESC") Then
                        i = 0
                        While dbreader.Read
                            If dgvSubjects.Rows.Count < dbreader.RecordsAffected Then
                                dgvSubjects.Rows.Add()
                                dgvSubjects.Item("ADMNo", dgvSubjects.Rows.Count - 1).Value = dbreader("ADMNo")
                                dgvSubjects.Item("StudentName", dgvSubjects.Rows.Count - 1).Value = dbreader("StudentName")
                            Else
                                exist = True
                                i = ReturnStudentIndex(dbreader("ADMNo"))
                            End If
                            If IsNumeric(dbreader(subject)) Then
                                out_of = SubjectOutOf(subject, tms(k), yrs(k), exam_names(k), class_form, dbreader("Stream"), 2)
                                If IsNumeric(dgvSubjects.Item("MarkAttained", i).Value) Then
                                    dgvSubjects.Item("MarkAttained", i).Value = dgvSubjects.Item("MarkAttained", i).Value + ((dbreader(subject) / out_of) * total_mark(k)) * (contribution(k) / total_mark(k))
                                Else
                                    dgvSubjects.Item("MarkAttained", i).Value = ((dbreader(subject) / out_of) * total_mark(k)) * (contribution(k) / total_mark(k)) 'todo added the brackets coz of BODMAS
                                End If
                            End If
                            i += 1
                        End While
                    End If
                Next
                For i = 0 To dgvSubjects.Rows.Count - 1
                    ' dgvSubjects.Item("MarkAttained", i).Value = Math.Round(dgvSubjects.Item("MarkAttained", i).Value, 0)
                Next
                For i = 0 To dgvSubjects.Rows.Count - 1
                    If IsNumeric(dgvSubjects.Item("MarkAttained", i).Value) Then
                        dgvSubjects.Item("GradeAttained", i).Value = get_grade(dgvSubjects.Item("MarkAttained", i).Value, mod_subject, subject)
                    Else
                        dgvSubjects.Item("GradeAttained", i).Value = "-"
                    End If
                Next
            Else
                If qread("SELECT ADMNo, StudentName, Stream,`" & subject & "` FROM `" & table & "` WHERE Examination='" & escape_string(exam_name) & "' AND class='" & escape_string(ret_name(class_form)) & "'  AND Term='" & tm & "' AND Year='" & yr & "' ORDER BY `" & subject & "` DESC") Then
                    Dim i As Integer = 0
                    While dbreader.Read
                        out_of = SubjectOutOf(subject, tm, yr, exam_name, class_form, dbreader("Stream"), 2)
                        If IsNumeric(dbreader(subject)) Then
                            dgvSubjects.Rows.Add()
                            dgvSubjects.Item("ADMNo", i).Value = get_id(dbreader("ADMNo"))
                            dgvSubjects.Item("StudentName", i).Value = dbreader("StudentName")
                            If IsNumeric(dbreader(subject)) Then
                                dgvSubjects.Item("MarkAttained", i).Value = Math.Round((dbreader(subject) / out_of) * marks, 0)
                            Else
                                dgvSubjects.Item("MarkAttained", i).Value = dbreader(subject)
                            End If
                            i += 1
                        End If
                    End While
                    For i = 0 To dgvSubjects.Rows.Count - 1
                        If IsNumeric(dgvSubjects.Item("MarkAttained", i).Value) Then
                            'todo original code below
                            '  dgvSubjects.Item("GradeAttained", i).Value = get_grade((dgvSubjects.Item("MarkAttained", i).Value / out_of) * 100, mod_subject, subject)
                            dgvSubjects.Item("GradeAttained", i).Value = get_grade(dgvSubjects.Item("MarkAttained", i).Value, mod_subject, subject)
                        Else
                            dgvSubjects.Item("GradeAttained", i).Value = dgvSubjects.Item("MarkAttained", i).Value
                        End If
                    Next
                End If
            End If
        End If
        dgvSubjects.Sort(dgvSubjects.Columns("MarkAttained"), System.ComponentModel.ListSortDirection.Descending)
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            dgvSubjects.Item("MarkAttained", k).Value = Format(dgvSubjects.Item("MarkAttained", k).Value, "0.00")
            dgvSubjects.Item("Points", k).Value = fix_point(dgvSubjects.Item("GradeAttained", k).Value)
        Next
        'If qread("SELECT ADMNo, StudentName, `" & subject & "` FROM `" & table & "` WHERE ((Examination='" & escape_string(exam_name) & "' AND class='" & escape_string(ret_name(class_form)) & "' AND Term='" & tm & "' AND Year='" & yr & "') AND (`" & subject & "`='X' OR `" & subject & "`='Y' OR `" & subject & "`='-')) ORDER BY `" & subject & "` DESC") Then
        '    While dbReader.Read
        '        dgvSubjects.Rows.Add()
        '        dgvSubjects.Item("ADMNo", dgvSubjects.Rows.Count - 1).Value = get_id(dbReader("ADMNo"))
        '        dgvSubjects.Item("StudentName", dgvSubjects.Rows.Count - 1).Value = dbReader("StudentName")
        '        dgvSubjects.Item("MarkAttained", dgvSubjects.Rows.Count - 1).Value = dbReader(subject)
        '    End While
        'End If
        load_genders()
        'For k As Integer = 0 To dgvSubjects.Rows.Count - 1
        '    If Not IsNumeric(dgvSubjects.Item("MarkAttained", k).Value) Then
        '        dgvSubjects.Item("GradeAttained", k).Value = dgvSubjects.Item("MarkAttained", k).Value
        '    End If
        'Next
        trim_records()
    End Sub
    Private Sub trim_records()
        If radF Then
            For k As Integer = dgvSubjects.Rows.Count - 1 To rankno Step -1
                dgvSubjects.Rows.RemoveAt(k)
            Next
        ElseIf radL Then
            Dim to_delete As Integer = dgvSubjects.Rows.Count - rankno
            While to_delete > 0
                dgvSubjects.Rows.RemoveAt(0)
                to_delete -= 1
            End While
        End If
    End Sub
    Private Sub load_genders()
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            qread("SELECT Gender FROM students WHERE admin_no='" & dgvSubjects.Item("ADMNo", k).Value & "'")
            dbreader.Read()
            Try
                dgvSubjects.Item("Gender", k).Value = dbreader("Gender")
            Catch ex As Exception

            End Try
            dbreader.Close()
        Next
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Function print_student_report()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report
        Return print_document
    End Function
    Dim start_from As Integer = 0
    Dim total_points As Double
    Dim total As Double
    Dim count As Integer = 0
    Dim prev_pos As Integer = 0
    Private Sub print_report(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.HasMorePages = False
        Dim avg As Integer = 380
        Dim remarks As Integer = 450
        Dim teacher As Integer = 520
        Dim exam_width As Integer
        Try
            exam_width = (380 - 150) / (tables.Length)
        Catch ex As Exception
            exam_width = 380
        End Try
        Dim line As Integer = 20
        Dim left_margin As Integer = 125
        Dim right_margin As Integer = 800
        Dim topline As Integer
        Dim CenterPage As Single
        If S_NAME <> String.Empty Then
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(S_NAME.ToUpper, header_font).Width / 2)
            e.Graphics.DrawString(S_NAME.ToUpper, header_font, Brushes.Black, CenterPage, line)
            line += header_font.Height + 2
        End If
        If S_ADDRESS <> String.Empty Then
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("P.O. BOX " & S_ADDRESS.ToUpper & ", " & S_LOCATION.ToUpper, other_font).Width / 2)
            e.Graphics.DrawString("P.O. BOX " & S_ADDRESS.ToUpper & ", " & S_LOCATION.ToUpper, other_font, Brushes.Black, CenterPage, line)
            line += other_font.Height + 5
        End If
        If S_PHONE <> String.Empty Then
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("TELEPHONE: " & S_PHONE, other_font).Width / 2)
            e.Graphics.DrawString("TELEPHONE: " & S_PHONE, other_font, Brushes.Black, CenterPage, line)
            line += other_font.Height + 5
        End If
        If S_EMAIL <> String.Empty Then
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("EMAIL ADDRESS: " & S_EMAIL, other_font).Width / 2)
            e.Graphics.DrawString("EMAIL ADDRESS: " & S_EMAIL, other_font, Brushes.Black, CenterPage, line)
            line += other_font.Height + 5
        End If
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(exam_name.ToString.ToUpper & " Term ".ToString.ToUpper & tm.ToString.ToUpper & " " & yr.ToString.ToUpper, other_font).Width / 2)
        e.Graphics.DrawString(exam_name.ToString.ToUpper & " Term ".ToString.ToUpper & tm.ToString.ToUpper & " " & yr.ToString.ToUpper, other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height + 5
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("STUDENT SUBJECT RANKING REPORT FOR " & get_subject_name(subject).ToUpper, other_font).Width / 2)
        e.Graphics.DrawString("STUDENT SUBJECT RANKING REPORT FOR " & get_subject_name(subject).ToUpper, other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height
        topline = line
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, left_margin + 600, line)
        e.Graphics.DrawString("POS.", other_font, Brushes.Black, left_margin + 5, line + 3)
        e.Graphics.DrawString("ADM.", other_font, Brushes.Black, left_margin + 50, line + 3)
        e.Graphics.DrawString("NAME OF STUDENT", other_font, Brushes.Black, left_margin + 100, line + 3)
        e.Graphics.DrawString("MARK", other_font, Brushes.Black, left_margin + 350, line + 3)
        e.Graphics.DrawString("GRADE", other_font, Brushes.Black, left_margin + 420, line + 3)
        e.Graphics.DrawString("POINTS", other_font, Brushes.Black, left_margin + 500, line + 3)
        line += 20
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, left_margin + 600, line)
        Dim in_tie As Boolean = False
        For k As Integer = start_from To dgvSubjects.Rows.Count - 1
            If dgvSubjects.Item("MarkAttained", k).Value <> String.Empty And dgvSubjects.Item("MarkAttained", k).Value <> "-" Then
                count += 1
                total += dgvSubjects.Item("MarkAttained", k).Value
                total_points += dgvSubjects.Item("Points", k).Value
            End If
            e.Graphics.DrawString(dgvSubjects.Item("ADMNo", k).Value, smallfont, Brushes.Black, left_margin + 50, line + 3)
            e.Graphics.DrawString(dgvSubjects.Item("StudentName", k).Value, smallfont, Brushes.Black, left_margin + 100, line + 3)
            e.Graphics.DrawString(dgvSubjects.Item("MarkAttained", k).Value, smallfont, Brushes.Black, left_margin + 350, line + 3)
            e.Graphics.DrawString(dgvSubjects.Item("GradeAttained", k).Value, smallfont, Brushes.Black, left_margin + 420, line + 3)
            e.Graphics.DrawString(dgvSubjects.Item("Points", k).Value, smallfont, Brushes.Black, left_margin + 500, line + 3)
            If k > 0 Then
                If IsNumeric(dgvSubjects.Item("MarkAttained", k).Value) Then
                    If dgvSubjects.Item("MarkAttained", k).Value = dgvSubjects.Item("MarkAttained", k - 1).Value Then
                        If Not in_tie Then
                            in_tie = True
                            prev_pos = k
                        End If
                        e.Graphics.DrawString(prev_pos, smallfont, Brushes.Black, left_margin + 10, line + 3)
                    Else
                        in_tie = False
                        e.Graphics.DrawString(k + 1, smallfont, Brushes.Black, left_margin + 10, line + 3)
                    End If
                End If
            Else
                e.Graphics.DrawString(k + 1, smallfont, Brushes.Black, left_margin + 10, line + 3)
            End If
            line += other_font.Height
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, left_margin + 600, line)
            If line >= 1061 And k < dgvSubjects.Rows.Count - 1 Then
                start_from = k + 1
                e.HasMorePages = True
                Exit For
            End If
        Next
        e.Graphics.DrawString(String.Empty, smallfont, Brushes.Black, left_margin + 50, line + 3)
        e.Graphics.DrawString("MEAN SCORE", smallfont, Brushes.Black, left_margin + 100, line + 3)
        e.Graphics.DrawString(Format(total / count, "0.00"), smallfont, Brushes.Black, left_margin + 350, line + 3)
        e.Graphics.DrawString(get_points(total_points / count), smallfont, Brushes.Black, left_margin + 420, line + 3)
        e.Graphics.DrawString(Format(total_points / count, "0.00"), smallfont, Brushes.Black, left_margin + 500, line + 3)
        line += other_font.Height
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, left_margin + 600, line)
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + 45, topline, left_margin + 45, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + 90, topline, left_margin + 90, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + 340, topline, left_margin + 340, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + 410, topline, left_margin + 410, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + 490, topline, left_margin + 490, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + 600, topline, left_margin + 600, line)
        If e.HasMorePages = False Then
            start_from = 0
        End If
    End Sub
    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report()
        print_document.DefaultPageSettings.Landscape = False
        Print_Preview.Document = print_document
        Print_Preview.ShowDialog()
        'qwrite("DROP TABLE results")
        'query = "CREATE TABLE results(id int not null auto_increment , "
        'For k As Integer = 0 To dgvSubjects.Columns.Count - 1
        '    query &= dgvSubjects.Columns(k).Name & " VARCHAR (100) NULL"
        '    If k < dgvSubjects.Columns.Count - 1 Then
        '        query &= ", "
        '    End If
        'Next
        'query &= ", primary key(id))"
        'If Not qwrite(query) Then
        '    qwrite("DROP TABLE results")
        '    qwrite(query)
        'End If
        'query = "INSERT INTO results VALUES"
        'For k As Integer = 0 To dgvSubjects.Rows.Count - 1
        '    query += "(NULL, "
        '    For i As Integer = 0 To dgvSubjects.Columns.Count - 1
        '        query += "'" & escape_string(dgvSubjects.Item(dgvSubjects.Columns(i).Name, k).Value) & "'"
        '        If i < dgvSubjects.Columns.Count - 1 Then
        '            query += ","
        '        Else
        '            query += ")"
        '        End If
        '    Next
        '    If k < dgvSubjects.Rows.Count - 1 Then
        '        query += ","
        '    End If
        'Next
        'Dim new_class_form As String = ret_name(class_form).ToString.ToUpper
        'Dim title As String
        'If radF Then
        '    title = new_class_form & "TOP " & rankno & " STUDENTS IN " & subject.ToUpper
        'ElseIf radL Then
        '    title = new_class_form & "BOTTOM " & rankno & " STUDENTS IN " & subject.ToUpper
        'Else
        '    title = new_class_form & "STUDENTS RANK IN " & get_subject_name(subject).ToString.ToUpper
        'End If
        'qwrite("UPDATE result_details SET class='" & new_class_form & "', code='" & exam_name & "', term='" & tm & "', year='" & Today.Year & "', title='" & title & "'")
        'If qwrite(query) Then
        '    Dim frm As New frmReportRank
        '    frm.ShowDialog()
        'End If
    End Sub
End Class