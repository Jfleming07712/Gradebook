﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        //"static" makes the "main" method point to the CLASS Program
        //avoid using static unless it is in a very specific circumstance
        static void Main(string[] args)
        {
            //Making a new object
            IBook book = new DiskBook("John's Grade Book");
            // allows for users to add multiple grades using a looping statement
            EnterGrades(book);

            var stats = book.GetStatistics();

            //Writes the Book Name and Average,High, and Low grade to the console formated to one decimal
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine($"Please enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                // Catching exeption created by the AddGrade methode
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // finally will execute if the try succeeds, as well as after the catch runs
                finally
                {
                    Console.WriteLine("");
                }
            }
        }
    }
}
