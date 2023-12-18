using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using buisnessCase_trends3.Models;
using Task = buisnessCase_trends3.Models.Task;

namespace buisnessCase_trends3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Task { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<LeaderboardEntry> LeaderboardEntries { get; set; } = default!;

        public static void DataInitializer(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                List<User> users = new()
                {
                    new () { Username = "JohnDoe", Password = "admin", LeaderboardEntry = new LeaderboardEntry() { Points = 777} },
                    new () { Username = "JaneDoe", Password = "admin", LeaderboardEntry = new LeaderboardEntry() { Points = 500} },
                    new () { Username = "JohnSmith", Password = "admin", LeaderboardEntry = new LeaderboardEntry() { Points = 90} },
                    new () { Username = "JaneSmith", Password = "admin", LeaderboardEntry = new LeaderboardEntry() { Points = 0} },
                    new () { Username = "MikeSmith", Password = "admin", LeaderboardEntry = new LeaderboardEntry() { Points = 0} }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            if (!context.Task.Any())
            {
                List<Models.Task> tasks = new()
                {
                    new () { TaskName = "Defeat the Bug Monster", TaskDescription = "Find and fix all bugs in the code.", Points = 50 },
                    new () { TaskName = "Solve the Debugging Maze", TaskDescription = "Navigate through the code maze and find the solution to a specific problem.", Points = 55 },
                    new () { TaskName = "Collect Refactoring Treasures", TaskDescription = "Improve existing code to make it more efficient and elegant.", Points = 6 },
                    new () { TaskName = "Conquer the Final Boss of Deployment", TaskDescription = "Successfully deploy the latest version of the application to production.", Points = 65 },
                    new () { TaskName = "Ascend the Pull Request Mountain", TaskDescription = "Complete and merge your pull request with the main branch of the repository.", Points = 70 },
                    new () { TaskName = "Discover the Performance Chest", TaskDescription = "Optimize the performance of a critical application function.", Points = 75 },
                    new () { TaskName = "Win the Unit Testing Race", TaskDescription = "Write unit tests for all significant functions of the application.", Points = 80 },
                    new () { TaskName = "Create a Documentation Spell", TaskDescription = "Document an important part of the code to facilitate understanding.", Points = 85 },
                    new () { TaskName = "Challenge the Continuous Integration Dragon", TaskDescription = "Set up a continuous integration pipeline to automate testing and deployments.", Points = 90 },
                    new () { TaskName = "Master the Art of Code Review", TaskDescription = "Review and provide constructive feedback on a teammate's code.", Points = 95 },
                    new () { TaskName = "Build the Castle of New Features", TaskDescription = "Add an exciting new feature to the application.", Points = 100 },
                    new () { TaskName = "Celebrate the Successful Delivery Festival", TaskDescription = "Celebrate a successful implementation with your team and users.", Points = 105 },
                    new () { TaskName = "Explore the Forest of Continuous Learning", TaskDescription = "Dedicate time to learning a new technology or skill.", Points = 11 }
                };

                context.Task.AddRange(tasks);
                context.SaveChanges();
            }
        }
    }
}
