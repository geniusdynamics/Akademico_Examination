<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubjectRank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSubjectRank))
        Me.radNone = New System.Windows.Forms.RadioButton()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.radLast = New System.Windows.Forms.RadioButton()
        Me.radFirst = New System.Windows.Forms.RadioButton()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAnalyze = New System.Windows.Forms.Button()
        Me.cboSubject = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'radNone
        '
        Me.radNone.AutoSize = True
        Me.radNone.Location = New System.Drawing.Point(119, 50)
        Me.radNone.Name = "radNone"
        Me.radNone.Size = New System.Drawing.Size(50, 17)
        Me.radNone.TabIndex = 13
        Me.radNone.TabStop = True
        Me.radNone.Text = "None"
        Me.radNone.UseVisualStyleBackColor = True
        '
        'txtNumber
        '
        Me.txtNumber.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumber.ForeColor = System.Drawing.Color.Brown
        Me.txtNumber.Location = New System.Drawing.Point(123, 76)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(182, 21)
        Me.txtNumber.TabIndex = 12
        '
        'radLast
        '
        Me.radLast.AutoSize = True
        Me.radLast.Location = New System.Drawing.Point(226, 50)
        Me.radLast.Name = "radLast"
        Me.radLast.Size = New System.Drawing.Size(59, 17)
        Me.radLast.TabIndex = 10
        Me.radLast.TabStop = True
        Me.radLast.Text = "Bottom"
        Me.radLast.UseVisualStyleBackColor = True
        '
        'radFirst
        '
        Me.radFirst.AutoSize = True
        Me.radFirst.Location = New System.Drawing.Point(176, 50)
        Me.radFirst.Name = "radFirst"
        Me.radFirst.Size = New System.Drawing.Size(43, 17)
        Me.radFirst.TabIndex = 11
        Me.radFirst.TabStop = True
        Me.radFirst.Text = "Top"
        Me.radFirst.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(138, 108)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 32)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAnalyze
        '
        Me.btnAnalyze.Image = CType(resources.GetObject("btnAnalyze.Image"), System.Drawing.Image)
        Me.btnAnalyze.Location = New System.Drawing.Point(226, 108)
        Me.btnAnalyze.Name = "btnAnalyze"
        Me.btnAnalyze.Size = New System.Drawing.Size(79, 32)
        Me.btnAnalyze.TabIndex = 9
        Me.btnAnalyze.Text = "&Analyze"
        Me.btnAnalyze.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAnalyze.UseVisualStyleBackColor = True
        '
        'cboSubject
        '
        Me.cboSubject.BackColor = System.Drawing.SystemColors.Info
        Me.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubject.ForeColor = System.Drawing.Color.IndianRed
        Me.cboSubject.FormattingEnabled = True
        Me.cboSubject.Location = New System.Drawing.Point(123, 18)
        Me.cboSubject.Name = "cboSubject"
        Me.cboSubject.Size = New System.Drawing.Size(182, 21)
        Me.cboSubject.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Subject of Analysis:"
        '
        'frmSubjectRank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 163)
        Me.Controls.Add(Me.radNone)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.radLast)
        Me.Controls.Add(Me.radFirst)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAnalyze)
        Me.Controls.Add(Me.cboSubject)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSubjectRank"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subject Ranking Prompt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents radNone As RadioButton
    Friend WithEvents txtNumber As TextBox
    Friend WithEvents radLast As RadioButton
    Friend WithEvents radFirst As RadioButton
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAnalyze As Button
    Friend WithEvents cboSubject As ComboBox
    Friend WithEvents Label1 As Label
End Class
