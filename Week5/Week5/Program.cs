using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[3];
            students[0] = new Student("mohamed", "ismail", "21/3/1994");
            students[1] = new Student("Ali", "kamel", "17/11/1989");
            students[2] = new Student("aya", "ali", "5/1/1990");
            Teacher teacher1 = new Teacher("said", "alaa", "computer science", 41);
            Course course1 = new Course(" Programming with C#", students, teacher1);
            Degree degree = new Degree("Bachelor", course1);
            UProgram universityProgram = new UProgram("Information Technology", degree);
            Console.WriteLine("The {0} program contains the {1} of Science degree \n", universityProgram.ProgramName, universityProgram.Degree.Degree1);
            Console.WriteLine("The {0} of Science degree contains the course {1} \n", universityProgram.Degree.Degree1, universityProgram.Degree.Course.CourseName);
            Console.WriteLine("The {0} course contains {1} students \n", universityProgram.Degree.Course.CourseName, universityProgram.Degree.Course.Student.Length);

        }
    }
}
