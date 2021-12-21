using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace exams
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class WaitForm1 : DevExpress.XtraWaitForm.WaitForm
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
            progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // progressPanel1
            // 
            progressPanel1.Appearance.BackColor = Color.Transparent;
            progressPanel1.Appearance.Options.UseBackColor = true;
            progressPanel1.AppearanceCaption.Font = new Font("Microsoft Sans Serif", 12.0f);
            progressPanel1.AppearanceCaption.Options.UseFont = true;
            progressPanel1.AppearanceDescription.Font = new Font("Microsoft Sans Serif", 8.25f);
            progressPanel1.AppearanceDescription.Options.UseFont = true;
            progressPanel1.Dock = DockStyle.Fill;
            progressPanel1.ImageHorzOffset = 20;
            progressPanel1.Location = new Point(0, 17);
            progressPanel1.Margin = new Padding(0, 3, 0, 3);
            progressPanel1.Name = "progressPanel1";
            progressPanel1.Size = new Size(246, 39);
            progressPanel1.TabIndex = 0;
            progressPanel1.Text = "progressPanel1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f));
            tableLayoutPanel1.Controls.Add(progressPanel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(0, 14, 0, 14);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f));
            tableLayoutPanel1.Size = new Size(246, 73);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(246, 73);
            Controls.Add(tableLayoutPanel1);
            DoubleBuffered = true;
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}