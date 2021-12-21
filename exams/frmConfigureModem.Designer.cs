using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace exams
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmConfigureModem : DevExpress.XtraEditors.XtraForm
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
            txtPhone = new TextBox();
            Label1 = new Label();
            SuspendLayout();
            // 
            // Button1
            // 
            _Button1.Location = new Point(153, 51);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(123, 23);
            _Button1.TabIndex = 5;
            _Button1.Text = "Find And Configure";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(138, 24);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(138, 21);
            txtPhone.TabIndex = 4;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(16, 27);
            Label1.Name = "Label1";
            Label1.Size = new Size(111, 13);
            Label1.TabIndex = 3;
            Label1.Text = "Enter Your Phone No:";
            // 
            // frmConfigureModem
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(319, 105);
            Controls.Add(_Button1);
            Controls.Add(txtPhone);
            Controls.Add(Label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfigureModem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configure Modem";
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

        internal TextBox txtPhone;
        internal Label Label1;
    }
}