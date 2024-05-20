using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class DisplayDepartmentStudentWindow
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;

        public DisplayDepartmentStudentWindow(IStudentService studentService, IDepartmentService departmentService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
        }

        public async Task DisplayDepartmentStudents()
        {
            Console.Clear();
            var departments = await _departmentService.GetAllDepartments();
            var departmentId = ConsoleHelper.SelectDepartment(departments);

            var students = await _studentService.GetStudentsByDepartmentId(departmentId);

            if (students == null)
            {
                Console.WriteLine("No student found for this department.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Students for department ID {departmentId}:");
            foreach (var student in students)
            {
                Console.WriteLine($"- {student.FirstName} {student.LastName}");
            }
            ConsoleHelper.GoBack();
        }
    }
}
