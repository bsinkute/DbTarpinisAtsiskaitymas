namespace DbTarpinisAtsiskaitymas.Models
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public IList<StudentLecture> StudentLectures { get; set; }
        public IList<DepartmentLecture> DepartmentLectures { get; set; }

    }
}
