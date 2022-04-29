﻿using Lab12_Async_Inn_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Interfaces.Services
{
    public class AmenityRepository : IAmenity
    {
        private readonly AsyncInnDbContext _amenity;

        public AmenityRepository(AsyncInnDbContext amenity)
        {
            _amenity = amenity;
        }
        public async Task<Amenity> Create(Amenity amenity)
        {
            _amenity.Entry(amenity).State = EntityState.Added;
            await _amenity.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _amenity.Entry(amenity).State = EntityState.Deleted;
            await _amenity.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _amenity.Amenities
                .Include(a => a.RoomAmenity)
                .ThenInclude(x => x.Room)
                .ToListAsync();
                
            return amenities;
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity amenity = await _amenity.Amenities
                .Include(_a => _a.RoomAmenity)
                .ThenInclude(x => x.Room)
                .FirstOrDefaultAsync(x => x.Id == id);

            return amenity;
        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _amenity.Entry(amenity).State = EntityState.Modified;
            await _amenity.SaveChangesAsync();
            return amenity;
        }
    }
}
