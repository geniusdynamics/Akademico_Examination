<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubjectRankPrompt2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSubjectRankPrompt2))
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.radLast = New System.Windows.Forms.RadioButton()
        Me.radFirst = New System.Windows.Forms.RadioButton()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAnalyze = New System.Windows.Forms.Button()
        Me.radNone = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'txtNumber
        '
        Me.txtNumber.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumber.ForeColor = System.Drawing.Color.Brown
        Me.txtNumber.Location = New System.Drawing.Point(64, 64)
        Me.txtNumber.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(220, 22)
        Me.txtNumber.TabIndex = 18
        '
        'radLast
        '
        Me.radLast.AutoSize = True
        Me.radLast.Location = New System.Drawing.Point(211, 32)
        Me.radLast.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.radLast.Name = "radLast"
        Me.radLast.Size = New System.Drawing.Size(73, 21)
        Me.radLast.TabIndex = 16
        Me.radLast.TabStop = True
        Me.radLast.Text = "Bottom"
        Me.radLast.UseVisualStyleBackColor = True
        '
        'radFirst
        '
        Me.radFirst.AutoSize = True
        Me.radFirst.Location = New System.Drawing.Point(133, 32)
        Me.radFirst.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.radFirst.Name = "radFirst"
        Me.radFirst.Size = New System.Drawing.Size(54, 21)
        Me.radFirst.TabIndex = 17
        Me.radFirst.TabStop = True
        Me.radFirst.Text = "Top"
        Me.radFirst.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(90, 103)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 39)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAnalyze
        '
        Me.btnAnalyze.Image = CType(resources.GetObject("btnAnalyze.Image"), System.Drawing.Image)
        Me.btnAnalyze.Location = New System.Drawing.Point(193, 103)
        Me.btnAnalyze.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAnalyze.Name = "btnAnalyze"
        Me.btnAnalyze.Size = New System.Drawing.Size(92, 39)
        Me.btnAnalyze.TabIndex = 15
        Me.btnAnalyze.Text = "&Analyze"
        Me.btnAnalyze.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAnalyze.UseVisualStyleBackColor = True
        '
        'radNone
        '
        Me.radNone.AutoSize = True
        Me.radNone.Location = New System.Drawing.Point(64, 32)
        Me.radNone.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.radNone.Name = "radNone"
        Me.radNone.Size = New System.Drawing.Size(63, 21)
        Me.radNone.TabIndex = 19
        Me.radNone.TabStop = True
        Me.radNone.Text = "None"
        Me.radNone.UseVisualStyleBackColor = True
        '
        'frmSubjectRankPrompt2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 177)
        Me.Controls.Add(Me.radNone)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.radLast)
        Me.Controls.Add(Me.radFirst)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAnalyze)
        Me.MinimizeBox = False
        Me.Name = "frmSubjectRankPrompt2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subject Rank Prompt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNumber As TextBox
    Friend WithEvents radLast As RadioButton
    Friend WithEvents radFirst As RadioButton
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAnalyze As Button
    Friend WithEvents radNone As RadioButton
End Class
