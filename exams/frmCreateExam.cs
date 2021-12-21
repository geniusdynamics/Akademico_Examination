using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmCreateExam
    {
        public frmCreateExam()
        {
            InitializeComponent();
            _btnClear.Name = "btnClear";
            _btnSave.Name = "btnSave";
            _chkOtherName.Name = "chkOtherName";
        }

        private void frmCreateExam_Load(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.OrObject(!publicSubsNFunctions.connect(), !publicSubsNFunctions.get_subjects())))
            {
                Close();
            }

            var argcbo = cboYear;
            publicSubsNFunctions.fill_years(ref argcbo);
            cboYear = argcbo;
            lstClass.Items.Clear();
            var argcbo1 = cboTerm;
            publicSubsNFunctions.get_term(ref argcbo1);
            cboTerm = argcbo1;
            string argq = "SELECT distinct(class) from class_stream";
            publicSubsNFunctions.qread(ref argq);
            while (publicSubsNFunctions.dbreader.Read())
            {
                var li = new ListViewItem();
                li = lstClass.Items.Add(publicSubsNFunctions.dbreader["class"]);
                li.Checked = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            cboTerm.SelectedItem = null;
            cboExamName.SelectedItem = null;
            chkOtherName.Checked = false;
            cboExamName.Enabled = true;
            txtExamName.Clear();
            txtTotal.Clear();
        }

        private string msg = string.Empty;

        private object isvalid()
        {
            if (cboTerm.SelectedItem is null)
            {
                msg = "Invalid Selection for Term!";
                return false;
            }
            else if (cboYear.SelectedItem is null)
            {
                msg = "Please Select The Examination Year";
                return false;
            }
            else if (cboExamName.SelectedItem is null & !chkOtherName.Checked)
            {
                msg = "Exam Name is invalid!";
                return false;
            }
            else if (chkOtherName.Checked & (txtExamName.Text ?? "") == (string.Empty ?? ""))
            {
                msg = "Exam Name is invalid!";
                return false;
            }
            else if ((txtTotal.Text ?? "") == (string.Empty ?? "") | !Information.IsNumeric(txtTotal.Text))
            {
                msg = "Total Marks is invalid!";
                return false;
            }
            else if (Conversions.ToBoolean(exists()))
            {
                msg = "Examination Already Exists!";
                return false;
            }
            else if (DateTimePicker1.Value.Date < DateAndTime.Today.Date)
            {
                msg = "Invalid Date For Last Date Of Marks Entry";
                return false;
            }
            else
            {
                return true;
            }
        }

        private string exam_name = string.Empty;

        private object exists()
        {
            if (chkOtherName.Checked)
            {
                exam_name = Strings.Trim(txtExamName.Text);
            }
            else
            {
                exam_name = Conversions.ToString(cboExamName.SelectedItem);
            }

            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM examinations WHERE (Term='", cboTerm.SelectedItem), "' AND ExamName='"), exam_name), "' AND Year='"), cboYear.SelectedItem), "')"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.Read())
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
                publicSubsNFunctions.failure("Could Not Correctly Confirm If Examination Already Exists!");
                return false;
            }
        }

        private void add_exam()
        {
            if (chkOtherName.Checked)
            {
                exam_name = Strings.Trim(txtExamName.Text);
            }
            else
            {
                exam_name = Conversions.ToString(cboExamName.SelectedItem);
            }

            publicSubsNFunctions.start();
            if (publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO examinations VALUES(NULL, '", cboTerm.SelectedItem), "','"), publicSubsNFunctions.escape_string(exam_name)), "','"), Strings.Trim(txtTotal.Text)), "','"), cboYear.SelectedItem), "', '"), DateTimePicker1.Value.Year), "-"), Strings.Format(DateTimePicker1.Value.Month, "00")), "-"), Strings.Format(DateTimePicker1.Value.Day, "00")), "')"))) & SaveExaminedClasses() & SaveSubjectsOutOf())
            {
                publicSubsNFunctions.commit();
                publicSubsNFunctions.success("Examination Successfully Saved!");
            }
            else
            {
                publicSubsNFunctions.rollback();
                publicSubsNFunctions.failure("Examination Could not be successfully Saved!");
            }
        }

        public bool SaveSubjectsOutOf()
        {
            string list = null;
            string values = null;
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                list = Conversions.ToString(list + publicSubsNFunctions.subjname[k]);
                values += txtTotal.Text;
                if (k < publicSubsNFunctions.subjabb.Length - 1)
                {
                    list += ",";
                    values += ",";
                }
            }

            for (int k = 0, loopTo1 = lstClass.Items.Count - 1; k <= loopTo1; k++)
            {
                string argq = "SELECT `stream` FROM class_stream WHERE class='" + publicSubsNFunctions.escape_string(lstClass.Items[k].Text) + "';";
                publicSubsNFunctions.qread(ref argq);
                while (publicSubsNFunctions.dbreader.Read())
                {
                    if (!publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO exam_results_subjects_out_of (id, Examination, Term, Year, Class, Stream, " + list + ") VALUES" + "(NULL, '" + publicSubsNFunctions.escape_string(exam_name) + "','", cboTerm.SelectedItem), "','"), cboYear.SelectedItem), "', '"), publicSubsNFunctions.escape_string(lstClass.Items[k].Text)), "', '"), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.dbreader["stream"]))), "', "), values), ")"))))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool SaveExaminedClasses()
        {
            for (int k = 0, loopTo = lstClass.Items.Count - 1; k <= loopTo; k++)
            {
                if (lstClass.Items[k].Checked)
                {
                    if (!publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO examined_classes (`id`, `examination`, `term`, `year`, `class` ) VALUES(NULL, '" + publicSubsNFunctions.escape_string(exam_name) + "', '", cboTerm.SelectedItem), "','"), cboYear.SelectedItem), "','"), publicSubsNFunctions.escape_string(lstClass.Items[k].Text)), "')"))))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void chkOtherName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherName.Checked)
            {
                txtExamName.Enabled = true;
                cboExamName.SelectedItem = null;
                cboExamName.Enabled = false;
            }
            else
            {
                txtExamName.Enabled = false;
                cboExamName.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isvalid()))
            {
                try
                {
                    add_exam();
                    clear();
                }
                catch (Exception ex)
                {
                    publicSubsNFunctions.failure(ex.Message);
                }
            }
            else
            {
                publicSubsNFunctions.failure(msg);
            }
        }
    }
}