using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmNationalGradesAttained : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNationalGradesAttained));
            dgvSubjects = new DataGridView();
            GroupBox1 = new GroupBox();
            printpreview = new PrintPreviewDialog();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            Label1 = new Label();
            _ComboBox1 = new ComboBox();
            _ComboBox1.SelectedIndexChanged += new EventHandler(ComboBox1_SelectedIndexChanged);
            _btnPrintPreview = new Button();
            _btnPrintPreview.Click += new EventHandler(btnPrintPreview_Click);
            _btnPrint = new Button();
            _btnPrint.Click += new EventHandler(btnPrint_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
            GroupBox1.SuspendLayout();
            SuspendLayout();
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
            dgvSubjects.Size = new Size(1071, 420);
            dgvSubjects.TabIndex = 0;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(dgvSubjects);
            GroupBox1.Location = new Point(20, 55);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(1077, 440);
            GroupBox1.TabIndex = 18;
            GroupBox1.TabStop = false;
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
            // Button1
            // 
            _Button1.Location = new Point(991, 501);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(105, 23);
            _Button1.TabIndex = 24;
            _Button1.Text = "&Save Performance";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(54, 15);
            Label1.Name = "Label1";
            Label1.Size = new Size(45, 13);
            Label1.TabIndex = 23;
            Label1.Text = "Stream:";
            // 
            // ComboBox1
            // 
            _ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            _ComboBox1.FormattingEnabled = true;
            _ComboBox1.Location = new Point(104, 12);
            _ComboBox1.Name = "_ComboBox1";
            _ComboBox1.Size = new Size(121, 21);
            _ComboBox1.TabIndex = 22;
            // 
            // btnPrintPreview
            // 
            _btnPrintPreview.Image = (Image)resources.GetObject("btnPrintPreview.Image");
            _btnPrintPreview.Location = new Point(852, 501);
            _btnPrintPreview.Name = "_btnPrintPreview";
            _btnPrintPreview.Size = new Size(67, 24);
            _btnPrintPreview.TabIndex = 21;
            _btnPrintPreview.Text = "&Preview";
            _btnPrintPreview.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnPrintPreview.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            _btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            _btnPrint.Location = new Point(925, 501);
            _btnPrint.Name = "_btnPrint";
            _btnPrint.Size = new Size(60, 24);
            _btnPrint.TabIndex = 19;
            _btnPrint.Text = "&Print";
            _btnPrint.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(776, 501);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(70, 24);
            _btnCancel.TabIndex = 20;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmNationalGradesAttained
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 543);
            Controls.Add(GroupBox1);
            Controls.Add(_Button1);
            Controls.Add(Label1);
            Controls.Add(_ComboBox1);
            Controls.Add(_btnPrintPreview);
            Controls.Add(_btnPrint);
            Controls.Add(_btnCancel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNationalGradesAttained";
            Text = "frmNationalGradesAttained";
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            GroupBox1.ResumeLayout(false);
            Load += new EventHandler(frmGradesAttained_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal DataGridView dgvSubjects;
        internal GroupBox GroupBox1;
        internal PrintPreviewDialog printpreview;
        private Button _Button1;

        internal Button Button1
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

        internal Label Label1;
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