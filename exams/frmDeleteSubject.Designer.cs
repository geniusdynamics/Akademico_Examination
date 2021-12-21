using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmDeleteSubject : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeleteSubject));
            GroupBox1 = new GroupBox();
            _dgvSubjects = new DataGridView();
            _dgvSubjects.DoubleClick += new EventHandler(dgvSubjects_DoubleClick);
            SubjID = new DataGridViewTextBoxColumn();
            SubjectName = new DataGridViewTextBoxColumn();
            Abbreviation = new DataGridViewTextBoxColumn();
            Department = new DataGridViewTextBoxColumn();
            pbar = new ProgressBar();
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvSubjects).BeginInit();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(_dgvSubjects);
            GroupBox1.Location = new Point(12, 12);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(653, 426);
            GroupBox1.TabIndex = 5;
            GroupBox1.TabStop = false;
            // 
            // dgvSubjects
            // 
            _dgvSubjects.AllowUserToAddRows = false;
            _dgvSubjects.AllowUserToDeleteRows = false;
            _dgvSubjects.AllowUserToResizeColumns = false;
            _dgvSubjects.AllowUserToResizeRows = false;
            _dgvSubjects.BackgroundColor = SystemColors.Info;
            _dgvSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvSubjects.Columns.AddRange(new DataGridViewColumn[] { SubjID, SubjectName, Abbreviation, Department });
            _dgvSubjects.Dock = DockStyle.Fill;
            _dgvSubjects.GridColor = Color.RosyBrown;
            _dgvSubjects.Location = new Point(3, 17);
            _dgvSubjects.Name = "_dgvSubjects";
            _dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvSubjects.Size = new Size(647, 406);
            _dgvSubjects.TabIndex = 1;
            // 
            // SubjID
            // 
            SubjID.HeaderText = "Subject ID";
            SubjID.Name = "SubjID";
            SubjID.ReadOnly = true;
            // 
            // SubjectName
            // 
            SubjectName.HeaderText = "Name of Subject";
            SubjectName.Name = "SubjectName";
            SubjectName.ReadOnly = true;
            SubjectName.Width = 200;
            // 
            // Abbreviation
            // 
            Abbreviation.HeaderText = "Abbreviation";
            Abbreviation.Name = "Abbreviation";
            Abbreviation.ReadOnly = true;
            // 
            // Department
            // 
            Department.HeaderText = "Department";
            Department.Name = "Department";
            Department.ReadOnly = true;
            Department.Width = 200;
            // 
            // pbar
            // 
            pbar.Location = new Point(15, 438);
            pbar.Name = "pbar";
            pbar.Size = new Size(650, 18);
            pbar.TabIndex = 8;
            pbar.Visible = false;
            // 
            // btnDelete
            // 
            _btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            _btnDelete.Location = new Point(536, 458);
            _btnDelete.Name = "_btnDelete";
            _btnDelete.Size = new Size(126, 25);
            _btnDelete.TabIndex = 6;
            _btnDelete.Text = "&Delete Subject";
            _btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(449, 458);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(69, 25);
            _btnCancel.TabIndex = 7;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmDeleteSubject
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(673, 494);
            Controls.Add(_btnDelete);
            Controls.Add(GroupBox1);
            Controls.Add(pbar);
            Controls.Add(_btnCancel);
            Name = "frmDeleteSubject";
            Text = "Delete Subject";
            GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvSubjects).EndInit();
            Load += new EventHandler(frmDeleteSubject_Load);
            ResumeLayout(false);
        }

        private Button _btnDelete;

        internal Button btnDelete
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

        internal GroupBox GroupBox1;
        private DataGridView _dgvSubjects;

        internal DataGridView dgvSubjects
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvSubjects;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvSubjects != null)
                {
                    _dgvSubjects.DoubleClick -= dgvSubjects_DoubleClick;
                }

                _dgvSubjects = value;
                if (_dgvSubjects != null)
                {
                    _dgvSubjects.DoubleClick += dgvSubjects_DoubleClick;
                }
            }
        }

        internal DataGridViewTextBoxColumn SubjID;
        internal DataGridViewTextBoxColumn SubjectName;
        internal DataGridViewTextBoxColumn Abbreviation;
        internal DataGridViewTextBoxColumn Department;
        internal ProgressBar pbar;
        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }
    }
}