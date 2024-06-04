using System.ComponentModel.DataAnnotations;

namespace tournament_manager_backend.Models.Auth
{
    public class TokenRequest
    {
        [Required]
        public string Token { get; set; } = string.Empty;
    }
}
