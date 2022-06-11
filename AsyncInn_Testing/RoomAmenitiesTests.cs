using Lab12_Async_Inn_Management_System.Models.Interfaces.Services;
using Lab12_Async_Inn_Management_System.Models.DTOs;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInn_Testing
{
    public class RoomAmenitiesTests : Mock
    {
        [Fact]
        public async Task Can_add_and_Remove_amenity_to_room()
        {
            // Arrange
            var amenity = await CreateAndSaveTestAmenity();
            var room = await CreateAndSaveTestRoom();

            var repository = new RoomRepository(_db);

            // Act
            await repository.AddAmenityToRoom(room.Id, amenity.Id);

            // Assert
            var actualRoom = await repository.GetRoom(room.Id);
            Assert.Contains(actualRoom.Amenities, x => x.ID == amenity.Id);

            // Act
            await repository.RemoveAmentityFromRoom(room.Id, amenity.Id);

            // Assert
            actualRoom = await repository.GetRoom(room.Id);
            Assert.DoesNotContain(actualRoom.Amenities, x => x.ID == amenity.Id);
        }
    }
}
