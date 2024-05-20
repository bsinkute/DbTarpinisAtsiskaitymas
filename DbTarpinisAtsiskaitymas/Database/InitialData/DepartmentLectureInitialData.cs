using DbTarpinisAtsiskaitymas.Models;

namespace DbTarpinisAtsiskaitymas.Database.InitialData
{
    public static class DepartmentLectureInitialData
    {
        public static DepartmentLecture[] DataSeed => new DepartmentLecture[]
        {
            new DepartmentLecture
            {
                DepartmentId = 1,
                LectureId = 1
            },

            new DepartmentLecture
            {
                DepartmentId = 1,
                LectureId = 2
            },

        };
    }    
}
