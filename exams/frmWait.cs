using System;

namespace exams
{
    public partial class frmWait
    {
        public frmWait()
        {
            InitializeComponent();
        }

        private int i = 0;

        private void frmWait_Load(object sender, EventArgs e)
        {
            lblOperation.Text = publicSubsNFunctions.operation;
            Timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Increment(10);
            i += 5;
            if (i == 80)
            {
                Timer1.Enabled = false;
                Close();
            }
        }
    }
}