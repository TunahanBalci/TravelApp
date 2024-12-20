using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models.Entities
{
    public class Destination
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        public Guid User_ID { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<User> Visitor_History { get; set; } = new List<User>();

        public ICollection<Activity> Activities { get; set; } = new List<Activity>();

        public ICollection<string> Attractions { get; set; } = new List<string>();


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
}
