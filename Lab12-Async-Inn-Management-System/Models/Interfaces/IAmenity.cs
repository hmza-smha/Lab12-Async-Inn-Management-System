using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab12_Async_Inn_Management_System.Models.Interfaces
{
    public interface IAmenity
    {
        Task<Amenity> Create(Amenity amenity);

        Task<List<Amenity>> GetAmenities();

        Task<Amenity> GetAmenity(int id);

        Task<Amenity> UpdateAmenity(int id, Amenity amenity);

        Task Delete(int id);
    }
}
