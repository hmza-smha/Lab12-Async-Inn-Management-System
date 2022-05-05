using Lab12_Async_Inn_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab12_Async_Inn_Management_System.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }

        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { Id = 1, Name = "Async Inn", City = "Amman", Country = "Jordan", Phone = "+962", StAddress = "St. 512", State = "Available" },
              new Hotel { Id = 2, Name = "Async Inn", City = "Irbid", Country = "Jordan", Phone = "+962", StAddress = "St. 325", State = "Available" },
              new Hotel { Id = 3, Name = "Async Inn", City = "Aqaba", Country = "Jordan", Phone = "+962", StAddress = "St. 456", State = "Available" }
            );

            modelBuilder.Entity<Room>().HasData(
              new Room { Id = 1, Name = "Room 1", Layout = 1 },
              new Room { Id = 2, Name = "Room 2", Layout = 2 },
              new Room { Id = 3, Name = "Room 3", Layout = 3 }
            );

            modelBuilder.Entity<Amenity>().HasData(
              new Amenity { Id = 1, Name = "TV" },
              new Amenity { Id = 2, Name = "Cofee Machine" },
              new Amenity { Id = 3, Name = "Ocean View" }
            );

            // add a FK to HotelRoom, as CK
            modelBuilder.Entity<HotelRoom>().HasKey(
                hr => new { hr.HotelId, hr.RoomNumber }
            );

            //// add a FK to RoomAmenity, as CK
            modelBuilder.Entity<RoomAmenity>().HasKey(
                ra => new { ra.RoomId, ra.AmenityId }
            );
        }

    }
}
