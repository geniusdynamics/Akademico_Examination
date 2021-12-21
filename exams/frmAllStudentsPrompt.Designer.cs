using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmAllStudentsPrompt : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllStudentsPrompt));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _btnCancel = new DevExpress.XtraEditors.SimpleButton();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnSearch = new DevExpress.XtraEditors.SimpleButton();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _txtName = new TextBox();
            _txtName.KeyPress += new KeyPressEventHandler(txtName_KeyPress);
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnCancel);
            LayoutControl1.Controls.Add(_btnSearch);
            LayoutControl1.Controls.Add(_txtName);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(520, 106);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnCancel.Location = new Point(346, 36);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(79, 39);
            _btnCancel.StyleController = LayoutControl1;
            _btnCancel.TabIndex = 6;
            _btnCancel.Text = "Cancel";
            // 
            // btnSearch
            // 
            _btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            _btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnSearch.Location = new Point(429, 36);
            _btnSearch.Name = "_btnSearch";
            _btnSearch.Size = new Size(79, 39);
            _btnSearch.StyleController = LayoutControl1;
            _btnSearch.TabIndex = 5;
            _btnSearch.Text = "Search";
            // 
            // txtName
            // 
            _txtName.Location = new Point(131, 12);
            _txtName.Name = "_txtName";
            _txtName.Size = new Size(377, 20);
            _txtName.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, EmptySpaceItem1, EmptySpaceItem2, LayoutControlItem2, LayoutControlItem3 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(520, 106);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _txtName;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(500, 24);
            LayoutControlItem1.Text = "Enter Admission Number";
            LayoutControlItem1.TextSize = new Size(116, 13);
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 24);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(334, 43);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 67);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(500, 19);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _btnSearch;
            LayoutControlItem2.Location = new Point(417, 24);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(83, 43);
            LayoutControlItem2.TextSize = new Size(0, 0);
            LayoutControlItem2.TextVisible = false;
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _btnCancel;
            LayoutControlItem3.Location = new Point(334, 24);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(83, 43);
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // frmAllStudentsPrompt
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 106);
            ControlBox = false;
            Controls.Add(LayoutControl1);
            Name = "frmAllStudentsPrompt";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Which Student ?";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            Load += new EventHandler(frmAllStudentsPrompt_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        private DevExpress.XtraEditors.SimpleButton _btnCancel;

        internal DevExpress.XtraEditors.SimpleButton btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _btnSearch;

        internal DevExpress.XtraEditors.SimpleButton btnSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSearch != null)
                {
                    _btnSearch.Click -= btnSearch_Click;
                }

                _btnSearch = value;
                if (_btnSearch != null)
                {
                    _btnSearch.Click += btnSearch_Click;
                }
            }
        }

        private TextBox _txtName;

        internal TextBox txtName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtName != null)
                {
                    _txtName.KeyPress -= txtName_KeyPress;
                }

                _txtName = value;
                if (_txtName != null)
                {
                    _txtName.KeyPress += txtName_KeyPress;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
    }
}