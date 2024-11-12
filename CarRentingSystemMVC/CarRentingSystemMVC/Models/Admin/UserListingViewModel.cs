using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystemMVC.Models.Admin
{
    // This model represents a single user.
    public class UserListingViewModel : Controller
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public List<UserListingViewModel>? Users { get; set; }

    }

}
