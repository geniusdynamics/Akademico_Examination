using System;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmNationalMeanAnalysis
    {
        public frmNationalMeanAnalysis()
        {
            InitializeComponent();
            _GroupBox1.Name = "GroupBox1";
            _ComboBox1.Name = "ComboBox1";
            _btnPrint.Name = "btnPrint";
            _btnPrintPreview.Name = "btnPrintPreview";
            _btnCancel.Name = "btnCancel";
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
                publicSubsNFunctions.load_stream1(ComboBox1, "FORM 4");
                ComboBox1.SelectedItem = null;
                loadData();
            }
        }

        private void loadData()
        {
            int total, count;
            bool prime = publicSubsNFunctions.IsPrimary();
            dgvSubjects.Rows.Clear();
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ComboBox1.SelectedItem, null, false)))
                {
                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `", publicSubsNFunctions.subjabb[k]), "` FROM `kcse_results` WHERE (Year='"), publicSubsNFunctions.yr), "' AND  Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "')"));
                }
                else
                {
                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `", publicSubsNFunctions.subjabb[k]), "` FROM `kcse_results` WHERE (Year='"), publicSubsNFunctions.yr), "' AND  Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND Stream='"), publicSubsNFunctions.escape_string(Conversions.ToString(ComboBox1.SelectedItem))), "')"));
                }

                if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
                {
                    total = 0;
                    count = 0;
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k]), "-", false), Operators.ConditionalCompareObjectNotEqual(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k]), string.Empty, false)), Operators.ConditionalCompareObjectNotEqual(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k]), "X", false))))
                        {
                            if (prime)
                            {
                                var values = publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k]).ToString().Split(' ');
                                total = Conversions.ToInteger(total + publicSubsNFunctions.fix_point(values[values.Length - 1]));
                            }
                            else
                            {
                                total = Conversions.ToInteger(total + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k]))));
                            }

                            count += 1;
                        }
                    }

                    dgvSubjects.Rows.Add();
                    dgvSubjects["SubjID", k].Value = publicSubsNFunctions.subjids[k];
                    dgvSubjects["Abbreviation", k].Value = publicSubsNFunctions.subjabb[k];
                    dgvSubjects["SubjectName", k].Value = publicSubsNFunctions.subjects[k];
                    if (count == 0 | total == 0)
                    {
                        dgvSubjects["MeanPoints", k].Value = 0.0d;
                    }
                    else
                    {
                        dgvSubjects["MeanPoints", k].Value = Strings.Format(total / (double)count, "0.00");
                    }
                }
            }

            for (int k = 0, loopTo1 = dgvSubjects.Rows.Count - 1; k <= loopTo1; k++)
            {
                if (publicSubsNFunctions.mode)
                {
                    dgvSubjects["MeanGrade", k].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvSubjects["MeanPoints", k].Value));
                }
                else
                {
                    dgvSubjects["MeanGrade", k].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvSubjects["MeanPoints", k].Value));
                }
            }

            for (int k = 0, loopTo2 = dgvSubjects.Rows.Count - 1; k <= loopTo2; k++)
                dgvSubjects["MeanPoints", k].Value = Convert.ToDecimal(dgvSubjects["MeanPoints", k].Value);
            dgvSubjects.Sort(dgvSubjects.Columns["MeanPoints"], System.ComponentModel.ListSortDirection.Descending);
        }
        // Private Sub points(ByVal k)
        // Dim tp, cnt, marks(0) As Integer
        // For m As Integer = 0 To subjabb.Length - 1
        // tp = 0
        // cnt = 0
        // If dgvSubjects.Item("Abbreviation", k).Value = subjabb(m) Then
        // If mode Then
        // For t As Integer = 0 To tables.Length - 1
        // qread("SELECT `" & subjname(m) & "` FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(tables(t)) & "' AND Term='" & tm & "' AND Year='" & yr & "')")
        // ReDim Preserve marks(dbReader.RecordsAffected - 1)
        // Dim i As Integer = 0
        // While dbReader.Read
        // If IsNumeric(dbReader(subjname(m))) Then
        // marks(i) += dbReader(subjname(m)) / total_mark(t) * contribution(t)
        // End If
        // i += 1
        // End While
        // dbReader.Close()
        // Next
        // For l As Integer = 0 To marks.Length - 1
        // cnt += 1
        // tp += fix_point(get_grade(marks(l), grading, subjabb(m)))
        // Next
        // Else
        // Dim mark As Integer = get_total_mark(exam_name, tm)
        // qread("SELECT `" & subjname(m) & "` FROM `" & table & "` WHERE (class='" & escape_string(class_form) & "' AND Examination='" & escape_string(exam_name) & "'  AND Term='" & tm & "' AND Year='" & yr & "')")
        // While dbReader.Read
        // If IsNumeric(dbReader(subjname(m))) Then
        // cnt += 1
        // tp += fix_point(get_grade((dbReader(subjname(m)) / mark) * 100, grading, subjabb(m)))
        // End If
        // End While
        // dbReader.Close()
        // End If
        // If cnt > 0 Then
        // dgvSubjects.Item("MeanPoints", k).Value = Format(tp / cnt, "0.00")
        // Else
        // dgvSubjects.Item("MeanPoints", k).Value = "0.00"
        // End If
        // End If
        // Next
        // End Sub
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
            string argq = "SELECT Name FROM departments ORDER BY DepartmentID";
            publicSubsNFunctions.qread(ref argq);
            depts = new string[publicSubsNFunctions.dbreader.RecordsAffected];
            while (publicSubsNFunctions.dbreader.Read())
            {
                depts[i] = Conversions.ToString(publicSubsNFunctions.dbreader["Name"]);
                i += 1;
            }

            return depts;
        }

        private void print_report(object sender, PrintPageEventArgs e)
        {
            // e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
            int line;
            int left_margin = 60;
            int right_margin = 720;
            int topline;
            line = 50;
            e.Graphics.DrawString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font, Brushes.Black, left_margin + 150, line);
            line += publicSubsNFunctions.header_font.Height;
            e.Graphics.DrawString("EXAMINATION DEPARTMENT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 200, line);
            line += publicSubsNFunctions.other_font.Height;
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(ComboBox1.SelectedItem, null, false)))
            {
                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("FORM 4 ", ComboBox1.SelectedItem), " "), publicSubsNFunctions.yr), " "), publicSubsNFunctions.exam_name.ToUpper())), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 200, line);
            }
            else
            {
                e.Graphics.DrawString("FORM 4 " + publicSubsNFunctions.yr + " " + publicSubsNFunctions.exam_name.ToUpper(), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 200, line);
            }

            line += publicSubsNFunctions.other_font.Height;
            e.Graphics.DrawString(publicSubsNFunctions.exam_name.ToString().ToUpper() + " " + publicSubsNFunctions.yr + " SUBJECT MEAN ANALYSIS REPORT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 160, line);
            line += publicSubsNFunctions.other_font.Height;
            // e.Graphics.DrawString(, other_font, Brushes.Black, left_margin + 150, line)
            line += 15;
            topline = line;
            if (publicSubsNFunctions.rpt == "List")
            {
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                e.Graphics.DrawString("SUBJECT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 10, line + 3);
                e.Graphics.DrawString("MEAN GRADE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 400, line + 3);
                e.Graphics.DrawString("MEAN POINTS", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 500, line + 3);
                line += 22;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                for (int k = 0, loopTo = dgvSubjects.Rows.Count - 1; k <= loopTo; k++)
                {
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["SubjectName", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 10, line + 3);
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MeanGrade", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 400, line + 3);
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MeanPoints", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 500, line + 3);
                    line += 22;
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                }

                e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 390, topline, left_margin + 390, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 490, topline, left_margin + 490, line);
                e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline, right_margin - 2, line);
            }
            else
            {
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                e.Graphics.DrawString("SUBJECT GROUP", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 5, line + 3);
                e.Graphics.DrawString("SUBJECT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 140, line + 3);
                e.Graphics.DrawString("MEAN GRADE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 450, line + 3);
                e.Graphics.DrawString("MEAN POINTS", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 556, line + 3);
                line += publicSubsNFunctions.other_font.Height + 3;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                var depts = loadDepartments();
                for (int k = 0, loopTo1 = depts.Length - 1; k <= loopTo1; k++)
                {
                    double dev = 0d;
                    double tp, tm, cnt;
                    tp = 0d;
                    tm = 0d;
                    cnt = 0d;
                    e.Graphics.DrawString(depts[k], publicSubsNFunctions.other_font, Brushes.Black, left_margin + 5, line + 3);
                    var subjs = subjectsPerGroup(depts[k]);
                    for (int count = 0, loopTo2 = subjs.Length - 1; count <= loopTo2; count++)
                    {
                        for (int row = 0, loopTo3 = dgvSubjects.Rows.Count - 1; row <= loopTo3; row++)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvSubjects["SubjectName", row].Value, subjs[count], false)))
                            {
                                e.Graphics.DrawString(subjs[count], publicSubsNFunctions.other_font, Brushes.Black, left_margin + 135, line + 3);
                                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MeanGrade", row].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 460, line + 3);
                                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MeanPoints", row].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 565, line + 3);
                                line += publicSubsNFunctions.other_font.Height + 3;
                                tp = Conversions.ToDouble(tp + dgvSubjects["MeanPoints", row].Value);
                                cnt += 1d;
                                e.Graphics.DrawLine(Pens.Black, left_margin + 118, line, right_margin - 2, line);
                                break;
                            }
                        }
                    }

                    if (cnt > 0d & tp > 0d)
                    {
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(tp / cnt)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 460, line + 3);
                        e.Graphics.DrawString(Strings.Format(tp / cnt, "0.00"), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 565, line + 3);
                    }
                    else
                    {
                        e.Graphics.DrawString("--", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 460, line + 3);
                        e.Graphics.DrawString("--", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 550, line + 3);
                    }

                    e.Graphics.DrawString(" AVERAGE " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font, Brushes.Black, left_margin + 200, line + 3);
                    line += publicSubsNFunctions.other_font.Height + 3;
                    e.Graphics.DrawLine(Pens.Black, left_margin + 118, line, right_margin - 2, line);
                    e.Graphics.DrawString(" AVERAGE " + (publicSubsNFunctions.yr - 1), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 200, line + 3);
                    double pts = PreviousPoints(publicSubsNFunctions.yr - 1, depts[k]);
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(pts)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 460, line + 3);
                    e.Graphics.DrawString(Strings.Format(pts, "0.00"), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 565, line + 3);
                    line += publicSubsNFunctions.other_font.Height + 3;
                    dev = tp / cnt - pts;
                    e.Graphics.DrawLine(Pens.Black, left_margin + 118, line, right_margin - 2, line);
                    e.Graphics.DrawString(" DEVIATION ", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 200, line + 3);
                    if (dev > 0d)
                    {
                        e.Graphics.DrawString("+" + Strings.Format(dev, "0.00"), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 565, line + 3);
                    }
                    else
                    {
                        e.Graphics.DrawString(Strings.Format(dev, "0.00"), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 565, line + 3);
                    }

                    line += publicSubsNFunctions.other_font.Height + 3;
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
                }

                e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 118, topline, left_margin + 118, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 445, topline, left_margin + 445, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 555, topline, left_margin + 555, line);
                e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline, right_margin - 2, line);
            }
        }

        private double PreviousPoints(int yr, string dept)
        {
            string argq = "SELECT sum(mp) as mp, count(*) as num FROM `kcse_overall_subject_performance` WHERE subject IN (SELECT subject FROM subjects WHERE department='" + publicSubsNFunctions.escape_string(dept) + "') AND year='" + yr + "'";
            publicSubsNFunctions.qread(ref argq);
            publicSubsNFunctions.dbreader.Read();
            try
            {
                return Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader["mp"], publicSubsNFunctions.dbreader["num"]));
            }
            catch (Exception ex)
            {
                return Conversions.ToDouble("--");
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

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            publicSubsNFunctions.rpt = "Group";
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_report();
            print_document.DefaultPageSettings.Landscape = false;
            printpreview.Document = print_document;
            printpreview.ShowDialog();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}