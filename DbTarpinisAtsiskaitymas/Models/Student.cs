﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}