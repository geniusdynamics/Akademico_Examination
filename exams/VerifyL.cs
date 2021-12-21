using System;
using System.Collections.Generic;
using System.Data;
using global::System.IO;
using global::System.Linq;
using global::System.Security.Cryptography;
using global::System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using global::Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public class VerifyL
    {
        private static bool verified = false;
        public static Random rnd = new Random();
        public static DateTime licenseExpiration;

        public static bool verifyTime()
        {
            verified = false;
            getExpirationDate();
            if (DateTime.Now > licenseExpiration)
            {
                MessageBox.Show("Please Call Your Software Vendor For An Updated Version" + Environment.NewLine + "THIS COPY IS UNLICENCED CALL 0733 911 638 OR 0723 836 205");
                Application.Exit();
                verified = true;
            }

            return verified;
        }

        public static bool verifyTimeStamp()
        {
            bool verified = false;
            if (getExpirationDate() == false)
            {
                return InlineAssignHelper(ref verified, true);
            }

            var queries = new[] { "select year from examined_classes where year > '" + licenseExpiration.ToString("yyyy-MM-dd") + "';" };
            foreach (string s in queries)
            {
                if (publicSubsNFunctions.qread(ref s))
                {
                    if (publicSubsNFunctions.dbreader.RecordsAffected > 15)
                    {
                        publicSubsNFunctions.dbreader.Read();
                        MessageBox.Show("Please Call Your Software Vendor For An Updated Version" + Environment.NewLine + "THIS COPY IS UNLICENCED CALL 0733 911 638 OR 0723 836 205");
                        verified = true;
                        return verified;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return verified;
        }

        public static string getSchoolDetails()
        {
            string details = string.Empty;
            details = getStringRecord(Convert.ToString("select school_name from license where module = '") + Encrypt("AKADEMICO_EXAMINATION") + "' order by id desc limit 1");
            if (!string.IsNullOrEmpty(details))
            {
                details = Decrypt(details);
            }

            return details;
        }

        public static string getStringRecord(string query)
        {
            string record = string.Empty;
            if (publicSubsNFunctions.qread(ref query))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    publicSubsNFunctions.dbreader.Read();
                    record = publicSubsNFunctions.dbreader.GetString(0);
                }
                else
                {
                    record = string.Empty;
                }
            }

            return record;
        }

        public static bool getExpirationDate()
        {
            bool valid = false;
            string dateTime = getStringRecord(Convert.ToString("select time_stamp from license where module = '") + Encrypt("AKADEMICO_EXAMINATION") + "' order by id desc limit 1");
            if (string.IsNullOrEmpty(dateTime))
            {
                MessageBox.Show("Please License Your Copy Of Akademico Or Register For A Trial Version");
                valid = false;
            }
            else
            {
                dateTime = Decrypt(dateTime);
                dateTime = formatDateTime(dateTime);
                var dates = dateTime.Split('-');
                var licenseDate = new DateTime(int.Parse(dates[1]), int.Parse(dates[2]), int.Parse(dates[0]));
                var expiryDate = licenseDate.AddMonths(int.Parse(dates[3]));
                licenseExpiration = expiryDate;
                valid = true;
            }

            return valid;
        }

        // Public Shared Function viaDB() As Boolean
        // verified = False
        // Dim lDate As New DateTime(2017, 8, 20)
        // Dim queries As String() = {"select transaction_date from detailed_transaction where transaction_date > '" + lDate.ToString("yyyy-MM-dd") + "';", "select issue_date from log_lib_register where issue_date > '" + lDate.ToString("yyyy-MM-dd") + "';", "select year from exam_results where year > '" + lDate.ToString("yyyy") + "';", "select date from inventory where date > '" + lDate.ToString("yyyy-MM-dd") + "';"}

        // For Each s As String In queries
        // Dim myReader As OdbcDataReader = CommonFunctions.dbRead(s)
        // If myReader IsNot Nothing Then
        // If myReader.RecordsAffected > 15 Then
        // MessageBox.Show("Please Call Your Software Vendor For An Updated Version" + Environment.NewLine + "THIS COPY IS UNLICENCED CALL 0733 911 638 OR 0723 836 205")
        // verified = True
        // Return verified
        // End If
        // End If
        // Next
        // Return verified
        // End Function

        public static void formatDate(ref DateTimePicker myPicker)
        {
            if (getExpirationDate() == true)
            {
                myPicker.MaxDate = new DateTime(licenseExpiration.Year, licenseExpiration.Month, licenseExpiration.Day);
            }
            else
            {
                myPicker.MaxDate = new DateTime(2012, 1, 1);
            }
        }

        public static string genGuid()
        {
            var guid__1 = Guid.NewGuid();
            return guid__1.ToString();
        }

        public static string generateLicenseCode(string licenseTime)
        {
            string licensePeriod = licenseTime;
            var guidTest = genGuid().ToCharArray();
            string guid1 = string.Join(string.Empty, Conversions.ToString(guidTest));
            var guid = guidTest;
            int intTotal = countInt(guidTest);
            if (intTotal < 23)
            {
                guid = addInt(guidTest, 23 - intTotal);
            }

            string unsuffled = DateTime.Now.Ticks.ToString() + DateTime.Now.Millisecond.ToString();
            string shuffled = new string(unsuffled.OrderBy(r => rnd.Next()).ToArray());
            var ticks = shuffled.ToCharArray();
            var now = (Convert.ToString(Convert.ToString(formatString(DateTime.Now.Day.ToString()) + DateTime.Now.Year.ToString()) + formatString(DateTime.Now.Month.ToString())) + formatString(licensePeriod)).ToCharArray();
            string ticks1 = string.Join(string.Empty, Conversions.ToString(ticks));
            string now1 = string.Join(string.Empty, Conversions.ToString(now));
            int counter = 0;
            int result;
            string value = string.Empty;
            for (int k = 2, loopTo = ticks.Length - 1; k <= loopTo; k++)
            {
                if (k % 2 == 0)
                {
                    if (counter < now.Length)
                    {
                        ticks[k] = now[counter];
                        counter += 1;
                    }
                    else if (counter > now.Length)
                    {
                        break;
                    }
                }
            }

            ticks1 = string.Join(string.Empty, Conversions.ToString(ticks));
            counter = 0;
            for (int k = 0, loopTo1 = guid.Length - 1; k <= loopTo1; k++)
            {
                value = guid[k].ToString();
                if (int.TryParse(value, out result))
                {
                    if (counter < ticks.Length)
                    {
                        guid[k] = ticks[counter];
                        counter += 1;
                    }
                    else if (counter > ticks.Length)
                    {
                        break;
                    }
                }
            }

            guid1 = string.Join(string.Empty, Conversions.ToString(guid)).ToUpper();
            return guid1;
        }

        public static string formatString(string item)
        {
            string formatted = string.Empty;
            if (item.Length == 1)
            {
                formatted = Convert.ToString("0") + item;
            }
            else
            {
                formatted = item;
            }

            return formatted;
        }

        public static int countInt(char[] guid)
        {
            int counter = 0;
            int value = 0;
            for (int k = 0, loopTo = guid.Length - 1; k <= loopTo; k++)
            {
                if (int.TryParse(guid[k].ToString(), out value))
                {
                    counter += 1;
                }
            }

            return counter;
        }

        public static char[] addInt(char[] guid, int difference)
        {
            var rnd = new Random();
            string value = string.Empty;
            int outt = 0;
            int counter = 0;
            for (int k = guid.Length - 1; k >= 0; k -= 1)
            {
                if (!int.TryParse(guid[k].ToString(), out outt))
                {
                    if (counter < difference)
                    {
                        value += Conversions.ToString(char.Parse(rnd.Next(9).ToString()));
                        counter += 1;
                    }
                    else
                    {
                        value += Conversions.ToString(guid[k]);
                    }
                }
                else
                {
                    value += Conversions.ToString(guid[k]);
                }
            }

            return value.ToCharArray();
        }

        public static string formatDateTime(string dateTime)
        {
            string value = string.Empty;
            value = dateTime.Insert(2, "-").Insert(7, "-").Insert(10, "-");
            return value;
        }

        public static string extractValues(string key)
        {
            int result = 0;
            string value = string.Empty;
            string ans = string.Empty;
            foreach (char c in key.ToCharArray())
            {
                if (int.TryParse(c.ToString(), out result))
                {
                    value += c.ToString();
                }
            }

            for (int k = 2, loopTo = value.Length - 1; k <= loopTo; k++)
            {
                if (ans.Length > 9)
                {
                    break;
                }

                if (k % 2 == 0)
                {
                    ans += Conversions.ToString(value[k]);
                }
            }

            return ans;
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "%^&$#*1234Abcdef";
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }

            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                string EncryptionKey = "%^&$#*1234Abcdef";
                cipherText = cipherText.Replace(" ", "+");
                var cipherBytes = Convert.FromBase64String(cipherText);
                using (var encryptor = Aes.Create())
                {
                    var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }

                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("THE LICENSE FILE HAS BEEN MODIFIED" + Environment.NewLine + "Please Call 0733 911 638 or 0723 836 205 For Assistance");
                cipherText = string.Empty;
            }

            return cipherText;
        }

        public static object key_code(string name, string module_, string licence)
        {
            string key_string = name + module_.ToUpper() + licence;
            return FormatKeyCode(ToBase32(Enumerable.Range(0, md5_this(key_string).Length / 2).Select(x => Conversions.ToByte("&H" + md5_this(key_string).Substring(x * 2, 2))).ToArray()), 4L);
        }

        public static void AddTimeStamp()
        {
            var tables = new[] { "examined_classes", "detailed_transaction", "log_lib_register", "inventory", "students" };
            foreach (string s in tables)
            {
                if (!ifExists(Convert.ToString("SHOW COLUMNS FROM " + My.MySettingsProperty.Settings.dbName + ".") + s + " LIKE 'time_stamp';"))
                {
                    if (publicSubsNFunctions.qwrite(Convert.ToString("ALTER TABLE `") + s + "` ADD `time_stamp` TIMESTAMP ON UPDATE CURRENT_TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ;"))
                    {
                    }
                }
            }
        }

        public static void addLicenseTable()
        {
            if (!ifExists("SELECT * FROM information_schema.TABLES WHERE (TABLE_SCHEMA = '" + My.MySettingsProperty.Settings.dbName + "') AND (TABLE_NAME = 'license');"))
            {
                string licenseTable = "CREATE TABLE IF NOT EXISTS `license` (`id` bigint(255) NOT NULL AUTO_INCREMENT, `school_name` varchar(255) NOT NULL DEFAULT '--', `module` varchar(255) NOT NULL DEFAULT '--', `license` varchar(255) NOT NULL DEFAULT '--', `time_stamp` varchar(255) NOT NULL DEFAULT '--', PRIMARY KEY (`id`)) ENGINE=InnoDB DEFAULT CHARSET=latin1;";
                if (publicSubsNFunctions.qwrite(licenseTable))
                {
                }
            }
        }

        public static bool ifExists(object query)
        {
            string argq = Conversions.ToString(query);
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    publicSubsNFunctions.dbreader.Read();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return default;
        }

        public static string md5_this(string Source)
        {
            var sb = new StringBuilder();
            bool flag = string.IsNullOrEmpty(Source);
            if (flag)
            {
                throw new ArgumentNullException();
            }

            var Bytes = Encoding.Default.GetBytes(Source);
            Bytes = MD5.Create().ComputeHash(Bytes);
            int arg_3A_0 = 0;
            int num = Bytes.Length - 1;
            int x = arg_3A_0;
            while (true)
            {
                int arg_61_0 = x;
                int num2 = num;
                if (arg_61_0 > num2)
                {
                    break;
                }

                sb.Append(Bytes[x].ToString("x2"));
                x += 1;
            }

            return sb.ToString();
        }

        public static string ToBase32(byte[] Data, bool IncludePadding = true)
        {
            string RetVal = string.Empty;
            var Segments = new List<long>();
            int Index = 0;
            while (Index < Data.Length)
            {
                long CurrentSegment = 0L;
                int SegmentSize = 0;
                while (Index < Data.Length & SegmentSize < 5)
                {
                    CurrentSegment = CurrentSegment << 8;
                    CurrentSegment += (long)(ulong)Data[Index];
                    Index += 1;
                    SegmentSize += 1;
                }

                CurrentSegment = CurrentSegment << 8 * (5 - SegmentSize);
                Segments.Add(CurrentSegment);
            }

            try
            {
                var enumerator = Segments.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    long CurrentSegment2 = enumerator.Current;
                    int x = 0;
                    int arg_B6_0;
                    int num;
                    do
                    {
                        RetVal += Conversions.ToString("ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"[(int)(CurrentSegment2 >> (7 - x) * 5 & 31L)]);
                        x += 1;
                        arg_B6_0 = x;
                        num = 7;
                    }
                    while (arg_B6_0 <= num);
                }
            }
            // System.Collections.Generic.List<long>.Enumerator enumerator;
            // ((System.IDisposable)enumerator).Dispose();
            finally
            {
            }

            int LastSegmentUsefulDataLength = (int)Math.Round(Math.Round(Math.Ceiling(Data.Length % 5 * 8 / 5.0d)));
            RetVal = RetVal.Substring(0, RetVal.Length - (8 - LastSegmentUsefulDataLength));
            if (IncludePadding)
            {
                RetVal += new string(ControlChars.NullChar, 8 - LastSegmentUsefulDataLength);
            }

            return RetVal;
        }

        public static string FormatKeyCode(string StrIn, long GrpLen)
        {
            string OutStr = null;
            long StrLen = Strings.Len(StrIn);
            double StrGroups = Conversion.Int(StrLen / (double)GrpLen);
            long StrLeftOver = StrLen % GrpLen;
            long arg_42_0 = 0L;
            long num = (long)Math.Round(Math.Round(StrGroups - 1.0d));
            long CurGrp = arg_42_0;
            bool flag;
            while (true)
            {
                long arg_8C_0 = CurGrp;
                long num2 = num;
                if (arg_8C_0 > num2)
                {
                    break;
                }

                long GrpStart = CurGrp * GrpLen + 1L;
                string GrpStr = Strings.Mid(StrIn, (int)GrpStart, (int)GrpLen);
                flag = CurGrp > 0L;
                if (flag)
                {
                    OutStr = Convert.ToString(OutStr + Convert.ToString("-")) + GrpStr;
                }
                else
                {
                    OutStr += GrpStr;
                }

                CurGrp += 1L;
            }

            flag = StrLeftOver > 0L;
            if (flag)
            {
                OutStr = OutStr + Convert.ToString("-") + Strings.Right(StrIn, (int)StrLeftOver);
            }

            return OutStr;
        }

        private static T InlineAssignHelper<T>(ref T target, T value)
        {
            target = value;
            return value;
        }
    }
}