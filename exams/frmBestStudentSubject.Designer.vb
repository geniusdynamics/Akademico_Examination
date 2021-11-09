<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBestStudentSubject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBestStudentSubject))
        Me.computeDVG = New System.Windows.Forms.DataGridView()
        Me.resultDGV = New System.Windows.Forms.DataGridView()
        Me.ADMNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StudentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarkAttained = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GradeAttained = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Points = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.computeDVG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.resultDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'computeDVG
        '
        Me.computeDVG.AllowUserToAddRows = False
        Me.computeDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.computeDVG.Location = New System.Drawing.Point(12, 616)
        Me.computeDVG.Name = "computeDVG"
        Me.computeDVG.RowTemplate.Height = 24
        Me.computeDVG.Size = New System.Drawing.Size(1293, 42)
        Me.computeDVG.TabIndex = 1
        Me.computeDVG.Visible = False
        '
        'resultDGV
        '
        Me.resultDGV.AllowUserToAddRows = False
        Me.resultDGV.AllowUserToDeleteRows = False
        Me.resultDGV.AllowUserToResizeColumns = False
        Me.resultDGV.AllowUserToResizeRows = False
        Me.resultDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.resultDGV.BackgroundColor = System.Drawing.SystemColors.Info
        Me.resultDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.resultDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ADMNo, Me.StudentName, Me.Gender, Me.MarkAttained, Me.GradeAttained, Me.Points})
        Me.resultDGV.GridColor = System.Drawing.Color.IndianRed
        Me.resultDGV.Location = New System.Drawing.Point(12, 63)
        Me.resultDGV.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.resultDGV.Name = "resultDGV"
        Me.resultDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.resultDGV.Size = New System.Drawing.Size(1311, 637)
        Me.resultDGV.TabIndex = 2
        '
        'ADMNo
        '
        Me.ADMNo.HeaderText = "ADM No."
        Me.ADMNo.Name = "ADMNo"
        Me.ADMNo.ReadOnly = True
        Me.ADMNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'StudentName
        '
        Me.StudentName.HeaderText = "Name of Student"
        Me.StudentName.Name = "StudentName"
        Me.StudentName.ReadOnly = True
        Me.StudentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Gender
        '
        Me.Gender.HeaderText = "Gender"
        Me.Gender.Name = "Gender"
        Me.Gender.ReadOnly = True
        '
        'MarkAttained
        '
        Me.MarkAttained.HeaderText = "Marks"
        Me.MarkAttained.Name = "MarkAttained"
        Me.MarkAttained.ReadOnly = True
        Me.MarkAttained.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'GradeAttained
        '
        Me.GradeAttained.HeaderText = "Grade"
        Me.GradeAttained.Name = "GradeAttained"
        Me.GradeAttained.ReadOnly = True
        Me.GradeAttained.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Points
        '
        Me.Points.HeaderText = "Points"
        Me.Points.Name = "Points"
        Me.Points.ReadOnly = True
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(1217, 13)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 44)
        Me.btnPrint.TabIndex = 19
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(1107, 13)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 44)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmBestStudentSubject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1317, 713)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.resultDGV)
        Me.Controls.Add(Me.computeDVG)
        Me.MinimizeBox = False
        Me.Name = "frmBestStudentSubject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Best Student Per Subject"
        CType(Me.computeDVG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.resultDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents computeDVG As DataGridView
    Friend WithEvents resultDGV As DataGridView
    Friend WithEvents ADMNo As DataGridViewTextBoxColumn
    Friend WithEvents StudentName As DataGridViewTextBoxColumn
    Friend WithEvents Gender As DataGridViewTextBoxColumn
    Friend WithEvents MarkAttained As DataGridViewTextBoxColumn
    Friend WithEvents GradeAttained As DataGridViewTextBoxColumn
    Friend WithEvents Points As DataGridViewTextBoxColumn
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnCancel As Button
End Class
