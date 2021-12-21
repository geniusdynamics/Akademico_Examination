using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmAllStudents : DevExpress.XtraEditors.XtraForm
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
            LayoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            _dgvStudents = new DataGridView();
            _dgvStudents.DoubleClick += new EventHandler(dgvStudents_DoubleClick);
            ADMNo = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            LayoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl2).BeginInit();
            LayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl2
            // 
            LayoutControl2.Controls.Add(_dgvStudents);
            LayoutControl2.Dock = DockStyle.Fill;
            LayoutControl2.Location = new Point(0, 0);
            LayoutControl2.Name = "LayoutControl2";
            LayoutControl2.Root = LayoutControlGroup2;
            LayoutControl2.Size = new Size(533, 479);
            LayoutControl2.TabIndex = 1;
            LayoutControl2.Text = "LayoutControl2";
            // 
            // dgvStudents
            // 
            _dgvStudents.AllowUserToAddRows = false;
            _dgvStudents.AllowUserToDeleteRows = false;
            _dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvStudents.Columns.AddRange(new DataGridViewColumn[] { ADMNo, StudentName });
            _dgvStudents.Location = new Point(12, 12);
            _dgvStudents.Name = "_dgvStudents";
            _dgvStudents.Size = new Size(509, 455);
            _dgvStudents.TabIndex = 4;
            // 
            // ADMNo
            // 
            ADMNo.HeaderText = "Admission Number";
            ADMNo.Name = "ADMNo";
            // 
            // StudentName
            // 
            StudentName.HeaderText = "Name Of Student";
            StudentName.Name = "StudentName";
            // 
            // LayoutControlGroup2
            // 
            LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup2.GroupBordersVisible = false;
            LayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1 });
            LayoutControlGroup2.Location = new Point(0, 0);
            LayoutControlGroup2.Name = "LayoutControlGroup2";
            LayoutControlGroup2.Size = new Size(533, 479);
            LayoutControlGroup2.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _dgvStudents;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(513, 459);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // frmAllStudents
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 479);
            Controls.Add(LayoutControl2);
            Name = "frmAllStudents";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "List Of Students";
            ((System.ComponentModel.ISupportInitialize)LayoutControl2).EndInit();
            LayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            Load += new EventHandler(frmAllStudents_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl2;
        private DataGridView _dgvStudents;

        internal DataGridView dgvStudents
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvStudents;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvStudents != null)
                {
                    _dgvStudents.DoubleClick -= dgvStudents_DoubleClick;
                }

                _dgvStudents = value;
                if (_dgvStudents != null)
                {
                    _dgvStudents.DoubleClick += dgvStudents_DoubleClick;
                }
            }
        }

        internal DataGridViewTextBoxColumn ADMNo;
        internal DataGridViewTextBoxColumn StudentName;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
    }
}