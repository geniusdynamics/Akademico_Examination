using System;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmDeleteNationalExam
    {
        public frmDeleteNationalExam()
        {
            InitializeComponent();
            _btnDelete.Name = "btnDelete";
            _cboYear.Name = "cboYear";
        }

        private string[] words;

        private void frmDeleteExam_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                for (int k = publicSubsNFunctions.startyear, loopTo = publicSubsNFunctions.endyear; k <= loopTo; k++)
                    cboYear.Items.Add(k);
                load_exams();
            }
        }

        public void load_exams()
        {
            ComboBox1.Items.Clear();
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM national_examinations WHERE year='", cboYear.SelectedItem), "'"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                while (publicSubsNFunctions.dbreader.Read())
                    ComboBox1.Items.Add(publicSubsNFunctions.dbreader["Name"]);
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Read From The Examinations Database!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Are you sure you want to delete examination!")))
            {
                delete();
                load_exams();
            }
        }

        private void delete()
        {
            if (publicSubsNFunctions.qwrite("DELETE FROM national_examinations WHERE Name='" + publicSubsNFunctions.escape_string(Conversions.ToString(ComboBox1.SelectedItem)) + "'"))
            {
                publicSubsNFunctions.success("Examination Successfully Deleted!");
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Successfully Delete Examination Entry");
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_exams();
        }
    }
}