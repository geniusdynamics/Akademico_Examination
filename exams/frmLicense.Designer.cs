using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmLicense : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicense));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _btnActivate = new DevExpress.XtraEditors.SimpleButton();
            _btnActivate.Click += new EventHandler(btnActivate_Click);
            txtLicenseKey = new TextBox();
            txtLicenseInfo = new TextBox();
            txtSchoolName = new TextBox();
            _radActivate = new RadioButton();
            _radActivate.CheckedChanged += new EventHandler(radActivate_CheckedChanged);
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            schoolNameLC = new DevExpress.XtraLayout.LayoutControlItem();
            licenseCodeLC = new DevExpress.XtraLayout.LayoutControlItem();
            licenseKeyLC = new DevExpress.XtraLayout.LayoutControlItem();
            activateLC = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ErrorProvider1 = new ErrorProvider(components);
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            _sampleDb = new DevExpress.XtraEditors.SimpleButton();
            _sampleDb.Click += new EventHandler(sampleDb_Click);
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            LabelInfo = new DevExpress.XtraEditors.TextEdit();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schoolNameLC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)licenseCodeLC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)licenseKeyLC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)activateLC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LabelInfo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnActivate);
            LayoutControl1.Controls.Add(txtLicenseKey);
            LayoutControl1.Controls.Add(txtLicenseInfo);
            LayoutControl1.Controls.Add(txtSchoolName);
            LayoutControl1.Controls.Add(_radActivate);
            LayoutControl1.Controls.Add(_sampleDb);
            LayoutControl1.Controls.Add(LabelInfo);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(599, 211);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // btnActivate
            // 
            _btnActivate.ImageOptions.Image = (Image)resources.GetObject("btnActivate.ImageOptions.Image");
            _btnActivate.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnActivate.Location = new Point(398, 113);
            _btnActivate.Name = "_btnActivate";
            _btnActivate.Size = new Size(189, 55);
            _btnActivate.StyleController = LayoutControl1;
            _btnActivate.TabIndex = 10;
            _btnActivate.Text = "Activate";
            // 
            // txtLicenseKey
            // 
            txtLicenseKey.Location = new Point(78, 89);
            txtLicenseKey.Name = "txtLicenseKey";
            txtLicenseKey.Size = new Size(509, 20);
            txtLicenseKey.TabIndex = 8;
            // 
            // txtLicenseInfo
            // 
            txtLicenseInfo.Location = new Point(78, 65);
            txtLicenseInfo.Name = "txtLicenseInfo";
            txtLicenseInfo.Size = new Size(509, 20);
            txtLicenseInfo.TabIndex = 7;
            // 
            // txtSchoolName
            // 
            txtSchoolName.Location = new Point(78, 41);
            txtSchoolName.Name = "txtSchoolName";
            txtSchoolName.Size = new Size(509, 20);
            txtSchoolName.TabIndex = 6;
            // 
            // radActivate
            // 
            _radActivate.Location = new Point(12, 12);
            _radActivate.Name = "_radActivate";
            _radActivate.Size = new Size(575, 25);
            _radActivate.TabIndex = 4;
            _radActivate.TabStop = true;
            _radActivate.Text = "Activate Akademico";
            _radActivate.UseVisualStyleBackColor = true;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, schoolNameLC, licenseCodeLC, licenseKeyLC, activateLC, EmptySpaceItem1, EmptySpaceItem2, LayoutControlItem2, EmptySpaceItem3, EmptySpaceItem4, LayoutControlItem3 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(599, 211);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _radActivate;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(579, 29);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // schoolNameLC
            // 
            schoolNameLC.Control = txtSchoolName;
            schoolNameLC.Location = new Point(0, 29);
            schoolNameLC.Name = "schoolNameLC";
            schoolNameLC.Size = new Size(579, 24);
            schoolNameLC.Text = "School Code";
            schoolNameLC.TextSize = new Size(63, 13);
            // 
            // licenseCodeLC
            // 
            licenseCodeLC.Control = txtLicenseInfo;
            licenseCodeLC.Location = new Point(0, 53);
            licenseCodeLC.Name = "licenseCodeLC";
            licenseCodeLC.Size = new Size(579, 24);
            licenseCodeLC.Text = "License Code";
            licenseCodeLC.TextSize = new Size(63, 13);
            // 
            // licenseKeyLC
            // 
            licenseKeyLC.Control = txtLicenseKey;
            licenseKeyLC.Location = new Point(0, 77);
            licenseKeyLC.Name = "licenseKeyLC";
            licenseKeyLC.Size = new Size(579, 24);
            licenseKeyLC.Text = "License Key";
            licenseKeyLC.TextSize = new Size(63, 13);
            // 
            // activateLC
            // 
            activateLC.Control = _btnActivate;
            activateLC.Location = new Point(386, 101);
            activateLC.Name = "activateLC";
            activateLC.Size = new Size(193, 90);
            activateLC.TextSize = new Size(0, 0);
            activateLC.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(282, 167);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(86, 24);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // ErrorProvider1
            // 
            ErrorProvider1.ContainerControl = this;
            ErrorProvider1.RightToLeft = true;
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(368, 101);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(18, 90);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // sampleDb
            // 
            _sampleDb.Location = new Point(12, 131);
            _sampleDb.Name = "_sampleDb";
            _sampleDb.Size = new Size(154, 44);
            _sampleDb.StyleController = LayoutControl1;
            _sampleDb.TabIndex = 13;
            _sampleDb.Text = "Load DemoDatabase";
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _sampleDb;
            LayoutControlItem2.Location = new Point(0, 119);
            LayoutControlItem2.MinSize = new Size(112, 26);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(158, 48);
            LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            LayoutControlItem2.TextSize = new Size(0, 0);
            LayoutControlItem2.TextVisible = false;
            // 
            // EmptySpaceItem3
            // 
            EmptySpaceItem3.AllowHotTrack = false;
            EmptySpaceItem3.Location = new Point(0, 101);
            EmptySpaceItem3.Name = "EmptySpaceItem3";
            EmptySpaceItem3.Size = new Size(158, 18);
            EmptySpaceItem3.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem4
            // 
            EmptySpaceItem4.AllowHotTrack = false;
            EmptySpaceItem4.Location = new Point(158, 101);
            EmptySpaceItem4.Name = "EmptySpaceItem4";
            EmptySpaceItem4.Size = new Size(210, 66);
            EmptySpaceItem4.TextSize = new Size(0, 0);
            // 
            // LabelInfo
            // 
            LabelInfo.Enabled = false;
            LabelInfo.Location = new Point(12, 179);
            LabelInfo.Name = "LabelInfo";
            LabelInfo.Size = new Size(278, 20);
            LabelInfo.StyleController = LayoutControl1;
            LabelInfo.TabIndex = 14;
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = LabelInfo;
            LayoutControlItem3.Location = new Point(0, 167);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(282, 24);
            LayoutControlItem3.Text = "Expiry";
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // frmLicense
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 211);
            Controls.Add(LayoutControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "License";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)schoolNameLC).EndInit();
            ((System.ComponentModel.ISupportInitialize)licenseCodeLC).EndInit();
            ((System.ComponentModel.ISupportInitialize)licenseKeyLC).EndInit();
            ((System.ComponentModel.ISupportInitialize)activateLC).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LabelInfo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            Load += new EventHandler(frmLicense_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton _btnActivate;

        internal DevExpress.XtraEditors.SimpleButton btnActivate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnActivate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnActivate != null)
                {
                    _btnActivate.Click -= btnActivate_Click;
                }

                _btnActivate = value;
                if (_btnActivate != null)
                {
                    _btnActivate.Click += btnActivate_Click;
                }
            }
        }

        internal TextBox txtLicenseKey;
        internal TextBox txtLicenseInfo;
        internal TextBox txtSchoolName;
        private RadioButton _radActivate;

        internal RadioButton radActivate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radActivate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radActivate != null)
                {
                    _radActivate.CheckedChanged -= radActivate_CheckedChanged;
                }

                _radActivate = value;
                if (_radActivate != null)
                {
                    _radActivate.CheckedChanged += radActivate_CheckedChanged;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem schoolNameLC;
        internal DevExpress.XtraLayout.LayoutControlItem licenseCodeLC;
        internal DevExpress.XtraLayout.LayoutControlItem licenseKeyLC;
        internal DevExpress.XtraLayout.LayoutControlItem activateLC;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal ErrorProvider ErrorProvider1;
        private DevExpress.XtraEditors.SimpleButton _sampleDb;

        internal DevExpress.XtraEditors.SimpleButton sampleDb
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _sampleDb;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_sampleDb != null)
                {
                    _sampleDb.Click -= sampleDb_Click;
                }

                _sampleDb = value;
                if (_sampleDb != null)
                {
                    _sampleDb.Click += sampleDb_Click;
                }
            }
        }

        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem3;
        internal DevExpress.XtraEditors.TextEdit LabelInfo;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
    }
}