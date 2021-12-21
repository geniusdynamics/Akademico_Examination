using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace exams
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmFilter : DevExpress.XtraEditors.XtraForm
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
            Label1 = new Label();
            _txtNumber = new TextBox();
            _txtNumber.KeyPress += new KeyPressEventHandler(txtNumber_KeyPress);
            radNone = new RadioButton();
            radBottom = new RadioButton();
            radTop = new RadioButton();
            SuspendLayout();
            // 
            // Button1
            // 
            _Button1.Location = new Point(151, 62);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(75, 23);
            _Button1.TabIndex = 9;
            _Button1.Text = "&Go";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(24, 17);
            Label1.Name = "Label1";
            Label1.Size = new Size(197, 13);
            Label1.TabIndex = 8;
            Label1.Text = "Filter Top / Bottom Students By Number";
            // 
            // txtNumber
            // 
            _txtNumber.BackColor = SystemColors.Info;
            _txtNumber.ForeColor = Color.IndianRed;
            _txtNumber.Location = new Point(40, 65);
            _txtNumber.Name = "_txtNumber";
            _txtNumber.Size = new Size(101, 21);
            _txtNumber.TabIndex = 7;
            // 
            // radNone
            // 
            radNone.AutoSize = true;
            radNone.Location = new Point(40, 39);
            radNone.Name = "radNone";
            radNone.Size = new Size(50, 17);
            radNone.TabIndex = 4;
            radNone.TabStop = true;
            radNone.Text = "None";
            radNone.UseVisualStyleBackColor = true;
            // 
            // radBottom
            // 
            radBottom.AutoSize = true;
            radBottom.Location = new Point(165, 39);
            radBottom.Name = "radBottom";
            radBottom.Size = new Size(59, 17);
            radBottom.TabIndex = 5;
            radBottom.TabStop = true;
            radBottom.Text = "Bottom";
            radBottom.UseVisualStyleBackColor = true;
            // 
            // radTop
            // 
            radTop.AutoSize = true;
            radTop.Location = new Point(97, 39);
            radTop.Name = "radTop";
            radTop.Size = new Size(43, 17);
            radTop.TabIndex = 6;
            radTop.TabStop = true;
            radTop.Text = "Top";
            radTop.UseVisualStyleBackColor = true;
            // 
            // frmFilter
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 111);
            Controls.Add(_Button1);
            Controls.Add(Label1);
            Controls.Add(_txtNumber);
            Controls.Add(radNone);
            Controls.Add(radBottom);
            Controls.Add(radTop);
            Name = "frmFilter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Filter Report";
            KeyPress += new KeyPressEventHandler(frmFilter_KeyPress);
            Load += new EventHandler(frmFilter_Load);
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

        internal Label Label1;
        private TextBox _txtNumber;

        internal TextBox txtNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNumber != null)
                {
                    _txtNumber.KeyPress -= txtNumber_KeyPress;
                }

                _txtNumber = value;
                if (_txtNumber != null)
                {
                    _txtNumber.KeyPress += txtNumber_KeyPress;
                }
            }
        }

        internal RadioButton radNone;
        internal RadioButton radBottom;
        internal RadioButton radTop;
    }
}