using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name) 
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int students = Students.Count;
            List<double> avgGrades = new List<double>();

            foreach (var student in Students) 
            {
                avgGrades.Add(student.AverageGrade);
            }

            int grades = Convert.ToInt32(avgGrades.Count * 0.2);
            avgGrades.Sort(); avgGrades.Reverse();
            double[] avgGradesArray = avgGrades.ToArray();

            if (students < 5)
                throw new InvalidOperationException();
            else if (averageGrade >= avgGradesArray [grades - 1] && averageGrade <= avgGradesArray[0])
                return 'A';
            else if (averageGrade >= avgGradesArray [2 * grades - 1] && averageGrade <= avgGradesArray[grades])
                return 'B';
            else if (averageGrade >= avgGradesArray [3 * grades - 1] && averageGrade <= avgGradesArray[2 * grades])
                return 'C';
            else if (averageGrade >= avgGradesArray [4 * grades - 1] && averageGrade <= avgGradesArray[3 * grades])
                return 'D';
            else
                return 'F';
        }
    }
}
