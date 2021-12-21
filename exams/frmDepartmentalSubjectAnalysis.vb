Imports System.Drawing.Printing
Public Class frmDepartmentalSubjectAnalysis
    Dim words(), streams() As String
    Dim entries As Integer
    Private Sub frmSubjectRank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() And dbNewOpen() Then
            Me.Close()
        Else
            cboSubject.Items.Add(None)
            For k As Integer = 0 To subjabb.Length - 1
                cboSubject.Items.Add(subjabb(k))
            Next
            cboSubject.SelectedItem = None
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        rank = False
        Me.Close()
    End Sub

    Private Sub btnAnalyze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyze.Click
        If cboSubject.SelectedItem <> None Then
            rank = True
            subject = get_subject_name(cboSubject.SelectedItem)
            create_report()
        Else
            failure("Please Select A Subject To Analyze!")
        End If
    End Sub

    Private Sub create_report()
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = prepare_class_list()
        printpreview.Document = print_document
        printpreview.ShowDialog()
        ' print_document.Print()
    End Sub
    Private Function prepare_class_list()
        Dim print_document As New PrintDocument
        Dim margin As New Margins(10, 10, 10, 10)
        print_document.DefaultPageSettings.Landscape = False
        print_document.DefaultPageSettings.Margins = margin
        AddHandler print_document.PrintPage, AddressOf print_class_list
        Return print_document
    End Function
    Dim mp, total(), totalmp, totalentries As Integer
    Private Sub print_class_list(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim line As Integer = 20
        Dim topline As Integer = line
        Dim left_margin As Integer = 50
        Dim right_margin As Integer = 800
        Dim col As Integer = 50
        Try
            e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, line, 100, 100)
            line += 15
        Catch ex As Exception
        End Try

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
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("DEPARTMENTAL SUBJECT ANALYSIS", other_font).Width / 2)
        e.Graphics.DrawString("DEPARTMENTAL SUBJECT ANALYSIS", other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height + 5
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(exam_name & "  TERM " & term & "  " & yr, other_font).Width / 2)
        e.Graphics.DrawString(exam_name & "  TERM " & term & "  " & yr, other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height + 5
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(subject.ToUpper & " DEPARTMENT ", other_font).Width / 2)
        e.Graphics.DrawString(subject.ToUpper & " DEPARTMENT ", other_font, Brushes.Black, CenterPage, line)
        line += 25
        classes()
        ReDim total(grades.Length - 1)
        Dim cnt As Integer
        wait("Complex Computation ...")
        For c As Integer = 0 To words.Length - 1
            class_form = words(c)
            totalentries = 0
            entries = 0
            totalmp = 0
            mp = 0
            For k As Integer = 0 To grades.Length - 1
                total(k) = 0
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line)
            e.Graphics.DrawString("FORM", smallfont, Brushes.Black, left_margin + 20, line)
            topline = line - 10
            left_margin = 50
            col = 150
            For k As Integer = 0 To grades.Length - 1
                e.Graphics.DrawString(grades(k), smallfont, Brushes.Black, left_margin + col, line)
                col += 30
            Next
            e.Graphics.DrawString("ENTRY", smallfont, Brushes.Black, left_margin + col, line)
            col += 50
            e.Graphics.DrawString("M.P.", smallfont, Brushes.Black, left_margin + col, line)
            col += 60
            e.Graphics.DrawString("M. GRADE", smallfont, Brushes.Black, left_margin + col, line)
            line += 15
            e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line)
            fill_stream(words(c))
            Dim column As Integer = 103
            For s As Integer = 0 To streams.Length - 1
                wait("Computing " & words(c) & " " & streams(s) & "...")
                totalentries += entries
                entries = 0
                column = 150
                totalmp += mp
                mp = 0
                e.Graphics.DrawString(words(c).ToUpper & " " & streams(s).ToUpper, smallfont, Brushes.Black, left_margin + 20, line)
                For k As Integer = 0 To grades.Length - 1
                    cnt = no_of_grades(grades(k), words(c), streams(s))
                    total(k) += cnt
                    e.Graphics.DrawString(cnt, smallfont, Brushes.Black, left_margin + column, line)
                    column += 30
                Next
                e.Graphics.DrawString(entries, smallfont, Brushes.Black, left_margin + column, line)
                column += 50
                If entries = 0 Or mp = 0 Then
                    e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
                    column += 60
                    e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
                Else
                    e.Graphics.DrawString(Format(mp / entries, "0.00"), smallfont, Brushes.Black, left_margin + column, line)
                    column += 60
                    e.Graphics.DrawString(get_points(mp / entries), smallfont, Brushes.Black, left_margin + column, line)
                End If
                line += 15
                e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line)
                If s = streams.Length - 1 Then
                    totalmp += mp
                    totalentries += entries
                End If
            Next
            e.Graphics.DrawString("TOTAL", smallfont, Brushes.Black, left_margin + 20, line)
            column = 150
            For k As Integer = 0 To grades.Length - 1
                e.Graphics.DrawString(total(k), smallfont, Brushes.Black, left_margin + column, line)
                column += 30
            Next
            e.Graphics.DrawString(totalentries, smallfont, Brushes.Black, left_margin + column, line)
            column += 50
            If totalmp = 0 Or totalentries = 0 Then
                e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
                column += 60
                e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
            Else
                e.Graphics.DrawString(Format(totalmp / totalentries, "0.00"), smallfont, Brushes.Black, left_margin + column, line)
                column += 60
                e.Graphics.DrawString(get_points(totalmp / totalentries), smallfont, Brushes.Black, left_margin + column, line)
            End If
            line += 15
            e.Graphics.DrawLine(Pens.Black, left_margin + 20, line - 2, right_margin, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 20, topline + smallfont.Height - 2, left_margin + 20, line)
            col = 150
            For k As Integer = 0 To grades.Length - 1
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height - 2, left_margin + col - 4, line)
                col += 30
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height - 2, left_margin + col - 4, line)
            col += 50
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height - 2, left_margin + col - 4, line)
            col += 60
            e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + smallfont.Height - 2, left_margin + col - 4, line)
            e.Graphics.DrawLine(Pens.Black, right_margin, topline + smallfont.Height - 2, right_margin, line)
            line += 20
        Next
    End Sub

    Private Function no_of_grades(ByVal grade As String, ByVal cls As String, ByVal stream As String) As Integer
        Dim all_grades() As String
        no_of_grades = 0
        Dim subj As String = ret_subject_name(subject)
        If Not mode Then
            qread("SELECT `" & subj & "` FROM `" & table & "` WHERE (Class='" & escape_string(cls) & "' AND Stream='" & stream & "')")
            Dim i As Integer = 0
            ReDim all_grades(dbreader.RecordsAffected - 1)
            Dim val As String = ret_subject_name(subject)
            While dbreader.Read
                If IsNumeric(dbreader(val)) Then
                    all_grades(i) = get_grade((dbreader(val) / marks) * 100, grading, val)
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
        Else
            Dim largest_table As String = LargestTable(cls)
            Dim studs(large - 1)()
            For k As Integer = 0 To exam_names.Length - 1
                If exam_names(k) = largest_table Then
                    qread("SELECT ADMNo, `" & subj & "` FROM `exam_results` WHERE (Stream='" & escape_string(stream) & "' AND Examination='" & escape_string(exam_names(k)) & "' AND Class='" & escape_string(cls) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "');")
                    ReDim studs(dbreader.RecordsAffected - 1)(2)
                    For k1 As Integer = 0 To studs.Length - 1
                        ReDim studs(k1)(2)
                        For c As Integer = 0 To studs(k1).Length - 1
                            studs(k1)(c) = 0
                        Next
                    Next
                    Dim i As Integer = 0
                    While dbreader.Read
                        studs(i)(0) = dbreader("ADMNo")
                        i += 1
                    End While
                    Exit For
                End If
            Next
            For k As Integer = 0 To exam_names.Length - 1
                qread("SELECT * FROM `exam_results` WHERE (Stream='" & escape_string(stream) & "' AND Examination='" & escape_string(exam_names(k)) & "' AND Class='" & escape_string(cls) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "');")
                While dbreader.Read
                    For c As Integer = 0 To studs.Length - 1
                        If studs(c)(0) = dbreader("ADMNo") Then
                            If k > 0 Then
                                If IsNumeric(dbreader(subj).ToString()) Then
                                    studs(c)(1) += (dbreader(subj) / total_mark(k)) * contribution(k)
                                End If
                            Else
                                If IsNumeric(dbreader(subj).ToString()) Then
                                    studs(c)(1) = (dbreader(subj) / total_mark(k)) * contribution(k)
                                End If
                            End If
                            For st As Integer = 0 To subjabb.Length - 1
                                If IsNumeric(dbreader(subjname(st))) Then
                                    studs(c)(2) += 1
                                End If
                            Next
                            Exit For
                        End If
                    Next
                End While
            Next
            For k As Integer = 0 To studs.Length - 1
                If studs(k)(1) > 0 Then
                    studs(k)(1) = get_grade(studs(k)(1), grading, subj)
                End If
            Next
            For k As Integer = 0 To studs.Length - 1
                If studs(k)(1).ToString = grade Then
                    no_of_grades += 1
                End If
            Next
            entries += no_of_grades
            mp += no_of_grades * fix_point(grade)
            Return no_of_grades
        End If
    End Function

    Dim large As Integer = 0
    Private Function LargestTable(ByVal cls As String) As String
        LargestTable = Nothing
        large = Nothing
        For k As Integer = 0 To exam_names.Length - 1
            qread("SELECT id FROM exam_results WHERE (class='" & escape_string(cls) & "' AND Examination='" & escape_string(exam_names(k)) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "')")
            If dbreader.RecordsAffected > large Then
                large = dbreader.RecordsAffected
                LargestTable = exam_names(k)
            End If
        Next
        Return LargestTable
    End Function
    Private Function form_name(ByVal str As String)
        Dim fname As String() = str.Split("_")
        Return fname(1)
    End Function
    Private Sub classes()
        If qread("SELECT distinct class FROM class_stream") Then
            ReDim words(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read
                words(i) = dbreader("class")
                i += 1
            End While
        Else
            failure("Could Not Load Classes That Do/Have Done The Examinations!")
        End If
    End Sub

    Private Sub fill_class(ByVal str As String)
        str.ToCharArray()
        Dim i, j As Integer
        j = 0
        Dim in_word As Boolean = False
        For i = 0 To str.Length - 1
            If str(i) = "=" And in_word Then
                j += 1
                in_word = False
            ElseIf str(i) <> "=" And Not in_word Then
                in_word = True
            End If
        Next
        ReDim words(j - 1)
        j = 0
        in_word = False
        Dim temp As String = String.Empty
        For i = 0 To str.Length - 1
            If str(i) <> "=" Then
                If Not in_word Then
                    in_word = True
                End If
                temp += str(i)
            ElseIf str(i) = "=" Then
                If in_word Then
                    in_word = False
                    words(j) = temp
                    temp = String.Empty
                    j += 1
                End If
            ElseIf i = str.Length - 1 Then
                temp += str(i)
                words(j) = temp
            End If
        Next
    End Sub
    Private Function get_stream(ByVal field As String)
        If qread("SELECT `" & field & "` FROM school_details") Then
            dbreader.Read()
            field = dbreader(field)
            dbreader.Close()
            Return field
        Else
            failure("Could Not Read From School Database!")
            Return False
            Exit Function
        End If
    End Function
    Private Sub fill_stream(ByVal str As String)
        qread("SELECT stream FROM class_stream WHERE class='" & str & "'")
        ReDim streams(dbreader.RecordsAffected - 1)
        Dim i As Integer = 0
        While dbreader.Read
            streams(i) = dbreader("stream")
            i += 1
        End While
    End Sub
End Class