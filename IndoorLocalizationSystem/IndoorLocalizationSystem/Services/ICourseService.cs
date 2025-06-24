using IndoorLocalizationSystem.DTOs;
using IndoorLocalizationSystem.Models;

namespace IndoorLocalizationSystem.Services
{
    public interface ICourseService
    {
        Task<CourseDTO> GetCourseByIdAsync(string id);
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(string id);
        Task<List<CourseDTO>> GetStudentsPerCourseStatsAsync();

        Task<bool> CanAssignProfessorToCourseAsync(int professorId);
    }
}
