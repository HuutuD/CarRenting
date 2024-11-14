using System.ComponentModel.DataAnnotations;
using System.Composition;

namespace CarRentingSystemMVC.Data.Models
{
    public class RentalHistory
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CarBrand { get; set; }
        public string? CarModel { get; set; }
        public int? Days { get; set; }
        public double? TotalPrice { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }
        public string? CreditCardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? CreditCardCVV { get; set; }
        public ICollection<Reports>? Reports { get; set; } = new List<Reports>();
    }
}
