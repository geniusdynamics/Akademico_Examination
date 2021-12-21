using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmSubjectRankPrompt2 : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectRankPrompt2));
            txtNumber = new TextBox();
            radLast = new RadioButton();
            radFirst = new RadioButton();
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnAnalyze = new Button();
            _btnAnalyze.Click += new EventHandler(btnAnalyze_Click);
            radNone = new RadioButton();
            SuspendLayout();
            // 
            // txtNumber
            // 
            txtNumber.BackColor = SystemColors.Info;
            txtNumber.ForeColor = Color.Brown;
            txtNumber.Location = new Point(64, 64);
            txtNumber.Margin = new Padding(3, 4, 3, 4);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(220, 22);
            txtNumber.TabIndex = 18;
            // 
            // radLast
            // 
            radLast.AutoSize = true;
            radLast.Location = new Point(211, 32);
            radLast.Margin = new Padding(3, 4, 3, 4);
            radLast.Name = "radLast";
            radLast.Size = new Size(73, 21);
            radLast.TabIndex = 16;
            radLast.TabStop = true;
            radLast.Text = "Bottom";
            radLast.UseVisualStyleBackColor = true;
            // 
            // radFirst
            // 
            radFirst.AutoSize = true;
            radFirst.Location = new Point(133, 32);
            radFirst.Margin = new Padding(3, 4, 3, 4);
            radFirst.Name = "radFirst";
            radFirst.Size = new Size(54, 21);
            radFirst.TabIndex = 17;
            radFirst.TabStop = true;
            radFirst.Text = "Top";
            radFirst.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(90, 103);
            _btnCancel.Margin = new Padding(3, 4, 3, 4);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(80, 39);
            _btnCancel.TabIndex = 14;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAnalyze
            // 
            _btnAnalyze.Image = (Image)resources.GetObject("btnAnalyze.Image");
            _btnAnalyze.Location = new Point(193, 103);
            _btnAnalyze.Margin = new Padding(3, 4, 3, 4);
            _btnAnalyze.Name = "_btnAnalyze";
            _btnAnalyze.Size = new Size(92, 39);
            _btnAnalyze.TabIndex = 15;
            _btnAnalyze.Text = "&Analyze";
            _btnAnalyze.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnAnalyze.UseVisualStyleBackColor = true;
            // 
            // radNone
            // 
            radNone.AutoSize = true;
            radNone.Location = new Point(64, 32);
            radNone.Margin = new Padding(3, 4, 3, 4);
            radNone.Name = "radNone";
            radNone.Size = new Size(63, 21);
            radNone.TabIndex = 19;
            radNone.TabStop = true;
            radNone.Text = "None";
            radNone.UseVisualStyleBackColor = true;
            // 
            // frmSubjectRankPrompt2
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 177);
            Controls.Add(radNone);
            Controls.Add(txtNumber);
            Controls.Add(radLast);
            Controls.Add(radFirst);
            Controls.Add(_btnCancel);
            Controls.Add(_btnAnalyze);
            MinimizeBox = false;
            Name = "frmSubjectRankPrompt2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subject Rank Prompt";
            Load += new EventHandler(frmSubjectRankPrompt2_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal TextBox txtNumber;
        internal RadioButton radLast;
        internal RadioButton radFirst;
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

        internal RadioButton radNone;
    }
}