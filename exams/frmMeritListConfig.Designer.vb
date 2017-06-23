<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMeritListConfig
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.chkKCPE = New System.Windows.Forms.CheckBox()
        Me.chkIndex = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkTM = New System.Windows.Forms.CheckBox()
        Me.chkOP = New System.Windows.Forms.CheckBox()
        Me.chkStr = New System.Windows.Forms.CheckBox()
        Me.chkMM = New System.Windows.Forms.CheckBox()
        Me.chkVAP = New System.Windows.Forms.CheckBox()
        Me.chkTP = New System.Windows.Forms.CheckBox()
        Me.chkSP = New System.Windows.Forms.CheckBox()
        Me.chkMG = New System.Windows.Forms.CheckBox()
        Me.chkMP = New System.Windows.Forms.CheckBox()
        Me.chkSE = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Class:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(90, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(315, 21)
        Me.ComboBox1.TabIndex = 21
        '
        'chkKCPE
        '
        Me.chkKCPE.AutoSize = True
        Me.chkKCPE.Location = New System.Drawing.Point(207, 146)
        Me.chkKCPE.Name = "chkKCPE"
        Me.chkKCPE.Size = New System.Drawing.Size(82, 17)
        Me.chkKCPE.TabIndex = 19
        Me.chkKCPE.Text = "KCPE Marks"
        Me.chkKCPE.UseVisualStyleBackColor = True
        '
        'chkIndex
        '
        Me.chkIndex.AutoSize = True
        Me.chkIndex.Location = New System.Drawing.Point(207, 172)
        Me.chkIndex.Name = "chkIndex"
        Me.chkIndex.Size = New System.Drawing.Size(94, 17)
        Me.chkIndex.TabIndex = 20
        Me.chkIndex.Text = "Index Number"
        Me.chkIndex.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(330, 200)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 31)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "&Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkTM
        '
        Me.chkTM.AutoSize = True
        Me.chkTM.Location = New System.Drawing.Point(38, 174)
        Me.chkTM.Name = "chkTM"
        Me.chkTM.Size = New System.Drawing.Size(110, 17)
        Me.chkTM.TabIndex = 8
        Me.chkTM.Text = "Total Marks (T.M)"
        Me.chkTM.UseVisualStyleBackColor = True
        '
        'chkOP
        '
        Me.chkOP.AutoSize = True
        Me.chkOP.Location = New System.Drawing.Point(207, 96)
        Me.chkOP.Name = "chkOP"
        Me.chkOP.Size = New System.Drawing.Size(129, 17)
        Me.chkOP.TabIndex = 9
        Me.chkOP.Text = "Overall Position (O.P)"
        Me.chkOP.UseVisualStyleBackColor = True
        '
        'chkStr
        '
        Me.chkStr.AutoSize = True
        Me.chkStr.Location = New System.Drawing.Point(207, 44)
        Me.chkStr.Name = "chkStr"
        Me.chkStr.Size = New System.Drawing.Size(90, 17)
        Me.chkStr.TabIndex = 10
        Me.chkStr.Text = "Stream (STR)"
        Me.chkStr.UseVisualStyleBackColor = True
        '
        'chkMM
        '
        Me.chkMM.AutoSize = True
        Me.chkMM.Location = New System.Drawing.Point(38, 122)
        Me.chkMM.Name = "chkMM"
        Me.chkMM.Size = New System.Drawing.Size(114, 17)
        Me.chkMM.TabIndex = 11
        Me.chkMM.Text = "Mean Marks (M.M)"
        Me.chkMM.UseVisualStyleBackColor = True
        '
        'chkVAP
        '
        Me.chkVAP.AutoSize = True
        Me.chkVAP.Location = New System.Drawing.Point(207, 122)
        Me.chkVAP.Name = "chkVAP"
        Me.chkVAP.Size = New System.Drawing.Size(169, 17)
        Me.chkVAP.TabIndex = 12
        Me.chkVAP.Text = "Value Added Progress (V.A.P)"
        Me.chkVAP.UseVisualStyleBackColor = True
        '
        'chkTP
        '
        Me.chkTP.AutoSize = True
        Me.chkTP.Location = New System.Drawing.Point(38, 70)
        Me.chkTP.Name = "chkTP"
        Me.chkTP.Size = New System.Drawing.Size(109, 17)
        Me.chkTP.TabIndex = 13
        Me.chkTP.Text = "Total Points (T.P)"
        Me.chkTP.UseVisualStyleBackColor = True
        '
        'chkSP
        '
        Me.chkSP.AutoSize = True
        Me.chkSP.Location = New System.Drawing.Point(207, 70)
        Me.chkSP.Name = "chkSP"
        Me.chkSP.Size = New System.Drawing.Size(127, 17)
        Me.chkSP.TabIndex = 14
        Me.chkSP.Text = "Stream Position (S.P)"
        Me.chkSP.UseVisualStyleBackColor = True
        '
        'chkMG
        '
        Me.chkMG.AutoSize = True
        Me.chkMG.Location = New System.Drawing.Point(38, 148)
        Me.chkMG.Name = "chkMG"
        Me.chkMG.Size = New System.Drawing.Size(114, 17)
        Me.chkMG.TabIndex = 15
        Me.chkMG.Text = "Mean Grade (M.G)"
        Me.chkMG.UseVisualStyleBackColor = True
        '
        'chkMP
        '
        Me.chkMP.AutoSize = True
        Me.chkMP.Location = New System.Drawing.Point(38, 96)
        Me.chkMP.Name = "chkMP"
        Me.chkMP.Size = New System.Drawing.Size(113, 17)
        Me.chkMP.TabIndex = 16
        Me.chkMP.Text = "Mean Points (M.P)"
        Me.chkMP.UseVisualStyleBackColor = True
        '
        'chkSE
        '
        Me.chkSE.AutoSize = True
        Me.chkSE.Location = New System.Drawing.Point(38, 44)
        Me.chkSE.Name = "chkSE"
        Me.chkSE.Size = New System.Drawing.Size(125, 17)
        Me.chkSE.TabIndex = 17
        Me.chkSE.Text = "Subject Entries (S.E)"
        Me.chkSE.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 7
        '
        'frmMeritListConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 261)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.chkKCPE)
        Me.Controls.Add(Me.chkIndex)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chkTM)
        Me.Controls.Add(Me.chkOP)
        Me.Controls.Add(Me.chkStr)
        Me.Controls.Add(Me.chkMM)
        Me.Controls.Add(Me.chkVAP)
        Me.Controls.Add(Me.chkTP)
        Me.Controls.Add(Me.chkSP)
        Me.Controls.Add(Me.chkMG)
        Me.Controls.Add(Me.chkMP)
        Me.Controls.Add(Me.chkSE)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMeritListConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Merit List Configurations"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents chkKCPE As CheckBox
    Friend WithEvents chkIndex As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents chkTM As CheckBox
    Friend WithEvents chkOP As CheckBox
    Friend WithEvents chkStr As CheckBox
    Friend WithEvents chkMM As CheckBox
    Friend WithEvents chkVAP As CheckBox
    Friend WithEvents chkTP As CheckBox
    Friend WithEvents chkSP As CheckBox
    Friend WithEvents chkMG As CheckBox
    Friend WithEvents chkMP As CheckBox
    Friend WithEvents chkSE As CheckBox
    Friend WithEvents Label1 As Label
End Class
