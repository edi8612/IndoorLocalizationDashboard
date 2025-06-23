using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Repositories;

namespace IndoorLocalizationSystem.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Course> GetCourseByIdAsync(string id)
        {
            return await _courseRepository.GetCourseByIdAsync(id);
        }
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllCoursesAsync();
        }
        public async Task AddCourseAsync(Course course)
        {
            await _courseRepository.AddCourseAsync(course);
        }
        public async Task UpdateCourseAsync(Course course)
        {
            await _courseRepository.UpdateCourseAsync(course);
        }
        public async Task DeleteCourseAsync(string id)
        {
            await _courseRepository.DeleteCourseAsync(id);
        }
    }
    
}
