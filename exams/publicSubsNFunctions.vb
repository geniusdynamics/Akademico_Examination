Imports System.Environment

Module publicSubsNFunctions

    Public dbconn As Odbc.OdbcConnection
    Public dbcommand As Odbc.OdbcCommand
    Public dbreader As Odbc.OdbcDataReader
    Public dbreader1 As Odbc.OdbcDataReader
    Public successful, search_teachers, analysis_mode, grading, rank As Boolean
    Public cont As Boolean = False
    Public fee As Boolean = False
    Public subjects(), subjabb(), subjname(), subjids(), grades(), exam_names(), grades_y(), sequence(), yrs(), tms(), all_classes()
    Public class_stream, query, table, exam_name, tm, class_form, stream, subj, title, msg, t_name, term, streams(), operation, rpt As String
    Public yr, USER_ID, ENTITY_ID, t_id, contribution(), total_mark(), marks As Integer
    Public S_NAME, S_FAX, S_PHONE, S_LOCATION, S_ADDRESS, S_EMAIL, subject, tables(), SMS_Center, SMS_COM, ThisUser(), classIDs() As String
    Public bigfont As String = "Arial"
    Public fontname As String = "Arial"
    Public biggerfont As String = "Arial"
    Public biggersize As Integer = "15"
    Public bigsize As Integer = "14"
    Public headsmall As Integer = "12"
    Public othersize As Integer = "11"
    Public smallsize As Integer = "10"
    Public small_font As Integer = "8"
    Public GRP_SCIENCES = "SCIENCE"
    Public GRP_HUMANITIES = "HUMANITIES"
    Public GRP_TECHNICAL = "TECHNICAL"
    Public sortby As String
    Public modules(5), show_sending, bar_graph, NewOpen As Boolean
    Public page_line As String = "....................................................................................................."
    Public to_close, to_open As Date
    Public stud As Boolean = False
    Public medium_larger As New Font(biggerfont, biggersize, FontStyle.Regular)
    Public medium As New Font(bigfont, othersize - 1, FontStyle.Regular)
    Public head_small As New Font(bigfont, headsmall, FontStyle.Bold)
    Public smallfont As New Font(fontname, small_font, FontStyle.Regular)
    Public italisized_font As New Font(fontname, smallsize, FontStyle.Italic)
    Public mediumsize As New Font(fontname, othersize, FontStyle.Bold)
    Public other_font As New Font(fontname, smallsize, FontStyle.Bold)
    Public header_font As New Font(bigfont, bigsize, FontStyle.Bold)
    Public stream_mode, trying, subject_ranking_table, show_split, found As Boolean
    Public confirm_return, form_4_mode, to_continue, best_of_7 As Boolean
    Public mod_subject As Boolean = False
    Public bk_id, t_no, row_from, row_to, rankno As Integer
    Public None As String = "None"
    Public dbreader2 As Odbc.OdbcDataReader
    Public DemoDatabase As String = "DemoDatabase"
    Public mode As Boolean = False
    Public attend As Boolean = False
    Public radF, radL, backup, restore, load_from_alumni, watermark, grade As Boolean
    Public path As String = GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Public dbConnNew As Odbc.OdbcConnection
    Public dbcommand1 As Odbc.OdbcCommand
    Public startyear As Integer = 2010
    Public endyear As Integer = Today.Year
    Public changedByUser As Boolean
    Public loggedInUser As String = String.Empty
    Public myFormVariable As Boolean = False


    Public subjectColumns As List(Of String)
    Public examList As List(Of Tuple(Of String, String, String))
    Public examListMain As List(Of Tuple(Of String, String, String, String, String))
    Public selectedClass As String = String.Empty
    Public selectedYear As String = String.Empty
    Public gradingType As String = String.Empty
    Public selectedTerm As String = String.Empty
    Public sortGradesBy As String = String.Empty


    Public subjectGrading As New Dictionary(Of String, List(Of Tuple(Of String, Int16)))
    Public subjectGrading2 As New Dictionary(Of String, List(Of Tuple(Of String, Int16)))
    Public classGrading As New List(Of Tuple(Of String, Int16))
    Public GradeToPoint As New Dictionary(Of String, Int16)
    Public students As New List(Of Tuple(Of Int64, String, String, String, String))
    Public classStream As New List(Of String)
    Public overallAverage As New Dictionary(Of String, Integer)
    Public averagePoints As New Dictionary(Of String, Double)
    Public studentCount As New Dictionary(Of String, Integer)
    Public classCount As Integer
    Public resultsTotal As Integer
    Public selectedExams As New List(Of Tuple(Of String, String, String, String))
    Public filterType As String = String.Empty
    Public schoolSubjects As New List(Of String)



    Public Structure ReportForm
        Dim student_photo, school_logo, color, head_teacher_name, class_teacher_name, class_teacher_comments, head_teacher_comments, class_teacher_signature, head_teacher_signature, house_master_comments, club_and_societies As Boolean
    End Structure

    Public Function connect() As Boolean
        dbconn = New Odbc.OdbcConnection("Driver=MySQl ODBC 5.1 Driver;server=" + My.Settings.host + ";user=" + My.Settings.userName + ";password=" + My.Settings.passWord + ";database=" + My.Settings.dbName + ";port=" + My.Settings.dPport + ";")
        Try
            dbconn.Open()
            Return True
        Catch ex As Exception
            MessageBox.Show("The System Could Not Connect to the Database" & vbNewLine & "Make sure the Wamp Server is running", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function dbNewOpen()
        dbConnNew = New Odbc.OdbcConnection("Driver=MySQl ODBC 5.1 Driver;server=" + My.Settings.host + ";user=" + My.Settings.userName + ";password=" + My.Settings.passWord + ";database=" + My.Settings.dbName + ";port=" + My.Settings.dPport + ";")
        Try
            dbConnNew.Open()
            dbcommand1 = New Odbc.OdbcCommand
            dbcommand1.Connection = dbConnNew
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function generateDataTable(ByRef sql As String)
        Dim run As Odbc.OdbcCommand = New Odbc.OdbcCommand
        Dim dt As New DataTable
        Dim dataadapter As New Odbc.OdbcDataAdapter

        Try
            With run
                .CommandText = sql
                .Connection = dbconn
            End With

            With dataadapter
                .SelectCommand = run
                .Fill(dt)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return dt
    End Function

    Public Function getMenus(ByVal user As String)

        Dim menus = String.Empty
        If qread("select rights from priviledges where user = '" + user + "' and domain = 'Exam'") Then
            If dbreader.RecordsAffected > 0 Then

                dbreader.Read()
                menus = dbreader.GetString(0)
                dbreader.Close()
            End If
        End If

        Return menus
    End Function

    Public Function logIn(ByVal userName As String, ByVal passWord As String) As Boolean

        If qread("select partner from system_users where user_name = md5('" + userName + "') and password = md5('" + passWord + "') and domain = md5('Examination');") Then
            If dbreader.RecordsAffected > 0 Then
                dbreader.Read()
                loggedInUser = dbreader.GetString(0)
                Return True
            Else
                Return False
            End If
        End If

    End Function

    Public Function qread(ByRef q As String, Optional ByVal reader As Integer = 0) As Boolean
        dbcommand = New Odbc.OdbcCommand
        dbcommand.Connection = dbconn
        dbcommand.CommandText = q

        Try
            If reader = 0 Then
                Try
                    dbreader.Close()
                Catch ex As Exception

                End Try
                dbreader = dbcommand.ExecuteReader
            ElseIf reader = 1 Then
                Try
                    dbreader1.Close()
                Catch ex As Exception

                End Try
                dbreader1 = dbcommand.ExecuteReader
            ElseIf reader = 2 Then
                Try
                    dbreader2.Close()
                Catch ex As Exception

                End Try
                dbreader2 = dbcommand.ExecuteReader
            End If
            Return True
        Catch ex As Exception
            MsgBox("System Could Not Read The Database" & vbNewLine & ex.Message)
            Return False
        End Try

        'Try
        '    dbreader = dbcommand.ExecuteReader
        '    Return True
        'Catch ex As Exception
        '    MsgBox("System Could Not Read The Database" & vbNewLine & ex.Message)
        '    Return False
        'End Try
    End Function

    Public Function qwrite(q As String) As Boolean
        dbcommand = New Odbc.OdbcCommand
        dbcommand.Connection = dbconn
        dbcommand.CommandText = q

        Try
            dbcommand.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("System Could Not Write The DataBase" & vbNewLine & ex.Message)
            Return False
        End Try
    End Function

    Public Sub load_class(ByRef cbo As ComboBox)
        cbo.Items.Clear()
        qread("SELECT distinct(class) FROM class_stream")
        While dbreader.Read
            cbo.Items.Add(dbreader("class"))
        End While
    End Sub

    Public Sub load_stream(ByRef cbo As ComboBox)
        cbo.Items.Clear()
        qread("SELECT distinct(stream) FROM class_stream")
        While dbreader.Read
            cbo.Items.Add(dbreader("stream"))
        End While
    End Sub

    Public Sub load_stream1(ByVal cbo As ComboBox, ByVal cls As String)
        cbo.Items.Clear()
        qread("SELECT stream FROM class_stream WHERE class='" & escape_string(cls) & "'")
        While dbreader.Read
            cbo.Items.Add(dbreader("stream"))
        End While
    End Sub

    Public Sub load_subjects(ByRef cbo As ComboBox)
        cbo.Items.Clear()
        qread("select subject from subjects")
        While dbreader.Read
            cbo.Items.Add(dbreader("subject"))
        End While
    End Sub

    Public Sub load_form()
        Dim frm As New frmLoading
        frm.ShowDialog()
    End Sub

    Public Function escape_string(ByVal val As String) As String
        Try
            val.ToCharArray()
        Catch ex As Exception
            Return String.Empty
        End Try

        Dim temp As String = String.Empty
        For k As Integer = 0 To val.Length - 1
            If val(k) = "'" Then
                If k = 0 Or val(k - 1) <> "\" Then
                    temp += "\" & val(k)
                End If
            Else
                temp += val(k)
            End If
        Next
        Return temp
    End Function

    Public Sub success(ByVal msg As String)
        MsgBox(msg, MsgBoxStyle.Information, "Operation was successful")
    End Sub

    Public Sub failure(ByVal msg As String)
        MsgBox(msg, MsgBoxStyle.Information, "Operation was unsuccessful")
    End Sub

    Public Sub fill_years(ByRef cbo As ComboBox)
        cbo.Items.Clear()

        For k As Integer = Today.Year - 3 To Today.Year + 3
            cbo.Items.Add(k.ToString())
        Next
        cbo.SelectedItem = Today.Year.ToString()

    End Sub

    Public Sub start()
        qwrite("START TRANSACTION")
    End Sub
    Public Sub commit()
        qwrite("COMMIT")
    End Sub
    Public Sub rollback()
        qwrite("ROLLBACK")
    End Sub

    Public Function get_subjects()
        If qread("SELECT * FROM `subjects` order by subjectcode asc") Then
            If dbreader.RecordsAffected > 0 Then
                ReDim subjabb(dbreader.RecordsAffected - 1), subjids(dbreader.RecordsAffected - 1), subjname(dbreader.RecordsAffected - 1), subjects(dbreader.RecordsAffected - 1)
                Dim i As Integer = 0
                While dbreader.Read
                    subjabb(i) = dbreader("Abbreviation")
                    subjects(i) = dbreader("Subject")
                    subjname(i) = remove_wild(subjabb(i))
                    subjids(i) = dbreader("id")
                    i += 1
                End While
                dbreader.Close()
                Return True
            Else
                success("You Have Not Yet Made Subject Entries Into The Application!")
                Return False
            End If
        Else
            failure("Could Not Read From Subjects Database!")
            Return False
        End If
    End Function

    Public Function remove_wild(ByVal value As String)
        Try
            value.ToCharArray()
        Catch ex As Exception
            Return String.Empty
        End Try
        Dim ret As String = String.Empty
        Dim state As Boolean = False
        Dim wild(28) As String
        wild(0) = "~"
        wild(1) = "`"
        wild(2) = "!"
        wild(3) = "@"
        wild(4) = "#"
        wild(5) = "$"
        wild(6) = "%"
        wild(7) = "^"
        wild(8) = "&"
        wild(9) = "*"
        wild(10) = "("
        wild(11) = ")"
        wild(12) = "{"
        wild(13) = "}"
        wild(14) = "["
        wild(15) = "]"
        wild(16) = "/"
        wild(17) = "\"
        wild(18) = "|"
        wild(19) = "'"
        wild(20) = ":"
        wild(21) = ";"
        wild(22) = "<"
        wild(23) = ">"
        wild(24) = ","
        wild(25) = "."
        wild(26) = "?"
        wild(27) = "-"
        wild(28) = "+"
        For j As Integer = 0 To value.Length - 1
            For k As Integer = 0 To wild.Length - 1
                If value(j) = wild(k) Then
                    state = True
                End If
            Next
            If Not state Then
                ret += value(j)
            End If
            state = False
        Next
        Return ret
    End Function

    Public Function confirm(ByVal msg As String)

        If MsgBox(msg, MsgBoxStyle.YesNo, "Please confirm your action") = MsgBoxResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ret_name(ByVal str As String)
        Dim ret As String = String.Empty
        Dim state As Boolean = False
        str = Trim(str)
        Try
            str.ToCharArray()
        Catch ex As Exception
            Return ret
        End Try
        Dim i As Integer
        For i = 0 To str.Length - 1
            If str(i) = "_" And state Then
                ret += " "
                state = False
            Else
                If str(i) <> "_" Then
                    state = True
                    ret += str(i)
                End If
            End If
        Next
        Return ret
    End Function

    Public Function IsAdmin()
        If (USER_ID = 1 Or USER_ID = 3) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsSubjectTeacher(ByVal subj As String, ByVal class_form As String, ByVal stream As String, term As String, year As String) As Boolean
        qread("SELECT Entry FROM subject_teachers WHERE (class='" & escape_string(ret_name(class_form)) & "' AND stream='" & escape_string(stream) & "' AND term='" & term & "' AND year=" & year & " AND TeacherID=" & ENTITY_ID & " AND subject='" & escape_string(subj) & "')")
        If dbreader.RecordsAffected > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsPrimary() As Boolean
        qread("SELECT school_type FROM school_details WHERE school_type='Primary'")
        If dbreader.RecordsAffected > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function get_id(ByVal id)
        Return id
    End Function

    Public Function get_subject_name(ByVal s As String, Optional ByVal abb As Boolean = False)
        If abb Then
            Dim i As Integer
            For i = 0 To subjabb.Length - 1
                If subjects(i) = s Or subjabb(i) = s Then
                    Return subjabb(i)
                End If
            Next
            Try
                Return subjabb(i)
            Catch ex As Exception
                Return String.Empty
            End Try
        Else
            Dim i As Integer
            For i = 0 To subjabb.Length - 1
                If subjabb(i) = s Or subjects(i) = s Then
                    Return subjects(i)
                End If
            Next
            Try
                Return subjects(i)
            Catch ex As Exception
                Return String.Empty
            End Try
        End If
    End Function

    Public Function fix_point(ByVal grade As String)
        'If (grade.Length - 3) > 0 Then
        '    For m As Integer = 0 To grades.Length - 3
        '        If grade = grades(m) Then
        '            Return (12 - m)
        '        End If
        '    Next
        'End If
        'Return 0

        For m As Integer = 0 To grades.Length - 3
            If grade = grades(m) Then
                Return (12 - m)
            End If
        Next
        Return 0
    End Function

    Public Function get_grade(ByVal val As Double, ByVal s As Boolean, ByVal subj As String, Optional ByVal class_ As String = Nothing)
        If class_ = Nothing Then
            class_ = class_form
        End If
        val = Math.Round(val, 0)
        If s Then
            qread("SELECT * FROM s_grading WHERE (Class='" & ret_name(class_) & "' AND Subject='" & get_subject_name(subj) & "' AND term='" & tm & "' AND year='" & yr & "');", 1)
        Else
            qread("SELECT * FROM grading WHERE (Class='" & ret_name(class_) & "' AND term='" & tm & "' AND year='" & yr & "');", 1)
        End If
        If dbreader1.RecordsAffected > 0 Then
            dbreader1.Read()
            If val >= dbreader1("A") Then
                dbreader1.Close()
                Return "A"
            ElseIf val >= dbreader1("A-") Then
                dbreader1.Close()
                Return "A-"
            ElseIf val >= dbreader1("B+") Then
                dbreader1.Close()
                Return "B+"
            ElseIf val >= dbreader1("B") Then
                dbreader1.Close()
                Return "B"
            ElseIf val >= dbreader1("B-") Then
                dbreader1.Close()
                Return "B-"
            ElseIf val >= dbreader1("C+") Then
                dbreader1.Close()
                Return "C+"
            ElseIf val >= dbreader1("C") Then
                dbreader1.Close()
                Return "C"
            ElseIf val >= dbreader1("C-") Then
                dbreader1.Close()
                Return "C-"
            ElseIf val >= dbreader1("D+") Then
                dbreader1.Close()
                Return "D+"
            ElseIf val >= dbreader1("D") Then
                dbreader1.Close()
                Return "D"
            ElseIf val >= dbreader1("D-") Then
                dbreader1.Close()
                Return "D-"
            Else
                dbreader1.Close()
                Return "E"
            End If
        Else
            dbreader1.Close()
            Return "E"
        End If
    End Function

    Public Sub fill_class(ByVal str As String, ByRef cbo As ComboBox)
        cbo.Items.Clear()
        qread("SELECT stream FROM class_stream WHERE class='" & escape_string(str) & "'")
        While dbreader.Read
            cbo.Items.Add(dbreader("stream"))
        End While
    End Sub

    Public Function parseQuery(ByVal queryString As String) As String
        Dim newString As String = String.Empty
        newString = queryString.Trim
        If newString.EndsWith(",") Then
            newString = newString.Remove(newString.Length - 1, 1)
            newString += ";"
        End If

        Return newString
    End Function

    Public Sub resetSchoolName()
        Dim details As String = VerifyL.getSchoolDetails()
        If Not String.IsNullOrEmpty(details) Then
            Dim schoolName As String = VerifyL.getStringRecord("select school_name from school_details limit 1;")

            If String.IsNullOrEmpty(schoolName) Then
                If qwrite("insert into school_details (`school_name`, `telephone`, `postal_address`, `town`) values ('" + escape_string(details) + "', 'SAMPLE', 'SAMPLE', 'SAMPLE');") Then

                End If
            Else
                If schoolName <> details Then
                    If qwrite("update school_details set school_name = '" + escape_string(details) + "';") Then

                    End If
                End If
            End If

        Else
            If qwrite("insert into school_details (`school_name`, `telephone`, `postal_address`, `town`) values ('" + escape_string(details) + "', 'SAMPLE', 'SAMPLE', 'SAMPLE');") Then

            End If
        End If
    End Sub

    Public Function get_total_mark(ByVal exam As String, ByVal tm As String, Optional ByVal yer As String = Nothing)
        If yer = Nothing Then
            yer = yr
        End If
        Dim i As Integer
        If qread("SELECT Total FROM examinations WHERE (ExamName='" & exam & "' AND Term='" & tm & "' AND Year='" & yer & "')") Then
            dbreader.Read()
            Try
                i = dbreader("Total")
            Catch ex As Exception
                i = 0
            End Try
            dbreader.Close()
            Return i
        Else
            Return False
        End If
    End Function

    Public Function SubjectOutOf(ByVal subj, ByVal tm, ByVal yr, ByVal exam, ByVal cls, ByVal str, Optional ByVal reader = 0) As Double
        qread("SELECT `" & subj & "` FROM exam_results_subjects_out_of WHERE (Examination = '" & escape_string(exam) & "' AND Term = '" & tm & "' AND Year = '" & yr & "' AND Class='" & escape_string(cls) & "' AND Stream='" & escape_string(str) & "')", reader)
        If reader = 0 Then
            If dbreader.RecordsAffected > 0 Then
                dbreader.Read()
                Return dbreader(subj)
            End If
        Else
            If dbreader2.RecordsAffected > 0 Then
                dbreader2.Read()
                Return dbreader2(subj)
            End If
        End If
    End Function

    Public Function get_name(ByVal str As String)
        str = remove_wild(str)
        Dim ret As String = String.Empty
        Dim state As Boolean = False
        str = Trim(str)
        Try
            str.ToCharArray()
        Catch ex As Exception
            Return str
        End Try
        Dim i As Integer
        For i = 0 To str.Length - 1
            If str(i) = " " And state Then
                ret += "_"
                state = False
            Else
                If str(i) <> " " Then
                    state = True
                    ret += str(i)
                End If
            End If
        Next
        Return ret
    End Function

    Public Sub get_grades()
        ReDim grades(13)
        ReDim grades_y(13)
        grades(0) = "A"
        grades(1) = "A-"
        grades(2) = "B+"
        grades(3) = "B"
        grades(4) = "B-"
        grades(5) = "C+"
        grades(6) = "C"
        grades(7) = "C-"
        grades(8) = "D+"
        grades(9) = "D"
        grades(10) = "D-"
        grades(11) = "E"
        grades(12) = "X"
        grades(13) = "Y"
    End Sub

    Public Function get_points(ByVal marks As Double)
        marks = Math.Round(marks, 2)
        If marks >= 11.5 Then
            Return "A"
        ElseIf marks >= 10.5 Then
            Return "A-"
        ElseIf marks >= 9.5 Then
            Return "B+"
        ElseIf marks >= 8.5 Then
            Return "B"
        ElseIf marks >= 7.5 Then
            Return "B-"
        ElseIf marks >= 6.5 Then
            Return "C+"
        ElseIf marks >= 5.5 Then
            Return "C"
        ElseIf marks >= 4.5 Then
            Return "C-"
        ElseIf marks >= 3.5 Then
            Return "D+"
        ElseIf marks >= 2.5 Then
            Return "D"
        ElseIf marks >= 1.5 Then
            Return "D-"
        Else
            Return "E"
        End If
    End Function

    Public Function logo() As String
        qread("SELECT image_path FROM school_details")
        dbreader.Read()
        logo = dbreader("image_path")
        dbreader.Close()
    End Function

    Public Sub get_term()
        If Month(Today.Date) <= 4 Then
            term = "I"
        ElseIf Month(Today.Date) <= 8 Then
            term = "II"
        Else
            term = "III"
        End If
        tm = term
    End Sub

    Public Sub wait(ByVal msg As String)
        operation = msg
        Dim frm As New frmWait
        frm.ShowDialog()
    End Sub


    Public Function ret_subject_name(ByVal s As String)
        Dim i As Integer
        For i = 0 To subjabb.Length - 1
            If subjects(i) = s Then
                Return subjabb(i)
            End If
        Next
        Try
            Return subjabb(i)
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function get_comment(ByVal grade As String, ByVal s_grade As Boolean, ByVal S As String) As String
        If s_grade Then
            If qread("SELECT `" & grade & "` FROM s_grading_comments WHERE (Subject='" & get_subject_name(S) & "' AND Class='" & ret_name(class_form) & "' AND term='" & tm & "' AND year='" & yr & "')") Then
                Try
                    dbreader.Read()
                    grade = dbreader(grade)
                Catch ex As Exception
                    grade = Nothing
                End Try
            Else
                grade = "POOR"
            End If
        Else
            If qread("SELECT `" & grade & "` FROM grading_comments WHERE (Class='" & ret_name(class_form) & "' AND term='" & tm & "' AND year='" & yr & "')") Then
                Try
                    dbreader.Read()
                    grade = dbreader(grade)
                Catch ex As Exception

                End Try
            Else
                grade = "POOR"
            End If
        End If
        Return grade
    End Function

    Public Function subject_teacher(ByVal str As String, ByVal c_form As String, ByVal term As String, ByVal year As Integer, ByVal subj As String)
        Dim tname As String = String.Empty
        Dim tInitials As String()
        Dim initials As String = String.Empty
        Dim tid As Integer

        qread("SELECT TeacherID FROM `subject_teachers` WHERE (Abbreviation='" & escape_string(subj) & "' AND term='" & term & "' AND year='" & year & "' AND stream='" & escape_string(str) & "' AND class='" & escape_string(ret_name(c_form)) & "')")
        If dbreader.RecordsAffected > 0 Then
            Try
                dbreader.Read()
                tid = dbreader("TeacherID")
                dbreader.Close()
                qread("SELECT partnerName, title FROM partners WHERE id ='" & tid & "' and partnerType = 'Teaching Staff'")
                If dbreader.RecordsAffected > 0 Then
                    dbreader.Read()

                    If Not IsDBNull(dbreader("partnerName")) Then
                        If Not String.IsNullOrEmpty(dbreader("partnerName").ToString()) Then
                            tInitials = dbreader("partnerName").ToString().Split()
                            If tInitials.Count > 0 Then
                                For Each s As String In tInitials
                                    If Not String.IsNullOrEmpty(s) Then
                                        initials += s.Substring(0, 1).ToUpper() + " "
                                    End If
                                Next
                            End If
                        End If
                    End If



                    ' tname = dbreader("title") & ". " & initials
                    tname = initials
                    dbreader.Close()
                End If
            Catch ex As Exception

            End Try

        End If
        Return tname
    End Function

    Public Sub get_SMS_Details()
        qread("SELECT * FROM sms")
        If dbreader.RecordsAffected > 0 Then
            While dbreader.Read
                SMS_Center = dbreader("CenterNo")
                SMS_COM = dbreader("Port")
            End While
        End If
    End Sub

    Public Function classes() As String()
        'todo added the list of string code and the distinct in sql 
        Dim schoolClasses As New List(Of String)
        Dim ret As String()

        qread("SELECT distinct class FROM class_stream ORDER BY id")

        ReDim ret(dbreader.RecordsAffected - 1), classIDs(dbreader.RecordsAffected - 1)

        qread("SELECT id, class FROM class_stream ORDER BY id")
        Dim i As Integer = 0
        While dbreader.Read
            If Not schoolClasses.Contains(dbreader("class").ToString()) Then
                If i >= classIDs.Count Then
                    Exit While
                End If
                ret(i) = dbreader("class")
                classIDs(i) = dbreader("id")
                schoolClasses.Add(dbreader("class").ToString())
                i += 1
            End If
        End While
        Return ret
    End Function

    Public Function CheckStatus(ByVal val)
        If val.ToString = "1" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function subject_get(ByVal id)
        qread("SELECT Subject FROM subjects WHERE id='" & id & "'")
        dbreader.Read()
        subject_get = dbreader("Subject")
        dbreader.Close()
    End Function

    Public Function CurrentClass(ByVal cls As String(), ByVal class_form As String)
        For k As Integer = 0 To cls.Length - 1
            If ret_name(class_form) = cls(k) Then
                Return k
            End If
        Next
        Return 0
    End Function

    Public Function get_fname(ByVal adm As String)
        qread("SELECT student_name FROM students WHERE admin_no='" & adm & "'")
        dbreader.Read()
        Dim fname As String = dbreader("student_name")
        dbreader.Close()
        Return fname
    End Function

    Public Function format_no(ByVal no As String)
        Try
            Return "+254" & no.Substring(1)
        Catch ex As Exception
            Return "+254733911638"
        End Try
    End Function

    Public Sub wait_slow(ByVal msg As String)
        operation = msg
        Dim frm As New frmWaitSlow
        frm.ShowDialog()
    End Sub

    Public Function get_class_subjects(ByVal cls As String)
        If qread("SELECT SubjID, Abbreviation, Subject FROM class_subjects WHERE Class='" & escape_string(cls) & "' ORDER BY SubjID ASC") Then
            If dbreader.RecordsAffected > 0 Then
                ReDim subjabb(dbreader.RecordsAffected - 1), subjids(dbreader.RecordsAffected - 1), subjname(dbreader.RecordsAffected - 1), subjects(dbreader.RecordsAffected - 1)
                Dim i As Integer = 0
                While dbreader.Read
                    subjabb(i) = dbreader("Abbreviation")
                    subjects(i) = dbreader("Subject")
                    subjname(i) = remove_wild(subjabb(i))
                    subjids(i) = dbreader("SubjID")
                    i += 1
                End While
                Return True
            Else
                failure("You Have Not Yet Made Subject Entries Into The Application!")
                Return False
            End If
        Else
            failure("Could Not Read From Subjects Database!")
            Return False
        End If
    End Function

    Public Sub new_con()
        dbcommand = New Odbc.OdbcCommand
        dbcommand.Connection = dbconn
    End Sub

    Public Function get_stream(ByVal adm)
        qread("SELECT Stream FROM students WHERE admin_no='" & adm & "'")
        If dbreader.Read Then
            Return dbreader("Stream")
        Else
            failure("Looks Like Student With Admission Number " & adm & " Has Not Been Assigned A Stream! Please Check On That! In the meantime.. Assigning Him NULL Stream!")
            Return "NULL"
        End If
    End Function

    Public Sub get_term(ByRef cbo As ComboBox)
        If Month(Today.Date) <= 4 Then
            term = "I"
        ElseIf Month(Today.Date) <= 8 Then
            term = "II"
        Else
            term = "III"
        End If
        tm = term
        cbo.SelectedItem = term
    End Sub

    Public Function displayConfirmationMessage(ByVal msg As String) As Boolean
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
        If MsgBox(msg, MsgBoxStyle.YesNo, "Please Confirm") = MsgBoxResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub get_school_details()

        If qread("SELECT school_name, email, postal_address, telephone, town FROM school_details") Then
            If dbreader.RecordsAffected > 0 Then
                dbreader.Read()
                S_NAME = dbreader("school_name")
                S_FAX = dbreader("email")
                S_PHONE = dbreader("telephone")
                S_ADDRESS = dbreader("postal_address")
                S_LOCATION = dbreader("town")
                Try
                    S_EMAIL = dbreader("Email")
                Catch ex As Exception

                End Try
                dbreader.Close()
            End If
        Else
            failure("Could Not Read From The School Database!")
        End If
    End Sub

    Public Sub createTableTempTable()
        Dim table As String = "CREATE TABLE `stud_balance_temp_table` (
	`id` BIGINT(255) NOT NULL AUTO_INCREMENT,
	`admin_no` BIGINT(255) NOT NULL DEFAULT '0',
	`name` VARCHAR(255) NOT NULL DEFAULT '--',
	`class` VARCHAR(255) NOT NULL DEFAULT '--',
	`stream` VARCHAR(255) NOT NULL DEFAULT '--',
	`fee_amount` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`fee_exemption` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`fee_penalty` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`amount_paid` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`balance` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`overpay` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`refund` DECIMAL(10,2) NOT NULL DEFAULT '0',
	PRIMARY KEY (`id`)
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
;"
        Dim query As String = "SHOW TABLES LIKE 'stud_balance_temp_table';"
        If qread(query) Then
            If dbreader.RecordsAffected = 0 Then
                If qwrite(table) Then

                End If
            End If
        End If
    End Sub
End Module
