using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Models.Entities;

namespace TravelApp.Models.ViewModels
{
    public class CreateAccommodationViewModel
    {
        // Accommodation Properties
        [Required(ErrorMessage = "Accommodation name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.00, 99999999.99, ErrorMessage = "Invalid value (cannot be negative or too big).")]
        public decimal Price { get; set; }

        [Display(Name = "Availability")]
        public bool Availability { get; set; } = true;

        [Required(ErrorMessage = "Please select a city.")]
        public Guid CityID { get; set; } // Foreign Key

        // For Dropdowns
        public List<City> Cities { get; set; } = new List<City>();

        // Additional Properties (e.g., Amenities) can be added here
    }
}
