<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddSubject
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddSubject))
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.radOptional = New System.Windows.Forms.RadioButton()
        Me.radCompulsory = New System.Windows.Forms.RadioButton()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.txtAbbreviation = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.SystemColors.Info
        Me.txtCode.ForeColor = System.Drawing.Color.RosyBrown
        Me.txtCode.Location = New System.Drawing.Point(101, 79)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(232, 21)
        Me.txtCode.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Subject Code:"
        '
        'radOptional
        '
        Me.radOptional.AutoSize = True
        Me.radOptional.Location = New System.Drawing.Point(216, 135)
        Me.radOptional.Name = "radOptional"
        Me.radOptional.Size = New System.Drawing.Size(65, 17)
        Me.radOptional.TabIndex = 22
        Me.radOptional.TabStop = True
        Me.radOptional.Text = "Optional"
        Me.radOptional.UseVisualStyleBackColor = True
        '
        'radCompulsory
        '
        Me.radCompulsory.AutoSize = True
        Me.radCompulsory.Location = New System.Drawing.Point(102, 135)
        Me.radCompulsory.Name = "radCompulsory"
        Me.radCompulsory.Size = New System.Drawing.Size(81, 17)
        Me.radCompulsory.TabIndex = 19
        Me.radCompulsory.TabStop = True
        Me.radCompulsory.Text = "Compulsory"
        Me.radCompulsory.UseVisualStyleBackColor = True
        '
        'cboDepartment
        '
        Me.cboDepartment.BackColor = System.Drawing.SystemColors.Info
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.ForeColor = System.Drawing.Color.RosyBrown
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Items.AddRange(New Object() {"None"})
        Me.cboDepartment.Location = New System.Drawing.Point(101, 105)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(232, 21)
        Me.cboDepartment.TabIndex = 16
        '
        'txtAbbreviation
        '
        Me.txtAbbreviation.BackColor = System.Drawing.SystemColors.Info
        Me.txtAbbreviation.ForeColor = System.Drawing.Color.RosyBrown
        Me.txtAbbreviation.Location = New System.Drawing.Point(101, 53)
        Me.txtAbbreviation.Name = "txtAbbreviation"
        Me.txtAbbreviation.Size = New System.Drawing.Size(232, 21)
        Me.txtAbbreviation.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Abbreviation:"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.SystemColors.Info
        Me.txtName.ForeColor = System.Drawing.Color.RosyBrown
        Me.txtName.Location = New System.Drawing.Point(101, 27)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(232, 21)
        Me.txtName.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Subject Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Comment:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Subject Group:"
        '
        'btnRegister
        '
        Me.btnRegister.Image = CType(resources.GetObject("btnRegister.Image"), System.Drawing.Image)
        Me.btnRegister.Location = New System.Drawing.Point(251, 157)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(76, 29)
        Me.btnRegister.TabIndex = 23
        Me.btnRegister.Text = "&Register"
        Me.btnRegister.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(179, 157)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(63, 29)
        Me.btnClear.TabIndex = 24
        Me.btnClear.Text = "C&lear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(89, 157)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 29)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmAddSubject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 219)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.radOptional)
        Me.Controls.Add(Me.radCompulsory)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.cboDepartment)
        Me.Controls.Add(Me.txtAbbreviation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddSubject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Subject"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents radOptional As RadioButton
    Friend WithEvents radCompulsory As RadioButton
    Friend WithEvents btnRegister As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents txtAbbreviation As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
End Class
