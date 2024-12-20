using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models.Entities
{
    public class Accommodation
    {

        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }


        [Required]
        [Range(0.00, 99999999.99, ErrorMessage = "Invalid value (cannot be negative or too big).")]
        public decimal Price { get; set; }

        [Required]
        public bool Availability { get; set; } = true;

        [Required]
        public City City { get; set; }  

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public ICollection<Activity> Activities { get; set; } = new List<Activity>();

        public ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();

        public double Average_Rating
        {
            get
            {
                return Reviews != null && Reviews.Any()
                    ? Reviews.Average(r => r.Rating)
                    : 0.0;
            }
        }

    }

    public class Amenity
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
    }

    public class Booking
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Accommodation Accommodation { get; set; }

        [Required]
        public DateTime Start_Date { get; set; }

        [Required]
        public DateTime End_Date { get; set; }

        [Required]
        public DateTime Booking_Date { get; set; } = DateTime.Now;

    }
}
