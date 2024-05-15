using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class DisplayStudentLectureWindow
    {
        private readonly ILectureService _lectureService;

        public DisplayStudentLectureWindow(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        public async Task DisplayStudentLectures()
        {
            Console.Write("Enter student ID: ");
            bool isValidId = int.TryParse(Console.ReadLine(), out int studentId);

            if (!isValidId)
            {
                Console.WriteLine("Invalid student ID.");
                return;
            }

            var lectures = await _lectureService.GetLecturesByStudentId(studentId);

            if (lectures == null )
            {
                Console.WriteLine("No lectures found for this student.");
                return;
            }

            Console.WriteLine($"Lectures for student ID {studentId}:");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"- {lecture.LectureName}");
            }
            Console.ReadLine();
        }
    }
}
