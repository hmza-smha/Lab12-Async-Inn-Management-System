using Lab12_Async_Inn_Management_System.Data;
using Lab12_Async_Inn_Management_System.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInn_Testing
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly AsyncInnDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new AsyncInnDbContext(
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<Hotel> CreateAndSaveTestHotel()
        {
            var hotel = new Hotel { Name = "HotelTest" };
            _db.Hotels.Add(hotel);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, hotel.Id); // Sanity check
            return hotel;
        }

        protected async Task<Room> CreateAndSaveTestRoom()
        {
            var room = new Room { Name = "TestRoom", Layout = 1 };
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, room.Id); // Sanity check
            return room;
        }

        protected async Task<Amenity> CreateAndSaveTestAmenity()
        {
            var amenity = new Amenity { Name = "TestAmenity" };
            _db.Amenities.Add(amenity);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, amenity.Id); // Sanity check
            return amenity;
        }
    }
}
