using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmIndexNumbers
    {
        public frmIndexNumbers()
        {
            InitializeComponent();
            _btnClear.Name = "btnClear";
            _btnEnterMarks.Name = "btnEnterMarks";
            _btnEnter.Name = "btnEnter";
            _cboStream.Name = "cboStream";
            _cboClass.Name = "cboClass";
        }

        private void frmIndexNumbers_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                load_code();
                var argcbo = cboClass;
                publicSubsNFunctions.load_class(ref argcbo);
                cboClass = argcbo;
            }
        }

        private void load_code()
        {
            string argq = "SELECT code FROM school_details";
            publicSubsNFunctions.qread(ref argq);
            publicSubsNFunctions.dbreader.Read();
            txtCode.Text = Conversions.ToString(publicSubsNFunctions.dbreader["code"]);
            publicSubsNFunctions.dbreader.Close();
        }

        private object index_no(int adm)
        {
            object index_noRet = default;
            string argq = "SELECT indexno FROM students WHERE admin_no='" + adm + "'";
            publicSubsNFunctions.qread(ref argq);
            try
            {
                publicSubsNFunctions.dbreader.Read();
                index_noRet = publicSubsNFunctions.dbreader["indexno"];
            }
            catch (Exception ex)
            {
                index_noRet = 0;
            }

            publicSubsNFunctions.dbreader.Close();
            return index_noRet;
        }

        private void load_students()
        {
            dgvIndexNo.Rows.Clear();
            publicSubsNFunctions.qread(ref publicSubsNFunctions.query);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                var rows = new List<string>();
                while (publicSubsNFunctions.dbreader.Read())
                {
                    // dgvIndexNo.Rows.Add()
                    // dgvIndexNo.Item("ADMNo", dgvIndexNo.Rows.Count - 1).Value = get_id(dbreader("admin_no"))
                    // dgvIndexNo.Item("StudentName", dgvIndexNo.Rows.Count - 1).Value = dbreader("student_name")
                    // dgvIndexNo.Item("str_class", dgvIndexNo.Rows.Count - 1).Value = dbreader("Stream")
                    rows.Add(Conversions.ToString(publicSubsNFunctions.dbreader["admin_no"]));
                    rows.Add(Conversions.ToString(publicSubsNFunctions.dbreader["student_name"]));
                    rows.Add(Conversions.ToString(publicSubsNFunctions.dbreader["stream"]));
                    dgvIndexNo.Rows.Add(rows.ToArray());
                    rows.Clear();
                }

                publicSubsNFunctions.dbreader.Close();
                for (int k = 0, loopTo = dgvIndexNo.Rows.Count - 1; k <= loopTo; k++)
                    dgvIndexNo["IndexNo", k].Value = index_no(Conversions.ToInteger(dgvIndexNo["ADMNo", k].Value));
            }
            else
            {
                publicSubsNFunctions.failure("There Were No Matching Student Records For This Operation!");
                try
                {
                    publicSubsNFunctions.dbreader.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int k = 0, loopTo = dgvIndexNo.Rows.Count - 1; k <= loopTo; k++)
                dgvIndexNo["IndexNo", k].Value = 0;
        }

        private void btnEnterMarks_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.start();
            int inc;
            if (dgvIndexNo.Rows.Count > 100)
            {
                inc = (int)Math.Round(dgvIndexNo.Rows.Count / 100d);
            }
            else
            {
                inc = (int)Math.Round(100d / dgvIndexNo.Rows.Count);
            }

            for (int k = 0, loopTo = dgvIndexNo.Rows.Count - 1; k <= loopTo; k++)
            {
                string index = Conversions.ToString(dgvIndexNo["IndexNo", k].Value);
                if (index.Length < 4)
                {
                    index = txtCode.Text + index;
                }

                if (!publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("UPDATE students SET indexno='" + index + "' WHERE admin_no='", dgvIndexNo["ADMNo", k].Value), "'"))))
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Could Not Save Records!");
                    ProgressBar1.Visible = false;
                    return;
                }

                ProgressBar1.Increment(inc);
            }

            publicSubsNFunctions.commit();
            publicSubsNFunctions.success("Records Successfully Saved!");
            ProgressBar1.Visible = false;
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            var argcbo = cboStream;
            publicSubsNFunctions.fill_class(Conversions.ToString(cboClass.SelectedItem), ref argcbo);
            cboStream = argcbo;
            publicSubsNFunctions.query = "SELECT * FROM students WHERE Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "' AND IsStudent='True' ORDER BY indexno ASC";
            load_students();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboStream.SelectedItem, "All", false)))
            {
                publicSubsNFunctions.query = "SELECT * FROM students WHERE Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "' AND IsStudent='True' ORDER BY indexno ASC";
            }
            else
            {
                publicSubsNFunctions.query = "SELECT * FROM students WHERE Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "' AND Stream='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboStream.SelectedItem)) + "' ORDER BY indexno ASC";
            }

            load_students();
        }

        private void cboStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboStream.SelectedItem, "All", false)))
            {
                publicSubsNFunctions.query = "SELECT * FROM students WHERE Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "' AND IsStudent='True'";
            }
            else
            {
                publicSubsNFunctions.query = "SELECT * FROM students WHERE Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "' AND stream='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboStream.SelectedItem)) + "' AND IsStudent='True'";
            }

            load_students();
        }
    }
}