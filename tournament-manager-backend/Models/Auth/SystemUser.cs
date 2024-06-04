using System.ComponentModel.DataAnnotations;

namespace tournament_manager_backend.Models.Auth
{
    public class SystemUser
    {
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
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
            UserName = string.Empty;
            Email = string.Empty;
            PasswordHash = string.Empty;
        }
    }
}
