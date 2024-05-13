using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Models
{
    public class Department
    {
        public int DepartamentId { get; set; }
        public string DepartamentName { get; set; }
        public IList<Student> Students {  get; set; }
        public IList<Lecture> Lectures { get; set; }


    }
}
