using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace exams
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMeritListConfig : DevExpress.XtraEditors.XtraForm
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
            Label2 = new Label();
            _ComboBox1 = new ComboBox();
            _ComboBox1.SelectedIndexChanged += new EventHandler(ComboBox1_SelectedIndexChanged);
            chkKCPE = new CheckBox();
            chkIndex = new CheckBox();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            chkTM = new CheckBox();
            chkOP = new CheckBox();
            chkStr = new CheckBox();
            chkMM = new CheckBox();
            chkVAP = new CheckBox();
            chkTP = new CheckBox();
            chkSP = new CheckBox();
            chkMG = new CheckBox();
            chkMP = new CheckBox();
            chkSE = new CheckBox();
            Label1 = new Label();
            SuspendLayout();
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(41, 15);
            Label2.Name = "Label2";
            Label2.Size = new Size(36, 13);
            Label2.TabIndex = 22;
            Label2.Text = "Class:";
            // 
            // ComboBox1
            // 
            _ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            _ComboBox1.FormattingEnabled = true;
            _ComboBox1.Location = new Point(90, 12);
            _ComboBox1.Name = "_ComboBox1";
            _ComboBox1.Size = new Size(315, 21);
            _ComboBox1.TabIndex = 21;
            // 
            // chkKCPE
            // 
            chkKCPE.AutoSize = true;
            chkKCPE.Location = new Point(207, 146);
            chkKCPE.Name = "chkKCPE";
            chkKCPE.Size = new Size(82, 17);
            chkKCPE.TabIndex = 19;
            chkKCPE.Text = "KCPE Marks";
            chkKCPE.UseVisualStyleBackColor = true;
            // 
            // chkIndex
            // 
            chkIndex.AutoSize = true;
            chkIndex.Location = new Point(207, 172);
            chkIndex.Name = "chkIndex";
            chkIndex.Size = new Size(94, 17);
            chkIndex.TabIndex = 20;
            chkIndex.Text = "Index Number";
            chkIndex.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            _Button1.Location = new Point(330, 200);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(75, 31);
            _Button1.TabIndex = 18;
            _Button1.Text = "&Update";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // chkTM
            // 
            chkTM.AutoSize = true;
            chkTM.Location = new Point(38, 174);
            chkTM.Name = "chkTM";
            chkTM.Size = new Size(110, 17);
            chkTM.TabIndex = 8;
            chkTM.Text = "Total Marks (T.M)";
            chkTM.UseVisualStyleBackColor = true;
            // 
            // chkOP
            // 
            chkOP.AutoSize = true;
            chkOP.Location = new Point(207, 96);
            chkOP.Name = "chkOP";
            chkOP.Size = new Size(129, 17);
            chkOP.TabIndex = 9;
            chkOP.Text = "Overall Position (O.P)";
            chkOP.UseVisualStyleBackColor = true;
            // 
            // chkStr
            // 
            chkStr.AutoSize = true;
            chkStr.Location = new Point(207, 44);
            chkStr.Name = "chkStr";
            chkStr.Size = new Size(90, 17);
            chkStr.TabIndex = 10;
            chkStr.Text = "Stream (STR)";
            chkStr.UseVisualStyleBackColor = true;
            // 
            // chkMM
            // 
            chkMM.AutoSize = true;
            chkMM.Location = new Point(38, 122);
            chkMM.Name = "chkMM";
            chkMM.Size = new Size(114, 17);
            chkMM.TabIndex = 11;
            chkMM.Text = "Mean Marks (M.M)";
            chkMM.UseVisualStyleBackColor = true;
            // 
            // chkVAP
            // 
            chkVAP.AutoSize = true;
            chkVAP.Location = new Point(207, 122);
            chkVAP.Name = "chkVAP";
            chkVAP.Size = new Size(169, 17);
            chkVAP.TabIndex = 12;
            chkVAP.Text = "Value Added Progress (V.A.P)";
            chkVAP.UseVisualStyleBackColor = true;
            // 
            // chkTP
            // 
            chkTP.AutoSize = true;
            chkTP.Location = new Point(38, 70);
            chkTP.Name = "chkTP";
            chkTP.Size = new Size(109, 17);
            chkTP.TabIndex = 13;
            chkTP.Text = "Total Points (T.P)";
            chkTP.UseVisualStyleBackColor = true;
            // 
            // chkSP
            // 
            chkSP.AutoSize = true;
            chkSP.Location = new Point(207, 70);
            chkSP.Name = "chkSP";
            chkSP.Size = new Size(127, 17);
            chkSP.TabIndex = 14;
            chkSP.Text = "Stream Position (S.P)";
            chkSP.UseVisualStyleBackColor = true;
            // 
            // chkMG
            // 
            chkMG.AutoSize = true;
            chkMG.Location = new Point(38, 148);
            chkMG.Name = "chkMG";
            chkMG.Size = new Size(114, 17);
            chkMG.TabIndex = 15;
            chkMG.Text = "Mean Grade (M.G)";
            chkMG.UseVisualStyleBackColor = true;
            // 
            // chkMP
            // 
            chkMP.AutoSize = true;
            chkMP.Location = new Point(38, 96);
            chkMP.Name = "chkMP";
            chkMP.Size = new Size(113, 17);
            chkMP.TabIndex = 16;
            chkMP.Text = "Mean Points (M.P)";
            chkMP.UseVisualStyleBackColor = true;
            // 
            // chkSE
            // 
            chkSE.AutoSize = true;
            chkSE.Location = new Point(38, 44);
            chkSE.Name = "chkSE";
            chkSE.Size = new Size(125, 17);
            chkSE.TabIndex = 17;
            chkSE.Text = "Subject Entries (S.E)";
            chkSE.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(35, 20);
            Label1.Name = "Label1";
            Label1.Size = new Size(0, 13);
            Label1.TabIndex = 7;
            // 
            // frmMeritListConfig
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 261);
            Controls.Add(Label2);
            Controls.Add(_ComboBox1);
            Controls.Add(chkKCPE);
            Controls.Add(chkIndex);
            Controls.Add(_Button1);
            Controls.Add(chkTM);
            Controls.Add(chkOP);
            Controls.Add(chkStr);
            Controls.Add(chkMM);
            Controls.Add(chkVAP);
            Controls.Add(chkTP);
            Controls.Add(chkSP);
            Controls.Add(chkMG);
            Controls.Add(chkMP);
            Controls.Add(chkSE);
            Controls.Add(Label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMeritListConfig";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Merit List Configurations";
            Load += new EventHandler(frmMeritListConfig_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label Label2;
        private ComboBox _ComboBox1;

        internal ComboBox ComboBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBox1 != null)
                {
                    _ComboBox1.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged;
                }

                _ComboBox1 = value;
                if (_ComboBox1 != null)
                {
                    _ComboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
                }
            }
        }

        internal CheckBox chkKCPE;
        internal CheckBox chkIndex;
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

        internal CheckBox chkTM;
        internal CheckBox chkOP;
        internal CheckBox chkStr;
        internal CheckBox chkMM;
        internal CheckBox chkVAP;
        internal CheckBox chkTP;
        internal CheckBox chkSP;
        internal CheckBox chkMG;
        internal CheckBox chkMP;
        internal CheckBox chkSE;
        internal Label Label1;
    }
}