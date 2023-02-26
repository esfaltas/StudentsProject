using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject
{
    internal class Menu
    {
        public void InitiateMenu()
        {
            bool isAlive = true;
            while (isAlive)
            {
                Console.WriteLine($"Hogvarc   ------------------------------------------------   {time}");
                Console.WriteLine("1. Create deparment and add students");
                Console.WriteLine("2. Add a student/lecture to an existing deprtment");
                Console.WriteLine("3. Create a lecture and add it to a department");
                Console.WriteLine("4. Create a student and add him a department with a lecture");
                Console.WriteLine("5. Move student to different department");
                Console.WriteLine("6. Show all students in department");
                Console.WriteLine("7. Show all lectures in department");
                Console.WriteLine("8. Show all lectures for student");
                Console.WriteLine("9. Close program");
                Console.WriteLine($"---------------------------------------------------------------------------------");

                var input = GetSelection();
                switch (input)
                {
                    case 1:
                        Service.CreateDepartmentAddStudentsAddLectures();
                        Console.Clear();
                        Console.WriteLine("2");
                        break;
                    case 2:
                        Service.TransferStudentToDepartment();
                        Console.WriteLine("3");
                        break;
                    case 3:
                        Service.AddLectureToDepartment();
                        Console.WriteLine("4");
                        break;
                    case 4:
                        Service.AddStudentToDepartment();
                        Console.WriteLine("5");
                        break;
                    case 5:
                        Console.WriteLine("1");
                        break;
                    case 6:
                        Service.ShowStudentsInDepartment();
                        Console.WriteLine("6");
                        break;
                    case 7:
                        Service.ShowLecturesInDepartment();
                        Console.WriteLine("7");
                        break;
                    case 8:
                        Console.WriteLine("8");
                        Service.ShowLecturesByStudent();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public int GetSelection()
        {
            bool isSuccess = Int32.TryParse(Console.ReadLine(), out int result);
            if (isSuccess)
            {
                return result;
            }
            Console.WriteLine("Wrong selection");
            return 0;
        }

        string time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    }
}
