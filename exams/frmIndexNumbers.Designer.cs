using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmIndexNumbers : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndexNumbers));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            txtCode = new TextBox();
            ProgressBar1 = new ProgressBar();
            _btnClear = new Button();
            _btnClear.Click += new EventHandler(btnClear_Click);
            _btnEnterMarks = new Button();
            _btnEnterMarks.Click += new EventHandler(btnEnterMarks_Click);
            _btnEnter = new Button();
            _btnEnter.Click += new EventHandler(btnEnter_Click);
            dgvIndexNo = new DataGridView();
            ADMNo = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            str_class = new DataGridViewTextBoxColumn();
            IndexNo = new DataGridViewTextBoxColumn();
            _cboStream = new ComboBox();
            _cboStream.SelectedIndexChanged += new EventHandler(cboStream_SelectedIndexChanged);
            _cboClass = new ComboBox();
            _cboClass.SelectedIndexChanged += new EventHandler(cboClass_SelectedIndexChanged);
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIndexNo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(txtCode);
            LayoutControl1.Controls.Add(ProgressBar1);
            LayoutControl1.Controls.Add(_btnClear);
            LayoutControl1.Controls.Add(_btnEnterMarks);
            LayoutControl1.Controls.Add(_btnEnter);
            LayoutControl1.Controls.Add(dgvIndexNo);
            LayoutControl1.Controls.Add(_cboStream);
            LayoutControl1.Controls.Add(_cboClass);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(610, 266, 250, 350);
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(805, 442);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(74, 37);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(326, 20);
            txtCode.TabIndex = 24;
            // 
            // ProgressBar1
            // 
            ProgressBar1.Location = new Point(12, 383);
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new Size(781, 20);
            ProgressBar1.TabIndex = 23;
            // 
            // btnClear
            // 
            _btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            _btnClear.Location = new Point(633, 407);
            _btnClear.Name = "_btnClear";
            _btnClear.Size = new Size(79, 23);
            _btnClear.TabIndex = 22;
            _btnClear.Text = "C&lear";
            _btnClear.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnClear.UseVisualStyleBackColor = true;
            // 
            // btnEnterMarks
            // 
            _btnEnterMarks.Image = (Image)resources.GetObject("btnEnterMarks.Image");
            _btnEnterMarks.Location = new Point(716, 407);
            _btnEnterMarks.Name = "_btnEnterMarks";
            _btnEnterMarks.Size = new Size(77, 23);
            _btnEnterMarks.TabIndex = 21;
            _btnEnterMarks.Text = "&Save Records";
            _btnEnterMarks.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnEnterMarks.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            _btnEnter.Image = (Image)resources.GetObject("btnEnter.Image");
            _btnEnter.Location = new Point(722, 61);
            _btnEnter.Name = "_btnEnter";
            _btnEnter.Size = new Size(71, 20);
            _btnEnter.TabIndex = 20;
            _btnEnter.Text = "&Enter";
            _btnEnter.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnEnter.UseVisualStyleBackColor = true;
            // 
            // dgvIndexNo
            // 
            dgvIndexNo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIndexNo.Columns.AddRange(new DataGridViewColumn[] { ADMNo, StudentName, str_class, IndexNo });
            dgvIndexNo.Location = new Point(12, 85);
            dgvIndexNo.Name = "dgvIndexNo";
            dgvIndexNo.Size = new Size(781, 294);
            dgvIndexNo.TabIndex = 6;
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
            IndexNo.HeaderText = "IndexNo";
            IndexNo.Name = "IndexNo";
            // 
            // cboStream
            // 
            _cboStream.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStream.FormattingEnabled = true;
            _cboStream.Location = new Point(466, 12);
            _cboStream.Name = "_cboStream";
            _cboStream.Size = new Size(327, 21);
            _cboStream.TabIndex = 5;
            // 
            // cboClass
            // 
            _cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboClass.FormattingEnabled = true;
            _cboClass.Location = new Point(74, 12);
            _cboClass.Name = "_cboClass";
            _cboClass.Size = new Size(326, 21);
            _cboClass.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem3, EmptySpaceItem1, LayoutControlItem2, LayoutControlItem1, LayoutControlItem4, EmptySpaceItem2, EmptySpaceItem3, LayoutControlItem5, LayoutControlItem6, LayoutControlItem7, LayoutControlItem8 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(805, 442);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = dgvIndexNo;
            LayoutControlItem3.Location = new Point(0, 73);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(785, 298);
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 49);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(710, 24);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _cboStream;
            LayoutControlItem2.Location = new Point(392, 0);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(393, 25);
            LayoutControlItem2.Text = "Stream";
            LayoutControlItem2.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _cboClass;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(392, 25);
            LayoutControlItem1.Text = "Class";
            LayoutControlItem1.TextSize = new Size(59, 13);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _btnEnter;
            LayoutControlItem4.Location = new Point(710, 49);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(75, 24);
            LayoutControlItem4.TextSize = new Size(0, 0);
            LayoutControlItem4.TextVisible = false;
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(392, 25);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(393, 24);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem3
            // 
            EmptySpaceItem3.AllowHotTrack = false;
            EmptySpaceItem3.Location = new Point(0, 395);
            EmptySpaceItem3.Name = "EmptySpaceItem3";
            EmptySpaceItem3.Size = new Size(621, 27);
            EmptySpaceItem3.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = _btnEnterMarks;
            LayoutControlItem5.Location = new Point(704, 395);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(81, 27);
            LayoutControlItem5.TextSize = new Size(0, 0);
            LayoutControlItem5.TextVisible = false;
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = _btnClear;
            LayoutControlItem6.Location = new Point(621, 395);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(83, 27);
            LayoutControlItem6.TextSize = new Size(0, 0);
            LayoutControlItem6.TextVisible = false;
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = ProgressBar1;
            LayoutControlItem7.Location = new Point(0, 371);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(785, 24);
            LayoutControlItem7.TextSize = new Size(0, 0);
            LayoutControlItem7.TextVisible = false;
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = txtCode;
            LayoutControlItem8.Location = new Point(0, 25);
            LayoutControlItem8.Name = "LayoutControlItem8";
            LayoutControlItem8.Size = new Size(392, 24);
            LayoutControlItem8.Text = "School Code";
            LayoutControlItem8.TextSize = new Size(59, 13);
            // 
            // frmIndexNumbers
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 442);
            Controls.Add(LayoutControl1);
            Name = "frmIndexNumbers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Index Numbers";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvIndexNo).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).EndInit();
            Load += new EventHandler(frmIndexNumbers_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        private Button _btnClear;

        internal Button btnClear
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

        private Button _btnEnterMarks;

        internal Button btnEnterMarks
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

        private Button _btnEnter;

        internal Button btnEnter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEnter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEnter != null)
                {
                    _btnEnter.Click -= btnEnter_Click;
                }

                _btnEnter = value;
                if (_btnEnter != null)
                {
                    _btnEnter.Click += btnEnter_Click;
                }
            }
        }

        internal DataGridView dgvIndexNo;
        internal DataGridViewTextBoxColumn ADMNo;
        internal DataGridViewTextBoxColumn StudentName;
        internal DataGridViewTextBoxColumn str_class;
        internal DataGridViewTextBoxColumn IndexNo;
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

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal ProgressBar ProgressBar1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal TextBox txtCode;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
    }
}