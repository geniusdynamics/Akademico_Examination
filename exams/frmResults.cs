using System;
using System.Collections.Generic;
using System.Drawing;
using global::System.Drawing.Printing;
using global::System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmResults
    {
        public frmResults()
        {
            InitializeComponent();
            _Button2.Name = "Button2";
            _btnViewReport.Name = "btnViewReport";
            _btnClassPerformance.Name = "btnClassPerformance";
            _Button5.Name = "Button5";
            _btnStreamPerformance.Name = "btnStreamPerformance";
            _btnCancel.Name = "btnCancel";
            _Button1.Name = "Button1";
            _Button6.Name = "Button6";
            _Button3.Name = "Button3";
            _btnReload.Name = "btnReload";
            _btnGrade.Name = "btnGrade";
            _radSubject.Name = "radSubject";
            _chkMode.Name = "chkMode";
            _Button4.Name = "Button4";
            _dgvEnterMarks.Name = "dgvEnterMarks";
        }

        private object[][] subjects_7 = new object[501][];
        private object counter;
        private int total_term_days;
        private double percentage_attendance;
        private int student;
        private int class_out_of;
        private int[] stream_no;
        private object adm_no;
        private string[] sciences;
        private string[] sci_names;
        private bool science = true;
        private string[] humanities;
        private string[] hum_names;
        private string[] app_names;
        private bool humanity = false;
        private string[] applieds;
        private bool applied = false;
        private string[] compulsory;
        private string[] comp_names;
        private bool points = false;
        private string[] admnos;
        private string logoPath;
        private int total_days(string from_, string to_)
        {
            string argq = "SELECT DISTINCT date FROM student_attendance WHERE date >= '" + from_ + "' AND date <='" + to_ + "';";
            publicSubsNFunctions.qread(ref argq);
            return publicSubsNFunctions.dbreader.RecordsAffected;
        }

        private object get_total_attendance(int id)
        {
            int att = 0;
            string argq = "SELECT * FROM term_dates WHERE Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "'";
            if (publicSubsNFunctions.qread(ref argq))
            {
                publicSubsNFunctions.dbreader.Read();
                if (!Information.IsDate(publicSubsNFunctions.dbreader["startDate"]) | !Information.IsDate(publicSubsNFunctions.dbreader["endDate"]))
                {
                    return default;
                }

                DateTime date_from = Conversions.ToDate(publicSubsNFunctions.dbreader["startDate"]);
                DateTime date_to = Conversions.ToDate(publicSubsNFunctions.dbreader["endDate"]);
                publicSubsNFunctions.query = "SELECT * FROM student_attendance WHERE Morning_present='Present' AND afte_present='Present' AND admin_no='" + id + "' AND Date >='" + date_from.Year + "-" + Strings.Format(date_from.Month, "00") + "-" + Strings.Format(date_from.Day, "00") + "' AND Date <='" + date_to.Year + "-" + Strings.Format(date_to.Month, "00") + "-" + Strings.Format(date_to.Day, "00") + "'  GROUP BY DATE";
                publicSubsNFunctions.dbreader.Close();
                if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
                {
                    att = publicSubsNFunctions.dbreader.RecordsAffected;
                }

                total_term_days = total_days(date_from.Year + "-" + Strings.Format(date_from.Month, "00") + "-" + Strings.Format(date_from.Day, "00"), date_to.Year + "-" + Strings.Format(date_to.Month, "00") + "-" + Strings.Format(date_to.Day, "00"));
            }

            if (total_term_days > 0)
            {
                percentage_attendance = Conversions.ToDouble(Strings.Format(att / (double)total_term_days * 100d, 0.0d.ToString()));
            }
            else
            {
                percentage_attendance = 0.0d;
            }

            return att;
        }

        private object prepare_class_list()
        {
            var print_document = new PrintDocument();
            var margin = new Margins(10, 10, 10, 10);
            print_document.DefaultPageSettings.Landscape = true;
            print_document.DefaultPageSettings.Margins = margin;
            print_document.PrintPage += print_class_list;
            return print_document;
        }

        private object prepare_stream_list()
        {
            var print_document = new PrintDocument();
            var margin = new Margins(10, 10, 10, 10);
            print_document.DefaultPageSettings.Landscape = true;
            print_document.DefaultPageSettings.Margins = margin;
            print_document.PrintPage += print_stream_list;
            return print_document;
        }

        private void print_class_list(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds);
            int line = 160;
            int topline = line;
            int left_margin, right_margin;
            left_margin = 50;
            right_margin = 1000;
            if ((publicSubsNFunctions.S_NAME ?? "") != (string.Empty ?? ""))
            {
                e.Graphics.DrawString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font, Brushes.Black, left_margin + 180, 50f);
            }

            if ((publicSubsNFunctions.S_ADDRESS ?? "") != (string.Empty ?? ""))
            {
                e.Graphics.DrawString("P.O. BOX " + publicSubsNFunctions.S_ADDRESS.ToUpper() + ", " + publicSubsNFunctions.S_LOCATION.ToUpper(), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 250, 80f);
            }

            if ((publicSubsNFunctions.S_FAX ?? "") != (string.Empty ?? ""))
            {
                e.Graphics.DrawString("FAX: " + publicSubsNFunctions.S_FAX, publicSubsNFunctions.other_font, Brushes.Black, left_margin + 270, 100f);
            }

            if ((publicSubsNFunctions.S_PHONE ?? "") != (string.Empty ?? ""))
            {
                e.Graphics.DrawString("TELEPHONE: " + publicSubsNFunctions.S_PHONE, publicSubsNFunctions.other_font, Brushes.Black, left_margin + 260, 120f);
            }

            try
            {
                e.Graphics.DrawString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper() + " " + publicSubsNFunctions.exam_name.ToUpper() + " EXAMINATION PERFORMANCE MARKLIST", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 200, line);
            }
            catch (Exception ex)
            {
                string exam = string.Empty;
                for (int k = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo; k++)
                {
                    exam = Conversions.ToString(exam + publicSubsNFunctions.exam_names[k]);
                    if (k < publicSubsNFunctions.exam_names.Length - 1)
                    {
                        exam += "/";
                    }
                }

                e.Graphics.DrawString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper() + " " + exam.ToUpper() + " EXAMINATION PERFORMANCE MARKLIST", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 100, line);
            }

            line += 30;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2);
            e.Graphics.DrawString("NAME OF STUDENT", publicSubsNFunctions.other_font, Brushes.Black, left_margin - 2, line + 5);
            int col = 280;
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                try
                {
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subjabb[k].Substring((object)0, (object)3)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 3, line + 5);
                }
                catch (Exception ex)
                {
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subjabb[k].Substring((object)0, (object)2)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 3, line + 5);
                }

                col += 45;
            }

            col += 7;
            e.Graphics.DrawString("Total", publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 5);
            col += 40;
            e.Graphics.DrawString("Pos.", publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 5);
            line += 20;
            // e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line)
            col = 280;
            for (int i = 0, loopTo1 = dgvEnterMarks.Rows.Count - 1; i <= loopTo1; i++)
            {
                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["StudentName", i].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 5, line + 3);
                for (int k = 0, loopTo2 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo2; k++)
                {
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 5, line + 3);
                    col += 45;
                }

                col += 7;
                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["Total", i].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 3);
                col += 40;
                e.Graphics.DrawString((i + 1).ToString(), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 3);
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2);
                line += 20;
                col = 280;
            }

            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 3, right_margin - 2, line + 3);
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline + 32, left_margin - 2, line + 3);
            col = 280;
            for (int k = 0, loopTo3 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo3; k++)
            {
                e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3);
                col += 45;
            }

            col += 7;
            e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3);
            col += 40;
            e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3);
            e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline + 32, right_margin - 2, line + 3);
        }

        private void print_stream_list(object sender, PrintPageEventArgs e)
        {
            int line = 150;
            int topline = line;
            int left_margin, right_margin;
            left_margin = 50;
            right_margin = 800;
            if ((publicSubsNFunctions.S_NAME ?? "") != (string.Empty ?? ""))
            {
                e.Graphics.DrawString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font, Brushes.Black, left_margin + 160, 50f);
            }

            if ((publicSubsNFunctions.S_ADDRESS ?? "") != (string.Empty ?? ""))
            {
                e.Graphics.DrawString("P.O. BOX " + publicSubsNFunctions.S_ADDRESS.ToUpper() + ", " + publicSubsNFunctions.S_LOCATION.ToUpper(), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 250, 80f);
            }

            if ((publicSubsNFunctions.S_FAX ?? "") != (string.Empty ?? ""))
            {
                e.Graphics.DrawString("FAX: " + publicSubsNFunctions.S_FAX, publicSubsNFunctions.other_font, Brushes.Black, left_margin + 270, 100f);
            }

            if ((publicSubsNFunctions.S_PHONE ?? "") != (string.Empty ?? ""))
            {
                e.Graphics.DrawString("TELEPHONE: " + publicSubsNFunctions.S_PHONE, publicSubsNFunctions.other_font, Brushes.Black, left_margin + 260, 120f);
            }

            try
            {
                e.Graphics.DrawString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper() + " " + publicSubsNFunctions.class_stream.ToUpper() + " " + publicSubsNFunctions.exam_name.ToUpper() + " EXAMINATION PERFORMANCE MARKLIST", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 200, line);
            }
            catch (Exception ex)
            {
                string exam = string.Empty;
                for (int k = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo; k++)
                {
                    exam = Conversions.ToString(exam + publicSubsNFunctions.exam_names[k]);
                    if (k < publicSubsNFunctions.exam_names.Length - 1)
                    {
                        exam += "/";
                    }
                }

                e.Graphics.DrawString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper() + " " + publicSubsNFunctions.class_stream.ToUpper() + " " + exam.ToUpper() + " EXAMINATION PERFORMANCE MARKLIST", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 100, line);
            }

            line += 30;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2);
            e.Graphics.DrawString("NAME OF STUDENT", publicSubsNFunctions.other_font, Brushes.Black, left_margin - 2, line + 5);
            int col = 280;
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                try
                {
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subjabb[k].Substring((object)0, (object)3)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 5);
                }
                catch (Exception ex)
                {
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subjabb[k].Substring((object)0, (object)2)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 5);
                }

                col += 34;
            }

            col += 16;
            e.Graphics.DrawString("Total", publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 5);
            col += 40;
            e.Graphics.DrawString("Pos.", publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 5);
            line += 20;
            int i, j;
            j = 0;
            var loopTo1 = dgvEnterMarks.Rows.Count - 1;
            for (i = 0; i <= loopTo1; i++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", i].Value, publicSubsNFunctions.class_stream, false)))
                {
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["StudentName", i].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 5, line + 3);
                    col = 285;
                    for (int k = 0, loopTo2 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo2; k++)
                    {
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 3);
                        col += 34;
                    }

                    col += 16;
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["Total", i].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 3);
                    col += 40;
                    e.Graphics.DrawString((j + 1).ToString(), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 3);
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2);
                    line += 20;
                    j += 1;
                }
            }

            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 3, right_margin - 2, line + 3);
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline + 32, left_margin - 2, line + 3);
            col = 280;
            for (int k = 0, loopTo3 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo3; k++)
            {
                e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3);
                col += 34;
            }

            col += 16;
            e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3);
            col += 40;
            e.Graphics.DrawLine(Pens.Black, left_margin + col, topline + 32, left_margin + col, line + 3);
            e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline + 32, right_margin - 2, line + 3);
        }

        private void get_split_subjects(string subj, bool name = false)
        {
            string argq = "SELECT * FROM split_subjects WHERE subject='" + publicSubsNFunctions.escape_string(subj) + "' AND class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "'";
            publicSubsNFunctions.qread(ref argq, 2);
            splits = new object[publicSubsNFunctions.dbreader2.RecordsAffected];
            splits_cont = new object[publicSubsNFunctions.dbreader2.RecordsAffected];
            splits_name = new object[publicSubsNFunctions.dbreader2.RecordsAffected];
            int i = 0;
            while (publicSubsNFunctions.dbreader2.Read())
            {
                if (name)
                {
                    splits_name[i] = publicSubsNFunctions.dbreader2["abbreviation"];
                    splits[i] = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.dbreader2["name"], " [ "), publicSubsNFunctions.dbreader2["abbreviation"]), " ] ");
                }
                else
                {
                    splits[i] = publicSubsNFunctions.dbreader2["abbreviation"];
                }

                splits_cont[i] = publicSubsNFunctions.dbreader2["contribution"];
                i += 1;
            }
        }

        private object[] splits, splits_cont, splits_name;
        private void create_dataform()
        {
            DataGridViewCell cellKCPE = new DataGridViewTextBoxCell();
            var colKCPE = new DataGridViewColumn();
            colKCPE.CellTemplate = cellKCPE;
            colKCPE.Name = "KCPE";
            colKCPE.HeaderText = "KCPE";
            colKCPE.Width = 100;
            colKCPE.Visible = _kcpe;
            colKCPE.ReadOnly = true;
            colKCPE.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvEnterMarks.Columns.Add(colKCPE);
            DataGridViewCell cellINDEX = new DataGridViewTextBoxCell();
            var colINDEX = new DataGridViewColumn();
            colINDEX.CellTemplate = cellINDEX;
            colINDEX.Name = "INDEX";
            colINDEX.HeaderText = "INDEX NO.";
            colINDEX.Width = 100;
            colINDEX.Visible = _index;
            colINDEX.ReadOnly = true;
            colINDEX.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvEnterMarks.Columns.Add(colINDEX);
            publicSubsNFunctions.get_subjects();
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                int split_count = 0;
                if (publicSubsNFunctions.show_split)
                {
                    get_split_subjects(Conversions.ToString(publicSubsNFunctions.subjects[k]));
                    for (int count = 0, loopTo1 = splits.Length - 1; count <= loopTo1; count++)
                    {
                        DataGridViewCell cellINDEX1 = new DataGridViewTextBoxCell();
                        var colINDEX1 = new DataGridViewColumn();
                        colINDEX1.CellTemplate = cellINDEX1;
                        colINDEX1.Name = Conversions.ToString(splits[count]);
                        colINDEX1.HeaderText = Conversions.ToString(splits[count]);
                        colINDEX1.Width = 50;
                        colINDEX1.ReadOnly = true;
                        colINDEX1.SortMode = DataGridViewColumnSortMode.Programmatic;
                        dgvEnterMarks.Columns.Add(colINDEX1);
                        split_count += 1;
                    }
                }

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
                    if (split_count == 0 | !publicSubsNFunctions.IsPrimary())
                    {
                        column.HeaderText = Conversions.ToString(publicSubsNFunctions.remove_wild(Conversions.ToString(publicSubsNFunctions.subjabb[k].Substring((object)0, (object)2))));
                    }
                    else
                    {
                        column.HeaderText = "Total";
                    }
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
            colent.Visible = _se;
            colent.ReadOnly = true;
            dgvEnterMarks.Columns.Add(colent);
            DataGridViewCell celltp = new DataGridViewTextBoxCell();
            var coltp = new DataGridViewColumn();
            coltp.CellTemplate = celltp;
            coltp.Name = "TP";
            coltp.HeaderText = "TP";
            coltp.Width = 50;
            coltp.Visible = _tp;
            coltp.ReadOnly = true;
            coltp.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEnterMarks.Columns.Add(coltp);
            DataGridViewCell cellmp = new DataGridViewTextBoxCell();
            var colmp = new DataGridViewColumn();
            colmp.CellTemplate = cellmp;
            colmp.Name = "MP";
            colmp.HeaderText = "MP";
            colmp.Width = 50;
            colmp.Visible = _mp;
            colmp.ReadOnly = true;
            colmp.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEnterMarks.Columns.Add(colmp);
            DataGridViewCell cellmm = new DataGridViewTextBoxCell();
            var colmm = new DataGridViewColumn();
            colmm.CellTemplate = cellmm;
            colmm.Name = "MM";
            colmm.HeaderText = "MM";
            colmm.Width = 50;
            colmm.Visible = _mm;
            colmm.ReadOnly = true;
            colmm.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEnterMarks.Columns.Add(colmm);
            DataGridViewCell cellmg = new DataGridViewTextBoxCell();
            var colmg = new DataGridViewColumn();
            colmg.CellTemplate = cellmg;
            colmg.Name = "MG";
            colmg.HeaderText = "MG";
            colmg.Width = 50;
            colmg.Visible = _mg;
            colmg.SortMode = DataGridViewColumnSortMode.NotSortable;
            colmg.ReadOnly = false;
            dgvEnterMarks.Columns.Add(colmg);
            DataGridViewCell cell1 = new DataGridViewTextBoxCell();
            var column0 = new DataGridViewColumn();
            column0.CellTemplate = cell1;
            column0.Name = "Total";
            column0.HeaderText = "TM";
            column0.Visible = _tm;
            column0.Width = 60;
            column0.ReadOnly = true;
            column0.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEnterMarks.Columns.Add(column0);
            var column1 = new DataGridViewColumn();
            column1.CellTemplate = cell1;
            column1.Name = "str_class";
            column1.Visible = _str;
            column1.HeaderText = "STR";
            column1.Width = 60;
            column1.ReadOnly = true;
            dgvEnterMarks.Columns.Add(column1);
            var column2 = new DataGridViewColumn();
            column2.CellTemplate = cell1;
            column2.Name = "Position";
            column2.HeaderText = "SP";
            column2.Width = 60;
            column2.ReadOnly = true;
            dgvEnterMarks.Columns.Add(column2);
            var column3 = new DataGridViewColumn();
            column3.CellTemplate = cell1;
            column3.Name = "Overall";
            column3.HeaderText = "OP";
            column3.Width = 60;
            column3.ReadOnly = true;
            dgvEnterMarks.Columns.Add(column3);
            var column4 = new DataGridViewColumn();
            column4.CellTemplate = cell1;
            column4.Name = "VAP";
            column4.HeaderText = "VAP";
            column4.Width = 60;
            column4.Visible = _vap;
            column4.ReadOnly = true;
            dgvEnterMarks.Columns.Add(column4);
        }

        private object kcpe_rank(object marks)
        {
            int k = 1;
            int tester;
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT admin_no, marks_attained_primary FROM students WHERE Class='", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "' ORDER BY marks_attained_primary DESC"));
            publicSubsNFunctions.qread(ref argq);
            while (publicSubsNFunctions.dbreader.Read())
            {
                if (string.IsNullOrEmpty(publicSubsNFunctions.dbreader["marks_attained_primary"].ToString()) | (publicSubsNFunctions.dbreader["marks_attained_primary"].ToString() ?? "") == (string.Empty ?? ""))
                {
                    tester = 0;
                }
                else
                {
                    tester = Conversions.ToInteger(publicSubsNFunctions.dbreader["marks_attained_primary"]);
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(marks, tester, false)))
                {
                    return k;
                }

                k += 1;
            }

            return "--";
        }

        private publicSubsNFunctions.ReportForm report = new publicSubsNFunctions.ReportForm();
        private void loadReportFormDefaults()
        {
            string argq = "SELECT * FROM report_configuration";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                {
                    ref var withBlock = ref report;
                    withBlock.club_and_societies = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["club_and_societies"]));
                    withBlock.class_teacher_comments = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["class_teacher_comments"]));
                    withBlock.class_teacher_signature = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["class_teacher_signature"]));
                    withBlock.house_master_comments = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["house_master_comments"]));
                    withBlock.head_teacher_comments = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["head_teacher_comments"]));
                    withBlock.head_teacher_signature = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["head_teacher_signature"]));
                    withBlock.school_logo = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["school_logo"]));
                    withBlock.student_photo = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["student_photo"]));
                    withBlock.head_teacher_name = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["head_teacher_name"]));
                    withBlock.class_teacher_name = Conversions.ToBoolean(publicSubsNFunctions.CheckStatus(publicSubsNFunctions.dbreader["class_teacher_name"]));
                }
            }
        }

        private bool _se, _tp, _mp, _mm, _mg, _tm, _str, _sp, _op, _vap, _kcpe, _index;
        private void get_merit_list_configuration()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM merit_list_config WHERE `class`='", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "'"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    publicSubsNFunctions.dbreader.Read();
                    _se = Conversions.ToBoolean(publicSubsNFunctions.dbreader["se"]);
                    _tp = Conversions.ToBoolean(publicSubsNFunctions.dbreader["tp"]);
                    _mp = Conversions.ToBoolean(publicSubsNFunctions.dbreader["mp"]);
                    _mg = Conversions.ToBoolean(publicSubsNFunctions.dbreader["mg"]);
                    _tm = Conversions.ToBoolean(publicSubsNFunctions.dbreader["tm"]);
                    _str = Conversions.ToBoolean(publicSubsNFunctions.dbreader["str"]);
                    _sp = Conversions.ToBoolean(publicSubsNFunctions.dbreader["sp"]);
                    _op = Conversions.ToBoolean(publicSubsNFunctions.dbreader["op"]);
                    _vap = Conversions.ToBoolean(publicSubsNFunctions.dbreader["vap"]);
                    _kcpe = Conversions.ToBoolean(publicSubsNFunctions.dbreader["kcpe"]);
                    _index = Conversions.ToBoolean(publicSubsNFunctions.dbreader["index_no"]);
                }
                else
                {
                    var frm = new frmMeritListConfig();
                    frm.ShowDialog();
                    get_merit_list_configuration();
                }
            }
            else
            {
                publicSubsNFunctions.failure("You are missing a critical configuration setting in your software!");
            }
        }

        private string parentsGuardiansFolder = string.Empty;
        private string studentImagePath = string.Empty;
        private void frmResults_Load(object sender, EventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            parentsGuardiansFolder = Path.Combine(folder, "photos_parent_guardians");
            chkMode.CheckState = CheckState.Unchecked;
            if (Conversions.ToBoolean(Operators.OrObject(!publicSubsNFunctions.connect(), !publicSubsNFunctions.dbNewOpen())))
            {
                Close();
            }
            else
            {
                if (!publicSubsNFunctions.IsPrimary())
                {
                    radSubject.Visible = true;
                    chkSplit.Visible = false;
                }
                else
                {
                    chkSplit.Checked = true;
                    radSubject.Checked = false;
                }

                var frm = new frmResultAnalysis();
                frm.ShowDialog();
                if (!publicSubsNFunctions.search_teachers)
                {
                }
                // Me.Close()
                else
                {
                    using (new DevExpress.Utils.WaitDialogForm("Processing Results, Please Wait .....", "Computing Results"))
                    {
                        get_merit_list_configuration();
                        loadReportFormDefaults();
                        create_dataform();
                        if (publicSubsNFunctions.mode)
                        {
                            load_multi();
                        }
                        else
                        {
                            load_entered();
                        }
                    }
                }
            }

            chkMode.Visible = radSubject.Checked;
            state = true;
            logo();
        }

        public string logo()
        {
            string argq = "SELECT image_path FROM school_details";
            publicSubsNFunctions.qread(ref argq);
            publicSubsNFunctions.dbreader.Read();
            logoPath = Conversions.ToString(publicSubsNFunctions.dbreader["image_path"]);
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            parentsGuardiansFolder = Path.Combine(folder, "photos_parent_guardians");
            logoPath = parentsGuardiansFolder + @"\schoolLogo.png";
            return logoPath;
        }

        private object contribute(int val, int cont)
        {
            if (cont == 0)
            {
                return val;
            }
            else
            {
                return val / (double)publicSubsNFunctions.marks * cont;
            }
        }

        private object student_name(string adm)
        {
            string sname = string.Empty;
            // "SELECT LastName, FirstName, MiddleName FROM " & get_name(class_form) & "_classlist WHERE ADMNo='" & adm & "'"
            string argq = "select student_name from students where admin_no ='" + adm + "'";
            if (publicSubsNFunctions.qread(ref argq))
            {
                publicSubsNFunctions.dbreader.Read();
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    // sname = dbreader("LastName") & " " & dbreader("MiddleName") & " " & dbreader("FirstName")
                    sname = Conversions.ToString(publicSubsNFunctions.dbreader["student_name"]);
                }
                else
                {
                    sname = string.Empty;
                }

                publicSubsNFunctions.dbreader.Close();
            }

            return sname;
        }

        private int student_no;
        private void re_read_table()
        {
            var j = default(int);
            string term = string.Empty;
            var year = default(int);
            string re_read_table = null;
            for (int k = 0, loopTo = publicSubsNFunctions.tables.Length - 1; k <= loopTo; k++)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ADMNo FROM " + publicSubsNFunctions.table + " WHERE Examination='" + publicSubsNFunctions.tables[k] + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "' AND Class='"), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)))), "'"));
                publicSubsNFunctions.qread(ref argq);
                if (k == 0)
                {
                    student_no = publicSubsNFunctions.dbreader.RecordsAffected;
                    term = Conversions.ToString(publicSubsNFunctions.tms[k]);
                    year = Conversions.ToInteger(publicSubsNFunctions.yrs[k]);
                    re_read_table = publicSubsNFunctions.tables[k];
                }

                if (k > 0 & publicSubsNFunctions.dbreader.RecordsAffected > student_no)
                {
                    student_no = publicSubsNFunctions.dbreader.RecordsAffected;
                    term = Conversions.ToString(publicSubsNFunctions.tms[k]);
                    year = Conversions.ToInteger(publicSubsNFunctions.yrs[k]);
                    re_read_table = publicSubsNFunctions.tables[k];
                }
            }

            string argq1 = "SELECT ADMNo FROM " + publicSubsNFunctions.table + " WHERE Examination='" + re_read_table + "'  AND Term='" + term + "' AND Year='" + year + "' AND Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "'";
            publicSubsNFunctions.qread(ref argq1);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                subjects_7[publicSubsNFunctions.dbreader.RecordsAffected - 1] = new object[8];
                for (int k = 0, loopTo1 = subjects_7.Length - 1; k <= loopTo1; k++)
                {
                    subjects_7[k] = new object[9];
                    for (int m = 0, loopTo2 = subjects_7[k].Length - 1; m <= loopTo2; m++)
                        subjects_7[k][8] = null;
                }

                admnos = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                while (publicSubsNFunctions.dbreader.Read())
                {
                    admnos[j] = Conversions.ToString(publicSubsNFunctions.dbreader["ADMNo"]);
                    subjects_7[j][8] = publicSubsNFunctions.dbreader["ADMNo"];
                    j += 1;
                }

                publicSubsNFunctions.dbreader.Close();
            }
        }

        private List<string> xStudents = new List<string>();
        private void load_multi()
        {
            if (Conversions.ToBoolean(Operators.AndObject(publicSubsNFunctions.form_4_mode, !formfourmode())))
            {
                return;
            }

            get_streams(publicSubsNFunctions.class_form);
            string c_stream;
            c_stream = string.Empty;
            string sname = string.Empty;
            var total = new object[publicSubsNFunctions.subjabb.Length];
            int i, l, totals;
            int j = 0;
            if (publicSubsNFunctions.yr > DateAndTime.Today.Year)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT admin_no FROM students WHERE Class='", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "' ORDER BY ADMNo"));
                if (publicSubsNFunctions.qread(ref argq))
                {
                    if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                    {
                        publicSubsNFunctions.failure(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("There Were No Matching Records Found From The ", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), " Classlist! Continuing With Recovery Mode...")));
                        re_read_table();
                    }
                }
            }
            else
            {
                re_read_table();
            }

            string temp, temp_name;
            Pbar.Visible = true;
            int inc = (int)Math.Round(admnos.Length / 100d);
            if (publicSubsNFunctions.form_4_mode)
            {
                int[] comp, sci, hum, app;
                comp = new int[compulsory.Length];
                comp_names = new string[compulsory.Length];
                sci = new int[sciences.Length];
                sci_names = new string[sciences.Length];
                hum_names = new string[humanities.Length];
                hum = new int[humanities.Length];
                app_names = new string[applieds.Length];
                app = new int[applieds.Length];
                var loopTo = admnos.Length - 1;
                for (j = 0; j <= loopTo; j++)
                {
                    // new code start
                    publicSubsNFunctions.found = false;
                    // new code end
                    science = true;
                    for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                        total[k] = 0;
                    for (int k = 0, loopTo2 = comp.Length - 1; k <= loopTo2; k++)
                        comp[k] = 0;
                    for (int k = 0, loopTo3 = sci.Length - 1; k <= loopTo3; k++)
                        sci[k] = 0;
                    for (int k = 0, loopTo4 = hum.Length - 1; k <= loopTo4; k++)
                        hum[k] = 0;
                    for (int k = 0, loopTo5 = app.Length - 1; k <= loopTo5; k++)
                        app[k] = 0;
                    totals = 0;
                    double out_of;
                    int tp = 0;
                    var loopTo6 = publicSubsNFunctions.tables.Length - 1;
                    for (i = 0; i <= loopTo6; i++)
                    {

                        // I've overridden the default year for tm and yr which represent the current year and term
                        publicSubsNFunctions.tm = Conversions.ToString(publicSubsNFunctions.tms[i]);
                        publicSubsNFunctions.yr = Conversions.ToInteger(publicSubsNFunctions.yrs[i]);
                        string argq1 = "SELECT * FROM " + publicSubsNFunctions.table + " WHERE ADMNo='" + admnos[j] + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.tables[i]) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' LIMIT 1";
                        if (publicSubsNFunctions.qread(ref argq1))
                        {
                            try
                            {
                                publicSubsNFunctions.dbreader.Read();
                                sname = Conversions.ToString(publicSubsNFunctions.dbreader["StudentName"]);
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }

                            c_stream = Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]);
                            for (int k = 0, loopTo7 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo7; k++)
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k])))
                                {
                                    out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_names[i], publicSubsNFunctions.dbreader["Class"], publicSubsNFunctions.dbreader["Stream"], 2);
                                    if (publicSubsNFunctions.contribution[i] == 0)
                                    {
                                        total[k] += Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), out_of), publicSubsNFunctions.total_mark[i]);
                                    }
                                    else
                                    {
                                        total[k] += Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), out_of), publicSubsNFunctions.total_mark[i]), publicSubsNFunctions.contribution[i]), publicSubsNFunctions.total_mark[i]);
                                    }
                                }
                                // new code start for students thta have x and y
                                else if (publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]).ToString().ToUpper() == "X")
                                {
                                    total[k] = "X";
                                    publicSubsNFunctions.found = true;
                                    xStudents.Add(admnos[j]);
                                }
                                else if (publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]).ToString().ToUpper() == "Y")
                                {
                                    total[k] = "Y";
                                    publicSubsNFunctions.found = true;
                                    xStudents.Add(admnos[j]);
                                    // new code end
                                }
                            }

                            // ##############get total of first compulsory subjects#################
                            for (int k = 0, loopTo8 = compulsory.Length - 1; k <= loopTo8; k++)
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader[compulsory[k]]))
                                {
                                    out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_names[i], publicSubsNFunctions.dbreader["Class"], publicSubsNFunctions.dbreader["Stream"], 2);
                                    if (publicSubsNFunctions.contribution[i] == 0)
                                    {
                                        comp[k] = Conversions.ToInteger(comp[k] + Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[compulsory[k]], out_of), publicSubsNFunctions.total_mark[i]));
                                    }
                                    else
                                    {
                                        comp[k] = Conversions.ToInteger(comp[k] + Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[compulsory[k]], out_of), publicSubsNFunctions.total_mark[i]), publicSubsNFunctions.contribution[i]), publicSubsNFunctions.total_mark[i]));
                                    }

                                    comp_names[k] = Conversions.ToString(publicSubsNFunctions.subjabb[k]);
                                }
                            }

                            for (int k = 0, loopTo9 = sciences.Length - 1; k <= loopTo9; k++)
                            {
                                if (!Information.IsNumeric(publicSubsNFunctions.dbreader[sciences[k]]))
                                {
                                    science = false;
                                }
                            }

                            for (int k = 0, loopTo10 = sciences.Length - 1; k <= loopTo10; k++)
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader[sciences[k]]))
                                {
                                    out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_names[i], publicSubsNFunctions.dbreader["Class"], publicSubsNFunctions.dbreader["Stream"], 2);
                                    if (publicSubsNFunctions.contribution[i] == 0)
                                    {
                                        sci[k] = Conversions.ToInteger(sci[k] + Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[sciences[k]], out_of), publicSubsNFunctions.total_mark[i]));
                                    }
                                    else
                                    {
                                        sci[k] = Conversions.ToInteger(sci[k] + Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[sciences[k]], out_of), publicSubsNFunctions.total_mark[i]), publicSubsNFunctions.contribution[i]), publicSubsNFunctions.total_mark[i]));
                                    }

                                    sci_names[k] = sciences[k];
                                }
                            }

                            for (int k = 0, loopTo11 = humanities.Length - 1; k <= loopTo11; k++)
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader[humanities[k]]))
                                {
                                    out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_names[i], publicSubsNFunctions.dbreader["Class"], publicSubsNFunctions.dbreader["Stream"], 2);
                                    if (publicSubsNFunctions.contribution[i] == 0)
                                    {
                                        hum[k] = Conversions.ToInteger(hum[k] + Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[humanities[k]], out_of), publicSubsNFunctions.total_mark[i]));
                                    }
                                    else
                                    {
                                        hum[k] = Conversions.ToInteger(hum[k] + Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[humanities[k]], out_of), publicSubsNFunctions.total_mark[i]), publicSubsNFunctions.contribution[i]), publicSubsNFunctions.total_mark[i]));
                                    }

                                    hum_names[k] = humanities[k];
                                }
                            }

                            for (int k = 0, loopTo12 = applieds.Length - 1; k <= loopTo12; k++)
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader[applieds[k]]))
                                {
                                    out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_names[i], publicSubsNFunctions.dbreader["Class"], publicSubsNFunctions.dbreader["Stream"], 2);
                                    if (publicSubsNFunctions.contribution[i] == 0)
                                    {
                                        app[k] = Conversions.ToInteger(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[applieds[k]], out_of), publicSubsNFunctions.total_mark[i]));
                                    }
                                    else
                                    {
                                        app[k] = Conversions.ToInteger(app[k] + Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[applieds[k]], out_of), publicSubsNFunctions.total_mark[i]), publicSubsNFunctions.contribution[i]), publicSubsNFunctions.total_mark[i]));
                                    }

                                    app_names[k] = applieds[k];
                                }
                            }
                        }
                    }


                    // #######################GET TOTALS##############################
                    totals = 0;
                    counter = 0;
                    for (int k = 0, loopTo13 = comp.Length - 1; k <= loopTo13; k++)
                    {
                        totals += comp[k];
                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)comp[k], radSubject.Checked, comp_names[k]))));
                        subjects_7[j][Conversions.ToInteger(counter)] = comp_names[k];
                        counter += 1;
                    }


                    // #######################################
                    for (int k = 0, loopTo14 = sciences.Length - 1; k <= loopTo14; k++)
                        sci_names[k] = sciences[k];
                    if (science)
                    {
                        // ###########Sort them#############
                        for (int k = 0, loopTo15 = sciences.Length - 1; k <= loopTo15; k++)
                        {
                            var loopTo16 = sciences.Length - 1;
                            for (l = k + 1; l <= loopTo16; l++)
                            {
                                if (sci[k] < sci[l] | !Information.IsNumeric(sci[k]))
                                {
                                    temp = sci[k].ToString();
                                    temp_name = sci_names[k];
                                    sci[k] = sci[l];
                                    sci_names[k] = sci_names[l];
                                    sci[l] = Conversions.ToInteger(temp);
                                    sci_names[l] = temp_name;
                                }
                            }
                        }

                        for (int k = 0, loopTo17 = sciences.Length - 1; k <= loopTo17; k++)
                        {
                            if (k < sciences.Length - 1)
                            {
                                totals += sci[k];
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)sci[k], radSubject.Checked, sci_names[k]))));
                                subjects_7[j][Conversions.ToInteger(counter)] = sci_names[k];
                                counter += 1;
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0, loopTo18 = sciences.Length - 1; k <= loopTo18; k++)
                        {
                            totals += sci[k];
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)sci[k], radSubject.Checked, sci_names[k]))));
                            subjects_7[j][Conversions.ToInteger(counter)] = sci_names[k];
                            counter += 1;
                        }
                    }


                    // #######################################
                    int count = humanities.Length;
                    for (int k = 0, loopTo19 = humanities.Length - 1; k <= loopTo19; k++)
                    {
                        hum_names[k] = humanities[k];
                        if (!Information.IsNumeric(hum[k]))
                        {
                            count -= 1;
                        }
                    }

                    if (count > 1)
                    {
                        humanity = true;
                        l = 0;
                        for (int k = 0, loopTo20 = hum.Length - 1; k <= loopTo20; k++)
                        {
                            var loopTo21 = hum.Length - 1;
                            for (l = k + 1; l <= loopTo21; l++)
                            {
                                if (hum[k] < hum[l] | !Information.IsNumeric(hum[k]))
                                {
                                    temp = hum[k].ToString();
                                    temp_name = hum_names[k];
                                    hum[k] = hum[l];
                                    hum_names[k] = hum_names[l];
                                    hum[l] = Conversions.ToInteger(temp);
                                    hum_names[l] = temp_name;
                                }
                            }
                        }

                        totals += hum[0];
                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[0], radSubject.Checked, hum_names[0]))));
                        subjects_7[j][Conversions.ToInteger(counter)] = hum_names[0];
                        counter += 1;
                    }
                    else
                    {
                        for (int k = 0, loopTo22 = humanities.Length - 1; k <= loopTo22; k++)
                        {
                            if (Information.IsNumeric(hum[k]))
                            {
                                totals += hum[k];
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[k], radSubject.Checked, hum_names[k]))));
                                subjects_7[j][Conversions.ToInteger(counter)] = hum_names[k];
                                counter += 1;
                            }
                        }
                    }


                    // ######################################
                    count = applieds.Length;
                    for (int k = 0, loopTo23 = applieds.Length - 1; k <= loopTo23; k++)
                    {
                        if (!Information.IsNumeric(app[k]))
                        {
                            count -= 1;
                        }
                    }

                    if (count > 0)
                    {
                        applied = true;
                        for (int k = 0, loopTo24 = app.Length - 1; k <= loopTo24; k++)
                        {
                            var loopTo25 = app.Length - 1;
                            for (l = k + 1; l <= loopTo25; l++)
                            {
                                if (app[k] < app[l] | !Information.IsNumeric(app[k]))
                                {
                                    temp = app[k].ToString();
                                    temp_name = app_names[k];
                                    app[k] = app[l];
                                    app_names[k] = app_names[l];
                                    app[l] = Conversions.ToInteger(temp);
                                    app_names[l] = temp_name;
                                }
                            }
                        }
                    }


                    // ######################################

                    if (science & humanity & applied)
                    {
                        if (sci[2] > hum[1])
                        {
                            if (sci[2] > app[0])
                            {
                                totals += sci[2];
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)sci[2], radSubject.Checked, sci_names[2]))));
                                subjects_7[j][Conversions.ToInteger(counter)] = sci_names[2];
                                counter += 1;
                            }
                            else
                            {
                                totals += app[0];
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0], radSubject.Checked, app_names[0]))));
                                subjects_7[j][Conversions.ToInteger(counter)] = app_names[0];
                                counter += 1;
                            }
                        }
                        else if (hum[1] > app[0])
                        {
                            totals += hum[1];
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1], radSubject.Checked, hum_names[1]))));
                            subjects_7[j][Conversions.ToInteger(counter)] = hum_names[1];
                            counter += 1;
                        }
                        else
                        {
                            totals += app[0];
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0], radSubject.Checked, app_names[0]))));
                            subjects_7[j][Conversions.ToInteger(counter)] = app_names[0];
                            counter += 1;
                        }
                    }
                    else if (science & humanity)
                    {
                        if (sci[2] > hum[1])
                        {
                            totals += sci[2];
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)sci[2], radSubject.Checked, sci_names[2]))));
                            subjects_7[j][Conversions.ToInteger(counter)] = sci_names[2];
                            counter += 1;
                        }
                        else
                        {
                            totals += hum[1];
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1], radSubject.Checked, hum_names[1]))));
                            subjects_7[j][Conversions.ToInteger(counter)] = hum_names[1];
                            counter += 1;
                        }
                    }
                    else if (science & applied)
                    {
                        if (sci[2] > app[0])
                        {
                            totals += sci[2];
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)sci[2], radSubject.Checked, sci_names[2]))));
                            subjects_7[j][Conversions.ToInteger(counter)] = sci_names[2];
                            counter += 1;
                        }
                        else
                        {
                            totals += app[0];
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0], radSubject.Checked, app_names[0]))));
                            subjects_7[j][Conversions.ToInteger(counter)] = app_names[0];
                            counter += 1;
                        }
                    }
                    else if (applied & humanity)
                    {
                        if (app[0] > hum[1])
                        {
                            totals += app[0];
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0], radSubject.Checked, app_names[0]))));
                            subjects_7[j][Conversions.ToInteger(counter)] = app_names[0];
                            counter += 1;
                        }
                        else
                        {
                            totals += hum[1];
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1], radSubject.Checked, hum_names[1]))));
                            subjects_7[j][Conversions.ToInteger(counter)] = hum_names[1];
                            counter += 1;
                        }
                    }


                    // #########################################
                    dgvEnterMarks.Rows.Add();
                    dgvEnterMarks["ADMNo", j].Value = publicSubsNFunctions.get_id(admnos[j]);
                    dgvEnterMarks["StudentName", j].Value = sname;

                    // new code start
                    for (int k = 0, loopTo26 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo26; k++)
                    {
                        try
                        {
                            dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], j).Value = Math.Round(total[k], (object)0);
                        }
                        catch (Exception ex)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(total[k], "X", false)))
                            {
                                dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], j).Value = "X";
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(total[k], "Y", false)))
                            {
                                dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], j).Value = "Y";
                            }
                        }
                    }

                    if (total.Contains("X") | total.Contains("Y") | publicSubsNFunctions.found == true)
                    {
                        dgvEnterMarks["TP", j].Value = 0;
                        dgvEnterMarks["Total", j].Value = 0;
                    }
                    else
                    {
                        dgvEnterMarks["TP", j].Value = tp;
                        dgvEnterMarks["Total", j].Value = Math.Round((decimal)totals, 0);
                    }


                    // new code end

                    dgvEnterMarks["str_class", j].Value = c_stream;
                    Pbar.Increment(inc);
                }
            }
            else
            {
                int tp;
                double out_of;
                var loopTo27 = admnos.Length - 1;
                for (j = 0; j <= loopTo27; j++)
                {
                    tp = 0;
                    for (int k = 0, loopTo28 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo28; k++)
                        total[k] = 0;
                    totals = 0;
                    var loopTo29 = publicSubsNFunctions.tables.Length - 1;
                    for (i = 0; i <= loopTo29; i++)
                    {

                        // I've overridden the default year for tm and yr which represent the current year and term
                        publicSubsNFunctions.tm = Conversions.ToString(publicSubsNFunctions.tms[i]);
                        publicSubsNFunctions.yr = Conversions.ToInteger(publicSubsNFunctions.yrs[i]);
                        string argq2 = "SELECT * FROM " + publicSubsNFunctions.table + " WHERE ADMNo='" + admnos[j] + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.tables[i]) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' LIMIT 1";
                        if (publicSubsNFunctions.qread(ref argq2))
                        {
                            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                            {
                                publicSubsNFunctions.dbreader.Read();
                                sname = Conversions.ToString(publicSubsNFunctions.dbreader["StudentName"]);
                                for (int k = 0, loopTo30 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo30; k++)
                                {
                                    if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k])))
                                    {
                                        out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_names[i], publicSubsNFunctions.dbreader["Class"], publicSubsNFunctions.dbreader["Stream"], 2);
                                        if (publicSubsNFunctions.contribution[i] == 0)
                                        {
                                            total[k] += 0;
                                        }
                                        else
                                        {
                                            // todo edit 8/8/2016
                                            try
                                            {
                                                if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k])))
                                                {
                                                    total[k] += Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), out_of), publicSubsNFunctions.total_mark[i]), publicSubsNFunctions.contribution[i] / (double)publicSubsNFunctions.total_mark[i]);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                            // edit end
                                        }

                                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), out_of), publicSubsNFunctions.total_mark[i])), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[k])))));
                                    }
                                    // new code start
                                    else if (publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]).ToString().ToUpper() == "X")
                                    {
                                        total[k] = "X";
                                        xStudents.Add(admnos[j]);
                                    }
                                    else if (publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]).ToString().ToUpper() == "Y")
                                    {
                                        total[k] = "Y";
                                        xStudents.Add(admnos[j]);
                                        // new code end
                                    }
                                }

                                c_stream = Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]);
                            }
                            else
                            {
                                publicSubsNFunctions.dbreader.Close();
                                sname = Conversions.ToString(student_name(admnos[j]));
                                for (int k = 0, loopTo31 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo31; k++)
                                    // tp += fix_point(get_grade(dbReader(subjname(k)), radSubject.Checked, subjabb(k)))
                                    total[k] = 0;
                            }
                        }
                    }

                    dgvEnterMarks.Rows.Add();
                    dgvEnterMarks["ADMNo", j].Value = publicSubsNFunctions.get_id(admnos[j]);
                    dgvEnterMarks["StudentName", j].Value = sname;
                    for (int k = 0, loopTo32 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo32; k++)
                    {

                        // new code start
                        try
                        {
                            dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], j).Value = Conversions.ToInteger(total[k]);
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                if (double.IsInfinity(Conversions.ToDouble(total[k])))
                                {
                                    total[k] = "X";
                                    dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], j).Value = "X";
                                }
                            }
                            catch (Exception e)
                            {
                            }

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(total[k], "X", false)))
                            {
                                dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], j).Value = "X";
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(total[k], "Y", false)))
                            {
                                dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], j).Value = "Y";
                            }
                        }
                        // new code end
                    }

                    dgvEnterMarks["Total", j].Value = 0;
                    if (total.Contains("X") | total.Contains("Y"))
                    {
                        dgvEnterMarks["Total", j].Value = 0;
                    }
                    else
                    {
                        for (int k = 0, loopTo33 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo33; k++)
                        {
                            // new code start
                            try
                            {
                                dgvEnterMarks["Total", j].Value += Math.Round(total[k], (object)0);
                            }
                            catch (Exception ex)
                            {
                            }
                            // new code end
                        }
                    }

                    dgvEnterMarks["str_class", j].Value = c_stream;
                    Pbar.Increment(inc);
                }
            }

            Pbar.Visible = false;
            Pbar.Increment(-100);
            clean();
            if (!publicSubsNFunctions.form_4_mode)
            {
                compute_multi();
            }
            else
            {
                multi_points();
            }

            kcpe();
            for (int k = 0, loopTo34 = dgvEnterMarks.Rows.Count - 5; k <= loopTo34; k++)
                dgvEnterMarks["VAP", k].Value = Strings.Format(vap(Conversions.ToString(dgvEnterMarks["ADMNo", k].Value), Conversions.ToDouble(dgvEnterMarks["MP", k].Value)), "0.00");
            int cnt = 0;
            dgvEnterMarks["MP", dgvEnterMarks.Rows.Count - 2].Value = 0;
            for (int k = 0, loopTo35 = dgvEnterMarks.Rows.Count - 5; k <= loopTo35; k++)
            {
                if (Information.IsNumeric(dgvEnterMarks["MP", k].Value))
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(dgvEnterMarks["MP", k].Value, 0, false)))
                    {
                        dgvEnterMarks["MP", dgvEnterMarks.Rows.Count - 2].Value += dgvEnterMarks["MP", k].Value;
                        cnt += 1;
                    }
                }
            }

            dgvEnterMarks["MP", dgvEnterMarks.Rows.Count - 2].Value = Strings.Format(Operators.DivideObject(dgvEnterMarks["MP", dgvEnterMarks.Rows.Count - 2].Value, cnt), "0.00");
            dgvEnterMarks["MG", dgvEnterMarks.Rows.Count - 2].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvEnterMarks["MP", dgvEnterMarks.Rows.Count - 2].Value));
            cnt = 0;
            dgvEnterMarks["MM", dgvEnterMarks.Rows.Count - 2].Value = 0;
            for (int k = 0, loopTo36 = dgvEnterMarks.Rows.Count - 4; k <= loopTo36; k++)
            {
                if (Information.IsNumeric(dgvEnterMarks["MM", k].Value))
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(dgvEnterMarks["MM", k].Value, 0, false)))
                    {
                        dgvEnterMarks["MM", dgvEnterMarks.Rows.Count - 2].Value += dgvEnterMarks["MM", k].Value;
                        cnt += 1;
                    }
                }
            }

            dgvEnterMarks["MM", dgvEnterMarks.Rows.Count - 2].Value = Strings.Format(Operators.DivideObject(dgvEnterMarks["MM", dgvEnterMarks.Rows.Count - 2].Value, cnt), "0.00");
            cnt = 0;
            dgvEnterMarks["Total", dgvEnterMarks.Rows.Count - 2].Value = 0;
            for (int k = 0, loopTo37 = dgvEnterMarks.Rows.Count - 4; k <= loopTo37; k++)
            {
                if (Information.IsNumeric(dgvEnterMarks["Total", k].Value))
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(dgvEnterMarks["Total", k].Value, 0, false)))
                    {
                        dgvEnterMarks["Total", dgvEnterMarks.Rows.Count - 2].Value += dgvEnterMarks["Total", k].Value;
                        cnt += 1;
                    }
                }
            }

            dgvEnterMarks["Total", dgvEnterMarks.Rows.Count - 2].Value = Strings.Format(Operators.DivideObject(dgvEnterMarks["Total", dgvEnterMarks.Rows.Count - 2].Value, cnt), "0.00");
            positions();
        }

        private void clean()
        {
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
            {
                for (int m = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; m <= loopTo1; m++)
                {
                    try
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks.Item(publicSubsNFunctions.subjname[m], k).Value, 0, false)))
                        {
                            dgvEnterMarks.Item(publicSubsNFunctions.subjname[m], k).Value = "-";

                            // *** New code starts here ***


                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        private void positions()
        {
            stream_no = new int[publicSubsNFunctions.streams.Length];
            for (int j = 0, loopTo = publicSubsNFunctions.streams.Length - 1; j <= loopTo; j++)
                stream_no[j] = 0;
            int pos = 0;
            int EndOfRows;
            if (publicSubsNFunctions.mode)
            {
                EndOfRows = dgvEnterMarks.Rows.Count - 5;
            }
            else
            {
                EndOfRows = dgvEnterMarks.Rows.Count - 1;
            }

            for (int i = 0, loopTo1 = EndOfRows; i <= loopTo1; i++)
            {
                if (i > 0)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks[publicSubsNFunctions.sortby, i].Value, dgvEnterMarks[publicSubsNFunctions.sortby, i - 1].Value, false)))
                    {
                        pos = i + 1;
                        dgvEnterMarks["Overall", i].Value = pos;
                    }
                    else
                    {
                        dgvEnterMarks["Overall", i].Value = pos;
                    }
                }
                else
                {
                    pos += 1;
                    dgvEnterMarks["Overall", i].Value = pos;
                }

                var stream_pos = new int[publicSubsNFunctions.streams.Length];
                for (int j = 0, loopTo2 = publicSubsNFunctions.streams.Length - 1; j <= loopTo2; j++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", i].Value, publicSubsNFunctions.streams[j], false)))
                    {
                        if (stream_no[j] > 0)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(previous_person_sortby_value(publicSubsNFunctions.streams[j], i), dgvEnterMarks[publicSubsNFunctions.sortby, i].Value, false)))
                            {
                                dgvEnterMarks["Position", i].Value = stream_no[j];
                                stream_pos[j] += 1;
                            }
                            else
                            {
                                dgvEnterMarks["Position", i].Value = no_of_persons_for_stream(publicSubsNFunctions.streams[j], i);
                                stream_no[j] = Conversions.ToInteger(dgvEnterMarks["Position", i].Value);
                            }
                        }
                        else
                        {
                            stream_no[j] += 1;
                            stream_pos[j] = stream_no[j];
                            dgvEnterMarks["Position", i].Value = stream_no[j];
                        }
                    }
                }
            }

            for (int k = 0, loopTo3 = publicSubsNFunctions.streams.Length - 1; k <= loopTo3; k++)
                stream_no[k] = 1;
            for (int k = 0, loopTo4 = EndOfRows; k <= loopTo4; k++)
            {
                for (int s = 0, loopTo5 = publicSubsNFunctions.streams.Length - 1; s <= loopTo5; s++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", k].Value, publicSubsNFunctions.streams[s], false)))
                    {
                        stream_no[s] += 1;
                    }
                }
            }

            class_out_of = dgvEnterMarks.Rows.Count;
        }

        private object no_of_persons_for_stream(string s, int row)
        {
            object no_of_persons_for_streamRet = default;
            no_of_persons_for_streamRet = 0;
            for (int k = row; k >= 0; k -= 1)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", k].Value, s, false)))
                {
                    no_of_persons_for_streamRet += 1;
                }
            }

            return no_of_persons_for_streamRet;
        }

        private object previous_person_sortby_value(string s, int row)
        {
            object previous_person_sortby_valueRet = default;
            for (int k = row - 1; k >= 0; k -= 1)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", k].Value, s, false)))
                {
                    previous_person_sortby_valueRet = dgvEnterMarks[publicSubsNFunctions.sortby, k].Value;
                    return previous_person_sortby_valueRet;
                }
            }

            previous_person_sortby_valueRet = 0;
            return previous_person_sortby_valueRet;
        }

        private void totals()
        {
            int total, tp, cnt;
            int l;
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
            {
                total = 0;
                cnt = 0;
                tp = 0;
                for (int c = 0, loopTo1 = compulsory.Length - 1; c <= loopTo1; c++)
                {
                    if (Information.IsNumeric(dgvEnterMarks[compulsory[c], k].Value))
                    {
                        total = Conversions.ToInteger(total + dgvEnterMarks[compulsory[c], k].Value);
                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[compulsory[c], k].Value), radSubject.Checked, compulsory[c]))));
                        cnt += 1;
                    }
                }

                // ###########add the 2 best performed science and the second best###################
                for (int c = 0, loopTo2 = sciences.Length - 1; c <= loopTo2; c++)
                {
                    if (!Information.IsNumeric(dgvEnterMarks[sciences[c], k].Value))
                    {
                        science = false;
                    }
                }

                object[] sci = new object[sciences.Length];
                object temp, temp_name;
                int[] hum = new int[humanities.Length], app = new int[applieds.Length];
                app_names = new string[applieds.Length];
                hum_names = new string[humanities.Length];
                sci_names = new string[sciences.Length];
                for (int c = 0, loopTo3 = sciences.Length - 1; c <= loopTo3; c++)
                {
                    sci[c] = dgvEnterMarks[sciences[c], k].Value;
                    sci_names[c] = sciences[c];
                }

                if (science)
                {
                    // ###########SorT them#############
                    for (int c = 0, loopTo4 = sciences.Length - 1; c <= loopTo4; c++)
                    {
                        var loopTo5 = sciences.Length - 1;
                        for (l = k + 1; l <= loopTo5; l++)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectLess(sci[c], sci[l], false)))
                            {
                                temp = sci[c];
                                temp_name = sci_names[c];
                                sci[k] = sci[l];
                                sci_names[k] = sci_names[l];
                                sci[l] = temp;
                                sci_names[l] = Conversions.ToString(temp_name);
                            }
                        }
                    }

                    for (int c = 0, loopTo6 = sciences.Length - 1; c <= loopTo6; c++)
                    {
                        if (c < sciences.Length - 1)
                        {
                            total = Conversions.ToInteger(total + sci[c]);
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(sci[c]), radSubject.Checked, sci_names[c]))));
                            cnt += 1;
                        }
                    }
                }
                else
                {
                    for (int c = 0, loopTo7 = sciences.Length - 1; c <= loopTo7; c++)
                    {
                        if (Information.IsNumeric(dgvEnterMarks[sciences[c], k].Value))
                        {
                            total = Conversions.ToInteger(total + dgvEnterMarks[sciences[c], k].Value);
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[sci_names[c], k].Value), radSubject.Checked, sci_names[c]))));
                            cnt += 1;
                        }
                    }
                }

                // ###########get highest and second best performed humanity ##################
                int count = humanities.Length;
                for (int c = 0, loopTo8 = humanities.Length - 1; c <= loopTo8; c++)
                    hum_names[c] = humanities[c];
                for (int c = 0, loopTo9 = humanities.Length - 1; c <= loopTo9; c++)
                {
                    if (!Information.IsNumeric(dgvEnterMarks[humanities[c], k].Value))
                    {
                        count -= 1;
                    }
                }

                if (count > 1)
                {
                    humanity = true;
                    l = 0;
                    for (int c = 0, loopTo10 = humanities.Length - 1; c <= loopTo10; c++)
                    {
                        if (Information.IsNumeric(dgvEnterMarks[humanities[c], k].Value))
                        {
                            hum[c] = Conversions.ToInteger(dgvEnterMarks[humanities[c], k].Value);
                        }
                    }

                    for (int c = 0, loopTo11 = hum.Length - 1; c <= loopTo11; c++)
                    {
                        var loopTo12 = hum.Length - 1;
                        for (l = k + 1; l <= loopTo12; l++)
                        {
                            if (hum[c] < hum[l] | !Information.IsNumeric(hum[c]) & Information.IsNumeric(hum[l]))
                            {
                                temp = hum[c];
                                temp_name = hum_names[c];
                                hum[c] = hum[l];
                                hum_names[c] = hum_names[l];
                                hum_names[l] = Conversions.ToString(temp_name);
                                hum[l] = Conversions.ToInteger(temp);
                            }
                        }
                    }

                    total += hum[0];
                    tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[0], radSubject.Checked, hum_names[0]))));
                    cnt += 1;
                }
                else
                {
                    for (int c = 0, loopTo13 = humanities.Length - 1; c <= loopTo13; c++)
                    {
                        try
                        {
                            if (Information.IsNumeric(publicSubsNFunctions.dbreader[humanities[c]]))
                            {
                                total = Conversions.ToInteger(total + publicSubsNFunctions.dbreader[humanities[c]]);
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[humanities[c], k].Value), radSubject.Checked, hum_names[c]))));
                                cnt += 1;
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                // ########### get highest performed applied subject ##################
                for (int c = 0, loopTo14 = applieds.Length - 1; c <= loopTo14; c++)
                    app_names[c] = applieds[c];
                count = 0;
                l = 0;
                for (int c = 0, loopTo15 = applieds.Length - 1; c <= loopTo15; c++)
                {
                    if (Information.IsNumeric(dgvEnterMarks[applieds[c], k].Value))
                    {
                        count += 1;
                    }
                }

                if (count > 0)
                {
                    applied = true;
                    for (int c = 0, loopTo16 = applieds.Length - 1; c <= loopTo16; c++)
                    {
                        if (Information.IsNumeric(dgvEnterMarks[applieds[c], k].Value))
                        {
                            app[l] = Conversions.ToInteger(dgvEnterMarks[applieds[c], k].Value);
                            app_names[l] = applieds[c];
                            l += 1;
                        }
                    }

                    for (int c = 0, loopTo17 = app.Length - 1; c <= loopTo17; c++)
                    {
                        var loopTo18 = app.Length - 1;
                        for (l = k + 1; l <= loopTo18; l++)
                        {
                            if (app[c] < app[l])
                            {
                                temp = app[c];
                                temp_name = app_names[c];
                                app[c] = app[l];
                                app_names[k] = app_names[l];
                                app[l] = Conversions.ToInteger(temp);
                                app_names[l] = Conversions.ToString(temp_name);
                            }
                        }
                    }
                }

                if (science & humanity & applied)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], hum[1], false)))
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], app[0], false)))
                        {
                            total = Conversions.ToInteger(total + sci[2]);
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[sci_names[2], k].Value), radSubject.Checked, sci_names[2]))));
                            cnt += 1;
                        }
                        else
                        {
                            total += app[0];
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[app_names[0], k].Value), radSubject.Checked, app_names[0]))));
                            cnt += 1;
                        }
                    }
                    else if (hum[1] > app[0])
                    {
                        total += hum[1];
                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1], radSubject.Checked, hum_names[1]))));
                        cnt += 1;
                    }
                    else
                    {
                        total += app[0];
                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0], radSubject.Checked, app_names[0]))));
                        cnt += 1;
                    }
                }
                else if (science & humanity)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], hum[1], false)))
                    {
                        total = Conversions.ToInteger(total + sci[2]);
                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(sci[2]), radSubject.Checked, sci_names[2]))));
                        cnt += 1;
                    }
                    else
                    {
                        total += hum[1];
                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1], radSubject.Checked, hum_names[1]))));
                        cnt += 1;
                    }
                }
                else if (science & applied)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], app[0], false)))
                    {
                        total = Conversions.ToInteger(total + sci[2]);
                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(sci[2]), radSubject.Checked, sci_names[2]))));
                        cnt += 1;
                    }
                    else
                    {
                        total += app[0];
                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0], radSubject.Checked, app_names[0]))));
                        cnt += 1;
                    }
                }
                else if (applied & humanity)
                {
                    if (app[0] > hum[1])
                    {
                        total += app[0];
                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0], radSubject.Checked, app_names[0]))));
                        cnt += 1;
                    }
                    else
                    {
                        total += hum[1];
                        tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1], radSubject.Checked, hum_names[1]))));
                        cnt += 1;
                    }
                }
                else if (science)
                {
                    total = Conversions.ToInteger(total + sci[2]);
                    tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(sci[2]), radSubject.Checked, sci_names[2]))));
                    cnt += 1;
                }
                else if (humanity)
                {
                    total += hum[1];
                    tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1], radSubject.Checked, hum_names[1]))));
                    cnt += 1;
                }
                else if (applied)
                {
                    total += app[0];
                    tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0], radSubject.Checked, app_names[0]))));
                    cnt += 1;
                }

                dgvEnterMarks["Total", k].Value = total;
                if (cnt > 0)
                {
                    dgvEnterMarks["MM", k].Value = Strings.Format(total / (double)cnt, "0.00");
                }
                else
                {
                    dgvEnterMarks["MM", k].Value = "0.00";
                }

                dgvEnterMarks["TP", k].Value = tp;
                if (cnt > 0)
                {
                    dgvEnterMarks["MP", k].Value = Strings.Format(tp / (double)cnt, "0.00");
                }
                else
                {
                    dgvEnterMarks["MP", k].Value = "0.00";
                }

                dgvEnterMarks["MG", k].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvEnterMarks["MP", k].Value));
            }
        }

        private void multi_points()
        {
            index_no();
            kcpe();
            mean_mark();
            subject_entries();
            // totals()
            mean_point();
            meangrade();
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
                dgvEnterMarks[publicSubsNFunctions.sortby, k].Value = Convert.ToDouble(dgvEnterMarks["Total", k].Value);
            dgvEnterMarks.Sort(dgvEnterMarks.Columns[publicSubsNFunctions.sortby], System.ComponentModel.ListSortDirection.Descending);
            mean_score();
            total_means();
            mean_grade();
            mean_points();
            mean_grade_points();
            xStudents.Clear();
        }

        private void compute_multi()
        {
            index_no();
            kcpe();
            mean_mark();
            subject_entries();
            if (!publicSubsNFunctions.form_4_mode)
            {
                total_points();
            }

            mean_point();
            meangrade();
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
                dgvEnterMarks[publicSubsNFunctions.sortby, k].Value = Convert.ToDouble(dgvEnterMarks[publicSubsNFunctions.sortby, k].Value);
            dgvEnterMarks.Sort(dgvEnterMarks.Columns[publicSubsNFunctions.sortby], System.ComponentModel.ListSortDirection.Descending);
            positions();
            mean_score();
            mean_grade();
            mean_points();
            mean_grade_points();
            xStudents.Clear();
        }

        private void get_streams(string class_form)
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT stream FROM class_stream WHERE class='", publicSubsNFunctions.ret_name(class_form)), "'"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                publicSubsNFunctions.streams = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                int i = 0;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    publicSubsNFunctions.streams[i] = Conversions.ToString(publicSubsNFunctions.dbreader["stream"]);
                    i += 1;
                }
            }
        }

        private object[][] subj_out_of = new object[publicSubsNFunctions.subjabb.Length][];
        private void loadSubjectsOutOf()
        {
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                subj_out_of[k] = new object[publicSubsNFunctions.streams.Length];
                for (int i = 0, loopTo1 = subj_out_of[k].Length - 1; i <= loopTo1; i++)
                    subj_out_of[k][i] = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_name, publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form), publicSubsNFunctions.streams[i]);
            }
        }

        private object IndexOf(string str)
        {
            for (int k = 0, loopTo = publicSubsNFunctions.streams.Length - 1; k <= loopTo; k++)
            {
                if ((publicSubsNFunctions.streams[k] ?? "") == (str ?? ""))
                {
                    return k;
                }
            }

            return 0;
        }

        private double markOutOf(string subj, string str)
        {
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(subj, publicSubsNFunctions.subjname[k], false)))
                {
                    return Conversions.ToDouble(subj_out_of[k][Conversions.ToInteger(IndexOf(str))]);
                }
            }

            return default;
        }

        private double mark = Conversions.ToDouble(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
        private void load_entered()
        {
            mark = Conversions.ToDouble(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm, publicSubsNFunctions.yr.ToString()));
            get_streams(publicSubsNFunctions.class_form);
            loadSubjectsOutOf();
            if (Conversions.ToBoolean(Operators.AndObject(publicSubsNFunctions.form_4_mode, !formfourmode())))
            {
                return;
            }

            publicSubsNFunctions.query = "SELECT * FROM " + publicSubsNFunctions.table + " WHERE (Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "') ORDER BY Total DESC";
            if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
            {
                try
                {
                    subjects_7[publicSubsNFunctions.dbreader.RecordsAffected - 1] = new object[9];
                }
                catch (Exception ex)
                {
                    publicSubsNFunctions.failure("Looks Like You Are Trying To Analyze Results For An Examination For Which No Marks Have Been Entered!");
                    Close();
                }

                for (int l = 0, loopTo = publicSubsNFunctions.dbreader.RecordsAffected - 1; l <= loopTo; l++)
                {
                    subjects_7[l] = new object[9];
                    for (int w = 0, loopTo1 = subjects_7[l].Length - 1; w <= loopTo1; w++)
                        subjects_7[l][w] = 0;
                }

                Pbar.Visible = true;
                int inc = (int)Math.Round(publicSubsNFunctions.dbreader.RecordsAffected / 100d);
                int total;
                try
                {
                    stream_no = new int[publicSubsNFunctions.streams.Length];
                }
                catch (Exception ex)
                {
                }

                int i, tp, j;
                i = 0;
                try
                {
                    var loopTo2 = publicSubsNFunctions.streams.Length - 1;
                    for (j = 0; j <= loopTo2; j++)
                        stream_no[j] = 0;
                }
                catch (Exception ex)
                {
                }

                dgvEnterMarks.Rows.Clear();
                while (publicSubsNFunctions.dbreader.Read())
                {
                    counter = 0;
                    total = 0;
                    tp = 0;
                    dgvEnterMarks.Rows.Add();
                    dgvEnterMarks["ADMNo", i].Value = publicSubsNFunctions.get_id(publicSubsNFunctions.dbreader["ADMNo"]);
                    dgvEnterMarks["StudentName", i].Value = publicSubsNFunctions.dbreader["StudentName"];
                    dgvEnterMarks["str_class", i].Value = publicSubsNFunctions.dbreader["Stream"];
                    try
                    {
                        var loopTo3 = publicSubsNFunctions.streams.Length - 1;
                        for (j = 0; j <= loopTo3; j++)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.dbreader["Stream"], publicSubsNFunctions.streams[j], false)))
                            {
                                dgvEnterMarks["Position", i].Value = stream_no[j] + 1;
                                stream_no[j] += 1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    subjects_7[i][8] = publicSubsNFunctions.dbreader["ADMNo"];
                    dgvEnterMarks["Overall", i].Value = i + 1;
                    double out_of;
                    if (publicSubsNFunctions.form_4_mode)
                    {
                        science = true;
                        string temp_name;
                        int temp, l;
                        // ##############get total of first compulsory subjects#################
                        for (int k = 0, loopTo4 = compulsory.Length - 1; k <= loopTo4; k++)
                        {
                            if (Information.IsNumeric(publicSubsNFunctions.dbreader[compulsory[k]]))
                            {
                                out_of = markOutOf(compulsory[k], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[compulsory[k]], out_of), mark));
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[compulsory[k]], out_of), 100)), radSubject.Checked, compulsory[k]))));
                                subjects_7[i][Conversions.ToInteger(counter)] = compulsory[k];
                                counter += 1;
                            }
                        }

                        // ###########add the 2 best performed science and the second best###################
                        for (int k = 0, loopTo5 = sciences.Length - 1; k <= loopTo5; k++)
                        {
                            if (!Information.IsNumeric(publicSubsNFunctions.dbreader[sciences[k]]))
                            {
                                science = false;
                            }
                        }

                        var sci = new object[sciences.Length];
                        int[] hum = new int[humanities.Length], app = new int[applieds.Length];
                        app_names = new string[applieds.Length];
                        hum_names = new string[humanities.Length];
                        sci_names = new string[sciences.Length];
                        for (int k = 0, loopTo6 = sciences.Length - 1; k <= loopTo6; k++)
                        {
                            sci[k] = publicSubsNFunctions.dbreader[sciences[k]];
                            sci_names[k] = sciences[k];
                        }

                        if (science)
                        {
                            // ###########SorT them#############
                            for (int k = 0, loopTo7 = sciences.Length - 1; k <= loopTo7; k++)
                            {
                                var loopTo8 = sciences.Length - 1;
                                for (l = k + 1; l <= loopTo8; l++)
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectLess(sci[k], sci[l], false)))
                                    {
                                        temp = Conversions.ToInteger(sci[k]);
                                        temp_name = sci_names[k];
                                        sci[k] = sci[l];
                                        sci_names[k] = sci_names[l];
                                        sci[l] = temp;
                                        sci_names[l] = temp_name;
                                    }
                                }
                            }

                            for (int k = 0, loopTo9 = sciences.Length - 1; k <= loopTo9; k++)
                            {
                                if (k < sciences.Length - 1)
                                {
                                    out_of = markOutOf(sci_names[k], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                    total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(sci[k], out_of), mark));
                                    tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[k], out_of), 100)), radSubject.Checked, sci_names[k]))));
                                    subjects_7[i][Conversions.ToInteger(counter)] = sci_names[k];
                                    counter += 1;
                                }
                            }
                        }
                        else
                        {
                            for (int k = 0, loopTo10 = sciences.Length - 1; k <= loopTo10; k++)
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader[sciences[k]]))
                                {
                                    out_of = markOutOf(sci_names[k], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                    total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[sciences[k]], out_of), mark));
                                    tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[sciences[k]], out_of), 100)), radSubject.Checked, sci_names[k]))));
                                    subjects_7[i][Conversions.ToInteger(counter)] = sciences[k];
                                    counter += 1;
                                }
                            }
                        }

                        // ###########get highest and second best performed humanity ##################
                        int count = humanities.Length;
                        for (int k = 0, loopTo11 = humanities.Length - 1; k <= loopTo11; k++)
                            hum_names[k] = humanities[k];
                        for (int k = 0, loopTo12 = humanities.Length - 1; k <= loopTo12; k++)
                        {
                            if (!Information.IsNumeric(publicSubsNFunctions.dbreader[humanities[k]]))
                            {
                                count -= 1;
                            }
                        }

                        if (count > 1)
                        {
                            humanity = true;
                            l = 0;
                            for (int k = 0, loopTo13 = humanities.Length - 1; k <= loopTo13; k++)
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader[humanities[k]]))
                                {
                                    hum[k] = Conversions.ToInteger(publicSubsNFunctions.dbreader[humanities[k]]);
                                }
                            }

                            for (int k = 0, loopTo14 = hum.Length - 1; k <= loopTo14; k++)
                            {
                                var loopTo15 = hum.Length - 1;
                                for (l = k + 1; l <= loopTo15; l++)
                                {
                                    if (hum[k] < hum[l] | !Information.IsNumeric(hum[k]) & Information.IsNumeric(hum[l]))
                                    {
                                        temp = hum[k];
                                        temp_name = hum_names[k];
                                        hum[k] = hum[l];
                                        hum_names[k] = hum_names[l];
                                        hum_names[l] = temp_name;
                                        hum[l] = temp;
                                    }
                                }
                            }

                            out_of = markOutOf(hum_names[0], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                            total = (int)Math.Round(total + hum[0] / out_of * mark);
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[0] / out_of * 100d, radSubject.Checked, hum_names[0]))));
                            subjects_7[i][Conversions.ToInteger(counter)] = hum_names[0];
                            counter += 1;
                        }
                        else
                        {
                            for (int k = 0, loopTo16 = humanities.Length - 1; k <= loopTo16; k++)
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader[humanities[k]]))
                                {
                                    out_of = markOutOf(hum_names[k], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                    total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[humanities[k]], out_of), mark));
                                    tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[humanities[k]], out_of), 100)), radSubject.Checked, hum_names[k]))));
                                    subjects_7[i][Conversions.ToInteger(counter)] = humanities[k];
                                    counter += 1;
                                }
                            }
                        }

                        // ########### get highest performed applied subject ##################
                        for (int k = 0, loopTo17 = applieds.Length - 1; k <= loopTo17; k++)
                            app_names[k] = applieds[k];
                        count = 0;
                        l = 0;
                        for (int k = 0, loopTo18 = applieds.Length - 1; k <= loopTo18; k++)
                        {
                            if (Information.IsNumeric(publicSubsNFunctions.dbreader[applieds[k]]))
                            {
                                count += 1;
                            }
                        }

                        if (count > 0)
                        {
                            applied = true;
                            for (int k = 0, loopTo19 = applieds.Length - 1; k <= loopTo19; k++)
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader[applieds[k]]))
                                {
                                    app[l] = Conversions.ToInteger(publicSubsNFunctions.dbreader[applieds[k]]);
                                    app_names[l] = applieds[k];
                                    l += 1;
                                }
                            }

                            for (int k = 0, loopTo20 = app.Length - 1; k <= loopTo20; k++)
                            {
                                var loopTo21 = app.Length - 1;
                                for (l = k + 1; l <= loopTo21; l++)
                                {
                                    if (app[k] < app[l])
                                    {
                                        temp = app[k];
                                        temp_name = app_names[k];
                                        app[k] = app[l];
                                        app_names[k] = app_names[l];
                                        app[l] = temp;
                                        app_names[l] = temp_name;
                                    }
                                }
                            }
                        }

                        if (science & humanity & applied)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], hum[1], false)))
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], app[0], false)))
                                {
                                    out_of = markOutOf(sci_names[2], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                    total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), mark));
                                    tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[sci_names[2]], out_of), 100)), radSubject.Checked, sci_names[2]))));
                                    subjects_7[i][Conversions.ToInteger(counter)] = sci_names[2];
                                    counter += 1;
                                }
                                else
                                {
                                    out_of = markOutOf(app_names[0], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                    total = (int)Math.Round(total + app[0] / out_of * mark);
                                    tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[app_names[0]], out_of), 100)), radSubject.Checked, app_names[0]))));
                                    subjects_7[i][Conversions.ToInteger(counter)] = app_names[0];
                                    counter += 1;
                                }
                            }
                            else if (hum[1] > app[0])
                            {
                                out_of = markOutOf(hum_names[1], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                total = (int)Math.Round(total + hum[1] / out_of * mark);
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / out_of * 100d, radSubject.Checked, hum_names[1]))));
                                subjects_7[i][Conversions.ToInteger(counter)] = hum_names[1];
                                counter += 1;
                            }
                            else
                            {
                                out_of = markOutOf(app_names[0], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                total = (int)Math.Round(total + app[0] / out_of * mark);
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, radSubject.Checked, app_names[0]))));
                                subjects_7[i][Conversions.ToInteger(counter)] = app_names[0];
                                counter += 1;
                            }
                        }
                        else if (science & humanity)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], hum[1], false)))
                            {
                                out_of = markOutOf(sci_names[2], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), mark));
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100)), radSubject.Checked, sci_names[2]))));
                                subjects_7[i][Conversions.ToInteger(counter)] = sci_names[2];
                                counter += 1;
                            }
                            else
                            {
                                out_of = markOutOf(hum_names[1], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                total = (int)Math.Round(total + hum[1] / out_of * mark);
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / mark * 100d, radSubject.Checked, hum_names[1]))));
                                subjects_7[i][Conversions.ToInteger(counter)] = hum_names[1];
                                counter += 1;
                            }
                        }
                        else if (science & applied)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], app[0], false)))
                            {
                                out_of = markOutOf(sci_names[2], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), mark));
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100)), radSubject.Checked, sci_names[2]))));
                                subjects_7[i][Conversions.ToInteger(counter)] = sci_names[2];
                                counter += 1;
                            }
                            else
                            {
                                out_of = markOutOf(app_names[0], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                total = (int)Math.Round(total + app[0] / out_of * mark);
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, radSubject.Checked, app_names[0]))));
                                subjects_7[i][Conversions.ToInteger(counter)] = app_names[0];
                                counter += 1;
                            }
                        }
                        else if (applied & humanity)
                        {
                            if (app[0] > hum[1])
                            {
                                out_of = markOutOf(app_names[0], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                total = (int)Math.Round(total + app[0] / out_of * mark);
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, radSubject.Checked, app_names[0]))));
                                subjects_7[i][Conversions.ToInteger(counter)] = app_names[0];
                                counter += 1;
                            }
                            else
                            {
                                out_of = markOutOf(hum_names[1], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                total = (int)Math.Round(total + hum[1] / out_of * mark);
                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / out_of * 100d, radSubject.Checked, hum_names[1]))));
                                subjects_7[i][Conversions.ToInteger(counter)] = hum_names[1];
                                counter += 1;
                            }
                        }
                        else if (science)
                        {
                            out_of = markOutOf(sci_names[2], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                            total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), mark));
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100)), radSubject.Checked, sci_names[2]))));
                            subjects_7[i][Conversions.ToInteger(counter)] = sci_names[2];
                            counter += 1;
                        }
                        else if (humanity)
                        {
                            out_of = markOutOf(hum_names[1], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                            total = (int)Math.Round(total + hum[1] / out_of * mark);
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / out_of * 100d, radSubject.Checked, hum_names[1]))));
                            subjects_7[i][Conversions.ToInteger(counter)] = hum_names[1];
                            counter += 1;
                        }
                        else if (applied)
                        {
                            out_of = markOutOf(app_names[0], Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                            total = (int)Math.Round(total + app[0] / out_of * mark);
                            tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, radSubject.Checked, app_names[0]))));
                            subjects_7[i][Conversions.ToInteger(counter)] = app_names[0];
                            counter += 1;
                        }
                    }
                    else
                    {
                        for (int k = 0, loopTo22 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo22; k++)
                        {
                            if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k])))
                            {
                                out_of = markOutOf(Conversions.ToString(publicSubsNFunctions.subjname[k]), Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                                if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectGreater(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), 0, false), out_of)))
                                {
                                    total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), out_of), mark));
                                }

                                tp = Conversions.ToInteger(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), out_of), 100)), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[k])))));
                            }
                        }
                    }

                    for (int k = 0, loopTo23 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo23; k++)
                    {
                        if (!Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k])))
                        {
                            dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value = publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]);
                        }
                        else
                        {
                            out_of = markOutOf(Conversions.ToString(publicSubsNFunctions.subjname[k]), Conversions.ToString(publicSubsNFunctions.dbreader["Stream"]));
                            double num = Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), out_of), mark));
                            if (num < 10d)
                            {
                                dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value = "0" + Math.Round(num, 0);
                            }
                            else
                            {
                                dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value = Math.Round(num, 0);
                            }
                        }
                    }

                    dgvEnterMarks["Total", i].Value = total;
                    int counts = 0;
                    for (int k = 0, loopTo24 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo24; k++)
                    {
                        if (dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).value.ToString() != "-")
                        {
                            counts += 1;
                        }
                    }

                    if (counts >= 7)
                    {
                        dgvEnterMarks["TP", i].Value = tp;
                    }
                    else
                    {
                        dgvEnterMarks["TP", i].Value = "0";
                    }

                    for (int k = 0, loopTo25 = compulsory.Length - 1; k <= loopTo25; k++)
                    {
                        if (!Information.IsNumeric(dgvEnterMarks[compulsory[k], i].Value))
                        {
                            dgvEnterMarks["TP", i].Value = "0";
                        }
                    }

                    counts = 0;
                    for (int k = 0, loopTo26 = sciences.Length - 1; k <= loopTo26; k++)
                    {
                        if (!Information.IsNumeric(dgvEnterMarks[sciences[k], i].Value))
                        {
                            counts += 1;
                        }
                    }

                    if (counts > 1)
                    {
                        dgvEnterMarks["TP", i].Value = "0";
                    }

                    i += 1;
                    Pbar.Increment(inc);
                }

                dgvEnterMarks.Sort(dgvEnterMarks.Columns["Total"], System.ComponentModel.ListSortDirection.Descending);
                i = 0;
                var loopTo27 = publicSubsNFunctions.streams.Length - 1;
                for (j = 0; j <= loopTo27; j++)
                    stream_no[j] = 0;
                var loopTo28 = dgvEnterMarks.Rows.Count - 1;
                for (i = 0; i <= loopTo28; i++)
                {
                    try
                    {
                        var loopTo29 = publicSubsNFunctions.streams.Length - 1;
                        for (j = 0; j <= loopTo29; j++)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", i].Value, publicSubsNFunctions.streams[j], false)))
                            {
                                dgvEnterMarks["Position", i].Value = stream_no[j] + 1;
                                stream_no[j] += 1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                var loopTo30 = dgvEnterMarks.Rows.Count - 1;
                for (i = 0; i <= loopTo30; i++)
                    dgvEnterMarks["Overall", i].Value = i + 1;
                compute();
                for (int k = 0, loopTo31 = dgvEnterMarks.Rows.Count - 5; k <= loopTo31; k++)
                    dgvEnterMarks["VAP", k].Value = Strings.Format(vap(Conversions.ToString(dgvEnterMarks["ADMNo", k].Value), Conversions.ToDouble(dgvEnterMarks["MP", k].Value)), "0.00");
                class_out_of = i;
            }

            Pbar.Increment(-100);
            Pbar.Visible = false;
            if (publicSubsNFunctions.show_split)
            {
                for (int k = 0, loopTo32 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo32; k++)
                {
                    get_split_subjects(Conversions.ToString(publicSubsNFunctions.subjects[k]));
                    for (int s = 0, loopTo33 = splits.Length - 1; s <= loopTo33; s++)
                    {
                        for (int row = 0, loopTo34 = dgvEnterMarks.Rows.Count - 1; row <= loopTo34; row++)
                        {
                            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `" + publicSubsNFunctions.class_form + "_", splits[s]), "` FROM exam_split_subject_results WHERE ADMNo='"), dgvEnterMarks["ADMNo", row].Value), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND Term='"), publicSubsNFunctions.tm), "' AND Year='"), publicSubsNFunctions.yr), "'"));
                            publicSubsNFunctions.qread(ref argq);
                            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                            {
                                publicSubsNFunctions.dbreader.Read();
                                dgvEnterMarks.Item(splits[s], row).Value = publicSubsNFunctions.dbreader(Operators.ConcatenateObject(publicSubsNFunctions.class_form + "_", splits[s]));
                            }
                        }
                    }
                }
            }

            if (publicSubsNFunctions.grade)
            {
                gradeview();
            }
        }

        private double vap(string adm, double mp)
        {
            double vapRet = default;
            string argq = "SELECT marks_attained_primary FROM students WHERE admin_no='" + adm + "'";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                if (Conversions.ToBoolean(Operators.AndObject(!Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.dbreader["marks_attained_primary"], "--", false), !Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.dbreader["marks_attained_primary"], string.Empty, false))))
                {
                    vapRet = Conversions.ToDouble(publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader["marks_attained_primary"], 500), 100)), false, string.Empty))));
                    vapRet = mp - vapRet;
                }
            }
            else
            {
                vapRet = 0.0d;
            }

            return vapRet;
        }

        private string vapgrade(string adm)
        {
            string vapgradeRet = default;
            string argq = "SELECT marks_attained_primary FROM students WHERE admin_no ='" + adm + "'";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                vapgradeRet = Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader["marks_attained_primary"], 500), 100)), false, string.Empty));
            }
            else
            {
                vapgradeRet = "E";
            }

            return vapgradeRet;
        }

        private object indexno(string adm)
        {
            object indexnoRet = default;
            string argq = "SELECT indexno FROM students WHERE admin_no='" + adm + "'";
            publicSubsNFunctions.qread(ref argq);
            try
            {
                publicSubsNFunctions.dbreader.Read();
                indexnoRet = publicSubsNFunctions.dbreader["indexno"];
            }
            catch (Exception ex)
            {
                return "000";
            }

            return indexnoRet;
        }

        private void index_no()
        {
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
                dgvEnterMarks["INDEX", k].Value = indexno(Conversions.ToString(dgvEnterMarks["ADMNo", k].Value));
        }

        private void convert_to_double()
        {
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
                dgvEnterMarks[publicSubsNFunctions.sortby, k].Value = Convert.ToDouble(dgvEnterMarks[publicSubsNFunctions.sortby, k].Value);
        }

        private void compute()
        {
            index_no();
            mean_mark();
            subject_entries();
            if (!publicSubsNFunctions.form_4_mode)
            {
                total_points();
            }

            mean_point();
            meangrade();
            convert_to_double();
            try
            {
                dgvEnterMarks.Sort(dgvEnterMarks.Columns[publicSubsNFunctions.sortby], System.ComponentModel.ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
            }

            if (publicSubsNFunctions.sortby == "MP")
            {
                for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
                    dgvEnterMarks["MP", k].Value = Strings.Format(dgvEnterMarks["MP", k].Value, "0.00");
            }

            positions();
            mean_score();
            total_means();
            mean_grade();
            mean_points();
            kcpe();
            mean_grade_points();
        }

        private void mean_grade_points()
        {
            dgvEnterMarks.Rows.Add();
            dgvEnterMarks["StudentName", dgvEnterMarks.Rows.Count - 1].Value = "MEAN GRADE (M. POINTS)";
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], (object)(dgvEnterMarks.Rows.Count - 2)).value))
                {
                    dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], (object)(dgvEnterMarks.Rows.Count - 2)).value));
                }
                else
                {
                    dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = "--";
                }
            }
        }

        private void mean_mark()
        {
            int cnt = 0;
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
            {
                cnt = 0;
                for (int s = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo1; s++)
                {
                    if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value))
                    {
                        cnt += 1;
                    }
                    else if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.ConditionalCompareObjectEqual(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value, "X", false), Operators.ConditionalCompareObjectEqual(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value, "Y", false)), Operators.ConditionalCompareObjectEqual(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value, "x", false)), Operators.ConditionalCompareObjectEqual(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value, "y", false))))
                    {
                        cnt += 1;
                    }
                }

                if (!publicSubsNFunctions.form_4_mode)
                {
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks["Total", k].Value, 0, false), Information.IsNumeric(dgvEnterMarks["Total", k].Value))))
                    {
                        dgvEnterMarks["MM", k].Value = Strings.Format(Operators.DivideObject(dgvEnterMarks["Total", k].Value, cnt), "0.00");
                    }
                    else
                    {
                        dgvEnterMarks["MM", k].Value = "0";
                    }
                }
                else if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks["Total", k].Value, 0, false), Information.IsNumeric(dgvEnterMarks["Total", k].Value))))
                {
                    dgvEnterMarks["MM", k].Value = Strings.Format(Operators.DivideObject(dgvEnterMarks["Total", k].Value, 7), "0.00");
                }
                else
                {
                    dgvEnterMarks["MM", k].Value = "0";
                }

                // new code start
                if (xStudents.Contains(dgvEnterMarks["ADMNo", k].Value.ToString()))
                {
                    dgvEnterMarks["MM", k].Value = "0";
                }
                // new code end
            }

            for (int k = 0, loopTo2 = dgvEnterMarks.Rows.Count - 1; k <= loopTo2; k++)
                dgvEnterMarks["MM", k].Value = Convert.ToDouble(dgvEnterMarks["MM", k].Value);
        }

        private void kcpe()
        {
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 4; k <= loopTo; k++)
                dgvEnterMarks["KCPE", k].Value = get_kcpe_marks(Conversions.ToString(dgvEnterMarks["ADMNo", k].Value));
        }

        private void meangrade()
        {
            string grade;
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
            {
                grade = null;
                if (publicSubsNFunctions.mode)
                {
                    if (publicSubsNFunctions.form_4_mode)
                    {
                        if (Conversions.ToBoolean(get_compulsory()))
                        {
                            for (int c = 0, loopTo1 = compulsory.Length - 1; c <= loopTo1; c++)
                            {
                                if (dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(compulsory[c]), k).value.ToString() == "X" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(compulsory[c]), k).value.ToString() == "Y" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(compulsory[c]), k).value.ToString() == "x" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(compulsory[c]), k).value.ToString() == "y")
                                {
                                    grade = Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(compulsory[c]), k).value);
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(grade))
                        {
                            dgvEnterMarks["MG", k].Value = grade;
                        }
                        else
                        {
                            int cnt = 0;
                            if (Conversions.ToBoolean(get_sciences()))
                            {
                                for (int s = 0, loopTo2 = sciences.Length - 1; s <= loopTo2; s++)
                                {
                                    if (dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(sciences[s]), k).value.ToString() == "X" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(sciences[s]), k).value.ToString() == "Y" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(sciences[s]), k).value.ToString() == "x" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(sciences[s]), k).value.ToString() == "y")
                                    {
                                        cnt += 1;
                                        grade = Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(sciences[s]), k).value);
                                    }
                                }
                            }

                            if (cnt > 1)
                            {
                                dgvEnterMarks["MG", k].Value = grade;
                            }
                            else
                            {
                                cnt = 0;
                                grade = null;
                                int count = 0;
                                if (Conversions.ToBoolean(get_humanity()))
                                {
                                    for (int s = 0, loopTo3 = humanities.Length - 1; s <= loopTo3; s++)
                                    {
                                        if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value))
                                        {
                                            count += 1;
                                        }

                                        if (dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value.ToString() == "X" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value.ToString() == "Y" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value.ToString() == "x" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value.ToString() == "y")
                                        {
                                            cnt += 1;
                                            grade = Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value);
                                        }
                                    }
                                }

                                if (count == 0)
                                {
                                    if (!string.IsNullOrEmpty(grade))
                                    {
                                        dgvEnterMarks["MG", k].Value = grade;
                                    }
                                    else
                                    {
                                        dgvEnterMarks["MG", k].Value = "-";
                                    }
                                }
                                else
                                {
                                    dgvEnterMarks["MG", k].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvEnterMarks["MP", k].Value));
                                }
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            dgvEnterMarks["MG", k].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvEnterMarks["MP", k].Value));
                        }
                        catch (Exception ex)
                        {
                            dgvEnterMarks["MG", k].Value = dgvEnterMarks["MP", k].Value;
                        }
                    }
                }
                else
                {
                    double total = Conversions.ToDouble(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                    if (publicSubsNFunctions.form_4_mode)
                    {
                        if (Conversions.ToBoolean(get_compulsory()))
                        {
                            for (int c = 0, loopTo4 = compulsory.Length - 1; c <= loopTo4; c++)
                            {
                                if (dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(compulsory[c]), k).value.ToString() == "X" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(compulsory[c]), k).value.ToString() == "Y" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(compulsory[c]), k).value.ToString() == "x" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(compulsory[c]), k).value.ToString() == "y")
                                {
                                    grade = Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(compulsory[c]), k).value);
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(grade))
                        {
                            dgvEnterMarks["MG", k].Value = grade;
                        }
                        else
                        {
                            int cnt = 0;
                            if (Conversions.ToBoolean(get_sciences()))
                            {
                                for (int s = 0, loopTo5 = sciences.Length - 1; s <= loopTo5; s++)
                                {
                                    if (dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(sciences[s]), k).value.ToString() == "X" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(sciences[s]), k).value.ToString() == "Y" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(sciences[s]), k).value.ToString() == "x" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(sciences[s]), k).value.ToString() == "y")
                                    {
                                        cnt += 1;
                                        grade = Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(sciences[s]), k).value);
                                    }
                                }
                            }

                            if (cnt > 1)
                            {
                                dgvEnterMarks["MG", k].Value = grade;
                            }
                            else
                            {
                                cnt = 0;
                                grade = null;
                                int count = 0;
                                if (Conversions.ToBoolean(get_humanity()))
                                {
                                    for (int s = 0, loopTo6 = humanities.Length - 1; s <= loopTo6; s++)
                                    {
                                        if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value))
                                        {
                                            count += 1;
                                        }

                                        if (dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value.ToString() == "X" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value.ToString() == "Y" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value.ToString() == "x" | dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value.ToString() == "y")
                                        {
                                            cnt += 1;
                                            grade = Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.remove_wild(humanities[s]), k).value);
                                        }
                                    }
                                }

                                if (count == 0)
                                {
                                    if (!string.IsNullOrEmpty(grade))
                                    {
                                        dgvEnterMarks["MG", k].Value = grade;
                                    }
                                    else
                                    {
                                        dgvEnterMarks["MG", k].Value = "-";
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        dgvEnterMarks["MG", k].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvEnterMarks["MP", k].Value));
                                    }
                                    catch (Exception ex)
                                    {
                                        dgvEnterMarks["MG", k].Value = "-";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            dgvEnterMarks["MG", k].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvEnterMarks["MP", k].Value));
                        }
                        catch (Exception ex)
                        {
                            dgvEnterMarks["MG", k].Value = dgvEnterMarks["MP", k].Value;
                        }
                    }
                }

                if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["Sent", k].Value, 0, false), Operators.ConditionalCompareObjectEqual(dgvEnterMarks["Mp", k].Value, 0, false))))
                {
                    dgvEnterMarks["MG", k].Value = "--";
                }


                // new code start
                if (xStudents.Contains(dgvEnterMarks["ADMNo", k].Value.ToString()))
                {
                    dgvEnterMarks["MG", k].Value = "X";
                }
                // new code end

            }
        }

        private void mean_point()
        {
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
            {
                if (!publicSubsNFunctions.form_4_mode)
                {
                    if (Conversions.ToBoolean(Operators.AndObject(Information.IsNumeric(dgvEnterMarks["Sent", k].Value), Operators.ConditionalCompareObjectGreater(dgvEnterMarks["Sent", k].Value, 0, false))))
                    {
                        dgvEnterMarks["MP", k].Value = Strings.Format(Operators.DivideObject(dgvEnterMarks["TP", k].Value, dgvEnterMarks["Sent", k].Value), "0.00");
                    }
                    else
                    {
                        dgvEnterMarks["MP", k].Value = "0";
                    }
                }
                else if (Conversions.ToBoolean(Operators.AndObject(Information.IsNumeric(dgvEnterMarks["Sent", k].Value), Operators.ConditionalCompareObjectGreater(dgvEnterMarks["Sent", k].Value, 0, false))))
                {
                    dgvEnterMarks["MP", k].Value = Strings.Format(Operators.DivideObject(dgvEnterMarks["TP", k].Value, 7), "0.00");
                }
                else
                {
                    dgvEnterMarks["MP", k].Value = "0";
                }


                // new code start
                if (xStudents.Contains(dgvEnterMarks["ADMNo", k].Value.ToString()))
                {
                    dgvEnterMarks["MP", k].Value = "0";
                }
                // new code end

            }

            for (int k = 0, loopTo1 = dgvEnterMarks.Rows.Count - 1; k <= loopTo1; k++)
                dgvEnterMarks["MP", k].Value = Convert.ToDouble(dgvEnterMarks["MP", k].Value);
        }

        private void total_points()
        {
            int cnt;
            if (publicSubsNFunctions.mode)
            {
                for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
                {
                    cnt = 0;
                    for (int s = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo1; s++)
                    {
                        if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value))
                        {
                            cnt = Conversions.ToInteger(cnt + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[s])))));
                        }
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks["Sent", k].Value, 0, false)))
                    {
                        dgvEnterMarks["TP", k].Value = cnt;
                    }
                    else
                    {
                        dgvEnterMarks["TP", k].Value = "0";
                    }


                    // new code start
                    if (xStudents.Contains(dgvEnterMarks["ADMNo", k].Value.ToString()))
                    {
                        dgvEnterMarks["TP", k].Value = "0";
                    }
                    // new code end
                }
            }
            else
            {
                double total = Conversions.ToDouble(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                for (int k = 0, loopTo2 = dgvEnterMarks.Rows.Count - 1; k <= loopTo2; k++)
                {
                    cnt = 0;
                    for (int s = 0, loopTo3 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo3; s++)
                    {
                        if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value))
                        {
                            cnt = Conversions.ToInteger(cnt + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value, total), 100)), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[s])))));
                        }
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks["Sent", k].Value, 0, false)))
                    {
                        dgvEnterMarks["TP", k].Value = cnt;
                    }
                    else
                    {
                        dgvEnterMarks["TP", k].Value = "0";
                    }


                    // new code start
                    if (xStudents.Contains(dgvEnterMarks["ADMNo", k].Value.ToString()))
                    {
                        dgvEnterMarks["TP", k].Value = "0";
                    }
                    // new code end
                }
            }

            // For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
            // dgvEnterMarks.Item("TP", k).Value = Convert.ToDouble(dgvEnterMarks.Item("MP", k).Value)
            // Next
        }

        private void subject_entries()
        {
            int cnt;
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
            {
                cnt = 0;
                for (int s = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo1; s++)
                {
                    if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value))
                    {
                        cnt += 1;
                    }
                    else if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.ConditionalCompareObjectEqual(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value, "X", false), Operators.ConditionalCompareObjectEqual(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value, "Y", false)), Operators.ConditionalCompareObjectEqual(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value, "x", false)), Operators.ConditionalCompareObjectEqual(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).value, "y", false))))
                    {
                        cnt += 1;
                    }
                }

                dgvEnterMarks["Sent", k].Value = cnt;
            }
        }

        private void mean_points()
        {
            var mark = default(double);
            if (!publicSubsNFunctions.mode)
            {
                mark = Conversions.ToDouble(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
            }

            dgvEnterMarks.Rows.Add();
            dgvEnterMarks["StudentName", dgvEnterMarks.Rows.Count - 1].Value = "MEAN POINTS";
            int cnt;
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = 0;
            for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
            {
                cnt = 0;
                for (int l = 0, loopTo2 = dgvEnterMarks.Rows.Count - 4; l <= loopTo2; l++)
                {
                    if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], l).value))
                    {
                        cnt += 1;
                        if (publicSubsNFunctions.mode)
                        {
                            dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value += publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], l).value), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[k]))));
                        }
                        else
                        {
                            dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value += publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], l).value, mark), 100)), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[k]))));
                        }
                    }
                    else if (dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], l).value.ToString() != "-")
                    {
                        dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value += (object)1;
                        cnt += 1;
                    }
                }

                double value = Conversions.ToDouble(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], (object)(dgvEnterMarks.Rows.Count - 1)).value);
                if (cnt == 0)
                {
                    dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = "--";
                }
                else
                {
                    dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = Strings.Format(Convert.ToDouble(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], (object)(dgvEnterMarks.Rows.Count - 1)).value, cnt)), "0.00");
                }
            }
        }

        private void mean_grade()
        {
            dgvEnterMarks.Rows.Add();
            dgvEnterMarks["StudentName", dgvEnterMarks.Rows.Count - 1].Value = "MEAN GRADE (M. MARKS)";
            if (publicSubsNFunctions.mode)
            {
                for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                {
                    if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], (object)(dgvEnterMarks.Rows.Count - 2)).value))
                    {
                        dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], (object)(dgvEnterMarks.Rows.Count - 2)).value), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[k]));
                    }
                    else
                    {
                        dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = "--";
                    }
                }
            }
            else
            {
                double total = Conversions.ToDouble(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                {
                    if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], (object)(dgvEnterMarks.Rows.Count - 2)).value))
                    {
                        dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], (object)(dgvEnterMarks.Rows.Count - 2)).value, total), 100)), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[k]));
                    }
                    else
                    {
                        dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = "--";
                    }
                }
            }
        }

        private object position_in_exam(string exam)
        {
            object position_in_examRet = default;
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT pos FROM examination_performance WHERE (exam='" + exam + "' AND term='" + publicSubsNFunctions.tm + "' AND year='" + publicSubsNFunctions.yr + "' AND ADMNo='", dgvEnterMarks["ADMNo", student].Value), "')"));
            publicSubsNFunctions.qread(ref argq);
            try
            {
                publicSubsNFunctions.dbreader.Read();
                position_in_examRet = publicSubsNFunctions.dbreader["pos"];
            }
            catch (Exception ex)
            {
                position_in_examRet = "0/00";
            }

            return position_in_examRet;
        }

        private object no_of_splits(string subject)
        {
            for (int k = 0, loopTo = publicSubsNFunctions.subjects.Length - 1; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.subjects[k], subject, false)))
                {
                    return subject_splits[k];
                }
            }

            return 0;
        }

        private void mean_score()
        {
            dgvEnterMarks.Rows.Add();
            dgvEnterMarks["StudentName", dgvEnterMarks.Rows.Count - 1].Value = "MEAN SCORE";
            int cnt;
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = 0;
            double count = 0d;
            for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
            {
                cnt = 0;
                for (int l = 0, loopTo2 = dgvEnterMarks.Rows.Count - 2; l <= loopTo2; l++)
                {
                    if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], l).value))
                    {
                        cnt += 1;
                        dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value += dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], l).value;
                        count = Conversions.ToDouble(count + dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], l).value);
                    }
                    else if (dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], l).value.ToString() != "-")
                    {
                        cnt += 1;
                    }
                }

                if (cnt == 0)
                {
                    dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = "--";
                }
                else
                {
                    dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], dgvEnterMarks.Rows.Count - 1).value = Strings.Format(Convert.ToDouble(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], (object)(dgvEnterMarks.Rows.Count - 1)).value, cnt)), "0.00");
                }
            }
        }

        private void total_means()
        {
            int cnt;
            var totals = new string[] { "MM", "MP", "Total", "TP" };
            for (int t = 0, loopTo = totals.Length - 1; t <= loopTo; t++)
            {
                cnt = 0;
                for (int l = 0, loopTo1 = dgvEnterMarks.Rows.Count - 2; l <= loopTo1; l++)
                {
                    if (Information.IsNumeric(dgvEnterMarks[totals[t], l].Value))
                    {
                        cnt += 1;
                        dgvEnterMarks[totals[t], dgvEnterMarks.Rows.Count - 1].Value = Convert.ToDouble(dgvEnterMarks[totals[t], dgvEnterMarks.Rows.Count - 1].Value) + Convert.ToDouble(dgvEnterMarks[totals[t], l].Value);
                    }
                }

                dgvEnterMarks[totals[t], dgvEnterMarks.Rows.Count - 1].Value = Strings.Format(Convert.ToDouble(Operators.DivideObject(dgvEnterMarks[totals[t], dgvEnterMarks.Rows.Count - 1].Value, cnt)), "0.00");
            }
        }

        private void save_subjects()
        {
            Pbar.Visible = true;
            // lblWait.Visible = True
            int increment = (int)Math.Round((dgvEnterMarks.Rows.Count - 5) / 100d);
            if (publicSubsNFunctions.grade)
            {
                dgvEnterMarks.Rows.Clear();
                publicSubsNFunctions.grade = false;
                btnViewReport.Enabled = true;
                if (publicSubsNFunctions.mode)
                {
                    load_multi();
                }
                else
                {
                    load_entered();
                }

                btnGrade.Text = "View In Grade Mode";
            }

            publicSubsNFunctions.marks = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
            try
            {
                publicSubsNFunctions.qwrite("CREATE TABLE `subjects_progress` (" + "`id` int(11) NOT NULL auto_increment," + "`admno` int(11) NOT NULL," + "`subject` varchar(100) NOT NULL," + "`grade` double NOT NULL," + "`term` varchar(3) NOT NULL," + "`year` int(11) NOT NULL," + "`exam` varchar(100) NOT NULL," + " PRIMARY KEY  (`id`)" + ") ENGINE=InnoDB DEFAULT CHARSET=latin1;");
            }
            catch (Exception ex)
            {
            }

            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 5; k <= loopTo; k++)
            {
                for (int s = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo1; s++)
                {
                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("DELETE FROM subjects_progress WHERE (admno='", dgvEnterMarks["ADMNo", k].Value), "' AND subject='"), publicSubsNFunctions.subject_get(publicSubsNFunctions.subjids[s])), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "' AND exam='"), publicSubsNFunctions.exam_name), "')"));
                    publicSubsNFunctions.qwrite(publicSubsNFunctions.query);
                    try
                    {
                        publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO subjects_progress VALUES(NULL,'", dgvEnterMarks["ADMNo", k].Value), "','"), publicSubsNFunctions.subject_get(publicSubsNFunctions.subjids[s])), "','"), publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).Value, publicSubsNFunctions.marks), 100)), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[s]))))), "','"), publicSubsNFunctions.tm), "','"), publicSubsNFunctions.yr), "','"), publicSubsNFunctions.exam_name), "')"));
                    }
                    catch (Exception ex)
                    {
                        publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO subjects_progress VALUES(NULL,'", dgvEnterMarks["ADMNo", k].Value), "','0','"), dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).Value), "','"), publicSubsNFunctions.tm), "','"), publicSubsNFunctions.yr), "','"), publicSubsNFunctions.exam_name), "')"));
                    }

                    publicSubsNFunctions.qwrite(publicSubsNFunctions.query);
                }

                Pbar.Increment(increment);
            }

            Pbar.Increment(-100);
            Pbar.Visible = false;
        }

        private object print_student_report2()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_report2;
            return print_document;
        }

        private object print_student_report3()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_report3;
            return print_document;
        }

        private int start_from = 0;
        private bool in_page = false;
        private void print_report3(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            int line = 30;
            int left_margin = 40;
            int right_margin = 1100;
            int count = 0;
            float CenterPage;
            float max_height;
            if (publicSubsNFunctions.IsPrimary())
            {
                max_height = 1050f;
            }
            else
            {
                max_height = 750f;
            }

            if (start_from == 0)
            {
                try
                {
                    e.Graphics.DrawImage(Image.FromFile(logoPath), left_margin + 10, line, 100, 100);
                    line += 15;
                }
                catch (Exception ex)
                {
                    Timer1.Enabled = false;
                    if (!mode_view)
                    {
                        Timer1.Enabled = true;
                    }
                }

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

                if (publicSubsNFunctions.mode)
                {
                    publicSubsNFunctions.exam_name = null;
                    for (int k = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo; k++)
                    {
                        if (k > 0)
                        {
                            publicSubsNFunctions.exam_name += "/";
                        }

                        publicSubsNFunctions.exam_name = Conversions.ToString(publicSubsNFunctions.exam_name + publicSubsNFunctions.exam_names[k]);
                    }
                }

                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper() + " " + publicSubsNFunctions.class_stream.ToString().ToUpper() + " MERIT LIST FOR " + publicSubsNFunctions.exam_name + " EXAM, TERM " + publicSubsNFunctions.tm + " " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font).Width / 2f);
                e.Graphics.DrawString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper() + " " + publicSubsNFunctions.class_stream.ToString().ToUpper() + " MERIT LIST FOR " + publicSubsNFunctions.exam_name + " EXAM, TERM " + publicSubsNFunctions.tm + " " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
                line += publicSubsNFunctions.other_font.Height + 5;
            }

            line += 10;
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
            int topline = line;
            line += 10;
            if (start_from < dgvEnterMarks.Rows.Count)
            {
                for (int col = 0, loopTo1 = dgvEnterMarks.Columns.Count - 1; col <= loopTo1; col++)
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
                                e.Graphics.DrawString(dgvEnterMarks.Columns[col].HeaderText.Substring(0, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                            }
                            catch (Exception ex)
                            {
                                e.Graphics.DrawString(dgvEnterMarks.Columns[col].HeaderText, publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                            }
                        }

                        count += 1;
                        if (count == 2)
                        {
                            left_margin += 200;
                        }
                        else if (publicSubsNFunctions.IsPrimary())
                        {
                            left_margin += 35;
                        }
                        else
                        {
                            left_margin += 40;
                        }
                    }
                }

                line += 10;
            }

            for (int row = start_from, loopTo2 = dgvEnterMarks.Rows.Count - 1; row <= loopTo2; row++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", row].Value, publicSubsNFunctions.class_stream, false)))
                {
                    line += 2;
                    if (line >= max_height & row < dgvEnterMarks.Rows.Count - 1)
                    {
                        e.HasMorePages = true;
                        start_from = row;
                        return;
                    }

                    left_margin = 40;
                    count = 0;
                    for (int col = 0, loopTo3 = dgvEnterMarks.Columns.Count - 1; col <= loopTo3; col++)
                    {
                        if (dgvEnterMarks.Columns[col].Visible)
                        {
                            if (dgvEnterMarks.Columns[col].Name == "str_class")
                            {
                                if (dgvEnterMarks["str_class", row].Value.ToString().Length > 3)
                                {
                                    e.Graphics.DrawString(dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value.ToString().Substring(0, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
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
                            if (count == 2)
                            {
                                left_margin += 200;
                            }
                            else if (publicSubsNFunctions.IsPrimary())
                            {
                                left_margin += 35;
                            }
                            else
                            {
                                left_margin += 40;
                            }
                        }
                    }

                    line += 2;
                    e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line);
                    line += 10;
                }
            }

            if (line + 100 >= max_height + 60f)
            {
                count = 0;
                line += 5;
                e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line);
                left_margin = 40;
                for (int k = 0, loopTo4 = dgvEnterMarks.Columns.Count - 1; k <= loopTo4; k++)
                {
                    if (dgvEnterMarks.Columns[k].Visible)
                    {
                        if (k == 0)
                        {
                            e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline);
                        }
                        else
                        {
                            e.Graphics.DrawLine(Pens.Black, left_margin - 5, line, left_margin - 5, topline);
                        }

                        count += 1;
                        if (count == 2)
                        {
                            left_margin += 200;
                        }
                        else if (publicSubsNFunctions.IsPrimary())
                        {
                            left_margin += 35;
                        }
                        else
                        {
                            left_margin += 40;
                        }
                    }
                }

                e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline);
                start_from = dgvEnterMarks.Rows.Count;
                e.HasMorePages = true;
                return;
            }

            left_margin = 30;
            e.Graphics.DrawString("SUBJECT MEAN MARKS", publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 20);
            e.Graphics.DrawString("SUBJECT MEAN GRADE (M. MARKS)", publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 40);
            e.Graphics.DrawString("SUBJECT MEAN POINTS", publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 60);
            e.Graphics.DrawString("SUBJECT MEAN GRADE (M. POINTS)", publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 80);
            left_margin = 240;
            var subj_mp = new object[publicSubsNFunctions.subjabb.Length];
            for (int col = 0, loopTo5 = dgvEnterMarks.Columns.Count - 1; col <= loopTo5; col++)
            {
                for (int s = 0, loopTo6 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo6; s++)
                {
                    int counter = 0;
                    double tm, tp;
                    tm = 0d;
                    tp = 0d;
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks.Columns[col].Name, publicSubsNFunctions.subjname[s], false)))
                    {
                        for (int row = 0, loopTo7 = dgvEnterMarks.Rows.Count - 1; row <= loopTo7; row++)
                        {
                            if (Conversions.ToBoolean(Operators.AndObject(dgvEnterMarks[publicSubsNFunctions.subjname[s].ToString(), row].Value.ToString() != "-", Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", row].Value, publicSubsNFunctions.class_stream, false))))
                            {
                                counter += 1;
                                var marks = dgvEnterMarks[publicSubsNFunctions.subjname[s].ToString(), row].Value.ToString().Split(' ');
                                if (marks.Length > 1)
                                {
                                    if (Information.IsNumeric(marks[0]))
                                    {
                                        tm += Conversions.ToDouble(marks[0]);
                                        tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(marks[1]));
                                    }
                                }
                                else if (Information.IsNumeric(marks[0]))
                                {
                                    tm += Conversions.ToDouble(marks[0]);
                                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(marks[0]), radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[s])))));
                                }
                            }
                        }

                        if (tm > 0d & counter > 0)
                        {
                            subj_mp[s] = publicSubsNFunctions.get_points(tp / counter);
                            e.Graphics.DrawString(Strings.Format(tm / counter, "0.00").ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (s + 1) * 40, line + 20);
                            e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_grade(tm / counter, radSubject.Checked, Conversions.ToString(publicSubsNFunctions.subjabb[s]))), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (s + 1) * 40 + 5, line + 40);
                            e.Graphics.DrawString(Strings.Format(tp / counter, "0.00").ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (s + 1) * 40, line + 60);
                            e.Graphics.DrawString(Conversions.ToString(subj_mp[s]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (s + 1) * 40 + 5, line + 80);
                        }
                        else
                        {
                            e.Graphics.DrawString("==", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (s + 1) * 40 + 5, line + 20);
                            e.Graphics.DrawString("==", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (s + 1) * 40 + 5, line + 40);
                            e.Graphics.DrawString("==", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (s + 1) * 40, line + 60);
                            e.Graphics.DrawString("==", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (s + 1) * 40 + 5, line + 80);
                        }
                    }
                }
            }

            if (start_from < dgvEnterMarks.Rows.Count)
            {
                count = 0;
                line += 5;
                e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line);
                left_margin = 40;
                for (int k = 0, loopTo8 = dgvEnterMarks.Columns.Count - 1; k <= loopTo8; k++)
                {
                    if (dgvEnterMarks.Columns[k].Visible)
                    {
                        if (k == 0)
                        {
                            e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline);
                        }
                        else
                        {
                            e.Graphics.DrawLine(Pens.Black, left_margin - 5, line, left_margin - 5, topline);
                        }

                        count += 1;
                        if (count == 2)
                        {
                            left_margin += 200;
                        }
                        else if (publicSubsNFunctions.IsPrimary())
                        {
                            left_margin += 35;
                        }
                        else
                        {
                            left_margin += 40;
                        }
                    }
                }

                e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline);
            }

            line += 100;
            if (line + 20 * publicSubsNFunctions.grades.Length - 1 + line + publicSubsNFunctions.other_font.Height * (publicSubsNFunctions.streams.Length + 1) > max_height + 60f)
            {
                start_from = dgvEnterMarks.Rows.Count;
                e.HasMorePages = true;
                return;
            }

            topline = line;
            left_margin = 100;
            for (int k = 0, loopTo9 = publicSubsNFunctions.grades.Length - 1; k <= loopTo9; k++)
            {
                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.other_font, Brushes.Black, left_margin, line - 8);
                e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin - 100, line);
                line += 20;
            }

            e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin - 100, line);
            int graphtop = topline;
            left_margin += 30;
            for (int k = 0, loopTo10 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo10; k++)
            {
                graphtop = topline;
                for (int g = 0, loopTo11 = publicSubsNFunctions.grades.Length - 1; g <= loopTo11; g++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(subj_mp[k], publicSubsNFunctions.grades[g], false)))
                    {
                        var rect = new Rectangle(left_margin + k * 10, graphtop, 20, line - graphtop);
                        e.Graphics.FillRectangle(Brushes.Black, rect);
                    }
                    else
                    {
                        graphtop += 20;
                    }
                }

                left_margin += 25;
            }

            left_margin = 100;
            left_margin += 30;
            for (int k = 0, loopTo12 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo12; k++)
            {
                try
                {
                    e.Graphics.DrawString(publicSubsNFunctions.subjabb[k].ToString().Substring(0, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                }
                catch (Exception ex)
                {
                    e.Graphics.DrawString(publicSubsNFunctions.subjabb[k].ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                }

                left_margin += 35;
            }

            line += 30;
            left_margin = 30;
            int start_left = 100;
            left_margin = start_left;
            topline = line;
            e.Graphics.DrawLine(Pens.Black, start_left, line, 220 + 50 * publicSubsNFunctions.grades.Length, line);
            left_margin += 120;
            line += 3;
            e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), publicSubsNFunctions.other_font, Brushes.Black, start_left + 5, line);
            for (int k = 0, loopTo13 = publicSubsNFunctions.grades.Length - 1; k <= loopTo13; k++)
            {
                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 5, line);
                left_margin += 30;
            }

            line += publicSubsNFunctions.other_font.Height + 5;
            left_margin = start_left;
            for (int k = 0, loopTo14 = publicSubsNFunctions.streams.Length - 1; k <= loopTo14; k++)
            {
                e.Graphics.DrawString(publicSubsNFunctions.streams[k], publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 5, line);
                for (int i = 0, loopTo15 = publicSubsNFunctions.grades.Length - 1; i <= loopTo15; i++)
                {
                    if (i == 0)
                    {
                        left_margin += 120;
                    }
                    else
                    {
                        left_margin += 30;
                    }

                    e.Graphics.DrawString(count_grades(Conversions.ToString(publicSubsNFunctions.grades[i]), publicSubsNFunctions.streams[k]).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 5, line);
                }

                e.Graphics.DrawLine(Pens.Black, start_left, line - 3, left_margin + 30, line - 3);
                line += publicSubsNFunctions.other_font.Height + 5;
                left_margin = start_left;
            }

            e.Graphics.DrawLine(Pens.Black, start_left, line, 220 + 30 * publicSubsNFunctions.grades.Length, line);
            left_margin = start_left;
            for (int k = 0, loopTo16 = publicSubsNFunctions.grades.Length + 1; k <= loopTo16; k++)
            {
                e.Graphics.DrawLine(Pens.Black, left_margin, topline, left_margin, line);
                if (k == 0)
                {
                    left_margin += 120;
                }
                else
                {
                    left_margin += 30;
                }
            }

            line += 30;
            left_margin = start_left;
            e.Graphics.DrawString("   SE    = SUBJECT ENTRIES		STR     = STREAM" + Constants.vbNewLine + "   TP	= TOTAL POINTS			S.P     = STREAM POSITION" + Constants.vbNewLine + "   MP	= MEAN POINTS			O.P     = OVERALL (CLASS) POSITION" + Constants.vbNewLine + "   TM	= TOTAL MARKS			VAP     = VALUE ADDED PROGRESS (DEVIATION)", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 100, line);
            start_from = 0;
        }

        private void print_report2(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            int line = 20;
            int left_margin = 40;
            int right_margin = 1100;
            int count = 0;
            float CenterPage;
            float max_height;
            if (publicSubsNFunctions.IsPrimary())
            {
                max_height = 1050f;
            }
            else
            {
                max_height = 750f;
            }

            if (start_from == 0)
            {
                try
                {
                    e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\photos_parent_guardians\" + "schoolLogo" + ".jpg"), left_margin + 10, line, 90, 90);
                    // e.Graphics.DrawImage(Image.FromFile(logoPath), left_margin + 10, line, 90, 90)
                    line += 15;
                }
                catch (Exception ex)
                {
                    Timer1.Enabled = false;
                    if (!mode_view)
                    {
                        Timer1.Enabled = true;
                    }
                }

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

                if (publicSubsNFunctions.mode)
                {
                    publicSubsNFunctions.exam_name = null;
                    for (int k = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo; k++)
                    {
                        if (k > 0)
                        {
                            publicSubsNFunctions.exam_name += "/";
                        }

                        publicSubsNFunctions.exam_name = Conversions.ToString(publicSubsNFunctions.exam_name + publicSubsNFunctions.exam_names[k]);
                    }
                }

                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper() + " MERIT LIST FOR " + publicSubsNFunctions.exam_name + " EXAM, TERM " + publicSubsNFunctions.tm + " " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font).Width / 2f);
                e.Graphics.DrawString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper() + " MERIT LIST FOR " + publicSubsNFunctions.exam_name + " EXAM, TERM " + publicSubsNFunctions.tm + " " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
                line += publicSubsNFunctions.other_font.Height + 5;
            }

            line += 10;
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
            line += 10;
            int topline = line;
            if (start_from < dgvEnterMarks.Rows.Count)
            {
                for (int col = 0, loopTo1 = dgvEnterMarks.Columns.Count - 1; col <= loopTo1; col++)
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
                                e.Graphics.DrawString(dgvEnterMarks.Columns[col].HeaderText.Substring(0, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                            }
                            catch (Exception ex)
                            {
                                e.Graphics.DrawString(dgvEnterMarks.Columns[col].HeaderText, publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                            }
                        }

                        count += 1;
                        if (count == 2)
                        {
                            left_margin += 200;
                        }
                        else if (publicSubsNFunctions.IsPrimary())
                        {
                            left_margin += 35;
                        }
                        else
                        {
                            left_margin += 40;
                        }
                    }
                }

                line += 10;
            }

            for (int row = start_from, loopTo2 = dgvEnterMarks.Rows.Count - 1; row <= loopTo2; row++)
            {
                line += 2;
                if (row == dgvEnterMarks.Rows.Count - 4)
                {
                    line += 10;
                }

                if (line >= max_height & row < dgvEnterMarks.Rows.Count - 1)
                {
                    count = 0;
                    line += 5;
                    e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line);
                    left_margin = 40;
                    for (int k = 0, loopTo3 = dgvEnterMarks.Columns.Count - 1; k <= loopTo3; k++)
                    {
                        if (dgvEnterMarks.Columns[k].Visible)
                        {
                            if (k == 0)
                            {
                                e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline);
                            }
                            else
                            {
                                e.Graphics.DrawLine(Pens.Black, left_margin - 5, line, left_margin - 5, topline);
                            }

                            count += 1;
                            if (count == 2)
                            {
                                left_margin += 200;
                            }
                            else if (publicSubsNFunctions.IsPrimary())
                            {
                                left_margin += 35;
                            }
                            else
                            {
                                left_margin += 40;
                            }
                        }
                    }

                    e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline);
                    e.HasMorePages = true;
                    start_from = row;
                    return;
                }

                left_margin = 40;
                count = 0;
                for (int col = 0, loopTo4 = dgvEnterMarks.Columns.Count - 1; col <= loopTo4; col++)
                {
                    if (dgvEnterMarks.Columns[col].Visible)
                    {
                        if (dgvEnterMarks.Columns[col].Name == "str_class")
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks["str_class", row].Value, null, false)))
                            {
                                if (dgvEnterMarks["str_class", row].Value.ToString().Length > 3)
                                {
                                    e.Graphics.DrawString(dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value.ToString().Substring(0, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                                }
                            }
                        }
                        else if (dgvEnterMarks.Columns[col].Name == "INDEX")
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks["INDEX", row].Value, null, false)))
                            {
                                if (dgvEnterMarks["INDEX", row].Value.ToString().Length > 3)
                                {
                                    e.Graphics.DrawString(dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value.ToString().Substring(dgvEnterMarks["INDEX", row].Value.ToString().Length - 3, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                                }
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                        }

                        count += 1;
                        if (count == 2)
                        {
                            left_margin += 200;
                        }
                        else if (publicSubsNFunctions.IsPrimary())
                        {
                            left_margin += 35;
                        }
                        else
                        {
                            left_margin += 40;
                        }
                    }
                }

                line += 2;
                if (row < dgvEnterMarks.Rows.Count - 4)
                {
                    e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line);
                }

                line += 10;
            }

            if (start_from < dgvEnterMarks.Rows.Count)
            {
                count = 0;
                line += 5;
                e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line);
                left_margin = 40;
                for (int k = 0, loopTo5 = dgvEnterMarks.Columns.Count - 1; k <= loopTo5; k++)
                {
                    if (dgvEnterMarks.Columns[k].Visible)
                    {
                        if (k == 0)
                        {
                            e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline);
                        }
                        else
                        {
                            e.Graphics.DrawLine(Pens.Black, left_margin - 5, line, left_margin - 5, topline);
                        }

                        count += 1;
                        if (count == 2)
                        {
                            left_margin += 200;
                        }
                        else if (publicSubsNFunctions.IsPrimary())
                        {
                            left_margin += 35;
                        }
                        else
                        {
                            left_margin += 40;
                        }
                    }
                }

                e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, topline);
            }

            line += 10;
            if (line + 60 >= max_height)
            {
                start_from = dgvEnterMarks.Rows.Count;
                e.HasMorePages = true;
                return;
            }

            line += 20;
            left_margin = 100;
            get_streams(publicSubsNFunctions.class_form);
            if (line + 20 * publicSubsNFunctions.grades.Length + line + publicSubsNFunctions.other_font.Height * (publicSubsNFunctions.streams.Length + 1) > max_height + 60f)
            {
                start_from = dgvEnterMarks.Rows.Count;
                e.HasMorePages = true;
                return;
            }

            topline = line;
            for (int k = 0, loopTo6 = publicSubsNFunctions.grades.Length - 1; k <= loopTo6; k++)
            {
                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.other_font, Brushes.Black, left_margin, line - 8);
                e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin - 100, line);
                line += 20;
            }

            e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin - 100, line);
            int graphtop = topline;
            left_margin += 30;
            for (int k = 0, loopTo7 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo7; k++)
            {
                graphtop = topline;
                for (int g = 0, loopTo8 = publicSubsNFunctions.grades.Length - 1; g <= loopTo8; g++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks[publicSubsNFunctions.subjname[k].ToString(), dgvEnterMarks.Rows.Count - 1].Value, publicSubsNFunctions.grades[g], false)))
                    {
                        var rect = new Rectangle(left_margin + k * 10, graphtop, 20, line - graphtop);
                        e.Graphics.FillRectangle(Brushes.Black, rect);
                    }
                    else
                    {
                        graphtop += 20;
                    }
                }

                left_margin += 25;
            }

            line += 10;
            left_margin = 100;
            left_margin += 30;
            for (int k = 0, loopTo9 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo9; k++)
            {
                if (publicSubsNFunctions.subjabb[k].ToString().Length >= 3)
                {
                    e.Graphics.DrawString(publicSubsNFunctions.subjabb[k].ToString().Substring(0, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                }
                else
                {
                    e.Graphics.DrawString(publicSubsNFunctions.subjabb[k].ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                }

                left_margin += 35;
            }

            line += 30;
            int start_left = 100;
            left_margin = start_left;
            topline = line;
            e.Graphics.DrawLine(Pens.Black, start_left, line, 220 + 50 * publicSubsNFunctions.grades.Length, line);
            left_margin += 120;
            line += 3;
            e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), publicSubsNFunctions.other_font, Brushes.Black, start_left + 5, line);
            for (int k = 0, loopTo10 = publicSubsNFunctions.grades.Length - 1; k <= loopTo10; k++)
            {
                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 5, line);
                left_margin += 30;
            }

            line += publicSubsNFunctions.other_font.Height + 5;
            left_margin = start_left;
            for (int k = 0, loopTo11 = publicSubsNFunctions.streams.Length - 1; k <= loopTo11; k++)
            {
                e.Graphics.DrawString(publicSubsNFunctions.streams[k], publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 5, line);
                for (int i = 0, loopTo12 = publicSubsNFunctions.grades.Length - 1; i <= loopTo12; i++)
                {
                    if (i == 0)
                    {
                        left_margin += 120;
                    }
                    else
                    {
                        left_margin += 30;
                    }

                    e.Graphics.DrawString(count_grades(Conversions.ToString(publicSubsNFunctions.grades[i]), publicSubsNFunctions.streams[k]).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 5, line);
                }

                e.Graphics.DrawLine(Pens.Black, start_left, line - 3, left_margin + 30, line - 3);
                line += publicSubsNFunctions.other_font.Height + 5;
                left_margin = start_left;
            }

            e.Graphics.DrawLine(Pens.Black, start_left, line, 220 + 30 * publicSubsNFunctions.grades.Length, line);
            left_margin = start_left;
            for (int k = 0, loopTo13 = publicSubsNFunctions.grades.Length + 1; k <= loopTo13; k++)
            {
                e.Graphics.DrawLine(Pens.Black, left_margin, topline, left_margin, line);
                if (k == 0)
                {
                    left_margin += 120;
                }
                else
                {
                    left_margin += 30;
                }
            }

            line += 30;
            left_margin = start_left;
            e.Graphics.DrawString("   SE	= SUBJECT ENTRIES					STR 	= STREAM" + Constants.vbNewLine + "   TP	= TOTAL POINTS					    S.P		= STREAM POSITION" + Constants.vbNewLine + "   MP	= MEAN POINTS					    O.P     = OVERALL (CLASS) POSITION" + Constants.vbNewLine + "   TM	= TOTAL MARKS					    VAP     = VALUE ADDED PROGRESS (DEVIATION)", publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            start_from = 0;
        }

        private int count_grades(string grade, string str)
        {
            int count_gradesRet = default;
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 4; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["MG", k].Value, grade, false), Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", k].Value, str, false))))
                {
                    count_gradesRet += 1;
                }
            }

            return count_gradesRet;
        }

        private void btnClassPerformance_Click(object sender, EventArgs e)
        {
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_report2();
            if (publicSubsNFunctions.IsPrimary())
            {
                print_document.DefaultPageSettings.Landscape = false;
            }
            else
            {
                print_document.DefaultPageSettings.Landscape = true;
            }

            Print_Preview.Document = print_document;
            Print_Preview.ShowDialog();
        }

        private void btnStreamPerformance_Click(object sender, EventArgs e)
        {
            Pbar.Visible = false;
            var frm2 = new frmFilter();
            frm2.ShowDialog();
            if (publicSubsNFunctions.cont)
            {
                var frm1 = new frmPrompt();
                frm1.ShowDialog();
            }
            else
            {
                return;
            }

            if (!publicSubsNFunctions.to_continue)
            {
                return;
            }

            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_report3();
            if (publicSubsNFunctions.IsPrimary())
            {
                print_document.DefaultPageSettings.Landscape = false;
            }
            else
            {
                print_document.DefaultPageSettings.Landscape = true;
            }

            Print_Preview.Document = print_document;
            Print_Preview.ShowDialog();
        }

        private bool print_reports = false;
        private bool mode_view = true;
        private void Button2_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.resetSchoolName();
            mode_view = true;
            if (publicSubsNFunctions.stream_mode)
            {
                publicSubsNFunctions.failure("Cannot Print Or View Report Form! Please Consider Analyzing Results For The Entire Class");
                return;
            }

            publicSubsNFunctions.cont = false;
            var frm = new frmDates();
            frm.ShowDialog();
            if (publicSubsNFunctions.cont)
            {
                if (dgvEnterMarks.SelectedRows.Count <= 0)
                {
                    publicSubsNFunctions.success("Please Select A Student To Preview");
                    return;
                }

                var i = default(int);
                // For i = 0 To dgvEnterMarks.SelectedRows.Count - 1
                student = dgvEnterMarks.SelectedRows[i].Index;
                to_row = student;
                var Print_Preview = new PrintPreviewDialog();
                var print_dialog = new PrintDialog();
                // print_dialog.ShowDialog()
                PrintDocument print_document = (PrintDocument)print_student_report();
                var margin = new Margins(10, 10, 10, 10);
                print_document.DefaultPageSettings.Landscape = false;
                print_document.DefaultPageSettings.Margins = margin;
                print_document.DocumentName = Conversions.ToString(Operators.ConcatenateObject(publicSubsNFunctions.get_name(Conversions.ToString(dgvEnterMarks["StudentName", student].Value)), "_Report_Form"));
                printpreview.Document = print_document;
                printpreview.ShowDialog();
            }
            // Next
            else
            {
                return;
            }

            publicSubsNFunctions.cont = false;
        }

        private object print_student_report()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_report;
            return print_document;
        }

        private object print_subject_report()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_subject;
            return print_document;
        }

        private double amt;
        private object get_fee_bal(string adm)
        {
            double total = 0d;
            string argq = "SELECT COALESCE(balance, 0) as balance FROM stud_balance_temp_table WHERE admin_no ='" + adm + "'";
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    while (publicSubsNFunctions.dbreader.Read())
                        total = Conversions.ToDouble(total + publicSubsNFunctions.dbreader["balance"]);
                }

                publicSubsNFunctions.dbreader.Close();
            }

            return total.ToString("n2");
        }

        private void get_fees()
        {
            string term = null;
            int yr_ = publicSubsNFunctions.yr;
            if (publicSubsNFunctions.tm == "I")
            {
                term = "II";
            }
            else if (publicSubsNFunctions.tm == "II")
            {
                term = "III";
            }
            else if (publicSubsNFunctions.tm == "III")
            {
                term = "I";
                yr_ = publicSubsNFunctions.yr + 1;
            }

            amt = 0d;
            // qread("SELECT amount FROM fee_structure WHERE class='" & ret_name(class_form) & "' AND term='" & term & "' AND year='" & yr_ & "' AND category=(SELECT category FROM students WHERE ADMNo='" & escape_string(dgvEnterMarks.Item("ADMNo", student).Value) & "')")
            // While dbreader.Read()
            // amt += dbreader("amount")
            // End While
            // todo get fee balance 2
        }

        private object get_balance(int no)
        {
            object get_balanceRet = default;
            // qread("SELECT Amount FROM accounts_students WHERE ADMNo='" & no & "'")
            // Try
            // dbreader.Read()
            // get_balance = dbreader("Amount")
            // Catch ex As Exception
            // qwrite("INSERT INTO accounts_students VALUES('" & no & "','0','True')")
            // get_balance = 0
            // End Try
            // dbreader.Close()
            // todo get fee balance 2
            get_balanceRet = 0;
            return get_balanceRet;
        }

        private object dormitory(string adm)
        {
            object dormitoryRet = default;
            string argq = "SELECT dormitory FROM students WHERE admin_no ='" + adm + "'";
            publicSubsNFunctions.qread(ref argq);
            try
            {
                publicSubsNFunctions.dbreader.Read();
                dormitoryRet = publicSubsNFunctions.dbreader["dormitory"];
            }
            catch (Exception ex)
            {
                dormitoryRet = string.Empty;
            }

            return dormitoryRet;
        }

        private object no_of_subjects(string adm)
        {
            object no_of_subjectsRet = default;
            no_of_subjectsRet = 0;
            string argq = "SELECT * FROM `subjects_done` WHERE ADMNo='" + adm + "'";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                {
                    try
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k]), "Yes", false)))
                        {
                            Array.Resize(ref subjects_done, Conversions.ToInteger(no_of_subjectsRet + 1));
                            Array.Resize(ref subjects_done_name, Conversions.ToInteger(no_of_subjectsRet + 1));
                            Array.Resize(ref subjects_done_abb, Conversions.ToInteger(no_of_subjectsRet + 1));
                            subjects_done[Conversions.ToInteger(no_of_subjectsRet)] = Conversions.ToString(publicSubsNFunctions.subjects[k]);
                            subjects_done_abb[Conversions.ToInteger(no_of_subjectsRet)] = Conversions.ToString(publicSubsNFunctions.subjabb[k]);
                            subjects_done_name[Conversions.ToInteger(no_of_subjectsRet)] = Conversions.ToString(publicSubsNFunctions.subjname[k]);
                            no_of_subjectsRet += 1;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                publicSubsNFunctions.dbreader.Close();
            }
            else
            {
                publicSubsNFunctions.qwrite("INSERT INTO `subjects_done`(ADMNo) VALUES('" + adm + "')");
                subjects_done = new string[publicSubsNFunctions.subjabb.Length];
                subjects_done_name = new string[publicSubsNFunctions.subjabb.Length];
                subjects_done_abb = new string[publicSubsNFunctions.subjabb.Length];
                for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                {
                    subjects_done[Conversions.ToInteger(no_of_subjectsRet)] = Conversions.ToString(publicSubsNFunctions.subjects[k]);
                    subjects_done_abb[Conversions.ToInteger(no_of_subjectsRet)] = Conversions.ToString(publicSubsNFunctions.subjabb[k]);
                    subjects_done_name[Conversions.ToInteger(no_of_subjectsRet)] = Conversions.ToString(publicSubsNFunctions.subjname[k]);
                    no_of_subjectsRet += 1;
                }

                no_of_subjectsRet = publicSubsNFunctions.subjabb.Length;
            }

            return no_of_subjectsRet;
        }

        private string[] subjects_done, subjects_done_abb, subjects_done_name;
        private object get_no_of_split_subjects(int index)
        {
            string argq = "SELECT * FROM `split_subjects` WHERE `subject` = '" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.subjects[index])) + "' AND `class` = '" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "';";
            publicSubsNFunctions.qread(ref argq);
            return publicSubsNFunctions.dbreader.RecordsAffected;
        }

        private int[] subject_splits = new int[publicSubsNFunctions.subjects.Length];
        private bool selected_print = false;
        private double total_fees;
        private void print_report(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            total_fees = 0d;
            int avg = 415;
            int subj_pos = 530;
            int remarks = 560;
            int teacher = 695;
            int pt = 495;
            int mg = 455;
            int exam_width = 50;
            int line, i, j;
            float CenterPage;
            int left_margin = 80;
            int right_margin = 800;
            int topline = 175;
            string perf = null;
            Pen Graphpen;
            Brush Avgpen, RemarksPen, Teacherpen, PointPen, Subjectpen, Mgpen;
            if (report.color == true)
            {
                Graphpen = new Pen(Color.Red, 2f);
                Avgpen = Brushes.Blue;
                RemarksPen = Brushes.Red;
                Teacherpen = Brushes.Blue;
                Subjectpen = Brushes.Black;
                Mgpen = Brushes.Red;
                PointPen = Brushes.Blue;
            }
            else
            {
                Graphpen = new Pen(Color.Black, 2f);
                Avgpen = Brushes.Black;
                PointPen = Brushes.Black;
                RemarksPen = Brushes.Black;
                Teacherpen = Brushes.Black;
                Subjectpen = Brushes.Black;
                Mgpen = Brushes.Black;
            }

            try
            {
                exam_width = (int)Math.Round((avg - (left_margin + 210) + 70) / (double)publicSubsNFunctions.tables.Length);
            }
            catch (Exception ex)
            {
                exam_width = avg - (left_margin + 210);
            }

            line = 15;
            if (report.school_logo)
            {
                // If True Then
                try
                {
                    e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\photos_parent_guardians\" + "schoolLogo" + ".jpg"), left_margin + 5, topline - 170, 90, 90);
                }
                catch (Exception ex)
                {
                    Timer1.Enabled = false;
                }
            }

            if (report.student_photo)
            {
                try
                {
                    e.Graphics.DrawImage(Image.FromFile(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.path + @"\photos_parent_guardians\", dgvEnterMarks["ADMNo", student].Value), ".jpg"))), right_margin - 100, topline - 170, 100, 100);
                }
                catch (Exception ex)
                {
                    Timer1.Enabled = false;
                }
            }

            if ((publicSubsNFunctions.S_NAME ?? "") != (string.Empty ?? ""))
            {
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font).Width / 2f);
                e.Graphics.DrawString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font, Avgpen, CenterPage, line);
                line += publicSubsNFunctions.header_font.Height + 2;
            }

            if ((publicSubsNFunctions.S_ADDRESS ?? "") != (string.Empty ?? ""))
            {
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("P.O. BOX " + publicSubsNFunctions.S_ADDRESS.ToUpper() + ", " + publicSubsNFunctions.S_LOCATION.ToUpper(), publicSubsNFunctions.other_font).Width / 2f);
                e.Graphics.DrawString("P.O. BOX " + publicSubsNFunctions.S_ADDRESS.ToUpper() + ", " + publicSubsNFunctions.S_LOCATION.ToUpper(), publicSubsNFunctions.other_font, Avgpen, CenterPage, line);
                line += publicSubsNFunctions.other_font.Height + 5;
            }

            if ((publicSubsNFunctions.S_PHONE ?? "") != (string.Empty ?? ""))
            {
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("TELEPHONE: " + publicSubsNFunctions.S_PHONE, publicSubsNFunctions.other_font).Width / 2f);
                e.Graphics.DrawString("TELEPHONE: " + publicSubsNFunctions.S_PHONE, publicSubsNFunctions.other_font, Avgpen, CenterPage, line);
                line += publicSubsNFunctions.other_font.Height + 5;
            }

            // If S_EMAIL <> "" Then
            // CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("EMAIL ADDRESS: " & S_EMAIL, other_font).Width / 2)
            // e.Graphics.DrawString("EMAIL ADDRESS: " & S_EMAIL, other_font, Avgpen, CenterPage, line)
            // line += other_font.Height + 5
            // End If
            line -= 5;
            if (print_reports & !selected_print)
            {
                while (Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks["str_class", student].Value, publicSubsNFunctions.class_stream, false))
                    student += 1;
            }

            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("STUDENT PROGRESS REPORT", publicSubsNFunctions.header_font).Width / 2f);
            e.Graphics.DrawString("STUDENT PROGRESS REPORT", publicSubsNFunctions.header_font, Avgpen, CenterPage, line + 5);
            line += publicSubsNFunctions.header_font.Height + 10;
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
            line += 10;
            e.Graphics.DrawString("NAME OF STUDENT:_______________________________________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["StudentName", student].Value), publicSubsNFunctions.medium_larger, Avgpen, left_margin + 150, line - 8);
            e.Graphics.DrawString("ADMISSION NUMBER:_______", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 500, line);
            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value), publicSubsNFunctions.medium_larger, Avgpen, left_margin + 660, line - 8);
            line += 25;
            e.Graphics.DrawString("CLASS:_________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
            e.Graphics.DrawString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper(), publicSubsNFunctions.other_font, Avgpen, left_margin + 60, line - 3);
            e.Graphics.DrawString("STREAM:_________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 150, line);
            e.Graphics.DrawString(dgvEnterMarks["str_class", student].Value.ToString().ToUpper(), publicSubsNFunctions.other_font, Avgpen, left_margin + 220, line - 3);
            e.Graphics.DrawString("TERM:_____", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 300, line);
            e.Graphics.DrawString(publicSubsNFunctions.tm, publicSubsNFunctions.other_font, Avgpen, left_margin + 350, line - 2);
            e.Graphics.DrawString("YEAR:______", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 400, line);
            e.Graphics.DrawString(publicSubsNFunctions.yr.ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + 450, line - 3);
            e.Graphics.DrawString("DORMITORY:_____________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 500, line);
            e.Graphics.DrawString(dormitory(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value)).ToString().ToUpper(), publicSubsNFunctions.other_font, Avgpen, left_margin + 600, line - 3);
            line = topline;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
            e.Graphics.DrawString("SUBJECT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
            j = 210;
            var italisized_font = new Font(publicSubsNFunctions.biggerfont, 7f, FontStyle.Italic);
            try
            {
                if (publicSubsNFunctions.tables.Length > 1)
                {
                    var loopTo = publicSubsNFunctions.tables.Length - 1;
                    for (i = 0; i <= loopTo; i++)
                    {
                        e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.exam_names[i].ToUpper.Substring((object)0, (object)4), "/"), publicSubsNFunctions.total_mark[i]), string.Empty)), italisized_font, Brushes.Black, (float)(left_margin + j + exam_width / 2d - 20d), line + 3);
                        j += exam_width;
                    }
                }
                else
                {
                    publicSubsNFunctions.marks = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                    e.Graphics.DrawString(publicSubsNFunctions.exam_name.ToUpper().ToString().Substring(0, 4) + "/" + publicSubsNFunctions.marks + string.Empty, italisized_font, Brushes.Black, (float)(left_margin + j + exam_width / 2d - 20d), line + 3);
                }
            }
            catch (Exception ex)
            {
                // marks = get_total_mark(exam_name, tm)
                // e.Graphics.DrawString(exam_name.ToUpper.ToString.Substring(0, 4) & "/" & marks & "", italisized_font, Brushes.Black, left_margin + j + (exam_width / 2) - 20, line + 3)
            }

            e.Graphics.DrawString("TOT", publicSubsNFunctions.other_font, Avgpen, left_margin + avg, line);
            e.Graphics.DrawString("PTS", publicSubsNFunctions.other_font, PointPen, left_margin + pt, line);
            e.Graphics.DrawString("M.G.", publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 3, line);
            e.Graphics.DrawString("SSP", publicSubsNFunctions.other_font, Mgpen, left_margin + subj_pos, line);
            e.Graphics.DrawString("REMARK", publicSubsNFunctions.other_font, RemarksPen, left_margin + remarks, line);
            e.Graphics.DrawString("T.I", publicSubsNFunctions.other_font, Teacherpen, left_margin + teacher, line);
            line += 20;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
            double totals = default, totals_avg = default, totals_avg_cnt = default;
            int no = Conversions.ToInteger(no_of_subjects(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value)));
            if (chkSplit.Checked)
            {
                for (int k = 0, loopTo1 = publicSubsNFunctions.subjects.Length - 1; k <= loopTo1; k++)
                    subject_splits[k] = Conversions.ToInteger(get_no_of_split_subjects(k));
            }

            if (!publicSubsNFunctions.mode)
            {
                int total_mark = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                if (publicSubsNFunctions.grade)
                {
                    for (int k = 0, loopTo2 = subjects_done.Length - 1; k <= loopTo2; k++)
                    {
                        totals = Conversions.ToDouble(totals + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100));
                        totals_avg = Conversions.ToDouble(totals_avg + dgvEnterMarks[subjects_done_name[k], student].Value);
                        totals_avg_cnt += 1d;
                        e.Graphics.DrawString(Conversions.ToInteger(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)).ToString(), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                        e.Graphics.DrawString(Conversions.ToInteger(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)).ToString(), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + avg + 5, line);
                        line += 20;
                    }
                }
                else
                {
                    for (int k = 0, loopTo3 = subjects_done.Length - 1; k <= loopTo3; k++)
                    {
                        if (chkSplit.Checked)
                        {
                            get_split_subjects(subjects_done[k], true);
                            for (int c = 0, loopTo4 = splits.Length - 1; c <= loopTo4; c++)
                            {
                                e.Graphics.DrawString(Conversions.ToString(splits[c]), publicSubsNFunctions.other_font, Subjectpen, left_margin + 2, line);
                                if (report.color)
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks.Item(splits_name[c], student).Value), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks.Item(splits_name[c], student).Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 220, line);
                                }

                                line += 20;
                            }
                        }

                        if (dgvEnterMarks[subjects_done_name[k], student].Value.ToString() != "-")
                        {
                            if (Information.IsNumeric(dgvEnterMarks[subjects_done_name[k], student].Value))
                            {
                                totals = Conversions.ToDouble(totals + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100));
                                totals_avg = Conversions.ToDouble(totals_avg + dgvEnterMarks[subjects_done_name[k], student].Value);
                                if (report.color)
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 220, line);
                                }

                                e.Graphics.DrawString(Conversions.ToInteger(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)).ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                                if (Information.IsNumeric(dgvEnterMarks[subjects_done_name[k], student].Value))
                                {
                                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)), radSubject.Checked, subjects_done_abb[k])))), publicSubsNFunctions.other_font, Brushes.Black, left_margin + pt, line);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt, line);
                                }
                            }

                            totals_avg_cnt += 1d;
                        }
                        else
                        {
                            if (report.color)
                            {
                                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                            }
                            else
                            {
                                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 220, line);
                            }

                            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                        }

                        line += 20;
                    }
                }

                e.Graphics.DrawString(totals_avg.ToString(), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                e.Graphics.DrawString(((int)Math.Round(totals)).ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["TP", student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 5, line);
                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 5, line);
                line = topline + 20;
                for (int k = 0, loopTo5 = subjects_done.Length - 1; k <= loopTo5; k++)
                {
                    if (chkSplit.Checked)
                    {
                        for (int s = 0, loopTo6 = Conversions.ToInteger(Operators.SubtractObject(no_of_splits(subjects_done[k]), 1)); s <= loopTo6; s++)
                            line += 20;
                    }

                    if (Information.IsNumeric(dgvEnterMarks[subjects_done_name[k], student].Value))
                    {
                        e.Graphics.DrawString(publicSubsNFunctions.get_comment(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)), radSubject.Checked, subjects_done_abb[k]).ToString(), radSubject.Checked, subjects_done_abb[k]), italisized_font, RemarksPen, left_margin + remarks, line);
                    }
                    else
                    {
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), italisized_font, RemarksPen, left_margin + remarks, line);
                    }

                    if (publicSubsNFunctions.grade)
                    {
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg, line);
                    }
                    else if (Information.IsNumeric(dgvEnterMarks[subjects_done_name[k], student].Value))
                    {
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)), radSubject.Checked, subjects_done_abb[k])), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 7, line);
                    }
                    else
                    {
                        e.Graphics.DrawString("-", publicSubsNFunctions.other_font, Mgpen, left_margin + mg, line);
                    }

                    line += 20;
                }
            }
            else
            {
                j = 210;
                double total_;
                double out_of;
                var loopTo7 = publicSubsNFunctions.tables.Length - 1;
                for (i = 0; i <= loopTo7; i++)
                {
                    publicSubsNFunctions.marks = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(Conversions.ToString(publicSubsNFunctions.exam_names[i]), publicSubsNFunctions.tm));
                    total_ = 0d;
                    line = topline + 20;
                    int tot_cnt = 0;
                    string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE ADMNo='", dgvEnterMarks["ADMNo", student].Value), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.tables[i])), "' AND Term='"), publicSubsNFunctions.tms[i]), "' AND Year='"), publicSubsNFunctions.yrs[i]), "'"));
                    if (publicSubsNFunctions.qread(ref argq1))
                    {
                        tot_cnt = 0;
                        tot_cnt = 0;
                        publicSubsNFunctions.dbreader.Read();
                        string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `exam_split_subject_results`  WHERE ADMNo='", dgvEnterMarks["ADMNo", student].Value), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.tables[i])), "' AND Term='"), publicSubsNFunctions.tms[i]), "' AND Year='"), publicSubsNFunctions.yrs[i]), "'"));
                        publicSubsNFunctions.qread(ref argq, 1);
                        if (publicSubsNFunctions.dbreader1.RecordsAffected > 0)
                        {
                            publicSubsNFunctions.dbreader1.Read();
                        }

                        for (int k = 0, loopTo8 = subjects_done.Length - 1; k <= loopTo8; k++)
                        {
                            if (chkSplit.Checked)
                            {
                                get_split_subjects(subjects_done[k], true);
                                for (int c = 0, loopTo9 = splits.Length - 1; c <= loopTo9; c++)
                                {
                                    e.Graphics.DrawString(Conversions.ToString(splits[c]), publicSubsNFunctions.other_font, Subjectpen, left_margin + 2, line);
                                    if (publicSubsNFunctions.dbreader1.RecordsAffected > 0)
                                    {
                                        if (report.color)
                                        {
                                            e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.dbreader1(Operators.ConcatenateObject(publicSubsNFunctions.class_form + "_", splits_name[c]))), publicSubsNFunctions.other_font, Brushes.DarkBlue, (float)(left_margin + j + exam_width / 2d - 10d), line);
                                        }
                                        else
                                        {
                                            e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.dbreader1(Operators.ConcatenateObject(publicSubsNFunctions.class_form + "_", splits_name[c]))), publicSubsNFunctions.other_font, Brushes.Black, (float)(left_margin + j + exam_width / 2d - 10d), line);
                                        }
                                    }

                                    line += 20;
                                }
                            }

                            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader[subjects_done_abb[k]]))
                                {
                                    out_of = publicSubsNFunctions.SubjectOutOf(subjects_done_abb[k], publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_names[i], publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form), dgvEnterMarks["str_class", student].Value, 2);
                                    e.Graphics.DrawString(Conversions.ToInteger(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[subjects_done_abb[k]], out_of), publicSubsNFunctions.marks)).ToString(), publicSubsNFunctions.other_font, Brushes.Black, (float)(left_margin + j + exam_width / 2d - 10d), line);
                                    total_ = Conversions.ToDouble(total_ + publicSubsNFunctions.dbreader[subjects_done_abb[k]]);
                                    tot_cnt += 1;
                                }
                            }

                            line += 20;
                        }

                        if (chkMode.Checked)
                        {
                            var tot = default(double);
                            for (int k = 0, loopTo10 = subjects_7.Length - 1; k <= loopTo10; k++)
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(subjects_7[k][8], dgvEnterMarks["ADMNo", student].Value.ToString(), false)))
                                {
                                    tot = 0d;
                                    for (int c = 0, loopTo11 = subjects_7[k].Length - 2; c <= loopTo11; c++)
                                    {
                                        try
                                        {
                                            if (Information.IsNumeric(publicSubsNFunctions.dbreader[subjects_7[k][c].ToString()]))
                                            {
                                                tot = Conversions.ToDouble(tot + publicSubsNFunctions.dbreader[subjects_7[k][c].ToString()]);
                                                tot_cnt += 1;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }

                                    break;
                                }
                            }

                            e.Graphics.DrawString(tot.ToString(), publicSubsNFunctions.other_font, Brushes.Black, left_margin + j + 2, line);
                        }
                        else
                        {
                            e.Graphics.DrawString(total_.ToString(), publicSubsNFunctions.other_font, Brushes.Black, left_margin + j + 2, line);
                        }

                        j += exam_width;
                        line = 330;
                    }
                }

                line = topline + 20;
                for (int k = 0, loopTo12 = subjects_done.Length - 1; k <= loopTo12; k++)
                {
                    if (chkSplit.Checked)
                    {
                        for (int s = 0, loopTo13 = Conversions.ToInteger(Operators.SubtractObject(no_of_splits(subjects_done[k]), 1)); s <= loopTo13; s++)
                            line += 20;
                    }

                    if (Information.IsNumeric(dgvEnterMarks[subjects_done_name[k], student].Value))
                    {
                        e.Graphics.DrawString(publicSubsNFunctions.get_comment(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[subjects_done_name[k], student].Value), radSubject.Checked, subjects_done_abb[k]).ToString(), radSubject.Checked, subjects_done_abb[k]), italisized_font, RemarksPen, left_margin + remarks, line);
                    }
                    else
                    {
                        e.Graphics.DrawString(string.Empty, italisized_font, RemarksPen, left_margin + remarks, line);
                    }

                    if (publicSubsNFunctions.grade)
                    {
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.fix_point(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value))), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 4, line);
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 4, line);
                    }
                    else if (Information.IsNumeric(dgvEnterMarks[subjects_done_name[k], student].Value))
                    {
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[subjects_done_name[k], student].Value), radSubject.Checked, subjects_done_abb[k])))), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 4, line);
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[subjects_done_name[k], student].Value), radSubject.Checked, subjects_done_abb[k])), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 4, line);
                    }

                    line += 20;
                }

                line = topline + 20;
                if (publicSubsNFunctions.grade)
                {
                    for (int k = 0, loopTo14 = subjects_done.Length - 1; k <= loopTo14; k++)
                    {
                        totals = Conversions.ToDouble(totals + dgvEnterMarks[subjects_done_name[k], student].Value);
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                        line += 20;
                    }

                    e.Graphics.DrawString(totals.ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["TP", student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 5, line);
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 5, line);
                }
                else
                {
                    for (int k = 0, loopTo15 = subjects_done.Length - 1; k <= loopTo15; k++)
                    {
                        if (chkSplit.Checked)
                        {
                            for (int s = 0, loopTo16 = Conversions.ToInteger(Operators.SubtractObject(no_of_splits(subjects_done[k]), 1)); s <= loopTo16; s++)
                                line += 20;
                        }

                        if (Information.IsNumeric(dgvEnterMarks[subjects_done_name[k], student].Value))
                        {
                            totals = Conversions.ToDouble(totals + dgvEnterMarks[subjects_done_name[k], student].Value);
                        }

                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                        line += 20;
                    }

                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["Total", student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["TP", student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 5, line);
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 5, line);
                }
            }

            line = topline + 20;
            for (int k = 0, loopTo17 = subjects_done.Length - 1; k <= loopTo17; k++)
            {
                if (chkSplit.Checked)
                {
                    for (int s = 0, loopTo18 = Conversions.ToInteger(Operators.SubtractObject(no_of_splits(subjects_done[k]), 1)); s <= loopTo18; s++)
                    {
                        line += 20;
                        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
                    }
                }

                if (subjects_done[k].Length >= 22)
                {
                    e.Graphics.DrawString(subjects_done[k].Substring(0, 22), publicSubsNFunctions.other_font, Subjectpen, left_margin + 2, line);
                }
                else
                {
                    e.Graphics.DrawString(subjects_done[k], publicSubsNFunctions.other_font, Subjectpen, left_margin + 2, line);
                }

                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subject_teacher(Conversions.ToString(dgvEnterMarks["str_class", student].Value), publicSubsNFunctions.class_form, publicSubsNFunctions.tm, publicSubsNFunctions.yr, subjects_done_abb[k])), publicSubsNFunctions.other_font, Teacherpen, left_margin + teacher, line);
                e.Graphics.DrawString(Conversions.ToString(subject_rank_only(subjects_done_name[k], Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), Conversions.ToString(dgvEnterMarks["str_class", student].Value))), publicSubsNFunctions.other_font, Mgpen, left_margin + subj_pos, line);
                line += 20;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
            }

            if (publicSubsNFunctions.grade)
            {
                e.Graphics.DrawString("MEAN GRADE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
            }
            else
            {
                e.Graphics.DrawString("TOTAL MARKS", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
            }

            line += 20;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline - 2, left_margin - 2, line);
            j = 210;
            try
            {
                var loopTo19 = publicSubsNFunctions.tables.Length - 1;
                for (i = 0; i <= loopTo19; i++)
                {
                    e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line);
                    j += exam_width;
                }
            }
            catch (Exception ex)
            {
                e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line);
            }

            e.Graphics.DrawLine(Pens.Black, left_margin + avg - 2, topline - 2, left_margin + avg - 2, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + pt - 2, topline - 2, left_margin + pt - 2, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + mg - 2, topline - 2, left_margin + mg - 2, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + subj_pos - 2, topline - 2, left_margin + subj_pos - 2, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + remarks - 2, topline - 2, left_margin + remarks - 2, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + teacher - 2, topline - 2, left_margin + teacher - 2, line);
            e.Graphics.DrawLine(Pens.Black, right_margin + 2, topline - 2, right_margin + 2, line);
            line += 10;
            int stream_out_of = 0;
            var loopTo20 = publicSubsNFunctions.streams.Length - 1;
            for (i = 0; i <= loopTo20; i++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", student].Value, publicSubsNFunctions.streams[i], false)))
                {
                    stream_out_of = stream_no[i];
                }
            }

            e.Graphics.DrawString("CLASS POSITION:______________", publicSubsNFunctions.other_font, Avgpen, left_margin + 2, line);
            e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks["Overall", student].Value, " Out Of "), dgvEnterMarks.Rows.Count - 4)), publicSubsNFunctions.other_font, RemarksPen, left_margin + 130, line - 2);
            e.Graphics.DrawString("STR. POSITION:_____________", publicSubsNFunctions.other_font, Avgpen, left_margin + 230, line);
            e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks["Position", student].Value, " Out Of "), stream_out_of - 1)), publicSubsNFunctions.other_font, RemarksPen, left_margin + 360, line - 2);
            e.Graphics.DrawString("M. GRADE:____", publicSubsNFunctions.other_font, Avgpen, left_margin + 470, line);
            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.other_font, RemarksPen, left_margin + 550, line - 2);
            e.Graphics.DrawString("M. POINTS:________", publicSubsNFunctions.other_font, Avgpen, left_margin + 590, line);
            if (Information.IsNumeric(dgvEnterMarks["MP", student].Value))
            {
                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MP", student].Value), publicSubsNFunctions.other_font, RemarksPen, left_margin + 675, line - 2);
            }
            else
            {
                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.other_font, RemarksPen, left_margin + 675, line - 2);
            }

            line += 25;
            int startline = line;
            publicSubsNFunctions.all_classes = publicSubsNFunctions.classes();
            int h_width = (int)Math.Round((right_margin - (left_margin + 50)) / (double)publicSubsNFunctions.all_classes.Length);
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
            e.Graphics.DrawString("CLASS", publicSubsNFunctions.smallfont, RemarksPen, left_margin + 20, line);
            e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin + 50, line + 20);
            e.Graphics.DrawString("TERM", publicSubsNFunctions.smallfont, RemarksPen, left_margin + 2, line + 9);
            line += 20;
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
            e.Graphics.DrawString("I", publicSubsNFunctions.other_font, Avgpen, left_margin + 20, line + 2);
            line += 20;
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
            e.Graphics.DrawString("II", publicSubsNFunctions.other_font, RemarksPen, left_margin + 20, line + 2);
            line += 20;
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
            e.Graphics.DrawString("III", publicSubsNFunctions.other_font, Avgpen, left_margin + 20, line + 2);
            line += 20;
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
            e.Graphics.DrawLine(Pens.Black, left_margin, startline, left_margin, line);
            int newline;
            int startyr = Conversions.ToInteger(Operators.SubtractObject(DateAndTime.Today.Year, publicSubsNFunctions.CurrentClass((string[])publicSubsNFunctions.all_classes, publicSubsNFunctions.class_form)));
            class_term[publicSubsNFunctions.all_classes.Length - 1] = new Point[3];
            class_term_data[publicSubsNFunctions.all_classes.Length - 1] = new bool[3];
            for (int k = 0, loopTo21 = publicSubsNFunctions.all_classes.Length - 1; k <= loopTo21; k++)
            {
                class_term[k] = new Point[3];
                class_term_data[k] = new bool[3];
                for (int count = 0; count <= 2; count++)
                {
                    class_term[k][count] = default;
                    class_term_data[k][count] = false;
                }
            }

            int class_from = left_margin + 50;
            for (int k = 0, loopTo22 = publicSubsNFunctions.all_classes.Length - 1; k <= loopTo22; k++)
            {
                newline = line - 60;
                e.Graphics.DrawLine(Pens.Black, class_from + h_width * k, startline, class_from + h_width * k, line);
                if (k % 2 == 0)
                {
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.all_classes[k].ToUpper), publicSubsNFunctions.other_font, Avgpen, class_from + h_width * k + 2, startline + 2);
                }
                else
                {
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.all_classes[k].ToUpper), publicSubsNFunctions.other_font, RemarksPen, class_from + h_width * k + 2, startline + 2);
                }

                e.Graphics.DrawString(get_class_performance_data("I", k.ToString(), startyr), publicSubsNFunctions.smallfont, RemarksPen, class_from + h_width * k + 2, newline + 2);
                newline += 20;
                e.Graphics.DrawString(get_class_performance_data("II", k.ToString(), startyr), publicSubsNFunctions.smallfont, RemarksPen, class_from + h_width * k + 2, newline + 2);
                newline += 20;
                e.Graphics.DrawString(get_class_performance_data("III", k.ToString(), startyr), publicSubsNFunctions.smallfont, RemarksPen, class_from + h_width * k + 2, newline + 2);
                newline += 20;
                startyr += 1;
            }

            e.Graphics.DrawLine(Pens.Black, right_margin, startline, right_margin, line);
            line += 5;
            if (publicSubsNFunctions.subject_ranking_table)
            {
                e.Graphics.DrawString("GRAPHICAL PROGRESS REPORT", publicSubsNFunctions.other_font, Avgpen, left_margin + 50, line);
                e.Graphics.DrawString("SUBJECT RANKING IN CLASS", publicSubsNFunctions.other_font, Avgpen, left_margin + 420, line);
            }
            else
            {
                e.Graphics.DrawString("GRAPHICAL PROGRESS REPORT", publicSubsNFunctions.other_font, Avgpen, left_margin + 200, line);
            }

            line += 20;
            startline = line;
            e.Graphics.DrawLine(Pens.Black, left_margin + 10, line, left_margin + 10, line + 185);
            zline = line + 183;
            int right_end;
            if (publicSubsNFunctions.subject_ranking_table)
            {
                right_end = (int)Math.Round((right_margin - left_margin) / 2d + 75d);
            }
            else
            {
                right_end = right_margin;
            }

            e.Graphics.DrawLine(Pens.Black, left_margin + 10, line + 185, right_end, line + 185);
            int ht = (int)Math.Round(280d / publicSubsNFunctions.grades.Length - 3d);
            int endline = line + 185;
            if (!publicSubsNFunctions.IsPrimary())
            {
                e.Graphics.DrawString("KCPE", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 3, endline);
                e.Graphics.DrawLine(Pens.Black, left_margin + 25, endline, left_margin + 25, startline);
                h_width = 20;
            }
            else
            {
                h_width = 0;
            }

            int increment;
            if (publicSubsNFunctions.subject_ranking_table)
            {
                increment = (int)Math.Round((right_margin - (left_margin + 50)) / 2d / publicSubsNFunctions.all_classes.Length);
            }
            else
            {
                increment = (int)Math.Round((right_margin - (left_margin + 50)) / (double)publicSubsNFunctions.all_classes.Length);
            }

            int inc = (int)Math.Round(increment / 3d);
            bool primary = publicSubsNFunctions.IsPrimary();
            for (int k = 0, loopTo23 = publicSubsNFunctions.all_classes.Length - 1; k <= loopTo23; k++)
            {
                e.Graphics.DrawLine(Pens.Black, left_margin + h_width + increment * (k + 1), startline, left_margin + h_width + increment * (k + 1), line + 185);
                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.all_classes[k]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + increment * k + 10, line + 195);
                for (int h = 0; h <= 2; h++)
                {
                    if (h == 0)
                    {
                        e.Graphics.DrawLine(Pens.Black, left_margin + h_width + inc * (h + 1) + increment * k, line + 185 - 5, left_margin + h_width + inc * (h + 1) + increment * k, line + 185);
                        if (!primary)
                        {
                            e.Graphics.DrawString("I", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + inc * (h + 1) + increment * k, line + 185);
                        }
                        else
                        {
                            e.Graphics.DrawString("I", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + inc * (h + 1) + increment * k - 20, line + 185);
                        }

                        class_term[k][0].X = (int)Math.Round(left_margin + h_width + inc * (h + 1) / 2d + increment * k);
                    }
                    else if (h == 1)
                    {
                        e.Graphics.DrawLine(Pens.Black, left_margin + h_width + inc * (h + 1) + increment * k, line + 185 - 5, left_margin + h_width + inc * (h + 1) + increment * k, line + 185);
                        if (!primary)
                        {
                            e.Graphics.DrawString("II", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + inc * (h + 1) + increment * k, line + 185);
                        }
                        else
                        {
                            e.Graphics.DrawString("II", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + inc * (h + 1) + increment * k - 20, line + 185);
                        }

                        class_term[k][1].X = class_term[k][0].X + inc;
                    }
                    else if (h == 2)
                    {
                        if (!primary)
                        {
                            e.Graphics.DrawString("III", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + inc * (h + 1) + increment * k, line + 185);
                        }
                        else
                        {
                            e.Graphics.DrawString("III", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + inc * (h + 1) + increment * k - 20, line + 185);
                        }

                        class_term[k][2].X = class_term[k][1].X + inc;
                    }
                }
            }

            Rectangle rect;
            if (publicSubsNFunctions.bar_graph)
            {
                if (report.color)
                {
                    for (int k = 0, loopTo24 = publicSubsNFunctions.all_classes.Length - 1; k <= loopTo24; k++)
                    {
                        for (int h = 0; h <= 2; h++)
                        {
                            if (class_term_data[k][h])
                            {
                                rect = new Rectangle(class_term[k][h].X - 8, class_term[k][h].Y, 20, endline - class_term[k][h].Y);
                                e.Graphics.FillRectangle(Brushes.Black, rect);
                            }
                        }
                    }
                }
                else
                {
                    for (int k = 0, loopTo25 = publicSubsNFunctions.all_classes.Length - 1; k <= loopTo25; k++)
                    {
                        for (int h = 0; h <= 2; h++)
                        {
                            if (class_term_data[k][h])
                            {
                                rect = new Rectangle(class_term[k][h].X - 8, class_term[k][h].Y, 20, endline - class_term[k][h].Y);
                                e.Graphics.FillRectangle(Brushes.Black, rect);
                            }
                        }
                    }
                }
            }
            else
            {
                var linePen = new Pen(Color.Black, 2f);
                for (int k = 0, loopTo26 = publicSubsNFunctions.all_classes.Length - 1; k <= loopTo26; k++)
                {
                    for (int h = 0; h <= 2; h++)
                    {
                        if (h == 0)
                        {
                            if (k > 0)
                            {
                                if (class_term_data[k][h] & class_term_data[k - 1][2])
                                {
                                    rect = new Rectangle(class_term[k][h].X - 4, class_term[k][h].Y - 4, 8, 8);
                                    e.Graphics.DrawEllipse(Pens.Black, rect);
                                    e.Graphics.FillEllipse(Brushes.Black, rect);
                                    rect = new Rectangle(class_term[k - 1][2].X - 4, class_term[k - 1][2].Y - 4, 8, 8);
                                    e.Graphics.DrawEllipse(Pens.Black, rect);
                                    e.Graphics.FillEllipse(Brushes.Black, rect);
                                    e.Graphics.DrawLine(linePen, class_term[k][h].X, class_term[k][h].Y, class_term[k - 1][2].X, class_term[k - 1][2].Y);
                                }
                            }
                        }
                        else if (class_term_data[k][h] & class_term_data[k][h - 1])
                        {
                            rect = new Rectangle(class_term[k][h].X - 4, class_term[k][h].Y - 4, 8, 8);
                            e.Graphics.DrawEllipse(Pens.Black, rect);
                            e.Graphics.FillEllipse(Brushes.Black, rect);
                            rect = new Rectangle(class_term[k][h - 1].X - 4, class_term[k][h - 1].Y - 4, 8, 8);
                            e.Graphics.DrawEllipse(Pens.Black, rect);
                            e.Graphics.FillEllipse(Brushes.Black, rect);
                            e.Graphics.DrawLine(linePen, class_term[k][h].X, class_term[k][h].Y, class_term[k][h - 1].X, class_term[k][h - 1].Y);
                        }
                    }
                }
            }

            for (int k = 0, loopTo27 = publicSubsNFunctions.all_classes.Length - 1; k <= loopTo27; k++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form), publicSubsNFunctions.all_classes[k], false)))
                {
                    if (publicSubsNFunctions.tm == "I")
                    {
                        if (k > 0)
                        {
                            if (class_term_data[k - 1][2])
                            {
                                if (class_term[k - 1][2].Y < class_term[k][0].Y)
                                {
                                    perf = "Improve";
                                }
                                else if (class_term[k][0].Y < class_term[k - 1][2].Y)
                                {
                                    perf = "Drop";
                                }
                                else if (class_term[k][0].Y == class_term[k - 1][2].Y)
                                {
                                    perf = "Constant";
                                }
                            }
                            else
                            {
                                perf = Conversions.ToString(dgvEnterMarks["MG", student].Value);
                            }
                        }
                        else
                        {
                            perf = Conversions.ToString(dgvEnterMarks["MG", student].Value);
                        }
                    }
                    else if (publicSubsNFunctions.tm == "II")
                    {
                        if (k > 0)
                        {
                            if (class_term_data[k][0])
                            {
                                if (class_term[k][1].Y < class_term[k][0].Y)
                                {
                                    perf = "Improve";
                                }
                                else if (class_term[k][0].Y < class_term[k][1].Y)
                                {
                                    perf = "Drop";
                                }
                                else if (class_term[k][1].Y == class_term[k][0].Y)
                                {
                                    perf = "Constant";
                                }
                            }
                            else
                            {
                                perf = Conversions.ToString(dgvEnterMarks["MG", student].Value);
                            }
                        }
                        else
                        {
                            perf = Conversions.ToString(dgvEnterMarks["MG", student].Value);
                        }
                    }
                    else if (publicSubsNFunctions.tm == "III")
                    {
                        if (k > 0)
                        {
                            if (class_term_data[k][1])
                            {
                                if (class_term[k][1].Y < class_term[k - 1][1].Y)
                                {
                                    perf = "Improve";
                                }
                                else if (class_term[k - 1][1].Y < class_term[k][1].Y)
                                {
                                    perf = "Drop";
                                }
                                else if (class_term[k][1].Y == class_term[k - 1][1].Y)
                                {
                                    perf = "Constant";
                                }
                            }
                            else
                            {
                                perf = Conversions.ToString(dgvEnterMarks["MG", student].Value);
                            }
                        }
                        else
                        {
                            perf = Conversions.ToString(dgvEnterMarks["MG", student].Value);
                        }
                    }

                    break;
                }
            }

            var npen = new Pen(Color.Silver, 1f);
            npen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            for (int k = 0, loopTo28 = publicSubsNFunctions.grades.Length - 1; k <= loopTo28; k++)
            {
                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.smallfont, Avgpen, left_margin - 5, line);
                e.Graphics.DrawLine(npen, left_margin + 10, line + 9, right_end, line + 9);
                publicSubsNFunctions.grades_y[k] = line;
                line += ht - 4;
            }

            line += 30;
            if (publicSubsNFunctions.IsPrimary())
            {
                h_width = (int)Math.Round((right_margin - left_margin) / 3d);
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                e.Graphics.DrawString("PERFORMANCE INDEX", publicSubsNFunctions.medium, Brushes.Black, left_margin + 5, line);
                e.Graphics.DrawString("CLASS MEAN MARKS", publicSubsNFunctions.medium, Brushes.Black, left_margin + h_width * 1 + 5, line);
                e.Graphics.DrawString("CLASS MEAN GRADE", publicSubsNFunctions.medium, Brushes.Black, left_margin + h_width * 2 + 5, line);
                line += 15;
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                e.Graphics.DrawString(Strings.Format(class_mean_mark(), "0.00"), publicSubsNFunctions.medium, Brushes.Black, left_margin + h_width * 1 + 5, line);
                e.Graphics.DrawString(Conversions.ToString(class_mean_grade()), publicSubsNFunctions.medium, Brushes.Black, left_margin + h_width * 2 + 5, line);
                line += 15;
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                e.Graphics.DrawLine(Pens.Black, left_margin, line - 30, left_margin, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + h_width * 1, line - 30, left_margin + h_width * 1, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + h_width * 2, line - 30, left_margin + h_width * 2, line);
                e.Graphics.DrawLine(Pens.Black, right_margin, line - 30, right_margin, line);
            }
            else
            {
                vat.Y = Conversions.ToInteger(y_point_of_grade(vapgrade(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value))));
                vat.X = left_margin + 10;
                rect = new Rectangle(vat.X, vat.Y, 15, endline - vat.Y);
                if (report.color)
                {
                    e.Graphics.FillRectangle(Brushes.Black, rect);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Black, rect);
                }

                h_width = (int)Math.Round((right_margin - left_margin) / 5d);
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                e.Graphics.DrawString("MARKS IN KCPE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 5, line);
                e.Graphics.DrawString("RANK IN KCPE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + h_width * 1 + 5, line);
                e.Graphics.DrawString("PERF. INDEX", publicSubsNFunctions.other_font, Brushes.Black, left_margin + h_width * 2 + 5, line);
                e.Graphics.DrawString("CLASS M. MARKS", publicSubsNFunctions.other_font, Brushes.Black, left_margin + h_width * 3 + 5, line);
                e.Graphics.DrawString("CLASS M. GRADE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + h_width * 4 + 5, line);
                line += 15;
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(get_kcpe_marks(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value)), " / 500")), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 5, line);
                e.Graphics.DrawString(Conversions.ToString(kcpe_rank(dgvEnterMarks["KCPE", student].Value)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + h_width * 1 + 5, line);
                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["VAP", student].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + h_width * 2 + 5, line);
                e.Graphics.DrawString(Strings.Format(class_mean_mark(), "0.00"), publicSubsNFunctions.other_font, Brushes.Black, left_margin + h_width * 3 + 5, line);
                e.Graphics.DrawString(Conversions.ToString(class_mean_grade()), publicSubsNFunctions.other_font, Brushes.Black, left_margin + h_width * 4 + 5, line);
                line += 15;
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                e.Graphics.DrawLine(Pens.Black, left_margin, line - 30, left_margin, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + h_width * 1, line - 30, left_margin + h_width * 1, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + h_width * 2, line - 30, left_margin + h_width * 2, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + h_width * 3, line - 30, left_margin + h_width * 3, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + h_width * 4, line - 30, left_margin + h_width * 4, line);
                e.Graphics.DrawLine(Pens.Black, right_margin, line - 30, right_margin, line);
            }

            line += 5;
            if (publicSubsNFunctions.subject_ranking_table)
            {
                e.Graphics.DrawLine(Pens.Black, (int)Math.Round(right_margin / 2d) + 60, startline, right_margin, startline);
                topline = startline;
                e.Graphics.DrawString("SUBJECT", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (int)Math.Round(right_margin / 2d) + 10, startline);
                e.Graphics.DrawString("RANK IN STR.", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (int)Math.Round(right_margin / 2d) + 165, startline);
                e.Graphics.DrawString("RANK IN CL.", publicSubsNFunctions.smallfont, Brushes.Black, right_margin - 75, startline);
                startline += publicSubsNFunctions.smallfont.Height;
                e.Graphics.DrawLine(Pens.Black, left_margin + (int)Math.Round(right_margin / 2d) - 20, startline, right_margin, startline);
                bool continue_ = false;
                for (int k = 0, loopTo29 = publicSubsNFunctions.subjects.Length - 1; k <= loopTo29; k++)
                {
                    for (int s = 0, loopTo30 = subjects_done.Length - 1; s <= loopTo30; s++)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.subjects[k], subjects_done[s], false)))
                        {
                            continue_ = true;
                            break;
                        }
                    }

                    if (continue_)
                    {
                        if (report.color)
                        {
                            if (publicSubsNFunctions.subjects[k].ToString().Length >= 22)
                            {
                                e.Graphics.DrawString(publicSubsNFunctions.subjects[k].ToString().Substring(0, 22), publicSubsNFunctions.smallfont, Brushes.Blue, left_margin + (int)Math.Round(right_margin / 2d) - 10, startline);
                            }
                            else
                            {
                                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subjects[k]), publicSubsNFunctions.smallfont, Brushes.Blue, left_margin + (int)Math.Round(right_margin / 2d) - 10, startline);
                            }

                            e.Graphics.DrawString(Conversions.ToString(subject_rank(subjects_done_name[k], Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.subjabb[k], student).Value), Conversions.ToString(dgvEnterMarks["str_class", student].Value))), publicSubsNFunctions.smallfont, Brushes.Blue, left_margin + (int)Math.Round(right_margin / 2d) + 165, startline);
                            e.Graphics.DrawString(Conversions.ToString(subject_rank(subjects_done_name[k], Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.subjabb[k], student).Value), string.Empty)), publicSubsNFunctions.smallfont, Brushes.Blue, right_margin - 80, startline);
                        }
                        else
                        {
                            if (publicSubsNFunctions.subjects[k].ToString().Length >= 22)
                            {
                                e.Graphics.DrawString(publicSubsNFunctions.subjects[k].ToString().Substring(0, 22), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (int)Math.Round(right_margin / 2d) - 10, startline);
                            }
                            else
                            {
                                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subjects[k]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (int)Math.Round(right_margin / 2d) - 10, startline);
                            }

                            e.Graphics.DrawString(Conversions.ToString(subject_rank(Conversions.ToString(publicSubsNFunctions.subjabb[k]), Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.subjabb[k], student).Value), Conversions.ToString(dgvEnterMarks["str_class", student].Value))), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (int)Math.Round(right_margin / 2d) + 165, startline);
                            e.Graphics.DrawString(Conversions.ToString(subject_rank(Conversions.ToString(publicSubsNFunctions.subjabb[k]), Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.subjabb[k], student).Value), string.Empty)), publicSubsNFunctions.smallfont, Brushes.Black, right_margin - 80, startline);
                        }
                    }
                    else if (report.color)
                    {
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subjects[k]), publicSubsNFunctions.smallfont, Brushes.Blue, left_margin + (int)Math.Round(right_margin / 2d) - 10, startline);
                        e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Blue, left_margin + (int)Math.Round(right_margin / 2d) + 170, startline);
                        e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Blue, right_margin - 70, startline);
                    }
                    else
                    {
                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subjects[k]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (int)Math.Round(right_margin / 2d) - 10, startline);
                        e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + (int)Math.Round(right_margin / 2d) + 170, startline);
                        e.Graphics.DrawString("--", publicSubsNFunctions.smallfont, Brushes.Black, right_margin - 70, startline);
                    }

                    continue_ = false;
                    startline += publicSubsNFunctions.smallfont.Height;
                    e.Graphics.DrawLine(Pens.Black, left_margin + (int)Math.Round(right_margin / 2d) - 20, startline, right_margin, startline);
                }

                e.Graphics.DrawLine(Pens.Black, left_margin + (int)Math.Round(right_margin / 2d) - 20, startline, left_margin + (int)Math.Round(right_margin / 2d) - 20, topline);
                e.Graphics.DrawLine(Pens.Black, left_margin + (int)Math.Round(right_margin / 2d) + 165, startline, left_margin + (int)Math.Round(right_margin / 2d) + 165, topline);
                e.Graphics.DrawLine(Pens.Black, right_margin - 80, startline, right_margin - 80, topline);
                e.Graphics.DrawLine(Pens.Black, right_margin, topline, right_margin, startline);
            }

            if (publicSubsNFunctions.attend)
            {
                if (report.color)
                {
                    e.Graphics.DrawString("TOTAL ATTENDANCE:........................", publicSubsNFunctions.medium, Avgpen, left_margin + 2, line);
                    e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(get_total_attendance(Conversions.ToInteger(dgvEnterMarks["ADMNo", student].Value)), " Out Of "), total_term_days)), publicSubsNFunctions.medium, Avgpen, left_margin + 160, line - 3);
                    e.Graphics.DrawString("PERCENTAGE ATTENDANCE:.......................", publicSubsNFunctions.medium, Avgpen, left_margin + 300, line);
                    e.Graphics.DrawString(Strings.Format(percentage_attendance, "0.00") + " %", publicSubsNFunctions.medium, Avgpen, left_margin + 500, line - 3);
                }
                else
                {
                    e.Graphics.DrawString("TOTAL ATTENDANCE:........................", publicSubsNFunctions.medium, Brushes.Black, left_margin + 2, line);
                    e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(get_total_attendance(Conversions.ToInteger(dgvEnterMarks["ADMNo", student].Value)), " Out Of "), total_term_days)), publicSubsNFunctions.medium, Brushes.Black, left_margin + 160, line - 3);
                    e.Graphics.DrawString("PERCENTAGE ATTENDANCE:.......................", publicSubsNFunctions.medium, Brushes.Black, left_margin + 300, line);
                    e.Graphics.DrawString(Strings.Format(percentage_attendance, "0.00") + " %", publicSubsNFunctions.medium, Brushes.Black, left_margin + 500, line - 3);
                }

                line += 25;
            }

            int drline;
            if (report.house_master_comments | report.club_and_societies)
            {
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                drline = line;
            }

            drline = line;
            if (report.house_master_comments)
            {
                line += 2;
                e.Graphics.DrawString("HOUSE MASTER'S COMMENTS: ", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 2, line);
                line += 18;
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 200, line, left_margin + 200, drline);
            }

            if (report.club_and_societies)
            {
                line += 2;
                e.Graphics.DrawString("CLUBS AND SOCIETIES: ", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 2, line);
                line += 18;
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 200, line, left_margin + 200, drline);
            }

            e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, drline);
            e.Graphics.DrawLine(Pens.Black, right_margin, line, right_margin, drline);
            line += 2;
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
            drline = line;
            line += 2;
            e.Graphics.DrawString("CLASS TEACHER'S COMMENTS: ", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 2, line + 3);
            if (report.class_teacher_comments)
            {
                // comment of perf variable
                e.Graphics.DrawString(Conversions.ToString(get_class_teacher_comments(publicSubsNFunctions.class_form, Conversions.ToString(dgvEnterMarks["str_class", student].Value), perf)), italisized_font, Brushes.Black, left_margin + 210, line);
            }

            line += 22;
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
            e.Graphics.DrawLine(Pens.Black, left_margin + 200, line, left_margin + 200, drline);
            e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, drline);
            e.Graphics.DrawLine(Pens.Black, right_margin, line, right_margin, drline);
            line += 15;
            if (report.class_teacher_name)
            {
                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject("CLASS TEACHER'S NAME: ", get_class_teacher(Conversions.ToString(dgvEnterMarks["str_class", student].Value), false))), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 150, line);
            }

            e.Graphics.DrawString("SIGNATURE:", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 450, line);
            if (report.class_teacher_signature)
            {
                if (File.Exists(Conversions.ToString(getSignaturePath(Conversions.ToString(get_class_teacher(Conversions.ToString(dgvEnterMarks["str_class", student].Value), false))))))
                {
                    e.Graphics.DrawImage(Image.FromFile(Conversions.ToString(getSignaturePath(Conversions.ToString(get_class_teacher(Conversions.ToString(dgvEnterMarks["str_class", student].Value), false))))), left_margin + 550, line - 10, 100, 30);
                }
            }

            e.Graphics.DrawString(" ________________________________", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 520, line + 5);
            line += 20;
            drline = line;
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
            e.Graphics.DrawString("PRINCIPAL'S COMMENTS: ", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 2, line + 10);
            if (report.head_teacher_comments)
            {
                // commented on perf
                e.Graphics.DrawString(Conversions.ToString(get_head_teacher_comments(Conversions.ToString(dgvEnterMarks["MG", student].Value))), italisized_font, Brushes.Black, left_margin + 210, line);
            }

            e.Graphics.DrawLine(Pens.Black, left_margin + 200, line + 20, right_margin, line + 20);
            line += 40;
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
            e.Graphics.DrawLine(Pens.Black, left_margin, line, left_margin, drline);
            e.Graphics.DrawLine(Pens.Black, right_margin, line, right_margin, drline);
            e.Graphics.DrawLine(Pens.Black, left_margin + 200, line, left_margin + 200, drline);
            line += 15;
            if (report.head_teacher_name)
            {
                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject("PRINCIPAL'S NAME: ", get_head_teacher())), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 150, line);
            }

            e.Graphics.DrawString("SIGNATURE:", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 450, line);
            if (report.head_teacher_signature)
            {
                if (File.Exists(Conversions.ToString(getSignaturePath(Conversions.ToString(get_head_teacher())))))
                {
                    e.Graphics.DrawImage(Image.FromFile(Conversions.ToString(getSignaturePath(Conversions.ToString(get_head_teacher())))), left_margin + 550, line - 10, 100, 30);
                }
            }

            e.Graphics.DrawString("_______________________________", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 520, line + 5);
            if (publicSubsNFunctions.fee)
            {
                line += 20;
                drline = line;
                e.Graphics.DrawString("SCHOOL FEES", publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 120, line, right_margin - 100, line);
                e.Graphics.DrawString("OUTSTANDING ARREARS", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 125, line + 3);
                e.Graphics.DrawString("NEXT TERM FEES", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 280, line + 3);
                e.Graphics.DrawString("TOTAL FEES AMOUNT", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 440, line + 3);
                line += publicSubsNFunctions.other_font.Height;
                e.Graphics.DrawString(Conversions.ToString(get_fee_bal(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value))), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 130, line + 5);
                e.Graphics.DrawString(Conversions.ToString(next_term()), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 290, line + 5);
                e.Graphics.DrawString(Strings.Format(total_fees, "0.00"), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 450, line + 5);
                line += 2;
                e.Graphics.DrawLine(Pens.Black, left_margin + 120, line, right_margin - 100, line);
                line += publicSubsNFunctions.other_font.Height + 2;
                e.Graphics.DrawLine(Pens.Black, left_margin + 120, line, right_margin - 100, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 120, drline, left_margin + 120, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 275, drline, left_margin + 275, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + 430, drline, left_margin + 430, line);
                e.Graphics.DrawLine(Pens.Black, right_margin - 100, drline, right_margin - 100, line);
            }

            line += 10;
            e.Graphics.DrawString("CLOSING DATE THIS TERM:________________", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 50, line);
            if (!report.color)
            {
                e.Graphics.DrawString(Strings.Format(publicSubsNFunctions.to_close.Day, "00") + "-" + Strings.Format(publicSubsNFunctions.to_close.Month, "00") + "-" + publicSubsNFunctions.to_close.Year, publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 220, line - 3);
            }
            else
            {
                e.Graphics.DrawString(Strings.Format(publicSubsNFunctions.to_close.Day, "00") + "-" + Strings.Format(publicSubsNFunctions.to_close.Month, "00") + "-" + publicSubsNFunctions.to_close.Year, publicSubsNFunctions.smallfont, Brushes.Blue, left_margin + 220, line - 3);
            }

            e.Graphics.DrawString("OPENING DATE NEXT TERM:________________", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 450, line);
            if (report.color)
            {
                e.Graphics.DrawString(Strings.Format(publicSubsNFunctions.to_open.Day, "00") + "-" + Strings.Format(publicSubsNFunctions.to_open.Month, "00") + "-" + publicSubsNFunctions.to_open.Year, publicSubsNFunctions.smallfont, Brushes.Blue, left_margin + 620, line - 3);
            }
            else
            {
                e.Graphics.DrawString(Strings.Format(publicSubsNFunctions.to_open.Day, "00") + "-" + Strings.Format(publicSubsNFunctions.to_open.Month, "00") + "-" + publicSubsNFunctions.to_open.Year, publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 620, line - 3);
            }

            line += publicSubsNFunctions.smallfont.Height + 3;
            e.Graphics.DrawString("PARENT'S SIGNATURE: ___________________________________________________________________", publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 150, line);
            if (publicSubsNFunctions.watermark)
            {
                var g = e.Graphics;
                g.TranslateTransform(200f, 200f);
                if (e.PageSettings.Landscape)
                {
                    g.RotateTransform(30f);
                }
                else
                {
                    g.RotateTransform(60f);
                }

                g.DrawString(publicSubsNFunctions.S_NAME, new Font("Arial", 40f, FontStyle.Bold), new SolidBrush(Color.FromArgb(64, Color.Black)), 0f, 0f);
            }

            if (student == to_row)
            {
                return;
            }
            else
            {
                e.HasMorePages = true;
                student += 1;
                return;
            }
        }

        private object get_student_category()
        {
            string argq = "SELECT student_category FROM students WHERE admin_no='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value)) + "'";
            if (publicSubsNFunctions.qread(ref argq))
            {
                publicSubsNFunctions.dbreader.Read();
                return publicSubsNFunctions.dbreader["student_category"];
            }
            else
            {
                return "Boarder";
            }
        }

        private object next_term()
        {
            object next_termRet = default;
            string term = null;
            int yr1;
            if (publicSubsNFunctions.tm == "I")
            {
                yr1 = publicSubsNFunctions.yr;
                term = "II";
            }
            else if (publicSubsNFunctions.tm == "II")
            {
                yr1 = publicSubsNFunctions.yr;
                term = "III";
            }
            else if (publicSubsNFunctions.tm == "III")
            {
                yr1 = publicSubsNFunctions.yr + 1;
                term = "I";
            }

            double amt = 0d;
            // qread("SELECT amount FROM fee_structure WHERE (term='" & term & "' AND class='" & ret_name(class_form) & "' AND year='" & yr1 & "' AND category='" & escape_string(get_student_category()) & "')")
            // While dbreader.Read
            // amt += dbreader("amount")
            // End While

            // todo fee structure
            // total_fees += amt
            next_termRet = Strings.Format(amt, "0.00");
            return next_termRet;
        }

        // Dim total_fees As Double
        private bool ignore_class_teacher, ignore_head_teacher;
        private int zline;
        private object get_head_teacher()
        {
            object get_head_teacherRet = default;
            string argq = "SELECT head FROM school_details";
            publicSubsNFunctions.qread(ref argq);
            publicSubsNFunctions.dbreader.Read();
            get_head_teacherRet = publicSubsNFunctions.dbreader["head"];
            return get_head_teacherRet;
        }

        private object get_class_teacher_comments(string cf, string str, string performance)
        {
            object get_class_teacher_commentsRet = default;
            string test = Conversions.ToString(publicSubsNFunctions.ret_name(cf));
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT comment FROM class_teachers_comments WHERE (class='", publicSubsNFunctions.ret_name(cf)), "' AND stream='"), str), "' AND trend='"), performance), "')"));
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                get_class_teacher_commentsRet = publicSubsNFunctions.dbreader["comment"];
            }
            else
            {
                return string.Empty;
            }

            return get_class_teacher_commentsRet;
        }

        private object get_head_teacher_comments(string performance)
        {
            object get_head_teacher_commentsRet = default;
            string argq = "SELECT comment FROM head_teachers_comments WHERE  trend='" + performance + "'";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                get_head_teacher_commentsRet = publicSubsNFunctions.dbreader["comment"];
            }
            else
            {
                return string.Empty;
            }

            return get_head_teacher_commentsRet;
        }

        public object getSignaturePath(string name)
        {
            string path = string.Empty;
            string argq = "SELECT path FROM partners WHERE  partnername ='" + name + "'";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                path = Conversions.ToString(publicSubsNFunctions.dbreader["path"]);
            }

            return path;
        }

        private object get_class_teacher(string str, bool initial)
        {
            object get_class_teacherRet = default;
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Teacher FROM class_teachers WHERE Class='", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "' AND Stream='"), publicSubsNFunctions.escape_string(str)), "'"));
            publicSubsNFunctions.qread(ref argq);
            if (initial)
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    publicSubsNFunctions.dbreader.Read();
                    get_class_teacherRet = publicSubsNFunctions.dbreader["Teacher"];
                    var names = get_class_teacherRet.ToString().Split(' ');
                    if (names.Length > 2)
                    {
                        get_class_teacherRet = names[1].ToString().Substring(0, 1) + " " + names[2].ToString().Substring(0, 1);
                    }
                    else
                    {
                        get_class_teacherRet = names[1].ToString().Substring(0, 1);
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            else if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                get_class_teacherRet = publicSubsNFunctions.dbreader["Teacher"];
            }
            else
            {
                return string.Empty;
            }

            return get_class_teacherRet;
        }

        private object subject_rank(string sname, string value, string stream)
        {
            if (!Information.IsNumeric(value))
            {
                return "--";
            }
            else
            {
                double[] ranks = null;
                int count = 0;
                if (publicSubsNFunctions.mode)
                {
                    for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 5; k <= loopTo; k++)
                    {
                        if ((stream ?? "") == (string.Empty ?? ""))
                        {
                            if (Information.IsNumeric(dgvEnterMarks[sname, k].Value))
                            {
                                Array.Resize(ref ranks, count + 1);
                                ranks[count] = Conversions.ToDouble(dgvEnterMarks[sname, k].Value);
                                count += 1;
                            }
                        }
                        else if (Conversions.ToBoolean(Operators.AndObject(Information.IsNumeric(dgvEnterMarks[sname, k].Value), Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", k].Value, stream, false))))
                        {
                            Array.Resize(ref ranks, count + 1);
                            ranks[count] = Conversions.ToDouble(dgvEnterMarks[sname, k].Value);
                            count += 1;
                        }
                    }

                    double temp;
                    if (count > 0)
                    {
                        for (int k = 0, loopTo1 = ranks.Length - 1; k <= loopTo1; k++)
                        {
                            for (int l = k + 1, loopTo2 = ranks.Length - 1; l <= loopTo2; l++)
                            {
                                if (ranks[l] > ranks[k])
                                {
                                    temp = ranks[k];
                                    ranks[k] = ranks[l];
                                    ranks[l] = temp;
                                }
                            }
                        }
                    }
                    else
                    {
                        return "--";
                    }

                    for (int k = 0, loopTo3 = ranks.Length - 1; k <= loopTo3; k++)
                    {
                        try
                        {
                            if (ranks[k] == Conversions.ToDouble(value))
                            {
                                if (k + 1 > ranks.Length)
                                {
                                    return "--";
                                }
                                else
                                {
                                    return k + 1 + " Out Of " + ranks.Length;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            return "--";
                        }
                    }
                }
                else
                {
                    if ((stream ?? "") == (string.Empty ?? ""))
                    {
                        publicSubsNFunctions.query = "SELECT `" + sname + "` FROM " + publicSubsNFunctions.table + " WHERE Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "'  AND class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "'  ORDER BY " + sname + " DESC";
                    }
                    else
                    {
                        publicSubsNFunctions.query = "SELECT `" + sname + "` FROM " + publicSubsNFunctions.table + " WHERE Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Stream='" + stream + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "'  AND class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "'  ORDER BY " + sname + " DESC";
                    }

                    publicSubsNFunctions.qread(ref publicSubsNFunctions.query);
                    var all = default(int);
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        if (Information.IsNumeric(publicSubsNFunctions.dbreader[sname]) | publicSubsNFunctions.dbreader[sname].ToString() == "X" | publicSubsNFunctions.dbreader[sname].ToString() == "Y" | publicSubsNFunctions.dbreader[sname].ToString() == "x" | publicSubsNFunctions.dbreader[sname].ToString() == "y")
                        {
                            all += 1;
                        }
                    }

                    if (all == 0)
                    {
                        return "--";
                    }

                    publicSubsNFunctions.dbreader.Close();
                    publicSubsNFunctions.qread(ref publicSubsNFunctions.query);
                    int i = 1;
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        try
                        {
                            if (Conversions.ToInteger(publicSubsNFunctions.dbreader[sname]) == Conversions.ToInteger(value))
                            {
                                publicSubsNFunctions.dbreader.Close();
                                if (i > all)
                                {
                                    return "--";
                                }
                                else
                                {
                                    return i + " Out Of " + all;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                        i += 1;
                    }
                }

                return "--";
            }
        }

        private object subject_rank_only(string sname, string value, string stream)
        {
            if (!Information.IsNumeric(value))
            {
                return "--";
            }
            else
            {
                double[] ranks = null;
                int count = 0;
                if (publicSubsNFunctions.mode)
                {
                    for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 5; k <= loopTo; k++)
                    {
                        if ((stream ?? "") == (string.Empty ?? ""))
                        {
                            if (Information.IsNumeric(dgvEnterMarks[sname, k].Value))
                            {
                                Array.Resize(ref ranks, count + 1);
                                ranks[count] = Conversions.ToDouble(dgvEnterMarks[sname, k].Value);
                                count += 1;
                            }
                        }
                        else if (Conversions.ToBoolean(Operators.AndObject(Information.IsNumeric(dgvEnterMarks[sname, k].Value), Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", k].Value, stream, false))))
                        {
                            Array.Resize(ref ranks, count + 1);
                            ranks[count] = Conversions.ToDouble(dgvEnterMarks[sname, k].Value);
                            count += 1;
                        }
                    }

                    double temp;
                    if (count > 0)
                    {
                        for (int k = 0, loopTo1 = ranks.Length - 1; k <= loopTo1; k++)
                        {
                            for (int l = k + 1, loopTo2 = ranks.Length - 1; l <= loopTo2; l++)
                            {
                                if (ranks[l] > ranks[k])
                                {
                                    temp = ranks[k];
                                    ranks[k] = ranks[l];
                                    ranks[l] = temp;
                                }
                            }
                        }
                    }
                    else
                    {
                        return "--";
                    }

                    for (int k = 0, loopTo3 = ranks.Length - 1; k <= loopTo3; k++)
                    {
                        try
                        {
                            if ((int)Math.Round(ranks[k]) == Conversions.ToDouble(value))
                            {
                                if (k + 1 > ranks.Length)
                                {
                                    return "--";
                                }
                                else
                                {
                                    return k + 1;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            return "--";
                        }
                    }
                }
                else
                {
                    if ((stream ?? "") == (string.Empty ?? ""))
                    {
                        publicSubsNFunctions.query = "SELECT `" + sname + "` FROM " + publicSubsNFunctions.table + " WHERE Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Term='" + publicSubsNFunctions.tm + "' AND class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "' AND Year='" + publicSubsNFunctions.yr + "' ORDER BY " + sname + " DESC";
                    }
                    else
                    {
                        publicSubsNFunctions.query = "SELECT `" + sname + "` FROM " + publicSubsNFunctions.table + " WHERE Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "'  AND Term='" + publicSubsNFunctions.tm + "' AND class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "'  AND Year='" + publicSubsNFunctions.yr + "' AND Stream='" + stream + "' ORDER BY " + sname + " DESC";
                    }

                    publicSubsNFunctions.qread(ref publicSubsNFunctions.query);
                    var all = default(int);
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        if (Information.IsNumeric(publicSubsNFunctions.dbreader[sname]) | publicSubsNFunctions.dbreader[sname].ToString() == "X" | publicSubsNFunctions.dbreader[sname].ToString() == "Y" | publicSubsNFunctions.dbreader[sname].ToString() == "x" | publicSubsNFunctions.dbreader[sname].ToString() == "y")
                        {
                            all += 1;
                        }
                    }

                    if (all == 0)
                    {
                        return "--";
                    }

                    publicSubsNFunctions.qread(ref publicSubsNFunctions.query);
                    int i = 1;
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        if (Information.IsNumeric(publicSubsNFunctions.dbreader[sname]))
                        {
                            if (Conversions.ToInteger(publicSubsNFunctions.dbreader[sname]) == Conversions.ToInteger(value))
                            {
                                if (i > all)
                                {
                                    return "--";
                                }
                                else
                                {
                                    return i;
                                }
                            }
                        }
                        else
                        {
                            return "--";
                        }

                        i += 1;
                    }
                }
            }

            return "--";
        }

        // Dim f1t1, f1t2, f1t3, f2t1, f2t2, f2t3, f3t1, f3t2, f3t3, f4t1, f4t2, f4t3, vat As Point
        private Point[][] class_term = new Point[13][];
        private Point vat;
        // Dim f1t1h, f1t2h, f1t3h, f2t1h, f2t2h, f2t3h, f3t1h, f3t2h, f3t3h, f4t1h, f4t2h, f4t3h As Integer
        private int[][] class_term_height = new int[13][];
        private string only_grade;
        // Dim f1t1tm, f1t2tm, f1t3tm, f2t1tm, f2t2tm, f2t3tm, f3t1tm, f3t2tm, f3t3tm, f4t1tm, f4t2tm, f4t3tm As Boolean
        private bool[][] class_term_data = new bool[13][];
        private string get_class_performance_data(string tm, string cls, int yr)
        {
            string get_class_performance_dataRet = default;
            bool set_bool;
            string grade = null;
            bool localqread()
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM class_performance_data WHERE ADMNo='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value)) + "' AND term='" + tm + "' AND class='", publicSubsNFunctions.all_classes[Conversions.ToInteger(cls)]), "'"));
                var ret = publicSubsNFunctions.qread(ref argq);
                return ret;
            }

            if (!localqread())
            {
                return string.Empty;
            }

            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                get_class_performance_dataRet = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("POS:", publicSubsNFunctions.dbreader["POS"]), " MG:"), publicSubsNFunctions.dbreader["GRADE"]), " MP:"), publicSubsNFunctions.dbreader["POINTS"]));
                set_bool = true;
                grade = Conversions.ToString(publicSubsNFunctions.dbreader["GRADE"]);
            }
            else
            {
                get_class_performance_dataRet = string.Empty;
                set_bool = false;
            }

            if (tm == "I")
            {
                class_term[Conversions.ToInteger(cls)][0].Y = Conversions.ToInteger(Operators.AddObject(y_point_of_grade(grade), 9));
                class_term_data[Conversions.ToInteger(cls)][0] = set_bool;
            }
            else if (tm == "II")
            {
                class_term[Conversions.ToInteger(cls)][1].Y = Conversions.ToInteger(Operators.AddObject(y_point_of_grade(grade), 9));
                class_term_data[Conversions.ToInteger(cls)][1] = set_bool;
            }
            else if (tm == "III")
            {
                class_term[Conversions.ToInteger(cls)][2].Y = Conversions.ToInteger(Operators.AddObject(y_point_of_grade(grade), 9));
                class_term_data[Conversions.ToInteger(cls)][2] = set_bool;
            }

            only_grade = grade;
            return get_class_performance_dataRet;
        }

        private object y_point_of_grade(string grade)
        {
            for (int k = 0, loopTo = publicSubsNFunctions.grades.Length - 1; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(grade, publicSubsNFunctions.grades[k], false)))
                {
                    return publicSubsNFunctions.grades_y[k];
                }
            }

            return zline;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.tables = null;
            publicSubsNFunctions.mode = false;
            publicSubsNFunctions.mod_subject = false;
            publicSubsNFunctions.form_4_mode = false;
            publicSubsNFunctions.grade = false;
            Close();
        }

        private void reload()
        {
            if (publicSubsNFunctions.grade)
            {
                publicSubsNFunctions.grade = false;
                btnGrade.Text = "View In Grade Mode";
            }

            dgvEnterMarks.Rows.Clear();
            if (publicSubsNFunctions.mode)
            {
                load_multi();
            }
            else
            {
                load_entered();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void gradeview()
        {
            Pbar.Visible = true;
            double inc = dgvEnterMarks.Rows.Count - 5d / 100d;
            var total = default(int);
            if (!publicSubsNFunctions.mode)
            {
                total = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
            }

            for (int i = 0, loopTo = dgvEnterMarks.Rows.Count - 5; i <= loopTo; i++)
            {
                for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                {
                    if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value))
                    {
                        if (!publicSubsNFunctions.mode)
                        {
                            dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value = Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value, " "), publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value, total), 100)), publicSubsNFunctions.mod_subject, Conversions.ToString(publicSubsNFunctions.subjabb[k])));
                        }
                        else
                        {
                            dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value = Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value, " "), publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value), publicSubsNFunctions.mod_subject, Conversions.ToString(publicSubsNFunctions.subjabb[k])));
                        }
                    }
                }

                Pbar.Increment((int)Math.Round(inc));
            }

            Pbar.Visible = false;
            Pbar.Increment(-100);
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            if (publicSubsNFunctions.grade)
            {
                dgvEnterMarks.Rows.Clear();
                publicSubsNFunctions.grade = false;
                btnViewReport.Enabled = true;
                Button1.Enabled = true;
                if (publicSubsNFunctions.mode)
                {
                    load_multi();
                }
                else
                {
                    load_entered();
                }

                btnGrade.Text = "Show Marks + Grades";
            }
            else
            {
                publicSubsNFunctions.grade = true;
                btnViewReport.Enabled = false;
                Button1.Enabled = false;
                gradeview();
                btnGrade.Text = "Show Marks Only";
            }
        }

        private void chkmode_CheckedChanged(object sender, EventArgs e)
        {
            using (new DevExpress.Utils.WaitDialogForm("Computing Please Wait ..."))
            {
                if (chkMode.Checked)
                {
                    publicSubsNFunctions.form_4_mode = true;
                }
                else
                {
                    publicSubsNFunctions.form_4_mode = false;
                }

                dgvEnterMarks.Rows.Clear();
                if (publicSubsNFunctions.mode)
                {
                    load_multi();
                }
                else
                {
                    load_entered();
                }
            }
        }

        private object get_sciences()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Abbreviation FROM subjects WHERE Department='", publicSubsNFunctions.GRP_SCIENCES), "'"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                sciences = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                int i = 0;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    sciences[i] = Conversions.ToString(publicSubsNFunctions.dbreader["Abbreviation"]);
                    i += 1;
                }

                publicSubsNFunctions.dbreader.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        private object get_compulsory()
        {
            string argq = "SELECT Abbreviation FROM subjects WHERE  Comment='Compulsory'";
            if (publicSubsNFunctions.qread(ref argq))
            {
                compulsory = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                int i = 0;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    compulsory[i] = Conversions.ToString(publicSubsNFunctions.dbreader["Abbreviation"]);
                    i += 1;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private object get_humanity()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Abbreviation FROM subjects WHERE  Department='", publicSubsNFunctions.GRP_HUMANITIES), "'"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                humanities = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                int i = 0;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    humanities[i] = Conversions.ToString(publicSubsNFunctions.dbreader["Abbreviation"]);
                    i += 1;
                }

                publicSubsNFunctions.dbreader.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        private object get_applied()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Abbreviation FROM subjects WHERE  Department='", publicSubsNFunctions.GRP_TECHNICAL), "'"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                applieds = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                int i = 0;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    applieds[i] = Conversions.ToString(publicSubsNFunctions.dbreader["Abbreviation"]);
                    i += 1;
                }

                publicSubsNFunctions.dbreader.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        private object formfourmode()
        {
            if (Conversions.ToBoolean(get_compulsory()))
            {
                if (Conversions.ToBoolean(get_sciences()))
                {
                    if (Conversions.ToBoolean(get_humanity()))
                    {
                        get_applied();
                        return true;
                    }
                    else
                    {
                        publicSubsNFunctions.failure("Could Not Correctly Determine Any Humanity Subject!");
                        return false;
                    }
                }
                else
                {
                    publicSubsNFunctions.failure("Could Not Correctly Determine Any Science Subject!");
                    return false;
                }
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Correctly Determine Any Compulsory Subject!");
                return false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PrintDocument print_document = (PrintDocument)prepare_class_list();
            var margin = new Margins(10, 10, 10, 10);
            print_document.DefaultPageSettings.Landscape = false;
            print_document.DefaultPageSettings.Margins = margin;
            print_document.DocumentName = Conversions.ToString(publicSubsNFunctions.get_name(publicSubsNFunctions.class_form + " Performance List"));
            printpreview.Document = print_document;
            print_document.Print();
        }

        private double class_mean_mark()
        {
            double class_mean_markRet = default;
            int cnt = 0;
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
            {
                class_mean_markRet = Conversions.ToDouble(class_mean_markRet + dgvEnterMarks["MM", k].Value);
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks["MM", k].Value, 0, false)))
                {
                    cnt += 1;
                }
            }

            class_mean_markRet = class_mean_markRet / cnt;
            return class_mean_markRet;
        }

        private object class_mean_grade()
        {
            object class_mean_gradeRet = default;
            var mean_points = default(double);
            int cnt = 0;
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
            {
                mean_points = Conversions.ToDouble(mean_points + dgvEnterMarks["MP", k].Value);
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks["MP", k].Value, 0, false)))
                {
                    cnt += 1;
                }
            }

            mean_points = mean_points / cnt;
            class_mean_gradeRet = publicSubsNFunctions.get_points(mean_points);
            return class_mean_gradeRet;
        }

        private int from_row, to_row;
        private void Button2_Click_1(object sender, EventArgs e)
        {
            publicSubsNFunctions.resetSchoolName();
            if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Do You Want To Print All Report Forms?")))
            {
                selected_print = false;
                var frm2 = new frmPrompt();
                frm2.ShowDialog();
                if (publicSubsNFunctions.cont)
                {
                    from_row = 0;
                    to_row = dgvEnterMarks.Rows.Count - 5;
                    publicSubsNFunctions.cont = true;
                    print_reports = true;
                    selected_print = true;
                }
            }
            else
            {
                selected_print = true;
                from_row = -1;
                to_row = -1;
                var frm1 = new frmPrintFrom();
                frm1.ShowDialog();
                for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 4; k <= loopTo; k++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["ADMNo", k].Value, publicSubsNFunctions.row_from, false)))
                    {
                        from_row = k;
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["ADMNo", k].Value, publicSubsNFunctions.row_to, false)))
                    {
                        to_row = k;
                        break;
                    }
                }

                print_reports = true;
            }

            // added the below code
            if (!publicSubsNFunctions.to_continue)
            {
                return;
            }

            // If Not cont Then
            // Exit Sub
            // End If
            if (from_row == -1 | to_row == -1 | from_row > to_row)
            {
                return;
            }

            mode_view = false;
            if (publicSubsNFunctions.stream_mode)
            {
                publicSubsNFunctions.failure("Cannot Print Or View Report Form! Please Consider Analysing Results For The Entire Class");
                return;
            }

            publicSubsNFunctions.cont = false;
            var frm = new frmDates();
            frm.ShowDialog();
            if (!publicSubsNFunctions.cont)
            {
                return;
            }

            reload();
            if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Are You Sure You Want To Save This Examination Results As End Of Term " + publicSubsNFunctions.tm + " Results For " + publicSubsNFunctions.yr + "'")))
            {
                save_as();
            }
            else
            {
                return;
            }

            i = from_row;
            student = i;
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_report();
            print_document.DefaultPageSettings.Landscape = false;
            print_document.DocumentName = "Student Report Forms";
            printpreview.Document = print_document;
            print_document.Print();
            return;
        }

        private int getPosition()
        {
            return default;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var frm = new frmPrompt();
            frm.ShowDialog();
            if (publicSubsNFunctions.to_continue)
            {
                var Print_Preview = new PrintPreviewDialog();
                var print_dialog = new PrintDialog();
                PrintDocument print_document = (PrintDocument)prepare_stream_list();
                var margin = new Margins(10, 10, 10, 10);
                print_document.DefaultPageSettings.Landscape = false;
                print_document.DefaultPageSettings.Margins = margin;
                print_document.DocumentName = Conversions.ToString(publicSubsNFunctions.get_name(publicSubsNFunctions.class_form + " " + publicSubsNFunctions.class_stream + " Performance List"));
                printpreview.Document = print_document;
                print_document.Print();
            }
        }

        private object get_kcpe_marks(string id)
        {
            string argq = "SELECT marks_attained_primary FROM students WHERE admin_no='" + id + "'";
            if (publicSubsNFunctions.qread(ref argq))
            {
                publicSubsNFunctions.dbreader.Read();
                try
                {
                    id = Conversions.ToString(publicSubsNFunctions.dbreader["marks_attained_primary"]);
                }
                catch (Exception ex)
                {
                    id = 0.ToString();
                }

                publicSubsNFunctions.dbreader.Close();
            }

            return id;
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

        private void Button4_Click(object sender, EventArgs e)
        {
            reload();
            if (!publicSubsNFunctions.grade)
            {
                publicSubsNFunctions.grade = true;
                gradeview();
                btnGrade.Text = "Marks";
            }

            pointsview();
        }

        private void pointsview()
        {
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
            {
                for (int j = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; j <= loopTo1; j++)
                    dgvEnterMarks.Item(publicSubsNFunctions.subjname[j], k).value = publicSubsNFunctions.fix_point(Conversions.ToString(dgvEnterMarks.Item(publicSubsNFunctions.subjname[j], k).value));
                dgvEnterMarks["Total", k].Value = publicSubsNFunctions.fix_point(Conversions.ToString(dgvEnterMarks["Total", k].Value));
            }
        }

        private string Examination_Message(string adm)
        {
            string Message = null;
            if (publicSubsNFunctions.mode)
            {
                for (int k = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo; k++)
                {
                    Message = Conversions.ToString(Message + publicSubsNFunctions.exam_names[k]);
                    if (k < publicSubsNFunctions.exam_names.Length - 1)
                    {
                        Message += "/";
                    }
                }
            }
            else
            {
                Message = publicSubsNFunctions.exam_name;
            }

            Message += ":";
            for (int k = 0, loopTo1 = dgvEnterMarks.Rows.Count - 1; k <= loopTo1; k++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["ADMNo", k].Value, adm, false)))
                {
                    Message = Conversions.ToString(Message + Operators.ConcatenateObject(publicSubsNFunctions.get_fname(adm), " "));
                    if (publicSubsNFunctions.mode)
                    {
                        for (int s = 0, loopTo2 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo2; s++)
                            Message = Conversions.ToString(Message + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.subjabb[s], "="), dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).Value), ","));
                        Message = Conversions.ToString(Message + Operators.ConcatenateObject(",M.G=", dgvEnterMarks["MG", k].Value));
                        Message = Conversions.ToString(Message + Operators.ConcatenateObject(",M.P=", dgvEnterMarks["MP", k].Value));
                        Message = Conversions.ToString(Message + Operators.ConcatenateObject(",T.P=", dgvEnterMarks["TP", k].Value));

                        // If grade Then
                        // Message &= "M.G=" & dgvEnterMarks.Item("Total", k).Value
                        // Else
                        // Message &= "Total=" & dgvEnterMarks.Item("Total", k).Value & "/" & subjabb.Length * 100
                        // End If

                        Message = Conversions.ToString(Message + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(",C.Pos=", dgvEnterMarks["Overall", k].Value), ",S.Pos="), dgvEnterMarks["Position", k].Value));
                    }
                    else
                    {
                        int mark = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                        for (int s = 0, loopTo3 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo3; s++)
                        {
                            try
                            {
                                Message = Conversions.ToString(Message + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.subjabb[s], "="), dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).Value), ","));
                            }
                            catch (Exception ex)
                            {
                                Message = Conversions.ToString(Message + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.subjabb[s], "="), dgvEnterMarks.Item(publicSubsNFunctions.subjname[s], k).Value), ","));
                            }
                        }

                        Message = Conversions.ToString(Message + Operators.ConcatenateObject(",M.G=", dgvEnterMarks["MG", k].Value));
                        Message = Conversions.ToString(Message + Operators.ConcatenateObject(",M.P=", dgvEnterMarks["MP", k].Value));
                        Message = Conversions.ToString(Message + Operators.ConcatenateObject(",T.P=", dgvEnterMarks["TP", k].Value));

                        // If grade Then
                        // Message &= "M.G=" & dgvEnterMarks.Item("Total", k).Value
                        // Else
                        // Message &= "Total=" & dgvEnterMarks.Item("Total", k).Value & "/" & subjabb.Length * mark
                        // End If

                        Message = Conversions.ToString(Message + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(",C.Pos=", dgvEnterMarks["Overall", k].Value), ",S.Pos="), dgvEnterMarks["Position", k].Value));
                    }

                    break;
                }
            }

            return Message;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(!publicSubsNFunctions.confirm("Are You Sure You Want To Send The Results As Analysed Above To Parents/Guardians?")))
            {
                return;
            }

            Enabled = false;
            if (string.IsNullOrEmpty(My.MySettingsProperty.Settings.API))
            {
                Interaction.MsgBox("The API Key Is Missing");
                return;
            }

            if (string.IsNullOrEmpty(My.MySettingsProperty.Settings.APIUserName))
            {
                Interaction.MsgBox("The SMS Username Is Missing");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            for (int k = 0, loopTo = admnos.Length - 1; k <= loopTo; k++)
            {
                admnos[k] = Conversions.ToString(dgvEnterMarks["ADMNo", k].Value);
                SendSMS.sendMsg(Conversions.ToString(guardian_no(admnos[k])), Examination_Message(admnos[k]));
            }

            Cursor.Current = Cursors.Default;
            Interaction.MsgBox("The Student Results Have Been Sent");
            return;
            // OLD CODE
            publicSubsNFunctions.get_SMS_Details();

            // If String.IsNullOrEmpty(SMS_COM) Then
            // failure("The modem por has not been set")
            // Return
            // End If

            string modemPort = Interaction.InputBox("Enter Modem5 Port Number", "Enter Value", "Enter port number attached to the modem");
            if (string.IsNullOrEmpty(modemPort) | !Information.IsNumeric(modemPort))
            {
                publicSubsNFunctions.failure("The modem port number entered is either empty or the value it not a number");
                return;
            }

            publicSubsNFunctions.SMS_COM = modemPort;
            var SMSEngine = new sms(ref publicSubsNFunctions.SMS_COM);
            if (!SMSEngine.IsOpen)
            {
                var frm = new frmConfigureModem();
                frm.ShowDialog();
                publicSubsNFunctions.get_SMS_Details();
                SMSEngine = new sms(ref publicSubsNFunctions.SMS_COM);
            }

            if (!SMSEngine.IsOpen)
            {
                publicSubsNFunctions.failure("Could Not Automatically Configure your modem!");
                Enabled = true;
                return;
            }

            bool done = true;
            if (!publicSubsNFunctions.mode)
            {
                admnos = new string[dgvEnterMarks.Rows.Count - 5 + 1];
            }

            bool failed = false;
            for (int k = 0, loopTo1 = admnos.Length - 1; k <= loopTo1; k++)
            {
                admnos[k] = Conversions.ToString(dgvEnterMarks["ADMNo", k].Value);
                try
                {
                    SMSEngine.SendSMS(Conversions.ToString(guardian_no(admnos[k])), Examination_Message(admnos[k]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    publicSubsNFunctions.failure(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Could Not Send SMS To ", guardian_no(admnos[k])), ": Error: "), ex.Message)));
                }
            }

            if (!failed)
            {
                publicSubsNFunctions.success("If your modem is correctly configured and has enough airtime, the message was successfully sent!");
            }

            SMSEngine.Close();
            Enabled = true;
        }

        private object guardian_no(string adm)
        {
            publicSubsNFunctions.dbreader.Close();
            string phone = string.Empty;
            string result = string.Empty;
            string argq = "SELECT Phone FROM parents_guardians WHERE admin_no ='" + adm + "'";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                while (publicSubsNFunctions.dbreader.Read())
                {
                    phone = Conversions.ToString(publicSubsNFunctions.dbreader["Phone"]);
                    if (!string.IsNullOrEmpty(phone))
                    {
                        if (phone.StartsWith("0"))
                        {
                            phone = phone.Remove(0, 1);
                            phone = "+254" + phone;
                        }
                        else if (phone.StartsWith("7"))
                        {
                            phone = "+254" + phone;
                        }
                    }

                    if (phone.Length != 13)
                    {
                        phone = string.Empty;
                    }

                    result += "-" + phone;
                }
            }

            publicSubsNFunctions.dbreader.Close();
            return result;
        }

        private void create_query_sms(string no, string message)
        {
            publicSubsNFunctions.query += "(NULL,'" + no + "','" + publicSubsNFunctions.escape_string(message) + "','" + DateAndTime.Today.Date.Date + "','" + DateAndTime.Now.TimeOfDay.ToString() + "','False','','')";
        }

        private object issaved()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM term_results WHERE (class='", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "')"));
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

        private void save_as()
        {
            Pbar.Visible = true;
            int inc = (int)Math.Round(100d / dgvEnterMarks.Rows.Count - 5d);
            if (Conversions.ToBoolean(issaved()))
            {
                for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 5; k <= loopTo; k++)
                {
                    publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("DELETE FROM `class_performance_data` WHERE (ADMNo='", dgvEnterMarks["ADMNo", k].Value), "' AND term='"), publicSubsNFunctions.tm), "' AND Year='"), publicSubsNFunctions.yr), "' AND Class='"), publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "')")));
                    Pbar.Increment(inc);
                }

                publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("DELETE FROM term_results WHERE (class='", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "')")));
            }

            Pbar.Increment(-100);
            publicSubsNFunctions.query = "INSERT INTO `class_performance_data` VALUES";
            for (int k = 0, loopTo1 = dgvEnterMarks.Rows.Count - 5; k <= loopTo1; k++)
            {
                publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("('", dgvEnterMarks["ADMNo", k].Value), "','"), dgvEnterMarks["Overall", k].Value), " / "), dgvEnterMarks.Rows.Count - 4), "','"), dgvEnterMarks["MG", k].Value), "', '"), dgvEnterMarks["MP", k].Value), "', '"), publicSubsNFunctions.tm), "', '"), publicSubsNFunctions.yr), "', '"), publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "')"));
                if (k < dgvEnterMarks.Rows.Count - 5)
                {
                    publicSubsNFunctions.query += ",";
                }

                Pbar.Increment(inc);
            }

            publicSubsNFunctions.qwrite(publicSubsNFunctions.query);
            publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO term_results VALUES(NULL, '" + publicSubsNFunctions.tm + "','" + publicSubsNFunctions.yr + "','", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "')")));
            publicSubsNFunctions.success("End Of Term Results Successfully Saved!");
            Pbar.Visible = false;
            Pbar.Increment(-100);
        }

        private bool state = false;
        private int i;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
        }

        private bool all;
        private void Button1_Click_1(object sender, EventArgs e)
        {
            student = dgvEnterMarks.SelectedRows[0].Index;
            i = 0;
            if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Do You Want Result Slip For The Particular Selected Student? Click No To Print Result Slips For All Students")))
            {
                controller = dgvEnterMarks.SelectedRows[0].Index;
                all = false;
                Timer2.Enabled = true;
            }
            else if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Result Slip Processing Completed! Estimate Completion Time: " + (int)Math.Round((7 * dgvEnterMarks.Rows.Count - 5) / 60d / 3d) + " Minutes! No Interuptions Please! Continue?")))
            {
                controller = 0;
                Timer2.Enabled = true;
                all = true;
            }
        }

        private int controller;
        private void Timer2_Tick(object sender, EventArgs e)
        {
            Timer2.Enabled = false;
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_result_slip();
            print_document.DefaultPageSettings.Landscape = false;
            printpreview.Document = print_document;
            Print_Preview.Document = print_document;
            if (all)
            {
                print_document.Print();
                if (student >= dgvEnterMarks.Rows.Count - 5)
                {
                    Timer2.Enabled = false;
                }
                else
                {
                    Timer2.Enabled = true;
                }
            }
            else
            {
                Print_Preview.ShowDialog();
            }
        }

        private object print_student_result_slip()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_result_slip;
            return print_document;
        }

        private void print_result_slip(object sender, PrintPageEventArgs e)
        {
            int avg = 415;
            int subj_pos = 530;
            int remarks = 590;
            int teacher = 690;
            int pt = 495;
            int mg = 455;
            int exam_width = 50;
            int line, i, j;
            int left_margin = 80;
            int right_margin = 800;
            int topline = 170;
            string perf = null;
            float CenterPage;
            Pen Graphpen;
            Brush Avgpen, RemarksPen, Teacherpen, PointPen, Subjectpen, Mgpen;
            if (report.color == true)
            {
                Graphpen = new Pen(Color.Red, 2f);
                Avgpen = Brushes.Blue;
                RemarksPen = Brushes.Red;
                Teacherpen = Brushes.Blue;
                Subjectpen = Brushes.Black;
                Mgpen = Brushes.Red;
                PointPen = Brushes.Blue;
            }
            else
            {
                Graphpen = new Pen(Color.Black, 2f);
                Avgpen = Brushes.Black;
                PointPen = Brushes.Black;
                RemarksPen = Brushes.Black;
                Teacherpen = Brushes.Black;
                Subjectpen = Brushes.Black;
                Mgpen = Brushes.Black;
            }

            try
            {
                exam_width = (int)Math.Round((avg - (left_margin + 210) + 70) / (double)publicSubsNFunctions.tables.Length);
            }
            catch (Exception ex)
            {
                exam_width = avg - (left_margin + 210);
            }

            line = 20;
            if (all)
            {
                for (int count = 0; count <= 1; count++)
                {
                    if (count == 1)
                    {
                        topline = line + 150;
                    }

                    if (report.school_logo)
                    {
                        try
                        {
                            e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + logo()), left_margin + 10, topline - 155, 90, 90);
                        }
                        catch (Exception ex)
                        {
                            Timer1.Enabled = false;
                            if (!mode_view)
                            {
                                Timer1.Enabled = true;
                            }
                        }
                    }

                    if (report.student_photo)
                    {
                        try
                        {
                            e.Graphics.DrawImage(Image.FromFile(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.path + @"\student_images\", dgvEnterMarks["ADMNo", student].Value), ".jpg"))), right_margin - 110, topline - 155, 90, 90);
                        }
                        catch (Exception ex)
                        {
                            Timer1.Enabled = false;
                            if (!mode_view)
                            {
                                Timer1.Enabled = true;
                            }
                        }
                    }

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

                    // If S_EMAIL <> "" Then
                    // CenterPage = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString("EMAIL ADDRESS: " & S_EMAIL, other_font).Width / 2)
                    // e.Graphics.DrawString("EMAIL ADDRESS: " & S_EMAIL, other_font, Brushes.Black, CenterPage, line)
                    // line += other_font.Height + 5
                    // End If
                    line -= 5;
                    CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("STUDENT RESULT SLIP", publicSubsNFunctions.other_font).Width / 2f);
                    e.Graphics.DrawString("STUDENT RESULT SLIP", publicSubsNFunctions.header_font, Avgpen, CenterPage, line);
                    line += publicSubsNFunctions.header_font.Height + 10;
                    e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3);
                    e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
                    e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
                    line += 10;
                    e.Graphics.DrawString("NAME OF STUDENT:__________________________________________________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["StudentName", student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + 150, line - 3);
                    e.Graphics.DrawString("ADMISSION NUMBER:_____________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 500, line);
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + 650, line - 3);
                    line += 25;
                    e.Graphics.DrawString("CLASS:_______________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), publicSubsNFunctions.other_font, Avgpen, left_margin + 60, line - 3);
                    e.Graphics.DrawString("STREAM:________________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 150, line);
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["str_class", student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + 230, line - 3);
                    e.Graphics.DrawString("TERM:_______", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 300, line);
                    e.Graphics.DrawString(publicSubsNFunctions.tm, publicSubsNFunctions.other_font, Avgpen, left_margin + 350, line - 3);
                    e.Graphics.DrawString("YEAR:_________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 400, line);
                    e.Graphics.DrawString(publicSubsNFunctions.yr.ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + 450, line - 3);
                    e.Graphics.DrawString("DORMITORY:_________________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 500, line);
                    e.Graphics.DrawString(Conversions.ToString(dormitory(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value))), publicSubsNFunctions.other_font, Avgpen, left_margin + 580, line - 3);
                    line = topline;
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
                    e.Graphics.DrawString("SUBJECT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                    j = 210;
                    try
                    {
                        if (publicSubsNFunctions.tables.Length > 1)
                        {
                            var loopTo = publicSubsNFunctions.tables.Length - 1;
                            for (i = 0; i <= loopTo; i++)
                            {
                                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.exam_names[i].ToUpper, " /"), publicSubsNFunctions.total_mark[i]), string.Empty)), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + j, line);
                                j += exam_width;
                            }
                        }
                        else
                        {
                            publicSubsNFunctions.marks = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                            e.Graphics.DrawString(publicSubsNFunctions.exam_name.ToUpper().ToString().Substring(0, 4) + " /" + publicSubsNFunctions.marks + string.Empty, publicSubsNFunctions.other_font, Brushes.Black, left_margin + j, line);
                        }
                    }
                    catch (Exception ex)
                    {
                        // marks = get_total_mark(exam_name, tm)
                        // e.Graphics.DrawString(exam_name.ToUpper.ToString.Substring(0, 4) & " /" & marks & "", other_font, Brushes.Black, left_margin + j, line)
                    }

                    e.Graphics.DrawString("AVG", publicSubsNFunctions.other_font, Avgpen, left_margin + avg, line);
                    e.Graphics.DrawString("PTS", publicSubsNFunctions.other_font, PointPen, left_margin + pt, line);
                    e.Graphics.DrawString("M.G.", publicSubsNFunctions.other_font, Mgpen, left_margin + mg, line);
                    e.Graphics.DrawString("S.POS", publicSubsNFunctions.other_font, Mgpen, left_margin + subj_pos, line);
                    e.Graphics.DrawString("REMARKS", publicSubsNFunctions.other_font, RemarksPen, left_margin + remarks, line);
                    e.Graphics.DrawString("T.I", publicSubsNFunctions.other_font, Teacherpen, left_margin + teacher, line);
                    line += 20;
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
                    double totals = default, totals_avg = default, totals_avg_cnt = default;
                    int no = Conversions.ToInteger(no_of_subjects(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value)));
                    if (!publicSubsNFunctions.mode)
                    {
                        int total_mark = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                        if (publicSubsNFunctions.grade)
                        {
                            for (int k = 0, loopTo1 = subjects_done.Length - 1; k <= loopTo1; k++)
                            {
                                totals = Conversions.ToDouble(totals + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100));
                                totals_avg = Conversions.ToDouble(totals_avg + dgvEnterMarks[subjects_done_name[k], student].Value);
                                totals_avg_cnt += 1d;
                                e.Graphics.DrawString(Conversions.ToInteger(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)).ToString(), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                                e.Graphics.DrawString(Conversions.ToInteger(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)).ToString(), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + avg + 5, line);
                                line += 20;
                            }
                        }
                        else
                        {
                            for (int k = 0, loopTo2 = subjects_done.Length - 1; k <= loopTo2; k++)
                            {
                                if (Information.IsNumeric(dgvEnterMarks[subjects_done_name[k], student].Value))
                                {
                                    totals = Conversions.ToDouble(totals + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100));
                                    totals_avg = Conversions.ToDouble(totals_avg + dgvEnterMarks[subjects_done_name[k], student].Value);
                                    totals_avg_cnt += 1d;
                                    if (report.color)
                                    {
                                        e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks[subjects_done_name[k], student].Value, " "), publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[subjects_done_name[k], student].Value), radSubject.Checked, subjects_done_abb[k]))), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                                    }
                                    else
                                    {
                                        e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks[subjects_done_name[k], student].Value, " "), publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)), radSubject.Checked, subjects_done_abb[k]))), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 220, line);
                                    }

                                    e.Graphics.DrawString(Conversions.ToInteger(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)).ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                                    try
                                    {
                                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)), radSubject.Checked, subjects_done_abb[k])))), publicSubsNFunctions.other_font, Brushes.Black, left_margin + pt, line);
                                    }
                                    catch (Exception ex)
                                    {
                                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt, line);
                                    }
                                }
                                else
                                {
                                    if (report.color)
                                    {
                                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                                    }
                                    else
                                    {
                                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 220, line);
                                    }

                                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                                }

                                line += 20;
                            }
                        }

                        e.Graphics.DrawString(totals_avg + "/" + publicSubsNFunctions.marks * totals_avg_cnt, publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                        e.Graphics.DrawString(((int)Math.Round(totals)).ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["TP", student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 5, line);
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 5, line);
                        line = topline + 20;
                        for (int k = 0, loopTo3 = subjects_done.Length - 1; k <= loopTo3; k++)
                        {
                            try
                            {
                                e.Graphics.DrawString(publicSubsNFunctions.get_comment(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)), radSubject.Checked, subjects_done_abb[k])), radSubject.Checked, subjects_done_abb[k]), publicSubsNFunctions.italisized_font, RemarksPen, left_margin + remarks, line);
                            }
                            catch (Exception ex)
                            {
                                e.Graphics.DrawString("-", publicSubsNFunctions.italisized_font, RemarksPen, left_margin + remarks, line);
                            }

                            if (publicSubsNFunctions.grade)
                            {
                                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg, line);
                            }
                            else
                            {
                                try
                                {
                                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)), radSubject.Checked, subjects_done_abb[k])), publicSubsNFunctions.other_font, Mgpen, left_margin + mg, line);
                                }
                                catch (Exception ex)
                                {
                                    e.Graphics.DrawString("-", publicSubsNFunctions.other_font, Mgpen, left_margin + mg, line);
                                }
                            }

                            line += 20;
                        }
                    }
                    else
                    {
                        j = 210;
                        double total_;
                        var loopTo4 = publicSubsNFunctions.tables.Length - 1;
                        for (i = 0; i <= loopTo4; i++)
                        {
                            publicSubsNFunctions.marks = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(Conversions.ToString(publicSubsNFunctions.exam_names[i]), publicSubsNFunctions.tm));
                            total_ = 0d;
                            line = topline + 20;
                            int tot_cnt = 0;
                            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE ADMNo='", dgvEnterMarks["ADMNo", student].Value), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.tables[i])), "' AND Term='"), publicSubsNFunctions.tm), "' AND Year='"), publicSubsNFunctions.yr), "'"));
                            if (publicSubsNFunctions.qread(ref argq))
                            {
                                tot_cnt = 0;
                                tot_cnt = 0;
                                publicSubsNFunctions.dbreader.Read();
                                for (int k = 0, loopTo5 = subjects_done.Length - 1; k <= loopTo5; k++)
                                {
                                    try
                                    {
                                        e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.dbreader[subjects_done_abb[k]], " "), publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[subjects_done_abb[k]], publicSubsNFunctions.total_mark[i]), 100)), radSubject.Checked, subjects_done_abb[k]))), publicSubsNFunctions.other_font, Brushes.Black, left_margin + j + 2, line);
                                        total_ = Conversions.ToDouble(total_ + publicSubsNFunctions.dbreader[subjects_done_abb[k]]);
                                        tot_cnt += 1;
                                    }
                                    catch (Exception ex)
                                    {
                                    }

                                    line += 20;
                                }

                                if (chkMode.Checked)
                                {
                                    var tot = default(double);
                                    for (int k = 0, loopTo6 = subjects_7.Length - 1; k <= loopTo6; k++)
                                    {
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(subjects_7[k][8], dgvEnterMarks["ADMNo", student].Value.ToString(), false)))
                                        {
                                            tot = 0d;
                                            for (int c = 0, loopTo7 = subjects_7[k].Length - 2; c <= loopTo7; c++)
                                            {
                                                try
                                                {
                                                    tot = Conversions.ToDouble(tot + publicSubsNFunctions.dbreader[subjects_7[k][c].ToString()]);
                                                    tot_cnt += 1;
                                                }
                                                catch (Exception ex)
                                                {
                                                }
                                            }

                                            break;
                                        }
                                    }

                                    e.Graphics.DrawString(tot + "/" + publicSubsNFunctions.marks * tot_cnt, publicSubsNFunctions.other_font, Brushes.Black, left_margin + j + 2, line);
                                }
                                else
                                {
                                    e.Graphics.DrawString(total_ + "/" + publicSubsNFunctions.marks * tot_cnt, publicSubsNFunctions.other_font, Brushes.Black, left_margin + j + 2, line);
                                }

                                j += exam_width;
                                line = 330;
                                publicSubsNFunctions.dbreader.Close();
                            }
                        }

                        line = topline + 20;
                        for (int k = 0, loopTo8 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo8; k++)
                        {
                            try
                            {
                                e.Graphics.DrawString(publicSubsNFunctions.get_comment(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[subjects_done_name[k], student].Value), radSubject.Checked, subjects_done_abb[k])), radSubject.Checked, subjects_done_abb[k]), publicSubsNFunctions.italisized_font, RemarksPen, left_margin + remarks, line);
                            }
                            catch (Exception ex)
                            {
                                e.Graphics.DrawString("-", publicSubsNFunctions.italisized_font, RemarksPen, left_margin + remarks, line);
                            }

                            if (publicSubsNFunctions.grade)
                            {
                                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.fix_point(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value))), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 4, line);
                                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 4, line);
                            }
                            else
                            {
                                try
                                {
                                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[subjects_done_name[k], student].Value), radSubject.Checked, subjects_done_abb[k])))), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 4, line);
                                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[subjects_done_name[k], student].Value), radSubject.Checked, subjects_done_abb[k])), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 4, line);
                                }
                                catch (Exception ex)
                                {
                                }
                            }

                            line += 20;
                        }

                        line = topline + 20;
                        if (publicSubsNFunctions.grade)
                        {
                            for (int k = 0, loopTo9 = subjects_done.Length - 1; k <= loopTo9; k++)
                            {
                                totals = Conversions.ToDouble(totals + dgvEnterMarks[subjects_done_name[k], student].Value);
                                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                                line += 20;
                            }

                            e.Graphics.DrawString(totals.ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["TP", student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 5, line);
                            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 5, line);
                        }
                        else
                        {
                            for (int k = 0, loopTo10 = subjects_done.Length - 1; k <= loopTo10; k++)
                            {
                                try
                                {
                                    totals = Conversions.ToDouble(totals + dgvEnterMarks[subjects_done_name[k], student].Value);
                                }
                                catch (Exception ex)
                                {
                                }

                                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                                line += 20;
                            }

                            e.Graphics.DrawString(totals.ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["TP", student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 5, line);
                            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 5, line);
                        }
                    }

                    line = topline + 20;
                    for (int k = 0, loopTo11 = subjects_done.Length - 1; k <= loopTo11; k++)
                    {
                        if (subjects_done[k].Length >= 22)
                        {
                            e.Graphics.DrawString(subjects_done[k].Substring(0, 22), publicSubsNFunctions.other_font, Subjectpen, left_margin + 2, line);
                        }
                        else
                        {
                            e.Graphics.DrawString(subjects_done[k], publicSubsNFunctions.other_font, Subjectpen, left_margin + 2, line);
                        }

                        e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subject_teacher(Conversions.ToString(dgvEnterMarks["str_class", student].Value), publicSubsNFunctions.class_form, publicSubsNFunctions.tm, Conversions.ToInteger(publicSubsNFunctions.yr.ToString().Substring(2)), subjects_done_abb[k])), publicSubsNFunctions.other_font, Teacherpen, left_margin + teacher, line);
                        e.Graphics.DrawString(Conversions.ToString(subject_rank_only(subjects_done_name[k], Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), Conversions.ToString(dgvEnterMarks["str_class", student].Value))), publicSubsNFunctions.other_font, Mgpen, left_margin + subj_pos, line);
                        line += 20;
                        e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
                    }

                    if (publicSubsNFunctions.grade)
                    {
                        e.Graphics.DrawString("MEAN GRADE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                    }
                    else
                    {
                        e.Graphics.DrawString("TOTAL MARKS/PTS", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                    }

                    line += 20;
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
                    e.Graphics.DrawString("POSITION", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                    j = 210;
                    if (publicSubsNFunctions.mode)
                    {
                        for (int k = 0, loopTo12 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo12; k++)
                        {
                            e.Graphics.DrawString(Conversions.ToString(position_in_exam(Conversions.ToString(publicSubsNFunctions.exam_names[k]))), publicSubsNFunctions.other_font, Brushes.Black, left_margin + j, line);
                            j += exam_width;
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString(Conversions.ToString(position_in_exam(publicSubsNFunctions.exam_name)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + j, line);
                    }

                    line += 20;
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline - 2, left_margin - 2, line);
                    j = 210;
                    try
                    {
                        var loopTo13 = publicSubsNFunctions.tables.Length - 1;
                        for (i = 0; i <= loopTo13; i++)
                        {
                            e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line);
                            j += exam_width;
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line);
                    }

                    e.Graphics.DrawLine(Pens.Black, left_margin + avg - 2, topline - 2, left_margin + avg - 2, line);
                    e.Graphics.DrawLine(Pens.Black, left_margin + pt - 2, topline - 2, left_margin + pt - 2, line);
                    e.Graphics.DrawLine(Pens.Black, left_margin + mg - 2, topline - 2, left_margin + mg - 2, line);
                    e.Graphics.DrawLine(Pens.Black, left_margin + subj_pos - 2, topline - 2, left_margin + subj_pos - 2, line);
                    e.Graphics.DrawLine(Pens.Black, left_margin + remarks - 2, topline - 2, left_margin + remarks - 2, line);
                    e.Graphics.DrawLine(Pens.Black, left_margin + teacher - 2, topline - 2, left_margin + teacher - 2, line);
                    e.Graphics.DrawLine(Pens.Black, right_margin + 2, topline - 2, right_margin + 2, line);
                    line += 10;
                    int stream_out_of = 0;
                    var loopTo14 = publicSubsNFunctions.streams.Length - 1;
                    for (i = 0; i <= loopTo14; i++)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", student].Value, publicSubsNFunctions.streams[i], false)))
                        {
                            stream_out_of = stream_no[i];
                        }
                    }

                    e.Graphics.DrawString("CLASS POSITION:________________", publicSubsNFunctions.medium, Avgpen, left_margin + 2, line);
                    e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks["Overall", student].Value, " Out Of "), dgvEnterMarks.Rows.Count - 4)), publicSubsNFunctions.medium, RemarksPen, left_margin + 120, line - 2);
                    e.Graphics.DrawString("STREAM POSITION:_______________", publicSubsNFunctions.medium, Avgpen, left_margin + 220, line);
                    e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks["Position", student].Value, " Out Of "), stream_out_of - 1)), publicSubsNFunctions.medium, RemarksPen, left_margin + 350, line - 2);
                    e.Graphics.DrawString("MEAN GRADE:____", publicSubsNFunctions.medium, Avgpen, left_margin + 450, line);
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.medium, RemarksPen, left_margin + 545, line - 2);
                    e.Graphics.DrawString("MEAN POINTS:________", publicSubsNFunctions.medium, Avgpen, left_margin + 570, line);
                    if (Information.IsNumeric(dgvEnterMarks["MP", student].Value))
                    {
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MP", student].Value), publicSubsNFunctions.medium, RemarksPen, left_margin + 665, line - 5);
                    }
                    else
                    {
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.medium, RemarksPen, left_margin + 665, line - 5);
                    }

                    if (student == dgvEnterMarks.Rows.Count - 4)
                    {
                        break;
                    }

                    student += 1;
                    line += 100;
                }
            }
            else
            {
                if (report.school_logo)
                {
                    try
                    {
                        e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + logo()), left_margin + 10, 10, 90, 90);
                    }
                    catch (Exception ex)
                    {
                        Timer1.Enabled = false;
                        if (!mode_view)
                        {
                            Timer1.Enabled = true;
                        }
                    }
                }

                if (report.student_photo)
                {
                    try
                    {
                        e.Graphics.DrawImage(Image.FromFile(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.path + @"\student_images\", dgvEnterMarks["ADMNo", student].Value), ".jpg"))), right_margin - 110, 10, 90, 90);
                    }
                    catch (Exception ex)
                    {
                        Timer1.Enabled = false;
                        if (!mode_view)
                        {
                            Timer1.Enabled = true;
                        }
                    }
                }

                if ((publicSubsNFunctions.S_NAME ?? "") != (string.Empty ?? ""))
                {
                    CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font).Width / 2f);
                    e.Graphics.DrawString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font, Avgpen, CenterPage, line);
                    line += publicSubsNFunctions.header_font.Height + 2;
                }

                if ((publicSubsNFunctions.S_ADDRESS ?? "") != (string.Empty ?? ""))
                {
                    CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("P.O. BOX " + publicSubsNFunctions.S_ADDRESS.ToUpper() + ", " + publicSubsNFunctions.S_LOCATION.ToUpper(), publicSubsNFunctions.other_font).Width / 2f);
                    e.Graphics.DrawString("P.O. BOX " + publicSubsNFunctions.S_ADDRESS.ToUpper() + ", " + publicSubsNFunctions.S_LOCATION.ToUpper(), publicSubsNFunctions.other_font, Avgpen, CenterPage, line);
                    line += publicSubsNFunctions.other_font.Height + 5;
                }

                if ((publicSubsNFunctions.S_PHONE ?? "") != (string.Empty ?? ""))
                {
                    CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("TELEPHONE: " + publicSubsNFunctions.S_PHONE, publicSubsNFunctions.other_font).Width / 2f);
                    e.Graphics.DrawString("TELEPHONE: " + publicSubsNFunctions.S_PHONE, publicSubsNFunctions.other_font, Avgpen, CenterPage, line);
                    line += publicSubsNFunctions.other_font.Height + 5;
                }

                if ((publicSubsNFunctions.S_EMAIL ?? "") != (string.Empty ?? ""))
                {
                    CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("EMAIL ADDRESS: " + publicSubsNFunctions.S_EMAIL, publicSubsNFunctions.other_font).Width / 2f);
                    e.Graphics.DrawString("EMAIL ADDRESS: " + publicSubsNFunctions.S_EMAIL, publicSubsNFunctions.other_font, Avgpen, CenterPage, line);
                    line += publicSubsNFunctions.other_font.Height + 5;
                }

                line -= 5;
                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("STUDENT RESULT SLIP", publicSubsNFunctions.header_font).Width / 2f);
                e.Graphics.DrawString("STUDENT RESULT SLIP", publicSubsNFunctions.header_font, Avgpen, CenterPage, line + 5);
                line += publicSubsNFunctions.header_font.Height + 10;
                e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3);
                e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
                e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
                line += 10;
                e.Graphics.DrawString("NAME OF STUDENT:_______________________________________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["StudentName", student].Value), publicSubsNFunctions.medium_larger, Avgpen, left_margin + 150, line - 8);
                e.Graphics.DrawString("ADMISSION NUMBER:_______", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 500, line);
                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value), publicSubsNFunctions.medium_larger, Avgpen, left_margin + 680, line - 8);
                line += 25;
                e.Graphics.DrawString("CLASS:_________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                e.Graphics.DrawString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper(), publicSubsNFunctions.other_font, Avgpen, left_margin + 60, line - 3);
                e.Graphics.DrawString("STREAM:_________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 150, line);
                e.Graphics.DrawString(dgvEnterMarks["str_class", student].Value.ToString().ToUpper(), publicSubsNFunctions.other_font, Avgpen, left_margin + 220, line - 3);
                e.Graphics.DrawString("TERM:_____", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 300, line);
                e.Graphics.DrawString(publicSubsNFunctions.tm, publicSubsNFunctions.other_font, Avgpen, left_margin + 350, line - 2);
                e.Graphics.DrawString("YEAR:______", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 400, line);
                e.Graphics.DrawString(publicSubsNFunctions.yr.ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + 450, line - 3);
                e.Graphics.DrawString("DORMITORY:_____________", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 500, line);
                e.Graphics.DrawString(dormitory(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value)).ToString().ToUpper(), publicSubsNFunctions.other_font, Avgpen, left_margin + 600, line - 3);
                line = topline;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
                e.Graphics.DrawString("SUBJECT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                j = 210;
                try
                {
                    if (publicSubsNFunctions.tables.Length > 1)
                    {
                        var loopTo15 = publicSubsNFunctions.tables.Length - 1;
                        for (i = 0; i <= loopTo15; i++)
                        {
                            e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.exam_names[i].ToUpper, " /"), publicSubsNFunctions.total_mark[i]), string.Empty)), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + j, line);
                            j += exam_width;
                        }
                    }
                    else
                    {
                        publicSubsNFunctions.marks = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                        e.Graphics.DrawString(publicSubsNFunctions.exam_name.ToUpper().ToString().Substring(0, 4) + " /" + publicSubsNFunctions.marks + string.Empty, publicSubsNFunctions.other_font, Brushes.Black, left_margin + j, line);
                    }
                }
                catch (Exception ex)
                {
                    publicSubsNFunctions.marks = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                    e.Graphics.DrawString(publicSubsNFunctions.exam_name.ToUpper().ToString().Substring(0, 4) + " /" + publicSubsNFunctions.marks + string.Empty, publicSubsNFunctions.other_font, Brushes.Black, left_margin + j, line);
                }

                e.Graphics.DrawString("AVG", publicSubsNFunctions.other_font, Avgpen, left_margin + avg, line);
                e.Graphics.DrawString("PTS", publicSubsNFunctions.other_font, PointPen, left_margin + pt, line);
                e.Graphics.DrawString("M.G.", publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 3, line);
                e.Graphics.DrawString("S.POS", publicSubsNFunctions.other_font, Mgpen, left_margin + subj_pos, line);
                e.Graphics.DrawString("REMARKS", publicSubsNFunctions.other_font, RemarksPen, left_margin + remarks, line);
                e.Graphics.DrawString("T.I", publicSubsNFunctions.other_font, Teacherpen, left_margin + teacher, line);
                line += 20;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
                double totals = default, totals_avg = default, totals_avg_cnt = default;
                int no = Conversions.ToInteger(no_of_subjects(Conversions.ToString(dgvEnterMarks["ADMNo", student].Value)));
                if (!publicSubsNFunctions.mode)
                {
                    int total_mark = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
                    if (publicSubsNFunctions.grade)
                    {
                        for (int k = 0, loopTo16 = subjects_done.Length - 1; k <= loopTo16; k++)
                        {
                            totals = Conversions.ToDouble(totals + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100));
                            totals_avg = Conversions.ToDouble(totals_avg + dgvEnterMarks[subjects_done_name[k], student].Value);
                            totals_avg_cnt += 1d;
                            e.Graphics.DrawString(Conversions.ToInteger(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)).ToString(), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                            e.Graphics.DrawString(Conversions.ToInteger(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)).ToString(), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + avg + 5, line);
                            line += 20;
                        }
                    }
                    else
                    {
                        for (int k = 0, loopTo17 = subjects_done.Length - 1; k <= loopTo17; k++)
                        {
                            if (Information.IsNumeric(dgvEnterMarks[subjects_done_name[k], student].Value))
                            {
                                totals = Conversions.ToDouble(totals + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100));
                                totals_avg = Conversions.ToDouble(totals_avg + dgvEnterMarks[subjects_done_name[k], student].Value);
                                totals_avg_cnt += 1d;
                                if (report.color)
                                {
                                    e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks[subjects_done_name[k], student].Value, " "), publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[subjects_done_name[k], student].Value), radSubject.Checked, subjects_done_abb[k]))), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks[subjects_done_name[k], student].Value, " "), publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)), radSubject.Checked, subjects_done_abb[k]))), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 220, line);
                                }

                                e.Graphics.DrawString(Conversions.ToInteger(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)).ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                                try
                                {
                                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)), radSubject.Checked, subjects_done_abb[k])))), publicSubsNFunctions.other_font, Brushes.Black, left_margin + pt, line);
                                }
                                catch (Exception ex)
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt, line);
                                }
                            }
                            else
                            {
                                if (report.color)
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 220, line);
                                }

                                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                            }

                            line += 20;
                        }
                    }

                    e.Graphics.DrawString(totals_avg + "/" + publicSubsNFunctions.marks * totals_avg_cnt, publicSubsNFunctions.other_font, Brushes.DarkBlue, left_margin + 220, line);
                    e.Graphics.DrawString(((int)Math.Round(totals)).ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["TP", student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 5, line);
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 5, line);
                    line = topline + 20;
                    for (int k = 0, loopTo18 = subjects_done.Length - 1; k <= loopTo18; k++)
                    {
                        try
                        {
                            e.Graphics.DrawString(publicSubsNFunctions.get_comment(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)), radSubject.Checked, subjects_done_abb[k])), radSubject.Checked, subjects_done_abb[k]), publicSubsNFunctions.italisized_font, RemarksPen, left_margin + remarks, line);
                        }
                        catch (Exception ex)
                        {
                            e.Graphics.DrawString("-", publicSubsNFunctions.italisized_font, RemarksPen, left_margin + remarks, line);
                        }

                        if (publicSubsNFunctions.grade)
                        {
                            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg, line);
                        }
                        else
                        {
                            try
                            {
                                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[subjects_done_name[k], student].Value, total_mark), 100)), radSubject.Checked, subjects_done_abb[k])), publicSubsNFunctions.other_font, Mgpen, left_margin + mg, line);
                            }
                            catch (Exception ex)
                            {
                                e.Graphics.DrawString("-", publicSubsNFunctions.other_font, Mgpen, left_margin + mg, line);
                            }
                        }

                        line += 20;
                    }
                }
                else
                {
                    j = 210;
                    double total_;
                    var loopTo19 = publicSubsNFunctions.tables.Length - 1;
                    for (i = 0; i <= loopTo19; i++)
                    {
                        publicSubsNFunctions.marks = Conversions.ToInteger(publicSubsNFunctions.get_total_mark(Conversions.ToString(publicSubsNFunctions.exam_names[i]), publicSubsNFunctions.tm));
                        total_ = 0d;
                        line = topline + 20;
                        int tot_cnt = 0;
                        string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE ADMNo='", dgvEnterMarks["ADMNo", student].Value), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.tables[i])), "' AND Term='"), publicSubsNFunctions.tm), "' AND Year='"), publicSubsNFunctions.yr), "'"));
                        if (publicSubsNFunctions.qread(ref argq1))
                        {
                            tot_cnt = 0;
                            tot_cnt = 0;
                            publicSubsNFunctions.dbreader.Read();
                            for (int k = 0, loopTo20 = subjects_done.Length - 1; k <= loopTo20; k++)
                            {
                                try
                                {
                                    e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.dbreader[subjects_done_abb[k]], " "), publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader[subjects_done_abb[k]], publicSubsNFunctions.total_mark[i]), 100)), radSubject.Checked, subjects_done_abb[k]))), publicSubsNFunctions.other_font, Brushes.Black, left_margin + j + 2, line);
                                    total_ = Conversions.ToDouble(total_ + publicSubsNFunctions.dbreader[subjects_done_abb[k]]);
                                    tot_cnt += 1;
                                }
                                catch (Exception ex)
                                {
                                }

                                line += 20;
                            }

                            if (chkMode.Checked)
                            {
                                var tot = default(double);
                                for (int k = 0, loopTo21 = subjects_7.Length - 1; k <= loopTo21; k++)
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(subjects_7[k][8], dgvEnterMarks["ADMNo", student].Value.ToString(), false)))
                                    {
                                        tot = 0d;
                                        for (int c = 0, loopTo22 = subjects_7[k].Length - 2; c <= loopTo22; c++)
                                        {
                                            try
                                            {
                                                tot = Conversions.ToDouble(tot + publicSubsNFunctions.dbreader[subjects_7[k][c].ToString()]);
                                                tot_cnt += 1;
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                        }

                                        break;
                                    }
                                }

                                e.Graphics.DrawString(tot + "/" + publicSubsNFunctions.marks * tot_cnt, publicSubsNFunctions.other_font, Brushes.Black, left_margin + j + 2, line);
                            }
                            else
                            {
                                e.Graphics.DrawString(total_ + "/" + publicSubsNFunctions.marks * tot_cnt, publicSubsNFunctions.other_font, Brushes.Black, left_margin + j + 2, line);
                            }

                            j += exam_width;
                            line = 330;
                            publicSubsNFunctions.dbreader.Close();
                        }
                    }

                    line = topline + 20;
                    for (int k = 0, loopTo23 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo23; k++)
                    {
                        try
                        {
                            e.Graphics.DrawString(publicSubsNFunctions.get_comment(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[subjects_done_name[k], student].Value), radSubject.Checked, subjects_done_abb[k])), radSubject.Checked, subjects_done_abb[k]), publicSubsNFunctions.italisized_font, RemarksPen, left_margin + remarks, line);
                        }
                        catch (Exception ex)
                        {
                            e.Graphics.DrawString("-", publicSubsNFunctions.italisized_font, RemarksPen, left_margin + remarks, line);
                        }

                        if (publicSubsNFunctions.grade)
                        {
                            e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.fix_point(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value))), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 4, line);
                            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 4, line);
                        }
                        else
                        {
                            try
                            {
                                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[subjects_done_name[k], student].Value), radSubject.Checked, subjects_done_abb[k])))), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 4, line);
                                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(dgvEnterMarks[subjects_done_name[k], student].Value), radSubject.Checked, subjects_done_abb[k])), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 4, line);
                            }
                            catch (Exception ex)
                            {
                            }
                        }

                        line += 20;
                    }

                    line = topline + 20;
                    if (publicSubsNFunctions.grade)
                    {
                        for (int k = 0, loopTo24 = subjects_done.Length - 1; k <= loopTo24; k++)
                        {
                            totals = Conversions.ToDouble(totals + dgvEnterMarks[subjects_done_name[k], student].Value);
                            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                            line += 20;
                        }

                        e.Graphics.DrawString(totals.ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["TP", student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 5, line);
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 5, line);
                    }
                    else
                    {
                        for (int k = 0, loopTo25 = subjects_done.Length - 1; k <= loopTo25; k++)
                        {
                            try
                            {
                                totals = Conversions.ToDouble(totals + dgvEnterMarks[subjects_done_name[k], student].Value);
                            }
                            catch (Exception ex)
                            {
                            }

                            e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                            line += 20;
                        }

                        e.Graphics.DrawString(totals.ToString(), publicSubsNFunctions.other_font, Avgpen, left_margin + avg + 5, line);
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["TP", student].Value), publicSubsNFunctions.other_font, PointPen, left_margin + pt + 5, line);
                        e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.other_font, Mgpen, left_margin + mg + 5, line);
                    }
                }

                line = topline + 20;
                for (int k = 0, loopTo26 = subjects_done.Length - 1; k <= loopTo26; k++)
                {
                    if (subjects_done[k].Length >= 22)
                    {
                        e.Graphics.DrawString(subjects_done[k].Substring(0, 22), publicSubsNFunctions.other_font, Subjectpen, left_margin + 2, line);
                    }
                    else
                    {
                        e.Graphics.DrawString(subjects_done[k], publicSubsNFunctions.other_font, Subjectpen, left_margin + 2, line);
                    }

                    e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subject_teacher(Conversions.ToString(dgvEnterMarks["str_class", student].Value), publicSubsNFunctions.class_form, publicSubsNFunctions.tm, Conversions.ToInteger(publicSubsNFunctions.yr.ToString().Substring(2)), subjects_done_abb[k])), publicSubsNFunctions.smallfont, Teacherpen, left_margin + teacher, line);
                    e.Graphics.DrawString(Conversions.ToString(subject_rank_only(subjects_done_name[k], Conversions.ToString(dgvEnterMarks[subjects_done_name[k], student].Value), Conversions.ToString(dgvEnterMarks["str_class", student].Value))), publicSubsNFunctions.other_font, Mgpen, left_margin + subj_pos, line);
                    line += 20;
                    e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
                }

                if (publicSubsNFunctions.grade)
                {
                    e.Graphics.DrawString("MEAN GRADE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                }
                else
                {
                    e.Graphics.DrawString("TOTAL MARKS/PTS", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                }

                line += 20;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
                e.Graphics.DrawString("POSITION", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 2, line);
                j = 210;
                if (publicSubsNFunctions.mode)
                {
                    for (int k = 0, loopTo27 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo27; k++)
                    {
                        e.Graphics.DrawString(Conversions.ToString(position_in_exam(Conversions.ToString(publicSubsNFunctions.exam_names[k]))), publicSubsNFunctions.other_font, Brushes.Black, left_margin + j, line);
                        j += exam_width;
                    }
                }
                else
                {
                    e.Graphics.DrawString(Conversions.ToString(position_in_exam(publicSubsNFunctions.exam_name)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + j, line);
                }

                line += 20;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line - 2, right_margin + 2, line - 2);
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline - 2, left_margin - 2, line);
                j = 210;
                try
                {
                    var loopTo28 = publicSubsNFunctions.tables.Length - 1;
                    for (i = 0; i <= loopTo28; i++)
                    {
                        e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line);
                        j += exam_width;
                    }
                }
                catch (Exception ex)
                {
                    e.Graphics.DrawLine(Pens.Black, left_margin + j - 2, topline - 2, left_margin + j - 2, line);
                }

                e.Graphics.DrawLine(Pens.Black, left_margin + avg - 2, topline - 2, left_margin + avg - 2, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + pt - 2, topline - 2, left_margin + pt - 2, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + mg - 2, topline - 2, left_margin + mg - 2, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + subj_pos - 2, topline - 2, left_margin + subj_pos - 2, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + remarks - 2, topline - 2, left_margin + remarks - 2, line);
                e.Graphics.DrawLine(Pens.Black, left_margin + teacher - 2, topline - 2, left_margin + teacher - 2, line);
                e.Graphics.DrawLine(Pens.Black, right_margin + 2, topline - 2, right_margin + 2, line);
                line += 10;
                int stream_out_of = 0;
                var loopTo29 = publicSubsNFunctions.streams.Length - 1;
                for (i = 0; i <= loopTo29; i++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", student].Value, publicSubsNFunctions.streams[i], false)))
                    {
                        stream_out_of = stream_no[i];
                    }
                }

                e.Graphics.DrawString("CLASS POSITION:________________", publicSubsNFunctions.medium, Avgpen, left_margin + 2, line);
                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks["Overall", student].Value, " Out Of "), dgvEnterMarks.Rows.Count - 4)), publicSubsNFunctions.medium, RemarksPen, left_margin + 120, line - 2);
                e.Graphics.DrawString("STREAM POSITION:_______________", publicSubsNFunctions.medium, Avgpen, left_margin + 220, line);
                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgvEnterMarks["Position", student].Value, " Out Of "), stream_out_of - 1)), publicSubsNFunctions.medium, RemarksPen, left_margin + 350, line - 2);
                e.Graphics.DrawString("MEAN GRADE:____", publicSubsNFunctions.medium, Avgpen, left_margin + 450, line);
                e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.medium, RemarksPen, left_margin + 545, line - 2);
                e.Graphics.DrawString("MEAN POINTS:________", publicSubsNFunctions.medium, Avgpen, left_margin + 570, line);
                if (Information.IsNumeric(dgvEnterMarks["MP", student].Value))
                {
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MP", student].Value), publicSubsNFunctions.medium, RemarksPen, left_margin + 665, line - 5);
                }
                else
                {
                    e.Graphics.DrawString(Conversions.ToString(dgvEnterMarks["MG", student].Value), publicSubsNFunctions.medium, RemarksPen, left_margin + 665, line - 5);
                }
            }
        }

        private void dgvEnterMarks_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvEnterMarks.Rows[dgvEnterMarks.Rows.Count - 1].Cells["MP"].ValueType = typeof(double);
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = SaveFileDialog1.FileName;
                if (string.IsNullOrEmpty(filename))
                {
                    filename = Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\export_data";
                }

                string saveas = filename;
                filename += ".csv";
                FileSystem.FileOpen(1, filename, OpenMode.Output);
                string line = null;
                for (int k = 0, loopTo = dgvEnterMarks.Columns.Count - 1; k <= loopTo; k++)
                {
                    line += dgvEnterMarks.Columns[k].HeaderText;
                    if (k < dgvEnterMarks.Columns.Count - 1)
                    {
                        line += ",";
                    }
                }

                line += Constants.vbNewLine;
                for (int row = 0, loopTo1 = dgvEnterMarks.Rows.Count - 1; row <= loopTo1; row++)
                {
                    for (int col = 0, loopTo2 = dgvEnterMarks.Columns.Count - 1; col <= loopTo2; col++)
                    {
                        line = Conversions.ToString(line + dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value);
                        if (col < dgvEnterMarks.Columns.Count - 1)
                        {
                            line += ",";
                        }
                    }

                    line += Constants.vbNewLine;
                }

                FileSystem.Print(1, line);
                FileSystem.FileClose(1);
                try
                {
                    object oExcelFile;
                    try
                    {
                        oExcelFile = Interaction.GetObject(Class: "Excel.Application");
                    }
                    catch
                    {
                        oExcelFile = Interaction.CreateObject("Excel.Application");
                    }

                    oExcelFile.Visible = false;
                    oExcelFile.Workbooks.Open(SaveFileDialog1.FileName);
                    oExcelFile.DisplayAlerts = false;
                    // todo oExcelFile.ActiveWorkbook.SaveAs(Filename:=saveas, FileFormat:=Excel.XlFileFormat.xlExcel5, CreateBackup:=False)
                    oExcelFile.ActiveWorkbook.Close(SaveChanges: false);
                    oExcelFile.DisplayAlerts = true;
                    oExcelFile.Quit();
                    File.Delete(filename);
                    publicSubsNFunctions.success("Data Successfully Exported To " + filename + ".xls");
                }
                catch (Exception ex)
                {
                    publicSubsNFunctions.failure("Failed to initialize Excel application. Please restart your computer and try again");
                }
            }
        }

        private void print_subject(object sender, PrintPageEventArgs e)
        {
            int left_margin = 200;
            int right_margin = 3000;
            int topline = 200;
            int line, inc;
            int bottomline = 2000;
            inc = (int)Math.Round((bottomline - topline) / (double)publicSubsNFunctions.grades.Length);
            line = topline;
            e.Graphics.DrawLine(Pens.Black, left_margin, topline - 30, left_margin, bottomline);
            e.Graphics.DrawLine(Pens.Black, left_margin, bottomline, right_margin, bottomline);
            var npen = new Pen(Color.Silver, 1f);
            npen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            for (int k = 0, loopTo = publicSubsNFunctions.grades.Length - 1; k <= loopTo; k++)
            {
                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.header_font, Brushes.Black, left_margin - 40, line);
                e.Graphics.DrawLine(npen, left_margin, line, right_margin, line);
                line += inc;
            }

            object[] grade_lines = new object[publicSubsNFunctions.grades.Length];
            object found;
            for (int k = 0, loopTo1 = publicSubsNFunctions.grades.Length - 1; k <= loopTo1; k++)
                grade_lines[k] = topline + inc * k;
            print_exams();
            int column = 70;
            for (int k = 0, loopTo2 = exams_done.Length - 1; k <= loopTo2; k++)
                e.Graphics.DrawString((k + 1).ToString(), publicSubsNFunctions.header_font, Brushes.Black, (float)(left_margin + (k + 1) * column - 0.75d * column), bottomline + 40);
            line = bottomline + 100;
            int col = 0;
            for (int k = 0, loopTo3 = exams_done.Length - 1; k <= loopTo3; k++)
            {
                e.Graphics.DrawString(k + 1 + ":  " + exam_done_name[k], publicSubsNFunctions.header_font, Brushes.Black, left_margin + col, line);
                line += publicSubsNFunctions.header_font.Height + 5;
                if (k == 3)
                {
                    col += column;
                    line = bottomline + 100;
                }
            }

            found = 0;
            var pencil = new Pen[publicSubsNFunctions.subjabb.Length];
            var colors = new Color[publicSubsNFunctions.subjabb.Length];
            colors[0] = Color.Blue;
            colors[1] = Color.Green;
            colors[2] = Color.Yellow;
            colors[3] = Color.Red;
            colors[4] = Color.Purple;
            colors[5] = Color.Orange;
            colors[6] = Color.Navy;
            colors[7] = Color.Brown;
            colors[8] = Color.YellowGreen;
            colors[9] = Color.Violet;
            colors[10] = Color.LimeGreen;
            // colors(11) = Color.LimeGreen
            for (int k = 0, loopTo4 = pencil.Length - 1; k <= loopTo4; k++)
                pencil[k] = new Pen(colors[k], 5f);
            var brush = new Brush[pencil.Length];
            brush[0] = Brushes.Blue;
            brush[1] = Brushes.Green;
            brush[2] = Brushes.Yellow;
            brush[3] = Brushes.Red;
            brush[4] = Brushes.Purple;
            brush[5] = Brushes.Orange;
            brush[6] = Brushes.Navy;
            brush[7] = Brushes.Brown;
            brush[8] = Brushes.YellowGreen;
            brush[9] = Brushes.Violet;
            brush[10] = Brushes.LimeGreen;
            brush[11] = Brushes.AliceBlue;
            var line_points = new Point[exams_done.Length][];
            for (int k = 0, loopTo5 = line_points.Length - 1; k <= loopTo5; k++)
                line_points[k] = new Point[publicSubsNFunctions.subjabb.Length];
            for (int ex = 0, loopTo6 = exams_done.Length - 1; ex <= loopTo6; ex++)
            {
                for (int k = 0, loopTo7 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo7; k++)
                {
                    string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `grade` FROM subjects_progress WHERE (subject='", publicSubsNFunctions.subject_get(publicSubsNFunctions.subjids[k])), "' AND admno='"), dgvEnterMarks["ADMNo", student].Value), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "' AND exam='"), ex_done_name[ex]), "')"));
                    publicSubsNFunctions.qread(ref argq);
                    publicSubsNFunctions.dbreader.Read();
                    for (int g = 0, loopTo8 = publicSubsNFunctions.grades.Length - 1; g <= loopTo8; g++)
                    {
                        try
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.dbreader["grade"], publicSubsNFunctions.grades[g], false)))
                            {
                                found = grade_lines[g];
                                break;
                            }
                        }
                        catch (Exception exept)
                        {
                            break;
                        }
                    }

                    publicSubsNFunctions.dbreader.Close();
                    line_points[ex][k] = new Point((int)Math.Round(left_margin + (ex + 1) * column - 0.75d * column), Conversions.ToInteger(found));
                    e.Graphics.DrawEllipse(pencil[k], (object)(int)Math.Round((double)(left_margin + (ex + 1) * column) - 0.75d * (double)column), Operators.SubtractObject(found, 5), (object)10, (object)10);
                    e.Graphics.FillEllipse(brush[k], (object)(int)Math.Round((double)(left_margin + (ex + 1) * column) - 0.75d * (double)column), Operators.SubtractObject(found, 5), (object)10, (object)10);
                }
            }

            for (int k = 0, loopTo9 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo9; k++)
            {
                for (int m = 1, loopTo10 = exams_done.Length - 1; m <= loopTo10; m++)
                    // e.Graphics.DrawCurve(Pens.Black, line_points(m), 5)
                    e.Graphics.DrawLine(pencil[k], line_points[m][k].X, line_points[m][k].Y, line_points[m - 1][k].X, line_points[m - 1][k].Y);
            }

            var rect = default(Rectangle);
            rect.Y = bottomline + 120;
            rect.X = left_margin + 1000;
            rect.Width = 60;
            rect.Height = 30;
            rect.Y = bottomline + 120;
            for (int k = 0, loopTo11 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo11; k++)
            {
                e.Graphics.DrawRectangle(pencil[k], rect);
                e.Graphics.FillRectangle(brush[k], rect);
                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.subjects[k]), publicSubsNFunctions.head_small, brush[k], rect.X + 100, rect.Y + 10);
                if ((k + 1) % 4 == 0 & k != 0)
                {
                    rect.X = rect.X + 600;
                    rect.Y = bottomline + 70;
                }

                rect.Y = rect.Y + 50;
            }
        }

        private void print_exams()
        {
            string cur_form, exit_form, term_out;
            string[] forms;
            string[] start_form, end_form;
            int[] yr;
            int year_out;
            string argq2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT CurrentClass, YearOut, TermOut, ClassAdmitted FROM students WHERE ADMNo='", dgvEnterMarks["ADMNo", student].Value), "'"));
            if (publicSubsNFunctions.qread(ref argq2))
            {
                publicSubsNFunctions.dbreader.Read();
                exit_form = Conversions.ToString(publicSubsNFunctions.dbreader["CurrentClass"]);
                cur_form = Conversions.ToString(publicSubsNFunctions.dbreader["ClassAdmitted"]);
                if ((cur_form ?? "") == (string.Empty ?? ""))
                {
                    cur_form = "Form 1";
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.dbreader["YearOut"], 0, false)))
                {
                    year_out = DateAndTime.Today.Year;
                }
                else
                {
                    year_out = Conversions.ToInteger(publicSubsNFunctions.dbreader["YearOut"]);
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.dbreader["TermOut"], string.Empty, false)))
                {
                    publicSubsNFunctions.get_term();
                    term_out = publicSubsNFunctions.term;
                }
                else
                {
                    term_out = Conversions.ToString(publicSubsNFunctions.dbreader["TermOut"]);
                }

                publicSubsNFunctions.dbreader.Close();
                start_form = cur_form.Split(' ');
                end_form = exit_form.Split(' ');
                int count = Conversions.ToInteger(end_form[1]) - Conversions.ToInteger(start_form[1]);
                forms = new string[count + 1];
                yr = new int[count + 1];
                for (int k = 0, loopTo = count; k <= loopTo; k++)
                    forms[k] = "Form " + (k + 1);
                for (int k = count; k >= 0; k -= 1)
                    yr[k] = year_out - k;
                count = 0;
                int j = 0;
                for (int k = yr.Length - 1; k >= 0; k -= 1)
                {
                    string argq = "SELECT * FROM examinations WHERE Year='" + yr[k] + "' AND (Term='I' OR Term='II' OR Term='III') AND Classes LIKE '%" + forms[count] + "%'";
                    if (publicSubsNFunctions.qread(ref argq))
                    {
                        if (k == yr.Length - 1)
                        {
                            j = 0;
                            exam_name_ = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                            exams = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                            total = new int[publicSubsNFunctions.dbreader.RecordsAffected];
                            ex_name = new string[publicSubsNFunctions.dbreader.RecordsAffected];
                        }
                        else
                        {
                            Array.Resize(ref exams, exams.Length - 1 + publicSubsNFunctions.dbreader.RecordsAffected + 1);
                            Array.Resize(ref exam_name_, publicSubsNFunctions.exam_name.Length - 1 + publicSubsNFunctions.dbreader.RecordsAffected + 1);
                            Array.Resize(ref total, total.Length - 1 + publicSubsNFunctions.dbreader.RecordsAffected + 1);
                            Array.Resize(ref ex_name, ex_name.Length - 1 + publicSubsNFunctions.dbreader.RecordsAffected + 1);
                        }

                        while (publicSubsNFunctions.dbreader.Read())
                        {
                            exams[j] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.dbreader["Term"], "_"), publicSubsNFunctions.dbreader["Year"].ToString().Substring(2)), "_"), publicSubsNFunctions.get_name(Conversions.ToString(publicSubsNFunctions.dbreader["ExamName"]))), "_"), publicSubsNFunctions.get_name(forms[count])));
                            exam_name_[j] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.dbreader["ExamName"], " Term "), publicSubsNFunctions.dbreader["Term"]), " "), publicSubsNFunctions.dbreader["Year"]));
                            total[j] = Conversions.ToInteger(publicSubsNFunctions.dbreader["Total"]);
                            ex_name[j] = Conversions.ToString(publicSubsNFunctions.dbreader["ExamName"]);
                            j += 1;
                        }
                    }

                    count += 1;
                }

                publicSubsNFunctions.dbreader.Close();
                // print_examination()
                int exam_count = 0;
                for (int k = 0, loopTo1 = exams.Length - 1; k <= loopTo1; k++)
                {
                    string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `" + exams[k] + "` WHERE ADMNo='", dgvEnterMarks["ADMNo", student].Value), "'"));
                    if (publicSubsNFunctions.qread(ref argq1))
                    {
                        if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                        {
                            exam_count += 1;
                            if (exam_count == 1)
                            {
                                exam_done_name = new string[exam_count];
                                exams_done = new string[exam_count];
                                total_done = new int[exam_count];
                                ex_done_name = new string[exam_count];
                            }
                            else
                            {
                                Array.Resize(ref exam_done_name, exam_count);
                                Array.Resize(ref exams_done, exam_count);
                                Array.Resize(ref total_done, exam_count);
                                Array.Resize(ref ex_done_name, exam_count);
                            }

                            exams_done[exam_count - 1] = exams[k];
                            exam_done_name[exam_count - 1] = exam_name_[k];
                            total_done[exam_count - 1] = total[k];
                            ex_done_name[exam_count - 1] = ex_name[k];
                        }
                    }

                    publicSubsNFunctions.dbreader.Close();
                }
            }
        }

        private string[] exams, exam_name_, exams_done, exam_done_name, ex_name, ex_done_name;
        private int[] total, total_done;
        private void Button4_Click_1(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Are You Sure You Want To Save This Analysis As Examination Performance For This Particular Examination?")))
            {
                save_examination();
            }
        }

        private void save_examination()
        {
            // Dim inc As Integer = dgvEnterMarks.Rows.Count - 4 / 100
            // qwrite("CREATE TABLE `examination_performance` (" &
            // "`id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY ," &
            // "`ADMNo` BIGINT( 255 ) NOT NULL," &
            // "`exam` VARCHAR( 255 ) NOT NULL , " &
            // "`term` VARCHAR( 255 ) NOT NULL , " &
            // "`year` BIGINT(255) NOT NULL ," &
            // "`pos` VARCHAR(20) NOT NULL" &
            // "	INDEX `FK_examination_performance_students` (`ADMNo`)," &
            // "CONSTRAINT `FK_examination_performance_students` FOREIGN KEY (`ADMNo`) REFERENCES `students` (`ADMNo`) ON UPDATE CASCADE ON DELETE CASCADE" &
            // ") ENGINE = Innodb ;")
            Pbar.Increment(-100);
            Pbar.Visible = true;

            // For k As Integer = 0 To dgvEnterMarks.Rows.Count - 5

            int inc = (int)Math.Round(100d / dgvEnterMarks.Rows.Count - 5d);
            if (Conversions.ToBoolean(issaved()))
            {
                for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 5; k <= loopTo; k++)
                {
                    string test = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM examination_performance WHERE (ADMNo='", dgvEnterMarks["ADMNo", k].Value), "' AND exam='"), publicSubsNFunctions.exam_name), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "')"));
                    string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM examination_performance WHERE (ADMNo='", dgvEnterMarks["ADMNo", k].Value), "' AND exam='"), publicSubsNFunctions.exam_name), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "')"));
                    publicSubsNFunctions.qread(ref argq);
                    if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                    {
                        publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("UPDATE examination_performance SET pos='", dgvEnterMarks["Overall", k].Value), "/"), dgvEnterMarks.Rows.Count - 4), "' WHERE (ADMNo='"), dgvEnterMarks["ADMNo", k].Value), "' AND exam='"), publicSubsNFunctions.exam_name), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "')")));
                    }
                    else
                    {
                        publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO examination_performance VALUES(NULL, '", dgvEnterMarks["ADMNo", k].Value), "', '"), publicSubsNFunctions.exam_name), "', '"), publicSubsNFunctions.tm), "','"), publicSubsNFunctions.yr), "','"), dgvEnterMarks["Overall", k].Value), "/"), dgvEnterMarks.Rows.Count - 4), "')")));
                    }

                    Pbar.Increment(inc);
                }

                // Pbar.Visible = False
                // success("Examination Performance Saved!")

                // Pbar.Visible = True

                // qwrite("DELETE FROM `class_performance_data` WHERE (ADMNo='" & dgvEnterMarks.Item("ADMNo", k).Value & "' AND term='" & tm & "' AND Year='" & yr & "' AND Class='" & ret_name(class_form) & "')")
                // Pbar.Increment(inc)
                // Next
                publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("DELETE FROM term_results WHERE (class='", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "')")));

                // Pbar.Increment(-100)
                publicSubsNFunctions.query = "INSERT INTO `class_performance_data` VALUES";
            }

            for (int k = 0, loopTo1 = dgvEnterMarks.Rows.Count - 5; k <= loopTo1; k++)
            {
                publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("('", dgvEnterMarks["ADMNo", k].Value), "','"), dgvEnterMarks["Overall", k].Value), " / "), dgvEnterMarks.Rows.Count - 4), "','"), dgvEnterMarks["MG", k].Value), "', '"), dgvEnterMarks["MP", k].Value), "', '"), publicSubsNFunctions.tm), "', '"), publicSubsNFunctions.yr), "', '"), publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "')"));
                if (k < dgvEnterMarks.Rows.Count - 5)
                {
                    publicSubsNFunctions.query += ",";
                }

                Pbar.Increment(inc);
            }

            publicSubsNFunctions.qwrite(publicSubsNFunctions.query);
            publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO term_results VALUES(NULL, '" + publicSubsNFunctions.tm + "','" + publicSubsNFunctions.yr + "','", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "')")));
            publicSubsNFunctions.success("End Of Term Results Successfully Saved!");
            Pbar.Visible = false;
            Pbar.Increment(-100);
        }

        private object SchoolCode()
        {
            string argq = "SELECT code FROM school_details";
            publicSubsNFunctions.qread(ref argq);
            publicSubsNFunctions.dbreader.Read();
            return publicSubsNFunctions.dbreader["code"];
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string code = Conversions.ToString(SchoolCode());
            if (code.Length < 6)
            {
                if (Conversions.ToBoolean(!publicSubsNFunctions.confirm("Your School Code May Not Have Been Set! Do You Want To Continue Anyway?")))
                {
                    return;
                }
            }

            string index;
            publicSubsNFunctions.start();
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 4; k <= loopTo; k++)
            {
                if (k < 9)
                {
                    index = code + "00" + (k + 1);
                }
                else if (k < 99)
                {
                    index = code + "0" + (k + 1);
                }
                else
                {
                    index = code + (k + 1);
                }

                if (!publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("UPDATE students SET indexno = '" + index + "' WHERE admin_no =  '", dgvEnterMarks["ADMNo", k].Value), "'"))))
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Could Not Successfully Perform Index Numbering!");
                    return;
                }
            }

            publicSubsNFunctions.commit();
            publicSubsNFunctions.success("Student Index Numbering Successfully Saved");
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            double[] counts = new double[publicSubsNFunctions.streams.Length], sums = new double[publicSubsNFunctions.streams.Length];
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 4; k <= loopTo; k++)
            {
                if (dgvEnterMarks["ENG", k].Value.ToString() != "-")
                {
                    for (int s = 0, loopTo1 = publicSubsNFunctions.streams.Length - 1; s <= loopTo1; s++)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvEnterMarks["str_class", k].Value, publicSubsNFunctions.streams[s], false)))
                        {
                            if (Information.IsNumeric(dgvEnterMarks["ENG", k].Value))
                            {
                                sums[s] = Conversions.ToDouble(sums[s] + dgvEnterMarks["ENG", k].Value);
                            }

                            counts[s] += 1d;
                        }
                    }
                }
            }

            string result = null;
            for (int k = 0, loopTo2 = publicSubsNFunctions.streams.Length - 1; k <= loopTo2; k++)
                result += " Stream: " + publicSubsNFunctions.streams[k] + " SUM: " + sums[k] + " COUNT: " + counts[k] + Constants.vbNewLine;
            Interaction.MsgBox(result);
        }

        private void frmResults_Shown(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.search_teachers)
            {
                Close();
            }
        }
    }
}