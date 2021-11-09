<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBConnection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDBConnection))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtDbHost = New System.Windows.Forms.TextBox()
        Me.txtDBName = New System.Windows.Forms.TextBox()
        Me.defaultConnString = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDbPort = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtAPIUserName = New System.Windows.Forms.TextBox()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtAPI = New System.Windows.Forms.TextBox()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtSender = New System.Windows.Forms.TextBox()
        Me.Sender = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtDbPort.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sender, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtSender)
        Me.LayoutControl1.Controls.Add(Me.txtAPI)
        Me.LayoutControl1.Controls.Add(Me.txtAPIUserName)
        Me.LayoutControl1.Controls.Add(Me.btnSave)
        Me.LayoutControl1.Controls.Add(Me.txtPassword)
        Me.LayoutControl1.Controls.Add(Me.txtUserName)
        Me.LayoutControl1.Controls.Add(Me.txtDbHost)
        Me.LayoutControl1.Controls.Add(Me.txtDBName)
        Me.LayoutControl1.Controls.Add(Me.defaultConnString)
        Me.LayoutControl1.Controls.Add(Me.txtDbPort)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(588, 320)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnSave
        '
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(422, 261)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(129, 44)
        Me.btnSave.StyleController = Me.LayoutControl1
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(112, 109)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(439, 25)
        Me.txtPassword.TabIndex = 7
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(112, 78)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(439, 25)
        Me.txtUserName.TabIndex = 6
        '
        'txtDbHost
        '
        Me.txtDbHost.Location = New System.Drawing.Point(112, 47)
        Me.txtDbHost.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDbHost.Name = "txtDbHost"
        Me.txtDbHost.Size = New System.Drawing.Size(439, 25)
        Me.txtDbHost.TabIndex = 5
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(112, 16)
        Me.txtDBName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(439, 25)
        Me.txtDBName.TabIndex = 4
        '
        'defaultConnString
        '
        Me.defaultConnString.Location = New System.Drawing.Point(16, 261)
        Me.defaultConnString.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.defaultConnString.Name = "defaultConnString"
        Me.defaultConnString.Size = New System.Drawing.Size(129, 44)
        Me.defaultConnString.StyleController = Me.LayoutControl1
        Me.defaultConnString.TabIndex = 10
        Me.defaultConnString.Text = "Load Defaults"
        '
        'txtDbPort
        '
        Me.txtDbPort.Location = New System.Drawing.Point(112, 140)
        Me.txtDbPort.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDbPort.Name = "txtDbPort"
        Me.txtDbPort.Size = New System.Drawing.Size(439, 22)
        Me.txtDbPort.StyleController = Me.LayoutControl1
        Me.txtDbPort.TabIndex = 11
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.EmptySpaceItem4, Me.LayoutControlItem7, Me.EmptySpaceItem1, Me.LayoutControlItem6, Me.EmptySpaceItem5, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.Sender})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(567, 331)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtDBName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(541, 31)
        Me.LayoutControlItem1.Text = "DB Name"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(93, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtDbHost
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 31)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(541, 31)
        Me.LayoutControlItem2.Text = "Db Host"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(93, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtUserName
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 62)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(541, 31)
        Me.LayoutControlItem3.Text = "User Name"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(93, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtPassword
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 93)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(541, 31)
        Me.LayoutControlItem4.Text = "Password"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(93, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnSave
        Me.LayoutControlItem5.Location = New System.Drawing.Point(406, 245)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(135, 50)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(271, 245)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(135, 50)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtDbPort
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 124)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(541, 28)
        Me.LayoutControlItem7.Text = "Server Port"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(93, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(135, 245)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(136, 50)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.defaultConnString
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 245)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(79, 26)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(135, 50)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 295)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(541, 10)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.RightToLeft = True
        '
        'txtAPIUserName
        '
        Me.txtAPIUserName.Location = New System.Drawing.Point(112, 199)
        Me.txtAPIUserName.Name = "txtAPIUserName"
        Me.txtAPIUserName.Size = New System.Drawing.Size(439, 25)
        Me.txtAPIUserName.TabIndex = 12
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtAPIUserName
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 183)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(541, 31)
        Me.LayoutControlItem8.Text = "SMS User Name"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(93, 16)
        '
        'txtAPI
        '
        Me.txtAPI.Location = New System.Drawing.Point(112, 230)
        Me.txtAPI.Name = "txtAPI"
        Me.txtAPI.Size = New System.Drawing.Size(439, 25)
        Me.txtAPI.TabIndex = 13
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtAPI
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 214)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(541, 31)
        Me.LayoutControlItem9.Text = "SMS API"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(93, 16)
        '
        'txtSender
        '
        Me.txtSender.Location = New System.Drawing.Point(112, 168)
        Me.txtSender.Name = "txtSender"
        Me.txtSender.Size = New System.Drawing.Size(439, 25)
        Me.txtSender.TabIndex = 14
        '
        'Sender
        '
        Me.Sender.Control = Me.txtSender
        Me.Sender.Location = New System.Drawing.Point(0, 152)
        Me.Sender.Name = "Sender"
        Me.Sender.Size = New System.Drawing.Size(541, 31)
        Me.Sender.TextSize = New System.Drawing.Size(93, 16)
        '
        'frmDBConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 320)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDBConnection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DB Connection"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtDbPort.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sender, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents txtDbHost As TextBox
    Friend WithEvents txtDBName As TextBox
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents defaultConnString As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtDbPort As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtAPI As TextBox
    Friend WithEvents txtAPIUserName As TextBox
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSender As TextBox
    Friend WithEvents Sender As DevExpress.XtraLayout.LayoutControlItem
End Class
