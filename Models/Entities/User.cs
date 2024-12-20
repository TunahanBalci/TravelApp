using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }


        [Required]
        [StringLength(255, MinimumLength = 8)]

        public string? Password { get; set; }

        public ICollection<Review> Review_History { get; set; } = new List<Review>();

        public ICollection<Destination> Travel_History { get; set; } = new List<Destination>();

        public ICollection<String> Preferences { get; set; } = new List<String>();

        public ICollection<Accommodation> Booking_History { get; set; } = new List<Accommodation>();
    }

    public class User_Travel_History
    {
        [Required]
        public Guid User_ID { get; set; }

        [Required]
        public Guid Destination_ID { get; set; }

        [Required]
        public DateTime Visit_Date { get; set; } = DateTime.Now; // Default now

    }

    public class User_Destination
    {

        [Required]
        public Guid User_ID { get; set; }

        [Required]
        public Guid Destination_ID { get; set; }

        [Required]
        public bool Favorite { get; set; } = false;

        [Required]
        public bool Visited { get; set; } = false;
    }
}
