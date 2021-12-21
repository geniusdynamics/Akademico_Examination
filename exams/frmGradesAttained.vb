Imports System.Drawing.Printing
Public Class frmGradesAttained
    Dim admnos(), vals()
    Dim vals_alt() As String
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub create_form()
        dgvSubjects.Columns.Clear()
        Dim col As New DataGridViewColumn
        Dim cel As DataGridViewCell = New DataGridViewTextBoxCell
        With col
            .Name = "Grade"
            .HeaderText = String.Empty
            .CellTemplate = cel
            .ReadOnly = True
            .Width = 200
        End With
        dgvSubjects.Columns.Add(col)
        Dim ent As DataGridViewColumn = New DataGridViewColumn
        With ent
            .CellTemplate = cel
            .Width = 50
            .Name = "ENTRY"
            .HeaderText = "ENTRY"
            .ReadOnly = True
        End With
        dgvSubjects.Columns.Add(ent)
        For k As Integer = 0 To subjabb.Length - 1
            dgvSubjects.Rows.Add()
        Next
        For k As Integer = 0 To grades.Length - 1
            Dim column As New DataGridViewColumn
            Dim cell As DataGridViewCell = New DataGridViewTextBoxCell
            With column
                .CellTemplate = cell
                .Name = grades(k).Substring(0, 1) & k.ToString
                .HeaderText = grades(k)
                .ReadOnly = True
                .Width = 46
            End With
            dgvSubjects.Columns.Add(column)
        Next
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            dgvSubjects.Item("Grade", k).Value = subjects(k)
        Next
        Dim tp As DataGridViewColumn = New DataGridViewColumn
        With tp
            .CellTemplate = cel
            .Width = 60
            .Name = "STP"
            .HeaderText = "S. T. P."
            .ReadOnly = True
        End With
        dgvSubjects.Columns.Add(tp)
        Dim mp As DataGridViewColumn = New DataGridViewColumn
        With mp
            .CellTemplate = cel
            .Width = 60
            .Name = "SMP"
            .HeaderText = "S. M. P."
            .ReadOnly = True
        End With
        dgvSubjects.Columns.Add(mp)
        Dim mg As DataGridViewColumn = New DataGridViewColumn
        With mg
            .CellTemplate = cel
            .Width = 50
            .Name = "MG"
            .ReadOnly = True
            .HeaderText = "M.G."
        End With
        dgvSubjects.Columns.Add(mg)
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            For j As Integer = 0 To grades.Length - 1
                dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value = "-"
            Next
        Next
    End Sub
    Private Sub frmGradesAttained_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() And dbNewOpen() Then
            Me.Close()
        Else
            fill_class(ret_name(class_form), cboStream)
            cboStream.Items.Add("All")
            cboStream.SelectedItem = "All"
            load_data()
            state = True
        End If
    End Sub

    Private Sub load_data()
        pbar.Visible = True
        create_form()
        If mode Then
            ismode()
        Else
            not_mode()
        End If

        pbar.Increment(-100)
        Dim inc As Integer
        inc = 100 / grades.Length
        For k As Integer = 0 To grades.Length - 1
            If Not IsNumeric(dgvSubjects.Item(grades(k).Substring(0, 1) & k, dgvSubjects.Rows.Count - 1).Value) Then
                dgvSubjects.Item(grades(k).Substring(0, 1) & k, dgvSubjects.Rows.Count - 1).Value = "-"
            End If
            pbar.Increment(inc)
        Next
        pbar.Increment(-100)
        inc = 100 / dgvSubjects.Rows.Count
        compute_totals()
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            If IsNumeric(dgvSubjects.Item("SMP", k).Value) Then
                dgvSubjects.Item("SMP", k).Value = Convert.ToDouble(dgvSubjects.Item("SMP", k).Value)
            Else
                dgvSubjects.Item("SMP", k).Value = 0.0
            End If
        Next

        dgvSubjects.Rows.Add()
        dgvSubjects.Item("GRADE", dgvSubjects.Rows.Count - 1).Value = "OVERALL MEAN GRADE"
        For j As Integer = 0 To grades.Length - 1
            dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, dgvSubjects.Rows.Count - 1).Value = "-"
        Next
        means()
        compute_totals(dgvSubjects.Rows.Count - 1)
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            If IsNumeric(dgvSubjects.Item("SMP", k).Value) Then
                dgvSubjects.Item("MG", k).Value = get_points(dgvSubjects.Item("SMP", k).Value)
            Else
                dgvSubjects.Item("MG", k).Value = "--"
            End If
            dgvSubjects.Item("SMP", k).Value = Format(dgvSubjects.Item("SMP", k).Value, "0.00")
            pbar.Increment(inc)
        Next
        dgvSubjects.Sort(dgvSubjects.Columns("SMP"), System.ComponentModel.ListSortDirection.Descending)
        Dim tp, tot As Double
        For k As Integer = 0 To grades.Length - 1
            Try
                tp += dgvSubjects.Item(grades(k).Substring(0, 1) & k, dgvSubjects.Rows.Count - 1).Value * fix_point(grades(k))
                tot += dgvSubjects.Item(grades(k).Substring(0, 1) & k, dgvSubjects.Rows.Count - 1).Value
            Catch ex As Exception

            End Try

        Next
        dgvSubjects.Item("ENTRY", dgvSubjects.Rows.Count - 1).Value = tot
        dgvSubjects.Item("STP", dgvSubjects.Rows.Count - 1).Value = tp
        dgvSubjects.Item("SMP", dgvSubjects.Rows.Count - 1).Value = Math.Round(tp / tot, 3, MidpointRounding.AwayFromZero)
        dgvSubjects.Item("MG", dgvSubjects.Rows.Count - 1).Value = get_points(tp / tot)
        pbar.Increment(-100)
        pbar.Visible = False
    End Sub
    Private Sub means()
        Dim sum As String
        Dim overall_grades(grades.Length - 1)
        If best_of_7 Then
            If mod_subject Then
                sum = "B7SB_TP"
            Else
                sum = "B7NSB_TP"
            End If
        Else
            If mod_subject Then
                sum = "SB_TP"
            Else
                sum = "NSB_TP"
            End If
        End If
        If Not mode Then
            If best_of_7 Then
                If cboStream.SelectedItem = "All" Then
                    query = "SELECT * FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(exam_name) & "' AND Term='" & tm & "' AND Year='" & yr & "' AND " & sum & ">0)"
                Else
                    query = "SELECT * FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(exam_name) & "' AND Stream='" & escape_string(cboStream.SelectedItem) & "' AND Term='" & tm & "' AND Year='" & yr & "' AND " & sum & ">0)"
                End If
            Else
                If cboStream.SelectedItem = "All" Then
                    query = "SELECT * FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(exam_name) & "' AND Term='" & tm & "' AND Year='" & yr & "')"
                Else
                    query = "SELECT * FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(exam_name) & "' AND Stream='" & escape_string(cboStream.SelectedItem) & "' AND Term='" & tm & "' AND Year='" & yr & "')"
                End If
            End If
            qread(query)
            Dim temp, count
            While dbreader.Read
                count = 0
                If best_of_7 Then
                    temp = get_points(dbreader(sum) / 7)
                Else
                    For k As Integer = 0 To subjabb.Length - 1
                        If IsNumeric(dbreader(subjname(k))) Then
                            count += 1
                        End If
                    Next
                    temp = get_points(dbreader(sum) / count)
                End If
                For k As Integer = 0 To grades.Length - 1
                    If temp = grades(k) Then
                        overall_grades(k) += 1
                        Exit For
                    End If
                Next
            End While
            For k As Integer = 0 To overall_grades.Length - 1
                dgvSubjects.Item(grades(k).Substring(0, 1) & k.ToString, dgvSubjects.Rows.Count - 1).Value = overall_grades(k)
            Next
        Else
            For k As Integer = 0 To exam_names.Length - 1

            Next
        End If
    End Sub
    Private Sub compute_totals(Optional ByVal start As Integer = 0)
        Dim count, inc As Integer
        pbar.Increment(-100)
        inc = 100 / subjabb.Length
        For s As Integer = 0 To dgvSubjects.Rows.Count - 2
            count = 0
            dgvSubjects.Item("STP", s).Value = 0
            For k As Integer = 0 To grades.Length - 1
                If IsNumeric(dgvSubjects.Item(grades(k).Substring(0, 1) & k.ToString, s).Value) Then
                    dgvSubjects.Item("STP", s).Value += fix_point(grades(k)) * dgvSubjects.Item(grades(k).Substring(0, 1) & k.ToString, s).Value
                    count += dgvSubjects.Item(grades(k).Substring(0, 1) & k.ToString, s).Value
                End If
            Next
            If count > 0 Then
                dgvSubjects.Item("SMP", s).Value = Convert.ToDouble(dgvSubjects.Item("STP", s).Value) / count
            Else
                dgvSubjects.Item("SMP", s).Value = "--"
            End If
            dgvSubjects.Item("ENTRY", s).Value = count
            pbar.Increment(inc)
        Next
    End Sub
    Private Function LargestTable() As String
        LargestTable = Nothing
        Dim large As Integer = 0
        For k As Integer = 0 To exam_names.Length - 1
            qread("SELECT id FROM exam_results WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(exam_names(k)) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "')")
            If dbreader.RecordsAffected > large Then
                large = dbreader.RecordsAffected
                largest_index = k
                LargestTable = exam_names(k)
            End If
        Next
        Return LargestTable
    End Function
    Dim largest_index
    Private Sub ismode()
        Dim m, j As Integer
        m = 0
        j = 0
        Dim largest_table As String = LargestTable()
        Dim opt_query As String = Nothing
        If cboStream.SelectedItem <> "All" And cboStream.SelectedItem <> Nothing Then
            opt_query = " AND stream = '" & escape_string(cboStream.SelectedItem) & "'"
        End If
        pbar.Visible = True
        Dim inc As Integer
        pbar.Increment(-100)
        If qread("SELECT ADMNo FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(largest_table) & "' AND Term='" & tms(largest_index) & "' AND Year='" & yrs(largest_index) & "'" & opt_query & ")") Then
            If dbreader.RecordsAffected > 100 Then
                inc = dbreader.RecordsAffected / 100
            Else
                inc = 100 / dbreader.RecordsAffected
            End If
            ReDim admnos(dbreader.RecordsAffected - 1)
            While dbreader.Read
                admnos(m) = dbreader("ADMNo")
                m += 1
                If m Mod inc = 0 Then
                    pbar.Increment(1)
                End If
            End While
        End If
        pbar.Increment(-100)
        ReDim vals_alt(subjabb.Length - 1)
        ReDim vals(subjabb.Length - 1)
        Dim out_of As Double
        For m = 0 To admnos.Length - 1
            For k As Integer = 0 To subjabb.Length - 1
                vals(k) = 0
                vals_alt(k) = Nothing
            Next
            For k As Integer = 0 To exam_names.Length - 1
                If qread("SELECT * FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND ADMNo='" & admnos(m) & "' AND Examination='" & escape_string(exam_names(k)) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "')") Then
                    If dbreader.RecordsAffected > 0 Then
                        dbreader.Read()
                        For j = 0 To subjabb.Length - 1
                            If IsNumeric(dbreader(subjabb(j))) Then
                                out_of = SubjectOutOf(subjname(k), tms(k), yrs(k), exam_names(k), class_form, dbreader("Stream"), 2)
                                vals(j) += ((dbreader(subjabb(j)) / out_of) * total_mark(k)) * (contribution(k) / 100)
                            Else
                                vals_alt(j) = dbreader(subjabb(j))
                            End If
                        Next
                    End If
                End If
            Next
            Dim val As String
            For k As Integer = 0 To subjabb.Length - 1
                If vals_alt(k) = Nothing Then
                    val = get_grade(vals(k), mod_subject, subjects(k))
                    For j = 0 To grades.Length - 3
                        If val = grades(j) Then
                            If IsNumeric(dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value) Then
                                dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value = dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value + 1
                            Else
                                dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value = 1
                            End If
                            Exit For
                        End If
                    Next
                ElseIf vals_alt(k) = "X" Then
                    If IsNumeric(dgvSubjects.Item("X12", k).Value) Then
                        dgvSubjects.Item("X12", k).Value = dgvSubjects.Item("X12", k).Value + 1
                    Else
                        dgvSubjects.Item("X12", k).Value = 1
                    End If
                ElseIf vals_alt(k) = "Y" Then
                    If IsNumeric(dgvSubjects.Item("Y13", k).Value) Then
                        dgvSubjects.Item("Y13", k).Value = dgvSubjects.Item("Y13", k).Value + 1
                    Else
                        dgvSubjects.Item("Y13", k).Value = 1
                    End If
                End If
            Next
            If m Mod inc = 0 Then
                pbar.Increment(1)
            End If
        Next
    End Sub
    Private Sub not_mode()
        If cboStream.SelectedItem = "All" Then
            query = "SELECT ADMNo, Stream FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND  Examination='" & escape_string(exam_name) & "' AND Term='" & tm & "' AND Year='" & yr & "')"
        Else
            query = "SELECT ADMNo, Stream FROM `" & table & "` WHERE (Examination='" & escape_string(exam_name) & "' AND class='" & escape_string(class_form) & "' AND Stream='" & escape_string(cboStream.SelectedItem) & "' AND Term='" & tm & "' AND Year='" & yr & "')"
        End If
        pbar.Visible = True
        Dim inc As Integer
        If qread(query) Then
            ReDim admnos(dbreader.RecordsAffected - 1)
            If admnos.Length > 100 Then
                inc = dbreader.RecordsAffected / 100
            Else
                inc = 1
            End If
            Dim m As Integer = 0
            While dbreader.Read
                admnos(m) = dbreader("ADMNo")
                pbar.Increment(inc)
                m += 1
            End While
            pbar.Increment(-100)
            ReDim vals_alt(subjabb.Length - 1)
            ReDim vals(subjabb.Length - 1)
            Dim out_of As Double
            For m = 0 To admnos.Length - 1
                If qread("SELECT * FROM `" & table & "` WHERE (ADMNo='" & admnos(m) & "' AND Examination='" & escape_string(exam_name) & "' AND Term='" & tm & "' AND Year='" & yr & "')") Then
                    dbreader.Read()
                    For k As Integer = 0 To subjabb.Length - 1
                        If IsNumeric(dbreader(subjabb(k))) Then
                            out_of = SubjectOutOf(subjname(k), tm, yr, exam_name, class_form, dbreader("Stream"), 2)
                            vals(k) = (dbreader(subjabb(k)) / out_of) * marks
                            vals_alt(k) = 0
                        Else
                            vals(k) = dbreader(subjabb(k))
                            vals_alt(k) = dbreader(subjabb(k))
                        End If
                    Next
                    Dim val As String
                    For k As Integer = 0 To subjabb.Length - 1
                        If IsNumeric(vals(k)) Then
                            val = get_grade(vals(k), mod_subject, subjabb(k))
                        Else
                            val = vals(k)
                        End If
                        For j As Integer = 0 To grades.Length - 1
                            If val = grades(j) Then
                                If IsNumeric(dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value) Then
                                    dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value = dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value + 1
                                    Exit For
                                Else
                                    dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value = 1
                                    Exit For
                                End If
                            End If
                        Next
                    Next
                End If
                pbar.Increment(inc)
            Next
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report()
        print_document.DefaultPageSettings.Landscape = True
        print_document.Print()
    End Sub
    Private Function print_student_report()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report
        Return print_document
    End Function
    Public Function logo() As String
        qread("SELECT image_path FROM school_details")
        dbreader.Read()
        logo = dbreader("image_path")
        dbreader.Close()
    End Function
    Private Sub print_report(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        'e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
        Dim line As Integer
        Dim left_margin As Integer = 20
        Dim right_margin As Integer = (grades.Length + 4) * 45 + 272
        Dim topline As Integer = 250

        Try
            e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), CInt(e.PageBounds.Width / 2) - 50, topline - 230, 100, 100)
        Catch ex As Exception

        End Try
        Dim CenterPage As Single
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(S_NAME.ToUpper, header_font).Width / 2)
        e.Graphics.DrawString(S_NAME.ToUpper, header_font, Brushes.Black, CenterPage, 130)
        If mode Then
            exam_name = Nothing
            For k As Integer = 0 To exam_names.Length - 1
                exam_name &= exam_names(k)
                If k < exam_names.Length - 1 Then
                    exam_name &= "/"
                End If
            Next
        End If
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(exam_name.ToUpper & " TERM " & tm & " " & yr & " EXAMINATION PERFORMANCE ANALYSIS", header_font).Width / 2)
        e.Graphics.DrawString(exam_name.ToUpper & " TERM " & tm & " " & yr & " EXAMINATION PERFORMANCE ANALYSIS", header_font, Brushes.Black, CenterPage, 160)
        Dim class_name As String = class_form.ToString.ToUpper
        If cboStream.SelectedItem <> "All" Then
            class_name &= " " & cboStream.SelectedItem
        Else
            class_name &= " COMBINED"
        End If
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(class_name, other_font).Width / 2)
        e.Graphics.DrawString(class_name, header_font, Brushes.Black, CenterPage, 190)
        line = topline - 20
        Dim col As Integer = 300
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
        e.Graphics.DrawString("GRADES ATTAINED PER SUBJECT", other_font, Brushes.Black, left_margin + 5, line + 5)
        For k As Integer = 0 To grades.Length - 1
            e.Graphics.DrawString(grades(k), other_font, Brushes.Black, left_margin + col + 2, line + 5)
            col += 40
        Next
        e.Graphics.DrawString("STP", other_font, Brushes.Black, left_margin + col, line + 5)
        col += 40
        e.Graphics.DrawString("SMP", other_font, Brushes.Black, left_margin + col + 2, line + 5)
        col += 70
        e.Graphics.DrawString("ENTRY", other_font, Brushes.Black, left_margin + col - 9, line + 5)
        col += 40
        e.Graphics.DrawString("MG", other_font, Brushes.Black, left_margin + col + 5, line + 5)
        line += 22
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2)
        For k As Integer = 0 To subjabb.Length - 1
            e.Graphics.DrawString(dgvSubjects.Item("Grade", k).Value, other_font, Brushes.Black, left_margin + 5, line + 3)
            line += 22
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2)
        Next
        e.Graphics.DrawString("OVERALL MEAN GRADE", other_font, Brushes.Black, left_margin + 5, line + 3)
        line += 22
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2)
        line = topline + 22 - 20
        col = 300
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            For j As Integer = 0 To grades.Length - 1
                e.Graphics.DrawString(dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value, other_font, Brushes.Black, left_margin + col + 5, line + 3)
                col += 40
            Next
            e.Graphics.DrawString(dgvSubjects.Item("STP", k).Value, other_font, Brushes.Black, left_margin + col, line + 3)
            col += 40
            e.Graphics.DrawString(dgvSubjects.Item("SMP", k).Value, other_font, Brushes.Black, left_margin + col - 5, line + 3)
            col += 70
            e.Graphics.DrawString(dgvSubjects.Item("ENTRY", k).Value, other_font, Brushes.Black, left_margin + col + 5, line + 3)
            col += 50
            e.Graphics.DrawString(dgvSubjects.Item("MG", k).Value, other_font, Brushes.Black, left_margin + col + 5, line + 3)
            col = 300
            line += 22
        Next
        'e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
        'e.Graphics.DrawLine(Pens.Black, left_margin + 250, topline, left_margin + 250, line + 2)
        col = 300
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline - 20, left_margin - 2, line + 2)
        For k As Integer = 0 To grades.Length + 3
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 10, topline - 20, left_margin + col - 10, line + 2)
            If k = grades.Length + 1 Then
                col += 70
            ElseIf k = grades.Length + 2 Then
                col += 50
            Else
                col += 40
            End If
        Next
        e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline - 20, right_margin - 2, line + 2)
        line += 30
        e.Graphics.DrawString("   SE	= SUBJECT ENTRIES					STP 		= SUBJECT TOTAL POINTS" & vbNewLine &
                              "   TP	= TOTAL POINTS					SMP		= SUBJECT MEAN POINTS" & vbNewLine &
                              "   MP	= MEAN POINTS					" & vbNewLine &
                              "   TM	= TOTAL MARKS					", other_font, Brushes.Black, left_margin, line)
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report()
        print_document.DefaultPageSettings.Landscape = True
        printpreview.Document = print_document
        printpreview.ShowDialog()
    End Sub
    Dim state As Boolean = False
    Private Sub cboStream_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStream.SelectedIndexChanged
        If state Then
            load_data()
        End If
    End Sub
End Class