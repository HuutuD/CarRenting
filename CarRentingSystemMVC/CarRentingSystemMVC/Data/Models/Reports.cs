﻿using System.ComponentModel.DataAnnotations;

namespace CarRentingSystemMVC.Data.Models
{
    public class Reports
    {
        [Key]
        public int Id { get; set; }
        public int? RentalHistoryId { get; set; }
        public RentalHistory? RentalHistory { get; set; }
        public DateTime? DateReport { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
    }
}
