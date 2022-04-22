using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab12_Async_Inn_Management_System.Migrations
{
    public partial class UpdateAmenityData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "TV");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Cofee Machine");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Ocean View");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Amenity 1");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Amenity 2");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Amenity 3");
        }
    }
}
