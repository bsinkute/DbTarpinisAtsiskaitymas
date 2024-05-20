using DbTarpinisAtsiskaitymas.Models;

namespace DbTarpinisAtsiskaitymas.Database.InitialData
{
    public static class DepartmentInitialData
    {
        public static Department[] DataSeed => new Department[]
        {
            new Department
            {
                DepartmentId = 1,
                DepartmentName = "Computer Science"
            },

            new Department
            {
                DepartmentId = 2,
                DepartmentName = "Electrical Engineering"
            },
            new Department
            {
                DepartmentId = 3,
                DepartmentName = "Mathematics"
            },

            new Department
            {
                DepartmentId = 4,
                DepartmentName = "Civil Engineering"
            }     
        };
    }
}
