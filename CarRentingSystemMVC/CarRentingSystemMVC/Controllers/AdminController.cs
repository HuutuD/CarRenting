using CarRentingSystemMVC.Data;
using CarRentingSystemMVC.Data.Models;
using CarRentingSystemMVC.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarRentingSystemMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly CarsRentDbContext _data;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(CarsRentDbContext data, UserManager<IdentityUser> userManager)
        {
            _data = data;
            _userManager = userManager;
        }

        // Helper method to check if the user is "Admin"
        private bool IsAdmin()
        {
            return User.Identity != null && User.Identity.IsAuthenticated && User.Identity.Name == "Admin";
        }

        // Admin Dashboard
        public IActionResult Dashboard()
        {
            if (!IsAdmin())
            {
                return Forbid(); // Return 403 Forbidden if the user is not "Admin"
            }

            var dashboardViewModel = new DashboardViewModel
            {
                TotalCars = _data.Cars.Count(),
                TotalUsers = _userManager.Users.Count(),
                TotalRentals = _data.Rents.Count(),
                CarsRentedToday = _data.Rents.Count(),
                TotalIncome = _data.Rents.Sum(r => r.TotalPrice),
                PendingReports = 10
            };
            return View(dashboardViewModel);
        }

        // Manage Rentals
        public IActionResult ManageRentals()
        {
            if (!IsAdmin())
            {
                return Forbid();
            }

            var rentals = _data.Rents
                .Select(r => new RentalListingViewModel
                {
                    Id = r.Id,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    CarBrand = r.CarBrand,
                    CarModel = r.CarModel,
                    Days = r.Days,
                    TotalPrice = r.TotalPrice,
                    UserName = r.User.UserName
                })
                .ToList();

            return View(rentals);
        }

        // View Rental Details
        public IActionResult RentalDetails(int id)
        {
            if (!IsAdmin())
            {
                return Forbid();
            }

            var rental = _data.Rents
                .Where(r => r.Id == id)
                .Select(r => new RentalDetailsViewModel
                {
                    Id = r.Id,
                    CreditCardNumber = r.CreditCardNumber,
                    CreditCardCVV = r.CreditCardCVV,
                    ExpirationDate = r.ExpirationDate,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    Address = r.Address,
                    CarBrand = r.CarBrand,
                    CarModel = r.CarModel,
                    Days = r.Days,
                    TotalPrice = r.TotalPrice,
                    UserName = r.User.UserName
                })
                .FirstOrDefault();

            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // Manage Reports
        public IActionResult ManageReports()
        {
            if (!IsAdmin())
            {
                return Forbid();
            }

            return View();
        }

        // View Total Income Details
        public IActionResult ManageIncomes()
        {
            if (!IsAdmin())
            {
                return Forbid();
            }

            var totalIncome = _data.Rents.Sum(r => r.TotalPrice);
            var rentals = _data.Rents
                .Select(r => new RentalListingViewModel
                {
                    Id = r.Id,
                    CarBrand = r.CarBrand,
                    CarModel = r.CarModel,
                    Days = r.Days,
                    TotalPrice = r.TotalPrice
                })
                .ToList();

            var viewModel = new ManageIncomesViewModel
            {
                TotalIncome = totalIncome,
                Rentals = rentals
            };

            return View(viewModel);
        }


        // Manage Users
        public IActionResult ManageUsers()
        {
            var users = _userManager.Users?
                .Select(u => new UserListingViewModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email
                })
                .ToList();

            return View(users);
        }

        // Edit user view
        public IActionResult EditUser(string id)
        {
            var user = _userManager.Users
                .Where(u => u.Id == id)
                .Select(u => new UserListingViewModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email
                })
                .FirstOrDefault();

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return View(user);
        }

        // Handle edit submission
        [HttpPost]
        public async Task<IActionResult> EditUser(UserListingViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.UserName = model.UserName;
            user.Email = model.Email;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ManageUsers));
            }

            // Handle errors (e.g., show validation errors)
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        // Delete user action
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ManageUsers));
            }

            return StatusCode(500, "An error occurred while deleting the user.");
        }

        // Delete Rental
        [HttpPost]
        public IActionResult DeleteRental(int id)
        {
            if (!IsAdmin())
            {
                return Forbid();
            }

            var rental = _data.Rents.Find(id);

            if (rental == null)
            {
                return NotFound();
            }

            _data.Rents.Remove(rental);
            _data.SaveChanges();

            return RedirectToAction(nameof(ManageRentals));
        }


    }
}
