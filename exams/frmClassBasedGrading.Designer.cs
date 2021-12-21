using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmClassBasedGrading : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassBasedGrading));
            LayoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            _btnClear = new DevExpress.XtraEditors.SimpleButton();
            _btnClear.Click += new EventHandler(btnClear_Click);
            _btnSave = new DevExpress.XtraEditors.SimpleButton();
            _btnSave.Click += new EventHandler(btnSave_Click);
            txtAstart = new TextBox();
            txtAComment = new TextBox();
            txtCstart = new TextBox();
            txtCComment = new TextBox();
            cboTerm = new ComboBox();
            _cboClass = new ComboBox();
            _cboClass.SelectedIndexChanged += new EventHandler(cboClass_SelectedIndexChanged);
            cboYear = new ComboBox();
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
            LayoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
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
            EmptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl2).BeginInit();
            LayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem28).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem29).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl2
            // 
            LayoutControl2.Controls.Add(_btnClear);
            LayoutControl2.Controls.Add(_btnSave);
            LayoutControl2.Controls.Add(txtAstart);
            LayoutControl2.Controls.Add(txtAComment);
            LayoutControl2.Controls.Add(txtCstart);
            LayoutControl2.Controls.Add(txtCComment);
            LayoutControl2.Controls.Add(cboTerm);
            LayoutControl2.Controls.Add(_cboClass);
            LayoutControl2.Controls.Add(cboYear);
            LayoutControl2.Controls.Add(txtCMinusComment);
            LayoutControl2.Controls.Add(txtCminstart);
            LayoutControl2.Controls.Add(txtAMinusComment);
            LayoutControl2.Controls.Add(txtAminstart);
            LayoutControl2.Controls.Add(txtDPlusComment);
            LayoutControl2.Controls.Add(txtDplusstart);
            LayoutControl2.Controls.Add(txtBPlusComment);
            LayoutControl2.Controls.Add(txtBplusstart);
            LayoutControl2.Controls.Add(txtDComment);
            LayoutControl2.Controls.Add(txtDstart);
            LayoutControl2.Controls.Add(txtBComment);
            LayoutControl2.Controls.Add(txtBstart);
            LayoutControl2.Controls.Add(txtDMinusComment);
            LayoutControl2.Controls.Add(txtDminstart);
            LayoutControl2.Controls.Add(txtBMinusComment);
            LayoutControl2.Controls.Add(txtBminstart);
            LayoutControl2.Controls.Add(txtEComment);
            LayoutControl2.Controls.Add(txtEstart);
            LayoutControl2.Controls.Add(txtCPlusComment);
            LayoutControl2.Controls.Add(txtCplusstart);
            LayoutControl2.Dock = DockStyle.Fill;
            LayoutControl2.Location = new Point(0, 0);
            LayoutControl2.Name = "LayoutControl2";
            LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(467, 297, 250, 350);
            LayoutControl2.Root = LayoutControlGroup2;
            LayoutControl2.Size = new Size(973, 431);
            LayoutControl2.TabIndex = 1;
            LayoutControl2.Text = "LayoutControl2";
            // 
            // btnClear
            // 
            _btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            _btnClear.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnClear.Location = new Point(869, 191);
            _btnClear.Name = "_btnClear";
            _btnClear.Size = new Size(44, 39);
            _btnClear.StyleController = LayoutControl2;
            _btnClear.TabIndex = 13;
            _btnClear.Text = "Clear";
            // 
            // btnSave
            // 
            _btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            _btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnSave.Location = new Point(917, 191);
            _btnSave.Name = "_btnSave";
            _btnSave.Size = new Size(44, 39);
            _btnSave.StyleController = LayoutControl2;
            _btnSave.TabIndex = 12;
            _btnSave.Text = "Save";
            // 
            // txtAstart
            // 
            txtAstart.Location = new Point(74, 47);
            txtAstart.Name = "txtAstart";
            txtAstart.Size = new Size(122, 20);
            txtAstart.TabIndex = 11;
            // 
            // txtAComment
            // 
            txtAComment.Location = new Point(262, 47);
            txtAComment.Name = "txtAComment";
            txtAComment.Size = new Size(201, 20);
            txtAComment.TabIndex = 10;
            // 
            // txtCstart
            // 
            txtCstart.Location = new Point(529, 47);
            txtCstart.Name = "txtCstart";
            txtCstart.Size = new Size(123, 20);
            txtCstart.TabIndex = 9;
            // 
            // txtCComment
            // 
            txtCComment.Location = new Point(718, 47);
            txtCComment.Name = "txtCComment";
            txtCComment.Size = new Size(243, 20);
            txtCComment.TabIndex = 8;
            // 
            // cboTerm
            // 
            cboTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTerm.FormattingEnabled = true;
            cboTerm.Items.AddRange(new object[] { "None", "I", "II", "III" });
            cboTerm.Location = new Point(366, 12);
            cboTerm.Name = "cboTerm";
            cboTerm.Size = new Size(250, 21);
            cboTerm.TabIndex = 7;
            // 
            // cboClass
            // 
            _cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboClass.FormattingEnabled = true;
            _cboClass.Location = new Point(682, 12);
            _cboClass.Name = "_cboClass";
            _cboClass.Size = new Size(279, 21);
            _cboClass.TabIndex = 6;
            // 
            // cboYear
            // 
            cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cboYear.FormattingEnabled = true;
            cboYear.Location = new Point(74, 12);
            cboYear.Name = "cboYear";
            cboYear.Size = new Size(226, 21);
            cboYear.TabIndex = 4;
            // 
            // txtCMinusComment
            // 
            txtCMinusComment.Location = new Point(718, 71);
            txtCMinusComment.Name = "txtCMinusComment";
            txtCMinusComment.Size = new Size(243, 20);
            txtCMinusComment.TabIndex = 8;
            // 
            // txtCminstart
            // 
            txtCminstart.Location = new Point(529, 71);
            txtCminstart.Name = "txtCminstart";
            txtCminstart.Size = new Size(123, 20);
            txtCminstart.TabIndex = 9;
            // 
            // txtAMinusComment
            // 
            txtAMinusComment.Location = new Point(262, 71);
            txtAMinusComment.Name = "txtAMinusComment";
            txtAMinusComment.Size = new Size(201, 20);
            txtAMinusComment.TabIndex = 10;
            // 
            // txtAminstart
            // 
            txtAminstart.Location = new Point(74, 71);
            txtAminstart.Name = "txtAminstart";
            txtAminstart.Size = new Size(122, 20);
            txtAminstart.TabIndex = 11;
            // 
            // txtDPlusComment
            // 
            txtDPlusComment.Location = new Point(718, 95);
            txtDPlusComment.Name = "txtDPlusComment";
            txtDPlusComment.Size = new Size(243, 20);
            txtDPlusComment.TabIndex = 8;
            // 
            // txtDplusstart
            // 
            txtDplusstart.Location = new Point(529, 95);
            txtDplusstart.Name = "txtDplusstart";
            txtDplusstart.Size = new Size(123, 20);
            txtDplusstart.TabIndex = 9;
            // 
            // txtBPlusComment
            // 
            txtBPlusComment.Location = new Point(262, 95);
            txtBPlusComment.Name = "txtBPlusComment";
            txtBPlusComment.Size = new Size(201, 20);
            txtBPlusComment.TabIndex = 10;
            // 
            // txtBplusstart
            // 
            txtBplusstart.Location = new Point(74, 95);
            txtBplusstart.Name = "txtBplusstart";
            txtBplusstart.Size = new Size(122, 20);
            txtBplusstart.TabIndex = 11;
            // 
            // txtDComment
            // 
            txtDComment.Location = new Point(718, 119);
            txtDComment.Name = "txtDComment";
            txtDComment.Size = new Size(243, 20);
            txtDComment.TabIndex = 8;
            // 
            // txtDstart
            // 
            txtDstart.Location = new Point(529, 119);
            txtDstart.Name = "txtDstart";
            txtDstart.Size = new Size(123, 20);
            txtDstart.TabIndex = 9;
            // 
            // txtBComment
            // 
            txtBComment.Location = new Point(262, 119);
            txtBComment.Name = "txtBComment";
            txtBComment.Size = new Size(201, 20);
            txtBComment.TabIndex = 10;
            // 
            // txtBstart
            // 
            txtBstart.Location = new Point(74, 119);
            txtBstart.Name = "txtBstart";
            txtBstart.Size = new Size(122, 20);
            txtBstart.TabIndex = 11;
            // 
            // txtDMinusComment
            // 
            txtDMinusComment.Location = new Point(718, 143);
            txtDMinusComment.Name = "txtDMinusComment";
            txtDMinusComment.Size = new Size(243, 20);
            txtDMinusComment.TabIndex = 8;
            // 
            // txtDminstart
            // 
            txtDminstart.Location = new Point(529, 143);
            txtDminstart.Name = "txtDminstart";
            txtDminstart.Size = new Size(123, 20);
            txtDminstart.TabIndex = 9;
            // 
            // txtBMinusComment
            // 
            txtBMinusComment.Location = new Point(262, 143);
            txtBMinusComment.Name = "txtBMinusComment";
            txtBMinusComment.Size = new Size(201, 20);
            txtBMinusComment.TabIndex = 10;
            // 
            // txtBminstart
            // 
            txtBminstart.Location = new Point(74, 143);
            txtBminstart.Name = "txtBminstart";
            txtBminstart.Size = new Size(122, 20);
            txtBminstart.TabIndex = 11;
            // 
            // txtEComment
            // 
            txtEComment.Location = new Point(718, 167);
            txtEComment.Name = "txtEComment";
            txtEComment.Size = new Size(243, 20);
            txtEComment.TabIndex = 8;
            // 
            // txtEstart
            // 
            txtEstart.Location = new Point(529, 167);
            txtEstart.Name = "txtEstart";
            txtEstart.Size = new Size(123, 20);
            txtEstart.TabIndex = 9;
            // 
            // txtCPlusComment
            // 
            txtCPlusComment.Location = new Point(262, 167);
            txtCPlusComment.Name = "txtCPlusComment";
            txtCPlusComment.Size = new Size(201, 20);
            txtCPlusComment.TabIndex = 10;
            // 
            // txtCplusstart
            // 
            txtCplusstart.Location = new Point(74, 167);
            txtCplusstart.Name = "txtCplusstart";
            txtCplusstart.Size = new Size(122, 20);
            txtCplusstart.TabIndex = 11;
            // 
            // LayoutControlGroup2
            // 
            LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup2.GroupBordersVisible = false;
            LayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem4, LayoutControlItem1, LayoutControlItem3, EmptySpaceItem2, LayoutControlItem2, LayoutControlItem5, LayoutControlItem6, LayoutControlItem7, LayoutControlItem8, LayoutControlItem9, LayoutControlItem10, LayoutControlItem11, LayoutControlItem12, LayoutControlItem13, LayoutControlItem14, LayoutControlItem15, LayoutControlItem16, LayoutControlItem17, LayoutControlItem18, LayoutControlItem19, LayoutControlItem20, LayoutControlItem21, LayoutControlItem22, LayoutControlItem23, LayoutControlItem24, LayoutControlItem25, LayoutControlItem26, LayoutControlItem27, EmptySpaceItem6, EmptySpaceItem8, LayoutControlItem28, LayoutControlItem29 });
            LayoutControlGroup2.Location = new Point(0, 0);
            LayoutControlGroup2.Name = "Root";
            LayoutControlGroup2.Size = new Size(973, 431);
            LayoutControlGroup2.TextVisible = false;
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = cboTerm;
            LayoutControlItem4.Location = new Point(292, 0);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(316, 25);
            LayoutControlItem4.Text = "Term";
            LayoutControlItem4.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = cboYear;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(292, 25);
            LayoutControlItem1.Text = "Year";
            LayoutControlItem1.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _cboClass;
            LayoutControlItem3.Location = new Point(608, 0);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(345, 25);
            LayoutControlItem3.Text = "Select Class";
            LayoutControlItem3.TextSize = new Size(59, 13);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 25);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(953, 10);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = txtCComment;
            LayoutControlItem2.Location = new Point(644, 35);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(309, 24);
            LayoutControlItem2.Text = "% Comment";
            LayoutControlItem2.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = txtCstart;
            LayoutControlItem5.Location = new Point(455, 35);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(189, 24);
            LayoutControlItem5.Text = "C From";
            LayoutControlItem5.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = txtAComment;
            LayoutControlItem6.Location = new Point(188, 35);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(267, 24);
            LayoutControlItem6.Text = "% Comment";
            LayoutControlItem6.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = txtAstart;
            LayoutControlItem7.Location = new Point(0, 35);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(188, 24);
            LayoutControlItem7.Text = "A From";
            LayoutControlItem7.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = txtCMinusComment;
            LayoutControlItem8.CustomizationFormText = "LayoutControlItem2";
            LayoutControlItem8.Location = new Point(644, 59);
            LayoutControlItem8.Name = "LayoutControlItem8";
            LayoutControlItem8.Size = new Size(309, 24);
            LayoutControlItem8.Text = "% Comment";
            LayoutControlItem8.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem9
            // 
            LayoutControlItem9.Control = txtCminstart;
            LayoutControlItem9.CustomizationFormText = "LayoutControlItem5";
            LayoutControlItem9.Location = new Point(455, 59);
            LayoutControlItem9.Name = "LayoutControlItem9";
            LayoutControlItem9.Size = new Size(189, 24);
            LayoutControlItem9.Text = "C- From";
            LayoutControlItem9.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem10
            // 
            LayoutControlItem10.Control = txtAMinusComment;
            LayoutControlItem10.CustomizationFormText = "LayoutControlItem6";
            LayoutControlItem10.Location = new Point(188, 59);
            LayoutControlItem10.Name = "LayoutControlItem10";
            LayoutControlItem10.Size = new Size(267, 24);
            LayoutControlItem10.Text = "% Comment";
            LayoutControlItem10.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem11
            // 
            LayoutControlItem11.Control = txtAminstart;
            LayoutControlItem11.CustomizationFormText = "LayoutControlItem7";
            LayoutControlItem11.Location = new Point(0, 59);
            LayoutControlItem11.Name = "LayoutControlItem11";
            LayoutControlItem11.Size = new Size(188, 24);
            LayoutControlItem11.Text = "A- From";
            LayoutControlItem11.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem12
            // 
            LayoutControlItem12.Control = txtDPlusComment;
            LayoutControlItem12.CustomizationFormText = "LayoutControlItem2";
            LayoutControlItem12.Location = new Point(644, 83);
            LayoutControlItem12.Name = "LayoutControlItem12";
            LayoutControlItem12.Size = new Size(309, 24);
            LayoutControlItem12.Text = "% Comment";
            LayoutControlItem12.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem13
            // 
            LayoutControlItem13.Control = txtDplusstart;
            LayoutControlItem13.CustomizationFormText = "LayoutControlItem5";
            LayoutControlItem13.Location = new Point(455, 83);
            LayoutControlItem13.Name = "LayoutControlItem13";
            LayoutControlItem13.Size = new Size(189, 24);
            LayoutControlItem13.Text = "D+ From";
            LayoutControlItem13.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem14
            // 
            LayoutControlItem14.Control = txtBPlusComment;
            LayoutControlItem14.CustomizationFormText = "LayoutControlItem6";
            LayoutControlItem14.Location = new Point(188, 83);
            LayoutControlItem14.Name = "LayoutControlItem14";
            LayoutControlItem14.Size = new Size(267, 24);
            LayoutControlItem14.Text = "% Comment";
            LayoutControlItem14.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem15
            // 
            LayoutControlItem15.Control = txtBplusstart;
            LayoutControlItem15.CustomizationFormText = "LayoutControlItem7";
            LayoutControlItem15.Location = new Point(0, 83);
            LayoutControlItem15.Name = "LayoutControlItem15";
            LayoutControlItem15.Size = new Size(188, 24);
            LayoutControlItem15.Text = "B+ From";
            LayoutControlItem15.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem16
            // 
            LayoutControlItem16.Control = txtDComment;
            LayoutControlItem16.CustomizationFormText = "LayoutControlItem2";
            LayoutControlItem16.Location = new Point(644, 107);
            LayoutControlItem16.Name = "LayoutControlItem16";
            LayoutControlItem16.Size = new Size(309, 24);
            LayoutControlItem16.Text = "% Comment";
            LayoutControlItem16.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem17
            // 
            LayoutControlItem17.Control = txtDstart;
            LayoutControlItem17.CustomizationFormText = "LayoutControlItem5";
            LayoutControlItem17.Location = new Point(455, 107);
            LayoutControlItem17.Name = "LayoutControlItem17";
            LayoutControlItem17.Size = new Size(189, 24);
            LayoutControlItem17.Text = "D From";
            LayoutControlItem17.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem18
            // 
            LayoutControlItem18.Control = txtBComment;
            LayoutControlItem18.CustomizationFormText = "LayoutControlItem6";
            LayoutControlItem18.Location = new Point(188, 107);
            LayoutControlItem18.Name = "LayoutControlItem18";
            LayoutControlItem18.Size = new Size(267, 24);
            LayoutControlItem18.Text = "% Comment";
            LayoutControlItem18.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem19
            // 
            LayoutControlItem19.Control = txtBstart;
            LayoutControlItem19.CustomizationFormText = "LayoutControlItem7";
            LayoutControlItem19.Location = new Point(0, 107);
            LayoutControlItem19.Name = "LayoutControlItem19";
            LayoutControlItem19.Size = new Size(188, 24);
            LayoutControlItem19.Text = "B From";
            LayoutControlItem19.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem20
            // 
            LayoutControlItem20.Control = txtDMinusComment;
            LayoutControlItem20.CustomizationFormText = "LayoutControlItem2";
            LayoutControlItem20.Location = new Point(644, 131);
            LayoutControlItem20.Name = "LayoutControlItem20";
            LayoutControlItem20.Size = new Size(309, 24);
            LayoutControlItem20.Text = "% Comment";
            LayoutControlItem20.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem21
            // 
            LayoutControlItem21.Control = txtDminstart;
            LayoutControlItem21.CustomizationFormText = "LayoutControlItem5";
            LayoutControlItem21.Location = new Point(455, 131);
            LayoutControlItem21.Name = "LayoutControlItem21";
            LayoutControlItem21.Size = new Size(189, 24);
            LayoutControlItem21.Text = "D- From";
            LayoutControlItem21.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem22
            // 
            LayoutControlItem22.Control = txtBMinusComment;
            LayoutControlItem22.CustomizationFormText = "LayoutControlItem6";
            LayoutControlItem22.Location = new Point(188, 131);
            LayoutControlItem22.Name = "LayoutControlItem22";
            LayoutControlItem22.Size = new Size(267, 24);
            LayoutControlItem22.Text = "% Comment";
            LayoutControlItem22.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem23
            // 
            LayoutControlItem23.Control = txtBminstart;
            LayoutControlItem23.CustomizationFormText = "LayoutControlItem7";
            LayoutControlItem23.Location = new Point(0, 131);
            LayoutControlItem23.Name = "LayoutControlItem23";
            LayoutControlItem23.Size = new Size(188, 24);
            LayoutControlItem23.Text = "B- From";
            LayoutControlItem23.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem24
            // 
            LayoutControlItem24.Control = txtEComment;
            LayoutControlItem24.CustomizationFormText = "LayoutControlItem2";
            LayoutControlItem24.Location = new Point(644, 155);
            LayoutControlItem24.Name = "LayoutControlItem24";
            LayoutControlItem24.Size = new Size(309, 24);
            LayoutControlItem24.Text = "% Comment";
            LayoutControlItem24.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem25
            // 
            LayoutControlItem25.Control = txtEstart;
            LayoutControlItem25.CustomizationFormText = "LayoutControlItem5";
            LayoutControlItem25.Location = new Point(455, 155);
            LayoutControlItem25.Name = "LayoutControlItem25";
            LayoutControlItem25.Size = new Size(189, 24);
            LayoutControlItem25.Text = "E From";
            LayoutControlItem25.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem26
            // 
            LayoutControlItem26.Control = txtCPlusComment;
            LayoutControlItem26.CustomizationFormText = "LayoutControlItem6";
            LayoutControlItem26.Location = new Point(188, 155);
            LayoutControlItem26.Name = "LayoutControlItem26";
            LayoutControlItem26.Size = new Size(267, 24);
            LayoutControlItem26.Text = "% Comment";
            LayoutControlItem26.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem27
            // 
            LayoutControlItem27.Control = txtCplusstart;
            LayoutControlItem27.CustomizationFormText = "LayoutControlItem7";
            LayoutControlItem27.Location = new Point(0, 155);
            LayoutControlItem27.Name = "LayoutControlItem27";
            LayoutControlItem27.Size = new Size(188, 24);
            LayoutControlItem27.Text = "C+ From";
            LayoutControlItem27.TextSize = new Size(59, 13);
            // 
            // EmptySpaceItem6
            // 
            EmptySpaceItem6.AllowHotTrack = false;
            EmptySpaceItem6.Location = new Point(0, 179);
            EmptySpaceItem6.Name = "EmptySpaceItem6";
            EmptySpaceItem6.Size = new Size(857, 43);
            EmptySpaceItem6.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem8
            // 
            EmptySpaceItem8.AllowHotTrack = false;
            EmptySpaceItem8.Location = new Point(0, 222);
            EmptySpaceItem8.Name = "EmptySpaceItem8";
            EmptySpaceItem8.Size = new Size(953, 189);
            EmptySpaceItem8.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem28
            // 
            LayoutControlItem28.Control = _btnSave;
            LayoutControlItem28.Location = new Point(905, 179);
            LayoutControlItem28.Name = "LayoutControlItem28";
            LayoutControlItem28.Size = new Size(48, 43);
            LayoutControlItem28.TextSize = new Size(0, 0);
            LayoutControlItem28.TextVisible = false;
            // 
            // LayoutControlItem29
            // 
            LayoutControlItem29.Control = _btnClear;
            LayoutControlItem29.Location = new Point(857, 179);
            LayoutControlItem29.Name = "LayoutControlItem29";
            LayoutControlItem29.Size = new Size(48, 43);
            LayoutControlItem29.TextSize = new Size(0, 0);
            LayoutControlItem29.TextVisible = false;
            // 
            // frmClassBasedGrading
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 431);
            Controls.Add(LayoutControl2);
            Name = "frmClassBasedGrading";
            Text = "frmClassBasedGrading";
            ((System.ComponentModel.ISupportInitialize)LayoutControl2).EndInit();
            LayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem28).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem29).EndInit();
            Load += new EventHandler(frmClassBasedGrading_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl2;
        internal ComboBox cboTerm;
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

        internal ComboBox cboYear;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal TextBox txtAstart;
        internal TextBox txtAComment;
        internal TextBox txtCstart;
        internal TextBox txtCComment;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal TextBox txtCMinusComment;
        internal TextBox txtCminstart;
        internal TextBox txtAMinusComment;
        internal TextBox txtAminstart;
        internal TextBox txtDPlusComment;
        internal TextBox txtDplusstart;
        internal TextBox txtBPlusComment;
        internal TextBox txtBplusstart;
        internal TextBox txtDComment;
        internal TextBox txtDstart;
        internal TextBox txtBComment;
        internal TextBox txtBstart;
        internal TextBox txtDMinusComment;
        internal TextBox txtDminstart;
        internal TextBox txtBMinusComment;
        internal TextBox txtBminstart;
        internal TextBox txtEComment;
        internal TextBox txtEstart;
        internal TextBox txtCPlusComment;
        internal TextBox txtCplusstart;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem9;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem10;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem11;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem12;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem13;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem14;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem15;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem16;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem17;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem18;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem19;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem20;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem21;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem22;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem23;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem24;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem25;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem26;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem27;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem6;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem8;
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

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem28;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem29;
    }
}