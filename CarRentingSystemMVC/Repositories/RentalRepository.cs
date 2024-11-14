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
    public class RentalRepository : IRentalRepository
    {
        public async Task<List<RentalHistoryDTO>> GetRentalHistoriesAsync() 
            => await RentalHistoryDAO.GetRentalHistoriesAsync();

    }
}
