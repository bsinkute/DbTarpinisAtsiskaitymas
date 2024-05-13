using DbTarpinisAtsiskaitymas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Database
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() 
        {
            ConnectionString = "Data Source=DESKTOP-473CTTK\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True;Trust Server Certificate=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionString);

        public string ConnectionString { get; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
