using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("ThrowAwayGradeBook::ComputeStatistics()");
            float lowestGrade = float.MaxValue;
            foreach (var grade in grades)
            {
                lowestGrade = Math.Min(lowestGrade, grade);
            }
            // TODO: handle different cases.
            grades.Remove(lowestGrade);
            return base.ComputeStatistics();
        }
    }
}
