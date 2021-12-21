using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmSubjectsOutOf : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectsOutOf));
            LayoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            _Button1 = new DevExpress.XtraEditors.SimpleButton();
            _Button1.Click += new EventHandler(Button1_Click);
            dgvSubjects = new DataGridView();
            Abbreviation = new DataGridViewTextBoxColumn();
            Subject = new DataGridViewTextBoxColumn();
            Clas = new DataGridViewTextBoxColumn();
            Str = new DataGridViewTextBoxColumn();
            Marks = new DataGridViewTextBoxColumn();
            LayoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl2).BeginInit();
            LayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl2
            // 
            LayoutControl2.Controls.Add(_Button1);
            LayoutControl2.Controls.Add(dgvSubjects);
            LayoutControl2.Dock = DockStyle.Fill;
            LayoutControl2.Location = new Point(0, 0);
            LayoutControl2.Name = "LayoutControl2";
            LayoutControl2.Root = LayoutControlGroup2;
            LayoutControl2.Size = new Size(830, 495);
            LayoutControl2.TabIndex = 1;
            LayoutControl2.Text = "LayoutControl2";
            // 
            // Button1
            // 
            _Button1.Image = (Image)resources.GetObject("Button1.Image");
            _Button1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button1.Location = new Point(770, 444);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(48, 39);
            _Button1.StyleController = LayoutControl2;
            _Button1.TabIndex = 17;
            _Button1.Text = "Save";
            // 
            // dgvSubjects
            // 
            dgvSubjects.AllowUserToAddRows = false;
            dgvSubjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubjects.Columns.AddRange(new DataGridViewColumn[] { Abbreviation, Subject, Clas, Str, Marks });
            dgvSubjects.Location = new Point(12, 12);
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.Size = new Size(806, 428);
            dgvSubjects.TabIndex = 4;
            // 
            // Abbreviation
            // 
            Abbreviation.HeaderText = "SID";
            Abbreviation.Name = "Abbreviation";
            // 
            // Subject
            // 
            Subject.HeaderText = "Subject";
            Subject.Name = "Subject";
            // 
            // Clas
            // 
            Clas.HeaderText = "Class";
            Clas.Name = "Clas";
            // 
            // Str
            // 
            Str.HeaderText = "Stream";
            Str.Name = "Str";
            // 
            // Marks
            // 
            Marks.HeaderText = "Marks";
            Marks.Name = "Marks";
            // 
            // LayoutControlGroup2
            // 
            LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup2.GroupBordersVisible = false;
            LayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, EmptySpaceItem1, LayoutControlItem2 });
            LayoutControlGroup2.Location = new Point(0, 0);
            LayoutControlGroup2.Name = "LayoutControlGroup2";
            LayoutControlGroup2.Size = new Size(830, 495);
            LayoutControlGroup2.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = dgvSubjects;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(810, 432);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 432);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(758, 43);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _Button1;
            LayoutControlItem2.Location = new Point(758, 432);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(52, 43);
            LayoutControlItem2.TextSize = new Size(0, 0);
            LayoutControlItem2.TextVisible = false;
            // 
            // frmSubjectsOutOf
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 495);
            Controls.Add(LayoutControl2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSubjectsOutOf";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subjects Out Of";
            ((System.ComponentModel.ISupportInitialize)LayoutControl2).EndInit();
            LayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            Load += new EventHandler(frmSubjectsOutOf_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl2;
        internal DataGridView dgvSubjects;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton _Button1;

        internal DevExpress.XtraEditors.SimpleButton Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DataGridViewTextBoxColumn Abbreviation;
        internal DataGridViewTextBoxColumn Subject;
        internal DataGridViewTextBoxColumn Clas;
        internal DataGridViewTextBoxColumn Str;
        internal DataGridViewTextBoxColumn Marks;
    }
}