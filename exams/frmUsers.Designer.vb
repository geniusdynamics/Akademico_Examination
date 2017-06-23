<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsers))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.radioNonTeaching = New System.Windows.Forms.RadioButton()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.radioTeaching = New System.Windows.Forms.RadioButton()
        Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.partnersLUE = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.layoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtDepartment = New System.Windows.Forms.TextBox()
        Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.layoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.layoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.userGC = New DevExpress.XtraGrid.GridControl()
        Me.userGV = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.partnersLUE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.userGC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.userGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnDelete)
        Me.LayoutControl1.Controls.Add(Me.btnEdit)
        Me.LayoutControl1.Controls.Add(Me.simpleButton1)
        Me.LayoutControl1.Controls.Add(Me.userGC)
        Me.LayoutControl1.Controls.Add(Me.radioTeaching)
        Me.LayoutControl1.Controls.Add(Me.radioNonTeaching)
        Me.LayoutControl1.Controls.Add(Me.partnersLUE)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtDepartment)
        Me.LayoutControl1.Controls.Add(Me.txtUserName)
        Me.LayoutControl1.Controls.Add(Me.txtPassword)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(853, 445)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.layoutControlItem3, Me.layoutControlItem5, Me.LayoutControlItem2, Me.layoutControlItem10, Me.layoutControlItem4, Me.LayoutControlItem6, Me.layoutControlItem9, Me.EmptySpaceItem1, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.EmptySpaceItem3, Me.LayoutControlItem11})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(853, 445)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'radioNonTeaching
        '
        Me.radioNonTeaching.Checked = True
        Me.radioNonTeaching.Location = New System.Drawing.Point(428, 12)
        Me.radioNonTeaching.Name = "radioNonTeaching"
        Me.radioNonTeaching.Size = New System.Drawing.Size(413, 25)
        Me.radioNonTeaching.TabIndex = 6
        Me.radioNonTeaching.TabStop = True
        Me.radioNonTeaching.Text = "Non Teaching Staff"
        Me.radioNonTeaching.UseVisualStyleBackColor = True
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.radioNonTeaching
        Me.LayoutControlItem1.Location = New System.Drawing.Point(416, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(417, 29)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.radioTeaching
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(416, 29)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'radioTeaching
        '
        Me.radioTeaching.Location = New System.Drawing.Point(12, 12)
        Me.radioTeaching.Name = "radioTeaching"
        Me.radioTeaching.Size = New System.Drawing.Size(412, 25)
        Me.radioTeaching.TabIndex = 7
        Me.radioTeaching.Text = "Teaching Staff"
        Me.radioTeaching.UseVisualStyleBackColor = True
        '
        'layoutControlItem3
        '
        Me.layoutControlItem3.Control = Me.partnersLUE
        Me.layoutControlItem3.CustomizationFormText = "Select Partner"
        Me.layoutControlItem3.Location = New System.Drawing.Point(0, 29)
        Me.layoutControlItem3.Name = "layoutControlItem3"
        Me.layoutControlItem3.Size = New System.Drawing.Size(833, 24)
        Me.layoutControlItem3.Text = "Select Partner"
        Me.layoutControlItem3.TextSize = New System.Drawing.Size(68, 13)
        '
        'partnersLUE
        '
        Me.partnersLUE.Location = New System.Drawing.Point(84, 41)
        Me.partnersLUE.Name = "partnersLUE"
        Me.partnersLUE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.partnersLUE.Properties.NullText = ""
        Me.partnersLUE.Size = New System.Drawing.Size(757, 20)
        Me.partnersLUE.StyleController = Me.LayoutControl1
        Me.partnersLUE.TabIndex = 6
        '
        'txtName
        '
        Me.txtName.ForeColor = System.Drawing.Color.Red
        Me.txtName.Location = New System.Drawing.Point(84, 65)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(340, 20)
        Me.txtName.TabIndex = 8
        '
        'layoutControlItem5
        '
        Me.layoutControlItem5.Control = Me.txtName
        Me.layoutControlItem5.CustomizationFormText = "Staff"
        Me.layoutControlItem5.Location = New System.Drawing.Point(0, 53)
        Me.layoutControlItem5.Name = "layoutControlItem5"
        Me.layoutControlItem5.Size = New System.Drawing.Size(416, 24)
        Me.layoutControlItem5.Text = "Staff"
        Me.layoutControlItem5.TextSize = New System.Drawing.Size(68, 13)
        '
        'txtDepartment
        '
        Me.txtDepartment.ForeColor = System.Drawing.Color.Red
        Me.txtDepartment.Location = New System.Drawing.Point(500, 65)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.ReadOnly = True
        Me.txtDepartment.Size = New System.Drawing.Size(341, 20)
        Me.txtDepartment.TabIndex = 7
        '
        'layoutControlItem4
        '
        Me.layoutControlItem4.Control = Me.txtDepartment
        Me.layoutControlItem4.CustomizationFormText = "Department"
        Me.layoutControlItem4.Location = New System.Drawing.Point(416, 53)
        Me.layoutControlItem4.Name = "layoutControlItem4"
        Me.layoutControlItem4.Size = New System.Drawing.Size(417, 24)
        Me.layoutControlItem4.Text = "Department"
        Me.layoutControlItem4.TextSize = New System.Drawing.Size(68, 13)
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(84, 89)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(340, 20)
        Me.txtUserName.TabIndex = 13
        '
        'layoutControlItem10
        '
        Me.layoutControlItem10.Control = Me.txtUserName
        Me.layoutControlItem10.CustomizationFormText = "User Name"
        Me.layoutControlItem10.Location = New System.Drawing.Point(0, 77)
        Me.layoutControlItem10.Name = "layoutControlItem10"
        Me.layoutControlItem10.Size = New System.Drawing.Size(416, 24)
        Me.layoutControlItem10.Text = "User Name"
        Me.layoutControlItem10.TextSize = New System.Drawing.Size(68, 13)
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(500, 89)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(341, 20)
        Me.txtPassword.TabIndex = 12
        '
        'layoutControlItem9
        '
        Me.layoutControlItem9.Control = Me.txtPassword
        Me.layoutControlItem9.CustomizationFormText = "Password"
        Me.layoutControlItem9.Location = New System.Drawing.Point(416, 77)
        Me.layoutControlItem9.Name = "layoutControlItem9"
        Me.layoutControlItem9.Size = New System.Drawing.Size(417, 24)
        Me.layoutControlItem9.Text = "Password"
        Me.layoutControlItem9.TextSize = New System.Drawing.Size(68, 13)
        '
        'userGC
        '
        Me.userGC.Location = New System.Drawing.Point(12, 156)
        Me.userGC.MainView = Me.userGV
        Me.userGC.Name = "userGC"
        Me.userGC.Size = New System.Drawing.Size(829, 234)
        Me.userGC.TabIndex = 14
        Me.userGC.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.userGV})
        '
        'userGV
        '
        Me.userGV.GridControl = Me.userGC
        Me.userGV.Name = "userGV"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.userGC
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 144)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(833, 238)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 101)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(700, 43)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'simpleButton1
        '
        Me.simpleButton1.Image = CType(resources.GetObject("simpleButton1.Image"), System.Drawing.Image)
        Me.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.simpleButton1.Location = New System.Drawing.Point(774, 113)
        Me.simpleButton1.Name = "simpleButton1"
        Me.simpleButton1.Size = New System.Drawing.Size(67, 39)
        Me.simpleButton1.StyleController = Me.LayoutControl1
        Me.simpleButton1.TabIndex = 15
        Me.simpleButton1.Text = "Add"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.simpleButton1
        Me.LayoutControlItem7.Location = New System.Drawing.Point(762, 101)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(71, 43)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnEdit.Location = New System.Drawing.Point(712, 113)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(58, 39)
        Me.btnEdit.StyleController = Me.LayoutControl1
        Me.btnEdit.TabIndex = 16
        Me.btnEdit.Text = "Edit"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnEdit
        Me.LayoutControlItem8.Location = New System.Drawing.Point(700, 101)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(62, 43)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 382)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(787, 43)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(799, 394)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(42, 39)
        Me.btnDelete.StyleController = Me.LayoutControl1
        Me.btnDelete.TabIndex = 17
        Me.btnDelete.Text = "Delete"
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.btnDelete
        Me.LayoutControlItem11.Location = New System.Drawing.Point(787, 382)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(46, 43)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.RightToLeft = True
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 445)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmUsers"
        Me.Text = "System Users"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.partnersLUE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.userGC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.userGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents userGC As DevExpress.XtraGrid.GridControl
    Friend WithEvents userGV As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents radioTeaching As RadioButton
    Private WithEvents radioNonTeaching As RadioButton
    Friend WithEvents partnersLUE As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtDepartment As TextBox
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
