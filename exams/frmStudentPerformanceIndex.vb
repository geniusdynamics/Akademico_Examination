Imports System.Drawing.Printing
Public Class frmStudentPerformanceIndex

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
                chkBestOf7.Visible = False
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
    Dim loaded_data As Boolean = False
    Dim studs(1000)()
    Dim start_from As Integer = 0
    Private Sub print_report2(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.HasMorePages = False
        Dim line As Integer = 30
        Dim CenterPage As Single
        Dim left_margin As Integer = 20
        Dim right_margin As Single = 800
        If Not loaded_data Then
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
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("MOST IMPROVED STUDENTS", header_font).Width / 2)
            e.Graphics.DrawString("MOST IMPROVED STUDENTS", header_font, Brushes.Black, CenterPage, line)
            line += other_font.Height + 10
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3)
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)
            line += 2
            Dim sum As String
            If cboSortBy.SelectedItem = "Total Points" Then
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
            Else
                If chkBestOf7.Checked Then
                    sum = "B7_Total"
                Else
                    sum = "Total"
                End If
            End If
            qread("SELECT ADMNo , StudentName, `" & sum & "` FROM exam_results WHERE (Examination='" & escape_string(cboExamName1.SelectedItem) & "' AND Term='" & escape_string(cboTerm1.SelectedItem) & "' AND Year='" & escape_string(cboYear1.SelectedItem) & "' AND Class='" & escape_string(cboClass.SelectedItem) & "') ORDER BY `ADMNo` ASC")
            ReDim studs(dbreader.RecordsAffected - 1)(4)
            For k As Integer = 0 To studs.Length - 1
                ReDim studs(k)(4)
                For m As Integer = 0 To studs(k).Length - 1
                    studs(k)(m) = Nothing
                Next
            Next
            Dim i As Integer = 0
            While dbreader.Read
                studs(i)(0) = dbreader("ADMNo")
                studs(i)(1) = dbreader(sum)
                studs(i)(2) = dbreader("StudentName")
                studs(i)(3) = dbreader(sum)
                i += 1
            End While
            For k As Integer = 0 To studs.Length - 1
                If studs(k)(0) = Nothing Then
                    Exit For
                End If
                qread("SELECT `" & sum & "` FROM exam_results WHERE (Examination='" & escape_string(cboExamName.SelectedItem) & "' AND Term='" & escape_string(cboTerm.SelectedItem) & "' AND Year='" & escape_string(cboYear.SelectedItem) & "' AND ADMNo='" & escape_string(studs(k)(0)) & "') ORDER BY `ADMNo` ASC")
                If dbreader.RecordsAffected > 0 Then
                    dbreader.Read()
                    studs(k)(1) = studs(k)(1) - dbreader(sum)
                    studs(k)(4) = dbreader(sum)
                Else
                    studs(k)(4) = "--"
                    studs(k)(1) = 0
                End If
            Next
            Dim studs_temp(4)
            For k As Integer = 0 To studs.Length - 1
                If studs(k)(0) = Nothing Then
                    Exit For
                End If
                For l As Integer = 0 To studs.Length - 1
                    If studs(k)(1) > studs(l)(1) Then
                        studs_temp(0) = studs(k)(0)
                        studs_temp(1) = studs(k)(1)
                        studs_temp(2) = studs(k)(2)
                        studs_temp(3) = studs(k)(3)
                        studs_temp(4) = studs(k)(4)
                        studs(k)(0) = studs(l)(0)
                        studs(k)(1) = studs(l)(1)
                        studs(k)(2) = studs(l)(2)
                        studs(k)(3) = studs(l)(3)
                        studs(k)(4) = studs(l)(4)
                        studs(l)(0) = studs_temp(0)
                        studs(l)(1) = studs_temp(1)
                        studs(l)(2) = studs_temp(2)
                        studs(l)(3) = studs_temp(3)
                        studs(l)(4) = studs_temp(4)
                    End If
                Next
            Next
            e.Graphics.DrawString("S/No.", other_font, Brushes.Black, left_margin, line)
            e.Graphics.DrawString("Adm. No.", other_font, Brushes.Black, left_margin + 50, line)
            e.Graphics.DrawString("NAME OF STUDENT", other_font, Brushes.Black, left_margin + 120, line)
            e.Graphics.DrawString(cboExamName.SelectedItem & " " & cboTerm.SelectedItem & " " & cboYear.SelectedItem, other_font, Brushes.Black, left_margin + 300, line)
            e.Graphics.DrawString(cboExamName1.SelectedItem & " " & cboTerm1.SelectedItem & " " & cboYear1.SelectedItem, other_font, Brushes.Black, left_margin + 450, line)
            e.Graphics.DrawString("DEVIATION", other_font, Brushes.Black, left_margin + 650, line)
            line += other_font.Height + 5
        Else
            line += other_font.Height + 20
        End If
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)
        line += 2
        Dim count_similar As Integer = 0
        For k As Integer = start_from To studs.Length - 1
            If studs(k)(0) = Nothing Then
                Exit For
            ElseIf studs(k)(4).ToString = "--" Then
                Continue For
            End If
            If k > 0 Then
                If studs(k)(1) = studs(k - 1)(1) Then
                    count_similar += 1
                    If count_similar > 1 Then
                        e.Graphics.DrawString(k - 1, smallfont, Brushes.Black, left_margin, line)
                    Else
                        e.Graphics.DrawString(k, smallfont, Brushes.Black, left_margin, line)
                    End If
                Else
                    e.Graphics.DrawString(k + 1, smallfont, Brushes.Black, left_margin, line)
                End If
            Else
                e.Graphics.DrawString(k + 1, smallfont, Brushes.Black, left_margin, line)
            End If
            e.Graphics.DrawString(studs(k)(0), smallfont, Brushes.Black, left_margin + 50, line)
            e.Graphics.DrawString(studs(k)(2), smallfont, Brushes.Black, left_margin + 120, line)
            e.Graphics.DrawString(studs(k)(4), smallfont, Brushes.Black, left_margin + 350, line)
            e.Graphics.DrawString(studs(k)(3), smallfont, Brushes.Black, left_margin + 500, line)
            If studs(k)(1) > 0 Then
                e.Graphics.DrawString("+" & studs(k)(1), smallfont, Brushes.Black, left_margin + 670, line)
            Else
                e.Graphics.DrawString(studs(k)(1), smallfont, Brushes.Black, left_margin + 670, line)
            End If
            line += other_font.Height
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            If line > 1100 Then
                loaded_data = True
                start_from = k + 1
                e.HasMorePages = True
                Exit Sub
            End If
        Next
        start_from = 0
        For k As Integer = start_from To studs.Length - 1
            If studs(k)(0) = Nothing Then
                Exit For
            ElseIf studs(k)(4).ToString = "--" Then
                If k > 0 Then
                    If studs(k)(1) = studs(k - 1)(1) Then
                        count_similar += 1
                        If count_similar > 1 Then
                            e.Graphics.DrawString(k - 1, smallfont, Brushes.Black, left_margin, line)
                        Else
                            e.Graphics.DrawString(k, smallfont, Brushes.Black, left_margin, line)
                        End If
                    Else
                        e.Graphics.DrawString(k + 1, smallfont, Brushes.Black, left_margin, line)
                    End If
                Else
                    e.Graphics.DrawString(k + 1, smallfont, Brushes.Black, left_margin, line)
                End If
                e.Graphics.DrawString(studs(k)(0), smallfont, Brushes.Black, left_margin + 50, line)
                e.Graphics.DrawString(studs(k)(2), smallfont, Brushes.Black, left_margin + 120, line)
                e.Graphics.DrawString(studs(k)(4), smallfont, Brushes.Black, left_margin + 350, line)
                e.Graphics.DrawString(studs(k)(3), smallfont, Brushes.Black, left_margin + 500, line)
                If studs(k)(1) > 0 Then
                    e.Graphics.DrawString("+" & studs(k)(1), smallfont, Brushes.Black, left_margin + 670, line)
                Else
                    e.Graphics.DrawString(studs(k)(1), smallfont, Brushes.Black, left_margin + 670, line)
                End If
                line += other_font.Height
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
                If line > 1100 Then
                    loaded_data = True
                    start_from = k + 1
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
        Next
        start_from = 0
        loaded_data = False
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cboExamName.SelectedItem <> Nothing And cboExamName1.SelectedItem <> Nothing And cboClass.SelectedItem <> Nothing And cboSortBy.SelectedItem <> Nothing Then
            loaded_data = False
            start_from = 0
            Dim Print_Preview As New PrintPreviewDialog
            Dim print_dialog As New PrintDialog
            Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report2()
            print_document.DefaultPageSettings.Landscape = False
            Print_Preview.Document = print_document
            Print_Preview.ShowDialog()
        Else
            failure("The Form Is Not Validly Filled!")
        End If
    End Sub

End Class