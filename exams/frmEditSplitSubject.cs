using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmEditSplitSubject
    {
        public frmEditSplitSubject()
        {
            InitializeComponent();
            _Button1.Name = "Button1";
            _cboClass.Name = "cboClass";
            _btnDelete.Name = "btnDelete";
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
                // todo commented the below code not sure what the repurcsion are
                // qwrite("ALTER TABLE `split_subjects` ADD COLUMN `weighted` DOUBLE NOT NULL AFTER `contribution`;")
                string argq = "SELECT * FROM split_subjects WHERE id=" + publicSubsNFunctions.t_id;
                publicSubsNFunctions.qread(ref argq);
                publicSubsNFunctions.dbreader.Read();
                string subject = Conversions.ToString(publicSubsNFunctions.dbreader["subject"]);
                names = Conversions.ToString(publicSubsNFunctions.dbreader["Abbreviation"]);
                txtAbbreviation.Text = Conversions.ToString(publicSubsNFunctions.dbreader["Abbreviation"]);
                txtContribution.Text = Conversions.ToString(publicSubsNFunctions.dbreader["Contribution"]);
                txtWeighted.Text = Conversions.ToString(publicSubsNFunctions.dbreader["weighted"]);
                txtName.Text = Conversions.ToString(publicSubsNFunctions.dbreader["Name"]);
                cboClass.SelectedItem = publicSubsNFunctions.dbreader["Class"];
                cboSubject.SelectedItem = subject;
            }
        }

        private string names = null;

        private void load_subjects()
        {
            cboSubject.Items.Clear();
            publicSubsNFunctions.get_class_subjects(Conversions.ToString(cboClass.SelectedItem));
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                cboSubject.Items.Add(publicSubsNFunctions.subjects[k]);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboSubject.SelectedItem, null, false), !string.IsNullOrEmpty(txtName.Text.Trim())), !string.IsNullOrEmpty(txtAbbreviation.Text.Trim())), Information.IsNumeric(txtContribution.Text))))
            {
                publicSubsNFunctions.start();
                if (!publicSubsNFunctions.qwrite("UPDATE split_subjects SET class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "', subject='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboSubject.SelectedItem)) + "',name='" + publicSubsNFunctions.escape_string(txtName.Text) + "',abbreviation='" + publicSubsNFunctions.escape_string(txtAbbreviation.Text) + "', contribution='" + txtContribution.Text + "', weighted='" + txtWeighted.Text + "' WHERE id=" + publicSubsNFunctions.t_id) | !publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ALTER TABLE `exam_split_subject_results`" + "CHANGE `", publicSubsNFunctions.get_name(Conversions.ToString(cboClass.SelectedItem))), "_"), names), "` `"), publicSubsNFunctions.get_name(Conversions.ToString(cboClass.SelectedItem))), "_"), txtAbbreviation.Text), "` VARCHAR(255) NOT NULL DEFAULT '';"))))
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Could Not Save Record!");
                }
                else
                {
                    publicSubsNFunctions.commit();
                    publicSubsNFunctions.success("Record Successfully Saved!");
                    Close();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboSubject.SelectedItem, null, false), !string.IsNullOrEmpty(txtName.Text.Trim())), txtAbbreviation.Text.Trim())))
            {
                if (publicSubsNFunctions.displayConfirmationMessage("Are You Sure You Want To Delete This Subject ?"))
                {
                    if (publicSubsNFunctions.qwrite("ALTER TABLE exam_split_subject_results DROP COLUMN " + txtName.Text + ";") & publicSubsNFunctions.qwrite("delete from split_subjects where subject = '" + cboSubject.SelectedItem.ToString() + "' and name = '" + txtName.Text + "' and abbreviation = '" + txtAbbreviation.Text + "' "))
                    {
                        Interaction.MsgBox("The Operation Was Successful");
                    }
                }
            }
            else
            {
                publicSubsNFunctions.failure("Please fill in the form correctly!");
            }
        }
    }
}