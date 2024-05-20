using DbTarpinisAtsiskaitymas.Interfaces;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class MainWindow
    {
        private readonly IStudentService _studentService;
        private readonly DisplayStudentLectureWindow _displayStudentLectureWindow;
        private readonly DisplayDepartmentLectureWindow _displayDepartmentLectureWindow;
        private readonly DisplayDepartmentStudentWindow _displayDepartmentStudentWindow;
        private readonly TransferStudentWindow _transferStudentWindow;
        private readonly CreateStudentAddDepartmentAndLectureWindow _createStudentAddDepartmentAndLectureWindow;
        private readonly CreateLectureAndAssignToDepartmentWindow _createLectureAndAssignToDepartmentWindow;
        private readonly AddLectureToExistingDepartmentWindow _addLectureToExistingDepartmentWindow;
        private readonly CreateDepartmentAndAddStudentAndLectureWindow _createDepartmentAndAddStudentAndLectureWindow;

        public MainWindow(IStudentService studentService, 
            DisplayStudentLectureWindow displayStudentLectureWindow,
            DisplayDepartmentLectureWindow displayDepartmentLectureWindow,
            DisplayDepartmentStudentWindow displayDepartmentStudentWindow,
            TransferStudentWindow transferStudentWindow,
            CreateStudentAddDepartmentAndLectureWindow createStudentAddDepartmentAndLectureWindow,
            CreateLectureAndAssignToDepartmentWindow createLectureAndAssignToDepartmentWindow,
            AddLectureToExistingDepartmentWindow addLectureToExistingDepartmentWindow,
            CreateDepartmentAndAddStudentAndLectureWindow createDepartmentAndAddStudentAndLectureWindow)

        {
            _studentService = studentService;
            _displayStudentLectureWindow = displayStudentLectureWindow;
            _displayDepartmentLectureWindow = displayDepartmentLectureWindow;
            _displayDepartmentStudentWindow = displayDepartmentStudentWindow;
            _transferStudentWindow = transferStudentWindow;
            _createStudentAddDepartmentAndLectureWindow = createStudentAddDepartmentAndLectureWindow;
            _createLectureAndAssignToDepartmentWindow = createLectureAndAssignToDepartmentWindow;
            _addLectureToExistingDepartmentWindow = addLectureToExistingDepartmentWindow;
            _createDepartmentAndAddStudentAndLectureWindow = createDepartmentAndAddStudentAndLectureWindow;
        }

        public async Task Load()
        {
            while (true)
            {
                DisplayMenu();
                bool isLoadCorect = int.TryParse(Console.ReadLine(), out int loadSelect);
                while (!isLoadCorect || loadSelect < 1 || loadSelect > 8)
                {
                    Console.Write("Please enter a number from 1 to 8: ");
                    isLoadCorect = int.TryParse(Console.ReadLine(), out loadSelect);
                }
                switch (loadSelect)
                {
                    case 1:
                        await _createDepartmentAndAddStudentAndLectureWindow.CreateDepartmentAndAddStudentAndLecture();
                        break;
                    case 2:
                        await _addLectureToExistingDepartmentWindow.AddLectureToExistingDepartment();
                        break;
                    case 3:
                        await _createLectureAndAssignToDepartmentWindow.CreateLectureAndAssignToDepartment();
                        break;
                    case 4:
                        await _createStudentAddDepartmentAndLectureWindow.CreateStudentAddDepartmentAndLecture();
                        break;
                    case 5:
                        await _transferStudentWindow.TransferStudent();
                        break;
                    case 6:
                        await _displayDepartmentStudentWindow.DisplayDepartmentStudents();
                        break;
                    case 7:
                        await _displayDepartmentLectureWindow.DisplayDepartmentLectures();
                        break;
                    case 8:
                        await _displayStudentLectureWindow.DisplayStudentLectures();
                        break;
                    default:
                        break;
                }
            }
        }
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to students registration system! Select an action:");
            Console.WriteLine("1. Create a department and add students/lectures to it");
            Console.WriteLine("2. Add lectures to an already existing department");
            Console.WriteLine("3. Create a lecture and assign it to a department");
            Console.WriteLine("4. Create a student, add him to an existing department and assign existing lectures to him");
            Console.WriteLine("5. Transfer the student to another department");
            Console.WriteLine("6. Display all students of the department");
            Console.WriteLine("7. Display all lectures of the department");
            Console.WriteLine("8. Display all lectures by student.");
            Console.Write("Enter number from 1 to 8: ");
        }
    }
}
