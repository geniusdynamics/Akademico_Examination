using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmNationalExamPerformance
    {
        public frmNationalExamPerformance()
        {
            InitializeComponent();
            _cboYear.Name = "cboYear";
            _Button4.Name = "Button4";
            _Button3.Name = "Button3";
            _Button2.Name = "Button2";
            _Button1.Name = "Button1";
        }

        private bool isvalid()
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboYear.SelectedItem, null, false), Operators.ConditionalCompareObjectNotEqual(cboExamination.SelectedItem, null, false))))
            {
                return true;
            }
            else
            {
                publicSubsNFunctions.failure("Please Select An Examination To Analyze Results For!");
                return false;
            }
        }

        private void frmNationalExamPerformance_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                publicSubsNFunctions.get_subjects();
                publicSubsNFunctions.get_grades();
                for (int k = publicSubsNFunctions.startyear, loopTo = publicSubsNFunctions.endyear; k <= loopTo; k++)
                    cboYear.Items.Add(k);
                cboYear.SelectedItem = DateAndTime.Today.Year;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                publicSubsNFunctions.exam_name = Conversions.ToString(cboExamination.SelectedItem);
                publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
                publicSubsNFunctions.load_form();
                var frm = new frmNationalMeanAnalysis();
                frm.ShowDialog();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                publicSubsNFunctions.exam_name = Conversions.ToString(cboExamination.SelectedItem);
                publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
                publicSubsNFunctions.load_form();
                var frm = new frmNationalGradesAttained();
                frm.ShowDialog();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                publicSubsNFunctions.exam_name = Conversions.ToString(cboExamination.SelectedItem);
                publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
                publicSubsNFunctions.load_form();
                publicSubsNFunctions.rpt = "Subjects";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                publicSubsNFunctions.exam_name = Conversions.ToString(cboExamination.SelectedItem);
                publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
                publicSubsNFunctions.load_form();
                publicSubsNFunctions.rpt = "Students";
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

                cboExamination.Items.Clear();
                if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
                {
                    while (publicSubsNFunctions.dbreader.Read())
                        cboExamination.Items.Add(publicSubsNFunctions.dbreader["Name"]);
                }
            }
        }
    }
}