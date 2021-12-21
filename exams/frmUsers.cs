using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmUsers
    {
        public frmUsers()
        {
            InitializeComponent();
            _radioNonTeaching.Name = "radioNonTeaching";
            _radioTeaching.Name = "radioTeaching";
            _partnersLUE.Name = "partnersLUE";
            _userGV.Name = "userGV";
            _simpleButton1.Name = "simpleButton1";
            _btnDelete.Name = "btnDelete";
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }

            string argparameter = "teaching staff";
            loadLUE(ref argparameter);
            loadGrid();
        }

        private void loadGrid()
        {
            string argsql = "select Title, partnername as Name, Designation, Department from system_users left join partners on partners.partnerName = system_users.partner where system_users.domain = md5('Examination')";
            DataTable myTable = (DataTable)publicSubsNFunctions.generateDataTable(ref argsql);
            userGC.DataSource = myTable;
        }

        private void loadLUE(ref string parameter)
        {
            string argsql = "select Title, partnername as Name, Designation, Department from partners where partnertype = '" + parameter + "'";
            DataTable myTable = (DataTable)publicSubsNFunctions.generateDataTable(ref argsql);
            partnersLUE.Properties.DataSource = myTable;
            partnersLUE.Properties.DisplayMember = "Name";
            partnersLUE.Properties.ValueMember = "Name";
        }

        private void radioTeaching_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void radioNonTeaching_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (radioNonTeaching.Checked == true)
            {
                string argparameter = "support staff";
                loadLUE(ref argparameter);
            }
            else
            {
                string argparameter1 = "teaching staff";
                loadLUE(ref argparameter1);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                ErrorProvider1.SetError(partnersLUE, "Please Select The Staff Member");
            }
            else
            {
                if (Conversions.ToBoolean(!verify()))
                {
                    return;
                }

                object localrecordsAffected() { string argname = txtName.Text; var ret = recordsAffected(ref argname); txtName.Text = argname; return ret; }

                if (Conversions.ToBoolean(localrecordsAffected()))
                {
                    upDateRecord();
                    loadGrid();
                }
                else
                {
                    insertRecord();
                    loadGrid();
                }

                txtPassword.Clear();
                txtUserName.Clear();
            }
        }

        private void upDateRecord()
        {
            if (publicSubsNFunctions.qwrite("UPDATE `system_users` SET `user_name`=md5('" + publicSubsNFunctions.escape_string(txtUserName.Text) + "'), `password`= md5('" + txtPassword.Text + "') WHERE  `partner`='" + txtName.Text + "' and domain = md5('Examination');"))
            {
                publicSubsNFunctions.success("The Operation Was Successful");
            }
        }

        private void insertRecord()
        {
            if (publicSubsNFunctions.qwrite("INSERT INTO `system_users` (`partner`, `user_name`, `password`, `domain`) VALUES ('" + publicSubsNFunctions.escape_string(txtName.Text) + "', md5('" + txtUserName.Text + "'),  md5('" + txtPassword.Text + "'), md5('Examination'));"))
            {
                publicSubsNFunctions.success("The Operation Was Successful");
            }
        }

        private object verify()
        {
            ErrorProvider1.Clear();
            bool veriified = false;
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                ErrorProvider1.SetError(txtUserName, "The User Name Is Blank");
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ErrorProvider1.SetError(txtPassword, "Please Enter The Password");
            }
            else
            {
                veriified = true;
            }

            return veriified;
        }

        private void clearItems()
        {
            txtDepartment.Clear();
            txtName.Clear();
            txtPassword.Clear();
            txtUserName.Clear();
            partnersLUE.EditValue = null;
        }

        public object recordsAffected(ref string name)
        {
            bool veriified = false;
            string argq = "select id from system_users where partner = '" + name + "' and domain = md5('Examination');";
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    veriified = true;
                }
            }

            return veriified;
        }

        private void userGV_DoubleClick(object sender, EventArgs e)
        {
            if (userGV.SelectedRowsCount > 0)
            {
                partnersLUE.EditValue = userGV.GetFocusedRowCellValue("Name").ToString();
                txtName.Text = userGV.GetFocusedRowCellValue("Name").ToString();
                txtDepartment.Text = userGV.GetFocusedRowCellValue("Department").ToString();
            }
        }

        private void partnersLUE_EditValueChanged(object sender, EventArgs e)
        {
            txtName.Text = partnersLUE.EditValue.ToString();
            txtDepartment.Text = partnersLUE.GetColumnValue("Department").ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                ErrorProvider1.SetError(txtName, "Please Double Click The Grid To Select The User");
            }
            else if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Delete The Selected User ?")))
            {
                if (publicSubsNFunctions.qwrite("delete from system_users where partner = '" + txtName.Text + "' and domain = md5('Examination')"))
                {
                    publicSubsNFunctions.success("The Operation Was Successful");
                    loadGrid();
                }
            }
        }
    }
}