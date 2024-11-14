using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystemMVC.Migrations
{
    public partial class CreateRentalHistoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_RentalHistory_RentalHistoryId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_RentalHistory_RentalHistoryId1",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalHistory",
                table: "RentalHistory");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c527addb-dfe4-481d-8cc6-753effaf047f");

            migrationBuilder.RenameTable(
                name: "RentalHistory",
                newName: "RentalHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalHistories",
                table: "RentalHistories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "48dc2b30-d99c-4bc9-9fbd-7df8890e4175", 0, "26382dab-a0e5-47f1-9129-9fc1a0c5629d", "user@abv.bg", true, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAEL+ws46N5gb8j8N9Y8Dw8L1QY0cY6VXNoQALhE+MTn32I9NIzX+MzUmeMbnA5gvBNg==", null, false, "80cb1969-fdd2-40fd-9eaa-85964bd8d1c7", false, "user" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "48dc2b30-d99c-4bc9-9fbd-7df8890e4175");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "48dc2b30-d99c-4bc9-9fbd-7df8890e4175");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_RentalHistories_RentalHistoryId",
                table: "Reports",
                column: "RentalHistoryId",
                principalTable: "RentalHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_RentalHistories_RentalHistoryId1",
                table: "Reports",
                column: "RentalHistoryId1",
                principalTable: "RentalHistories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_RentalHistories_RentalHistoryId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_RentalHistories_RentalHistoryId1",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalHistories",
                table: "RentalHistories");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "48dc2b30-d99c-4bc9-9fbd-7df8890e4175");

            migrationBuilder.RenameTable(
                name: "RentalHistories",
                newName: "RentalHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalHistory",
                table: "RentalHistory",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c527addb-dfe4-481d-8cc6-753effaf047f", 0, "ceae2c8e-5631-42bc-b320-9ad4edf5c52c", "user@abv.bg", true, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAEA/ahLeqfepCCoR7nVdqpN3m2GvWbX17HRxZblkhJ8vKmzTO87tGMD1CtwKDAh0xkg==", null, false, "d9e47152-3c11-4c28-9c71-e5aae4955893", false, "user" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "c527addb-dfe4-481d-8cc6-753effaf047f");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "c527addb-dfe4-481d-8cc6-753effaf047f");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_RentalHistory_RentalHistoryId",
                table: "Reports",
                column: "RentalHistoryId",
                principalTable: "RentalHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_RentalHistory_RentalHistoryId1",
                table: "Reports",
                column: "RentalHistoryId1",
                principalTable: "RentalHistory",
                principalColumn: "Id");
        }
    }
}
