using AutoMapper;
using IndoorLocalizationSystem.DTOs;
using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Repositories;

namespace IndoorLocalizationSystem.Services
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }


        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {

            var student = await _studentRepository.GetStudentByIdAsync(id);
            return _mapper.Map<StudentDTO>(student); 
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return _mapper.Map<List<StudentDTO>>(students); 
        }






        public async Task AddStudentAsync(Student student)
        {
            if(string.IsNullOrWhiteSpace(student.Name))
            {
                throw new ArgumentException("Student name cannot be null or empty.", nameof(student.Name));
            }
            await _studentRepository.AddStudentAsync(student);
        }
        public async Task UpdateStudentAsync(Student student)
        {
            var existing = await _studentRepository.GetStudentByIdAsync(student.Id);
            if (existing == null)
                throw new Exception("Student does not exist.");

            await _studentRepository.UpdateStudentAsync(student);
        }
        public async Task DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
                throw new Exception("Student not found.");

            if (student.Courses != null && student.Courses.Any())
                throw new Exception("Cannot delete a student assigned to courses.");

            await _studentRepository.DeleteStudentAsync(id);
        }


        //Business logic to enroll a student in their default courses based on their classroom
        public async Task EnrollSudentInDefaultCourseAsync(int studentId, string courseId)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentId);
            if (student == null)
                throw new Exception("Student not found.");

           
            var defaultCourses = student.Courses?.Where(c => c.ClassroomId == student.ClassroomId).ToList();
            if (defaultCourses == null || !defaultCourses.Any())
                throw new Exception("No default courses found for student's classroom.");

            student.Courses = defaultCourses;
            await _studentRepository.UpdateStudentAsync(student);
        }
    }
}
