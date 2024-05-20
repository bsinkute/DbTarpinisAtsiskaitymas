using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;
using System.Text.RegularExpressions;

namespace DbTarpinisAtsiskaitymas.Helpers
{
    public static class ConsoleHelper
    {
        public static int SelectDepartment(List<Department> departments)
        {
            Console.WriteLine("Department list: ");

            foreach (var department in departments)
            {
                Console.WriteLine($"Id: {department.DepartmentId} | Department Name: {department.DepartmentName}");
            }

            Console.Write("Enter department ID: ");
            bool isValidDepartmentId = int.TryParse(Console.ReadLine(), out int newDepartmentId);
            var departmentExists = departments.Any(x => x.DepartmentId == newDepartmentId);

            while (!isValidDepartmentId || !departmentExists)
            {
                if (!isValidDepartmentId)
                {
                    Console.Write("Department id must be a number. Enter a valid department id: ");
                }
                else if (!departmentExists)
                {
                    Console.Write("Department not found. Enter an existing department id: ");
                }
                isValidDepartmentId = int.TryParse(Console.ReadLine(), out newDepartmentId);
                departmentExists = departments.Any(x => x.DepartmentId == newDepartmentId);
            }
            return newDepartmentId;
        }

        public static async Task<Student> CreateStudent(int departmentId, IStudentService studentService)
        {
            Console.WriteLine("Creating a new student!");
            string firstName, lastName, email, phone;

            do
            {
                Console.Write("Enter student first name: ");
                firstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("First name cannot be empty. Please enter a valid first name.");
                }
            } while (string.IsNullOrWhiteSpace(firstName));

            do
            {
                Console.Write("Enter student last name: ");
                lastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Last name cannot be empty. Please enter a valid last name.");
                }
            } while (string.IsNullOrWhiteSpace(lastName));

            do
            {
                Console.Write("Enter student email: ");
                email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
                {
                    Console.WriteLine("Invalid email. Please enter a valid email.");
                }
            } while (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email));

            do
            {
                Console.Write("Enter student phone: ");
                phone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(phone) || !phone.All(x => char.IsDigit(x) || x == '+'))
                {
                    Console.WriteLine("Invalid phone number. Please enter a valid phone number containing only digits.");
                }
            } while (string.IsNullOrWhiteSpace(phone) || !phone.All(x => char.IsDigit(x) || x == '+'));

            return await studentService.AddStudent(firstName, lastName, email, phone, departmentId);
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static int SelectLectureId(List<Lecture> lectures)
        {
            Console.WriteLine("Available Lectures:");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"ID: {lecture.LectureId}, Name: {lecture.LectureName}");
            }

            bool isValidId, lectureExists;
            int lectureId;

            do
            {
                Console.Write("Enter the id of the lecture you want to assign: ");
                isValidId = int.TryParse(Console.ReadLine(), out lectureId);
                lectureExists = lectures.Any(x => x.LectureId == lectureId);
                if (!isValidId || !lectureExists)
                {
                    Console.WriteLine("Invalid lecture ID.");
                }
            } while (!isValidId || !lectureExists);
            return lectureId;
        }

        public static int SelectStudentId(List<Student> students)
        {
            Console.WriteLine("Available Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.StudentId}, First Name: {student.FirstName}, Last Name: {student.LastName}, Department Id: {student.DepartmentId}");
            }

            bool isValidId, studentExists;
            int studentId;

            do
            {
                Console.Write("Enter the id of the student: ");
                isValidId = int.TryParse(Console.ReadLine(), out studentId);
                studentExists = students.Any(x => x.StudentId == studentId);
                if (!isValidId || !studentExists)
                {
                    Console.WriteLine("Invalid student ID.");
                }
            } while (!isValidId || !studentExists);
            return studentId;
        }
    }
}
