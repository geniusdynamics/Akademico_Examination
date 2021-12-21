Imports System.Drawing.Printing
Public Class frmNationalExaminationsEntry
    Dim up_date As Boolean = False
    Private Sub frmNationalExaminationsEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            Dim frm As New frmNationalExaminationsEntryPrompt
            frm.ShowDialog()
            If cont Then
                get_subjects()
                create_form()
                'todo change the below code
                load_stream1(ComboBox1, "Form 4")
                ComboBox1.Items.Add("All")
                ComboBox1.SelectedItem = "All"
                load_data()
            Else
                ' Me.Close()
            End If
        End If
    End Sub

    Dim admnos()
    Private Sub load_data()
        dgvSubjects.Rows.Clear()
        If ComboBox1.SelectedItem = "All" Then
            query = "SELECT * FROM `kcse_results` WHERE year='" & yr & "' AND Examination='" & escape_string(exam_name) & "' ORDER BY id ASC"
        Else
            query = "SELECT * FROM `kcse_results` WHERE year='" & yr & "' AND Examination='" & escape_string(exam_name) & "' AND Stream='" & escape_string(ComboBox1.SelectedItem) & "' ORDER BY id ASC"
        End If
        If qread(query) Then
            If dbreader.RecordsAffected > 0 Then
                up_date = True
                btnSave.Text = "&Update"
                Dim count As Integer
                ReDim admnos(dbreader.RecordsAffected - 1)
                While dbreader.Read()
                    dgvSubjects.Rows.Add()
                    admnos(count) = dbreader("ADMNo")
                    For j As Integer = 0 To dgvSubjects.Columns.Count - 1
                        If j = 1 Then
                            dgvSubjects.Item(dgvSubjects.Columns(j).Name, count).Value = CInt(dbreader(dgvSubjects.Columns(j).Name))
                        Else
                            dgvSubjects.Item(dgvSubjects.Columns(j).Name, count).Value = dbreader(dgvSubjects.Columns(j).Name)
                        End If
                    Next
                    count += 1
                End While
            Else
                up_date = False
                qread("SELECT ADMNo, indexno, StudentName FROM alumni WHERE year=" & yr)
                While dbreader.Read
                    dgvSubjects.Rows.Add()
                    dgvSubjects.Item("ADMNo", dgvSubjects.Rows.Count - 2).Value = dbreader("ADMNo")
                    dgvSubjects.Item("IndexNo", dgvSubjects.Rows.Count - 2).Value = dbreader("indexno")
                    dgvSubjects.Item("StudentName", dgvSubjects.Rows.Count - 2).Value = dbreader("StudentName")
                End While
                btnSave.Text = "&Save"
            End If
        Else
            failure("Looks Like Your Installation Isn't Complete! Please Contact Your Software Vendor!")
        End If
        dgvSubjects.Sort(dgvSubjects.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
    End Sub
    Private Sub create_form()
        Dim col As New DataGridViewColumn
        Dim cel As DataGridViewCell = New DataGridViewTextBoxCell
        With col
            .ReadOnly = load_from_alumni
            .Name = "ADMNo"
            .HeaderText = "Adm. No."
            .CellTemplate = cel
            .Width = 50
        End With
        dgvSubjects.Columns.Add(col)
        Dim col0 As New DataGridViewColumn
        Dim cel0 As DataGridViewCell = New DataGridViewTextBoxCell
        With col0
            .ReadOnly = load_from_alumni
            .Name = "IndexNo"
            .HeaderText = "INDEX"
            .CellTemplate = cel0
            .SortMode = DataGridViewColumnSortMode.Automatic
            .Width = 80
        End With
        dgvSubjects.Columns.Add(col0)
        Dim col2 As New DataGridViewColumn
        Dim cel2 As DataGridViewCell = New DataGridViewTextBoxCell
        With col2
            .ReadOnly = load_from_alumni
            .Name = "StudentName"
            .HeaderText = "Name Of Student"
            .CellTemplate = cel2
            .Width = 150
        End With
        dgvSubjects.Columns.Add(col2)
        Dim col3 As New DataGridViewColumn
        Dim cel3 As DataGridViewCell = New DataGridViewTextBoxCell
        With col3
            .ReadOnly = load_from_alumni
            .Name = "Stream"
            .HeaderText = "STR"
            .CellTemplate = cel3
            .Width = 50
        End With
        dgvSubjects.Columns.Add(col3)
        For k As Integer = 0 To subjabb.Length - 1
            Dim column As New DataGridViewColumn
            Dim cell As DataGridViewCell = New DataGridViewTextBoxCell
            With column
                .CellTemplate = cell
                Try
                    .Name = subjname(k)
                    .HeaderText = subjabb(k).Substring(0, 3)
                Catch ex As Exception
                    .Name = subjname(k)
                    .HeaderText = subjabb(k).Substring(0, 2)
                End Try
                .Width = 45
            End With
            dgvSubjects.Columns.Add(column)
        Next
        Dim col5 As New DataGridViewColumn
        Dim cel5 As DataGridViewCell = New DataGridViewTextBoxCell
        With col5
            .ReadOnly = False
            .Name = "mg"
            .HeaderText = "MG"
            .CellTemplate = cel5
            .Width = 80
        End With
        dgvSubjects.Columns.Add(col5)
        Dim col4 As New DataGridViewColumn
        Dim cel4 As DataGridViewCell = New DataGridViewTextBoxCell
        With col4
            .ReadOnly = False
            .Name = "tp"
            .HeaderText = "TP"
            .CellTemplate = cel4
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.Automatic
        End With
        dgvSubjects.Columns.Add(col4)
    End Sub


    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If up_date Then
            start()
            For k As Integer = 0 To dgvSubjects.Rows.Count - 2
                If qread("SELECT ADMNo FROM `kcse_results` WHERE IndexNo='" & escape_string(dgvSubjects.Item("IndexNo", k).Value) & "'") Then
                    If dbreader.RecordsAffected > 0 Then
                        query = "UPDATE `kcse_results` SET"
                        For col As Integer = 1 To dgvSubjects.Columns.Count - 1
                            query &= "`" & dgvSubjects.Columns(col).Name & "`='" & escape_string(dgvSubjects.Item(dgvSubjects.Columns(col).Name, k).Value) & "'"
                            If col < dgvSubjects.Columns.Count - 1 Then
                                query &= ","
                            End If
                        Next
                        query &= " WHERE IndexNo='" & escape_string(dgvSubjects.Item("IndexNo", k).Value) & "' AND year='" & yr & "'"
                    Else
                        query = "INSERT INTO `kcse_results`("
                        For cnt As Integer = 0 To dgvSubjects.Columns.Count - 1
                            query &= "`" & dgvSubjects.Columns(cnt).Name & "`"
                            If cnt < dgvSubjects.Columns.Count - 1 Then
                                query &= ","
                            End If
                        Next
                        query &= ") VALUES(NULL,'" & escape_string(exam_name) & "'," & yr & ","
                        For j As Integer = 0 To dgvSubjects.Columns.Count - 1
                            query = query & "'" & escape_string(dgvSubjects.Item(dgvSubjects.Columns(j).Name, k).Value) & "'"
                            If j < dgvSubjects.Columns.Count - 1 Then
                                query = query & ", "
                            Else
                                query = query & ")"
                            End If
                        Next
                    End If
                End If
                If Not qwrite(query) Then
                    rollback()
                    failure("Could Not Save The Data")
                    Exit Sub
                End If
            Next
            commit()
            success("Examination Record Successfully Saved!")
            up_date = True
            btnSave.Text = "&Update"
        Else
            save_exam()
        End If
    End Sub

    Private Sub save_exam()
        Dim save_query As String = "INSERT INTO `kcse_results` VALUES"
        For k As Integer = 0 To dgvSubjects.Rows.Count - 3
            save_query &= "(NULL,'" & escape_string(exam_name) & "', " & yr & ","
            For j As Integer = 0 To dgvSubjects.Columns.Count - 1
                save_query = save_query & "'" & escape_string(dgvSubjects.Item(dgvSubjects.Columns(j).Name, k).Value) & "'"
                If j < dgvSubjects.Columns.Count - 1 Then
                    save_query = save_query & ", "
                Else
                    save_query = save_query & ")"
                End If
            Next
            If k < dgvSubjects.Rows.Count - 3 Then
                save_query &= ","
            End If
        Next
        If qwrite(save_query) Then
            success("Examination Record Successfully Saved!")
            up_date = True
            btnSave.Text = "&Update"
        Else
            failure("Examination Results Could NOt Be Saved!")
        End If
    End Sub
    Dim start_from As Integer = 0
    Private Sub print_report2(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.HasMorePages = False
        Dim line As Integer = 20
        Dim left_margin As Integer = 90
        Dim right_margin As Integer = 1050
        Dim count As Integer = 0
        If start_from = 0 Then
            Try
                e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, line, 90, 90)
                line += 15
            Catch ex As Exception
            End Try
            If S_NAME <> String.Empty Then
                e.Graphics.DrawString(S_NAME.ToUpper, header_font, Brushes.Black, left_margin + 180, line)
                line += header_font.Height + 2
            End If
            If S_ADDRESS <> String.Empty Then
                e.Graphics.DrawString("P.O. BOX " & S_ADDRESS.ToUpper & ", " & S_LOCATION.ToUpper, other_font, Brushes.Black, left_margin + 220, line)
                line += other_font.Height + 5
            End If
            If S_PHONE <> String.Empty Then
                e.Graphics.DrawString("TELEPHONE: " & S_PHONE, other_font, Brushes.Black, left_margin + 220, line)
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
            If ComboBox1.SelectedItem = "All" Then
                e.Graphics.DrawString("FORM 4 MERIT LIST FOR " & exam_name & " EXAM, TERM " & yr, other_font, Brushes.Black, left_margin + 180, line)
            Else
                e.Graphics.DrawString("FORM 4 " & ComboBox1.SelectedItem & " MERIT LIST FOR " & exam_name & " EXAM, TERM " & yr, other_font, Brushes.Black, left_margin + 180, line)
            End If
            line += other_font.Height + 5
        End If
        line += 10
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)
        line += 10
        e.Graphics.DrawString("S/N", smallfont, Brushes.Black, left_margin, line)
        left_margin += 30
        For col As Integer = 1 To dgvSubjects.Columns.Count - 1
            If dgvSubjects.Columns(col).Visible Then
                If count = 1 Then
                    e.Graphics.DrawString(dgvSubjects.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
                Else
                    Try
                        e.Graphics.DrawString(dgvSubjects.Columns(col).HeaderText.Substring(0, 3), smallfont, Brushes.Black, left_margin, line)
                    Catch ex As Exception
                        e.Graphics.DrawString(dgvSubjects.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
                    End Try
                End If
                count += 1
                If count = 2 Then
                    left_margin += 170
                Else
                    left_margin += 30
                End If
            End If
        Next
        line += 10
        For row As Integer = start_from To dgvSubjects.Rows.Count - 2
            line += 2
            If line >= 750 And row < dgvSubjects.Rows.Count - 1 Then
                e.HasMorePages = True
                start_from = row
                Exit Sub
            End If
            left_margin = 120
            e.Graphics.DrawString(row + 1, smallfont, Brushes.Black, left_margin - 30, line)
            count = 0
            For col As Integer = 1 To dgvSubjects.Columns.Count - 1
                If dgvSubjects.Columns(col).Visible Then
                    Try
                        e.Graphics.DrawString(dgvSubjects.Item(dgvSubjects.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                    Catch ex As Exception

                    End Try
                    count += 1
                    If count = 2 Then
                        left_margin += 170
                    Else
                        left_margin += 30
                    End If
                End If
            Next
            e.Graphics.DrawLine(Pens.Black, 90, line, left_margin, line)
            line += smallfont.Height
        Next
        line += 5
        If line + 60 >= 806 Then
            start_from = dgvSubjects.Rows.Count
            e.HasMorePages = True
            Exit Sub
        End If
        line += 20
        'Dim topline As Integer = line
        'For k As Integer = 0 To grades.Length - 1
        '    e.Graphics.DrawString(grades(k), other_font, Brushes.Black, left_margin, line - 8)
        '    e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin, line)
        '    line += 20
        'Next
        'e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin, line)
        'Dim graphtop As Integer = topline
        'left_margin += 30
        'For k As Integer = 0 To subjabb.Length - 1
        '    graphtop = topline
        '    For g As Integer = 0 To grades.Length - 1
        '        If dgvSubjects.Item(subjname(k).ToString, dgvSubjects.Rows.Count - 1).Value = grades(g) Then
        '            Dim rect = New Rectangle(left_margin + (k * 10), graphtop, 10, line - graphtop)
        '            e.Graphics.FillRectangle(Brushes.Silver, rect)
        '        Else
        '            graphtop += 20
        '        End If
        '    Next
        '    left_margin += 20
        'Next
        'line += 10
        'left_margin = 260
        'left_margin += 20
        'For k As Integer = 0 To subjabb.Length - 1
        '    Try
        '        e.Graphics.DrawString(subjabb(k).ToString.Substring(0, 3), smallfont, Brushes.Black, left_margin, line)
        '    Catch ex As Exception
        '        e.Graphics.DrawString(subjabb(k).ToString, smallfont, Brushes.Black, left_margin, line)
        '    End Try
        '    left_margin += 30
        'Next
        line += 30
        left_margin = 90
        e.Graphics.DrawString("   SE	= SUBJECT ENTRIES					STR 	= STREAM" & vbNewLine &
                              "   TP	= TOTAL POINTS					S.P		= STREAM POSITION" & vbNewLine &
                              "   MP	= MEAN POINTS					                 O.P    = OVERALL (CLASS) POSITION" & vbNewLine &
                              "   TM	= TOTAL MARKS					VAP     = VALUE ADDED PROGRESS (DEVIATION)", other_font, Brushes.Black, left_margin, line)
        start_from = 0
    End Sub
    Private Function print_student_report2()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report2
        Return print_document
    End Function
    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report2()
        print_document.DefaultPageSettings.Landscape = True
        Print_Preview.Document = print_document
        Print_Preview.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        load_data()
    End Sub
End Class