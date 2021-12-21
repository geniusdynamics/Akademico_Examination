using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmBestStudentSubject
    {
        public frmBestStudentSubject()
        {
            InitializeComponent();
            _btnPrint.Name = "btnPrint";
            _btnCancel.Name = "btnCancel";
        }

        private void frmBestStudentSubject_Load(object sender, EventArgs e)
        {
            resultDGV.Rows.Clear();
            resultDGV.Columns.Clear();
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                using (new DevExpress.Utils.WaitDialogForm("Please Wait ..."))
                {
                    getSchoolSubjects();
                    if (!ExamFunctions.getGradingScheme())
                    {
                        Interaction.MsgBox("The " + publicSubsNFunctions.gradingType + " Grading Scheme For Class " + publicSubsNFunctions.selectedClass + " Term " + publicSubsNFunctions.selectedTerm + " Year " + publicSubsNFunctions.selectedYear + " Does Not Exist In The Database. Please Add It To Proceed Or Select Another Grading Scheme");
                        return;
                    }

                    ExamFunctions.initialzeGradePoints();
                    var argdgv = resultDGV;
                    reorderColumns(ref argdgv, false);
                    resultDGV = argdgv;
                    publicSubsNFunctions.students.Clear();
                    string argq = "select admin_no, student_name, gender, class, stream from students where class = '" + publicSubsNFunctions.selectedClass + "';";
                    if (publicSubsNFunctions.qread(ref argq))
                    {
                        if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                        {
                            while (publicSubsNFunctions.dbreader.Read())
                                publicSubsNFunctions.students.Add(new Tuple<long, string, string, string, string>(Conversions.ToLong(publicSubsNFunctions.dbreader["admin_no"]), Conversions.ToString(publicSubsNFunctions.dbreader["student_name"]), Conversions.ToString(publicSubsNFunctions.dbreader["gender"]), Conversions.ToString(publicSubsNFunctions.dbreader["class"]), Conversions.ToString(publicSubsNFunctions.dbreader["stream"])));
                        }
                    }

                    string query = string.Empty;
                    short examTotal;
                    short totalMarks;
                    var rowValues = new List<string>();
                    string studGrade = string.Empty;
                    string studPoints = string.Empty;
                    foreach (var currentSubject in publicSubsNFunctions.schoolSubjects)
                    {
                        publicSubsNFunctions.subject = currentSubject;
                        var argdgv1 = computeDVG;
                        reorderColumns(ref argdgv1);
                        computeDVG = argdgv1;
                        for (int i = 0, loopTo = publicSubsNFunctions.students.Count - 1; i <= loopTo; i++)
                        {
                            totalMarks = 0;
                            for (int j = 0, loopTo1 = publicSubsNFunctions.selectedExams.Count - 1; j <= loopTo1; j++)
                            {
                                examTotal = Conversions.ToShort(publicSubsNFunctions.get_total_mark(publicSubsNFunctions.selectedExams[j].Item1, publicSubsNFunctions.selectedExams[j].Item3, publicSubsNFunctions.selectedExams[j].Item4));
                                query = "select COALESCE(((" + publicSubsNFunctions.subject + "/" + examTotal.ToString() + ") * " + publicSubsNFunctions.selectedExams[j].Item2 + "), 0) as total from exam_results where examination = '" + publicSubsNFunctions.selectedExams[j].Item1 + "' and admno = " + publicSubsNFunctions.students[i].Item1.ToString() + " and term = '" + publicSubsNFunctions.selectedExams[j].Item3 + "' and year = '" + publicSubsNFunctions.selectedExams[j].Item4.ToString() + "'";
                                if (publicSubsNFunctions.qread(ref query))
                                {
                                    if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                                    {
                                        while (publicSubsNFunctions.dbreader.Read())
                                            totalMarks = Conversions.ToShort(totalMarks + publicSubsNFunctions.dbreader["total"]);
                                    }
                                }
                            }

                            rowValues.Add("0");
                            rowValues.Add(publicSubsNFunctions.students[i].Item1.ToString());
                            rowValues.Add(publicSubsNFunctions.students[i].Item2);
                            rowValues.Add(publicSubsNFunctions.students[i].Item3);
                            rowValues.Add(totalMarks.ToString());
                            if (publicSubsNFunctions.gradingType == "SubjectBased")
                            {
                                studGrade = ExamFunctions.convertMarksToGrade(totalMarks, publicSubsNFunctions.gradingType, publicSubsNFunctions.subject);
                            }
                            else
                            {
                                studGrade = ExamFunctions.convertMarksToGrade(totalMarks, publicSubsNFunctions.gradingType);
                            }

                            rowValues.Add(studGrade);
                            studPoints = ExamFunctions.convertGradeToPoints(studGrade).ToString();
                            rowValues.Add(studPoints);
                            computeDVG.Rows.Add(rowValues.ToArray());
                            rowValues.Clear();
                        }

                        DataGridViewRow row;
                        computeDVG.Sort(computeDVG.Columns[4], System.ComponentModel.ListSortDirection.Descending);
                        if (publicSubsNFunctions.filterType == "Top")
                        {
                            if (publicSubsNFunctions.rankno + 1 < computeDVG.Rows.Count)
                            {
                                for (int i = computeDVG.Rows.Count - 1, loopTo2 = publicSubsNFunctions.rankno; i >= loopTo2; i -= 1)
                                {
                                    row = computeDVG.Rows[i];
                                    computeDVG.Rows.Remove(row);
                                }
                            }
                        }

                        if (publicSubsNFunctions.filterType == "Bottom")
                        {
                            if (publicSubsNFunctions.rankno + 1 < computeDVG.Rows.Count)
                            {
                                for (int i = computeDVG.Rows.Count - 1 - publicSubsNFunctions.rankno; i >= 0; i -= 1)
                                {
                                    row = computeDVG.Rows[i];
                                    computeDVG.Rows.Remove(row);
                                }
                            }
                        }

                        var argdgv2 = computeDVG;
                        fillResultTable(ref argdgv2, publicSubsNFunctions.subject);
                        computeDVG = argdgv2;
                    }
                }
            }
        }

        private void fillResultTable(ref DataGridView dgv, string subject)
        {
            short counter = 1;
            resultDGV.Rows.Add(subject);
            for (int k = 0, loopTo = dgv.Rows.Count - 1; k <= loopTo; k++)
            {
                resultDGV.Rows.Add(counter, dgv.Rows[k].Cells[1].Value, dgv.Rows[k].Cells[2].Value, dgv.Rows[k].Cells[3].Value, dgv.Rows[k].Cells[4].Value, dgv.Rows[k].Cells[5].Value, dgv.Rows[k].Cells[6].Value);
                counter = (short)(counter + 1);
            }
        }

        public object getSchoolSubjects()
        {
            publicSubsNFunctions.schoolSubjects.Clear();
            bool available = false;
            string argq = "select abbreviation from subjects;";
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    available = true;
                    while (publicSubsNFunctions.dbreader.Read())
                        publicSubsNFunctions.schoolSubjects.Add(Conversions.ToString(publicSubsNFunctions.dbreader["abbreviation"]));
                }
            }

            return available;
        }

        public void reorderColumns(ref DataGridView dgv, bool delete = true)
        {
            if (delete)
            {
                dgv.Rows.Clear();
                dgv.Columns.Clear();
            }

            dgv.Columns.Add("No", "No");
            dgv.Columns.Add("admno", "Adm No.");
            dgv.Columns.Add("student_name", "Name Of Student");
            dgv.Columns.Add("gender", "Gender");
            dgv.Columns.Add("marks", "marks");
            dgv.Columns.Add("grade", "grade");
            dgv.Columns.Add("point", "Points");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (resultDGV.Rows.Count > 0)
            {
                var argmyView = resultDGV;
                reporting.generateFromDataTable("Subject Wise Ranking", "From Grid", string.Empty, null, ref argmyView);
                resultDGV = argmyView;
            }
            else
            {
                Interaction.MsgBox("There are no row to print");
            }
        }
    }
}