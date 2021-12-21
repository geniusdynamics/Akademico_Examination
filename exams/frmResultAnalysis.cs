using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmResultAnalysis
    {
        public frmResultAnalysis()
        {
            InitializeComponent();
            _btnAddExam.Name = "btnAddExam";
            _chkMode.Name = "chkMode";
            _btnEnterMarks.Name = "btnEnterMarks";
            _btnClear.Name = "btnClear";
            _txtContribution.Name = "txtContribution";
            _btnCancel.Name = "btnCancel";
            _cboClass.Name = "cboClass";
            _cboExamName.Name = "cboExamName";
            _cboYear.Name = "cboYear";
            _cboTerm.Name = "cboTerm";
        }

        private double total_percentage = 0d;
        private string msg = string.Empty;

        private void frmExamEntry_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                publicSubsNFunctions.stream_mode = false;
                lstExaminations.Items.Clear();
                CheckBox1.Enabled = true;
                btnAddExam.Enabled = false;
                txtContribution.Enabled = false;
                grpMultiExaminations.Enabled = false;
                fill_year();
                publicSubsNFunctions.get_term();
                var argcbo = cboClass;
                publicSubsNFunctions.load_class(ref argcbo);
                cboClass = argcbo;
                cboTerm.SelectedItem = publicSubsNFunctions.term;
                cboYear.SelectedItem = DateAndTime.Today.Year;
            }
        }

        private void loadClasses()
        {
            cboClass.Items.Clear();
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT class FROM examined_classes WHERE (Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboExamName.SelectedItem)) + "' AND Term='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboTerm.SelectedItem)) + "' AND Year='", cboYear.SelectedItem), "')"));
            publicSubsNFunctions.qread(ref argq);
            while (publicSubsNFunctions.dbreader.Read())
                cboClass.Items.Add(publicSubsNFunctions.dbreader["class"]);
        }

        private void fill_year()
        {
            cboYear.Items.Clear();
            var argcbo = cboYear;
            publicSubsNFunctions.fill_years(ref argcbo);
            cboYear = argcbo;
            cboYear.SelectedItem = DateAndTime.Today.Year;
        }

        private void cboTerm_SelectedValueChanged(object sender, EventArgs e)
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
            // cboStream.SelectedItem = None
            lstExaminations.Items.Clear();
        }

        private object isvalid()
        {
            if (total_percentage != 100d & chkMode.Checked)
            {
                msg = "The Examination Contributions Don't Total to 100%!";
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
            else if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(cboClass.SelectedItem, null, false), Operators.ConditionalCompareObjectEqual(cboClass.SelectedItem, publicSubsNFunctions.None, false))))
            {
                msg = "Invalid Selection For Class!";
                return false;
            }
            else if (lstExaminations.Items.Count < 1 & chkMode.Checked)
            {
                msg = "Only 1 Examination? You didn't tell me so!";
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

        private void load_entry_form_many()
        {
            int i;
            publicSubsNFunctions.tables = new string[lstExaminations.Items.Count];
            publicSubsNFunctions.contribution = new int[lstExaminations.Items.Count];
            publicSubsNFunctions.total_mark = new int[lstExaminations.Items.Count];
            publicSubsNFunctions.tms = new object[lstExaminations.Items.Count];
            publicSubsNFunctions.yrs = new object[lstExaminations.Items.Count];
            var loopTo = publicSubsNFunctions.tables.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                publicSubsNFunctions.tables[i] = lstExaminations.Items[i].Text;
                publicSubsNFunctions.total_mark[i] = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(lstExaminations.Items[i].Text, lstExaminations.Items[i].SubItems[3].Text));
                publicSubsNFunctions.contribution[i] = Conversions.ToInteger(lstExaminations.Items[i].SubItems[1].Text);
                publicSubsNFunctions.tms[i] = lstExaminations.Items[i].SubItems[3].Text;
                publicSubsNFunctions.yrs[i] = lstExaminations.Items[i].SubItems[2].Text;
            }

            publicSubsNFunctions.class_form = Conversions.ToString(publicSubsNFunctions.get_name(Conversions.ToString(cboClass.SelectedItem)));
            publicSubsNFunctions.exam_names = new object[lstExaminations.Items.Count];
            var loopTo1 = lstExaminations.Items.Count - 1;
            for (i = 0; i <= loopTo1; i++)
                publicSubsNFunctions.exam_names[i] = lstExaminations.Items[i].Text;
            publicSubsNFunctions.table = "exam_results";
            for (int k = 0, loopTo2 = publicSubsNFunctions.tables.Length - 1; k <= loopTo2; k++)
            {
                if (publicSubsNFunctions.total_mark[k] == 0)
                {
                    publicSubsNFunctions.failure(" Program Cannot Perform The Requested Operation! Looks Like There's One Examination Which The Chosen Class Did Not Undertake!");
                    return;
                }
            }

            Close();
        }

        private void btnEnterMarks_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isvalid()))
            {
                publicSubsNFunctions.table = "exam_results";
                publicSubsNFunctions.search_teachers = true;
                publicSubsNFunctions.show_split = CheckBox1.Checked;
                publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
                // stream = cboStream.SelectedItem
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

                if (chkMode.Checked)
                {
                    publicSubsNFunctions.mode = true;
                    load_entry_form_many();
                }
                else
                {
                    chkMode.Checked = true;
                    publicSubsNFunctions.mode = true;
                    lstExaminations.Items.Clear();
                    var li = new ListViewItem();
                    li = lstExaminations.Items.Add(cboExamName.SelectedItem);
                    li.SubItems.Add("100");
                    li.SubItems.Add(cboYear.SelectedItem);
                    li.SubItems.Add(cboTerm.SelectedItem);
                    total_percentage += 100d;
                    load_entry_form_many();
                    // load_entry_form()
                }
            }
            else
            {
                publicSubsNFunctions.failure(msg);
            }
        }

        private void load_entry_form()
        {
            publicSubsNFunctions.table = "exam_results";
            publicSubsNFunctions.class_form = Conversions.ToString(publicSubsNFunctions.get_name(Conversions.ToString(cboClass.SelectedItem)));
            publicSubsNFunctions.exam_name = Conversions.ToString(cboExamName.SelectedItem);
            Close();
        }

        private void chkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMode.Checked)
            {
                btnAddExam.Enabled = true;
                txtContribution.Enabled = true;
                grpMultiExaminations.Enabled = true;
                CheckBox1.Checked = false;
                CheckBox1.Enabled = false;
            }
            else
            {
                lstExaminations.Items.Clear();
                CheckBox1.Enabled = true;
                btnAddExam.Enabled = false;
                txtContribution.Enabled = false;
                grpMultiExaminations.Enabled = false;
            }
        }

        private object exists(string str)
        {
            int i;
            string selectedTerm = string.Empty;
            var loopTo = lstExaminations.Items.Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject((lstExaminations.Items[i].Text ?? "") == (str ?? ""), Operators.ConditionalCompareObjectEqual(lstExaminations.Items[i].SubItems[2].Text, cboYear.SelectedItem, false)), Operators.ConditionalCompareObjectEqual(lstExaminations.Items[i].SubItems[3].Text, cboTerm.SelectedItem, false))))
                {
                    Interaction.MsgBox("The Exam Already Exist In The List");
                    return true;
                }
            }

            return false;
        }

        private void add_exam()
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboExamName.SelectedItem, publicSubsNFunctions.None, false), Information.IsNumeric(txtContribution.Text)), (txtContribution.Text ?? "") != (string.Empty ?? ""))))
            {
                if (Conversions.ToBoolean(!exists(Conversions.ToString(cboExamName.SelectedItem))))
                {
                    var li = new ListViewItem();
                    li = lstExaminations.Items.Add(cboExamName.SelectedItem);
                    li.SubItems.Add(txtContribution.Text);
                    li.SubItems.Add(cboYear.SelectedItem);
                    li.SubItems.Add(cboTerm.SelectedItem);
                    total_percentage += Conversions.ToDouble(txtContribution.Text);
                }
            }
        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            add_exam();
        }

        private void cboExamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtContribution.Clear();
            txtContribution.Focus();
            loadClasses();
        }

        private void txtContribution_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                add_exam();
            }
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            publicSubsNFunctions.get_class_subjects(Conversions.ToString(cboClass.SelectedItem));
        }
    }
}