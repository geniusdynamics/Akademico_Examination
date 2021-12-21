using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmCreateNationalExam : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateNationalExam));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _btnCreateExam = new DevExpress.XtraEditors.SimpleButton();
            _btnCreateExam.Click += new EventHandler(btnCreateExam_Click);
            txtExamName = new TextBox();
            cboYear = new ComboBox();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnCreateExam);
            LayoutControl1.Controls.Add(txtExamName);
            LayoutControl1.Controls.Add(cboYear);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(419, 115);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // btnCreateExam
            // 
            _btnCreateExam.Image = (Image)resources.GetObject("btnCreateExam.Image");
            _btnCreateExam.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnCreateExam.Location = new Point(324, 61);
            _btnCreateExam.Name = "_btnCreateExam";
            _btnCreateExam.Size = new Size(83, 39);
            _btnCreateExam.StyleController = LayoutControl1;
            _btnCreateExam.TabIndex = 6;
            _btnCreateExam.Text = "Save";
            // 
            // txtExamName
            // 
            txtExamName.Location = new Point(71, 37);
            txtExamName.Name = "txtExamName";
            txtExamName.Size = new Size(336, 20);
            txtExamName.TabIndex = 5;
            // 
            // cboYear
            // 
            cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cboYear.FormattingEnabled = true;
            cboYear.Location = new Point(71, 12);
            cboYear.Name = "cboYear";
            cboYear.Size = new Size(336, 21);
            cboYear.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, EmptySpaceItem1, LayoutControlItem3 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(419, 115);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = cboYear;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(399, 25);
            LayoutControlItem1.Text = "Select Year";
            LayoutControlItem1.TextSize = new Size(56, 13);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = txtExamName;
            LayoutControlItem2.Location = new Point(0, 25);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(399, 24);
            LayoutControlItem2.Text = "Exam Name";
            LayoutControlItem2.TextSize = new Size(56, 13);
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 49);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(312, 46);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _btnCreateExam;
            LayoutControlItem3.Location = new Point(312, 49);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(87, 46);
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // frmCreateNationalExam
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 115);
            Controls.Add(LayoutControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCreateNationalExam";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create National Exam";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            Load += new EventHandler(frmCreateNationalExam_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton _btnCreateExam;

        internal DevExpress.XtraEditors.SimpleButton btnCreateExam
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreateExam;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreateExam != null)
                {
                    _btnCreateExam.Click -= btnCreateExam_Click;
                }

                _btnCreateExam = value;
                if (_btnCreateExam != null)
                {
                    _btnCreateExam.Click += btnCreateExam_Click;
                }
            }
        }

        internal TextBox txtExamName;
        internal ComboBox cboYear;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
    }
}