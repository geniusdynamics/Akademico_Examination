using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace exams
{
    public partial class frmMainForm
    {
        /// <summary>
    /// Required designer variable.
    /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components is object)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            mainRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            _performanceCommentsBI = new DevExpress.XtraBars.BarButtonItem();
            _performanceCommentsBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(performanceCommentsBI_ItemClick);
            _principalCommentBI = new DevExpress.XtraBars.BarButtonItem();
            _principalCommentBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(principalCommentBI_ItemClick);
            _classBasedBI = new DevExpress.XtraBars.BarButtonItem();
            _classBasedBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(classBasedBI_ItemClick);
            _subjectBasedBI = new DevExpress.XtraBars.BarButtonItem();
            _subjectBasedBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(subjectBasedBI_ItemClick);
            _createExamBI = new DevExpress.XtraBars.BarButtonItem();
            _createExamBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(createExamBI_ItemClick);
            _editExamBI = new DevExpress.XtraBars.BarButtonItem();
            _editExamBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(editExamBI_ItemClick);
            _localExaminationBI = new DevExpress.XtraBars.BarButtonItem();
            _localExaminationBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(localExaminationBI_ItemClick);
            _studentProfileBI = new DevExpress.XtraBars.BarButtonItem();
            _studentProfileBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(studentProfileBI_ItemClick);
            _performanceIndexBI = new DevExpress.XtraBars.BarButtonItem();
            _performanceIndexBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(performanceIndexBI_ItemClick);
            _subjectPerformanceIndexBI = new DevExpress.XtraBars.BarButtonItem();
            _subjectPerformanceIndexBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(subjectPerformanceIndexBI_ItemClick);
            _generalPerformanceBI = new DevExpress.XtraBars.BarButtonItem();
            _generalPerformanceBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(generalPerformanceBI_ItemClick);
            _studentPerformanceBI = new DevExpress.XtraBars.BarButtonItem();
            _studentPerformanceBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(studentPerformanceBI_ItemClick);
            _subjectPerformanceBI = new DevExpress.XtraBars.BarButtonItem();
            _subjectPerformanceBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(subjectPerformanceBI_ItemClick);
            _reportFormConfigurationFormBI = new DevExpress.XtraBars.BarButtonItem();
            _reportFormConfigurationFormBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(reportFormConfigurationFormBI_ItemClick);
            _meritListConfigBI = new DevExpress.XtraBars.BarButtonItem();
            _meritListConfigBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(meritListConfigBI_ItemClick);
            _splitSubjectBI = new DevExpress.XtraBars.BarButtonItem();
            _splitSubjectBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(splitSubjectBI_ItemClick);
            _editSplitBI = new DevExpress.XtraBars.BarButtonItem();
            _editSplitBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(editSplitBI_ItemClick);
            _subjectTakenBI = new DevExpress.XtraBars.BarButtonItem();
            _subjectTakenBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(subjectTakenBI_ItemClick);
            _assignIndexNoBI = new DevExpress.XtraBars.BarButtonItem();
            _assignIndexNoBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(assignIndexNoBI_ItemClick);
            _createNationalExamBI = new DevExpress.XtraBars.BarButtonItem();
            _createNationalExamBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(createNationalExamBI_ItemClick);
            _editNationalExamBI = new DevExpress.XtraBars.BarButtonItem();
            _editNationalExamBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(editNationalExamBI_ItemClick);
            _enterNationExams = new DevExpress.XtraBars.BarButtonItem();
            _enterNationExams.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(enterNationExams_ItemClick);
            SkinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            _applicationFontBI = new DevExpress.XtraBars.BarButtonItem();
            _applicationFontBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(applicationFontBI_ItemClick);
            _defaultBI = new DevExpress.XtraBars.BarButtonItem();
            _defaultBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(defaultBI_ItemClick);
            _systemUsersBI = new DevExpress.XtraBars.BarButtonItem();
            _systemUsersBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(systemUsersBI_ItemClick);
            _rightsBI = new DevExpress.XtraBars.BarButtonItem();
            _rightsBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(rightsBI_ItemClick);
            _classSubjectBI = new DevExpress.XtraBars.BarButtonItem();
            _classSubjectBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(classSubjectBI_ItemClick);
            _showSubjectsBI = new DevExpress.XtraBars.BarButtonItem();
            _showSubjectsBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(showSubjectsBI_ItemClick);
            _markSheetBI = new DevExpress.XtraBars.BarButtonItem();
            _markSheetBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(markSheetBI_ItemClick);
            _addSubjectsBI = new DevExpress.XtraBars.BarButtonItem();
            _addSubjectsBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(addSubjectsBI_ItemClick);
            _editSubjectBI = new DevExpress.XtraBars.BarButtonItem();
            _editSubjectBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(editSubjectBI_ItemClick);
            _deleteSubjectBI = new DevExpress.XtraBars.BarButtonItem();
            _deleteSubjectBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(deleteSubjectBI_ItemClick);
            _aboutBI = new DevExpress.XtraBars.BarButtonItem();
            _aboutBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(aboutBI_ItemClick);
            _performance = new DevExpress.XtraBars.BarButtonItem();
            _performance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(performance_ItemClick);
            configurationsMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgPerformanceComments = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgPrinciapalsComments = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgReportConfiguration = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgMeritConfig = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            subjectsMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgAddSubject = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgClassSubjects = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            splitSubjectRpg = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgSubjectTaken = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgAssignIndexNo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgSubjectsTaken = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            gradingMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgClassBased = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgSubjectBasedGrading = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            examinationsMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgCreateExam = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgEditExam = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgCreateNationalExam = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            deleteNationalExamBI = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            performanceEntryMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgLocalExamination = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgEnterNationalExam = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgMarkSheet = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            resultAnalysisMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgStudentProfile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgPerformanceIndex = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgGeneralPerformance = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgStudentPerformance = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgSubjectPerformance = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgSubjectPerformanceIndex = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RibbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgUsers = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgSystemUsers = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgRights = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgChangeLook = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgTheme = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgApplicationFont = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgDefault = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            aboutRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            aboutRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            myXtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(components);
            mainNavBar = new DevExpress.XtraNavBar.NavBarControl();
            NavBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            _dbConnection = new DevExpress.XtraNavBar.NavBarItem();
            _dbConnection.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(dbConnection_LinkClicked);
            _createExamNB = new DevExpress.XtraNavBar.NavBarItem();
            _createExamNB.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(createExamNB_LinkClicked);
            _localExamNB = new DevExpress.XtraNavBar.NavBarItem();
            _localExamNB.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(localExamNB_LinkClicked);
            _generalPerformanceNB = new DevExpress.XtraNavBar.NavBarItem();
            _generalPerformanceNB.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(generalPerformanceNB_LinkClicked);
            _subjectPerformanceNB = new DevExpress.XtraNavBar.NavBarItem();
            _subjectPerformanceNB.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(subjectPerformanceNB_LinkClicked);
            _licenseNB = new DevExpress.XtraNavBar.NavBarItem();
            _licenseNB.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(licenseNB_LinkClicked);
            myDefaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(components);
            SplashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true, true);
            _newPerformance = new DevExpress.XtraBars.BarButtonItem();
            _newPerformance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(newPerformance_ItemClick);
            ((System.ComponentModel.ISupportInitialize)mainRibbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myXtraTabbedMdiManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainNavBar).BeginInit();
            SuspendLayout();
            // 
            // mainRibbon
            // 
            mainRibbon.ExpandCollapseItem.Id = 0;
            mainRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { mainRibbon.ExpandCollapseItem, _performanceCommentsBI, _principalCommentBI, _classBasedBI, _subjectBasedBI, _createExamBI, _editExamBI, _localExaminationBI, _studentProfileBI, _performanceIndexBI, _subjectPerformanceIndexBI, _generalPerformanceBI, _studentPerformanceBI, _subjectPerformanceBI, _reportFormConfigurationFormBI, _meritListConfigBI, _splitSubjectBI, _editSplitBI, _subjectTakenBI, _assignIndexNoBI, _createNationalExamBI, _editNationalExamBI, _enterNationExams, SkinRibbonGalleryBarItem1, _applicationFontBI, _defaultBI, _systemUsersBI, _rightsBI, _classSubjectBI, _showSubjectsBI, _markSheetBI, _addSubjectsBI, _editSubjectBI, _deleteSubjectBI, _aboutBI, _performance, _newPerformance });
            mainRibbon.Location = new Point(0, 0);
            mainRibbon.MaxItemId = 37;
            mainRibbon.Name = "mainRibbon";
            mainRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { configurationsMenu, subjectsMenu, gradingMenu, examinationsMenu, performanceEntryMenu, resultAnalysisMenu, rpgUsers, rpgChangeLook, aboutRP });
            mainRibbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            mainRibbon.Size = new Size(979, 143);
            // 
            // performanceCommentsBI
            // 
            _performanceCommentsBI.Caption = "Performance Comments";
            _performanceCommentsBI.Id = 1;
            _performanceCommentsBI.ImageOptions.Image = (Image)resources.GetObject("performanceCommentsBI.ImageOptions.Image");
            _performanceCommentsBI.ImageOptions.LargeImage = (Image)resources.GetObject("performanceCommentsBI.ImageOptions.LargeImage");
            _performanceCommentsBI.Name = "_performanceCommentsBI";
            // 
            // principalCommentBI
            // 
            _principalCommentBI.Caption = "Prinicipal Comments";
            _principalCommentBI.Id = 2;
            _principalCommentBI.ImageOptions.Image = (Image)resources.GetObject("principalCommentBI.ImageOptions.Image");
            _principalCommentBI.ImageOptions.LargeImage = (Image)resources.GetObject("principalCommentBI.ImageOptions.LargeImage");
            _principalCommentBI.Name = "_principalCommentBI";
            // 
            // classBasedBI
            // 
            _classBasedBI.Caption = "Class Based Grading Scheme";
            _classBasedBI.Id = 3;
            _classBasedBI.ImageOptions.Image = (Image)resources.GetObject("classBasedBI.ImageOptions.Image");
            _classBasedBI.ImageOptions.LargeImage = (Image)resources.GetObject("classBasedBI.ImageOptions.LargeImage");
            _classBasedBI.Name = "_classBasedBI";
            // 
            // subjectBasedBI
            // 
            _subjectBasedBI.Caption = "Subject Based Grading";
            _subjectBasedBI.Id = 4;
            _subjectBasedBI.ImageOptions.Image = (Image)resources.GetObject("subjectBasedBI.ImageOptions.Image");
            _subjectBasedBI.ImageOptions.LargeImage = (Image)resources.GetObject("subjectBasedBI.ImageOptions.LargeImage");
            _subjectBasedBI.Name = "_subjectBasedBI";
            // 
            // createExamBI
            // 
            _createExamBI.Caption = "Create Exam";
            _createExamBI.Id = 5;
            _createExamBI.ImageOptions.LargeImage = (Image)resources.GetObject("createExamBI.ImageOptions.LargeImage");
            _createExamBI.Name = "_createExamBI";
            // 
            // editExamBI
            // 
            _editExamBI.Caption = "Edit Exam";
            _editExamBI.Id = 6;
            _editExamBI.ImageOptions.Image = (Image)resources.GetObject("editExamBI.ImageOptions.Image");
            _editExamBI.ImageOptions.LargeImage = (Image)resources.GetObject("editExamBI.ImageOptions.LargeImage");
            _editExamBI.Name = "_editExamBI";
            // 
            // localExaminationBI
            // 
            _localExaminationBI.Caption = "Local Examination";
            _localExaminationBI.Id = 7;
            _localExaminationBI.ImageOptions.Image = (Image)resources.GetObject("localExaminationBI.ImageOptions.Image");
            _localExaminationBI.ImageOptions.LargeImage = (Image)resources.GetObject("localExaminationBI.ImageOptions.LargeImage");
            _localExaminationBI.Name = "_localExaminationBI";
            // 
            // studentProfileBI
            // 
            _studentProfileBI.Caption = "Student Performance Profile";
            _studentProfileBI.Id = 8;
            _studentProfileBI.ImageOptions.Image = (Image)resources.GetObject("studentProfileBI.ImageOptions.Image");
            _studentProfileBI.ImageOptions.LargeImage = (Image)resources.GetObject("studentProfileBI.ImageOptions.LargeImage");
            _studentProfileBI.Name = "_studentProfileBI";
            // 
            // performanceIndexBI
            // 
            _performanceIndexBI.Caption = "Student Performance Index";
            _performanceIndexBI.Id = 9;
            _performanceIndexBI.ImageOptions.Image = (Image)resources.GetObject("performanceIndexBI.ImageOptions.Image");
            _performanceIndexBI.ImageOptions.LargeImage = (Image)resources.GetObject("performanceIndexBI.ImageOptions.LargeImage");
            _performanceIndexBI.Name = "_performanceIndexBI";
            // 
            // subjectPerformanceIndexBI
            // 
            _subjectPerformanceIndexBI.Caption = "Subject Performance Index";
            _subjectPerformanceIndexBI.Id = 10;
            _subjectPerformanceIndexBI.ImageOptions.Image = (Image)resources.GetObject("subjectPerformanceIndexBI.ImageOptions.Image");
            _subjectPerformanceIndexBI.ImageOptions.LargeImage = (Image)resources.GetObject("subjectPerformanceIndexBI.ImageOptions.LargeImage");
            _subjectPerformanceIndexBI.Name = "_subjectPerformanceIndexBI";
            // 
            // generalPerformanceBI
            // 
            _generalPerformanceBI.Caption = "General Performance";
            _generalPerformanceBI.Id = 11;
            _generalPerformanceBI.ImageOptions.Image = (Image)resources.GetObject("generalPerformanceBI.ImageOptions.Image");
            _generalPerformanceBI.ImageOptions.LargeImage = (Image)resources.GetObject("generalPerformanceBI.ImageOptions.LargeImage");
            _generalPerformanceBI.Name = "_generalPerformanceBI";
            // 
            // studentPerformanceBI
            // 
            _studentPerformanceBI.Caption = "Student Performance";
            _studentPerformanceBI.Id = 12;
            _studentPerformanceBI.ImageOptions.Image = (Image)resources.GetObject("studentPerformanceBI.ImageOptions.Image");
            _studentPerformanceBI.ImageOptions.LargeImage = (Image)resources.GetObject("studentPerformanceBI.ImageOptions.LargeImage");
            _studentPerformanceBI.Name = "_studentPerformanceBI";
            // 
            // subjectPerformanceBI
            // 
            _subjectPerformanceBI.Caption = "Subject Performance";
            _subjectPerformanceBI.Id = 13;
            _subjectPerformanceBI.ImageOptions.Image = (Image)resources.GetObject("subjectPerformanceBI.ImageOptions.Image");
            _subjectPerformanceBI.ImageOptions.LargeImage = (Image)resources.GetObject("subjectPerformanceBI.ImageOptions.LargeImage");
            _subjectPerformanceBI.Name = "_subjectPerformanceBI";
            // 
            // reportFormConfigurationFormBI
            // 
            _reportFormConfigurationFormBI.Caption = "Report Form Configurations";
            _reportFormConfigurationFormBI.Id = 14;
            _reportFormConfigurationFormBI.ImageOptions.Image = (Image)resources.GetObject("reportFormConfigurationFormBI.ImageOptions.Image");
            _reportFormConfigurationFormBI.ImageOptions.LargeImage = (Image)resources.GetObject("reportFormConfigurationFormBI.ImageOptions.LargeImage");
            _reportFormConfigurationFormBI.Name = "_reportFormConfigurationFormBI";
            // 
            // meritListConfigBI
            // 
            _meritListConfigBI.Caption = "Merit List Configurations";
            _meritListConfigBI.Id = 15;
            _meritListConfigBI.ImageOptions.Image = (Image)resources.GetObject("meritListConfigBI.ImageOptions.Image");
            _meritListConfigBI.ImageOptions.LargeImage = (Image)resources.GetObject("meritListConfigBI.ImageOptions.LargeImage");
            _meritListConfigBI.Name = "_meritListConfigBI";
            // 
            // splitSubjectBI
            // 
            _splitSubjectBI.Caption = "Add Split Subject";
            _splitSubjectBI.Id = 16;
            _splitSubjectBI.ImageOptions.Image = (Image)resources.GetObject("splitSubjectBI.ImageOptions.Image");
            _splitSubjectBI.ImageOptions.LargeImage = (Image)resources.GetObject("splitSubjectBI.ImageOptions.LargeImage");
            _splitSubjectBI.Name = "_splitSubjectBI";
            // 
            // editSplitBI
            // 
            _editSplitBI.Caption = "Edit Split Subject";
            _editSplitBI.Id = 17;
            _editSplitBI.ImageOptions.Image = (Image)resources.GetObject("editSplitBI.ImageOptions.Image");
            _editSplitBI.ImageOptions.LargeImage = (Image)resources.GetObject("editSplitBI.ImageOptions.LargeImage");
            _editSplitBI.Name = "_editSplitBI";
            // 
            // subjectTakenBI
            // 
            _subjectTakenBI.Caption = "Assign Subject Taken";
            _subjectTakenBI.Id = 18;
            _subjectTakenBI.ImageOptions.Image = (Image)resources.GetObject("subjectTakenBI.ImageOptions.Image");
            _subjectTakenBI.ImageOptions.LargeImage = (Image)resources.GetObject("subjectTakenBI.ImageOptions.LargeImage");
            _subjectTakenBI.Name = "_subjectTakenBI";
            // 
            // assignIndexNoBI
            // 
            _assignIndexNoBI.Caption = "Assign Index Number";
            _assignIndexNoBI.Id = 19;
            _assignIndexNoBI.ImageOptions.Image = (Image)resources.GetObject("assignIndexNoBI.ImageOptions.Image");
            _assignIndexNoBI.ImageOptions.LargeImage = (Image)resources.GetObject("assignIndexNoBI.ImageOptions.LargeImage");
            _assignIndexNoBI.Name = "_assignIndexNoBI";
            // 
            // createNationalExamBI
            // 
            _createNationalExamBI.Caption = "Create National Exam";
            _createNationalExamBI.Id = 20;
            _createNationalExamBI.ImageOptions.Image = (Image)resources.GetObject("createNationalExamBI.ImageOptions.Image");
            _createNationalExamBI.ImageOptions.LargeImage = (Image)resources.GetObject("createNationalExamBI.ImageOptions.LargeImage");
            _createNationalExamBI.Name = "_createNationalExamBI";
            // 
            // editNationalExamBI
            // 
            _editNationalExamBI.Caption = "Edit National Exam";
            _editNationalExamBI.Id = 21;
            _editNationalExamBI.ImageOptions.Image = (Image)resources.GetObject("editNationalExamBI.ImageOptions.Image");
            _editNationalExamBI.ImageOptions.LargeImage = (Image)resources.GetObject("editNationalExamBI.ImageOptions.LargeImage");
            _editNationalExamBI.Name = "_editNationalExamBI";
            // 
            // enterNationExams
            // 
            _enterNationExams.Caption = "National Examination";
            _enterNationExams.Id = 22;
            _enterNationExams.ImageOptions.Image = (Image)resources.GetObject("enterNationExams.ImageOptions.Image");
            _enterNationExams.ImageOptions.LargeImage = (Image)resources.GetObject("enterNationExams.ImageOptions.LargeImage");
            _enterNationExams.Name = "_enterNationExams";
            // 
            // SkinRibbonGalleryBarItem1
            // 
            SkinRibbonGalleryBarItem1.Caption = "SkinRibbonGalleryBarItem1";
            SkinRibbonGalleryBarItem1.Id = 23;
            SkinRibbonGalleryBarItem1.Name = "SkinRibbonGalleryBarItem1";
            // 
            // applicationFontBI
            // 
            _applicationFontBI.Caption = "Application Font";
            _applicationFontBI.Id = 24;
            _applicationFontBI.ImageOptions.Image = (Image)resources.GetObject("applicationFontBI.ImageOptions.Image");
            _applicationFontBI.ImageOptions.LargeImage = (Image)resources.GetObject("applicationFontBI.ImageOptions.LargeImage");
            _applicationFontBI.Name = "_applicationFontBI";
            // 
            // defaultBI
            // 
            _defaultBI.Caption = "Restore Default Look And Feel";
            _defaultBI.Id = 25;
            _defaultBI.ImageOptions.Image = (Image)resources.GetObject("defaultBI.ImageOptions.Image");
            _defaultBI.ImageOptions.LargeImage = (Image)resources.GetObject("defaultBI.ImageOptions.LargeImage");
            _defaultBI.Name = "_defaultBI";
            // 
            // systemUsersBI
            // 
            _systemUsersBI.Caption = "System Users";
            _systemUsersBI.Id = 26;
            _systemUsersBI.ImageOptions.Image = (Image)resources.GetObject("systemUsersBI.ImageOptions.Image");
            _systemUsersBI.ImageOptions.LargeImage = (Image)resources.GetObject("systemUsersBI.ImageOptions.LargeImage");
            _systemUsersBI.Name = "_systemUsersBI";
            // 
            // rightsBI
            // 
            _rightsBI.Caption = "User Rights And Priviledges";
            _rightsBI.Id = 27;
            _rightsBI.ImageOptions.Image = (Image)resources.GetObject("rightsBI.ImageOptions.Image");
            _rightsBI.ImageOptions.LargeImage = (Image)resources.GetObject("rightsBI.ImageOptions.LargeImage");
            _rightsBI.Name = "_rightsBI";
            // 
            // classSubjectBI
            // 
            _classSubjectBI.Caption = "Assign Class Subject";
            _classSubjectBI.Id = 28;
            _classSubjectBI.ImageOptions.Image = (Image)resources.GetObject("classSubjectBI.ImageOptions.Image");
            _classSubjectBI.ImageOptions.LargeImage = (Image)resources.GetObject("classSubjectBI.ImageOptions.LargeImage");
            _classSubjectBI.Name = "_classSubjectBI";
            // 
            // showSubjectsBI
            // 
            _showSubjectsBI.Caption = "Student Subjects Taken";
            _showSubjectsBI.Id = 29;
            _showSubjectsBI.ImageOptions.Image = (Image)resources.GetObject("showSubjectsBI.ImageOptions.Image");
            _showSubjectsBI.ImageOptions.LargeImage = (Image)resources.GetObject("showSubjectsBI.ImageOptions.LargeImage");
            _showSubjectsBI.Name = "_showSubjectsBI";
            // 
            // markSheetBI
            // 
            _markSheetBI.Caption = "Mark Sheet";
            _markSheetBI.Id = 30;
            _markSheetBI.ImageOptions.Image = (Image)resources.GetObject("markSheetBI.ImageOptions.Image");
            _markSheetBI.ImageOptions.LargeImage = (Image)resources.GetObject("markSheetBI.ImageOptions.LargeImage");
            _markSheetBI.Name = "_markSheetBI";
            // 
            // addSubjectsBI
            // 
            _addSubjectsBI.Caption = "Add Subjects";
            _addSubjectsBI.Id = 31;
            _addSubjectsBI.ImageOptions.Image = (Image)resources.GetObject("addSubjectsBI.ImageOptions.Image");
            _addSubjectsBI.ImageOptions.LargeImage = (Image)resources.GetObject("addSubjectsBI.ImageOptions.LargeImage");
            _addSubjectsBI.Name = "_addSubjectsBI";
            // 
            // editSubjectBI
            // 
            _editSubjectBI.Caption = "Edit Subject";
            _editSubjectBI.Id = 32;
            _editSubjectBI.ImageOptions.Image = (Image)resources.GetObject("editSubjectBI.ImageOptions.Image");
            _editSubjectBI.ImageOptions.LargeImage = (Image)resources.GetObject("editSubjectBI.ImageOptions.LargeImage");
            _editSubjectBI.Name = "_editSubjectBI";
            // 
            // deleteSubjectBI
            // 
            _deleteSubjectBI.Caption = "Delete Subject";
            _deleteSubjectBI.Id = 33;
            _deleteSubjectBI.ImageOptions.Image = (Image)resources.GetObject("deleteSubjectBI.ImageOptions.Image");
            _deleteSubjectBI.ImageOptions.LargeImage = (Image)resources.GetObject("deleteSubjectBI.ImageOptions.LargeImage");
            _deleteSubjectBI.Name = "_deleteSubjectBI";
            // 
            // aboutBI
            // 
            _aboutBI.Caption = "About Us";
            _aboutBI.Id = 34;
            _aboutBI.ImageOptions.Image = (Image)resources.GetObject("aboutBI.ImageOptions.Image");
            _aboutBI.ImageOptions.LargeImage = (Image)resources.GetObject("aboutBI.ImageOptions.LargeImage");
            _aboutBI.Name = "_aboutBI";
            // 
            // performance
            // 
            _performance.Caption = "Mean Performance";
            _performance.Id = 35;
            _performance.ImageOptions.Image = (Image)resources.GetObject("performance.ImageOptions.Image");
            _performance.Name = "_performance";
            // 
            // configurationsMenu
            // 
            configurationsMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgPerformanceComments, rpgPrinciapalsComments, rpgReportConfiguration, rpgMeritConfig });
            configurationsMenu.Name = "configurationsMenu";
            configurationsMenu.Text = "Configurations";
            // 
            // rpgPerformanceComments
            // 
            rpgPerformanceComments.ItemLinks.Add(_performanceCommentsBI);
            rpgPerformanceComments.Name = "rpgPerformanceComments";
            rpgPerformanceComments.Text = "Performance Comments";
            // 
            // rpgPrinciapalsComments
            // 
            rpgPrinciapalsComments.ItemLinks.Add(_principalCommentBI);
            rpgPrinciapalsComments.Name = "rpgPrinciapalsComments";
            rpgPrinciapalsComments.Text = "Principal Comments";
            // 
            // rpgReportConfiguration
            // 
            rpgReportConfiguration.ItemLinks.Add(_reportFormConfigurationFormBI);
            rpgReportConfiguration.Name = "rpgReportConfiguration";
            rpgReportConfiguration.Text = "Report Form Configurations";
            // 
            // rpgMeritConfig
            // 
            rpgMeritConfig.ItemLinks.Add(_meritListConfigBI);
            rpgMeritConfig.Name = "rpgMeritConfig";
            rpgMeritConfig.Text = "Merit List Configurations";
            // 
            // subjectsMenu
            // 
            subjectsMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgAddSubject, rpgClassSubjects, splitSubjectRpg, rpgSubjectTaken, rpgAssignIndexNo, rpgSubjectsTaken });
            subjectsMenu.Name = "subjectsMenu";
            subjectsMenu.Text = "Subjects";
            // 
            // rpgAddSubject
            // 
            rpgAddSubject.ItemLinks.Add(_addSubjectsBI);
            rpgAddSubject.ItemLinks.Add(_editSubjectBI);
            rpgAddSubject.ItemLinks.Add(_deleteSubjectBI);
            rpgAddSubject.Name = "rpgAddSubject";
            rpgAddSubject.Text = "Add Subject";
            // 
            // rpgClassSubjects
            // 
            rpgClassSubjects.ItemLinks.Add(_classSubjectBI);
            rpgClassSubjects.Name = "rpgClassSubjects";
            rpgClassSubjects.Text = "Assign Class Subject";
            // 
            // splitSubjectRpg
            // 
            splitSubjectRpg.ItemLinks.Add(_splitSubjectBI);
            splitSubjectRpg.ItemLinks.Add(_editSplitBI);
            splitSubjectRpg.Name = "splitSubjectRpg";
            splitSubjectRpg.Text = "Split Subject";
            // 
            // rpgSubjectTaken
            // 
            rpgSubjectTaken.ItemLinks.Add(_subjectTakenBI);
            rpgSubjectTaken.Name = "rpgSubjectTaken";
            rpgSubjectTaken.Text = "Assingn Subjects Taken";
            // 
            // rpgAssignIndexNo
            // 
            rpgAssignIndexNo.ItemLinks.Add(_assignIndexNoBI);
            rpgAssignIndexNo.Name = "rpgAssignIndexNo";
            rpgAssignIndexNo.Text = "Assign Index Number";
            // 
            // rpgSubjectsTaken
            // 
            rpgSubjectsTaken.ItemLinks.Add(_showSubjectsBI);
            rpgSubjectsTaken.Name = "rpgSubjectsTaken";
            rpgSubjectsTaken.Text = "Student Subjects Taken";
            // 
            // gradingMenu
            // 
            gradingMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgClassBased, rpgSubjectBasedGrading });
            gradingMenu.Name = "gradingMenu";
            gradingMenu.Text = "Grading";
            // 
            // rpgClassBased
            // 
            rpgClassBased.ItemLinks.Add(_classBasedBI);
            rpgClassBased.Name = "rpgClassBased";
            rpgClassBased.Text = "Class Based Grading Scheme";
            // 
            // rpgSubjectBasedGrading
            // 
            rpgSubjectBasedGrading.ItemLinks.Add(_subjectBasedBI);
            rpgSubjectBasedGrading.Name = "rpgSubjectBasedGrading";
            rpgSubjectBasedGrading.Text = "Subject Based Grading";
            // 
            // examinationsMenu
            // 
            examinationsMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgCreateExam, rpgEditExam, rpgCreateNationalExam, deleteNationalExamBI });
            examinationsMenu.Name = "examinationsMenu";
            examinationsMenu.Text = "Examinations";
            // 
            // rpgCreateExam
            // 
            rpgCreateExam.ItemLinks.Add(_createExamBI);
            rpgCreateExam.Name = "rpgCreateExam";
            rpgCreateExam.Text = "Create Exam";
            // 
            // rpgEditExam
            // 
            rpgEditExam.ItemLinks.Add(_editExamBI);
            rpgEditExam.Name = "rpgEditExam";
            rpgEditExam.Text = "Edit Examination";
            // 
            // rpgCreateNationalExam
            // 
            rpgCreateNationalExam.ItemLinks.Add(_createNationalExamBI);
            rpgCreateNationalExam.Name = "rpgCreateNationalExam";
            rpgCreateNationalExam.Text = "Create National Exam";
            // 
            // deleteNationalExamBI
            // 
            deleteNationalExamBI.ItemLinks.Add(_editNationalExamBI);
            deleteNationalExamBI.Name = "deleteNationalExamBI";
            deleteNationalExamBI.Text = "Edit National Exam";
            // 
            // performanceEntryMenu
            // 
            performanceEntryMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgLocalExamination, rpgEnterNationalExam, rpgMarkSheet });
            performanceEntryMenu.Name = "performanceEntryMenu";
            performanceEntryMenu.Text = "Performance Entry";
            // 
            // rpgLocalExamination
            // 
            rpgLocalExamination.ItemLinks.Add(_localExaminationBI);
            rpgLocalExamination.Name = "rpgLocalExamination";
            rpgLocalExamination.Text = "Local Examination";
            // 
            // rpgEnterNationalExam
            // 
            rpgEnterNationalExam.ItemLinks.Add(_enterNationExams);
            rpgEnterNationalExam.Name = "rpgEnterNationalExam";
            rpgEnterNationalExam.Text = "Enter National Examination";
            // 
            // rpgMarkSheet
            // 
            rpgMarkSheet.ItemLinks.Add(_markSheetBI);
            rpgMarkSheet.Name = "rpgMarkSheet";
            rpgMarkSheet.Text = "Mark Sheet";
            // 
            // resultAnalysisMenu
            // 
            resultAnalysisMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgStudentProfile, rpgPerformanceIndex, rpgGeneralPerformance, rpgStudentPerformance, rpgSubjectPerformance, rpgSubjectPerformanceIndex, RibbonPageGroup1 });
            resultAnalysisMenu.Name = "resultAnalysisMenu";
            resultAnalysisMenu.Text = "Result Analysis";
            // 
            // rpgStudentProfile
            // 
            rpgStudentProfile.ItemLinks.Add(_studentProfileBI);
            rpgStudentProfile.Name = "rpgStudentProfile";
            rpgStudentProfile.Text = "Student Performance Profile";
            // 
            // rpgPerformanceIndex
            // 
            rpgPerformanceIndex.ItemLinks.Add(_performanceIndexBI);
            rpgPerformanceIndex.Name = "rpgPerformanceIndex";
            rpgPerformanceIndex.Text = "Student Performance Index";
            // 
            // rpgGeneralPerformance
            // 
            rpgGeneralPerformance.ItemLinks.Add(_generalPerformanceBI);
            rpgGeneralPerformance.Name = "rpgGeneralPerformance";
            rpgGeneralPerformance.Text = "General Performance";
            // 
            // rpgStudentPerformance
            // 
            rpgStudentPerformance.ItemLinks.Add(_studentPerformanceBI);
            rpgStudentPerformance.ItemLinks.Add(_performance);
            rpgStudentPerformance.ItemLinks.Add(_newPerformance);
            rpgStudentPerformance.Name = "rpgStudentPerformance";
            rpgStudentPerformance.Text = "Student Performance";
            // 
            // rpgSubjectPerformance
            // 
            rpgSubjectPerformance.ItemLinks.Add(_subjectPerformanceBI);
            rpgSubjectPerformance.Name = "rpgSubjectPerformance";
            rpgSubjectPerformance.Text = "Subject Performance";
            // 
            // rpgSubjectPerformanceIndex
            // 
            rpgSubjectPerformanceIndex.ItemLinks.Add(_subjectPerformanceIndexBI);
            rpgSubjectPerformanceIndex.Name = "rpgSubjectPerformanceIndex";
            rpgSubjectPerformanceIndex.Text = "Subject Performance Index";
            // 
            // RibbonPageGroup1
            // 
            RibbonPageGroup1.Name = "RibbonPageGroup1";
            RibbonPageGroup1.Text = "RibbonPageGroup1";
            // 
            // rpgUsers
            // 
            rpgUsers.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgSystemUsers, rpgRights });
            rpgUsers.Name = "rpgUsers";
            rpgUsers.Text = "Users";
            // 
            // rpgSystemUsers
            // 
            rpgSystemUsers.ItemLinks.Add(_systemUsersBI);
            rpgSystemUsers.Name = "rpgSystemUsers";
            rpgSystemUsers.Text = "System Users";
            // 
            // rpgRights
            // 
            rpgRights.ItemLinks.Add(_rightsBI);
            rpgRights.Name = "rpgRights";
            rpgRights.Text = "User Rights And Priviledges";
            // 
            // rpgChangeLook
            // 
            rpgChangeLook.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgTheme, rpgApplicationFont, rpgDefault });
            rpgChangeLook.Name = "rpgChangeLook";
            rpgChangeLook.Text = "Change Look";
            // 
            // rpgTheme
            // 
            rpgTheme.ItemLinks.Add(SkinRibbonGalleryBarItem1);
            rpgTheme.Name = "rpgTheme";
            rpgTheme.Text = "Select Theme";
            // 
            // rpgApplicationFont
            // 
            rpgApplicationFont.ItemLinks.Add(_applicationFontBI);
            rpgApplicationFont.Name = "rpgApplicationFont";
            rpgApplicationFont.Text = "Application Font";
            // 
            // rpgDefault
            // 
            rpgDefault.ItemLinks.Add(_defaultBI);
            rpgDefault.Name = "rpgDefault";
            rpgDefault.Text = "Default Look And Feel";
            // 
            // aboutRP
            // 
            aboutRP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { aboutRPG });
            aboutRP.Name = "aboutRP";
            aboutRP.Text = "About";
            // 
            // aboutRPG
            // 
            aboutRPG.ItemLinks.Add(_aboutBI);
            aboutRPG.Name = "aboutRPG";
            aboutRPG.Text = "About Us";
            // 
            // myXtraTabbedMdiManager
            // 
            myXtraTabbedMdiManager.MdiParent = this;
            // 
            // mainNavBar
            // 
            mainNavBar.ActiveGroup = NavBarGroup1;
            mainNavBar.Dock = DockStyle.Left;
            mainNavBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] { NavBarGroup1 });
            mainNavBar.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] { _dbConnection, _createExamNB, _localExamNB, _generalPerformanceNB, _subjectPerformanceNB, _licenseNB });
            mainNavBar.Location = new Point(0, 143);
            mainNavBar.Name = "mainNavBar";
            mainNavBar.OptionsNavPane.ExpandedWidth = 164;
            mainNavBar.Size = new Size(164, 301);
            mainNavBar.TabIndex = 2;
            mainNavBar.Text = "NavBarControl1";
            // 
            // NavBarGroup1
            // 
            NavBarGroup1.Caption = "Quick Links";
            NavBarGroup1.Expanded = true;
            NavBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(_dbConnection), new DevExpress.XtraNavBar.NavBarItemLink(_createExamNB), new DevExpress.XtraNavBar.NavBarItemLink(_localExamNB), new DevExpress.XtraNavBar.NavBarItemLink(_generalPerformanceNB), new DevExpress.XtraNavBar.NavBarItemLink(_subjectPerformanceNB), new DevExpress.XtraNavBar.NavBarItemLink(_licenseNB) });
            NavBarGroup1.Name = "NavBarGroup1";
            // 
            // dbConnection
            // 
            _dbConnection.Caption = "DB Connection";
            _dbConnection.Name = "_dbConnection";
            _dbConnection.SmallImage = (Image)resources.GetObject("dbConnection.SmallImage");
            // 
            // createExamNB
            // 
            _createExamNB.Caption = "Create Examination";
            _createExamNB.Name = "_createExamNB";
            _createExamNB.SmallImage = (Image)resources.GetObject("createExamNB.SmallImage");
            // 
            // localExamNB
            // 
            _localExamNB.Caption = "Local Examination";
            _localExamNB.Name = "_localExamNB";
            _localExamNB.SmallImage = (Image)resources.GetObject("localExamNB.SmallImage");
            // 
            // generalPerformanceNB
            // 
            _generalPerformanceNB.Caption = "General Performance";
            _generalPerformanceNB.LargeImage = (Image)resources.GetObject("generalPerformanceNB.LargeImage");
            _generalPerformanceNB.Name = "_generalPerformanceNB";
            _generalPerformanceNB.SmallImage = (Image)resources.GetObject("generalPerformanceNB.SmallImage");
            // 
            // subjectPerformanceNB
            // 
            _subjectPerformanceNB.Caption = "Subject Performance";
            _subjectPerformanceNB.Name = "_subjectPerformanceNB";
            _subjectPerformanceNB.SmallImage = (Image)resources.GetObject("subjectPerformanceNB.SmallImage");
            // 
            // licenseNB
            // 
            _licenseNB.Caption = "License";
            _licenseNB.Name = "_licenseNB";
            _licenseNB.SmallImage = (Image)resources.GetObject("licenseNB.SmallImage");
            // 
            // SplashScreenManager2
            // 
            SplashScreenManager2.ClosingDelay = 500;
            // 
            // newPerformance
            // 
            _newPerformance.Caption = "New Performance";
            _newPerformance.Id = 36;
            _newPerformance.ImageOptions.Image = (Image)resources.GetObject("newPerformance.ImageOptions.Image");
            _newPerformance.Name = "_newPerformance";
            // 
            // frmMainForm
            // 
            AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 444);
            Controls.Add(mainNavBar);
            Controls.Add(mainRibbon);
            IsMdiContainer = true;
            Name = "frmMainForm";
            Ribbon = mainRibbon;
            Text = "Akademico Exams";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)mainRibbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myXtraTabbedMdiManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)mainNavBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage configurationsMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPerformanceComments;
        private DevExpress.XtraBars.BarButtonItem _performanceCommentsBI;

        internal DevExpress.XtraBars.BarButtonItem performanceCommentsBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _performanceCommentsBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_performanceCommentsBI != null)
                {
                    _performanceCommentsBI.ItemClick -= performanceCommentsBI_ItemClick;
                }

                _performanceCommentsBI = value;
                if (_performanceCommentsBI != null)
                {
                    _performanceCommentsBI.ItemClick += performanceCommentsBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraTabbedMdi.XtraTabbedMdiManager myXtraTabbedMdiManager;
        internal DevExpress.XtraNavBar.NavBarControl mainNavBar;
        internal DevExpress.XtraNavBar.NavBarGroup NavBarGroup1;
        internal DevExpress.LookAndFeel.DefaultLookAndFeel myDefaultLookAndFeel;
        private DevExpress.XtraBars.BarButtonItem _principalCommentBI;

        internal DevExpress.XtraBars.BarButtonItem principalCommentBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _principalCommentBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_principalCommentBI != null)
                {
                    _principalCommentBI.ItemClick -= principalCommentBI_ItemClick;
                }

                _principalCommentBI = value;
                if (_principalCommentBI != null)
                {
                    _principalCommentBI.ItemClick += principalCommentBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPrinciapalsComments;
        private DevExpress.XtraBars.BarButtonItem _classBasedBI;

        internal DevExpress.XtraBars.BarButtonItem classBasedBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _classBasedBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_classBasedBI != null)
                {
                    _classBasedBI.ItemClick -= classBasedBI_ItemClick;
                }

                _classBasedBI = value;
                if (_classBasedBI != null)
                {
                    _classBasedBI.ItemClick += classBasedBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPage gradingMenu;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgClassBased;
        private DevExpress.XtraBars.BarButtonItem _subjectBasedBI;

        internal DevExpress.XtraBars.BarButtonItem subjectBasedBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _subjectBasedBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_subjectBasedBI != null)
                {
                    _subjectBasedBI.ItemClick -= subjectBasedBI_ItemClick;
                }

                _subjectBasedBI = value;
                if (_subjectBasedBI != null)
                {
                    _subjectBasedBI.ItemClick += subjectBasedBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSubjectBasedGrading;
        private DevExpress.XtraBars.BarButtonItem _createExamBI;

        internal DevExpress.XtraBars.BarButtonItem createExamBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _createExamBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_createExamBI != null)
                {
                    _createExamBI.ItemClick -= createExamBI_ItemClick;
                }

                _createExamBI = value;
                if (_createExamBI != null)
                {
                    _createExamBI.ItemClick += createExamBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPage examinationsMenu;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgCreateExam;
        private DevExpress.XtraBars.BarButtonItem _editExamBI;

        internal DevExpress.XtraBars.BarButtonItem editExamBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _editExamBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_editExamBI != null)
                {
                    _editExamBI.ItemClick -= editExamBI_ItemClick;
                }

                _editExamBI = value;
                if (_editExamBI != null)
                {
                    _editExamBI.ItemClick += editExamBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgEditExam;
        private DevExpress.XtraBars.BarButtonItem _localExaminationBI;

        internal DevExpress.XtraBars.BarButtonItem localExaminationBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _localExaminationBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_localExaminationBI != null)
                {
                    _localExaminationBI.ItemClick -= localExaminationBI_ItemClick;
                }

                _localExaminationBI = value;
                if (_localExaminationBI != null)
                {
                    _localExaminationBI.ItemClick += localExaminationBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPage performanceEntryMenu;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgLocalExamination;
        private DevExpress.XtraBars.BarButtonItem _studentProfileBI;

        internal DevExpress.XtraBars.BarButtonItem studentProfileBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _studentProfileBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_studentProfileBI != null)
                {
                    _studentProfileBI.ItemClick -= studentProfileBI_ItemClick;
                }

                _studentProfileBI = value;
                if (_studentProfileBI != null)
                {
                    _studentProfileBI.ItemClick += studentProfileBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPage resultAnalysisMenu;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgStudentProfile;
        private DevExpress.XtraBars.BarButtonItem _performanceIndexBI;

        internal DevExpress.XtraBars.BarButtonItem performanceIndexBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _performanceIndexBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_performanceIndexBI != null)
                {
                    _performanceIndexBI.ItemClick -= performanceIndexBI_ItemClick;
                }

                _performanceIndexBI = value;
                if (_performanceIndexBI != null)
                {
                    _performanceIndexBI.ItemClick += performanceIndexBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPerformanceIndex;
        private DevExpress.XtraBars.BarButtonItem _subjectPerformanceIndexBI;

        internal DevExpress.XtraBars.BarButtonItem subjectPerformanceIndexBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _subjectPerformanceIndexBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_subjectPerformanceIndexBI != null)
                {
                    _subjectPerformanceIndexBI.ItemClick -= subjectPerformanceIndexBI_ItemClick;
                }

                _subjectPerformanceIndexBI = value;
                if (_subjectPerformanceIndexBI != null)
                {
                    _subjectPerformanceIndexBI.ItemClick += subjectPerformanceIndexBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSubjectPerformanceIndex;
        private DevExpress.XtraBars.BarButtonItem _generalPerformanceBI;

        internal DevExpress.XtraBars.BarButtonItem generalPerformanceBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _generalPerformanceBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_generalPerformanceBI != null)
                {
                    _generalPerformanceBI.ItemClick -= generalPerformanceBI_ItemClick;
                }

                _generalPerformanceBI = value;
                if (_generalPerformanceBI != null)
                {
                    _generalPerformanceBI.ItemClick += generalPerformanceBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgGeneralPerformance;
        private DevExpress.XtraBars.BarButtonItem _studentPerformanceBI;

        internal DevExpress.XtraBars.BarButtonItem studentPerformanceBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _studentPerformanceBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_studentPerformanceBI != null)
                {
                    _studentPerformanceBI.ItemClick -= studentPerformanceBI_ItemClick;
                }

                _studentPerformanceBI = value;
                if (_studentPerformanceBI != null)
                {
                    _studentPerformanceBI.ItemClick += studentPerformanceBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgStudentPerformance;
        private DevExpress.XtraBars.BarButtonItem _subjectPerformanceBI;

        internal DevExpress.XtraBars.BarButtonItem subjectPerformanceBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _subjectPerformanceBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_subjectPerformanceBI != null)
                {
                    _subjectPerformanceBI.ItemClick -= subjectPerformanceBI_ItemClick;
                }

                _subjectPerformanceBI = value;
                if (_subjectPerformanceBI != null)
                {
                    _subjectPerformanceBI.ItemClick += subjectPerformanceBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSubjectPerformance;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgReportConfiguration;
        private DevExpress.XtraBars.BarButtonItem _reportFormConfigurationFormBI;

        internal DevExpress.XtraBars.BarButtonItem reportFormConfigurationFormBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _reportFormConfigurationFormBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_reportFormConfigurationFormBI != null)
                {
                    _reportFormConfigurationFormBI.ItemClick -= reportFormConfigurationFormBI_ItemClick;
                }

                _reportFormConfigurationFormBI = value;
                if (_reportFormConfigurationFormBI != null)
                {
                    _reportFormConfigurationFormBI.ItemClick += reportFormConfigurationFormBI_ItemClick;
                }
            }
        }

        private DevExpress.XtraBars.BarButtonItem _meritListConfigBI;

        internal DevExpress.XtraBars.BarButtonItem meritListConfigBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _meritListConfigBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_meritListConfigBI != null)
                {
                    _meritListConfigBI.ItemClick -= meritListConfigBI_ItemClick;
                }

                _meritListConfigBI = value;
                if (_meritListConfigBI != null)
                {
                    _meritListConfigBI.ItemClick += meritListConfigBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgMeritConfig;
        private DevExpress.XtraNavBar.NavBarItem _dbConnection;

        internal DevExpress.XtraNavBar.NavBarItem dbConnection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dbConnection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dbConnection != null)
                {
                    _dbConnection.LinkClicked -= dbConnection_LinkClicked;
                }

                _dbConnection = value;
                if (_dbConnection != null)
                {
                    _dbConnection.LinkClicked += dbConnection_LinkClicked;
                }
            }
        }

        private DevExpress.XtraBars.BarButtonItem _splitSubjectBI;

        internal DevExpress.XtraBars.BarButtonItem splitSubjectBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _splitSubjectBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_splitSubjectBI != null)
                {
                    _splitSubjectBI.ItemClick -= splitSubjectBI_ItemClick;
                }

                _splitSubjectBI = value;
                if (_splitSubjectBI != null)
                {
                    _splitSubjectBI.ItemClick += splitSubjectBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPage subjectsMenu;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup splitSubjectRpg;
        private DevExpress.XtraBars.BarButtonItem _editSplitBI;

        internal DevExpress.XtraBars.BarButtonItem editSplitBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _editSplitBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_editSplitBI != null)
                {
                    _editSplitBI.ItemClick -= editSplitBI_ItemClick;
                }

                _editSplitBI = value;
                if (_editSplitBI != null)
                {
                    _editSplitBI.ItemClick += editSplitBI_ItemClick;
                }
            }
        }

        private DevExpress.XtraBars.BarButtonItem _subjectTakenBI;

        internal DevExpress.XtraBars.BarButtonItem subjectTakenBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _subjectTakenBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_subjectTakenBI != null)
                {
                    _subjectTakenBI.ItemClick -= subjectTakenBI_ItemClick;
                }

                _subjectTakenBI = value;
                if (_subjectTakenBI != null)
                {
                    _subjectTakenBI.ItemClick += subjectTakenBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSubjectTaken;
        private DevExpress.XtraBars.BarButtonItem _assignIndexNoBI;

        internal DevExpress.XtraBars.BarButtonItem assignIndexNoBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _assignIndexNoBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_assignIndexNoBI != null)
                {
                    _assignIndexNoBI.ItemClick -= assignIndexNoBI_ItemClick;
                }

                _assignIndexNoBI = value;
                if (_assignIndexNoBI != null)
                {
                    _assignIndexNoBI.ItemClick += assignIndexNoBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgAssignIndexNo;
        private DevExpress.XtraBars.BarButtonItem _createNationalExamBI;

        internal DevExpress.XtraBars.BarButtonItem createNationalExamBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _createNationalExamBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_createNationalExamBI != null)
                {
                    _createNationalExamBI.ItemClick -= createNationalExamBI_ItemClick;
                }

                _createNationalExamBI = value;
                if (_createNationalExamBI != null)
                {
                    _createNationalExamBI.ItemClick += createNationalExamBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgCreateNationalExam;
        private DevExpress.XtraBars.BarButtonItem _editNationalExamBI;

        internal DevExpress.XtraBars.BarButtonItem editNationalExamBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _editNationalExamBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_editNationalExamBI != null)
                {
                    _editNationalExamBI.ItemClick -= editNationalExamBI_ItemClick;
                }

                _editNationalExamBI = value;
                if (_editNationalExamBI != null)
                {
                    _editNationalExamBI.ItemClick += editNationalExamBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup deleteNationalExamBI;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgEnterNationalExam;
        private DevExpress.XtraBars.BarButtonItem _enterNationExams;

        internal DevExpress.XtraBars.BarButtonItem enterNationExams
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _enterNationExams;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_enterNationExams != null)
                {
                    _enterNationExams.ItemClick -= enterNationExams_ItemClick;
                }

                _enterNationExams = value;
                if (_enterNationExams != null)
                {
                    _enterNationExams.ItemClick += enterNationExams_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.SkinRibbonGalleryBarItem SkinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem _applicationFontBI;

        internal DevExpress.XtraBars.BarButtonItem applicationFontBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _applicationFontBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_applicationFontBI != null)
                {
                    _applicationFontBI.ItemClick -= applicationFontBI_ItemClick;
                }

                _applicationFontBI = value;
                if (_applicationFontBI != null)
                {
                    _applicationFontBI.ItemClick += applicationFontBI_ItemClick;
                }
            }
        }

        private DevExpress.XtraBars.BarButtonItem _defaultBI;

        internal DevExpress.XtraBars.BarButtonItem defaultBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _defaultBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_defaultBI != null)
                {
                    _defaultBI.ItemClick -= defaultBI_ItemClick;
                }

                _defaultBI = value;
                if (_defaultBI != null)
                {
                    _defaultBI.ItemClick += defaultBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPage rpgChangeLook;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTheme;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgApplicationFont;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgDefault;
        private DevExpress.XtraBars.BarButtonItem _systemUsersBI;

        internal DevExpress.XtraBars.BarButtonItem systemUsersBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _systemUsersBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_systemUsersBI != null)
                {
                    _systemUsersBI.ItemClick -= systemUsersBI_ItemClick;
                }

                _systemUsersBI = value;
                if (_systemUsersBI != null)
                {
                    _systemUsersBI.ItemClick += systemUsersBI_ItemClick;
                }
            }
        }

        private DevExpress.XtraBars.BarButtonItem _rightsBI;

        internal DevExpress.XtraBars.BarButtonItem rightsBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rightsBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rightsBI != null)
                {
                    _rightsBI.ItemClick -= rightsBI_ItemClick;
                }

                _rightsBI = value;
                if (_rightsBI != null)
                {
                    _rightsBI.ItemClick += rightsBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPage rpgUsers;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSystemUsers;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgRights;
        internal DevExpress.XtraSplashScreen.SplashScreenManager SplashScreenManager1;
        internal DevExpress.XtraSplashScreen.SplashScreenManager SplashScreenManager2;
        private DevExpress.XtraNavBar.NavBarItem _createExamNB;

        internal DevExpress.XtraNavBar.NavBarItem createExamNB
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _createExamNB;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_createExamNB != null)
                {
                    _createExamNB.LinkClicked -= createExamNB_LinkClicked;
                }

                _createExamNB = value;
                if (_createExamNB != null)
                {
                    _createExamNB.LinkClicked += createExamNB_LinkClicked;
                }
            }
        }

        private DevExpress.XtraNavBar.NavBarItem _localExamNB;

        internal DevExpress.XtraNavBar.NavBarItem localExamNB
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _localExamNB;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_localExamNB != null)
                {
                    _localExamNB.LinkClicked -= localExamNB_LinkClicked;
                }

                _localExamNB = value;
                if (_localExamNB != null)
                {
                    _localExamNB.LinkClicked += localExamNB_LinkClicked;
                }
            }
        }

        private DevExpress.XtraNavBar.NavBarItem _generalPerformanceNB;

        internal DevExpress.XtraNavBar.NavBarItem generalPerformanceNB
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _generalPerformanceNB;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_generalPerformanceNB != null)
                {
                    _generalPerformanceNB.LinkClicked -= generalPerformanceNB_LinkClicked;
                }

                _generalPerformanceNB = value;
                if (_generalPerformanceNB != null)
                {
                    _generalPerformanceNB.LinkClicked += generalPerformanceNB_LinkClicked;
                }
            }
        }

        private DevExpress.XtraNavBar.NavBarItem _subjectPerformanceNB;

        internal DevExpress.XtraNavBar.NavBarItem subjectPerformanceNB
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _subjectPerformanceNB;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_subjectPerformanceNB != null)
                {
                    _subjectPerformanceNB.LinkClicked -= subjectPerformanceNB_LinkClicked;
                }

                _subjectPerformanceNB = value;
                if (_subjectPerformanceNB != null)
                {
                    _subjectPerformanceNB.LinkClicked += subjectPerformanceNB_LinkClicked;
                }
            }
        }

        private DevExpress.XtraBars.BarButtonItem _classSubjectBI;

        internal DevExpress.XtraBars.BarButtonItem classSubjectBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _classSubjectBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_classSubjectBI != null)
                {
                    _classSubjectBI.ItemClick -= classSubjectBI_ItemClick;
                }

                _classSubjectBI = value;
                if (_classSubjectBI != null)
                {
                    _classSubjectBI.ItemClick += classSubjectBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgClassSubjects;
        private DevExpress.XtraBars.BarButtonItem _showSubjectsBI;

        internal DevExpress.XtraBars.BarButtonItem showSubjectsBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _showSubjectsBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_showSubjectsBI != null)
                {
                    _showSubjectsBI.ItemClick -= showSubjectsBI_ItemClick;
                }

                _showSubjectsBI = value;
                if (_showSubjectsBI != null)
                {
                    _showSubjectsBI.ItemClick += showSubjectsBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSubjectsTaken;
        private DevExpress.XtraBars.BarButtonItem _markSheetBI;

        internal DevExpress.XtraBars.BarButtonItem markSheetBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _markSheetBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_markSheetBI != null)
                {
                    _markSheetBI.ItemClick -= markSheetBI_ItemClick;
                }

                _markSheetBI = value;
                if (_markSheetBI != null)
                {
                    _markSheetBI.ItemClick += markSheetBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgMarkSheet;
        private DevExpress.XtraBars.BarButtonItem _addSubjectsBI;

        internal DevExpress.XtraBars.BarButtonItem addSubjectsBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _addSubjectsBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_addSubjectsBI != null)
                {
                    _addSubjectsBI.ItemClick -= addSubjectsBI_ItemClick;
                }

                _addSubjectsBI = value;
                if (_addSubjectsBI != null)
                {
                    _addSubjectsBI.ItemClick += addSubjectsBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgAddSubject;
        private DevExpress.XtraBars.BarButtonItem _editSubjectBI;

        internal DevExpress.XtraBars.BarButtonItem editSubjectBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _editSubjectBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_editSubjectBI != null)
                {
                    _editSubjectBI.ItemClick -= editSubjectBI_ItemClick;
                }

                _editSubjectBI = value;
                if (_editSubjectBI != null)
                {
                    _editSubjectBI.ItemClick += editSubjectBI_ItemClick;
                }
            }
        }

        private DevExpress.XtraBars.BarButtonItem _deleteSubjectBI;

        internal DevExpress.XtraBars.BarButtonItem deleteSubjectBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _deleteSubjectBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_deleteSubjectBI != null)
                {
                    _deleteSubjectBI.ItemClick -= deleteSubjectBI_ItemClick;
                }

                _deleteSubjectBI = value;
                if (_deleteSubjectBI != null)
                {
                    _deleteSubjectBI.ItemClick += deleteSubjectBI_ItemClick;
                }
            }
        }

        private DevExpress.XtraBars.BarButtonItem _aboutBI;

        internal DevExpress.XtraBars.BarButtonItem aboutBI
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _aboutBI;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_aboutBI != null)
                {
                    _aboutBI.ItemClick -= aboutBI_ItemClick;
                }

                _aboutBI = value;
                if (_aboutBI != null)
                {
                    _aboutBI.ItemClick += aboutBI_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPage aboutRP;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup aboutRPG;
        private DevExpress.XtraNavBar.NavBarItem _licenseNB;

        internal DevExpress.XtraNavBar.NavBarItem licenseNB
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _licenseNB;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_licenseNB != null)
                {
                    _licenseNB.LinkClicked -= licenseNB_LinkClicked;
                }

                _licenseNB = value;
                if (_licenseNB != null)
                {
                    _licenseNB.LinkClicked += licenseNB_LinkClicked;
                }
            }
        }

        private DevExpress.XtraBars.BarButtonItem _performance;

        internal DevExpress.XtraBars.BarButtonItem performance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _performance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_performance != null)
                {
                    _performance.ItemClick -= performance_ItemClick;
                }

                _performance = value;
                if (_performance != null)
                {
                    _performance.ItemClick += performance_ItemClick;
                }
            }
        }

        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem _newPerformance;

        internal DevExpress.XtraBars.BarButtonItem newPerformance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _newPerformance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_newPerformance != null)
                {
                    _newPerformance.ItemClick -= newPerformance_ItemClick;
                }

                _newPerformance = value;
                if (_newPerformance != null)
                {
                    _newPerformance.ItemClick += newPerformance_ItemClick;
                }
            }
        }
    }
}