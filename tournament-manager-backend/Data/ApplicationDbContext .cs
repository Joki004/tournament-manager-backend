using Microsoft.EntityFrameworkCore;
using tournament_manager_backend.Models.Auth;
using tournament_manager_backend.Models.tournament;

namespace tournament_manager_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Disciplines> Disciplines { get; set; }
        public DbSet<TournamentTypes> TournamentTypes { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Tournaments> Tournaments { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<BracketMatches> BracketMatches { get; set; }
        public DbSet<RoundRobinMatches> RoundRobinMatches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Disable cascading delete for the problematic relationships

            modelBuilder.Entity<Tournaments>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tournaments)
                .HasForeignKey(t => t.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tournaments>()
                .HasOne(t => t.Discipline)
                .WithMany()
                .HasForeignKey(t => t.DisciplineID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tournaments>()
                .HasOne(t => t.TournamentType)
                .WithMany()
                .HasForeignKey(t => t.TournamentTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tournaments>()
                .HasOne(t => t.WinnerTeam)
                .WithMany()
                .HasForeignKey(t => t.WinnerTeamID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teams>()
                .HasOne(t => t.Tournament)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TournamentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BracketMatches>()
                .HasOne(bm => bm.Team1)
                .WithMany(t => t.BracketMatchesAsTeam1)
                .HasForeignKey(bm => bm.Team1ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BracketMatches>()
                .HasOne(bm => bm.Team2)
                .WithMany(t => t.BracketMatchesAsTeam2)
                .HasForeignKey(bm => bm.Team2ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BracketMatches>()
                .HasOne(bm => bm.WinnerTeam)
                .WithMany(t => t.BracketMatchesAsWinner)
                .HasForeignKey(bm => bm.WinnerTeamID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoundRobinMatches>()
                .HasOne(rrm => rrm.Team1)
                .WithMany(t => t.RoundRobinMatchesAsTeam1)
                .HasForeignKey(rrm => rrm.Team1ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoundRobinMatches>()
                .HasOne(rrm => rrm.Team2)
                .WithMany(t => t.RoundRobinMatchesAsTeam2)
                .HasForeignKey(rrm => rrm.Team2ID)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string? connectionString = Environment.GetEnvironmentVariable("TournamentAppDBCon");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Environment variable 'TournamentAppDBCon' is not configured.");
            }

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
