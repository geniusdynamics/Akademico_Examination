using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmAddSplitSubject : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSplitSubject));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _Button1 = new DevExpress.XtraEditors.SimpleButton();
            _Button1.Click += new EventHandler(Button1_Click);
            txtWeighted = new TextBox();
            txtContribution = new TextBox();
            txtAbbreviation = new TextBox();
            txtName = new TextBox();
            cboSubject = new ComboBox();
            _cboClass = new ComboBox();
            _cboClass.SelectedIndexChanged += new EventHandler(cboClass_SelectedIndexChanged);
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_Button1);
            LayoutControl1.Controls.Add(txtWeighted);
            LayoutControl1.Controls.Add(txtContribution);
            LayoutControl1.Controls.Add(txtAbbreviation);
            LayoutControl1.Controls.Add(txtName);
            LayoutControl1.Controls.Add(cboSubject);
            LayoutControl1.Controls.Add(_cboClass);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(548, 261);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // Button1
            // 
            _Button1.Image = (Image)resources.GetObject("Button1.Image");
            _Button1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button1.Location = new Point(457, 158);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(79, 39);
            _Button1.StyleController = LayoutControl1;
            _Button1.TabIndex = 10;
            _Button1.Text = "Save";
            // 
            // txtWeighted
            // 
            txtWeighted.Location = new Point(138, 134);
            txtWeighted.Name = "txtWeighted";
            txtWeighted.Size = new Size(398, 20);
            txtWeighted.TabIndex = 9;
            // 
            // txtContribution
            // 
            txtContribution.Location = new Point(138, 110);
            txtContribution.Name = "txtContribution";
            txtContribution.Size = new Size(398, 20);
            txtContribution.TabIndex = 8;
            // 
            // txtAbbreviation
            // 
            txtAbbreviation.Location = new Point(138, 86);
            txtAbbreviation.Name = "txtAbbreviation";
            txtAbbreviation.Size = new Size(398, 20);
            txtAbbreviation.TabIndex = 7;
            // 
            // txtName
            // 
            txtName.Location = new Point(138, 62);
            txtName.Name = "txtName";
            txtName.Size = new Size(398, 20);
            txtName.TabIndex = 6;
            // 
            // cboSubject
            // 
            cboSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSubject.FormattingEnabled = true;
            cboSubject.Location = new Point(138, 37);
            cboSubject.Name = "cboSubject";
            cboSubject.Size = new Size(398, 21);
            cboSubject.TabIndex = 5;
            // 
            // cboClass
            // 
            _cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboClass.FormattingEnabled = true;
            _cboClass.Location = new Point(138, 12);
            _cboClass.Name = "_cboClass";
            _cboClass.Size = new Size(398, 21);
            _cboClass.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, LayoutControlItem3, LayoutControlItem4, LayoutControlItem5, LayoutControlItem6, EmptySpaceItem1, EmptySpaceItem2, LayoutControlItem7 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(548, 261);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _cboClass;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(528, 25);
            LayoutControlItem1.Text = "Class";
            LayoutControlItem1.TextSize = new Size(123, 13);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = cboSubject;
            LayoutControlItem2.Location = new Point(0, 25);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(528, 25);
            LayoutControlItem2.Text = "Subject";
            LayoutControlItem2.TextSize = new Size(123, 13);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = txtName;
            LayoutControlItem3.Location = new Point(0, 50);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(528, 24);
            LayoutControlItem3.Text = "Split Subjet Name";
            LayoutControlItem3.TextSize = new Size(123, 13);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = txtAbbreviation;
            LayoutControlItem4.Location = new Point(0, 74);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(528, 24);
            LayoutControlItem4.Text = "Split Subject Abbreviation";
            LayoutControlItem4.TextSize = new Size(123, 13);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = txtContribution;
            LayoutControlItem5.Location = new Point(0, 98);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(528, 24);
            LayoutControlItem5.Text = "Contribution";
            LayoutControlItem5.TextSize = new Size(123, 13);
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = txtWeighted;
            LayoutControlItem6.Location = new Point(0, 122);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(528, 24);
            LayoutControlItem6.Text = "Weighted Contribution";
            LayoutControlItem6.TextSize = new Size(123, 13);
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 146);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(445, 43);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 189);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(528, 52);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = _Button1;
            LayoutControlItem7.Location = new Point(445, 146);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(83, 43);
            LayoutControlItem7.TextSize = new Size(0, 0);
            LayoutControlItem7.TextVisible = false;
            // 
            // frmAddSplitSubject
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 261);
            Controls.Add(LayoutControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddSplitSubject";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Split Subject";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            Load += new EventHandler(frmAddSplitSubject_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        private DevExpress.XtraEditors.SimpleButton _Button1;

        internal DevExpress.XtraEditors.SimpleButton Button1
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

        internal TextBox txtWeighted;
        internal TextBox txtContribution;
        internal TextBox txtAbbreviation;
        internal TextBox txtName;
        internal ComboBox cboSubject;
        private ComboBox _cboClass;

        internal ComboBox cboClass
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboClass;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboClass != null)
                {
                    _cboClass.SelectedIndexChanged -= cboClass_SelectedIndexChanged;
                }

                _cboClass = value;
                if (_cboClass != null)
                {
                    _cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
    }
}