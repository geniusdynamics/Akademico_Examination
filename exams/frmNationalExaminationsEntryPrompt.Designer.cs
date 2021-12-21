using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmNationalExaminationsEntryPrompt : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNationalExaminationsEntryPrompt));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            _cboYear = new ComboBox();
            _cboYear.SelectedIndexChanged += new EventHandler(cboYear_SelectedIndexChanged);
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            cboExamination = new ComboBox();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            CheckBox1 = new CheckBox();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            _btnEnter = new DevExpress.XtraEditors.SimpleButton();
            _btnEnter.Click += new EventHandler(btnEnter_Click);
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_btnEnter);
            LayoutControl1.Controls.Add(CheckBox1);
            LayoutControl1.Controls.Add(cboExamination);
            LayoutControl1.Controls.Add(_cboYear);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(587, 153);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, LayoutControlItem3, EmptySpaceItem1, LayoutControlItem4 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(587, 153);
            LayoutControlGroup1.TextVisible = false;
            // 
            // cboYear
            // 
            _cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboYear.FormattingEnabled = true;
            _cboYear.Location = new Point(74, 12);
            _cboYear.Name = "_cboYear";
            _cboYear.Size = new Size(501, 21);
            _cboYear.TabIndex = 4;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = _cboYear;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(567, 25);
            LayoutControlItem1.Text = "Year";
            LayoutControlItem1.TextSize = new Size(58, 13);
            // 
            // cboExamination
            // 
            cboExamination.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExamination.FormattingEnabled = true;
            cboExamination.Location = new Point(74, 37);
            cboExamination.Name = "cboExamination";
            cboExamination.Size = new Size(501, 21);
            cboExamination.TabIndex = 5;
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = cboExamination;
            LayoutControlItem2.Location = new Point(0, 25);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(567, 25);
            LayoutControlItem2.Text = "Examination";
            LayoutControlItem2.TextSize = new Size(58, 13);
            // 
            // CheckBox1
            // 
            CheckBox1.Location = new Point(12, 62);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(563, 20);
            CheckBox1.TabIndex = 6;
            CheckBox1.Text = "Load Students From Alumni Database";
            CheckBox1.UseVisualStyleBackColor = true;
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = CheckBox1;
            LayoutControlItem3.Location = new Point(0, 50);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(567, 24);
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 74);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(484, 59);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // btnEnter
            // 
            _btnEnter.Image = (Image)resources.GetObject("btnEnter.Image");
            _btnEnter.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _btnEnter.Location = new Point(496, 86);
            _btnEnter.Name = "_btnEnter";
            _btnEnter.Size = new Size(79, 39);
            _btnEnter.StyleController = LayoutControl1;
            _btnEnter.TabIndex = 7;
            _btnEnter.Text = "Enter";
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _btnEnter;
            LayoutControlItem4.Location = new Point(484, 74);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(83, 59);
            LayoutControlItem4.TextSize = new Size(0, 0);
            LayoutControlItem4.TextVisible = false;
            // 
            // frmNationalExaminationsEntryPrompt
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 153);
            Controls.Add(LayoutControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNationalExaminationsEntryPrompt";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Exam";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            Load += new EventHandler(frmNationalExaminationsEntryPrompt_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        private DevExpress.XtraEditors.SimpleButton _btnEnter;

        internal DevExpress.XtraEditors.SimpleButton btnEnter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEnter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEnter != null)
                {
                    _btnEnter.Click -= btnEnter_Click;
                }

                _btnEnter = value;
                if (_btnEnter != null)
                {
                    _btnEnter.Click += btnEnter_Click;
                }
            }
        }

        internal CheckBox CheckBox1;
        internal ComboBox cboExamination;
        private ComboBox _cboYear;

        internal ComboBox cboYear
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboYear;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboYear != null)
                {
                    _cboYear.SelectedIndexChanged -= cboYear_SelectedIndexChanged;
                }

                _cboYear = value;
                if (_cboYear != null)
                {
                    _cboYear.SelectedIndexChanged += cboYear_SelectedIndexChanged;
                }
            }
        }

        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
    }
}