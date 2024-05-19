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
    public class DepartmentService : IDepartmentService
    {
        private readonly UniversityContext _universityContext;

        public DepartmentService(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }

        public async Task<Department> AddDepartment(string departmentName)
        {
            if (string.IsNullOrWhiteSpace(departmentName) || departmentName.Length > 150)
            {
                return null;
            }

            var department = new Department
            {
                DepartmentName = departmentName
            };

            _universityContext.Departments.Add(department);
            await _universityContext.SaveChangesAsync();
            return department;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _universityContext.Departments
                .Include(x => x.DepartmentLectures)
                .ThenInclude(dl => dl.Lecture)
                .ToListAsync();
        }
    }
}

