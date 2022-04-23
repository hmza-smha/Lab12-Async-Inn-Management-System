﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(Room room);

        Task<List<Room>> GetRooms();

        Task<Room> GetRoom(int id);

        Task<Room> UpdateRoom(int id, Room room);

        Task Delete(int id);

        Task AddAmenityToRoom(int roomId, int amenityId);

        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}