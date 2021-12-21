Imports System.Drawing.Printing
Imports System.IO

Public Class frmResults
    Dim subjects_7(500)(), counter
    Dim total_term_days As Integer
    Dim percentage_attendance As Double
    Dim student As Integer
    Dim class_out_of As Integer
    Dim stream_no() As Integer
    Dim adm_no
    Dim sciences() As String
    Dim sci_names() As String
    Dim science As Boolean = True
    Dim humanities() As String
    Dim hum_names() As String
    Dim app_names() As String
    Dim humanity As Boolean = False
    Dim applieds() As String
    Dim applied As Boolean = False
    Dim compulsory() As String
    Dim comp_names() As String
    Dim points As Boolean = False
    Dim admnos() As String
    Dim logoPath As String


    Private Function total_days(from_ As String, to_ As String) As Integer
        qread("SELECT DISTINCT date FROM student_attendance WHERE date >= '" & from_ & "' AND date <='" & to_ & "';")
        Return dbreader.RecordsAffected
    End Function
    Private Function get_total_attendance(ByVal id As Integer)
        Dim att As Integer = 0
        If qread("SELECT * FROM term_dates WHERE Term='" & tm & "' AND Year='" & yr & "'") Then
            dbreader.Read()
            If Not IsDate(dbreader("startDate")) Or Not IsDate(dbreader("endDate")) Then
                Exit Function
            End If

            Dim date_from As Date = dbreader("startDate")
            Dim date_to As Date = dbreader("endDate")
            query = "SELECT * FROM student_attendance WHERE Morning_present='Present' AND afte_present='Present' AND admin_no='" & id & "' AND Date >='" & date_from.Year & "-" & Format(date_from.Month, "00") & "-" & Format(date_from.Day, "00") & "' AND Date <='" & date_to.Year & "-" & Format(date_to.Month, "00") & "-" & Format(date_to.Day, "00") & "'  GROUP BY DATE"
            dbreader.Close()
            If qread(query) Then
                att = dbreader.RecordsAffected
            End If
            total_term_days = total_days(date_from.Year & "-" & Format(date_from.Month, "00") & "-" & Format(date_from.Day, "00"), date_to.Year & "-" & Format(date_to.Month, "00") & "-" & Format(date_to.Day, "00"))
        End If
        If total_term_days > 0 Then
            percentage_attendance = Format((att / total_term_days) * 100, 0.0)
        Else
            percentage_attendance = 0.0
        End If
        Return att
    End Function
    Private Function prepare_class_list()
        Dim print_document As New PrintDocument
        Dim margin As New Margins(10, 10, 10, 10)
        print_document.DefaultPageSettings.Landscape = True
        print_document.DefaultPageSettings.Margins = margin
        AddHandler print_document.PrintPage, AddressOf print_class_list
        Return print_document
    End Function
    Private Function prepare_stream_list()
        Dim print_document As New PrintDocument
        Dim margin As New Margins(10, 10, 10, 10)
        print_document.DefaultPageSettings.Landscape = True
        print_document.DefaultPageSettings.Margins = margin
        AddHandler print_document.PrintPage, AddressOf print_stream_list
        Return print_document
    End Function
    Private Sub print_class_list(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
        Dim line As Integer = 160
        Dim topline As Integer = line
        Dim left_margin, right_margin As Integer
        left_margin = 50
        right_margin = 1000
        If S_NAME <> String.Empty Then
            e.Graphics.DrawString(S_NAME.ToUpper, header_font, Brushes.Black, left_margin + 180, 50)
        End If
        If S_ADDRESS <> String.Empty Then
            e.Graphics.DrawString("P.O. BOX " & S_ADDRESS.ToUpper & ", " & S_LOCATION.ToUpper, other_font, Brushes.Black, left_margin + 250, 80)
        End If
        If S_FAX <> String.Empty Then
            e.Graphics.DrawString("FAX: " & S_FAX, other_font, Brushes.Black, left_margin + 270, 100)
        End If
        If S_PHONE <> String.Empty Then
            e.Graphics.DrawString("TELEPHONE: " & S_PHONE, other_font, Brushes.Black, left_margin + 260, 120)
        End If
        Try
            e.Graphics.DrawString(ret_name(class_form).ToString.ToUpper & " " & exam_name.ToUpper & " EXAMINATION PERFORMANCE MARKLIST", other_font, Brushes.Black, left_margin + 200, line)
        Catch ex As Exception
            Dim exam As String = String.Empty
            For k As Integer = 0 To exam_names.Length - 1
                exam += exam_names(k)
                If k < exam_names.Length - 1 Then
                    exam += "/"
                End If
            Next
            e.Graphics.DrawString(ret_name(class_form).ToString.ToUpper & " " & exam.ToUpper & " EXAMINATION PERFORMANCE MARKLIST", other_font, Brushes.Black, left_margin + 100, line)
        End Try

        line += 30
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2)
        e.Graphics.DrawString("NAME OF STUDENT", other_font, Brushes.Black, left_margin - 2, line + 5)
        Dim col As Integer = 280
        For k As Integer = 0 To subjabb.Length - 1
            Try
                e.Graphics.DrawString(subjabb(k).Substring(0, 3), other_font, Brushes.Black, left_margin + col + 3, line + 5)
            Catch ex As Exception
                e.Graphics.DrawString(subjabb(k).Substring(0, 2), other_font, Brushes.Black, left_margin + col + 3, line + 5)
            End Try
            col += 45
        Next
        col += 7
        e.Graphics.DrawString("Total", other_font, Brushes.Black, left_margin + col, line + 5)
        col += 40
        e.Graphics.DrawString("Pos.", other_font, Brushes.Black, left_margin + col, line + 5)
        line += 20
        'e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line)
        col = 280
        For i As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            e.Graphics.DrawString(dgvEnterMarks.Item("StudentName", i).Value, other_font, Brushes.Black, left_margin + 5, line + 3)

            For k As Integer = 0 To subjabb.Length - 1
                e.Graphics.DrawString(dgvEnterMarks.Item(subjname(k), i).Value, other_font, Brushes.Black, left_margin + col + 5, line + 3)
                col += 45
            Next
            col += 7
            e.Graphics.DrawString(dgvEnterMarks.Item("Total", i).Value, other_font, Brushes.Black, left_margin + col, line + 3)
            col += 40
            e.Graphics.DrawString(i + 1, other_font, Brushes.Black, left_margin + col, line + 3)
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2)
            line += 20
            col = 280
        Next
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 3, right_margin - 2, line + 3)
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline + 32, left_margin - 2, line + 3)
        col = 280
        For k As Integer = 0 To subjabb.Length - 1
            e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3)
            col += 45
        Next
        col += 7
        e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3)
        col += 40
        e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3)
        e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline + 32, right_margin - 2, line + 3)
    End Sub
    Private Sub print_stream_list(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim line As Integer = 150
        Dim topline As Integer = line
        Dim left_margin, right_margin As Integer
        left_margin = 50
        right_margin = 800
        If S_NAME <> String.Empty Then
            e.Graphics.DrawString(S_NAME.ToUpper, header_font, Brushes.Black, left_margin + 160, 50)
        End If
        If S_ADDRESS <> String.Empty Then
            e.Graphics.DrawString("P.O. BOX " & S_ADDRESS.ToUpper & ", " & S_LOCATION.ToUpper, other_font, Brushes.Black, left_margin + 250, 80)
        End If
        If S_FAX <> String.Empty Then
            e.Graphics.DrawString("FAX: " & S_FAX, other_font, Brushes.Black, left_margin + 270, 100)
        End If
        If S_PHONE <> String.Empty Then
            e.Graphics.DrawString("TELEPHONE: " & S_PHONE, other_font, Brushes.Black, left_margin + 260, 120)
        End If
        Try
            e.Graphics.DrawString(ret_name(class_form).ToString.ToUpper & " " & class_stream.ToUpper & " " & exam_name.ToUpper & " EXAMINATION PERFORMANCE MARKLIST", other_font, Brushes.Black, left_margin + 200, line)
        Catch ex As Exception
            Dim exam As String = String.Empty
            For k As Integer = 0 To exam_names.Length - 1
                exam += exam_names(k)
                If k < exam_names.Length - 1 Then
                    exam += "/"
                End If
            Next
            e.Graphics.DrawString(ret_name(class_form).ToString.ToUpper & " " & class_stream.ToUpper & " " & exam.ToUpper & " EXAMINATION PERFORMANCE MARKLIST", other_font, Brushes.Black, left_margin + 100, line)
        End Try
        line += 30
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2)
        e.Graphics.DrawString("NAME OF STUDENT", other_font, Brushes.Black, left_margin - 2, line + 5)
        Dim col As Integer = 280
        For k As Integer = 0 To subjabb.Length - 1
            Try
                e.Graphics.DrawString(subjabb(k).Substring(0, 3), other_font, Brushes.Black, left_margin + col, line + 5)
            Catch ex As Exception
                e.Graphics.DrawString(subjabb(k).Substring(0, 2), other_font, Brushes.Black, left_margin + col, line + 5)
            End Try
            col += 34
        Next
        col += 16
        e.Graphics.DrawString("Total", other_font, Brushes.Black, left_margin + col, line + 5)
        col += 40
        e.Graphics.DrawString("Pos.", other_font, Brushes.Black, left_margin + col, line + 5)
        line += 20
        Dim i, j As Integer
        j = 0
        For i = 0 To dgvEnterMarks.Rows.Count - 1
            If dgvEnterMarks.Item("str_class", i).Value = class_stream Then
                e.Graphics.DrawString(dgvEnterMarks.Item("StudentName", i).Value, other_font, Brushes.Black, left_margin + 5, line + 3)
                col = 285
                For k As Integer = 0 To subjabb.Length - 1
                    e.Graphics.DrawString(dgvEnterMarks.Item(subjname(k), i).Value, other_font, Brushes.Black, left_margin + col, line + 3)
                    col += 34
                Next
                col += 16
                e.Graphics.DrawString(dgvEnterMarks.Item("Total", i).Value, other_font, Brushes.Black, left_margin + col, line + 3)
                col += 40
                e.Graphics.DrawString(j + 1, other_font, Brushes.Black, left_margin + col, line + 3)
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2)
                line += 20
                j += 1
            End If
        Next
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 3, right_margin - 2, line + 3)
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline + 32, left_margin - 2, line + 3)
        col = 280
        For k As Integer = 0 To subjabb.Length - 1
            e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3)
            col += 34
        Next
        col += 16
        e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3)
        col += 40
        e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3)
        e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline + 32, right_margin - 2, line + 3)
    End Sub
    Private Sub get_split_subjects(ByVal subj As String, Optional name As Boolean = False)
        qread("SELECT * FROM split_subjects WHERE subject='" & escape_string(subj) & "' AND class='" & escape_string(ret_name(class_form)) & "'", 2)
        ReDim splits(dbreader2.RecordsAffected - 1), splits_cont(dbreader2.RecordsAffected - 1), splits_name(dbreader2.RecordsAffected - 1)
        Dim i As Integer = 0
        While dbreader2.Read
            If name Then
                splits_name(i) = dbreader2("abbreviation")
                splits(i) = dbreader2("name") & " [ " & dbreader2("abbreviation") & " ] "
            Else
                splits(i) = dbreader2("abbreviation")
            End If
            splits_cont(i) = dbreader2("contribution")
            i += 1
        End While
    End Sub
    Dim splits(), splits_cont(), splits_name()
    Private Sub create_dataform()
        Dim cellKCPE As DataGridViewCell = New DataGridViewTextBoxCell
        Dim colKCPE As New DataGridViewColumn
        With colKCPE
            .CellTemplate = cellKCPE
            .Name = "KCPE"
            .HeaderText = "KCPE"
            .Width = 100
            .Visible = _kcpe
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Programmatic
        End With
        dgvEnterMarks.Columns.Add(colKCPE)
        Dim cellINDEX As DataGridViewCell = New DataGridViewTextBoxCell
        Dim colINDEX As New DataGridViewColumn
        With colINDEX
            .CellTemplate = cellINDEX
            .Name = "INDEX"
            .HeaderText = "INDEX NO."
            .Width = 100
            .Visible = _index
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Programmatic
        End With
        dgvEnterMarks.Columns.Add(colINDEX)
        get_subjects()
        For k As Integer = 0 To subjabb.Length - 1
            Dim split_count As Integer = 0
            If show_split Then
                get_split_subjects(subjects(k))
                For count = 0 To splits.Length - 1
                    Dim cellINDEX1 As DataGridViewCell = New DataGridViewTextBoxCell
                    Dim colINDEX1 As New DataGridViewColumn
                    With colINDEX1
                        .CellTemplate = cellINDEX1
                        .Name = splits(count)
                        .HeaderText = splits(count)
                        .Width = 50
                        .ReadOnly = True
                        .SortMode = DataGridViewColumnSortMode.Programmatic
                    End With
                    dgvEnterMarks.Columns.Add(colINDEX1)
                    split_count += 1
                Next
            End If
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
                    If split_count = 0 Or Not IsPrimary() Then
                        .HeaderText = remove_wild(subjabb(k).Substring(0, 2))
                    Else
                        .HeaderText = "Total"
                    End If
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
            .Visible = _se
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
            .Visible = _tp
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
            .Visible = _mp
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
            .Visible = _mm
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
            .Visible = _mg
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = False
        End With
        dgvEnterMarks.Columns.Add(colmg)
        Dim cell1 As DataGridViewCell = New DataGridViewTextBoxCell
        Dim column0 As New DataGridViewColumn
        With column0
            .CellTemplate = cell1
            .Name = "Total"
            .HeaderText = "TM"
            .Visible = _tm
            .Width = 60
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgvEnterMarks.Columns.Add(column0)
        Dim column1 As New DataGridViewColumn
        With column1
            .CellTemplate = cell1
            .Name = "str_class"
            .Visible = _str
            .HeaderText = "STR"
            .Width = 60
            .ReadOnly = True
        End With
        dgvEnterMarks.Columns.Add(column1)
        Dim column2 As New DataGridViewColumn
        With column2
            .CellTemplate = cell1
            .Name = "Position"
            .HeaderText = "SP"
            .Width = 60
            .ReadOnly = True
        End With
        dgvEnterMarks.Columns.Add(column2)
        Dim column3 As New DataGridViewColumn
        With column3
            .CellTemplate = cell1
            .Name = "Overall"
            .HeaderText = "OP"
            .Width = 60
            .ReadOnly = True
        End With
        dgvEnterMarks.Columns.Add(column3)
        Dim column4 As New DataGridViewColumn
        With column4
            .CellTemplate = cell1
            .Name = "VAP"
            .HeaderText = "VAP"
            .Width = 60
            .Visible = _vap
            .ReadOnly = True
        End With
        dgvEnterMarks.Columns.Add(column4)
    End Sub
    Private Function kcpe_rank(ByVal marks)
        Dim k As Integer = 1
        Dim tester As Integer
        qread("SELECT admin_no, marks_attained_primary FROM students WHERE Class='" & ret_name(class_form) & "' ORDER BY marks_attained_primary DESC")
        While dbreader.Read
            If dbreader("marks_attained_primary").ToString = Nothing Or dbreader("marks_attained_primary").ToString = String.Empty Then
                tester = 0
            Else
                tester = dbreader("marks_attained_primary")
            End If
            If marks = tester Then
                Return k
            End If
            k += 1
        End While
        Return "--"
    End Function
    Dim report As New ReportForm
    Private Sub loadReportFormDefaults()
        qread("SELECT * FROM report_configuration")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            With report
                .club_and_societies = CheckStatus(dbreader("club_and_societies"))
                .class_teacher_comments = CheckStatus(dbreader("class_teacher_comments"))
                .class_teacher_signature = CheckStatus(dbreader("class_teacher_signature"))
                .house_master_comments = CheckStatus(dbreader("house_master_comments"))
                .head_teacher_comments = CheckStatus(dbreader("head_teacher_comments"))
                .head_teacher_signature = CheckStatus(dbreader("head_teacher_signature"))
                .school_logo = CheckStatus(dbreader("school_logo"))
                .student_photo = CheckStatus(dbreader("student_photo"))
                .head_teacher_name = CheckStatus(dbreader("head_teacher_name"))
                .class_teacher_name = CheckStatus(dbreader("class_teacher_name"))
            End With
        End If
    End Sub
    Dim _se, _tp, _mp, _mm, _mg, _tm, _str, _sp, _op, _vap, _kcpe, _index As Boolean
    Private Sub get_merit_list_configuration()
        If qread("SELECT * FROM merit_list_config WHERE `class`='" & ret_name(class_form) & "'") Then
            If dbreader.RecordsAffected > 0 Then
                dbreader.Read()
                _se = dbreader("se")
                _tp = dbreader("tp")
                _mp = dbreader("mp")
                _mg = dbreader("mg")
                _tm = dbreader("tm")
                _str = dbreader("str")
                _sp = dbreader("sp")
                _op = dbreader("op")
                _vap = dbreader("vap")
                _kcpe = dbreader("kcpe")
                _index = dbreader("index_no")
            Else
                Dim frm As New frmMeritListConfig
                frm.ShowDialog()
                get_merit_list_configuration()

            End If
        Else
            failure("You are missing a critical configuration setting in your software!")
        End If
    End Sub

    Dim parentsGuardiansFolder As String = String.Empty
    Dim studentImagePath As String = String.Empty
    Private Sub frmResults_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim folder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        parentsGuardiansFolder = System.IO.Path.Combine(folder, "photos_parent_guardians")

        chkMode.CheckState = CheckState.Unchecked

        If Not connect() Or Not dbNewOpen() Then
            Me.Close()
        Else
            If Not IsPrimary() Then
                radSubject.Visible = True
                chkSplit.Visible = False
            Else
                chkSplit.Checked = True
                radSubject.Checked = False
            End If
            Dim frm As New frmResultAnalysis
            frm.ShowDialog()

            If Not search_teachers Then
                ' Me.Close()
            Else
                Using (New DevExpress.Utils.WaitDialogForm("Processing Results, Please Wait .....", "Computing Results"))
                    get_merit_list_configuration()
                    loadReportFormDefaults()
                    create_dataform()
                    If mode Then
                        load_multi()
                    Else
                        load_entered()
                    End If
                End Using
            End If
        End If
        chkMode.Visible = radSubject.Checked
        state = True
        logo()

    End Sub
    Public Function logo() As String
        qread("SELECT image_path FROM school_details")
        dbreader.Read()

        logoPath = dbreader("image_path")
        Dim folder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        parentsGuardiansFolder = System.IO.Path.Combine(folder, "photos_parent_guardians")
        logoPath = parentsGuardiansFolder + "\schoolLogo.png"
        Return logoPath
    End Function
    Private Function contribute(ByVal val As Integer, ByVal cont As Integer)
        If cont = 0 Then
            Return val
        Else
            Return (val / marks) * cont
        End If
    End Function

    Private Function student_name(ByVal adm As String)
        Dim sname As String = String.Empty
        ' "SELECT LastName, FirstName, MiddleName FROM " & get_name(class_form) & "_classlist WHERE ADMNo='" & adm & "'"
        If qread("select student_name from students where admin_no ='" & adm & "'") Then
            dbreader.Read()
            If dbreader.RecordsAffected > 0 Then
                ' sname = dbreader("LastName") & " " & dbreader("MiddleName") & " " & dbreader("FirstName")
                sname = dbreader("student_name")
            Else
                sname = String.Empty
            End If
            dbreader.Close()
        End If
        Return sname
    End Function

    Dim student_no As Integer
    Private Sub re_read_table()
        Dim j As Integer
        Dim term As String = String.Empty
        Dim year As Integer
        Dim re_read_table As String = Nothing
        For k As Integer = 0 To tables.Length - 1
            qread("SELECT ADMNo FROM " & table & " WHERE Examination='" & tables(k) & "' AND Term='" & tms(k) & "' AND Year='" & yrs(k) & "' AND Class='" & escape_string(ret_name(class_form)) & "'")
            If k = 0 Then
                student_no = dbreader.RecordsAffected
                term = tms(k)
                year = yrs(k)
                re_read_table = tables(k)
            End If
            If k > 0 And dbreader.RecordsAffected > student_no Then
                student_no = dbreader.RecordsAffected
                term = tms(k)
                year = yrs(k)
                re_read_table = tables(k)
            End If
        Next
        qread("SELECT ADMNo FROM " & table & " WHERE Examination='" & re_read_table & "'  AND Term='" & term & "' AND Year='" & year & "' AND Class='" & escape_string(ret_name(class_form)) & "'")
        If dbreader.RecordsAffected > 0 Then
            ReDim subjects_7(dbreader.RecordsAffected - 1)(7)
            For k As Integer = 0 To subjects_7.Length - 1
                ReDim subjects_7(k)(8)
                For m As Integer = 0 To subjects_7(k).Length - 1
                    subjects_7(k)(8) = Nothing
                Next
            Next
            ReDim admnos(dbreader.RecordsAffected - 1)
            While dbreader.Read
                admnos(j) = dbreader("ADMNo")
                subjects_7(j)(8) = dbreader("ADMNo")
                j += 1
            End While
            dbreader.Close()
        End If
    End Sub

    Dim xStudents As New List(Of String)

    Private Sub load_multi()
        If form_4_mode And Not formfourmode() Then
            Exit Sub
        End If
        get_streams(class_form)
        Dim c_stream As String
        c_stream = String.Empty
        Dim sname As String = String.Empty
        Dim total(subjabb.Length - 1)
        Dim i, l, totals As Integer
        Dim j As Integer = 0
        If yr > Today.Year Then
            If qread("SELECT admin_no FROM students WHERE Class='" & ret_name(class_form) & "' ORDER BY ADMNo") Then
                If dbreader.RecordsAffected > 0 Then
                    failure("There Were No Matching Records Found From The " & ret_name(class_form) & " Classlist! Continuing With Recovery Mode...")
                    re_read_table()
                End If
            End If
        Else
            re_read_table()
        End If
        Dim temp, temp_name As String
        Pbar.Visible = True
        Dim inc As Integer = admnos.Length / 100

        If form_4_mode Then
            Dim comp(), sci(), hum(), app() As Integer
            ReDim comp(compulsory.Length - 1), comp_names(compulsory.Length - 1), sci(sciences.Length - 1), sci_names(sciences.Length - 1), hum_names(humanities.Length - 1), hum(humanities.Length - 1), app_names(applieds.Length - 1), app(applieds.Length - 1)


            For j = 0 To admnos.Length - 1
                'new code start
                found = False
                'new code end
                science = True
                For k As Integer = 0 To subjabb.Length - 1
                    total(k) = 0
                Next
                For k As Integer = 0 To comp.Length - 1
                    comp(k) = 0
                Next
                For k As Integer = 0 To sci.Length - 1
                    sci(k) = 0
                Next
                For k As Integer = 0 To hum.Length - 1
                    hum(k) = 0
                Next
                For k As Integer = 0 To app.Length - 1
                    app(k) = 0
                Next
                totals = 0
                Dim out_of As Double
                Dim tp As Integer = 0
                For i = 0 To tables.Length - 1

                    'I've overridden the default year for tm and yr which represent the current year and term
                    tm = tms(i)
                    yr = yrs(i)

                    If qread("SELECT * FROM " & table & " WHERE ADMNo='" &
                            admnos(j) & "' AND Examination='" & escape_string(tables(i)) & "' AND Term='" & tm & "' AND Year='" & yr & "' LIMIT 1") Then
                        Try
                            dbreader.Read()
                            sname = dbreader("StudentName")
                        Catch ex As Exception
                            Continue For
                        End Try
                        c_stream = dbreader("Stream")
                        For k As Integer = 0 To subjabb.Length - 1
                            If IsNumeric(dbreader(subjname(k))) Then
                                out_of = SubjectOutOf(subjname(k), tm, yr, exam_names(i), dbreader("Class"), dbreader("Stream"), 2)
                                If contribution(i) = 0 Then
                                    total(k) += (dbreader(subjname(k)) / out_of) * total_mark(i)
                                Else
                                    total(k) += ((dbreader(subjname(k)) / out_of) * total_mark(i)) * contribution(i) / total_mark(i)
                                End If
                                'new code start for students thta have x and y
                            Else
                                If dbreader(subjname(k)).ToString().ToUpper = "X" Then
                                    total(k) = "X"
                                    found = True
                                    xStudents.Add(admnos(j))
                                ElseIf dbreader(subjname(k)).ToString().ToUpper = "Y" Then
                                    total(k) = "Y"
                                    found = True
                                    xStudents.Add(admnos(j))
                                End If
                                'new code end
                            End If
                        Next
                        '##############get total of first compulsory subjects#################
                        For k As Integer = 0 To compulsory.Length - 1
                            If IsNumeric(dbreader(compulsory(k))) Then
                                out_of = SubjectOutOf(subjname(k), tm, yr, exam_names(i), dbreader("Class"), dbreader("Stream"), 2)
                                If contribution(i) = 0 Then
                                    comp(k) += (dbreader(compulsory(k)) / out_of) * total_mark(i)
                                Else
                                    comp(k) += ((dbreader(compulsory(k)) / out_of) * total_mark(i)) * contribution(i) / total_mark(i)
                                End If
                                comp_names(k) = subjabb(k)
                            End If
                        Next
                        For k As Integer = 0 To sciences.Length - 1
                            If Not IsNumeric(dbreader(sciences(k))) Then
                                science = False
                            End If
                        Next
                        For k As Integer = 0 To sciences.Length - 1
                            If IsNumeric(dbreader(sciences(k))) Then
                                out_of = SubjectOutOf(subjname(k), tm, yr, exam_names(i), dbreader("Class"), dbreader("Stream"), 2)
                                If contribution(i) = 0 Then
                                    sci(k) += (dbreader(sciences(k)) / out_of) * total_mark(i)
                                Else
                                    sci(k) += ((dbreader(sciences(k)) / out_of) * total_mark(i)) * contribution(i) / total_mark(i)
                                End If
                                sci_names(k) = sciences(k)
                            End If
                        Next
                        For k As Integer = 0 To humanities.Length - 1
                            If IsNumeric(dbreader(humanities(k))) Then
                                out_of = SubjectOutOf(subjname(k), tm, yr, exam_names(i), dbreader("Class"), dbreader("Stream"), 2)
                                If contribution(i) = 0 Then
                                    hum(k) += (dbreader(humanities(k)) / out_of) * total_mark(i)
                                Else
                                    hum(k) += ((dbreader(humanities(k)) / out_of) * total_mark(i)) * contribution(i) / total_mark(i)
                                End If

                                hum_names(k) = humanities(k)
                            End If
                        Next
                        For k As Integer = 0 To applieds.Length - 1
                            If IsNumeric(dbreader(applieds(k))) Then
                                out_of = SubjectOutOf(subjname(k), tm, yr, exam_names(i), dbreader("Class"), dbreader("Stream"), 2)
                                If contribution(i) = 0 Then
                                    app(k) = (dbreader(applieds(k)) / out_of) * total_mark(i)
                                Else
                                    app(k) += ((dbreader(applieds(k)) / out_of) * total_mark(i)) * contribution(i) / total_mark(i)
                                End If

                                app_names(k) = applieds(k)
                            End If
                        Next
                    End If
                Next

                '#######################GET TOTALS##############################
                totals = 0
                counter = 0
                For k As Integer = 0 To comp.Length - 1
                    totals += comp(k)
                    tp += fix_point(get_grade(comp(k), radSubject.Checked, comp_names(k)))
                    subjects_7(j)(counter) = comp_names(k)
                    counter += 1
                Next

                '#######################################
                For k As Integer = 0 To sciences.Length - 1
                    sci_names(k) = sciences(k)
                Next
                If science Then
                    '###########Sort them#############
                    For k As Integer = 0 To sciences.Length - 1
                        For l = k + 1 To sciences.Length - 1
                            If sci(k) < sci(l) Or Not IsNumeric(sci(k)) Then
                                temp = sci(k)
                                temp_name = sci_names(k)
                                sci(k) = sci(l)
                                sci_names(k) = sci_names(l)
                                sci(l) = temp
                                sci_names(l) = temp_name
                            End If
                        Next
                    Next
                    For k As Integer = 0 To sciences.Length - 1
                        If k < sciences.Length - 1 Then
                            totals += sci(k)
                            tp += fix_point(get_grade(sci(k), radSubject.Checked, sci_names(k)))
                            subjects_7(j)(counter) = sci_names(k)
                            counter += 1
                        End If
                    Next
                Else
                    For k As Integer = 0 To sciences.Length - 1
                        totals += sci(k)
                        tp += fix_point(get_grade(sci(k), radSubject.Checked, sci_names(k)))
                        subjects_7(j)(counter) = sci_names(k)
                        counter += 1
                    Next
                End If

                '#######################################
                Dim count As Integer = humanities.Length
                For k As Integer = 0 To humanities.Length - 1
                    hum_names(k) = humanities(k)
                    If Not IsNumeric(hum(k)) Then
                        count -= 1
                    End If
                Next
                If count > 1 Then
                    humanity = True
                    l = 0
                    For k As Integer = 0 To hum.Length - 1
                        For l = k + 1 To hum.Length - 1
                            If hum(k) < hum(l) Or Not IsNumeric(hum(k)) Then
                                temp = hum(k)
                                temp_name = hum_names(k)
                                hum(k) = hum(l)
                                hum_names(k) = hum_names(l)
                                hum(l) = temp
                                hum_names(l) = temp_name
                            End If
                        Next
                    Next
                    totals += hum(0)
                    tp += fix_point(get_grade(hum(0), radSubject.Checked, hum_names(0)))
                    subjects_7(j)(counter) = hum_names(0)
                    counter += 1
                Else
                    For k As Integer = 0 To humanities.Length - 1
                        If IsNumeric(hum(k)) Then
                            totals += hum(k)
                            tp += fix_point(get_grade(hum(k), radSubject.Checked, hum_names(k)))
                            subjects_7(j)(counter) = hum_names(k)
                            counter += 1
                        End If
                    Next
                End If

                '######################################
                count = applieds.Length
                For k As Integer = 0 To applieds.Length - 1
                    If Not IsNumeric(app(k)) Then
                        count -= 1
                    End If
                Next
                If count > 0 Then
                    applied = True
                    For k As Integer = 0 To app.Length - 1
                        For l = k + 1 To app.Length - 1
                            If app(k) < app(l) Or Not IsNumeric(app(k)) Then
                                temp = app(k)
                                temp_name = app_names(k)
                                app(k) = app(l)
                                app_names(k) = app_names(l)
                                app(l) = temp
                                app_names(l) = temp_name
                            End If
                        Next
                    Next
                End If

                '######################################

                If science And humanity And applied Then
                    If sci(2) > hum(1) Then
                        If sci(2) > app(0) Then
                            totals += sci(2)
                            tp += fix_point(get_grade(sci(2), radSubject.Checked, sci_names(2)))
                            subjects_7(j)(counter) = sci_names(2)
                            counter += 1
                        Else
                            totals += app(0)
                            tp += fix_point(get_grade(app(0), radSubject.Checked, app_names(0)))
                            subjects_7(j)(counter) = app_names(0)
                            counter += 1
                        End If
                    Else
                        If hum(1) > app(0) Then
                            totals += hum(1)
                            tp += fix_point(get_grade(hum(1), radSubject.Checked, hum_names(1)))
                            subjects_7(j)(counter) = hum_names(1)
                            counter += 1
                        Else
                            totals += app(0)
                            tp += fix_point(get_grade(app(0), radSubject.Checked, app_names(0)))
                            subjects_7(j)(counter) = app_names(0)
                            counter += 1
                        End If
                    End If
                ElseIf science And humanity Then
                    If sci(2) > hum(1) Then
                        totals += sci(2)
                        tp += fix_point(get_grade(sci(2), radSubject.Checked, sci_names(2)))
                        subjects_7(j)(counter) = sci_names(2)
                        counter += 1
                    Else
                        totals += hum(1)
                        tp += fix_point(get_grade(hum(1), radSubject.Checked, hum_names(1)))
                        subjects_7(j)(counter) = hum_names(1)
                        counter += 1
                    End If
                ElseIf science And applied Then
                    If sci(2) > app(0) Then
                        totals += sci(2)
                        tp += fix_point(get_grade(sci(2), radSubject.Checked, sci_names(2)))
                        subjects_7(j)(counter) = sci_names(2)
                        counter += 1
                    Else
                        totals += app(0)
                        tp += fix_point(get_grade(app(0), radSubject.Checked, app_names(0)))
                        subjects_7(j)(counter) = app_names(0)
                        counter += 1
                    End If
                ElseIf applied And humanity Then
                    If app(0) > hum(1) Then
                        totals += app(0)
                        tp += fix_point(get_grade(app(0), radSubject.Checked, app_names(0)))
                        subjects_7(j)(counter) = app_names(0)
                        counter += 1
                    Else
                        totals += hum(1)
                        tp += fix_point(get_grade(hum(1), radSubject.Checked, hum_names(1)))
                        subjects_7(j)(counter) = hum_names(1)
                        counter += 1
                    End If
                End If

                '#########################################
                dgvEnterMarks.Rows.Add()
                dgvEnterMarks.Item("ADMNo", j).Value = get_id(admnos(j))
                dgvEnterMarks.Item("StudentName", j).Value = sname

                'new code start
                For k As Integer = 0 To subjabb.Length - 1
                    Try
                        dgvEnterMarks.Item(subjname(k), j).Value = Math.Round(total(k), 0)
                    Catch ex As Exception
                        If total(k) = "X" Then
                            dgvEnterMarks.Item(subjname(k), j).Value = "X"
                        ElseIf total(k) = "Y" Then
                            dgvEnterMarks.Item(subjname(k), j).Value = "Y"
                        End If
                    End Try
                Next

                If total.Contains("X") Or total.Contains("Y") Or found = True Then
                    dgvEnterMarks.Item("TP", j).Value = 0
                    dgvEnterMarks.Item("Total", j).Value = 0
                Else
                    dgvEnterMarks.Item("TP", j).Value = tp
                    dgvEnterMarks.Item("Total", j).Value = Math.Round(totals, 0)
                End If

                'new code end

                dgvEnterMarks.Item("str_class", j).Value = c_stream
                Pbar.Increment(inc)
            Next
        Else
            Dim tp As Integer
            Dim out_of As Double
            For j = 0 To admnos.Length - 1
                tp = 0
                For k As Integer = 0 To subjabb.Length - 1
                    total(k) = 0
                Next
                totals = 0
                For i = 0 To tables.Length - 1

                    'I've overridden the default year for tm and yr which represent the current year and term
                    tm = tms(i)
                    yr = yrs(i)

                    If qread("SELECT * FROM " & table & " WHERE ADMNo='" &
                    admnos(j) & "' AND Examination='" & escape_string(tables(i)) & "' AND Term='" & tm & "' AND Year='" & yr & "' LIMIT 1") Then
                        If dbreader.RecordsAffected > 0 Then
                            dbreader.Read()
                            sname = dbreader("StudentName")
                            For k As Integer = 0 To subjabb.Length - 1
                                If IsNumeric(dbreader(subjname(k))) Then
                                    out_of = SubjectOutOf(subjname(k), tm, yr, exam_names(i), dbreader("Class"), dbreader("Stream"), 2)
                                    If contribution(i) = 0 Then
                                        total(k) += 0
                                    Else
                                        'todo edit 8/8/2016
                                        Try
                                            If IsNumeric(dbreader(subjname(k))) Then
                                                total(k) += ((dbreader(subjname(k)) / out_of) * total_mark(i)) * (contribution(i) / total_mark(i))
                                            End If
                                        Catch ex As Exception

                                        End Try
                                        'edit end
                                    End If
                                    tp += fix_point(get_grade(((dbreader(subjname(k)) / out_of) * total_mark(i)), radSubject.Checked, subjabb(k)))
                                    'new code start
                                Else
                                    If dbreader(subjname(k)).ToString().ToUpper = "X" Then
                                        total(k) = "X"
                                        xStudents.Add(admnos(j))
                                    ElseIf dbreader(subjname(k)).ToString().ToUpper = "Y" Then
                                        total(k) = "Y"
                                        xStudents.Add(admnos(j))
                                    End If
                                    'new code end
                                End If
                            Next
                            c_stream = dbreader("Stream")
                        Else
                            dbreader.Close()
                            sname = student_name(admnos(j))
                            For k As Integer = 0 To subjabb.Length - 1
                                total(k) = 0
                                'tp += fix_point(get_grade(dbReader(subjname(k)), radSubject.Checked, subjabb(k)))
                            Next
                        End If
                    End If
                Next
                dgvEnterMarks.Rows.Add()
                dgvEnterMarks.Item("ADMNo", j).Value = get_id(admnos(j))
                dgvEnterMarks.Item("StudentName", j).Value = sname
                For k As Integer = 0 To subjabb.Length - 1

                    'new code start
                    Try
                        dgvEnterMarks.Item(subjname(k), j).Value = CInt(total(k))
                    Catch ex As Exception

                        Try
                            If Double.IsInfinity(total(k)) Then
                                total(k) = "X"
                                dgvEnterMarks.Item(subjname(k), j).Value = "X"
                            End If
                        Catch e As Exception

                        End Try

                        If total(k) = "X" Then
                            dgvEnterMarks.Item(subjname(k), j).Value = "X"
                        ElseIf total(k) = "Y" Then
                            dgvEnterMarks.Item(subjname(k), j).Value = "Y"
                        End If
                    End Try
                    'new code end
                Next
                dgvEnterMarks.Item("Total", j).Value = 0

                If total.Contains("X") Or total.Contains("Y") Then
                    dgvEnterMarks.Item("Total", j).Value = 0
                Else
                    For k As Integer = 0 To subjabb.Length - 1
                        'new code start
                        Try
                            dgvEnterMarks.Item("Total", j).Value += Math.Round(total(k), 0)
                        Catch ex As Exception

                        End Try
                        'new code end
                    Next
                End If


                dgvEnterMarks.Item("str_class", j).Value = c_stream
                Pbar.Increment(inc)
            Next
        End If
        Pbar.Visible = False
        Pbar.Increment(-100)
        clean()
        If Not form_4_mode Then
            compute_multi()
        Else
            multi_points()
        End If
        kcpe()
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5
            dgvEnterMarks.Item("VAP", k).Value = Format(vap(dgvEnterMarks.Item("ADMNo", k).Value, dgvEnterMarks.Item("MP", k).Value), "0.00")
        Next
        Dim cnt As Integer = 0
        dgvEnterMarks.Item("MP", dgvEnterMarks.Rows.Count - 2).Value = 0
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5
            If IsNumeric(dgvEnterMarks.Item("MP", k).Value) Then
                If dgvEnterMarks.Item("MP", k).Value > 0 Then
                    dgvEnterMarks.Item("MP", dgvEnterMarks.Rows.Count - 2).Value += dgvEnterMarks.Item("MP", k).Value
                    cnt += 1
                End If
            End If
        Next
        dgvEnterMarks.Item("MP", dgvEnterMarks.Rows.Count - 2).Value = Format(dgvEnterMarks.Item("MP", dgvEnterMarks.Rows.Count - 2).Value / cnt, "0.00")
        dgvEnterMarks.Item("MG", dgvEnterMarks.Rows.Count - 2).Value = get_points(dgvEnterMarks.Item("MP", dgvEnterMarks.Rows.Count - 2).Value)
        cnt = 0
        dgvEnterMarks.Item("MM", dgvEnterMarks.Rows.Count - 2).Value = 0
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 4
            If IsNumeric(dgvEnterMarks.Item("MM", k).Value) Then
                If dgvEnterMarks.Item("MM", k).Value > 0 Then
                    dgvEnterMarks.Item("MM", dgvEnterMarks.Rows.Count - 2).Value += dgvEnterMarks.Item("MM", k).Value
                    cnt += 1
                End If
            End If
        Next
        dgvEnterMarks.Item("MM", dgvEnterMarks.Rows.Count - 2).Value = Format(dgvEnterMarks.Item("MM", dgvEnterMarks.Rows.Count - 2).Value / cnt, "0.00")
        cnt = 0
        dgvEnterMarks.Item("Total", dgvEnterMarks.Rows.Count - 2).Value = 0
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 4
            If IsNumeric(dgvEnterMarks.Item("Total", k).Value) Then
                If dgvEnterMarks.Item("Total", k).Value > 0 Then
                    dgvEnterMarks.Item("Total", dgvEnterMarks.Rows.Count - 2).Value += dgvEnterMarks.Item("Total", k).Value
                    cnt += 1
                End If
            End If
        Next
        dgvEnterMarks.Item("Total", dgvEnterMarks.Rows.Count - 2).Value = Format(dgvEnterMarks.Item("Total", dgvEnterMarks.Rows.Count - 2).Value / cnt, "0.00")
        positions()
    End Sub
    Private Sub clean()
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            For m As Integer = 0 To subjabb.Length - 1
                Try
                    If dgvEnterMarks.Item(subjname(m), k).Value = 0 Then
                        dgvEnterMarks.Item(subjname(m), k).Value = "-"

                        '  *** New code starts here ***


                    End If
                Catch ex As Exception

                End Try
            Next
        Next
    End Sub
    Private Sub positions()
        ReDim stream_no(streams.Length - 1)
        For j = 0 To streams.Length - 1
            stream_no(j) = 0
        Next
        Dim pos As Integer = 0
        Dim EndOfRows As Integer
        If mode Then
            EndOfRows = dgvEnterMarks.Rows.Count - 5
        Else
            EndOfRows = dgvEnterMarks.Rows.Count - 1
        End If
        For i As Integer = 0 To EndOfRows
            If i > 0 Then
                If dgvEnterMarks.Item(sortby, i).Value <> dgvEnterMarks.Item(sortby, i - 1).Value Then
                    pos = i + 1
                    dgvEnterMarks.Item("Overall", i).Value = pos
                Else
                    dgvEnterMarks.Item("Overall", i).Value = pos
                End If
            Else
                pos += 1
                dgvEnterMarks.Item("Overall", i).Value = pos
            End If
            Dim stream_pos(streams.Length - 1) As Integer
            For j = 0 To streams.Length - 1
                If dgvEnterMarks.Item("str_class", i).Value = streams(j) Then
                    If stream_no(j) > 0 Then
                        If previous_person_sortby_value(streams(j), i) = dgvEnterMarks.Item(sortby, i).Value Then
                            dgvEnterMarks.Item("Position", i).Value = stream_no(j)
                            stream_pos(j) += 1
                        Else
                            dgvEnterMarks.Item("Position", i).Value = no_of_persons_for_stream(streams(j), i)
                            stream_no(j) = dgvEnterMarks.Item("Position", i).Value
                        End If
                    Else
                        stream_no(j) += 1
                        stream_pos(j) = stream_no(j)
                        dgvEnterMarks.Item("Position", i).Value = stream_no(j)
                    End If
                End If
            Next
        Next
        For k As Integer = 0 To streams.Length - 1
            stream_no(k) = 1
        Next
        For k As Integer = 0 To EndOfRows
            For s As Integer = 0 To streams.Length - 1
                If dgvEnterMarks.Item("str_class", k).Value = streams(s) Then
                    stream_no(s) += 1
                End If
            Next
        Next
        class_out_of = dgvEnterMarks.Rows.Count
    End Sub

    Private Function no_of_persons_for_stream(ByVal s As String, ByVal row As Integer)
        no_of_persons_for_stream = 0
        For k As Integer = row To 0 Step -1
            If dgvEnterMarks.Item("str_class", k).Value = s Then
                no_of_persons_for_stream += 1
            End If
        Next
    End Function
    Private Function previous_person_sortby_value(ByVal s As String, ByVal row As Integer)
        For k As Integer = row - 1 To 0 Step -1
            If dgvEnterMarks.Item("str_class", k).Value = s Then
                previous_person_sortby_value = dgvEnterMarks.Item(sortby, k).Value
                Exit Function
            End If
        Next
        previous_person_sortby_value = 0
    End Function
    Private Sub totals()
        Dim total, tp, cnt As Integer
        Dim l As Integer
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            total = 0
            cnt = 0
            tp = 0
            For c As Integer = 0 To compulsory.Length - 1
                If IsNumeric(dgvEnterMarks.Item(compulsory(c), k).Value) Then
                    total += dgvEnterMarks.Item(compulsory(c), k).Value
                    tp += fix_point(get_grade(dgvEnterMarks.Item(compulsory(c), k).Value, radSubject.Checked, compulsory(c)))
                    cnt += 1
                End If
            Next
            '###########add the 2 best performed science and the second best###################
            For c As Integer = 0 To sciences.Length - 1
                If Not IsNumeric(dgvEnterMarks.Item(sciences(c), k).Value) Then
                    science = False
                End If
            Next
            Dim sci(sciences.Length - 1), temp, temp_name
            Dim hum(humanities.Length - 1), app(applieds.Length - 1) As Integer
            ReDim app_names(applieds.Length - 1), hum_names(humanities.Length - 1), sci_names(sciences.Length - 1)
            For c As Integer = 0 To sciences.Length - 1
                sci(c) = dgvEnterMarks.Item(sciences(c), k).Value
                sci_names(c) = sciences(c)
            Next
            If science Then
                '###########SorT them#############
                For c As Integer = 0 To sciences.Length - 1
                    For l = k + 1 To sciences.Length - 1
                        If sci(c) < sci(l) Then
                            temp = sci(c)
                            temp_name = sci_names(c)
                            sci(k) = sci(l)
                            sci_names(k) = sci_names(l)
                            sci(l) = temp
                            sci_names(l) = temp_name
                        End If
                    Next
                Next
                For c As Integer = 0 To sciences.Length - 1
                    If c < sciences.Length - 1 Then
                        total += sci(c)
                        tp += fix_point(get_grade(sci(c), radSubject.Checked, sci_names(c)))
                        cnt += 1
                    End If
                Next
            Else
                For c As Integer = 0 To sciences.Length - 1
                    If IsNumeric(dgvEnterMarks.Item(sciences(c), k).Value) Then
                        total += dgvEnterMarks.Item(sciences(c), k).Value
                        tp += fix_point(get_grade(dgvEnterMarks.Item(sci_names(c), k).Value, radSubject.Checked, sci_names(c)))
                        cnt += 1
                    End If
                Next
            End If
            '###########get highest and second best performed humanity ##################
            Dim count As Integer = humanities.Length
            For c As Integer = 0 To humanities.Length - 1
                hum_names(c) = humanities(c)
            Next
            For c As Integer = 0 To humanities.Length - 1
                If Not IsNumeric(dgvEnterMarks.Item(humanities(c), k).Value) Then
                    count -= 1
                End If
            Next
            If count > 1 Then
                humanity = True
                l = 0
                For c As Integer = 0 To humanities.Length - 1
                    If IsNumeric(dgvEnterMarks.Item(humanities(c), k).Value) Then
                        hum(c) = dgvEnterMarks.Item(humanities(c), k).Value
                    End If
                Next
                For c As Integer = 0 To hum.Length - 1
                    For l = k + 1 To hum.Length - 1
                        If hum(c) < hum(l) Or (Not IsNumeric(hum(c)) And IsNumeric(hum(l))) Then
                            temp = hum(c)
                            temp_name = hum_names(c)
                            hum(c) = hum(l)
                            hum_names(c) = hum_names(l)
                            hum_names(l) = temp_name
                            hum(l) = temp
                        End If
                    Next
                Next
                total += hum(0)
                tp += fix_point(get_grade(hum(0), radSubject.Checked, hum_names(0)))
                cnt += 1
            Else
                For c As Integer = 0 To humanities.Length - 1
                    Try
                        If IsNumeric(dbreader(humanities(c))) Then
                            total += dbreader(humanities(c))
                            tp += fix_point(get_grade(dgvEnterMarks.Item(humanities(c), k).Value, radSubject.Checked, hum_names(c)))
                            cnt += 1
                        End If
                    Catch ex As Exception

                    End Try
                Next
            End If
            '########### get highest performed applied subject ##################
            For c As Integer = 0 To applieds.Length - 1
                app_names(c) = applieds(c)
            Next
            count = 0
            l = 0
            For c As Integer = 0 To applieds.Length - 1
                If IsNumeric(dgvEnterMarks.Item(applieds(c), k).Value) Then
                    count += 1
                End If
            Next
            If count > 0 Then
                applied = True
                For c As Integer = 0 To applieds.Length - 1
                    If IsNumeric(dgvEnterMarks.Item(applieds(c), k).Value) Then
                        app(l) = dgvEnterMarks.Item(applieds(c), k).Value
                        app_names(l) = applieds(c)
                        l += 1
                    End If
                Next
                For c As Integer = 0 To app.Length - 1
                    For l = k + 1 To app.Length - 1
                        If app(c) < app(l) Then
                            temp = app(c)
                            temp_name = app_names(c)
                            app(c) = app(l)
                            app_names(k) = app_names(l)
                            app(l) = temp
                            app_names(l) = temp_name
                        End If
                    Next
                Next
            End If
            If science And humanity And applied Then
                If sci(2) > hum(1) Then
                    If sci(2) > app(0) Then
                        total += sci(2)
                        tp += fix_point(get_grade(dgvEnterMarks.Item(sci_names(2), k).Value, radSubject.Checked, sci_names(2)))
                        cnt += 1
                    Else
                        total += app(0)
                        tp += fix_point(get_grade(dgvEnterMarks.Item(app_names(0), k).Value, radSubject.Checked, app_names(0)))
                        cnt += 1
                    End If
                Else
                    If hum(1) > app(0) Then
                        total += hum(1)
                        tp += fix_point(get_grade(hum(1), radSubject.Checked, hum_names(1)))
                        cnt += 1
                    Else
                        total += app(0)
                        tp += fix_point(get_grade(app(0), radSubject.Checked, app_names(0)))
                        cnt += 1
                    End If
                End If
            ElseIf science And humanity Then
                If sci(2) > hum(1) Then
                    total += sci(2)
                    tp += fix_point(get_grade(sci(2), radSubject.Checked, sci_names(2)))
                    cnt += 1
                Else
                    total += hum(1)
                    tp += fix_point(get_grade(hum(1), radSubject.Checked, hum_names(1)))
                    cnt += 1
                End If
            ElseIf science And applied Then
                If sci(2) > app(0) Then
                    total += sci(2)
                    tp += fix_point(get_grade(sci(2), radSubject.Checked, sci_names(2)))
                    cnt += 1
                Else
                    total += app(0)
                    tp += fix_point(get_grade(app(0), radSubject.Checked, app_names(0)))
                    cnt += 1
                End If
            ElseIf applied And humanity Then
                If app(0) > hum(1) Then
                    total += app(0)
                    tp += fix_point(get_grade(app(0), radSubject.Checked, app_names(0)))
                    cnt += 1
                Else
                    total += hum(1)
                    tp += fix_point(get_grade(hum(1), radSubject.Checked, hum_names(1)))
                    cnt += 1
                End If
            ElseIf science Then
                total += sci(2)
                tp += fix_point(get_grade(sci(2), radSubject.Checked, sci_names(2)))
                cnt += 1
            ElseIf humanity Then
                total += hum(1)
                tp += fix_point(get_grade(hum(1), radSubject.Checked, hum_names(1)))
                cnt += 1
            ElseIf applied Then
                total += app(0)
                tp += fix_point(get_grade(app(0), radSubject.Checked, app_names(0)))
                cnt += 1
            End If
            dgvEnterMarks.Item("Total", k).Value = total
            If cnt > 0 Then
                dgvEnterMarks.Item("MM", k).Value = Format(total / cnt, "0.00")
            Else
                dgvEnterMarks.Item("MM", k).Value = "0.00"
            End If
            dgvEnterMarks.Item("TP", k).Value = tp
            If cnt > 0 Then
                dgvEnterMarks.Item("MP", k).Value = Format(tp / cnt, "0.00")
            Else
                dgvEnterMarks.Item("MP", k).Value = "0.00"
            End If
            dgvEnterMarks.Item("MG", k).Value = get_points(dgvEnterMarks.Item("MP", k).Value)
        Next
    End Sub

    Private Sub multi_points()
        index_no()
        kcpe()
        mean_mark()
        subject_entries()
        'totals()
        mean_point()
        meangrade()
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            dgvEnterMarks.Item(sortby, k).Value = Convert.ToDouble(dgvEnterMarks.Item("Total", k).Value)
        Next
        dgvEnterMarks.Sort(dgvEnterMarks.Columns(sortby), System.ComponentModel.ListSortDirection.Descending)

        mean_score()
        total_means()
        mean_grade()
        mean_points()
        mean_grade_points()
        xStudents.Clear()
    End Sub

    Private Sub compute_multi()
        index_no()
        kcpe()
        mean_mark()
        subject_entries()
        If Not form_4_mode Then
            total_points()
        End If
        mean_point()
        meangrade()
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            dgvEnterMarks.Item(sortby, k).Value = Convert.ToDouble(dgvEnterMarks.Item(sortby, k).Value)
        Next
        dgvEnterMarks.Sort(dgvEnterMarks.Columns(sortby), System.ComponentModel.ListSortDirection.Descending)
        positions()
        mean_score()
        mean_grade()
        mean_points()
        mean_grade_points()
        xStudents.Clear()
    End Sub
    Private Sub get_streams(ByVal class_form As String)
        If qread("SELECT stream FROM class_stream WHERE class='" & ret_name(class_form) & "'") Then
            ReDim streams(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read
                streams(i) = dbreader("stream")
                i += 1
            End While
        End If
    End Sub
    Dim subj_out_of(subjabb.Length - 1)()

    Private Sub loadSubjectsOutOf()
        For k As Integer = 0 To subjabb.Length - 1
            ReDim subj_out_of(k)(streams.Length - 1)
            For i As Integer = 0 To subj_out_of(k).Length - 1
                subj_out_of(k)(i) = SubjectOutOf(subjname(k), tm, yr, exam_name, ret_name(class_form), streams(i))
            Next
        Next
    End Sub
    Private Function IndexOf(ByVal str As String)
        For k As Integer = 0 To streams.Length - 1
            If streams(k) = str Then
                Return k
            End If
        Next
        Return 0
    End Function
    Private Function markOutOf(ByVal subj As String, ByVal str As String) As Double
        For k As Integer = 0 To subjabb.Length - 1
            If subj = subjname(k) Then
                Return subj_out_of(k)(IndexOf(str))
            End If
        Next
    End Function
    Dim mark As Double = get_total_mark(exam_name, tm)
    Private Sub load_entered()
        mark = get_total_mark(exam_name, tm, yr)
        get_streams(class_form)
        loadSubjectsOutOf()
        If form_4_mode And Not formfourmode() Then
            Exit Sub
        End If
        query = "SELECT * FROM " & table & " WHERE (Examination='" & escape_string(exam_name) & "' AND Term='" & tm & "' AND Year='" & yr & "' AND class='" & escape_string(ret_name(class_form)) & "') ORDER BY Total DESC"
        If qread(query) Then
            Try
                ReDim subjects_7(dbreader.RecordsAffected - 1)(8)
            Catch ex As Exception
                failure("Looks Like You Are Trying To Analyze Results For An Examination For Which No Marks Have Been Entered!")
                Me.Close()
            End Try
            For l As Integer = 0 To dbreader.RecordsAffected - 1
                ReDim subjects_7(l)(8)
                For w As Integer = 0 To subjects_7(l).Length - 1
                    subjects_7(l)(w) = 0
                Next
            Next
            Pbar.Visible = True
            Dim inc As Integer = dbreader.RecordsAffected / 100
            Dim total As Integer
            Try
                ReDim stream_no(streams.Length - 1)
            Catch ex As Exception

            End Try

            Dim i, tp, j As Integer
            i = 0
            Try
                For j = 0 To streams.Length - 1
                    stream_no(j) = 0
                Next
            Catch ex As Exception

            End Try

            dgvEnterMarks.Rows.Clear()
            While dbreader.Read
                counter = 0
                total = 0
                tp = 0
                dgvEnterMarks.Rows.Add()
                dgvEnterMarks.Item("ADMNo", i).Value = get_id(dbreader("ADMNo"))
                dgvEnterMarks.Item("StudentName", i).Value = dbreader("StudentName")
                dgvEnterMarks.Item("str_class", i).Value = dbreader("Stream")
                Try
                    For j = 0 To streams.Length - 1
                        If dbreader("Stream") = streams(j) Then
                            dgvEnterMarks.Item("Position", i).Value = stream_no(j) + 1
                            stream_no(j) += 1
                        End If
                    Next
                Catch ex As Exception

                End Try
                subjects_7(i)(8) = dbreader("ADMNo")
                dgvEnterMarks.Item("Overall", i).Value = i + 1
                Dim out_of As Double
                If form_4_mode Then
                    science = True
                    Dim temp_name As String
                    Dim temp, l As Integer
                    '##############get total of first compulsory subjects#################
                    For k As Integer = 0 To compulsory.Length - 1
                        If IsNumeric(dbreader(compulsory(k))) Then
                            out_of = markOutOf(compulsory(k), dbreader("Stream"))
                            total += (dbreader(compulsory(k)) / out_of) * mark
                            tp += fix_point(get_grade((dbreader(compulsory(k)) / out_of) * 100, radSubject.Checked, compulsory(k)))
                            subjects_7(i)(counter) = compulsory(k)
                            counter += 1
                        End If
                    Next
                    '###########add the 2 best performed science and the second best###################
                    For k As Integer = 0 To sciences.Length - 1
                        If Not IsNumeric(dbreader(sciences(k))) Then
                            science = False
                        End If
                    Next
                    Dim sci(sciences.Length - 1)
                    Dim hum(humanities.Length - 1), app(applieds.Length - 1) As Integer
                    ReDim app_names(applieds.Length - 1), hum_names(humanities.Length - 1), sci_names(sciences.Length - 1)
                    For k As Integer = 0 To sciences.Length - 1
                        sci(k) = dbreader(sciences(k))
                        sci_names(k) = sciences(k)
                    Next
                    If science Then
                        '###########SorT them#############
                        For k As Integer = 0 To sciences.Length - 1
                            For l = k + 1 To sciences.Length - 1
                                If sci(k) < sci(l) Then
                                    temp = sci(k)
                                    temp_name = sci_names(k)
                                    sci(k) = sci(l)
                                    sci_names(k) = sci_names(l)
                                    sci(l) = temp
                                    sci_names(l) = temp_name
                                End If
                            Next
                        Next
                        For k As Integer = 0 To sciences.Length - 1
                            If k < sciences.Length - 1 Then
                                out_of = markOutOf(sci_names(k), dbreader("Stream"))
                                total += (sci(k) / out_of) * mark
                                tp += fix_point(get_grade((sci(k) / out_of) * 100, radSubject.Checked, sci_names(k)))
                                subjects_7(i)(counter) = sci_names(k)
                                counter += 1
                            End If
                        Next
                    Else
                        For k As Integer = 0 To sciences.Length - 1
                            If IsNumeric(dbreader(sciences(k))) Then
                                out_of = markOutOf(sci_names(k), dbreader("Stream"))
                                total += (dbreader(sciences(k)) / out_of) * mark
                                tp += fix_point(get_grade((dbreader(sciences(k)) / out_of) * 100, radSubject.Checked, sci_names(k)))
                                subjects_7(i)(counter) = sciences(k)
                                counter += 1
                            End If
                        Next
                    End If
                    '###########get highest and second best performed humanity ##################
                    Dim count As Integer = humanities.Length
                    For k As Integer = 0 To humanities.Length - 1
                        hum_names(k) = humanities(k)
                    Next
                    For k As Integer = 0 To humanities.Length - 1
                        If Not IsNumeric(dbreader(humanities(k))) Then
                            count -= 1
                        End If
                    Next
                    If count > 1 Then
                        humanity = True
                        l = 0
                        For k As Integer = 0 To humanities.Length - 1
                            If IsNumeric(dbreader(humanities(k))) Then
                                hum(k) = dbreader(humanities(k))
                            End If
                        Next
                        For k As Integer = 0 To hum.Length - 1
                            For l = k + 1 To hum.Length - 1
                                If hum(k) < hum(l) Or (Not IsNumeric(hum(k)) And IsNumeric(hum(l))) Then
                                    temp = hum(k)
                                    temp_name = hum_names(k)
                                    hum(k) = hum(l)
                                    hum_names(k) = hum_names(l)
                                    hum_names(l) = temp_name
                                    hum(l) = temp
                                End If
                            Next
                        Next
                        out_of = markOutOf(hum_names(0), dbreader("Stream"))
                        total += (hum(0) / out_of) * mark
                        tp += fix_point(get_grade((hum(0) / out_of) * 100, radSubject.Checked, hum_names(0)))
                        subjects_7(i)(counter) = hum_names(0)
                        counter += 1
                    Else
                        For k As Integer = 0 To humanities.Length - 1
                            If IsNumeric(dbreader(humanities(k))) Then
                                out_of = markOutOf(hum_names(k), dbreader("Stream"))
                                total += (dbreader(humanities(k)) / out_of) * mark
                                tp += fix_point(get_grade((dbreader(humanities(k)) / out_of) * 100, radSubject.Checked, hum_names(k)))
                                subjects_7(i)(counter) = humanities(k)
                                counter += 1
                            End If
                        Next
                    End If
                    '########### get highest performed applied subject ##################
                    For k As Integer = 0 To applieds.Length - 1
                        app_names(k) = applieds(k)
                    Next
                    count = 0
                    l = 0
                    For k As Integer = 0 To applieds.Length - 1
                        If IsNumeric(dbreader(applieds(k))) Then
                            count += 1
                        End If
                    Next
                    If count > 0 Then
                        applied = True
                        For k As Integer = 0 To applieds.Length - 1
                            If IsNumeric(dbreader(applieds(k))) Then
                                app(l) = dbreader(applieds(k))
                                app_names(l) = applieds(k)
                                l += 1
                            End If
                        Next
                        For k As Integer = 0 To app.Length - 1
                            For l = k + 1 To app.Length - 1
                                If app(k) < app(l) Then
                                    temp = app(k)
                                    temp_name = app_names(k)
                                    app(k) = app(l)
                                    app_names(k) = app_names(l)
                                    app(l) = temp
                                    app_names(l) = temp_name
                                End If
                            Next
                        Next
                    End If
                    If science And humanity And applied Then
                        If sci(2) > hum(1) Then
                            If sci(2) > app(0) Then
                                out_of = markOutOf(sci_names(2), dbreader("Stream"))
                                total += (sci(2) / out_of) * mark
                                tp += fix_point(get_grade((dbreader(sci_names(2)) / out_of) * 100, radSubject.Checked, sci_names(2)))
                                subjects_7(i)(counter) = sci_names(2)
                                counter += 1
                            Else
                                out_of = markOutOf(app_names(0), dbreader("Stream"))
                                total += (app(0) / out_of) * mark
                                tp += fix_point(get_grade((dbreader(app_names(0)) / out_of) * 100, radSubject.Checked, app_names(0)))
                                subjects_7(i)(counter) = app_names(0)
                                counter += 1
                            End If
                        Else
                            If hum(1) > app(0) Then
                                out_of = markOutOf(hum_names(1), dbreader("Stream"))
                                total += (hum(1) / out_of) * mark
                                tp += fix_point(get_grade((hum(1) / out_of) * 100, radSubject.Checked, hum_names(1)))
                                subjects_7(i)(counter) = hum_names(1)
                                counter += 1
                            Else
                                out_of = markOutOf(app_names(0), dbreader("Stream"))
                                total += (app(0) / out_of) * mark
                                tp += fix_point(get_grade((app(0) / out_of) * 100, radSubject.Checked, app_names(0)))
                                subjects_7(i)(counter) = app_names(0)
                                counter += 1
                            End If
                        End If
                    ElseIf science And humanity Then
                        If sci(2) > hum(1) Then
                            out_of = markOutOf(sci_names(2), dbreader("Stream"))
                            total += (sci(2) / out_of) * mark
                            tp += fix_point(get_grade((sci(2) / out_of) * 100, radSubject.Checked, sci_names(2)))
                            subjects_7(i)(counter) = sci_names(2)
                            counter += 1
                        Else
                            out_of = markOutOf(hum_names(1), dbreader("Stream"))
                            total += (hum(1) / out_of) * mark
                            tp += fix_point(get_grade((hum(1) / mark) * 100, radSubject.Checked, hum_names(1)))
                            subjects_7(i)(counter) = hum_names(1)
                            counter += 1
                        End If
                    ElseIf science And applied Then
                        If sci(2) > app(0) Then
                            out_of = markOutOf(sci_names(2), dbreader("Stream"))
                            total += (sci(2) / out_of) * mark
                            tp += fix_point(get_grade((sci(2) / out_of) * 100, radSubject.Checked, sci_names(2)))
                            subjects_7(i)(counter) = sci_names(2)
                            counter += 1
                        Else
                            out_of = markOutOf(app_names(0), dbreader("Stream"))
                            total += (app(0) / out_of) * mark
                            tp += fix_point(get_grade((app(0) / out_of) * 100, radSubject.Checked, app_names(0)))
                            subjects_7(i)(counter) = app_names(0)
                            counter += 1
                        End If
                    ElseIf applied And humanity Then
                        If app(0) > hum(1) Then
                            out_of = markOutOf(app_names(0), dbreader("Stream"))
                            total += (app(0) / out_of) * mark
                            tp += fix_point(get_grade((app(0) / out_of) * 100, radSubject.Checked, app_names(0)))
                            subjects_7(i)(counter) = app_names(0)
                            counter += 1
                        Else
                            out_of = markOutOf(hum_names(1), dbreader("Stream"))
                            total += (hum(1) / out_of) * mark
                            tp += fix_point(get_grade((hum(1) / out_of) * 100, radSubject.Checked, hum_names(1)))
                            subjects_7(i)(counter) = hum_names(1)
                            counter += 1
                        End If
                    ElseIf science Then
                        out_of = markOutOf(sci_names(2), dbreader("Stream"))
                        total += (sci(2) / out_of) * mark
                        tp += fix_point(get_grade((sci(2) / out_of) * 100, radSubject.Checked, sci_names(2)))
                        subjects_7(i)(counter) = sci_names(2)
                        counter += 1
                    ElseIf humanity Then
                        out_of = markOutOf(hum_names(1), dbreader("Stream"))
                        total += (hum(1) / out_of) * mark
                        tp += fix_point(get_grade((hum(1) / out_of) * 100, radSubject.Checked, hum_names(1)))
                        subjects_7(i)(counter) = hum_names(1)
                        counter += 1
                    ElseIf applied Then
                        out_of = markOutOf(app_names(0), dbreader("Stream"))
                        total += (app(0) / out_of) * mark
                        tp += fix_point(get_grade((app(0) / out_of) * 100, radSubject.Checked, app_names(0)))
                        subjects_7(i)(counter) = app_names(0)
                        counter += 1
                    End If
                Else
                    For k As Integer = 0 To subjabb.Length - 1
                        If IsNumeric(dbreader(subjname(k))) Then
                            out_of = markOutOf(subjname(k), dbreader("Stream"))
                            If dbreader(subjname(k)) > 0 And out_of Then
                                total += (dbreader(subjname(k)) / out_of) * mark
                            End If
                            tp += fix_point(get_grade((dbreader(subjname(k)) / out_of) * 100, radSubject.Checked, subjabb(k)))
                        End If
                    Next
                End If
                For k As Integer = 0 To subjabb.Length - 1
                    If Not IsNumeric(dbreader(subjname(k))) Then
                        dgvEnterMarks.Item(subjname(k), i).Value = dbreader(subjname(k))
                    Else
                        out_of = markOutOf(subjname(k), dbreader("Stream"))
                        Dim num As Double = (dbreader(subjname(k)) / out_of) * mark
                        If num < 10 Then
                            dgvEnterMarks.Item(subjname(k), i).Value = "0" & Math.Round(num, 0)
                        Else
                            dgvEnterMarks.Item(subjname(k), i).Value = Math.Round(num, 0)
                        End If

                    End If
                Next
                dgvEnterMarks.Item("Total", i).Value = total
                Dim counts As Integer = 0
                For k As Integer = 0 To subjabb.Length - 1
                    If dgvEnterMarks.Item(subjname(k), i).value.ToString <> "-" Then
                        counts += 1
                    End If
                Next
                If counts >= 7 Then
                    dgvEnterMarks.Item("TP", i).Value = tp
                Else
                    dgvEnterMarks.Item("TP", i).Value = "0"
                End If
                For k As Integer = 0 To compulsory.Length - 1
                    If Not IsNumeric(dgvEnterMarks.Item(compulsory(k), i).Value) Then
                        dgvEnterMarks.Item("TP", i).Value = "0"
                    End If
                Next
                counts = 0
                For k As Integer = 0 To sciences.Length - 1
                    If Not IsNumeric(dgvEnterMarks.Item(sciences(k), i).Value) Then
                        counts += 1
                    End If
                Next
                If counts > 1 Then
                    dgvEnterMarks.Item("TP", i).Value = "0"
                End If
                i += 1
                Pbar.Increment(inc)
            End While
            dgvEnterMarks.Sort(dgvEnterMarks.Columns("Total"), System.ComponentModel.ListSortDirection.Descending)
            i = 0
            For j = 0 To streams.Length - 1
                stream_no(j) = 0
            Next
            For i = 0 To dgvEnterMarks.Rows.Count - 1
                Try
                    For j = 0 To streams.Length - 1
                        If dgvEnterMarks.Item("str_class", i).Value = streams(j) Then
                            dgvEnterMarks.Item("Position", i).Value = stream_no(j) + 1
                            stream_no(j) += 1
                        End If
                    Next
                Catch ex As Exception

                End Try

            Next
            For i = 0 To dgvEnterMarks.Rows.Count - 1
                dgvEnterMarks.Item("Overall", i).Value = i + 1
            Next
            compute()
            For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5
                dgvEnterMarks.Item("VAP", k).Value = Format(vap(dgvEnterMarks.Item("ADMNo", k).Value, dgvEnterMarks.Item("MP", k).Value), "0.00")
            Next
            class_out_of = i
        End If
        Pbar.Increment(-100)
        Pbar.Visible = False
        If show_split Then
            For k As Integer = 0 To subjabb.Length - 1
                get_split_subjects(subjects(k))
                For s As Integer = 0 To splits.Length - 1
                    For row As Integer = 0 To dgvEnterMarks.Rows.Count - 1
                        qread("SELECT `" & class_form & "_" & splits(s) & "` FROM exam_split_subject_results WHERE ADMNo='" & dgvEnterMarks.Item("ADMNo", row).Value & "' AND Examination='" & escape_string(exam_name) & "' AND Term='" & tm & "' AND Year='" & yr & "'")
                        If dbreader.RecordsAffected > 0 Then
                            dbreader.Read()
                            dgvEnterMarks.Item(splits(s), row).Value = dbreader(class_form & "_" & splits(s))
                        End If
                    Next
                Next
            Next
        End If
        If grade Then
            gradeview()
        End If
    End Sub

    Private Function vap(ByVal adm As String, ByVal mp As Double) As Double
        qread("SELECT marks_attained_primary FROM students WHERE admin_no='" & adm & "'")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            If Not dbreader("marks_attained_primary") = "--" And Not dbreader("marks_attained_primary") = String.Empty Then
                vap = fix_point(get_grade((dbreader("marks_attained_primary") / 500) * 100, False, String.Empty))
                vap = mp - vap
            End If
        Else
            vap = 0.0
        End If
        Return vap
    End Function


    Private Function vapgrade(ByVal adm As String) As String
        qread("SELECT marks_attained_primary FROM students WHERE admin_no ='" & adm & "'")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            vapgrade = get_grade((dbreader("marks_attained_primary") / 500) * 100, False, String.Empty)
        Else
            vapgrade = "E"
        End If
    End Function

    Private Function indexno(ByVal adm As String)
        qread("SELECT indexno FROM students WHERE admin_no='" & adm & "'")
        Try
            dbreader.Read()
            indexno = dbreader("indexno")
        Catch ex As Exception
            Return "000"
        End Try
    End Function
    Private Sub index_no()
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            dgvEnterMarks.Item("INDEX", k).Value = indexno(dgvEnterMarks.Item("ADMNo", k).Value)
        Next
    End Sub

    Private Sub convert_to_double()
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            dgvEnterMarks.Item(sortby, k).Value = Convert.ToDouble(dgvEnterMarks.Item(sortby, k).Value)
        Next
    End Sub
    Private Sub compute()
        index_no()
        mean_mark()
        subject_entries()
        If Not form_4_mode Then
            total_points()
        End If
        mean_point()
        meangrade()
        convert_to_double()
        Try
            dgvEnterMarks.Sort(dgvEnterMarks.Columns(sortby), System.ComponentModel.ListSortDirection.Descending)
        Catch ex As Exception

        End Try

        If sortby = "MP" Then
            For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
                dgvEnterMarks.Item("MP", k).Value = Format(dgvEnterMarks.Item("MP", k).Value, "0.00")
            Next
        End If
        positions()
        mean_score()
        total_means()

        mean_grade()
        mean_points()
        kcpe()
        mean_grade_points()
    End Sub

    Private Sub mean_grade_points()
        dgvEnterMarks.Rows.Add()
        dgvEnterMarks.Item("StudentName", dgvEnterMarks.Rows.Count - 1).Value = "MEAN GRADE (M. POINTS)"
        For k As Integer = 0 To subjabb.Length - 1
            If IsNumeric(dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 2).value) Then
                dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = get_points(dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 2).value)
            Else
                dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = "--"
            End If
        Next
    End Sub
    Private Sub mean_mark()
        Dim cnt As Integer = 0
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            cnt = 0
            For s As Integer = 0 To subjabb.Length - 1
                If IsNumeric(dgvEnterMarks.Item(subjname(s), k).value) Then
                    cnt += 1
                ElseIf dgvEnterMarks.Item(subjname(s), k).value = "X" Or dgvEnterMarks.Item(subjname(s), k).value = "Y" Or dgvEnterMarks.Item(subjname(s), k).value = "x" Or dgvEnterMarks.Item(subjname(s), k).value = "y" Then
                    cnt += 1
                End If
            Next

            If Not form_4_mode Then
                If dgvEnterMarks.Item("Total", k).Value <> 0 And IsNumeric(dgvEnterMarks.Item("Total", k).Value) Then
                    dgvEnterMarks.Item("MM", k).Value = Format(dgvEnterMarks.Item("Total", k).Value / cnt, "0.00")
                Else
                    dgvEnterMarks.Item("MM", k).Value = "0"
                End If
            Else
                If dgvEnterMarks.Item("Total", k).Value <> 0 And IsNumeric(dgvEnterMarks.Item("Total", k).Value) Then
                    dgvEnterMarks.Item("MM", k).Value = Format(dgvEnterMarks.Item("Total", k).Value / 7, "0.00")
                Else
                    dgvEnterMarks.Item("MM", k).Value = "0"
                End If
            End If
            'new code start
            If xStudents.Contains(dgvEnterMarks.Item("ADMNo", k).Value.ToString()) Then
                dgvEnterMarks.Item("MM", k).Value = "0"
            End If
            'new code end
        Next



        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            dgvEnterMarks.Item("MM", k).Value = Convert.ToDouble(dgvEnterMarks.Item("MM", k).Value)
        Next
    End Sub
    Private Sub kcpe()
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 4
            dgvEnterMarks.Item("KCPE", k).Value = get_kcpe_marks(dgvEnterMarks.Item("ADMNo", k).Value)
        Next
    End Sub

    Private Sub meangrade()
        Dim grade As String
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            grade = Nothing
            If mode Then
                If form_4_mode Then
                    If get_compulsory() Then
                        For c As Integer = 0 To compulsory.Length - 1
                            If dgvEnterMarks.Item(remove_wild(compulsory(c)), k).value.ToString = "X" Or dgvEnterMarks.Item(remove_wild(compulsory(c)), k).value.ToString = "Y" Or dgvEnterMarks.Item(remove_wild(compulsory(c)), k).value.ToString = "x" Or dgvEnterMarks.Item(remove_wild(compulsory(c)), k).value.ToString = "y" Then
                                grade = dgvEnterMarks.Item(remove_wild(compulsory(c)), k).value
                            End If
                        Next
                    End If
                    If grade <> Nothing Then
                        dgvEnterMarks.Item("MG", k).Value = grade
                    Else
                        Dim cnt As Integer = 0
                        If get_sciences() Then
                            For s As Integer = 0 To sciences.Length - 1
                                If dgvEnterMarks.Item(remove_wild(sciences(s)), k).value.ToString = "X" Or dgvEnterMarks.Item(remove_wild(sciences(s)), k).value.ToString = "Y" Or dgvEnterMarks.Item(remove_wild(sciences(s)), k).value.ToString = "x" Or dgvEnterMarks.Item(remove_wild(sciences(s)), k).value.ToString = "y" Then
                                    cnt += 1
                                    grade = dgvEnterMarks.Item(remove_wild(sciences(s)), k).value
                                End If
                            Next
                        End If
                        If cnt > 1 Then
                            dgvEnterMarks.Item("MG", k).Value = grade
                        Else
                            cnt = 0
                            grade = Nothing
                            Dim count As Integer = 0
                            If get_humanity() Then
                                For s As Integer = 0 To humanities.Length - 1
                                    If IsNumeric(dgvEnterMarks.Item(remove_wild(humanities(s)), k).value) Then
                                        count += 1
                                    End If
                                    If dgvEnterMarks.Item(remove_wild(humanities(s)), k).value.ToString = "X" Or dgvEnterMarks.Item(remove_wild(humanities(s)), k).value.ToString = "Y" Or dgvEnterMarks.Item(remove_wild(humanities(s)), k).value.ToString = "x" Or dgvEnterMarks.Item(remove_wild(humanities(s)), k).value.ToString = "y" Then
                                        cnt += 1
                                        grade = dgvEnterMarks.Item(remove_wild(humanities(s)), k).value
                                    End If
                                Next
                            End If
                            If count = 0 Then
                                If grade <> Nothing Then
                                    dgvEnterMarks.Item("MG", k).Value = grade
                                Else
                                    dgvEnterMarks.Item("MG", k).Value = "-"
                                End If
                            Else
                                dgvEnterMarks.Item("MG", k).Value = get_points(dgvEnterMarks.Item("MP", k).Value)
                            End If
                        End If
                    End If
                Else
                    Try
                        dgvEnterMarks.Item("MG", k).Value = get_points(dgvEnterMarks.Item("MP", k).Value)
                    Catch ex As Exception
                        dgvEnterMarks.Item("MG", k).Value = dgvEnterMarks.Item("MP", k).Value
                    End Try
                End If
            Else
                Dim total As Double = get_total_mark(exam_name, tm)
                If form_4_mode Then
                    If get_compulsory() Then
                        For c As Integer = 0 To compulsory.Length - 1
                            If dgvEnterMarks.Item(remove_wild(compulsory(c)), k).value.ToString = "X" Or dgvEnterMarks.Item(remove_wild(compulsory(c)), k).value.ToString = "Y" Or dgvEnterMarks.Item(remove_wild(compulsory(c)), k).value.ToString = "x" Or dgvEnterMarks.Item(remove_wild(compulsory(c)), k).value.ToString = "y" Then
                                grade = dgvEnterMarks.Item(remove_wild(compulsory(c)), k).value
                            End If
                        Next
                    End If
                    If grade <> Nothing Then
                        dgvEnterMarks.Item("MG", k).Value = grade
                    Else
                        Dim cnt As Integer = 0
                        If get_sciences() Then
                            For s As Integer = 0 To sciences.Length - 1
                                If dgvEnterMarks.Item(remove_wild(sciences(s)), k).value.ToString = "X" Or dgvEnterMarks.Item(remove_wild(sciences(s)), k).value.ToString = "Y" Or dgvEnterMarks.Item(remove_wild(sciences(s)), k).value.ToString = "x" Or dgvEnterMarks.Item(remove_wild(sciences(s)), k).value.ToString = "y" Then
                                    cnt += 1
                                    grade = dgvEnterMarks.Item(remove_wild(sciences(s)), k).value
                                End If
                            Next
                        End If
                        If cnt > 1 Then
                            dgvEnterMarks.Item("MG", k).Value = grade
                        Else
                            cnt = 0
                            grade = Nothing
                            Dim count As Integer = 0
                            If get_humanity() Then
                                For s As Integer = 0 To humanities.Length - 1
                                    If IsNumeric(dgvEnterMarks.Item(remove_wild(humanities(s)), k).value) Then
                                        count += 1
                                    End If
                                    If dgvEnterMarks.Item(remove_wild(humanities(s)), k).value.ToString = "X" Or dgvEnterMarks.Item(remove_wild(humanities(s)), k).value.ToString = "Y" Or dgvEnterMarks.Item(remove_wild(humanities(s)), k).value.ToString = "x" Or dgvEnterMarks.Item(remove_wild(humanities(s)), k).value.ToString = "y" Then
                                        cnt += 1
                                        grade = dgvEnterMarks.Item(remove_wild(humanities(s)), k).value
                                    End If
                                Next
                            End If
                            If count = 0 Then
                                If grade <> Nothing Then
                                    dgvEnterMarks.Item("MG", k).Value = grade
                                Else
                                    dgvEnterMarks.Item("MG", k).Value = "-"
                                End If
                            Else
                                Try
                                    dgvEnterMarks.Item("MG", k).Value = get_points(dgvEnterMarks.Item("MP", k).Value)
                                Catch ex As Exception
                                    dgvEnterMarks.Item("MG", k).Value = "-"
                                End Try
                            End If
                        End If
                    End If
                Else
                    Try
                        dgvEnterMarks.Item("MG", k).Value = get_points(dgvEnterMarks.Item("MP", k).Value)
                    Catch ex As Exception
                        dgvEnterMarks.Item("MG", k).Value = dgvEnterMarks.Item("MP", k).Value
                    End Try
                End If
            End If
            If dgvEnterMarks.Item("Sent", k).Value = 0 Or dgvEnterMarks.Item("Mp", k).Value = 0 Then
                dgvEnterMarks.Item("MG", k).Value = "--"
            End If

            'new code start
            If xStudents.Contains(dgvEnterMarks.Item("ADMNo", k).Value.ToString()) Then
                dgvEnterMarks.Item("MG", k).Value = "X"
            End If
            'new code end

        Next
    End Sub
    Private Sub mean_point()
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            If Not form_4_mode Then
                If IsNumeric(dgvEnterMarks.Item("Sent", k).Value) And dgvEnterMarks.Item("Sent", k).Value > 0 Then
                    dgvEnterMarks.Item("MP", k).Value = Format(dgvEnterMarks.Item("TP", k).Value / dgvEnterMarks.Item("Sent", k).Value, "0.00")
                Else
                    dgvEnterMarks.Item("MP", k).Value = "0"
                End If
            Else
                If IsNumeric(dgvEnterMarks.Item("Sent", k).Value) And dgvEnterMarks.Item("Sent", k).Value > 0 Then
                    dgvEnterMarks.Item("MP", k).Value = Format(dgvEnterMarks.Item("TP", k).Value / 7, "0.00")
                Else
                    dgvEnterMarks.Item("MP", k).Value = "0"
                End If
            End If

            'new code start
            If xStudents.Contains(dgvEnterMarks.Item("ADMNo", k).Value.ToString()) Then
                dgvEnterMarks.Item("MP", k).Value = "0"
            End If
            'new code end

        Next
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            dgvEnterMarks.Item("MP", k).Value = Convert.ToDouble(dgvEnterMarks.Item("MP", k).Value)
        Next
    End Sub
    Private Sub total_points()
        Dim cnt As Integer
        If mode Then
            For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
                cnt = 0
                For s As Integer = 0 To subjabb.Length - 1
                    If IsNumeric(dgvEnterMarks.Item(subjname(s), k).value) Then
                        cnt += fix_point(get_grade(dgvEnterMarks.Item(subjname(s), k).value, radSubject.Checked, subjabb(s)))
                    End If
                Next
                If dgvEnterMarks.Item("Sent", k).Value <> 0 Then
                    dgvEnterMarks.Item("TP", k).Value = cnt
                Else
                    dgvEnterMarks.Item("TP", k).Value = "0"
                End If

                'new code start
                If xStudents.Contains(dgvEnterMarks.Item("ADMNo", k).Value.ToString()) Then
                    dgvEnterMarks.Item("TP", k).Value = "0"
                End If
                'new code end
            Next
        Else
            Dim total As Double = get_total_mark(exam_name, tm)
            For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
                cnt = 0
                For s As Integer = 0 To subjabb.Length - 1
                    If IsNumeric(dgvEnterMarks.Item(subjname(s), k).value) Then
                        cnt += fix_point(get_grade((dgvEnterMarks.Item(subjname(s), k).value / total) * 100, radSubject.Checked, subjabb(s)))
                    End If
                Next
                If dgvEnterMarks.Item("Sent", k).Value <> 0 Then
                    dgvEnterMarks.Item("TP", k).Value = cnt
                Else
                    dgvEnterMarks.Item("TP", k).Value = "0"
                End If

                'new code start
                If xStudents.Contains(dgvEnterMarks.Item("ADMNo", k).Value.ToString()) Then
                    dgvEnterMarks.Item("TP", k).Value = "0"
                End If
                'new code end
            Next
        End If

        'For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
        '    dgvEnterMarks.Item("TP", k).Value = Convert.ToDouble(dgvEnterMarks.Item("MP", k).Value)
        'Next
    End Sub

    Private Sub subject_entries()
        Dim cnt As Integer
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            cnt = 0
            For s As Integer = 0 To subjabb.Length - 1
                If IsNumeric(dgvEnterMarks.Item(subjname(s), k).value) Then
                    cnt += 1
                ElseIf dgvEnterMarks.Item(subjname(s), k).value = "X" Or dgvEnterMarks.Item(subjname(s), k).value = "Y" Or dgvEnterMarks.Item(subjname(s), k).value = "x" Or dgvEnterMarks.Item(subjname(s), k).value = "y" Then
                    cnt += 1
                End If
            Next
            dgvEnterMarks.Item("Sent", k).Value = cnt
        Next
    End Sub
    Private Sub mean_points()
        Dim mark As Double
        If Not mode Then
            mark = get_total_mark(exam_name, tm)
        End If
        dgvEnterMarks.Rows.Add()
        dgvEnterMarks.Item("StudentName", dgvEnterMarks.Rows.Count - 1).Value = "MEAN POINTS"
        Dim cnt As Integer
        For k As Integer = 0 To subjabb.Length - 1
            dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = 0
        Next
        For k As Integer = 0 To subjabb.Length - 1
            cnt = 0
            For l As Integer = 0 To dgvEnterMarks.Rows.Count - 4
                If IsNumeric(dgvEnterMarks.Item(subjname(k), l).value) Then
                    cnt += 1
                    If mode Then
                        dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value += fix_point(get_grade(dgvEnterMarks.Item(subjname(k), l).value, radSubject.Checked, subjabb(k)))
                    Else
                        dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value += fix_point(get_grade((dgvEnterMarks.Item(subjname(k), l).value / mark) * 100, radSubject.Checked, subjabb(k)))
                    End If
                ElseIf dgvEnterMarks.Item(subjname(k), l).value.ToString <> "-" Then
                    dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value += 1
                    cnt += 1
                End If
            Next
            Dim value As Double = dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value
            If cnt = 0 Then
                dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = "--"
            Else
                dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = Format(Convert.ToDouble(dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value / cnt), "0.00")
            End If
        Next
    End Sub

    Private Sub mean_grade()
        dgvEnterMarks.Rows.Add()
        dgvEnterMarks.Item("StudentName", dgvEnterMarks.Rows.Count - 1).Value = "MEAN GRADE (M. MARKS)"
        If mode Then
            For k As Integer = 0 To subjabb.Length - 1
                If IsNumeric(dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 2).value) Then
                    dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = get_grade(dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 2).value, radSubject.Checked, subjabb(k))
                Else
                    dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = "--"
                End If
            Next
        Else
            Dim total As Double = get_total_mark(exam_name, tm)
            For k As Integer = 0 To subjabb.Length - 1
                If IsNumeric(dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 2).value) Then
                    dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = get_grade((dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 2).value / total) * 100, radSubject.Checked, subjabb(k))
                Else
                    dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = "--"
                End If
            Next
        End If
    End Sub

    Private Function position_in_exam(ByVal exam As String)
        qread("SELECT pos FROM examination_performance WHERE (exam='" & exam & "' AND term='" & tm & "' AND year='" & yr & "' AND ADMNo='" & dgvEnterMarks.Item("ADMNo", student).Value & "')")
        Try
            dbreader.Read()
            position_in_exam = dbreader("pos")
        Catch ex As Exception
            position_in_exam = "0/00"
        End Try
    End Function
    Private Function no_of_splits(ByVal subject As String)
        For k As Integer = 0 To subjects.Length - 1
            If subjects(k) = subject Then
                Return subject_splits(k)
            End If
        Next
        Return 0
    End Function
    Private Sub mean_score()
        dgvEnterMarks.Rows.Add()
        dgvEnterMarks.Item("StudentName", dgvEnterMarks.Rows.Count - 1).Value = "MEAN SCORE"
        Dim cnt As Integer
        For k As Integer = 0 To subjabb.Length - 1
            dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = 0
        Next
        Dim count As Double = 0
        For k As Integer = 0 To subjabb.Length - 1
            cnt = 0
            For l As Integer = 0 To dgvEnterMarks.Rows.Count - 2
                If IsNumeric(dgvEnterMarks.Item(subjname(k), l).value) Then
                    cnt += 1
                    dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value += dgvEnterMarks.Item(subjname(k), l).value
                    count += dgvEnterMarks.Item(subjname(k), l).value
                ElseIf dgvEnterMarks.Item(subjname(k), l).value.ToString <> "-" Then
                    cnt += 1
                End If
            Next
            If cnt = 0 Then
                dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = "--"
            Else
                dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value = Format(Convert.ToDouble(dgvEnterMarks.Item(subjname(k), dgvEnterMarks.Rows.Count - 1).value / cnt), "0.00")
            End If
        Next
    End Sub
    Private Sub total_means()
        Dim cnt As Integer
        Dim totals() As String = {"MM", "MP", "Total", "TP"}
        For t As Integer = 0 To totals.Length - 1
            cnt = 0
            For l As Integer = 0 To dgvEnterMarks.Rows.Count - 2
                If IsNumeric(dgvEnterMarks.Item(totals(t), l).Value) Then
                    cnt += 1
                    dgvEnterMarks.Item(totals(t), dgvEnterMarks.Rows.Count - 1).Value = Convert.ToDouble(dgvEnterMarks.Item(totals(t), dgvEnterMarks.Rows.Count - 1).Value) + Convert.ToDouble(dgvEnterMarks.Item(totals(t), l).Value)
                End If
            Next
            dgvEnterMarks.Item(totals(t), dgvEnterMarks.Rows.Count - 1).Value = Format(Convert.ToDouble(dgvEnterMarks.Item(totals(t), dgvEnterMarks.Rows.Count - 1).Value / cnt), "0.00")
        Next

    End Sub
    Private Sub save_subjects()
        Pbar.Visible = True
        'lblWait.Visible = True
        Dim increment As Integer = (dgvEnterMarks.Rows.Count - 5) / 100
        If grade Then
            dgvEnterMarks.Rows.Clear()
            grade = False
            btnViewReport.Enabled = True
            If mode Then
                load_multi()
            Else
                load_entered()
            End If
            btnGrade.Text = "View In Grade Mode"
        End If
        marks = get_total_mark(exam_name, tm)
        Try
            qwrite("CREATE TABLE `subjects_progress` (" &
        "`id` int(11) NOT NULL auto_increment," &
        "`admno` int(11) NOT NULL," &
        "`subject` varchar(100) NOT NULL," &
        "`grade` double NOT NULL," &
        "`term` varchar(3) NOT NULL," &
        "`year` int(11) NOT NULL," &
        "`exam` varchar(100) NOT NULL," &
        " PRIMARY KEY  (`id`)" &
        ") ENGINE=InnoDB DEFAULT CHARSET=latin1;")
        Catch ex As Exception

        End Try
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5
            For s As Integer = 0 To subjabb.Length - 1
                query = "DELETE FROM subjects_progress WHERE (admno='" & dgvEnterMarks.Item("ADMNo", k).Value & "' AND subject='" & subject_get(subjids(s)) & "' AND term='" & tm & "' AND year='" & yr & "' AND exam='" & exam_name & "')"
                qwrite(query)
                Try
                    query = "INSERT INTO subjects_progress VALUES(NULL,'" & dgvEnterMarks.Item("ADMNo", k).Value & "','" & subject_get(subjids(s)) & "','" & fix_point(get_grade((dgvEnterMarks.Item(subjname(s), k).Value / marks) * 100, radSubject.Checked, subjabb(s))) & "','" & tm & "','" & yr & "','" & exam_name & "')"
                Catch ex As Exception
                    query = "INSERT INTO subjects_progress VALUES(NULL,'" & dgvEnterMarks.Item("ADMNo", k).Value & "','0','" & dgvEnterMarks.Item(subjname(s), k).Value & "','" & tm & "','" & yr & "','" & exam_name & "')"
                End Try
                qwrite(query)
            Next
            Pbar.Increment(increment)
        Next
        Pbar.Increment(-100)
        Pbar.Visible = False
    End Sub
    Private Function print_student_report2()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report2
        Return print_document
    End Function
    Private Function print_student_report3()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report3
        Return print_document
    End Function
    Dim start_from As Integer = 0
    Dim in_page As Boolean = False
    Private Sub print_report3(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.HasMorePages = False
        Dim line As Integer = 30
        Dim left_margin As Integer = 40
        Dim right_margin As Integer = 1100
        Dim count As Integer = 0
        Dim CenterPage As Single
        Dim max_height As Single
        If IsPrimary() Then
            max_height = 1050
        Else
            max_height = 750
        End If
        If start_from = 0 Then
            Try
                e.Graphics.DrawImage(Image.FromFile(logoPath), left_margin + 10, line, 100, 100)
                line += 15
            Catch ex As Exception
                Timer1.Enabled = False
                If Not mode_view Then
                    Timer1.Enabled = True
                End If
            End Try
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
            If mode Then
                exam_name = Nothing
                For k As Integer = 0 To exam_names.Length - 1
                    If k > 0 Then
                        exam_name &= "/"
                    End If
                    exam_name &= exam_names(k)
                Next
            End If
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(ret_name(class_form).ToString.ToUpper & " " & class_stream.ToString.ToUpper & " MERIT LIST FOR " & exam_name & " EXAM, TERM " & tm & " " & yr, other_font).Width / 2)
            e.Graphics.DrawString(ret_name(class_form).ToString.ToUpper & " " & class_stream.ToString.ToUpper & " MERIT LIST FOR " & exam_name & " EXAM, TERM " & tm & " " & yr, other_font, Brushes.Black, CenterPage, line)
            line += other_font.Height + 5
        End If
        line += 10
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)
        Dim topline = line
        line += 10
        If start_from < dgvEnterMarks.Rows.Count Then
            For col As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                If dgvEnterMarks.Columns(col).Visible Then
                    If count = 1 Then
                        e.Graphics.DrawString(dgvEnterMarks.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
                    Else
                        Try
                            e.Graphics.DrawString(dgvEnterMarks.Columns(col).HeaderText.Substring(0, 3), smallfont, Brushes.Black, left_margin, line)
                        Catch ex As Exception
                            e.Graphics.DrawString(dgvEnterMarks.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
                        End Try
                    End If
                    count += 1
                    If count = 2 Then
                        left_margin += 200
                    Else
                        If IsPrimary() Then
                            left_margin += 35
                        Else
                            left_margin += 40
                        End If
                    End If
                End If
            Next
            line += 10
        End If
        For row As Integer = start_from To dgvEnterMarks.Rows.Count - 1
            If dgvEnterMarks.Item("str_class", row).Value = class_stream Then
                line += 2
                If line >= max_height And row < dgvEnterMarks.Rows.Count - 1 Then
                    e.HasMorePages = True
                    start_from = row
                    Exit Sub
                End If
                left_margin = 40
                count = 0
                For col As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                    If dgvEnterMarks.Columns(col).Visible Then
                        If dgvEnterMarks.Columns(col).Name = "str_class" Then
                            If dgvEnterMarks.Item("str_class", row).Value.ToString.Length > 3 Then
                                e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value.ToString.Substring(0, 3), smallfont, Brushes.Black, left_margin, line + 2)
                            Else
                                e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                            End If
                        Else
                            e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                        End If
                        count += 1
                        If count = 2 Then
                            left_margin += 200
                        Else
                            If IsPrimary() Then
                                left_margin += 35
                            Else
                                left_margin += 40
                            End If
                        End If
                    End If
                Next
                line += 2
                e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line)
                line += 10
            End If
        Next
        If line + 100 >= max_height + 60 Then
            count = 0
            line += 5
            e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line)
            left_margin = 40
            For k As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                If dgvEnterMarks.Columns(k).Visible Then
                    If k = 0 Then
                        e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline)
                    Else
                        e.Graphics.DrawLine(Pens.Black, left_margin - 5, line, left_margin - 5, topline)
                    End If
                    count += 1
                    If count = 2 Then
                        left_margin += 200
                    Else
                        If IsPrimary() Then
                            left_margin += 35
                        Else
                            left_margin += 40
                        End If
                    End If
                End If
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline)
            start_from = dgvEnterMarks.Rows.Count
            e.HasMorePages = True
            Exit Sub
        End If
        left_margin = 30
        e.Graphics.DrawString("SUBJECT MEAN MARKS", smallfont, Brushes.Black, left_margin, line + 20)
        e.Graphics.DrawString("SUBJECT MEAN GRADE (M. MARKS)", smallfont, Brushes.Black, left_margin, line + 40)
        e.Graphics.DrawString("SUBJECT MEAN POINTS", smallfont, Brushes.Black, left_margin, line + 60)
        e.Graphics.DrawString("SUBJECT MEAN GRADE (M. POINTS)", smallfont, Brushes.Black, left_margin, line + 80)
        left_margin = 240
        Dim subj_mp(subjabb.Length - 1)
        For col As Integer = 0 To dgvEnterMarks.Columns.Count - 1
            For s As Integer = 0 To subjabb.Length - 1
                Dim counter As Integer = 0
                Dim tm, tp As Double
                tm = 0
                tp = 0
                If dgvEnterMarks.Columns(col).Name = subjname(s) Then
                    For row As Integer = 0 To dgvEnterMarks.Rows.Count - 1
                        If dgvEnterMarks.Item(subjname(s).ToString, row).Value.ToString <> "-" And dgvEnterMarks.Item("str_class", row).Value = class_stream Then
                            counter += 1
                            Dim marks() As String = dgvEnterMarks.Item(subjname(s).ToString, row).Value.ToString.Split(" ")
                            If marks.Length > 1 Then
                                If IsNumeric(marks(0)) Then
                                    tm += marks(0)
                                    tp += fix_point(marks(1))
                                End If
                            Else
                                If IsNumeric(marks(0)) Then
                                    tm += marks(0)
                                    tp += fix_point(get_grade(marks(0), radSubject.Checked, subjabb(s)))
                                End If
                            End If
                        End If
                    Next
                    If tm > 0 And counter > 0 Then
                        subj_mp(s) = get_points(tp / counter)
                        e.Graphics.DrawString(Format(tm / counter, "0.00").ToString, smallfont, Brushes.Black, left_margin + ((s + 1) * 40), line + 20)
                        e.Graphics.DrawString(get_grade(tm / counter, radSubject.Checked, subjabb(s)), smallfont, Brushes.Black, left_margin + ((s + 1) * 40) + 5, line + 40)
                        e.Graphics.DrawString(Format(tp / counter, "0.00").ToString, smallfont, Brushes.Black, left_margin + ((s + 1) * 40), line + 60)
                        e.Graphics.DrawString(subj_mp(s), smallfont, Brushes.Black, left_margin + ((s + 1) * 40) + 5, line + 80)
                    Else
                        e.Graphics.DrawString("==", smallfont, Brushes.Black, left_margin + ((s + 1) * 40) + 5, line + 20)
                        e.Graphics.DrawString("==", smallfont, Brushes.Black, left_margin + ((s + 1) * 40) + 5, line + 40)
                        e.Graphics.DrawString("==", smallfont, Brushes.Black, left_margin + ((s + 1) * 40), line + 60)
                        e.Graphics.DrawString("==", smallfont, Brushes.Black, left_margin + ((s + 1) * 40) + 5, line + 80)
                    End If
                End If
            Next
        Next
        If start_from < dgvEnterMarks.Rows.Count Then
            count = 0
            line += 5
            e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line)
            left_margin = 40
            For k As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                If dgvEnterMarks.Columns(k).Visible Then
                    If k = 0 Then
                        e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline)
                    Else
                        e.Graphics.DrawLine(Pens.Black, left_margin - 5, line, left_margin - 5, topline)
                    End If
                    count += 1
                    If count = 2 Then
                        left_margin += 200
                    Else
                        If IsPrimary() Then
                            left_margin += 35
                        Else
                            left_margin += 40
                        End If
                    End If
                End If
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline)
        End If
        line += 100
        If line + 20 * grades.Length - 1 + line + other_font.Height * (streams.Length + 1) > max_height + 60 Then
            start_from = dgvEnterMarks.Rows.Count
            e.HasMorePages = True
            Exit Sub
        End If
        topline = line
        left_margin = 100
        For k As Integer = 0 To grades.Length - 1
            e.Graphics.DrawString(grades(k), other_font, Brushes.Black, left_margin, line - 8)
            e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin - 100, line)
            line += 20
        Next
        e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin - 100, line)
        Dim graphtop As Integer = topline
        left_margin += 30
        For k As Integer = 0 To subjabb.Length - 1
            graphtop = topline
            For g As Integer = 0 To grades.Length - 1
                If subj_mp(k) = grades(g) Then
                    Dim rect = New Rectangle(left_margin + (k * 10), graphtop, 20, line - graphtop)
                    e.Graphics.FillRectangle(Brushes.Black, rect)
                Else
                    graphtop += 20
                End If
            Next
            left_margin += 25
        Next
        left_margin = 100
        left_margin += 30
        For k As Integer = 0 To subjabb.Length - 1
            Try
                e.Graphics.DrawString(subjabb(k).ToString.Substring(0, 3), smallfont, Brushes.Black, left_margin, line)
            Catch ex As Exception
                e.Graphics.DrawString(subjabb(k).ToString, smallfont, Brushes.Black, left_margin, line)
            End Try
            left_margin += 35
        Next
        line += 30
        left_margin = 30
        Dim start_left As Integer = 100
        left_margin = start_left
        topline = line
        e.Graphics.DrawLine(Pens.Black, start_left, line, 220 + (50 * grades.Length), line)
        left_margin += 120
        line += 3
        e.Graphics.DrawString(ret_name(class_form), other_font, Brushes.Black, start_left + 5, line)
        For k As Integer = 0 To grades.Length - 1
            e.Graphics.DrawString(grades(k), smallfont, Brushes.Black, left_margin + 5, line)
            left_margin += 30
        Next
        line += other_font.Height + 5
        left_margin = start_left
        For k As Integer = 0 To streams.Length - 1
            e.Graphics.DrawString(streams(k), smallfont, Brushes.Black, left_margin + 5, line)
            For i As Integer = 0 To grades.Length - 1
                If i = 0 Then
                    left_margin += 120
                Else
                    left_margin += 30
                End If
                e.Graphics.DrawString(count_grades(grades(i), streams(k)), smallfont, Brushes.Black, left_margin + 5, line)
            Next
            e.Graphics.DrawLine(Pens.Black, start_left, line - 3, left_margin + 30, line - 3)
            line += other_font.Height + 5
            left_margin = start_left
        Next
        e.Graphics.DrawLine(Pens.Black, start_left, line, 220 + (30 * grades.Length), line)
        left_margin = start_left
        For k As Integer = 0 To grades.Length + 1
            e.Graphics.DrawLine(Pens.Black, left_margin, topline, left_margin, line)
            If k = 0 Then
                left_margin += 120
            Else
                left_margin += 30
            End If
        Next
        line += 30
        left_margin = start_left
        e.Graphics.DrawString("   SE    = SUBJECT ENTRIES		STR     = STREAM" & vbNewLine &
                              "   TP	= TOTAL POINTS			S.P     = STREAM POSITION" & vbNewLine &
                              "   MP	= MEAN POINTS			O.P     = OVERALL (CLASS) POSITION" & vbNewLine &
                              "   TM	= TOTAL MARKS			VAP     = VALUE ADDED PROGRESS (DEVIATION)", other_font, Brushes.Black, left_margin + 100, line)
        start_from = 0
    End Sub
    Private Sub print_report2(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.HasMorePages = False
        Dim line As Integer = 20
        Dim left_margin As Integer = 40
        Dim right_margin As Integer = 1100
        Dim count As Integer = 0
        Dim CenterPage As Single
        Dim max_height As Single
        If IsPrimary() Then
            max_height = 1050
        Else
            max_height = 750
        End If
        If start_from = 0 Then
            Try
                e.Graphics.DrawImage(Image.FromFile(path & "\photos_parent_guardians\" & "schoolLogo" & ".jpg"), left_margin + 10, line, 90, 90)
                'e.Graphics.DrawImage(Image.FromFile(logoPath), left_margin + 10, line, 90, 90)
                line += 15
            Catch ex As Exception
                Timer1.Enabled = False
                If Not mode_view Then
                    Timer1.Enabled = True
                End If
            End Try
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
            If mode Then
                exam_name = Nothing
                For k As Integer = 0 To exam_names.Length - 1
                    If k > 0 Then
                        exam_name &= "/"
                    End If
                    exam_name &= exam_names(k)
                Next
            End If
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(ret_name(class_form).ToString.ToUpper & " MERIT LIST FOR " & exam_name & " EXAM, TERM " & tm & " " & yr, other_font).Width / 2)
            e.Graphics.DrawString(ret_name(class_form).ToString.ToUpper & " MERIT LIST FOR " & exam_name & " EXAM, TERM " & tm & " " & yr, other_font, Brushes.Black, CenterPage, line)
            line += other_font.Height + 5
        End If
        line += 10
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)
        line += 10
        Dim topline As Integer = line
        If start_from < dgvEnterMarks.Rows.Count Then
            For col As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                If dgvEnterMarks.Columns(col).Visible Then
                    If count = 1 Then
                        e.Graphics.DrawString(dgvEnterMarks.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
                    Else
                        Try
                            e.Graphics.DrawString(dgvEnterMarks.Columns(col).HeaderText.Substring(0, 3), smallfont, Brushes.Black, left_margin, line)
                        Catch ex As Exception
                            e.Graphics.DrawString(dgvEnterMarks.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
                        End Try
                    End If
                    count += 1
                    If count = 2 Then
                        left_margin += 200
                    Else
                        If IsPrimary() Then
                            left_margin += 35
                        Else
                            left_margin += 40
                        End If
                    End If
                End If
            Next
            line += 10
        End If
        For row As Integer = start_from To dgvEnterMarks.Rows.Count - 1
            line += 2
            If row = dgvEnterMarks.Rows.Count - 4 Then
                line += 10
            End If
            If line >= max_height And row < dgvEnterMarks.Rows.Count - 1 Then
                count = 0
                line += 5
                e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line)
                left_margin = 40
                For k As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                    If dgvEnterMarks.Columns(k).Visible Then
                        If k = 0 Then
                            e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline)
                        Else
                            e.Graphics.DrawLine(Pens.Black, left_margin - 5, line, left_margin - 5, topline)
                        End If
                        count += 1
                        If count = 2 Then
                            left_margin += 200
                        Else
                            If IsPrimary() Then
                                left_margin += 35
                            Else
                                left_margin += 40
                            End If
                        End If
                    End If
                Next
                e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline)
                e.HasMorePages = True
                start_from = row
                Exit Sub
            End If
            left_margin = 40
            count = 0
            For col As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                If dgvEnterMarks.Columns(col).Visible Then
                    If dgvEnterMarks.Columns(col).Name = "str_class" Then
                        If dgvEnterMarks.Item("str_class", row).Value <> Nothing Then
                            If dgvEnterMarks.Item("str_class", row).Value.ToString.Length > 3 Then
                                e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value.ToString.Substring(0, 3), smallfont, Brushes.Black, left_margin, line + 2)
                            Else
                                e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                            End If
                        End If
                    ElseIf dgvEnterMarks.Columns(col).Name = "INDEX" Then
                        If dgvEnterMarks.Item("INDEX", row).Value <> Nothing Then
                            If dgvEnterMarks.Item("INDEX", row).Value.ToString.Length > 3 Then
                                e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value.ToString.Substring(dgvEnterMarks.Item("INDEX", row).Value.ToString.Length - 3, 3), smallfont, Brushes.Black, left_margin, line + 2)
                            Else
                                e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                            End If
                        End If
                    Else
                        e.Graphics.DrawString(dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                    End If
                    count += 1
                    If count = 2 Then
                        left_margin += 200
                    Else
                        If IsPrimary() Then
                            left_margin += 35
                        Else
                            left_margin += 40
                        End If
                    End If
                End If
            Next
            line += 2
            If row < dgvEnterMarks.Rows.Count - 4 Then
                e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line)
            End If
            line += 10
        Next
        If start_from < dgvEnterMarks.Rows.Count Then
            count = 0
            line += 5
            e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line)
            left_margin = 40
            For k As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                If dgvEnterMarks.Columns(k).Visible Then
                    If k = 0 Then
                        e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline)
                    Else
                        e.Graphics.DrawLine(Pens.Black, left_margin - 5, line, left_margin - 5, topline)
                    End If
                    count += 1
                    If count = 2 Then
                        left_margin += 200
                    Else
                        If IsPrimary() Then
                            left_margin += 35
                        Else
                            left_margin += 40
                        End If
                    End If
                End If
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline)
        End If
        line += 10
        If line + 60 >= max_height Then
            start_from = dgvEnterMarks.Rows.Count
            e.HasMorePages = True
            Exit Sub
        End If
        line += 20
        left_margin = 100
        get_streams(class_form)
        If line + 20 * (grades.Length) + line + other_font.Height * (streams.Length + 1) > max_height + 60 Then
            start_from = dgvEnterMarks.Rows.Count
            e.HasMorePages = True
            Exit Sub
        End If
        topline = line
        For k As Integer = 0 To grades.Length - 1
            e.Graphics.DrawString(grades(k), other_font, Brushes.Black, left_margin, line - 8)
            e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin - 100, line)
            line += 20
        Next
        e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin - 100, line)
        Dim graphtop As Integer = topline
        left_margin += 30
        For k As Integer = 0 To subjabb.Length - 1
            graphtop = topline
            For g As Integer = 0 To grades.Length - 1
                If dgvEnterMarks.Item(subjname(k).ToString, dgvEnterMarks.Rows.Count - 1).Value = grades(g) Then
                    Dim rect = New Rectangle(left_margin + (k * 10), graphtop, 20, line - graphtop)
                    e.Graphics.FillRectangle(Brushes.Black, rect)
                Else
                    graphtop += 20
                End If
            Next
            left_margin += 25
        Next
        line += 10
        left_margin = 100
        left_margin += 30
        For k As Integer = 0 To subjabb.Length - 1
            If subjabb(k).ToString.Length >= 3 Then
                e.Graphics.DrawString(subjabb(k).ToString.Substring(0, 3), smallfont, Brushes.Black, left_margin, line)
            Else
                e.Graphics.DrawString(subjabb(k).ToString, smallfont, Brushes.Black, left_margin, line)
            End If
            left_margin += 35
        Next
        line += 30
        Dim start_left As Integer = 100
        left_margin = start_left
        topline = line
        e.Graphics.DrawLine(Pens.Black, start_left, line, 220 + (50 * grades.Length), line)
        left_margin += 120
        line += 3
        e.Graphics.DrawString(ret_name(class_form), other_font, Brushes.Black, start_left + 5, line)
        For k As Integer = 0 To grades.Length - 1
            e.Graphics.DrawString(grades(k), smallfont, Brushes.Black, left_margin + 5, line)
            left_margin += 30
        Next
        line += other_font.Height + 5
        left_margin = start_left
        For k As Integer = 0 To streams.Length - 1
            e.Graphics.DrawString(streams(k), smallfont, Brushes.Black, left_margin + 5, line)
            For i As Integer = 0 To grades.Length - 1
                If i = 0 Then
                    left_margin += 120
                Else
                    left_margin += 30
                End If
                e.Graphics.DrawString(count_grades(grades(i), streams(k)), smallfont, Brushes.Black, left_margin + 5, line)
            Next
            e.Graphics.DrawLine(Pens.Black, start_left, line - 3, left_margin + 30, line - 3)
            line += other_font.Height + 5
            left_margin = start_left
        Next
        e.Graphics.DrawLine(Pens.Black, start_left, line, 220 + (30 * grades.Length), line)
        left_margin = start_left
        For k As Integer = 0 To grades.Length + 1
            e.Graphics.DrawLine(Pens.Black, left_margin, topline, left_margin, line)
            If k = 0 Then
                left_margin += 120
            Else
                left_margin += 30
            End If
        Next
        line += 30
        left_margin = start_left
        e.Graphics.DrawString("   SE	= SUBJECT ENTRIES					STR 	= STREAM" & vbNewLine &
                              "   TP	= TOTAL POINTS					    S.P		= STREAM POSITION" & vbNewLine &
                              "   MP	= MEAN POINTS					    O.P     = OVERALL (CLASS) POSITION" & vbNewLine &
                              "   TM	= TOTAL MARKS					    VAP     = VALUE ADDED PROGRESS (DEVIATION)", other_font, Brushes.Black, left_margin, line)
        start_from = 0
    End Sub
    Private Function count_grades(grade As String, str As String) As Integer
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 4
            If dgvEnterMarks.Item("MG", k).Value = grade And dgvEnterMarks.Item("str_class", k).Value = str Then
                count_grades += 1
            End If
        Next
    End Function
    Private Sub btnClassPerformance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClassPerformance.Click
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report2()
        If IsPrimary() Then
            print_document.DefaultPageSettings.Landscape = False
        Else
            print_document.DefaultPageSettings.Landscape = True
        End If
        Print_Preview.Document = print_document
        Print_Preview.ShowDialog()
    End Sub

    Private Sub btnStreamPerformance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStreamPerformance.Click
        Pbar.Visible = False
        Dim frm2 As New frmFilter
        frm2.ShowDialog()
        If cont Then
            Dim frm1 As New frmPrompt
            frm1.ShowDialog()
        Else
            Exit Sub
        End If
        If Not to_continue Then
            Exit Sub
        End If
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report3()
        If IsPrimary() Then
            print_document.DefaultPageSettings.Landscape = False
        Else
            print_document.DefaultPageSettings.Landscape = True
        End If
        Print_Preview.Document = print_document
        Print_Preview.ShowDialog()
    End Sub
    Dim print_reports As Boolean = False
    Dim mode_view As Boolean = True
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click

        resetSchoolName()

        mode_view = True
        If stream_mode Then
            failure("Cannot Print Or View Report Form! Please Consider Analyzing Results For The Entire Class")
            Exit Sub
        End If
        cont = False
        Dim frm As New frmDates
        frm.ShowDialog()
        If cont Then
            If dgvEnterMarks.SelectedRows.Count <= 0 Then
                success("Please Select A Student To Preview")
                Return
            End If
            Dim i As Integer
            'For i = 0 To dgvEnterMarks.SelectedRows.Count - 1
            student = dgvEnterMarks.SelectedRows(i).Index
            to_row = student
            Dim Print_Preview As New PrintPreviewDialog
            Dim print_dialog As New PrintDialog
            'print_dialog.ShowDialog()
            Dim print_document As PrintDocument = print_student_report()
            Dim margin As New Margins(10, 10, 10, 10)
            print_document.DefaultPageSettings.Landscape = False
            print_document.DefaultPageSettings.Margins = margin
            print_document.DocumentName = get_name(dgvEnterMarks.Item("StudentName", student).Value) & "_Report_Form"
            printpreview.Document = print_document
            printpreview.ShowDialog()
            'Next
        Else
            Exit Sub
        End If
        cont = False
    End Sub
    Private Function print_student_report()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report
        Return print_document
    End Function
    Private Function print_subject_report()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_subject
        Return print_document
    End Function
    Dim amt As Double
    Private Function get_fee_bal(ByVal adm As String)
        Dim total As Double = 0
        If qread("SELECT COALESCE(balance, 0) as balance FROM stud_balance_temp_table WHERE admin_no ='" & adm & "'") Then
            If dbreader.RecordsAffected > 0 Then
                While dbreader.Read
                    total += dbreader("balance")
                End While
            End If
            dbreader.Close()
        End If

        Return total.ToString("n2")
    End Function
    Private Sub get_fees()
        Dim term As String = Nothing
        Dim yr_ As Integer = yr
        If tm = "I" Then
            term = "II"
        ElseIf tm = "II" Then
            term = "III"
        ElseIf tm = "III" Then
            term = "I"
            yr_ = yr + 1
        End If
        amt = 0
        'qread("SELECT amount FROM fee_structure WHERE class='" & ret_name(class_form) & "' AND term='" & term & "' AND year='" & yr_ & "' AND category=(SELECT category FROM students WHERE ADMNo='" & escape_string(dgvEnterMarks.Item("ADMNo", student).Value) & "')")
        'While dbreader.Read()
        '    amt += dbreader("amount")
        'End While
        ' todo get fee balance 2
    End Sub
    Private Function get_balance(ByVal no As Integer)
        'qread("SELECT Amount FROM accounts_students WHERE ADMNo='" & no & "'")
        'Try
        '    dbreader.Read()
        '    get_balance = dbreader("Amount")
        'Catch ex As Exception
        '    qwrite("INSERT INTO accounts_students VALUES('" & no & "','0','True')")
        '    get_balance = 0
        'End Try
        'dbreader.Close()
        'todo get fee balance 2
        get_balance = 0
    End Function

    Private Function dormitory(ByVal adm As String)
        qread("SELECT dormitory FROM students WHERE admin_no ='" & adm & "'")
        Try
            dbreader.Read()
            dormitory = dbreader("dormitory")
        Catch ex As Exception
            dormitory = String.Empty
        End Try
    End Function

    Private Function no_of_subjects(ByVal adm As String)
        no_of_subjects = 0
        qread("SELECT * FROM `subjects_done` WHERE ADMNo='" & adm & "'")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            For k As Integer = 0 To subjabb.Length - 1
                Try
                    If dbreader(subjname(k)) = "Yes" Then
                        ReDim Preserve subjects_done(no_of_subjects), subjects_done_name(no_of_subjects), subjects_done_abb(no_of_subjects)
                        subjects_done(no_of_subjects) = subjects(k)
                        subjects_done_abb(no_of_subjects) = subjabb(k)
                        subjects_done_name(no_of_subjects) = subjname(k)
                        no_of_subjects += 1
                    End If
                Catch ex As Exception

                End Try
            Next
            dbreader.Close()
        Else
            qwrite("INSERT INTO `subjects_done`(ADMNo) VALUES('" & adm & "')")
            ReDim subjects_done(subjabb.Length - 1), subjects_done_name(subjabb.Length - 1), subjects_done_abb(subjabb.Length - 1)
            For k As Integer = 0 To subjabb.Length - 1
                subjects_done(no_of_subjects) = subjects(k)
                subjects_done_abb(no_of_subjects) = subjabb(k)
                subjects_done_name(no_of_subjects) = subjname(k)
                no_of_subjects += 1
            Next
            no_of_subjects = subjabb.Length
        End If
    End Function
    Dim subjects_done(), subjects_done_abb(), subjects_done_name() As String
    Private Function get_no_of_split_subjects(ByVal index As Integer)
        qread("SELECT * FROM `split_subjects` WHERE `subject` = '" & escape_string(subjects(index)) & "' AND `class` = '" & escape_string(ret_name(class_form)) & "';")
        Return dbreader.RecordsAffected
    End Function
    Dim subject_splits(subjects.Length - 1) As Integer
    Dim selected_print As Boolean = False
    Dim total_fees As Double
    Private Sub print_report(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.HasMorePages = False
        total_fees = 0
        Dim avg As Integer = 415
        Dim subj_pos As Integer = 530
        Dim remarks As Integer = 560
        Dim teacher As Integer = 695
        Dim pt As Integer = 495
        Dim mg As Integer = 455
        Dim exam_width As Integer = 50
        Dim line, i, j As Integer
        Dim CenterPage As Single
        Dim left_margin As Integer = 80
        Dim right_margin As Integer = 800
        Dim topline As Integer = 175
        Dim perf As String = Nothing
        Dim Graphpen As Pen
        Dim Avgpen, RemarksPen, Teacherpen, PointPen, Subjectpen, Mgpen As Brush
        If report.color = True Then
            Graphpen = New Pen(Color.Red, 2)
            Avgpen = Brushes.Blue
            RemarksPen = Brushes.Red
            Teacherpen = Brushes.Blue
            Subjectpen = Brushes.Black
            Mgpen = Brushes.Red
            PointPen = Brushes.Blue
        Else
            Graphpen = New Pen(Color.Black, 2)
            Avgpen = Brushes.Black
            PointPen = Brushes.Black
            RemarksPen = Brushes.Black
            Teacherpen = Brushes.Black
            Subjectpen = Brushes.Black
            Mgpen = Brushes.Black
        End If
        Try
            exam_width = ((avg - (left_margin + 210)) + 70) / tables.Length
        Catch ex As Exception
            exam_width = avg - (left_margin + 210)
        End Try
        line = 15
        If report.school_logo Then
            ' If True Then
            Try
                e.Graphics.DrawImage(Image.FromFile(path & "\photos_parent_guardians\" & "schoolLogo" & ".jpg"), left_margin + 5, topline - 170, 90, 90)
            Catch ex As Exception
                Timer1.Enabled = False
            End Try
        End If
        If report.student_photo Then
            Try
                e.Graphics.DrawImage(Image.FromFile(path & "\photos_parent_guardians\" & dgvEnterMarks.Item("ADMNo", student).Value & ".jpg"), right_margin - 100, topline - 170, 100, 100)
            Catch ex As Exception
                Timer1.Enabled = False
            End Try
        End If
        If S_NAME <> String.Empty Then
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(S_NAME.ToUpper, header_font).Width / 2)
            e.Graphics.DrawString(S_NAME.ToUpper, header_font, Avgpen, CenterPage, line)
            line += header_font.Height + 2
        End If
        If S_ADDRESS <> String.Empty Then
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("P.O. BOX " & S_ADDRESS.ToUpper & ", " & S_LOCATION.ToUpper, other_font).Width / 2)
            e.Graphics.DrawString("P.O. BOX " & S_ADDRESS.ToUpper & ", " & S_LOCATION.ToUpper, other_font, Avgpen, CenterPage, line)
            line += other_font.Height + 5
        End If
        If S_PHONE <> String.Empty Then
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("TELEPHONE: " & S_PHONE, other_font).Width / 2)
            e.Graphics.DrawString("TELEPHONE: " & S_PHONE, other_font, Avgpen, CenterPage, line)
            line += other_font.Height + 5
        End If
        'If S_EMAIL <> "" Then
        '    CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("EMAIL ADDRESS: " & S_EMAIL, other_font).Width / 2)
        '    e.Graphics.DrawString("EMAIL ADDRESS: " & S_EMAIL, other_font, Avgpen, CenterPage, line)
        '    line += other_font.Height + 5
        'End If
        line -= 5
        If print_reports And Not selected_print Then
            While dgvEnterMarks.Item("str_class", student).Value <> class_stream
                student += 1
            End While
        End If
        CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("STUDENT PROGRESS REPORT", header_font).Width / 2)
        e.Graphics.DrawString("STUDENT PROGRESS REPORT", header_font, Avgpen, CenterPage, line + 5)
        line += header_font.Height + 10
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
        e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)
        line += 10
        e.Graphics.DrawString("NAME OF STUDENT:_______________________________________", other_font, Brushes.Black, left_margin + 2, line)
        e.Graphics.DrawString(dgvEnterMarks.Item("StudentName", student).Value, medium_larger, Avgpen, left_margin + 150, line - 8)
        e.Graphics.DrawString("ADMISSION NUMBER:_______", other_font, Brushes.Black, left_margin + 500, line)
        e.Graphics.DrawString(dgvEnterMarks.Item("ADMNo", student).Value, medium_larger, Avgpen, left_margin + 660, line - 8)
        line += 25
        e.Graphics.DrawString("CLASS:_________", other_font, Brushes.Black, left_margin + 2, line)
        e.Graphics.DrawString(ret_name(class_form).ToString.ToUpper, other_font, Avgpen, left_margin + 60, line - 3)
        e.Graphics.DrawString("STREAM:_________", other_font, Brushes.Black, left_margin + 150, line)
        e.Graphics.DrawString(dgvEnterMarks.Item("str_class", student).Value.ToString.ToUpper, other_font, Avgpen, left_margin + 220, line - 3)
        e.Graphics.DrawString("TERM:_____", other_font, Brushes.Black, left_margin + 300, line)
        e.Graphics.DrawString(tm, other_font, Avgpen, left_margin + 350, line - 2)
        e.Graphics.DrawString("YEAR:______", other_font, Brushes.Black, left_margin + 400, line)
        e.Graphics.DrawString(yr, other_font, Avgpen, left_margin + 450, line - 3)
        e.Graphics.DrawString("DORMITORY:_____________", other_font, Brushes.Black, left_margin + 500, line)
        e.Graphics.DrawString(dormitory(dgvEnterMarks.Item("ADMNo", student).Value).ToString.ToUpper, other_font, Avgpen, left_margin + 600, line - 3)
        line = topline
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
        e.Graphics.DrawString("SUBJECT", other_font, Brushes.Black, left_margin + 2, line)
        j = 210

        Dim italisized_font As New Font(biggerfont, 7, FontStyle.Italic)
        Try
            If tables.Length > 1 Then
                For i = 0 To tables.Length - 1
                    e.Graphics.DrawString(exam_names(i).ToUpper.Substring(0, 4) & "/" & total_mark(i) & String.Empty, italisized_font, Brushes.Black, left_margin + j + (exam_width / 2) - 20, line + 3)
                    j += exam_width
                Next
            Else
                marks = get_total_mark(exam_name, tm)
                e.Graphics.DrawString(exam_name.ToUpper.ToString.Substring(0, 4) & "/" & marks & String.Empty, italisized_font, Brushes.Black, left_margin + j + (exam_width / 2) - 20, line + 3)
            End If
        Catch ex As Exception
            'marks = get_total_mark(exam_name, tm)
            'e.Graphics.DrawString(exam_name.ToUpper.ToString.Substring(0, 4) & "/" & marks & "", italisized_font, Brushes.Black, left_margin + j + (exam_width / 2) - 20, line + 3)
        End Try
        e.Graphics.DrawString("TOT", other_font, Avgpen, left_margin + avg, line)
        e.Graphics.DrawString("PTS", other_font, PointPen, left_margin + pt, line)
        e.Graphics.DrawString("M.G.", other_font, Mgpen, left_margin + mg + 3, line)
        e.Graphics.DrawString("SSP", other_font, Mgpen, left_margin + subj_pos, line)
        e.Graphics.DrawString("REMARK", other_font, RemarksPen, left_margin + remarks, line)
        e.Graphics.DrawString("T.I", other_font, Teacherpen, left_margin + teacher, line)
        line += 20
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
        Dim totals, totals_avg, totals_avg_cnt As Double
        Dim no As Integer = no_of_subjects(dgvEnterMarks.Item("ADMNo", student).Value)
        If chkSplit.Checked Then
            For k As Integer = 0 To subjects.Length - 1
                subject_splits(k) = get_no_of_split_subjects(k)
            Next
        End If
        If Not mode Then
            Dim total_mark As Integer = get_total_mark(exam_name, tm)
            If grade Then
                For k As Integer = 0 To subjects_done.Length - 1
                    totals += (dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100
                    totals_avg += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                    totals_avg_cnt += 1
                    e.Graphics.DrawString(CInt((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), other_font, Brushes.DarkBlue, left_margin + 220, line)
                    e.Graphics.DrawString(CInt((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), other_font, Brushes.DarkBlue, left_margin + avg + 5, line)
                    line += 20
                Next
            Else
                For k As Integer = 0 To subjects_done.Length - 1
                    If chkSplit.Checked Then
                        get_split_subjects(subjects_done(k), True)
                        For c As Integer = 0 To splits.Length - 1
                            e.Graphics.DrawString(splits(c), other_font, Subjectpen, left_margin + 2, line)
                            If report.color Then
                                e.Graphics.DrawString(dgvEnterMarks.Item(splits_name(c), student).Value, other_font, Brushes.DarkBlue, left_margin + 220, line)
                            Else
                                e.Graphics.DrawString(dgvEnterMarks.Item(splits_name(c), student).Value, other_font, Brushes.Black, left_margin + 220, line)
                            End If
                            line += 20
                        Next
                    End If
                    If dgvEnterMarks.Item(subjects_done_name(k), student).Value.ToString <> "-" Then
                        If IsNumeric(dgvEnterMarks.Item(subjects_done_name(k), student).Value) Then
                            totals += (dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100
                            totals_avg += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                            If report.color Then
                                e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Brushes.DarkBlue, left_margin + 220, line)
                            Else
                                e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Brushes.Black, left_margin + 220, line)
                            End If
                            e.Graphics.DrawString(CInt((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), other_font, Avgpen, left_margin + avg + 5, line)
                            If IsNumeric(dgvEnterMarks.Item(subjects_done_name(k), student).Value) Then
                                e.Graphics.DrawString(fix_point(get_grade((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100, radSubject.Checked, subjects_done_abb(k))), other_font, Brushes.Black, left_margin + pt, line)
                            Else
                                e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, PointPen, left_margin + pt, line)
                            End If
                        End If
                        totals_avg_cnt += 1
                    Else
                        If report.color Then
                            e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Brushes.DarkBlue, left_margin + 220, line)
                        Else
                            e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Brushes.Black, left_margin + 220, line)
                        End If
                        e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Avgpen, left_margin + avg + 5, line)
                    End If
                    line += 20
                Next
            End If
            e.Graphics.DrawString(totals_avg, other_font, Brushes.DarkBlue, left_margin + 220, line)
            e.Graphics.DrawString(CInt(totals), other_font, Avgpen, left_margin + avg + 5, line)
            e.Graphics.DrawString(dgvEnterMarks.Item("TP", student).Value, other_font, PointPen, left_margin + pt + 5, line)
            e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, other_font, Mgpen, left_margin + mg + 5, line)
            line = topline + 20
            For k As Integer = 0 To subjects_done.Length - 1
                If chkSplit.Checked Then
                    For s As Integer = 0 To no_of_splits(subjects_done(k)) - 1
                        line += 20
                    Next
                End If
                If IsNumeric(dgvEnterMarks.Item(subjects_done_name(k), student).Value) Then
                    e.Graphics.DrawString(get_comment(get_grade(((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), radSubject.Checked, subjects_done_abb(k)).ToString, radSubject.Checked, subjects_done_abb(k)), italisized_font, RemarksPen, left_margin + remarks, line)
                Else
                    e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, italisized_font, RemarksPen, left_margin + remarks, line)
                End If
                If grade Then
                    e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Mgpen, left_margin + mg, line)
                Else
                    If IsNumeric(dgvEnterMarks.Item(subjects_done_name(k), student).Value) Then
                        e.Graphics.DrawString(get_grade(((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), radSubject.Checked, subjects_done_abb(k)), other_font, Mgpen, left_margin + mg + 7, line)
                    Else
                        e.Graphics.DrawString("-", other_font, Mgpen, left_margin + mg, line)
                    End If
                End If
                line += 20
            Next
        Else
            j = 210
            Dim total_ As Double
            Dim out_of As Double
            For i = 0 To tables.Length - 1
                marks = get_total_mark(exam_names(i), tm)
                total_ = 0
                line = topline + 20
                Dim tot_cnt As Integer = 0
                If qread("SELECT * FROM `" & table & "` WHERE ADMNo='" & dgvEnterMarks.Item("ADMNo", student).Value & "' AND Examination='" & escape_string(tables(i)) & "' AND Term='" & tms(i) & "' AND Year='" & yrs(i) & "'") Then
                    tot_cnt = 0
                    tot_cnt = 0
                    dbreader.Read()
                    qread("SELECT * FROM `exam_split_subject_results`  WHERE ADMNo='" & dgvEnterMarks.Item("ADMNo", student).Value & "' AND Examination='" & escape_string(tables(i)) & "' AND Term='" & tms(i) & "' AND Year='" & yrs(i) & "'", 1)
                    If dbreader1.RecordsAffected > 0 Then
                        dbreader1.Read()
                    End If
                    For k As Integer = 0 To subjects_done.Length - 1
                        If chkSplit.Checked Then
                            get_split_subjects(subjects_done(k), True)
                            For c As Integer = 0 To splits.Length - 1
                                e.Graphics.DrawString(splits(c), other_font, Subjectpen, left_margin + 2, line)
                                If dbreader1.RecordsAffected > 0 Then
                                    If report.color Then
                                        e.Graphics.DrawString(dbreader1(class_form & "_" & splits_name(c)), other_font, Brushes.DarkBlue, left_margin + j + (exam_width / 2) - 10, line)
                                    Else
                                        e.Graphics.DrawString(dbreader1(class_form & "_" & splits_name(c)), other_font, Brushes.Black, left_margin + j + (exam_width / 2) - 10, line)
                                    End If
                                End If
                                line += 20
                            Next
                        End If
                        If dbreader.RecordsAffected > 0 Then
                            If IsNumeric(dbreader(subjects_done_abb(k))) Then
                                out_of = SubjectOutOf(subjects_done_abb(k), tm, yr, exam_names(i), ret_name(class_form), dgvEnterMarks.Item("str_class", student).Value, 2)
                                e.Graphics.DrawString(CInt((dbreader(subjects_done_abb(k)) / out_of) * marks), other_font, Brushes.Black, left_margin + j + (exam_width / 2) - 10, line)
                                total_ += dbreader(subjects_done_abb(k))
                                tot_cnt += 1
                            End If
                        End If
                        line += 20
                    Next
                    If chkMode.Checked Then
                        Dim tot As Double
                        For k As Integer = 0 To subjects_7.Length - 1
                            If subjects_7(k)(8) = dgvEnterMarks.Item("ADMNo", student).Value.ToString Then
                                tot = 0
                                For c As Integer = 0 To subjects_7(k).Length - 2
                                    Try
                                        If IsNumeric(dbreader(subjects_7(k)(c).ToString)) Then
                                            tot += dbreader(subjects_7(k)(c).ToString)
                                            tot_cnt += 1
                                        End If
                                    Catch ex As Exception

                                    End Try
                                Next
                                Exit For
                            End If
                        Next
                        e.Graphics.DrawString(tot, other_font, Brushes.Black, left_margin + j + 2, line)
                    Else
                        e.Graphics.DrawString(total_, other_font, Brushes.Black, left_margin + j + 2, line)
                    End If
                    j += exam_width
                    line = 330
                End If
            Next
            line = topline + 20
            For k As Integer = 0 To subjects_done.Length - 1
                If chkSplit.Checked Then
                    For s As Integer = 0 To no_of_splits(subjects_done(k)) - 1
                        line += 20
                    Next
                End If
                If IsNumeric(dgvEnterMarks.Item(subjects_done_name(k), student).Value) Then
                    e.Graphics.DrawString(get_comment(get_grade(dgvEnterMarks.Item(subjects_done_name(k), student).Value, radSubject.Checked, subjects_done_abb(k)).ToString, radSubject.Checked, subjects_done_abb(k)), italisized_font, RemarksPen, left_margin + remarks, line)
                Else
                    e.Graphics.DrawString(String.Empty, italisized_font, RemarksPen, left_margin + remarks, line)
                End If
                If grade Then
                    e.Graphics.DrawString(fix_point(dgvEnterMarks.Item(subjects_done_name(k), student).Value), other_font, PointPen, left_margin + pt + 4, line)
                    e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Mgpen, left_margin + mg + 4, line)
                Else
                    If IsNumeric(dgvEnterMarks.Item(subjects_done_name(k), student).Value) Then
                        e.Graphics.DrawString(fix_point(get_grade(dgvEnterMarks.Item(subjects_done_name(k), student).Value, radSubject.Checked, subjects_done_abb(k))), other_font, PointPen, left_margin + pt + 4, line)
                        e.Graphics.DrawString(get_grade(dgvEnterMarks.Item(subjects_done_name(k), student).Value, radSubject.Checked, subjects_done_abb(k)), other_font, Mgpen, left_margin + mg + 4, line)
                    End If
                End If
                line += 20
            Next
            line = topline + 20
            If grade Then
                For k As Integer = 0 To subjects_done.Length - 1
                    totals += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                    e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Avgpen, left_margin + avg + 5, line)
                    line += 20
                Next
                e.Graphics.DrawString(totals, other_font, Avgpen, left_margin + avg + 5, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("TP", student).Value, other_font, PointPen, left_margin + pt + 5, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, other_font, Mgpen, left_margin + mg + 5, line)
            Else
                For k As Integer = 0 To subjects_done.Length - 1
                    If chkSplit.Checked Then
                        For s As Integer = 0 To no_of_splits(subjects_done(k)) - 1
                            line += 20
                        Next
                    End If
                    If IsNumeric(dgvEnterMarks.Item(subjects_done_name(k), student).Value) Then
                        totals += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                    End If
                    e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Avgpen, left_margin + avg + 5, line)
                    line += 20
                Next
                e.Graphics.DrawString(dgvEnterMarks.Item("Total", student).Value, other_font, Avgpen, left_margin + avg + 5, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("TP", student).Value, other_font, PointPen, left_margin + pt + 5, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, other_font, Mgpen, left_margin + mg + 5, line)
            End If
        End If
        line = topline + 20
        For k As Integer = 0 To subjects_done.Length - 1
            If chkSplit.Checked Then
                For s As Integer = 0 To no_of_splits(subjects_done(k)) - 1
                    line += 20
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
                Next
            End If
            If subjects_done(k).Length >= 22 Then
                e.Graphics.DrawString(subjects_done(k).Substring(0, 22), other_font, Subjectpen, left_margin + 2, line)
            Else
                e.Graphics.DrawString(subjects_done(k), other_font, Subjectpen, left_margin + 2, line)
            End If

            e.Graphics.DrawString(subject_teacher(dgvEnterMarks.Item("str_class", student).Value, class_form, tm, yr, subjects_done_abb(k)), other_font, Teacherpen, left_margin + teacher, line)
            e.Graphics.DrawString(subject_rank_only(subjects_done_name(k), dgvEnterMarks.Item(subjects_done_name(k), student).Value, dgvEnterMarks.Item("str_class", student).Value), other_font, Mgpen, left_margin + subj_pos, line)
            line += 20
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
        Next
        If grade Then
            e.Graphics.DrawString("MEAN GRADE", other_font, Brushes.Black, left_margin + 2, line)
        Else
            e.Graphics.DrawString("TOTAL MARKS", other_font, Brushes.Black, left_margin + 2, line)
        End If
        line += 20
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
        e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline - 2, left_margin - 2, line)
        j = 210
        Try
            For i = 0 To tables.Length - 1
                e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line)
                j += exam_width
            Next
        Catch ex As Exception
            e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line)
        End Try
        e.Graphics.DrawLine(Pens.Black, left_margin + avg - 2, topline - 2, left_margin + avg - 2, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + pt - 2, topline - 2, left_margin + pt - 2, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + mg - 2, topline - 2, left_margin + mg - 2, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + subj_pos - 2, topline - 2, left_margin + subj_pos - 2, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + remarks - 2, topline - 2, left_margin + remarks - 2, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + teacher - 2, topline - 2, left_margin + teacher - 2, line)
        e.Graphics.DrawLine(Pens.Black, right_margin + 2, topline - 2, right_margin + 2, line)
        line += 10
        Dim stream_out_of As Integer = 0
        For i = 0 To streams.Length - 1
            If dgvEnterMarks.Item("str_class", student).Value = streams(i) Then
                stream_out_of = stream_no(i)
            End If
        Next
        e.Graphics.DrawString("CLASS POSITION:______________", other_font, Avgpen, left_margin + 2, line)
        e.Graphics.DrawString(dgvEnterMarks.Item("Overall", student).Value & " Out Of " & dgvEnterMarks.Rows.Count - 4, other_font, RemarksPen, left_margin + 130, line - 2)
        e.Graphics.DrawString("STR. POSITION:_____________", other_font, Avgpen, left_margin + 230, line)
        e.Graphics.DrawString(dgvEnterMarks.Item("Position", student).Value & " Out Of " & stream_out_of - 1, other_font, RemarksPen, left_margin + 360, line - 2)
        e.Graphics.DrawString("M. GRADE:____", other_font, Avgpen, left_margin + 470, line)
        e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, other_font, RemarksPen, left_margin + 550, line - 2)
        e.Graphics.DrawString("M. POINTS:________", other_font, Avgpen, left_margin + 590, line)
        If IsNumeric(dgvEnterMarks.Item("MP", student).Value) Then
            e.Graphics.DrawString(dgvEnterMarks.Item("MP", student).Value, other_font, RemarksPen, left_margin + 675, line - 2)
        Else
            e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, other_font, RemarksPen, left_margin + 675, line - 2)
        End If
        line += 25
        Dim startline As Integer = line
        all_classes = classes()
        Dim h_width As Integer = (right_margin - (left_margin + 50)) / all_classes.Length
        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
        e.Graphics.DrawString("CLASS", smallfont, RemarksPen, left_margin + 20, line)
        e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin + 50, line + 20)
        e.Graphics.DrawString("TERM", smallfont, RemarksPen, left_margin + 2, line + 9)
        line += 20
        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
        e.Graphics.DrawString("I", other_font, Avgpen, left_margin + 20, line + 2)
        line += 20
        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
        e.Graphics.DrawString("II", other_font, RemarksPen, left_margin + 20, line + 2)
        line += 20
        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
        e.Graphics.DrawString("III", other_font, Avgpen, left_margin + 20, line + 2)
        line += 20
        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
        e.Graphics.DrawLine(Pens.Black, left_margin, startline, left_margin, line)
        Dim newline As Integer
        Dim startyr As Integer = Today.Year - CurrentClass(all_classes, class_form)
        ReDim class_term(all_classes.Length - 1)(2), class_term_data(all_classes.Length - 1)(2)
        For k As Integer = 0 To all_classes.Length - 1
            ReDim class_term(k)(2)
            ReDim class_term_data(k)(2)
            For count As Integer = 0 To 2
                class_term(k)(count) = Nothing
                class_term_data(k)(count) = False
            Next
        Next
        Dim class_from As Integer = left_margin + 50
        For k As Integer = 0 To all_classes.Length - 1
            newline = line - 60
            e.Graphics.DrawLine(Pens.Black, class_from + h_width * k, startline, class_from + h_width * k, line)
            If k Mod 2 = 0 Then
                e.Graphics.DrawString(all_classes(k).ToUpper, other_font, Avgpen, class_from + h_width * k + 2, startline + 2)
            Else
                e.Graphics.DrawString(all_classes(k).ToUpper, other_font, RemarksPen, class_from + h_width * k + 2, startline + 2)
            End If
            e.Graphics.DrawString(get_class_performance_data("I", k, startyr), smallfont, RemarksPen, class_from + h_width * k + 2, newline + 2)
            newline += 20
            e.Graphics.DrawString(get_class_performance_data("II", k, startyr), smallfont, RemarksPen, class_from + h_width * k + 2, newline + 2)
            newline += 20
            e.Graphics.DrawString(get_class_performance_data("III", k, startyr), smallfont, RemarksPen, class_from + h_width * k + 2, newline + 2)
            newline += 20
            startyr += 1
        Next
        e.Graphics.DrawLine(Pens.Black, right_margin, startline, right_margin, line)
        line += 5
        If subject_ranking_table Then
            e.Graphics.DrawString("GRAPHICAL PROGRESS REPORT", other_font, Avgpen, left_margin + 50, line)
            e.Graphics.DrawString("SUBJECT RANKING IN CLASS", other_font, Avgpen, left_margin + 420, line)
        Else
            e.Graphics.DrawString("GRAPHICAL PROGRESS REPORT", other_font, Avgpen, left_margin + 200, line)
        End If
        line += 20
        startline = line
        e.Graphics.DrawLine(Pens.Black, left_margin + 10, line, left_margin + 10, line + 185)
        zline = line + 183
        Dim right_end As Integer
        If subject_ranking_table Then
            right_end = ((right_margin - left_margin) / 2) + 75
        Else
            right_end = right_margin
        End If
        e.Graphics.DrawLine(Pens.Black, left_margin + 10, line + 185, right_end, line + 185)
        Dim ht As Integer = 280 / grades.Length - 3
        Dim endline As Integer = line + 185
        If Not IsPrimary() Then
            e.Graphics.DrawString("KCPE", smallfont, Brushes.Black, left_margin + 3, endline)
            e.Graphics.DrawLine(Pens.Black, left_margin + 25, endline, left_margin + 25, startline)
            h_width = 20
        Else
            h_width = 0
        End If
        Dim increment As Integer
        If subject_ranking_table Then
            increment = ((right_margin - (left_margin + 50)) / 2) / all_classes.Length
        Else
            increment = (right_margin - (left_margin + 50)) / all_classes.Length
        End If
        Dim inc As Integer = increment / 3
        Dim primary As Boolean = IsPrimary()
        For k As Integer = 0 To all_classes.Length - 1
            e.Graphics.DrawLine(Pens.Black, left_margin + h_width + increment * (k + 1), startline, left_margin + h_width + increment * (k + 1), line + 185)
            e.Graphics.DrawString(all_classes(k), smallfont, Brushes.Black, left_margin + increment * k + 10, line + 195)
            For h As Integer = 0 To 2
                If h = 0 Then
                    e.Graphics.DrawLine(Pens.Black, left_margin + h_width + inc * (h + 1) + (increment * k), (line + 185) - 5, left_margin + h_width + inc * (h + 1) + (increment * k), line + 185)
                    If Not primary Then
                        e.Graphics.DrawString("I", smallfont, Brushes.Black, (left_margin + inc * (h + 1)) + (increment * k), line + 185)
                    Else
                        e.Graphics.DrawString("I", smallfont, Brushes.Black, (left_margin + inc * (h + 1)) + (increment * k) - 20, line + 185)
                    End If
                    class_term(k)(0).X = left_margin + h_width + (inc * (h + 1)) / 2 + (increment * k)
                ElseIf h = 1 Then
                    e.Graphics.DrawLine(Pens.Black, left_margin + h_width + inc * (h + 1) + (increment * k), (line + 185) - 5, left_margin + h_width + inc * (h + 1) + (increment * k), line + 185)
                    If Not primary Then
                        e.Graphics.DrawString("II", smallfont, Brushes.Black, (left_margin + inc * (h + 1)) + (increment * k), line + 185)
                    Else
                        e.Graphics.DrawString("II", smallfont, Brushes.Black, (left_margin + inc * (h + 1)) + (increment * k) - 20, line + 185)
                    End If
                    class_term(k)(1).X = class_term(k)(0).X + inc
                ElseIf h = 2 Then
                    If Not primary Then
                        e.Graphics.DrawString("III", smallfont, Brushes.Black, (left_margin + inc * (h + 1)) + (increment * k), line + 185)
                    Else
                        e.Graphics.DrawString("III", smallfont, Brushes.Black, (left_margin + inc * (h + 1)) + (increment * k) - 20, line + 185)
                    End If
                    class_term(k)(2).X = class_term(k)(1).X + inc
                End If
            Next
        Next
        Dim rect As Rectangle
        If bar_graph Then
            If report.color Then
                For k As Integer = 0 To all_classes.Length - 1
                    For h As Integer = 0 To 2
                        If class_term_data(k)(h) Then
                            rect = New Rectangle(class_term(k)(h).X - 8, class_term(k)(h).Y, 20, endline - class_term(k)(h).Y)
                            e.Graphics.FillRectangle(Brushes.Black, rect)
                        End If
                    Next
                Next
            Else
                For k As Integer = 0 To all_classes.Length - 1
                    For h As Integer = 0 To 2
                        If class_term_data(k)(h) Then
                            rect = New Rectangle(class_term(k)(h).X - 8, class_term(k)(h).Y, 20, endline - class_term(k)(h).Y)
                            e.Graphics.FillRectangle(Brushes.Black, rect)
                        End If
                    Next
                Next
            End If
        Else
            Dim linePen As New Pen(Color.Black, 2)
            For k As Integer = 0 To all_classes.Length - 1
                For h As Integer = 0 To 2
                    If h = 0 Then
                        If k > 0 Then
                            If class_term_data(k)(h) And class_term_data(k - 1)(2) Then
                                rect = New Rectangle(class_term(k)(h).X - 4, class_term(k)(h).Y - 4, 8, 8)
                                e.Graphics.DrawEllipse(Pens.Black, rect)
                                e.Graphics.FillEllipse(Brushes.Black, rect)
                                rect = New Rectangle(class_term(k - 1)(2).X - 4, class_term(k - 1)(2).Y - 4, 8, 8)
                                e.Graphics.DrawEllipse(Pens.Black, rect)
                                e.Graphics.FillEllipse(Brushes.Black, rect)
                                e.Graphics.DrawLine(linePen, class_term(k)(h).X, class_term(k)(h).Y, class_term(k - 1)(2).X, class_term(k - 1)(2).Y)
                            End If
                        End If
                    Else
                        If class_term_data(k)(h) And class_term_data(k)(h - 1) Then
                            rect = New Rectangle(class_term(k)(h).X - 4, class_term(k)(h).Y - 4, 8, 8)
                            e.Graphics.DrawEllipse(Pens.Black, rect)
                            e.Graphics.FillEllipse(Brushes.Black, rect)
                            rect = New Rectangle(class_term(k)(h - 1).X - 4, class_term(k)(h - 1).Y - 4, 8, 8)
                            e.Graphics.DrawEllipse(Pens.Black, rect)
                            e.Graphics.FillEllipse(Brushes.Black, rect)
                            e.Graphics.DrawLine(linePen, class_term(k)(h).X, class_term(k)(h).Y, class_term(k)(h - 1).X, class_term(k)(h - 1).Y)
                        End If
                    End If
                Next
            Next
        End If
        For k As Integer = 0 To all_classes.Length - 1
            If ret_name(class_form) = all_classes(k) Then
                If tm = "I" Then
                    If k > 0 Then
                        If class_term_data(k - 1)(2) Then
                            If class_term(k - 1)(2).Y < class_term(k)(0).Y Then
                                perf = "Improve"
                            ElseIf class_term(k)(0).Y < class_term(k - 1)(2).Y Then
                                perf = "Drop"
                            ElseIf class_term(k)(0).Y = class_term(k - 1)(2).Y Then
                                perf = "Constant"
                            End If
                        Else
                            perf = dgvEnterMarks.Item("MG", student).Value
                        End If
                    Else
                        perf = dgvEnterMarks.Item("MG", student).Value
                    End If
                ElseIf tm = "II" Then
                    If k > 0 Then
                        If class_term_data(k)(0) Then
                            If class_term(k)(1).Y < class_term(k)(0).Y Then
                                perf = "Improve"
                            ElseIf class_term(k)(0).Y < class_term(k)(1).Y Then
                                perf = "Drop"
                            ElseIf class_term(k)(1).Y = class_term(k)(0).Y Then
                                perf = "Constant"
                            End If
                        Else
                            perf = dgvEnterMarks.Item("MG", student).Value
                        End If
                    Else
                        perf = dgvEnterMarks.Item("MG", student).Value
                    End If
                ElseIf tm = "III" Then
                    If k > 0 Then
                        If class_term_data(k)(1) Then
                            If class_term(k)(1).Y < class_term(k - 1)(1).Y Then
                                perf = "Improve"
                            ElseIf class_term(k - 1)(1).Y < class_term(k)(1).Y Then
                                perf = "Drop"
                            ElseIf class_term(k)(1).Y = class_term(k - 1)(1).Y Then
                                perf = "Constant"
                            End If
                        Else
                            perf = dgvEnterMarks.Item("MG", student).Value
                        End If
                    Else
                        perf = dgvEnterMarks.Item("MG", student).Value
                    End If
                End If
                Exit For
            End If
        Next
        Dim npen As New Pen(Color.Silver, 1)
        npen.DashStyle = Drawing2D.DashStyle.DashDot
        For k As Integer = 0 To grades.Length - 1
            e.Graphics.DrawString(grades(k), smallfont, Avgpen, left_margin - 5, line)
            e.Graphics.DrawLine(npen, left_margin + 10, line + 9, right_end, line + 9)
            grades_y(k) = line
            line += ht - 4
        Next
        line += 30
        If IsPrimary() Then
            h_width = (right_margin - left_margin) / 3
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            e.Graphics.DrawString("PERFORMANCE INDEX", medium, Brushes.Black, left_margin + 5, line)
            e.Graphics.DrawString("CLASS MEAN MARKS", medium, Brushes.Black, left_margin + (h_width * 1) + 5, line)
            e.Graphics.DrawString("CLASS MEAN GRADE", medium, Brushes.Black, left_margin + (h_width * 2) + 5, line)
            line += 15
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            e.Graphics.DrawString(Format(class_mean_mark(), "0.00"), medium, Brushes.Black, left_margin + (h_width * 1) + 5, line)
            e.Graphics.DrawString(class_mean_grade(), medium, Brushes.Black, left_margin + (h_width * 2) + 5, line)
            line += 15
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 30, left_margin, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + (h_width * 1), line - 30, left_margin + (h_width * 1), line)
            e.Graphics.DrawLine(Pens.Black, left_margin + (h_width * 2), line - 30, left_margin + (h_width * 2), line)
            e.Graphics.DrawLine(Pens.Black, right_margin, line - 30, right_margin, line)
        Else
            vat.Y = y_point_of_grade(vapgrade(dgvEnterMarks.Item("ADMNo", student).Value))
            vat.X = left_margin + 10
            rect = New Rectangle(vat.X, vat.Y, 15, endline - vat.Y)
            If report.color Then
                e.Graphics.FillRectangle(Brushes.Black, rect)
            Else
                e.Graphics.FillRectangle(Brushes.Black, rect)
            End If
            h_width = (right_margin - left_margin) / 5
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            e.Graphics.DrawString("MARKS IN KCPE", other_font, Brushes.Black, left_margin + 5, line)
            e.Graphics.DrawString("RANK IN KCPE", other_font, Brushes.Black, left_margin + (h_width * 1) + 5, line)
            e.Graphics.DrawString("PERF. INDEX", other_font, Brushes.Black, left_margin + (h_width * 2) + 5, line)
            e.Graphics.DrawString("CLASS M. MARKS", other_font, Brushes.Black, left_margin + (h_width * 3) + 5, line)
            e.Graphics.DrawString("CLASS M. GRADE", other_font, Brushes.Black, left_margin + (h_width * 4) + 5, line)
            line += 15
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            e.Graphics.DrawString(get_kcpe_marks(dgvEnterMarks.Item("ADMNo", student).Value) & " / 500", other_font, Brushes.Black, left_margin + 5, line)
            e.Graphics.DrawString(kcpe_rank(dgvEnterMarks.Item("KCPE", student).Value), other_font, Brushes.Black, left_margin + (h_width * 1) + 5, line)
            e.Graphics.DrawString(dgvEnterMarks.Item("VAP", student).Value, other_font, Brushes.Black, left_margin + (h_width * 2) + 5, line)
            e.Graphics.DrawString(Format(class_mean_mark(), "0.00"), other_font, Brushes.Black, left_margin + (h_width * 3) + 5, line)
            e.Graphics.DrawString(class_mean_grade(), other_font, Brushes.Black, left_margin + (h_width * 4) + 5, line)
            line += 15
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 30, left_margin, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + (h_width * 1), line - 30, left_margin + (h_width * 1), line)
            e.Graphics.DrawLine(Pens.Black, left_margin + (h_width * 2), line - 30, left_margin + (h_width * 2), line)
            e.Graphics.DrawLine(Pens.Black, left_margin + (h_width * 3), line - 30, left_margin + (h_width * 3), line)
            e.Graphics.DrawLine(Pens.Black, left_margin + (h_width * 4), line - 30, left_margin + (h_width * 4), line)
            e.Graphics.DrawLine(Pens.Black, right_margin, line - 30, right_margin, line)
        End If
        line += 5
        If subject_ranking_table Then
            e.Graphics.DrawLine(Pens.Black, CInt(right_margin / 2) + 60, startline, right_margin, startline)
            topline = startline
            e.Graphics.DrawString("SUBJECT", smallfont, Brushes.Black, left_margin + CInt(right_margin / 2) + 10, startline)
            e.Graphics.DrawString("RANK IN STR.", smallfont, Brushes.Black, left_margin + CInt(right_margin / 2) + 165, startline)
            e.Graphics.DrawString("RANK IN CL.", smallfont, Brushes.Black, right_margin - 75, startline)
            startline += smallfont.Height
            e.Graphics.DrawLine(Pens.Black, left_margin + CInt(right_margin / 2) - 20, startline, right_margin, startline)
            Dim continue_ As Boolean = False
            For k As Integer = 0 To subjects.Length - 1
                For s As Integer = 0 To subjects_done.Length - 1
                    If subjects(k) = subjects_done(s) Then
                        continue_ = True
                        Exit For
                    End If
                Next
                If continue_ Then
                    If report.color Then
                        If subjects(k).ToString.Length >= 22 Then
                            e.Graphics.DrawString(subjects(k).ToString.Substring(0, 22), smallfont, Brushes.Blue, left_margin + CInt(right_margin / 2) - 10, startline)
                        Else
                            e.Graphics.DrawString(subjects(k), smallfont, Brushes.Blue, left_margin + CInt(right_margin / 2) - 10, startline)
                        End If
                        e.Graphics.DrawString(subject_rank(subjects_done_name(k), dgvEnterMarks.Item(subjabb(k), student).Value, dgvEnterMarks.Item("str_class", student).Value), smallfont, Brushes.Blue, left_margin + CInt(right_margin / 2) + 165, startline)
                        e.Graphics.DrawString(subject_rank(subjects_done_name(k), dgvEnterMarks.Item(subjabb(k), student).Value, String.Empty), smallfont, Brushes.Blue, right_margin - 80, startline)
                    Else
                        If subjects(k).ToString.Length >= 22 Then
                            e.Graphics.DrawString(subjects(k).ToString.Substring(0, 22), smallfont, Brushes.Black, left_margin + CInt(right_margin / 2) - 10, startline)
                        Else
                            e.Graphics.DrawString(subjects(k), smallfont, Brushes.Black, left_margin + CInt(right_margin / 2) - 10, startline)
                        End If
                        e.Graphics.DrawString(subject_rank(subjabb(k), dgvEnterMarks.Item(subjabb(k), student).Value, dgvEnterMarks.Item("str_class", student).Value), smallfont, Brushes.Black, left_margin + CInt(right_margin / 2) + 165, startline)
                        e.Graphics.DrawString(subject_rank(subjabb(k), dgvEnterMarks.Item(subjabb(k), student).Value, String.Empty), smallfont, Brushes.Black, right_margin - 80, startline)
                    End If
                Else
                    If report.color Then
                        e.Graphics.DrawString(subjects(k), smallfont, Brushes.Blue, left_margin + CInt(right_margin / 2) - 10, startline)
                        e.Graphics.DrawString("--", smallfont, Brushes.Blue, left_margin + CInt(right_margin / 2) + 170, startline)
                        e.Graphics.DrawString("--", smallfont, Brushes.Blue, right_margin - 70, startline)
                    Else
                        e.Graphics.DrawString(subjects(k), smallfont, Brushes.Black, left_margin + CInt(right_margin / 2) - 10, startline)
                        e.Graphics.DrawString("--", smallfont, Brushes.Black, left_margin + CInt(right_margin / 2) + 170, startline)
                        e.Graphics.DrawString("--", smallfont, Brushes.Black, right_margin - 70, startline)
                    End If
                End If
                continue_ = False
                startline += smallfont.Height
                e.Graphics.DrawLine(Pens.Black, left_margin + CInt(right_margin / 2) - 20, startline, right_margin, startline)
            Next
            e.Graphics.DrawLine(Pens.Black, left_margin + CInt(right_margin / 2) - 20, startline, left_margin + CInt(right_margin / 2) - 20, topline)
            e.Graphics.DrawLine(Pens.Black, left_margin + CInt(right_margin / 2) + 165, startline, left_margin + CInt(right_margin / 2) + 165, topline)
            e.Graphics.DrawLine(Pens.Black, right_margin - 80, startline, right_margin - 80, topline)
            e.Graphics.DrawLine(Pens.Black, right_margin, topline, right_margin, startline)
        End If
        If attend Then
            If report.color Then
                e.Graphics.DrawString("TOTAL ATTENDANCE:........................", medium, Avgpen, left_margin + 2, line)
                e.Graphics.DrawString(get_total_attendance(dgvEnterMarks.Item("ADMNo", student).Value) & " Out Of " & total_term_days, medium, Avgpen, left_margin + 160, line - 3)
                e.Graphics.DrawString("PERCENTAGE ATTENDANCE:.......................", medium, Avgpen, left_margin + 300, line)
                e.Graphics.DrawString(Format(percentage_attendance, "0.00") & " %", medium, Avgpen, left_margin + 500, line - 3)
            Else
                e.Graphics.DrawString("TOTAL ATTENDANCE:........................", medium, Brushes.Black, left_margin + 2, line)
                e.Graphics.DrawString(get_total_attendance(dgvEnterMarks.Item("ADMNo", student).Value) & " Out Of " & total_term_days, medium, Brushes.Black, left_margin + 160, line - 3)
                e.Graphics.DrawString("PERCENTAGE ATTENDANCE:.......................", medium, Brushes.Black, left_margin + 300, line)
                e.Graphics.DrawString(Format(percentage_attendance, "0.00") & " %", medium, Brushes.Black, left_margin + 500, line - 3)
            End If
            line += 25
        End If
        Dim drline As Integer
        If report.house_master_comments Or report.club_and_societies Then
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            drline = line
        End If
        drline = line
        If report.house_master_comments Then
            line += 2
            e.Graphics.DrawString("HOUSE MASTER'S COMMENTS: ", smallfont, Brushes.Black, left_margin + 2, line)
            line += 18
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 200, line, left_margin + 200, drline)
        End If
        If report.club_and_societies Then
            line += 2
            e.Graphics.DrawString("CLUBS AND SOCIETIES: ", smallfont, Brushes.Black, left_margin + 2, line)
            line += 18
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 200, line, left_margin + 200, drline)
        End If
        e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, drline)
        e.Graphics.DrawLine(Pens.Black, right_margin, line, right_margin, drline)
        line += 2
        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
        drline = line
        line += 2
        e.Graphics.DrawString("CLASS TEACHER'S COMMENTS: ", smallfont, Brushes.Black, left_margin + 2, line + 3)
        If report.class_teacher_comments Then
            'comment of perf variable
            e.Graphics.DrawString(get_class_teacher_comments(class_form, dgvEnterMarks.Item("str_class", student).Value, perf), italisized_font, Brushes.Black, left_margin + 210, line)
        End If
        line += 22
        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
        e.Graphics.DrawLine(Pens.Black, left_margin + 200, line, left_margin + 200, drline)
        e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, drline)
        e.Graphics.DrawLine(Pens.Black, right_margin, line, right_margin, drline)
        line += 15
        If report.class_teacher_name Then
            e.Graphics.DrawString("CLASS TEACHER'S NAME: " & get_class_teacher(dgvEnterMarks.Item("str_class", student).Value, False), smallfont, Brushes.Black, left_margin + 150, line)
        End If
        e.Graphics.DrawString("SIGNATURE:", smallfont, Brushes.Black, left_margin + 450, line)
        If report.class_teacher_signature Then
            If File.Exists(getSignaturePath(get_class_teacher(dgvEnterMarks.Item("str_class", student).Value, False))) Then
                e.Graphics.DrawImage(Image.FromFile(getSignaturePath(get_class_teacher(dgvEnterMarks.Item("str_class", student).Value, False))), left_margin + 550, line - 10, 100, 30)
            End If
        End If
        e.Graphics.DrawString(" ________________________________", smallfont, Brushes.Black, left_margin + 520, line + 5)
        line += 20
        drline = line
        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
        e.Graphics.DrawString("PRINCIPAL'S COMMENTS: ", smallfont, Brushes.Black, left_margin + 2, line + 10)
        If report.head_teacher_comments Then
            'commented on perf
            e.Graphics.DrawString(get_head_teacher_comments(dgvEnterMarks.Item("MG", student).Value), italisized_font, Brushes.Black, left_margin + 210, line)
        End If
        e.Graphics.DrawLine(Pens.Black, left_margin + 200, line + 20, right_margin, line + 20)
        line += 40
        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line)
        e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, drline)
        e.Graphics.DrawLine(Pens.Black, right_margin, line, right_margin, drline)
        e.Graphics.DrawLine(Pens.Black, left_margin + 200, line, left_margin + 200, drline)
        line += 15
        If report.head_teacher_name Then
            e.Graphics.DrawString("PRINCIPAL'S NAME: " & get_head_teacher(), smallfont, Brushes.Black, left_margin + 150, line)
        End If
        e.Graphics.DrawString("SIGNATURE:", smallfont, Brushes.Black, left_margin + 450, line)
        If report.head_teacher_signature Then
            If File.Exists(getSignaturePath(get_head_teacher())) Then
                e.Graphics.DrawImage(Image.FromFile(getSignaturePath(get_head_teacher())), left_margin + 550, line - 10, 100, 30)
            End If
        End If
        e.Graphics.DrawString("_______________________________", smallfont, Brushes.Black, left_margin + 520, line + 5)
        If fee Then
            line += 20
            drline = line
            e.Graphics.DrawString("SCHOOL FEES", other_font, Brushes.Black, left_margin, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 120, line, right_margin - 100, line)
            e.Graphics.DrawString("OUTSTANDING ARREARS", smallfont, Brushes.Black, left_margin + 125, line + 3)
            e.Graphics.DrawString("NEXT TERM FEES", smallfont, Brushes.Black, left_margin + 280, line + 3)
            e.Graphics.DrawString("TOTAL FEES AMOUNT", smallfont, Brushes.Black, left_margin + 440, line + 3)
            line += other_font.Height
            e.Graphics.DrawString(get_fee_bal(dgvEnterMarks.Item("ADMNo", student).Value), smallfont, Brushes.Black, left_margin + 130, line + 5)
            e.Graphics.DrawString(next_term(), smallfont, Brushes.Black, left_margin + 290, line + 5)
            e.Graphics.DrawString(Format(total_fees, "0.00"), smallfont, Brushes.Black, left_margin + 450, line + 5)
            line += 2
            e.Graphics.DrawLine(Pens.Black, left_margin + 120, line, right_margin - 100, line)
            line += other_font.Height + 2
            e.Graphics.DrawLine(Pens.Black, left_margin + 120, line, right_margin - 100, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 120, drline, left_margin + 120, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 275, drline, left_margin + 275, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + 430, drline, left_margin + 430, line)
            e.Graphics.DrawLine(Pens.Black, right_margin - 100, drline, right_margin - 100, line)
        End If
        line += 10
        e.Graphics.DrawString("CLOSING DATE THIS TERM:________________", smallfont, Brushes.Black, left_margin + 50, line)
        If Not report.color Then
            e.Graphics.DrawString(Format(to_close.Day, "00") & "-" & Format(to_close.Month, "00") & "-" & to_close.Year, smallfont, Brushes.Black, left_margin + 220, line - 3)
        Else
            e.Graphics.DrawString(Format(to_close.Day, "00") & "-" & Format(to_close.Month, "00") & "-" & to_close.Year, smallfont, Brushes.Blue, left_margin + 220, line - 3)
        End If
        e.Graphics.DrawString("OPENING DATE NEXT TERM:________________", smallfont, Brushes.Black, left_margin + 450, line)
        If report.color Then
            e.Graphics.DrawString(Format(to_open.Day, "00") & "-" & Format(to_open.Month, "00") & "-" & to_open.Year, smallfont, Brushes.Blue, left_margin + 620, line - 3)
        Else
            e.Graphics.DrawString(Format(to_open.Day, "00") & "-" & Format(to_open.Month, "00") & "-" & to_open.Year, smallfont, Brushes.Black, left_margin + 620, line - 3)
        End If

        line += smallfont.Height + 3
        e.Graphics.DrawString("PARENT'S SIGNATURE: ___________________________________________________________________", smallfont, Brushes.Black, left_margin + 150, line)
        If watermark Then
            Dim g = e.Graphics
            g.TranslateTransform(200, 200)
            If e.PageSettings.Landscape Then
                g.RotateTransform(30)
            Else
                g.RotateTransform(60)
            End If
            g.DrawString(S_NAME, New Font("Arial", 40, FontStyle.Bold), New SolidBrush(Color.FromArgb(64, Color.Black)), 0, 0)
        End If
        If student = to_row Then
            Exit Sub
        Else
            e.HasMorePages = True
            student += 1
            Exit Sub
        End If
    End Sub
    Private Function get_student_category()
        If qread("SELECT student_category FROM students WHERE admin_no='" & escape_string(dgvEnterMarks.Item("ADMNo", student).Value) & "'") Then
            dbreader.Read()
            Return dbreader("student_category")
        Else
            Return "Boarder"
        End If
    End Function
    Private Function next_term()
        Dim term As String = Nothing
        Dim yr1 As Integer
        If tm = "I" Then
            yr1 = yr
            term = "II"
        ElseIf tm = "II" Then
            yr1 = yr
            term = "III"
        ElseIf tm = "III" Then
            yr1 = yr + 1
            term = "I"
        End If
        Dim amt As Double = 0
        'qread("SELECT amount FROM fee_structure WHERE (term='" & term & "' AND class='" & ret_name(class_form) & "' AND year='" & yr1 & "' AND category='" & escape_string(get_student_category()) & "')")
        'While dbreader.Read
        '    amt += dbreader("amount")
        'End While

        'todo fee structure
        '  total_fees += amt
        next_term = Format(amt, "0.00")
    End Function
    ' Dim total_fees As Double
    Dim ignore_class_teacher, ignore_head_teacher As Boolean
    Dim zline As Integer
    Private Function get_head_teacher()
        qread("SELECT head FROM school_details")
        dbreader.Read()
        get_head_teacher = dbreader("head")
    End Function
    Private Function get_class_teacher_comments(ByVal cf As String, ByVal str As String, ByVal performance As String)
        Dim test As String = ret_name(cf)
        qread("SELECT comment FROM class_teachers_comments WHERE (class='" & ret_name(cf) & "' AND stream='" & str & "' AND trend='" & performance & "')")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            get_class_teacher_comments = dbreader("comment")
        Else
            Return String.Empty
        End If
    End Function
    Private Function get_head_teacher_comments(ByVal performance As String)
        qread("SELECT comment FROM head_teachers_comments WHERE  trend='" & performance & "'")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            get_head_teacher_comments = dbreader("comment")
        Else
            Return String.Empty
        End If
    End Function

    Public Function getSignaturePath(ByVal name As String)

        Dim path As String = String.Empty

        qread("SELECT path FROM partners WHERE  partnername ='" & name & "'")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            path = dbreader("path")
        End If

        Return path

    End Function

    Private Function get_class_teacher(ByVal str As String, ByVal initial As Boolean)
        qread("SELECT Teacher FROM class_teachers WHERE Class='" & ret_name(class_form) & "' AND Stream='" & escape_string(str) & "'")
        If initial Then
            If dbreader.RecordsAffected > 0 Then
                dbreader.Read()
                get_class_teacher = dbreader("Teacher")
                Dim names As String() = get_class_teacher.ToString.Split(" ")
                If names.Length > 2 Then
                    get_class_teacher = names(1).ToString.Substring(0, 1) & " " & names(2).ToString.Substring(0, 1)
                Else
                    get_class_teacher = names(1).ToString.Substring(0, 1)
                End If
            Else
                Return String.Empty
            End If
        Else
            If dbreader.RecordsAffected > 0 Then
                dbreader.Read()
                get_class_teacher = dbreader("Teacher")
            Else
                Return String.Empty
            End If
        End If
    End Function

    Private Function subject_rank(ByVal sname As String, ByVal value As String, ByVal stream As String)
        If Not IsNumeric(value) Then
            Return "--"
        Else
            Dim ranks() As Double = Nothing
            Dim count As Integer = 0
            If mode Then
                For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5
                    If stream = String.Empty Then
                        If IsNumeric(dgvEnterMarks.Item(sname, k).Value) Then
                            ReDim Preserve ranks(count)
                            ranks(count) = dgvEnterMarks.Item(sname, k).Value
                            count += 1
                        End If
                    Else
                        If IsNumeric(dgvEnterMarks.Item(sname, k).Value) And dgvEnterMarks.Item("str_class", k).Value = stream Then
                            ReDim Preserve ranks(count)
                            ranks(count) = dgvEnterMarks.Item(sname, k).Value
                            count += 1
                        End If
                    End If
                Next
                Dim temp As Double
                If count > 0 Then
                    For k As Integer = 0 To ranks.Length - 1
                        For l As Integer = k + 1 To ranks.Length - 1
                            If ranks(l) > ranks(k) Then
                                temp = ranks(k)
                                ranks(k) = ranks(l)
                                ranks(l) = temp
                            End If
                        Next
                    Next
                Else
                    Return "--"
                End If
                For k As Integer = 0 To ranks.Length - 1
                    Try
                        If ranks(k) = value Then
                            If k + 1 > ranks.Length Then
                                Return "--"
                            Else
                                Return k + 1 & " Out Of " & ranks.Length
                            End If

                        End If
                    Catch ex As Exception
                        Return "--"
                    End Try
                Next
            Else
                If stream = String.Empty Then
                    query = "SELECT `" & sname & "` FROM " & table & " WHERE Examination='" & escape_string(exam_name) & "' AND Term='" & tm & "' AND Year='" & yr & "'  AND class='" & escape_string(ret_name(class_form)) & "'  ORDER BY " & sname & " DESC"
                Else
                    query = "SELECT `" & sname & "` FROM " & table & " WHERE Examination='" & escape_string(exam_name) & "' AND Stream='" & stream & "' AND Term='" & tm & "' AND Year='" & yr & "'  AND class='" & escape_string(ret_name(class_form)) & "'  ORDER BY " & sname & " DESC"
                End If
                qread(query)
                Dim all As Integer
                While dbreader.Read
                    If IsNumeric(dbreader(sname)) Or dbreader(sname).ToString = "X" Or dbreader(sname).ToString = "Y" Or dbreader(sname).ToString = "x" Or dbreader(sname).ToString = "y" Then
                        all += 1
                    End If
                End While
                If all = 0 Then
                    Return "--"
                End If
                dbreader.Close()
                qread(query)
                Dim i As Integer = 1
                While dbreader.Read
                    Try
                        If CInt(dbreader(sname)) = CInt(value) Then
                            dbreader.Close()
                            If i > all Then
                                Return "--"
                            Else
                                Return i & " Out Of " & all
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    i += 1
                End While
            End If
            Return "--"
        End If
    End Function
    Private Function subject_rank_only(ByVal sname As String, ByVal value As String, ByVal stream As String)
        If Not IsNumeric(value) Then
            Return "--"
        Else
            Dim ranks() As Double = Nothing
            Dim count As Integer = 0
            If mode Then
                For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5
                    If stream = String.Empty Then
                        If IsNumeric(dgvEnterMarks.Item(sname, k).Value) Then
                            ReDim Preserve ranks(count)
                            ranks(count) = dgvEnterMarks.Item(sname, k).Value
                            count += 1
                        End If
                    Else
                        If IsNumeric(dgvEnterMarks.Item(sname, k).Value) And dgvEnterMarks.Item("str_class", k).Value = stream Then
                            ReDim Preserve ranks(count)
                            ranks(count) = dgvEnterMarks.Item(sname, k).Value
                            count += 1
                        End If
                    End If
                Next
                Dim temp As Double
                If count > 0 Then
                    For k As Integer = 0 To ranks.Length - 1
                        For l As Integer = k + 1 To ranks.Length - 1
                            If ranks(l) > ranks(k) Then
                                temp = ranks(k)
                                ranks(k) = ranks(l)
                                ranks(l) = temp
                            End If
                        Next
                    Next
                Else
                    Return "--"
                End If
                For k As Integer = 0 To ranks.Length - 1
                    Try
                        If CInt(ranks(k)) = value Then
                            If k + 1 > ranks.Length Then
                                Return "--"
                            Else
                                Return k + 1
                            End If

                        End If
                    Catch ex As Exception
                        Return "--"
                    End Try
                Next
            Else
                If stream = String.Empty Then
                    query = "SELECT `" & sname & "` FROM " & table & " WHERE Examination='" & escape_string(exam_name) & "' AND Term='" & tm & "' AND class='" & escape_string(ret_name(class_form)) & "' AND Year='" & yr & "' ORDER BY " & sname & " DESC"
                Else
                    query = "SELECT `" & sname & "` FROM " & table & " WHERE Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND class='" & escape_string(ret_name(class_form)) & "'  AND Year='" & yr & "' AND Stream='" & stream & "' ORDER BY " & sname & " DESC"
                End If
                qread(query)
                Dim all As Integer
                While dbreader.Read
                    If IsNumeric(dbreader(sname)) Or dbreader(sname).ToString = "X" Or dbreader(sname).ToString = "Y" Or dbreader(sname).ToString = "x" Or dbreader(sname).ToString = "y" Then
                        all += 1
                    End If
                End While
                If all = 0 Then
                    Return "--"
                End If
                qread(query)
                Dim i As Integer = 1
                While dbreader.Read
                    If IsNumeric(dbreader(sname)) Then
                        If CInt(dbreader(sname)) = CInt(value) Then
                            If i > all Then
                                Return "--"
                            Else
                                Return i
                            End If
                        End If
                    Else
                        Return "--"
                    End If
                    i += 1
                End While
            End If
        End If
        Return "--"
    End Function
    'Dim f1t1, f1t2, f1t3, f2t1, f2t2, f2t3, f3t1, f3t2, f3t3, f4t1, f4t2, f4t3, vat As Point
    Dim class_term(12)(), vat As Point
    'Dim f1t1h, f1t2h, f1t3h, f2t1h, f2t2h, f2t3h, f3t1h, f3t2h, f3t3h, f4t1h, f4t2h, f4t3h As Integer
    Dim class_term_height(12)() As Integer
    Dim only_grade As String
    'Dim f1t1tm, f1t2tm, f1t3tm, f2t1tm, f2t2tm, f2t3tm, f3t1tm, f3t2tm, f3t3tm, f4t1tm, f4t2tm, f4t3tm As Boolean
    Dim class_term_data(12)() As Boolean

    Private Function get_class_performance_data(ByVal tm As String, ByVal cls As String, ByVal yr As Integer) As String
        Dim set_bool As Boolean
        Dim grade As String = Nothing
        If Not qread("SELECT * FROM class_performance_data WHERE ADMNo='" & escape_string(dgvEnterMarks.Item("ADMNo", student).Value) & "' AND term='" & tm & "' AND class='" & all_classes(cls) & "'") Then
            Return String.Empty
        End If
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            get_class_performance_data = "POS:" & dbreader("POS") & " MG:" & dbreader("GRADE") & " MP:" & dbreader("POINTS")
            set_bool = True
            grade = dbreader("GRADE")
        Else
            get_class_performance_data = String.Empty
            set_bool = False
        End If
        If tm = "I" Then
            class_term(cls)(0).Y = y_point_of_grade(grade) + 9
            class_term_data(cls)(0) = set_bool
        ElseIf tm = "II" Then
            class_term(cls)(1).Y = y_point_of_grade(grade) + 9
            class_term_data(cls)(1) = set_bool
        ElseIf tm = "III" Then
            class_term(cls)(2).Y = y_point_of_grade(grade) + 9
            class_term_data(cls)(2) = set_bool
        End If
        only_grade = grade
    End Function

    Private Function y_point_of_grade(ByVal grade As String)
        For k As Integer = 0 To grades.Length - 1
            If grade = grades(k) Then
                Return grades_y(k)
            End If
        Next
        Return zline
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        tables = Nothing
        mode = False
        mod_subject = False
        form_4_mode = False
        grade = False
        Me.Close()
    End Sub

    Private Sub reload()
        If grade Then
            grade = False
            btnGrade.Text = "View In Grade Mode"
        End If
        dgvEnterMarks.Rows.Clear()
        If mode Then
            load_multi()
        Else
            load_entered()
        End If
    End Sub
    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReload.Click
        reload()
    End Sub
    Private Sub gradeview()
        Pbar.Visible = True
        Dim inc = dgvEnterMarks.Rows.Count - 5 / 100
        Dim total As Integer
        If Not mode Then
            total = get_total_mark(exam_name, tm)
        End If
        For i As Integer = 0 To dgvEnterMarks.Rows.Count - 5
            For k As Integer = 0 To subjabb.Length - 1
                If IsNumeric(dgvEnterMarks.Item(subjname(k), i).Value) Then
                    If Not mode Then
                        dgvEnterMarks.Item(subjname(k), i).Value = dgvEnterMarks.Item(subjname(k), i).Value & " " & get_grade((dgvEnterMarks.Item(subjname(k), i).Value / total) * 100, mod_subject, subjabb(k))
                    Else
                        dgvEnterMarks.Item(subjname(k), i).Value = dgvEnterMarks.Item(subjname(k), i).Value & " " & get_grade(dgvEnterMarks.Item(subjname(k), i).Value, mod_subject, subjabb(k))
                    End If
                End If
            Next
            Pbar.Increment(inc)
        Next
        Pbar.Visible = False
        Pbar.Increment(-100)
    End Sub

    Private Sub btnGrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade.Click
        If grade Then
            dgvEnterMarks.Rows.Clear()
            grade = False
            btnViewReport.Enabled = True
            Button1.Enabled = True
            If mode Then
                load_multi()
            Else
                load_entered()
            End If
            btnGrade.Text = "Show Marks + Grades"
        Else
            grade = True
            btnViewReport.Enabled = False
            Button1.Enabled = False
            gradeview()
            btnGrade.Text = "Show Marks Only"
        End If
    End Sub

    Private Sub chkmode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMode.CheckedChanged

        Using New DevExpress.Utils.WaitDialogForm("Computing Please Wait ...")
            If chkMode.Checked Then
                form_4_mode = True
            Else
                form_4_mode = False
            End If
            dgvEnterMarks.Rows.Clear()
            If mode Then
                load_multi()
            Else
                load_entered()
            End If
        End Using

    End Sub
    Private Function get_sciences()
        If qread("SELECT Abbreviation FROM subjects WHERE Department='" & GRP_SCIENCES & "'") Then
            ReDim sciences(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read
                sciences(i) = dbreader("Abbreviation")
                i += 1
            End While
            dbreader.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Private Function get_compulsory()
        If qread("SELECT Abbreviation FROM subjects WHERE  Comment='Compulsory'") Then
            ReDim compulsory(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read
                compulsory(i) = dbreader("Abbreviation")
                i += 1
            End While
            Return True
        Else
            Return False
        End If
    End Function
    Private Function get_humanity()
        If qread("SELECT Abbreviation FROM subjects WHERE  Department='" & GRP_HUMANITIES & "'") Then
            ReDim humanities(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read
                humanities(i) = dbreader("Abbreviation")
                i += 1
            End While
            dbreader.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Private Function get_applied()
        If qread("SELECT Abbreviation FROM subjects WHERE  Department='" & GRP_TECHNICAL & "'") Then
            ReDim applieds(dbreader.RecordsAffected - 1)
            Dim i As Integer = 0
            While dbreader.Read
                applieds(i) = dbreader("Abbreviation")
                i += 1
            End While
            dbreader.Close()
            Return True
        Else
            Return False
        End If
    End Function
    Private Function formfourmode()
        If get_compulsory() Then
            If get_sciences() Then
                If get_humanity() Then
                    get_applied()
                    Return True
                Else
                    failure("Could Not Correctly Determine Any Humanity Subject!")
                    Return False
                End If
            Else
                failure("Could Not Correctly Determine Any Science Subject!")
                Return False
            End If
        Else
            failure("Could Not Correctly Determine Any Compulsory Subject!")
            Return False
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim print_document As System.Drawing.Printing.PrintDocument = prepare_class_list()
        Dim margin As New Margins(10, 10, 10, 10)
        print_document.DefaultPageSettings.Landscape = False
        print_document.DefaultPageSettings.Margins = margin
        print_document.DocumentName = get_name(class_form & " Performance List")
        printpreview.Document = print_document
        print_document.Print()
    End Sub
    Private Function class_mean_mark() As Double
        Dim cnt As Integer = 0
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            class_mean_mark += dgvEnterMarks.Item("MM", k).Value
            If dgvEnterMarks.Item("MM", k).Value <> 0 Then
                cnt += 1
            End If
        Next
        class_mean_mark = class_mean_mark / cnt
    End Function
    Private Function class_mean_grade()
        Dim mean_points As Double
        Dim cnt As Integer = 0
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            mean_points += dgvEnterMarks.Item("MP", k).Value
            If dgvEnterMarks.Item("MP", k).Value <> 0 Then
                cnt += 1
            End If
        Next
        mean_points = mean_points / cnt
        class_mean_grade = get_points(mean_points)
    End Function
    Dim from_row, to_row As Integer
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        resetSchoolName()

        If confirm("Do You Want To Print All Report Forms?") Then
            selected_print = False
            Dim frm2 As New frmPrompt
            frm2.ShowDialog()
            If cont Then
                from_row = 0
                to_row = dgvEnterMarks.Rows.Count - 5
                cont = True
                print_reports = True
                selected_print = True
            End If
        Else
            selected_print = True
            from_row = -1
            to_row = -1
            Dim frm1 As New frmPrintFrom
            frm1.ShowDialog()
            For k As Integer = 0 To dgvEnterMarks.Rows.Count - 4
                If dgvEnterMarks.Item("ADMNo", k).Value = row_from Then
                    from_row = k
                End If
                If dgvEnterMarks.Item("ADMNo", k).Value = row_to Then
                    to_row = k
                    Exit For
                End If
            Next
            print_reports = True
        End If
        'added the below code
        If Not to_continue Then
            Exit Sub
        End If
        'If Not cont Then
        '    Exit Sub
        'End If
        If from_row = -1 Or to_row = -1 Or from_row > to_row Then
            Exit Sub
        End If
        mode_view = False
        If stream_mode Then
            failure("Cannot Print Or View Report Form! Please Consider Analysing Results For The Entire Class")
            Exit Sub
        End If
        cont = False
        Dim frm As New frmDates
        frm.ShowDialog()
        If Not cont Then
            Exit Sub
        End If
        reload()
        If confirm("Are You Sure You Want To Save This Examination Results As End Of Term " & tm & " Results For " & yr & "'") Then
            save_as()
        Else
            Exit Sub
        End If
        i = from_row
        student = i
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report()
        print_document.DefaultPageSettings.Landscape = False
        print_document.DocumentName = "Student Report Forms"
        printpreview.Document = print_document
        print_document.Print()
        Exit Sub
    End Sub
    Private Function getPosition() As Integer

    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmPrompt
        frm.ShowDialog()
        If to_continue Then
            Dim Print_Preview As New PrintPreviewDialog
            Dim print_dialog As New PrintDialog
            Dim print_document As System.Drawing.Printing.PrintDocument = prepare_stream_list()
            Dim margin As New Margins(10, 10, 10, 10)
            print_document.DefaultPageSettings.Landscape = False
            print_document.DefaultPageSettings.Margins = margin
            print_document.DocumentName = get_name(class_form & " " & class_stream & " Performance List")
            printpreview.Document = print_document
            print_document.Print()
        End If
    End Sub
    Private Function get_kcpe_marks(ByVal id As String)
        If qread("SELECT marks_attained_primary FROM students WHERE admin_no='" & id & "'") Then
            dbreader.Read()
            Try
                id = dbreader("marks_attained_primary")
            Catch ex As Exception
                id = 0
            End Try
            dbreader.Close()
        End If
        Return id
    End Function

    Private Sub radSubject_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSubject.CheckedChanged
        If radSubject.Checked Then
            mod_subject = True
        Else
            mod_subject = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        reload()
        If Not grade Then
            grade = True
            gradeview()
            btnGrade.Text = "Marks"
        End If
        pointsview()
    End Sub

    Private Sub pointsview()
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            For j As Integer = 0 To subjabb.Length - 1
                dgvEnterMarks.Item(subjname(j), k).value = fix_point(dgvEnterMarks.Item(subjname(j), k).value)
            Next
            dgvEnterMarks.Item("Total", k).Value = fix_point(dgvEnterMarks.Item("Total", k).Value)
        Next
    End Sub
    Private Function Examination_Message(ByVal adm As String) As String
        Dim Message As String = Nothing
        If mode Then
            For k As Integer = 0 To exam_names.Length - 1
                Message &= exam_names(k)
                If k < exam_names.Length - 1 Then
                    Message &= "/"
                End If
            Next
        Else
            Message = exam_name
        End If
        Message &= ":"
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            If dgvEnterMarks.Item("ADMNo", k).Value = adm Then
                Message &= get_fname(adm) & " "
                If mode Then
                    For s As Integer = 0 To subjabb.Length - 1
                        Message &= subjabb(s) & "=" & dgvEnterMarks.Item(subjname(s), k).Value & ","
                    Next


                    Message &= ",M.G=" & dgvEnterMarks.Item("MG", k).Value
                    Message &= ",M.P=" & dgvEnterMarks.Item("MP", k).Value
                    Message &= ",T.P=" & dgvEnterMarks.Item("TP", k).Value

                    'If grade Then
                    '    Message &= "M.G=" & dgvEnterMarks.Item("Total", k).Value
                    'Else
                    '    Message &= "Total=" & dgvEnterMarks.Item("Total", k).Value & "/" & subjabb.Length * 100
                    'End If

                    Message &= ",C.Pos=" & dgvEnterMarks.Item("Overall", k).Value & ",S.Pos=" &
                    dgvEnterMarks.Item("Position", k).Value
                Else
                    Dim mark As Integer = get_total_mark(exam_name, tm)
                    For s As Integer = 0 To subjabb.Length - 1
                        Try
                            Message &= subjabb(s) & "=" & dgvEnterMarks.Item(subjname(s), k).Value & ","
                        Catch ex As Exception
                            Message &= subjabb(s) & "=" & dgvEnterMarks.Item(subjname(s), k).Value & ","
                        End Try
                    Next

                    Message &= ",M.G=" & dgvEnterMarks.Item("MG", k).Value
                    Message &= ",M.P=" & dgvEnterMarks.Item("MP", k).Value
                    Message &= ",T.P=" & dgvEnterMarks.Item("TP", k).Value

                    'If grade Then
                    '    Message &= "M.G=" & dgvEnterMarks.Item("Total", k).Value
                    'Else
                    '    Message &= "Total=" & dgvEnterMarks.Item("Total", k).Value & "/" & subjabb.Length * mark
                    'End If

                    Message &= ",C.Pos=" & dgvEnterMarks.Item("Overall", k).Value & ",S.Pos=" &
                    dgvEnterMarks.Item("Position", k).Value
                End If
                Exit For
            End If
        Next
        Return Message
    End Function
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Not confirm("Are You Sure You Want To Send The Results As Analysed Above To Parents/Guardians?") Then
            Exit Sub
        End If
        Me.Enabled = False

        If String.IsNullOrEmpty(My.Settings.API) Then
            MsgBox("The API Key Is Missing")
            Return
        End If

        If String.IsNullOrEmpty(My.Settings.APIUserName) Then
            MsgBox("The SMS Username Is Missing")
            Return
        End If

        Cursor.Current = Cursors.WaitCursor
        For k As Integer = 0 To admnos.Length - 1
            admnos(k) = dgvEnterMarks.Item("ADMNo", k).Value
            SendSMS.sendMsg(guardian_no(admnos(k)), Examination_Message(admnos(k)))
        Next
        Cursor.Current = Cursors.Default
        MsgBox("The Student Results Have Been Sent")

        Return
        'OLD CODE
        get_SMS_Details()

        'If String.IsNullOrEmpty(SMS_COM) Then
        '    failure("The modem por has not been set")
        '    Return
        'End If

        Dim modemPort As String = InputBox("Enter Modem5 Port Number", "Enter Value", "Enter port number attached to the modem")
        If String.IsNullOrEmpty(modemPort) Or Not IsNumeric(modemPort) Then
            failure("The modem port number entered is either empty or the value it not a number")
            Return
        End If

        SMS_COM = modemPort

        Dim SMSEngine As New sms(SMS_COM)
        If Not SMSEngine.IsOpen Then
            Dim frm As New frmConfigureModem
            frm.ShowDialog()
            get_SMS_Details()
            SMSEngine = New sms(SMS_COM)
        End If
        If Not SMSEngine.IsOpen Then
            failure("Could Not Automatically Configure your modem!")
            Me.Enabled = True
            Exit Sub
        End If
        Dim done As Boolean = True
        If Not mode Then
            ReDim admnos(dgvEnterMarks.Rows.Count - 5)
        End If
        Dim failed As Boolean = False
        For k As Integer = 0 To admnos.Length - 1
            admnos(k) = dgvEnterMarks.Item("ADMNo", k).Value
            Try
                SMSEngine.SendSMS(guardian_no(admnos(k)), Examination_Message(admnos(k)))
            Catch ex As Exception
                failed = True
                failure("Could Not Send SMS To " & guardian_no(admnos(k)) & ": Error: " & ex.Message)
            End Try
        Next
        If Not failed Then
            success("If your modem is correctly configured and has enough airtime, the message was successfully sent!")
        End If
        SMSEngine.Close()
        Me.Enabled = True
    End Sub

    Private Function guardian_no(ByVal adm As String)
        dbreader.Close()
        Dim phone As String = String.Empty
        Dim result As String = String.Empty
        qread("SELECT Phone FROM parents_guardians WHERE admin_no ='" & adm & "'")
        If dbreader.RecordsAffected > 0 Then
            While dbreader.Read()

                phone = dbreader("Phone")

                If Not String.IsNullOrEmpty(phone) Then
                    If phone.StartsWith("0") Then
                        phone = phone.Remove(0, 1)
                        phone = "+254" + phone
                    ElseIf phone.StartsWith("7") Then
                        phone = "+254" + phone
                    End If
                End If

                If phone.Length <> 13 Then
                    phone = String.Empty
                End If

                result += "-" + phone

            End While
        End If
        dbreader.Close()

        Return result
    End Function

    Private Sub create_query_sms(ByVal no As String, ByVal message As String)
        query &= "(NULL,'" & no & "','" & escape_string(message) & "','" & Today.Date.Date & "','" &
        Now.TimeOfDay.ToString & "','False','','')"
    End Sub

    Private Function issaved()
        qread("SELECT * FROM term_results WHERE (class='" & ret_name(class_form) & "' AND term='" & tm & "' AND year='" & yr & "')")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Close()
            Return True
        Else
            dbreader.Close()
            Return False
        End If
    End Function
    Private Sub save_as()
        Pbar.Visible = True
        Dim inc As Integer = 100 / dgvEnterMarks.Rows.Count - 5
        If issaved() Then
            For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5
                qwrite("DELETE FROM `class_performance_data` WHERE (ADMNo='" & dgvEnterMarks.Item("ADMNo", k).Value & "' AND term='" & tm & "' AND Year='" & yr & "' AND Class='" & ret_name(class_form) & "')")
                Pbar.Increment(inc)
            Next
            qwrite("DELETE FROM term_results WHERE (class='" & ret_name(class_form) & "' AND term='" & tm & "' AND year='" & yr & "')")
        End If
        Pbar.Increment(-100)
        query = "INSERT INTO `class_performance_data` VALUES"
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5
            query &= "('" & dgvEnterMarks.Item("ADMNo", k).Value & "','" & dgvEnterMarks.Item("Overall", k).Value & " / " & dgvEnterMarks.Rows.Count - 4 & "','" & dgvEnterMarks.Item("MG", k).Value &
            "', '" & dgvEnterMarks.Item("MP", k).Value & "', '" & tm & "', '" & yr & "', '" & ret_name(class_form) & "')"
            If k < dgvEnterMarks.Rows.Count - 5 Then
                query &= ","
            End If
            Pbar.Increment(inc)
        Next
        qwrite(query)
        qwrite("INSERT INTO term_results VALUES(NULL, '" & tm & "','" & yr & "','" & ret_name(class_form) & "')")
        success("End Of Term Results Successfully Saved!")
        Pbar.Visible = False
        Pbar.Increment(-100)
    End Sub
    Dim state As Boolean = False
    Dim i As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
    End Sub
    Dim all As Boolean
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        student = dgvEnterMarks.SelectedRows.Item(0).Index
        i = 0
        If confirm("Do You Want Result Slip For The Particular Selected Student? Click No To Print Result Slips For All Students") Then
            controller = dgvEnterMarks.SelectedRows.Item(0).Index
            all = False
            Timer2.Enabled = True
        Else
            If confirm("Result Slip Processing Completed! Estimate Completion Time: " & CInt(((7 * dgvEnterMarks.Rows.Count - 5) / 60) / 3) &
               " Minutes! No Interuptions Please! Continue?") Then
                controller = 0
                Timer2.Enabled = True
                all = True
            End If
        End If
    End Sub
    Dim controller As Integer
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        Dim Print_Preview As New PrintPreviewDialog
        Dim print_dialog As New PrintDialog
        Dim print_document As System.Drawing.Printing.PrintDocument = print_student_result_slip()
        print_document.DefaultPageSettings.Landscape = False
        printpreview.Document = print_document
        Print_Preview.Document = print_document
        If all Then
            print_document.Print()
            If student >= dgvEnterMarks.Rows.Count - 5 Then
                Timer2.Enabled = False
            Else
                Timer2.Enabled = True
            End If
        Else
            Print_Preview.ShowDialog()
        End If
    End Sub

    Private Function print_student_result_slip()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_result_slip
        Return print_document
    End Function

    Private Sub print_result_slip(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim avg As Integer = 415
        Dim subj_pos As Integer = 530
        Dim remarks As Integer = 590
        Dim teacher As Integer = 690
        Dim pt As Integer = 495
        Dim mg As Integer = 455
        Dim exam_width As Integer = 50
        Dim line, i, j As Integer
        Dim left_margin As Integer = 80
        Dim right_margin As Integer = 800
        Dim topline As Integer = 170
        Dim perf As String = Nothing
        Dim CenterPage As Single
        Dim Graphpen As Pen
        Dim Avgpen, RemarksPen, Teacherpen, PointPen, Subjectpen, Mgpen As Brush
        If report.color = True Then
            Graphpen = New Pen(Color.Red, 2)
            Avgpen = Brushes.Blue
            RemarksPen = Brushes.Red
            Teacherpen = Brushes.Blue
            Subjectpen = Brushes.Black
            Mgpen = Brushes.Red
            PointPen = Brushes.Blue
        Else
            Graphpen = New Pen(Color.Black, 2)
            Avgpen = Brushes.Black
            PointPen = Brushes.Black
            RemarksPen = Brushes.Black
            Teacherpen = Brushes.Black
            Subjectpen = Brushes.Black
            Mgpen = Brushes.Black
        End If
        Try
            exam_width = ((avg - (left_margin + 210)) + 70) / tables.Length
        Catch ex As Exception
            exam_width = avg - (left_margin + 210)
        End Try
        line = 20
        If all Then
            For count As Integer = 0 To 1
                If count = 1 Then
                    topline = line + 150
                End If
                If report.school_logo Then
                    Try
                        e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, topline - 155, 90, 90)
                    Catch ex As Exception
                        Timer1.Enabled = False
                        If Not mode_view Then
                            Timer1.Enabled = True
                        End If
                    End Try
                End If
                If report.student_photo Then
                    Try
                        e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & dgvEnterMarks.Item("ADMNo", student).Value & ".jpg"), right_margin - 110, topline - 155, 90, 90)
                    Catch ex As Exception
                        Timer1.Enabled = False
                        If Not mode_view Then
                            Timer1.Enabled = True
                        End If
                    End Try
                End If
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
                'If S_EMAIL <> "" Then
                '    CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("EMAIL ADDRESS: " & S_EMAIL, other_font).Width / 2)
                '    e.Graphics.DrawString("EMAIL ADDRESS: " & S_EMAIL, other_font, Brushes.Black, CenterPage, line)
                '    line += other_font.Height + 5
                'End If
                line -= 5
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("STUDENT RESULT SLIP", other_font).Width / 2)
                e.Graphics.DrawString("STUDENT RESULT SLIP", header_font, Avgpen, CenterPage, line)
                line += header_font.Height + 10
                e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3)
                e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
                e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)
                line += 10
                e.Graphics.DrawString("NAME OF STUDENT:__________________________________________________", other_font, Brushes.Black, left_margin + 2, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("StudentName", student).Value, other_font, Avgpen, left_margin + 150, line - 3)
                e.Graphics.DrawString("ADMISSION NUMBER:_____________", other_font, Brushes.Black, left_margin + 500, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("ADMNo", student).Value, other_font, Avgpen, left_margin + 650, line - 3)
                line += 25
                e.Graphics.DrawString("CLASS:_______________", other_font, Brushes.Black, left_margin + 2, line)
                e.Graphics.DrawString(ret_name(class_form), other_font, Avgpen, left_margin + 60, line - 3)
                e.Graphics.DrawString("STREAM:________________", other_font, Brushes.Black, left_margin + 150, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("str_class", student).Value, other_font, Avgpen, left_margin + 230, line - 3)
                e.Graphics.DrawString("TERM:_______", other_font, Brushes.Black, left_margin + 300, line)
                e.Graphics.DrawString(tm, other_font, Avgpen, left_margin + 350, line - 3)
                e.Graphics.DrawString("YEAR:_________", other_font, Brushes.Black, left_margin + 400, line)
                e.Graphics.DrawString(yr, other_font, Avgpen, left_margin + 450, line - 3)
                e.Graphics.DrawString("DORMITORY:_________________", other_font, Brushes.Black, left_margin + 500, line)
                e.Graphics.DrawString(dormitory(dgvEnterMarks.Item("ADMNo", student).Value), other_font, Avgpen, left_margin + 580, line - 3)
                line = topline
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
                e.Graphics.DrawString("SUBJECT", other_font, Brushes.Black, left_margin + 2, line)
                j = 210
                Try
                    If tables.Length > 1 Then
                        For i = 0 To tables.Length - 1
                            e.Graphics.DrawString(exam_names(i).ToUpper & " /" & total_mark(i) & String.Empty, smallfont, Brushes.Black, left_margin + j, line)
                            j += exam_width
                        Next
                    Else
                        marks = get_total_mark(exam_name, tm)
                        e.Graphics.DrawString(exam_name.ToUpper.ToString.Substring(0, 4) & " /" & marks & String.Empty, other_font, Brushes.Black, left_margin + j, line)
                    End If
                Catch ex As Exception
                    'marks = get_total_mark(exam_name, tm)
                    'e.Graphics.DrawString(exam_name.ToUpper.ToString.Substring(0, 4) & " /" & marks & "", other_font, Brushes.Black, left_margin + j, line)
                End Try
                e.Graphics.DrawString("AVG", other_font, Avgpen, left_margin + avg, line)
                e.Graphics.DrawString("PTS", other_font, PointPen, left_margin + pt, line)
                e.Graphics.DrawString("M.G.", other_font, Mgpen, left_margin + mg, line)
                e.Graphics.DrawString("S.POS", other_font, Mgpen, left_margin + subj_pos, line)
                e.Graphics.DrawString("REMARKS", other_font, RemarksPen, left_margin + remarks, line)
                e.Graphics.DrawString("T.I", other_font, Teacherpen, left_margin + teacher, line)
                line += 20
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
                Dim totals, totals_avg, totals_avg_cnt As Double
                Dim no As Integer = no_of_subjects(dgvEnterMarks.Item("ADMNo", student).Value)
                If Not mode Then
                    Dim total_mark As Integer = get_total_mark(exam_name, tm)
                    If grade Then
                        For k As Integer = 0 To subjects_done.Length - 1
                            totals += (dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100
                            totals_avg += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                            totals_avg_cnt += 1
                            e.Graphics.DrawString(CInt((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), other_font, Brushes.DarkBlue, left_margin + 220, line)
                            e.Graphics.DrawString(CInt((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), other_font, Brushes.DarkBlue, left_margin + avg + 5, line)
                            line += 20
                        Next
                    Else
                        For k As Integer = 0 To subjects_done.Length - 1
                            If IsNumeric(dgvEnterMarks.Item(subjects_done_name(k), student).Value) Then
                                totals += (dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100
                                totals_avg += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                                totals_avg_cnt += 1
                                If report.color Then
                                    e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value & " " & get_grade(dgvEnterMarks.Item(subjects_done_name(k), student).Value, radSubject.Checked, subjects_done_abb(k)), other_font, Brushes.DarkBlue, left_margin + 220, line)
                                Else
                                    e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value & " " & get_grade((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100, radSubject.Checked, subjects_done_abb(k)), other_font, Brushes.Black, left_margin + 220, line)
                                End If
                                e.Graphics.DrawString(CInt((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), other_font, Avgpen, left_margin + avg + 5, line)
                                Try
                                    e.Graphics.DrawString(fix_point(get_grade((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100, radSubject.Checked, subjects_done_abb(k))), other_font, Brushes.Black, left_margin + pt, line)
                                Catch ex As Exception
                                    e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, PointPen, left_margin + pt, line)
                                End Try
                            Else
                                If report.color Then
                                    e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Brushes.DarkBlue, left_margin + 220, line)
                                Else
                                    e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Brushes.Black, left_margin + 220, line)
                                End If
                                e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Avgpen, left_margin + avg + 5, line)
                            End If
                            line += 20
                        Next
                    End If
                    e.Graphics.DrawString(totals_avg & "/" & (marks * totals_avg_cnt), other_font, Brushes.DarkBlue, left_margin + 220, line)
                    e.Graphics.DrawString(CInt(totals), other_font, Avgpen, left_margin + avg + 5, line)
                    e.Graphics.DrawString(dgvEnterMarks.Item("TP", student).Value, other_font, PointPen, left_margin + pt + 5, line)
                    e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, other_font, Mgpen, left_margin + mg + 5, line)
                    line = topline + 20
                    For k As Integer = 0 To subjects_done.Length - 1
                        Try
                            e.Graphics.DrawString(get_comment(get_grade(((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), radSubject.Checked, subjects_done_abb(k)), radSubject.Checked, subjects_done_abb(k)), italisized_font, RemarksPen, left_margin + remarks, line)
                        Catch ex As Exception
                            e.Graphics.DrawString("-", italisized_font, RemarksPen, left_margin + remarks, line)
                        End Try
                        If grade Then
                            e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Mgpen, left_margin + mg, line)
                        Else
                            Try
                                e.Graphics.DrawString(get_grade(((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), radSubject.Checked, subjects_done_abb(k)), other_font, Mgpen, left_margin + mg, line)
                            Catch ex As Exception
                                e.Graphics.DrawString("-", other_font, Mgpen, left_margin + mg, line)
                            End Try
                        End If
                        line += 20
                    Next
                Else
                    j = 210
                    Dim total_ As Double
                    For i = 0 To tables.Length - 1
                        marks = get_total_mark(exam_names(i), tm)
                        total_ = 0
                        line = topline + 20
                        Dim tot_cnt As Integer = 0
                        If qread("SELECT * FROM `" & table & "` WHERE ADMNo='" & dgvEnterMarks.Item("ADMNo", student).Value & "' AND Examination='" & escape_string(tables(i)) & "' AND Term='" & tm & "' AND Year='" & yr & "'") Then
                            tot_cnt = 0
                            tot_cnt = 0
                            dbreader.Read()
                            For k As Integer = 0 To subjects_done.Length - 1
                                Try
                                    e.Graphics.DrawString(dbreader(subjects_done_abb(k)) & " " & get_grade((dbreader(subjects_done_abb(k)) / total_mark(i) * 100), radSubject.Checked, subjects_done_abb(k)), other_font, Brushes.Black, left_margin + j + 2, line)
                                    total_ += dbreader(subjects_done_abb(k))
                                    tot_cnt += 1
                                Catch ex As Exception

                                End Try
                                line += 20
                            Next
                            If chkMode.Checked Then
                                Dim tot As Double
                                For k As Integer = 0 To subjects_7.Length - 1
                                    If subjects_7(k)(8) = dgvEnterMarks.Item("ADMNo", student).Value.ToString Then
                                        tot = 0
                                        For c As Integer = 0 To subjects_7(k).Length - 2
                                            Try
                                                tot += dbreader(subjects_7(k)(c).ToString)
                                                tot_cnt += 1
                                            Catch ex As Exception

                                            End Try
                                        Next
                                        Exit For
                                    End If
                                Next
                                e.Graphics.DrawString(tot & "/" & marks * tot_cnt, other_font, Brushes.Black, left_margin + j + 2, line)
                            Else
                                e.Graphics.DrawString(total_ & "/" & marks * tot_cnt, other_font, Brushes.Black, left_margin + j + 2, line)
                            End If
                            j += exam_width
                            line = 330
                            dbreader.Close()
                        End If
                    Next
                    line = topline + 20
                    For k As Integer = 0 To subjabb.Length - 1
                        Try
                            e.Graphics.DrawString(get_comment(get_grade(dgvEnterMarks.Item(subjects_done_name(k), student).Value, radSubject.Checked, subjects_done_abb(k)), radSubject.Checked, subjects_done_abb(k)), italisized_font, RemarksPen, left_margin + remarks, line)
                        Catch ex As Exception
                            e.Graphics.DrawString("-", italisized_font, RemarksPen, left_margin + remarks, line)
                        End Try
                        If grade Then
                            e.Graphics.DrawString(fix_point(dgvEnterMarks.Item(subjects_done_name(k), student).Value), other_font, PointPen, left_margin + pt + 4, line)
                            e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Mgpen, left_margin + mg + 4, line)
                        Else
                            Try
                                e.Graphics.DrawString(fix_point(get_grade(dgvEnterMarks.Item(subjects_done_name(k), student).Value, radSubject.Checked, subjects_done_abb(k))), other_font, PointPen, left_margin + pt + 4, line)
                                e.Graphics.DrawString(get_grade(dgvEnterMarks.Item(subjects_done_name(k), student).Value, radSubject.Checked, subjects_done_abb(k)), other_font, Mgpen, left_margin + mg + 4, line)
                            Catch ex As Exception

                            End Try
                        End If
                        line += 20
                    Next
                    line = topline + 20
                    If grade Then
                        For k As Integer = 0 To subjects_done.Length - 1
                            totals += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                            e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Avgpen, left_margin + avg + 5, line)
                            line += 20
                        Next
                        e.Graphics.DrawString(totals, other_font, Avgpen, left_margin + avg + 5, line)
                        e.Graphics.DrawString(dgvEnterMarks.Item("TP", student).Value, other_font, PointPen, left_margin + pt + 5, line)
                        e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, other_font, Mgpen, left_margin + mg + 5, line)
                    Else
                        For k As Integer = 0 To subjects_done.Length - 1
                            Try
                                totals += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                            Catch ex As Exception

                            End Try
                            e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Avgpen, left_margin + avg + 5, line)
                            line += 20
                        Next
                        e.Graphics.DrawString(totals, other_font, Avgpen, left_margin + avg + 5, line)
                        e.Graphics.DrawString(dgvEnterMarks.Item("TP", student).Value, other_font, PointPen, left_margin + pt + 5, line)
                        e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, other_font, Mgpen, left_margin + mg + 5, line)
                    End If
                End If
                line = topline + 20
                For k As Integer = 0 To subjects_done.Length - 1
                    If subjects_done(k).Length >= 22 Then
                        e.Graphics.DrawString(subjects_done(k).Substring(0, 22), other_font, Subjectpen, left_margin + 2, line)
                    Else
                        e.Graphics.DrawString(subjects_done(k), other_font, Subjectpen, left_margin + 2, line)
                    End If
                    e.Graphics.DrawString(subject_teacher(dgvEnterMarks.Item("str_class", student).Value, class_form, tm, yr.ToString.Substring(2), subjects_done_abb(k)), other_font, Teacherpen, left_margin + teacher, line)
                    e.Graphics.DrawString(subject_rank_only(subjects_done_name(k), dgvEnterMarks.Item(subjects_done_name(k), student).Value, dgvEnterMarks.Item("str_class", student).Value), other_font, Mgpen, left_margin + subj_pos, line)
                    line += 20
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
                Next
                If grade Then
                    e.Graphics.DrawString("MEAN GRADE", other_font, Brushes.Black, left_margin + 2, line)
                Else
                    e.Graphics.DrawString("TOTAL MARKS/PTS", other_font, Brushes.Black, left_margin + 2, line)
                End If
                line += 20
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
                e.Graphics.DrawString("POSITION", other_font, Brushes.Black, left_margin + 2, line)
                j = 210
                If mode Then
                    For k As Integer = 0 To exam_names.Length - 1
                        e.Graphics.DrawString(position_in_exam(exam_names(k)), other_font, Brushes.Black, left_margin + j, line)
                        j += exam_width
                    Next
                Else
                    e.Graphics.DrawString(position_in_exam(exam_name), other_font, Brushes.Black, left_margin + j, line)
                End If
                line += 20
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline - 2, left_margin - 2, line)
                j = 210
                Try
                    For i = 0 To tables.Length - 1
                        e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line)
                        j += exam_width
                    Next
                Catch ex As Exception
                    e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line)
                End Try
                e.Graphics.DrawLine(Pens.Black, left_margin + avg - 2, topline - 2, left_margin + avg - 2, line)
                e.Graphics.DrawLine(Pens.Black, left_margin + pt - 2, topline - 2, left_margin + pt - 2, line)
                e.Graphics.DrawLine(Pens.Black, left_margin + mg - 2, topline - 2, left_margin + mg - 2, line)
                e.Graphics.DrawLine(Pens.Black, left_margin + subj_pos - 2, topline - 2, left_margin + subj_pos - 2, line)
                e.Graphics.DrawLine(Pens.Black, left_margin + remarks - 2, topline - 2, left_margin + remarks - 2, line)
                e.Graphics.DrawLine(Pens.Black, left_margin + teacher - 2, topline - 2, left_margin + teacher - 2, line)
                e.Graphics.DrawLine(Pens.Black, right_margin + 2, topline - 2, right_margin + 2, line)
                line += 10
                Dim stream_out_of As Integer = 0
                For i = 0 To streams.Length - 1
                    If dgvEnterMarks.Item("str_class", student).Value = streams(i) Then
                        stream_out_of = stream_no(i)
                    End If
                Next
                e.Graphics.DrawString("CLASS POSITION:________________", medium, Avgpen, left_margin + 2, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("Overall", student).Value & " Out Of " & dgvEnterMarks.Rows.Count - 4, medium, RemarksPen, left_margin + 120, line - 2)
                e.Graphics.DrawString("STREAM POSITION:_______________", medium, Avgpen, left_margin + 220, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("Position", student).Value & " Out Of " & stream_out_of - 1, medium, RemarksPen, left_margin + 350, line - 2)
                e.Graphics.DrawString("MEAN GRADE:____", medium, Avgpen, left_margin + 450, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, medium, RemarksPen, left_margin + 545, line - 2)
                e.Graphics.DrawString("MEAN POINTS:________", medium, Avgpen, left_margin + 570, line)
                If IsNumeric(dgvEnterMarks.Item("MP", student).Value) Then
                    e.Graphics.DrawString(dgvEnterMarks.Item("MP", student).Value, medium, RemarksPen, left_margin + 665, line - 5)
                Else
                    e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, medium, RemarksPen, left_margin + 665, line - 5)
                End If
                If student = dgvEnterMarks.Rows.Count - 4 Then
                    Exit For
                End If
                student += 1
                line += 100
            Next
        Else
            If report.school_logo Then
                Try
                    e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & logo()), left_margin + 10, 10, 90, 90)
                Catch ex As Exception
                    Timer1.Enabled = False
                    If Not mode_view Then
                        Timer1.Enabled = True
                    End If
                End Try
            End If
            If report.student_photo Then
                Try
                    e.Graphics.DrawImage(Image.FromFile(path & "\student_images\" & dgvEnterMarks.Item("ADMNo", student).Value & ".jpg"), right_margin - 110, 10, 90, 90)
                Catch ex As Exception
                    Timer1.Enabled = False
                    If Not mode_view Then
                        Timer1.Enabled = True
                    End If
                End Try
            End If
            If S_NAME <> String.Empty Then
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(S_NAME.ToUpper, header_font).Width / 2)
                e.Graphics.DrawString(S_NAME.ToUpper, header_font, Avgpen, CenterPage, line)
                line += header_font.Height + 2
            End If
            If S_ADDRESS <> String.Empty Then
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("P.O. BOX " & S_ADDRESS.ToUpper & ", " & S_LOCATION.ToUpper, other_font).Width / 2)
                e.Graphics.DrawString("P.O. BOX " & S_ADDRESS.ToUpper & ", " & S_LOCATION.ToUpper, other_font, Avgpen, CenterPage, line)
                line += other_font.Height + 5
            End If
            If S_PHONE <> String.Empty Then
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("TELEPHONE: " & S_PHONE, other_font).Width / 2)
                e.Graphics.DrawString("TELEPHONE: " & S_PHONE, other_font, Avgpen, CenterPage, line)
                line += other_font.Height + 5
            End If
            If S_EMAIL <> String.Empty Then
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("EMAIL ADDRESS: " & S_EMAIL, other_font).Width / 2)
                e.Graphics.DrawString("EMAIL ADDRESS: " & S_EMAIL, other_font, Avgpen, CenterPage, line)
                line += other_font.Height + 5
            End If
            line -= 5
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("STUDENT RESULT SLIP", header_font).Width / 2)
            e.Graphics.DrawString("STUDENT RESULT SLIP", header_font, Avgpen, CenterPage, line + 5)
            line += header_font.Height + 10
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3)
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2)
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1)
            line += 10
            e.Graphics.DrawString("NAME OF STUDENT:_______________________________________", other_font, Brushes.Black, left_margin + 2, line)
            e.Graphics.DrawString(dgvEnterMarks.Item("StudentName", student).Value, medium_larger, Avgpen, left_margin + 150, line - 8)
            e.Graphics.DrawString("ADMISSION NUMBER:_______", other_font, Brushes.Black, left_margin + 500, line)
            e.Graphics.DrawString(dgvEnterMarks.Item("ADMNo", student).Value, medium_larger, Avgpen, left_margin + 680, line - 8)
            line += 25
            e.Graphics.DrawString("CLASS:_________", other_font, Brushes.Black, left_margin + 2, line)
            e.Graphics.DrawString(ret_name(class_form).ToString.ToUpper, other_font, Avgpen, left_margin + 60, line - 3)
            e.Graphics.DrawString("STREAM:_________", other_font, Brushes.Black, left_margin + 150, line)
            e.Graphics.DrawString(dgvEnterMarks.Item("str_class", student).Value.ToString.ToUpper, other_font, Avgpen, left_margin + 220, line - 3)
            e.Graphics.DrawString("TERM:_____", other_font, Brushes.Black, left_margin + 300, line)
            e.Graphics.DrawString(tm, other_font, Avgpen, left_margin + 350, line - 2)
            e.Graphics.DrawString("YEAR:______", other_font, Brushes.Black, left_margin + 400, line)
            e.Graphics.DrawString(yr, other_font, Avgpen, left_margin + 450, line - 3)
            e.Graphics.DrawString("DORMITORY:_____________", other_font, Brushes.Black, left_margin + 500, line)
            e.Graphics.DrawString(dormitory(dgvEnterMarks.Item("ADMNo", student).Value).ToString.ToUpper, other_font, Avgpen, left_margin + 600, line - 3)
            line = topline
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
            e.Graphics.DrawString("SUBJECT", other_font, Brushes.Black, left_margin + 2, line)
            j = 210
            Try
                If tables.Length > 1 Then
                    For i = 0 To tables.Length - 1
                        e.Graphics.DrawString(exam_names(i).ToUpper & " /" & total_mark(i) & String.Empty, smallfont, Brushes.Black, left_margin + j, line)
                        j += exam_width
                    Next
                Else
                    marks = get_total_mark(exam_name, tm)
                    e.Graphics.DrawString(exam_name.ToUpper.ToString.Substring(0, 4) & " /" & marks & String.Empty, other_font, Brushes.Black, left_margin + j, line)
                End If
            Catch ex As Exception
                marks = get_total_mark(exam_name, tm)
                e.Graphics.DrawString(exam_name.ToUpper.ToString.Substring(0, 4) & " /" & marks & String.Empty, other_font, Brushes.Black, left_margin + j, line)
            End Try
            e.Graphics.DrawString("AVG", other_font, Avgpen, left_margin + avg, line)
            e.Graphics.DrawString("PTS", other_font, PointPen, left_margin + pt, line)
            e.Graphics.DrawString("M.G.", other_font, Mgpen, left_margin + mg + 3, line)
            e.Graphics.DrawString("S.POS", other_font, Mgpen, left_margin + subj_pos, line)
            e.Graphics.DrawString("REMARKS", other_font, RemarksPen, left_margin + remarks, line)
            e.Graphics.DrawString("T.I", other_font, Teacherpen, left_margin + teacher, line)
            line += 20
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
            Dim totals, totals_avg, totals_avg_cnt As Double
            Dim no As Integer = no_of_subjects(dgvEnterMarks.Item("ADMNo", student).Value)
            If Not mode Then
                Dim total_mark As Integer = get_total_mark(exam_name, tm)
                If grade Then
                    For k As Integer = 0 To subjects_done.Length - 1
                        totals += (dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100
                        totals_avg += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                        totals_avg_cnt += 1
                        e.Graphics.DrawString(CInt((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), other_font, Brushes.DarkBlue, left_margin + 220, line)
                        e.Graphics.DrawString(CInt((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), other_font, Brushes.DarkBlue, left_margin + avg + 5, line)
                        line += 20
                    Next
                Else
                    For k As Integer = 0 To subjects_done.Length - 1
                        If IsNumeric(dgvEnterMarks.Item(subjects_done_name(k), student).Value) Then
                            totals += (dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100
                            totals_avg += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                            totals_avg_cnt += 1
                            If report.color Then
                                e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value & " " & get_grade(dgvEnterMarks.Item(subjects_done_name(k), student).Value, radSubject.Checked, subjects_done_abb(k)), other_font, Brushes.DarkBlue, left_margin + 220, line)
                            Else
                                e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value & " " & get_grade((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100, radSubject.Checked, subjects_done_abb(k)), other_font, Brushes.Black, left_margin + 220, line)
                            End If
                            e.Graphics.DrawString(CInt((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), other_font, Avgpen, left_margin + avg + 5, line)
                            Try
                                e.Graphics.DrawString(fix_point(get_grade((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100, radSubject.Checked, subjects_done_abb(k))), other_font, Brushes.Black, left_margin + pt, line)
                            Catch ex As Exception
                                e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, PointPen, left_margin + pt, line)
                            End Try
                        Else
                            If report.color Then
                                e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Brushes.DarkBlue, left_margin + 220, line)
                            Else
                                e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Brushes.Black, left_margin + 220, line)
                            End If
                            e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Avgpen, left_margin + avg + 5, line)
                        End If
                        line += 20
                    Next
                End If

                e.Graphics.DrawString(totals_avg & "/" & (marks * totals_avg_cnt), other_font, Brushes.DarkBlue, left_margin + 220, line)
                e.Graphics.DrawString(CInt(totals), other_font, Avgpen, left_margin + avg + 5, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("TP", student).Value, other_font, PointPen, left_margin + pt + 5, line)
                e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, other_font, Mgpen, left_margin + mg + 5, line)
                line = topline + 20
                For k As Integer = 0 To subjects_done.Length - 1
                    Try
                        e.Graphics.DrawString(get_comment(get_grade(((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), radSubject.Checked, subjects_done_abb(k)), radSubject.Checked, subjects_done_abb(k)), italisized_font, RemarksPen, left_margin + remarks, line)
                    Catch ex As Exception
                        e.Graphics.DrawString("-", italisized_font, RemarksPen, left_margin + remarks, line)
                    End Try
                    If grade Then
                        e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Mgpen, left_margin + mg, line)
                    Else
                        Try
                            e.Graphics.DrawString(get_grade(((dgvEnterMarks.Item(subjects_done_name(k), student).Value / total_mark) * 100), radSubject.Checked, subjects_done_abb(k)), other_font, Mgpen, left_margin + mg, line)
                        Catch ex As Exception
                            e.Graphics.DrawString("-", other_font, Mgpen, left_margin + mg, line)
                        End Try
                    End If
                    line += 20
                Next
            Else
                j = 210
                Dim total_ As Double
                For i = 0 To tables.Length - 1
                    marks = get_total_mark(exam_names(i), tm)
                    total_ = 0
                    line = topline + 20
                    Dim tot_cnt As Integer = 0
                    If qread("SELECT * FROM `" & table & "` WHERE ADMNo='" & dgvEnterMarks.Item("ADMNo", student).Value & "' AND Examination='" & escape_string(tables(i)) & "' AND Term='" & tm & "' AND Year='" & yr & "'") Then
                        tot_cnt = 0
                        tot_cnt = 0
                        dbreader.Read()
                        For k As Integer = 0 To subjects_done.Length - 1
                            Try
                                e.Graphics.DrawString(dbreader(subjects_done_abb(k)) & " " & get_grade((dbreader(subjects_done_abb(k)) / total_mark(i) * 100), radSubject.Checked, subjects_done_abb(k)), other_font, Brushes.Black, left_margin + j + 2, line)
                                total_ += dbreader(subjects_done_abb(k))
                                tot_cnt += 1
                            Catch ex As Exception

                            End Try
                            line += 20
                        Next
                        If chkMode.Checked Then
                            Dim tot As Double
                            For k As Integer = 0 To subjects_7.Length - 1
                                If subjects_7(k)(8) = dgvEnterMarks.Item("ADMNo", student).Value.ToString Then
                                    tot = 0
                                    For c As Integer = 0 To subjects_7(k).Length - 2
                                        Try
                                            tot += dbreader(subjects_7(k)(c).ToString)
                                            tot_cnt += 1
                                        Catch ex As Exception

                                        End Try
                                    Next
                                    Exit For
                                End If
                            Next
                            e.Graphics.DrawString(tot & "/" & marks * tot_cnt, other_font, Brushes.Black, left_margin + j + 2, line)
                        Else
                            e.Graphics.DrawString(total_ & "/" & marks * tot_cnt, other_font, Brushes.Black, left_margin + j + 2, line)
                        End If
                        j += exam_width
                        line = 330
                        dbreader.Close()
                    End If
                Next
                line = topline + 20
                For k As Integer = 0 To subjabb.Length - 1
                    Try
                        e.Graphics.DrawString(get_comment(get_grade(dgvEnterMarks.Item(subjects_done_name(k), student).Value, radSubject.Checked, subjects_done_abb(k)), radSubject.Checked, subjects_done_abb(k)), italisized_font, RemarksPen, left_margin + remarks, line)
                    Catch ex As Exception
                        e.Graphics.DrawString("-", italisized_font, RemarksPen, left_margin + remarks, line)
                    End Try
                    If grade Then
                        e.Graphics.DrawString(fix_point(dgvEnterMarks.Item(subjects_done_name(k), student).Value), other_font, PointPen, left_margin + pt + 4, line)
                        e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Mgpen, left_margin + mg + 4, line)
                    Else
                        Try
                            e.Graphics.DrawString(fix_point(get_grade(dgvEnterMarks.Item(subjects_done_name(k), student).Value, radSubject.Checked, subjects_done_abb(k))), other_font, PointPen, left_margin + pt + 4, line)
                            e.Graphics.DrawString(get_grade(dgvEnterMarks.Item(subjects_done_name(k), student).Value, radSubject.Checked, subjects_done_abb(k)), other_font, Mgpen, left_margin + mg + 4, line)
                        Catch ex As Exception

                        End Try
                    End If
                    line += 20
                Next
                line = topline + 20
                If grade Then
                    For k As Integer = 0 To subjects_done.Length - 1
                        totals += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                        e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Avgpen, left_margin + avg + 5, line)
                        line += 20
                    Next
                    e.Graphics.DrawString(totals, other_font, Avgpen, left_margin + avg + 5, line)
                    e.Graphics.DrawString(dgvEnterMarks.Item("TP", student).Value, other_font, PointPen, left_margin + pt + 5, line)
                    e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, other_font, Mgpen, left_margin + mg + 5, line)
                Else
                    For k As Integer = 0 To subjects_done.Length - 1
                        Try
                            totals += dgvEnterMarks.Item(subjects_done_name(k), student).Value
                        Catch ex As Exception

                        End Try
                        e.Graphics.DrawString(dgvEnterMarks.Item(subjects_done_name(k), student).Value, other_font, Avgpen, left_margin + avg + 5, line)
                        line += 20
                    Next
                    e.Graphics.DrawString(totals, other_font, Avgpen, left_margin + avg + 5, line)
                    e.Graphics.DrawString(dgvEnterMarks.Item("TP", student).Value, other_font, PointPen, left_margin + pt + 5, line)
                    e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, other_font, Mgpen, left_margin + mg + 5, line)
                End If
            End If
            line = topline + 20
            For k As Integer = 0 To subjects_done.Length - 1
                If subjects_done(k).Length >= 22 Then
                    e.Graphics.DrawString(subjects_done(k).Substring(0, 22), other_font, Subjectpen, left_margin + 2, line)
                Else
                    e.Graphics.DrawString(subjects_done(k), other_font, Subjectpen, left_margin + 2, line)
                End If
                e.Graphics.DrawString(subject_teacher(dgvEnterMarks.Item("str_class", student).Value, class_form, tm, yr.ToString.Substring(2), subjects_done_abb(k)), smallfont, Teacherpen, left_margin + teacher, line)
                e.Graphics.DrawString(subject_rank_only(subjects_done_name(k), dgvEnterMarks.Item(subjects_done_name(k), student).Value, dgvEnterMarks.Item("str_class", student).Value), other_font, Mgpen, left_margin + subj_pos, line)
                line += 20
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
            Next
            If grade Then
                e.Graphics.DrawString("MEAN GRADE", other_font, Brushes.Black, left_margin + 2, line)
            Else
                e.Graphics.DrawString("TOTAL MARKS/PTS", other_font, Brushes.Black, left_margin + 2, line)
            End If
            line += 20
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
            e.Graphics.DrawString("POSITION", other_font, Brushes.Black, left_margin + 2, line)
            j = 210
            If mode Then
                For k As Integer = 0 To exam_names.Length - 1
                    e.Graphics.DrawString(position_in_exam(exam_names(k)), other_font, Brushes.Black, left_margin + j, line)
                    j += exam_width
                Next
            Else
                e.Graphics.DrawString(position_in_exam(exam_name), other_font, Brushes.Black, left_margin + j, line)
            End If
            line += 20
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2)
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline - 2, left_margin - 2, line)
            j = 210
            Try
                For i = 0 To tables.Length - 1
                    e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line)
                    j += exam_width
                Next
            Catch ex As Exception
                e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line)
            End Try
            e.Graphics.DrawLine(Pens.Black, left_margin + avg - 2, topline - 2, left_margin + avg - 2, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + pt - 2, topline - 2, left_margin + pt - 2, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + mg - 2, topline - 2, left_margin + mg - 2, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + subj_pos - 2, topline - 2, left_margin + subj_pos - 2, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + remarks - 2, topline - 2, left_margin + remarks - 2, line)
            e.Graphics.DrawLine(Pens.Black, left_margin + teacher - 2, topline - 2, left_margin + teacher - 2, line)
            e.Graphics.DrawLine(Pens.Black, right_margin + 2, topline - 2, right_margin + 2, line)
            line += 10
            Dim stream_out_of As Integer = 0
            For i = 0 To streams.Length - 1
                If dgvEnterMarks.Item("str_class", student).Value = streams(i) Then
                    stream_out_of = stream_no(i)
                End If
            Next
            e.Graphics.DrawString("CLASS POSITION:________________", medium, Avgpen, left_margin + 2, line)
            e.Graphics.DrawString(dgvEnterMarks.Item("Overall", student).Value & " Out Of " & dgvEnterMarks.Rows.Count - 4, medium, RemarksPen, left_margin + 120, line - 2)
            e.Graphics.DrawString("STREAM POSITION:_______________", medium, Avgpen, left_margin + 220, line)
            e.Graphics.DrawString(dgvEnterMarks.Item("Position", student).Value & " Out Of " & stream_out_of - 1, medium, RemarksPen, left_margin + 350, line - 2)
            e.Graphics.DrawString("MEAN GRADE:____", medium, Avgpen, left_margin + 450, line)
            e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, medium, RemarksPen, left_margin + 545, line - 2)
            e.Graphics.DrawString("MEAN POINTS:________", medium, Avgpen, left_margin + 570, line)
            If IsNumeric(dgvEnterMarks.Item("MP", student).Value) Then
                e.Graphics.DrawString(dgvEnterMarks.Item("MP", student).Value, medium, RemarksPen, left_margin + 665, line - 5)
            Else
                e.Graphics.DrawString(dgvEnterMarks.Item("MG", student).Value, medium, RemarksPen, left_margin + 665, line - 5)
            End If
        End If
    End Sub

    Private Sub dgvEnterMarks_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvEnterMarks.RowsAdded
        dgvEnterMarks.Rows(dgvEnterMarks.Rows.Count - 1).Cells("MP").ValueType = GetType(System.Double)
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim filename As String = SaveFileDialog1.FileName
            If filename = Nothing Then
                filename = Environment.GetEnvironmentVariable("HOMEDRIVE") & "\export_data"
            End If
            Dim saveas As String = filename
            filename &= ".csv"
            FileOpen(1, filename, OpenMode.Output)
            Dim line As String = Nothing
            For k As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                line &= dgvEnterMarks.Columns(k).HeaderText
                If k < dgvEnterMarks.Columns.Count - 1 Then
                    line &= ","
                End If
            Next
            line += vbNewLine
            For row As Integer = 0 To dgvEnterMarks.Rows.Count - 1
                For col As Integer = 0 To dgvEnterMarks.Columns.Count - 1
                    line &= dgvEnterMarks.Item(dgvEnterMarks.Columns(col).Name, row).Value
                    If col < dgvEnterMarks.Columns.Count - 1 Then
                        line &= ","
                    End If
                Next
                line += vbNewLine
            Next
            Print(1, line)
            FileClose(1)
            Try
                Dim oExcelFile As Object
                Try
                    oExcelFile = GetObject(, "Excel.Application")
                Catch
                    oExcelFile = CreateObject("Excel.Application")
                End Try
                oExcelFile.Visible = False
                oExcelFile.Workbooks.Open(SaveFileDialog1.FileName)
                oExcelFile.DisplayAlerts = False
                ' todo oExcelFile.ActiveWorkbook.SaveAs(Filename:=saveas, FileFormat:=Excel.XlFileFormat.xlExcel5, CreateBackup:=False)
                oExcelFile.ActiveWorkbook.Close(SaveChanges:=False)
                oExcelFile.DisplayAlerts = True
                oExcelFile.Quit()
                File.Delete(filename)
                success("Data Successfully Exported To " & filename & ".xls")
            Catch ex As Exception
                failure("Failed to initialize Excel application. Please restart your computer and try again")
            End Try
        End If

    End Sub
    Private Sub print_subject(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim left_margin As Integer = 200
        Dim right_margin As Integer = 3000
        Dim topline As Integer = 200
        Dim line, inc As Integer
        Dim bottomline As Integer = 2000
        inc = (bottomline - topline) / grades.Length
        line = topline
        e.Graphics.DrawLine(Pens.Black, left_margin, topline - 30, left_margin, bottomline)
        e.Graphics.DrawLine(Pens.Black, left_margin, bottomline, right_margin, bottomline)
        Dim npen As New Pen(Color.Silver, 1)
        npen.DashStyle = Drawing2D.DashStyle.DashDot
        For k As Integer = 0 To grades.Length - 1
            e.Graphics.DrawString(grades(k), header_font, Brushes.Black, left_margin - 40, line)
            e.Graphics.DrawLine(npen, left_margin, line, right_margin, line)
            line += inc
        Next
        Dim grade_lines(grades.Length - 1), found
        For k As Integer = 0 To grades.Length - 1
            grade_lines(k) = topline + (inc * k)
        Next
        print_exams()
        Dim column As Integer = 70
        For k As Integer = 0 To exams_done.Length - 1
            e.Graphics.DrawString(k + 1, header_font, Brushes.Black, (left_margin + ((k + 1) * column)) - (0.75 * column), bottomline + 40)
        Next
        line = bottomline + 100
        Dim col As Integer = 0
        For k As Integer = 0 To exams_done.Length - 1
            e.Graphics.DrawString(k + 1 & ":  " & exam_done_name(k), header_font, Brushes.Black, left_margin + col, line)
            line += header_font.Height + 5
            If k = 3 Then
                col += column
                line = bottomline + 100
            End If
        Next
        found = 0
        Dim pencil(subjabb.Length - 1) As Pen
        Dim colors(subjabb.Length - 1) As Color
        colors(0) = Color.Blue
        colors(1) = Color.Green
        colors(2) = Color.Yellow
        colors(3) = Color.Red
        colors(4) = Color.Purple
        colors(5) = Color.Orange
        colors(6) = Color.Navy
        colors(7) = Color.Brown
        colors(8) = Color.YellowGreen
        colors(9) = Color.Violet
        colors(10) = Color.LimeGreen
        'colors(11) = Color.LimeGreen
        For k As Integer = 0 To pencil.Length - 1
            pencil(k) = New Pen(colors(k), 5)
        Next
        Dim brush(pencil.Length - 1) As Brush
        brush(0) = Brushes.Blue
        brush(1) = Brushes.Green
        brush(2) = Brushes.Yellow
        brush(3) = Brushes.Red
        brush(4) = Brushes.Purple
        brush(5) = Brushes.Orange
        brush(6) = Brushes.Navy
        brush(7) = Brushes.Brown
        brush(8) = Brushes.YellowGreen
        brush(9) = Brushes.Violet
        brush(10) = Brushes.LimeGreen
        brush(11) = Brushes.AliceBlue
        Dim line_points(exams_done.Length - 1)() As Point
        For k As Integer = 0 To line_points.Length - 1
            ReDim line_points(k)(subjabb.Length - 1)
        Next
        For ex As Integer = 0 To exams_done.Length - 1
            For k As Integer = 0 To subjabb.Length - 1
                qread("SELECT `grade` FROM subjects_progress WHERE (subject='" & subject_get(subjids(k)) &
                      "' AND admno='" & dgvEnterMarks.Item("ADMNo", student).Value & "' AND term='" & tm &
                      "' AND year='" & yr & "' AND exam='" & ex_done_name(ex) & "')")
                dbreader.Read()
                For g As Integer = 0 To grades.Length - 1
                    Try
                        If dbreader("grade") = grades(g) Then
                            found = grade_lines(g)
                            Exit For
                        End If
                    Catch exept As Exception
                        Exit For
                    End Try
                Next
                dbreader.Close()
                line_points(ex)(k) = New Point(CInt((left_margin + ((ex + 1) * column)) - (0.75 * column)), found)
                e.Graphics.DrawEllipse(pencil(k), CInt((left_margin + ((ex + 1) * column)) - (0.75 * column)), found - 5, 10, 10)
                e.Graphics.FillEllipse(brush(k), CInt((left_margin + ((ex + 1) * column)) - (0.75 * column)), found - 5, 10, 10)
            Next
        Next
        For k As Integer = 0 To subjabb.Length - 1
            For m As Integer = 1 To exams_done.Length - 1
                'e.Graphics.DrawCurve(Pens.Black, line_points(m), 5)
                e.Graphics.DrawLine(pencil(k), line_points(m)(k).X, line_points(m)(k).Y, line_points(m - 1)(k).X, line_points(m - 1)(k).Y)
            Next
        Next
        Dim rect As Rectangle
        rect.Y = bottomline + 120
        rect.X = left_margin + 1000
        rect.Width = 60
        rect.Height = 30
        rect.Y = bottomline + 120
        For k As Integer = 0 To subjabb.Length - 1
            e.Graphics.DrawRectangle(pencil(k), rect)
            e.Graphics.FillRectangle(brush(k), rect)
            e.Graphics.DrawString(subjects(k), head_small, brush(k), rect.X + 100, rect.Y + 10)
            If (k + 1) Mod 4 = 0 And k <> 0 Then
                rect.X = rect.X + 600
                rect.Y = bottomline + 70
            End If
            rect.Y = rect.Y + 50
        Next
    End Sub

    Private Sub print_exams()
        Dim cur_form, exit_form, forms(), term_out As String
        Dim start_form(), end_form() As String
        Dim yr(), year_out As Integer
        If qread("SELECT CurrentClass, YearOut, TermOut, ClassAdmitted FROM students WHERE ADMNo='" & dgvEnterMarks("ADMNo", student).Value & "'") Then
            dbreader.Read()
            exit_form = dbreader("CurrentClass")
            cur_form = dbreader("ClassAdmitted")
            If cur_form = String.Empty Then
                cur_form = "Form 1"
            End If
            If dbreader("YearOut") = 0 Then
                year_out = Today.Year
            Else
                year_out = dbreader("YearOut")
            End If
            If dbreader("TermOut") = String.Empty Then
                get_term()
                term_out = term
            Else
                term_out = dbreader("TermOut")
            End If
            dbreader.Close()
            start_form = cur_form.Split(" ")
            end_form = exit_form.Split(" ")
            Dim count As Integer = CInt(end_form(1)) - CInt(start_form(1))
            ReDim forms(count)
            ReDim yr(count)
            For k As Integer = 0 To count
                forms(k) = "Form " & k + 1
            Next
            For k As Integer = count To 0 Step -1
                yr(k) = year_out - k
            Next
            count = 0
            Dim j As Integer = 0
            For k As Integer = yr.Length - 1 To 0 Step -1
                If qread("SELECT * FROM examinations WHERE Year='" & yr(k) & "' AND (Term='I' OR Term='II' OR Term='III') AND Classes LIKE '%" & forms(count) & "%'") Then
                    If k = yr.Length - 1 Then
                        j = 0
                        ReDim exam_name_(dbreader.RecordsAffected - 1)
                        ReDim exams(dbreader.RecordsAffected - 1)
                        ReDim total(dbreader.RecordsAffected - 1)
                        ReDim ex_name(dbreader.RecordsAffected - 1)
                    Else
                        ReDim Preserve exams(exams.Length - 1 + dbreader.RecordsAffected)
                        ReDim Preserve exam_name_(exam_name.Length - 1 + dbreader.RecordsAffected)
                        ReDim Preserve total(total.Length - 1 + dbreader.RecordsAffected)
                        ReDim Preserve ex_name(ex_name.Length - 1 + dbreader.RecordsAffected)
                    End If
                    While dbreader.Read
                        exams(j) = dbreader("Term") & "_" & dbreader("Year").ToString.Substring(2) & "_" & get_name(dbreader("ExamName")) & "_" & get_name(forms(count))
                        exam_name_(j) = dbreader("ExamName") & " Term " & dbreader("Term") & " " & dbreader("Year")
                        total(j) = dbreader("Total")
                        ex_name(j) = dbreader("ExamName")
                        j += 1
                    End While
                End If
                count += 1
            Next
            dbreader.Close()
            'print_examination()
            Dim exam_count As Integer = 0
            For k As Integer = 0 To exams.Length - 1
                If qread("SELECT * FROM `" & exams(k) & "` WHERE ADMNo='" & dgvEnterMarks.Item("ADMNo", student).Value & "'") Then
                    If dbreader.RecordsAffected > 0 Then
                        exam_count += 1
                        If exam_count = 1 Then
                            ReDim exam_done_name(exam_count - 1)
                            ReDim exams_done(exam_count - 1)
                            ReDim total_done(exam_count - 1)
                            ReDim ex_done_name(exam_count - 1)
                        Else
                            ReDim Preserve exam_done_name(exam_count - 1)
                            ReDim Preserve exams_done(exam_count - 1)
                            ReDim Preserve total_done(exam_count - 1)
                            ReDim Preserve ex_done_name(exam_count - 1)
                        End If
                        exams_done(exam_count - 1) = exams(k)
                        exam_done_name(exam_count - 1) = exam_name_(k)
                        total_done(exam_count - 1) = total(k)
                        ex_done_name(exam_count - 1) = ex_name(k)
                    End If
                End If
                dbreader.Close()
            Next
        End If
    End Sub
    Dim exams(), exam_name_(), exams_done(), exam_done_name(), ex_name(), ex_done_name() As String
    Dim total(), total_done() As Integer

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If confirm("Are You Sure You Want To Save This Analysis As Examination Performance For This Particular Examination?") Then
            save_examination()
        End If
    End Sub

    Private Sub save_examination()
        'Dim inc As Integer = dgvEnterMarks.Rows.Count - 4 / 100
        'qwrite("CREATE TABLE `examination_performance` (" &
        '        "`id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY ," &
        '        "`ADMNo` BIGINT( 255 ) NOT NULL," &
        '        "`exam` VARCHAR( 255 ) NOT NULL , " &
        '        "`term` VARCHAR( 255 ) NOT NULL , " &
        '        "`year` BIGINT(255) NOT NULL ," &
        '        "`pos` VARCHAR(20) NOT NULL" &
        '        "	INDEX `FK_examination_performance_students` (`ADMNo`)," &
        '     "CONSTRAINT `FK_examination_performance_students` FOREIGN KEY (`ADMNo`) REFERENCES `students` (`ADMNo`) ON UPDATE CASCADE ON DELETE CASCADE" &
        '        ") ENGINE = Innodb ;")
        Pbar.Increment(-100)
        Pbar.Visible = True

        'For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5

        Dim inc As Integer = 100 / dgvEnterMarks.Rows.Count - 5
        If issaved() Then
            For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5
                Dim test As String = "SELECT * FROM examination_performance WHERE (ADMNo='" & dgvEnterMarks.Item("ADMNo", k).Value & "' AND exam='" & exam_name & "' AND term='" & tm & "' AND year='" & yr & "')"

                qread("SELECT * FROM examination_performance WHERE (ADMNo='" & dgvEnterMarks.Item("ADMNo", k).Value & "' AND exam='" & exam_name & "' AND term='" & tm & "' AND year='" & yr & "')")
                If dbreader.RecordsAffected > 0 Then
                    qwrite("UPDATE examination_performance SET pos='" & dgvEnterMarks.Item("Overall", k).Value & "/" & dgvEnterMarks.Rows.Count - 4 & "' WHERE (ADMNo='" & dgvEnterMarks.Item("ADMNo", k).Value & "' AND exam='" & exam_name & "' AND term='" & tm & "' AND year='" & yr & "')")
                Else
                    qwrite("INSERT INTO examination_performance VALUES(NULL, '" & dgvEnterMarks.Item("ADMNo", k).Value & "', '" & exam_name & "', '" & tm & "','" & yr & "','" & dgvEnterMarks.Item("Overall", k).Value & "/" & dgvEnterMarks.Rows.Count - 4 & "')")
                End If
                Pbar.Increment(inc)
            Next
            '    Pbar.Visible = False
            'success("Examination Performance Saved!")

            'Pbar.Visible = True

            'qwrite("DELETE FROM `class_performance_data` WHERE (ADMNo='" & dgvEnterMarks.Item("ADMNo", k).Value & "' AND term='" & tm & "' AND Year='" & yr & "' AND Class='" & ret_name(class_form) & "')")
            'Pbar.Increment(inc)
            'Next
            qwrite("DELETE FROM term_results WHERE (class='" & ret_name(class_form) & "' AND term='" & tm & "' AND year='" & yr & "')")

            'Pbar.Increment(-100)
            query = "INSERT INTO `class_performance_data` VALUES"
        End If
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5
            query &= "('" & dgvEnterMarks.Item("ADMNo", k).Value & "','" & dgvEnterMarks.Item("Overall", k).Value & " / " & dgvEnterMarks.Rows.Count - 4 & "','" & dgvEnterMarks.Item("MG", k).Value &
            "', '" & dgvEnterMarks.Item("MP", k).Value & "', '" & tm & "', '" & yr & "', '" & ret_name(class_form) & "')"
            If k < dgvEnterMarks.Rows.Count - 5 Then
                query &= ","
            End If
            Pbar.Increment(inc)
        Next
        qwrite(query)
        qwrite("INSERT INTO term_results VALUES(NULL, '" & tm & "','" & yr & "','" & ret_name(class_form) & "')")
        success("End Of Term Results Successfully Saved!")
        Pbar.Visible = False
        Pbar.Increment(-100)
    End Sub
    Private Function SchoolCode()
        qread("SELECT code FROM school_details")
        dbreader.Read()
        Return dbreader("code")
    End Function
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim code As String = SchoolCode()
        If code.Length < 6 Then
            If Not confirm("Your School Code May Not Have Been Set! Do You Want To Continue Anyway?") Then
                Exit Sub
            End If
        End If
        Dim index As String
        start()
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 4
            If k < 9 Then
                index = code & "00" & k + 1
            ElseIf k < 99 Then
                index = code & "0" & k + 1
            Else
                index = code & k + 1
            End If
            If Not qwrite("UPDATE students SET indexno = '" & index & "' WHERE admin_no =  '" & dgvEnterMarks.Item("ADMNo", k).Value & "'") Then
                rollback()
                failure("Could Not Successfully Perform Index Numbering!")
                Exit Sub
            End If
        Next
        commit()
        success("Student Index Numbering Successfully Saved")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Dim counts(streams.Length - 1), sums(streams.Length - 1) As Double
        For k As Integer = 0 To dgvEnterMarks.Rows.Count - 4
            If dgvEnterMarks.Item("ENG", k).Value.ToString <> "-" Then
                For s As Integer = 0 To streams.Length - 1
                    If dgvEnterMarks.Item("str_class", k).Value = streams(s) Then
                        If IsNumeric(dgvEnterMarks.Item("ENG", k).Value) Then
                            sums(s) += dgvEnterMarks.Item("ENG", k).Value
                        End If
                        counts(s) += 1
                    End If
                Next
            End If
        Next
        Dim result As String = Nothing
        For k As Integer = 0 To streams.Length - 1
            result &= " Stream: " & streams(k) & " SUM: " & sums(k) & " COUNT: " & counts(k) & vbNewLine
        Next
        MsgBox(result)
    End Sub

    Private Sub frmResults_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Not search_teachers Then
            Me.Close()
        End If
    End Sub
End Class