using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmMeanResults : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeanResults));
            dgvMeanMarks = new DataGridView();
            ADMNo = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewImageColumn();
            Column2 = new DataGridViewImageColumn();
            Column3 = new DataGridViewImageColumn();
            Column4 = new DataGridViewImageColumn();
            _chkMode = new CheckBox();
            _chkMode.CheckedChanged += new EventHandler(chkMode_CheckedChanged);
            _marksGrade = new CheckBox();
            _marksGrade.CheckedChanged += new EventHandler(marksGrade_CheckedChanged);
            Timer1 = new Timer(components);
            radSubject = new CheckBox();
            frmMeanResultsLayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            SimpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            _Button4 = new DevExpress.XtraEditors.SimpleButton();
            _Button4.Click += new EventHandler(Button4_Click);
            _btnStreamPerformance = new DevExpress.XtraEditors.SimpleButton();
            _btnStreamPerformance.Click += new EventHandler(btnStreamPerformance_Click);
            _btnClassPerformance = new DevExpress.XtraEditors.SimpleButton();
            _btnClassPerformance.Click += new EventHandler(btnClassPerformance_Click);
            _Button3 = new DevExpress.XtraEditors.SimpleButton();
            _Button3.Click += new EventHandler(Button3_Click);
            _Button6 = new DevExpress.XtraEditors.SimpleButton();
            _Button6.Click += new EventHandler(Button6_Click);
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)dgvMeanMarks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)frmMeanResultsLayoutControl1ConvertedLayout).BeginInit();
            frmMeanResultsLayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SimpleSeparator1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).BeginInit();
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
            dgvMeanMarks.Location = new Point(16, 16);
            dgvMeanMarks.Margin = new Padding(4, 4, 4, 4);
            dgvMeanMarks.Name = "dgvMeanMarks";
            dgvMeanMarks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMeanMarks.Size = new Size(1503, 336);
            dgvMeanMarks.TabIndex = 5;
            // 
            // ADMNo
            // 
            ADMNo.HeaderText = "ADM.";
            ADMNo.Name = "ADMNo";
            ADMNo.Width = 71;
            // 
            // StudentName
            // 
            StudentName.HeaderText = "Name Of Student";
            StudentName.Name = "StudentName";
            StudentName.Width = 134;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.Visible = false;
            Column1.Width = 69;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            Column2.Visible = false;
            Column2.Width = 69;
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            Column3.Visible = false;
            Column3.Width = 69;
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            Column4.Visible = false;
            Column4.Width = 69;
            // 
            // chkMode
            // 
            _chkMode.Location = new Point(448, 358);
            _chkMode.Margin = new Padding(4, 4, 4, 4);
            _chkMode.Name = "_chkMode";
            _chkMode.Size = new Size(209, 25);
            _chkMode.TabIndex = 16;
            _chkMode.Text = "Best Of 7";
            _chkMode.UseVisualStyleBackColor = true;
            // 
            // marksGrade
            // 
            _marksGrade.Location = new Point(663, 408);
            _marksGrade.Margin = new Padding(4, 4, 4, 4);
            _marksGrade.Name = "_marksGrade";
            _marksGrade.Size = new Size(425, 25);
            _marksGrade.TabIndex = 18;
            _marksGrade.Text = "Show Marks + Grade";
            _marksGrade.UseVisualStyleBackColor = true;
            // 
            // radSubject
            // 
            radSubject.Checked = true;
            radSubject.CheckState = CheckState.Checked;
            radSubject.Location = new Point(1094, 358);
            radSubject.Margin = new Padding(4, 4, 4, 4);
            radSubject.Name = "radSubject";
            radSubject.Size = new Size(183, 25);
            radSubject.TabIndex = 23;
            radSubject.Text = "Use Subject Grading";
            radSubject.UseVisualStyleBackColor = true;
            radSubject.Visible = false;
            // 
            // frmMeanResultsLayoutControl1ConvertedLayout
            // 
            frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(_Button4);
            frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(radSubject);
            frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(_btnStreamPerformance);
            frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(_btnClassPerformance);
            frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(_marksGrade);
            frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(_chkMode);
            frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(_Button3);
            frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(_Button6);
            frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(dgvMeanMarks);
            frmMeanResultsLayoutControl1ConvertedLayout.Dock = DockStyle.Fill;
            frmMeanResultsLayoutControl1ConvertedLayout.Location = new Point(0, 0);
            frmMeanResultsLayoutControl1ConvertedLayout.Margin = new Padding(4, 4, 4, 4);
            frmMeanResultsLayoutControl1ConvertedLayout.Name = "frmMeanResultsLayoutControl1ConvertedLayout";
            frmMeanResultsLayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(215, 248, 450, 400);
            frmMeanResultsLayoutControl1ConvertedLayout.Root = LayoutControlGroup1;
            frmMeanResultsLayoutControl1ConvertedLayout.Size = new Size(1535, 449);
            frmMeanResultsLayoutControl1ConvertedLayout.TabIndex = 25;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, LayoutControlItem3, LayoutControlItem4, LayoutControlItem5, LayoutControlItem7, LayoutControlItem8, LayoutControlItem9, LayoutControlItem10, EmptySpaceItem1, SimpleSeparator1 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(1535, 449);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = radSubject;
            LayoutControlItem2.Location = new Point(1078, 342);
            LayoutControlItem2.Name = "radSubjectitem";
            LayoutControlItem2.Size = new Size(189, 81);
            LayoutControlItem2.TextSize = new Size(0, 0);
            LayoutControlItem2.TextVisible = false;
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = _marksGrade;
            LayoutControlItem5.Location = new Point(647, 392);
            LayoutControlItem5.Name = "marksGradeitem";
            LayoutControlItem5.Size = new Size(431, 31);
            LayoutControlItem5.TextSize = new Size(0, 0);
            LayoutControlItem5.TextVisible = false;
            // 
            // LayoutControlItem7
            // 
            LayoutControlItem7.Control = _chkMode;
            LayoutControlItem7.Location = new Point(432, 342);
            LayoutControlItem7.Name = "chkModeitem";
            LayoutControlItem7.Size = new Size(215, 81);
            LayoutControlItem7.TextSize = new Size(0, 0);
            LayoutControlItem7.TextVisible = false;
            // 
            // LayoutControlItem10
            // 
            LayoutControlItem10.Control = dgvMeanMarks;
            LayoutControlItem10.Location = new Point(0, 0);
            LayoutControlItem10.Name = "dgvMeanMarksitem";
            LayoutControlItem10.Size = new Size(1509, 342);
            LayoutControlItem10.TextSize = new Size(0, 0);
            LayoutControlItem10.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(1267, 375);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(242, 45);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // SimpleSeparator1
            // 
            SimpleSeparator1.AllowHotTrack = false;
            SimpleSeparator1.Location = new Point(1267, 420);
            SimpleSeparator1.Name = "SimpleSeparator1";
            SimpleSeparator1.Size = new Size(242, 3);
            // 
            // Button4
            // 
            _Button4.ImageOptions.Image = (Image)resources.GetObject("Button4.ImageOptions.Image");
            _Button4.Location = new Point(1283, 358);
            _Button4.Margin = new Padding(4);
            _Button4.Name = "_Button4";
            _Button4.Size = new Size(236, 27);
            _Button4.StyleController = frmMeanResultsLayoutControl1ConvertedLayout;
            _Button4.TabIndex = 24;
            _Button4.Text = "Save Examination Performance";
            _Button4.Visible = false;
            // 
            // btnStreamPerformance
            // 
            _btnStreamPerformance.ImageOptions.Image = (Image)resources.GetObject("btnStreamPerformance.ImageOptions.Image");
            _btnStreamPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnStreamPerformance.Location = new Point(879, 358);
            _btnStreamPerformance.Margin = new Padding(4);
            _btnStreamPerformance.Name = "_btnStreamPerformance";
            _btnStreamPerformance.Size = new Size(209, 44);
            _btnStreamPerformance.StyleController = frmMeanResultsLayoutControl1ConvertedLayout;
            _btnStreamPerformance.TabIndex = 22;
            _btnStreamPerformance.Text = "&Stream Merit List";
            // 
            // btnClassPerformance
            // 
            _btnClassPerformance.ImageOptions.Image = (Image)resources.GetObject("btnClassPerformance.ImageOptions.Image");
            _btnClassPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnClassPerformance.Location = new Point(663, 358);
            _btnClassPerformance.Margin = new Padding(4);
            _btnClassPerformance.Name = "_btnClassPerformance";
            _btnClassPerformance.Size = new Size(210, 44);
            _btnClassPerformance.StyleController = frmMeanResultsLayoutControl1ConvertedLayout;
            _btnClassPerformance.TabIndex = 21;
            _btnClassPerformance.Text = "&Class Merit List";
            // 
            // Button3
            // 
            _Button3.ImageOptions.Image = (Image)resources.GetObject("Button3.ImageOptions.Image");
            _Button3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button3.Location = new Point(232, 358);
            _Button3.Margin = new Padding(4);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(210, 44);
            _Button3.StyleController = frmMeanResultsLayoutControl1ConvertedLayout;
            _Button3.TabIndex = 15;
            _Button3.Text = "Export To Excel";
            // 
            // Button6
            // 
            _Button6.ImageOptions.Image = (Image)resources.GetObject("Button6.ImageOptions.Image");
            _Button6.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button6.Location = new Point(16, 358);
            _Button6.Margin = new Padding(4);
            _Button6.Name = "_Button6";
            _Button6.Size = new Size(210, 44);
            _Button6.StyleController = frmMeanResultsLayoutControl1ConvertedLayout;
            _Button6.TabIndex = 14;
            _Button6.Text = "Use Analysis For Indexing";
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _Button4;
            LayoutControlItem1.Location = new Point(1267, 342);
            LayoutControlItem1.Name = "Button4item";
            LayoutControlItem1.Size = new Size(242, 33);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = _btnStreamPerformance;
            LayoutControlItem3.Location = new Point(863, 342);
            LayoutControlItem3.Name = "btnStreamPerformanceitem";
            LayoutControlItem3.Size = new Size(215, 50);
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _btnClassPerformance;
            LayoutControlItem4.Location = new Point(647, 342);
            LayoutControlItem4.Name = "btnClassPerformanceitem";
            LayoutControlItem4.Size = new Size(216, 50);
            LayoutControlItem4.TextSize = new Size(0, 0);
            LayoutControlItem4.TextVisible = false;
            // 
            // LayoutControlItem8
            // 
            LayoutControlItem8.Control = _Button3;
            LayoutControlItem8.Location = new Point(216, 342);
            LayoutControlItem8.Name = "Button3item";
            LayoutControlItem8.Size = new Size(216, 81);
            LayoutControlItem8.TextSize = new Size(0, 0);
            LayoutControlItem8.TextVisible = false;
            // 
            // LayoutControlItem9
            // 
            LayoutControlItem9.Control = _Button6;
            LayoutControlItem9.Location = new Point(0, 342);
            LayoutControlItem9.Name = "Button6item";
            LayoutControlItem9.Size = new Size(216, 81);
            LayoutControlItem9.TextSize = new Size(0, 0);
            LayoutControlItem9.TextVisible = false;
            // 
            // frmMeanResults
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1535, 449);
            Controls.Add(frmMeanResultsLayoutControl1ConvertedLayout);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmMeanResults";
            Text = "Mean Results";
            ((System.ComponentModel.ISupportInitialize)dgvMeanMarks).EndInit();
            ((System.ComponentModel.ISupportInitialize)frmMeanResultsLayoutControl1ConvertedLayout).EndInit();
            frmMeanResultsLayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem10).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)SimpleSeparator1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem9).EndInit();
            Load += new EventHandler(frmMeanResults_Load);
            ResumeLayout(false);
        }

        internal DataGridView dgvMeanMarks;
        internal DataGridViewTextBoxColumn ADMNo;
        internal DataGridViewTextBoxColumn StudentName;
        internal DataGridViewImageColumn Column1;
        internal DataGridViewImageColumn Column2;
        internal DataGridViewImageColumn Column3;
        internal DataGridViewImageColumn Column4;
        private DevExpress.XtraEditors.SimpleButton _Button6;

        internal DevExpress.XtraEditors.SimpleButton Button6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button6 != null)
                {
                    _Button6.Click -= Button6_Click;
                }

                _Button6 = value;
                if (_Button6 != null)
                {
                    _Button6.Click += Button6_Click;
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

        private CheckBox _marksGrade;

        internal CheckBox marksGrade
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _marksGrade;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_marksGrade != null)
                {
                    _marksGrade.CheckedChanged -= marksGrade_CheckedChanged;
                }

                _marksGrade = value;
                if (_marksGrade != null)
                {
                    _marksGrade.CheckedChanged += marksGrade_CheckedChanged;
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

        internal Timer Timer1;
        internal CheckBox radSubject;
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

        internal DevExpress.XtraLayout.LayoutControl frmMeanResultsLayoutControl1ConvertedLayout;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem9;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem10;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.SimpleSeparator SimpleSeparator1;
    }
}