using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab12_Async_Inn_Management_System.Migrations
{
    public partial class Seed_Roles_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "DistrictManager", "766af6a3-08fd-4abe-8ff0-abd94c7855a8", "DistrictManager", "DistrictManager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "PropertyManager", "08b943da-7bff-4562-b36e-12bed276ae16", "PropertyManager", "PropertyManager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "Agent", "f8dec24f-4c88-4fee-91ed-bf44a08be1c3", "Agent", "Agent" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Agent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "DistrictManager");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "PropertyManager");
        }
    }
}
