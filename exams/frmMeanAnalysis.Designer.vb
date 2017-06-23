<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMeanAnalysis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMeanAnalysis))
        Me.dgvSubjects = New System.Windows.Forms.DataGridView()
        Me.SubjID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abbreviation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubjectName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeanMark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeanGrade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeanPoints = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.printpreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvSubjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvSubjects
        '
        Me.dgvSubjects.AllowUserToAddRows = False
        Me.dgvSubjects.AllowUserToDeleteRows = False
        Me.dgvSubjects.AllowUserToResizeColumns = False
        Me.dgvSubjects.AllowUserToResizeRows = False
        Me.dgvSubjects.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubjects.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SubjID, Me.Abbreviation, Me.SubjectName, Me.MeanMark, Me.MeanGrade, Me.MeanPoints})
        Me.dgvSubjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSubjects.GridColor = System.Drawing.Color.IndianRed
        Me.dgvSubjects.Location = New System.Drawing.Point(3, 16)
        Me.dgvSubjects.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvSubjects.Name = "dgvSubjects"
        Me.dgvSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSubjects.Size = New System.Drawing.Size(607, 429)
        Me.dgvSubjects.TabIndex = 0
        '
        'SubjID
        '
        Me.SubjID.HeaderText = "Subject ID"
        Me.SubjID.Name = "SubjID"
        Me.SubjID.ReadOnly = True
        Me.SubjID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.SubjID.Visible = False
        '
        'Abbreviation
        '
        Me.Abbreviation.HeaderText = "Abbreviation"
        Me.Abbreviation.Name = "Abbreviation"
        Me.Abbreviation.ReadOnly = True
        Me.Abbreviation.Width = 80
        '
        'SubjectName
        '
        Me.SubjectName.HeaderText = "Subject Name"
        Me.SubjectName.Name = "SubjectName"
        Me.SubjectName.ReadOnly = True
        Me.SubjectName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.SubjectName.Width = 200
        '
        'MeanMark
        '
        Me.MeanMark.HeaderText = "Mean Mark"
        Me.MeanMark.Name = "MeanMark"
        Me.MeanMark.ReadOnly = True
        Me.MeanMark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.MeanMark.Width = 90
        '
        'MeanGrade
        '
        Me.MeanGrade.HeaderText = "Mean Grade"
        Me.MeanGrade.Name = "MeanGrade"
        Me.MeanGrade.ReadOnly = True
        Me.MeanGrade.Width = 90
        '
        'MeanPoints
        '
        Me.MeanPoints.HeaderText = "Mean Points"
        Me.MeanPoints.Name = "MeanPoints"
        Me.MeanPoints.ReadOnly = True
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Image = CType(resources.GetObject("btnPrintPreview.Image"), System.Drawing.Image)
        Me.btnPrintPreview.Location = New System.Drawing.Point(422, 481)
        Me.btnPrintPreview.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(92, 29)
        Me.btnPrintPreview.TabIndex = 22
        Me.btnPrintPreview.Text = "&List Report"
        Me.btnPrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrintPreview.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(343, 481)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(73, 29)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvSubjects)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 30)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(613, 447)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.Control
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 7)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(640, 37)
        Me.lblTitle.TabIndex = 20
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(520, 481)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 29)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "&Group Report"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmMeanAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 517)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMeanAnalysis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subject Result Analysis"
        CType(Me.dgvSubjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvSubjects As DataGridView
    Friend WithEvents SubjID As DataGridViewTextBoxColumn
    Friend WithEvents Abbreviation As DataGridViewTextBoxColumn
    Friend WithEvents SubjectName As DataGridViewTextBoxColumn
    Friend WithEvents MeanMark As DataGridViewTextBoxColumn
    Friend WithEvents MeanGrade As DataGridViewTextBoxColumn
    Friend WithEvents MeanPoints As DataGridViewTextBoxColumn
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents printpreview As PrintPreviewDialog
    Friend WithEvents Button1 As Button
End Class
