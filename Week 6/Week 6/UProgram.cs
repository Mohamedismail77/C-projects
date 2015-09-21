using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7
{
    class UProgram
    {
        private Degree degree;
        private string programName;

        public UProgram(string programname, Degree degree)
        {
            this.Degree = degree;
            this.ProgramName = programname;
        }

        internal Degree Degree
        {
            get { return degree; }
            set { degree = value; }
        }
        public string ProgramName
        {
            get { return programName; }
            set { programName = value; }
        }
    }
}
