using CarRentingSystemMVC.APIs;
using CarRentingSystemMVC.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CarRentingSystemMVC.Controllers
{
    public class RentalHistoriesController : Controller
    {
        private readonly ApiService<RentalHistoryDTO> _rentalHistoryDTOService;
        private readonly string RentalHistoriesAPIUrl;

        public RentalHistoriesController(
           ApiService<RentalHistoryDTO> rentalHistoryDTOService,
           IOptions<ApiUrls> apiUrls
       )
        {
            _rentalHistoryDTOService = rentalHistoryDTOService;
            RentalHistoriesAPIUrl = apiUrls.Value.RentalHistoriesAPIUrl;
        }

        // GET: RentalHistories
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rentalHistories = await _rentalHistoryDTOService.GetAllAsync(RentalHistoriesAPIUrl);
            if (rentalHistories == null || !rentalHistories.Any())
            {
                ViewData["Message"] = "No rental history data available.";
                return View();
                Console.WriteLine($"Rental histories fetched: {rentalHistories.Count()} records.");
            }
            
            return View(rentalHistories);
        }
    }
}
