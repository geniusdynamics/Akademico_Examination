using global::System;
using global::System.IO.Ports;
using global::System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public class sms
    {
        private SerialPort SMSPort;
        private Thread SMSThread;
        private Thread ReadThread;
        private static bool _Continue = false;
        private static bool _ContSMS = false;
        private bool _Wait = false;
        private static bool _ReadPort = false;

        public event sendingEventHandler sending;

        public delegate void sendingEventHandler(bool done);

        public event DataReceivedEventHandler DataReceived;

        public delegate void DataReceivedEventHandler(string message);

        public sms(ref string COMMPORT)
        {
            SMSPort = new SerialPort();
            {
                var withBlock = SMSPort;
                withBlock.PortName = COMMPORT;
                withBlock.BaudRate = 9600;
                withBlock.Parity = Parity.None;
                withBlock.DataBits = 8;
                withBlock.StopBits = StopBits.One;
                withBlock.Handshake = Handshake.RequestToSend;
                withBlock.DtrEnable = true;
                withBlock.RtsEnable = true;
                withBlock.NewLine = Constants.vbCrLf;
            }

            try
            {
                SMSPort.Open();
            }
            catch (Exception ex)
            {
                publicSubsNFunctions.failure("Could Not Initialize Your GSM Modem For SMS Sending! Please Ensure It Is Connected And Correctly Configured!");
                return;
            }

            string cmd;
            publicSubsNFunctions.wait("Initializing  Modem...");
            if (SMSPort.IsOpen)
            {
                cmd = "AT";
                SMSPort.WriteLine(cmd);
                cmd = "AT+CNMI=1,2,0,0,0";
                SMSPort.WriteLine(cmd);
                // set command message format to text mode(1)
                cmd = "AT+CMGF=1";
                SMSPort.WriteLine(cmd);
                // set service center address (which varies for service providers (idea, airtel))
                cmd = "AT+CSCA=\"" + publicSubsNFunctions.SMS_Center + "\"";
                SMSPort.WriteLine(cmd);
            }
        }

        public bool SendSMS(string cellNo, string SMSMessage)
        {
            cellNo = Conversions.ToString(publicSubsNFunctions.format_no(cellNo));
            bool long_sms = false;
            int smsno_test = (int)Math.Round(SMSMessage.Length / 160d);
            double smsno = SMSMessage.Length / 160d;
            if (smsno > smsno_test)
            {
                smsno = smsno_test + 1;
            }
            else
            {
                smsno = (int)Math.Round(smsno);
            }

            string MyMessage = null;
            if (SMSMessage.Length > 160)
            {
                long_sms = true;
            }

            string cmd;
            if (SMSPort.IsOpen)
            {
                if (long_sms)
                {
                    for (int k = 0, loopTo = (int)Math.Round(smsno - 1d); k <= loopTo; k++)
                    {
                        cmd = "AT+CMGS=\"" + cellNo + "\"";
                        SMSPort.WriteLine(cmd);
                        if (k == smsno - 1d)
                        {
                            cmd = SMSMessage.Substring(k * 160);
                        }
                        else
                        {
                            cmd = SMSMessage.Substring(k * 160, 160);
                        }

                        SMSPort.WriteLine(cmd);
                        SMSPort.WriteLine(Conversions.ToString('\u001a')); // SMS sending
                        publicSubsNFunctions.wait_slow("Sending SMS to " + cellNo);
                    }
                }
                else
                {
                    cmd = "AT";
                    SMSPort.WriteLine(cmd);
                    cmd = "AT+CMGS=\"" + cellNo + "\"";
                    SMSPort.WriteLine(cmd);
                    SMSPort.WriteLine(SMSMessage);
                    SMSPort.WriteLine(Conversions.ToString('\u001a')); // SMS sending
                    publicSubsNFunctions.wait_slow("Sending SMS to " + cellNo);
                }
            }

            return default;
        }

        private string no;

        private void ReadPort()
        {
            string SerialIn = null;
            var RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
            string SMSMessage = null;
            int Strpos = 0;
            string TmpStr = null;
            while (SMSPort.IsOpen)
            {
                if (SMSPort.BytesToRead != 0 & SMSPort.IsOpen)
                {
                    while (SMSPort.BytesToRead != 0)
                    {
                        SMSPort.Read(RXBuffer, 0, SMSPort.ReadBufferSize);
                        SerialIn = SerialIn + System.Text.Encoding.ASCII.GetString(RXBuffer);
                        if (SerialIn.Contains(">"))
                        {
                            _ContSMS = true;
                        }

                        if (SerialIn.Contains("+CMGS:"))
                        {
                            _Continue = true;
                            sending?.Invoke(true);
                            _Wait = false;
                            SerialIn = string.Empty;
                            RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
                        }
                    }

                    DataReceived?.Invoke(SerialIn);
                    SerialIn = string.Empty;
                    RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
                }
            }
        }

        public bool IsOpen
        {
            get
            {
                bool IsOpenRet = default;
                if (SMSPort.IsOpen)
                {
                    IsOpenRet = true;
                }
                else
                {
                    IsOpenRet = false;
                }

                return IsOpenRet;
            }
        }

        public void Open()
        {
            if (!IsOpen)
            {
                SMSPort.Open();
            }
        }

        public void Close()
        {
            if (IsOpen)
            {
                SMSPort.Close();
            }
        }
    }
}