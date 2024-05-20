namespace DbTarpinisAtsiskaitymas.Models
{
    public class DepartmentLecture
    {
        public int LectureId { get; set; }
        public int DepartmentId {  get; set; }

        public Lecture Lecture { get; set; }
        public Department Department { get; set; }
    }
}

