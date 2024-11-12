using CarRentingSystemMVC.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRentingSystemMVC.Seeding
{
    public static class DataSeeder
    {
        static string userGeneratedId = Guid.NewGuid().ToString();
        public static IdentityUser UserSeed()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            IdentityUser user = new IdentityUser()
            {
                Id = userGeneratedId,
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@abv.bg",
                NormalizedEmail = "USER@ABV.BG",
                EmailConfirmed = true
            };

            user.PasswordHash = hasher.HashPassword(user, "123456zZ!");

            return user;
        }

        public static List<Category> CategoriesSeed()
        {
            Category category01 = new Category()
            {
                Id = 1,
                Name = "Mini"
            };

            Category category02 = new Category()
            {
                Id = 2,
                Name = "SUV"
            };

            Category category03 = new Category()
            {
                Id = 3,
                Name = "Sport"
            };

            Category category04 = new Category()
            {
                Id = 4,
                Name = "Compact"
            };

            Category category05 = new Category()
            {
                Id = 5,
                Name = "Sedan"
            };

            return new List<Category>() { category01, category02, category03, category04, category05 };
        }

        public static List<Car> CarsSeed()
        {
            Car car01 = new Car()
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Camry",
                ImageUrl = "https://drive.gianhangvn.com/image/toyota-camry-hv-zing-1-2385312j22961.jpg",
                Description = "The best SUV in the entire world! Rent Now!",
                Price = 300.000,
                CategoryId = 2,
                UserId = userGeneratedId
            };

            Car car02 = new Car()
            {
                Id = 2,
                Brand = "Honda",
                Model = "Civic",
                ImageUrl = "https://dsportmag.com/wp-content/uploads/2016/09/WEB-HondaCivicTypeR-000a.jpg",
                Description = "Honda Civic Type R the new generation vehicle! Rent Now!",
                Price = 500.000,
                CategoryId = 5,
                UserId = userGeneratedId
            };

            return new List<Car>() { car01, car02 };
        }
    }
}
