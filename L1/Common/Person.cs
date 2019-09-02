using System;
using System.Collections.Generic;
using System.Text;

namespace L1.Common
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public int BirthYear
        {
            get { return _birthDate.Year; }
            set { _birthDate.AddYears(value - _birthDate.Year); }
        }

        public Person()
        {
            _firstName = "John";
            _lastName = "Doe";
            _birthDate = new DateTime(2000, 10, 10);
        }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            _firstName = firstName;
            _lastName = lastName;
            _birthDate = birthDate;
        }

        public override string ToString()
        {
            return $"{FirstName}, {LastName}, {BirthYear.ToString()}";
        }

        public virtual string ToShortString()
        {
            return $"{FirstName}, {LastName}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                var person = (Person)obj;
                return person.FirstName.Equals(FirstName) &&
                    person.LastName.Equals(LastName) &&
                    person.BirthYear.Equals(BirthYear);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, BirthYear);
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.FirstName.Equals(person2.FirstName) &&
                person1.LastName.Equals(person2.LastName) &&
                person1.BirthYear.Equals(person2.BirthYear);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.FirstName.Equals(person2.FirstName) &&
                !person1.LastName.Equals(person2.LastName) &&
                !person1.BirthYear.Equals(person2.BirthYear);
        }

    }
}
