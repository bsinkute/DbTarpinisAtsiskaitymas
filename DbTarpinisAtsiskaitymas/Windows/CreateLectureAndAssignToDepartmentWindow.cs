using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;

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
            string lectureName;
            do
            {
                Console.Write("Enter lecture name: ");
                lectureName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(lectureName))
                {
                    Console.WriteLine("Lecture name can not be empty.");
                }
            } while (string.IsNullOrWhiteSpace(lectureName));

            var lecture = await _lectureService.AddLecture(lectureName);
            var departments = await _departmentService.GetAllDepartments();

            bool addToAnotherDepartment;
            do
            {
                var departmentsWithoutLecture = departments
                    .Where(x => !x.DepartmentLectures.Any(y => y.LectureId == lecture.LectureId))
                    .ToList();

                if (departmentsWithoutLecture.Count == 0)
                {
                    break;
                }

                var departmentId = ConsoleHelper.SelectDepartment(departmentsWithoutLecture);
                await _lectureService.AddLectureDepartment(lecture.LectureId, departmentId);
                Console.WriteLine($"Lecture `{lectureName}` has been created and added to department with ID `{departmentId}`");
                Console.Write("Would you like to add this lecture to another department? (yes/no): ");
                string response = Console.ReadLine().Trim().ToLower();
                addToAnotherDepartment = response == "yes";

            } while (addToAnotherDepartment);


            ConsoleHelper.GoBack();
        }
    }
}
