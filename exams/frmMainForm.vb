Imports DevExpress.LookAndFeel
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraBars
Imports DevExpress.XtraSplashScreen
Imports System.Threading
Imports System.IO
Imports exams.MySql.Data.MySqlClient
Imports System.Data.SqlClient

Partial Public Class frmMainForm
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm
    Shared Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.Skins.SkinManager.EnableMdiFormSkins()

        UserLookAndFeel.Default.SkinName = My.Settings.selectedTheme
        DevExpress.Utils.AppearanceObject.DefaultFont = New Font(My.Settings.userFont, My.Settings.fontSize)

    End Sub
    Public Sub New()
        InitializeComponent()
        myDefaultLookAndFeel.LookAndFeel.SetSkinStyle(My.Settings.selectedTheme)
    End Sub

    Private Sub performanceCommentsBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles performanceCommentsBI.ItemClick
        Dim performanceCommentsForm = New frmPerformanceComments
        performanceCommentsForm.ShowDialog()
    End Sub

    Private Sub principalCommentBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles principalCommentBI.ItemClick
        Dim headTeacherCommentForm = New frmHeadTeacherComments
        headTeacherCommentForm.ShowDialog()
    End Sub

    Private Sub classBasedBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles classBasedBI.ItemClick
        Dim classBasedForm = New frmClassBasedGrading
        classBasedForm.Text = "Class Based Grading"
        classBasedForm.MdiParent = Me
        classBasedForm.Show()
    End Sub

    Private Sub subjectBasedBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles subjectBasedBI.ItemClick
        Dim subjectBasedForm = New frmSubjectBasedGrading
        subjectBasedForm.MdiParent = Me
        subjectBasedForm.Show()
    End Sub

    Private Sub createExamBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles createExamBI.ItemClick
        Dim createExamForm = New frmCreateExam
        createExamForm.ShowDialog()
    End Sub

    Private Sub editExamBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles editExamBI.ItemClick
        Dim editExamForm = New frmEditDeleteExam
        editExamForm.ShowDialog()
    End Sub

    Private Sub localExaminationBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles localExaminationBI.ItemClick
        Dim enterMarksForm = New frmEnterMarks
        enterMarksForm.MdiParent = Me
        enterMarksForm.Show()
    End Sub

    Private Sub studentProfileBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles studentProfileBI.ItemClick
        Dim studentPerformanceProfile = New frmStudentProfile
        studentPerformanceProfile.MdiParent = Me
        studentPerformanceProfile.Show()
    End Sub

    Private Sub performanceIndexBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles performanceIndexBI.ItemClick
        Dim studentProfileIndex = New frmStudentPerformanceIndex
        studentProfileIndex.ShowDialog()
    End Sub

    Private Sub subjectPerformanceIndexBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles subjectPerformanceIndexBI.ItemClick
        Dim subjectPerformanceIndexForm = New frmSubjectPerformanceIndex
        subjectPerformanceIndexForm.ShowDialog()
    End Sub

    Private Sub studentPerformanceBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles studentPerformanceBI.ItemClick
        Dim studentPerformanceForm = New frmResults
        studentPerformanceForm.MdiParent = Me
        studentPerformanceForm.Show()
    End Sub

    Private Sub subjectPerformanceBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles subjectPerformanceBI.ItemClick
        Dim subjectPerformanceForm = New frmSubjectPerformanceSpecific
        subjectPerformanceForm.ShowDialog()
    End Sub

    Private Sub reportFormConfigurationFormBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles reportFormConfigurationFormBI.ItemClick
        Dim reportFormConfiguration As New frmReportConfiguration
        reportFormConfiguration.ShowDialog()
    End Sub

    Private Sub meritListConfigBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles meritListConfigBI.ItemClick
        Dim meritListForm = New frmMeritListConfig
        meritListForm.ShowDialog()
    End Sub


    Dim accesibleMenu = ""

    Private Sub frmMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each pageGroup As RibbonPage In mainRibbon.Pages
            For Each group As RibbonPageGroup In pageGroup.Groups
                group.AllowTextClipping = False
                group.ShowCaptionButton = False
            Next
        Next

        If Not connect() Then
            frmDBConnection.ShowDialog()
            Return
        End If

        mainRibbon.Enabled = False

        get_school_details()
        get_subjects()
        get_grades()

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)

        For i = 1 To 100
            SplashScreenManager.Default.SetWaitFormDescription(i.ToString() + "%")
            SplashScreenManager.Default.SetWaitFormCaption("Initializing Akademico")

            Thread.Sleep(25)
        Next


        SplashScreenManager.CloseForm(False)



        VerifyL.addLicenseTable()
        VerifyL.AddTimeStamp()

        If VerifyL.verifyTimeStamp() = True Then
            Dim licenseForm As New frmLicense()
            licenseForm.ShowDialog()

            If VerifyL.verifyTimeStamp() = True Then
                Return
            End If
        End If

        If VerifyL.verifyTime() Then
            Return
        End If

        Dim details As String = VerifyL.getSchoolDetails()
        If Not String.IsNullOrEmpty(details) Then
            Me.Text += Convert.ToString(" Is Licensed to ") & details

        End If


        frmLogIn.ShowDialog()

        If myFormVariable = False Then
            Me.Close()
        End If

        If loggedInUser = "Admin1234" Then
            mainRibbon.Enabled = True
            Return
        End If

        accesibleMenu = getMenus(loggedInUser).ToString.ToLower()

        If accesibleMenu.Length <= 0 Then
            success("The User Has Not Been Assigned Any Rights In The System")
            mainRibbon.Enabled = False
            Return
        End If

        mainRibbon.Enabled = True

        For Each pageGroup As RibbonPage In mainRibbon.Pages
            For Each group As RibbonPageGroup In pageGroup.Groups
                Dim button1
                For Each button1 In group.Ribbon.Items
                    If button1.GetType.ToString() = "DevExpress.XtraBars.BarButtonItem" Then
                        Dim button As BarButtonItem = button1
                        If Not accesibleMenu.Contains(button.Caption.ToLower()) Then
                            button.Enabled = False
                        End If
                    End If
                Next
            Next
        Next

        For Each item As NavBarItem In mainNavBar.Items
            If Not accesibleMenu.Contains(item.Caption) And Not item.Caption.ToLower = "db connection" Then
                item.Enabled = False
            End If
        Next

    End Sub

    Private Sub generalPerformanceBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles generalPerformanceBI.ItemClick
        Dim generalPerformance As New frmSubjectPerformanceGeneral
        generalPerformance.ShowDialog()
    End Sub

    Private Sub dbConnection_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles dbConnection.LinkClicked
        frmDBConnection.ShowDialog()
    End Sub

    Private Sub splitSubjectBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles splitSubjectBI.ItemClick
        frmAddSplitSubject.ShowDialog()
    End Sub

    Private Sub editSplitBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles editSplitBI.ItemClick
        frmSplitSubjects.ShowDialog()
    End Sub

    Private Sub subjectTakenBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles subjectTakenBI.ItemClick
        Dim subjectTakenForm = New frmSubjectsDone
        subjectTakenForm.MdiParent = Me
        subjectTakenForm.Show()
    End Sub

    Private Sub assignIndexNoBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles assignIndexNoBI.ItemClick
        Dim indexNumberForm = New frmIndexNumbers
        indexNumberForm.MdiParent = Me
        indexNumberForm.Show()
    End Sub

    Private Sub createNationalExamBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles createNationalExamBI.ItemClick
        frmCreateNationalExam.ShowDialog()
    End Sub

    Private Sub editNationalExamBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles editNationalExamBI.ItemClick
        frmDeleteNationalExam.ShowDialog()
    End Sub

    Private Sub enterNationExams_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles enterNationExams.ItemClick
        Dim nationalExamsForm As New frmNationalExaminationsEntry
        nationalExamsForm.MdiParent = Me
        nationalExamsForm.Show()
    End Sub

    Private Sub applicationFontBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles applicationFontBI.ItemClick
        Dim applicationFont As New FontDialog
        applicationFont.ShowApply = False
        applicationFont.ScriptsOnly = False
        applicationFont.MaxSize = 13
        applicationFont.MinSize = 8
        applicationFont.ShowEffects = False
        applicationFont.FontMustExist = True
        applicationFont.AllowScriptChange = False
        If applicationFont.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.fontSize = applicationFont.Font.Size
            My.Settings.userFont = applicationFont.Font.ToString
            My.Settings.Save()
            MsgBox("Please Close And Launch The Application For The Changes To Reflect")
        End If
    End Sub

    Private Sub defaultBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles defaultBI.ItemClick
        If displayConfirmationMessage("Are You Sure You Want To Restore The Defualt Theme And Font") Then
            My.Settings.fontSize = 10
            My.Settings.userFont = "Segoe UI Symbol"
            My.Settings.selectedTheme = "Caramel"
            changedByUser = True
            My.Settings.Save()
            MsgBox("Please Close And Launch The Application For The Changes To Reflect")
        End If
    End Sub

    Private Sub frmMainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        My.Settings.selectedTheme = myDefaultLookAndFeel.LookAndFeel.ActiveSkinName
        My.Settings.Save()


        Dim directoryPath As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "app_databases")
        If (Directory.Exists(directoryPath)) Then
            Dim files As String() = Directory.GetFiles(directoryPath, "*.sql", SearchOption.AllDirectories)
            If files.Length = 0 Then
                backupDatabase()
            Else
                Dim totalDaysNow As Integer = Date.Now.Year
                Dim totalDaysPrevious As Integer = File.GetCreationTime(files(files.Length - 1)).DayOfYear
                Dim difference As Integer = totalDaysNow - totalDaysPrevious

                If qread("SELECT frequency FROM `db_back_up` LIMIT 1;") Then
                    If dbreader.RecordsAffected > 0 Then
                        dbreader.Read()
                        Dim index As Integer = Convert.ToInt16(dbreader(0).ToString().Substring(0, 1))
                        If (totalDaysNow > (index + totalDaysPrevious)) Then
                            backupDatabase()
                        End If
                    Else
                        If totalDaysNow <> totalDaysPrevious Then
                            backupDatabase()
                        End If
                    End If
                End If
            End If
        Else
            Directory.CreateDirectory(directoryPath)
            backupDatabase()
        End If

    End Sub

    Private Sub backupDatabase()
        Dim conString As String = "server=" + My.Settings.host + ";user=" + My.Settings.userName + ";password=" + My.Settings.passWord + ";database=" + My.Settings.dbName + ";port=" + My.Settings.dPport + ";"

        'Dim conString As String = "server=" + My.Settings.host + ";user=" + My.Settings.userName + ";password=" + My.Settings.passWord + ";database=" + My.Settings.dbName + ";port=" + My.Settings.dbPort + ";convert zero datetime=True"
        Dim filePath As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "app_databases") + "\\" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ".sql"
        Using New DevExpress.Utils.WaitDialogForm("Backing Up Database")
            Try
                Dim conn As SqlConnection = New SqlConnection(conString)
                Dim cmd As SqlCommand = New SqlCommand()
                Dim mb As MySqlBackup = New MySqlBackup(cmd)

                cmd.Connection = conn
                conn.Open()
                mb.ExportInfo.AddCreateDatabase = True
                mb.ExportToFile(filePath)
                conn.Close()
                MessageBox.Show("The Operation Was Successful")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return
            End Try
        End Using

    End Sub

    Private Sub systemUsersBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles systemUsersBI.ItemClick
        Dim userForm As New frmUsers
        userForm.MdiParent = Me
        userForm.Show()
    End Sub

    Private Sub rightsBI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rightsBI.ItemClick
        Dim rightsForm As New frmPriviledges
        rightsForm.MdiParent = Me
        rightsForm.Show()
    End Sub

    Private Sub createExamNB_LinkClicked(sender As Object, e As NavBarLinkEventArgs) Handles createExamNB.LinkClicked
        frmCreateExam.ShowDialog()
    End Sub

    Private Sub localExamNB_LinkClicked(sender As Object, e As NavBarLinkEventArgs) Handles localExamNB.LinkClicked
        Dim enterMarksForm = New frmEnterMarks
        enterMarksForm.MdiParent = Me
        enterMarksForm.Show()
    End Sub

    Private Sub generalPerformanceNB_LinkClicked(sender As Object, e As NavBarLinkEventArgs) Handles generalPerformanceNB.LinkClicked
        frmSubjectPerformanceGeneral.ShowDialog()
    End Sub

    Private Sub subjectPerformanceNB_LinkClicked(sender As Object, e As NavBarLinkEventArgs) Handles subjectPerformanceNB.LinkClicked
        frmSubjectPerformanceSpecific.ShowDialog()
    End Sub

    Private Sub classSubjectBI_ItemClick(sender As Object, e As ItemClickEventArgs) Handles classSubjectBI.ItemClick
        frmClassSubjects.ShowDialog()
    End Sub

    Private Sub showSubjectsBI_ItemClick(sender As Object, e As ItemClickEventArgs) Handles showSubjectsBI.ItemClick
        Dim report As New frmPrintSubjectsTaken()
        report.Text = "Show Subjects Taken"
        report.ShowDialog()

    End Sub

    Private Sub markSheetBI_ItemClick(sender As Object, e As ItemClickEventArgs) Handles markSheetBI.ItemClick
        Dim report As New frmPrintSubjectsTaken()
        report.Text = "Mark Sheet"
        report.ShowDialog()
    End Sub

    Private Sub addSubjectsBI_ItemClick(sender As Object, e As ItemClickEventArgs) Handles addSubjectsBI.ItemClick
        frmAddSubject.ShowDialog()
    End Sub

    Private Sub editSubjectBI_ItemClick(sender As Object, e As ItemClickEventArgs) Handles editSubjectBI.ItemClick
        frmModifySubject.ShowDialog()
    End Sub

    Private Sub deleteSubjectBI_ItemClick(sender As Object, e As ItemClickEventArgs) Handles deleteSubjectBI.ItemClick
        frmDeleteSubject.ShowDialog()
    End Sub

    Private Sub aboutBI_ItemClick(sender As Object, e As ItemClickEventArgs) Handles aboutBI.ItemClick
        MessageBox.Show("Akademico Is A School Information Management System Developed and Maintained By Genius Dynamics" + Environment.NewLine + "For More Information About This Product Please Call 0733 911 638 or 0723 836 205", "About Akademico", MessageBoxButtons.OK)
    End Sub

    Private Sub licenseNB_LinkClicked(sender As Object, e As NavBarLinkEventArgs) Handles licenseNB.LinkClicked
        frmLicense.ShowDialog()
    End Sub

    Private Class MySqlBackup
        Friend ExportInfo As Object
        Private cmd As SqlCommand

        Public Sub New(cmd As SqlCommand)
            Me.cmd = cmd
        End Sub

        Friend Sub ExportToFile(filePath As String)
            Throw New NotImplementedException()
        End Sub
    End Class

    Private Sub performance_ItemClick(sender As Object, e As ItemClickEventArgs) Handles performance.ItemClick

        frmResultMeanAnalysis.ShowDialog()
        'calls frmMeanResults
    End Sub

    Private Sub newPerformance_ItemClick(sender As Object, e As ItemClickEventArgs) Handles newPerformance.ItemClick
        frmContribution.ShowDialog()
        'calls frmcomputeResults
    End Sub
End Class
