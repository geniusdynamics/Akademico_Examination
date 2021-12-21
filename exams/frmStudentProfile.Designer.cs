using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmStudentProfile : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentProfile));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _Button2 = new DevExpress.XtraEditors.SimpleButton();
            _Button2.Click += new EventHandler(Button2_Click);
            ProgressBar1 = new ProgressBar();
            dgvEnterMarks = new DataGridView();
            Year = new DataGridViewTextBoxColumn();
            Term = new DataGridViewTextBoxColumn();
            Examination = new DataGridViewTextBoxColumn();
            _txtADMNo = new TextBox();
            _txtADMNo.Click += new EventHandler(txtADMNo_Click);
            _txtName = new TextBox();
            _txtName.Click += new EventHandler(txtADMNo_Click);
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEnterMarks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_Button2);
            LayoutControl1.Controls.Add(ProgressBar1);
            LayoutControl1.Controls.Add(dgvEnterMarks);
            LayoutControl1.Controls.Add(_txtADMNo);
            LayoutControl1.Controls.Add(_txtName);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(481, 292, 250, 350);
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(959, 490);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // Button2
            // 
            _Button2.Image = (Image)resources.GetObject("Button2.Image");
            _Button2.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button2.Location = new Point(868, 439);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(79, 39);
            _Button2.StyleController = LayoutControl1;
            _Button2.TabIndex = 8;
            _Button2.Text = "Print Report";
            // 
            // ProgressBar1
            // 
            ProgressBar1.Location = new Point(12, 415);
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new Size(935, 20);
            ProgressBar1.TabIndex = 7;
            // 
            // dgvEnterMarks
            // 
            dgvEnterMarks.AllowUserToAddRows = false;
            dgvEnterMarks.AllowUserToDeleteRows = false;
            dgvEnterMarks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEnterMarks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnterMarks.Columns.AddRange(new DataGridViewColumn[] { Year, Term, Examination });
            dgvEnterMarks.Location = new Point(12, 36);
            dgvEnterMarks.Name = "dgvEnterMarks";
            dgvEnterMarks.ReadOnly = true;
            dgvEnterMarks.Size = new Size(935, 375);
            dgvEnterMarks.TabIndex = 6;
            // 
            // Year
            // 
            Year.HeaderText = "Year";
            Year.Name = "Year";
            Year.ReadOnly = true;
            // 
            // Term
            // 
            Term.HeaderText = "Term";
            Term.Name = "Term";
            Term.ReadOnly = true;
            // 
            // Examination
            // 
            Examination.HeaderText = "Examination";
            Examination.Name = "Examination";
            Examination.ReadOnly = true;
            // 
            // txtADMNo
            // 
            _txtADMNo.BackColor = Color.BurlyWood;
            _txtADMNo.Location = new Point(102, 12);
            _txtADMNo.Name = "_txtADMNo";
            _txtADMNo.ReadOnly = true;
            _txtADMNo.Size = new Size(205, 20);
            _txtADMNo.TabIndex = 5;
            // 
            // txtName
            // 
            _txtName.BackColor = Color.BurlyWood;
            _txtName.Location = new Point(401, 12);
            _txtName.Name = "_txtName";
            _txtName.ReadOnly = true;
            _txtName.Size = new Size(546, 20);
            _txtName.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem3, LayoutControlItem4, EmptySpaceItem1, LayoutControlItem5, LayoutControlItem2 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(959, 490);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _txtName;
            LayoutControlItem1.Location = new Point(299, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(640, 24);
            LayoutControlItem1.Text = "Name Of Student";
            LayoutControlItem1.TextSize = new Size(87, 13);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = dgvEnterMarks;
            LayoutControlItem3.Location = new Point(0, 24);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(939, 379);
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = ProgressBar1;
            LayoutControlItem4.Location = new Point(0, 403);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(939, 24);
            LayoutControlItem4.TextSize = new Size(0, 0);
            LayoutControlItem4.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 427);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(856, 43);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = _Button2;
            LayoutControlItem5.Location = new Point(856, 427);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(83, 43);
            LayoutControlItem5.TextSize = new Size(0, 0);
            LayoutControlItem5.TextVisible = false;
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _txtADMNo;
            LayoutControlItem2.Location = new Point(0, 0);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(299, 24);
            LayoutControlItem2.Text = "Admission Number";
            LayoutControlItem2.TextSize = new Size(87, 13);
            // 
            // frmStudentProfile
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 490);
            Controls.Add(LayoutControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmStudentProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Profile";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEnterMarks).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            Load += new EventHandler(frmStudentProfile_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton _Button2;

        internal DevExpress.XtraEditors.SimpleButton Button2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button2 != null)
                {
                    _Button2.Click -= Button2_Click;
                }

                _Button2 = value;
                if (_Button2 != null)
                {
                    _Button2.Click += Button2_Click;
                }
            }
        }

        internal ProgressBar ProgressBar1;
        internal DataGridView dgvEnterMarks;
        internal DataGridViewTextBoxColumn Year;
        internal DataGridViewTextBoxColumn Term;
        internal DataGridViewTextBoxColumn Examination;
        private TextBox _txtADMNo;

        internal TextBox txtADMNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtADMNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtADMNo != null)
                {
                    _txtADMNo.Click -= txtADMNo_Click;
                }

                _txtADMNo = value;
                if (_txtADMNo != null)
                {
                    _txtADMNo.Click += txtADMNo_Click;
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
                    _txtName.Click -= txtADMNo_Click;
                }

                _txtName = value;
                if (_txtName != null)
                {
                    _txtName.Click += txtADMNo_Click;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
    }
}