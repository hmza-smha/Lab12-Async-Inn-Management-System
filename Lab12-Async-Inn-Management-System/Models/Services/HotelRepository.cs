using Lab12_Async_Inn_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            // The system knows we have a primary key and will use it
            Hotel hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var rooms = await _context.Hotels.ToListAsync();
            return rooms;
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
