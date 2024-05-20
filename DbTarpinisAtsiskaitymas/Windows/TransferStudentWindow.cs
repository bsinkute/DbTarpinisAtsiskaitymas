using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Services;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class TransferStudentWindow
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly ILectureService _lectureService;

        public TransferStudentWindow(IStudentService studentService, IDepartmentService departmentService, ILectureService lectureService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _lectureService = lectureService;
        }

        public async Task TransferStudent()
        {
            Console.Clear();
            var students = await _studentService.GetAllStudents();
            if (!students.Any())
            {
                Console.WriteLine("No students available to transfer.");
                Console.ReadLine();
                return;
            }
            var studentId = ConsoleHelper.SelectStudentId(students);

            var departments = await _departmentService.GetAllDepartments();
            var newDepartmentId = ConsoleHelper.SelectDepartment(departments);

            var student = await _studentService.GetStudentById(studentId);

            if (student is null)
            {
                Console.WriteLine($"Student not found with id: {studentId}");
            }
            else
            {
                var oldDepartmentId = student.DepartmentId;
                if (oldDepartmentId == newDepartmentId)
                {
                    Console.WriteLine("Student already in this department");
                }
                else
                {
                    await _studentService.RemoveStudentLectures(studentId);
                    await _studentService.AddStudentDepartment(student, newDepartmentId);
                    var newDepartmentLectures = await _lectureService.GetLecturesByDepartmentId(newDepartmentId);
                    var lectureIds = newDepartmentLectures.Select(x => x.LectureId).ToList();
                    await _lectureService.AssignLecturesToStudent(student.StudentId, lectureIds);
                    Console.WriteLine($"Student {student.FirstName} {student.LastName} has been transferred from department ID {oldDepartmentId} to department ID {newDepartmentId} and assigned new lectures.");
                }
            }
            ConsoleHelper.GoBack();
        }
    }
}
