using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tournament_manager_backend.Data;
using tournament_manager_backend.Models.tournament;
namespace tournament_manager_backend.Controllers
{
    public class TournamentTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TournamentTypesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("TournamentTypes")]
        [HttpGet]
        public async Task<IActionResult> GetAllTournamentTypes()
        {
            try
            {
                var tournamentTypes = await _dbContext.TournamentTypes
                    .Select(t => new TournamentTypeDto
                    {
                        TournamentTypeID = t.TournamentTypeID,
                        TournamentTypeName = t.TournamentTypeName,
                        Description = t.Description
                    }).ToListAsync();

                return Ok(new { status = 200, isSuccess = true, tournamentTypes });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetAllTournamentTypes: {ex.Message}");
                return StatusCode(500, new { status = 500, isSuccess = false, message = "Internal server error" });
            }
        }
        [HttpGet]
        [Route("TournamentTypes/{id}")]
        public async Task<IActionResult> GetTournamentType(int id)
        {
            try
            {
                var tournamentType = await _dbContext.TournamentTypes
                    .FirstOrDefaultAsync(t => t.TournamentTypeID == id);

                if (tournamentType == null)
                {
                    return NotFound(new { status = 404, isSuccess = false, message = "Tournament type not found" });
                }

                var tournamentTypeDto = new TournamentTypeDto
                {
                    TournamentTypeID = tournamentType.TournamentTypeID,
                    TournamentTypeName = tournamentType.TournamentTypeName,
                    Description = tournamentType.Description
                };

                return Ok(new { status = 200, isSuccess = true, tournamentType = tournamentTypeDto });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetTournamentType: {ex.Message}");
                return StatusCode(500, new { status = 500, isSuccess = false, message = "Internal server error" });
            }
        }
    }
}
