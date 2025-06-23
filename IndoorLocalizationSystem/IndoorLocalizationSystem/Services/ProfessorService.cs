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

            if (string.IsNullOrWhiteSpace(professor.Name))
                throw new Exception("Professor name is required.");

            await _professorRepository.AddProfessorAsync(professor);
        }
        public async Task UpdateProfessorAsync(Professor professor)
        {
            var existing = await _professorRepository.GetProfessorByIdAsync(professor.Id);
            if (existing == null)
                throw new Exception("Professor not found.");

            await _professorRepository.UpdateProfessorAsync(professor);
        }
        public async Task DeleteProfessorAsync(int id)
        {
            var professor = await _professorRepository.GetProfessorByIdAsync(id);
            if (professor == null)
                throw new Exception("Professor not found.");

            if (professor.Courses != null && professor.Courses.Any())
                throw new Exception("Cannot delete a professor with assigned courses.");

            await _professorRepository.DeleteProfessorAsync(id);
        }

        // Business logic to get all courses taught by a specific professor
        public async Task<IEnumerable<Course>> GetCoursesTaughtByProfessorAsync(int professorId)
        {
            var professor = await _professorRepository.GetProfessorByIdAsync(professorId);
            if (professor == null)
                throw new Exception("Professor not found.");

            return professor.Courses;
        }



    }
}
