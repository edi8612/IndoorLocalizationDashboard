using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Repositories;

namespace IndoorLocalizationSystem.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IProfessorRepository _professorRepository;
        public CourseService(ICourseRepository courseRepository, IProfessorRepository professorRepository)
        {
            _courseRepository = courseRepository;
            _professorRepository = professorRepository;
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
            if (string.IsNullOrWhiteSpace(course.Name))
                throw new Exception("Course name is required.");

            if (await _professorRepository.GetProfessorByIdAsync(course.ProfessorId) == null)
                throw new Exception("Assigned professor does not exist.");

            await _courseRepository.AddCourseAsync(course);
        }
        public async Task UpdateCourseAsync(Course course)
        {
            var existing = await _courseRepository.GetCourseByIdAsync(course.Id);
            if (existing == null)
                throw new Exception("Course does not exist.");

            await _courseRepository.UpdateCourseAsync(course);
        }
        public async Task DeleteCourseAsync(string id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course == null)
                throw new Exception("Course not found.");

            if (course.Students != null && course.Students.Any())
                throw new Exception("Cannot delete a course with enrolled students.");

            await _courseRepository.DeleteCourseAsync(id);
        }

        // Business logic to check if a professor can be assigned to a course
        public async Task<bool> CanAssignProfessorToCourseAsync(int professorId)
        {
            var professor = await _professorRepository.GetProfessorByIdAsync(professorId);
            if (professor == null)
                throw new Exception("Professor not found.");

            return professor.Courses.Count < 3;
        }




    }

}
