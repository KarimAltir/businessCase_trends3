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
        public DbSet<buisnessCase_trends3.Models.Task> Task { get; set; } = default!;
    }
}
