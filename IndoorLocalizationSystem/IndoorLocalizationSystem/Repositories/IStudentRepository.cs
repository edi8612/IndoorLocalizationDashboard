using IndoorLocalizationSystem.Models;

namespace IndoorLocalizationSystem.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        //Task<IEnumerable<Student>> GetStudentsByCourseIdAsync(string courseId);
        //Task<IEnumerable<Student>> GetStudentsByClassroomIdAsync(int classroomId);
    }
}
