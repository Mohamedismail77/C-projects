using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7
{
    class Person
    {
        private string firstName;
        private string lastName;
        private string birthDate;
        private string adress;

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
    }
}
