Imports System.Drawing.Printing
Public Class frmNationalMeanAnalysis

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmMeanAnalysis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() And dbNewOpen() Then
            Me.Close()
        Else
            load_stream1(ComboBox1, "FORM 4")
            ComboBox1.SelectedItem = Nothing
            loadData()
        End If
    End Sub

    Private Sub loadData()
        Dim total, count As Integer
        Dim prime As Boolean = IsPrimary()
        dgvSubjects.Rows.Clear()
        For k As Integer = 0 To subjabb.Length - 1
            If ComboBox1.SelectedItem = Nothing Then
                query = "SELECT `" & subjabb(k) & "` FROM `kcse_results` WHERE (Year='" & yr & "' AND  Examination='" & escape_string(exam_name) & "')"
            Else
                query = "SELECT `" & subjabb(k) & "` FROM `kcse_results` WHERE (Year='" & yr & "' AND  Examination='" & escape_string(exam_name) & "' AND Stream='" & escape_string(ComboBox1.SelectedItem) & "')"
            End If
            If qread(query) Then
                total = 0
                count = 0
                While dbreader.Read
                    If dbreader(subjabb(k)) <> "-" And dbreader(subjabb(k)) <> "" And dbreader(subjabb(k)) <> "X" Then
                        If prime Then
                            Dim values() As String = dbreader(subjabb(k)).ToString.Split(" ")
                            total += fix_point(values(values.Length - 1))
                        Else
                            total += fix_point(dbreader(subjabb(k)))
                        End If
                        count += 1
                    End If
                End While
                dgvSubjects.Rows.Add()
                dgvSubjects.Item("SubjID", k).Value = subjids(k)
                dgvSubjects.Item("Abbreviation", k).Value = subjabb(k)
                dgvSubjects.Item("SubjectName", k).Value = subjects(k)
                If count = 0 Or total = 0 Then
                    dgvSubjects.Item("MeanPoints", k).Value = 0.0
                Else
                    dgvSubjects.Item("MeanPoints", k).Value = Format(total / count, "0.00")
                End If
            End If
        Next
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            If mode Then
                dgvSubjects.Item("MeanGrade", k).Value = get_points(dgvSubjects.Item("MeanPoints", k).Value)
            Else
                dgvSubjects.Item("MeanGrade", k).Value = get_points(dgvSubjects.Item("MeanPoints", k).Value)
            End If
        Next
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            dgvSubjects.Item("MeanPoints", k).Value = Convert.ToDecimal(dgvSubjects.Item("MeanPoints", k).Value)
        Next
        dgvSubjects.Sort(dgvSubjects.Columns("MeanPoints"), System.ComponentModel.ListSortDirection.Descending)
    End Sub
    'Private Sub points(ByVal k)
    '    Dim tp, cnt, marks(0) As Integer
    '    For m As Integer = 0 To subjabb.Length - 1
    '        tp = 0
    '        cnt = 0
    '        If dgvSubjects.Item("Abbreviation", k).Value = subjabb(m) Then
    '            If mode Then
    '                For t As Integer = 0 To tables.Length - 1
    '                    qread("SELECT `" & subjname(m) & "` FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(tables(t)) & "' AND Term='" & tm & "' AND Year='" & yr & "')")
    '                    ReDim Preserve marks(dbReader.RecordsAffected - 1)
    '                    Dim i As Integer = 0
    '                    While dbReader.Read
    '                        If IsNumeric(dbReader(subjname(m))) Then
    '                            marks(i) += dbReader(subjname(m)) / total_mark(t) * contribution(t)
    '                        End If
    '                        i += 1
    '                    End While
    '                    dbReader.Close()
    '                Next
    '                For l As Integer = 0 To marks.Length - 1
    '                    cnt += 1
    '                    tp += fix_point(get_grade(marks(l), grading, subjabb(m)))
    '                Next
    '            Else
    '                Dim mark As Integer = get_total_mark(exam_name, tm)
    '                qread("SELECT `" & subjname(m) & "` FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "')")
    '                While dbReader.Read
    '                    If IsNumeric(dbReader(subjname(m))) Then
    '                        cnt += 1
    '                        tp += fix_point(get_grade((dbReader(subjname(m)) / mark) * 100, grading, subjabb(m)))
    '                    End If
    '                End While
    '                dbReader.Close()
    '            End If
    '            If cnt > 0 Then
    '                dgvSubjects.Item("MeanPoints", k).Value = Format(tp / cnt, "0.00")
    '            Else
    '                dgvSubjects.Item("MeanPoints", k).Value = "0.00"
    '            End If
    '        End If
    '    Next
    'End Sub
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
        qread("SELECT Name FROM departments ORDER BY DepartmentID")
        ReDim depts(dbreader.RecordsAffected - 1)
        While dbreader.Read
            depts(i) = dbreader("Name")
            i += 1
        End While
        Return depts
    End Function
    Private Sub print_report(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        'e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
        Dim line As Integer
        Dim left_margin As Integer = 60
        Dim right_margin As Integer = 720
        Dim topline As Integer
        line = 50
        e.Graphics.DrawString(S_NAME.ToUpper, header_font, Brushes.Black, left_margin + 150, line)
        line += header_font.Height
        e.Graphics.DrawString("EXAMINATION DEPARTMENT", other_font, Brushes.Black, left_margin + 200, line)
        line += other_font.Height
        If ComboBox1.SelectedItem <> Nothing Then
            e.Graphics.DrawString("FORM 4 " & ComboBox1.SelectedItem & " " & yr & " " & exam_name.ToUpper, other_font, Brushes.Black, left_margin + 200, line)
        Else
            e.Graphics.DrawString("FORM 4 " & yr & " " & exam_name.ToUpper, other_font, Brushes.Black, left_margin + 200, line)
        End If
        line += other_font.Height
        e.Graphics.DrawString(exam_name.ToString.ToUpper & " " & yr & " SUBJECT MEAN ANALYSIS REPORT", other_font, Brushes.Black, left_margin + 160, line)
        line += other_font.Height
        'e.Graphics.DrawString(, other_font, Brushes.Black, left_margin + 150, line)
        line += 15
        topline = line
        If rpt = "List" Then
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            e.Graphics.DrawString("SUBJECT", other_font, Brushes.Black, left_margin + 10, line + 3)
            e.Graphics.DrawString("MEAN GRADE", other_font, Brushes.Black, left_margin + 400, line + 3)
            e.Graphics.DrawString("MEAN POINTS", other_font, Brushes.Black, left_margin + 500, line + 3)
            line += 22
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            For k As Integer = 0 To dgvSubjects.Rows.Count - 1
                e.Graphics.DrawString(dgvSubjects.Item("SubjectName", k).Value, other_font, Brushes.Black, left_margin + 10, line + 3)
                e.Graphics.DrawString(dgvSubjects.Item("MeanGrade", k).Value, other_font, Brushes.Black, left_margin + 400, line + 3)
                e.Graphics.DrawString(dgvSubjects.Item("MeanPoints", k).Value, other_font, Brushes.Black, left_margin + 500, line + 3)
                line += 22
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 390, topline, left_margin + 390, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 490, topline, left_margin + 490, line)
            e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline, right_margin - 2, line)
        Else
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            e.Graphics.DrawString("SUBJECT GROUP", other_font, Brushes.Black, left_margin + 5, line + 3)
            e.Graphics.DrawString("SUBJECT", other_font, Brushes.Black, left_margin + 140, line + 3)
            e.Graphics.DrawString("MEAN GRADE", other_font, Brushes.Black, left_margin + 450, line + 3)
            e.Graphics.DrawString("MEAN POINTS", other_font, Brushes.Black, left_margin + 556, line + 3)
            line += other_font.Height + 3
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            Dim depts() As String = loadDepartments()
            For k As Integer = 0 To depts.Length - 1
                Dim dev As Double = 0
                Dim tp, tm, cnt As Double
                tp = 0
                tm = 0
                cnt = 0
                e.Graphics.DrawString(depts(k), other_font, Brushes.Black, left_margin + 5, line + 3)
                Dim subjs() = subjectsPerGroup(depts(k))
                For count = 0 To subjs.Length - 1
                    For row = 0 To dgvSubjects.Rows.Count - 1
                        If dgvSubjects.Item("SubjectName", row).Value = subjs(count) Then
                            e.Graphics.DrawString(subjs(count), other_font, Brushes.Black, left_margin + 135, line + 3)
                            e.Graphics.DrawString(dgvSubjects.Item("MeanGrade", row).Value, other_font, Brushes.Black, left_margin + 460, line + 3)
                            e.Graphics.DrawString(dgvSubjects.Item("MeanPoints", row).Value, other_font, Brushes.Black, left_margin + 565, line + 3)
                            line += other_font.Height + 3
                            tp += dgvSubjects.Item("MeanPoints", row).Value
                            cnt += 1
                            e.Graphics.DrawLine(Pens.Black, left_margin + 118, line, right_margin - 2, line)
                            Exit For
                        End If
                    Next
                Next
                If cnt > 0 And tp > 0 Then
                    e.Graphics.DrawString(get_points(tp / cnt), other_font, Brushes.Black, left_margin + 460, line + 3)
                    e.Graphics.DrawString(Format((tp / cnt), "0.00"), other_font, Brushes.Black, left_margin + 565, line + 3)
                Else
                    e.Graphics.DrawString("--", other_font, Brushes.Black, left_margin + 460, line + 3)
                    e.Graphics.DrawString("--", other_font, Brushes.Black, left_margin + 550, line + 3)
                End If
                e.Graphics.DrawString(" AVERAGE " & yr, other_font, Brushes.Black, left_margin + 200, line + 3)
                line += other_font.Height + 3
                e.Graphics.DrawLine(Pens.Black, left_margin + 118, line, right_margin - 2, line)
                e.Graphics.DrawString(" AVERAGE " & yr - 1, other_font, Brushes.Black, left_margin + 200, line + 3)
                Dim pts As Double = PreviousPoints(yr - 1, depts(k))
                e.Graphics.DrawString(get_points(pts), other_font, Brushes.Black, left_margin + 460, line + 3)
                e.Graphics.DrawString(Format(pts, "0.00"), other_font, Brushes.Black, left_margin + 565, line + 3)
                line += other_font.Height + 3
                dev = (tp / cnt) - pts
                e.Graphics.DrawLine(Pens.Black, left_margin + 118, line, right_margin - 2, line)
                e.Graphics.DrawString(" DEVIATION ", other_font, Brushes.Black, left_margin + 200, line + 3)
                If dev > 0 Then
                    e.Graphics.DrawString("+" & Format(dev, "0.00"), other_font, Brushes.Black, left_margin + 565, line + 3)
                Else
                    e.Graphics.DrawString(Format(dev, "0.00"), other_font, Brushes.Black, left_margin + 565, line + 3)
                End If
                line += other_font.Height + 3
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 118, topline, left_margin + 118, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 445, topline, left_margin + 445, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 555, topline, left_margin + 555, line)
            e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline, right_margin - 2, line)
        End If
    End Sub
    Private Function PreviousPoints(ByVal yr As Integer, ByVal dept As String) As Double
        qread("SELECT sum(mp) as mp, count(*) as num FROM `kcse_overall_subject_performance` WHERE subject IN (SELECT subject FROM subjects WHERE department='" & escape_string(dept) & "') AND year='" & yr & "'")
        dbreader.Read()
        Try
            Return dbreader("mp") / dbreader("num")
        Catch ex As Exception
            Return "--"
        End Try
    End Function
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        rpt = "List"
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report()
        print_document.DefaultPageSettings.Landscape = False
        printpreview.Document = print_document
        printpreview.ShowDialog()
    End Sub

    Private Sub btnPrint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        rpt = "Group"
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report()
        print_document.DefaultPageSettings.Landscape = False
        printpreview.Document = print_document
        printpreview.ShowDialog()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        loadData()
    End Sub
End Class