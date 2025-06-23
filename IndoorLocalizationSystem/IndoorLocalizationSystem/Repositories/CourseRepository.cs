using IndoorLocalizationSystem.Data;
using IndoorLocalizationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace IndoorLocalizationSystem.Repositories
{
    public class CourseRepository: ICourseRepository
    {

        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Course> GetCourseByIdAsync(string id)
        {
            return await _context.Courses
                .Include(c => c.Classroom) // Include Classroom navigation property
                .Include(c => c.Professor) // Include Professor navigation property
                .Include(c => c.Students) // Include Students navigation property
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.Classroom) // Include Classroom navigation property
                .Include(c => c.Professor) // Include Professor navigation property
                .Include(c => c.Students) // Include Students navigation property
                .ToListAsync();
        }
        public async Task AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCourseAsync(string id)
        {
            var course = await GetCourseByIdAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

    }
}
