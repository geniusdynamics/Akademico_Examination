using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmPerformanceComments : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerformanceComments));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _btnSave = new DevExpress.XtraEditors.SimpleButton();
            _btnSave.Click += new EventHandler(btnSave_Click);
            txtComment = new TextBox();
            _cboTrend = new ComboBox();
            _cboTrend.SelectedIndexChanged += new EventHandler(cboTrend_SelectedIndexChanged);
            _cboStream = new ComboBox();
            _cboStream.SelectedIndexChanged += new EventHandler(cboStream_SelectedIndexChanged);
            _cboClass = new ComboBox();
            _cboClass.SelectedIndexChanged += new EventHandler(cboClass_SelectedIndexChanged);
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ErrorProvider1 = new ErrorProvider();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnSave);
            LayoutControl1.Controls.Add(txtComment);
            LayoutControl1.Controls.Add(_cboTrend);
            LayoutControl1.Controls.Add(_cboStream);
            LayoutControl1.Controls.Add(_cboClass);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(526, 212);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // btnSave
            // 
            _btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            _btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnSave.Location = new Point(464, 144);
            _btnSave.Name = "_btnSave";
            _btnSave.Size = new Size(50, 39);
            _btnSave.StyleController = LayoutControl1;
            _btnSave.TabIndex = 9;
            _btnSave.Text = "Save";
            // 
            // txtComment
            // 
            txtComment.Location = new Point(107, 87);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(407, 53);
            txtComment.TabIndex = 8;
            // 
            // cboTrend
            // 
            _cboTrend.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTrend.FormattingEnabled = true;
            _cboTrend.Items.AddRange(new object[] { "None", "Constant", "Drop", "Improve", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "E", "X", " Y" });
            _cboTrend.Location = new Point(107, 62);
            _cboTrend.Name = "_cboTrend";
            _cboTrend.Size = new Size(407, 21);
            _cboTrend.TabIndex = 7;
            // 
            // cboStream
            // 
            _cboStream.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStream.FormattingEnabled = true;
            _cboStream.Location = new Point(107, 37);
            _cboStream.Name = "_cboStream";
            _cboStream.Size = new Size(407, 21);
            _cboStream.TabIndex = 6;
            // 
            // cboClass
            // 
            _cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboClass.FormattingEnabled = true;
            _cboClass.Location = new Point(107, 12);
            _cboClass.Name = "_cboClass";
            _cboClass.Size = new Size(407, 21);
            _cboClass.TabIndex = 5;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem2, LayoutControlItem3, LayoutControlItem4, LayoutControlItem5, EmptySpaceItem1, EmptySpaceItem2, LayoutControlItem6 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(526, 212);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _cboClass;
            LayoutControlItem2.Location = new Point(0, 0);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(506, 25);
            LayoutControlItem2.Text = "Class";
            LayoutControlItem2.TextSize = new Size(92, 13);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _cboStream;
            LayoutControlItem3.Location = new Point(0, 25);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(506, 25);
            LayoutControlItem3.Text = "Stream";
            LayoutControlItem3.TextSize = new Size(92, 13);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _cboTrend;
            LayoutControlItem4.Location = new Point(0, 50);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(506, 25);
            LayoutControlItem4.Text = "Performance Trend";
            LayoutControlItem4.TextSize = new Size(92, 13);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = txtComment;
            LayoutControlItem5.Location = new Point(0, 75);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(506, 57);
            LayoutControlItem5.Text = "Comment";
            LayoutControlItem5.TextSize = new Size(92, 13);
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 132);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(452, 43);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 175);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(506, 17);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = _btnSave;
            LayoutControlItem6.Location = new Point(452, 132);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(54, 43);
            LayoutControlItem6.TextSize = new Size(0, 0);
            LayoutControlItem6.TextVisible = false;
            // 
            // ErrorProvider1
            // 
            ErrorProvider1.ContainerControl = this;
            ErrorProvider1.RightToLeft = true;
            // 
            // frmPerformanceComments
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 212);
            Controls.Add(LayoutControl1);
            Name = "frmPerformanceComments";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Performance Comments";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).EndInit();
            Load += new EventHandler(frmPerformanceComments_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
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

        internal TextBox txtComment;
        private ComboBox _cboTrend;

        internal ComboBox cboTrend
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTrend;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTrend != null)
                {
                    _cboTrend.SelectedIndexChanged -= cboTrend_SelectedIndexChanged;
                }

                _cboTrend = value;
                if (_cboTrend != null)
                {
                    _cboTrend.SelectedIndexChanged += cboTrend_SelectedIndexChanged;
                }
            }
        }

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

        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal ErrorProvider ErrorProvider1;
    }
}