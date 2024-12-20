using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models.Entities
{
    public class Review
    {
        public Guid ID { get; set; }

        [Range(0,5, ErrorMessage = "Invalid rating (Must be between 0 and 5).")]
        public int Rating { get; set; }


        [Required]
        public User User { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }


        [Required]
        public Guid Entity_ID { get; set; } // polymorphic 


        [RegularExpression("^(Destination|Accommodation|Activity)$", ErrorMessage = "Invalid Entity Type. Allowed values: 'Destination', 'Accommodation', 'Activity'")]
        [Required]
        public string Entity_Type { get; set; } // polymorphic

    }
}
