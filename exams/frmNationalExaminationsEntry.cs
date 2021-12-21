using System;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmNationalExaminationsEntry
    {
        public frmNationalExaminationsEntry()
        {
            InitializeComponent();
            _btnSave.Name = "btnSave";
            _btnPrintPreview.Name = "btnPrintPreview";
            _ComboBox1.Name = "ComboBox1";
        }

        private bool up_date = false;

        private void frmNationalExaminationsEntry_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                var frm = new frmNationalExaminationsEntryPrompt();
                frm.ShowDialog();
                if (publicSubsNFunctions.cont)
                {
                    publicSubsNFunctions.get_subjects();
                    create_form();
                    // todo change the below code
                    publicSubsNFunctions.load_stream1(ComboBox1, "Form 4");
                    ComboBox1.Items.Add("All");
                    ComboBox1.SelectedItem = "All";
                    load_data();
                }
                else
                {
                    // Me.Close()
                }
            }
        }

        private object[] admnos;

        private void load_data()
        {
            dgvSubjects.Rows.Clear();
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ComboBox1.SelectedItem, "All", false)))
            {
                publicSubsNFunctions.query = "SELECT * FROM `kcse_results` WHERE year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' ORDER BY id ASC";
            }
            else
            {
                publicSubsNFunctions.query = "SELECT * FROM `kcse_results` WHERE year='" + publicSubsNFunctions.yr + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Stream='" + publicSubsNFunctions.escape_string(Conversions.ToString(ComboBox1.SelectedItem)) + "' ORDER BY id ASC";
            }

            if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    up_date = true;
                    btnSave.Text = "&Update";
                    var count = default(int);
                    admnos = new object[publicSubsNFunctions.dbreader.RecordsAffected];
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        dgvSubjects.Rows.Add();
                        admnos[count] = publicSubsNFunctions.dbreader["ADMNo"];
                        for (int j = 0, loopTo = dgvSubjects.Columns.Count - 1; j <= loopTo; j++)
                        {
                            if (j == 1)
                            {
                                dgvSubjects[dgvSubjects.Columns[j].Name, count].Value = Conversions.ToInteger(publicSubsNFunctions.dbreader[dgvSubjects.Columns[j].Name]);
                            }
                            else
                            {
                                dgvSubjects[dgvSubjects.Columns[j].Name, count].Value = publicSubsNFunctions.dbreader[dgvSubjects.Columns[j].Name];
                            }
                        }

                        count += 1;
                    }
                }
                else
                {
                    up_date = false;
                    string argq = "SELECT ADMNo, indexno, StudentName FROM alumni WHERE year=" + publicSubsNFunctions.yr;
                    publicSubsNFunctions.qread(ref argq);
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        dgvSubjects.Rows.Add();
                        dgvSubjects["ADMNo", dgvSubjects.Rows.Count - 2].Value = publicSubsNFunctions.dbreader["ADMNo"];
                        dgvSubjects["IndexNo", dgvSubjects.Rows.Count - 2].Value = publicSubsNFunctions.dbreader["indexno"];
                        dgvSubjects["StudentName", dgvSubjects.Rows.Count - 2].Value = publicSubsNFunctions.dbreader["StudentName"];
                    }

                    btnSave.Text = "&Save";
                }
            }
            else
            {
                publicSubsNFunctions.failure("Looks Like Your Installation Isn't Complete! Please Contact Your Software Vendor!");
            }

            dgvSubjects.Sort(dgvSubjects.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void create_form()
        {
            var col = new DataGridViewColumn();
            DataGridViewCell cel = new DataGridViewTextBoxCell();
            col.ReadOnly = publicSubsNFunctions.load_from_alumni;
            col.Name = "ADMNo";
            col.HeaderText = "Adm. No.";
            col.CellTemplate = cel;
            col.Width = 50;
            dgvSubjects.Columns.Add(col);
            var col0 = new DataGridViewColumn();
            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
            col0.ReadOnly = publicSubsNFunctions.load_from_alumni;
            col0.Name = "IndexNo";
            col0.HeaderText = "INDEX";
            col0.CellTemplate = cel0;
            col0.SortMode = DataGridViewColumnSortMode.Automatic;
            col0.Width = 80;
            dgvSubjects.Columns.Add(col0);
            var col2 = new DataGridViewColumn();
            DataGridViewCell cel2 = new DataGridViewTextBoxCell();
            col2.ReadOnly = publicSubsNFunctions.load_from_alumni;
            col2.Name = "StudentName";
            col2.HeaderText = "Name Of Student";
            col2.CellTemplate = cel2;
            col2.Width = 150;
            dgvSubjects.Columns.Add(col2);
            var col3 = new DataGridViewColumn();
            DataGridViewCell cel3 = new DataGridViewTextBoxCell();
            col3.ReadOnly = publicSubsNFunctions.load_from_alumni;
            col3.Name = "Stream";
            col3.HeaderText = "STR";
            col3.CellTemplate = cel3;
            col3.Width = 50;
            dgvSubjects.Columns.Add(col3);
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                var column = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                column.CellTemplate = cell;
                try
                {
                    column.Name = Conversions.ToString(publicSubsNFunctions.subjname[k]);
                    column.HeaderText = Conversions.ToString(publicSubsNFunctions.subjabb[k].Substring((object)0, (object)3));
                }
                catch (Exception ex)
                {
                    column.Name = Conversions.ToString(publicSubsNFunctions.subjname[k]);
                    column.HeaderText = Conversions.ToString(publicSubsNFunctions.subjabb[k].Substring((object)0, (object)2));
                }

                column.Width = 45;
                dgvSubjects.Columns.Add(column);
            }

            var col5 = new DataGridViewColumn();
            DataGridViewCell cel5 = new DataGridViewTextBoxCell();
            col5.ReadOnly = false;
            col5.Name = "mg";
            col5.HeaderText = "MG";
            col5.CellTemplate = cel5;
            col5.Width = 80;
            dgvSubjects.Columns.Add(col5);
            var col4 = new DataGridViewColumn();
            DataGridViewCell cel4 = new DataGridViewTextBoxCell();
            col4.ReadOnly = false;
            col4.Name = "tp";
            col4.HeaderText = "TP";
            col4.CellTemplate = cel4;
            col4.Width = 80;
            col4.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvSubjects.Columns.Add(col4);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (up_date)
            {
                publicSubsNFunctions.start();
                for (int k = 0, loopTo = dgvSubjects.Rows.Count - 2; k <= loopTo; k++)
                {
                    string argq = "SELECT ADMNo FROM `kcse_results` WHERE IndexNo='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvSubjects["IndexNo", k].Value)) + "'";
                    if (publicSubsNFunctions.qread(ref argq))
                    {
                        if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                        {
                            publicSubsNFunctions.query = "UPDATE `kcse_results` SET";
                            for (int col = 1, loopTo1 = dgvSubjects.Columns.Count - 1; col <= loopTo1; col++)
                            {
                                publicSubsNFunctions.query += "`" + dgvSubjects.Columns[col].Name + "`='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvSubjects[dgvSubjects.Columns[col].Name, k].Value)) + "'";
                                if (col < dgvSubjects.Columns.Count - 1)
                                {
                                    publicSubsNFunctions.query += ",";
                                }
                            }

                            publicSubsNFunctions.query += " WHERE IndexNo='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvSubjects["IndexNo", k].Value)) + "' AND year='" + publicSubsNFunctions.yr + "'";
                        }
                        else
                        {
                            publicSubsNFunctions.query = "INSERT INTO `kcse_results`(";
                            for (int cnt = 0, loopTo2 = dgvSubjects.Columns.Count - 1; cnt <= loopTo2; cnt++)
                            {
                                publicSubsNFunctions.query += "`" + dgvSubjects.Columns[cnt].Name + "`";
                                if (cnt < dgvSubjects.Columns.Count - 1)
                                {
                                    publicSubsNFunctions.query += ",";
                                }
                            }

                            publicSubsNFunctions.query += ") VALUES(NULL,'" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "'," + publicSubsNFunctions.yr + ",";
                            for (int j = 0, loopTo3 = dgvSubjects.Columns.Count - 1; j <= loopTo3; j++)
                            {
                                publicSubsNFunctions.query = publicSubsNFunctions.query + "'" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvSubjects[dgvSubjects.Columns[j].Name, k].Value)) + "'";
                                if (j < dgvSubjects.Columns.Count - 1)
                                {
                                    publicSubsNFunctions.query = publicSubsNFunctions.query + ", ";
                                }
                                else
                                {
                                    publicSubsNFunctions.query = publicSubsNFunctions.query + ")";
                                }
                            }
                        }
                    }

                    if (!publicSubsNFunctions.qwrite(publicSubsNFunctions.query))
                    {
                        publicSubsNFunctions.rollback();
                        publicSubsNFunctions.failure("Could Not Save The Data");
                        return;
                    }
                }

                publicSubsNFunctions.commit();
                publicSubsNFunctions.success("Examination Record Successfully Saved!");
                up_date = true;
                btnSave.Text = "&Update";
            }
            else
            {
                save_exam();
            }
        }

        private void save_exam()
        {
            string save_query = "INSERT INTO `kcse_results` VALUES";
            for (int k = 0, loopTo = dgvSubjects.Rows.Count - 3; k <= loopTo; k++)
            {
                save_query += "(NULL,'" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "', " + publicSubsNFunctions.yr + ",";
                for (int j = 0, loopTo1 = dgvSubjects.Columns.Count - 1; j <= loopTo1; j++)
                {
                    save_query = save_query + "'" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvSubjects[dgvSubjects.Columns[j].Name, k].Value)) + "'";
                    if (j < dgvSubjects.Columns.Count - 1)
                    {
                        save_query = save_query + ", ";
                    }
                    else
                    {
                        save_query = save_query + ")";
                    }
                }

                if (k < dgvSubjects.Rows.Count - 3)
                {
                    save_query += ",";
                }
            }

            if (publicSubsNFunctions.qwrite(save_query))
            {
                publicSubsNFunctions.success("Examination Record Successfully Saved!");
                up_date = true;
                btnSave.Text = "&Update";
            }
            else
            {
                publicSubsNFunctions.failure("Examination Results Could NOt Be Saved!");
            }
        }

        private int start_from = 0;

        private void print_report2(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            int line = 20;
            int left_margin = 90;
            int right_margin = 1050;
            int count = 0;
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

                if ((publicSubsNFunctions.S_NAME ?? "") != (string.Empty ?? ""))
                {
                    e.Graphics.DrawString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font, Brushes.Black, left_margin + 180, line);
                    line += publicSubsNFunctions.header_font.Height + 2;
                }

                if ((publicSubsNFunctions.S_ADDRESS ?? "") != (string.Empty ?? ""))
                {
                    e.Graphics.DrawString("P.O. BOX " + publicSubsNFunctions.S_ADDRESS.ToUpper() + ", " + publicSubsNFunctions.S_LOCATION.ToUpper(), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 220, line);
                    line += publicSubsNFunctions.other_font.Height + 5;
                }

                if ((publicSubsNFunctions.S_PHONE ?? "") != (string.Empty ?? ""))
                {
                    e.Graphics.DrawString("TELEPHONE: " + publicSubsNFunctions.S_PHONE, publicSubsNFunctions.other_font, Brushes.Black, left_margin + 220, line);
                    line += publicSubsNFunctions.other_font.Height + 5;
                }

                if (publicSubsNFunctions.mode)
                {
                    for (int k = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo; k++)
                    {
                        publicSubsNFunctions.exam_name = Conversions.ToString(publicSubsNFunctions.exam_name + publicSubsNFunctions.exam_names[k]);
                        if (k > 0)
                        {
                            publicSubsNFunctions.exam_name += "/";
                        }
                    }
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ComboBox1.SelectedItem, "All", false)))
                {
                    e.Graphics.DrawString("FORM 4 MERIT LIST FOR " + publicSubsNFunctions.exam_name + " EXAM, TERM " + publicSubsNFunctions.yr, publicSubsNFunctions.other_font, Brushes.Black, left_margin + 180, line);
                }
                else
                {
                    e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("FORM 4 ", ComboBox1.SelectedItem), " MERIT LIST FOR "), publicSubsNFunctions.exam_name), " EXAM, TERM "), publicSubsNFunctions.yr)), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 180, line);
                }

                line += publicSubsNFunctions.other_font.Height + 5;
            }

            line += 10;
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 3, right_margin, line - 3);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 2, right_margin, line - 2);
            e.Graphics.DrawLine(Pens.Black, left_margin, line - 1, right_margin, line - 1);
            line += 10;
            e.Graphics.DrawString("S/N", publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
            left_margin += 30;
            for (int col = 1, loopTo1 = dgvSubjects.Columns.Count - 1; col <= loopTo1; col++)
            {
                if (dgvSubjects.Columns[col].Visible)
                {
                    if (count == 1)
                    {
                        e.Graphics.DrawString(dgvSubjects.Columns[col].HeaderText, publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                    }
                    else
                    {
                        try
                        {
                            e.Graphics.DrawString(dgvSubjects.Columns[col].HeaderText.Substring(0, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                        }
                        catch (Exception ex)
                        {
                            e.Graphics.DrawString(dgvSubjects.Columns[col].HeaderText, publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                        }
                    }

                    count += 1;
                    if (count == 2)
                    {
                        left_margin += 170;
                    }
                    else
                    {
                        left_margin += 30;
                    }
                }
            }

            line += 10;
            for (int row = start_from, loopTo2 = dgvSubjects.Rows.Count - 2; row <= loopTo2; row++)
            {
                line += 2;
                if (line >= 750 & row < dgvSubjects.Rows.Count - 1)
                {
                    e.HasMorePages = true;
                    start_from = row;
                    return;
                }

                left_margin = 120;
                e.Graphics.DrawString((row + 1).ToString(), publicSubsNFunctions.smallfont, Brushes.Black, left_margin - 30, line);
                count = 0;
                for (int col = 1, loopTo3 = dgvSubjects.Columns.Count - 1; col <= loopTo3; col++)
                {
                    if (dgvSubjects.Columns[col].Visible)
                    {
                        try
                        {
                            e.Graphics.DrawString(Conversions.ToString(dgvSubjects[dgvSubjects.Columns[col].Name, row].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                        }
                        catch (Exception ex)
                        {
                        }

                        count += 1;
                        if (count == 2)
                        {
                            left_margin += 170;
                        }
                        else
                        {
                            left_margin += 30;
                        }
                    }
                }

                e.Graphics.DrawLine(Pens.Black, 90, line, left_margin, line);
                line += publicSubsNFunctions.smallfont.Height;
            }

            line += 5;
            if (line + 60 >= 806)
            {
                start_from = dgvSubjects.Rows.Count;
                e.HasMorePages = true;
                return;
            }

            line += 20;
            // Dim topline As Integer = line
            // For k As Integer = 0 To grades.Length - 1
            // e.Graphics.DrawString(grades(k), other_font, Brushes.Black, left_margin, line - 8)
            // e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin, line)
            // line += 20
            // Next
            // e.Graphics.DrawLine(Pens.Gray, left_margin + 20, line, right_margin, line)
            // Dim graphtop As Integer = topline
            // left_margin += 30
            // For k As Integer = 0 To subjabb.Length - 1
            // graphtop = topline
            // For g As Integer = 0 To grades.Length - 1
            // If dgvSubjects.Item(subjname(k).ToString, dgvSubjects.Rows.Count - 1).Value = grades(g) Then
            // Dim rect = New Rectangle(left_margin + (k * 10), graphtop, 10, line - graphtop)
            // e.Graphics.FillRectangle(Brushes.Silver, rect)
            // Else
            // graphtop += 20
            // End If
            // Next
            // left_margin += 20
            // Next
            // line += 10
            // left_margin = 260
            // left_margin += 20
            // For k As Integer = 0 To subjabb.Length - 1
            // Try
            // e.Graphics.DrawString(subjabb(k).ToString.Substring(0, 3), smallfont, Brushes.Black, left_margin, line)
            // Catch ex As Exception
            // e.Graphics.DrawString(subjabb(k).ToString, smallfont, Brushes.Black, left_margin, line)
            // End Try
            // left_margin += 30
            // Next
            line += 30;
            left_margin = 90;
            e.Graphics.DrawString("   SE	= SUBJECT ENTRIES					STR 	= STREAM" + Constants.vbNewLine + "   TP	= TOTAL POINTS					S.P		= STREAM POSITION" + Constants.vbNewLine + "   MP	= MEAN POINTS					                 O.P    = OVERALL (CLASS) POSITION" + Constants.vbNewLine + "   TM	= TOTAL MARKS					VAP     = VALUE ADDED PROGRESS (DEVIATION)", publicSubsNFunctions.other_font, Brushes.Black, left_margin, line);
            start_from = 0;
        }

        private object print_student_report2()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_report2;
            return print_document;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            var Print_Preview = new PrintPreviewDialog();
            var print_dialog = new PrintDialog();
            PrintDocument print_document = (PrintDocument)print_student_report2();
            print_document.DefaultPageSettings.Landscape = true;
            Print_Preview.Document = print_document;
            Print_Preview.ShowDialog();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }
    }
}