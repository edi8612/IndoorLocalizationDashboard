using IndoorLocalizationSystem.Controllers;
using IndoorLocalizationSystem.Data;
using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Repositories;
using IndoorLocalizationSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;

namespace IndoorLocalizationSystem.Testing.Repositories
{
    public class StudentRepositoryTests
    {
        private readonly AppDbContext _context;
        private readonly StudentRepository _repository;

        public StudentRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestStudentDb")
                .Options;

            _context = new AppDbContext(options);
            _repository = new StudentRepository(_context);

            SeedData();
        }

        private void SeedData()
        {
            if (!_context.Students.Any())
            {
                var user1 = new User { Id = 1, Email = "alice@example.com", Username = "alice", Role = "Student" };
                var user2 = new User { Id = 2, Email = "bob@example.com", Username = "bob", Role = "Student" };

                _context.Users.AddRange(user1, user2);

                _context.Students.AddRange(
                    new Student { Id = 1, Name = "Alice", UserId = 1, User = user1, Attended = true },
                    new Student { Id = 2, Name = "Bob", UserId = 2, User = user2, Attended = false }
                );
                _context.SaveChanges();
            }
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsCorrectStudent()
        {
            var student = await _repository.GetStudentByIdAsync(1);
            Assert.NotNull(student);
            Assert.Equal("Alice", student.Name);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllStudents()
        {
            var students = await _repository.GetAllStudentsAsync();
            Assert.Equal(2, students.Count());
        }

        [Fact]
        public async Task AddAsync_AddsStudentSuccessfully()
        {
            var user = new User { Id = 3, Email = "charlie@example.com", Username = "charlie", Role = "Student" };
            _context.Users.Add(user);

            var newStudent = new Student { Id = 3, Name = "Charlie", UserId = 3, User = user, Attended = false };
            await _repository.AddStudentAsync(newStudent);
            await _context.SaveChangesAsync();

            var students = await _repository.GetAllStudentsAsync();
            Assert.Equal(3, students.Count());
        }

        [Fact]
        public async Task Update_UpdatesStudentSuccessfully()
        {
            var student = await _repository.GetStudentByIdAsync(1);
            student.Name = "Alice Updated";
            await _repository.UpdateStudentAsync(student);
            await _context.SaveChangesAsync();

            var updatedStudent = await _repository.GetStudentByIdAsync(1);
            Assert.Equal("Alice Updated", updatedStudent.Name);
        }

        [Fact]
        public async Task Delete_RemovesStudentSuccessfully()
        {
            var student = await _repository.GetStudentByIdAsync(2);
            await _repository.DeleteStudentAsync(student.Id);
            await _context.SaveChangesAsync();

            var students = await _repository.GetAllStudentsAsync();
            Assert.Single(students);
        }

    }
}