using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new ThrowAwayGradeBook();

            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Average", stats.AverageGrade);
            WriteResult("HighestGrade", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
            WriteResult("Description", stats.Description);
        }

        private static void SaveGrades(GradeBook book)
        {
            using (StreamWriter outPutFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outPutFile);
            }
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter a name: ");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void WriteResult(string descripion, string result)
        {
            Console.WriteLine($"{descripion}  {result}");
        }
        static void WriteResult(string descripion, float result)
        {
            Console.WriteLine(descripion + "(float): " + result);
        }
    }
}
