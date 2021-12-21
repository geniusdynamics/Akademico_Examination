using System;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmSubjectPerformanceIndex
    {
        public frmSubjectPerformanceIndex()
        {
            InitializeComponent();
            _Button1.Name = "Button1";
            _cboTerm1.Name = "cboTerm1";
            _cboYear1.Name = "cboYear1";
            _cboTerm.Name = "cboTerm";
            _cboYear.Name = "cboYear";
        }

        private void frmMostImproved_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                var argcbo = cboYear;
                publicSubsNFunctions.fill_years(ref argcbo);
                cboYear = argcbo;
                var argcbo1 = cboYear1;
                publicSubsNFunctions.fill_years(ref argcbo1);
                cboYear1 = argcbo1;
                cboYear.SelectedItem = DateAndTime.Today.Year;
                cboYear1.SelectedItem = DateAndTime.Today.Year;
                publicSubsNFunctions.get_term();
                cboTerm.SelectedItem = publicSubsNFunctions.term;
                cboTerm1.SelectedItem = publicSubsNFunctions.term;
                var argcbo2 = cboClass;
                publicSubsNFunctions.load_class(ref argcbo2);
                cboClass = argcbo2;
                if (publicSubsNFunctions.IsPrimary())
                {
                    radSubject.Visible = false;
                }
            }
        }

        private void cboTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboTerm.SelectedItem, null, false), Operators.ConditionalCompareObjectNotEqual(cboYear.SelectedItem, null, false))))
            {
                var argcbo = cboExamName;
                fill_exam(Conversions.ToString(cboTerm.SelectedItem), Conversions.ToInteger(cboYear.SelectedItem), ref argcbo);
                cboExamName = argcbo;
            }
        }

        private void fill_exam(string term, int year, ref ComboBox cbo)
        {
            string argq = "SELECT ExamName FROM examinations WHERE Term='" + term + "' AND Year='" + year + "'";
            if (publicSubsNFunctions.qread(ref argq))
            {
                cbo.Items.Clear();
                while (publicSubsNFunctions.dbreader.Read())
                    cbo.Items.Add(publicSubsNFunctions.dbreader["ExamName"]);
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Load Examinations!");
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboTerm.SelectedItem, null, false), Operators.ConditionalCompareObjectNotEqual(cboYear.SelectedItem, null, false))))
            {
                var argcbo = cboExamName;
                fill_exam(Conversions.ToString(cboTerm.SelectedItem), Conversions.ToInteger(cboYear.SelectedItem), ref argcbo);
                cboExamName = argcbo;
            }
        }

        private void cboYear1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboTerm1.SelectedItem, null, false), Operators.ConditionalCompareObjectNotEqual(cboYear1.SelectedItem, null, false))))
            {
                var argcbo = cboExamName1;
                fill_exam(Conversions.ToString(cboTerm1.SelectedItem), Conversions.ToInteger(cboYear1.SelectedItem), ref argcbo);
                cboExamName1 = argcbo;
            }
        }

        private void cboTerm1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboTerm1.SelectedItem, null, false), Operators.ConditionalCompareObjectNotEqual(cboYear1.SelectedItem, null, false))))
            {
                var argcbo = cboExamName1;
                fill_exam(Conversions.ToString(cboTerm1.SelectedItem), Conversions.ToInteger(cboYear1.SelectedItem), ref argcbo);
                cboExamName1 = argcbo;
            }
        }

        private object print_student_report2()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_report2;
            return print_document;
        }

        private void print_report2(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            int line = 30;
            float CenterPage;
            int left_margin = 20;
            float right_margin = 800f;
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

            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("SUBJECT PERFORMANCE INDEX", publicSubsNFunctions.header_font).Width / 2f);
            e.Graphics.DrawString("SUBJECT PERFORMANCE INDEX", publicSubsNFunctions.header_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height + 10;
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
            line += 2;
            var subjs = new object[publicSubsNFunctions.subjabb.Length][];
            for (int k = 0, loopTo = subjs.Length - 1; k <= loopTo; k++)
            {
                subjs[k] = new object[5];
                for (int c = 0, loopTo1 = subjs[k].Length - 1; c <= loopTo1; c++)
                    subjs[k][c] = null;
            }

            publicSubsNFunctions.yr = Conversions.ToInteger(cboYear1.SelectedItem);
            publicSubsNFunctions.tm = Conversions.ToString(cboTerm1.SelectedItem);
            publicSubsNFunctions.class_form = Conversions.ToString(cboClass.SelectedItem);
            int cnt = 0;
            double total_marks, tp;
            for (int k = 0, loopTo2 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo2; k++)
            {
                cnt = 0;
                tp = 0d;
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `", publicSubsNFunctions.subjname[k]), "`, Stream FROM exam_results WHERE (Examination='"), publicSubsNFunctions.escape_string(Conversions.ToString(cboExamName1.SelectedItem))), "' AND Term='"), publicSubsNFunctions.escape_string(Conversions.ToString(cboTerm1.SelectedItem))), "' AND Year='"), publicSubsNFunctions.escape_string(Conversions.ToString(cboYear1.SelectedItem))), "' AND Class='"), publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem))), "' AND `"), publicSubsNFunctions.subjname[k]), "` REGEXP '[0-9]+')"));
                publicSubsNFunctions.qread(ref argq);
                while (publicSubsNFunctions.dbreader.Read())
                {
                    total_marks = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], cboTerm.SelectedItem, cboYear.SelectedItem, cboExamName.SelectedItem, cboClass.SelectedItem, publicSubsNFunctions.dbreader["Stream"], 2);
                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), total_marks), 100)), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[k])))));
                    cnt += 1;
                }

                subjs[k][0] = publicSubsNFunctions.subjabb[k];
                subjs[k][1] = publicSubsNFunctions.subjects[k];
                subjs[k][2] = tp / cnt;
                subjs[k][3] = subjs[k][2];
            }

            publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
            publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
            cnt = 0;
            tp = 0d;
            for (int k = 0, loopTo3 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo3; k++)
            {
                cnt = 0;
                tp = 0d;
                string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `", publicSubsNFunctions.subjname[k]), "`, Stream FROM exam_results WHERE (Examination='"), publicSubsNFunctions.escape_string(Conversions.ToString(cboExamName.SelectedItem))), "' AND Term='"), publicSubsNFunctions.escape_string(Conversions.ToString(cboTerm.SelectedItem))), "' AND Year='"), publicSubsNFunctions.escape_string(Conversions.ToString(cboYear.SelectedItem))), "' AND Class='"), publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem))), "' AND `"), publicSubsNFunctions.subjname[k]), "` REGEXP '[0-9]+')"));
                publicSubsNFunctions.qread(ref argq1);
                while (publicSubsNFunctions.dbreader.Read())
                {
                    total_marks = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], cboTerm.SelectedItem, cboYear.SelectedItem, cboExamName.SelectedItem, cboClass.SelectedItem, publicSubsNFunctions.dbreader["Stream"], 2);
                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), total_marks), 100)), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[k])))));
                    cnt += 1;
                }

                subjs[k][2] = Operators.SubtractObject(subjs[k][2], tp / cnt);
                subjs[k][4] = tp / cnt;
            }

            var subjs_temp = new object[5];
            for (int k = 0, loopTo4 = subjs.Length - 1; k <= loopTo4; k++)
            {
                for (int l = 0, loopTo5 = subjs.Length - 1; l <= loopTo5; l++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(subjs[k][2], subjs[l][2], false)))
                    {
                        subjs_temp[0] = subjs[k][0];
                        subjs_temp[1] = subjs[k][1];
                        subjs_temp[2] = subjs[k][2];
                        subjs_temp[3] = subjs[k][3];
                        subjs_temp[4] = subjs[k][4];
                        subjs[k][0] = subjs[l][0];
                        subjs[k][1] = subjs[l][1];
                        subjs[k][2] = subjs[l][2];
                        subjs[k][3] = subjs[l][3];
                        subjs[k][4] = subjs[l][4];
                        subjs[l][0] = subjs_temp[0];
                        subjs[l][1] = subjs_temp[1];
                        subjs[l][2] = subjs_temp[2];
                        subjs[l][3] = subjs_temp[3];
                        subjs[l][4] = subjs_temp[4];
                    }
                }
            }

            e.Graphics.DrawString("S/No.", publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            e.Graphics.DrawString("SUBJECT NAME", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 50, line);
            e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(cboExamName.SelectedItem, " "), cboTerm.SelectedItem), " "), cboYear.SelectedItem)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 300, line);
            e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(cboExamName1.SelectedItem, " "), cboTerm1.SelectedItem), " "), cboYear1.SelectedItem)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 450, line);
            e.Graphics.DrawString("DEVIATION", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 650, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
            line += 2;
            var count_similar = default(int);
            for (int k = 0, loopTo6 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo6; k++)
            {
                if (k > 0)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(subjs[k][2], subjs[k - 1][2], false)))
                    {
                        count_similar += 1;
                        if (count_similar > 1)
                        {
                            e.Graphics.DrawString((k - 1).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                        }
                        else
                        {
                            e.Graphics.DrawString(k.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                        }
                    }
                    else
                    {
                        count_similar = 0;
                        e.Graphics.DrawString((k + 1).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                    }
                }
                else
                {
                    e.Graphics.DrawString((k + 1).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                }

                e.Graphics.DrawString(Conversions.ToString(subjs[k][1]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 50, line);
                e.Graphics.DrawString(Strings.Format(subjs[k][4], "0.0000"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 320, line);
                e.Graphics.DrawString(Strings.Format(subjs[k][3], "0.0000"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 470, line);
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(subjs[k][2], 0, false)))
                {
                    e.Graphics.DrawString("+" + Strings.Format(subjs[k][2], "0.00"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 680, line);
                }
                else
                {
                    e.Graphics.DrawString(Strings.Format(subjs[k][2], "0.00"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 680, line);
                }

                line += publicSubsNFunctions.other_font.Height;
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboExamName.SelectedItem, null, false), Operators.ConditionalCompareObjectNotEqual(cboExamName1.SelectedItem, null, false)), Operators.ConditionalCompareObjectNotEqual(cboClass.SelectedItem, null, false))))
            {
                var Print_Preview = new PrintPreviewDialog();
                var print_dialog = new PrintDialog();
                PrintDocument print_document = (PrintDocument)print_student_report2();
                print_document.DefaultPageSettings.Landscape = false;
                Print_Preview.Document = print_document;
                Print_Preview.ShowDialog();
            }
            else
            {
                publicSubsNFunctions.failure("The Form Is Not Correctly Filled! Please Make The Necessary Corrections!");
            }
        }
    }
}