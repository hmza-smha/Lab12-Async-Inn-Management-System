﻿namespace Lab12_Async_Inn_Management_System.Models
{
    public class HotelRoom
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public decimal Rate { get; set; }
        public int RoomNumber { get; set; }

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
