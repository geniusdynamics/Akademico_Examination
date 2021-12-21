using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmClassSubjects
    {
        public frmClassSubjects()
        {
            InitializeComponent();
            _Button5.Name = "Button5";
            _Button2.Name = "Button2";
            _SimpleButton1.Name = "SimpleButton1";
            _cboClass.Name = "cboClass";
        }

        private void frmClassSubjects_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                publicSubsNFunctions.get_subjects();
                cboSubject.Items.Clear();
                for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                    cboSubject.Items.Add(publicSubsNFunctions.subjects[k]);
                var argcbo = cboClass;
                publicSubsNFunctions.load_class(ref argcbo);
                cboClass = argcbo;
            }
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstSubjects.Items.Clear();
            int i = 1;
            string argq = "SELECT * FROM class_subjects WHERE class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "'";
            publicSubsNFunctions.qread(ref argq);
            while (publicSubsNFunctions.dbreader.Read())
            {
                var li = new ListViewItem();
                li = lstSubjects.Items.Add(i.ToString());
                li.Tag = publicSubsNFunctions.dbreader["SubjID"];
                li.SubItems.Add(publicSubsNFunctions.dbreader["Class"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["Subject"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["Abbreviation"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["Department"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["Comment"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["Code"]);
                i += 1;
            }
        }

        private bool Exists()
        {
            for (int k = 0, loopTo = lstSubjects.Items.Count - 1; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboSubject.SelectedItem, lstSubjects.Items[k].SubItems[2].Text, false)))
                {
                    return true;
                }
            }

            return false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.start();
            publicSubsNFunctions.qwrite("DELETE FROM class_subjects WHERE class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "'");
            for (int k = 0, loopTo = lstSubjects.Items.Count - 1; k <= loopTo; k++)
            {
                if (!publicSubsNFunctions.qwrite("INSERT INTO class_subjects VALUES(NULL,'" + publicSubsNFunctions.escape_string(lstSubjects.Items[k].SubItems[1].Text) + "','" + publicSubsNFunctions.escape_string(lstSubjects.Items[k].SubItems[2].Text) + "','" + publicSubsNFunctions.escape_string(lstSubjects.Items[k].SubItems[3].Text) + "','" + publicSubsNFunctions.escape_string(lstSubjects.Items[k].SubItems[4].Text) + "','" + publicSubsNFunctions.escape_string(lstSubjects.Items[k].SubItems[5].Text) + "','" + publicSubsNFunctions.escape_string(lstSubjects.Items[k].SubItems[6].Text) + "')"))
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Could Not Save Class Subjects!");
                    return;
                }
            }

            publicSubsNFunctions.commit();
            publicSubsNFunctions.success("Class Subjects Successfully Saved!");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (lstSubjects.SelectedItems.Count > 0)
            {
                if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Are you sure you want to delete the selected subject from the list?")))
                {
                    for (int k = lstSubjects.Items.Count - 1; k >= 0; k -= 1)
                    {
                        if (lstSubjects.Items[k].Selected)
                        {
                            lstSubjects.Items.RemoveAt(k);
                        }
                    }
                }
            }
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (!Exists())
            {
                string argq = "SELECT * FROM subjects WHERE subject='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboSubject.SelectedItem)) + "'";
                publicSubsNFunctions.qread(ref argq);
                publicSubsNFunctions.dbreader.Read();
                var li = new ListViewItem();
                li = lstSubjects.Items.Add(publicSubsNFunctions.dbreader["ID"]);
                li.SubItems.Add(cboClass.SelectedItem);
                li.SubItems.Add(publicSubsNFunctions.dbreader["Subject"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["Abbreviation"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["Department"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["Comment"]);
                // previous code li.SubItems.Add(dbreader("Code"))
                li.SubItems.Add(publicSubsNFunctions.dbreader["subjectCode"]);
            }
            else
            {
                publicSubsNFunctions.failure("Subject Alread Exists In The List!");
            }
        }
    }
}