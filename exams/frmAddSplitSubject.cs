using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmAddSplitSubject
    {
        public frmAddSplitSubject()
        {
            InitializeComponent();
            _Button1.Name = "Button1";
            _cboClass.Name = "cboClass";
        }

        private void frmAddSplitSubject_Load(object sender, EventArgs e)
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
            }
        }

        private void load_subjects()
        {
            cboSubject.Items.Clear();
            if (Conversions.ToBoolean(publicSubsNFunctions.get_class_subjects(Conversions.ToString(cboClass.SelectedItem))))
            {
                for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                    cboSubject.Items.Add(publicSubsNFunctions.subjects[k]);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboClass.SelectedItem, null, false), Operators.ConditionalCompareObjectNotEqual(cboSubject.SelectedItem, null, false)), !string.IsNullOrEmpty(txtName.Text.Trim())), !string.IsNullOrEmpty(txtAbbreviation.Text.Trim())), Information.IsNumeric(txtContribution.Text))))
            {
                // qwrite("ALTER TABLE `split_subjects` ADD COLUMN `weighted` DOUBLE NOT NULL AFTER `contribution`;")
                publicSubsNFunctions.start();
                if (!publicSubsNFunctions.qwrite("INSERT INTO split_subjects VALUES(NULL, '" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "','" + publicSubsNFunctions.escape_string(Conversions.ToString(cboSubject.SelectedItem)) + "','" + publicSubsNFunctions.escape_string(txtName.Text) + "','" + publicSubsNFunctions.escape_string(txtAbbreviation.Text) + "', '" + txtContribution.Text + "', '" + txtWeighted.Text + "')") | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `exam_split_subject_results`" + "ADD COLUMN `", publicSubsNFunctions.get_name(Conversions.ToString(cboClass.SelectedItem))), "_"), txtAbbreviation.Text), "` VARCHAR(255) NOT NULL DEFAULT '';"))))
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Could Not Save Record!");
                }
                else
                {
                    publicSubsNFunctions.commit();
                    publicSubsNFunctions.success("Record Successfully Saved!");
                }
            }
            else
            {
                publicSubsNFunctions.failure("Please fill in the form correctly!");
            }
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_subjects();
        }
    }
}