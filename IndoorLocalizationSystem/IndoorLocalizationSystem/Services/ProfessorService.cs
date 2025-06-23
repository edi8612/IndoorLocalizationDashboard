using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Repositories;

namespace IndoorLocalizationSystem.Services
{
    public class ProfessorService: IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        public ProfessorService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }
        public async Task<Professor> GetProfessorByIdAsync(int id)
        {
            return await _professorRepository.GetProfessorByIdAsync(id);
        }
        public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
        {
            return await _professorRepository.GetAllProfessorsAsync();
        }
        public async Task AddProfessorAsync(Professor professor)
        {
            await _professorRepository.AddProfessorAsync(professor);
        }
        public async Task UpdateProfessorAsync(Professor professor)
        {
            await _professorRepository.UpdateProfessorAsync(professor);
        }
        public async Task DeleteProfessorAsync(int id)
        {
            await _professorRepository.DeleteProfessorAsync(id);
        }
    }
}
