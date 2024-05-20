using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class CreateDepartmentAndAddStudentAndLectureWindow
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILectureService _lectureService;
        private readonly IStudentService _studentService;

        public CreateDepartmentAndAddStudentAndLectureWindow(IDepartmentService departmentService, ILectureService lectureService, IStudentService studentService)
        {
            _departmentService = departmentService;
            _lectureService = lectureService;
            _studentService = studentService;
        }
        public async Task CreateDepartmentAndAddStudentAndLecture()
        {
            Console.Clear();
            Console.WriteLine("Creating a new department!");
            Console.Write("Enter department name: ");
            string departmentName = Console.ReadLine();

            var department = await _departmentService.AddDepartment(departmentName);

            bool addMoreStudents;
            do
            {
                await ConsoleHelper.CreateStudent(department.DepartmentId, _studentService);

                Console.Write("Do you want to add another student? (yes/no): ");
                string response = Console.ReadLine().Trim().ToLower();
                addMoreStudents = response == "yes";
            } while (addMoreStudents);

            Console.WriteLine("Assignment of new lectures!");
            var lectures = await _lectureService.GetAllLectures();
            bool addMoreLectures;
            do
            {
                if (!lectures.Any())
                {
                    Console.WriteLine("No lectures available to assign.");
                    addMoreLectures = false;
                    continue;
                }
                var lectureId = ConsoleHelper.SelectLectureId(lectures);
                await _lectureService.AddLectureDepartment(lectureId, department.DepartmentId);
                var lecture = lectures.FirstOrDefault(l => l.LectureId == lectureId);
                Console.WriteLine($"Lecture '{lecture.LectureName}' has been added to department ID '{department.DepartmentId}'.");

                Console.Write("Do you want to add another lecture? (yes/no): ");
                string response = Console.ReadLine().Trim().ToLower();
                addMoreLectures = response == "yes";

            } while (addMoreLectures);

            Console.WriteLine("Finished adding lectures.");
            Console.WriteLine($"You added a department {department.DepartmentName} with students and lectures.");
            Console.ReadLine();
        }
    }
}
