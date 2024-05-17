using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class CreateLectureAndAssignToDepartmentWindow
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILectureService _lectureService;

        public CreateLectureAndAssignToDepartmentWindow(IDepartmentService departmentService, ILectureService lectureService)
        {
            _departmentService = departmentService;
            _lectureService = lectureService;
        }

        public async Task CreateLectureAndAssignToDepartment()
        {
            Console.Write("Enter lecture name: ");
            string lectureName = Console.ReadLine();

            var departments = await _departmentService.GetAllDepartments();
            var departmentId = ConsoleHelper.SelectDepartment(departments);

            var lecture = await _lectureService.AddLecture(lectureName);

            await _lectureService.AddLectureDepartment(lecture.LectureId, departmentId);

            Console.WriteLine($"Lecture `{lectureName}` has been created and added in department with ID `{departmentId}`");
            Console.ReadLine();
        }
    }
}
