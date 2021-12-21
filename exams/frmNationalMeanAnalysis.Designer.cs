using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmNationalMeanAnalysis : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNationalMeanAnalysis));
            dgvSubjects = new DataGridView();
            SubjID = new DataGridViewTextBoxColumn();
            Abbreviation = new DataGridViewTextBoxColumn();
            SubjectName = new DataGridViewTextBoxColumn();
            MeanPoints = new DataGridViewTextBoxColumn();
            MeanGrade = new DataGridViewTextBoxColumn();
            _GroupBox1 = new GroupBox();
            _GroupBox1.Enter += new EventHandler(GroupBox1_Enter);
            printpreview = new PrintPreviewDialog();
            Label1 = new Label();
            _ComboBox1 = new ComboBox();
            _ComboBox1.SelectedIndexChanged += new EventHandler(ComboBox1_SelectedIndexChanged);
            _btnPrint = new Button();
            _btnPrint.Click += new EventHandler(btnPrint_Click_1);
            _btnPrintPreview = new Button();
            _btnPrintPreview.Click += new EventHandler(btnPrint_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
            _GroupBox1.SuspendLayout();
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
            dgvSubjects.Columns.AddRange(new DataGridViewColumn[] { SubjID, Abbreviation, SubjectName, MeanPoints, MeanGrade });
            dgvSubjects.Dock = DockStyle.Fill;
            dgvSubjects.GridColor = Color.IndianRed;
            dgvSubjects.Location = new Point(3, 16);
            dgvSubjects.Margin = new Padding(3, 2, 3, 2);
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubjects.Size = new Size(521, 396);
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
            // MeanPoints
            // 
            MeanPoints.HeaderText = "Mean Points";
            MeanPoints.Name = "MeanPoints";
            MeanPoints.ReadOnly = true;
            // 
            // MeanGrade
            // 
            MeanGrade.HeaderText = "Mean Grade";
            MeanGrade.Name = "MeanGrade";
            MeanGrade.ReadOnly = true;
            MeanGrade.Width = 90;
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(dgvSubjects);
            _GroupBox1.Location = new Point(40, 36);
            _GroupBox1.Margin = new Padding(3, 2, 3, 2);
            _GroupBox1.Name = "_GroupBox1";
            _GroupBox1.Padding = new Padding(3, 2, 3, 2);
            _GroupBox1.Size = new Size(527, 414);
            _GroupBox1.TabIndex = 21;
            _GroupBox1.TabStop = false;
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
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(40, 18);
            Label1.Name = "Label1";
            Label1.Size = new Size(45, 13);
            Label1.TabIndex = 26;
            Label1.Text = "Stream:";
            // 
            // ComboBox1
            // 
            _ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            _ComboBox1.FormattingEnabled = true;
            _ComboBox1.Location = new Point(90, 15);
            _ComboBox1.Name = "_ComboBox1";
            _ComboBox1.Size = new Size(156, 21);
            _ComboBox1.TabIndex = 25;
            // 
            // btnPrint
            // 
            _btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            _btnPrint.Location = new Point(445, 454);
            _btnPrint.Margin = new Padding(3, 2, 3, 2);
            _btnPrint.Name = "_btnPrint";
            _btnPrint.Size = new Size(108, 29);
            _btnPrint.TabIndex = 22;
            _btnPrint.Text = "&Group Report";
            _btnPrint.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnPrintPreview
            // 
            _btnPrintPreview.Image = (Image)resources.GetObject("btnPrintPreview.Image");
            _btnPrintPreview.Location = new Point(352, 454);
            _btnPrintPreview.Margin = new Padding(3, 2, 3, 2);
            _btnPrintPreview.Name = "_btnPrintPreview";
            _btnPrintPreview.Size = new Size(87, 29);
            _btnPrintPreview.TabIndex = 23;
            _btnPrintPreview.Text = "&List Report";
            _btnPrintPreview.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnPrintPreview.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(260, 454);
            _btnCancel.Margin = new Padding(3, 2, 3, 2);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(73, 29);
            _btnCancel.TabIndex = 24;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmNationalMeanAnalysis
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 510);
            Controls.Add(_GroupBox1);
            Controls.Add(Label1);
            Controls.Add(_ComboBox1);
            Controls.Add(_btnPrint);
            Controls.Add(_btnPrintPreview);
            Controls.Add(_btnCancel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNationalMeanAnalysis";
            Text = "frmNationalMeanAnalysis";
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            _GroupBox1.ResumeLayout(false);
            Load += new EventHandler(frmMeanAnalysis_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal DataGridView dgvSubjects;
        internal DataGridViewTextBoxColumn SubjID;
        internal DataGridViewTextBoxColumn Abbreviation;
        internal DataGridViewTextBoxColumn SubjectName;
        internal DataGridViewTextBoxColumn MeanPoints;
        internal DataGridViewTextBoxColumn MeanGrade;
        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                    _GroupBox1.Enter -= GroupBox1_Enter;
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                    _GroupBox1.Enter += GroupBox1_Enter;
                }
            }
        }

        internal PrintPreviewDialog printpreview;
        internal Label Label1;
        private ComboBox _ComboBox1;

        internal ComboBox ComboBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBox1 != null)
                {
                    _ComboBox1.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged;
                }

                _ComboBox1 = value;
                if (_ComboBox1 != null)
                {
                    _ComboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
                }
            }
        }

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
                    _btnPrint.Click -= btnPrint_Click_1;
                }

                _btnPrint = value;
                if (_btnPrint != null)
                {
                    _btnPrint.Click += btnPrint_Click_1;
                }
            }
        }

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
    }
}