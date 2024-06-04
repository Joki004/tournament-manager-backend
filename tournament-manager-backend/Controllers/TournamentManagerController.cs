using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using tournament_manager_backend.Data;
using tournament_manager_backend.Models.tournament;
namespace tournament_manager_backend.Controllers
{

    [ApiController]
    public class TournamentManagerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TournamentManagerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("Tournaments")]
        //[Authorize]
        public async Task<IActionResult> GetTournaments()
        {
            try
            {
                var tournaments = await _dbContext.Tournaments
                     .Select(t => new TournamentDto
                     {
                         TournamentID = t.TournamentID,
                         UserID = t.UserID,
                         TournamentName = t.TournamentName,
                         DisciplineID = t.DisciplineID,
                         TournamentTypeID = t.TournamentTypeID,
                         NumberOfTeams = t.NumberOfTeams,
                         StartDate = t.StartDate,
                         EndDate = t.EndDate,
                         WinnerTeamID = t.WinnerTeamID,
                         CreatedAt = t.CreatedAt
                     }).ToListAsync();
                var response = new ApiResponseTournament
                {
                    Status = 200,
                    IsSuccess = true,
                    Message = "Tournaments fetched successfully",
                    Table = tournaments
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetTournaments: {ex}");
                var errorResponse = new ApiResponseTournament
                {
                    Status = 500,
                    IsSuccess = false,
                    Message = "Internal server error",
                    Table = null
                };
                return StatusCode(500, errorResponse);
            }
        }




    }
}
