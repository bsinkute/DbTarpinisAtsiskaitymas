using DbTarpinisAtsiskaitymas.Models;

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
