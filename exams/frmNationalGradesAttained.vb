Imports System.Drawing.Printing
Public Class frmNationalGradesAttained
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
            .HeaderText = ""
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
                .ReadOnly = False
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
            .Visible = False
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
            .Visible = False
            .ReadOnly = True
        End With
        dgvSubjects.Columns.Add(mp)
        Dim tp1 As DataGridViewColumn = New DataGridViewColumn
        With tp1
            .CellTemplate = cel
            .Width = 60
            .Name = (Today.Year - 1).ToString
            .HeaderText = "MEAN " & (Today.Year - 1).ToString
            .ReadOnly = True
        End With
        dgvSubjects.Columns.Add(tp1)
        Dim mp1 As DataGridViewColumn = New DataGridViewColumn
        With mp1
            .CellTemplate = cel
            .Width = 60
            .Name = (Today.Year - 2).ToString
            .HeaderText = "MEAN " & (Today.Year - 2).ToString
            .ReadOnly = True
        End With
        dgvSubjects.Columns.Add(mp1)
        Dim mp11 As DataGridViewColumn = New DataGridViewColumn
        With mp11
            .CellTemplate = cel
            .Width = 60
            .Name = "DEVIATION"
            .HeaderText = "DEV."
            .ReadOnly = True
        End With
        dgvSubjects.Columns.Add(mp11)
        Dim mg As DataGridViewColumn = New DataGridViewColumn
        With mg
            .CellTemplate = cel
            .Width = 50
            .Name = "MG"
            .ReadOnly = True
            .HeaderText = "M.G."
        End With
        dgvSubjects.Columns.Add(mg)
    End Sub
    Private Sub frmGradesAttained_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() And dbNewOpen() Then
            Me.Close()
        Else
            load_stream1(ComboBox1, "Form 4")
            ComboBox1.Items.Add("All")
            ComboBox1.SelectedItem = "All"
            state = True
            load_data()
        End If
    End Sub
    Dim state As Boolean = False
    Private Sub load_data()
        If state Then
            create_form()
            not_mode()
            compute_totals()
            dgvSubjects.Rows.Add()
            dgvSubjects.Item("GRADE", dgvSubjects.Rows.Count - 1).Value = "TOTAL GRADES"
            For g As Integer = 0 To grades.Length - 1
                Dim totG As Integer = 0
                For k As Integer = 0 To dgvSubjects.Rows.Count - 4
                    Try
                        totG += dgvSubjects.Item(grades(g).Substring(0, 1) & g, k).Value
                    Catch ex As Exception

                    End Try
                Next
                dgvSubjects.Item(grades(g).Substring(0, 1) & g, dgvSubjects.Rows.Count - 1).Value = totG
            Next
            'dgvSubjects.Sort(dgvSubjects.Columns("SMP"), System.ComponentModel.ListSortDirection.Descending)
            dgvSubjects.Rows.Add()
            dgvSubjects.Item("GRADE", dgvSubjects.Rows.Count - 1).Value = "OVERALL SCHOOL MEAN GRADE " & yr
            'For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            '    For j As Integer = 0 To grades.Length - 1
            '        dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value = "-"
            '    Next
            'Next
            'means()
            Dim inc As Integer
            inc = 100 / grades.Length
            For k As Integer = 0 To grades.Length - 1
                If Not IsNumeric(dgvSubjects.Item(grades(k).Substring(0, 1) & k, dgvSubjects.Rows.Count - 1).Value) Then
                    dgvSubjects.Item(grades(k).Substring(0, 1) & k, dgvSubjects.Rows.Count - 1).Value = "-"
                End If
            Next
            inc = 100 / dgvSubjects.Rows.Count
            For k As Integer = 0 To dgvSubjects.Rows.Count - 3
                dgvSubjects.Item("MG", k).Value = get_points(dgvSubjects.Item("SMP", k).Value)
            Next
            dgvSubjects.Rows.Add()
            dgvSubjects.Item("GRADE", dgvSubjects.Rows.Count - 1).Value = "OVERALL SCHOOL MEAN GRADE " & yr - 1
            qread("SELECT * FROM kcse_overall_performance WHERE year='" & yr - 1 & "'")
            dbreader.Read()
            For k As Integer = 0 To grades.Length - 1
                dgvSubjects.Item(grades(k).Substring(0, 1) & k, dgvSubjects.Rows.Count - 1).Value = dbreader(grades(k))
            Next
            dgvSubjects.Item((yr - 1).ToString, dgvSubjects.Rows.Count - 2).Value = dbreader("mp")
            dgvSubjects.Item("MG", dgvSubjects.Rows.Count - 1).Value = dbreader("mg")
            dgvSubjects.Item("ENTRY", dgvSubjects.Rows.Count - 1).Value = dbreader("Entry")
            Dim dev As Double = Convert.ToDouble(dgvSubjects.Item(yr.ToString, dgvSubjects.Rows.Count - 2).Value) - Convert.ToDouble(dgvSubjects.Item((yr - 1).ToString, dgvSubjects.Rows.Count - 2).Value)
            If dev > 0 Then
                dgvSubjects.Item("DEVIATION", dgvSubjects.Rows.Count - 2).Value = "+" & Format(dev, "0.00")
            Else
                dgvSubjects.Item("DEVIATION", dgvSubjects.Rows.Count - 2).Value = Format(dev, "0.00")
            End If
            dgvSubjects.Item("MG", dgvSubjects.Rows.Count - 2).Value = get_points(dgvSubjects.Item(yr.ToString, dgvSubjects.Rows.Count - 2).Value)
        End If
    End Sub
    Private Sub means()
        For k As Integer = 0 To grades.Length - 1
            If ComboBox1.SelectedItem = "All" Then
                qread("SELECT count(*) as number FROM `kcse_results` WHERE (year='" & yr & "' AND Examination='" & escape_string(exam_name) & "' AND mg='" & escape_string(grades(k)) & "')")
            Else
                qread("SELECT count(*) as number FROM `kcse_results` WHERE (year='" & yr & "' AND Examination='" & escape_string(exam_name) & "' AND mg='" & escape_string(grades(k)) & "' AND stream='" & escape_string(ComboBox1.SelectedItem) & "')")
            End If
            dbreader.Read()
            dgvSubjects.Item(grades(k).Substring(0, 1).ToString & k, dgvSubjects.Rows.Count - 1).Value = dbreader("number")
        Next
        If ComboBox1.SelectedItem = "All" Then
            qread("SELECT count(*) as number FROM `kcse_results` WHERE (year='" & yr & "' AND Examination='" & escape_string(exam_name) & "' AND tp>0)")
        Else
            qread("SELECT count(*) as number FROM `kcse_results` WHERE (year='" & yr & "' AND Examination='" & escape_string(exam_name) & "' AND stream='" & escape_string(ComboBox1.SelectedItem) & "' AND tp>0)")
        End If
        dbreader.Read()
        dgvSubjects.Item("ENTRY", dgvSubjects.Rows.Count - 1).Value = dbreader("number")
        If ComboBox1.SelectedItem = "All" Then
            qread("SELECT mg FROM `kcse_results` WHERE (year='" & yr & "' AND Examination='" & escape_string(exam_name) & "') AND mg!='X'")
        Else
            qread("SELECT mg FROM `kcse_results` WHERE (year='" & yr & "' AND Examination='" & escape_string(exam_name) & "' AND stream='" & escape_string(ComboBox1.SelectedItem) & "' AND mg!='X')")
        End If
        Dim tp As Double = 0
        Dim cnt As Integer = 0
        While dbreader.Read
            tp += fix_point(dbreader("mg"))
            cnt += 1
        End While
        dgvSubjects.Item("STP", dgvSubjects.Rows.Count - 1).Value = tp
        dgvSubjects.Item("SMP", dgvSubjects.Rows.Count - 1).Value = Format((tp / cnt), "0.00")
        dgvSubjects.Item(yr.ToString, dgvSubjects.Rows.Count - 1).Value = Format((tp / cnt), "0.00")
        For k As Integer = 0 To dgvSubjects.Rows.Count - 3
            qread("SELECT mp FROM kcse_overall_subject_performance WHERE subject='" & escape_string(dgvSubjects.Item("Grade", k).Value) & "' AND year='" & yr - 1 & "'")
            dbreader.Read()
            dgvSubjects.Item((yr - 1).ToString, k).Value = dbreader("mp")
            If dgvSubjects.Item((yr - 1).ToString, k).Value = 0 Then
                dgvSubjects.Item("DEVIATION", k).Value = "--"
            Else
                dgvSubjects.Item("DEVIATION", k).Value = Format(dgvSubjects.Item(yr.ToString, k).Value - dgvSubjects.Item((yr - 1).ToString, k).Value, "0.00")
            End If
        Next
    End Sub
    Private Sub compute_totals()
        Dim count, inc As Integer
        inc = 100 / subjabb.Length
        For s As Integer = 0 To subjabb.Length - 1
            If s = 3 Then
                MsgBox("here")
            End If
            count = 0
            dgvSubjects.Item("STP", s).Value = 0
            For k As Integer = 0 To grades.Length - 3
                If IsNumeric(dgvSubjects.Item(grades(k).Substring(0, 1) & k.ToString, s).Value) Then
                    dgvSubjects.Item("STP", s).Value += fix_point(grades(k)) * dgvSubjects.Item(grades(k).Substring(0, 1) & k.ToString, s).Value
                    count += dgvSubjects.Item(grades(k).Substring(0, 1) & k.ToString, s).Value
                End If
            Next
            If count > 0 Then
                dgvSubjects.Item("SMP", s).Value = Format(Convert.ToDouble(dgvSubjects.Item("STP", s).Value) / count, "0.00")
                dgvSubjects.Item(yr.ToString, s).Value = Format(Convert.ToDouble(dgvSubjects.Item("STP", s).Value) / count, "0.00")
            Else
                dgvSubjects.Item("SMP", s).Value = 0
            End If
            dgvSubjects.Item("ENTRY", s).Value = count
        Next
    End Sub
    Private Sub not_mode()
        Dim prime As Boolean = IsPrimary()
        For k As Integer = 0 To grades.Length - 1
            For s As Integer = 0 To subjabb.Length - 1
                If prime Then
                    Dim cnt As Integer = 0
                    If ComboBox1.SelectedItem = "All" Then
                        qread("SELECT `" & subjabb(s) & "` FROM `kcse_results` WHERE (`" & subjabb(s) & "` LIKE '% " & escape_string(grades(k)) & "%' AND Examination='" & escape_string(exam_name) & "' AND Year='" & yr & "')")
                    Else
                        qread("SELECT `" & subjabb(s) & "` FROM `kcse_results` WHERE (`" & subjabb(s) & "` LIKE '% " & escape_string(grades(k)) & "%' AND Examination='" & escape_string(exam_name) & "' AND Year='" & yr & "' AND stream='" & escape_string(ComboBox1.SelectedItem) & "')")
                    End If
                    While dbreader.Read
                        Dim values() = dbreader(subjabb(s)).ToString.Split(" ")
                        If values(values.Length - 1).ToString = grades(k) Then
                            cnt += 1
                        End If
                    End While
                    dgvSubjects.Item(grades(k).Substring(0, 1) & k, s).Value = cnt
                Else
                    If ComboBox1.SelectedItem = "All" Then
                        qread("SELECT count(*) as number FROM `kcse_results` WHERE (`" & subjabb(s) & "`='" & escape_string(grades(k)) & "' AND Examination='" & escape_string(exam_name) & "' AND Year='" & yr & "')")
                    Else
                        qread("SELECT count(*) as number FROM `kcse_results` WHERE (`" & subjabb(s) & "`='" & escape_string(grades(k)) & "' AND Examination='" & escape_string(exam_name) & "' AND Year='" & yr & "' AND stream='" & escape_string(ComboBox1.SelectedItem) & "')")
                    End If
                    dbreader.Read()
                    dgvSubjects.Item(grades(k).Substring(0, 1) & k, s).Value = dbreader("number")
                End If
            Next
        Next
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
        qread("SELECT logo FROM school_details")
        dbreader.Read()
        logo = dbreader("logo")
        dbreader.Close()
    End Function
    Private Sub print_report(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        'e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
        Dim line As Integer
        Dim left_margin As Integer = 30
        Dim right_margin As Integer = (grades.Length + 5) * 45 + 302
        Dim topline As Integer = 100
        Try
            e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, topline - 130, 100, 100)
        Catch ex As Exception

        End Try
        e.Graphics.DrawString(S_NAME.ToUpper, header_font, Brushes.Black, (right_margin - left_margin) / 3, 20)
        e.Graphics.DrawString(exam_name.ToUpper & " EXAMINATION PERFORMANCE SUBJECT ANALYSIS", header_font, Brushes.Black, (right_margin - left_margin) / 4, 20 + header_font.Height + 5)
        If ComboBox1.SelectedItem = "All" Then
            e.Graphics.DrawString("FORM 4 " & yr & " " & exam_name.ToUpper, header_font, Brushes.Black, (right_margin - left_margin) / 2 - 100, 20 + header_font.Height + header_font.Height + 5)
        Else
            e.Graphics.DrawString("FORM 4 " & ComboBox1.SelectedItem & " " & yr & " " & exam_name.ToUpper, header_font, Brushes.Black, (right_margin - left_margin) / 2 - 100, 20 + header_font.Height + header_font.Height + 5)
        End If
        line = topline
        Dim col As Integer = 270
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
        e.Graphics.DrawString("GRADES ATTAINED PER SUBJECT", medium, Brushes.Black, left_margin + 5, line + 5)
        For k As Integer = 0 To grades.Length - 1
            e.Graphics.DrawString(grades(k), other_font, Brushes.Black, left_margin + col + 2, line + 4)
            col += 40
        Next
        e.Graphics.DrawString(yr.ToString, medium, Brushes.Black, left_margin + col + 2, line + 5)
        col += 60
        e.Graphics.DrawString((yr - 1).ToString, medium, Brushes.Black, left_margin + col + 2, line + 5)
        col += 60
        e.Graphics.DrawString("DEV", medium, Brushes.Black, left_margin + col - 10, line + 5)
        col += 45
        e.Graphics.DrawString("ENTRY", medium, Brushes.Black, left_margin + col - 5, line + 5)
        col += 45
        e.Graphics.DrawString("MG " & yr, medium, Brushes.Black, left_margin + col, line + 5)
        line += 22
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2)
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            If k < dgvSubjects.Rows.Count - 3 Then
                e.Graphics.DrawString(dgvSubjects.Item("Grade", k).Value, medium, Brushes.Black, left_margin + 5, line + 4)
            Else
                e.Graphics.DrawString(dgvSubjects.Item("Grade", k).Value, other_font, Brushes.Black, left_margin + 5, line + 4)
            End If
            line += 22
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2)
        Next
        'e.Graphics.DrawString("OVERALL MEAN GRADE", medium, Brushes.Black, left_margin + 5, line + 3)
        'line += 22
        'e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2)
        line = topline + 22
        col = 270
        For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            If k < dgvSubjects.Rows.Count - 3 Then
                For j As Integer = 0 To grades.Length - 1
                    e.Graphics.DrawString(dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value, medium, Brushes.Black, left_margin + col + 5, line + 4)
                    col += 40
                Next
                e.Graphics.DrawString(dgvSubjects.Item(yr.ToString, k).Value, medium, Brushes.Black, left_margin + col, line + 4)
                col += 60
                e.Graphics.DrawString(dgvSubjects.Item((yr - 1).ToString, k).Value, medium, Brushes.Black, left_margin + col - 5, line + 4)
                col += 60
                e.Graphics.DrawString(dgvSubjects.Item("DEVIATION", k).Value, medium, Brushes.Black, left_margin + col - 10, line + 4)
                col += 45
                e.Graphics.DrawString(dgvSubjects.Item("ENTRY", k).Value, medium, Brushes.Black, left_margin + col + 1, line + 4)
                col += 45 + 20
                e.Graphics.DrawString(dgvSubjects.Item("MG", k).Value, medium, Brushes.Black, left_margin + col, line + 4)
                col = 270
                line += 22
            Else
                For j As Integer = 0 To grades.Length - 1
                    e.Graphics.DrawString(dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value, other_font, Brushes.Black, left_margin + col + 5, line + 4)
                    col += 40
                Next
                e.Graphics.DrawString(dgvSubjects.Item(yr.ToString, k).Value, other_font, Brushes.Black, left_margin + col, line + 4)
                col += 60
                e.Graphics.DrawString(dgvSubjects.Item((yr - 1).ToString, k).Value, other_font, Brushes.Black, left_margin + col - 5, line + 4)
                col += 60
                e.Graphics.DrawString(dgvSubjects.Item("DEVIATION", k).Value, medium, Brushes.Black, left_margin + col - 10, line + 4)
                col += 45
                e.Graphics.DrawString(dgvSubjects.Item("ENTRY", k).Value, other_font, Brushes.Black, left_margin + col + 1, line + 4)
                col += 70
                e.Graphics.DrawString(dgvSubjects.Item("MG", k).Value, other_font, Brushes.Black, left_margin + col, line + 4)
                col = 270
                line += 22
            End If
        Next
        'e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
        'e.Graphics.DrawLine(Pens.Black, left_margin + 250, topline, left_margin + 250, line + 2)
        col = 270
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line + 2)
        For k As Integer = 0 To grades.Length + 4
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 10, topline, left_margin + col - 10, line + 2)
            If k = grades.Length + 1 Or k = grades.Length Then
                col += 60
            Else
                col += 40
            End If
            If k = grades.Length + 2 Then
                col += 10
            End If
            If k = grades.Length + 3 Then
                col += 10
            ElseIf k = grades.Length + 4 Then
                col += 30
            End If
        Next
        e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline, right_margin - 2, line + 2)
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

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        load_data()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem = "All" Then
            start()
            Dim imp As Double = 0
            qread("SELECT mp FROM kcse_overall_performance WHERE (year='" & yr - 1 & "' AND Examination='" & escape_string(exam_name) & "')")
            dbreader.Read()
            Try
                imp = dbreader("mp")
            Catch ex As Exception

            End Try
            query = "INSERT INTO `kcse_overall_performance` VALUES(NULL, '" & escape_string(exam_name) & "', '" & yr & "', '" & dgvSubjects.Item("ENTRY", dgvSubjects.Rows.Count - 1).Value & "','" & dgvSubjects.Item("SMP", dgvSubjects.Rows.Count - 1).Value & "','" & dgvSubjects.Item("MG", dgvSubjects.Rows.Count - 1).Value & "'," & dgvSubjects.Item("SMP", dgvSubjects.Rows.Count - 1).Value - imp & ","
            For k As Integer = 0 To grades.Length - 1
                query &= "'" & dgvSubjects.Item(grades(k).Substring(0, 1).ToString & k, dgvSubjects.Rows.Count - 1).Value & "'"
                If k < grades.Length - 1 Then
                    query &= ","
                End If
            Next
            query &= ")"

            If Not qwrite("DELETE FROM `kcse_overall_performance` WHERE (Examination='" & escape_string(exam_name) & "' AND year='" & yr & "')") Or Not qwrite(query) Then
                rollback()
                failure("Results Analysis Could Not Be Saved!")
                Exit Sub
            End If
            If Not qwrite("DELETE FROM `kcse_overall_subject_performance` WHERE (Examination='" & escape_string(exam_name) & "' AND year='" & yr & "')") Then
                rollback()
                failure("Results Analysis Could Not Be Saved!")
                Exit Sub
            End If
            For k As Integer = 0 To dgvSubjects.Rows.Count - 4
                qread("SELECT mp FROM kcse_overall_subject_performance WHERE (year='" & yr - 1 & "' AND Examination='" & escape_string(exam_name) & "' AND subject='" & escape_string(dgvSubjects.Item("Grade", k).Value) & "')")
                dbreader.Read()
                Try
                    imp = dbreader("mp")
                Catch ex As Exception

                End Try
                query = "INSERT INTO `kcse_overall_subject_performance` VALUES(NULL, '" & escape_string(exam_name) & "', '" & yr & "','" & dgvSubjects.Item("GRADE", k).Value & "','" & dgvSubjects.Item("Entry", k).Value & "','" & dgvSubjects.Item("SMP", k).Value & "','" & dgvSubjects.Item("MG", k).Value & "','" & dgvSubjects.Item("SMP", k).Value - imp & "',"
                For s As Integer = 0 To grades.Length - 1
                    query &= "'" & dgvSubjects.Item(grades(s).Substring(0, 1).ToString & s, k).Value & "'"
                    If s < grades.Length - 1 Then
                        query &= ","
                    End If
                Next
                query &= ")"
                If Not qwrite(query) Then
                    rollback()
                    failure("Results Analysis Could Not Be Saved!")
                    Exit Sub
                End If
            Next
            commit()
            success("Results Analaysis Successfully Saved!")
        End If
    End Sub
End Class