using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmAllStudentsPrompt
    {
        public frmAllStudentsPrompt()
        {
            InitializeComponent();
            _btnCancel.Name = "btnCancel";
            _btnSearch.Name = "btnSearch";
            _txtName.Name = "txtName";
        }

        private object isvalid()
        {
            if ((Strings.Trim(txtName.Text) ?? "") == (string.Empty ?? ""))
            {
                publicSubsNFunctions.msg = "Admission Number Cannot Be Empty!";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void show_students()
        {
            publicSubsNFunctions.query = "SELECT admin_no, student_name, Class FROM students WHERE admin_no LIKE '%" + publicSubsNFunctions.escape_string(txtName.Text) + "%' AND IsStudent='True'";
            if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 1)
                {
                    var frm = new frmAllStudents();
                    frm.ShowDialog();
                }
                else
                {
                    try
                    {
                        publicSubsNFunctions.dbreader.Read();
                        publicSubsNFunctions.t_name = Conversions.ToString(publicSubsNFunctions.dbreader["student_name"]);
                        publicSubsNFunctions.t_id = Conversions.ToInteger(publicSubsNFunctions.dbreader["admin_no"]);
                        publicSubsNFunctions.cont = true;
                    }
                    catch (Exception ex)
                    {
                        publicSubsNFunctions.failure("No Matching Student Records Found!");
                        publicSubsNFunctions.cont = false;
                    }
                }
            }

            if (publicSubsNFunctions.cont)
            {
                Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isvalid()))
            {
                show_students();
            }
            else
            {
                publicSubsNFunctions.failure(publicSubsNFunctions.msg);
            }
        }

        private void frmAllStudentsPrompt_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.cont = false;
            Close();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (Conversions.ToBoolean(isvalid()))
                {
                    show_students();
                }
            }
        }
    }
}