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
            Console.Clear();
            var lectures = await _lectureService.GetAllLectures();

            if (!lectures.Any())
            {
                Console.WriteLine("No lectures available to assign.");
                Console.ReadLine();
                return;
            }

            var departments = await _departmentService.GetAllDepartments();

            while (true)
            {
                Console.Clear();
                int lectureId = ConsoleHelper.SelectLectureId(lectures);
                var lectureToAssign = lectures.FirstOrDefault(l => l.LectureId == lectureId);

                var departmentsWithoutLecture = departments
                    .Where(x => !x.DepartmentLectures.Any(y => y.LectureId == lectureId))
                    .ToList();

                int departmentId = ConsoleHelper.SelectDepartment(departmentsWithoutLecture);

                var result = await _lectureService.AddLectureDepartment(lectureId, departmentId);

                if (result)
                {
                    Console.WriteLine($"Lecture `{lectureToAssign.LectureName}` has been added to department with ID `{departmentId}`.");
                }
                else
                {
                    Console.WriteLine($"Lecture `{lectureToAssign.LectureName}` is already assigned to department with ID `{departmentId}`.");
                }

                Console.Write("Would you like to add another lecture? (yes/no): ");
                string response = Console.ReadLine().Trim().ToLower();

                if (response != "yes")
                {
                    break;
                }
            }

            Console.ReadLine();
        }
    } 
}
