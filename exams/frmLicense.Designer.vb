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
        Me.btnActivate = New DevExpress.XtraEditors.SimpleButton()
        Me.txtLicenseKey = New System.Windows.Forms.TextBox()
        Me.txtLicenseInfo = New System.Windows.Forms.TextBox()
        Me.txtSchoolName = New System.Windows.Forms.TextBox()
        Me.radActivate = New System.Windows.Forms.RadioButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.schoolNameLC = New DevExpress.XtraLayout.LayoutControlItem()
        Me.licenseCodeLC = New DevExpress.XtraLayout.LayoutControlItem()
        Me.licenseKeyLC = New DevExpress.XtraLayout.LayoutControlItem()
        Me.activateLC = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.sampleDb = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LabelInfo = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.schoolNameLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.licenseCodeLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.licenseKeyLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.activateLC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelInfo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnActivate)
        Me.LayoutControl1.Controls.Add(Me.txtLicenseKey)
        Me.LayoutControl1.Controls.Add(Me.txtLicenseInfo)
        Me.LayoutControl1.Controls.Add(Me.txtSchoolName)
        Me.LayoutControl1.Controls.Add(Me.radActivate)
        Me.LayoutControl1.Controls.Add(Me.sampleDb)
        Me.LayoutControl1.Controls.Add(Me.LabelInfo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(599, 211)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnActivate
        '
        Me.btnActivate.ImageOptions.Image = CType(resources.GetObject("btnActivate.ImageOptions.Image"), System.Drawing.Image)
        Me.btnActivate.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnActivate.Location = New System.Drawing.Point(398, 113)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(189, 55)
        Me.btnActivate.StyleController = Me.LayoutControl1
        Me.btnActivate.TabIndex = 10
        Me.btnActivate.Text = "Activate"
        '
        'txtLicenseKey
        '
        Me.txtLicenseKey.Location = New System.Drawing.Point(78, 89)
        Me.txtLicenseKey.Name = "txtLicenseKey"
        Me.txtLicenseKey.Size = New System.Drawing.Size(509, 20)
        Me.txtLicenseKey.TabIndex = 8
        '
        'txtLicenseInfo
        '
        Me.txtLicenseInfo.Location = New System.Drawing.Point(78, 65)
        Me.txtLicenseInfo.Name = "txtLicenseInfo"
        Me.txtLicenseInfo.Size = New System.Drawing.Size(509, 20)
        Me.txtLicenseInfo.TabIndex = 7
        '
        'txtSchoolName
        '
        Me.txtSchoolName.Location = New System.Drawing.Point(78, 41)
        Me.txtSchoolName.Name = "txtSchoolName"
        Me.txtSchoolName.Size = New System.Drawing.Size(509, 20)
        Me.txtSchoolName.TabIndex = 6
        '
        'radActivate
        '
        Me.radActivate.Location = New System.Drawing.Point(12, 12)
        Me.radActivate.Name = "radActivate"
        Me.radActivate.Size = New System.Drawing.Size(575, 25)
        Me.radActivate.TabIndex = 4
        Me.radActivate.TabStop = True
        Me.radActivate.Text = "Activate Akademico"
        Me.radActivate.UseVisualStyleBackColor = True
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.schoolNameLC, Me.licenseCodeLC, Me.licenseKeyLC, Me.activateLC, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.EmptySpaceItem4, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(599, 211)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.radActivate
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(579, 29)
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
        Me.schoolNameLC.TextSize = New System.Drawing.Size(63, 13)
        '
        'licenseCodeLC
        '
        Me.licenseCodeLC.Control = Me.txtLicenseInfo
        Me.licenseCodeLC.Location = New System.Drawing.Point(0, 53)
        Me.licenseCodeLC.Name = "licenseCodeLC"
        Me.licenseCodeLC.Size = New System.Drawing.Size(579, 24)
        Me.licenseCodeLC.Text = "License Code"
        Me.licenseCodeLC.TextSize = New System.Drawing.Size(63, 13)
        '
        'licenseKeyLC
        '
        Me.licenseKeyLC.Control = Me.txtLicenseKey
        Me.licenseKeyLC.Location = New System.Drawing.Point(0, 77)
        Me.licenseKeyLC.Name = "licenseKeyLC"
        Me.licenseKeyLC.Size = New System.Drawing.Size(579, 24)
        Me.licenseKeyLC.Text = "License Key"
        Me.licenseKeyLC.TextSize = New System.Drawing.Size(63, 13)
        '
        'activateLC
        '
        Me.activateLC.Control = Me.btnActivate
        Me.activateLC.Location = New System.Drawing.Point(386, 101)
        Me.activateLC.Name = "activateLC"
        Me.activateLC.Size = New System.Drawing.Size(193, 90)
        Me.activateLC.TextSize = New System.Drawing.Size(0, 0)
        Me.activateLC.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(282, 167)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(86, 24)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.RightToLeft = True
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(368, 101)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(18, 90)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'sampleDb
        '
        Me.sampleDb.Location = New System.Drawing.Point(12, 131)
        Me.sampleDb.Name = "sampleDb"
        Me.sampleDb.Size = New System.Drawing.Size(154, 44)
        Me.sampleDb.StyleController = Me.LayoutControl1
        Me.sampleDb.TabIndex = 13
        Me.sampleDb.Text = "Load DemoDatabase"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.sampleDb
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 119)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(112, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(158, 48)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 101)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(158, 18)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(158, 101)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(210, 66)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LabelInfo
        '
        Me.LabelInfo.Enabled = False
        Me.LabelInfo.Location = New System.Drawing.Point(12, 179)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(278, 20)
        Me.LabelInfo.StyleController = Me.LayoutControl1
        Me.LabelInfo.TabIndex = 14
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.LabelInfo
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 167)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(282, 24)
        Me.LayoutControlItem3.Text = "Expiry"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
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
        CType(Me.activateLC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelInfo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnActivate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtLicenseKey As TextBox
    Friend WithEvents txtLicenseInfo As TextBox
    Friend WithEvents txtSchoolName As TextBox
    Friend WithEvents radActivate As RadioButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents schoolNameLC As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents licenseCodeLC As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents licenseKeyLC As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents activateLC As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents sampleDb As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LabelInfo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
End Class
