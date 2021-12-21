using System;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmStudentProfile
    {
        public frmStudentProfile()
        {
            InitializeComponent();
            _Button2.Name = "Button2";
            _txtADMNo.Name = "txtADMNo";
            _txtName.Name = "txtName";
        }

        private void frmStudentProfile_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                create_dataform();
                show_record();
            }
        }

        private void show_record()
        {
            var frm = new frmAllStudentsPrompt();
            frm.ShowDialog();
            if (publicSubsNFunctions.cont)
            {
                string argq = "SELECT student_name, Class, Stream FROM students WHERE admin_no='" + publicSubsNFunctions.t_id + "'";
                if (publicSubsNFunctions.qread(ref argq))
                {
                    publicSubsNFunctions.dbreader.Read();
                    txtADMNo.Text = publicSubsNFunctions.t_id.ToString();
                    txtName.Text = Conversions.ToString(publicSubsNFunctions.dbreader["student_name"]);
                    publicSubsNFunctions.class_form = Conversions.ToString(publicSubsNFunctions.dbreader["Class"]);
                    publicSubsNFunctions.stream = Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]);
                    ShowProfile();
                }
            }
        }

        private void txtADMNo_Click(object sender, EventArgs e)
        {
            show_record();
        }

        private void ShowProfile()
        {
            ProgressBar1.Visible = true;
            dgvEnterMarks.Rows.Clear();
            string argq = "SELECT *, `examinations`.`Total` AS Totals FROM exam_results LEFT JOIN examinations ON (exam_results.Examination=examinations.ExamName) WHERE exam_results.Term=examinations.Term AND exam_results.Year=examinations.Year AND ADMNo='" + publicSubsNFunctions.escape_string(txtADMNo.Text) + "' ORDER BY `id`";
            publicSubsNFunctions.qread(ref argq);
            int inc;
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                inc = (int)Math.Round(100d / publicSubsNFunctions.dbreader.RecordsAffected);
            }
            else
            {
                inc = 100;
            }

            double out_of;
            while (publicSubsNFunctions.dbreader.Read())
            {
                dgvEnterMarks.Rows.Add();
                dgvEnterMarks["Year", dgvEnterMarks.Rows.Count - 1].Value = publicSubsNFunctions.dbreader["Year"];
                dgvEnterMarks["Term", dgvEnterMarks.Rows.Count - 1].Value = publicSubsNFunctions.dbreader["Term"];
                dgvEnterMarks["Examination", dgvEnterMarks.Rows.Count - 1].Value = publicSubsNFunctions.dbreader["Examination"];
                int se = 0;
                for (int k = 0, loopTo = publicSubsNFunctions.subjname.Length - 1; k <= loopTo; k++)
                {
                    if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k])))
                    {
                        out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.dbreader["Term"], publicSubsNFunctions.dbreader["Year"], publicSubsNFunctions.dbreader["Examination"], publicSubsNFunctions.dbreader["Class"], publicSubsNFunctions.dbreader["Stream"], 2);
                        dgvEnterMarks[publicSubsNFunctions.subjname[k].ToString(), dgvEnterMarks.Rows.Count - 1].Value = Math.Round(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), out_of), 100), (object)0);
                    }
                    else
                    {
                        dgvEnterMarks[publicSubsNFunctions.subjname[k].ToString(), dgvEnterMarks.Rows.Count - 1].Value = publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]);
                    }

                    if (publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]).ToString() != "-")
                    {
                        se += 1;
                    }
                }

                dgvEnterMarks["Sent", dgvEnterMarks.Rows.Count - 1].Value = se;
                ProgressBar1.Increment(inc);
            }

            ProgressBar1.Increment(-100);
            string grade;
            publicSubsNFunctions.get_grades();
            string curr_class = publicSubsNFunctions.class_form;
            for (int k = 0, loopTo1 = dgvEnterMarks.Rows.Count - 1; k <= loopTo1; k++)
            {
                double tp = 0d;
                double tmK = 0d;
                publicSubsNFunctions.tm = Conversions.ToString(dgvEnterMarks["Term", k].Value);
                publicSubsNFunctions.yr = Conversions.ToInteger(dgvEnterMarks["Year", k].Value);
                int LIMIT = 0;
                if (publicSubsNFunctions.yr != DateAndTime.Today.Year)
                {
                    LIMIT = DateAndTime.Today.Year - publicSubsNFunctions.yr;
                    string argq1 = "SELECT `class` FROM `class_stream` WHERE `class` < '" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' ORDER BY `class` DESC LIMIT " + LIMIT;
                    publicSubsNFunctions.qread(ref argq1);
                    if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                    {
                        publicSubsNFunctions.dbreader.Read();
                        curr_class = Conversions.ToString(publicSubsNFunctions.dbreader["class"]);
                    }
                }

                for (int s = 0, loopTo2 = publicSubsNFunctions.subjname.Length - 1; s <= loopTo2; s++)
                {
                    grade = null;
                    if (Information.IsNumeric(dgvEnterMarks[publicSubsNFunctions.subjname[s].ToString(), k].Value))
                    {
                        grade = Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[publicSubsNFunctions.subjname[s].ToString(), k].Value), true, Conversions.ToString(publicSubsNFunctions.subjabb[s]), curr_class));
                        tmK = Conversions.ToDouble(tmK + dgvEnterMarks[publicSubsNFunctions.subjname[s].ToString(), k].Value);
                        dgvEnterMarks[publicSubsNFunctions.subjname[s].ToString(), k].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks[publicSubsNFunctions.subjname[s].ToString(), k].Value, " "), grade);
                        tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(grade));
                    }
                }

                dgvEnterMarks["TP", k].Value = tp;
                dgvEnterMarks["MP", k].Value = Strings.Format(Operators.DivideObject(tp, dgvEnterMarks["Sent", dgvEnterMarks.Rows.Count - 1].Value), "0.00");
                dgvEnterMarks["TM", k].Value = tmK;
                dgvEnterMarks["MM", k].Value = Strings.Format(Operators.DivideObject(tmK, dgvEnterMarks["Sent", dgvEnterMarks.Rows.Count - 1].Value), "0.00");
                dgvEnterMarks["MG", k].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvEnterMarks["MP", k].Value));
                ProgressBar1.Increment(inc);
            }

            ProgressBar1.Increment(-100);
            ProgressBar1.Visible = false;
        }

        private void create_dataform()
        {
            publicSubsNFunctions.get_subjects();
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                var column = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                column.CellTemplate = cell;
                column.ReadOnly = true;
                try
                {
                    column.Name = Conversions.ToString(publicSubsNFunctions.subjname[k]);
                    column.HeaderText = Conversions.ToString(publicSubsNFunctions.remove_wild(Conversions.ToString(publicSubsNFunctions.subjabb[k].Substring((object)0, (object)3))));
                }
                catch (Exception ex)
                {
                    column.Name = Conversions.ToString(publicSubsNFunctions.subjname[k]);
                    column.HeaderText = Conversions.ToString(publicSubsNFunctions.remove_wild(Conversions.ToString(publicSubsNFunctions.subjabb[k].Substring((object)0, (object)2))));
                }

                column.Width = 55;
                dgvEnterMarks.Columns.Add(column);
            }

            DataGridViewCell cellent = new DataGridViewTextBoxCell();
            var colent = new DataGridViewColumn();
            colent.CellTemplate = cellent;
            colent.Name = "Sent";
            colent.HeaderText = "SE";
            colent.Width = 50;
            colent.ReadOnly = true;
            dgvEnterMarks.Columns.Add(colent);
            DataGridViewCell celltp = new DataGridViewTextBoxCell();
            var coltp = new DataGridViewColumn();
            coltp.CellTemplate = celltp;
            coltp.Name = "TP";
            coltp.HeaderText = "TP";
            coltp.Width = 50;
            coltp.ReadOnly = true;
            coltp.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEnterMarks.Columns.Add(coltp);
            DataGridViewCell cellmp = new DataGridViewTextBoxCell();
            var colmp = new DataGridViewColumn();
            colmp.CellTemplate = cellmp;
            colmp.Name = "MP";
            colmp.HeaderText = "MP";
            colmp.Width = 50;
            colmp.ReadOnly = true;
            colmp.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEnterMarks.Columns.Add(colmp);
            DataGridViewCell cellmm = new DataGridViewTextBoxCell();
            var colmm = new DataGridViewColumn();
            colmm.CellTemplate = cellmm;
            colmm.Name = "MM";
            colmm.HeaderText = "MM";
            colmm.Width = 50;
            colmm.ReadOnly = true;
            colmm.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEnterMarks.Columns.Add(colmm);
            DataGridViewCell cellmg = new DataGridViewTextBoxCell();
            var colmg = new DataGridViewColumn();
            colmg.CellTemplate = cellmg;
            colmg.Name = "MG";
            colmg.HeaderText = "MG";
            colmg.Width = 50;
            colmg.SortMode = DataGridViewColumnSortMode.NotSortable;
            colmg.ReadOnly = true;
            dgvEnterMarks.Columns.Add(colmg);
            DataGridViewCell cell1 = new DataGridViewTextBoxCell();
            var column0 = new DataGridViewColumn();
            column0.CellTemplate = cell1;
            column0.Name = "TM";
            column0.HeaderText = "TM";
            column0.Width = 60;
            column0.ReadOnly = true;
            column0.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEnterMarks.Columns.Add(column0);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_report2();
            print_document.DefaultPageSettings.Landscape = true;
            Print_Preview.Document = print_document;
            Print_Preview.ShowDialog();
        }

        private object print_student_report2()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_report2;
            return print_document;
        }

        private int start_from = 0;

        private void print_report2(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            int line = 20;
            int left_margin = 80;
            int right_margin = 1050;
            int count = 0;
            float CenterPage;
            if (start_from == 0)
            {
                try
                {
                    e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + publicSubsNFunctions.logo()), left_margin + 10, line, 90, 90);
                    line += 15;
                }
                catch (Exception ex)
                {
                }

                line = 20;
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

                line -= 5;
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("STUDENT PROGRESS REPORT", publicSubsNFunctions.header_font).Width / 2f);
                e.Graphics.DrawString("STUDENT ACADEMIC PROFILE", publicSubsNFunctions.header_font, Brushes.Black, CenterPage, line + 5);
                line += publicSubsNFunctions.other_font.Height + 5;
            }

            line += 20;
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
            line += 10;
            e.Graphics.DrawString("Admission No: " + txtADMNo.Text + "                 Name Of Student: " + txtName.Text + "                    Class: " + publicSubsNFunctions.class_form + " " + publicSubsNFunctions.stream, publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            line += publicSubsNFunctions.other_font.Height + 5;
            line += 10;
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
            line += 10;
            for (int col = 0, loopTo = dgvEnterMarks.Columns.Count - 1; col <= loopTo; col++)
            {
                if (dgvEnterMarks.Columns[col].Visible)
                {
                    if (count == 1)
                    {
                        e.Graphics.DrawString(dgvEnterMarks.Columns[col].HeaderText, publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                    }
                    else
                    {
                        try
                        {
                            e.Graphics.DrawString(dgvEnterMarks.Columns[col].HeaderText, publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                        }
                        catch (Exception ex)
                        {
                            e.Graphics.DrawString(dgvEnterMarks.Columns[col].HeaderText, publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                        }
                    }

                    count += 1;
                    if (count == 3)
                    {
                        left_margin += 100;
                    }
                    else
                    {
                        left_margin += 35;
                    }
                }
            }

            line += 10;
            for (int row = start_from, loopTo1 = dgvEnterMarks.Rows.Count - 1; row <= loopTo1; row++)
            {
                line += 2;
                if (line >= 806 & row < dgvEnterMarks.Rows.Count - 1)
                {
                    e.HasMorePages = true;
                    start_from = row;
                    return;
                }

                left_margin = 80;
                count = 0;
                for (int col = 0, loopTo2 = dgvEnterMarks.Columns.Count - 1; col <= loopTo2; col++)
                {
                    if (dgvEnterMarks.Columns[col].Visible)
                    {
                        if (count == 2)
                        {
                            if (dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value.ToString().Length > 13)
                            {
                                e.Graphics.DrawString(dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value.ToString().Substring(0, 13), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                            }
                            else
                            {
                                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                        }

                        count += 1;
                        if (count == 3)
                        {
                            left_margin += 100;
                        }
                        else
                        {
                            left_margin += 35;
                        }
                    }
                }

                line += 2;
                e.Graphics.DrawLine(Pens.Black, 80, line, left_margin, line);
                line += 10;
            }

            line += 10;
            if (line + 100 + 20 * publicSubsNFunctions.grades.Length + 1 >= 806)
            {
                start_from = dgvEnterMarks.Rows.Count;
                e.HasMorePages = true;
                return;
            }

            left_margin = 80;
            line += 10;
            int topline = line;
            var npen = new Pen(Color.Silver, 1f);
            npen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            for (int k = 0, loopTo3 = publicSubsNFunctions.grades.Length - 1; k <= loopTo3; k++)
            {
                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.other_font, Brushes.Black, left_margin, line - 8);
                e.Graphics.DrawLine(npen, left_margin + 20, line, right_margin, line);
                line += 20;
            }

            e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, left_margin + 20, topline);
            e.Graphics.DrawLine(Pens.Black, left_margin + 20, line, right_margin, line);
            for (int k = 0, loopTo4 = dgvEnterMarks.Rows.Count - 1; k <= loopTo4; k++)
            {
                int graphtop = topline;
                for (int g = 0, loopTo5 = publicSubsNFunctions.grades.Length - 1; g <= loopTo5; g++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["MG", k].Value, publicSubsNFunctions.grades[g], false)))
                    {
                        var rect = new Rectangle(left_margin + 20 + k * 20, graphtop, 10, line - graphtop);
                        e.Graphics.FillRectangle(Brushes.Black, rect);
                    }
                    else
                    {
                        graphtop += 20;
                    }
                }
            }

            line += 10;
            e.Graphics.DrawString("   SE	= SUBJECT ENTRIES               STR = STREAM" + Constants.vbNewLine + "   TP	= TOTAL POINTS                  MM  = MEAN MARKS" + Constants.vbNewLine + "   MP	= MEAN POINTS					 " + Constants.vbNewLine + "   TM	= TOTAL MARKS                   MG  = MEAN GRADE", publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            start_from = 0;
        }
    }
}