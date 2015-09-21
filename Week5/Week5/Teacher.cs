using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5
{
    class Teacher
    {
        
        private string firstName;
        private string lastName;
        private string birthDate;
        private string adress;
        private int age;
        private string major;

        public Teacher(string firstName, string lastName, string major,int Age)
        {
            this.FirstName = firstName;
            this.lastName = lastName;
            this.Age = Age;
        }


        public int Age
        {
            get { return age; }
            set { age = value; }
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
        public string Major
        {
            get { return major; }
            set { major = value; }
        }

        public bool GradeTest()
        {
            return true;
        }
    }
}
