using Microsoft.AspNetCore.Mvc;
using TravelApp.Data;
using TravelApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TravelApp.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly AppDBContext _context;

        public AdminPanelController(AppDBContext context)
        {
            _context = context;
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

        public IActionResult CreateUser()
        {
            // Initialize the User model and pass it to the view
            return View(new User());
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user); // Return the same view with validation errors
            }

            try
            {
                user.ID = Guid.NewGuid(); // Generate a new unique ID for the user
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Create"); // Redirect to the main Create page
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View(user);
            }
        }


        public IActionResult CreateDestination()
        {
            // Ensure the list of cities is fetched and passed to the view
            var cities = _context.Cities.ToList();

            // Check if cities are null or empty
            if (cities == null || !cities.Any())
            {
                // Add an error message if no cities are found
                ModelState.AddModelError("", "No cities available. Please create a city first.");
            }

            ViewBag.Cities = cities;

            // Pass a new Destination model to the view
            return View(new Destination());
        }


        [HttpPost]
        public IActionResult CreateDestination(Destination destination, string Attractions, Guid City)
        {
            if (!ModelState.IsValid)
            {
                // If the model is invalid, reload the cities for the dropdown and return the view
                ViewBag.Cities = _context.Cities.ToList();
                return View(destination);
            }

            try
            {
                // Handle Attractions as a comma-separated list
                if (!string.IsNullOrWhiteSpace(Attractions))
                {
                    destination.Attractions = Attractions.Split(',').Select(a => a.Trim()).ToList();
                }

                // Assign the selected city using the City ID
                destination.City = _context.Cities.FirstOrDefault(c => c.ID == City);

                // Generate a new GUID for the destination
                destination.ID = Guid.NewGuid();

                // Save the destination to the database
                _context.Destinations.Add(destination);
                _context.SaveChanges();

                // Redirect to the main Create page
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                // Handle any errors during saving
                ModelState.AddModelError("", $"Error: {ex.Message}");

                // Reload the cities for the dropdown
                ViewBag.Cities = _context.Cities.ToList();

                // Return the view with the error message
                return View(destination);
            }
        }

        public IActionResult CreateReview()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }

            try
            {
                review.ID = Guid.NewGuid(); // Generate a unique ID for the review
                _context.Reviews.Add(review);
                _context.SaveChanges();

                return RedirectToAction("Create"); // Redirect to the main Create page
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View(review);
            }
        }
        public IActionResult CreateAccommodation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccommodation(Accommodation accommodation)
        {
            Console.WriteLine("CreateAccommodation POST method invoked.");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid.");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(accommodation);
            }

            try
            {
                Console.WriteLine("Saving accommodation to the database.");
                accommodation.ID = Guid.NewGuid();
                _context.Accommodations.Add(accommodation);
                _context.SaveChanges();
                return RedirectToAction("Index", "AdminPanel");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View(accommodation);
            }
        }



        public IActionResult CreateActivity()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateActivity(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return View(activity);
            }

            try
            {
                activity.ID = Guid.NewGuid(); // Generate a unique ID for the activity
                _context.Activities.Add(activity);
                _context.SaveChanges();

                return RedirectToAction("Create"); // Redirect to the main Create page
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View(activity);
            }
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

                return RedirectToAction("Create"); // Redirect to the main Create page
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View(city);
            }
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
            var reviews = await _context.Reviews.Include(r => r.User).ToListAsync();
            return View(reviews);
        }
        public async Task<IActionResult> ListDestinations()
        {
            var destinations = await _context.Destinations.Include(d => d.City).ToListAsync();
            return View(destinations);
        }
        public async Task<IActionResult> ListActivities()
        {
            var activities = await _context.Activities.Include(a => a.Destination).ToListAsync();
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


    }
}
