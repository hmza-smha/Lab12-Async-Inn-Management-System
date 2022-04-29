using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<Hotel> GetHotelRooms(int hotelId);

        Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoom hr);

        Task<HotelRoom> RoomDetails(int hotelId, int roomNumber);

        Task<HotelRoom> UpdateRoomDetails(int hotelId, int roomNumber, HotelRoom hr);

        Task DeleteRoomFromHotel(int hotelId, int roomNumber);
    }
}
