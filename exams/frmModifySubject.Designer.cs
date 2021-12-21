using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmModifySubject : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifySubject));
            Label3 = new Label();
            radOptional = new RadioButton();
            radCompulsory = new RadioButton();
            Label2 = new Label();
            Comment = new DataGridViewTextBoxColumn();
            Department = new DataGridViewTextBoxColumn();
            Code = new DataGridViewTextBoxColumn();
            Abbreviation = new DataGridViewTextBoxColumn();
            SubjectName = new DataGridViewTextBoxColumn();
            SubjID = new DataGridViewTextBoxColumn();
            _dgvSubjects = new DataGridView();
            _dgvSubjects.CellEnter += new DataGridViewCellEventHandler(dgvSubjects_CellEnter);
            _dgvSubjects.Click += new EventHandler(dgvSubjects_Click);
            txtCode = new TextBox();
            GroupBox1 = new GroupBox();
            cboDepartment = new ComboBox();
            txtAbbreviation = new TextBox();
            Label1 = new Label();
            txtName = new TextBox();
            Label10 = new Label();
            Label7 = new Label();
            _btnUpdate = new Button();
            _btnUpdate.Click += new EventHandler(btnUpdate_Click);
            _btnClear = new Button();
            _btnClear.Click += new EventHandler(btnClear_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            ((System.ComponentModel.ISupportInitialize)_dgvSubjects).BeginInit();
            GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(10, 435);
            Label3.Name = "Label3";
            Label3.Size = new Size(75, 13);
            Label3.TabIndex = 48;
            Label3.Text = "Subject Code:";
            // 
            // radOptional
            // 
            radOptional.AutoSize = true;
            radOptional.Location = new Point(210, 459);
            radOptional.Name = "radOptional";
            radOptional.Size = new Size(65, 17);
            radOptional.TabIndex = 39;
            radOptional.TabStop = true;
            radOptional.Text = "Optional";
            radOptional.UseVisualStyleBackColor = true;
            // 
            // radCompulsory
            // 
            radCompulsory.AutoSize = true;
            radCompulsory.Location = new Point(96, 459);
            radCompulsory.Name = "radCompulsory";
            radCompulsory.Size = new Size(81, 17);
            radCompulsory.TabIndex = 38;
            radCompulsory.TabStop = true;
            radCompulsory.Text = "Compulsory";
            radCompulsory.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(27, 459);
            Label2.Name = "Label2";
            Label2.Size = new Size(56, 13);
            Label2.TabIndex = 46;
            Label2.Text = "Comment:";
            // 
            // Comment
            // 
            Comment.HeaderText = "Comment";
            Comment.Name = "Comment";
            Comment.ReadOnly = true;
            // 
            // Department
            // 
            Department.HeaderText = "Department";
            Department.Name = "Department";
            Department.ReadOnly = true;
            Department.Width = 150;
            // 
            // Code
            // 
            Code.HeaderText = "Code";
            Code.Name = "Code";
            Code.ReadOnly = true;
            // 
            // Abbreviation
            // 
            Abbreviation.HeaderText = "Abbreviation";
            Abbreviation.Name = "Abbreviation";
            // 
            // SubjectName
            // 
            SubjectName.HeaderText = "Name of Subject";
            SubjectName.Name = "SubjectName";
            SubjectName.ReadOnly = true;
            SubjectName.Width = 200;
            // 
            // SubjID
            // 
            SubjID.HeaderText = "Subject ID";
            SubjID.Name = "SubjID";
            SubjID.ReadOnly = true;
            SubjID.Visible = false;
            // 
            // dgvSubjects
            // 
            _dgvSubjects.AllowUserToAddRows = false;
            _dgvSubjects.AllowUserToDeleteRows = false;
            _dgvSubjects.AllowUserToResizeColumns = false;
            _dgvSubjects.AllowUserToResizeRows = false;
            _dgvSubjects.BackgroundColor = SystemColors.Info;
            _dgvSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvSubjects.Columns.AddRange(new DataGridViewColumn[] { SubjID, SubjectName, Abbreviation, Code, Department, Comment });
            _dgvSubjects.Dock = DockStyle.Fill;
            _dgvSubjects.GridColor = Color.RosyBrown;
            _dgvSubjects.Location = new Point(3, 17);
            _dgvSubjects.MultiSelect = false;
            _dgvSubjects.Name = "_dgvSubjects";
            _dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvSubjects.Size = new Size(695, 355);
            _dgvSubjects.TabIndex = 1;
            // 
            // txtCode
            // 
            txtCode.BackColor = SystemColors.Info;
            txtCode.ForeColor = Color.RosyBrown;
            txtCode.Location = new Point(95, 432);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(227, 21);
            txtCode.TabIndex = 47;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(_dgvSubjects);
            GroupBox1.Location = new Point(12, 12);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(701, 375);
            GroupBox1.TabIndex = 34;
            GroupBox1.TabStop = false;
            // 
            // cboDepartment
            // 
            cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartment.FormattingEnabled = true;
            cboDepartment.Items.AddRange(new object[] { "None" });
            cboDepartment.Location = new Point(455, 432);
            cboDepartment.Name = "cboDepartment";
            cboDepartment.Size = new Size(258, 21);
            cboDepartment.TabIndex = 37;
            // 
            // txtAbbreviation
            // 
            txtAbbreviation.Location = new Point(455, 405);
            txtAbbreviation.Name = "txtAbbreviation";
            txtAbbreviation.Size = new Size(258, 21);
            txtAbbreviation.TabIndex = 36;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(373, 408);
            Label1.Name = "Label1";
            Label1.Size = new Size(72, 13);
            Label1.TabIndex = 44;
            Label1.Text = "Abbreviation:";
            // 
            // txtName
            // 
            txtName.Location = new Point(95, 405);
            txtName.Name = "txtName";
            txtName.Size = new Size(227, 21);
            txtName.TabIndex = 35;
            // 
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.Location = new Point(10, 408);
            Label10.Name = "Label10";
            Label10.Size = new Size(77, 13);
            Label10.TabIndex = 45;
            Label10.Text = "Subject Name:";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Location = new Point(365, 435);
            Label7.Name = "Label7";
            Label7.Size = new Size(79, 13);
            Label7.TabIndex = 43;
            Label7.Text = "Subject Group:";
            // 
            // btnUpdate
            // 
            _btnUpdate.Image = (Image)resources.GetObject("btnUpdate.Image");
            _btnUpdate.Location = new Point(642, 459);
            _btnUpdate.Name = "_btnUpdate";
            _btnUpdate.Size = new Size(71, 28);
            _btnUpdate.TabIndex = 40;
            _btnUpdate.Text = "&Update";
            _btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            _btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            _btnClear.Location = new Point(561, 459);
            _btnClear.Name = "_btnClear";
            _btnClear.Size = new Size(63, 28);
            _btnClear.TabIndex = 41;
            _btnClear.Text = "C&lear";
            _btnClear.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnClear.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(469, 459);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(72, 28);
            _btnCancel.TabIndex = 42;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmModifySubject
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 502);
            Controls.Add(Label3);
            Controls.Add(radOptional);
            Controls.Add(radCompulsory);
            Controls.Add(Label2);
            Controls.Add(txtCode);
            Controls.Add(GroupBox1);
            Controls.Add(_btnUpdate);
            Controls.Add(_btnClear);
            Controls.Add(_btnCancel);
            Controls.Add(cboDepartment);
            Controls.Add(txtAbbreviation);
            Controls.Add(Label1);
            Controls.Add(txtName);
            Controls.Add(Label10);
            Controls.Add(Label7);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmModifySubject";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modify Subject";
            ((System.ComponentModel.ISupportInitialize)_dgvSubjects).EndInit();
            GroupBox1.ResumeLayout(false);
            Load += new EventHandler(frmModifySubject_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label Label3;
        internal RadioButton radOptional;
        internal RadioButton radCompulsory;
        internal Label Label2;
        internal DataGridViewTextBoxColumn Comment;
        internal DataGridViewTextBoxColumn Department;
        internal DataGridViewTextBoxColumn Code;
        internal DataGridViewTextBoxColumn Abbreviation;
        internal DataGridViewTextBoxColumn SubjectName;
        internal DataGridViewTextBoxColumn SubjID;
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
                    _dgvSubjects.CellEnter -= dgvSubjects_CellEnter;
                    _dgvSubjects.Click -= dgvSubjects_Click;
                }

                _dgvSubjects = value;
                if (_dgvSubjects != null)
                {
                    _dgvSubjects.CellEnter += dgvSubjects_CellEnter;
                    _dgvSubjects.Click += dgvSubjects_Click;
                }
            }
        }

        internal TextBox txtCode;
        internal GroupBox GroupBox1;
        private Button _btnUpdate;

        internal Button btnUpdate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdate != null)
                {
                    _btnUpdate.Click -= btnUpdate_Click;
                }

                _btnUpdate = value;
                if (_btnUpdate != null)
                {
                    _btnUpdate.Click += btnUpdate_Click;
                }
            }
        }

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

        internal ComboBox cboDepartment;
        internal TextBox txtAbbreviation;
        internal Label Label1;
        internal TextBox txtName;
        internal Label Label10;
        internal Label Label7;
    }
}