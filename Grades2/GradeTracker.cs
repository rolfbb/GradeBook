using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        protected string _name;

        public NameChangedDelegate NameChanged;

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


    }
}
