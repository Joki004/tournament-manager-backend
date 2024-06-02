namespace tournament_manager_backend.Models.Auth
{
    public class SystemUser
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public SystemUser(Guid userId, string userName, string email, string passwordHash)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
        }
        public SystemUser()
        {
            // Default constructor needed for Entity Framework Core
        }
    }
}
