using IndoorLocalizationSystem.Models;

namespace IndoorLocalizationSystem.Services
{
    public interface ICourseService
    {
        Task<Course> GetCourseByIdAsync(string id);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(string id);
    }
}
