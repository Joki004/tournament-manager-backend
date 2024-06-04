namespace tournament_manager_backend.Models.tournament
{
    public class ApiResponseTournament
    {
        public int Status { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<TournamentDto>? Table { get; set; }
    }

    public class ApiResponseDiscipline
    {
        public int Status { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<DisciplineDto>? Table { get; set; }
    }

    public class ApiResponseTournamentTypes
    {
        public int Status { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<TournamentTypeDto>? Table { get; set; }
    }
}
