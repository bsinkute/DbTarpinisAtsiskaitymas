using DbTarpinisAtsiskaitymas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsByDepartmentId(int departmentId);
        Task<Student> GetStudentById(int studentId);
        Task AddStudentDepartment(Student student, int newDepartmentId);
        Task<Student> AddStudent(string firstName, string lastName, string email, string phone, int departmentId);
        Task<List<Student>> GetAllStudents();
    }
}
