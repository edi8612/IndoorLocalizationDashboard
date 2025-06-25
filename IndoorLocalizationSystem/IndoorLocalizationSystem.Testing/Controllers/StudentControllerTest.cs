using IndoorLocalizationSystem.Controllers;
using IndoorLocalizationSystem.Data;
using IndoorLocalizationSystem.DTOs;
using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Repositories;
using IndoorLocalizationSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;

namespace IndoorLocalizationSystem.Testing.Controllers
{
    public class StudentControllerTests
    {
        private readonly Mock<IStudentService> _mockService;
        private readonly StudentController _controller;

        public StudentControllerTests()
        {
            _mockService = new Mock<IStudentService>();
            _controller = new StudentController(_mockService.Object);
        }

        [Fact]
        public async Task GetStudentById_ReturnsOk_WhenStudentExists()
        {
            var studentDto = new StudentDTO { Id = 1, Name = "Alice" };
            _mockService.Setup(s => s.GetStudentByIdAsync(1)).ReturnsAsync(studentDto);

            var result = await _controller.GetStudentById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedStudent = Assert.IsType<StudentDTO>(okResult.Value);
            Assert.Equal("Alice", returnedStudent.Name);
        }

        [Fact]
        public async Task GetStudentById_ReturnsNotFound_WhenStudentDoesNotExist()
        {
            _mockService.Setup(s => s.GetStudentByIdAsync(1)).ReturnsAsync((StudentDTO)null!);

            var result = await _controller.GetStudentById(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAllStudents_ReturnsOk_WithListOfStudents()
        {
            var students = new List<StudentDTO> {
        new StudentDTO { Id = 1, Name = "Alice" }
    };

            _mockService.Setup(s => s.GetAllStudentsAsync()).ReturnsAsync(students);

            var result = await _controller.GetAllStudents();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var list = Assert.IsAssignableFrom<IEnumerable<StudentDTO>>(okResult.Value);
            Assert.Single(list);
        }

        [Fact]
        public async Task AddStudent_ReturnsCreatedAt_WhenValid()
        {
            var student = new Student { Id = 1, Name = "Alice" };

            var result = await _controller.AddStudent(student);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedStudent = Assert.IsType<Student>(createdResult.Value);
            Assert.Equal("Alice", returnedStudent.Name);
        }

        [Fact]
        public async Task UpdateStudent_ReturnsNoContent_WhenSuccess()
        {
            var student = new Student { Id = 1, Name = "Updated" };

            var result = await _controller.UpdateStudent(1, student);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateStudent_ReturnsBadRequest_WhenIdMismatch()
        {
            var student = new Student { Id = 2, Name = "Mismatch" };

            var result = await _controller.UpdateStudent(1, student);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("ID mismatch.", badRequest.Value);
        }

        [Fact]
        public async Task DeleteStudent_ReturnsNoContent_WhenSuccess()
        {
            var result = await _controller.DeleteStudent(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task EnrollInDefaults_ReturnsOk_WhenSuccess()
        {
            var result = await _controller.EnrollInDefaults(1, "1");

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Student enrolled in default courses.", okResult.Value);
        }
    }
}