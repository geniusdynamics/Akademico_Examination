using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmUsers : DevExpress.XtraEditors.XtraForm
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components is object)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            _radioNonTeaching = new RadioButton();
            _radioNonTeaching.CheckedChanged += new EventHandler(radioNonTeaching_CheckedChanged);
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            _radioTeaching = new RadioButton();
            _radioTeaching.CheckedChanged += new EventHandler(radioTeaching_CheckedChanged);
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            _partnersLUE = new DevExpress.XtraEditors.LookUpEdit();
            _partnersLUE.EditValueChanged += new EventHandler(partnersLUE_EditValueChanged);
            txtName = new TextBox();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            txtDepartment = new TextBox();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            txtUserName = new TextBox();
            layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            txtPassword = new TextBox();
            layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            userGC = new DevExpress.XtraGrid.GridControl();
            _userGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            _userGV.DoubleClick += new EventHandler(userGV_DoubleClick);
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            _simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            _simpleButton1.Click += new EventHandler(simpleButton1_Click);
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            btnEdit = new DevExpress.XtraEditors.SimpleButton();
            LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            _btnDelete = new DevExpress.XtraEditors.SimpleButton();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            LayoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            ErrorProvider1 = new ErrorProvider();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_partnersLUE.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userGC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_userGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnDelete);
            LayoutControl1.Controls.Add(btnEdit);
            LayoutControl1.Controls.Add(_simpleButton1);
            LayoutControl1.Controls.Add(userGC);
            LayoutControl1.Controls.Add(_radioTeaching);
            LayoutControl1.Controls.Add(_radioNonTeaching);
            LayoutControl1.Controls.Add(_partnersLUE);
            LayoutControl1.Controls.Add(txtName);
            LayoutControl1.Controls.Add(txtDepartment);
            LayoutControl1.Controls.Add(txtUserName);
            LayoutControl1.Controls.Add(txtPassword);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(853, 445);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, layoutControlItem3, layoutControlItem5, LayoutControlItem2, layoutControlItem10, layoutControlItem4, LayoutControlItem6, layoutControlItem9, EmptySpaceItem1, LayoutControlItem7, LayoutControlItem8, EmptySpaceItem3, LayoutControlItem11 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(853, 445);
            LayoutControlGroup1.TextVisible = false;
            // 
            // radioNonTeaching
            // 
            _radioNonTeaching.Checked = true;
            _radioNonTeaching.Location = new Point(428, 12);
            _radioNonTeaching.Name = "_radioNonTeaching";
            _radioNonTeaching.Size = new Size(413, 25);
            _radioNonTeaching.TabIndex = 6;
            _radioNonTeaching.TabStop = true;
            _radioNonTeaching.Text = "Non Teaching Staff";
            _radioNonTeaching.UseVisualStyleBackColor = true;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _radioNonTeaching;
            LayoutControlItem1.Location = new Point(416, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(417, 29);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _radioTeaching;
            LayoutControlItem2.Location = new Point(0, 0);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(416, 29);
            LayoutControlItem2.TextSize = new Size(0, 0);
            LayoutControlItem2.TextVisible = false;
            // 
            // radioTeaching
            // 
            _radioTeaching.Location = new Point(12, 12);
            _radioTeaching.Name = "_radioTeaching";
            _radioTeaching.Size = new Size(412, 25);
            _radioTeaching.TabIndex = 7;
            _radioTeaching.Text = "Teaching Staff";
            _radioTeaching.UseVisualStyleBackColor = true;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = _partnersLUE;
            layoutControlItem3.CustomizationFormText = "Select Partner";
            layoutControlItem3.Location = new Point(0, 29);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(833, 24);
            layoutControlItem3.Text = "Select Partner";
            layoutControlItem3.TextSize = new Size(68, 13);
            // 
            // partnersLUE
            // 
            _partnersLUE.Location = new Point(84, 41);
            _partnersLUE.Name = "_partnersLUE";
            _partnersLUE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            _partnersLUE.Properties.NullText = "";
            _partnersLUE.Size = new Size(757, 20);
            _partnersLUE.StyleController = LayoutControl1;
            _partnersLUE.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.ForeColor = Color.Red;
            txtName.Location = new Point(84, 65);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(340, 20);
            txtName.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = txtName;
            layoutControlItem5.CustomizationFormText = "Staff";
            layoutControlItem5.Location = new Point(0, 53);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(416, 24);
            layoutControlItem5.Text = "Staff";
            layoutControlItem5.TextSize = new Size(68, 13);
            // 
            // txtDepartment
            // 
            txtDepartment.ForeColor = Color.Red;
            txtDepartment.Location = new Point(500, 65);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.ReadOnly = true;
            txtDepartment.Size = new Size(341, 20);
            txtDepartment.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = txtDepartment;
            layoutControlItem4.CustomizationFormText = "Department";
            layoutControlItem4.Location = new Point(416, 53);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(417, 24);
            layoutControlItem4.Text = "Department";
            layoutControlItem4.TextSize = new Size(68, 13);
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(84, 89);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(340, 20);
            txtUserName.TabIndex = 13;
            // 
            // layoutControlItem10
            // 
            layoutControlItem10.Control = txtUserName;
            layoutControlItem10.CustomizationFormText = "User Name";
            layoutControlItem10.Location = new Point(0, 77);
            layoutControlItem10.Name = "layoutControlItem10";
            layoutControlItem10.Size = new Size(416, 24);
            layoutControlItem10.Text = "User Name";
            layoutControlItem10.TextSize = new Size(68, 13);
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(500, 89);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(341, 20);
            txtPassword.TabIndex = 12;
            // 
            // layoutControlItem9
            // 
            layoutControlItem9.Control = txtPassword;
            layoutControlItem9.CustomizationFormText = "Password";
            layoutControlItem9.Location = new Point(416, 77);
            layoutControlItem9.Name = "layoutControlItem9";
            layoutControlItem9.Size = new Size(417, 24);
            layoutControlItem9.Text = "Password";
            layoutControlItem9.TextSize = new Size(68, 13);
            // 
            // userGC
            // 
            userGC.Location = new Point(12, 156);
            userGC.MainView = _userGV;
            userGC.Name = "userGC";
            userGC.Size = new Size(829, 234);
            userGC.TabIndex = 14;
            userGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { _userGV });
            // 
            // userGV
            // 
            _userGV.GridControl = userGC;
            _userGV.Name = "_userGV";
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = userGC;
            LayoutControlItem6.Location = new Point(0, 144);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(833, 238);
            LayoutControlItem6.TextSize = new Size(0, 0);
            LayoutControlItem6.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 101);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(700, 43);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // simpleButton1
            // 
            _simpleButton1.Image = (Image)resources.GetObject("simpleButton1.Image");
            _simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _simpleButton1.Location = new Point(774, 113);
            _simpleButton1.Name = "_simpleButton1";
            _simpleButton1.Size = new Size(67, 39);
            _simpleButton1.StyleController = LayoutControl1;
            _simpleButton1.TabIndex = 15;
            _simpleButton1.Text = "Add";
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = _simpleButton1;
            LayoutControlItem7.Location = new Point(762, 101);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(71, 43);
            LayoutControlItem7.TextSize = new Size(0, 0);
            LayoutControlItem7.TextVisible = false;
            // 
            // btnEdit
            // 
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            btnEdit.Location = new Point(712, 113);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(58, 39);
            btnEdit.StyleController = LayoutControl1;
            btnEdit.TabIndex = 16;
            btnEdit.Text = "Edit";
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = btnEdit;
            LayoutControlItem8.Location = new Point(700, 101);
            LayoutControlItem8.Name = "LayoutControlItem8";
            LayoutControlItem8.Size = new Size(62, 43);
            LayoutControlItem8.TextSize = new Size(0, 0);
            LayoutControlItem8.TextVisible = false;
            // 
            // EmptySpaceItem3
            // 
            EmptySpaceItem3.AllowHotTrack = false;
            EmptySpaceItem3.Location = new Point(0, 382);
            EmptySpaceItem3.Name = "EmptySpaceItem3";
            EmptySpaceItem3.Size = new Size(787, 43);
            EmptySpaceItem3.TextSize = new Size(0, 0);
            // 
            // btnDelete
            // 
            _btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            _btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnDelete.Location = new Point(799, 394);
            _btnDelete.Name = "_btnDelete";
            _btnDelete.Size = new Size(42, 39);
            _btnDelete.StyleController = LayoutControl1;
            _btnDelete.TabIndex = 17;
            _btnDelete.Text = "Delete";
            // 
            // LayoutControlItem11
            // 
            LayoutControlItem11.Control = _btnDelete;
            LayoutControlItem11.Location = new Point(787, 382);
            LayoutControlItem11.Name = "LayoutControlItem11";
            LayoutControlItem11.Size = new Size(46, 43);
            LayoutControlItem11.TextSize = new Size(0, 0);
            LayoutControlItem11.TextVisible = false;
            // 
            // ErrorProvider1
            // 
            ErrorProvider1.ContainerControl = this;
            ErrorProvider1.RightToLeft = true;
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 445);
            Controls.Add(LayoutControl1);
            Name = "frmUsers";
            Text = "System Users";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)_partnersLUE.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)userGC).EndInit();
            ((System.ComponentModel.ISupportInitialize)_userGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).EndInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).EndInit();
            Load += new EventHandler(frmUsers_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        private DevExpress.XtraEditors.SimpleButton _btnDelete;

        private DevExpress.XtraEditors.SimpleButton btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton _simpleButton1;

        private DevExpress.XtraEditors.SimpleButton simpleButton1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _simpleButton1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_simpleButton1 != null)
                {
                    _simpleButton1.Click -= simpleButton1_Click;
                }

                _simpleButton1 = value;
                if (_simpleButton1 != null)
                {
                    _simpleButton1.Click += simpleButton1_Click;
                }
            }
        }

        internal DevExpress.XtraGrid.GridControl userGC;
        private DevExpress.XtraGrid.Views.Grid.GridView _userGV;

        internal DevExpress.XtraGrid.Views.Grid.GridView userGV
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _userGV;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_userGV != null)
                {
                    _userGV.DoubleClick -= userGV_DoubleClick;
                }

                _userGV = value;
                if (_userGV != null)
                {
                    _userGV.DoubleClick += userGV_DoubleClick;
                }
            }
        }

        private RadioButton _radioTeaching;

        private RadioButton radioTeaching
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radioTeaching;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radioTeaching != null)
                {
                    _radioTeaching.CheckedChanged -= radioTeaching_CheckedChanged;
                }

                _radioTeaching = value;
                if (_radioTeaching != null)
                {
                    _radioTeaching.CheckedChanged += radioTeaching_CheckedChanged;
                }
            }
        }

        private RadioButton _radioNonTeaching;

        private RadioButton radioNonTeaching
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radioNonTeaching;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radioNonTeaching != null)
                {
                    _radioNonTeaching.CheckedChanged -= radioNonTeaching_CheckedChanged;
                }

                _radioNonTeaching = value;
                if (_radioNonTeaching != null)
                {
                    _radioNonTeaching.CheckedChanged += radioNonTeaching_CheckedChanged;
                }
            }
        }

        private DevExpress.XtraEditors.LookUpEdit _partnersLUE;

        internal DevExpress.XtraEditors.LookUpEdit partnersLUE
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _partnersLUE;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_partnersLUE != null)
                {
                    _partnersLUE.EditValueChanged -= partnersLUE_EditValueChanged;
                }

                _partnersLUE = value;
                if (_partnersLUE != null)
                {
                    _partnersLUE.EditValueChanged += partnersLUE_EditValueChanged;
                }
            }
        }

        internal TextBox txtName;
        internal TextBox txtDepartment;
        internal TextBox txtUserName;
        internal TextBox txtPassword;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        internal DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem11;
        internal ErrorProvider ErrorProvider1;
    }
}