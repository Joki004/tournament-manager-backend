using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tournament_manager_backend.Models.tournament
{
    public class Teams
    {
        public Teams()
        {
            BracketMatchesAsTeam1 = new HashSet<BracketMatches>();
            BracketMatchesAsTeam2 = new HashSet<BracketMatches>();
            BracketMatchesAsWinner = new HashSet<BracketMatches>();
            RoundRobinMatchesAsTeam1 = new HashSet<RoundRobinMatches>();
            RoundRobinMatchesAsTeam2 = new HashSet<RoundRobinMatches>();
        }

        [Key]
        public int TeamID { get; set; }

        [Required]
        public int TournamentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string TeamName { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int MatchesPlayed { get; set; }

        [ForeignKey("TournamentID")]
        public Tournaments? Tournament { get; set; }

        public ICollection<BracketMatches> BracketMatchesAsTeam1 { get; set; }
        public ICollection<BracketMatches> BracketMatchesAsTeam2 { get; set; }
        public ICollection<BracketMatches> BracketMatchesAsWinner { get; set; }
        public ICollection<RoundRobinMatches> RoundRobinMatchesAsTeam1 { get; set; }
        public ICollection<RoundRobinMatches> RoundRobinMatchesAsTeam2 { get; set; }
    }
}
