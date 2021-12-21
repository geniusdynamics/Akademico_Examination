using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmModifySubject
    {
        public frmModifySubject()
        {
            InitializeComponent();
            _dgvSubjects.Name = "dgvSubjects";
            _btnUpdate.Name = "btnUpdate";
            _btnClear.Name = "btnClear";
            _btnCancel.Name = "btnCancel";
        }

        private string msg;
        private bool state = false;

        private void frmModifySubject_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                load_subjects();
                load_dept();
            }
        }

        private void load_dept()
        {
            string argq = "SELECT * FROM departments";
            if (publicSubsNFunctions.qread(ref argq))
            {
                while (publicSubsNFunctions.dbreader.Read())
                    cboDepartment.Items.Add(publicSubsNFunctions.dbreader["department"]);
                cboDepartment.SelectedItem = publicSubsNFunctions.None;
                publicSubsNFunctions.dbreader.Close();
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Read From Departments Database!");
            }
        }

        private void load_subjects()
        {
            state = false;
            string argq = "SELECT * FROM subjects";
            if (publicSubsNFunctions.qread(ref argq))
            {
                int i = 0;
                dgvSubjects.Rows.Clear();
                while (publicSubsNFunctions.dbreader.Read())
                {
                    dgvSubjects.Rows.Add();
                    dgvSubjects["SubjID", i].Value = publicSubsNFunctions.dbreader["ID"];
                    dgvSubjects["SubjectName", i].Value = publicSubsNFunctions.dbreader["Subject"];
                    dgvSubjects["Code", i].Value = publicSubsNFunctions.dbreader["subjectCode"];
                    dgvSubjects["Abbreviation", i].Value = publicSubsNFunctions.dbreader["Abbreviation"];
                    dgvSubjects["Department", i].Value = publicSubsNFunctions.dbreader["Department"];
                    dgvSubjects["Comment", i].Value = publicSubsNFunctions.dbreader["Comment"];
                    i += 1;
                }

                publicSubsNFunctions.dbreader.Close();
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Read From Subjects Database!");
            }

            state = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAbbreviation.Clear();
            cboDepartment.SelectedItem = publicSubsNFunctions.None;
        }

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
                msg = "Comment On Subject is Not Valid!";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void up_date()
        {
            string comment;
            if (radCompulsory.Checked)
            {
                comment = "Compulsory";
            }
            else
            {
                comment = "Optional";
            }

            publicSubsNFunctions.start();
            if (publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("UPDATE subjects SET `Subjectcode`='" + Strings.Trim(txtCode.Text) + "', Subject='" + publicSubsNFunctions.escape_string(Strings.Trim(txtName.Text).ToUpper()) + "',Abbreviation='" + publicSubsNFunctions.escape_string(Strings.Trim(txtAbbreviation.Text).ToUpper()) + "',Department='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboDepartment.SelectedItem)) + "', Comment='" + comment + "' WHERE ID ='", dgvSubjects["SubjID", dgvSubjects.SelectedRows[0].Index].Value), "'"))) & update_instances(txtAbbreviation.Text))
            {
                publicSubsNFunctions.commit();
                publicSubsNFunctions.success("Subject Update Was Successful!");
            }
            else
            {
                publicSubsNFunctions.rollback();
                publicSubsNFunctions.failure("Subject Update Failed! Duplicate Entry For Subject Details!");
            }
        }

        private string subjectfrom;

        private bool update_instances(string subjectto)
        {
            subjectto = Conversions.ToString(publicSubsNFunctions.get_name(subjectto));
            if (!publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `exam_results` CHANGE `", publicSubsNFunctions.get_name(subjectfrom)), "` `"), publicSubsNFunctions.get_name(subjectto)), "` VARCHAR(255) NOT NULL DEFAULT '-'"))) | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `exam_results_subjects_out_of` CHANGE `", publicSubsNFunctions.get_name(subjectfrom)), "` `"), publicSubsNFunctions.get_name(subjectto)), "` DOUBLE NOT NULL DEFAULT '100'"))) | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `kcse_results` CHANGE `", publicSubsNFunctions.get_name(subjectfrom)), "` `"), publicSubsNFunctions.get_name(subjectto)), "` VARCHAR(255) NOT NULL DEFAULT '-'"))) | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `subjects_done` CHANGE `", publicSubsNFunctions.get_name(subjectfrom)), "` `"), publicSubsNFunctions.get_name(subjectto)), "` ENUM('Yes','No') NOT NULL DEFAULT 'Yes'"))))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isvalid()))
            {
                up_date();
                load_subjects();
                fill();
            }
            else
            {
                publicSubsNFunctions.failure(msg);
            }
        }

        private void dgvSubjects_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (state)
            {
                fill();
            }
        }

        private string subject_full;

        private void fill()
        {
            try
            {
                txtName.Text = Conversions.ToString(dgvSubjects["SubjectName", dgvSubjects.SelectedRows[0].Index].Value);
                txtAbbreviation.Text = Conversions.ToString(dgvSubjects["Abbreviation", dgvSubjects.SelectedRows[0].Index].Value);
                txtCode.Text = dgvSubjects["Code", dgvSubjects.SelectedRows[0].Index].Value.ToString();
                subjectfrom = txtAbbreviation.Text;
                subject_full = txtName.Text;
                cboDepartment.SelectedItem = dgvSubjects["Department", dgvSubjects.SelectedRows[0].Index].Value;
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvSubjects["Comment", dgvSubjects.SelectedRows[0].Index].Value, "Compulsory", false)))
                {
                    radCompulsory.Checked = true;
                }
                else
                {
                    radOptional.Checked = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvSubjects_Click(object sender, EventArgs e)
        {
            fill();
        }
    }
}