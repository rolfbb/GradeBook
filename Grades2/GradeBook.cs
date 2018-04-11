using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        List<float> grades;
        private string _name;

        public NameChangedDelegate NameChanged;

        public GradeBook()
        {
            grades = new List<float>();
            _name = "Empty";
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Throwing ArgumentException...");
                    throw new ArgumentException("Name cannot be null or empty!");
                }

                if (Name != value && NameChanged != null)
                {
                    NameChanged(_name, value);
                }
                _name = value;
            }
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);

                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count; //todo: error handling

            return stats;
        }

        public void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine("jhepp " + grades[i]);
            }
            // Reversed.
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

    }
}
