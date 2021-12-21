Imports System.Drawing.Printing

Public Class frmComputeResults

    Dim subjectGrading As New Dictionary(Of String, List(Of Tuple(Of String, Int16)))
    Dim classGrading As New List(Of Tuple(Of String, Int16))
    Dim GradeToPoint As New Dictionary(Of String, Int16)
    Dim students As New List(Of Tuple(Of Int64, String, String, String, String))
    Dim classStream As New List(Of String)
    Dim subjectGrade As String = String.Empty
    Dim tpp, tmm As Integer
    Dim mpp As Double
    Dim subjectPoints, subjectEntries As Int16
    Dim subjectMark As Integer
    Dim mgg As String = String.Empty
    Dim originalData As New DataTable

    Private Function getSubjectEntries(ByVal adm_no As Integer) As Integer
        Dim entries As Integer = 0

        If qread("select *  from subjects_done where admno = " + adm_no.ToString() + ";", 1) Then
            If dbreader1.RecordsAffected > 0 Then
                While dbreader1.Read
                    For Each s As String In subjectColumns
                        If dbreader1(s) = "Yes" Then
                            entries += 1
                        End If
                    Next
                End While
            End If
        End If

        Return entries
    End Function

    Private Sub exportDataToExcel()
        exportToExcel(dgvMeanMarks)
    End Sub
    Private Sub reorderColumns()

        dgvMeanMarks.Rows.Clear()
        dgvMeanMarks.Columns.Clear()

        dgvMeanMarks.Columns.Add("admno", "Adm No.")
        dgvMeanMarks.Columns.Add("student_name", "Name Of Student")
        dgvMeanMarks.Columns.Add("kcpe", "KCPE")

        originalData.Columns.Add("admno")
        originalData.Columns("admno").Caption = "ADM"
        originalData.Columns.Add("student_name")
        originalData.Columns("student_name").Caption = "Name Of Student"
        originalData.Columns.Add("kcpe")
        originalData.Columns("kcpe").Caption = "KCPE"


        For Each s As String In subjectColumns
            dgvMeanMarks.Columns.Add(s.Replace(" ", "_"), s)
            originalData.Columns.Add(s.Replace(" ", "_"))
        Next

        Dim additonalColumns As String() = {"SE", "TP", "MP", "MG", "TM", "STR", "SP", "OP"}

        For Each s As String In additonalColumns
            dgvMeanMarks.Columns.Add(s, s)
            originalData.Columns.Add(s)

            If s = "TP" Or s = "MP" Or s = "TM" Then
                dgvMeanMarks.Columns(s).ValueType = System.Type.GetType("System.Double")
            End If
        Next

    End Sub
    Private Sub getStreams()

        classStream.Clear()

        If qread("select DISTINCT(stream) as stream from class_stream where class = '" + selectedClass + "';") Then
            If dbreader.RecordsAffected > 0 Then
                While dbreader.Read
                    classStream.Add(dbreader("stream"))
                End While
            End If
        End If
    End Sub

    Private Sub initialzeGradePoints()
        GradeToPoint.Add("A", 12)
        GradeToPoint.Add("A-", 11)
        GradeToPoint.Add("B+", 10)
        GradeToPoint.Add("B", 9)
        GradeToPoint.Add("B-", 8)
        GradeToPoint.Add("C+", 7)
        GradeToPoint.Add("C", 6)
        GradeToPoint.Add("C-", 5)
        GradeToPoint.Add("D+", 4)
        GradeToPoint.Add("D", 3)
        GradeToPoint.Add("D-", 2)
        GradeToPoint.Add("E", 1)
        GradeToPoint.Add("Y", 0)
        GradeToPoint.Add("X", 0)

    End Sub
    Private Sub test(ByVal subject As String, ByVal gradeList As List(Of Tuple(Of String, Int16)))
        Dim newListTuple As New List(Of Tuple(Of String, Int16))
        For i = 0 To gradeList.Count - 1
            newListTuple.Add(New Tuple(Of String, Int16)(gradeList(i).Item1, gradeList(i).Item2))
        Next

        subjectGrading.Add(subject, newListTuple)
    End Sub
    Private Function getGradingScheme() As Boolean
        Dim schemeAvailable As Boolean = False
        Dim query As String = String.Empty
        Dim gradess As String() = {"A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "E"}
        Dim gradeValues As New List(Of Tuple(Of String, Int16))
        Dim saveGradeValue As New List(Of Tuple(Of String, Int16))

        If gradingType = "SubjectBased" Then

            subjectGrading.Clear()

            For Each s As String In subjectColumns
                query = "SELECT * FROM s_grading WHERE (Class='" & selectedClass & "' AND Subject='" & get_subject_name(s) & "' AND term='" & selectedTerm & "' AND year='" & selectedYear & "');"
                If qread(query, 1) Then
                    If dbreader1.RecordsAffected > 0 Then
                        schemeAvailable = True
                        While dbreader1.Read
                            For Each g As String In gradess
                                gradeValues.Add(New Tuple(Of String, Int16)(g, dbreader1(g)))
                            Next
                            test(s, gradeValues)
                            'subjectGrading.Add(s, gradeValues)
                            gradeValues.Clear()
                        End While
                    End If
                End If
            Next

        Else

            classGrading.Clear()

            query = "SELECT * FROM grading WHERE (Class='" & selectedClass & "' AND term='" & selectedTerm & "' AND year='" & selectedYear & "');"
            If qread(query, 1) Then
                If dbreader1.RecordsAffected > 0 Then
                    schemeAvailable = True
                    While dbreader1.Read
                        For Each g As String In gradess
                            classGrading.Add(New Tuple(Of String, Int16)(g, dbreader1(g)))
                        Next
                    End While
                End If
            End If
        End If

        Return schemeAvailable
    End Function

    Private Sub fillDataTable()
        originalData.Rows.Clear()
        Dim row As DataRow

        For i = 0 To dgvMeanMarks.Rows.Count - 1
            row = originalData.NewRow
            For j = 0 To dgvMeanMarks.Columns.Count - 1
                row(dgvMeanMarks.Columns(j).Name) = dgvMeanMarks.Rows(i).Cells(j).Value
            Next
            originalData.Rows.Add(row)
        Next

    End Sub

    Private Function getHighestMark(ByVal subjectList As Array, ByVal rowkcpe As Integer) As List(Of Tuple(Of String, Integer))
        Dim highestMarks As New List(Of Tuple(Of String, Integer))
        Dim subjectMarkss As New List(Of Tuple(Of String, Integer))

        For Each s As String In subjectList
            subjectMarkss.Add(New Tuple(Of String, Integer)(s, dgvMeanMarks.Rows(rowkcpe).Cells(s).Value))
        Next

        Dim test = (From m In subjectMarkss
                    Order By m.Item2 Descending
                    Select m).FirstOrDefault()

        highestMarks.Add(test)

        Return highestMarks
    End Function

    Private Function convertMarksToGrade(ByVal marks As Int16, ByVal gradingType As String, Optional ByVal subjectParm As String = "") As String
        Dim studGrade As String = String.Empty

        If marks = 0 Then
            studGrade = "Y"
        ElseIf gradingType = "SubjectBased" Then
            'Dim subjectGrading As New Dictionary(Of String, List(Of Tuple(Of String, Int16)))
            Dim subjGrade As List(Of Tuple(Of String, Int16)) = subjectGrading(subjectParm)

            If marks < subjGrade(subjGrade.Count - 1).Item2 Then
                studGrade = "E"
            Else
                For i = 0 To subjGrade.Count - 1
                    If marks >= subjGrade(i).Item2 Then
                        studGrade = subjGrade(i).Item1
                        Exit For
                    End If
                Next
            End If
        Else
            ' Dim classGrading As New List(Of Tuple(Of String, Int16))
            If marks < classGrading(classGrading.Count - 1).Item2 Then
                studGrade = "E"
            Else
                For i = 0 To classGrading.Count - 1
                    If marks >= classGrading(i).Item2 Then
                        studGrade = classGrading(i).Item1
                        Exit For
                    End If
                Next
            End If
        End If

        Return studGrade
    End Function

    Private Sub getB7()

        Dim compulsory() As String = {"ENG", "KISW", "MATH", "CHEM"}
        Dim science() As String = {"PHY", "BIO"}
        Dim humanity() As String = {"GEO", "HIST"}
        Dim others() As String = {"CRE", "IRE", "BST", "AGR"}
        subjectEntries = 7
        Dim groupedSubject As New List(Of Array)
        Dim ordered As New List(Of Tuple(Of String, Integer))

        groupedSubject.AddRange({science, humanity, others})
        allResults.Clear()
        streamResults.Clear()

        For l = dgvMeanMarks.Rows.Count - 1 To dgvMeanMarks.Rows.Count - 4 Step -1
            dgvMeanMarks.Rows.RemoveAt(l)
        Next

        Using New DevExpress.Utils.WaitDialogForm("Please Wait ...")

            For i = 0 To dgvMeanMarks.Rows.Count - 1

                tpp = 0
                tmm = 0

                For Each s As String In compulsory
                    subjectMark = dgvMeanMarks.Rows(i).Cells(s).Value
                    subjectGrade = convertMarksToGrade(subjectMark, gradingType, s)
                    subjectPoints = convertGradeToPoints(subjectGrade)
                    tpp += subjectPoints
                    tmm += subjectMark
                Next

                For k = 0 To groupedSubject.Count - 1
                    ' ordered = getHighestMark(science, i)
                    ordered = getHighestMark(groupedSubject(k), i)
                    subjectMark = ordered(0).Item2
                    subjectGrade = convertMarksToGrade(subjectMark, gradingType, ordered(0).Item1)
                    subjectPoints = convertGradeToPoints(subjectGrade)
                    tpp += subjectPoints
                    tmm += subjectMark
                Next

                dgvMeanMarks.Rows(i).Cells("TP").Value = tpp

                mpp = Math.Round(tpp / subjectEntries, 2, MidpointRounding.AwayFromZero)
                dgvMeanMarks.Rows(i).Cells("MP").Value = mpp

                mgg = getMeanGrade(mpp)
                dgvMeanMarks.Rows(i).Cells("MG").Value = mgg

                dgvMeanMarks.Rows(i).Cells("TM").Value = tmm


                If sortGradesBy = "Total Marks" Then
                    allResults.Add(New Tuple(Of String, Double)(dgvMeanMarks.Rows(i).Cells("STR").Value, tmm))
                ElseIf sortGradesBy = "Mean Marks" Then
                    allResults.Add(New Tuple(Of String, Double)(dgvMeanMarks.Rows(i).Cells("STR").Value, Math.Round(tmm / subjectEntries, 2, MidpointRounding.AwayFromZero)))
                ElseIf sortGradesBy = "Mean Points" Then
                    allResults.Add(New Tuple(Of String, Double)(dgvMeanMarks.Rows(i).Cells("STR").Value, mpp))
                Else
                    allResults.Add(New Tuple(Of String, Double)(dgvMeanMarks.Rows(i).Cells("STR").Value, tpp))
                End If


            Next


            Dim streamList As New List(Of Double)
            Dim element As Integer
            Dim j As Integer

            'Compute Overall Position
            Dim overAllPos As New List(Of Double)
            overAllPos = (From all In allResults
                          Order By all.Item2 Descending
                          Select all.Item2).ToList()



            For i = 0 To dgvMeanMarks.RowCount - 4
                element = overAllPos.IndexOf(Convert.ToDouble(dgvMeanMarks.Rows(i).Cells(sortby).Value))
                dgvMeanMarks.Rows(i).Cells("OP").Value = (element + 1)
            Next


            'Compute Stream Position
            For s = 0 To classStream.Count - 1

                'get the results for one stream only
                j = s
                streamList = (From all In allResults
                              Where all.Item1 = classStream(j)
                              Order By all.Item2 Descending
                              Select all.Item2).ToList()

                For i = 0 To dgvMeanMarks.RowCount - 4

                    'do not loop if stream is not the same
                    If dgvMeanMarks.Rows(i).Cells("STR").Value = classStream(j) Then

                        'IndexOf returns -1 when that item does not occur remember its a zero based so add one to the element
                        element = streamList.IndexOf(Convert.ToDouble(dgvMeanMarks.Rows(i).Cells(sortby).Value))
                        dgvMeanMarks.Rows(i).Cells("SP").Value = (element + 1)
                    End If
                Next

            Next

            dgvMeanMarks.Sort(dgvMeanMarks.Columns("OP"), System.ComponentModel.ListSortDirection.Ascending)

        End Using

    End Sub

    Private Function convertGradeToPoints(ByVal grade As String) As Int16

        Dim points As Int16
        points = GradeToPoint(grade)
        Return points

    End Function

    Private Sub showMarksAndGrade()

        Using New DevExpress.Utils.WaitDialogForm("Computing Please Wait ...")
            For i = 0 To dgvMeanMarks.Rows.Count - 1
                For Each s As String In subjectColumns
                    subjectMark = dgvMeanMarks.Rows(i).Cells(s).Value
                    subjectGrade = convertMarksToGrade(subjectMark, gradingType, s)
                    dgvMeanMarks.Rows(i).Cells(s).Value = subjectMark.ToString() + " " + subjectGrade
                Next
            Next
        End Using


    End Sub

    Private Sub deleteMarkGrade()
        Dim mark As String = String.Empty

        Using New DevExpress.Utils.WaitDialogForm("Please Wait ...")
            For i = 0 To dgvMeanMarks.Rows.Count - 1
                For Each s As String In subjectColumns
                    mark = dgvMeanMarks.Rows(i).Cells(s).Value
                    If mark.Length > 2 Then
                        mark = mark.Remove(mark.Length - 2)
                        dgvMeanMarks.Rows(i).Cells(s).Value = mark
                    End If
                Next
            Next
        End Using


    End Sub

    Private Function getMeanGrade(ByVal meanGrade As Int16) As String
        Dim grade As String = String.Empty
        For Each var In GradeToPoint
            If meanGrade >= var.Value Then
                grade = var.Key
                Exit For
            End If
        Next
        Return grade
    End Function

    Private Function getSelectStatement(ByVal stude_admno As String) As String
        Dim statements As String = String.Empty

        For Each S As String In subjectColumns
            statements += "round("

            For j = 0 To examListMain.Count - 1
                statements += "sum((select ((" + S + "/" + examListMain(j).Item5 + ")*" + examListMain(j).Item2 + ") from exam_results where admno = " + stude_admno + " and (examination = '" + examListMain(j).Item1 + "' and term = '" + examListMain(j).Item3 + "' and year = " + examListMain(0).Item4 + " ))) +"
            Next

            statements = statements.Remove(statements.Length - 1)
            statements += ") as " + S + ","
        Next

        statements = statements.Remove(statements.Length - 1)

        Return statements
    End Function



    Private Sub chkMarksGrade_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarksGrade.CheckedChanged
        If chkMarksGrade.CheckState = CheckState.Checked Then
            showMarksAndGrade()
        Else
            deleteMarkGrade()
        End If
    End Sub

    Private Sub setIndexing()
        Dim code As String = String.Empty
        Dim kcpe As String = String.Empty

        If qread("select code from school_details") Then
            If dbreader.RecordsAffected = 0 Then
                If Not confirm("Your School Code May Not Have Been Set! Do You Want To Continue Anyway?") Then
                    Exit Sub
                End If
            Else
                code = dbreader("code")
            End If
        End If

        If confirm("Are You Sure ?") Then
            start()

            Using New DevExpress.Utils.WaitDialogForm("Saving Data Please Wait")
                For i = 0 To dgvMeanMarks.Rows.Count - 1
                    kcpe = code + dgvMeanMarks.Rows(i).Cells("OP").Value
                    If Not qwrite("UPDATE students SET kcpeno = '" & kcpe & "' WHERE admin_no =  '" & dgvMeanMarks.Rows(i).Cells("admno").Value & "'") Then
                        rollback()
                        failure("Could Not Successfully Perform kcpe Numbering!")
                        Exit Sub
                    End If
                Next
            End Using

            commit()
            MsgBox("The Operation  Was Successful")
        End If

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        exportDataToExcel()
    End Sub

    Dim bufferDatatable As New DataTable
    Private Sub chkMode_CheckedChanged(sender As Object, e As EventArgs) Handles chkMode.CheckedChanged
        If chkMode.CheckState = CheckState.Checked Then
            getB7()
        Else
            dgvMeanMarks.DataSource = Nothing
            dgvMeanMarks.Rows.Clear()
            dgvMeanMarks.Columns.Clear()
            bufferDatatable = originalData.Copy
            dgvMeanMarks.DataSource = bufferDatatable
        End If
    End Sub

    Private Sub initializeAverageResult()
        For Each x In subjectColumns
            overallAverage.Add(x, 0)
            averagePoints.Add(x, 0)
        Next
    End Sub

    Dim allResults As New List(Of Tuple(Of String, Double))
    Dim streamResults As New List(Of Tuple(Of String, Double))

    Private Sub frmComputeResults_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            Using New DevExpress.Utils.WaitDialogForm("Please Wait ...")


                If Not getGradingScheme() Then
                    MsgBox("The " + gradingType + " Grading Scheme For Class " + selectedClass + " Term " + selectedTerm + " Year " + selectedYear + " Does Not Exist In The Database. Please Add It To Proceed Or Select Another Grading Scheme")
                    Exit Sub
                End If

                initialzeGradePoints()
                getStreams()
                initializeAverageResult()

                If qread("select admin_no, student_name, marks_attained_primary as kcpe, class, stream from students where class = '" + selectedClass + "';") Then
                    If dbreader.RecordsAffected > 0 Then
                        While dbreader.Read
                            students.Add(New Tuple(Of Int64, String, String, String, String)(dbreader("admin_no"), dbreader("student_name"), dbreader("kcpe"), dbreader("class"), dbreader("stream")))
                        End While
                    End If
                End If

                reorderColumns()
                getStudentSubjectDone()

                Dim rowValues As New List(Of String)
                Dim sqlStatment As String = String.Empty


                Dim markSubject As New Dictionary(Of String, Int16)
                Dim isUpperClass As Boolean = False

                allResults.Clear()
                streamResults.Clear()

                For i = 0 To students.Count - 1

                    rowValues.Clear()
                    tmm = 0
                    tpp = 0
                    markSubject.Clear()

                    If (selectedClass.ToLower() = "form 2" Or selectedClass.ToLower = "form 3" Or selectedClass.ToLower = "form 4") Then
                        isUpperClass = True
                    End If


                    sqlStatment = "select " + getSelectStatement(students(i).Item1.ToString())

                    If qread(sqlStatment) Then
                        If dbreader.RecordsAffected > 0 Then

                            rowValues.Add(students(i).Item1)
                            rowValues.Add(students(i).Item2)
                            rowValues.Add(students(i).Item3)

                            While dbreader.Read

                                For Each s As String In subjectColumns
                                    If IsDBNull(dbreader(s)) Then
                                        subjectMark = 0
                                    Else
                                        subjectMark = dbreader(s)
                                    End If

                                    rowValues.Add(subjectMark)

                                    subjectGrade = convertMarksToGrade(subjectMark, gradingType, s)
                                    subjectPoints = convertGradeToPoints(subjectGrade)
                                    tpp += subjectPoints

                                    tmm += subjectMark
                                Next

                            End While

                            subjectEntries = getSubjectEntries(students(i).Item1)
                            rowValues.Add(subjectEntries)

                            rowValues.Add(tpp)

                            mpp = Math.Round((tpp / subjectEntries), 2, MidpointRounding.AwayFromZero)
                            rowValues.Add(mpp)

                            mgg = getMeanGrade(mpp)
                            rowValues.Add(mgg)

                            rowValues.Add(tmm)

                            rowValues.Add(students(i).Item5)

                            dgvMeanMarks.Rows.Add(rowValues.ToArray())

                            If sortGradesBy = "Total Marks" Then
                                allResults.Add(New Tuple(Of String, Double)(students(i).Item5, tmm))
                            ElseIf sortGradesBy = "Mean Marks" Then
                                allResults.Add(New Tuple(Of String, Double)(students(i).Item5, tmm / subjectEntries))
                            ElseIf sortGradesBy = "Mean Points" Then
                                allResults.Add(New Tuple(Of String, Double)(students(i).Item5, mpp))
                            Else
                                allResults.Add(New Tuple(Of String, Double)(students(i).Item5, tpp))
                            End If

                        End If
                    End If

                Next

                If sortGradesBy = "Total Marks" Then
                    sortby = "TM"
                ElseIf sortGradesBy = "Mean Marks" Then
                    sortby = "MM"
                ElseIf sortGradesBy = "Mean Points" Then
                    sortby = "MP"
                Else
                    sortby = "TP"
                End If


                Dim streamList As New List(Of Double)
                Dim element As Integer
                Dim j As Integer

                'Compute Overall Position
                Dim overAllPos As New List(Of Double)
                overAllPos = (From all In allResults
                              Order By all.Item2 Descending
                              Select all.Item2).ToList()


                resultsTotal = 0
                averageMP = 0

                For i = 0 To dgvMeanMarks.RowCount - 1
                    element = overAllPos.IndexOf(Convert.ToDouble(dgvMeanMarks.Rows(i).Cells(sortby).Value))
                    dgvMeanMarks.Rows(i).Cells("OP").Value = (element + 1)

                    Dim studGrade As String = String.Empty
                    Dim studPoint As Double
                    For Each x In subjectColumns
                        If IsNumeric(dgvMeanMarks.Rows(i).Cells(x).Value) Then
                            overallAverage(x) += dgvMeanMarks.Rows(i).Cells(x).Value

                            studGrade = convertMarksToGrade(dgvMeanMarks.Rows(i).Cells(x).Value, gradingType, x)
                            studPoint = convertGradeToPoints(studGrade)
                            averagePoints(x) += studPoint
                        End If
                    Next

                    resultsTotal += dgvMeanMarks.Rows(i).Cells("TM").Value
                    averageMP += dgvMeanMarks.Rows(i).Cells("MP").Value

                Next


                'Compute Stream Position
                For s = 0 To classStream.Count - 1

                    'get the results for one stream only
                    j = s
                    streamList = (From all In allResults
                                  Where all.Item1 = classStream(j)
                                  Order By all.Item2 Descending
                                  Select all.Item2).ToList()

                    For i = 0 To dgvMeanMarks.RowCount - 1

                        'do not loop if stream is not the same
                        If dgvMeanMarks.Rows(i).Cells("STR").Value = classStream(j) Then

                            'kcpeOf returns -1 when that item does not occur remember its a zero based so add one to the element
                            element = streamList.IndexOf(Convert.ToDouble(dgvMeanMarks.Rows(i).Cells(sortby).Value))
                            dgvMeanMarks.Rows(i).Cells("SP").Value = (element + 1)
                        End If
                    Next

                Next

                dgvMeanMarks.Sort(dgvMeanMarks.Columns("OP"), System.ComponentModel.ListSortDirection.Ascending)
                classCount = dgvMeanMarks.Rows.Count - 1
                dgvMeanMarks.Rows.AddCopies(dgvMeanMarks.Rows.Count - 1, 4)

                fillMeanScore()

                fillDataTable()

            End Using
        End If
    End Sub

    Dim overallAverage As New Dictionary(Of String, Integer)
    Dim averagePoints As New Dictionary(Of String, Double)
    Dim studentCount As New Dictionary(Of String, Integer)
    Dim classCount As Integer
    Dim resultsTotal As Integer
    Dim averageMP As Integer

    Private Sub getStudentSubjectDone()
        Dim admno As String = "("
        Dim query As String = String.Empty
        For k = 0 To students.Count - 1
            admno += " admno = " + students(k).Item1.ToString() + " or "
        Next

        admno = admno.Remove(admno.Length - 3)
        admno += ");"

        For Each s In subjectColumns
            query = "select count(" + s + ") as count from subjects_done where " + s + " = 'Yes' and " + admno
            If qread(query) Then
                While dbreader.Read
                    studentCount.Add(s, dbreader("count"))
                End While
            End If
        Next

    End Sub

    Private Sub fillMeanScore()
        Dim averageScore As New Dictionary(Of String, String)
        Dim scoreCount, gradeCount, pointsCount, markCount, previous As Integer
        Dim ans As Double
        Dim grade As String = String.Empty

        scoreCount = dgvMeanMarks.Rows.Count - 4
        dgvMeanMarks.Rows(scoreCount).Cells("student_name").Value = "MEAN SCORE"

        For Each s In subjectColumns
            ans = Math.Round((overallAverage(s) / studentCount(s)), 2, MidpointRounding.AwayFromZero)
            dgvMeanMarks.Rows(scoreCount).Cells(s).Value = ans
            overallAverage(s) = ans
        Next

        markCount = dgvMeanMarks.Rows.Count - 3
        dgvMeanMarks.Rows(markCount).Cells("student_name").Value = "MEAN GRADE (M.MARKS)"

        For Each s In subjectColumns
            grade = convertMarksToGrade(overallAverage(s), gradingType, s)
            dgvMeanMarks.Rows(markCount).Cells(s).Value = grade
            averageScore.Add(s, grade)
        Next

        pointsCount = dgvMeanMarks.Rows.Count - 2
        dgvMeanMarks.Rows(pointsCount).Cells("student_name").Value = "MEAN POINTS"

        For Each s In subjectColumns
            ans = averagePoints(s) / studentCount(s)
            dgvMeanMarks.Rows(pointsCount).Cells(s).Value = Math.Round(ans, 2, MidpointRounding.AwayFromZero)
            averageScore(s) = ans
        Next
        ans = Math.Round(averageMP / classCount, 2, MidpointRounding.AwayFromZero)
        dgvMeanMarks.Rows(pointsCount).Cells("MP").Value = ans
        dgvMeanMarks.Rows(pointsCount).Cells("MG").Value = getMeanGrade(ans)
        dgvMeanMarks.Rows(pointsCount).Cells("TM").Value = Math.Round(resultsTotal / classCount, 2, MidpointRounding.AwayFromZero)

        gradeCount = dgvMeanMarks.Rows.Count - 1
        previous = gradeCount - 1
        dgvMeanMarks.Rows(gradeCount).Cells("student_name").Value = "MEAN GRADE (M. POINTS)"

        For Each s In subjectColumns
            ans = dgvMeanMarks.Rows(previous).Cells(s).Value
            grade = getMeanGrade(Convert.ToInt16(ans))
            dgvMeanMarks.Rows(gradeCount).Cells(s).Value = grade
        Next

    End Sub

    Private Sub btnClassPerformance_Click(sender As Object, e As EventArgs) Handles btnClassPerformance.Click
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

    Private Function print_student_report2()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report2
        Return print_document
    End Function

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
                e.Graphics.DrawImage(Image.FromFile(logoPath), left_margin + 10, line, 90, 90)
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
        If start_from < dgvMeanMarks.Rows.Count Then
            For col As Integer = 0 To dgvMeanMarks.Columns.Count - 1
                If dgvMeanMarks.Columns(col).Visible Then
                    If count = 1 Then
                        e.Graphics.DrawString(dgvMeanMarks.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
                    Else
                        Try
                            e.Graphics.DrawString(dgvMeanMarks.Columns(col).HeaderText.Substring(0, 3), smallfont, Brushes.Black, left_margin, line)
                        Catch ex As Exception
                            e.Graphics.DrawString(dgvMeanMarks.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
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
        For row As Integer = start_from To dgvMeanMarks.Rows.Count - 1
            line += 2
            If row = dgvMeanMarks.Rows.Count - 4 Then
                line += 10
            End If
            If line >= max_height And row < dgvMeanMarks.Rows.Count - 1 Then
                count = 0
                line += 5
                e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line)
                left_margin = 40
                For k As Integer = 0 To dgvMeanMarks.Columns.Count - 1
                    If dgvMeanMarks.Columns(k).Visible Then
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
            For col As Integer = 0 To dgvMeanMarks.Columns.Count - 1
                If dgvMeanMarks.Columns(col).Visible Then
                    If dgvMeanMarks.Columns(col).Name = "STR" Then
                        If dgvMeanMarks.Item("STR", row).Value <> Nothing Then
                            If dgvMeanMarks.Item("STR", row).Value.ToString.Length > 3 Then
                                e.Graphics.DrawString(dgvMeanMarks.Item(dgvMeanMarks.Columns(col).Name, row).Value.ToString.Substring(0, 3), smallfont, Brushes.Black, left_margin, line + 2)
                            Else
                                e.Graphics.DrawString(dgvMeanMarks.Item(dgvMeanMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                            End If
                        End If
                    ElseIf dgvMeanMarks.Columns(col).Name = "kcpe" Then
                        If dgvMeanMarks.Item("kcpe", row).Value <> Nothing Then
                            If dgvMeanMarks.Item("kcpe", row).Value.ToString.Length > 3 Then
                                e.Graphics.DrawString(dgvMeanMarks.Item(dgvMeanMarks.Columns(col).Name, row).Value.ToString.Substring(dgvMeanMarks.Item("kcpe", row).Value.ToString.Length - 3, 3), smallfont, Brushes.Black, left_margin, line + 2)
                            Else
                                e.Graphics.DrawString(dgvMeanMarks.Item(dgvMeanMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                            End If
                        End If
                    Else
                        e.Graphics.DrawString(dgvMeanMarks.Item(dgvMeanMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
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
            If row < dgvMeanMarks.Rows.Count - 4 Then
                e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line)
            End If
            line += 10
        Next
        If start_from < dgvMeanMarks.Rows.Count Then
            count = 0
            line += 5
            e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line)
            left_margin = 40
            For k As Integer = 0 To dgvMeanMarks.Columns.Count - 1
                If dgvMeanMarks.Columns(k).Visible Then
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
            start_from = dgvMeanMarks.Rows.Count
            e.HasMorePages = True
            Exit Sub
        End If
        line += 20
        left_margin = 100
        get_streams(class_form)
        If line + 20 * (grades.Length) + line + other_font.Height * (streams.Length + 1) > max_height + 60 Then
            start_from = dgvMeanMarks.Rows.Count
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
                If dgvMeanMarks.Item(subjname(k).ToString, dgvMeanMarks.Rows.Count - 1).Value = grades(g) Then
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

    Dim start_from As Integer = 0
    Dim logoPath As String
    Dim mode_view As Boolean = True

    Private Function count_grades(grade As String, str As String) As Integer
        For k As Integer = 0 To dgvMeanMarks.Rows.Count - 4
            If dgvMeanMarks.Item("MG", k).Value = grade And dgvMeanMarks.Item("STR", k).Value = str Then
                count_grades += 1
            End If
        Next
    End Function

    Private Sub btnIndexing_Click(sender As Object, e As EventArgs) Handles btnIndexing.Click
        setIndexing()
    End Sub

    Private Sub btnStreamPerformance_Click(sender As Object, e As EventArgs) Handles btnStreamPerformance.Click
        class_form = selectedClass
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

    Private Function print_student_report3()
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf print_report3
        Return print_document
    End Function


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
        If start_from < dgvMeanMarks.Rows.Count Then
            For col As Integer = 0 To dgvMeanMarks.Columns.Count - 1
                If dgvMeanMarks.Columns(col).Visible Then
                    If count = 1 Then
                        e.Graphics.DrawString(dgvMeanMarks.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
                    Else
                        Try
                            e.Graphics.DrawString(dgvMeanMarks.Columns(col).HeaderText.Substring(0, 3), smallfont, Brushes.Black, left_margin, line)
                        Catch ex As Exception
                            e.Graphics.DrawString(dgvMeanMarks.Columns(col).HeaderText, smallfont, Brushes.Black, left_margin, line)
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
        For row As Integer = start_from To dgvMeanMarks.Rows.Count - 1
            If dgvMeanMarks.Item("STR", row).Value = class_stream Then
                line += 2
                If line >= max_height And row < dgvMeanMarks.Rows.Count - 1 Then
                    e.HasMorePages = True
                    start_from = row
                    Exit Sub
                End If
                left_margin = 40
                count = 0
                For col As Integer = 0 To dgvMeanMarks.Columns.Count - 1
                    If dgvMeanMarks.Columns(col).Visible Then
                        If dgvMeanMarks.Columns(col).Name = "STR" Then
                            If dgvMeanMarks.Item("STR", row).Value.ToString.Length > 3 Then
                                e.Graphics.DrawString(dgvMeanMarks.Item(dgvMeanMarks.Columns(col).Name, row).Value.ToString.Substring(0, 3), smallfont, Brushes.Black, left_margin, line + 2)
                            Else
                                e.Graphics.DrawString(dgvMeanMarks.Item(dgvMeanMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
                            End If
                        Else
                            e.Graphics.DrawString(dgvMeanMarks.Item(dgvMeanMarks.Columns(col).Name, row).Value, smallfont, Brushes.Black, left_margin, line + 2)
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
            For k As Integer = 0 To dgvMeanMarks.Columns.Count - 1
                If dgvMeanMarks.Columns(k).Visible Then
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
            start_from = dgvMeanMarks.Rows.Count
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
        For col As Integer = 0 To dgvMeanMarks.Columns.Count - 1
            For s As Integer = 0 To subjabb.Length - 1
                Dim counter As Integer = 0
                Dim tm, tp As Double
                tm = 0
                tp = 0
                If dgvMeanMarks.Columns(col).Name = subjname(s) Then
                    For row As Integer = 0 To dgvMeanMarks.Rows.Count - 1
                        If dgvMeanMarks.Item(subjname(s).ToString, row).Value.ToString <> "-" And dgvMeanMarks.Item("STR", row).Value = class_stream Then
                            counter += 1
                            Dim marks() As String = dgvMeanMarks.Item(subjname(s).ToString, row).Value.ToString.Split(" ")
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
        If start_from < dgvMeanMarks.Rows.Count Then
            count = 0
            line += 5
            e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line)
            left_margin = 40
            For k As Integer = 0 To dgvMeanMarks.Columns.Count - 1
                If dgvMeanMarks.Columns(k).Visible Then
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
            start_from = dgvMeanMarks.Rows.Count
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If confirm("Are You Sure You Want To Save This Analysis As Examination Performance For This Particular Examination?") Then
            save_examination()
        End If
    End Sub

    Private Sub save_examination()

        For k = 0 To examListMain.Count - 1
            exam_name += examListMain(k).Item1 + "/"
        Next
        exam_name = exam_name.Remove(exam_name.Length - 1)

        For k As Integer = 0 To dgvMeanMarks.Rows.Count - 5
            Dim test As String = "SELECT * FROM examination_performance WHERE (ADMNo='" & dgvMeanMarks.Item("admno", k).Value & "' AND exam='" & exam_name & "' AND term='" & tm & "' AND year='" & yr & "')"

            qread("SELECT * FROM examination_performance WHERE (ADMNo='" & dgvMeanMarks.Item("admno", k).Value & "' AND exam='" & exam_name & "' AND term='" & tm & "' AND year='" & yr & "')")
            If dbreader.RecordsAffected > 0 Then
                qwrite("UPDATE examination_performance SET pos='" & dgvMeanMarks.Item("OP", k).Value & "/" & dgvMeanMarks.Rows.Count - 4 & "' WHERE (ADMNo='" & dgvMeanMarks.Item("admno", k).Value & "' AND exam='" & exam_name & "' AND term='" & tm & "' AND year='" & yr & "')")
            Else
                qwrite("INSERT INTO examination_performance VALUES(NULL, '" & dgvMeanMarks.Item("admno", k).Value & "', '" & exam_name & "', '" & tm & "','" & yr & "','" & dgvMeanMarks.Item("OP", k).Value & "/" & dgvMeanMarks.Rows.Count - 4 & "')")
            End If

        Next
        success("Examination Performance Saved!")
    End Sub
End Class