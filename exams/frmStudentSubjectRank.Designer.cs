using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmStudentSubjectRank : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentSubjectRank));
            dgvSubjects = new DataGridView();
            ADMNo = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            MarkAttained = new DataGridViewTextBoxColumn();
            GradeAttained = new DataGridViewTextBoxColumn();
            Points = new DataGridViewTextBoxColumn();
            GroupBox1 = new GroupBox();
            lblTitle = new Label();
            _btnPrint = new Button();
            _btnPrint.Click += new EventHandler(btnPrint_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            printpreview = new PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
            GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSubjects
            // 
            dgvSubjects.AllowUserToAddRows = false;
            dgvSubjects.AllowUserToDeleteRows = false;
            dgvSubjects.AllowUserToResizeColumns = false;
            dgvSubjects.AllowUserToResizeRows = false;
            dgvSubjects.BackgroundColor = SystemColors.Info;
            dgvSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubjects.Columns.AddRange(new DataGridViewColumn[] { ADMNo, StudentName, Gender, MarkAttained, GradeAttained, Points });
            dgvSubjects.Dock = DockStyle.Fill;
            dgvSubjects.GridColor = Color.IndianRed;
            dgvSubjects.Location = new Point(3, 17);
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubjects.Size = new Size(725, 612);
            dgvSubjects.TabIndex = 0;
            // 
            // ADMNo
            // 
            ADMNo.HeaderText = "ADM No.";
            ADMNo.Name = "ADMNo";
            ADMNo.ReadOnly = true;
            ADMNo.SortMode = DataGridViewColumnSortMode.Programmatic;
            ADMNo.Width = 90;
            // 
            // StudentName
            // 
            StudentName.HeaderText = "Name of Student";
            StudentName.Name = "StudentName";
            StudentName.ReadOnly = true;
            StudentName.SortMode = DataGridViewColumnSortMode.Programmatic;
            StudentName.Width = 250;
            // 
            // Gender
            // 
            Gender.HeaderText = "Gender";
            Gender.Name = "Gender";
            Gender.ReadOnly = true;
            Gender.Width = 60;
            // 
            // MarkAttained
            // 
            MarkAttained.HeaderText = "Marks";
            MarkAttained.Name = "MarkAttained";
            MarkAttained.ReadOnly = true;
            MarkAttained.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // GradeAttained
            // 
            GradeAttained.HeaderText = "Grade";
            GradeAttained.Name = "GradeAttained";
            GradeAttained.ReadOnly = true;
            GradeAttained.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // Points
            // 
            Points.HeaderText = "Points";
            Points.Name = "Points";
            Points.ReadOnly = true;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(dgvSubjects);
            GroupBox1.Location = new Point(9, 39);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(731, 632);
            GroupBox1.TabIndex = 16;
            GroupBox1.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = SystemColors.Control;
            lblTitle.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            lblTitle.Location = new Point(30, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(481, 27);
            lblTitle.TabIndex = 15;
            lblTitle.Text = "STUDENT SUBJECT RANKING ANALYSIS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            _btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            _btnPrint.Location = new Point(682, 9);
            _btnPrint.Name = "_btnPrint";
            _btnPrint.Size = new Size(64, 36);
            _btnPrint.TabIndex = 17;
            _btnPrint.Text = "&Print";
            _btnPrint.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(588, 9);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(73, 36);
            _btnCancel.TabIndex = 18;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // printpreview
            // 
            printpreview.AutoScrollMargin = new Size(0, 0);
            printpreview.AutoScrollMinSize = new Size(0, 0);
            printpreview.ClientSize = new Size(400, 300);
            printpreview.Enabled = true;
            printpreview.Icon = (Icon)resources.GetObject("printpreview.Icon");
            printpreview.Name = "printpreview";
            printpreview.Visible = false;
            // 
            // frmStudentSubjectRank
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 683);
            Controls.Add(GroupBox1);
            Controls.Add(lblTitle);
            Controls.Add(_btnPrint);
            Controls.Add(_btnCancel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmStudentSubjectRank";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Subject Rank";
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            GroupBox1.ResumeLayout(false);
            Load += new EventHandler(frmStudentSubjectRank_Load);
            ResumeLayout(false);
        }

        internal DataGridView dgvSubjects;
        internal DataGridViewTextBoxColumn ADMNo;
        internal DataGridViewTextBoxColumn StudentName;
        internal DataGridViewTextBoxColumn Gender;
        internal DataGridViewTextBoxColumn MarkAttained;
        internal DataGridViewTextBoxColumn GradeAttained;
        internal DataGridViewTextBoxColumn Points;
        internal GroupBox GroupBox1;
        internal Label lblTitle;
        private Button _btnPrint;

        internal Button btnPrint
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrint;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrint != null)
                {
                    _btnPrint.Click -= btnPrint_Click;
                }

                _btnPrint = value;
                if (_btnPrint != null)
                {
                    _btnPrint.Click += btnPrint_Click;
                }
            }
        }

        private Button _btnCancel;

        internal Button btnCancel
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

        internal PrintPreviewDialog printpreview;
    }
}