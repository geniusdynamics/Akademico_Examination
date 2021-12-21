using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmSubjectBasedGrading : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectBasedGrading));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            btnClear = new DevExpress.XtraEditors.SimpleButton();
            _btnSave = new DevExpress.XtraEditors.SimpleButton();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _cboClass = new ComboBox();
            _cboClass.SelectedIndexChanged += new EventHandler(cboClass_SelectedIndexChanged);
            _cboYear = new ComboBox();
            _cboYear.SelectedIndexChanged += new EventHandler(cboYear_SelectedIndexChanged);
            _cboTerm = new ComboBox();
            _cboTerm.SelectedIndexChanged += new EventHandler(cboTerm_SelectedIndexChanged);
            _cboSubject = new ComboBox();
            _cboSubject.SelectedIndexChanged += new EventHandler(cboSubject_SelectedIndexChanged);
            txtCComment = new TextBox();
            txtCstart = new TextBox();
            txtAComment = new TextBox();
            txtAstart = new TextBox();
            txtCMinusComment = new TextBox();
            txtCminstart = new TextBox();
            txtAMinusComment = new TextBox();
            txtAminstart = new TextBox();
            txtDPlusComment = new TextBox();
            txtDplusstart = new TextBox();
            txtBPlusComment = new TextBox();
            txtBplusstart = new TextBox();
            txtDComment = new TextBox();
            txtDstart = new TextBox();
            txtBComment = new TextBox();
            txtBstart = new TextBox();
            txtDMinusComment = new TextBox();
            txtDminstart = new TextBox();
            txtBMinusComment = new TextBox();
            txtBminstart = new TextBox();
            txtEComment = new TextBox();
            txtEstart = new TextBox();
            txtCPlusComment = new TextBox();
            txtCplusstart = new TextBox();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem18).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem19).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem20).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem22).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem23).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem24).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem25).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem26).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem27).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem28).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem29).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem30).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(btnClear);
            LayoutControl1.Controls.Add(_btnSave);
            LayoutControl1.Controls.Add(_cboClass);
            LayoutControl1.Controls.Add(_cboYear);
            LayoutControl1.Controls.Add(_cboTerm);
            LayoutControl1.Controls.Add(_cboSubject);
            LayoutControl1.Controls.Add(txtCComment);
            LayoutControl1.Controls.Add(txtCstart);
            LayoutControl1.Controls.Add(txtAComment);
            LayoutControl1.Controls.Add(txtAstart);
            LayoutControl1.Controls.Add(txtCMinusComment);
            LayoutControl1.Controls.Add(txtCminstart);
            LayoutControl1.Controls.Add(txtAMinusComment);
            LayoutControl1.Controls.Add(txtAminstart);
            LayoutControl1.Controls.Add(txtDPlusComment);
            LayoutControl1.Controls.Add(txtDplusstart);
            LayoutControl1.Controls.Add(txtBPlusComment);
            LayoutControl1.Controls.Add(txtBplusstart);
            LayoutControl1.Controls.Add(txtDComment);
            LayoutControl1.Controls.Add(txtDstart);
            LayoutControl1.Controls.Add(txtBComment);
            LayoutControl1.Controls.Add(txtBstart);
            LayoutControl1.Controls.Add(txtDMinusComment);
            LayoutControl1.Controls.Add(txtDminstart);
            LayoutControl1.Controls.Add(txtBMinusComment);
            LayoutControl1.Controls.Add(txtBminstart);
            LayoutControl1.Controls.Add(txtEComment);
            LayoutControl1.Controls.Add(txtEstart);
            LayoutControl1.Controls.Add(txtCPlusComment);
            LayoutControl1.Controls.Add(txtCplusstart);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(465, 301, 250, 350);
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(975, 499);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // btnClear
            // 
            btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            btnClear.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            btnClear.Location = new Point(888, 192);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(36, 39);
            btnClear.StyleController = LayoutControl1;
            btnClear.TabIndex = 14;
            btnClear.Text = "Clear";
            // 
            // btnSave
            // 
            _btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            _btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnSave.Location = new Point(928, 192);
            _btnSave.Name = "_btnSave";
            _btnSave.Size = new Size(35, 39);
            _btnSave.StyleController = LayoutControl1;
            _btnSave.TabIndex = 13;
            _btnSave.Text = "Save";
            // 
            // cboClass
            // 
            _cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboClass.FormattingEnabled = true;
            _cboClass.Location = new Point(515, 12);
            _cboClass.Name = "_cboClass";
            _cboClass.Size = new Size(187, 21);
            _cboClass.TabIndex = 7;
            // 
            // cboYear
            // 
            _cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear.FormattingEnabled = true;
            _cboYear.Location = new Point(83, 12);
            _cboYear.Name = "_cboYear";
            _cboYear.Size = new Size(147, 21);
            _cboYear.TabIndex = 6;
            // 
            // cboTerm
            // 
            _cboTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerm.FormattingEnabled = true;
            _cboTerm.Items.AddRange(new object[] { "None", "I", "II", "III" });
            _cboTerm.Location = new Point(305, 12);
            _cboTerm.Name = "_cboTerm";
            _cboTerm.Size = new Size(135, 21);
            _cboTerm.TabIndex = 5;
            // 
            // cboSubject
            // 
            _cboSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSubject.FormattingEnabled = true;
            _cboSubject.Location = new Point(777, 12);
            _cboSubject.Name = "_cboSubject";
            _cboSubject.Size = new Size(186, 21);
            _cboSubject.TabIndex = 4;
            // 
            // txtCComment
            // 
            txtCComment.Location = new Point(724, 48);
            txtCComment.Name = "txtCComment";
            txtCComment.Size = new Size(239, 20);
            txtCComment.TabIndex = 8;
            // 
            // txtCstart
            // 
            txtCstart.Location = new Point(539, 48);
            txtCstart.Name = "txtCstart";
            txtCstart.Size = new Size(110, 20);
            txtCstart.TabIndex = 9;
            // 
            // txtAComment
            // 
            txtAComment.Location = new Point(272, 48);
            txtAComment.Name = "txtAComment";
            txtAComment.Size = new Size(192, 20);
            txtAComment.TabIndex = 10;
            // 
            // txtAstart
            // 
            txtAstart.Location = new Point(83, 48);
            txtAstart.Name = "txtAstart";
            txtAstart.Size = new Size(114, 20);
            txtAstart.TabIndex = 11;
            // 
            // txtCMinusComment
            // 
            txtCMinusComment.Location = new Point(725, 72);
            txtCMinusComment.Name = "txtCMinusComment";
            txtCMinusComment.Size = new Size(238, 20);
            txtCMinusComment.TabIndex = 8;
            // 
            // txtCminstart
            // 
            txtCminstart.Location = new Point(539, 72);
            txtCminstart.Name = "txtCminstart";
            txtCminstart.Size = new Size(111, 20);
            txtCminstart.TabIndex = 9;
            // 
            // txtAMinusComment
            // 
            txtAMinusComment.Location = new Point(272, 72);
            txtAMinusComment.Name = "txtAMinusComment";
            txtAMinusComment.Size = new Size(192, 20);
            txtAMinusComment.TabIndex = 10;
            // 
            // txtAminstart
            // 
            txtAminstart.Location = new Point(83, 72);
            txtAminstart.Name = "txtAminstart";
            txtAminstart.Size = new Size(114, 20);
            txtAminstart.TabIndex = 11;
            // 
            // txtDPlusComment
            // 
            txtDPlusComment.Location = new Point(726, 96);
            txtDPlusComment.Name = "txtDPlusComment";
            txtDPlusComment.Size = new Size(237, 20);
            txtDPlusComment.TabIndex = 8;
            // 
            // txtDplusstart
            // 
            txtDplusstart.Location = new Point(537, 96);
            txtDplusstart.Name = "txtDplusstart";
            txtDplusstart.Size = new Size(114, 20);
            txtDplusstart.TabIndex = 9;
            // 
            // txtBPlusComment
            // 
            txtBPlusComment.Location = new Point(272, 96);
            txtBPlusComment.Name = "txtBPlusComment";
            txtBPlusComment.Size = new Size(190, 20);
            txtBPlusComment.TabIndex = 10;
            // 
            // txtBplusstart
            // 
            txtBplusstart.Location = new Point(83, 96);
            txtBplusstart.Name = "txtBplusstart";
            txtBplusstart.Size = new Size(114, 20);
            txtBplusstart.TabIndex = 11;
            // 
            // txtDComment
            // 
            txtDComment.Location = new Point(727, 120);
            txtDComment.Name = "txtDComment";
            txtDComment.Size = new Size(236, 20);
            txtDComment.TabIndex = 8;
            // 
            // txtDstart
            // 
            txtDstart.Location = new Point(539, 120);
            txtDstart.Name = "txtDstart";
            txtDstart.Size = new Size(113, 20);
            txtDstart.TabIndex = 9;
            // 
            // txtBComment
            // 
            txtBComment.Location = new Point(272, 120);
            txtBComment.Name = "txtBComment";
            txtBComment.Size = new Size(192, 20);
            txtBComment.TabIndex = 10;
            // 
            // txtBstart
            // 
            txtBstart.Location = new Point(83, 120);
            txtBstart.Name = "txtBstart";
            txtBstart.Size = new Size(114, 20);
            txtBstart.TabIndex = 11;
            // 
            // txtDMinusComment
            // 
            txtDMinusComment.Location = new Point(728, 144);
            txtDMinusComment.Name = "txtDMinusComment";
            txtDMinusComment.Size = new Size(235, 20);
            txtDMinusComment.TabIndex = 8;
            // 
            // txtDminstart
            // 
            txtDminstart.Location = new Point(538, 144);
            txtDminstart.Name = "txtDminstart";
            txtDminstart.Size = new Size(115, 20);
            txtDminstart.TabIndex = 9;
            // 
            // txtBMinusComment
            // 
            txtBMinusComment.Location = new Point(272, 144);
            txtBMinusComment.Name = "txtBMinusComment";
            txtBMinusComment.Size = new Size(191, 20);
            txtBMinusComment.TabIndex = 10;
            // 
            // txtBminstart
            // 
            txtBminstart.Location = new Point(83, 144);
            txtBminstart.Name = "txtBminstart";
            txtBminstart.Size = new Size(114, 20);
            txtBminstart.TabIndex = 11;
            // 
            // txtEComment
            // 
            txtEComment.Location = new Point(729, 168);
            txtEComment.Name = "txtEComment";
            txtEComment.Size = new Size(234, 20);
            txtEComment.TabIndex = 8;
            // 
            // txtEstart
            // 
            txtEstart.Location = new Point(539, 168);
            txtEstart.Name = "txtEstart";
            txtEstart.Size = new Size(115, 20);
            txtEstart.TabIndex = 9;
            // 
            // txtCPlusComment
            // 
            txtCPlusComment.Location = new Point(272, 168);
            txtCPlusComment.Name = "txtCPlusComment";
            txtCPlusComment.Size = new Size(192, 20);
            txtCPlusComment.TabIndex = 10;
            // 
            // txtCplusstart
            // 
            txtCplusstart.Location = new Point(83, 168);
            txtCplusstart.Name = "txtCplusstart";
            txtCplusstart.Size = new Size(114, 20);
            txtCplusstart.TabIndex = 11;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem4, LayoutControlItem2, LayoutControlItem3, EmptySpaceItem2, LayoutControlItem5, LayoutControlItem6, LayoutControlItem7, LayoutControlItem8, LayoutControlItem9, LayoutControlItem10, LayoutControlItem11, LayoutControlItem12, LayoutControlItem13, LayoutControlItem14, LayoutControlItem15, LayoutControlItem16, LayoutControlItem17, LayoutControlItem18, LayoutControlItem19, LayoutControlItem20, LayoutControlItem21, LayoutControlItem22, LayoutControlItem23, LayoutControlItem24, LayoutControlItem25, LayoutControlItem26, LayoutControlItem27, LayoutControlItem28, EmptySpaceItem7, EmptySpaceItem8, LayoutControlItem29, LayoutControlItem30 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(975, 499);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _cboSubject;
            LayoutControlItem1.Location = new Point(694, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(261, 25);
            LayoutControlItem1.Text = "Select Subject";
            LayoutControlItem1.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _cboClass;
            LayoutControlItem4.Location = new Point(432, 0);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(262, 25);
            LayoutControlItem4.Text = "Select Class";
            LayoutControlItem4.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _cboTerm;
            LayoutControlItem2.Location = new Point(222, 0);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(210, 25);
            LayoutControlItem2.Text = "Term";
            LayoutControlItem2.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _cboYear;
            LayoutControlItem3.Location = new Point(0, 0);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(222, 25);
            LayoutControlItem3.Text = "Year";
            LayoutControlItem3.TextSize = new Size(68, 13);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 25);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(955, 11);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = txtCComment;
            LayoutControlItem5.CustomizationFormText = "% Comment";
            LayoutControlItem5.Location = new Point(641, 36);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(314, 24);
            LayoutControlItem5.Text = "% Comment";
            LayoutControlItem5.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = txtCstart;
            LayoutControlItem6.CustomizationFormText = "C From";
            LayoutControlItem6.Location = new Point(456, 36);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(185, 24);
            LayoutControlItem6.Text = "C From";
            LayoutControlItem6.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = txtAComment;
            LayoutControlItem7.CustomizationFormText = "% Comment";
            LayoutControlItem7.Location = new Point(189, 36);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(267, 24);
            LayoutControlItem7.Text = "% Comment";
            LayoutControlItem7.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = txtAstart;
            LayoutControlItem8.CustomizationFormText = "A From";
            LayoutControlItem8.Location = new Point(0, 36);
            LayoutControlItem8.Name = "LayoutControlItem8";
            LayoutControlItem8.Size = new Size(189, 24);
            LayoutControlItem8.Text = "A From";
            LayoutControlItem8.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem9
            // 
            LayoutControlItem9.Control = txtCMinusComment;
            LayoutControlItem9.CustomizationFormText = "LayoutControlItem2";
            LayoutControlItem9.Location = new Point(642, 60);
            LayoutControlItem9.Name = "LayoutControlItem9";
            LayoutControlItem9.Size = new Size(313, 24);
            LayoutControlItem9.Text = "% Comment";
            LayoutControlItem9.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem10
            // 
            LayoutControlItem10.Control = txtCminstart;
            LayoutControlItem10.CustomizationFormText = "LayoutControlItem5";
            LayoutControlItem10.Location = new Point(456, 60);
            LayoutControlItem10.Name = "LayoutControlItem10";
            LayoutControlItem10.Size = new Size(186, 24);
            LayoutControlItem10.Text = "C- From";
            LayoutControlItem10.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem11
            // 
            LayoutControlItem11.Control = txtAMinusComment;
            LayoutControlItem11.CustomizationFormText = "LayoutControlItem6";
            LayoutControlItem11.Location = new Point(189, 60);
            LayoutControlItem11.Name = "LayoutControlItem11";
            LayoutControlItem11.Size = new Size(267, 24);
            LayoutControlItem11.Text = "% Comment";
            LayoutControlItem11.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem12
            // 
            LayoutControlItem12.Control = txtAminstart;
            LayoutControlItem12.CustomizationFormText = "LayoutControlItem7";
            LayoutControlItem12.Location = new Point(0, 60);
            LayoutControlItem12.Name = "LayoutControlItem12";
            LayoutControlItem12.Size = new Size(189, 24);
            LayoutControlItem12.Text = "A- From";
            LayoutControlItem12.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem13
            // 
            LayoutControlItem13.Control = txtDPlusComment;
            LayoutControlItem13.CustomizationFormText = "LayoutControlItem2";
            LayoutControlItem13.Location = new Point(643, 84);
            LayoutControlItem13.Name = "LayoutControlItem13";
            LayoutControlItem13.Size = new Size(312, 24);
            LayoutControlItem13.Text = "% Comment";
            LayoutControlItem13.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem14
            // 
            LayoutControlItem14.Control = txtDplusstart;
            LayoutControlItem14.CustomizationFormText = "LayoutControlItem5";
            LayoutControlItem14.Location = new Point(454, 84);
            LayoutControlItem14.Name = "LayoutControlItem14";
            LayoutControlItem14.Size = new Size(189, 24);
            LayoutControlItem14.Text = "D+ From";
            LayoutControlItem14.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem15
            // 
            LayoutControlItem15.Control = txtBPlusComment;
            LayoutControlItem15.CustomizationFormText = "LayoutControlItem6";
            LayoutControlItem15.Location = new Point(189, 84);
            LayoutControlItem15.Name = "LayoutControlItem15";
            LayoutControlItem15.Size = new Size(265, 24);
            LayoutControlItem15.Text = "% Comment";
            LayoutControlItem15.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem16
            // 
            LayoutControlItem16.Control = txtBplusstart;
            LayoutControlItem16.CustomizationFormText = "LayoutControlItem7";
            LayoutControlItem16.Location = new Point(0, 84);
            LayoutControlItem16.Name = "LayoutControlItem16";
            LayoutControlItem16.Size = new Size(189, 24);
            LayoutControlItem16.Text = "B+ From";
            LayoutControlItem16.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem17
            // 
            LayoutControlItem17.Control = txtDComment;
            LayoutControlItem17.CustomizationFormText = "LayoutControlItem2";
            LayoutControlItem17.Location = new Point(644, 108);
            LayoutControlItem17.Name = "LayoutControlItem17";
            LayoutControlItem17.Size = new Size(311, 24);
            LayoutControlItem17.Text = "% Comment";
            LayoutControlItem17.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem18
            // 
            LayoutControlItem18.Control = txtDstart;
            LayoutControlItem18.CustomizationFormText = "LayoutControlItem5";
            LayoutControlItem18.Location = new Point(456, 108);
            LayoutControlItem18.Name = "LayoutControlItem18";
            LayoutControlItem18.Size = new Size(188, 24);
            LayoutControlItem18.Text = "D From";
            LayoutControlItem18.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem19
            // 
            LayoutControlItem19.Control = txtBComment;
            LayoutControlItem19.CustomizationFormText = "LayoutControlItem6";
            LayoutControlItem19.Location = new Point(189, 108);
            LayoutControlItem19.Name = "LayoutControlItem19";
            LayoutControlItem19.Size = new Size(267, 24);
            LayoutControlItem19.Text = "% Comment";
            LayoutControlItem19.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem20
            // 
            LayoutControlItem20.Control = txtBstart;
            LayoutControlItem20.CustomizationFormText = "LayoutControlItem7";
            LayoutControlItem20.Location = new Point(0, 108);
            LayoutControlItem20.Name = "LayoutControlItem20";
            LayoutControlItem20.Size = new Size(189, 24);
            LayoutControlItem20.Text = "B From";
            LayoutControlItem20.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem21
            // 
            LayoutControlItem21.Control = txtDMinusComment;
            LayoutControlItem21.CustomizationFormText = "LayoutControlItem2";
            LayoutControlItem21.Location = new Point(645, 132);
            LayoutControlItem21.Name = "LayoutControlItem21";
            LayoutControlItem21.Size = new Size(310, 24);
            LayoutControlItem21.Text = "% Comment";
            LayoutControlItem21.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem22
            // 
            LayoutControlItem22.Control = txtDminstart;
            LayoutControlItem22.CustomizationFormText = "LayoutControlItem5";
            LayoutControlItem22.Location = new Point(455, 132);
            LayoutControlItem22.Name = "LayoutControlItem22";
            LayoutControlItem22.Size = new Size(190, 24);
            LayoutControlItem22.Text = "D- From";
            LayoutControlItem22.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem23
            // 
            LayoutControlItem23.Control = txtBMinusComment;
            LayoutControlItem23.CustomizationFormText = "LayoutControlItem6";
            LayoutControlItem23.Location = new Point(189, 132);
            LayoutControlItem23.Name = "LayoutControlItem23";
            LayoutControlItem23.Size = new Size(266, 24);
            LayoutControlItem23.Text = "% Comment";
            LayoutControlItem23.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem24
            // 
            LayoutControlItem24.Control = txtBminstart;
            LayoutControlItem24.CustomizationFormText = "LayoutControlItem7";
            LayoutControlItem24.Location = new Point(0, 132);
            LayoutControlItem24.Name = "LayoutControlItem24";
            LayoutControlItem24.Size = new Size(189, 24);
            LayoutControlItem24.Text = "B- From";
            LayoutControlItem24.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem25
            // 
            LayoutControlItem25.Control = txtEComment;
            LayoutControlItem25.CustomizationFormText = "LayoutControlItem2";
            LayoutControlItem25.Location = new Point(646, 156);
            LayoutControlItem25.Name = "LayoutControlItem25";
            LayoutControlItem25.Size = new Size(309, 24);
            LayoutControlItem25.Text = "% Comment";
            LayoutControlItem25.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem26
            // 
            LayoutControlItem26.Control = txtEstart;
            LayoutControlItem26.CustomizationFormText = "LayoutControlItem5";
            LayoutControlItem26.Location = new Point(456, 156);
            LayoutControlItem26.Name = "LayoutControlItem26";
            LayoutControlItem26.Size = new Size(190, 24);
            LayoutControlItem26.Text = "E From";
            LayoutControlItem26.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem27
            // 
            LayoutControlItem27.Control = txtCPlusComment;
            LayoutControlItem27.CustomizationFormText = "LayoutControlItem6";
            LayoutControlItem27.Location = new Point(189, 156);
            LayoutControlItem27.Name = "LayoutControlItem27";
            LayoutControlItem27.Size = new Size(267, 24);
            LayoutControlItem27.Text = "% Comment";
            LayoutControlItem27.TextSize = new Size(68, 13);
            // 
            // LayoutControlItem28
            // 
            LayoutControlItem28.Control = txtCplusstart;
            LayoutControlItem28.CustomizationFormText = "LayoutControlItem7";
            LayoutControlItem28.Location = new Point(0, 156);
            LayoutControlItem28.Name = "LayoutControlItem28";
            LayoutControlItem28.Size = new Size(189, 24);
            LayoutControlItem28.Text = "C+ From";
            LayoutControlItem28.TextSize = new Size(68, 13);
            // 
            // EmptySpaceItem7
            // 
            EmptySpaceItem7.AllowHotTrack = false;
            EmptySpaceItem7.Location = new Point(0, 180);
            EmptySpaceItem7.Name = "EmptySpaceItem7";
            EmptySpaceItem7.Size = new Size(876, 43);
            EmptySpaceItem7.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem8
            // 
            EmptySpaceItem8.AllowHotTrack = false;
            EmptySpaceItem8.Location = new Point(0, 223);
            EmptySpaceItem8.Name = "EmptySpaceItem8";
            EmptySpaceItem8.Size = new Size(955, 256);
            EmptySpaceItem8.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem29
            // 
            LayoutControlItem29.Control = _btnSave;
            LayoutControlItem29.Location = new Point(916, 180);
            LayoutControlItem29.Name = "LayoutControlItem29";
            LayoutControlItem29.Size = new Size(39, 43);
            LayoutControlItem29.TextSize = new Size(0, 0);
            LayoutControlItem29.TextVisible = false;
            // 
            // LayoutControlItem30
            // 
            LayoutControlItem30.Control = btnClear;
            LayoutControlItem30.Location = new Point(876, 180);
            LayoutControlItem30.Name = "LayoutControlItem30";
            LayoutControlItem30.Size = new Size(40, 43);
            LayoutControlItem30.TextSize = new Size(0, 0);
            LayoutControlItem30.TextVisible = false;
            // 
            // frmSubjectBasedGrading
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 499);
            Controls.Add(LayoutControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSubjectBasedGrading";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subject Based Grading";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem11).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem12).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem13).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem14).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem15).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem16).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem17).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem18).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem19).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem20).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem21).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem22).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem23).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem24).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem25).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem26).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem27).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem28).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem29).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem30).EndInit();
            Load += new EventHandler(frmSubjectBasedGrading_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
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
                    _cboTerm.SelectedIndexChanged -= cboTerm_SelectedIndexChanged;
                }

                _cboTerm = value;
                if (_cboTerm != null)
                {
                    _cboTerm.SelectedIndexChanged += cboTerm_SelectedIndexChanged;
                }
            }
        }

        private ComboBox _cboSubject;

        internal ComboBox cboSubject
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSubject;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSubject != null)
                {
                    _cboSubject.SelectedIndexChanged -= cboSubject_SelectedIndexChanged;
                }

                _cboSubject = value;
                if (_cboSubject != null)
                {
                    _cboSubject.SelectedIndexChanged += cboSubject_SelectedIndexChanged;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal TextBox txtCComment;
        internal TextBox txtCstart;
        internal TextBox txtAComment;
        internal TextBox txtAstart;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
        internal TextBox txtCMinusComment;
        internal TextBox txtCminstart;
        internal TextBox txtAMinusComment;
        internal TextBox txtAminstart;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem9;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem10;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem11;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem12;
        internal TextBox txtDPlusComment;
        internal TextBox txtDplusstart;
        internal TextBox txtBPlusComment;
        internal TextBox txtBplusstart;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem13;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem14;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem15;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem16;
        internal TextBox txtDComment;
        internal TextBox txtDstart;
        internal TextBox txtBComment;
        internal TextBox txtBstart;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem17;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem18;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem19;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem20;
        internal TextBox txtDMinusComment;
        internal TextBox txtDminstart;
        internal TextBox txtBMinusComment;
        internal TextBox txtBminstart;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem21;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem22;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem23;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem24;
        internal TextBox txtEComment;
        internal TextBox txtEstart;
        internal TextBox txtCPlusComment;
        internal TextBox txtCplusstart;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem25;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem26;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem27;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem28;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem7;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem8;
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

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem29;
        internal DevExpress.XtraEditors.SimpleButton btnClear;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem30;
    }
}