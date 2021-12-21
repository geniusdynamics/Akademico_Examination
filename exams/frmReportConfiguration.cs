using System;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmReportConfiguration
    {
        public frmReportConfiguration()
        {
            InitializeComponent();
            _Button1.Name = "Button1";
        }

        private void frmReportConfiguration_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                loadDefaults();
            }
        }

        private string operationType = string.Empty;

        private void loadDefaults()
        {
            string argq = "SELECT * FROM report_configuration";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                chkClubSociety.Checked = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["club_and_societies"]));
                chkCTC.Checked = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["class_teacher_comments"]));
                chkCTS.Checked = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["class_teacher_signature"]));
                chkHouse.Checked = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["house_master_comments"]));
                chkHTC.Checked = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["head_teacher_comments"]));
                chkHTS.Checked = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["head_teacher_signature"]));
                chkLogo.Checked = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["school_logo"]));
                chkPhoto.Checked = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["student_photo"]));
                chkHTN.Checked = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["head_teacher_name"]));
                chkCTN.Checked = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["class_teacher_name"]));
                operationType = "Update";
            }
            else
            {
                operationType = "Insert";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (operationType == "Insert")
            {
                publicSubsNFunctions.query = "Insert into report_configuration SET student_photo=";
            }
            else
            {
                publicSubsNFunctions.query = "UPDATE report_configuration SET student_photo=";
            }

            if (chkPhoto.Checked)
            {
                publicSubsNFunctions.query += "1,";
            }
            else
            {
                publicSubsNFunctions.query += "0,";
            }

            publicSubsNFunctions.query += "school_logo=";
            if (chkLogo.Checked)
            {
                publicSubsNFunctions.query += "1,";
            }
            else
            {
                publicSubsNFunctions.query += "0,";
            }

            publicSubsNFunctions.query += "class_teacher_signature=";
            if (chkCTS.Checked)
            {
                publicSubsNFunctions.query += "1,";
            }
            else
            {
                publicSubsNFunctions.query += "0,";
            }

            publicSubsNFunctions.query += "head_teacher_signature=";
            if (chkHTS.Checked)
            {
                publicSubsNFunctions.query += "1,";
            }
            else
            {
                publicSubsNFunctions.query += "0,";
            }

            publicSubsNFunctions.query += "class_teacher_comments=";
            if (chkCTC.Checked)
            {
                publicSubsNFunctions.query += "1,";
            }
            else
            {
                publicSubsNFunctions.query += "0,";
            }

            publicSubsNFunctions.query += "head_teacher_comments=";
            if (chkHTC.Checked)
            {
                publicSubsNFunctions.query += "1,";
            }
            else
            {
                publicSubsNFunctions.query += "0,";
            }

            publicSubsNFunctions.query += "house_master_comments=";
            if (chkHouse.Checked)
            {
                publicSubsNFunctions.query += "1,";
            }
            else
            {
                publicSubsNFunctions.query += "0,";
            }

            publicSubsNFunctions.query += "head_teacher_name=";
            if (chkHTN.Checked)
            {
                publicSubsNFunctions.query += "1,";
            }
            else
            {
                publicSubsNFunctions.query += "0,";
            }

            publicSubsNFunctions.query += "class_teacher_name=";
            if (chkCTN.Checked)
            {
                publicSubsNFunctions.query += "1,";
            }
            else
            {
                publicSubsNFunctions.query += "0,";
            }

            publicSubsNFunctions.query += "club_and_societies=";
            if (chkHouse.Checked)
            {
                publicSubsNFunctions.query += "1";
            }
            else
            {
                publicSubsNFunctions.query += "0";
            }

            if (publicSubsNFunctions.qwrite(publicSubsNFunctions.query))
            {
                publicSubsNFunctions.success("Report Form Configuration Successfully Saved!");
                loadDefaults();
            }
            else
            {
                publicSubsNFunctions.failure("Report Form Configuration Could Not Be Saved!");
            }
        }
    }
}