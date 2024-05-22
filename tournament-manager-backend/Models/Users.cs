using System.ComponentModel.DataAnnotations;

namespace tournament_manager_backend.Models
{
    public class Users
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
