using Microsoft.AspNetCore.Mvc;
namespace CarRentingSystemMVC.Models.Admin
{
    public class RentalDetailsViewModel : Controller
    {
        public RentalDetailsViewModel() { }
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CarBrand { get; set; }
        public string? CarModel { get; set; }
        public int Days { get; set; }
        public double TotalPrice { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }
        public string? CreditCardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? CreditCardCVV { get; set; }
    }
}
