using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tournament_manager_backend.Data;
using tournament_manager_backend.helpers;
using tournament_manager_backend.Models.Auth;

namespace tournament_manager_backend.Controllers
{

    [ApiController]
    public class AuthController : Controller
    {
        private readonly AuthHelpers _authHelpers;
        private readonly ApplicationDbContext _dbContext;
        public AuthController(AuthHelpers authHelpers, ApplicationDbContext dbContext)
        {
            _authHelpers = authHelpers;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser([FromBody] SystemUser newUser)
        {
            try
            {
                _authHelpers.RegisterUser(newUser);
                string jwtToken = _authHelpers.GenerateJWTToken(newUser);

                var userDetails = new
                {
                    UserId = newUser.UserId,
                    Email = newUser.Email,
                    UserName = newUser.UserName,
                    // Add ProfilePicture if you have it
                    // ProfilePicture = newUser.ProfilePicture
                };


                return Ok(new { status = 200, isSuccess = true, message = "User Login successfully", UserDetails = userDetails, token = jwtToken });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in RegisterUser: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error registering user");
            }
        }

        [HttpPost]
        [Route("isTokenValid")]
        public IActionResult IsTokenValid([FromBody] TokenRequest request)
        {
            try
            {
                var (isValid, user) = _authHelpers.IsTokenValid(request.Token);
                return Ok(new { status = 200, isValid, user });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in IsTokenValid: {ex.Message}");
                return StatusCode(500, new { status = 500, isValid = false, message = "Internal server error" });
            }
        }

        [HttpGet]
        [Route("user")]
        [Authorize]
        public IActionResult GetUser(string userID)
        {
            try
            {
                // Check if the userID is provided
                if (string.IsNullOrWhiteSpace(userID))
                {
                    return BadRequest(new { status = 400, isSuccess = false, message = "User ID is required" });
                }

                // Find the user by userID
                var user = _dbContext.Users.FirstOrDefault(u => u.UserId.ToString() == userID);

                // Check if the user exists
                if (user == null)
                {
                    return NotFound(new { status = 404, isSuccess = false, message = "User not found" });
                }

                // Create a response object with necessary user information
                var userDetails = new
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    UserName = user.UserName,
                    // Include other necessary fields, e.g., ProfilePicture
                    // ProfilePicture = user.ProfilePicture
                };

                return Ok(new { status = 200, isSuccess = true, userDetails });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetUser: {ex.Message}");
                return StatusCode(500, new { status = 500, isSuccess = false, message = "Internal server error" });
            }
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(Login logins)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u =>
                     u.UserName == logins.UserNameOrEmail || u.Email == logins.UserNameOrEmail);

                if (user == null)
                {
                    return Unauthorized(new { status = 401, isSuccess = false, message = "Invalid credentials" });
                }

                if (!_authHelpers.VerifyPasswordHash(logins.Password, user.PasswordHash))
                {
                    return Unauthorized(new { status = 401, isSuccess = false, message = "Invalid credentials" });
                }

                SystemUser systemUser = new SystemUser
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                };

                string jwtToken = _authHelpers.GenerateJWTToken(systemUser);

                var UserDetails = new
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    UserName = user.UserName,
                    // Include other necessary fields, e.g., ProfilePicture
                    // ProfilePicture = user.ProfilePicture
                };

                return Ok(new { status = 200, isSuccess = true, message = "User Login successfully", UserDetails, token = jwtToken });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Login: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error during login");
            }
        }


    }
}
