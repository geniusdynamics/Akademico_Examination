using System;

namespace exams
{
    public partial class frmLoading
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private int i = 0;

        private void frmLoading_Load(object sender, EventArgs e)
        {
            StartTimer.Enabled = true;
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(5);
            i += 2;
            if (i >= 120)
            {
                StartTimer.Enabled = false;
                Close();
            }
        }
    }
}