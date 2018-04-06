using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("hello, this is the grade book program.");

            GradeBook book = new GradeBook();

            book.NameChanged = new NameChangedDelegate(OnNameChanged);

            book.Name = "Rolfs book";
            book.Name = null;

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("HighestGrade", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }

        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Grade book changing name from {existingName} to {newName}");
        }

        static void WriteResult(string descripion, int result)
        {
            Console.WriteLine(descripion + "(int): " + result);
        }

        static void WriteResult(string descripion, float result)
        {
            Console.WriteLine(descripion + "(float): " + result);
        }
    }
}
