Imports System.Drawing.Printing
Public Class frmMeanAnalysis

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmMeanAnalysis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() And dbNewOpen() Then
            Me.Close()
        Else
            lblTitle.Text = "Subject Performance Analysis - Mean Analysis".ToUpper
            Dim out_of As Double
            If mode Then
                Dim total(subjabb.Length - 1), count(subjabb.Length - 1) As Double
                For j As Integer = 0 To exam_names.Length - 1
                    For k As Integer = 0 To subjabb.Length - 1
                        total(k) = 0
                        count(k) = 0
                    Next
                    For k As Integer = 0 To subjabb.Length - 1
                        If qread("SELECT `" & subjabb(k) & "`, Stream FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(exam_names(j)) & "'  AND Term='" & tms(j) & "' AND Year='" & yrs(j) & "')") Then
                            While dbreader.Read
                                If IsNumeric(dbreader(subjabb(k))) Then
                                    out_of = SubjectOutOf(subjname(k), tms(j), yrs(j), exam_names(j), class_form, dbreader("Stream"), 2)
                                    total(k) += ((dbreader(subjabb(k)) / out_of) * total_mark(j)) * contribution(j) / 100
                                    count(k) += 1
                                End If
                            End While
                        End If
                    Next
                    For k As Integer = 0 To subjabb.Length - 1
                        If dgvSubjects.Rows.Count < subjabb.Length Then
                            dgvSubjects.Rows.Add()
                        End If
                        dgvSubjects.Item("SubjID", k).Value = subjids(k)
                        dgvSubjects.Item("Abbreviation", k).Value = subjabb(k)
                        dgvSubjects.Item("SubjectName", k).Value = subjects(k)
                        If IsNumeric(dgvSubjects.Item("MeanMark", k).Value) Then
                            dgvSubjects.Item("MeanMark", k).Value = Format(dgvSubjects.Item("MeanMark", k).Value + (total(k) / count(k)), "0.00")
                        Else
                            dgvSubjects.Item("MeanMark", k).Value = Format(total(k) / count(k), "0.00")
                        End If
                    Next
                Next
            Else
                Dim total, count As Integer
                For k As Integer = 0 To subjabb.Length - 1
                    If qread("SELECT `" & subjabb(k) & "`, Stream FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND  Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "')") Then
                        total = 0
                        count = 0
                        While dbreader.Read
                            If IsNumeric(dbreader(subjabb(k))) Then
                                out_of = SubjectOutOf(subjname(k), tm, yr, exam_name, class_form, dbreader("Stream"), 2)
                                total += (dbreader(subjabb(k)) / out_of) * marks
                                count += 1
                            End If
                        End While
                        dbreader.Close()
                        dgvSubjects.Rows.Add()
                        dgvSubjects.Item("SubjID", k).Value = subjids(k)
                        dgvSubjects.Item("Abbreviation", k).Value = subjabb(k)
                        dgvSubjects.Item("SubjectName", k).Value = subjects(k)
                        If count > 0 Then
                            dgvSubjects.Item("MeanMark", k).Value = Format(((total / count) / marks) * 100, "0.00")
                        Else
                            dgvSubjects.Item("MeanMark", k).Value = "--"
                        End If
                    End If
                Next
            End If
            For k As Integer = 0 To dgvSubjects.Rows.Count - 1
                points(k)
                dgvSubjects.Item("MeanGrade", k).Value = get_points(dgvSubjects.Item("MeanPoints", k).Value)
                dgvSubjects.Item("MeanPoints", k).Value = Convert.ToDecimal(dgvSubjects.Item("MeanPoints", k).Value)
            Next
            dgvSubjects.Sort(dgvSubjects.Columns("MeanPoints"), System.ComponentModel.ListSortDirection.Descending)
            For k As Integer = 0 To dgvSubjects.Rows.Count - 1
                If dgvSubjects.Item("MeanPoints", k).Value = 0 Then
                    dgvSubjects.Item("MeanPoints", k).Value = "--"
                    dgvSubjects.Item("MeanGrade", k).Value = "--"
                End If
            Next
        End If
    End Sub

    Private Sub points(ByVal k)
        Dim tp, cnt, marks(0) As Integer
        Dim out_of As Double
        For m As Integer = 0 To subjabb.Length - 1
            tp = 0
            cnt = 0
            If dgvSubjects.Item("Abbreviation", k).Value = subjabb(m) Then
                If mode Then
                    For t As Integer = 0 To exam_names.Length - 1
                        qread("SELECT `" & subjname(m) & "`, Stream FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(exam_names(t)) & "' AND Term='" & tms(t) & "' AND Year='" & yrs(t) & "')")
                        ReDim Preserve marks(dbreader.RecordsAffected - 1)
                        Dim i As Integer = 0
                        While dbreader.Read
                            If IsNumeric(dbreader(subjname(m))) Then
                                out_of = SubjectOutOf(subjname(m), tms(t), yrs(t), exam_names(t), class_form, dbreader("Stream"), 2)
                                marks(i) += (dbreader(subjname(m)) / out_of) * total_mark(t) * contribution(t) / 100
                            End If
                            i += 1
                        End While
                    Next
                    For l As Integer = 0 To marks.Length - 1
                        cnt += 1
                        tp += fix_point(get_grade(marks(l), grading, subjabb(m)))
                    Next
                Else
                    Dim mark As Integer = get_total_mark(exam_name, tm)
                    qread("SELECT `" & subjname(m) & "`, Stream FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "')")
                    While dbreader.Read
                        If IsNumeric(dbreader(subjname(m))) Then
                            out_of = SubjectOutOf(subjname(m), tm, yr, exam_name, class_form, dbreader("Stream"), 2)
                            cnt += 1
                            tp += fix_point(get_grade(((dbreader(subjname(m)) / out_of) * 100), grading, subjabb(m)))
                        End If
                    End While
                    dbreader.Close()
                End If
                If cnt > 0 Then
                    dgvSubjects.Item("MeanPoints", k).Value = Format(tp / cnt, "0.00")
                Else
                    dgvSubjects.Item("MeanPoints", k).Value = "0.00"
                End If
            End If
        Next
    End Sub
    Private Function print_student_report()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report
        Return print_document
    End Function

    Private Function subjectsPerGroup(ByVal group As String) As String()
        Dim i As Integer = 0
        Dim subjs() As String
        qread("SELECT subject FROM subjects WHERE department='" & escape_string(group) & "'")
        ReDim subjs(dbreader.RecordsAffected - 1)
        While dbreader.Read
            subjs(i) = dbreader("subject")
            i += 1
        End While
        Return subjs
    End Function
    Private Function loadDepartments() As String()
        Dim depts() As String
        Dim i As Integer = 0
        qread("SELECT department FROM departments ORDER BY id")
        ReDim depts(dbreader.RecordsAffected - 1)
        While dbreader.Read
            depts(i) = dbreader("department")
            i += 1
        End While
        Return depts
    End Function

    Private Sub print_report(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        'e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
        Dim line As Integer
        Dim left_margin As Integer = 50
        Dim right_margin As Integer = 780
        Dim topline As Integer
        Dim CenterPage As Single
        line += 20
        Try
            e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, line, 100, 100)
            line += 15
        Catch ex As Exception
        End Try
        line = 50
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
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("EXAMINATION DEPARTMENT", other_font).Width / 2)
        e.Graphics.DrawString("EXAMINATION DEPARTMENT", other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(exam_name.ToUpper & "     Term " & tm & "     " & yr, other_font).Width / 2)
        e.Graphics.DrawString(exam_name.ToUpper & "     Term " & tm & "     " & yr, other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(class_form.ToString.ToUpper & " SUBJECT MEAN ANALYSIS REPORT", other_font).Width / 2)
        e.Graphics.DrawString(class_form.ToString.ToUpper & " SUBJECT MEAN ANALYSIS REPORT", other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height
        line += 15

        e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)

        line += 10
        topline = line
        If rpt = "List" Then
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            e.Graphics.DrawString("SUBJECT", other_font, Brushes.Black, left_margin + 10, line + 3)
            e.Graphics.DrawString("MEAN MARK", other_font, Brushes.Black, left_margin + 300, line + 3)
            e.Graphics.DrawString("MEAN GRADE", other_font, Brushes.Black, left_margin + 420, line + 3)
            e.Graphics.DrawString("MEAN POINTS", other_font, Brushes.Black, left_margin + 562, line + 3)
            line += 22
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            For k As Integer = 0 To dgvSubjects.Rows.Count - 1
                e.Graphics.DrawString(dgvSubjects.Item("SubjectName", k).Value, other_font, Brushes.Black, left_margin + 10, line + 3)
                e.Graphics.DrawString(dgvSubjects.Item("MeanMark", k).Value, other_font, Brushes.Black, left_margin + 300, line + 3)
                e.Graphics.DrawString(dgvSubjects.Item("MeanGrade", k).Value, other_font, Brushes.Black, left_margin + 430, line + 3)
                e.Graphics.DrawString(dgvSubjects.Item("MeanPoints", k).Value, other_font, Brushes.Black, left_margin + 575, line + 3)
                line += 22
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 290, topline, left_margin + 290, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 410, topline, left_margin + 410, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 560, topline, left_margin + 560, line)
            e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline, right_margin - 2, line)
        Else
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            e.Graphics.DrawString("SUBJECT GRP", other_font, Brushes.Black, left_margin + 10, line + 3)
            e.Graphics.DrawString("SUBJECT", other_font, Brushes.Black, left_margin + 120, line + 3)
            e.Graphics.DrawString("MEAN MARK", other_font, Brushes.Black, left_margin + 390, line + 3)
            e.Graphics.DrawString("MEAN GRADE", other_font, Brushes.Black, left_margin + 505, line + 3)
            e.Graphics.DrawString("MEAN POINTS", other_font, Brushes.Black, left_margin + 625, line + 3)
            line += other_font.Height + 3
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            Dim depts() As String = loadDepartments()
            For k As Integer = 0 To depts.Length - 1
                Dim tp, tm, cnt As Double
                tp = 0
                tm = 0
                cnt = 0
                e.Graphics.DrawString(depts(k), other_font, Brushes.Black, left_margin + 10, line + 3)
                Dim subjs() = subjectsPerGroup(depts(k))
                For count = 0 To subjs.Length - 1
                    For row = 0 To dgvSubjects.Rows.Count - 1
                        If dgvSubjects.Item("SubjectName", row).Value = subjs(count) Then
                            e.Graphics.DrawString(subjs(count), other_font, Brushes.Black, left_margin + 120, line + 3)
                            e.Graphics.DrawString(dgvSubjects.Item("MeanMark", row).Value, other_font, Brushes.Black, left_margin + 405, line + 3)
                            e.Graphics.DrawString(dgvSubjects.Item("MeanGrade", row).Value, other_font, Brushes.Black, left_margin + 510, line + 3)
                            e.Graphics.DrawString(dgvSubjects.Item("MeanPoints", row).Value, other_font, Brushes.Black, left_margin + 645, line + 3)
                            line += other_font.Height + 3
                            If IsNumeric(dgvSubjects.Item("MeanPoints", row).Value) Then
                                tp += dgvSubjects.Item("MeanPoints", row).Value
                                tm += dgvSubjects.Item("MeanMark", row).Value
                                cnt += 1
                            End If
                            e.Graphics.DrawLine(Pens.Black, left_margin + 118, line, right_margin - 2, line)
                            Exit For
                        End If
                    Next
                Next
                If cnt > 0 And tp > 0 Then
                    e.Graphics.DrawString(Format((tm / cnt), "0.00"), other_font, Brushes.Black, left_margin + 405, line + 3)
                    e.Graphics.DrawString(get_points(tp / cnt), other_font, Brushes.Black, left_margin + 510, line + 3)
                    e.Graphics.DrawString(Format((tp / cnt), "0.00"), other_font, Brushes.Black, left_margin + 645, line + 3)
                Else
                    e.Graphics.DrawString("--", other_font, Brushes.Black, left_margin + 350, line + 3)
                    e.Graphics.DrawString("--", other_font, Brushes.Black, left_margin + 450, line + 3)
                    e.Graphics.DrawString("--", other_font, Brushes.Black, left_margin + 555, line + 3)
                End If
                line += other_font.Height + 3
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 118, topline, left_margin + 118, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 390, topline, left_margin + 390, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 490, topline, left_margin + 490, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 610, topline, left_margin + 610, line)
            e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline, right_margin - 2, line)
        End If
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        rpt = "List"
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report()
        print_document.DefaultPageSettings.Landscape = False
        printpreview.Document = print_document
        printpreview.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        rpt = "Group"
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report()
        print_document.DefaultPageSettings.Landscape = False
        printpreview.Document = print_document
        printpreview.ShowDialog()
    End Sub
End Class