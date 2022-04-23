using System.Collections.Generic;

namespace Lab12_Async_Inn_Management_System.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RoomAmenity> RoomAmenity { get; set; }
    }
}
