using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab12_Async_Inn_Management_System.Migrations
{
    public partial class AddRoomNumberToHotelRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "HotelRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "HotelRooms");
        }
    }
}
