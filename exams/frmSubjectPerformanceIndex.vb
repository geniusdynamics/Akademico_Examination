Imports System.Drawing.Printing
Public Class frmSubjectPerformanceIndex

    Private Sub frmMostImproved_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            fill_years(cboYear)
            fill_years(cboYear1)
            cboYear.SelectedItem = Today.Year
            cboYear1.SelectedItem = Today.Year
            get_term()
            cboTerm.SelectedItem = term
            cboTerm1.SelectedItem = term
            load_class(cboClass)
            If IsPrimary() Then
                radSubject.Visible = False
            End If
        End If
    End Sub

    Private Sub cboTerm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTerm.SelectedIndexChanged
        If cboTerm.SelectedItem <> Nothing And cboYear.SelectedItem <> Nothing Then
            fill_exam(cboTerm.SelectedItem, cboYear.SelectedItem, cboExamName)
        End If
    End Sub

    Private Sub fill_exam(ByVal term As String, ByVal year As Integer, ByRef cbo As ComboBox)
        If qread("SELECT ExamName FROM examinations WHERE Term='" & term & "' AND Year='" & year & "'") Then
            cbo.Items.Clear()
            While dbreader.Read
                cbo.Items.Add(dbreader("ExamName"))
            End While
        Else
            failure("Could Not Load Examinations!")
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        If cboTerm.SelectedItem <> Nothing And cboYear.SelectedItem <> Nothing Then
            fill_exam(cboTerm.SelectedItem, cboYear.SelectedItem, cboExamName)
        End If
    End Sub

    Private Sub cboYear1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear1.SelectedIndexChanged
        If cboTerm1.SelectedItem <> Nothing And cboYear1.SelectedItem <> Nothing Then
            fill_exam(cboTerm1.SelectedItem, cboYear1.SelectedItem, cboExamName1)
        End If
    End Sub

    Private Sub cboTerm1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTerm1.SelectedIndexChanged
        If cboTerm1.SelectedItem <> Nothing And cboYear1.SelectedItem <> Nothing Then
            fill_exam(cboTerm1.SelectedItem, cboYear1.SelectedItem, cboExamName1)
        End If
    End Sub

    Private Function print_student_report2()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report2
        Return print_document
    End Function
    Private Sub print_report2(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.HasMorePages = False
        Dim line As Integer = 30
        Dim CenterPage As Single
        Dim left_margin As Integer = 20
        Dim right_margin As Single = 800
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
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("SUBJECT PERFORMANCE INDEX", header_font).Width / 2)
        e.Graphics.DrawString("SUBJECT PERFORMANCE INDEX", header_font, Brushes.Black, CenterPage, line)
        line += other_font.Height + 10
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)
        line += 2

        Dim subjs(subjabb.Length - 1)()

        For k As Integer = 0 To subjs.Length - 1
            ReDim subjs(k)(4)
            For c As Integer = 0 To subjs(k).Length - 1
                subjs(k)(c) = Nothing
            Next
        Next
        yr = cboYear1.SelectedItem
        tm = cboTerm1.SelectedItem
        class_form = cboClass.SelectedItem
        Dim cnt As Integer = 0
        Dim total_marks, tp As Double
        For k As Integer = 0 To subjabb.Length - 1
            cnt = 0
            tp = 0
            qread("SELECT `" & subjname(k) & "`, Stream FROM exam_results WHERE (Examination='" & escape_string(cboExamName1.SelectedItem) & "' AND Term='" & escape_string(cboTerm1.SelectedItem) & "' AND Year='" & escape_string(cboYear1.SelectedItem) & "' AND Class='" & escape_string(cboClass.SelectedItem) & "' AND `" & subjname(k) & "` REGEXP '[0-9]+')")
            While dbreader.Read
                total_marks = SubjectOutOf(subjname(k), cboTerm.SelectedItem, cboYear.SelectedItem, cboExamName.SelectedItem, cboClass.SelectedItem, dbreader("Stream"), 2)
                tp += fix_point(get_grade((dbreader(subjname(k)) / total_marks) * 100, radSubject.Checked, subjabb(k)))
                cnt += 1
            End While
            subjs(k)(0) = subjabb(k)
            subjs(k)(1) = subjects(k)
            subjs(k)(2) = tp / cnt
            subjs(k)(3) = subjs(k)(2)
        Next
        yr = cboYear.SelectedItem
        tm = cboTerm.SelectedItem
        cnt = 0
        tp = 0
        For k As Integer = 0 To subjabb.Length - 1
            cnt = 0
            tp = 0
            qread("SELECT `" & subjname(k) & "`, Stream FROM exam_results WHERE (Examination='" & escape_string(cboExamName.SelectedItem) & "' AND Term='" & escape_string(cboTerm.SelectedItem) & "' AND Year='" & escape_string(cboYear.SelectedItem) & "' AND Class='" & escape_string(cboClass.SelectedItem) & "' AND `" & subjname(k) & "` REGEXP '[0-9]+')")
            While dbreader.Read
                total_marks = SubjectOutOf(subjname(k), cboTerm.SelectedItem, cboYear.SelectedItem, cboExamName.SelectedItem, cboClass.SelectedItem, dbreader("Stream"), 2)
                tp += fix_point(get_grade((dbreader(subjname(k)) / total_marks) * 100, radSubject.Checked, subjabb(k)))
                cnt += 1
            End While
            subjs(k)(2) = subjs(k)(2) - (tp / cnt)
            subjs(k)(4) = tp / cnt
        Next
        Dim subjs_temp(4)
        For k As Integer = 0 To subjs.Length - 1
            For l As Integer = 0 To subjs.Length - 1
                If subjs(k)(2) > subjs(l)(2) Then
                    subjs_temp(0) = subjs(k)(0)
                    subjs_temp(1) = subjs(k)(1)
                    subjs_temp(2) = subjs(k)(2)
                    subjs_temp(3) = subjs(k)(3)
                    subjs_temp(4) = subjs(k)(4)
                    subjs(k)(0) = subjs(l)(0)
                    subjs(k)(1) = subjs(l)(1)
                    subjs(k)(2) = subjs(l)(2)
                    subjs(k)(3) = subjs(l)(3)
                    subjs(k)(4) = subjs(l)(4)
                    subjs(l)(0) = subjs_temp(0)
                    subjs(l)(1) = subjs_temp(1)
                    subjs(l)(2) = subjs_temp(2)
                    subjs(l)(3) = subjs_temp(3)
                    subjs(l)(4) = subjs_temp(4)
                End If
            Next
        Next
        e.Graphics.DrawString("S/No.", other_font, Brushes.Black, left_margin, line)
        e.Graphics.DrawString("SUBJECT NAME", other_font, Brushes.Black, left_margin + 50, line)
        e.Graphics.DrawString(cboExamName.SelectedItem & " " & cboTerm.SelectedItem & " " & cboYear.SelectedItem, other_font, Brushes.Black, left_margin + 300, line)
        e.Graphics.DrawString(cboExamName1.SelectedItem & " " & cboTerm1.SelectedItem & " " & cboYear1.SelectedItem, other_font, Brushes.Black, left_margin + 450, line)
        e.Graphics.DrawString("DEVIATION", other_font, Brushes.Black, left_margin + 650, line)
        line += other_font.Height + 5
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)
        line += 2
        Dim count_similar As Integer
        For k As Integer = 0 To subjabb.Length - 1
            If k > 0 Then
                If subjs(k)(2) = subjs(k - 1)(2) Then
                    count_similar += 1
                    If count_similar > 1 Then
                        e.Graphics.DrawString(k - 1, smallfont, Brushes.Black, left_margin, line)
                    Else
                        e.Graphics.DrawString(k, smallfont, Brushes.Black, left_margin, line)
                    End If
                Else
                    count_similar = 0
                    e.Graphics.DrawString(k + 1, smallfont, Brushes.Black, left_margin, line)
                End If
            Else
                e.Graphics.DrawString(k + 1, smallfont, Brushes.Black, left_margin, line)
            End If
            e.Graphics.DrawString(subjs(k)(1), smallfont, Brushes.Black, left_margin + 50, line)
            e.Graphics.DrawString(Format(subjs(k)(4), "0.0000"), smallfont, Brushes.Black, left_margin + 320, line)
            e.Graphics.DrawString(Format(subjs(k)(3), "0.0000"), smallfont, Brushes.Black, left_margin + 470, line)
            If subjs(k)(2) > 0 Then
                e.Graphics.DrawString("+" & Format(subjs(k)(2), "0.00"), smallfont, Brushes.Black, left_margin + 680, line)
            Else
                e.Graphics.DrawString(Format(subjs(k)(2), "0.00"), smallfont, Brushes.Black, left_margin + 680, line)
            End If
            line += other_font.Height
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
        Next
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cboExamName.SelectedItem <> Nothing And cboExamName1.SelectedItem <> Nothing And cboClass.SelectedItem <> Nothing Then
            Dim Print_Preview As New PrintPreviewDialog
            Dim print_dialog As New PrintDialog
            Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report2()
            print_document.DefaultPageSettings.Landscape = False
            Print_Preview.Document = print_document
            Print_Preview.ShowDialog()
        Else
            failure("The Form Is Not Correctly Filled! Please Make The Necessary Corrections!")
        End If
    End Sub

End Class