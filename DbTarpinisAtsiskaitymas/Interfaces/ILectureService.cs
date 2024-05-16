using DbTarpinisAtsiskaitymas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Interfaces
{
    public interface ILectureService
    {
        Task<List<Lecture>> GetLecturesByStudentId(int studentId);
        Task<List<Lecture>> GetLecturesByDepartmentId(int departmentId);
        Task<List<Lecture>> AssignLecturesToStudent(int studentId, List<int> lectureIds);
        Task<List<Lecture>> GetAllLectures();
    }
}
