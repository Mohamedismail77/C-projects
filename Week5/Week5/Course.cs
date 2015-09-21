using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5
{
    class Course
    {
        private string courseName;

        private int hoursPerWeek;
        private Student[] student;
        private Teacher teacher;

        public Course(string courseName, Student[] student, Teacher teacher)
        {
            this.Student = student;
            this.Teacher = teacher;
            this.CourseName = courseName;
        }
        internal Student[] Student
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

    }
}
