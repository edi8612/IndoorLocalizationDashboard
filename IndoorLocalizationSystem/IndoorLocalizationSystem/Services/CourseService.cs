using AutoMapper;
using IndoorLocalizationSystem.DTOs;
using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IndoorLocalizationSystem.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository, IProfessorRepository professorRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _professorRepository = professorRepository;
            _mapper = mapper;
        }
        public async Task<CourseDTO> GetCourseByIdAsync(string id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            return _courseRepository.GetCourseByIdAsync(id) == null ? null : _mapper.Map<CourseDTO>(course);
        }
        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllCoursesAsync();
            return _mapper.Map<List<CourseDTO>>(courses);
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

        public async Task<List<CourseDTO>> GetStudentsPerCourseStatsAsync()
        {
            var courses = await _courseRepository.GetAllCoursesAsync();
                
            return _mapper.Map<List<CourseDTO>>(courses);
        }




    }

}
