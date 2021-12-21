using System;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmAllStudents
    {
        public frmAllStudents()
        {
            InitializeComponent();
            _dgvStudents.Name = "dgvStudents";
        }

        private void frmAllStudents_Load(object sender, EventArgs e)
        {
            if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    int i = 0;
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        dgvStudents.Rows.Add();
                        dgvStudents["ADMNo", i].Value = publicSubsNFunctions.dbreader["ADMNo"];
                        dgvStudents["StudentName", i].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.dbreader["LastName"], " "), publicSubsNFunctions.dbreader["FirstName"]), " "), publicSubsNFunctions.dbreader["MiddleName"]);
                        publicSubsNFunctions.class_form = Conversions.ToString(publicSubsNFunctions.dbreader["CurrentClass"]);
                        i += 1;
                    }

                    publicSubsNFunctions.cont = true;
                }
                else
                {
                    publicSubsNFunctions.failure("No Matching Student Records Found!");
                    publicSubsNFunctions.cont = false;
                    Close();
                }

                publicSubsNFunctions.dbreader.Close();
            }
        }

        private void dgvStudents_DoubleClick(object sender, EventArgs e)
        {
            publicSubsNFunctions.t_id = Conversions.ToInteger(dgvStudents["ADMNo", dgvStudents.SelectedRows[0].Index].Value);
            publicSubsNFunctions.t_name = Conversions.ToString(dgvStudents["StudentName", dgvStudents.SelectedRows[0].Index].Value);
            Close();
        }
    }
}