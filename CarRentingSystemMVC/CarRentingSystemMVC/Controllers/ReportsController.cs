using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRentingSystemMVC.Data;
using CarRentingSystemMVC.Data.Models;
using CarRentingSystemMVC.APIs;
using CarRentingSystemMVC.Services;
using Microsoft.Extensions.Options;
using DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Composition;

namespace CarRentingSystemMVC.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApiService<ReportsDTO> _reportDTOService;
        private readonly ApiService<Reports> _reportService;
        private readonly ApiService<RentalHistory> _rentalHistoryService;
        private readonly string ReportsAPIUrl;
        private readonly string RentalHistoriesAPIUrl;

        public ReportsController(
            ApiService<ReportsDTO> reportDTOService,
            ApiService<Reports> reportService,
            ApiService<RentalHistory> rentalHistoryService,
            IOptions<ApiUrls> apiUrls)
        {
            _reportDTOService = reportDTOService;
            _reportService = reportService;
            _rentalHistoryService = rentalHistoryService;
            ReportsAPIUrl = apiUrls.Value.ReportsAPIUrl;
            RentalHistoriesAPIUrl = apiUrls.Value.RentalHistoriesAPIUrl;
        }

        // GET: Reports
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ReportsDTO> reports = await _reportDTOService.GetAllAsync(ReportsAPIUrl);

            if (reports == null || !reports.Any())
            {
                Console.WriteLine("Không có dữ liệu báo cáo nào trả về từ API.");
            }

            return View(reports);
        }

        // GET: Create Report
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Lấy dữ liệu RentalHistories
            IEnumerable<RentalHistory> rentalHistories = await _rentalHistoryService.GetAllAsync(RentalHistoriesAPIUrl);
            return View(rentalHistories);
        }

        // POST: Create Report
        [HttpPost]
        public async Task<IActionResult> Create(Reports reports)
        {
            // Kiểm tra tính hợp lệ của mô hình
            if (!ModelState.IsValid)
            {
                IEnumerable<RentalHistory> rentalHistories = await _rentalHistoryService.GetAllAsync(RentalHistoriesAPIUrl);
                return View(rentalHistories);
            }

            // Lấy thông tin RentalHistory từ API qua RentalHistoryId
            var selectedRentalHistory = await _rentalHistoryService.GetByIdAsync(RentalHistoriesAPIUrl, reports.RentalHistoryId);

            // Nếu tồn tại RentalHistory, gán các thuộc tính vào báo cáo
            if (selectedRentalHistory != null)
            {
                // Bạn có thể truy cập các thuộc tính của RentalHistory như CarBrand, CarModel, v.v.
                reports.DateReport = DateTime.Now;
                reports.Status = "Pending";

                // Nếu bạn muốn gán các thông tin từ RentalHistory vào Reports
                // Ví dụ:
                // reports.CarBrand = selectedRentalHistory.CarBrand; // Nếu bạn muốn lưu lại thông tin về thương hiệu xe
                // reports.CarModel = selectedRentalHistory.CarModel; // Nếu bạn muốn lưu lại thông tin về model xe
                // reports.TotalPrice = selectedRentalHistory.TotalPrice; // Lưu lại tổng giá
                // reports.Days = selectedRentalHistory.Days; // Lưu lại số ngày thuê
            }
            else
            {
                // Nếu không tìm thấy RentalHistory tương ứng, trả về lỗi
                ModelState.AddModelError("", "Invalid RentalHistoryId.");
                return View(reports);
            }

            // Lưu báo cáo mới
            bool isCreated = await _reportService.CreateAsync(ReportsAPIUrl, reports);
            if (isCreated)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating report. Please try again.");
            return View(reports);
        }


        // GET: Edit Report
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Reports reports = await _reportService.GetByIdAsync(ReportsAPIUrl, id);
            if (reports == null)
            {
                return NotFound();
            }

            // Lấy dữ liệu RentalHistories
            IEnumerable<RentalHistory> rentalHistories = await _rentalHistoryService.GetAllAsync(RentalHistoriesAPIUrl);
            ViewBag.RentalHistories = new SelectList(rentalHistories, "Id", "CarModelName"); // Thay "CarModelName" bằng thuộc tính phù hợp
            return View(reports);
        }

        // POST: Edit Report
        [HttpPost]
        public async Task<IActionResult> Edit(Reports reports)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<RentalHistory> rentalHistories = await _rentalHistoryService.GetAllAsync(RentalHistoriesAPIUrl);
                ViewBag.RentalHistories = new SelectList(rentalHistories, "Id", "CarModelName"); // Thay "CarModelName" bằng thuộc tính phù hợp
                return View(reports);
            }

            bool isUpdated = await _reportService.UpdateAsync(ReportsAPIUrl, reports, reports.Id);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error updating report. Please try again.");
            return View(reports);
        }

        // DELETE: Delete Report
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _reportService.DeleteAsync(ReportsAPIUrl, id);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // GET: Report Details
        public async Task<IActionResult> Details(int id)
        {
            Reports reports = await _reportService.GetByIdAsync(ReportsAPIUrl, id);

            if (reports == null)
            {
                return NotFound();
            }
            return View(reports);
        }

        // POST: Approve/Reject Report
        [HttpPost]
        public async Task<IActionResult> ApproveRejectReport(int id, string status)
        {
            Reports reports = await _reportService.GetByIdAsync(ReportsAPIUrl, id);
            if (reports == null)
            {
                return NotFound();
            }

            reports.Status = status; // "Pending", "Approved" or "Rejected"
            bool isUpdated = await _reportService.UpdateAsync(ReportsAPIUrl, reports, reports.Id);

            if (isUpdated)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error updating report status.");
            return View("Details", reports);
        }
    }
}
