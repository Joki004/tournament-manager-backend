using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using tournament_manager_backend.Models.tournament;

namespace tournament_manager_backend.Models.Auth
{
    public class Users
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public ICollection<Tournaments> Tournaments { get; set; } = new HashSet<Tournaments>();

        public Users(Guid userId, string userName, string email, string passwordHash)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
        }

        public Users()
        {
            // Default constructor needed for Entity Framework Core
            UserName = string.Empty;
            Email = string.Empty;
            PasswordHash = string.Empty;
            CreatedAt = DateTime.UtcNow;
            Tournaments = new HashSet<Tournaments>();
        }
    }
}
