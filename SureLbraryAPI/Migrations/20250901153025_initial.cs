using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SureLbraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "MembershipNumber", "MembershipPrefix", "Name", "Password", "UpdatedAt" },
                values: new object[] { 1, "", new DateTimeOffset(new DateTime(2025, 9, 1, 15, 30, 24, 598, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 0, 0, 0, 0)), "WisdomSure5@gmail.com", 1, "MEM-", "Admin", "Trigger1919", new DateTimeOffset(new DateTime(2025, 9, 1, 15, 30, 24, 598, DateTimeKind.Unspecified).AddTicks(3073), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
