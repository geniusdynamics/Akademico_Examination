using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace exams
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmReportConfiguration : DevExpress.XtraEditors.XtraForm
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
            chkCTN = new CheckBox();
            chkHouse = new CheckBox();
            chkHTN = new CheckBox();
            chkClubSociety = new CheckBox();
            chkHTS = new CheckBox();
            chkHTC = new CheckBox();
            chkCTS = new CheckBox();
            chkCTC = new CheckBox();
            chkLogo = new CheckBox();
            chkPhoto = new CheckBox();
            SuspendLayout();
            // 
            // Button1
            // 
            _Button1.Location = new Point(148, 266);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(75, 23);
            _Button1.TabIndex = 16;
            _Button1.Text = "&Update";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // chkCTN
            // 
            chkCTN.AutoSize = true;
            chkCTN.Location = new Point(34, 243);
            chkCTN.Name = "chkCTN";
            chkCTN.Size = new Size(130, 17);
            chkCTN.TabIndex = 14;
            chkCTN.Text = "Class Teacher's Name";
            chkCTN.UseVisualStyleBackColor = true;
            // 
            // chkHouse
            // 
            chkHouse.AutoSize = true;
            chkHouse.Location = new Point(35, 193);
            chkHouse.Name = "chkHouse";
            chkHouse.Size = new Size(152, 17);
            chkHouse.TabIndex = 15;
            chkHouse.Text = "House Masters' Comments";
            chkHouse.UseVisualStyleBackColor = true;
            // 
            // chkHTN
            // 
            chkHTN.AutoSize = true;
            chkHTN.Location = new Point(34, 218);
            chkHTN.Name = "chkHTN";
            chkHTN.Size = new Size(130, 17);
            chkHTN.TabIndex = 12;
            chkHTN.Text = "Head Teacher's Name";
            chkHTN.UseVisualStyleBackColor = true;
            // 
            // chkClubSociety
            // 
            chkClubSociety.AutoSize = true;
            chkClubSociety.Location = new Point(35, 168);
            chkClubSociety.Name = "chkClubSociety";
            chkClubSociety.Size = new Size(172, 17);
            chkClubSociety.TabIndex = 13;
            chkClubSociety.Text = "Clubs And Societies Comments";
            chkClubSociety.UseVisualStyleBackColor = true;
            // 
            // chkHTS
            // 
            chkHTS.AutoSize = true;
            chkHTS.Location = new Point(34, 93);
            chkHTS.Name = "chkHTS";
            chkHTS.Size = new Size(149, 17);
            chkHTS.TabIndex = 10;
            chkHTS.Text = "Head Teachers' Signature";
            chkHTS.UseVisualStyleBackColor = true;
            // 
            // chkHTC
            // 
            chkHTC.AutoSize = true;
            chkHTC.Location = new Point(34, 143);
            chkHTC.Name = "chkHTC";
            chkHTC.Size = new Size(153, 17);
            chkHTC.TabIndex = 11;
            chkHTC.Text = "Head Teachers' Comments";
            chkHTC.UseVisualStyleBackColor = true;
            // 
            // chkCTS
            // 
            chkCTS.AutoSize = true;
            chkCTS.Location = new Point(34, 68);
            chkCTS.Name = "chkCTS";
            chkCTS.Size = new Size(149, 17);
            chkCTS.TabIndex = 7;
            chkCTS.Text = "Class Teachers' Signature";
            chkCTS.UseVisualStyleBackColor = true;
            // 
            // chkCTC
            // 
            chkCTC.AutoSize = true;
            chkCTC.Location = new Point(34, 118);
            chkCTC.Name = "chkCTC";
            chkCTC.Size = new Size(153, 17);
            chkCTC.TabIndex = 8;
            chkCTC.Text = "Class Teachers' Comments";
            chkCTC.UseVisualStyleBackColor = true;
            // 
            // chkLogo
            // 
            chkLogo.AutoSize = true;
            chkLogo.Location = new Point(34, 43);
            chkLogo.Name = "chkLogo";
            chkLogo.Size = new Size(83, 17);
            chkLogo.TabIndex = 9;
            chkLogo.Text = "School Logo";
            chkLogo.UseVisualStyleBackColor = true;
            // 
            // chkPhoto
            // 
            chkPhoto.AutoSize = true;
            chkPhoto.Location = new Point(34, 18);
            chkPhoto.Name = "chkPhoto";
            chkPhoto.Size = new Size(95, 17);
            chkPhoto.TabIndex = 6;
            chkPhoto.Text = "Student Photo";
            chkPhoto.UseVisualStyleBackColor = true;
            // 
            // frmReportConfiguration
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(252, 323);
            Controls.Add(_Button1);
            Controls.Add(chkCTN);
            Controls.Add(chkHouse);
            Controls.Add(chkHTN);
            Controls.Add(chkClubSociety);
            Controls.Add(chkHTS);
            Controls.Add(chkHTC);
            Controls.Add(chkCTS);
            Controls.Add(chkCTC);
            Controls.Add(chkLogo);
            Controls.Add(chkPhoto);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmReportConfiguration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Report Form Configuration";
            Load += new EventHandler(frmReportConfiguration_Load);
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

        internal CheckBox chkCTN;
        internal CheckBox chkHouse;
        internal CheckBox chkHTN;
        internal CheckBox chkClubSociety;
        internal CheckBox chkHTS;
        internal CheckBox chkHTC;
        internal CheckBox chkCTS;
        internal CheckBox chkCTC;
        internal CheckBox chkLogo;
        internal CheckBox chkPhoto;
    }
}