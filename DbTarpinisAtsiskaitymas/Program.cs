using DbTarpinisAtsiskaitymas.Database;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Services;
using DbTarpinisAtsiskaitymas.Windows;

namespace DbTarpinisAtsiskaitymas
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MainWindow mainWindow = RegisterServices();
            await mainWindow.Load();
        }

        private static MainWindow RegisterServices()
        {
            UniversityContext universityContext = new UniversityContext();
            IDepartmentService departmentService = new DepartmentService(universityContext);
            ILectureService lectureService = new LectureService(universityContext);
            IStudentService studentService = new StudentService(universityContext);

            DisplayDepartmentStudentWindow displayDepartmentStudentWindow = new DisplayDepartmentStudentWindow(studentService);
            DisplayDepartmentLectureWindow displayDepartmentLectureWindow = new DisplayDepartmentLectureWindow(lectureService);
            DisplayStudentLectureWindow displayStudentLectureWindow = new DisplayStudentLectureWindow(lectureService);
            MainWindow mainWindow = new MainWindow(studentService, displayStudentLectureWindow, displayDepartmentLectureWindow, displayDepartmentStudentWindow);
            
            return mainWindow;
        }
    }
}
