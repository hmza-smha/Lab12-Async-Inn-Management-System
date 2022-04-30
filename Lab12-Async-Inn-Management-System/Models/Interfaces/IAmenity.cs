using Lab12_Async_Inn_Management_System.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Interfaces
{
    public interface IAmenity
    {
        Task<Amenity> Create(AmenityDTO amenity);

        Task<List<AmenityDTO>> GetAmenities();

        Task<AmenityDTO> GetAmenity(int id);

        Task<Amenity> UpdateAmenity(int id, AmenityDTO amenity);

        Task Delete(int id);
    }
}
