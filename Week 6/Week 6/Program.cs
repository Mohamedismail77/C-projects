using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> Students = new List<Student>();
            Student Student_1 = new Student("Mohamed", "Ismail", "21/3/1994", "A1", 1);
            Student Student_2 = new Student("Mohamed", "Ali", "2/5/1992", "A1", 2);
            Student Student_3 = new Student("Mohamed", "Abd Allah", "1/7/1993", "A1", 3);
            Student_1.Grades = new Stack<string>();
            Student_2.Grades = new Stack<string>();
            Student_3.Grades = new Stack<string>();

            Student_1.Grades.Push("A");
            Student_1.Grades.Push("A");
            Student_1.Grades.Push("B");
            Student_1.Grades.Push("B");
            Student_1.Grades.Push("C");
            Student_2.Grades.Push("A");
            Student_2.Grades.Push("B");
            Student_2.Grades.Push("B");
            Student_2.Grades.Push("C");
            Student_2.Grades.Push("C");
            Student_3.Grades.Push("A");
            Student_3.Grades.Push("A");
            Student_3.Grades.Push("B");
            Student_3.Grades.Push("B");
            Student_3.Grades.Push("B");

            Students.Add(Student_1);
            Students.Add(Student_2);
            Students.Add(Student_3);

            foreach(Student student in Students)
            {
                Console.WriteLine("Student_{0} Name: {1} {2}",student.Number,student.FirstName,student.LastName);
            }
            Console.WriteLine();

            Teacher teacher = new Teacher();
            teacher.FirstName = "Alaa";
            teacher.LastName = "Ali";
            teacher.BirthDate = "1/5/1864";
            teacher.Major = "Computer Science";

            Course course1 = new Course(" Programming with C#", Students, teacher);

            course1.ListStudents(Students);

            Console.ReadLine();
            

        }
    }
}

/*


            Course course1 = new Course(" Programming with C#", Students, teacher);
            Degree degree = new Degree("Bachelor", course1);
            UProgram universityProgram = new UProgram("Information Technology", degree);
            Console.WriteLine("The {0} program contains the {1} of Science degree \n", universityProgram.ProgramName, universityProgram.Degree.Degree1);
            Console.WriteLine("The {0} of Science degree contains the course {1} \n", universityProgram.Degree.Degree1, universityProgram.Degree.Course.CourseName);
            Console.WriteLine("The {0} course contains {1} students \n", universityProgram.Degree.Course.CourseName, universityProgram.Degree.Course.Student.Count);

            Console.WriteLine("First student pass test: {0} \n", ((Student)Students[0]).TakeTest());
            Console.WriteLine("Teacher grade test: {0} \n", teacher.GradeTest());
 * 
*/