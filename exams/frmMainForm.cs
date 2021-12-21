using System;
using global::System.Data.SqlClient;
using System.Drawing;
using global::System.IO;
using System.Linq;
using global::System.Threading;
using System.Windows.Forms;
using global::DevExpress.LookAndFeel;
using global::DevExpress.XtraBars;
using global::DevExpress.XtraBars.Ribbon;
using global::DevExpress.XtraNavBar;
using global::DevExpress.XtraSplashScreen;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmMainForm : RibbonForm
    {
        static frmMainForm()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            UserLookAndFeel.Default.SkinName = My.MySettingsProperty.Settings.selectedTheme;
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font(My.MySettingsProperty.Settings.userFont, My.MySettingsProperty.Settings.fontSize);
        }

        public frmMainForm()
        {
            Load += frmMainForm_Load;
            FormClosing += frmMainForm_FormClosing;
            InitializeComponent();
            myDefaultLookAndFeel.LookAndFeel.SetSkinStyle(My.MySettingsProperty.Settings.selectedTheme);
        }

        private void performanceCommentsBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var performanceCommentsForm = new frmPerformanceComments();
            performanceCommentsForm.ShowDialog();
        }

        private void principalCommentBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var headTeacherCommentForm = new frmHeadTeacherComments();
            headTeacherCommentForm.ShowDialog();
        }

        private void classBasedBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var classBasedForm = new frmClassBasedGrading();
            classBasedForm.Text = "Class Based Grading";
            classBasedForm.MdiParent = this;
            classBasedForm.Show();
        }

        private void subjectBasedBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subjectBasedForm = new frmSubjectBasedGrading();
            subjectBasedForm.MdiParent = this;
            subjectBasedForm.Show();
        }

        private void createExamBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var createExamForm = new frmCreateExam();
            createExamForm.ShowDialog();
        }

        private void editExamBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var editExamForm = new frmEditDeleteExam();
            editExamForm.ShowDialog();
        }

        private void localExaminationBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var enterMarksForm = new frmEnterMarks();
            enterMarksForm.MdiParent = this;
            enterMarksForm.Show();
        }

        private void studentProfileBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var studentPerformanceProfile = new frmStudentProfile();
            studentPerformanceProfile.MdiParent = this;
            studentPerformanceProfile.Show();
        }

        private void performanceIndexBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var studentProfileIndex = new frmStudentPerformanceIndex();
            studentProfileIndex.ShowDialog();
        }

        private void subjectPerformanceIndexBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subjectPerformanceIndexForm = new frmSubjectPerformanceIndex();
            subjectPerformanceIndexForm.ShowDialog();
        }

        private void studentPerformanceBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var studentPerformanceForm = new frmResults();
            studentPerformanceForm.MdiParent = this;
            studentPerformanceForm.Show();
        }

        private void subjectPerformanceBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subjectPerformanceForm = new frmSubjectPerformanceSpecific();
            subjectPerformanceForm.ShowDialog();
        }

        private void reportFormConfigurationFormBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var reportFormConfiguration = new frmReportConfiguration();
            reportFormConfiguration.ShowDialog();
        }

        private void meritListConfigBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var meritListForm = new frmMeritListConfig();
            meritListForm.ShowDialog();
        }

        private object accesibleMenu = string.Empty;

        private void frmMainForm_Load(object sender, EventArgs e)
        {

            // frmDBConnection.ShowDialog()

            foreach (RibbonPage pageGroup in mainRibbon.Pages)
            {
                foreach (RibbonPageGroup group in pageGroup.Groups)
                {
                    group.AllowTextClipping = false;
                    group.ShowCaptionButton = false;
                }
            }

            if (!publicSubsNFunctions.connect())
            {
                My.MyProject.Forms.frmDBConnection.ShowDialog();
                return;
            }

            mainRibbon.Enabled = false;
            publicSubsNFunctions.get_school_details();
            publicSubsNFunctions.get_subjects();
            publicSubsNFunctions.get_grades();
            publicSubsNFunctions.createTableTempTable();
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            for (int i = 1; i <= 100; i++)
            {
                SplashScreenManager.Default.SetWaitFormDescription(i.ToString() + "%");
                SplashScreenManager.Default.SetWaitFormCaption("Initializing Akademico");
                Thread.Sleep(25);
            }

            SplashScreenManager.CloseForm(false);
            VerifyL.addLicenseTable();
            VerifyL.AddTimeStamp();
            if (VerifyL.verifyTimeStamp() == true)
            {
                var licenseForm = new frmLicense();
                licenseForm.ShowDialog();
                if (VerifyL.verifyTimeStamp() == true)
                {
                    return;
                }
            }

            if (VerifyL.verifyTime())
            {
                return;
            }

            string details = VerifyL.getSchoolDetails();
            if (!string.IsNullOrEmpty(details))
            {
                Text += Convert.ToString(" Is Licensed to ") + details;
            }

            My.MyProject.Forms.frmLogIn.ShowDialog();
            if (publicSubsNFunctions.myFormVariable == false)
            {
                Close();
            }

            if (publicSubsNFunctions.loggedInUser == "Admin1234")
            {
                mainRibbon.Enabled = true;
                return;
            }

            accesibleMenu = publicSubsNFunctions.getMenus(publicSubsNFunctions.loggedInUser).ToString().ToLower();
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectLessEqual(accesibleMenu.Length, 0, false)))
            {
                publicSubsNFunctions.success("The User Has Not Been Assigned Any Rights In The System");
                mainRibbon.Enabled = false;
                return;
            }

            mainRibbon.Enabled = true;
            foreach (RibbonPage pageGroup in mainRibbon.Pages)
            {
                foreach (RibbonPageGroup group in pageGroup.Groups)
                {
                    foreach (var button1 in group.Ribbon.Items)
                    {
                        if (button1.GetType().ToString() == "DevExpress.XtraBars.BarButtonItem")
                        {
                            BarButtonItem button = (BarButtonItem)button1;
                            if (Conversions.ToBoolean(!accesibleMenu.Contains(button.Caption.ToLower())))
                            {
                                button.Enabled = false;
                            }
                        }
                    }
                }
            }

            foreach (NavBarItem item in mainNavBar.Items)
            {
                if (Conversions.ToBoolean(Operators.AndObject(!accesibleMenu.Contains(item.Caption), !(item.Caption.ToLower() == "db connection"))))
                {
                    item.Enabled = false;
                }
            }
        }

        private void generalPerformanceBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var generalPerformance = new frmSubjectPerformanceGeneral();
            generalPerformance.ShowDialog();
        }

        private void dbConnection_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            My.MyProject.Forms.frmDBConnection.ShowDialog();
        }

        private void splitSubjectBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            My.MyProject.Forms.frmAddSplitSubject.ShowDialog();
        }

        private void editSplitBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            My.MyProject.Forms.frmSplitSubjects.ShowDialog();
        }

        private void subjectTakenBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subjectTakenForm = new frmSubjectsDone();
            subjectTakenForm.MdiParent = this;
            subjectTakenForm.Show();
        }

        private void assignIndexNoBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var indexNumberForm = new frmIndexNumbers();
            indexNumberForm.MdiParent = this;
            indexNumberForm.Show();
        }

        private void createNationalExamBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            My.MyProject.Forms.frmCreateNationalExam.ShowDialog();
        }

        private void editNationalExamBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            My.MyProject.Forms.frmDeleteNationalExam.ShowDialog();
        }

        private void enterNationExams_ItemClick(object sender, ItemClickEventArgs e)
        {
            var nationalExamsForm = new frmNationalExaminationsEntry();
            nationalExamsForm.MdiParent = this;
            nationalExamsForm.Show();
        }

        private void applicationFontBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var applicationFont = new FontDialog();
            applicationFont.ShowApply = false;
            applicationFont.ScriptsOnly = false;
            applicationFont.MaxSize = 13;
            applicationFont.MinSize = 8;
            applicationFont.ShowEffects = false;
            applicationFont.FontMustExist = true;
            applicationFont.AllowScriptChange = false;
            if (applicationFont.ShowDialog() == DialogResult.OK)
            {
                My.MySettingsProperty.Settings.fontSize = applicationFont.Font.Size;
                My.MySettingsProperty.Settings.userFont = applicationFont.Font.ToString();
                My.MySettingsProperty.Settings.Save();
                Interaction.MsgBox("Please Close And Launch The Application For The Changes To Reflect");
            }
        }

        private void defaultBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (publicSubsNFunctions.displayConfirmationMessage("Are You Sure You Want To Restore The Defualt Theme And Font"))
            {
                My.MySettingsProperty.Settings.fontSize = 10f;
                My.MySettingsProperty.Settings.userFont = "Segoe UI Symbol";
                My.MySettingsProperty.Settings.selectedTheme = "Caramel";
                publicSubsNFunctions.changedByUser = true;
                My.MySettingsProperty.Settings.Save();
                Interaction.MsgBox("Please Close And Launch The Application For The Changes To Reflect");
            }
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            My.MySettingsProperty.Settings.selectedTheme = myDefaultLookAndFeel.LookAndFeel.ActiveSkinName;
            My.MySettingsProperty.Settings.Save();
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "app_databases");
            if (Directory.Exists(directoryPath))
            {
                var files = Directory.GetFiles(directoryPath, "*.sql", SearchOption.AllDirectories);
                if (files.Length == 0)
                {
                    backupDatabase();
                }
                else
                {
                    int totalDaysNow = DateTime.Now.Year;
                    int totalDaysPrevious = File.GetCreationTime(files[files.Length - 1]).DayOfYear;
                    int difference = totalDaysNow - totalDaysPrevious;
                    string argq = "SELECT frequency FROM `db_back_up` LIMIT 1;";
                    if (publicSubsNFunctions.qread(ref argq))
                    {
                        if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                        {
                            publicSubsNFunctions.dbreader.Read();
                            int index = Convert.ToInt16(publicSubsNFunctions.dbreader[0].ToString().Substring(0, 1));
                            if (totalDaysNow > index + totalDaysPrevious)
                            {
                                backupDatabase();
                            }
                        }
                        else if (totalDaysNow != totalDaysPrevious)
                        {
                            backupDatabase();
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(directoryPath);
                backupDatabase();
            }
        }

        private void backupDatabase()
        {
            // dbconn = New Odbc.OdbcConnection("Driver=MySQl ODBC 5.1 Driver;server=" + My.Settings.host + ";user=" + My.Settings.userName + ";password=" + My.Settings.passWord + ";database=" + My.Settings.dbName + ";port=" + My.Settings.dPport + ";")
            // Dim conString As String = "server=" + My.Settings.host + ";user=" + My.Settings.userName + ";password=" + My.Settings.passWord + ";database=" + My.Settings.dbName + ";port=" + My.Settings.dPport + ";"

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "app_databases") + @"\\" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ".sql";
            using (new DevExpress.Utils.WaitDialogForm("Backing Up Database"))
                try
                {
                    var cmd = new SqlCommand();
                    var mb = new MySqlBackup(cmd);
                    // cmd.Connection = dbconn
                    publicSubsNFunctions.connect();
                    mb.ExportInfo.AddCreateDatabase = true;
                    mb.ExportToFile(filePath);
                    publicSubsNFunctions.dbconn.Close();
                    MessageBox.Show("The Operation Was Successful");
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message)
                    return;
                }
        }

        private void systemUsersBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var userForm = new frmUsers();
            userForm.MdiParent = this;
            userForm.Show();
        }

        private void rightsBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rightsForm = new frmPriviledges();
            rightsForm.MdiParent = this;
            rightsForm.Show();
        }

        private void createExamNB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            My.MyProject.Forms.frmCreateExam.ShowDialog();
        }

        private void localExamNB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var enterMarksForm = new frmEnterMarks();
            enterMarksForm.MdiParent = this;
            enterMarksForm.Show();
        }

        private void generalPerformanceNB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            My.MyProject.Forms.frmSubjectPerformanceGeneral.ShowDialog();
        }

        private void subjectPerformanceNB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            My.MyProject.Forms.frmSubjectPerformanceSpecific.ShowDialog();
        }

        private void classSubjectBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            My.MyProject.Forms.frmClassSubjects.ShowDialog();
        }

        private void showSubjectsBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var report = new frmPrintSubjectsTaken();
            report.Text = "Show Subjects Taken";
            report.ShowDialog();
        }

        private void markSheetBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            var report = new frmPrintSubjectsTaken();
            report.Text = "Mark Sheet";
            report.ShowDialog();
        }

        private void addSubjectsBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            My.MyProject.Forms.frmAddSubject.ShowDialog();
        }

        private void editSubjectBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            My.MyProject.Forms.frmModifySubject.ShowDialog();
        }

        private void deleteSubjectBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            My.MyProject.Forms.frmDeleteSubject.ShowDialog();
        }

        private void aboutBI_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Akademico Is A School Information Management System Developed and Maintained By Genius Dynamics" + Environment.NewLine + "For More Information About This Product Please Call 0733 911 638 or 0723 836 205", "About Akademico", MessageBoxButtons.OK);
        }

        private void licenseNB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            My.MyProject.Forms.frmLicense.ShowDialog();
        }

        private class MySqlBackup
        {
            internal object ExportInfo;
            private SqlCommand cmd;

            public MySqlBackup(SqlCommand cmd)
            {
                this.cmd = cmd;
            }

            internal void ExportToFile(string filePath)
            {
                throw new NotImplementedException();
            }
        }

        private void performance_ItemClick(object sender, ItemClickEventArgs e)
        {
            My.MyProject.Forms.frmResultMeanAnalysis.ShowDialog();
            // calls frmMeanResults
        }

        private void newPerformance_ItemClick(object sender, ItemClickEventArgs e)
        {
            My.MyProject.Forms.frmContribution.ShowDialog();
            // calls frmcomputeResults
        }
    }
}