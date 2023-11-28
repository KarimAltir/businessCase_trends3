using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using buisnessCase_trends3.Models;

namespace buisnessCase_trends3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Task> Task { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<LeaderboardEntry> LeaderboardEntries { get; set; } = default!;

        public static void DataInitializer(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                List<User> users = new()
                {
                    new User() { Username = "JohnDoe", Password = "admin" },
                    new User() { Username = "JaneDoe", Password = "admin" },
                    new User() { Username = "JohnSmith", Password = "admin" },
                    new User() { Username = "JaneSmith", Password = "admin" },
                    new User() { Username = "MikeSmith", Password = "admin" }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            //assign a leaderboard entry to each user
            if (!context.LeaderboardEntries.Any()) //(Copilot generated)
            {
                List<LeaderboardEntry> leaderboardEntries = new()
                {
                    new LeaderboardEntry() { UserId = 1, Points = 25 },
                    new LeaderboardEntry() { UserId = 2, Points = 130 },
                    new LeaderboardEntry() { UserId = 3, Points = 500 },
                    new LeaderboardEntry() { UserId = 4, Points = 0 },
                    new LeaderboardEntry() { UserId = 5, Points = 0 }
                };

                context.LeaderboardEntries.AddRange(leaderboardEntries);
                context.SaveChanges();
            }
        }
    }
}
