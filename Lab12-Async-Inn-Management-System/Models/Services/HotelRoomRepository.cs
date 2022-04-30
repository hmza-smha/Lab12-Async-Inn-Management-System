using Lab12_Async_Inn_Management_System.Data;
using Lab12_Async_Inn_Management_System.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Interfaces.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoomDTO hr)
        {
            HotelRoom hotelRoom = new HotelRoom
            {
                HotelId = hr.HotelID,
                Rate = hr.Rate,
                RoomId = hr.RoomID,
                RoomNumber = hr.RoomNumber
            };

             _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task DeleteRoomFromHotel(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms
                .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
                .FirstAsync();

            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId)
        {
            return await _context.HotelRooms
                .Where(hr => hr.HotelId == hotelId)
                .Select(hr => new HotelRoomDTO
                {
                    HotelID = hr.HotelId,
                    Rate = hr.Rate,
                    RoomID = hr.RoomId,
                    RoomNumber = hr.RoomNumber,
                    Room = new RoomDTO
                    {
                        ID = hr.Room.Id,
                        Name = hr.Room.Name,
                        Layout = hr.Room.Layout,
                        Amenities = hr.Room.RoomAmenity
                            .Select(a => new AmenityDTO
                            {
                                ID = a.RoomId,
                                Name = a.Amenity.Name
                            }).ToList()
                    }
                }).ToListAsync();
        }

        public async Task<HotelRoomDTO> RoomDetails(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms
                .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
                .Select(hr => new HotelRoomDTO
                {
                    RoomID = hr.RoomId,
                    HotelID = hr.HotelId,
                    Rate= hr.Rate,
                    RoomNumber = hr.RoomNumber,
                    Room = new RoomDTO
                    {
                        ID = hr.Room.Id,
                        Layout = hr.Room.Layout,
                        Name = hr.Room.Name,
                        Amenities = hr.Room.RoomAmenity
                            .Select(a => new AmenityDTO
                            {
                                ID= a.RoomId,
                                Name = a.Amenity.Name
                            }).ToList()
                    }
                }).FirstOrDefaultAsync();

            return hotelRoom;
        }

        public async Task<HotelRoom> UpdateRoomDetails(int hotelId, int roomNumber, HotelRoomDTO hr)
        {
            HotelRoom hotelRoom = new HotelRoom
            {
                HotelId = hr.HotelID,
                RoomNumber = hr.RoomID,
                Rate = hr.Rate,
                RoomId = hr.RoomID
            };
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hotelRoom;
        }
    }
}
