using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models.Entities;
using TravelApp.Models.ViewModels;

namespace TravelApp.Controllers
{
    public class CreateActivityController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILogger<AdminPanelController> _logger;

        public CreateActivityController(AppDBContext context, ILogger<AdminPanelController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET: Activities/Create
        public async Task<IActionResult> CreateActivity()
        {
            var model = new CreateActivityViewModel
            {
                Destinations = await _context.Destinations
                    .Select(d => new SelectListItem
                    {
                        Value = d.ID.ToString(),
                        Text = $"{d.Name} (ID: {d.ID})"
                    })
                    .ToListAsync()
            };

            // Check if any destinations exist
            if (!model.Destinations.Any())
            {
                ModelState.AddModelError("", "No destinations available. Please create a destination first.");
            }

            return View(model);
        }

        // POST: AdminPanel/CreateActivity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateActivity(CreateActivityViewModel model)
        {
            _logger.LogInformation("CreateActivity POST method invoked.");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is invalid. Errors:");
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    if (errors.Count > 0)
                    {
                        _logger.LogWarning($"Key: {key}");
                        foreach (var error in errors)
                        {
                            _logger.LogWarning($"Error: {error.ErrorMessage}");
                        }
                    }
                }

                // Reload Destinations list
                model.Destinations = await _context.Destinations
                    .Select(d => new SelectListItem
                    {
                        Value = d.ID.ToString(),
                        Text = $"{d.Name} (ID: {d.ID})"
                    })
                    .ToListAsync();

                return View(model);
            }

            try
            {
                // Retrieve the selected Destinations
                var selectedDestinations = await _context.Destinations
                    .Where(d => model.Destination_IDs.Contains(d.ID))
                    .ToListAsync();

                if (selectedDestinations.Count != model.Destination_IDs.Count)
                {
                    throw new Exception("One or more selected destinations do not exist.");
                }

                // Create a new Activity entity
                var activity = new Activity
                {
                    ID = Guid.NewGuid(),
                    Name = model.Name,
                    Type = model.Type,
                    Date = model.Date,
                    Price = model.Price,
                    Requires_Reservation = model.Requires_Reservation
                };

                // Associate Destinations
                foreach (var destination in selectedDestinations)
                {
                    activity.Destinations.Add(destination);
                    // Optionally, add the activity to the destination's activities if bidirectional
                    destination.Activities.Add(activity);
                }

                _context.Activities.Add(activity);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Activity saved successfully.");
                return RedirectToAction("Create", "AdminPanel");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while creating activity: {ex.Message}");
                ModelState.AddModelError("", $"Error: {ex.Message}");

                // Reload Destinations list
                model.Destinations = await _context.Destinations
                    .Select(d => new SelectListItem
                    {
                        Value = d.ID.ToString(),
                        Text = $"{d.Name} (ID: {d.ID})"
                    })
                    .ToListAsync();

                return View(model);
            }
        }
    }
}
