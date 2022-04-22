using System.Collections.Generic;

namespace Lab12_Async_Inn_Management_System.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public List<HotelRoom> HotelRoom { get; set; }
    }
}
