using System;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmDepartmentalSubjectAnalysis
    {
        public frmDepartmentalSubjectAnalysis()
        {
            InitializeComponent();
            _btnCancel.Name = "btnCancel";
            _btnAnalyze.Name = "btnAnalyze";
        }

        private string[] words, streams;
        private int entries;

        private void frmSubjectRank_Load(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(!publicSubsNFunctions.connect(), publicSubsNFunctions.dbNewOpen())))
            {
                Close();
            }
            else
            {
                cboSubject.Items.Add(publicSubsNFunctions.None);
                for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                    cboSubject.Items.Add(publicSubsNFunctions.subjabb[k]);
                cboSubject.SelectedItem = publicSubsNFunctions.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.rank = false;
            Close();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(cboSubject.SelectedItem, publicSubsNFunctions.None, false)))
            {
                publicSubsNFunctions.rank = true;
                publicSubsNFunctions.subject = Conversions.ToString(publicSubsNFunctions.get_subject_name(Conversions.ToString(cboSubject.SelectedItem)));
                create_report();
            }
            else
            {
                publicSubsNFunctions.failure("Please Select A Subject To Analyze!");
            }
        }

        private void create_report()
        {
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)prepare_class_list();
            printpreview.Document = print_document;
            printpreview.ShowDialog();
            // print_document.Print()
        }

        private object prepare_class_list()
        {
            var print_document = new PrintDocument();
            var margin = new Margins(10, 10, 10, 10);
            print_document.DefaultPageSettings.Landscape = false;
            print_document.DefaultPageSettings.Margins = margin;
            print_document.PrintPage += print_class_list;
            return print_document;
        }

        private int mp, totalmp, totalentries;
        private int[] total;

        private void print_class_list(object sender, PrintPageEventArgs e)
        {
            int line = 20;
            int topline = line;
            int left_margin = 50;
            int right_margin = 800;
            int col = 50;
            try
            {
                e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + publicSubsNFunctions.logo()), left_margin + 10, line, 100, 100);
                line += 15;
            }
            catch (Exception ex)
            {
            }

            float CenterPage;
            if ((publicSubsNFunctions.S_NAME ?? "") != (string.Empty ?? ""))
            {
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font).Width / 2f);
                e.Graphics.DrawString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font, Brushes.Black, CenterPage, line);
                line += publicSubsNFunctions.header_font.Height + 2;
            }

            if ((publicSubsNFunctions.S_ADDRESS ?? "") != (string.Empty ?? ""))
            {
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("P.O. BOX " + publicSubsNFunctions.S_ADDRESS.ToUpper() + ", " + publicSubsNFunctions.S_LOCATION.ToUpper(), publicSubsNFunctions.other_font).Width / 2f);
                e.Graphics.DrawString("P.O. BOX " + publicSubsNFunctions.S_ADDRESS.ToUpper() + ", " + publicSubsNFunctions.S_LOCATION.ToUpper(), publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
                line += publicSubsNFunctions.other_font.Height + 5;
            }

            if ((publicSubsNFunctions.S_PHONE ?? "") != (string.Empty ?? ""))
            {
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("TELEPHONE: " + publicSubsNFunctions.S_PHONE, publicSubsNFunctions.other_font).Width / 2f);
                e.Graphics.DrawString("TELEPHONE: " + publicSubsNFunctions.S_PHONE, publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
                line += publicSubsNFunctions.other_font.Height + 5;
            }

            if ((publicSubsNFunctions.S_EMAIL ?? "") != (string.Empty ?? ""))
            {
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("EMAIL ADDRESS: " + publicSubsNFunctions.S_EMAIL, publicSubsNFunctions.other_font).Width / 2f);
                e.Graphics.DrawString("EMAIL ADDRESS: " + publicSubsNFunctions.S_EMAIL, publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
                line += publicSubsNFunctions.other_font.Height + 5;
            }

            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("DEPARTMENTAL SUBJECT ANALYSIS", publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString("DEPARTMENTAL SUBJECT ANALYSIS", publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.exam_name + "  TERM " + publicSubsNFunctions.term + "  " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString(publicSubsNFunctions.exam_name + "  TERM " + publicSubsNFunctions.term + "  " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.subject.ToUpper() + " DEPARTMENT ", publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString(publicSubsNFunctions.subject.ToUpper() + " DEPARTMENT ", publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += 25;
            classes();
            total = new int[publicSubsNFunctions.grades.Length];
            int cnt;
            publicSubsNFunctions.wait("Complex Computation ...");
            for (int c = 0, loopTo = words.Length - 1; c <= loopTo; c++)
            {
                publicSubsNFunctions.class_form = words[c];
                totalentries = 0;
                entries = 0;
                totalmp = 0;
                mp = 0;
                for (int k = 0, loopTo1 = publicSubsNFunctions.grades.Length - 1; k <= loopTo1; k++)
                    total[k] = 0;
                e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line);
                e.Graphics.DrawString("FORM", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 20, line);
                topline = line - 10;
                left_margin = 50;
                col = 150;
                for (int k = 0, loopTo2 = publicSubsNFunctions.grades.Length - 1; k <= loopTo2; k++)
                {
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 30;
                }

                e.Graphics.DrawString("ENTRY", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                col += 50;
                e.Graphics.DrawString("M.P.", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                col += 60;
                e.Graphics.DrawString("M. GRADE", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                line += 15;
                e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line);
                fill_stream(words[c]);
                int column = 103;
                for (int s = 0, loopTo3 = streams.Length - 1; s <= loopTo3; s++)
                {
                    publicSubsNFunctions.wait("Computing " + words[c] + " " + streams[s] + "...");
                    totalentries += entries;
                    entries = 0;
                    column = 150;
                    totalmp += mp;
                    mp = 0;
                    e.Graphics.DrawString(words[c].ToUpper() + " " + streams[s].ToUpper(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 20, line);
                    for (int k = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; k <= loopTo4; k++)
                    {
                        cnt = no_of_grades(Conversions.ToString(publicSubsNFunctions.grades[k]), words[c], streams[s]);
                        total[k] += cnt;
                        e.Graphics.DrawString(cnt.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                        column += 30;
                    }

                    e.Graphics.DrawString(entries.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    column += 50;
                    if (entries == 0 | mp == 0)
                    {
                        e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                        column += 60;
                        e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    }
                    else
                    {
                        e.Graphics.DrawString(Strings.Format(mp / (double)entries, "0.00"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                        column += 60;
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(mp / (double)entries)), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    }

                    line += 15;
                    e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line);
                    if (s == streams.Length - 1)
                    {
                        totalmp += mp;
                        totalentries += entries;
                    }
                }

                e.Graphics.DrawString("TOTAL", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 20, line);
                column = 150;
                for (int k = 0, loopTo5 = publicSubsNFunctions.grades.Length - 1; k <= loopTo5; k++)
                {
                    e.Graphics.DrawString(total[k].ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    column += 30;
                }

                e.Graphics.DrawString(totalentries.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                column += 50;
                if (totalmp == 0 | totalentries == 0)
                {
                    e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    column += 60;
                    e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }
                else
                {
                    e.Graphics.DrawString(Strings.Format(totalmp / (double)totalentries, "0.00"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    column += 60;
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(totalmp / (double)totalentries)), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }

                line += 15;
                e.Graphics.DrawLine(Pens.Black, left_margin + 20, line - 2, right_margin, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 20, topline + publicSubsNFunctions.smallfont.Height - 2, left_margin + 20, line);
                col = 150;
                for (int k = 0, loopTo6 = publicSubsNFunctions.grades.Length - 1; k <= loopTo6; k++)
                {
                    e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height - 2, left_margin + col - 4, line);
                    col += 30;
                }

                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height - 2, left_margin + col - 4, line);
                col += 50;
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height - 2, left_margin + col - 4, line);
                col += 60;
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height - 2, left_margin + col - 4, line);
                e.Graphics.DrawLine(Pens.Black, right_margin, topline + publicSubsNFunctions.smallfont.Height - 2, right_margin, line);
                line += 20;
            }
        }

        private int no_of_grades(string grade, string cls, string stream)
        {
            int no_of_gradesRet = default;
            string[] all_grades;
            no_of_gradesRet = 0;
            string subj = Conversions.ToString(publicSubsNFunctions.ret_subject_name(publicSubsNFunctions.subject));
            if (!publicSubsNFunctions.mode)
            {
                string argq = "SELECT `" + subj + "` FROM `" + publicSubsNFunctions.table + "` WHERE (Class='" + publicSubsNFunctions.escape_string(cls) + "' AND Stream='" + stream + "')";
                publicSubsNFunctions.qread(ref argq);
                int i = 0;
                all_grades = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                string val = Conversions.ToString(publicSubsNFunctions.ret_subject_name(publicSubsNFunctions.subject));
                while (publicSubsNFunctions.dbreader.Read())
                {
                    if (Information.IsNumeric(publicSubsNFunctions.dbreader[val]))
                    {
                        all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[val], publicSubsNFunctions.marks), 100)), publicSubsNFunctions.grading, val));
                        i += 1;
                    }
                }

                for (int k = 0, loopTo = all_grades.Length - 1; k <= loopTo; k++)
                {
                    if ((all_grades[k] ?? "") == (grade ?? ""))
                    {
                        no_of_gradesRet += 1;
                    }
                }

                entries += no_of_gradesRet;
                mp = Conversions.ToInteger(mp + Operators.MultiplyObject(no_of_gradesRet, publicSubsNFunctions.fix_point(grade)));
                return no_of_gradesRet;
            }
            else
            {
                string largest_table = LargestTable(cls);
                var studs = new object[large][];
                for (int k = 0, loopTo1 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo1; k++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.exam_names[k], largest_table, false)))
                    {
                        string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ADMNo, `" + subj + "` FROM `exam_results` WHERE (Stream='" + publicSubsNFunctions.escape_string(stream) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND Class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "');"));
                        publicSubsNFunctions.qread(ref argq1);
                        studs[publicSubsNFunctions.dbreader.RecordsAffected - 1] = new object[3];
                        for (int k1 = 0, loopTo2 = studs.Length - 1; k1 <= loopTo2; k1++)
                        {
                            studs[k1] = new object[3];
                            for (int c = 0, loopTo3 = studs[k1].Length - 1; c <= loopTo3; c++)
                                studs[k1][c] = 0;
                        }

                        int i = 0;
                        while (publicSubsNFunctions.dbreader.Read())
                        {
                            studs[i][0] = publicSubsNFunctions.dbreader["ADMNo"];
                            i += 1;
                        }

                        break;
                    }
                }

                for (int k = 0, loopTo4 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo4; k++)
                {
                    string argq2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `exam_results` WHERE (Stream='" + publicSubsNFunctions.escape_string(stream) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND Class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "');"));
                    publicSubsNFunctions.qread(ref argq2);
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        for (int c = 0, loopTo5 = studs.Length - 1; c <= loopTo5; c++)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[c][0], publicSubsNFunctions.dbreader["ADMNo"], false)))
                            {
                                if (k > 0)
                                {
                                    if (Information.IsNumeric(publicSubsNFunctions.dbreader[subj].ToString()))
                                    {
                                        studs[c][1] += Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[subj], publicSubsNFunctions.total_mark[k]), publicSubsNFunctions.contribution[k]);
                                    }
                                }
                                else if (Information.IsNumeric(publicSubsNFunctions.dbreader[subj].ToString()))
                                {
                                    studs[c][1] = Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[subj], publicSubsNFunctions.total_mark[k]), publicSubsNFunctions.contribution[k]);
                                }

                                for (int st = 0, loopTo6 = publicSubsNFunctions.subjabb.Length - 1; st <= loopTo6; st++)
                                {
                                    if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[st])))
                                    {
                                        studs[c][2] += 1;
                                    }
                                }

                                break;
                            }
                        }
                    }
                }

                for (int k = 0, loopTo7 = studs.Length - 1; k <= loopTo7; k++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(studs[k][1], 0, false)))
                    {
                        studs[k][1] = publicSubsNFunctions.get_grade(Conversions.ToDouble(studs[k][1]), publicSubsNFunctions.grading, subj);
                    }
                }

                for (int k = 0, loopTo8 = studs.Length - 1; k <= loopTo8; k++)
                {
                    if ((studs[k][1].ToString() ?? "") == (grade ?? ""))
                    {
                        no_of_gradesRet += 1;
                    }
                }

                entries += no_of_gradesRet;
                mp = Conversions.ToInteger(mp + Operators.MultiplyObject(no_of_gradesRet, publicSubsNFunctions.fix_point(grade)));
                return no_of_gradesRet;
            }
        }

        private int large = 0;

        private string LargestTable(string cls)
        {
            string LargestTableRet = default;
            LargestTableRet = null;
            large = default;
            for (int k = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo; k++)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT id FROM exam_results WHERE (class='" + publicSubsNFunctions.escape_string(cls) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "')"));
                publicSubsNFunctions.qread(ref argq);
                if (publicSubsNFunctions.dbreader.RecordsAffected > large)
                {
                    large = publicSubsNFunctions.dbreader.RecordsAffected;
                    LargestTableRet = Conversions.ToString(publicSubsNFunctions.exam_names[k]);
                }
            }

            return LargestTableRet;
        }

        private object form_name(string str)
        {
            var fname = str.Split('_');
            return fname[1];
        }

        private void classes()
        {
            string argq = "SELECT distinct class FROM class_stream";
            if (publicSubsNFunctions.qread(ref argq))
            {
                words = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                int i = 0;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    words[i] = Conversions.ToString(publicSubsNFunctions.dbreader["class"]);
                    i += 1;
                }
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Load Classes That Do/Have Done The Examinations!");
            }
        }

        private void fill_class(string str)
        {
            str.ToCharArray();
            int i, j;
            j = 0;
            bool in_word = false;
            var loopTo = str.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (Conversions.ToString(str[i]) == "=" & in_word)
                {
                    j += 1;
                    in_word = false;
                }
                else if (Conversions.ToString(str[i]) != "=" & !in_word)
                {
                    in_word = true;
                }
            }

            words = new string[j];
            j = 0;
            in_word = false;
            string temp = string.Empty;
            var loopTo1 = str.Length - 1;
            for (i = 0; i <= loopTo1; i++)
            {
                if (Conversions.ToString(str[i]) != "=")
                {
                    if (!in_word)
                    {
                        in_word = true;
                    }

                    temp += Conversions.ToString(str[i]);
                }
                else if (Conversions.ToString(str[i]) == "=")
                {
                    if (in_word)
                    {
                        in_word = false;
                        words[j] = temp;
                        temp = string.Empty;
                        j += 1;
                    }
                }
                else if (i == str.Length - 1)
                {
                    temp += Conversions.ToString(str[i]);
                    words[j] = temp;
                }
            }
        }

        private object get_stream(string field)
        {
            string argq = "SELECT `" + field + "` FROM school_details";
            if (publicSubsNFunctions.qread(ref argq))
            {
                publicSubsNFunctions.dbreader.Read();
                field = Conversions.ToString(publicSubsNFunctions.dbreader[field]);
                publicSubsNFunctions.dbreader.Close();
                return field;
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Read From School Database!");
                return false;
                return default;
            }
        }

        private void fill_stream(string str)
        {
            string argq = "SELECT stream FROM class_stream WHERE class='" + str + "'";
            publicSubsNFunctions.qread(ref argq);
            streams = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            int i = 0;
            while (publicSubsNFunctions.dbreader.Read())
            {
                streams[i] = Conversions.ToString(publicSubsNFunctions.dbreader["stream"]);
                i += 1;
            }
        }
    }
}