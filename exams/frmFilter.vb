Public Class frmFilter

    Private Sub frmFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    End Sub

    Private Sub frmFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        radNone.Checked = True
        radBottom.Checked = False
        radTop.Checked = False
    End Sub

    Private Sub txtNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If (Not IsNumeric(txtNumber.Text) And radNone.Checked) Or IsNumeric(txtNumber.Text) And (radBottom.Checked Or radTop.Checked) Then
                radF = radTop.Checked
                radL = radBottom.Checked
                Try
                    rankno = txtNumber.Text
                Catch ex As Exception

                End Try
                Me.Close()
            Else
                failure("Invalid Value For Number Of Students To Filter Considering Your Choice!")
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not (IsNumeric(txtNumber.Text) And radNone.Checked) Or IsNumeric(txtNumber.Text) And (radBottom.Checked Or radTop.Checked) Then
            radF = radTop.Checked
            radL = radBottom.Checked
            Try
                rankno = txtNumber.Text
            Catch ex As Exception

            End Try
            cont = True
            Me.Close()
        Else
            failure("Invalid Value For Number Of Students To Filter Considering Your Choice!")
        End If
    End Sub
End Class