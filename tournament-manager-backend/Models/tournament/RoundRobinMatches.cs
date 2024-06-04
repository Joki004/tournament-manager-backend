using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tournament_manager_backend.Models.tournament
{
    public class RoundRobinMatches
    {
        public RoundRobinMatches(int matchID, int tournamentID, int team1ID, int team2ID)
        {
            MatchID = matchID;
            TournamentID = tournamentID;
            Team1ID = team1ID;
            Team2ID = team2ID;
        }

        [Key]
        public int MatchID { get; set; }

        [Required]
        public int TournamentID { get; set; }

        [Required]
        public int Team1ID { get; set; }

        [Required]
        public int Team2ID { get; set; }

        public int? Team1Score { get; set; }
        public int? Team2Score { get; set; }
        public DateTime? MatchDate { get; set; }

        [ForeignKey("TournamentID")]
        public Tournaments? Tournament { get; set; }

        [ForeignKey("Team1ID")]
        public Teams? Team1 { get; set; }

        [ForeignKey("Team2ID")]
        public Teams? Team2 { get; set; }
    }
}
