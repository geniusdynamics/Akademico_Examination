<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResultAnalysis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResultAnalysis))
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnAddExam = New System.Windows.Forms.Button()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkMode = New System.Windows.Forms.CheckBox()
        Me.btnEnterMarks = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.cboSortBy = New System.Windows.Forms.ComboBox()
        Me.txtContribution = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboExamName = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTerm = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grpMultiExaminations = New System.Windows.Forms.GroupBox()
        Me.lstExaminations = New System.Windows.Forms.ListView()
        Me.grpMultiExaminations.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(95, 315)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(181, 17)
        Me.CheckBox1.TabIndex = 71
        Me.CheckBox1.Text = "Show Split Subject Contributions"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Term"
        Me.ColumnHeader4.Width = 50
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Year"
        Me.ColumnHeader3.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Contribution"
        Me.ColumnHeader2.Width = 80
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(42, 291)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "Rank By:"
        '
        'btnAddExam
        '
        Me.btnAddExam.Image = CType(resources.GetObject("btnAddExam.Image"), System.Drawing.Image)
        Me.btnAddExam.Location = New System.Drawing.Point(262, 108)
        Me.btnAddExam.Name = "btnAddExam"
        Me.btnAddExam.Size = New System.Drawing.Size(127, 23)
        Me.btnAddExam.TabIndex = 57
        Me.btnAddExam.Text = "&Add Examination"
        Me.btnAddExam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddExam.UseVisualStyleBackColor = True
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Exam"
        Me.ColumnHeader1.Width = 100
        '
        'chkMode
        '
        Me.chkMode.AutoSize = True
        Me.chkMode.Location = New System.Drawing.Point(97, 18)
        Me.chkMode.Name = "chkMode"
        Me.chkMode.Size = New System.Drawing.Size(205, 17)
        Me.chkMode.TabIndex = 52
        Me.chkMode.Text = "Combine More Than One Examination"
        Me.chkMode.UseVisualStyleBackColor = True
        '
        'btnEnterMarks
        '
        Me.btnEnterMarks.Image = CType(resources.GetObject("btnEnterMarks.Image"), System.Drawing.Image)
        Me.btnEnterMarks.Location = New System.Drawing.Point(275, 338)
        Me.btnEnterMarks.Name = "btnEnterMarks"
        Me.btnEnterMarks.Size = New System.Drawing.Size(111, 32)
        Me.btnEnterMarks.TabIndex = 64
        Me.btnEnterMarks.Text = "&Analyse"
        Me.btnEnterMarks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEnterMarks.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(207, 338)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(63, 32)
        Me.btnClear.TabIndex = 66
        Me.btnClear.Text = "C&lear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'cboSortBy
        '
        Me.cboSortBy.BackColor = System.Drawing.SystemColors.Info
        Me.cboSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSortBy.ForeColor = System.Drawing.Color.IndianRed
        Me.cboSortBy.FormattingEnabled = True
        Me.cboSortBy.Items.AddRange(New Object() {"Total Marks", "Mean Marks", "Mean Points", "Total Points"})
        Me.cboSortBy.Location = New System.Drawing.Point(95, 288)
        Me.cboSortBy.Name = "cboSortBy"
        Me.cboSortBy.Size = New System.Drawing.Size(291, 21)
        Me.cboSortBy.TabIndex = 69
        '
        'txtContribution
        '
        Me.txtContribution.BackColor = System.Drawing.SystemColors.Info
        Me.txtContribution.ForeColor = System.Drawing.Color.IndianRed
        Me.txtContribution.Location = New System.Drawing.Point(98, 109)
        Me.txtContribution.Name = "txtContribution"
        Me.txtContribution.Size = New System.Drawing.Size(96, 21)
        Me.txtContribution.TabIndex = 56
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(131, 338)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 32)
        Me.btnCancel.TabIndex = 67
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cboClass
        '
        Me.cboClass.BackColor = System.Drawing.SystemColors.Info
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.ForeColor = System.Drawing.Color.IndianRed
        Me.cboClass.FormattingEnabled = True
        Me.cboClass.Location = New System.Drawing.Point(95, 266)
        Me.cboClass.Name = "cboClass"
        Me.cboClass.Size = New System.Drawing.Size(291, 21)
        Me.cboClass.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 268)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Class:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 100)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "List Of Examinations And Their Respective Contributions For Analysis:"
        '
        'cboExamName
        '
        Me.cboExamName.BackColor = System.Drawing.SystemColors.Info
        Me.cboExamName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExamName.ForeColor = System.Drawing.Color.IndianRed
        Me.cboExamName.FormattingEnabled = True
        Me.cboExamName.Location = New System.Drawing.Point(97, 87)
        Me.cboExamName.Name = "cboExamName"
        Me.cboExamName.Size = New System.Drawing.Size(289, 21)
        Me.cboExamName.TabIndex = 55
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(200, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "% of 100%"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Contribution:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Exam Name:"
        '
        'cboYear
        '
        Me.cboYear.BackColor = System.Drawing.SystemColors.Info
        Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYear.ForeColor = System.Drawing.Color.IndianRed
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Items.AddRange(New Object() {"None", "I", "II", "III"})
        Me.cboYear.Location = New System.Drawing.Point(97, 43)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(291, 21)
        Me.cboYear.TabIndex = 53
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(61, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Year:"
        '
        'cboTerm
        '
        Me.cboTerm.BackColor = System.Drawing.SystemColors.Info
        Me.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerm.ForeColor = System.Drawing.Color.IndianRed
        Me.cboTerm.FormattingEnabled = True
        Me.cboTerm.Items.AddRange(New Object() {"None", "I", "II", "III"})
        Me.cboTerm.Location = New System.Drawing.Point(97, 65)
        Me.cboTerm.Name = "cboTerm"
        Me.cboTerm.Size = New System.Drawing.Size(291, 21)
        Me.cboTerm.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(56, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Term:"
        '
        'grpMultiExaminations
        '
        Me.grpMultiExaminations.Controls.Add(Me.lstExaminations)
        Me.grpMultiExaminations.Controls.Add(Me.Label5)
        Me.grpMultiExaminations.Location = New System.Drawing.Point(17, 128)
        Me.grpMultiExaminations.Name = "grpMultiExaminations"
        Me.grpMultiExaminations.Size = New System.Drawing.Size(376, 132)
        Me.grpMultiExaminations.TabIndex = 68
        Me.grpMultiExaminations.TabStop = False
        '
        'lstExaminations
        '
        Me.lstExaminations.BackColor = System.Drawing.SystemColors.Info
        Me.lstExaminations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstExaminations.ForeColor = System.Drawing.Color.IndianRed
        Me.lstExaminations.GridLines = True
        Me.lstExaminations.Location = New System.Drawing.Point(78, 20)
        Me.lstExaminations.Name = "lstExaminations"
        Me.lstExaminations.Size = New System.Drawing.Size(290, 101)
        Me.lstExaminations.TabIndex = 6
        Me.lstExaminations.UseCompatibleStateImageBehavior = False
        Me.lstExaminations.View = System.Windows.Forms.View.Details
        '
        'frmResultAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 408)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnAddExam)
        Me.Controls.Add(Me.chkMode)
        Me.Controls.Add(Me.btnEnterMarks)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.cboSortBy)
        Me.Controls.Add(Me.txtContribution)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.cboClass)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboExamName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTerm)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.grpMultiExaminations)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResultAnalysis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Result Analysis"
        Me.grpMultiExaminations.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Label10 As Label
    Friend WithEvents btnAddExam As Button
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents chkMode As CheckBox
    Friend WithEvents btnEnterMarks As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents cboSortBy As ComboBox
    Friend WithEvents txtContribution As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents cboClass As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboExamName As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboYear As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboTerm As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents grpMultiExaminations As GroupBox
    Friend WithEvents lstExaminations As ListView
End Class
