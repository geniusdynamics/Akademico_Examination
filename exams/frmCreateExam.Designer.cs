using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmCreateExam : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateExam));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _btnClear = new DevExpress.XtraEditors.SimpleButton();
            _btnClear.Click += new EventHandler(btnClear_Click);
            _btnSave = new DevExpress.XtraEditors.SimpleButton();
            _btnSave.Click += new EventHandler(btnSave_Click);
            DateTimePicker1 = new DateTimePicker();
            lstClass = new ListView();
            ColumnHeader1 = new ColumnHeader();
            txtTotal = new TextBox();
            txtExamName = new TextBox();
            _chkOtherName = new CheckBox();
            _chkOtherName.CheckedChanged += new EventHandler(chkOtherName_CheckedChanged);
            cboExamName = new ComboBox();
            cboYear = new ComboBox();
            cboTerm = new ComboBox();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnClear);
            LayoutControl1.Controls.Add(_btnSave);
            LayoutControl1.Controls.Add(DateTimePicker1);
            LayoutControl1.Controls.Add(lstClass);
            LayoutControl1.Controls.Add(txtTotal);
            LayoutControl1.Controls.Add(txtExamName);
            LayoutControl1.Controls.Add(_chkOtherName);
            LayoutControl1.Controls.Add(cboExamName);
            LayoutControl1.Controls.Add(cboYear);
            LayoutControl1.Controls.Add(cboTerm);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(605, 212, 250, 350);
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(673, 363);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // btnClear
            // 
            _btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            _btnClear.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnClear.Location = new Point(566, 298);
            _btnClear.Name = "_btnClear";
            _btnClear.Size = new Size(49, 39);
            _btnClear.StyleController = LayoutControl1;
            _btnClear.TabIndex = 15;
            _btnClear.Text = "Clear";
            // 
            // btnSave
            // 
            _btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            _btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnSave.Location = new Point(619, 298);
            _btnSave.Name = "_btnSave";
            _btnSave.Size = new Size(42, 39);
            _btnSave.StyleController = LayoutControl1;
            _btnSave.TabIndex = 14;
            _btnSave.Text = "Save";
            // 
            // DateTimePicker1
            // 
            DateTimePicker1.Location = new Point(105, 274);
            DateTimePicker1.Name = "DateTimePicker1";
            DateTimePicker1.Size = new Size(556, 21);
            DateTimePicker1.TabIndex = 11;
            // 
            // lstClass
            // 
            lstClass.CheckBoxes = true;
            lstClass.Columns.AddRange(new ColumnHeader[] { ColumnHeader1 });
            lstClass.GridLines = true;
            lstClass.Location = new Point(12, 155);
            lstClass.Name = "lstClass";
            lstClass.Size = new Size(649, 105);
            lstClass.TabIndex = 10;
            lstClass.UseCompatibleStateImageBehavior = false;
            lstClass.View = View.Details;
            // 
            // ColumnHeader1
            // 
            ColumnHeader1.Text = "Select Classes That Will Do The Exam Here";
            ColumnHeader1.Width = 639;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(105, 115);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(556, 20);
            txtTotal.TabIndex = 9;
            // 
            // txtExamName
            // 
            txtExamName.Location = new Point(431, 76);
            txtExamName.Name = "txtExamName";
            txtExamName.Size = new Size(230, 20);
            txtExamName.TabIndex = 8;
            // 
            // chkOtherName
            // 
            _chkOtherName.Location = new Point(12, 76);
            _chkOtherName.Name = "_chkOtherName";
            _chkOtherName.Size = new Size(322, 20);
            _chkOtherName.TabIndex = 7;
            _chkOtherName.Text = "Create Own Exam Name";
            _chkOtherName.UseVisualStyleBackColor = true;
            // 
            // cboExamName
            // 
            cboExamName.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExamName.FormattingEnabled = true;
            cboExamName.Items.AddRange(new object[] { "CAT I", "CAT II", "CAT III", "END TERM", "MID TERM", "OPENING EXAM" });
            cboExamName.Location = new Point(105, 51);
            cboExamName.Name = "cboExamName";
            cboExamName.Size = new Size(556, 21);
            cboExamName.TabIndex = 6;
            // 
            // cboYear
            // 
            cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cboYear.FormattingEnabled = true;
            cboYear.Location = new Point(105, 12);
            cboYear.Name = "cboYear";
            cboYear.Size = new Size(229, 21);
            cboYear.TabIndex = 5;
            // 
            // cboTerm
            // 
            cboTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTerm.FormattingEnabled = true;
            cboTerm.Items.AddRange(new object[] { "I", "II", "III" });
            cboTerm.Location = new Point(431, 12);
            cboTerm.Name = "cboTerm";
            cboTerm.Size = new Size(230, 21);
            cboTerm.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem3, LayoutControlItem4, LayoutControlItem6, LayoutControlItem7, LayoutControlItem8, LayoutControlItem2, LayoutControlItem5, EmptySpaceItem1, EmptySpaceItem2, EmptySpaceItem3, EmptySpaceItem4, EmptySpaceItem5, EmptySpaceItem6, LayoutControlItem9, LayoutControlItem10 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(673, 363);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = cboTerm;
            LayoutControlItem1.Location = new Point(326, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(327, 25);
            LayoutControlItem1.Text = "Term";
            LayoutControlItem1.TextSize = new Size(90, 13);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = cboExamName;
            LayoutControlItem3.Location = new Point(0, 39);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(653, 25);
            LayoutControlItem3.Text = "Select Exam Name";
            LayoutControlItem3.TextSize = new Size(90, 13);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _chkOtherName;
            LayoutControlItem4.Location = new Point(0, 64);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(326, 24);
            LayoutControlItem4.TextSize = new Size(0, 0);
            LayoutControlItem4.TextVisible = false;
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = txtTotal;
            LayoutControlItem6.Location = new Point(0, 103);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(653, 24);
            LayoutControlItem6.Text = "Total Marks";
            LayoutControlItem6.TextSize = new Size(90, 13);
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = lstClass;
            LayoutControlItem7.Location = new Point(0, 143);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(653, 109);
            LayoutControlItem7.TextSize = new Size(0, 0);
            LayoutControlItem7.TextVisible = false;
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = DateTimePicker1;
            LayoutControlItem8.Location = new Point(0, 262);
            LayoutControlItem8.Name = "LayoutControlItem8";
            LayoutControlItem8.Size = new Size(653, 24);
            LayoutControlItem8.Text = "Last Date Of Entry";
            LayoutControlItem8.TextSize = new Size(90, 13);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = cboYear;
            LayoutControlItem2.Location = new Point(0, 0);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(326, 25);
            LayoutControlItem2.Text = "Year";
            LayoutControlItem2.TextSize = new Size(90, 13);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = txtExamName;
            LayoutControlItem5.Location = new Point(326, 64);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(327, 24);
            LayoutControlItem5.Text = "Enter Exam Name";
            LayoutControlItem5.TextSize = new Size(90, 13);
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 25);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(653, 14);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 88);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(653, 15);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem3
            // 
            EmptySpaceItem3.AllowHotTrack = false;
            EmptySpaceItem3.Location = new Point(0, 127);
            EmptySpaceItem3.Name = "EmptySpaceItem3";
            EmptySpaceItem3.Size = new Size(653, 16);
            EmptySpaceItem3.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem4
            // 
            EmptySpaceItem4.AllowHotTrack = false;
            EmptySpaceItem4.Location = new Point(0, 286);
            EmptySpaceItem4.Name = "EmptySpaceItem4";
            EmptySpaceItem4.Size = new Size(554, 43);
            EmptySpaceItem4.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem5
            // 
            EmptySpaceItem5.AllowHotTrack = false;
            EmptySpaceItem5.Location = new Point(0, 252);
            EmptySpaceItem5.Name = "EmptySpaceItem5";
            EmptySpaceItem5.Size = new Size(653, 10);
            EmptySpaceItem5.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem6
            // 
            EmptySpaceItem6.AllowHotTrack = false;
            EmptySpaceItem6.Location = new Point(0, 329);
            EmptySpaceItem6.Name = "EmptySpaceItem6";
            EmptySpaceItem6.Size = new Size(653, 14);
            EmptySpaceItem6.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem9
            // 
            LayoutControlItem9.Control = _btnSave;
            LayoutControlItem9.Location = new Point(607, 286);
            LayoutControlItem9.Name = "LayoutControlItem9";
            LayoutControlItem9.Size = new Size(46, 43);
            LayoutControlItem9.TextSize = new Size(0, 0);
            LayoutControlItem9.TextVisible = false;
            // 
            // LayoutControlItem10
            // 
            LayoutControlItem10.Control = _btnClear;
            LayoutControlItem10.Location = new Point(554, 286);
            LayoutControlItem10.Name = "LayoutControlItem10";
            LayoutControlItem10.Size = new Size(53, 43);
            LayoutControlItem10.TextSize = new Size(0, 0);
            LayoutControlItem10.TextVisible = false;
            // 
            // frmCreateExam
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(673, 363);
            Controls.Add(LayoutControl1);
            Name = "frmCreateExam";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Exam";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).EndInit();
            Load += new EventHandler(frmCreateExam_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal DateTimePicker DateTimePicker1;
        internal ListView lstClass;
        internal TextBox txtTotal;
        internal TextBox txtExamName;
        private CheckBox _chkOtherName;

        internal CheckBox chkOtherName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkOtherName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkOtherName != null)
                {
                    _chkOtherName.CheckedChanged -= chkOtherName_CheckedChanged;
                }

                _chkOtherName = value;
                if (_chkOtherName != null)
                {
                    _chkOtherName.CheckedChanged += chkOtherName_CheckedChanged;
                }
            }
        }

        internal ComboBox cboExamName;
        internal ComboBox cboYear;
        internal ComboBox cboTerm;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem3;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem4;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem5;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem6;
        private DevExpress.XtraEditors.SimpleButton _btnSave;

        internal DevExpress.XtraEditors.SimpleButton btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem9;
        private DevExpress.XtraEditors.SimpleButton _btnClear;

        internal DevExpress.XtraEditors.SimpleButton btnClear
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClear;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClear != null)
                {
                    _btnClear.Click -= btnClear_Click;
                }

                _btnClear = value;
                if (_btnClear != null)
                {
                    _btnClear.Click += btnClear_Click;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem10;
        internal ColumnHeader ColumnHeader1;
    }
}