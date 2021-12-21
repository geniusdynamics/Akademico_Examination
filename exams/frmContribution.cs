using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmContribution
    {
        public frmContribution()
        {
            InitializeComponent();
            _cboYear.Name = "cboYear";
            _cboTerm.Name = "cboTerm";
            _btnAddExam.Name = "btnAddExam";
            _btnEnterMarks.Name = "btnEnterMarks";
            _btnClear.Name = "btnClear";
            _btnCancel.Name = "btnCancel";
        }

        private void frmContribution_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                total_percentage = 0d;
                txtContribution.Clear();
                lstExaminations.Items.Clear();
                grpMultiExaminations.Enabled = true;
                fill_year();
                publicSubsNFunctions.get_term();
                var argcbo = cboClass;
                publicSubsNFunctions.load_class(ref argcbo);
                cboClass = argcbo;
                cboTerm.SelectedItem = publicSubsNFunctions.term;
                txtContribution.Text = 0.ToString();
                cboSelectedTerm.SelectedItem = publicSubsNFunctions.term;
            }
        }

        private void fill_year()
        {
            cboYear.Items.Clear();
            cboSelectedYear.Items.Clear();
            var argcbo = cboYear;
            publicSubsNFunctions.fill_years(ref argcbo);
            cboYear = argcbo;
            var argcbo1 = cboSelectedYear;
            publicSubsNFunctions.fill_years(ref argcbo1);
            cboSelectedYear = argcbo1;
            cboYear.SelectedItem = DateAndTime.Today.Year;
            cboSelectedTerm.SelectedItem = DateAndTime.Today.Year;
        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isvalid()))
            {
                add_exam();
            }
            else
            {
                Interaction.MsgBox(msg);
            }
        }

        private string getExamContribution()
        {
            string contribution = string.Empty;
            string argq = "select total from examinations where term = '" + cboTerm.SelectedItem.ToString() + "' and year = '" + cboYear.SelectedItem.ToString() + "' and examname = '" + cboExamName.SelectedItem.ToString() + "'";
            if (publicSubsNFunctions.qread(ref argq))
            {
                while (publicSubsNFunctions.dbreader.Read())
                    contribution = Conversions.ToString(publicSubsNFunctions.dbreader["total"]);
            }

            return contribution;
        }

        private double total_percentage = 0d;
        private string msg = string.Empty;

        private object isvalid()
        {
            double buffer = 0d;
            buffer = total_percentage + Conversions.ToDouble(txtContribution.Text);
            if (buffer > 100d)
            {
                msg = "The Examination Contributions Must Not Exceed 100%";
                return false;
            }

            if (!Information.IsNumeric(cboYear.SelectedItem))
            {
                msg = "Invalid Selection For Year!";
                return false;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboTerm.SelectedItem, publicSubsNFunctions.None, false)))
            {
                msg = "Invalid Selection for Term!";
                return false;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboExamName.SelectedItem, publicSubsNFunctions.None, false)))
            {
                msg = "Invalid Selection For Exam Name!";
                return false;
            }
            else if (!Information.IsNumeric(txtContribution.Text))
            {
                msg = "The Value For Contribution Is Not A Number";
                return false;
            }
            else if (Conversions.ToDouble(txtContribution.Text) == 0d)
            {
                msg = "Contribution Can Not Be Zero";
                return false;
            }
            else
            {
                return true;
            }
        }

        private object isValidSave()
        {
            if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(cboClass.SelectedItem, null, false), Operators.ConditionalCompareObjectEqual(cboClass.SelectedItem, publicSubsNFunctions.None, false))))
            {
                msg = "Invalid Selection For Class!";
                return false;
            }
            else if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(cboSortBy.SelectedItem, string.Empty, false), cboSortBy.Visible)))
            {
                msg = "Please Choose The Mode To Sort The Result Analysis!";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void add_exam()
        {
            // todo add method to get the exam out of
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboExamName.SelectedItem, publicSubsNFunctions.None, false), Information.IsNumeric(txtContribution.Text)), (txtContribution.Text ?? "") != (string.Empty ?? ""))))
            {
                if (Conversions.ToBoolean(!exists(Conversions.ToString(cboExamName.SelectedItem))))
                {
                    var li = new ListViewItem();
                    li = lstExaminations.Items.Add(cboExamName.SelectedItem);
                    li.SubItems.Add(txtContribution.Text);
                    li.SubItems.Add(cboTerm.SelectedItem);
                    li.SubItems.Add(cboYear.SelectedItem);
                    li.SubItems.Add(getExamContribution());
                    total_percentage += Conversions.ToDouble(txtContribution.Text);
                }
            }
        }

        private object exists(string str)
        {
            int i;
            string selectedTerm = string.Empty;
            var loopTo = lstExaminations.Items.Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject((lstExaminations.Items[i].Text ?? "") == (str ?? ""), Operators.ConditionalCompareObjectEqual(lstExaminations.Items[i].SubItems[2].Text, cboYear.SelectedItem, false)), Operators.ConditionalCompareObjectEqual(lstExaminations.Items[i].SubItems[1].Text, cboTerm.SelectedItem, false))))
                {
                    Interaction.MsgBox("The Exam Already Exist In The List");
                    return true;
                }
            }

            return false;
        }

        private void cboTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboTerm.SelectedItem, publicSubsNFunctions.None, false), (cboYear.SelectedItem.ToString() ?? "") != (publicSubsNFunctions.None ?? ""))))
            {
                fill_exam();
            }
        }

        private void fill_exam()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ExamName FROM examinations WHERE Term='", cboTerm.SelectedItem), "' AND Year='"), cboYear.SelectedItem), "'"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                cboExamName.Items.Clear();
                cboExamName.Items.Add(publicSubsNFunctions.None);
                while (publicSubsNFunctions.dbreader.Read())
                    cboExamName.Items.Add(publicSubsNFunctions.dbreader["ExamName"]);
                cboExamName.SelectedItem = publicSubsNFunctions.None;
                publicSubsNFunctions.dbreader.Close();
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Load Examinations!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.search_teachers = false;
            Close();
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboTerm.SelectedItem, publicSubsNFunctions.None, false), (cboYear.SelectedItem.ToString() ?? "") != (publicSubsNFunctions.None ?? ""))))
            {
                fill_exam();
            }
        }

        private void btnEnterMarks_Click(object sender, EventArgs e)
        {
            if (lstExaminations.Items.Count == 0)
            {
                Interaction.MsgBox("There Are No Exams To Analyze");
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboClass.SelectedItem, null, false)))
            {
                Interaction.MsgBox("Please Select The Class");
            }
            else if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(cboSortBy.SelectedItem, string.Empty, false), cboSortBy.Visible)))
            {
                Interaction.MsgBox("Please Choose The Mode To Sort The Result Analysis!");
            }
            else
            {
                if (rdSubjectBased.Checked == true)
                {
                    publicSubsNFunctions.gradingType = "SubjectBased";
                }
                else
                {
                    publicSubsNFunctions.gradingType = "ClassBased";
                }

                publicSubsNFunctions.selectedTerm = cboTerm.SelectedItem.ToString();
                publicSubsNFunctions.selectedClass = cboClass.SelectedItem.ToString();
                publicSubsNFunctions.selectedYear = cboSelectedYear.SelectedItem.ToString();
                publicSubsNFunctions.sortGradesBy = cboSortBy.SelectedItem.ToString();
                publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
                publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
                publicSubsNFunctions.examListMain = new List<Tuple<string, string, string, string, string>>();
                for (int i = 0, loopTo = lstExaminations.Items.Count - 1; i <= loopTo; i++)
                    publicSubsNFunctions.examListMain.Add(new Tuple<string, string, string, string, string>(lstExaminations.Items[i].Text, lstExaminations.Items[i].SubItems[1].Text, lstExaminations.Items[i].SubItems[2].Text, lstExaminations.Items[i].SubItems[3].Text, lstExaminations.Items[i].SubItems[4].Text));
                publicSubsNFunctions.subjectColumns = new List<string>();
                string argq = "SHOW COLUMNS FROM subjects_done;";
                publicSubsNFunctions.qread(ref argq);
                string columns = string.Empty;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    columns = Conversions.ToString(publicSubsNFunctions.dbreader["Field"]);
                    if (columns != "ADMNo")
                    {
                        publicSubsNFunctions.subjectColumns.Add(columns);
                    }
                }

                // //////////////////////////////////////////////////////////////////////

                publicSubsNFunctions.table = "exam_results";
                publicSubsNFunctions.search_teachers = true;
                publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
                publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboSortBy.SelectedItem, "Total Marks", false)))
                {
                    publicSubsNFunctions.sortby = "Total";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboSortBy.SelectedItem, "Mean Marks", false)))
                {
                    publicSubsNFunctions.sortby = "MM";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboSortBy.SelectedItem, "Mean Points", false)))
                {
                    publicSubsNFunctions.sortby = "MP";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboSortBy.SelectedItem, "Total Points", false)))
                {
                    publicSubsNFunctions.sortby = "TP";
                }

                // /////////////////////////////////////////////////////////////////////

                Close();
                // total be converted to devexpress
                var computeResultForm = new frmComputeResults();
                computeResultForm.MdiParent = My.MyProject.Forms.frmMainForm;
                computeResultForm.Show();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            total_percentage = 0d;
        }

        private void clear()
        {
            cboTerm.SelectedItem = publicSubsNFunctions.None;
            cboExamName.SelectedItem = publicSubsNFunctions.None;
            cboClass.SelectedItem = publicSubsNFunctions.None;
            lstExaminations.Items.Clear();
            txtContribution.Text = 0.ToString();
        }
    }
}