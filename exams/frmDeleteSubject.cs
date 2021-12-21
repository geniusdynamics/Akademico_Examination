using System;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmDeleteSubject
    {
        public frmDeleteSubject()
        {
            InitializeComponent();
            _dgvSubjects.Name = "dgvSubjects";
            _btnDelete.Name = "btnDelete";
            _btnCancel.Name = "btnCancel";
        }

        private void frmDeleteSubject_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                load_subjects();
            }
        }

        private void load_subjects()
        {
            string argq = "SELECT * FROM subjects ORDER BY ID";
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    int i = 0;
                    dgvSubjects.Rows.Clear();
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        dgvSubjects.Rows.Add();
                        dgvSubjects["SubjID", i].Value = publicSubsNFunctions.dbreader["ID"];
                        dgvSubjects["SubjectName", i].Value = publicSubsNFunctions.dbreader["Subject"];
                        dgvSubjects["Abbreviation", i].Value = publicSubsNFunctions.dbreader["Abbreviation"];
                        dgvSubjects["Department", i].Value = publicSubsNFunctions.dbreader["Department"];
                        i += 1;
                    }
                }
                else
                {
                    publicSubsNFunctions.failure("No Subject Records Found To Delete!");
                    Close();
                }
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Read From  Subjects Database!");
                Close();
            }
        }

        private void dgvSubjects_DoubleClick(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Are you sure you want to delete subject?")))
            {
                for (int k = 0, loopTo = dgvSubjects.SelectedRows.Count - 1; k <= loopTo; k++)
                    delete(dgvSubjects.SelectedRows[k].Index);
                load_subjects();
            }
        }

        private bool del_instances(string subject, int row)
        {
            if (!publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `exam_results` DROP COLUMN `", publicSubsNFunctions.get_name(Conversions.ToString(dgvSubjects["Abbreviation", row].Value))), "`"))) | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `exam_results_subjects_out_of` DROP COLUMN `", publicSubsNFunctions.get_name(Conversions.ToString(dgvSubjects["Abbreviation", row].Value))), "`"))) | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `kcse_results` DROP COLUMN `", publicSubsNFunctions.get_name(Conversions.ToString(dgvSubjects["Abbreviation", row].Value))), "`"))) | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `subjects_done` DROP COLUMN `", publicSubsNFunctions.get_name(Conversions.ToString(dgvSubjects["Abbreviation", row].Value))), "`"))))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void delete(int row)
        {
            publicSubsNFunctions.start();
            for (int k = 0, loopTo = dgvSubjects.SelectedRows.Count - 1; k <= loopTo; k++)
            {
                if (!publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("DELETE FROM subjects WHERE id='", dgvSubjects["SubjID", row].Value), "'"))) & del_instances(Conversions.ToString(dgvSubjects["SubjectName", row].Value), row))
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Subject Entry Deletion Failed!");
                }
            }

            publicSubsNFunctions.commit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Are you sure you want to delete subject?")))
            {
                pbar.Visible = true;
                int inc = (int)Math.Round(100d / dgvSubjects.SelectedRows.Count);
                for (int k = 0, loopTo = dgvSubjects.SelectedRows.Count - 1; k <= loopTo; k++)
                {
                    delete(dgvSubjects.SelectedRows[k].Index);
                    pbar.Increment(inc);
                }

                publicSubsNFunctions.success("Subject(s) Entry Successfully Deleted!");
                pbar.Visible = false;
                pbar.Increment(-100);
                load_subjects();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}