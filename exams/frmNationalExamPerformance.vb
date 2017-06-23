Public Class frmNationalExamPerformance
    Private Function isvalid() As Boolean
        If cboYear.SelectedItem <> Nothing And cboExamination.SelectedItem <> Nothing Then
            Return True
        Else
            failure("Please Select An Examination To Analyze Results For!")
            Return False
        End If
    End Function
    Private Sub frmNationalExamPerformance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            get_subjects()
            get_grades()
            For k As Integer = startyear To endyear
                cboYear.Items.Add(k)
            Next
            cboYear.SelectedItem = Today.Year
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If isvalid() Then
            exam_name = cboExamination.SelectedItem
            yr = cboYear.SelectedItem
            load_form()
            Dim frm As New frmNationalMeanAnalysis
            frm.ShowDialog()
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If isvalid() Then
            exam_name = cboExamination.SelectedItem
            yr = cboYear.SelectedItem
            load_form()
            Dim frm As New frmNationalGradesAttained
            frm.ShowDialog()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If isvalid() Then
            exam_name = cboExamination.SelectedItem
            yr = cboYear.SelectedItem
            load_form()
            rpt = "Subjects"
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If isvalid() Then
            exam_name = cboExamination.SelectedItem
            yr = cboYear.SelectedItem
            load_form()
            rpt = "Students"
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        If cboYear.SelectedItem.ToString <> None Then
            If stud Then
                query = "SELECT Name FROM national_examinations WHERE Year='" & cboYear.SelectedItem & "'"
            Else
                query = "SELECT Name FROM national_examinations WHERE Year='" & cboYear.SelectedItem & "'"
            End If
            cboExamination.Items.Clear()
            If qread(query) Then
                While dbreader.Read
                    cboExamination.Items.Add(dbreader("Name"))
                End While
            End If
        End If
    End Sub
End Class