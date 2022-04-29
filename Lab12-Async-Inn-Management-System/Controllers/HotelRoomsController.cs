using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12_Async_Inn_Management_System.Data;
using Lab12_Async_Inn_Management_System.Models;
using Lab12_Async_Inn_Management_System.Models.Interfaces;

namespace Lab12_Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _HotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _HotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms/1/Rooms
        [HttpGet("{hotelId}/Rooms")]
        public async Task<ActionResult<Hotel>> GetHotelRooms(int hotelId)
        {
            var hotelRooms = await _HotelRoom.GetHotelRooms(hotelId);
            return Ok(hotelRooms);
        }

        // POST: api/HotelRooms/5/Rooms
        [HttpPost("{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int hotelId, HotelRoom hr)
        {
            if(hotelId != hr.HotelId)
            {
                return BadRequest();
            }

            var hotelRoom = await _HotelRoom.AddRoomToHotel(hotelId, hr);
            return Ok(hotelRoom);
        }

        // DELETE: api/HotelRooms/5/Rooms/1
        [HttpDelete("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelId, int roomNumber)
        {
            await _HotelRoom.DeleteRoomFromHotel(hotelId, roomNumber);
            return NoContent();
        }

        // GET: api/HotelRooms/1/Rooms/1
        [HttpGet("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> GetRoomDetails(int hotelId, int roomNumber)
        {
            var room = await _HotelRoom.RoomDetails(hotelId, roomNumber);
            return Ok(room);
        }

        // PUT: api/HotelRooms/1/Rooms/1/
        [HttpPut("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoom hr)
        {
            if (hr.HotelId != hotelId || hr.RoomNumber != roomNumber)
            {
                return BadRequest();
            }

            var newRoom = await _HotelRoom.UpdateRoomDetails(hotelId, roomNumber, hr);
            return Ok(newRoom);
        }

        //private bool HotelRoomExists(int id)
        //{
        //    return _context.HotelRooms.Any(e => e.HotelId == id);
        //}
    }
}
