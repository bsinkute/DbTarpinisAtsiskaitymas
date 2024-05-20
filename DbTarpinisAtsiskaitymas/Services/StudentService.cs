using DbTarpinisAtsiskaitymas.Database;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Student> GetStudentById(int studentId)
        {
            var student = await _universityContext.Students
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            return student;
        }
        public async Task AddStudentDepartment(Student student, int newDepartmentId)
        {
            if (student == null)
            {
                return;
            }

            student.DepartmentId = newDepartmentId;
            await _universityContext.SaveChangesAsync();
        }

        public async Task<Student> AddStudent(string firstName, string lastName, string email, string phone, int departmentId)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > 150)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > 150)
            {
                return null;
            }
            if (email.Length > 150)
            {
                return null;
            }
            if (phone.Length > 150)
            {
                return null;
            }

            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                DepartmentId = departmentId,
            };

            _universityContext.Students.Add(student);
            await _universityContext.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _universityContext.Students.ToListAsync();
        }
    }
}
