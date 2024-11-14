using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentingSystemMVC.Data;
using CarRentingSystemMVC.Data.Models;
using CarRentingSystemMVC.APIs;
using CarRentingSystemMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using DTO;

namespace CarRentingSystemMVC.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApiService<ReportsDTO> _reportDTOService;
        private readonly ApiService<Reports> _reportService;
        private readonly string ReportsAPIUrl;

        public ReportsController(
                ApiService<ReportsDTO> reportDTOService,
                ApiService<Reports> reportService,
                IOptions<ApiUrls> apiUrls)
        {
            _reportDTOService = reportDTOService;
            _reportService = reportService;
            ReportsAPIUrl = apiUrls.Value.ReportsAPIUrl;
        }

        // GET: /Reports
        public async Task<IActionResult> Index()
        {
            List<ReportsDTO> reports = await _reportDTOService.GetAllAsync(ReportsAPIUrl);

            if (reports == null || !reports.Any())
            {
                Console.WriteLine("Không có dữ liệu reports nào trả về từ API.");
            }
            
            if (User.Identity.Name == "Admin")
            {
                return View(reports);
            }
            else
            {               
                var username = User.Identity.Name;

                if (string.IsNullOrEmpty(username))
                {
                    // Nếu không có tên người dùng trong Identity, yêu cầu đăng nhập lại
                    ModelState.AddModelError("", "Không tìm thấy tên người dùng trong phiên làm việc. Vui lòng đăng nhập lại.");
                    return RedirectToAction("Index", "Logins");
                }              
                var userReports = reports.Where(r => r.UserName == username).ToList();

                if (!userReports.Any())
                {
                    ViewData["Message"] = "Không có báo cáo nào của bạn.";
                }

                return View(userReports); 
            }
        }


        // GET: Reports/Create
        public IActionResult Create(int rentalHistoryId)
        {
            return View();
        }

        // POST: Reports/Create 
        // POST: Reports/Create
        [HttpPost]
        public async Task<IActionResult> Create(Reports reports)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    reports.DateReport = reports.DateReport == default ? DateTime.Now : reports.DateReport; 
                    reports.Status = string.IsNullOrEmpty(reports.Status) ? "Pending" : reports.Status; 
                    
                    // Debug: Kiểm tra dữ liệu trước khi gửi tới API
                    Console.WriteLine($"Creating Report with RentalHistoryId: {reports.RentalHistoryId}, DateReport: {reports.DateReport}, Status: {reports.Status}");

                    // Gửi yêu cầu tạo mới tới API
                    bool isCreated = await _reportService.CreateAsync(ReportsAPIUrl, reports);

                    if (isCreated)
                    {
                        return RedirectToAction("Index", "Reports");
                    }
                    else
                    {
                        // Thông báo lỗi nếu không thể tạo
                        ModelState.AddModelError("", "Không thể tạo đơn hàng. Vui lòng thử lại.");
                    }
                }
                catch (Exception ex)
                {
                    // Log chi tiết lỗi
                    ModelState.AddModelError("", $"Có lỗi khi tạo đơn hàng: {ex.Message}");
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                // Thêm thông báo lỗi nếu ModelState không hợp lệ
                Console.WriteLine("ModelState is invalid.");
            }

            return View(reports);
        }


        // POST: Reports/Approve (dành cho Admin để xác nhận Reports)
        [HttpPost]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> Approve(int id)
        {
            Reports reports = await _reportService.GetByIdAsync(ReportsAPIUrl, id);
            if (reports != null)
            {
                var userIdString = HttpContext.Session.GetString("UserId");
                if (string.IsNullOrEmpty(userIdString))
                {
                    ModelState.AddModelError("", "Không tìm thấy UserId trong phiên làm việc. Vui lòng đăng nhập lại.");
                    return RedirectToAction("Index", "Logins");
                }

                // Cập nhật đơn hàng trong API
                bool isApproved = await _reportService.UpdateAsync(ReportsAPIUrl, reports, id);

                if (isApproved)
                {
                    // Sau khi duyệt thành công, chuyển về trang danh sách reports
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Có lỗi khi xác nhận reports. Vui lòng thử lại.");
            }
            return RedirectToAction("Index");
        }

    }
}
