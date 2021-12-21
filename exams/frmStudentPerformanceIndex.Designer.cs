using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmStudentPerformanceIndex : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentPerformanceIndex));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            cboSortBy = new ComboBox();
            _Button1 = new DevExpress.XtraEditors.SimpleButton();
            _Button1.Click += new EventHandler(Button1_Click);
            chkBestOf7 = new CheckBox();
            radSubject = new CheckBox();
            cboClass = new ComboBox();
            _cboYear1 = new ComboBox();
            _cboYear1.SelectedIndexChanged += new EventHandler(cboYear1_SelectedIndexChanged);
            _cboTerm1 = new ComboBox();
            _cboTerm1.SelectedIndexChanged += new EventHandler(cboTerm1_SelectedIndexChanged);
            cboExamName1 = new ComboBox();
            _cboTerm = new ComboBox();
            _cboTerm.SelectedIndexChanged += new EventHandler(cboTerm_SelectedIndexChanged);
            _cboYear = new ComboBox();
            _cboYear.SelectedIndexChanged += new EventHandler(cboYear_SelectedIndexChanged);
            cboExamName = new ComboBox();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(cboSortBy);
            LayoutControl1.Controls.Add(_Button1);
            LayoutControl1.Controls.Add(chkBestOf7);
            LayoutControl1.Controls.Add(radSubject);
            LayoutControl1.Controls.Add(cboClass);
            LayoutControl1.Controls.Add(_cboYear1);
            LayoutControl1.Controls.Add(_cboTerm1);
            LayoutControl1.Controls.Add(cboExamName1);
            LayoutControl1.Controls.Add(_cboTerm);
            LayoutControl1.Controls.Add(_cboYear);
            LayoutControl1.Controls.Add(cboExamName);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(516, 254, 250, 350);
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(461, 368);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // cboSortBy
            // 
            cboSortBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSortBy.FormattingEnabled = true;
            cboSortBy.Items.AddRange(new object[] { "Total Marks", "Total Points" });
            cboSortBy.Location = new Point(71, 295);
            cboSortBy.Name = "cboSortBy";
            cboSortBy.Size = new Size(361, 21);
            cboSortBy.TabIndex = 14;
            // 
            // Button1
            // 
            _Button1.Image = (Image)resources.GetObject("Button1.Image");
            _Button1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button1.Location = new Point(299, 330);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(133, 39);
            _Button1.StyleController = LayoutControl1;
            _Button1.TabIndex = 13;
            _Button1.Text = "Show Report";
            // 
            // chkBestOf7
            // 
            chkBestOf7.Location = new Point(12, 271);
            chkBestOf7.Name = "chkBestOf7";
            chkBestOf7.Size = new Size(208, 20);
            chkBestOf7.TabIndex = 12;
            chkBestOf7.Text = "Use Best Of 7 Mode";
            chkBestOf7.UseVisualStyleBackColor = true;
            // 
            // radSubject
            // 
            radSubject.Location = new Point(224, 271);
            radSubject.Name = "radSubject";
            radSubject.Size = new Size(208, 20);
            radSubject.TabIndex = 11;
            radSubject.Text = "Use Subject Based Grading";
            radSubject.UseVisualStyleBackColor = true;
            // 
            // cboClass
            // 
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.FormattingEnabled = true;
            cboClass.Location = new Point(71, 246);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(361, 21);
            cboClass.TabIndex = 10;
            // 
            // cboYear1
            // 
            _cboYear1.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear1.FormattingEnabled = true;
            _cboYear1.Location = new Point(83, 159);
            _cboYear1.Name = "_cboYear1";
            _cboYear1.Size = new Size(337, 21);
            _cboYear1.TabIndex = 9;
            // 
            // cboTerm1
            // 
            _cboTerm1.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerm1.FormattingEnabled = true;
            _cboTerm1.Items.AddRange(new object[] { "I", "II", "III" });
            _cboTerm1.Location = new Point(83, 184);
            _cboTerm1.Name = "_cboTerm1";
            _cboTerm1.Size = new Size(337, 21);
            _cboTerm1.TabIndex = 8;
            // 
            // cboExamName1
            // 
            cboExamName1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExamName1.FormattingEnabled = true;
            cboExamName1.Location = new Point(83, 209);
            cboExamName1.Name = "cboExamName1";
            cboExamName1.Size = new Size(337, 21);
            cboExamName1.TabIndex = 7;
            // 
            // cboTerm
            // 
            _cboTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerm.FormattingEnabled = true;
            _cboTerm.Items.AddRange(new object[] { "I", "II", "III" });
            _cboTerm.Location = new Point(83, 67);
            _cboTerm.Name = "_cboTerm";
            _cboTerm.Size = new Size(337, 21);
            _cboTerm.TabIndex = 6;
            // 
            // cboYear
            // 
            _cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear.FormattingEnabled = true;
            _cboYear.Location = new Point(83, 42);
            _cboYear.Name = "_cboYear";
            _cboYear.Size = new Size(337, 21);
            _cboYear.TabIndex = 5;
            // 
            // cboExamName
            // 
            cboExamName.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExamName.FormattingEnabled = true;
            cboExamName.Location = new Point(83, 92);
            cboExamName.Name = "cboExamName";
            cboExamName.Size = new Size(337, 21);
            cboExamName.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlGroup2, LayoutControlGroup3, LayoutControlItem7, LayoutControlItem8, LayoutControlItem9, EmptySpaceItem1, LayoutControlItem10, EmptySpaceItem2, LayoutControlItem11, EmptySpaceItem3 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(444, 391);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlGroup2
            // 
            LayoutControlGroup2.CustomizationFormText = "1st Exam";
            LayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem2, LayoutControlItem1, LayoutControlItem3 });
            LayoutControlGroup2.Location = new Point(0, 0);
            LayoutControlGroup2.Name = "LayoutControlGroup2";
            LayoutControlGroup2.Size = new Size(424, 117);
            LayoutControlGroup2.Text = "1st Exam";
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _cboYear;
            LayoutControlItem2.Location = new Point(0, 0);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(400, 25);
            LayoutControlItem2.Text = "Year ";
            LayoutControlItem2.TextSize = new Size(56, 13);
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = cboExamName;
            LayoutControlItem1.Location = new Point(0, 50);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(400, 25);
            LayoutControlItem1.Text = "Exam Name";
            LayoutControlItem1.TextSize = new Size(56, 13);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _cboTerm;
            LayoutControlItem3.Location = new Point(0, 25);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(400, 25);
            LayoutControlItem3.Text = "Term";
            LayoutControlItem3.TextSize = new Size(56, 13);
            // 
            // LayoutControlGroup3
            // 
            LayoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem6, LayoutControlItem5, LayoutControlItem4 });
            LayoutControlGroup3.Location = new Point(0, 117);
            LayoutControlGroup3.Name = "LayoutControlGroup3";
            LayoutControlGroup3.Size = new Size(424, 117);
            LayoutControlGroup3.Text = "2nd Exam";
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = _cboYear1;
            LayoutControlItem6.Location = new Point(0, 0);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(400, 25);
            LayoutControlItem6.Text = "Year";
            LayoutControlItem6.TextSize = new Size(56, 13);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = _cboTerm1;
            LayoutControlItem5.Location = new Point(0, 25);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(400, 25);
            LayoutControlItem5.Text = "Term";
            LayoutControlItem5.TextSize = new Size(56, 13);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = cboExamName1;
            LayoutControlItem4.Location = new Point(0, 50);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(400, 25);
            LayoutControlItem4.Text = "Exam Name";
            LayoutControlItem4.TextSize = new Size(56, 13);
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = cboClass;
            LayoutControlItem7.Location = new Point(0, 234);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(424, 25);
            LayoutControlItem7.Text = "Class";
            LayoutControlItem7.TextSize = new Size(56, 13);
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = radSubject;
            LayoutControlItem8.Location = new Point(212, 259);
            LayoutControlItem8.Name = "LayoutControlItem8";
            LayoutControlItem8.Size = new Size(212, 24);
            LayoutControlItem8.TextSize = new Size(0, 0);
            LayoutControlItem8.TextVisible = false;
            // 
            // LayoutControlItem9
            // 
            LayoutControlItem9.Control = chkBestOf7;
            LayoutControlItem9.Location = new Point(0, 259);
            LayoutControlItem9.Name = "LayoutControlItem9";
            LayoutControlItem9.Size = new Size(212, 24);
            LayoutControlItem9.TextSize = new Size(0, 0);
            LayoutControlItem9.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 318);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(287, 43);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem10
            // 
            LayoutControlItem10.Control = _Button1;
            LayoutControlItem10.Location = new Point(287, 318);
            LayoutControlItem10.Name = "LayoutControlItem10";
            LayoutControlItem10.Size = new Size(137, 43);
            LayoutControlItem10.TextSize = new Size(0, 0);
            LayoutControlItem10.TextVisible = false;
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 361);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(424, 10);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem11
            // 
            LayoutControlItem11.Control = cboSortBy;
            LayoutControlItem11.Location = new Point(0, 283);
            LayoutControlItem11.Name = "LayoutControlItem11";
            LayoutControlItem11.Size = new Size(424, 25);
            LayoutControlItem11.Text = "Rank By";
            LayoutControlItem11.TextSize = new Size(56, 13);
            // 
            // EmptySpaceItem3
            // 
            EmptySpaceItem3.AllowHotTrack = false;
            EmptySpaceItem3.Location = new Point(0, 308);
            EmptySpaceItem3.Name = "EmptySpaceItem3";
            EmptySpaceItem3.Size = new Size(424, 10);
            EmptySpaceItem3.TextSize = new Size(0, 0);
            // 
            // frmStudentPerformanceIndex
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 368);
            Controls.Add(LayoutControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmStudentPerformanceIndex";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Most Improved Student";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).EndInit();
            Load += new EventHandler(frmMostImproved_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal ComboBox cboSortBy;
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

        internal CheckBox chkBestOf7;
        internal CheckBox radSubject;
        internal ComboBox cboClass;
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

        internal ComboBox cboExamName1;
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

        internal ComboBox cboExamName;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem9;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem10;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem11;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem3;
    }
}