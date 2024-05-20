using DbTarpinisAtsiskaitymas.Models;

namespace DbTarpinisAtsiskaitymas.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> AddDepartment(string departmentName);
        Task<List<Department>> GetAllDepartments();

    }
}
