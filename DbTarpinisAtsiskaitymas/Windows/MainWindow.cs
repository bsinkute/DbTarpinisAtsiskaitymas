using DbTarpinisAtsiskaitymas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class MainWindow
    {
        private readonly IStudentService _studentService;
        private readonly DisplayStudentLectureWindow _displayStudentLectureWindow;
        private readonly DisplayDepartmentLectureWindow _displayDepartmentLectureWindow;
        private readonly DisplayDepartmentStudentWindow _displayDepartmentStudentWindow;
        public MainWindow(IStudentService studentService, 
            DisplayStudentLectureWindow displayStudentLectureWindow, 
            DisplayDepartmentLectureWindow displayDepartmentLectureWindow,
            DisplayDepartmentStudentWindow displayDepartmentStudentWindow)
        {
            _studentService = studentService;
            _displayStudentLectureWindow = displayStudentLectureWindow;
            _displayDepartmentLectureWindow = displayDepartmentLectureWindow;
            _displayDepartmentStudentWindow = displayDepartmentStudentWindow;
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
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                       
                        break;
                    case 5:
                        
                        break;
                    case 6:
                        _displayDepartmentStudentWindow.DisplayDepartmentStudents();
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
            Console.WriteLine("2. Add students/lectures to an already existing department");
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
