Public Class frmBestStudentSubject


    Private Sub frmBestStudentSubject_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        resultDGV.Rows.Clear()
        resultDGV.Columns.Clear()

        If Not connect() Then
            Me.Close()
        Else
            Using New DevExpress.Utils.WaitDialogForm("Please Wait ...")

                getSchoolSubjects()
                If Not getGradingScheme() Then
                    MsgBox("The " + gradingType + " Grading Scheme For Class " + selectedClass + " Term " + selectedTerm + " Year " + selectedYear + " Does Not Exist In The Database. Please Add It To Proceed Or Select Another Grading Scheme")
                    Exit Sub
                End If

                initialzeGradePoints()
                reorderColumns(resultDGV, False)

                students.Clear()

                If qread("select admin_no, student_name, gender, class, stream from students where class = '" + selectedClass + "';") Then
                    If dbreader.RecordsAffected > 0 Then
                        While dbreader.Read
                            students.Add(New Tuple(Of Int64, String, String, String, String)(dbreader("admin_no"), dbreader("student_name"), dbreader("gender"), dbreader("class"), dbreader("stream")))
                        End While
                    End If
                End If

                Dim query As String = String.Empty
                Dim examTotal As Int16
                Dim totalMarks As Int16
                Dim rowValues As New List(Of String)
                Dim studGrade As String = String.Empty
                Dim studPoints As String = String.Empty


                For Each subject In schoolSubjects

                    reorderColumns(computeDVG)

                    For i = 0 To students.Count - 1

                        totalMarks = 0

                        For j = 0 To selectedExams.Count - 1
                            examTotal = get_total_mark(selectedExams(j).Item1, selectedExams(j).Item3, selectedExams(j).Item4)
                            query = "select COALESCE(((" + subject + "/" + examTotal.ToString() + ") * " + selectedExams(j).Item2 + "), 0) as total from exam_results where examination = '" + selectedExams(j).Item1 + "' and admno = " + students(i).Item1.ToString() + " and term = '" + selectedExams(j).Item3 + "' and year = '" + selectedExams(j).Item4.ToString() + "'"

                            If qread(query) Then
                                If dbreader.RecordsAffected > 0 Then
                                    While dbreader.Read
                                        totalMarks += dbreader("total")
                                    End While
                                End If
                            End If
                        Next

                        rowValues.Add("0")
                        rowValues.Add(students(i).Item1)
                        rowValues.Add(students(i).Item2)
                        rowValues.Add(students(i).Item3)
                        rowValues.Add(totalMarks)
                        If gradingType = "SubjectBased" Then
                            studGrade = convertMarksToGrade(totalMarks, gradingType, subject)
                        Else
                            studGrade = convertMarksToGrade(totalMarks, gradingType)
                        End If

                        rowValues.Add(studGrade)
                        studPoints = convertGradeToPoints(studGrade)
                        rowValues.Add(studPoints)


                        computeDVG.Rows.Add(rowValues.ToArray())
                        rowValues.Clear()
                    Next

                    Dim row As DataGridViewRow
                    computeDVG.Sort(computeDVG.Columns(4), System.ComponentModel.ListSortDirection.Descending)


                    If filterType = "Top" Then
                        If rankno + 1 < computeDVG.Rows.Count Then
                            For i = computeDVG.Rows.Count - 1 To rankno Step -1
                                row = computeDVG.Rows(i)
                                computeDVG.Rows.Remove(row)
                            Next
                        End If
                    End If

                    If filterType = "Bottom" Then

                        If rankno + 1 < computeDVG.Rows.Count Then
                            For i = (computeDVG.Rows.Count - 1) - rankno To 0 Step -1
                                row = computeDVG.Rows(i)
                                computeDVG.Rows.Remove(row)
                            Next
                        End If

                    End If


                    fillResultTable(computeDVG, subject)

                Next

            End Using
        End If

    End Sub


    Private Sub fillResultTable(ByRef dgv As DataGridView, ByVal subject As String)

        Dim counter As Int16 = 1
        resultDGV.Rows.Add(subject)
        For k = 0 To dgv.Rows.Count - 1
            resultDGV.Rows.Add(counter, dgv.Rows(k).Cells(1).Value, dgv.Rows(k).Cells(2).Value, dgv.Rows(k).Cells(3).Value, dgv.Rows(k).Cells(4).Value, dgv.Rows(k).Cells(5).Value, dgv.Rows(k).Cells(6).Value)
            counter += 1
        Next

    End Sub


    Public Function getSchoolSubjects()
        schoolSubjects.Clear()
        Dim available As Boolean = False
        If qread("select abbreviation from subjects;") Then
            If dbreader.RecordsAffected > 0 Then
                available = True
                While dbreader.Read
                    schoolSubjects.Add(dbreader("abbreviation"))
                End While
            End If
        End If

        Return available
    End Function


    Public Sub reorderColumns(ByRef dgv As DataGridView, Optional ByVal delete As Boolean = True)

        If delete Then
            dgv.Rows.Clear()
            dgv.Columns.Clear()
        End If

        dgv.Columns.Add("No", "No")
        dgv.Columns.Add("admno", "Adm No.")
        dgv.Columns.Add("student_name", "Name Of Student")
        dgv.Columns.Add("gender", "Gender")



        dgv.Columns.Add("marks", "marks")
        dgv.Columns.Add("grade", "grade")
        dgv.Columns.Add("point", "Points")

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If resultDGV.Rows.Count > 0 Then
            generateFromDataTable("Subject Wise Ranking", "From Grid", String.Empty, Nothing, resultDGV)
        Else
            MsgBox("There are no row to print")
        End If
    End Sub
End Class