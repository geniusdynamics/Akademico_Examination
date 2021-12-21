using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmSubjectRank
    {
        public frmSubjectRank()
        {
            InitializeComponent();
            _radLast.Name = "radLast";
            _radFirst.Name = "radFirst";
            _btnCancel.Name = "btnCancel";
            _btnAnalyze.Name = "btnAnalyze";
        }

        private void frmSubjectRank_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                radNone.Checked = true;
                radFirst.Checked = false;
                radLast.Checked = false;
                txtNumber.Enabled = false;
                cboSubject.Items.Add(publicSubsNFunctions.None);
                for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                    cboSubject.Items.Add(publicSubsNFunctions.subjabb[k]);
                cboSubject.SelectedItem = publicSubsNFunctions.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.rank = false;
            Close();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(cboSubject.SelectedItem, publicSubsNFunctions.None, false)))
            {
                if ((radFirst.Checked | radLast.Checked) & !Information.IsNumeric(txtNumber.Text))
                {
                    publicSubsNFunctions.failure("failure Value For Student Filter Number!");
                    return;
                }

                publicSubsNFunctions.rank = true;
                publicSubsNFunctions.radF = radFirst.Checked;
                publicSubsNFunctions.radL = radLast.Checked;
                try
                {
                    publicSubsNFunctions.rankno = Conversions.ToInteger(txtNumber.Text);
                }
                catch (Exception ex)
                {
                }

                publicSubsNFunctions.subject = Conversions.ToString(cboSubject.SelectedItem);
                Close();
            }
            else
            {
                publicSubsNFunctions.failure("Please Select A Subject To Analyze!");
            }
        }

        private void radFirst_CheckedChanged(object sender, EventArgs e)
        {
            txtNumber.Enabled = true;
        }

        private void radLast_CheckedChanged(object sender, EventArgs e)
        {
            txtNumber.Enabled = true;
        }
    }
}