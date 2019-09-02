using L1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L1.TicketOne
{
    public class Student
    {
        private Person _person;
        private Education _education;
        private int _group;
        private Exam[] _exams;

        public Student()
        {
            _person = new Person();
            _education = Education.Bachelor;
            _group = 101;
        }

        public Student(Person person, Education education, int group)
        {
            _person = person;
            _education = education;
            _group = group;
        }

        public Person Person
        {
            get { return _person; }
            set { _person = value; }
        }
        public Education Education
        {
            get { return _education; }
            set { _education = value; }
        }
        public int Group
        {
            get { return _group; }
            set { _group = value; }
        }
        public Exam[] Exams
        {
            get { return _exams; }
            set { _exams = value; }
        }

        public double Average
        {
            get
            {
                int sum = 0;
                if (_exams != null)
                {
                    foreach (var exam in _exams)
                    {
                        sum += exam.Mark;
                    }
                    return sum / _exams.Length;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool this[Education education]
        {
            get
            {
                return (_education == education);
            }
        }

        public void AddExams(Exam[] exams)
        {
            Exams = Exams.Concat(exams).ToArray();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (_exams != null)
            {
                foreach (var exam in _exams)
                {
                    stringBuilder.Append($"{exam.SubjectName}, {exam.ExamDate}, {exam.Mark} ; ");
                }
            }

            return $"{_person.ToString()}, {_group.ToString()}, {_education.ToString()}, exams: [ {stringBuilder} ]";
        }

        public virtual string ToShortString()
        {
            return $"{_person.ToString()}, {_group.ToString()}, {_education.ToString()}, {Average.ToString()}";
        }

        public Student DeepCopy()
        {
            var studentCopy = new Student();
            studentCopy.Group = Group;
            studentCopy.Person = new Person();
            studentCopy.Person.BirthYear = Person.BirthYear;
            studentCopy.Person.FirstName = String.Copy(Person.FirstName);
            studentCopy.Person.LastName = String.Copy(Person.LastName);
            studentCopy.Exams = new Exam[Exams.Length];
            for (var i = 0; i < Exams.Length; i++)
            {
                studentCopy.Exams[i] = Exams[i].DeepCopy();
            }
            return studentCopy;
        }
    }
}
