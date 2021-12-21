using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmPrintSubjectsTaken
    {
        public frmPrintSubjectsTaken()
        {
            InitializeComponent();
            _btnShow.Name = "btnShow";
        }

        private void frmPrintSubjectsTaken_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                My.MyProject.Forms.frmDBConnection.ShowDialog();
                return;
            }

            reportDT.Columns.Add("ADM NO");
            reportDT.Columns.Add("STUDENT");
            var queries = new[] { "select distinct class from class_stream;", "select distinct stream from class_stream;", "select distinct subject from subjects;" };
            int counter = 0;
            foreach (string s in queries)
            {
                if (publicSubsNFunctions.qread(ref s))
                {
                    if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                    {
                        while (publicSubsNFunctions.dbreader.Read())
                        {
                            if (counter == 0)
                            {
                                cboClass.Items.Add(publicSubsNFunctions.dbreader["class"]);
                            }
                            else if (counter == 1)
                            {
                                CboStream.Items.Add(publicSubsNFunctions.dbreader["stream"]);
                            }
                            else if (counter == 2)
                            {
                                cboSubject.Items.Add(publicSubsNFunctions.dbreader["subject"]);
                            }
                        }
                    }
                }

                counter += 1;
            }

            if (!(Text == "Show Subjects Taken"))
            {
                cboSubject.Items.Insert(0, "ALL");
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            reportDT.Rows.Clear();
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboClass.SelectedItem, null, false)))
            {
                ErrorProvider1.SetError(cboClass, "Please Select The Class");
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboSubject.SelectedItem, null, false)))
            {
                ErrorProvider1.SetError(cboSubject, "Please Select The Subject");
            }
            else
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(CboStream.SelectedItem, null, false)))
                {
                    if (!loadAdmissionNumber("Class Only"))
                    {
                        return;
                    }
                }
                else if (!loadAdmissionNumber("Class and Stream"))
                {
                    return;
                }

                if (Text == "Show Subjects Taken")
                {
                    string argsubject = cboSubject.SelectedItem.ToString();
                    string abbreviation = Conversions.ToString(getAbbreviation(ref argsubject));
                    foreach (long adm in adminNos.Keys)
                    {
                        string test = "select admno from subjects_done where admno = '" + adm.ToString() + "' and " + abbreviation + " = 'Yes';";
                        string argq = "select admno from subjects_done where admno = '" + adm.ToString() + "' and " + abbreviation + " = 'Yes';";
                        if (publicSubsNFunctions.qread(ref argq))
                        {
                            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                            {
                                var rowData = new[] { adm.ToString(), adminNos[adm] };
                                reportDT.Rows.Add(rowData);
                            }
                        }
                    }

                    string rptTitle = string.Empty;
                    if (CboStream.SelectedItem is object)
                    {
                        rptTitle = "Student List For " + cboSubject.SelectedItem.ToString() + " Class " + cboClass.SelectedItem.ToString() + " Stream " + CboStream.SelectedItem.ToString();
                    }
                    else
                    {
                        publicSubsNFunctions.rpt = "Student List For " + cboSubject.SelectedItem.ToString() + " Class " + cboClass.SelectedItem.ToString();
                    }

                    reporting.addColumnNumbering(ref reportDT);
                    DataGridView argmyView = null;
                    reporting.generateFromDataTable(rptTitle, "From DT", string.Empty, reportDT, myView: ref argmyView);
                }
                else
                {
                    clearAdd();
                    if (cboSubject.SelectedIndex == 0)
                    {
                        var items = cboSubject.Items.GetEnumerator();
                        while (items.MoveNext())
                        {
                            object localgetAbbreviation() { string argsubject = Conversions.ToString(items.Current); var ret = getAbbreviation(ref argsubject); items.Current = argsubject; return ret; }

                            reportDT.Columns.Add(localgetAbbreviation());
                        }

                        reportDT.Columns.RemoveAt(2);
                    }
                    else
                    {
                        reportDT.Columns.Add(cboSubject.SelectedItem.ToString());
                    }

                    foreach (long adm in adminNos.Keys)
                    {
                        var rowData = new[] { adm.ToString(), adminNos[adm] };
                        reportDT.Rows.Add(rowData);
                    }

                    string rptTitle = string.Empty;
                    if (CboStream.SelectedItem is object)
                    {
                        rptTitle = "Student List For " + cboSubject.SelectedItem.ToString() + " Class " + cboClass.SelectedItem.ToString() + " Stream " + CboStream.SelectedItem.ToString();
                    }
                    else
                    {
                        publicSubsNFunctions.rpt = "Student List For " + cboSubject.SelectedItem.ToString() + " Class " + cboClass.SelectedItem.ToString();
                    }

                    reporting.addColumnNumbering(ref reportDT);
                    DataGridView argmyView1 = null;
                    reporting.generateFromDataTable(rptTitle, "From DT", string.Empty, reportDT, myView: ref argmyView1);
                }
            }
        }

        private void clearAdd()
        {
            reportDT.Rows.Clear();
            reportDT.Columns.Clear();
            reportDT.Columns.Add("ADM NO");
            reportDT.Columns.Add("STUDENT");
            var identifier = Guid.NewGuid();
            reportDT.TableName = identifier.ToString();
        }

        private object getAbbreviation(ref string subject)
        {
            string abb = string.Empty;
            string argq = "select abbreviation from subjects where subject = '" + subject + "'";
            if (publicSubsNFunctions.qread(ref argq, 1))
            {
                if (publicSubsNFunctions.dbreader1.RecordsAffected > 0)
                {
                    publicSubsNFunctions.dbreader1.Read();
                    abb = Conversions.ToString(publicSubsNFunctions.dbreader1["abbreviation"]);
                }
            }

            return abb;
        }

        private DataTable reportDT = new DataTable();
        private Dictionary<long, string> adminNos = new Dictionary<long, string>();

        private bool loadAdmissionNumber(string type)
        {
            adminNos.Clear();
            publicSubsNFunctions.successful = false;
            string q = string.Empty;
            if (type == "Class Only")
            {
                q = "select admin_no, student_name from students where class = '" + cboClass.SelectedItem.ToString() + "' and isstudent = 'true';";
            }
            else
            {
                q = "select admin_no, student_name from students where class = '" + cboClass.SelectedItem.ToString() + "' and stream = '" + CboStream.SelectedItem.ToString() + "' and isstudent='true';";
            }

            if (publicSubsNFunctions.qread(ref q))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    while (publicSubsNFunctions.dbreader.Read())
                        adminNos.Add(Conversions.ToLong(publicSubsNFunctions.dbreader["admin_no"]), Conversions.ToString(publicSubsNFunctions.dbreader["student_name"]));
                    publicSubsNFunctions.successful = true;
                }
                else
                {
                    Interaction.MsgBox("There Are No Students Registered In The Class");
                }
            }

            return publicSubsNFunctions.successful;
        }
    }
}