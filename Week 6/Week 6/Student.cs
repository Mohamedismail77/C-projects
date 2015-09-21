using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7
{
    class Student : Person
    {
        private string classNumber;
        private int number;


        private Stack<string> grades;

        
        public Student(string fName,string lName, string bDate,string cNum,int Number)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.BirthDate = bDate;
            this.ClassNumber = cNum;
            this.Number = Number;
            
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public string ClassNumber
        {
            get { return classNumber; }
            set { classNumber = value; }
        }

        public Stack<string> Grades
        {
            get { return grades; }
            set { grades = value; }
        }
        public bool TakeTest()
        {
            return true;
        }
    }
}
