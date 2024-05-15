namespace DbTarpinisAtsiskaitymas.Models
{
    public class StudentLecture
    {
        public int StudentId { get; set; }
        public int LectureId { get; set; }
        public Student Student { get; set; }
        public Lecture Lecture { get; set;}
    }
}
