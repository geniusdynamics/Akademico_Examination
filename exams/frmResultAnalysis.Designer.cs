using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmResultAnalysis : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResultAnalysis));
            CheckBox1 = new CheckBox();
            ColumnHeader4 = new ColumnHeader();
            ColumnHeader3 = new ColumnHeader();
            ColumnHeader2 = new ColumnHeader();
            Label10 = new Label();
            _btnAddExam = new Button();
            _btnAddExam.Click += new EventHandler(btnAddExam_Click);
            ColumnHeader1 = new ColumnHeader();
            _chkMode = new CheckBox();
            _chkMode.CheckedChanged += new EventHandler(chkMode_CheckedChanged);
            _btnEnterMarks = new Button();
            _btnEnterMarks.Click += new EventHandler(btnEnterMarks_Click);
            _btnClear = new Button();
            _btnClear.Click += new EventHandler(btnClear_Click);
            cboSortBy = new ComboBox();
            _txtContribution = new TextBox();
            _txtContribution.KeyPress += new KeyPressEventHandler(txtContribution_KeyPress);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _cboClass = new ComboBox();
            _cboClass.SelectedIndexChanged += new EventHandler(cboClass_SelectedIndexChanged);
            Label2 = new Label();
            Label5 = new Label();
            _cboExamName = new ComboBox();
            _cboExamName.SelectedIndexChanged += new EventHandler(cboExamName_SelectedIndexChanged);
            Label8 = new Label();
            Label6 = new Label();
            Label1 = new Label();
            _cboYear = new ComboBox();
            _cboYear.SelectedValueChanged += new EventHandler(cboTerm_SelectedValueChanged);
            Label4 = new Label();
            _cboTerm = new ComboBox();
            _cboTerm.SelectedValueChanged += new EventHandler(cboTerm_SelectedValueChanged);
            Label7 = new Label();
            grpMultiExaminations = new GroupBox();
            lstExaminations = new ListView();
            grpMultiExaminations.SuspendLayout();
            SuspendLayout();
            // 
            // CheckBox1
            // 
            CheckBox1.AutoSize = true;
            CheckBox1.Location = new Point(95, 315);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(181, 17);
            CheckBox1.TabIndex = 71;
            CheckBox1.Text = "Show Split Subject Contributions";
            CheckBox1.UseVisualStyleBackColor = true;
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
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.Location = new Point(42, 291);
            Label10.Name = "Label10";
            Label10.Size = new Size(50, 13);
            Label10.TabIndex = 70;
            Label10.Text = "Rank By:";
            // 
            // btnAddExam
            // 
            _btnAddExam.Image = (Image)resources.GetObject("btnAddExam.Image");
            _btnAddExam.Location = new Point(262, 108);
            _btnAddExam.Name = "_btnAddExam";
            _btnAddExam.Size = new Size(127, 23);
            _btnAddExam.TabIndex = 57;
            _btnAddExam.Text = "&Add Examination";
            _btnAddExam.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnAddExam.UseVisualStyleBackColor = true;
            // 
            // ColumnHeader1
            // 
            ColumnHeader1.Text = "Exam";
            ColumnHeader1.Width = 100;
            // 
            // chkMode
            // 
            _chkMode.AutoSize = true;
            _chkMode.Location = new Point(97, 18);
            _chkMode.Name = "_chkMode";
            _chkMode.Size = new Size(205, 17);
            _chkMode.TabIndex = 52;
            _chkMode.Text = "Combine More Than One Examination";
            _chkMode.UseVisualStyleBackColor = true;
            // 
            // btnEnterMarks
            // 
            _btnEnterMarks.Image = (Image)resources.GetObject("btnEnterMarks.Image");
            _btnEnterMarks.Location = new Point(275, 338);
            _btnEnterMarks.Name = "_btnEnterMarks";
            _btnEnterMarks.Size = new Size(111, 32);
            _btnEnterMarks.TabIndex = 64;
            _btnEnterMarks.Text = "&Analyse";
            _btnEnterMarks.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnEnterMarks.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            _btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            _btnClear.Location = new Point(207, 338);
            _btnClear.Name = "_btnClear";
            _btnClear.Size = new Size(63, 32);
            _btnClear.TabIndex = 66;
            _btnClear.Text = "C&lear";
            _btnClear.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnClear.UseVisualStyleBackColor = true;
            // 
            // cboSortBy
            // 
            cboSortBy.BackColor = SystemColors.Info;
            cboSortBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSortBy.ForeColor = Color.IndianRed;
            cboSortBy.FormattingEnabled = true;
            cboSortBy.Items.AddRange(new object[] { "Total Marks", "Mean Marks", "Mean Points", "Total Points" });
            cboSortBy.Location = new Point(95, 288);
            cboSortBy.Name = "cboSortBy";
            cboSortBy.Size = new Size(291, 21);
            cboSortBy.TabIndex = 69;
            // 
            // txtContribution
            // 
            _txtContribution.BackColor = SystemColors.Info;
            _txtContribution.ForeColor = Color.IndianRed;
            _txtContribution.Location = new Point(98, 109);
            _txtContribution.Name = "_txtContribution";
            _txtContribution.Size = new Size(96, 21);
            _txtContribution.TabIndex = 56;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(131, 338);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(72, 32);
            _btnCancel.TabIndex = 67;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // cboClass
            // 
            _cboClass.BackColor = SystemColors.Info;
            _cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboClass.ForeColor = Color.IndianRed;
            _cboClass.FormattingEnabled = true;
            _cboClass.Location = new Point(95, 266);
            _cboClass.Name = "_cboClass";
            _cboClass.Size = new Size(291, 21);
            _cboClass.TabIndex = 58;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(59, 268);
            Label2.Name = "Label2";
            Label2.Size = new Size(36, 13);
            Label2.TabIndex = 59;
            Label2.Text = "Class:";
            // 
            // Label5
            // 
            Label5.Location = new Point(7, 21);
            Label5.Name = "Label5";
            Label5.Size = new Size(71, 100);
            Label5.TabIndex = 9;
            Label5.Text = "List Of Examinations And Their Respective Contributions For Analysis:";
            // 
            // cboExamName
            // 
            _cboExamName.BackColor = SystemColors.Info;
            _cboExamName.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboExamName.ForeColor = Color.IndianRed;
            _cboExamName.FormattingEnabled = true;
            _cboExamName.Location = new Point(97, 87);
            _cboExamName.Name = "_cboExamName";
            _cboExamName.Size = new Size(289, 21);
            _cboExamName.TabIndex = 55;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Location = new Point(200, 112);
            Label8.Name = "Label8";
            Label8.Size = new Size(63, 13);
            Label8.TabIndex = 62;
            Label8.Text = "% of 100%";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new Point(24, 112);
            Label6.Name = "Label6";
            Label6.Size = new Size(70, 13);
            Label6.TabIndex = 60;
            Label6.Text = "Contribution:";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(24, 90);
            Label1.Name = "Label1";
            Label1.Size = new Size(67, 13);
            Label1.TabIndex = 63;
            Label1.Text = "Exam Name:";
            // 
            // cboYear
            // 
            _cboYear.BackColor = SystemColors.Info;
            _cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear.ForeColor = Color.IndianRed;
            _cboYear.FormattingEnabled = true;
            _cboYear.Items.AddRange(new object[] { "None", "I", "II", "III" });
            _cboYear.Location = new Point(97, 43);
            _cboYear.Name = "_cboYear";
            _cboYear.Size = new Size(291, 21);
            _cboYear.TabIndex = 53;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(61, 46);
            Label4.Name = "Label4";
            Label4.Size = new Size(33, 13);
            Label4.TabIndex = 61;
            Label4.Text = "Year:";
            // 
            // cboTerm
            // 
            _cboTerm.BackColor = SystemColors.Info;
            _cboTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerm.ForeColor = Color.IndianRed;
            _cboTerm.FormattingEnabled = true;
            _cboTerm.Items.AddRange(new object[] { "None", "I", "II", "III" });
            _cboTerm.Location = new Point(97, 65);
            _cboTerm.Name = "_cboTerm";
            _cboTerm.Size = new Size(291, 21);
            _cboTerm.TabIndex = 54;
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Location = new Point(56, 68);
            Label7.Name = "Label7";
            Label7.Size = new Size(35, 13);
            Label7.TabIndex = 65;
            Label7.Text = "Term:";
            // 
            // grpMultiExaminations
            // 
            grpMultiExaminations.Controls.Add(lstExaminations);
            grpMultiExaminations.Controls.Add(Label5);
            grpMultiExaminations.Location = new Point(17, 128);
            grpMultiExaminations.Name = "grpMultiExaminations";
            grpMultiExaminations.Size = new Size(376, 132);
            grpMultiExaminations.TabIndex = 68;
            grpMultiExaminations.TabStop = false;
            // 
            // lstExaminations
            // 
            lstExaminations.BackColor = SystemColors.Info;
            lstExaminations.Columns.AddRange(new ColumnHeader[] { ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4 });
            lstExaminations.ForeColor = Color.IndianRed;
            lstExaminations.GridLines = true;
            lstExaminations.Location = new Point(78, 20);
            lstExaminations.Name = "lstExaminations";
            lstExaminations.Size = new Size(290, 101);
            lstExaminations.TabIndex = 6;
            lstExaminations.UseCompatibleStateImageBehavior = false;
            lstExaminations.View = View.Details;
            // 
            // frmResultAnalysis
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 408);
            Controls.Add(CheckBox1);
            Controls.Add(Label10);
            Controls.Add(_btnAddExam);
            Controls.Add(_chkMode);
            Controls.Add(_btnEnterMarks);
            Controls.Add(_btnClear);
            Controls.Add(cboSortBy);
            Controls.Add(_txtContribution);
            Controls.Add(_btnCancel);
            Controls.Add(_cboClass);
            Controls.Add(Label2);
            Controls.Add(_cboExamName);
            Controls.Add(Label8);
            Controls.Add(Label6);
            Controls.Add(Label1);
            Controls.Add(_cboYear);
            Controls.Add(Label4);
            Controls.Add(_cboTerm);
            Controls.Add(Label7);
            Controls.Add(grpMultiExaminations);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmResultAnalysis";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Result Analysis";
            grpMultiExaminations.ResumeLayout(false);
            Load += new EventHandler(frmExamEntry_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal CheckBox CheckBox1;
        internal ColumnHeader ColumnHeader4;
        internal ColumnHeader ColumnHeader3;
        internal ColumnHeader ColumnHeader2;
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

        internal ColumnHeader ColumnHeader1;
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

        internal ComboBox cboSortBy;
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

        internal Label Label2;
        internal Label Label5;
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

        internal Label Label8;
        internal Label Label6;
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
                    _cboYear.SelectedValueChanged -= cboTerm_SelectedValueChanged;
                }

                _cboYear = value;
                if (_cboYear != null)
                {
                    _cboYear.SelectedValueChanged += cboTerm_SelectedValueChanged;
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
                    _cboTerm.SelectedValueChanged -= cboTerm_SelectedValueChanged;
                }

                _cboTerm = value;
                if (_cboTerm != null)
                {
                    _cboTerm.SelectedValueChanged += cboTerm_SelectedValueChanged;
                }
            }
        }

        internal Label Label7;
        internal GroupBox grpMultiExaminations;
        internal ListView lstExaminations;
    }
}