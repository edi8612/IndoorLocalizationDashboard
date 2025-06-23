using IndoorLocalizationSystem.Models;

namespace IndoorLocalizationSystem.Services
{
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);

    }
}
