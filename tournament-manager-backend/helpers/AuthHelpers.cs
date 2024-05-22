using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tournament_manager_backend.Models;
using tournament_manager_backend.Data;
namespace tournament_manager_backend.helpers
{
    public class AuthHelpers
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly string _jwtSecret;

        public AuthHelpers(ApplicationDbContext dbContext, string jwtSecret)
        {
            _dbContext = dbContext;
            _jwtSecret = jwtSecret;
        }

        public void RegisterUser(SystemUser newUser)

        {
            if (newUser.UserId == Guid.Empty)
            {
                newUser.UserId = Guid.NewGuid();
            }
            newUser.PasswordHash = HashPassword(newUser.PasswordHash);
            var user = new Users
            {
                UserId = newUser.UserId,
                UserName = newUser.UserName,
                Email = newUser.Email,
                PasswordHash = newUser.PasswordHash,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public bool AuthenticateUser(string userNameOrEmail, string password)
        {
            // Check if user exists based on UserName or Email
            var user = _dbContext.Users.FirstOrDefault(u =>
                u.UserName == userNameOrEmail || u.Email == userNameOrEmail);

            if (user == null)
            {
                return false; // User not found
            }

            // Validate password - You should implement your own password validation logic here
            bool isPasswordValid = VerifyPasswordHash(password, user.PasswordHash);

            return isPasswordValid;
        }


        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPasswordHash(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }

        public string GenerateJWTToken(SystemUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(_jwtSecret)
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
