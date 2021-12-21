using System;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmMeanAnalysis
    {
        public frmMeanAnalysis()
        {
            InitializeComponent();
            _btnPrintPreview.Name = "btnPrintPreview";
            _btnCancel.Name = "btnCancel";
            _Button1.Name = "Button1";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMeanAnalysis_Load(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(!publicSubsNFunctions.connect(), publicSubsNFunctions.dbNewOpen())))
            {
                Close();
            }
            else
            {
                lblTitle.Text = "Subject Performance Analysis - Mean Analysis".ToUpper();
                double out_of;
                if (publicSubsNFunctions.mode)
                {
                    double[] total = new double[publicSubsNFunctions.subjabb.Length], count = new double[publicSubsNFunctions.subjabb.Length];
                    for (int j = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; j <= loopTo; j++)
                    {
                        for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                        {
                            total[k] = 0d;
                            count[k] = 0d;
                        }

                        for (int k = 0, loopTo2 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo2; k++)
                        {
                            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `", publicSubsNFunctions.subjabb[k]), "`, Stream FROM `"), publicSubsNFunctions.table), "` WHERE (class='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form)), "' AND Examination='"), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[j]))), "'  AND Term='"), publicSubsNFunctions.tms[j]), "' AND Year='"), publicSubsNFunctions.yrs[j]), "')"));
                            if (publicSubsNFunctions.qread(ref argq))
                            {
                                while (publicSubsNFunctions.dbreader.Read())
                                {
                                    if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k])))
                                    {
                                        out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.tms[j], publicSubsNFunctions.yrs[j], publicSubsNFunctions.exam_names[j], publicSubsNFunctions.class_form, publicSubsNFunctions.dbreader["Stream"], 2);
                                        total[k] = Conversions.ToDouble(total[k] + Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k]), out_of), publicSubsNFunctions.total_mark[j]), publicSubsNFunctions.contribution[j]), 100));
                                        count[k] += 1d;
                                    }
                                }
                            }
                        }

                        for (int k = 0, loopTo3 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo3; k++)
                        {
                            if (dgvSubjects.Rows.Count < publicSubsNFunctions.subjabb.Length)
                            {
                                dgvSubjects.Rows.Add();
                            }

                            dgvSubjects["SubjID", k].Value = publicSubsNFunctions.subjids[k];
                            dgvSubjects["Abbreviation", k].Value = publicSubsNFunctions.subjabb[k];
                            dgvSubjects["SubjectName", k].Value = publicSubsNFunctions.subjects[k];
                            if (Information.IsNumeric(dgvSubjects["MeanMark", k].Value))
                            {
                                dgvSubjects["MeanMark", k].Value = Strings.Format(Operators.AddObject(dgvSubjects["MeanMark", k].Value, total[k] / count[k]), "0.00");
                            }
                            else
                            {
                                dgvSubjects["MeanMark", k].Value = Strings.Format(total[k] / count[k], "0.00");
                            }
                        }
                    }
                }
                else
                {
                    int total, count;
                    for (int k = 0, loopTo4 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo4; k++)
                    {
                        string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `", publicSubsNFunctions.subjabb[k]), "`, Stream FROM `"), publicSubsNFunctions.table), "` WHERE (class='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form)), "' AND  Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "'  AND Term='"), publicSubsNFunctions.tm), "' AND Year='"), publicSubsNFunctions.yr), "')"));
                        if (publicSubsNFunctions.qread(ref argq1))
                        {
                            total = 0;
                            count = 0;
                            while (publicSubsNFunctions.dbreader.Read())
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k])))
                                {
                                    out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_name, publicSubsNFunctions.class_form, publicSubsNFunctions.dbreader["Stream"], 2);
                                    total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k]), out_of), publicSubsNFunctions.marks));
                                    count += 1;
                                }
                            }

                            publicSubsNFunctions.dbreader.Close();
                            dgvSubjects.Rows.Add();
                            dgvSubjects["SubjID", k].Value = publicSubsNFunctions.subjids[k];
                            dgvSubjects["Abbreviation", k].Value = publicSubsNFunctions.subjabb[k];
                            dgvSubjects["SubjectName", k].Value = publicSubsNFunctions.subjects[k];
                            if (count > 0)
                            {
                                dgvSubjects["MeanMark", k].Value = Strings.Format(total / (double)count / publicSubsNFunctions.marks * 100d, "0.00");
                            }
                            else
                            {
                                dgvSubjects["MeanMark", k].Value = "--";
                            }
                        }
                    }
                }

                for (int k = 0, loopTo5 = dgvSubjects.Rows.Count - 1; k <= loopTo5; k++)
                {
                    points(k);
                    dgvSubjects["MeanGrade", k].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvSubjects["MeanPoints", k].Value));
                    dgvSubjects["MeanPoints", k].Value = Convert.ToDecimal(dgvSubjects["MeanPoints", k].Value);
                }

                dgvSubjects.Sort(dgvSubjects.Columns["MeanPoints"], System.ComponentModel.ListSortDirection.Descending);
                for (int k = 0, loopTo6 = dgvSubjects.Rows.Count - 1; k <= loopTo6; k++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvSubjects["MeanPoints", k].Value, 0, false)))
                    {
                        dgvSubjects["MeanPoints", k].Value = "--";
                        dgvSubjects["MeanGrade", k].Value = "--";
                    }
                }
            }
        }

        private void points(object k)
        {
            int tp, cnt;
            int[] marks = new int[1];
            double out_of;
            for (int m = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; m <= loopTo; m++)
            {
                tp = 0;
                cnt = 0;
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvSubjects["Abbreviation", Conversions.ToInteger(k)].Value, publicSubsNFunctions.subjabb[m], false)))
                {
                    if (publicSubsNFunctions.mode)
                    {
                        for (int t = 0, loopTo1 = publicSubsNFunctions.exam_names.Length - 1; t <= loopTo1; t++)
                        {
                            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `", publicSubsNFunctions.subjname[m]), "`, Stream FROM `"), publicSubsNFunctions.table), "` WHERE (class='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form)), "' AND Examination='"), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[t]))), "' AND Term='"), publicSubsNFunctions.tms[t]), "' AND Year='"), publicSubsNFunctions.yrs[t]), "')"));
                            publicSubsNFunctions.qread(ref argq);
                            Array.Resize(ref marks, publicSubsNFunctions.dbreader.RecordsAffected);
                            int i = 0;
                            while (publicSubsNFunctions.dbreader.Read())
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[m])))
                                {
                                    out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[m], publicSubsNFunctions.tms[t], publicSubsNFunctions.yrs[t], publicSubsNFunctions.exam_names[t], publicSubsNFunctions.class_form, publicSubsNFunctions.dbreader["Stream"], 2);
                                    marks[i] = Conversions.ToInteger(marks[i] + Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[m]), out_of), publicSubsNFunctions.total_mark[t]), publicSubsNFunctions.contribution[t]), 100));
                                }

                                i += 1;
                            }
                        }

                        for (int l = 0, loopTo2 = marks.Length - 1; l <= loopTo2; l++)
                        {
                            cnt += 1;
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)marks[l], publicSubsNFunctions.grading, Conversions.ToString(publicSubsNFunctions.subjabb[m])))));
                        }
                    }
                    else
                    {
                        int mark = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                        string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `", publicSubsNFunctions.subjname[m]), "`, Stream FROM `"), publicSubsNFunctions.table), "` WHERE (class='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form)), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "'  AND Term='"), publicSubsNFunctions.tm), "' AND Year='"), publicSubsNFunctions.yr), "')"));
                        publicSubsNFunctions.qread(ref argq1);
                        while (publicSubsNFunctions.dbreader.Read())
                        {
                            if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[m])))
                            {
                                out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[m], publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_name, publicSubsNFunctions.class_form, publicSubsNFunctions.dbreader["Stream"], 2);
                                cnt += 1;
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[m]), out_of), 100)), publicSubsNFunctions.grading, Conversions.ToString(publicSubsNFunctions.subjabb[m])))));
                            }
                        }

                        publicSubsNFunctions.dbreader.Close();
                    }

                    if (cnt > 0)
                    {
                        dgvSubjects["MeanPoints", Conversions.ToInteger(k)].Value = Strings.Format(tp / (double)cnt, "0.00");
                    }
                    else
                    {
                        dgvSubjects["MeanPoints", Conversions.ToInteger(k)].Value = "0.00";
                    }
                }
            }
        }

        private object print_student_report()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_report;
            return print_document;
        }

        private string[] subjectsPerGroup(string group)
        {
            int i = 0;
            string[] subjs;
            string argq = "SELECT subject FROM subjects WHERE department='" + publicSubsNFunctions.escape_string(group) + "'";
            publicSubsNFunctions.qread(ref argq);
            subjs = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            while (publicSubsNFunctions.dbreader.Read())
            {
                subjs[i] = Conversions.ToString(publicSubsNFunctions.dbreader["subject"]);
                i += 1;
            }

            return subjs;
        }

        private string[] loadDepartments()
        {
            string[] depts;
            int i = 0;
            string argq = "SELECT department FROM departments ORDER BY id";
            publicSubsNFunctions.qread(ref argq);
            depts = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            while (publicSubsNFunctions.dbreader.Read())
            {
                depts[i] = Conversions.ToString(publicSubsNFunctions.dbreader["department"]);
                i += 1;
            }

            return depts;
        }

        private void print_report(object sender, PrintPageEventArgs e)
        {
            // e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
            var line = default(int);
            int left_margin = 50;
            int right_margin = 780;
            int topline;
            float CenterPage;
            line += 20;
            try
            {
                e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + publicSubsNFunctions.logo()), left_margin + 10, line, 100, 100);
                line += 15;
            }
            catch (Exception ex)
            {
            }

            line = 50;
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

            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("EXAMINATION DEPARTMENT", publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString("EXAMINATION DEPARTMENT", publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height;
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.exam_name.ToUpper() + "     Term " + publicSubsNFunctions.tm + "     " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString(publicSubsNFunctions.exam_name.ToUpper() + "     Term " + publicSubsNFunctions.tm + "     " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height;
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.class_form.ToString().ToUpper() + " SUBJECT MEAN ANALYSIS REPORT", publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString(publicSubsNFunctions.class_form.ToString().ToUpper() + " SUBJECT MEAN ANALYSIS REPORT", publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height;
            line += 15;
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
            line += 10;
            topline = line;
            if (publicSubsNFunctions.rpt == "List")
            {
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                e.Graphics.DrawString("SUBJECT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 10, line + 3);
                e.Graphics.DrawString("MEAN MARK", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 300, line + 3);
                e.Graphics.DrawString("MEAN GRADE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 420, line + 3);
                e.Graphics.DrawString("MEAN POINTS", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 562, line + 3);
                line += 22;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                for (int k = 0, loopTo = dgvSubjects.Rows.Count - 1; k <= loopTo; k++)
                {
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["SubjectName", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 10, line + 3);
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MeanMark", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 300, line + 3);
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MeanGrade", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 430, line + 3);
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MeanPoints", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 575, line + 3);
                    line += 22;
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                }

                e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 290, topline, left_margin + 290, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 410, topline, left_margin + 410, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 560, topline, left_margin + 560, line);
                e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline, right_margin - 2, line);
            }
            else
            {
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                e.Graphics.DrawString("SUBJECT GRP", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 10, line + 3);
                e.Graphics.DrawString("SUBJECT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 120, line + 3);
                e.Graphics.DrawString("MEAN MARK", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 390, line + 3);
                e.Graphics.DrawString("MEAN GRADE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 505, line + 3);
                e.Graphics.DrawString("MEAN POINTS", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 625, line + 3);
                line += publicSubsNFunctions.other_font.Height + 3;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                var depts = loadDepartments();
                for (int k = 0, loopTo1 = depts.Length - 1; k <= loopTo1; k++)
                {
                    double tp, tm, cnt;
                    tp = 0d;
                    tm = 0d;
                    cnt = 0d;
                    e.Graphics.DrawString(depts[k], publicSubsNFunctions.other_font, Brushes.Black, left_margin + 10, line + 3);
                    var subjs = subjectsPerGroup(depts[k]);
                    for (int count = 0, loopTo2 = subjs.Length - 1; count <= loopTo2; count++)
                    {
                        for (int row = 0, loopTo3 = dgvSubjects.Rows.Count - 1; row <= loopTo3; row++)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvSubjects["SubjectName", row].Value, subjs[count], false)))
                            {
                                e.Graphics.DrawString(subjs[count], publicSubsNFunctions.other_font, Brushes.Black, left_margin + 120, line + 3);
                                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MeanMark", row].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 405, line + 3);
                                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MeanGrade", row].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 510, line + 3);
                                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MeanPoints", row].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 645, line + 3);
                                line += publicSubsNFunctions.other_font.Height + 3;
                                if (Information.IsNumeric(dgvSubjects["MeanPoints", row].Value))
                                {
                                    tp = Conversions.ToDouble(tp + dgvSubjects["MeanPoints", row].Value);
                                    tm = Conversions.ToDouble(tm + dgvSubjects["MeanMark", row].Value);
                                    cnt += 1d;
                                }

                                e.Graphics.DrawLine(Pens.Black, left_margin + 118, line, right_margin - 2, line);
                                break;
                            }
                        }
                    }

                    if (cnt > 0d & tp > 0d)
                    {
                        e.Graphics.DrawString(Strings.Format(tm / cnt, "0.00"), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 405, line + 3);
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(tp / cnt)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 510, line + 3);
                        e.Graphics.DrawString(Strings.Format(tp / cnt, "0.00"), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 645, line + 3);
                    }
                    else
                    {
                        e.Graphics.DrawString("--", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 350, line + 3);
                        e.Graphics.DrawString("--", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 450, line + 3);
                        e.Graphics.DrawString("--", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 555, line + 3);
                    }

                    line += publicSubsNFunctions.other_font.Height + 3;
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                }

                e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 118, topline, left_margin + 118, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 390, topline, left_margin + 390, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 490, topline, left_margin + 490, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 610, topline, left_margin + 610, line);
                e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline, right_margin - 2, line);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.rpt = "List";
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_report();
            print_document.DefaultPageSettings.Landscape = false;
            printpreview.Document = print_document;
            printpreview.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.rpt = "Group";
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_report();
            print_document.DefaultPageSettings.Landscape = false;
            printpreview.Document = print_document;
            printpreview.ShowDialog();
        }
    }
}