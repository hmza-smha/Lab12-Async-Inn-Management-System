using Lab12_Async_Inn_Management_System.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoom hr)
        {
             _context.Entry(hr).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hr;
        }

        public async Task DeleteRoomFromHotel(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms
                .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
                .FirstAsync();

            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotelRooms(int hotelId)
        {
            return await _context.Hotels
                .Include(h => h.HotelRoom)
                .ThenInclude(a => a.Room)
                .ThenInclude(x => x.RoomAmenity)
                .ThenInclude(c => c.Amenity)
                .FirstOrDefaultAsync(h => h.Id == hotelId);
        }

        public async Task<HotelRoom> RoomDetails(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms
                .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
                .Include(x => x.Room)
                .FirstOrDefaultAsync(x => x.HotelId == hotelId && x.RoomNumber == roomNumber);

            return hotelRoom;
        }

        public async Task<HotelRoom> UpdateRoomDetails(int hotelId, int roomNumber, HotelRoom hr)
        {
            _context.Entry(hr).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hr;
        }
    }
}
