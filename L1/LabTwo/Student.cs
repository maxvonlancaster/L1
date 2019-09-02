using L1.TicketOne;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace L1.LabTwo
{
    public class Student : Person
    {
        private Education _education;
        private int _group;
        private ArrayList _exams;
        private ArrayList _tests;

        public Student() : base()
        {
            _group = 101;
            _education = Education.Bachelor;
            _exams = new ArrayList();
            _tests = new ArrayList();
        }

        public Student(Person person, Education education, int group)
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
            Date = person.Date;
            _education = education;
            _group = group;
        }

        public Education Education { get => _education; set => _education = value; }
        public int Group
        {
            get => _group;
            set
            {
                if (100 < value && value < 699)
                {
                    _group = value;
                }
                else
                {
                    throw new Exception("Value should be between 100 and 699;");
                }
            }
        }
        public ArrayList Exams { get => _exams; set => _exams = value; }
        public ArrayList Tests { get => _tests; set => _tests = value; }

        public Person Person
        {
            get
            {
                var person = new Person(FirstName, LastName, Date);
                return person;
            }
            set
            {
                FirstName = value.FirstName;
                LastName = value.LastName;
                Date = value.Date;
            }
        }

        public double Average
        {
            get
            {
                int sum = 0;
                if (_exams != null)
                {
                    foreach (Exam exam in _exams)
                    {
                        sum += exam.Mark;
                    }
                    return sum / _exams.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void AddExams(ArrayList exams)
        {
            Exams.AddRange(exams);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (_exams != null)
            {
                foreach (Exam exam in _exams)
                {
                    stringBuilder.Append($"{exam.SubjectName}, {exam.Date}, {exam.Mark} ; ");
                }
            }
            if (_tests != null)
            {
                foreach (Test test in _tests)
                {
                    stringBuilder.Append($"{test.SubjectName}, {test.Passed.ToString()} ; ");
                }
            }
            return $"{base.ToString()}, {_education.ToString()}, {_group.ToString()}, exams/tests : [{stringBuilder}]";
        }

        public override string ToShortString()
        {
            return $"{base.ToShortString()}, {_education.ToString()}, {_group.ToString()}, {Average.ToString()}";
        }

        public override object DeepCopy()
        {
            var personCopy = (Person)base.DeepCopy();
            var studentCopy = new Student();
            studentCopy.LastName = personCopy.LastName;
            studentCopy.FirstName = personCopy.FirstName;
            studentCopy.Date = personCopy.Date;
            studentCopy.Group = Group;
            studentCopy.Education = Education;
            foreach (Exam exam in Exams)
            {
                studentCopy.Exams.Add(exam.DeepCopy());
            }
            foreach (Test test in Tests)
            {
                studentCopy.Tests.Add(test.DeepCopy());
            }
            return studentCopy;
        }

        public IEnumerator GetEnumerator()
        {
            var totalArray = new ArrayList();
            totalArray.AddRange(Exams);
            totalArray.AddRange(Tests);
            for (int i = 0; i < totalArray.Count; i++)
            {
                yield return totalArray[i];
            }
        }

        public IEnumerator<Exam> GetEnumeratorExams()
        {
            for (int i = 0; i < Exams.Count; i++)
            {
                yield return (Exam)Exams[i];
            }
        }

        public StudentEnumerator GetEnumeratorCustom()
        {
            var exams = new ArrayList();
            for (int i = 0; i < Exams.Count; i++)
            {
                for (int j = 0; j < Tests.Count; j++)
                {
                    if (Exams[i] == Tests[j])
                    {
                        exams.Add(Exams[i]);
                    }
                }
            }
            return new StudentEnumerator(exams);
        }
    }
}
