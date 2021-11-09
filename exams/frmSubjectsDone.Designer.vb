<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubjectsDone
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSubjectsDone))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cboStream = New System.Windows.Forms.ComboBox()
        Me.btnview = New DevExpress.XtraEditors.SimpleButton()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.btnEnterMarks = New DevExpress.XtraEditors.SimpleButton()
        Me.dgvIndexNo = New System.Windows.Forms.DataGridView()
        Me.ADMNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StudentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.str_class = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IndexNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.dgvIndexNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cboStream)
        Me.LayoutControl1.Controls.Add(Me.btnview)
        Me.LayoutControl1.Controls.Add(Me.cboClass)
        Me.LayoutControl1.Controls.Add(Me.btnEnterMarks)
        Me.LayoutControl1.Controls.Add(Me.dgvIndexNo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1043, 560)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cboStream
        '
        Me.cboStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStream.FormattingEnabled = True
        Me.cboStream.Location = New System.Drawing.Point(608, 16)
        Me.cboStream.Name = "cboStream"
        Me.cboStream.Size = New System.Drawing.Size(419, 24)
        Me.cboStream.TabIndex = 8
        '
        'btnview
        '
        Me.btnview.ImageOptions.Image = CType(resources.GetObject("btnview.ImageOptions.Image"), System.Drawing.Image)
        Me.btnview.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnview.Location = New System.Drawing.Point(947, 59)
        Me.btnview.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(80, 44)
        Me.btnview.StyleController = Me.LayoutControl1
        Me.btnview.TabIndex = 7
        Me.btnview.Text = "View"
        '
        'cboClass
        '
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.FormattingEnabled = True
        Me.cboClass.Location = New System.Drawing.Point(100, 16)
        Me.cboClass.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboClass.Name = "cboClass"
        Me.cboClass.Size = New System.Drawing.Size(418, 24)
        Me.cboClass.TabIndex = 6
        '
        'btnEnterMarks
        '
        Me.btnEnterMarks.ImageOptions.Image = CType(resources.GetObject("btnEnterMarks.ImageOptions.Image"), System.Drawing.Image)
        Me.btnEnterMarks.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnEnterMarks.Location = New System.Drawing.Point(936, 500)
        Me.btnEnterMarks.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEnterMarks.Name = "btnEnterMarks"
        Me.btnEnterMarks.Size = New System.Drawing.Size(91, 44)
        Me.btnEnterMarks.StyleController = Me.LayoutControl1
        Me.btnEnterMarks.TabIndex = 5
        Me.btnEnterMarks.Text = "Save"
        '
        'dgvIndexNo
        '
        Me.dgvIndexNo.AllowUserToAddRows = False
        Me.dgvIndexNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIndexNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ADMNo, Me.StudentName, Me.str_class, Me.IndexNo})
        Me.dgvIndexNo.Location = New System.Drawing.Point(16, 109)
        Me.dgvIndexNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvIndexNo.Name = "dgvIndexNo"
        Me.dgvIndexNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIndexNo.Size = New System.Drawing.Size(1011, 385)
        Me.dgvIndexNo.TabIndex = 4
        '
        'ADMNo
        '
        Me.ADMNo.HeaderText = "ADMNo"
        Me.ADMNo.Name = "ADMNo"
        '
        'StudentName
        '
        Me.StudentName.HeaderText = "Name Of Student"
        Me.StudentName.Name = "StudentName"
        '
        'str_class
        '
        Me.str_class.HeaderText = "Stream"
        Me.str_class.Name = "str_class"
        '
        'IndexNo
        '
        Me.IndexNo.HeaderText = "Index No"
        Me.IndexNo.Name = "IndexNo"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem2, Me.LayoutControlItem4, Me.EmptySpaceItem3, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1043, 560)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.dgvIndexNo
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 93)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1017, 391)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 484)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(920, 50)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnEnterMarks
        Me.LayoutControlItem2.Location = New System.Drawing.Point(920, 484)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(97, 50)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboClass
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(508, 32)
        Me.LayoutControlItem3.Text = "Select Class"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(81, 16)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 43)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(931, 50)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnview
        Me.LayoutControlItem4.Location = New System.Drawing.Point(931, 43)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(86, 50)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 32)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1017, 11)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboStream
        Me.LayoutControlItem5.Location = New System.Drawing.Point(508, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(509, 32)
        Me.LayoutControlItem5.Text = "Select Stream"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(81, 16)
        '
        'frmSubjectsDone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 560)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSubjectsDone"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subjects Done"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.dgvIndexNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnEnterMarks As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dgvIndexNo As DataGridView
    Friend WithEvents ADMNo As DataGridViewTextBoxColumn
    Friend WithEvents StudentName As DataGridViewTextBoxColumn
    Friend WithEvents str_class As DataGridViewTextBoxColumn
    Friend WithEvents IndexNo As DataGridViewTextBoxColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnview As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboClass As ComboBox
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboStream As ComboBox
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
