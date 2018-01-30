<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLicense
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLicense))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.btnGenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.btnActivate = New DevExpress.XtraEditors.SimpleButton()
        Me.cboLicensePeriod = New System.Windows.Forms.ComboBox()
        Me.txtLicenseKey = New System.Windows.Forms.TextBox()
        Me.txtLicenseInfo = New System.Windows.Forms.TextBox()
        Me.txtSchoolName = New System.Windows.Forms.TextBox()
        Me.radGenerateCode = New System.Windows.Forms.RadioButton()
        Me.radActivate = New System.Windows.Forms.RadioButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.schoolNameLC = New DevExpress.XtraLayout.LayoutControlItem()
        Me.licenseCodeLC = New DevExpress.XtraLayout.LayoutControlItem()
        Me.licenseKeyLC = New DevExpress.XtraLayout.LayoutControlItem()
        Me.licensePeriodLC = New DevExpress.XtraLayout.LayoutControlItem()
        Me.activateLC = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.generateCodeLC = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.schoolNameLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.licenseCodeLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.licenseKeyLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.licensePeriodLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.activateLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.generateCodeLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.lblInfo)
        Me.LayoutControl1.Controls.Add(Me.btnGenerate)
        Me.LayoutControl1.Controls.Add(Me.btnActivate)
        Me.LayoutControl1.Controls.Add(Me.cboLicensePeriod)
        Me.LayoutControl1.Controls.Add(Me.txtLicenseKey)
        Me.LayoutControl1.Controls.Add(Me.txtLicenseInfo)
        Me.LayoutControl1.Controls.Add(Me.txtSchoolName)
        Me.LayoutControl1.Controls.Add(Me.radGenerateCode)
        Me.LayoutControl1.Controls.Add(Me.radActivate)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(599, 211)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'lblInfo
        '
        Me.lblInfo.ForeColor = System.Drawing.Color.Red
        Me.lblInfo.Location = New System.Drawing.Point(12, 138)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(316, 28)
        Me.lblInfo.TabIndex = 12
        '
        'btnGenerate
        '
        Me.btnGenerate.ImageOptions.Image = CType(resources.GetObject("btnGenerate.ImageOptions.Image"), System.Drawing.Image)
        Me.btnGenerate.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnGenerate.Location = New System.Drawing.Point(332, 138)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(160, 55)
        Me.btnGenerate.StyleController = Me.LayoutControl1
        Me.btnGenerate.TabIndex = 11
        Me.btnGenerate.Text = "Generate Code"
        '
        'btnActivate
        '
        Me.btnActivate.ImageOptions.Image = CType(resources.GetObject("btnActivate.ImageOptions.Image"), System.Drawing.Image)
        Me.btnActivate.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnActivate.Location = New System.Drawing.Point(496, 138)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(91, 55)
        Me.btnActivate.StyleController = Me.LayoutControl1
        Me.btnActivate.TabIndex = 10
        Me.btnActivate.Text = "Activate"
        '
        'cboLicensePeriod
        '
        Me.cboLicensePeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLicensePeriod.FormattingEnabled = True
        Me.cboLicensePeriod.Items.AddRange(New Object() {"1 Month", "2 Months", "3 Months", "4 Months", "5 Months", "6 Months", "7 Months", "8 Months", "9 Months ", "10 Months", "11 Months", "12 Months"})
        Me.cboLicensePeriod.Location = New System.Drawing.Point(83, 113)
        Me.cboLicensePeriod.Name = "cboLicensePeriod"
        Me.cboLicensePeriod.Size = New System.Drawing.Size(504, 21)
        Me.cboLicensePeriod.TabIndex = 9
        '
        'txtLicenseKey
        '
        Me.txtLicenseKey.Location = New System.Drawing.Point(83, 89)
        Me.txtLicenseKey.Name = "txtLicenseKey"
        Me.txtLicenseKey.Size = New System.Drawing.Size(504, 20)
        Me.txtLicenseKey.TabIndex = 8
        '
        'txtLicenseInfo
        '
        Me.txtLicenseInfo.Location = New System.Drawing.Point(83, 65)
        Me.txtLicenseInfo.Name = "txtLicenseInfo"
        Me.txtLicenseInfo.Size = New System.Drawing.Size(504, 20)
        Me.txtLicenseInfo.TabIndex = 7
        '
        'txtSchoolName
        '
        Me.txtSchoolName.Location = New System.Drawing.Point(83, 41)
        Me.txtSchoolName.Name = "txtSchoolName"
        Me.txtSchoolName.Size = New System.Drawing.Size(504, 20)
        Me.txtSchoolName.TabIndex = 6
        '
        'radGenerateCode
        '
        Me.radGenerateCode.Location = New System.Drawing.Point(12, 12)
        Me.radGenerateCode.Name = "radGenerateCode"
        Me.radGenerateCode.Size = New System.Drawing.Size(285, 25)
        Me.radGenerateCode.TabIndex = 5
        Me.radGenerateCode.TabStop = True
        Me.radGenerateCode.Text = "Generate License Code"
        Me.radGenerateCode.UseVisualStyleBackColor = True
        '
        'radActivate
        '
        Me.radActivate.Location = New System.Drawing.Point(301, 12)
        Me.radActivate.Name = "radActivate"
        Me.radActivate.Size = New System.Drawing.Size(286, 25)
        Me.radActivate.TabIndex = 4
        Me.radActivate.TabStop = True
        Me.radActivate.Text = "Activate Akademico"
        Me.radActivate.UseVisualStyleBackColor = True
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.schoolNameLC, Me.licenseCodeLC, Me.licenseKeyLC, Me.licensePeriodLC, Me.activateLC, Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.generateCodeLC, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(599, 211)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.radActivate
        Me.LayoutControlItem1.Location = New System.Drawing.Point(289, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(290, 29)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'schoolNameLC
        '
        Me.schoolNameLC.Control = Me.txtSchoolName
        Me.schoolNameLC.Location = New System.Drawing.Point(0, 29)
        Me.schoolNameLC.Name = "schoolNameLC"
        Me.schoolNameLC.Size = New System.Drawing.Size(579, 24)
        Me.schoolNameLC.Text = "School Code"
        Me.schoolNameLC.TextSize = New System.Drawing.Size(68, 13)
        '
        'licenseCodeLC
        '
        Me.licenseCodeLC.Control = Me.txtLicenseInfo
        Me.licenseCodeLC.Location = New System.Drawing.Point(0, 53)
        Me.licenseCodeLC.Name = "licenseCodeLC"
        Me.licenseCodeLC.Size = New System.Drawing.Size(579, 24)
        Me.licenseCodeLC.Text = "License Code"
        Me.licenseCodeLC.TextSize = New System.Drawing.Size(68, 13)
        '
        'licenseKeyLC
        '
        Me.licenseKeyLC.Control = Me.txtLicenseKey
        Me.licenseKeyLC.Location = New System.Drawing.Point(0, 77)
        Me.licenseKeyLC.Name = "licenseKeyLC"
        Me.licenseKeyLC.Size = New System.Drawing.Size(579, 24)
        Me.licenseKeyLC.Text = "License Key"
        Me.licenseKeyLC.TextSize = New System.Drawing.Size(68, 13)
        '
        'licensePeriodLC
        '
        Me.licensePeriodLC.Control = Me.cboLicensePeriod
        Me.licensePeriodLC.Location = New System.Drawing.Point(0, 101)
        Me.licensePeriodLC.Name = "licensePeriodLC"
        Me.licensePeriodLC.Size = New System.Drawing.Size(579, 25)
        Me.licensePeriodLC.Text = "License Period"
        Me.licensePeriodLC.TextSize = New System.Drawing.Size(68, 13)
        '
        'activateLC
        '
        Me.activateLC.Control = Me.btnActivate
        Me.activateLC.Location = New System.Drawing.Point(484, 126)
        Me.activateLC.Name = "activateLC"
        Me.activateLC.Size = New System.Drawing.Size(95, 65)
        Me.activateLC.TextSize = New System.Drawing.Size(0, 0)
        Me.activateLC.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.radGenerateCode
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(289, 29)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 158)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(320, 33)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'generateCodeLC
        '
        Me.generateCodeLC.Control = Me.btnGenerate
        Me.generateCodeLC.Location = New System.Drawing.Point(320, 126)
        Me.generateCodeLC.Name = "generateCodeLC"
        Me.generateCodeLC.Size = New System.Drawing.Size(164, 65)
        Me.generateCodeLC.TextSize = New System.Drawing.Size(0, 0)
        Me.generateCodeLC.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.lblInfo
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 126)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(320, 32)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.RightToLeft = True
        '
        'frmLicense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 211)
        Me.Controls.Add(Me.LayoutControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLicense"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "License"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.schoolNameLC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.licenseCodeLC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.licenseKeyLC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.licensePeriodLC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.activateLC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.generateCodeLC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnGenerate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnActivate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboLicensePeriod As ComboBox
    Friend WithEvents txtLicenseKey As TextBox
    Friend WithEvents txtLicenseInfo As TextBox
    Friend WithEvents txtSchoolName As TextBox
    Friend WithEvents radGenerateCode As RadioButton
    Friend WithEvents radActivate As RadioButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents schoolNameLC As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents licenseCodeLC As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents licenseKeyLC As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents licensePeriodLC As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents activateLC As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents generateCodeLC As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblInfo As Label
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
