using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class CreateStudentAddDepartmentAndLectureWindow
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly ILectureService _lectureService;

        public CreateStudentAddDepartmentAndLectureWindow(IStudentService studentService, IDepartmentService departmentService, ILectureService lectureService )
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _lectureService = lectureService;
        }

        public async Task CreateStudentAddDepartmentAndLecture()
        {
            Console.Clear();
            var departments = await _departmentService.GetAllDepartments();
            var newDepartmentId = ConsoleHelper.SelectDepartment(departments);

            var departmentToAssign = departments.First(x => x.DepartmentId == newDepartmentId);
            var student = await ConsoleHelper.CreateStudent(newDepartmentId, _studentService);
            var lecturesToAdd = departmentToAssign.DepartmentLectures.Select(x => x.LectureId).ToList();

            await _lectureService.AssignLecturesToStudent(student.StudentId, lecturesToAdd);
            Console.Clear();
            Console.WriteLine($"Student `{student.FirstName} {student.LastName}` has been created in `{departmentToAssign.DepartmentName}` department");

            foreach (var lecture in departmentToAssign.DepartmentLectures.Select(x => x.Lecture))
            {
                Console.WriteLine($" - Lecture `{lecture.LectureName}` has been assigned to student");
            }

            ConsoleHelper.GoBack();
        }
    }
}
