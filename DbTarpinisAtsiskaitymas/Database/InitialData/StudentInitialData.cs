using DbTarpinisAtsiskaitymas.Models;

namespace DbTarpinisAtsiskaitymas.Database.InitialData
{
    public static class StudentInitialData
    {
        public static Student[] DataSeed = new Student[]
        {
            new Student
            {
                StudentId = 1,
                FirstName = "Jonas",
                LastName = "Jonauskas",
                Email = "jonas.jonauskas@gmail.com",
                Phone = "+3706567890",
                DepartmentId = 1,
            }
        };
    }
}
