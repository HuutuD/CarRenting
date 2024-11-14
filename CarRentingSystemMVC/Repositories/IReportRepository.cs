using CarRentingSystemMVC.Data.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IReportRepository
    {
        Task SaveReportAsync(Reports r);
        Task<Reports> GetReportByIdAsync(int id);
        Task DeleteReportAsync(Reports r);
        Task UpdateReportAsync(Reports r);
        Task<List<ReportsDTO>> GetReportsAsync();

    }
}
