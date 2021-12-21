using System;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmNationalGradesAttained
    {
        public frmNationalGradesAttained()
        {
            InitializeComponent();
            _Button1.Name = "Button1";
            _ComboBox1.Name = "ComboBox1";
            _btnPrintPreview.Name = "btnPrintPreview";
            _btnPrint.Name = "btnPrint";
            _btnCancel.Name = "btnCancel";
        }

        private object[] admnos, vals;
        private string[] vals_alt;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void create_form()
        {
            dgvSubjects.Columns.Clear();
            var col = new DataGridViewColumn();
            DataGridViewCell cel = new DataGridViewTextBoxCell();
            col.Name = "Grade";
            col.HeaderText = string.Empty;
            col.CellTemplate = cel;
            col.ReadOnly = true;
            col.Width = 200;
            dgvSubjects.Columns.Add(col);
            var ent = new DataGridViewColumn();
            ent.CellTemplate = cel;
            ent.Width = 50;
            ent.Name = "ENTRY";
            ent.HeaderText = "ENTRY";
            ent.ReadOnly = true;
            dgvSubjects.Columns.Add(ent);
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                dgvSubjects.Rows.Add();
            for (int k = 0, loopTo1 = publicSubsNFunctions.grades.Length - 1; k <= loopTo1; k++)
            {
                var column = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                column.CellTemplate = cell;
                column.Name = Conversions.ToString(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k.ToString()));
                column.HeaderText = Conversions.ToString(publicSubsNFunctions.grades[k]);
                column.ReadOnly = false;
                column.Width = 46;
                dgvSubjects.Columns.Add(column);
            }

            for (int k = 0, loopTo2 = dgvSubjects.Rows.Count - 1; k <= loopTo2; k++)
                dgvSubjects["Grade", k].Value = publicSubsNFunctions.subjects[k];
            var tp = new DataGridViewColumn();
            tp.CellTemplate = cel;
            tp.Width = 60;
            tp.Name = "STP";
            tp.Visible = false;
            tp.HeaderText = "S. T. P.";
            tp.ReadOnly = true;
            dgvSubjects.Columns.Add(tp);
            var mp = new DataGridViewColumn();
            mp.CellTemplate = cel;
            mp.Width = 60;
            mp.Name = "SMP";
            mp.HeaderText = "S. M. P.";
            mp.Visible = false;
            mp.ReadOnly = true;
            dgvSubjects.Columns.Add(mp);
            var tp1 = new DataGridViewColumn();
            tp1.CellTemplate = cel;
            tp1.Width = 60;
            tp1.Name = (DateAndTime.Today.Year - 1).ToString();
            tp1.HeaderText = "MEAN " + (DateAndTime.Today.Year - 1).ToString();
            tp1.ReadOnly = true;
            dgvSubjects.Columns.Add(tp1);
            var mp1 = new DataGridViewColumn();
            mp1.CellTemplate = cel;
            mp1.Width = 60;
            mp1.Name = (DateAndTime.Today.Year - 2).ToString();
            mp1.HeaderText = "MEAN " + (DateAndTime.Today.Year - 2).ToString();
            mp1.ReadOnly = true;
            dgvSubjects.Columns.Add(mp1);
            var mp11 = new DataGridViewColumn();
            mp11.CellTemplate = cel;
            mp11.Width = 60;
            mp11.Name = "DEVIATION";
            mp11.HeaderText = "DEV.";
            mp11.ReadOnly = true;
            dgvSubjects.Columns.Add(mp11);
            var mg = new DataGridViewColumn();
            mg.CellTemplate = cel;
            mg.Width = 50;
            mg.Name = "MG";
            mg.ReadOnly = true;
            mg.HeaderText = "M.G.";
            dgvSubjects.Columns.Add(mg);
        }

        private void frmGradesAttained_Load(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(!publicSubsNFunctions.connect(), publicSubsNFunctions.dbNewOpen())))
            {
                Close();
            }
            else
            {
                publicSubsNFunctions.load_stream1(ComboBox1, "Form 4");
                ComboBox1.Items.Add("All");
                ComboBox1.SelectedItem = "All";
                state = true;
                load_data();
            }
        }

        private bool state = false;

        private void load_data()
        {
            if (state)
            {
                create_form();
                not_mode();
                compute_totals();
                dgvSubjects.Rows.Add();
                dgvSubjects["GRADE", dgvSubjects.Rows.Count - 1].Value = "TOTAL GRADES";
                for (int g = 0, loopTo = publicSubsNFunctions.grades.Length - 1; g <= loopTo; g++)
                {
                    int totG = 0;
                    for (int k = 0, loopTo1 = dgvSubjects.Rows.Count - 4; k <= loopTo1; k++)
                    {
                        try
                        {
                            totG = Conversions.ToInteger(totG + dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[g].Substring((object)0, (object)1), g), k).Value);
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[g].Substring((object)0, (object)1), g), dgvSubjects.Rows.Count - 1).Value = totG;
                }
                // dgvSubjects.Sort(dgvSubjects.Columns("SMP"), System.ComponentModel.ListSortDirection.Descending)
                dgvSubjects.Rows.Add();
                dgvSubjects["GRADE", dgvSubjects.Rows.Count - 1].Value = "OVERALL SCHOOL MEAN GRADE " + publicSubsNFunctions.yr;
                // For k As Integer = 0 To dgvSubjects.Rows.Count - 1
                // For j As Integer = 0 To grades.Length - 1
                // dgvSubjects.Item(grades(j).Substring(0, 1) & j.ToString, k).Value = "-"
                // Next
                // Next
                // means()
                int inc;
                inc = (int)Math.Round(100d / publicSubsNFunctions.grades.Length);
                for (int k = 0, loopTo2 = publicSubsNFunctions.grades.Length - 1; k <= loopTo2; k++)
                {
                    if (!Information.IsNumeric(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k), (object)(dgvSubjects.Rows.Count - 1)).Value))
                    {
                        dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k), dgvSubjects.Rows.Count - 1).Value = "-";
                    }
                }

                inc = (int)Math.Round(100d / dgvSubjects.Rows.Count);
                for (int k = 0, loopTo3 = dgvSubjects.Rows.Count - 3; k <= loopTo3; k++)
                    dgvSubjects["MG", k].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvSubjects["SMP", k].Value));
                dgvSubjects.Rows.Add();
                dgvSubjects["GRADE", dgvSubjects.Rows.Count - 1].Value = "OVERALL SCHOOL MEAN GRADE " + (publicSubsNFunctions.yr - 1);
                string argq = "SELECT * FROM kcse_overall_performance WHERE year='" + (publicSubsNFunctions.yr - 1) + "'";
                publicSubsNFunctions.qread(ref argq);
                publicSubsNFunctions.dbreader.Read();
                for (int k = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; k <= loopTo4; k++)
                    dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k), dgvSubjects.Rows.Count - 1).Value = publicSubsNFunctions.dbreader(publicSubsNFunctions.grades[k]);
                dgvSubjects[(publicSubsNFunctions.yr - 1).ToString(), dgvSubjects.Rows.Count - 2].Value = publicSubsNFunctions.dbreader["mp"];
                dgvSubjects["MG", dgvSubjects.Rows.Count - 1].Value = publicSubsNFunctions.dbreader["mg"];
                dgvSubjects["ENTRY", dgvSubjects.Rows.Count - 1].Value = publicSubsNFunctions.dbreader["Entry"];
                double dev = Convert.ToDouble(dgvSubjects[publicSubsNFunctions.yr.ToString(), dgvSubjects.Rows.Count - 2].Value) - Convert.ToDouble(dgvSubjects[(publicSubsNFunctions.yr - 1).ToString(), dgvSubjects.Rows.Count - 2].Value);
                if (dev > 0d)
                {
                    dgvSubjects["DEVIATION", dgvSubjects.Rows.Count - 2].Value = "+" + Strings.Format(dev, "0.00");
                }
                else
                {
                    dgvSubjects["DEVIATION", dgvSubjects.Rows.Count - 2].Value = Strings.Format(dev, "0.00");
                }

                dgvSubjects["MG", dgvSubjects.Rows.Count - 2].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvSubjects[publicSubsNFunctions.yr.ToString(), dgvSubjects.Rows.Count - 2].Value));
            }
        }

        private void means()
        {
            for (int k = 0, loopTo = publicSubsNFunctions.grades.Length - 1; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ComboBox1.SelectedItem, "All", false)))
                {
                    string argq = "SELECT count(*) as number FROM `kcse_results` WHERE (year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND mg='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.grades[k])) + "')";
                    publicSubsNFunctions.qread(ref argq);
                }
                else
                {
                    string argq1 = "SELECT count(*) as number FROM `kcse_results` WHERE (year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND mg='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.grades[k])) + "' AND stream='" + publicSubsNFunctions.escape_string(Conversions.ToString(ComboBox1.SelectedItem)) + "')";
                    publicSubsNFunctions.qread(ref argq1);
                }

                publicSubsNFunctions.dbreader.Read();
                dgvSubjects[publicSubsNFunctions.grades[k].Substring((object)0, (object)1).ToString() + k, dgvSubjects.Rows.Count - 1].Value = publicSubsNFunctions.dbreader["number"];
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ComboBox1.SelectedItem, "All", false)))
            {
                string argq2 = "SELECT count(*) as number FROM `kcse_results` WHERE (year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND tp>0)";
                publicSubsNFunctions.qread(ref argq2);
            }
            else
            {
                string argq3 = "SELECT count(*) as number FROM `kcse_results` WHERE (year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND stream='" + publicSubsNFunctions.escape_string(Conversions.ToString(ComboBox1.SelectedItem)) + "' AND tp>0)";
                publicSubsNFunctions.qread(ref argq3);
            }

            publicSubsNFunctions.dbreader.Read();
            dgvSubjects["ENTRY", dgvSubjects.Rows.Count - 1].Value = publicSubsNFunctions.dbreader["number"];
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ComboBox1.SelectedItem, "All", false)))
            {
                string argq4 = "SELECT mg FROM `kcse_results` WHERE (year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "') AND mg!='X'";
                publicSubsNFunctions.qread(ref argq4);
            }
            else
            {
                string argq5 = "SELECT mg FROM `kcse_results` WHERE (year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND stream='" + publicSubsNFunctions.escape_string(Conversions.ToString(ComboBox1.SelectedItem)) + "' AND mg!='X')";
                publicSubsNFunctions.qread(ref argq5);
            }

            double tp = 0d;
            int cnt = 0;
            while (publicSubsNFunctions.dbreader.Read())
            {
                tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.dbreader["mg"])));
                cnt += 1;
            }

            dgvSubjects["STP", dgvSubjects.Rows.Count - 1].Value = tp;
            dgvSubjects["SMP", dgvSubjects.Rows.Count - 1].Value = Strings.Format(tp / cnt, "0.00");
            dgvSubjects[publicSubsNFunctions.yr.ToString(), dgvSubjects.Rows.Count - 1].Value = Strings.Format(tp / cnt, "0.00");
            for (int k = 0, loopTo1 = dgvSubjects.Rows.Count - 3; k <= loopTo1; k++)
            {
                string argq6 = "SELECT mp FROM kcse_overall_subject_performance WHERE subject='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvSubjects["Grade", k].Value)) + "' AND year='" + (publicSubsNFunctions.yr - 1) + "'";
                publicSubsNFunctions.qread(ref argq6);
                publicSubsNFunctions.dbreader.Read();
                dgvSubjects[(publicSubsNFunctions.yr - 1).ToString(), k].Value = publicSubsNFunctions.dbreader["mp"];
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvSubjects[(publicSubsNFunctions.yr - 1).ToString(), k].Value, 0, false)))
                {
                    dgvSubjects["DEVIATION", k].Value = "--";
                }
                else
                {
                    dgvSubjects["DEVIATION", k].Value = Strings.Format(Operators.SubtractObject(dgvSubjects[publicSubsNFunctions.yr.ToString(), k].Value, dgvSubjects[(publicSubsNFunctions.yr - 1).ToString(), k].Value), "0.00");
                }
            }
        }

        private void compute_totals()
        {
            int count, inc;
            inc = (int)Math.Round(100d / publicSubsNFunctions.subjabb.Length);
            for (int s = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo; s++)
            {
                if (s == 3)
                {
                    Interaction.MsgBox("here");
                }

                count = 0;
                dgvSubjects["STP", s].Value = 0;
                for (int k = 0, loopTo1 = publicSubsNFunctions.grades.Length - 3; k <= loopTo1; k++)
                {
                    if (Information.IsNumeric(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k.ToString()), s).Value))
                    {
                        dgvSubjects["STP", s].Value += Operators.MultiplyObject(publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.grades[k])), dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k.ToString()), s).Value);
                        count = Conversions.ToInteger(count + dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k.ToString()), s).Value);
                    }
                }

                if (count > 0)
                {
                    dgvSubjects["SMP", s].Value = Strings.Format(Convert.ToDouble(dgvSubjects["STP", s].Value) / count, "0.00");
                    dgvSubjects[publicSubsNFunctions.yr.ToString(), s].Value = Strings.Format(Convert.ToDouble(dgvSubjects["STP", s].Value) / count, "0.00");
                }
                else
                {
                    dgvSubjects["SMP", s].Value = 0;
                }

                dgvSubjects["ENTRY", s].Value = count;
            }
        }

        private void not_mode()
        {
            bool prime = publicSubsNFunctions.IsPrimary();
            for (int k = 0, loopTo = publicSubsNFunctions.grades.Length - 1; k <= loopTo; k++)
            {
                for (int s = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo1; s++)
                {
                    if (prime)
                    {
                        int cnt = 0;
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ComboBox1.SelectedItem, "All", false)))
                        {
                            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `", publicSubsNFunctions.subjabb[s]), "` FROM `kcse_results` WHERE (`"), publicSubsNFunctions.subjabb[s]), "` LIKE '% "), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.grades[k]))), "%' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND Year='"), publicSubsNFunctions.yr), "')"));
                            publicSubsNFunctions.qread(ref argq);
                        }
                        else
                        {
                            string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT `", publicSubsNFunctions.subjabb[s]), "` FROM `kcse_results` WHERE (`"), publicSubsNFunctions.subjabb[s]), "` LIKE '% "), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.grades[k]))), "%' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND Year='"), publicSubsNFunctions.yr), "' AND stream='"), publicSubsNFunctions.escape_string(Conversions.ToString(ComboBox1.SelectedItem))), "')"));
                            publicSubsNFunctions.qread(ref argq1);
                        }

                        while (publicSubsNFunctions.dbreader.Read())
                        {
                            var values = publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[s]).ToString().Split(' ');
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(values[values.Length - 1].ToString(), publicSubsNFunctions.grades[k], false)))
                            {
                                cnt += 1;
                            }
                        }

                        dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k), s).Value = cnt;
                    }
                    else
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ComboBox1.SelectedItem, "All", false)))
                        {
                            string argq2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT count(*) as number FROM `kcse_results` WHERE (`", publicSubsNFunctions.subjabb[s]), "`='"), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.grades[k]))), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND Year='"), publicSubsNFunctions.yr), "')"));
                            publicSubsNFunctions.qread(ref argq2);
                        }
                        else
                        {
                            string argq3 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT count(*) as number FROM `kcse_results` WHERE (`", publicSubsNFunctions.subjabb[s]), "`='"), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.grades[k]))), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND Year='"), publicSubsNFunctions.yr), "' AND stream='"), publicSubsNFunctions.escape_string(Conversions.ToString(ComboBox1.SelectedItem))), "')"));
                            publicSubsNFunctions.qread(ref argq3);
                        }

                        publicSubsNFunctions.dbreader.Read();
                        dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k), s).Value = publicSubsNFunctions.dbreader["number"];
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_report();
            print_document.DefaultPageSettings.Landscape = true;
            print_document.Print();
        }

        private object print_student_report()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_report;
            return print_document;
        }

        public string logo()
        {
            string logoRet = default;
            string argq = "SELECT logo FROM school_details";
            publicSubsNFunctions.qread(ref argq);
            publicSubsNFunctions.dbreader.Read();
            logoRet = Conversions.ToString(publicSubsNFunctions.dbreader["logo"]);
            publicSubsNFunctions.dbreader.Close();
            return logoRet;
        }

        private void print_report(object sender, PrintPageEventArgs e)
        {
            // e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
            int line;
            int left_margin = 30;
            int right_margin = (publicSubsNFunctions.grades.Length + 5) * 45 + 302;
            int topline = 100;
            try
            {
                e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + logo()), left_margin + 10, topline - 130, 100, 100);
            }
            catch (Exception ex)
            {
            }

            e.Graphics.DrawString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font, Brushes.Black, (float)((right_margin - left_margin) / 3d), 20f);
            e.Graphics.DrawString(publicSubsNFunctions.exam_name.ToUpper() + " EXAMINATION PERFORMANCE SUBJECT ANALYSIS", publicSubsNFunctions.header_font, Brushes.Black, (float)((right_margin - left_margin) / 4d), 20 + publicSubsNFunctions.header_font.Height + 5);
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ComboBox1.SelectedItem, "All", false)))
            {
                e.Graphics.DrawString("FORM 4 " + publicSubsNFunctions.yr + " " + publicSubsNFunctions.exam_name.ToUpper(), publicSubsNFunctions.header_font, Brushes.Black, (float)((right_margin - left_margin) / 2d - 100d), 20 + publicSubsNFunctions.header_font.Height + publicSubsNFunctions.header_font.Height + 5);
            }
            else
            {
                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("FORM 4 ", ComboBox1.SelectedItem), " "), publicSubsNFunctions.yr), " "), publicSubsNFunctions.exam_name.ToUpper())), publicSubsNFunctions.header_font, Brushes.Black, (float)((right_margin - left_margin) / 2d - 100d), 20 + publicSubsNFunctions.header_font.Height + publicSubsNFunctions.header_font.Height + 5);
            }

            line = topline;
            int col = 270;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
            e.Graphics.DrawString("GRADES ATTAINED PER SUBJECT", publicSubsNFunctions.medium, Brushes.Black, left_margin + 5, line + 5);
            for (int k = 0, loopTo = publicSubsNFunctions.grades.Length - 1; k <= loopTo; k++)
            {
                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 2, line + 4);
                col += 40;
            }

            e.Graphics.DrawString(publicSubsNFunctions.yr.ToString(), publicSubsNFunctions.medium, Brushes.Black, left_margin + col + 2, line + 5);
            col += 60;
            e.Graphics.DrawString((publicSubsNFunctions.yr - 1).ToString(), publicSubsNFunctions.medium, Brushes.Black, left_margin + col + 2, line + 5);
            col += 60;
            e.Graphics.DrawString("DEV", publicSubsNFunctions.medium, Brushes.Black, left_margin + col - 10, line + 5);
            col += 45;
            e.Graphics.DrawString("ENTRY", publicSubsNFunctions.medium, Brushes.Black, left_margin + col - 5, line + 5);
            col += 45;
            e.Graphics.DrawString("MG " + publicSubsNFunctions.yr, publicSubsNFunctions.medium, Brushes.Black, left_margin + col, line + 5);
            line += 22;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2);
            for (int k = 0, loopTo1 = dgvSubjects.Rows.Count - 1; k <= loopTo1; k++)
            {
                if (k < dgvSubjects.Rows.Count - 3)
                {
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["Grade", k].Value), publicSubsNFunctions.medium, Brushes.Black, left_margin + 5, line + 4);
                }
                else
                {
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["Grade", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 5, line + 4);
                }

                line += 22;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2);
            }
            // e.Graphics.DrawString("OVERALL MEAN GRADE", medium, Brushes.Black, left_margin + 5, line + 3)
            // line += 22
            // e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2)
            line = topline + 22;
            col = 270;
            for (int k = 0, loopTo2 = dgvSubjects.Rows.Count - 1; k <= loopTo2; k++)
            {
                if (k < dgvSubjects.Rows.Count - 3)
                {
                    for (int j = 0, loopTo3 = publicSubsNFunctions.grades.Length - 1; j <= loopTo3; j++)
                    {
                        e.Graphics.DrawString(Conversions.ToString(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value), publicSubsNFunctions.medium, Brushes.Black, left_margin + col + 5, line + 4);
                        col += 40;
                    }

                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects[publicSubsNFunctions.yr.ToString(), k].Value), publicSubsNFunctions.medium, Brushes.Black, left_margin + col, line + 4);
                    col += 60;
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects[(publicSubsNFunctions.yr - 1).ToString(), k].Value), publicSubsNFunctions.medium, Brushes.Black, left_margin + col - 5, line + 4);
                    col += 60;
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["DEVIATION", k].Value), publicSubsNFunctions.medium, Brushes.Black, left_margin + col - 10, line + 4);
                    col += 45;
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["ENTRY", k].Value), publicSubsNFunctions.medium, Brushes.Black, left_margin + col + 1, line + 4);
                    col += 45 + 20;
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MG", k].Value), publicSubsNFunctions.medium, Brushes.Black, left_margin + col, line + 4);
                    col = 270;
                    line += 22;
                }
                else
                {
                    for (int j = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; j <= loopTo4; j++)
                    {
                        e.Graphics.DrawString(Conversions.ToString(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 5, line + 4);
                        col += 40;
                    }

                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects[publicSubsNFunctions.yr.ToString(), k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 4);
                    col += 60;
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects[(publicSubsNFunctions.yr - 1).ToString(), k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col - 5, line + 4);
                    col += 60;
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["DEVIATION", k].Value), publicSubsNFunctions.medium, Brushes.Black, left_margin + col - 10, line + 4);
                    col += 45;
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["ENTRY", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 1, line + 4);
                    col += 70;
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MG", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 4);
                    col = 270;
                    line += 22;
                }
            }
            // e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            // e.Graphics.DrawLine(Pens.Black, left_margin + 250, topline, left_margin + 250, line + 2)
            col = 270;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline, left_margin - 2, line + 2);
            for (int k = 0, loopTo5 = publicSubsNFunctions.grades.Length + 4; k <= loopTo5; k++)
            {
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 10, topline, left_margin + col - 10, line + 2);
                if (k == publicSubsNFunctions.grades.Length + 1 | k == publicSubsNFunctions.grades.Length)
                {
                    col += 60;
                }
                else
                {
                    col += 40;
                }

                if (k == publicSubsNFunctions.grades.Length + 2)
                {
                    col += 10;
                }

                if (k == publicSubsNFunctions.grades.Length + 3)
                {
                    col += 10;
                }
                else if (k == publicSubsNFunctions.grades.Length + 4)
                {
                    col += 30;
                }
            }

            e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline, right_margin - 2, line + 2);
            line += 30;
            e.Graphics.DrawString("   SE	= SUBJECT ENTRIES					STP 		= SUBJECT TOTAL POINTS" + Constants.vbNewLine + "   TP	= TOTAL POINTS					SMP		= SUBJECT MEAN POINTS" + Constants.vbNewLine + "   MP	= MEAN POINTS					" + Constants.vbNewLine + "   TM	= TOTAL MARKS					", publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_report();
            print_document.DefaultPageSettings.Landscape = true;
            printpreview.Document = print_document;
            printpreview.ShowDialog();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ComboBox1.SelectedItem, "All", false)))
            {
                publicSubsNFunctions.start();
                double imp = 0d;
                string argq = "SELECT mp FROM kcse_overall_performance WHERE (year='" + (publicSubsNFunctions.yr - 1) + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "')";
                publicSubsNFunctions.qread(ref argq);
                publicSubsNFunctions.dbreader.Read();
                try
                {
                    imp = Conversions.ToDouble(publicSubsNFunctions.dbreader["mp"]);
                }
                catch (Exception ex)
                {
                }

                publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO `kcse_overall_performance` VALUES(NULL, '" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "', '" + publicSubsNFunctions.yr + "', '", dgvSubjects["ENTRY", dgvSubjects.Rows.Count - 1].Value), "','"), dgvSubjects["SMP", dgvSubjects.Rows.Count - 1].Value), "','"), dgvSubjects["MG", dgvSubjects.Rows.Count - 1].Value), "',"), Operators.SubtractObject(dgvSubjects["SMP", dgvSubjects.Rows.Count - 1].Value, imp)), ","));
                for (int k = 0, loopTo = publicSubsNFunctions.grades.Length - 1; k <= loopTo; k++)
                {
                    publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject("'", dgvSubjects[publicSubsNFunctions.grades[k].Substring((object)0, (object)1).ToString() + k, dgvSubjects.Rows.Count - 1].Value), "'"));
                    if (k < publicSubsNFunctions.grades.Length - 1)
                    {
                        publicSubsNFunctions.query += ",";
                    }
                }

                publicSubsNFunctions.query += ")";
                if (!publicSubsNFunctions.qwrite("DELETE FROM `kcse_overall_performance` WHERE (Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND year='" + publicSubsNFunctions.yr + "')") | !publicSubsNFunctions.qwrite(publicSubsNFunctions.query))
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Results Analysis Could Not Be Saved!");
                    return;
                }

                if (!publicSubsNFunctions.qwrite("DELETE FROM `kcse_overall_subject_performance` WHERE (Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND year='" + publicSubsNFunctions.yr + "')"))
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Results Analysis Could Not Be Saved!");
                    return;
                }

                for (int k = 0, loopTo1 = dgvSubjects.Rows.Count - 4; k <= loopTo1; k++)
                {
                    string argq1 = "SELECT mp FROM kcse_overall_subject_performance WHERE (year='" + (publicSubsNFunctions.yr - 1) + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND subject='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvSubjects["Grade", k].Value)) + "')";
                    publicSubsNFunctions.qread(ref argq1);
                    publicSubsNFunctions.dbreader.Read();
                    try
                    {
                        imp = Conversions.ToDouble(publicSubsNFunctions.dbreader["mp"]);
                    }
                    catch (Exception ex)
                    {
                    }

                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO `kcse_overall_subject_performance` VALUES(NULL, '" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "', '" + publicSubsNFunctions.yr + "','", dgvSubjects["GRADE", k].Value), "','"), dgvSubjects["Entry", k].Value), "','"), dgvSubjects["SMP", k].Value), "','"), dgvSubjects["MG", k].Value), "','"), Operators.SubtractObject(dgvSubjects["SMP", k].Value, imp)), "',"));
                    for (int s = 0, loopTo2 = publicSubsNFunctions.grades.Length - 1; s <= loopTo2; s++)
                    {
                        publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject("'", dgvSubjects[publicSubsNFunctions.grades[s].Substring((object)0, (object)1).ToString() + s, k].Value), "'"));
                        if (s < publicSubsNFunctions.grades.Length - 1)
                        {
                            publicSubsNFunctions.query += ",";
                        }
                    }

                    publicSubsNFunctions.query += ")";
                    if (!publicSubsNFunctions.qwrite(publicSubsNFunctions.query))
                    {
                        publicSubsNFunctions.rollback();
                        publicSubsNFunctions.failure("Results Analysis Could Not Be Saved!");
                        return;
                    }
                }

                publicSubsNFunctions.commit();
                publicSubsNFunctions.success("Results Analaysis Successfully Saved!");
            }
        }
    }
}