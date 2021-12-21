using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmNationalExaminationsEntryPrompt
    {
        public frmNationalExaminationsEntryPrompt()
        {
            InitializeComponent();
            _cboYear.Name = "cboYear";
            _btnEnter.Name = "btnEnter";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if ((cboYear.SelectedItem.ToString() ?? "") != (publicSubsNFunctions.None ?? ""))
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(cboExamination.SelectedItem, publicSubsNFunctions.None, false)))
                {
                    publicSubsNFunctions.exam_name = Conversions.ToString(cboExamination.SelectedItem);
                    publicSubsNFunctions.cont = true;
                    publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
                    publicSubsNFunctions.load_from_alumni = CheckBox1.Checked;
                    Close();
                }
                else
                {
                    publicSubsNFunctions.failure("Invalid Choice For Examination Name!");
                }
            }
            else
            {
                publicSubsNFunctions.failure("Invalid Choice For Year!");
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboYear.SelectedItem.ToString() ?? "") != (publicSubsNFunctions.None ?? ""))
            {
                if (publicSubsNFunctions.stud)
                {
                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Name FROM national_examinations WHERE Year='", cboYear.SelectedItem), "'"));
                }
                else
                {
                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Name FROM national_examinations WHERE Year='", cboYear.SelectedItem), "'"));
                }

                if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
                {
                    while (publicSubsNFunctions.dbreader.Read())
                        cboExamination.Items.Add(publicSubsNFunctions.dbreader["Name"]);
                }
            }
        }

        private void frmNationalExaminationsEntryPrompt_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                for (int k = publicSubsNFunctions.startyear, loopTo = publicSubsNFunctions.endyear; k <= loopTo; k++)
                    cboYear.Items.Add(k);
                cboYear.SelectedItem = DateAndTime.Today.Year;
            }
        }
    }
}