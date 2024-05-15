using DbTarpinisAtsiskaitymas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class DisplayDepartmentLectureWindow
    {
        private readonly ILectureService _lectureService;

        public DisplayDepartmentLectureWindow(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        public async Task DisplayDepartmentLectures()
        {
            Console.Write("Enter department ID: ");
            bool isValidId = int.TryParse(Console.ReadLine(), out int departmentId);

            if (!isValidId)
            {
                Console.WriteLine("Invalid department ID.");
                return;
            }

            var lectures = await _lectureService.GetLecturesByDepartmentId(departmentId);

            if (lectures == null)
            {
                Console.WriteLine("No lectures found for this department.");
                return;
            }

            Console.WriteLine($"Lectures for department ID {departmentId}:");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"- {lecture.LectureName}");
            }
            Console.ReadLine();
        }
    }
}
