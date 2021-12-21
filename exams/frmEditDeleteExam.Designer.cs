using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmEditDeleteExam : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditDeleteExam));
            LayoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            _btnDelete = new DevExpress.XtraEditors.SimpleButton();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _btnEdit = new DevExpress.XtraEditors.SimpleButton();
            _btnEdit.Click += new EventHandler(btnEdit_Click);
            txtTotal = new TextBox();
            txtName = new TextBox();
            _cboExamName = new ComboBox();
            _cboExamName.SelectedIndexChanged += new EventHandler(cboExamName_SelectedIndexChanged);
            _cboTerm = new ComboBox();
            _cboTerm.SelectedIndexChanged += new EventHandler(cboTerm_SelectedIndexChanged);
            _cboYear = new ComboBox();
            _cboYear.SelectedIndexChanged += new EventHandler(cboYear_SelectedIndexChanged);
            LayoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl2).BeginInit();
            LayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl2
            // 
            LayoutControl2.Controls.Add(_btnDelete);
            LayoutControl2.Controls.Add(_btnEdit);
            LayoutControl2.Controls.Add(txtTotal);
            LayoutControl2.Controls.Add(txtName);
            LayoutControl2.Controls.Add(_cboExamName);
            LayoutControl2.Controls.Add(_cboTerm);
            LayoutControl2.Controls.Add(_cboYear);
            LayoutControl2.Dock = DockStyle.Fill;
            LayoutControl2.Location = new Point(0, 0);
            LayoutControl2.Name = "LayoutControl2";
            LayoutControl2.Root = LayoutControlGroup2;
            LayoutControl2.Size = new Size(558, 206);
            LayoutControl2.TabIndex = 1;
            LayoutControl2.Text = "LayoutControl2";
            // 
            // btnDelete
            // 
            _btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            _btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnDelete.Location = new Point(466, 135);
            _btnDelete.Name = "_btnDelete";
            _btnDelete.Size = new Size(42, 39);
            _btnDelete.StyleController = LayoutControl2;
            _btnDelete.TabIndex = 16;
            _btnDelete.Text = "Delete";
            // 
            // btnEdit
            // 
            _btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            _btnEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnEdit.Location = new Point(512, 135);
            _btnEdit.Name = "_btnEdit";
            _btnEdit.Size = new Size(34, 39);
            _btnEdit.StyleController = LayoutControl2;
            _btnEdit.TabIndex = 15;
            _btnEdit.Text = "Edit";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(95, 111);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(451, 20);
            txtTotal.TabIndex = 8;
            // 
            // txtName
            // 
            txtName.Location = new Point(95, 87);
            txtName.Name = "txtName";
            txtName.Size = new Size(451, 20);
            txtName.TabIndex = 7;
            // 
            // cboExamName
            // 
            _cboExamName.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboExamName.FormattingEnabled = true;
            _cboExamName.Location = new Point(95, 62);
            _cboExamName.Name = "_cboExamName";
            _cboExamName.Size = new Size(451, 21);
            _cboExamName.TabIndex = 6;
            // 
            // cboTerm
            // 
            _cboTerm.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerm.FormattingEnabled = true;
            _cboTerm.Items.AddRange(new object[] { "I", "II", "III" });
            _cboTerm.Location = new Point(95, 37);
            _cboTerm.Name = "_cboTerm";
            _cboTerm.Size = new Size(451, 21);
            _cboTerm.TabIndex = 5;
            // 
            // cboYear
            // 
            _cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear.FormattingEnabled = true;
            _cboYear.Location = new Point(95, 12);
            _cboYear.Name = "_cboYear";
            _cboYear.Size = new Size(451, 21);
            _cboYear.TabIndex = 4;
            // 
            // LayoutControlGroup2
            // 
            LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup2.GroupBordersVisible = false;
            LayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, LayoutControlItem3, LayoutControlItem4, LayoutControlItem5, EmptySpaceItem1, EmptySpaceItem2, LayoutControlItem6, LayoutControlItem7 });
            LayoutControlGroup2.Location = new Point(0, 0);
            LayoutControlGroup2.Name = "LayoutControlGroup2";
            LayoutControlGroup2.Size = new Size(558, 206);
            LayoutControlGroup2.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _cboYear;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(538, 25);
            LayoutControlItem1.Text = "Year";
            LayoutControlItem1.TextSize = new Size(80, 13);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _cboTerm;
            LayoutControlItem2.Location = new Point(0, 25);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(538, 25);
            LayoutControlItem2.Text = "Term";
            LayoutControlItem2.TextSize = new Size(80, 13);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _cboExamName;
            LayoutControlItem3.Location = new Point(0, 50);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(538, 25);
            LayoutControlItem3.Text = "Exam Name";
            LayoutControlItem3.TextSize = new Size(80, 13);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = txtName;
            LayoutControlItem4.Location = new Point(0, 75);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(538, 24);
            LayoutControlItem4.Text = "New Exam Name";
            LayoutControlItem4.TextSize = new Size(80, 13);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = txtTotal;
            LayoutControlItem5.Location = new Point(0, 99);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(538, 24);
            LayoutControlItem5.Text = "Total";
            LayoutControlItem5.TextSize = new Size(80, 13);
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 123);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(454, 43);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 166);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(538, 20);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = _btnEdit;
            LayoutControlItem6.Location = new Point(500, 123);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(38, 43);
            LayoutControlItem6.TextSize = new Size(0, 0);
            LayoutControlItem6.TextVisible = false;
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = _btnDelete;
            LayoutControlItem7.Location = new Point(454, 123);
            LayoutControlItem7.Name = "LayoutControlItem7";
            LayoutControlItem7.Size = new Size(46, 43);
            LayoutControlItem7.TextSize = new Size(0, 0);
            LayoutControlItem7.TextVisible = false;
            // 
            // frmEditDeleteExam
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 206);
            Controls.Add(LayoutControl2);
            Name = "frmEditDeleteExam";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Exam";
            ((System.ComponentModel.ISupportInitialize)LayoutControl2).EndInit();
            LayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            Load += new EventHandler(frmEditDeleteExam_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl2;
        internal TextBox txtTotal;
        internal TextBox txtName;
        private ComboBox _cboExamName;

        internal ComboBox cboExamName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboExamName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboExamName != null)
                {
                    _cboExamName.SelectedIndexChanged -= cboExamName_SelectedIndexChanged;
                }

                _cboExamName = value;
                if (_cboExamName != null)
                {
                    _cboExamName.SelectedIndexChanged += cboExamName_SelectedIndexChanged;
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

        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton _btnDelete;

        internal DevExpress.XtraEditors.SimpleButton btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _btnEdit;

        internal DevExpress.XtraEditors.SimpleButton btnEdit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEdit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEdit != null)
                {
                    _btnEdit.Click -= btnEdit_Click;
                }

                _btnEdit = value;
                if (_btnEdit != null)
                {
                    _btnEdit.Click += btnEdit_Click;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
    }
}