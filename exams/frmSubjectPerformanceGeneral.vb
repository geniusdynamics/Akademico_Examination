Imports System.Drawing.Printing
Public Class frmSubjectPerformanceGeneral

    Private Sub frmSubjectPerformanceGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Or Not get_subjects() Or Not dbNewOpen() Then
            Me.Close()
        Else
            get_grades()
            Button2.Enabled = False
            grpSelect.Enabled = True
            grpAnalyze.Enabled = False
            fill_years(cboYear)
            cboYear.SelectedItem = Today.Year
            get_term()
            cboTerm.SelectedItem = term
            chkBestOf7.Visible = Not IsPrimary()
            radSubject.Visible = chkBestOf7.Visible
            btnAddExam.Enabled = False
            txtContribution.Enabled = False
            grpMultiExaminations.Enabled = True
            mode = False
            analysis_mode = False
        End If

        Dim totalWidth As Integer = lstExaminations.Width
        lstExaminations.Columns(0).Width = totalWidth * (40 / 100)
        Dim colWidth As Integer = (totalWidth * (60 / 100)) / 4
        For k = 1 To lstExaminations.Columns.Count - 1
            lstExaminations.Columns(k).Width = colWidth
        Next

    End Sub
    Private Function isvalid()
        If cboYear.SelectedItem.ToString = None Then
            msg = "failure Choice For Year!"
            Return False
        ElseIf cboTerm.SelectedItem = None Then
            msg = "failure Choice For Term!"
            Return False
        ElseIf cboExamName.SelectedItem = None Then
            msg = "failure Choice For Examination Name!"
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub analyze()
        grpSelect.Enabled = False
        grpAnalyze.Enabled = True
        Button2.Enabled = True

    End Sub

    Private Sub btnAnalyze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyze.Click
        If isvalid() Then
            If chkMode.Checked Then
                ReDim yrs(lstExaminations.Items.Count - 1), tms(lstExaminations.Items.Count - 1), exam_names(lstExaminations.Items.Count - 1), contribution(lstExaminations.Items.Count - 1), total_mark(lstExaminations.Items.Count - 1)
                For k As Integer = 0 To lstExaminations.Items.Count - 1
                    exam_names(k) = lstExaminations.Items.Item(k).Text
                    contribution(k) = lstExaminations.Items.Item(k).SubItems(1).Text
                    yrs(k) = lstExaminations.Items.Item(k).SubItems(2).Text
                    tms(k) = lstExaminations.Items.Item(k).SubItems(3).Text

                    'todo I have set the total_mark to a constant 100 original code is below
                    ' total_mark(k) = 100

                    total_mark(k) = get_total_mark(exam_names(k), tms(k), yrs(k))
                Next
            Else
                yr = cboYear.SelectedItem
                tm = cboTerm.SelectedItem
            End If
            analyze()
        Else
            failure(msg)
        End If
    End Sub
    Private Sub get_details()
        tm = cboTerm.SelectedItem
        yr = cboYear.SelectedItem
        exam_name = cboExamName.SelectedItem

        marks = get_total_mark(cboExamName.SelectedItem, tm)
        'todo modified marks set it to a constant 100 the original code is commented above

        ' marks = 100
        table = "exam_results"
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        get_details()
        create_report2()
    End Sub
    Private Sub create_report2()
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = prepare_class_list2()
        printpreview.Document = print_document
        printpreview.ShowDialog()
        ' print_document.Print()
    End Sub
    Private Sub create_report3()
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = prepare_class_list3()
        printpreview.Document = print_document
        printpreview.ShowDialog()
        ' print_document.Print()
    End Sub
    Private Function prepare_class_list2()
        Dim print_document As New PrintDocument
        Dim margin As New Margins(10, 10, 10, 10)
        print_document.DefaultPageSettings.Landscape = False
        print_document.DefaultPageSettings.Margins = margin
        AddHandler print_document.PrintPage, AddressOf print_class_list2
        Return print_document
    End Function
    Private Function prepare_class_list3()
        Dim print_document As New PrintDocument
        Dim margin As New Margins(10, 10, 10, 10)
        print_document.DefaultPageSettings.Landscape = False
        print_document.DefaultPageSettings.Margins = margin
        AddHandler print_document.PrintPage, AddressOf print_class_list3
        Return print_document
    End Function
    Private Sub classes()
        If qread("SELECT distinct(class) as class FROM class_stream") Then
            ReDim words(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read()
                words(i) = dbreader("class")
                i += 1
            End While
            dbreader.Close()
        Else
            failure("Could Not Load Classes!")
        End If
    End Sub

    Private Sub fill_stream(ByVal str As String)
        If qread("SELECT stream FROM class_stream WHERE `class`='" & escape_string(str) & "'") Then
            ReDim streams(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read
                streams(i) = dbreader("stream")
                i += 1
            End While
            dbreader.Close()
        Else
            failure("Could Not Load Streams For Class " & str)
        End If
    End Sub

    Dim words() As String
    Dim mp, totalmp, totalentries, entries, total(), mm As Integer
    Private Sub genders()
        qread("SELECT DISTINCT Gender FROM students")
        ReDim sex(dbreader.RecordsAffected - 1)
        Dim i As Integer = 0
        While dbreader.Read
            sex(i) = dbreader("Gender")
            i += 1
        End While
    End Sub
    Dim sex() As String
    Private Sub print_class_list2(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
        Dim line As Integer = 30
        Dim topline As Integer = line
        Dim left_margin As Integer = 20
        Dim right_margin As Integer = 810
        Dim col As Integer = 50
        Try
            e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, line, 100, 100)
            line += 15
        Catch ex As Exception
        End Try

        'line + 20 uncommented
        line += 20
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
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("GENDER BASED PERFORMANCE ANALYSIS", other_font).Width / 2)
        e.Graphics.DrawString("GENDER BASED PERFORMANCE ANALYSIS", other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height + 5
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(exam_name & " Term " & cboTerm.SelectedItem & " " & cboYear.SelectedItem, other_font).Width / 2)
        e.Graphics.DrawString(exam_name & " Term " & cboTerm.SelectedItem & " " & cboYear.SelectedItem, other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height + 5
        classes()
        genders()
        wait("Complex Computation ...")
        For c As Integer = 0 To words.Length - 1
            fill_stream(words(c))
            For s As Integer = 0 To streams.Length - 1
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
                For count As Integer = 0 To sex.Length - 1
                    col = 103
                    For k As Integer = 0 To grades.Length - 1
                        e.Graphics.DrawString(gradeno(grades(k), sex(count), streams(s), words(c)), smallfont, Brushes.Black, left_margin + col + 4, line)
                        col += 35
                    Next
                    e.Graphics.DrawString(g_entry, smallfont, Brushes.Black, left_margin + col, line)
                    col += 50
                    Dim mean = mean_p("", sex(count), streams(s), words(c))
                    e.Graphics.DrawString(mean, smallfont, Brushes.Black, left_margin + col, line)
                    col += 50
                    Try
                        e.Graphics.DrawString(get_points(mean), smallfont, Brushes.Black, left_margin + col, line)
                    Catch ex As Exception
                        e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + col, line)
                    End Try
                    col += 50
                    mean = meanmark(sex(count), streams(s), words(c))
                    e.Graphics.DrawString(mean, smallfont, Brushes.Black, left_margin + col, line)
                    g_mp = 0
                    g_entry = 0
                    mean = 0
                    e.Graphics.DrawString(sex(count).Substring(0, 1), smallfont, Brushes.Black, left_margin + 10, line)
                    line += smallfont.Height + 2
                    e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
                    e.Graphics.DrawLine(Pens.Black, left_margin, topline, left_margin, line)
                Next
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
    Dim category() As String
    Private Sub categories()
        qread("SELECT studentcategory FROM studentCategory")
        ReDim category(dbreader.RecordsAffected - 1)
        Dim i As Integer = 0
        While dbreader.Read
            category(i) = dbreader("studentcategory")
            i += 1
        End While
    End Sub
    Private Sub print_class_list3(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
        Dim line As Integer = 30
        Dim topline As Integer = line
        Dim left_margin As Integer = 20
        Dim right_margin As Integer = 810
        Dim col As Integer = 50
        Try
            e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, line, 100, 100)
            line += 15
        Catch ex As Exception
        End Try
        line += 20
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
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("CATEGORICAL PERFORMANCE ANALYSIS", other_font).Width / 2)
        e.Graphics.DrawString("CATEGORICAL PERFORMANCE ANALYSIS", other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height + 5
        e.Graphics.DrawString(exam_name & " Term: " & cboTerm.SelectedItem & " " & cboYear.SelectedItem, other_font, Brushes.Black, left_margin + 150, line)
        line += other_font.Height + 5
        classes()
        categories()
        wait("Complex Computation ...")
        For c As Integer = 0 To words.Length - 1
            fill_stream(words(c))
            For s As Integer = 0 To streams.Length - 1
                wait("Computing " & words(c) & " " & streams(s) & "...")
                e.Graphics.DrawString(words(c).ToUpper & " " & streams(s), smallfont, Brushes.Black, left_margin, line)
                line += smallfont.Height + 2
                topline = line
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
                e.Graphics.DrawString("CATEGORY   ", smallfont, Brushes.Black, left_margin, line)
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
                For m As Integer = 0 To category.Length - 1
                    col = 103
                    For k As Integer = 0 To grades.Length - 1
                        e.Graphics.DrawString(gradeno(grades(k), category(m), streams(s), words(c)), smallfont, Brushes.Black, left_margin + col + 4, line)
                        col += 35
                    Next
                    e.Graphics.DrawString(g_entry, smallfont, Brushes.Black, left_margin + col, line)
                    col += 50
                    Dim mean = mean_p3("", category(m), streams(s), words(c))
                    e.Graphics.DrawString(mean, smallfont, Brushes.Black, left_margin + col, line)
                    col += 50
                    Try
                        e.Graphics.DrawString(get_points(mean), smallfont, Brushes.Black, left_margin + col, line)
                    Catch ex As Exception
                        e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + col, line)
                    End Try
                    col += 50
                    mean = meanmark3(category(m), streams(s), words(c))
                    e.Graphics.DrawString(mean, smallfont, Brushes.Black, left_margin + col, line)
                    g_mp = 0
                    g_entry = 0
                    mean = 0
                    e.Graphics.DrawString(category(m), smallfont, Brushes.Black, left_margin + 10, line)
                    line += smallfont.Height + 2
                    e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
                    e.Graphics.DrawLine(Pens.Black, left_margin, topline, left_margin, line)
                Next
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
    Private Function mean_p(ByVal grade As String, ByVal gender As String, ByVal s As String, ByVal cls As String)
        Dim all_grades() As String
        Dim admnos() As String
        Dim cnt As Integer = 0
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
        qread("SELECT * FROM `" & table & "` WHERE (Stream='" & escape_string(s) & "' AND class='" & escape_string(cls) & "' AND Term='" & tm & "' AND Year='" & yr & "' AND Examination='" & escape_string(exam_name) & "')")
        Dim i As Integer = 0
        ReDim all_grades(dbreader.RecordsAffected - 1), admnos(dbreader.RecordsAffected - 1)
        While dbreader.Read
            cnt = 0
            If IsNumeric(dbreader(sum)) Then
                admnos(i) = dbreader("ADMNo")
                For k As Integer = 0 To subjabb.Length - 1
                    If IsNumeric(dbreader(subjname(k))) Then
                        cnt += 1
                    End If
                Next
                If chkBestOf7.Checked Then
                    all_grades(i) = get_points(dbreader(sum) / 7)
                Else
                    all_grades(i) = get_points(dbreader(sum) / cnt)
                End If
                i += 1
            End If
        End While
        cnt = 0
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
    Private Function mean_p3(ByVal grade As String, ByVal gender As String, ByVal s As String, ByVal cls As String)
        Dim all_grades() As String
        Dim admnos() As String
        Dim cnt As Integer = 0
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
        qread("SELECT * FROM `" & table & "` WHERE (Stream='" & s & "' AND class='" & escape_string(cls) & "' AND Term='" & tm & "' AND Year='" & yr & "' AND Examination='" & escape_string(exam_name) & "')")
        Dim i As Integer = 0
        ReDim all_grades(dbreader.RecordsAffected - 1), admnos(dbreader.RecordsAffected - 1)

        While dbreader.Read
            cnt = 0
            If IsNumeric(dbreader(sum)) Then
                admnos(i) = dbreader("ADMNo")
                For k As Integer = 0 To subjabb.Length - 1
                    If IsNumeric(dbreader(subjname(k))) Then
                        cnt += 1
                    End If
                Next
                If chkBestOf7.Checked Then
                    all_grades(i) = get_points(dbreader(sum) / 7)
                Else
                    all_grades(i) = get_points(dbreader(sum) / cnt)
                End If
                i += 1
            End If
        End While
        dbreader.Close()
        cnt = 0
        For k As Integer = 0 To admnos.Length - 1
            If isgender3(admnos(k), gender) Then
                g_mp += fix_point(all_grades(k))
                cnt += 1
            End If
        Next
        If cnt = 0 Then
            Return "--"
        Else
            Return Format(g_mp / cnt, "0.00")
        End If
    End Function
    Private Function meanmark3(ByVal gender As String, ByVal s As String, ByVal cls As String)
        Dim admnos() As String
        Dim cnt As Integer
        If chkBestOf7.Checked Then
            sum = "B7_Total"
        Else
            sum = "Total"
        End If
        qread("SELECT `" & sum & "`, `ADMNo` FROM `" & table & "` WHERE (Stream='" & s & "' AND class='" & escape_string(cls) & "' AND Term='" & tm & "' AND Year='" & yr & "' AND Examination='" & escape_string(exam_name) & "')")
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
            If isgender3(admnos(k), gender) Then
                g_mp += totals(k)
                cnt += 1
            End If
        Next
        If g_mp = 0 Or cnt = 0 Then
            Return "--"
        Else
            Return Format(g_mp / cnt, "0.00")
        End If
    End Function
    Private Function meanmark(ByVal gender As String, ByVal s As String, ByVal cls As String)
        Dim admnos() As String
        Dim cnt As Integer
        If chkBestOf7.Checked Then
            sum = "B7_Total"
        Else
            sum = "Total"
        End If
        qread("SELECT `" & sum & "`, `ADMNo` FROM `" & table & "` WHERE (Stream='" & s & "' AND class='" & escape_string(cls) & "' AND Term='" & tm & "' AND Year='" & yr & "' AND Examination='" & escape_string(exam_name) & "')")
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
        If g_mp = 0 Or cnt = 0 Then
            Return "--"
        Else
            Return Format(g_mp / cnt, "0.00")
        End If
    End Function
    Dim g_entry, g_mp, totals() As Integer
    Dim sum As String
    Private Function gradeno(ByVal grade As String, ByVal gender As String, ByVal s As String, ByVal cls As String)
        Dim all_grades() As String
        Dim admnos() As String
        gradeno = 0
        If gender.ToLower <> "male" And gender.ToLower <> "female" Then
            If Not mode Then
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
                qread("SELECT * FROM `" & table & "` WHERE (Stream='" & escape_string(s) & "' AND class='" & escape_string(cls) & "' AND Term='" & tm & "' AND Year='" & yr & "' AND Examination='" & escape_string(exam_name) & "')")
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
                For k As Integer = 0 To admnos.Length - 1
                    If isgender3(admnos(k), gender) Then
                        If all_grades(k) = grade Then
                            gradeno += 1
                            g_entry += 1
                        End If
                    End If
                Next
                Return gradeno
            Else
                Dim largest_table As String = LargestTable(cls)
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
                Dim studs(large - 1)()
                For k As Integer = 0 To exam_names.Length - 1
                    If exam_names(k) = largest_table Then
                        qread("SELECT ADMNo, `" & sum & "` FROM `exam_results` WHERE (Stream='" & escape_string(s) & "' AND Examination='" & escape_string(exam_names(k)) & "' AND Class='" & escape_string(cls) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "');")
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
                    qread("SELECT * FROM `exam_results` WHERE (Stream='" & escape_string(s) & "' AND Examination='" & escape_string(exam_names(k)) & "' AND Class='" & escape_string(cls) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "');")
                    While dbreader.Read
                        For c As Integer = 0 To studs.Length - 1
                            If studs(c)(0) = dbreader("ADMNo") Then
                                If k > 0 Then
                                    studs(c)(1) += dbreader(sum)
                                Else
                                    studs(c)(1) = dbreader(sum)
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
                        If chkBestOf7.Checked Then
                            studs(k)(1) = get_points(studs(k)(1) / 7)
                        Else
                            studs(k)(1) = get_points(studs(k)(1) / studs(k)(2))
                        End If
                    End If
                Next
                For k As Integer = 0 To studs.Length - 1
                    If isgender3(studs(k)(0), gender) Then
                        'todo added a try catch statement here at times studs(k)(1) evaluates to a number
                        Try
                            If studs(k)(1) = grade Then
                                gradeno += 1
                                g_entry += 1
                            End If
                        Catch ex As Exception

                        End Try

                    End If
                Next
                Return gradeno
            End If
        Else
            If Not mode Then
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
                qread("SELECT * FROM `" & table & "` WHERE (Stream='" & escape_string(s) & "' AND class='" & escape_string(cls) & "' AND Term='" & tm & "' AND Year='" & yr & "' AND Examination='" & escape_string(exam_name) & "')")
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
                For k As Integer = 0 To admnos.Length - 1
                    If isgender(admnos(k), gender) Then
                        If all_grades(k) = grade Then
                            gradeno += 1
                            g_entry += 1
                        End If
                    End If
                Next
                Return gradeno
            Else
                Dim largest_table As String = LargestTable(cls)
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
                Dim studs(large - 1)()
                For k As Integer = 0 To exam_names.Length - 1
                    If exam_names(k) = largest_table Then
                        qread("SELECT ADMNo, `" & sum & "` FROM `exam_results` WHERE (Stream='" & escape_string(s) & "' AND Examination='" & escape_string(exam_names(k)) & "' AND Class='" & escape_string(cls) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "');")
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
                    qread("SELECT * FROM `exam_results` WHERE (Stream='" & escape_string(s) & "' AND Examination='" & escape_string(exam_names(k)) & "' AND Class='" & escape_string(cls) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "');")
                    While dbreader.Read
                        For c As Integer = 0 To studs.Length - 1
                            If studs(c)(0) = dbreader("ADMNo") Then
                                If k > 0 Then
                                    studs(c)(1) += dbreader(sum)
                                Else
                                    studs(c)(1) = dbreader(sum)
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
                        If chkBestOf7.Checked Then
                            studs(k)(1) = get_points(studs(k)(1) / 7)
                        Else
                            studs(k)(1) = get_points(studs(k)(1) / studs(k)(2))
                        End If
                    End If
                Next
                For k As Integer = 0 To studs.Length - 1
                    Try
                        If isgender(studs(k)(0), gender) Then
                            If studs(k)(1) = grade Then
                                gradeno += 1
                                g_entry += 1
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                Next
                Return gradeno
            End If
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
    Private Function isgender3(ByVal adm As String, ByVal gender As String)
        qread("SELECT * FROM students WHERE admin_no='" & adm & "' AND student_category='" & gender & "'")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Close()
            Return True
        Else
            dbreader.Close()
            Return False
        End If
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        get_details()
        create_report()
    End Sub

    Private Sub create_report()
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = prepare_class_list()
        printpreview.Document = print_document
        printpreview.ShowDialog()
        'Me.Close()
    End Sub
    Private Function prepare_class_list()
        Dim print_document As New PrintDocument
        Dim margin As New Margins(10, 10, 10, 10)
        print_document.DefaultPageSettings.Landscape = False
        print_document.DefaultPageSettings.Margins = margin
        AddHandler print_document.PrintPage, AddressOf print_class_list
        Return print_document
    End Function
    Private Sub print_class_list(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim line As Integer = 20
        Dim topline As Integer = line
        Dim left_margin As Integer = 120
        Dim right_margin As Integer = 800
        Dim col As Integer = 50
        Try
            e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, line, 100, 100)
            line += 15
        Catch ex As Exception
        End Try
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
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("CLASS MEAN GRADE COUNT ANALYSIS", other_font).Width / 2)
        e.Graphics.DrawString("CLASS MEAN GRADE COUNT ANALYSIS", other_font, Brushes.Black, CenterPage, line)
        line += other_font.Height + 5
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(exam_name & " Term " & cboTerm.SelectedItem & " " & cboYear.SelectedItem, other_font).Width / 2)
        e.Graphics.DrawString(exam_name & " Term " & cboTerm.SelectedItem & " " & cboYear.SelectedItem, other_font, Brushes.Black, left_margin + 150, line)
        line += 30
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
            e.Graphics.DrawLine(Pens.Black, 60, line, right_margin, line)
            e.Graphics.DrawString(words(c).ToUpper, smallfont, Brushes.Black, 60, line)
            topline = line - 20
            left_margin = 60
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
            fill_stream(words(c))
            Dim column As Integer
            For s As Integer = 0 To streams.Length - 1
                wait("Computing " & words(c) & " " & streams(s) & "...")
                totalentries += entries
                entries = 0
                column = 73
                totalmp += mp
                mp = 0
                e.Graphics.DrawString(streams(s).ToUpper, smallfont, Brushes.Black, left_margin, line)
                For k As Integer = 0 To grades.Length - 1
                    cnt = no_of_grades(grades(k), streams(s), words(c))
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
                column += 70
                e.Graphics.DrawString(mean_mark(streams(s), words(c)), smallfont, Brushes.Black, left_margin + column, line)
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
            If totalmp = 0 Or totalentries = 0 Then
                e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
                column += 60
                e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + column, line)
            Else
                e.Graphics.DrawString(Format(totalmp / totalentries, "0.00"), smallfont, Brushes.Black, left_margin + column, line)
                column += 60
                e.Graphics.DrawString(get_points(totalmp / totalentries), smallfont, Brushes.Black, left_margin + column, line)
            End If
            column += 70
            e.Graphics.DrawString(mean_mark_total(words(c)), smallfont, Brushes.Black, left_margin + column, line)
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

    Private Function mean_mark_total(ByVal cls As String)
        mm = 0
        If chkBestOf7.Checked Then
            sum = "B7_Total"
        Else
            sum = "Total"
        End If
        qread("SELECT `" & sum & "` FROM `" & table & "` WHERE (Examination='" & escape_string(exam_name) & "' AND class='" & escape_string(cls) & "' AND Term='" & tm & "' AND Year='" & yr & "')")
        Dim cnt As Integer
        While dbreader.Read
            If dbreader(sum) <> 0 Then
                mm += dbreader(sum)
                cnt += 1
            End If
        End While
        If cnt = 0 Or mm = 0 Then
            Return "--"
        Else
            Return Format(mm / cnt, "0.00")
        End If
    End Function
    Private Function mean_mark(ByVal s As String, ByVal cls As String)
        mm = 0
        If chkBestOf7.Checked Then
            sum = "B7_Total"
        Else
            sum = "Total"
        End If
        qread("SELECT `" & sum & "` FROM `" & table & "` WHERE (Stream='" & s & "' AND class='" & escape_string(cls) & "' AND Examination='" & escape_string(exam_name) & "' AND Term='" & tm & "' AND Year='" & yr & "')")
        Dim cnt As Integer
        While dbreader.Read
            If dbreader(sum) <> 0 Then
                mm += dbreader(sum)
                cnt += 1
            End If
        End While
        If cnt = 0 Or mm = 0 Then
            Return "--"
        Else
            Return Format(mm / cnt, "0.00")
        End If
    End Function

    Private Function no_of_grades(ByVal grade As String, ByVal stream As String, ByVal cls As String) As Integer
        Dim all_grades() As String
        no_of_grades = 0
        If Not mode Then
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
            qread("SELECT * FROM `" & table & "` WHERE (Stream='" & stream & "' AND class='" & cls & "' AND Examination='" & escape_string(exam_name) & "' AND Term='" & tm & "' AND Year='" & yr & "')")
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
        Else
            Dim largest_table As String = LargestTable(cls)
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
            Dim studs(large - 1)()
            For k As Integer = 0 To exam_names.Length - 1
                If exam_names(k) = largest_table Then
                    qread("SELECT ADMNo, `" & sum & "` FROM `exam_results` WHERE (Stream='" & escape_string(stream) & "' AND Examination='" & escape_string(exam_names(k)) & "' AND Class='" & escape_string(cls) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "');")
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
                                studs(c)(1) += dbreader(sum)
                            Else
                                studs(c)(1) = dbreader(sum)
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
                    If chkBestOf7.Checked Then
                        studs(k)(1) = get_points(studs(k)(1) / 7)
                    Else
                        studs(k)(1) = get_points(studs(k)(1) / studs(k)(2))
                    End If
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
    Private Function form_name(ByVal str As String)
        Dim fname As String() = str.Split("_")
        Return fname(1)
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        denalyze()
    End Sub
    Private Sub denalyze()
        grpSelect.Enabled = True
        grpAnalyze.Enabled = False
        mode = False
    End Sub

    Private Sub cboTerm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTerm.SelectedIndexChanged
        If cboTerm.SelectedItem <> None And cboYear.SelectedItem.ToString <> None Then
            fill_exam()
        Else
            cboExamName.Items.Clear()
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

    Private Sub btnMeanMarkAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeanMarkAnalysis.Click
        grading = radSubject.Checked
        tm = cboTerm.SelectedItem
        yr = cboYear.SelectedItem
        exam_name = cboExamName.SelectedItem
        get_details()
        Dim frm As New frmDepartmentalSubjectAnalysis
        frm.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        get_details()
        create_report3()
    End Sub

    Private Sub btnAddExam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddExam.Click
        add_exam()
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

    Private Sub chkMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMode.CheckedChanged
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

    Private Sub cboExamName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExamName.SelectedIndexChanged
        txtContribution.Clear()
        txtContribution.Focus()
    End Sub

    Private Sub txtContribution_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContribution.KeyPress
        If Asc(e.KeyChar()) = 13 Then
            add_exam()
        End If
    End Sub
End Class