<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModifySubject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModifySubject))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.radOptional = New System.Windows.Forms.RadioButton()
        Me.radCompulsory = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Department = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abbreviation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubjectName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubjID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSubjects = New System.Windows.Forms.DataGridView()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.txtAbbreviation = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.dgvSubjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 435)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Subject Code:"
        '
        'radOptional
        '
        Me.radOptional.AutoSize = True
        Me.radOptional.Location = New System.Drawing.Point(210, 459)
        Me.radOptional.Name = "radOptional"
        Me.radOptional.Size = New System.Drawing.Size(65, 17)
        Me.radOptional.TabIndex = 39
        Me.radOptional.TabStop = True
        Me.radOptional.Text = "Optional"
        Me.radOptional.UseVisualStyleBackColor = True
        '
        'radCompulsory
        '
        Me.radCompulsory.AutoSize = True
        Me.radCompulsory.Location = New System.Drawing.Point(96, 459)
        Me.radCompulsory.Name = "radCompulsory"
        Me.radCompulsory.Size = New System.Drawing.Size(81, 17)
        Me.radCompulsory.TabIndex = 38
        Me.radCompulsory.TabStop = True
        Me.radCompulsory.Text = "Compulsory"
        Me.radCompulsory.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 459)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Comment:"
        '
        'Comment
        '
        Me.Comment.HeaderText = "Comment"
        Me.Comment.Name = "Comment"
        Me.Comment.ReadOnly = True
        '
        'Department
        '
        Me.Department.HeaderText = "Department"
        Me.Department.Name = "Department"
        Me.Department.ReadOnly = True
        Me.Department.Width = 150
        '
        'Code
        '
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        '
        'Abbreviation
        '
        Me.Abbreviation.HeaderText = "Abbreviation"
        Me.Abbreviation.Name = "Abbreviation"
        '
        'SubjectName
        '
        Me.SubjectName.HeaderText = "Name of Subject"
        Me.SubjectName.Name = "SubjectName"
        Me.SubjectName.ReadOnly = True
        Me.SubjectName.Width = 200
        '
        'SubjID
        '
        Me.SubjID.HeaderText = "Subject ID"
        Me.SubjID.Name = "SubjID"
        Me.SubjID.ReadOnly = True
        Me.SubjID.Visible = False
        '
        'dgvSubjects
        '
        Me.dgvSubjects.AllowUserToAddRows = False
        Me.dgvSubjects.AllowUserToDeleteRows = False
        Me.dgvSubjects.AllowUserToResizeColumns = False
        Me.dgvSubjects.AllowUserToResizeRows = False
        Me.dgvSubjects.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubjects.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SubjID, Me.SubjectName, Me.Abbreviation, Me.Code, Me.Department, Me.Comment})
        Me.dgvSubjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSubjects.GridColor = System.Drawing.Color.RosyBrown
        Me.dgvSubjects.Location = New System.Drawing.Point(3, 17)
        Me.dgvSubjects.MultiSelect = False
        Me.dgvSubjects.Name = "dgvSubjects"
        Me.dgvSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSubjects.Size = New System.Drawing.Size(695, 355)
        Me.dgvSubjects.TabIndex = 1
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.SystemColors.Info
        Me.txtCode.ForeColor = System.Drawing.Color.RosyBrown
        Me.txtCode.Location = New System.Drawing.Point(95, 432)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(227, 21)
        Me.txtCode.TabIndex = 47
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvSubjects)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(701, 375)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Items.AddRange(New Object() {"None"})
        Me.cboDepartment.Location = New System.Drawing.Point(455, 432)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(258, 21)
        Me.cboDepartment.TabIndex = 37
        '
        'txtAbbreviation
        '
        Me.txtAbbreviation.Location = New System.Drawing.Point(455, 405)
        Me.txtAbbreviation.Name = "txtAbbreviation"
        Me.txtAbbreviation.Size = New System.Drawing.Size(258, 21)
        Me.txtAbbreviation.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(373, 408)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Abbreviation:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(95, 405)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(227, 21)
        Me.txtName.TabIndex = 35
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 408)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Subject Name:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(365, 435)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Subject Group:"
        '
        'btnUpdate
        '
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.Location = New System.Drawing.Point(642, 459)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(71, 28)
        Me.btnUpdate.TabIndex = 40
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(561, 459)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(63, 28)
        Me.btnClear.TabIndex = 41
        Me.btnClear.Text = "C&lear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(469, 459)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 28)
        Me.btnCancel.TabIndex = 42
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmModifySubject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 502)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.radOptional)
        Me.Controls.Add(Me.radCompulsory)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.cboDepartment)
        Me.Controls.Add(Me.txtAbbreviation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModifySubject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modify Subject"
        CType(Me.dgvSubjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents radOptional As RadioButton
    Friend WithEvents radCompulsory As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Comment As DataGridViewTextBoxColumn
    Friend WithEvents Department As DataGridViewTextBoxColumn
    Friend WithEvents Code As DataGridViewTextBoxColumn
    Friend WithEvents Abbreviation As DataGridViewTextBoxColumn
    Friend WithEvents SubjectName As DataGridViewTextBoxColumn
    Friend WithEvents SubjID As DataGridViewTextBoxColumn
    Friend WithEvents dgvSubjects As DataGridView
    Friend WithEvents txtCode As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents txtAbbreviation As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
End Class
