using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject
{
    internal class Service
    {
        public static void CreateDepartmentAddStudentsAddLectures()
        {
            Console.Clear();
            using var db = new AppDbContext();
            Console.WriteLine("You are creating a department and adding students/lectures");
            Console.WriteLine("Enter department name");
            var department = new Departments(Console.ReadLine());
            Console.WriteLine("How many students will this department have?");
            int HmStudents = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < HmStudents; i++)
            {
                Console.Clear();
                Console.WriteLine("Enter student(s) name");
                department.Student.Add(new Students(Console.ReadLine()));
            }
            Console.Clear();
            Console.WriteLine("How many lectures will this department have?");
            int HmLectures = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= HmLectures; i++)
            {
                Console.Clear();
                Console.WriteLine("Enter lecture(s) name");
                department.Lecture.Add(new Lectures(Console.ReadLine()));
            }
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public static void AddLectureToDepartment()
        {
            using var db = new AppDbContext();
            Console.Clear();
            Console.WriteLine("Enter lecture name");
            string LectureNameNew = Console.ReadLine();
            var lecture = new Lectures(LectureNameNew);

            Console.Write("Enter a name from already existing ones or create a new one.");
            Console.Write("Already existing departments: ");
            foreach (Departments department1 in db.Departments)
            {
                Console.Write($"{department1.Name} ");
            }
            Console.Clear();
            Console.WriteLine("\nwhere to add");
            string departmentName = Console.ReadLine();

            Byte[] Bt = new Byte[16];
            Guid lecId = new Guid(Bt);
            Guid depId = new Guid(Bt);
            string depName;

            foreach (Departments department in db.Departments)
            {
                if (departmentName == department.Name)
                {
                    depId = department.Id;
                    depName = department.Name;
                    Console.WriteLine($"{department.Id} {department.Name}");
                }
            }
            if (depId == Guid.Empty)
            {
                Console.WriteLine("Department does not exist");
                var department = new Departments(departmentName);
                department.Lecture.Add(lecture);
                db.Departments.Add(department);
                db.SaveChanges();
            }
            else
            {
                Console.Clear();
                var department = new Departments(departmentName);
                lecture.DepartmentId = depId;
                db.Lectures.Add(lecture);
                db.SaveChanges();
            }
        }
        public static void AddStudentToDepartment()
        {
            Console.Clear();
            using var db = new AppDbContext();
            Console.WriteLine("Enter student name");

            string StudentNameNew = Console.ReadLine();
            var student = new Students(StudentNameNew);

            Console.Write("How many students you want to add? ");
            foreach (Departments department1 in db.Departments)
            {
                Console.Write($"{department1.Name} ");
            }
            Console.WriteLine("");
            string departmentName = Console.ReadLine();

            Byte[] Bt = new Byte[16];
            Guid depId = new Guid(Bt);
            string depName;

            foreach (Departments department in db.Departments)
            {
                if (departmentName == department.Name)
                {
                    depId = department.Id;
                    depName = department.Name;
                    Console.WriteLine($"tikrinu {department.Id} {department.Name}");
                }
            }
            if (depId == Guid.Empty)
            {
                Console.WriteLine("Department does not exist");
            }
            else
            {
                student.DepartmentId = depId;
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
        public static void TransferStudentToDepartment()
        {
            using var db = new AppDbContext();
            Console.Clear();
            Console.WriteLine("Choose the student you want to transfer:");


            Byte[] Bt = new Byte[16];
            Guid depId = new Guid(Bt);

            foreach (Students student2 in db.Students)
            {
                Console.Clear();
                Console.Write($"{student2.Name} ");
            }
            Console.WriteLine("");
            string studentName = Console.ReadLine();

            Console.WriteLine("Which department to transfer the strudent to?");
            foreach (Departments department in db.Departments)
            {
                Console.Write($"{department.Name} ");
            }
            Console.WriteLine("");
            var departmentName = Console.ReadLine();

            foreach (Departments department in db.Departments)
            {
                if (departmentName == department.Name)
                {
                    depId = department.Id;
                }
            }
            var student = new Students(studentName);

            if (depId == Guid.Empty)
            {
                Console.WriteLine("Department does not exist");
            }
            else
            {
                student.DepartmentId = depId;
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
        public static void ShowStudentsInDepartment()
        {
            Console.Write("Choose the department: ");
            using var db = new AppDbContext();

            foreach (Departments department in db.Departments)
            {
                Console.Write($"{department.Name} ");
            }
            Console.WriteLine($"");
            string departmentName = Console.ReadLine();

            Console.WriteLine($"Students in {departmentName} department:");
            foreach (Students student in db.Students)
            {
                if (departmentName == student.Department.Name)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
        public static void ShowLecturesInDepartment()
        {
            Console.Write("Choose the department: ");
            using var db = new AppDbContext();

            foreach (Departments department in db.Departments)
            {
                Console.Write($"{department.Name} ");
            }
            Console.WriteLine($"");
            string departmentName = Console.ReadLine();
            Console.WriteLine($"{departmentName} department lectures:");
            foreach (Lectures lecture in db.Lectures)
            {
                if (departmentName == lecture.Department.Name)
                {
                    Console.WriteLine(lecture.Name);
                }
            }
        }

        public static void ShowLecturesByStudent()
        {
            Console.Write("Enter student name: ");
            using var db = new AppDbContext();

            Byte[] Bt = new Byte[16];
            Guid studDepId = new Guid(Bt);

            foreach (Students student in db.Students)
            {
                Console.Write($"{student.Name} ");
            }
            Console.WriteLine($"");
            string studentName = Console.ReadLine();

            foreach (Students student in db.Students)
            {
                if (studentName == student.Name)
                {
                    studDepId = student.DepartmentId;
                }
            }
            Console.WriteLine($"{studentName} lectures:");
            foreach (Lectures lecture in db.Lectures)
            {
                if (lecture.DepartmentId == studDepId)
                {
                    Console.WriteLine($"{lecture.Name}");
                }
            }
        }
    }
}
