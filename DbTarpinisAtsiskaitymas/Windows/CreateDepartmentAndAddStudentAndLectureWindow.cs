using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;

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
            List<Student> addedStudents = new List<Student>();
            Console.Clear();
            Console.WriteLine("Creating a new department!");
            Console.Write("Enter department name: ");
            string departmentName = Console.ReadLine();

            var department = await _departmentService.AddDepartment(departmentName);

            bool addMoreStudents;
            do
            {
                var student = await ConsoleHelper.CreateStudent(department.DepartmentId, _studentService);
                addedStudents.Add(student);

                Console.Write("Do you want to add another student? (yes/no): ");
                string response = Console.ReadLine().Trim().ToLower();
                addMoreStudents = response == "yes";
            } while (addMoreStudents);

            Console.WriteLine("Assignment of new lectures!");
            var lectures = await _lectureService.GetAllLectures();
            bool addMoreLectures;
            List<int> addedLectureIds = new List<int>();
            do
            {
                if (!lectures.Any())
                {
                    Console.WriteLine("No lectures available to assign.");
                    addMoreLectures = false;
                    continue;
                }
                var lecturesNotInDepartment = lectures
                    .Where(x => !x.DepartmentLectures.Any(y => y.DepartmentId == department.DepartmentId))
                    .ToList();
                var lectureId = ConsoleHelper.SelectLectureId(lecturesNotInDepartment);
                await _lectureService.AddLectureDepartment(lectureId, department.DepartmentId);
                addedLectureIds.Add(lectureId);
                var lecture = lectures.FirstOrDefault(l => l.LectureId == lectureId);
                Console.WriteLine($"Lecture '{lecture.LectureName}' has been added to department ID '{department.DepartmentId}'.");

                Console.Write("Do you want to add another lecture? (yes/no): ");
                string response = Console.ReadLine().Trim().ToLower();
                addMoreLectures = response == "yes";

            } while (addMoreLectures);

            foreach (var student in addedStudents)
            {
                if (addedLectureIds.Count == 0)
                {
                    break;
                }
                await _lectureService.AssignLecturesToStudent(student.StudentId, addedLectureIds);
            }

            Console.WriteLine("Finished adding lectures.");
            Console.WriteLine($"You added a department {department.DepartmentName} with students and lectures.");
            Console.ReadLine();
        }
    }
}
