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
        Me.frmMeanResultsLayoutControl1ConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.btnStreamPerformance = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClassPerformance = New DevExpress.XtraEditors.SimpleButton()
        Me.Button3 = New DevExpress.XtraEditors.SimpleButton()
        Me.Button6 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        CType(Me.dgvMeanMarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frmMeanResultsLayoutControl1ConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmMeanResultsLayoutControl1ConvertedLayout.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgvMeanMarks.Size = New System.Drawing.Size(1127, 274)
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
        Me.chkMode.Location = New System.Drawing.Point(336, 290)
        Me.chkMode.Name = "chkMode"
        Me.chkMode.Size = New System.Drawing.Size(157, 20)
        Me.chkMode.TabIndex = 16
        Me.chkMode.Text = "Best Of 7"
        Me.chkMode.UseVisualStyleBackColor = True
        '
        'marksGrade
        '
        Me.marksGrade.Location = New System.Drawing.Point(497, 333)
        Me.marksGrade.Name = "marksGrade"
        Me.marksGrade.Size = New System.Drawing.Size(319, 20)
        Me.marksGrade.TabIndex = 18
        Me.marksGrade.Text = "Show Marks + Grade"
        Me.marksGrade.UseVisualStyleBackColor = True
        '
        'radSubject
        '
        Me.radSubject.Checked = True
        Me.radSubject.CheckState = System.Windows.Forms.CheckState.Checked
        Me.radSubject.Location = New System.Drawing.Point(820, 290)
        Me.radSubject.Name = "radSubject"
        Me.radSubject.Size = New System.Drawing.Size(138, 20)
        Me.radSubject.TabIndex = 23
        Me.radSubject.Text = "Use Subject Grading"
        Me.radSubject.UseVisualStyleBackColor = True
        Me.radSubject.Visible = False
        '
        'Button4
        '
        Me.Button4.ImageOptions.Image = CType(resources.GetObject("Button4.ImageOptions.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(962, 290)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(177, 22)
        Me.Button4.StyleController = Me.frmMeanResultsLayoutControl1ConvertedLayout
        Me.Button4.TabIndex = 24
        Me.Button4.Text = "Save Examination Performance"
        Me.Button4.Visible = False
        '
        'frmMeanResultsLayoutControl1ConvertedLayout
        '
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(Me.Button4)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(Me.radSubject)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(Me.btnStreamPerformance)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(Me.btnClassPerformance)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(Me.marksGrade)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(Me.chkMode)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(Me.Button3)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(Me.Button6)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Controls.Add(Me.dgvMeanMarks)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Name = "frmMeanResultsLayoutControl1ConvertedLayout"
        Me.frmMeanResultsLayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(215, 248, 450, 400)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Root = Me.LayoutControlGroup1
        Me.frmMeanResultsLayoutControl1ConvertedLayout.Size = New System.Drawing.Size(1151, 365)
        Me.frmMeanResultsLayoutControl1ConvertedLayout.TabIndex = 25
        '
        'btnStreamPerformance
        '
        Me.btnStreamPerformance.ImageOptions.Image = CType(resources.GetObject("btnStreamPerformance.ImageOptions.Image"), System.Drawing.Image)
        Me.btnStreamPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnStreamPerformance.Location = New System.Drawing.Point(659, 290)
        Me.btnStreamPerformance.Name = "btnStreamPerformance"
        Me.btnStreamPerformance.Size = New System.Drawing.Size(157, 39)
        Me.btnStreamPerformance.StyleController = Me.frmMeanResultsLayoutControl1ConvertedLayout
        Me.btnStreamPerformance.TabIndex = 22
        Me.btnStreamPerformance.Text = "&Stream Merit List"
        '
        'btnClassPerformance
        '
        Me.btnClassPerformance.ImageOptions.Image = CType(resources.GetObject("btnClassPerformance.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClassPerformance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnClassPerformance.Location = New System.Drawing.Point(497, 290)
        Me.btnClassPerformance.Name = "btnClassPerformance"
        Me.btnClassPerformance.Size = New System.Drawing.Size(158, 39)
        Me.btnClassPerformance.StyleController = Me.frmMeanResultsLayoutControl1ConvertedLayout
        Me.btnClassPerformance.TabIndex = 21
        Me.btnClassPerformance.Text = "&Class Merit List"
        '
        'Button3
        '
        Me.Button3.ImageOptions.Image = CType(resources.GetObject("Button3.ImageOptions.Image"), System.Drawing.Image)
        Me.Button3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.Button3.Location = New System.Drawing.Point(174, 290)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(158, 39)
        Me.Button3.StyleController = Me.frmMeanResultsLayoutControl1ConvertedLayout
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Export To Excel"
        '
        'Button6
        '
        Me.Button6.ImageOptions.Image = CType(resources.GetObject("Button6.ImageOptions.Image"), System.Drawing.Image)
        Me.Button6.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.Button6.Location = New System.Drawing.Point(12, 290)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(158, 39)
        Me.Button6.StyleController = Me.frmMeanResultsLayoutControl1ConvertedLayout
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "Use Analysis For Indexing"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.EmptySpaceItem1, Me.SimpleSeparator1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1151, 365)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Button4
        Me.LayoutControlItem1.Location = New System.Drawing.Point(950, 278)
        Me.LayoutControlItem1.Name = "Button4item"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(181, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.radSubject
        Me.LayoutControlItem2.Location = New System.Drawing.Point(808, 278)
        Me.LayoutControlItem2.Name = "radSubjectitem"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(142, 67)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnStreamPerformance
        Me.LayoutControlItem3.Location = New System.Drawing.Point(647, 278)
        Me.LayoutControlItem3.Name = "btnStreamPerformanceitem"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(161, 43)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnClassPerformance
        Me.LayoutControlItem4.Location = New System.Drawing.Point(485, 278)
        Me.LayoutControlItem4.Name = "btnClassPerformanceitem"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(162, 43)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.marksGrade
        Me.LayoutControlItem5.Location = New System.Drawing.Point(485, 321)
        Me.LayoutControlItem5.Name = "marksGradeitem"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(323, 24)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.chkMode
        Me.LayoutControlItem7.Location = New System.Drawing.Point(324, 278)
        Me.LayoutControlItem7.Name = "chkModeitem"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(161, 67)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.Button3
        Me.LayoutControlItem8.Location = New System.Drawing.Point(162, 278)
        Me.LayoutControlItem8.Name = "Button3item"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(162, 67)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.Button6
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 278)
        Me.LayoutControlItem9.Name = "Button6item"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(162, 67)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.dgvMeanMarks
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "dgvMeanMarksitem"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(1131, 278)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(950, 304)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(181, 39)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(950, 343)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(181, 2)
        '
        'frmMeanResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1151, 365)
        Me.Controls.Add(Me.frmMeanResultsLayoutControl1ConvertedLayout)
        Me.Name = "frmMeanResults"
        Me.Text = "Mean Results"
        CType(Me.dgvMeanMarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frmMeanResultsLayoutControl1ConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmMeanResultsLayoutControl1ConvertedLayout.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents marksGrade As System.Windows.Forms.CheckBox
    Friend WithEvents btnStreamPerformance As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClassPerformance As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents radSubject As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents frmMeanResultsLayoutControl1ConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
End Class
