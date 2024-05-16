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
            Console.Write("Enter student ID: ");
            bool isValidId = int.TryParse(Console.ReadLine(), out int studentId);

            if (!isValidId)
            {
                Console.WriteLine("Invalid student ID.");
                return;
            }

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
