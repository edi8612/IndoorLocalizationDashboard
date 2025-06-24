using IndoorLocalizationSystem.DTOs;
using IndoorLocalizationSystem.Models;

namespace IndoorLocalizationSystem.Services
{
    public interface IStudentService
    {
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        Task EnrollSudentInDefaultCourseAsync(int studentId, string courseId);

    }
}
