namespace DbTarpinisAtsiskaitymas.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public IList<StudentLecture> StudentLectures { get; set; }
    }
}
