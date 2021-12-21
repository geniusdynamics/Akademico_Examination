using System;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmSubjectPerformanceGeneral
    {
        public frmSubjectPerformanceGeneral()
        {
            InitializeComponent();
            _btnCancel.Name = "btnCancel";
            _btnClear.Name = "btnClear";
            _btnMeanMarkAnalysis.Name = "btnMeanMarkAnalysis";
            _Button2.Name = "Button2";
            _Button3.Name = "Button3";
            _Button1.Name = "Button1";
            _btnAnalyze.Name = "btnAnalyze";
            _btnAddExam.Name = "btnAddExam";
            _txtContribution.Name = "txtContribution";
            _cboExamName.Name = "cboExamName";
            _cboTerm.Name = "cboTerm";
            _chkMode.Name = "chkMode";
        }

        private void frmSubjectPerformanceGeneral_Load(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(!publicSubsNFunctions.connect(), !publicSubsNFunctions.get_subjects()), !publicSubsNFunctions.dbNewOpen())))
            {
                Close();
            }
            else
            {
                publicSubsNFunctions.get_grades();
                Button2.Enabled = false;
                grpSelect.Enabled = true;
                grpAnalyze.Enabled = false;
                var argcbo = cboYear;
                publicSubsNFunctions.fill_years(ref argcbo);
                cboYear = argcbo;
                cboYear.SelectedItem = DateAndTime.Today.Year;
                publicSubsNFunctions.get_term();
                cboTerm.SelectedItem = publicSubsNFunctions.term;
                chkBestOf7.Visible = !publicSubsNFunctions.IsPrimary();
                radSubject.Visible = chkBestOf7.Visible;
                btnAddExam.Enabled = false;
                txtContribution.Enabled = false;
                grpMultiExaminations.Enabled = true;
                publicSubsNFunctions.mode = false;
                publicSubsNFunctions.analysis_mode = false;
            }

            int totalWidth = lstExaminations.Width;
            lstExaminations.Columns[0].Width = (int)Math.Round(totalWidth * (40d / 100d));
            int colWidth = (int)Math.Round(totalWidth * (60d / 100d) / 4d);
            for (int k = 1, loopTo = lstExaminations.Columns.Count - 1; k <= loopTo; k++)
                lstExaminations.Columns[k].Width = colWidth;
        }

        private object isvalid()
        {
            if ((cboYear.SelectedItem.ToString() ?? "") == (publicSubsNFunctions.None ?? ""))
            {
                publicSubsNFunctions.msg = "failure Choice For Year!";
                return false;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboTerm.SelectedItem, publicSubsNFunctions.None, false)))
            {
                publicSubsNFunctions.msg = "failure Choice For Term!";
                return false;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboExamName.SelectedItem, publicSubsNFunctions.None, false)))
            {
                publicSubsNFunctions.msg = "failure Choice For Examination Name!";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void analyze()
        {
            grpSelect.Enabled = false;
            grpAnalyze.Enabled = true;
            Button2.Enabled = true;
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isvalid()))
            {
                if (chkMode.Checked)
                {
                    publicSubsNFunctions.yrs = new object[lstExaminations.Items.Count];
                    publicSubsNFunctions.tms = new object[lstExaminations.Items.Count];
                    publicSubsNFunctions.exam_names = new object[lstExaminations.Items.Count];
                    publicSubsNFunctions.contribution = new int[lstExaminations.Items.Count];
                    publicSubsNFunctions.total_mark = new int[lstExaminations.Items.Count];
                    for (int k = 0, loopTo = lstExaminations.Items.Count - 1; k <= loopTo; k++)
                    {
                        publicSubsNFunctions.exam_names[k] = lstExaminations.Items[k].Text;
                        publicSubsNFunctions.contribution[k] = Conversions.ToInteger(lstExaminations.Items[k].SubItems[1].Text);
                        publicSubsNFunctions.yrs[k] = lstExaminations.Items[k].SubItems[2].Text;
                        publicSubsNFunctions.tms[k] = lstExaminations.Items[k].SubItems[3].Text;

                        // todo I have set the total_mark to a constant 100 original code is below
                        // total_mark(k) = 100

                        publicSubsNFunctions.total_mark[k] = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(Conversions.ToString(publicSubsNFunctions.exam_names[k]), Conversions.ToString(publicSubsNFunctions.tms[k]), Conversions.ToString(publicSubsNFunctions.yrs[k])));
                    }
                }
                else
                {
                    publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
                    publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
                }

                analyze();
            }
            else
            {
                publicSubsNFunctions.failure(publicSubsNFunctions.msg);
            }
        }

        private void get_details()
        {
            publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
            publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
            publicSubsNFunctions.exam_name = Conversions.ToString(cboExamName.SelectedItem);
            publicSubsNFunctions.marks = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(Conversions.ToString(cboExamName.SelectedItem), publicSubsNFunctions.tm));
            // todo modified marks set it to a constant 100 the original code is commented above

            // marks = 100
            publicSubsNFunctions.table = "exam_results";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            get_details();
            create_report2();
        }

        private void create_report2()
        {
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)prepare_class_list2();
            printpreview.Document = print_document;
            printpreview.ShowDialog();
            // print_document.Print()
        }

        private void create_report3()
        {
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)prepare_class_list3();
            printpreview.Document = print_document;
            printpreview.ShowDialog();
            // print_document.Print()
        }

        private object prepare_class_list2()
        {
            var print_document = new PrintDocument();
            var margin = new Margins(10, 10, 10, 10);
            print_document.DefaultPageSettings.Landscape = false;
            print_document.DefaultPageSettings.Margins = margin;
            print_document.PrintPage += print_class_list2;
            return print_document;
        }

        private object prepare_class_list3()
        {
            var print_document = new PrintDocument();
            var margin = new Margins(10, 10, 10, 10);
            print_document.DefaultPageSettings.Landscape = false;
            print_document.DefaultPageSettings.Margins = margin;
            print_document.PrintPage += print_class_list3;
            return print_document;
        }

        private void classes()
        {
            string argq = "SELECT distinct(class) as class FROM class_stream";
            if (publicSubsNFunctions.qread(ref argq))
            {
                words = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                int i = 0;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    words[i] = Conversions.ToString(publicSubsNFunctions.dbreader["class"]);
                    i += 1;
                }

                publicSubsNFunctions.dbreader.Close();
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Load Classes!");
            }
        }

        private void fill_stream(string str)
        {
            string argq = "SELECT stream FROM class_stream WHERE `class`='" + publicSubsNFunctions.escape_string(str) + "'";
            if (publicSubsNFunctions.qread(ref argq))
            {
                publicSubsNFunctions.streams = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                int i = 0;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    publicSubsNFunctions.streams[i] = Conversions.ToString(publicSubsNFunctions.dbreader["stream"]);
                    i += 1;
                }

                publicSubsNFunctions.dbreader.Close();
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Load Streams For Class " + str);
            }
        }

        private string[] words;
        private int mp, totalmp, totalentries, entries, mm;
        private int[] total;

        private void genders()
        {
            string argq = "SELECT DISTINCT Gender FROM students";
            publicSubsNFunctions.qread(ref argq);
            sex = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            int i = 0;
            while (publicSubsNFunctions.dbreader.Read())
            {
                sex[i] = Conversions.ToString(publicSubsNFunctions.dbreader["Gender"]);
                i += 1;
            }
        }

        private string[] sex;

        private void print_class_list2(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds);
            int line = 30;
            int topline = line;
            int left_margin = 20;
            int right_margin = 810;
            int col = 50;
            try
            {
                e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + publicSubsNFunctions.logo()), left_margin + 10, line, 100, 100);
                line += 15;
            }
            catch (Exception ex)
            {
            }

            // line + 20 uncommented
            line += 20;
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

            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("GENDER BASED PERFORMANCE ANALYSIS", publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString("GENDER BASED PERFORMANCE ANALYSIS", publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.exam_name + " Term ", cboTerm.SelectedItem), " "), cboYear.SelectedItem)), publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.exam_name + " Term ", cboTerm.SelectedItem), " "), cboYear.SelectedItem)), publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            classes();
            genders();
            publicSubsNFunctions.wait("Complex Computation ...");
            for (int c = 0, loopTo = words.Length - 1; c <= loopTo; c++)
            {
                fill_stream(words[c]);
                for (int s = 0, loopTo1 = publicSubsNFunctions.streams.Length - 1; s <= loopTo1; s++)
                {
                    e.Graphics.DrawString(words[c].ToUpper() + " " + publicSubsNFunctions.streams[s], publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                    line += publicSubsNFunctions.smallfont.Height + 2;
                    topline = line;
                    e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                    e.Graphics.DrawString("GENDER   ", publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                    col = 103;
                    for (int k = 0, loopTo2 = publicSubsNFunctions.grades.Length - 1; k <= loopTo2; k++)
                    {
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col + 4, line);
                        col += 35;
                    }

                    e.Graphics.DrawString("ENTRY", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    e.Graphics.DrawString("M.P.", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    e.Graphics.DrawString("M.G.", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    e.Graphics.DrawString("M.M.", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    line += publicSubsNFunctions.smallfont.Height + 2;
                    e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                    for (int count = 0, loopTo3 = sex.Length - 1; count <= loopTo3; count++)
                    {
                        col = 103;
                        for (int k = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; k <= loopTo4; k++)
                        {
                            e.Graphics.DrawString(Conversions.ToString(gradeno(Conversions.ToString(publicSubsNFunctions.grades[k]), sex[count], publicSubsNFunctions.streams[s], words[c])), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col + 4, line);
                            col += 35;
                        }

                        e.Graphics.DrawString(g_entry.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                        col += 50;
                        var mean = mean_p(string.Empty, sex[count], publicSubsNFunctions.streams[s], words[c]);
                        e.Graphics.DrawString(Conversions.ToString(mean), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                        col += 50;
                        try
                        {
                            e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(mean))), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                        }
                        catch (Exception ex)
                        {
                            e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                        }

                        col += 50;
                        mean = meanmark(sex[count], publicSubsNFunctions.streams[s], words[c]);
                        e.Graphics.DrawString(Conversions.ToString(mean), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                        g_mp = 0;
                        g_entry = 0;
                        mean = 0;
                        e.Graphics.DrawString(sex[count].Substring(0, 1), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 10, line);
                        line += publicSubsNFunctions.smallfont.Height + 2;
                        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                        e.Graphics.DrawLine(Pens.Black, left_margin, topline, left_margin, line);
                    }

                    col = 103;
                    for (int k = 0, loopTo5 = publicSubsNFunctions.grades.Length - 1; k <= loopTo5; k++)
                    {
                        e.Graphics.DrawLine(Pens.Black, left_margin + col, topline, left_margin + col, line);
                        col += 35;
                    }

                    e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line);
                    col += 50;
                    e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line);
                    col += 50;
                    e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line);
                    col += 50;
                    e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line);
                    e.Graphics.DrawLine(Pens.Black, right_margin, topline, right_margin, line);
                    line += 10;
                }

                line += 20;
            }

            e.Graphics.DrawString(DateAndTime.Today.Date.Date + " " + DateAndTime.Now.Hour + ":" + DateAndTime.Now.Minute + ":" + DateAndTime.Now.Second, publicSubsNFunctions.smallfont, Brushes.Black, left_margin - 80, line);
        }

        private string[] category;

        private void categories()
        {
            string argq = "SELECT studentcategory FROM studentCategory";
            publicSubsNFunctions.qread(ref argq);
            category = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            int i = 0;
            while (publicSubsNFunctions.dbreader.Read())
            {
                category[i] = Conversions.ToString(publicSubsNFunctions.dbreader["studentcategory"]);
                i += 1;
            }
        }

        private void print_class_list3(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds);
            int line = 30;
            int topline = line;
            int left_margin = 20;
            int right_margin = 810;
            int col = 50;
            try
            {
                e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + publicSubsNFunctions.logo()), left_margin + 10, line, 100, 100);
                line += 15;
            }
            catch (Exception ex)
            {
            }

            line += 20;
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

            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("CATEGORICAL PERFORMANCE ANALYSIS", publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString("CATEGORICAL PERFORMANCE ANALYSIS", publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.exam_name + " Term: ", cboTerm.SelectedItem), " "), cboYear.SelectedItem)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 150, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            classes();
            categories();
            publicSubsNFunctions.wait("Complex Computation ...");
            for (int c = 0, loopTo = words.Length - 1; c <= loopTo; c++)
            {
                fill_stream(words[c]);
                for (int s = 0, loopTo1 = publicSubsNFunctions.streams.Length - 1; s <= loopTo1; s++)
                {
                    publicSubsNFunctions.wait("Computing " + words[c] + " " + publicSubsNFunctions.streams[s] + "...");
                    e.Graphics.DrawString(words[c].ToUpper() + " " + publicSubsNFunctions.streams[s], publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                    line += publicSubsNFunctions.smallfont.Height + 2;
                    topline = line;
                    e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                    e.Graphics.DrawString("CATEGORY   ", publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                    col = 103;
                    for (int k = 0, loopTo2 = publicSubsNFunctions.grades.Length - 1; k <= loopTo2; k++)
                    {
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col + 4, line);
                        col += 35;
                    }

                    e.Graphics.DrawString("ENTRY", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    e.Graphics.DrawString("M.P.", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    e.Graphics.DrawString("M.G.", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    e.Graphics.DrawString("M.M.", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    line += publicSubsNFunctions.smallfont.Height + 2;
                    e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                    for (int m = 0, loopTo3 = category.Length - 1; m <= loopTo3; m++)
                    {
                        col = 103;
                        for (int k = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; k <= loopTo4; k++)
                        {
                            e.Graphics.DrawString(Conversions.ToString(gradeno(Conversions.ToString(publicSubsNFunctions.grades[k]), category[m], publicSubsNFunctions.streams[s], words[c])), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col + 4, line);
                            col += 35;
                        }

                        e.Graphics.DrawString(g_entry.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                        col += 50;
                        var mean = mean_p3(string.Empty, category[m], publicSubsNFunctions.streams[s], words[c]);
                        e.Graphics.DrawString(Conversions.ToString(mean), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                        col += 50;
                        try
                        {
                            e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(mean))), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                        }
                        catch (Exception ex)
                        {
                            e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                        }

                        col += 50;
                        mean = meanmark3(category[m], publicSubsNFunctions.streams[s], words[c]);
                        e.Graphics.DrawString(Conversions.ToString(mean), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                        g_mp = 0;
                        g_entry = 0;
                        mean = 0;
                        e.Graphics.DrawString(category[m], publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 10, line);
                        line += publicSubsNFunctions.smallfont.Height + 2;
                        e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                        e.Graphics.DrawLine(Pens.Black, left_margin, topline, left_margin, line);
                    }

                    col = 103;
                    for (int k = 0, loopTo5 = publicSubsNFunctions.grades.Length - 1; k <= loopTo5; k++)
                    {
                        e.Graphics.DrawLine(Pens.Black, left_margin + col, topline, left_margin + col, line);
                        col += 35;
                    }

                    e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line);
                    col += 50;
                    e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line);
                    col += 50;
                    e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line);
                    col += 50;
                    e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline, left_margin + col - 4, line);
                    e.Graphics.DrawLine(Pens.Black, right_margin, topline, right_margin, line);
                    line += 10;
                }

                line += 20;
            }

            e.Graphics.DrawString(DateAndTime.Today.Date.Date + " " + DateAndTime.Now.Hour + ":" + DateAndTime.Now.Minute + ":" + DateAndTime.Now.Second, publicSubsNFunctions.smallfont, Brushes.Black, left_margin - 80, line);
        }

        private object mean_p(string grade, string gender, string s, string cls)
        {
            string[] all_grades;
            string[] admnos;
            int cnt = 0;
            if (chkBestOf7.Checked)
            {
                if (radSubject.Checked)
                {
                    sum = "B7SB_TP";
                }
                else
                {
                    sum = "B7NSB_TP";
                }
            }
            else if (radSubject.Checked)
            {
                sum = "SB_TP";
            }
            else
            {
                sum = "NSB_TP";
            }

            string argq = "SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE (Stream='" + publicSubsNFunctions.escape_string(s) + "' AND class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "')";
            publicSubsNFunctions.qread(ref argq);
            int i = 0;
            all_grades = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            admnos = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            while (publicSubsNFunctions.dbreader.Read())
            {
                cnt = 0;
                if (Information.IsNumeric(publicSubsNFunctions.dbreader[sum]))
                {
                    admnos[i] = Conversions.ToString(publicSubsNFunctions.dbreader["ADMNo"]);
                    for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                    {
                        if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k])))
                        {
                            cnt += 1;
                        }
                    }

                    if (chkBestOf7.Checked)
                    {
                        all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], 7))));
                    }
                    else
                    {
                        all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], cnt))));
                    }

                    i += 1;
                }
            }

            cnt = 0;
            for (int k = 0, loopTo1 = admnos.Length - 1; k <= loopTo1; k++)
            {
                if (Conversions.ToBoolean(isgender(admnos[k], gender)))
                {
                    g_mp = Conversions.ToInteger(g_mp + publicSubsNFunctions.fix_point(all_grades[k]));
                    cnt += 1;
                }
            }

            if (cnt == 0 | g_mp == 0)
            {
                return "--";
            }
            else
            {
                return Strings.Format(g_mp / (double)cnt, "0.00");
            }
        }

        private object mean_p3(string grade, string gender, string s, string cls)
        {
            string[] all_grades;
            string[] admnos;
            int cnt = 0;
            if (chkBestOf7.Checked)
            {
                if (radSubject.Checked)
                {
                    sum = "B7SB_TP";
                }
                else
                {
                    sum = "B7NSB_TP";
                }
            }
            else if (radSubject.Checked)
            {
                sum = "SB_TP";
            }
            else
            {
                sum = "NSB_TP";
            }

            string argq = "SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE (Stream='" + s + "' AND class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "')";
            publicSubsNFunctions.qread(ref argq);
            int i = 0;
            all_grades = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            admnos = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            while (publicSubsNFunctions.dbreader.Read())
            {
                cnt = 0;
                if (Information.IsNumeric(publicSubsNFunctions.dbreader[sum]))
                {
                    admnos[i] = Conversions.ToString(publicSubsNFunctions.dbreader["ADMNo"]);
                    for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                    {
                        if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k])))
                        {
                            cnt += 1;
                        }
                    }

                    if (chkBestOf7.Checked)
                    {
                        all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], 7))));
                    }
                    else
                    {
                        all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], cnt))));
                    }

                    i += 1;
                }
            }

            publicSubsNFunctions.dbreader.Close();
            cnt = 0;
            for (int k = 0, loopTo1 = admnos.Length - 1; k <= loopTo1; k++)
            {
                if (Conversions.ToBoolean(isgender3(admnos[k], gender)))
                {
                    g_mp = Conversions.ToInteger(g_mp + publicSubsNFunctions.fix_point(all_grades[k]));
                    cnt += 1;
                }
            }

            if (cnt == 0)
            {
                return "--";
            }
            else
            {
                return Strings.Format(g_mp / (double)cnt, "0.00");
            }
        }

        private object meanmark3(string gender, string s, string cls)
        {
            string[] admnos;
            var cnt = default(int);
            if (chkBestOf7.Checked)
            {
                sum = "B7_Total";
            }
            else
            {
                sum = "Total";
            }

            string argq = "SELECT `" + sum + "`, `ADMNo` FROM `" + publicSubsNFunctions.table + "` WHERE (Stream='" + s + "' AND class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "')";
            publicSubsNFunctions.qread(ref argq);
            int i = 0;
            totals = new int[publicSubsNFunctions.dbreader.RecordsAffected];
            admnos = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            while (publicSubsNFunctions.dbreader.Read())
            {
                if (Information.IsNumeric(publicSubsNFunctions.dbreader[sum]))
                {
                    admnos[i] = Conversions.ToString(publicSubsNFunctions.dbreader["ADMNo"]);
                    totals[i] = Conversions.ToInteger(publicSubsNFunctions.dbreader[sum]);
                    i += 1;
                }
            }

            publicSubsNFunctions.dbreader.Close();
            g_mp = 0;
            for (int k = 0, loopTo = admnos.Length - 1; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(isgender3(admnos[k], gender)))
                {
                    g_mp += totals[k];
                    cnt += 1;
                }
            }

            if (g_mp == 0 | cnt == 0)
            {
                return "--";
            }
            else
            {
                return Strings.Format(g_mp / (double)cnt, "0.00");
            }
        }

        private object meanmark(string gender, string s, string cls)
        {
            string[] admnos;
            var cnt = default(int);
            if (chkBestOf7.Checked)
            {
                sum = "B7_Total";
            }
            else
            {
                sum = "Total";
            }

            string argq = "SELECT `" + sum + "`, `ADMNo` FROM `" + publicSubsNFunctions.table + "` WHERE (Stream='" + s + "' AND class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "')";
            publicSubsNFunctions.qread(ref argq);
            int i = 0;
            totals = new int[publicSubsNFunctions.dbreader.RecordsAffected];
            admnos = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            while (publicSubsNFunctions.dbreader.Read())
            {
                if (Information.IsNumeric(publicSubsNFunctions.dbreader[sum]))
                {
                    admnos[i] = Conversions.ToString(publicSubsNFunctions.dbreader["ADMNo"]);
                    totals[i] = Conversions.ToInteger(publicSubsNFunctions.dbreader[sum]);
                    i += 1;
                }
            }

            publicSubsNFunctions.dbreader.Close();
            g_mp = 0;
            for (int k = 0, loopTo = admnos.Length - 1; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(isgender(admnos[k], gender)))
                {
                    g_mp += totals[k];
                    cnt += 1;
                }
            }

            if (g_mp == 0 | cnt == 0)
            {
                return "--";
            }
            else
            {
                return Strings.Format(g_mp / (double)cnt, "0.00");
            }
        }

        private int g_entry, g_mp;
        private int[] totals;
        private string sum;

        private object gradeno(string grade, string gender, string s, string cls)
        {
            object gradenoRet = default;
            string[] all_grades;
            string[] admnos;
            gradenoRet = 0;
            if (gender.ToLower() != "male" & gender.ToLower() != "female")
            {
                if (!publicSubsNFunctions.mode)
                {
                    if (chkBestOf7.Checked)
                    {
                        if (radSubject.Checked)
                        {
                            sum = "B7SB_TP";
                        }
                        else
                        {
                            sum = "B7NSB_TP";
                        }
                    }
                    else if (radSubject.Checked)
                    {
                        sum = "SB_TP";
                    }
                    else
                    {
                        sum = "NSB_TP";
                    }

                    string argq = "SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE (Stream='" + publicSubsNFunctions.escape_string(s) + "' AND class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "')";
                    publicSubsNFunctions.qread(ref argq);
                    int i = 0;
                    int count = 0;
                    all_grades = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                    admnos = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        count = 0;
                        for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                        {
                            if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k])))
                            {
                                count += 1;
                            }
                        }

                        if (Information.IsNumeric(publicSubsNFunctions.dbreader[sum]))
                        {
                            admnos[i] = Conversions.ToString(publicSubsNFunctions.dbreader["ADMNo"]);
                            if (chkBestOf7.Checked)
                            {
                                all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], 7))));
                            }
                            else
                            {
                                all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], count))));
                            }

                            i += 1;
                        }
                    }

                    for (int k = 0, loopTo1 = admnos.Length - 1; k <= loopTo1; k++)
                    {
                        if (Conversions.ToBoolean(isgender3(admnos[k], gender)))
                        {
                            if ((all_grades[k] ?? "") == (grade ?? ""))
                            {
                                gradenoRet += 1;
                                g_entry += 1;
                            }
                        }
                    }

                    return gradenoRet;
                }
                else
                {
                    string largest_table = LargestTable(cls);
                    if (chkBestOf7.Checked)
                    {
                        if (radSubject.Checked)
                        {
                            sum = "B7SB_TP";
                        }
                        else
                        {
                            sum = "B7NSB_TP";
                        }
                    }
                    else if (radSubject.Checked)
                    {
                        sum = "SB_TP";
                    }
                    else
                    {
                        sum = "NSB_TP";
                    }

                    var studs = new object[large][];
                    for (int k = 0, loopTo2 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo2; k++)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.exam_names[k], largest_table, false)))
                        {
                            string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ADMNo, `" + sum + "` FROM `exam_results` WHERE (Stream='" + publicSubsNFunctions.escape_string(s) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND Class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "');"));
                            publicSubsNFunctions.qread(ref argq1);
                            studs[publicSubsNFunctions.dbreader.RecordsAffected - 1] = new object[3];
                            for (int k1 = 0, loopTo3 = studs.Length - 1; k1 <= loopTo3; k1++)
                            {
                                studs[k1] = new object[3];
                                for (int c = 0, loopTo4 = studs[k1].Length - 1; c <= loopTo4; c++)
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

                    for (int k = 0, loopTo5 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo5; k++)
                    {
                        string argq2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `exam_results` WHERE (Stream='" + publicSubsNFunctions.escape_string(s) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND Class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "');"));
                        publicSubsNFunctions.qread(ref argq2);
                        while (publicSubsNFunctions.dbreader.Read())
                        {
                            for (int c = 0, loopTo6 = studs.Length - 1; c <= loopTo6; c++)
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[c][0], publicSubsNFunctions.dbreader["ADMNo"], false)))
                                {
                                    if (k > 0)
                                    {
                                        studs[c][1] += publicSubsNFunctions.dbreader[sum];
                                    }
                                    else
                                    {
                                        studs[c][1] = publicSubsNFunctions.dbreader[sum];
                                    }

                                    for (int st = 0, loopTo7 = publicSubsNFunctions.subjabb.Length - 1; st <= loopTo7; st++)
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

                    for (int k = 0, loopTo8 = studs.Length - 1; k <= loopTo8; k++)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(studs[k][1], 0, false)))
                        {
                            if (chkBestOf7.Checked)
                            {
                                studs[k][1] = publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(studs[k][1], 7)));
                            }
                            else
                            {
                                studs[k][1] = publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(studs[k][1], studs[k][2])));
                            }
                        }
                    }

                    for (int k = 0, loopTo9 = studs.Length - 1; k <= loopTo9; k++)
                    {
                        if (Conversions.ToBoolean(isgender3(Conversions.ToString(studs[k][0]), gender)))
                        {
                            // todo added a try catch statement here at times studs(k)(1) evaluates to a number
                            try
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[k][1], grade, false)))
                                {
                                    gradenoRet += 1;
                                    g_entry += 1;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }

                    return gradenoRet;
                }
            }
            else if (!publicSubsNFunctions.mode)
            {
                if (chkBestOf7.Checked)
                {
                    if (radSubject.Checked)
                    {
                        sum = "B7SB_TP";
                    }
                    else
                    {
                        sum = "B7NSB_TP";
                    }
                }
                else if (radSubject.Checked)
                {
                    sum = "SB_TP";
                }
                else
                {
                    sum = "NSB_TP";
                }

                string argq3 = "SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE (Stream='" + publicSubsNFunctions.escape_string(s) + "' AND class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "')";
                publicSubsNFunctions.qread(ref argq3);
                int i = 0;
                int count = 0;
                all_grades = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                admnos = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                while (publicSubsNFunctions.dbreader.Read())
                {
                    count = 0;
                    for (int k = 0, loopTo10 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo10; k++)
                    {
                        if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k])))
                        {
                            count += 1;
                        }
                    }

                    if (Information.IsNumeric(publicSubsNFunctions.dbreader[sum]))
                    {
                        admnos[i] = Conversions.ToString(publicSubsNFunctions.dbreader["ADMNo"]);
                        if (chkBestOf7.Checked)
                        {
                            all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], 7))));
                        }
                        else
                        {
                            all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], count))));
                        }

                        i += 1;
                    }
                }

                for (int k = 0, loopTo11 = admnos.Length - 1; k <= loopTo11; k++)
                {
                    if (Conversions.ToBoolean(isgender(admnos[k], gender)))
                    {
                        if ((all_grades[k] ?? "") == (grade ?? ""))
                        {
                            gradenoRet += 1;
                            g_entry += 1;
                        }
                    }
                }

                return gradenoRet;
            }
            else
            {
                string largest_table = LargestTable(cls);
                if (chkBestOf7.Checked)
                {
                    if (radSubject.Checked)
                    {
                        sum = "B7SB_TP";
                    }
                    else
                    {
                        sum = "B7NSB_TP";
                    }
                }
                else if (radSubject.Checked)
                {
                    sum = "SB_TP";
                }
                else
                {
                    sum = "NSB_TP";
                }

                var studs = new object[large][];
                for (int k = 0, loopTo12 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo12; k++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.exam_names[k], largest_table, false)))
                    {
                        string argq4 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ADMNo, `" + sum + "` FROM `exam_results` WHERE (Stream='" + publicSubsNFunctions.escape_string(s) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND Class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "');"));
                        publicSubsNFunctions.qread(ref argq4);
                        studs[publicSubsNFunctions.dbreader.RecordsAffected - 1] = new object[3];
                        for (int k1 = 0, loopTo13 = studs.Length - 1; k1 <= loopTo13; k1++)
                        {
                            studs[k1] = new object[3];
                            for (int c = 0, loopTo14 = studs[k1].Length - 1; c <= loopTo14; c++)
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

                for (int k = 0, loopTo15 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo15; k++)
                {
                    string argq5 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `exam_results` WHERE (Stream='" + publicSubsNFunctions.escape_string(s) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND Class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "');"));
                    publicSubsNFunctions.qread(ref argq5);
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        for (int c = 0, loopTo16 = studs.Length - 1; c <= loopTo16; c++)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[c][0], publicSubsNFunctions.dbreader["ADMNo"], false)))
                            {
                                if (k > 0)
                                {
                                    studs[c][1] += publicSubsNFunctions.dbreader[sum];
                                }
                                else
                                {
                                    studs[c][1] = publicSubsNFunctions.dbreader[sum];
                                }

                                for (int st = 0, loopTo17 = publicSubsNFunctions.subjabb.Length - 1; st <= loopTo17; st++)
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

                for (int k = 0, loopTo18 = studs.Length - 1; k <= loopTo18; k++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(studs[k][1], 0, false)))
                    {
                        if (chkBestOf7.Checked)
                        {
                            studs[k][1] = publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(studs[k][1], 7)));
                        }
                        else
                        {
                            studs[k][1] = publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(studs[k][1], studs[k][2])));
                        }
                    }
                }

                for (int k = 0, loopTo19 = studs.Length - 1; k <= loopTo19; k++)
                {
                    try
                    {
                        if (Conversions.ToBoolean(isgender(Conversions.ToString(studs[k][0]), gender)))
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[k][1], grade, false)))
                            {
                                gradenoRet += 1;
                                g_entry += 1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                return gradenoRet;
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

        private object isgender(string adm, string gender)
        {
            string argq = "SELECT * FROM students WHERE admin_no='" + adm + "' AND Gender='" + gender + "'";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Close();
                return true;
            }
            else
            {
                publicSubsNFunctions.dbreader.Close();
                return false;
            }
        }

        private object isgender3(string adm, string gender)
        {
            string argq = "SELECT * FROM students WHERE admin_no='" + adm + "' AND student_category='" + gender + "'";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Close();
                return true;
            }
            else
            {
                publicSubsNFunctions.dbreader.Close();
                return false;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            get_details();
            create_report();
        }

        private void create_report()
        {
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)prepare_class_list();
            printpreview.Document = print_document;
            printpreview.ShowDialog();
            // Me.Close()
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

        private void print_class_list(object sender, PrintPageEventArgs e)
        {
            int line = 20;
            int topline = line;
            int left_margin = 120;
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

            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("CLASS MEAN GRADE COUNT ANALYSIS", publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString("CLASS MEAN GRADE COUNT ANALYSIS", publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.exam_name + " Term ", cboTerm.SelectedItem), " "), cboYear.SelectedItem)), publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.exam_name + " Term ", cboTerm.SelectedItem), " "), cboYear.SelectedItem)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 150, line);
            line += 30;
            classes();
            total = new int[publicSubsNFunctions.grades.Length];
            totalmp = 0;
            int cnt;
            publicSubsNFunctions.wait("Complex Computation ...");
            for (int c = 0, loopTo = words.Length - 1; c <= loopTo; c++)
            {
                totalentries = 0;
                entries = 0;
                mp = 0;
                totalmp = 0;
                mm = 0;
                for (int k = 0, loopTo1 = publicSubsNFunctions.grades.Length - 1; k <= loopTo1; k++)
                    total[k] = 0;
                e.Graphics.DrawLine(Pens.Black, 60, line, right_margin, line);
                e.Graphics.DrawString(words[c].ToUpper(), publicSubsNFunctions.smallfont, Brushes.Black, 60f, line);
                topline = line - 20;
                left_margin = 60;
                col = 70;
                for (int k = 0, loopTo2 = publicSubsNFunctions.grades.Length - 1; k <= loopTo2; k++)
                {
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 30;
                }

                e.Graphics.DrawString("ENTRY", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                col += 50;
                e.Graphics.DrawString("M.P.", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                col += 60;
                e.Graphics.DrawString("M.GRADE", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                col += 70;
                e.Graphics.DrawString("M.MARK", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                line += 15;
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                fill_stream(words[c]);
                int column;
                for (int s = 0, loopTo3 = publicSubsNFunctions.streams.Length - 1; s <= loopTo3; s++)
                {
                    publicSubsNFunctions.wait("Computing " + words[c] + " " + publicSubsNFunctions.streams[s] + "...");
                    totalentries += entries;
                    entries = 0;
                    column = 73;
                    totalmp += mp;
                    mp = 0;
                    e.Graphics.DrawString(publicSubsNFunctions.streams[s].ToUpper(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                    for (int k = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; k <= loopTo4; k++)
                    {
                        cnt = no_of_grades(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.streams[s], words[c]);
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

                    column += 70;
                    e.Graphics.DrawString(Conversions.ToString(mean_mark(publicSubsNFunctions.streams[s], words[c])), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    line += 15;
                    e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                    if (s == publicSubsNFunctions.streams.Length - 1)
                    {
                        totalmp += mp;
                        totalentries += entries;
                    }
                }

                e.Graphics.DrawString("TOTAL", publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                column = 73;
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

                column += 70;
                e.Graphics.DrawString(Conversions.ToString(mean_mark_total(words[c])), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                line += 15;
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                e.Graphics.DrawLine(Pens.Black, left_margin, topline + publicSubsNFunctions.smallfont.Height + 8, left_margin, line);
                col = 70;
                for (int k = 0, loopTo6 = publicSubsNFunctions.grades.Length - 1; k <= loopTo6; k++)
                {
                    e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height + 8, left_margin + col - 4, line);
                    col += 30;
                }

                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height + 8, left_margin + col - 4, line);
                col += 50;
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height + 8, left_margin + col - 4, line);
                col += 60;
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height + 8, left_margin + col - 4, line);
                col += 70;
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height + 8, left_margin + col - 4, line);
                e.Graphics.DrawLine(Pens.Black, right_margin, topline + publicSubsNFunctions.smallfont.Height + 8, right_margin, line);
                line += 25;
            }

            e.Graphics.DrawString(DateAndTime.Today.Date.Date + " " + DateAndTime.Now.Hour + ":" + DateAndTime.Now.Minute + ":" + DateAndTime.Now.Second, publicSubsNFunctions.smallfont, Brushes.Black, left_margin - 80, line);
        }

        private object mean_mark_total(string cls)
        {
            mm = 0;
            if (chkBestOf7.Checked)
            {
                sum = "B7_Total";
            }
            else
            {
                sum = "Total";
            }

            string argq = "SELECT `" + sum + "` FROM `" + publicSubsNFunctions.table + "` WHERE (Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "')";
            publicSubsNFunctions.qread(ref argq);
            var cnt = default(int);
            while (publicSubsNFunctions.dbreader.Read())
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(publicSubsNFunctions.dbreader[sum], 0, false)))
                {
                    mm = Conversions.ToInteger(mm + publicSubsNFunctions.dbreader[sum]);
                    cnt += 1;
                }
            }

            if (cnt == 0 | mm == 0)
            {
                return "--";
            }
            else
            {
                return Strings.Format(mm / (double)cnt, "0.00");
            }
        }

        private object mean_mark(string s, string cls)
        {
            mm = 0;
            if (chkBestOf7.Checked)
            {
                sum = "B7_Total";
            }
            else
            {
                sum = "Total";
            }

            string argq = "SELECT `" + sum + "` FROM `" + publicSubsNFunctions.table + "` WHERE (Stream='" + s + "' AND class='" + publicSubsNFunctions.escape_string(cls) + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "')";
            publicSubsNFunctions.qread(ref argq);
            var cnt = default(int);
            while (publicSubsNFunctions.dbreader.Read())
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(publicSubsNFunctions.dbreader[sum], 0, false)))
                {
                    mm = Conversions.ToInteger(mm + publicSubsNFunctions.dbreader[sum]);
                    cnt += 1;
                }
            }

            if (cnt == 0 | mm == 0)
            {
                return "--";
            }
            else
            {
                return Strings.Format(mm / (double)cnt, "0.00");
            }
        }

        private int no_of_grades(string grade, string stream, string cls)
        {
            int no_of_gradesRet = default;
            string[] all_grades;
            no_of_gradesRet = 0;
            if (!publicSubsNFunctions.mode)
            {
                if (chkBestOf7.Checked)
                {
                    if (radSubject.Checked)
                    {
                        sum = "B7SB_TP";
                    }
                    else
                    {
                        sum = "B7NSB_TP";
                    }
                }
                else if (radSubject.Checked)
                {
                    sum = "SB_TP";
                }
                else
                {
                    sum = "NSB_TP";
                }

                string argq = "SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE (Stream='" + stream + "' AND class='" + cls + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "')";
                publicSubsNFunctions.qread(ref argq);
                int i = 0;
                int count;
                all_grades = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                while (publicSubsNFunctions.dbreader.Read())
                {
                    count = publicSubsNFunctions.subjabb.Length;
                    if (Information.IsNumeric(publicSubsNFunctions.dbreader[sum]))
                    {
                        for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), "-", false)))
                            {
                                count -= 1;
                            }
                        }

                        if (chkBestOf7.Checked)
                        {
                            all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], 7))));
                        }
                        else
                        {
                            all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], count))));
                        }

                        i += 1;
                    }
                }

                for (int k = 0, loopTo1 = all_grades.Length - 1; k <= loopTo1; k++)
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
                if (chkBestOf7.Checked)
                {
                    if (radSubject.Checked)
                    {
                        sum = "B7SB_TP";
                    }
                    else
                    {
                        sum = "B7NSB_TP";
                    }
                }
                else if (radSubject.Checked)
                {
                    sum = "SB_TP";
                }
                else
                {
                    sum = "NSB_TP";
                }

                var studs = new object[large][];
                for (int k = 0, loopTo2 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo2; k++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.exam_names[k], largest_table, false)))
                    {
                        string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ADMNo, `" + sum + "` FROM `exam_results` WHERE (Stream='" + publicSubsNFunctions.escape_string(stream) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND Class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "');"));
                        publicSubsNFunctions.qread(ref argq1);
                        studs[publicSubsNFunctions.dbreader.RecordsAffected - 1] = new object[3];
                        for (int k1 = 0, loopTo3 = studs.Length - 1; k1 <= loopTo3; k1++)
                        {
                            studs[k1] = new object[3];
                            for (int c = 0, loopTo4 = studs[k1].Length - 1; c <= loopTo4; c++)
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

                for (int k = 0, loopTo5 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo5; k++)
                {
                    string argq2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `exam_results` WHERE (Stream='" + publicSubsNFunctions.escape_string(stream) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND Class='" + publicSubsNFunctions.escape_string(cls) + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "');"));
                    publicSubsNFunctions.qread(ref argq2);
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        for (int c = 0, loopTo6 = studs.Length - 1; c <= loopTo6; c++)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[c][0], publicSubsNFunctions.dbreader["ADMNo"], false)))
                            {
                                if (k > 0)
                                {
                                    studs[c][1] += publicSubsNFunctions.dbreader[sum];
                                }
                                else
                                {
                                    studs[c][1] = publicSubsNFunctions.dbreader[sum];
                                }

                                for (int st = 0, loopTo7 = publicSubsNFunctions.subjabb.Length - 1; st <= loopTo7; st++)
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

                for (int k = 0, loopTo8 = studs.Length - 1; k <= loopTo8; k++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(studs[k][1], 0, false)))
                    {
                        if (chkBestOf7.Checked)
                        {
                            studs[k][1] = publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(studs[k][1], 7)));
                        }
                        else
                        {
                            studs[k][1] = publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(studs[k][1], studs[k][2])));
                        }
                    }
                }

                for (int k = 0, loopTo9 = studs.Length - 1; k <= loopTo9; k++)
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

        private object form_name(string str)
        {
            var fname = str.Split('_');
            return fname[1];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            denalyze();
        }

        private void denalyze()
        {
            grpSelect.Enabled = true;
            grpAnalyze.Enabled = false;
            publicSubsNFunctions.mode = false;
        }

        private void cboTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboTerm.SelectedItem, publicSubsNFunctions.None, false), (cboYear.SelectedItem.ToString() ?? "") != (publicSubsNFunctions.None ?? ""))))
            {
                fill_exam();
            }
            else
            {
                cboExamName.Items.Clear();
            }
        }

        private void fill_exam()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ExamName FROM examinations WHERE Term='", cboTerm.SelectedItem), "' AND Year='"), cboYear.SelectedItem), "'"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                cboExamName.Items.Clear();
                cboExamName.Items.Add(publicSubsNFunctions.None);
                while (publicSubsNFunctions.dbreader.Read())
                    cboExamName.Items.Add(publicSubsNFunctions.dbreader["ExamName"]);
                publicSubsNFunctions.dbreader.Close();
                cboExamName.SelectedItem = publicSubsNFunctions.None;
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Load Examinations!");
                Close();
            }
        }

        private void btnMeanMarkAnalysis_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.grading = radSubject.Checked;
            publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
            publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
            publicSubsNFunctions.exam_name = Conversions.ToString(cboExamName.SelectedItem);
            get_details();
            var frm = new frmDepartmentalSubjectAnalysis();
            frm.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            get_details();
            create_report3();
        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            add_exam();
        }

        private object exists(string str)
        {
            int i;
            var loopTo = lstExaminations.Items.Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if ((lstExaminations.Items[i].Text ?? "") == (str ?? ""))
                {
                    return true;
                }
            }

            return false;
        }

        private double total_percentage;

        private void add_exam()
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboExamName.SelectedItem, publicSubsNFunctions.None, false), Information.IsNumeric(txtContribution.Text)), (txtContribution.Text ?? "") != (string.Empty ?? ""))))
            {
                if (Conversions.ToBoolean(!exists(Conversions.ToString(cboExamName.SelectedItem))))
                {
                    var li = new ListViewItem();
                    li = lstExaminations.Items.Add(cboExamName.SelectedItem);
                    li.SubItems.Add(txtContribution.Text);
                    li.SubItems.Add(cboYear.SelectedItem);
                    li.SubItems.Add(cboTerm.SelectedItem);
                    total_percentage += Conversions.ToDouble(txtContribution.Text);
                }
                else
                {
                    publicSubsNFunctions.failure("Examination Already Exists In Examination Listing");
                }
            }
        }

        private void chkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMode.Checked)
            {
                btnAddExam.Enabled = true;
                txtContribution.Enabled = true;
                grpMultiExaminations.Enabled = true;
                publicSubsNFunctions.analysis_mode = true;
                publicSubsNFunctions.mode = true;
            }
            else
            {
                lstExaminations.Items.Clear();
                btnAddExam.Enabled = false;
                txtContribution.Enabled = false;
                grpMultiExaminations.Enabled = false;
                publicSubsNFunctions.mode = false;
                publicSubsNFunctions.analysis_mode = false;
            }
        }

        private void cboExamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtContribution.Clear();
            txtContribution.Focus();
        }

        private void txtContribution_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                add_exam();
            }
        }
    }
}