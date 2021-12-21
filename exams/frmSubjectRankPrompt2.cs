using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmSubjectRankPrompt2
    {
        public frmSubjectRankPrompt2()
        {
            InitializeComponent();
            _btnCancel.Name = "btnCancel";
            _btnAnalyze.Name = "btnAnalyze";
        }

        private void frmSubjectRankPrompt2_Load(object sender, EventArgs e)
        {
            radFirst.Checked = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(txtNumber.Text))
            {
                if (radNone.Checked == true)
                {
                    publicSubsNFunctions.filterType = "None";
                }
                else
                {
                    Interaction.MsgBox("Please enter the result limit or the value is not a number");
                    return;
                }
            }
            else
            {
                publicSubsNFunctions.rankno = Conversions.ToInteger(txtNumber.Text);
                if (radFirst.Checked == true)
                {
                    publicSubsNFunctions.filterType = "Top";
                }
                else if (radLast.Checked == true)
                {
                    publicSubsNFunctions.filterType = "Bottom";
                }
                else
                {
                    publicSubsNFunctions.filterType = "None";
                }
            }

            var bestSubject = new frmBestStudentSubject();
            bestSubject.ShowDialog();
            Close();
        }
    }
}