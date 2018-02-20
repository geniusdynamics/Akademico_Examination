<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMeanResults
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMeanResults))
        Me.dgvMeanMarks = New System.Windows.Forms.DataGridView()
        Me.ADMNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StudentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.chkMode = New System.Windows.Forms.CheckBox()
        Me.marksGrade = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.radSubject = New System.Windows.Forms.CheckBox()
        Me.Button4 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnStreamPerformance = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClassPerformance = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.Button3 = New DevExpress.XtraEditors.SimpleButton()
        Me.Button6 = New DevExpress.XtraEditors.SimpleButton()
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
        Me.dgvMeanMarks.Location = New System.Drawing.Point(12, 12)
        Me.dgvMeanMarks.Name = "dgvMeanMarks"
        Me.dgvMeanMarks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMeanMarks.Size = New System.Drawing.Size(1130, 427)
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
        'chkMode
        '
        Me.chkMode.Location = New System.Drawing.Point(294, 464)
        Me.chkMode.Name = "chkMode"
        Me.chkMode.Size = New System.Drawing.Size(128, 20)
        Me.chkMode.TabIndex = 16
        Me.chkMode.Text = "Best Of 7"
        Me.chkMode.UseVisualStyleBackColor = True
        '
        'marksGrade
        '
        Me.marksGrade.Location = New System.Drawing.Point(413, 464)
        Me.marksGrade.Name = "marksGrade"
        Me.marksGrade.Size = New System.Drawing.Size(191, 20)
        Me.marksGrade.TabIndex = 18
        Me.marksGrade.Text = "Show Marks + Grade"
        Me.marksGrade.UseVisualStyleBackColor = True
        '
        'radSubject
        '
        Me.radSubject.Checked = True
        Me.radSubject.CheckState = System.Windows.Forms.CheckState.Checked
        Me.radSubject.Location = New System.Drawing.Point(864, 464)
        Me.radSubject.Name = "radSubject"
        Me.radSubject.Size = New System.Drawing.Size(73, 20)
        Me.radSubject.TabIndex = 23
        Me.radSubject.Text = "Use Subject Grading"
        Me.radSubject.UseVisualStyleBackColor = True
        Me.radSubject.Visible = False
        '
        'Button4
        '
        Me.Button4.ImageOptions.Image = CType(resources.GetObject("Button4.ImageOptions.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(943, 445)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(179, 41)
        Me.Button4.TabIndex = 24
        Me.Button4.Text = "Save Examination Performance"
        Me.Button4.Visible = False
        '
        'btnStreamPerformance
        '
        Me.btnStreamPerformance.ImageOptions.Image = CType(resources.GetObject("btnStreamPerformance.ImageOptions.Image"), System.Drawing.Image)
        Me.btnStreamPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnStreamPerformance.Location = New System.Drawing.Point(707, 445)
        Me.btnStreamPerformance.Name = "btnStreamPerformance"
        Me.btnStreamPerformance.Size = New System.Drawing.Size(128, 39)
        Me.btnStreamPerformance.TabIndex = 22
        Me.btnStreamPerformance.Text = "&Stream Merit List"
        '
        'btnClassPerformance
        '
        Me.btnClassPerformance.ImageOptions.Image = CType(resources.GetObject("btnClassPerformance.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClassPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnClassPerformance.Location = New System.Drawing.Point(550, 445)
        Me.btnClassPerformance.Name = "btnClassPerformance"
        Me.btnClassPerformance.Size = New System.Drawing.Size(138, 39)
        Me.btnClassPerformance.TabIndex = 21
        Me.btnClassPerformance.Text = "&Class Merit List"
        '
        'btnCancel
        '
        Me.btnCancel.ImageOptions.Image = CType(resources.GetObject("btnCancel.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnCancel.Location = New System.Drawing.Point(1150, 445)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(53, 39)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "&Quit"
        '
        'Button3
        '
        Me.Button3.ImageOptions.Image = CType(resources.GetObject("Button3.ImageOptions.Image"), System.Drawing.Image)
        Me.Button3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.Button3.Location = New System.Drawing.Point(153, 445)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(122, 39)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Export To Excel"
        '
        'Button6
        '
        Me.Button6.ImageOptions.Image = CType(resources.GetObject("Button6.ImageOptions.Image"), System.Drawing.Image)
        Me.Button6.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.Button6.Location = New System.Drawing.Point(12, 445)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(135, 39)
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "Use Analysis For Indexing"
        '
        'frmMeanResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1151, 496)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.radSubject)
        Me.Controls.Add(Me.btnStreamPerformance)
        Me.Controls.Add(Me.btnClassPerformance)
        Me.Controls.Add(Me.marksGrade)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.chkMode)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.dgvMeanMarks)
        Me.Name = "frmMeanResults"
        Me.Text = "Mean Results"
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
    Friend WithEvents Button6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkMode As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents marksGrade As System.Windows.Forms.CheckBox
    Friend WithEvents btnStreamPerformance As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClassPerformance As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents radSubject As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As DevExpress.XtraEditors.SimpleButton
End Class
