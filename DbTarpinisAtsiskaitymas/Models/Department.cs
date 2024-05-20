namespace DbTarpinisAtsiskaitymas.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public IList<Student> Students {  get; set; }
        public IList<DepartmentLecture> DepartmentLectures { get; set; }




    }
}
