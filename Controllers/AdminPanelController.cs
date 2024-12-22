using Microsoft.AspNetCore.Mvc;
using TravelApp.Data;
using TravelApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using TravelApp.Models.ViewModels;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelApp.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILogger<AdminPanelController> _logger;

        public AdminPanelController(AppDBContext context, ILogger<AdminPanelController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Entity/Create
        public IActionResult Create(string entityType)
        {
            ViewBag.EntityType = entityType;

            if (entityType == "Review")
            {
                ViewBag.EntityTypes = new[] { "Destination", "Accommodation", "Activity" };
            }

            return View();
        }

        // POST: Entity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string entityType, object entityData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    switch (entityType)
                    {
                        case "Activity":
                            _context.Activities.Add((Activity)entityData);
                            break;
                        case "Accommodation":
                            _context.Accommodations.Add((Accommodation)entityData);
                            break;
                        case "Destination":
                            _context.Destinations.Add((Destination)entityData);
                            break;
                        case "City":
                            _context.Cities.Add((City)entityData);
                            break;
                        case "User":
                            _context.Users.Add((User)entityData);
                            break;
                        case "Review":
                            _context.Reviews.Add((Review)entityData);
                            break;
                        default:
                            throw new Exception("Unsupported entity type.");
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            ViewBag.EntityType = entityType;
            if (entityType == "Review")
            {
                ViewBag.EntityTypes = new[] { "Destination", "Accommodation", "Activity" };
            }

            return View(entityData);
        }
        public async Task<IActionResult> List()
        {
            return View();
        }










        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListUsers()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
        public async Task<IActionResult> ListReviews()
        {
            var reviews = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Destination)
                .Include(r => r.Accommodation)
                .Include(r => r.Activity)
                .ToListAsync();

            return View(reviews);
        }
        public async Task<IActionResult> ListDestinations()
        {
            var destinations = await _context.Destinations.Include(d => d.City).ToListAsync();
            return View(destinations);
        }
        public async Task<IActionResult> ListActivities()
        {
            var activities = await _context.Activities
                .Include(a => a.Destinations) // Include multiple destinations for each activity
                .ToListAsync();
            return View(activities);
        }

        public async Task<IActionResult> ListCities()
        {
            var cities = await _context.Cities.ToListAsync();
            return View(cities);
        }
        public async Task<IActionResult> ListAccommodations()
        {
            var accommodations = await _context.Accommodations.Include(a => a.City).ToListAsync();
            return View(accommodations);
        }


        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test(IFormCollection collection)
        {


            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
