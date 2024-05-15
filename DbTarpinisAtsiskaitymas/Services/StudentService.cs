using DbTarpinisAtsiskaitymas.Database;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Services
{
    public class StudentService : IStudentService
    {
        private readonly UniversityContext _universityContext;

        public StudentService(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }

        public async Task<List<Student>> GetStudentsByDepartmentId(int departmentId)
        {
            var students = await _universityContext.Students
                .Where(s => s.DepartmentId == departmentId)
                .ToListAsync();
            return students;
        }


    }
}
