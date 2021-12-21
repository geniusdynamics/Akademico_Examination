using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class test : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(test));
            LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            dgvMeanMarks = new DataGridView();
            ADMNo = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewImageColumn();
            Column2 = new DataGridViewImageColumn();
            Column3 = new DataGridViewImageColumn();
            Column4 = new DataGridViewImageColumn();
            LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            Button6 = new DevExpress.XtraEditors.SimpleButton();
            LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).BeginInit();
            LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeanMarks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).BeginInit();
            SuspendLayout();
            // 
            // LayoutControl1
            // 
            LayoutControl1.Controls.Add(Button6);
            LayoutControl1.Controls.Add(dgvMeanMarks);
            LayoutControl1.Dock = DockStyle.Fill;
            LayoutControl1.Location = new Point(0, 0);
            LayoutControl1.Name = "LayoutControl1";
            LayoutControl1.Root = LayoutControlGroup1;
            LayoutControl1.Size = new Size(917, 489);
            LayoutControl1.TabIndex = 0;
            LayoutControl1.Text = "LayoutControl1";
            // 
            // LayoutControlGroup1
            // 
            LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LayoutControlGroup1.GroupBordersVisible = false;
            LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LayoutControlItem1, LayoutControlItem2, EmptySpaceItem2, EmptySpaceItem1 });
            LayoutControlGroup1.Location = new Point(0, 0);
            LayoutControlGroup1.Name = "LayoutControlGroup1";
            LayoutControlGroup1.Size = new Size(917, 489);
            LayoutControlGroup1.TextVisible = false;
            // 
            // dgvMeanMarks
            // 
            dgvMeanMarks.AllowUserToAddRows = false;
            dgvMeanMarks.AllowUserToDeleteRows = false;
            dgvMeanMarks.AllowUserToOrderColumns = true;
            dgvMeanMarks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMeanMarks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeanMarks.Columns.AddRange(new DataGridViewColumn[] { ADMNo, StudentName, Column1, Column2, Column3, Column4 });
            dgvMeanMarks.Location = new Point(12, 12);
            dgvMeanMarks.Name = "dgvMeanMarks";
            dgvMeanMarks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMeanMarks.Size = new Size(893, 402);
            dgvMeanMarks.TabIndex = 6;
            // 
            // ADMNo
            // 
            ADMNo.HeaderText = "ADM.";
            ADMNo.Name = "ADMNo";
            ADMNo.Width = 58;
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
            // LayoutControlItem1
            // 
            LayoutControlItem1.Control = dgvMeanMarks;
            LayoutControlItem1.Location = new Point(0, 0);
            LayoutControlItem1.Name = "LayoutControlItem1";
            LayoutControlItem1.Size = new Size(897, 406);
            LayoutControlItem1.TextSize = new Size(0, 0);
            LayoutControlItem1.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            EmptySpaceItem1.AllowHotTrack = false;
            EmptySpaceItem1.Location = new Point(137, 406);
            EmptySpaceItem1.Name = "EmptySpaceItem1";
            EmptySpaceItem1.Size = new Size(760, 63);
            EmptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // Button6
            // 
            Button6.ImageOptions.Image = (Image)resources.GetObject("Button6.ImageOptions.Image");
            Button6.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            Button6.Location = new Point(12, 418);
            Button6.Name = "Button6";
            Button6.Size = new Size(133, 39);
            Button6.StyleController = LayoutControl1;
            Button6.TabIndex = 15;
            Button6.Text = "Use Analysis For Indexing";
            // 
            // LayoutControlItem2
            // 
            LayoutControlItem2.Control = Button6;
            LayoutControlItem2.Location = new Point(0, 406);
            LayoutControlItem2.Name = "LayoutControlItem2";
            LayoutControlItem2.Size = new Size(137, 43);
            LayoutControlItem2.TextSize = new Size(0, 0);
            LayoutControlItem2.TextVisible = false;
            // 
            // EmptySpaceItem2
            // 
            EmptySpaceItem2.AllowHotTrack = false;
            EmptySpaceItem2.Location = new Point(0, 449);
            EmptySpaceItem2.Name = "EmptySpaceItem2";
            EmptySpaceItem2.Size = new Size(137, 20);
            EmptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // test
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 489);
            Controls.Add(LayoutControl1);
            Name = "test";
            Text = "test";
            ((System.ComponentModel.ISupportInitialize)LayoutControl1).EndInit();
            LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeanMarks).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LayoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmptySpaceItem2).EndInit();
            Load += new EventHandler(test_Load);
            ResumeLayout(false);
        }

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal DataGridView dgvMeanMarks;
        internal DataGridViewTextBoxColumn ADMNo;
        internal DataGridViewTextBoxColumn StudentName;
        internal DataGridViewImageColumn Column1;
        internal DataGridViewImageColumn Column2;
        internal DataGridViewImageColumn Column3;
        internal DataGridViewImageColumn Column4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraEditors.SimpleButton Button6;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
    }
}