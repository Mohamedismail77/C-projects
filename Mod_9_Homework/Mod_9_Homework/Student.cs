using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_9_Homework
{
    class Student
    {
        private string firstName;
        private string lastName;
        private string city;

        


        public Student(string firstName, string lastName, string city)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.City = city;
        }


        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }



    }
}
