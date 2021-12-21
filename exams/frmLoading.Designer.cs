using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace exams
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmLoading : Form
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
            components = new System.ComponentModel.Container();
            Label1 = new Label();
            progressBar = new ProgressBar();
            _StartTimer = new Timer(components);
            _StartTimer.Tick += new EventHandler(StartTimer_Tick);
            Label2 = new Label();
            SuspendLayout();
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(23, 6);
            Label1.Name = "Label1";
            Label1.Size = new Size(54, 13);
            Label1.TabIndex = 3;
            Label1.Text = "Loading...";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 24);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(339, 36);
            progressBar.TabIndex = 2;
            // 
            // StartTimer
            // 
            _StartTimer.Interval = 10;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(269, 6);
            Label2.Name = "Label2";
            Label2.Size = new Size(69, 13);
            Label2.TabIndex = 4;
            Label2.Text = "...please wait";
            // 
            // frmLoading
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 73);
            ControlBox = false;
            Controls.Add(Label1);
            Controls.Add(progressBar);
            Controls.Add(Label2);
            Name = "frmLoading";
            StartPosition = FormStartPosition.CenterScreen;
            Load += new EventHandler(frmLoading_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label Label1;
        internal ProgressBar progressBar;
        private Timer _StartTimer;

        internal Timer StartTimer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StartTimer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_StartTimer != null)
                {
                    _StartTimer.Tick -= StartTimer_Tick;
                }

                _StartTimer = value;
                if (_StartTimer != null)
                {
                    _StartTimer.Tick += StartTimer_Tick;
                }
            }
        }

        internal Label Label2;
    }
}