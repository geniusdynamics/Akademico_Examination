using System;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmSubjectsOutOf
    {
        public frmSubjectsOutOf()
        {
            InitializeComponent();
            _Button1.Name = "Button1";
        }

        private void frmSubjectsOutOf_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                if (publicSubsNFunctions.stream == "All")
                {
                    publicSubsNFunctions.query = "SELECT * FROM exam_results_subjects_out_of WHERE Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND term='" + publicSubsNFunctions.tm + "' AND year='" + publicSubsNFunctions.yr + "' AND Class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "'";
                }
                else
                {
                    publicSubsNFunctions.query = "SELECT * FROM exam_results_subjects_out_of WHERE Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND term='" + publicSubsNFunctions.tm + "' AND year='" + publicSubsNFunctions.yr + "' AND Class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' AND Stream='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.stream) + "'";
                }

                publicSubsNFunctions.qread(ref publicSubsNFunctions.query);
                int i = 0;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                    {
                        dgvSubjects.Rows.Add();
                        dgvSubjects["Abbreviation", k + i * publicSubsNFunctions.subjabb.Length].Value = publicSubsNFunctions.subjabb[k];
                        dgvSubjects["Subject", k + i * publicSubsNFunctions.subjabb.Length].Value = publicSubsNFunctions.subjects[k];
                        dgvSubjects["Clas", k + i * publicSubsNFunctions.subjabb.Length].Value = publicSubsNFunctions.dbreader["Class"];
                        dgvSubjects["Str", k + i * publicSubsNFunctions.subjabb.Length].Value = publicSubsNFunctions.dbreader["Stream"];
                        dgvSubjects["Marks", k + i * publicSubsNFunctions.subjabb.Length].Value = publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]);
                    }

                    i += 1;
                }

                if (Conversions.ToBoolean(!publicSubsNFunctions.IsAdmin()))
                {
                    for (int k = 0, loopTo1 = dgvSubjects.Rows.Count - 1; k <= loopTo1; k++)
                    {
                        if (publicSubsNFunctions.IsSubjectTeacher(Conversions.ToString(dgvSubjects["Subject", k].Value), Conversions.ToString(dgvSubjects["Clas", k].Value), Conversions.ToString(dgvSubjects["Str", k].Value), publicSubsNFunctions.tm, publicSubsNFunctions.yr.ToString()))
                        {
                            dgvSubjects.Rows[k].ReadOnly = true;
                        }
                        else
                        {
                            dgvSubjects.Rows[k].ReadOnly = false;
                        }
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.start();
            for (int k = 0, loopTo = dgvSubjects.Rows.Count - 1; k <= loopTo; k++)
            {
                if (!publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("UPDATE exam_results_subjects_out_of SET `", dgvSubjects["Abbreviation", k].Value), "`='"), dgvSubjects["Marks", k].Value), "' WHERE (Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "' AND Class='"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvSubjects["Clas", k].Value))), "' AND Stream='"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvSubjects["Str", k].Value))), "')"))))
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Subject Total Marks Could Not Be Saved!");
                    return;
                }
            }

            publicSubsNFunctions.commit();
            publicSubsNFunctions.success("Subject Total Marks Successfully Saved!");
        }
    }
}