using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmSubjectPerformanceGeneral : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectPerformanceGeneral));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            Label1 = new Label();
            _btnCancel = new DevExpress.XtraEditors.SimpleButton();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnClear = new DevExpress.XtraEditors.SimpleButton();
            _btnClear.Click += new EventHandler(btnClear_Click);
            _btnMeanMarkAnalysis = new DevExpress.XtraEditors.SimpleButton();
            _btnMeanMarkAnalysis.Click += new EventHandler(btnMeanMarkAnalysis_Click);
            _Button2 = new DevExpress.XtraEditors.SimpleButton();
            _Button2.Click += new EventHandler(Button2_Click);
            _Button3 = new DevExpress.XtraEditors.SimpleButton();
            _Button3.Click += new EventHandler(Button3_Click);
            _Button1 = new DevExpress.XtraEditors.SimpleButton();
            _Button1.Click += new EventHandler(Button1_Click);
            chkBestOf7 = new CheckBox();
            radSubject = new CheckBox();
            _btnAnalyze = new DevExpress.XtraEditors.SimpleButton();
            _btnAnalyze.Click += new EventHandler(btnAnalyze_Click);
            lstExaminations = new ListView();
            ColumnHeader1 = new ColumnHeader();
            ColumnHeader2 = new ColumnHeader();
            ColumnHeader3 = new ColumnHeader();
            ColumnHeader4 = new ColumnHeader();
            _btnAddExam = new DevExpress.XtraEditors.SimpleButton();
            _btnAddExam.Click += new EventHandler(btnAddExam_Click);
            _txtContribution = new TextBox();
            _txtContribution.KeyPress += new KeyPressEventHandler(txtContribution_KeyPress);
            _cboExamName = new ComboBox();
            _cboExamName.SelectedIndexChanged += new EventHandler(cboExamName_SelectedIndexChanged);
            _cboTerm = new ComboBox();
            _cboTerm.SelectedIndexChanged += new EventHandler(cboTerm_SelectedIndexChanged);
            cboYear = new ComboBox();
            _chkMode = new CheckBox();
            _chkMode.CheckedChanged += new EventHandler(chkMode_CheckedChanged);
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            grpSelect = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            grpMultiExaminations = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            grpAnalyze = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            printpreview = new PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpSelect).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpMultiExaminations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpAnalyze).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem16).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(Label1);
            LayoutControl1.Controls.Add(_btnCancel);
            LayoutControl1.Controls.Add(_btnClear);
            LayoutControl1.Controls.Add(_btnMeanMarkAnalysis);
            LayoutControl1.Controls.Add(_Button2);
            LayoutControl1.Controls.Add(_Button3);
            LayoutControl1.Controls.Add(_Button1);
            LayoutControl1.Controls.Add(chkBestOf7);
            LayoutControl1.Controls.Add(radSubject);
            LayoutControl1.Controls.Add(_btnAnalyze);
            LayoutControl1.Controls.Add(lstExaminations);
            LayoutControl1.Controls.Add(_btnAddExam);
            LayoutControl1.Controls.Add(_txtContribution);
            LayoutControl1.Controls.Add(_cboExamName);
            LayoutControl1.Controls.Add(_cboTerm);
            LayoutControl1.Controls.Add(cboYear);
            LayoutControl1.Controls.Add(_chkMode);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Margin = new Padding(3, 4, 3, 4);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(474, 286, 250, 350);
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(780, 660);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // Label1
            // 
            Label1.Location = new Point(391, 181);
            Label1.Name = "Label1";
            Label1.Size = new Size(171, 27);
            Label1.TabIndex = 20;
            Label1.Text = "Out Of 100 %";
            // 
            // btnCancel
            // 
            _btnCancel.ImageOptions.Image = (Image)resources.GetObject("btnCancel.ImageOptions.Image");
            _btnCancel.Location = new Point(577, 617);
            _btnCancel.Margin = new Padding(3, 4, 3, 4);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(90, 27);
            _btnCancel.StyleController = LayoutControl1;
            _btnCancel.TabIndex = 19;
            _btnCancel.Text = "Cancel";
            // 
            // btnClear
            // 
            _btnClear.ImageOptions.Image = (Image)resources.GetObject("btnClear.ImageOptions.Image");
            _btnClear.Location = new Point(673, 617);
            _btnClear.Margin = new Padding(3, 4, 3, 4);
            _btnClear.Name = "_btnClear";
            _btnClear.Size = new Size(91, 27);
            _btnClear.StyleController = LayoutControl1;
            _btnClear.TabIndex = 18;
            _btnClear.Text = "Clear";
            // 
            // btnMeanMarkAnalysis
            // 
            _btnMeanMarkAnalysis.ImageOptions.Image = (Image)resources.GetObject("btnMeanMarkAnalysis.ImageOptions.Image");
            _btnMeanMarkAnalysis.Location = new Point(257, 569);
            _btnMeanMarkAnalysis.Margin = new Padding(3, 4, 3, 4);
            _btnMeanMarkAnalysis.Name = "_btnMeanMarkAnalysis";
            _btnMeanMarkAnalysis.Size = new Size(253, 27);
            _btnMeanMarkAnalysis.StyleController = LayoutControl1;
            _btnMeanMarkAnalysis.TabIndex = 17;
            _btnMeanMarkAnalysis.Text = "Departmental Subject Analysis";
            // 
            // Button2
            // 
            _Button2.ImageOptions.Image = (Image)resources.GetObject("Button2.ImageOptions.Image");
            _Button2.Location = new Point(257, 536);
            _Button2.Margin = new Padding(3, 4, 3, 4);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(253, 27);
            _Button2.StyleController = LayoutControl1;
            _Button2.TabIndex = 16;
            _Button2.Text = "Class Mean Grade Count Analysis";
            // 
            // Button3
            // 
            _Button3.ImageOptions.Image = (Image)resources.GetObject("Button3.ImageOptions.Image");
            _Button3.Location = new Point(257, 503);
            _Button3.Margin = new Padding(3, 4, 3, 4);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(253, 27);
            _Button3.StyleController = LayoutControl1;
            _Button3.TabIndex = 15;
            _Button3.Text = "Student Category Analysis";
            // 
            // Button1
            // 
            _Button1.ImageOptions.Image = (Image)resources.GetObject("Button1.ImageOptions.Image");
            _Button1.Location = new Point(257, 470);
            _Button1.Margin = new Padding(3, 4, 3, 4);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(253, 27);
            _Button1.StyleController = LayoutControl1;
            _Button1.TabIndex = 14;
            _Button1.Text = "Gender Analysis";
            // 
            // chkBestOf7
            // 
            chkBestOf7.Location = new Point(31, 439);
            chkBestOf7.Margin = new Padding(3, 4, 3, 4);
            chkBestOf7.Name = "chkBestOf7";
            chkBestOf7.Size = new Size(355, 25);
            chkBestOf7.TabIndex = 13;
            chkBestOf7.Text = "Use Best Of 7";
            chkBestOf7.UseVisualStyleBackColor = true;
            // 
            // radSubject
            // 
            radSubject.Location = new Point(392, 439);
            radSubject.Margin = new Padding(3, 4, 3, 4);
            radSubject.Name = "radSubject";
            radSubject.Size = new Size(357, 25);
            radSubject.TabIndex = 12;
            radSubject.Text = "Use Subject Based Grading";
            radSubject.UseVisualStyleBackColor = true;
            // 
            // btnAnalyze
            // 
            _btnAnalyze.Location = new Point(621, 353);
            _btnAnalyze.Margin = new Padding(3, 4, 3, 4);
            _btnAnalyze.Name = "_btnAnalyze";
            _btnAnalyze.Size = new Size(128, 27);
            _btnAnalyze.StyleController = LayoutControl1;
            _btnAnalyze.TabIndex = 11;
            _btnAnalyze.Text = "Analyze Examination";
            // 
            // lstExaminations
            // 
            lstExaminations.Columns.AddRange(new ColumnHeader[] { ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4 });
            lstExaminations.FullRowSelect = true;
            lstExaminations.GridLines = true;
            lstExaminations.Location = new Point(31, 277);
            lstExaminations.Margin = new Padding(3, 4, 3, 4);
            lstExaminations.Name = "lstExaminations";
            lstExaminations.Size = new Size(718, 70);
            lstExaminations.TabIndex = 10;
            lstExaminations.UseCompatibleStateImageBehavior = false;
            lstExaminations.View = View.Details;
            // 
            // ColumnHeader1
            // 
            ColumnHeader1.Text = "Exam";
            ColumnHeader1.Width = 225;
            // 
            // ColumnHeader2
            // 
            ColumnHeader2.Text = "Contribution";
            ColumnHeader2.Width = 109;
            // 
            // ColumnHeader3
            // 
            ColumnHeader3.Text = "Year";
            ColumnHeader3.Width = 115;
            // 
            // ColumnHeader4
            // 
            ColumnHeader4.Text = "Term";
            ColumnHeader4.Width = 166;
            // 
            // btnAddExam
            // 
            _btnAddExam.ImageOptions.Image = (Image)resources.GetObject("btnAddExam.ImageOptions.Image");
            _btnAddExam.Location = new Point(568, 181);
            _btnAddExam.Margin = new Padding(3, 4, 3, 4);
            _btnAddExam.Name = "_btnAddExam";
            _btnAddExam.Size = new Size(181, 27);
            _btnAddExam.StyleController = LayoutControl1;
            _btnAddExam.TabIndex = 9;
            _btnAddExam.Text = "Add Exam";
            // 
            // txtContribution
            // 
            _txtContribution.Location = new Point(103, 181);
            _txtContribution.Margin = new Padding(3, 4, 3, 4);
            _txtContribution.Name = "_txtContribution";
            _txtContribution.Size = new Size(282, 25);
            _txtContribution.TabIndex = 8;
            // 
            // cboExamName
            // 
            _cboExamName.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboExamName.FormattingEnabled = true;
            _cboExamName.Location = new Point(103, 149);
            _cboExamName.Margin = new Padding(3, 4, 3, 4);
            _cboExamName.Name = "_cboExamName";
            _cboExamName.Size = new Size(646, 24);
            _cboExamName.TabIndex = 7;
            // 
            // cboTerm
            // 
            _cboTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerm.FormattingEnabled = true;
            _cboTerm.Items.AddRange(new object[] { "None", "I", "II", "III" });
            _cboTerm.Location = new Point(103, 117);
            _cboTerm.Margin = new Padding(3, 4, 3, 4);
            _cboTerm.Name = "_cboTerm";
            _cboTerm.Size = new Size(646, 24);
            _cboTerm.TabIndex = 6;
            // 
            // cboYear
            // 
            cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cboYear.FormattingEnabled = true;
            cboYear.Location = new Point(103, 85);
            cboYear.Margin = new Padding(3, 4, 3, 4);
            cboYear.Name = "cboYear";
            cboYear.Size = new Size(646, 24);
            cboYear.TabIndex = 5;
            // 
            // chkMode
            // 
            _chkMode.Location = new Point(31, 54);
            _chkMode.Margin = new Padding(3, 4, 3, 4);
            _chkMode.Name = "_chkMode";
            _chkMode.Size = new Size(718, 25);
            _chkMode.TabIndex = 4;
            _chkMode.Text = "Analyze More Than One Examination";
            _chkMode.UseVisualStyleBackColor = true;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { grpSelect, grpMultiExaminations, grpAnalyze, EmptySpaceItem3, LayoutControlItem15, LayoutControlItem16 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(780, 660);
            LayoutControlGroup1.TextVisible = false;
            // 
            // grpSelect
            // 
            grpSelect.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, LayoutControlItem3, LayoutControlItem4, LayoutControlItem5, LayoutControlItem6, EmptySpaceItem1, LayoutControlItem17 });
            grpSelect.Location = new Point(0, 0);
            grpSelect.Name = "grpSelect";
            grpSelect.Size = new Size(754, 223);
            grpSelect.Text = "Select Examination (s)";
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _chkMode;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(724, 31);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = cboYear;
            LayoutControlItem2.Location = new Point(0, 31);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(724, 32);
            LayoutControlItem2.Text = "Year";
            LayoutControlItem2.TextSize = new Size(69, 16);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _cboTerm;
            LayoutControlItem3.Location = new Point(0, 63);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(724, 32);
            LayoutControlItem3.Text = "Term";
            LayoutControlItem3.TextSize = new Size(69, 16);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _cboExamName;
            LayoutControlItem4.Location = new Point(0, 95);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(724, 32);
            LayoutControlItem4.Text = "Examination";
            LayoutControlItem4.TextSize = new Size(69, 16);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = _txtContribution;
            LayoutControlItem5.Location = new Point(0, 127);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(360, 33);
            LayoutControlItem5.Text = "Contribution";
            LayoutControlItem5.TextSize = new Size(69, 16);
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = _btnAddExam;
            LayoutControlItem6.Location = new Point(537, 127);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(187, 33);
            LayoutControlItem6.TextSize = new Size(0, 0);
            LayoutControlItem6.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 160);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(724, 10);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem17
            // 
            LayoutControlItem17.Control = Label1;
            LayoutControlItem17.Location = new Point(360, 127);
            LayoutControlItem17.Name = "LayoutControlItem17";
            LayoutControlItem17.Size = new Size(177, 33);
            LayoutControlItem17.TextSize = new Size(0, 0);
            LayoutControlItem17.TextVisible = false;
            // 
            // grpMultiExaminations
            // 
            grpMultiExaminations.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem7, LayoutControlItem8, EmptySpaceItem2 });
            grpMultiExaminations.Location = new Point(0, 223);
            grpMultiExaminations.Name = "grpMultiExaminations";
            grpMultiExaminations.Size = new Size(754, 162);
            grpMultiExaminations.Text = "List Of Examinations and Their Respective Contribution";
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = lstExaminations;
            LayoutControlItem7.Location = new Point(0, 0);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(724, 76);
            LayoutControlItem7.TextSize = new Size(0, 0);
            LayoutControlItem7.TextVisible = false;
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = _btnAnalyze;
            LayoutControlItem8.Location = new Point(590, 76);
            LayoutControlItem8.Name = "LayoutControlItem8";
            LayoutControlItem8.Size = new Size(134, 33);
            LayoutControlItem8.TextSize = new Size(0, 0);
            LayoutControlItem8.TextVisible = false;
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 76);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(590, 33);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // grpAnalyze
            // 
            grpAnalyze.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem9, LayoutControlItem10, LayoutControlItem11, LayoutControlItem12, LayoutControlItem13, LayoutControlItem14, EmptySpaceItem4, EmptySpaceItem5 });
            grpAnalyze.Location = new Point(0, 385);
            grpAnalyze.Name = "grpAnalyze";
            grpAnalyze.Size = new Size(754, 216);
            grpAnalyze.Text = "General Analysis";
            // 
            // LayoutControlItem9
            // 
            LayoutControlItem9.Control = radSubject;
            LayoutControlItem9.Location = new Point(361, 0);
            LayoutControlItem9.Name = "LayoutControlItem9";
            LayoutControlItem9.Size = new Size(363, 31);
            LayoutControlItem9.TextSize = new Size(0, 0);
            LayoutControlItem9.TextVisible = false;
            // 
            // LayoutControlItem10
            // 
            LayoutControlItem10.Control = chkBestOf7;
            LayoutControlItem10.Location = new Point(0, 0);
            LayoutControlItem10.Name = "LayoutControlItem10";
            LayoutControlItem10.Size = new Size(361, 31);
            LayoutControlItem10.TextSize = new Size(0, 0);
            LayoutControlItem10.TextVisible = false;
            // 
            // LayoutControlItem11
            // 
            LayoutControlItem11.Control = _Button1;
            LayoutControlItem11.Location = new Point(226, 31);
            LayoutControlItem11.Name = "LayoutControlItem11";
            LayoutControlItem11.Size = new Size(259, 33);
            LayoutControlItem11.TextSize = new Size(0, 0);
            LayoutControlItem11.TextVisible = false;
            // 
            // LayoutControlItem12
            // 
            LayoutControlItem12.Control = _Button3;
            LayoutControlItem12.Location = new Point(226, 64);
            LayoutControlItem12.Name = "LayoutControlItem12";
            LayoutControlItem12.Size = new Size(259, 33);
            LayoutControlItem12.TextSize = new Size(0, 0);
            LayoutControlItem12.TextVisible = false;
            // 
            // LayoutControlItem13
            // 
            LayoutControlItem13.Control = _Button2;
            LayoutControlItem13.Location = new Point(226, 97);
            LayoutControlItem13.Name = "LayoutControlItem13";
            LayoutControlItem13.Size = new Size(259, 33);
            LayoutControlItem13.TextSize = new Size(0, 0);
            LayoutControlItem13.TextVisible = false;
            // 
            // LayoutControlItem14
            // 
            LayoutControlItem14.Control = _btnMeanMarkAnalysis;
            LayoutControlItem14.Location = new Point(226, 130);
            LayoutControlItem14.Name = "LayoutControlItem14";
            LayoutControlItem14.Size = new Size(259, 33);
            LayoutControlItem14.TextSize = new Size(0, 0);
            LayoutControlItem14.TextVisible = false;
            // 
            // EmptySpaceItem4
            // 
            EmptySpaceItem4.AllowHotTrack = false;
            EmptySpaceItem4.Location = new Point(0, 31);
            EmptySpaceItem4.Name = "EmptySpaceItem4";
            EmptySpaceItem4.Size = new Size(226, 132);
            EmptySpaceItem4.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem5
            // 
            EmptySpaceItem5.AllowHotTrack = false;
            EmptySpaceItem5.Location = new Point(485, 31);
            EmptySpaceItem5.Name = "EmptySpaceItem5";
            EmptySpaceItem5.Size = new Size(239, 132);
            EmptySpaceItem5.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem3
            // 
            EmptySpaceItem3.AllowHotTrack = false;
            EmptySpaceItem3.Location = new Point(0, 601);
            EmptySpaceItem3.Name = "EmptySpaceItem3";
            EmptySpaceItem3.Size = new Size(561, 33);
            EmptySpaceItem3.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem15
            // 
            LayoutControlItem15.Control = _btnClear;
            LayoutControlItem15.Location = new Point(657, 601);
            LayoutControlItem15.Name = "LayoutControlItem15";
            LayoutControlItem15.Size = new Size(97, 33);
            LayoutControlItem15.TextSize = new Size(0, 0);
            LayoutControlItem15.TextVisible = false;
            // 
            // LayoutControlItem16
            // 
            LayoutControlItem16.Control = _btnCancel;
            LayoutControlItem16.Location = new Point(561, 601);
            LayoutControlItem16.Name = "LayoutControlItem16";
            LayoutControlItem16.Size = new Size(96, 33);
            LayoutControlItem16.TextSize = new Size(0, 0);
            LayoutControlItem16.TextVisible = false;
            // 
            // printpreview
            // 
            printpreview.AutoScrollMargin = new Size(0, 0);
            printpreview.AutoScrollMinSize = new Size(0, 0);
            printpreview.ClientSize = new Size(400, 300);
            printpreview.Enabled = true;
            printpreview.Icon = (Icon)resources.GetObject("printpreview.Icon");
            printpreview.Name = "printpreview";
            printpreview.Visible = false;
            // 
            // frmSubjectPerformanceGeneral
            // 
            AutoScaleDimensions = new SizeF(7.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 660);
            Controls.Add(LayoutControl1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSubjectPerformanceGeneral";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subject Performance General";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpSelect).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem17).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpMultiExaminations).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpAnalyze).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem12).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem13).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem14).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem15).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem16).EndInit();
            Load += new EventHandler(frmSubjectPerformanceGeneral_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal Label Label1;
        private DevExpress.XtraEditors.SimpleButton _btnCancel;

        internal DevExpress.XtraEditors.SimpleButton btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

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

        private DevExpress.XtraEditors.SimpleButton _btnMeanMarkAnalysis;

        internal DevExpress.XtraEditors.SimpleButton btnMeanMarkAnalysis
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMeanMarkAnalysis;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMeanMarkAnalysis != null)
                {
                    _btnMeanMarkAnalysis.Click -= btnMeanMarkAnalysis_Click;
                }

                _btnMeanMarkAnalysis = value;
                if (_btnMeanMarkAnalysis != null)
                {
                    _btnMeanMarkAnalysis.Click += btnMeanMarkAnalysis_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _Button2;

        internal DevExpress.XtraEditors.SimpleButton Button2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button2 != null)
                {
                    _Button2.Click -= Button2_Click;
                }

                _Button2 = value;
                if (_Button2 != null)
                {
                    _Button2.Click += Button2_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _Button3;

        internal DevExpress.XtraEditors.SimpleButton Button3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button3 != null)
                {
                    _Button3.Click -= Button3_Click;
                }

                _Button3 = value;
                if (_Button3 != null)
                {
                    _Button3.Click += Button3_Click;
                }
            }
        }

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
        private DevExpress.XtraEditors.SimpleButton _btnAnalyze;

        internal DevExpress.XtraEditors.SimpleButton btnAnalyze
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAnalyze;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAnalyze != null)
                {
                    _btnAnalyze.Click -= btnAnalyze_Click;
                }

                _btnAnalyze = value;
                if (_btnAnalyze != null)
                {
                    _btnAnalyze.Click += btnAnalyze_Click;
                }
            }
        }

        internal ListView lstExaminations;
        internal ColumnHeader ColumnHeader1;
        internal ColumnHeader ColumnHeader2;
        internal ColumnHeader ColumnHeader3;
        internal ColumnHeader ColumnHeader4;
        private DevExpress.XtraEditors.SimpleButton _btnAddExam;

        internal DevExpress.XtraEditors.SimpleButton btnAddExam
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddExam;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddExam != null)
                {
                    _btnAddExam.Click -= btnAddExam_Click;
                }

                _btnAddExam = value;
                if (_btnAddExam != null)
                {
                    _btnAddExam.Click += btnAddExam_Click;
                }
            }
        }

        private TextBox _txtContribution;

        internal TextBox txtContribution
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContribution;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContribution != null)
                {
                    _txtContribution.KeyPress -= txtContribution_KeyPress;
                }

                _txtContribution = value;
                if (_txtContribution != null)
                {
                    _txtContribution.KeyPress += txtContribution_KeyPress;
                }
            }
        }

        private ComboBox _cboExamName;

        internal ComboBox cboExamName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboExamName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboExamName != null)
                {
                    _cboExamName.SelectedIndexChanged -= cboExamName_SelectedIndexChanged;
                }

                _cboExamName = value;
                if (_cboExamName != null)
                {
                    _cboExamName.SelectedIndexChanged += cboExamName_SelectedIndexChanged;
                }
            }
        }

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

        internal ComboBox cboYear;
        private CheckBox _chkMode;

        internal CheckBox chkMode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkMode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkMode != null)
                {
                    _chkMode.CheckedChanged -= chkMode_CheckedChanged;
                }

                _chkMode = value;
                if (_chkMode != null)
                {
                    _chkMode.CheckedChanged += chkMode_CheckedChanged;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlGroup grpSelect;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem17;
        internal DevExpress.XtraLayout.LayoutControlGroup grpMultiExaminations;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.LayoutControlGroup grpAnalyze;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem9;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem10;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem11;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem12;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem13;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem14;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem15;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem16;
        internal PrintPreviewDialog printpreview;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem4;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem5;
    }
}