using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7
{
    class Course
    {
        private string courseName;

        private int hoursPerWeek;
        private List<Student> student;
        private Teacher teacher;

        public Course(string courseName, List<Student> student, Teacher teacher)
        {
            this.Student = student;
            this.Teacher = teacher;
            this.CourseName = courseName;
        }
        internal List<Student> Student
        {
            get { return student; }
            set { student = value; }
        }
        internal Teacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public void  ListStudents(List<Student> Students)
        {
            foreach (object student in Students)
            {

                Console.WriteLine("Student_{0} Name: {1} {2}", ((Student)student).Number, ((Student)student).FirstName, ((Student)student).LastName);
            }
        }
    }
}
