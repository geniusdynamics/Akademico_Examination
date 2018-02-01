<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContribution
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContribution))
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.lstExaminations = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboSortBy = New System.Windows.Forms.ComboBox()
        Me.txtContribution = New System.Windows.Forms.TextBox()
        Me.grpMultiExaminations = New System.Windows.Forms.GroupBox()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboExamName = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTerm = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAddExam = New System.Windows.Forms.Button()
        Me.btnEnterMarks = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.analysisGB = New System.Windows.Forms.GroupBox()
        Me.cboSelectedYear = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rdSubjectBased = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rdClassBased = New System.Windows.Forms.RadioButton()
        Me.cboSelectedTerm = New System.Windows.Forms.ComboBox()
        Me.grpMultiExaminations.SuspendLayout()
        Me.analysisGB.SuspendLayout()
        Me.SuspendLayout()
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Exam"
        Me.ColumnHeader1.Width = 100
        '
        'lstExaminations
        '
        Me.lstExaminations.BackColor = System.Drawing.SystemColors.Info
        Me.lstExaminations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader3, Me.ColumnHeader5})
        Me.lstExaminations.ForeColor = System.Drawing.Color.IndianRed
        Me.lstExaminations.GridLines = True
        Me.lstExaminations.Location = New System.Drawing.Point(78, 20)
        Me.lstExaminations.Name = "lstExaminations"
        Me.lstExaminations.Size = New System.Drawing.Size(354, 101)
        Me.lstExaminations.TabIndex = 6
        Me.lstExaminations.UseCompatibleStateImageBehavior = False
        Me.lstExaminations.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Contribution"
        Me.ColumnHeader2.Width = 80
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
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Out Of"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 100)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "List Of Examinations And Their Respective Contributions For Analysis:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(45, 289)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "Rank By:"
        '
        'cboSortBy
        '
        Me.cboSortBy.BackColor = System.Drawing.SystemColors.Info
        Me.cboSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSortBy.ForeColor = System.Drawing.Color.IndianRed
        Me.cboSortBy.FormattingEnabled = True
        Me.cboSortBy.Items.AddRange(New Object() {"Total Marks", "Mean Marks", "Mean Points", "Total Points"})
        Me.cboSortBy.Location = New System.Drawing.Point(98, 286)
        Me.cboSortBy.Name = "cboSortBy"
        Me.cboSortBy.Size = New System.Drawing.Size(354, 21)
        Me.cboSortBy.TabIndex = 89
        '
        'txtContribution
        '
        Me.txtContribution.BackColor = System.Drawing.SystemColors.Info
        Me.txtContribution.ForeColor = System.Drawing.Color.IndianRed
        Me.txtContribution.Location = New System.Drawing.Point(101, 107)
        Me.txtContribution.Name = "txtContribution"
        Me.txtContribution.Size = New System.Drawing.Size(96, 20)
        Me.txtContribution.TabIndex = 76
        '
        'grpMultiExaminations
        '
        Me.grpMultiExaminations.Controls.Add(Me.lstExaminations)
        Me.grpMultiExaminations.Controls.Add(Me.Label5)
        Me.grpMultiExaminations.Location = New System.Drawing.Point(20, 126)
        Me.grpMultiExaminations.Name = "grpMultiExaminations"
        Me.grpMultiExaminations.Size = New System.Drawing.Size(439, 132)
        Me.grpMultiExaminations.TabIndex = 88
        Me.grpMultiExaminations.TabStop = False
        '
        'cboClass
        '
        Me.cboClass.BackColor = System.Drawing.SystemColors.Info
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.ForeColor = System.Drawing.Color.IndianRed
        Me.cboClass.FormattingEnabled = True
        Me.cboClass.Location = New System.Drawing.Point(98, 264)
        Me.cboClass.Name = "cboClass"
        Me.cboClass.Size = New System.Drawing.Size(354, 21)
        Me.cboClass.TabIndex = 78
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 266)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Class:"
        '
        'cboExamName
        '
        Me.cboExamName.BackColor = System.Drawing.SystemColors.Info
        Me.cboExamName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExamName.ForeColor = System.Drawing.Color.IndianRed
        Me.cboExamName.FormattingEnabled = True
        Me.cboExamName.Location = New System.Drawing.Point(100, 85)
        Me.cboExamName.Name = "cboExamName"
        Me.cboExamName.Size = New System.Drawing.Size(352, 21)
        Me.cboExamName.TabIndex = 75
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(203, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 82
        Me.Label8.Text = "% of 100%"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "Contribution:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Exam Name:"
        '
        'cboYear
        '
        Me.cboYear.BackColor = System.Drawing.SystemColors.Info
        Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYear.ForeColor = System.Drawing.Color.IndianRed
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Items.AddRange(New Object() {"None", "I", "II", "III"})
        Me.cboYear.Location = New System.Drawing.Point(100, 41)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(354, 21)
        Me.cboYear.TabIndex = 73
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(64, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Year:"
        '
        'cboTerm
        '
        Me.cboTerm.BackColor = System.Drawing.SystemColors.Info
        Me.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerm.ForeColor = System.Drawing.Color.IndianRed
        Me.cboTerm.FormattingEnabled = True
        Me.cboTerm.Items.AddRange(New Object() {"None", "I", "II", "III"})
        Me.cboTerm.Location = New System.Drawing.Point(100, 63)
        Me.cboTerm.Name = "cboTerm"
        Me.cboTerm.Size = New System.Drawing.Size(354, 21)
        Me.cboTerm.TabIndex = 74
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(59, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Term:"
        '
        'btnAddExam
        '
        Me.btnAddExam.Image = CType(resources.GetObject("btnAddExam.Image"), System.Drawing.Image)
        Me.btnAddExam.Location = New System.Drawing.Point(265, 106)
        Me.btnAddExam.Name = "btnAddExam"
        Me.btnAddExam.Size = New System.Drawing.Size(190, 23)
        Me.btnAddExam.TabIndex = 77
        Me.btnAddExam.Text = "&Add Examination"
        Me.btnAddExam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddExam.UseVisualStyleBackColor = True
        '
        'btnEnterMarks
        '
        Me.btnEnterMarks.Image = CType(resources.GetObject("btnEnterMarks.Image"), System.Drawing.Image)
        Me.btnEnterMarks.Location = New System.Drawing.Point(344, 433)
        Me.btnEnterMarks.Name = "btnEnterMarks"
        Me.btnEnterMarks.Size = New System.Drawing.Size(111, 32)
        Me.btnEnterMarks.TabIndex = 84
        Me.btnEnterMarks.Text = "&Analyse"
        Me.btnEnterMarks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEnterMarks.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(276, 433)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(63, 32)
        Me.btnClear.TabIndex = 86
        Me.btnClear.Text = "C&lear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(200, 433)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 32)
        Me.btnCancel.TabIndex = 87
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'analysisGB
        '
        Me.analysisGB.Controls.Add(Me.cboSelectedYear)
        Me.analysisGB.Controls.Add(Me.Label3)
        Me.analysisGB.Controls.Add(Me.rdSubjectBased)
        Me.analysisGB.Controls.Add(Me.Label9)
        Me.analysisGB.Controls.Add(Me.rdClassBased)
        Me.analysisGB.Controls.Add(Me.cboSelectedTerm)
        Me.analysisGB.Location = New System.Drawing.Point(20, 327)
        Me.analysisGB.Name = "analysisGB"
        Me.analysisGB.Size = New System.Drawing.Size(429, 100)
        Me.analysisGB.TabIndex = 96
        Me.analysisGB.TabStop = False
        Me.analysisGB.Text = "Use These Analysis Criteria"
        '
        'cboSelectedYear
        '
        Me.cboSelectedYear.BackColor = System.Drawing.SystemColors.Info
        Me.cboSelectedYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelectedYear.ForeColor = System.Drawing.Color.IndianRed
        Me.cboSelectedYear.FormattingEnabled = True
        Me.cboSelectedYear.Items.AddRange(New Object() {"I", "II", "III"})
        Me.cboSelectedYear.Location = New System.Drawing.Point(255, 58)
        Me.cboSelectedYear.Name = "cboSelectedYear"
        Me.cboSelectedYear.Size = New System.Drawing.Size(121, 21)
        Me.cboSelectedYear.TabIndex = 96
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(201, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Year"
        '
        'rdSubjectBased
        '
        Me.rdSubjectBased.AutoSize = True
        Me.rdSubjectBased.Checked = True
        Me.rdSubjectBased.Location = New System.Drawing.Point(13, 20)
        Me.rdSubjectBased.Name = "rdSubjectBased"
        Me.rdSubjectBased.Size = New System.Drawing.Size(123, 17)
        Me.rdSubjectBased.TabIndex = 91
        Me.rdSubjectBased.TabStop = True
        Me.rdSubjectBased.Text = "Use Subject Grading"
        Me.rdSubjectBased.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "Term"
        '
        'rdClassBased
        '
        Me.rdClassBased.AutoSize = True
        Me.rdClassBased.Location = New System.Drawing.Point(234, 20)
        Me.rdClassBased.Name = "rdClassBased"
        Me.rdClassBased.Size = New System.Drawing.Size(112, 17)
        Me.rdClassBased.TabIndex = 92
        Me.rdClassBased.Text = "Use Class Grading"
        Me.rdClassBased.UseVisualStyleBackColor = True
        '
        'cboSelectedTerm
        '
        Me.cboSelectedTerm.BackColor = System.Drawing.SystemColors.Info
        Me.cboSelectedTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelectedTerm.ForeColor = System.Drawing.Color.IndianRed
        Me.cboSelectedTerm.FormattingEnabled = True
        Me.cboSelectedTerm.Items.AddRange(New Object() {"I", "II", "III"})
        Me.cboSelectedTerm.Location = New System.Drawing.Point(58, 58)
        Me.cboSelectedTerm.Name = "cboSelectedTerm"
        Me.cboSelectedTerm.Size = New System.Drawing.Size(121, 21)
        Me.cboSelectedTerm.TabIndex = 93
        '
        'frmContribution
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 477)
        Me.ControlBox = False
        Me.Controls.Add(Me.analysisGB)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnAddExam)
        Me.Controls.Add(Me.btnEnterMarks)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.cboSortBy)
        Me.Controls.Add(Me.txtContribution)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grpMultiExaminations)
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
        Me.Name = "frmContribution"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Result Analysis"
        Me.grpMultiExaminations.ResumeLayout(False)
        Me.analysisGB.ResumeLayout(False)
        Me.analysisGB.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstExaminations As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnAddExam As System.Windows.Forms.Button
    Friend WithEvents btnEnterMarks As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents cboSortBy As System.Windows.Forms.ComboBox
    Friend WithEvents txtContribution As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpMultiExaminations As System.Windows.Forms.GroupBox
    Friend WithEvents cboClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboExamName As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTerm As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents analysisGB As System.Windows.Forms.GroupBox
    Friend WithEvents cboSelectedYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rdSubjectBased As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rdClassBased As System.Windows.Forms.RadioButton
    Friend WithEvents cboSelectedTerm As System.Windows.Forms.ComboBox
End Class
