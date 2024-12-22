using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Models.Entities;

namespace TravelApp.Models.ViewModels
{
    public class CreateDestinationViewModel
    {
        // Destination Properties
        [Required(ErrorMessage = "Destination name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please select a city.")]
        public Guid CityID { get; set; }

        // Activities
        public List<Guid> SelectedActivityIds { get; set; } = new List<Guid>();

        // Single Attraction Input
        [Display(Name = "Attraction")]
        public string AttractionsInput { get; set; } // Single attraction input

        // For Dropdowns and Checkboxes
        public List<City> Cities { get; set; } = new List<City>();
        public List<Activity> Activities { get; set; } = new List<Activity>();
    }
}
