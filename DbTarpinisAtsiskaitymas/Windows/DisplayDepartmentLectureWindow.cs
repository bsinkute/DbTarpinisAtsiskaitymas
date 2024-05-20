using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class DisplayDepartmentLectureWindow
    {
        private readonly ILectureService _lectureService;
        private readonly IDepartmentService _departmentService;

        public DisplayDepartmentLectureWindow(ILectureService lectureService, IDepartmentService departmentService)
        {
            _lectureService = lectureService;
            _departmentService = departmentService;
        }

        public async Task DisplayDepartmentLectures()
        {
            Console.Clear();
            var departments = await _departmentService.GetAllDepartments();
            if (departments.Count == 0)
            {
                Console.WriteLine("No departments found");
                ConsoleHelper.GoBack();
                return;
            }

            bool displayMoreDepartmentLectures;
            do
            {
                var departmentId = ConsoleHelper.SelectDepartment(departments);
                var lectures = await _lectureService.GetLecturesByDepartmentId(departmentId);

                if (lectures == null)
                {
                    Console.WriteLine("No lectures found for this department.");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine($"Lectures for department ID {departmentId}:");
                foreach (var lecture in lectures)
                {
                    Console.WriteLine($"- {lecture.LectureName}");
                }
                Console.Write("Would you like to display more? (yes/no): ");
                string response = Console.ReadLine().Trim().ToLower();
                displayMoreDepartmentLectures = response == "yes";
            } while (displayMoreDepartmentLectures);
            ConsoleHelper.GoBack();
        }
    }
}
