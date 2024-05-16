using DbTarpinisAtsiskaitymas.Models;

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

            Console.Write("Enter new department ID: ");
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
    }
}
