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
    public class AddLectureToExistingDepartmentWindow
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILectureService _lectureService;

        public AddLectureToExistingDepartmentWindow(IDepartmentService departmentService, ILectureService lectureService)
        {
            _departmentService = departmentService;
            _lectureService = lectureService;
        }

        public async Task AddLectureToExistingDepartment()
        {
            var lectures = await _lectureService.GetAllLectures();

            if (!lectures.Any())
            {
                Console.WriteLine("No lectures available to assign.");
                return;
            }

            Console.WriteLine("Available Lectures:");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"ID: {lecture.LectureId}, Name: {lecture.LectureName}");
            }

            Console.Write("Enter the id of the lecture you want to assign: ");
            bool isValidId = int.TryParse(Console.ReadLine(), out int lectureId);

            if (!isValidId & lectureId <= lectures.Count)
            {
                Console.WriteLine("Invalid student ID.");
                return;
            }

            var lectureToAssign = lectures.FirstOrDefault(l => l.LectureId == lectureId);

            var departments = await _departmentService.GetAllDepartments();
            var departmentId = ConsoleHelper.SelectDepartment(departments);


            await _lectureService.AddLectureDepartment(lectureId, departmentId);

            Console.WriteLine($"Lecture `{lectureToAssign.LectureName}` has been added in department with ID `{departmentId}`");
            Console.ReadLine();
        }
    }
}
