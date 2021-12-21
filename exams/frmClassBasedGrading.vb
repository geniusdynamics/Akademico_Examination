Public Class frmClassBasedGrading
    Private Sub frmClassBasedGrading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not connect() Then
            Close()
            Return
        End If

        fill_years(cboYear)
        load_class(cboClass)
    End Sub

    Private Sub cboClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClass.SelectedIndexChanged
        If cboClass.SelectedItem IsNot Nothing Then
            load_grade()
            dbreader.Close()
        End If
    End Sub

    Private Sub load_grade()
        'todo add foreign key reference for class in table grading and grading comments
        If qread("SELECT * FROM grading WHERE (Class='" & cboClass.SelectedItem & "' AND term='" & cboTerm.SelectedItem & "' AND year='" & cboYear.SelectedItem & "')") Then
            If dbreader.RecordsAffected > 0 Then
                dbreader.Read()
                txtAstart.Text = dbreader("A")
                txtAminstart.Text = dbreader("A-")
                txtBplusstart.Text = dbreader("B+")
                txtBstart.Text = dbreader("B")
                txtBminstart.Text = dbreader("B-")
                txtCplusstart.Text = dbreader("C+")
                txtCstart.Text = dbreader("C")
                txtCminstart.Text = dbreader("C-")
                txtDplusstart.Text = dbreader("D+")
                txtDstart.Text = dbreader("D")
                txtDminstart.Text = dbreader("D-")
                txtEstart.Text = dbreader("E")
                btnSave.Text = "Update"

                dbreader.Close()

                qread("SELECT * FROM grading_comments WHERE (Class='" & cboClass.SelectedItem & "' AND term='" & cboTerm.SelectedItem & "' AND year='" & cboYear.SelectedItem & "')")
                dbreader.Read()
                txtAComment.Text = dbreader("A")
                txtAMinusComment.Text = dbreader("A-")
                txtBPlusComment.Text = dbreader("B+")
                txtBComment.Text = dbreader("B")
                txtBMinusComment.Text = dbreader("B-")
                txtCPlusComment.Text = dbreader("C+")
                txtCComment.Text = dbreader("C")
                txtCMinusComment.Text = dbreader("C-")
                txtDPlusComment.Text = dbreader("D+")
                txtDComment.Text = dbreader("D")
                txtDMinusComment.Text = dbreader("D-")
                txtEComment.Text = dbreader("E")
                btnSave.Text = "Update"
                dbreader.Close()
            Else
                btnSave.Text = "Save"

            End If
        Else
            failure("Could Not Read Grading Scheme!")
        End If
    End Sub
    Private Sub clear()
        txtAstart.Clear()
        txtAminstart.Clear()
        txtBplusstart.Clear()
        txtBstart.Clear()
        txtBminstart.Clear()
        txtCplusstart.Clear()
        txtCstart.Clear()
        txtCminstart.Clear()
        txtDplusstart.Clear()
        txtDstart.Clear()
        txtDminstart.Clear()
        txtEstart.Clear()
        txtAComment.Clear()
        txtBComment.Clear()
        txtAMinusComment.Clear()
        txtBPlusComment.Clear()
        txtBMinusComment.Clear()
        txtCPlusComment.Clear()
        txtCComment.Clear()
        txtCMinusComment.Clear()
        txtDPlusComment.Clear()
        txtDComment.Clear()
        txtDMinusComment.Clear()
        txtEComment.Clear()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not isvalid() Then
            Return
        End If

        start()
        If btnSave.Text = "Update" Then
            If qwrite("UPDATE grading SET `A`='" & Trim(txtAstart.Text).ToUpper &
       "', `A-`='" & Trim(txtAminstart.Text).ToUpper & "',`B+`='" & Trim(txtBplusstart.Text) & "',`B`='" & Trim(txtBstart.Text).ToUpper & "',`B-`='" &
       Trim(txtBminstart.Text).ToUpper & "',`C+`='" & Trim(txtCplusstart.Text).ToUpper & "',`C`='" & Trim(txtCstart.Text).ToUpper & "',`C-`='" &
       Trim(txtCminstart.Text).ToUpper & "',`D+`='" & Trim(txtDplusstart.Text).ToUpper & "',`D`='" & Trim(txtDstart.Text).ToUpper & "',`D-`='" &
       Trim(txtDminstart.Text).ToUpper & "',`E`='" & Trim(txtEstart.Text).ToUpper & "' WHERE (Class='" & cboClass.SelectedItem &
       "' AND term='" & cboTerm.SelectedItem & "' AND year='" & cboYear.SelectedItem & "')") And qwrite("UPDATE grading_comments SET `A`='" & escape_string(txtAMinusComment.Text) &
       "', `A-`='" & escape_string(txtAMinusComment.Text) & "',`B+`='" & escape_string(txtBPlusComment.Text) & "',`B`='" & escape_string(txtBComment.Text) & "',`B-`='" &
       escape_string(txtBMinusComment.Text) & "',`C+`='" & escape_string(txtCPlusComment.Text) & "',`C`='" & escape_string(txtCComment.Text) & "',`C-`='" &
       escape_string(txtCMinusComment.Text) & "',`D+`='" & escape_string(txtDPlusComment.Text) & "',`D`='" & escape_string(txtDComment.Text) & "',`D-`='" &
       escape_string(txtDMinusComment.Text) & "',`E`='" & escape_string(txtEComment.Text) & "' WHERE (Class='" & cboClass.SelectedItem & "' AND term='" & cboTerm.SelectedItem & "' AND year='" & cboYear.SelectedItem & "')") Then

                commit()
                success("Grading Scheme Successfully Updated!")
            Else
                rollback()
                failure("Grading Scheme Update Failed!")
            End If

        Else

            If qwrite("INSERT INTO grading VALUES(NULL, '" & cboClass.SelectedItem & "', '" & Trim(txtAstart.Text) &
        "', '" & Trim(txtAminstart.Text) & "','" & Trim(txtBplusstart.Text) & "','" & Trim(txtBstart.Text) & "','" &
        Trim(txtBminstart.Text) & "','" & Trim(txtCplusstart.Text) & "','" & Trim(txtCstart.Text) & "','" &
        Trim(txtCminstart.Text) & "','" & Trim(txtDplusstart.Text) & "','" & Trim(txtDstart.Text) & "','" &
        Trim(txtDminstart.Text) & "','" & Trim(txtEstart.Text) &
        "', '" & cboYear.SelectedItem & "', '" & cboTerm.SelectedItem & "')") And qwrite("INSERT INTO grading_comments VALUES(NULL, '" & cboClass.SelectedItem & "','" & escape_string(txtAComment.Text) &
        "', '" & escape_string(txtAMinusComment.Text) & "','" & escape_string(txtBPlusComment.Text) & "','" & escape_string(txtBComment.Text) & "','" &
        escape_string(txtBMinusComment.Text) & "','" & escape_string(txtCPlusComment.Text) & "','" & escape_string(txtCComment.Text) & "','" &
        escape_string(txtCMinusComment.Text) & "','" & escape_string(txtDPlusComment.Text) & "','" & escape_string(txtDComment.Text) & "','" &
        escape_string(txtDMinusComment.Text) & "','" & escape_string(txtEComment.Text) & "', '" & cboYear.SelectedItem & "', '" & cboTerm.SelectedItem & "')") Then

                commit()
                success("Grading Scheme Successfully Saved!")
            Else
                rollback()
                failure("Grading Scheme Saving Failed! Duplicate Entry For Class!")
            End If

        End If

        clear()
        cboClass.SelectedItem = "None"
    End Sub


    Dim msg As String = String.Empty

    Private Function isvalid()
        If cboClass.SelectedItem = "None" Then
            msg = "No Class Selected!"
            failure(msg)
            Return False
        End If
        If IsNumeric(Trim(txtAstart.Text)) Then
            If CInt(txtAstart.Text) > 100 Or CInt(Trim(txtAstart.Text)) < 0 Then
                msg = "Invalid Value For Grade A Minimum!"
                failure(msg)
                Return False
            End If
        Else
            msg = "Invalid Value For Grade A!"
            Return False
        End If
        If IsNumeric(Trim(txtAminstart.Text)) Then
            If CInt(Trim(txtAminstart.Text)) >= CInt(Trim(txtAstart.Text)) Or CInt(Trim(txtAminstart.Text)) < 0 Then
                msg = "Grade A- Cannot Be Greater Than Grade A Or Less Than 0"
                failure(msg)
                Return False
            End If
        Else
            msg = "Invalid Value For Grade A-!"
            failure(msg)
            Return False
        End If
        If IsNumeric(Trim(txtBplusstart.Text)) Then
            If CInt(Trim(txtBplusstart.Text)) >= CInt(Trim(txtAminstart.Text)) Or CInt(Trim(txtBplusstart.Text)) < 0 Then
                msg = "Grade B+ Cannot Be Greater Than Grade A- Or Less Than 0"
                failure(msg)
                Return False
            End If
        Else

            msg = "Invalid Value For Grade B+!"
            failure(msg)
            Return False
        End If
        If IsNumeric(Trim(txtBstart.Text)) Then
            If CInt(Trim(txtBstart.Text)) >= CInt(Trim(txtBplusstart.Text)) Or CInt(Trim(txtBstart.Text)) < 0 Then
                msg = "Grade B Cannot Be Greater Than Grade B+ Or Less Than 0"
                failure(msg)
                Return False
            End If
        Else
            msg = "Invalid Value For Grade B!"
            Return False
        End If
        If IsNumeric(Trim(txtBminstart.Text)) Then
            If CInt(Trim(txtBminstart.Text)) >= CInt(Trim(txtBstart.Text)) Or CInt(Trim(txtBminstart.Text)) < 0 Then
                msg = "Grade B- Cannot Be Greater Than Grade B Or Less Than 0"
                Return False
            End If
        Else
            msg = "Invalid Value For Grade B-!"
            Return False
        End If
        If IsNumeric(Trim(txtCplusstart.Text)) Then
            If CInt(Trim(txtCplusstart.Text)) >= CInt(Trim(txtBstart.Text)) Or CInt(Trim(txtCplusstart.Text)) < 0 Then
                msg = "Grade C+ Cannot Be Greater Than Grade B- Or Less Than 0"
                Return False
            End If
        Else
            msg = "Invalid Value For Grade C+!"
            failure(msg)
            Return False
        End If
        If IsNumeric(Trim(txtCstart.Text)) Then
            If CInt(Trim(txtCstart.Text)) >= CInt(Trim(txtCplusstart.Text)) Or CInt(Trim(txtCstart.Text)) < 0 Then
                msg = "Grade C Cannot Be Greater Than Grade C+ Or Less Than 0"
                failure(msg)
                Return False
            End If
        Else
            msg = "Invalid Value For Grade C!"
            failure(msg)
            Return False
        End If
        If IsNumeric(Trim(txtCminstart.Text)) Then
            If CInt(Trim(txtCminstart.Text)) >= CInt(Trim(txtCstart.Text)) Or CInt(Trim(txtCminstart.Text)) < 0 Then
                msg = "Grade C- Cannot Be Greater Than Grade C Or Less Than 0"
                failure(msg)
                Return False
            End If
        Else
            msg = "Invalid Value For Grade C-!"
            failure(msg)
            Return False
        End If
        If IsNumeric(Trim(txtDplusstart.Text)) Then
            If CInt(Trim(txtDplusstart.Text)) >= CInt(Trim(txtCminstart.Text)) Or CInt(Trim(txtDplusstart.Text)) < 0 Then
                msg = "Grade D+ Cannot Be Greater Than Grade C- Or Less Than 0"
                failure(msg)
                Return False
            End If
        Else
            msg = "Invalid Value For Grade D+!"
            failure(msg)
            Return False
        End If
        If IsNumeric(Trim(txtDstart.Text)) Then
            If CInt(Trim(txtDstart.Text)) >= CInt(Trim(txtDplusstart.Text)) Or CInt(Trim(txtDstart.Text)) < 0 Then
                msg = "Grade D Cannot Be Greater Than Grade D+ Or Less Than 0"
                failure(msg)
                Return False
            End If
        Else
            msg = "Invalid Value For Grade D!"
            failure(msg)
            Return False
        End If
        If IsNumeric(Trim(txtDminstart.Text)) Then
            If CInt(Trim(txtDminstart.Text)) >= CInt(Trim(txtDstart.Text)) Or CInt(Trim(txtDminstart.Text)) < 0 Then
                msg = "Grade D- Cannot Be Greater Than Grade D Or Less Than 0"
                failure(msg)
                Return False
            End If
        Else
            msg = "Invalid Value For Grade D-!"
            failure(msg)
            Return False
        End If
        If IsNumeric(Trim(txtEstart.Text)) Then
            If CInt(Trim(txtEstart.Text)) > CInt(Trim(txtDminstart.Text)) Or CInt(Trim(txtEstart.Text)) < 0 Then
                msg = "Grade E Cannot Be Greater Than Grade D- Or Less Than 0"
                Return False
            End If
        Else
            msg = "Invalid Value For Grade E!"
            failure(msg)
            Return False
        End If
        If Trim(txtAComment.Text) = String.Empty Then
            msg = "No Comment For Grade A!"
            failure(msg)
            Return False
        ElseIf Trim(txtAMinusComment.Text) = String.Empty Then
            msg = "No Comment For Grade A-!"
            failure(msg)
            Return False
        ElseIf Trim(txtBPlusComment.Text) = String.Empty Then
            msg = "No Comment For Grade B+!"
            failure(msg)
            Return False
        ElseIf Trim(txtBComment.Text) = String.Empty Then
            msg = "No Comment For Grade B!"
            failure(msg)
            Return False
        ElseIf Trim(txtBMinusComment.Text) = String.Empty Then
            msg = "No Comment For Grade B-!"
            failure(msg)
            Return False
        ElseIf Trim(txtCPlusComment.Text) = String.Empty Then
            msg = "No Comment For Grade C+!"
            failure(msg)
            Return False
        ElseIf Trim(txtCComment.Text) = String.Empty Then
            msg = "No Comment For Grade C!"
            failure(msg)
            Return False
        ElseIf Trim(txtCMinusComment.Text) = String.Empty Then
            msg = "No Comment For Grade C-!"
            failure(msg)
            Return False
        ElseIf Trim(txtDPlusComment.Text) = String.Empty Then
            msg = "No Comment For Grade D+!"
            failure(msg)
            Return False
        ElseIf Trim(txtDComment.Text) = String.Empty Then
            msg = "No Comment For Grade D!"
            failure(msg)
            Return False
        ElseIf Trim(txtDMinusComment.Text) = String.Empty Then
            msg = "No Comment For Grade D-!"
            failure(msg)
            Return False
        ElseIf Trim(txtEComment.Text) = String.Empty Then
            msg = "No Comment For Grade E!"
            failure(msg)
            Return False
        End If
        Return True
    End Function
End Class