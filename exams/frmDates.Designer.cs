using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmDates : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDates));
            CheckBox1 = new CheckBox();
            chkTable = new CheckBox();
            chkBarGraph = new CheckBox();
            chkFee = new CheckBox();
            chkAttendance = new CheckBox();
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnGo = new Button();
            _btnGo.Click += new EventHandler(btnGo_Click);
            DateTimePicker2 = new DateTimePicker();
            DateTimePicker1 = new DateTimePicker();
            Label2 = new Label();
            Label1 = new Label();
            SuspendLayout();
            // 
            // CheckBox1
            // 
            CheckBox1.AutoSize = true;
            CheckBox1.Checked = true;
            CheckBox1.CheckState = CheckState.Checked;
            CheckBox1.Location = new Point(102, 168);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(161, 17);
            CheckBox1.TabIndex = 22;
            CheckBox1.Text = "Watermark the Report Form";
            CheckBox1.UseVisualStyleBackColor = true;
            // 
            // chkTable
            // 
            chkTable.AutoSize = true;
            chkTable.Checked = true;
            chkTable.CheckState = CheckState.Checked;
            chkTable.Location = new Point(102, 144);
            chkTable.Name = "chkTable";
            chkTable.Size = new Size(174, 17);
            chkTable.TabIndex = 21;
            chkTable.Text = "Show Detailed Subject Ranking";
            chkTable.UseVisualStyleBackColor = true;
            // 
            // chkBarGraph
            // 
            chkBarGraph.AutoSize = true;
            chkBarGraph.Checked = true;
            chkBarGraph.CheckState = CheckState.Checked;
            chkBarGraph.Location = new Point(102, 121);
            chkBarGraph.Name = "chkBarGraph";
            chkBarGraph.Size = new Size(103, 17);
            chkBarGraph.TabIndex = 20;
            chkBarGraph.Text = "Show Bar Graph";
            chkBarGraph.UseVisualStyleBackColor = true;
            // 
            // chkFee
            // 
            chkFee.AutoSize = true;
            chkFee.Checked = true;
            chkFee.CheckState = CheckState.Checked;
            chkFee.Location = new Point(102, 98);
            chkFee.Name = "chkFee";
            chkFee.Size = new Size(117, 17);
            chkFee.TabIndex = 18;
            chkFee.Text = "Show Fees Arrears";
            chkFee.UseVisualStyleBackColor = true;
            // 
            // chkAttendance
            // 
            chkAttendance.AutoSize = true;
            chkAttendance.Location = new Point(102, 75);
            chkAttendance.Name = "chkAttendance";
            chkAttendance.Size = new Size(111, 17);
            chkAttendance.TabIndex = 19;
            chkAttendance.Text = "Show Attendance";
            chkAttendance.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(103, 198);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(72, 27);
            _btnCancel.TabIndex = 16;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            _btnGo.Image = (Image)resources.GetObject("btnGo.Image");
            _btnGo.Location = new Point(203, 198);
            _btnGo.Name = "_btnGo";
            _btnGo.Size = new Size(71, 27);
            _btnGo.TabIndex = 17;
            _btnGo.Text = "&Go";
            _btnGo.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnGo.UseVisualStyleBackColor = true;
            // 
            // DateTimePicker2
            // 
            DateTimePicker2.Format = DateTimePickerFormat.Short;
            DateTimePicker2.Location = new Point(102, 49);
            DateTimePicker2.Name = "DateTimePicker2";
            DateTimePicker2.Size = new Size(172, 21);
            DateTimePicker2.TabIndex = 14;
            // 
            // DateTimePicker1
            // 
            DateTimePicker1.Format = DateTimePickerFormat.Short;
            DateTimePicker1.Location = new Point(102, 18);
            DateTimePicker1.Name = "DateTimePicker1";
            DateTimePicker1.Size = new Size(172, 21);
            DateTimePicker1.TabIndex = 15;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(22, 54);
            Label2.Name = "Label2";
            Label2.Size = new Size(77, 13);
            Label2.TabIndex = 12;
            Label2.Text = "Opening Date:";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(26, 23);
            Label1.Name = "Label1";
            Label1.Size = new Size(71, 13);
            Label1.TabIndex = 13;
            Label1.Text = "Closing Date:";
            // 
            // frmDates
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 266);
            Controls.Add(CheckBox1);
            Controls.Add(chkTable);
            Controls.Add(chkBarGraph);
            Controls.Add(chkFee);
            Controls.Add(chkAttendance);
            Controls.Add(_btnCancel);
            Controls.Add(_btnGo);
            Controls.Add(DateTimePicker2);
            Controls.Add(DateTimePicker1);
            Controls.Add(Label2);
            Controls.Add(Label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDates";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Opening And Closing Dates Required";
            Load += new EventHandler(frmDates_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal CheckBox CheckBox1;
        internal CheckBox chkTable;
        internal CheckBox chkBarGraph;
        internal CheckBox chkFee;
        internal CheckBox chkAttendance;
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

        private Button _btnGo;

        internal Button btnGo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGo != null)
                {
                    _btnGo.Click -= btnGo_Click;
                }

                _btnGo = value;
                if (_btnGo != null)
                {
                    _btnGo.Click += btnGo_Click;
                }
            }
        }

        internal DateTimePicker DateTimePicker2;
        internal DateTimePicker DateTimePicker1;
        internal Label Label2;
        internal Label Label1;
    }
}