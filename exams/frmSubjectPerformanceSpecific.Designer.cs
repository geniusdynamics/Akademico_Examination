using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmSubjectPerformanceSpecific : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectPerformanceSpecific));
            printpreview = new PrintPreviewDialog();
            Label5 = new Label();
            ColumnHeader4 = new ColumnHeader();
            ColumnHeader3 = new ColumnHeader();
            ColumnHeader2 = new ColumnHeader();
            ColumnHeader1 = new ColumnHeader();
            lstExaminations = new ListView();
            lblTitle = new Label();
            grpSelect = new GroupBox();
            _chkMode = new CheckBox();
            _chkMode.CheckedChanged += new EventHandler(chkMode_CheckedChanged);
            _txtContribution = new TextBox();
            _txtContribution.KeyPress += new KeyPressEventHandler(txtContribution_KeyPress);
            _btnAddExam = new Button();
            _btnAddExam.Click += new EventHandler(btnAddExam_Click);
            Label8 = new Label();
            Label6 = new Label();
            grpMultiExaminations = new GroupBox();
            _btnAnalyze = new Button();
            _btnAnalyze.Click += new EventHandler(btnAnalyze_Click);
            _cboClass = new ComboBox();
            _cboClass.SelectedIndexChanged += new EventHandler(cboClass_SelectedIndexChanged);
            _cboExamName = new ComboBox();
            _cboExamName.SelectedIndexChanged += new EventHandler(cboExamName_SelectedIndexChanged);
            Label1 = new Label();
            Label2 = new Label();
            _cboTerm = new ComboBox();
            _cboTerm.SelectedIndexChanged += new EventHandler(cboTerm_SelectedIndexChanged);
            Label3 = new Label();
            _cboYear = new ComboBox();
            _cboYear.SelectedIndexChanged += new EventHandler(cboYear_SelectedIndexChanged);
            Label4 = new Label();
            chkBestOf7 = new CheckBox();
            grpAnalyze = new GroupBox();
            _Button4 = new Button();
            _Button4.Click += new EventHandler(Button4_Click_1);
            _radSubject = new CheckBox();
            _radSubject.CheckedChanged += new EventHandler(radSubject_CheckedChanged);
            _btnMeanGradeAnalysis = new Button();
            _btnMeanGradeAnalysis.Click += new EventHandler(Button4_Click);
            _btnGradesAttained = new Button();
            _btnGradesAttained.Click += new EventHandler(btnGradesAttained_Click);
            _btnStudentRank = new Button();
            _btnStudentRank.Click += new EventHandler(Button2_Click);
            _btnClear = new Button();
            _btnClear.Click += new EventHandler(btnClear_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _bestStud = new Button();
            _bestStud.Click += new EventHandler(bestStud_Click);
            grpSelect.SuspendLayout();
            grpMultiExaminations.SuspendLayout();
            grpAnalyze.SuspendLayout();
            SuspendLayout();
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
            // Label5
            // 
            Label5.Location = new Point(9, 16);
            Label5.Name = "Label5";
            Label5.Size = new Size(394, 18);
            Label5.TabIndex = 9;
            Label5.Text = "List Of Examinations And Their Respective Contributions For Analysis:";
            // 
            // ColumnHeader4
            // 
            ColumnHeader4.Text = "Term";
            ColumnHeader4.Width = 50;
            // 
            // ColumnHeader3
            // 
            ColumnHeader3.Text = "Year";
            ColumnHeader3.Width = 50;
            // 
            // ColumnHeader2
            // 
            ColumnHeader2.Text = "Contribution";
            ColumnHeader2.Width = 80;
            // 
            // ColumnHeader1
            // 
            ColumnHeader1.Text = "Exam";
            ColumnHeader1.Width = 150;
            // 
            // lstExaminations
            // 
            lstExaminations.BackColor = SystemColors.Info;
            lstExaminations.Columns.AddRange(new ColumnHeader[] { ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4 });
            lstExaminations.ForeColor = Color.IndianRed;
            lstExaminations.GridLines = true;
            lstExaminations.Location = new Point(7, 38);
            lstExaminations.Margin = new Padding(3, 4, 3, 4);
            lstExaminations.Name = "lstExaminations";
            lstExaminations.Size = new Size(396, 123);
            lstExaminations.TabIndex = 6;
            lstExaminations.UseCompatibleStateImageBehavior = false;
            lstExaminations.View = View.Details;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = SystemColors.Control;
            lblTitle.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            lblTitle.Location = new Point(29, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(562, 36);
            lblTitle.TabIndex = 21;
            lblTitle.Text = "SUBJECT PERFORMANCE ANALYSIS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpSelect
            // 
            grpSelect.Controls.Add(_chkMode);
            grpSelect.Controls.Add(_txtContribution);
            grpSelect.Controls.Add(_btnAddExam);
            grpSelect.Controls.Add(Label8);
            grpSelect.Controls.Add(Label6);
            grpSelect.Controls.Add(grpMultiExaminations);
            grpSelect.Controls.Add(_btnAnalyze);
            grpSelect.Controls.Add(_cboClass);
            grpSelect.Controls.Add(_cboExamName);
            grpSelect.Controls.Add(Label1);
            grpSelect.Controls.Add(Label2);
            grpSelect.Controls.Add(_cboTerm);
            grpSelect.Controls.Add(Label3);
            grpSelect.Controls.Add(_cboYear);
            grpSelect.Controls.Add(Label4);
            grpSelect.Location = new Point(44, 49);
            grpSelect.Margin = new Padding(3, 4, 3, 4);
            grpSelect.Name = "grpSelect";
            grpSelect.Padding = new Padding(3, 4, 3, 4);
            grpSelect.Size = new Size(537, 384);
            grpSelect.TabIndex = 19;
            grpSelect.TabStop = false;
            grpSelect.Text = "Select Examination(s)";
            // 
            // chkMode
            // 
            _chkMode.AutoSize = true;
            _chkMode.Location = new Point(107, 18);
            _chkMode.Margin = new Padding(3, 4, 3, 4);
            _chkMode.Name = "_chkMode";
            _chkMode.Size = new Size(253, 21);
            _chkMode.TabIndex = 27;
            _chkMode.Text = "Analyse More Than One Examination";
            _chkMode.UseVisualStyleBackColor = true;
            // 
            // txtContribution
            // 
            _txtContribution.BackColor = SystemColors.Info;
            _txtContribution.ForeColor = Color.IndianRed;
            _txtContribution.Location = new Point(107, 121);
            _txtContribution.Margin = new Padding(3, 4, 3, 4);
            _txtContribution.Name = "_txtContribution";
            _txtContribution.Size = new Size(143, 23);
            _txtContribution.TabIndex = 48;
            // 
            // btnAddExam
            // 
            _btnAddExam.Image = (Image)resources.GetObject("btnAddExam.Image");
            _btnAddExam.Location = new Point(363, 119);
            _btnAddExam.Margin = new Padding(3, 4, 3, 4);
            _btnAddExam.Name = "_btnAddExam";
            _btnAddExam.Size = new Size(148, 28);
            _btnAddExam.TabIndex = 49;
            _btnAddExam.Text = "&Add Examination";
            _btnAddExam.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnAddExam.UseVisualStyleBackColor = true;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Location = new Point(258, 124);
            Label8.Name = "Label8";
            Label8.Size = new Size(80, 17);
            Label8.TabIndex = 51;
            Label8.Text = "% of 100%";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new Point(21, 124);
            Label6.Name = "Label6";
            Label6.Size = new Size(89, 17);
            Label6.TabIndex = 50;
            Label6.Text = "Contribution:";
            // 
            // grpMultiExaminations
            // 
            grpMultiExaminations.Controls.Add(lstExaminations);
            grpMultiExaminations.Controls.Add(Label5);
            grpMultiExaminations.Location = new Point(99, 144);
            grpMultiExaminations.Margin = new Padding(3, 4, 3, 4);
            grpMultiExaminations.Name = "grpMultiExaminations";
            grpMultiExaminations.Padding = new Padding(3, 4, 3, 4);
            grpMultiExaminations.Size = new Size(414, 167);
            grpMultiExaminations.TabIndex = 52;
            grpMultiExaminations.TabStop = false;
            // 
            // btnAnalyze
            // 
            _btnAnalyze.Image = (Image)resources.GetObject("btnAnalyze.Image");
            _btnAnalyze.Location = new Point(351, 342);
            _btnAnalyze.Margin = new Padding(3, 4, 3, 4);
            _btnAnalyze.Name = "_btnAnalyze";
            _btnAnalyze.Size = new Size(160, 37);
            _btnAnalyze.TabIndex = 3;
            _btnAnalyze.Text = "Analyze Examination";
            _btnAnalyze.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnAnalyze.UseVisualStyleBackColor = true;
            // 
            // cboClass
            // 
            _cboClass.BackColor = SystemColors.Info;
            _cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboClass.ForeColor = Color.IndianRed;
            _cboClass.FormattingEnabled = true;
            _cboClass.Location = new Point(107, 314);
            _cboClass.Margin = new Padding(3, 4, 3, 4);
            _cboClass.Name = "_cboClass";
            _cboClass.Size = new Size(403, 24);
            _cboClass.TabIndex = 1;
            // 
            // cboExamName
            // 
            _cboExamName.BackColor = SystemColors.Info;
            _cboExamName.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboExamName.ForeColor = Color.IndianRed;
            _cboExamName.FormattingEnabled = true;
            _cboExamName.Location = new Point(107, 94);
            _cboExamName.Margin = new Padding(3, 4, 3, 4);
            _cboExamName.Name = "_cboExamName";
            _cboExamName.Size = new Size(403, 24);
            _cboExamName.TabIndex = 1;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(63, 43);
            Label1.Name = "Label1";
            Label1.Size = new Size(40, 17);
            Label1.TabIndex = 0;
            Label1.Text = "Year:";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(62, 70);
            Label2.Name = "Label2";
            Label2.Size = new Size(45, 17);
            Label2.TabIndex = 0;
            Label2.Text = "Term:";
            // 
            // cboTerm
            // 
            _cboTerm.BackColor = SystemColors.Info;
            _cboTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerm.ForeColor = Color.IndianRed;
            _cboTerm.FormattingEnabled = true;
            _cboTerm.Items.AddRange(new object[] { "None", "I", "II", "III" });
            _cboTerm.Location = new Point(106, 66);
            _cboTerm.Margin = new Padding(3, 4, 3, 4);
            _cboTerm.Name = "_cboTerm";
            _cboTerm.Size = new Size(403, 24);
            _cboTerm.TabIndex = 1;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(22, 96);
            Label3.Name = "Label3";
            Label3.Size = new Size(88, 17);
            Label3.TabIndex = 0;
            Label3.Text = "Examination:";
            // 
            // cboYear
            // 
            _cboYear.BackColor = SystemColors.Info;
            _cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear.ForeColor = Color.IndianRed;
            _cboYear.FormattingEnabled = true;
            _cboYear.Location = new Point(107, 39);
            _cboYear.Margin = new Padding(3, 4, 3, 4);
            _cboYear.Name = "_cboYear";
            _cboYear.Size = new Size(403, 24);
            _cboYear.TabIndex = 1;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(61, 318);
            Label4.Name = "Label4";
            Label4.Size = new Size(43, 17);
            Label4.TabIndex = 0;
            Label4.Text = "Class:";
            // 
            // chkBestOf7
            // 
            chkBestOf7.AutoSize = true;
            chkBestOf7.Location = new Point(48, 21);
            chkBestOf7.Margin = new Padding(3, 4, 3, 4);
            chkBestOf7.Name = "chkBestOf7";
            chkBestOf7.Size = new Size(149, 21);
            chkBestOf7.TabIndex = 37;
            chkBestOf7.Text = "Use Best Of 7 Mode";
            chkBestOf7.UseVisualStyleBackColor = true;
            // 
            // grpAnalyze
            // 
            grpAnalyze.Controls.Add(chkBestOf7);
            grpAnalyze.Controls.Add(_Button4);
            grpAnalyze.Controls.Add(_radSubject);
            grpAnalyze.Controls.Add(_btnMeanGradeAnalysis);
            grpAnalyze.Controls.Add(_btnGradesAttained);
            grpAnalyze.Controls.Add(_btnStudentRank);
            grpAnalyze.Location = new Point(43, 441);
            grpAnalyze.Margin = new Padding(3, 4, 3, 4);
            grpAnalyze.Name = "grpAnalyze";
            grpAnalyze.Padding = new Padding(3, 4, 3, 4);
            grpAnalyze.Size = new Size(537, 213);
            grpAnalyze.TabIndex = 20;
            grpAnalyze.TabStop = false;
            grpAnalyze.Text = "Specific Subject Analysis";
            // 
            // Button4
            // 
            _Button4.Image = (Image)resources.GetObject("Button4.Image");
            _Button4.Location = new Point(262, 96);
            _Button4.Margin = new Padding(3, 4, 3, 4);
            _Button4.Name = "_Button4";
            _Button4.Size = new Size(250, 49);
            _Button4.TabIndex = 39;
            _Button4.Text = "Class Departmental Analysis";
            _Button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            _Button4.UseVisualStyleBackColor = true;
            // 
            // radSubject
            // 
            _radSubject.AutoSize = true;
            _radSubject.Location = new Point(278, 21);
            _radSubject.Margin = new Padding(3, 4, 3, 4);
            _radSubject.Name = "_radSubject";
            _radSubject.Size = new Size(194, 21);
            _radSubject.TabIndex = 36;
            _radSubject.Text = "Use Subject Based Grading";
            _radSubject.UseVisualStyleBackColor = true;
            // 
            // btnMeanGradeAnalysis
            // 
            _btnMeanGradeAnalysis.Image = (Image)resources.GetObject("btnMeanGradeAnalysis.Image");
            _btnMeanGradeAnalysis.Location = new Point(31, 96);
            _btnMeanGradeAnalysis.Margin = new Padding(3, 4, 3, 4);
            _btnMeanGradeAnalysis.Name = "_btnMeanGradeAnalysis";
            _btnMeanGradeAnalysis.Size = new Size(224, 49);
            _btnMeanGradeAnalysis.TabIndex = 3;
            _btnMeanGradeAnalysis.Text = "Subject Mean Analysis";
            _btnMeanGradeAnalysis.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnMeanGradeAnalysis.UseVisualStyleBackColor = true;
            // 
            // btnGradesAttained
            // 
            _btnGradesAttained.Image = (Image)resources.GetObject("btnGradesAttained.Image");
            _btnGradesAttained.Location = new Point(261, 43);
            _btnGradesAttained.Margin = new Padding(3, 4, 3, 4);
            _btnGradesAttained.Name = "_btnGradesAttained";
            _btnGradesAttained.Size = new Size(250, 49);
            _btnGradesAttained.TabIndex = 3;
            _btnGradesAttained.Text = "Subject Performance Analysis";
            _btnGradesAttained.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnGradesAttained.UseVisualStyleBackColor = true;
            // 
            // btnStudentRank
            // 
            _btnStudentRank.Image = (Image)resources.GetObject("btnStudentRank.Image");
            _btnStudentRank.Location = new Point(30, 43);
            _btnStudentRank.Margin = new Padding(3, 4, 3, 4);
            _btnStudentRank.Name = "_btnStudentRank";
            _btnStudentRank.Size = new Size(224, 49);
            _btnStudentRank.TabIndex = 3;
            _btnStudentRank.Text = "Student Ranking Per Subject";
            _btnStudentRank.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnStudentRank.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            _btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            _btnClear.Location = new Point(462, 662);
            _btnClear.Margin = new Padding(3, 4, 3, 4);
            _btnClear.Name = "_btnClear";
            _btnClear.Size = new Size(84, 47);
            _btnClear.TabIndex = 17;
            _btnClear.Text = "C&lear";
            _btnClear.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnClear.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(335, 662);
            _btnCancel.Margin = new Padding(3, 4, 3, 4);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(84, 47);
            _btnCancel.TabIndex = 18;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // bestStud
            // 
            _bestStud.Image = (Image)resources.GetObject("bestStud.Image");
            _bestStud.Location = new Point(74, 594);
            _bestStud.Margin = new Padding(3, 4, 3, 4);
            _bestStud.Name = "_bestStud";
            _bestStud.Size = new Size(224, 49);
            _bestStud.TabIndex = 22;
            _bestStud.Text = "Best Student Per Subject";
            _bestStud.TextImageRelation = TextImageRelation.ImageBeforeText;
            _bestStud.UseVisualStyleBackColor = true;
            // 
            // frmSubjectPerformanceSpecific
            // 
            AutoScaleDimensions = new SizeF(7.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 722);
            Controls.Add(_bestStud);
            Controls.Add(_btnClear);
            Controls.Add(_btnCancel);
            Controls.Add(lblTitle);
            Controls.Add(grpSelect);
            Controls.Add(grpAnalyze);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSubjectPerformanceSpecific";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Result Analysis";
            grpSelect.ResumeLayout(false);
            grpSelect.PerformLayout();
            grpMultiExaminations.ResumeLayout(false);
            grpAnalyze.ResumeLayout(false);
            grpAnalyze.PerformLayout();
            Load += new EventHandler(frmSubjectPerformance_Load);
            ResumeLayout(false);
        }

        internal PrintPreviewDialog printpreview;
        private Button _btnClear;

        internal Button btnClear
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClear;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClear != null)
                {
                    _btnClear.Click -= btnClear_Click;
                }

                _btnClear = value;
                if (_btnClear != null)
                {
                    _btnClear.Click += btnClear_Click;
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

        internal Label Label5;
        internal ColumnHeader ColumnHeader4;
        internal ColumnHeader ColumnHeader3;
        internal ColumnHeader ColumnHeader2;
        internal ColumnHeader ColumnHeader1;
        internal ListView lstExaminations;
        internal Label lblTitle;
        internal GroupBox grpSelect;
        private CheckBox _chkMode;

        internal CheckBox chkMode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkMode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkMode != null)
                {
                    _chkMode.CheckedChanged -= chkMode_CheckedChanged;
                }

                _chkMode = value;
                if (_chkMode != null)
                {
                    _chkMode.CheckedChanged += chkMode_CheckedChanged;
                }
            }
        }

        private TextBox _txtContribution;

        internal TextBox txtContribution
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContribution;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContribution != null)
                {
                    _txtContribution.KeyPress -= txtContribution_KeyPress;
                }

                _txtContribution = value;
                if (_txtContribution != null)
                {
                    _txtContribution.KeyPress += txtContribution_KeyPress;
                }
            }
        }

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

        internal Label Label8;
        internal Label Label6;
        internal GroupBox grpMultiExaminations;
        private Button _btnAnalyze;

        internal Button btnAnalyze
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAnalyze;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAnalyze != null)
                {
                    _btnAnalyze.Click -= btnAnalyze_Click;
                }

                _btnAnalyze = value;
                if (_btnAnalyze != null)
                {
                    _btnAnalyze.Click += btnAnalyze_Click;
                }
            }
        }

        private ComboBox _cboClass;

        internal ComboBox cboClass
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboClass;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboClass != null)
                {
                    _cboClass.SelectedIndexChanged -= cboClass_SelectedIndexChanged;
                }

                _cboClass = value;
                if (_cboClass != null)
                {
                    _cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
                }
            }
        }

        private ComboBox _cboExamName;

        internal ComboBox cboExamName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboExamName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboExamName != null)
                {
                    _cboExamName.SelectedIndexChanged -= cboExamName_SelectedIndexChanged;
                }

                _cboExamName = value;
                if (_cboExamName != null)
                {
                    _cboExamName.SelectedIndexChanged += cboExamName_SelectedIndexChanged;
                }
            }
        }

        internal Label Label1;
        internal Label Label2;
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

        internal Label Label3;
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
        private Button _btnGradesAttained;

        internal Button btnGradesAttained
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGradesAttained;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGradesAttained != null)
                {
                    _btnGradesAttained.Click -= btnGradesAttained_Click;
                }

                _btnGradesAttained = value;
                if (_btnGradesAttained != null)
                {
                    _btnGradesAttained.Click += btnGradesAttained_Click;
                }
            }
        }

        private Button _btnStudentRank;

        internal Button btnStudentRank
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnStudentRank;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnStudentRank != null)
                {
                    _btnStudentRank.Click -= Button2_Click;
                }

                _btnStudentRank = value;
                if (_btnStudentRank != null)
                {
                    _btnStudentRank.Click += Button2_Click;
                }
            }
        }

        private Button _btnMeanGradeAnalysis;

        internal Button btnMeanGradeAnalysis
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMeanGradeAnalysis;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMeanGradeAnalysis != null)
                {
                    _btnMeanGradeAnalysis.Click -= Button4_Click;
                }

                _btnMeanGradeAnalysis = value;
                if (_btnMeanGradeAnalysis != null)
                {
                    _btnMeanGradeAnalysis.Click += Button4_Click;
                }
            }
        }

        internal CheckBox chkBestOf7;
        private Button _Button4;

        internal Button Button4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button4 != null)
                {
                    _Button4.Click -= Button4_Click_1;
                }

                _Button4 = value;
                if (_Button4 != null)
                {
                    _Button4.Click += Button4_Click_1;
                }
            }
        }

        internal GroupBox grpAnalyze;
        private CheckBox _radSubject;

        internal CheckBox radSubject
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radSubject;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radSubject != null)
                {
                    _radSubject.CheckedChanged -= radSubject_CheckedChanged;
                }

                _radSubject = value;
                if (_radSubject != null)
                {
                    _radSubject.CheckedChanged += radSubject_CheckedChanged;
                }
            }
        }

        private Button _bestStud;

        internal Button bestStud
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _bestStud;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_bestStud != null)
                {
                    _bestStud.Click -= bestStud_Click;
                }

                _bestStud = value;
                if (_bestStud != null)
                {
                    _bestStud.Click += bestStud_Click;
                }
            }
        }
    }
}