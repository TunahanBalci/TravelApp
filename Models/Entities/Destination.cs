using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
        public Guid CityID { get; set; } // Foreign Key

        [ForeignKey("CityID")]
        [ValidateNever] // Prevent validation on the navigation property
        public City City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public ICollection<Attraction> Attractions { get; set; } = new List<Attraction>();

        public string Image_Path { get; set; } = string.Empty;

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
    }

    public class Attraction
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("Destination")]
        public Guid DestinationID { get; set; }

        public Destination Destination { get; set; }
    }
}
