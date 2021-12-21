Public Class frmPrompt

    Private Sub frmPrompt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            qread("SELECT stream FROM class_stream WHERE class='" & ret_name(class_form) & "'")
            While dbreader.Read
                cboStream.Items.Add(dbreader("stream"))
            End While
        End If
    End Sub
    Private Sub fill_stream(ByVal str As String)
        str.ToCharArray()
        Dim i, j As Integer
        j = 0
        Dim words() As String
        Dim in_word As Boolean = False
        For i = 0 To str.Length - 1
            If str(i) = "=" And in_word Then
                j += 1
                in_word = False
            ElseIf str(i) <> "=" And Not in_word Then
                in_word = True
            End If
        Next
        ReDim words(j - 1)
        j = 0
        in_word = False
        Dim temp As String = String.Empty
        For i = 0 To str.Length - 1
            If str(i) <> "=" Then
                If Not in_word Then
                    in_word = True
                End If
                temp += str(i)
            ElseIf str(i) = "=" Then
                If in_word Then
                    in_word = False
                    words(j) = temp
                    temp = String.Empty
                    j += 1
                End If
            ElseIf i = str.Length - 1 Then
                temp += str(i)
                words(j) = temp
            End If
        Next
        For i = 0 To words.Length - 1
            cboStream.Items.Add(words(i))
        Next
        cboStream.SelectedItem = None
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        to_continue = False
    End Sub

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        If cboStream.SelectedItem <> None And cboStream.SelectedItem <> String.Empty Then
            class_stream = cboStream.SelectedItem
            to_continue = True
            Me.Close()
        End If
    End Sub
End Class