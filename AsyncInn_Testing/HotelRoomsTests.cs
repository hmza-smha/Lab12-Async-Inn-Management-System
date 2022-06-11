using Lab12_Async_Inn_Management_System.Models.Interfaces.Services;
using Lab12_Async_Inn_Management_System.Models.DTOs;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInn_Testing
{
    public class HotelRoomsTests : Mock
    {
        [Fact]
        public async Task Can_add_and_Remove_room_to_hotel()
        {
            // Arrange
            var hotel = await CreateAndSaveTestHotel();
            var room = await CreateAndSaveTestRoom();

            var repository = new HotelRoomRepository(_db);

            // Act
            await repository.AddRoomToHotel(hotel.Id, new HotelRoomDTO {
                HotelID = hotel.Id,
                Rate = 100,
                RoomID = room.Id,
                RoomNumber = 105
            });

            // Assert
            var actualHotelRoom = await repository.RoomDetails(hotel.Id, 105);
            Assert.Equal(105, actualHotelRoom.RoomNumber);

            // Act
            await repository.DeleteRoomFromHotel(hotel.Id, 105);

            // Assert
            actualHotelRoom = await repository.RoomDetails(hotel.Id, 105);
            Assert.Null(actualHotelRoom);
        }
    }
}
