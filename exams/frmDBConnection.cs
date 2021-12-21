using System;

namespace exams
{
    public partial class frmDBConnection
    {
        public frmDBConnection()
        {
            InitializeComponent();
            _btnSave.Name = "btnSave";
            _defaultConnString.Name = "defaultConnString";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.dbName = txtDBName.Text;
            My.MySettingsProperty.Settings.host = txtDbHost.Text;
            My.MySettingsProperty.Settings.userName = txtUserName.Text;
            My.MySettingsProperty.Settings.passWord = txtPassword.Text;
            My.MySettingsProperty.Settings.dPport = txtDbPort.Text;
            My.MySettingsProperty.Settings.API = txtAPI.Text;
            My.MySettingsProperty.Settings.APIUserName = txtAPIUserName.Text;
            My.MySettingsProperty.Settings.Sender = txtSender.Text;
            My.MySettingsProperty.Settings.Save();
            publicSubsNFunctions.success("The Connection Was Succesfuly Saved");
            Close();
        }

        private void frmDBConnection_Load(object sender, EventArgs e)
        {
            txtDBName.Text = My.MySettingsProperty.Settings.dbName;
            txtDbHost.Text = My.MySettingsProperty.Settings.host;
            txtUserName.Text = My.MySettingsProperty.Settings.userName;
            txtPassword.Text = My.MySettingsProperty.Settings.passWord;
            txtDbPort.Text = My.MySettingsProperty.Settings.dPport;
            txtAPI.Text = My.MySettingsProperty.Settings.API;
            txtSender.Text = My.MySettingsProperty.Settings.Sender;
            txtAPIUserName.Text = My.MySettingsProperty.Settings.APIUserName;
        }

        private void defaultConnString_Click(object sender, EventArgs e)
        {
            txtDBName.Text = "schoolss";
            txtDbHost.Text = "localhost";
            txtPassword.Text = string.Empty;
            txtUserName.Text = "root";
            txtDbPort.Text = "7474";
        }
    }
}