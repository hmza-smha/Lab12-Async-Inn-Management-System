using Lab12_Async_Inn_Management_System.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId);

        Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoomDTO hr);

        Task<HotelRoomDTO> RoomDetails(int hotelId, int roomNumber);

        Task<HotelRoom> UpdateRoomDetails(int hotelId, int roomNumber, HotelRoomDTO hr);

        Task DeleteRoomFromHotel(int hotelId, int roomNumber);
    }
}
