using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;
using DbTarpinisAtsiskaitymas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class CreateStudentAddDepartmentAndLectureWindow
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly ILectureService _lectureService;

        public CreateStudentAddDepartmentAndLectureWindow(IStudentService studentService, IDepartmentService departmentService, ILectureService lectureService )
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _lectureService = lectureService;
        }

        public async Task CreateStudentAddDepartmentAndLecture()
        {
            Console.Write("Enter student first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter student last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter student email: ");
            string email = Console.ReadLine();
            Console.Write("Enter student phone: ");
            string phone = Console.ReadLine();

            var departments = await _departmentService.GetAllDepartments();
            var newDepartmentId = ConsoleHelper.SelectDepartment(departments);

            var departmentToAssign = departments.First(x => x.DepartmentId == newDepartmentId);
            var student = await _studentService.AddStudent(firstName, lastName, email, phone, newDepartmentId);
            var lecturesToAdd = departmentToAssign.DepartmentLectures.Select(x => x.LectureId).ToList();

            await _lectureService.AssignLecturesToStudent(student.StudentId, lecturesToAdd);
            Console.Clear();
            Console.WriteLine($"Student `{student.FirstName} {student.LastName}` has been created in `{departmentToAssign.DepartmentName}` department");

            foreach (var lecture in departmentToAssign.DepartmentLectures.Select(x => x.Lecture))
            {
                Console.WriteLine($" - Lecture `{lecture.LectureName}` has been assigned to student");
            }

            Console.ReadLine();
        }

        //private static int GetLectureToAdd(List<Lecture> lectures)
        //{
        //    Console.Write("Enter lecture id to add: ");
        //    var inputIsNumber = int.TryParse(Console.ReadLine(), out int lectureId);
        //    var lectureExists = lectures.Any(x => x.LectureId == lectureId);
        //    while (!inputIsNumber || !lectureExists)
        //    {
        //        if (!inputIsNumber)
        //        {
        //            Console.Write("Input must be a valid number: ");
        //        }
        //        else if (!lectureExists)
        //        {
        //            Console.Write("This lecture does not exist: ");
        //        }
        //        inputIsNumber = int.TryParse(Console.ReadLine(), out lectureId);
        //        lectureExists = lectures.Any(x => x.LectureId == lectureId);
        //    }
        //    return lectureId;
        //}
    }
}
