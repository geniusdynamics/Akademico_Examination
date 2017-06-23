Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports Microsoft.VisualBasic.CompilerServices

Public Class VerifyL

    Shared verified As Boolean = False
    Public Shared rnd As New Random()
    Public Shared licenseExpiration As DateTime
    Public Shared Function verifyTime() As Boolean
        verified = False
        getExpirationDate()
        If DateTime.Now > licenseExpiration Then
            MessageBox.Show("Please Call Your Software Vendor For An Updated Version" + Environment.NewLine + "THIS COPY IS UNLICENCED CALL 0733 911 638 OR 0723 836 205")
            Application.[Exit]()
            verified = True
        End If

        Return verified
    End Function

    Public Shared Function verifyTimeStamp() As Boolean
        Dim verified As Boolean = False

        If getExpirationDate() = False Then
            Return InlineAssignHelper(verified, True)
        End If


        Dim queries As String() = {"select year from examined_classes where year > '" + licenseExpiration.ToString("yyyy-MM-dd") + "';"}

        For Each s As String In queries
            If qread(s) Then
                If dbreader.RecordsAffected > 15 Then
                    dbreader.Read()
                    MessageBox.Show("Please Call Your Software Vendor For An Updated Version" + Environment.NewLine + "THIS COPY IS UNLICENCED CALL 0733 911 638 OR 0723 836 205")
                    verified = True
                    Return verified
                Else
                    Return False
                End If
            End If

        Next

        Return verified
    End Function

    Public Shared Function getSchoolDetails() As String
        Dim details As String = String.Empty
        details = getStringRecord((Convert.ToString("select school_name from license where module = '") & VerifyL.Encrypt("AKADEMICO_EXAMINATION")) + "' order by id desc limit 1")
        If Not String.IsNullOrEmpty(details) Then
            details = Decrypt(details)
        End If

        Return details
    End Function

    Public Shared Function getStringRecord(ByVal query As String) As String
        Dim record As String = String.Empty

        If qread(query) Then
            If dbreader.RecordsAffected > 0 Then
                dbreader.Read()
                record = dbreader.GetString(0)
            Else
                record = String.Empty
            End If
        End If

        Return record
    End Function

    Public Shared Function getExpirationDate() As Boolean
        Dim valid As Boolean = False

        Dim dateTime As String = getStringRecord((Convert.ToString("select time_stamp from license where module = '") & VerifyL.Encrypt("AKADEMICO_EXAMINATION")) + "' order by id desc limit 1")
        If String.IsNullOrEmpty(dateTime) Then
            MessageBox.Show("Please License Your Copy Of Akademico Or Register For A Trial Version")
            valid = False
        Else
            dateTime = Decrypt(dateTime)
            dateTime = FormatDateTime(dateTime)
            Dim dates As String() = dateTime.Split("-"c)
            Dim licenseDate As New DateTime(Integer.Parse(dates(1)), Integer.Parse(dates(2)), Integer.Parse(dates(0)))
            Dim expiryDate As DateTime = licenseDate.AddMonths(Integer.Parse(dates(3)))
            licenseExpiration = expiryDate
            valid = True
        End If
        Return valid
    End Function

    'Public Shared Function viaDB() As Boolean
    '    verified = False
    '    Dim lDate As New DateTime(2017, 8, 20)
    '    Dim queries As String() = {"select transaction_date from detailed_transaction where transaction_date > '" + lDate.ToString("yyyy-MM-dd") + "';", "select issue_date from log_lib_register where issue_date > '" + lDate.ToString("yyyy-MM-dd") + "';", "select year from exam_results where year > '" + lDate.ToString("yyyy") + "';", "select date from inventory where date > '" + lDate.ToString("yyyy-MM-dd") + "';"}

    '    For Each s As String In queries
    '        Dim myReader As OdbcDataReader = CommonFunctions.dbRead(s)
    '        If myReader IsNot Nothing Then
    '            If myReader.RecordsAffected > 15 Then
    '                MessageBox.Show("Please Call Your Software Vendor For An Updated Version" + Environment.NewLine + "THIS COPY IS UNLICENCED CALL 0733 911 638 OR 0723 836 205")
    '                verified = True
    '                Return verified
    '            End If
    '        End If
    '    Next
    '    Return verified
    'End Function

    Public Shared Sub formatDate(ByRef myPicker As DateTimePicker)
        If getExpirationDate() = True Then
            myPicker.MaxDate = New DateTime(licenseExpiration.Year, licenseExpiration.Month, licenseExpiration.Day)
        Else
            myPicker.MaxDate = New DateTime(2012, 1, 1)
        End If

    End Sub

    Public Shared Function genGuid() As String
        Dim guid__1 As Guid = Guid.NewGuid()
        Return guid__1.ToString()
    End Function

    Public Shared Function generateLicenseCode(licenseTime As String) As String

        Dim licensePeriod As String = licenseTime
        Dim guidTest As Char() = genGuid().ToCharArray()
        Dim guid1 As String = String.Join(String.Empty, guidTest)
        Dim guid As Char() = guidTest

        Dim intTotal As Integer = countInt(guidTest)
        If intTotal < 23 Then
            guid = addInt(guidTest, (23 - intTotal))
        End If


        Dim unsuffled As String = DateTime.Now.Ticks.ToString() + DateTime.Now.Millisecond.ToString()
        Dim shuffled As New String(unsuffled.OrderBy(Function(r) rnd.[Next]()).ToArray())
        Dim ticks As Char() = shuffled.ToCharArray()
        Dim now As Char() = (Convert.ToString(Convert.ToString(formatString(DateTime.Now.Day.ToString()) & DateTime.Now.Year.ToString()) & formatString(DateTime.Now.Month.ToString())) & formatString(licensePeriod)).ToCharArray()


        Dim ticks1 As String = String.Join(String.Empty, ticks)
        Dim now1 As String = String.Join(String.Empty, now)

        Dim counter As Integer = 0
        Dim result As Integer
        Dim value As String = String.Empty

        For k As Integer = 2 To ticks.Length - 1
            If k Mod 2 = 0 Then
                If counter < now.Length Then
                    ticks(k) = now(counter)
                    counter += 1
                ElseIf counter > now.Length Then
                    Exit For
                End If
            End If
        Next

        ticks1 = String.Join(String.Empty, ticks)
        counter = 0

        For k As Integer = 0 To guid.Length - 1
            value = guid(k).ToString()

            If Integer.TryParse(value, result) Then
                If counter < ticks.Length Then
                    guid(k) = ticks(counter)
                    counter += 1
                ElseIf counter > ticks.Length Then
                    Exit For
                End If
            End If
        Next

        guid1 = String.Join(String.Empty, guid).ToUpper()
        Return guid1
    End Function

    Public Shared Function formatString(item As String) As String
        Dim formatted As String = String.Empty
        If item.Length = 1 Then
            formatted = Convert.ToString("0") & item
        Else
            formatted = item
        End If

        Return formatted
    End Function

    Public Shared Function countInt(guid As Char()) As Integer
        Dim counter As Integer = 0
        Dim value As Integer = 0
        For k As Integer = 0 To guid.Length - 1
            If Integer.TryParse(guid(k).ToString(), value) Then
                counter += 1
            End If
        Next

        Return counter
    End Function

    Public Shared Function addInt(guid As Char(), difference As Integer) As Char()
        Dim rnd As New Random()
        Dim value As String = String.Empty
        Dim outt As Integer = 0
        Dim counter As Integer = 0
        For k As Integer = guid.Length - 1 To 0 Step -1

            If Not Integer.TryParse(guid(k).ToString(), outt) Then
                If counter < difference Then
                    value += Char.Parse(rnd.[Next](9).ToString())
                    counter += 1
                Else
                    value += guid(k)
                End If
            Else
                value += guid(k)

            End If
        Next

        Return value.ToCharArray()
    End Function

    Public Shared Function formatDateTime(dateTime As String) As String
        Dim value As String = String.Empty
        value = dateTime.Insert(2, "-").Insert(7, "-").Insert(10, "-")
        Return value
    End Function

    Public Shared Function extractValues(key As String) As String
        Dim result As Integer = 0
        Dim value As String = String.Empty
        Dim ans As String = String.Empty

        For Each c As Char In key.ToCharArray()
            If Integer.TryParse(c.ToString(), result) Then
                value += c.ToString()
            End If
        Next

        For k As Integer = 2 To value.Length - 1
            If ans.Length > 9 Then
                Exit For
            End If

            If k Mod 2 = 0 Then
                ans += value(k)

            End If
        Next

        Return ans
    End Function

    Public Shared Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "%^&$#*1234Abcdef"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
                    &H65, &H64, &H76, &H65, &H64, &H65,
                    &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function
    Public Shared Function Decrypt(cipherText As String) As String

        Try
            Dim EncryptionKey As String = "%^&$#*1234Abcdef"
            cipherText = cipherText.Replace(" ", "+")
            Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
                    &H65, &H64, &H76, &H65, &H64, &H65,
                    &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using ms As New MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                        cs.Write(cipherBytes, 0, cipherBytes.Length)
                        cs.Close()
                    End Using
                    cipherText = Encoding.Unicode.GetString(ms.ToArray())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("THE LICENSE FILE HAS BEEN MODIFIED" + Environment.NewLine + "Please Call 0733 911 638 or 0723 836 205 For Assistance")
            cipherText = String.Empty
        End Try


        Return cipherText
    End Function

    Public Shared Function key_code(name As String, module_ As String, licence As String)
        Dim key_string = name & module_.ToUpper & licence
        Return FormatKeyCode(ToBase32(Enumerable.Range(0, md5_this(key_string).Length \ 2).Select(Function(x) CByte("&H" & md5_this(key_string).Substring(x * 2, 2))).ToArray), 4)
    End Function


    Public Shared Sub AddTimeStamp()
        Dim tables As String() = {"examined_classes", "detailed_transaction", "log_lib_register", "inventory", "students"}

        For Each s As String In tables
            If Not ifExists((Convert.ToString("SHOW COLUMNS FROM " + My.Settings.dbName + ".") & s) + " LIKE 'time_stamp';") Then

                If qwrite((Convert.ToString("ALTER TABLE `") & s) + "` ADD `time_stamp` TIMESTAMP ON UPDATE CURRENT_TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ;") Then

                End If
            End If
        Next
    End Sub

    Public Shared Sub addLicenseTable()
        If Not ifExists("SELECT * FROM information_schema.TABLES WHERE (TABLE_SCHEMA = '" + My.Settings.dbName + "') AND (TABLE_NAME = 'license');") Then
            Dim licenseTable As String = "CREATE TABLE IF NOT EXISTS `license` (`id` bigint(255) NOT NULL AUTO_INCREMENT, `school_name` varchar(255) NOT NULL DEFAULT '--', `module` varchar(255) NOT NULL DEFAULT '--', `license` varchar(255) NOT NULL DEFAULT '--', `time_stamp` varchar(255) NOT NULL DEFAULT '--', PRIMARY KEY (`id`)) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
            If qwrite(licenseTable) Then
            End If
        End If
    End Sub

    Public Shared Function ifExists(ByVal query) As Boolean
        If qread(query) Then
            If dbreader.RecordsAffected > 0 Then
                dbreader.Read()
                Return True
            Else
                Return False
            End If
        End If
    End Function



    Public Shared Function md5_this(Source As String) As String
        Dim sb As New System.Text.StringBuilder()
        Dim flag As Boolean = String.IsNullOrEmpty(Source)
        If flag Then
            Throw New System.ArgumentNullException()
        End If
        Dim Bytes As Byte() = System.Text.Encoding.[Default].GetBytes(Source)
        Bytes = System.Security.Cryptography.MD5.Create().ComputeHash(Bytes)
        Dim arg_3A_0 As Integer = 0
        Dim num As Integer = Bytes.Length - 1
        Dim x As Integer = arg_3A_0
        While True
            Dim arg_61_0 As Integer = x
            Dim num2 As Integer = num
            If arg_61_0 > num2 Then
                Exit While
            End If
            sb.Append(Bytes(x).ToString("x2"))
            x += 1
        End While
        Return sb.ToString()

    End Function

    Public Shared Function ToBase32(Data As Byte(), Optional IncludePadding As Boolean = True) As String
        Dim RetVal As String = ""
        Dim Segments As New System.Collections.Generic.List(Of Long)()
        Dim Index As Integer = 0
        While Index < Data.Length
            Dim CurrentSegment As Long = 0L
            Dim SegmentSize As Integer = 0
            While Index < Data.Length And SegmentSize < 5
                CurrentSegment <<= 8
                CurrentSegment += CLng(CULng(Data(Index)))
                Index += 1
                SegmentSize += 1
            End While
            CurrentSegment <<= 8 * (5 - SegmentSize)
            Segments.Add(CurrentSegment)
        End While
        Try
            Dim enumerator As System.Collections.Generic.List(Of Long).Enumerator = Segments.GetEnumerator()
            While enumerator.MoveNext()
                Dim CurrentSegment2 As Long = enumerator.Current
                Dim x As Integer = 0
                Dim arg_B6_0 As Integer
                Dim num As Integer
                Do
                    RetVal += Conversions.ToString("ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"(CInt(CurrentSegment2 >> (7 - x) * 5 And 31L)))
                    x += 1
                    arg_B6_0 = x
                    num = 7
                Loop While arg_B6_0 <= num
            End While
            'System.Collections.Generic.List<long>.Enumerator enumerator;
            '((System.IDisposable)enumerator).Dispose();
        Finally
        End Try
        Dim LastSegmentUsefulDataLength As Integer = CInt(System.Math.Round(System.Math.Ceiling(CDbl((Data.Length Mod 5) * 8) / 5.0)))
        RetVal = RetVal.Substring(0, RetVal.Length - (8 - LastSegmentUsefulDataLength))
        If IncludePadding Then
            RetVal += New String(ControlChars.NullChar, 8 - LastSegmentUsefulDataLength)
        End If
        Return RetVal

    End Function

    Public Shared Function FormatKeyCode(StrIn As String, GrpLen As Long) As String
        Dim OutStr As String = Nothing
        Dim StrLen As Long = CLng(Strings.Len(StrIn))
        Dim StrGroups As Double = Conversion.Int(CDbl(StrLen) / CDbl(GrpLen))
        Dim StrLeftOver As Long = StrLen Mod GrpLen
        Dim arg_42_0 As Long = 0L
        Dim num As Long = CLng(System.Math.Round(StrGroups - 1.0))
        Dim CurGrp As Long = arg_42_0
        Dim flag As Boolean
        While True
            Dim arg_8C_0 As Long = CurGrp
            Dim num2 As Long = num
            If arg_8C_0 > num2 Then
                Exit While
            End If
            Dim GrpStart As Long = CurGrp * GrpLen + 1L
            Dim GrpStr As String = Strings.Mid(StrIn, CInt(GrpStart), CInt(GrpLen))
            flag = (CurGrp > 0L)
            If flag Then
                OutStr = Convert.ToString(OutStr & Convert.ToString("-")) & GrpStr
            Else
                OutStr += GrpStr
            End If
            CurGrp += 1L
        End While
        flag = (StrLeftOver > 0L)
        If flag Then
            OutStr = (OutStr & Convert.ToString("-")) + Strings.Right(StrIn, CInt(StrLeftOver))
        End If
        Return OutStr

    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

End Class
