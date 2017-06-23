Partial Public Class frmMainForm
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainForm))
        Me.mainRibbon = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.performanceCommentsBI = New DevExpress.XtraBars.BarButtonItem()
        Me.principalCommentBI = New DevExpress.XtraBars.BarButtonItem()
        Me.classBasedBI = New DevExpress.XtraBars.BarButtonItem()
        Me.subjectBasedBI = New DevExpress.XtraBars.BarButtonItem()
        Me.createExamBI = New DevExpress.XtraBars.BarButtonItem()
        Me.editExamBI = New DevExpress.XtraBars.BarButtonItem()
        Me.localExaminationBI = New DevExpress.XtraBars.BarButtonItem()
        Me.studentProfileBI = New DevExpress.XtraBars.BarButtonItem()
        Me.performanceIndexBI = New DevExpress.XtraBars.BarButtonItem()
        Me.subjectPerformanceIndexBI = New DevExpress.XtraBars.BarButtonItem()
        Me.generalPerformanceBI = New DevExpress.XtraBars.BarButtonItem()
        Me.studentPerformanceBI = New DevExpress.XtraBars.BarButtonItem()
        Me.subjectPerformanceBI = New DevExpress.XtraBars.BarButtonItem()
        Me.reportFormConfigurationFormBI = New DevExpress.XtraBars.BarButtonItem()
        Me.meritListConfigBI = New DevExpress.XtraBars.BarButtonItem()
        Me.splitSubjectBI = New DevExpress.XtraBars.BarButtonItem()
        Me.editSplitBI = New DevExpress.XtraBars.BarButtonItem()
        Me.subjectTakenBI = New DevExpress.XtraBars.BarButtonItem()
        Me.assignIndexNoBI = New DevExpress.XtraBars.BarButtonItem()
        Me.createNationalExamBI = New DevExpress.XtraBars.BarButtonItem()
        Me.editNationalExamBI = New DevExpress.XtraBars.BarButtonItem()
        Me.enterNationExams = New DevExpress.XtraBars.BarButtonItem()
        Me.SkinRibbonGalleryBarItem1 = New DevExpress.XtraBars.SkinRibbonGalleryBarItem()
        Me.applicationFontBI = New DevExpress.XtraBars.BarButtonItem()
        Me.defaultBI = New DevExpress.XtraBars.BarButtonItem()
        Me.systemUsersBI = New DevExpress.XtraBars.BarButtonItem()
        Me.rightsBI = New DevExpress.XtraBars.BarButtonItem()
        Me.classSubjectBI = New DevExpress.XtraBars.BarButtonItem()
        Me.showSubjectsBI = New DevExpress.XtraBars.BarButtonItem()
        Me.markSheetBI = New DevExpress.XtraBars.BarButtonItem()
        Me.addSubjectsBI = New DevExpress.XtraBars.BarButtonItem()
        Me.editSubjectBI = New DevExpress.XtraBars.BarButtonItem()
        Me.deleteSubjectBI = New DevExpress.XtraBars.BarButtonItem()
        Me.aboutBI = New DevExpress.XtraBars.BarButtonItem()
        Me.configurationsMenu = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgPerformanceComments = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgPrinciapalsComments = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgReportConfiguration = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgMeritConfig = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.subjectsMenu = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgAddSubject = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgClassSubjects = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.splitSubjectRpg = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgSubjectTaken = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgAssignIndexNo = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgSubjectsTaken = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.gradingMenu = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgClassBased = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgSubjectBasedGrading = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.examinationsMenu = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgCreateExam = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgEditExam = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgCreateNationalExam = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.deleteNationalExamBI = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.performanceEntryMenu = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgLocalExamination = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgEnterNationalExam = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgMarkSheet = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.resultAnalysisMenu = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgStudentProfile = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgPerformanceIndex = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgGeneralPerformance = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgStudentPerformance = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgSubjectPerformance = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgSubjectPerformanceIndex = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgUsers = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgSystemUsers = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgRights = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgChangeLook = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgTheme = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgApplicationFont = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgDefault = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.aboutRP = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.aboutRPG = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.myXtraTabbedMdiManager = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager()
        Me.mainNavBar = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavBarGroup1 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.dbConnection = New DevExpress.XtraNavBar.NavBarItem()
        Me.createExamNB = New DevExpress.XtraNavBar.NavBarItem()
        Me.localExamNB = New DevExpress.XtraNavBar.NavBarItem()
        Me.generalPerformanceNB = New DevExpress.XtraNavBar.NavBarItem()
        Me.subjectPerformanceNB = New DevExpress.XtraNavBar.NavBarItem()
        Me.myDefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel()
        Me.SplashScreenManager2 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.exams.WaitForm1), True, True, True)
        Me.licenseNB = New DevExpress.XtraNavBar.NavBarItem()
        CType(Me.mainRibbon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myXtraTabbedMdiManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mainNavBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mainRibbon
        '
        Me.mainRibbon.ExpandCollapseItem.Id = 0
        Me.mainRibbon.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.mainRibbon.ExpandCollapseItem, Me.performanceCommentsBI, Me.principalCommentBI, Me.classBasedBI, Me.subjectBasedBI, Me.createExamBI, Me.editExamBI, Me.localExaminationBI, Me.studentProfileBI, Me.performanceIndexBI, Me.subjectPerformanceIndexBI, Me.generalPerformanceBI, Me.studentPerformanceBI, Me.subjectPerformanceBI, Me.reportFormConfigurationFormBI, Me.meritListConfigBI, Me.splitSubjectBI, Me.editSplitBI, Me.subjectTakenBI, Me.assignIndexNoBI, Me.createNationalExamBI, Me.editNationalExamBI, Me.enterNationExams, Me.SkinRibbonGalleryBarItem1, Me.applicationFontBI, Me.defaultBI, Me.systemUsersBI, Me.rightsBI, Me.classSubjectBI, Me.showSubjectsBI, Me.markSheetBI, Me.addSubjectsBI, Me.editSubjectBI, Me.deleteSubjectBI, Me.aboutBI})
        Me.mainRibbon.Location = New System.Drawing.Point(0, 0)
        Me.mainRibbon.MaxItemId = 35
        Me.mainRibbon.Name = "mainRibbon"
        Me.mainRibbon.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.configurationsMenu, Me.subjectsMenu, Me.gradingMenu, Me.examinationsMenu, Me.performanceEntryMenu, Me.resultAnalysisMenu, Me.rpgUsers, Me.rpgChangeLook, Me.aboutRP})
        Me.mainRibbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010
        Me.mainRibbon.Size = New System.Drawing.Size(979, 143)
        '
        'performanceCommentsBI
        '
        Me.performanceCommentsBI.Caption = "Performance Comments"
        Me.performanceCommentsBI.Glyph = CType(resources.GetObject("performanceCommentsBI.Glyph"), System.Drawing.Image)
        Me.performanceCommentsBI.Id = 1
        Me.performanceCommentsBI.LargeGlyph = CType(resources.GetObject("performanceCommentsBI.LargeGlyph"), System.Drawing.Image)
        Me.performanceCommentsBI.Name = "performanceCommentsBI"
        '
        'principalCommentBI
        '
        Me.principalCommentBI.Caption = "Prinicipal Comments"
        Me.principalCommentBI.Glyph = CType(resources.GetObject("principalCommentBI.Glyph"), System.Drawing.Image)
        Me.principalCommentBI.Id = 2
        Me.principalCommentBI.LargeGlyph = CType(resources.GetObject("principalCommentBI.LargeGlyph"), System.Drawing.Image)
        Me.principalCommentBI.Name = "principalCommentBI"
        '
        'classBasedBI
        '
        Me.classBasedBI.Caption = "Class Based Grading Scheme"
        Me.classBasedBI.Glyph = CType(resources.GetObject("classBasedBI.Glyph"), System.Drawing.Image)
        Me.classBasedBI.Id = 3
        Me.classBasedBI.LargeGlyph = CType(resources.GetObject("classBasedBI.LargeGlyph"), System.Drawing.Image)
        Me.classBasedBI.Name = "classBasedBI"
        '
        'subjectBasedBI
        '
        Me.subjectBasedBI.Caption = "Subject Based Grading"
        Me.subjectBasedBI.Glyph = CType(resources.GetObject("subjectBasedBI.Glyph"), System.Drawing.Image)
        Me.subjectBasedBI.Id = 4
        Me.subjectBasedBI.LargeGlyph = CType(resources.GetObject("subjectBasedBI.LargeGlyph"), System.Drawing.Image)
        Me.subjectBasedBI.Name = "subjectBasedBI"
        '
        'createExamBI
        '
        Me.createExamBI.Caption = "Create Exam"
        Me.createExamBI.Id = 5
        Me.createExamBI.LargeGlyph = CType(resources.GetObject("createExamBI.LargeGlyph"), System.Drawing.Image)
        Me.createExamBI.Name = "createExamBI"
        '
        'editExamBI
        '
        Me.editExamBI.Caption = "Edit Exam"
        Me.editExamBI.Glyph = CType(resources.GetObject("editExamBI.Glyph"), System.Drawing.Image)
        Me.editExamBI.Id = 6
        Me.editExamBI.LargeGlyph = CType(resources.GetObject("editExamBI.LargeGlyph"), System.Drawing.Image)
        Me.editExamBI.Name = "editExamBI"
        '
        'localExaminationBI
        '
        Me.localExaminationBI.Caption = "Local Examination"
        Me.localExaminationBI.Glyph = CType(resources.GetObject("localExaminationBI.Glyph"), System.Drawing.Image)
        Me.localExaminationBI.Id = 7
        Me.localExaminationBI.LargeGlyph = CType(resources.GetObject("localExaminationBI.LargeGlyph"), System.Drawing.Image)
        Me.localExaminationBI.Name = "localExaminationBI"
        '
        'studentProfileBI
        '
        Me.studentProfileBI.Caption = "Student Performance Profile"
        Me.studentProfileBI.Glyph = CType(resources.GetObject("studentProfileBI.Glyph"), System.Drawing.Image)
        Me.studentProfileBI.Id = 8
        Me.studentProfileBI.LargeGlyph = CType(resources.GetObject("studentProfileBI.LargeGlyph"), System.Drawing.Image)
        Me.studentProfileBI.Name = "studentProfileBI"
        '
        'performanceIndexBI
        '
        Me.performanceIndexBI.Caption = "Student Performance Index"
        Me.performanceIndexBI.Glyph = CType(resources.GetObject("performanceIndexBI.Glyph"), System.Drawing.Image)
        Me.performanceIndexBI.Id = 9
        Me.performanceIndexBI.LargeGlyph = CType(resources.GetObject("performanceIndexBI.LargeGlyph"), System.Drawing.Image)
        Me.performanceIndexBI.Name = "performanceIndexBI"
        '
        'subjectPerformanceIndexBI
        '
        Me.subjectPerformanceIndexBI.Caption = "Subject Performance Index"
        Me.subjectPerformanceIndexBI.Glyph = CType(resources.GetObject("subjectPerformanceIndexBI.Glyph"), System.Drawing.Image)
        Me.subjectPerformanceIndexBI.Id = 10
        Me.subjectPerformanceIndexBI.LargeGlyph = CType(resources.GetObject("subjectPerformanceIndexBI.LargeGlyph"), System.Drawing.Image)
        Me.subjectPerformanceIndexBI.Name = "subjectPerformanceIndexBI"
        '
        'generalPerformanceBI
        '
        Me.generalPerformanceBI.Caption = "General Performance"
        Me.generalPerformanceBI.Glyph = CType(resources.GetObject("generalPerformanceBI.Glyph"), System.Drawing.Image)
        Me.generalPerformanceBI.Id = 11
        Me.generalPerformanceBI.LargeGlyph = CType(resources.GetObject("generalPerformanceBI.LargeGlyph"), System.Drawing.Image)
        Me.generalPerformanceBI.Name = "generalPerformanceBI"
        '
        'studentPerformanceBI
        '
        Me.studentPerformanceBI.Caption = "Student Performance"
        Me.studentPerformanceBI.Glyph = CType(resources.GetObject("studentPerformanceBI.Glyph"), System.Drawing.Image)
        Me.studentPerformanceBI.Id = 12
        Me.studentPerformanceBI.LargeGlyph = CType(resources.GetObject("studentPerformanceBI.LargeGlyph"), System.Drawing.Image)
        Me.studentPerformanceBI.Name = "studentPerformanceBI"
        '
        'subjectPerformanceBI
        '
        Me.subjectPerformanceBI.Caption = "Subject Performance"
        Me.subjectPerformanceBI.Glyph = CType(resources.GetObject("subjectPerformanceBI.Glyph"), System.Drawing.Image)
        Me.subjectPerformanceBI.Id = 13
        Me.subjectPerformanceBI.LargeGlyph = CType(resources.GetObject("subjectPerformanceBI.LargeGlyph"), System.Drawing.Image)
        Me.subjectPerformanceBI.Name = "subjectPerformanceBI"
        '
        'reportFormConfigurationFormBI
        '
        Me.reportFormConfigurationFormBI.Caption = "Report Form Configurations"
        Me.reportFormConfigurationFormBI.Glyph = CType(resources.GetObject("reportFormConfigurationFormBI.Glyph"), System.Drawing.Image)
        Me.reportFormConfigurationFormBI.Id = 14
        Me.reportFormConfigurationFormBI.LargeGlyph = CType(resources.GetObject("reportFormConfigurationFormBI.LargeGlyph"), System.Drawing.Image)
        Me.reportFormConfigurationFormBI.Name = "reportFormConfigurationFormBI"
        '
        'meritListConfigBI
        '
        Me.meritListConfigBI.Caption = "Merit List Configurations"
        Me.meritListConfigBI.Glyph = CType(resources.GetObject("meritListConfigBI.Glyph"), System.Drawing.Image)
        Me.meritListConfigBI.Id = 15
        Me.meritListConfigBI.LargeGlyph = CType(resources.GetObject("meritListConfigBI.LargeGlyph"), System.Drawing.Image)
        Me.meritListConfigBI.Name = "meritListConfigBI"
        '
        'splitSubjectBI
        '
        Me.splitSubjectBI.Caption = "Add Split Subject"
        Me.splitSubjectBI.Glyph = CType(resources.GetObject("splitSubjectBI.Glyph"), System.Drawing.Image)
        Me.splitSubjectBI.Id = 16
        Me.splitSubjectBI.LargeGlyph = CType(resources.GetObject("splitSubjectBI.LargeGlyph"), System.Drawing.Image)
        Me.splitSubjectBI.Name = "splitSubjectBI"
        '
        'editSplitBI
        '
        Me.editSplitBI.Caption = "Edit Split Subject"
        Me.editSplitBI.Glyph = CType(resources.GetObject("editSplitBI.Glyph"), System.Drawing.Image)
        Me.editSplitBI.Id = 17
        Me.editSplitBI.LargeGlyph = CType(resources.GetObject("editSplitBI.LargeGlyph"), System.Drawing.Image)
        Me.editSplitBI.Name = "editSplitBI"
        '
        'subjectTakenBI
        '
        Me.subjectTakenBI.Caption = "Assign Subject Taken"
        Me.subjectTakenBI.Glyph = CType(resources.GetObject("subjectTakenBI.Glyph"), System.Drawing.Image)
        Me.subjectTakenBI.Id = 18
        Me.subjectTakenBI.LargeGlyph = CType(resources.GetObject("subjectTakenBI.LargeGlyph"), System.Drawing.Image)
        Me.subjectTakenBI.Name = "subjectTakenBI"
        '
        'assignIndexNoBI
        '
        Me.assignIndexNoBI.Caption = "Assign Index Number"
        Me.assignIndexNoBI.Glyph = CType(resources.GetObject("assignIndexNoBI.Glyph"), System.Drawing.Image)
        Me.assignIndexNoBI.Id = 19
        Me.assignIndexNoBI.LargeGlyph = CType(resources.GetObject("assignIndexNoBI.LargeGlyph"), System.Drawing.Image)
        Me.assignIndexNoBI.Name = "assignIndexNoBI"
        '
        'createNationalExamBI
        '
        Me.createNationalExamBI.Caption = "Create National Exam"
        Me.createNationalExamBI.Glyph = CType(resources.GetObject("createNationalExamBI.Glyph"), System.Drawing.Image)
        Me.createNationalExamBI.Id = 20
        Me.createNationalExamBI.LargeGlyph = CType(resources.GetObject("createNationalExamBI.LargeGlyph"), System.Drawing.Image)
        Me.createNationalExamBI.Name = "createNationalExamBI"
        '
        'editNationalExamBI
        '
        Me.editNationalExamBI.Caption = "Edit National Exam"
        Me.editNationalExamBI.Glyph = CType(resources.GetObject("editNationalExamBI.Glyph"), System.Drawing.Image)
        Me.editNationalExamBI.Id = 21
        Me.editNationalExamBI.LargeGlyph = CType(resources.GetObject("editNationalExamBI.LargeGlyph"), System.Drawing.Image)
        Me.editNationalExamBI.Name = "editNationalExamBI"
        '
        'enterNationExams
        '
        Me.enterNationExams.Caption = "National Examination"
        Me.enterNationExams.Glyph = CType(resources.GetObject("enterNationExams.Glyph"), System.Drawing.Image)
        Me.enterNationExams.Id = 22
        Me.enterNationExams.LargeGlyph = CType(resources.GetObject("enterNationExams.LargeGlyph"), System.Drawing.Image)
        Me.enterNationExams.Name = "enterNationExams"
        '
        'SkinRibbonGalleryBarItem1
        '
        Me.SkinRibbonGalleryBarItem1.Caption = "SkinRibbonGalleryBarItem1"
        Me.SkinRibbonGalleryBarItem1.Id = 23
        Me.SkinRibbonGalleryBarItem1.Name = "SkinRibbonGalleryBarItem1"
        '
        'applicationFontBI
        '
        Me.applicationFontBI.Caption = "Application Font"
        Me.applicationFontBI.Glyph = CType(resources.GetObject("applicationFontBI.Glyph"), System.Drawing.Image)
        Me.applicationFontBI.Id = 24
        Me.applicationFontBI.LargeGlyph = CType(resources.GetObject("applicationFontBI.LargeGlyph"), System.Drawing.Image)
        Me.applicationFontBI.Name = "applicationFontBI"
        '
        'defaultBI
        '
        Me.defaultBI.Caption = "Restore Default Look And Feel"
        Me.defaultBI.Glyph = CType(resources.GetObject("defaultBI.Glyph"), System.Drawing.Image)
        Me.defaultBI.Id = 25
        Me.defaultBI.LargeGlyph = CType(resources.GetObject("defaultBI.LargeGlyph"), System.Drawing.Image)
        Me.defaultBI.Name = "defaultBI"
        '
        'systemUsersBI
        '
        Me.systemUsersBI.Caption = "System Users"
        Me.systemUsersBI.Glyph = CType(resources.GetObject("systemUsersBI.Glyph"), System.Drawing.Image)
        Me.systemUsersBI.Id = 26
        Me.systemUsersBI.LargeGlyph = CType(resources.GetObject("systemUsersBI.LargeGlyph"), System.Drawing.Image)
        Me.systemUsersBI.Name = "systemUsersBI"
        '
        'rightsBI
        '
        Me.rightsBI.Caption = "User Rights And Priviledges"
        Me.rightsBI.Glyph = CType(resources.GetObject("rightsBI.Glyph"), System.Drawing.Image)
        Me.rightsBI.Id = 27
        Me.rightsBI.LargeGlyph = CType(resources.GetObject("rightsBI.LargeGlyph"), System.Drawing.Image)
        Me.rightsBI.Name = "rightsBI"
        '
        'classSubjectBI
        '
        Me.classSubjectBI.Caption = "Assign Class Subject"
        Me.classSubjectBI.Glyph = CType(resources.GetObject("classSubjectBI.Glyph"), System.Drawing.Image)
        Me.classSubjectBI.Id = 28
        Me.classSubjectBI.LargeGlyph = CType(resources.GetObject("classSubjectBI.LargeGlyph"), System.Drawing.Image)
        Me.classSubjectBI.Name = "classSubjectBI"
        '
        'showSubjectsBI
        '
        Me.showSubjectsBI.Caption = "Student Subjects Taken"
        Me.showSubjectsBI.Glyph = CType(resources.GetObject("showSubjectsBI.Glyph"), System.Drawing.Image)
        Me.showSubjectsBI.Id = 29
        Me.showSubjectsBI.LargeGlyph = CType(resources.GetObject("showSubjectsBI.LargeGlyph"), System.Drawing.Image)
        Me.showSubjectsBI.Name = "showSubjectsBI"
        '
        'markSheetBI
        '
        Me.markSheetBI.Caption = "Mark Sheet"
        Me.markSheetBI.Glyph = CType(resources.GetObject("markSheetBI.Glyph"), System.Drawing.Image)
        Me.markSheetBI.Id = 30
        Me.markSheetBI.LargeGlyph = CType(resources.GetObject("markSheetBI.LargeGlyph"), System.Drawing.Image)
        Me.markSheetBI.Name = "markSheetBI"
        '
        'addSubjectsBI
        '
        Me.addSubjectsBI.Caption = "Add Subjects"
        Me.addSubjectsBI.Glyph = CType(resources.GetObject("addSubjectsBI.Glyph"), System.Drawing.Image)
        Me.addSubjectsBI.Id = 31
        Me.addSubjectsBI.LargeGlyph = CType(resources.GetObject("addSubjectsBI.LargeGlyph"), System.Drawing.Image)
        Me.addSubjectsBI.Name = "addSubjectsBI"
        '
        'editSubjectBI
        '
        Me.editSubjectBI.Caption = "Edit Subject"
        Me.editSubjectBI.Glyph = CType(resources.GetObject("editSubjectBI.Glyph"), System.Drawing.Image)
        Me.editSubjectBI.Id = 32
        Me.editSubjectBI.LargeGlyph = CType(resources.GetObject("editSubjectBI.LargeGlyph"), System.Drawing.Image)
        Me.editSubjectBI.Name = "editSubjectBI"
        '
        'deleteSubjectBI
        '
        Me.deleteSubjectBI.Caption = "Delete Subject"
        Me.deleteSubjectBI.Glyph = CType(resources.GetObject("deleteSubjectBI.Glyph"), System.Drawing.Image)
        Me.deleteSubjectBI.Id = 33
        Me.deleteSubjectBI.LargeGlyph = CType(resources.GetObject("deleteSubjectBI.LargeGlyph"), System.Drawing.Image)
        Me.deleteSubjectBI.Name = "deleteSubjectBI"
        '
        'aboutBI
        '
        Me.aboutBI.Caption = "About Us"
        Me.aboutBI.Glyph = CType(resources.GetObject("aboutBI.Glyph"), System.Drawing.Image)
        Me.aboutBI.Id = 34
        Me.aboutBI.LargeGlyph = CType(resources.GetObject("aboutBI.LargeGlyph"), System.Drawing.Image)
        Me.aboutBI.Name = "aboutBI"
        '
        'configurationsMenu
        '
        Me.configurationsMenu.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgPerformanceComments, Me.rpgPrinciapalsComments, Me.rpgReportConfiguration, Me.rpgMeritConfig})
        Me.configurationsMenu.Name = "configurationsMenu"
        Me.configurationsMenu.Text = "Configurations"
        '
        'rpgPerformanceComments
        '
        Me.rpgPerformanceComments.ItemLinks.Add(Me.performanceCommentsBI)
        Me.rpgPerformanceComments.Name = "rpgPerformanceComments"
        Me.rpgPerformanceComments.Text = "Performance Comments"
        '
        'rpgPrinciapalsComments
        '
        Me.rpgPrinciapalsComments.ItemLinks.Add(Me.principalCommentBI)
        Me.rpgPrinciapalsComments.Name = "rpgPrinciapalsComments"
        Me.rpgPrinciapalsComments.Text = "Principal Comments"
        '
        'rpgReportConfiguration
        '
        Me.rpgReportConfiguration.ItemLinks.Add(Me.reportFormConfigurationFormBI)
        Me.rpgReportConfiguration.Name = "rpgReportConfiguration"
        Me.rpgReportConfiguration.Text = "Report Form Configurations"
        '
        'rpgMeritConfig
        '
        Me.rpgMeritConfig.ItemLinks.Add(Me.meritListConfigBI)
        Me.rpgMeritConfig.Name = "rpgMeritConfig"
        Me.rpgMeritConfig.Text = "Merit List Configurations"
        '
        'subjectsMenu
        '
        Me.subjectsMenu.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgAddSubject, Me.rpgClassSubjects, Me.splitSubjectRpg, Me.rpgSubjectTaken, Me.rpgAssignIndexNo, Me.rpgSubjectsTaken})
        Me.subjectsMenu.Name = "subjectsMenu"
        Me.subjectsMenu.Text = "Subjects"
        '
        'rpgAddSubject
        '
        Me.rpgAddSubject.ItemLinks.Add(Me.addSubjectsBI)
        Me.rpgAddSubject.ItemLinks.Add(Me.editSubjectBI)
        Me.rpgAddSubject.ItemLinks.Add(Me.deleteSubjectBI)
        Me.rpgAddSubject.Name = "rpgAddSubject"
        Me.rpgAddSubject.Text = "Add Subject"
        '
        'rpgClassSubjects
        '
        Me.rpgClassSubjects.ItemLinks.Add(Me.classSubjectBI)
        Me.rpgClassSubjects.Name = "rpgClassSubjects"
        Me.rpgClassSubjects.Text = "Assign Class Subject"
        '
        'splitSubjectRpg
        '
        Me.splitSubjectRpg.ItemLinks.Add(Me.splitSubjectBI)
        Me.splitSubjectRpg.ItemLinks.Add(Me.editSplitBI)
        Me.splitSubjectRpg.Name = "splitSubjectRpg"
        Me.splitSubjectRpg.Text = "Split Subject"
        '
        'rpgSubjectTaken
        '
        Me.rpgSubjectTaken.ItemLinks.Add(Me.subjectTakenBI)
        Me.rpgSubjectTaken.Name = "rpgSubjectTaken"
        Me.rpgSubjectTaken.Text = "Assingn Subjects Taken"
        '
        'rpgAssignIndexNo
        '
        Me.rpgAssignIndexNo.ItemLinks.Add(Me.assignIndexNoBI)
        Me.rpgAssignIndexNo.Name = "rpgAssignIndexNo"
        Me.rpgAssignIndexNo.Text = "Assign Index Number"
        '
        'rpgSubjectsTaken
        '
        Me.rpgSubjectsTaken.ItemLinks.Add(Me.showSubjectsBI)
        Me.rpgSubjectsTaken.Name = "rpgSubjectsTaken"
        Me.rpgSubjectsTaken.Text = "Student Subjects Taken"
        '
        'gradingMenu
        '
        Me.gradingMenu.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgClassBased, Me.rpgSubjectBasedGrading})
        Me.gradingMenu.Name = "gradingMenu"
        Me.gradingMenu.Text = "Grading"
        '
        'rpgClassBased
        '
        Me.rpgClassBased.ItemLinks.Add(Me.classBasedBI)
        Me.rpgClassBased.Name = "rpgClassBased"
        Me.rpgClassBased.Text = "Class Based Grading Scheme"
        '
        'rpgSubjectBasedGrading
        '
        Me.rpgSubjectBasedGrading.ItemLinks.Add(Me.subjectBasedBI)
        Me.rpgSubjectBasedGrading.Name = "rpgSubjectBasedGrading"
        Me.rpgSubjectBasedGrading.Text = "Subject Based Grading"
        '
        'examinationsMenu
        '
        Me.examinationsMenu.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgCreateExam, Me.rpgEditExam, Me.rpgCreateNationalExam, Me.deleteNationalExamBI})
        Me.examinationsMenu.Name = "examinationsMenu"
        Me.examinationsMenu.Text = "Examinations"
        '
        'rpgCreateExam
        '
        Me.rpgCreateExam.ItemLinks.Add(Me.createExamBI)
        Me.rpgCreateExam.Name = "rpgCreateExam"
        Me.rpgCreateExam.Text = "Create Exam"
        '
        'rpgEditExam
        '
        Me.rpgEditExam.ItemLinks.Add(Me.editExamBI)
        Me.rpgEditExam.Name = "rpgEditExam"
        Me.rpgEditExam.Text = "Edit Examination"
        '
        'rpgCreateNationalExam
        '
        Me.rpgCreateNationalExam.ItemLinks.Add(Me.createNationalExamBI)
        Me.rpgCreateNationalExam.Name = "rpgCreateNationalExam"
        Me.rpgCreateNationalExam.Text = "Create National Exam"
        '
        'deleteNationalExamBI
        '
        Me.deleteNationalExamBI.ItemLinks.Add(Me.editNationalExamBI)
        Me.deleteNationalExamBI.Name = "deleteNationalExamBI"
        Me.deleteNationalExamBI.Text = "Edit National Exam"
        '
        'performanceEntryMenu
        '
        Me.performanceEntryMenu.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgLocalExamination, Me.rpgEnterNationalExam, Me.rpgMarkSheet})
        Me.performanceEntryMenu.Name = "performanceEntryMenu"
        Me.performanceEntryMenu.Text = "Performance Entry"
        '
        'rpgLocalExamination
        '
        Me.rpgLocalExamination.ItemLinks.Add(Me.localExaminationBI)
        Me.rpgLocalExamination.Name = "rpgLocalExamination"
        Me.rpgLocalExamination.Text = "Local Examination"
        '
        'rpgEnterNationalExam
        '
        Me.rpgEnterNationalExam.ItemLinks.Add(Me.enterNationExams)
        Me.rpgEnterNationalExam.Name = "rpgEnterNationalExam"
        Me.rpgEnterNationalExam.Text = "Enter National Examination"
        '
        'rpgMarkSheet
        '
        Me.rpgMarkSheet.ItemLinks.Add(Me.markSheetBI)
        Me.rpgMarkSheet.Name = "rpgMarkSheet"
        Me.rpgMarkSheet.Text = "Mark Sheet"
        '
        'resultAnalysisMenu
        '
        Me.resultAnalysisMenu.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgStudentProfile, Me.rpgPerformanceIndex, Me.rpgGeneralPerformance, Me.rpgStudentPerformance, Me.rpgSubjectPerformance, Me.rpgSubjectPerformanceIndex})
        Me.resultAnalysisMenu.Name = "resultAnalysisMenu"
        Me.resultAnalysisMenu.Text = "Result Analysis"
        '
        'rpgStudentProfile
        '
        Me.rpgStudentProfile.ItemLinks.Add(Me.studentProfileBI)
        Me.rpgStudentProfile.Name = "rpgStudentProfile"
        Me.rpgStudentProfile.Text = "Student Performance Profile"
        '
        'rpgPerformanceIndex
        '
        Me.rpgPerformanceIndex.ItemLinks.Add(Me.performanceIndexBI)
        Me.rpgPerformanceIndex.Name = "rpgPerformanceIndex"
        Me.rpgPerformanceIndex.Text = "Student Performance Index"
        '
        'rpgGeneralPerformance
        '
        Me.rpgGeneralPerformance.ItemLinks.Add(Me.generalPerformanceBI)
        Me.rpgGeneralPerformance.Name = "rpgGeneralPerformance"
        Me.rpgGeneralPerformance.Text = "General Performance"
        '
        'rpgStudentPerformance
        '
        Me.rpgStudentPerformance.ItemLinks.Add(Me.studentPerformanceBI)
        Me.rpgStudentPerformance.Name = "rpgStudentPerformance"
        Me.rpgStudentPerformance.Text = "Student Performance"
        '
        'rpgSubjectPerformance
        '
        Me.rpgSubjectPerformance.ItemLinks.Add(Me.subjectPerformanceBI)
        Me.rpgSubjectPerformance.Name = "rpgSubjectPerformance"
        Me.rpgSubjectPerformance.Text = "Subject Performance"
        '
        'rpgSubjectPerformanceIndex
        '
        Me.rpgSubjectPerformanceIndex.ItemLinks.Add(Me.subjectPerformanceIndexBI)
        Me.rpgSubjectPerformanceIndex.Name = "rpgSubjectPerformanceIndex"
        Me.rpgSubjectPerformanceIndex.Text = "Subject Performance Index"
        '
        'rpgUsers
        '
        Me.rpgUsers.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgSystemUsers, Me.rpgRights})
        Me.rpgUsers.Name = "rpgUsers"
        Me.rpgUsers.Text = "Users"
        '
        'rpgSystemUsers
        '
        Me.rpgSystemUsers.ItemLinks.Add(Me.systemUsersBI)
        Me.rpgSystemUsers.Name = "rpgSystemUsers"
        Me.rpgSystemUsers.Text = "System Users"
        '
        'rpgRights
        '
        Me.rpgRights.ItemLinks.Add(Me.rightsBI)
        Me.rpgRights.Name = "rpgRights"
        Me.rpgRights.Text = "User Rights And Priviledges"
        '
        'rpgChangeLook
        '
        Me.rpgChangeLook.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgTheme, Me.rpgApplicationFont, Me.rpgDefault})
        Me.rpgChangeLook.Name = "rpgChangeLook"
        Me.rpgChangeLook.Text = "Change Look"
        '
        'rpgTheme
        '
        Me.rpgTheme.ItemLinks.Add(Me.SkinRibbonGalleryBarItem1)
        Me.rpgTheme.Name = "rpgTheme"
        Me.rpgTheme.Text = "Select Theme"
        '
        'rpgApplicationFont
        '
        Me.rpgApplicationFont.ItemLinks.Add(Me.applicationFontBI)
        Me.rpgApplicationFont.Name = "rpgApplicationFont"
        Me.rpgApplicationFont.Text = "Application Font"
        '
        'rpgDefault
        '
        Me.rpgDefault.ItemLinks.Add(Me.defaultBI)
        Me.rpgDefault.Name = "rpgDefault"
        Me.rpgDefault.Text = "Default Look And Feel"
        '
        'aboutRP
        '
        Me.aboutRP.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.aboutRPG})
        Me.aboutRP.Name = "aboutRP"
        Me.aboutRP.Text = "About"
        '
        'aboutRPG
        '
        Me.aboutRPG.ItemLinks.Add(Me.aboutBI)
        Me.aboutRPG.Name = "aboutRPG"
        Me.aboutRPG.Text = "About Us"
        '
        'myXtraTabbedMdiManager
        '
        Me.myXtraTabbedMdiManager.MdiParent = Me
        '
        'mainNavBar
        '
        Me.mainNavBar.ActiveGroup = Me.NavBarGroup1
        Me.mainNavBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.mainNavBar.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarGroup1})
        Me.mainNavBar.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.dbConnection, Me.createExamNB, Me.localExamNB, Me.generalPerformanceNB, Me.subjectPerformanceNB, Me.licenseNB})
        Me.mainNavBar.Location = New System.Drawing.Point(0, 143)
        Me.mainNavBar.Name = "mainNavBar"
        Me.mainNavBar.OptionsNavPane.ExpandedWidth = 164
        Me.mainNavBar.Size = New System.Drawing.Size(164, 301)
        Me.mainNavBar.TabIndex = 2
        Me.mainNavBar.Text = "NavBarControl1"
        '
        'NavBarGroup1
        '
        Me.NavBarGroup1.Caption = "Quick Links"
        Me.NavBarGroup1.Expanded = True
        Me.NavBarGroup1.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.dbConnection), New DevExpress.XtraNavBar.NavBarItemLink(Me.createExamNB), New DevExpress.XtraNavBar.NavBarItemLink(Me.localExamNB), New DevExpress.XtraNavBar.NavBarItemLink(Me.generalPerformanceNB), New DevExpress.XtraNavBar.NavBarItemLink(Me.subjectPerformanceNB), New DevExpress.XtraNavBar.NavBarItemLink(Me.licenseNB)})
        Me.NavBarGroup1.Name = "NavBarGroup1"
        '
        'dbConnection
        '
        Me.dbConnection.Caption = "DB Connection"
        Me.dbConnection.Name = "dbConnection"
        Me.dbConnection.SmallImage = CType(resources.GetObject("dbConnection.SmallImage"), System.Drawing.Image)
        '
        'createExamNB
        '
        Me.createExamNB.Caption = "Create Examination"
        Me.createExamNB.Name = "createExamNB"
        Me.createExamNB.SmallImage = CType(resources.GetObject("createExamNB.SmallImage"), System.Drawing.Image)
        '
        'localExamNB
        '
        Me.localExamNB.Caption = "Local Examination"
        Me.localExamNB.Name = "localExamNB"
        Me.localExamNB.SmallImage = CType(resources.GetObject("localExamNB.SmallImage"), System.Drawing.Image)
        '
        'generalPerformanceNB
        '
        Me.generalPerformanceNB.Caption = "General Performance"
        Me.generalPerformanceNB.LargeImage = CType(resources.GetObject("generalPerformanceNB.LargeImage"), System.Drawing.Image)
        Me.generalPerformanceNB.Name = "generalPerformanceNB"
        Me.generalPerformanceNB.SmallImage = CType(resources.GetObject("generalPerformanceNB.SmallImage"), System.Drawing.Image)
        '
        'subjectPerformanceNB
        '
        Me.subjectPerformanceNB.Caption = "Subject Performance"
        Me.subjectPerformanceNB.Name = "subjectPerformanceNB"
        Me.subjectPerformanceNB.SmallImage = CType(resources.GetObject("subjectPerformanceNB.SmallImage"), System.Drawing.Image)
        '
        'SplashScreenManager2
        '
        Me.SplashScreenManager2.ClosingDelay = 500
        '
        'licenseNB
        '
        Me.licenseNB.Caption = "License"
        Me.licenseNB.Name = "licenseNB"
        Me.licenseNB.SmallImage = CType(resources.GetObject("licenseNB.SmallImage"), System.Drawing.Image)
        '
        'frmMainForm
        '
        Me.AllowFormGlass = DevExpress.Utils.DefaultBoolean.[False]
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 444)
        Me.Controls.Add(Me.mainNavBar)
        Me.Controls.Add(Me.mainRibbon)
        Me.IsMdiContainer = True
        Me.Name = "frmMainForm"
        Me.Ribbon = Me.mainRibbon
        Me.Text = "Akademico Exams"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.mainRibbon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myXtraTabbedMdiManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mainNavBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents mainRibbon As DevExpress.XtraBars.Ribbon.RibbonControl
    Private configurationsMenu As DevExpress.XtraBars.Ribbon.RibbonPage
    Private rpgPerformanceComments As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents performanceCommentsBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents myXtraTabbedMdiManager As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents mainNavBar As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarGroup1 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents myDefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents principalCommentBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgPrinciapalsComments As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents classBasedBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents gradingMenu As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgClassBased As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents subjectBasedBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgSubjectBasedGrading As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents createExamBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents examinationsMenu As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgCreateExam As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents editExamBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgEditExam As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents localExaminationBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents performanceEntryMenu As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgLocalExamination As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents studentProfileBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents resultAnalysisMenu As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgStudentProfile As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents performanceIndexBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgPerformanceIndex As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents subjectPerformanceIndexBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgSubjectPerformanceIndex As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents generalPerformanceBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgGeneralPerformance As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents studentPerformanceBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgStudentPerformance As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents subjectPerformanceBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgSubjectPerformance As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgReportConfiguration As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents reportFormConfigurationFormBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents meritListConfigBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgMeritConfig As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents dbConnection As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents splitSubjectBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents subjectsMenu As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents splitSubjectRpg As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents editSplitBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents subjectTakenBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgSubjectTaken As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents assignIndexNoBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgAssignIndexNo As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents createNationalExamBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgCreateNationalExam As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents editNationalExamBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents deleteNationalExamBI As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgEnterNationalExam As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents enterNationExams As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SkinRibbonGalleryBarItem1 As DevExpress.XtraBars.SkinRibbonGalleryBarItem
    Friend WithEvents applicationFontBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents defaultBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgChangeLook As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgTheme As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgApplicationFont As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgDefault As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents systemUsersBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rightsBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgUsers As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgSystemUsers As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgRights As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents SplashScreenManager2 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents createExamNB As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents localExamNB As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents generalPerformanceNB As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents subjectPerformanceNB As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents classSubjectBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgClassSubjects As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents showSubjectsBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgSubjectsTaken As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents markSheetBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgMarkSheet As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents addSubjectsBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgAddSubject As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents editSubjectBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents deleteSubjectBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents aboutBI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents aboutRP As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents aboutRPG As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents licenseNB As DevExpress.XtraNavBar.NavBarItem
End Class
