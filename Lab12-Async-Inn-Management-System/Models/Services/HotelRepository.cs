using Lab12_Async_Inn_Management_System.Data;
using Lab12_Async_Inn_Management_System.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Interfaces.Services
{
    public class HotelRepository : IHotel
    {
        private AsyncInnDbContext _context;

        public HotelRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelDTO> GetHotel(int id)
        {
            return await _context.Hotels
                .Select(hotel => new HotelDTO
                {
                    ID = hotel.Id,
                    Name = hotel.Name,
                    StreetAddress = hotel.StAddress,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.Phone,
                    Rooms = hotel.HotelRoom
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
                                    ID = a.AmenityId,
                                    Name = a.Amenity.Name,
                                }).ToList(),
                            }
                        }).ToList(),
                }).FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<HotelDTO>> GetHotels()
        {
            var hotels = await _context.Hotels
                .Select(hotel => new HotelDTO
                {
                    ID = hotel.Id,
                    Name = hotel.Name,
                    StreetAddress = hotel.StAddress,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.Phone,
                    Rooms = hotel.HotelRoom
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
                                    ID = a.AmenityId,
                                    Name = a.Amenity.Name,
                                }).ToList(),
                            }
                        }).ToList(),

                }).ToListAsync();

            return hotels;
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
