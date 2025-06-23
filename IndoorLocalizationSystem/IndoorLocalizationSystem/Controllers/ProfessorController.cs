using IndoorLocalizationSystem.Models;
using IndoorLocalizationSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndoorLocalizationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _professorService.GetAllProfessorsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var prof = await _professorService.GetProfessorByIdAsync(id);
            return prof == null ? NotFound() : Ok(prof);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Professor professor)
        {
            try
            {
                await _professorService.AddProfessorAsync(professor);
                return CreatedAtAction(nameof(GetById), new { id = professor.Id }, professor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Professor professor)
        {
            if (id != professor.Id) return BadRequest("ID mismatch.");

            try
            {
                await _professorService.UpdateProfessorAsync(professor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _professorService.DeleteProfessorAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get all courses taught by professor
        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetCourses(int id)
        {
            try
            {
                var courses = await _professorService.GetCoursesTaughtByProfessorAsync(id);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
