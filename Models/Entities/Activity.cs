using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models.Entities
{
    public class Activity
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public DateTime Date { get; set; }

        [Range(0.00, 99999999.99, ErrorMessage = "Invalid value (cannot be negative or too big).")]
        public decimal Price { get; set; }

        [Required]
        public bool Requires_Reservation { get; set; } = false;

        [Required]
        public Destination Destination { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public double Average_Rating
        {
            get
            {
                return Reviews != null && Reviews.Any()
                    ? Reviews.Average(r => r.Rating)
                    : 0.0;
            }
        }

        public ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
    }
}
