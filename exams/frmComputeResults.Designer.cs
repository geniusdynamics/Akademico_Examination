using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmComputeResults : Form
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComputeResults));
            dgvMeanMarks = new DataGridView();
            ADMNo = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewImageColumn();
            Column2 = new DataGridViewImageColumn();
            Column3 = new DataGridViewImageColumn();
            Column4 = new DataGridViewImageColumn();
            _chkMarksGrade = new CheckBox();
            _chkMarksGrade.CheckedChanged += new EventHandler(chkMarksGrade_CheckedChanged);
            _btnIndexing = new DevExpress.XtraEditors.SimpleButton();
            _btnIndexing.Click += new EventHandler(btnIndexing_Click);
            _Button3 = new DevExpress.XtraEditors.SimpleButton();
            _Button3.Click += new EventHandler(Button3_Click);
            _chkMode = new CheckBox();
            _chkMode.CheckedChanged += new EventHandler(chkMode_CheckedChanged);
            _Button4 = new DevExpress.XtraEditors.SimpleButton();
            _Button4.Click += new EventHandler(Button4_Click);
            printpreview = new PrintPreviewDialog();
            Timer1 = new Timer(components);
            Timer2 = new Timer(components);
            _btnClassPerformance = new DevExpress.XtraEditors.SimpleButton();
            _btnClassPerformance.Click += new EventHandler(btnClassPerformance_Click);
            _btnStreamPerformance = new DevExpress.XtraEditors.SimpleButton();
            _btnStreamPerformance.Click += new EventHandler(btnStreamPerformance_Click);
            radSubject = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvMeanMarks).BeginInit();
            SuspendLayout();
            // 
            // dgvMeanMarks
            // 
            dgvMeanMarks.AllowUserToAddRows = false;
            dgvMeanMarks.AllowUserToDeleteRows = false;
            dgvMeanMarks.AllowUserToOrderColumns = true;
            dgvMeanMarks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMeanMarks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeanMarks.Columns.AddRange(new DataGridViewColumn[] { ADMNo, StudentName, Column1, Column2, Column3, Column4 });
            dgvMeanMarks.Location = new Point(3, 3);
            dgvMeanMarks.Name = "dgvMeanMarks";
            dgvMeanMarks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMeanMarks.Size = new Size(1142, 448);
            dgvMeanMarks.TabIndex = 5;
            // 
            // ADMNo
            // 
            ADMNo.HeaderText = "ADM.";
            ADMNo.Name = "ADMNo";
            ADMNo.Width = 59;
            // 
            // StudentName
            // 
            StudentName.HeaderText = "Name Of Student";
            StudentName.Name = "StudentName";
            StudentName.Width = 105;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.Visible = false;
            Column1.Width = 54;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            Column2.Visible = false;
            Column2.Width = 54;
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            Column3.Visible = false;
            Column3.Width = 54;
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            Column4.Visible = false;
            Column4.Width = 54;
            // 
            // chkMarksGrade
            // 
            _chkMarksGrade.Location = new Point(12, 486);
            _chkMarksGrade.Name = "_chkMarksGrade";
            _chkMarksGrade.Size = new Size(128, 20);
            _chkMarksGrade.TabIndex = 9;
            _chkMarksGrade.Text = "Show Marks + Grade";
            _chkMarksGrade.UseVisualStyleBackColor = true;
            // 
            // btnIndexing
            // 
            _btnIndexing.ImageOptions.Image = (Image)resources.GetObject("btnIndexing.ImageOptions.Image");
            _btnIndexing.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnIndexing.Location = new Point(146, 473);
            _btnIndexing.Name = "_btnIndexing";
            _btnIndexing.Size = new Size(135, 39);
            _btnIndexing.TabIndex = 14;
            _btnIndexing.Text = "Use Analysis For Indexing";
            // 
            // Button3
            // 
            _Button3.ImageOptions.Image = (Image)resources.GetObject("Button3.ImageOptions.Image");
            _Button3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button3.Location = new Point(300, 473);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(122, 39);
            _Button3.TabIndex = 15;
            _Button3.Text = "Export To Excel";
            // 
            // chkMode
            // 
            _chkMode.Location = new Point(443, 492);
            _chkMode.Name = "_chkMode";
            _chkMode.Size = new Size(128, 20);
            _chkMode.TabIndex = 16;
            _chkMode.Text = "Best Of 7";
            _chkMode.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            _Button4.ImageOptions.Image = (Image)resources.GetObject("Button4.ImageOptions.Image");
            _Button4.Location = new Point(898, 471);
            _Button4.Name = "_Button4";
            _Button4.Size = new Size(179, 41);
            _Button4.TabIndex = 17;
            _Button4.Text = "Save Examination Performance";
            _Button4.Visible = false;
            // 
            // printpreview
            // 
            printpreview.AutoScrollMargin = new Size(0, 0);
            printpreview.AutoScrollMinSize = new Size(0, 0);
            printpreview.ClientSize = new Size(400, 300);
            printpreview.Enabled = true;
            printpreview.Icon = (Icon)resources.GetObject("printpreview.Icon");
            printpreview.Name = "printpreview";
            printpreview.Visible = false;
            // 
            // btnClassPerformance
            // 
            _btnClassPerformance.ImageOptions.Image = (Image)resources.GetObject("btnClassPerformance.ImageOptions.Image");
            _btnClassPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnClassPerformance.Location = new Point(528, 473);
            _btnClassPerformance.Name = "_btnClassPerformance";
            _btnClassPerformance.Size = new Size(138, 39);
            _btnClassPerformance.TabIndex = 19;
            _btnClassPerformance.Text = "&Class Merit List";
            // 
            // btnStreamPerformance
            // 
            _btnStreamPerformance.ImageOptions.Image = (Image)resources.GetObject("btnStreamPerformance.ImageOptions.Image");
            _btnStreamPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnStreamPerformance.Location = new Point(685, 473);
            _btnStreamPerformance.Name = "_btnStreamPerformance";
            _btnStreamPerformance.Size = new Size(128, 39);
            _btnStreamPerformance.TabIndex = 20;
            _btnStreamPerformance.Text = "&Stream Merit List";
            // 
            // radSubject
            // 
            radSubject.Checked = true;
            radSubject.CheckState = CheckState.Checked;
            radSubject.Location = new Point(819, 482);
            radSubject.Name = "radSubject";
            radSubject.Size = new Size(73, 20);
            radSubject.TabIndex = 21;
            radSubject.Text = "Use Subject Grading";
            radSubject.UseVisualStyleBackColor = true;
            radSubject.Visible = false;
            // 
            // frmComputeResults
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1149, 524);
            Controls.Add(radSubject);
            Controls.Add(_btnStreamPerformance);
            Controls.Add(_btnClassPerformance);
            Controls.Add(_Button4);
            Controls.Add(_chkMode);
            Controls.Add(_Button3);
            Controls.Add(_btnIndexing);
            Controls.Add(_chkMarksGrade);
            Controls.Add(dgvMeanMarks);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmComputeResults";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exam Result Analysis";
            ((System.ComponentModel.ISupportInitialize)dgvMeanMarks).EndInit();
            Load += new EventHandler(frmComputeResults_Load_1);
            ResumeLayout(false);
        }

        internal DataGridView dgvMeanMarks;
        internal DataGridViewTextBoxColumn ADMNo;
        internal DataGridViewTextBoxColumn StudentName;
        internal DataGridViewImageColumn Column1;
        internal DataGridViewImageColumn Column2;
        internal DataGridViewImageColumn Column3;
        internal DataGridViewImageColumn Column4;
        private CheckBox _chkMarksGrade;

        internal CheckBox chkMarksGrade
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkMarksGrade;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkMarksGrade != null)
                {
                    _chkMarksGrade.CheckedChanged -= chkMarksGrade_CheckedChanged;
                }

                _chkMarksGrade = value;
                if (_chkMarksGrade != null)
                {
                    _chkMarksGrade.CheckedChanged += chkMarksGrade_CheckedChanged;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _btnIndexing;

        internal DevExpress.XtraEditors.SimpleButton btnIndexing
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnIndexing;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnIndexing != null)
                {
                    _btnIndexing.Click -= btnIndexing_Click;
                }

                _btnIndexing = value;
                if (_btnIndexing != null)
                {
                    _btnIndexing.Click += btnIndexing_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _Button3;

        internal DevExpress.XtraEditors.SimpleButton Button3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button3 != null)
                {
                    _Button3.Click -= Button3_Click;
                }

                _Button3 = value;
                if (_Button3 != null)
                {
                    _Button3.Click += Button3_Click;
                }
            }
        }

        private CheckBox _chkMode;

        internal CheckBox chkMode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkMode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkMode != null)
                {
                    _chkMode.CheckedChanged -= chkMode_CheckedChanged;
                }

                _chkMode = value;
                if (_chkMode != null)
                {
                    _chkMode.CheckedChanged += chkMode_CheckedChanged;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _Button4;

        internal DevExpress.XtraEditors.SimpleButton Button4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button4 != null)
                {
                    _Button4.Click -= Button4_Click;
                }

                _Button4 = value;
                if (_Button4 != null)
                {
                    _Button4.Click += Button4_Click;
                }
            }
        }

        internal PrintPreviewDialog printpreview;
        internal Timer Timer1;
        internal Timer Timer2;
        private DevExpress.XtraEditors.SimpleButton _btnClassPerformance;

        internal DevExpress.XtraEditors.SimpleButton btnClassPerformance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClassPerformance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClassPerformance != null)
                {
                    _btnClassPerformance.Click -= btnClassPerformance_Click;
                }

                _btnClassPerformance = value;
                if (_btnClassPerformance != null)
                {
                    _btnClassPerformance.Click += btnClassPerformance_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _btnStreamPerformance;

        internal DevExpress.XtraEditors.SimpleButton btnStreamPerformance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnStreamPerformance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnStreamPerformance != null)
                {
                    _btnStreamPerformance.Click -= btnStreamPerformance_Click;
                }

                _btnStreamPerformance = value;
                if (_btnStreamPerformance != null)
                {
                    _btnStreamPerformance.Click += btnStreamPerformance_Click;
                }
            }
        }

        internal CheckBox radSubject;
    }
}