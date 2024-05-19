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

            TransferStudentWindow transferStudentWindow = new TransferStudentWindow(studentService, departmentService);
            DisplayDepartmentStudentWindow displayDepartmentStudentWindow = new DisplayDepartmentStudentWindow(studentService, departmentService);
            DisplayDepartmentLectureWindow displayDepartmentLectureWindow = new DisplayDepartmentLectureWindow(lectureService, departmentService);
            DisplayStudentLectureWindow displayStudentLectureWindow = new DisplayStudentLectureWindow(lectureService, studentService);
            CreateStudentAddDepartmentAndLectureWindow createStudentAddDepartmentAndLectureWindow = new CreateStudentAddDepartmentAndLectureWindow(studentService, departmentService, lectureService);
            CreateLectureAndAssignToDepartmentWindow createLectureAndAssignToDepartmentWindow = new CreateLectureAndAssignToDepartmentWindow(departmentService, lectureService);
            AddLectureToExistingDepartmentWindow addLectureToExistingDepartmentWindow = new AddLectureToExistingDepartmentWindow(departmentService, lectureService);
            CreateDepartmentAndAddStudentAndLectureWindow createDepartmentAndAddStudentAndLectureWindow = new CreateDepartmentAndAddStudentAndLectureWindow(departmentService, lectureService, studentService);
            MainWindow mainWindow = new MainWindow(studentService, displayStudentLectureWindow, displayDepartmentLectureWindow, displayDepartmentStudentWindow, transferStudentWindow, createStudentAddDepartmentAndLectureWindow, createLectureAndAssignToDepartmentWindow, addLectureToExistingDepartmentWindow, createDepartmentAndAddStudentAndLectureWindow);
            
            return mainWindow;
        }
    }
}
