Public Class frmNationalExaminationsEntryPrompt


    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        If cboYear.SelectedItem.ToString <> None Then
            If cboExamination.SelectedItem <> None Then
                exam_name = cboExamination.SelectedItem
                cont = True
                yr = cboYear.SelectedItem
                load_from_alumni = CheckBox1.Checked
                Me.Close()
            Else
                failure("Invalid Choice For Examination Name!")
            End If
        Else
            failure("Invalid Choice For Year!")
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        If cboYear.SelectedItem.ToString <> None Then
            If stud Then
                query = "SELECT Name FROM national_examinations WHERE Year='" & cboYear.SelectedItem & "'"
            Else
                query = "SELECT Name FROM national_examinations WHERE Year='" & cboYear.SelectedItem & "'"
            End If
            If qread(query) Then
                While dbreader.Read
                    cboExamination.Items.Add(dbreader("Name"))
                End While
            End If
        End If
    End Sub

    Private Sub frmNationalExaminationsEntryPrompt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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