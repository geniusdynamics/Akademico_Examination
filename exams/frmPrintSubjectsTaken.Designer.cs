using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmPrintSubjectsTaken : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintSubjectsTaken));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _btnShow = new DevExpress.XtraEditors.SimpleButton();
            _btnShow.Click += new EventHandler(btnShow_Click);
            cboSubject = new ComboBox();
            CboStream = new ComboBox();
            cboClass = new ComboBox();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            subjectsLC = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ErrorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subjectsLC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnShow);
            LayoutControl1.Controls.Add(cboSubject);
            LayoutControl1.Controls.Add(CboStream);
            LayoutControl1.Controls.Add(cboClass);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(392, 139);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // btnShow
            // 
            _btnShow.Image = (Image)resources.GetObject("btnShow.Image");
            _btnShow.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnShow.Location = new Point(293, 87);
            _btnShow.Name = "_btnShow";
            _btnShow.Size = new Size(87, 39);
            _btnShow.StyleController = LayoutControl1;
            _btnShow.TabIndex = 7;
            _btnShow.Text = "Show";
            // 
            // cboSubject
            // 
            cboSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSubject.FormattingEnabled = true;
            cboSubject.Location = new Point(51, 62);
            cboSubject.Name = "cboSubject";
            cboSubject.Size = new Size(329, 21);
            cboSubject.TabIndex = 6;
            // 
            // CboStream
            // 
            CboStream.DropDownStyle = ComboBoxStyle.DropDownList;
            CboStream.FormattingEnabled = true;
            CboStream.Location = new Point(51, 37);
            CboStream.Name = "CboStream";
            CboStream.Size = new Size(329, 21);
            CboStream.TabIndex = 5;
            // 
            // cboClass
            // 
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.FormattingEnabled = true;
            cboClass.Location = new Point(51, 12);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(329, 21);
            cboClass.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, subjectsLC, LayoutControlItem4, EmptySpaceItem1 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(392, 139);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = cboClass;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(372, 25);
            LayoutControlItem1.Text = "Class";
            LayoutControlItem1.TextSize = new Size(36, 13);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = CboStream;
            LayoutControlItem2.Location = new Point(0, 25);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(372, 25);
            LayoutControlItem2.Text = "Stream";
            LayoutControlItem2.TextSize = new Size(36, 13);
            // 
            // subjectsLC
            // 
            subjectsLC.Control = cboSubject;
            subjectsLC.Location = new Point(0, 50);
            subjectsLC.Name = "subjectsLC";
            subjectsLC.Size = new Size(372, 25);
            subjectsLC.Text = "Subject";
            subjectsLC.TextSize = new Size(36, 13);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _btnShow;
            LayoutControlItem4.Location = new Point(281, 75);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(91, 44);
            LayoutControlItem4.TextSize = new Size(0, 0);
            LayoutControlItem4.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 75);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(281, 44);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // ErrorProvider1
            // 
            ErrorProvider1.ContainerControl = this;
            ErrorProvider1.RightToLeft = true;
            // 
            // frmPrintSubjectsTaken
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 139);
            Controls.Add(LayoutControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPrintSubjectsTaken";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Show Subjects Taken";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)subjectsLC).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).EndInit();
            Load += new EventHandler(frmPrintSubjectsTaken_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton _btnShow;

        internal DevExpress.XtraEditors.SimpleButton btnShow
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnShow;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnShow != null)
                {
                    _btnShow.Click -= btnShow_Click;
                }

                _btnShow = value;
                if (_btnShow != null)
                {
                    _btnShow.Click += btnShow_Click;
                }
            }
        }

        internal ComboBox cboSubject;
        internal ComboBox CboStream;
        internal ComboBox cboClass;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem subjectsLC;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal ErrorProvider ErrorProvider1;
    }
}