using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmLicense
    {
        public frmLicense()
        {
            InitializeComponent();
            _btnActivate.Name = "btnActivate";
            _radActivate.Name = "radActivate";
            _sampleDb.Name = "sampleDb";
        }

        private string DemoDatabase = "DemoDatabase";

        private void frmLicense_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                My.MyProject.Forms.frmDBConnection.ShowDialog();
            }
            // schoolNameLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            // licenseKeyLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            // activateLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            else if (VerifyL.getExpirationDate() == true)
            {
                LabelInfo.Text = "The License Will Expire On " + VerifyL.licenseExpiration.ToString();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // ErrorProvider1.Clear()
            // If cboLicensePeriod.SelectedItem Is Nothing Then
            // ErrorProvider1.SetError(cboLicensePeriod, "Please Select The Licensing Period Time")
            // Else
            // Dim time As String() = cboLicensePeriod.SelectedItem.ToString().Split(" "c)
            // txtLicenseInfo.Text = VerifyL.generateLicenseCode(time(0))
            // End If
        }

        private void radGenerateCode_CheckedChanged(object sender, EventArgs e)
        {
            // If radGenerateCode.Checked = True Then
            // schoolNameLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            // licenseKeyLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            // activateLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            // generateCodeLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            // Else
            // schoolNameLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            // licenseKeyLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            // activateLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            // generateCodeLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            // licensePeriodLC.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            // End If
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            ErrorProvider1.Clear();
            if (string.IsNullOrEmpty(txtSchoolName.Text))
            {
                ErrorProvider1.SetError(txtSchoolName, "Please Select The School Name");
                return;
            }
            else if (string.IsNullOrEmpty(txtLicenseInfo.Text))
            {
                ErrorProvider1.SetError(txtLicenseInfo, "Please Enter The License Information");
                return;
            }
            else if (string.IsNullOrEmpty(txtLicenseKey.Text))
            {
                ErrorProvider1.SetError(txtLicenseKey, "Please Enter The License Key");
                return;
            }
            else
            {
                // else if (cboLicensePeriod.SelectedItem == null)
                // {
                // errorProvider1.SetError(cboLicensePeriod, "Please Select The Licensing Period");
                // return;
                // }
                string licenseInfo = VerifyL.extractValues(txtLicenseInfo.Text);
                if (licenseInfo.Length != 10)
                {
                    MessageBox.Show("The License Information Is Invalid" + Environment.NewLine + "Please Contact The Software Vendor");
                    return;
                }
                else
                {
                    string dateTime__1 = VerifyL.formatString(DateTime.Now.Day.ToString()) + DateTime.Now.Year.ToString() + VerifyL.formatString(DateTime.Now.Month.ToString());
                    string extractedInfo = VerifyL.extractValues(txtLicenseInfo.Text);
                    string info = extractedInfo.Substring(0, extractedInfo.Length - 2);
                    if ((dateTime__1 ?? "") != (info ?? ""))
                    {
                        MessageBox.Show("The License Information Is Invalid, Please Try Again");
                        return;
                    }
                    else
                    {
                        string applicationKey = Conversions.ToString(VerifyL.key_code(txtSchoolName.Text, "AKADEMICO_EXAMINATION", txtLicenseInfo.Text));
                        applicationKey = applicationKey.Substring(0, 32);
                        if ((applicationKey ?? "") == (txtLicenseKey.Text ?? ""))
                        {
                            if (publicSubsNFunctions.qwrite("INSERT INTO `license` (`school_name`, `module`, `license`, `time_stamp`) VALUES ('" + VerifyL.Encrypt(txtSchoolName.Text) + "', '" + VerifyL.Encrypt("AKADEMICO_EXAMINATION") + "', '" + VerifyL.Encrypt(txtLicenseKey.Text) + "', '" + VerifyL.Encrypt(extractedInfo) + "');"))
                            {
                                MessageBox.Show("Thank You For Regestering Your Copy Of Akademico Exam");
                                Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("The License Is Invalid, Please Contact The Software Vendor");
                            return;
                        }
                    }
                }
            }
        }

        private void radActivate_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void sampleDb_Click(object sender, EventArgs e)
        {

            // frmDBConnection frmDBConnection = New frmDBConnection();
            // frmDBConnection.ShowDialog();
            // My.Settings.dbName = "demodatabase"
            // the above methods did not work, created a setting parameter named defaultDb to store db value
            My.MySettingsProperty.Settings.dbName = My.MySettingsProperty.Settings.defaultDb;
            My.MySettingsProperty.Settings.Save();
            MessageBox.Show("your database has been changed to DemoDatabase  & When you click ok, the application will reload  & During Login, click Db Connect,Enter schoolss to return to New blank");
            // Restarts the application after setting a new database
            // Application.Exit()
            Application.Restart();
        }
    }
}