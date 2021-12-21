using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmPrompt : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrompt));
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnEnter = new Button();
            _btnEnter.Click += new EventHandler(btnEnter_Click);
            Label1 = new Label();
            cboStream = new ComboBox();
            SuspendLayout();
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(121, 59);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(68, 33);
            _btnCancel.TabIndex = 6;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            _btnEnter.Image = (Image)resources.GetObject("btnEnter.Image");
            _btnEnter.Location = new Point(206, 59);
            _btnEnter.Name = "_btnEnter";
            _btnEnter.Size = new Size(68, 33);
            _btnEnter.TabIndex = 4;
            _btnEnter.Text = "&Enter";
            _btnEnter.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnEnter.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(21, 25);
            Label1.Name = "Label1";
            Label1.Size = new Size(45, 13);
            Label1.TabIndex = 5;
            Label1.Text = "Stream:";
            // 
            // cboStream
            // 
            cboStream.BackColor = SystemColors.Info;
            cboStream.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStream.ForeColor = Color.IndianRed;
            cboStream.FormattingEnabled = true;
            cboStream.Location = new Point(74, 22);
            cboStream.Name = "cboStream";
            cboStream.Size = new Size(217, 21);
            cboStream.TabIndex = 3;
            // 
            // frmPrompt
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 127);
            Controls.Add(_btnCancel);
            Controls.Add(_btnEnter);
            Controls.Add(Label1);
            Controls.Add(cboStream);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPrompt";
            Text = "Result Analysis Prompt";
            Load += new EventHandler(frmPrompt_Load);
            ResumeLayout(false);
            PerformLayout();
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

        private Button _btnEnter;

        internal Button btnEnter
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

        internal Label Label1;
        internal ComboBox cboStream;
    }
}