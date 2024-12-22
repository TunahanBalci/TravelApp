using Microsoft.AspNetCore.Mvc;
using TravelApp.Data;
using TravelApp.Models.Entities;

namespace TravelApp.Controllers
{
    public class CreateCityController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILogger<AdminPanelController> _logger;

        public CreateCityController(AppDBContext context, ILogger<AdminPanelController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult CreateCity()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            try
            {
                city.ID = Guid.NewGuid(); // Generate a unique ID for the city
                _context.Cities.Add(city);
                _context.SaveChanges();

                return RedirectToAction("Create", "AdminPanel"); // Redirect to the main Create page
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View(city);
            }
        }
    }
}
