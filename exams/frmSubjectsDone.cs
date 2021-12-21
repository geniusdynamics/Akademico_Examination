using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmSubjectsDone
    {
        public frmSubjectsDone()
        {
            InitializeComponent();
            _btnview.Name = "btnview";
            _cboClass.Name = "cboClass";
            _btnEnterMarks.Name = "btnEnterMarks";
        }

        private void frmSubjectsDone_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                // Dim frm As New frmSelectClass
                // frm.ShowDialog()
                // If cont Then
                // create_dataform()
                // load_students()
                // Else
                // Me.Close()
                // End If

                string argq = "select distinct class from class_stream";
                if (publicSubsNFunctions.qread(ref argq))
                {
                    if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                    {
                        cboClass.Items.Clear();
                        while (publicSubsNFunctions.dbreader.Read())
                            cboClass.Items.Add(publicSubsNFunctions.dbreader["class"]);
                    }
                }
            }
        }

        private void load_students()
        {
            string q = string.Empty;
            if (cboStream.SelectedItem is object)
            {
                q = Conversions.ToString(Operators.ConcatenateObject("SELECT * FROM students WHERE Class='" + publicSubsNFunctions.escape_string(cboClass.SelectedItem.ToString()), Operators.AddObject(Operators.AddObject("' AND IsStudent='True' and stream  = '", cboStream.SelectedItem), "'")));
            }
            else
            {
                q = "SELECT * FROM students WHERE Class='" + publicSubsNFunctions.escape_string(cboClass.SelectedItem.ToString()) + "' AND IsStudent='True'";
            }

            publicSubsNFunctions.qread(ref q);
            dgvIndexNo.Rows.Clear();
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                var row = new List<string>();
                while (publicSubsNFunctions.dbreader.Read())
                {
                    row.Add(Conversions.ToString(publicSubsNFunctions.dbreader["admin_no"]));
                    row.Add(Conversions.ToString(publicSubsNFunctions.dbreader["student_name"]));
                    row.Add(Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                    row.Add(Conversions.ToString(publicSubsNFunctions.dbreader["indexno"]));
                    dgvIndexNo.Rows.Add(row.ToArray());
                    row.Clear();
                    // dgvIndexNo.Rows.Add()
                    // dgvIndexNo.Item("ADMNo", dgvIndexNo.Rows.Count - 1).Value = get_id(dbreader("admin_no"))
                    // dgvIndexNo.Item("StudentName", dgvIndexNo.Rows.Count - 1).Value = dbreader("student_name")
                    // dgvIndexNo.Item("str_class", dgvIndexNo.Rows.Count - 1).Value = dbreader("Stream")
                    // dgvIndexNo.Item("IndexNo", dgvIndexNo.Rows.Count - 1).Value = dbreader("indexno")
                }

                for (int k = 0, loopTo = dgvIndexNo.Rows.Count - 1; k <= loopTo; k++)
                {
                    string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `subjects_done` WHERE ADMNo='", dgvIndexNo["ADMNo", k].Value), "'"));
                    publicSubsNFunctions.qread(ref argq);
                    if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                    {
                        publicSubsNFunctions.dbreader.Read();
                        for (int s = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo1; s++)
                        {
                            try
                            {
                                dgvIndexNo.Item(publicSubsNFunctions.subjname[s], k).Value = publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[s]);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    else
                    {
                        publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO `subjects_done`(ADMNo) VALUES('", dgvIndexNo["ADMNo", k].Value), "')")));
                        for (int s = 0, loopTo2 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo2; s++)
                            dgvIndexNo.Item(publicSubsNFunctions.subjname[s], k).value = "Yes";
                    }
                }
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

                Close();
            }
        }

        private void create_dataform()
        {
            publicSubsNFunctions.get_subjects();
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                var column = new DataGridViewComboBoxColumn();
                column.Name = Conversions.ToString(publicSubsNFunctions.subjname[k]);
                column.Items.Add("Yes");
                column.Items.Add("No");
                column.Width = 55;
                dgvIndexNo.Columns.Add(column);
            }
        }

        private void btnEnterMarks_Click(object sender, EventArgs e)
        {
            for (int line = 0, loopTo = dgvIndexNo.Rows.Count - 1; line <= loopTo; line++)
            {
                for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                {
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(dgvIndexNo.Item(publicSubsNFunctions.subjname[k], line).value, "No", false), Operators.ConditionalCompareObjectNotEqual(dgvIndexNo.Item(publicSubsNFunctions.subjname[k], line).value, "Yes", false))))
                    {
                        publicSubsNFunctions.failure(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Invalid Value For ", publicSubsNFunctions.subjects[k]), " On Row Number "), line + 1)));
                        return;
                    }
                }
            }

            publicSubsNFunctions.start();
            for (int k = 0, loopTo2 = dgvIndexNo.Rows.Count - 1; k <= loopTo2; k++)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `subjects_done` WHERE ADMNo='", dgvIndexNo["ADMNo", k].Value), "'"));
                publicSubsNFunctions.qread(ref argq);
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    publicSubsNFunctions.dbreader.Close();
                    publicSubsNFunctions.query = "UPDATE `subjects_done` SET ";
                    for (int s = 0, loopTo3 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo3; s++)
                    {
                        publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("`", publicSubsNFunctions.subjname[s]), "`='"), dgvIndexNo.Item(publicSubsNFunctions.subjname[s], k).value), "'"));
                        if (s < publicSubsNFunctions.subjabb.Length - 1)
                        {
                            publicSubsNFunctions.query += ", ";
                        }
                    }

                    publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject(" WHERE ADMNo='", dgvIndexNo["ADMNo", k].Value), "'"));
                    if (!publicSubsNFunctions.qwrite(publicSubsNFunctions.query))
                    {
                        publicSubsNFunctions.rollback();
                        publicSubsNFunctions.failure("Could Not Save The Data!");
                        return;
                    }
                }
                else
                {
                    publicSubsNFunctions.dbreader.Close();
                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO `subjects_done` VALUES('", dgvIndexNo["ADMNo", k].Value), "',"));
                    for (int s = 0, loopTo4 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo4; s++)
                    {
                        publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject("'", dgvIndexNo.Item(publicSubsNFunctions.subjname[s], k).value), "',"));
                        if (s == publicSubsNFunctions.subjabb.Length - 1)
                        {
                            publicSubsNFunctions.query += ")";
                        }
                    }

                    if (!publicSubsNFunctions.qwrite(publicSubsNFunctions.query))
                    {
                        publicSubsNFunctions.rollback();
                        publicSubsNFunctions.failure("Could Not Save The Data!");
                        return;
                    }
                }
            }

            publicSubsNFunctions.commit();
            publicSubsNFunctions.success("Student Subject Choices Successfully Saved!");
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            if (cboClass.SelectedItem is object)
            {
                create_dataform();
                load_students();
            }
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClass.SelectedItem is object)
            {
                string argq = Conversions.ToString(Operators.AddObject(Operators.AddObject("select distinct stream from class_stream where class = '", cboClass.SelectedItem), "'"));
                if (publicSubsNFunctions.qread(ref argq))
                {
                    if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                    {
                        cboStream.Items.Clear();
                        while (publicSubsNFunctions.dbreader.Read())
                            cboStream.Items.Add(publicSubsNFunctions.dbreader["stream"]);
                    }
                }
            }
        }
    }
}