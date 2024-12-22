using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models.Entities;
using TravelApp.Models.ViewModels;

namespace TravelApp.Controllers
{
    public class CreateAccommodationController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILogger<AdminPanelController> _logger;

        public CreateAccommodationController(AppDBContext context, ILogger<AdminPanelController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult CreateAccommodation()
        {
            var model = new CreateAccommodationViewModel
            {
                Cities = _context.Cities.ToList()
            };

            if (!model.Cities.Any())
            {
                ModelState.AddModelError("", "No cities available. Please create a city first.");
            }

            return View(model);
        }

        // POST: AdminPanel/CreateAccommodation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccommodation(CreateAccommodationViewModel model)
        {
            _logger.LogInformation("CreateAccommodation POST method invoked.");

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

                // Reload cities for the view
                model.Cities = await _context.Cities.ToListAsync();
                return View(model);
            }

            try
            {
                // Retrieve the selected City
                var city = await _context.Cities.FindAsync(model.CityID);
                if (city == null)
                {
                    throw new Exception("Selected city does not exist.");
                }

                // Create a new Accommodation entity
                var accommodation = new Accommodation
                {
                    ID = Guid.NewGuid(),
                    Name = model.Name,
                    Type = model.Type,
                    Location = model.Location,
                    Price = model.Price,
                    Availability = model.Availability,
                    CityID = model.CityID,
                    City = city
                };

                _context.Accommodations.Add(accommodation);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Accommodation saved successfully.");
                return RedirectToAction("Create", "AdminPanel");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while creating accommodation: {ex.Message}");
                ModelState.AddModelError("", $"Error: {ex.Message}");

                // Reload cities for the view
                model.Cities = await _context.Cities.ToListAsync();
                return View(model);
            }
        }
    }
}
