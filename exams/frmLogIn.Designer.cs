using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmLogIn : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _lblDBConnection = new Label();
            _lblDBConnection.Click += new EventHandler(lblDBConnection_Click);
            _btnLogIn = new DevExpress.XtraEditors.SimpleButton();
            _btnLogIn.Click += new EventHandler(btnLogIn_Click);
            PictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_lblDBConnection);
            LayoutControl1.Controls.Add(_btnLogIn);
            LayoutControl1.Controls.Add(PictureEdit1);
            LayoutControl1.Controls.Add(txtUserName);
            LayoutControl1.Controls.Add(txtPassword);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(504, 174);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // lblDBConnection
            // 
            _lblDBConnection.Location = new Point(198, 142);
            _lblDBConnection.Name = "_lblDBConnection";
            _lblDBConnection.Size = new Size(223, 20);
            _lblDBConnection.TabIndex = 9;
            _lblDBConnection.Text = "DB Connection";
            // 
            // btnLogIn
            // 
            _btnLogIn.Image = (Image)resources.GetObject("btnLogIn.Image");
            _btnLogIn.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnLogIn.Location = new Point(425, 60);
            _btnLogIn.Name = "_btnLogIn";
            _btnLogIn.Size = new Size(67, 39);
            _btnLogIn.StyleController = LayoutControl1;
            _btnLogIn.TabIndex = 8;
            _btnLogIn.Text = "Log In";
            // 
            // PictureEdit1
            // 
            PictureEdit1.EditValue = My.Resources.Resources.users;
            PictureEdit1.Location = new Point(12, 12);
            PictureEdit1.Name = "PictureEdit1";
            PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            PictureEdit1.Size = new Size(182, 150);
            PictureEdit1.StyleController = LayoutControl1;
            PictureEdit1.TabIndex = 4;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(253, 12);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(239, 20);
            txtUserName.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(253, 36);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(239, 20);
            txtPassword.TabIndex = 6;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, layoutControlItem2, layoutControlItem3, EmptySpaceItem1, EmptySpaceItem2, LayoutControlItem4, LayoutControlItem5 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(504, 174);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = PictureEdit1;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(186, 154);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtUserName;
            layoutControlItem2.CustomizationFormText = "User Name";
            layoutControlItem2.Location = new Point(186, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(298, 24);
            layoutControlItem2.Text = "User Name";
            layoutControlItem2.TextSize = new Size(52, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtPassword;
            layoutControlItem3.CustomizationFormText = "Password";
            layoutControlItem3.Location = new Point(186, 24);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(298, 24);
            layoutControlItem3.Text = "Password";
            layoutControlItem3.TextSize = new Size(52, 13);
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(186, 48);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(227, 82);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(413, 91);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(71, 63);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _btnLogIn;
            LayoutControlItem4.Location = new Point(413, 48);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(71, 43);
            LayoutControlItem4.TextSize = new Size(0, 0);
            LayoutControlItem4.TextVisible = false;
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = _lblDBConnection;
            LayoutControlItem5.Location = new Point(186, 130);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(227, 24);
            LayoutControlItem5.TextSize = new Size(0, 0);
            LayoutControlItem5.TextVisible = false;
            // 
            // frmLogIn
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 174);
            Controls.Add(LayoutControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLogIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log In";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            Load += new EventHandler(frmLogIn_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        private Label _lblDBConnection;

        internal Label lblDBConnection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDBConnection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDBConnection != null)
                {
                    _lblDBConnection.Click -= lblDBConnection_Click;
                }

                _lblDBConnection = value;
                if (_lblDBConnection != null)
                {
                    _lblDBConnection.Click += lblDBConnection_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _btnLogIn;

        private DevExpress.XtraEditors.SimpleButton btnLogIn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnLogIn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnLogIn != null)
                {
                    _btnLogIn.Click -= btnLogIn_Click;
                }

                _btnLogIn = value;
                if (_btnLogIn != null)
                {
                    _btnLogIn.Click += btnLogIn_Click;
                }
            }
        }

        internal DevExpress.XtraEditors.PictureEdit PictureEdit1;
        internal TextBox txtUserName;
        internal TextBox txtPassword;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
    }
}