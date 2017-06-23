<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubjectPerformanceSpecific
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSubjectPerformanceSpecific))
        Me.printpreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstExaminations = New System.Windows.Forms.ListView()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.grpSelect = New System.Windows.Forms.GroupBox()
        Me.chkMode = New System.Windows.Forms.CheckBox()
        Me.txtContribution = New System.Windows.Forms.TextBox()
        Me.btnAddExam = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpMultiExaminations = New System.Windows.Forms.GroupBox()
        Me.btnAnalyze = New System.Windows.Forms.Button()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.cboExamName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTerm = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGradesAttained = New System.Windows.Forms.Button()
        Me.btnStudentRank = New System.Windows.Forms.Button()
        Me.btnMeanGradeAnalysis = New System.Windows.Forms.Button()
        Me.chkBestOf7 = New System.Windows.Forms.CheckBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.grpAnalyze = New System.Windows.Forms.GroupBox()
        Me.radSubject = New System.Windows.Forms.CheckBox()
        Me.grpSelect.SuspendLayout()
        Me.grpMultiExaminations.SuspendLayout()
        Me.grpAnalyze.SuspendLayout()
        Me.SuspendLayout()
        '
        'printpreview
        '
        Me.printpreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.printpreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.printpreview.ClientSize = New System.Drawing.Size(400, 300)
        Me.printpreview.Enabled = True
        Me.printpreview.Icon = CType(resources.GetObject("printpreview.Icon"), System.Drawing.Icon)
        Me.printpreview.Name = "printpreview"
        Me.printpreview.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(404, 490)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 38)
        Me.btnClear.TabIndex = 17
        Me.btnClear.Text = "C&lear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(291, 490)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 38)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(338, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "List Of Examinations And Their Respective Contributions For Analysis:"
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
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Exam"
        Me.ColumnHeader1.Width = 150
        '
        'lstExaminations
        '
        Me.lstExaminations.BackColor = System.Drawing.SystemColors.Info
        Me.lstExaminations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstExaminations.ForeColor = System.Drawing.Color.IndianRed
        Me.lstExaminations.GridLines = True
        Me.lstExaminations.Location = New System.Drawing.Point(6, 31)
        Me.lstExaminations.Name = "lstExaminations"
        Me.lstExaminations.Size = New System.Drawing.Size(340, 101)
        Me.lstExaminations.TabIndex = 6
        Me.lstExaminations.UseCompatibleStateImageBehavior = False
        Me.lstExaminations.View = System.Windows.Forms.View.Details
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.Control
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(25, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(482, 29)
        Me.lblTitle.TabIndex = 21
        Me.lblTitle.Text = "SUBJECT PERFORMANCE ANALYSIS"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpSelect
        '
        Me.grpSelect.Controls.Add(Me.chkMode)
        Me.grpSelect.Controls.Add(Me.txtContribution)
        Me.grpSelect.Controls.Add(Me.btnAddExam)
        Me.grpSelect.Controls.Add(Me.Label8)
        Me.grpSelect.Controls.Add(Me.Label6)
        Me.grpSelect.Controls.Add(Me.grpMultiExaminations)
        Me.grpSelect.Controls.Add(Me.btnAnalyze)
        Me.grpSelect.Controls.Add(Me.cboClass)
        Me.grpSelect.Controls.Add(Me.cboExamName)
        Me.grpSelect.Controls.Add(Me.Label1)
        Me.grpSelect.Controls.Add(Me.Label2)
        Me.grpSelect.Controls.Add(Me.cboTerm)
        Me.grpSelect.Controls.Add(Me.Label3)
        Me.grpSelect.Controls.Add(Me.cboYear)
        Me.grpSelect.Controls.Add(Me.Label4)
        Me.grpSelect.Location = New System.Drawing.Point(38, 40)
        Me.grpSelect.Name = "grpSelect"
        Me.grpSelect.Size = New System.Drawing.Size(460, 312)
        Me.grpSelect.TabIndex = 19
        Me.grpSelect.TabStop = False
        Me.grpSelect.Text = "Select Examination(s)"
        '
        'chkMode
        '
        Me.chkMode.AutoSize = True
        Me.chkMode.Location = New System.Drawing.Point(92, 15)
        Me.chkMode.Name = "chkMode"
        Me.chkMode.Size = New System.Drawing.Size(202, 17)
        Me.chkMode.TabIndex = 27
        Me.chkMode.Text = "Analyse More Than One Examination"
        Me.chkMode.UseVisualStyleBackColor = True
        '
        'txtContribution
        '
        Me.txtContribution.BackColor = System.Drawing.SystemColors.Info
        Me.txtContribution.ForeColor = System.Drawing.Color.IndianRed
        Me.txtContribution.Location = New System.Drawing.Point(92, 98)
        Me.txtContribution.Name = "txtContribution"
        Me.txtContribution.Size = New System.Drawing.Size(123, 21)
        Me.txtContribution.TabIndex = 48
        '
        'btnAddExam
        '
        Me.btnAddExam.Image = CType(resources.GetObject("btnAddExam.Image"), System.Drawing.Image)
        Me.btnAddExam.Location = New System.Drawing.Point(311, 97)
        Me.btnAddExam.Name = "btnAddExam"
        Me.btnAddExam.Size = New System.Drawing.Size(127, 23)
        Me.btnAddExam.TabIndex = 49
        Me.btnAddExam.Text = "&Add Examination"
        Me.btnAddExam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddExam.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(221, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "% of 100%"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Contribution:"
        '
        'grpMultiExaminations
        '
        Me.grpMultiExaminations.Controls.Add(Me.lstExaminations)
        Me.grpMultiExaminations.Controls.Add(Me.Label5)
        Me.grpMultiExaminations.Location = New System.Drawing.Point(85, 117)
        Me.grpMultiExaminations.Name = "grpMultiExaminations"
        Me.grpMultiExaminations.Size = New System.Drawing.Size(355, 136)
        Me.grpMultiExaminations.TabIndex = 52
        Me.grpMultiExaminations.TabStop = False
        '
        'btnAnalyze
        '
        Me.btnAnalyze.Image = CType(resources.GetObject("btnAnalyze.Image"), System.Drawing.Image)
        Me.btnAnalyze.Location = New System.Drawing.Point(301, 278)
        Me.btnAnalyze.Name = "btnAnalyze"
        Me.btnAnalyze.Size = New System.Drawing.Size(137, 30)
        Me.btnAnalyze.TabIndex = 3
        Me.btnAnalyze.Text = "Analyze Examination"
        Me.btnAnalyze.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAnalyze.UseVisualStyleBackColor = True
        '
        'cboClass
        '
        Me.cboClass.BackColor = System.Drawing.SystemColors.Info
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.ForeColor = System.Drawing.Color.IndianRed
        Me.cboClass.FormattingEnabled = True
        Me.cboClass.Location = New System.Drawing.Point(92, 255)
        Me.cboClass.Name = "cboClass"
        Me.cboClass.Size = New System.Drawing.Size(346, 21)
        Me.cboClass.TabIndex = 1
        '
        'cboExamName
        '
        Me.cboExamName.BackColor = System.Drawing.SystemColors.Info
        Me.cboExamName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExamName.ForeColor = System.Drawing.Color.IndianRed
        Me.cboExamName.FormattingEnabled = True
        Me.cboExamName.Location = New System.Drawing.Point(92, 76)
        Me.cboExamName.Name = "cboExamName"
        Me.cboExamName.Size = New System.Drawing.Size(346, 21)
        Me.cboExamName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Year:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Term:"
        '
        'cboTerm
        '
        Me.cboTerm.BackColor = System.Drawing.SystemColors.Info
        Me.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerm.ForeColor = System.Drawing.Color.IndianRed
        Me.cboTerm.FormattingEnabled = True
        Me.cboTerm.Items.AddRange(New Object() {"None", "I", "II", "III"})
        Me.cboTerm.Location = New System.Drawing.Point(91, 54)
        Me.cboTerm.Name = "cboTerm"
        Me.cboTerm.Size = New System.Drawing.Size(346, 21)
        Me.cboTerm.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Examination:"
        '
        'cboYear
        '
        Me.cboYear.BackColor = System.Drawing.SystemColors.Info
        Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYear.ForeColor = System.Drawing.Color.IndianRed
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(92, 32)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(346, 21)
        Me.cboYear.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(52, 258)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Class:"
        '
        'btnGradesAttained
        '
        Me.btnGradesAttained.Image = CType(resources.GetObject("btnGradesAttained.Image"), System.Drawing.Image)
        Me.btnGradesAttained.Location = New System.Drawing.Point(224, 35)
        Me.btnGradesAttained.Name = "btnGradesAttained"
        Me.btnGradesAttained.Size = New System.Drawing.Size(214, 40)
        Me.btnGradesAttained.TabIndex = 3
        Me.btnGradesAttained.Text = "Subject Performance Analysis"
        Me.btnGradesAttained.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGradesAttained.UseVisualStyleBackColor = True
        '
        'btnStudentRank
        '
        Me.btnStudentRank.Image = CType(resources.GetObject("btnStudentRank.Image"), System.Drawing.Image)
        Me.btnStudentRank.Location = New System.Drawing.Point(26, 35)
        Me.btnStudentRank.Name = "btnStudentRank"
        Me.btnStudentRank.Size = New System.Drawing.Size(192, 40)
        Me.btnStudentRank.TabIndex = 3
        Me.btnStudentRank.Text = "Student Ranking Per Subject"
        Me.btnStudentRank.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStudentRank.UseVisualStyleBackColor = True
        '
        'btnMeanGradeAnalysis
        '
        Me.btnMeanGradeAnalysis.Image = CType(resources.GetObject("btnMeanGradeAnalysis.Image"), System.Drawing.Image)
        Me.btnMeanGradeAnalysis.Location = New System.Drawing.Point(27, 78)
        Me.btnMeanGradeAnalysis.Name = "btnMeanGradeAnalysis"
        Me.btnMeanGradeAnalysis.Size = New System.Drawing.Size(192, 40)
        Me.btnMeanGradeAnalysis.TabIndex = 3
        Me.btnMeanGradeAnalysis.Text = "Subject Mean Analysis"
        Me.btnMeanGradeAnalysis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMeanGradeAnalysis.UseVisualStyleBackColor = True
        '
        'chkBestOf7
        '
        Me.chkBestOf7.AutoSize = True
        Me.chkBestOf7.Location = New System.Drawing.Point(41, 17)
        Me.chkBestOf7.Name = "chkBestOf7"
        Me.chkBestOf7.Size = New System.Drawing.Size(121, 17)
        Me.chkBestOf7.TabIndex = 37
        Me.chkBestOf7.Text = "Use Best Of 7 Mode"
        Me.chkBestOf7.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(225, 78)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(214, 40)
        Me.Button4.TabIndex = 39
        Me.Button4.Text = "Class Departmental Analysis"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = True
        '
        'grpAnalyze
        '
        Me.grpAnalyze.Controls.Add(Me.chkBestOf7)
        Me.grpAnalyze.Controls.Add(Me.Button4)
        Me.grpAnalyze.Controls.Add(Me.radSubject)
        Me.grpAnalyze.Controls.Add(Me.btnMeanGradeAnalysis)
        Me.grpAnalyze.Controls.Add(Me.btnGradesAttained)
        Me.grpAnalyze.Controls.Add(Me.btnStudentRank)
        Me.grpAnalyze.Location = New System.Drawing.Point(37, 358)
        Me.grpAnalyze.Name = "grpAnalyze"
        Me.grpAnalyze.Size = New System.Drawing.Size(460, 126)
        Me.grpAnalyze.TabIndex = 20
        Me.grpAnalyze.TabStop = False
        Me.grpAnalyze.Text = "Specific Subject Analysis"
        '
        'radSubject
        '
        Me.radSubject.AutoSize = True
        Me.radSubject.Location = New System.Drawing.Point(238, 17)
        Me.radSubject.Name = "radSubject"
        Me.radSubject.Size = New System.Drawing.Size(155, 17)
        Me.radSubject.TabIndex = 36
        Me.radSubject.Text = "Use Subject Based Grading"
        Me.radSubject.UseVisualStyleBackColor = True
        '
        'frmSubjectPerformanceSpecific
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 534)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.grpSelect)
        Me.Controls.Add(Me.grpAnalyze)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSubjectPerformanceSpecific"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Result Analysis"
        Me.grpSelect.ResumeLayout(False)
        Me.grpSelect.PerformLayout()
        Me.grpMultiExaminations.ResumeLayout(False)
        Me.grpAnalyze.ResumeLayout(False)
        Me.grpAnalyze.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents printpreview As PrintPreviewDialog
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents lstExaminations As ListView
    Friend WithEvents lblTitle As Label
    Friend WithEvents grpSelect As GroupBox
    Friend WithEvents chkMode As CheckBox
    Friend WithEvents txtContribution As TextBox
    Friend WithEvents btnAddExam As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents grpMultiExaminations As GroupBox
    Friend WithEvents btnAnalyze As Button
    Friend WithEvents cboClass As ComboBox
    Friend WithEvents cboExamName As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboTerm As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboYear As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnGradesAttained As Button
    Friend WithEvents btnStudentRank As Button
    Friend WithEvents btnMeanGradeAnalysis As Button
    Friend WithEvents chkBestOf7 As CheckBox
    Friend WithEvents Button4 As Button
    Friend WithEvents grpAnalyze As GroupBox
    Friend WithEvents radSubject As CheckBox
End Class
