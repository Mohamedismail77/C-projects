using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7
{
    class Degree
    {
        private Course course;
        private string degree;

        public Degree(string degree, Course course)
        {
            this.Course = course;
            this.Degree1 = degree;
        }

        internal Course Course
        {
            get { return course; }
            set { course = value; }
        }
        public string Degree1
        {
            get { return degree; }
            set { degree = value; }
        }
    }
}
