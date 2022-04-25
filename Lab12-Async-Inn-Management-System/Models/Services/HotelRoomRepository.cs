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

        public async Task<HotelRoom> AddRoomToHotel(int hotelId, int roomId, int roomNumber)
        {
            var hotelRoom = new HotelRoom
            {
                HotelId = hotelId,
                RoomNumber = roomNumber,
                RoomId = roomId
            };

             _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task DeleteRoomFromHotel(int hotelId, int roomId)
        {
            var hotelRoom = await _context.HotelRooms
                .Where(hr => hr.HotelId == hotelId && hr.RoomId == roomId)
                .FirstAsync();

            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotelRooms(int hotelId)
        {
            return await _context.Hotels
                .Include(h => h.HotelRoom)
                .ThenInclude(a => a.Room)

                .FirstOrDefaultAsync(h => h.Id == hotelId);
        }

        public async Task<Room> RoomDetails(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms
                .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
                .FirstAsync();

            var room = await _context.Rooms
                .Where(r => r.Id == hotelRoom.RoomId)
                .FirstAsync();

            return room;
        }


        public async Task<HotelRoom> UpdateRoomDetails(int roomNumber, HotelRoom hr)
        {
            //var hotelRoom = await _context.HotelRooms
            //    .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
            //    .FirstAsync();

            //hotelRoom.RoomNumber = hr.RoomNumber;
            //hotelRoom.Rate = hr.Rate;

            _context.Entry(hr).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hr;
        }
    }
}
