using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

