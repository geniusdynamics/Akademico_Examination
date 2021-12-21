using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmResultMeanAnalysis : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResultMeanAnalysis));
            lstExaminations = new ListView();
            colExam = new ColumnHeader();
            colTerm = new ColumnHeader();
            colYear = new ColumnHeader();
            Label5 = new Label();
            Label10 = new Label();
            cboSortBy = new ComboBox();
            Label2 = new Label();
            grpMultiExaminations = new GroupBox();
            cboExamName = new ComboBox();
            Label1 = new Label();
            _cboYear = new ComboBox();
            _cboYear.SelectedIndexChanged += new EventHandler(cboYear_SelectedIndexChanged);
            Label4 = new Label();
            _cboTerm = new ComboBox();
            _cboTerm.SelectedIndexChanged += new EventHandler(cboTerm_SelectedIndexChanged);
            Label7 = new Label();
            cboClass = new ComboBox();
            _btnAddExam = new Button();
            _btnAddExam.Click += new EventHandler(btnAddExam_Click);
            _btnEnterMarks = new Button();
            _btnEnterMarks.Click += new EventHandler(btnEnterMarks_Click);
            btnClear = new Button();
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            rdSubjectBased = new RadioButton();
            rdClassBased = new RadioButton();
            cboSelectedTerm = new ComboBox();
            Label3 = new Label();
            analysisGB = new GroupBox();
            Label6 = new Label();
            cboSelectedYear = new ComboBox();
            grpMultiExaminations.SuspendLayout();
            analysisGB.SuspendLayout();
            SuspendLayout();
            // 
            // lstExaminations
            // 
            lstExaminations.BackColor = SystemColors.Info;
            lstExaminations.Columns.AddRange(new ColumnHeader[] { colExam, colTerm, colYear });
            lstExaminations.ForeColor = Color.IndianRed;
            lstExaminations.GridLines = true;
            lstExaminations.Location = new Point(86, 25);
            lstExaminations.Name = "lstExaminations";
            lstExaminations.Size = new Size(290, 101);
            lstExaminations.TabIndex = 6;
            lstExaminations.UseCompatibleStateImageBehavior = false;
            lstExaminations.View = View.Details;
            // 
            // colExam
            // 
            colExam.Text = "Exam";
            colExam.Width = 151;
            // 
            // colTerm
            // 
            colTerm.Text = "Term";
            colTerm.Width = 50;
            // 
            // colYear
            // 
            colYear.Text = "Year";
            colYear.Width = 50;
            // 
            // Label5
            // 
            Label5.Location = new Point(12, 21);
            Label5.Name = "Label5";
            Label5.Size = new Size(71, 100);
            Label5.TabIndex = 9;
            Label5.Text = "List Of Examinations";
            // 
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.Location = new Point(52, 274);
            Label10.Name = "Label10";
            Label10.Size = new Size(50, 13);
            Label10.TabIndex = 90;
            Label10.Text = "Rank By:";
            // 
            // cboSortBy
            // 
            cboSortBy.BackColor = SystemColors.Info;
            cboSortBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSortBy.ForeColor = Color.IndianRed;
            cboSortBy.FormattingEnabled = true;
            cboSortBy.Items.AddRange(new object[] { "Total Marks", "Mean Marks", "Mean Points", "Total Points" });
            cboSortBy.Location = new Point(105, 271);
            cboSortBy.Name = "cboSortBy";
            cboSortBy.Size = new Size(348, 21);
            cboSortBy.TabIndex = 89;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(69, 251);
            Label2.Name = "Label2";
            Label2.Size = new Size(36, 13);
            Label2.TabIndex = 79;
            Label2.Text = "Class:";
            // 
            // grpMultiExaminations
            // 
            grpMultiExaminations.Controls.Add(lstExaminations);
            grpMultiExaminations.Controls.Add(Label5);
            grpMultiExaminations.Location = new Point(27, 111);
            grpMultiExaminations.Name = "grpMultiExaminations";
            grpMultiExaminations.Size = new Size(429, 132);
            grpMultiExaminations.TabIndex = 88;
            grpMultiExaminations.TabStop = false;
            // 
            // cboExamName
            // 
            cboExamName.BackColor = SystemColors.Info;
            cboExamName.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExamName.ForeColor = Color.IndianRed;
            cboExamName.FormattingEnabled = true;
            cboExamName.Location = new Point(107, 70);
            cboExamName.Name = "cboExamName";
            cboExamName.Size = new Size(349, 21);
            cboExamName.TabIndex = 75;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(34, 73);
            Label1.Name = "Label1";
            Label1.Size = new Size(67, 13);
            Label1.TabIndex = 83;
            Label1.Text = "Exam Name:";
            // 
            // cboYear
            // 
            _cboYear.BackColor = SystemColors.Info;
            _cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear.ForeColor = Color.IndianRed;
            _cboYear.FormattingEnabled = true;
            _cboYear.Items.AddRange(new object[] { "None", "I", "II", "III" });
            _cboYear.Location = new Point(107, 26);
            _cboYear.Name = "_cboYear";
            _cboYear.Size = new Size(348, 21);
            _cboYear.TabIndex = 73;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(71, 29);
            Label4.Name = "Label4";
            Label4.Size = new Size(33, 13);
            Label4.TabIndex = 81;
            Label4.Text = "Year:";
            // 
            // cboTerm
            // 
            _cboTerm.BackColor = SystemColors.Info;
            _cboTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerm.ForeColor = Color.IndianRed;
            _cboTerm.FormattingEnabled = true;
            _cboTerm.Items.AddRange(new object[] { "None", "I", "II", "III" });
            _cboTerm.Location = new Point(107, 48);
            _cboTerm.Name = "_cboTerm";
            _cboTerm.Size = new Size(348, 21);
            _cboTerm.TabIndex = 74;
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Location = new Point(66, 51);
            Label7.Name = "Label7";
            Label7.Size = new Size(35, 13);
            Label7.TabIndex = 85;
            Label7.Text = "Term:";
            // 
            // cboClass
            // 
            cboClass.BackColor = SystemColors.Info;
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.ForeColor = Color.IndianRed;
            cboClass.FormattingEnabled = true;
            cboClass.Location = new Point(105, 249);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(348, 21);
            cboClass.TabIndex = 78;
            // 
            // btnAddExam
            // 
            _btnAddExam.Image = (Image)resources.GetObject("btnAddExam.Image");
            _btnAddExam.Location = new Point(272, 91);
            _btnAddExam.Name = "_btnAddExam";
            _btnAddExam.Size = new Size(184, 23);
            _btnAddExam.TabIndex = 77;
            _btnAddExam.Text = "&Add Examination";
            _btnAddExam.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnAddExam.UseVisualStyleBackColor = true;
            // 
            // btnEnterMarks
            // 
            _btnEnterMarks.Image = (Image)resources.GetObject("btnEnterMarks.Image");
            _btnEnterMarks.Location = new Point(340, 415);
            _btnEnterMarks.Name = "_btnEnterMarks";
            _btnEnterMarks.Size = new Size(111, 32);
            _btnEnterMarks.TabIndex = 84;
            _btnEnterMarks.Text = "&Analyse";
            _btnEnterMarks.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnEnterMarks.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            btnClear.Location = new Point(272, 415);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(63, 32);
            btnClear.TabIndex = 86;
            btnClear.Text = "C&lear";
            btnClear.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(196, 415);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(72, 32);
            _btnCancel.TabIndex = 87;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // rdSubjectBased
            // 
            rdSubjectBased.AutoSize = true;
            rdSubjectBased.Checked = true;
            rdSubjectBased.Location = new Point(13, 20);
            rdSubjectBased.Name = "rdSubjectBased";
            rdSubjectBased.Size = new Size(122, 17);
            rdSubjectBased.TabIndex = 91;
            rdSubjectBased.TabStop = true;
            rdSubjectBased.Text = "Use Subject Grading";
            rdSubjectBased.UseVisualStyleBackColor = true;
            // 
            // rdClassBased
            // 
            rdClassBased.AutoSize = true;
            rdClassBased.Location = new Point(234, 20);
            rdClassBased.Name = "rdClassBased";
            rdClassBased.Size = new Size(111, 17);
            rdClassBased.TabIndex = 92;
            rdClassBased.Text = "Use Class Grading";
            rdClassBased.UseVisualStyleBackColor = true;
            // 
            // cboSelectedTerm
            // 
            cboSelectedTerm.BackColor = SystemColors.Info;
            cboSelectedTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSelectedTerm.ForeColor = Color.IndianRed;
            cboSelectedTerm.FormattingEnabled = true;
            cboSelectedTerm.Items.AddRange(new object[] { "I", "II", "III" });
            cboSelectedTerm.Location = new Point(58, 58);
            cboSelectedTerm.Name = "cboSelectedTerm";
            cboSelectedTerm.Size = new Size(121, 21);
            cboSelectedTerm.TabIndex = 93;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(7, 66);
            Label3.Name = "Label3";
            Label3.Size = new Size(31, 13);
            Label3.TabIndex = 94;
            Label3.Text = "Term";
            // 
            // analysisGB
            // 
            analysisGB.Controls.Add(cboSelectedYear);
            analysisGB.Controls.Add(Label6);
            analysisGB.Controls.Add(rdSubjectBased);
            analysisGB.Controls.Add(Label3);
            analysisGB.Controls.Add(rdClassBased);
            analysisGB.Controls.Add(cboSelectedTerm);
            analysisGB.Location = new Point(27, 309);
            analysisGB.Name = "analysisGB";
            analysisGB.Size = new Size(429, 100);
            analysisGB.TabIndex = 95;
            analysisGB.TabStop = false;
            analysisGB.Text = "Use These Analysis Criteria";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new Point(201, 66);
            Label6.Name = "Label6";
            Label6.Size = new Size(29, 13);
            Label6.TabIndex = 95;
            Label6.Text = "Year";
            // 
            // cboSelectedYear
            // 
            cboSelectedYear.BackColor = SystemColors.Info;
            cboSelectedYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSelectedYear.ForeColor = Color.IndianRed;
            cboSelectedYear.FormattingEnabled = true;
            cboSelectedYear.Items.AddRange(new object[] { "I", "II", "III" });
            cboSelectedYear.Location = new Point(255, 58);
            cboSelectedYear.Name = "cboSelectedYear";
            cboSelectedYear.Size = new Size(121, 21);
            cboSelectedYear.TabIndex = 96;
            // 
            // frmResultMeanAnalysis
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 458);
            ControlBox = false;
            Controls.Add(analysisGB);
            Controls.Add(Label10);
            Controls.Add(_btnAddExam);
            Controls.Add(_btnEnterMarks);
            Controls.Add(btnClear);
            Controls.Add(cboSortBy);
            Controls.Add(_btnCancel);
            Controls.Add(Label2);
            Controls.Add(grpMultiExaminations);
            Controls.Add(cboExamName);
            Controls.Add(Label1);
            Controls.Add(_cboYear);
            Controls.Add(Label4);
            Controls.Add(_cboTerm);
            Controls.Add(Label7);
            Controls.Add(cboClass);
            Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Name = "frmResultMeanAnalysis";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Result Mean Analysis";
            grpMultiExaminations.ResumeLayout(false);
            analysisGB.ResumeLayout(false);
            analysisGB.PerformLayout();
            Load += new EventHandler(frmResultMeanAnalysis_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal ListView lstExaminations;
        internal ColumnHeader colExam;
        internal ColumnHeader colTerm;
        internal ColumnHeader colYear;
        internal Label Label5;
        internal Label Label10;
        private Button _btnAddExam;

        internal Button btnAddExam
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddExam;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddExam != null)
                {
                    _btnAddExam.Click -= btnAddExam_Click;
                }

                _btnAddExam = value;
                if (_btnAddExam != null)
                {
                    _btnAddExam.Click += btnAddExam_Click;
                }
            }
        }

        private Button _btnEnterMarks;

        internal Button btnEnterMarks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEnterMarks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEnterMarks != null)
                {
                    _btnEnterMarks.Click -= btnEnterMarks_Click;
                }

                _btnEnterMarks = value;
                if (_btnEnterMarks != null)
                {
                    _btnEnterMarks.Click += btnEnterMarks_Click;
                }
            }
        }

        internal Button btnClear;
        internal ComboBox cboSortBy;
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

        internal Label Label2;
        internal GroupBox grpMultiExaminations;
        internal ComboBox cboExamName;
        internal Label Label1;
        private ComboBox _cboYear;

        internal ComboBox cboYear
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboYear;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboYear != null)
                {
                    _cboYear.SelectedIndexChanged -= cboYear_SelectedIndexChanged;
                }

                _cboYear = value;
                if (_cboYear != null)
                {
                    _cboYear.SelectedIndexChanged += cboYear_SelectedIndexChanged;
                }
            }
        }

        internal Label Label4;
        private ComboBox _cboTerm;

        internal ComboBox cboTerm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTerm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTerm != null)
                {
                    _cboTerm.SelectedIndexChanged -= cboTerm_SelectedIndexChanged;
                }

                _cboTerm = value;
                if (_cboTerm != null)
                {
                    _cboTerm.SelectedIndexChanged += cboTerm_SelectedIndexChanged;
                }
            }
        }

        internal Label Label7;
        internal ComboBox cboClass;
        internal RadioButton rdSubjectBased;
        internal RadioButton rdClassBased;
        internal ComboBox cboSelectedTerm;
        internal Label Label3;
        internal GroupBox analysisGB;
        internal ComboBox cboSelectedYear;
        internal Label Label6;
    }
}