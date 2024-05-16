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

        public TransferStudentWindow(IStudentService studentService)
        {
            _studentService = studentService;
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

            Console.Write("Enter new department ID: ");
            bool isValidDepartmentId = int.TryParse(Console.ReadLine(), out int newDepartmentId);

            if (!isValidDepartmentId)
            {
                Console.WriteLine("Invalid department ID.");
                return;
            }

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
