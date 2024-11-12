using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystemMVC.Models.Admin
{
    public class DashboardViewModel : Controller
     
    {
        public int TotalCars { get; set; }
        public int TotalUsers { get; set; }
        public int TotalRentals { get; set; }
        public int CarsRentedToday { get; set; }
        public int PendingReports { get; set; }
        public double TotalIncome { get; set; }
    }
}
