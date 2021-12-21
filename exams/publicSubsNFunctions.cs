using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using static global::System.Environment;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    static class publicSubsNFunctions
    {
        public static System.Data.Odbc.OdbcConnection dbconn;
        public static System.Data.Odbc.OdbcCommand dbcommand;
        public static System.Data.Odbc.OdbcDataReader dbreader;
        public static System.Data.Odbc.OdbcDataReader dbreader1;
        public static bool successful, search_teachers, analysis_mode, grading, rank;
        public static bool cont = false;
        public static bool fee = false;
        public static object[] subjects, subjabb, subjname, subjids, grades, exam_names, grades_y, sequence, yrs, tms, all_classes;
        public static string class_stream, query, table, exam_name, tm, class_form, stream, subj, title, msg, t_name, term, operation, rpt;
        public static string[] streams;
        public static int yr, USER_ID, ENTITY_ID, t_id, marks;
        public static int[] contribution, total_mark;
        public static string S_NAME, S_FAX, S_PHONE, S_LOCATION, S_ADDRESS, S_EMAIL, subject, SMS_Center, SMS_COM;
        public static string[] tables, ThisUser, classIDs;
        public static string bigfont = "Arial";
        public static string fontname = "Arial";
        public static string biggerfont = "Arial";
        public static int biggersize = Conversions.ToInteger("15");
        public static int bigsize = Conversions.ToInteger("14");
        public static int headsmall = Conversions.ToInteger("12");
        public static int othersize = Conversions.ToInteger("11");
        public static int smallsize = Conversions.ToInteger("10");
        public static int small_font = Conversions.ToInteger("8");
        public static object GRP_SCIENCES = "SCIENCE";
        public static object GRP_HUMANITIES = "HUMANITIES";
        public static object GRP_TECHNICAL = "TECHNICAL";
        public static string sortby;
        public static bool[] modules = new bool[6];
        public static bool show_sending, bar_graph, NewOpen;
        public static string page_line = ".....................................................................................................";
        public static DateTime to_close, to_open;
        public static bool stud = false;
        public static Font medium_larger = new Font(biggerfont, biggersize, FontStyle.Regular);
        public static Font medium = new Font(bigfont, othersize - 1, FontStyle.Regular);
        public static Font head_small = new Font(bigfont, headsmall, FontStyle.Bold);
        public static Font smallfont = new Font(fontname, small_font, FontStyle.Regular);
        public static Font italisized_font = new Font(fontname, smallsize, FontStyle.Italic);
        public static Font mediumsize = new Font(fontname, othersize, FontStyle.Bold);
        public static Font other_font = new Font(fontname, smallsize, FontStyle.Bold);
        public static Font header_font = new Font(bigfont, bigsize, FontStyle.Bold);
        public static bool stream_mode, trying, subject_ranking_table, show_split, found;
        public static bool confirm_return, form_4_mode, to_continue, best_of_7;
        public static bool mod_subject = false;
        public static int bk_id, t_no, row_from, row_to, rankno;
        public static string None = "None";
        public static System.Data.Odbc.OdbcDataReader dbreader2;
        public static string DemoDatabase = "DemoDatabase";
        public static bool mode = false;
        public static bool attend = false;
        public static bool radF, radL, backup, restore, load_from_alumni, watermark, grade;
        public static string path = GetFolderPath(SpecialFolder.ApplicationData);
        public static System.Data.Odbc.OdbcConnection dbConnNew;
        public static System.Data.Odbc.OdbcCommand dbcommand1;
        public static int startyear = 2010;
        public static int endyear = DateAndTime.Today.Year;
        public static bool changedByUser;
        public static string loggedInUser = string.Empty;
        public static bool myFormVariable = false;
        public static List<string> subjectColumns;
        public static List<Tuple<string, string, string>> examList;
        public static List<Tuple<string, string, string, string, string>> examListMain;
        public static string selectedClass = string.Empty;
        public static string selectedYear = string.Empty;
        public static string gradingType = string.Empty;
        public static string selectedTerm = string.Empty;
        public static string sortGradesBy = string.Empty;
        public static Dictionary<string, List<Tuple<string, short>>> subjectGrading = new Dictionary<string, List<Tuple<string, short>>>();
        public static Dictionary<string, List<Tuple<string, short>>> subjectGrading2 = new Dictionary<string, List<Tuple<string, short>>>();
        public static List<Tuple<string, short>> classGrading = new List<Tuple<string, short>>();
        public static Dictionary<string, short> GradeToPoint = new Dictionary<string, short>();
        public static List<Tuple<long, string, string, string, string>> students = new List<Tuple<long, string, string, string, string>>();
        public static List<string> classStream = new List<string>();
        public static Dictionary<string, int> overallAverage = new Dictionary<string, int>();
        public static Dictionary<string, double> averagePoints = new Dictionary<string, double>();
        public static Dictionary<string, int> studentCount = new Dictionary<string, int>();
        public static int classCount;
        public static int resultsTotal;
        public static List<Tuple<string, string, string, string>> selectedExams = new List<Tuple<string, string, string, string>>();
        public static string filterType = string.Empty;
        public static List<string> schoolSubjects = new List<string>();

        public struct ReportForm
        {
            public bool student_photo, school_logo, color, head_teacher_name, class_teacher_name, class_teacher_comments, head_teacher_comments, class_teacher_signature, head_teacher_signature, house_master_comments, club_and_societies;
        }

        public static bool connect()
        {
            dbconn = new System.Data.Odbc.OdbcConnection("Driver=MySQl ODBC 5.1 Driver;server=" + My.MySettingsProperty.Settings.host + ";user=" + My.MySettingsProperty.Settings.userName + ";password=" + My.MySettingsProperty.Settings.passWord + ";database=" + My.MySettingsProperty.Settings.dbName + ";port=" + My.MySettingsProperty.Settings.dPport + ";");
            try
            {
                dbconn.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The System Could Not Connect to the Database" + Constants.vbNewLine + "Make sure the Wamp Server is running", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static object dbNewOpen()
        {
            dbConnNew = new System.Data.Odbc.OdbcConnection("Driver=MySQl ODBC 5.1 Driver;server=" + My.MySettingsProperty.Settings.host + ";user=" + My.MySettingsProperty.Settings.userName + ";password=" + My.MySettingsProperty.Settings.passWord + ";database=" + My.MySettingsProperty.Settings.dbName + ";port=" + My.MySettingsProperty.Settings.dPport + ";");
            try
            {
                dbConnNew.Open();
                dbcommand1 = new System.Data.Odbc.OdbcCommand();
                dbcommand1.Connection = dbConnNew;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static object generateDataTable(ref string sql)
        {
            var run = new System.Data.Odbc.OdbcCommand();
            var dt = new DataTable();
            var dataadapter = new System.Data.Odbc.OdbcDataAdapter();
            try
            {
                run.CommandText = sql;
                run.Connection = dbconn;
                dataadapter.SelectCommand = run;
                dataadapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }

            return dt;
        }

        public static object getMenus(string user)
        {
            string menus = string.Empty;
            string argq = "select rights from priviledges where user = '" + user + "' and domain = 'Exam'";
            if (qread(ref argq))
            {
                if (dbreader.RecordsAffected > 0)
                {
                    dbreader.Read();
                    menus = dbreader.GetString(0);
                    dbreader.Close();
                }
            }

            return menus;
        }

        public static bool logIn(string userName, string passWord)
        {
            string argq = "select partner from system_users where user_name = md5('" + userName + "') and password = md5('" + passWord + "') and domain = md5('Examination');";
            if (qread(ref argq))
            {
                if (dbreader.RecordsAffected > 0)
                {
                    dbreader.Read();
                    loggedInUser = dbreader.GetString(0);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return default;
        }

        public static bool qread(ref string q, int reader = 0)
        {
            dbcommand = new System.Data.Odbc.OdbcCommand();
            dbcommand.Connection = dbconn;
            dbcommand.CommandText = q;
            try
            {
                if (reader == 0)
                {
                    try
                    {
                        dbreader.Close();
                    }
                    catch (Exception ex)
                    {
                    }

                    dbreader = dbcommand.ExecuteReader();
                }
                else if (reader == 1)
                {
                    try
                    {
                        dbreader1.Close();
                    }
                    catch (Exception ex)
                    {
                    }

                    dbreader1 = dbcommand.ExecuteReader();
                }
                else if (reader == 2)
                {
                    try
                    {
                        dbreader2.Close();
                    }
                    catch (Exception ex)
                    {
                    }

                    dbreader2 = dbcommand.ExecuteReader();
                }

                return true;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("System Could Not Read The Database" + Constants.vbNewLine + ex.Message);
                return false;
            }

            // Try
            // dbreader = dbcommand.ExecuteReader
            // Return True
            // Catch ex As Exception
            // MsgBox("System Could Not Read The Database" & vbNewLine & ex.Message)
            // Return False
            // End Try
        }

        public static bool qwrite(string q)
        {
            dbcommand = new System.Data.Odbc.OdbcCommand();
            dbcommand.Connection = dbconn;
            dbcommand.CommandText = q;
            try
            {
                dbcommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("System Could Not Write The DataBase" + Constants.vbNewLine + ex.Message);
                return false;
            }
        }

        public static void load_class(ref ComboBox cbo)
        {
            cbo.Items.Clear();
            string argq = "SELECT distinct(class) FROM class_stream";
            qread(ref argq);
            while (dbreader.Read())
                cbo.Items.Add(dbreader["class"]);
        }

        public static void load_stream(ref ComboBox cbo)
        {
            cbo.Items.Clear();
            string argq = "SELECT distinct(stream) FROM class_stream";
            qread(ref argq);
            while (dbreader.Read())
                cbo.Items.Add(dbreader["stream"]);
        }

        public static void load_stream1(ComboBox cbo, string cls)
        {
            cbo.Items.Clear();
            string argq = "SELECT stream FROM class_stream WHERE class='" + escape_string(cls) + "'";
            qread(ref argq);
            while (dbreader.Read())
                cbo.Items.Add(dbreader["stream"]);
        }

        public static void load_subjects(ref ComboBox cbo)
        {
            cbo.Items.Clear();
            string argq = "select subject from subjects";
            qread(ref argq);
            while (dbreader.Read())
                cbo.Items.Add(dbreader["subject"]);
        }

        public static void load_form()
        {
            var frm = new frmLoading();
            frm.ShowDialog();
        }

        public static string escape_string(string val)
        {
            try
            {
                val.ToCharArray();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

            string temp = string.Empty;
            for (int k = 0, loopTo = val.Length - 1; k <= loopTo; k++)
            {
                if (Conversions.ToString(val[k]) == "'")
                {
                    if (k == 0 | Conversions.ToString(val[k - 1]) != @"\")
                    {
                        temp += @"\" + val[k];
                    }
                }
                else
                {
                    temp += Conversions.ToString(val[k]);
                }
            }

            return temp;
        }

        public static void success(string msg)
        {
            Interaction.MsgBox(msg, MsgBoxStyle.Information, "Operation was successful");
        }

        public static void failure(string msg)
        {
            Interaction.MsgBox(msg, MsgBoxStyle.Information, "Operation was unsuccessful");
        }

        public static void fill_years(ref ComboBox cbo)
        {
            cbo.Items.Clear();
            for (int k = DateAndTime.Today.Year - 3, loopTo = DateAndTime.Today.Year + 3; k <= loopTo; k++)
                cbo.Items.Add(k.ToString());
            cbo.SelectedItem = DateAndTime.Today.Year.ToString();
        }

        public static void start()
        {
            qwrite("START TRANSACTION");
        }

        public static void commit()
        {
            qwrite("COMMIT");
        }

        public static void rollback()
        {
            qwrite("ROLLBACK");
        }

        public static object get_subjects()
        {
            string argq = "SELECT * FROM `subjects` order by subjectcode asc";
            if (qread(ref argq))
            {
                if (dbreader.RecordsAffected > 0)
                {
                    subjabb = new object[dbreader.RecordsAffected];
                    subjids = new object[dbreader.RecordsAffected];
                    subjname = new object[dbreader.RecordsAffected];
                    subjects = new object[dbreader.RecordsAffected];
                    int i = 0;
                    while (dbreader.Read())
                    {
                        subjabb[i] = dbreader["Abbreviation"];
                        subjects[i] = dbreader["Subject"];
                        subjname[i] = remove_wild(Conversions.ToString(subjabb[i]));
                        subjids[i] = dbreader["id"];
                        i += 1;
                    }

                    dbreader.Close();
                    return true;
                }
                else
                {
                    success("You Have Not Yet Made Subject Entries Into The Application!");
                    return false;
                }
            }
            else
            {
                failure("Could Not Read From Subjects Database!");
                return false;
            }
        }

        public static object remove_wild(string value)
        {
            try
            {
                value.ToCharArray();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

            string ret = string.Empty;
            bool state = false;
            var wild = new string[29];
            wild[0] = "~";
            wild[1] = "`";
            wild[2] = "!";
            wild[3] = "@";
            wild[4] = "#";
            wild[5] = "$";
            wild[6] = "%";
            wild[7] = "^";
            wild[8] = "&";
            wild[9] = "*";
            wild[10] = "(";
            wild[11] = ")";
            wild[12] = "{";
            wild[13] = "}";
            wild[14] = "[";
            wild[15] = "]";
            wild[16] = "/";
            wild[17] = @"\";
            wild[18] = "|";
            wild[19] = "'";
            wild[20] = ":";
            wild[21] = ";";
            wild[22] = "<";
            wild[23] = ">";
            wild[24] = ",";
            wild[25] = ".";
            wild[26] = "?";
            wild[27] = "-";
            wild[28] = "+";
            for (int j = 0, loopTo = value.Length - 1; j <= loopTo; j++)
            {
                for (int k = 0, loopTo1 = wild.Length - 1; k <= loopTo1; k++)
                {
                    if (Conversions.ToString(value[j]) == wild[k])
                    {
                        state = true;
                    }
                }

                if (!state)
                {
                    ret += Conversions.ToString(value[j]);
                }

                state = false;
            }

            return ret;
        }

        public static object confirm(string msg)
        {
            if (Interaction.MsgBox(msg, MsgBoxStyle.YesNo, "Please confirm your action") == MsgBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static object ret_name(string str)
        {
            string ret = string.Empty;
            bool state = false;
            str = Strings.Trim(str);
            try
            {
                str.ToCharArray();
            }
            catch (Exception ex)
            {
                return ret;
            }

            int i;
            var loopTo = str.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (Conversions.ToString(str[i]) == "_" & state)
                {
                    ret += " ";
                    state = false;
                }
                else if (Conversions.ToString(str[i]) != "_")
                {
                    state = true;
                    ret += Conversions.ToString(str[i]);
                }
            }

            return ret;
        }

        public static object IsAdmin()
        {
            if (USER_ID == 1 | USER_ID == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsSubjectTeacher(string subj, string class_form, string stream, string term, string year)
        {
            string argq = "SELECT Entry FROM subject_teachers WHERE (class='" + escape_string(Conversions.ToString(ret_name(class_form))) + "' AND stream='" + escape_string(stream) + "' AND term='" + term + "' AND year=" + year + " AND TeacherID=" + ENTITY_ID + " AND subject='" + escape_string(subj) + "')";
            qread(ref argq);
            if (dbreader.RecordsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsPrimary()
        {
            string argq = "SELECT school_type FROM school_details WHERE school_type='Primary'";
            qread(ref argq);
            if (dbreader.RecordsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static object get_id(object id)
        {
            return id;
        }

        public static object get_subject_name(string s, bool abb = false)
        {
            if (abb)
            {
                int i;
                var loopTo = subjabb.Length - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(subjects[i], s, false), Operators.ConditionalCompareObjectEqual(subjabb[i], s, false))))
                    {
                        return subjabb[i];
                    }
                }

                try
                {
                    return subjabb[i];
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
            else
            {
                int i;
                var loopTo1 = subjabb.Length - 1;
                for (i = 0; i <= loopTo1; i++)
                {
                    if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(subjabb[i], s, false), Operators.ConditionalCompareObjectEqual(subjects[i], s, false))))
                    {
                        return subjects[i];
                    }
                }

                try
                {
                    return subjects[i];
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
        }

        public static object fix_point(string grade)
        {
            // If (grade.Length - 3) > 0 Then
            // For m As Integer = 0 To grades.Length - 3
            // If grade = grades(m) Then
            // Return (12 - m)
            // End If
            // Next
            // End If
            // Return 0

            for (int m = 0, loopTo = grades.Length - 3; m <= loopTo; m++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(grade, grades[m], false)))
                {
                    return 12 - m;
                }
            }

            return 0;
        }

        public static object get_grade(double val, bool s, string subj, string class_ = null)
        {
            if (string.IsNullOrEmpty(class_))
            {
                class_ = class_form;
            }

            val = Math.Round(val, 0);
            if (s)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM s_grading WHERE (Class='", ret_name(class_)), "' AND Subject='"), get_subject_name(subj)), "' AND term='"), tm), "' AND year='"), yr), "');"));
                qread(ref argq, 1);
            }
            else
            {
                string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM grading WHERE (Class='", ret_name(class_)), "' AND term='"), tm), "' AND year='"), yr), "');"));
                qread(ref argq1, 1);
            }

            if (dbreader1.RecordsAffected > 0)
            {
                dbreader1.Read();
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(val, dbreader1["A"], false)))
                {
                    dbreader1.Close();
                    return "A";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(val, dbreader1["A-"], false)))
                {
                    dbreader1.Close();
                    return "A-";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(val, dbreader1["B+"], false)))
                {
                    dbreader1.Close();
                    return "B+";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(val, dbreader1["B"], false)))
                {
                    dbreader1.Close();
                    return "B";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(val, dbreader1["B-"], false)))
                {
                    dbreader1.Close();
                    return "B-";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(val, dbreader1["C+"], false)))
                {
                    dbreader1.Close();
                    return "C+";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(val, dbreader1["C"], false)))
                {
                    dbreader1.Close();
                    return "C";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(val, dbreader1["C-"], false)))
                {
                    dbreader1.Close();
                    return "C-";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(val, dbreader1["D+"], false)))
                {
                    dbreader1.Close();
                    return "D+";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(val, dbreader1["D"], false)))
                {
                    dbreader1.Close();
                    return "D";
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreaterEqual(val, dbreader1["D-"], false)))
                {
                    dbreader1.Close();
                    return "D-";
                }
                else
                {
                    dbreader1.Close();
                    return "E";
                }
            }
            else
            {
                dbreader1.Close();
                return "E";
            }
        }

        public static void fill_class(string str, ref ComboBox cbo)
        {
            cbo.Items.Clear();
            string argq = "SELECT stream FROM class_stream WHERE class='" + escape_string(str) + "'";
            qread(ref argq);
            while (dbreader.Read())
                cbo.Items.Add(dbreader["stream"]);
        }

        public static string parseQuery(string queryString)
        {
            string newString = string.Empty;
            newString = queryString.Trim();
            if (newString.EndsWith(","))
            {
                newString = newString.Remove(newString.Length - 1, 1);
                newString += ";";
            }

            return newString;
        }

        public static void resetSchoolName()
        {
            string details = VerifyL.getSchoolDetails();
            if (!string.IsNullOrEmpty(details))
            {
                string schoolName = VerifyL.getStringRecord("select school_name from school_details limit 1;");
                if (string.IsNullOrEmpty(schoolName))
                {
                    if (qwrite("insert into school_details (`school_name`, `telephone`, `postal_address`, `town`) values ('" + escape_string(details) + "', 'SAMPLE', 'SAMPLE', 'SAMPLE');"))
                    {
                    }
                }
                else if ((schoolName ?? "") != (details ?? ""))
                {
                    if (qwrite("update school_details set school_name = '" + escape_string(details) + "';"))
                    {
                    }
                }
            }
            else if (qwrite("insert into school_details (`school_name`, `telephone`, `postal_address`, `town`) values ('" + escape_string(details) + "', 'SAMPLE', 'SAMPLE', 'SAMPLE');"))
            {
            }
        }

        public static object get_total_mark(string exam, string tm, string yer = null)
        {
            if (string.IsNullOrEmpty(yer))
            {
                yer = yr.ToString();
            }

            int i;
            string argq = "SELECT Total FROM examinations WHERE (ExamName='" + exam + "' AND Term='" + tm + "' AND Year='" + yer + "')";
            if (qread(ref argq))
            {
                dbreader.Read();
                try
                {
                    i = Conversions.ToInteger(dbreader["Total"]);
                }
                catch (Exception ex)
                {
                    i = 0;
                }

                dbreader.Close();
                return i;
            }
            else
            {
                return false;
            }
        }

        public static double SubjectOutOf(object subj, object tm, object yr, object exam, object cls, object str, object reader = 0)
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `", subj), "` FROM exam_results_subjects_out_of WHERE (Examination = '"), escape_string(Conversions.ToString(exam))), "' AND Term = '"), tm), "' AND Year = '"), yr), "' AND Class='"), escape_string(Conversions.ToString(cls))), "' AND Stream='"), escape_string(Conversions.ToString(str))), "')"));
            qread(ref argq, Conversions.ToInteger(reader));
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(reader, 0, false)))
            {
                if (dbreader.RecordsAffected > 0)
                {
                    dbreader.Read();
                    return Conversions.ToDouble(publicSubsNFunctions.dbreader(subj));
                }
            }
            else if (dbreader2.RecordsAffected > 0)
            {
                dbreader2.Read();
                return Conversions.ToDouble(publicSubsNFunctions.dbreader2(subj));
            }

            return default;
        }

        public static object get_name(string str)
        {
            str = Conversions.ToString(remove_wild(str));
            string ret = string.Empty;
            bool state = false;
            str = Strings.Trim(str);
            try
            {
                str.ToCharArray();
            }
            catch (Exception ex)
            {
                return str;
            }

            int i;
            var loopTo = str.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (Conversions.ToString(str[i]) == " " & state)
                {
                    ret += "_";
                    state = false;
                }
                else if (Conversions.ToString(str[i]) != " ")
                {
                    state = true;
                    ret += Conversions.ToString(str[i]);
                }
            }

            return ret;
        }

        public static void get_grades()
        {
            grades = new object[14];
            grades_y = new object[14];
            grades[0] = "A";
            grades[1] = "A-";
            grades[2] = "B+";
            grades[3] = "B";
            grades[4] = "B-";
            grades[5] = "C+";
            grades[6] = "C";
            grades[7] = "C-";
            grades[8] = "D+";
            grades[9] = "D";
            grades[10] = "D-";
            grades[11] = "E";
            grades[12] = "X";
            grades[13] = "Y";
        }

        public static object get_points(double marks)
        {
            marks = Math.Round(marks, 2);
            if (marks >= 11.5d)
            {
                return "A";
            }
            else if (marks >= 10.5d)
            {
                return "A-";
            }
            else if (marks >= 9.5d)
            {
                return "B+";
            }
            else if (marks >= 8.5d)
            {
                return "B";
            }
            else if (marks >= 7.5d)
            {
                return "B-";
            }
            else if (marks >= 6.5d)
            {
                return "C+";
            }
            else if (marks >= 5.5d)
            {
                return "C";
            }
            else if (marks >= 4.5d)
            {
                return "C-";
            }
            else if (marks >= 3.5d)
            {
                return "D+";
            }
            else if (marks >= 2.5d)
            {
                return "D";
            }
            else if (marks >= 1.5d)
            {
                return "D-";
            }
            else
            {
                return "E";
            }
        }

        public static string logo()
        {
            string logoRet = default;
            string argq = "SELECT image_path FROM school_details";
            qread(ref argq);
            dbreader.Read();
            logoRet = Conversions.ToString(dbreader["image_path"]);
            dbreader.Close();
            return logoRet;
        }

        public static void get_term()
        {
            if (DateAndTime.Month(DateAndTime.Today.Date) <= 4)
            {
                term = "I";
            }
            else if (DateAndTime.Month(DateAndTime.Today.Date) <= 8)
            {
                term = "II";
            }
            else
            {
                term = "III";
            }

            tm = term;
        }

        public static void wait(string msg)
        {
            operation = msg;
            var frm = new frmWait();
            frm.ShowDialog();
        }

        public static object ret_subject_name(string s)
        {
            int i;
            var loopTo = subjabb.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(subjects[i], s, false)))
                {
                    return subjabb[i];
                }
            }

            try
            {
                return subjabb[i];
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string get_comment(string grade, bool s_grade, string S)
        {
            if (s_grade)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `" + grade + "` FROM s_grading_comments WHERE (Subject='", get_subject_name(S)), "' AND Class='"), ret_name(class_form)), "' AND term='"), tm), "' AND year='"), yr), "')"));
                if (qread(ref argq))
                {
                    try
                    {
                        dbreader.Read();
                        grade = Conversions.ToString(dbreader[grade]);
                    }
                    catch (Exception ex)
                    {
                        grade = null;
                    }
                }
                else
                {
                    grade = "POOR";
                }
            }
            else
            {
                string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `" + grade + "` FROM grading_comments WHERE (Class='", ret_name(class_form)), "' AND term='"), tm), "' AND year='"), yr), "')"));
                if (qread(ref argq1))
                {
                    try
                    {
                        dbreader.Read();
                        grade = Conversions.ToString(dbreader[grade]);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    grade = "POOR";
                }
            }

            return grade;
        }

        public static object subject_teacher(string str, string c_form, string term, int year, string subj)
        {
            string tname = string.Empty;
            string[] tInitials;
            string initials = string.Empty;
            int tid;
            string argq = "SELECT TeacherID FROM `subject_teachers` WHERE (Abbreviation='" + escape_string(subj) + "' AND term='" + term + "' AND year='" + year + "' AND stream='" + escape_string(str) + "' AND class='" + escape_string(Conversions.ToString(ret_name(c_form))) + "')";
            qread(ref argq);
            if (dbreader.RecordsAffected > 0)
            {
                try
                {
                    dbreader.Read();
                    tid = Conversions.ToInteger(dbreader["TeacherID"]);
                    dbreader.Close();
                    string argq1 = "SELECT partnerName, title FROM partners WHERE id ='" + tid + "' and partnerType = 'Teaching Staff'";
                    qread(ref argq1);
                    if (dbreader.RecordsAffected > 0)
                    {
                        dbreader.Read();
                        if (!Information.IsDBNull(dbreader["partnerName"]))
                        {
                            if (!string.IsNullOrEmpty(dbreader["partnerName"].ToString()))
                            {
                                tInitials = dbreader["partnerName"].ToString().Split();
                                if (tInitials.Count() > 0)
                                {
                                    foreach (string s in tInitials)
                                    {
                                        if (!string.IsNullOrEmpty(s))
                                        {
                                            initials += s.Substring(0, 1).ToUpper() + " ";
                                        }
                                    }
                                }
                            }
                        }



                        // tname = dbreader("title") & ". " & initials
                        tname = initials;
                        dbreader.Close();
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return tname;
        }

        public static void get_SMS_Details()
        {
            string argq = "SELECT * FROM sms";
            qread(ref argq);
            if (dbreader.RecordsAffected > 0)
            {
                while (dbreader.Read())
                {
                    SMS_Center = Conversions.ToString(dbreader["CenterNo"]);
                    SMS_COM = Conversions.ToString(dbreader["Port"]);
                }
            }
        }

        public static string[] classes()
        {
            // todo added the list of string code and the distinct in sql 
            var schoolClasses = new List<string>();
            string[] ret;
            string argq = "SELECT distinct class FROM class_stream ORDER BY id";
            qread(ref argq);
            ret = new string[dbreader.RecordsAffected];
            classIDs = new string[dbreader.RecordsAffected];
            string argq1 = "SELECT id, class FROM class_stream ORDER BY id";
            qread(ref argq1);
            int i = 0;
            while (dbreader.Read())
            {
                if (!schoolClasses.Contains(dbreader["class"].ToString()))
                {
                    if (i >= classIDs.Count())
                    {
                        break;
                    }

                    ret[i] = Conversions.ToString(dbreader["class"]);
                    classIDs[i] = Conversions.ToString(dbreader["id"]);
                    schoolClasses.Add(dbreader["class"].ToString());
                    i += 1;
                }
            }

            return ret;
        }

        public static object CheckStatus(object val)
        {
            if (val.ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static object subject_get(object id)
        {
            object subject_getRet = default;
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Subject FROM subjects WHERE id='", id), "'"));
            qread(ref argq);
            dbreader.Read();
            subject_getRet = dbreader["Subject"];
            dbreader.Close();
            return subject_getRet;
        }

        public static object CurrentClass(string[] cls, string class_form)
        {
            for (int k = 0, loopTo = cls.Length - 1; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ret_name(class_form), cls[k], false)))
                {
                    return k;
                }
            }

            return 0;
        }

        public static object get_fname(string adm)
        {
            string argq = "SELECT student_name FROM students WHERE admin_no='" + adm + "'";
            qread(ref argq);
            dbreader.Read();
            string fname = Conversions.ToString(dbreader["student_name"]);
            dbreader.Close();
            return fname;
        }

        public static object format_no(string no)
        {
            try
            {
                return "+254" + no.Substring(1);
            }
            catch (Exception ex)
            {
                return "+254733911638";
            }
        }

        public static void wait_slow(string msg)
        {
            operation = msg;
            var frm = new frmWaitSlow();
            frm.ShowDialog();
        }

        public static object get_class_subjects(string cls)
        {
            string argq = "SELECT SubjID, Abbreviation, Subject FROM class_subjects WHERE Class='" + escape_string(cls) + "' ORDER BY SubjID ASC";
            if (qread(ref argq))
            {
                if (dbreader.RecordsAffected > 0)
                {
                    subjabb = new object[dbreader.RecordsAffected];
                    subjids = new object[dbreader.RecordsAffected];
                    subjname = new object[dbreader.RecordsAffected];
                    subjects = new object[dbreader.RecordsAffected];
                    int i = 0;
                    while (dbreader.Read())
                    {
                        subjabb[i] = dbreader["Abbreviation"];
                        subjects[i] = dbreader["Subject"];
                        subjname[i] = remove_wild(Conversions.ToString(subjabb[i]));
                        subjids[i] = dbreader["SubjID"];
                        i += 1;
                    }

                    return true;
                }
                else
                {
                    failure("You Have Not Yet Made Subject Entries Into The Application!");
                    return false;
                }
            }
            else
            {
                failure("Could Not Read From Subjects Database!");
                return false;
            }
        }

        public static void new_con()
        {
            dbcommand = new System.Data.Odbc.OdbcCommand();
            dbcommand.Connection = dbconn;
        }

        public static object get_stream(object adm)
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Stream FROM students WHERE admin_no='", adm), "'"));
            qread(ref argq);
            if (dbreader.Read())
            {
                return dbreader["Stream"];
            }
            else
            {
                failure(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Looks Like Student With Admission Number ", adm), " Has Not Been Assigned A Stream! Please Check On That! In the meantime.. Assigning Him NULL Stream!")));
                return "NULL";
            }
        }

        public static void get_term(ref ComboBox cbo)
        {
            if (DateAndTime.Month(DateAndTime.Today.Date) <= 4)
            {
                term = "I";
            }
            else if (DateAndTime.Month(DateAndTime.Today.Date) <= 8)
            {
                term = "II";
            }
            else
            {
                term = "III";
            }

            tm = term;
            cbo.SelectedItem = term;
        }

        public static bool displayConfirmationMessage(string msg)
        {
            My.MyProject.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep);
            if (Interaction.MsgBox(msg, MsgBoxStyle.YesNo, "Please Confirm") == MsgBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void get_school_details()
        {
            string argq = "SELECT school_name, email, postal_address, telephone, town FROM school_details";
            if (qread(ref argq))
            {
                if (dbreader.RecordsAffected > 0)
                {
                    dbreader.Read();
                    S_NAME = Conversions.ToString(dbreader["school_name"]);
                    S_FAX = Conversions.ToString(dbreader["email"]);
                    S_PHONE = Conversions.ToString(dbreader["telephone"]);
                    S_ADDRESS = Conversions.ToString(dbreader["postal_address"]);
                    S_LOCATION = Conversions.ToString(dbreader["town"]);
                    try
                    {
                        S_EMAIL = Conversions.ToString(dbreader["Email"]);
                    }
                    catch (Exception ex)
                    {
                    }

                    dbreader.Close();
                }
            }
            else
            {
                failure("Could Not Read From The School Database!");
            }
        }

        public static void createTableTempTable()
        {
            string table = @"CREATE TABLE `stud_balance_temp_table` (
	`id` BIGINT(255) NOT NULL AUTO_INCREMENT,
	`admin_no` BIGINT(255) NOT NULL DEFAULT '0',
	`name` VARCHAR(255) NOT NULL DEFAULT '--',
	`class` VARCHAR(255) NOT NULL DEFAULT '--',
	`stream` VARCHAR(255) NOT NULL DEFAULT '--',
	`fee_amount` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`fee_exemption` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`fee_penalty` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`amount_paid` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`balance` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`overpay` DECIMAL(10,2) NOT NULL DEFAULT '0',
	`refund` DECIMAL(10,2) NOT NULL DEFAULT '0',
	PRIMARY KEY (`id`)
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
;";
            string query = "SHOW TABLES LIKE 'stud_balance_temp_table';";
            if (qread(ref query))
            {
                if (dbreader.RecordsAffected == 0)
                {
                    if (qwrite(table))
                    {
                    }
                }
            }
        }
    }
}