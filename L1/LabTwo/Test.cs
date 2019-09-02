using System;
using System.Collections.Generic;
using System.Text;

namespace L1.LabTwo
{
    public class Test : IDateAndCopy
    {
        public Test()
        {
            SubjectName = "Maths ";
            Passed = true;
        }

        public Test(string subjectName, bool passed)
        {
            SubjectName = subjectName;
            Passed = passed;
        }

        public string SubjectName { get; set; }
        public bool Passed { get; set; }
        public DateTime Date { get; set; }

        public object DeepCopy()
        {
            var testCopy = new Test();
            testCopy.SubjectName = String.Copy(SubjectName);
            testCopy.Passed = Passed;
            testCopy.Date = new DateTime(Date.Year, Date.Month, Date.Day);
            return testCopy;
        }

        public override string ToString()
        {
            return $"{SubjectName}, {Passed.ToString()}";
        }
    }
}
