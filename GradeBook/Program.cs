using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        //"static" makes the "main" method point to the CLASS Program
        //avoid using static unless it is in a very specific circumstance
        static void Main(string[] args)
        {
            //Making a new 
            var book = new Book("John's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            var stats = book.GetStatistics();

            //Writes the Average grade to the console formated to one decimal
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"the lowest grade is {stats.Low:N1}");



            ////Makes a list of all the grades
            //var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            //grades.Add(56.1);

        }
    }
}
