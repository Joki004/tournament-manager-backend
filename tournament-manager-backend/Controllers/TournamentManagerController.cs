using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace tournament_manager_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TournamentManagerController : ControllerBase
    {

        [HttpGet]
        [Route("Tournaments")]
        public IActionResult GetTournaments()
        {
            try
            {
                string query = "select * from dbo.Tournaments";
                DataTable table = new DataTable();
                string sqlDatasource = Environment.GetEnvironmentVariable("TournamentAppDBCon") ?? throw new InvalidOperationException("Connection string 'TournamentAppDBCon' is not configured.");
                Console.WriteLine($"Connecting to: {sqlDatasource}");

                using (SqlConnection myCon = new SqlConnection(sqlDatasource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {
                            table.Load(myReader);
                        }
                    }
                }

                return new JsonResult(table);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetTournaments: {ex}");
                throw;
            }
        }
    }
}
