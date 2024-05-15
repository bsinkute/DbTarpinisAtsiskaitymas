using DbTarpinisAtsiskaitymas.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Database.InitialData
{
    public static class DepartmentInitialData
    {
        public static Department[] DataSeed => new Department[]
        {
            new Department
            {
                DepartmentId = 1,
                DepartmentName = "Computer Science"
            },

            new Department
            {
                DepartmentId = 2,
                DepartmentName = "Electrical Engineering"
            },
            new Department
            {
                DepartmentId = 3,
                DepartmentName = "Mathematics"
            },

            new Department
            {
                DepartmentId = 4,
                DepartmentName = "Civil Engineering"
            },

            /*new Department
            {
                DepartmentId = 5,
                DepartmentName = "Mechanical Engineering"
            },

            new Department
            {
                DepartmentId = 6,
                DepartmentName = "Physics"
            },
            new Department
            {
                DepartmentId = 7,
                DepartmentName = "Biology"
            },

            new Department
            {
                DepartmentId = 8,
                DepartmentName = "Chemistry"
            } */                  
        };
    }
}
