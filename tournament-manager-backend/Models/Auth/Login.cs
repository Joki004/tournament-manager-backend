using System.ComponentModel.DataAnnotations;

namespace tournament_manager_backend.Models.Auth
{
    public class Login
    {
        [Required]
        public string UserNameOrEmail { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
