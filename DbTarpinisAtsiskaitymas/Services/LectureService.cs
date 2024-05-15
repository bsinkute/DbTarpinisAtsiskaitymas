using DbTarpinisAtsiskaitymas.Database;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Services
{
    public class LectureService : ILectureService
    {
        private readonly UniversityContext _universityContext;

        public LectureService(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }
        public async Task<List<Lecture>> GetLecturesByStudentId(int studentId)
        {
            var lectures = await _universityContext.Lectures
                .Where(l => l.StudentLectures.Any(sl => sl.StudentId == studentId))
                .ToListAsync();
            return lectures;
        }
        
        public async Task<List<Lecture>> GetLecturesByDepartmentId(int departmentId)
        {
            var lectures = await _universityContext.Lectures
                .Where(l => l.DepartmentLectures.Any(dl => dl.DepartmentId == departmentId))
                .ToListAsync();
            return lectures;
        }
    }
}
