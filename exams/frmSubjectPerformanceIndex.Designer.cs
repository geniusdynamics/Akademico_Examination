using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmSubjectPerformanceIndex : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectPerformanceIndex));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _Button1 = new DevExpress.XtraEditors.SimpleButton();
            _Button1.Click += new EventHandler(Button1_Click);
            radSubject = new CheckBox();
            cboClass = new ComboBox();
            cboExamName1 = new ComboBox();
            _cboTerm1 = new ComboBox();
            _cboTerm1.SelectedIndexChanged += new EventHandler(cboTerm1_SelectedIndexChanged);
            _cboYear1 = new ComboBox();
            _cboYear1.SelectedIndexChanged += new EventHandler(cboYear1_SelectedIndexChanged);
            cboExamName = new ComboBox();
            _cboTerm = new ComboBox();
            _cboTerm.SelectedIndexChanged += new EventHandler(cboTerm_SelectedIndexChanged);
            _cboYear = new ComboBox();
            _cboYear.SelectedIndexChanged += new EventHandler(cboYear_SelectedIndexChanged);
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_Button1);
            LayoutControl1.Controls.Add(radSubject);
            LayoutControl1.Controls.Add(cboClass);
            LayoutControl1.Controls.Add(cboExamName1);
            LayoutControl1.Controls.Add(_cboTerm1);
            LayoutControl1.Controls.Add(_cboYear1);
            LayoutControl1.Controls.Add(cboExamName);
            LayoutControl1.Controls.Add(_cboTerm);
            LayoutControl1.Controls.Add(_cboYear);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(488, 251, 394, 350);
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(433, 352);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // Button1
            // 
            _Button1.Image = (Image)resources.GetObject("Button1.Image");
            _Button1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button1.Location = new Point(345, 295);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(76, 39);
            _Button1.StyleController = LayoutControl1;
            _Button1.TabIndex = 14;
            _Button1.Text = "Show Report";
            // 
            // radSubject
            // 
            radSubject.Location = new Point(12, 271);
            radSubject.Name = "radSubject";
            radSubject.Size = new Size(409, 20);
            radSubject.TabIndex = 11;
            radSubject.Text = "Use Subject Based Grading";
            radSubject.UseVisualStyleBackColor = true;
            // 
            // cboClass
            // 
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.FormattingEnabled = true;
            cboClass.Location = new Point(72, 246);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(349, 21);
            cboClass.TabIndex = 10;
            // 
            // cboExamName1
            // 
            cboExamName1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExamName1.FormattingEnabled = true;
            cboExamName1.Location = new Point(84, 209);
            cboExamName1.Name = "cboExamName1";
            cboExamName1.Size = new Size(325, 21);
            cboExamName1.TabIndex = 9;
            // 
            // cboTerm1
            // 
            _cboTerm1.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerm1.FormattingEnabled = true;
            _cboTerm1.Items.AddRange(new object[] { "I", "II", "III" });
            _cboTerm1.Location = new Point(84, 184);
            _cboTerm1.Name = "_cboTerm1";
            _cboTerm1.Size = new Size(325, 21);
            _cboTerm1.TabIndex = 8;
            // 
            // cboYear1
            // 
            _cboYear1.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear1.FormattingEnabled = true;
            _cboYear1.Location = new Point(84, 159);
            _cboYear1.Name = "_cboYear1";
            _cboYear1.Size = new Size(325, 21);
            _cboYear1.TabIndex = 7;
            // 
            // cboExamName
            // 
            cboExamName.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExamName.FormattingEnabled = true;
            cboExamName.Location = new Point(84, 92);
            cboExamName.Name = "cboExamName";
            cboExamName.Size = new Size(325, 21);
            cboExamName.TabIndex = 6;
            // 
            // cboTerm
            // 
            _cboTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerm.FormattingEnabled = true;
            _cboTerm.Items.AddRange(new object[] { "I", "II", "III" });
            _cboTerm.Location = new Point(84, 67);
            _cboTerm.Name = "_cboTerm";
            _cboTerm.Size = new Size(325, 21);
            _cboTerm.TabIndex = 5;
            // 
            // cboYear
            // 
            _cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear.FormattingEnabled = true;
            _cboYear.Location = new Point(84, 42);
            _cboYear.Name = "_cboYear";
            _cboYear.Size = new Size(325, 21);
            _cboYear.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.CustomizationFormText = "Root";
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlGroup2, LayoutControlGroup3, LayoutControlItem7, LayoutControlItem8, EmptySpaceItem1, LayoutControlItem9 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(433, 352);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlGroup2
            // 
            LayoutControlGroup2.CustomizationFormText = "1st Exam";
            LayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, LayoutControlItem3 });
            LayoutControlGroup2.Location = new Point(0, 0);
            LayoutControlGroup2.Name = "LayoutControlGroup2";
            LayoutControlGroup2.Size = new Size(413, 117);
            LayoutControlGroup2.Text = "1st Exam";
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _cboYear;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(389, 25);
            LayoutControlItem1.Text = "Year";
            LayoutControlItem1.TextSize = new Size(57, 13);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _cboTerm;
            LayoutControlItem2.Location = new Point(0, 25);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(389, 25);
            LayoutControlItem2.Text = "Term";
            LayoutControlItem2.TextSize = new Size(57, 13);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = cboExamName;
            LayoutControlItem3.Location = new Point(0, 50);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(389, 25);
            LayoutControlItem3.Text = "Exam Name";
            LayoutControlItem3.TextSize = new Size(57, 13);
            // 
            // LayoutControlGroup3
            // 
            LayoutControlGroup3.CustomizationFormText = "2nd Exam";
            LayoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem4, LayoutControlItem5, LayoutControlItem6 });
            LayoutControlGroup3.Location = new Point(0, 117);
            LayoutControlGroup3.Name = "LayoutControlGroup3";
            LayoutControlGroup3.Size = new Size(413, 117);
            LayoutControlGroup3.Text = "2nd Exam";
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _cboYear1;
            LayoutControlItem4.Location = new Point(0, 0);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(389, 25);
            LayoutControlItem4.Text = "Year";
            LayoutControlItem4.TextSize = new Size(57, 13);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = _cboTerm1;
            LayoutControlItem5.Location = new Point(0, 25);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(389, 25);
            LayoutControlItem5.Text = "Term";
            LayoutControlItem5.TextSize = new Size(57, 13);
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = cboExamName1;
            LayoutControlItem6.Location = new Point(0, 50);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(389, 25);
            LayoutControlItem6.Text = "Exam Name";
            LayoutControlItem6.TextSize = new Size(57, 13);
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = cboClass;
            LayoutControlItem7.Location = new Point(0, 234);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(413, 25);
            LayoutControlItem7.Text = "Select Class";
            LayoutControlItem7.TextSize = new Size(57, 13);
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = radSubject;
            LayoutControlItem8.Location = new Point(0, 259);
            LayoutControlItem8.Name = "LayoutControlItem8";
            LayoutControlItem8.Size = new Size(413, 24);
            LayoutControlItem8.TextSize = new Size(0, 0);
            LayoutControlItem8.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1";
            EmptySpaceItem1.Location = new Point(0, 283);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(333, 49);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem9
            // 
            LayoutControlItem9.Control = _Button1;
            LayoutControlItem9.Location = new Point(333, 283);
            LayoutControlItem9.Name = "LayoutControlItem9";
            LayoutControlItem9.Size = new Size(80, 49);
            LayoutControlItem9.TextSize = new Size(0, 0);
            LayoutControlItem9.TextVisible = false;
            // 
            // frmSubjectPerformanceIndex
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 352);
            Controls.Add(LayoutControl1);
            Name = "frmSubjectPerformanceIndex";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subject Performance Index";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).EndInit();
            Load += new EventHandler(frmMostImproved_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal CheckBox radSubject;
        internal ComboBox cboClass;
        internal ComboBox cboExamName1;
        private ComboBox _cboTerm1;

        internal ComboBox cboTerm1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTerm1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTerm1 != null)
                {
                    _cboTerm1.SelectedIndexChanged -= cboTerm1_SelectedIndexChanged;
                }

                _cboTerm1 = value;
                if (_cboTerm1 != null)
                {
                    _cboTerm1.SelectedIndexChanged += cboTerm1_SelectedIndexChanged;
                }
            }
        }

        private ComboBox _cboYear1;

        internal ComboBox cboYear1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboYear1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboYear1 != null)
                {
                    _cboYear1.SelectedIndexChanged -= cboYear1_SelectedIndexChanged;
                }

                _cboYear1 = value;
                if (_cboYear1 != null)
                {
                    _cboYear1.SelectedIndexChanged += cboYear1_SelectedIndexChanged;
                }
            }
        }

        internal ComboBox cboExamName;
        private ComboBox _cboTerm;

        internal ComboBox cboTerm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTerm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTerm != null)
                {
                    _cboTerm.SelectedIndexChanged -= cboTerm_SelectedIndexChanged;
                }

                _cboTerm = value;
                if (_cboTerm != null)
                {
                    _cboTerm.SelectedIndexChanged += cboTerm_SelectedIndexChanged;
                }
            }
        }

        private ComboBox _cboYear;

        internal ComboBox cboYear
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboYear;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboYear != null)
                {
                    _cboYear.SelectedIndexChanged -= cboYear_SelectedIndexChanged;
                }

                _cboYear = value;
                if (_cboYear != null)
                {
                    _cboYear.SelectedIndexChanged += cboYear_SelectedIndexChanged;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
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

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem9;
    }
}