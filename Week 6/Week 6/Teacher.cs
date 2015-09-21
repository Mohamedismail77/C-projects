using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7
{
    class Teacher : Person
    {
        private string major;

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
