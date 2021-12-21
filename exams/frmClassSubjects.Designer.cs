using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmClassSubjects : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassSubjects));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            _Button5 = new DevExpress.XtraEditors.SimpleButton();
            _Button5.Click += new EventHandler(Button5_Click);
            _Button2 = new DevExpress.XtraEditors.SimpleButton();
            _Button2.Click += new EventHandler(Button2_Click);
            _SimpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            _SimpleButton1.Click += new EventHandler(SimpleButton1_Click);
            lstSubjects = new ListView();
            ColumnHeader1 = new ColumnHeader();
            ColumnHeader2 = new ColumnHeader();
            ColumnHeader3 = new ColumnHeader();
            ColumnHeader4 = new ColumnHeader();
            ColumnHeader5 = new ColumnHeader();
            ColumnHeader6 = new ColumnHeader();
            ColumnHeader7 = new ColumnHeader();
            _cboClass = new ComboBox();
            _cboClass.SelectedIndexChanged += new EventHandler(cboClass_SelectedIndexChanged);
            cboSubject = new ComboBox();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(_Button5);
            LayoutControl1.Controls.Add(_Button2);
            LayoutControl1.Controls.Add(_SimpleButton1);
            LayoutControl1.Controls.Add(lstSubjects);
            LayoutControl1.Controls.Add(_cboClass);
            LayoutControl1.Controls.Add(cboSubject);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(588, 276, 250, 350);
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(872, 452);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // Button5
            // 
            _Button5.Image = (Image)resources.GetObject("Button5.Image");
            _Button5.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button5.Location = new Point(714, 401);
            _Button5.Name = "_Button5";
            _Button5.Size = new Size(96, 39);
            _Button5.StyleController = LayoutControl1;
            _Button5.TabIndex = 9;
            _Button5.Text = "Remove From List";
            // 
            // Button2
            // 
            _Button2.Image = (Image)resources.GetObject("Button2.Image");
            _Button2.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _Button2.Location = new Point(814, 401);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(46, 39);
            _Button2.StyleController = LayoutControl1;
            _Button2.TabIndex = 8;
            _Button2.Text = "Save";
            // 
            // SimpleButton1
            // 
            _SimpleButton1.Image = (Image)resources.GetObject("SimpleButton1.Image");
            _SimpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            _SimpleButton1.Location = new Point(790, 47);
            _SimpleButton1.Name = "_SimpleButton1";
            _SimpleButton1.Size = new Size(70, 39);
            _SimpleButton1.StyleController = LayoutControl1;
            _SimpleButton1.TabIndex = 7;
            _SimpleButton1.Text = "Add Subject";
            // 
            // lstSubjects
            // 
            lstSubjects.Columns.AddRange(new ColumnHeader[] { ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4, ColumnHeader5, ColumnHeader6, ColumnHeader7 });
            lstSubjects.FullRowSelect = true;
            lstSubjects.Location = new Point(12, 90);
            lstSubjects.Name = "lstSubjects";
            lstSubjects.Size = new Size(848, 307);
            lstSubjects.TabIndex = 6;
            lstSubjects.UseCompatibleStateImageBehavior = false;
            lstSubjects.View = View.Details;
            // 
            // ColumnHeader1
            // 
            ColumnHeader1.Text = "ID";
            ColumnHeader1.Width = 81;
            // 
            // ColumnHeader2
            // 
            ColumnHeader2.Text = "Class";
            ColumnHeader2.Width = 99;
            // 
            // ColumnHeader3
            // 
            ColumnHeader3.Text = "Subject";
            ColumnHeader3.Width = 114;
            // 
            // ColumnHeader4
            // 
            ColumnHeader4.Text = "Abbreviation";
            ColumnHeader4.Width = 127;
            // 
            // ColumnHeader5
            // 
            ColumnHeader5.Text = "Department";
            ColumnHeader5.Width = 143;
            // 
            // ColumnHeader6
            // 
            ColumnHeader6.Text = "Comment";
            ColumnHeader6.Width = 173;
            // 
            // ColumnHeader7
            // 
            ColumnHeader7.Text = "Code";
            ColumnHeader7.Width = 105;
            // 
            // cboClass
            // 
            _cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboClass.FormattingEnabled = true;
            _cboClass.Location = new Point(51, 12);
            _cboClass.Name = "_cboClass";
            _cboClass.Size = new Size(364, 21);
            _cboClass.TabIndex = 5;
            // 
            // cboSubject
            // 
            cboSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSubject.FormattingEnabled = true;
            cboSubject.Location = new Point(458, 12);
            cboSubject.Name = "cboSubject";
            cboSubject.Size = new Size(402, 21);
            cboSubject.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem3, EmptySpaceItem1, EmptySpaceItem2, LayoutControlItem2, LayoutControlItem4, EmptySpaceItem3, LayoutControlItem5, LayoutControlItem6 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "Root";
            LayoutControlGroup1.Size = new Size(872, 452);
            LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = cboSubject;
            LayoutControlItem1.Location = new Point(407, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(445, 25);
            LayoutControlItem1.Text = "Subject";
            LayoutControlItem1.TextSize = new Size(36, 13);
            // 
            // LayoutControlItem3
            // 
            LayoutControlItem3.Control = lstSubjects;
            LayoutControlItem3.Location = new Point(0, 78);
            LayoutControlItem3.Name = "LayoutControlItem3";
            LayoutControlItem3.Size = new Size(852, 311);
            LayoutControlItem3.TextSize = new Size(0, 0);
            LayoutControlItem3.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(0, 389);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(702, 43);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 35);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(778, 43);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = _cboClass;
            LayoutControlItem2.Location = new Point(0, 0);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(407, 25);
            LayoutControlItem2.Text = "Class";
            LayoutControlItem2.TextSize = new Size(36, 13);
            // 
            // LayoutControlItem4
            // 
            LayoutControlItem4.Control = _SimpleButton1;
            LayoutControlItem4.Location = new Point(778, 35);
            LayoutControlItem4.Name = "LayoutControlItem4";
            LayoutControlItem4.Size = new Size(74, 43);
            LayoutControlItem4.TextSize = new Size(0, 0);
            LayoutControlItem4.TextVisible = false;
            // 
            // EmptySpaceItem3
            // 
            EmptySpaceItem3.AllowHotTrack = false;
            EmptySpaceItem3.Location = new Point(0, 25);
            EmptySpaceItem3.Name = "EmptySpaceItem3";
            EmptySpaceItem3.Size = new Size(852, 10);
            EmptySpaceItem3.TextSize = new Size(0, 0);
            // 
            // LayoutControlItem5
            // 
            LayoutControlItem5.Control = _Button2;
            LayoutControlItem5.Location = new Point(802, 389);
            LayoutControlItem5.Name = "LayoutControlItem5";
            LayoutControlItem5.Size = new Size(50, 43);
            LayoutControlItem5.TextSize = new Size(0, 0);
            LayoutControlItem5.TextVisible = false;
            // 
            // LayoutControlItem6
            // 
            LayoutControlItem6.Control = _Button5;
            LayoutControlItem6.Location = new Point(702, 389);
            LayoutControlItem6.Name = "LayoutControlItem6";
            LayoutControlItem6.Size = new Size(100, 43);
            LayoutControlItem6.TextSize = new Size(0, 0);
            LayoutControlItem6.TextVisible = false;
            // 
            // frmClassSubjects
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 452);
            Controls.Add(LayoutControl1);
            Name = "frmClassSubjects";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Assign Class Subjects";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem6).EndInit();
            Load += new EventHandler(frmClassSubjects_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton _Button5;

        internal DevExpress.XtraEditors.SimpleButton Button5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button5 != null)
                {
                    _Button5.Click -= Button5_Click;
                }

                _Button5 = value;
                if (_Button5 != null)
                {
                    _Button5.Click += Button5_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _Button2;

        internal DevExpress.XtraEditors.SimpleButton Button2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button2 != null)
                {
                    _Button2.Click -= Button2_Click;
                }

                _Button2 = value;
                if (_Button2 != null)
                {
                    _Button2.Click += Button2_Click;
                }
            }
        }

        private DevExpress.XtraEditors.SimpleButton _SimpleButton1;

        internal DevExpress.XtraEditors.SimpleButton SimpleButton1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SimpleButton1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SimpleButton1 != null)
                {
                    _SimpleButton1.Click -= SimpleButton1_Click;
                }

                _SimpleButton1 = value;
                if (_SimpleButton1 != null)
                {
                    _SimpleButton1.Click += SimpleButton1_Click;
                }
            }
        }

        internal ListView lstSubjects;
        internal ColumnHeader ColumnHeader1;
        internal ColumnHeader ColumnHeader2;
        internal ColumnHeader ColumnHeader3;
        internal ColumnHeader ColumnHeader4;
        internal ColumnHeader ColumnHeader5;
        internal ColumnHeader ColumnHeader6;
        internal ColumnHeader ColumnHeader7;
        private ComboBox _cboClass;

        internal ComboBox cboClass
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboClass;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboClass != null)
                {
                    _cboClass.SelectedIndexChanged -= cboClass_SelectedIndexChanged;
                }

                _cboClass = value;
                if (_cboClass != null)
                {
                    _cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
                }
            }
        }

        internal ComboBox cboSubject;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
    }
}