using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace CarRentingSystemMVC.Models.Admin
{
    public class ManageIncomesViewModel : Controller
    {
        public double TotalIncome { get; set; }

        public IEnumerable<RentalListingViewModel>? Rentals { get; set; }
    }
}