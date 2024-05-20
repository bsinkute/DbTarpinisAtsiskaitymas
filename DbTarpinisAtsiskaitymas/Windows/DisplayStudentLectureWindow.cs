using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class DisplayStudentLectureWindow
    {
        private readonly ILectureService _lectureService;
        private readonly IStudentService _studentService;

        public DisplayStudentLectureWindow(ILectureService lectureService, IStudentService studentService)
        {
            _lectureService = lectureService;
            _studentService = studentService;
        }

        public async Task DisplayStudentLectures()
        {
            Console.Clear();
            var students = await _studentService.GetAllStudents();
            if (!students.Any())
            {
                Console.WriteLine("No students available.");
                Console.ReadLine();
                return;
            }
            var studentId = ConsoleHelper.SelectStudentId(students);


            var lectures = await _lectureService.GetLecturesByStudentId(studentId);

            if (lectures == null )
            {
                Console.WriteLine("No lectures found for this student.");
                Console.ReadLine();
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
