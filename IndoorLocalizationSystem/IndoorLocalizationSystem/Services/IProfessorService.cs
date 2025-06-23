using IndoorLocalizationSystem.Models;

namespace IndoorLocalizationSystem.Services
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();
        Task<Professor> GetProfessorByIdAsync(int id);
        Task AddProfessorAsync(Professor professor);
        Task UpdateProfessorAsync(Professor professor);
        Task DeleteProfessorAsync(int id);
        Task<IEnumerable<Course>> GetCoursesTaughtByProfessorAsync(int professorId);
    }
}
