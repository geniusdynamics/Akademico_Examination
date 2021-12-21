using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace exams
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmWait : DevExpress.XtraEditors.XtraForm
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
            components = new System.ComponentModel.Container();
            lblOperation = new Label();
            Label1 = new Label();
            ProgressBar1 = new ProgressBar();
            _Timer1 = new Timer(components);
            _Timer1.Tick += new EventHandler(Timer1_Tick);
            SuspendLayout();
            // 
            // lblOperation
            // 
            lblOperation.AutoSize = true;
            lblOperation.Location = new Point(3, 9);
            lblOperation.Name = "lblOperation";
            lblOperation.Size = new Size(81, 13);
            lblOperation.TabIndex = 0;
            lblOperation.Text = "Saving Data....";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(389, 9);
            Label1.Name = "Label1";
            Label1.Size = new Size(76, 13);
            Label1.TabIndex = 1;
            Label1.Text = "... please wait";
            // 
            // ProgressBar1
            // 
            ProgressBar1.Location = new Point(6, 25);
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new Size(459, 40);
            ProgressBar1.TabIndex = 2;
            // 
            // Timer1
            // 
            // 
            // frmWait
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 77);
            ControlBox = false;
            Controls.Add(ProgressBar1);
            Controls.Add(Label1);
            Controls.Add(lblOperation);
            Name = "frmWait";
            StartPosition = FormStartPosition.CenterScreen;
            Load += new EventHandler(frmWait_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label lblOperation;
        internal Label Label1;
        internal ProgressBar ProgressBar1;
        private Timer _Timer1;

        internal Timer Timer1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Timer1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Timer1 != null)
                {
                    _Timer1.Tick -= Timer1_Tick;
                }

                _Timer1 = value;
                if (_Timer1 != null)
                {
                    _Timer1.Tick += Timer1_Tick;
                }
            }
        }
    }
}