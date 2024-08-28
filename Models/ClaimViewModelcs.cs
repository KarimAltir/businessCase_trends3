using System.Collections.Generic;

namespace buisnessCase_trends3.Models
{
    public class ClaimViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Achievement> Achievements { get; set; }
    }
}
