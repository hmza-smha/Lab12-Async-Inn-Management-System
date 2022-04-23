using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<Hotel> GetHotelRooms(int hotelId);

        Task<HotelRoom> AddRoomToHotel(int hotelId, int roomId, int roomNumber);

        Task<Room> RoomDetails(int hotelId, int roomNumber);

        Task<Room> UpdateRoomDetails(int hotelId, int roomNumber, Room room);

        Task DeleteRoomFromHotel(int hotelId, int roomId);
    }
}
