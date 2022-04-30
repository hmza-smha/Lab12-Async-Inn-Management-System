using Lab12_Async_Inn_Management_System.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Lab12_Async_Inn_Management_System.Models.DTOs;

/// NOTE:
/// JsonException: A possible object cycle was detected.
/// This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
/// Consider using ReferenceHandler.Preserve on JsonSerializerOptions to support cycles.
/// 
/// To solve this exception download newotonsoftJson dependency
/// and remember to 1) change the version 2) modefiy services.AddControllers() in Startup.cs
/// 

namespace Lab12_Async_Inn_Management_System.Models.Interfaces.Services
{
    public class RoomRepository : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity ra = new RoomAmenity
            {
                RoomId = roomId,
                AmenityId = amenityId
            };

            _context.Entry(ra).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> Create(RoomDTO room)
        {
            Room newRoom = new Room
            {
                Id = room.ID,
                Name = room.Name,
                Layout = room.Layout
            };

            _context.Entry(newRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newRoom;
        }

        public async Task Delete(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            return await _context.Rooms
                 .Where(r => r.Id == id)
                 .Select(r => new RoomDTO
                 {
                     ID = r.Id,
                     Name = r.Name,
                     Layout = r.Layout,
                     Amenities = r.RoomAmenity
                         .Select(a => new AmenityDTO
                         {
                             ID = a.AmenityId,
                             Name = a.Room.Name
                         }).ToList()
                 }).FirstOrDefaultAsync();
        }

        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _context.Rooms
                .Select(r => new RoomDTO
                {
                    ID = r.Id,
                    Name = r.Name,
                    Layout = r.Layout,
                    Amenities = r.RoomAmenity
                        .Select(a => new AmenityDTO
                        {
                            ID = a.AmenityId,
                            Name = a.Room.Name
                        }).ToList()
                }).ToListAsync();
        }

        
        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var ra = await _context.RoomAmenities
                .Where(x => x.RoomId == roomId && x.AmenityId == amenityId)
                .FirstAsync();

            _context.Entry(ra).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> UpdateRoom(int id, RoomDTO room)
        {
            Room updatedRoom = new Room
            {
                Id = room.ID,
                Name = room.Name,
                Layout = room.Layout

            };

            _context.Entry(updatedRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updatedRoom;
        }
    }
}
