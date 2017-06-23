Public Class frmConfigureModem

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If confirm("An sms will be sent to your phone and you'll be required to confirm once you receive it. Proceed?") Then
            configure()
        End If
    End Sub
    Dim SMSEngine
    Private Sub configure()
        trying = True
        For k As Integer = 1 To 30
            SMSEngine = New sms("COM" & k)
            If SMSEngine.isOpen() Then
                SMSEngine.SendSMS(txtPhone.Text, "Configuration Test Message")
                If confirm("Did you get a message?") Then
                    If qwrite("UPDATE sms SET port='COM" & k & "'") Then
                        success("Your SMS Configuration Was Successful!")
                        SMSEngine.Close()
                        Me.Close()
                    End If
                    Exit For
                End If
            End If
        Next
        trying = False
    End Sub
End Class