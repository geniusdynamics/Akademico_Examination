using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmHeadTeacherComments : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHeadTeacherComments));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _btnSave = new DevExpress.XtraEditors.SimpleButton();
            _btnSave.Click += new EventHandler(btnSave_Click);
            txtComment = new TextBox();
            _cboTrend = new ComboBox();
            _cboTrend.SelectedIndexChanged += new EventHandler(cboTrend_SelectedIndexChanged);
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ErrorProvider1 = new ErrorProvider();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnSave);
            LayoutControl1.Controls.Add(txtComment);
            LayoutControl1.Controls.Add(_cboTrend);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(475, 161);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // btnSave
            // 
            _btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            _btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnSave.Location = new Point(422, 86);
            _btnSave.Name = "_btnSave";
            _btnSave.Size = new Size(41, 39);
            _btnSave.StyleController = LayoutControl1;
            _btnSave.TabIndex = 10;
            _btnSave.Text = "Save";
            // 
            // txtComment
            // 
            txtComment.Location = new Point(107, 37);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(356, 45);
            txtComment.TabIndex = 5;
            // 
            // cboTrend
            // 
            _cboTrend.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTrend.FormattingEnabled = true;
            _cboTrend.Items.AddRange(new object[] { "None", "Constant", "Drop", "Improve", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "E", "X", " Y" });
            _cboTrend.Location = new Point(107, 12);
            _cboTrend.Name = "_cboTrend";
            _cboTrend.Size = new Size(356, 21);
            _cboTrend.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, EmptySpaceItem1, EmptySpaceItem2, LayoutControlItem3 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(475, 161);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _cboTrend;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(455, 25);
            LayoutControlItem1.Text = "Performance Trend";
            LayoutControlItem1.TextSize = new Size(92, 13);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = txtComment;
            LayoutControlItem2.Location = new Point(0, 25);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(455, 49);
            LayoutControlItem2.Text = "Comment";
            LayoutControlItem2.TextSize = new Size(92, 13);
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 74);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(410, 43);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 117);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(455, 24);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _btnSave;
            LayoutControlItem3.Location = new Point(410, 74);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(45, 43);
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // ErrorProvider1
            // 
            ErrorProvider1.ContainerControl = this;
            ErrorProvider1.RightToLeft = true;
            // 
            // frmHeadTeacherComments
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 161);
            Controls.Add(LayoutControl1);
            Name = "frmHeadTeacherComments";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Prinicipals Comments";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).EndInit();
            Load += new EventHandler(frmHeadTeacherComments_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal TextBox txtComment;
        private ComboBox _cboTrend;

        internal ComboBox cboTrend
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTrend;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTrend != null)
                {
                    _cboTrend.SelectedIndexChanged -= cboTrend_SelectedIndexChanged;
                }

                _cboTrend = value;
                if (_cboTrend != null)
                {
                    _cboTrend.SelectedIndexChanged += cboTrend_SelectedIndexChanged;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton _btnSave;

        internal DevExpress.XtraEditors.SimpleButton btnSave
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

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal ErrorProvider ErrorProvider1;
    }
}