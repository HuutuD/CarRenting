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
            // Lấy danh sách các lịch sử thuê
            var rentalHistories = await _rentalHistoryDTOService.GetAllAsync(RentalHistoriesAPIUrl);

            if (rentalHistories == null || !rentalHistories.Any())
            {
                ViewData["Message"] = "No rental history data available.";
                return View();
            }

           
            var currentUserName = User.Identity.Name; 
            var filteredHistories = rentalHistories
                .Where(r => r.UserName == currentUserName)
                .ToList();

            if (!filteredHistories.Any())
            {
                ViewData["Message"] = "No rental history found for the current user.";
            }

            return View(filteredHistories); // Trả về dữ liệu đã lọc
        }
    }
}
