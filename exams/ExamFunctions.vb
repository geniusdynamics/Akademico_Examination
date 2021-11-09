Module ExamFunctions



    Private Sub copyValues(ByVal grades As Dictionary(Of String, List(Of Tuple(Of String, Int16))))
        subjectGrading2.Clear()
        subjectGrading2 = grades
    End Sub

    Public Function getGradingScheme() As Boolean
        Dim schemeAvailable As Boolean = False
        Dim query As String = String.Empty
        Dim gradess As String() = {"A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "E"}
        Dim gradeValues As New List(Of Tuple(Of String, Int16))
        Dim saveGradeValue As New List(Of Tuple(Of String, Int16))


        If String.IsNullOrEmpty(gradingType) Then
            gradingType = String.Empty
        End If

        If gradingType = "SubjectBased" Then

            subjectGrading.Clear()

            For Each s As String In schoolSubjects
                query = "SELECT * FROM s_grading WHERE (Class='" & selectedClass & "' AND Subject='" & get_subject_name(s) & "' AND term='" & selectedTerm & "' AND year='" & selectedYear & "');"
                If qread(query, 1) Then
                    If dbreader1.RecordsAffected > 0 Then
                        schemeAvailable = True
                        While dbreader1.Read
                            For Each g As String In gradess
                                gradeValues.Add(New Tuple(Of String, Int16)(g, dbreader1(g)))
                            Next
                            ' test(s, gradeValues)
                            subjectGrading.Add(s, gradeValues)
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

    Public Sub initialzeGradePoints()

        GradeToPoint.Clear()

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

    Public Function convertMarksToGrade(ByVal marks As Int16, ByVal gradingType As String, Optional ByVal subjectParm As String = "") As String
        Dim studGrade As String = String.Empty

        If marks = 0 Then
            studGrade = "Y"
        ElseIf gradingType = "SubjectBased" Then
            'Dim subjectGrading As New Dictionary(Of String, List(Of Tuple(Of String, Int16)))

            Dim subjGrade As New List(Of Tuple(Of String, Int16))
            For Each pair In subjectGrading
                If pair.Key = subjectParm Then
                    subjGrade = pair.Value
                End If
            Next


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

    Public Function convertGradeToPoints(ByVal grade As String) As Int16

        Dim points As Int16
        points = GradeToPoint(grade)
        Return points

    End Function

End Module
