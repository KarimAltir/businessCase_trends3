using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buisnessCase_trends3.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int Points { get; set; }
        public bool? Completed { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public Task()
        {
        }
    }
}
