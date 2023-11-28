using System.ComponentModel.DataAnnotations.Schema;

namespace buisnessCase_trends3.Models
{
    public class LeaderboardEntry
    {
        public int Id { get; set; }
        public int Points { get; set; } = 0;

        [NotMapped]
        public int Rank { get; set; } = 0;

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
