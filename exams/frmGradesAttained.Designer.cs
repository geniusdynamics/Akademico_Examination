using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmGradesAttained : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGradesAttained));
            GroupBox1 = new GroupBox();
            dgvSubjects = new DataGridView();
            lblTitle = new Label();
            _btnPrint = new Button();
            _btnPrint.Click += new EventHandler(btnPrint_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            printpreview = new PrintPreviewDialog();
            pbar = new ProgressBar();
            _cboStream = new ComboBox();
            _cboStream.SelectedIndexChanged += new EventHandler(cboStream_SelectedIndexChanged);
            Label1 = new Label();
            _btnPrintPreview = new Button();
            _btnPrintPreview.Click += new EventHandler(btnPrintPreview_Click);
            GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(dgvSubjects);
            GroupBox1.Location = new Point(32, 100);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(1077, 404);
            GroupBox1.TabIndex = 18;
            GroupBox1.TabStop = false;
            // 
            // dgvSubjects
            // 
            dgvSubjects.AllowUserToAddRows = false;
            dgvSubjects.AllowUserToDeleteRows = false;
            dgvSubjects.AllowUserToResizeColumns = false;
            dgvSubjects.BackgroundColor = SystemColors.Info;
            dgvSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubjects.Dock = DockStyle.Fill;
            dgvSubjects.GridColor = Color.IndianRed;
            dgvSubjects.Location = new Point(3, 17);
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubjects.Size = new Size(1071, 384);
            dgvSubjects.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = SystemColors.Control;
            lblTitle.Font = new Font("Arial", 11.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            lblTitle.Location = new Point(23, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1097, 38);
            lblTitle.TabIndex = 21;
            lblTitle.Text = "SUBJECT GRADES ATTAINED ANALYSIS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            _btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            _btnPrint.Location = new Point(1023, 510);
            _btnPrint.Name = "_btnPrint";
            _btnPrint.Size = new Size(83, 39);
            _btnPrint.TabIndex = 19;
            _btnPrint.Text = "&Print";
            _btnPrint.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(850, 510);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(70, 39);
            _btnCancel.TabIndex = 20;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
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
            // pbar
            // 
            pbar.Location = new Point(32, 78);
            pbar.Name = "pbar";
            pbar.Size = new Size(1077, 23);
            pbar.TabIndex = 25;
            pbar.Visible = false;
            // 
            // cboStream
            // 
            _cboStream.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStream.FormattingEnabled = true;
            _cboStream.Location = new Point(100, 53);
            _cboStream.Name = "_cboStream";
            _cboStream.Size = new Size(248, 21);
            _cboStream.TabIndex = 24;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(47, 56);
            Label1.Name = "Label1";
            Label1.Size = new Size(45, 13);
            Label1.TabIndex = 23;
            Label1.Text = "Stream:";
            // 
            // btnPrintPreview
            // 
            _btnPrintPreview.Image = (Image)resources.GetObject("btnPrintPreview.Image");
            _btnPrintPreview.Location = new Point(930, 510);
            _btnPrintPreview.Name = "_btnPrintPreview";
            _btnPrintPreview.Size = new Size(83, 39);
            _btnPrintPreview.TabIndex = 22;
            _btnPrintPreview.Text = "&Preview";
            _btnPrintPreview.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnPrintPreview.UseVisualStyleBackColor = true;
            // 
            // frmGradesAttained
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 558);
            Controls.Add(GroupBox1);
            Controls.Add(lblTitle);
            Controls.Add(_btnPrint);
            Controls.Add(_btnCancel);
            Controls.Add(pbar);
            Controls.Add(_cboStream);
            Controls.Add(Label1);
            Controls.Add(_btnPrintPreview);
            Name = "frmGradesAttained";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subject Results Analysis";
            GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            Load += new EventHandler(frmGradesAttained_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal GroupBox GroupBox1;
        internal DataGridView dgvSubjects;
        internal Label lblTitle;
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

        internal PrintPreviewDialog printpreview;
        internal ProgressBar pbar;
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

        internal Label Label1;
        private Button _btnPrintPreview;

        internal Button btnPrintPreview
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
    }
}