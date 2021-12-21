using System;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmHeadTeacherComments
    {
        public frmHeadTeacherComments()
        {
            InitializeComponent();
            _btnSave.Name = "btnSave";
            _cboTrend.Name = "cboTrend";
        }

        private void frmHeadTeacherComments_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
        }

        private string recordID = string.Empty;

        private void check()
        {
            if (cboTrend.SelectedItem is object)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT id,comment FROM head_teachers_comments WHERE trend='", cboTrend.SelectedItem), "'"));
                publicSubsNFunctions.qread(ref argq);
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    btnSave.Text = "Update";
                    publicSubsNFunctions.dbreader.Read();
                    recordID = Conversions.ToString(publicSubsNFunctions.dbreader["id"]);
                    txtComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["comment"]);
                    publicSubsNFunctions.dbreader.Close();
                }
                else
                {
                    btnSave.Text = "Save";
                    publicSubsNFunctions.dbreader.Close();
                }
            }
        }

        private void cboTrend_SelectedIndexChanged(object sender, EventArgs e)
        {
            check();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                if (btnSave.Text == "Save")
                {
                    if (publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO head_teachers_comments VALUES(NULL, '", cboTrend.SelectedItem), "','"), publicSubsNFunctions.escape_string(txtComment.Text)), "')"))))
                    {
                        publicSubsNFunctions.success("Comments Successfully Saved!");
                        btnSave.Text = "Update";
                    }
                    else
                    {
                        publicSubsNFunctions.failure("Could not save comments");
                    }
                }
                else if (publicSubsNFunctions.qwrite("UPDATE head_teachers_comments SET comment='" + publicSubsNFunctions.escape_string(txtComment.Text) + "' WHERE id='" + recordID + "'"))
                {
                    publicSubsNFunctions.success("Comments Update Successfully Saved!");
                    check();
                }
                else
                {
                    publicSubsNFunctions.failure("could not save comments");
                }
            }
        }

        private bool verify()
        {
            if (string.IsNullOrEmpty(txtComment.Text))
            {
                ErrorProvider1.SetError(txtComment, "Please Enter The Performance Comment");
                publicSubsNFunctions.successful = false;
            }
            else if (cboTrend.SelectedItem is null)
            {
                ErrorProvider1.SetError(cboTrend, "Please Select The Performance Trend");
                publicSubsNFunctions.successful = false;
            }
            else
            {
                publicSubsNFunctions.successful = true;
            }

            return publicSubsNFunctions.successful;
        }
    }
}