using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmSubjectRank : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectRank));
            radNone = new RadioButton();
            txtNumber = new TextBox();
            _radLast = new RadioButton();
            _radLast.CheckedChanged += new EventHandler(radLast_CheckedChanged);
            _radFirst = new RadioButton();
            _radFirst.CheckedChanged += new EventHandler(radFirst_CheckedChanged);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnAnalyze = new Button();
            _btnAnalyze.Click += new EventHandler(btnAnalyze_Click);
            cboSubject = new ComboBox();
            Label1 = new Label();
            SuspendLayout();
            // 
            // radNone
            // 
            radNone.AutoSize = true;
            radNone.Location = new Point(119, 50);
            radNone.Name = "radNone";
            radNone.Size = new Size(50, 17);
            radNone.TabIndex = 13;
            radNone.TabStop = true;
            radNone.Text = "None";
            radNone.UseVisualStyleBackColor = true;
            // 
            // txtNumber
            // 
            txtNumber.BackColor = SystemColors.Info;
            txtNumber.ForeColor = Color.Brown;
            txtNumber.Location = new Point(123, 76);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(182, 21);
            txtNumber.TabIndex = 12;
            // 
            // radLast
            // 
            _radLast.AutoSize = true;
            _radLast.Location = new Point(226, 50);
            _radLast.Name = "_radLast";
            _radLast.Size = new Size(59, 17);
            _radLast.TabIndex = 10;
            _radLast.TabStop = true;
            _radLast.Text = "Bottom";
            _radLast.UseVisualStyleBackColor = true;
            // 
            // radFirst
            // 
            _radFirst.AutoSize = true;
            _radFirst.Location = new Point(176, 50);
            _radFirst.Name = "_radFirst";
            _radFirst.Size = new Size(43, 17);
            _radFirst.TabIndex = 11;
            _radFirst.TabStop = true;
            _radFirst.Text = "Top";
            _radFirst.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(138, 108);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(69, 32);
            _btnCancel.TabIndex = 8;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAnalyze
            // 
            _btnAnalyze.Image = (Image)resources.GetObject("btnAnalyze.Image");
            _btnAnalyze.Location = new Point(226, 108);
            _btnAnalyze.Name = "_btnAnalyze";
            _btnAnalyze.Size = new Size(79, 32);
            _btnAnalyze.TabIndex = 9;
            _btnAnalyze.Text = "&Analyze";
            _btnAnalyze.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnAnalyze.UseVisualStyleBackColor = true;
            // 
            // cboSubject
            // 
            cboSubject.BackColor = SystemColors.Info;
            cboSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSubject.ForeColor = Color.IndianRed;
            cboSubject.FormattingEnabled = true;
            cboSubject.Location = new Point(123, 18);
            cboSubject.Name = "cboSubject";
            cboSubject.Size = new Size(182, 21);
            cboSubject.TabIndex = 7;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(14, 21);
            Label1.Name = "Label1";
            Label1.Size = new Size(102, 13);
            Label1.TabIndex = 6;
            Label1.Text = "Subject of Analysis:";
            // 
            // frmSubjectRank
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 163);
            Controls.Add(radNone);
            Controls.Add(txtNumber);
            Controls.Add(_radLast);
            Controls.Add(_radFirst);
            Controls.Add(_btnCancel);
            Controls.Add(_btnAnalyze);
            Controls.Add(cboSubject);
            Controls.Add(Label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSubjectRank";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subject Ranking Prompt";
            Load += new EventHandler(frmSubjectRank_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal RadioButton radNone;
        internal TextBox txtNumber;
        private RadioButton _radLast;

        internal RadioButton radLast
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radLast;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radLast != null)
                {
                    _radLast.CheckedChanged -= radLast_CheckedChanged;
                }

                _radLast = value;
                if (_radLast != null)
                {
                    _radLast.CheckedChanged += radLast_CheckedChanged;
                }
            }
        }

        private RadioButton _radFirst;

        internal RadioButton radFirst
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radFirst;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radFirst != null)
                {
                    _radFirst.CheckedChanged -= radFirst_CheckedChanged;
                }

                _radFirst = value;
                if (_radFirst != null)
                {
                    _radFirst.CheckedChanged += radFirst_CheckedChanged;
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

        internal ComboBox cboSubject;
        internal Label Label1;
    }
}