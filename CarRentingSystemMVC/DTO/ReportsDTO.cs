using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReportsDTO
    {
        [Key]
        public int Id { get; set; }
        public int? RentalHistoryId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CarBrand { get; set; }
        public string? CarModel { get; set; }
        public string? Description { get; set; }
        public int? Days { get; set; }
        public double? TotalPrice { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }
        public string? CreditCardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? CreditCardCVV { get; set; }
        public DateTime? DateReport { get; set; }
        public string? Status { get; set; }
    }
}
