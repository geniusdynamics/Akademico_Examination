using System;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmPerformanceComments
    {
        public frmPerformanceComments()
        {
            InitializeComponent();
            _btnSave.Name = "btnSave";
            _cboTrend.Name = "cboTrend";
            _cboStream.Name = "cboStream";
            _cboClass.Name = "cboClass";
        }

        private void frmPerformanceComments_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                var argcbo = cboClass;
                publicSubsNFunctions.load_class(ref argcbo);
                cboClass = argcbo;
                var argcbo1 = cboStream;
                publicSubsNFunctions.load_stream(ref argcbo1);
                cboStream = argcbo1;
            }
        }

        private bool verify()
        {
            if (cboClass.SelectedItem is null)
            {
                ErrorProvider1.SetError(cboClass, "Please Select The Class");
                publicSubsNFunctions.successful = false;
            }
            else if (cboStream.SelectedItem is null)
            {
                ErrorProvider1.SetError(cboStream, "Please Select The Stream");
                publicSubsNFunctions.successful = false;
            }
            else if (cboTrend.SelectedItem is null)
            {
                ErrorProvider1.SetError(cboTrend, "Please Select The Performance Trend");
                publicSubsNFunctions.successful = false;
            }
            else if ((txtComment.Text ?? "") == (string.Empty ?? ""))
            {
                ErrorProvider1.SetError(txtComment, "Please Enter The Performance Comments");
                publicSubsNFunctions.successful = false;
            }
            else
            {
                publicSubsNFunctions.successful = true;
            }

            return publicSubsNFunctions.successful;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                // todo foreign key reference for the class and stream on update cascade on delete cascade
                if (btnSave.Text == "Save")
                {
                    if (publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO class_teachers_comments VALUES(NULL, '" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "', '" + publicSubsNFunctions.escape_string(Conversions.ToString(cboStream.SelectedItem)) + "', '", cboTrend.SelectedItem), "','"), publicSubsNFunctions.escape_string(txtComment.Text)), "')"))))
                    {
                        publicSubsNFunctions.success("Comments Successfully Saved!");
                        btnSave.Text = "Update";
                    }
                    else
                    {
                        publicSubsNFunctions.failure("Could Not Save The Details!");
                    }
                }
                else if (publicSubsNFunctions.qwrite("UPDATE class_teachers_comments SET comment='" + publicSubsNFunctions.escape_string(txtComment.Text) + "' WHERE id='" + recordId + "'"))
                {
                    publicSubsNFunctions.success("Comments Update Successful!");
                    check();
                }
                else
                {
                    publicSubsNFunctions.failure("Could Not Save The Details!");
                }
            }
        }

        private string recordId;

        private void check()
        {
            if (cboClass.SelectedItem is object & cboStream.SelectedItem is object & cboTrend.SelectedItem is object)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT id,comment FROM class_teachers_comments WHERE (class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "' AND stream='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboStream.SelectedItem)) + "' AND trend='", cboTrend.SelectedItem), "')"));
                publicSubsNFunctions.qread(ref argq);
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    btnSave.Text = "Update";
                    publicSubsNFunctions.dbreader.Read();
                    recordId = Conversions.ToString(publicSubsNFunctions.dbreader["id"]);
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

        private void cboStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            check();
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            check();
        }

        private void cboTrend_SelectedIndexChanged(object sender, EventArgs e)
        {
            check();
        }
    }
}