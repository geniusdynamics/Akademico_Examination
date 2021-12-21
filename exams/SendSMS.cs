using global::System;
using global::System.Collections.Specialized;
using global::System.Net;
using global::System.Net.Security;
using global::System.Security.Cryptography.X509Certificates;
using global::System.Text;

namespace exams
{
    static class SendSMS
    {
        public static bool AcceptAllCertifications(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static void sendMsg(string phoneNo, string msgResult)
        {
            if (string.IsNullOrEmpty(phoneNo) | string.IsNullOrEmpty(msgResult))
            {
                return;
            }

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptAllCertifications);
                string url = "https://sms.movesms.co.ke/api/compose?";
                using (var wb = new WebClient())
                {
                    foreach (var phone in phoneNo.Split(new char[] { '-' }))
                    {
                        if (phone.Length == 13)
                        {
                            var data = new NameValueCollection();
                            data["username"] = My.MySettingsProperty.Settings.APIUserName;
                            data["api_key"] = My.MySettingsProperty.Settings.API;
                            data["sender"] = My.MySettingsProperty.Settings.Sender;
                            data["to"] = phone;
                            data["message"] = msgResult;
                            data["msgtype"] = "5";
                            data["dlr"] = "0";
                            var response = wb.UploadValues(url, "POST", data);
                            string responseString = Encoding.UTF8.GetString(response); // "Message Sent:1701"
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static string checkBalance()
        {
            string responseString = string.Empty;
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptAllCertifications);
                string url = "https://sms.movesms.co.ke/api/balance?";
                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["api_key"] = "DtQVOpaC2BhRYnoCijrpiQdNsCk0Mr0ISuGzoFcy71rk4w1dr5";
                    var response = wb.UploadValues(url, "POST", data);
                    responseString = Encoding.UTF8.GetString(response); // SMS Balance: 1"
                }
            }
            catch (Exception ex)
            {
                responseString = ex.Message;
            }

            return responseString;
        }
    }
}