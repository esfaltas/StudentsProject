using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject
{
    internal class Students
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public Departments Department { get; set; }

        public Students(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
