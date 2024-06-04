using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tournament_manager_backend.Data;
using tournament_manager_backend.Models.tournament;

namespace tournament_manager_backend.Controllers
{
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public DisciplineController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("Discipline")]
        public async Task<IActionResult> GetAllDisciplines()
        {
            try
            {
                var disciplines = await _dbContext.Disciplines
                    .Select(d => new DisciplineDto
                    {
                        DisciplineID = d.DisciplineID,
                        DisciplineName = d.DisciplineName,
                        Description = d.Description,
                        PlayersPerTeam = d.PlayersPerTeam
                    }).ToListAsync();

                return Ok(new { status = 200, isSuccess = true, disciplines });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetAllDisciplines: {ex.Message}");
                return StatusCode(500, new { status = 500, isSuccess = false, message = "Internal server error" });
            }
        }

        [HttpGet]
        [Route("Discipline/{id}")]
        public async Task<IActionResult> GetDiscipline(int id)
        {
            var discipline = await _dbContext.Disciplines
                .FirstOrDefaultAsync(d => d.DisciplineID == id);

            if (discipline == null)
            {
                return NotFound();
            }

            var disciplineDto = new DisciplineDto
            {
                DisciplineID = discipline.DisciplineID,
                DisciplineName = discipline.DisciplineName,
                Description = discipline.Description,
                PlayersPerTeam = discipline.PlayersPerTeam
            };

            return Ok(disciplineDto);
        }
    }
}
