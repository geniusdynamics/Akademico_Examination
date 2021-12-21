using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmEnterMarks : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnterMarks));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            CheckBox2 = new CheckBox();
            lblWait = new Label();
            lblSave = new Label();
            progress = new ProgressBar();
            _Button3 = new DevExpress.XtraEditors.SimpleButton();
            _Button3.Click += new EventHandler(Button3_Click);
            _Button1 = new DevExpress.XtraEditors.SimpleButton();
            _Button1.Click += new EventHandler(Button1_Click);
            _btnCancel = new DevExpress.XtraEditors.SimpleButton();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnSave = new DevExpress.XtraEditors.SimpleButton();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnClear = new DevExpress.XtraEditors.SimpleButton();
            _btnClear.Click += new EventHandler(btnClear_Click);
            dgvEnterMarks = new DataGridView();
            admin_no = new DataGridViewTextBoxColumn();
            IndexNo = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            Examination = new DataGridViewTextBoxColumn();
            Term = new DataGridViewTextBoxColumn();
            Year = new DataGridViewTextBoxColumn();
            _Button4 = new DevExpress.XtraEditors.SimpleButton();
            _Button4.Click += new EventHandler(Button4_Click);
            _Button2 = new DevExpress.XtraEditors.SimpleButton();
            _Button2.Click += new EventHandler(Button2_Click);
            ComboBox1 = new ComboBox();
            CheckBox1 = new CheckBox();
            _cboStream = new ComboBox();
            _cboStream.SelectedIndexChanged += new EventHandler(cboStream_SelectedIndexChanged);
            _cboClass = new ComboBox();
            _cboClass.SelectedIndexChanged += new EventHandler(cboClass_SelectedIndexChanged);
            _cboYear = new ComboBox();
            _cboYear.SelectedIndexChanged += new EventHandler(cboYear_SelectedIndexChanged);
            _cboTerm = new ComboBox();
            _cboTerm.SelectedIndexChanged += new EventHandler(cboYear_SelectedIndexChanged);
            _cboExamName = new ComboBox();
            _cboExamName.SelectedIndexChanged += new EventHandler(cboExamName_SelectedIndexChanged);
            cboSubject = new ComboBox();
            _btnImportResults = new DevExpress.XtraEditors.SimpleButton();
            _btnImportResults.Click += new EventHandler(btnImportResults_Click);
            _Editor = new DevExpress.XtraEditors.SimpleButton();
            _Editor.Click += new EventHandler(Editor_Click);
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            OpenFileDialog1 = new OpenFileDialog();
            SaveFileDialog1 = new SaveFileDialog();
            _deleteChk = new CheckBox();
            _deleteChk.CheckStateChanged += new EventHandler(deleteChk_CheckStateChanged);
            LayoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            _btnDelete = new DevExpress.XtraEditors.SimpleButton();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            LayoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEnterMarks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem18).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem19).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem20).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem22).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem23).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem24).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnDelete);
            LayoutControl1.Controls.Add(_deleteChk);
            LayoutControl1.Controls.Add(CheckBox2);
            LayoutControl1.Controls.Add(lblWait);
            LayoutControl1.Controls.Add(lblSave);
            LayoutControl1.Controls.Add(progress);
            LayoutControl1.Controls.Add(_Button3);
            LayoutControl1.Controls.Add(_Button1);
            LayoutControl1.Controls.Add(_btnCancel);
            LayoutControl1.Controls.Add(_btnSave);
            LayoutControl1.Controls.Add(_btnClear);
            LayoutControl1.Controls.Add(dgvEnterMarks);
            LayoutControl1.Controls.Add(_Button4);
            LayoutControl1.Controls.Add(_Button2);
            LayoutControl1.Controls.Add(ComboBox1);
            LayoutControl1.Controls.Add(CheckBox1);
            LayoutControl1.Controls.Add(_cboStream);
            LayoutControl1.Controls.Add(_cboClass);
            LayoutControl1.Controls.Add(_cboYear);
            LayoutControl1.Controls.Add(_cboTerm);
            LayoutControl1.Controls.Add(_cboExamName);
            LayoutControl1.Controls.Add(cboSubject);
            LayoutControl1.Controls.Add(_btnImportResults);
            LayoutControl1.Controls.Add(_Editor);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Margin = new Padding(3, 4, 3, 4);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(306, 290, 250, 350);
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(1323, 601);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // CheckBox2
            // 
            CheckBox2.Location = new Point(712, 541);
            CheckBox2.Margin = new Padding(3, 4, 3, 4);
            CheckBox2.Name = "CheckBox2";
            CheckBox2.Size = new Size(120, 25);
            CheckBox2.TabIndex = 23;
            CheckBox2.Text = "Landscape";
            CheckBox2.UseVisualStyleBackColor = true;
            // 
            // lblWait
            // 
            lblWait.Location = new Point(664, 413);
            lblWait.Name = "lblWait";
            lblWait.Size = new Size(643, 25);
            lblWait.TabIndex = 22;
            lblWait.Text = "Please Wait";
            // 
            // lblSave
            // 
            lblSave.Location = new Point(16, 413);
            lblSave.Name = "lblSave";
            lblSave.Size = new Size(642, 25);
            lblSave.TabIndex = 21;
            lblSave.Text = "Saving Data ....";
            // 
            // progress
            // 
            progress.Location = new Point(16, 444);
            progress.Margin = new Padding(3, 4, 3, 4);
            progress.Name = "progress";
            progress.Size = new Size(1291, 91);
            progress.TabIndex = 20;
            // 
            // Button3
            // 
            _Button3.ImageOptions.Image = (Image)resources.GetObject("Button3.ImageOptions.Image");
            _Button3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button3.Location = new Point(1124, 541);
            _Button3.Margin = new Padding(3, 4, 3, 4);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(89, 44);
            _Button3.StyleController = LayoutControl1;
            _Button3.TabIndex = 19;
            _Button3.Text = "Export";
            // 
            // Button1
            // 
            _Button1.ImageOptions.Image = (Image)resources.GetObject("Button1.ImageOptions.Image");
            _Button1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button1.Location = new Point(1219, 541);
            _Button1.Margin = new Padding(3, 4, 3, 4);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(88, 44);
            _Button1.StyleController = LayoutControl1;
            _Button1.TabIndex = 18;
            _Button1.Text = "Print";
            // 
            // btnCancel
            // 
            _btnCancel.ImageOptions.Image = (Image)resources.GetObject("btnCancel.ImageOptions.Image");
            _btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnCancel.Location = new Point(838, 541);
            _btnCancel.Margin = new Padding(3, 4, 3, 4);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(90, 44);
            _btnCancel.StyleController = LayoutControl1;
            _btnCancel.TabIndex = 17;
            _btnCancel.Text = "Cancel";
            // 
            // btnSave
            // 
            _btnSave.ImageOptions.Image = (Image)resources.GetObject("btnSave.ImageOptions.Image");
            _btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnSave.Location = new Point(1030, 541);
            _btnSave.Margin = new Padding(3, 4, 3, 4);
            _btnSave.Name = "_btnSave";
            _btnSave.Size = new Size(88, 44);
            _btnSave.StyleController = LayoutControl1;
            _btnSave.TabIndex = 16;
            _btnSave.Text = "Save";
            // 
            // btnClear
            // 
            _btnClear.ImageOptions.Image = (Image)resources.GetObject("btnClear.ImageOptions.Image");
            _btnClear.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnClear.Location = new Point(934, 541);
            _btnClear.Margin = new Padding(3, 4, 3, 4);
            _btnClear.Name = "_btnClear";
            _btnClear.Size = new Size(90, 44);
            _btnClear.StyleController = LayoutControl1;
            _btnClear.TabIndex = 15;
            _btnClear.Text = "Import";
            // 
            // dgvEnterMarks
            // 
            dgvEnterMarks.AllowUserToAddRows = false;
            dgvEnterMarks.AllowUserToDeleteRows = false;
            dgvEnterMarks.AllowUserToOrderColumns = true;
            dgvEnterMarks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnterMarks.Columns.AddRange(new DataGridViewColumn[] { admin_no, IndexNo, StudentName, Examination, Term, Year });
            dgvEnterMarks.Location = new Point(16, 108);
            dgvEnterMarks.Margin = new Padding(3, 4, 3, 4);
            dgvEnterMarks.Name = "dgvEnterMarks";
            dgvEnterMarks.Size = new Size(1291, 299);
            dgvEnterMarks.TabIndex = 14;
            // 
            // admin_no
            // 
            admin_no.HeaderText = "ADM.";
            admin_no.Name = "admin_no";
            // 
            // IndexNo
            // 
            IndexNo.HeaderText = "Index No.";
            IndexNo.Name = "IndexNo";
            // 
            // StudentName
            // 
            StudentName.HeaderText = "Name Of Student";
            StudentName.Name = "StudentName";
            // 
            // Examination
            // 
            Examination.HeaderText = "Examination";
            Examination.Name = "Examination";
            Examination.Visible = false;
            // 
            // Term
            // 
            Term.HeaderText = "Term";
            Term.Name = "Term";
            Term.Visible = false;
            // 
            // Year
            // 
            Year.HeaderText = "Year";
            Year.Name = "Year";
            Year.Visible = false;
            // 
            // Button4
            // 
            _Button4.ImageOptions.Image = (Image)resources.GetObject("Button4.ImageOptions.Image");
            _Button4.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button4.Location = new Point(1143, 58);
            _Button4.Margin = new Padding(3, 4, 3, 4);
            _Button4.Name = "_Button4";
            _Button4.Size = new Size(164, 44);
            _Button4.StyleController = LayoutControl1;
            _Button4.TabIndex = 13;
            _Button4.Text = "Enter Subject Based Marks";
            // 
            // Button2
            // 
            _Button2.ImageOptions.Image = (Image)resources.GetObject("Button2.ImageOptions.Image");
            _Button2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button2.Location = new Point(745, 58);
            _Button2.Margin = new Padding(3, 4, 3, 4);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(392, 44);
            _Button2.StyleController = LayoutControl1;
            _Button2.TabIndex = 12;
            _Button2.Text = "Load Marks";
            // 
            // ComboBox1
            // 
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox1.FormattingEnabled = true;
            ComboBox1.Items.AddRange(new object[] { "Adm. No.", "Index No.", "Name" });
            ComboBox1.Location = new Point(449, 58);
            ComboBox1.Margin = new Padding(3, 4, 3, 4);
            ComboBox1.Name = "ComboBox1";
            ComboBox1.Size = new Size(290, 24);
            ComboBox1.TabIndex = 11;
            // 
            // CheckBox1
            // 
            CheckBox1.Location = new Point(16, 58);
            CheckBox1.Margin = new Padding(3, 4, 3, 4);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(374, 25);
            CheckBox1.TabIndex = 10;
            CheckBox1.Text = "Show Constituent Subjects";
            CheckBox1.UseVisualStyleBackColor = true;
            // 
            // cboStream
            // 
            _cboStream.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStream.FormattingEnabled = true;
            _cboStream.Location = new Point(862, 16);
            _cboStream.Margin = new Padding(3, 4, 3, 4);
            _cboStream.Name = "_cboStream";
            _cboStream.Size = new Size(130, 24);
            _cboStream.TabIndex = 9;
            // 
            // cboClass
            // 
            _cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboClass.FormattingEnabled = true;
            _cboClass.Location = new Point(666, 16);
            _cboClass.Margin = new Padding(3, 4, 3, 4);
            _cboClass.Name = "_cboClass";
            _cboClass.Size = new Size(137, 24);
            _cboClass.TabIndex = 8;
            // 
            // cboYear
            // 
            _cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear.FormattingEnabled = true;
            _cboYear.Location = new Point(69, 16);
            _cboYear.Margin = new Padding(3, 4, 3, 4);
            _cboYear.Name = "_cboYear";
            _cboYear.Size = new Size(124, 24);
            _cboYear.TabIndex = 7;
            // 
            // cboTerm
            // 
            _cboTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerm.FormattingEnabled = true;
            _cboTerm.Items.AddRange(new object[] { "None", "I", "II", "III" });
            _cboTerm.Location = new Point(252, 16);
            _cboTerm.Margin = new Padding(3, 4, 3, 4);
            _cboTerm.Name = "_cboTerm";
            _cboTerm.Size = new Size(78, 24);
            _cboTerm.TabIndex = 6;
            // 
            // cboExamName
            // 
            _cboExamName.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboExamName.FormattingEnabled = true;
            _cboExamName.Location = new Point(389, 16);
            _cboExamName.Margin = new Padding(3, 4, 3, 4);
            _cboExamName.Name = "_cboExamName";
            _cboExamName.Size = new Size(218, 24);
            _cboExamName.TabIndex = 5;
            // 
            // cboSubject
            // 
            cboSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSubject.FormattingEnabled = true;
            cboSubject.Location = new Point(1051, 16);
            cboSubject.Margin = new Padding(3, 4, 3, 4);
            cboSubject.Name = "cboSubject";
            cboSubject.Size = new Size(256, 24);
            cboSubject.TabIndex = 4;
            // 
            // btnImportResults
            // 
            _btnImportResults.ImageOptions.Image = (Image)resources.GetObject("btnImportResults.ImageOptions.Image");
            _btnImportResults.Location = new Point(16, 541);
            _btnImportResults.Margin = new Padding(3, 4, 3, 4);
            _btnImportResults.Name = "_btnImportResults";
            _btnImportResults.Size = new Size(111, 27);
            _btnImportResults.StyleController = LayoutControl1;
            _btnImportResults.TabIndex = 24;
            _btnImportResults.Text = "Simple Import";
            // 
            // Editor
            // 
            _Editor.Location = new Point(133, 541);
            _Editor.Margin = new Padding(3, 4, 3, 4);
            _Editor.Name = "_Editor";
            _Editor.Size = new Size(118, 27);
            _Editor.StyleController = LayoutControl1;
            _Editor.TabIndex = 25;
            _Editor.Text = "Editor";
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem7, LayoutControlItem11, LayoutControlItem6, LayoutControlItem5, LayoutControlItem2, LayoutControlItem3, LayoutControlItem4, LayoutControlItem8, LayoutControlItem10, LayoutControlItem15, LayoutControlItem16, LayoutControlItem13, LayoutControlItem12, LayoutControlItem14, EmptySpaceItem2, LayoutControlItem9, LayoutControlItem17, LayoutControlItem18, LayoutControlItem19, LayoutControlItem20, LayoutControlItem21, EmptySpaceItem4, LayoutControlItem22, EmptySpaceItem1, LayoutControlItem23, LayoutControlItem24 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(1323, 601);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = cboSubject;
            LayoutControlItem1.Location = new Point(982, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(315, 32);
            LayoutControlItem1.Text = "Subject";
            LayoutControlItem1.TextSize = new Size(50, 16);
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = CheckBox1;
            LayoutControlItem7.Location = new Point(0, 42);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(380, 50);
            LayoutControlItem7.TextSize = new Size(0, 0);
            LayoutControlItem7.TextVisible = false;
            // 
            // LayoutControlItem11
            // 
            LayoutControlItem11.Control = dgvEnterMarks;
            LayoutControlItem11.Location = new Point(0, 92);
            LayoutControlItem11.Name = "LayoutControlItem11";
            LayoutControlItem11.Size = new Size(1297, 305);
            LayoutControlItem11.TextSize = new Size(0, 0);
            LayoutControlItem11.TextVisible = false;
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = _cboStream;
            LayoutControlItem6.Location = new Point(793, 0);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(189, 32);
            LayoutControlItem6.Text = "Stream";
            LayoutControlItem6.TextSize = new Size(50, 16);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = _cboClass;
            LayoutControlItem5.Location = new Point(597, 0);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(196, 32);
            LayoutControlItem5.Text = "Class";
            LayoutControlItem5.TextSize = new Size(50, 16);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _cboExamName;
            LayoutControlItem2.Location = new Point(320, 0);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(277, 32);
            LayoutControlItem2.Text = "Exam";
            LayoutControlItem2.TextSize = new Size(50, 16);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _cboTerm;
            LayoutControlItem3.Location = new Point(183, 0);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(137, 32);
            LayoutControlItem3.Text = "Term";
            LayoutControlItem3.TextSize = new Size(50, 16);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _cboYear;
            LayoutControlItem4.Location = new Point(0, 0);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(183, 32);
            LayoutControlItem4.Text = "Year";
            LayoutControlItem4.TextSize = new Size(50, 16);
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = ComboBox1;
            LayoutControlItem8.Location = new Point(380, 42);
            LayoutControlItem8.Name = "LayoutControlItem8";
            LayoutControlItem8.Size = new Size(349, 50);
            LayoutControlItem8.Text = "Order By";
            LayoutControlItem8.TextSize = new Size(50, 16);
            // 
            // LayoutControlItem10
            // 
            LayoutControlItem10.Control = _Button4;
            LayoutControlItem10.Location = new Point(1127, 42);
            LayoutControlItem10.Name = "LayoutControlItem10";
            LayoutControlItem10.Size = new Size(170, 50);
            LayoutControlItem10.TextSize = new Size(0, 0);
            LayoutControlItem10.TextVisible = false;
            // 
            // LayoutControlItem15
            // 
            LayoutControlItem15.Control = _Button1;
            LayoutControlItem15.Location = new Point(1203, 525);
            LayoutControlItem15.Name = "LayoutControlItem15";
            LayoutControlItem15.Size = new Size(94, 50);
            LayoutControlItem15.TextSize = new Size(0, 0);
            LayoutControlItem15.TextVisible = false;
            // 
            // LayoutControlItem16
            // 
            LayoutControlItem16.Control = _Button3;
            LayoutControlItem16.Location = new Point(1108, 525);
            LayoutControlItem16.Name = "LayoutControlItem16";
            LayoutControlItem16.Size = new Size(95, 50);
            LayoutControlItem16.TextSize = new Size(0, 0);
            LayoutControlItem16.TextVisible = false;
            // 
            // LayoutControlItem13
            // 
            LayoutControlItem13.Control = _btnSave;
            LayoutControlItem13.Location = new Point(1014, 525);
            LayoutControlItem13.Name = "LayoutControlItem13";
            LayoutControlItem13.Size = new Size(94, 50);
            LayoutControlItem13.TextSize = new Size(0, 0);
            LayoutControlItem13.TextVisible = false;
            // 
            // LayoutControlItem12
            // 
            LayoutControlItem12.Control = _btnClear;
            LayoutControlItem12.Location = new Point(918, 525);
            LayoutControlItem12.Name = "LayoutControlItem12";
            LayoutControlItem12.Size = new Size(96, 50);
            LayoutControlItem12.TextSize = new Size(0, 0);
            LayoutControlItem12.TextVisible = false;
            // 
            // LayoutControlItem14
            // 
            LayoutControlItem14.Control = _btnCancel;
            LayoutControlItem14.Location = new Point(822, 525);
            LayoutControlItem14.Name = "LayoutControlItem14";
            LayoutControlItem14.Size = new Size(96, 50);
            LayoutControlItem14.TextSize = new Size(0, 0);
            LayoutControlItem14.TextVisible = false;
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 32);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(1297, 10);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem9
            // 
            LayoutControlItem9.Control = _Button2;
            LayoutControlItem9.Location = new Point(729, 42);
            LayoutControlItem9.Name = "LayoutControlItem9";
            LayoutControlItem9.Size = new Size(398, 50);
            LayoutControlItem9.TextSize = new Size(0, 0);
            LayoutControlItem9.TextVisible = false;
            // 
            // LayoutControlItem17
            // 
            LayoutControlItem17.Control = progress;
            LayoutControlItem17.Location = new Point(0, 428);
            LayoutControlItem17.Name = "LayoutControlItem17";
            LayoutControlItem17.Size = new Size(1297, 97);
            LayoutControlItem17.TextSize = new Size(0, 0);
            LayoutControlItem17.TextVisible = false;
            // 
            // LayoutControlItem18
            // 
            LayoutControlItem18.Control = lblSave;
            LayoutControlItem18.Location = new Point(0, 397);
            LayoutControlItem18.Name = "LayoutControlItem18";
            LayoutControlItem18.Size = new Size(648, 31);
            LayoutControlItem18.TextSize = new Size(0, 0);
            LayoutControlItem18.TextVisible = false;
            // 
            // LayoutControlItem19
            // 
            LayoutControlItem19.Control = lblWait;
            LayoutControlItem19.Location = new Point(648, 397);
            LayoutControlItem19.Name = "LayoutControlItem19";
            LayoutControlItem19.Size = new Size(649, 31);
            LayoutControlItem19.TextSize = new Size(0, 0);
            LayoutControlItem19.TextVisible = false;
            // 
            // LayoutControlItem20
            // 
            LayoutControlItem20.Control = CheckBox2;
            LayoutControlItem20.Location = new Point(696, 525);
            LayoutControlItem20.Name = "LayoutControlItem20";
            LayoutControlItem20.Size = new Size(126, 50);
            LayoutControlItem20.TextSize = new Size(0, 0);
            LayoutControlItem20.TextVisible = false;
            // 
            // LayoutControlItem21
            // 
            LayoutControlItem21.Control = _btnImportResults;
            LayoutControlItem21.Location = new Point(0, 525);
            LayoutControlItem21.Name = "LayoutControlItem21";
            LayoutControlItem21.Size = new Size(117, 33);
            LayoutControlItem21.TextSize = new Size(0, 0);
            LayoutControlItem21.TextVisible = false;
            // 
            // EmptySpaceItem4
            // 
            EmptySpaceItem4.AllowHotTrack = false;
            EmptySpaceItem4.Location = new Point(0, 558);
            EmptySpaceItem4.Name = "EmptySpaceItem4";
            EmptySpaceItem4.Size = new Size(117, 17);
            EmptySpaceItem4.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem22
            // 
            LayoutControlItem22.Control = _Editor;
            LayoutControlItem22.Location = new Point(117, 525);
            LayoutControlItem22.Name = "LayoutControlItem22";
            LayoutControlItem22.Size = new Size(124, 50);
            LayoutControlItem22.TextSize = new Size(0, 0);
            LayoutControlItem22.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(241, 525);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(227, 50);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // OpenFileDialog1
            // 
            OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // deleteChk
            // 
            _deleteChk.Location = new Point(484, 541);
            _deleteChk.Margin = new Padding(3, 4, 3, 4);
            _deleteChk.Name = "_deleteChk";
            _deleteChk.Size = new Size(108, 25);
            _deleteChk.TabIndex = 26;
            _deleteChk.Text = "Delete";
            _deleteChk.UseVisualStyleBackColor = true;
            // 
            // LayoutControlItem23
            // 
            LayoutControlItem23.Control = _deleteChk;
            LayoutControlItem23.Location = new Point(468, 525);
            LayoutControlItem23.Name = "LayoutControlItem23";
            LayoutControlItem23.Size = new Size(114, 50);
            LayoutControlItem23.TextSize = new Size(0, 0);
            LayoutControlItem23.TextVisible = false;
            // 
            // btnDelete
            // 
            _btnDelete.ImageOptions.Image = (Image)resources.GetObject("SimpleButton1.ImageOptions.Image");
            _btnDelete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnDelete.Location = new Point(598, 541);
            _btnDelete.Margin = new Padding(3, 4, 3, 4);
            _btnDelete.Name = "_btnDelete";
            _btnDelete.Size = new Size(108, 44);
            _btnDelete.StyleController = LayoutControl1;
            _btnDelete.TabIndex = 27;
            _btnDelete.Text = "Delete";
            // 
            // LayoutControlItem24
            // 
            LayoutControlItem24.Control = _btnDelete;
            LayoutControlItem24.Location = new Point(582, 525);
            LayoutControlItem24.Name = "LayoutControlItem24";
            LayoutControlItem24.Size = new Size(114, 50);
            LayoutControlItem24.TextSize = new Size(0, 0);
            LayoutControlItem24.TextVisible = false;
            // 
            // frmEnterMarks
            // 
            AutoScaleDimensions = new SizeF(7.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 601);
            Controls.Add(LayoutControl1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmEnterMarks";
            Text = "Enter Marks";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEnterMarks).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem15).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem16).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem13).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem12).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem14).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem17).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem18).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem19).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem20).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem21).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem22).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem23).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem24).EndInit();
            Load += new EventHandler(frmEnterMarks_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
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

        internal DataGridView dgvEnterMarks;
        private DevExpress.XtraEditors.SimpleButton _Button4;

        internal DevExpress.XtraEditors.SimpleButton Button4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button4 != null)
                {
                    _Button4.Click -= Button4_Click;
                }

                _Button4 = value;
                if (_Button4 != null)
                {
                    _Button4.Click += Button4_Click;
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

        internal ComboBox ComboBox1;
        internal CheckBox CheckBox1;
        private ComboBox _cboStream;

        internal ComboBox cboStream
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboStream;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboStream != null)
                {
                    _cboStream.SelectedIndexChanged -= cboStream_SelectedIndexChanged;
                }

                _cboStream = value;
                if (_cboStream != null)
                {
                    _cboStream.SelectedIndexChanged += cboStream_SelectedIndexChanged;
                }
            }
        }

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
                    _cboTerm.SelectedIndexChanged -= cboYear_SelectedIndexChanged;
                }

                _cboTerm = value;
                if (_cboTerm != null)
                {
                    _cboTerm.SelectedIndexChanged += cboYear_SelectedIndexChanged;
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

        internal ComboBox cboSubject;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem11;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem10;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem15;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem16;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem13;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem12;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem14;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem9;
        internal OpenFileDialog OpenFileDialog1;
        internal SaveFileDialog SaveFileDialog1;
        internal ProgressBar progress;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem17;
        internal Label lblSave;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem18;
        internal Label lblWait;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem19;
        internal CheckBox CheckBox2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem20;
        internal DataGridViewTextBoxColumn admin_no;
        internal DataGridViewTextBoxColumn IndexNo;
        internal DataGridViewTextBoxColumn StudentName;
        internal DataGridViewTextBoxColumn Examination;
        internal DataGridViewTextBoxColumn Term;
        internal DataGridViewTextBoxColumn Year;
        private DevExpress.XtraEditors.SimpleButton _btnImportResults;

        internal DevExpress.XtraEditors.SimpleButton btnImportResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnImportResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnImportResults != null)
                {
                    _btnImportResults.Click -= btnImportResults_Click;
                }

                _btnImportResults = value;
                if (_btnImportResults != null)
                {
                    _btnImportResults.Click += btnImportResults_Click;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem21;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem4;
        private DevExpress.XtraEditors.SimpleButton _Editor;

        internal DevExpress.XtraEditors.SimpleButton Editor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Editor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Editor != null)
                {
                    _Editor.Click -= Editor_Click;
                }

                _Editor = value;
                if (_Editor != null)
                {
                    _Editor.Click += Editor_Click;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem22;
        private CheckBox _deleteChk;

        internal CheckBox deleteChk
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _deleteChk;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_deleteChk != null)
                {
                    _deleteChk.CheckStateChanged -= deleteChk_CheckStateChanged;
                }

                _deleteChk = value;
                if (_deleteChk != null)
                {
                    _deleteChk.CheckStateChanged += deleteChk_CheckStateChanged;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem23;
        private DevExpress.XtraEditors.SimpleButton _btnDelete;

        internal DevExpress.XtraEditors.SimpleButton btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem24;
    }
}