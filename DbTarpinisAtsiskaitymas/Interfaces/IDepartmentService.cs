using DbTarpinisAtsiskaitymas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> AddDepartment(string departmentName);
        Task<List<Department>> GetAllDepartments();

    }
}
