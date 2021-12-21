using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    static class ExamFunctions
    {
        private static void copyValues(Dictionary<string, List<Tuple<string, short>>> grades)
        {
            publicSubsNFunctions.subjectGrading2.Clear();
            publicSubsNFunctions.subjectGrading2 = grades;
        }

        public static bool getGradingScheme()
        {
            bool schemeAvailable = false;
            string query = string.Empty;
            var gradess = new[] { "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "E" };
            var gradeValues = new List<Tuple<string, short>>();
            var saveGradeValue = new List<Tuple<string, short>>();
            if (string.IsNullOrEmpty(publicSubsNFunctions.gradingType))
            {
                publicSubsNFunctions.gradingType = string.Empty;
            }

            if (publicSubsNFunctions.gradingType == "SubjectBased")
            {
                publicSubsNFunctions.subjectGrading.Clear();
                foreach (string s in publicSubsNFunctions.schoolSubjects)
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
                                // test(s, gradeValues)
                                publicSubsNFunctions.subjectGrading.Add(s, gradeValues);
                                gradeValues.Clear();
                            }
                        }
                    }
                }
            }
            else
            {
                publicSubsNFunctions.classGrading.Clear();
                query = "SELECT * FROM grading WHERE (Class='" + publicSubsNFunctions.selectedClass + "' AND term='" + publicSubsNFunctions.selectedTerm + "' AND year='" + publicSubsNFunctions.selectedYear + "');";
                if (publicSubsNFunctions.qread(ref query, 1))
                {
                    if (publicSubsNFunctions.dbreader1.RecordsAffected > 0)
                    {
                        schemeAvailable = true;
                        while (publicSubsNFunctions.dbreader1.Read())
                        {
                            foreach (string g in gradess)
                                publicSubsNFunctions.classGrading.Add(new Tuple<string, short>(g, Conversions.ToShort(publicSubsNFunctions.dbreader1[g])));
                        }
                    }
                }
            }

            return schemeAvailable;
        }

        public static void initialzeGradePoints()
        {
            publicSubsNFunctions.GradeToPoint.Clear();
            publicSubsNFunctions.GradeToPoint.Add("A", 12);
            publicSubsNFunctions.GradeToPoint.Add("A-", 11);
            publicSubsNFunctions.GradeToPoint.Add("B+", 10);
            publicSubsNFunctions.GradeToPoint.Add("B", 9);
            publicSubsNFunctions.GradeToPoint.Add("B-", 8);
            publicSubsNFunctions.GradeToPoint.Add("C+", 7);
            publicSubsNFunctions.GradeToPoint.Add("C", 6);
            publicSubsNFunctions.GradeToPoint.Add("C-", 5);
            publicSubsNFunctions.GradeToPoint.Add("D+", 4);
            publicSubsNFunctions.GradeToPoint.Add("D", 3);
            publicSubsNFunctions.GradeToPoint.Add("D-", 2);
            publicSubsNFunctions.GradeToPoint.Add("E", 1);
            publicSubsNFunctions.GradeToPoint.Add("Y", 0);
            publicSubsNFunctions.GradeToPoint.Add("X", 0);
        }

        public static string convertMarksToGrade(short marks, string gradingType, string subjectParm = "")
        {
            string studGrade = string.Empty;
            if (marks == 0)
            {
                studGrade = "Y";
            }
            else if (gradingType == "SubjectBased")
            {
                // Dim subjectGrading As New Dictionary(Of String, List(Of Tuple(Of String, Int16)))

                var subjGrade = new List<Tuple<string, short>>();
                foreach (var pair in publicSubsNFunctions.subjectGrading)
                {
                    if ((pair.Key ?? "") == (subjectParm ?? ""))
                    {
                        subjGrade = pair.Value;
                    }
                }

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
            else if (marks < publicSubsNFunctions.classGrading[publicSubsNFunctions.classGrading.Count - 1].Item2)
            {
                studGrade = "E";
            }
            else
            {
                for (int i = 0, loopTo = publicSubsNFunctions.classGrading.Count - 1; i <= loopTo; i++)
                {
                    if (marks >= publicSubsNFunctions.classGrading[i].Item2)
                    {
                        studGrade = publicSubsNFunctions.classGrading[i].Item1;
                        break;
                    }
                }
            }

            return studGrade;
        }

        public static short convertGradeToPoints(string grade)
        {
            short points;
            points = publicSubsNFunctions.GradeToPoint[grade];
            return points;
        }
    }
}