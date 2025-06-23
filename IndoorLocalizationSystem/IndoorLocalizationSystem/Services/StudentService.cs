using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Repositories;

namespace IndoorLocalizationSystem.Services
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }
        public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddStudentAsync(student);
        }
        public async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateStudentAsync(student);
        }
        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
        }
    }
}
