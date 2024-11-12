using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystemMVC.Migrations
{
    public partial class AddReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c04806ee-5ce4-47b9-af63-58a0179468ea");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 200000.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 50.0);

            migrationBuilder.CreateTable(
                name: "RentalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditCardCVV = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalHistoryId = table.Column<int>(type: "int", nullable: false),
                    DateReport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalHistoryId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_RentalHistory_RentalHistoryId",
                        column: x => x.RentalHistoryId,
                        principalTable: "RentalHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_RentalHistory_RentalHistoryId1",
                        column: x => x.RentalHistoryId1,
                        principalTable: "RentalHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c527addb-dfe4-481d-8cc6-753effaf047f", 0, "ceae2c8e-5631-42bc-b320-9ad4edf5c52c", "user@abv.bg", true, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAEA/ahLeqfepCCoR7nVdqpN3m2GvWbX17HRxZblkhJ8vKmzTO87tGMD1CtwKDAh0xkg==", null, false, "d9e47152-3c11-4c28-9c71-e5aae4955893", false, "user" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "ImageUrl", "Model", "Price", "UserId" },
                values: new object[] { "Toyota", "https://drive.gianhangvn.com/image/toyota-camry-hv-zing-1-2385312j22961.jpg", "Camry", 300.0, "c527addb-dfe4-481d-8cc6-753effaf047f" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "Description", "ImageUrl", "Model", "Price", "UserId" },
                values: new object[] { "Honda", "Honda Civic Type R the new generation vehicle! Rent Now!", "https://dsportmag.com/wp-content/uploads/2016/09/WEB-HondaCivicTypeR-000a.jpg", "Civic", 500.0, "c527addb-dfe4-481d-8cc6-753effaf047f" });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_RentalHistoryId",
                table: "Reports",
                column: "RentalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_RentalHistoryId1",
                table: "Reports",
                column: "RentalHistoryId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "RentalHistory");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c527addb-dfe4-481d-8cc6-753effaf047f");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 50.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 200000.0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c04806ee-5ce4-47b9-af63-58a0179468ea", 0, "26582f16-48e6-4029-8df0-a8a34b89eb5b", "user@abv.bg", true, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAEJwzEPFcPAOngAq4v7sr2IYqJiZ3/mVrTwTcVtyvvPvcuPm0J7tY4elP8vJTdK4ZZw==", null, false, "4e6e93c6-06d5-4c02-8ff2-818489c18d34", false, "user" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "ImageUrl", "Model", "Price", "UserId" },
                values: new object[] { "BMW", "https://cdni.autocarindia.com/Utils/ImageResizer.ashx?n=https://cdni.autocarindia.com/ExtraImages/20230714060819_BMW_X5_facelift.jpg", "X5", 55.310000000000002, "c04806ee-5ce4-47b9-af63-58a0179468ea" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "Description", "ImageUrl", "Model", "Price", "UserId" },
                values: new object[] { "Audi", "Audi A7 is a new generation vehicle! Rent Now!", "https://media.audifrance.fr/wp-content/uploads/2020/08/929104-2000x1414.jpg", "A7", 165.28999999999999, "c04806ee-5ce4-47b9-af63-58a0179468ea" });
        }
    }
}
