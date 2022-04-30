using Lab12_Async_Inn_Management_System.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(RoomDTO room);

        Task<List<RoomDTO>> GetRooms();

        Task<RoomDTO> GetRoom(int id);

        Task<Room> UpdateRoom(int id, RoomDTO room);

        Task Delete(int id);

        Task AddAmenityToRoom(int roomId, int amenityId);

        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
