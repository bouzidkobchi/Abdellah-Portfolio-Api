using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abdellah_Portfolio.Migrations
{
    public partial class setpasswordhash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2023, 8, 18, 6, 20, 49, 152, DateTimeKind.Local).AddTicks(7694), "AQAAAAEAACcQAAAAEEbixmlN3jVIJvWwbLCgt2A9UgYsJ7ek/EBMlc4o550htLTBzsyKcioww2qMYrn66Q==", "6a8a9192-9d8e-4be5-aca2-a64533ea9f03" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2023, 8, 18, 6, 19, 38, 634, DateTimeKind.Local).AddTicks(1656), "", "1640fcf8-967b-45ee-9fd4-283364f62847" });
        }
    }
}
