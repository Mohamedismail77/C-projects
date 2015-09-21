using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5
{
    class Student
    {
        private string firstName;
        private string lastName;
        private string birthDate;
        private string adress;
        private string classNumber;
        private string grade;


        public Student(string firstName, string lastName, string birthDate)
        {
            this.FirstName = firstName;
            this.lastName = lastName;
            this.BirthDate = birthDate;
        }
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        public string ClassNumber
        {
            get { return classNumber; }
            set { classNumber = value; }
        }

        public bool TakeTest()
        {
            return true;
        }
    }
}
