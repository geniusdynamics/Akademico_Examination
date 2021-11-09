Imports System
Imports System.Text
Imports System.Net
Imports System.Net.Security
Imports System.Collections.Specialized
Imports System.Security.Cryptography.X509Certificates
Module SendSMS

    Public Function AcceptAllCertifications(
    sender As Object,
    certificate As X509Certificate,
    chain As X509Chain,
    sslPolicyErrors As SslPolicyErrors
) As Boolean

        Return True

    End Function

    Public Sub sendMsg(ByVal phoneNo As String, ByVal msgResult As String)

        If String.IsNullOrEmpty(phoneNo) Or String.IsNullOrEmpty(msgResult) Then
            Return
        End If

        Try

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Ssl3

            ServicePointManager.ServerCertificateValidationCallback =
      New RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)


            Dim url As String = "https://sms.movesms.co.ke/api/compose?"
            Using wb = New WebClient()
                Dim phone As String

                For Each phone In phoneNo.Split(New Char() {"-"c})
                    If phone.Length = 13 Then

                        Dim data = New NameValueCollection()
                        data("username") = My.Settings.APIUserName
                        data("api_key") = My.Settings.API
                        data("sender") = My.Settings.Sender
                        data("to") = phone
                        data("message") = msgResult
                        data("msgtype") = "5"
                        data("dlr") = "0"

                        Dim response = wb.UploadValues(url, "POST", data)
                        Dim responseString As String = Encoding.UTF8.GetString(response) '"Message Sent:1701"

                    End If
                Next

            End Using
        Catch ex As Exception

        End Try

    End Sub
    Public Function checkBalance() As String

        Dim responseString As String = String.Empty

        Try
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Ssl3

            ServicePointManager.ServerCertificateValidationCallback =
      New RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)

            Dim url As String = "https://sms.movesms.co.ke/api/balance?"
            Using wb = New WebClient()
                Dim data = New NameValueCollection()
                data("api_key") = "DtQVOpaC2BhRYnoCijrpiQdNsCk0Mr0ISuGzoFcy71rk4w1dr5"

                Dim response = wb.UploadValues(url, "POST", data)
                responseString = Encoding.UTF8.GetString(response) 'SMS Balance: 1"
            End Using

        Catch ex As Exception
            responseString = ex.Message
        End Try

        Return responseString

    End Function
End Module