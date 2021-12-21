using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmNationalExaminationsEntry : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNationalExaminationsEntry));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _btnSave = new DevExpress.XtraEditors.SimpleButton();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            _btnPrintPreview.Click += new EventHandler(btnPrintPreview_Click);
            dgvSubjects = new DataGridView();
            _ComboBox1 = new ComboBox();
            _ComboBox1.SelectedIndexChanged += new EventHandler(ComboBox1_SelectedIndexChanged);
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnSave);
            LayoutControl1.Controls.Add(_btnPrintPreview);
            LayoutControl1.Controls.Add(dgvSubjects);
            LayoutControl1.Controls.Add(_ComboBox1);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(924, 427);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // btnSave
            // 
            _btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            _btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnSave.Location = new Point(770, 376);
            _btnSave.Name = "_btnSave";
            _btnSave.Size = new Size(64, 39);
            _btnSave.StyleController = LayoutControl1;
            _btnSave.TabIndex = 10;
            _btnSave.Text = "Save";
            // 
            // btnPrintPreview
            // 
            _btnPrintPreview.Image = (Image)resources.GetObject("btnPrintPreview.Image");
            _btnPrintPreview.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnPrintPreview.Location = new Point(838, 376);
            _btnPrintPreview.Name = "_btnPrintPreview";
            _btnPrintPreview.Size = new Size(74, 39);
            _btnPrintPreview.StyleController = LayoutControl1;
            _btnPrintPreview.TabIndex = 9;
            _btnPrintPreview.Text = "Print Preview";
            // 
            // dgvSubjects
            // 
            dgvSubjects.AllowUserToAddRows = false;
            dgvSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubjects.Location = new Point(12, 37);
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubjects.Size = new Size(900, 335);
            dgvSubjects.TabIndex = 5;
            // 
            // ComboBox1
            // 
            _ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            _ComboBox1.FormattingEnabled = true;
            _ComboBox1.Location = new Point(49, 12);
            _ComboBox1.Name = "_ComboBox1";
            _ComboBox1.Size = new Size(863, 21);
            _ComboBox1.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, EmptySpaceItem1, LayoutControlItem3, LayoutControlItem4 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(924, 427);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _ComboBox1;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(904, 25);
            LayoutControlItem1.Text = "Stream";
            LayoutControlItem1.TextSize = new Size(34, 13);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = dgvSubjects;
            LayoutControlItem2.Location = new Point(0, 25);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(904, 339);
            LayoutControlItem2.TextSize = new Size(0, 0);
            LayoutControlItem2.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 364);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(758, 43);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _btnPrintPreview;
            LayoutControlItem3.Location = new Point(826, 364);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(78, 43);
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _btnSave;
            LayoutControlItem4.Location = new Point(758, 364);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(68, 43);
            LayoutControlItem4.TextSize = new Size(0, 0);
            LayoutControlItem4.TextVisible = false;
            // 
            // frmNationalExaminationsEntry
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 427);
            Controls.Add(LayoutControl1);
            Name = "frmNationalExaminationsEntry";
            Text = "National Examinations Result Entry";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            Load += new EventHandler(frmNationalExaminationsEntry_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DataGridView dgvSubjects;
        private ComboBox _ComboBox1;

        internal ComboBox ComboBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBox1 != null)
                {
                    _ComboBox1.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged;
                }

                _ComboBox1 = value;
                if (_ComboBox1 != null)
                {
                    _ComboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
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

        private DevExpress.XtraEditors.SimpleButton _btnPrintPreview;

        internal DevExpress.XtraEditors.SimpleButton btnPrintPreview
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintPreview;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintPreview != null)
                {
                    _btnPrintPreview.Click -= btnPrintPreview_Click;
                }

                _btnPrintPreview = value;
                if (_btnPrintPreview != null)
                {
                    _btnPrintPreview.Click += btnPrintPreview_Click;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
    }
}