using System;
using System.Collections.Generic;
using System.Text;

namespace L1.LabTwo
{
    public class Exam : IDateAndCopy
    {
        public Exam()
        {
            SubjectName = "Physics";
            Date = new DateTime(2019, 10, 10);
            Mark = 90;
        }

        public int Mark { get; set; }

        public string SubjectName { get; set; }

        public DateTime Date { get; set; }

        public object DeepCopy()
        {
            var examCopy = new Exam();
            examCopy.Date = new DateTime(Date.Year, Date.Month, Date.Day);
            examCopy.SubjectName = String.Copy(SubjectName);
            examCopy.Mark = Mark;
            return examCopy;
        }
    }
}
