using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentsProject
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Lectures> Lectures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-FTK2CJN; Database = Students;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
