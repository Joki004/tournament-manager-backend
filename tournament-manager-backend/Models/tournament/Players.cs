using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tournament_manager_backend.Models.tournament
{
    public class Players
    {
        public Players(int playerID, int teamID, string playerName)
        {
            PlayerID = playerID;
            TeamID = teamID;
            PlayerName = playerName;
        }

        [Key]
        public int PlayerID { get; set; }

        [Required]
        public int TeamID { get; set; }

        [Required]
        [MaxLength(100)]
        public string PlayerName { get; set; }

        [ForeignKey("TeamID")]
        public Teams? Team { get; set; }
    }
}
