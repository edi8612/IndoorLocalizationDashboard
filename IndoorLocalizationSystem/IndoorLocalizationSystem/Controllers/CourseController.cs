using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndoorLocalizationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(string id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return course == null ? NotFound() : Ok(course);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            try
            {
                await _courseService.AddCourseAsync(course);
                return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(string id, [FromBody] Course course)
        {
            if (id != course.Id) return BadRequest("ID mismatch.");

            try
            {
                await _courseService.UpdateCourseAsync(course);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            try
            {
                await _courseService.DeleteCourseAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // Business logic to check if a professor can be assigned to a course
        [HttpGet("can-assign-professor/{professorId}")]
        public async Task<IActionResult> CanAssign(int professorId)
        {
            try
            {
                var allowed = await _courseService.CanAssignProfessorToCourseAsync(professorId);
                return Ok(new { professorId, allowed });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
