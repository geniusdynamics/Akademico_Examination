Public Class frmReportConfiguration

    Private Sub frmReportConfiguration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            loadDefaults()
        End If
    End Sub

    Dim operationType As String = ""

    Private Sub loadDefaults()
        qread("SELECT * FROM report_configuration")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            chkClubSociety.Checked = CheckStatus(dbreader("club_and_societies"))
            chkCTC.Checked = CheckStatus(dbreader("class_teacher_comments"))
            chkCTS.Checked = CheckStatus(dbreader("class_teacher_signature"))
            chkHouse.Checked = CheckStatus(dbreader("house_master_comments"))
            chkHTC.Checked = CheckStatus(dbreader("head_teacher_comments"))
            chkHTS.Checked = CheckStatus(dbreader("head_teacher_signature"))
            chkLogo.Checked = CheckStatus(dbreader("school_logo"))
            chkPhoto.Checked = CheckStatus(dbreader("student_photo"))
            chkHTN.Checked = CheckStatus(dbreader("head_teacher_name"))
            chkCTN.Checked = CheckStatus(dbreader("class_teacher_name"))
            operationType = "Update"
        Else
            operationType = "Insert"
        End If

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If operationType = "Insert" Then
            query = "Insert into report_configuration SET student_photo="
        Else
            query = "UPDATE report_configuration SET student_photo="
        End If

        If chkPhoto.Checked Then
            query &= "1,"
        Else
            query &= "0,"
        End If
        query &= "school_logo="
        If chkLogo.Checked Then
            query &= "1,"
        Else
            query &= "0,"
        End If
        query &= "class_teacher_signature="
        If chkCTS.Checked Then
            query &= "1,"
        Else
            query &= "0,"
        End If
        query &= "head_teacher_signature="
        If chkHTS.Checked Then
            query &= "1,"
        Else
            query &= "0,"
        End If
        query &= "class_teacher_comments="
        If chkCTC.Checked Then
            query &= "1,"
        Else
            query &= "0,"
        End If
        query &= "head_teacher_comments="
        If chkHTC.Checked Then
            query &= "1,"
        Else
            query &= "0,"
        End If
        query &= "house_master_comments="
        If chkHouse.Checked Then
            query &= "1,"
        Else
            query &= "0,"
        End If
        query &= "head_teacher_name="
        If chkHTN.Checked Then
            query &= "1,"
        Else
            query &= "0,"
        End If
        query &= "class_teacher_name="
        If chkCTN.Checked Then
            query &= "1,"
        Else
            query &= "0,"
        End If
        query &= "club_and_societies="
        If chkHouse.Checked Then
            query &= "1"
        Else
            query &= "0"
        End If
        If qwrite(query) Then
            success("Report Form Configuration Successfully Saved!")
            loadDefaults()
        Else
            failure("Report Form Configuration Could Not Be Saved!")
        End If
    End Sub
End Class