<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDates))
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkTable = New System.Windows.Forms.CheckBox()
        Me.chkBarGraph = New System.Windows.Forms.CheckBox()
        Me.chkFee = New System.Windows.Forms.CheckBox()
        Me.chkAttendance = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(102, 168)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(161, 17)
        Me.CheckBox1.TabIndex = 22
        Me.CheckBox1.Text = "Watermark the Report Form"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkTable
        '
        Me.chkTable.AutoSize = True
        Me.chkTable.Checked = True
        Me.chkTable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTable.Location = New System.Drawing.Point(102, 144)
        Me.chkTable.Name = "chkTable"
        Me.chkTable.Size = New System.Drawing.Size(174, 17)
        Me.chkTable.TabIndex = 21
        Me.chkTable.Text = "Show Detailed Subject Ranking"
        Me.chkTable.UseVisualStyleBackColor = True
        '
        'chkBarGraph
        '
        Me.chkBarGraph.AutoSize = True
        Me.chkBarGraph.Checked = True
        Me.chkBarGraph.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBarGraph.Location = New System.Drawing.Point(102, 121)
        Me.chkBarGraph.Name = "chkBarGraph"
        Me.chkBarGraph.Size = New System.Drawing.Size(103, 17)
        Me.chkBarGraph.TabIndex = 20
        Me.chkBarGraph.Text = "Show Bar Graph"
        Me.chkBarGraph.UseVisualStyleBackColor = True
        '
        'chkFee
        '
        Me.chkFee.AutoSize = True
        Me.chkFee.Checked = True
        Me.chkFee.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFee.Location = New System.Drawing.Point(102, 98)
        Me.chkFee.Name = "chkFee"
        Me.chkFee.Size = New System.Drawing.Size(117, 17)
        Me.chkFee.TabIndex = 18
        Me.chkFee.Text = "Show Fees Arrears"
        Me.chkFee.UseVisualStyleBackColor = True
        '
        'chkAttendance
        '
        Me.chkAttendance.AutoSize = True
        Me.chkAttendance.Location = New System.Drawing.Point(102, 75)
        Me.chkAttendance.Name = "chkAttendance"
        Me.chkAttendance.Size = New System.Drawing.Size(111, 17)
        Me.chkAttendance.TabIndex = 19
        Me.chkAttendance.Text = "Show Attendance"
        Me.chkAttendance.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(103, 198)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 27)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.Location = New System.Drawing.Point(203, 198)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(71, 27)
        Me.btnGo.TabIndex = 17
        Me.btnGo.Text = "&Go"
        Me.btnGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(102, 49)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(172, 21)
        Me.DateTimePicker2.TabIndex = 14
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(102, 18)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(172, 21)
        Me.DateTimePicker1.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Opening Date:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Closing Date:"
        '
        'frmDates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 266)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.chkTable)
        Me.Controls.Add(Me.chkBarGraph)
        Me.Controls.Add(Me.chkFee)
        Me.Controls.Add(Me.chkAttendance)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opening And Closing Dates Required"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents chkTable As CheckBox
    Friend WithEvents chkBarGraph As CheckBox
    Friend WithEvents chkFee As CheckBox
    Friend WithEvents chkAttendance As CheckBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnGo As Button
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
