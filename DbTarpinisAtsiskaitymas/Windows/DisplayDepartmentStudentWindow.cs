using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var departments = await _departmentService.GetAllDepartments();
            var departmentId = ConsoleHelper.SelectDepartment(departments);

            var students = await _studentService.GetStudentsByDepartmentId(departmentId);

            if (students == null)
            {
                Console.WriteLine("No student found for this department.");
                return;
            }

            Console.WriteLine($"Students for department ID {departmentId}:");
            foreach (var student in students)
            {
                Console.WriteLine($"- {student.FirstName} {student.LastName}");
            }
            Console.ReadLine();
        }
    }
}
