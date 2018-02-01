<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResultMeanAnalysis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResultMeanAnalysis))
        Me.lstExaminations = New System.Windows.Forms.ListView()
        Me.colExam = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTerm = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colYear = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboSortBy = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpMultiExaminations = New System.Windows.Forms.GroupBox()
        Me.cboExamName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTerm = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.btnAddExam = New System.Windows.Forms.Button()
        Me.btnEnterMarks = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.rdSubjectBased = New System.Windows.Forms.RadioButton()
        Me.rdClassBased = New System.Windows.Forms.RadioButton()
        Me.cboSelectedTerm = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.analysisGB = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboSelectedYear = New System.Windows.Forms.ComboBox()
        Me.grpMultiExaminations.SuspendLayout()
        Me.analysisGB.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstExaminations
        '
        Me.lstExaminations.BackColor = System.Drawing.SystemColors.Info
        Me.lstExaminations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colExam, Me.colTerm, Me.colYear})
        Me.lstExaminations.ForeColor = System.Drawing.Color.IndianRed
        Me.lstExaminations.GridLines = True
        Me.lstExaminations.Location = New System.Drawing.Point(86, 25)
        Me.lstExaminations.Name = "lstExaminations"
        Me.lstExaminations.Size = New System.Drawing.Size(290, 101)
        Me.lstExaminations.TabIndex = 6
        Me.lstExaminations.UseCompatibleStateImageBehavior = False
        Me.lstExaminations.View = System.Windows.Forms.View.Details
        '
        'colExam
        '
        Me.colExam.Text = "Exam"
        Me.colExam.Width = 151
        '
        'colTerm
        '
        Me.colTerm.Text = "Term"
        Me.colTerm.Width = 50
        '
        'colYear
        '
        Me.colYear.Text = "Year"
        Me.colYear.Width = 50
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 100)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "List Of Examinations"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(52, 274)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
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
        Me.cboSortBy.Location = New System.Drawing.Point(105, 271)
        Me.cboSortBy.Name = "cboSortBy"
        Me.cboSortBy.Size = New System.Drawing.Size(348, 21)
        Me.cboSortBy.TabIndex = 89
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 251)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Class:"
        '
        'grpMultiExaminations
        '
        Me.grpMultiExaminations.Controls.Add(Me.lstExaminations)
        Me.grpMultiExaminations.Controls.Add(Me.Label5)
        Me.grpMultiExaminations.Location = New System.Drawing.Point(27, 111)
        Me.grpMultiExaminations.Name = "grpMultiExaminations"
        Me.grpMultiExaminations.Size = New System.Drawing.Size(429, 132)
        Me.grpMultiExaminations.TabIndex = 88
        Me.grpMultiExaminations.TabStop = False
        '
        'cboExamName
        '
        Me.cboExamName.BackColor = System.Drawing.SystemColors.Info
        Me.cboExamName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExamName.ForeColor = System.Drawing.Color.IndianRed
        Me.cboExamName.FormattingEnabled = True
        Me.cboExamName.Location = New System.Drawing.Point(107, 70)
        Me.cboExamName.Name = "cboExamName"
        Me.cboExamName.Size = New System.Drawing.Size(349, 21)
        Me.cboExamName.TabIndex = 75
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 73)
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
        Me.cboYear.Location = New System.Drawing.Point(107, 26)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(348, 21)
        Me.cboYear.TabIndex = 73
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(71, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
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
        Me.cboTerm.Location = New System.Drawing.Point(107, 48)
        Me.cboTerm.Name = "cboTerm"
        Me.cboTerm.Size = New System.Drawing.Size(348, 21)
        Me.cboTerm.TabIndex = 74
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(66, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Term:"
        '
        'cboClass
        '
        Me.cboClass.BackColor = System.Drawing.SystemColors.Info
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.ForeColor = System.Drawing.Color.IndianRed
        Me.cboClass.FormattingEnabled = True
        Me.cboClass.Location = New System.Drawing.Point(105, 249)
        Me.cboClass.Name = "cboClass"
        Me.cboClass.Size = New System.Drawing.Size(348, 21)
        Me.cboClass.TabIndex = 78
        '
        'btnAddExam
        '
        Me.btnAddExam.Image = CType(resources.GetObject("btnAddExam.Image"), System.Drawing.Image)
        Me.btnAddExam.Location = New System.Drawing.Point(272, 91)
        Me.btnAddExam.Name = "btnAddExam"
        Me.btnAddExam.Size = New System.Drawing.Size(184, 23)
        Me.btnAddExam.TabIndex = 77
        Me.btnAddExam.Text = "&Add Examination"
        Me.btnAddExam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddExam.UseVisualStyleBackColor = True
        '
        'btnEnterMarks
        '
        Me.btnEnterMarks.Image = CType(resources.GetObject("btnEnterMarks.Image"), System.Drawing.Image)
        Me.btnEnterMarks.Location = New System.Drawing.Point(340, 415)
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
        Me.btnClear.Location = New System.Drawing.Point(272, 415)
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
        Me.btnCancel.Location = New System.Drawing.Point(196, 415)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 32)
        Me.btnCancel.TabIndex = 87
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'rdSubjectBased
        '
        Me.rdSubjectBased.AutoSize = True
        Me.rdSubjectBased.Checked = True
        Me.rdSubjectBased.Location = New System.Drawing.Point(13, 20)
        Me.rdSubjectBased.Name = "rdSubjectBased"
        Me.rdSubjectBased.Size = New System.Drawing.Size(122, 17)
        Me.rdSubjectBased.TabIndex = 91
        Me.rdSubjectBased.TabStop = True
        Me.rdSubjectBased.Text = "Use Subject Grading"
        Me.rdSubjectBased.UseVisualStyleBackColor = True
        '
        'rdClassBased
        '
        Me.rdClassBased.AutoSize = True
        Me.rdClassBased.Location = New System.Drawing.Point(234, 20)
        Me.rdClassBased.Name = "rdClassBased"
        Me.rdClassBased.Size = New System.Drawing.Size(111, 17)
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "Term"
        '
        'analysisGB
        '
        Me.analysisGB.Controls.Add(Me.cboSelectedYear)
        Me.analysisGB.Controls.Add(Me.Label6)
        Me.analysisGB.Controls.Add(Me.rdSubjectBased)
        Me.analysisGB.Controls.Add(Me.Label3)
        Me.analysisGB.Controls.Add(Me.rdClassBased)
        Me.analysisGB.Controls.Add(Me.cboSelectedTerm)
        Me.analysisGB.Location = New System.Drawing.Point(27, 309)
        Me.analysisGB.Name = "analysisGB"
        Me.analysisGB.Size = New System.Drawing.Size(429, 100)
        Me.analysisGB.TabIndex = 95
        Me.analysisGB.TabStop = False
        Me.analysisGB.Text = "Use These Analysis Criteria"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(201, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Year"
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
        'frmResultMeanAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 458)
        Me.ControlBox = False
        Me.Controls.Add(Me.analysisGB)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnAddExam)
        Me.Controls.Add(Me.btnEnterMarks)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.cboSortBy)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grpMultiExaminations)
        Me.Controls.Add(Me.cboExamName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTerm)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboClass)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmResultMeanAnalysis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Result Mean Analysis"
        Me.grpMultiExaminations.ResumeLayout(False)
        Me.analysisGB.ResumeLayout(False)
        Me.analysisGB.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstExaminations As System.Windows.Forms.ListView
    Friend WithEvents colExam As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTerm As System.Windows.Forms.ColumnHeader
    Friend WithEvents colYear As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnAddExam As System.Windows.Forms.Button
    Friend WithEvents btnEnterMarks As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents cboSortBy As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpMultiExaminations As System.Windows.Forms.GroupBox
    Friend WithEvents cboExamName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTerm As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboClass As System.Windows.Forms.ComboBox
    Friend WithEvents rdSubjectBased As System.Windows.Forms.RadioButton
    Friend WithEvents rdClassBased As System.Windows.Forms.RadioButton
    Friend WithEvents cboSelectedTerm As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents analysisGB As System.Windows.Forms.GroupBox
    Friend WithEvents cboSelectedYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
