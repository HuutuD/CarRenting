using CarRentingSystemMVC.Data;
using CarRentingSystemMVC.Data.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RentalHistoryDAO
    {
        private readonly CarsRentDbContext _context;

        public RentalHistoryDAO(CarsRentDbContext context)
        {
            _context = context;
        }
        public static async Task<List<RentalHistoryDTO>> GetRentalHistoriesAsync()
        {
            try
            {
                using (var context = new CarsRentDbContext())
                {
                    var rentalHistories = await context.RentalHistories
                        .AsNoTracking()
                        .Select(p => new RentalHistoryDTO
                        {
                            Id = p.Id,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            CarBrand = p.CarBrand,
                            CarModel = p.CarModel,
                            Days = p.Days,
                            TotalPrice = p.TotalPrice,
                            Address = p.Address,
                            CreditCardNumber = p.CreditCardNumber,
                            ExpirationDate = p.ExpirationDate,
                            CreditCardCVV = p.CreditCardCVV,
                            UserName = p.UserName,
                        })
                        .ToListAsync();

                    return rentalHistories;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
