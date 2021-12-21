using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmDepartmentalSubjectAnalysis : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartmentalSubjectAnalysis));
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnAnalyze = new Button();
            _btnAnalyze.Click += new EventHandler(btnAnalyze_Click);
            cboSubject = new ComboBox();
            Label1 = new Label();
            printpreview = new PrintPreviewDialog();
            SuspendLayout();
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(136, 52);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(69, 32);
            _btnCancel.TabIndex = 9;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAnalyze
            // 
            _btnAnalyze.Image = (Image)resources.GetObject("btnAnalyze.Image");
            _btnAnalyze.Location = new Point(224, 52);
            _btnAnalyze.Name = "_btnAnalyze";
            _btnAnalyze.Size = new Size(79, 32);
            _btnAnalyze.TabIndex = 10;
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
            cboSubject.Location = new Point(121, 12);
            cboSubject.Name = "cboSubject";
            cboSubject.Size = new Size(182, 21);
            cboSubject.TabIndex = 8;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(12, 15);
            Label1.Name = "Label1";
            Label1.Size = new Size(102, 13);
            Label1.TabIndex = 7;
            Label1.Text = "Subject of Analysis:";
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
            // frmDepartmentalSubjectAnalysis
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 104);
            Controls.Add(_btnCancel);
            Controls.Add(_btnAnalyze);
            Controls.Add(cboSubject);
            Controls.Add(Label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDepartmentalSubjectAnalysis";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subject Performance Analysis";
            Load += new EventHandler(frmSubjectRank_Load);
            ResumeLayout(false);
            PerformLayout();
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
        internal PrintPreviewDialog printpreview;
    }
}