using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmCreateNationalExam
    {
        public frmCreateNationalExam()
        {
            InitializeComponent();
            _btnCreateExam.Name = "btnCreateExam";
        }

        private void create_examination()
        {
            if (publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO national_examinations VALUES(NULL, '" + publicSubsNFunctions.escape_string(Strings.Trim(txtExamName.Text).ToUpper()) + "','", cboYear.SelectedItem), "')"))))
            {
                publicSubsNFunctions.success("Examination Entry Successful!");
            }
            else
            {
                publicSubsNFunctions.failure("Examination Entry Failed!" + Constants.vbNewLine + "Duplicate Entry For Examination!");
            }
        }

        private object exists()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM national_examinations WHERE Name='" + publicSubsNFunctions.escape_string(Strings.Trim(txtExamName.Text).ToUpper()) + "' AND Year='", cboYear.SelectedItem), "'"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    publicSubsNFunctions.dbreader.Close();
                    return true;
                }
                else
                {
                    publicSubsNFunctions.dbreader.Close();
                    return false;
                }
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Read From The National Examinations Database!");
                return true;
            }
        }

        private void btnCreateExam_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject((Strings.Trim(txtExamName.Text) ?? "") != (string.Empty ?? ""), !exists())))
            {
                create_examination();
            }
            else
            {
                publicSubsNFunctions.failure("Invalid Value For Examination Name!");
            }
        }

        private void frmCreateNationalExam_Load(object sender, EventArgs e)
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