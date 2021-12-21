using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using global::System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmMeanResults
    {
        public frmMeanResults()
        {
            InitializeComponent();
            _chkMode.Name = "chkMode";
            _marksGrade.Name = "marksGrade";
            _Button4.Name = "Button4";
            _btnStreamPerformance.Name = "btnStreamPerformance";
            _btnClassPerformance.Name = "btnClassPerformance";
            _Button3.Name = "Button3";
            _Button6.Name = "Button6";
        }

        private List<Tuple<long, string, string, string, string>> students = new List<Tuple<long, string, string, string, string>>();
        private List<string> classStream = new List<string>();

        private void getStreams()
        {
            classStream.Clear();
            string argq = "select DISTINCT(stream) as stream from class_stream where class = '" + publicSubsNFunctions.selectedClass + "';";
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    while (publicSubsNFunctions.dbreader.Read())
                        classStream.Add(Conversions.ToString(publicSubsNFunctions.dbreader["stream"]));
                }
            }
        }

        private void reorderColumns()
        {
            dgvMeanMarks.Rows.Clear();
            dgvMeanMarks.Columns.Clear();
            dgvMeanMarks.Columns.Add("admno", "Adm No.");
            dgvMeanMarks.Columns.Add("student_name", "Name Of Student");
            dgvMeanMarks.Columns.Add("kcpe", "KCPE");
            originalData.Columns.Add("admno");
            originalData.Columns["admno"].Caption = "ADM";
            originalData.Columns.Add("student_name");
            originalData.Columns["student_name"].Caption = "Student Name";
            originalData.Columns.Add("kcpe");
            originalData.Columns["kcpe"].Caption = "KCPE";
            foreach (string s in publicSubsNFunctions.subjectColumns)
            {
                dgvMeanMarks.Columns.Add(s.Replace(" ", "_"), s);
                originalData.Columns.Add(s.Replace(" ", "_"));
            }

            var additonalColumns = new[] { "SE", "TP", "MP", "MG", "TM", "STR", "SP", "OP" };
            foreach (string s in additonalColumns)
            {
                dgvMeanMarks.Columns.Add(s, s);
                originalData.Columns.Add(s);
                if (s == "TP" | s == "MP" | s == "TM")
                {
                    dgvMeanMarks.Columns[s].ValueType = Type.GetType("System.Double");
                }
            }
        }

        private string getSelectStatement()
        {
            string statements = string.Empty;
            foreach (string S in publicSubsNFunctions.subjectColumns)
                statements += " round(avg(" + S + ")) as " + S + ",";
            statements = statements.Remove(statements.Length - 1);
            return statements;
        }

        private string getWhereStatements()
        {
            string where = string.Empty;
            for (int i = 0, loopTo = publicSubsNFunctions.examList.Count - 1; i <= loopTo; i++)
                where += " (examination = '" + publicSubsNFunctions.examList[i].Item1 + "' and term = '" + publicSubsNFunctions.examList[i].Item2 + "' and year = " + publicSubsNFunctions.examList[i].Item3 + " ) or ";
            where = where.Remove(where.Length - 3);
            return where;
        }

        private int getSubjectEntries(int adm_no)
        {
            int entries = 0;
            string argq = "select *  from subjects_done where admno = " + adm_no.ToString() + ";";
            if (publicSubsNFunctions.qread(ref argq, 1))
            {
                if (publicSubsNFunctions.dbreader1.RecordsAffected > 0)
                {
                    while (publicSubsNFunctions.dbreader1.Read())
                    {
                        foreach (string s in publicSubsNFunctions.subjectColumns)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(publicSubsNFunctions.dbreader1[s], "Yes", false)))
                            {
                                entries += 1;
                            }
                        }
                    }
                }
            }

            return entries;
        }

        private Dictionary<string, List<Tuple<string, short>>> subjectGrading = new Dictionary<string, List<Tuple<string, short>>>();
        private List<Tuple<string, short>> classGrading = new List<Tuple<string, short>>();

        private void test(string subject, List<Tuple<string, short>> gradeList)
        {
            var newListTuple = new List<Tuple<string, short>>();
            for (int i = 0, loopTo = gradeList.Count - 1; i <= loopTo; i++)
                newListTuple.Add(new Tuple<string, short>(gradeList[i].Item1, gradeList[i].Item2));
            subjectGrading.Add(subject, newListTuple);
        }

        private bool getGradingScheme()
        {
            bool schemeAvailable = false;
            string query = string.Empty;
            var gradess = new[] { "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "E" };
            var gradeValues = new List<Tuple<string, short>>();
            var saveGradeValue = new List<Tuple<string, short>>();
            if (publicSubsNFunctions.gradingType == "SubjectBased")
            {
                subjectGrading.Clear();
                foreach (string s in publicSubsNFunctions.subjectColumns)
                {
                    query = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM s_grading WHERE (Class='" + publicSubsNFunctions.selectedClass + "' AND Subject='", publicSubsNFunctions.get_subject_name(s)), "' AND term='"), publicSubsNFunctions.selectedTerm), "' AND year='"), publicSubsNFunctions.selectedYear), "');"));
                    if (publicSubsNFunctions.qread(ref query, 1))
                    {
                        if (publicSubsNFunctions.dbreader1.RecordsAffected > 0)
                        {
                            schemeAvailable = true;
                            while (publicSubsNFunctions.dbreader1.Read())
                            {
                                foreach (string g in gradess)
                                    gradeValues.Add(new Tuple<string, short>(g, Conversions.ToShort(publicSubsNFunctions.dbreader1[g])));
                                test(s, gradeValues);
                                // subjectGrading.Add(s, gradeValues)
                                gradeValues.Clear();
                            }
                        }
                    }
                }
            }
            else
            {
                classGrading.Clear();
                query = "SELECT * FROM grading WHERE (Class='" + publicSubsNFunctions.selectedClass + "' AND term='" + publicSubsNFunctions.selectedTerm + "' AND year='" + publicSubsNFunctions.selectedYear + "');";
                if (publicSubsNFunctions.qread(ref query, 1))
                {
                    if (publicSubsNFunctions.dbreader1.RecordsAffected > 0)
                    {
                        schemeAvailable = true;
                        while (publicSubsNFunctions.dbreader1.Read())
                        {
                            foreach (string g in gradess)
                                classGrading.Add(new Tuple<string, short>(g, Conversions.ToShort(publicSubsNFunctions.dbreader1[g])));
                        }
                    }
                }
            }

            return schemeAvailable;
        }

        private Dictionary<string, short> GradeToPoint = new Dictionary<string, short>();

        private void initialzeGradePoints()
        {
            GradeToPoint.Add("A", 12);
            GradeToPoint.Add("A-", 11);
            GradeToPoint.Add("B+", 10);
            GradeToPoint.Add("B", 9);
            GradeToPoint.Add("B-", 8);
            GradeToPoint.Add("C+", 7);
            GradeToPoint.Add("C", 6);
            GradeToPoint.Add("C-", 5);
            GradeToPoint.Add("D+", 4);
            GradeToPoint.Add("D", 3);
            GradeToPoint.Add("D-", 2);
            GradeToPoint.Add("E", 1);
            GradeToPoint.Add("Y", 0);
            GradeToPoint.Add("X", 0);
        }

        private short convertGradeToPoints(string grade)
        {
            short points;
            points = GradeToPoint[grade];
            return points;
        }

        private string convertGradeToPointsReverse(int grade)
        {
            string ans = string.Empty;
            ans = (from l in GradeToPoint
                   where l.Value == grade
                   select l.Key).FirstOrDefault();
            return ans;
        }

        private string getMeanGrade(short meanGrade)
        {
            string grade = string.Empty;
            foreach (var var in GradeToPoint)
            {
                if (meanGrade >= var.Value)
                {
                    grade = var.Key;
                    break;
                }
            }

            return grade;
        }

        private string convertMarksToGrade(short marks, string gradingType, string subjectParm = "")
        {
            string studGrade = string.Empty;
            if (marks == 0)
            {
                studGrade = "Y";
            }
            else if (gradingType == "SubjectBased")
            {
                // Dim subjectGrading As New Dictionary(Of String, List(Of Tuple(Of String, Int16)))
                var subjGrade = subjectGrading[subjectParm];
                if (marks < subjGrade[subjGrade.Count - 1].Item2)
                {
                    studGrade = "E";
                }
                else
                {
                    for (int i = 0, loopTo1 = subjGrade.Count - 1; i <= loopTo1; i++)
                    {
                        if (marks >= subjGrade[i].Item2)
                        {
                            studGrade = subjGrade[i].Item1;
                            break;
                        }
                    }
                }
            }
            // Dim classGrading As New List(Of Tuple(Of String, Int16))
            else if (marks < classGrading[classGrading.Count - 1].Item2)
            {
                studGrade = "E";
            }
            else
            {
                for (int i = 0, loopTo = classGrading.Count - 1; i <= loopTo; i++)
                {
                    if (marks >= classGrading[i].Item2)
                    {
                        studGrade = classGrading[i].Item1;
                        break;
                    }
                }
            }

            return studGrade;
        }

        private List<Tuple<string, int>> getHighestMark(Array subjectList, int rowIndex)
        {
            var highestMarks = new List<Tuple<string, int>>();
            var subjectMarkss = new List<Tuple<string, int>>();
            foreach (string s in subjectList)
                subjectMarkss.Add(new Tuple<string, int>(s, Conversions.ToInteger(dgvMeanMarks.Rows[rowIndex].Cells[s].Value)));
            var test = (from m in subjectMarkss
                        orderby m.Item2 descending
                        select m).FirstOrDefault();
            highestMarks.Add(test);
            return highestMarks;
        }

        private void setIndexing()
        {
            string code = string.Empty;
            string index = string.Empty;
            string argq = "select code from school_details";
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected == 0)
                {
                    if (Conversions.ToBoolean(!publicSubsNFunctions.confirm("Your School Code May Not Have Been Set! Do You Want To Continue Anyway?")))
                    {
                        return;
                    }
                }
                else
                {
                    code = Conversions.ToString(publicSubsNFunctions.dbreader["code"]);
                }
            }

            if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Are You Sure ?")))
            {
                publicSubsNFunctions.start();
                using (new DevExpress.Utils.WaitDialogForm("Saving Data Please Wait"))
                    for (int i = 0, loopTo = dgvMeanMarks.Rows.Count - 1; i <= loopTo; i++)
                    {
                        index = Conversions.ToString(Operators.AddObject(code, dgvMeanMarks.Rows[i].Cells["OP"].Value));
                        if (!publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("UPDATE students SET indexno = '" + index + "' WHERE admin_no =  '", dgvMeanMarks.Rows[i].Cells["admno"].Value), "'"))))
                        {
                            publicSubsNFunctions.rollback();
                            publicSubsNFunctions.failure("Could Not Successfully Perform Index Numbering!");
                            return;
                        }
                    }

                publicSubsNFunctions.commit();
                Interaction.MsgBox("The Operation  Was Successful");
            }
        }

        private void showMarksAndGrade()
        {
            using (new DevExpress.Utils.WaitDialogForm("Computing Please Wait ..."))
                for (int i = 0, loopTo = dgvMeanMarks.Rows.Count - 1; i <= loopTo; i++)
                {
                    foreach (string s in publicSubsNFunctions.subjectColumns)
                    {
                        subjectMark = Conversions.ToInteger(dgvMeanMarks.Rows[i].Cells[s].Value);
                        subjectGrade = convertMarksToGrade((short)subjectMark, publicSubsNFunctions.gradingType, s);
                        dgvMeanMarks.Rows[i].Cells[s].Value = subjectMark.ToString() + " " + subjectGrade;
                    }
                }
        }

        private void deleteMarkGrade()
        {
            string mark = string.Empty;
            using (new DevExpress.Utils.WaitDialogForm("Please Wait ..."))
                for (int i = 0, loopTo = dgvMeanMarks.Rows.Count - 1; i <= loopTo; i++)
                {
                    foreach (string s in publicSubsNFunctions.subjectColumns)
                    {
                        mark = Conversions.ToString(dgvMeanMarks.Rows[i].Cells[s].Value);
                        if (mark.Length > 2)
                        {
                            mark = mark.Remove(mark.Length - 2);
                            dgvMeanMarks.Rows[i].Cells[s].Value = mark;
                        }
                    }
                }
        }

        private void getB7()
        {
            var compulsory = new string[] { "ENG", "KISW", "MATH", "CHEM" };
            var science = new string[] { "PHY", "BIO" };
            var humanity = new string[] { "GEO", "HIST" };
            var others = new string[] { "CRE", "IRE", "BST", "AGR" };
            subjectEntries = 7;
            var groupedSubject = new List<Array>();
            var ordered = new List<Tuple<string, int>>();
            groupedSubject.AddRange(new[] { science, humanity, others });
            allResults.Clear();
            streamResults.Clear();
            for (int l = dgvMeanMarks.Rows.Count - 1, loopTo = dgvMeanMarks.Rows.Count - 4; l >= loopTo; l -= 1)
                dgvMeanMarks.Rows.RemoveAt(l);
            using (new DevExpress.Utils.WaitDialogForm("Please Wait ..."))
            {
                for (int i = 0, loopTo1 = dgvMeanMarks.Rows.Count - 1; i <= loopTo1; i++)
                {
                    tpp = 0;
                    tmm = 0;
                    foreach (string s in compulsory)
                    {
                        subjectMark = Conversions.ToInteger(dgvMeanMarks.Rows[i].Cells[s].Value);
                        subjectGrade = convertMarksToGrade((short)subjectMark, publicSubsNFunctions.gradingType, s);
                        subjectPoints = convertGradeToPoints(subjectGrade);
                        tpp += subjectPoints;
                        tmm += subjectMark;
                    }

                    for (int k = 0, loopTo2 = groupedSubject.Count - 1; k <= loopTo2; k++)
                    {
                        // ordered = getHighestMark(science, i)
                        ordered = getHighestMark(groupedSubject[k], i);
                        subjectMark = ordered[0].Item2;
                        subjectGrade = convertMarksToGrade((short)subjectMark, publicSubsNFunctions.gradingType, ordered[0].Item1);
                        subjectPoints = convertGradeToPoints(subjectGrade);
                        tpp += subjectPoints;
                        tmm += subjectMark;
                    }

                    dgvMeanMarks.Rows[i].Cells["TP"].Value = tpp;
                    mpp = Math.Round(tpp / (double)subjectEntries, 2, MidpointRounding.AwayFromZero);
                    dgvMeanMarks.Rows[i].Cells["MP"].Value = mpp;
                    mgg = getMeanGrade((short)Math.Round(mpp));
                    dgvMeanMarks.Rows[i].Cells["MG"].Value = mgg;
                    dgvMeanMarks.Rows[i].Cells["TM"].Value = tmm;
                    if (publicSubsNFunctions.sortGradesBy == "Total Marks")
                    {
                        allResults.Add(new Tuple<string, double>(Conversions.ToString(dgvMeanMarks.Rows[i].Cells["STR"].Value), tmm));
                    }
                    else if (publicSubsNFunctions.sortGradesBy == "Mean Marks")
                    {
                        allResults.Add(new Tuple<string, double>(Conversions.ToString(dgvMeanMarks.Rows[i].Cells["STR"].Value), Math.Round(tmm / (double)subjectEntries, 2, MidpointRounding.AwayFromZero)));
                    }
                    else if (publicSubsNFunctions.sortGradesBy == "Mean Points")
                    {
                        allResults.Add(new Tuple<string, double>(Conversions.ToString(dgvMeanMarks.Rows[i].Cells["STR"].Value), mpp));
                    }
                    else
                    {
                        allResults.Add(new Tuple<string, double>(Conversions.ToString(dgvMeanMarks.Rows[i].Cells["STR"].Value), tpp));
                    }
                }

                var streamList = new List<double>();
                int element;
                int j;

                // Compute Overall Position
                var overAllPos = new List<double>();
                overAllPos = (from all in allResults
                              orderby all.Item2 descending
                              select all.Item2).ToList();
                for (int i = 0, loopTo3 = dgvMeanMarks.RowCount - 4; i <= loopTo3; i++)
                {
                    element = overAllPos.IndexOf(Convert.ToDouble(dgvMeanMarks.Rows[i].Cells[publicSubsNFunctions.sortby].Value));
                    dgvMeanMarks.Rows[i].Cells["OP"].Value = element + 1;
                }


                // Compute Stream Position
                for (int s = 0, loopTo4 = classStream.Count - 1; s <= loopTo4; s++)
                {

                    // get the results for one stream only
                    j = s;
                    streamList = (from all in allResults
                                  where (all.Item1 ?? "") == (classStream[j] ?? "")
                                  orderby all.Item2 descending
                                  select all.Item2).ToList();
                    for (int i = 0, loopTo5 = dgvMeanMarks.RowCount - 4; i <= loopTo5; i++)
                    {

                        // do not loop if stream is not the same
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvMeanMarks.Rows[i].Cells["STR"].Value, classStream[j], false)))
                        {

                            // IndexOf returns -1 when that item does not occur remember its a zero based so add one to the element
                            element = streamList.IndexOf(Convert.ToDouble(dgvMeanMarks.Rows[i].Cells[publicSubsNFunctions.sortby].Value));
                            dgvMeanMarks.Rows[i].Cells["SP"].Value = element + 1;
                        }
                    }
                }

                dgvMeanMarks.Sort(dgvMeanMarks.Columns["OP"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        private List<Tuple<string, double>> allResults = new List<Tuple<string, double>>();
        private List<Tuple<string, double>> streamResults = new List<Tuple<string, double>>();

        private void exportDataToExcel()
        {
            var argmyView = dgvMeanMarks;
            reporting.exportToExcel(ref argmyView);
            dgvMeanMarks = argmyView;
        }

        private string subjectGrade = string.Empty;
        private int tpp, tmm;
        private double mpp;
        private short subjectPoints, subjectEntries;
        private int subjectMark;
        private string mgg = string.Empty;
        private DataTable originalData = new DataTable();

        private void initializeAverageResult()
        {
            foreach (var x in publicSubsNFunctions.subjectColumns)
            {
                overallAverage.Add(x, 0);
                averagePoints.Add(x, 0d);
            }
        }

        private void frmMeanResults_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                using (new DevExpress.Utils.WaitDialogForm("Please Wait ..."))
                {
                    if (!getGradingScheme())
                    {
                        Interaction.MsgBox("The " + publicSubsNFunctions.gradingType + " Grading Scheme For Class " + publicSubsNFunctions.selectedClass + " Term " + publicSubsNFunctions.selectedTerm + " Year " + publicSubsNFunctions.selectedYear + " Does Not Exist In The Database. Please Add It To Proceed Or Select Another Grading Scheme");
                        return;
                    }

                    initialzeGradePoints();
                    getStreams();
                    initializeAverageResult();
                    string argq = "select admin_no, student_name, marks_attained_primary as kcpe, class, stream from students where class = '" + publicSubsNFunctions.selectedClass + "';";
                    if (publicSubsNFunctions.qread(ref argq))
                    {
                        if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                        {
                            while (publicSubsNFunctions.dbreader.Read())
                                students.Add(new Tuple<long, string, string, string, string>(Conversions.ToLong(publicSubsNFunctions.dbreader["admin_no"]), Conversions.ToString(publicSubsNFunctions.dbreader["student_name"]), Conversions.ToString(publicSubsNFunctions.dbreader["kcpe"]), Conversions.ToString(publicSubsNFunctions.dbreader["class"]), Conversions.ToString(publicSubsNFunctions.dbreader["stream"])));
                        }
                    }

                    reorderColumns();
                    getStudentSubjectDone();
                    var rowValues = new List<string>();
                    string sqlStatment = string.Empty;
                    string selectStatement = getSelectStatement();
                    string fromStatement = string.Empty;
                    string whereStatement = getWhereStatements();
                    var markSubject = new Dictionary<string, short>();
                    bool isUpperClass = false;
                    allResults.Clear();
                    streamResults.Clear();
                    for (int i = 0, loopTo = students.Count - 1; i <= loopTo; i++)
                    {
                        rowValues.Clear();
                        tmm = 0;
                        tpp = 0;
                        markSubject.Clear();
                        if (publicSubsNFunctions.selectedClass.ToLower() == "form 2" | publicSubsNFunctions.selectedClass.ToLower() == "form 3" | publicSubsNFunctions.selectedClass.ToLower() == "form 4")
                        {
                            isUpperClass = true;
                        }

                        fromStatement = " from exam_results where admno = " + students[i].Item1.ToString() + " and (";
                        sqlStatment = "select " + selectStatement + fromStatement + whereStatement + ")";
                        if (publicSubsNFunctions.qread(ref sqlStatment))
                        {
                            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                            {
                                rowValues.Add(students[i].Item1.ToString());
                                rowValues.Add(students[i].Item2);
                                rowValues.Add(students[i].Item3);
                                while (publicSubsNFunctions.dbreader.Read())
                                {
                                    foreach (string s in publicSubsNFunctions.subjectColumns)
                                    {
                                        if (Information.IsDBNull(publicSubsNFunctions.dbreader[s]))
                                        {
                                            subjectMark = 0;
                                        }
                                        else
                                        {
                                            subjectMark = Conversions.ToInteger(publicSubsNFunctions.dbreader[s]);
                                        }

                                        rowValues.Add(subjectMark.ToString());
                                        subjectGrade = convertMarksToGrade((short)subjectMark, publicSubsNFunctions.gradingType, s);
                                        subjectPoints = convertGradeToPoints(subjectGrade);
                                        tpp += subjectPoints;
                                        tmm += subjectMark;
                                    }
                                }

                                subjectEntries = (short)getSubjectEntries((int)students[i].Item1);
                                rowValues.Add(subjectEntries.ToString());
                                rowValues.Add(tpp.ToString());
                                mpp = Math.Round(tpp / (double)subjectEntries, 2, MidpointRounding.AwayFromZero);
                                rowValues.Add(mpp.ToString());
                                mgg = getMeanGrade((short)Math.Round(mpp));
                                rowValues.Add(mgg);
                                rowValues.Add(tmm.ToString());
                                rowValues.Add(students[i].Item5);
                                dgvMeanMarks.Rows.Add(rowValues.ToArray());
                                if (publicSubsNFunctions.sortGradesBy == "Total Marks")
                                {
                                    allResults.Add(new Tuple<string, double>(students[i].Item5, tmm));
                                }
                                else if (publicSubsNFunctions.sortGradesBy == "Mean Marks")
                                {
                                    allResults.Add(new Tuple<string, double>(students[i].Item5, Math.Round(tmm / (double)subjectEntries, 2, MidpointRounding.AwayFromZero)));
                                }
                                else if (publicSubsNFunctions.sortGradesBy == "Mean Points")
                                {
                                    allResults.Add(new Tuple<string, double>(students[i].Item5, mpp));
                                }
                                else
                                {
                                    allResults.Add(new Tuple<string, double>(students[i].Item5, tpp));
                                }
                            }
                        }
                    }

                    if (publicSubsNFunctions.sortGradesBy == "Total Marks")
                    {
                        publicSubsNFunctions.sortby = "TM";
                    }
                    else if (publicSubsNFunctions.sortGradesBy == "Mean Marks")
                    {
                        publicSubsNFunctions.sortby = "MM";
                    }
                    else if (publicSubsNFunctions.sortGradesBy == "Mean Points")
                    {
                        publicSubsNFunctions.sortby = "MP";
                    }
                    else
                    {
                        publicSubsNFunctions.sortby = "TP";
                    }

                    var streamList = new List<double>();
                    int element;
                    int j;

                    // Compute Overall Position
                    var overAllPos = new List<double>();
                    overAllPos = (from all in allResults
                                  orderby all.Item2 descending
                                  select all.Item2).ToList();
                    resultsTotal = 0;
                    averageMP = 0;
                    for (int i = 0, loopTo1 = dgvMeanMarks.RowCount - 1; i <= loopTo1; i++)
                    {
                        element = overAllPos.IndexOf(Convert.ToDouble(dgvMeanMarks.Rows[i].Cells[publicSubsNFunctions.sortby].Value));
                        dgvMeanMarks.Rows[i].Cells["OP"].Value = element + 1;
                        string studGrade = string.Empty;
                        double studPoint;
                        foreach (var x in publicSubsNFunctions.subjectColumns)
                        {
                            if (Information.IsNumeric(dgvMeanMarks.Rows[i].Cells[x].Value))
                            {
                                overallAverage[x] = Conversions.ToInteger(overallAverage[x] + dgvMeanMarks.Rows[i].Cells[x].Value);
                                studGrade = convertMarksToGrade(Conversions.ToShort(dgvMeanMarks.Rows[i].Cells[x].Value), publicSubsNFunctions.gradingType, x);
                                studPoint = convertGradeToPoints(studGrade);
                                averagePoints[x] += studPoint;
                            }
                        }

                        resultsTotal = Conversions.ToInteger(resultsTotal + dgvMeanMarks.Rows[i].Cells["TM"].Value);
                        averageMP = Conversions.ToInteger(averageMP + dgvMeanMarks.Rows[i].Cells["MP"].Value);
                    }


                    // Compute Stream Position
                    for (int s = 0, loopTo2 = classStream.Count - 1; s <= loopTo2; s++)
                    {

                        // get the results for one stream only
                        j = s;
                        streamList = (from all in allResults
                                      where (all.Item1 ?? "") == (classStream[j] ?? "")
                                      orderby all.Item2 descending
                                      select all.Item2).ToList();
                        for (int i = 0, loopTo3 = dgvMeanMarks.RowCount - 1; i <= loopTo3; i++)
                        {

                            // do not loop if stream is not the same
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvMeanMarks.Rows[i].Cells["STR"].Value, classStream[j], false)))
                            {

                                // IndexOf returns -1 when that item does not occur remember its a zero based so add one to the element
                                element = streamList.IndexOf(Convert.ToDouble(dgvMeanMarks.Rows[i].Cells[publicSubsNFunctions.sortby].Value));
                                dgvMeanMarks.Rows[i].Cells["SP"].Value = element + 1;
                            }
                        }
                    }

                    dgvMeanMarks.Sort(dgvMeanMarks.Columns["OP"], System.ComponentModel.ListSortDirection.Ascending);
                    classCount = dgvMeanMarks.Rows.Count - 1;
                    dgvMeanMarks.Rows.AddCopies(dgvMeanMarks.Rows.Count - 1, 4);
                    fillMeanScore();
                    fillDataTable();
                }
            }
        }

        private Dictionary<string, int> overallAverage = new Dictionary<string, int>();
        private Dictionary<string, double> averagePoints = new Dictionary<string, double>();
        private Dictionary<string, int> studentCount = new Dictionary<string, int>();
        private int classCount;
        private int resultsTotal;
        private int averageMP;

        private void getStudentSubjectDone()
        {
            string admno = "(";
            string query = string.Empty;
            for (int k = 0, loopTo = students.Count - 1; k <= loopTo; k++)
                admno += " admno = " + students[k].Item1.ToString() + " or ";
            admno = admno.Remove(admno.Length - 3);
            admno += ");";
            foreach (var s in publicSubsNFunctions.subjectColumns)
            {
                query = "select count(" + s + ") as count from subjects_done where " + s + " = 'Yes' and " + admno;
                if (publicSubsNFunctions.qread(ref query))
                {
                    while (publicSubsNFunctions.dbreader.Read())
                        studentCount.Add(s, Conversions.ToInteger(publicSubsNFunctions.dbreader["count"]));
                }
            }
        }

        private void fillMeanScore()
        {
            var averageScore = new Dictionary<string, string>();
            int scoreCount, gradeCount, pointsCount, markCount, previous;
            double ans;
            string grade = string.Empty;
            scoreCount = dgvMeanMarks.Rows.Count - 4;
            dgvMeanMarks.Rows[scoreCount].Cells["student_name"].Value = "MEAN SCORE";
            foreach (var s in publicSubsNFunctions.subjectColumns)
            {
                ans = Math.Round(overallAverage[s] / (double)studentCount[s], 2, MidpointRounding.AwayFromZero);
                dgvMeanMarks.Rows[scoreCount].Cells[s].Value = ans;
                overallAverage[s] = (int)Math.Round(ans);
            }

            markCount = dgvMeanMarks.Rows.Count - 3;
            dgvMeanMarks.Rows[markCount].Cells["student_name"].Value = "MEAN GRADE (M.MARKS)";
            foreach (var s in publicSubsNFunctions.subjectColumns)
            {
                grade = convertMarksToGrade((short)overallAverage[s], publicSubsNFunctions.gradingType, s);
                dgvMeanMarks.Rows[markCount].Cells[s].Value = grade;
                averageScore.Add(s, grade);
            }

            pointsCount = dgvMeanMarks.Rows.Count - 2;
            dgvMeanMarks.Rows[pointsCount].Cells["student_name"].Value = "MEAN POINTS";
            foreach (var s in publicSubsNFunctions.subjectColumns)
            {
                ans = averagePoints[s] / studentCount[s];
                dgvMeanMarks.Rows[pointsCount].Cells[s].Value = Math.Round(ans, 2, MidpointRounding.AwayFromZero);
                averageScore[s] = ans.ToString();
            }

            ans = Math.Round(averageMP / (double)classCount, 2, MidpointRounding.AwayFromZero);
            dgvMeanMarks.Rows[pointsCount].Cells["MP"].Value = ans;
            dgvMeanMarks.Rows[pointsCount].Cells["MG"].Value = getMeanGrade((short)Math.Round(ans));
            dgvMeanMarks.Rows[pointsCount].Cells["TM"].Value = Math.Round(resultsTotal / (double)classCount, 2, MidpointRounding.AwayFromZero);
            gradeCount = dgvMeanMarks.Rows.Count - 1;
            previous = gradeCount - 1;
            dgvMeanMarks.Rows[gradeCount].Cells["student_name"].Value = "MEAN GRADE (M. POINTS)";
            foreach (var s in publicSubsNFunctions.subjectColumns)
            {
                ans = Conversions.ToDouble(dgvMeanMarks.Rows[previous].Cells[s].Value);
                grade = getMeanGrade(Convert.ToInt16(ans));
                dgvMeanMarks.Rows[gradeCount].Cells[s].Value = grade;
            }
        }

        private void fillDataTable()
        {
            originalData.Rows.Clear();
            DataRow row;
            for (int i = 0, loopTo = dgvMeanMarks.Rows.Count - 1; i <= loopTo; i++)
            {
                row = originalData.NewRow();
                for (int j = 0, loopTo1 = dgvMeanMarks.Columns.Count - 1; j <= loopTo1; j++)
                    row[dgvMeanMarks.Columns[j].Name] = dgvMeanMarks.Rows[i].Cells[j].Value;
                originalData.Rows.Add(row);
            }
        }

        private object getSmallest(int parm1, int parm2)
        {
            int smallest;
            if (parm1 > parm2)
            {
                smallest = parm2;
            }
            else
            {
                smallest = parm1;
            }

            return smallest;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            exportDataToExcel();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            setIndexing();
        }

        private void marksGrade_CheckedChanged(object sender, EventArgs e)
        {
            if (marksGrade.CheckState == CheckState.Checked)
            {
                showMarksAndGrade();
            }
            else
            {
                deleteMarkGrade();
            }
        }

        private DataTable bufferDatatable = new DataTable();

        private void chkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMode.CheckState == CheckState.Checked)
            {
                getB7();
            }
            else
            {
                dgvMeanMarks.DataSource = null;
                dgvMeanMarks.Rows.Clear();
                dgvMeanMarks.Columns.Clear();
                bufferDatatable = originalData.Copy();
                dgvMeanMarks.DataSource = bufferDatatable;
            }
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

        private object print_student_report2()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_report2;
            return print_document;
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
                    e.Graphics.DrawImage(Image.FromFile(logoPath), left_margin + 10, line, 90, 90);
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
            if (start_from < dgvMeanMarks.Rows.Count)
            {
                for (int col = 0, loopTo1 = dgvMeanMarks.Columns.Count - 1; col <= loopTo1; col++)
                {
                    if (dgvMeanMarks.Columns[col].Visible)
                    {
                        if (count == 1)
                        {
                            e.Graphics.DrawString(dgvMeanMarks.Columns[col].HeaderText, publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                        }
                        else
                        {
                            try
                            {
                                e.Graphics.DrawString(dgvMeanMarks.Columns[col].HeaderText.Substring(0, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                            }
                            catch (Exception ex)
                            {
                                e.Graphics.DrawString(dgvMeanMarks.Columns[col].HeaderText, publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
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

            for (int row = start_from, loopTo2 = dgvMeanMarks.Rows.Count - 1; row <= loopTo2; row++)
            {
                line += 2;
                if (row == dgvMeanMarks.Rows.Count - 4)
                {
                    line += 10;
                }

                if (line >= max_height & row < dgvMeanMarks.Rows.Count - 1)
                {
                    count = 0;
                    line += 5;
                    e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line);
                    left_margin = 40;
                    for (int k = 0, loopTo3 = dgvMeanMarks.Columns.Count - 1; k <= loopTo3; k++)
                    {
                        if (dgvMeanMarks.Columns[k].Visible)
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
                for (int col = 0, loopTo4 = dgvMeanMarks.Columns.Count - 1; col <= loopTo4; col++)
                {
                    if (dgvMeanMarks.Columns[col].Visible)
                    {
                        if (dgvMeanMarks.Columns[col].Name == "STR")
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(dgvMeanMarks["STR", row].Value, null, false)))
                            {
                                if (dgvMeanMarks["STR", row].Value.ToString().Length > 3)
                                {
                                    e.Graphics.DrawString(dgvMeanMarks[dgvMeanMarks.Columns[col].Name, row].Value.ToString().Substring(0, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvMeanMarks[dgvMeanMarks.Columns[col].Name, row].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                                }
                            }
                        }
                        else if (dgvMeanMarks.Columns[col].Name == "kcpe")
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(dgvMeanMarks["kcpe", row].Value, null, false)))
                            {
                                if (dgvMeanMarks["kcpe", row].Value.ToString().Length > 3)
                                {
                                    e.Graphics.DrawString(dgvMeanMarks[dgvMeanMarks.Columns[col].Name, row].Value.ToString().Substring(dgvMeanMarks["kcpe", row].Value.ToString().Length - 3, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvMeanMarks[dgvMeanMarks.Columns[col].Name, row].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                                }
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(Conversions.ToString(dgvMeanMarks[dgvMeanMarks.Columns[col].Name, row].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
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
                if (row < dgvMeanMarks.Rows.Count - 4)
                {
                    e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line);
                }

                line += 10;
            }

            if (start_from < dgvMeanMarks.Rows.Count)
            {
                count = 0;
                line += 5;
                e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line);
                left_margin = 40;
                for (int k = 0, loopTo5 = dgvMeanMarks.Columns.Count - 1; k <= loopTo5; k++)
                {
                    if (dgvMeanMarks.Columns[k].Visible)
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
                start_from = dgvMeanMarks.Rows.Count;
                e.HasMorePages = true;
                return;
            }

            line += 20;
            left_margin = 100;
            get_streams(publicSubsNFunctions.class_form);
            if (line + 20 * publicSubsNFunctions.grades.Length + line + publicSubsNFunctions.other_font.Height * (publicSubsNFunctions.streams.Length + 1) > max_height + 60f)
            {
                start_from = dgvMeanMarks.Rows.Count;
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
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvMeanMarks[publicSubsNFunctions.subjname[k].ToString(), dgvMeanMarks.Rows.Count - 1].Value, publicSubsNFunctions.grades[g], false)))
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

        private int start_from = 0;
        private string logoPath;
        private bool mode_view = true;

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

        private int count_grades(string grade, string str)
        {
            int count_gradesRet = default;
            for (int k = 0, loopTo = dgvMeanMarks.Rows.Count - 4; k <= loopTo; k++)
            {
                if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(dgvMeanMarks["MG", k].Value, grade, false), Operators.ConditionalCompareObjectEqual(dgvMeanMarks["STR", k].Value, str, false))))
                {
                    count_gradesRet += 1;
                }
            }

            return count_gradesRet;
        }

        private void btnStreamPerformance_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.class_form = publicSubsNFunctions.selectedClass;
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

        private object print_student_report3()
        {
            var print_document = new PrintDocument();
            print_document.PrintPage += print_report3;
            return print_document;
        }

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
            if (start_from < dgvMeanMarks.Rows.Count)
            {
                for (int col = 0, loopTo1 = dgvMeanMarks.Columns.Count - 1; col <= loopTo1; col++)
                {
                    if (dgvMeanMarks.Columns[col].Visible)
                    {
                        if (count == 1)
                        {
                            e.Graphics.DrawString(dgvMeanMarks.Columns[col].HeaderText, publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                        }
                        else
                        {
                            try
                            {
                                e.Graphics.DrawString(dgvMeanMarks.Columns[col].HeaderText.Substring(0, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
                            }
                            catch (Exception ex)
                            {
                                e.Graphics.DrawString(dgvMeanMarks.Columns[col].HeaderText, publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line);
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

            for (int row = start_from, loopTo2 = dgvMeanMarks.Rows.Count - 1; row <= loopTo2; row++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvMeanMarks["STR", row].Value, publicSubsNFunctions.class_stream, false)))
                {
                    line += 2;
                    if (line >= max_height & row < dgvMeanMarks.Rows.Count - 1)
                    {
                        e.HasMorePages = true;
                        start_from = row;
                        return;
                    }

                    left_margin = 40;
                    count = 0;
                    for (int col = 0, loopTo3 = dgvMeanMarks.Columns.Count - 1; col <= loopTo3; col++)
                    {
                        if (dgvMeanMarks.Columns[col].Visible)
                        {
                            if (dgvMeanMarks.Columns[col].Name == "STR")
                            {
                                if (dgvMeanMarks["STR", row].Value.ToString().Length > 3)
                                {
                                    e.Graphics.DrawString(dgvMeanMarks[dgvMeanMarks.Columns[col].Name, row].Value.ToString().Substring(0, 3), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Conversions.ToString(dgvMeanMarks[dgvMeanMarks.Columns[col].Name, row].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
                                }
                            }
                            else
                            {
                                e.Graphics.DrawString(Conversions.ToString(dgvMeanMarks[dgvMeanMarks.Columns[col].Name, row].Value), publicSubsNFunctions.smallfont, Brushes.Black, left_margin, line + 2);
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
                for (int k = 0, loopTo4 = dgvMeanMarks.Columns.Count - 1; k <= loopTo4; k++)
                {
                    if (dgvMeanMarks.Columns[k].Visible)
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
                start_from = dgvMeanMarks.Rows.Count;
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
            for (int col = 0, loopTo5 = dgvMeanMarks.Columns.Count - 1; col <= loopTo5; col++)
            {
                for (int s = 0, loopTo6 = publicSubsNFunctions.subjabb.Length - 1; s <= loopTo6; s++)
                {
                    int counter = 0;
                    double tm, tp;
                    tm = 0d;
                    tp = 0d;
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgvMeanMarks.Columns[col].Name, publicSubsNFunctions.subjname[s], false)))
                    {
                        for (int row = 0, loopTo7 = dgvMeanMarks.Rows.Count - 1; row <= loopTo7; row++)
                        {
                            if (Conversions.ToBoolean(Operators.AndObject(dgvMeanMarks[publicSubsNFunctions.subjname[s].ToString(), row].Value.ToString() != "-", Operators.ConditionalCompareObjectEqual(dgvMeanMarks["STR", row].Value, publicSubsNFunctions.class_stream, false))))
                            {
                                counter += 1;
                                var marks = dgvMeanMarks[publicSubsNFunctions.subjname[s].ToString(), row].Value.ToString().Split(' ');
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

            if (start_from < dgvMeanMarks.Rows.Count)
            {
                count = 0;
                line += 5;
                e.Graphics.DrawLine(Pens.Black, 40, line, left_margin, line);
                left_margin = 40;
                for (int k = 0, loopTo8 = dgvMeanMarks.Columns.Count - 1; k <= loopTo8; k++)
                {
                    if (dgvMeanMarks.Columns[k].Visible)
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
                start_from = dgvMeanMarks.Rows.Count;
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

        private void Button4_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Are You Sure You Want To Save This Analysis As Examination Performance For This Particular Examination?")))
            {
                save_examination();
            }
        }

        private void save_examination()
        {
            for (int k = 0, loopTo = publicSubsNFunctions.examList.Count - 1; k <= loopTo; k++)
                publicSubsNFunctions.exam_name += publicSubsNFunctions.examList[k].Item1 + "/";
            publicSubsNFunctions.exam_name = publicSubsNFunctions.exam_name.Remove(publicSubsNFunctions.exam_name.Length - 1);
            for (int k = 0, loopTo1 = dgvMeanMarks.Rows.Count - 5; k <= loopTo1; k++)
            {
                string test = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM examination_performance WHERE (ADMNo='", dgvMeanMarks["admno", k].Value), "' AND exam='"), publicSubsNFunctions.exam_name), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "')"));
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM examination_performance WHERE (ADMNo='", dgvMeanMarks["admno", k].Value), "' AND exam='"), publicSubsNFunctions.exam_name), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "')"));
                publicSubsNFunctions.qread(ref argq);
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("UPDATE examination_performance SET pos='", dgvMeanMarks["OP", k].Value), "/"), dgvMeanMarks.Rows.Count - 4), "' WHERE (ADMNo='"), dgvMeanMarks["admno", k].Value), "' AND exam='"), publicSubsNFunctions.exam_name), "' AND term='"), publicSubsNFunctions.tm), "' AND year='"), publicSubsNFunctions.yr), "')")));
                }
                else
                {
                    publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO examination_performance VALUES(NULL, '", dgvMeanMarks["admno", k].Value), "', '"), publicSubsNFunctions.exam_name), "', '"), publicSubsNFunctions.tm), "','"), publicSubsNFunctions.yr), "','"), dgvMeanMarks["OP", k].Value), "/"), dgvMeanMarks.Rows.Count - 4), "')")));
                }
            }

            publicSubsNFunctions.success("Examination Performance Saved!");
        }
    }
}