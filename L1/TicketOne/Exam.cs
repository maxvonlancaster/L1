using System;
using System.Collections.Generic;
using System.Text;

namespace L1.TicketOne
{
    public class Exam
    {
        public Exam()
        {
            SubjectName = "Mathematics";
            Mark = 100;
            ExamDate = new DateTime(2019, 10, 10);
        }

        public Exam(string subjectName, int mark, DateTime examDate)
        {
            SubjectName = subjectName;
            Mark = mark;
            ExamDate = examDate;
        }

        public string SubjectName { get; set; }
        public int Mark { get; set; }
        public DateTime ExamDate { get; set; }

        public override string ToString()
        {
            return $"{SubjectName}, {Mark.ToString()}, {ExamDate.ToString()}";
        }

        public Exam DeepCopy()
        {
            var examCopy = new Exam();
            examCopy.SubjectName = String.Copy(SubjectName);
            examCopy.Mark = Mark;
            examCopy.ExamDate = new DateTime(ExamDate.Year, ExamDate.Month, ExamDate.Day);
            return examCopy;
        }
    }
}
