using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmBestStudentSubject : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBestStudentSubject));
            computeDVG = new DataGridView();
            resultDGV = new DataGridView();
            ADMNo = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            MarkAttained = new DataGridViewTextBoxColumn();
            GradeAttained = new DataGridViewTextBoxColumn();
            Points = new DataGridViewTextBoxColumn();
            _btnPrint = new Button();
            _btnPrint.Click += new EventHandler(btnPrint_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            ((System.ComponentModel.ISupportInitialize)computeDVG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resultDGV).BeginInit();
            SuspendLayout();
            // 
            // computeDVG
            // 
            computeDVG.AllowUserToAddRows = false;
            computeDVG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            computeDVG.Location = new Point(12, 616);
            computeDVG.Name = "computeDVG";
            computeDVG.RowTemplate.Height = 24;
            computeDVG.Size = new Size(1293, 42);
            computeDVG.TabIndex = 1;
            computeDVG.Visible = false;
            // 
            // resultDGV
            // 
            resultDGV.AllowUserToAddRows = false;
            resultDGV.AllowUserToDeleteRows = false;
            resultDGV.AllowUserToResizeColumns = false;
            resultDGV.AllowUserToResizeRows = false;
            resultDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultDGV.BackgroundColor = SystemColors.Info;
            resultDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultDGV.Columns.AddRange(new DataGridViewColumn[] { ADMNo, StudentName, Gender, MarkAttained, GradeAttained, Points });
            resultDGV.GridColor = Color.IndianRed;
            resultDGV.Location = new Point(12, 63);
            resultDGV.Margin = new Padding(3, 4, 3, 4);
            resultDGV.Name = "resultDGV";
            resultDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            resultDGV.Size = new Size(1311, 637);
            resultDGV.TabIndex = 2;
            // 
            // ADMNo
            // 
            ADMNo.HeaderText = "ADM No.";
            ADMNo.Name = "ADMNo";
            ADMNo.ReadOnly = true;
            ADMNo.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // StudentName
            // 
            StudentName.HeaderText = "Name of Student";
            StudentName.Name = "StudentName";
            StudentName.ReadOnly = true;
            StudentName.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // Gender
            // 
            Gender.HeaderText = "Gender";
            Gender.Name = "Gender";
            Gender.ReadOnly = true;
            // 
            // MarkAttained
            // 
            MarkAttained.HeaderText = "Marks";
            MarkAttained.Name = "MarkAttained";
            MarkAttained.ReadOnly = true;
            MarkAttained.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // GradeAttained
            // 
            GradeAttained.HeaderText = "Grade";
            GradeAttained.Name = "GradeAttained";
            GradeAttained.ReadOnly = true;
            GradeAttained.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // Points
            // 
            Points.HeaderText = "Points";
            Points.Name = "Points";
            Points.ReadOnly = true;
            // 
            // btnPrint
            // 
            _btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            _btnPrint.Location = new Point(1217, 13);
            _btnPrint.Margin = new Padding(3, 4, 3, 4);
            _btnPrint.Name = "_btnPrint";
            _btnPrint.Size = new Size(75, 44);
            _btnPrint.TabIndex = 19;
            _btnPrint.Text = "&Print";
            _btnPrint.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(1107, 13);
            _btnCancel.Margin = new Padding(3, 4, 3, 4);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(85, 44);
            _btnCancel.TabIndex = 20;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmBestStudentSubject
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1317, 713);
            ControlBox = false;
            Controls.Add(_btnPrint);
            Controls.Add(_btnCancel);
            Controls.Add(resultDGV);
            Controls.Add(computeDVG);
            MinimizeBox = false;
            Name = "frmBestStudentSubject";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Best Student Per Subject";
            ((System.ComponentModel.ISupportInitialize)computeDVG).EndInit();
            ((System.ComponentModel.ISupportInitialize)resultDGV).EndInit();
            Load += new EventHandler(frmBestStudentSubject_Load);
            ResumeLayout(false);
        }

        internal DataGridView computeDVG;
        internal DataGridView resultDGV;
        internal DataGridViewTextBoxColumn ADMNo;
        internal DataGridViewTextBoxColumn StudentName;
        internal DataGridViewTextBoxColumn Gender;
        internal DataGridViewTextBoxColumn MarkAttained;
        internal DataGridViewTextBoxColumn GradeAttained;
        internal DataGridViewTextBoxColumn Points;
        private Button _btnPrint;

        internal Button btnPrint
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrint;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrint != null)
                {
                    _btnPrint.Click -= btnPrint_Click;
                }

                _btnPrint = value;
                if (_btnPrint != null)
                {
                    _btnPrint.Click += btnPrint_Click;
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
    }
}