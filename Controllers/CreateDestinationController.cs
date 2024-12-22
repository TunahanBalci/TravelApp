using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models.Entities;
using TravelApp.Models.ViewModels;

namespace TravelApp.Controllers
{
    public class CreateDestinationController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILogger<AdminPanelController> _logger;

        public CreateDestinationController(AppDBContext context, ILogger<AdminPanelController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult CreateDestination()
        {
            var model = new CreateDestinationViewModel
            {
                Cities = _context.Cities.ToList(),
                Activities = _context.Activities.ToList()
            };

            if (!model.Cities.Any())
            {
                ModelState.AddModelError("", "No cities available. Please create a city first.");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDestination(CreateDestinationViewModel model)
        {
            _logger.LogInformation("CreateDestination POST method invoked.");

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

                // Reload cities and activities for the view
                model.Cities = await _context.Cities.ToListAsync();
                model.Activities = await _context.Activities.ToListAsync();
                return View(model);
            }

            try
            {
                // Create a new Destination
                var destination = new Destination
                {
                    ID = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                    Location = model.Location,
                    CityID = model.CityID,
                    Image_Path = $"/images/destinations/{model.Name}.jpg"
                };

                // Associate City
                var city = await _context.Cities.FindAsync(model.CityID);
                if (city == null)
                {
                    throw new Exception("City not found.");
                }
                destination.City = city;

                // Handle single attraction
                if (!string.IsNullOrWhiteSpace(model.AttractionsInput))
                {
                    _logger.LogInformation("Processing single attraction...");
                    var attractionName = model.AttractionsInput.Trim();

                    var attraction = new Attraction
                    {
                        ID = Guid.NewGuid(),
                        Name = attractionName,
                        DestinationID = destination.ID
                    };

                    _context.Attractions.Add(attraction);
                    destination.Attractions.Add(attraction);

                    _logger.LogInformation($"Attraction added: {attractionName}");
                }
                else
                {
                    _logger.LogInformation("No attraction input provided.");
                }

                // Handle selected activities
                _logger.LogInformation("Retrieving selected activities...");
                var activities = await _context.Activities
                    .Where(a => model.SelectedActivityIds.Contains(a.ID))
                    .ToListAsync();

                foreach (var activity in activities)
                {
                    _logger.LogInformation($"Processing activity ID: {activity.ID}, Name: {activity.Name}");

                    // Initialize Destinations list if null
                    if (activity.Destinations == null)
                    {
                        _logger.LogInformation($"Initializing Destinations list for activity ID: {activity.ID}");
                        activity.Destinations = new List<Destination>();
                    }

                    // Add destination to activity if not already present
                    if (!activity.Destinations.Any(d => d.ID == destination.ID))
                    {
                        _logger.LogInformation($"Adding destination to activity ID: {activity.ID}");
                        activity.Destinations.Add(destination);
                    }

                    // Optionally, add activity to destination.Activities
                    destination.Activities.Add(activity);
                }

                // Save the destination
                _logger.LogInformation("Adding destination to database...");
                _context.Destinations.Add(destination);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Destination saved successfully!");

                return RedirectToAction("Create", "AdminPanel");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while creating destination: {ex.Message}");
                ModelState.AddModelError("", $"Error: {ex.Message}");

                // Reload cities and activities for the view
                model.Cities = await _context.Cities.ToListAsync();
                model.Activities = await _context.Activities.ToListAsync();
                return View(model);
            }
        }

    }
}
