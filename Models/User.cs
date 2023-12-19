using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buisnessCase_trends3.Models
{
    public class User
    {
        //generate a number of variables for the user. besides the obvious Id, username and password, we must also need a point counter.   
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Points { get; set; } = 0;

        public LeaderboardEntry LeaderboardEntry { get; set; }

        public ICollection<Task> CompletedTasks { get; set; } = new List<Task>();

        public ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
    }
}
