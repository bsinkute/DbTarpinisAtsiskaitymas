using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class TransferStudentWindow
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;

        public TransferStudentWindow(IStudentService studentService, IDepartmentService departmentService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
        }

        public async Task TransferStudent()
        {
            Console.Clear();
            var students = await _studentService.GetAllStudents();
            if (!students.Any())
            {
                Console.WriteLine("No students available to transfer.");
                Console.ReadLine();
                return;
            }
            var studentId = ConsoleHelper.SelectStudentId(students);

            var departments = await _departmentService.GetAllDepartments();
            var newDepartmentId = ConsoleHelper.SelectDepartment(departments);

            var student = await _studentService.GetStudentById(studentId);

            if (student is null)
            {
                Console.WriteLine($"Student not found with id: {studentId}");
            }
            else
            {
                var oldDepartmentId = student.DepartmentId;
                if (oldDepartmentId == newDepartmentId)
                {
                    Console.WriteLine("Student already in this department");
                }
                else
                {
                    await _studentService.AddStudentDepartment(student, newDepartmentId);
                    Console.WriteLine($"Student {student.FirstName} {student.LastName} has been transferred from department ID {oldDepartmentId} to department ID {newDepartmentId}.");
                }
            }
            Console.ReadLine();
        }
    }
}
