using CarRentingSystemMVC.Data;
using CarRentingSystemMVC.Data.Models;
using CarRentingSystemMVC.Models.Admin;
using CarRentingSystemMVC.Models.Rent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRentingSystemMVC.Controllers
{
    [Authorize]
    public class RentsController : Controller
    {
        private readonly CarsRentDbContext _data;
        public RentsController(CarsRentDbContext data)
        {
            this._data = data;
        }

        public IActionResult Checkout(int id)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Car car = this._data.Cars.First(c => c.Id == id);
            if (currentUserId == car.UserId)
            {
                return Unauthorized();
            }

            RentFormModel rentFormModel = new RentFormModel();
            rentFormModel.PricePerDay = car.Price;
            return View(rentFormModel);
        }

        [HttpPost]
        public IActionResult Checkout(int id, RentFormModel rentFormModel)
        {
            Car car = this._data.Cars.First(c => c.Id == id);
            rentFormModel.CarBrand = car.Brand;
            rentFormModel.CarModel = car.Model;
            rentFormModel.PricePerDay = car.Price;
            rentFormModel.TotalPrice = rentFormModel.PricePerDay * rentFormModel.Days;

            ModelState.Remove("CarModel");
            ModelState.Remove("CarBrand");
            ModelState.Remove("PricePerDay");
            if (rentFormModel.TotalPrice < 0)
            {
                ModelState.AddModelError(string.Empty, "Total price cannot be negative.");
                return View(rentFormModel);
            }
            if (!ModelState.IsValid)
            {
                return View(rentFormModel);
            }

            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (rentFormModel.ExpirationDate.Year < DateTime.Now.Year)
            {
                ModelState.AddModelError(string.Empty, "Your credit/debit card has expired.");

                return View(rentFormModel);
            }
            else if (rentFormModel.ExpirationDate.Year == DateTime.Now.Year && rentFormModel.ExpirationDate.Month < DateTime.Now.Month)
            {
                ModelState.AddModelError(string.Empty, "Your credit/debit card has expired.");

                return View(rentFormModel);
            }

            Rent rent = new Rent()
            {
                CreditCardNumber = rentFormModel.CreditCardNumber,
                CreditCardCVV = rentFormModel.CreditCardCVV,
                ExpirationDate = rentFormModel.ExpirationDate.ToString("MM/yyyy"),
                FirstName = rentFormModel.FirstName,
                LastName = rentFormModel.LastName,
                Address = rentFormModel.Address,
                CarBrand = rentFormModel.CarBrand,
                CarModel = rentFormModel.CarModel,
                Days = rentFormModel.Days,
                TotalPrice = rentFormModel.TotalPrice,
                UserId = currentUserId
            };

            this._data.Cars.Remove(car);

            this._data.Rents.Add(rent);

             RentalHistory rentalHistory = new RentalHistory
            {
                FirstName = rentFormModel.FirstName,
                LastName = rentFormModel.LastName,
                CarBrand = rentFormModel.CarBrand,
                CarModel = rentFormModel.CarModel,
                Days = rentFormModel.Days,
                TotalPrice = rentFormModel.TotalPrice,
                UserName = User.Identity.Name,
                Address = rentFormModel.Address,
                CreditCardNumber = rentFormModel.CreditCardNumber,
                ExpirationDate = rentFormModel.ExpirationDate.ToString("MM/yyyy"),
                CreditCardCVV = rentFormModel.CreditCardCVV
            };

            this._data.RentalHistories.Add(rentalHistory);
            this._data.SaveChanges();

            return View("ThankYou");
        }


    }
}
