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

        public DisplayDepartmentStudentWindow(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task DisplayDepartmentStudents()
        {
            Console.Write("Enter department ID: ");
            bool isValidId = int.TryParse(Console.ReadLine(), out int departmentId);

            if (!isValidId)
            {
                Console.WriteLine("Invalid department ID.");
                return;
            }

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
