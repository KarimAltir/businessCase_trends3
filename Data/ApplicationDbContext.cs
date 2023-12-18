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

            if (!context.Task.Any())
            {
                List<Models.Task> tasks = new()
                    {
                        new Models.Task() { TaskName = "Defeat the Bug Monster", TaskDescription = "Find and fix all bugs in the code.", Points = 50, Completed = false },
                        new Models.Task() { TaskName = "Solve the Debugging Maze", TaskDescription = "Navigate through the code maze and find the solution to a specific problem.", Points = 55, Completed = false },
                        new Models.Task() { TaskName = "Collect Refactoring Treasures", TaskDescription = "Improve existing code to make it more efficient and elegant.", Points = 60, Completed = false},
                        new Models.Task() { TaskName = "Conquer the Final Boss of Deployment", TaskDescription = "Successfully deploy the latest version of the application to production.", Points = 65, Completed = false },
                        new Models.Task() { TaskName = "Ascend the Pull Request Mountain", TaskDescription = "Complete and merge your pull request with the main branch of the repository.", Points = 70, Completed = false },
                        new Models.Task() { TaskName = "Discover the Performance Chest", TaskDescription = "Optimize the performance of a critical application function.", Points = 75, Completed = false },
                        new Models.Task() { TaskName = "Win the Unit Testing Race", TaskDescription = "Write unit tests for all significant functions of the application.", Points = 80, Completed = false },
                        new Models.Task() { TaskName = "Create a Documentation Spell", TaskDescription = "Document an important part of the code to facilitate understanding.", Points = 85, Completed = false },
                        new Models.Task() { TaskName = "Challenge the Continuous Integration Dragon", TaskDescription = "Set up a continuous integration pipeline to automate testing and deployments.", Points = 90, Completed = false },
                        new Models.Task() { TaskName = "Master the Art of Code Review", TaskDescription = "Review and provide constructive feedback on a teammate's code.", Points = 95, Completed = false },
                        new Models.Task() { TaskName = "Build the Castle of New Features", TaskDescription = "Add an exciting new feature to the application.", Points = 100, Completed = false },
                        new Models.Task() { TaskName = "Celebrate the Successful Delivery Festival", TaskDescription = "Celebrate a successful implementation with your team and users.", Points = 105, Completed = false },
                        new Models.Task() { TaskName = "Explore the Forest of Continuous Learning", TaskDescription = "Dedicate time to learning a new technology or skill.", Points = 110, Completed = false }
                    };

                context.Task.AddRange(tasks);
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
