namespace tournament_manager_backend.Models.Auth
{
    public class Register
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Register(int userId, string userName, string passwordHash, string email)
        {
            UserId = userId;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        // Default constructor
        public Register()
        {

        }
    }
}
