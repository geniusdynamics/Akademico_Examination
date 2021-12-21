using System;
using System.Drawing;
using global::System.Drawing.Printing;
using global::System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmSubjectPerformanceSpecific
    {
        public frmSubjectPerformanceSpecific()
        {
            InitializeComponent();
            _chkMode.Name = "chkMode";
            _txtContribution.Name = "txtContribution";
            _btnAddExam.Name = "btnAddExam";
            _btnAnalyze.Name = "btnAnalyze";
            _cboClass.Name = "cboClass";
            _cboExamName.Name = "cboExamName";
            _cboTerm.Name = "cboTerm";
            _cboYear.Name = "cboYear";
            _Button4.Name = "Button4";
            _radSubject.Name = "radSubject";
            _btnMeanGradeAnalysis.Name = "btnMeanGradeAnalysis";
            _btnGradesAttained.Name = "btnGradesAttained";
            _btnStudentRank.Name = "btnStudentRank";
            _btnClear.Name = "btnClear";
            _btnCancel.Name = "btnCancel";
            _bestStud.Name = "bestStud";
        }

        private bool state = false;
        private int index = 0;

        private void frmSubjectPerformance_Load(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(!publicSubsNFunctions.connect(), !publicSubsNFunctions.get_subjects()), !publicSubsNFunctions.dbNewOpen())))
            {
                Close();
            }
            else
            {
                publicSubsNFunctions.get_grades();
                grpAnalyze.Enabled = false;
                // btnAddExam.Enabled = False
                Button4.Enabled = false;
                // Button2.Enabled = False
                grpSelect.Enabled = true;
                var argcbo = cboYear;
                publicSubsNFunctions.fill_years(ref argcbo);
                cboYear = argcbo;
                cboYear.SelectedItem = DateAndTime.Today.Year;
                publicSubsNFunctions.get_term();
                state = true;
                cboTerm.SelectedItem = publicSubsNFunctions.term;
                var argcbo1 = cboClass;
                publicSubsNFunctions.load_class(ref argcbo1);
                cboClass = argcbo1;
                chkBestOf7.Visible = !publicSubsNFunctions.IsPrimary();
                radSubject.Visible = chkBestOf7.Visible;
                bestStud.Enabled = false;
            }
        }

        private void cboTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboTerm.SelectedItem, publicSubsNFunctions.None, false), state), (cboYear.SelectedItem.ToString() ?? "") != (publicSubsNFunctions.None ?? ""))))
            {
                fill_exam();
            }
            else
            {
                cboExamName.Items.Clear();
                cboClass.Items.Clear();
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

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject((cboYear.SelectedItem.ToString() ?? "") != (publicSubsNFunctions.None ?? ""), Operators.ConditionalCompareObjectNotEqual(cboTerm.SelectedItem, publicSubsNFunctions.None, false)), state)))
            {
                fill_exam();
            }
            else
            {
                cboExamName.Items.Clear();
                cboClass.Items.Clear();
            }
        }

        private void chkAnalyze_CheckedChanged(object sender, EventArgs e)
        {
            publicSubsNFunctions.mode = false;
        }

        private object isvalid()
        {
            if (chkMode.Checked)
            {
                if (lstExaminations.Items.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if ((cboYear.SelectedItem.ToString() ?? "") == (publicSubsNFunctions.None ?? ""))
            {
                publicSubsNFunctions.msg = "failure Choice For Year!";
                return false;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboTerm.SelectedItem, publicSubsNFunctions.None, false)))
            {
                publicSubsNFunctions.msg = "failure Choice For Term!";
                return false;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboExamName.SelectedItem, null, false)))
            {
                publicSubsNFunctions.msg = "failure Choice For Examination Name!";
                return false;
            }
            else if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(cboClass.SelectedItem, publicSubsNFunctions.None, false), Operators.ConditionalCompareObjectEqual(cboClass.SelectedItem, string.Empty, false))))
            {
                publicSubsNFunctions.msg = "failure Choice For Class!";
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
            // Button2.Enabled = True
            Button4.Enabled = true;
        }

        private void denalyze()
        {
            grpSelect.Enabled = true;
            grpAnalyze.Enabled = false;
            // Button2.Enabled = False
            Button4.Enabled = false;
            publicSubsNFunctions.mode = false;
        }

        private string main_exam;

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(isvalid()))
            {
                bestStud.Enabled = true;
                if (chkMode.Checked)
                {
                    publicSubsNFunctions.mode = true;
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
                        publicSubsNFunctions.total_mark[k] = 100;

                        // total_mark(k) = get_total_mark(exam_names(k), tms(k), yrs(k))
                    }

                    analyze();
                }
                else
                {
                    publicSubsNFunctions.mode = false;
                    publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
                    publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
                    analyze();
                }
            }
            else
            {
                publicSubsNFunctions.failure(publicSubsNFunctions.msg);
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

        private void txtContribution_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                add_exam();
            }
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

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            add_exam();
        }

        private void cboExamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtContribution.Clear();
            txtContribution.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.grade = false;
            publicSubsNFunctions.mod_subject = false;
            publicSubsNFunctions.mode = false;
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            denalyze();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            get_details();
            var frm = new frmStudentSubjectRank();
            frm.ShowDialog();
        }

        private void get_details()
        {
            publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
            publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
            publicSubsNFunctions.mod_subject = radSubject.Checked;
            publicSubsNFunctions.grading = radSubject.Checked;
            publicSubsNFunctions.best_of_7 = chkBestOf7.Checked;
            publicSubsNFunctions.exam_name = Conversions.ToString(cboExamName.SelectedItem);



            // marks = get_total_mark(cboExamName.SelectedItem, tm)
            // todo modified marks set it to a constant 100 the original code is commented 

            publicSubsNFunctions.marks = 100;
            publicSubsNFunctions.table = "exam_results";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            get_details();
            publicSubsNFunctions.wait("Computing Subject Grades...");
            var frm = new frmMeanAnalysis();
            frm.ShowDialog();
        }

        private void btnGradesAttained_Click(object sender, EventArgs e)
        {
            get_details();
            publicSubsNFunctions.wait("Computing Exam Results...");
            var frm = new frmGradesAttained();
            frm.ShowDialog();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            index = 0;
            publicSubsNFunctions.tables = new string[index + 1];
            publicSubsNFunctions.total_mark = new int[index + 1];
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboClass.SelectedItem, publicSubsNFunctions.None, false), Operators.ConditionalCompareObjectNotEqual(cboClass.SelectedItem, string.Empty, false))))
            {
                publicSubsNFunctions.class_form = Conversions.ToString(cboClass.SelectedItem);
            }
        }

        private void radSubject_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubject.Checked)
            {
                publicSubsNFunctions.mod_subject = true;
            }
            else
            {
                publicSubsNFunctions.mod_subject = false;
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
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
            print_document.Print();
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

        private string[] words;
        private int mp, totalmp, totalentries, entries, mm;
        private int[] total;

        private object get_exam_name()
        {
            publicSubsNFunctions.exam_name = string.Empty;
            if (chkMode.Checked)
            {
                for (int k = 0, loopTo = lstExaminations.Items.Count - 1; k <= loopTo; k++)
                {
                    publicSubsNFunctions.exam_name += lstExaminations.Items[k].Text;
                    if (k < lstExaminations.Items.Count - 1)
                    {
                        publicSubsNFunctions.exam_name += "/";
                    }
                }

                return publicSubsNFunctions.exam_name;
            }
            else
            {
                return cboExamName.SelectedItem;
            }
        }

        private void print_class_list(object sender, PrintPageEventArgs e)
        {
            int line = 40;
            int topline = line;
            int left_margin = 20;
            int right_margin = 800;
            int col = 50;
            publicSubsNFunctions.exam_name = Conversions.ToString(get_exam_name());
            try
            {
                e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + publicSubsNFunctions.logo()), left_margin + 10, topline, 100, 100);
            }
            catch (Exception ex)
            {
                if (Conversions.ToBoolean(!publicSubsNFunctions.confirm("You Have No School Logo To Print! Do You Want To Continue Printing?")))
                {
                    return;
                }
            }

            e.Graphics.DrawString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            e.Graphics.DrawString("EXAMINATION DEPARTMENT", publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            e.Graphics.DrawString("CLASS MEAN GRADE COUNT ANALYSIS", publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            e.Graphics.DrawString(publicSubsNFunctions.exam_name + "             Term: " + publicSubsNFunctions.term + "          Year: " + DateAndTime.Today.Year, publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            line += 20;
            publicSubsNFunctions.classes();
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
                publicSubsNFunctions.table = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(cboTerm.SelectedItem, "_"), cboYear.SelectedItem.ToString().Substring(2)), "_"), publicSubsNFunctions.get_name(Conversions.ToString(cboExamName.SelectedItem))), "_"), publicSubsNFunctions.get_name(words[c])));
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                e.Graphics.DrawString(words[c].ToUpper(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                topline = line - 20;
                left_margin = 20;
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
                fill_stream(Conversions.ToString(publicSubsNFunctions.get_stream(words[c])));
                int column;
                for (int s = 0, loopTo3 = publicSubsNFunctions.streams.Length - 1; s <= loopTo3; s++)
                {
                    publicSubsNFunctions.wait("Computing " + words[c] + " " + publicSubsNFunctions.streams[s] + "...");
                    totalentries += entries;
                    entries = 0;
                    column = 73;
                    totalmp += mp;
                    mp = 0;
                    e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.get_name(words[c]), " "), publicSubsNFunctions.streams[s])), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                    for (int k = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; k <= loopTo4; k++)
                    {
                        cnt = no_of_grades(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.streams[s]);
                        total[k] += cnt;
                        e.Graphics.DrawString(cnt.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                        column += 30;
                    }

                    e.Graphics.DrawString(entries.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    column += 50;
                    e.Graphics.DrawString(Strings.Format(mp / (double)entries, "0.00"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    column += 60;
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(mp / (double)entries)), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    column += 70;
                    e.Graphics.DrawString(Conversions.ToString(mean_mark(publicSubsNFunctions.streams[s])), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
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
                if (totalentries == 0 | totalmp == 0)
                {
                    e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }
                else
                {
                    e.Graphics.DrawString(Strings.Format(totalmp / (double)totalentries, "0.00"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }

                column += 60;
                if (totalentries == 0 | totalmp == 0)
                {
                    e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }
                else
                {
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(totalmp / (double)totalentries)), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }

                column += 70;
                if (totalentries == 0 | totalmp == 0)
                {
                    e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }
                else
                {
                    e.Graphics.DrawString(Conversions.ToString(mean_mark_total()), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }

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

        private object largest_index;

        private int no_of_grades_2(string grade, string stream, string subj)
        {
            int no_of_grades_2Ret = default;
            subj = Conversions.ToString(publicSubsNFunctions.ret_subject_name(subj));
            string[] all_grades;
            no_of_grades_2Ret = 0;
            double out_of;
            if (!publicSubsNFunctions.mode)
            {
                string argq = "SELECT `" + subj + "`, Stream FROM `" + publicSubsNFunctions.table + "` WHERE Stream='" + publicSubsNFunctions.escape_string(stream) + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "'  AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "'";
                publicSubsNFunctions.qread(ref argq);
                int i = 0;
                all_grades = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                while (publicSubsNFunctions.dbreader.Read())
                {
                    if (Information.IsNumeric(publicSubsNFunctions.dbreader[subj]))
                    {
                        out_of = publicSubsNFunctions.SubjectOutOf(subj, publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_name, publicSubsNFunctions.class_form, publicSubsNFunctions.dbreader["Stream"], 2);
                        all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[subj], out_of), 100)), publicSubsNFunctions.grading, subj));
                    }
                    else
                    {
                        all_grades[i] = Conversions.ToString(publicSubsNFunctions.dbreader[subj]);
                    }

                    i += 1;
                }

                for (int k = 0, loopTo = all_grades.Length - 1; k <= loopTo; k++)
                {
                    if ((all_grades[k] ?? "") == (grade ?? ""))
                    {
                        no_of_grades_2Ret += 1;
                    }
                }

                entries += no_of_grades_2Ret;
                mp = Conversions.ToInteger(mp + Operators.MultiplyObject(no_of_grades_2Ret, publicSubsNFunctions.fix_point(grade)));
                return no_of_grades_2Ret;
            }
            else
            {
                string largest_table = LargestTable(stream);
                var studs = new object[large][];
                for (int k = 0, loopTo1 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo1; k++)
                {
                    string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ADMNo, `" + subj + "`, Stream FROM `" + publicSubsNFunctions.table + "` WHERE Stream='" + publicSubsNFunctions.escape_string(stream) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "'  AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "' AND Class='"), publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem))), "' ORDER BY ADMNo ASC"));
                    publicSubsNFunctions.qread(ref argq1);
                    if (k == 0)
                    {
                        Array.Resize(ref studs[publicSubsNFunctions.dbreader.RecordsAffected - 1], 2);
                        for (int c = 0, loopTo2 = studs.Length - 1; c <= loopTo2; c++)
                        {
                            Array.Resize(ref studs[c], 2);
                            for (int c1 = 0, loopTo3 = studs[c].Length - 1; c1 <= loopTo3; c1++)
                                studs[c][c1] = 0;
                        }
                    }

                    int i = 0;
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        out_of = publicSubsNFunctions.SubjectOutOf(subj, publicSubsNFunctions.tms[k], publicSubsNFunctions.yrs[k], publicSubsNFunctions.exam_names[k], publicSubsNFunctions.class_form, publicSubsNFunctions.dbreader["Stream"], 2);
                        if (k == 0)
                        {
                            try
                            {
                                studs[i][0] = publicSubsNFunctions.dbreader["ADMNo"];
                                studs[i][1] += Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[subj], out_of), publicSubsNFunctions.total_mark[k]), publicSubsNFunctions.contribution[k]), publicSubsNFunctions.total_mark[k]);
                                i += 1;
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        else
                        {
                            for (int count = 0, loopTo4 = studs.Length - 1; count <= loopTo4; count++)
                            {
                                try
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[count][0], publicSubsNFunctions.dbreader["ADMNo"], false)))
                                    {
                                        studs[count][1] += Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[subj], out_of), publicSubsNFunctions.total_mark[k]), publicSubsNFunctions.contribution[k]), publicSubsNFunctions.total_mark[k]);
                                        break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }
                    }
                }

                for (int k = 0, loopTo5 = studs.Length - 1; k <= loopTo5; k++)
                    studs[k][1] = publicSubsNFunctions.get_grade(Conversions.ToDouble(studs[k][1]), publicSubsNFunctions.grading, subj);
                for (int k = 0, loopTo6 = studs.Length - 1; k <= loopTo6; k++)
                {
                    try
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[k][1], grade, false)))
                        {
                            no_of_grades_2Ret += 1;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                entries += no_of_grades_2Ret;
                mp = Conversions.ToInteger(mp + Operators.MultiplyObject(no_of_grades_2Ret, publicSubsNFunctions.fix_point(grade)));
                return no_of_grades_2Ret;
            }
            // here
        }

        private int large = 0;

        private string LargestTable(string str)
        {
            string LargestTableRet = default;
            LargestTableRet = null;
            for (int k = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo; k++)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT id FROM exam_results WHERE (class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' and stream='" + publicSubsNFunctions.escape_string(str) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "')"));
                publicSubsNFunctions.qread(ref argq);
                if (publicSubsNFunctions.dbreader.RecordsAffected > large)
                {
                    large = publicSubsNFunctions.dbreader.RecordsAffected;
                    largest_index = k;
                    LargestTableRet = Conversions.ToString(publicSubsNFunctions.exam_names[k]);
                }
            }

            return LargestTableRet;
        }

        private string sum;

        private object mean_mark_total()
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

            string argq = "SELECT `" + sum + "` FROM `" + publicSubsNFunctions.table + "` WHERE Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "'  AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "'";
            publicSubsNFunctions.qread(ref argq);
            var cnt = default(int);
            while (publicSubsNFunctions.dbreader.Read())
            {
                if (Information.IsNumeric(publicSubsNFunctions.dbreader[sum]))
                {
                    mm = Conversions.ToInteger(mm + publicSubsNFunctions.dbreader[sum]);
                    cnt += 1;
                }
            }

            publicSubsNFunctions.dbreader.Close();
            return Strings.Format(mm / (double)cnt, "0.00");
        }

        private object mean_mark(string s)
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

            string argq = "SELECT `" + sum + "` FROM `" + publicSubsNFunctions.table + "` WHERE Stream='" + s + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "'  AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "'";
            publicSubsNFunctions.qread(ref argq);
            var cnt = default(int);
            while (publicSubsNFunctions.dbreader.Read())
            {
                if (Information.IsNumeric(publicSubsNFunctions.dbreader[sum]))
                {
                    mm = Conversions.ToInteger(mm + publicSubsNFunctions.dbreader[sum]);
                    cnt += 1;
                }
            }

            publicSubsNFunctions.dbreader.Close();
            return Strings.Format(mm / (double)cnt, "0.00");
        }

        private int no_of_grades(string grade, string stream)
        {
            int no_of_gradesRet = default;
            string[] all_grades;
            no_of_gradesRet = 0;
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

            string argq = "SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE Stream='" + stream + "' Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "'  AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "'";
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

        private void fill_stream(string str)
        {
            string argq = "SELECT stream FROM class_stream WHERE class='" + publicSubsNFunctions.escape_string(str) + "'";
            publicSubsNFunctions.qread(ref argq);
            publicSubsNFunctions.streams = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            int i = 0;
            while (publicSubsNFunctions.dbreader.Read())
            {
                publicSubsNFunctions.streams[i] = Conversions.ToString(publicSubsNFunctions.dbreader["stream"]);
                i += 1;
            }
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
            print_document.Print();
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

        private void print_class_list2(object sender, PrintPageEventArgs e)
        {
            // e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
            int line = 30;
            int topline = line;
            int left_margin = 20;
            int right_margin = 810;
            int col = 50;
            publicSubsNFunctions.exam_name = Conversions.ToString(get_exam_name());
            try
            {
                e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + publicSubsNFunctions.logo()), left_margin + 10, topline, 100, 100);
            }
            catch (Exception ex)
            {
                if (Conversions.ToBoolean(!publicSubsNFunctions.confirm("You Have No School Logo To Print! Do You Want To Continue Printing?")))
                {
                    return;
                }
            }

            e.Graphics.DrawString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            e.Graphics.DrawString("EXAMINATION DEPARTMENT", publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            e.Graphics.DrawString("CLASS GENDER ANALYSIS", publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            e.Graphics.DrawString(publicSubsNFunctions.exam_name + " Term " + publicSubsNFunctions.tm + " " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            publicSubsNFunctions.classes();
            publicSubsNFunctions.wait("Complex Computation ...");
            for (int c = 0, loopTo = words.Length - 1; c <= loopTo; c++)
            {
                publicSubsNFunctions.table = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(cboTerm.SelectedItem, "_"), cboYear.SelectedItem.ToString().Substring(2)), "_"), publicSubsNFunctions.get_name(Conversions.ToString(cboExamName.SelectedItem))), "_"), publicSubsNFunctions.get_name(words[c])));
                fill_stream(Conversions.ToString(publicSubsNFunctions.get_stream(words[c])));
                for (int s = 0, loopTo1 = publicSubsNFunctions.streams.Length - 1; s <= loopTo1; s++)
                {
                    publicSubsNFunctions.wait("Computing " + words[c] + " " + publicSubsNFunctions.streams[s] + "...");
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
                    col = 103;
                    for (int k = 0, loopTo3 = publicSubsNFunctions.grades.Length - 1; k <= loopTo3; k++)
                    {
                        e.Graphics.DrawString(Conversions.ToString(gradeno(Conversions.ToString(publicSubsNFunctions.grades[k]), "Male", publicSubsNFunctions.streams[s])), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col + 4, line);
                        col += 35;
                    }

                    e.Graphics.DrawString(g_entry.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    double mean = Conversions.ToDouble(mean_p(string.Empty, "Male", publicSubsNFunctions.streams[s]));
                    e.Graphics.DrawString(mean.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(mean)), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    mean = Conversions.ToDouble(meanmark("Male", publicSubsNFunctions.streams[s]));
                    e.Graphics.DrawString(mean.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    g_mp = 0;
                    g_entry = 0;
                    mean = 0d;
                    e.Graphics.DrawString("M", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 10, line);
                    line += publicSubsNFunctions.smallfont.Height + 2;
                    e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                    col = 103;
                    for (int k = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; k <= loopTo4; k++)
                    {
                        e.Graphics.DrawString(Conversions.ToString(gradeno(Conversions.ToString(publicSubsNFunctions.grades[k]), "Female", publicSubsNFunctions.streams[s])), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col + 4, line);
                        col += 35;
                    }

                    e.Graphics.DrawString(g_entry.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    mean = Conversions.ToDouble(mean_p(string.Empty, "Female", publicSubsNFunctions.streams[s]));
                    e.Graphics.DrawString(mean.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(mean)), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 50;
                    mean = Conversions.ToDouble(meanmark("Female", publicSubsNFunctions.streams[s]));
                    e.Graphics.DrawString(mean.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    g_mp = 0;
                    g_entry = 0;
                    mean = 0d;
                    e.Graphics.DrawString("F", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 10, line);
                    line += publicSubsNFunctions.smallfont.Height + 2;
                    e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                    e.Graphics.DrawLine(Pens.Black, left_margin, topline, left_margin, line);
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

        private object mean_p(string grade, string gender, string s)
        {
            string[] all_grades;
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

            string argq = "SELECT `" + sum + "`, `ADMNo` FROM `" + publicSubsNFunctions.table + "` WHERE Stream='" + s + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "'  AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "'";
            publicSubsNFunctions.qread(ref argq);
            int i = 0;
            all_grades = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            admnos = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            while (publicSubsNFunctions.dbreader.Read())
            {
                if (Information.IsNumeric(publicSubsNFunctions.dbreader[sum]))
                {
                    admnos[i] = Conversions.ToString(publicSubsNFunctions.dbreader["ADMNo"]);
                    all_grades[i] = Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], 11), publicSubsNFunctions.marks), 100)), false, Conversions.ToString(publicSubsNFunctions.ret_subject_name(publicSubsNFunctions.subject))));
                    i += 1;
                }
            }

            publicSubsNFunctions.dbreader.Close();
            for (int k = 0, loopTo = admnos.Length - 1; k <= loopTo; k++)
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

        private object meanmark(string gender, string s)
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

            string argq = "SELECT `" + sum + "`, `ADMNo` FROM `" + publicSubsNFunctions.table + "` WHERE Stream='" + s + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "'  AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "'";
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

            if (cnt > 0 & g_mp > 0)
            {
                return Strings.Format(g_mp / (double)cnt, "0.00");
            }
            else
            {
                return "--";
            }
        }

        private int g_entry, g_mp;
        private int[] totals;

        private void bestStud_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.selectedExams.Clear();
            if (radSubject.CheckState == CheckState.Checked)
            {
                Interaction.MsgBox("Please use class based grading");
                return;
                // gradingType = "SubjectBased"
            }

            publicSubsNFunctions.selectedClass = Conversions.ToString(cboClass.SelectedItem);
            publicSubsNFunctions.selectedTerm = Conversions.ToString(cboTerm.SelectedItem);
            publicSubsNFunctions.selectedYear = Conversions.ToString(cboYear.SelectedItem);
            if (chkMode.Checked)
            {
                foreach (ListViewItem value in lstExaminations.Items)
                    publicSubsNFunctions.selectedExams.Add(new Tuple<string, string, string, string>(value.Text, value.SubItems[1].Text, value.SubItems[2].Text, value.SubItems[3].Text));
            }
            else
            {
                publicSubsNFunctions.selectedExams.Add(new Tuple<string, string, string, string>(Conversions.ToString(cboExamName.SelectedItem), 100.ToString(), publicSubsNFunctions.selectedTerm, publicSubsNFunctions.selectedYear));
            }

            if (publicSubsNFunctions.selectedExams.Count == 0)
            {
                Interaction.MsgBox("The exam or term or year has not been selected");
            }

            var prompt2 = new frmSubjectRankPrompt2();
            prompt2.ShowDialog();
        }

        private object gradeno(string grade, string gender, string s)
        {
            object gradenoRet = default;
            string[] all_grades;
            string[] admnos;
            gradenoRet = 0;
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

            string argq = "SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE Stream='" + publicSubsNFunctions.escape_string(s) + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "'  AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "'";
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

            publicSubsNFunctions.dbreader.Close();
            for (int k = 0, loopTo1 = admnos.Length - 1; k <= loopTo1; k++)
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

        private void Button4_Click_1(object sender, EventArgs e)
        {
            publicSubsNFunctions.grading = radSubject.Checked;
            if (!chkMode.Checked)
            {
                publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
                publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
            }

            publicSubsNFunctions.class_form = Conversions.ToString(cboClass.SelectedItem);
            publicSubsNFunctions.exam_name = Conversions.ToString(cboExamName.SelectedItem);
            get_details();
            create_report3();
        }

        private void create_report3()
        {
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)prepare_class_list3();
            printpreview.Document = print_document;
            printpreview.ShowDialog();
            print_document.Print();
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

        private int start_from = 0;

        private void print_class_list3(object sender, PrintPageEventArgs e)
        {
            // e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
            int line = 20;
            int topline = line;
            int left_margin = 50;
            int right_margin = 800;
            int col = 50;
            publicSubsNFunctions.exam_name = Conversions.ToString(get_exam_name());
            if (File.Exists(publicSubsNFunctions.path + @"\student_images\" + publicSubsNFunctions.logo()))
            {
                e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + publicSubsNFunctions.logo()), left_margin, topline, 100, 100);
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
            line += publicSubsNFunctions.other_font.Height + 3;
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(cboClass.SelectedItem.ToString().ToUpper() + " " + publicSubsNFunctions.exam_name.ToUpper() + " TERM " + publicSubsNFunctions.tm + "  " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString(cboClass.SelectedItem.ToString().ToUpper() + " " + publicSubsNFunctions.exam_name.ToUpper() + "  TERM " + publicSubsNFunctions.tm + "  " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height + 3;
            line += 15;
            publicSubsNFunctions.classes();
            for (int p = start_from, loopTo = publicSubsNFunctions.subjabb.Length - 1; p <= loopTo; p++)
            {
                if (line + 80 >= 1000 & start_from == 0)
                {
                    e.HasMorePages = true;
                    start_from = p;
                    return;
                }

                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(publicSubsNFunctions.subjects[p], " DEPARTMENT ")), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                line += 14;
                total = new int[publicSubsNFunctions.grades.Length];
                totalmp = 0;
                mp = 0;
                int cnt;
                totalentries = 0;
                entries = 0;
                e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line);
                e.Graphics.DrawString(cboClass.SelectedItem.ToString().ToUpper(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 20, line);
                topline = line - 10;
                left_margin = 50;
                col = 100;
                for (int k = 0, loopTo1 = publicSubsNFunctions.grades.Length - 1; k <= loopTo1; k++)
                {
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                    col += 35;
                }

                e.Graphics.DrawString("ENTRY", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                col += 50;
                e.Graphics.DrawString("M.P.", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                col += 60;
                e.Graphics.DrawString("M. GRADE", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + col, line);
                line += 13;
                e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line);
                fill_stream(Conversions.ToString(cboClass.SelectedItem));
                int column = 103;
                for (int s = 0, loopTo2 = publicSubsNFunctions.streams.Length - 1; s <= loopTo2; s++)
                {
                    publicSubsNFunctions.wait(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Computing ", cboClass.SelectedItem), " "), publicSubsNFunctions.streams[s]), "...")));
                    totalentries += entries;
                    entries = 0;
                    column = 103;
                    totalmp += mp;
                    mp = 0;
                    e.Graphics.DrawString(publicSubsNFunctions.streams[s], publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 20, line);
                    for (int k = 0, loopTo3 = publicSubsNFunctions.grades.Length - 1; k <= loopTo3; k++)
                    {
                        cnt = no_of_grades_2(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.streams[s], Conversions.ToString(publicSubsNFunctions.subjects[p]));
                        total[k] += cnt;
                        e.Graphics.DrawString(cnt.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                        column += 35;
                    }

                    e.Graphics.DrawString(entries.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    column += 50;
                    if (mp == 0 | entries == 0)
                    {
                        e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    }
                    else
                    {
                        e.Graphics.DrawString(Strings.Format(mp / (double)entries, "0.00"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    }

                    column += 60;
                    if (mp == 0 | entries == 0)
                    {
                        e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    }
                    else
                    {
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(mp / (double)entries)), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    }

                    line += 13;
                    e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line);
                    if (s == publicSubsNFunctions.streams.Length - 1)
                    {
                        totalmp += mp;
                        totalentries += entries;
                    }
                }

                e.Graphics.DrawString("TOTAL", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 20, line);
                column = 103;
                for (int k = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; k <= loopTo4; k++)
                {
                    e.Graphics.DrawString(total[k].ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                    column += 35;
                }

                e.Graphics.DrawString(totalentries.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                column += 50;
                if (totalentries == 0 | totalmp == 0)
                {
                    e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }
                else
                {
                    e.Graphics.DrawString(Strings.Format(totalmp / (double)totalentries, "0.00"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }

                column += 60;
                if (totalentries == 0 | totalmp == 0)
                {
                    e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }
                else
                {
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(totalmp / (double)totalentries)), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + column, line);
                }

                line += 13;
                e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 20, topline + publicSubsNFunctions.smallfont.Height, left_margin + 20, line);
                col = 100;
                for (int k = 0, loopTo5 = publicSubsNFunctions.grades.Length - 1; k <= loopTo5; k++)
                {
                    e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height, left_margin + col - 4, line);
                    col += 35;
                }

                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height, left_margin + col - 4, line);
                col += 50;
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height, left_margin + col - 4, line);
                col += 60;
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 4, topline + publicSubsNFunctions.smallfont.Height, left_margin + col - 4, line);
                e.Graphics.DrawLine(Pens.Black, right_margin, topline + publicSubsNFunctions.smallfont.Height, right_margin, line);
            }

            e.Graphics.DrawString(DateAndTime.Today.Date.Date + " " + DateAndTime.Now.Hour + ":" + DateAndTime.Now.Minute + ":" + DateAndTime.Now.Second, publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 100, line);
            start_from = 0;
        }
    }
}