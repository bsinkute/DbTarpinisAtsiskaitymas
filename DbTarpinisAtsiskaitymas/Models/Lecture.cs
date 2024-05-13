using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Models
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public IList<Student> Students { get; set; }
        public IList<Department> Departments { get; set; }

    }
}
