Imports System.Drawing.Printing
Public Class frmStudentProfile

    Private Sub frmStudentProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            create_dataform()
            show_record()
        End If
    End Sub
    Private Sub show_record()
        Dim frm As New frmAllStudentsPrompt
        frm.ShowDialog()
        If cont Then
            If qread("SELECT student_name, Class, Stream FROM students WHERE admin_no='" & t_id & "'") Then
                dbreader.Read()
                txtADMNo.Text = t_id
                txtName.Text = dbreader("student_name")
                class_form = dbreader("Class")
                stream = dbreader("Stream")
                ShowProfile()
            End If
        End If
    End Sub
    Private Sub txtADMNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtADMNo.Click, txtName.Click
        show_record()
    End Sub

    Private Sub ShowProfile()
        ProgressBar1.Visible = True
        dgvEnterMarks.Rows.Clear()
        qread("SELECT *, `examinations`.`Total` AS Totals FROM exam_results LEFT JOIN examinations ON (exam_results.Examination=examinations.ExamName) WHERE exam_results.Term=examinations.Term AND exam_results.Year=examinations.Year AND ADMNo='" & escape_string(txtADMNo.Text) & "' ORDER BY `id`")
        Dim inc As Integer
        If dbreader.RecordsAffected > 0 Then
            inc = 100 / dbreader.RecordsAffected
        Else
            inc = 100
        End If
        Dim out_of As Double
        While dbreader.Read
            dgvEnterMarks.Rows.Add()
            dgvEnterMarks.Item("Year", dgvEnterMarks.Rows.Count - 1).Value = dbreader("Year")
            dgvEnterMarks.Item("Term", dgvEnterMarks.Rows.Count - 1).Value = dbreader("Term")
            dgvEnterMarks.Item("Examination", dgvEnterMarks.Rows.Count - 1).Value = dbreader("Examination")
            Dim se As Integer = 0
            For k As Integer = 0 To subjname.Length - 1
                If IsNumeric(dbreader(subjname(k))) Then
                    out_of = SubjectOutOf(subjname(k), dbreader("Term"), dbreader("Year"), dbreader("Examination"), dbreader("Class"), dbreader("Stream"), 2)
                    dgvEnterMarks.Item(subjname(k).ToString, dgvEnterMarks.Rows.Count - 1).Value = Math.Round((dbreader(subjname(k)) / out_of) * 100, 0)
                Else
                    dgvEnterMarks.Item(subjname(k).ToString, dgvEnterMarks.Rows.Count - 1).Value = dbreader(subjname(k))
                End If
                If dbreader(subjname(k)).ToString <> "-" Then
                    se += 1
                End If
            Next
            dgvEnterMarks.Item("Sent", dgvEnterMarks.Rows.Count - 1).Value = se
            ProgressBar1.Increment(inc)
        End While
        ProgressBar1.Increment(-100)
        Dim grade As String
        get_grades()
        Dim curr_class As String = class_form
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            Dim tp As Double = 0
            Dim tmK As Double = 0
            tm = dgvEnterMarks.Item("Term", k).Value
            yr = dgvEnterMarks.Item("Year", k).Value
            Dim LIMIT As Integer = 0
            If yr <> Today.Year Then
                LIMIT = Today.Year - yr
                qread("SELECT `class` FROM `class_stream` WHERE `class` < '" & escape_string(class_form) & "' ORDER BY `class` DESC LIMIT " & LIMIT)
                If dbreader.RecordsAffected > 0 Then
                    dbreader.Read()
                    curr_class = dbreader("class")
                End If
            End If
            For s As Integer = 0 To subjname.Length - 1
                grade = Nothing
                If IsNumeric(dgvEnterMarks.Item(subjname(s).ToString, k).Value) Then
                    grade = get_grade(dgvEnterMarks.Item(subjname(s).ToString, k).Value, True, subjabb(s), curr_class)
                    tmK += dgvEnterMarks.Item(subjname(s).ToString, k).Value
                    dgvEnterMarks.Item(subjname(s).ToString, k).Value = dgvEnterMarks.Item(subjname(s).ToString, k).Value & " " & grade
                    tp += fix_point(grade)
                End If
            Next
            dgvEnterMarks.Item("TP", k).Value = tp
            dgvEnterMarks.Item("MP", k).Value = Format(tp / dgvEnterMarks.Item("Sent", dgvEnterMarks.Rows.Count - 1).Value, "0.00")
            dgvEnterMarks.Item("TM", k).Value = tmK
            dgvEnterMarks.Item("MM", k).Value = Format(tmK / dgvEnterMarks.Item("Sent", dgvEnterMarks.Rows.Count - 1).Value, "0.00")
            dgvEnterMarks.Item("MG", k).Value = get_points(dgvEnterMarks.Item("MP", k).Value)
            ProgressBar1.Increment(inc)
        Next
        ProgressBar1.Increment(-100)
        ProgressBar1.Visible = False
    End Sub
    Private Sub create_dataform()
        get_subjects()
        For k As Integer = 0 To subjabb.Length - 1
            Dim column As New DataGridViewColumn
            Dim cell As DataGridViewCell = New DataGridViewTextBoxCell
            With column
                .CellTemplate = cell
                .ReadOnly = True
                Try
                    .Name = subjname(k)
                    .HeaderText = remove_wild(subjabb(k).Substring(0, 3))
                Catch ex As Exception
                    .Name = subjname(k)
                    .HeaderText = remove_wild(subjabb(k).Substring(0, 2))
                End Try
                .Width = 55
            End With
            dgvEnterMarks.Columns.Add(column)
        Next
        Dim cellent As DataGridViewCell = New DataGridViewTextBoxCell
        Dim colent As New DataGridViewColumn
        With colent
            .CellTemplate = cellent
            .Name = "Sent"
            .HeaderText = "SE"
            .Width = 50
            .ReadOnly = True
        End With
        dgvEnterMarks.Columns.Add(colent)
        Dim celltp As DataGridViewCell = New DataGridViewTextBoxCell
        Dim coltp As New DataGridViewColumn
        With coltp
            .CellTemplate = celltp
            .Name = "TP"
            .HeaderText = "TP"
            .Width = 50
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgvEnterMarks.Columns.Add(coltp)
        Dim cellmp As DataGridViewCell = New DataGridViewTextBoxCell
        Dim colmp As New DataGridViewColumn
        With colmp
            .CellTemplate = cellmp
            .Name = "MP"
            .HeaderText = "MP"
            .Width = 50
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgvEnterMarks.Columns.Add(colmp)
        Dim cellmm As DataGridViewCell = New DataGridViewTextBoxCell
        Dim colmm As New DataGridViewColumn
        With colmm
            .CellTemplate = cellmm
            .Name = "MM"
            .HeaderText = "MM"
            .Width = 50
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgvEnterMarks.Columns.Add(colmm)
        Dim cellmg As DataGridViewCell = New DataGridViewTextBoxCell
        Dim colmg As New DataGridViewColumn
        With colmg
            .CellTemplate = cellmg
            .Name = "MG"
            .HeaderText = "MG"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        dgvEnterMarks.Columns.Add(colmg)
        Dim cell1 As DataGridViewCell = New DataGridViewTextBoxCell
        Dim column0 As New DataGridViewColumn
        With column0
            .CellTemplate = cell1
            .Name = "TM"
            .HeaderText = "TM"
            .Width = 60
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgvEnterMarks.Columns.Add(column0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report2()
        print_document.DefaultPageSettings.Landscape = True
        Print_Preview.Document = print_document
        Print_Preview.ShowDialog()
    End Sub
    Private Function print_student_report2()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report2
        Return print_document
    End Function
    Dim start_from As Integer = 0
    Private Sub print_report2(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.HasMorePages = False
        Dim line As Integer = 20
        Dim left_margin As Integer = 80
        Dim right_margin = 1050
        Dim count As Integer = 0
        Dim CenterPage As Single
        If start_from = 0 Then
            Try
                e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, line, 90, 90)
                line += 15
            Catch ex As Exception
            End Try
            line = 20
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
            line -= 5
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("STUDENT PROGRESS REPORT", header_font).Width / 2)
            e.Graphics.DrawString("STUDENT ACADEMIC PROFILE", header_font, Brushes.Black, CenterPage, line + 5)
            line += other_font.Height + 5
        End If
        line += 20

        e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)

        line += 10

        e.Graphics.DrawString("Admission No: " & txtADMNo.Text & "                 Name Of Student: " & txtName.Text & "                    Class: " & class_form & " " & stream, other_font, Brushes.Black, left_margin, line)

        line += other_font.Height + 5
        line += 10

        e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)

        line += 10

        For col As Integer = 0 To dgvEnterMarks.Columns.Count - 1
            If dgvEnterMarks.Columns(col).Visible Then
                If count = 1 Then
                    e.Graphics.DrawString(dgvEnterMarks.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
                Else
                    Try
                        e.Graphics.DrawString(dgvEnterMarks.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
                    Catch ex As Exception
                        e.Graphics.DrawString(dgvEnterMarks.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
                    End Try
                End If
                count += 1
                If count = 3 Then
                    left_margin += 100
                Else
                    left_margin += 35
                End If
            End If
        Next
        line += 10
        For row As Integer = start_from To dgvEnterMarks.Rows.Count - 1
            line += 2
            If line >= 806 And row < dgvEnterMarks.Rows.Count - 1 Then
                e.HasMorePages = True
                start_from = row
                Exit Sub
            End If
            left_margin = 80
            count = 0
            For col As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                If dgvEnterMarks.Columns(col).Visible Then
                    If count = 2 Then
                        If dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value.ToString.Length > 13 Then
                            e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value.ToString.Substring(0, 13), smallfont, Brushes.Black, left_margin, line + 2)
                        Else
                            e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                        End If
                    Else
                        e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                    End If
                    count += 1
                    If count = 3 Then
                        left_margin += 100
                    Else
                        left_margin += 35
                    End If
                End If
            Next
            line += 2
            e.Graphics.DrawLine(Pens.Black, 80, line, left_margin, line)
            line += 10
        Next
        line += 10
        If line + 100 + 20 * grades.Length + 1 >= 806 Then
            start_from = dgvEnterMarks.Rows.Count
            e.HasMorePages = True
            Exit Sub
        End If
        left_margin = 80
        line += 10
        Dim topline As Integer = line
        Dim npen As New Pen(Color.Silver, 1)
        npen.DashStyle = Drawing2D.DashStyle.DashDot
        For k As Integer = 0 To grades.Length - 1
            e.Graphics.DrawString(grades(k), other_font, Brushes.Black, left_margin, line - 8)
            e.Graphics.DrawLine(npen, left_margin + 20, line, right_margin, line)
            line += 20
        Next
        e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, left_margin + 20, topline)
        e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line)
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            Dim graphtop As Integer = topline
            For g As Integer = 0 To grades.Length - 1
                If dgvEnterMarks.Item("MG", k).Value = grades(g) Then
                    Dim rect = New Rectangle(left_margin + 20 + (k * 20), graphtop, 10, line - graphtop)
                    e.Graphics.FillRectangle(Brushes.Black, rect)
                Else
                    graphtop += 20
                End If
            Next
        Next
        line += 10
        e.Graphics.DrawString("   SE	= SUBJECT ENTRIES               STR = STREAM" & vbNewLine &
                              "   TP	= TOTAL POINTS                  MM  = MEAN MARKS" & vbNewLine &
                              "   MP	= MEAN POINTS					 " & vbNewLine &
                              "   TM	= TOTAL MARKS                   MG  = MEAN GRADE", other_font, Brushes.Black, left_margin, line)
        start_from = 0
    End Sub
End Class