using System.ComponentModel.DataAnnotations;

namespace tournament_manager_backend.Models.tournament
{
    public class Disciplines
    {
        public Disciplines(int disciplineID, string disciplineName, int playersPerTeam)
        {
            DisciplineID = disciplineID;
            DisciplineName = disciplineName;
            PlayersPerTeam = playersPerTeam;
        }

        [Key]
        public int DisciplineID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DisciplineName { get; set; }

        public string? Description { get; set; }

        [Range(1, int.MaxValue)]
        public int PlayersPerTeam { get; set; }
    }

    public class DisciplineDto
    {
        public int DisciplineID { get; set; }
        public string DisciplineName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int PlayersPerTeam { get; set; }
    }
}
