using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models.Entities;

namespace TravelApp.Controllers
{
    public class CreateUserController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILogger<AdminPanelController> _logger;

        public CreateUserController(AppDBContext context, ILogger<AdminPanelController> logger)
        {
            _context = context;
            _logger = logger;
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
                return RedirectToAction("Create", "AdminPanel");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View(user);
            }
        }
    }
}
