Option Explicit On
Imports System
Imports System.IO.Ports
Imports System.Threading
Public Class sms
    Private WithEvents SMSPort As SerialPort
    Private SMSThread As Thread
    Private ReadThread As Thread
    Shared _Continue As Boolean = False
    Shared _ContSMS As Boolean = False
    Private _Wait As Boolean = False
    Shared _ReadPort As Boolean = False
    Public Event sending(ByVal done As Boolean)
    Public Event DataReceived(ByVal message As String)
    Public Sub New(ByRef COMMPORT As String)
        SMSPort = New SerialPort
        With SMSPort
            .PortName = COMMPORT
            .BaudRate = 9600
            .Parity = Parity.None
            .DataBits = 8
            .StopBits = StopBits.One
            .Handshake = Handshake.RequestToSend
            .DtrEnable = True
            .RtsEnable = True
            .NewLine = vbCrLf
        End With
        Try
            SMSPort.Open()
        Catch ex As Exception
            failure("Could Not Initialize Your GSM Modem For SMS Sending! Please Ensure It Is Connected And Correctly Configured!")
            Exit Sub
        End Try
        Dim cmd As String
        wait("Initializing  Modem...")
        If SMSPort.IsOpen Then
            cmd = "AT"
            SMSPort.WriteLine(cmd)
            cmd = "AT+CNMI=1,2,0,0,0"
            SMSPort.WriteLine(cmd)
            'set command message format to text mode(1)
            cmd = "AT+CMGF=1"
            SMSPort.WriteLine(cmd)
            'set service center address (which varies for service providers (idea, airtel))
            cmd = "AT+CSCA=""" & SMS_Center & """"
            SMSPort.WriteLine(cmd)
        End If
    End Sub
    Public Function SendSMS(ByVal cellNo As String, ByVal SMSMessage As String) As Boolean
        cellNo = format_no(cellNo)
        Dim long_sms As Boolean = False
        Dim smsno_test As Integer = CInt(SMSMessage.Length / 160)
        Dim smsno As Double = SMSMessage.Length / 160
        If smsno > smsno_test Then
            smsno = smsno_test + 1
        Else
            smsno = CInt(smsno)
        End If
        Dim MyMessage As String = Nothing
        If SMSMessage.Length > 160 Then
            long_sms = True
        End If
        Dim cmd As String
        If SMSPort.IsOpen Then
            If long_sms Then
                For k As Integer = 0 To smsno - 1
                    cmd = "AT+CMGS=""" & cellNo & """"
                    SMSPort.WriteLine(cmd)
                    If k = smsno - 1 Then
                        cmd = SMSMessage.Substring(k * 160)
                    Else
                        cmd = SMSMessage.Substring(k * 160, 160)
                    End If
                    SMSPort.WriteLine(cmd)
                    SMSPort.WriteLine(Chr(26)) 'SMS sending
                    wait_slow("Sending SMS to " & cellNo)
                Next
            Else
                cmd = "AT"
                SMSPort.WriteLine(cmd)
                cmd = "AT+CMGS=""" & cellNo & """"
                SMSPort.WriteLine(cmd)
                SMSPort.WriteLine(SMSMessage)
                SMSPort.WriteLine(Chr(26)) 'SMS sending
                wait_slow("Sending SMS to " & cellNo)
            End If
        End If
    End Function
    Dim no As String
    Private Sub ReadPort()
        Dim SerialIn As String = Nothing
        Dim RXBuffer(SMSPort.ReadBufferSize) As Byte
        Dim SMSMessage As String = Nothing
        Dim Strpos As Integer = 0
        Dim TmpStr As String = Nothing
        While SMSPort.IsOpen
            If (SMSPort.BytesToRead <> 0) And SMSPort.IsOpen Then
                While SMSPort.BytesToRead <> 0
                    SMSPort.Read(RXBuffer, 0, SMSPort.ReadBufferSize)
                    SerialIn = SerialIn & System.Text.Encoding.ASCII.GetString(RXBuffer)
                    If SerialIn.Contains(">") Then
                        _ContSMS = True
                    End If
                    If SerialIn.Contains("+CMGS:") Then
                        _Continue = True
                        RaiseEvent sending(True)
                        _Wait = False
                        SerialIn = String.Empty
                        ReDim RXBuffer(SMSPort.ReadBufferSize)
                    End If
                End While
                RaiseEvent DataReceived(SerialIn)
                SerialIn = String.Empty
                ReDim RXBuffer(SMSPort.ReadBufferSize)
            End If
        End While
    End Sub
    Public ReadOnly Property IsOpen() As Boolean
        Get
            If SMSPort.IsOpen Then
                IsOpen = True
            Else
                IsOpen = False
            End If
        End Get
    End Property
    Public Sub Open()
        If Not IsOpen Then
            SMSPort.Open()
        End If
    End Sub
    Public Sub Close()
        If IsOpen Then
            SMSPort.Close()
        End If
    End Sub

End Class
