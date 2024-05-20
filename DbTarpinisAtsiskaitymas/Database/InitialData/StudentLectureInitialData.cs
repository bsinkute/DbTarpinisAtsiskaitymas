using DbTarpinisAtsiskaitymas.Models;

namespace DbTarpinisAtsiskaitymas.Database.InitialData
{
    public static class StudentLectureInitialData
    {
        public static StudentLecture[] DataSeed => new StudentLecture[]
        {
            new StudentLecture
            {
                StudentId = 1,
                LectureId = 1
            },
            new StudentLecture
            {
                StudentId = 1,
                LectureId = 2
            }
        };
    }
}
