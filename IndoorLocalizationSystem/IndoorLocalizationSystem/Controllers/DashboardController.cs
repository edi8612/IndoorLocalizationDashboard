using IndoorLocalizationSystem.DTOs;
using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace IndoorLocalizationSystem.Controllers
{
    public class DashboardController : Controller
    {
      private readonly HttpClient _httpClient;
      private readonly IStudentService _studentService;
      private readonly ICourseService _courseService;

      public DashboardController(IHttpClientFactory httpClientFactory, IStudentService studentService, ICourseService courseService)
      {
            _httpClient = httpClientFactory.CreateClient("api");
            _studentService = studentService;
            _courseService = courseService;
      }


      public async Task<IActionResult> Students()
      {
            var students = await _httpClient.GetFromJsonAsync<List<StudentDTO>>("api/student");
            return View(students);
      }

      public async Task<IActionResult> Courses()
      {
            var courses = await _httpClient.GetFromJsonAsync<List<CourseDTO>>("api/course");
            return View(courses);
      }





        [HttpGet("/api/dashboard/daily-attendance")]
      public async Task<IActionResult> GetDailyAttendance()
      {
            var students = await _studentService.GetAllStudentsAsync();

            var stats = students
                .Where(s => s.Attended)
                .GroupBy(s => DateTime.Today.AddDays(-Random.Shared.Next(0, 7)).ToString("yyyy-MM-dd")) // Replace with real attendance date
                .Select(g => new AttendanceStatDTO
                {
                    Date = g.Key,
                    Count = g.Count()
                })
                .OrderBy(s => s.Date)
                .ToList();

            return Ok(stats);
      }


      [HttpGet("api/dashboard/students-per-course")]
      public async Task<IActionResult> GetStudentsPerCourseAsync()
      {
            var courseDTOs = await _courseService.GetStudentsPerCourseStatsAsync();

            var simplified = courseDTOs.Select(c => new {
                courseName = c.Name,
                studentCount = c.StudentCount
            });

            return Ok(simplified);
      }


        [HttpGet("api/dashboard/student-positions")]
        public async Task<IActionResult> GetStudentPositions()
        {
            var students = await _studentService.GetAllStudentsAsync(); // with PositionX/Y
            return Ok(students);
        }





    }
}
