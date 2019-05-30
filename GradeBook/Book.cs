using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
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
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {   //This will throw an ArgumentException, that should be caught by try/catch in AddGrade
                throw new ArgumentException($"Invalid {nameof(grade)}");

            }
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            var index = 0;
            //Loop that adds all numbers in the arra of grades, and then divides to get average
            while(index < grades.Count)
            {
                //Uses the Math.Max operator to find the highest value between (number, and
                //the variable highGrade)
                result.Add(grades[index]);
                index += 1;
            }

            return result;
        }

        private List<double> grades;

        private string name;
    }
}
