Public Class frmLicense
    Private Sub frmLicense_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not connect() Then
            frmDBConnection.ShowDialog()
        Else
            schoolNameLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            licenseKeyLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            activateLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            If VerifyL.getExpirationDate() = True Then
                lblInfo.Text = "The License Will Expire On " + VerifyL.licenseExpiration.ToString()
            End If
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        ErrorProvider1.Clear()
        If cboLicensePeriod.SelectedItem Is Nothing Then
            ErrorProvider1.SetError(cboLicensePeriod, "Please Select The Licensing Period Time")
        Else
            Dim time As String() = cboLicensePeriod.SelectedItem.ToString().Split(" "c)
            txtLicenseInfo.Text = VerifyL.generateLicenseCode(time(0))
        End If
    End Sub

    Private Sub radGenerateCode_CheckedChanged(sender As Object, e As EventArgs) Handles radGenerateCode.CheckedChanged
        If radGenerateCode.Checked = True Then
            schoolNameLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            licenseKeyLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            activateLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            generateCodeLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            schoolNameLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            licenseKeyLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            activateLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            generateCodeLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            licensePeriodLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub btnActivate_Click(sender As Object, e As EventArgs) Handles btnActivate.Click
        ErrorProvider1.Clear()
        If String.IsNullOrEmpty(txtSchoolName.Text) Then
            ErrorProvider1.SetError(txtSchoolName, "Please Select The School Name")
            Return
        ElseIf String.IsNullOrEmpty(txtLicenseInfo.Text) Then
            ErrorProvider1.SetError(txtLicenseInfo, "Please Enter The License Information")
            Return
        ElseIf String.IsNullOrEmpty(txtLicenseKey.Text) Then
            ErrorProvider1.SetError(txtLicenseKey, "Please Enter The License Key")
            Return
        Else
            'else if (cboLicensePeriod.SelectedItem == null)
            '{
            '    errorProvider1.SetError(cboLicensePeriod, "Please Select The Licensing Period");
            '    return;
            '}
            Dim licenseInfo As String = VerifyL.extractValues(txtLicenseInfo.Text)
            If licenseInfo.Length <> 10 Then
                MessageBox.Show("The License Information Is Invalid" + Environment.NewLine + "Please Contact The Software Vendor")
                Return
            Else
                Dim dateTime__1 As String = VerifyL.formatString(DateTime.Now.Day.ToString()) + DateTime.Now.Year.ToString() + VerifyL.formatString(DateTime.Now.Month.ToString())
                Dim extractedInfo As String = VerifyL.extractValues(txtLicenseInfo.Text)
                Dim info As String = extractedInfo.Substring(0, extractedInfo.Length - 2)

                If dateTime__1 <> info Then
                    MessageBox.Show("The License Information Is Invalid, Please Try Again")
                    Return
                Else
                    Dim applicationKey As String = VerifyL.key_code(txtSchoolName.Text, "AKADEMICO_EXAMINATION", txtLicenseInfo.Text)
                    applicationKey = applicationKey.Substring(0, 32)

                    If applicationKey = txtLicenseKey.Text Then
                        If qwrite("INSERT INTO `license` (`school_name`, `module`, `license`, `time_stamp`) VALUES ('" + VerifyL.Encrypt(txtSchoolName.Text) + "', '" + VerifyL.Encrypt("AKADEMICO_EXAMINATION") + "', '" + VerifyL.Encrypt(txtLicenseKey.Text) + "', '" + VerifyL.Encrypt(extractedInfo) + "');") Then
                            MessageBox.Show("Thank You For Regestering Your Copy Of Akademico Exam")
                        End If
                    Else
                        MessageBox.Show("The License Is Invalid, Please Contact The Software Vendor")
                        Return

                    End If
                End If
            End If
        End If
    End Sub
End Class