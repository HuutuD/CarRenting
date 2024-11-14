using CarRentingSystemMVC.Data.Models;
using DataAccess;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ReportRepository : IReportRepository
    {
        public async Task DeleteReportAsync(Reports r) => await ReportDAO.DeleteReportAsync(r);
        public async Task<Reports> GetReportByIdAsync(int id) => await ReportDAO.FindReportByIdAsync(id);
        public async Task<List<ReportsDTO>> GetReportsAsync() => await ReportDAO.GetReportsAsync();
        public async Task SaveReportAsync(Reports r) => await ReportDAO.SaveReportAsync(r);
        public async Task UpdateReportAsync(Reports r) => await ReportDAO.UpdateReportAsync(r);

    }
}
