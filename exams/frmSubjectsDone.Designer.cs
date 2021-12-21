using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmSubjectsDone : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectsDone));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            cboStream = new ComboBox();
            _btnview = new DevExpress.XtraEditors.SimpleButton();
            _btnview.Click += new EventHandler(btnview_Click);
            _cboClass = new ComboBox();
            _cboClass.SelectedIndexChanged += new EventHandler(cboClass_SelectedIndexChanged);
            _btnEnterMarks = new DevExpress.XtraEditors.SimpleButton();
            _btnEnterMarks.Click += new EventHandler(btnEnterMarks_Click);
            dgvIndexNo = new DataGridView();
            ADMNo = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            str_class = new DataGridViewTextBoxColumn();
            IndexNo = new DataGridViewTextBoxColumn();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIndexNo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(cboStream);
            LayoutControl1.Controls.Add(_btnview);
            LayoutControl1.Controls.Add(_cboClass);
            LayoutControl1.Controls.Add(_btnEnterMarks);
            LayoutControl1.Controls.Add(dgvIndexNo);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Margin = new Padding(3, 4, 3, 4);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(1043, 560);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // cboStream
            // 
            cboStream.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStream.FormattingEnabled = true;
            cboStream.Location = new Point(608, 16);
            cboStream.Name = "cboStream";
            cboStream.Size = new Size(419, 24);
            cboStream.TabIndex = 8;
            // 
            // btnview
            // 
            _btnview.ImageOptions.Image = (Image)resources.GetObject("btnview.ImageOptions.Image");
            _btnview.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnview.Location = new Point(947, 59);
            _btnview.Margin = new Padding(3, 4, 3, 4);
            _btnview.Name = "_btnview";
            _btnview.Size = new Size(80, 44);
            _btnview.StyleController = LayoutControl1;
            _btnview.TabIndex = 7;
            _btnview.Text = "View";
            // 
            // cboClass
            // 
            _cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboClass.FormattingEnabled = true;
            _cboClass.Location = new Point(100, 16);
            _cboClass.Margin = new Padding(3, 4, 3, 4);
            _cboClass.Name = "_cboClass";
            _cboClass.Size = new Size(418, 24);
            _cboClass.TabIndex = 6;
            // 
            // btnEnterMarks
            // 
            _btnEnterMarks.ImageOptions.Image = (Image)resources.GetObject("btnEnterMarks.ImageOptions.Image");
            _btnEnterMarks.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnEnterMarks.Location = new Point(936, 500);
            _btnEnterMarks.Margin = new Padding(3, 4, 3, 4);
            _btnEnterMarks.Name = "_btnEnterMarks";
            _btnEnterMarks.Size = new Size(91, 44);
            _btnEnterMarks.StyleController = LayoutControl1;
            _btnEnterMarks.TabIndex = 5;
            _btnEnterMarks.Text = "Save";
            // 
            // dgvIndexNo
            // 
            dgvIndexNo.AllowUserToAddRows = false;
            dgvIndexNo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIndexNo.Columns.AddRange(new DataGridViewColumn[] { ADMNo, StudentName, str_class, IndexNo });
            dgvIndexNo.Location = new Point(16, 109);
            dgvIndexNo.Margin = new Padding(3, 4, 3, 4);
            dgvIndexNo.Name = "dgvIndexNo";
            dgvIndexNo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIndexNo.Size = new Size(1011, 385);
            dgvIndexNo.TabIndex = 4;
            // 
            // ADMNo
            // 
            ADMNo.HeaderText = "ADMNo";
            ADMNo.Name = "ADMNo";
            // 
            // StudentName
            // 
            StudentName.HeaderText = "Name Of Student";
            StudentName.Name = "StudentName";
            // 
            // str_class
            // 
            str_class.HeaderText = "Stream";
            str_class.Name = "str_class";
            // 
            // IndexNo
            // 
            IndexNo.HeaderText = "Index No";
            IndexNo.Name = "IndexNo";
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, EmptySpaceItem1, LayoutControlItem2, LayoutControlItem3, EmptySpaceItem2, LayoutControlItem4, EmptySpaceItem3, LayoutControlItem5 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(1043, 560);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = dgvIndexNo;
            LayoutControlItem1.Location = new Point(0, 93);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(1017, 391);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 484);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(920, 50);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _btnEnterMarks;
            LayoutControlItem2.Location = new Point(920, 484);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(97, 50);
            LayoutControlItem2.TextSize = new Size(0, 0);
            LayoutControlItem2.TextVisible = false;
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _cboClass;
            LayoutControlItem3.Location = new Point(0, 0);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(508, 32);
            LayoutControlItem3.Text = "Select Class";
            LayoutControlItem3.TextSize = new Size(81, 16);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 43);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(931, 50);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _btnview;
            LayoutControlItem4.Location = new Point(931, 43);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(86, 50);
            LayoutControlItem4.TextSize = new Size(0, 0);
            LayoutControlItem4.TextVisible = false;
            // 
            // EmptySpaceItem3
            // 
            EmptySpaceItem3.AllowHotTrack = false;
            EmptySpaceItem3.Location = new Point(0, 32);
            EmptySpaceItem3.Name = "EmptySpaceItem3";
            EmptySpaceItem3.Size = new Size(1017, 11);
            EmptySpaceItem3.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = cboStream;
            LayoutControlItem5.Location = new Point(508, 0);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(509, 32);
            LayoutControlItem5.Text = "Select Stream";
            LayoutControlItem5.TextSize = new Size(81, 16);
            // 
            // frmSubjectsDone
            // 
            AutoScaleDimensions = new SizeF(7.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 560);
            Controls.Add(LayoutControl1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSubjectsDone";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subjects Done";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvIndexNo).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            Load += new EventHandler(frmSubjectsDone_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton _btnEnterMarks;

        internal DevExpress.XtraEditors.SimpleButton btnEnterMarks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEnterMarks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEnterMarks != null)
                {
                    _btnEnterMarks.Click -= btnEnterMarks_Click;
                }

                _btnEnterMarks = value;
                if (_btnEnterMarks != null)
                {
                    _btnEnterMarks.Click += btnEnterMarks_Click;
                }
            }
        }

        internal DataGridView dgvIndexNo;
        internal DataGridViewTextBoxColumn ADMNo;
        internal DataGridViewTextBoxColumn StudentName;
        internal DataGridViewTextBoxColumn str_class;
        internal DataGridViewTextBoxColumn IndexNo;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton _btnview;

        internal DevExpress.XtraEditors.SimpleButton btnview
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnview;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnview != null)
                {
                    _btnview.Click -= btnview_Click;
                }

                _btnview = value;
                if (_btnview != null)
                {
                    _btnview.Click += btnview_Click;
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

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem3;
        internal ComboBox cboStream;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
    }
}