using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystemMVC.Migrations
{
    public partial class DeletePriceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15a99fb1-b119-4111-8737-a8570e221143");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Rents",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "RentalHistories",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 200000.0,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 200000m);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a2443445-9cf2-461d-8182-f485e6dc83da", 0, "32aa42d7-eeed-4575-a937-9d9a0cec83e3", "user@abv.bg", true, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAENfy05w0zL/vcPjHNuXMKwDQzFiS7PWWgY0gaeuDzsi/A9GoIkmp4+jx1G2xXWaOOg==", null, false, "236abae6-5b54-4d54-948a-32067882e6d6", false, "user" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "UserId" },
                values: new object[] { 300000.0, "a2443445-9cf2-461d-8182-f485e6dc83da" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "UserId" },
                values: new object[] { 500000.0, "a2443445-9cf2-461d-8182-f485e6dc83da" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2443445-9cf2-461d-8182-f485e6dc83da");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Rents",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "RentalHistories",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 200000m,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 200000.0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "15a99fb1-b119-4111-8737-a8570e221143", 0, "2aa60b53-0b29-4030-95b1-bda0f7399aaa", "user@abv.bg", true, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAEAtCPZ0kx52d7SqDTQIYTQetdx/RhLajB3UGktNShnynfodECICyqb4OXlp8081zSg==", null, false, "72c41090-1ac0-4559-9303-149656440f2f", false, "user" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "UserId" },
                values: new object[] { 300000m, "15a99fb1-b119-4111-8737-a8570e221143" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "UserId" },
                values: new object[] { 500000m, "15a99fb1-b119-4111-8737-a8570e221143" });
        }
    }
}
