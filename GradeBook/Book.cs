﻿using System;
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

        public void AddLetterGrade(char letter)
        {
          switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        // Initilizing AddGrade
        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
        }
        public Statistics GetStatistics()
        {
            var result = new Statistics();

                //double.MinValue sets the var to the lowest possible number you can enter in a double
                result.High = double.MinValue;
                result.Low = double.MaxValue;
                result.Average = 0.0;

            var index = 0;
            //Loop that adds all numbers in the arra of grades, and then divides to get average
            while(index < grades.Count)
            {
                //Uses the Math.Max operator to find the highest value between (number, and
                //the variable highGrade)
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
                index += 1;
            }


            result.Average = result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        private List<double> grades;
        public string Name;

        
    }
}
