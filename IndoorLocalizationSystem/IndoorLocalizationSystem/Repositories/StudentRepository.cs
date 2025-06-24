using IndoorLocalizationSystem.Data;
using IndoorLocalizationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace IndoorLocalizationSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {


        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Student student)
        {
           
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Student with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.Classroom) // Include Classroom navigation property
                .Include(s => s.Courses)
                .Include(s=>s.Device)// Include Courses navigation property
                .ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
           return await _context.Students
                .Include(s => s.Classroom) // Include Classroom navigation property
                .Include(s => s.Courses) // Include Courses navigation property
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
