<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFilter
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.radNone = New System.Windows.Forms.RadioButton()
        Me.radBottom = New System.Windows.Forms.RadioButton()
        Me.radTop = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(151, 62)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "&Go"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Filter Top / Bottom Students By Number"
        '
        'txtNumber
        '
        Me.txtNumber.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumber.ForeColor = System.Drawing.Color.IndianRed
        Me.txtNumber.Location = New System.Drawing.Point(40, 65)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(101, 21)
        Me.txtNumber.TabIndex = 7
        '
        'radNone
        '
        Me.radNone.AutoSize = True
        Me.radNone.Location = New System.Drawing.Point(40, 39)
        Me.radNone.Name = "radNone"
        Me.radNone.Size = New System.Drawing.Size(50, 17)
        Me.radNone.TabIndex = 4
        Me.radNone.TabStop = True
        Me.radNone.Text = "None"
        Me.radNone.UseVisualStyleBackColor = True
        '
        'radBottom
        '
        Me.radBottom.AutoSize = True
        Me.radBottom.Location = New System.Drawing.Point(165, 39)
        Me.radBottom.Name = "radBottom"
        Me.radBottom.Size = New System.Drawing.Size(59, 17)
        Me.radBottom.TabIndex = 5
        Me.radBottom.TabStop = True
        Me.radBottom.Text = "Bottom"
        Me.radBottom.UseVisualStyleBackColor = True
        '
        'radTop
        '
        Me.radTop.AutoSize = True
        Me.radTop.Location = New System.Drawing.Point(97, 39)
        Me.radTop.Name = "radTop"
        Me.radTop.Size = New System.Drawing.Size(43, 17)
        Me.radTop.TabIndex = 6
        Me.radTop.TabStop = True
        Me.radTop.Text = "Top"
        Me.radTop.UseVisualStyleBackColor = True
        '
        'frmFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(272, 111)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.radNone)
        Me.Controls.Add(Me.radBottom)
        Me.Controls.Add(Me.radTop)
        Me.Name = "frmFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filter Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNumber As TextBox
    Friend WithEvents radNone As RadioButton
    Friend WithEvents radBottom As RadioButton
    Friend WithEvents radTop As RadioButton
End Class
