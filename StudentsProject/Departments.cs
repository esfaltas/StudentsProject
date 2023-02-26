using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject
{
    internal class Departments
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Students> Student { get; set; }
        public List<Lectures> Lecture { get; set; }

        public Departments(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Student = new List<Students>();
            Lecture = new List<Lectures>();
        }
    }
}
