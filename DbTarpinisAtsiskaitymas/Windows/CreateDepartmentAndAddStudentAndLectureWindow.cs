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


            Console.WriteLine($"List of lectures which you want to add to a department with ID {department.DepartmentId}");
            var lectures = await _lectureService.GetAllLectures();

            foreach (var lecture in lectures)
            {
                Console.WriteLine($"ID: {lecture.LectureId}, Name: {lecture.LectureName}");
            }

            bool addMoreLectures;
            do
            {
                var lectureId = ConsoleHelper.SelectLectureId(lectures);
                await _lectureService.AddLectureDepartment(lectureId, department.DepartmentId);
                var lecture = lectures.FirstOrDefault(l => l.LectureId == lectureId);
                Console.WriteLine($"Lecture '{lecture.LectureName}' has been added to department ID '{department.DepartmentId}'.");

                Console.Write("Do you want to add another lecture? (yes/no): ");
                string response = Console.ReadLine().Trim().ToLower();
                addMoreLectures = response == "yes";

            } while (addMoreLectures);

            Console.WriteLine("Finished adding lectures.");
            Console.WriteLine($"You added a department {department.DepartmentName} .");
            Console.ReadLine();
        }
    }
}
