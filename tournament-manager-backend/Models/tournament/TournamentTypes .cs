using System.ComponentModel.DataAnnotations;

namespace tournament_manager_backend.Models.tournament
{
    public class TournamentTypes
    {
        public TournamentTypes(int tournamentTypeID, string tournamentTypeName)
        {
            TournamentTypeID = tournamentTypeID;
            TournamentTypeName = tournamentTypeName;
        }

        [Key]
        public int TournamentTypeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string TournamentTypeName { get; set; }

        public string? Description { get; set; }
    }

    public class TournamentTypeDto
    {
        public int TournamentTypeID { get; set; }
        public string TournamentTypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
