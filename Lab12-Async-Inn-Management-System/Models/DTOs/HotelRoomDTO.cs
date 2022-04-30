namespace Lab12_Async_Inn_Management_System.Models.DTOs
{
    public class HotelRoomDTO
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public int RoomID { get; set; }
        public RoomDTO Room { get; set; }
    }
}
