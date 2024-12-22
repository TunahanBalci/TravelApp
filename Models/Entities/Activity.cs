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

        public ICollection<Destination> Destinations { get; set; } = new List<Destination>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public double? Average_Rating
        {
            get
            {
                if (Reviews != null && Reviews.Any(r => r.Rating.HasValue))
                {
                    return Reviews.Where(r => r.Rating.HasValue).Average(r => r.Rating.Value);
                }
                else
                {
                    return null; // Indicates no ratings available
                }
            }
        }

        public ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
    }
}
