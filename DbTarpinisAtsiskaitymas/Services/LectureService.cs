using DbTarpinisAtsiskaitymas.Database;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Lecture>> AssignLecturesToStudent(int studentId, List<int> lectureIds)
        {
            var student = await _universityContext.Students
            .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
            {
                return null;
            }

            var lectures = await _universityContext.Lectures
            .Where(l => lectureIds.Contains(l.LectureId))
            .ToListAsync();

            if (!lectures.Any())
            {
                return null;
            }

            foreach (var lecture in lectures)
            {
                if (!await _universityContext.StudentLectures
                    .AnyAsync(sl => sl.StudentId == studentId && sl.LectureId == lecture.LectureId))
                {
                    var studentLecture = new StudentLecture
                    {
                        StudentId = studentId,
                        LectureId = lecture.LectureId
                    };
                    _universityContext.StudentLectures.Add(studentLecture);
                }
            }

            await _universityContext.SaveChangesAsync();
            return lectures;
        }

        public async Task<List<Lecture>> GetAllLectures()
        {
            return await _universityContext.Lectures.ToListAsync();     
        }

        public async Task<Lecture> AddLecture(string lectureName)
        {
            if (string.IsNullOrWhiteSpace(lectureName) || lectureName.Length > 150)
            {
                return null;
            }
           
            var lecture = new Lecture
            {
                LectureName = lectureName,
            };

            _universityContext.Lectures.Add(lecture);
            await _universityContext.SaveChangesAsync();
            return lecture;
        }

        public async Task AddLectureDepartment(int lectureId, int departmentId)
        {
            var departmentLecture = new DepartmentLecture
            {
                DepartmentId = departmentId,
                LectureId = lectureId,
            };

            _universityContext.DepartmentLectures.Add(departmentLecture);
            await _universityContext.SaveChangesAsync();
        }
    }
}
