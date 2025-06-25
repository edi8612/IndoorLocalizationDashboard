using AutoMapper;
using IndoorLocalizationSystem.Data;
using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Repositories;
using IndoorLocalizationSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;

namespace IndoorLocalizationSystem.Testing.Services
{
    public class StudentServiceTest
    {
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly StudentService _studentService;
        private readonly Mock<IStudentRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly StudentService _service;
        public StudentServiceTest()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _mockRepo = new Mock<IStudentRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new StudentService(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetStudentByIdAsync_ReturnsCorrectStudent()
        {
            var student = new Student { Id = 1, Name = "Alice" };
            _studentRepositoryMock.Setup(repo => repo.GetStudentByIdAsync(1)).ReturnsAsync(student);

            var result = await _studentService.GetStudentByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Alice", result.Name);
        }

        [Fact]
        public async Task GetAllStudentsAsync_ReturnsAllStudents()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice" },
                new Student { Id = 2, Name = "Bob" }
            };
            _studentRepositoryMock.Setup(repo => repo.GetAllStudentsAsync()).ReturnsAsync(students);

            var result = await _studentService.GetAllStudentsAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task AddStudentAsync_AddsStudent()
        {
            var newStudent = new Student { Id = 3, Name = "Charlie" };
            _studentRepositoryMock.Setup(repo => repo.AddStudentAsync(newStudent)).Returns(Task.CompletedTask);

            await _studentService.AddStudentAsync(newStudent);

            _studentRepositoryMock.Verify(repo => repo.AddStudentAsync(newStudent), Times.Once);
        }

        [Fact]
        public async Task UpdateStudentAsync_UpdatesStudent()
        {
            var student = new Student { Id = 1, Name = "Updated" };
            _studentRepositoryMock.Setup(repo => repo.UpdateStudentAsync(student)).Returns(Task.CompletedTask);

            await _studentService.UpdateStudentAsync(student);

            _studentRepositoryMock.Verify(repo => repo.UpdateStudentAsync(student), Times.Once);
        }

        [Fact]
        public async Task DeleteStudentAsync_DeletesStudent()
        {
            var student = new Student { Id = 1, Name = "ToDelete" };
            _studentRepositoryMock.Setup(repo => repo.DeleteStudentAsync(student.Id)).Returns(Task.CompletedTask);

            await _studentService.DeleteStudentAsync(student.Id);

            _studentRepositoryMock.Verify(repo => repo.DeleteStudentAsync(student.Id), Times.Once);
        }
    }
}