using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmPriviledges : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPriviledges));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            myTreeView = new TreeView();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            _usersDGV = new DataGridView();
            _usersDGV.SelectionChanged += new EventHandler(usersDGV_SelectionChanged);
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            _btnSave = new DevExpress.XtraEditors.SimpleButton();
            _btnSave.Click += new EventHandler(btnSave_Click);
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_usersDGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnSave);
            LayoutControl1.Controls.Add(_usersDGV);
            LayoutControl1.Controls.Add(myTreeView);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(735, 431);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, EmptySpaceItem1, EmptySpaceItem2, LayoutControlItem3 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(735, 431);
            LayoutControlGroup1.TextVisible = false;
            // 
            // myTreeView
            // 
            myTreeView.CheckBoxes = true;
            myTreeView.Location = new Point(12, 12);
            myTreeView.Name = "myTreeView";
            myTreeView.Size = new Size(213, 364);
            myTreeView.TabIndex = 8;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = myTreeView;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(217, 368);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // usersDGV
            // 
            _usersDGV.AllowUserToAddRows = false;
            _usersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _usersDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _usersDGV.Location = new Point(260, 12);
            _usersDGV.MultiSelect = false;
            _usersDGV.Name = "_usersDGV";
            _usersDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _usersDGV.Size = new Size(463, 364);
            _usersDGV.TabIndex = 9;
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _usersDGV;
            LayoutControlItem2.Location = new Point(248, 0);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(467, 368);
            LayoutControlItem2.TextSize = new Size(0, 0);
            LayoutControlItem2.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(217, 0);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(31, 368);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 368);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(652, 43);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // btnSave
            // 
            _btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            _btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnSave.Location = new Point(664, 380);
            _btnSave.Name = "_btnSave";
            _btnSave.Size = new Size(59, 39);
            _btnSave.StyleController = LayoutControl1;
            _btnSave.TabIndex = 10;
            _btnSave.Text = "Save";
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _btnSave;
            LayoutControlItem3.Location = new Point(652, 368);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(63, 43);
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // frmPriviledges
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 431);
            Controls.Add(LayoutControl1);
            Name = "frmPriviledges";
            Text = "User Rights And Priviledges";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)_usersDGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            Load += new EventHandler(frmPriviledges_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton _btnSave;

        private DevExpress.XtraEditors.SimpleButton btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        private DataGridView _usersDGV;

        private DataGridView usersDGV
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _usersDGV;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_usersDGV != null)
                {
                    _usersDGV.SelectionChanged -= usersDGV_SelectionChanged;
                }

                _usersDGV = value;
                if (_usersDGV != null)
                {
                    _usersDGV.SelectionChanged += usersDGV_SelectionChanged;
                }
            }
        }

        private TreeView myTreeView;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
    }
}