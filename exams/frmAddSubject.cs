using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmAddSubject
    {
        public frmAddSubject()
        {
            InitializeComponent();
            _btnRegister.Name = "btnRegister";
            _btnClear.Name = "btnClear";
            _btnCancel.Name = "btnCancel";
        }

        private string msg;
        private string opt;

        private object isvalid()
        {
            if ((Strings.Trim(txtName.Text) ?? "") == (string.Empty ?? "") | Information.IsNumeric(txtName.Text))
            {
                msg = "Subject Name is invalid!";
                return false;
            }
            else if ((Strings.Trim(txtAbbreviation.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "Subject Abbreviation is invalid!";
                return false;
            }
            else if ((Strings.Trim(txtCode.Text) ?? "") == (string.Empty ?? "") | !Information.IsNumeric(txtCode.Text))
            {
                msg = "Subject Code Is Invalid!";
                return false;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboDepartment.SelectedItem, publicSubsNFunctions.None, false)))
            {
                msg = "Invalid Values Selected For Department!";
                return false;
            }
            else if (!radCompulsory.Checked & !radOptional.Checked)
            {
                msg = "Invalid Subject Comment! Compulsory Or Optional?";
                return false;
            }
            else
            {
                return true;
            }
        }

        private string LastValidColumn()
        {
            string argq = "SELECT Abbreviation FROM subjects ORDER BY id DESC LIMIT 1";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                return Conversions.ToString(publicSubsNFunctions.dbreader["Abbreviation"]);
            }
            else
            {
            }

            return default;
        }

        private string get_one_subject()
        {
            publicSubsNFunctions.get_subjects();
            return Conversions.ToString(publicSubsNFunctions.subjname[0]);
        }

        private bool add_instances(string subject)
        {
            if (!publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `exam_results` ADD COLUMN `", publicSubsNFunctions.get_name(publicSubsNFunctions.escape_string(txtAbbreviation.Text))), "` VARCHAR(255) NOT NULL DEFAULT '-' AFTER `Year`"))) | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `kcse_results` ADD COLUMN `", publicSubsNFunctions.get_name(publicSubsNFunctions.escape_string(txtAbbreviation.Text))), "` VARCHAR(255) NOT NULL DEFAULT '-' AFTER `stream`"))) | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `subjects_done` ADD COLUMN `", publicSubsNFunctions.get_name(txtAbbreviation.Text)), "` ENUM('Yes','No') NOT NULL DEFAULT 'No'"))) | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `exam_results_subjects_out_of` ADD COLUMN `", publicSubsNFunctions.get_name(publicSubsNFunctions.escape_string(txtAbbreviation.Text))), "` DOUBLE NOT NULL DEFAULT '100' AFTER `year`"))) | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("UPDATE exam_results_subjects_out_of SET `", publicSubsNFunctions.get_name(publicSubsNFunctions.escape_string(txtAbbreviation.Text))), "`=`"), get_one_subject()), "`"))))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string[] words;
        private string col;

        private void add_subject()
        {
            publicSubsNFunctions.start();
            col = LastValidColumn();
            if (publicSubsNFunctions.qwrite("INSERT INTO subjects VALUES(NULL,'" + publicSubsNFunctions.escape_string(Strings.Trim(txtName.Text).ToUpper()) + "','" + publicSubsNFunctions.escape_string(Strings.Trim(txtAbbreviation.Text).ToUpper()) + "','" + Strings.Trim(txtCode.Text) + "','" + publicSubsNFunctions.escape_string(Conversions.ToString(cboDepartment.SelectedItem)) + "','" + opt + "', '--', 'Yes' )") & add_instances(txtName.Text))
            {
                publicSubsNFunctions.commit();
                publicSubsNFunctions.success("Subject Entry Was Successful!");
            }
            else
            {
                publicSubsNFunctions.rollback();
                publicSubsNFunctions.failure("Subject Entry Failed! Subject Exists!");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isvalid()))
            {
                if (radCompulsory.Checked)
                {
                    opt = "Compulsory";
                }
                else
                {
                    opt = "Optional";
                }

                if (subjects.ContainsKey(txtName.Text.ToLower()))
                {
                    publicSubsNFunctions.failure("The Subject Has Already Been Added Into The System");
                    return;
                }
                else if (subjects.ContainsValue(txtCode.Text.ToLower()))
                {
                    publicSubsNFunctions.failure("The Subject Has Already Been Used In The System");
                    return;
                }

                add_subject();
            }
            else
            {
                publicSubsNFunctions.failure(msg);
            }
        }

        private void frmAddSubject_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                load_dept();
            }
        }

        private Dictionary<string, string> subjects = new Dictionary<string, string>();

        private void loadSubjectsInfo()
        {
            string argq = "select subject, abbreviation from subjects;";
            if (publicSubsNFunctions.qread(ref argq))
            {
                subjects.Clear();
                while (publicSubsNFunctions.dbreader.Read())
                    subjects.Add(publicSubsNFunctions.dbreader["subject"].ToString().ToLower(), publicSubsNFunctions.dbreader["abbreviation"].ToString().ToLower());
                publicSubsNFunctions.dbreader.Close();
            }
        }

        private void load_dept()
        {
            string argq = "SELECT * FROM departments";
            if (publicSubsNFunctions.qread(ref argq))
            {
                cboDepartment.Items.Clear();
                while (publicSubsNFunctions.dbreader.Read())
                    cboDepartment.Items.Add(publicSubsNFunctions.dbreader["department"]);
                cboDepartment.SelectedItem = publicSubsNFunctions.None;
                publicSubsNFunctions.dbreader.Close();
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Read Departments Database!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            cboDepartment.SelectedItem = publicSubsNFunctions.None;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}