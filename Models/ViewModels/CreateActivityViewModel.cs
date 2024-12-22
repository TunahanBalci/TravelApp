using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelApp.Models.ViewModels
{
    public class CreateActivityViewModel
    {
        [Required(ErrorMessage = "Activity name is required.")]
        [MaxLength(100, ErrorMessage = "Activity name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [MaxLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        public string Type { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Range(0.00, 99999999.99, ErrorMessage = "Price must be a valid number.")]
        public decimal Price { get; set; }

        [Display(Name = "Requires Reservation")]
        public bool Requires_Reservation { get; set; }

        [Required(ErrorMessage = "At least one Destination is required.")]
        [Display(Name = "Destinations")]
        public List<Guid> Destination_IDs { get; set; } = new List<Guid>();

        // Dropdown Lists
        public List<SelectListItem> Destinations { get; set; } = new List<SelectListItem>();
    }
}
