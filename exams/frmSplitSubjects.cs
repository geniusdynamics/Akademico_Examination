using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmSplitSubjects
    {
        public frmSplitSubjects()
        {
            InitializeComponent();
            _lstSubjects.Name = "lstSubjects";
        }

        private void frmSplitSubjects_Load(object sender, EventArgs e)
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
            lstSubjects.Items.Clear();
            // todo commented the below code not sure what the repurcsion are
            // qwrite("ALTER TABLE `split_subjects` ADD COLUMN `weighted` DOUBLE NOT NULL AFTER `contribution`;")
            string argq = "SELECT * FROM split_subjects";
            publicSubsNFunctions.qread(ref argq);
            while (publicSubsNFunctions.dbreader.Read())
            {
                var li = new ListViewItem();
                li = lstSubjects.Items.Add(publicSubsNFunctions.dbreader["class"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["subject"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["name"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["Abbreviation"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["contribution"]);
                li.SubItems.Add(publicSubsNFunctions.dbreader["weighted"]);
                li.Tag = publicSubsNFunctions.dbreader["id"];
            }
        }

        private void lstSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            publicSubsNFunctions.t_id = Conversions.ToInteger(lstSubjects.Items[lstSubjects.SelectedItems[0].Index].Tag);
            var frm = new frmEditSplitSubject();
            frm.ShowDialog();
            load_subjects();
        }
    }
}