using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmDBConnection : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBConnection));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _btnSave = new DevExpress.XtraEditors.SimpleButton();
            _btnSave.Click += new EventHandler(btnSave_Click);
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            txtDbHost = new TextBox();
            txtDBName = new TextBox();
            _defaultConnString = new DevExpress.XtraEditors.SimpleButton();
            _defaultConnString.Click += new EventHandler(defaultConnString_Click);
            txtDbPort = new DevExpress.XtraEditors.TextEdit();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            ErrorProvider1 = new ErrorProvider(components);
            txtAPIUserName = new TextBox();
            LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            txtAPI = new TextBox();
            LayoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            txtSender = new TextBox();
            Sender = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtDbPort.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Sender).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(txtSender);
            LayoutControl1.Controls.Add(txtAPI);
            LayoutControl1.Controls.Add(txtAPIUserName);
            LayoutControl1.Controls.Add(_btnSave);
            LayoutControl1.Controls.Add(txtPassword);
            LayoutControl1.Controls.Add(txtUserName);
            LayoutControl1.Controls.Add(txtDbHost);
            LayoutControl1.Controls.Add(txtDBName);
            LayoutControl1.Controls.Add(_defaultConnString);
            LayoutControl1.Controls.Add(txtDbPort);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Margin = new Padding(3, 4, 3, 4);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(588, 320);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // btnSave
            // 
            _btnSave.ImageOptions.Image = (Image)resources.GetObject("btnSave.ImageOptions.Image");
            _btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnSave.Location = new Point(422, 261);
            _btnSave.Margin = new Padding(3, 4, 3, 4);
            _btnSave.Name = "_btnSave";
            _btnSave.Size = new Size(129, 44);
            _btnSave.StyleController = LayoutControl1;
            _btnSave.TabIndex = 9;
            _btnSave.Text = "Save";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(112, 109);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(439, 25);
            txtPassword.TabIndex = 7;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(112, 78);
            txtUserName.Margin = new Padding(3, 4, 3, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(439, 25);
            txtUserName.TabIndex = 6;
            // 
            // txtDbHost
            // 
            txtDbHost.Location = new Point(112, 47);
            txtDbHost.Margin = new Padding(3, 4, 3, 4);
            txtDbHost.Name = "txtDbHost";
            txtDbHost.Size = new Size(439, 25);
            txtDbHost.TabIndex = 5;
            // 
            // txtDBName
            // 
            txtDBName.Location = new Point(112, 16);
            txtDBName.Margin = new Padding(3, 4, 3, 4);
            txtDBName.Name = "txtDBName";
            txtDBName.Size = new Size(439, 25);
            txtDBName.TabIndex = 4;
            // 
            // defaultConnString
            // 
            _defaultConnString.Location = new Point(16, 261);
            _defaultConnString.Margin = new Padding(3, 4, 3, 4);
            _defaultConnString.Name = "_defaultConnString";
            _defaultConnString.Size = new Size(129, 44);
            _defaultConnString.StyleController = LayoutControl1;
            _defaultConnString.TabIndex = 10;
            _defaultConnString.Text = "Load Defaults";
            // 
            // txtDbPort
            // 
            txtDbPort.Location = new Point(112, 140);
            txtDbPort.Margin = new Padding(3, 4, 3, 4);
            txtDbPort.Name = "txtDbPort";
            txtDbPort.Size = new Size(439, 22);
            txtDbPort.StyleController = LayoutControl1;
            txtDbPort.TabIndex = 11;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, LayoutControlItem3, LayoutControlItem4, LayoutControlItem5, EmptySpaceItem4, LayoutControlItem7, EmptySpaceItem1, LayoutControlItem6, EmptySpaceItem5, LayoutControlItem8, LayoutControlItem9, Sender });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(567, 331);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = txtDBName;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(541, 31);
            LayoutControlItem1.Text = "DB Name";
            LayoutControlItem1.TextSize = new Size(93, 16);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = txtDbHost;
            LayoutControlItem2.Location = new Point(0, 31);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(541, 31);
            LayoutControlItem2.Text = "Db Host";
            LayoutControlItem2.TextSize = new Size(93, 16);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = txtUserName;
            LayoutControlItem3.Location = new Point(0, 62);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(541, 31);
            LayoutControlItem3.Text = "User Name";
            LayoutControlItem3.TextSize = new Size(93, 16);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = txtPassword;
            LayoutControlItem4.Location = new Point(0, 93);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(541, 31);
            LayoutControlItem4.Text = "Password";
            LayoutControlItem4.TextSize = new Size(93, 16);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = _btnSave;
            LayoutControlItem5.Location = new Point(406, 245);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(135, 50);
            LayoutControlItem5.TextSize = new Size(0, 0);
            LayoutControlItem5.TextVisible = false;
            // 
            // EmptySpaceItem4
            // 
            EmptySpaceItem4.AllowHotTrack = false;
            EmptySpaceItem4.Location = new Point(271, 245);
            EmptySpaceItem4.Name = "EmptySpaceItem4";
            EmptySpaceItem4.Size = new Size(135, 50);
            EmptySpaceItem4.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = txtDbPort;
            LayoutControlItem7.Location = new Point(0, 124);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(541, 28);
            LayoutControlItem7.Text = "Server Port";
            LayoutControlItem7.TextSize = new Size(93, 16);
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(135, 245);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(136, 50);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = _defaultConnString;
            LayoutControlItem6.Location = new Point(0, 245);
            LayoutControlItem6.MinSize = new Size(79, 26);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(135, 50);
            LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            LayoutControlItem6.TextSize = new Size(0, 0);
            LayoutControlItem6.TextVisible = false;
            // 
            // EmptySpaceItem5
            // 
            EmptySpaceItem5.AllowHotTrack = false;
            EmptySpaceItem5.Location = new Point(0, 295);
            EmptySpaceItem5.Name = "EmptySpaceItem5";
            EmptySpaceItem5.Size = new Size(541, 10);
            EmptySpaceItem5.TextSize = new Size(0, 0);
            // 
            // ErrorProvider1
            // 
            ErrorProvider1.ContainerControl = this;
            ErrorProvider1.RightToLeft = true;
            // 
            // txtAPIUserName
            // 
            txtAPIUserName.Location = new Point(112, 199);
            txtAPIUserName.Name = "txtAPIUserName";
            txtAPIUserName.Size = new Size(439, 25);
            txtAPIUserName.TabIndex = 12;
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = txtAPIUserName;
            LayoutControlItem8.Location = new Point(0, 183);
            LayoutControlItem8.Name = "LayoutControlItem8";
            LayoutControlItem8.Size = new Size(541, 31);
            LayoutControlItem8.Text = "SMS User Name";
            LayoutControlItem8.TextSize = new Size(93, 16);
            // 
            // txtAPI
            // 
            txtAPI.Location = new Point(112, 230);
            txtAPI.Name = "txtAPI";
            txtAPI.Size = new Size(439, 25);
            txtAPI.TabIndex = 13;
            // 
            // LayoutControlItem9
            // 
            LayoutControlItem9.Control = txtAPI;
            LayoutControlItem9.Location = new Point(0, 214);
            LayoutControlItem9.Name = "LayoutControlItem9";
            LayoutControlItem9.Size = new Size(541, 31);
            LayoutControlItem9.Text = "SMS API";
            LayoutControlItem9.TextSize = new Size(93, 16);
            // 
            // txtSender
            // 
            txtSender.Location = new Point(112, 168);
            txtSender.Name = "txtSender";
            txtSender.Size = new Size(439, 25);
            txtSender.TabIndex = 14;
            // 
            // Sender
            // 
            Sender.Control = txtSender;
            Sender.Location = new Point(0, 152);
            Sender.Name = "Sender";
            Sender.Size = new Size(541, 31);
            Sender.TextSize = new Size(93, 16);
            // 
            // frmDBConnection
            // 
            AutoScaleDimensions = new SizeF(7.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 320);
            Controls.Add(LayoutControl1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDBConnection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DB Connection";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtDbPort.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)Sender).EndInit();
            Load += new EventHandler(frmDBConnection_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton _btnSave;

        private DevExpress.XtraEditors.SimpleButton btnSave
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

        internal TextBox txtPassword;
        internal TextBox txtUserName;
        internal TextBox txtDbHost;
        internal TextBox txtDBName;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal ErrorProvider ErrorProvider1;
        private DevExpress.XtraEditors.SimpleButton _defaultConnString;

        internal DevExpress.XtraEditors.SimpleButton defaultConnString
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _defaultConnString;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_defaultConnString != null)
                {
                    _defaultConnString.Click -= defaultConnString_Click;
                }

                _defaultConnString = value;
                if (_defaultConnString != null)
                {
                    _defaultConnString.Click += defaultConnString_Click;
                }
            }
        }

        internal DevExpress.XtraEditors.TextEdit txtDbPort;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem5;
        internal TextBox txtAPI;
        internal TextBox txtAPIUserName;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem9;
        internal TextBox txtSender;
        internal DevExpress.XtraLayout.LayoutControlItem Sender;
    }
}