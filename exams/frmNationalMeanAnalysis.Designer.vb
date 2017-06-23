<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNationalMeanAnalysis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNationalMeanAnalysis))
        Me.dgvSubjects = New System.Windows.Forms.DataGridView()
        Me.SubjID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abbreviation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubjectName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeanPoints = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeanGrade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.printpreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
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
        Me.dgvSubjects.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SubjID, Me.Abbreviation, Me.SubjectName, Me.MeanPoints, Me.MeanGrade})
        Me.dgvSubjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSubjects.GridColor = System.Drawing.Color.IndianRed
        Me.dgvSubjects.Location = New System.Drawing.Point(3, 16)
        Me.dgvSubjects.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvSubjects.Name = "dgvSubjects"
        Me.dgvSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSubjects.Size = New System.Drawing.Size(521, 396)
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
        'MeanPoints
        '
        Me.MeanPoints.HeaderText = "Mean Points"
        Me.MeanPoints.Name = "MeanPoints"
        Me.MeanPoints.ReadOnly = True
        '
        'MeanGrade
        '
        Me.MeanGrade.HeaderText = "Mean Grade"
        Me.MeanGrade.Name = "MeanGrade"
        Me.MeanGrade.ReadOnly = True
        Me.MeanGrade.Width = 90
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvSubjects)
        Me.GroupBox1.Location = New System.Drawing.Point(40, 36)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(527, 414)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Stream:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(90, 15)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(156, 21)
        Me.ComboBox1.TabIndex = 25
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(445, 454)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(108, 29)
        Me.btnPrint.TabIndex = 22
        Me.btnPrint.Text = "&Group Report"
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Image = CType(resources.GetObject("btnPrintPreview.Image"), System.Drawing.Image)
        Me.btnPrintPreview.Location = New System.Drawing.Point(352, 454)
        Me.btnPrintPreview.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(87, 29)
        Me.btnPrintPreview.TabIndex = 23
        Me.btnPrintPreview.Text = "&List Report"
        Me.btnPrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrintPreview.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(260, 454)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(73, 29)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmNationalMeanAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 510)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnCancel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNationalMeanAnalysis"
        Me.Text = "frmNationalMeanAnalysis"
        CType(Me.dgvSubjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvSubjects As DataGridView
    Friend WithEvents SubjID As DataGridViewTextBoxColumn
    Friend WithEvents Abbreviation As DataGridViewTextBoxColumn
    Friend WithEvents SubjectName As DataGridViewTextBoxColumn
    Friend WithEvents MeanPoints As DataGridViewTextBoxColumn
    Friend WithEvents MeanGrade As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents printpreview As PrintPreviewDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents btnCancel As Button
End Class
