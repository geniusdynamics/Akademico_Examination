using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmMeanAnalysis : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeanAnalysis));
            dgvSubjects = new DataGridView();
            SubjID = new DataGridViewTextBoxColumn();
            Abbreviation = new DataGridViewTextBoxColumn();
            SubjectName = new DataGridViewTextBoxColumn();
            MeanMark = new DataGridViewTextBoxColumn();
            MeanGrade = new DataGridViewTextBoxColumn();
            MeanPoints = new DataGridViewTextBoxColumn();
            _btnPrintPreview = new Button();
            _btnPrintPreview.Click += new EventHandler(btnPrint_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            GroupBox1 = new GroupBox();
            lblTitle = new Label();
            printpreview = new PrintPreviewDialog();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
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
            dgvSubjects.Columns.AddRange(new DataGridViewColumn[] { SubjID, Abbreviation, SubjectName, MeanMark, MeanGrade, MeanPoints });
            dgvSubjects.Dock = DockStyle.Fill;
            dgvSubjects.GridColor = Color.IndianRed;
            dgvSubjects.Location = new Point(3, 16);
            dgvSubjects.Margin = new Padding(3, 2, 3, 2);
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubjects.Size = new Size(607, 429);
            dgvSubjects.TabIndex = 0;
            // 
            // SubjID
            // 
            SubjID.HeaderText = "Subject ID";
            SubjID.Name = "SubjID";
            SubjID.ReadOnly = true;
            SubjID.SortMode = DataGridViewColumnSortMode.Programmatic;
            SubjID.Visible = false;
            // 
            // Abbreviation
            // 
            Abbreviation.HeaderText = "Abbreviation";
            Abbreviation.Name = "Abbreviation";
            Abbreviation.ReadOnly = true;
            Abbreviation.Width = 80;
            // 
            // SubjectName
            // 
            SubjectName.HeaderText = "Subject Name";
            SubjectName.Name = "SubjectName";
            SubjectName.ReadOnly = true;
            SubjectName.SortMode = DataGridViewColumnSortMode.Programmatic;
            SubjectName.Width = 200;
            // 
            // MeanMark
            // 
            MeanMark.HeaderText = "Mean Mark";
            MeanMark.Name = "MeanMark";
            MeanMark.ReadOnly = true;
            MeanMark.SortMode = DataGridViewColumnSortMode.Programmatic;
            MeanMark.Width = 90;
            // 
            // MeanGrade
            // 
            MeanGrade.HeaderText = "Mean Grade";
            MeanGrade.Name = "MeanGrade";
            MeanGrade.ReadOnly = true;
            MeanGrade.Width = 90;
            // 
            // MeanPoints
            // 
            MeanPoints.HeaderText = "Mean Points";
            MeanPoints.Name = "MeanPoints";
            MeanPoints.ReadOnly = true;
            // 
            // btnPrintPreview
            // 
            _btnPrintPreview.Image = (Image)resources.GetObject("btnPrintPreview.Image");
            _btnPrintPreview.Location = new Point(422, 481);
            _btnPrintPreview.Margin = new Padding(3, 2, 3, 2);
            _btnPrintPreview.Name = "_btnPrintPreview";
            _btnPrintPreview.Size = new Size(92, 29);
            _btnPrintPreview.TabIndex = 22;
            _btnPrintPreview.Text = "&List Report";
            _btnPrintPreview.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnPrintPreview.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(343, 481);
            _btnCancel.Margin = new Padding(3, 2, 3, 2);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(73, 29);
            _btnCancel.TabIndex = 23;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(dgvSubjects);
            GroupBox1.Location = new Point(25, 30);
            GroupBox1.Margin = new Padding(3, 2, 3, 2);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Padding = new Padding(3, 2, 3, 2);
            GroupBox1.Size = new Size(613, 447);
            GroupBox1.TabIndex = 21;
            GroupBox1.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = SystemColors.Control;
            lblTitle.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            lblTitle.Location = new Point(12, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(640, 37);
            lblTitle.TabIndex = 20;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
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
            // Button1
            // 
            _Button1.Image = (Image)resources.GetObject("Button1.Image");
            _Button1.Location = new Point(520, 481);
            _Button1.Margin = new Padding(3, 2, 3, 2);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(106, 29);
            _Button1.TabIndex = 24;
            _Button1.Text = "&Group Report";
            _Button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            _Button1.UseVisualStyleBackColor = true;
            // 
            // frmMeanAnalysis
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 517);
            Controls.Add(_btnPrintPreview);
            Controls.Add(_btnCancel);
            Controls.Add(GroupBox1);
            Controls.Add(lblTitle);
            Controls.Add(_Button1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMeanAnalysis";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subject Result Analysis";
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            GroupBox1.ResumeLayout(false);
            Load += new EventHandler(frmMeanAnalysis_Load);
            ResumeLayout(false);
        }

        internal DataGridView dgvSubjects;
        internal DataGridViewTextBoxColumn SubjID;
        internal DataGridViewTextBoxColumn Abbreviation;
        internal DataGridViewTextBoxColumn SubjectName;
        internal DataGridViewTextBoxColumn MeanMark;
        internal DataGridViewTextBoxColumn MeanGrade;
        internal DataGridViewTextBoxColumn MeanPoints;
        private Button _btnPrintPreview;

        internal Button btnPrintPreview
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintPreview;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintPreview != null)
                {
                    _btnPrintPreview.Click -= btnPrint_Click;
                }

                _btnPrintPreview = value;
                if (_btnPrintPreview != null)
                {
                    _btnPrintPreview.Click += btnPrint_Click;
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

        internal GroupBox GroupBox1;
        internal Label lblTitle;
        internal PrintPreviewDialog printpreview;
        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }
    }
}