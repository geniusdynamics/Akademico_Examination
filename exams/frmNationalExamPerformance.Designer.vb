<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNationalExamPerformance
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
        Me.cboExamination = New System.Windows.Forms.ComboBox()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboExamination
        '
        Me.cboExamination.BackColor = System.Drawing.SystemColors.Info
        Me.cboExamination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExamination.ForeColor = System.Drawing.Color.IndianRed
        Me.cboExamination.FormattingEnabled = True
        Me.cboExamination.Location = New System.Drawing.Point(256, 22)
        Me.cboExamination.Name = "cboExamination"
        Me.cboExamination.Size = New System.Drawing.Size(181, 21)
        Me.cboExamination.TabIndex = 12
        '
        'cboYear
        '
        Me.cboYear.BackColor = System.Drawing.SystemColors.Info
        Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYear.ForeColor = System.Drawing.Color.IndianRed
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(74, 22)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(69, 21)
        Me.cboYear.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(180, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Examination:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Year:"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(249, 93)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(188, 29)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Overall Performance Index"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(34, 93)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(188, 29)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Subject Grade Attainance"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(249, 59)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(188, 29)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Subject Performance Index"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(34, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(188, 29)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Subject Ranking"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmNationalExamPerformance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 146)
        Me.Controls.Add(Me.cboExamination)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNationalExamPerformance"
        Me.Text = "National Exam Performance Analysis"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboExamination As ComboBox
    Friend WithEvents cboYear As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class
