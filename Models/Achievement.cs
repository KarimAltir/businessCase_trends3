using System.ComponentModel.DataAnnotations;

namespace buisnessCase_trends3.Models
{
    public class Achievement
    {
        public int Id { get; set; } // Primary key

        [Required]
        [Display(Name = "Achievement Name")]
        public string Name { get; set; } // Name of the achievement

        [Display(Name = "Description")]
        public string Description { get; set; } // Description of the achievement

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Points")]
        public int Points { get; set; } // Points awarded for the achievement

        // Add this property to track claim status
        public bool IsClaimed { get; set; } = false;
    }
}
