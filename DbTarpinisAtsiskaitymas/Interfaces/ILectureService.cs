using DbTarpinisAtsiskaitymas.Models;

namespace DbTarpinisAtsiskaitymas.Interfaces
{
    public interface ILectureService
    {
        Task<List<Lecture>> GetLecturesByStudentId(int studentId);
        Task<List<Lecture>> GetLecturesByDepartmentId(int departmentId);
        Task<List<Lecture>> AssignLecturesToStudent(int studentId, List<int> lectureIds);
        Task<List<Lecture>> GetAllLectures();
        Task<Lecture> AddLecture(string lectureName);
        Task<bool> AddLectureDepartment(int lectureId, int departmentId);
    }
}
