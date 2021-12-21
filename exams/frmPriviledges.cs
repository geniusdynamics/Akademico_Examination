using System;
using System.Collections.Generic;
using System.Linq;
using global::System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmPriviledges
    {
        public frmPriviledges()
        {
            InitializeComponent();
            _usersDGV.Name = "usersDGV";
            _btnSave.Name = "btnSave";
        }

        private void frmPriviledges_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }

            string argsql = "select Title, partnername as Name, Designation, Department from system_users left join partners on partners.partnerName = system_users.partner where domain = md5('Examination')";
            var myTable = publicSubsNFunctions.generateDataTable(ref argsql);
            usersDGV.DataSource = myTable;
            loadTreeView();
        }

        private object menus = string.Empty;
        private object treeView = new Dictionary<string, List<string>>();

        private void loadTreeView()
        {
            treeView.Clear();
            var configurations = new[] { "Performance Comments", "Principal Comments", "Report Form Configurations", "Merit List Configurations" };
            var subjects = new[] { "Add Split Subject", "Edit Split Subject", "Assign Subject Taken", "Assign Index Number" };
            var Grading = new[] { "Class Based Grading Scheme", "Subject Based Grading" };
            var Examinations = new[] { "Create Examination", "Edit Examination", "Create National Examination", "Edit National Examination" };
            var Performance_entry = new[] { "Local Examination", "National Examination" };
            var Results = new[] { "Student Performance Profile", "Student Performance Index", "General Performance", "Student Performance", "Subject Performance", "Subject Performance Index" };
            var Users = new[] { "System Users", "User Rights And Priviledges" };
            var ChangeLook = new[] { "Application Font", "Restore Default Look And Feel" };
            treeView.Add("Configuration", configurations.ToList());
            treeView.Add("Subjects", subjects.ToList());
            treeView.Add("Grading", Grading.ToList());
            treeView.Add("Examinations", Examinations.ToList());
            treeView.Add("Performance Entry", Performance_entry.ToList());
            treeView.Add("Results", Results.ToList());
            treeView.Add("Users", Users.ToList());
            treeView.Add("Change Look", ChangeLook.ToList());
            myTreeView.Nodes.Clear();
            int counter = 0;
            foreach (string s in (System.Collections.IEnumerable)treeView.keys)
            {
                myTreeView.Nodes.Add(s);
                foreach (string item in (System.Collections.IEnumerable)this.treeView(s))
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(menus.Length, 0, false)))
                    {
                        if (Conversions.ToBoolean(menus.Contains(item)))
                        {
                            myTreeView.Nodes[counter].Nodes.Add(item).Checked = true;
                        }
                        else
                        {
                            myTreeView.Nodes[counter].Nodes.Add(item);
                        }
                    }
                    else
                    {
                        myTreeView.Nodes[counter].Nodes.Add(item);
                    }
                }

                counter += 1;
            }

            myTreeView.ExpandAll();
        }

        private object CheckedNames(TreeNodeCollection theNodes)
        {
            var aResult = new List<string>();
            if (!Information.IsNothing(theNodes))
            {
                foreach (TreeNode aNode in theNodes)
                {
                    if (aNode.Checked == true)
                    {
                        aResult.Add(aNode.Text);
                    }

                    aResult.AddRange((IEnumerable<string>)CheckedNames(aNode.Nodes));
                }
            }

            return aResult;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectedItems = CheckedNames(myTreeView.Nodes);
            var items = new StringBuilder();
            foreach (string s in (System.Collections.IEnumerable)selectedItems)
                items.Append(s + " , ");
            if (usersDGV.SelectedRows.Count > 0)
            {
                string user = usersDGV.SelectedRows[0].Cells[1].Value.ToString();
                if (publicSubsNFunctions.qwrite("delete from priviledges where user = '" + user + "' and domain = 'Exam'") & publicSubsNFunctions.qwrite("INSERT INTO `priviledges` (`user`, `rights`, `domain`) VALUES ('" + publicSubsNFunctions.escape_string(user) + "', '" + publicSubsNFunctions.escape_string(items.ToString()) + "', 'Exam');"))
                {
                    publicSubsNFunctions.success("The Operation Was Successful");
                }
            }
        }

        private void usersDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (usersDGV.SelectedRows.Count > 0)
            {
                string user = usersDGV.SelectedRows[0].Cells[1].Value.ToString();
                menus = publicSubsNFunctions.getMenus(user);
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(menus.Length, 0, false)))
                {
                    loadTreeView();
                }
            }
        }
    }
}