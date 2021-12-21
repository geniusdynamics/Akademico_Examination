using System;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmGradesAttained
    {
        public frmGradesAttained()
        {
            InitializeComponent();
            _btnPrint.Name = "btnPrint";
            _btnCancel.Name = "btnCancel";
            _cboStream.Name = "cboStream";
            _btnPrintPreview.Name = "btnPrintPreview";
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
                column.ReadOnly = true;
                column.Width = 46;
                dgvSubjects.Columns.Add(column);
            }

            for (int k = 0, loopTo2 = dgvSubjects.Rows.Count - 1; k <= loopTo2; k++)
                dgvSubjects["Grade", k].Value = publicSubsNFunctions.subjects[k];
            var tp = new DataGridViewColumn();
            tp.CellTemplate = cel;
            tp.Width = 60;
            tp.Name = "STP";
            tp.HeaderText = "S. T. P.";
            tp.ReadOnly = true;
            dgvSubjects.Columns.Add(tp);
            var mp = new DataGridViewColumn();
            mp.CellTemplate = cel;
            mp.Width = 60;
            mp.Name = "SMP";
            mp.HeaderText = "S. M. P.";
            mp.ReadOnly = true;
            dgvSubjects.Columns.Add(mp);
            var mg = new DataGridViewColumn();
            mg.CellTemplate = cel;
            mg.Width = 50;
            mg.Name = "MG";
            mg.ReadOnly = true;
            mg.HeaderText = "M.G.";
            dgvSubjects.Columns.Add(mg);
            for (int k = 0, loopTo3 = dgvSubjects.Rows.Count - 1; k <= loopTo3; k++)
            {
                for (int j = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; j <= loopTo4; j++)
                    dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value = "-";
            }
        }

        private void frmGradesAttained_Load(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(!publicSubsNFunctions.connect(), publicSubsNFunctions.dbNewOpen())))
            {
                Close();
            }
            else
            {
                var argcbo = cboStream;
                publicSubsNFunctions.fill_class(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), ref argcbo);
                cboStream = argcbo;
                cboStream.Items.Add("All");
                cboStream.SelectedItem = "All";
                load_data();
                state = true;
            }
        }

        private void load_data()
        {
            pbar.Visible = true;
            create_form();
            if (publicSubsNFunctions.mode)
            {
                ismode();
            }
            else
            {
                not_mode();
            }

            pbar.Increment(-100);
            int inc;
            inc = (int)Math.Round(100d / publicSubsNFunctions.grades.Length);
            for (int k = 0, loopTo = publicSubsNFunctions.grades.Length - 1; k <= loopTo; k++)
            {
                if (!Information.IsNumeric(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k), (object)(dgvSubjects.Rows.Count - 1)).Value))
                {
                    dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k), dgvSubjects.Rows.Count - 1).Value = "-";
                }

                pbar.Increment(inc);
            }

            pbar.Increment(-100);
            inc = (int)Math.Round(100d / dgvSubjects.Rows.Count);
            compute_totals();
            for (int k = 0, loopTo1 = dgvSubjects.Rows.Count - 1; k <= loopTo1; k++)
            {
                if (Information.IsNumeric(dgvSubjects["SMP", k].Value))
                {
                    dgvSubjects["SMP", k].Value = Convert.ToDouble(dgvSubjects["SMP", k].Value);
                }
                else
                {
                    dgvSubjects["SMP", k].Value = 0.0d;
                }
            }

            dgvSubjects.Rows.Add();
            dgvSubjects["GRADE", dgvSubjects.Rows.Count - 1].Value = "OVERALL MEAN GRADE";
            for (int j = 0, loopTo2 = publicSubsNFunctions.grades.Length - 1; j <= loopTo2; j++)
                dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), dgvSubjects.Rows.Count - 1).Value = "-";
            means();
            compute_totals(dgvSubjects.Rows.Count - 1);
            for (int k = 0, loopTo3 = dgvSubjects.Rows.Count - 1; k <= loopTo3; k++)
            {
                if (Information.IsNumeric(dgvSubjects["SMP", k].Value))
                {
                    dgvSubjects["MG", k].Value = publicSubsNFunctions.get_points(Conversions.ToDouble(dgvSubjects["SMP", k].Value));
                }
                else
                {
                    dgvSubjects["MG", k].Value = "--";
                }

                dgvSubjects["SMP", k].Value = Strings.Format(dgvSubjects["SMP", k].Value, "0.00");
                pbar.Increment(inc);
            }

            dgvSubjects.Sort(dgvSubjects.Columns["SMP"], System.ComponentModel.ListSortDirection.Descending);
            double tp = default, tot = default;
            for (int k = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; k <= loopTo4; k++)
            {
                try
                {
                    tp = Conversions.ToDouble(tp + Operators.MultiplyObject(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k), (object)(dgvSubjects.Rows.Count - 1)).Value, publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.grades[k]))));
                    tot = Conversions.ToDouble(tot + dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k), (object)(dgvSubjects.Rows.Count - 1)).Value);
                }
                catch (Exception ex)
                {
                }
            }

            dgvSubjects["ENTRY", dgvSubjects.Rows.Count - 1].Value = tot;
            dgvSubjects["STP", dgvSubjects.Rows.Count - 1].Value = tp;
            dgvSubjects["SMP", dgvSubjects.Rows.Count - 1].Value = Math.Round(tp / tot, 3, MidpointRounding.AwayFromZero);
            dgvSubjects["MG", dgvSubjects.Rows.Count - 1].Value = publicSubsNFunctions.get_points(tp / tot);
            pbar.Increment(-100);
            pbar.Visible = false;
        }

        private void means()
        {
            string sum;
            var overall_grades = new object[publicSubsNFunctions.grades.Length];
            if (publicSubsNFunctions.best_of_7)
            {
                if (publicSubsNFunctions.mod_subject)
                {
                    sum = "B7SB_TP";
                }
                else
                {
                    sum = "B7NSB_TP";
                }
            }
            else if (publicSubsNFunctions.mod_subject)
            {
                sum = "SB_TP";
            }
            else
            {
                sum = "NSB_TP";
            }

            if (!publicSubsNFunctions.mode)
            {
                if (publicSubsNFunctions.best_of_7)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboStream.SelectedItem, "All", false)))
                    {
                        publicSubsNFunctions.query = "SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE (class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND " + sum + ">0)";
                    }
                    else
                    {
                        publicSubsNFunctions.query = "SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE (class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Stream='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboStream.SelectedItem)) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND " + sum + ">0)";
                    }
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboStream.SelectedItem, "All", false)))
                {
                    publicSubsNFunctions.query = "SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE (class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "')";
                }
                else
                {
                    publicSubsNFunctions.query = "SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE (class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Stream='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboStream.SelectedItem)) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "')";
                }

                publicSubsNFunctions.qread(ref publicSubsNFunctions.query);
                object temp, count;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    count = 0;
                    if (publicSubsNFunctions.best_of_7)
                    {
                        temp = publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], 7)));
                    }
                    else
                    {
                        for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                        {
                            if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjname[k])))
                            {
                                count += 1;
                            }
                        }

                        temp = publicSubsNFunctions.get_points(Conversions.ToDouble(Operators.DivideObject(publicSubsNFunctions.dbreader[sum], count)));
                    }

                    for (int k = 0, loopTo1 = publicSubsNFunctions.grades.Length - 1; k <= loopTo1; k++)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(temp, publicSubsNFunctions.grades[k], false)))
                        {
                            overall_grades[k] += 1;
                            break;
                        }
                    }
                }

                for (int k = 0, loopTo2 = overall_grades.Length - 1; k <= loopTo2; k++)
                    dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k.ToString()), dgvSubjects.Rows.Count - 1).Value = overall_grades[k];
            }
            else
            {
                for (int k = 0, loopTo3 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo3; k++)
                {
                }
            }
        }

        private void compute_totals(int start = 0)
        {
            int count, inc;
            pbar.Increment(-100);
            inc = (int)Math.Round(100d / publicSubsNFunctions.subjabb.Length);
            for (int s = 0, loopTo = dgvSubjects.Rows.Count - 2; s <= loopTo; s++)
            {
                count = 0;
                dgvSubjects["STP", s].Value = 0;
                for (int k = 0, loopTo1 = publicSubsNFunctions.grades.Length - 1; k <= loopTo1; k++)
                {
                    if (Information.IsNumeric(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k.ToString()), s).Value))
                    {
                        dgvSubjects["STP", s].Value += Operators.MultiplyObject(publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.grades[k])), dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k.ToString()), s).Value);
                        count = Conversions.ToInteger(count + dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[k].Substring((object)0, (object)1), k.ToString()), s).Value);
                    }
                }

                if (count > 0)
                {
                    dgvSubjects["SMP", s].Value = Convert.ToDouble(dgvSubjects["STP", s].Value) / count;
                }
                else
                {
                    dgvSubjects["SMP", s].Value = "--";
                }

                dgvSubjects["ENTRY", s].Value = count;
                pbar.Increment(inc);
            }
        }

        private string LargestTable()
        {
            string LargestTableRet = default;
            LargestTableRet = null;
            int large = 0;
            for (int k = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo; k++)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT id FROM exam_results WHERE (class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' AND Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k])) + "' AND Term='", publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "')"));
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

        private object largest_index;

        private void ismode()
        {
            int m, j;
            m = 0;
            j = 0;
            string largest_table = LargestTable();
            string opt_query = null;
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboStream.SelectedItem, "All", false), Operators.ConditionalCompareObjectNotEqual(cboStream.SelectedItem, null, false))))
            {
                opt_query = " AND stream = '" + publicSubsNFunctions.escape_string(Conversions.ToString(cboStream.SelectedItem)) + "'";
            }

            pbar.Visible = true;
            var inc = default(int);
            pbar.Increment(-100);
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ADMNo FROM `" + publicSubsNFunctions.table + "` WHERE (class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' AND Examination='" + publicSubsNFunctions.escape_string(largest_table) + "' AND Term='", publicSubsNFunctions.tms[Conversions.ToInteger(largest_index)]), "' AND Year='"), publicSubsNFunctions.yrs[Conversions.ToInteger(largest_index)]), "'"), opt_query), ")"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 100)
                {
                    inc = (int)Math.Round(publicSubsNFunctions.dbreader.RecordsAffected / 100d);
                }
                else
                {
                    inc = (int)Math.Round(100d / publicSubsNFunctions.dbreader.RecordsAffected);
                }

                admnos = new object[publicSubsNFunctions.dbreader.RecordsAffected];
                while (publicSubsNFunctions.dbreader.Read())
                {
                    admnos[m] = publicSubsNFunctions.dbreader["ADMNo"];
                    m += 1;
                    if (m % inc == 0)
                    {
                        pbar.Increment(1);
                    }
                }
            }

            pbar.Increment(-100);
            vals_alt = new string[publicSubsNFunctions.subjabb.Length];
            vals = new object[publicSubsNFunctions.subjabb.Length];
            double out_of;
            var loopTo = admnos.Length - 1;
            for (m = 0; m <= loopTo; m++)
            {
                for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                {
                    vals[k] = 0;
                    vals_alt[k] = null;
                }

                for (int k = 0, loopTo2 = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo2; k++)
                {
                    string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE (class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' AND ADMNo='", admnos[m]), "' AND Examination='"), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.exam_names[k]))), "' AND Term='"), publicSubsNFunctions.tms[k]), "' AND Year='"), publicSubsNFunctions.yrs[k]), "')"));
                    if (publicSubsNFunctions.qread(ref argq1))
                    {
                        if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                        {
                            publicSubsNFunctions.dbreader.Read();
                            var loopTo3 = publicSubsNFunctions.subjabb.Length - 1;
                            for (j = 0; j <= loopTo3; j++)
                            {
                                if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[j])))
                                {
                                    out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.tms[k], publicSubsNFunctions.yrs[k], publicSubsNFunctions.exam_names[k], publicSubsNFunctions.class_form, publicSubsNFunctions.dbreader["Stream"], 2);
                                    vals[j] += Operators.MultiplyObject(Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[j]), out_of), publicSubsNFunctions.total_mark[k]), publicSubsNFunctions.contribution[k] / 100d);
                                }
                                else
                                {
                                    vals_alt[j] = Conversions.ToString(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[j]));
                                }
                            }
                        }
                    }
                }

                string val;
                for (int k = 0, loopTo4 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo4; k++)
                {
                    if (string.IsNullOrEmpty(vals_alt[k]))
                    {
                        val = Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(vals[k]), publicSubsNFunctions.mod_subject, Conversions.ToString(publicSubsNFunctions.subjects[k])));
                        var loopTo5 = publicSubsNFunctions.grades.Length - 3;
                        for (j = 0; j <= loopTo5; j++)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(val, publicSubsNFunctions.grades[j], false)))
                            {
                                if (Information.IsNumeric(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value))
                                {
                                    dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value = Operators.AddObject(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value, 1);
                                }
                                else
                                {
                                    dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value = 1;
                                }

                                break;
                            }
                        }
                    }
                    else if (vals_alt[k] == "X")
                    {
                        if (Information.IsNumeric(dgvSubjects["X12", k].Value))
                        {
                            dgvSubjects["X12", k].Value = Operators.AddObject(dgvSubjects["X12", k].Value, 1);
                        }
                        else
                        {
                            dgvSubjects["X12", k].Value = 1;
                        }
                    }
                    else if (vals_alt[k] == "Y")
                    {
                        if (Information.IsNumeric(dgvSubjects["Y13", k].Value))
                        {
                            dgvSubjects["Y13", k].Value = Operators.AddObject(dgvSubjects["Y13", k].Value, 1);
                        }
                        else
                        {
                            dgvSubjects["Y13", k].Value = 1;
                        }
                    }
                }

                if (m % inc == 0)
                {
                    pbar.Increment(1);
                }
            }
        }

        private void not_mode()
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboStream.SelectedItem, "All", false)))
            {
                publicSubsNFunctions.query = "SELECT ADMNo, Stream FROM `" + publicSubsNFunctions.table + "` WHERE (class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' AND  Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "')";
            }
            else
            {
                publicSubsNFunctions.query = "SELECT ADMNo, Stream FROM `" + publicSubsNFunctions.table + "` WHERE (Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND class='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.class_form) + "' AND Stream='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboStream.SelectedItem)) + "' AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "')";
            }

            pbar.Visible = true;
            int inc;
            if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
            {
                admnos = new object[publicSubsNFunctions.dbreader.RecordsAffected];
                if (admnos.Length > 100)
                {
                    inc = (int)Math.Round(publicSubsNFunctions.dbreader.RecordsAffected / 100d);
                }
                else
                {
                    inc = 1;
                }

                int m = 0;
                while (publicSubsNFunctions.dbreader.Read())
                {
                    admnos[m] = publicSubsNFunctions.dbreader["ADMNo"];
                    pbar.Increment(inc);
                    m += 1;
                }

                pbar.Increment(-100);
                vals_alt = new string[publicSubsNFunctions.subjabb.Length];
                vals = new object[publicSubsNFunctions.subjabb.Length];
                double out_of;
                var loopTo = admnos.Length - 1;
                for (m = 0; m <= loopTo; m++)
                {
                    string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM `" + publicSubsNFunctions.table + "` WHERE (ADMNo='", admnos[m]), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND Term='"), publicSubsNFunctions.tm), "' AND Year='"), publicSubsNFunctions.yr), "')"));
                    if (publicSubsNFunctions.qread(ref argq))
                    {
                        publicSubsNFunctions.dbreader.Read();
                        for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                        {
                            if (Information.IsNumeric(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k])))
                            {
                                out_of = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], publicSubsNFunctions.tm, publicSubsNFunctions.yr, publicSubsNFunctions.exam_name, publicSubsNFunctions.class_form, publicSubsNFunctions.dbreader["Stream"], 2);
                                vals[k] = Operators.MultiplyObject(Operators.DivideObject(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k]), out_of), publicSubsNFunctions.marks);
                                vals_alt[k] = 0.ToString();
                            }
                            else
                            {
                                vals[k] = publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k]);
                                vals_alt[k] = Conversions.ToString(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[k]));
                            }
                        }

                        string val;
                        for (int k = 0, loopTo2 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo2; k++)
                        {
                            if (Information.IsNumeric(vals[k]))
                            {
                                val = Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(vals[k]), publicSubsNFunctions.mod_subject, Conversions.ToString(publicSubsNFunctions.subjabb[k])));
                            }
                            else
                            {
                                val = Conversions.ToString(vals[k]);
                            }

                            for (int j = 0, loopTo3 = publicSubsNFunctions.grades.Length - 1; j <= loopTo3; j++)
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(val, publicSubsNFunctions.grades[j], false)))
                                {
                                    if (Information.IsNumeric(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value))
                                    {
                                        dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value = Operators.AddObject(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value, 1);
                                        break;
                                    }
                                    else
                                    {
                                        dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value = 1;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    pbar.Increment(inc);
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
            string argq = "SELECT image_path FROM school_details";
            publicSubsNFunctions.qread(ref argq);
            publicSubsNFunctions.dbreader.Read();
            logoRet = Conversions.ToString(publicSubsNFunctions.dbreader["image_path"]);
            publicSubsNFunctions.dbreader.Close();
            return logoRet;
        }

        private void print_report(object sender, PrintPageEventArgs e)
        {
            // e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)
            int line;
            int left_margin = 20;
            int right_margin = (publicSubsNFunctions.grades.Length + 4) * 45 + 272;
            int topline = 250;
            try
            {
                e.Graphics.DrawImage(Image.FromFile(publicSubsNFunctions.path + @"\student_images\" + logo()), (int)Math.Round(e.PageBounds.Width / 2d) - 50, topline - 230, 100, 100);
            }
            catch (Exception ex)
            {
            }

            float CenterPage;
            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font).Width / 2f);
            e.Graphics.DrawString(publicSubsNFunctions.S_NAME.ToUpper(), publicSubsNFunctions.header_font, Brushes.Black, CenterPage, 130f);
            if (publicSubsNFunctions.mode)
            {
                publicSubsNFunctions.exam_name = null;
                for (int k = 0, loopTo = publicSubsNFunctions.exam_names.Length - 1; k <= loopTo; k++)
                {
                    publicSubsNFunctions.exam_name = Conversions.ToString(publicSubsNFunctions.exam_name + publicSubsNFunctions.exam_names[k]);
                    if (k < publicSubsNFunctions.exam_names.Length - 1)
                    {
                        publicSubsNFunctions.exam_name += "/";
                    }
                }
            }

            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(publicSubsNFunctions.exam_name.ToUpper() + " TERM " + publicSubsNFunctions.tm + " " + publicSubsNFunctions.yr + " EXAMINATION PERFORMANCE ANALYSIS", publicSubsNFunctions.header_font).Width / 2f);
            e.Graphics.DrawString(publicSubsNFunctions.exam_name.ToUpper() + " TERM " + publicSubsNFunctions.tm + " " + publicSubsNFunctions.yr + " EXAMINATION PERFORMANCE ANALYSIS", publicSubsNFunctions.header_font, Brushes.Black, CenterPage, 160f);
            string class_name = publicSubsNFunctions.class_form.ToString().ToUpper();
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(cboStream.SelectedItem, "All", false)))
            {
                class_name = Conversions.ToString(class_name + Operators.ConcatenateObject(" ", cboStream.SelectedItem));
            }
            else
            {
                class_name += " COMBINED";
            }

            CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(class_name, publicSubsNFunctions.other_font).Width / 2f);
            e.Graphics.DrawString(class_name, publicSubsNFunctions.header_font, Brushes.Black, CenterPage, 190f);
            line = topline - 20;
            int col = 300;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line);
            e.Graphics.DrawString("GRADES ATTAINED PER SUBJECT", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 5, line + 5);
            for (int k = 0, loopTo1 = publicSubsNFunctions.grades.Length - 1; k <= loopTo1; k++)
            {
                e.Graphics.DrawString(Conversions.ToString(publicSubsNFunctions.grades[k]), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 2, line + 5);
                col += 40;
            }

            e.Graphics.DrawString("STP", publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 5);
            col += 40;
            e.Graphics.DrawString("SMP", publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 2, line + 5);
            col += 70;
            e.Graphics.DrawString("ENTRY", publicSubsNFunctions.other_font, Brushes.Black, left_margin + col - 9, line + 5);
            col += 40;
            e.Graphics.DrawString("MG", publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 5, line + 5);
            line += 22;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2);
            for (int k = 0, loopTo2 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo2; k++)
            {
                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["Grade", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + 5, line + 3);
                line += 22;
                e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2);
            }

            e.Graphics.DrawString("OVERALL MEAN GRADE", publicSubsNFunctions.other_font, Brushes.Black, left_margin + 5, line + 3);
            line += 22;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, line + 2, right_margin - 2, line + 2);
            line = topline + 22 - 20;
            col = 300;
            for (int k = 0, loopTo3 = dgvSubjects.Rows.Count - 1; k <= loopTo3; k++)
            {
                for (int j = 0, loopTo4 = publicSubsNFunctions.grades.Length - 1; j <= loopTo4; j++)
                {
                    e.Graphics.DrawString(Conversions.ToString(dgvSubjects.Item(Operators.ConcatenateObject(publicSubsNFunctions.grades[j].Substring((object)0, (object)1), j.ToString()), k).Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 5, line + 3);
                    col += 40;
                }

                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["STP", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col, line + 3);
                col += 40;
                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["SMP", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col - 5, line + 3);
                col += 70;
                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["ENTRY", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 5, line + 3);
                col += 50;
                e.Graphics.DrawString(Conversions.ToString(dgvSubjects["MG", k].Value), publicSubsNFunctions.other_font, Brushes.Black, left_margin + col + 5, line + 3);
                col = 300;
                line += 22;
            }
            // e.Graphics.DrawLine(Pens.Black, left_margin - 2, line, right_margin - 2, line)
            // e.Graphics.DrawLine(Pens.Black, left_margin + 250, topline, left_margin + 250, line + 2)
            col = 300;
            e.Graphics.DrawLine(Pens.Black, left_margin - 2, topline - 20, left_margin - 2, line + 2);
            for (int k = 0, loopTo5 = publicSubsNFunctions.grades.Length + 3; k <= loopTo5; k++)
            {
                e.Graphics.DrawLine(Pens.Black, left_margin + col - 10, topline - 20, left_margin + col - 10, line + 2);
                if (k == publicSubsNFunctions.grades.Length + 1)
                {
                    col += 70;
                }
                else if (k == publicSubsNFunctions.grades.Length + 2)
                {
                    col += 50;
                }
                else
                {
                    col += 40;
                }
            }

            e.Graphics.DrawLine(Pens.Black, right_margin - 2, topline - 20, right_margin - 2, line + 2);
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

        private bool state = false;

        private void cboStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (state)
            {
                load_data();
            }
        }
    }
}