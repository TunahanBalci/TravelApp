﻿// Models/ViewModels/CreateReviewViewModel.cs
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models.ViewModels
{
    public class CreateReviewViewModel
    {
        [Required(ErrorMessage = "Rating is required.")]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }

        [MaxLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters.")]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "Entity Type is required.")]
        [RegularExpression("^(Destination|Accommodation|Activity)$", ErrorMessage = "Invalid Entity Type. Allowed values: 'Destination', 'Accommodation', 'Activity'.")]
        public string EntityType { get; set; }

        [Required(ErrorMessage = "Entity selection is required.")]
        public Guid EntityID { get; set; }

        [Required(ErrorMessage = "User selection is required.")]
        public Guid UserID { get; set; }
        public List<SelectListItem> Users { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Destinations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Accommodations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Activities { get; set; } = new List<SelectListItem>();
    }
}
