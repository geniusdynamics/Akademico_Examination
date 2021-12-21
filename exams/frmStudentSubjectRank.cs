using System;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmStudentSubjectRank
    {
        public frmStudentSubjectRank()
        {
            InitializeComponent();
            _btnPrint.Name = "btnPrint";
            _btnCancel.Name = "btnCancel";
        }

        private string[] admnos;

        private void frmStudentSubjectRank_Load(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(!publicSubsNFunctions.connect(), publicSubsNFunctions.dbNewOpen())))
            {
                Close();
            }
            else
            {
                load_it();
            }
        }

        private int ReturnStudentIndex(string adm)
        {
            for (int k = 0, loopTo = dgvSubjects.Rows.Count - 1; k <= loopTo; k++)
            {
                if ((dgvSubjects["ADMNo", k].Value.ToString() ?? "") == (adm ?? ""))
                {
                    return k;
                }
            }

            return default;
        }

        private void load_it()
        {
            var frm = new frmSubjectRank();
            frm.ShowDialog();
            double out_of;
            if (!publicSubsNFunctions.rank)
            {
                Close();
            }
            else
            {
                lblTitle.Text = Conversions.ToString(Operators.ConcatenateObject("Student Subject Ranking Analysis for ", publicSubsNFunctions.get_subject_name(publicSubsNFunctions.subject)));
                if (publicSubsNFunctions.mode)
                {
                    int i;
                    bool exist = false;
                    for (int k = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo; k++)
                    {
                        string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ADMNo, StudentName, Stream,`" + publicSubsNFunctions.subject + "` FROM `" + publicSubsNFunctions.table + "` WHERE (Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "'  AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "' AND ADMNo IN (SELECT ADMNo FROM subjects_done WHERE `"), publicSubsNFunctions.subject), "`='Yes')) ORDER BY `"), publicSubsNFunctions.subject), "` DESC"));
                        if (publicSubsNFunctions.qread(ref argq))
                        {
                            i = 0;
                            while (publicSubsNFunctions.dbreader.Read())
                            {
                                if (dgvSubjects.Rows.Count < publicSubsNFunctions.dbreader.RecordsAffected)
                                {
                                    dgvSubjects.Rows.Add();
                                    dgvSubjects["ADMNo", dgvSubjects.Rows.Count - 1].Value = publicSubsNFunctions.dbreader["ADMNo"];
                                    dgvSubjects["StudentName", dgvSubjects.Rows.Count - 1].Value = publicSubsNFunctions.dbreader["StudentName"];
                                }
                                else
                                {
                                    exist = true;
                                    i = ReturnStudentIndex(Conversions.ToString(publicSubsNFunctions.dbreader["ADMNo"]));
                                }

                                if (Information.IsNumeric(publicSubsNFunctions.dbreader[publicSubsNFunctions.subject]))
                                {
                                    out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subject, publicSubsNFunctions.tms[k], publicSubsNFunctions.yrs[k], publicSubsNFunctions.exam_names[k], publicSubsNFunctions.class_form, publicSubsNFunctions.dbreader["Stream"], 2);
                                    if (Information.IsNumeric(dgvSubjects["MarkAttained", i].Value))
                                    {
                                        dgvSubjects["MarkAttained", i].Value = Operators.AddObject(dgvSubjects["MarkAttained", i].Value, Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[publicSubsNFunctions.subject], out_of), publicSubsNFunctions.total_mark[k]), publicSubsNFunctions.contribution[k] / (double)publicSubsNFunctions.total_mark[k]));
                                    }
                                    else
                                    {
                                        dgvSubjects["MarkAttained", i].Value = Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[publicSubsNFunctions.subject], out_of), publicSubsNFunctions.total_mark[k]), publicSubsNFunctions.contribution[k] / (double)publicSubsNFunctions.total_mark[k]);
                                    } // todo added the brackets coz of BODMAS
                                }

                                i += 1;
                            }
                        }
                    }

                    var loopTo1 = dgvSubjects.Rows.Count - 1;
                    for (i = 0; i <= loopTo1; i++)
                    {
                        // dgvSubjects.Item("MarkAttained", i).Value = Math.Round(dgvSubjects.Item("MarkAttained", i).Value, 0)
                    }

                    var loopTo2 = dgvSubjects.Rows.Count - 1;
                    for (i = 0; i <= loopTo2; i++)
                    {
                        if (Information.IsNumeric(dgvSubjects["MarkAttained", i].Value))
                        {
                            dgvSubjects["GradeAttained", i].Value = publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvSubjects["MarkAttained", i].Value), publicSubsNFunctions.mod_subject, publicSubsNFunctions.subject);
                        }
                        else
                        {
                            dgvSubjects["GradeAttained", i].Value = "-";
                        }
                    }
                }
                else
                {
                    string argq1 = "SELECT ADMNo, StudentName, Stream,`" + publicSubsNFunctions.subject + "` FROM `" + publicSubsNFunctions.table + "` WHERE Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "'  AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' ORDER BY `" + publicSubsNFunctions.subject + "` DESC";
                    if (publicSubsNFunctions.qread(ref argq1))
                    {
                        int i = 0;
                        while (publicSubsNFunctions.dbreader.Read())
                        {
                            out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subject, publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_name, publicSubsNFunctions.class_form, publicSubsNFunctions.dbreader["Stream"], 2);
                            if (Information.IsNumeric(publicSubsNFunctions.dbreader[publicSubsNFunctions.subject]))
                            {
                                dgvSubjects.Rows.Add();
                                dgvSubjects["ADMNo", i].Value = publicSubsNFunctions.get_id(publicSubsNFunctions.dbreader["ADMNo"]);
                                dgvSubjects["StudentName", i].Value = publicSubsNFunctions.dbreader["StudentName"];
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader[publicSubsNFunctions.subject]))
                                {
                                    dgvSubjects["MarkAttained", i].Value = Math.Round(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[publicSubsNFunctions.subject], out_of), publicSubsNFunctions.marks), (object)0);
                                }
                                else
                                {
                                    dgvSubjects["MarkAttained", i].Value = publicSubsNFunctions.dbreader[publicSubsNFunctions.subject];
                                }

                                i += 1;
                            }
                        }

                        var loopTo3 = dgvSubjects.Rows.Count - 1;
                        for (i = 0; i <= loopTo3; i++)
                        {
                            if (Information.IsNumeric(dgvSubjects["MarkAttained", i].Value))
                            {
                                // todo original code below
                                // dgvSubjects.Item("GradeAttained", i).Value = get_grade((dgvSubjects.Item("MarkAttained", i).Value / out_of) * 100, mod_subject, subject)
                                dgvSubjects["GradeAttained", i].Value = publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvSubjects["MarkAttained", i].Value), publicSubsNFunctions.mod_subject, publicSubsNFunctions.subject);
                            }
                            else
                            {
                                dgvSubjects["GradeAttained", i].Value = dgvSubjects["MarkAttained", i].Value;
                            }
                        }
                    }
                }
            }

            dgvSubjects.Sort(dgvSubjects.Columns["MarkAttained"], System.ComponentModel.ListSortDirection.Descending);
            for (int k = 0, loopTo4 = dgvSubjects.Rows.Count - 1; k <= loopTo4; k++)
            {
                dgvSubjects["MarkAttained", k].Value = Strings.Format(dgvSubjects["MarkAttained", k].Value, "0.00");
                dgvSubjects["Points", k].Value = publicSubsNFunctions.fix_point(Conversions.ToString(dgvSubjects["GradeAttained", k].Value));
            }
            // If qread("SELECT ADMNo, StudentName, `" & subject & "` FROM `" & table & "` WHERE ((Examination='" & escape_string(exam_name) & "' AND class='" & escape_string(ret_name(class_form)) & "' AND Term='" & tm & "' AND Year='" & yr & "') AND (`" & subject & "`='X' OR `" & subject & "`='Y' OR `" & subject & "`='-')) ORDER BY `" & subject & "` DESC") Then
            // While dbReader.Read
            // dgvSubjects.Rows.Add()
            // dgvSubjects.Item("ADMNo", dgvSubjects.Rows.Count - 1).Value = get_id(dbReader("ADMNo"))
            // dgvSubjects.Item("StudentName", dgvSubjects.Rows.Count - 1).Value = dbReader("StudentName")
            // dgvSubjects.Item("MarkAttained", dgvSubjects.Rows.Count - 1).Value = dbReader(subject)
            // End While
            // End If
            load_genders();
            // For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            // If Not IsNumeric(dgvSubjects.Item("MarkAttained", k).Value) Then
            // dgvSubjects.Item("GradeAttained", k).Value = dgvSubjects.Item("MarkAttained", k).Value
            // End If
            // Next
            trim_records();
        }

        private void trim_records()
        {
            if (publicSubsNFunctions.radF)
            {
                for (int k = dgvSubjects.Rows.Count - 1, loopTo = publicSubsNFunctions.rankno; k >= loopTo; k -= 1)
                    dgvSubjects.Rows.RemoveAt(k);
            }
            else if (publicSubsNFunctions.radL)
            {
                int to_delete = dgvSubjects.Rows.Count - publicSubsNFunctions.rankno;
                while (to_delete > 0)
                {
                    dgvSubjects.Rows.RemoveAt(0);
                    to_delete -= 1;
                }
            }
        }

        private void load_genders()
        {
            for (int k = 0, loopTo = dgvSubjects.Rows.Count - 1; k <= loopTo; k++)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Gender FROM students WHERE admin_no='", dgvSubjects["ADMNo", k].Value), "'"));
                publicSubsNFunctions.qread(ref argq);
                publicSubsNFunctions.dbreader.Read();
                try
                {
                    dgvSubjects["Gender", k].Value = publicSubsNFunctions.dbreader["Gender"];
                }
                catch (Exception ex)
                {
                }

                publicSubsNFunctions.dbreader.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private object print_student_report()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_report;
            return print_document;
        }

        private int start_from = 0;
        private double total_points;
        private double total;
        private int count = 0;
        private int prev_pos = 0;

        private void print_report(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            int avg = 380;
            int remarks = 450;
            int teacher = 520;
            int exam_width;
            try
            {
                exam_width = (int)Math.Round((380 - 150) / (double)publicSubsNFunctions.tables.Length);
            }
            catch (Exception ex)
            {
                exam_width = 380;
            }

            int line = 20;
            int left_margin = 125;
            int right_margin = 800;
            int topline;
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

            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.exam_name.ToString().ToUpper() + " Term ".ToString().ToUpper() + publicSubsNFunctions.tm.ToString().ToUpper() + " " + publicSubsNFunctions.yr.ToString().ToUpper(), publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString(publicSubsNFunctions.exam_name.ToString().ToUpper() + " Term ".ToString().ToUpper() + publicSubsNFunctions.tm.ToString().ToUpper() + " " + publicSubsNFunctions.yr.ToString().ToUpper(), publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            CenterPage = Convert.ToSingle((double)e.PageBounds.Width / 2d - (double)(e.Graphics.MeasureString(Conversions.ToString(Operators.ConcatenateObject("STUDENT SUBJECT RANKING REPORT FOR ", publicSubsNFunctions.get_subject_name(publicSubsNFunctions.subject).ToUpper)), publicSubsNFunctions.other_font).Width / 2f));
            e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject("STUDENT SUBJECT RANKING REPORT FOR ", publicSubsNFunctions.get_subject_name(publicSubsNFunctions.subject).ToUpper)), publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
            line += publicSubsNFunctions.other_font.Height;
            topline = line;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, left_margin + 600, line);
            e.Graphics.DrawString("POS.", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 5, line + 3);
            e.Graphics.DrawString("ADM.", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 50, line + 3);
            e.Graphics.DrawString("NAME OF STUDENT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 100, line + 3);
            e.Graphics.DrawString("MARK", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 350, line + 3);
            e.Graphics.DrawString("GRADE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 420, line + 3);
            e.Graphics.DrawString("POINTS", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 500, line + 3);
            line += 20;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, left_margin + 600, line);
            bool in_tie = false;
            for (int k = start_from, loopTo = dgvSubjects.Rows.Count - 1; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(dgvSubjects["MarkAttained", k].Value, string.Empty, false), Operators.ConditionalCompareObjectNotEqual(dgvSubjects["MarkAttained", k].Value, "-", false))))
                {
                    count += 1;
                    total = Conversions.ToDouble(total + dgvSubjects["MarkAttained", k].Value);
                    total_points = Conversions.ToDouble(total_points + dgvSubjects["Points", k].Value);
                }

                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["ADMNo", k].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 50, line + 3);
                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["StudentName", k].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 100, line + 3);
                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MarkAttained", k].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 350, line + 3);
                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["GradeAttained", k].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 420, line + 3);
                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["Points", k].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 500, line + 3);
                if (k > 0)
                {
                    if (Information.IsNumeric(dgvSubjects["MarkAttained", k].Value))
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvSubjects["MarkAttained", k].Value, dgvSubjects["MarkAttained", k - 1].Value, false)))
                        {
                            if (!in_tie)
                            {
                                in_tie = true;
                                prev_pos = k;
                            }

                            e.Graphics.DrawString(prev_pos.ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 10, line + 3);
                        }
                        else
                        {
                            in_tie = false;
                            e.Graphics.DrawString((k + 1).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 10, line + 3);
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawString((k + 1).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 10, line + 3);
                }

                line += publicSubsNFunctions.other_font.Height;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, left_margin + 600, line);
                if (line >= 1061 & k < dgvSubjects.Rows.Count - 1)
                {
                    start_from = k + 1;
                    e.HasMorePages = true;
                    break;
                }
            }

            e.Graphics.DrawString(string.Empty, publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 50, line + 3);
            e.Graphics.DrawString("MEAN SCORE", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 100, line + 3);
            e.Graphics.DrawString(Strings.Format(total / count, "0.00"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 350, line + 3);
            e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_points(total_points / count)), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 420, line + 3);
            e.Graphics.DrawString(Strings.Format(total_points / count, "0.00"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 500, line + 3);
            line += publicSubsNFunctions.other_font.Height;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, left_margin + 600, line);
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + 45, topline, left_margin + 45, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + 90, topline, left_margin + 90, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + 340, topline, left_margin + 340, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + 410, topline, left_margin + 410, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + 490, topline, left_margin + 490, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + 600, topline, left_margin + 600, line);
            if (e.HasMorePages == false)
            {
                start_from = 0;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_report();
            print_document.DefaultPageSettings.Landscape = false;
            Print_Preview.Document = print_document;
            Print_Preview.ShowDialog();
            // qwrite("DROP TABLE results")
            // query = "CREATE TABLE results(id int not null auto_increment , "
            // For k As Integer = 0 To dgvSubjects.Columns.Count - 1
            // query &= dgvSubjects.Columns(k).Name & " VARCHAR (100) NULL"
            // If k < dgvSubjects.Columns.Count - 1 Then
            // query &= ", "
            // End If
            // Next
            // query &= ", primary key(id))"
            // If Not qwrite(query) Then
            // qwrite("DROP TABLE results")
            // qwrite(query)
            // End If
            // query = "INSERT INTO results VALUES"
            // For k As Integer = 0 To dgvSubjects.Rows.Count - 1
            // query += "(NULL, "
            // For i As Integer = 0 To dgvSubjects.Columns.Count - 1
            // query += "'" & escape_string(dgvSubjects.Item(dgvSubjects.Columns(i).Name, k).Value) & "'"
            // If i < dgvSubjects.Columns.Count - 1 Then
            // query += ","
            // Else
            // query += ")"
            // End If
            // Next
            // If k < dgvSubjects.Rows.Count - 1 Then
            // query += ","
            // End If
            // Next
            // Dim new_class_form As String = ret_name(class_form).ToString.ToUpper
            // Dim title As String
            // If radF Then
            // title = new_class_form & "TOP " & rankno & " STUDENTS IN " & subject.ToUpper
            // ElseIf radL Then
            // title = new_class_form & "BOTTOM " & rankno & " STUDENTS IN " & subject.ToUpper
            // Else
            // title = new_class_form & "STUDENTS RANK IN " & get_subject_name(subject).ToString.ToUpper
            // End If
            // qwrite("UPDATE result_details SET class='" & new_class_form & "', code='" & exam_name & "', term='" & tm & "', year='" & Today.Year & "', title='" & title & "'")
            // If qwrite(query) Then
            // Dim frm As New frmReportRank
            // frm.ShowDialog()
            // End If
        }
    }
}