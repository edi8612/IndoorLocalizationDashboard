using IndoorLocalizationSystem.Models;

namespace IndoorLocalizationSystem.Repositories
{
    public interface IProfessorRepository
    {
        
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();
        Task<Professor> GetProfessorByIdAsync(int id);
        Task AddProfessorAsync(Professor professor);
        Task UpdateProfessorAsync(Professor professor);
        Task DeleteProfessorAsync(int id);
    }
}
