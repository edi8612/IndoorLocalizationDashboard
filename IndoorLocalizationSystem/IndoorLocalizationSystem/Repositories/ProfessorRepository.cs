using IndoorLocalizationSystem.Data;
using IndoorLocalizationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace IndoorLocalizationSystem.Repositories
{
    public class ProfessorRepository: IProfessorRepository
    {
        private readonly AppDbContext _context;
        public ProfessorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
        {
            return await _context.Professors
                .Include(p => p.Courses)
                .Include(p => p.User)
                .ToListAsync();
        }
        public async Task<Professor> GetProfessorByIdAsync(int id)
        {
            return await _context.Professors
                .Include(p => p.Courses)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddProfessorAsync(Professor professor)
        {
            await _context.Professors.AddAsync(professor);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProfessorAsync(Professor professor)
        {
            _context.Professors.Update(professor);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProfessorAsync(int id)
        {
            var professor = await _context.Professors.FindAsync(id);
            if (professor != null)
            {
                _context.Professors.Remove(professor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
