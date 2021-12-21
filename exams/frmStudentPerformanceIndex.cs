using System;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmStudentPerformanceIndex
    {
        public frmStudentPerformanceIndex()
        {
            InitializeComponent();
            _Button1.Name = "Button1";
            _cboYear1.Name = "cboYear1";
            _cboTerm1.Name = "cboTerm1";
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
                    chkBestOf7.Visible = false;
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

        private bool loaded_data = false;
        private object[][] studs = new object[1001][];
        private int start_from = 0;

        private void print_report2(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            int line = 30;
            float CenterPage;
            int left_margin = 20;
            float right_margin = 800f;
            if (!loaded_data)
            {
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

                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString("MOST IMPROVED STUDENTS", publicSubsNFunctions.header_font).Width / 2f);
                e.Graphics.DrawString("MOST IMPROVED STUDENTS", publicSubsNFunctions.header_font, Brushes.Black, CenterPage, line);
                line += publicSubsNFunctions.other_font.Height + 10;
                e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3);
                e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
                e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
                line += 2;
                string sum;
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboSortBy.SelectedItem, "Total Points", false)))
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
                }
                else if (chkBestOf7.Checked)
                {
                    sum = "B7_Total";
                }
                else
                {
                    sum = "Total";
                }

                string argq = "SELECT ADMNo , StudentName, `" + sum + "` FROM exam_results WHERE (Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboExamName1.SelectedItem)) + "' AND Term='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboTerm1.SelectedItem)) + "' AND Year='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboYear1.SelectedItem)) + "' AND Class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "') ORDER BY `ADMNo` ASC";
                publicSubsNFunctions.qread(ref argq);
                studs[publicSubsNFunctions.dbreader.RecordsAffected - 1] = new object[5];
                for (int k = 0, loopTo = studs.Length - 1; k <= loopTo; k++)
                {
                    studs[k] = new object[5];
                    for (int m = 0, loopTo1 = studs[k].Length - 1; m <= loopTo1; m++)
                        studs[k][m] = null;
                }

                int i = 0;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    studs[i][0] = publicSubsNFunctions.dbreader["ADMNo"];
                    studs[i][1] = publicSubsNFunctions.dbreader[sum];
                    studs[i][2] = publicSubsNFunctions.dbreader["StudentName"];
                    studs[i][3] = publicSubsNFunctions.dbreader[sum];
                    i += 1;
                }

                for (int k = 0, loopTo2 = studs.Length - 1; k <= loopTo2; k++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[k][0], null, false)))
                    {
                        break;
                    }

                    string argq1 = "SELECT `" + sum + "` FROM exam_results WHERE (Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboExamName.SelectedItem)) + "' AND Term='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboTerm.SelectedItem)) + "' AND Year='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboYear.SelectedItem)) + "' AND ADMNo='" + publicSubsNFunctions.escape_string(Conversions.ToString(studs[k][0])) + "') ORDER BY `ADMNo` ASC";
                    publicSubsNFunctions.qread(ref argq1);
                    if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                    {
                        publicSubsNFunctions.dbreader.Read();
                        studs[k][1] = Operators.SubtractObject(studs[k][1], publicSubsNFunctions.dbreader[sum]);
                        studs[k][4] = publicSubsNFunctions.dbreader[sum];
                    }
                    else
                    {
                        studs[k][4] = "--";
                        studs[k][1] = 0;
                    }
                }

                var studs_temp = new object[5];
                for (int k = 0, loopTo3 = studs.Length - 1; k <= loopTo3; k++)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[k][0], null, false)))
                    {
                        break;
                    }

                    for (int l = 0, loopTo4 = studs.Length - 1; l <= loopTo4; l++)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(studs[k][1], studs[l][1], false)))
                        {
                            studs_temp[0] = studs[k][0];
                            studs_temp[1] = studs[k][1];
                            studs_temp[2] = studs[k][2];
                            studs_temp[3] = studs[k][3];
                            studs_temp[4] = studs[k][4];
                            studs[k][0] = studs[l][0];
                            studs[k][1] = studs[l][1];
                            studs[k][2] = studs[l][2];
                            studs[k][3] = studs[l][3];
                            studs[k][4] = studs[l][4];
                            studs[l][0] = studs_temp[0];
                            studs[l][1] = studs_temp[1];
                            studs[l][2] = studs_temp[2];
                            studs[l][3] = studs_temp[3];
                            studs[l][4] = studs_temp[4];
                        }
                    }
                }

                e.Graphics.DrawString("S/No.", publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
                e.Graphics.DrawString("Adm. No.", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 50, line);
                e.Graphics.DrawString("NAME OF STUDENT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 120, line);
                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(cboExamName.SelectedItem, " "), cboTerm.SelectedItem), " "), cboYear.SelectedItem)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 300, line);
                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(cboExamName1.SelectedItem, " "), cboTerm1.SelectedItem), " "), cboYear1.SelectedItem)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 450, line);
                e.Graphics.DrawString("DEVIATION", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 650, line);
                line += publicSubsNFunctions.other_font.Height + 5;
            }
            else
            {
                line += publicSubsNFunctions.other_font.Height + 20;
            }

            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
            line += 2;
            int count_similar = 0;
            for (int k = start_from, loopTo5 = studs.Length - 1; k <= loopTo5; k++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[k][0], null, false)))
                {
                    break;
                }
                else if (studs[k][4].ToString() == "--")
                {
                    continue;
                }

                if (k > 0)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[k][1], studs[k - 1][1], false)))
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
                        e.Graphics.DrawString((k + 1).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                    }
                }
                else
                {
                    e.Graphics.DrawString((k + 1).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                }

                e.Graphics.DrawString(Conversions.ToString(studs[k][0]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 50, line);
                e.Graphics.DrawString(Conversions.ToString(studs[k][2]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 120, line);
                e.Graphics.DrawString(Conversions.ToString(studs[k][4]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 350, line);
                e.Graphics.DrawString(Conversions.ToString(studs[k][3]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 500, line);
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(studs[k][1], 0, false)))
                {
                    e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject("+", studs[k][1])), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 670, line);
                }
                else
                {
                    e.Graphics.DrawString(Conversions.ToString(studs[k][1]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 670, line);
                }

                line += publicSubsNFunctions.other_font.Height;
                e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                if (line > 1100)
                {
                    loaded_data = true;
                    start_from = k + 1;
                    e.HasMorePages = true;
                    return;
                }
            }

            start_from = 0;
            for (int k = start_from, loopTo6 = studs.Length - 1; k <= loopTo6; k++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[k][0], null, false)))
                {
                    break;
                }
                else if (studs[k][4].ToString() == "--")
                {
                    if (k > 0)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(studs[k][1], studs[k - 1][1], false)))
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
                            e.Graphics.DrawString((k + 1).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString((k + 1).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                    }

                    e.Graphics.DrawString(Conversions.ToString(studs[k][0]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 50, line);
                    e.Graphics.DrawString(Conversions.ToString(studs[k][2]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 120, line);
                    e.Graphics.DrawString(Conversions.ToString(studs[k][4]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 350, line);
                    e.Graphics.DrawString(Conversions.ToString(studs[k][3]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 500, line);
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(studs[k][1], 0, false)))
                    {
                        e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject("+", studs[k][1])), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 670, line);
                    }
                    else
                    {
                        e.Graphics.DrawString(Conversions.ToString(studs[k][1]), publicSubsNFunctions.smallfont, Brushes.Black, left_margin + 670, line);
                    }

                    line += publicSubsNFunctions.other_font.Height;
                    e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                    if (line > 1100)
                    {
                        loaded_data = true;
                        start_from = k + 1;
                        e.HasMorePages = true;
                        return;
                    }
                }
            }

            start_from = 0;
            loaded_data = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboExamName.SelectedItem, null, false), Operators.ConditionalCompareObjectNotEqual(cboExamName1.SelectedItem, null, false)), Operators.ConditionalCompareObjectNotEqual(cboClass.SelectedItem, null, false)), Operators.ConditionalCompareObjectNotEqual(cboSortBy.SelectedItem, null, false))))
            {
                loaded_data = false;
                start_from = 0;
                var Print_Preview = new PrintPreviewDialog();
                var print_dialog = new PrintDialog();
                PrintDocument print_document = (PrintDocument)print_student_report2();
                print_document.DefaultPageSettings.Landscape = false;
                Print_Preview.Document = print_document;
                Print_Preview.ShowDialog();
            }
            else
            {
                publicSubsNFunctions.failure("The Form Is Not Validly Filled!");
            }
        }
    }
}