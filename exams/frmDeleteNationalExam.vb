Public Class frmDeleteNationalExam
    Dim words() As String
    Private Sub frmDeleteExam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            For k As Integer = startyear To endyear
                cboYear.Items.Add(k)
            Next
            load_exams()
        End If
    End Sub
    Public Sub load_exams()
        ComboBox1.Items.Clear()
        If qread("SELECT * FROM national_examinations WHERE year='" & cboYear.SelectedItem & "'") Then
            While dbreader.Read
                ComboBox1.Items.Add(dbreader("Name"))
            End While
        Else
            failure("Could Not Read From The Examinations Database!")
        End If
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If confirm("Are you sure you want to delete examination!") Then
            delete()
            load_exams()
        End If
    End Sub
    Private Sub delete()
        If qwrite("DELETE FROM national_examinations WHERE Name='" & escape_string(ComboBox1.SelectedItem) & "'") Then
            success("Examination Successfully Deleted!")
        Else
            failure("Could Not Successfully Delete Examination Entry")
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        load_exams()
    End Sub
End Class