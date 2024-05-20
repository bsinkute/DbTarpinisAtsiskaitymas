using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class AddStudentLectureToExistingDepartmentWindow
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILectureService _lectureService;
        private readonly TransferStudentWindow _transferStudentWindow;

        public AddStudentLectureToExistingDepartmentWindow(
            IDepartmentService departmentService, 
            ILectureService lectureService, 
            TransferStudentWindow transferStudentWindow)
        {
            _departmentService = departmentService;
            _lectureService = lectureService;
            _transferStudentWindow = transferStudentWindow;
        }

        public async Task AddStudentLectureToExistingDepartment()
        {
            while (true)
            {
                DisplayMenu();
                bool isLoadCorect = int.TryParse(Console.ReadLine(), out int loadSelect);
                while (!isLoadCorect || loadSelect < 1 || loadSelect > 3)
                {
                    Console.Write("Please enter a number from 1 to 3: ");
                    isLoadCorect = int.TryParse(Console.ReadLine(), out loadSelect);
                }
                switch (loadSelect)
                {
                    case 1:
                        await _transferStudentWindow.TransferStudent();
                        break;
                    case 2:
                        await AddLectureToDepartment();
                        break;
                    default:
                        return;
                }
            }
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Add a student to an existing department");
            Console.WriteLine("2. Add lectures to an existing department");
            Console.WriteLine("3. Go back to main menu");
            Console.Write("Enter a number from 1 to 3: ");
        }

        public async Task AddLectureToDepartment()
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
        }
    } 
}
