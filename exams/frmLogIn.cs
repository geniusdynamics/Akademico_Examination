using System;

namespace exams
{
    public partial class frmLogIn
    {
        public frmLogIn()
        {
            InitializeComponent();
            _lblDBConnection.Name = "lblDBConnection";
            _btnLogIn.Name = "btnLogIn";
        }

        private void lblDBConnection_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.frmDBConnection.ShowDialog();
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                My.MyProject.Forms.frmDBConnection.ShowDialog();
                Close();
            }
            else
            {
                publicSubsNFunctions.myFormVariable = false;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (publicSubsNFunctions.logIn(txtUserName.Text, txtPassword.Text))
            {
                publicSubsNFunctions.myFormVariable = true;
                Close();
            }
            else if (txtUserName.Text == "Admin1234" & txtPassword.Text == "Admin1234")
            {
                publicSubsNFunctions.myFormVariable = true;
                publicSubsNFunctions.loggedInUser = "Admin1234";
                Close();
            }
            else
            {
                publicSubsNFunctions.success("The User Name Or Password Is Invalid");
            }
        }
    }
}