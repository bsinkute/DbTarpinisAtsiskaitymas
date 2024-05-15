using DbTarpinisAtsiskaitymas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Database.InitialData
{
    public static class LectureInitialData
    {
        public static Lecture[] DataSeed => new Lecture[]
        {
            new Lecture
            {
                LectureId = 1,
                LectureName = "Introduction to Programming"
            },

            new Lecture
            {
                LectureId = 2,
                LectureName = "Algorithms and Data Structures"
            },

            new Lecture
            {
                LectureId = 3,
                LectureName = "Civil Engineering Fundamentals"
            },


        };
    }
}
