using global::System;
using System.Collections.Generic;
using System.Data;
using static global::System.Diagnostics.Debugger;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmEnterMarks
    {
        public frmEnterMarks()
        {
            InitializeComponent();
            _Button3.Name = "Button3";
            _Button1.Name = "Button1";
            _btnCancel.Name = "btnCancel";
            _btnSave.Name = "btnSave";
            _btnClear.Name = "btnClear";
            _Button4.Name = "Button4";
            _Button2.Name = "Button2";
            _cboStream.Name = "cboStream";
            _cboClass.Name = "cboClass";
            _cboYear.Name = "cboYear";
            _cboTerm.Name = "cboTerm";
            _cboExamName.Name = "cboExamName";
            _btnImportResults.Name = "btnImportResults";
            _Editor.Name = "Editor";
            _deleteChk.Name = "deleteChk";
            _btnDelete.Name = "btnDelete";
        }

        private bool results_entered;
        private string msg;
        private object[] adm;

        private object check_results()
        {
            if (publicSubsNFunctions.class_stream != "All")
            {
                publicSubsNFunctions.query = "SELECT * FROM " + publicSubsNFunctions.table + " WHERE Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "'  AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND  class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "' AND Stream='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.stream) + "'";
            }
            else
            {
                publicSubsNFunctions.query = "SELECT * FROM " + publicSubsNFunctions.table + " WHERE Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "'  AND Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "' AND  class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "' ";
            }

            if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
            {
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
            else
            {
                return false;
            }
        }

        private bool IsEditableResults()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Entry FROM examinations WHERE (last_date_of_entry<='" + DateAndTime.Today.Year + "-" + Strings.Format(DateAndTime.Today.Month, "00") + "-" + Strings.Format(DateAndTime.Today.Day, "00") + "' AND ExamName='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboExamName.SelectedItem)) + "' AND Term='", cboTerm.SelectedItem), "' AND Year="), cboYear.SelectedItem), ")"));
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool is_editable;

        private void get_split_subjects(string subj)
        {
            string argq = "SELECT * FROM split_subjects WHERE subject='" + publicSubsNFunctions.escape_string(subj) + "' AND class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "' ORDER BY id ASC";
            publicSubsNFunctions.qread(ref argq);
            splits = new object[publicSubsNFunctions.dbreader.RecordsAffected];
            splits_cont = new object[publicSubsNFunctions.dbreader.RecordsAffected];
            int i = 0;
            while (publicSubsNFunctions.dbreader.Read())
            {
                splits[i] = publicSubsNFunctions.dbreader["abbreviation"];
                splits_cont[i] = publicSubsNFunctions.dbreader["contribution"];
                i += 1;
            }
        }

        private object[] splits, splits_cont;

        private void create_dataform()
        {
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                int split_count = 0;
                if (CheckBox1.Checked)
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
                        colINDEX1.ReadOnly = false;
                        colINDEX1.SortMode = DataGridViewColumnSortMode.Programmatic;
                        if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.subjects[k], cboSubject.SelectedItem, false), Operators.ConditionalCompareObjectEqual(cboSubject.SelectedItem, "All", false))))
                        {
                            colINDEX1.Visible = true;
                        }
                        else
                        {
                            colINDEX1.Visible = false;
                        }

                        dgvEnterMarks.Columns.Add(colINDEX1);
                        split_count += 1;
                    }
                }

                var column = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                column.CellTemplate = cell;
                if (Conversions.ToBoolean(Operators.AndObject(publicSubsNFunctions.subj == "All", publicSubsNFunctions.IsAdmin())))
                {
                    column.Visible = true;
                }
                else if (publicSubsNFunctions.subj == "All")
                {
                    if (publicSubsNFunctions.IsSubjectTeacher(Conversions.ToString(publicSubsNFunctions.subjects[k]), Conversions.ToString(cboClass.SelectedItem), Conversions.ToString(cboStream.SelectedItem), publicSubsNFunctions.tm, publicSubsNFunctions.yr.ToString()))
                    {
                        column.Visible = true & is_editable;
                    }
                    else
                    {
                        column.Visible = false;
                    }
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.subj, publicSubsNFunctions.subjects[k], false)))
                {
                    column.Visible = true & is_editable;
                }
                else
                {
                    column.Visible = false;
                }

                column.Width = 55;
                if (publicSubsNFunctions.subjabb.Length > 3)
                {
                    column.Name = Conversions.ToString(publicSubsNFunctions.subjname[k]);
                    if (CheckBox1.Checked)
                    {
                        column.Width = 0;
                    }

                    if (publicSubsNFunctions.IsPrimary() & split_count > 0)
                    {
                        column.ReadOnly = true;
                        column.HeaderText = "TOTAL";
                    }
                    else if (publicSubsNFunctions.subjabb[k].ToString().Length > 3)
                    {
                        column.HeaderText = Conversions.ToString(publicSubsNFunctions.remove_wild(Conversions.ToString(publicSubsNFunctions.subjabb[k].Substring((object)0, (object)3))));
                    }
                    else
                    {
                        column.HeaderText = Conversions.ToString(publicSubsNFunctions.remove_wild(Conversions.ToString(publicSubsNFunctions.subjabb[k])));
                    }
                }
                else
                {
                    column.Name = Conversions.ToString(publicSubsNFunctions.subjname[k]);
                    if (publicSubsNFunctions.IsPrimary() & split_count > 0)
                    {
                        column.HeaderText = "TOTAL";
                        column.Visible = false;
                        column.ReadOnly = true;
                    }
                    else
                    {
                        column.HeaderText = Conversions.ToString(publicSubsNFunctions.remove_wild(Conversions.ToString(publicSubsNFunctions.subjabb[k].Substring((object)0, (object)2))));
                    }
                }

                dgvEnterMarks.Columns.Add(column);
            }

            var column1 = new DataGridViewColumn();
            DataGridViewCell cell1 = new DataGridViewTextBoxCell();
            column1.Name = "Class";
            column1.HeaderText = "Class";
            column1.CellTemplate = cell1;
            column1.Visible = false;
            dgvEnterMarks.Columns.Add(column1);
            var column2 = new DataGridViewColumn();
            DataGridViewCell cell2 = new DataGridViewTextBoxCell();
            column2.Name = "Stream";
            column2.HeaderText = "Stream";
            column2.CellTemplate = cell2;
            column2.Visible = false;
            dgvEnterMarks.Columns.Add(column2);

            // dgvEnterMarks.AutoResizeColumns()

        }

        private void frmEnterMarks_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else if (Conversions.ToBoolean(!publicSubsNFunctions.get_subjects()))
            {
                Close();
            }
            else
            {
                fill_year();
                cboYear.SelectedItem = DateAndTime.Today.Year;
                CheckBox1.Checked = publicSubsNFunctions.IsPrimary();
                var argcbo = cboClass;
                publicSubsNFunctions.load_class(ref argcbo);
                cboClass = argcbo;
                cboTerm.SelectedItem = publicSubsNFunctions.tm;
                ComboBox1.SelectedIndex = 0;
            }
        }

        private void fill_year()
        {
            int i;
            cboYear.Items.Clear();
            var loopTo = publicSubsNFunctions.endyear;
            for (i = publicSubsNFunctions.startyear; i <= loopTo; i++)
                cboYear.Items.Add(i);
            cboYear.SelectedItem = DateAndTime.Today.Year;
        }

        private void load_entered()
        {
            string query1 = string.Empty;
            string adminNumber = string.Empty;
            dgvEnterMarks.Rows.Clear();
            if (publicSubsNFunctions.yr == DateAndTime.Today.Year)
            {
                if (publicSubsNFunctions.subj != "All")
                {
                    if (publicSubsNFunctions.stream == "All")
                    {
                        query1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT admin_no FROM students WHERE (class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "' AND IsStudent='True'  AND admin_no IN (SELECT admno FROM subjects_done WHERE `", publicSubsNFunctions.get_subject_name(publicSubsNFunctions.subj, true)), "`='Yes' )) ORDER BY admin_no"));
                    }
                    else
                    {
                        query1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT admin_no FROM students WHERE (class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "' AND stream='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.stream) + "' AND IsStudent='True'  AND admin_no IN (SELECT admno FROM subjects_done WHERE `", publicSubsNFunctions.get_subject_name(publicSubsNFunctions.subj, true)), "`='Yes' )) ORDER BY admin_no"));
                    }
                }
                else if (publicSubsNFunctions.stream == "All")
                {
                    query1 = "SELECT admin_no FROM students WHERE (class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "' AND IsStudent='True') ORDER BY admin_no";
                }
                else
                {
                    query1 = "SELECT admin_no FROM students WHERE (class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "' AND stream='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.stream) + "' AND IsStudent='True') ORDER BY admin_no";
                }
            }
            else if (publicSubsNFunctions.stream == "All")
            {
                publicSubsNFunctions.query = "SELECT * FROM exam_results WHERE (term='" + publicSubsNFunctions.tm + "' AND year='" + publicSubsNFunctions.yr + "' AND examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "') ORDER BY admno";
            }
            else
            {
                publicSubsNFunctions.query = "SELECT * FROM exam_results WHERE (term='" + publicSubsNFunctions.tm + "' AND year='" + publicSubsNFunctions.yr + "' AND examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND class='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboClass.SelectedItem)) + "' AND stream='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboStream.SelectedItem)) + "') ORDER BY admno";
            }

            if (!ReferenceEquals(query1, string.Empty))
            {
                publicSubsNFunctions.query = query1;
                adminNumber = "admin_no";
            }
            else
            {
                adminNumber = "admno";
            }

            if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
            {
                int i = 0;
                if (publicSubsNFunctions.dbreader.RecordsAffected == 0)
                {
                    load_new();
                    publicSubsNFunctions.dbreader.Close();
                }
                else
                {
                    adm = new object[publicSubsNFunctions.dbreader.RecordsAffected];
                    int k = 0;
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        adm[k] = publicSubsNFunctions.dbreader[adminNumber];
                        k += 1;
                    }

                    var loopTo = adm.Length - 1;
                    for (k = 0; k <= loopTo; k++)
                    {
                        string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM exam_results LEFT JOIN students ON students.admin_no=exam_results.admno WHERE term='" + publicSubsNFunctions.tm + "' AND year='" + publicSubsNFunctions.yr + "' AND examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND exam_results.admno='", adm[k]), "'"));
                        if (publicSubsNFunctions.qread(ref argq1))
                        {
                            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                            {
                                publicSubsNFunctions.dbreader.Read();
                                dgvEnterMarks.Rows.Add();
                                dgvEnterMarks["IndexNo", k].Value = publicSubsNFunctions.get_id(publicSubsNFunctions.dbreader["indexno"]);
                                dgvEnterMarks["admin_no", k].Value = publicSubsNFunctions.get_id(publicSubsNFunctions.dbreader[adminNumber]);
                                dgvEnterMarks["Class", k].Value = cboClass.SelectedItem;
                                dgvEnterMarks["Stream", k].Value = publicSubsNFunctions.dbreader["stream"];
                                dgvEnterMarks["StudentName", k].Value = publicSubsNFunctions.dbreader["studentname"];
                                dgvEnterMarks["Examination", k].Value = publicSubsNFunctions.dbreader["Examination"];
                                dgvEnterMarks["Term", k].Value = publicSubsNFunctions.dbreader["Term"];
                                dgvEnterMarks["Year", k].Value = publicSubsNFunctions.dbreader["Year"];
                                for (int j = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; j <= loopTo1; j++)
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[j]), string.Empty, false)))
                                    {
                                        dgvEnterMarks.Item(publicSubsNFunctions.subjname[j], k).Value = "-";
                                    }
                                    else
                                    {
                                        dgvEnterMarks.Item(publicSubsNFunctions.subjname[j], k).Value = publicSubsNFunctions.dbreader(publicSubsNFunctions.subjabb[j]);
                                    }
                                }
                            }
                            else
                            {
                                string argq = "SELECT admin_no, student_name, stream, indexno FROM students WHERE admin_no='" + publicSubsNFunctions.escape_string(Conversions.ToString(adm[k])) + "' AND IsStudent='True'";
                                publicSubsNFunctions.qread(ref argq);
                                publicSubsNFunctions.dbreader.Read();
                                dgvEnterMarks.Rows.Add();
                                dgvEnterMarks["IndexNo", k].Value = publicSubsNFunctions.get_id(publicSubsNFunctions.dbreader["indexno"]);
                                dgvEnterMarks["admin_no", k].Value = publicSubsNFunctions.get_id(publicSubsNFunctions.dbreader["admin_no"]);
                                dgvEnterMarks["StudentName", k].Value = publicSubsNFunctions.dbreader["student_name"];
                                dgvEnterMarks["Class", k].Value = cboClass.SelectedItem;
                                dgvEnterMarks["Stream", k].Value = publicSubsNFunctions.dbreader["Stream"];
                            }
                        }
                    }

                    if (CheckBox1.Checked)
                    {
                        load_split();
                    }

                    publicSubsNFunctions.dbreader.Close();
                    Text = publicSubsNFunctions.exam_name.ToUpper() + " EXAMINATION RESULTS ENTRY FOR " + publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper();
                }
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Read From The Database!");
                Close();
            }
        }

        private void load_split()
        {
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM exam_split_subject_results WHERE term='" + publicSubsNFunctions.tm + "' AND year='" + publicSubsNFunctions.yr + "' AND examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND admno='", dgvEnterMarks["admin_no", k].Value), "'"));
                publicSubsNFunctions.qread(ref argq);
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    publicSubsNFunctions.dbreader.Read();
                    for (int i = 6, loopTo1 = dgvEnterMarks.Columns.Count - 3; i <= loopTo1; i++)
                    {
                        if (dgvEnterMarks.Columns[i].Visible & is_split_subject(dgvEnterMarks.Columns[i].Name))
                        {
                            try
                            {
                                dgvEnterMarks[dgvEnterMarks.Columns[i].Name, k].Value = publicSubsNFunctions.dbreader[publicSubsNFunctions.class_form + "_" + dgvEnterMarks.Columns[i].Name];
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
            }
        }

        private void load_form()
        {
            results_entered = Conversions.ToBoolean(check_results());
            if (results_entered)
            {
                load_entered();
            }
            else
            {
                load_new();
            }

            if (dgvEnterMarks.RowCount == 0)
            {
                return;
            }

            if (ComboBox1.SelectedIndex == 0)
            {
                dgvEnterMarks.Sort(dgvEnterMarks.Columns["admin_no"], System.ComponentModel.ListSortDirection.Ascending);
                dgvEnterMarks.Columns["IndexNo"].Visible = false;
                dgvEnterMarks.Columns["admin_no"].Visible = true;
            }
            else if (ComboBox1.SelectedIndex == 1)
            {
                dgvEnterMarks.Sort(dgvEnterMarks.Columns["IndexNo"], System.ComponentModel.ListSortDirection.Ascending);
                dgvEnterMarks.Columns["admin_no"].Visible = false;
                dgvEnterMarks.Columns["IndexNo"].Visible = true;
            }
            else
            {
                dgvEnterMarks.Sort(dgvEnterMarks.Columns["StudentName"], System.ComponentModel.ListSortDirection.Ascending);
                dgvEnterMarks.Columns["IndexNo"].Visible = false;
                dgvEnterMarks.Columns["admin_no"].Visible = true;
            }
        }

        private void load_new()
        {
            if (publicSubsNFunctions.subj == "All")
            {
                if (publicSubsNFunctions.stream != "All")
                {
                    publicSubsNFunctions.query = "SELECT admin_no, student_name, stream, indexno FROM `students` WHERE class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "' AND stream='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.stream) + "'  AND IsStudent='True' ORDER BY admin_no";
                }
                else
                {
                    publicSubsNFunctions.query = "SELECT admin_no, student_name, stream, indexno FROM `students` WHERE class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "'  AND IsStudent='True'  ORDER BY admin_no";
                }
            }
            else if (publicSubsNFunctions.stream != "All")
            {
                publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT admin_no, student_name, stream, indexno FROM `students` WHERE (class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "' AND stream='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.stream) + "'  AND IsStudent='True' AND admin_no IN (SELECT admin_no FROM subjects_done WHERE `", publicSubsNFunctions.get_subject_name(publicSubsNFunctions.subj, true)), "`='Yes' )) ORDER BY admin_no"));
            }
            else
            {
                publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT admin_no, student_name, stream, indexno FROM `students` WHERE (class='" + publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form))) + "'  AND IsStudent='True'  AND admin_no IN (SELECT admin_no FROM subjects_done WHERE `", publicSubsNFunctions.get_subject_name(publicSubsNFunctions.subj, true)), "`='Yes' ))  ORDER BY admin_no"));
            }

            if (publicSubsNFunctions.qread(ref publicSubsNFunctions.query))
            {
                int i = 0;
                if (publicSubsNFunctions.dbreader.RecordsAffected == 0)
                {
                    publicSubsNFunctions.failure("No Student Records Found For Examination Marks Entry Operation!");
                    Close();
                }
                else
                {
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        dgvEnterMarks.Rows.Add();
                        dgvEnterMarks["IndexNo", i].Value = publicSubsNFunctions.get_id(publicSubsNFunctions.dbreader["indexno"]);
                        dgvEnterMarks["admin_no", i].Value = publicSubsNFunctions.get_id(publicSubsNFunctions.dbreader["admin_no"]);
                        dgvEnterMarks["StudentName", i].Value = publicSubsNFunctions.dbreader["student_name"];
                        dgvEnterMarks["Examination", i].Value = publicSubsNFunctions.exam_name;
                        dgvEnterMarks["Term", i].Value = publicSubsNFunctions.tm;
                        dgvEnterMarks["Year", i].Value = publicSubsNFunctions.yr;
                        dgvEnterMarks["Class", i].Value = cboClass.SelectedItem;
                        dgvEnterMarks["Stream", i].Value = publicSubsNFunctions.dbreader["stream"];
                        i += 1;
                    }

                    publicSubsNFunctions.dbreader.Close();
                    Text = publicSubsNFunctions.exam_name.ToUpper() + " EXAMINATION RESULTS ENTRY FOR " + publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form).ToString().ToUpper();
                }
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Read From The Database!");
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Save Data Before Closing Form?")))
            {
                save_now();
                Close();
            }
            else
            {
                Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            removeColumnDelete();
            if (!(OpenFileDialog1.ShowDialog() == DialogResult.OK))
            {
                return;
            }

            import_data();
        }

        private void import_data()
        {
            using (new DevExpress.Utils.WaitDialogForm("Importing excel results , Please Wait .....", "Importing Results"))
            {
                string fields_list = string.Empty;
                int col_count = 0;
                for (int k = 0, loopTo = dgvEnterMarks.Columns.Count - 1; k <= loopTo; k++)
                {
                    if (dgvEnterMarks.Columns[k].Visible)
                    {
                        if (col_count > 0)
                        {
                            fields_list += ",";
                        }

                        fields_list += dgvEnterMarks.Columns[k].Name;
                        col_count += 1;
                    }
                }

                var excel = new Excel.Application();
                Global.Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Open(OpenFileDialog1.FileName);
                Global.Microsoft.Office.Interop.Excel.Worksheet ws = excel.ActiveSheet as Excel.Worksheet;
                int i = 2;
                progress.Visible = true;
                progress.Increment(-100);
                string counter = string.Empty;
                while (ws.Cells(i, 1).Value2 != (default))
                {

                    // If i = 70 Then
                    // Debugger.Break()
                    // Break()
                    // End If

                    counter = ws.Cells(i, 1).Value.ToString();
                    col_count = 1;
                    int row_index = getRowIndex(ws.Cells(i, 1).Value2);
                    for (int k = 0, loopTo1 = dgvEnterMarks.Columns.Count - 1; k <= loopTo1; k++)
                    {
                        if (dgvEnterMarks.Columns[k].Visible)
                        {
                            dgvEnterMarks.Rows.Add();
                            dgvEnterMarks[dgvEnterMarks.Columns[k].Name, row_index].Value = ws.Cells(i, col_count).Value2;
                            col_count += 1;
                        }
                    }

                    progress.Increment(1);
                    i += 1;
                    if (!Information.IsNumeric(counter))
                    {
                        break;
                    }
                }

                progress.Visible = Conversions.ToBoolean(DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            }

            MessageBox.Show("The Operation Was Successful");
        }

        private int getRowIndex(string adm)
        {
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
            {
                if ((dgvEnterMarks["admin_no", k].Value.ToString() ?? "") == (adm ?? ""))
                {
                    return k;
                }
            }

            return default;
        }

        private object isvalid()
        {
            double out_of;
            progress.Visible = true;
            lblSave.Visible = true;
            lblSave.Text = "Validating Data...";
            int inc = (int)Math.Round(100d / dgvEnterMarks.Rows.Count);
            for (int i = 0, loopTo = dgvEnterMarks.Rows.Count - 1; i <= loopTo; i++)
            {
                for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                {
                    if (Conversions.ToBoolean(Operators.AndObject(!Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).value), Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).value, null, false))))
                    {
                        dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).value = dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).value.ToString().ToUpper();
                    }
                    else if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value))
                    {
                        out_of = markOutOf(Conversions.ToString(publicSubsNFunctions.subjname[k]), Conversions.ToString(dgvEnterMarks["Stream", i].Value));
                        if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectGreater(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value, out_of, false), Operators.ConditionalCompareObjectLess(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).value, 0, false))))
                        {
                            msg = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("failure value for ", publicSubsNFunctions.subjects[k]), " for "), dgvEnterMarks["StudentName", i].Value), " Value greater than maximum Or Lower Than Minimum!"));
                            progress.Visible = false;
                            lblSave.Visible = false;
                            return false;
                        }
                    }
                }

                progress.Increment(inc);
            }

            progress.Increment(-100);
            progress.Visible = false;
            lblSave.Visible = false;
            return true;
        }

        private void save_now()
        {
            if (Conversions.ToBoolean(Operators.AndObject(isvalid(), formfourmode())))
            {
                increment = (int)Math.Round(dgvEnterMarks.Rows.Count / 100d);
                progress.Visible = true;
                lblSave.Visible = true;
                lblWait.Visible = true;
                if (Conversions.ToBoolean(check_results()))
                {
                    lblSave.Text = "Updating Data...";
                    up_date();
                }
                else
                {
                    lblSave.Text = "Saving Data...";
                    save();
                }

                progress.Increment(-100);
                progress.Visible = false;
                lblSave.Visible = false;
                lblWait.Visible = false;
            }
            else
            {
                publicSubsNFunctions.failure(msg);
            }
        }

        private void removeColumnDelete()
        {
            if (deleteChk.CheckState == CheckState.Checked)
            {
                dgvEnterMarks.Columns.Remove("Delete");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            removeColumnDelete();
            progress.Visible = Conversions.ToBoolean(DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
            save_now();
        }

        private double total;
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
        private string[] admin_nos;

        private object get_sciences()
        {
            string argq = "SELECT Abbreviation FROM subjects WHERE  Department='Science'";
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

                publicSubsNFunctions.dbreader.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        private object get_humanity()
        {
            string argq = "SELECT Abbreviation FROM subjects WHERE  Department='Humanities'";
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
            string argq = "SELECT Abbreviation FROM subjects WHERE  Department='APPLIED STUDIES'";
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

        private object valid(int row)
        {
            if (Conversions.ToBoolean(formfourmode()))
            {
                for (int k = 0, loopTo = compulsory.Length - 1; k <= loopTo; k++)
                {
                    if (!Information.IsNumeric(dgvEnterMarks[compulsory[k], row].Value))
                    {
                        return false;
                    }
                }

                int sci_count = sciences.Length;
                for (int k = 0, loopTo1 = sciences.Length - 1; k <= loopTo1; k++)
                {
                    if (!Information.IsNumeric(dgvEnterMarks[sciences[k], row].Value))
                    {
                        sci_count -= 1;
                    }
                }

                if (sci_count < 2)
                {
                    return false;
                }

                int hum_count = humanities.Length;
                for (int k = 0, loopTo2 = humanities.Length - 1; k <= loopTo2; k++)
                {
                    if (!Information.IsNumeric(dgvEnterMarks[humanities[k], row].Value))
                    {
                        hum_count -= 1;
                    }
                }

                if (hum_count < 1)
                {
                    return false;
                }

                int app_count = applieds.Length;
                for (int k = 0, loopTo3 = applieds.Length - 1; k <= loopTo3; k++)
                {
                    if (!Information.IsNumeric(dgvEnterMarks[applieds[k], row].Value))
                    {
                        app_count -= 1;
                    }
                }

                if (sci_count == 2 & hum_count == 1 & app_count == 0)
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private double sb_tp, tp;

        private double markOutOf(string subj, string str)
        {
            return publicSubsNFunctions.SubjectOutOf(subj, cboTerm.SelectedItem, cboYear.SelectedItem, cboExamName.SelectedItem, cboClass.SelectedItem, str);
        }

        private object best_of_7(int row)
        {
            if (Conversions.ToBoolean(!valid(row)))
            {
                sb_tp = 0d;
                tp = 0d;
                total = 0d;
                return 0;
            }

            double out_of;
            total = 0d;
            science = true;
            tp = 0d;
            sb_tp = 0d;
            int temp, l;
            // ##############get total of first compulsory subjects#################
            int counter = 0;
            for (int k = 0, loopTo = compulsory.Length - 1; k <= loopTo; k++)
            {
                if (Information.IsNumeric(dgvEnterMarks[compulsory[k], row].Value))
                {
                    out_of = markOutOf(compulsory[k], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                    total = Conversions.ToDouble(total + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[compulsory[k], row].Value, out_of), 100));
                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[compulsory[k], row].Value, out_of), 100)), false, compulsory[k]))));
                    sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[compulsory[k], row].Value, out_of), 100)), true, compulsory[k]))));
                    counter += 1;
                }
            }

            if (counter < 3)
            {
                sb_tp = 0d;
                tp = 0d;
                total = 0d;
                return 0;
            }
            else
            {
                counter = 0;
            }
            // ###########add the 2 best performed science and the second best###################
            for (int k = 0, loopTo1 = sciences.Length - 1; k <= loopTo1; k++)
            {
                if (!Information.IsNumeric(dgvEnterMarks[sciences[k], row].Value))
                {
                    science = false;
                }
                else
                {
                    counter += 1;
                }
            }

            if (counter < 2)
            {
                sb_tp = 0d;
                tp = 0d;
                total = 0d;
                return 0;
            }
            else
            {
                counter = 0;
            }

            var sci = new object[sciences.Length];
            int[] hum = new int[humanities.Length], app = new int[applieds.Length];
            app_names = new string[applieds.Length];
            hum_names = new string[humanities.Length];
            sci_names = new string[sciences.Length];
            for (int k = 0, loopTo2 = sciences.Length - 1; k <= loopTo2; k++)
            {
                sci[k] = dgvEnterMarks[sciences[k], row].Value;
                sci_names[k] = sciences[k];
            }

            string temp_name;
            if (science)
            {
                // ###########Sor them#############
                for (int k = 0, loopTo3 = sciences.Length - 1; k <= loopTo3; k++)
                {
                    var loopTo4 = sciences.Length - 1;
                    for (l = k + 1; l <= loopTo4; l++)
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

                for (int k = 0, loopTo5 = sciences.Length - 1; k <= loopTo5; k++)
                {
                    if (k < sciences.Length - 1)
                    {
                        out_of = markOutOf(sci_names[k], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                        total = Conversions.ToDouble(total + Operators.MultiplyObject(Operators.DivideObject(sci[k], out_of), 100));
                        tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[k], out_of), 100)), false, sci_names[k]))));
                        sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[k], out_of), 100)), true, sci_names[k]))));
                    }
                }
            }
            else
            {
                for (int k = 0, loopTo6 = sciences.Length - 1; k <= loopTo6; k++)
                {
                    if (Information.IsNumeric(dgvEnterMarks[sciences[k], row].Value))
                    {
                        out_of = markOutOf(sci_names[k], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                        total = Conversions.ToDouble(total + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[sciences[k], row].Value, out_of), 100));
                        tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[sciences[k], row].Value, out_of), 100)), false, sci_names[k]))));
                        sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[sciences[k], row].Value, out_of), 100)), true, sci_names[k]))));
                    }
                }
            }
            // ###########get highest and second best performed humanity ##################
            int count = humanities.Length;
            for (int k = 0, loopTo7 = humanities.Length - 1; k <= loopTo7; k++)
                hum_names[k] = humanities[k];
            for (int k = 0, loopTo8 = humanities.Length - 1; k <= loopTo8; k++)
            {
                if (!Information.IsNumeric(dgvEnterMarks[humanities[k], row].Value))
                {
                    count -= 1;
                }
                else
                {
                    counter += 1;
                }
            }

            if (counter < 1)
            {
                sb_tp = 0d;
                tp = 0d;
                total = 0d;
                return 0;
            }
            else
            {
                counter = 0;
            }

            if (count > 1)
            {
                humanity = true;
                l = 0;
                for (int k = 0, loopTo9 = humanities.Length - 1; k <= loopTo9; k++)
                {
                    if (Information.IsNumeric(dgvEnterMarks[humanities[k], row].Value))
                    {
                        hum[k] = Conversions.ToInteger(dgvEnterMarks[humanities[k], row].Value);
                    }
                }

                for (int k = 0, loopTo10 = hum.Length - 1; k <= loopTo10; k++)
                {
                    var loopTo11 = hum.Length - 1;
                    for (l = k + 1; l <= loopTo11; l++)
                    {
                        if (hum[k] < hum[l] | !Information.IsNumeric(hum[k]) & Information.IsNumeric(hum[l]))
                        {
                            temp = hum[k];
                            temp_name = hum_names[k];
                            hum[k] = hum[l];
                            hum_names[k] = hum_names[l];
                            hum[l] = temp;
                            hum_names[l] = temp_name;
                        }
                    }
                }

                out_of = markOutOf(hum_names[0], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                total += hum[0] / out_of * 100d;
                tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[0] / out_of * 100d, false, hum_names[0]))));
                sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[0] / out_of * 100d, true, hum_names[0]))));
            }
            else
            {
                for (int k = 0, loopTo12 = humanities.Length - 1; k <= loopTo12; k++)
                {
                    if (Information.IsNumeric(dgvEnterMarks[humanities[k], row].Value))
                    {
                        out_of = markOutOf(hum_names[k], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                        total = Conversions.ToDouble(total + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[humanities[k], row].Value, out_of), 100));
                        tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[humanities[k], row].Value, out_of), 100)), false, hum_names[k]))));
                        sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks[humanities[k], row].Value, out_of), 100)), true, hum_names[k]))));
                    }
                }
            }
            // ########### get highest performed applied subject ##################
            for (int k = 0, loopTo13 = applieds.Length - 1; k <= loopTo13; k++)
                app_names[k] = applieds[k];
            count = 0;
            l = 0;
            for (int k = 0, loopTo14 = applieds.Length - 1; k <= loopTo14; k++)
            {
                if (Information.IsNumeric(dgvEnterMarks[applieds[k], row].Value))
                {
                    count += 1;
                }
            }

            if (count > 0)
            {
                applied = true;
                for (int k = 0, loopTo15 = applieds.Length - 1; k <= loopTo15; k++)
                {
                    if (Information.IsNumeric(dgvEnterMarks[applieds[k], row].Value))
                    {
                        app[l] = Conversions.ToInteger(dgvEnterMarks[applieds[k], row].Value);
                        app_names[l] = applieds[k];
                        l += 1;
                    }
                }

                if (l > 1)
                {
                    for (int k = 0, loopTo16 = app.Length - 1; k <= loopTo16; k++)
                    {
                        var loopTo17 = app.Length - 1;
                        for (l = k + 1; l <= loopTo17; l++)
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
            }

            if (science & humanity & applied)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], hum[1], false)))
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], app[0], false)))
                    {
                        out_of = markOutOf(sci_names[2], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                        total = Conversions.ToDouble(total + Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100));
                        tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100)), false, sci_names[2]))));
                        sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100)), true, sci_names[2]))));
                    }
                    else
                    {
                        out_of = markOutOf(app_names[0], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                        total += app[0] / out_of * 100d;
                        tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, false, app_names[0]))));
                        sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, true, app_names[0]))));
                    }
                }
                else if (hum[1] > app[0])
                {
                    out_of = markOutOf(hum_names[1], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                    total += hum[1] / out_of * 100d;
                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / out_of * 100d, false, hum_names[1]))));
                    sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / out_of * 100d, true, hum_names[1]))));
                }
                else
                {
                    out_of = markOutOf(app_names[0], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                    total += app[0] / out_of * 100d;
                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, false, app_names[0]))));
                    sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, true, app_names[0]))));
                }
            }
            else if (science & humanity)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], hum[1], false)))
                {
                    out_of = markOutOf(sci_names[2], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                    total = Conversions.ToDouble(total + Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100));
                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100)), false, sci_names[2]))));
                    sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100)), true, sci_names[2]))));
                }
                else
                {
                    out_of = markOutOf(hum_names[1], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                    total += hum[1] / out_of * 100d;
                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / out_of * 100d, false, hum_names[1]))));
                    sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / out_of * 100d, true, hum_names[1]))));
                }
            }
            else if (science & applied)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(sci[2], app[0], false)))
                {
                    out_of = markOutOf(sci_names[2], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                    total = Conversions.ToDouble(total + Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100));
                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100)), false, sci_names[2]))));
                    sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100)), true, sci_names[2]))));
                }
                else
                {
                    out_of = markOutOf(app_names[0], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                    total += app[0] / out_of * 100d;
                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, false, app_names[0]))));
                    sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, true, app_names[0]))));
                }
            }
            else if (applied & humanity)
            {
                if (app[0] > hum[1])
                {
                    out_of = markOutOf(app_names[0], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                    total += app[0] / out_of * 100d;
                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, false, app_names[0]))));
                    sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, true, app_names[0]))));
                }
                else
                {
                    out_of = markOutOf(hum_names[1], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                    total += hum[1] / out_of * 100d;
                    tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / out_of * 100d, false, hum_names[1]))));
                    sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / out_of * 100d, true, hum_names[1]))));
                }
            }
            else if (science)
            {
                out_of = markOutOf(sci_names[2], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                total = Conversions.ToDouble(total + Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100));
                tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100)), false, sci_names[2]))));
                sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(sci[2], out_of), 100)), true, sci_names[2]))));
            }
            else if (humanity)
            {
                out_of = markOutOf(hum_names[1], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                total += hum[1] / out_of * 100d;
                tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / out_of * 100d, false, hum_names[1]))));
                sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)hum[1] / out_of * 100d, true, hum_names[1]))));
            }
            else if (applied)
            {
                out_of = markOutOf(app_names[0], Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                total += app[0] / out_of * 100d;
                tp = Conversions.ToDouble(tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, false, app_names[0]))));
                sb_tp = Conversions.ToDouble(sb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade((double)app[0] / out_of * 100d, true, app_names[0]))));
            }
            else
            {
                sb_tp = 0d;
                tp = 0d;
                total = 0d;
                return 0;
            }

            return total;
        }

        private double mark;
        private double nsb_tp;

        public object compute_points(int row)
        {
            double total = default, out_of;
            nsb_tp = 0d;
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                out_of = markOutOf(Conversions.ToString(publicSubsNFunctions.subjname[k]), Conversions.ToString(dgvEnterMarks["Stream", row].Value));
                if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], row).Value))
                {
                    // todo fix_point() function may result into a big logic error
                    total = Conversions.ToDouble(total + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], row).Value, out_of), 100)), false, Conversions.ToString(publicSubsNFunctions.subjabb[k])))));
                    nsb_tp = Conversions.ToDouble(nsb_tp + publicSubsNFunctions.fix_point(Conversions.ToString(publicSubsNFunctions.get_grade(Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], row).Value, out_of), 100)), true, Conversions.ToString(publicSubsNFunctions.subjabb[k])))));
                }
            }

            return total;
        }

        private int increment;
        private List<string> tableColumns = new List<string>();
        private List<string> availableColumns = new List<string>();

        private void getColumns()
        {
            tableColumns.Clear();
            availableColumns.Clear();
            string argq = "show columns from exam_split_subject_results;";
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    while (publicSubsNFunctions.dbreader.Read())
                        tableColumns.Add(Conversions.ToString(publicSubsNFunctions.dbreader["field"]));
                }
            }
        }

        private void up_date()
        {
            var total = default(int);
            if (dgvEnterMarks.Rows.Count > 100)
            {
                increment = (int)Math.Round(dgvEnterMarks.Rows.Count / 100d);
            }
            else
            {
                increment = (int)Math.Round(100d / dgvEnterMarks.Rows.Count);
            }

            var out_of = default(double);
            string query2 = null;
            getColumns();
            publicSubsNFunctions.start();
            if (CheckBox1.Checked)
            {
                for (int i = 0, loopTo = dgvEnterMarks.Rows.Count - 1; i <= loopTo; i++)
                {
                    if (string.IsNullOrEmpty(Conversions.ToString(dgvEnterMarks["admin_no", i].Value)))
                    {
                        Break();
                    }

                    if (ExistsStudentInRecord(i))
                    {
                        total = 0;
                        for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                        {
                            // todo edited here 8/8/2016
                            try
                            {
                                if (dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value.ToString() != "-" & dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value.ToString() != "X")
                                {
                                    string sResult = dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value.ToString();
                                    if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value) & Conversions.ToDecimal(sResult) > 0m)
                                    {
                                        out_of = markOutOf(Conversions.ToString(publicSubsNFunctions.subjname[k]), Conversions.ToString(dgvEnterMarks["Stream", i].Value));
                                        total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value, out_of), 100));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }

                        int count_ = 0;
                        // save split subjects
                        if (ExistsStudentInRecord2(i))
                        {
                            // update split subjects query
                            publicSubsNFunctions.query = "UPDATE exam_split_subject_results SET StudentName='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["StudentName", i].Value)) + "', ";
                            for (int k = 6, loopTo2 = dgvEnterMarks.Columns.Count - 1; k <= loopTo2; k++)
                            {
                                if (dgvEnterMarks.Columns[k].Visible & is_split_subject(dgvEnterMarks.Columns[k].Name))
                                {
                                    if (count_ > 0)
                                    {
                                        publicSubsNFunctions.query += ", ";
                                    }

                                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + "`" + publicSubsNFunctions.class_form + "_" + dgvEnterMarks.Columns[k].Name + "`='", dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value), "'"));
                                    availableColumns.Add(string.Empty + publicSubsNFunctions.class_form + "_" + dgvEnterMarks.Columns[k].Name + string.Empty);
                                    count_ += 1;
                                }
                            }

                            publicSubsNFunctions.query += " WHERE admno='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["admin_no", i].Value)) + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Year='" + publicSubsNFunctions.yr + "' AND Term='" + publicSubsNFunctions.tm + "'";
                        }
                        else
                        {
                            // insert split subjects query
                            publicSubsNFunctions.query = "INSERT INTO exam_split_subject_results(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,";
                            for (int k = 6, loopTo3 = dgvEnterMarks.Columns.Count - 1; k <= loopTo3; k++)
                            {
                                if (dgvEnterMarks.Columns[dgvEnterMarks.Columns[k].Name].Visible & is_split_subject(dgvEnterMarks.Columns[k].Name))
                                {
                                    publicSubsNFunctions.query += "`" + publicSubsNFunctions.class_form + "_" + dgvEnterMarks.Columns[k].Name + "`";
                                    availableColumns.Add(string.Empty + publicSubsNFunctions.class_form + "_" + dgvEnterMarks.Columns[k].Name + string.Empty);
                                    if (k < dgvEnterMarks.Columns.Count - 4)
                                    {
                                        publicSubsNFunctions.query += ",";
                                    }
                                }
                            }

                            publicSubsNFunctions.query = publicSubsNFunctions.query.Substring(0, publicSubsNFunctions.query.Length - 1);
                            publicSubsNFunctions.query = publicSubsNFunctions.query + ") VALUES";
                            publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(NULL, '", dgvEnterMarks["admin_no", i].Value), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["StudentName", i].Value))), "', '"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "', '"), publicSubsNFunctions.tm), "', '"), publicSubsNFunctions.yr), "','"));
                            for (int k = 6, loopTo4 = dgvEnterMarks.Columns.Count - 1; k <= loopTo4; k++)
                            {
                                if (dgvEnterMarks.Columns[dgvEnterMarks.Columns[k].Name].Visible & is_split_subject(dgvEnterMarks.Columns[k].Name))
                                {
                                    if (Information.IsNumeric(dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value))
                                    {
                                        if (dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value.ToString().Length > 1)
                                        {
                                            publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query, dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value), "', '"));
                                        }
                                        else
                                        {
                                            publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + "0", dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value), "', '"));
                                        }
                                    }
                                    else
                                    {
                                        publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query, dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value), "', '"));
                                    }
                                }
                            }

                            publicSubsNFunctions.query = publicSubsNFunctions.query.Substring(0, publicSubsNFunctions.query.Length - 2) + ")";
                            publicSubsNFunctions.query = publicSubsNFunctions.query.Replace(",)", ")");
                        }
                        // update exam_results query
                        query2 = "UPDATE " + publicSubsNFunctions.table + " SET StudentName='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["StudentName", i].Value)) + "',";
                        for (int k = 0, loopTo5 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo5; k++)
                        {
                            if (dgvEnterMarks.Columns[publicSubsNFunctions.subjname[k].ToString()].Visible)
                            {
                                if (has_constituents(Conversions.ToString(publicSubsNFunctions.subjects[k])))
                                {
                                    query2 = Conversions.ToString(query2 + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("`", publicSubsNFunctions.subjname[k]), "`='"), subject_total(Conversions.ToString(publicSubsNFunctions.subjects[k]), i, out_of)), "', "));
                                }
                                else
                                {
                                    query2 = Conversions.ToString(query2 + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("`", publicSubsNFunctions.subjname[k]), "`='"), dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value), "', "));
                                }
                            }
                        }

                        query2 = Conversions.ToString(query2 + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Total='" + total + "', B7_Total='", best_of_7(i)), "', B7SB_TP='"), sb_tp), "', B7NSB_TP='"), tp), "', NSB_TP='"), compute_points(i)), "', SB_TP='"), nsb_tp), "' WHERE admno='"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["admin_no", i].Value))), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND Year='"), publicSubsNFunctions.yr), "' AND Term='"), publicSubsNFunctions.tm), "'"));
                        progress.Increment(increment);
                        try
                        {
                            publicSubsNFunctions.dbreader.Close();
                        }
                        catch (Exception ex)
                        {
                        }

                        publicSubsNFunctions.query = publicSubsNFunctions.query.Replace(",  WHERE", "  WHERE");
                        confirmRows();
                        // Dim deleteQuery As String = "delete from exam_results where admno = '" & dgvEnterMarks.Item("admin_no", i).Value & "' and examination = '" & cboExamName.SelectedItem.ToString & "' and term = '" & cboTerm.SelectedItem.ToString & "' and year = '" & cboYear.SelectedItem.ToString & "';"

                        if (publicSubsNFunctions.qwrite(publicSubsNFunctions.query))
                        {
                            if (publicSubsNFunctions.qwrite(query2))
                            {
                            }
                            else
                            {
                                publicSubsNFunctions.rollback();
                                publicSubsNFunctions.failure("Could Not Save Records");
                                progress.Visible = false;
                                return;
                            }
                        }
                        else
                        {
                            publicSubsNFunctions.rollback();
                            publicSubsNFunctions.failure("Could Not Save Records");
                            progress.Visible = false;
                            return;
                        }
                    }
                    else
                    {
                        // save split subjects
                        var count_ = default(int);
                        if (ExistsStudentInRecord2(i))
                        {
                            // update split subjects query
                            publicSubsNFunctions.query = "UPDATE exam_split_subject_results SET StudentName='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["StudentName", i].Value)) + "', ";
                            for (int k = 6, loopTo6 = dgvEnterMarks.Columns.Count - 1; k <= loopTo6; k++)
                            {
                                if (dgvEnterMarks.Columns[k].Visible & is_split_subject(dgvEnterMarks.Columns[k].Name))
                                {
                                    if (count_ > 0)
                                    {
                                        publicSubsNFunctions.query += ", ";
                                    }

                                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + "`" + publicSubsNFunctions.class_form + "_" + dgvEnterMarks.Columns[k].Name + "`='", dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value), "'"));
                                    availableColumns.Add(string.Empty + publicSubsNFunctions.class_form + "_" + dgvEnterMarks.Columns[k].Name + string.Empty);
                                    count_ += 1;
                                }
                            }

                            publicSubsNFunctions.query += " WHERE admno='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["admin_no", i].Value)) + "' AND Examination='" + publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name) + "' AND Year='" + publicSubsNFunctions.yr + "' AND Term='" + publicSubsNFunctions.tm + "'";
                        }
                        else
                        {
                            // insert split subjects query
                            publicSubsNFunctions.query = "INSERT INTO exam_split_subject_results(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,";
                            for (int k = 6, loopTo7 = dgvEnterMarks.Columns.Count - 1; k <= loopTo7; k++)
                            {
                                if (dgvEnterMarks.Columns[dgvEnterMarks.Columns[k].Name].Visible & is_split_subject(dgvEnterMarks.Columns[k].Name))
                                {
                                    publicSubsNFunctions.query += "`" + publicSubsNFunctions.class_form + "_" + dgvEnterMarks.Columns[k].Name + "`";
                                    availableColumns.Add(string.Empty + publicSubsNFunctions.class_form + "_" + dgvEnterMarks.Columns[k].Name + string.Empty);
                                    if (k < dgvEnterMarks.Columns.Count - 4)
                                    {
                                        publicSubsNFunctions.query += ",";
                                    }
                                }
                            }

                            publicSubsNFunctions.query = publicSubsNFunctions.query + ") VALUES";
                            publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(NULL, '", dgvEnterMarks["admin_no", i].Value), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["StudentName", i].Value))), "', '"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "', '"), publicSubsNFunctions.tm), "', '"), publicSubsNFunctions.yr), "','"));
                            for (int k = 6, loopTo8 = dgvEnterMarks.Columns.Count - 1; k <= loopTo8; k++)
                            {
                                if (dgvEnterMarks.Columns[dgvEnterMarks.Columns[k].Name].Visible & is_split_subject(dgvEnterMarks.Columns[k].Name))
                                {
                                    if (Information.IsNumeric(dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value))
                                    {
                                        if (dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value.ToString().Length > 1)
                                        {
                                            publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query, dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value), "', '"));
                                        }
                                        else
                                        {
                                            publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + "0", dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value), "', '"));
                                        }
                                    }
                                    else
                                    {
                                        publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query, dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value), "', '"));
                                    }
                                }
                            }
                        }

                        // query = query.Substring(0, query.Length - 3) & ")"

                        query2 = "INSERT INTO exam_results(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,";
                        for (int k = 0, loopTo9 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo9; k++)
                            query2 = Conversions.ToString(query2 + Operators.ConcatenateObject(Operators.ConcatenateObject("`", publicSubsNFunctions.subjname[k]), "`, "));
                        query2 = query2 + " `Total`, `B7_Total`, `B7SB_TP`, `B7NSB_TP`, `SB_TP`, `NSB_TP`, `CLASS`, `STREAM`) VALUES";
                        // For k As Integer = 0 To dgvEnterMarks.Rows.Count - 1
                        query2 = Conversions.ToString(query2 + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(NULL, '", dgvEnterMarks["admin_no", i].Value), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["StudentName", i].Value))), "', '"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "', '"), publicSubsNFunctions.tm), "', '"), publicSubsNFunctions.yr), "','"));
                        for (int l = 0, loopTo10 = publicSubsNFunctions.subjabb.Length - 1; l <= loopTo10; l++)
                        {
                            out_of = markOutOf(Conversions.ToString(publicSubsNFunctions.subjname[l]), Conversions.ToString(dgvEnterMarks["Stream", i].Value));
                            if (has_constituents(Conversions.ToString(publicSubsNFunctions.subjects[l])))
                            {
                                query2 += subject_total(Conversions.ToString(publicSubsNFunctions.subjects[l]), i, out_of) + "','";
                            }
                            else
                            {
                                query2 = Conversions.ToString(query2 + Operators.ConcatenateObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[l], i).Value, "','"));
                            }
                        }

                        query2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(query2 + total + "','", best_of_7(i)), "','"), sb_tp), "','"), tp), "','"), compute_points(i)), "','"), nsb_tp), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)))), "', '"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["Stream", i].Value))), "')"));
                        if (get_class(dgvEnterMarks["admin_no", i].Value).ToString() == "False")
                        {
                            publicSubsNFunctions.failure(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Could Not Determine The Stream For Student With Admission Number: ", dgvEnterMarks["admin_no", i].Value), ". Therefore The Saving Has Been Terminated. Exiting..")));
                            progress.Visible = false;
                            progress.Increment(-100);
                            return;
                        }

                        total = 0;
                        progress.Increment(increment);
                        if (!publicSubsNFunctions.qwrite(query2))
                        {
                            publicSubsNFunctions.rollback();
                            publicSubsNFunctions.failure("Could Not Save Records!  You may have checked the 'Show Subjects Contribution' option when you do not have split subject entries");
                            progress.Visible = false;
                            return;
                        }
                        else if (splits.Length > 0)
                        {
                            confirmRows();
                            publicSubsNFunctions.query = publicSubsNFunctions.query.Replace(", ,", ",");
                            if (!publicSubsNFunctions.qwrite(publicSubsNFunctions.query))
                            {
                                publicSubsNFunctions.rollback();
                                publicSubsNFunctions.failure("Could Not Save Records");
                                progress.Visible = false;
                                return;
                            }
                        }

                        total = 0;
                    }
                }
            }
            else
            {
                for (int i = 0, loopTo11 = dgvEnterMarks.Rows.Count - 1; i <= loopTo11; i++)
                {
                    if (ExistsStudentInRecord(i))
                    {
                        total = 0;
                        for (int k = 0, loopTo12 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo12; k++)
                        {
                            if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value))
                            {
                                out_of = markOutOf(Conversions.ToString(publicSubsNFunctions.subjname[k]), Conversions.ToString(dgvEnterMarks["Stream", i].Value));
                                total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value, out_of), 100));
                            }
                        }

                        publicSubsNFunctions.query = "UPDATE " + publicSubsNFunctions.table + " SET StudentName='" + publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["StudentName", i].Value)) + "',";
                        for (int k = 0, loopTo13 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo13; k++)
                        {
                            if (Conversions.ToBoolean(dgvEnterMarks.Columns(publicSubsNFunctions.subjname[k]).visible))
                            {
                                if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).value))
                                {
                                    if (Conversions.ToInteger(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).value) > 9)
                                    {
                                        publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + "`", publicSubsNFunctions.subjabb[k]), "`='"), Convert.ToDouble(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value)), "', "));
                                    }
                                    else
                                    {
                                        publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + "`", publicSubsNFunctions.subjabb[k]), "`='0"), Conversions.ToInteger(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value)), "', "));
                                    }
                                }
                                else
                                {
                                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + "`", publicSubsNFunctions.subjabb[k]), "`='"), dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value), "', "));
                                }
                            }
                        }

                        publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + "Total='" + total + "', B7_Total='", best_of_7(i)), "', B7SB_TP='"), sb_tp), "', B7NSB_TP='"), tp), "', NSB_TP='"), compute_points(i)), "', SB_TP='"), nsb_tp), "' WHERE admno='"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["admin_no", i].Value))), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND Year='"), publicSubsNFunctions.yr), "' AND Term='"), publicSubsNFunctions.tm), "'"));
                        progress.Increment(increment);
                        confirmRows();
                        if (!publicSubsNFunctions.qwrite(publicSubsNFunctions.query))
                        {
                            publicSubsNFunctions.rollback();
                            publicSubsNFunctions.failure("Could Not Save Records");
                            progress.Visible = false;
                            return;
                        }
                    }
                    else
                    {
                        publicSubsNFunctions.query = "INSERT INTO " + publicSubsNFunctions.table + "(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,";
                        for (int k = 0, loopTo14 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo14; k++)
                        {
                            if (Conversions.ToBoolean(dgvEnterMarks.Columns(publicSubsNFunctions.subjname[k]).Visible))
                            {
                                if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value))
                                {
                                    out_of = markOutOf(Conversions.ToString(publicSubsNFunctions.subjname[k]), Conversions.ToString(dgvEnterMarks["Stream", i].Value));
                                    total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value, out_of), 100));
                                }

                                publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject("`", publicSubsNFunctions.subjname[k]), "`,"));
                            }
                        }

                        publicSubsNFunctions.query = publicSubsNFunctions.query + " `Total`, `B7_Total`, `B7SB_TP`, `B7NSB_TP`, `SB_TP`, `NSB_TP`, `CLASS`, `STREAM`) VALUES";
                        publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(NULL, '", dgvEnterMarks["admin_no", i].Value), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["StudentName", i].Value))), "', '"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "', '"), publicSubsNFunctions.tm), "', '"), publicSubsNFunctions.yr), "','"));
                        for (int k = 0, loopTo15 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo15; k++)
                        {
                            if (Conversions.ToBoolean(dgvEnterMarks.Columns(publicSubsNFunctions.subjname[k]).Visible))
                            {
                                if (Information.IsNumeric(dgvEnterMarks[publicSubsNFunctions.subjname[k].ToString(), i].Value))
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(dgvEnterMarks[publicSubsNFunctions.subjname[k].ToString(), i].Value, 9, false)))
                                    {
                                        publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query, dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value), "', '"));
                                    }
                                    else
                                    {
                                        publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + "0", dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value), "', '"));
                                    }
                                }
                                else
                                {
                                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query, dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value), "', '"));
                                }
                            }
                        }

                        if (get_class(dgvEnterMarks["admin_no", i].Value).ToString() == "False")
                        {
                            publicSubsNFunctions.failure(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Could Not Determine The Stream For Student With Admission Number: ", dgvEnterMarks["admin_no", i].Value), ". Therefore The Saving Has Been Terminated. Exiting..")));
                            progress.Visible = false;
                            progress.Increment(-100);
                            return;
                        }

                        publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + total + "','", best_of_7(i)), "','"), sb_tp), "','"), tp), "','"), compute_points(i)), "','"), nsb_tp), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)))), "', '"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["Stream", i].Value))), "')"));
                        confirmRows();
                        if (!publicSubsNFunctions.qwrite(publicSubsNFunctions.query))
                        {
                            publicSubsNFunctions.rollback();
                            publicSubsNFunctions.failure("Could Not Save Records");
                            progress.Visible = false;
                            return;
                        }

                        total = 0;
                    }
                }
            }

            results_entered = true;
            publicSubsNFunctions.commit();
            publicSubsNFunctions.success("Examination Results Successfully Saved!");
        }

        private void confirmRows()
        {
            foreach (var item in availableColumns)
            {
                if (!tableColumns.Contains(item))
                {
                    if (publicSubsNFunctions.qwrite("ALTER TABLE `exam_split_subject_results` ADD COLUMN `" + item + "` VARCHAR(255) NOT NULL DEFAULT '' AFTER `" + tableColumns[tableColumns.Count - 1] + "`;"))
                    {
                        tableColumns.Add(item);
                    }
                }
            }
        }

        private bool ExistsStudentInRecord(int row)
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT id FROM exam_results WHERE admno='", dgvEnterMarks["admin_no", row].Value), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND year='"), publicSubsNFunctions.yr), "' AND Term='"), publicSubsNFunctions.tm), "'"));
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ExistsStudentInRecord2(int row)
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT id FROM exam_split_subject_results WHERE admno='", dgvEnterMarks["admin_no", row].Value), "' AND Examination='"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "' AND year='"), publicSubsNFunctions.yr), "' AND Term='"), publicSubsNFunctions.tm), "'"));
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private object get_class(object adm)
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT stream FROM students WHERE admin_no='", adm), "'"));
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                return publicSubsNFunctions.dbreader["stream"];
            }
            else
            {
                publicSubsNFunctions.failure(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Could Not Determine The Correct Stream For Student Adm. No. ", adm), ". You Must Fix This Before You Continue...")));
                return false;
            }
        }

        private void save()
        {
            string query2 = null;
            int total = 0;
            int i;
            double out_of;
            getColumns();
            if (!CheckBox1.Checked)
            {
                publicSubsNFunctions.query = "INSERT INTO " + publicSubsNFunctions.table + "(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,";
                var loopTo = dgvEnterMarks.Rows.Count - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    if (string.IsNullOrEmpty(Conversions.ToString(dgvEnterMarks["admin_no", i].Value)))
                    {
                        continue;
                    }

                    if (i == 0)
                    {
                        for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                        {
                            out_of = markOutOf(Conversions.ToString(publicSubsNFunctions.subjname[k]), Conversions.ToString(dgvEnterMarks["Stream", i].Value));
                            if (Conversions.ToBoolean(dgvEnterMarks.Columns(publicSubsNFunctions.subjname[k]).Visible))
                            {
                                if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value))
                                {
                                    total = Conversions.ToInteger(total + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value, out_of), 100));
                                }

                                publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject("`", publicSubsNFunctions.subjname[k]), "`,"));
                            }
                        }

                        publicSubsNFunctions.query = publicSubsNFunctions.query + " `Total`, `B7_Total`, `B7SB_TP`, `B7NSB_TP`, `SB_TP`, `NSB_TP`, `CLASS`, `STREAM`) VALUES";
                    }

                    publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(NULL, '", dgvEnterMarks["admin_no", i].Value), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["StudentName", i].Value))), "', '"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "', '"), publicSubsNFunctions.tm), "', '"), publicSubsNFunctions.yr), "','"));
                    for (int k = 0, loopTo2 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo2; k++)
                    {
                        if (Conversions.ToBoolean(dgvEnterMarks.Columns(publicSubsNFunctions.subjname[k]).Visible))
                        {
                            if (Information.IsNumeric(dgvEnterMarks[publicSubsNFunctions.subjname[k].ToString(), i].Value))
                            {
                                if (dgvEnterMarks[publicSubsNFunctions.subjname[k].ToString(), i].Value.ToString().Length > 1)
                                {
                                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query, dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value), "', '"));
                                }
                                else
                                {
                                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + "0", dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value), "', '"));
                                }
                            }
                            else
                            {
                                publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query, dgvEnterMarks.Item(publicSubsNFunctions.subjname[k], i).Value), "', '"));
                            }
                        }
                    }

                    if (get_class(dgvEnterMarks["admin_no", i].Value).ToString() == "False")
                    {
                        publicSubsNFunctions.failure(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Could Not Determine The Stream For Student With Admission Number: ", dgvEnterMarks["admin_no", i].Value), ". Therefore The Saving Has Been Terminated. Exiting..")));
                        progress.Visible = false;
                        progress.Increment(-100);
                        return;
                    }

                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + total + "','", best_of_7(i)), "','"), sb_tp), "','"), tp), "','"), compute_points(i)), "','"), nsb_tp), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)))), "', '"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["Stream", i].Value))), "')"));
                    total = 0;
                    if (i < dgvEnterMarks.Rows.Count - 1)
                    {
                        publicSubsNFunctions.query = publicSubsNFunctions.query + ", ";
                        // If i = dgvEnterMarks.Rows.Count - 2 Then
                        // query = query & "; "
                        // Else
                        // query = query & ", "
                        // End If


                    }

                    progress.Increment(increment);
                }
            }
            else
            {
                publicSubsNFunctions.query = "INSERT INTO exam_split_subject_results(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,";
                query2 = "INSERT INTO exam_results(`id`, `admno`, `StudentName`, `Examination`, `Term`, `Year`,";
                for (int k = 0, loopTo3 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo3; k++)
                    query2 = Conversions.ToString(query2 + Operators.ConcatenateObject(Operators.ConcatenateObject("`", publicSubsNFunctions.subjname[k]), "`, "));
                query2 = query2 + " `Total`, `B7_Total`, `B7SB_TP`, `B7NSB_TP`, `SB_TP`, `NSB_TP`, `CLASS`, `STREAM`) VALUES";
                for (int k = 0, loopTo4 = dgvEnterMarks.Rows.Count - 1; k <= loopTo4; k++)
                {
                    query2 = Conversions.ToString(query2 + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(NULL, '", dgvEnterMarks["admin_no", k].Value), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["StudentName", k].Value))), "', '"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "', '"), publicSubsNFunctions.tm), "', '"), publicSubsNFunctions.yr), "','"));
                    for (int l = 0, loopTo5 = publicSubsNFunctions.subjabb.Length - 1; l <= loopTo5; l++)
                    {
                        out_of = markOutOf(Conversions.ToString(publicSubsNFunctions.subjname[l]), Conversions.ToString(dgvEnterMarks["Stream", k].Value));
                        if (has_constituents(Conversions.ToString(publicSubsNFunctions.subjects[l])))
                        {
                            query2 += subject_total(Conversions.ToString(publicSubsNFunctions.subjects[l]), k, out_of) + "','";
                        }
                        else
                        {
                            query2 = Conversions.ToString(query2 + Operators.ConcatenateObject(dgvEnterMarks.Item(publicSubsNFunctions.subjname[l], k).Value, "','"));
                        }
                    }

                    query2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(query2 + total + "','", best_of_7(k)), "','"), sb_tp), "','"), tp), "','"), compute_points(k)), "','"), nsb_tp), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)))), "', '"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["Stream", k].Value))), "')"));
                    if (k < dgvEnterMarks.Rows.Count - 1)
                    {
                        query2 += ",";
                    }
                }

                var loopTo6 = dgvEnterMarks.Rows.Count - 1;
                for (i = 0; i <= loopTo6; i++)
                {
                    if (i == 0)
                    {
                        for (int k = 6, loopTo7 = dgvEnterMarks.Columns.Count - 1; k <= loopTo7; k++)
                        {
                            if (dgvEnterMarks.Columns[dgvEnterMarks.Columns[k].Name].Visible & is_split_subject(dgvEnterMarks.Columns[k].Name))
                            {
                                publicSubsNFunctions.query += "`" + publicSubsNFunctions.class_form + "_" + dgvEnterMarks.Columns[k].Name + "`";
                                availableColumns.Add(string.Empty + publicSubsNFunctions.class_form + "_" + dgvEnterMarks.Columns[k].Name + string.Empty);
                                if (k <= dgvEnterMarks.Columns.Count - 5)
                                {
                                    publicSubsNFunctions.query += ",";
                                }
                            }
                        }

                        if (publicSubsNFunctions.query.Substring(publicSubsNFunctions.query.Length - 1) == ",")
                        {
                            publicSubsNFunctions.query = publicSubsNFunctions.query.Substring(0, publicSubsNFunctions.query.Length - 1);
                        }

                        publicSubsNFunctions.query = publicSubsNFunctions.query + ") VALUES";
                    }

                    publicSubsNFunctions.query = Conversions.ToString(publicSubsNFunctions.query + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(NULL, '", dgvEnterMarks["admin_no", i].Value), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(dgvEnterMarks["StudentName", i].Value))), "', '"), publicSubsNFunctions.escape_string(publicSubsNFunctions.exam_name)), "', '"), publicSubsNFunctions.tm), "', '"), publicSubsNFunctions.yr), "','"));
                    for (int k = 6, loopTo8 = dgvEnterMarks.Columns.Count - 1; k <= loopTo8; k++)
                    {
                        if (dgvEnterMarks.Columns[dgvEnterMarks.Columns[k].Name].Visible & is_split_subject(dgvEnterMarks.Columns[k].Name))
                        {
                            if (Information.IsNumeric(dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value))
                            {
                                if (dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value.ToString().Length > 1)
                                {
                                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query, dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value), "', '"));
                                }
                                else
                                {
                                    publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query + "0", dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value), "', '"));
                                }
                            }
                            else
                            {
                                publicSubsNFunctions.query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.query, dgvEnterMarks[dgvEnterMarks.Columns[k].Name, i].Value), "', '"));
                            }
                        }
                    }

                    if (get_class(dgvEnterMarks["admin_no", i].Value).ToString() == "False")
                    {
                        publicSubsNFunctions.failure(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Could Not Determine The Stream For Student With Admission Number: ", dgvEnterMarks["admin_no", i].Value), ". Therefore The Saving Has Been Terminated. Exiting..")));
                        progress.Visible = false;
                        progress.Increment(-100);
                        return;
                    }

                    publicSubsNFunctions.query = publicSubsNFunctions.query.Substring(0, publicSubsNFunctions.query.Length - 3) + ")";
                    total = 0;
                    if (i < dgvEnterMarks.Rows.Count - 1)
                    {
                        publicSubsNFunctions.query = publicSubsNFunctions.query + ", ";
                    }

                    progress.Increment(increment);
                }
            }

            publicSubsNFunctions.start();
            if (CheckBox1.Checked)
            {
                confirmRows();
                if (publicSubsNFunctions.qwrite(publicSubsNFunctions.query))
                {
                    if (publicSubsNFunctions.qwrite(query2))
                    {
                    }
                    else
                    {
                        publicSubsNFunctions.rollback();
                        publicSubsNFunctions.failure("Examination Results Saving Failed! You may have checked the 'Show Subjects Contribution' option when you do not have split subject entries");
                    }

                    results_entered = true;
                    publicSubsNFunctions.commit();
                    publicSubsNFunctions.success("Examination Results Successfully Saved!");
                }
                else
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Examination Results Saving Failed! You may have checked the 'Show Subjects Contribution' option when you do not have split subject entries");
                }
            }
            else
            {
                confirmRows();
                string test = publicSubsNFunctions.parseQuery(publicSubsNFunctions.query);
                if (publicSubsNFunctions.qwrite(publicSubsNFunctions.parseQuery(publicSubsNFunctions.query)))
                {
                    results_entered = true;
                    publicSubsNFunctions.commit();
                    publicSubsNFunctions.success("Examination Results Successfully Saved!");
                }
                else
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Examination Results Saving Failed!");
                }
            }
        }

        private double subject_total(string name, int row, double out_of)
        {
            double subject_totalRet = default;
            subject_totalRet = 0d;
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM split_subjects WHERE subject='" + publicSubsNFunctions.escape_string(name) + "' AND class='", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "'"));
            publicSubsNFunctions.qread(ref argq);
            while (publicSubsNFunctions.dbreader.Read())
            {
                if (Information.IsNumeric(dgvEnterMarks.Item(publicSubsNFunctions.dbreader["abbreviation"], row).value))
                {
                    subject_totalRet = Conversions.ToDouble(subject_totalRet + Operators.MultiplyObject(Operators.DivideObject(dgvEnterMarks.Item(publicSubsNFunctions.dbreader["abbreviation"], row).value, publicSubsNFunctions.dbreader["contribution"]), publicSubsNFunctions.dbreader["weighted"]));
                }
            }

            return (int)Math.Round(subject_totalRet);
        }

        private bool has_constituents(string name)
        {
            string argq = "SELECT abbreviation FROM split_subjects WHERE subject='" + publicSubsNFunctions.escape_string(name) + "'";
            publicSubsNFunctions.qread(ref argq, 1);
            return publicSubsNFunctions.dbreader1.HasRows;
        }

        private bool is_split_subject(string name)
        {
            string argq = "SELECT abbreviation FROM split_subjects WHERE abbreviation='" + name + "'";
            publicSubsNFunctions.qread(ref argq, 1);
            publicSubsNFunctions.dbreader1.Read();
            if (publicSubsNFunctions.dbreader1.RecordsAffected == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            int line = 30;
            int topline;
            float CenterPage;
            int left_margin = 50;
            int count = 0;
            if (start_from == 0)
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

                CenterPage = Convert.ToSingle(e.PageBounds.Width / 2d - e.Graphics.MeasureString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form), " "), publicSubsNFunctions.stream), " "), publicSubsNFunctions.exam_name), " MARKS FOR TERM "), publicSubsNFunctions.tm), " "), publicSubsNFunctions.yr)), publicSubsNFunctions.other_font).Width / 2f);
                e.Graphics.DrawString(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form), " "), publicSubsNFunctions.stream), " "), publicSubsNFunctions.exam_name), " MARKS FOR TERM "), publicSubsNFunctions.tm), " "), publicSubsNFunctions.yr)), publicSubsNFunctions.other_font, Brushes.Black, CenterPage, line);
                line += publicSubsNFunctions.other_font.Height + 5;
            }

            topline = line;
            for (int col = 0, loopTo1 = dgvEnterMarks.Columns.Count - 1; col <= loopTo1; col++)
            {
                if (dgvEnterMarks.Columns[col].Visible)
                {
                    try
                    {
                        e.Graphics.DrawString(dgvEnterMarks.Columns[col].HeaderText, publicSubsNFunctions.other_font, Brushes.Black, left_margin, line - 1);
                    }
                    catch (Exception ex)
                    {
                        e.Graphics.DrawString(dgvEnterMarks.Columns[col].HeaderText, publicSubsNFunctions.other_font, Brushes.Black, left_margin, line - 1);
                    }

                    count += 1;
                    if (count == 2)
                    {
                        left_margin += 200;
                    }
                    else
                    {
                        left_margin += 50;
                    }
                }
            }

            int right_margin = left_margin;
            e.Graphics.DrawLine(Pens.Black, 42, line, right_margin, line);
            line += 15;
            for (int row = start_from, loopTo2 = dgvEnterMarks.Rows.Count - 1; row <= loopTo2; row++)
            {
                line += 1;
                if (line >= 806 & row < dgvEnterMarks.Rows.Count - 1)
                {
                    left_margin = 10;
                    for (int k = 0, loopTo3 = dgvEnterMarks.Columns.Count - 6; k <= loopTo3; k++)
                    {
                        if (k == 2)
                        {
                            left_margin += 200;
                        }
                        else
                        {
                            left_margin += 50;
                        }

                        e.Graphics.DrawLine(Pens.Black, left_margin - 15, line, left_margin - 15, topline);
                    }

                    left_margin = 50;
                    e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
                    e.HasMorePages = true;
                    start_from = row;
                    return;
                }

                left_margin = 50;
                count = 0;
                for (int col = 0, loopTo4 = dgvEnterMarks.Columns.Count - 1; col <= loopTo4; col++)
                {
                    if (dgvEnterMarks.Columns[col].Visible)
                    {
                        if (dgvEnterMarks.Columns[col].Name == "IndexNo")
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(dgvEnterMarks["IndexNo", row].Value, null, false)))
                            {
                                if (dgvEnterMarks["IndexNo", row].Value.ToString().Length > 3)
                                {
                                    e.Graphics.DrawString(dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value.ToString().Substring(dgvEnterMarks["IndexNo", row].Value.ToString().Length - 3, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
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
                        else
                        {
                            left_margin += 50;
                        }
                    }
                }

                line += 1;
                e.Graphics.DrawLine(Pens.Black, 45, line, left_margin, line);
                line += publicSubsNFunctions.smallfont.Height + 5;
            }

            left_margin = 10;
            for (int k = 0, loopTo5 = dgvEnterMarks.Columns.Count - 6; k <= loopTo5; k++)
            {
                if (k == 2)
                {
                    left_margin += 200;
                }
                else
                {
                    left_margin += 50;
                }

                e.Graphics.DrawLine(Pens.Black, left_margin - 15, line, left_margin - 15, topline);
            }

            left_margin = 50;
            e.Graphics.DrawLine(Pens.Black, left_margin, line, right_margin, line);
            start_from = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            removeColumnDelete();
            // Dim Print_Preview As New PrintPreviewDialog
            // Dim print_dialog As New PrintDialog
            // Dim print_document As System.Drawing.Printing.PrintDocument = print_student_report2()
            // print_document.DefaultPageSettings.Landscape = CheckBox2.Checked
            // Print_Preview.Document = print_document
            // Print_Preview.ShowDialog()

            var argdgv = dgvEnterMarks;
            addNumberingToGrid(ref argdgv);
            dgvEnterMarks = argdgv;
            string title = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form), " "), publicSubsNFunctions.stream), " "), publicSubsNFunctions.exam_name), " MARKS FOR TERM "), publicSubsNFunctions.tm), " "), publicSubsNFunctions.yr));
            var argmyView = dgvEnterMarks;
            reporting.generateFromDataTable(title, "From Grid", string.Empty, null, ref argmyView);
            dgvEnterMarks = argmyView;
            dgvEnterMarks.Columns.Remove("count");
        }

        private void addNumberingToGrid(ref DataGridView dgv)
        {
            var AddColumn = new DataGridViewTextBoxColumn();
            AddColumn.HeaderText = "Count";
            AddColumn.Name = "Count";
            AddColumn.Width = 80;
            AddColumn.Visible = true;
            dgv.Columns.Insert(0, AddColumn);
            short counter = 1;
            for (short i = 0, loopTo = (short)(dgv.Rows.Count - 1); i <= loopTo; i++)
            {
                dgv.Rows[i].Cells[0].Value = counter.ToString();
                counter = (short)(counter + 1);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // exportToExcel(dgvEnterMarks)
            removeColumnDelete();
            if (SaveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string filename = SaveFileDialog1.FileName;
            if (string.IsNullOrEmpty(filename))
            {
                filename = Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\export_data";
            }

            filename += ".csv";
            FileSystem.FileOpen(1, filename, OpenMode.Output);
            string line = null;
            for (int k = 0, loopTo = dgvEnterMarks.Columns.Count - 1; k <= loopTo; k++)
            {
                if (dgvEnterMarks.Columns[k].Visible == true)
                {
                    line += dgvEnterMarks.Columns[k].HeaderText;
                    if (k < dgvEnterMarks.Columns.Count - 1)
                    {
                        line += ",";
                    }
                }
            }

            line += Constants.vbNewLine;
            for (int row = 0, loopTo1 = dgvEnterMarks.Rows.Count - 1; row <= loopTo1; row++)
            {
                for (int col = 0, loopTo2 = dgvEnterMarks.Columns.Count - 1; col <= loopTo2; col++)
                {
                    if (dgvEnterMarks.Columns[col].Visible == true)
                    {
                        line = Conversions.ToString(line + dgvEnterMarks[dgvEnterMarks.Columns[col].Name, row].Value);
                        if (col < dgvEnterMarks.Columns.Count - 1)
                        {
                            line += ",";
                        }
                    }
                }

                line += Constants.vbNewLine;
            }

            FileSystem.Print(1, line);
            FileSystem.FileClose(1);
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
            // todo commented the below code
            // oExcelFile.ActiveWorkbook.SaveAs(Filename:=SaveFileDialog1.FileName, FileFormat:=Excel.XlFileFormat.xlExcel5, CreateBackup:=False)
            oExcelFile.ActiveWorkbook.Close(SaveChanges: false);
            oExcelFile.DisplayAlerts = true;
            oExcelFile.Quit();
            // File.Delete(SaveFileDialog1.FileName & ".csv")
            publicSubsNFunctions.success("Data Successfully Exported To " + SaveFileDialog1.FileName + ".xls");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.ConditionalCompareObjectEqual(cboYear.SelectedItem, null, false), Operators.ConditionalCompareObjectEqual(cboTerm.SelectedItem, null, false)), Operators.ConditionalCompareObjectEqual(cboExamName.SelectedItem, null, false)), Operators.ConditionalCompareObjectEqual(cboClass.SelectedItem, null, false)), Operators.ConditionalCompareObjectEqual(cboStream.SelectedItem, null, false))))
            {
                publicSubsNFunctions.failure("Please Select An Examination And / Or Class / Stream To Enter Out Of Mark");
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboSubject.SelectedItem, null, false)))
            {
                publicSubsNFunctions.failure("Please Select Subject To Load/Enter Marks For!");
                return;
            }

            publicSubsNFunctions.class_stream = Conversions.ToString(cboStream.SelectedItem);
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboStream.SelectedItem, "All", false)))
            {
                publicSubsNFunctions.title = "EXAMINATION MARKS ENTRY FOR " + cboClass.SelectedItem.ToString().ToUpper();
                publicSubsNFunctions.stream_mode = false;
            }
            else
            {
                publicSubsNFunctions.title = Conversions.ToString(Operators.ConcatenateObject("EXAMINATION MARKS ENTRY FOR " + cboClass.SelectedItem.ToString().ToUpper() + " ", cboStream.SelectedItem));
                publicSubsNFunctions.stream_mode = true;
            }

            publicSubsNFunctions.subj = Conversions.ToString(cboSubject.SelectedItem);
            publicSubsNFunctions.search_teachers = true;
            publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
            publicSubsNFunctions.stream = Conversions.ToString(cboStream.SelectedItem);
            publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
            is_editable = IsEditableResults();
            if (Conversions.ToBoolean(Operators.AndObject(is_editable, !publicSubsNFunctions.IsAdmin())))
            {
                btnClear.Enabled = false;
            }
            else
            {
                btnClear.Enabled = true;
            }

            load_entry_form();
            Text = publicSubsNFunctions.title;
            dgvEnterMarks.Rows.Clear();
            int count = dgvEnterMarks.Columns.Count - 1;
            if (count > 6)
            {
                for (int k = dgvEnterMarks.Columns.Count - 1; k >= 6; k -= 1)
                    dgvEnterMarks.Columns.RemoveAt(k);
            }

            create_dataform();
            load_form();
            mark = Conversions.ToDouble(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.exam_name, publicSubsNFunctions.tm));
            loadSubjectsOutOf();
        }
        // Dim subj_out_of(subjabb.Length - 1)()
        private object[][] subj_out_of = new object[13][];

        private void loadSubjectsOutOf()
        {
            // todo change the code below added a try catch statement
            for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
            {
                try
                {
                    subj_out_of[k] = new object[cboStream.Items.Count - 2 + 1];
                    for (int i = 0, loopTo1 = subj_out_of[k].Length - 1; i <= loopTo1; i++)
                        subj_out_of[k][i] = 0;
                }
                catch (Exception ex)
                {
                }
            }

            try
            {
                for (int k = 0, loopTo2 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo2; k++)
                {
                    for (int i = 0, loopTo3 = subj_out_of[k].Length - 1; i <= loopTo3; i++)
                        subj_out_of[k][i] = publicSubsNFunctions.SubjectOutOf(publicSubsNFunctions.subjname[k], cboTerm.SelectedItem, cboYear.SelectedItem, cboExamName.SelectedItem, cboClass.SelectedItem, cboStream.Items[i].ToString());
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void load_entry_form()
        {
            publicSubsNFunctions.table = "exam_results";
            publicSubsNFunctions.class_form = Conversions.ToString(publicSubsNFunctions.get_name(Conversions.ToString(cboClass.SelectedItem)));
            publicSubsNFunctions.stream = Conversions.ToString(cboStream.SelectedItem);
            publicSubsNFunctions.exam_name = Conversions.ToString(cboExamName.SelectedItem);
        }

        private void Permissions()
        {
            // permissions sub determines which particular teacher can add or edit a particular exam admin is all and teacher is restricted
            cboSubject.Items.Clear();
            publicSubsNFunctions.USER_ID = 1; // todo remove this user id hardcoded
            if (publicSubsNFunctions.USER_ID == 1 | publicSubsNFunctions.USER_ID == 3)
            {
                cboSubject.Items.Add("All");
                for (int k = 0, loopTo = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo; k++)
                    cboSubject.Items.Add(publicSubsNFunctions.subjects[k]);
            }
            else
            {
                for (int k = 0, loopTo1 = publicSubsNFunctions.subjabb.Length - 1; k <= loopTo1; k++)
                {
                    if (publicSubsNFunctions.IsSubjectTeacher(Conversions.ToString(publicSubsNFunctions.subjects[k]), Conversions.ToString(cboClass.SelectedItem), Conversions.ToString(cboStream.SelectedItem), Conversions.ToString(cboTerm.SelectedItem), Conversions.ToString(cboYear.SelectedItem)))
                    {
                        cboSubject.Items.Add(publicSubsNFunctions.subjects[k]);
                    }
                }
            }

            cboSubject.SelectedItem = "All";
        }

        private void fill_exam()
        {
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT ExamName FROM examinations WHERE Term='", cboTerm.SelectedItem), "' AND Year='"), cboYear.SelectedItem), "'"));
            if (publicSubsNFunctions.qread(ref argq))
            {
                cboExamName.Items.Clear();
                cboExamName.Items.Add(publicSubsNFunctions.None);
                while (publicSubsNFunctions.dbreader.Read())
                    cboExamName.Items.Add(publicSubsNFunctions.dbreader["ExamName"]);
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Load Examinations!");
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Permissions();
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboTerm.SelectedItem, publicSubsNFunctions.None, false), (cboYear.SelectedItem.ToString() ?? "") != (publicSubsNFunctions.None ?? ""))))
            {
                fill_exam();
            }

            loadClasses();
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(cboClass.SelectedItem, publicSubsNFunctions.None, false)))
            {
                var argcbo = cboStream;
                publicSubsNFunctions.fill_class(Conversions.ToString(cboClass.SelectedItem), ref argcbo);
                cboStream = argcbo;
                cboStream.Items.Add("All");
                cboStream.SelectedItem = "All";
                Permissions();
            }
        }

        private void cboStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            Permissions();
        }

        private void loadClasses()
        {
            cboClass.Items.Clear();
            string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT class FROM examined_classes WHERE (Examination='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboExamName.SelectedItem)) + "' AND Term='" + publicSubsNFunctions.escape_string(Conversions.ToString(cboTerm.SelectedItem)) + "' AND Year='", cboYear.SelectedItem), "')"));
            publicSubsNFunctions.qread(ref argq);
            while (publicSubsNFunctions.dbreader.Read())
                cboClass.Items.Add(publicSubsNFunctions.dbreader["class"]);
        }

        private void btnImportResults_Click(object sender, EventArgs e)
        {
            if (dgvEnterMarks.Rows.Count == 0)
            {
                Interaction.MsgBox("Please select the year, term, exam .... inorder to add students to the list");
                return;
            }

            string abbr = string.Empty;
            string argq = "select abbreviation from subjects where subject = '" + cboSubject.SelectedItem.ToString() + "';";
            publicSubsNFunctions.qread(ref argq);
            while (publicSubsNFunctions.dbreader.Read())
                abbr = Conversions.ToString(publicSubsNFunctions.dbreader["abbreviation"]);
            for (int k = 0, loopTo = dgvEnterMarks.Rows.Count - 1; k <= loopTo; k++)
                dgvEnterMarks.Rows[k].Cells[abbr].Value = "-";
            if (!(OpenFileDialog1.ShowDialog() == DialogResult.OK))
            {
                return;
            }

            using (new DevExpress.Utils.WaitDialogForm("Importing Exam records, Please Wait .....", "Importing"))
            {
                Global.Microsoft.Office.Interop.Excel.Application xlApp;
                Global.Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Global.Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                Global.Microsoft.Office.Interop.Excel.Range range;
                int rCnt;
                int cCnt;
                object Obj;
                object Obj2;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(OpenFileDialog1.FileName);
                xlWorkSheet = xlWorkBook.Worksheets("sheet1");
                range = xlWorkSheet.UsedRange;
                var loopTo1 = range.Rows.Count;
                for (rCnt = 1; rCnt <= loopTo1; rCnt++)
                {
                    Obj = (Excel.Range)range.Cells(rCnt, 1);
                    Obj2 = (Excel.Range)range.Cells(rCnt, 3);
                    for (int k = 0, loopTo2 = dgvEnterMarks.Rows.Count - 1; k <= loopTo2; k++)
                    {
                        if ((dgvEnterMarks.Rows[k].Cells["admin_no"].Value.ToString() ?? "") == (Obj.value.ToString() ?? ""))
                        {
                            dgvEnterMarks.Rows[k].Cells[abbr].Value = Obj2.value.ToString();
                        }
                    }
                }

                xlWorkBook.Close();
                xlApp.Quit();
                releaseObject(xlApp);
                releaseObject(xlWorkBook);
                releaseObject(xlWorkSheet);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void Editor_Click(object sender, EventArgs e)
        {
            if (!(OpenFileDialog1.ShowDialog() == DialogResult.OK))
            {
                return;
            }

            using (new DevExpress.Utils.WaitDialogForm("Updating students details, Please Wait .....", "Updating Records"))
            {
                Global.Microsoft.Office.Interop.Excel.Application xlApp;
                Global.Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Global.Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                Global.Microsoft.Office.Interop.Excel.Range range;
                int rCnt;
                int cCnt;
                object Obj;
                object Obj2;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(OpenFileDialog1.FileName);
                xlWorkSheet = xlWorkBook.Worksheets("sheet1");
                range = xlWorkSheet.UsedRange;
                var rowValues = new Dictionary<string, string>();
                string col;
                string query;
                string values;
                string admNumber;
                string parentQuery;
                var parentsColums = new List<string>(new string[] { "father", "mother", "phone", "address", "admin_no" });
                string pCol;
                string pVal;
                var loopTo = range.Rows.Count;
                for (rCnt = 2; rCnt <= loopTo; rCnt++)
                {
                    rowValues.Clear();
                    query = string.Empty;
                    values = string.Empty;
                    admNumber = string.Empty;
                    pCol = string.Empty;
                    pVal = string.Empty;
                    var loopTo1 = range.Columns.Count;
                    for (cCnt = 1; cCnt <= loopTo1; cCnt++)
                    {
                        Obj = (Excel.Range)range.Cells(rCnt, cCnt);
                        if (!string.IsNullOrEmpty(Conversions.ToString(Obj.value)))
                        {
                            Obj2 = (Excel.Range)range.Cells(1, cCnt);
                            col = Conversions.ToString(Obj2.value);
                            rowValues.Add(col, Conversions.ToString(Obj.value));
                        }
                    }

                    if (rowValues.Count > 0)
                    {
                        for (int j = 0, loopTo2 = rowValues.Count - 1; j <= loopTo2; j++)
                        {
                            if (!parentsColums.Contains(rowValues.Keys.ElementAtOrDefault(j).ToLower()))
                            {
                                values += rowValues.Keys.ElementAtOrDefault(j) + "= '" + rowValues[rowValues.Keys.ElementAtOrDefault(j)] + "', ";
                            }
                        }

                        values = values.Remove(values.Length - 2, 2);
                        Obj2 = (Excel.Range)range.Cells(rCnt, 1);
                        admNumber = Conversions.ToString(Obj2.value);
                        query = "UPDATE students SET " + values + " WHERE  admin_no=" + admNumber + string.Empty;
                        if (publicSubsNFunctions.qwrite(query))
                        {
                            var parents = new List<string>(new string[] { "father", "mother" });
                            for (int z = 0, loopTo3 = parents.Count - 1; z <= loopTo3; z++)
                            {
                                pCol = string.Empty;
                                pVal = string.Empty;
                                if (rowValues.ContainsKey(parents[z]))
                                {
                                    pCol += "type, ";
                                    if (parents[z] == "father")
                                    {
                                        pVal += "'Father', ";
                                    }
                                    else
                                    {
                                        pVal += "'Mother', ";
                                    }

                                    for (int i = 0, loopTo4 = parentsColums.Count - 1; i <= loopTo4; i++)
                                    {
                                        if (rowValues.ContainsKey(parentsColums[i]))
                                        {
                                            if (z == 0)
                                            {
                                                if (!(parentsColums[i] == "mother"))
                                                {
                                                    pCol += parentsColums[i] + ", ";
                                                    pVal += "'" + rowValues[parentsColums[i]] + "', ";
                                                }
                                            }
                                            else if (!(parentsColums[i] == "father"))
                                            {
                                                pCol += parentsColums[i] + ", ";
                                                pVal += "'" + rowValues[parentsColums[i]] + "', ";
                                            }
                                        }
                                    }

                                    pCol = pCol.Remove(pCol.Count() - 2, 2).Replace("father", "name").Replace("mother", "name");
                                    pVal = pVal.Remove(pVal.Count() - 2, 2);
                                    parentQuery = "INSERT INTO parents_guardians (" + pCol + ") VALUES (" + pVal + ");";
                                    if (publicSubsNFunctions.qwrite(parentQuery))
                                    {
                                    }
                                }
                            }
                        }
                    }
                }

                xlWorkBook.Close();
                xlApp.Quit();
                releaseObject(xlApp);
                releaseObject(xlWorkBook);
                releaseObject(xlWorkSheet);
            }
        }

        private void deleteChk_CheckStateChanged(object sender, EventArgs e)
        {
            if (deleteChk.CheckState == CheckState.Checked)
            {
                var AddColumn = new DataGridViewCheckBoxColumn();
                AddColumn.HeaderText = "Delete";
                AddColumn.Name = "Delete";
                AddColumn.Width = 80;
                dgvEnterMarks.Columns.Insert(0, AddColumn);
            }
            else
            {
                dgvEnterMarks.Columns.Remove("Delete");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEnterMarks.Rows.Count == 0)
            {
                Interaction.MsgBox("There are no selected rows to delete");
            }
            else if (deleteChk.CheckState == CheckState.Unchecked)
            {
                Interaction.MsgBox("Please select the delete checkbox before proceding");
            }
            else
            {
                string query = string.Empty;
                if (publicSubsNFunctions.displayConfirmationMessage("Are you sure you want to delete the selected records"))
                {
                    foreach (DataGridViewRow row in dgvEnterMarks.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            query = "delete from exam_results where year = '" + cboYear.SelectedItem.ToString() + "' and term = '" + cboTerm.SelectedItem.ToString() + "' and examination = '" + cboExamName.SelectedItem.ToString() + "' and admno = '" + row.Cells["admin_no"].Value.ToString() + "'";
                            if (publicSubsNFunctions.qwrite(query))
                            {
                            }
                        }
                    }
                }
            }
        }

        private void cboExamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadClasses();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboYear.SelectedItem, null, false), Operators.ConditionalCompareObjectNotEqual(cboTerm.SelectedItem, null, false)), Operators.ConditionalCompareObjectNotEqual(cboExamName.SelectedItem, null, false)), Operators.ConditionalCompareObjectNotEqual(cboClass.SelectedItem, null, false)), Operators.ConditionalCompareObjectNotEqual(cboStream.SelectedItem, "All", false))))
            {
                publicSubsNFunctions.exam_name = Conversions.ToString(cboExamName.SelectedItem);
                publicSubsNFunctions.tm = Conversions.ToString(cboTerm.SelectedItem);
                publicSubsNFunctions.yr = Conversions.ToInteger(cboYear.SelectedItem);
                publicSubsNFunctions.class_form = Conversions.ToString(cboClass.SelectedItem);
                publicSubsNFunctions.stream = Conversions.ToString(cboStream.SelectedItem);
                var frm = new frmSubjectsOutOf();
                frm.ShowDialog();
            }
            else
            {
                publicSubsNFunctions.failure("Please Select An Examination And / Or Class / Stream To Enter Out Of Mark");
            }
        }
    }
}