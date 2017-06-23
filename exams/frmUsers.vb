Public Class frmUsers
    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        End If

        loadLUE("teaching staff")
        loadGrid()
    End Sub

    Private Sub loadGrid()
        Dim myTable As DataTable = generateDataTable("select Title, partnername as Name, Designation, Department from system_users left join partners on partners.partnerName = system_users.partner where system_users.domain = md5('Examination')")
        userGC.DataSource = myTable
    End Sub

    Private Sub loadLUE(ByRef parameter As String)
        Dim myTable As DataTable = generateDataTable("select Title, partnername as Name, Designation, Department from partners where partnertype = '" + parameter + "'")
        partnersLUE.Properties.DataSource = myTable
        partnersLUE.Properties.DisplayMember = "Name"
        partnersLUE.Properties.ValueMember = "Name"

    End Sub

    Private Sub radioTeaching_CheckedChanged(sender As Object, e As EventArgs) Handles radioTeaching.CheckedChanged
        loadData()
    End Sub

    Private Sub radioNonTeaching_CheckedChanged(sender As Object, e As EventArgs) Handles radioNonTeaching.CheckedChanged
        loadData()
    End Sub

    Private Sub loadData()
        If radioNonTeaching.Checked = True Then
            loadLUE("support staff")
        Else
            loadLUE("teaching staff")
        End If
    End Sub

    Private Sub simpleButton1_Click(sender As Object, e As EventArgs) Handles simpleButton1.Click
        If String.IsNullOrEmpty(txtName.Text) Then
            ErrorProvider1.SetError(partnersLUE, "Please Select The Staff Member")
        Else
            If Not verify() Then
                Return
            End If

            If recordsAffected(txtName.Text) Then
                upDateRecord()
                loadGrid()
            Else
                insertRecord()
                loadGrid()
            End If
            txtPassword.Clear()
            txtUserName.Clear()
        End If
    End Sub

    Private Sub upDateRecord()
        If qwrite("UPDATE `system_users` SET `user_name`=md5('" + escape_string(txtUserName.Text) + "'), `password`= md5('" + txtPassword.Text + "') WHERE  `partner`='" + txtName.Text + "' and domain = md5('Examination');") Then
            success("The Operation Was Successful")
        End If
    End Sub

    Private Sub insertRecord()
        If qwrite("INSERT INTO `system_users` (`partner`, `user_name`, `password`, `domain`) VALUES ('" + escape_string(txtName.Text) + "', md5('" + txtUserName.Text + "'),  md5('" + txtPassword.Text + "'), md5('Examination'));") Then
            success("The Operation Was Successful")
        End If
    End Sub

    Private Function verify()
        ErrorProvider1.Clear()
        Dim veriified = False
        If String.IsNullOrEmpty(txtUserName.Text) Then
            ErrorProvider1.SetError(txtUserName, "The User Name Is Blank")
        ElseIf String.IsNullOrEmpty(txtPassword.Text)
            ErrorProvider1.SetError(txtPassword, "Please Enter The Password")
        Else
            veriified = True
        End If
        Return veriified
    End Function

    Private Sub clearItems()
        txtDepartment.Clear()
        txtName.Clear()
        txtPassword.Clear()
        txtUserName.Clear()
        partnersLUE.EditValue = Nothing
    End Sub

    Public Function recordsAffected(ByRef name As String)
        Dim veriified = False
        If qread("select id from system_users where partner = '" + name + "' and domain = md5('Examination');") Then
            If dbreader.RecordsAffected > 0 Then
                veriified = True
            End If
        End If
        Return veriified
    End Function

    Private Sub userGV_DoubleClick(sender As Object, e As EventArgs) Handles userGV.DoubleClick
        If userGV.SelectedRowsCount > 0 Then
            partnersLUE.EditValue = userGV.GetFocusedRowCellValue("Name").ToString()
            txtName.Text = userGV.GetFocusedRowCellValue("Name").ToString()
            txtDepartment.Text = userGV.GetFocusedRowCellValue("Department").ToString()
        End If
    End Sub

    Private Sub partnersLUE_EditValueChanged(sender As Object, e As EventArgs) Handles partnersLUE.EditValueChanged
        txtName.Text = partnersLUE.EditValue.ToString()
        txtDepartment.Text = partnersLUE.GetColumnValue("Department").ToString()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(txtName.Text) Then
            ErrorProvider1.SetError(txtName, "Please Double Click The Grid To Select The User")
        Else
            If confirm("Delete The Selected User ?") Then
                If (qwrite("delete from system_users where partner = '" + txtName.Text + "' and domain = md5('Examination')")) Then
                    success("The Operation Was Successful")
                    loadGrid()
                End If
            End If
        End If
    End Sub
End Class