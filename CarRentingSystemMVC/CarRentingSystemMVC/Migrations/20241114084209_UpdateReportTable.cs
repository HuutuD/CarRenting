using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystemMVC.Migrations
{
    public partial class UpdateReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_RentalHistories_RentalHistoryId1",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_RentalHistoryId1",
                table: "Reports");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "48dc2b30-d99c-4bc9-9fbd-7df8890e4175");

            migrationBuilder.DropColumn(
                name: "RentalHistoryId1",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "RentalHistories",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Days",
                table: "RentalHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f3b32ed6-5f01-45bb-8eb1-0fe311d06306", 0, "ebcf85d6-f18a-4bd8-9a36-da3aac01e0c2", "user@abv.bg", true, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAEGV982faLbCysuKp/zg1Okr0EC4ay2Bo9NLydYAl2Pl+8exbDVr5xP9r9rrKy779mg==", null, false, "eccf9f4f-e9af-4eaf-9996-a5fac4658847", false, "user" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "f3b32ed6-5f01-45bb-8eb1-0fe311d06306");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "f3b32ed6-5f01-45bb-8eb1-0fe311d06306");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b32ed6-5f01-45bb-8eb1-0fe311d06306");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "RentalHistoryId1",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "RentalHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Days",
                table: "RentalHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Reports_RentalHistoryId1",
                table: "Reports",
                column: "RentalHistoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_RentalHistories_RentalHistoryId1",
                table: "Reports",
                column: "RentalHistoryId1",
                principalTable: "RentalHistories",
                principalColumn: "Id");
        }
    }
}
