using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
     public class Book
    {
        public Book(string name)
        {
            //Initilizing grades
            grades = new List<double>();
            Name = name;
        }
        // Initilizing AddGrade
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            

            //double.MinValue sets the var to the lowest possible number you can enter in a double
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Average = 0.0;

            //Loop that adds all numbers in the arra of grades, and then divides to get average
            foreach (double grade in grades)
            {
                //Uses the Math.Max operator to find the highest value between (number, and
                //the variable highGrade)
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
            result.Average = result.Average /= grades.Count;

            return result;
        }

        private List<double> grades;
        public string Name;

        
    }
}
