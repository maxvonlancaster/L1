using L1.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using L1.TicketOne;
using System.Collections;

namespace L1
{
    class Program
    {
        private static Features _features;
        private static int nRows;
        private static int nColumns;

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter separation symbols:");
            var separationSymbols = Console.ReadLine();
            Console.WriteLine("Please enter nRows and nColumns:");
            var rowsColumns = Console.ReadLine();
            var arrRowsColumns = new String[2];

            foreach (var symbol in separationSymbols)
            {
                if (rowsColumns.Contains(symbol))
                {
                    arrRowsColumns = rowsColumns.Split(symbol);
                }
            }

            string rows = arrRowsColumns[0];
            string columns = arrRowsColumns[1];

            int.TryParse(rows, out nRows);
            int.TryParse(columns, out nColumns);


            LoadConfiguration();
            switch (_features.Variant)
            {
                case "1":
                    MainOne();
                    MainOneLabTwo();
                    break;
                case "2":
                    MainTwo();
                    break;
                case "3":
                    MainThree();
                    break;
                default:
                    MainOne();
                    break;
            }
        }

        public static void LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true,
                             reloadOnChange: true);
            IConfiguration config = builder.Build();
            _features = new Features();
            config.GetSection("Features").Bind(_features);
        }

        static void MainOne()
        {
            var student = new Student();

            Console.WriteLine(student.ToShortString());

            Console.WriteLine(student[Education.Bachelor].ToString());
            Console.WriteLine(student[Education.Master].ToString());
            Console.WriteLine(student[Education.SecondaryEducation].ToString());

            student.Group = 102;
            student.Exams = new Exam[] { new Exam(), new Exam(), new Exam() };
            Console.WriteLine(student.ToString());

            student.AddExams(new Exam[] { new Exam(), new Exam("Data Science", 90, new DateTime(2019, 10, 20)) });
            Console.WriteLine(student.ToString());

            int startOneDim = Environment.TickCount;
            var arrayOneDim = new Exam[nRows * nColumns];
            for (var i = 0; i < nRows * nColumns; i++)
            {
                arrayOneDim[i] = new Exam();
                arrayOneDim[i].Mark = 91;
            }
            int endOneDim = Environment.TickCount;
            int diffOneDim = endOneDim - startOneDim;



            int startTwoDimRect = Environment.TickCount;
            var arrayTwoDimRect = new Exam[nRows, nColumns];
            for (var i = 0; i < nRows; i++)
            {
                for (var j = 0; j < nColumns; j++)
                {
                    arrayTwoDimRect[i, j] = new Exam();
                    arrayTwoDimRect[i, j].Mark = 91;
                }
            }
            int endTwoDimRect = Environment.TickCount;
            int diffTwoDimRect = endTwoDimRect - startTwoDimRect;



            int startTwoDim = Environment.TickCount;
            var arrayTwoDim = new Exam[3][]
            {
                new Exam[2],
                new Exam[1],
                new Exam[nRows * nColumns - 3]
            };
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < arrayTwoDim[i].Length; j++)
                {
                    arrayTwoDim[i][j] = new Exam();
                    arrayTwoDim[i][j].Mark = 91;
                }
            }
            int endTwoDim = Environment.TickCount;
            int diffTwoDim = endTwoDim - startTwoDim;
            Tuple<int, int, int> tuple = new Tuple<int, int, int>(diffOneDim, diffTwoDimRect, diffTwoDim);
        }

        static void MainOneLabTwo()
        {
            Console.WriteLine("\n\nLAB TWO:");
            var firstName = "Homer";
            var lastName = "Simpson";
            var dateOfBirth = new DateTime(1998, 5, 5);
            var personOne = new L1.LabTwo.Person(firstName, lastName, dateOfBirth);
            var personTwo = new L1.LabTwo.Person(firstName, lastName, dateOfBirth);
            var isReferenceSame = object.ReferenceEquals(personOne.FirstName, personTwo.FirstName);

            var student = new L1.LabTwo.Student();
            student.AddExams(new ArrayList() { new L1.LabTwo.Exam(), new L1.LabTwo.Exam() });
            student.Tests.Add(new L1.LabTwo.Test());
            Console.WriteLine(student.ToString());

            Console.WriteLine(student.Person.ToString());

            var studCopy = (L1.LabTwo.Student)student.DeepCopy();
            studCopy.FirstName = "Jonathan";
            Console.WriteLine(student.Person.ToString());

            try
            {
                studCopy.Group = 800;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var e in studCopy)
            {
                if (e is L1.LabTwo.Exam)
                {
                    var ex = (L1.LabTwo.Exam)e;
                    if (ex.Mark > 3)
                    {
                        Console.WriteLine(ex.SubjectName);
                    }
                }
            }

            foreach (var e in studCopy.GetEnumeratorCustom())
            {
                Console.WriteLine(e.ToString());
            }

        }


        static void MainTwo()
        {
            int start = Environment.TickCount;


            int end = Environment.TickCount;
            int diff = end - start;
        }

        static void MainThree()
        {
            int start = Environment.TickCount;


            int end = Environment.TickCount;
            int diff = end - start;
        }
    }
}
