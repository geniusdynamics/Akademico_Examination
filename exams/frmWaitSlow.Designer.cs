using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace exams
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmWaitSlow : DevExpress.XtraEditors.XtraForm
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
            ProgressBar1 = new ProgressBar();
            Label1 = new Label();
            lblOperation = new Label();
            _Timer1 = new Timer(components);
            _Timer1.Tick += new EventHandler(Timer1_Tick);
            SuspendLayout();
            // 
            // ProgressBar1
            // 
            ProgressBar1.Location = new Point(24, 30);
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new Size(459, 40);
            ProgressBar1.TabIndex = 5;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(407, 14);
            Label1.Name = "Label1";
            Label1.Size = new Size(76, 13);
            Label1.TabIndex = 4;
            Label1.Text = "... please wait";
            // 
            // lblOperation
            // 
            lblOperation.AutoSize = true;
            lblOperation.Location = new Point(21, 14);
            lblOperation.Name = "lblOperation";
            lblOperation.Size = new Size(81, 13);
            lblOperation.TabIndex = 3;
            lblOperation.Text = "Saving Data....";
            // 
            // Timer1
            // 
            // 
            // frmWaitSlow
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 91);
            ControlBox = false;
            Controls.Add(ProgressBar1);
            Controls.Add(Label1);
            Controls.Add(lblOperation);
            Name = "frmWaitSlow";
            StartPosition = FormStartPosition.CenterScreen;
            Load += new EventHandler(frmWait_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal ProgressBar ProgressBar1;
        internal Label Label1;
        internal Label lblOperation;
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