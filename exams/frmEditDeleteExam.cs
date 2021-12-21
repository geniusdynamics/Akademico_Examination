using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmEditDeleteExam
    {
        public frmEditDeleteExam()
        {
            InitializeComponent();
            _btnDelete.Name = "btnDelete";
            _btnEdit.Name = "btnEdit";
            _cboExamName.Name = "cboExamName";
            _cboTerm.Name = "cboTerm";
            _cboYear.Name = "cboYear";
        }

        private void frmEditDeleteExam_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
                return;
            }

            var argcbo = cboYear;
            publicSubsNFunctions.fill_years(ref argcbo);
            cboYear = argcbo;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboExamName.SelectedItem is null)
            {
                if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Are You Sure You Want To Delete The Examination! This Will Remove All Records Associated With The Examination!")))
                {
                    if (publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("DELETE FROM examinations WHERE (ExamName='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboExamName.SelectedItem)) + "' AND Term='", cboTerm.SelectedItem), "' AND Year='"), cboYear.SelectedItem), "')"))))
                    {
                        publicSubsNFunctions.success("Examination Records For The Specified Examination Have Been Successfully Deleted!");
                        fill_exam();
                    }
                    else
                    {
                        publicSubsNFunctions.failure("Could Not Delete The Examination!");
                    }
                }
            }
            else
            {
                publicSubsNFunctions.failure("Invalid Examination Name Selected!");
            }
        }

        private void fill_exam()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ExamName FROM examinations WHERE Term='", cboTerm.SelectedItem), "' AND Year='"), cboYear.SelectedItem), "'"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                cboExamName.Items.Clear();
                txtTotal.Clear();
                txtName.Clear();
                cboExamName.SelectedItem = string.Empty;
                while (publicSubsNFunctions.dbreader.Read())
                    cboExamName.Items.Add(publicSubsNFunctions.dbreader["ExamName"]);
                publicSubsNFunctions.dbreader.Close();
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Load Examinations!");
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTerm.SelectedItem is object & cboYear.SelectedItem.ToString() is object)
            {
                fill_exam();
            }
        }

        private void cboTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTerm.SelectedItem is object & cboYear.SelectedItem.ToString() is object)
            {
                fill_exam();
            }
        }

        private void cboExamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboExamName.SelectedItem is object)
            {
                txtName.Text = Conversions.ToString(cboExamName.SelectedItem);
                totalMark();
            }
        }

        private void totalMark()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Total FROM examinations WHERE (ExamName='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboExamName.SelectedItem)) + "' AND Term='", cboTerm.SelectedItem), "' AND Year='"), cboYear.SelectedItem), "')"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                try
                {
                    publicSubsNFunctions.dbreader.Read();
                    txtTotal.Text = Conversions.ToString(publicSubsNFunctions.dbreader["Total"]);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Information.IsNumeric(txtTotal.Text))
            {
                if (publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("UPDATE examinations SET ExamName='" + publicSubsNFunctions.escape_string(txtName.Text) + "', Total='" + txtTotal.Text + "' WHERE (ExamName='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboExamName.SelectedItem)) + "' AND Term='", cboTerm.SelectedItem), "' AND Year='"), cboYear.SelectedItem), "')"))))
                {
                    publicSubsNFunctions.success("Examination Successfully Updated!");
                    fill_exam();
                }
                else
                {
                    publicSubsNFunctions.failure("Examination Could Not Be Updated!");
                }
            }
        }
    }
}