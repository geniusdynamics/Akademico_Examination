using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace exams
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmNationalExamPerformance : DevExpress.XtraEditors.XtraForm
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
            cboExamination = new ComboBox();
            _cboYear = new ComboBox();
            _cboYear.SelectedIndexChanged += new EventHandler(cboYear_SelectedIndexChanged);
            Label2 = new Label();
            Label1 = new Label();
            _Button4 = new Button();
            _Button4.Click += new EventHandler(Button4_Click);
            _Button3 = new Button();
            _Button3.Click += new EventHandler(Button3_Click);
            _Button2 = new Button();
            _Button2.Click += new EventHandler(Button2_Click);
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            SuspendLayout();
            // 
            // cboExamination
            // 
            cboExamination.BackColor = SystemColors.Info;
            cboExamination.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExamination.ForeColor = Color.IndianRed;
            cboExamination.FormattingEnabled = true;
            cboExamination.Location = new Point(256, 22);
            cboExamination.Name = "cboExamination";
            cboExamination.Size = new Size(181, 21);
            cboExamination.TabIndex = 12;
            // 
            // cboYear
            // 
            _cboYear.BackColor = SystemColors.Info;
            _cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear.ForeColor = Color.IndianRed;
            _cboYear.FormattingEnabled = true;
            _cboYear.Location = new Point(74, 22);
            _cboYear.Name = "_cboYear";
            _cboYear.Size = new Size(69, 21);
            _cboYear.TabIndex = 13;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(180, 25);
            Label2.Name = "Label2";
            Label2.Size = new Size(69, 13);
            Label2.TabIndex = 10;
            Label2.Text = "Examination:";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(42, 25);
            Label1.Name = "Label1";
            Label1.Size = new Size(33, 13);
            Label1.TabIndex = 11;
            Label1.Text = "Year:";
            // 
            // Button4
            // 
            _Button4.Location = new Point(249, 93);
            _Button4.Name = "_Button4";
            _Button4.Size = new Size(188, 29);
            _Button4.TabIndex = 8;
            _Button4.Text = "Overall Performance Index";
            _Button4.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            _Button3.Location = new Point(34, 93);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(188, 29);
            _Button3.TabIndex = 6;
            _Button3.Text = "Subject Grade Attainance";
            _Button3.UseVisualStyleBackColor = true;
            // 
            // Button2
            // 
            _Button2.Location = new Point(249, 59);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(188, 29);
            _Button2.TabIndex = 9;
            _Button2.Text = "Subject Performance Index";
            _Button2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            _Button1.Location = new Point(34, 59);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(188, 29);
            _Button1.TabIndex = 7;
            _Button1.Text = "Subject Ranking";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // frmNationalExamPerformance
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 146);
            Controls.Add(cboExamination);
            Controls.Add(_cboYear);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(_Button4);
            Controls.Add(_Button3);
            Controls.Add(_Button2);
            Controls.Add(_Button1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNationalExamPerformance";
            Text = "National Exam Performance Analysis";
            Load += new EventHandler(frmNationalExamPerformance_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal ComboBox cboExamination;
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

        internal Label Label2;
        internal Label Label1;
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
                    _Button4.Click -= Button4_Click;
                }

                _Button4 = value;
                if (_Button4 != null)
                {
                    _Button4.Click += Button4_Click;
                }
            }
        }

        private Button _Button3;

        internal Button Button3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button3 != null)
                {
                    _Button3.Click -= Button3_Click;
                }

                _Button3 = value;
                if (_Button3 != null)
                {
                    _Button3.Click += Button3_Click;
                }
            }
        }

        private Button _Button2;

        internal Button Button2
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