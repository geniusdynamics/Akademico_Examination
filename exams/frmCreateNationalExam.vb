Public Class frmCreateNationalExam


    Private Sub create_examination()
        If qwrite("INSERT INTO national_examinations VALUES(NULL, '" & escape_string(Trim(txtExamName.Text).ToUpper) & "','" & cboYear.SelectedItem & "')") Then
            success("Examination Entry Successful!")
        Else
            failure("Examination Entry Failed!" & vbNewLine & "Duplicate Entry For Examination!")
        End If
    End Sub

    Private Function exists()
        If qread("SELECT * FROM national_examinations WHERE Name='" & escape_string(Trim(txtExamName.Text).ToUpper) & "' AND Year='" & cboYear.SelectedItem & "'") Then
            If dbreader.RecordsAffected > 0 Then
                dbreader.Close()
                Return True
            Else
                dbreader.Close()
                Return False
            End If
        Else
            failure("Could Not Read From The National Examinations Database!")
            Return True
        End If
    End Function
    Private Sub btnCreateExam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateExam.Click
        If Trim(txtExamName.Text) <> "" And Not exists() Then
            create_examination()
        Else
            failure("Invalid Value For Examination Name!")
        End If
    End Sub

    Private Sub frmCreateNationalExam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            For k As Integer = startyear To endyear
                cboYear.Items.Add(k)
            Next
            cboYear.SelectedItem = Today.Year
        End If
    End Sub
End Class