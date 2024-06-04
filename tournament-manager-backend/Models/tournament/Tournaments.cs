using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tournament_manager_backend.Models.Auth;

namespace tournament_manager_backend.Models.tournament
{
    public class Tournaments
    {
        public Tournaments()
        {
            BracketMatches = new HashSet<BracketMatches>();
            RoundRobinMatches = new HashSet<RoundRobinMatches>();
            Teams = new HashSet<Teams>();
        }

        [Key]
        public int TournamentID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string TournamentName { get; set; } = string.Empty;

        [Required]
        public int DisciplineID { get; set; }

        [Required]
        public int TournamentTypeID { get; set; }

        [Range(2, int.MaxValue)]
        public int NumberOfTeams { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public int? WinnerTeamID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserID")]
        public Users? User { get; set; }

        [ForeignKey("DisciplineID")]
        public Disciplines? Discipline { get; set; }

        [ForeignKey("TournamentTypeID")]
        public TournamentTypes? TournamentType { get; set; }

        [ForeignKey("WinnerTeamID")]
        public Teams? WinnerTeam { get; set; }

        // Navigation property
        public ICollection<Teams> Teams { get; set; }

        public ICollection<BracketMatches> BracketMatches { get; set; }
        public ICollection<RoundRobinMatches> RoundRobinMatches { get; set; }
    }

    public class TournamentDto
    {
        public int TournamentID { get; set; }
        public Guid UserID { get; set; }
        public string TournamentName { get; set; } = string.Empty;
        public int DisciplineID { get; set; }
        public int TournamentTypeID { get; set; }
        public int NumberOfTeams { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? WinnerTeamID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
