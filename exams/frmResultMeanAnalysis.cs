using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmResultMeanAnalysis
    {
        public frmResultMeanAnalysis()
        {
            InitializeComponent();
            _cboYear.Name = "cboYear";
            _cboTerm.Name = "cboTerm";
            _btnAddExam.Name = "btnAddExam";
            _btnEnterMarks.Name = "btnEnterMarks";
            _btnCancel.Name = "btnCancel";
        }

        private void frmResultMeanAnalysis_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                lstExaminations.Items.Clear();
                grpMultiExaminations.Enabled = true;
                fill_year();
                publicSubsNFunctions.get_term();
                var argcbo = cboClass;
                publicSubsNFunctions.load_class(ref argcbo);
                cboClass = argcbo;
                cboTerm.SelectedItem = publicSubsNFunctions.term;
                cboYear.SelectedItem = DateAndTime.Today.Year;
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
            cboSelectedYear.SelectedItem = DateAndTime.Today.Year;
        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            add_exam();
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

        private void add_exam()
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(cboExamName.SelectedItem, publicSubsNFunctions.None, false)))
            {
                if (Conversions.ToBoolean(!exists(Conversions.ToString(cboExamName.SelectedItem))))
                {
                    var li = new ListViewItem();
                    li = lstExaminations.Items.Add(cboExamName.SelectedItem);
                    li.SubItems.Add(cboTerm.SelectedItem);
                    li.SubItems.Add(cboYear.SelectedItem);
                }
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboTerm.SelectedItem, publicSubsNFunctions.None, false), (cboYear.SelectedItem.ToString() ?? "") != (publicSubsNFunctions.None ?? ""))))
            {
                fill_exam();
            }
        }

        private void cboTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboTerm.SelectedItem, publicSubsNFunctions.None, false), (cboYear.SelectedItem.ToString() ?? "") != (publicSubsNFunctions.None ?? ""))))
            {
                fill_exam();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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
            // todo add condition to check whether grading scheme exists
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

                publicSubsNFunctions.selectedTerm = cboSelectedTerm.SelectedItem.ToString();
                publicSubsNFunctions.selectedClass = cboClass.SelectedItem.ToString();
                publicSubsNFunctions.selectedYear = cboSelectedYear.SelectedItem.ToString();
                publicSubsNFunctions.sortGradesBy = cboSortBy.SelectedItem.ToString();
                publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
                publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
                publicSubsNFunctions.examList = new List<Tuple<string, string, string>>();
                for (int i = 0, loopTo = lstExaminations.Items.Count - 1; i <= loopTo; i++)
                    publicSubsNFunctions.examList.Add(new Tuple<string, string, string>(lstExaminations.Items[i].Text, lstExaminations.Items[i].SubItems[1].Text, lstExaminations.Items[i].SubItems[2].Text));
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

                Close();
                var meanResultForm = new frmMeanResults();
                meanResultForm.MdiParent = My.MyProject.Forms.frmMainForm;
                meanResultForm.Show();
            }
        }
    }
}