using CarRentingSystemMVC.Data;
using CarRentingSystemMVC.Data.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ReportDAO
    {
        private readonly CarsRentDbContext _context;

        public ReportDAO(CarsRentDbContext context)
        {
            _context = context;
        }
        public static async Task<List<ReportsDTO>> GetReportsAsync()
        {
            try
            {
                using (var context = new CarsRentDbContext())
                {
                    var reports = await context.Reports
                        .AsNoTracking()
                        .Include(r => r.RentalHistory)  // 
                        .Select(p => new ReportsDTO
                        {
                            Id = p.Id,
                            FirstName = p.RentalHistory.FirstName,  // Lấy thông tin từ RentalHistory
                            LastName = p.RentalHistory.LastName,
                            CarBrand = p.RentalHistory.CarBrand,
                            CarModel = p.RentalHistory.CarModel,
                            Days = p.RentalHistory.Days,
                            TotalPrice = p.RentalHistory.TotalPrice,
                            UserName = p.RentalHistory.UserName,
                            Address = p.RentalHistory.Address,
                            CreditCardNumber = p.RentalHistory.CreditCardNumber,
                            ExpirationDate = p.RentalHistory.ExpirationDate,
                            CreditCardCVV = p.RentalHistory.CreditCardCVV,
                            DateReport = p.DateReport,
                            Description = p.Description,
                            Status = p.Status,
                            RentalHistoryId = p.RentalHistoryId  //lấy khóa ngoại RentalHistoryId
                        })
                        .ToListAsync();

                    return reports;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<Reports> FindReportByIdAsync(int reportId)
        {
            Reports reports = null;
            try
            {
                using (var context = new CarsRentDbContext())
                {
                    reports = await context.Reports.SingleOrDefaultAsync(x => x.Id == reportId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return reports;
        }

        public static async Task SaveReportAsync(Reports reports)
        {
            try
            {
                using (var context = new CarsRentDbContext())
                {
                    await context.Reports.AddAsync(reports);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task UpdateReportAsync(Reports reports)
        {
            try
            {
                using (var context = new CarsRentDbContext())
                {
                    context.Entry(reports).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task DeleteReportAsync(Reports reports)
        {
            try
            {
                using (var context = new CarsRentDbContext())
                {
                    var existingReport = await context.Reports.SingleOrDefaultAsync(c => c.Id == reports.Id);
                    if (existingReport != null)
                    {
                        context.Reports.Remove(existingReport);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

    }
}
