using Lab12_Async_Inn_Management_System.Data;
using Lab12_Async_Inn_Management_System.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<Amenity> Create(AmenityDTO amenity)
        {
            Amenity newAmenity = new Amenity
            {
                Id = amenity.ID,
                Name = amenity.Name,
            };
            _amenity.Entry(newAmenity).State = EntityState.Added;
            await _amenity.SaveChangesAsync();
            return newAmenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await _amenity.Amenities.FindAsync(id);
            _amenity.Entry(amenity).State = EntityState.Deleted;
            await _amenity.SaveChangesAsync();
        }

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            return await _amenity.Amenities
                .Select(a => new AmenityDTO
                {
                    ID = a.Id,
                    Name = a.Name,
                }).ToListAsync();
        }

        public async Task<AmenityDTO> GetAmenity(int id)
        {
            return await _amenity.Amenities
                .Where(x => x.Id == id)
                .Select(a => new AmenityDTO
                {
                    ID = a.Id,
                    Name = a.Name
                }).FirstAsync();
        }

        public async Task<Amenity> UpdateAmenity(int id, AmenityDTO amenity)
        {
            Amenity updatedAmenity = new Amenity
            {
                Id = amenity.ID,
                Name = amenity.Name,
            };
            _amenity.Entry(updatedAmenity).State = EntityState.Modified;
            await _amenity.SaveChangesAsync();
            return updatedAmenity;
        }
    }
}
