using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class frmAddSubject : DevExpress.XtraEditors.XtraForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSubject));
            txtCode = new TextBox();
            Label3 = new Label();
            radOptional = new RadioButton();
            radCompulsory = new RadioButton();
            cboDepartment = new ComboBox();
            txtAbbreviation = new TextBox();
            Label1 = new Label();
            txtName = new TextBox();
            Label10 = new Label();
            Label2 = new Label();
            Label7 = new Label();
            _btnRegister = new Button();
            _btnRegister.Click += new EventHandler(btnRegister_Click);
            _btnClear = new Button();
            _btnClear.Click += new EventHandler(btnClear_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            SuspendLayout();
            // 
            // txtCode
            // 
            txtCode.BackColor = SystemColors.Info;
            txtCode.ForeColor = Color.RosyBrown;
            txtCode.Location = new Point(101, 79);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(232, 21);
            txtCode.TabIndex = 26;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(28, 83);
            Label3.Name = "Label3";
            Label3.Size = new Size(75, 13);
            Label3.TabIndex = 27;
            Label3.Text = "Subject Code:";
            // 
            // radOptional
            // 
            radOptional.AutoSize = true;
            radOptional.Location = new Point(216, 135);
            radOptional.Name = "radOptional";
            radOptional.Size = new Size(65, 17);
            radOptional.TabIndex = 22;
            radOptional.TabStop = true;
            radOptional.Text = "Optional";
            radOptional.UseVisualStyleBackColor = true;
            // 
            // radCompulsory
            // 
            radCompulsory.AutoSize = true;
            radCompulsory.Location = new Point(102, 135);
            radCompulsory.Name = "radCompulsory";
            radCompulsory.Size = new Size(81, 17);
            radCompulsory.TabIndex = 19;
            radCompulsory.TabStop = true;
            radCompulsory.Text = "Compulsory";
            radCompulsory.UseVisualStyleBackColor = true;
            // 
            // cboDepartment
            // 
            cboDepartment.BackColor = SystemColors.Info;
            cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartment.ForeColor = Color.RosyBrown;
            cboDepartment.FormattingEnabled = true;
            cboDepartment.Items.AddRange(new object[] { "None" });
            cboDepartment.Location = new Point(101, 105);
            cboDepartment.Name = "cboDepartment";
            cboDepartment.Size = new Size(232, 21);
            cboDepartment.TabIndex = 16;
            // 
            // txtAbbreviation
            // 
            txtAbbreviation.BackColor = SystemColors.Info;
            txtAbbreviation.ForeColor = Color.RosyBrown;
            txtAbbreviation.Location = new Point(101, 53);
            txtAbbreviation.Name = "txtAbbreviation";
            txtAbbreviation.Size = new Size(232, 21);
            txtAbbreviation.TabIndex = 15;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(29, 56);
            Label1.Name = "Label1";
            Label1.Size = new Size(72, 13);
            Label1.TabIndex = 20;
            Label1.Text = "Abbreviation:";
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.Info;
            txtName.ForeColor = Color.RosyBrown;
            txtName.Location = new Point(101, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(232, 21);
            txtName.TabIndex = 14;
            // 
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.Location = new Point(25, 29);
            Label10.Name = "Label10";
            Label10.Size = new Size(77, 13);
            Label10.TabIndex = 21;
            Label10.Text = "Subject Name:";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(44, 137);
            Label2.Name = "Label2";
            Label2.Size = new Size(56, 13);
            Label2.TabIndex = 17;
            Label2.Text = "Comment:";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Location = new Point(23, 108);
            Label7.Name = "Label7";
            Label7.Size = new Size(79, 13);
            Label7.TabIndex = 18;
            Label7.Text = "Subject Group:";
            // 
            // btnRegister
            // 
            _btnRegister.Image = (Image)resources.GetObject("btnRegister.Image");
            _btnRegister.Location = new Point(251, 157);
            _btnRegister.Name = "_btnRegister";
            _btnRegister.Size = new Size(76, 29);
            _btnRegister.TabIndex = 23;
            _btnRegister.Text = "&Register";
            _btnRegister.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            _btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            _btnClear.Location = new Point(179, 157);
            _btnClear.Name = "_btnClear";
            _btnClear.Size = new Size(63, 29);
            _btnClear.TabIndex = 24;
            _btnClear.Text = "C&lear";
            _btnClear.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnClear.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            _btnCancel.Location = new Point(89, 157);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(75, 29);
            _btnCancel.TabIndex = 25;
            _btnCancel.Text = "&Cancel";
            _btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddSubject
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 219);
            Controls.Add(txtCode);
            Controls.Add(Label3);
            Controls.Add(radOptional);
            Controls.Add(radCompulsory);
            Controls.Add(_btnRegister);
            Controls.Add(_btnClear);
            Controls.Add(_btnCancel);
            Controls.Add(cboDepartment);
            Controls.Add(txtAbbreviation);
            Controls.Add(Label1);
            Controls.Add(txtName);
            Controls.Add(Label10);
            Controls.Add(Label2);
            Controls.Add(Label7);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddSubject";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Subject";
            Load += new EventHandler(frmAddSubject_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal TextBox txtCode;
        internal Label Label3;
        internal RadioButton radOptional;
        internal RadioButton radCompulsory;
        private Button _btnRegister;

        internal Button btnRegister
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRegister;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRegister != null)
                {
                    _btnRegister.Click -= btnRegister_Click;
                }

                _btnRegister = value;
                if (_btnRegister != null)
                {
                    _btnRegister.Click += btnRegister_Click;
                }
            }
        }

        private Button _btnClear;

        internal Button btnClear
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClear;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClear != null)
                {
                    _btnClear.Click -= btnClear_Click;
                }

                _btnClear = value;
                if (_btnClear != null)
                {
                    _btnClear.Click += btnClear_Click;
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

        internal ComboBox cboDepartment;
        internal TextBox txtAbbreviation;
        internal Label Label1;
        internal TextBox txtName;
        internal Label Label10;
        internal Label Label2;
        internal Label Label7;
    }
}