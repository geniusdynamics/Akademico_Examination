using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace exams
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmPrintFrom : DevExpress.XtraEditors.XtraForm
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
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            txtTo = new TextBox();
            txtFrom = new TextBox();
            Label2 = new Label();
            Label1 = new Label();
            SuspendLayout();
            // 
            // Button1
            // 
            _Button1.Location = new Point(188, 69);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(139, 23);
            _Button1.TabIndex = 9;
            _Button1.Text = "Proceed To Print";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(110, 42);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(217, 21);
            txtTo.TabIndex = 8;
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(110, 15);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(217, 21);
            txtFrom.TabIndex = 7;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(36, 45);
            Label2.Name = "Label2";
            Label2.Size = new Size(67, 13);
            Label2.TabIndex = 6;
            Label2.Text = "To Adm. No:";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(22, 18);
            Label1.Name = "Label1";
            Label1.Size = new Size(79, 13);
            Label1.TabIndex = 5;
            Label1.Text = "From Adm. No:";
            // 
            // frmPrintFrom
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 118);
            Controls.Add(_Button1);
            Controls.Add(txtTo);
            Controls.Add(txtFrom);
            Controls.Add(Label2);
            Controls.Add(Label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPrintFrom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Print Form";
            Load += new EventHandler(frmPrintFrom_Load);
            ResumeLayout(false);
            PerformLayout();
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

        internal TextBox txtTo;
        internal TextBox txtFrom;
        internal Label Label2;
        internal Label Label1;
    }
}