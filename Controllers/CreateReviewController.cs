// Controllers/CreateReviewController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models.Entities;
using TravelApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Controllers
{
    public class CreateReviewController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILogger<CreateReviewController> _logger;

        public CreateReviewController(AppDBContext context, ILogger<CreateReviewController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: CreateReview/Create
        public async Task<IActionResult> CreateReview()
        {
            var model = new CreateReviewViewModel
            {
                Users = await _context.Users
                    .Select(u => new SelectListItem
                    {
                        Value = u.ID.ToString(),
                        Text = $"{u.Name} (ID: {u.ID})"
                    })
                    .ToListAsync(),

                Destinations = await _context.Destinations
                    .Select(d => new SelectListItem
                    {
                        Value = d.ID.ToString(),
                        Text = $"{d.Name} (ID: {d.ID})"
                    })
                    .ToListAsync(),

                Accommodations = await _context.Accommodations
                    .Select(a => new SelectListItem
                    {
                        Value = a.ID.ToString(),
                        Text = $"{a.Name} (ID: {a.ID})"
                    })
                    .ToListAsync(),

                Activities = await _context.Activities
                    .Select(a => new SelectListItem
                    {
                        Value = a.ID.ToString(),
                        Text = $"{a.Name} (ID: {a.ID})"
                    })
                    .ToListAsync()
            };

            return View(model);
        }

        // POST: CreateReview/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(CreateReviewViewModel model)
        {
            _logger.LogInformation("CreateReview POST method invoked.");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is invalid.");
                // Reload dropdowns
                model.Users = await _context.Users
                    .Select(u => new SelectListItem
                    {
                        Value = u.ID.ToString(),
                        Text = $"{u.Name} (ID: {u.ID})"
                    })
                    .ToListAsync();

                model.Destinations = await _context.Destinations
                    .Select(d => new SelectListItem
                    {
                        Value = d.ID.ToString(),
                        Text = $"{d.Name} (ID: {d.ID})"
                    })
                    .ToListAsync();

                model.Accommodations = await _context.Accommodations
                    .Select(a => new SelectListItem
                    {
                        Value = a.ID.ToString(),
                        Text = $"{a.Name} (ID: {a.ID})"
                    })
                    .ToListAsync();

                model.Activities = await _context.Activities
                    .Select(a => new SelectListItem
                    {
                        Value = a.ID.ToString(),
                        Text = $"{a.Name} (ID: {a.ID})"
                    })
                    .ToListAsync();

                return View(model);
            }

            try
            {
                var user = await _context.Users.FindAsync(model.UserID);
                if (user == null)
                {
                    throw new Exception("Selected user does not exist.");
                }

                var review = new Review
                {
                    ID = Guid.NewGuid(),
                    Rating = model.Rating,
                    Comment = model.Comment,
                    UserID = model.UserID,
                    User = user
                };

                switch (model.Entity_Type)
                {
                    case "Destination":
                        var destination = await _context.Destinations
                            .Include(d => d.Reviews)
                            .FirstOrDefaultAsync(d => d.ID == model.Entity_ID);
                        if (destination == null)
                        {
                            throw new Exception("Selected destination does not exist.");
                        }
                        review.DestinationID = destination.ID;
                        destination.Reviews.Add(review);
                        break;

                    case "Accommodation":
                        var accommodation = await _context.Accommodations
                            .Include(a => a.Reviews)
                            .FirstOrDefaultAsync(a => a.ID == model.Entity_ID);
                        if (accommodation == null)
                        {
                            throw new Exception("Selected accommodation does not exist.");
                        }
                        review.AccommodationID = accommodation.ID;
                        accommodation.Reviews.Add(review);
                        break;

                    case "Activity":
                        var activity = await _context.Activities
                            .Include(a => a.Reviews)
                            .FirstOrDefaultAsync(a => a.ID == model.Entity_ID);
                        if (activity == null)
                        {
                            throw new Exception("Selected activity does not exist.");
                        }
                        review.ActivityID = activity.ID;
                        activity.Reviews.Add(review);
                        break;

                    default:
                        throw new Exception("Invalid Entity Type.");
                }

                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Review saved successfully.");
                return RedirectToAction("Create", "AdminPanel");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while creating review: {ex.Message}");
                ModelState.AddModelError("", $"Error: {ex.Message}");

                // Reload dropdowns
                model.Users = await _context.Users
                    .Select(u => new SelectListItem
                    {
                        Value = u.ID.ToString(),
                        Text = $"{u.Name} (ID: {u.ID})"
                    })
                    .ToListAsync();

                model.Destinations = await _context.Destinations
                    .Select(d => new SelectListItem
                    {
                        Value = d.ID.ToString(),
                        Text = $"{d.Name} (ID: {d.ID})"
                    })
                    .ToListAsync();

                model.Accommodations = await _context.Accommodations
                    .Select(a => new SelectListItem
                    {
                        Value = a.ID.ToString(),
                        Text = $"{a.Name} (ID: {a.ID})"
                    })
                    .ToListAsync();

                model.Activities = await _context.Activities
                    .Select(a => new SelectListItem
                    {
                        Value = a.ID.ToString(),
                        Text = $"{a.Name} (ID: {a.ID})"
                    })
                    .ToListAsync();

                return View(model);
            }
        }

        // GET: CreateReview/GetEntities
        [HttpGet]
        public async Task<IActionResult> GetEntities(string entityType)
        {
            if (string.IsNullOrEmpty(entityType))
            {
                return BadRequest("Entity type is required.");
            }

            List<SelectListItem> entities = new List<SelectListItem>();

            switch (entityType)
            {
                case "Destination":
                    entities = await _context.Destinations
                        .Select(d => new SelectListItem
                        {
                            Value = d.ID.ToString(),
                            Text = $"{d.Name} (ID: {d.ID})"
                        })
                        .ToListAsync();
                    break;
                case "Accommodation":
                    entities = await _context.Accommodations
                        .Select(a => new SelectListItem
                        {
                            Value = a.ID.ToString(),
                            Text = $"{a.Name} (ID: {a.ID})"
                        })
                        .ToListAsync();
                    break;
                case "Activity":
                    entities = await _context.Activities
                        .Select(a => new SelectListItem
                        {
                            Value = a.ID.ToString(),
                            Text = $"{a.Name} (ID: {a.ID})"
                        })
                        .ToListAsync();
                    break;
                default:
                    return BadRequest("Invalid entity type.");
            }

            return Json(entities);
        }
    }
}
