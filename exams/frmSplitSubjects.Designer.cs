using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmSplitSubjects : DevExpress.XtraEditors.XtraForm
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
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _lstSubjects = new ListView();
            _lstSubjects.DoubleClick += new EventHandler(lstSubjects_SelectedIndexChanged);
            ColumnHeader1 = new ColumnHeader();
            ColumnHeader2 = new ColumnHeader();
            ColumnHeader3 = new ColumnHeader();
            ColumnHeader4 = new ColumnHeader();
            ColumnHeader5 = new ColumnHeader();
            ColumnHeader6 = new ColumnHeader();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_lstSubjects);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(869, 367);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // lstSubjects
            // 
            _lstSubjects.Columns.AddRange(new ColumnHeader[] { ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4, ColumnHeader5, ColumnHeader6 });
            _lstSubjects.GridLines = true;
            _lstSubjects.Location = new Point(12, 12);
            _lstSubjects.Name = "_lstSubjects";
            _lstSubjects.Size = new Size(845, 343);
            _lstSubjects.TabIndex = 4;
            _lstSubjects.UseCompatibleStateImageBehavior = false;
            _lstSubjects.View = View.Details;
            // 
            // ColumnHeader1
            // 
            ColumnHeader1.Text = "Class";
            ColumnHeader1.Width = 176;
            // 
            // ColumnHeader2
            // 
            ColumnHeader2.Text = "Parent Subject";
            ColumnHeader2.Width = 151;
            // 
            // ColumnHeader3
            // 
            ColumnHeader3.Text = "Name";
            ColumnHeader3.Width = 151;
            // 
            // ColumnHeader4
            // 
            ColumnHeader4.Text = "Abbreviation";
            ColumnHeader4.Width = 137;
            // 
            // ColumnHeader5
            // 
            ColumnHeader5.Text = "Contribution";
            ColumnHeader5.Width = 100;
            // 
            // ColumnHeader6
            // 
            ColumnHeader6.Text = "Weighted Contribution";
            ColumnHeader6.Width = 117;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(869, 367);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _lstSubjects;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(849, 347);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // frmSplitSubjects
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 367);
            Controls.Add(LayoutControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSplitSubjects";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Split Subjects";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            Load += new EventHandler(frmSplitSubjects_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        private ListView _lstSubjects;

        internal ListView lstSubjects
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lstSubjects;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lstSubjects != null)
                {
                    _lstSubjects.DoubleClick -= lstSubjects_SelectedIndexChanged;
                }

                _lstSubjects = value;
                if (_lstSubjects != null)
                {
                    _lstSubjects.DoubleClick += lstSubjects_SelectedIndexChanged;
                }
            }
        }

        internal ColumnHeader ColumnHeader1;
        internal ColumnHeader ColumnHeader2;
        internal ColumnHeader ColumnHeader3;
        internal ColumnHeader ColumnHeader4;
        internal ColumnHeader ColumnHeader5;
        internal ColumnHeader ColumnHeader6;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
    }
}