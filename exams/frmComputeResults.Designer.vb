<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComputeResults
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComputeResults))
        Me.dgvMeanMarks = New System.Windows.Forms.DataGridView()
        Me.ADMNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StudentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.chkMarksGrade = New System.Windows.Forms.CheckBox()
        Me.btnIndexing = New DevExpress.XtraEditors.SimpleButton()
        Me.Button3 = New DevExpress.XtraEditors.SimpleButton()
        Me.chkMode = New System.Windows.Forms.CheckBox()
        Me.Button4 = New DevExpress.XtraEditors.SimpleButton()
        Me.printpreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnClassPerformance = New DevExpress.XtraEditors.SimpleButton()
        Me.btnStreamPerformance = New DevExpress.XtraEditors.SimpleButton()
        Me.radSubject = New System.Windows.Forms.CheckBox()
        CType(Me.dgvMeanMarks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMeanMarks
        '
        Me.dgvMeanMarks.AllowUserToAddRows = False
        Me.dgvMeanMarks.AllowUserToDeleteRows = False
        Me.dgvMeanMarks.AllowUserToOrderColumns = True
        Me.dgvMeanMarks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMeanMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMeanMarks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ADMNo, Me.StudentName, Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dgvMeanMarks.Location = New System.Drawing.Point(3, 3)
        Me.dgvMeanMarks.Name = "dgvMeanMarks"
        Me.dgvMeanMarks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMeanMarks.Size = New System.Drawing.Size(1142, 448)
        Me.dgvMeanMarks.TabIndex = 5
        '
        'ADMNo
        '
        Me.ADMNo.HeaderText = "ADM."
        Me.ADMNo.Name = "ADMNo"
        Me.ADMNo.Width = 59
        '
        'StudentName
        '
        Me.StudentName.HeaderText = "Name Of Student"
        Me.StudentName.Name = "StudentName"
        Me.StudentName.Width = 105
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        Me.Column1.Width = 54
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        Me.Column2.Width = 54
        '
        'Column3
        '
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        Me.Column3.Visible = False
        Me.Column3.Width = 54
        '
        'Column4
        '
        Me.Column4.HeaderText = "Column4"
        Me.Column4.Name = "Column4"
        Me.Column4.Visible = False
        Me.Column4.Width = 54
        '
        'chkMarksGrade
        '
        Me.chkMarksGrade.Location = New System.Drawing.Point(12, 486)
        Me.chkMarksGrade.Name = "chkMarksGrade"
        Me.chkMarksGrade.Size = New System.Drawing.Size(128, 20)
        Me.chkMarksGrade.TabIndex = 9
        Me.chkMarksGrade.Text = "Show Marks + Grade"
        Me.chkMarksGrade.UseVisualStyleBackColor = True
        '
        'btnIndexing
        '
        Me.btnIndexing.ImageOptions.Image = CType(resources.GetObject("btnIndexing.ImageOptions.Image"), System.Drawing.Image)
        Me.btnIndexing.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnIndexing.Location = New System.Drawing.Point(146, 473)
        Me.btnIndexing.Name = "btnIndexing"
        Me.btnIndexing.Size = New System.Drawing.Size(135, 39)
        Me.btnIndexing.TabIndex = 14
        Me.btnIndexing.Text = "Use Analysis For Indexing"
        '
        'Button3
        '
        Me.Button3.ImageOptions.Image = CType(resources.GetObject("Button3.ImageOptions.Image"), System.Drawing.Image)
        Me.Button3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.Button3.Location = New System.Drawing.Point(300, 473)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(122, 39)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Export To Excel"
        '
        'chkMode
        '
        Me.chkMode.Location = New System.Drawing.Point(443, 492)
        Me.chkMode.Name = "chkMode"
        Me.chkMode.Size = New System.Drawing.Size(128, 20)
        Me.chkMode.TabIndex = 16
        Me.chkMode.Text = "Best Of 7"
        Me.chkMode.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.ImageOptions.Image = CType(resources.GetObject("Button4.ImageOptions.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(898, 471)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(179, 41)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "Save Examination Performance"
        Me.Button4.Visible = False
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
        'btnClassPerformance
        '
        Me.btnClassPerformance.ImageOptions.Image = CType(resources.GetObject("btnClassPerformance.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClassPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnClassPerformance.Location = New System.Drawing.Point(528, 473)
        Me.btnClassPerformance.Name = "btnClassPerformance"
        Me.btnClassPerformance.Size = New System.Drawing.Size(138, 39)
        Me.btnClassPerformance.TabIndex = 19
        Me.btnClassPerformance.Text = "&Class Merit List"
        '
        'btnStreamPerformance
        '
        Me.btnStreamPerformance.ImageOptions.Image = CType(resources.GetObject("btnStreamPerformance.ImageOptions.Image"), System.Drawing.Image)
        Me.btnStreamPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnStreamPerformance.Location = New System.Drawing.Point(685, 473)
        Me.btnStreamPerformance.Name = "btnStreamPerformance"
        Me.btnStreamPerformance.Size = New System.Drawing.Size(128, 39)
        Me.btnStreamPerformance.TabIndex = 20
        Me.btnStreamPerformance.Text = "&Stream Merit List"
        '
        'radSubject
        '
        Me.radSubject.Checked = True
        Me.radSubject.CheckState = System.Windows.Forms.CheckState.Checked
        Me.radSubject.Location = New System.Drawing.Point(819, 482)
        Me.radSubject.Name = "radSubject"
        Me.radSubject.Size = New System.Drawing.Size(73, 20)
        Me.radSubject.TabIndex = 21
        Me.radSubject.Text = "Use Subject Grading"
        Me.radSubject.UseVisualStyleBackColor = True
        Me.radSubject.Visible = False
        '
        'frmComputeResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 524)
        Me.Controls.Add(Me.radSubject)
        Me.Controls.Add(Me.btnStreamPerformance)
        Me.Controls.Add(Me.btnClassPerformance)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.chkMode)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnIndexing)
        Me.Controls.Add(Me.chkMarksGrade)
        Me.Controls.Add(Me.dgvMeanMarks)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComputeResults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exam Result Analysis"
        CType(Me.dgvMeanMarks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvMeanMarks As System.Windows.Forms.DataGridView
    Friend WithEvents ADMNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StudentName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents chkMarksGrade As System.Windows.Forms.CheckBox
    Friend WithEvents btnIndexing As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkMode As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents printpreview As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents btnClassPerformance As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnStreamPerformance As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents radSubject As System.Windows.Forms.CheckBox
End Class
