Public Class frmPrintSubjectsTaken
    Private Sub frmPrintSubjectsTaken_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not connect() Then
            frmDBConnection.ShowDialog()
            Return
        End If

        reportDT.Columns.Add("ADM NO")
        reportDT.Columns.Add("STUDENT")

        Dim queries As String() = {"select distinct class from class_stream;", "select distinct stream from class_stream;", "select distinct subject from subjects;"}
        Dim counter As Integer = 0
        For Each s As String In queries
            If qread(s) Then
                If dbreader.RecordsAffected > 0 Then
                    While dbreader.Read
                        If counter = 0 Then
                            cboClass.Items.Add(dbreader("class"))
                        ElseIf counter = 1 Then
                            CboStream.Items.Add(dbreader("stream"))
                        ElseIf counter = 2 Then
                            cboSubject.Items.Add(dbreader("subject"))
                        End If
                    End While
                End If
            End If
            counter += 1
        Next

        If Not Me.Text = "Show Subjects Taken" Then
            cboSubject.Items.Insert(0, "ALL")
        End If
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        reportDT.Rows.Clear()
        If cboClass.SelectedItem = Nothing Then
            ErrorProvider1.SetError(cboClass, "Please Select The Class")
        ElseIf cboSubject.SelectedItem = Nothing Then
            ErrorProvider1.SetError(cboSubject, "Please Select The Subject")
        Else

            If CboStream.SelectedItem = Nothing Then
                If Not loadAdmissionNumber("Class Only") Then
                    Return
                End If
            ElseIf Not loadAdmissionNumber("Class and Stream") Then
                Return
            End If

            If Me.Text = "Show Subjects Taken" Then

                Dim abbreviation As String = getAbbreviation(cboSubject.SelectedItem.ToString())

                For Each adm As Long In adminNos.Keys
                    Dim test As String = "select admno from subjects_done where admno = '" + adm.ToString() + "' and " + abbreviation + " = 'Yes';"
                    If qread("select admno from subjects_done where admno = '" + adm.ToString() + "' and " + abbreviation + " = 'Yes';") Then
                        If dbreader.RecordsAffected > 0 Then
                            Dim rowData As String() = {adm.ToString(), adminNos(adm)}
                            reportDT.Rows.Add(rowData)
                        End If
                    End If
                Next

                Dim rptTitle = ""
                If CboStream.SelectedItem IsNot Nothing Then
                    rptTitle = "Student List For " + cboSubject.SelectedItem.ToString() + " Class " + cboClass.SelectedItem.ToString() + " Stream " + CboStream.SelectedItem.ToString()
                Else
                    rpt = "Student List For " + cboSubject.SelectedItem.ToString() + " Class " + cboClass.SelectedItem.ToString()
                End If

                generateFromDataTable(rptTitle, "From DT", "", reportDT)
            Else
                clearAdd()

                If cboSubject.SelectedIndex = 0 Then
                    Dim items = cboSubject.Items.GetEnumerator()

                    While items.MoveNext()
                        reportDT.Columns.Add(getAbbreviation(items.Current))
                    End While
                    reportDT.Columns.RemoveAt(2)
                Else
                    reportDT.Columns.Add(cboSubject.SelectedItem.ToString())
                End If

                For Each adm As Long In adminNos.Keys
                    Dim rowData As String() = {adm.ToString(), adminNos(adm)}
                    reportDT.Rows.Add(rowData)
                Next

                Dim rptTitle = ""
                If CboStream.SelectedItem IsNot Nothing Then
                    rptTitle = "Student List For " + cboSubject.SelectedItem.ToString() + " Class " + cboClass.SelectedItem.ToString() + " Stream " + CboStream.SelectedItem.ToString()
                Else
                    rpt = "Student List For " + cboSubject.SelectedItem.ToString() + " Class " + cboClass.SelectedItem.ToString()
                End If

                generateFromDataTable(rptTitle, "From DT", "", reportDT)
            End If

        End If
    End Sub

    Private Sub clearAdd()
        reportDT.Rows.Clear()
        reportDT.Columns.Clear()
        reportDT.Columns.Add("ADM NO")
        reportDT.Columns.Add("STUDENT")
        Dim identifier As Guid = Guid.NewGuid()
        reportDT.TableName = identifier.ToString()
    End Sub

    Private Function getAbbreviation(ByRef subject As String)
        Dim abb As String = ""
        If qread("select abbreviation from subjects where subject = '" + subject + "'", 1) Then
            If dbreader1.RecordsAffected > 0 Then
                dbreader1.Read()
                abb = dbreader1("abbreviation")
            End If
        End If
        Return abb
    End Function
    Dim reportDT As New DataTable

    Dim adminNos As New Dictionary(Of Long, String)


    Private Function loadAdmissionNumber(ByVal type As String) As Boolean
        adminNos.Clear()
        successful = False
        Dim q As String = ""
        If type = "Class Only" Then
            q = "select admin_no, student_name from students where class = '" + cboClass.SelectedItem.ToString() + "' and isstudent = 'true';"
        Else
            q = "select admin_no, student_name from students where class = '" + cboClass.SelectedItem.ToString() + "' and stream = '" + CboStream.SelectedItem.ToString() + "' and isstudent='true';"
        End If
        If qread(q) Then
            If dbreader.RecordsAffected > 0 Then
                While dbreader.Read
                    adminNos.Add(dbreader("admin_no"), dbreader("student_name"))
                End While
                successful = True
            Else
                MsgBox("There Are No Students Registered In The Class")
            End If
        End If
        Return successful
    End Function
End Class