using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;

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
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Available Lectures:");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"ID: {lecture.LectureId}, Name: {lecture.LectureName}");
            }

            int lectureId = ConsoleHelper.SelectLectureId(lectures);
            var lectureToAssign = lectures.FirstOrDefault(l => l.LectureId == lectureId);

            var departments = await _departmentService.GetAllDepartments();
            var departmentId = ConsoleHelper.SelectDepartment(departments);


            await _lectureService.AddLectureDepartment(lectureId, departmentId);

            Console.WriteLine($"Lecture `{lectureToAssign.LectureName}` has been added in department with ID `{departmentId}`");
            Console.ReadLine();
        }

        
    }
}
