<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportConfiguration
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
        Me.chkCTN = New System.Windows.Forms.CheckBox()
        Me.chkHouse = New System.Windows.Forms.CheckBox()
        Me.chkHTN = New System.Windows.Forms.CheckBox()
        Me.chkClubSociety = New System.Windows.Forms.CheckBox()
        Me.chkHTS = New System.Windows.Forms.CheckBox()
        Me.chkHTC = New System.Windows.Forms.CheckBox()
        Me.chkCTS = New System.Windows.Forms.CheckBox()
        Me.chkCTC = New System.Windows.Forms.CheckBox()
        Me.chkLogo = New System.Windows.Forms.CheckBox()
        Me.chkPhoto = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(148, 266)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "&Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkCTN
        '
        Me.chkCTN.AutoSize = True
        Me.chkCTN.Location = New System.Drawing.Point(34, 243)
        Me.chkCTN.Name = "chkCTN"
        Me.chkCTN.Size = New System.Drawing.Size(130, 17)
        Me.chkCTN.TabIndex = 14
        Me.chkCTN.Text = "Class Teacher's Name"
        Me.chkCTN.UseVisualStyleBackColor = True
        '
        'chkHouse
        '
        Me.chkHouse.AutoSize = True
        Me.chkHouse.Location = New System.Drawing.Point(35, 193)
        Me.chkHouse.Name = "chkHouse"
        Me.chkHouse.Size = New System.Drawing.Size(152, 17)
        Me.chkHouse.TabIndex = 15
        Me.chkHouse.Text = "House Masters' Comments"
        Me.chkHouse.UseVisualStyleBackColor = True
        '
        'chkHTN
        '
        Me.chkHTN.AutoSize = True
        Me.chkHTN.Location = New System.Drawing.Point(34, 218)
        Me.chkHTN.Name = "chkHTN"
        Me.chkHTN.Size = New System.Drawing.Size(130, 17)
        Me.chkHTN.TabIndex = 12
        Me.chkHTN.Text = "Head Teacher's Name"
        Me.chkHTN.UseVisualStyleBackColor = True
        '
        'chkClubSociety
        '
        Me.chkClubSociety.AutoSize = True
        Me.chkClubSociety.Location = New System.Drawing.Point(35, 168)
        Me.chkClubSociety.Name = "chkClubSociety"
        Me.chkClubSociety.Size = New System.Drawing.Size(172, 17)
        Me.chkClubSociety.TabIndex = 13
        Me.chkClubSociety.Text = "Clubs And Societies Comments"
        Me.chkClubSociety.UseVisualStyleBackColor = True
        '
        'chkHTS
        '
        Me.chkHTS.AutoSize = True
        Me.chkHTS.Location = New System.Drawing.Point(34, 93)
        Me.chkHTS.Name = "chkHTS"
        Me.chkHTS.Size = New System.Drawing.Size(149, 17)
        Me.chkHTS.TabIndex = 10
        Me.chkHTS.Text = "Head Teachers' Signature"
        Me.chkHTS.UseVisualStyleBackColor = True
        '
        'chkHTC
        '
        Me.chkHTC.AutoSize = True
        Me.chkHTC.Location = New System.Drawing.Point(34, 143)
        Me.chkHTC.Name = "chkHTC"
        Me.chkHTC.Size = New System.Drawing.Size(153, 17)
        Me.chkHTC.TabIndex = 11
        Me.chkHTC.Text = "Head Teachers' Comments"
        Me.chkHTC.UseVisualStyleBackColor = True
        '
        'chkCTS
        '
        Me.chkCTS.AutoSize = True
        Me.chkCTS.Location = New System.Drawing.Point(34, 68)
        Me.chkCTS.Name = "chkCTS"
        Me.chkCTS.Size = New System.Drawing.Size(149, 17)
        Me.chkCTS.TabIndex = 7
        Me.chkCTS.Text = "Class Teachers' Signature"
        Me.chkCTS.UseVisualStyleBackColor = True
        '
        'chkCTC
        '
        Me.chkCTC.AutoSize = True
        Me.chkCTC.Location = New System.Drawing.Point(34, 118)
        Me.chkCTC.Name = "chkCTC"
        Me.chkCTC.Size = New System.Drawing.Size(153, 17)
        Me.chkCTC.TabIndex = 8
        Me.chkCTC.Text = "Class Teachers' Comments"
        Me.chkCTC.UseVisualStyleBackColor = True
        '
        'chkLogo
        '
        Me.chkLogo.AutoSize = True
        Me.chkLogo.Location = New System.Drawing.Point(34, 43)
        Me.chkLogo.Name = "chkLogo"
        Me.chkLogo.Size = New System.Drawing.Size(83, 17)
        Me.chkLogo.TabIndex = 9
        Me.chkLogo.Text = "School Logo"
        Me.chkLogo.UseVisualStyleBackColor = True
        '
        'chkPhoto
        '
        Me.chkPhoto.AutoSize = True
        Me.chkPhoto.Location = New System.Drawing.Point(34, 18)
        Me.chkPhoto.Name = "chkPhoto"
        Me.chkPhoto.Size = New System.Drawing.Size(95, 17)
        Me.chkPhoto.TabIndex = 6
        Me.chkPhoto.Text = "Student Photo"
        Me.chkPhoto.UseVisualStyleBackColor = True
        '
        'frmReportConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(252, 323)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chkCTN)
        Me.Controls.Add(Me.chkHouse)
        Me.Controls.Add(Me.chkHTN)
        Me.Controls.Add(Me.chkClubSociety)
        Me.Controls.Add(Me.chkHTS)
        Me.Controls.Add(Me.chkHTC)
        Me.Controls.Add(Me.chkCTS)
        Me.Controls.Add(Me.chkCTC)
        Me.Controls.Add(Me.chkLogo)
        Me.Controls.Add(Me.chkPhoto)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportConfiguration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Form Configuration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents chkCTN As CheckBox
    Friend WithEvents chkHouse As CheckBox
    Friend WithEvents chkHTN As CheckBox
    Friend WithEvents chkClubSociety As CheckBox
    Friend WithEvents chkHTS As CheckBox
    Friend WithEvents chkHTC As CheckBox
    Friend WithEvents chkCTS As CheckBox
    Friend WithEvents chkCTC As CheckBox
    Friend WithEvents chkLogo As CheckBox
    Friend WithEvents chkPhoto As CheckBox
End Class
