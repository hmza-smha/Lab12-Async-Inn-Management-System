using Lab12_Async_Inn_Management_System.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
           // get the room
           Room room = await _context.Rooms.FindAsync(id);

            // get the room amenities
            var roomAmenities = await _context.RoomAmenities
                .Where(ra => ra.RoomId == id)
                .Include(a => a.Amenity)
                .ThenInclude(a => a.RoomAmenity)
                .ToListAsync();

            // assign amenities to the got room
            room.RoomAmenity = roomAmenities;

            return room;

            /* 
            // Same Result
            return await _context.Rooms
                .Include(ra => ra.RoomAmenity) // ra is object from Rooms
                .ThenInclude(hr => hr.Amenity) // hr is object from Room amenity so the amenity comes from RoomAmenity
                .FirstOrDefaultAsync(r => r.Id == id);
            */
        }

        public async Task<List<Room>> GetRooms()
        {
            // getting rooms without amenities
            //var rooms = await _context.Rooms.ToListAsync();
            //return rooms;

            return await _context.Rooms
                .Include(ra => ra.RoomAmenity) // ra is object from Rooms
                .ThenInclude(hr => hr.Amenity) // hr is object from Room amenity so the amenity comes from RoomAmenity
                .ThenInclude(x => x.RoomAmenity)
                .ToListAsync();
        }

        
        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var ra = await _context.RoomAmenities
                .Where(x => x.RoomId == roomId && x.AmenityId == amenityId)
                .FirstAsync();

            _context.Entry(ra).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
    }
}
