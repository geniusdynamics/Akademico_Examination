using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmResults : DevExpress.XtraEditors.XtraForm
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResults));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _Button2 = new DevExpress.XtraEditors.SimpleButton();
            _Button2.Click += new EventHandler(Button2_Click_1);
            _btnViewReport = new DevExpress.XtraEditors.SimpleButton();
            _btnViewReport.Click += new EventHandler(Button2_Click);
            _btnClassPerformance = new DevExpress.XtraEditors.SimpleButton();
            _btnClassPerformance.Click += new EventHandler(btnClassPerformance_Click);
            _Button5 = new DevExpress.XtraEditors.SimpleButton();
            _Button5.Click += new EventHandler(Button5_Click);
            _btnStreamPerformance = new DevExpress.XtraEditors.SimpleButton();
            _btnStreamPerformance.Click += new EventHandler(btnStreamPerformance_Click);
            _btnCancel = new DevExpress.XtraEditors.SimpleButton();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _Button1 = new DevExpress.XtraEditors.SimpleButton();
            _Button1.Click += new EventHandler(Button1_Click_1);
            _Button6 = new DevExpress.XtraEditors.SimpleButton();
            _Button6.Click += new EventHandler(Button6_Click);
            _Button3 = new DevExpress.XtraEditors.SimpleButton();
            _Button3.Click += new EventHandler(Button3_Click_1);
            _btnReload = new DevExpress.XtraEditors.SimpleButton();
            _btnReload.Click += new EventHandler(btnReload_Click);
            _btnGrade = new DevExpress.XtraEditors.SimpleButton();
            _btnGrade.Click += new EventHandler(btnGrade_Click);
            _radSubject = new CheckBox();
            _radSubject.CheckedChanged += new EventHandler(radSubject_CheckedChanged);
            _chkMode = new CheckBox();
            _chkMode.CheckedChanged += new EventHandler(chkmode_CheckedChanged);
            chkSplit = new CheckBox();
            _Button4 = new DevExpress.XtraEditors.SimpleButton();
            _Button4.Click += new EventHandler(Button4_Click_1);
            Pbar = new ProgressBar();
            _dgvEnterMarks = new DataGridView();
            _dgvEnterMarks.RowsAdded += new DataGridViewRowsAddedEventHandler(dgvEnterMarks_RowsAdded);
            ADMNo = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewImageColumn();
            Column2 = new DataGridViewImageColumn();
            Column3 = new DataGridViewImageColumn();
            Column4 = new DataGridViewImageColumn();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            _Timer1 = new Timer(components);
            _Timer1.Tick += new EventHandler(Timer1_Tick);
            _Timer2 = new Timer(components);
            _Timer2.Tick += new EventHandler(Timer2_Tick);
            printpreview = new PrintPreviewDialog();
            SaveFileDialog1 = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvEnterMarks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_Button2);
            LayoutControl1.Controls.Add(_btnViewReport);
            LayoutControl1.Controls.Add(_btnClassPerformance);
            LayoutControl1.Controls.Add(_Button5);
            LayoutControl1.Controls.Add(_btnStreamPerformance);
            LayoutControl1.Controls.Add(_btnCancel);
            LayoutControl1.Controls.Add(_Button1);
            LayoutControl1.Controls.Add(_Button6);
            LayoutControl1.Controls.Add(_Button3);
            LayoutControl1.Controls.Add(_btnReload);
            LayoutControl1.Controls.Add(_btnGrade);
            LayoutControl1.Controls.Add(_radSubject);
            LayoutControl1.Controls.Add(_chkMode);
            LayoutControl1.Controls.Add(chkSplit);
            LayoutControl1.Controls.Add(_Button4);
            LayoutControl1.Controls.Add(Pbar);
            LayoutControl1.Controls.Add(_dgvEnterMarks);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Margin = new Padding(3, 4, 3, 4);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(361, 110, 250, 350);
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(1259, 619);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // Button2
            // 
            _Button2.ImageOptions.Image = (Image)resources.GetObject("Button2.ImageOptions.Image");
            _Button2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button2.Location = new Point(163, 559);
            _Button2.Margin = new Padding(3, 4, 3, 4);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(153, 44);
            _Button2.StyleController = LayoutControl1;
            _Button2.TabIndex = 20;
            _Button2.Text = "&Print Report Forms";
            // 
            // btnViewReport
            // 
            _btnViewReport.ImageOptions.Image = (Image)resources.GetObject("btnViewReport.ImageOptions.Image");
            _btnViewReport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnViewReport.Location = new Point(16, 559);
            _btnViewReport.Margin = new Padding(3, 4, 3, 4);
            _btnViewReport.Name = "_btnViewReport";
            _btnViewReport.Size = new Size(141, 44);
            _btnViewReport.StyleController = LayoutControl1;
            _btnViewReport.TabIndex = 19;
            _btnViewReport.Text = "Preview &Report Form";
            // 
            // btnClassPerformance
            // 
            _btnClassPerformance.ImageOptions.Image = (Image)resources.GetObject("btnClassPerformance.ImageOptions.Image");
            _btnClassPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnClassPerformance.Location = new Point(470, 559);
            _btnClassPerformance.Margin = new Padding(3, 4, 3, 4);
            _btnClassPerformance.Name = "_btnClassPerformance";
            _btnClassPerformance.Size = new Size(159, 44);
            _btnClassPerformance.StyleController = LayoutControl1;
            _btnClassPerformance.TabIndex = 18;
            _btnClassPerformance.Text = "&Class Merit List";
            // 
            // Button5
            // 
            _Button5.ImageOptions.Image = (Image)resources.GetObject("Button5.ImageOptions.Image");
            _Button5.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button5.Location = new Point(788, 559);
            _Button5.Margin = new Padding(3, 4, 3, 4);
            _Button5.Name = "_Button5";
            _Button5.Size = new Size(223, 44);
            _Button5.StyleController = LayoutControl1;
            _Button5.TabIndex = 17;
            _Button5.Text = "&SMS Results To Parents/ Guardians";
            // 
            // btnStreamPerformance
            // 
            _btnStreamPerformance.ImageOptions.Image = (Image)resources.GetObject("btnStreamPerformance.ImageOptions.Image");
            _btnStreamPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnStreamPerformance.Location = new Point(635, 559);
            _btnStreamPerformance.Margin = new Padding(3, 4, 3, 4);
            _btnStreamPerformance.Name = "_btnStreamPerformance";
            _btnStreamPerformance.Size = new Size(147, 44);
            _btnStreamPerformance.StyleController = LayoutControl1;
            _btnStreamPerformance.TabIndex = 16;
            _btnStreamPerformance.Text = "&Stream Merit List";
            // 
            // btnCancel
            // 
            _btnCancel.ImageOptions.Image = (Image)resources.GetObject("btnCancel.ImageOptions.Image");
            _btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnCancel.Location = new Point(1185, 559);
            _btnCancel.Margin = new Padding(3, 4, 3, 4);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(58, 44);
            _btnCancel.StyleController = LayoutControl1;
            _btnCancel.TabIndex = 15;
            _btnCancel.Text = "&Quit";
            // 
            // Button1
            // 
            _Button1.ImageOptions.Image = (Image)resources.GetObject("Button1.ImageOptions.Image");
            _Button1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button1.Location = new Point(322, 559);
            _Button1.Margin = new Padding(3, 4, 3, 4);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(142, 44);
            _Button1.StyleController = LayoutControl1;
            _Button1.TabIndex = 14;
            _Button1.Text = "&Result Slips";
            // 
            // Button6
            // 
            _Button6.ImageOptions.Image = (Image)resources.GetObject("Button6.ImageOptions.Image");
            _Button6.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button6.Location = new Point(163, 509);
            _Button6.Margin = new Padding(3, 4, 3, 4);
            _Button6.Name = "_Button6";
            _Button6.Size = new Size(157, 44);
            _Button6.StyleController = LayoutControl1;
            _Button6.TabIndex = 13;
            _Button6.Text = "Use Analysis For Indexing";
            // 
            // Button3
            // 
            _Button3.ImageOptions.Image = (Image)resources.GetObject("Button3.ImageOptions.Image");
            _Button3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button3.Location = new Point(326, 509);
            _Button3.Margin = new Padding(3, 4, 3, 4);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(138, 44);
            _Button3.StyleController = LayoutControl1;
            _Button3.TabIndex = 12;
            _Button3.Text = "Export To Excel";
            // 
            // btnReload
            // 
            _btnReload.ImageOptions.Image = (Image)resources.GetObject("btnReload.ImageOptions.Image");
            _btnReload.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnReload.Location = new Point(470, 509);
            _btnReload.Margin = new Padding(3, 4, 3, 4);
            _btnReload.Name = "_btnReload";
            _btnReload.Size = new Size(159, 44);
            _btnReload.StyleController = LayoutControl1;
            _btnReload.TabIndex = 11;
            _btnReload.Text = "Refresh";
            // 
            // btnGrade
            // 
            _btnGrade.ImageOptions.Image = (Image)resources.GetObject("btnGrade.ImageOptions.Image");
            _btnGrade.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnGrade.Location = new Point(16, 509);
            _btnGrade.Margin = new Padding(3, 4, 3, 4);
            _btnGrade.Name = "_btnGrade";
            _btnGrade.Size = new Size(141, 44);
            _btnGrade.StyleController = LayoutControl1;
            _btnGrade.TabIndex = 10;
            _btnGrade.Text = "Show Marks + Grades";
            // 
            // radSubject
            // 
            _radSubject.Checked = true;
            _radSubject.CheckState = CheckState.Checked;
            _radSubject.Location = new Point(788, 509);
            _radSubject.Margin = new Padding(3, 4, 3, 4);
            _radSubject.Name = "_radSubject";
            _radSubject.Size = new Size(219, 25);
            _radSubject.TabIndex = 9;
            _radSubject.Text = "Use Subject Grading";
            _radSubject.UseVisualStyleBackColor = true;
            // 
            // chkMode
            // 
            _chkMode.Location = new Point(635, 509);
            _chkMode.Margin = new Padding(3, 4, 3, 4);
            _chkMode.Name = "_chkMode";
            _chkMode.Size = new Size(147, 25);
            _chkMode.TabIndex = 8;
            _chkMode.Text = "Best Of 7";
            _chkMode.UseVisualStyleBackColor = true;
            // 
            // chkSplit
            // 
            chkSplit.Location = new Point(1013, 509);
            chkSplit.Margin = new Padding(3, 4, 3, 4);
            chkSplit.Name = "chkSplit";
            chkSplit.Size = new Size(230, 25);
            chkSplit.TabIndex = 7;
            chkSplit.Text = "Show Constituent Subjects On Report Form";
            chkSplit.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            _Button4.ImageOptions.Image = (Image)resources.GetObject("Button4.ImageOptions.Image");
            _Button4.Location = new Point(1035, 476);
            _Button4.Margin = new Padding(3, 4, 3, 4);
            _Button4.Name = "_Button4";
            _Button4.Size = new Size(208, 27);
            _Button4.StyleController = LayoutControl1;
            _Button4.TabIndex = 6;
            _Button4.Text = "Save Examination Performance";
            // 
            // Pbar
            // 
            Pbar.Location = new Point(16, 476);
            Pbar.Margin = new Padding(3, 4, 3, 4);
            Pbar.Name = "Pbar";
            Pbar.Size = new Size(988, 27);
            Pbar.TabIndex = 5;
            // 
            // dgvEnterMarks
            // 
            _dgvEnterMarks.AllowUserToAddRows = false;
            _dgvEnterMarks.AllowUserToDeleteRows = false;
            _dgvEnterMarks.AllowUserToOrderColumns = true;
            _dgvEnterMarks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _dgvEnterMarks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvEnterMarks.Columns.AddRange(new DataGridViewColumn[] { ADMNo, StudentName, Column1, Column2, Column3, Column4 });
            _dgvEnterMarks.Location = new Point(16, 16);
            _dgvEnterMarks.Margin = new Padding(3, 4, 3, 4);
            _dgvEnterMarks.Name = "_dgvEnterMarks";
            _dgvEnterMarks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvEnterMarks.Size = new Size(1227, 454);
            _dgvEnterMarks.TabIndex = 4;
            // 
            // ADMNo
            // 
            ADMNo.HeaderText = "ADM.";
            ADMNo.Name = "ADMNo";
            ADMNo.Width = 69;
            // 
            // StudentName
            // 
            StudentName.HeaderText = "Name Of Student";
            StudentName.Name = "StudentName";
            StudentName.Width = 131;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.Visible = false;
            Column1.Width = 54;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            Column2.Visible = false;
            Column2.Width = 54;
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            Column3.Visible = false;
            Column3.Width = 54;
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            Column4.Visible = false;
            Column4.Width = 54;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, LayoutControlItem4, LayoutControlItem3, LayoutControlItem5, LayoutControlItem7, LayoutControlItem9, LayoutControlItem10, LayoutControlItem8, LayoutControlItem6, LayoutControlItem12, LayoutControlItem16, LayoutControlItem11, LayoutControlItem15, LayoutControlItem17, LayoutControlItem14, LayoutControlItem13, EmptySpaceItem1, EmptySpaceItem4 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(1259, 619);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _dgvEnterMarks;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(1233, 460);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = Pbar;
            LayoutControlItem2.Location = new Point(0, 460);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(994, 33);
            LayoutControlItem2.TextSize = new Size(0, 0);
            LayoutControlItem2.TextVisible = false;
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = chkSplit;
            LayoutControlItem4.Location = new Point(997, 493);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(236, 50);
            LayoutControlItem4.TextSize = new Size(0, 0);
            LayoutControlItem4.TextVisible = false;
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _Button4;
            LayoutControlItem3.Location = new Point(1019, 460);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(214, 33);
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = _chkMode;
            LayoutControlItem5.Location = new Point(619, 493);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(153, 50);
            LayoutControlItem5.TextSize = new Size(0, 0);
            LayoutControlItem5.TextVisible = false;
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = _btnGrade;
            LayoutControlItem7.Location = new Point(0, 493);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(147, 50);
            LayoutControlItem7.TextSize = new Size(0, 0);
            LayoutControlItem7.TextVisible = false;
            // 
            // LayoutControlItem9
            // 
            LayoutControlItem9.Control = _Button3;
            LayoutControlItem9.Location = new Point(310, 493);
            LayoutControlItem9.Name = "LayoutControlItem9";
            LayoutControlItem9.Size = new Size(144, 50);
            LayoutControlItem9.TextSize = new Size(0, 0);
            LayoutControlItem9.TextVisible = false;
            // 
            // LayoutControlItem10
            // 
            LayoutControlItem10.Control = _Button6;
            LayoutControlItem10.Location = new Point(147, 493);
            LayoutControlItem10.Name = "LayoutControlItem10";
            LayoutControlItem10.Size = new Size(163, 50);
            LayoutControlItem10.TextSize = new Size(0, 0);
            LayoutControlItem10.TextVisible = false;
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = _btnReload;
            LayoutControlItem8.Location = new Point(454, 493);
            LayoutControlItem8.Name = "LayoutControlItem8";
            LayoutControlItem8.Size = new Size(165, 50);
            LayoutControlItem8.TextSize = new Size(0, 0);
            LayoutControlItem8.TextVisible = false;
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = _radSubject;
            LayoutControlItem6.Location = new Point(772, 493);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(225, 50);
            LayoutControlItem6.TextSize = new Size(0, 0);
            LayoutControlItem6.TextVisible = false;
            // 
            // LayoutControlItem12
            // 
            LayoutControlItem12.Control = _btnCancel;
            LayoutControlItem12.Location = new Point(1169, 543);
            LayoutControlItem12.Name = "LayoutControlItem12";
            LayoutControlItem12.Size = new Size(64, 50);
            LayoutControlItem12.TextSize = new Size(0, 0);
            LayoutControlItem12.TextVisible = false;
            // 
            // LayoutControlItem16
            // 
            LayoutControlItem16.Control = _btnViewReport;
            LayoutControlItem16.Location = new Point(0, 543);
            LayoutControlItem16.Name = "LayoutControlItem16";
            LayoutControlItem16.Size = new Size(147, 50);
            LayoutControlItem16.TextSize = new Size(0, 0);
            LayoutControlItem16.TextVisible = false;
            // 
            // LayoutControlItem11
            // 
            LayoutControlItem11.Control = _Button1;
            LayoutControlItem11.Location = new Point(306, 543);
            LayoutControlItem11.Name = "LayoutControlItem11";
            LayoutControlItem11.Size = new Size(148, 50);
            LayoutControlItem11.TextSize = new Size(0, 0);
            LayoutControlItem11.TextVisible = false;
            // 
            // LayoutControlItem15
            // 
            LayoutControlItem15.Control = _btnClassPerformance;
            LayoutControlItem15.Location = new Point(454, 543);
            LayoutControlItem15.Name = "LayoutControlItem15";
            LayoutControlItem15.Size = new Size(165, 50);
            LayoutControlItem15.TextSize = new Size(0, 0);
            LayoutControlItem15.TextVisible = false;
            // 
            // LayoutControlItem17
            // 
            LayoutControlItem17.Control = _Button2;
            LayoutControlItem17.Location = new Point(147, 543);
            LayoutControlItem17.Name = "LayoutControlItem17";
            LayoutControlItem17.Size = new Size(159, 50);
            LayoutControlItem17.TextSize = new Size(0, 0);
            LayoutControlItem17.TextVisible = false;
            // 
            // LayoutControlItem14
            // 
            LayoutControlItem14.Control = _Button5;
            LayoutControlItem14.Location = new Point(772, 543);
            LayoutControlItem14.Name = "LayoutControlItem14";
            LayoutControlItem14.Size = new Size(229, 50);
            LayoutControlItem14.TextSize = new Size(0, 0);
            LayoutControlItem14.TextVisible = false;
            // 
            // LayoutControlItem13
            // 
            LayoutControlItem13.Control = _btnStreamPerformance;
            LayoutControlItem13.Location = new Point(619, 543);
            LayoutControlItem13.Name = "LayoutControlItem13";
            LayoutControlItem13.Size = new Size(153, 50);
            LayoutControlItem13.TextSize = new Size(0, 0);
            LayoutControlItem13.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(994, 460);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(25, 33);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem4
            // 
            EmptySpaceItem4.AllowHotTrack = false;
            EmptySpaceItem4.Location = new Point(1001, 543);
            EmptySpaceItem4.Name = "EmptySpaceItem4";
            EmptySpaceItem4.Size = new Size(168, 50);
            EmptySpaceItem4.TextSize = new Size(0, 0);
            // 
            // Timer1
            // 
            // 
            // Timer2
            // 
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
            // frmResults
            // 
            AutoScaleDimensions = new SizeF(7.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 619);
            Controls.Add(LayoutControl1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmResults";
            Text = "Examination Result Analysis";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvEnterMarks).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem12).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem16).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem15).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem17).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem14).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem13).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).EndInit();
            Load += new EventHandler(frmResults_Load);
            Shown += new EventHandler(frmResults_Shown);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
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
                    _Button2.Click -= Button2_Click_1;
                }

                _Button2 = value;
                if (_Button2 != null)
                {
                    _Button2.Click += Button2_Click_1;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _btnViewReport;

        internal DevExpress.XtraEditors.SimpleButton btnViewReport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnViewReport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnViewReport != null)
                {
                    _btnViewReport.Click -= Button2_Click;
                }

                _btnViewReport = value;
                if (_btnViewReport != null)
                {
                    _btnViewReport.Click += Button2_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _btnClassPerformance;

        internal DevExpress.XtraEditors.SimpleButton btnClassPerformance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClassPerformance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClassPerformance != null)
                {
                    _btnClassPerformance.Click -= btnClassPerformance_Click;
                }

                _btnClassPerformance = value;
                if (_btnClassPerformance != null)
                {
                    _btnClassPerformance.Click += btnClassPerformance_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _Button5;

        internal DevExpress.XtraEditors.SimpleButton Button5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button5 != null)
                {
                    _Button5.Click -= Button5_Click;
                }

                _Button5 = value;
                if (_Button5 != null)
                {
                    _Button5.Click += Button5_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _btnStreamPerformance;

        internal DevExpress.XtraEditors.SimpleButton btnStreamPerformance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnStreamPerformance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnStreamPerformance != null)
                {
                    _btnStreamPerformance.Click -= btnStreamPerformance_Click;
                }

                _btnStreamPerformance = value;
                if (_btnStreamPerformance != null)
                {
                    _btnStreamPerformance.Click += btnStreamPerformance_Click;
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
                    _Button1.Click -= Button1_Click_1;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click_1;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _Button6;

        internal DevExpress.XtraEditors.SimpleButton Button6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button6 != null)
                {
                    _Button6.Click -= Button6_Click;
                }

                _Button6 = value;
                if (_Button6 != null)
                {
                    _Button6.Click += Button6_Click;
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
                    _Button3.Click -= Button3_Click_1;
                }

                _Button3 = value;
                if (_Button3 != null)
                {
                    _Button3.Click += Button3_Click_1;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _btnReload;

        internal DevExpress.XtraEditors.SimpleButton btnReload
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReload;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReload != null)
                {
                    _btnReload.Click -= btnReload_Click;
                }

                _btnReload = value;
                if (_btnReload != null)
                {
                    _btnReload.Click += btnReload_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _btnGrade;

        internal DevExpress.XtraEditors.SimpleButton btnGrade
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGrade;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGrade != null)
                {
                    _btnGrade.Click -= btnGrade_Click;
                }

                _btnGrade = value;
                if (_btnGrade != null)
                {
                    _btnGrade.Click += btnGrade_Click;
                }
            }
        }

        private CheckBox _radSubject;

        internal CheckBox radSubject
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radSubject;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radSubject != null)
                {
                    _radSubject.CheckedChanged -= radSubject_CheckedChanged;
                }

                _radSubject = value;
                if (_radSubject != null)
                {
                    _radSubject.CheckedChanged += radSubject_CheckedChanged;
                }
            }
        }

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
                    _chkMode.CheckedChanged -= chkmode_CheckedChanged;
                }

                _chkMode = value;
                if (_chkMode != null)
                {
                    _chkMode.CheckedChanged += chkmode_CheckedChanged;
                }
            }
        }

        internal CheckBox chkSplit;
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
                    _Button4.Click -= Button4_Click_1;
                }

                _Button4 = value;
                if (_Button4 != null)
                {
                    _Button4.Click += Button4_Click_1;
                }
            }
        }

        internal ProgressBar Pbar;
        private DataGridView _dgvEnterMarks;

        internal DataGridView dgvEnterMarks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvEnterMarks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvEnterMarks != null)
                {
                    _dgvEnterMarks.RowsAdded -= dgvEnterMarks_RowsAdded;
                }

                _dgvEnterMarks = value;
                if (_dgvEnterMarks != null)
                {
                    _dgvEnterMarks.RowsAdded += dgvEnterMarks_RowsAdded;
                }
            }
        }

        internal DataGridViewTextBoxColumn ADMNo;
        internal DataGridViewTextBoxColumn StudentName;
        internal DataGridViewImageColumn Column1;
        internal DataGridViewImageColumn Column2;
        internal DataGridViewImageColumn Column3;
        internal DataGridViewImageColumn Column4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem9;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem10;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem12;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem16;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem11;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem15;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem17;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem14;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem13;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        private Timer _Timer1;

        internal Timer Timer1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Timer1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Timer1 != null)
                {
                    _Timer1.Tick -= Timer1_Tick;
                }

                _Timer1 = value;
                if (_Timer1 != null)
                {
                    _Timer1.Tick += Timer1_Tick;
                }
            }
        }

        private Timer _Timer2;

        internal Timer Timer2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Timer2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Timer2 != null)
                {
                    _Timer2.Tick -= Timer2_Tick;
                }

                _Timer2 = value;
                if (_Timer2 != null)
                {
                    _Timer2.Tick += Timer2_Tick;
                }
            }
        }

        internal PrintPreviewDialog printpreview;
        internal SaveFileDialog SaveFileDialog1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem4;
    }
}